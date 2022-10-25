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
                new DropDown {Text = "Regular Single Bed", Value = "Reg-SB"},
                new DropDown {Text = "Regular Double Bed", Value = "Reg-DB"},
                new DropDown {Text = "Regular Twin Bed", Value = "Reg-TB"},
                new DropDown {Text = "VIP Single Bed", Value = "VIP-SB"},
                new DropDown {Text = "VIP Double Bed", Value = "VIP-DB"},
                new DropDown {Text = "VIP Twin Bed", Value = "VIP-TB"},
            };
        }
        public static IEnumerable<DropDown> ListStatusAccount()
        {
            return new List<DropDown>
            {
                new DropDown {Text = "Select Status", Value = null},
                new DropDown {Text = "Active", Value = "A"},
                new DropDown {Text = "Non-Active", Value = "N"},
                new DropDown {Text = "Blocked", Value = "B"},
            };
        }
    }
}
