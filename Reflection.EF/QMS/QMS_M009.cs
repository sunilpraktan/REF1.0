using System;

namespace Reflection.EF.QMS
{
    public partial class QMS_M009 : ObjectBase
    {
        public string tcm_code { get; set; }
        public string tcm_name { get; set; }
        public string tcm_desc { get; set; }
        public string test_code { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string lang_key { get; set; }
    }

    public partial class QMS_M009_A
    {
        public string test_code { get; set; }
        public string test_name { get; set; }
        public string short_name { get; set; }
        public string test_desc { get; set; }
        public string CatCode { get; set; }
        public string insp_type { get; set; }
        public string test_cat { get; set; }
        public string tp_code { get; set; }
        public string wi_code { get; set; }
        public string note { get; set; }
        public Nullable<bool> active { get; set; }
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
        public string ItemCode { get; set; }
        // scalar
        public string CatName { get; set; }
        public string insp_type_name { get; set; }
        public string tp_desc { get; set; }
        public string wi_desc { get; set; }
        public string ItemName { get; set; }
    }

    public partial class QMS_M009_B
    {
        public int id { get; set; }
        public string test_code { get; set; }
        public string test_type_code { get; set; }
        public string test_type_name { get; set; }
        public Nullable<int> seq_no { get; set; }
        public string short_name { get; set; }
        public string description { get; set; }
        public string master_inst { get; set; }
        public Nullable<int> line_id { get; set; }
        public string unit_code { get; set; }
        public string note { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string client { get; set; }
        public string lang_key { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string op_hdr { get; set; }
        public string formula_code { get; set; }
        public decimal? coverage_factor { get; set; }
        public string conf_level { get; set; }
        public string decimal_format_code { get; set; }
        //Scalar
        public string master_inst_name { get; set; }
        public string formula_desc { get; set; }        
    }

    public partial class QMS_M009_C
    {
        public int hdr_id { get; set; }
        public string test_type_code { get; set; }
        public int? seq_no { get; set; }
        public string hdr_name { get; set; }
        public string hdr_desc { get; set; }
        public decimal? std_value { get; set; }
        public decimal? l_value { get; set; }
        public decimal? h_value { get; set; }
        public string unit_code { get; set; }
        public bool? active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public DateTime add_date { get; set; }
        public string editby { get; set; }
        public DateTime? edit_date { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string insp_char { get; set; }
        //scalar
        public int? srno { get; set; }
    }

    public partial class QMS_M009_D
    {
        public int value_id { get; set; }
        public int hdr_id { get; set; }
        public string column_value { get; set; }
        public int? seq_no { get; set; }
        public bool? def_bit { get; set; }
        public string unit_code { get; set; }
        public bool? active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public DateTime add_date { get; set; }
        public string editby { get; set; }
        public DateTime? edit_date { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public decimal? std_value { get; set; }
        public decimal? l_value { get; set; }
        public decimal? h_value { get; set; }
        public decimal? value_from { get; set; }
        public string value_from_unit { get; set; }
        public decimal? value_to { get; set; }
        public string value_to_unit { get; set; }

        //scalar
        public int? srno { get; set; }
        public string test_type_code { get; set; }
    }

    public partial class QMS_M009_E
    {
        public int header_id { get; set; }
        public string test_type_code { get; set; }
        public Nullable<int> seq_no { get; set; }
        public string rdg_header { get; set; }
        public string short_name { get; set; }
        public string rdg_type { get; set; }
        public Nullable<bool> active { get; set; }
    }

    public partial class QMS_M009_F
    {
        public string para_code { get; set; }
        public string para_name { get; set; }
        public string tcm_code { get; set; }
        public string test_code { get; set; }
        public bool? allow_null { get; set; }
        public string unit_code { get; set; }
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
        public string para_type { get; set; }
        public string record_use { get; set; }
        public Nullable<System.DateTime> valid_from { get; set; }
        //scalar
        public int value_id { get; set; }
        public string value_code { get; set; }
        public string para_value { get; set; }
        public string unit_value { get; set; }
        public string CatlogName { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }
    }

    public partial class QMS_M009_G
    {
        public int id { get; set; }
        public string value_code { get; set; }
        public string para_value { get; set; }
        public string para_code { get; set; }
        public string unit_code { get; set; }
        public bool? active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string client { get; set; }
        public string lang_key { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string para_type { get; set; }
        public string version_no { get; set; }
        public Nullable<System.DateTime> valid_from { get; set; }
        public string defect_class { get; set; }
        public string record_use { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }
        //Scalar
        public string defect_desc { get; set; }
        public bool Click { get; set; }
    }

    public partial class QMS_M009_H
    {
        public int id { get; set; }
        public string test_code { get; set; }
        public string test_type_code { get; set; }
        public string tl_code { get; set; }
        public bool? active { get; set; }
        //Scalar
        public string short_text { get; set; }
    }

    public partial class QMS_M009_J
    {
        public int id { get; set; }
        public string test_code { get; set; }
        public string test_type_code { get; set; }
        public int header_id { get; set; }
        public int? value_id1 { get; set; }
        public int? value_id2 { get; set; }
        public int? value_id3 { get; set; }
        public int? value_id4 { get; set; }
        public int? value_id5 { get; set; }
        public int? value_id6 { get; set; }
        public int? value_id7 { get; set; }
        public int? value_id8 { get; set; }
        public int? value_id9 { get; set; }
        public int? value_id10 { get; set; }
        public decimal? header_value { get; set; }
        public decimal? uncertainty { get; set; }
        public string uncertainty_unit { get; set; }
        public DateTime? due_date { get; set; }
        public string unit_code { get; set; }
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
        public decimal? accuracy_up { get; set; }
        public string accuracy_up_unit { get; set; }
        public decimal? accuracy_down { get; set; }
        public string accuracy_down_unit { get; set; }
        public decimal? resolution { get; set; }
        public string resolution_unit { get; set; }
        //scalar
        public string test_type_name { get; set; }
        public string column_value1 { get; set; }
        public string column_value2 { get; set; }
        public string column_value3 { get; set; }
        public string column_value4 { get; set; }
        public string column_value5 { get; set; }
        public string column_value6 { get; set; }
        public string column_value7 { get; set; }
        public string column_value8 { get; set; }
        public string column_value9 { get; set; }
        public string column_value10 { get; set; }
        public string header_name { get; set; }
    }

    public partial class QMS_M009_K
    {
        public int id { get; set; }
        public string test_code { get; set; }
        public string test_type_code { get; set; }
        public string env_code { get; set; }
        public string env_name { get; set; }
        public decimal? std_value { get; set; }
        public decimal? upper_value { get; set; }
        public decimal? lower_value { get; set; }
        public string std_value_unit { get; set; }
        public decimal? resolution { get; set; }
        public string resolution_unit { get; set; }
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
    }
}
