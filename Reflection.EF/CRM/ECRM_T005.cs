using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.CRM
{
    public partial class ECRM_T005 : ObjectBase
    {
        public int id { get; set; }
        public int company_id { get; set; }
        public string plant { get; set; }
        public string inv_no { get; set; }
        public Nullable<decimal> exchange_rate { get; set; }
        public string cust_pur_inv { get; set; }
        public string pack_list { get; set; }
        public string sdf_form { get; set; }
        public string decltn_lic { get; set; }
        public string insurance { get; set; }
        public string brc { get; set; }
        public string adv_licenc_no { get; set; }
        public string epcg_licenc_no { get; set; }
        public string dispch_mode { get; set; }
        public string final_destn_contry { get; set; }
        public string final_destn_port { get; set; }
        public Nullable<decimal> gross_wt { get; set; }
        public Nullable<decimal> net_wt { get; set; }
        public string ship_line { get; set; }
        public string air_line { get; set; }
        public string air_way_billno { get; set; }
        public Nullable<System.DateTime> air_way_billdt { get; set; }
        public string ref_no { get; set; }
        public Nullable<System.DateTime> ref_date { get; set; }
        public string etd { get; set; }
        public string eta { get; set; }
        public string acode { get; set; }
        public string dcinv_frwd_cust { get; set; }
        public Nullable<System.DateTime> dcinv_frwd_cust_dt { get; set; }
        public string dcinv_frwd_thr { get; set; }
        public string dcpck_frwd_cust { get; set; }
        public Nullable<System.DateTime> dcpck_frwd_cust_dt { get; set; }
        public string dcpck_frwd_thr { get; set; }
        public string dcair_frwd_cust { get; set; }
        public Nullable<System.DateTime> dcair_frwd_cust_dt { get; set; }
        public string dcair_frwd_thr { get; set; }
        public string dcinsur_frwd_cust { get; set; }
        public Nullable<System.DateTime> dcinsur_frwd_cust_dt { get; set; }
        public string dcinsur_frwd_thr { get; set; }
        public string dccertif_cust { get; set; }
        public Nullable<System.DateTime> dccertif_cust_dt { get; set; }
        public string dccertif_cust_thr { get; set; }
        public string dbinv_frwd_bnk { get; set; }
        public Nullable<System.DateTime> dbinv_frwd_bnk_dt { get; set; }
        public string dbinv_frwd_thr { get; set; }
        public string dbpck_frwd_bnk { get; set; }
        public Nullable<System.DateTime> dbpck_frwd_bnk_dt { get; set; }
        public string dbpck_frwd_thr { get; set; }
        public string dbair_frwd_bnk { get; set; }
        public Nullable<System.DateTime> dbair_frwd_bnk_dt { get; set; }
        public string dbair_frwd_thr { get; set; }
        public string dbinsur_frwd_bnk { get; set; }
        public Nullable<System.DateTime> dbinsur_frwd_bnk_dt { get; set; }
        public string dbinsur_frwd_thr { get; set; }
        public string dbcertif_bnk { get; set; }
        public Nullable<System.DateTime> dbcertif_bnk_dt { get; set; }
        public string dbcertif_bnk_thr { get; set; }
        public string curr { get; set; }
        public Nullable<decimal> inv_fc { get; set; }
        public Nullable<decimal> inv_rs { get; set; }
        public Nullable<System.DateTime> brc_dt { get; set; }
        public Nullable<decimal> brc_inv_rs { get; set; }
        public string brc_appl_for_bank { get; set; }
        public Nullable<System.DateTime> brc_appl_dt { get; set; }
        public string brc_appl_bank { get; set; }
        public string brc_recv_for_bank { get; set; }
        public Nullable<System.DateTime> brc_recv_dt { get; set; }
        public string brc_recv_bank { get; set; }
        public Nullable<decimal> bnk_chrg_comm { get; set; }
        public Nullable<decimal> other_chrg { get; set; }
        public Nullable<decimal> short_pay { get; set; }
        public string shipp_billno { get; set; }
        public Nullable<System.DateTime> shipp_bill_dt { get; set; }
        public Nullable<decimal> fc_curr { get; set; }
        public Nullable<decimal> exrate { get; set; }
        public Nullable<decimal> fc_inv { get; set; }
        public Nullable<decimal> rs_inv { get; set; }
        public Nullable<decimal> fc_freight { get; set; }
        public Nullable<decimal> rs_freight { get; set; }
        public Nullable<decimal> fc_insur { get; set; }
        public Nullable<decimal> rs_insur { get; set; }
        public Nullable<decimal> fc_comm { get; set; }
        public Nullable<decimal> rs_comm { get; set; }
        public Nullable<decimal> fc_fob { get; set; }
        public Nullable<decimal> rs_fob { get; set; }
        public Nullable<decimal> fc_import_allw { get; set; }
        public Nullable<decimal> rs_import_allw { get; set; }
        public Nullable<decimal> fc_ship_inv { get; set; }
        public Nullable<decimal> rs_ship_inv { get; set; }
        public Nullable<decimal> ship_exchge_rate { get; set; }
        public string gridppsdf { get; set; }
        public Nullable<System.DateTime> mate_recp_dt { get; set; }
        public Nullable<System.DateTime> realization_dt { get; set; }
        public string nform_no { get; set; }
        public Nullable<System.DateTime> nform_dt { get; set; }
        public string epcopy { get; set; }
        public string sdffwtobank { get; set; }
        public string excontrolcopy { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public Nullable<int> edit_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public Nullable<System.DateTime> InvDate { get; set; }
        public string acode_name { get; set; }
        public decimal bnk_chrg_comm_fc { get; set; }
        public decimal other_chrg_fc { get; set; }
        public decimal short_pay_fc { get; set; }
        public string comp_code { get; set; }
        public string UserId { get; set; }
        public string editby_cd { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string location_Id { get; set; }
        public string curr_code { get; set; }
        public string editby { get; set; }
    }
}
