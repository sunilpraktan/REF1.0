using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.HRMS
{
    public partial class HRM_M001 : ObjectBase
    {
        public string EmpId { get; set; }
        public string sal_code { get; set; }
        public string alias_name { get; set; }
        public Nullable<System.DateTime> emp_dob { get; set; }
        public string emp_pob { get; set; }
        public string emp_cob { get; set; }
        public string reli_code { get; set; }
        public string cast_code { get; set; }
        public string cat_code { get; set; }
        public string gender { get; set; }
        public string blood_group { get; set; }
        public Nullable<System.DateTime> emp_dom { get; set; }
        public string marital_status { get; set; }
        public string nation_code { get; set; }
        public string nation_code1 { get; set; }
        public string phy_dis { get; set; }
        public string height_val { get; set; }
        public string height_unit { get; set; }
        public string weight_val { get; set; }
        public string weight_unit { get; set; }
        public Nullable<System.DateTime> join_date { get; set; }
        public string applicant_id { get; set; }
        public byte[] emp_photo { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string lang_key { get; set; }
        public string remark { get; set; }
    }
    public partial class HRM_M001_A   //Nominee Details
    {
        public int id { get; set; }
        public string EmpId { get; set; }
        public string f_name { get; set; }
        public string m_name { get; set; }
        public string l_name { get; set; }
        public string occupation { get; set; }
        public Nullable<System.DateTime> dob { get; set; }
        public byte[] nom_photo { get; set; }
        public string rele_code { get; set; }
        public string prof_code { get; set; }
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
    }
    public partial class HRM_M001_B  //Family Details
    {
        public int id { get; set; }
        public string EmpId { get; set; }
        public string no_of_mem { get; set; }
        public string f_name { get; set; }
        public string m_name { get; set; }
        public string l_name { get; set; }
        public Nullable<System.DateTime> dob { get; set; }
        public byte[] photo { get; set; }
        public bool ind_dep { get; set; }
        public string rele_code { get; set; }
        public string doc_code { get; set; }
        public string prof_code { get; set; }
        public string prof_details { get; set; }
        public string prof_org { get; set; }
        public string desig_code { get; set; }
        public Nullable<System.DateTime> doj { get; set; }
        public string income { get; set; }
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
    }
    public partial class HRM_M001_C  //Employment(Experience)  Details
    {
        public string employment_id { get; set; }
        public string EmpId { get; set; }
        public string com_name { get; set; }
        public Nullable<System.DateTime> doj { get; set; }
        public Nullable<System.DateTime> leave_date { get; set; }
        public string st_desg { get; set; }
        public string lt_desg { get; set; }
        public string resion_code { get; set; }
        public string resign_desc { get; set; }
        public string ctc { get; set; }
        public string job_pro { get; set; }
        public string fun_area { get; set; }
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
    }
    
    public partial class HRM_M001_E  //Hobbies Details
    {
        public string EmpId { get; set; }
        public string hobby_code { get; set; }
        public string hobby_desc { get; set; }
        public string achive { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string lang_key1 { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string remark { get; set; }
    }
    public partial class HRM_M001_F  //Refference Master Details
    {
        public string EmpId { get; set; }
        public string reff_name { get; set; }
        public string reff_occ { get; set; }
        public string rele_code { get; set; }
        public string reff_ind { get; set; }
        public string prof_code { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string lang_key1 { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string remark { get; set; }
    }
    public partial class HRM_M001_G  //Criminal Record Details
    {
        public int id { get; set; }
        public string EmpId { get; set; }
        public string ind_off_type { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string crime_desc { get; set; }
        public string penelty { get; set; }
        public string action { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string lang_key1 { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string remark { get; set; }
    }
    public partial class HRM_M001_H  //Employment Details (History)
    {
        public string EmpId { get; set; }
        public string empl_type { get; set; }
        public Nullable<System.DateTime> empl_from { get; set; }
        public Nullable<System.DateTime> empl_to { get; set; }
        public Nullable<System.DateTime> due_date { get; set; }
        public string key_area { get; set; }
        public string fun_area { get; set; }
        public string desig_code { get; set; }
        public string dept_code { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string lang_key1 { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string remark { get; set; }
    }
    public partial class HRM_M001_I  //Additional Activities Details
    {
        public string EmpId { get; set; }
        public string title { get; set; }
        public Nullable<System.DateTime> from_date { get; set; }
        public Nullable<System.DateTime> to_date { get; set; }
        public string Description { get; set; }
        public string act_type { get; set; }
        public string asub_type { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string lang_key1 { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string remark { get; set; }
    }
    public partial class HRM_M001_J  //Current Skill Details
    {
        public string skill_id { get; set; }
        public string EmpId { get; set; }
        public string skill_code { get; set; }
        public string skill_type { get; set; }
        public Nullable<System.DateTime> updated { get; set; }
        public string skill_desc { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string lang_key1 { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string remark { get; set; }
    }
    public partial class HRM_M001_K  //Tag Details
    {
        public string parentId { get; set; }
        public string tag_code { get; set; }
        public string EmpId { get; set; }
        public Nullable<System.DateTime> issue_date { get; set; }
        public Nullable<System.DateTime> effective_date { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string lang_key1 { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string remark { get; set; }
    }
}