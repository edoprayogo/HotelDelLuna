using HotelDelLuna.Provider;
using HotelDelLuna.ViewModel.Helpers;
using HotelDelLuna.ViewModel.Models.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelDelLuna.Web.Controllers
{

    public class AccountController : BaseController
    {
        [Authorize(Roles = "Administrator")]
        public IActionResult Index(int page = 1)
        {
            SetUsernameRole(User.Claims);
            Pager pager;
            var accounts = AccountProvider.GetProvider().GetAccountGridIndex(out pager, page);
            ViewBag.Pager = pager;
            ViewBag.Controller = "Account";
            ViewBag.ListStatus = DropDownView.ListStatusAccount();
            return View(accounts);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Insert() 
        {
            SetUsernameRole(User.Claims);
            UpsertAccountModel viewModel = new UpsertAccountModel();
            return Json(viewModel);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Update(int userId) 
        {
            SetUsernameRole(User.Claims);
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

        public IActionResult ChangeStatus(int userId) 
        {
            AccountProvider.GetProvider().RunChangeStatus(userId);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Guest")]
        public IActionResult MyProfile() 
        {
            SetUsernameRole(User.Claims);
            string username = GetUsername(User.Claims);
            var profileView = AccountProvider.GetProvider().MyProfilView(username);
            return View(profileView);
        }

        public IActionResult UpdateMyProfile() 
        {
            SetUsernameRole(User.Claims);
            string username = GetUsername(User.Claims);
            MyProfileViewModel myModel = AccountProvider.GetProvider().GetUpdateMyProfile(username);
            return Json(myModel);
        }

        //[ValidateAntiForgeryToken]
        //[HttpPost]
        //public IActionResult EditMyProfil([FromBody] MyProfileViewModel vm)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            if (vm. == 0)
        //            {
        //                AccountProvider.GetProvider().RunInsert(vm);
        //            }
        //            else
        //            {
        //                AccountProvider.GetProvider().RunUpdate(vm);
        //            }
        //            return Json(new { success = true });
        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }
        //    }
        //    var validationMessages = GetValidationMessagesVM(ModelState);
        //    return Json(new { success = false, validations = validationMessages });
        //}

    }
}
