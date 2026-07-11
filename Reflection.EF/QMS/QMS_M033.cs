using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.QMS
{
    public partial class QMS_M0033 : ObjectBase
    {
        public string prof_code { get; set; }
        public string short_text { get; set; }
        public string prof_type { get; set; }
        public string record_use { get; set; }
        public string active { get; set; }
        public string Location_id { get; set; }
        public string t_status { get; set; }
        public string lang_key { get; set; }
        public string comp_code { get; set; }


        //Scalar
        public string XDOC_A { get; set; }
        public string prof_type_name { get; set; }


    }

    public partial class QMS_M0033_A
    {
        public int? id { get; set; }
        public string prof_code { get; set; }
        public string prof_type { get; set; }
        public string char_code { get; set; }
        public string char_value { get; set; }
        public string ver_nos { get; set; }
        public DateTime? valid_from { get; set; }
        public string ver_noc { get; set; }
        public string short_text { get; set; }
        public string long_text { get; set; }
        public string v_code { get; set; }
        public string def_class { get; set; }
        public string curr_key { get; set; }
        public decimal? nc_cost { get; set; }
        public int? quality_score { get; set; }
        public string fa_code { get; set; }
        public string ud_code { get; set; }
        public string active { get; set; }
        public string location_id { get; set; }
        public string t_status { get; set; }
        public string comp_code { get; set; }
        public string lang_key { get; set; }

        //Scalar
        public string def_class_name { get; set; }
        public string char_name { get; set; }
        public string prof_name { get; set; }
        public string font_family { get; set; }
        public float font_size { get; set; }
        public bool? bold { get; set; }
        public string color { get; set; }
    }

    // Depricated below BE

    //public partial class QMS_M033 : ObjectBase
    //{
    //    public string para_prof_code { get; set; }
    //    public string para_prof_desc { get; set; }
    //    public string para_type { get; set; }
    //    public string record_use { get; set; }
    //    public Nullable<bool> active { get; set; }
    //    public string add_by { get; set; }
    //    public System.DateTime add_date { get; set; }
    //    public string editby { get; set; }
    //    public Nullable<System.DateTime> edit_date { get; set; }
    //    public string Location_Id { get; set; }
    //    public string t_status { get; set; }
    //    public string lang_key { get; set; }
    //    public string comp_code { get; set; }
    //    public string XmlDataDocument_QMS_M033_Flip { get; set; }
    //    public string XmlDataDocument_QMS_M033_A { get; set; }

    //    //Scalar
    //    public string _para_name { get; set; }


    //}

    //public partial class QMS_M033_A
    //{
    //    public int id { get; set; }
    //    public string para_prof_code { get; set; }
    //    public string para_type { get; set; }
    //    public string para_code { get; set; }
    //    public string value_code { get; set; }
    //    public string version_no_set { get; set; }
    //    public Nullable<System.DateTime> valid_from { get; set; }
    //    public string version_no_code { get; set; }
    //    public string short_desc { get; set; }
    //    public string long_desc { get; set; }
    //    public string valuation_code { get; set; }
    //    public string defect_class { get; set; }
    //    public string curr_key { get; set; }
    //    public Nullable<decimal> non_confirm_cost { get; set; }
    //    public Nullable<int> quality_score { get; set; }
    //    public string follow_action { get; set; }
    //    public string prob_usage_decision { get; set; }
    //    public Nullable<bool> active { get; set; }
    //    public string add_by { get; set; }
    //    public System.DateTime add_date { get; set; }
    //    public string editby { get; set; }
    //    public Nullable<System.DateTime> edit_date { get; set; }
    //    public string Location_Id { get; set; }
    //    public string user_source1 { get; set; }
    //    public string user_source2 { get; set; }
    //    public string t_status { get; set; }
    //    public string comp_code { get; set; }
    //    public string lang_key { get; set; }
    //    public string client { get; set; }
    //    //Scalar
    //    public string para_value { get; set; }
    //    public string group_code_name { get; set; }
    //    public string def_class_name { get; set; }
    //    public string char_code { get; set; }
    //    public string para_name { get; set; }
    //    public string para_prof_desc { get; set; }
    //}
}
