using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.SCM
{
    public partial class MM_M007 : ObjectBase
    {
        public int trnsID { get; set; }
        public string ItemCode { get; set; }
        public string sku { get; set; }
        public string batch_no { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public string TrnsType { get; set; }
        public string SourceLoc { get; set; }
        public string DestLoc { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string wa_code { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
    }

}
