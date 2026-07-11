using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
   public class ADM_M001_J
    {
        public int id { get;set; }
        public string soff_code { get; set; }
        public string sg_code { get; set; }
        public Nullable<bool> active { get; set; }
        public string client { get; set; }
        public string lang_key { get; set; }

        //Scaler
        public string sg_name { get; set; }
        public string sales_off { get; set; }
    }
}
