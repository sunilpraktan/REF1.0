using System;

namespace Reflection.EF.QMS
{
    public partial class QMS_M005 : ObjectBase
    {
        public string error_code { get; set; }
        public string test_code { get; set; }
        public string test_type_code { get; set; }
        public int column_id { get; set; }
        public Nullable<decimal> l_value { get; set; }
        public Nullable<decimal> h_value { get; set; }
        public Nullable<decimal> m_value { get; set; }
        public string l_remark { get; set; }
        public string h_remark { get; set; }
        public string m_remark { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string lang_key { get; set; }
    }
}
