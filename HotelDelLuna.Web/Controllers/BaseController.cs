using HotelDelLuna.ViewModel.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelDelLuna.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected IEnumerable<ValidationMessageVM> GetValidationMessagesVM(ModelStateDictionary modelState)
        {
            var validationMessages = new List<ValidationMessageVM>();
            foreach (KeyValuePair<string, ModelStateEntry> error in ModelState)
            {
                if (error.Value.Errors.Count < 1)
                {
                    continue;
                }
                else
                {
                    string firstErrorMessage = error.Value.Errors[0].ErrorMessage;
                    validationMessages.Add(new ValidationMessageVM(error.Key, firstErrorMessage));
                }
            }
            return validationMessages;
        }
    }
}
