using ElectroMVC.Data;
using ElectroMVC.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ElectroMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly ElectroMVCContext _context;

        public AccountController(ElectroMVCContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(User _userformPage)
        {
            var _user = _context.User.Where(m => m.Useremail == _userformPage.Useremail && m.Password == _userformPage.Password).FirstOrDefault();
            if (_user == null)
            {
                ViewBag.LoginStatus = 0;
            }
            else
            {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user.Useremail),
                new Claim("FullName", _user.UserName),
                new Claim(ClaimTypes.Role, _user.UserRote),
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {

                };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

                return RedirectToAction("Index", "Account");
            }
            return View();

        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Account");
        }
    }

}
