using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ADM_M027 : ObjectBase
    {
        public int ContInfoId { get; set; }
        public string PartyId { get; set; }
        public string Location { get; set; }
        public string PersnFName { get; set; }
        public string PersnMName { get; set; }
        public string PersnLName { get; set; }
        public string dept_code { get; set; }
        public string desig_code { get; set; }
        public Nullable<int> Age { get; set; }
        public string Gender { get; set; }
        public string PersnMobNo { get; set; }
        public string PersnPhNo { get; set; }
        public string PersnPhExt { get; set; }
        public string PersnFaxNo { get; set; }
        public string PersnEmailId { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string title { get; set; }
        public Nullable<bool> default_del { get; set; }
        public Nullable<bool> default_bil { get; set; }
        public string PartyNm { get; set; }
        public string DeptName { get; set; }
        public string DesigName { get; set; }
    }

}
