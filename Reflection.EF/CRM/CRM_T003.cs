using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.CRM
{
    public partial class CRM_T003 : ObjectBase
    {
        public string doc_no { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string source { get; set; }
        public Nullable<int> address_id { get; set; }
        public Nullable<System.DateTime> expect_date { get; set; }
        public Nullable<int> buyer { get; set; }
        public string notes { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string ref_doc_no { get; set; }
        public string ref_doc_type { get; set; }
        public string PartyId { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string curr_code { get; set; }
        public string cost_center { get; set; }
        public string version { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string t_status { get; set; }
        public Nullable<decimal> ex_rate { get; set; }
        public string para1 { get; set; }
        public string para2 { get; set; }
        public string para3 { get; set; }
        public string revision_no { get; set; }
        public string revision_ind { get; set; }
        public string rev_ref_no { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string reference_by { get; set; }
        public string reference_details { get; set; }
        public string t_status_remark { get; set; }
        public string client { get; set; }
        public string lang_key{ get; set; }
        public string doc_history_no { get; set; }
        public bool active { get; set; }
        public System.DateTime add_date { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
        public string group_key { get; set; }
        public string priority { get; set; }
        public string doc_score { get; set; }
        public string doc_rec { get; set; }
        public string camp_no { get; set; }
        public string project_no { get; set; }
        public string doc_title { get; set; }
        public string origin_code { get; set; }
        public string ind_privacy { get; set; }
        public Nullable<int> annual_revenue { get; set; }
        public Nullable<int> emp_strength { get; set; }
        public Nullable<decimal> exp_sales_opp { get; set; }
        public string seg_code { get; set; }
        public Nullable<System.DateTime> exp_closing_date { get; set; }
        public Nullable<decimal> success_chance { get; set; }
        public string ind_forecast { get; set; }
        public string doc_qulif_Level { get; set; }
        public string forcast_no { get; set; }
        public string planning_no { get; set; }
        public string ind_io { get; set; }
        public string survey_no { get; set; }
        public string cgroup_code { get; set; }
        public string pref_contact { get; set; }
        public string reason_code { get; set; }
        public string doc_stage { get; set; }
        public string color_code { get; set; }
        public string rank_star { get; set; }
        public Nullable<decimal> probability { get; set; }
        public int user_score { get; set; }
        public string doc_status { get; set; }
        public string doc_ref { get; set; }
        public Nullable<System.DateTime> ref_date { get; set; }
        public string ref_party { get; set; }
        public string ref_contact_person { get; set; }
        //Scaler   
        public string PartyNm { get; set; }
        public string seller_name { get; set; }
        public string cost_center_Desc { get; set; }
        public string PartyEmailId { get; set; }
        public string PersonEmailId { get; set; }
        public string dcat_name { get; set; }
        public string symbol { get; set; }
        public string doc_desc { get; set; }
        public string LoctnNm { get; set; }
        public string doc_type_user { get; set; }
        public string address_name { get; set; }
        public string buyer_name { get; set; }
        public string ref_contact_name { get; set; }
        public string origin_desc { get; set; }
        public string ref_party_name { get; set; }
        public string pref_contact_name { get; set; }
        public string seg_name { get; set; }
        //Scaler
        public string sales_person_name { get; set; }
        public string so_name { get; set; }
        public string sg_name { get; set; }
        public string party_name { get; set; }
        public string party_location { get; set; }
        public string location_name { get; set; }
        public string doc_status_name { get; set; }
        public string doc_stage_name { get; set; }
        public string doc_rec_name { get; set; }
        public string doc_score_name { get; set; }
        public string qulif_Level_name { get; set; }
        public string priority_name { get; set; }
    }
    public partial class CRM_T003_A
    {
        public int id { get; set; }
        public string doc_no { get; set; }

        public int line_id { get; set; }
        public string ItemCode { get; set; }
        public string sku { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> quantity { get; set; }
        public string unit_code { get; set; }
        public Nullable<decimal> unit_price { get; set; }
        public Nullable<System.DateTime> date_planned { get; set; }
        public string para1 { get; set; }
        public string para2 { get; set; }
        public string para3 { get; set; }
        public string doc_history_no { get; set; }
        public string bom_no { get; set; }
        public Nullable<decimal> net_value { get; set; }
        public Nullable<decimal> discount { get; set; }
        public string discount_type { get; set; }
        public Nullable<decimal> discount_amt { get; set; }


        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public bool active { get; set; }
        public string t_status { get; set; }
        public string status_remark { get; set; }
        public System.DateTime add_date { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }

        //Scaler
        public string symbol { get; set; }
        
    }
    public partial class CRM_T003_B
    {
        public int id { get; set; }
        public string doc_no { get; set; }   
        public Nullable<System.DateTime> distb_date { get; set; }
        public Nullable<System.DateTime> effec_date { get; set; }
        public string sales_person { get; set; }
        public string so_code { get; set; }
        public string sg_code { get; set; }
        public string dc_code { get; set; }
        public string soff_code { get; set; }
        public string sales_area { get; set; }
        public string t_status { get; set; }
        public string status_remark { get; set; }
        public string role_code { get; set; }
        public Nullable<bool> ind_primary { get; set; }
        public string distbt_mcode { get; set; }
        public bool active { get; set; }
        public System.DateTime add_date { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
        public string sales_person_name { get; set; }
    }
    public partial class CRM_T003_C
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public string party_id { get; set; }
        public string ind_primary { get; set; }    
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string edit_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string client { get; set; }
        public string lang_key { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        //Scaler
        public string party_name { get; set; }
      
    }
    public partial class CRM_T003_D
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public string cp_code { get; set; }
        public string ind_primary { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string edit_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string client { get; set; }
        public string lang_key { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        //Scaler
        public string cp_name { get; set; }
       
    }
    public class CRM_M003_P_RefDoc //Sales Order Reference Documents as per Paarty
    {
        public string doc_no { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string PartyId { get; set; }
        public string party_name { get; set; }
        public string ItemCode { get; set; }

    }
}
