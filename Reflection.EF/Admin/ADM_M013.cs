using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ADM_M013 : ObjectBase
    {
        public string StatAbbre { get; set; }
        public string state_code { get; set; }
        public string StatName { get; set; }
        public string country_code { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string CntryName { get; set; }
    }
}
