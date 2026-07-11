using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.SCM
{
    public partial class ZSCM_T001_B : ObjectBase
    {
        public int id { get; set; }
        public int average_wt_id { get; set; }
        public Nullable<System.DateTime> entry_date { get; set; }
        public Nullable<int> wire_type_id { get; set; }
        public Nullable<int> make_id { get; set; }
        public Nullable<int> wire_size_id { get; set; }
        public Nullable<int> blank_len { get; set; }
        public Nullable<bool> active { get; set; }
        public Nullable<decimal> wt1 { get; set; }
        public Nullable<decimal> wt2 { get; set; }
        public Nullable<decimal> wt3 { get; set; }
        public Nullable<decimal> avg_blank_wt { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string finyr { get; set; }
        public string WireType { get; set; }
        public string Make { get; set; }
        public Nullable<decimal> WireDia { get; set; }
        public string BlankLength { get; set; }
    }
}
