using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;

namespace HotelDelLuna.ViewModel.Helpers
{
    public static class ParsingView
    {
        public static string FormatRupiah(decimal money) {
            return money.ToString("c", CultureInfo.CreateSpecificCulture("id-ID"));
        }
    }
}
