using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Common.Data.Services
{
    public interface IEntityService<TEntity>
        where TEntity : BaseObjectWithState, IObjectWithState, new()
    {

        Task<bool> PersistEntity(TEntity entity);

        Task<TEntity> FindEntityById(int id);

        IEnumerable<TEntity> FindAllEntitiesByCriteria(                   
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