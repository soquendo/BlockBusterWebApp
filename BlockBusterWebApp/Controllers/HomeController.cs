using BlockBusterWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BlockBuster;

namespace BlockBusterWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Colors()
        {
            string[] colors = { "red", "blue", "yellow" };
            ViewBag.Colors = colors;
            return View();
        }

        public IActionResult Cities()
        {
            string[] cities = { "Berlin", "Palermo", "Nairobi", "Helsinki", "Bogota" };
            ViewBag.Cities = cities;
            return View();
        }

        public IActionResult Hobbies()
        {
            string[] hobbies = { "Photography", "Graphic Design", "Cooking", "Video Games", "Sports" };
            ViewBag.Hobbies = hobbies;
            return View();
        }

        public IActionResult Movies() 
        {
            var movieList = BlockBusterBasicFunctions.GetAllMoviesFull();
            return View(movieList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
