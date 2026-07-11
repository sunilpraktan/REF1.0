using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.SCM
{
    public partial class GEN_T009 : ObjectBase
    {
        public string doc_no { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string trans_type { get; set; }
        public string trans_sub_type { get; set; }
        public string way_bill_no { get; set; }
        public Nullable<System.DateTime> way_bill_date { get; set; }
        public System.TimeSpan wb_time { get; set; }
        public string ref_doc_no { get; set; }
        public string ref_doc_cat { get; set; }
        public string ref_doc_type { get; set; }
        public string distance { get; set; }
        public Nullable<System.DateTime> validity_from { get; set; }
        public Nullable<System.DateTime> validity_to { get; set; }
        public string t_status { get; set; }
        public Nullable<System.DateTime> rec_date { get; set; }
        public string ref_way_bill_no { get; set; }
        public string mode_of_gen { get; set; }
        public Nullable<bool> active { get; set; }
        public System.DateTime add_date { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
        public string lang_key { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }

        //Scaller
        public string t_name { get; set; }

    }
}
