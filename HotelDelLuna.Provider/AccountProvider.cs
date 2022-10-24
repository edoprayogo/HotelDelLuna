using HotelDelLuna.DataAccess;
using HotelDelLuna.ViewModel.Models.Accounts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using HotelDelLuna.ViewModel.Helpers;

namespace HotelDelLuna.Provider
{
    public class AccountProvider : BaseProvider
    {
        private static AccountProvider _instance = new AccountProvider();
        public static AccountProvider GetProvider()
        {
            return _instance;
        }

        public List<AccountViewModel> GettAllAccount()
        {
            using (var context = new HotelDelLunaContext())
            {
                var accounts = (from a in context.Accounts
                                select new AccountViewModel {
                                    Username = a.Username,
                                    Password = a.Password,
                                    Status = a.Status
                                }).ToList();
                return accounts;
            }
        }

        public IEnumerable<AccountViewModel> GetAccountGridIndex(out Pager pager, int page = 1)
        {
            var accounts = GettAllAccount();
            int totalData = accounts.Count();
            pager = new Pager(totalData, page);
            var accGrid = accounts.Skip(GetSkipData(page, pager.PageSize)).Take(pager.PageSize);
            return accGrid;
        }



    }
}
