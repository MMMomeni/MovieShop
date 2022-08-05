﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieShopMVC.Infrastructure.Data;

#nullable disable

namespace MovieShopMVC.Infrastructure.Migrations
{
    [DbContext(typeof(MovieShopDbContext))]
    partial class MovieShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MovieShopMVC.Core.Entities.Cast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Gender")
                        .HasColumnType("varchar(MAX)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProfilePath")
                        .HasColumnType("varchar(2048)");

                    b.Property<string>("TmdbUrl")
                        .HasColumnType("varchar(MAX)");

                    b.HasKey("Id");

                    b.ToTable("Cast");
                });

            modelBuilder.Entity("MovieShopMVC.Core.Entities.Crew", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Gender")
                        .HasColumnType("varchar(MAX)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProfilePath")
                        .HasColumnType("varchar(2048)");

                    b.Property<string>("TmdbUrl")
                        .HasColumnType("varchar(MAX)");

                    b.HasKey("Id");

                    b.ToTable("Crew");
                });

            modelBuilder.Entity("MovieShopMVC.Core.Entities.Favorite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Favorite");
                });

            modelBuilder.Entity("MovieShopMVC.Core.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("MovieShopMVC.Core.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BackdropUrl")
                        .HasColumnType("varchar(2084)");

                    b.Property<decimal?>("Budget")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(MAX)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2(7)");

                    b.Property<string>("ImdbUrl")
                        .HasColumnType("varchar(2084)");

                    b.Property<string>("OriginalLanguage")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("Overview")
                        .HasColumnType("varchar(MAX)");

                    b.Property<string>("PosterUrl")
                        .HasColumnType("varchar(2084)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(5,2)");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("datetime2(7)");

                    b.Property<decimal?>("Revenue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("RunTime")
                        .HasColumnType("int");

                    b.Property<string>("Tagline")
                        .HasColumnType("varchar(512)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<string>("TmdbUrl")
                        .HasColumnType("varchar(2084)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("varchar(MAX)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2(7)");

                    b.HasKey("Id");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("MovieShopMVC.Core.Entities.MovieCast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CastId")
                        .HasColumnType("int");

                    b.Property<string>("Character")
                        .IsRequired()
                        .HasColumnType("varchar(450)");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CastId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieCast");
                });

            modelBuilder.Entity("MovieShopMVC.Core.Entities.MovieCrew", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CrewId")
                        .HasColumnType("int");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("varchar(128)");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("job")
                        .IsRequired()
                        .HasColumnType("varchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("CrewId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieCrew");
                });

            modelBuilder.Entity("MovieShopMVC.Core.Entities.MovieGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieGenre");
                });

            modelBuilder.Entity("MovieShopMVC.Core.Entities.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDateTime")
                        .HasColumnType("datetime2(7)");

                    b.Property<Guid>("PurchaseNumber")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Purchase");
                });

            modelBuilder.Entity("MovieShopMVC.Core.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(3,2)");

                    b.Property<string>("ReviewText")
                        .HasColumnType("varchar(MAX)");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("MovieShopMVC.Core.Entities.Trailer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(2084)");

                    b.Property<string>("TrailerId")
                        .IsRequired()
                        .HasColumnType("varchar(2084)");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Trailer");
                });

            modelBuilder.Entity("MovieShopMVC.Core.Entities.Favorite", b =>
                {
                    b.HasOne("MovieShopMVC.Core.Entities.Movie", "Movie")
                        .WithMany("Favorites")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieShopMVC.Core.Entities.MovieCast", b =>
                {
                    b.HasOne("MovieShopMVC.Core.Entities.Cast", "Cast")
                        .WithMany("MovieCasts")
                        .HasForeignKey("CastId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieShopMVC.Core.Entities.Movie", null)
                        .WithMany("MovieCasts")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cast");
                });

            modelBuilder.Entity("MovieShopMVC.Core.Entities.MovieCrew", b =>
                {
                    b.HasOne("MovieShopMVC.Core.Entities.Crew", "Crew")
                        .WithMany("MovieCrewers")
                        .HasForeignKey("CrewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieShopMVC.Core.Entities.Movie", null)
                        .WithMany("MovieCrews")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Crew");
                });

            modelBuilder.Entity("MovieShopMVC.Core.Entities.MovieGenre", b =>
                {
                    b.HasOne("MovieShopMVC.Core.Entities.Genre", "Genre")
                        .WithMany("MovieGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieShopMVC.Core.Entities.Movie", "Movie")
                        .WithMany("MovieGenres")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieShopMVC.Core.Entities.Purchase", b =>
                {
                    b.HasOne("MovieShopMVC.Core.Entities.Movie", "Movie")
                        .WithMany("Purchases")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieShopMVC.Core.Entities.Review", b =>
                {
                    b.HasOne("MovieShopMVC.Core.Entities.Movie", "Movie")
                        .WithMany("Reviews")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieShopMVC.Core.Entities.Trailer", b =>
                {
                    b.HasOne("MovieShopMVC.Core.Entities.Movie", "Movie")
                        .WithMany("Trailers")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieShopMVC.Core.Entities.Cast", b =>
                {
                    b.Navigation("MovieCasts");
                });

            modelBuilder.Entity("MovieShopMVC.Core.Entities.Crew", b =>
                {
                    b.Navigation("MovieCrewers");
                });

            modelBuilder.Entity("MovieShopMVC.Core.Entities.Genre", b =>
                {
                    b.Navigation("MovieGenres");
                });

            modelBuilder.Entity("MovieShopMVC.Core.Entities.Movie", b =>
                {
                    b.Navigation("Favorites");

                    b.Navigation("MovieCasts");

                    b.Navigation("MovieCrews");

                    b.Navigation("MovieGenres");

                    b.Navigation("Purchases");

                    b.Navigation("Reviews");

                    b.Navigation("Trailers");
                });
#pragma warning restore 612, 618
        }
    }
}
