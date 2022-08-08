using MovieShopMVC.Core.Contracts.Repository;
using MovieShopMVC.Core.Entities;
using MovieShopMVC.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopMVC.Infrastructure.Repository
{
    public class MovieCastRepositoryAsync : BaseRepositoryAsync<MovieCast>, IMovieCastRepositoryAsync
    {
        public MovieCastRepositoryAsync(MovieShopDbContext DbContext) : base(DbContext)
        {
        }
    }
}
