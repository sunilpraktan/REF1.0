using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Communication
{
    public partial class Task : ObjectBase
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public int folder_id { get; set; }
        public string task_desc { get; set; }
        public string tsk_priority { get; set; }
        public string est_time { get; set; }
        public System.DateTime start_date { get; set; }
        public string start_time { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
        public string end_time { get; set; }
        public string assign_by { get; set; }
        public string assign_to { get; set; }
        public string doc_type { get; set; }
        public Nullable<int> doc_id { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string doc_cat { get; set; }
        public Nullable<bool> completed { get; set; }
        public string comp_remark { get; set; }
        public Nullable<System.DateTime> close_date { get; set; }
        public string task_type { get; set; }
        public string task_freq { get; set; }
        public Nullable<int> day_freq { get; set; }
        public Nullable<int> freq_no { get; set; }
        public string trigger_time { get; set; }
        public string t_status { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string referring_party { get; set; }
        public string referring_partyNm { get; set; }
        public string designation { get; set; }
        public string EmailId { get; set; }
        public string duration { get; set; }
        public string stage_id { get; set; }
        public string cat_id { get; set; }
        public string section_id { get; set; }
        public string note { get; set; }
        public string lead_id { get; set; }
        public string lead_title { get; set; }
        public string sono { get; set; }
        public string contact_person { get; set; }
        public string person_number { get; set; }
        public string activity_type { get; set; }
        public string action_type { get; set; }
        public string act_summary { get; set; }
        public Nullable<System.DateTime> act_date { get; set; }
        public string act_time { get; set; }
        public string act_desc { get; set; }
        public string act_action { get; set; }
        public string parent_activity { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string place { get; set; }
        public string address { get; set; }
        public Nullable<bool> visiblity_user { get; set; }
        public string other_participants { get; set; }
        public string s_status { get; set; }
        public string AssignToUser { get; set; }
        public string assign_by_name { get; set; }
        public string folder_name { get; set; }
        public string color_code { get; set; }
        public Nullable<int> folderid { get; set; }
    }
}
