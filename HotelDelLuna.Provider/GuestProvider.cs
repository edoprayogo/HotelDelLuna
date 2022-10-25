using HotelDelLuna.DataAccess;
using HotelDelLuna.ViewModel.Models.Guests;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using HotelDelLuna.ViewModel.Helpers;

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
                                UserId = g.UserId
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
        

    }
}
