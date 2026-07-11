using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Finance
{
    public partial class ACC_M003_W //Transaction Key Value String
    {
        public string key_value { get; set; }
        public string key_value_desc { get; set; }
        public string trns_key_code { get; set; }
        public string t_field1 { get; set; }
        public string t_field2 { get; set; }
        public string t_field3 { get; set; }
        public Nullable<bool> all_zero { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string module { get; set; }
    }
}
