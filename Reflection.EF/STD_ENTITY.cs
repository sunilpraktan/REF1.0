using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF
{
    // Generic standard business entity class. useful for multiple transactions
    public class STD_BE_A : ObjectBase 
    {
        public string group_code { get; set; } 
        public string ctry_code { get; set; } 
        public string hsn_code { get; set; }
        public string short_text { get; set; }
        public string comp_code { get; set; } 
        public string group_cat { get; set; } 
        public string cat_name { get; set; }
        public string group_name { get; set; }
        public string active { get; set; }
        public bool? selected { get; set; }

        public string obj_type { get; set; }
        public string obj_name { get; set; }
        public string obj_group { get; set; }
        public string equip_cat { get; set; }
        public string fun_loc { get; set; }
    }
}
