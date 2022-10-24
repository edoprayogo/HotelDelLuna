using HotelDelLuna.Provider;
using HotelDelLuna.ViewModel.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelDelLuna.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index(int page = 1)
        {
            Pager pager;
            var guests = AccountProvider.GetProvider().GetAccountGridIndex(out pager, page);
            ViewBag.Pager = pager;
            return View(guests);
        }


    }
}
