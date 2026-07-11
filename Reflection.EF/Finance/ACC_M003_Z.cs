using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Finance
{
    public partial class ACC_M003_Z //Account Determination for Purchase	
    {
     
        public string client { get; set; }
        public string trans_scope { get; set; }
        public string con_type { get; set; }
        public string coa_key { get; set; }
        public string pg_code { get; set; }
        public string po_code { get; set; }
        public string party_acc_group { get; set; }
        public string item_acc_group { get; set; }
        public string trns_key_code { get; set; }
        public string gl_code_d { get; set; }
        public string gl_code_c { get; set; }
        public string item_cat { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string key_code { get; set; }
        public string key_sequence { get; set; }
        public int line_id { get; set; }
        public bool active { get; set; }
        //Scalar
        public bool Click { get; set; }
    }
}
