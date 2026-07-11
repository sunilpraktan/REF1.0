using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessEntity
{
    public class PRICE_INDICATOR
    {
        public string ind_price { get; set; }
        public string ind_name { get; set; }
    }
    public enum ENUM_SORT_DIRECTION
    {
        ASC,
        DESC
    }
    public class ENUM_STD_LIST
    {
        public string enum_value { get; set; }
    }
    
}
