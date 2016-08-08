using Microsoft.AspNetCore.Mvc;
using TestProject.Models;
using System.Linq;

namespace WebApplication.Controllers
{

    public class ChinookController : Controller
    {
        private ChinookDbContext _chinookContext;

        public ChinookController(ChinookDbContext chinookContext)
        {
            _chinookContext = chinookContext;
        }

        public IActionResult Artists()
        {
            ViewData["Message"] = "Here are some cool artists from Chinook.";

            var artists = _chinookContext.Artist.Take(10).ToList();
            return View(artists);

        }

    }
}