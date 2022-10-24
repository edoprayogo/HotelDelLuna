using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDelLuna.ViewModel.Models.Guests
{
    public class UpsertGuestModel
    {
        public int RegisterId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthCity { get; set; }
        public string Gender { get; set; }
        public string IdNumber { get; set; }
    }
}
