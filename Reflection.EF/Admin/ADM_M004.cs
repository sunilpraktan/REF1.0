using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ADM_M004 : ObjectBase
    {
        public string activity_code { get; set; }
        public int ActivtCode { get; set; }
        public string AddInfo { get; set; }
        public string ActivtNm { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string activtNm { get; set; }
        public string lang_key { get; set; }
    }
}
