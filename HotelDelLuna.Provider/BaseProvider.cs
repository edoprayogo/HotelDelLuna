using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDelLuna.Provider
{
    public abstract class BaseProvider
    {
        protected int GetSkipData(int page, int totalRowPage)
        {
            return (page - 1) * totalRowPage;
        }
        protected string GenerateUsername(string gender, string firstName, string lastName, string idNumber) 
        {
            string firstCode = gender.Substring(0,1);
            string secondCode = $"{firstName.Substring(0, 1)}{lastName.Substring(0, 1)}";
            string thirdCode = idNumber.Substring((idNumber.Length - 4),4);

            return $"{firstCode}{secondCode}{thirdCode}";
        }
    }
}
