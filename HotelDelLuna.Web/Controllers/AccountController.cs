using HotelDelLuna.Provider;
using HotelDelLuna.ViewModel.Helpers;
using HotelDelLuna.ViewModel.Models.Accounts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelDelLuna.Web.Controllers
{
    public class AccountController : BaseController
    {
        public IActionResult Index(int page = 1)
        {
            Pager pager;
            var accounts = AccountProvider.GetProvider().GetAccountGridIndex(out pager, page);
            ViewBag.Pager = pager;
            ViewBag.Controller = "Account";
            ViewBag.ListStatus = DropDownView.ListStatusAccount();
            return View(accounts);
        }

        public IActionResult Insert() 
        {
            UpsertAccountModel viewModel = new UpsertAccountModel();
            return Json(viewModel);
        }

        public IActionResult Update(int userId) 
        {
            UpsertAccountModel viewModel = AccountProvider.GetProvider().GetUpdate(userId);
            return Json(viewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Save([FromBody] UpsertAccountModel vm) 
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (vm.UserId == 0)
                    {
                        AccountProvider.GetProvider().RunInsert(vm);                        
                    }
                    else
                    {
                        AccountProvider.GetProvider().RunUpdate(vm);                        
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
