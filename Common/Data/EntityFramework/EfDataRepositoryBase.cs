using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.Common.Data;
using Core.Common.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Common.Data.EntityFramework
{
    /// <summary>
    /// An Entity Framework base abastract class which implements the IDataRepository interface. All repository classes which interact with EF
    ///  should extend this class and customise the already provided functionality, e.g. they should override all virtual methods to suite their needs.
    /// The <see cref="FindAllEntitiesByCriteria"/> method must be overriden in the extending repository class because it currently returns an empty collection.
    /// </summary>
    /// <typeparam name="T">The actual entity type to save into the repository</typeparam>
    /// <typeparam name="TContext">A class that extends Entity Framework DbContext class.</typeparam>
    public abstract class EfDataRepositoryBase<T, TContext> : IDataRepository<T>
        where T : BaseObjectWithState, IObjectWithState, new()
        where TContext : DbContext, new()
    {
        public short QueriesMaxTimeoutInSeconds { get; set; }


        public OperationResult Persist(T entity)
        {
            return ExecuteExceptionHandledOperation(() =>
           {
               var result = new OperationResult();
               using (var entityContext = new TContext())
               {
                   entity.DateModified = DateTime.Now;

                   AttachEntity(entityContext, entity);
                   entityContext.ApplyStateChanges();
                   entityContext.SaveChanges();

                   entity.ObjectState = EfExtensions.ConvertState(entityContext.Entry(entity).State);

                   result.MessagesDictionary.Add("PersistedEntity", entity);

                   return result;
               }
           });
        }

        public T FindById(int id)
        {
            using (var entityContext = new TContext())
            {
                return FindEntityById(entityContext, id);
            }
        }

        public virtual T FindBy(Expression<Func<T, bool>> predicate)
        {
            using (var entityContext = new TContext())
            {
                return entityContext.Set<T>().SingleOrDefault(predicate);
            }
        }

        public virtual IEnumerable<T> FindAllBy(Expression<Func<T, bool>> predicate)
        {
            using (var entityContext = new TContext())
            {
                return entityContext.Set<T>().Where(predicate).ToList();
            }
        }

        public bool Exists(T entity)
        {
            using (var entityContext = new TContext())
            {
                return EntityExists(entityContext, entity);
            }
        }

        public bool Exists(int entityId)
        {
            using (var entityContext = new TContext())
            {
                return EntityExists(entityContext, entityId);
            }
        }

        public IEnumerable<T> FindAll()
        {
            using (var entityContext = new TContext())
            {
                return FindAllEntities(entityContext).ToList();
            }
        }

        public IEnumerable<T> FindAllByCriteria(int? pageNumber, int? pageSize, out int totalRecords, string sortColumn,
            string sortDirection, params string[] keywords)
        {
            return FindAllEntitiesByCriteria(pageNumber, pageSize, out totalRecords, sortColumn, sortDirection, keywords);
        }

        /// <summary>
        ///  Executes a piece of code and returns a result. Exceptions are also handled here. 
        ///  Useful for handling many common exceptions in one place.
        /// </summary>
        /// <typeparam name="TE">The type to return from the method, in this case we are returning an OperationResult object</typeparam>
        /// <param name="codeToExecute">the code to execute as a delagate.</param>
        /// <returns></returns>
        protected TE ExecuteExceptionHandledOperation<TE>(Func<TE> codeToExecute) where TE : OperationResult, new()
        {
            var result = new TE();
            try
            {
                return codeToExecute.Invoke();
            }
            catch (IOException ioe)
            {
                string error = Error.BuildExceptionDetail(ioe, new StringBuilder()).ToString();
                result.Success = false;
                //Log it
            }
            catch (DbUpdateException e)
            {
                result.Success = false;
                result.AddMessage(e.Message);
                var s = e.InnerException.InnerException as SqlException;

                if (s != null)
                {
                    //   var msg = string.Format("Source: {0} -> Error number: {1} -> Message: {2}",       ErrorsUtils.ErrorOrigin.Database, s.Number, s.Message);
                    result.Success = false;
                    // result.AddMessage(msg);
                    //  Logger.Log(new LogEntry(LoggingEventType.Error, ErrorsUtils.BuildExceptionDetail(e, new StringBuilder()).ToString(), e.Source, e));
                    result.Messages = SanitiseClientBoundErrorMessages(result.Messages);
                    return result;
                }
                result.Messages = SanitiseClientBoundErrorMessages(result.Messages);
                // Logger.Log(new LogEntry(LoggingEventType.Error, ErrorsUtils.BuildExceptionDetail(e, new StringBuilder()).ToString(), e.Source, e));
            }
            catch (Exception e)
            {
                result.Success = false;
                string error = Error.BuildExceptionDetail(e, new StringBuilder()).ToString();
                //Log it
            }
            result.Messages = SanitiseClientBoundErrorMessages(result.Messages);
            return result;
        }

        /// <summary>
        /// This methods takes the errors which were generated by the system and convert them into plain English so that the user of the application can know what's gone wrong.
        /// This also helps to hide the technology we are using to the client, for example, if we translate an Entity Framework error message into plain English, the client wouldn't know that the error was generated by EF.
        /// </summary>
        /// <param name="rawMessages">The list of error messgaes.</param>
        /// <returns>The list of messages with the messages translated into plain English.</returns>
        public virtual IList<string> SanitiseClientBoundErrorMessages(ICollection<string> rawMessages)
        {
            if (!rawMessages.Any()) return new List<string>();
            var sanitisedList = new List<string>();

            foreach (var message in rawMessages)
            {
                if (message == null) continue;

                string tmp = message;


                if (tmp.Contains("Entities may have been modified or deleted since entities were loaded"))
                {
                    tmp = "Sorry, someone else has updated this record while you were editing it. Your changes have been discarded and what you are seeing now is the latest record from the database.";
                }

                else if (tmp.Contains("Cannot insert duplicate key row in object"))
                {
                    tmp = "Duplicate record insertion detected";
                }

                sanitisedList.Add(tmp);
            }
            return sanitisedList;
        }

        protected virtual EntityEntry AttachEntity(TContext entityContext, T entity)
        {
            EntityEntry entityEntry = null;
            if (entity.Id < 1 && entity.ObjectState == ObjectState.Added)
            {
                entityEntry = entityContext.Set<T>().Add(entity);
            }
            entityEntry = entityContext.Set<T>().Attach(entity);
            return entityEntry;
        }
        protected virtual T FindEntityById(TContext entityContext, int id)
        {
            return entityContext.Set<T>().SingleOrDefault(x => x.Id == id);
        }

        protected virtual bool EntityExists(TContext entityContext, T entity)
        {
            return entityContext.Set<T>().Any(x => x.Id == entity.Id);
        }

        protected virtual bool EntityExists(TContext entityContext, int entityId)
        {
            return entityContext.Set<T>().Any(x => x.Id == entityId);
        }

        protected virtual IEnumerable<T> FindAllEntities(TContext entityContext)
        {
            return entityContext.Set<T>().ToList();
        }

        protected virtual IEnumerable<T> FindAllEntitiesByCriteria(
            int? pageNumber,
            int? pageSize,
            out int totalRecords,
            string sortColumn,
            string sortDirection,
            params string[] keywords)
        {
            totalRecords = 0;
            return new List<T>();
        }

    }
}