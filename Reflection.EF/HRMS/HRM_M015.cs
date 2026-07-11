using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.HRMS
{
    public partial class HRM_M015 : ObjectBase
    {
        public string ter_id { get; set; }
        public string ter_desc { get; set; }
        public string ter_shrt_nm { get; set; }
        public string ter_location { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string lang_key { get; set; }
        public string remark { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string XmlDataDocument_HRM_M015_A { get; set; }
        public string XmlDataDocument_HRM_M015_Flip { get; set; }

        //Scaller
        public string t_name { get; set; }
    }
    public partial class HRM_M015_A
    {
        public int id { get; set; }
        public string ter_id { get; set; }
        public string equ_id { get; set; }
        public string ind_inout { get; set; }
        public string t_status { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string lang_key { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string remark { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string client { get; set; }
        public string t_name { get; set; }
    }
}
