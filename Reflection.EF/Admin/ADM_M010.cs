using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ADM_M010 : ObjectBase
    {
        public int id { get; set; }
        public string UserId { get; set; }
        public Nullable<int> UserTypCode { get; set; }
        public string Password { get; set; }
        public string user_type { get; set; }
        public string Title { get; set; }
        public string EmpId { get; set; }
        public Nullable<bool> LogSts { get; set; }
        public Nullable<System.DateTime> ValidFrm { get; set; }
        public Nullable<System.DateTime> ValidTo { get; set; }
        public Nullable<bool> UserBlkSts { get; set; }
        public Nullable<bool> LockStat { get; set; }
        public string LockBy { get; set; }
        public Nullable<System.DateTime> LockDate { get; set; }
        public string UnlockBy { get; set; }
        public Nullable<System.DateTime> UnlockDate { get; set; }
        public byte[] Photo { get; set; }
        public Nullable<bool> active { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string add_by { get; set; }
        public string EmpNm { get; set; }
        public string UserTyp { get; set; }
        public string comp_code { get; set; }
        public string lang_key { get; set; }
        public string CompName { get; set; }
        public string dept_code { get; set; }
        public byte[] digi_sign { get; set; }
        public string user_level { get; set; }
        public string user_type_name { get; set; }

    }
}
