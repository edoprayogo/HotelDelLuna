using HotelDelLuna.Provider;
using HotelDelLuna.ViewModel.Helpers;
using HotelDelLuna.ViewModel.Models.Rooms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelDelLuna.Web.Controllers
{
    public class RoomController : BaseController
    {
        public IActionResult Index(int page = 1)
        {
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





    }
}
