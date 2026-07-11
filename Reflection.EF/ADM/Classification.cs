using Reflection.EF.QMS;
using System;
using System.Collections.Generic;

namespace Reflection.EF.ADM
{
    public class Classification : ObjectBase
    {
        public bool? selected { get; set; }
        public int? int_char { get; set; }
        public int? int_char_obj { get; set; }
        public int? eco_counter { get; set; }
        public int? value_counter { get; set; }
        public int? class_no { get; set; }
        public string config_id { get; set; }
        public string obj_type { get; set; }
        public string type_name { get; set; }
        public string obj_key { get; set; }
        public string obj_name { get; set; }
        public string ind_obj_class { get; set; }
        public int? item_no { get; set; }
        public int? int_counter { get; set; }
        public string class_code { get; set; }
        public string class_type { get; set; }
        public string class_group { get; set; }
        public string class_name { get; set; }
        public string char_code { get; set; }
        public string char_name { get; set; }
        public string char_value { get; set; }
        public string long_text { get; set; }  
        public string data_type { get; set; }
        public int? priority { get; set; }
        public int? no_of_char { get; set; }
        public int? no_of_dec { get; set; }
        public string ind_sign { get; set; }
        public string ind_case { get; set; }
        public string char_group { get; set; }
        public string group_name { get; set; }
        public string ind_char { get; set; }
        public string unit_code { get; set; }
        public string unit_code2 { get; set; }
        public string base_uom { get; set; }
        public string ind_add { get; set; }
        public string ind_mv { get; set; }
        public string t_status { get; set; }
        public string t_display { get; set; }
        public string active { get; set; }
        public string doc_no { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string prof_type { get; set; }
        public string prof_code { get; set; }
        public string para_type { get; set; }
        public string para_code { get; set; }
        public string para_name { get; set; }
        public string para_value { get; set; }
        public string para_set { get; set; }
        public DateTime? valid_from { get; set; }
        public DateTime? valid_to { get; set; }
        public string dep_code { get; set; }
        public string default_value { get; set; }
        public string obj_id { get; set; }
        public double? floating_from { get; set; }
        public double? floating_to { get; set; }
        public double? tol_from { get; set; }
        public double? tol_to { get; set; }
        public string ind_tol { get; set; }
        public double? tol_inc { get; set; }
        public string lang_key { get; set; }
        public string ind_comp { get; set; }
        public string ind_bom { get; set; }
        public string ind_task_list { get; set; }
        public string ind_rel { get; set; }
        public string profile_code { get; set; }
        public string profile_name { get; set; }
        public string sort_field { get; set; }
        public string curr_code { get; set; }
        public string short_text { get; set; }
        public string char_type { get; set; }
        public string char_ver { get; set; } // Version No
        public string char_loc { get; set; } // Char Location
        public string way_char { get; set; }
        public string qual_code { get; set; } // Qualification Code
        public double? up_limit { get; set; }
        public double? low_limit { get; set; }
        public string separator { get; set; }
        public string location_id { get; set; }
        public string comp_code { get; set; }
        //public string value_code { get; set; }
        //public string value_name { get; set; }
        public string ver_no { get; set; }
        public string def_class { get; set; } // defect class code
        public string def_class_name { get; set; }
        public double? quality_score { get; set; }
        public string v_code { get; set; } // Valuation Code for RR in Inspection
        public string v_name { get; set; } // Valuation Code Name for RR in Inspection
        public string ud_code { get; set; } // Usage decision Code for RR in Inspection


        public string XDOC_A { get; set; }
        public string XDOC_B { get; set; }
        //public string key_value { get; set; }

    }

