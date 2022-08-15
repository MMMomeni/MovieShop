using MovieShopMVC.Core.Contracts.Repository;
using MovieShopMVC.Core.Contracts.Service;
using MovieShopMVC.Core.Entities;
using MovieShopMVC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopMVC.Infrastructure.Service
{
    public class MovieCastServiceAsync : IMovieCastServiceAsync
    {
        private readonly IMovieCastRepositoryAsync movieCastRep;

        public MovieCastServiceAsync (IMovieCastRepositoryAsync movieCastRep)
        {
            this.movieCastRep = movieCastRep;
        }

        public Task<int> DeleteMovieCastAsync(int Id)
        {
            return movieCastRep.DeleteAsync(Id);
        }

        public async Task<IEnumerable<MovieCastModel>> GetAllMovieCastByMovieId(int MovieId)
        {
            var allMovieCasts = await movieCastRep.GetAllAsync();
            List<MovieCastModel> result = new List<MovieCastModel>();
            

            foreach(var movieCast in allMovieCasts)
            {
                if (movieCast.MovieId == MovieId)
                {
                    MovieCastModel model = new MovieCastModel();
                    model.Id = movieCast.Id;
                    model.CastId = movieCast.CastId;
                    model.MovieId = movieCast.Id;
                    model.Character = movieCast.Character;
                    result.Add(model);
                }
            }
            return result;
        }

        public async Task<MovieCastModel> GetMovieCastByIdAsync(int Id)
        {
            var movie = await movieCastRep.GetByIdAsync(Id);
            MovieCastModel model = new MovieCastModel();
            model.Id = movie.Id;
            model.CastId = movie.CastId;
            model.MovieId = movie.Id;
            model.Character = movie.Character;
            return model;
        }

        public Task<int> InsertMovieCastAsync(int movieId, int castId, string character)
        {
            MovieCast movieCast = new MovieCast()
            {
                CastId = castId,
                MovieId = movieId,
                Character = character
            };
            
            return movieCastRep.InsertAsync(movieCast);
        }

        public Task<int> UpdateMovieCastAsync(MovieCastModel model)
        {
            MovieCast movieCast = new MovieCast()
            {
                CastId = model.CastId,
                MovieId = model.Id,
                Character = model.Character,
            };

            return movieCastRep.UpdateAsync(movieCast);
        }
    }
}
