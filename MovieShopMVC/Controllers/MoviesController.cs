using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Core.Contracts.Service;
using MovieShopMVC.Core.Models;
using MovieShopMVC.Models;
using System.Diagnostics;

namespace MovieShopMVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly IMovieServiceAsync movieServ;

        public MoviesController(ILogger<MoviesController> logger, IMovieServiceAsync movieServ)
        {
            _logger = logger;
            this.movieServ = movieServ;
        }

        public async Task<IActionResult> Index()
        {
            var allMovies = await movieServ.GetAllMoviesAsync();
            return View(allMovies);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateMovie()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateMovie(MovieModel model)
        {
            if (ModelState.IsValid)
            {
                await movieServ.InsertMovieAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}