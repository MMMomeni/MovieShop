using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class MoviesController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
