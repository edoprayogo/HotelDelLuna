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
        
    }
}
