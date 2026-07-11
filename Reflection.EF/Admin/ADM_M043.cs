using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ADM_M043 : ObjectBase
    {
        public string workflow_id { get; set; }
        public string doc_type { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string transaction_id { get; set; }
        public Nullable<System.DateTime> create_date { get; set; }
        public bool active { get; set; }
        public string remark { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string doc_cat { get; set; }
        public string LoctnNm { get; set; }
        public string CompName { get; set; }
        public string TranName { get; set; }
        public string ref_doc_cat { get; set; }
        public string ref_doc_type { get; set; }
        public string lang_key { get; set; }
    }
}
