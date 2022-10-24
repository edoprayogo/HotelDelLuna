using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDelLuna.ViewModel.Helpers
{
    public class DropDown
    {
        public string Value { get; set; }
        public string Text { get; set; }
    }

    public static class DropDownView
    {
        public static IEnumerable<DropDown> ListRoomType()
        {
            return new List<DropDown>
            {
                new DropDown {Text = "Select Room Type", Value = null},
                new DropDown {Text = "Regular Single Bed", Value = "Regular Single Bed"},
                new DropDown {Text = "Regular Double Bed", Value = "Regular Double Bed"},
                new DropDown {Text = "Regular Twin Bed", Value = "Regular Twin Bed"},
                new DropDown {Text = "VIP Single Bed", Value = "VIP Single Bed"},
                new DropDown {Text = "VIP Double Bed", Value = "VIP Double Bed"},
                new DropDown {Text = "VIP Twin Bed", Value = "VIP Twin Bed"},
            };
        }
    }
}
