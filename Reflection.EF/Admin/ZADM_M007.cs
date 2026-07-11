using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ZADM_M007 : ObjectBase
    {
        public int ild_id { get; set; }
        public string ild { get; set; }
        public string ild_type { get; set; }
        public string tip_type { get; set; }
        public Nullable<decimal> min_val { get; set; }
        public Nullable<decimal> max_val { get; set; }
        public Nullable<decimal> avg_max { get; set; }
        public Nullable<decimal> avg_min { get; set; }
        public string desc { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
        public string show_ild { get; set; }
    }
}
