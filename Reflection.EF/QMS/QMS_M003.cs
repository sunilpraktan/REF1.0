using System;

namespace Reflection.EF.QMS
{
    public partial class QMS_M003 : ObjectBase
    {
        public int id { get; set; }
        public string inst_code { get; set; }
        public string inst_name { get; set; }
        public string CatCode { get; set; }
        public string SubCatCode { get; set; }
        public string unit_code { get; set; }
        public string inst_make { get; set; }
        public string range { get; set; }
        public string maint_src { get; set; }
        public string rig_code { get; set; }
        public string cal_src { get; set; }
        public string cd_name { get; set; }
        public decimal? accuracy_up { get; set; }
        public decimal? least_cnt { get; set; }
        public decimal? calfreq { get; set; }
        public string calperiod { get; set; }
        public string cal_inst { get; set; }
        public string cal_cat { get; set; }
        public decimal? appr_cost { get; set; }
        public string tech_spec { get; set; }
        public DateTime? pur_date { get; set; }
        public string po_no { get; set; }
        public DateTime? po_date { get; set; }
        public string req_no { get; set; }
        public DateTime? req_date { get; set; }
        public string bdgt_type { get; set; }
        public string cal_rpt { get; set; }
        public string PartyId { get; set; }
        public string inv_no { get; set; }
        public DateTime? inv_date { get; set; }
        public string cal_agency { get; set; }
        public string barcode { get; set; }
        public string lab_code { get; set; }
        public string add_by { get; set; }
        public DateTime add_date { get; set; }
        public string editby { get; set; }
        public DateTime? edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public bool? active { get; set; }
        public string language { get; set; }
        public decimal? weight { get; set; }
        public string t_status { get; set; }
        public string inst_srno { get; set; }
        public string EmpId { get; set; }
        public string remark { get; set; }
        public string cal_status { get; set; }
        public DateTime cal_lastdate { get; set; }
        public DateTime? due_date { get; set; }
        public DateTime? next_date { get; set; }
        public bool sick_bit { get; set; }
        public string email { get; set; }
        public string model_no { get; set; }
        public decimal? upper_range { get; set; }
        public decimal? lower_range { get; set; }
        public string range_unit { get; set; }
        public string upper_range_unit { get; set; }
        public string lower_range_unit { get; set; }
        public string accuracy_up_unit { get; set; }
        public string resolution_unit { get; set; }
        public string least_count_unit { get; set; }
        public decimal? uncertainty { get; set; }
        public string uncertainty_unit { get; set; }

        public string lab_name { get; set; }
        public string CatName { get; set; }
        public string SubCatName { get; set; }
        public string rig_name { get; set; }
        public string PartyNm { get; set; }
        public DateTime? date_start { get; set; }
        public string cal_inst_name { get; set; }
        public string EmpName { get; set; }
        public string location { get; set; }
        public DateTime? warranty_date { get; set; }
        public string make_year { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string inst_id { get; set; }
        public string tr_code { get; set; }
        public decimal? resolution { get; set; }
        public string accuracy_down { get; set; }
        public string accuracy_down_unit { get; set; }
        //Scallar
        public string tr_name { get; set; }

        public string XmlDataDocument_QMS_M003_A { get; set; }
        public string XmlDataDocument_QMS_M003_B { get; set; }
        public string XmlDataDocument_QMS_M003FLIP { get; set; }

    }
    public partial class QMS_M003_A
    {
        public int id { get; set; }
        public string ItemScope { get; set; }
        public string ItemType { get; set; }
        public string inst_code { get; set; }
        public string add_by { get; set; }
        public DateTime add_date { get; set; }
        public string editby { get; set; }
        public DateTime? edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public bool? active { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string ItemCode { get; set; }
        //Scalar
        public string ItemName { get; set; }
    }
    public partial class QMS_M003_B
    {
        public int id { get; set; }
        public string inst_code { get; set; }
        public string para_code { get; set; }
        public string para_value { get; set; }
        public string unit_code { get; set; }
        public DateTime? valid_from { get; set; }
        public DateTime? valid_to { get; set; }
        public string add_by { get; set; }
        public DateTime add_date { get; set; }
        public string editby { get; set; }
        public DateTime? edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public bool? active { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string doc_no { get; set; }
        public string para_type { get; set; }
        public string value_code { get; set; }
        //Scalar
        public string para_name { get; set; }
    }
}
