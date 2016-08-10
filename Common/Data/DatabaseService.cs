using System;
using System.Collections.Generic;
using Core.Common.Extensions;
using Core.Common.Utilities;

namespace Core.Common.Data
{
    public sealed partial class DatabaseService<T> : IDatabaseService<T>
     where T : BaseObjectWithState, IObjectWithState, new()
    {



        public IEnumerable<T> FindAllByCriteria(
                    IDataRepository<T> repository,
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
            if (repository == null) throw new Exception(nameof(repository));
            if (sortColumn.IsNullOrWhiteSpace()) Error.ArgumentNull(nameof(sortColumn));
            if (sortDirection.IsNullOrWhiteSpace()) Error.ArgumentNull(nameof(sortDirection));

            int pageIndex = pageNumber ?? 1;
            int sizeOfPage = pageSize ?? 10;

            var items = repository.FindAllByCriteria(
                 pageIndex, sizeOfPage, out totalRecords, sortColumn, sortDirection, keywords);
            totalNumberOfPages = (int)Math.Ceiling((double)totalRecords / sizeOfPage);

            offset = (int)((pageIndex - 1) * sizeOfPage + 1);
            offsetUpperBound = offset + (sizeOfPage - 1);
            if (offsetUpperBound > totalRecords) offsetUpperBound = totalRecords;

            return items;
        }
    }
}