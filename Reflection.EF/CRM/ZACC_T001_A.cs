using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.CRM
{
    public partial class ZACC_T001_A : ObjectBase
    {
        public string client { get; set; }
        public string comp_code { get; set; }
        public int id { get; set; }
        public string wiresz { get; set; }
        public string wiretp { get; set; }
        public string balltp { get; set; }
        public string tiplen { get; set; }
        public string unit { get; set; }
        public Nullable<decimal> gart { get; set; }
        public Nullable<decimal> gbrt { get; set; }
        public Nullable<decimal> gcrt { get; set; }
        public string mon { get; set; }
        public string yr { get; set; }
        public string editby { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
    }
}
