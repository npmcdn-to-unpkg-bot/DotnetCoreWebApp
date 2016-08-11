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
            int offsetUpperBound)
        {
            ViewBag.offset = offset;
            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.offsetUpperBound = offsetUpperBound;
            ViewBag.totalRecords = totalNumberOfItems;
            
            return await Task.FromResult(View());
        }
    }
}