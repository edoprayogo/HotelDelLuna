using HotelDelLuna.DataAccess;
using HotelDelLuna.ViewModel.Models.Logins;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Security.Claims;
using HotelDelLuna.DataAccess.Models;

namespace HotelDelLuna.Provider
{
    public class LoginProvider
    {
        private static LoginProvider _instance = new LoginProvider();
        public static LoginProvider GetProvider()
        {
            return _instance;
        }

        public bool IsAuthenticated(LoginViewModel vm)
        {
            using (var context = new HotelDelLunaContext())
            {
                var userLogin = context.Accounts.SingleOrDefault(a => a.Username == vm.Username && (a.Status == "A" || a.Status == "Admin"));
                if (userLogin != null)
                {
                    var passwordDb = userLogin.Password;
                    bool check = BCrypt.Net.BCrypt.Verify(vm.Password, passwordDb);
                    if (check)
                    {
                        return true;
                    }
                }
                return false;

            }
        }

        public string MemberRoles(LoginViewModel vm)
        {
            using (var dbContext = new HotelDelLunaContext())
            {
                if (dbContext.Accounts.Any(a => a.Username == vm.Username && a.Status == "Admin"))
                {
                    return "Administrator";
                }
                else
                {
                    return "Guest";
                }
            }
        }

        public List<Claim> GetNewClaims(LoginViewModel vm, string roles)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, vm.Username),
                new Claim(ClaimTypes.Role, roles)
            };
            return claims;
        }

        public void LoginSuccess(LoginViewModel vm)
        {
            using (var context = new HotelDelLunaContext())
            {
                Account acc = context.Accounts.Where(a => a.Username == vm.Username).FirstOrDefault();
                acc.LoginFailCount = 0;
                context.SaveChanges();
            }
        }
        public void LoginFail(LoginViewModel vm)
        {
            using (var context = new HotelDelLunaContext())
            {
                var entityOld = context.Accounts.SingleOrDefault(a => a.Username == vm.Username);

                int countLoginFail = entityOld.LoginFailCount;
                int newCount = countLoginFail + 1;
                entityOld.LoginFailCount = newCount;
                context.SaveChanges();

                if (entityOld.LoginFailCount >= 3)
                {
                    entityOld.Status = "B";
                    context.SaveChanges();
                }

            }
        }
    }
}
