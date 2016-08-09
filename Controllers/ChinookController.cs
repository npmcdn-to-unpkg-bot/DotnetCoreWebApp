using Microsoft.AspNetCore.Mvc;
using TestProject.Models;
using System.Linq;
using System;
using LinqKit;
using WebApplication.Data;
using System.Collections.Generic;

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

        public IActionResult Performers(int? pageNumber, int? pageSize, string keywords)
        {
            if (!pageNumber.HasValue) pageNumber = 1;
            if (!pageSize.HasValue) pageSize = 10;

            int totalNumberOfRecords;
            int totalNumberOfPages;
            int offset;
            int offsetUpperBound;
            var artists = _artistsRepository.FindAllByCriteria(
                 pageNumber, pageSize, out totalNumberOfRecords, "Code", "ASC", keywords);

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


        public IActionResult Artists(int? pageNumber, int? pageSize, string keywords)
        {
            ViewData["Message"] = "Here are some cool artists from Chinook.";

            int pageIndex = pageNumber ?? 1;
            int sizeOfPage = pageSize ?? 10;
            if (pageIndex < 1) pageIndex = 1;
            if (sizeOfPage < 1) sizeOfPage = 5;
            int skipValue = (sizeOfPage * (pageIndex - 1));
            int totalRecords = _chinookContext.Artist.Count();

            int offset = (int)((pageIndex - 1) * sizeOfPage + 1);
            int offsetUpperBound = offset + (sizeOfPage - 1);
            if (offsetUpperBound > totalRecords) offsetUpperBound = totalRecords;

            ViewBag.offset = offset;

            ViewBag.pageIndex = pageIndex;
            ViewBag.sizeOfPage = sizeOfPage;

            string[] keywordsList = !string.IsNullOrWhiteSpace(keywords) ? keywords.Split(',') : new string[] { };
            var predicate = PredicateBuilder.True<Artist>();
            bool isFilteredQuery = keywordsList.Any();

            if (isFilteredQuery)
            {
                predicate = PredicateBuilder.False<Artist>();
                foreach (var keyword in keywordsList)
                {
                    var temp = keyword;
                    if (temp == null) continue;
                    predicate = predicate.Or(p => p.Name.ToLower().Contains(temp.ToLower()));
                }
            }

            totalRecords =
               _chinookContext.Artist.AsExpandable().Where(predicate).OrderBy(am => am.Name).Count();
            offsetUpperBound = (totalRecords > offsetUpperBound ? offsetUpperBound : totalRecords);
            ViewBag.offsetUpperBound = offsetUpperBound;
            ViewBag.totalRecords = totalRecords;
            int totalNumberOfPages = (int)Math.Ceiling((double)totalRecords / sizeOfPage);
            ViewBag.totalNumberOfPages = totalNumberOfPages;
            var artists =
                _chinookContext.Artist.AsExpandable()
                    .Where(predicate)
                    .OrderBy(am => am.Name)
                    .Skip(skipValue)
                    .Take(sizeOfPage)
                    .ToList();
            return View(artists);
        }
    }
}