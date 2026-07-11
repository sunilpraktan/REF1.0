using System;

namespace Reflection.EF.Finance
{
    public partial class ACC_M003_H
    {
        public string acc_group { get; set; }
        public string group_desc { get; set; }
        public string comp_code { get; set; }
        public string acc_group_type { get; set; }
        public Nullable<bool> active { get; set; }
        public string client { get; set; }
        public string lang_key { get; set; }
        public System.DateTime add_date { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string location_Id { get; set; }
    }
}
