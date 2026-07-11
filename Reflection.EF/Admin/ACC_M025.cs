using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ACC_M025 : ObjectBase
    {
        public string comp_code { get; set; }
        public string country_code { get; set; }
        public bool active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string wtax_code { get; set; }
        public string wtax_ncode { get; set; }
        public string wtax_key { get; set; }
        public string ind_wtax_type { get; set; }
        public decimal wtax_per { get; set; }
        public decimal wtax_rate { get; set; }
        public string lang_key { get; set; }
        public string _location_Id { get; set;}

        //scalar 
        public string CntryName { get; set; }
        public bool Click { get; set; }
        public string _wtax_type { get; set; }
    }
}
