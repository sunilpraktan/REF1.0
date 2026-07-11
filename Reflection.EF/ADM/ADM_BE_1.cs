using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.ADM
{

    public class ADM_M0002
    {
        public string client { get; set; }
        public string group_code { get; set; }
        public string comp_code { get; set; }
        public string comp_name { get; set; }
        public string abrv { get; set; }
        public string curr_code { get; set; }
        public string buss_place { get; set; }
        public string ctr_code { get; set; }
        public byte[] comp_logo { get; set; }

        public string add_code { get; set; } // NOTE: add this as column and maintain address in the address table.
        public string address { get; set; } // NOTE: Make this as scallar and user for address construction for display purpose in single textbox.

        public string back_color { get; set; }
        public string four_color { get; set; }
        public string font_family { get; set; }
        public string font_size { get; set; }
        public string ind_underline { get; set; }
        public string ind_italic { get; set; }
        public string tax_reg_no { get; set; }
        public string logo_url { get; set; }
    }
    public class ADM_M0003
    {
        public string client { get; set; }
        public string group_code { get; set; }
        public string comp_code { get; set; }
        public string comp_name { get; set; }
        public string abrv { get; set; }
        public string location_id { get; set; }
        public string location_name { get; set; }
        public string place { get; set; }
        public string city { get; set; }
        public string state_code { get; set; }
        public string state { get; set; }
        public string country_code { get; set; }
        public string ctr_code { get; set; }
        public string buss_place { get; set; }

        public string add_code { get; set; } // NOTE: add this as column and maintain address in the address table.
        public string address { get; set; } // NOTE: Make this as scallar and user for address construction for display
        public string tax_reg_no { get; set; }
    }
    public class ADM_M0010
    {
        public string client { get; set; }
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public string doc_type { get; set; }
        public string type_name { get; set; }
        public string doc_type_name { get; set; }
        public string doc_type_user { get; set; }
        public string doc_type_doc_no { get; set; }
        public string doc_desc { get; set; }
        public string doc_desc_user { get; set; }
        public string doc_cat { get; set; }
        public bool? default_doc { get; set; }
        public string delivery_type { get; set; }
        public string billing_type { get; set; }
        public string report_name { get; set; }
        public string doc_no_format { get; set; }
        public string Workflow_id_temp { get; set; }
        public int? range1 { get; set; }
        public int? range2 { get; set; }
        public int? doc_no_digits { get; set; }
        public string ts_code { get; set; }
        public string ts_code_mi { get; set; }
        public string unit_code { get; set; } // Default Entry Unit. i.e. Hrs(Hourse) in case of Production Entry Time Ticket.
        public bool? auto_roundup { get; set; }
        public int? roundup_digits { get; set; }
        public string posting_key { get; set; }
        public string active { get; set; }

        public string format_no { get; set; } // Document format no
        public string issue_no { get; set; } // Document format issue no
        public DateTime? issue_date { get; set; } // Document format issue date
        public string rev_no { get; set; } // Document format revision no
        public DateTime? rev_date { get; set; } // Document format revision date
        public string ind_printf { get; set; } // default print format with or without header. Null or 1: with header 0: without Header
        public string ind_digital { get; set; } // default print format. Null or 1: Digital 0: Print format
        public string ind_header { get; set; } // default print format with or without header. Null or 1: with header 0: without Header
        public string date_type { get; set; }
        public string title { get; set; }
        public string store_code { get; set; } // default store code for POS invoice
        public string mov_tp_mi { get; set; } // default goods movement type for POS invoice
        public string ts_code_gr { get; set; } // default ts_code for Goods Receipt Note
        public string ts_code_si { get; set; } // default ts_code for invoice
        public string ts_code_or { get; set; } // default ts_code for Inhouse Production or Repaire & maintainance, Calibration and Testing Service Order.
        public string ind_default { get; set; } // default document type for document category.
        public int? valid_days { get; set; }

    }
    public class ADM_M0013 : ObjectBase
    {
        public string doc_type { get; set; }
        public string t_status { get; set; }
        public string t_name { get; set; }
        public int? id { get; set; }
        public int? t_sequence { get; set; }
        public string doc_cat { get; set; }
        public string t_module { get; set; }
        public string t_display { get; set; }
        public int? t_weight { get; set; }
        public string t_next { get; set; }
        public string t_prev { get; set; }
        public string ind_draft { get; set; }
        public string ind_closing { get; set; }
        public string ind_close { get; set; }
        public string ind_closed { get; set; }
        public string ind_custom { get; set; }
        public string ind_manual { get; set; }
        public string ind_doc_type { get; set; }
        public string ind_change { get; set; }
        public string ind_cancel { get; set; }
        public string ind_modify { get; set; }
        public string ind_valid { get; set; }
        public string ind_validated { get; set; }
        public string ind_active { get; set; }
        public string ind_default { get; set; }
        public string ind_goods_posting { get; set; }
        public string ind_released { get; set; }
        public string ind_ack { get; set; }
        public string lang_key { get; set; }
        public string active { get; set; }
        //scalar
        public bool? Click { get; set; }
        public string doc_desc_user { get; set; }
    }
    public class ADM_M0018
    {
        public string client { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string ref_doc_cat { get; set; }
        public string ref_doc_type { get; set; }
        public string t_status { get; set; }
        public string active { get; set; }
        public bool? selected { get; set; }

    }
    public class ADM_M0051 : ObjectBase
    {
        public bool? selected { get; set; }
        public string comp_code { get; set; }
        public string tc_code { get; set; }
        public int? seq_no { get; set; }
        public string party_code { get; set; }
        public string org_code { get; set; }
        public string org_group { get; set; }
        public string tc_cat { get; set; }
        public string short_text { get; set; }
        public string long_text { get; set; }
        public string ind_man { get; set; }
        public string lang_key { get; set; }
        public string con_group { get; set; }
        public string group_code { get; set; }
        public string con_type { get; set; }
        public string active { get; set; }
        public string tc_parent { get; set; }
        public string model_code { get; set; }
        public string doc_cat { get; set; }

        public string con_type_name { get; set; }
        public string party_name { get; set; }
    }
    public class ADM_M0071 : ObjectBase
    {
        public string para_code { get; set; }
        public string para_name { get; set; }
        public string para_value { get; set; }
        public string item_cat { get; set; }
        public string item_cat_name { get; set; }
        public string item_subcat { get; set; }
        public string item_subcat_name { get; set; }
        public string item_code { get; set; }
        public string sku { get; set; }
        public string ind_sku { get; set; }
        public string selectedValue { get; set; }
        public string unit_code { get; set; }
        public int? selectedindex { get; set; }

        // NOTE: Depricated 

        public string SubCatCode { get; set; }
        public string parametervalue { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string ItemCode { get; set; }
        public int? count { get; set; }
        public int? code { get; set; }
        public string stockunit { get; set; }
        public int? dgselectedindex { get; set; }

    }
    public class ADM_M0040 : ObjectBase
    {
        public string pr_code { get; set; }
        public string text_name { get; set; }
        public int? waitage { get; set; }
        public int? seq_no { get; set; }
    }

    public class ADM_M0110 : ObjectBase
    {
        public bool? selected { get; set; }
        public string char_group { get; set; }
        public string group_name { get; set; }
        public string parent_group { get; set; }
        public string active { get; set; }

    }
    public class ADM_S0001 //subscribe module list purchased by client
    {
        public string module_code { get; set; }
        public string module_name { get; set; }
        public string parent_module { get; set; }
        public string active { get; set; }
        public string t_status { get; set; }
    }


    public class ADM_M0051_MC : MC_ADM_BE
    {
        public List<ADM_M0051> MasterEntityList { get; set; }
    }

    
}
