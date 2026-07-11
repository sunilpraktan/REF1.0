using Reflection.BusinessEntity.ADM;
using Reflection.BusinessEntity.Admin;
using Reflection.BusinessEntity.CustomerRelation;
using Reflection.BusinessEntity.GEN;
using Reflection.BusinessEntity.ReflectionSystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Reflection.BusinessEntity
{

    public class PUR_T002_A : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private string _po_no;
        public string po_no
        {
            get { return _po_no; }
            set { _po_no = value; RaisePropertyChanged("po_no", ModelEntityUpdated); }
        }

        private string _symbol;
        public string symbol
        {
            get { return _symbol; }
            set { _symbol = value; RaisePropertyChanged("symbol"); }
        }

        private Nullable<System.DateTime> _po_date;
        public Nullable<System.DateTime> po_date
        {
            get { return _po_date; }
            set
            {
                if (value == null)
                {
                    _po_date = DateTime.Now;
                }
                else
                {
                    _po_date = value;
                }
                RaisePropertyChanged("po_date");
            }
        }

        private int _id;
        public int id { get { return _id; } set { _id = value; RaisePropertyChanged("id", ModelEntityUpdated); } }

        private string _doc_type;
        //[DisplayName("Document Type")]
        //[Required(ErrorMessage = "Field 'Doc_Type' is required.")]
        public string doc_type { get { return _doc_type; } set { _doc_type = value; RaisePropertyChanged("doc_type", ModelEntityUpdated); } }

        private string _doc_cat;
        public string doc_cat { get { return _doc_cat; } set { _doc_cat = value; RaisePropertyChanged("doc_cat", ModelEntityUpdated); } }

        private string _quotation_no;
        public string quotation_no { get { return _quotation_no; } set { _quotation_no = value; RaisePropertyChanged("quotation_no", ModelEntityUpdated); } }

        private Nullable<System.DateTime> _quotation_date;
        public Nullable<System.DateTime> quotation_date { get { return _quotation_date; } set { _quotation_date = value; RaisePropertyChanged("quotation_date", ModelEntityUpdated); } }

        private Nullable<System.DateTime> _quotation_validity;
        public Nullable<System.DateTime> quotation_validity { get { return _quotation_validity; } set { _quotation_validity = value; RaisePropertyChanged("quotation_validity", ModelEntityUpdated); } }

        private Nullable<bool> _sample;
        public Nullable<bool> sample { get { return _sample; } set { _sample = value; RaisePropertyChanged("sample", ModelEntityUpdated); } }

        private string _ref_doc_no;
        public string ref_doc_no { get { return _ref_doc_no; } set { _ref_doc_no = value; RaisePropertyChanged("ref_doc_no", ModelEntityUpdated); } }

        private Nullable<System.DateTime> _ref_doc_date;
        public Nullable<System.DateTime> ref_doc_date { get { return _ref_doc_date; } set { _ref_doc_date = value; RaisePropertyChanged("ref_doc_date", ModelEntityUpdated); } }

        private Nullable<System.DateTime> _valid_from_date;
        public Nullable<System.DateTime> valid_from_date { get { return _valid_from_date; } set { _valid_from_date = value; RaisePropertyChanged("valid_from_date", ModelEntityUpdated); } }

        private Nullable<System.DateTime> _valid_to_date;
        public Nullable<System.DateTime> valid_to_date { get { return _valid_to_date; } set { _valid_to_date = value; RaisePropertyChanged("valid_to_date", ModelEntityUpdated); } }

        private Nullable<System.DateTime> _expiration_date;
        public Nullable<System.DateTime> expiration_date { get { return _expiration_date; } set { _expiration_date = value; RaisePropertyChanged("expiration_date", ModelEntityUpdated); } }

        private string _buyer;

        //[DisplayName("Buyer Name")]
        //[Required(ErrorMessage = "Field 'buyer' is required.")]
        public string buyer { get { return _buyer; } set { _buyer = value; RaisePropertyChanged("buyer", ModelEntityUpdated); } }

        public string _supplier_EmpId;
        public string supplier_EmpId { get { return _supplier_EmpId; } set { _supplier_EmpId = value; RaisePropertyChanged("supplier_EmpId", ModelEntityUpdated); } }

        public string _supplier_EmpName;
        public string supplier_EmpName { get { return _supplier_EmpName; } set { _supplier_EmpName = value; RaisePropertyChanged("supplier_EmpName", ModelEntityUpdated); } }

        private string _po_code;
        public string po_code { get { return _po_code; } set { _po_code = value; RaisePropertyChanged("po_code", ModelEntityUpdated); } }

        private string _pg_code;
        public string pg_code { get { return _pg_code; } set { _pg_code = value; RaisePropertyChanged("pg_code", ModelEntityUpdated); } }

        private string _cost_center;
        public string cost_center { get { return _cost_center; } set { _cost_center = value; RaisePropertyChanged("cost_center", ModelEntityUpdated); } }

        private string _FormDescription;
        public string FormDescription
        {
            get { return _FormDescription; }
            set { _FormDescription = value; RaisePropertyChanged("FormDescription", ModelEntityUpdated); }
        }
        private Nullable<int> _form_type;
        public Nullable<int> form_type
        {
            get { return _form_type; }
            set { _form_type = value; RaisePropertyChanged("form_type", ModelEntityUpdated); }
        }
        private string _j_code;
        public string j_code { get { return _j_code; } set { _j_code = value; RaisePropertyChanged("j_code", ModelEntityUpdated); } }

        private Nullable<System.DateTime> _order_date;
        public Nullable<System.DateTime> order_date { get { return _order_date; } set { _order_date = value; RaisePropertyChanged("order_date", ModelEntityUpdated); } }

        private string _PartyId;
        //[Required(ErrorMessage = "Field 'Supplier Code' is required.")]
        public string PartyId { get { return _PartyId; } set { if (_PartyId != value) { _PartyId = value; RaisePropertyChanged("PartyId", ModelEntityUpdated); }; } }

        private string _party_name;
        public string party_name { get { return _party_name; } set { _party_name = value; RaisePropertyChanged("party_name", ModelEntityUpdated); } }

        private string _referring_party;
        public string referring_party { get { return _referring_party; } set { _referring_party = value; RaisePropertyChanged("referring_party", ModelEntityUpdated); } }

        private string _del_address_id;
        public string del_address_id { get { return _del_address_id; } set { _del_address_id = value; RaisePropertyChanged("del_address_id", ModelEntityUpdated); } }

        private string _bill_address_id;
        //[DisplayName("Billing Address")]
        public string bill_address_id { get { return _bill_address_id; } set { _bill_address_id = value; RaisePropertyChanged("bill_address_id", ModelEntityUpdated); } }

        private string _address;
        public string address { get { return _address; } set { _address = value; RaisePropertyChanged("address", ModelEntityUpdated); } }

        private string _address1;
        public string address1 { get { return _address1; } set { _address1 = value; RaisePropertyChanged("address1", ModelEntityUpdated); } }

        private string _country_nm;
        public string country_nm { get { return _country_nm; } set { _country_nm = value; RaisePropertyChanged("country_nm", ModelEntityUpdated); } }

        private string _state_nm;
        public string state_nm { get { return _state_nm; } set { _state_nm = value; RaisePropertyChanged("state_nm", ModelEntityUpdated); } }

        private string _city;
        public string city { get { return _city; } set { _city = value; RaisePropertyChanged("city", ModelEntityUpdated); } }

        private string _pincode;
        public string pincode { get { return _pincode; } set { _pincode = value; RaisePropertyChanged("pincode", ModelEntityUpdated); } }

        private string _phone_no;
        public string phone_no { get { return _phone_no; } set { _phone_no = value; RaisePropertyChanged("phone_no", ModelEntityUpdated); } }

        private string _mobile_no;
        public string mobile_no { get { return _mobile_no; } set { _mobile_no = value; RaisePropertyChanged("mobile_no", ModelEntityUpdated); } }

        private string _phone_ext;
        public string phone_ext { get { return _phone_ext; } set { _phone_ext = value; RaisePropertyChanged("phone_ext", ModelEntityUpdated); } }

        private string _mail_id;
        public string mail_id { get { return _mail_id; } set { _mail_id = value; RaisePropertyChanged("mail_id", ModelEntityUpdated); } }

        private string _web_site { get; set; }
        public string web_site { get { return _web_site; } set { _web_site = value; RaisePropertyChanged("web_site", ModelEntityUpdated); } }

        private string _fp_code;
        public string fp_code { get { return _fp_code; } set { _fp_code = value; RaisePropertyChanged("fp_code", ModelEntityUpdated); } }

        private Nullable<decimal> _amount_untaxed;
        public Nullable<decimal> amount_untaxed { get { return _amount_untaxed; } set { _amount_untaxed = value; RaisePropertyChanged("amount_untaxed", ModelEntityUpdated); } }

        private string _stock_location_id;
        public string stock_location_id { get { return _stock_location_id; } set { _stock_location_id = value; RaisePropertyChanged("stock_location_id", ModelEntityUpdated); } }

        private Nullable<decimal> _amount_tax;
        public Nullable<decimal> amount_tax { get { return _amount_tax; } set { _amount_tax = value; RaisePropertyChanged("amount_tax", ModelEntityUpdated); } }

        private Nullable<int> _pricelist_id;
        public Nullable<int> pricelist_id { get { return _pricelist_id; } set { _pricelist_id = value; RaisePropertyChanged("pricelist_id", ModelEntityUpdated); } }

        private string _cat_no;
        public string cat_no { get { return _cat_no; } set { _cat_no = value; RaisePropertyChanged("cat_no", ModelEntityUpdated); } }
        private string _wa_code;
        public string wa_code { get { return _wa_code; } set { _wa_code = value; RaisePropertyChanged("wa_code", ModelEntityUpdated); } }

        private string _p_term_code;
        public string p_term_code { get { return _p_term_code; } set { _p_term_code = value; RaisePropertyChanged("p_term_code", ModelEntityUpdated); } }

        private string _curr_code;
        public string curr_code
        {
            get { return _curr_code; }
            set {
                    if (_curr_code != value)
                    {
                     _curr_code = value; RaisePropertyChanged("curr_code", ModelEntityUpdated);
                    }   
                }
        }

        private Nullable<decimal> _ex_rate;
        public Nullable<decimal> ex_rate { get { return _ex_rate; } set { _ex_rate = value; RaisePropertyChanged("ex_rate", ModelEntityUpdated); } }

        private string _supplying_plant;
        //[DisplayName("Supplying plant Name")]
        //[Required(ErrorMessage = "Field 'Supplying plant' is required.")]
        public string supplying_plant { get { return _supplying_plant; } set { _supplying_plant = value; RaisePropertyChanged("supplying_plant", ModelEntityUpdated); } }

        private string _incoterms;
        public string incoterms { get { return _incoterms; } set { _incoterms = value; RaisePropertyChanged("incoterms", ModelEntityUpdated); } }

        private string _supplier_ref;
        public string supplier_ref { get { return _supplier_ref; } set { _supplier_ref = value; RaisePropertyChanged("supplier_ref", ModelEntityUpdated); } }

        public DateTime? _supplier_ref_date;
        public DateTime? supplier_ref_date
        { get { return _supplier_ref_date; } set { _supplier_ref_date = value; RaisePropertyChanged("supplier_ref_date", ModelEntityUpdated); } }

        private Nullable<System.DateTime> _date_approve;
        public Nullable<System.DateTime> date_approve { get { return _date_approve; } set { _date_approve = value; RaisePropertyChanged("date_approve", ModelEntityUpdated); } }

        private Nullable<decimal> _amount_total;
        public Nullable<decimal> amount_total { get { return _amount_total; } set { _amount_total = value; RaisePropertyChanged("amount_total", ModelEntityUpdated); } }

        private string _amt_in_words;
        public string amt_in_words { get { return _amt_in_words; } set { _amt_in_words = value; RaisePropertyChanged("amt_in_words", ModelEntityUpdated); } }

        private string _down_ind;
        public string down_ind { get { return _down_ind; } set { _down_ind = value; RaisePropertyChanged("down_ind", ModelEntityUpdated); } }

        private Nullable<decimal> _down_per;
        public Nullable<decimal> down_per { get { return _down_per; } set { _down_per = value; RaisePropertyChanged("down_per", ModelEntityUpdated); } }

        private Nullable<decimal> _down_pay;
        public Nullable<decimal> down_pay { get { return _down_pay; } set { _down_pay = value; RaisePropertyChanged("down_pay", ModelEntityUpdated); } }

        private Nullable<System.DateTime> _down_date;
        public Nullable<System.DateTime> down_date { get { return _down_date; } set { _down_date = value; RaisePropertyChanged("down_date"); } }

        private string _reference;
        public string reference { get { return _reference; } set { _reference = value; RaisePropertyChanged("reference", ModelEntityUpdated); } }

        private string _notes;
        public string notes { get { return _notes; } set { _notes = value; RaisePropertyChanged("notes"); } }

        private string _invoice_method;
        public string invoice_method { get { return _invoice_method; } set { _invoice_method = value; RaisePropertyChanged("invoice_method"); } }

        private Nullable<bool> _shipped;
        public Nullable<bool> shipped { get { return _shipped; } set { _shipped = value; RaisePropertyChanged("shipped"); } }

        private Nullable<System.DateTime> _shipped_date;
        public Nullable<System.DateTime> shipped_date { get { return _shipped_date; } set { _shipped_date = value; RaisePropertyChanged("shipped_date"); } }

        private string _validator_code;
        public string validator_code { get { return _validator_code; } set { _validator_code = value; RaisePropertyChanged("validator_code"); } }

        private Nullable<System.DateTime> _min_planned_date;
        public Nullable<System.DateTime> min_planned_date { get { return _min_planned_date; } set { _min_planned_date = value; RaisePropertyChanged("min_planned_date"); } }

        private string _rel_sts;
        public string rel_sts { get { return _rel_sts; } set { _rel_sts = value; RaisePropertyChanged("rel_sts"); } }

        private string _t_status;
        public string t_status { get { return _t_status; } set { _t_status = value; RaisePropertyChanged("t_status", ModelEntityUpdated); } }

        private string _transacion_type;
        public string transacion_type { get { return _transacion_type; } set { _transacion_type = value; RaisePropertyChanged("transacion_type", ModelEntityUpdated); } }

        private string _status_quotation;
        public string status_quotation { get { return _status_quotation; } set { _status_quotation = value; RaisePropertyChanged("status_quotation", ModelEntityUpdated); } }

        private string _location_Id;
        public string location_Id { get { return _location_Id; } set { _location_Id = value; RaisePropertyChanged("location_Id", ModelEntityUpdated); } }

        private string _comp_code;
        //[Required(ErrorMessage = "Field 'comp_code' is required.")]

        public string comp_code
        {
            get { return _comp_code; }
            set {
                if (_comp_code != value)
                {
                    _comp_code = value;
                    RaisePropertyChanged("comp_code", ModelEntityUpdated);
                }
            } }

        private string _version;
        public string version { get { return _version; } set { _version = value; RaisePropertyChanged("version"); } }

        private Nullable<bool> _active;
        public Nullable<bool> active { get { return _active; } set { _active = value; RaisePropertyChanged("active", ModelEntityUpdated); } }

        private string _add_by;
        public string add_by { get { return _add_by; } set { _add_by = value; RaisePropertyChanged("add_by"); } }

        private System.DateTime _add_date;
        public System.DateTime add_date { get { return _add_date; } set { _add_date = value; RaisePropertyChanged("add_date", ModelEntityUpdated); } }

        private string _editby;
        public string editby { get { return _editby; } set { _editby = value; RaisePropertyChanged("editby"); } }

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date { get { return _edit_date; } set { _edit_date = value; RaisePropertyChanged("edit_date"); } }

        private string _local_export_ind;
        public string local_export_ind { get { return _local_export_ind; } set { _local_export_ind = value; RaisePropertyChanged("local_export_ind", ModelEntityUpdated); } }

        private Nullable<System.DateTime> _app_closing_dt;
        public Nullable<System.DateTime> app_closing_dt { get { return _app_closing_dt; } set { _app_closing_dt = value; RaisePropertyChanged("app_closing_dt"); } }

        private Nullable<System.DateTime> _quotation_deadline;
        public Nullable<System.DateTime> quotation_deadline { get { return _quotation_deadline; } set { _quotation_deadline = value; RaisePropertyChanged("quotation_deadline"); } }

        private string _bid_inv_no;
        public string bid_inv_no { get { return _bid_inv_no; } set { _bid_inv_no = value; RaisePropertyChanged("bid_inv_no"); } }

        private Nullable<System.DateTime> _quotation_submt_dt;
        public Nullable<System.DateTime> quotation_submt_dt { get { return _quotation_submt_dt; } set { _quotation_submt_dt = value; RaisePropertyChanged("quotation_submt_dt"); } }

        private Nullable<decimal> _shrot_excess_amt;
        public Nullable<decimal> shrot_excess_amt { get { return _shrot_excess_amt; } set { _shrot_excess_amt = value; RaisePropertyChanged("shrot_excess_amt", ModelEntityUpdated); } }

        private string _shrot_excess_flag;
        public string shrot_excess_flag { get { return _shrot_excess_flag; } set { _shrot_excess_flag = value; RaisePropertyChanged("shrot_excess_flag", ModelEntityUpdated); } }

        private string _delivery_ind;
        public string delivery_ind { get { return _delivery_ind; } set { _delivery_ind = value; RaisePropertyChanged("delivery_ind", ModelEntityUpdated); } }

        private string _gr_ind;
        public string gr_ind { get { return _gr_ind; } set { _gr_ind = value; RaisePropertyChanged("gr_ind"); } }

        private string _invoice_ind;
        public string invoice_ind { get { return _invoice_ind; } set { _invoice_ind = value; RaisePropertyChanged("invoice_ind"); } }

        private string _gr_inv_ind;
        public string gr_inv_ind { get { return _gr_inv_ind; } set { _gr_inv_ind = value; RaisePropertyChanged("gr_inv_ind"); } }

        private string _order_ack_ind;
        public string order_ack_ind { get { return _order_ack_ind; } set { _order_ack_ind = value; RaisePropertyChanged("order_ack_ind"); } }

        private string _order_ack_no;
        public string order_ack_no { get { return _order_ack_no; } set { _order_ack_no = value; RaisePropertyChanged("order_ack_no"); } }

        private Nullable<System.DateTime> _order_ack_date;
        public Nullable<System.DateTime> order_ack_date { get { return _order_ack_date; } set { _order_ack_date = value; RaisePropertyChanged("order_ack_date", ModelEntityUpdated); } }

        private Nullable<bool> _acknowledged;
        public Nullable<bool> acknowledged { get { return _acknowledged; } set { _acknowledged = value; RaisePropertyChanged("acknowledged"); } }

        private string _pur_agree_no;
        public string pur_agree_no { get { return _pur_agree_no; } set { _pur_agree_no = value; RaisePropertyChanged("pur_agree_no"); } }

        private string _pur_agree_item_cd;
        public string pur_agree_item_cd { get { return _pur_agree_item_cd; } set { _pur_agree_item_cd = value; RaisePropertyChanged("pur_agree_item_cd"); } }

        private string _ref_doc_type;
        public string ref_doc_type { get { return _ref_doc_type; } set { _ref_doc_type = value; RaisePropertyChanged("ref_doc_type", ModelEntityUpdated); } }

        private string _cust_mat_no;
        public string cust_mat_no { get { return _cust_mat_no; } set { _cust_mat_no = value; RaisePropertyChanged("cust_mat_no"); } }

        private Nullable<decimal> _abs_deviation_qty;
        public Nullable<decimal> abs_deviation_qty { get { return _abs_deviation_qty; } set { _abs_deviation_qty = value; RaisePropertyChanged("abs_deviation_qty"); } }

        private Nullable<decimal> _per_deviation_qty;
        public Nullable<decimal> per_deviation_qty { get { return _per_deviation_qty; } set { _per_deviation_qty = value; RaisePropertyChanged("per_deviation_qty"); } }

        private Nullable<decimal> _over_del_tol;
        public Nullable<decimal> over_del_tol { get { return _over_del_tol; } set { _over_del_tol = value; RaisePropertyChanged("over_del_tol"); } }

        private Nullable<decimal> _under_del_tol;
        public Nullable<decimal> under_del_tol { get { return _under_del_tol; } set { _under_del_tol = value; RaisePropertyChanged("under_del_tol"); } }

        private string _bank_code;
        public string bank_code { get { return _bank_code; } set { _bank_code = value; RaisePropertyChanged("bank_code", ModelEntityUpdated); } }

        private string _revision_no;
        public string revision_no { get { return _revision_no; } set { _revision_no = value; RaisePropertyChanged("revision_no", ModelEntityUpdated); } }

        private string _revision_ind;
        public string revision_ind { get { return _revision_ind; } set { _revision_ind = value; RaisePropertyChanged("revision_ind", ModelEntityUpdated); } }

        private string _rev_ref_no;
        public string rev_ref_no { get { return _rev_ref_no; } set { _rev_ref_no = value; RaisePropertyChanged("rev_ref_no", ModelEntityUpdated); } }

        private string _cf_agent_cd;
        public string cf_agent_cd { get { return _cf_agent_cd; } set { _cf_agent_cd = value; RaisePropertyChanged("cf_agent_cd", ModelEntityUpdated); } }

        private Nullable<decimal> _qty_tol;
        public Nullable<decimal> qty_tol { get { return _qty_tol; } set { _qty_tol = value; RaisePropertyChanged("qty_tol", ModelEntityUpdated); } }

        private Nullable<decimal> _amt_tol;
        public Nullable<decimal> amt_tol { get { return _amt_tol; } set { _amt_tol = value; RaisePropertyChanged("amt_tol", ModelEntityUpdated); } }

        private string _nastro_bank_cd;
        public string nastro_bank_cd { get { return _nastro_bank_cd; } set { _nastro_bank_cd = value; RaisePropertyChanged("nastro_bank_cd", ModelEntityUpdated); } }

        private string _account_no;
        public string account_no { get { return _account_no; } set { _account_no = value; RaisePropertyChanged("account_no", ModelEntityUpdated); } }

        private string _swift_code;
        public string swift_code { get { return _swift_code; } set { _swift_code = value; RaisePropertyChanged("swift_code", ModelEntityUpdated); } }

        private string _ifsc_code;
        public string ifsc_code { get { return _ifsc_code; } set { _ifsc_code = value; RaisePropertyChanged("ifsc_code", ModelEntityUpdated); } }

        private string _terms_cond;
        public string terms_cond { get { return _terms_cond; } set { _terms_cond = value; RaisePropertyChanged("terms_cond", ModelEntityUpdated); } }

        private Nullable<bool> _abg_flag;
        public Nullable<bool> abg_flag { get { return _abg_flag; } set { _abg_flag = value; RaisePropertyChanged("abg_flag", ModelEntityUpdated); } }

        private Nullable<int> _abg_days;
        public Nullable<int> abg_days { get { return _abg_days; } set { _abg_days = value; RaisePropertyChanged("abg_days", ModelEntityUpdated); } }

        private Nullable<System.DateTime> _abg_release_date;
        public Nullable<System.DateTime> abg_release_date { get { return _abg_release_date; } set { _abg_release_date = value; RaisePropertyChanged("abg_release_date", ModelEntityUpdated); } }

        private string _release_mode;
        public string release_mode { get { return _release_mode; } set { _release_mode = value; RaisePropertyChanged("release_mode", ModelEntityUpdated); } }

        private string _transporter;
        public string transporter { get { return _transporter; } set { _transporter = value; RaisePropertyChanged("transporter", ModelEntityUpdated); } }

        private string _gl_code;
        public string gl_code { get { return _gl_code; } set { _gl_code = value; RaisePropertyChanged("gl_code", ModelEntityUpdated); } }

        private Nullable<decimal> _round_up;
        public Nullable<decimal> round_up { get { return _round_up; } set { _round_up = value; RaisePropertyChanged("round_up", ModelEntityUpdated); } }

        private Nullable<decimal> _roundup_total;
        public Nullable<decimal> roundup_total { get { return _roundup_total; } set { _roundup_total = value; RaisePropertyChanged("roundup_total", ModelEntityUpdated); } }

        private string _sto_ind;
        public string sto_ind { get { return _sto_ind; } set { _sto_ind = value; RaisePropertyChanged("sto_ind", ModelEntityUpdated); } }

        private string _rec_plant;
        //[DisplayName("Receving plant Name")]
        //[Required(ErrorMessage = "Field 'Receving plant' is required.")]
        public string rec_plant { get { return _rec_plant; } set { _rec_plant = value; RaisePropertyChanged("rec_plant", ModelEntityUpdated); } }

        //Scalar Propertire
        private string _display_doc_type;
        public string display_doc_type { get { return _display_doc_type; } set { _display_doc_type = value; RaisePropertyChanged("display_doc_type", ModelEntityUpdated); } }

        private string _doc_type_user;
        public string doc_type_user { get { return _doc_type_user; } set { _doc_type_user = value; RaisePropertyChanged("doc_type_user", ModelEntityUpdated); } }

        private string _doc_desc;
        public string doc_desc { get { return _doc_desc; } set { _doc_desc = value; RaisePropertyChanged("doc_desc", ModelEntityUpdated); } }

        private string _BuyerName;
        public string BuyerName { get { return _BuyerName; } set { _BuyerName = value; RaisePropertyChanged("BuyerName", ModelEntityUpdated); } }

        private string _pur_org;
        public string pur_org { get { return _pur_org; } set { _pur_org = value; RaisePropertyChanged("pur_org", ModelEntityUpdated); } }

        private string _pg_name;
        public string pg_name { get { return _pg_name; } set { _pg_name = value; RaisePropertyChanged("pg_name", ModelEntityUpdated); } }

        private string _cost_center_Desc;
        public string cost_center_Desc { get { return _cost_center_Desc; } set { _cost_center_Desc = value; RaisePropertyChanged("cost_center_Desc", ModelEntityUpdated); } }

        private string _inco_desc;
        public string inco_desc { get { return _inco_desc; } set { _inco_desc = value; RaisePropertyChanged("inco_desc", ModelEntityUpdated); } }

        private string _wa_name;
        public string wa_name { get { return _wa_name; } set { _wa_name = value; RaisePropertyChanged("wa_name", ModelEntityUpdated); } }

        private string _validator_name;
        public string validator_name { get { return _validator_name; } set { _validator_name = value; RaisePropertyChanged("validator_name", ModelEntityUpdated); } }

        private string _PaymentTerms;
        public string PaymentTerms { get { return _PaymentTerms; } set { _PaymentTerms = value; RaisePropertyChanged("PaymentTerms", ModelEntityUpdated); } }

        private string _dcat_name;
        public string dcat_name { get { return _dcat_name; } set { _dcat_name = value; RaisePropertyChanged("dcat_name", ModelEntityUpdated); } }

        private string _supplyingplant_name;
        public string supplyingplant_name { get { return _supplyingplant_name; } set { _supplyingplant_name = value; RaisePropertyChanged("supplyingplant_name", ModelEntityUpdated); } }

        private string _rec_plant_name;
        public string rec_plant_name { get { return _rec_plant_name; } set { _rec_plant_name = value; RaisePropertyChanged("rec_plant_name", ModelEntityUpdated); } }

        private string _status_remark;
        public string status_remark { get { return _status_remark; } set { _status_remark = value; RaisePropertyChanged("status_remark", ModelEntityUpdated); } }

        private string _EmailId;
        public string EmailId
        { get { return _EmailId; } set { _EmailId = value; RaisePropertyChanged("EmailId", ModelEntityUpdated); } }
        private string _PersnEmailId;
        public string PersnEmailId
        { get { return _PersnEmailId; } set { _PersnEmailId = value; RaisePropertyChanged("PersnEmailId", ModelEntityUpdated); } }
        private string _doc_history_no;
        public string doc_history_no
        {
            get { return _doc_history_no; }
            set
            {
                _doc_history_no = value;
                RaisePropertyChanged("doc_history_no");
            }
        }
        private string _CSTNo;
        public string CSTNo
        {
            get { return _CSTNo; }
            set
            {
                _CSTNo = value;
                RaisePropertyChanged("CSTNo");
            }
        }
        private string _VATNo;
        public string VATNo
        {
            get { return _VATNo; }
            set
            {
                _VATNo = value;
                RaisePropertyChanged("VATNo");
            }
        }
        private string _PanNo;
        public string PanNo
        {
            get { return _PanNo; }
            set
            {
                _PanNo = value;
                RaisePropertyChanged("PanNo");
            }
        }
        private string _EccCode;
        public string EccCode
        {
            get { return _EccCode; }
            set
            {
                _EccCode = value;
                RaisePropertyChanged("EccCode");
            }
        }
        private string _TNo;
        public string TNo
        {
            get { return _TNo; }
            set
            {
                _TNo = value;
                RaisePropertyChanged("TNo");
            }
        }
        private Nullable<System.DateTime> _CSTDate;
        public Nullable<System.DateTime> CSTDate { get { return _CSTDate; } set { _CSTDate = value; RaisePropertyChanged("CSTDate", ModelEntityUpdated); } }
        private Nullable<System.DateTime> _VATDate;
        public Nullable<System.DateTime> VATDate { get { return _VATDate; } set { _VATDate = value; RaisePropertyChanged("VATDate", ModelEntityUpdated); } }

        private decimal? _order_limit;
        public decimal? order_limit
        {
            get { return _order_limit; }
            set
            {
                _order_limit = value;
                RaisePropertyChanged("order_limit");
            }
        }
        private bool? _order_limit_tax;
        public bool? order_limit_tax
        {
            get { return _order_limit_tax; }
            set
            {
                _order_limit_tax = value;
                RaisePropertyChanged("order_limit_tax");
            }
        }

        private string _incoterm2;
        public string incoterm2
        {
            get { return _incoterm2; }
            set
            { _incoterm2 = value; RaisePropertyChanged("incoterm2", ModelEntityUpdated); }
        }

        private Nullable<System.DateTime> _ref_date;
        public Nullable<System.DateTime> ref_date
        {
            get { return _ref_date; }
            set
            {
                if (value == null)
                {
                    _ref_date = DateTime.Now;
                }
                else
                {
                    _ref_date = value;
                }
                RaisePropertyChanged("ref_date");
            }
        }

        private string _fin_year;
        public string fin_year
        {
            get
            {
                return _fin_year;
            }

            set
            {
                _fin_year = value; RaisePropertyChanged("fin_year");
            }
        }

        private string _posting_period;
        public string posting_period
        {
            get
            {
                return _posting_period;
            }

            set
            {
                _posting_period = value; RaisePropertyChanged("posting_period");
            }
        }

        private string _store_code;
        public string store_code
        {
            get
            {
                return _store_code;
            }

            set
            {
                _store_code = value; RaisePropertyChanged("store_code");
            }
        }

        private string _para1;
        public string para1
        {
            get
            {
                return _para1;
            }

            set
            {
                _para1 = value; RaisePropertyChanged("para1");
            }
        }

        private string _para2;
        public string para2
        {
            get
            {
                return _para2;
            }

            set
            {
                _para2 = value; RaisePropertyChanged("para2");
            }
        }

        private string _para3;
        public string para3
        {
            get
            {
                return _para3;
            }

            set
            {
                _para3 = value; RaisePropertyChanged("para3");
            }
        }

        private string _pre_carrage;
        public string pre_carrage
        {
            get
            {
                return _pre_carrage;
            }

            set
            {
                _pre_carrage = value; RaisePropertyChanged("pre_carrage");
            }
        }

        private string _pre_carrage_place;
        public string pre_carrage_place
        {
            get
            {
                return _pre_carrage_place;
            }

            set
            {
                _pre_carrage_place = value; RaisePropertyChanged("pre_carrage_place");
            }
        }

        private string _country_code;
        public string country_code
        {
            get
            {
                return _country_code;
            }

            set
            {
                _country_code = value; RaisePropertyChanged("country_code");
            }
        }

        private string _port_load;
        public string port_load
        {
            get
            {
                return _port_load;
            }

            set
            {
                _port_load = value; RaisePropertyChanged("port_load");
            }
        }

        private string _port_desc;
        public string port_desc
        {
            get
            {
                return _port_desc;
            }

            set
            {
                _port_desc = value; RaisePropertyChanged("port_desc");
            }
        }

        private string _port_final;
        public string port_final
        {
            get
            {
                return _port_final;
            }

            set
            {
                _port_final = value; RaisePropertyChanged("port_final");
            }
        }

        private string _final_dest;
        public string final_dest
        {
            get
            {
                return _final_dest;
            }

            set
            {
                _final_dest = value; RaisePropertyChanged("final_dest");
            }
        }

        private string _ship_terms;
        public string ship_terms
        {
            get
            {
                return _ship_terms;
            }

            set
            {
                _ship_terms = value; RaisePropertyChanged("ship_terms");
            }
        }

        private string _lic_cod;
        public string lic_cod
        {
            get
            {
                return _lic_cod;
            }

            set
            {
                _lic_cod = value; RaisePropertyChanged("lic_cod");
            }
        }

        private string _adv_lic_cd;
        public string adv_lic_cd
        {
            get
            {
                return _adv_lic_cd;
            }

            set
            {
                _adv_lic_cd = value; RaisePropertyChanged("adv_lic_cd");
            }
        }

        private string _org_country_cd;
        public string org_country_cd
        {
            get
            {
                return _org_country_cd;
            }

            set
            {
                _org_country_cd = value; RaisePropertyChanged("org_country_cd");
            }
        }

        private string _pack_rem;
        public string pack_rem
        {
            get
            {
                return _pack_rem;
            }

            set
            {
                _pack_rem = value; RaisePropertyChanged("pack_rem");
            }
        }

        private string _ship_mark;
        public string ship_mark
        {
            get
            {
                return _ship_mark;
            }

            set
            {
                _ship_mark = value; RaisePropertyChanged("ship_mark");
            }
        }

        private string _tr_mode;
        public string tr_mode
        {
            get
            {
                return _tr_mode;
            }

            set
            {
                _tr_mode = value; RaisePropertyChanged("tr_mode");
            }
        }

        private string _tr_type;
        public string tr_type
        {
            get
            {
                return _tr_type;
            }

            set
            {
                _tr_type = value; RaisePropertyChanged("tr_type");
            }
        }

        //private string _local_export;
        //public string local_export
        //{
        //    get
        //    {
        //        return _local_export;
        //    }

        //    set
        //    {
        //        _local_export = value; RaisePropertyChanged("local_export");
        //    }
        //}
        private string _ind_trade;
        [Required(ErrorMessage = "Field 'Transaction Trade Type' is required.")]
        public string ind_trade
        {
            get
            {
                return _ind_trade;
            }
            set
            {
                if (_ind_trade != value)
                {
                    _ind_trade = value; RaisePropertyChanged("ind_trade", ModelEntityUpdated);

                }
            }
        }
        private decimal? _gross_wt;
        public decimal? gross_wt
        {
            get
            {
                return _gross_wt;
            }

            set
            {
                _gross_wt = value; RaisePropertyChanged("gross_wt");
            }
        }

        private decimal? _net_wt;
        public decimal? net_wt
        {
            get
            {
                return _net_wt;
            }

            set
            {
                _net_wt = value; RaisePropertyChanged("net_wt");
            }
        }

        private string _unit_code;
        public string unit_code
        {
            get
            {
                return _unit_code;
            }

            set
            {
                _unit_code = value; RaisePropertyChanged("unit_code");
            }
        }

        private string _volume_unit;
        public string volume_unit
        {
            get
            {
                return _volume_unit;
            }

            set
            {
                _volume_unit = value; RaisePropertyChanged("volume_unit");
            }
        }

        private string _ref_version;
        public string ref_version
        {
            get
            {
                return _ref_version;
            }

            set
            {
                _ref_version = value; RaisePropertyChanged("ref_version");
            }
        }

        private decimal? _volume;
        public decimal? volume
        {
            get
            {
                return _volume;
            }

            set
            {
                _volume = value; RaisePropertyChanged("volume");
            }
        }

        private string _vendor_bank_code;
        public string vendor_bank_code
        {
            get
            {
                return _vendor_bank_code;
            }

            set
            {
                _vendor_bank_code = value; RaisePropertyChanged("vendor_bank_code");
            }
        }

        private string _notify_party;
        public string notify_party
        {
            get
            {
                return _notify_party;
            }

            set
            {
                _notify_party = value; RaisePropertyChanged("notify_party");
            }
        }

        private string _shipping_mark;
        public string shipping_mark
        {
            get { return _shipping_mark; }
            set
            { _shipping_mark = value; RaisePropertyChanged("shipping_mark"); }
        }

        private string _insurance;
        public string insurance
        {
            get { return _insurance; }
            set
            { _insurance = value; RaisePropertyChanged("insurance"); }
        }

        private string _packing;
        public string packing
        {
            get { return _packing; }
            set
            { _packing = value; RaisePropertyChanged("packing"); }
        }

        private string _transhipment;
        public string transhipment
        {
            get { return _transhipment; }
            set
            { _transhipment = value; RaisePropertyChanged("transhipment"); }
        }

        private string _partshipment;
        public string partshipment
        {
            get { return _partshipment; }
            set
            { _partshipment = value; RaisePropertyChanged("partshipment"); }
        }

        private Nullable<System.DateTime> _shipment_date;
        public Nullable<System.DateTime> shipment_date
        {
            get { return _shipment_date; }
            set
            { _shipment_date = value; RaisePropertyChanged("shipment_date"); }
        }

        private Nullable<System.DateTime> _validity_date;
        public Nullable<System.DateTime> validity_date
        {
            get { return _validity_date; }
            set
            { _validity_date = value; RaisePropertyChanged("validity_date"); }
        }

        private string _payment_mode;
        public string payment_mode
        {
            get { return _payment_mode; }
            set
            { _payment_mode = value; RaisePropertyChanged("payment_mode"); }
        }

        private bool? _qty_percent;
        public bool? qty_percent
        {
            get
            {
                return _qty_percent;
            }

            set
            {
                _qty_percent = value; RaisePropertyChanged("qty_percent");
            }
        }

        private bool? _amt_percent;
        public bool? amt_percent
        {
            get
            {
                return _amt_percent;
            }

            set
            {
                _amt_percent = value; RaisePropertyChanged("amt_percent");
            }
        }

        private Nullable<int> _ref_party_contact;
        public Nullable<int> ref_party_contact
        {
            get { return _ref_party_contact; }
            set
            { _ref_party_contact = value; RaisePropertyChanged("ref_party_contact"); }
        }

        private string _ref_contact_name;
        public string ref_contact_name
        {
            get { return _ref_contact_name; }
            set
            { _ref_contact_name = value; RaisePropertyChanged("ref_contact_name"); }
        }

        
        private string _language;
        public string language
        {
            get { return _language; }
            set
            { _language = value; RaisePropertyChanged("language"); }
        }

        private string _remark1;
        public string remark1
        {
            get { return _remark1; }
            set
            { _remark1 = value; RaisePropertyChanged("remark1"); }

        }

        private string _remark2;
        public string remark2
        {
            get { return _remark2; }
            set
            { _remark2 = value; RaisePropertyChanged("remark2"); }

        }

        private string _remark3;
        public string remark3
        {
            get { return _remark3; }
            set
            { _remark3 = value; RaisePropertyChanged("remark3"); }

        }

        private string _remark4;
        public string remark4
        {
            get { return _remark4; }
            set
            { _remark4 = value; RaisePropertyChanged("remark4"); }

        }

        private string _location;
        public string location
        {
            get { return _location; }
            set
            { _location = value; RaisePropertyChanged("location"); }
        }

        private string _title;
        public string title
        {
            get { return _title; }
            set
            { _title = value; RaisePropertyChanged("title"); }
        }

        private decimal? _net_value;
        public decimal? net_value
        {
            get
            {
                return _net_value;
            }

            set
            {
                _net_value = value; RaisePropertyChanged("net_value");
            }
        }

        private string _withholding_tax;
        public string withholding_tax
        {
            get { return _withholding_tax; }
            set
            { _withholding_tax = value; RaisePropertyChanged("withholding_tax"); }
        }

        private decimal? _withholding_value;
        public decimal? withholding_value
        {
            get
            {
                return _withholding_value;
            }

            set
            {
                _withholding_value = value; RaisePropertyChanged("withholding_value");
            }
        }

        private string _note;
        public string note
        {
            get { return _note; }
            set
            { _note = value; RaisePropertyChanged("note"); }
        }

        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set
            { _lang_key = value; RaisePropertyChanged("lang_key"); }
        }

        private string _remark;
        public string remark
        {
            get { return _remark; }
            set
            { _remark = value; RaisePropertyChanged("remark"); }
        }

        private string _incoterms1;
        public string incoterms1
        {
            get { return _incoterms1; }
            set
            { _incoterms1 = value; RaisePropertyChanged("incoterms1"); }
        }

        private string _incoterms2;
        public string incoterms2
        {
            get { return _incoterms2; }
            set
            { _incoterms2 = value; RaisePropertyChanged("incoterms2"); }
        }

        private string _principal_no;
        public string principal_no
        {
            get { return _principal_no; }
            set
            { _principal_no = value; RaisePropertyChanged("principal_no"); }
        }

        private string _purchase_ind;
        public string purchase_ind
        {
            get { return _purchase_ind; }
            set
            { _purchase_ind = value; RaisePropertyChanged("purchase_ind"); }
        }

        private decimal? _local_amount_tax;
        public decimal? local_amount_tax
        {
            get
            {
                return _local_amount_tax;
            }

            set
            {
                _local_amount_tax = value; RaisePropertyChanged("local_amount_tax");
            }
        }

        private decimal? _local_amount_total;
        public decimal? local_amount_total
        {
            get
            {
                return _local_amount_total;
            }

            set
            {
                _local_amount_total = value; RaisePropertyChanged("local_amount_total");
            }
        }

        private decimal? _local_round_up;
        public decimal? local_round_up
        {
            get
            {
                return _local_round_up;
            }

            set
            {
                _local_round_up = value; RaisePropertyChanged("local_round_up");
            }
        }

        private decimal? _local_roundup_total;
        public decimal? local_roundup_total
        {
            get
            {
                return _local_roundup_total;
            }

            set
            {
                _local_roundup_total = value; RaisePropertyChanged("local_roundup_total");
            }
        }

        private decimal? _local_net_value;
        public decimal? local_net_value
        {
            get
            {
                return _local_net_value;
            }

            set
            {
                _local_net_value = value; RaisePropertyChanged("local_net_value");
            }
        }

        private decimal? _other_charges;
        public decimal? other_charges
        {
            get
            {
                return _other_charges;
            }

            set
            {
                _other_charges = value; RaisePropertyChanged("other_charges");
            }
        }

        private decimal? _withholding_ex_amt;
        public decimal? withholding_ex_amt
        {
            get
            {
                return _withholding_ex_amt;
            }

            set
            {
                _withholding_ex_amt = value; RaisePropertyChanged("withholding_ex_amt");
            }
        }
        private string _bom_no;
        public string bom_no
        {
            get
            {
                return _bom_no;
            }

            set
            {
                _bom_no = value; RaisePropertyChanged("bom_no");
            }
        }

        private decimal? _gross_value;
        public decimal? gross_value
        {
            get
            {
                return _gross_value;
            }

            set
            {
                _gross_value = value; RaisePropertyChanged("gross_value");
            }
        }

        private decimal? _effective_value;
        public decimal? effective_value
        {
            get
            {
                return _effective_value;
            }

            set
            {
                _effective_value = value; RaisePropertyChanged("effective_value");
            }
        }

        private decimal? _disc_amt;
        public decimal? disc_amt
        {
            get
            {
                return _disc_amt;
            }

            set
            {
                _disc_amt = value; RaisePropertyChanged("disc_amt");
            }
        }

        private decimal? _tax_amount;
        public decimal? tax_amount
        {
            get
            {
                return _tax_amount;
            }

            set
            {
                _tax_amount = value; RaisePropertyChanged("tax_amount");
            }
        }

        private string _EmpEmailId;
        public string EmpEmailId
        {
            get
            {
                return _EmpEmailId;
            }

            set
            {
                _EmpEmailId = value; RaisePropertyChanged("EmpEmailId");
            }
        }

        private string _EmpMobNo;
        public string EmpMobNo
        {
            get
            {
                return _EmpMobNo;
            }

            set
            {
                _EmpMobNo = value; RaisePropertyChanged("EmpMobNo");
            }
        }

        private string _PhNo;
        public string PhNo
        {
            get
            {
                return _PhNo;
            }

            set
            {
                _PhNo = value; RaisePropertyChanged("PhNo");
            }
        }

        private string _FaxNo;
        public string FaxNo
        {
            get
            {
                return _FaxNo;
            }

            set
            {
                _FaxNo = value; RaisePropertyChanged("FaxNo");
            }
        }

        private string _refer_by;
        public string refer_by
        {
            get
            {
                return _refer_by;
            }

            set
            {
                _refer_by = value; RaisePropertyChanged("refer_by");
            }
        }

        //Added by Priya
        private string _gst_PartyId;
        public string gst_PartyId
        {
            get { return _gst_PartyId; }
            set
            { _gst_PartyId = value; RaisePropertyChanged("gst_PartyId", ModelEntityUpdated); }

        }
        private string _buss_place;
        public string buss_place
        {
            get { return _buss_place; }
            set
            { _buss_place = value; RaisePropertyChanged("buss_place", ModelEntityUpdated); }

        }
        private string _plc_name;
        public string plc_name
        {
            get { return _plc_name; }
            set
            {
                _plc_name = value;
                RaisePropertyChanged("plc_name");
            }
        }
        private string _t_display;
        public string t_display
        {
            get { return _t_display; }
            set
            {
                if (_t_display != value)
                {
                    _t_display = value; RaisePropertyChanged("t_display");
                }
            }
        }

        private string _ts_code;
        public string ts_code
        {
            get { return _ts_code; }
            set
            { _ts_code = value; }

        }
        private string _shipping_address;
        public string shipping_address
        {
            get { return _shipping_address; }
            set
            {
                if (_shipping_address != value)
                {
                    _shipping_address = value; RaisePropertyChanged("shipping_address");
                }
            }
        }

        private string _add_code;
        public string add_code
        {
            get
            {
                return _add_code;
            }
            set
            {
                if (_add_code != value)
                {
                    _add_code = value; RaisePropertyChanged("add_code");
                }
            }
        }

        private string _add_code_del;
        public string add_code_del
        {
            get
            {
                return _add_code_del;
            }
            set
            {
                if (_add_code_del != value)
                {
                    _add_code_del = value; RaisePropertyChanged("add_code_del");
                }
            }
        }

        private string _add_code_bil;
        public string add_code_bil
        {
            get
            {
                return _add_code_bil;
            }
            set
            {
                if (_add_code_bil != value)
                {
                    _add_code_bil = value; RaisePropertyChanged("add_code_bil");
                }
            }
        }

        //GST by Priya
        public string STP_gstinno { get; set; }
        public string DTP_gstinno { get; set; }
        public Nullable<System.DateTime> STP_gstindate { get; set; }
        public Nullable<System.DateTime> DTP_gstindate { get; set; }
        public string STP_state_code { get; set; }
        public string DTP_state_code { get; set; }
        public string data1 { get; set; }
        public string owner_name { get; set; }
        public string DEmp_PhNo { get; set; }
        public string DEmp_FaxNo { get; set; }
        public string DEmp_EmailId { get; set; }
        public string PersnFName { get; set; }
        public string PersnLName { get; set; }
        public string PersnMobNo { get; set; }
        public string XmlDataDocument_PUR_T002_B { get; set; }
        public string XmlDataDocument_PUR_T002_C { get; set; }
        public string XmlDataDocument_PUR_T002_D { get; set; }
        public string XmlDataDocument_ACC_T006_B { get; set; }
        public string XmlDataDocument_PUR_T004_A { get; set; }
        public string XmlDataDocument_PUR_T004_B { get; set; }
        public string XmlDataDocument_PUR_T002_H { get; set; }
        public string XDOC_TC { get; set; }
        public string XmlDataDocument_ACC_T006_D { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }

        private string _delivery_address;
        public string delivery_address
        {
            get { return _delivery_address; }
            set
            {
                if (_delivery_address != value)
                {
                    _delivery_address = value; RaisePropertyChanged("delivery_address");
                }
            }
        }
        private string _billing_address;
        public string billing_address
        {
            get { return _billing_address; }
            set
            {
                if (_billing_address != value)
                {
                    _billing_address = value; RaisePropertyChanged("billing_address");
                }
            }
        }
        private string _tr_name;
        public string tr_name
        {
            get
            {
                return _tr_name;
            }

            set
            {
                if (_tr_name != value)
                {
                    _tr_name = value; RaisePropertyChanged("tr_name");
                }
            }
        }
        private string _letter_text;
        public string letter_text
        {
            get { return _letter_text; }
            set { if (_letter_text != value) { _letter_text = value; RaisePropertyChanged("letter_text"); } }
        }
        private string _body_text;
        public string body_text
        {
            get { return _body_text; }
            set { if (_body_text != value) { _body_text = value; RaisePropertyChanged("body_text"); } }
        }
        private string _header_text;
        public string header_text
        {
            get { return _header_text; }
            set { if (_header_text != value) { _header_text = value; RaisePropertyChanged("header_text"); } }
        }
        private string _footer_text;
        public string footer_text
        {
            get { return _footer_text; }
            set { if (_footer_text != value) { _footer_text = value; RaisePropertyChanged("footer_text"); } }
        }
        public string delivery_state_code { get; set; }
        public string billing_state_code { get; set; }
        public string delivery_GSTIN { get; set; }
        public string billing_GSTIN { get; set; }
        public string doc_format { get; set; }

        public string emp_id { get; set; }
        public string emp_name { get; set; }
        public string emp_mail { get; set; }
        public string emp_contact { get; set; }
        public string supplier_address { get; set; }
        private string _instructions;
        public string instructions
        {
            get { return _instructions; }
            set { if (_instructions != value)
                {
                    _instructions = value; RaisePropertyChanged("instructions");
                }
            }
        }
        private byte[] _sig;

        public byte[] sig
        {
            get { return _sig; }
            set
            {
                if (_sig != value)
                {
                    _sig = value;
                    RaisePropertyChanged("sig");
                }
            }
        }
    }
    public class PUR_T002_B : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        public int id { get { return _id; } set { _id = value; RaisePropertyChanged("id"); } }
        private string _po_no;
        public string po_no { get { return _po_no; } set { _po_no = value; RaisePropertyChanged("po_no", ModelEntityUpdated); } }

        private int _line_id;
        public int line_id { get { return _line_id; } set { _line_id = value; RaisePropertyChanged("line_id"); } }

        private string _ItemCode;
        [DisplayName("Item Code")]
        [Required(ErrorMessage = "Field 'ItemCode' is required.")]

        public string ItemCode
        {
            get { return _ItemCode; }
            set
            {
                if (_ItemCode != value)
                {
                    _ItemCode = value;
                    RaisePropertyChanged("ItemCode", ModelEntityUpdated);
                }
            }
        }

        private string _req_no;
        public string req_no { get { return _req_no; } set { _req_no = value; RaisePropertyChanged("req_no"); } }

        private int _planning_line_id;
        public int planning_line_id { get { return _planning_line_id; } set { _planning_line_id = value; RaisePropertyChanged("planning_line_id"); } }

        private string _item_cat;
        public string item_cat { get { return _item_cat; } set { _item_cat = value; RaisePropertyChanged("item_cat"); } }

        private string _description;
        public string description { get { return _description; } set { _description = value; RaisePropertyChanged("description", ModelEntityUpdated); } }

        private string _sku;
        public string sku { get { return _sku; } set { _sku = value; RaisePropertyChanged("sku", ModelEntityUpdated); } }

        private string _sku_desc { get; set; }
        public string sku_desc { get { return _sku_desc; } set { _sku_desc = value; RaisePropertyChanged("sku_desc", ModelEntityUpdated); } }

        private Nullable<decimal> _qty;
        [Required(ErrorMessage = "Field 'Quantity' is required.")]
        [ValidInteger(ErrorMessage = "Invalid Numeric data")]
        public Nullable<decimal> qty { get { return _qty; } set { _qty = value; RaisePropertyChanged("qty", ModelEntityUpdated); } }

        private string _unit_code;

        [Required(ErrorMessage = "Field 'Unit of Measurement' is required.")]
        [ValidValue(ErrorMessage = "Invalid input of 'Unit of Measurement'.")]
        public string unit_code { get { return _unit_code; } set { _unit_code = value; RaisePropertyChanged("unit_code", ModelEntityUpdated); } }

        private Nullable<decimal> _unit_price;
        [Required(ErrorMessage = "Field 'Unit Price' is required.")]
        [ValidInteger(ErrorMessage = "Invalid Numeric data")]
        public Nullable<decimal> unit_price { get { return _unit_price; } set { _unit_price = value ?? 0; RaisePropertyChanged("unit_price", ModelEntityUpdated); } }

        private string _tax_id;
        public string tax_id { get { return _tax_id; } set { _tax_id = value; RaisePropertyChanged("tax_id", ModelEntityUpdated); } }

        private Nullable<decimal> _discount;
        public Nullable<decimal> discount { get { return _discount; }
            set
            {
                if (_discount != value)
                {
                    _discount = value; RaisePropertyChanged("discount", ModelEntityUpdated);
                }
            } }

        private Nullable<decimal> _sub_total;
        public Nullable<decimal> sub_total { get { return _sub_total; } set { _sub_total = value; RaisePropertyChanged("sub_total"); } }

        private string _move_dest_id;
        public string move_dest_id { get { return _move_dest_id; } set { _move_dest_id = value; RaisePropertyChanged("move_dest_id"); } }

        private string _PartyId;
        public string PartyId { get { return _PartyId; } set { _PartyId = value; RaisePropertyChanged("PartyId"); } }

        private Nullable<bool> _invoiced;
        public Nullable<bool> invoiced { get { return _invoiced; } set { _invoiced = value; RaisePropertyChanged("invoiced"); } }

        private Nullable<System.DateTime> _date_planned;
        public Nullable<System.DateTime> date_planned { get { return _date_planned; } set { _date_planned = value; RaisePropertyChanged("date_planned"); } }

        private string _acc_code;
        public string acc_code { get { return _acc_code; } set { _acc_code = value; RaisePropertyChanged("acc_code"); } }

        private string _batch_no;
        public string batch_no { get { return _batch_no; } set { _batch_no = value; RaisePropertyChanged("batch_no"); } }

        private Nullable<bool> _batch_split_allow;
        public Nullable<bool> batch_split_allow { get { return _batch_split_allow; } set { _batch_split_allow = value; RaisePropertyChanged("batch_split_allow"); } }

        private Nullable<decimal> _conversn_fact;
        public Nullable<decimal> conversn_fact { get { return _conversn_fact; } set { _conversn_fact = value; RaisePropertyChanged("conversn_fact"); } }

        private Nullable<decimal> _gross_wt;
        public Nullable<decimal> gross_wt { get { return _gross_wt; } set { _gross_wt = value; RaisePropertyChanged("gross_wt"); } }

        private Nullable<decimal> _net_wt;
        public Nullable<decimal> net_wt { get { return _net_wt; } set { _net_wt = value; RaisePropertyChanged("net_wt"); } }

        private string _weight_unit;
        public string weight_unit { get { return _weight_unit; } set { _weight_unit = value; RaisePropertyChanged("weight_unit"); } }

        private Nullable<decimal> _volume;
        public Nullable<decimal> volume { get { return _volume; } set { _volume = value; RaisePropertyChanged("volume"); } }

        private string _vol_unit;
        public string vol_unit { get { return _vol_unit; } set { _vol_unit = value; RaisePropertyChanged("vol_unit"); } }

        private string _store_code;
        public string store_code { get { return _store_code; } set { _store_code = value; RaisePropertyChanged("store_code"); } }

        private string _gr_ind;
        public string gr_ind { get { return _gr_ind; } set { _gr_ind = value; RaisePropertyChanged("gr_ind"); } }

        private string _inv_ind;
        public string inv_ind { get { return _inv_ind; } set { _inv_ind = value; RaisePropertyChanged("inv_ind"); } }

        private string _rfq_no;
        public string rfq_no { get { return _rfq_no; } set { _rfq_no = value; RaisePropertyChanged("rfq_no"); } }

        private Nullable<int> _rfq_item_no;
        public Nullable<int> rfq_item_no { get { return _rfq_item_no; } set { _rfq_item_no = value; RaisePropertyChanged("rfq_item_no"); } }

        private string _pur_req_no;
        public string pur_req_no { get { return _pur_req_no; } set { _pur_req_no = value; RaisePropertyChanged("pur_req_no"); } }

        private Nullable<int> _pur_req_item;
        public Nullable<int> pur_req_item { get { return _pur_req_item; } set { _pur_req_item = value; RaisePropertyChanged("pur_req_item"); } }

        private Nullable<int> _pur_req_item_row_id;
        public Nullable<int> pur_req_item_row_id { get { return _pur_req_item_row_id; } set { _pur_req_item_row_id = value; RaisePropertyChanged("pur_req_item_row_id"); } }

        private string _issue_store_code;
        public string issue_store_code { get { return _issue_store_code; } set { _issue_store_code = value; RaisePropertyChanged("issue_store_code"); } }

        private string _t_status;
        public string t_status { get { return _t_status; } set { _t_status = value; RaisePropertyChanged("t_status"); } }

        private string _comp_code;
        public string comp_code { get { return _comp_code; } set { _comp_code = value; RaisePropertyChanged("comp_code"); } }

        private string _location_Id;
        public string location_Id { get { return _location_Id; } set { _location_Id = value; RaisePropertyChanged("location_Id"); } }

        private Nullable<bool> _active;
        public Nullable<bool> active { get { return _active; } set { _active = value; RaisePropertyChanged("active"); } }

        private string _add_by;
        public string add_by { get { return _add_by; } set { _add_by = value; RaisePropertyChanged("add_by"); } }

        private System.DateTime _add_date;
        public System.DateTime add_date { get { return _add_date; } set { _add_date = value; RaisePropertyChanged("add_date"); } }

        private string _editby;
        public string editby { get { return _editby; } set { _editby = value; RaisePropertyChanged("editby"); } }

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date { get { return _edit_date; } set { _edit_date = value; RaisePropertyChanged("edit_date"); } }

        private string _bid_inv_no;
        public string bid_inv_no { get { return _bid_inv_no; } set { _bid_inv_no = value; RaisePropertyChanged("bid_inv_no"); } }

        private string _quotation_no;
        public string quotation_no { get { return _quotation_no; } set { _quotation_no = value; RaisePropertyChanged("quotation_no"); } }

        private Nullable<decimal> _shrot_excess_amt;
        public Nullable<decimal> shrot_excess_amt { get { return _shrot_excess_amt; } set { _shrot_excess_amt = value; RaisePropertyChanged("shrot_excess_amt"); } }

        private string _shrot_excess_flag;
        public string shrot_excess_flag { get { return _shrot_excess_flag; } set { _shrot_excess_flag = value; RaisePropertyChanged("shrot_excess_flag"); } }

        private string _delivery_ind;
        public string delivery_ind { get { return _delivery_ind; } set { _delivery_ind = value; RaisePropertyChanged("delivery_ind"); } }

        private string _gr_inv_ind;
        public string gr_inv_ind { get { return _gr_inv_ind; } set { _gr_inv_ind = value; RaisePropertyChanged("gr_inv_ind"); } }

        private string _order_ack_ind;
        public string order_ack_ind { get { return _order_ack_ind; } set { _order_ack_ind = value; RaisePropertyChanged("order_ack_ind"); } }

        private string _order_ack_no;
        public string order_ack_no { get { return _order_ack_no; } set { _order_ack_no = value; RaisePropertyChanged("order_ack_no"); } }

        private Nullable<System.DateTime> _order_ack_date;
        public Nullable<System.DateTime> order_ack_date { get { return _order_ack_date; } set { _order_ack_date = value; RaisePropertyChanged("order_ack_date"); } }

        private Nullable<bool> _acknowledged;
        public Nullable<bool> acknowledged { get { return _acknowledged; } set { _acknowledged = value; RaisePropertyChanged("acknowledged"); } }

        private string _pur_agree_no;
        public string pur_agree_no { get { return _pur_agree_no; } set { _pur_agree_no = value; RaisePropertyChanged("pur_agree_no"); } }

        private Nullable<int> _pur_agree_item_cd;
        public Nullable<int> pur_agree_item_cd { get { return _pur_agree_item_cd; } set { _pur_agree_item_cd = value; RaisePropertyChanged("pur_agree_item_cd"); } }

        private string _ref_doc_no;
        public string ref_doc_no { get { return _ref_doc_no; } set { _ref_doc_no = value; RaisePropertyChanged("ref_doc_no"); } }

        private Nullable<System.DateTime> _ref_doc_date;
        public Nullable<System.DateTime> ref_doc_date { get { return _ref_doc_date; } set { _ref_doc_date = value; RaisePropertyChanged("ref_doc_date"); } }

        public string _ref_doc_type;
        public string ref_doc_type { get { return _ref_doc_type; } set { _ref_doc_type = value; RaisePropertyChanged("ref_doc_type"); } }

        public string _cust_mat_no;
        public string cust_mat_no { get { return _cust_mat_no; } set { _cust_mat_no = value; RaisePropertyChanged("cust_mat_no"); } }

        public Nullable<decimal> _abs_deviation_qty;
        public Nullable<decimal> abs_deviation_qty { get { return _abs_deviation_qty; } set { _abs_deviation_qty = value; RaisePropertyChanged("abs_deviation_qty"); } }

        public Nullable<decimal> _per_deviation_qty;
        public Nullable<decimal> per_deviation_qty { get { return _per_deviation_qty; } set { _per_deviation_qty = value; RaisePropertyChanged("per_deviation_qty"); } }

        public Nullable<decimal> _over_del_tol;
        public Nullable<decimal> over_del_tol { get { return _over_del_tol; } set { _over_del_tol = value; RaisePropertyChanged("over_del_tol"); } }

        public Nullable<decimal> _under_del_tol;
        public Nullable<decimal> under_del_tol { get { return _under_del_tol; } set { _under_del_tol = value; RaisePropertyChanged("under_del_tol"); } }

        private string _batch_split;
        public string batch_split { get { return _batch_split; } set { _batch_split = value; RaisePropertyChanged("batch_split"); } }

        public string _p_term_code;
        public string p_term_code { get { return _p_term_code; } set { _p_term_code = value; RaisePropertyChanged("p_term_code"); } }

        public string _terms_cond;
        public string terms_cond { get { return _terms_cond; } set { _terms_cond = value; RaisePropertyChanged("terms_cond"); } }

        public string _serviceNo;
        public string serviceNo { get { return _serviceNo; } set { _serviceNo = value; RaisePropertyChanged("serviceNo"); } }

        public string _gl_code;
        public string gl_code { get { return _gl_code; } set { _gl_code = value; RaisePropertyChanged("gl_code"); } }

        public string _incoterms;
        public string incoterms { get { return _incoterms; } set { _incoterms = value; RaisePropertyChanged("incoterms"); } }

        private string _rec_plant;
        public string rec_plant { get { return _rec_plant; } set { _rec_plant = value; RaisePropertyChanged("rec_plant"); } }

        private string _supplying_plant;
        public string supplying_plant { get { return _supplying_plant; } set { _supplying_plant = value; RaisePropertyChanged("supplying_plant"); } }

        private string _status_remark;
        public string status_remark { get { return _status_remark; } set { _status_remark = value; RaisePropertyChanged("status_remark"); } }
        private string _remark;
        public string remark { get { return _remark; } set { _remark = value; RaisePropertyChanged("remark"); } }
        private string _textdata;
        public string textdata
        {
            get
            {
                return _textdata;
            }

            set
            {
                _textdata = value; RaisePropertyChanged("textdata");
            }
        }

        private int _ref_item_line_id;
        public int ref_item_line_id
        {
            get
            {
                return _ref_item_line_id;
            }

            set
            {
                _ref_item_line_id = value; RaisePropertyChanged("ref_item_line_id");
            }
        }
        private string _account_analytic_id;
        public string account_analytic_id
        {
            get
            {
                return _account_analytic_id;
            }

            set
            {
                _account_analytic_id = value; RaisePropertyChanged("account_analytic_id");
            }
        }
        private string _wa_code;
        public string wa_code
        {
            get
            {
                return _wa_code;
            }

            set
            {
                _wa_code = value; RaisePropertyChanged("wa_code");
            }
        }
        private string _para1;
        public string para1
        {
            get
            {
                return _para1;
            }

            set
            {
                _para1 = value; RaisePropertyChanged("para1");
            }
        }
        private string _para2;
        public string para2
        {
            get
            {
                return _para2;
            }

            set
            {
                _para2 = value; RaisePropertyChanged("para2");
            }
        }
        private string _para3;
        public string para3
        {
            get
            {
                return _para3;
            }

            set
            {
                _para3 = value; RaisePropertyChanged("para3");
            }
        }
        private int? _para4;
        public int? para4
        {
            get
            {
                return _para4;
            }

            set
            {
                _para4 = value; RaisePropertyChanged("para4");
            }
        }
        private string _para5;
        public string para5
        {
            get
            {
                return _para5;
            }

            set
            {
                _para5 = value; RaisePropertyChanged("para5");
            }
        }
        private string _para6;
        public string para6
        {
            get
            {
                return _para6;
            }

            set
            {
                _para6 = value; RaisePropertyChanged("para6");
            }
        }
        private string _para7;
        public string para7
        {
            get
            {
                return _para7;
            }

            set
            {
                _para7 = value; RaisePropertyChanged("para7");
            }
        }
        private decimal? _para8;
        public decimal? para8
        {
            get
            {
                return _para8;
            }

            set
            {
                _para8 = value; RaisePropertyChanged("para8");
            }
        }
        private string _para9;
        public string para9
        {
            get
            {
                return _para9;
            }

            set
            {
                _para9 = value; RaisePropertyChanged("para9");
            }
        }
        private string _para10;
        public string para10
        {
            get
            {
                return _para10;
            }

            set
            {
                _para10 = value; RaisePropertyChanged("para10");
            }
        }
        private string _para11;
        public string para11
        {
            get
            {
                return _para11;
            }

            set
            {
                _para11 = value; RaisePropertyChanged("para11");
            }
        }
        private bool? _para12;
        public bool? para12
        {
            get
            {
                return _para12;
            }

            set
            {
                _para12 = value; RaisePropertyChanged("para12");
            }
        }
        private DateTime? _para13;
        public DateTime? para13
        {
            get
            {
                return _para13;
            }

            set
            {
                _para13 = value; RaisePropertyChanged("para13");
            }
        }
        private string _para14;
        public string para14
        {
            get
            {
                return _para14;
            }

            set
            {
                _para14 = value; RaisePropertyChanged("para14");
            }
        }
        private string _para15;
        public string para15
        {
            get
            {
                return _para15;
            }

            set
            {
                _para15 = value; RaisePropertyChanged("para15");
            }
        }
        private string _para16;
        public string para16
        {
            get
            {
                return _para16;
            }

            set
            {
                _para16 = value; RaisePropertyChanged("para16");
            }
        }
        private decimal? _para17;
        public decimal? para17
        {
            get
            {
                return _para17;
            }

            set
            {
                _para17 = value; RaisePropertyChanged("para17");
            }
        }
        private string _para18;
        public string para18
        {
            get
            {
                return _para18;
            }

            set
            {
                _para18 = value; RaisePropertyChanged("para18");
            }
        }
        private string _para19;
        public string para19
        {
            get
            {
                return _para19;
            }

            set
            {
                _para19 = value; RaisePropertyChanged("para19");
            }
        }
        private string _para20;
        public string para20
        {
            get
            {
                return _para20;
            }

            set
            {
                _para20 = value; RaisePropertyChanged("para20");
            }
        }
        private string _para21;
        public string para21
        {
            get
            {
                return _para21;
            }

            set
            {
                _para21 = value; RaisePropertyChanged("para21");
            }
        }
        private string _para22;
        public string para22
        {
            get
            {
                return _para22;
            }

            set
            {
                _para22 = value; RaisePropertyChanged("para22");
            }
        }
        private string _para23;
        public string para23
        {
            get
            {
                return _para23;
            }

            set
            {
                _para23 = value; RaisePropertyChanged("para23");
            }
        }
        private int? _para24;
        public int? para24
        {
            get
            {
                return _para24;
            }

            set
            {
                _para24 = value; RaisePropertyChanged("para24");
            }
        }
        private string _para25;
        public string para25
        {
            get
            {
                return _para25;
            }

            set
            {
                _para25 = value; RaisePropertyChanged("para25");
            }
        }
        private string _para26;
        public string para26
        {
            get
            {
                return _para26;
            }

            set
            {
                _para26 = value; RaisePropertyChanged("para26");
            }
        }
        private string _para27;
        public string para27
        {
            get
            {
                return _para27;
            }

            set
            {
                _para27 = value; RaisePropertyChanged("para27");
            }
        }
        private int? _para28;
        public int? para28
        {
            get
            {
                return _para28;
            }

            set
            {
                _para28 = value; RaisePropertyChanged("para28");
            }
        }
        private string _cust_ref;
        public string cust_ref
        {
            get
            {
                return _cust_ref;
            }

            set
            {
                _cust_ref = value; RaisePropertyChanged("cust_ref");
            }
        }
        private DateTime? _cust_ref_date;
        public DateTime? cust_ref_date
        {
            get
            {
                return _cust_ref_date;
            }

            set
            {
                _cust_ref_date = value; RaisePropertyChanged("cust_ref_date");
            }
        }
        private int? _pack_style;
        public int? pack_style
        {
            get
            {
                return _pack_style;
            }

            set
            {
                _pack_style = value; RaisePropertyChanged("pack_style");
            }
        }
        private string _fin_year;
        public string fin_year
        {
            get
            {
                return _fin_year;
            }

            set
            {
                _fin_year = value; RaisePropertyChanged("fin_year");
            }
        }
        private string _posting_period;
        public string posting_period
        {
            get
            {
                return _posting_period;
            }

            set
            {
                _posting_period = value; RaisePropertyChanged("posting_period");
            }
        }
        private string _rel_delivery;
        public string rel_delivery
        {
            get
            {
                return _rel_delivery;
            }

            set
            {
                _rel_delivery = value; RaisePropertyChanged("rel_delivery");
            }
        }
        private string _rel_billing;
        public string rel_billing
        {
            get
            {
                return _rel_billing;
            }

            set
            {
                _rel_billing = value; RaisePropertyChanged("rel_billing");
            }
        }
        private int? _item_no_ref_item;
        public int? item_no_ref_item
        {
            get
            {
                return _item_no_ref_item;
            }

            set
            {
                _item_no_ref_item = value; RaisePropertyChanged("item_no_ref_item");
            }
        }
        private decimal? _net_value;
        public decimal? net_value
        {
            get
            {
                return _net_value;
            }

            set
            {
                _net_value = value; RaisePropertyChanged("net_value");
            }
        }

        private int? _source_doc_item_id;
        public int? source_doc_item_id
        {
            get
            {
                return _source_doc_item_id;
            }

            set
            {
                _source_doc_item_id = value; RaisePropertyChanged("source_doc_item_id");
            }
        }

        private int? _order_doc_item_id;
        public int? order_doc_item_id
        {
            get
            {
                return _order_doc_item_id;
            }

            set
            {
                _order_doc_item_id = value; RaisePropertyChanged("order_doc_item_id");
            }
        }

        private int? _ref_sales_item_id;
        public int? ref_sales_item_id
        {
            get
            {
                return _ref_sales_item_id;
            }

            set
            {
                _ref_sales_item_id = value; RaisePropertyChanged("ref_sales_item_id");
            }
        }

        private string _ref_order_no;
        public string ref_order_no
        {
            get
            {
                return _ref_order_no;
            }

            set
            {
                _ref_order_no = value; RaisePropertyChanged("ref_order_no");
            }
        }

        private int? _sales_item_line_id;
        public int? sales_item_line_id
        {
            get
            {
                return _sales_item_line_id;
            }

            set
            {
                _sales_item_line_id = value; RaisePropertyChanged("sales_item_line_id");
            }
        }

        private string _sono;
        public string sono
        {
            get
            {
                return _sono;
            }

            set
            {
                _sono = value; RaisePropertyChanged("sono");
            }
        }

        private string _recipient_location;
        public string recipient_location
        {
            get
            {
                return _recipient_location;
            }

            set
            {
                _recipient_location = value; RaisePropertyChanged("recipient_location");
            }
        }

        private string _requester_name;
        public string requester_name
        {
            get
            {
                return _requester_name;
            }

            set
            {
                _requester_name = value; RaisePropertyChanged("requester_name");
            }
        }

        private int? _per_req_item_id;
        public int? per_req_item_id
        {
            get
            {
                return _per_req_item_id;
            }

            set
            {
                _per_req_item_id = value; RaisePropertyChanged("per_req_item_id");
            }
        }

        private string _pkgs_no;
        public string pkgs_no
        {
            get
            {
                return _pkgs_no;
            }

            set
            {
                _pkgs_no = value; RaisePropertyChanged("pkgs_no");
            }
        }

        private string _incoterms1;
        public string incoterms1
        {
            get
            {
                return _incoterms1;
            }

            set
            {
                _incoterms1 = value; RaisePropertyChanged("incoterms1");
            }
        }

        private string _incoterms2;
        public string incoterms2
        {
            get
            {
                return _incoterms2;
            }

            set
            {
                _incoterms2 = value; RaisePropertyChanged("incoterms2");
            }
        }


        private string _shipping_inst;
        public string shipping_inst
        {
            get
            {
                return _shipping_inst;
            }

            set
            {
                _shipping_inst = value; RaisePropertyChanged("shipping_inst");
            }
        }

        private string _inter_article_no;
        public string inter_article_no
        {
            get
            {
                return _inter_article_no;
            }

            set
            {
                _inter_article_no = value; RaisePropertyChanged("inter_article_no");
            }
        }

        private string _base_unit;
        public string base_unit
        {
            get
            {
                return _base_unit;
            }

            set
            {
                _base_unit = value; RaisePropertyChanged("base_unit");
            }
        }

        private string _valuation_cat;
        public string valuation_cat
        {
            get
            {
                return _valuation_cat;
            }

            set
            {
                _valuation_cat = value; RaisePropertyChanged("valuation_cat");
            }
        }

        private string _valuation_type;
        public string valuation_type
        {
            get
            {
                return _valuation_type;
            }

            set
            {
                _valuation_type = value; RaisePropertyChanged("valuation_type");
            }
        }

        private decimal? _underdelivery_limit;
        public decimal? underdelivery_limit
        {
            get
            {
                return _underdelivery_limit;
            }

            set
            {
                _underdelivery_limit = value; RaisePropertyChanged("underdelivery_limit");
            }
        }

        private string _overdelivery_ind;
        public string overdelivery_ind
        {
            get
            {
                return _overdelivery_ind;
            }

            set
            {
                _overdelivery_ind = value; RaisePropertyChanged("overdelivery_ind");
            }
        }

        private decimal? _overdelivery_limit;
        public decimal? overdelivery_limit
        {
            get
            {
                return _overdelivery_limit;
            }

            set
            {
                _overdelivery_limit = value; RaisePropertyChanged("overdelivery_limit");
            }
        }

        private int? _day_reminder1;
        public int? day_reminder1
        {
            get
            {
                return _day_reminder1;
            }

            set
            {
                _day_reminder1 = value; RaisePropertyChanged("day_reminder1");
            }
        }

        private int? _day_reminder2;
        public int? day_reminder2
        {
            get
            {
                return _day_reminder2;
            }

            set
            {
                _day_reminder2 = value; RaisePropertyChanged("day_reminder2");
            }
        }

        private int? _day_reminder3;
        public int? day_reminder3
        {
            get
            {
                return _day_reminder3;
            }

            set
            {
                _day_reminder3 = value; RaisePropertyChanged("day_reminder3");
            }
        }

        private decimal? _cumulative_qty;
        public decimal? cumulative_qty
        {
            get
            {
                return _cumulative_qty;
            }

            set
            {
                _cumulative_qty = value; RaisePropertyChanged("cumulative_qty");
            }
        }

        private DateTime? _reconciliation_date;
        public DateTime? reconciliation_date
        {
            get
            {
                return _reconciliation_date;
            }

            set
            {
                _reconciliation_date = value; RaisePropertyChanged("reconciliation_date");
            }
        }

        private decimal? _cash_disc_per1;
        public decimal? cash_disc_per1
        {
            get
            {
                return _cash_disc_per1;
            }

            set
            {
                _cash_disc_per1 = value; RaisePropertyChanged("cash_disc_per1");
            }
        }

        private decimal? _cash_disc_per2;
        public decimal? cash_disc_per2
        {
            get
            {
                return _cash_disc_per2;
            }

            set
            {
                _cash_disc_per2 = value; RaisePropertyChanged("cash_disc_per2");
            }
        }

        private decimal? _cash_disc_per3;
        public decimal? cash_disc_per3
        {
            get
            {
                return _cash_disc_per3;
            }

            set
            {
                _cash_disc_per3 = value; RaisePropertyChanged("cash_disc_per3");
            }
        }

        private int? _cash_disc_days1;
        public int? cash_disc_days1
        {
            get
            {
                return _cash_disc_days1;
            }

            set
            {
                _cash_disc_days1 = value; RaisePropertyChanged("cash_disc_days1");
            }
        }

        private int? _cash_disc_days2;
        public int? cash_disc_days2
        {
            get
            {
                return _cash_disc_days2;
            }

            set
            {
                _cash_disc_days2 = value; RaisePropertyChanged("cash_disc_days2");
            }
        }

        private int? _cash_disc_days3;
        public int? cash_disc_days3
        {
            get
            {
                return _cash_disc_days3;
            }

            set
            {
                _cash_disc_days3 = value; RaisePropertyChanged("cash_disc_days3");
            }
        }

        private string _principal_no;
        public string principal_no
        {
            get
            {
                return _principal_no;
            }

            set
            {
                _principal_no = value; RaisePropertyChanged("principal_no");
            }
        }


        private string _principal_item_no;
        public string principal_item_no
        {
            get
            {
                return _principal_item_no;
            }

            set
            {
                _principal_item_no = value; RaisePropertyChanged("principal_item_no");
            }
        }

        private decimal? _local_discount;
        public decimal? local_discount
        {
            get
            {
                return _local_discount;
            }

            set
            {
                _local_discount = value; RaisePropertyChanged("local_discount");
            }
        }

        private decimal? _local_sub_total;
        public decimal? local_sub_total
        {
            get
            {
                return _local_sub_total;
            }

            set
            {
                _local_sub_total = value; RaisePropertyChanged("local_sub_total");
            }
        }

        private decimal? _local_net_value;
        public decimal? local_net_value
        {
            get
            {
                return _local_net_value;
            }

            set
            {
                _local_net_value = value; RaisePropertyChanged("local_net_value");
            }
        }

        private string _bom_no;
        public string bom_no
        {
            get
            {
                return _bom_no;
            }

            set
            {
                _bom_no = value; RaisePropertyChanged("bom_no");
            }
        }
        private string _symbol;
        public string symbol
        {
            get { return _symbol; }
            set { _symbol = value; RaisePropertyChanged("symbol"); }
        }

        private Nullable<decimal> _gross_value;
        public Nullable<decimal> gross_value
        {
            get { return _gross_value; }
            set { _gross_value = value; RaisePropertyChanged("gross_value"); }
        }

        private Nullable<decimal> _effective_value;
        public Nullable<decimal> effective_value
        {
            get { return _effective_value; }
            set { _effective_value = value; RaisePropertyChanged("effective_value"); }
        }

        private Nullable<decimal> _tax_amount;
        public Nullable<decimal> tax_amount
        {
            get { return _tax_amount; }
            set { _tax_amount = value; RaisePropertyChanged("tax_amount"); }
        }

        private string _discount_type;
        public string discount_type
        {
            get { return _discount_type; }
            set
            {
                if (value == null)
                {
                    _discount_type = value; RaisePropertyChanged("discount_type", ModelEntityUpdated);
                }
                else if (_discount_type != value.ToUpper())
                {
                    _discount_type = (value ?? "P").ToUpper(); RaisePropertyChanged("discount_type", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _discount_amt;
        public Nullable<decimal> discount_amt
        {
            get { return _discount_amt; }
            set
            {
                if (_discount_amt != value)
                {
                    _discount_amt = value; RaisePropertyChanged("discount_amt", ModelEntityUpdated);
                }
            }
        }

        private string _article_no;
        public string article_no
        {
            get { return _article_no; }
            set { _article_no = value; RaisePropertyChanged("article_no"); }
        }

        private Nullable<int> _ref_item_row_id;
        public Nullable<int> ref_item_row_id
        {
            get { return _ref_item_row_id; }
            set { _ref_item_row_id = value; RaisePropertyChanged("ref_item_row_id"); }
        }

        private Nullable<int> _planning_row_id;
        public Nullable<int> planning_row_id
        {
            get { return _planning_row_id; }
            set { _planning_row_id = value; RaisePropertyChanged("planning_row_id"); }
        }

        private Nullable<int> _per_req_item_row_id;
        public Nullable<int> per_req_item_row_id
        {
            get { return _per_req_item_row_id; }
            set { _per_req_item_row_id = value; RaisePropertyChanged("per_req_item_row_id"); }
        }

        private Nullable<int> _pur_agree_item_row_id;
        public Nullable<int> pur_agree_item_row_id
        {
            get { return _pur_agree_item_row_id; }
            set { _pur_agree_item_row_id = value; RaisePropertyChanged("pur_agree_item_row_id"); }
        }

        private Nullable<int> _source_doc_item_row_id;
        public Nullable<int> source_doc_item_row_id
        {
            get { return _source_doc_item_row_id; }
            set { _source_doc_item_row_id = value; RaisePropertyChanged("source_doc_item_row_id"); }
        }

        private Nullable<int> _order_doc_item_row_id;
        public Nullable<int> order_doc_item_row_id
        {
            get { return _order_doc_item_row_id; }
            set { _order_doc_item_row_id = value; RaisePropertyChanged("order_doc_item_row_id"); }
        }

        private string _Mat_Condition;
        public string Mat_Condition
        {
            get { return _Mat_Condition; }
            set { _Mat_Condition = value; RaisePropertyChanged("Mat_Condition"); }
        }

        private string _Type;
        public string Type
        {
            get { return _Type; }
            set { _Type = value; RaisePropertyChanged("Type"); }
        }

        private string _Make;
        public string Make
        {
            get { return _Make; }
            set { _Make = value; RaisePropertyChanged("Make"); }
        }

        //Added by Priya
        private string _planning_no;
        public string planning_no
        {
            get { return _planning_no; }
            set { _planning_no = value; RaisePropertyChanged("planning_no"); }
        }
        private string _notify_party;
        public string notify_party
        {
            get { return _notify_party; }
            set { _notify_party = value; RaisePropertyChanged("notify_party"); }
        }

        private Nullable<int> _service_id;
        public Nullable<int> service_id
        {
            get { return _service_id; }
            set { _service_id = value; RaisePropertyChanged("service_id"); }
        }
        private string _rfq_status;
        public string rfq_status
        {
            get { return _rfq_status; }
            set { _rfq_status = value; RaisePropertyChanged("rfq_status"); }
        }

        private Nullable<decimal> _num_order_unit;
        public Nullable<decimal> num_order_unit
        {
            get { return _num_order_unit; }
            set { _num_order_unit = value; RaisePropertyChanged("num_order_unit"); }
        }
        private Nullable<decimal> _denum_order_unit;
        public Nullable<decimal> denum_order_unit
        {
            get { return _denum_order_unit; }
            set { _denum_order_unit = value; RaisePropertyChanged("denum_order_unit"); }
        }
        private Nullable<decimal> _num_order_base_unit;
        public Nullable<decimal> num_order_base_unit
        {
            get { return _num_order_base_unit; }
            set { _num_order_base_unit = value; RaisePropertyChanged("num_order_base_unit"); }
        }
        private Nullable<decimal> _denum_order_base_unit;
        public Nullable<decimal> denum_order_base_unit
        {
            get { return _denum_order_base_unit; }
            set { _denum_order_base_unit = value; RaisePropertyChanged("denum_order_base_unit"); }
        }
        private string _ild_ul_del;
        public string ild_ul_del
        {
            get { return _ild_ul_del; }
            set { _ild_ul_del = value; RaisePropertyChanged("ild_ul_del"); }
        }
        private string _ind_rej;
        public string ind_rej
        {
            get { return _ind_rej; }
            set { _ind_rej = value; RaisePropertyChanged("ind_rej"); }
        }
        private string _ind_del_completed;
        public string ind_del_completed
        {
            get { return _ind_del_completed; }
            set { _ind_del_completed = value; RaisePropertyChanged("ind_del_completed"); }
        }
        private string _ind_invoice_final;
        public string ind_invoice_final
        {
            get { return _ind_invoice_final; }
            set { _ind_invoice_final = value; RaisePropertyChanged("ind_invoice_final"); }
        }
        private string _assign_no;
        public string assign_no
        {
            get { return _assign_no; }
            set { _assign_no = value; RaisePropertyChanged("assign_no"); }
        }
        private string _ind_gr_inv_verify;
        public string ind_gr_inv_verify
        {
            get { return _ind_gr_inv_verify; }
            set { _ind_gr_inv_verify = value; RaisePropertyChanged("ind_gr_inv_verify"); }
        }
        private string _budget_code;
        public string budget_code
        {
            get { return _budget_code; }
            set { _budget_code = value; RaisePropertyChanged("budget_code"); }
        }
        private string _cost_center;
        public string cost_center
        {
            get { return _cost_center; }
            set { _cost_center = value; RaisePropertyChanged("cost_center"); }
        }
        private string _profit_center;
        public string profit_center
        {
            get { return _profit_center; }
            set { _profit_center = value; RaisePropertyChanged("profit_center"); }
        }
        private string _time_zone;
        public string time_zone
        {
            get { return _time_zone; }
            set { _time_zone = value; RaisePropertyChanged("time_zone"); }
        }
        private string _tracking_no;
        public string tracking_no
        {
            get { return _tracking_no; }
            set { _tracking_no = value; RaisePropertyChanged("tracking_no"); }
        }



        private decimal? _bal_qty;

        public decimal? bal_qty
        {
            get
            {
                return _bal_qty;
            }

            set
            {
                _bal_qty = value; RaisePropertyChanged("bal_qty", ModelEntityUpdated);
            }
        }
        private string _bill_address_id { get; set; }
        public string bill_address_id
        {
            get
            {
                return _bill_address_id;
            }

            set
            {
                if (_bill_address_id != value)
                {
                    _bill_address_id = value;
                    RaisePropertyChanged("bill_address_id");
                }
            }
        }
        private string _del_address_id { get; set; }
        public string del_address_id
        {
            get
            {
                return _del_address_id;
            }

            set
            {
                if (_del_address_id != value)
                {
                    _del_address_id = value;
                    RaisePropertyChanged("del_address_id");
                }
            }
        }
        private string _buss_place { get; set; }
        public string buss_place
        {
            get
            {
                return _buss_place;
            }

            set
            {
                _buss_place = value; RaisePropertyChanged("buss_place");
            }
        }
        private string _hs_code { get; set; }
        public string hs_code
        {
            get
            {
                return _hs_code;
            }

            set
            {
                _hs_code = value; RaisePropertyChanged("hs_code");
            }
        }
        private string _hsn_code { get; set; }
        public string hsn_code
        {
            get
            {
                return _hsn_code;
            }

            set
            {
                _hsn_code = value; RaisePropertyChanged("hsn_code");
            }
        }
        private string _hsn_code2 { get; set; }
        public string hsn_code2
        {
            get
            {
                return _hsn_code2;
            }

            set
            {
                _hsn_code2 = value; RaisePropertyChanged("hsn_code2");
            }
        }
        private string _t_display;
        public string t_display
        {
            get { return _t_display; }
            set
            {
                if (_t_display != value)
                {
                    _t_display = value; RaisePropertyChanged("t_display");
                }
            }
        }
        //GST
        public string hs_code2 { get; set; }



    }
    public class PUR_T002_C : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int _id;
        public int id { get { return _id; } set { _id = value; RaisePropertyChanged("id"); } }
        private int _line_id;
        public int line_id { get { return _line_id; } set { _line_id = value; RaisePropertyChanged("line_id"); } }
        private int _ref_item_line_id;
        public int ref_item_line_id { get { return _ref_item_line_id; } set { _ref_item_line_id = value; RaisePropertyChanged("ref_item_line_id"); } }
        private string _po_no;
        public string po_no
        {
            get { return _po_no; }
            set { _po_no = value; RaisePropertyChanged("po_no"); }
        }

        private Nullable<int> _po_item_row_id;
        public Nullable<int> po_item_row_id { get { return _po_item_row_id; } set { _po_item_row_id = value; RaisePropertyChanged("po_item_row_id"); } }
        private Nullable<int> _sch_row_id;
        public Nullable<int> sch_row_id { get { return _sch_row_id; } set { _sch_row_id = value; RaisePropertyChanged("sch_row_id"); } }

        private bool? _active;
        public bool? active { get { return _active; } set { _active = value; RaisePropertyChanged("active"); } }
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set
            {
                if (_t_status != value)
                {
                    _t_status = value; RaisePropertyChanged("t_status");
                }
            }
        }
        
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                if (_comp_code != value)
                {
                    _comp_code = value; RaisePropertyChanged("comp_code");
                }
            }
        }
        private string _location_id;
        public string location_id
        {
            get { return _location_id; }
            set
            {
                if (_location_id != value)
                {
                    _location_id = value; RaisePropertyChanged("location_id");
                }
            }
        }
        private string _item_code;
        public string item_code
        {
            get { return _item_code; }
            set
            {
                if (_item_code != value)
                {
                    _item_code = value; RaisePropertyChanged("item_code");
                }
            }
        }
        private string _sku;
        public string sku
        {
            get { return _sku; }
            set
            {
                if (_sku != value)
                {
                    _sku = value; RaisePropertyChanged("sku");
                }
            }
        }
        private string _store_code;
        public string store_code
        {
            get { return _store_code; }
            set
            {
                if (_store_code != value)
                {
                    _store_code = value; RaisePropertyChanged("store_code");
                }
            }
        }
        private string _batch_no;
        public string batch_no
        {
            get { return _batch_no; }
            set
            {
                if (_batch_no != value)
                {
                    _batch_no = value; RaisePropertyChanged("batch_no");
                }
            }
        }
        private decimal _qty;
        public decimal qty
        {
            get { return _qty; }
            set
            {
                if (_qty != value)
                {
                    _qty = value; RaisePropertyChanged("qty");
                }
            }
        }
        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set
            {
                if (_unit_code != value)
                {
                    _unit_code = value; RaisePropertyChanged("unit_code");
                }
            }
        }
        private string _reserv_no;
        public string reserv_no
        {
            get { return _reserv_no; }
            set
            {
                if (_reserv_no != value)
                {
                    _reserv_no = value; RaisePropertyChanged("reserv_no");
                }
            }
        }
        private int? _reserv_item_row_id;
        public int? reserv_item_row_id
        {
            get { return _reserv_item_row_id; }
            set
            {
                if (_reserv_item_row_id != value)
                {
                    _reserv_item_row_id = value; RaisePropertyChanged("reserv_item_row_id");
                }
            }
        }
        private string _record_type;
        public string record_type
        {
            get { return _record_type; }
            set
            {
                if (_record_type != value)
                {
                    _record_type = value; RaisePropertyChanged("record_type");
                }
            }
        }
        private string _requirement_type;
        public string requirement_type
        {
            get { return _requirement_type; }
            set
            {
                if (_requirement_type != value)
                {
                    _requirement_type = value; RaisePropertyChanged("requirement_type");
                }
            }
        }
        private string _bom_no;
        public string bom_no
        {
            get { return _bom_no; }
            set
            {
                if (_bom_no != value)
                {
                    _bom_no = value; RaisePropertyChanged("bom_no");
                }
            }
        }
        private int? _bom_item_row_id;
        public int? bom_item_row_id
        {
            get { return _bom_item_row_id; }
            set
            {
                if (_bom_item_row_id != value)
                {
                    _bom_item_row_id = value; RaisePropertyChanged("bom_item_row_id");
                }
            }
        }
        private string _routing_no;
        public string routing_no
        {
            get { return _routing_no; }
            set
            {
                if (_routing_no != value)
                {
                    _routing_no = value; RaisePropertyChanged("routing_no");
                }
            }
        }
        private int? _op_seq;
        public int? op_seq
        {
            get { return _op_seq; }
            set
            {
                if (_op_seq != value)
                {
                    _op_seq = value; RaisePropertyChanged("op_seq");
                }
            }
        }
        private string _operation_no;
        public string operation_no
        {
            get { return _operation_no; }
            set
            {
                if (_operation_no != value)
                {
                    _operation_no = value; RaisePropertyChanged("operation_no");
                }
            }
        }
        private int? _plan_counter;
        public int? plan_counter
        {
            get { return _plan_counter; }
            set
            {
                if (_plan_counter != value)
                {
                    _plan_counter = value; RaisePropertyChanged("plan_counter");
                }
            }
        }
        private string _object_no;
        public string object_no
        {
            get { return _object_no; }
            set
            {
                if (_object_no != value)
                {
                    _object_no = value; RaisePropertyChanged("object_no");
                }
            }
        }
        private decimal _op_scrap;
        public decimal op_scrap
        {
            get { return _op_scrap; }
            set
            {
                if (_op_scrap != value)
                {
                    _op_scrap = value; RaisePropertyChanged("op_scrap");
                }
            }
        }
        private decimal _comp_scrap;
        public decimal comp_scrap
        {
            get { return _comp_scrap; }
            set
            {
                if (_comp_scrap != value)
                {
                    _comp_scrap = value; RaisePropertyChanged("comp_scrap");
                }
            }
        }
        private string _order_no;
        public string order_no
        {
            get { return _order_no; }
            set
            {
                if (_order_no != value)
                {
                    _order_no = value; RaisePropertyChanged("order_no");
                }
            }
        }
        private int? _order_item_row_id;
        public int? order_item_row_id
        {
            get { return _order_item_row_id; }
            set
            {
                if (_order_item_row_id != value)
                {
                    _order_item_row_id = value; RaisePropertyChanged("order_item_row_id");
                }
            }
        }


        // Scalar Fields
        private string _item_name;
        public string item_name
        {
            get { return _item_name; }
            set
            {
                if (_item_name != value)
                {
                    _item_name = value; RaisePropertyChanged("item_name");
                }
            }
        }
        private string _sku_desc;
        public string sku_desc
        {
            get { return _sku_desc; }
            set
            {
                if (_sku_desc != value)
                {
                    _sku_desc = value; RaisePropertyChanged("sku_desc");
                }
            }
        }
        private string _t_display;
        public string t_display
        {
            get { return _t_display; }
            set
            {
                if (_t_display != value)
                {
                    _t_display = value; RaisePropertyChanged("t_display");
                }
            }
        }
    }
    public class PUR_T002_D : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int _id { get; set; }
        public int id { get { return _id; } set { _id = value; RaisePropertyChanged("id", ModelEntityUpdated); } }

        private string _req_no;
        public string req_no { get { return _req_no; } set { _req_no = value; RaisePropertyChanged("req_no", ModelEntityUpdated); } }

        private Nullable<decimal> _tax_amount { get; set; }
        public Nullable<decimal> tax_amount { get { return _tax_amount; } set { _tax_amount = value; RaisePropertyChanged("tax_amount", ModelEntityUpdated); } }

        private Nullable<int> _account_id { get; set; }
        public Nullable<int> account_id { get { return _account_id; } set { _account_id = value; RaisePropertyChanged("account_id", ModelEntityUpdated); } }

        private Nullable<int> _sequence { get; set; }
        public Nullable<int> sequence { get { return _sequence; } set { _sequence = value; RaisePropertyChanged("sequence", ModelEntityUpdated); } }

        private string _doc_no { get; set; }
        public string doc_no { get { return _doc_no; } set { _doc_no = value; RaisePropertyChanged("doc_no", ModelEntityUpdated); } }

        private string _manual { get; set; }
        public string manual { get { return _manual; } set { _manual = value; RaisePropertyChanged("manual", ModelEntityUpdated); } }

        private Nullable<decimal> _base_amount { get; set; }
        public Nullable<decimal> base_amount { get { return _base_amount; } set { _base_amount = value; RaisePropertyChanged("base_amount", ModelEntityUpdated); } }

        private Nullable<decimal> _amount { get; set; }
        public Nullable<decimal> amount { get { return _amount; } set { _amount = value; RaisePropertyChanged("amount", ModelEntityUpdated); } }

        private Nullable<decimal> @base_;
        public Nullable<decimal> @base { get { return @base_; } set { @base_ = value; RaisePropertyChanged("@base", ModelEntityUpdated); } }

        private Nullable<int> _tax_code_id { get; set; }
        public Nullable<int> tax_code_id { get { return _tax_code_id; } set { _tax_code_id = value; RaisePropertyChanged("tax_code_id", ModelEntityUpdated); } }

        private Nullable<int> _account_analytic_id { get; set; }
        public Nullable<int> account_analytic_id { get { return _account_analytic_id; } set { _account_analytic_id = value; RaisePropertyChanged("account_analytic_id", ModelEntityUpdated); } }

        private Nullable<int> _base_code_id { get; set; }
        public Nullable<int> base_code_id { get { return _base_code_id; } set { _base_code_id = value; RaisePropertyChanged("base_code_id", ModelEntityUpdated); } }

        private string _tax_name;
        public string tax_name { get { return _tax_name; } set { _tax_name = value; RaisePropertyChanged("tax_name", ModelEntityUpdated); } }

        private string _gl_code { get; set; }
        public string gl_code { get { return _gl_code; } set { _gl_code = value; RaisePropertyChanged("gl_code", ModelEntityUpdated); } }

        private string _ItemCode { get; set; }
        public string ItemCode { get { return _ItemCode; } set { _ItemCode = value; RaisePropertyChanged("ItemCode", ModelEntityUpdated); } }

        private string _sku { get; set; }
        public string sku { get { return _sku; } set { _sku = value; RaisePropertyChanged("sku", ModelEntityUpdated); } }

        private int _item_line_id { get; set; }
        public int item_line_id { get { return _item_line_id; } set { _item_line_id = value; RaisePropertyChanged("item_line_id", ModelEntityUpdated); } }

        private int _fin_year { get; set; }
        public int fin_year { get { return _fin_year; } set { _fin_year = value; RaisePropertyChanged("fin_year", ModelEntityUpdated); } }

        private bool _active { get; set; }
        public bool active { get { return _active; } set { _active = value; RaisePropertyChanged("active", ModelEntityUpdated); } }

        private string _location_Id { get; set; }
        public string location_Id { get { return _location_Id; } set { _location_Id = value; RaisePropertyChanged("location_Id", ModelEntityUpdated); } }
        private string _comp_code { get; set; }
        public string comp_code { get { return _comp_code; } set { _comp_code = value; RaisePropertyChanged("comp_code", ModelEntityUpdated); } }
        private string _dc_ind { get; set; }
        public string dc_ind { get { return _dc_ind; } set { _dc_ind = value; RaisePropertyChanged("dc_ind"); } }
        private string _curr_code { get; set; }
        public string curr_code { get { return _curr_code; } set { _curr_code = value; RaisePropertyChanged("curr_code"); } }
        private Nullable<decimal> _exch_rate { get; set; }
        public Nullable<decimal> exch_rate { get { return _exch_rate; } set { _exch_rate = value; RaisePropertyChanged("exch_rate"); } }
        private string _local_curr { get; set; }
        public string local_curr { get { return _local_curr; } set { _local_curr = value; RaisePropertyChanged("local_curr"); } }
        private Nullable<decimal> _amt_local_curr { get; set; }
        public Nullable<decimal> amt_local_curr { get { return _amt_local_curr; } set { _amt_local_curr = value; RaisePropertyChanged("amt_local_curr"); } }
        private string _fix_per { get; set; }
        public string fix_per { get { return _fix_per; } set { _fix_per = value; RaisePropertyChanged("fix_per"); } }
        private string _symbol;
        public string symbol
        {
            get { return _symbol; }
            set { _symbol = value; RaisePropertyChanged("symbol"); }
        }
        private string _t_display;
        public string t_display
        {
            get { return _t_display; }
            set
            {
                if (_t_display != value)
                {
                    _t_display = value; RaisePropertyChanged("t_display");
                }
            }
        }
    }
    public class PUR_T002_E : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    RaisePropertyChanged("id", ModelEntityUpdated);
                }
            }
        }

        private Nullable<int> _po_line_id;
        public Nullable<int> po_line_id
        {
            get { return _po_line_id; }
            set
            {
                if (_po_line_id != value)
                {
                    _po_line_id = value;
                    RaisePropertyChanged("po_line_id", ModelEntityUpdated);
                }
            }
        }

        private string _po_no;
        public string po_no
        {
            get { return _po_no; }
            set
            {
                if (_po_no != value)
                {
                    _po_no = value;
                    RaisePropertyChanged("po_no", ModelEntityUpdated);
                }
            }
        }

        private Nullable<int> _invoice_id;
        public Nullable<int> invoice_id
        {
            get { return _invoice_id; }
            set
            {
                if (_invoice_id != value)
                {
                    _invoice_id = value;
                    RaisePropertyChanged("invoice_id", ModelEntityUpdated);
                }
            }
        }

        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                if (_doc_no != value)
                {
                    _doc_no = value;
                    RaisePropertyChanged("doc_no", ModelEntityUpdated);
                }
            }
        }
    }
    public class PUR_T002_F : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _ID;
        public int ID
        {
            get { return _ID; }
            set
            {
                if (_ID != value)
                {
                    _ID = value;
                    RaisePropertyChanged("ID", ModelEntityUpdated);
                }
            }
        }

        private string _product_uom;
        public string product_uom
        {
            get { return _product_uom; }
            set
            {
                if (_product_uom != value)
                {
                    _product_uom = value;
                    RaisePropertyChanged("product_uom", ModelEntityUpdated);
                }
            }
        }

        private Nullable<int> _sequence;
        public Nullable<int> sequence
        {
            get { return _sequence; }
            set
            {
                if (_sequence != value)
                {
                    _sequence = value;
                    RaisePropertyChanged("sequence", ModelEntityUpdated);
                }
            }
        }

        private Nullable<System.DateTime> _date_start;
        public Nullable<System.DateTime> date_start
        {
            get { return _date_start; }
            set
            {
                if (_date_start != value)
                {
                    _date_start = value;
                    RaisePropertyChanged("date_start", ModelEntityUpdated);
                }
            }
        }

        private Nullable<System.DateTime> _date_end;
        public Nullable<System.DateTime> date_end
        {
            get { return _date_end; }
            set
            {
                if (_date_end != value)
                {
                    _date_end = value;
                    RaisePropertyChanged("date_end", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _duration;
        public Nullable<decimal> duration
        {
            get { return _duration; }
            set
            {
                if (_duration != value)
                {
                    _duration = value;
                    RaisePropertyChanged("duration", ModelEntityUpdated);
                }
            }
        }

        private Nullable<System.DateTime> _constraint_date_end;
        public Nullable<System.DateTime> constraint_date_end
        {
            get { return _constraint_date_end; }
            set
            {
                if (_constraint_date_end != value)
                {
                    _constraint_date_end = value;
                    RaisePropertyChanged("constraint_date_end", ModelEntityUpdated);
                }
            }
        }

        private Nullable<System.DateTime> _constraint_date_start;
        public Nullable<System.DateTime> constraint_date_start
        {
            get { return _constraint_date_start; }
            set
            {
                if (_constraint_date_start != value)
                {
                    _constraint_date_start = value;
                    RaisePropertyChanged("constraint_date_start", ModelEntityUpdated);
                }
            }
        }

        private string _name;
        public string name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    RaisePropertyChanged("name", ModelEntityUpdated);
                }
            }
        }

        private string _project_id;
        public string project_id
        {
            get { return _project_id; }
            set
            {
                if (_project_id != value)
                {
                    _project_id = value;
                    RaisePropertyChanged("project_id", ModelEntityUpdated);
                }
            }
        }

        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set
            {
                if (_t_status != value)
                {
                    _t_status = value;
                    RaisePropertyChanged("t_status", ModelEntityUpdated);
                }
            }
        }

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set
            {
                if (_add_by != value)
                {
                    _add_by = value;
                    RaisePropertyChanged("add_by", ModelEntityUpdated);
                }
            }
        }

        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date
        {
            get { return _add_date; }
            set
            {
                if (_add_date != value)
                {
                    _add_date = value;
                    RaisePropertyChanged("add_date", ModelEntityUpdated);
                }
            }
        }

        private string _editby;
        public string editby
        {
            get { return _editby; }
            set
            {
                if (_editby != value)
                {
                    _editby = value;
                    RaisePropertyChanged("editby", ModelEntityUpdated);
                }
            }
        }

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                if (_edit_date != value)
                {
                    _edit_date = value;
                    RaisePropertyChanged("edit_date", ModelEntityUpdated);
                }
            }
        }
    }
    public class PUR_T002_G : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    RaisePropertyChanged("id", ModelEntityUpdated);
                }
            }
        }

        private string _po_no;
        public string po_no
        {
            get { return _po_no; }
            set
            {
                if (_po_no != value)
                {
                    _po_no = value;
                    RaisePropertyChanged("po_no", ModelEntityUpdated);
                }
            }
        }

        private Nullable<System.DateTime> _approve_dt;
        public Nullable<System.DateTime> approve_dt
        {
            get { return _approve_dt; }
            set
            {
                if (_approve_dt != value)
                {
                    _approve_dt = value;
                    RaisePropertyChanged("approve_dt", ModelEntityUpdated);
                }
            }
        }

        private Nullable<bool> _approve_status;
        public Nullable<bool> approve_status
        {
            get { return _approve_status; }
            set
            {
                if (_approve_status != value)
                {
                    _approve_status = value;
                    RaisePropertyChanged("approve_status", ModelEntityUpdated);
                }
            }
        }


        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set
            {
                if (_add_by != value)
                {
                    _add_by = value;
                    RaisePropertyChanged("add_by", ModelEntityUpdated);
                }
            }
        }

        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set
            {
                if (_add_date != value)
                {
                    _add_date = value;
                    RaisePropertyChanged("add_date", ModelEntityUpdated);
                }
            }
        }

        private string _editby;
        public string editby
        {
            get { return _editby; }
            set
            {
                if (_editby != value)
                {
                    _editby = value;
                    RaisePropertyChanged("editby", ModelEntityUpdated);
                }
            }
        }

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                if (_edit_date != value)
                {
                    _edit_date = value;
                    RaisePropertyChanged("edit_date", ModelEntityUpdated);
                }
            }
        }
    }
    public class PUR_T002_H : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private string _tc_code;
        private int _id;
        private Nullable<int> _sequence_code;
        private string _doc_no;
        private string _doc_cat;
        private string _doc_type;
        private Nullable<System.DateTime> _doc_date;
        private string _comp_code;
        private string _location_Id;
        private string _PartyId;
        private string _sg_code;
        private string _so_code;
        private string _CatCode;
        private string _ItemTypeCd;
        private string _ItemCode;
        private Nullable<int> _sequence1;
        private Nullable<int> _sequence2;
        private Nullable<int> _sequence3;
        private string _short_text;
        private string _long_text;
        private string _unit_code;
        private Nullable<bool> _compulsory;
        private string _language_code;
        private string _con_type;
        private string _con_desc;
        private string _info_group;
        private string _info_desc;
        private string _info_sub_group;
        private string _info_sub_desc;
        private Nullable<bool> _active;
        private string _add_by;
        private System.DateTime _add_date;
        private string _editby;
        private Nullable<System.DateTime> _edit_date;

        public string tc_code
        {
            get
            {
                return _tc_code;
            }

            set
            {
                _tc_code = value; RaisePropertyChanged("tc_code", ModelEntityUpdated);
            }
        }

        public int id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value; RaisePropertyChanged("id", ModelEntityUpdated);
            }
        }

        public int? sequence_code
        {
            get
            {
                return _sequence_code;
            }

            set
            {
                _sequence_code = value; RaisePropertyChanged("sequence_code", ModelEntityUpdated);
            }
        }

        public string doc_no
        {
            get
            {
                return _doc_no;
            }

            set
            {
                _doc_no = value; RaisePropertyChanged("doc_no", ModelEntityUpdated);
            }
        }

        public string doc_cat
        {
            get
            {
                return _doc_cat;
            }

            set
            {
                _doc_cat = value; RaisePropertyChanged("doc_cat", ModelEntityUpdated);
            }
        }

        public string doc_type
        {
            get
            {
                return _doc_type;
            }

            set
            {
                _doc_type = value; RaisePropertyChanged("doc_type", ModelEntityUpdated);
            }
        }

        public DateTime? doc_date
        {
            get
            {
                return _doc_date;
            }

            set
            {
                _doc_date = value; RaisePropertyChanged("doc_date", ModelEntityUpdated);
            }
        }

        public string comp_code
        {
            get
            {
                return _comp_code;
            }

            set
            {
                _comp_code = value; RaisePropertyChanged("comp_code", ModelEntityUpdated);
            }
        }

        public string location_Id
        {
            get
            {
                return _location_Id;
            }

            set
            {
                _location_Id = value; RaisePropertyChanged("location_Id", ModelEntityUpdated);
            }
        }

       
        public string PartyId
        {
            get
            {
                return _PartyId;
            }

            set
            {
                _PartyId = value; RaisePropertyChanged("PartyId", ModelEntityUpdated);
            }
        }

        public string sg_code
        {
            get
            {
                return _sg_code;
            }

            set
            {
                _sg_code = value; RaisePropertyChanged("sg_code", ModelEntityUpdated);
            }
        }

        public string so_code
        {
            get
            {
                return _so_code;
            }

            set
            {
                _so_code = value; RaisePropertyChanged("so_code", ModelEntityUpdated);
            }
        }

        public string CatCode
        {
            get
            {
                return _CatCode;
            }

            set
            {
                _CatCode = value; RaisePropertyChanged("CatCode", ModelEntityUpdated);
            }
        }

        public string ItemTypeCd
        {
            get
            {
                return _ItemTypeCd;
            }

            set
            {
                _ItemTypeCd = value; RaisePropertyChanged("ItemTypeCd", ModelEntityUpdated);
            }
        }

        public string ItemCode
        {
            get
            {
                return _ItemCode;
            }

            set
            {
                _ItemCode = value; RaisePropertyChanged("ItemCode", ModelEntityUpdated);
            }
        }

        public int? sequence1
        {
            get
            {
                return _sequence1;
            }

            set
            {
                _sequence1 = value; RaisePropertyChanged("sequence1", ModelEntityUpdated);
            }
        }

        public int? sequence2
        {
            get
            {
                return _sequence2;
            }

            set
            {
                _sequence2 = value; RaisePropertyChanged("sequence2", ModelEntityUpdated);
            }
        }

        public int? sequence3
        {
            get
            {
                return _sequence3;
            }

            set
            {
                _sequence3 = value; RaisePropertyChanged("sequence3", ModelEntityUpdated);
            }
        }

        public string short_text
        {
            get
            {
                return _short_text;
            }

            set
            {
                _short_text = value; RaisePropertyChanged("short_text", ModelEntityUpdated);
            }
        }

        public string long_text
        {
            get
            {
                return _long_text;
            }

            set
            {
                _long_text = value; RaisePropertyChanged("long_text", ModelEntityUpdated);
            }
        }

        public string unit_code
        {
            get
            {
                return _unit_code;
            }

            set
            {
                _unit_code = value; RaisePropertyChanged("unit_code", ModelEntityUpdated);
            }
        }

        public bool? compulsory
        {
            get
            {
                return _compulsory;
            }

            set
            {
                _compulsory = value; RaisePropertyChanged("compulsory", ModelEntityUpdated);
            }
        }

        public string language_code
        {
            get
            {
                return _language_code;
            }

            set
            {
                _language_code = value; RaisePropertyChanged("language_code", ModelEntityUpdated);
            }
        }

        public string con_type
        {
            get
            {
                return _con_type;
            }

            set
            {
                _con_type = value; RaisePropertyChanged("con_type", ModelEntityUpdated);
            }
        }

        public string con_desc
        {
            get
            {
                return _con_desc;
            }

            set
            {
                _con_desc = value; RaisePropertyChanged("con_desc", ModelEntityUpdated);
            }
        }

        public string info_group
        {
            get
            {
                return _info_group;
            }

            set
            {
                _info_group = value; RaisePropertyChanged("info_group", ModelEntityUpdated);
            }
        }

        public string info_desc
        {
            get
            {
                return _info_desc;
            }

            set
            {
                _info_desc = value; RaisePropertyChanged("info_desc", ModelEntityUpdated);
            }
        }

        public string info_sub_group
        {
            get
            {
                return _info_sub_group;
            }

            set
            {
                _info_sub_group = value; RaisePropertyChanged("info_sub_group", ModelEntityUpdated);
            }
        }

        public string info_sub_desc
        {
            get
            {
                return _info_sub_desc;
            }

            set
            {
                _info_sub_desc = value; RaisePropertyChanged("info_sub_desc", ModelEntityUpdated);
            }
        }

        public bool? active
        {
            get
            {
                return _active;
            }

            set
            {
                _active = value; RaisePropertyChanged("active", ModelEntityUpdated);
            }
        }

        public string add_by
        {
            get
            {
                return _add_by;
            }

            set
            {
                _add_by = value; RaisePropertyChanged("add_by", ModelEntityUpdated);
            }
        }

        public DateTime add_date
        {
            get
            {
                return _add_date;
            }

            set
            {
                _add_date = value; RaisePropertyChanged("add_date", ModelEntityUpdated);
            }
        }

        public string editby
        {
            get
            {
                return _editby;
            }

            set
            {
                _editby = value; RaisePropertyChanged("editby", ModelEntityUpdated);
            }
        }

        public DateTime? edit_date
        {
            get
            {
                return _edit_date;
            }

            set
            {
                _edit_date = value; RaisePropertyChanged("edit_date", ModelEntityUpdated);
            }
        }
    }
    public class PUR_T004_A : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int _id;
        public int id { get { return _id; } set { _id = value; RaisePropertyChanged("id", ModelEntityUpdated); } }

        private string _sch_no;
        public string sch_no { get { return _sch_no; } set { _sch_no = value; RaisePropertyChanged("sch_no", ModelEntityUpdated); } }

        private Nullable<System.DateTime> _sch_date;
        public Nullable<System.DateTime> sch_date { get { return _sch_date; } set { _sch_date = value; RaisePropertyChanged("sch_date", ModelEntityUpdated); } }

        private string _sch_mode;
        public string sch_mode { get { return _sch_mode; } set { _sch_mode = value; RaisePropertyChanged("sch_mode", ModelEntityUpdated); } }

        private string _PartyId;
        public string PartyId { get { return _PartyId; } set { _PartyId = value; RaisePropertyChanged("PartyId", ModelEntityUpdated); } }

        private string _t_status;
        public string t_status { get { return _t_status; } set { _t_status = value; RaisePropertyChanged("t_status", ModelEntityUpdated); } }

        private string _location_Id;
        public string location_Id { get { return _location_Id; } set { _location_Id = value; RaisePropertyChanged("location_Id", ModelEntityUpdated); } }

        private Nullable<bool> _active;
        public Nullable<bool> active { get { return _active; } set { _active = value; RaisePropertyChanged("active", ModelEntityUpdated); } }

        private string _add_by;
        public string add_by { get { return _add_by; } set { _add_by = value; RaisePropertyChanged("add_by", ModelEntityUpdated); } }

        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date { get { return _add_date; } set { _add_date = value; RaisePropertyChanged("add_date", ModelEntityUpdated); } }

        private string _editby;
        public string editby { get { return _editby; } set { _editby = value; RaisePropertyChanged("editby", ModelEntityUpdated); } }

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date { get { return _edit_date; } set { _edit_date = value; RaisePropertyChanged("edit_date", ModelEntityUpdated); } }

        private string _note;
        public string note { get { return _note; } set { _note = value; RaisePropertyChanged("note", ModelEntityUpdated); } }

        private string _comp_code;
        public string comp_code { get { return _comp_code; } set { _comp_code = value; RaisePropertyChanged("comp_code", ModelEntityUpdated); } }

        //Added by Priya
        private string _doc_type;
        public string doc_type
        {
            get
            {
                return _doc_type;
            }
            set
            {
                _doc_type = value;
                RaisePropertyChanged("doc_type", ModelEntityUpdated);
            }
        }
        private string _doc_cat;
        public string doc_cat
        {
            get
            {
                return _doc_cat;
            }
            set
            {
                _doc_cat = value;
                RaisePropertyChanged("doc_cat", ModelEntityUpdated);
            }
        }
        private string _ref_type;
        public string ref_type
        {
            get
            {
                return _ref_type;
            }
            set
            {
                _ref_type = value;
                RaisePropertyChanged("ref_type", ModelEntityUpdated);
            }
        }
        private string _ref_no;
        public string ref_no
        {
            get
            {
                return _ref_no;
            }
            set
            {
                _ref_no = value;
                RaisePropertyChanged("ref_no", ModelEntityUpdated);
            }
        }
        private Nullable<int> _ContInfoId;
        public Nullable<int> ContInfoId
        {
            get
            {
                return _ContInfoId;
            }
            set
            {
                _ContInfoId = value;
                RaisePropertyChanged("ContInfoId", ModelEntityUpdated);
            }
        }
        private string _sch_by;
        public string sch_by
        {
            get
            {
                return _sch_by;
            }
            set
            {
                _sch_by = value;
                RaisePropertyChanged("sch_by", ModelEntityUpdated);
            }
        }
        private string _EmpId;
        public string EmpId
        {
            get
            {
                return _EmpId;
            }
            set
            {
                _EmpId = value;
                RaisePropertyChanged("EmpId", ModelEntityUpdated);
            }
        }
        private string _sch_rec_by_cd;
        public string sch_rec_by_cd
        {
            get
            {
                return _sch_rec_by_cd;
            }
            set
            {
                _sch_rec_by_cd = value;
                RaisePropertyChanged("sch_rec_by_cd", ModelEntityUpdated);
            }
        }
        private string _remark;
        public string remark
        {
            get
            {
                return _remark;
            }
            set
            {
                _remark = value;
                RaisePropertyChanged("remark", ModelEntityUpdated);
            }
        }
        private string _fin_year;
        public string fin_year
        {
            get
            {
                return _fin_year;
            }
            set
            {
                _fin_year = value;
                RaisePropertyChanged("fin_year", ModelEntityUpdated);
            }
        }
        private string _posting_period;
        public string posting_period
        {
            get
            {
                return _posting_period;
            }
            set
            {
                _posting_period = value;
                RaisePropertyChanged("posting_period", ModelEntityUpdated);
            }
        }
        private string _ref_doc_no;
        public string ref_doc_no
        {
            get
            {
                return _ref_doc_no;
            }
            set
            {
                _ref_doc_no = value;
                RaisePropertyChanged("ref_doc_no", ModelEntityUpdated);
            }
        }
        private string _ref_doc_type;
        public string ref_doc_type
        {
            get
            {
                return _ref_doc_type;
            }
            set
            {
                _ref_doc_type = value;
                RaisePropertyChanged("ref_doc_type", ModelEntityUpdated);
            }
        }
        private string _ref_doc_cat;
        public string ref_doc_cat
        {
            get
            {
                return _ref_doc_cat;
            }
            set
            {
                _ref_doc_cat = value;
                RaisePropertyChanged("ref_doc_cat", ModelEntityUpdated);
            }
        }


        private Nullable<System.DateTime> _ref_doc_date;
        public Nullable<System.DateTime> ref_doc_date
        {
            get
            { return _ref_doc_date; }
            set
            { _ref_doc_date = value; RaisePropertyChanged("ref_doc_date", ModelEntityUpdated); }
        }

        private Nullable<int> _del_address;
        public Nullable<int> del_address
        {
            get
            {
                return _del_address;
            }
            set
            {
                _del_address = value;
                RaisePropertyChanged("del_address", ModelEntityUpdated);
            }
        }
        private string _status_remark;
        public string status_remark
        {
            get
            {
                return _status_remark;
            }
            set
            {
                _status_remark = value;
                RaisePropertyChanged("status_remark", ModelEntityUpdated);
            }
        }
        private string _t_display;
        public string t_display
        {
            get { return _t_display; }
            set
            {
                if (_t_display != value)
                {
                    _t_display = value; RaisePropertyChanged("t_display");
                }
            }
        }
        //Scalar Fields
        private string _PartyNm { get; set; }
        public string PartyNm { get { return _PartyNm; } set { _PartyNm = value; RaisePropertyChanged("PartyNm", ModelEntityUpdated); } }

        public string XmlDataDocument_PUR_T004_B { get; set; }
    }
    public class PUR_T004_B : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int _id;
        public int id { get { return _id; } set { _id = value; RaisePropertyChanged("id", ModelEntityUpdated); } }

        public string _sch_no;
        public string sch_no { get { return _sch_no; } set { _sch_no = value; RaisePropertyChanged("sch_no", ModelEntityUpdated); } }

        private int _line_id;
        public int line_id { get { return _line_id; } set { _line_id = value; RaisePropertyChanged("line_id", ModelEntityUpdated); } }

        private string _po_no;
        public string po_no { get { return _po_no; } set { _po_no = value; RaisePropertyChanged("po_no", ModelEntityUpdated); } }

        private string _ItemCode;
        public string ItemCode { get { return _ItemCode; } set { _ItemCode = value; RaisePropertyChanged("ItemCode", ModelEntityUpdated); } }

        private decimal? _qty;
        public decimal? qty { get { return _qty; } set { _qty = value; RaisePropertyChanged("qty", ModelEntityUpdated); } }

        private DateTime? _expected_date;
        public DateTime? expected_date
        {
            get { return _expected_date; }
            set { _expected_date = value; RaisePropertyChanged("expected_date", ModelEntityUpdated); }
        }

        private decimal? _confirm_qty;
        public decimal? confirm_qty { get { return _confirm_qty; } set { _confirm_qty = value; RaisePropertyChanged("confirm_qty", ModelEntityUpdated); } }

        private DateTime? _confirm_date;
        public DateTime? confirm_date { get { return _confirm_date; } set { _confirm_date = value; RaisePropertyChanged("confirm_date", ModelEntityUpdated); } }

        private DateTime? _despatch_date;
        public DateTime? despatch_date { get { return _despatch_date; } set { _despatch_date = value; RaisePropertyChanged("despatch_date", ModelEntityUpdated); } }

        private decimal? _rec_qty;
        public decimal? rec_qty { get { return _rec_qty; } set { _rec_qty = value; RaisePropertyChanged("rec_qty", ModelEntityUpdated); } }

        private DateTime? _rec_date;
        public DateTime? rec_date { get { return _rec_date; } set { _rec_date = value; RaisePropertyChanged("rec_date", ModelEntityUpdated); } }

        private string _note;
        public string note { get { return _note; } set { _note = value; RaisePropertyChanged("note", ModelEntityUpdated); } }

        private string _t_status;
        public string t_status { get { return _t_status; } set { _t_status = value; RaisePropertyChanged("t_status", ModelEntityUpdated); } }

        private string _location_Id;
        public string location_Id { get { return _location_Id; } set { _location_Id = value; RaisePropertyChanged("location_Id", ModelEntityUpdated); } }

        private bool? _active;
        public bool? active { get { return _active; } set { _active = value; RaisePropertyChanged("active", ModelEntityUpdated); } }

        private string _add_by;
        public string add_by { get { return _add_by; } set { _add_by = value; RaisePropertyChanged("add_by", ModelEntityUpdated); } }

        private System.DateTime _add_date;
        public System.DateTime add_date { get { return _add_date; } set { _add_date = value; RaisePropertyChanged("add_date", ModelEntityUpdated); } }

        private string _editby;
        public string editby { get { return _editby; } set { _editby = value; RaisePropertyChanged("editby", ModelEntityUpdated); } }

        private DateTime? _edit_date;
        public DateTime? edit_date { get { return _edit_date; } set { _edit_date = value; RaisePropertyChanged("edit_date", ModelEntityUpdated); } }

        private string _sku;
        public string sku { get { return _sku; } set { _sku = value; RaisePropertyChanged("sku", ModelEntityUpdated); } }

        private string _comp_code;
        public string comp_code { get { return _comp_code; } set { _comp_code = value; RaisePropertyChanged("comp_code", ModelEntityUpdated); } }

        private decimal? _rate;
        public decimal? rate { get { return _rate; } set { _rate = value; RaisePropertyChanged("rate", ModelEntityUpdated); } }

        private string _po_req_no;
        public string po_req_no { get { return _po_req_no; } set { _po_req_no = value; RaisePropertyChanged("po_req_no", ModelEntityUpdated); } }

        private string _ItemName;
        public string ItemName { get { return _ItemName; } set { _ItemName = value; RaisePropertyChanged("ItemName", ModelEntityUpdated); } }

        //Added by Priya
        private string _sch_cat;
        public string sch_cat { get { return _sch_cat; } set { _sch_cat = value; RaisePropertyChanged("sch_cat", ModelEntityUpdated); } }

        private Nullable<int> _po_item_row_id;
        public Nullable<int> po_item_row_id { get { return _po_item_row_id; } set { _po_item_row_id = value; RaisePropertyChanged("po_item_row_id", ModelEntityUpdated); } }
        private string _remark;
        public string remark { get { return _remark; } set { _remark = value; RaisePropertyChanged("remark", ModelEntityUpdated); } }

        private string _desp_id;
        public string desp_id { get { return _desp_id; } set { _desp_id = value; RaisePropertyChanged("desp_id", ModelEntityUpdated); } }

        private string _sku_desc;
        public string sku_desc { get { return _sku_desc; } set { _sku_desc = value; RaisePropertyChanged("sku_desc", ModelEntityUpdated); } }

        private string _fin_year;
        public string fin_year { get { return _fin_year; } set { _fin_year = value; RaisePropertyChanged("fin_year", ModelEntityUpdated); } }

        private string _posting_period;
        public string posting_period { get { return _posting_period; } set { _posting_period = value; RaisePropertyChanged("posting_period", ModelEntityUpdated); } }

        private string _rel_delivery;
        public string rel_delivery { get { return _rel_delivery; } set { _rel_delivery = value; RaisePropertyChanged("rel_delivery", ModelEntityUpdated); } }

        private string _rel_billing;
        public string rel_billing { get { return _rel_billing; } set { _rel_billing = value; RaisePropertyChanged("rel_billing", ModelEntityUpdated); } }

        private Nullable<int> _so_item_id;
        public Nullable<int> so_item_id { get { return _so_item_id; } set { _so_item_id = value; RaisePropertyChanged("so_item_id", ModelEntityUpdated); } }

        private Nullable<decimal> _order_qty;
        public Nullable<decimal> order_qty { get { return _order_qty; } set { _order_qty = value; RaisePropertyChanged("order_qty", ModelEntityUpdated); } }

        private string _confirm_status;
        public string confirm_status { get { return _confirm_status; } set { _confirm_status = value; RaisePropertyChanged("confirm_status", ModelEntityUpdated); } }

        private Nullable<bool> _del_block;
        public Nullable<bool> del_block { get { return _del_block; } set { _del_block = value; RaisePropertyChanged("del_block", ModelEntityUpdated); } }

        private string _mov_tp;
        public string mov_tp { get { return _mov_tp; } set { _mov_tp = value; RaisePropertyChanged("mov_tp", ModelEntityUpdated); } }

        private Nullable<System.DateTime> _sch_date;
        public Nullable<System.DateTime> sch_date
        {
            get { return _sch_date; }
            set
            { _sch_date = value; RaisePropertyChanged("sch_date"); }
        }
        private string _ship_mode;
        public string ship_mode
        {
            get
            {
                return _ship_mode;
            }

            set
            {
                _ship_mode = value; RaisePropertyChanged("ship_mode", ModelEntityUpdated);
            }
        }
        private string _PartyId;
        public string PartyId
        {
            get
            {
                return _PartyId;
            }

            set
            {
                _PartyId = value; RaisePropertyChanged("PartyId", ModelEntityUpdated);
            }
        }
        private string _para1;
        public string para1
        {
            get
            {
                return _para1;
            }

            set
            {
                _para1 = value; RaisePropertyChanged("para1");
            }
        }

        private string _para2;
        public string para2
        {
            get
            {
                return _para2;
            }

            set
            {
                _para2 = value; RaisePropertyChanged("para2");
            }
        }

        private string _para3;
        public string para3
        {
            get
            {
                return _para3;
            }

            set
            {
                _para3 = value; RaisePropertyChanged("para3");
            }
        }
        private string _ref_doc_no;
        public string ref_doc_no
        {
            get
            {
                return _ref_doc_no;
            }

            set
            {
                _ref_doc_no = value; RaisePropertyChanged("ref_doc_no", ModelEntityUpdated);
            }
        }
        private string _ref_doc_type;
        public string ref_doc_type
        {
            get
            {
                return _ref_doc_type;
            }

            set
            {
                _ref_doc_type = value; RaisePropertyChanged("ref_doc_type", ModelEntityUpdated);
            }
        }
        private string _ref_doc_cat;
        public string ref_doc_cat
        {
            get
            {
                return _ref_doc_cat;
            }

            set
            {
                _ref_doc_cat = value; RaisePropertyChanged("ref_doc_cat", ModelEntityUpdated);
            }
        }
        private Nullable<System.DateTime> _ref_doc_date;
        public Nullable<System.DateTime> ref_doc_date
        {
            get
            {
                return _ref_doc_date;
            }

            set
            {
                _ref_doc_date = value; RaisePropertyChanged("ref_doc_date", ModelEntityUpdated);
            }
        }
        private string _status_remark;
        public string status_remark
        {
            get
            {
                return _status_remark;
            }

            set
            {
                _status_remark = value; RaisePropertyChanged("status_remark");
            }
        }
        private Nullable<decimal> _bal_qty;
        public Nullable<decimal> bal_qty
        {
            get
            {
                return _bal_qty;
            }

            set
            {
                _bal_qty = value; RaisePropertyChanged("bal_qty", ModelEntityUpdated);
            }
        }

        private Nullable<int> _pur_req_item_row_id;
        public Nullable<int> pur_req_item_row_id { get { return _pur_req_item_row_id; } set { _pur_req_item_row_id = value; RaisePropertyChanged("pur_req_item_row_id", ModelEntityUpdated); } }
        private string _sob_no;
        public string sob_no
        {
            get
            {
                return _sob_no;
            }

            set
            {
                _sob_no = value; RaisePropertyChanged("sob_no");
            }
        }

        private Nullable<decimal> _qty_delivered;
        public Nullable<decimal> qty_delivered
        {
            get
            {
                return _qty_delivered;
            }

            set
            {
                _qty_delivered = value; RaisePropertyChanged("qty_delivered", ModelEntityUpdated);
            }
        }
        private Nullable<int> _sob_row_id;
        public Nullable<int> sob_row_id { get { return _sob_row_id; } set { _sob_row_id = value; RaisePropertyChanged("sob_row_id", ModelEntityUpdated); } }

        private string _bom_exp_no;
        public string bom_exp_no
        {
            get
            {
                return _bom_exp_no;
            }

            set
            {
                _bom_exp_no = value; RaisePropertyChanged("bom_exp_no");
            }
        }
        private string _bom_no;
        public string bom_no
        {
            get
            {
                return _bom_no;
            }

            set
            {
                _bom_no = value; RaisePropertyChanged("bom_no");
            }
        }
        private string _budget_no;
        public string budget_no
        {
            get
            {
                return _budget_no;
            }

            set
            {
                _budget_no = value; RaisePropertyChanged("budget_no");
            }
        }
        private string _req_budget;
        public string req_budget
        {
            get
            {
                return _req_budget;
            }

            set
            {
                _req_budget = value; RaisePropertyChanged("req_budget");
            }
        }
        private string _t_display;
        public string t_display
        {
            get { return _t_display; }
            set
            {
                if (_t_display != value)
                {
                    _t_display = value; RaisePropertyChanged("t_display");
                }
            }
        }

        private string _tr_mode;
        public string tr_mode
        {
            get { return _tr_mode; }
            set
            {
                if (_tr_mode != value)
                {
                    _tr_mode = value; RaisePropertyChanged("tr_mode");
                }
            }
        }

        private string _tr_type;
        public string tr_type
        {
            get { return _tr_type; }
            set
            {
                if (_tr_type != value)
                {
                    _tr_type = value; RaisePropertyChanged("tr_type");
                }
            }
        }

        private string _transportar_cd;
        public string transportar_cd
        {
            get { return _transportar_cd; }
            set
            {
                if (_transportar_cd != value)
                {
                    _transportar_cd = value; RaisePropertyChanged("transportar_cd");
                }
            }
        }

        private string _contact_person_party;
        public string contact_person_party
        {
            get { return _contact_person_party; }
            set
            {
                if (_contact_person_party != value)
                {
                    _contact_person_party = value; RaisePropertyChanged("contact_person_party");
                }
            }
        }

        private string _schedule_by;
        public string schedule_by
        {
            get { return _schedule_by; }
            set
            {
                if (_schedule_by != value)
                {
                    _schedule_by = value; RaisePropertyChanged("schedule_by");
                }
            }
        }

        private string _del_address_id;
        public string del_address_id
        {
            get { return _del_address_id; }
            set
            {
                if (_del_address_id != value)
                {
                    _del_address_id = value; RaisePropertyChanged("del_address_id");
                }
            }
        }

        private string _bill_address_id;
        public string bill_address_id
        {
            get { return _bill_address_id; }
            set
            {
                if (_bill_address_id != value)
                {
                    _bill_address_id = value; RaisePropertyChanged("bill_address_id");
                }
            }
        }

        private Nullable<int> _req_sch_row_id;
        public Nullable<int> req_sch_row_id
        {
            get { return _req_sch_row_id; }
            set
            {
                if (_req_sch_row_id != value)
                {
                    _req_sch_row_id = value; RaisePropertyChanged("req_sch_row_id");
                }
            }
        }

        private string _unit_code;

        [Required(ErrorMessage = "Field 'Unit of Measurement' is required.")]
        [ValidValue(ErrorMessage = "Invalid input of 'Unit of Measurement'.")]
        public string unit_code { get { return _unit_code; } set { _unit_code = value; RaisePropertyChanged("unit_code", ModelEntityUpdated); } }

        private decimal? _lead_time;
        public decimal? lead_time
        {
            get
            {
                return _lead_time;
            }

            set
            {
                if (_lead_time != value)
                {
                    _lead_time = value; RaisePropertyChanged("lead_time", ModelEntityUpdated);
                }
            }
        }
        private string _lead_uom;
        public string lead_uom
        {
            get
            {
                return _lead_uom;
            }

            set
            {
                if (_lead_uom != value)
                {
                    _lead_uom = value; RaisePropertyChanged("lead_uom");
                }
            }
        }
        private string _price_qty_uom;
        public string price_qty_uom
        {
            get { return _price_qty_uom; }
            set
            {
                if (_price_qty_uom != value)
                {
                    _price_qty_uom = value; RaisePropertyChanged("price_qty_uom");
                }
            }
        }

        private decimal? _price_qty;
        public decimal? price_qty
        {
            get
            {
                return _price_qty;
            }

            set
            {
                if (_price_qty != value)
                {
                    _price_qty = value; RaisePropertyChanged("price_qty");
                }
            }
        }

        private decimal? _qty_price;
        public decimal? qty_price
        {
            get
            {
                return _qty_price;
            }

            set
            {
                if (_qty_price != value)
                {
                    _qty_price = value; RaisePropertyChanged("qty_price");
                }
            }
        }
        private string _tr_party;
        public string tr_party
        {
            get
            {
                return _tr_party;
            }

            set
            {
                if (_tr_party != value)
                {
                    _tr_party = value; RaisePropertyChanged("tr_party");
                }
            }
        }
        private string _tr_name;
        public string tr_name
        {
            get
            {
                return _tr_name;
            }

            set
            {
                if (_tr_name != value)
                {
                    _tr_name = value; RaisePropertyChanged("tr_name");
                }
            }
        }
        private int? _item_line_id;
        public int? item_line_id
        {
            get
            {
                return _item_line_id;
            }

            set
            {
                if (_item_line_id != value)
                {
                    _item_line_id = value; RaisePropertyChanged("item_line_id");
                }
            }
        }

        private string _add_code_del;
        public string add_code_del
        {
            get
            {
                return _add_code_del;
            }

            set
            {
                if (_add_code_del != value)
                {
                    _add_code_del = value; RaisePropertyChanged("add_code_del");
                }
            }
        }

        private string _add_code_bil;
        public string add_code_bil
        {
            get
            {
                return _add_code_bil;
            }

            set
            {
                if (_add_code_bil != value)
                {
                    _add_code_bil = value; RaisePropertyChanged("add_code_bil");
                }
            }
        }

    }
    public class RptPUR_T002_B : ObjectBase
    {

        public string po_no { get; set; }
        public string ItemCode { get; set; }
        public string description { get; set; }
        public string sku { get; set; }
        public string sku_desc { get; set; }
        public Nullable<decimal> qty { get; set; }
        public string unit_code { get; set; }
        public Nullable<decimal> unit_price { get; set; }
        public Nullable<decimal> discount { get; set; }
        public Nullable<decimal> sub_total { get; set; }
        public string t_status { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public Nullable<bool> active { get; set; }
        public string symbol { get; set; }
        public string Mat_Condition { get; set; }
        public string Type { get; set; }
        public string Make { get; set; }
        public string hs_code { get; set; }
        public string hsn_code { get; set; }
        public string hsn_code2 { get; set; }
        //GST
        public string hs_code2 { get; set; }
        public string textdata { get; set; }
        public string t_display { get; set; }
        public string del_address_id { get; set; }


    }
    public class MultipleContext_PUR_T002_A
    {
        public List<STD_LIST_BE> PR_LIST { get; set; }
        public List<ACC_M007_A> PAY_TERMD { get; set; }
        public List<ADM_M0071> PARAMETERS_VALUES_LIST { get; set; }
        public List<ADM_M0002> COMPANY_LIST { get; set; }
        public List<ADM_M0003> LOCATION_LIST { get; set; }
        public List<STD_LIST_BE> KEY_DATA_LIST { get; set; }
        public List<STD_DOC_TYPE> DOC_TYPE_LIST { get; set; }
        public List<PUR_T002_AFlip> DocumentDataFlipGrid { get; set; }
        public List<ADM_M028_P> partyList { get; set; }
        public List<ADM_M038_B_P> unitList { get; set; }
        public List<ADM_M024_P> BuyerList { get; set; }
        public List<ACC_M005_P> journalList { get; set; }
        public List<ACC_M013_P> TaxList { get; set; }
        public List<ACC_M003_P> AccountList { get; set; }
        public List<ACC_M007_P> PayTerms { get; set; }
        public List<MM_M002_P> WarehouseList { get; set; }
        public List<SYS_M007> DocumentTypes { get; set; }
        public List<SYS_M007> doc_typeList { get; set; }
        public List<ADM_M037_P> currencyList { get; set; }
        public List<ADM_M037> CURRENCY_LIST { get; set; }
        public List<PUR_T002_P_RefeDoc> reference_docList { get; set; }
        public List<ADM_M001_M_P> purchase_orgList { get; set; }
        public List<ADM_M001_P_P> Purchase_groupList { get; set; }
        public List<MM_M001_P> storage_locList { get; set; }
        public List<ACC_M019_P> cost_centerList { get; set; }
        public List<ADM_M002_P> billaddrList { get; set; }
        public List<ADM_M003_P> deladdrList { get; set; }
        public List<SYS_M008_P> itemcatList { get; set; }
        public List<PUR_T002_P_PR_ItemsList> ItemListForPopup { get; set; }
        public List<PUR_T002_A> DocumentMaster { get; set; }
        public ObservableCollection<PUR_T002_B> DocumentItems { get; set; }
        public List<PUR_T002_C> DocumentTax { get; set; }
        public ObservableCollection<ACC_T006_B> DocumentTaxDetails { get; set; }
        public List<PUR_T004_A> DocumentScheduleMaster { get; set; }
        public ObservableCollection<PUR_T004_B> DocumentScheduleDetails { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<NotificationData> NotificationData { get; set; }
        public ObservableCollection<PUR_T002_H> TermsAndCondition { get; set; }
        public ObservableCollection<GEN_T011> TCondition { get; set; }
        public List<MM_M008_P> TermsConditionCollection { get; set; }
        public List<Purchase_Requision_Data> RequisitionItem { get; set; }
        public List<ADM_M028_C_P> ContactPerson { get; set; }
        public List<ACC_M013_P> FormType { get; set; }
        public List<ADM_M030_P> ParameterValue { get; set; }
        public List<ADM_M038_C> UnitConversion { get; set; }
        public List<ADM_M044_P> Incoterms { get; set; }
        public List<ADM_M041_P> LicenseAdvance { get; set; }
        public List<ADM_M041_P> LicenseEPCG { get; set; }
        public List<ADM_M041_P> LicenceList { get; set; }
        public ObservableCollection<ACC_T006_D> LicenceEntity { get; set; }
        public List<ADM_M003_C_P> BussinessPlaceList { get; set; }
        public List<ACC_M003_O_P> ConditionTypeList { get; set; }
        public List<GetItemDetailsEntity> UnitPriceList { get; set; }
        public List<GetItemDetailsEntity> QFRList { get; set; }
        public List<GetItemDetailsEntity> DispatchList { get; set; }
        public List<GetItemDetailsEntity> ProjectedDispList { get; set; }
        public List<ADM_M043_D> ApprovalData { get; set; }
        public List<RptPUR_T002_B> RptDocumentItems { get; set; }
        public List<ADM_M0013> t_statusList { get; set; }
        public List<ADM_M028_P> PartyMaster { get; set; }
        public List<SYS_M037> Trade_Types { get; set; }
        public ObservableCollection<PUR_T002_C> ComponantList { get; set; }
        public List<STD_ITEM> ItemListForComponant { get; set; }
        public List<STD_ITEM> STD_ITEM_LIST { get; set; }
        public List<STD_LIST_BE> STD_LIST_OBJ { get; set; }
        public List<SYS_M026> TransportMode { get; set; }
        public List<ADM_M002_B> ScopeList { get; set; }
        public List<ADM_M0051> CONDITION_LIST { get; set; }
        public List<ADM_M0061_A> CATALOG_LIST { get; set; }
    }
    public class PUR_T002_P_RefeDoc : ObjectBase//Reference doc no's
    {
        private bool _Select;
        public bool Select
        {
            get { return _Select; }
            set
            {
                _Select = value;
                RaisePropertyChanged("Select");
            }
        }
        public string po_no { get; set; }
        public Nullable<DateTime> po_date { get; set; }
        public string partyId { get; set; }
        public string party_name { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string supplier_ref { get; set; }
        public string po_code { get; set; }
        public string quotation_no { get; set; }
        public Nullable<DateTime> quotation_date { get; set; }
        public string display_doc_type { get; set; }
        public string doc_desc { get; set; }
        public string ItemCode { get; set; }
        public string req_no { get; set; }

        public string curr_code { get; set; }
        public string country_nm_s { get; set; }
        public string del_address { get; set; }
        public string p_term_code { get; set; }
        public string incoterms { get; set; }
        public string color_code { get; set; }
        public string t_status { get; set; }
        public string t_display { get; set; }


    }
    public class PUR_T002_P_PR_ItemsList : ObjectBase //Item List for Popup Purchase Documents from Purchase Requisition.
    {
        private bool _Select;
        public bool Select
        {
            get { return _Select; }
            set
            {
                _Select = value;
                RaisePropertyChanged("Select");
            }
        }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string CatCode { get; set; }
        public string SubCatCode { get; set; }
        public string unit_code { get; set; }
        public Nullable<bool> Stockble { get; set; }
        public string PartyId { get; set; }
        public string cstmr_itemcode { get; set; }
        public string cstmr_itemdescr { get; set; }
        public Nullable<decimal> b_rate { get; set; }
        public string sku { get; set; }
        public string tax_id { get; set; }
        public string Catlog_UOM { get; set; }
        public string sku_desc { get; set; }
        public Nullable<decimal> Req_QTY { get; set; }
        public Nullable<decimal> Req_Approve_qty { get; set; }
        public string Req_NO { get; set; }
        public int Pur_Req_Item_id { get; set; }
        public string req_type { get; set; }
        public string item_cat { get; set; }
        public string req_ref { get; set; }
        public Nullable<decimal> Rate_Suggested { get; set; }
        public Nullable<decimal> Rate_Catlog { get; set; }
        public Nullable<decimal> MinQty { get; set; }
        public Nullable<decimal> MaxQty { get; set; }
        public Nullable<decimal> Reorder { get; set; }
        public Nullable<decimal> stock_total { get; set; }
        public Nullable<decimal> stock_reserve { get; set; }
        public Nullable<decimal> stock_unr { get; set; }
        public Nullable<decimal> stock_in_transit { get; set; }
        public string note { get; set; }
        public string bom_no { get; set; }
    }


}

