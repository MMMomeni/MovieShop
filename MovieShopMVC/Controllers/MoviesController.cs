﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Core.Contracts.Service;
using MovieShopMVC.Core.Entities;
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
        private int savedMovieId;
        //private int castId;
        //private string character;
        private readonly SignInManager<User> signInManager;


        public MoviesController(IMovieServiceAsync movieServ, IMovieCastServiceAsync movieCastServ, ICastServiceAsync castServ, SignInManager<User> signInManager)
        {
            this.movieServ = movieServ;
            this.movieCastServ = movieCastServ;
            this.castServ = castServ;
            this.signInManager = signInManager;
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
        ///[Authorize]
        public IActionResult CreateMovie()
        {
            return View();
        }
        [HttpPost]
        //[Authorize]
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
        //[Authorize]
        public IActionResult CreateCast(int movieId)
        {
            return View(movieId);
        }
        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> CreateCast(CastModel model)
        {
            if (ModelState.IsValid)
            {
                await castServ.InsertCastAsync(model);
                //await Task.Delay(1000);
  
                //Task.WaitAll(t1);
                //this.movieId = movieId;
                //this.character = character;
                //castId = model.Id;
               // await CreateMovieCastAsync();
               return RedirectToAction("Index");
                
            }
            return View(model);
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> ChooseCast(int movieId)
        {
            this.savedMovieId = movieId;
            var allCast = await castServ.GetAllCastsAsync();
            ViewBag.MovieId = movieId;
            return View(allCast);
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> CreateMovieCast(int castId, int movieId)
        {
            var model = await castServ.GetCastByIdAsync(castId);
            ViewBag.MovieId = movieId;
            return View(model);
        }
        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> CreateMovieCast(MovieCastModel model)
        {
            if (ModelState.IsValid)
            {
                await movieCastServ.InsertMovieCastAsync(model);
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