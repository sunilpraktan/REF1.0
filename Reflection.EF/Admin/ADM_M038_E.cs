using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ADM_M038_E
    {
        public int id { get; set; }
        public string ItemCode { get; set; }
        public string dest_base_unit_code { get; set; }
        public string source_base_unit_code { get; set; }
        public decimal c_factor { get; set; }
        public Nullable<decimal> round_precision { get; set; }
        public string conv_type { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
        public string para1 { get; set; }
        public string para2 { get; set; }
        public string para3 { get; set; }
        public string client { get; set; }
    }
}
