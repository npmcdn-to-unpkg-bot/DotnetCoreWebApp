using System;
using System.Collections.Generic;
using Core.Common.Extensions;
using Core.Common.Utilities;

namespace Core.Common.Data
{
    public abstract class BaseDatabaseService<T> : IDatabaseService<T>
     where T : BaseObjectWithState, IObjectWithState, new()
    {
        private IDataRepository<T> _repository;

        public IEnumerable<T> FindAllByCriteria(
                    int? pageNumber,
                    int? pageSize,
                    out int totalRecords,
                    string sortColumn,
                    string sortDirection,
                    params string[] keywords)
        {
            if(_repository == null) throw new Exception(nameof(_repository));
            if (sortColumn.IsNullOrWhiteSpace()) Error.ArgumentNull(nameof(sortColumn));
            if (sortDirection.IsNullOrWhiteSpace()) Error.ArgumentNull(nameof(sortDirection));

            int pageIndex = pageNumber ?? 1;
            int sizeOfPage = pageSize ?? 10;
            int totalNumberOfPages;
            int offset;
            int offsetUpperBound;
            var items = _repository.FindAllByCriteria(
                 pageIndex, sizeOfPage, out totalRecords, sortColumn, sortDirection, keywords);
            totalNumberOfPages = (int)Math.Ceiling((double)totalRecords / sizeOfPage);

            offset = (int)((pageIndex - 1) * sizeOfPage + 1);
            offsetUpperBound = offset + (sizeOfPage - 1);
            if (offsetUpperBound > totalRecords) offsetUpperBound = totalRecords;

            return items;
        }
    }
}