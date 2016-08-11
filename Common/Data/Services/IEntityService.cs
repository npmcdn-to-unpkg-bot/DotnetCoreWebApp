using System.Collections.Generic;

namespace Core.Common.Data.Services
{
    public interface IEntityService<TEntity>
        where TEntity : BaseObjectWithState, IObjectWithState, new()
    {

        IEnumerable<TEntity> FindAllByCriteria(
                    IDataRepository<TEntity> repository,
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