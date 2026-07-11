using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Production
{
    public partial class ZCRM_T003 : ObjectBase
    {
        public string doc_no { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public Nullable<System.DateTime> insp_date { get; set; }
        public string token_no { get; set; }
        public string batch_no { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string ItemCode { get; set; }
        public string sku { get; set; }
        public string sku_desc { get; set; }
        public string machinecode { get; set; }
        public string shift { get; set; }
        public string EmpId { get; set; }
        public Nullable<decimal> shank_dia_max { get; set; }
        public Nullable<decimal> shank_dia_min { get; set; }
        public Nullable<decimal> shank_champer_max { get; set; }
        public Nullable<decimal> shank_champer_min { get; set; }
        public Nullable<decimal> shank_length_max { get; set; }
        public Nullable<decimal> shank_length_min { get; set; }
        public Nullable<decimal> pin_needle_dia_max { get; set; }
        public Nullable<decimal> pin_needle_dia_min { get; set; }
        public Nullable<decimal> front_pin_dia_max { get; set; }
        public Nullable<decimal> front_pin_dia_min { get; set; }
        public Nullable<decimal> needle_length_max { get; set; }
        public Nullable<decimal> needle_length_min { get; set; }
        public Nullable<decimal> front_pin_len_max { get; set; }
        public Nullable<decimal> front_pin_len_min { get; set; }
        public Nullable<decimal> cone_len_max { get; set; }
        public Nullable<decimal> cone_len_min { get; set; }
        public Nullable<decimal> body_dia { get; set; }
        public string lock_prob { get; set; }
        public string surface_shin { get; set; }
        public string central_drill { get; set; }
        public string first_drill { get; set; }
        public string loose_ball { get; set; }
        public Nullable<decimal> finish_tip_ball_ht_max { get; set; }
        public Nullable<decimal> finish_tip_ball_ht_min { get; set; }
        public string in_out_profile { get; set; }
        public string tip_ball_spin { get; set; }
        public Nullable<decimal> finish_tip_len_max { get; set; }
        public Nullable<decimal> finish_tip_len_min { get; set; }
        public string t_status { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public DateTime? prod_dt { get; set; }
        public string conversion_no { get; set; }
        public string unit_code { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string EmpName { get; set; }
        public string ItemName { get; set; }
        public Nullable<decimal> pin_length_min { get; set; }
        public Nullable<decimal> pin_length_max { get; set; }
        public string barcode { get; set; }
        public string ref_doc_type { get; set; }
        public string ref_Doc_TypeNm { get; set; }
        public string RefDocNo { get; set; }
        public decimal? ball_gripping_force_min { get; set; }
        public decimal? ball_gripping_force_max { get; set; }
        public string remark { get; set; }
        public string qc_person { get; set; }
        public string QcName { get; set; }
        public string remark1 { get; set; }
        public string remark2 { get; set; }
        public decimal? pin_dia_min { get; set; }
        public decimal? pin_dia_max { get; set; }
        public decimal? wt1no_of_pieces { get; set; }
        public decimal? wt2no_of_pieces { get; set; }
        public string wt1decision { get; set; }
        public string wt2decision { get; set; }
        public string wt1remark { get; set; }
        public string wt2remark { get; set; }
        public bool life_test { get; set; }
        public string decision { get; set; }
        public decimal? no_of_pages { get; set; }
        public string ltremark { get; set; }
        public string EmpId1 { get; set; }
        public string qc_person1 { get; set; }
        public System.DateTime? Fromdt { get; set; }
        public System.DateTime? Todt { get; set; }
        public string sshift { get; set; }
        public string con_no { get; set; }
        public string item { get; set; }
        public string machine { get; set; }
        public Nullable<decimal> check_qty { get; set; }
        public string t_display { get; set; }
        public string wc_code { get; set; }
        public string grade { get; set; }
        public decimal? counter_qty { get; set; }
        public string counter_remark { get; set; }
    }

    public partial class ZCRM_T003_A
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public string defect { get; set; }
        public string DefectNm { get; set; }
        public string parameters { get; set; }
        public string parameterNm { get; set; }
        public string observation { get; set; }
        public Nullable<decimal> defect_qty { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string client { get; set; }
        public string lang_key { get; set; }
        public string t_status { get; set; }
        public string remark { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public Nullable<bool> active { get; set; }
        public string defect_source { get; set; }
    }

}
