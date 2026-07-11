using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.HRMS
{
    public partial class HRM_T001 : ObjectBase
    {
        public string requestid { get; set; }
        public string request_type { get; set; }
        public string sub_req_type { get; set; }
        public string obj_type { get; set; }
        public string sub_object { get; set; }
        public string reason_code { get; set; }
        public string sub_reason_code { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }  
        public Nullable<System.DateTime> doc_date { get; set; }
        public string reff_request_id { get; set; }
        public string descript { get; set; }
        public string note { get; set; }
        public string remark { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string lang_key { get; set; }
        public string EmpId { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }

        //Scalar Fields
        public string t_name { get; set; }
        public string sub_reason_type { get; set; }
        public string req_type_desc { get; set; }
        public string sub_req_desc{ get; set; }      
        public string reason_type { get; set; }
        public string doc_type_name { get; set; }
        public string cat_name { get; set; }
        public string obj_type_desc { get; set; }

        public string XmlDataDocument_HRM_T001_A { get; set; }
        public string XmlDataDocument_HRM_T001_Flip { get; set; }
    }
    public partial class HRM_T001_A
    {
        public int id { get; set; }
        public string requestid { get; set; }
        public string day_code { get; set; }
        public string leave_code { get; set; }
        public string no_of_days { get; set; }
        public string no_of_hours { get; set; }
        public string payroll_days { get; set; }
        public string payroll_hours { get; set; }
        public Nullable<System.DateTime> appl_date { get; set; }
        public Nullable<System.DateTime> date_from { get; set; }
        public Nullable<System.DateTime> date_to { get; set; }
        public string request_type { get; set; }
        public string sub_req_type { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
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
        public string EmpId { get; set; }

        //Scalar Fields
        public string request_name { get; set; }
        public string sub_req_name { get; set; }
        public string day_type { get; set; }
       
    }
    public partial class HRM_T001_B
    {
        public int id { get; set; }
        public string requestid { get; set; }
        public string request_type { get; set; }
        public System.DateTime date_from { get; set; }
        public System.DateTime date_to { get; set; }
        public string no_of_days { get; set; }
        public string type_of_attendance { get; set; }
        public System.DateTime start_date { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
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
    }
}
