using HotelDelLuna.DataAccess;
using HotelDelLuna.ViewModel.Models.Rooms;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using HotelDelLuna.ViewModel.Helpers;
using HotelDelLuna.DataAccess.Models;
using HotelDelLuna.ViewModel.Models.BookHistories;

namespace HotelDelLuna.Provider
{
    public class RoomProvider : BaseProvider
    {
        private static RoomProvider _instance = new RoomProvider();
        public static RoomProvider GetProvider()
        {
            return _instance;
        }

        public List<RoomViewModel> GetAllRoom()
        {
            using (var context = new HotelDelLunaContext())
            {
                var guests = (from r in context.Rooms 
                              select new RoomViewModel {
                                  RoomNumber = r.RoomNumber,
                                  Type = r.Type,
                                  Floor = r.Floor,
                                  Price = r.Price
                              }).ToList();
                return guests;
            }
        }

        public IEnumerable<RoomViewModel> GetRoomGridIndex(out Pager pager, int page = 1)
        {
            var guests = GetAllRoom();
            int totalData = guests.Count();
            pager = new Pager(totalData, page);
            var guestGrid = guests.Skip(GetSkipData(page, pager.PageSize)).Take(pager.PageSize);
            return guestGrid;
        }

        public UpsertRoomModel GetUpdate(string roomNummber)
        {
            using (var context = new HotelDelLunaContext())
            {
                var entityOld = context.Rooms.FirstOrDefault(r => r.RoomNumber == roomNummber);
                UpsertRoomModel viewModel = new UpsertRoomModel();
                viewModel.RoomNumber = entityOld.RoomNumber;
                viewModel.DoorNumber = Convert.ToInt32(entityOld.RoomNumber.Substring((roomNummber.Length - 2), 2));
                viewModel.Type = entityOld.Type;
                viewModel.Floor = entityOld.Floor;
                viewModel.Price = entityOld.Price;
                return viewModel;
            }
        }

        public void RunUpdate(UpsertRoomModel vm)
        {
            using (var context = new HotelDelLunaContext())
            {
                var entityOld = context.Rooms.SingleOrDefault(r => r.RoomNumber == vm.RoomNumber);
                entityOld.Floor = vm.Floor;
                entityOld.Type = vm.Type;
                entityOld.Price = vm.Price;
                context.SaveChanges();
            }
        }

        public void RunInsert(UpsertRoomModel vm)
        {
            using (var context = new HotelDelLunaContext())
            {
                Room newRoom = new Room()
                {
                    RoomNumber = GenerateRoomNumber(vm),
                    Floor = vm.Floor,
                    Type = vm.Type,
                    Price = vm.Price
                };
                context.Rooms.Add(newRoom);
                context.SaveChanges();
            }
        }

        public void BookingRoom(UpsertBookHistoryModel vm) 
        {
            using (var context = new HotelDelLunaContext())
            {
                BookHistory bookHistory = new BookHistory()
                {
                    RoomNumber = vm.RoomNumber,
                    UserId = vm.UserId,
                    CheckInDate = vm.CheckInDate,
                    CheckOutDate = vm.CheckOutDate,
                    FamilyCount = vm.FamilyCount
                };
                context.BookHistories.Add(bookHistory);
                context.SaveChanges();
            }
        }


        public string GenerateRoomNumber(UpsertRoomModel vm)
        {
            return $"{vm.Floor}{vm.DoorNumber.ToString("00")}";
        }

        public int GetIdUser(string username) 
        {
            return AccountProvider.GetProvider().GettAllAccount().Where(a => a.Username == username).SingleOrDefault().UserId;
        }

    }
}
