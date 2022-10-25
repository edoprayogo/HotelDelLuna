﻿using HotelDelLuna.DataAccess;
using HotelDelLuna.ViewModel.Models.Accounts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using HotelDelLuna.ViewModel.Helpers;
using HotelDelLuna.DataAccess.Models;

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

    }
}
