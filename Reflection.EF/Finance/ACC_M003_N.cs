using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Finance
{
    public partial class ACC_M003_N   //Pricing Procedure Master
    {
        public int id { get; set; }
        public string pricing_pro { get; set; }
        public string condition_type { get; set; }
        public string name { get; set; }
        public string trns_key_code { get; set; }
        public string key_value { get; set; }
        public string mod_group { get; set; }
        public string trans_scope { get; set; }
        public Nullable<int> step { get; set; }
        public string acc_pro { get; set; }

        //Scalar
        public string condition_desc { get; set; }
        public string trns_key_desc { get; set; }
        public bool Click { get; set; }
    }
}
