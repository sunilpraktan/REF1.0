using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ADM_M041 : ObjectBase
    {
        public int id { get; set; }
        public string lic_cod { get; set; }
        public string lic_type { get; set; }
        public string lic_desc { get; set; }
        public DateTime? issue_date { get; set; }
        public DateTime? export_expiry_date { get; set; }
        public DateTime? export_expiry_date1 { get; set; }
        public DateTime? import_expiry_date { get; set; }
        public DateTime? import_expiry_date1 { get; set; }
        public string sion_no { get; set; }
        public string registration_port { get; set; }
        public string file_no { get; set; }
        public string bgb_no { get; set; }
        public decimal? bgb_amt { get; set; }
        public DateTime? bgb_from_date { get; set; }
        public DateTime? bgb_to_date { get; set; }
        public DateTime? bgb_to_date1 { get; set; }
        public DateTime? bgb_to_date2 { get; set; }
        public string lic_reg_no_imp { get; set; }
        public string lic_reg_no_exp { get; set; }
        public string file_imp { get; set; }
        public string file_exp { get; set; }
        public string lic_short_text { get; set; }
        public string scop { get; set; }
        public string release_status { get; set; }
        public string release_mode { get; set; }
        public decimal? release_amt { get; set; }
        public int? days { get; set; }
        public DateTime? release_date { get; set; }
        public string lic_cat_code { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public bool? active { get; set; }
        public string add_by { get; set; }
        public DateTime add_date { get; set; }
        public string edit_by { get; set; }
        public DateTime? edit_date { get; set; }
        public string para1 { get; set; }
        public string para2 { get; set; }
        public string para3 { get; set; }
        public string para4 { get; set; }
        public string para5 { get; set; }
        public string t_status { get; set; }
        public string bgb_register_at { get; set; }
        public string bgb_details { get; set; }
        public string CompName { get; set; }
        public string lang_key { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }
        public string XmlDataDocument_ADM_M041_C { get; set; }
    }

    public partial class ADM_M041_C
    {
        public int id { get; set; }
        public string lic_cod { get; set; }
        public string ItemCode { get; set; }
        public string description { get; set; }
        public string unit_code { get; set; }
        public decimal? qty { get; set; }
        public decimal? weight { get; set; }
        public string wt_unit { get; set; }
        public string sion_type { get; set; }
        public string incoterms { get; set; }
        public decimal? incoterm_val { get; set; }
        public string currency { get; set; }
        public string item_group_code { get; set; }
        public string sion_no { get; set; }
        public string sion_desc { get; set; }
        public string prod_desc { get; set; }
        public decimal? qty_limit_max { get; set; }
        public decimal? qty_limit_min { get; set; }
        public decimal? wt_limit_min { get; set; }
        public decimal? wt_limit_max { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public bool? active { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string add_by { get; set; }
        public DateTime add_date { get; set; }
        public string edit_by { get; set; }
        public DateTime? edit_date { get; set; }
        public string t_status { get; set; }
        public decimal? incoterm_val_local { get; set; }
        public string local_currency { get; set; }
        public DateTime? obgl_from { get; set; }
        public DateTime? obgl_to { get; set; }


    }
}
