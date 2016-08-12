using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
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
    /// <typeparam name="TEntity">The actual entity type to save into the repository</typeparam>
    /// <typeparam name="TContext">A class that extends Entity Framework DbContext class.</typeparam>
    public abstract class EfDataRepositoryBase<TEntity, TContext> : IDataRepository<TEntity>
        where TEntity : BaseObjectWithState, IObjectWithState, new()
        where TContext : DbContext, new()
    {
        protected TContext _context;

        public short QueriesMaxTimeoutInSeconds { get; set; }


        public async Task<OperationResult> Persist(TEntity entity)
        {
            var result = new OperationResult();
            entity.DateModified = DateTime.Now;
            AttachEntity(entity);
            _context.ApplyStateChanges();
            await _context.SaveChangesAsync();
            entity.ObjectState = EfExtensions.ConvertState(_context.Entry(entity).State);
            result.MessagesDictionary.Add("PersistedEntity", entity);
            return result;
        }

        public TEntity FindById(int id)
        {
            return FindEntityById(id);
        }

        public virtual TEntity FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public virtual IEnumerable<TEntity> FindAllBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).ToList();
        }

        public bool Exists(TEntity entity)
        {
            return EntityExists(entity);
        }

        public bool Exists(int entityId)
        {
            return EntityExists(entityId);
        }

        public IEnumerable<TEntity> FindAll()
        {
            return FindAllEntities().ToList();
        }

        public IEnumerable<TEntity> FindAllByCriteria(int? pageNumber, int? pageSize, out int totalRecords, string sortColumn,
            string sortDirection, params string[] keywords)
        {
            return FindAllEntitiesByCriteria(pageNumber, pageSize, out totalRecords, sortColumn, sortDirection, keywords);
        }


        protected virtual EntityEntry AttachEntity(TEntity entity)
        {
            EntityEntry entityEntry = null;
            if (entity.Id < 1 && entity.ObjectState == ObjectState.Added)
            {
                entityEntry = _context.Set<TEntity>().Add(entity);
            }
            entityEntry = _context.Set<TEntity>().Attach(entity);
            return entityEntry;
        }
        protected virtual TEntity FindEntityById(int id)
        {
            return _context.Set<TEntity>().SingleOrDefault(x => x.Id == id);
        }

        protected virtual bool EntityExists(TEntity entity)
        {
            return _context.Set<TEntity>().Any(x => x.Id == entity.Id);
        }

        protected virtual bool EntityExists(int entityId)
        {
            return _context.Set<TEntity>().Any(x => x.Id == entityId);
        }

        protected virtual IEnumerable<TEntity> FindAllEntities()
        {
            return _context.Set<TEntity>().ToList();
        }

        protected virtual IEnumerable<TEntity> FindAllEntitiesByCriteria(
            int? pageNumber,
            int? pageSize,
            out int totalRecords,
            string sortColumn,
            string sortDirection,
            params string[] keywords)
        {
            totalRecords = 0;
            return new List<TEntity>();
        }

    }
}