using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelDelLuna.ViewModel.Models.Logins
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "* Wajib diisi")]
        [StringLength(maximumLength: 20, ErrorMessage = "Maksimal karakter 20")]
        public string Username { get; set; }

        [Required(ErrorMessage = "* Wajib diisi")]
        [StringLength(maximumLength: 200, ErrorMessage = "Maksimal karakter 200")]
        public string Password { get; set; }
    }
}
