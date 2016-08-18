using System.Collections.Generic;
using DotNetCoreTestWebProject.Data.Services;
using DotNetCoreTestWebProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTestWebProject.Controllers.Api
{
     [Route("api/[controller]")]
    public sealed class ArtistsController : BaseApiController
    {
        private readonly IArtistEntityService _artistService;

        public ArtistsController(
            IArtistEntityService artistService)
        {
            _artistService = artistService;
        }


        [HttpGet]
        public IEnumerable<Artist> GetAll(
            int? pageNumber, int? pageSize, string sortCol,
            string sortDir, string searchTerms)
        {
            int pageIndex = pageNumber ?? 1;
                int sizeOfPage = pageSize ?? 10;
                sortCol = sortCol ?? "Name";
                sortDir = sortDir ?? "ASC";

                int totalNumberOfRecords = 0;
                int totalNumberOfPages = 0;
                int offset = 0;
                int offsetUpperBound = 0;
                string[] keywordsList = !string.IsNullOrWhiteSpace(searchTerms) ? searchTerms.Split(',') : new string[] { };
                IEnumerable<Artist> artists = _artistService.FindAllByCriteria(
                     pageIndex, sizeOfPage, out totalNumberOfRecords, sortCol, sortDir, out offset,
                     out offsetUpperBound, out totalNumberOfPages, keywordsList);

                ViewBag.offset = offset;
                ViewBag.pageIndex = pageIndex;
                ViewBag.sizeOfPage = sizeOfPage;
                ViewBag.offsetUpperBound = offsetUpperBound;
                ViewBag.totalRecords = totalNumberOfRecords;
                ViewBag.totalNumberOfPages = totalNumberOfPages;
                ViewBag.searchTerms = searchTerms;
                ViewBag.sortCol = sortCol;
                ViewBag.sortDir = sortDir;
                return artists;
        }
    }
}