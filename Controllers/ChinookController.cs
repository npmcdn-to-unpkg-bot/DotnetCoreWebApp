using Microsoft.AspNetCore.Mvc;
using TestProject.Models;
using System;
using WebApplication.Data;
using  Core.Common.Data;

namespace WebApplication.Controllers
{

    public class ChinookController : Controller
    {
        private ChinookSqlServer2008DbContext _chinookContext;
        private readonly IArtistsRepository _artistsRepository;
        private readonly IDatabaseService<Artist> _artistsDbService;

        public ChinookController(ChinookSqlServer2008DbContext chinookContext,
        IArtistsRepository artistsRepository,IDatabaseService<Artist> artistsDbService)
        {
            _chinookContext = chinookContext;
            _artistsRepository = artistsRepository;
            _artistsDbService = artistsDbService;
        }

        public IActionResult Performers(
            int? pageNumber, int? pageSize, string sortColumn, 
            string sortDirection, params string[] keywords)
        {
            int pageIndex =  pageNumber ?? 1;
            int sizeOfPage = pageSize ?? 10;
            string sortCol = sortColumn ?? "Name";
            string sortDir = sortDirection ?? "ASC";

            int totalNumberOfRecords = 0;
            int totalNumberOfPages = 0;
            int offset = 0;
            int offsetUpperBound = 0;
            var artists = _artistsDbService.FindAllByCriteria(_artistsRepository,
                 pageIndex, sizeOfPage, out totalNumberOfRecords, sortCol, sortDir, out offset, 
                 out offsetUpperBound, out totalNumberOfPages, keywords);

            ViewBag.offset = offset;
            ViewBag.pageIndex = pageIndex;
            ViewBag.sizeOfPage = sizeOfPage;
            ViewBag.offsetUpperBound = offsetUpperBound;
            ViewBag.totalRecords = totalNumberOfRecords;
            ViewBag.totalNumberOfPages = totalNumberOfPages;

            return View(artists);
        }
        
    }
}