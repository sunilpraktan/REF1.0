using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.CRM
{
    public partial class ECRM_T002_A : ObjectBase
    {
        public string client { get; set; }
        public int id { get; set; }
        public string quality_feedback_no { get; set; }
        public Nullable<System.DateTime> quality_feedback_date { get; set; }
        public string party_ref_no { get; set; }
        public Nullable<System.DateTime> party_ref_date { get; set; }
        public Nullable<int> model_id { get; set; }
        public string product_name { get; set; }
        public string PartyId { get; set; }
        public int ild_id { get; set; }
        public int ink_id { get; set; }
        public string ild { get; set; }
        public string ink { get; set; }
        public string ink_details { get; set; }
        public Nullable<decimal> invoice_qty { get; set; }
        public Nullable<decimal> defected_qty { get; set; }
        public string note { get; set; }
        public Nullable<bool> rtqfr { get; set; }
        public string rtqfr_no { get; set; }
        public Nullable<System.DateTime> rtqfr_date { get; set; }
        public Nullable<bool> quality_feedback_flg { get; set; }
        public Nullable<System.DateTime> rtqfradddt { get; set; }
        public string rtqfreditby { get; set; }
        public string EmpId { get; set; }
        public Nullable<System.DateTime> rtqfreditdt { get; set; }
        public string test_procedure { get; set; }
        public string test_procedure_result { get; set; }
        public string conclusion { get; set; }
        public string invno { get; set; }
        public Nullable<System.DateTime> invdt { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string cmplnt_RecvBy_cd { get; set; }
        public string cmplnt_HandlBy_cd { get; set; }
        public Nullable<decimal> sampl_qty { get; set; }
        public string sampl_mark { get; set; }
        public string sampl_nm { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string ModelNm { get; set; }
        public string LoctnNm { get; set; }
        public string t_status { get; set; }
        public string sample_status { get; set; }
        public string ItemCode { get; set; }
        public string corrective { get; set; }
        public string verification_effect { get; set; }
        public string suggestion { get; set; }
        public string PartyNm { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string cmplnt_HandlBy_Name { get; set; }
        public string cmplnt_RecvBy_Name { get; set; }
        public string imp_note { get; set; }
        public string material { get; set; }
        public string cust_complaint { get; set; }
        public string cust_req { get; set; }
        public string so_code { get; set; }
        public string sg_code { get; set; }
        public string sales_org { get; set; }
        public string sg_name { get; set; }
        public string report_type { get; set; }
        public string unit_inv_qty { get; set; }
        public string unit_defect_qty { get; set; }
        public int cust_ink_id { get; set; }
        public string cust_ink { get; set; }
        public string prepaper_name { get; set; }
        public string approver_name { get; set; }
        public string causes { get; set; }
        public string observation { get; set; }
        public string pre_tech_dir { get; set; }
        public string pre_unit_head { get; set; }
        public string pre_QS { get; set; }
        public string pre_others { get; set; }
        public string corrective_tech_dir { get; set; }
        public string corrective_unit_head { get; set; }
        public string corrective_QS { get; set; }
        public string corrective_others { get; set; }
        public string con_tech_dir { get; set; }
        public string con_unit_head { get; set; }
        public string con_QS { get; set; }
        public string con_others { get; set; }
        public string doc_name { get; set; }
        public string no_of_days { get; set; }
        public string batch_no { get; set; }
        public string pmceo { get; set; }
        public Nullable<System.DateTime> start_date1 { get; set; }
        public Nullable<System.DateTime> End_date { get; set; }
        public string match_to_tds { get; set; }
        public string comment1 { get; set; }
        public string comment2 { get; set; }
        public string audit1 { get; set; }
        public string audit2 { get; set; }
        public string audit3 { get; set; }

    }

    public partial class ECRM_T002_B
    {
        public int id { get; set; }
        public string quality_feedback_no { get; set; }
        public Nullable<int> defect_id { get; set; }
        public string defect_description { get; set; }
        public Nullable<decimal> no_of_sample { get; set; }
        public string batch_no { get; set; }
        public string observation_test { get; set; }
        public string obsnqa { get; set; }
        public string result_of_test { get; set; }
        public string result_of_test_cust { get; set; }
        public string causes { get; set; }
        public string preven_actions { get; set; }
        public string observation { get; set; }
        public string conclusion { get; set; }
        public string in_house_rep { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public Nullable<bool> active { get; set; }
        public Nullable<bool> active1 { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string material { get; set; }
        public Nullable<System.DateTime> sam_rec_date { get; set; }
        public string specification { get; set; }

        public string ink { get; set; }

        public string adapter { get; set; }

        public string con_sam { get; set; }
    }

    public partial class ECRM_T002_C
    {
        public int id { get; set; }
        public string quality_feedback_no { get; set; }
        public string test_name { get; set; }
        public string test_id { get; set; }
        public string result { get; set; }
        public string comp_code { get; set; }
        public string client { get; set; }
        public string location_Id { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
    }

}
