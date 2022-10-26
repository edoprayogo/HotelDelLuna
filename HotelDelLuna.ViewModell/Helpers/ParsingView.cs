using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;

namespace HotelDelLuna.ViewModel.Helpers
{
    public static class ParsingView
    {
        public static string FormatRupiah(decimal money)
        {
            return money.ToString("c", CultureInfo.CreateSpecificCulture("id-ID"));
        }
        public static string FormatDate(DateTime date)
        {
            return date.ToString("D");
        }

        public static string StringView(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                return text;
            }
            else
            {
                return "N/A";
            }
        }
        public static string FormatTypeRoom(string type)
        {
            if (type == "Reg-SB")
            {
                return "Regular Single Bed";
            }
            else if (type == "Reg-DB")
            {
                return "Regular Double Bed";
            }
            else if (type == "Reg-TB")
            {
                return "Regular Twin Bed";
            }
            else if (type == "VIP-SB")
            {
                return "VIP Single Bed";
            }
            else if (type == "VIP-DB")
            {
                return "VIP Double Bed";
            }
            else if (type == "VIP-TB")
            {
                return "VIP Twin Bed";
            }
            else
            {
                return "";
            }
        }
        public static string FormatStatus(string status)
        {
            if (status == "A")
            {
                return "Active";
            }
            else if (status == "N")
            {
                return "Non-Active";
            }
            else if (status == "Admin")
            {
                return "Admin";
            }
            else
            {
                return "Blocked";
            }
        }

    }
}
