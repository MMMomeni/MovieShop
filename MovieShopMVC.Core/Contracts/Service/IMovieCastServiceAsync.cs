using MovieShopMVC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopMVC.Core.Contracts.Service
{
    public interface IMovieCastServiceAsync
    {
        Task<int> InsertMovieCastAsync(int movieId, int castId, string character);
        Task<int> UpdateMovieCastAsync(MovieCastModel model);
        Task<int> DeleteMovieCastAsync(int Id);
        Task<MovieCastModel> GetMovieCastByIdAsync(int Id);

        Task<IEnumerable<MovieCastModel>> GetAllMovieCastByMovieId(int MovieId);
    }
}
