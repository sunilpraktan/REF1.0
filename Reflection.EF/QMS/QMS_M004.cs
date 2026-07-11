using System;

namespace Reflection.EF.QMS
{
    public partial class QMS_M004 : ObjectBase
    {
        public int id { get; set; }
        public string acc_scope { get; set; }
        public string scope_desc { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public Nullable<bool> active { get; set; }
    }
}
