using HotelDelLuna.DataAccess;
using HotelDelLuna.ViewModel.Models.Guests;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using HotelDelLuna.ViewModel.Helpers;
using HotelDelLuna.DataAccess.Models;

namespace HotelDelLuna.Provider
{
    public class GuestProvider : BaseProvider
    {
        private static GuestProvider _instance = new GuestProvider();
        public static GuestProvider GetProvider()
        {
            return _instance;
        }

        public List<GuestViewModel> GetAllGuest() 
        {
            using (var context = new HotelDelLunaContext())
            {
                var guests = (from g in context.Guests
                              select new GuestViewModel {
                                RegisterId = g.RegisterId,
                                FirstName = g.FirstName,
                                LastName = g.LastName,
                                BirthDate = g.BirthDate,
                                BirthCity = g.BirthCity,
                                Gender = g.Gender,
                                IdNumber = g.IdNumber,
                                UserId = g.UserId,
                                Account = g.Account,
                              }).ToList();
                return guests;                
            }
        }

        public IEnumerable<GuestViewModel> GetGuestGridIndex(out Pager pager, int page = 1) 
        {
            var guests = GetAllGuest();
            int totalData = guests.Count();
            pager = new Pager(totalData,page);
            var guestGrid = guests.Skip(GetSkipData(page, pager.PageSize)).Take(pager.PageSize);
            return guestGrid;
        }

        public UpsertGuestModel GetUpdate(int registerId)
        {
            using (var context = new HotelDelLunaContext())
            {
                var entityOld = context.Guests.FirstOrDefault(g => g.RegisterId == registerId);
                UpsertGuestModel viewModel = new UpsertGuestModel();
                viewModel.RegisterId = entityOld.RegisterId;
                viewModel.UserId = entityOld.UserId;
                viewModel.FirstName = entityOld.FirstName;
                viewModel.LastName = entityOld.LastName;
                viewModel.BirthDate = entityOld.BirthDate;
                viewModel.BirthCity = entityOld.BirthCity;
                viewModel.Gender = entityOld.Gender;
                viewModel.IdNumber = entityOld.IdNumber;
                return viewModel;
            }
        }

        public void RunUpdate(UpsertGuestModel vm)
        {
            using (var context = new HotelDelLunaContext())
            {
                Guest entityOld = context.Guests.SingleOrDefault(a => a.UserId == vm.UserId);
                entityOld.FirstName = vm.FirstName;
                entityOld.LastName = vm.LastName;
                entityOld.BirthDate = vm.BirthDate;
                entityOld.BirthCity = vm.BirthCity;
                entityOld.Gender = vm.Gender;
                entityOld.IdNumber = vm.IdNumber;
                context.SaveChanges();
            }
        }

        public void RunInsert(UpsertGuestModel vm)
        {
            using (var contenxt = new HotelDelLunaContext())
            {
                Account newAcc = new Account()
                {
                    Username = GenerateUsername(vm.Gender, vm.FirstName, vm.LastName, vm.IdNumber),
                    Password = BCrypt.Net.BCrypt.HashPassword(vm.IdNumber),
                    Status = "A",
                    LoginFailCount = 0
                };
                contenxt.Add(newAcc);
                contenxt.SaveChanges();

                Guest newGuest = new Guest()
                {
                    UserId = newAcc.UserId,
                    FirstName = vm.FirstName,
                    LastName = vm.LastName,
                    BirthDate = vm.BirthDate,
                    BirthCity = vm.BirthCity,
                    Gender = vm.Gender,
                    IdNumber = vm.IdNumber,                    
                };
                contenxt.Guests.Add(newGuest);
                contenxt.SaveChanges();
            }
        }

        

    }
}
