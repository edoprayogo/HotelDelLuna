using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDelLuna.ViewModel.Models.Rooms
{
    public class RoomViewModel
    {
        public string RoomNumber { get; set; }
        public int Floor { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
    }
}
