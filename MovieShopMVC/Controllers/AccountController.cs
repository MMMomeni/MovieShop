using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MovieShopMVC.Core.Contracts.Service;
using MovieShopMVC.Core.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MovieShopMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountServiceAsync accountServiceAsync;
        private readonly IConfiguration configuration;
        public AccountController(IAccountServiceAsync accountServiceAsync, IConfiguration configuration)
        {
            this.accountServiceAsync = accountServiceAsync;
            this.configuration = configuration;
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

            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256Signature)
                );
            // Now we need to use token handler that returns the token in the output.
            var t = new JwtSecurityTokenHandler().WriteToken(token);

            /* We need to return an object because Angular needs objects, otherwise
             * we could just return "t"*/
            return Ok(new { jwt = t });

        }
    }
}