    public class ADM_M0111 : ObjectBase
    {
        public int? int_char { get; set; }
        public int? eco_counter { get; set; }
        public string char_code { get; set; }
        public string char_name { get; set; }
        public string data_type { get; set; }
        public int? no_of_char { get; set; }
        public int? no_of_dec { get; set; }
        public string ind_sign { get; set; }
        public string ind_case { get; set; }
        public string char_group { get; set; }
        public string ind_char { get; set; }
        public string unit_code { get; set; }
        public string ind_mv { get; set; }
        public string ind_add { get; set; }
        public string ind_interval { get; set; }
        public string t_status { get; set; }
        public string active { get; set; }
        public string doc_no { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string prof_type { get; set; }
        public string para_code { get; set; }
        public string para_set { get; set; }
        public DateTime? valid_from { get; set; }
        public DateTime? valid_to { get; set; }
        public string curr_code { get; set; }
        public string char_type { get; set; }
        public string ver_no { get; set; }
        public string record_use { get; set; }
        public string control_data { get; set; }
        public string way_char { get; set; }
        public string tol_key { get; set; }
        public int? dc_place { get; set; }
        public double? target_value { get; set; }
        public string value1 { get; set; }
        public double? up_limit { get; set; }
        public string value2 { get; set; }
        public double? low_limit { get; set; }
        public double? up_tol_limit { get; set; }
        public double? low_tol_limit { get; set; }
        public double? low_limit1 { get; set; }
        public double? up_limit1 { get; set; }
        public string profile_d1 { get; set; }
        public string profile_d2 { get; set; }
        public string profile_d3 { get; set; }
        public string profile_d4 { get; set; }
        public string fract_cal { get; set; }
        public string internal_char { get; set; }
        public double? low_limit2 { get; set; }
        public double? up_limit2 { get; set; }
        public string ind_sp { get; set; }
        public string ind_spc { get; set; }
        public string ind_as { get; set; }
        public string ind_ds { get; set; }
        public string ind_lti { get; set; }
        public string ind_ss { get; set; }
        public string ind_ea { get; set; }
        public string ind_dr { get; set; }
        //public string ind_value { get; set; }
        public string insp_qual { get; set; }
        public string spec_info { get; set; }
        public string short_text { get; set; }
        public string vs_code { get; set; }
        public string ref_class { get; set; }
        public string ind_neg { get; set; }
        public string table_name { get; set; }
        public string field_name { get; set; }


        // Scalar
        public string _t_display { get; set; }
        public string sys_char_name { get; set; }
        public string class_name { get; set; }
        public string XDOC_A { get; set; }

    }
    public class ADM_M0112 : ObjectBase
    {
        public bool? selected { get; set; }
        public int? int_char { get; set; }
        public int? int_counter { get; set; }
        public int? eco_counter { get; set; }
        public string char_code { get; set; }
        public string char_value { get; set; }
        public string long_text { get; set; }
        public double? floating_from { get; set; }
        public double? floating_to { get; set; }
        public string dep_code { get; set; }
        public string default_value { get; set; }
        public string obj_id { get; set; }
        public double? tol_from { get; set; }
        public double? tol_to { get; set; }
        public string ind_tol { get; set; }
        public double? tol_inc { get; set; }
        public string active { get; set; }

        // Scalar
        public string char_name { get; set; }

    }
    public class ADM_M0126 : ObjectBase
    {
        public string obj_key { get; set; }
        public string class_type { get; set; }
        public string vc_code { get; set; }
        public string short_text { get; set; }
        public string class_code { get; set; }
        public int? class_no { get; set; }
        public int? int_counter { get; set; }
        public string vc_code_parent { get; set; }
        public string vc_code_root { get; set; }
        public string obj_type { get; set; }
        public string active { get; set; }

        //Scalar
        public string class_name { get; set; }
        public string XDOC_A { get; set; }


    }
    public class ADM_M0127 : ObjectBase
    {
        public string vc_code { get; set; }
        public string char_code { get; set; }
        public string char_value { get; set; }

        // Scalar
        public string char_name { get; set; }
        public string obj_key { get; set; }
        public string unit_code { get; set; }
        public int? int_char { get; set; }
        public string ind_interval { get; set; }
        public string ind_mv { get; set; }

    }
    public class ADM_M0111_MC : MC_ADM_BE
    {
        public List<ADM_M0111> MASTER_LIST { get; set; }
        public List<ADM_M0112> CHAR_VALUE_OBV_LIST { get; set; }
        public List<QMS_M0032> ProfileTypeList { get; set; }

        //public ObservableCollection<Classification> OBJECT_CLASS_LIST { get; set; }
        //public ObservableCollection<Classification> PROFILE_LIST { get; set; }

    }
    public class Classification_MC : MC_ADM_BE
    {
        public List<Classification> MASTER_LIST { get; set; }
        public List<Classification> OBJECT_CLASS_LIST { get; set; }
        public List<Classification> PROFILE_LIST { get; set; }
        public List<Classification> CHAR_VALUE_OBV_LIST { get; set; }
    }

    public class MC_ADM_M0126 : MC_ADM_BE
    {
        //public List<ADM_M0126> CHAR_LIST { get; set; }
        //public List<ADM_M0127> VC_VALUE_LIST { get; set; }
        //public ObservableCollection<Classification> OBJECT_CLASS_LIST { get; set; }
        //public ObservableCollection<Classification> PROFILE_LIST { get; set; }
        //public ObservableCollection<Classification> CHAR_VALUE_OBV_LIST { get; set; }
    }
}


