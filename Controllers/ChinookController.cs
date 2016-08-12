using Microsoft.AspNetCore.Mvc;
using WebApplication.Data.Services;
using WebApplication.Data.Repositories;
using System.Collections.Generic;
using TestProject.Models;
using WebApplication.ViewModels;
using System.Threading.Tasks;
using Core.Common.Data;

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
            string sortDir, string searchTerms)
        {

            return ExecuteExceptionsHandledActionResult(() =>
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

                var model = new ArtistViewModel();
                model.ArtistsList = artists;

                return View(model);
            });
        }


        public IActionResult AddArtist()
        {
            return  ExecuteExceptionsHandledActionResult( () =>
            {
                return View();
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddArtist(ArtistEditModel model)
        {
            if (model == null) return View();

            return await ExecuteExceptionsHandledAsyncActionResult(async () =>
            {
                var artist = new Artist { Name = model.Name , ObjectState = ObjectState.Added };
                await _artistService.Persist(artist);
                return View(model);
            });
        }
    }
}