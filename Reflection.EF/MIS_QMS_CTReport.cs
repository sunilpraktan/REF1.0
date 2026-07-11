using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF
{
    public class MIS_QMS_CTReport
    {
        public string doc_no { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string lab_code { get; set; }
        public string barcode { get; set; }
        public string test_code { get; set; }
        public string ref_doc_no { get; set; }
        public string rig_code { get; set; }
        public string tr_code { get; set; }
        public string temperature { get; set; }
        public string humidity { get; set; }
        public string remark1 { get; set; }
        public string remark2 { get; set; }
        public string remark3 { get; set; }
        public string master_inst { get; set; }
        public string EmpId { get; set; }
        public string cal_type { get; set; }
        public string po_no { get; set; }
        public string PartyId { get; set; }
        public int ContInfoId { get; set; }
        public DateTime? cal_date { get; set; }
        public DateTime? last_date { get; set; }
        public int cal_freq { get; set; }
        public string cal_period { get; set; }
        public DateTime? next_date { get; set; }
        public string u_remark1 { get; set; }
        public string u_remark2 { get; set; }
        public string u_remark3 { get; set; }
        public bool? active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public DateTime add_date { get; set; }
        public string editby { get; set; }
        public DateTime? edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string client { get; set; }
        public string lang_key { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string start_temp { get; set; }
        public string end_temp { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        public DateTime? doc_date { get; set; }
        public DateTime? due_date { get; set; }
        public string PartyNm { get; set; }
        public string inst_code { get; set; }
        public string inst_name { get; set; }
        public string serv_type { get; set; }
        public string insp_lot_no { get; set; }
        public string resolution { get; set; }
        public string middle_temp { get; set; }
        //Scalar
        public string test_name { get; set; }
        public string inst_id { get; set; }
        public string inst_make { get; set; }
        public string inst_srno { get; set; }
        public string model_no { get; set; }
        public string least_count { get; set; }
        public string range { get; set; }
        public string accuracy { get; set; }
        public string cont_per_name { get; set; }
        public string EmpNm { get; set; }
        public string tr_name { get; set; }
        public string rig_name { get; set; }
        public string lab_name { get; set; }
        public string to_mail_id { get; set; }
        public string inst_cond { get; set; }
        public string approvernm { get; set; }
        public string cust_name { get; set; }
    }
}
