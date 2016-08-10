using System.Collections.Generic;

namespace Core.Common.Data
{
    public interface IDatabaseService<T>
        where T : BaseObjectWithState, IObjectWithState, new()
    {

        IEnumerable<T> FindAllByCriteria(
                    IDataRepository<T> repository,
                    int? pageNumber,
                    int? pageSize,
                    out int totalRecords,
                    string sortColumn,
                    string sortDirection,
                    out int offset,
                    out int offsetUpperBound,
                    out int totalNumberOfPages,
                    params string[] keywords);
    }
}