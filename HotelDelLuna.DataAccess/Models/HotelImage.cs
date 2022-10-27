using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelDelLuna.DataAccess.Models
{
    public class HotelImage
    {
        [Key]
        public string PartView { get; set; }
        public string PartPicture { get; set; }
    }
}
