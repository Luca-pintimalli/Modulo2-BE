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
        private readonly ILogger<AccountController> logger;

        public AccountController(IAuthService authenticationService, ILogger<AccountController> logger)
        {
            this.authenticationService = authenticationService;
            this.logger = logger;
        }

        public IActionResult Auth()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }



        //GESTIONE LOGIN
        [HttpPost]
        public async Task<IActionResult> Login(ApplicationUser user)
        {
            try
            {

                var u = authenticationService.Login(user.UserName, user.Password);

                if (u == null)
                {
                    return RedirectToAction("Login", "Account"); // Torna alla pagina di login
                }


                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, $"Utente : {u.UserName}"),
        };
                u.Roles.ForEach(r => claims.Add(new Claim(ClaimTypes.Role, r)));

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity));

            }
            catch (Exception ex)
            {
               
            }

            return RedirectToAction("Index", "Home");
        }



        //gestione logout 
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

