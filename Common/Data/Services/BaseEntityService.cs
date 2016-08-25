using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.Extensions;
using Core.Common.Utilities;

namespace Core.Common.Data.Services
{
    public abstract partial class BaseEntityService<TEntity> : IEntityService<TEntity>
     where TEntity : BaseObjectWithState, IObjectWithState, new()
    {
        protected IDataRepository<TEntity> _repository;
        public virtual IEnumerable<TEntity> FindAllEntitiesByCriteria(                    
                    int? pageNumber,
                    int? pageSize,
                    out int totalRecords,
                    string sortColumn,
                    string sortDirection,
                     out int offset,
                    out int offsetUpperBound,
                    out int totalNumberOfPages,
                    params string[] keywords)
        {
            if (_repository == null) throw new Exception(nameof(_repository));
            if (sortColumn.IsNullOrWhiteSpace()) Error.ArgumentNull(nameof(sortColumn));
            if (sortDirection.IsNullOrWhiteSpace()) Error.ArgumentNull(nameof(sortDirection));

            int pageIndex = pageNumber ?? 1;
            int sizeOfPage = pageSize ?? 10;

            var items = _repository.FindAllEntitiesByCriteria(
                 pageIndex, sizeOfPage, out totalRecords, sortColumn, sortDirection, keywords);
            totalNumberOfPages = (int)Math.Ceiling((double)totalRecords / sizeOfPage);

            offset = (int)((pageIndex - 1) * sizeOfPage + 1);
            offsetUpperBound = offset + (sizeOfPage - 1);
            if (offsetUpperBound > totalRecords) offsetUpperBound = totalRecords;

            return items;
        }

        public async Task<bool> PersistEntity(TEntity entity)
        {
            return await _repository.PersistEntity(entity);
        }
    }
}