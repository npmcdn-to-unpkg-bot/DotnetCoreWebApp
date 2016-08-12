using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.ViewComponents
{
    public class ListPagerViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(
            string url,            
            int totalNumberOfItems, 
            int pageNumber, 
            int pageSize,
            int totalNumberOfPages,
            int offset, 
            int offsetUpperBound,
            string sortColumn,
            string sortDirection,
            string searchTerms)
        {
            ViewBag.offset = offset;
            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.offsetUpperBound = offsetUpperBound;
            ViewBag.totalRecords = totalNumberOfItems;
            ViewBag.sortColumn = sortColumn;
            ViewBag.sorDirection = sortDirection;
            ViewBag.searchTerms = searchTerms;
            
            return await Task.FromResult(View());
        }
    }
}