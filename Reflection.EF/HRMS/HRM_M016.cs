using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.HRMS
{
    public partial class HRM_M016 : ObjectBase
    {
        public string equ_id { get; set; }
        public string equ_name { get; set; }
        public string dev_code { get; set; }
        public string dev_serial_no { get; set; }
        public string t_status { get; set; }
        public string ItemCode { get; set; }
        public string boud_rate { get; set; }
        public string tcp_ip { get; set; }
        public string mac_add { get; set; }
        public string port { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string lang_key { get; set; }
        public string remark { get; set; }
        public string t_name { get; set; }

        public string XmlDataDocument_HRM_M016_A { get; set; }
        public string XmlDataDocument_HRM_M016_Flip { get; set; }
    }
    public partial class HRM_M016_A
    {
        public int id { get; set; }
        public string equ_id { get; set; }
        public string control_code { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string lang_key { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string remark { get; set; }
        public string control_desc { get; set; }
    }
  
}
