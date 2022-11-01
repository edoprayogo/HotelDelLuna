using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDelLuna.ViewModel.Models.BookHistories
{
    public class UpsertBookHistoryModel
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string RoomNumber { get; set; }
        public int FamilyCount { get; set; }
    }
}
