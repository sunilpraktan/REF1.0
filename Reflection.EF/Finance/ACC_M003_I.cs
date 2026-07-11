using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Finance
{
    public partial class ACC_M003_I
    {
        public string client { get; set; }        
        public string trns_key_code { get; set; }
        public string dr_key { get; set; }
        public string cr_key { get; set; }
        public string sp_gl_ind { get; set; }
        public string posting_desc_D { get; set; }
        public string posting_desc_C { get; set; }
    }
}
