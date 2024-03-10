using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ElectroMVC.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles ="user")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
