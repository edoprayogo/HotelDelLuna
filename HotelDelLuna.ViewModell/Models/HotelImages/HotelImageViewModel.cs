using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDelLuna.ViewModel.Models.HotelImages
{
    public class HotelImageViewModel
    {
        public string PartView { get; set; }
        public IFormFile PartImage { get; set; }
    }
}
