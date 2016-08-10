using System.Collections.Generic;

namespace Core.Common.Data
{
    public interface IDatabaseService<T>
        where T : BaseObjectWithState, IObjectWithState, new()
    {

        IEnumerable<T> FindAllByCriteria(
                    int? pageNumber,
                    int? pageSize,
                    out int totalRecords,
                    string sortColumn,
                    string sortDirection,
                    params string[] keywords);
    }
}