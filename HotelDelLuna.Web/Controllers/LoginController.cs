using HotelDelLuna.Provider;
using HotelDelLuna.ViewModel.Models.Logins;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HotelDelLuna.Web.Controllers
{
    public class LoginController : BaseController
    {
        public IActionResult Login()
        {
            var model = new LoginViewModel();
            return View(model);
        }

        [ValidateAntiForgeryToken] // Anti token untuk keamanan method post
        [HttpPost]
        public async Task<IActionResult> Login(string ReturnUrl, LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                if (LoginProvider.GetProvider().IsAuthenticated(vm))
                {
                    string rolesMember = LoginProvider.GetProvider().MemberRoles(vm);
                    var claims = LoginProvider.GetProvider().GetNewClaims(vm, rolesMember);

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(principal);

                    LoginProvider.GetProvider().LoginSuccess(vm);

                    if (string.IsNullOrEmpty(ReturnUrl)) //jika urlnya gak arah ke mana mana
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return Redirect(ReturnUrl);
                    }

                }
                else
                {
                    LoginProvider.GetProvider().LoginFail(vm);
                    return RedirectToAction("LoginFailed");
                }
            }
            return View("Login", vm); // kalo gagal di validasi awal langsung diarahin ke index dan msg vm

        }

        [HttpGet]
        public IActionResult LoginFailed()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            SetUsernameRole(User.Claims);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

    }
}
