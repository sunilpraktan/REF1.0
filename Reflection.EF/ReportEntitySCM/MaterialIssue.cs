using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.SCM.ReportEntitySCM
{
   public class MaterialIssue
    {
        public string doc_no { get; set; }
        public Nullable<int> id { get; set; }
        public string comp_code { get; set; }
        public Nullable<System.DateTime> doc_edate { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public Nullable<int> doc_year { get; set; }
        public string trns_type { get; set; }
        public string ge_no { get; set; }
        public Nullable<System.DateTime> ge_date { get; set; }
        public string doc_code { get; set; }
        public string doc_cat { get; set; }
        public string source_doc_cat { get; set; }
        public string source_doc_type { get; set; }
        public string source_doc_no { get; set; }
        public string vendor { get; set; }
        public string PartyId { get; set; }
        public Nullable<System.DateTime> post_date { get; set; }
        public string bill_ladding { get; set; }
        public Nullable<System.DateTime> bill_ladding_dt { get; set; }
        public string grgi_slip_no { get; set; }
        public string del_note { get; set; }
        public Nullable<System.DateTime> del_note_date { get; set; }
        public Nullable<System.DateTime> receipt_date { get; set; }
        public string tranp_mode { get; set; }
        public string transport_party { get; set; }
        public Nullable<System.TimeSpan> entry_time { get; set; }
        public string ref_doc { get; set; }
        public string order_doc_type { get; set; }
        public string order_doc_no { get; set; }
        public Nullable<System.DateTime> ref_doc_date { get; set; }
        public string time_zone { get; set; }
        public string mov_tp { get; set; }
        public string EmpId { get; set; }
        public string dept_code { get; set; }
        public string notes { get; set; }
        public Nullable<bool> active { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public System.DateTime add_date { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
        public string t_status { get; set; }
        public string location_Id { get; set; }
        public string vehicle_no { get; set; }
        public string doc_type { get; set; }
        public string cash_credit_pur { get; set; }
        public string posting_period { get; set; }
        public string fin_year { get; set; }
        public string mov_name { get; set; }
        public string Req_Name { get; set; }
        public string Dept_Name { get; set; }
        public string tranp_agency_name { get; set; }
        public string PlantName { get; set; }
        public string vendor_name { get; set; }
        public string sending_plant { get; set; }
        public string rec_plant { get; set; }
        public string sendplantnm { get; set; }
        public string recplantnm { get; set; }
        public string doc_history_no { get; set; }
        public string pur_org { get; set; }
        public string pg_name { get; set; }
        public string po_code { get; set; }
        public string pg_code { get; set; }
        public string com_inv_no { get; set; }
        public Nullable<System.DateTime> From_Date { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public string Grade { get; set; }
        public Nullable<System.DateTime> ProdDate { get; set; }
        public string ink_id { get; set; }
        public string ink { get; set; }
        public string ild_id { get; set; }
        public string ild { get; set; }
        public string doc_format { get; set; }
    }
}
