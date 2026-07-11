using Reflection.BusinessEntity.Account;
using Reflection.BusinessEntity.ADM;
using Reflection.BusinessEntity.CustomerRelation;
using Reflection.BusinessEntity.ReflectionSystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Reflection.BusinessEntity
{
    public class PUR_T005 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }

        private string _doc_no;
        public string doc_no
        {

            get { return _doc_no; }
            set { _doc_no = value; RaisePropertyChanged("doc_no", ModelEntityUpdated); }
        }
        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set { _doc_type = value; RaisePropertyChanged("doc_type", ModelEntityUpdated); }
        }

        private string _doc_desc;
        public string doc_desc
        {
            get { return _doc_desc; }
            set { _doc_desc = value; RaisePropertyChanged("doc_desc"); }
        }

        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set { _doc_cat = value; RaisePropertyChanged("doc_cat", ModelEntityUpdated); }
        }
        private Nullable<System.DateTime> _doc_date;
        public Nullable<System.DateTime> doc_date
        {
            get { return _doc_date; }
            set { _doc_date = value; RaisePropertyChanged("doc_date", ModelEntityUpdated); }
        }

        private Nullable<System.DateTime> _post_date;
        public Nullable<System.DateTime> post_date
        {
            get { return _post_date; }
            set { _post_date = value; RaisePropertyChanged("post_date", ModelEntityUpdated); }
        }

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code", ModelEntityUpdated); }
        }

        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id", ModelEntityUpdated); }
        }

        private string _PartyId;
        public string PartyId
        {
            get { return _PartyId; }
            set { _PartyId = value; RaisePropertyChanged("PartyId", ModelEntityUpdated); }
        }

        private string _curr_code;
        public string curr_code
        {
            get { return _curr_code; }
            set { _curr_code = value; RaisePropertyChanged("curr_code", ModelEntityUpdated); }
        }

        private string _trns_code;
        public string trns_code
        {
            get { return _trns_code; }
            set { _trns_code = value; RaisePropertyChanged("trns_code", ModelEntityUpdated); }
        }

        private Nullable<System.DateTime> _scc_doc_date;
        public Nullable<System.DateTime> scc_doc_date
        {
            get { return _scc_doc_date; }
            set { _scc_doc_date = value; RaisePropertyChanged("scc_doc_date", ModelEntityUpdated); }
        }

        private string _entry_time;
        public string entry_time
        {
            get { return _entry_time; }
            set { _entry_time = Convert.ToString(new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)); RaisePropertyChanged("entry_time", ModelEntityUpdated); }
        }

        private string _ref_doc_no;
        public string ref_doc_no
        {
            get { return _ref_doc_no; }
            set { _ref_doc_no = value; RaisePropertyChanged("ref_doc_no", ModelEntityUpdated); }
        }

        private string _ref_doc_type;
        public string ref_doc_type
        {
            get { return _ref_doc_type; }
            set { _ref_doc_type = value; RaisePropertyChanged("ref_doc_type", ModelEntityUpdated); }
        }

        private string _ref_doc_cat;
        public string ref_doc_cat
        {
            get { return _ref_doc_cat; }
            set { _ref_doc_cat = value; RaisePropertyChanged("ref_doc_cat", ModelEntityUpdated); }
        }

        private Nullable<int> _item_ref_doc;
        public Nullable<int> item_ref_doc
        {
            get { return _item_ref_doc; }
            set { _item_ref_doc = value; RaisePropertyChanged("item_ref_doc", ModelEntityUpdated); }
        }

        private Nullable<decimal> _exch_rate;
        public Nullable<decimal> exch_rate
        {
            get { return _exch_rate; }
            set { _exch_rate = value; RaisePropertyChanged("exch_rate", ModelEntityUpdated); }
        }

        private Nullable<decimal> _del_cost;
        public Nullable<decimal> del_cost
        {
            get { return _del_cost; }
            set { _del_cost = value; RaisePropertyChanged("del_cost", ModelEntityUpdated); }
        }

        private Nullable<decimal> _gross_amount;
        public Nullable<decimal> gross_amount
        {
            get { return _gross_amount; }
            set { _gross_amount = value; RaisePropertyChanged("gross_amount", ModelEntityUpdated); }
        }

        private Nullable<decimal> _tax_amount;
        public Nullable<decimal> tax_amount
        {
            get { return _tax_amount; }
            set { _tax_amount = value; RaisePropertyChanged("tax_amount", ModelEntityUpdated); }
        }

        private string _tax_code;
        public string tax_code
        {
            get { return _tax_code; }
            set { _tax_code = value; RaisePropertyChanged("tax_code", ModelEntityUpdated); }
        }

        private string _tax_juri;
        public string tax_juri
        {
            get { return _tax_juri; }
            set { _tax_juri = value; RaisePropertyChanged("tax_juri", ModelEntityUpdated); }
        }

        private Nullable<decimal> _total;
        public Nullable<decimal> total
        {
            get { return _total; }
            set { _total = value; RaisePropertyChanged("total", ModelEntityUpdated); }
        }

        private Nullable<decimal> _subtotal;
        public Nullable<decimal> subtotal
        {
            get { return _subtotal; }
            set { _subtotal = value; RaisePropertyChanged("subtotal", ModelEntityUpdated); }
        }

        private Nullable<decimal> _round_up;
        public Nullable<decimal> round_up
        {

            get { return _round_up; }
            set { _round_up = value; RaisePropertyChanged("round_up", ModelEntityUpdated); }
        }

        private Nullable<decimal> _roundup_total;
        public Nullable<decimal> roundup_total
        {
            get { return _roundup_total; }
            set { _roundup_total = value; RaisePropertyChanged("roundup_total", ModelEntityUpdated); }
        }

        private string _amt_word;
        public string amt_word
        {
            get { return _amt_word; }
            set { _amt_word = value; RaisePropertyChanged("amt_word", ModelEntityUpdated); }
        }

        private string _tax_reg_no;
        public string tax_reg_no
        {
            get { return _tax_reg_no; }
            set { _tax_reg_no = value; RaisePropertyChanged("tax_reg_no", ModelEntityUpdated); }
        }
        private string _p_term_code;
        public string p_term_code
        {
            get { return _p_term_code; }
            set { _p_term_code = value; RaisePropertyChanged("p_term_code", ModelEntityUpdated); }
        }

        private Nullable<decimal> _cash_disc_day1;
        public Nullable<decimal> cash_disc_day1
        {
            get { return _cash_disc_day1; }
            set { _cash_disc_day1 = value; RaisePropertyChanged("cash_disc_day1", ModelEntityUpdated); }
        }
        private Nullable<decimal> _cash_disc_per1;
        public Nullable<decimal> cash_disc_per1
        {
            get { return _cash_disc_per1; }
            set { _cash_disc_per1 = value; RaisePropertyChanged("cash_disc_per1", ModelEntityUpdated); }
        }

        private Nullable<decimal> _cash_disc_day2;
        public Nullable<decimal> cash_disc_day2
        {
            get { return _cash_disc_day2; }
            set { _cash_disc_day2 = value; RaisePropertyChanged("cash_disc_day2", ModelEntityUpdated); }
        }

        private Nullable<decimal> _cash_disc_per2;
        public Nullable<decimal> cash_disc_per2
        {
            get { return _cash_disc_per2; }
            set { _cash_disc_per2 = value; RaisePropertyChanged("cash_disc_per2", ModelEntityUpdated); }
        }

        private Nullable<decimal> _net_pay_period;
        public Nullable<decimal> net_pay_period
        {
            get { return _net_pay_period; }
            set { _net_pay_period = value; RaisePropertyChanged("net_pay_period", ModelEntityUpdated); }
        }

        private Nullable<decimal> _cash_disc_amt;
        public Nullable<decimal> cash_disc_amt
        {
            get { return _cash_disc_amt; }
            set { _cash_disc_amt = value; RaisePropertyChanged("cash_disc_amt", ModelEntityUpdated); }
        }


        private string _inv_no;
        public string inv_no
        {
            get { return _inv_no; }
            set { _inv_no = value; RaisePropertyChanged("inv_no"); }
        }

        private Nullable<bool> _invoice_verify;
        public Nullable<bool> invoice_verify
        {
            get { return _invoice_verify; }
            set { _invoice_verify = value; RaisePropertyChanged("invoice_verify"); }
        }

        private string _inv_doc_status;
        public string inv_doc_status
        {
            get { return _inv_doc_status; }
            set { _inv_doc_status = value; RaisePropertyChanged("inv_doc_status"); }
        }

        private Nullable<bool> _post_invoice;
        public Nullable<bool> post_invoice
        {

            get { return _post_invoice; }
            set { _post_invoice = value; RaisePropertyChanged("post_invoice"); }
        }

        private string _invoice_ref;
        public string invoice_ref
        {
            get { return _invoice_ref; }
            set { _invoice_ref = value; RaisePropertyChanged("invoice_ref"); }
        }

        private string _org_inv_fin_year;
        public string org_inv_fin_year
        {

            get { return _org_inv_fin_year; }
            set { _org_inv_fin_year = value; RaisePropertyChanged("org_inv_fin_year"); }
        }

        private string _inv_fin_year;
        public string inv_fin_year
        {
            get { return _inv_fin_year; }
            set { _inv_fin_year = value; RaisePropertyChanged("inv_fin_year"); }
        }

        private Nullable<System.DateTime> _inv_rec_date;
        public Nullable<System.DateTime> inv_rec_date
        {
            get { return _inv_rec_date; }
            set { _inv_rec_date = value; RaisePropertyChanged("inv_rec_date"); }
        }

        private Nullable<System.DateTime> _inv_date;
        public Nullable<System.DateTime> inv_date
        {
            get { return _inv_date; }
            set { _inv_date = value; RaisePropertyChanged("inv_date"); }
        }

        private string _payee_payer;
        public string payee_payer
        {
            get { return _payee_payer; }
            set { _payee_payer = value; RaisePropertyChanged("payee_payer", ModelEntityUpdated); }
        }

        private string _bank_code;
        public string bank_code
        {
            get { return _bank_code; }
            set { _bank_code = value; RaisePropertyChanged("bank_code"); }
        }

        private string _branch;
        public string branch
        {
            get { return _branch; }
            set { _branch = value; RaisePropertyChanged("branch", ModelEntityUpdated); }
        }


        private string _bank_acc;
        public string bank_acc
        {
            get { return _bank_acc; }
            set { _bank_acc = value; RaisePropertyChanged("bank_acc", ModelEntityUpdated); }
        }

        private string _account_no;
        public string account_no
        {
            get { return _account_no; }
            set { _account_no = value; RaisePropertyChanged("account_no", ModelEntityUpdated); }
        }

        private string _acc_code;
        public string acc_code
        {
            get { return _acc_code; }
            set { _acc_code = value; RaisePropertyChanged("acc_code", ModelEntityUpdated); }
        }

        private Nullable<decimal> _acc_amount;
        public Nullable<decimal> acc_amount
        {
            get { return _acc_amount; }
            set { _acc_amount = value; RaisePropertyChanged("acc_amount", ModelEntityUpdated); }
        }

        private string _ifsc_code;
        public string ifsc_code
        {
            get { return _ifsc_code; }
            set { _ifsc_code = value; RaisePropertyChanged("ifsc_code"); }
        }

        private string _swift_code;
        public string swift_code
        {
            get { return _swift_code; }
            set { _swift_code = value; RaisePropertyChanged("swift_code"); }
        }

        private string _nastro_bank_cd;
        public string nastro_bank_cd
        {
            get { return _nastro_bank_cd; }
            set { _nastro_bank_cd = value; RaisePropertyChanged("nastro_bank_cd"); }
        }

        private string _j_code;
        public string j_code
        {

            get { return _j_code; }
            set { _j_code = value; RaisePropertyChanged("j_code"); }
        }

        private string _pay_method;
        public string pay_method
        {
            get { return _pay_method; }
            set { _pay_method = value; RaisePropertyChanged("pay_method"); }
        }

        private Nullable<bool> _pay_block;
        public Nullable<bool> pay_block
        {
            get { return _pay_block; }
            set { _pay_block = value; RaisePropertyChanged("pay_block"); }
        }

        private string _pay_ref;
        public string pay_ref
        {
            get { return _pay_ref; }
            set { _pay_ref = value; RaisePropertyChanged("pay_ref"); }
        }

        private Nullable<bool> _cap_ind;
        public Nullable<bool> cap_ind
        {

            get { return _cap_ind; }
            set { _cap_ind = value; RaisePropertyChanged("cap_ind"); }
        }

        private string _vat_no;
        public string vat_no
        {
            get { return _vat_no; }
            set { _vat_no = value; RaisePropertyChanged("vat_no"); }
        }
        private string _pre_pay;
        public string pre_pay
        {
            get { return _pre_pay; }
            set { _pre_pay = value; RaisePropertyChanged("pre_pay"); }
        }

        private string _source_type;
        public string source_type
        {
            get { return _source_type; }
            set { _source_type = value; RaisePropertyChanged("source_type"); }
        }
        private string _source_no;
        public string source_no
        {
            get { return _source_no; }
            set { _source_no = value; RaisePropertyChanged("source_no"); }
        }

        private string _form_tp;
        public string form_tp
        {
            get { return _form_tp; }
            set { _form_tp = value; RaisePropertyChanged("form_tp"); }
        }

        private string _para1;
        public string para1
        {
            get { return _para1; }
            set { _para1 = value; RaisePropertyChanged("para1", ModelEntityUpdated); }
        }
        private string _para2;
        public string para2
        {
            get { return _para2; }
            set { _para2 = value; RaisePropertyChanged("para2", ModelEntityUpdated); }
        }
        private string _para3;
        public string para3
        {
            get { return _para3; }
            set { _para3 = value; RaisePropertyChanged("para3", ModelEntityUpdated); }
        }
        private string _para4;
        public string para4
        {
            get { return _para4; }
            set { _para4 = value; RaisePropertyChanged("para4", ModelEntityUpdated); }
        }
        private string _para5;
        public string para5
        {
            get { return _para5; }
            set { _para5 = value; RaisePropertyChanged("para5", ModelEntityUpdated); }
        }


        private string _note;
        public string note
        {
            get { return _note; }
            set { _note = value; RaisePropertyChanged("note"); }
        }

        private string _description;
        public string description
        {
            get { return _description; }
            set { _description = value; RaisePropertyChanged("description"); }
        }

        private string _del_note;
        public string del_note
        {
            get { return _del_note; }
            set { _del_note = value; RaisePropertyChanged("del_note", ModelEntityUpdated); }
        }

        private Nullable<System.DateTime> _del_note_date;
        public Nullable<System.DateTime> del_note_date
        {
            get { return _del_note_date; }
            set { _del_note_date = value; RaisePropertyChanged("del_note_date", ModelEntityUpdated); }
        }

        private string _grnno;
        public string grnno
        {
            get { return _grnno; }
            set { _grnno = value; RaisePropertyChanged("grnno", ModelEntityUpdated); }
        }

        private string _gl_code;
        public string gl_code
        {
            get { return _gl_code; }
            set { _gl_code = value; RaisePropertyChanged("gl_code", ModelEntityUpdated); }
        }

        private string _address;
        public string address
        {
            get { return _address; }
            set { _address = value; RaisePropertyChanged("address"); }
        }
        private string _address1;
        public string address1
        {
            get { return _address1; }
            set { _address1 = value; RaisePropertyChanged("address1"); }
        }

        private string _city;
        public string city
        {
            get { return _city; }
            set { _city = value; RaisePropertyChanged("city"); }
        }

        private string _state_code;
        public string state_code
        {
            get { return _state_code; }
            set { _state_code = value; RaisePropertyChanged("state_code"); }
        }
        private string _state_name;
        public string state_name
        {
            get { return _state_name; }
            set { _state_name = value; RaisePropertyChanged("state_name"); }
        }

        private string _country_code;
        public string country_code
        {
            get { return _country_code; }
            set { _country_code = value; RaisePropertyChanged("country_code"); }
        }

        private string _pincode;
        public string pincode
        {
            get { return _pincode; }
            set { _pincode = value; RaisePropertyChanged("pincode"); }
        }

        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code"); }
        }

        private string _volume_unit;
        public string volume_unit
        {
            get { return _volume_unit; }
            set { _volume_unit = value; RaisePropertyChanged("volume_unit", ModelEntityUpdated); }
        }

        private Nullable<decimal> _volume;
        public Nullable<decimal> volume
        {
            get { return _volume; }
            set { _volume = value; RaisePropertyChanged("volume", ModelEntityUpdated); }
        }

        private Nullable<decimal> _gross_wt;
        public Nullable<decimal> gross_wt
        {
            get { return _gross_wt; }
            set { _gross_wt = value; RaisePropertyChanged("gross_wt", ModelEntityUpdated); }
        }


        private Nullable<decimal> _net_wt;
        public Nullable<decimal> net_wt
        {
            get { return _net_wt; }
            set { _net_wt = value; RaisePropertyChanged("net_wt", ModelEntityUpdated); }
        }

        private string _ProdNmCd;
        public string ProdNmCd
        {
            get { return _ProdNmCd; }
            set { _ProdNmCd = value; RaisePropertyChanged("ProdNmCd", ModelEntityUpdated); }
        }

        private string _incoterms;
        public string incoterms
        {
            get { return _incoterms; }
            set { _incoterms = value; RaisePropertyChanged("incoterms", ModelEntityUpdated); }
        }

        private string _inco_desc;
        public string inco_desc
        {
            get { return _inco_desc; }
            set { _inco_desc = value; RaisePropertyChanged("inco_desc", ModelEntityUpdated); }
        }
        private string _po_code;
        public string po_code
        {
            get { return _po_code; }
            set { _po_code = value; RaisePropertyChanged("po_code"); }
        }

        private string _dc_code;
        public string dc_code
        {
            get { return _dc_code; }
            set { _dc_code = value; RaisePropertyChanged("dc_code"); }
        }

        private string _ship_cnd;
        public string ship_cnd
        {
            get { return _ship_cnd; }
            set { _ship_cnd = value; RaisePropertyChanged("ship_cnd"); }
        }

        private string _div_code;
        public string div_code
        {
            get { return _div_code; }
            set { _div_code = value; RaisePropertyChanged("div_code", ModelEntityUpdated); }
        }

        private string _rec_plant;
        public string rec_plant
        {
            get { return _rec_plant; }
            set { _rec_plant = value; RaisePropertyChanged("rec_plant", ModelEntityUpdated); }
        }

        private string _supp_plant;
        public string supp_plant
        {
            get { return _supp_plant; }
            set { _supp_plant = value; RaisePropertyChanged("supp_plant", ModelEntityUpdated); }
        }

        private Nullable<int> _pack_no_service;
        public Nullable<int> pack_no_service
        {
            get { return _pack_no_service; }
            set { _pack_no_service = value; RaisePropertyChanged("pack_no_service"); }
        }


        private Nullable<int> _line_no_service;
        public Nullable<int> line_no_service
        {
            get { return _line_no_service; }
            set { _line_no_service = value; RaisePropertyChanged("line_no_service"); }
        }



        private string _ind_disc;
        public string ind_disc
        {
            get { return _ind_disc; }
            set { _ind_disc = value; RaisePropertyChanged("ind_disc"); }
        }

        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status", ModelEntityUpdated); }
        }

        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active", ModelEntityUpdated); }
        }

        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
        }

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
        }


        private string _editby;
        public string editby
        {
            get { return _editby; }
            set { _editby = value; RaisePropertyChanged("editby"); }
        }

        private string _fin_year;
        public string fin_year
        {
            get { return _fin_year; }
            set { _fin_year = value; RaisePropertyChanged("fin_year", ModelEntityUpdated); }
        }
        private string _posting_period;
        public string posting_period
        {
            get { return _posting_period; }
            set { _posting_period = value; RaisePropertyChanged("posting_period", ModelEntityUpdated); }
        }

        private Nullable<bool> _doc_cancel;
        public Nullable<bool> doc_cancel
        {
            get { return _doc_cancel; }
            set { _doc_cancel = value; RaisePropertyChanged("doc_cancel"); }
        }

        private string _cancel_reason;
        public string cancel_reason
        {
            get { return _cancel_reason; }
            set { _cancel_reason = value; RaisePropertyChanged("cancel_reason"); }
        }
        private string _pg_code { get; set; }
        public string pg_code
        {
            get { return _pg_code; }
            set { _pg_code = value; RaisePropertyChanged("pg_code"); }
        }
        private string _cost_center { get; set; }
        public string cost_center
        {
            get { return _cost_center; }
            set { _cost_center = value; RaisePropertyChanged("cost_center", ModelEntityUpdated); }
        }
        //private string _local_export { get; set; }
        //public string local_export
        //{
        //    get { return _local_export; }
        //    set { _local_export = value; RaisePropertyChanged("local_export", ModelEntityUpdated); }
        //}
        private string _ind_trade;
        [Required(ErrorMessage = "Field 'Transaction Trade Type' is required.")]
        public string ind_trade
        {
            get { return _ind_trade; }
            set
            {
                if (_ind_trade != value)
                { _ind_trade = value; RaisePropertyChanged("ind_trade", ModelEntityUpdated); }
            }
        }
        private string _export_ind;
        public string export_ind
        {
            get { return _export_ind; }
            set { _export_ind = value; RaisePropertyChanged("export_ind", ModelEntityUpdated); }
        }
        private string _cust_acc;
        public string cust_acc
        {
            get { return _cust_acc; }
            set { _cust_acc = value; RaisePropertyChanged("cust_acc"); }
        }
        private Nullable<decimal> _loc_curr;
        public Nullable<decimal> loc_curr
        {
            get { return _loc_curr; }
            set { _loc_curr = value; RaisePropertyChanged("loc_curr", ModelEntityUpdated); }
        }
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

        private Nullable<decimal> _net_value;
        public Nullable<decimal> net_value
        {
            get { return _net_value; }
            set { _net_value = value; RaisePropertyChanged("net_value"); }
        }

        private string _withholding_tax;
        public string withholding_tax
        {
            get { return _withholding_tax; }
            set { _withholding_tax = value; RaisePropertyChanged("withholding_tax", ModelEntityUpdated); }
        }

        private Nullable<decimal> _withholding_value;
        public Nullable<decimal> withholding_value
        {
            get { return _withholding_value; }
            set { _withholding_value = value; RaisePropertyChanged("withholding_value"); }
        }

        private Nullable<decimal> _withholding_ex_amt;
        public Nullable<decimal> withholding_ex_amt
        {
            get { return _withholding_ex_amt; }
            set { _withholding_ex_amt = value; RaisePropertyChanged("withholding_ex_amt"); }
        }

        private Nullable<decimal> _local_net_value;
        public Nullable<decimal> local_net_value
        {
            get { return _local_net_value; }
            set { _local_net_value = value; RaisePropertyChanged("local_net_value"); }
        }

        private Nullable<decimal> _local_gross_amount;
        public Nullable<decimal> local_gross_amount
        {
            get { return _local_gross_amount; }
            set { _local_gross_amount = value; RaisePropertyChanged("local_gross_amount"); }
        }

        private Nullable<decimal> _local_tax_amount;
        public Nullable<decimal> local_tax_amount
        {
            get { return _local_tax_amount; }
            set { _local_tax_amount = value; RaisePropertyChanged("local_tax_amount"); }
        }

        private Nullable<decimal> _local_total;
        public Nullable<decimal> local_total
        {
            get { return _local_total; }
            set { _local_total = value; RaisePropertyChanged("local_total"); }
        }

        private Nullable<decimal> _local_subtotal;
        public Nullable<decimal> local_subtotal
        {
            get { return _local_subtotal; }
            set { _local_subtotal = value; RaisePropertyChanged("local_subtotal"); }
        }

        private Nullable<decimal> _local_round_up;
        public Nullable<decimal> local_round_up
        {
            get { return _local_round_up; }
            set { _local_round_up = value; RaisePropertyChanged("local_round_up"); }
        }

        private Nullable<decimal> _local_roundup_total;
        public Nullable<decimal> local_roundup_total
        {
            get { return _local_roundup_total; }
            set { _local_roundup_total = value; RaisePropertyChanged("local_roundup_total"); }
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


        public string XmlDataDocument_PUR_T005_A { get; set; }
        public string XmlDataDocument_PUR_T005_C { get; set; }
        public string XmlDataDocument_ACC_T006_C { get; set; }
        public string XmlDataDocument_ACC_T006_D { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }
        //scaler
        private string _supplier_party_Nm;
        public string supplier_party_Nm
        {
            get { return _supplier_party_Nm; }
            set { _supplier_party_Nm = value; RaisePropertyChanged("supplier_party_Nm", ModelEntityUpdated); }
        }
        private string _payee_name;
        public string payee_name
        {
            get { return _payee_name; }
            set { _payee_name = value; RaisePropertyChanged("payee_name", ModelEntityUpdated); }
        }
        private string _pur_org;
        public string pur_org
        {
            get { return _pur_org; }
            set { _pur_org = value; RaisePropertyChanged("pur_org", ModelEntityUpdated); }
        }
        private string _bank_name;
        public string bank_name
        {
            get { return _bank_name; }
            set { _bank_name = value; RaisePropertyChanged("bank_name", ModelEntityUpdated); }
        }
        private string _nastro_bank_name;
        public string nastro_bank_name
        {
            get { return _nastro_bank_name; }
            set { _nastro_bank_name = value; RaisePropertyChanged("nastro_bank_name", ModelEntityUpdated); }
        }
        private string _pg_name;
        public string pg_name
        {
            get { return _pg_name; }
            set { _pg_name = value; RaisePropertyChanged("pg_name", ModelEntityUpdated); }
        }
        private string _cost_center_Desc;
        public string cost_center_Desc
        {
            get { return _cost_center_Desc; }
            set { _cost_center_Desc = value; RaisePropertyChanged("cost_center_Desc", ModelEntityUpdated); }
        }
        private string _j_name;
        public string j_name
        {
            get { return _j_name; }
            set { _j_name = value; RaisePropertyChanged("j_name", ModelEntityUpdated); }
        }


        private Nullable<System.DateTime> _inv_due_date;
        public Nullable<System.DateTime> inv_due_date
        {
            get { return _inv_due_date; }
            set
            {
                _inv_due_date = value;
                RaisePropertyChanged("inv_due_date");
            }
        }

        private string _amt_in_wordsLoc;
        public string amt_in_wordsLoc
        {
            get { return _amt_in_wordsLoc; }
            set
            {
                _amt_in_wordsLoc = value;
                RaisePropertyChanged("amt_in_wordsLoc", ModelEntityUpdated);
            }
        }

        private Nullable<System.DateTime> _FrmDate;
        public Nullable<System.DateTime> FrmDate//Production FrmDate
        {
            get { return _FrmDate; }
            set
            {
                _FrmDate = value;
                RaisePropertyChanged("FrmDate");
            }
        }
        private Nullable<System.DateTime> _ToDate;
        public Nullable<System.DateTime> ToDate//Production ToDate
        {
            get { return _ToDate; }
            set
            {
                _ToDate = value;
                RaisePropertyChanged("ToDate");
            }
        }
        private string _local_curr;
        public string local_curr
        {
            get { return _local_curr; }
            set { _local_curr = value; RaisePropertyChanged("local_curr", ModelEntityUpdated); }
        }

        private string _local_currency;
        public string local_currency
        {
            get { return _local_currency; }
            set { _local_currency = value; RaisePropertyChanged("local_currency", ModelEntityUpdated); }
        }



        private Nullable<int> _exc_rate_tp;
        public Nullable<int> exc_rate_tp
        {
            get { return _exc_rate_tp; }
            set { _exc_rate_tp = value; RaisePropertyChanged("exc_rate_tp"); }
        }

        private string _assign_no;
        public string assign_no
        {
            get { return _assign_no; }
            set { _assign_no = value; RaisePropertyChanged("assign_no"); }
        }

        private Nullable<decimal> _disc_amt;
        public Nullable<decimal> disc_amt
        {
            get { return _disc_amt; }
            set { _disc_amt = value; RaisePropertyChanged("disc_amt"); }
        }

        private Nullable<decimal> _fright_values;
        public Nullable<decimal> fright_values
        {
            get { return _fright_values; }
            set { _fright_values = value; RaisePropertyChanged("fright_values"); }
        }

        private string _cancel_doc;
        public string cancel_doc
        {
            get { return _cancel_doc; }
            set { _cancel_doc = value; RaisePropertyChanged("cancel_doc"); }
        }

        private Nullable<decimal> _lc_exc_rate;
        public Nullable<decimal> lc_exc_rate
        {
            get { return _lc_exc_rate; }
            set { _lc_exc_rate = value; RaisePropertyChanged("lc_exc_rate"); }
        }

        private string _party_bank;
        public string party_bank
        {
            get { return _party_bank; }
            set { _party_bank = value; RaisePropertyChanged("party_bank"); }
        }

        private string _buss_place;
        public string buss_place
        {
            get { return _buss_place; }
            set { _buss_place = value; RaisePropertyChanged("buss_place"); }
        }

        private string _contract_acc;
        public string contract_acc
        {
            get { return _contract_acc; }
            set { _contract_acc = value; RaisePropertyChanged("contract_acc"); }
        }

        private string _cancel_re;
        public string cancel_re
        {
            get { return _cancel_re; }
            set { _cancel_re = value; RaisePropertyChanged("cancel_re"); }
        }

        private string _lc_cond;
        public string lc_cond
        {
            get { return _lc_cond; }
            set { _lc_cond = value; RaisePropertyChanged("lc_cond"); }
        }

        private string _consignee;
        public string consignee
        {
            get { return _consignee; }
            set { _consignee = value; RaisePropertyChanged("consignee"); }
        }

        private Nullable<int> _form_type;
        public Nullable<int> form_type
        {
            get { return _form_type; }
            set { _form_type = value; RaisePropertyChanged("form_type"); }
        }

        private string _lr_no;
        public string lr_no
        {
            get { return _lr_no; }
            set { _lr_no = value; RaisePropertyChanged("lr_no"); }
        }

        private Nullable<System.DateTime> _lr_date;
        public Nullable<System.DateTime> lr_date
        {
            get { return _lr_date; }
            set { _lr_date = value; RaisePropertyChanged("lr_date"); }
        }

        private string _del_no;
        public string del_no
        {
            get { return _del_no; }
            set { _del_no = value; RaisePropertyChanged("del_no"); }
        }

        private Nullable<System.DateTime> _del_date;
        public Nullable<System.DateTime> del_date
        {
            get { return _del_date; }
            set { _del_date = value; RaisePropertyChanged("del_date"); }
        }

        private string _trans_mode;
        public string trans_mode
        {
            get { return _trans_mode; }
            set { _trans_mode = value; RaisePropertyChanged("trans_mode"); }
        }

        private string _transporter;
        public string transporter
        {
            get { return _transporter; }
            set { _transporter = value; RaisePropertyChanged("transporter"); }
        }

        private string _pack_det;
        public string pack_det
        {
            get { return _pack_det; }
            set { _pack_det = value; RaisePropertyChanged("pack_det"); }
        }

        private string _pre_carrage;
        public string pre_carrage
        {
            get { return _pre_carrage; }
            set { _pre_carrage = value; RaisePropertyChanged("pre_carrage"); }
        }

        private string _pre_carrage_place;
        public string pre_carrage_place
        {
            get { return _pre_carrage_place; }
            set { _pre_carrage_place = value; RaisePropertyChanged("pre_carrage_place"); }
        }

        private string _dest_country_cd;
        public string dest_country_cd
        {
            get { return _dest_country_cd; }
            set { _dest_country_cd = value; RaisePropertyChanged("dest_country_cd"); }
        }

        private string _port_load;
        public string port_load
        {
            get { return _port_load; }
            set { _port_load = value; RaisePropertyChanged("port_load"); }
        }

        private string _port_desc;
        public string port_desc
        {
            get { return _port_desc; }
            set { _port_desc = value; RaisePropertyChanged("port_desc"); }
        }

        private string _port_final;
        public string port_final
        {
            get { return _port_final; }
            set { _port_final = value; RaisePropertyChanged("port_final"); }
        }

        private string _final_dest;
        public string final_dest
        {
            get { return _final_dest; }
            set { _final_dest = value; RaisePropertyChanged("final_dest"); }
        }

        private string _ship_terms;
        public string ship_terms
        {
            get { return _ship_terms; }
            set { _ship_terms = value; RaisePropertyChanged("ship_terms"); }
        }

        private string _advance_lic;
        public string advance_lic
        {
            get { return _advance_lic; }
            set { _advance_lic = value; RaisePropertyChanged("advance_lic"); }
        }

        private string _cf_agent_cd;
        public string cf_agent_cd
        {
            get { return _cf_agent_cd; }
            set { _cf_agent_cd = value; RaisePropertyChanged("cf_agent_cd"); }
        }

        private string _cf_agent_name;
        public string cf_agent_name
        {
            get { return _cf_agent_name; }
            set { _cf_agent_name = value; RaisePropertyChanged("cf_agent_name"); }
        }
        private string _lic_cod;
        public string lic_cod
        {
            get { return _lic_cod; }
            set { _lic_cod = value; RaisePropertyChanged("lic_cod"); }
        }

        private string _org_country_cd;
        public string org_country_cd
        {
            get { return _org_country_cd; }
            set { _org_country_cd = value; RaisePropertyChanged("org_country_cd"); }
        }

        private string _pack_rem;
        public string pack_rem
        {
            get { return _pack_rem; }
            set { _pack_rem = value; RaisePropertyChanged("pack_rem"); }
        }

        private string _ship_mark;
        public string ship_mark
        {
            get { return _ship_mark; }
            set { _ship_mark = value; RaisePropertyChanged("ship_mark"); }
        }

        private string _vess_flight;
        public string vess_flight
        {
            get { return _vess_flight; }
            set { _vess_flight = value; RaisePropertyChanged("vess_flight"); }
        }

        private string _ref_data;
        public string ref_data
        {
            get { return _ref_data; }
            set { _ref_data = value; RaisePropertyChanged("ref_data"); }
        }

        private string _ref_data2;
        public string ref_data2
        {
            get { return _ref_data2; }
            set { _ref_data2 = value; RaisePropertyChanged("ref_data2"); }
        }

        private string _notify_party;
        public string notify_party
        {
            get { return _notify_party; }
            set { _notify_party = value; RaisePropertyChanged("notify_party"); }
        }

        private string _cust_cat_no;
        public string cust_cat_no
        {
            get { return _cust_cat_no; }
            set { _cust_cat_no = value; RaisePropertyChanged("cust_cat_no"); }
        }

        private string _bill_address_id;
        public string bill_address_id
        {
            get { return _bill_address_id; }
            set { _bill_address_id = value; RaisePropertyChanged("bill_address_id"); }
        }

        private string _shipping_mark;

        public string shipping_mark
        {
            get { return _shipping_mark; }
            set { _shipping_mark = value; RaisePropertyChanged("shipping_mark"); }
        }

        private string _insurance;
        public string insurance
        {
            get { return _insurance; }
            set { _insurance = value; RaisePropertyChanged("insurance"); }
        }

        private string _packing;
        public string packing
        {
            get { return _packing; }
            set { _packing = value; RaisePropertyChanged("packing"); }
        }

        private string _transhipment;
        public string transhipment
        {
            get { return _transhipment; }
            set { _transhipment = value; RaisePropertyChanged("transhipment"); }
        }

        private string _partshipment;
        public string partshipment
        {
            get { return _partshipment; }
            set { _partshipment = value; RaisePropertyChanged("partshipment"); }
        }

        private Nullable<System.DateTime> _shipment_date;
        public Nullable<System.DateTime> shipment_date
        {
            get { return _shipment_date; }
            set { _shipment_date = value; RaisePropertyChanged("shipment_date"); }
        }

        private Nullable<System.DateTime> _validity_date;
        public Nullable<System.DateTime> validity_date
        {
            get { return _validity_date; }
            set { _validity_date = value; RaisePropertyChanged("validity_date"); }
        }

        private string _payment_mode;
        public string payment_mode
        {
            get { return _payment_mode; }
            set { _payment_mode = value; RaisePropertyChanged("payment_mode"); }
        }

        private string _sg_code;
        public string sg_code
        {
            get { return _sg_code; }
            set { _sg_code = value; RaisePropertyChanged("sg_code"); }
        }

        private Nullable<System.DateTime> _po_date;
        public Nullable<System.DateTime> po_date
        {
            get { return _po_date; }
            set { _po_date = value; RaisePropertyChanged("po_date"); }
        }

        private Nullable<System.DateTime> _ref_date;
        public Nullable<System.DateTime> ref_date
        {
            get { return _ref_date; }
            set { _ref_date = value; RaisePropertyChanged("ref_date"); }
        }

        private string _stock_code;
        public string stock_code
        {
            get { return _stock_code; }
            set { _stock_code = value; RaisePropertyChanged("stock_code"); }
        }

        private string _incoterm2;
        public string incoterm2
        {
            get { return _incoterm2; }
            set { _incoterm2 = value; RaisePropertyChanged("incoterm2"); }
        }

        private string _status_remark;
        public string status_remark
        {
            get { return _status_remark; }
            set { _status_remark = value; RaisePropertyChanged("status_remark"); }
        }

        private string _symbol;
        public string symbol
        {
            get { return _symbol; }
            set { _symbol = value; RaisePropertyChanged("symbol"); }
        }

        private string _bom_no;
        public string bom_no
        {
            get { return _bom_no; }
            set { _bom_no = value; RaisePropertyChanged("bom_no"); }
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

        //Added by Priya
        private string _po_no;
        public string po_no
        {
            get { return _po_no; }
            set { _po_no = value; RaisePropertyChanged("po_no"); }
        }
        private Nullable<decimal> _ass_value;
        public Nullable<decimal> ass_value
        {
            get { return _ass_value; }
            set { _ass_value = value; RaisePropertyChanged("ass_value"); }
        }
        private string _round_up_type;
        public string round_up_type
        {
            get { return _round_up_type; }
            set { _round_up_type = value; RaisePropertyChanged("round_up_type"); }
        }
        private string _gst_PartyId;
        public string gst_PartyId
        {
            get
            {
                return _gst_PartyId;
            }

            set
            {
                _gst_PartyId = value; RaisePropertyChanged("gst_PartyId");
            }
        }
        private string _plc_name;
        public string plc_name
        {
            get
            {
                return _plc_name;
            }

            set
            {
                _plc_name = value; RaisePropertyChanged("plc_name");
            }
        }
        //private string _buss_place;
        //public string buss_place
        //{
        //    get
        //    {
        //        return _buss_place;
        //    }

        //    set
        //    {
        //        _buss_place = value; RaisePropertyChanged("buss_place");
        //    }
        //}
        private string _ref_gst_PartyId;
        public string ref_gst_PartyId
        {
            get
            {
                return _ref_gst_PartyId;
            }

            set
            {
                _ref_gst_PartyId = value; RaisePropertyChanged("ref_gst_PartyId");
            }
        }
        private string _ref_buss_place;
        public string ref_buss_place
        {
            get
            {
                return _ref_buss_place;
            }

            set
            {
                _ref_buss_place = value; RaisePropertyChanged("ref_buss_place");
            }
        }

        //private string _STP_gstinno;
        //public string STP_gstinno
        //{
        //    get
        //    {
        //        return _STP_gstinno;
        //    }

        //    set
        //    {
        //        _STP_gstinno = value; RaisePropertyChanged("STP_gstinno");
        //    }
        //}
        //private string _DTP_gstinno;
        //public string DTP_gstinno
        //{
        //    get
        //    {
        //        return _DTP_gstinno;
        //    }

        //    set
        //    {
        //        _DTP_gstinno = value; RaisePropertyChanged("DTP_gstinno");
        //    }
        //}
        //private Nullable<System.DateTime> _STP_gstindate;
        //public Nullable<System.DateTime> STP_gstindate
        //{
        //    get { return _STP_gstindate; }
        //    set { _STP_gstindate = value; RaisePropertyChanged("STP_gstindate"); }
        //}

        //private Nullable<System.DateTime> _DTP_gstindate;
        //public Nullable<System.DateTime> DTP_gstindate
        //{
        //    get { return _DTP_gstindate; }
        //    set { _DTP_gstindate = value; RaisePropertyChanged("DTP_gstindate"); }
        //}

        private string _data1;
        public string data1
        {
            get { return _data1; }
            set { _data1 = value; RaisePropertyChanged("data1"); }
        }

        private string _del_address_id;
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
                    _del_address_id = value; RaisePropertyChanged("del_address_id");
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
        public decimal? order_limit { get; set; }
        public bool? order_limit_tax { get; set; }
        private string _party_bank_name;
        public string party_bank_name
        {
            get { return _party_bank_name; }
            set { _party_bank_name = value; RaisePropertyChanged("party_bank_name"); }
        }
        private string _amt_word_local;
        public string amt_word_local
        {
            get { return _amt_word_local; }
            set { _amt_word_local = value; RaisePropertyChanged("amt_word_local"); }
        }
        #region //Filter Search Variables
        private DateTime? _Fltr_FrmDate;
        public DateTime? Fltr_FrmDate   //Production FrmDate
        {
            get { return _Fltr_FrmDate; }
            set
            {
                if (_Fltr_FrmDate != value)
                {
                    _Fltr_FrmDate = value;
                    RaisePropertyChanged("Fltr_FrmDate");
                }
            }
        }
        private DateTime? _Fltr_ToDate;
        public DateTime? Fltr_ToDate    //Production ToDate
        {

            get { return _Fltr_ToDate; }
            set
            {
                if (_Fltr_ToDate != value)
                {
                    _Fltr_ToDate = value;
                    RaisePropertyChanged("Fltr_ToDate");
                }
            }
        }
        private string _Fltr_t_status;
        public string Fltr_t_status
        {
            get { return _Fltr_t_status; }
            set
            {
                if (_Fltr_t_status != value)
                {
                    _Fltr_t_status = value;
                    RaisePropertyChanged("Fltr_t_status");
                }
            }
        }
        private string _Fltr_t_display;
        public string Fltr_t_display
        {
            get { return _Fltr_t_display; }
            set
            {
                if (_Fltr_t_display != value)
                {
                    _Fltr_t_display = value;
                    RaisePropertyChanged("Fltr_t_display");
                }
            }
        }
        private string _Fltr_doc_type;
        public string Fltr_doc_type
        {
            get { return _Fltr_doc_type; }
            set
            {
                if (_Fltr_doc_type != value)
                {
                    _Fltr_doc_type = value;
                    RaisePropertyChanged("Fltr_doc_type");
                }
            }
        }
        private bool _Fltr_active;
        public bool Fltr_active
        {
            get { return _Fltr_active; }
            set
            {
                if (_Fltr_active != value)
                {
                    _Fltr_active = value;
                    RaisePropertyChanged("Fltr_active");
                }
            }
        }
        private string _Fltr_PartyId;
        public string Fltr_PartyId
        {
            get { return _Fltr_PartyId; }
            set
            {
                if (_Fltr_PartyId != value)
                {
                    _Fltr_PartyId = value;
                    RaisePropertyChanged("Fltr_PartyId");
                }
            }
        }
        private string _Fltr_PartyNm;
        public string Fltr_PartyNm
        {
            get { return _Fltr_PartyNm; }
            set
            {
                if (_Fltr_PartyNm != value)
                {
                    _Fltr_PartyNm = value;
                    RaisePropertyChanged("Fltr_PartyNm");
                }
            }
        }

        #endregion

        public string pt_name { get; set; } // payment Term Name
        public string pt_code { get; set; } // payment Term code
    }
    public class PUR_T005_A : ObjectBase
    {

        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id", ModelEntityUpdated); }
        }

        private int _line_id;
        public int line_id
        {
            get { return _line_id; }
            set { _line_id = value; RaisePropertyChanged("line_id", ModelEntityUpdated); }
        }

        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set { _doc_no = value; RaisePropertyChanged("doc_no", ModelEntityUpdated); }
        }

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code", ModelEntityUpdated); }
        }

        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id", ModelEntityUpdated); }
        }


        private string _PartyId;
        public string PartyId
        {
            get { return _PartyId; }
            set { _PartyId = value; RaisePropertyChanged("PartyId", ModelEntityUpdated); }
        }

        private string _curr_code;
        public string curr_code
        {
            get { return _curr_code; }
            set { _curr_code = value; RaisePropertyChanged("curr_code", ModelEntityUpdated); }
        }

        private string _ItemCode;
        public string ItemCode
        {
            get { return _ItemCode; }
            set { _ItemCode = value; RaisePropertyChanged("ItemCode", ModelEntityUpdated); }
        }

        private string _item_desc;
        public string item_desc
        {
            get { return _item_desc; }
            set { _item_desc = value; RaisePropertyChanged("item_desc", ModelEntityUpdated); }
        }

        private string _item_cat;
        public string item_cat
        {
            get { return _item_cat; }
            set { _item_cat = value; RaisePropertyChanged("item_cat", ModelEntityUpdated); }
        }
        private string _doc_item_code;
        public string doc_item_code
        {
            get { return _doc_item_code; }
            set { _doc_item_code = value; RaisePropertyChanged("doc_item_code", ModelEntityUpdated); }
        }

        private string _pur_doc_no;
        public string pur_doc_no
        {
            get { return _pur_doc_no; }
            set { _pur_doc_no = value; RaisePropertyChanged("pur_doc_no", ModelEntityUpdated); }
        }

        private string _pur_doc_item_cd;
        public string pur_doc_item_cd
        {
            get { return _pur_doc_item_cd; }
            set { _pur_doc_item_cd = value; RaisePropertyChanged("pur_doc_item_cd", ModelEntityUpdated); }
        }

        private string _tax_id;
        public string tax_id
        {
            get { return _tax_id; }
            set { _tax_id = value; RaisePropertyChanged("tax_id", ModelEntityUpdated); }
        }

        private string _tax_code;
        public string tax_code
        {
            get { return _tax_code; }
            set { _tax_code = value; RaisePropertyChanged("tax_code", ModelEntityUpdated); }
        }

        private string _tax_juri;
        public string tax_juri
        {
            get { return _tax_juri; }
            set { _tax_juri = value; RaisePropertyChanged("tax_juri", ModelEntityUpdated); }
        }


        private Nullable<decimal> _tax_amt;
        public Nullable<decimal> tax_amt
        {
            get { return _tax_amt; }
            set { _tax_amt = value; RaisePropertyChanged("tax_amt", ModelEntityUpdated); }
        }

        private Nullable<decimal> _discount;
        public Nullable<decimal> discount
        {
            get { return _discount; }
            set
            {
                if (_discount != value)
                {
                    _discount = value; RaisePropertyChanged("discount", ModelEntityUpdated);
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

        private string _discount_type;
        public string discount_type
        {
            get { return _discount_type; }
            set
            {
                if (_discount_type != value.ToUpper())
                {
                    _discount_type = value.ToUpper(); RaisePropertyChanged("discount_type", ModelEntityUpdated);
                }
            }
        }



        private Nullable<decimal> _amount;
        public Nullable<decimal> amount
        {
            get { return _amount; }
            set { _amount = value; RaisePropertyChanged("amount", ModelEntityUpdated); }
        }

        private Nullable<decimal> _subtotal;
        public Nullable<decimal> subtotal
        {
            get { return _subtotal; }
            set { _subtotal = value; RaisePropertyChanged("subtotal", ModelEntityUpdated); }
        }


        private string _debt_cr;
        public string debt_cr
        {
            get { return _debt_cr; }
            set { _debt_cr = value; RaisePropertyChanged("debt_cr", ModelEntityUpdated); }
        }

        private Nullable<decimal> _qty;
        public Nullable<decimal> qty
        {
            get { return _qty; }
            set { _qty = value; RaisePropertyChanged("qty", ModelEntityUpdated); }
        }
        private Nullable<decimal> _unit_price;
        public Nullable<decimal> unit_price
        {
            get { return _unit_price; }
            set { _unit_price = value; RaisePropertyChanged("unit_price", ModelEntityUpdated); }
        }

        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code", ModelEntityUpdated); }
        }

        private string _base_unit_cd;
        public string base_unit_cd
        {
            get { return _base_unit_cd; }
            set { _base_unit_cd = value; RaisePropertyChanged("base_unit_cd", ModelEntityUpdated); }
        }


        private Nullable<decimal> _volume;
        public Nullable<decimal> volume
        {
            get { return _volume; }
            set { _volume = value; RaisePropertyChanged("volume", ModelEntityUpdated); }
        }

        private string _volume_unit;
        public string volume_unit
        {
            get { return _volume_unit; }
            set { _volume_unit = value; RaisePropertyChanged("volume_unit", ModelEntityUpdated); }
        }

        private string _weight_unit;
        public string weight_unit
        {
            get { return _weight_unit; }
            set { _weight_unit = value; RaisePropertyChanged("weight_unit", ModelEntityUpdated); }
        }


        private Nullable<decimal> _gross_wt;
        public Nullable<decimal> gross_wt
        {
            get { return _gross_wt; }
            set { _gross_wt = value; RaisePropertyChanged("gross_wt", ModelEntityUpdated); }
        }

        private Nullable<decimal> _net_wt;
        public Nullable<decimal> net_wt
        {
            get { return _net_wt; }
            set { _net_wt = value; RaisePropertyChanged("net_wt", ModelEntityUpdated); }
        }


        private Nullable<decimal> _net_value;
        public Nullable<decimal> net_value
        {
            get { return _net_value; }
            set { _net_value = value; RaisePropertyChanged("net_value", ModelEntityUpdated); }
        }

        private Nullable<decimal> _gross_value;
        public Nullable<decimal> gross_value
        {
            get { return _gross_value; }
            set { _gross_value = value; RaisePropertyChanged("gross_value", ModelEntityUpdated); }
        }

        private Nullable<decimal> _exch_rate;
        public Nullable<decimal> exch_rate
        {
            get { return _exch_rate; }
            set { _exch_rate = value; RaisePropertyChanged("exch_rate", ModelEntityUpdated); }
        }

        private Nullable<decimal> _stock_val;
        public Nullable<decimal> stock_val
        {
            get { return _stock_val; }
            set { _stock_val = value; RaisePropertyChanged("stock_val", ModelEntityUpdated); }
        }


        private Nullable<decimal> _stock_valuated;
        public Nullable<decimal> stock_valuated
        {
            get { return _stock_valuated; }
            set { _stock_valuated = value; RaisePropertyChanged("stock_valuated", ModelEntityUpdated); }
        }

        private string _acc_assign;
        public string acc_assign
        {
            get { return _acc_assign; }
            set { _acc_assign = value; RaisePropertyChanged("acc_assign", ModelEntityUpdated); }
        }

        private string _acc_code;
        public string acc_code
        {
            get { return _acc_code; }
            set { _acc_code = value; RaisePropertyChanged("acc_code", ModelEntityUpdated); }
        }

        private string _pre_post;
        public string pre_post
        {
            get { return _pre_post; }
            set { _pre_post = value; RaisePropertyChanged("pre_post", ModelEntityUpdated); }
        }


        private string _ref_doc;
        public string ref_doc
        {
            get { return _ref_doc; }
            set { _ref_doc = value; RaisePropertyChanged("ref_doc", ModelEntityUpdated); }
        }

        private string _ref_doc_no;
        public string ref_doc_no
        {
            get { return _ref_doc_no; }
            set { _ref_doc_no = value; RaisePropertyChanged("ref_doc_no", ModelEntityUpdated); }
        }



        private string _ref_doc_type;
        public string ref_doc_type
        {
            get { return _ref_doc_type; }
            set { _ref_doc_type = value; RaisePropertyChanged("ref_doc_type", ModelEntityUpdated); }
        }


        private string _ref_doc_cat;
        public string ref_doc_cat
        {
            get { return _ref_doc_cat; }
            set { _ref_doc_cat = value; RaisePropertyChanged("ref_doc_cat", ModelEntityUpdated); }
        }

        private string _ref_item_code;
        public string ref_item_code
        {
            get { return _ref_item_code; }
            set { _ref_item_code = value; RaisePropertyChanged("ref_item_code", ModelEntityUpdated); }
        }


        private Nullable<decimal> _inv_amt;
        public Nullable<decimal> inv_amt
        {
            get { return _inv_amt; }
            set { _inv_amt = value; RaisePropertyChanged("inv_amt", ModelEntityUpdated); }
        }


        private string _ladding_bill;
        public string ladding_bill
        {
            get { return _ladding_bill; }
            set { _ladding_bill = value; RaisePropertyChanged("ladding_bill", ModelEntityUpdated); }
        }

        private string _para1;
        public string para1
        {
            get { return _para1; }
            set { _para1 = value; RaisePropertyChanged("para1", ModelEntityUpdated); }
        }
        private string _para2;
        public string para2
        {
            get { return _para2; }
            set { _para2 = value; RaisePropertyChanged("para2", ModelEntityUpdated); }
        }
        private string _para3;
        public string para3
        {
            get { return _para3; }
            set { _para3 = value; RaisePropertyChanged("para3", ModelEntityUpdated); }
        }
        private string _para4;
        public string para4
        {
            get { return _para4; }
            set { _para4 = value; RaisePropertyChanged("para4", ModelEntityUpdated); }
        }
        private string _para5;
        public string para5
        {
            get { return _para5; }
            set { _para5 = value; RaisePropertyChanged("para5", ModelEntityUpdated); }
        }


        private string _note;
        public string note
        {
            get { return _note; }
            set { _note = value; RaisePropertyChanged("note", ModelEntityUpdated); }
        }


        private string _sku;
        public string sku
        {
            get { return _sku; }
            set { _sku = value; RaisePropertyChanged("sku", ModelEntityUpdated); }
        }

        private string _sku_desc;
        public string sku_desc
        {
            get { return _sku_desc; }
            set { _sku_desc = value; RaisePropertyChanged("sku_desc", ModelEntityUpdated); }
        }


        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status", ModelEntityUpdated); }
        }


        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active", ModelEntityUpdated); }
        }

        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date", ModelEntityUpdated); }
        }

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by", ModelEntityUpdated); }
        }

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date", ModelEntityUpdated); }
        }


        private string _editby;
        public string editby
        {
            get { return _editby; }
            set { _editby = value; RaisePropertyChanged("editby", ModelEntityUpdated); }
        }

        private string _fin_year;
        public string fin_year
        {
            get { return _fin_year; }
            set { _fin_year = value; RaisePropertyChanged("fin_year", ModelEntityUpdated); }
        }

        private string _posting_period;
        public string posting_period
        {
            get { return _posting_period; }
            set { _posting_period = value; RaisePropertyChanged("posting_period", ModelEntityUpdated); }
        }

        private string _grnno;
        public string grnno
        {
            get { return _grnno; }
            set { _grnno = value; RaisePropertyChanged("grnno", ModelEntityUpdated); }
        }


        private string _po_no;
        public string po_no
        {
            get { return _po_no; }
            set { _po_no = value; RaisePropertyChanged("po_no"); }
        }

        private string _profit_center;
        public string profit_center
        {
            get { return _profit_center; }
            set { _profit_center = value; RaisePropertyChanged("profit_center", ModelEntityUpdated); }
        }

        private string _po_code;
        public string po_code
        {
            get { return _po_code; }
            set { _po_code = value; RaisePropertyChanged("po_code", ModelEntityUpdated); }
        }

        private string _dc_code;
        public string dc_code
        {
            get { return _dc_code; }
            set { _dc_code = value; RaisePropertyChanged("dc_code", ModelEntityUpdated); }
        }

        private string _div_code;
        public string div_code
        {
            get { return _div_code; }
            set { _div_code = value; RaisePropertyChanged("div_code", ModelEntityUpdated); }
        }
        private string _country_code;
        public string country_code
        {
            get { return _country_code; }
            set { _country_code = value; RaisePropertyChanged("country_code", ModelEntityUpdated); }
        }
        private string _region;
        public string region
        {
            get { return _region; }
            set { _region = value; RaisePropertyChanged("region", ModelEntityUpdated); }
        }


        private string _city;
        public string city
        {
            get { return _city; }
            set { _city = value; RaisePropertyChanged("city", ModelEntityUpdated); }
        }

        private string _cost_center;
        public string cost_center
        {
            get { return _cost_center; }
            set { _cost_center = value; RaisePropertyChanged("cost_center", ModelEntityUpdated); }
        }

        private string _pg_code;
        public string pg_code
        {
            get { return _pg_code; }
            set { _pg_code = value; RaisePropertyChanged("pg_code", ModelEntityUpdated); }
        }


        private string _store_code;
        public string store_code
        {
            get { return _store_code; }
            set { _store_code = value; RaisePropertyChanged("store_code", ModelEntityUpdated); }
        }


        private string _order_no;
        public string order_no
        {
            get { return _order_no; }
            set { _order_no = value; RaisePropertyChanged("order_no", ModelEntityUpdated); }
        }

        private Nullable<decimal> _conv_fact;
        public Nullable<decimal> conv_fact
        {
            get { return _conv_fact; }
            set { _conv_fact = value; RaisePropertyChanged("conv_fact", ModelEntityUpdated); }
        }

        private string _description;
        public string description
        {
            get { return _description; }
            set { _description = value; RaisePropertyChanged("description", ModelEntityUpdated); }
        }

        private string _block_price;
        public string block_price
        {
            get { return _block_price; }
            set { _block_price = value; RaisePropertyChanged("block_price", ModelEntityUpdated); }
        }

        private string _block_qty;
        public string block_qty
        {
            get { return _block_qty; }
            set { _block_qty = value; RaisePropertyChanged("block_qty", ModelEntityUpdated); }
        }
        private string _block_date;
        public string block_date
        {
            get { return _block_date; }
            set { _block_date = value; RaisePropertyChanged("block_date", ModelEntityUpdated); }
        }

        private string _block_budget;
        public string block_budget
        {
            get { return _block_budget; }
            set { _block_budget = value; RaisePropertyChanged("block_budget", ModelEntityUpdated); }
        }
        private string _ref_item_line_id;
        public string ref_item_line_id
        {
            get { return _ref_item_line_id; }
            set { _ref_item_line_id = value; RaisePropertyChanged("ref_item_line_id", ModelEntityUpdated); }
        }

        private string _doc_history_no;
        public string doc_history_no
        {
            get
            {
                return _doc_history_no;
            }

            set
            {
                _doc_history_no = value; RaisePropertyChanged("doc_history_no", ModelEntityUpdated);
            }
        }

        private Nullable<decimal> _local_net_value;
        public Nullable<decimal> local_net_value
        {
            get { return _local_net_value; }
            set { _local_net_value = value; RaisePropertyChanged("local_net_value"); }

        }

        private Nullable<decimal> _local_gross_value;
        public Nullable<decimal> local_gross_value
        {
            get { return _local_gross_value; }
            set { _local_gross_value = value; RaisePropertyChanged("local_gross_value"); }

        }

        private Nullable<decimal> _local_discount;
        public Nullable<decimal> local_discount
        {
            get { return _local_discount; }
            set { _local_discount = value; RaisePropertyChanged("local_discount"); }

        }

        private Nullable<decimal> _local_amount;
        public Nullable<decimal> local_amount
        {
            get { return _local_amount; }
            set { _local_amount = value; RaisePropertyChanged("local_amount"); }

        }

        private Nullable<decimal> _local_subtotal;
        public Nullable<decimal> local_subtotal
        {
            get { return _local_subtotal; }
            set { _local_subtotal = value; RaisePropertyChanged("local_subtotal"); }

        }

        private Nullable<decimal> _local_inv_amt;
        public Nullable<decimal> local_inv_amt
        {
            get { return _local_inv_amt; }
            set { _local_inv_amt = value; RaisePropertyChanged("local_inv_amt"); }

        }


        //Newly Added Fields 9/12/2016

        private Nullable<decimal> _qty_base_uom;
        public Nullable<decimal> qty_base_uom
        {
            get { return _qty_base_uom; }
            set { _qty_base_uom = value; RaisePropertyChanged("qty_base_uom"); }
        }

        private Nullable<System.DateTime> _price_date;
        public Nullable<System.DateTime> price_date
        {
            get { return _price_date; }
            set { _price_date = value; RaisePropertyChanged("price_date"); }
        }

        private Nullable<System.DateTime> _serv_date;
        public Nullable<System.DateTime> serv_date
        {
            get { return _serv_date; }
            set { _serv_date = value; RaisePropertyChanged("serv_date"); }
        }

        private string _batch;
        public string batch
        {
            get { return _batch; }
            set { _batch = value; RaisePropertyChanged("batch"); }
        }

        private string _located_country;
        public string located_country
        {
            get { return _located_country; }
            set { _located_country = value; RaisePropertyChanged("located_country"); }
        }

        private string _tax_class1;
        public string tax_class1
        {
            get { return _tax_class1; }
            set { _tax_class1 = value; RaisePropertyChanged("tax_class1"); }
        }

        private string _cash_dis;
        public string cash_dis
        {
            get { return _cash_dis; }
            set { _cash_dis = value; RaisePropertyChanged("cash_dis"); }
        }

        private Nullable<decimal> _disc_amt_elig;
        public Nullable<decimal> disc_amt_elig
        {
            get { return _disc_amt_elig; }
            set { _disc_amt_elig = value; RaisePropertyChanged("disc_amt_elig"); }
        }

        private string _eu_art;
        public string eu_art
        {
            get { return _eu_art; }
            set { _eu_art = value; RaisePropertyChanged("eu_art"); }
        }

        private string _value_type;
        public string value_type
        {
            get { return _value_type; }
            set { _value_type = value; RaisePropertyChanged("value_type"); }
        }

        private Nullable<decimal> _doc_cost;
        public Nullable<decimal> doc_cost
        {
            get { return _doc_cost; }
            set { _doc_cost = value; RaisePropertyChanged("doc_cost"); }
        }

        private string _art_no;
        public string art_no
        {
            get { return _art_no; }
            set { _art_no = value; RaisePropertyChanged("art_no"); }
        }


        private string _batch_split;
        public string batch_split
        {
            get { return _batch_split; }
            set { _batch_split = value; RaisePropertyChanged("batch_split"); }
        }

        private Nullable<decimal> _credit_price;
        public Nullable<decimal> credit_price
        {
            get { return _credit_price; }
            set { _credit_price = value; RaisePropertyChanged("credit_price"); }
        }

        private string _credit_ind;
        public string credit_ind
        {
            get { return _credit_ind; }
            set { _credit_ind = value; RaisePropertyChanged("credit_ind"); }
        }

        private string _pay_gua;
        public string pay_gua
        {
            get { return _pay_gua; }
            set { _pay_gua = value; RaisePropertyChanged("pay_gua"); }
        }

        private string _value_con;
        public string value_con
        {
            get { return _value_con; }
            set { _value_con = value; RaisePropertyChanged("value_con"); }
        }

        private string _cont_ItemCode;
        public string cont_ItemCode
        {
            get { return _cont_ItemCode; }
            set { _cont_ItemCode = value; RaisePropertyChanged("cont_ItemCode"); }
        }

        private string _cont_no;
        public string cont_no
        {
            get { return _cont_no; }
            set { _cont_no = value; RaisePropertyChanged("cont_no"); }
        }

        private decimal _lc_exch_rate;
        public decimal lc_exch_rate
        {
            get { return _lc_exch_rate; }
            set { _lc_exch_rate = value; RaisePropertyChanged("lc_exch_rate"); }
        }

        private string _ref_doc_item_cd;
        public string ref_doc_item_cd
        {
            get { return _ref_doc_item_cd; }
            set { _ref_doc_item_cd = value; RaisePropertyChanged("ref_doc_item_cd"); }
        }

        private decimal _loc_rate;
        public decimal loc_rate
        {
            get { return _loc_rate; }
            set { _loc_rate = value; RaisePropertyChanged("loc_rate"); }
        }

        private Nullable<int> _no_of_pkgs;
        public Nullable<int> no_of_pkgs
        {
            get { return _no_of_pkgs; }
            set { _no_of_pkgs = value; RaisePropertyChanged("no_of_pkgs"); }
        }

        private string _cust_cat_no;
        public string cust_cat_no
        {
            get { return _cust_cat_no; }
            set { _cust_cat_no = value; RaisePropertyChanged("cust_cat_no"); }
        }

        private Nullable<int> _package_id;
        public Nullable<int> package_id
        {
            get { return _package_id; }
            set { _package_id = value; RaisePropertyChanged("package_id"); }
        }

        private string _symbol;
        public string symbol
        {
            get { return _symbol; }
            set { _symbol = value; RaisePropertyChanged("symbol"); }
        }


        //scalar
        private Nullable<bool> _StockUnt;
        public Nullable<bool> StockUnt
        {
            get { return _StockUnt; }
            set { _StockUnt = value; RaisePropertyChanged("StockUnt", ModelEntityUpdated); }
        }
        private string _SubCatCode;
        public string SubCatCode
        {
            get { return _SubCatCode; }
            set { _SubCatCode = value; RaisePropertyChanged("SubCatCode", ModelEntityUpdated); }
        }
        private string _textdata;
        public string textdata
        {
            get
            {
                return _textdata;
            }

            set
            {
                _textdata = value; RaisePropertyChanged("textdata", ModelEntityUpdated);
            }
        }

        private Nullable<decimal> _effective_value;
        public Nullable<decimal> effective_value
        {
            get
            {
                return _effective_value;
            }

            set
            {
                _effective_value = value; RaisePropertyChanged("effective_value", ModelEntityUpdated);
            }
        }

        private Nullable<decimal> _tax_amount;
        public Nullable<decimal> tax_amount
        {
            get
            {
                return _tax_amount;
            }

            set
            {
                _tax_amount = value; RaisePropertyChanged("tax_amount", ModelEntityUpdated);
            }
        }

        private string _article_no;
        public string article_no
        {
            get
            {
                return _article_no;
            }

            set
            {
                _article_no = value; RaisePropertyChanged("article_no", ModelEntityUpdated);
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
                _bom_no = value; RaisePropertyChanged("bom_no", ModelEntityUpdated);
            }
        }

        private Nullable<int> _ref_item_row_id;
        public Nullable<int> ref_item_row_id
        {
            get
            {
                return _ref_item_row_id;
            }

            set
            {
                _ref_item_row_id = value; RaisePropertyChanged("ref_item_row_id", ModelEntityUpdated);
            }
        }

        private Nullable<int> _po_item_row_id;
        public Nullable<int> po_item_row_id
        {
            get
            {
                return _po_item_row_id;
            }

            set
            {
                _po_item_row_id = value; RaisePropertyChanged("po_item_row_id", ModelEntityUpdated);
            }
        }
        //Added by Priya
        private string _pro_inv_no;
        public string pro_inv_no
        {
            get
            {
                return _pro_inv_no;
            }

            set
            {
                _pro_inv_no = value; RaisePropertyChanged("pro_inv_no");
            }
        }
        private Nullable<int> _pro_inv_item_row_id;
        public Nullable<int> pro_inv_item_row_id
        {
            get
            {
                return _pro_inv_item_row_id;
            }

            set
            {
                _pro_inv_item_row_id = value; RaisePropertyChanged("pro_inv_item_row_id");
            }
        }
        private string _gl_code;
        public string gl_code
        {
            get
            {
                return _gl_code;
            }

            set
            {
                _gl_code = value; RaisePropertyChanged("gl_code");
            }
        }
        private string _ship_rec_point;
        public string ship_rec_point
        {
            get { return _ship_rec_point; }
            set { _ship_rec_point = value; RaisePropertyChanged("ship_rec_point"); }
        }
        private Nullable<int> _grn_row_id;
        public Nullable<int> grn_row_id
        {
            get
            {
                return _grn_row_id;
            }

            set
            {
                _grn_row_id = value; RaisePropertyChanged("grn_row_id");
            }
        }
        private string _recon_acc;
        public string recon_acc
        {
            get
            {
                return _recon_acc;
            }

            set
            {
                _recon_acc = value; RaisePropertyChanged("recon_acc");
            }
        }
        private string _ship_to_Party;
        public string ship_to_Party
        {
            get
            {
                return _ship_to_Party;
            }

            set
            {
                _ship_to_Party = value; RaisePropertyChanged("ship_to_Party");
            }
        }
        private int? _ship_to_add;
        public int? ship_to_add
        {
            get
            {
                return _ship_to_add;
            }

            set
            {
                _ship_to_add = value; RaisePropertyChanged("ship_to_add");
            }
        }
        private string _buss_place;
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
        private string _ref_ship_to_Party;
        public string ref_ship_to_Party
        {
            get
            {
                return _ref_ship_to_Party;
            }

            set
            {
                _ref_ship_to_Party = value; RaisePropertyChanged("ref_ship_to_Party");
            }
        }
        private int? _ref_ship_to_add;
        public int? ref_ship_to_add
        {
            get
            {
                return _ref_ship_to_add;
            }

            set
            {
                _ref_ship_to_add = value; RaisePropertyChanged("ref_ship_to_add");
            }
        }
        private string _ref_buss_place;
        public string ref_buss_place
        {
            get
            {
                return _ref_buss_place;
            }

            set
            {
                _ref_buss_place = value; RaisePropertyChanged("ref_buss_place");
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
        private string _hs_code { get; set; }
        public string hs_code
        {
            get { return _hs_code; }
            set
            {
                if (_hs_code != value)
                {
                    _hs_code = value; RaisePropertyChanged("hs_code");
                }
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
    }
    public class PUR_T005_B : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id", ModelEntityUpdated); }
        }
        private int _line_id;
        public int line_id
        {
            get { return _line_id; }
            set { _line_id = value; RaisePropertyChanged("line_id", ModelEntityUpdated); }
        }

        private int _tax_id;
        public int tax_id
        {
            get { return _tax_id; }
            set { _tax_id = value; RaisePropertyChanged("tax_id", ModelEntityUpdated); }
        }


    }
    public class PUR_T005_C : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id", ModelEntityUpdated); }
        }

        private Nullable<decimal> _tax_amount;
        public Nullable<decimal> tax_amount
        {
            get { return _tax_amount; }
            set { _tax_amount = value; RaisePropertyChanged("tax_amount", ModelEntityUpdated); }
        }

        private Nullable<int> _account_id;
        public Nullable<int> account_id
        {
            get { return _account_id; }
            set { _account_id = value; RaisePropertyChanged("account_id", ModelEntityUpdated); }
        }

        private Nullable<int> _sequence;
        public Nullable<int> sequence
        {
            get { return _sequence; }
            set { _sequence = value; RaisePropertyChanged("sequence", ModelEntityUpdated); }
        }

        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set { _doc_no = value; RaisePropertyChanged("doc_no", ModelEntityUpdated); }
        }

        private string _manual;
        public string manual
        {
            get { return _manual; }
            set { _manual = value; RaisePropertyChanged("manual", ModelEntityUpdated); }
        }

        private Nullable<decimal> _base_amount;
        public Nullable<decimal> base_amount
        {
            get { return _base_amount; }
            set { _base_amount = value; RaisePropertyChanged("base_amount", ModelEntityUpdated); }
        }

        private Nullable<decimal> _amount;
        public Nullable<decimal> amount
        {
            get { return _amount; }
            set { _amount = value; RaisePropertyChanged("amount", ModelEntityUpdated); }
        }


        private Nullable<decimal> _base;
        public Nullable<decimal> @base
        {
            get { return _base; }
            set { _base = value; RaisePropertyChanged("base", ModelEntityUpdated); }
        }

        private Nullable<int> _tax_code_id;
        public Nullable<int> tax_code_id
        {
            get { return _tax_code_id; }
            set { _tax_code_id = value; RaisePropertyChanged("tax_code_id", ModelEntityUpdated); }
        }


        private Nullable<int> _account_analytic_id;
        public Nullable<int> account_analytic_id
        {
            get { return _account_analytic_id; }
            set { _account_analytic_id = value; RaisePropertyChanged("account_analytic_id", ModelEntityUpdated); }
        }

        private Nullable<int> _base_code_id;
        public Nullable<int> base_code_id
        {
            get { return _base_code_id; }
            set { _base_code_id = value; RaisePropertyChanged("base_code_id", ModelEntityUpdated); }
        }

        private string _tax_name;
        public string tax_name
        {
            get { return _tax_name; }
            set { _tax_name = value; RaisePropertyChanged("tax_name", ModelEntityUpdated); }
        }

        private string _gl_code;
        public string gl_code
        {
            get { return _gl_code; }
            set { _gl_code = value; RaisePropertyChanged("gl_code", ModelEntityUpdated); }
        }


        private string _ItemCode;
        public string ItemCode
        {
            get { return _ItemCode; }
            set { _ItemCode = value; RaisePropertyChanged("ItemCode", ModelEntityUpdated); }
        }

        private string _sku;
        public string sku
        {
            get { return _sku; }
            set { _sku = value; RaisePropertyChanged("sku", ModelEntityUpdated); }
        }


        private Nullable<int> _item_line_id;
        public Nullable<int> item_line_id
        {
            get { return _item_line_id; }
            set { _item_line_id = value; RaisePropertyChanged("item_line_id", ModelEntityUpdated); }
        }

        private string _fin_year;
        public string fin_year
        {
            get { return _fin_year; }
            set { _fin_year = value; RaisePropertyChanged("fin_year", ModelEntityUpdated); }
        }

        private string _posting_period;
        public string posting_period
        {
            get { return _posting_period; }
            set { _posting_period = value; RaisePropertyChanged("posting_period", ModelEntityUpdated); }
        }


        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active", ModelEntityUpdated); }
        }

        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id", ModelEntityUpdated); }
        }

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code", ModelEntityUpdated); }
        }
        private string _dc_ind { get; set; }
        public string dc_ind
        {
            get { return _dc_ind; }
            set { _dc_ind = value; RaisePropertyChanged("dc_ind"); }
        }
        private string _curr_code { get; set; }
        public string curr_code
        {
            get { return _curr_code; }
            set { _curr_code = value; RaisePropertyChanged("curr_code"); }
        }
        private Nullable<decimal> _exch_rate { get; set; }
        public Nullable<decimal> exch_rate
        {
            get { return _exch_rate; }
            set { _exch_rate = value; RaisePropertyChanged("exch_rate"); }
        }
        private string _local_curr { get; set; }
        public string local_curr
        {
            get { return _local_curr; }
            set { _local_curr = value; RaisePropertyChanged("local_curr"); }
        }
        private Nullable<decimal> _amt_local_curr { get; set; }
        public Nullable<decimal> amt_local_curr
        {
            get { return _amt_local_curr; }
            set { _amt_local_curr = value; RaisePropertyChanged("amt_local_curr"); }
        }
        private string _fix_per { get; set; }
        public string fix_per
        {
            get { return _fix_per; }
            set { _fix_per = value; RaisePropertyChanged("fix_per"); }
        }
        private string _symbol;
        public string symbol
        {
            get { return _symbol; }
            set { _symbol = value; RaisePropertyChanged("symbol"); }
        }

    }

    public class PUR_T005_Flip
    {
        public string doc_no { get; set; }
        public Nullable<DateTime> doc_date { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string t_status { get; set; }
        public string ref_doc_no { get; set; }
        public string PartyId { get; set; }
        public string supplier_party_Nm { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string inv_no { get; set; }
        public Nullable<DateTime> inv_date { get; set; }
        public Nullable<DateTime> post_date { get; set; }
        public Nullable<decimal> roundup_total { get; set; }
        public string curr_code { get; set; }
        public string t_display { get; set; }
        public string color_code { get; set; }
    }

    public class MultipleContext_PUR_T005
    {
        public List<STD_DOC_TYPE> DOC_TYPE_LIST { get; set; }
        public List<SYS_M025> STATUS_LIST { get; set; }
        public List<ACC_M013> TAX_LIST { get; set; }
        public List<STD_LIST_BE> REF_DOC_LIST { get; set; }
        public List<STD_LIST_BE> BACK_FLIP_LIST { get; set; }
        public List<PUR_T005_Flip> DocumentDataFlipGrid { get; set; }
        public List<ADM_M028_P> PartyMaster { get; set; }
        public List<PUR_T005_P_RefDoc> Purchase_Invoice_Reference { get; set; }
        public List<ACC_M013_P> TaxList { get; set; }
        public List<ACC_M019_P> Cost_Centers { get; set; }
        public List<ACC_M005_P> Journals { get; set; }
        public List<ADM_M001_M_P> Purchase_orgList { get; set; }
        public List<ADM_M001_P_P> Purchase_groupList { get; set; }
        public List<ADM_M037_P> CurrencyList { get; set; }
        public List<ACC_M004_P> BankList { get; set; }
        public List<ACC_M004_P> PartyBanks { get; set; }
        public List<ADM_M031_P> ParameterList { get; set; } //Parameter Master
        public List<ADM_M030_P> ParamValueList { get; set; }
        public List<SYS_M003_P> ItemCategoryList { get; set; }
        public List<ADM_M038_B_P> UnitList { get; set; }
        public List<ACC_M007_P> PayTerms { get; set; }
        public List<ACC_M021_P> PayMethod { get; set; }
        public List<ACC_M013_P> FormType { get; set; }
        public List<ACC_M003_P> AccountList { get; set; }
        public List<PUR_T005_P_PI_ItemsList> ItemListPopup { get; set; }
        public List<PUR_T005> MasterEntity { get; set; }
        public ObservableCollection<PUR_T005_A> ItemsEntity { get; set; }
        public ObservableCollection<ACC_T006_C> TaxEntity { get; set; }
        public List<SYS_M007> doc_typeList { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<NotificationData> NotificationData { get; set; }

        public List<ADM_M044_P> Incoterms { get; set; }
        public List<ADM_M041_P> LicenseAdvance { get; set; }
        public List<ADM_M041_P> LicenseEPCG { get; set; }
        public List<ADM_M028_P> ServiceProviders { get; set; }
        public List<SYS_M007_P> DocTypeData { get; set; }
        public List<ACC_M003_O_P> ConditionTypeList { get; set; }
        public List<ADM_M041_P> LicenceList { get; set; }
        public ObservableCollection<ACC_T006_D> LicenceEntity { get; set; }
        public List<ADM_M003_C_P> BussinessPlaceList { get; set; }
        public List<GetItemDetailsEntity> UnitPriceList { get; set; }
        public List<GetItemDetailsEntity> QFRList { get; set; }
        public List<GetItemDetailsEntity> DispatchList { get; set; }
        public List<GetItemDetailsEntity> ProjectedDispList { get; set; }
        public List<ADM_M0013> t_statusList { get; set; }
        public List<ACC_M025_P> withholdinglist { get; set; }
        public List<InvoiceTraceEntity> TraceList { get; set; }
        public List<SYS_M037> Trade_Types { get; set; }

    }
    public class PUR_T005_P_PI_ItemsList
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string CatCode { get; set; }
        public string SubCatCode { get; set; }
        public string unit_code { get; set; }
        public Nullable<bool> StockUnt { get; set; }
        public string cstmr_itemcode { get; set; }
        public string cstmr_itemdescr { get; set; }
        public Nullable<decimal> rate { get; set; }
        public string sku { get; set; }
        public string tax_id { get; set; }
        public string Catlog_UOM { get; set; }
        public string sku_desc { get; set; }
        public string item_cat_id { get; set; }
        public Nullable<decimal> Rate_Suggested { get; set; }
        public Nullable<decimal> Rate_Catlog { get; set; }
        public string gross_wt { get; set; }
        public string net_wt { get; set; }
        public Nullable<decimal> qty { get; set; }
        public Nullable<decimal> sub_total { get; set; }
        public Nullable<decimal> discount { get; set; }
        public string volume { get; set; }
        public string weight_unit { get; set; }
        public string vol_unit { get; set; }
        public Nullable<decimal> MinQty { get; set; }
        public Nullable<decimal> MaxQty { get; set; }
        public Nullable<decimal> Reorder { get; set; }
        public Nullable<decimal> stock_total { get; set; }
        public Nullable<decimal> stock_reserve { get; set; }
        public Nullable<decimal> stock_unr { get; set; }
        public Nullable<decimal> stock_in_transit { get; set; }
        public string Ref_doc_no { get; set; }
        public string po_no { get; set; }
    }
    public class PUR_T005_P_RefDoc : ObjectBase //Purchase Invoice Reference Documents as per Party
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
        public string Ref_DocNo { get; set; }
        public DateTime Ref_date { get; set; }
        public string doc_cat { get; set; }
        public string Ref_DocType { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string t_status { get; set; }
        public string t_display { get; set; }
        public string po_code { get; set; }
        public string curr_code { get; set; }
        public int del_address { get; set; }
        public string p_term_code { get; set; }
        public string incoterms { get; set; }
        public int bill_address_id { get; set; }
        public string country_code { get; set; }
        public string country_nm_s { get; set; }
        public DateTime issue_date { get; set; }
        public string color_code { get; set; }
    }


    // New STD Multicontext Class
    public class MC_PUR_T005 : MC_FICO_BE
    {
        public List<PUR_T005> MasterEntity { get; set; }
        public ObservableCollection<PUR_T005_A> ItemsEntity { get; set; }
        public ObservableCollection<ACC_T006_C> TaxEntity { get; set; }
        public ObservableCollection<ACC_T006_D> LicenceEntity { get; set; }
    }

}