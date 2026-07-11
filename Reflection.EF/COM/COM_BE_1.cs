using Reflection.EF.ADM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.COM
{
    public class COM_T001 : ObjectBase
    {
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public string doc_no { get; set; }
        public DateTime? doc_date { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string not_type { get; set; }
        public string short_text { get; set; }
        public string pri_code { get; set; }
        public DateTime? not_date { get; set; }
        public TimeSpan? note_time { get; set; }
        public string emp_id { get; set; }
        public string emp_name { get; set; }
        public DateTime? start_date { get; set; }
        public TimeSpan? start_time { get; set; }
        public DateTime? end_date { get; set; }
        public TimeSpan? end_time { get; set; }
        public string curr_code { get; set; }
        public string order_no { get; set; }
        public string item_code { get; set; }
        public string ppc_plant { get; set; }
        public string party_code { get; set; }
        public string party_code2 { get; set; }
        public DateTime? ref_date { get; set; }
        public string ref_no { get; set; }
        public string sd_doc_no { get; set; }
        public int? sd_item_row_id { get; set; }
        public string po_no { get; set; }
        public int? po_item_row_id { get; set; }
        public string item_plant { get; set; }
        public string lot_no { get; set; }
        public string batch_no { get; set; }
        public string store_code { get; set; }
        public string batch_no_party { get; set; }
        public string doc_no_ppc { get; set; }
        public string doc_no_dn { get; set; }
        public int? item_row_id_dn { get; set; }
        public string obj_type { get; set; }
        public string obj_no { get; set; }
        public DateTime? cloase_date { get; set; }
        public string close_time { get; set; }
        public string wc_plant { get; set; }
        public string wc_obj_code { get; set; }
        public int? order_counter { get; set; }
        public decimal qty_internal { get; set; }
        public decimal qty_external { get; set; }
        public string unit_code { get; set; }
        public decimal qty_complaint { get; set; }
        public decimal qty_return { get; set; }
        public DateTime? return_date { get; set; }
        public string serail_no { get; set; }
        public string equip_no { get; set; }
        public string equip_master { get; set; }
        public string floc_no { get; set; }
        public string active { get; set; }
        public string t_status { get; set; }
        public string not_org { get; set; }
        public string ref_doc_cat { get; set; }
        public string ref_doc_no { get; set; }
        public string catlog_type { get; set; }
        public string code_group { get; set; }
        //public string value_code { get; set; }
        public string ver_no { get; set; }
        public string so_code { get; set; }
        public string sg_code { get; set; }
        public string po_code { get; set; }
        public string pg_code { get; set; }
        public string mm_doc_no { get; set; }
        public int? mm_item_row_id { get; set; }
        public string delivery_no { get; set; }
        public int? del_item_row_id { get; set; }
        public int? node_no { get; set; }
        public string ref_not_no { get; set; }
        public string ext_ref_no { get; set; }
        public string item_code_c { get; set; }
        public string item_code_v { get; set; }
        public DateTime? prod_date { get; set; }
        public string qm_doc_no { get; set; }
        public string pm_doc_no { get; set; }
        public int? int_counter { get; set; }
        public string element_id { get; set; }
        public string fun_loc { get; set; }
        public string unique_id { get; set; }
        public decimal cost_estimate { get; set; }
        public decimal cost_claimed { get; set; }
        public decimal cost_accepted { get; set; }
        public string emp_id_res { get; set; }
        

        //Scalar Fields

        public string long_text { get; set; }
        public string t_display { get; set; }
        public string XDOC_A { get; set; }
        public string XDOC_B { get; set; }
        public string XDOC_C { get; set; }
        public string XDOC_D { get; set; }
        public string XDOC_E { get; set; }
        public string emp_name_res { get; set; }
        public string not_type_name { get; set; }
        public string equip_name { get; set; }
        public string obj_name { get; set; }
        public string email_res { get; set; } // email id of responsible person
        public string doc_type_name { get; set; }
        public string manufacturer { get; set; }
        public string model { get; set; }
        public string serial_no { get; set; }
        public string range { get; set; }
        public string accuracy { get; set; }
        public string asset_status { get; set; }
        public string repair_by { get; set; }
        public DateTime? repair_plan_dt { get; set; }
        public DateTime? repair_dt { get; set; }


    }
    public class COM_T001_A : ObjectBase
    {
        public int? id { get; set; }
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public string doc_no { get; set; }
        public int? line_id { get; set; }
        public string short_text { get; set; }
        public string catlog_type { get; set; }
        public string code_group { get; set; }
        public string value_code { get; set; }
        public string ver_no { get; set; }
        public string catlog_type_obj { get; set; }
        public string code_group_obj { get; set; }
        public string value_code_obj { get; set; }
        public string assembly_code { get; set; }
        public string ind_org { get; set; }
        public string ind_repet { get; set; }
        public string defect_code { get; set; }
        public string defect_class { get; set; }
        public string order_no { get; set; }
        public decimal qty_external { get; set; }
        public decimal qty_internal { get; set; }
        public string unit_code { get; set; }
        public int? defect_no { get; set; }
        public double? defect_val { get; set; }
        public string val_unit { get; set; }
        public int? node_no { get; set; }
        public int? char_no { get; set; }
        public string char_code { get; set; }
        public int? sample_no { get; set; }
        public string phy_sample_no { get; set; }
        public string unit_no { get; set; }
        public string wc_obj_code { get; set; }
        public string wc_plant { get; set; }
        public int? org_item { get; set; }
        public string item_code { get; set; }
        public string po_code { get; set; }
        public string pur_doc_no { get; set; }
        public string cc_code { get; set; }
        public string equip_no { get; set; }
        public string fun_loc { get; set; }
        public string active { get; set; }
        public string t_status { get; set; }

    }
    public class COM_T001_B : ObjectBase
    {
        public int? id { get; set; }
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public string doc_no { get; set; }
        public int? line_id { get; set; }
        public int? item_row_id { get; set; }
        public int? seq_no { get; set; }
        public string catlog_type { get; set; }
        public string code_group { get; set; }
        public string value_code { get; set; }
        public string ver_no { get; set; }
        public string short_text { get; set; }
        public string follow_act { get; set; }
        public string obj_no { get; set; }
        public string ind_log { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        public string obj_name { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        public string emp_id { get; set; }
        public string emp_name { get; set; }
        public DateTime? comp_date { get; set; }
        public string comp_time { get; set; }
        public DateTime? resubmit_date { get; set; }
        public int? item_no { get; set; }
        public int? seq_no_cause { get; set; }
        public string pf_code { get; set; }
        public string party_code { get; set; }
        public string cp_code { get; set; }
        public string cp_name { get; set; }
        public decimal qty { get; set; }
        public string unit_code { get; set; }
        public string assembly_code { get; set; }
        public int? sort_no { get; set; }
        public string unique_id { get; set; }
        public string time_zone { get; set; }
        public string time_zone_task { get; set; }
        public DateTime? time_stamp { get; set; }
        public string active { get; set; }
        public string t_status { get; set; }

    }
    public class COM_T001_C : ObjectBase
    {
        public int? id { get; set; }
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public string doc_no { get; set; }
        public int? act_no { get; set; }
        public int? line_id { get; set; }
        public int? item_row_id { get; set; }
        public int? seq_no { get; set; }
        public string catlog_type { get; set; }
        public string code_group { get; set; }
        public string value_code { get; set; }
        public string ver_no { get; set; }
        public string short_text { get; set; }
        public string task_class { get; set; }
        public string ind_class { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        public string active { get; set; }
        public string t_status { get; set; }

    }



    public class MC_COM_T001_BE : MC_COM_BE
    {
        public List<COM_T001> MasterEntity { get; set; }
        public List<COM_T001_A> ItemsEntity { get; set; }
        public List<COM_T001_B> TaskEntity { get; set; }
        public List<COM_T001_C> ActivityEntity { get; set; }

    }

    public class COM_T011 : ObjectBase
    {
        public int? id { get; set; }
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public int? auth_level { get; set; }
        public string doc_no { get; set; }
        public DateTime? doc_date { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string doc_no_wf { get; set; }
        public string short_text { get; set; }
        public string pr_code { get; set; }
        public string obj_type { get; set; }
        public string obj_no { get; set; }
        //public string userid { get; set; } // inherited will get use
        public string creator { get; set; }
        public string sender { get; set; }
        public DateTime? rec_date { get; set; }
        public string rec_type { get; set; }
        public string rec_status { get; set; }
        public DateTime? read_date { get; set; }
        public DateTime? act_date { get; set; }
        public string t_status { get; set; }
        public string notes { get; set; }
        public string feedback { get; set; }
        public string auth_type { get; set; }


        //Scalar Fields

        public string emp_id { get; set; }
        public string emp_name { get; set; }
        public string t_display { get; set; }
        public string creator_name { get; set; }


    }
    public class MC_COM_T011_BE : MC_COM_BE
    {
        public List<COM_T011> MasterList { get; set; }

    }


    public class COM_NOTIFY : ObjectBase
    {
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public string doc_no { get; set; }
        public DateTime? doc_date { get; set; }
        public string short_text { get; set; }
        public string creator { get; set; }
        public string sender { get; set; }
        public string sender_no { get; set; }
        public string t_status { get; set; }
        public string notes { get; set; }
        public string emp_id { get; set; }
        public string emp_name { get; set; }
        public string t_display { get; set; }
        public string creator_name { get; set; }
        public string message { get; set; }
        public string template { get; set; }
        public string party_code { get; set; }
        public string party_name { get; set; }
        public string ref_name { get; set; }
        public string consultant { get; set; }
        public decimal? amount { get; set; }
        public string address { get; set; }
        public string contact_no { get; set; }
        public string email { get; set; }
        public string service_info { get; set; } // Test Info


    }

    public class COM_M0051  // API Master
    {
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public string api_code { get; set; }
        public string short_text { get; set; }
        public string party_code { get; set; }
        public string api_url { get; set; }
        public string url_type { get; set; }
        public string re_type { get; set; }
        public string active { get; set; }
        public DateTime? date_add { get; set; }
        public DateTime? date_start { get; set; }
        public DateTime? date_end { get; set; }

    }

    public class COM_T051  // Notification Log
    {
        public int? id { get; set; }
        public string client { get; set; }
        public string comp_code { get; set; }
        public string loc_code { get; set; }
        public string msg_cat { get; set; }
        public string short_text { get; set; }
        public string msg_id { get; set; }
        public string msg_sub { get; set; }
        public string ref_doc_cat { get; set; }
        public string ref_doc_no { get; set; }
        public int? item_row_id { get; set; }
        public string resp_id { get; set; }
        public string t_point { get; set; }
        public string t_status { get; set; }
        public DateTime? create_date { get; set; }
        public DateTime? sch_date { get; set; }
        public DateTime? sent_date { get; set; }
        public DateTime? ack_date { get; set; }
        public int? msg_count { get; set; }
        public string con_number { get; set; }
        public string msg_code { get; set; }
        public string ind_pay { get; set; }
        public string ind_mode { get; set; }
        public string sender { get; set; }

    }
    public class MC_NOTIFY_BE : MC_COM_BE
    {
        public List<COM_NOTIFY> NOTIFY_RECEPIENTS_LIST { get; set; }
        public List<COM_NOTIFY> NOTIFY_SERIVCE_LIST { get; set; } // API details like WhatsApp, SMS, Email setting etc
        public List<COM_M0051> API_LIST { get; set; }

    }
}
