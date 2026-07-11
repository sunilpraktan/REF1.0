using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ADM_M001_I
    {
        public string soff_code { get; set; }
        public int id { get; set; }
        public string sales_off { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string state_code { get; set; }
        public string country_code { get; set; }
        public string pin { get; set; }
        public string lang { get; set; }
        public string phone { get; set; }
        public string ph_ext { get; set; }
        public string fax { get; set; }
        public string fax_ext { get; set; }
        public string email { get; set; }
        public string notes { get; set; }
        public string comp_code { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string client { get; set; }
        public string lang_key { get; set; }

        //Scaler

        public string CntryName { get; set; }
        public string StatName { get; set; }

      
    }
}
