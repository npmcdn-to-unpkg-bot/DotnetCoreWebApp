using Microsoft.AspNetCore.Mvc;
using WebApplication.Data.Services;
using WebApplication.Data.Repositories;

namespace WebApplication.Controllers
{

    public class ChinookController : BaseController
    {
        private readonly IArtistsRepository _artistsRepository;
        private readonly IArtistEntityService _artistService;

        public ChinookController(            
            IArtistsRepository artistsRepository,
            IArtistEntityService artistService) 
        {
            _artistsRepository = artistsRepository;
            _artistService = artistService;

        }

        public IActionResult Performers(
            int? pageNumber, int? pageSize, string sortCol,
            string sortDir, params string[] keywords)
        {

            return ExecuteExceptionHandledActionResult(() =>
            {
                int pageIndex = pageNumber ?? 1;
                int sizeOfPage = pageSize ?? 10;
                sortCol = sortCol ?? "Name";
                sortDir = sortDir ?? "ASC";

                int totalNumberOfRecords = 0;
                int totalNumberOfPages = 0;
                int offset = 0;
                int offsetUpperBound = 0;
                var artists = _artistService.FindAllByCriteria(_artistsRepository,
                     pageIndex, sizeOfPage, out totalNumberOfRecords, sortCol, sortDir, out offset,
                     out offsetUpperBound, out totalNumberOfPages, keywords);

                ViewBag.offset = offset;
                ViewBag.pageIndex = pageIndex;
                ViewBag.sizeOfPage = sizeOfPage;
                ViewBag.offsetUpperBound = offsetUpperBound;
                ViewBag.totalRecords = totalNumberOfRecords;
                ViewBag.totalNumberOfPages = totalNumberOfPages;                

                return View(artists);
            });
        }

    }
}