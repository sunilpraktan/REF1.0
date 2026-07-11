using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ZADM_M008 : ObjectBase
    {
        public int tot_len_id { get; set; }
        public string total_len { get; set; }
        public string total_len_tolce_plus { get; set; }
        public string total_len_tolce_mins { get; set; }
        public string details { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string edit_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
    }
}
