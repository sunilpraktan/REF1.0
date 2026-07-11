using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.FICO
{
    public class STD_FICO_BE : STD_LIST_BE  //--- Standard Business Entity for FICO Module
    {
        public string con_type { get; set; }
        public string con_desc { get; set; }
        public string con_cat { get; set; }
        public string pricing_pro { get; set; }
        public string acc_key { get; set; }
        public string trns_key_code { get; set; }

        public string lic_cod { get; set; }
        public string lic_desc { get; set; }
        public string lic_type { get; set; }
        public DateTime? issue_date { get; set; }
        public DateTime? export_expiry_date { get; set; }
        public string file_no { get; set; }
        public string cc_code { get; set; } // Cost Center code
        public string cc_name { get; set; } // Cost Center Name

        public string wtax_code { get; set; }
        public string wtax_ncode { get; set; }
        public decimal? wtax_rate { get; set; }
        public decimal? wtax_per { get; set; }
        public string wtax_type { get; set; }
    }
    public class FICO_M0019//---Cost Center
    {
        public string cc_code { get; set; }
        public string cc_name { get; set; }
    }
    public class FICO_M0020//---Profit Center
    {
        public string pc_code { get; set; }
        public string pc_name { get; set; }
    }
    public class FICO_M0004 : ObjectBase // Bank
    {
        public bool? selected { get; set; }
        public int? id { get; set; }
        public string comp_code { get; set; }
        public string hb_code { get; set; }
        public string hb_acc { get; set; }
        public string acc_no { get; set; }
        public string acc_name { get; set; }
        public string acc_type { get; set; }
        public string curr_code { get; set; }
        public string iban_no { get; set; }
        public bool? active { get; set; }
        public string bank_code { get; set; }
        public string bank_name { get; set; }
        public string branch { get; set; }
        public string ifsc_code { get; set; }
        public string swift_code { get; set; }
        public string ad_code { get; set; }
        public string micr_code { get; set; }
        public string short_text { get; set; }
        public string long_text { get; set; }
        public string abbr { get; set; }
        public string ctry_code { get; set; }
        public string ctry_name { get; set; }
        public string lang_key { get; set; }
        public bool? ind_default { get; set; }
        public string ind_trade { get; set; }
        public string recon_acc { get; set; }
        public string gl_code { get; set; }
        public string gl_name { get; set; }

    }

    public class ACC_M0032  //--- Exchange Rate Related Entity
    {
        public string client { get; set; }
        public int? id { get; set; }
        public string exch_rate_type { get; set; }
        public string curr_code_from { get; set; }
        public string curr_code_to { get; set; }
        public DateTime? date_effective { get; set; }
        public decimal? exch_rate { get; set; }
        public decimal? exch_rate_direct { get; set; }
        public decimal? ratio_from { get; set; }
        public decimal? ratio_to { get; set; }
        public string ind_cal { get; set; }
        public string cur_code { get; set; }
        public string ind_from { get; set; }
        public string active { get; set; }

        // Scallar
        public bool? selected { get; set; }
    }
    public class FICO_M0033 : ObjectBase // Currency Master
    {
        public int? id { get; set; }
        public string curr_code { get; set; }
        public string curr_name { get; set; }
        public decimal? rounding { get; set; }
        public string symbol { get; set; }
        public bool? curr_base { get; set; }
        public string position { get; set; }
        public int? accuracy { get; set; }
        public bool? active { get; set; }
        public int? no_of_deci { get; set; }
        public string monitory_unit { get; set; }
        public string monitory_unit_prefix { get; set; }
        public string tail_word { get; set; }
        public decimal? exch_rate { get; set; }
        public decimal? exch_rate_direct { get; set; }
        public DateTime? date_effective { get; set; }
        public string curr_code_to { get; set; }
        public string word_format { get; set; }
        public string word_prefix { get; set; }
        public string word_suffix { get; set; }
        public string t_status { get; set; }
        public string t_display { get; set; }
        public bool? selected { get; set; }

    }

    public class ACC_T021 : ObjectBase // Billing Plan Table
    {
        public string comp_code { get; set; }
        public string doc_no { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string plan_cat { get; set; }
        public string short_text { get; set; }
        public DateTime? date_start { get; set; }
        public DateTime? date_end { get; set; }
        public DateTime? create_date { get; set; }
        public string ref_doc_cat { get; set; }
        public string ref_doc_no { get; set; }
        public decimal? target_value { get; set; }
        public string ind_advance { get; set; }
        public string pro_doc_no { get; set; }
        public string element_id { get; set; }
        public string active { get; set; }
        public string t_status { get; set; }
        public string curr_code { get; set; }

        // Scalar

        public string t_display { get; set; }

    }

    public class MC_ACC_M0032 : MC_FICO_BE // Transaction specific MC Class
    {
        public List<ACC_M0032> MASTER_ENTITY_LIST { get; set; }

    }
    public class MC_FICO_M0004 : MC_FICO_BE // Transaction specific MC Class
    {
        public List<FICO_M0004> MASTER_ENTITY_LIST { get; set; }
        public List<FICO_M0004> ItemsEntity { get; set; }
    }

	public class ACC_T051 : ObjectBase // einvoice/eWay Bill acknoledgement Table
	{
		public int? id { get; set; }
		public string comp_code { get; set; }
		public string doc_no { get; set; }
		public string ack_no { get; set; }
		public string irn_no { get; set; }
		public DateTime? irn_date { get; set; }
		public string doc_cat { get; set; }
		public string doc_type { get; set; }
		public string cat_code { get; set; }
		public string qr_code { get; set; }
		public string active { get; set; }
		public string t_status { get; set; }

		// Scalar

		public string t_display { get; set; }

	}
}
