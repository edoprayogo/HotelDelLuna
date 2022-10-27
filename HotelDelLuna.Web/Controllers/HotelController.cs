using HotelDelLuna.Provider;
using HotelDelLuna.ViewModel.Models.HotelImages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace HotelDelLuna.Web.Controllers
{
    public class HotelController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HotelController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnvironment = webHostEnvironment;
        }

        public IActionResult AboutUs()
        {
            SetUsernameRole(User.Claims);
            ViewBag.Pict = HotelProvider.GetProvider().GetImage();
            return View();
        }

        public IActionResult ThisHotel()
        {
            SetUsernameRole(User.Claims);
            UpsertHotelImage model = new UpsertHotelImage();
            return View(model);
        }

        #region Belum dipake
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> InsertImage(HotelImageViewModel model) 
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string uniqueFileName = UploadedFile(model);
        //        HotelProvider.GetProvider().RunInsertImage(model, uniqueFileName);
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
        //private string UploadedFile(HotelImageViewModel model)
        //{
        //    string uniqueFileName = null;

        //    if (model.PartImage != null)
        //    {
        //        string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
        //        uniqueFileName = Guid.NewGuid().ToString() + "_" + model.PartImage.FileName;
        //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            model.PartImage.CopyTo(fileStream);
        //        }
        //    }
        //    return uniqueFileName;
        //}
        #endregion

        //[HttpPost]
        //public async Task<IActionResult> UpsertImage(UpsertHotelImage modelImage)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string uniqueFileName = UploadedFileName(modelImage);
        //        HotelProvider.GetProvider().RunInsertImage(modelImage, await UploadImage(modelImage));
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        private async Task<string> UploadImage(UpsertHotelImage modelImage)
        {
            string result = null;
            if (modelImage.PartImage != null)
            {
                string folder = "Images/Profile/";
                string filename = Guid.NewGuid().ToString() + modelImage.PartView;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder + filename);

                await modelImage.PartImage.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                result = filename;
            }
            return result;
            //string uniqueFileName = null;

            //if (formFile != null)
            //{
            //    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            //    uniqueFileName = Guid.NewGuid().ToString() + "_" + formFile.FileName;
            //    //string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            //    await formFile.CopyToAsync(new FileStream(uploadsFolder, FileMode.Create));
            //}
            //return uniqueFileName;
        }

        private string UploadedFileName(UpsertHotelImage model)
        {
            string uniqueFileName = null;

            if (model.PartImage != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.PartImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.PartImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        //public class upsert{
        //    public int Id { get; set; }
        //    public IFormFile Foto { get; set; }
        //}


        [HttpPost]
        public async Task<IActionResult> AddImage(IFormFile partImage)
        {
            ViewBag.Pict = HotelProvider.GetProvider().GetImage();
            var img = await UploadedImage(partImage);
            HotelProvider.GetProvider().RunInsertImage(partImage, img);
            return RedirectToAction("AboutUs");
        }

        private async Task<string> UploadedImage(IFormFile partImage)
        {
            string result = null;
            if (partImage != null)
            {
                string folder = "images/";
                string filename = Guid.NewGuid().ToString() + partImage.FileName;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder + filename);

                await partImage.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                result = filename;
            }
            return result;
        }
    }
}
