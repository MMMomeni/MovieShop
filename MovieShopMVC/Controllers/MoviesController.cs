using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Core.Contracts.Service;
using MovieShopMVC.Core.Models;
using MovieShopMVC.Models;
using System.Diagnostics;

namespace MovieShopMVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieServiceAsync movieServ;
        private readonly IMovieCastServiceAsync movieCastServ;
        private readonly ICastServiceAsync castServ;
        private int movieId;
        private int castId;
        private string character;
        

        public MoviesController(IMovieServiceAsync movieServ, IMovieCastServiceAsync movieCastServ, ICastServiceAsync castServ)
        {
            this.movieServ = movieServ;
            this.movieCastServ = movieCastServ;
            this.castServ = castServ;
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

        [HttpGet]
        public async Task<IActionResult> Detail(int movieId)
        {
            MovieModel movieModel = await movieServ.GetMovieByIdAsync(movieId);
            movieModel.MovieCasts = await movieCastServ.GetAllMovieCastByMovieId(movieId);

            return View(movieModel);
        }


        [HttpGet]
        public IActionResult CreateCast(int movieId)
        {
            return View(movieId);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCast(CastModel model, int movieId, string character)
        {
            if (ModelState.IsValid)
            {
                var t1 = castServ.InsertCastAsync(model);
                //await Task.Delay(1000);
  
                Task.WaitAll(t1);
                this.movieId = movieId;
                this.character = character;
                castId = model.Id;
                await CreateMovieCastAsync();
                
            }
            return View();
        }
        public async Task CreateMovieCastAsync()
        {
            await movieCastServ.InsertMovieCastAsync(movieId, castId, character);
            RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}