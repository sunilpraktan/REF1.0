using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Production
{
    public partial class ENG_T004 : ObjectBase
    {
        public string doc_no { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public DateTime doc_date { get; set; }
        public string language{ get; set; }
        public string fin_year{ get; set; }
        public string posting_period{ get; set; }
        public string comp_code{ get; set; }
        public string location_Id{ get; set; }
        public string add_by{ get; set; }
        public DateTime add_date{ get; set; }
        public string editby{ get; set; }
        public DateTime edit_date{ get; set; }
        public bool active{ get; set; }
        public string t_status{ get; set; }
        public string ItemCode{ get; set; }
        public int ink_id{ get; set; }
        public int ild_id{ get; set; }
        public int machine_id{ get; set; }
        public string machinecode{ get; set; }
        public string sku{ get; set; }
        public string sku_desc{ get; set; }
        public int model_id{ get; set; }
        public string note{ get; set; }
        public string front_view{ get; set; }
        public string back_view{ get; set; }
        public string top_view{ get; set; }
        public string bottom_view{ get; set; }
        public int machine_type_id{ get; set; }
        public int revision_no { get; set; }
        public DateTime revision_date{ get; set; }
        public string parent_no{ get; set; }
        public int ball_makeCode { get; set; }
        public int wire_makeCode { get; set; }
        public int wire_type_id { get; set; }
        public string unit_code{ get; set; }
        public int MakeCode { get; set; }
        public string ref_doc_no { get; set; }
        public string cycle_type { get; set; }
        public string customer_id { get; set; }
       
        //Scalar
        public string modelno { get; set; }
        public string modeldesc { get; set; }
        public string ItemName { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public string Ball_Make { get; set; }
        public string Wire_Make { get; set; }
        public string Wire_Type { get; set; }
        public string LoctnNm { get; set; }
        public string doc_no1 { get; set; }
        public string doc_no2 { get; set; }
        public string doc_no3 { get; set; }
        public string doc_no4 { get; set; }
        public bool revision { get; set; }
        public string Make { get; set; }

        //scalar for filters

        public string lctn_id_filter { get; set; }
        public string lctn_filter { get; set; }
        public int model_id_filter { get; set; }
        public string modelno_filter { get; set; }
        public int ball_dia_filter { get; set; }
        public int ink_id_filter { get; set; }
        public string ink_filter { get; set; }
        public int ild_id_filter { get; set; }
        public string ild_filter { get; set; }
        public string Cust_id_filter { get; set; }
        public string Cust_nm_filter { get; set; }
        public string cycle_type_filter { get; set; }

        public string XmlDataDocument_ENG_T004_A { get; set; }
        public string XmlDataDocument_ENG_T004_B { get; set; }
        public string XmlDataDocument_ENG_T004_C { get; set; }
        public string XmlDataDocument_ENG_T004_D { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }

    }
    public partial class ENG_T004_A
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public System.DateTime doc_date { get; set; }
        public string client { get; set; }
        public string language { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public System.DateTime edit_date { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public bool active { get; set; }
        public string t_status { get; set; }
        public string revision_no { get; set; }
        public System.DateTime revision_date { get; set; }
        public string parent_no { get; set; }
        public string alternate_item { get; set; }
        public System.DateTime create_date { get; set; }
        public string range { get; set; }
        public Nullable<decimal> tol_minus { get; set; }
        public Nullable<decimal> tol_plus { get; set; }
        public string frequency { get; set; }
        public string spec_type_code { get; set; }
        public string spec_para_code { get; set; }
        public string instrument_code { get; set; }
        public string para_value { get; set; }
        public string remark { get; set; }
        public string sr_no { get; set; }
        public string value_code { get; set; }
        public int? line_id { get; set; }
        //scalar
        public string parametervalue { get; set; }
        public string spec_type { get; set; }
        public string parameter { get; set; }
        public string instrument { get; set; }
    }
    public partial class ENG_T004_B
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string Datetime { get; set; }
        public string client { get; set; }
        public string language { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public System.DateTime edit_date { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public bool active { get; set; }
        public string t_status { get; set; }
        public string revision_no { get; set; }
        public System.DateTime revision_date { get; set; }
        public string parent_no { get; set; }
        public string alternate_item { get; set; }
        public string section_type { get; set; }
        public Nullable<decimal> quantity { get; set; }
        public string life_days { get; set; }
        public string life_qty { get; set; }
        public string remark { get; set; }
        public Nullable<decimal> length { get; set; }
        public string ItemCode { get; set; }
        public Nullable<decimal> degree { get; set; }
        public string drill_spec { get; set; }
        public Nullable<decimal> drill_section { get; set; }
        public string stn_no { get; set; }
        public string type { get; set; }
        public int MakeCode { get; set; }
        public string make { get; set; }
        public int ball_dia_id { get; set; }
        public int wire_dia_id { get; set; }
        public int ball_MakeCode { get; set; }
        public int wire_MakeCode { get; set; }
        public string ball_grade_code { get; set; }
        public string wire_grade_code { get; set; }
        public int ink_id { get; set; }
        public string material { get; set; }
        public string grade { get; set; }
        public string ild_aurora { get; set; }
        public string surface_fnsh { get; set; }
        public string work_type { get; set; }
        public string bin_no { get; set; }
        public string gbi_obi_type { get; set; }
        public string colors { get; set; }
        public decimal? tol_minus { get; set; }
        public decimal? tol_plus { get; set; }
        public int? line_id { get; set; }
        //scalar
        public string ItemName { get; set; }
        public string alternate_itemName { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public string Make { get; set; }
        public decimal Ball_dia { get; set; }
        public decimal wire_size { get; set; }
        public string BallMake { get; set; }
        public string WireMake { get; set; }
        public string Working { get; set; }
        public string parametervalue { get; set; }
        public string parameter { get; set; }
        public string para_value { get; set; }
        public Nullable<decimal> tol_minus_A { get; set; }
        public Nullable<decimal> tol_plus_A { get; set; }
    }

    public partial class ENG_T004_C
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string ild { get; set; }
        public string ball_range { get; set; }
        public string ball_out { get; set; }
        public string hammer { get; set; }
        public string spring { get; set; }
        public bool active { get; set; }
        public string t_status { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public System.DateTime edit_date { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }

    }
    public partial class ENG_T004_D
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string PartyId { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string client { get; set; }
        public bool active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public System.DateTime edit_date { get; set; }
        public string PartyNm { get; set; }

    }
}
