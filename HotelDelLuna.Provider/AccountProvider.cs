using HotelDelLuna.DataAccess;
using HotelDelLuna.ViewModel.Models.Accounts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using HotelDelLuna.ViewModel.Helpers;
using HotelDelLuna.DataAccess.Models;
using HotelDelLuna.ViewModel.Models.Guests;

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
                                select new AccountViewModel
                                {
                                    UserId = a.UserId,
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

        public UpsertAccountModel GetUpdate(int userId)
        {
            using (var context = new HotelDelLunaContext())
            {
                var entityOld = context.Accounts.FirstOrDefault(a => a.UserId == userId);
                UpsertAccountModel viewModel = new UpsertAccountModel();
                viewModel.UserId = entityOld.UserId;
                viewModel.Username = entityOld.Username;
                viewModel.Password = entityOld.Password;
                viewModel.Status = entityOld.Status;
                return viewModel;
            }
        }

        public void RunUpdate(UpsertAccountModel vm)
        {
            using (var context = new HotelDelLunaContext())
            {
                Account entityOld = context.Accounts.SingleOrDefault(a => a.UserId == vm.UserId);
                entityOld.Username = vm.Username;
                entityOld.Password = BCrypt.Net.BCrypt.HashPassword(vm.Password);
                entityOld.Status = vm.Status;
                context.SaveChanges();
            }
        }

        public void RunInsert(UpsertAccountModel vm)
        {
            using (var contenxt = new HotelDelLunaContext())
            {
                Account newAccount = new Account()
                {
                    Username = vm.Username,
                    Password = BCrypt.Net.BCrypt.HashPassword(vm.Password),
                    Status = vm.Status,
                    LoginFailCount = 0
                };
                contenxt.Add(newAccount);
                contenxt.SaveChanges();



            }
        }

        public void RunChangeStatus(int userId)
        {
            using (var context = new HotelDelLunaContext())
            {
                Account entity = context.Accounts.SingleOrDefault(a => a.UserId == userId);
                if (entity.Status == "A")
                {
                    entity.Status = "N";
                    context.SaveChanges();
                }
                else
                {
                    entity.Status = "A";
                    entity.LoginFailCount = 0;
                    context.SaveChanges();
                }
            }
        }

        public MyProfileViewModel MyProfilView(string username)
        {
            using (var context = new HotelDelLunaContext())
            {
                bool checkAnyGuest = context.Guests.Any(g => g.Account.Username == username);
                if (checkAnyGuest)
                {
                    Guest guest = context.Guests.Where(g => g.Account.Username == username).AsEnumerable().FirstOrDefault();
                    Account acc = context.Accounts.Where(a => a.Username == username).FirstOrDefault();
                    var guestDetail = new MyProfileViewModel()
                    {
                        RegisterId = guest.RegisterId,
                        UserId = guest.UserId,
                        FirstName = guest.FirstName,
                        LastName = guest.LastName,
                        BirthDate = guest.BirthDate,
                        BirthCity = guest.BirthCity,
                        Gender = guest.Gender,
                        IdNumber = guest.IdNumber,
                        Username = username,
                        Status = acc.Status,
                        Account = acc
                    };
                    return guestDetail;
                }
                else
                {
                    var guestDetail = new MyProfileViewModel()
                    {
                        
                        RegisterId = 0,
                        UserId = null,
                        FirstName = null,
                        LastName = null,
                        BirthDate = new DateTime(2000,1,1),
                        BirthCity = null,
                        Gender = null,
                        IdNumber = null,
                        Account = null,
                        Username = username,
                        Status = "A"
                    };
                    return guestDetail;
                }

            }
        }

        public MyProfileViewModel GetUpdateMyProfile(string username) 
        {
            using (var context = new HotelDelLunaContext())
            {
                bool checkAcc = context.Accounts.Any(a => a.Username == username);
                if (checkAcc)
                {
                    Guest guest = context.Guests.FirstOrDefault(g => g.Account.Username == username);
                    Account account = guest.Account;
                    MyProfileViewModel viewModel = new MyProfileViewModel();
                    viewModel.Account = account;
                    viewModel.RegisterId = guest.RegisterId;
                    viewModel.UserId = guest.UserId;
                    viewModel.FirstName = guest.FirstName;
                    viewModel.LastName = guest.LastName;
                    viewModel.BirthCity = guest.BirthCity;
                    viewModel.BirthDate = guest.BirthDate;
                    viewModel.Gender = guest.Gender;
                    viewModel.IdNumber = guest.IdNumber;
                    viewModel.Username = username;
                    viewModel.Status = account.Status;                    
                    return viewModel;
                }
                else
                {
                    MyProfileViewModel viewModel = new MyProfileViewModel();
                    viewModel.RegisterId = 0;
                    viewModel.UserId = 0;
                    viewModel.FirstName = null;
                    viewModel.LastName = null;
                    viewModel.BirthCity = null;
                    viewModel.BirthDate = new DateTime(2000, 1, 1);
                    viewModel.Gender = null;
                    viewModel.IdNumber = null;
                    viewModel.Username = null;
                    viewModel.Status = "A";
                    return viewModel;
                }
            }
        }

        public void RunEditMyProfil() 
        {

        }

    }
}
