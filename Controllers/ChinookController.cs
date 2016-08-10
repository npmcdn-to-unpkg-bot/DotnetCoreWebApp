using Microsoft.AspNetCore.Mvc;
using TestProject.Models;
using System;
using WebApplication.Data;

namespace WebApplication.Controllers
{

    public class ChinookController : Controller
    {
        private ChinookSqlServer2008DbContext _chinookContext;
        private readonly IArtistsRepository _artistsRepository;

        public ChinookController(ChinookSqlServer2008DbContext chinookContext,
        IArtistsRepository artistsRepository)
        {
            _chinookContext = chinookContext;
            _artistsRepository = artistsRepository;
        }

        public IActionResult Performers(
            int? pageNumber, int? pageSize, string sortColumn, 
            string sortDirection, params string[] keywords)
        {
            int pageIndex =  pageNumber ?? 1;
            int sizeOfPage = pageSize ?? 10;

            string sortCol = sortColumn ?? "Name";
            string sortDir = sortDirection ?? "ASC";

            int totalNumberOfRecords;
            int totalNumberOfPages;
            int offset;
            int offsetUpperBound;
            var artists = _artistsRepository.FindAllByCriteria(
                 pageIndex, sizeOfPage, out totalNumberOfRecords, sortCol, sortDir, keywords);

            totalNumberOfPages = (int)Math.Ceiling((double)totalNumberOfRecords /sizeOfPage);

            offset = (int)((pageIndex - 1) * sizeOfPage + 1);
            offsetUpperBound = offset + (sizeOfPage - 1);
            if (offsetUpperBound > totalNumberOfRecords) offsetUpperBound = totalNumberOfRecords;

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