using HotelDelLuna.Provider;
using HotelDelLuna.ViewModel.Helpers;
using HotelDelLuna.ViewModel.Models.BookHistories;
using HotelDelLuna.ViewModel.Models.Rooms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelDelLuna.Web.Controllers
{
    [Authorize]
    public class RoomController : BaseController
    {
        public IActionResult Index(int page = 1)
        {
            SetUsernameRole(User.Claims);
            Pager pager;
            var guests = RoomProvider.GetProvider().GetRoomGridIndex(out pager, page);
            ViewBag.Controller = "Room";
            ViewBag.Pager = pager;
            ViewBag.ListRoomType = DropDownView.ListRoomType();
            return View(guests);
        }

        public IActionResult Insert()
        {
            var viewModel = new UpsertRoomModel();
            return Json(viewModel);
        }

        public IActionResult Update(string roomNumber)
        {
            UpsertRoomModel viewModel = RoomProvider.GetProvider().GetUpdate(roomNumber);
            return Json(viewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Save([FromBody] UpsertRoomModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (!string.IsNullOrEmpty(viewModel.RoomNumber))
                    {
                        RoomProvider.GetProvider().RunUpdate(viewModel);
                    }
                    else
                    {
                        RoomProvider.GetProvider().RunInsert(viewModel);
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


        public IActionResult Book(string roomNumber) 
        {
            string username = GetUsername(User.Claims);
            var bookModel = new UpsertBookHistoryModel();
            bookModel.RoomNumber = roomNumber;
            bookModel.UserId = RoomProvider.GetProvider().GetIdUser(username);
            return Json(bookModel);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Booked([FromBody] UpsertBookHistoryModel bookModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    RoomProvider.GetProvider().BookingRoom(bookModel);
                }
                catch (Exception)
                {

                    throw;
                }
                return Json(new { success = true });
            }
            var validationMessages = GetValidationMessagesVM(ModelState);
            return Json(new { success = false, validations = validationMessages });
        }

        
    }
}
