using HotelDelLuna.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HotelDelLuna.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            SetUsernameRole(User.Claims);
            return View();
        }

        public IActionResult Privacy()
        {
            SetUsernameRole(User.Claims);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void SetUsernameRole(IEnumerable<Claim> claims)
        {
            foreach (var claim in claims)
            {
                if (claim.Type == ClaimTypes.NameIdentifier)
                {
                    ViewBag.Username = claim.Value;
                }

                if (claim.Type == ClaimTypes.Role)
                {
                    ViewBag.Role = claim.Value;
                }

            }
        }
    }
}
