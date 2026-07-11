using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.SCM
{
    public partial class ZSCM_T001_A : ObjectBase
    {
        public int id { get; set; }
        public string average_wt_no { get; set; }
        public Nullable<System.DateTime> average_wt_dt { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string finyr { get; set; }
        public string ReportCode { get; set; }
        public string comp_code { get; set; }
    }
}
