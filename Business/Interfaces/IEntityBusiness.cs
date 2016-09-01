using Core.Common.Data;
using Core.Common.Utilities;

namespace DotNetCoreTestWebProject.Business.Interfaces
{
    public interface IEntityBusiness<TEntity>
        where TEntity : BaseObjectWithState, IObjectWithState, new()
    {

        OperationResult ListItems(
            int? pageNumber, int? pageSize, string sortCol,
            string sortDir, string searchTerms);
    }
}