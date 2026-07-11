using Reflection.BusinessEntity.ADM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Finance
{
    public class ACC_T001 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private string _doc_no;
        public string doc_no
        {
            get
            { return _doc_no; }
            set
            { _doc_no = value; RaisePropertyChanged("doc_no", ModelEntityUpdated); }
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
                _doc_cat = value; RaisePropertyChanged("doc_cat", ModelEntityUpdated);
            }
        }
        
        private string _comp_code;
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
        private string _fin_year;
        public string fin_year
        {
            get
            {
                return _fin_year;
            }

            set
            {
                _fin_year = value; RaisePropertyChanged("fin_year", ModelEntityUpdated);
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
                _posting_period = value; RaisePropertyChanged("posting_period", ModelEntityUpdated);
            }
        }
        private string _doc_type;
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
        private Nullable<System.DateTime> _doc_date;
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
        private Nullable<System.DateTime> _posting_date;
        public DateTime? posting_date
        {
            get
            {
                return _posting_date;
            }

            set
            {
                _posting_date = value; RaisePropertyChanged("posting_date", ModelEntityUpdated);
            }
        }
        private string _entry_time;
        public string entry_time
        {
            get
            {
                return _entry_time;
            }

            set
            {
                _entry_time = value; RaisePropertyChanged("entry_time", ModelEntityUpdated);
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
        private string _PartyNm;
        public string PartyNm
        {
            get
            {
                return _PartyNm;
            }

            set
            {
                _PartyNm = value; RaisePropertyChanged("PartyNm", ModelEntityUpdated);
            }
        }
        private string _pay_method;
        public string pay_method
        {
            get
            {
                return _pay_method;
            }

            set
            {
                _pay_method = value; RaisePropertyChanged("pay_method", ModelEntityUpdated);
            }
        }
        private string _check_no;
        public string check_no
        {
            get
            {
                return _check_no;
            }

            set
            {
                _check_no = value; RaisePropertyChanged("check_no", ModelEntityUpdated);
            }
        }
        private Nullable<System.DateTime> _check_date;
        public DateTime? check_date
        {
            get
            {
                return _check_date;
            }

            set
            {
                _check_date = value; RaisePropertyChanged("check_date", ModelEntityUpdated);
            }
        }
        private string _bank_party;
        public string bank_party
        {
            get
            {
                return _bank_party;
            }

            set
            {
                _bank_party = value; RaisePropertyChanged("bank_party", ModelEntityUpdated);
            }
        }
        private string _bank_branch;
        public string bank_branch
        {
            get
            {
                return _bank_branch;
            }

            set
            {
                _bank_branch = value; RaisePropertyChanged("bank_branch", ModelEntityUpdated);
            }
        }
        private string _bank_acc_no;
        public string bank_acc_no
        {
            get
            {
                return _bank_acc_no;
            }

            set
            {
                _bank_acc_no = value; RaisePropertyChanged(" bank_acc_no", ModelEntityUpdated);
            }
        }
        private string _ifsc_code;
        public string ifsc_code
        {
            get
            {
                return _ifsc_code;
            }

            set
            {
                _ifsc_code = value; RaisePropertyChanged("ifsc_code", ModelEntityUpdated);
            }
        }
        private string _swift_code;
        public string swift_code
        {
            get
            {
                return _swift_code;
            }

            set
            {
                _swift_code = value; RaisePropertyChanged("swift_code", ModelEntityUpdated);
            }
        }
        private string _bank_acc_name;
        public string bank_acc_name
        {
            get
            {
                return _bank_acc_name;
            }

            set
            {
                _bank_acc_name = value; RaisePropertyChanged("bank_acc_name", ModelEntityUpdated);
            }
        }
        private string _iban_no;
        public string iban_no
        {
            get
            {
                return _iban_no;
            }

            set
            {
                _iban_no = value; RaisePropertyChanged("iban_no", ModelEntityUpdated);
            }
        }
        private string _hb_code;
        public string hb_code
        {
            get
            {
                return _hb_code;
            }

            set
            {
                _hb_code = value; RaisePropertyChanged("hb_code", ModelEntityUpdated);
            }
        }
        private string _hb_acc;
        public string hb_acc
        {
            get
            {
                return _hb_acc;
            }

            set
            {
                _hb_acc = value; RaisePropertyChanged("hb_acc", ModelEntityUpdated);
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
                _gl_code = value; RaisePropertyChanged("gl_code", ModelEntityUpdated);
            }
        }
        private string _replace_check_no;
        public string replace_check_no
        {
            get
            {
                return _replace_check_no;
            }

            set
            {
                _replace_check_no = value; RaisePropertyChanged("replace_check_no", ModelEntityUpdated);
            }
        }
        private string _replace_check_bank;
        public string replace_check_bank
        {
            get
            {
                return _replace_check_bank;
            }

            set
            {
                _replace_check_bank = value; RaisePropertyChanged("replace_check_bank", ModelEntityUpdated);
            }
        }
        private string _replace_check_acc;
        public string replace_check_acc
        {
            get
            {
                return _replace_check_acc;
            }

            set
            {
                _replace_check_acc = value; RaisePropertyChanged(" replace_check_acc", ModelEntityUpdated);
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
        private string _header_text;
        public string header_text
        {
            get
            {
                return _header_text;
            }

            set
            {
                _header_text = value; RaisePropertyChanged("header_text", ModelEntityUpdated);
            }
        }
        private string _curr_code;
        public string curr_code
        {
            get
            {
                return _curr_code;
            }

            set
            {
                _curr_code = value; RaisePropertyChanged("curr_code", ModelEntityUpdated);
            }
        }
        private decimal _exch_rate;
        public decimal exch_rate
        {
            get
            {
                return _exch_rate;
            }

            set
            {
                _exch_rate = value; RaisePropertyChanged("exch_rate", ModelEntityUpdated);
            }
        }
        private string _local_currency;
        public string local_currency
        {
            get
            {
                return _local_currency;
            }

            set
            {
                _local_currency = value; RaisePropertyChanged("local_currency", ModelEntityUpdated);
            }
        }
        private string _exch_rate_type;
        public string exch_rate_type
        {
            get
            {
                return _exch_rate_type;
            }

            set
            {
                _exch_rate_type = value; RaisePropertyChanged("exch_rate_type", ModelEntityUpdated);
            }
        }
        private string _ledger_gen;
        public string ledger_gen
        {
            get
            {
                return _ledger_gen;
            }

            set
            {
                _ledger_gen = value; RaisePropertyChanged("ledger_gen", ModelEntityUpdated);
            }
        }
        private string _ledger_group;
        public string ledger_group
        {
            get { return _ledger_group; }
            set { _ledger_group = value; RaisePropertyChanged("ledger_group", ModelEntityUpdated); }
        }
        private string _reason;
        public string reason
        {
            get
            {
                return _reason;
            }

            set
            {
                _reason = value; RaisePropertyChanged("reason", ModelEntityUpdated);
            }
        }
        private string _note;
        public string note
        {
            get
            {
                return _note;
            }

            set
            {
                _note = value; RaisePropertyChanged("note", ModelEntityUpdated);
            }
        }
        private string _location_Id;
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
        private Nullable<bool> _active;
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
        private System.DateTime _add_date;
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
        private string _t_status;
        public string t_status
        {
            get
            {
                return _t_status;
            }

            set
            {
                _t_status = value; RaisePropertyChanged("t_status", ModelEntityUpdated);
            }
        }
        private string _pan_no;
        public string pan_no
        {
            get
            {
                return _pan_no;
            }

            set
            {
                _pan_no = value; RaisePropertyChanged("pan_no", ModelEntityUpdated);
            }
        }
        private Nullable<decimal> _amount;
        public Nullable<decimal> amount
        {
            get
            {
                return _amount;
            }

            set
            {
                _amount = value; RaisePropertyChanged("amount", ModelEntityUpdated);
            }
        }
        private string _amt_word;
        public string amt_word
        {
            get
            {
                return _amt_word;
            }

            set
            {
                _amt_word = value; RaisePropertyChanged("amt_word", ModelEntityUpdated);
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
                _EmpId = value; RaisePropertyChanged("EmpId", ModelEntityUpdated);
            }
        }
        public decimal? _local_amount;
        public decimal? local_amount
        {
            get
            {
                return _local_amount;
            }

            set
            {
                _local_amount = value; RaisePropertyChanged("local_amount", ModelEntityUpdated);
            }
        }
        private decimal? _tot_inv_amt;
        public decimal? tot_inv_amt
        {
            get
            {
                return _tot_inv_amt;
            }

            set
            {
                _tot_inv_amt = value; RaisePropertyChanged("tot_inv_amt", ModelEntityUpdated);
            }
        }
        private Nullable<decimal> _tot_fluc_amt;
        public decimal? tot_fluc_amt
        {
            get
            {
                return _tot_fluc_amt;
            }

            set
            {
                _tot_fluc_amt = value; RaisePropertyChanged("tot_fluc_amt", ModelEntityUpdated);
            }
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
        public System.DateTime? _chq_encash_dt;
        public DateTime? chq_encash_dt
        {
            get
            {
                return _chq_encash_dt;
            }

            set
            {
                _chq_encash_dt = value; RaisePropertyChanged("chq_encash_dt", ModelEntityUpdated);
            }
        }
        private decimal? _chk_void_code;
        public decimal? chk_void_code
        {
            get
            {
                return _chk_void_code;
            }

            set
            {
                _chk_void_code = value; RaisePropertyChanged("chk_void_code", ModelEntityUpdated);
            }
        }
        public System.DateTime? _voided_chk_dt;
        public DateTime? voided_chk_dt
        {
            get
            {
                return _voided_chk_dt;
            }

            set
            {
                _voided_chk_dt = value; RaisePropertyChanged("voided_chk_dt", ModelEntityUpdated);
            }
        }
        private string _voided_chk_user;
        public string voided_chk_user
        {
            get
            {
                return _voided_chk_user;
            }

            set
            {
                _voided_chk_user = value; RaisePropertyChanged("voided_chk_user", ModelEntityUpdated);
            }
        }
        private string _ind_rev_clrng;
        public string ind_rev_clrng
        {
            get
            {
                return _ind_rev_clrng;
            }

            set
            {
                _ind_rev_clrng = value; RaisePropertyChanged("ind_rev_clrng", ModelEntityUpdated);
            }
        }
        private decimal? _cash_dscnt_lc;
        public decimal? cash_dscnt_lc
        {
            get
            {
                return _cash_dscnt_lc;
            }

            set
            {
                _cash_dscnt_lc = value; RaisePropertyChanged("cash_dscnt_lc", ModelEntityUpdated);
            }
        }
        private decimal? _amt_paid_lc;
        public decimal? amt_paid_lc
        {
            get
            {
                return _amt_paid_lc;
            }

            set
            {
                _amt_paid_lc = value; RaisePropertyChanged("amt_paid_lc", ModelEntityUpdated);
            }
        }
        private string _address;
        public string address
        {
            get
            {
                return _address;
            }

            set
            {
                _address = value; RaisePropertyChanged("address", ModelEntityUpdated);
            }
        }
        private decimal? _bank_charges;
        public decimal? bank_charges
        {
            get
            {
                return _bank_charges;
            }

            set
            {
                _bank_charges = value; RaisePropertyChanged("bank_charges", ModelEntityUpdated);
            }
        }
        private decimal? _local_bank_charges;
        public decimal? local_bank_charges
        {
            get
            {
                return _local_bank_charges;
            }

            set
            {
                _local_bank_charges = value; RaisePropertyChanged("local_bank_charges", ModelEntityUpdated);
            }
        }
        private string _profit_center;
        public string profit_center
        {
            get
            {
                return _profit_center;
            }

            set
            {
                _profit_center = value; RaisePropertyChanged("profit_center", ModelEntityUpdated);
            }
        }
        private DateTime? _bank_date;
        public DateTime? bank_date
        {
            get
            {
                return _bank_date;
            }

            set
            {
                _bank_date = value; RaisePropertyChanged("bank_date", ModelEntityUpdated);
            }
        }
        private string _pay_req_no;
        public string pay_req_no
        {
            get
            {
                return _pay_req_no;
            }

            set
            {
                _pay_req_no = value; RaisePropertyChanged("pay_req_no", ModelEntityUpdated);
            }
        }
        private string _reason_code;
        public string reason_code
        {
            get
            {
                return _reason_code;
            }

            set
            {
                _reason_code = value; RaisePropertyChanged("reason_code", ModelEntityUpdated);
            }
        }
        private decimal? _total_wtax_amt;
        public decimal? total_wtax_amt
        {
            get
            {
                return _total_wtax_amt;
            }

            set
            {
                _total_wtax_amt = value; RaisePropertyChanged("total_wtax_amt", ModelEntityUpdated);
            }
        }
        private decimal? _total_cash_disc_amt;
        public decimal? total_cash_disc_amt
        {
            get
            {
                return _total_cash_disc_amt;
            }

            set
            {
                _total_cash_disc_amt = value; RaisePropertyChanged("total_cash_disc_amt", ModelEntityUpdated);
            }
        }
        private decimal? _total_amt_paid;
        public decimal? total_amt_paid
        {
            get
            {
                return _total_amt_paid;
            }

            set
            {
                _total_amt_paid = value; RaisePropertyChanged("total_amt_paid", ModelEntityUpdated);
            }
        }
        private string _sp_gl_code;
        public string sp_gl_code
        {
            get
            {
                return _sp_gl_code;
            }

            set
            {
                _sp_gl_code = value; RaisePropertyChanged("sp_gl_code");
            }
        }
        private string _bank_gl_code;
        public string bank_gl_code
        {
            get
            {
                return _bank_gl_code;
            }

            set
            {
                _bank_gl_code = value; RaisePropertyChanged("bank_gl_code");
            }
        }
        private string _order_no;
        public string order_no
        {
            get
            {
                return _order_no;
            }

            set
            {
                _order_no = value; RaisePropertyChanged("order_no", ModelEntityUpdated);
            }
        }
        private string _ind_spl_gl;
        public string ind_spl_gl
        {
            get
            {
                return _ind_spl_gl;
            }

            set
            {
                if (_ind_spl_gl != value)
                {
                    _ind_spl_gl = value;
                    RaisePropertyChanged("ind_spl_gl", ModelEntityUpdated);

                    //if(string.IsNullOrWhiteSpace((value ?? "").Trim()))
                    //{
                    //    _ind_spl_gl = value;
                    //}
                    //else
                    //{
                    //    _ind_spl_gl = value;
                    //    RaisePropertyChanged("ind_spl_gl", ModelEntityUpdated);
                    //}
                }
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
                _para1 = value; RaisePropertyChanged("para1", ModelEntityUpdated);
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
                _para2 = value; RaisePropertyChanged("para2", ModelEntityUpdated);
            }
        }

        //Scalar
        
        public string _compName;
        public string compName
        {
            get
            {
                return _compName;
            }

            set
            {
                _compName = value; RaisePropertyChanged("compName", ModelEntityUpdated);
            }
        }
        public string _gl_name;
        public string gl_name
        {
            get
            {
                return _gl_name;
            }

            set
            {
                _gl_name = value; RaisePropertyChanged("gl_name", ModelEntityUpdated);
            }
        }
        public string _EmpName;
        public string EmpName
        {
            get
            {
                return _EmpName;
            }

            set
            {
                _EmpName = value; RaisePropertyChanged("EmpName", ModelEntityUpdated);
            }
        }
        private string _sp_gl_name;
        public string sp_gl_name
        {
            get
            {
                return _sp_gl_name;
            }

            set
            {
                _sp_gl_name = value; RaisePropertyChanged("sp_gl_name");
            }
        }
        private string _bank_gl_name;
        public string bank_gl_name
        {
            get
            {
                return _bank_gl_name;
            }

            set
            {
                _bank_gl_name = value; RaisePropertyChanged("bank_gl_name");
            }
        }
        private string _reason_desc;
        public string reason_desc
        {
            get
            {
                return _reason_desc;
            }

            set
            {
                _reason_desc = value; RaisePropertyChanged("reason_desc");
            }
        }
        private string _profit_center_Desc;
        public string profit_center_Desc
        {
            get
            {
                return _profit_center_Desc;
            }

            set
            {
                _profit_center_Desc = value; RaisePropertyChanged("profit_center_Desc");
            }
        }
        private string _party_bank_name;
        public string party_bank_name
        {
            get
            {
                return _party_bank_name;
            }

            set
            {
                _party_bank_name = value; RaisePropertyChanged("party_bank_name");
            }
        }
        private string _our_hb_name;
        public string our_hb_name
        {
            get
            {
                return _our_hb_name;
            }

            set
            {
                _our_hb_name = value; RaisePropertyChanged("our_hb_name");
            }
        }
        private int? _address_id;
        public int? address_id
        {
            get
            {
                return _address_id;
            }

            set
            {
                _address_id = value; RaisePropertyChanged("address_id");
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
        private decimal? _received_amt;
        public decimal? received_amt
        {
            get { return _received_amt; }
            set
            {
                if (_received_amt != value)
                {
                    _received_amt = value; RaisePropertyChanged("received_amt", ModelEntityUpdated);
                }
            }
        }
        private decimal? _change_amt;
        public decimal? change_amt
        {
            get { return _change_amt; }
            set
            {
                if (_change_amt != value)
                {
                    _change_amt = value; RaisePropertyChanged("change_amt");
                }
            }
        }

        // for Open Items not added in WebService side
        private decimal? _total_amt_paid_ex;
        public decimal? total_amt_paid_ex
        {
            get
            {
                return _total_amt_paid_ex;
            }

            set
            {
                _total_amt_paid_ex = value; RaisePropertyChanged("total_amt_paid_ex", ModelEntityUpdated);
            }
        }
        private decimal? _balance_amt;
        public decimal? balance_amt
        {
            get
            {
                return _balance_amt;
            }

            set
            {
                _balance_amt = value; RaisePropertyChanged("balance_amt");
            }
        }
        private decimal? _adv_amt;
        public decimal? adv_amt
        {
            get
            {
                return _adv_amt;
            }

            set
            {
                _adv_amt = value; RaisePropertyChanged("adv_amt");
            }
        }
        private decimal? _advclr_amt;
        public decimal? advclr_amt
        {
            get
            {
                return _advclr_amt;
            }

            set
            {
                _advclr_amt = value; RaisePropertyChanged("advclr_amt");
            }
        }
        public string XmlDataDocument_FlipGrid;
        public string XmlDataDocument_ACC_T001_A;
        public string XmlDataDocument_ACC_T001_B;
        public string XmlDataDocument_ACC_T001_C;

        // Depricated
        public string _bank_no_payee;
        public string bank_no_payee
        {
            get
            {
                return _bank_no_payee;
            }

            set
            {
                _bank_no_payee = value; RaisePropertyChanged("bank_no_payee", ModelEntityUpdated);
            }
        }
        public string _PayeeBankName;
        public string PayeeBankName
        {
            get
            {
                return _PayeeBankName;
            }

            set
            {
                _PayeeBankName = value; RaisePropertyChanged("PayeeBankName", ModelEntityUpdated);
            }
        }
        public string _GlName;
        public string GlName
        {
            get
            {
                return _GlName;
            }

            set
            {
                _GlName = value; RaisePropertyChanged("GlName", ModelEntityUpdated);
            }
        }
        public string _bank_name_payer;
        public string bank_name_payer
        {
            get
            {
                return _bank_name_payer;
            }

            set
            {
                _bank_name_payer = value; RaisePropertyChanged("bank_name_payer", ModelEntityUpdated);
            }
        }
        public string _branch_payer;
        public string branch_payer
        {
            get
            {
                return _branch_payer;
            }

            set
            {
                _branch_payer = value; RaisePropertyChanged("branch_payer", ModelEntityUpdated);
            }
        }
        public string pay_method_desc { get; set; }

    }
    public class ACC_T001_A : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        public int id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value; RaisePropertyChanged("id");
            }
        }
        
        private string _comp_code;
        public string comp_code
        {
            get
            {
                return _comp_code;
            }

            set
            {
                _comp_code = value; RaisePropertyChanged("comp_code");
            }
        }
        private string _location_Id;
        public string location_Id
        {
            get
            {
                return _location_Id;
            }

            set
            {
                _location_Id = value; RaisePropertyChanged("location_Id");
            }
        }
        private string _doc_no;
        public string doc_no
        {
            get
            {
                return _doc_no;
            }

            set
            {
                _doc_no = value; RaisePropertyChanged("doc_no");
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
        private int? _line_no_acc_doc;
        public int? line_no_acc_doc
        {
            get
            {
                return _line_no_acc_doc;
            }

            set
            {
                _line_no_acc_doc = value; RaisePropertyChanged("line_no_acc_doc");
            }
        }
        private string _posting_key;
        public string posting_key
        {
            get
            {
                return _posting_key;
            }

            set
            {
                _posting_key = value; RaisePropertyChanged("posting_key");
            }
        }
        private string _acc_type;
        public string acc_type
        {
            get
            {
                return _acc_type;
            }

            set
            {
                _acc_type = value; RaisePropertyChanged("acc_type");
            }
        }
        private string _ind_gl;
        public string ind_gl
        {
            get
            {
                return _ind_gl;
            }

            set
            {
                _ind_gl = value; RaisePropertyChanged("ind_gl");
            }
        }
        private string _sp_gltype;
        public string sp_gltype
        {
            get
            {
                return _sp_gltype;
            }

            set
            {
                _sp_gltype = value; RaisePropertyChanged("sp_gltype");
            }
        }
        private string _ind_target_gl;
        public string ind_target_gl
        {
            get
            {
                return _ind_target_gl;
            }

            set
            {
                _ind_target_gl = value; RaisePropertyChanged("ind_target_gl");
            }
        }
        private string _ind_debitcredit;
        public string ind_debitcredit
        {
            get
            {
                return _ind_debitcredit;
            }

            set
            {
                _ind_debitcredit = value; RaisePropertyChanged("ind_debitcredit");
            }
        }
        private string _buss_area;
        public string buss_area
        {
            get
            {
                return _buss_area;
            }

            set
            {
                _buss_area = value; RaisePropertyChanged("buss_area");
            }
        }
        private string _tax_code_w;
        public string tax_code_w
        {
            get
            {
                return _tax_code_w;
            }

            set
            {
                _tax_code_w = value; RaisePropertyChanged("tax_code_w");
            }
        }
        private decimal? _amount_loc_curr;
        public decimal? amount_loc_curr
        {
            get
            {
                return _amount_loc_curr;
            }

            set
            {
                _amount_loc_curr = value; RaisePropertyChanged("amount_loc_curr");
            }
        }
        private decimal? _amount_doc_curr;
        public decimal? amount_doc_curr
        {
            get
            {
                return _amount_doc_curr;
            }

            set
            {
                _amount_doc_curr = value; RaisePropertyChanged("amount_doc_curr", ModelEntityUpdated);
            }
        }
        private decimal? _amount_ledger;
        public decimal? amount_ledger
        {
            get
            {
                return _amount_ledger;
            }

            set
            {
                _amount_ledger = value; RaisePropertyChanged("amount_ledger");
            }
        }
        private decimal? _amt_loc_taxbase;
        public decimal? amt_loc_taxbase
        {
            get
            {
                return _amt_loc_taxbase;
            }

            set
            {
                _amt_loc_taxbase = value; RaisePropertyChanged("amt_loc_taxbase");
            }
        }
        private decimal? _amt_doc_taxbase;
        public decimal? amt_doc_taxbase
        {
            get
            {
                return _amt_doc_taxbase;
            }

            set
            {
                _amt_doc_taxbase = value; RaisePropertyChanged("amt_doc_taxbase");
            }
        }
        private decimal? _amt_tax_local_curr;
        public decimal? amt_tax_local_curr
        {
            get
            {
                return _amt_tax_local_curr;
            }

            set
            {
                _amt_tax_local_curr = value; RaisePropertyChanged("amt_tax_local_curr");
            }
        }
        private decimal? _amt_tax_doc_curr;
        public decimal? amt_tax_doc_curr
        {
            get
            {
                return _amt_tax_doc_curr;
            }

            set
            {
                _amt_tax_doc_curr = value; RaisePropertyChanged("amt_tax_doc_curr");
            }
        }
        private decimal? _amt_withhold_tax;
        public decimal? amt_withhold_tax
        {
            get
            {
                return _amt_withhold_tax;
            }

            set
            {
                _amt_withhold_tax = value; RaisePropertyChanged("amt_withhold_tax", ModelEntityUpdated);
            }
        }
        private decimal? _value_diff;
        public decimal? value_diff
        {
            get
            {
                return _value_diff;
            }

            set
            {
                _value_diff = value; RaisePropertyChanged("value_diff");
            }
        }
        private decimal? _value_diff_sec_curr;
        public decimal? value_diff_sec_curr
        {
            get
            {
                return _value_diff_sec_curr;
            }

            set
            {
                _value_diff_sec_curr = value; RaisePropertyChanged("value_diff_sec_curr");
            }
        }
        private string _assign_no;
        public string assign_no
        {
            get
            {
                return _assign_no;
            }

            set
            {
                _assign_no = value; RaisePropertyChanged("assign_no");
            }
        }
        private string _item_text;
        public string item_text
        {
            get
            {
                return _item_text;
            }

            set
            {
                _item_text = value; RaisePropertyChanged("item_text");
            }
        }
        private string _description;
        public string description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value; RaisePropertyChanged("description");
            }
        }
        private string _trns_type;
        public string trns_type
        {
            get
            {
                return _trns_type;
            }

            set
            {
                _trns_type = value; RaisePropertyChanged("trns_type");
            }
        }
        private string _gl_trns_type;
        public string gl_trns_type
        {
            get
            {
                return _gl_trns_type;
            }

            set
            {
                _gl_trns_type = value; RaisePropertyChanged("gl_trns_type");
            }
        }
        private string _control_area;
        public string control_area
        {
            get
            {
                return _control_area;
            }

            set
            {
                _control_area = value; RaisePropertyChanged("control_area");
            }
        }
        private string _cost_center;
        public string cost_center
        {
            get
            {
                return _cost_center;
            }

            set
            {
                _cost_center = value; RaisePropertyChanged("cost_center");
            }
        }
        private string _order_no;
        public string order_no
        {
            get
            {
                return _order_no;
            }

            set
            {
                _order_no = value; RaisePropertyChanged("order_no");
            }
        }
        private string _bill_doc;
        public string bill_doc
        {
            get
            {
                return _bill_doc;
            }

            set
            {
                _bill_doc = value; RaisePropertyChanged("bill_doc");
            }
        }
        private string _sales_doc;
        public string sales_doc
        {
            get
            {
                return _sales_doc;
            }

            set
            {
                _sales_doc = value; RaisePropertyChanged("sales_doc");
            }
        }
        private int? _sd_item_row_id;
        public int? sd_item_row_id
        {
            get
            {
                return _sd_item_row_id;
            }

            set
            {
                _sd_item_row_id = value; RaisePropertyChanged("sd_item_row_id");
            }
        }
        private int? _bill_doc_item_row_id;
        public int? bill_doc_item_row_id
        {
            get
            {
                return _bill_doc_item_row_id;
            }

            set
            {
                _bill_doc_item_row_id = value; RaisePropertyChanged("bill_doc_item_row_id");
            }
        }
        private int? _sch_item_row_id;
        public int? sch_item_row_id
        {
            get
            {
                return _sch_item_row_id;
            }

            set
            {
                _sch_item_row_id = value; RaisePropertyChanged("sch_item_row_id");
            }
        }
        private int? _dn_item_row_id;
        public int? dn_item_row_id
        {
            get
            {
                return _dn_item_row_id;
            }

            set
            {
                _dn_item_row_id = value; RaisePropertyChanged("dn_item_row_id");
            }
        }
        private string _main_asset_no;
        public string main_asset_no
        {
            get
            {
                return _main_asset_no;
            }

            set
            {
                _main_asset_no = value; RaisePropertyChanged("main_asset_no");
            }
        }
        private string _asse_subno;
        public string asse_subno
        {
            get
            {
                return _asse_subno;
            }

            set
            {
                _asse_subno = value; RaisePropertyChanged("asse_subno");
            }
        }
        private string _ind_open_item;
        public string ind_open_item
        {
            get
            {
                return _ind_open_item;
            }

            set
            {
                _ind_open_item = value; RaisePropertyChanged("ind_open_item");
            }
        }
        private string _ind_down_pay;
        public string ind_down_pay
        {
            get
            {
                return _ind_down_pay;
            }

            set
            {
                _ind_down_pay = value; RaisePropertyChanged("ind_down_pay");
            }
        }
        private string _ind_post_key;
        public string ind_post_key
        {
            get
            {
                return _ind_post_key;
            }

            set
            {
                _ind_post_key = value; RaisePropertyChanged("ind_post_key");
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
        private string _ledger_gen;
        public string ledger_gen
        {
            get { return _ledger_gen; }
            set
            {
                _ledger_gen = value;
                RaisePropertyChanged("ledger_gen");
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
                _PartyId = value; RaisePropertyChanged("PartyId");
            }
        }
        private string _PartyNm;
        public string PartyNm
        {
            get
            {
                return _PartyNm;
            }

            set
            {
                _PartyNm = value; RaisePropertyChanged("PartyNm");
            }
        }
        private string _payterm_key;
        public string payterm_key
        {
            get
            {
                return _payterm_key;
            }

            set
            {
                _payterm_key = value; RaisePropertyChanged("payterm_key");
            }
        }
        private decimal? _cash_disc1;
        public decimal? cash_disc1
        {
            get
            {
                return _cash_disc1;
            }

            set
            {
                _cash_disc1 = value; RaisePropertyChanged("cash_disc1", ModelEntityUpdated);
            }
        }
        private decimal? _payterm_period;
        public decimal? payterm_period
        {
            get
            {
                return _payterm_period;
            }

            set
            {
                _payterm_period = value; RaisePropertyChanged("payterm_period");
            }
        }
        private decimal? _disc_per1;
        public decimal? disc_per1
        {
            get
            {
                return _disc_per1;
            }

            set
            {
                _disc_per1 = value; RaisePropertyChanged("disc_per1");
            }
        }
        private decimal? _amt_cd_eligible;
        public decimal? amt_cd_eligible
        {
            get
            {
                return _amt_cd_eligible;
            }

            set
            {
                _amt_cd_eligible = value; RaisePropertyChanged("amt_cd_eligible");
            }
        }
        private decimal? _cd_loc_curr;
        public decimal? cd_loc_curr
        {
            get
            {
                return _cd_loc_curr;
            }

            set
            {
                _cd_loc_curr = value; RaisePropertyChanged("cd_loc_curr");
            }
        }
        private decimal? _cd_doc_curr;
        public decimal? cd_doc_curr
        {
            get
            {
                return _cd_doc_curr;
            }

            set
            {
                _cd_doc_curr = value; RaisePropertyChanged("cd_doc_curr");
            }
        }
        private string _pay_method;
        public string pay_method
        {
            get
            {
                return _pay_method;
            }

            set
            {
                _pay_method = value; RaisePropertyChanged("pay_method");
            }
        }
        private string _pay_block_key;
        public string pay_block_key
        {
            get
            {
                return _pay_block_key;
            }

            set
            {
                _pay_block_key = value; RaisePropertyChanged("pay_block_key");
            }
        }
        private string _hb_code;
        public string hb_code
        {
            get
            {
                return _hb_code;
            }

            set
            {
                _hb_code = value; RaisePropertyChanged("hb_code");
            }
        }
        private string _hb_acc;
        public string hb_acc
        {
            get
            {
                return _hb_acc;
            }

            set
            {
                _hb_acc = value; RaisePropertyChanged("hb_acc", ModelEntityUpdated);
            }
        }
        private decimal? _net_pay_amt;
        public decimal? net_pay_amt
        {
            get
            {
                return _net_pay_amt;
            }

            set
            {
                _net_pay_amt = value; RaisePropertyChanged("net_pay_amt", ModelEntityUpdated);
            }
        }
        private string _ex_bill_no;
        public string ex_bill_no
        {
            get
            {
                return _ex_bill_no;
            }

            set
            {
                _ex_bill_no = value; RaisePropertyChanged("ex_bill_no");
            }
        }
        private DateTime? _ex_bill_duedate;
        public DateTime? ex_bill_duedate
        {
            get
            {
                return _ex_bill_duedate;
            }

            set
            {
                _ex_bill_duedate = value; RaisePropertyChanged("ex_bill_duedate");
            }
        }
        private string _tax_certi;
        public string tax_certi
        {
            get
            {
                return _tax_certi;
            }

            set
            {
                _tax_certi = value; RaisePropertyChanged("tax_certi");
            }
        }
        private decimal? _amt_withtax;
        public decimal? amt_withtax
        {
            get
            {
                return _amt_withtax;
            }

            set
            {
                _amt_withtax = value; RaisePropertyChanged("amt_withtax");
            }
        }
        private decimal? _amt_withtax_ex;
        public decimal? amt_withtax_ex
        {
            get
            {
                return _amt_withtax_ex;
            }

            set
            {
                _amt_withtax_ex = value; RaisePropertyChanged("amt_withtax_ex");
            }
        }
        private decimal? _qty;
        public decimal? qty
        {
            get
            {
                return _qty;
            }

            set
            {
                _qty = value; RaisePropertyChanged("qty");
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
        private string _po_no;
        public string po_no
        {
            get
            {
                return _po_no;
            }

            set
            {
                _po_no = value; RaisePropertyChanged("po_no");
            }
        }
        private int? _po_item_row_id;
        public int? po_item_row_id
        {
            get
            {
                return _po_item_row_id;
            }

            set
            {
                _po_item_row_id = value; RaisePropertyChanged("po_item_row_id");
            }
        }
        private string _reason_code;
        public string reason_code
        {
            get
            {
                return _reason_code;
            }

            set
            {
                _reason_code = value; RaisePropertyChanged("reason_code");
            }
        }
        private string _profit_center;
        public string profit_center
        {
            get
            {
                return _profit_center;
            }

            set
            {
                _profit_center = value; RaisePropertyChanged("profit_center");
            }
        }
        private string _ind_neg_posting;
        public string ind_neg_posting
        {
            get
            {
                return _ind_neg_posting;
            }

            set
            {
                _ind_neg_posting = value; RaisePropertyChanged("ind_neg_posting");
            }
        }
        private string _pay_ref;
        public string pay_ref
        {
            get
            {
                return _pay_ref;
            }

            set
            {
                _pay_ref = value; RaisePropertyChanged("pay_ref", ModelEntityUpdated);
            }
        }
        private string _acc_assign_cat;
        public string acc_assign_cat
        {
            get
            {
                return _acc_assign_cat;
            }

            set
            {
                _acc_assign_cat = value; RaisePropertyChanged("acc_assign_cat");
            }
        }
        private decimal _net_payable_amt;
        public decimal net_payable_amt
        {
            get
            {
                return _net_payable_amt;
            }

            set
            {
                _net_payable_amt = value; RaisePropertyChanged("net_payable_amt");
            }
        }
        private decimal? _loss_real1;
        public decimal? loss_real1
        {
            get
            {
                return _loss_real1;
            }

            set
            {
                _loss_real1 = value; RaisePropertyChanged("loss_real1");
            }
        }
        private decimal? _penalty_loc1;
        public decimal? penalty_loc1
        {
            get
            {
                return _penalty_loc1;
            }

            set
            {
                _penalty_loc1 = value; RaisePropertyChanged("penalty_loc1");
            }
        }
        private int? _days_penalty;
        public int? days_penalty
        {
            get
            {
                return _days_penalty;
            }

            set
            {
                _days_penalty = value; RaisePropertyChanged("days_penalty");
            }
        }
        private string _late_reason;
        public string late_reason
        {
            get
            {
                return _late_reason;
            }

            set
            {
                _late_reason = value; RaisePropertyChanged("late_reason");
            }
        }
        private decimal? _tax_profit;
        public decimal? tax_profit
        {
            get
            {
                return _tax_profit;
            }

            set
            {
                _tax_profit = value; RaisePropertyChanged("tax_profit", ModelEntityUpdated);
            }
        }
        private string _acc_gl_code;
        public string acc_gl_code
        {
            get
            {
                return _acc_gl_code;
            }

            set
            {
                _acc_gl_code = value; RaisePropertyChanged("acc_gl_code");
            }
        }
        private bool? _active;
        public bool? active
        {
            get
            {
                return _active;
            }

            set
            {
                _active = value; RaisePropertyChanged("active");
            }
        }
        private string _userid;
        public string userid
        {
            get
            {
                return _userid;
            }

            set
            {
                _userid = value; RaisePropertyChanged("userid");
            }
        }
        private System.DateTime _add_date;
        public DateTime add_date
        {
            get
            {
                return _add_date;
            }

            set
            {
                _add_date = value; RaisePropertyChanged("add_date");
            }
        }
        private string _t_status;
        public string t_status
        {
            get
            {
                return _t_status;
            }

            set
            {
                _t_status = value; RaisePropertyChanged("t_status");
            }
        }
        private decimal _doc_exch_rate;
        public decimal doc_exch_rate
        {
            get
            {
                return _doc_exch_rate;
            }

            set
            {
                _doc_exch_rate = value; RaisePropertyChanged("doc_exch_rate");
            }
        }
        private decimal? _cur_exch_rate;
        public decimal? cur_exch_rate
        {
            get
            {
                return _cur_exch_rate;
            }

            set
            {
                _cur_exch_rate = value; RaisePropertyChanged("cur_exch_rate", ModelEntityUpdated);
            }
        }
        private DateTime? _posting_dt;
        public DateTime? posting_dt
        {
            get
            {
                return _posting_dt;
            }

            set
            {
                _posting_dt = value; RaisePropertyChanged("posting_dt");
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
                _ref_doc_no = value; RaisePropertyChanged("ref_doc_no");
            }
        }
        private int? _ref_doc_item_row_id;
        public int? ref_doc_item_row_id
        {
            get
            {
                return _ref_doc_item_row_id;
            }

            set
            {
                _ref_doc_item_row_id = value; RaisePropertyChanged("ref_doc_item_row_id");
            }
        }
        private DateTime? _doc_date;
        public DateTime? doc_date
        {
            get
            {
                return _doc_date;
            }

            set
            {
                _doc_date = value; RaisePropertyChanged("doc_date");
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
                _doc_cat = value; RaisePropertyChanged("doc_cat");
            }
        }
        private string _doc_type;
        public string doc_type
        {
            get
            {
                return _doc_type;
            }

            set
            {
                _doc_type = value; RaisePropertyChanged("doc_type");
            }
        }
        private string _tax_code;
        public string tax_code
        {
            get
            {
                return _tax_code;
            }

            set
            {
                _tax_code = value; RaisePropertyChanged("tax_code");
            }
        }
        private decimal? _amt_withhold_taxbase;
        public decimal? amt_withhold_taxbase
        {
            get
            {
                return _amt_withhold_taxbase;
            }

            set
            {
                _amt_withhold_taxbase = value; RaisePropertyChanged("amt_withhold_taxbase");
            }
        }
        private decimal? _amt_withhold_tax_doc;
        public decimal? amt_withhold_tax_doc
        {
            get
            {
                return _amt_withhold_tax_doc;
            }

            set
            {
                _amt_withhold_tax_doc = value; RaisePropertyChanged("amt_withhold_tax_doc");
            }
        }
        private decimal? _amt_withhold_tax_loc;
        public decimal? amt_withhold_tax_loc
        {
            get
            {
                return _amt_withhold_tax_loc;
            }

            set
            {
                _amt_withhold_tax_loc = value; RaisePropertyChanged("amt_withhold_tax_loc");
            }
        }
        private string _wtax_certificate_no;
        public string wtax_certificate_no
        {
            get { return _wtax_certificate_no; }
            set
            {
                if (_wtax_certificate_no != value)
                {
                    _wtax_certificate_no = value; RaisePropertyChanged("wtax_certificate_no");
                }
            }
        }
        private string _curr_code;
        public string curr_code
        {
            get { return _curr_code; }
            set
            {
                _curr_code = value;
                RaisePropertyChanged("curr_code");
            }
        }
        private decimal? _bal_amt;
        public decimal? bal_amt
        {
            get
            {
                return _bal_amt;
            }

            set
            {
                _bal_amt = value; RaisePropertyChanged("bal_amt");
            }
        }
        private decimal? _order_price;
        public decimal? order_price
        {
            get
            {
                return _order_price;
            }

            set
            {
                _order_price = value; RaisePropertyChanged("order_price", ModelEntityUpdated);
            }
        }
        private decimal? _amt_cc;
        public decimal? amt_cc
        {
            get
            {
                return _amt_cc;
            }

            set
            {
                _amt_cc = value; RaisePropertyChanged("amt_cc", ModelEntityUpdated);
            }
        }
        private string _accounting_doc_no;
        public string accounting_doc_no
        {
            get { return _accounting_doc_no; }
            set
            {
                if (_accounting_doc_no != value)
                {
                    _accounting_doc_no = value; RaisePropertyChanged("accounting_doc_no");
                }
            }
        }
        private int? _open_item_row_id;
        public int? open_item_row_id
        {
            get
            {
                return _open_item_row_id;
            }

            set
            {
                _open_item_row_id = value; RaisePropertyChanged("open_item_row_id");
            }
        }
        private decimal? _ex_rate_diff;
        public decimal? ex_rate_diff
        {
            get
            {
                return _ex_rate_diff;
            }

            set
            {
                _ex_rate_diff = value; RaisePropertyChanged("ex_rate_diff", ModelEntityUpdated);
            }
        }


        //Scalers
        private string _GlName;
        public string GlName
        {
            get
            {
                return _GlName;
            }

            set
            {
                _GlName = value; RaisePropertyChanged("GlName");
            }
        }
        private string _gl_name;
        public string gl_name
        {
            get
            {
                return _gl_name;
            }

            set
            {
                _gl_name = value; RaisePropertyChanged("gl_name");
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
        private bool _Select;
        public bool Select
        {
            get { return _Select; }
            set
            {
                _Select = value;
                RaisePropertyChanged("Select", ModelEntityUpdated);
            }
        }
        public string _AssignColor;
        public string AssignColor
        {
            get { return _AssignColor; }
            set
            {
                if (_AssignColor != value)
                {
                    _AssignColor = value; RaisePropertyChanged("AssignColor");
                }
            }
        }

        // NOTE: Depricated
        private decimal? _TotalInvoiceAmt;
        public decimal? TotalInvoiceAmt
        {
            get
            {
                return _TotalInvoiceAmt;
            }

            set
            {
                _TotalInvoiceAmt = value; RaisePropertyChanged("TotalInvoiceAmt");
            }
        }
        private decimal? _TotalBillingAmt;
        public decimal? TotalBillingAmt
        {
            get
            {
                return _TotalBillingAmt;
            }

            set
            {
                _TotalBillingAmt = value; RaisePropertyChanged("TotalBillingAmt");
            }
        }
        private decimal? _exch_rate;
        public decimal? exch_rate
        {
            get
            {
                return _exch_rate;
            }

            set
            {
                _exch_rate = value; RaisePropertyChanged("exch_rate", ModelEntityUpdated);
            }
        }
        private decimal? _advance_amount;
        public decimal? advance_amount
        {
            get
            {
                return _advance_amount;
            }

            set
            {
                _advance_amount = value; RaisePropertyChanged("advance_amount");
            }
        }

    }
    public class ACC_T001_B : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        public int id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value; RaisePropertyChanged("id");
            }
        }
        
        private string _comp_code;
        public string comp_code
        {
            get
            {
                return _comp_code;
            }

            set
            {
                _comp_code = value; RaisePropertyChanged("comp_code");
            }
        }
        private string _location_Id;
        public string location_Id
        {
            get
            {
                return _location_Id;
            }

            set
            {
                _location_Id = value; RaisePropertyChanged("location_Id");
            }
        }
        private string _doc_no;
        public string doc_no
        {
            get
            {
                return _doc_no;
            }

            set
            {
                _doc_no = value; RaisePropertyChanged("doc_no");
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
        private int? _line_no_acc_doc;
        public int? line_no_acc_doc
        {
            get
            {
                return _line_no_acc_doc;
            }

            set
            {
                _line_no_acc_doc = value; RaisePropertyChanged("line_no_acc_doc");
            }
        }
        private string _posting_key;
        public string posting_key
        {
            get
            {
                return _posting_key;
            }

            set
            {
                _posting_key = value; RaisePropertyChanged("posting_key");
            }
        }
        private string _acc_type;
        public string acc_type
        {
            get
            {
                return _acc_type;
            }

            set
            {
                _acc_type = value; RaisePropertyChanged("acc_type");
            }
        }
        private string _ind_gl;
        public string ind_gl
        {
            get
            {
                return _ind_gl;
            }

            set
            {
                _ind_gl = value; RaisePropertyChanged("ind_gl");
            }
        }
        private string _sp_gltype;
        public string sp_gltype
        {
            get
            {
                return _sp_gltype;
            }

            set
            {
                _sp_gltype = value; RaisePropertyChanged("sp_gltype");
            }
        }
        private string _ind_target_gl;
        public string ind_target_gl
        {
            get
            {
                return _ind_target_gl;
            }

            set
            {
                _ind_target_gl = value; RaisePropertyChanged("ind_target_gl");
            }
        }
        private string _ind_debitcredit;
        public string ind_debitcredit
        {
            get
            {
                return _ind_debitcredit;
            }

            set
            {
                _ind_debitcredit = value; RaisePropertyChanged("ind_debitcredit");
            }
        }
        private string _buss_area;
        public string buss_area
        {
            get
            {
                return _buss_area;
            }

            set
            {
                _buss_area = value; RaisePropertyChanged("buss_area");
            }
        }
        private string _tax_code_w;
        public string tax_code_w
        {
            get
            {
                return _tax_code_w;
            }

            set
            {
                _tax_code_w = value; RaisePropertyChanged("tax_code_w");
            }
        }
        private decimal? _amount_loc_curr;
        public decimal? amount_loc_curr
        {
            get
            {
                return _amount_loc_curr;
            }

            set
            {
                _amount_loc_curr = value; RaisePropertyChanged("amount_loc_curr");
            }
        }
        private decimal? _amount_doc_curr;
        public decimal? amount_doc_curr
        {
            get
            {
                return _amount_doc_curr;
            }

            set
            {
                _amount_doc_curr = value; RaisePropertyChanged("amount_doc_curr", ModelEntityUpdated);
            }
        }
        private decimal? _amount_ledger;
        public decimal? amount_ledger
        {
            get
            {
                return _amount_ledger;
            }

            set
            {
                _amount_ledger = value; RaisePropertyChanged("amount_ledger");
            }
        }
        private decimal? _amt_loc_taxbase;
        public decimal? amt_loc_taxbase
        {
            get
            {
                return _amt_loc_taxbase;
            }

            set
            {
                _amt_loc_taxbase = value; RaisePropertyChanged("amt_loc_taxbase");
            }
        }
        private decimal? _amt_doc_taxbase;
        public decimal? amt_doc_taxbase
        {
            get
            {
                return _amt_doc_taxbase;
            }

            set
            {
                _amt_doc_taxbase = value; RaisePropertyChanged("amt_doc_taxbase");
            }
        }
        private decimal? _amt_tax_local_curr;
        public decimal? amt_tax_local_curr
        {
            get
            {
                return _amt_tax_local_curr;
            }

            set
            {
                _amt_tax_local_curr = value; RaisePropertyChanged("amt_tax_local_curr");
            }
        }
        private decimal? _amt_tax_doc_curr;
        public decimal? amt_tax_doc_curr
        {
            get
            {
                return _amt_tax_doc_curr;
            }

            set
            {
                _amt_tax_doc_curr = value; RaisePropertyChanged("amt_tax_doc_curr");
            }
        }
        private decimal? _amt_withhold_tax;
        public decimal? amt_withhold_tax
        {
            get
            {
                return _amt_withhold_tax;
            }

            set
            {
                _amt_withhold_tax = value; RaisePropertyChanged("amt_withhold_tax", ModelEntityUpdated);
            }
        }
        private decimal? _value_diff;
        public decimal? value_diff
        {
            get
            {
                return _value_diff;
            }

            set
            {
                _value_diff = value; RaisePropertyChanged("value_diff");
            }
        }
        private decimal? _value_diff_sec_curr;
        public decimal? value_diff_sec_curr
        {
            get
            {
                return _value_diff_sec_curr;
            }

            set
            {
                _value_diff_sec_curr = value; RaisePropertyChanged("value_diff_sec_curr");
            }
        }
        private string _assign_no;
        public string assign_no
        {
            get
            {
                return _assign_no;
            }

            set
            {
                _assign_no = value; RaisePropertyChanged("assign_no");
            }
        }
        private string _item_text;
        public string item_text
        {
            get
            {
                return _item_text;
            }

            set
            {
                _item_text = value; RaisePropertyChanged("item_text");
            }
        }
        private string _description;
        public string description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value; RaisePropertyChanged("description");
            }
        }
        private string _trns_type;
        public string trns_type
        {
            get
            {
                return _trns_type;
            }

            set
            {
                _trns_type = value; RaisePropertyChanged("trns_type");
            }
        }
        private string _gl_trns_type;
        public string gl_trns_type
        {
            get
            {
                return _gl_trns_type;
            }

            set
            {
                _gl_trns_type = value; RaisePropertyChanged("gl_trns_type");
            }
        }
        private string _control_area;
        public string control_area
        {
            get
            {
                return _control_area;
            }

            set
            {
                _control_area = value; RaisePropertyChanged("control_area");
            }
        }
        private string _cost_center;
        public string cost_center
        {
            get
            {
                return _cost_center;
            }

            set
            {
                _cost_center = value; RaisePropertyChanged("cost_center");
            }
        }
        private string _order_no;
        public string order_no
        {
            get
            {
                return _order_no;
            }

            set
            {
                _order_no = value; RaisePropertyChanged("order_no");
            }
        }
        private string _bill_doc;
        public string bill_doc
        {
            get
            {
                return _bill_doc;
            }

            set
            {
                _bill_doc = value; RaisePropertyChanged("bill_doc");
            }
        }
        private string _sales_doc;
        public string sales_doc
        {
            get
            {
                return _sales_doc;
            }

            set
            {
                _sales_doc = value; RaisePropertyChanged("sales_doc");
            }
        }
        private int? _sd_item_row_id;
        public int? sd_item_row_id
        {
            get
            {
                return _sd_item_row_id;
            }

            set
            {
                _sd_item_row_id = value; RaisePropertyChanged("sd_item_row_id");
            }
        }
        private int? _bill_doc_item_row_id;
        public int? bill_doc_item_row_id
        {
            get
            {
                return _bill_doc_item_row_id;
            }

            set
            {
                _bill_doc_item_row_id = value; RaisePropertyChanged("bill_doc_item_row_id");
            }
        }
        private int? _sch_item_row_id;
        public int? sch_item_row_id
        {
            get
            {
                return _sch_item_row_id;
            }

            set
            {
                _sch_item_row_id = value; RaisePropertyChanged("sch_item_row_id");
            }
        }
        private int? _dn_item_row_id;
        public int? dn_item_row_id
        {
            get
            {
                return _dn_item_row_id;
            }

            set
            {
                _dn_item_row_id = value; RaisePropertyChanged("dn_item_row_id");
            }
        }
        private string _main_asset_no;
        public string main_asset_no
        {
            get
            {
                return _main_asset_no;
            }

            set
            {
                _main_asset_no = value; RaisePropertyChanged("main_asset_no");
            }
        }
        private string _asse_subno;
        public string asse_subno
        {
            get
            {
                return _asse_subno;
            }

            set
            {
                _asse_subno = value; RaisePropertyChanged("asse_subno");
            }
        }
        private string _ind_open_item;
        public string ind_open_item
        {
            get
            {
                return _ind_open_item;
            }

            set
            {
                _ind_open_item = value; RaisePropertyChanged("ind_open_item");
            }
        }
        private string _ind_down_pay;
        public string ind_down_pay
        {
            get
            {
                return _ind_down_pay;
            }

            set
            {
                _ind_down_pay = value; RaisePropertyChanged("ind_down_pay");
            }
        }
        private string _ind_post_key;
        public string ind_post_key
        {
            get
            {
                return _ind_post_key;
            }

            set
            {
                _ind_post_key = value; RaisePropertyChanged("ind_post_key");
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
        private string _ledger_gen;
        public string ledger_gen
        {
            get { return _ledger_gen; }
            set
            {
                _ledger_gen = value;
                RaisePropertyChanged("ledger_gen");
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
                _PartyId = value; RaisePropertyChanged("PartyId");
            }
        }
        private string _PartyNm;
        public string PartyNm
        {
            get
            {
                return _PartyNm;
            }

            set
            {
                _PartyNm = value; RaisePropertyChanged("PartyNm");
            }
        }
        private string _payterm_key;
        public string payterm_key
        {
            get
            {
                return _payterm_key;
            }

            set
            {
                _payterm_key = value; RaisePropertyChanged("payterm_key");
            }
        }
        private decimal? _cash_disc1;
        public decimal? cash_disc1
        {
            get
            {
                return _cash_disc1;
            }

            set
            {
                _cash_disc1 = value; RaisePropertyChanged("cash_disc1", ModelEntityUpdated);
            }
        }
        private decimal? _payterm_period;
        public decimal? payterm_period
        {
            get
            {
                return _payterm_period;
            }

            set
            {
                _payterm_period = value; RaisePropertyChanged("payterm_period");
            }
        }
        private decimal? _disc_per1;
        public decimal? disc_per1
        {
            get
            {
                return _disc_per1;
            }

            set
            {
                _disc_per1 = value; RaisePropertyChanged("disc_per1");
            }
        }
        private decimal? _amt_cd_eligible;
        public decimal? amt_cd_eligible
        {
            get
            {
                return _amt_cd_eligible;
            }

            set
            {
                _amt_cd_eligible = value; RaisePropertyChanged("amt_cd_eligible");
            }
        }
        private decimal? _cd_loc_curr;
        public decimal? cd_loc_curr
        {
            get
            {
                return _cd_loc_curr;
            }

            set
            {
                _cd_loc_curr = value; RaisePropertyChanged("cd_loc_curr");
            }
        }
        private decimal? _cd_doc_curr;
        public decimal? cd_doc_curr
        {
            get
            {
                return _cd_doc_curr;
            }

            set
            {
                _cd_doc_curr = value; RaisePropertyChanged("cd_doc_curr");
            }
        }
        private string _pay_method;
        public string pay_method
        {
            get
            {
                return _pay_method;
            }

            set
            {
                _pay_method = value; RaisePropertyChanged("pay_method");
            }
        }
        private string _pay_block_key;
        public string pay_block_key
        {
            get
            {
                return _pay_block_key;
            }

            set
            {
                _pay_block_key = value; RaisePropertyChanged("pay_block_key");
            }
        }
        private string _hb_code;
        public string hb_code
        {
            get
            {
                return _hb_code;
            }

            set
            {
                _hb_code = value; RaisePropertyChanged("hb_code");
            }
        }
        private string _hb_acc;
        public string hb_acc
        {
            get
            {
                return _hb_acc;
            }

            set
            {
                _hb_acc = value; RaisePropertyChanged("hb_acc", ModelEntityUpdated);
            }
        }
        private decimal? _net_pay_amt;
        public decimal? net_pay_amt
        {
            get
            {
                return _net_pay_amt;
            }

            set
            {
                _net_pay_amt = value; RaisePropertyChanged("net_pay_amt", ModelEntityUpdated);
            }
        }
        private string _ex_bill_no;
        public string ex_bill_no
        {
            get
            {
                return _ex_bill_no;
            }

            set
            {
                _ex_bill_no = value; RaisePropertyChanged("ex_bill_no");
            }
        }
        private DateTime? _ex_bill_duedate;
        public DateTime? ex_bill_duedate
        {
            get
            {
                return _ex_bill_duedate;
            }

            set
            {
                _ex_bill_duedate = value; RaisePropertyChanged("ex_bill_duedate");
            }
        }
        private string _tax_certi;
        public string tax_certi
        {
            get
            {
                return _tax_certi;
            }

            set
            {
                _tax_certi = value; RaisePropertyChanged("tax_certi");
            }
        }
        private decimal? _amt_withtax;
        public decimal? amt_withtax
        {
            get
            {
                return _amt_withtax;
            }

            set
            {
                _amt_withtax = value; RaisePropertyChanged("amt_withtax");
            }
        }
        private decimal? _amt_withtax_ex;
        public decimal? amt_withtax_ex
        {
            get
            {
                return _amt_withtax_ex;
            }

            set
            {
                _amt_withtax_ex = value; RaisePropertyChanged("amt_withtax_ex");
            }
        }
        private Nullable<decimal> _qty;
        public decimal? qty
        {
            get
            {
                return _qty;
            }

            set
            {
                _qty = value; RaisePropertyChanged("qty");
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
        private string _po_no;
        public string po_no
        {
            get
            {
                return _po_no;
            }

            set
            {
                _po_no = value; RaisePropertyChanged("po_no");
            }
        }
        private int? _po_item_row_id;
        public int? po_item_row_id
        {
            get
            {
                return _po_item_row_id;
            }

            set
            {
                _po_item_row_id = value; RaisePropertyChanged("po_item_row_id");
            }
        }
        private string _reason_code;
        public string reason_code
        {
            get
            {
                return _reason_code;
            }

            set
            {
                _reason_code = value; RaisePropertyChanged("reason_code");
            }
        }
        private string _profit_center;
        public string profit_center
        {
            get
            {
                return _profit_center;
            }

            set
            {
                _profit_center = value; RaisePropertyChanged("profit_center");
            }
        }
        private string _ind_neg_posting;
        public string ind_neg_posting
        {
            get
            {
                return _ind_neg_posting;
            }

            set
            {
                _ind_neg_posting = value; RaisePropertyChanged("ind_neg_posting");
            }
        }
        private string _pay_ref;
        public string pay_ref
        {
            get
            {
                return _pay_ref;
            }

            set
            {
                _pay_ref = value; RaisePropertyChanged("pay_ref", ModelEntityUpdated);
            }
        }
        private string _acc_assign_cat;
        public string acc_assign_cat
        {
            get
            {
                return _acc_assign_cat;
            }

            set
            {
                _acc_assign_cat = value; RaisePropertyChanged("acc_assign_cat");
            }
        }
        private decimal? _net_payable_amt;
        public decimal? net_payable_amt
        {
            get
            {
                return _net_payable_amt;
            }

            set
            {
                _net_payable_amt = value; RaisePropertyChanged("net_payable_amt");
            }
        }
        private decimal? _loss_real1;
        public decimal? loss_real1
        {
            get
            {
                return _loss_real1;
            }

            set
            {
                _loss_real1 = value; RaisePropertyChanged("loss_real1");
            }
        }
        private decimal? _penalty_loc1;
        public decimal? penalty_loc1
        {
            get
            {
                return _penalty_loc1;
            }

            set
            {
                _penalty_loc1 = value; RaisePropertyChanged("penalty_loc1");
            }
        }
        private int? _days_penalty;
        public int? days_penalty
        {
            get
            {
                return _days_penalty;
            }

            set
            {
                _days_penalty = value; RaisePropertyChanged("days_penalty");
            }
        }
        private string _late_reason;
        public string late_reason
        {
            get
            {
                return _late_reason;
            }

            set
            {
                _late_reason = value; RaisePropertyChanged("late_reason");
            }
        }
        private Nullable<decimal> _tax_profit;
        public decimal? tax_profit
        {
            get
            {
                return _tax_profit;
            }

            set
            {
                _tax_profit = value; RaisePropertyChanged("tax_profit", ModelEntityUpdated);
            }
        }
        private string _acc_gl_code;
        public string acc_gl_code
        {
            get
            {
                return _acc_gl_code;
            }

            set
            {
                _acc_gl_code = value; RaisePropertyChanged("acc_gl_code");
            }
        }
        private bool? _active;
        public bool? active
        {
            get
            {
                return _active;
            }

            set
            {
                _active = value; RaisePropertyChanged("active");
            }
        }
        private string _userid;
        public string userid
        {
            get
            {
                return _userid;
            }

            set
            {
                _userid = value; RaisePropertyChanged("userid");
            }
        }
        private System.DateTime? _add_date;
        public DateTime? add_date
        {
            get
            {
                return _add_date;
            }

            set
            {
                _add_date = value; RaisePropertyChanged("add_date");
            }
        }
        private string _t_status;
        public string t_status
        {
            get
            {
                return _t_status;
            }

            set
            {
                _t_status = value; RaisePropertyChanged("t_status");
            }
        }
        private decimal? _doc_exch_rate;
        public decimal? doc_exch_rate
        {
            get
            {
                return _doc_exch_rate;
            }

            set
            {
                _doc_exch_rate = value; RaisePropertyChanged("doc_exch_rate");
            }
        }
        private decimal? _cur_exch_rate;
        public decimal? cur_exch_rate
        {
            get
            {
                return _cur_exch_rate;
            }

            set
            {
                _cur_exch_rate = value; RaisePropertyChanged("cur_exch_rate", ModelEntityUpdated);
            }
        }
        private DateTime? _posting_dt;
        public DateTime? posting_dt
        {
            get
            {
                return _posting_dt;
            }

            set
            {
                _posting_dt = value; RaisePropertyChanged("posting_dt");
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
                _ref_doc_no = value; RaisePropertyChanged("ref_doc_no");
            }
        }
        private Nullable<int> _ref_doc_item_row_id;
        public int? ref_doc_item_row_id
        {
            get
            {
                return _ref_doc_item_row_id;
            }

            set
            {
                _ref_doc_item_row_id = value; RaisePropertyChanged("ref_doc_item_row_id");
            }
        }
        private DateTime? _doc_date;
        public DateTime? doc_date
        {
            get
            {
                return _doc_date;
            }

            set
            {
                _doc_date = value; RaisePropertyChanged("doc_date");
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
                _doc_cat = value; RaisePropertyChanged("doc_cat");
            }
        }
        private string _doc_type;
        public string doc_type
        {
            get
            {
                return _doc_type;
            }

            set
            {
                _doc_type = value; RaisePropertyChanged("doc_type");
            }
        }
        private string _tax_code;
        public string tax_code
        {
            get
            {
                return _tax_code;
            }

            set
            {
                _tax_code = value; RaisePropertyChanged("tax_code");
            }
        }
        private decimal? _amt_withhold_taxbase;
        public decimal? amt_withhold_taxbase
        {
            get
            {
                return _amt_withhold_taxbase;
            }

            set
            {
                _amt_withhold_taxbase = value; RaisePropertyChanged("amt_withhold_taxbase");
            }
        }
        private decimal? _amt_withhold_tax_doc;
        public decimal? amt_withhold_tax_doc
        {
            get
            {
                return _amt_withhold_tax_doc;
            }

            set
            {
                _amt_withhold_tax_doc = value; RaisePropertyChanged("amt_withhold_tax_doc");
            }
        }
        private decimal? _amt_withhold_tax_loc;
        public decimal? amt_withhold_tax_loc
        {
            get
            {
                return _amt_withhold_tax_loc;
            }

            set
            {
                _amt_withhold_tax_loc = value; RaisePropertyChanged("amt_withhold_tax_loc");
            }
        }
        private string _wtax_certificate_no;
        public string wtax_certificate_no
        {
            get { return _wtax_certificate_no; }
            set
            {
                if (_wtax_certificate_no != value)
                {
                    _wtax_certificate_no = value; RaisePropertyChanged("wtax_certificate_no");
                }
            }
        }
        private string _curr_code;
        public string curr_code
        {
            get { return _curr_code; }
            set
            {
                _curr_code = value;
                RaisePropertyChanged("curr_code");
            }
        }
        private decimal? _bal_amt;
        public decimal? bal_amt
        {
            get
            {
                return _bal_amt;
            }

            set
            {
                _bal_amt = value; RaisePropertyChanged("bal_amt");
            }
        }
        private decimal? _order_price;
        public decimal? order_price
        {
            get
            {
                return _order_price;
            }

            set
            {
                _order_price = value; RaisePropertyChanged("order_price", ModelEntityUpdated);
            }
        }
        private decimal? _amt_cc;
        public decimal? amt_cc
        {
            get
            {
                return _amt_cc;
            }

            set
            {
                _amt_cc = value; RaisePropertyChanged("amt_cc", ModelEntityUpdated);
            }
        }
        private string _accounting_doc_no;
        public string accounting_doc_no
        {
            get { return _accounting_doc_no; }
            set
            {
                if (_accounting_doc_no != value)
                {
                    _accounting_doc_no = value; RaisePropertyChanged("accounting_doc_no");
                }
            }
        }
        private int? _open_item_row_id;
        public int? open_item_row_id
        {
            get
            {
                return _open_item_row_id;
            }

            set
            {
                _open_item_row_id = value; RaisePropertyChanged("open_item_row_id");
            }
        }
        private decimal? _ex_rate_diff;
        public decimal? ex_rate_diff
        {
            get
            {
                return _ex_rate_diff;
            }

            set
            {
                _ex_rate_diff = value; RaisePropertyChanged("ex_rate_diff", ModelEntityUpdated);
            }
        }

        //Scalers
        private string _GlName;
        public string GlName
        {
            get
            {
                return _GlName;
            }

            set
            {
                _GlName = value; RaisePropertyChanged("GlName");
            }
        }
        private string _gl_name;
        public string gl_name
        {
            get
            {
                return _gl_name;
            }

            set
            {
                _gl_name = value; RaisePropertyChanged("gl_name");
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
        public string _AssignColor;
        public string AssignColor
        {
            get { return _AssignColor; }
            set
            {
                if (_AssignColor != value)
                {
                    _AssignColor = value; RaisePropertyChanged("AssignColor");
                }
            }
        }


    }
    public class ACC_T001_C : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private string _doc_no;
        public string doc_no
        {
            get
            { return _doc_no; }
            set
            { _doc_no = value; RaisePropertyChanged("doc_no", ModelEntityUpdated); }
        }

        private string _comp_code;
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
        private int? _ref_row_id;
        public int? ref_row_id
        {
            get
            {
                return _ref_row_id;
            }

            set
            {
                _ref_row_id = value; RaisePropertyChanged("ref_row_id", ModelEntityUpdated);
            }
        }
        private string _order_no;
        public string order_no
        {
            get
            {
                return _order_no;
            }

            set
            {
                _order_no = value; RaisePropertyChanged("order_no", ModelEntityUpdated);
            }
        }
        private string _bill_doc;
        public string bill_doc
        {
            get
            {
                return _bill_doc;
            }

            set
            {
                _bill_doc = value; RaisePropertyChanged("bill_doc", ModelEntityUpdated);
            }
        }
        private decimal _amount;
        public decimal amount
        {
            get
            {
                return _amount;
            }

            set
            {
                _amount = value; RaisePropertyChanged("amount", ModelEntityUpdated);
            }
        }

    }
    public class ACC_T001_Flip
    {
        public string doc_no { get; set; }
        public string doc_date { get; set; }
        public string t_status { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string pay_method { get; set; }
        public string amount { get; set; }
        public string check_no { get; set; }
        public string comp_code { get; set; }
        public string doc_type { get; set; }
        public string SalesPerson { get; set; }
        public string t_display { get; set; }

    }
    public class RptPaymentEntry
    {
        public string doc_no { get; set; }
        public string doc_date { get; set; }
        public string doc_type { get; set; }
        public decimal amount { get; set; }
        public string check_no { get; set; }
        public string PartyNm { get; set; }
        public string bank_name_payer { get; set; }
        public string bank_branch { get; set; }
        public string note { get; set; }
        public byte[] authorised_signature { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string pay_method { get; set; }
        public string salesPersnNm { get; set; }
        public string PersnEmailId { get; set; }
        public string PersnContNo { get; set; }
    }
    public class RptPaymentEntryItem
    {
        public Nullable<decimal> cash_disc1 { get; set; }
        public string pay_ref { get; set; }
        public Nullable<decimal> net_pay_amt { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
    }
    public class MultipleContext_ACC_T001
    {
        public List<ADM_M0013> STATUS_LIST { get; set; }
        public List<ACC_T001_Flip> DocumentDataFlipGrid { get; set; }
        public List<ADM_M028_P> PartyMaster { get; set; }
        public List<ACC_M004_P> BanksMaster { get; set; }
        public List<ADM_M037_P> Currencys { get; set; }
        public List<ADM_M002_P> CompanyMaster { get; set; }
        public List<ACC_M003_P> GLCodes { get; set; }
        public List<ACC_M028_P> SpecialGLCodes { get; set; }
        public List<SEL_T003_P> SalesPurchaseInvoice { get; set; }
        public List<SEL_T001_P> SalesOrderList { get; set; }
        public List<ACC_T001> MasterEntity { get; set; }
        public ObservableCollection<ACC_T001_A> DetailEntity { get; set; }
        public List<ADM_M028_D> AddressMaster { get; set; }
        public List<ADM_M012_P> CountryMaster { get; set; }
        public List<ADM_M013_P> StateMaster { get; set; }
        public List<ADM_M024_P> SalesPerson { get; set; }
        public List<RptPaymentEntry> RptPaymentEntry { get; set; }
        public List<RptPaymentEntryItem> RptPaymentEntryItem { get; set; }
        public List<ACC_M004_B_P> OurBankAccNoList { get; set; }
        public List<ACC_M027_P> PayMethodList { get; set; }
        public List<SYS_M027_P> ReasonList { get; set; }
        public List<ACC_M020_P> ProfitCenterList { get; set; }
        public List<ADM_M028_E_P> PartyBankAccNoList { get; set; }
        public List<ACC_T001_A> OpenDocumentNoList { get; set; }
        public List<SYS_M015> DocumentTypes { get; set; }
        public ObservableCollection<ACC_T001_B> OpenItems { get; set; }
        public ObservableCollection<ACC_T001_C> PAYMENT_ALLOCATION { get; set; }
        public List<STD_LIST_BE> PAYMENT_MODE_LIST { get; set; }
    }
}
