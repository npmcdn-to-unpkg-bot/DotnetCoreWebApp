using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Common.Utilities;

namespace Core.Common.Data
{
    public interface IDataRepository
    {
    }

    public interface IDataRepository<TEntity> : IDataRepository
        where TEntity : BaseObjectWithState, IObjectWithState, new()
    {
        /// <summary>
        /// Attmpts to save an entity into the database and returns an OperationResult indicating success or failure.
        /// </summary>
        /// <param name="entity">The entity to save into the database.</param>
        /// <returns>OperationResult object indicating the outcome of the operation. Note, if you want to return the object which 
        /// was saved you can add it to the MessagesDictionary property of the OperationResult object.
        /// </returns>
        Task<OperationResult> Persist(TEntity entity);

        /// <summary>
        /// Finds an entity by its id.
        /// </summary>
        /// <param name="id">The ID of the entity to search for.</param>
        /// <returns>The entity if found, it's up to the implementer what to return if the entity was not found. They can throw a NotFoundException if needed.</returns>
        TEntity FindById(int id);

        /// <summary>
        ///  Checks if an entity exists in the repository.
        /// </summary>
        /// <param name="entity">The entity to search for. </param>
        /// <returns>True if entity exists, false otherwise.</returns>
        bool Exists(TEntity entity);

        /// <summary>
        /// Checks if an entity exists in the repository by its ID.
        /// </summary>
        /// <param name="entityId">The ID of the entity to search for.</param>
        /// <returns>True if the entity was found, false otherwise.</returns>
        bool Exists(int entityId);

        /// <summary>
        /// Returns all entities of type TEntity from the repository. 
        /// </summary>
        /// <returns>A collection of T entities.</returns>
        IEnumerable<TEntity> FindAll();


        /// <summary>
        /// Returns entity of type TEntity from the repository based on predicate. 
        /// </summary>
        /// <returns>The entity if found.</returns>
        TEntity FindBy(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Returns all entities of type TEntity from the repository based on predicate. 
        /// </summary>
        /// <returns>A collection of TEntity entities if found.</returns>
        IEnumerable<TEntity> FindAllBy(Expression<Func<TEntity, bool>> predicate);
  
        /// <summary>
        ///  Returns a collection of TEntity entity in chunks. The client can also specify search and paging requirements criteria.
        /// </summary>
        /// <param name="pageNumber">The page number to return  when paging.</param>
        /// <param name="pageSize">The page size when paging.</param>
        /// <param name="totalRecords">The total number of records which were returned by the query criteria. Needed for displaying paging navigation links.</param>
        /// <param name="keywords">An array of keywords for searching. Implementers can decide which columns in the underlying data store the search is perfromed against, but make sure that the searched data is indexed in order to speed up performance.</param>
        /// <param name="sortColumn">The sort column in the underlying data store. Should be indexed or performance could be severly reduced.</param>
        /// <param name="sortDirection">Either ASC or DESC.</param>
        /// <returns>A collection of TEntity entities.</returns>
        IEnumerable<TEntity> FindAllByCriteria(
            int? pageNumber,
            int? pageSize,
            out int totalRecords,
            string sortColumn,
            string sortDirection,
            params string[] keywords);
    }
}