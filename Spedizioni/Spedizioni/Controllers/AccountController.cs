

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Spedizioni.Models;

namespace Spedizioni.Controllers
{
	public class AccountController : Controller
	{

        private readonly IAuthService authenticationService;


        public AccountController(IAuthService authenticationService)
		{
			this.authenticationService = authenticationService;
		}


		public IActionResult Login()
		{
			return View();
		}


        [HttpPost]
        public IActionResult Login(ApplicationUser user)
        {
            try
            {
                var u = authenticationService.Login(user.UserName, user.Password);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, u.UserName),
                    new Claim(ClaimTypes.Role, "Amministratore") //DEFINISCO IL RUOLO
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity)

                    );

            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Index", "Home");
        }




    }
}

