using System;

namespace Reflection.EF.QMS
{
    public partial class QMS_M024 : ObjectBase
    {
        public string tl_code { get; set; }
        public string tl_type { get; set; }
        public string tl_key { get; set; }
        public string long_text { get; set; }
        public string short_text { get; set; }
        public DateTime? valid_from_date { get; set; }
        public string tech_status_from { get; set; }
        public string tl_usage { get; set; }
        public string unit_code { get; set; }
        public decimal? from_lot_size { get; set; }
        public decimal? to_lot_size { get; set; }
        public string EmpId { get; set; }
        public DateTime? last_call_date { get; set; }
        public decimal? number_of_calls { get; set; }
        public string sel_set_usage_decision { get; set; }
        public DateTime? usage_decision_date { get; set; }
        public string sample_drawing_proc { get; set; }
        public string insp_point { get; set; }
        public string maint_strategy { get; set; }
        public string maint_package_pool { get; set; }
        public string maint_location_Id { get; set; }
        public string sys_condition { get; set; }
        public string lab_code { get; set; }
        public string insp_lot_no { get; set; }
        public string ind_deletion { get; set; }
        public string obj_type { get; set; }
        public string setup_recipe { get; set; }
        public string clean_out_recipe { get; set; }
        public DateTime? archieve_date { get; set; }
        public string obj_id { get; set; }
        public string ind_submission { get; set; }
        public int? routing_no { get; set; }
        public decimal? base_qty { get; set; }
        public bool? active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public DateTime add_date { get; set; }
        public string edit_by { get; set; }
        public DateTime? edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string lang_key { get; set; }

        public string XmlDataDocument_FlipGrid { get; set; }
    }
}
