using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Communication
{
    public partial class Approval : ObjectBase
    {
        public int srno { get; set; }
        public string id { get; set; }
        public string doc_type { get; set; }
        public string doc_no { get; set; }
        public string doc_cat { get; set; }
        public string workflow_id { get; set; }
        public string approver_id { get; set; }
        public string UserId { get; set; }
        public string authority { get; set; }
        public string appro_status { get; set; }
        public DateTime? appro_date { get; set; }
        public string read_status { get; set; }
        public DateTime? read_date { get; set; }
        public string remarks { get; set; }
        public string ref_id { get; set; }
        public string forward { get; set; }
        public int level_no { get; set; }
        public string creator { get; set; }
        public DateTime create_date { get; set; }
        public string add_by { get; set; }
        public DateTime add_date { get; set; }
        public string editby { get; set; }
        public DateTime? edit_date { get; set; }
        public string TranCode { get; set; }
        public string doc_desc { get; set; }
        public string ApproverName { get; set; }
        public string ApproverEmailId { get; set; }
        public string CreatorName { get; set; }
        public string CreatorEmailId { get; set; }
        public string note_subject { get; set; }
        public string note_messagebody { get; set; }
        public string approvar_remark { get; set; }
        public string sender { get; set; }
        public string record_src { get; set; }
        public string doc_info { get; set; }
        public string ReadyToUpdate { get; set; }
        public string UpdateInfo { get; set; }
        public string t_display { get; set; }
        public string UserName { get; set; }
        public DateTime? FrmDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string comp_code { get; set; }
        public string location_id { get; set; }

        public string obj_code { get; set; }
        public string obj_name { get; set; }
        public string party_code { get; set; }
        public string party_name { get; set; }
        public string order_no { get; set; }
        public string tl_code { get; set; }


        // NOTE: Approval Workflow Proposed Entity
        //public int srno { get; set; }
        //public string wf_code { get; set; }
        //public string auth_type { get; set; }
        //public string rec_status { get; set; }
        //public DateTime? act_date { get; set; }
        //public DateTime? read_date { get; set; }
        //public string comments { get; set; }
        //public string feedback { get; set; }
        //public int? level_no { get; set; }
        //public string creator { get; set; }
        //public string creator_name { get; set; }
        //public string creator_email { get; set; }
        //public string subject { get; set; } // Purposr of the notification can be set here, like user need approval action ot only for notification etc..
        //public string message { get; set; }
        //public string sender { get; set; }
        //public string ind_action { get; set; } // This will tell whether to action can take or not.
        //public string act_text { get; set; } // Rason for action indicator value.

    }
}
