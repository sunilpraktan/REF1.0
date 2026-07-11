using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ADM_M009B : ObjectBase
    {
        public int SrNo { get; set; }
        public string RoleCode { get; set; }
        public string TranCode { get; set; }
        public string AuthFldCod { get; set; }
        public string LoctnCode { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string TranName { get; set; }
    }
}
