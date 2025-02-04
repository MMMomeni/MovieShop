﻿using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Core.Contracts.Service;
using MovieShopMVC.Core.Models;

namespace MovieShopMVC.Controllers
{
    public class CastController : Controller
    {
        private readonly ICastServiceAsync castServ;
        private readonly IMovieCastServiceAsync movieCastServ;

        public CastController (ICastServiceAsync castServ, IMovieCastServiceAsync movieCastServ)
        {
            this.castServ = castServ;
            this.movieCastServ = movieCastServ;
        }
        [HttpGet]
        public async Task<IActionResult> ShowAllMoviesByCast(int castId)
        {
            IEnumerable<MoviesByCastModel> moviesByCast = await movieCastServ.GetAllMoviesByCastId(castId);
            return View(moviesByCast);
        }

    }
}
