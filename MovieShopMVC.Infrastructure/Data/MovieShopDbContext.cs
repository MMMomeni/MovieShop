using Microsoft.EntityFrameworkCore;
using MovieShopMVC.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopMVC.Infrastructure.Data
{
    public class MovieShopDbContext : DbContext
    {
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movie { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<MovieGenre> MovieGenre { get; set; }
        public DbSet<MovieCrew> MovieCrew { get; set; }
        public DbSet<Crew> Crew { get; set; }
        public DbSet<MovieCast> MovieCast { get; set; }
        public DbSet<Cast> Cast { get; set; }
        public DbSet<Favorite> Favorite { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<Trailer> Trailer { get; set; }

        /*
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<MovieCast>()
                .HasOne(c => c.Cast)
                .WithOne(mc => mc.MovieCast)
                .HasForeignKey<MovieCast>(c => c.CastId);

            // each movie can have many movie casts
            builder.Entity<Movie>()
                .HasMany(m => m.MovieCasts)
                .WithOne(mc => mc.Movie)
                .HasForeignKey(mc => mc.MovieId)
                .OnDelete(DeleteBehavior.Cascade);
        }
        */



    }
}
