using HotelDelLuna.DataAccess;
using HotelDelLuna.DataAccess.Models;
using HotelDelLuna.ViewModel.Models.HotelImages;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HotelDelLuna.Provider
{
    public class HotelProvider : BaseProvider
    {
        private static HotelProvider _instance = new HotelProvider();
        public static HotelProvider GetProvider()
        {
            return _instance;
        }

        public async void RunInsertImage(IFormFile partImage, string fileName) 
        {
            using (var context = new HotelDelLunaContext())
            {
                HotelImage hotelImage = new HotelImage 
                {
                    PartView = $"{partImage.Name}-{DateTime.Now.ToString("G")}",
                    PartPicture = fileName
                };
                context.HotelImages.Add(hotelImage);
                await context.SaveChangesAsync();                
            }
        }

        public string GetImage() 
        {
            using (var context = new HotelDelLunaContext())
            {
                string name = context.HotelImages.OrderByDescending(a => a.PartView).FirstOrDefault().PartPicture;
                //string picName = $"~/images/{name}";
                return name;
            }
        }

    }
}
