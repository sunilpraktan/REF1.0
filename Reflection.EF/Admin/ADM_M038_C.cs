using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ADM_M038_C
    {
        public int id { get; set; }
        public string unit_code { get; set; }
        public string base_unit_code { get; set; }
        public Nullable<decimal> c_factor { get; set; }
        public Nullable<decimal> round_precision { get; set; }
        public string conv_type { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
        public string base_unit { get; set; }
        public string class_name { get; set; }
        public string para1 { get; set; }
        public string para2 { get; set; }
        public string para3 { get; set; }
        public string client { get; set; }
    }
}
