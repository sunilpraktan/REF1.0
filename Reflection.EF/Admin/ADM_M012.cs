using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ADM_M012 : ObjectBase
    {
        public string country_code { get; set; }
        public int CntryCode { get; set; }
        public string CntryName { get; set; }
        public string CntryAbbre { get; set; }
        public string CntryCurncy { get; set; }
        public byte[] CntryFlag { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
    }
}
