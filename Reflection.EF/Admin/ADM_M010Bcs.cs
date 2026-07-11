using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ADM_M010B
    {
        public int SrNo { get; set; }
        public string UserId { get; set; }
        public string RoleCode { get; set; }
        public string ValdtTyp { get; set; }
        public Nullable<System.DateTime> ValidFrm { get; set; }
        public Nullable<System.DateTime> ValidTo { get; set; }
        public Nullable<bool> active { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string add_by { get; set; }
        public string RoleName { get; set; }
    }
}
