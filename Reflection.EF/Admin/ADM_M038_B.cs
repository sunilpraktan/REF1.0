using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ADM_M038_B
    {
        public int id { get; set; }
        public int class_id { get; set; }
        public string unit_code { get; set; }
        public string unit_abbrv { get; set; }
        public string unit_name { get; set; }
        public string unit_desc { get; set; }
        public Nullable<bool> is_base_unit { get; set; }
        public Nullable<bool> active { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public System.DateTime add_date { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
        public string class_name { get; set; }
        public string unit_symbol { get; set; }
        public string client { get; set; }
    }
}
