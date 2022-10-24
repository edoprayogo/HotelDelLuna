using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDelLuna.ViewModel.Helpers
{
    public class ValidationMessageVM
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }

        public ValidationMessageVM(string propertyName, string errorMessage)
        {
            this.PropertyName = propertyName;
            this.ErrorMessage = errorMessage;
        }
    }
}
