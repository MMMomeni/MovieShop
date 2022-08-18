using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Core.Contracts.Service;
using MovieShopMVC.Core.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MovieShopMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountServiceAsync accountServiceAsync;
        public AccountController(IAccountServiceAsync accountServiceAsync)
        {
            this.accountServiceAsync = accountServiceAsync;
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            if (ModelState.IsValid)
            {
                await accountServiceAsync.SignUpAsync(model);
                return RedirectToAction("Index", "Movies");
            }
            return View(model);
        }
        public IActionResult Login(SignInModel model)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(SignInModel model)
        {
            var result = await accountServiceAsync.LoginAsync(model);

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (!result.Succeeded || result == null)
            {
                ModelState.AddModelError(string.Empty, "Please check username and password");
                return View();
            }


            //list of claims
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.Email),
                new Claim(ClaimTypes.Country, "USA"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var authKey

        }
    }
}
