using MovieShopMVC.Core.Contracts.Repository;
using MovieShopMVC.Core.Contracts.Service;
using MovieShopMVC.Infrastructure.Data;
using MovieShopMVC.Infrastructure.Repository;
using MovieShopMVC.Infrastructure.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSqlServer<MovieShopDbContext>(builder.Configuration.GetConnectionString("MovieShop"));

// Repository Injection
builder.Services.AddScoped<IMovieRepositoryAsync, MovieRepositoryAsync>();

// Service Injection
builder.Services.AddScoped<IMovieServiceAsync, MovieServiceAsync>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movies}/{action=Index}/{id?}");

app.Run();
