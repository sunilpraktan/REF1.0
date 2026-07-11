using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Finance
{
    public partial class ACC_M003_F
    {
        public string client { get; set; }
        public string coa_key { get; set; }
        public string mod_group { get; set; }
        public string trns_key_code { get; set; }
        public Nullable<bool> acc_var { get; set; }
        public Nullable<bool> value_group { get; set; }
        public Nullable<bool> value_class { get; set; }
        public Nullable<bool> drcr { get; set; }
        public Nullable<bool> tax_code { get; set; }
        public Nullable<bool> buss_place { get; set; }
    }        
}
