using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.Data;
using DotNetCoreTestWebProject.Data.Services;
using DotNetCoreTestWebProject.Models;
using DotNetCoreTestWebProject.EditModels;
using DotNetCoreTestWebProject.ViewModels;

namespace DotNetCoreTestWebProject.Controllers
{

    public class ChinookController : BaseController
    {
        private readonly IArtistEntityService _artistService;

        public ChinookController(
            IArtistEntityService artistService)
        {
            _artistService = artistService;

        }

        public IActionResult Artists(
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
                IEnumerable<Artist> artists = _artistService.FindAllEntitiesByCriteria(
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

    public IActionResult EditArtist(int id)
        {
            return  ExecuteExceptionsHandledActionResult( () =>
            {
                return View();
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
                var artist = new DotNetCoreTestWebProject.Models.Artist { 
                    Name = model.Name , ObjectState = ObjectState.Added , Deleted = false };
                await _artistService.PersistEntity(artist);
                return View(model);
            });
        }

        public IActionResult ArtistsAngular()
        {
            return View();
        }
    }
}