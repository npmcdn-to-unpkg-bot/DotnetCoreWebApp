using Microsoft.AspNetCore.Mvc;
using TestProject.Models;
using System.Linq;

namespace WebApplication.Controllers
{

    public class ChinookController : Controller
    {
        public IActionResult Artists()
        {
            ViewData["Message"] = "Here are some cool artists from Chinook.";
            using (var ctx = new ChinookDbContext())
            {
                var artists = ctx.Artist.Take(10).ToList();
                return View(artists);
            }
        }

    }
}