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

        public IActionResult Performers(int? pageNumber, int? pageSize, params string[] keywords)
        {
            if (!pageNumber.HasValue) pageNumber = 1;
            if (!pageSize.HasValue) pageSize = 10;

            int totalNumberOfRecords;
            int totalNumberOfPages;
            int offset;
            int offsetUpperBound;
            var artists = _artistsRepository.FindAllByCriteria(
                 pageNumber, pageSize, out totalNumberOfRecords, "Name", "DESC", keywords);

            totalNumberOfPages = (int)Math.Ceiling((double)totalNumberOfRecords / pageSize.Value);

            offset = (int)((pageNumber - 1) * pageSize + 1);
            offsetUpperBound = offset + (pageSize.Value - 1);
            if (offsetUpperBound > totalNumberOfRecords) offsetUpperBound = totalNumberOfRecords;

            ViewBag.offset = offset;
            ViewBag.pageIndex = pageNumber ?? 1;
            ViewBag.sizeOfPage = pageSize ?? 10;
            ViewBag.offsetUpperBound = offsetUpperBound;
            ViewBag.totalRecords = totalNumberOfRecords;
            ViewBag.totalNumberOfPages = totalNumberOfPages;

            return View(artists);
        }
        
    }
}