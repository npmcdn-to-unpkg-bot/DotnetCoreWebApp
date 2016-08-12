using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.Utilities;

namespace Core.Common.Data.Services
{
    public interface IEntityService<TEntity>
        where TEntity : BaseObjectWithState, IObjectWithState, new()
    {

        Task<OperationResult> Persist(TEntity entity);

        IEnumerable<TEntity> FindAllByCriteria(                   
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