using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ADM_M001_K
    {
        public string so_code { get; set; }
        public int id { get; set; }
        public string comp_code { get; set; }
        public Nullable<bool> active { get; set; }
        public string client { get; set; }
        public string lang_key { get; set; }
        public string dc_code { get; set; }
        public string div_code { get; set; }

        //Scaler
        public string CompName { get; set; }
        public string sales_org { get; set; }
        public string dc_name { get; set; }
        public string div_name { get; set; }


    }
}
