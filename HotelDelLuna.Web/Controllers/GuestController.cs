using HotelDelLuna.Provider;
using HotelDelLuna.ViewModel.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelDelLuna.Web.Controllers
{
    public class GuestController : BaseController
    {
        public IActionResult Index(int page = 1)
        {
            Pager pager;
            var guests = GuestProvider.GetProvider().GetGuestGridIndex(out pager, page);
            ViewBag.Controller = "Mahasiswa";
            ViewBag.Pager = pager;
            return View(guests);
        }
    }
}
