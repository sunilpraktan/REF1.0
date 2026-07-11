using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ADM_M003_C
    {
        public int id { get; set; }
        public string buss_place { get; set; }
        public string plc_name { get; set; }
        public string plc_desc { get; set; }
        public string state_tax_code { get; set; }
        public string state_code { get; set; }
        public string country_code { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string edit_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string client { get; set; }
        public string lang_key { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        //Scalar
        public bool Click { get; set; }
    }
}
