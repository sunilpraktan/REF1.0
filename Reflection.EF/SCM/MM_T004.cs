using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.SCM
{
    public partial class MM_T004 : ObjectBase
    {
        public string doc_no { get; set; }
        public string doc_cat { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string EmpId { get; set; }
        public string EmpNm { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string unit_code { get; set; }
        public string unit_name { get; set; }
        public int? ContInfoId { get; set; }
        public string address { get; set; }
        public string phone_no { get; set; }
        public DateTime? entry_date { get; set; }
        public string entry_time { get; set; }
        public string in_time { get; set; }
        public string out_time { get; set; }
        public decimal? qty { get; set; }
        public string dept_code { get; set; }
        public string vehicle_no { get; set; }
        public string note { get; set; }
        public string remark { get; set; }
        public string order_no { get; set; }
        public DateTime? order_date { get; set; }
        public string challan_no { get; set; }
        public DateTime? challan_date { get; set; }
        public string bill_no { get; set; }
        public DateTime? bill_date { get; set; }
        public string grn_no { get; set; }
        public string service_provider_id { get; set; }
        public string service_provider_nm { get; set; }
        public string gate_pass_no { get; set; }
        public string issued_by_id { get; set; }
        public string issued_by_nm { get; set; }
        public string issued_to_id { get; set; }
        public string issued_to_nm { get; set; }
        public DateTime? return_date { get; set; }
        public string authorised_by { get; set; }
        public string prepared_by { get; set; }
        public string received_by { get; set; }
        public string security_person { get; set; }
        public string driverNm { get; set; }
        public string duration { get; set; }
        public string reading_out { get; set; }
        public string reading_in { get; set; }
        public string distance { get; set; }
        public string place { get; set; }
        public string gate_no { get; set; }
        public string person_to_be_visited_id { get; set; }
        public string person_to_be_visited_nm { get; set; }
        public string no_of_person { get; set; }
        public string lrno { get; set; }
        public DateTime? lrdate { get; set; }
        public string add_by { get; set; }
        public DateTime? add_date { get; set; }
        public string editby { get; set; }
        public DateTime? edit_date { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string batch_no { get; set; }
        public decimal? weight { get; set; }
        public string pod_no { get; set; }
        public string description { get; set; }
        public string purpose { get; set; }
        public string t_status { get; set; }
        public bool? active { get; set; }
        public string doc_type { get; set; }
        public string doc_type_name { get; set; }
        public string del_note_no { get; set; }
        public DateTime? del_note_date { get; set; }
        public DateTime? date_of_receipt { get; set; }
        public DateTime? posting_date { get; set; }
        public string trans_mode { get; set; }
        public string dept_Nm { get; set; }
        public string location { get; set; }
        public string material_order_for { get; set; }
        public string prepared_by_nm { get; set; }
        public string t_display { get; set; }
    }
}
