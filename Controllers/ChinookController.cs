using Microsoft.AspNetCore.Mvc;
using TestProject.Models;
using System.Linq;
using System;

namespace WebApplication.Controllers
{

    public class ChinookController : Controller
    {
        //private ChinookDbContext _chinookContext;
        private ChinookSqlServerDbContext _chinookContext;

        public ChinookController(ChinookSqlServerDbContext chinookContext)
        {
            _chinookContext = chinookContext;
        }

        public IActionResult Artists(int? pageNumber, int? pageSize)
        {
            ViewData["Message"] = "Here are some cool artists from Chinook.";

            int pageIndex = pageNumber ?? 1;
            int sizeOfPage = pageSize ?? 10;
            if (pageIndex < 1) pageIndex = 1;
            if (sizeOfPage < 1) sizeOfPage = 5;
            int skipValue = (sizeOfPage * (pageIndex - 1));
            int totalRecords = _chinookContext.Artist.Count();
            int totalNumberOfPages = (int)Math.Ceiling((double)totalRecords / sizeOfPage);

            int offset = (int)((pageNumber - 1) * pageSize + 1);
            int offsetUpperBound = offset + (pageSize.Value - 1);
            if (offsetUpperBound > totalRecords) offsetUpperBound = totalRecords;

            ViewBag.totalRecords = totalRecords;
            ViewBag.totalNumberOfPages = totalNumberOfPages;
            ViewBag.offset = offset;
            ViewBag.offsetUpperBound = offsetUpperBound;
            ViewBag.pageIndex = pageIndex;
            ViewBag.sizeOfPage = sizeOfPage;

            var artists = _chinookContext.Artist.OrderBy(a => a.Name).Skip(skipValue).Take(sizeOfPage).ToList();
            return View(artists);

        }

    }
}