using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessEntity.Production
{
    public class ECRM_T002_AFeedbackRpt
    {
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
        public Nullable<int> defect_id { get; set; }
        public string defect_description { get; set; }
        public Nullable<decimal> no_of_sample { get; set; }
        public string batch_no { get; set; }
        public string observation_test { get; set; }
        public string obsnqa { get; set; }
        public string result_of_test { get; set; }
        public string result_of_test_cust { get; set; }
    }
}
