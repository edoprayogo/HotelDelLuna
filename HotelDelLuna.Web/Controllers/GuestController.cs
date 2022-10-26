using HotelDelLuna.Provider;
using HotelDelLuna.ViewModel.Helpers;
using HotelDelLuna.ViewModel.Models.Guests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelDelLuna.Web.Controllers
{
    [Authorize]
    public class GuestController : BaseController
    {
        public IActionResult Index(int page = 1)
        {
            SetUsernameRole(User.Claims);
            Pager pager;
            var guests = GuestProvider.GetProvider().GetGuestGridIndex(out pager, page);
            ViewBag.Pager = pager;
            return View(guests);
        }

        public IActionResult Insert() 
        {
            UpsertGuestModel viewModel = new UpsertGuestModel();
            return Json(viewModel);
        }

        public IActionResult Update(int registerId)
        {
            UpsertGuestModel viewModel = GuestProvider.GetProvider().GetUpdate(registerId);
            return Json(viewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Save([FromBody] UpsertGuestModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (vm.UserId == 0)
                    {
                        GuestProvider.GetProvider().RunInsert(vm);
                    }
                    else
                    {
                        GuestProvider.GetProvider().RunUpdate(vm);
                    }
                    return Json(new { success = true });
                }
                catch (Exception)
                {

                    throw;
                }
            }
            var validationMessages = GetValidationMessagesVM(ModelState);
            return Json(new { success = false, validations = validationMessages });
        }

    }
}
