using Reflection.BusinessEntity.ADM;
using Reflection.BusinessEntity.CustomerRelation;
using Reflection.BusinessEntity.Finance;
using Reflection.BusinessEntity.GEN;
using Reflection.BusinessEntity.ReflectionSystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Reflection.BusinessEntity
{
    public class SEL_T003 : ObjectBase
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
                if (_id != value)
                {
                    _id = value; RaisePropertyChanged("id", ModelEntityUpdated);
                }
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
                if (_bill_doc != value)
                {
                    _bill_doc = value; RaisePropertyChanged("bill_doc", ModelEntityUpdated);
                }
            }
        }
        private string _bill_type;
        public string bill_type
        {
            get
            {
                return _bill_type;
            }
            set
            {
                if (_bill_type != value)
                {
                    _bill_type = value; RaisePropertyChanged("bill_type", ModelEntityUpdated);
                }
            }
        }
        private string _bill_cat;
        public string bill_cat
        {
            get
            {
                return _bill_cat;
            }
            set
            {
                if (_bill_cat != value)
                {
                    _bill_cat = value; RaisePropertyChanged("bill_cat", ModelEntityUpdated);
                }
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
                if (_doc_cat != value)
                {
                    _doc_cat = value; RaisePropertyChanged("doc_cat", ModelEntityUpdated);
                }
            }
        }
        private string _doc_type;
        [Required(ErrorMessage = "Field 'Doc Type' is required.")]
        public string doc_type
        {
            get
            {
                return _doc_type;
            }
            set
            {
                if (_doc_type != value)
                {
                    _doc_type = value; RaisePropertyChanged("doc_type", ModelEntityUpdated);
                }
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
                if (_curr_code != value)
                {
                    _curr_code = value; RaisePropertyChanged("curr_code", ModelEntityUpdated);
                }
            }
        }
        private Nullable<System.DateTime> _doc_date;
        public Nullable<System.DateTime> doc_date
        {
            get
            {
                return _doc_date;
            }
            set
            {
                if (_doc_date != value)
                {
                    _doc_date = value; RaisePropertyChanged("doc_date", ModelEntityUpdated);
                }
            }
        }
        private Nullable<System.DateTime> _post_date;
        public Nullable<System.DateTime> post_date
        {
            get
            {
                return _post_date;
            }
            set
            {
                if (_post_date != value)
                {
                    _post_date = value; RaisePropertyChanged("post_date", ModelEntityUpdated);
                }
            }
        }
        private string _so_code;
        public string so_code
        {
            get
            {
                return _so_code;
            }
            set
            {

                if (_so_code != value)
                {
                    _so_code = value; RaisePropertyChanged("so_code", ModelEntityUpdated);
                }
            }
        }
        private string _dc_code;
        public string dc_code
        {
            get
            {
                return _dc_code;
            }
            set
            {
                if (_dc_code != value)
                {
                    _dc_code = value; RaisePropertyChanged("dc_code", ModelEntityUpdated);
                }
            }
        }
        private string _ship_cnd;
        public string ship_cnd
        {
            get
            {
                return _ship_cnd;
            }
            set
            {
                if (_ship_cnd != value)
                {
                    _ship_cnd = value; RaisePropertyChanged("ship_cnd", ModelEntityUpdated);
                }
            }
        }
        private Nullable<System.DateTime> _bill_date;
        public Nullable<System.DateTime> bill_date
        {
            get
            {
                return _bill_date;
            }
            set
            {
                if (_bill_date != value)
                {
                    _bill_date = value; RaisePropertyChanged("bill_date", ModelEntityUpdated);
                }
            }
        }
        private string _acc_doc;
        public string acc_doc
        {
            get
            {
                return _acc_doc;
            }
            set
            {
                if (_acc_doc != value)
                {
                    _acc_doc = value; RaisePropertyChanged("acc_doc", ModelEntityUpdated);
                }
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
                if (_fin_year != value)
                {
                    _fin_year = value; RaisePropertyChanged("fin_year", ModelEntityUpdated);
                }
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
                if (_posting_period != value)
                {
                    _posting_period = value; RaisePropertyChanged("posting_period", ModelEntityUpdated);
                }
            }
        }
        private string _incoterms;
        public string incoterms
        {
            get
            {
                return _incoterms;
            }
            set
            {
                if (_incoterms != value)
                {
                    _incoterms = value; RaisePropertyChanged("incoterms", ModelEntityUpdated);
                }
            }
        }
        private string _export_ind;
        public string export_ind
        {
            get
            {
                return _export_ind;
            }
            set
            {
                if (_export_ind != value)
                {
                    _export_ind = value; RaisePropertyChanged("export_ind", ModelEntityUpdated);
                }
            }
        }
        private string _transfer_status;
        public string transfer_status
        {
            get
            {
                return _transfer_status;
            }
            set
            {
                if (_transfer_status != value)
                {
                    _transfer_status = value; RaisePropertyChanged("transfer_status", ModelEntityUpdated);
                }
            }
        }
        private Nullable<decimal> _exc_rate;
        public Nullable<decimal> exc_rate
        {
            get
            {
                return _exc_rate;
            }
            set
            {
                if (_exc_rate != value)
                {
                    _exc_rate = value; RaisePropertyChanged("exc_rate", ModelEntityUpdated);
                }
            }
        }
        private string _p_term_code;
        public string p_term_code
        {
            get
            {
                return _p_term_code;
            }
            set
            {
                if (_p_term_code != value)
                {
                    _p_term_code = value; RaisePropertyChanged("p_term_code", ModelEntityUpdated);
                }
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
                if (_pay_method != value)
                {
                    _pay_method = value; RaisePropertyChanged("pay_method", ModelEntityUpdated);
                }
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
                if (_country_code != value)
                {
                    _country_code = value; RaisePropertyChanged("country_code", ModelEntityUpdated);
                }
            }
        }
        private string _region;
        public string region
        {
            get
            {
                return _region;
            }
            set
            {
                if (_region != value)
                {
                    _region = value; RaisePropertyChanged("region", ModelEntityUpdated);
                }
            }
        }
        private string _city;
        public string city
        {
            get
            {
                return _city;
            }
            set
            {
                if (_city != value)
                {
                    _city = value; RaisePropertyChanged("city", ModelEntityUpdated);
                }
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
                if (_comp_code != value)
                {
                    _comp_code = value; RaisePropertyChanged("comp_code", ModelEntityUpdated);

                }
            }
        }
        private Nullable<System.TimeSpan> _entry_time;
        public Nullable<System.TimeSpan> entry_time
        {
            get
            {
                return _entry_time;
            }
            set
            {
                if (_entry_time != value)
                {
                    _entry_time = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second); RaisePropertyChanged("entry_time", ModelEntityUpdated);

                }
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
                if (_PartyId != value)
                {
                    _PartyId = value; RaisePropertyChanged("PartyId", ModelEntityUpdated);
                }
            }
        }
        private string _payer;
        public string payer
        {
            get { return _payer; }
            set
            {
                if (_payer != value)
                {
                    _payer = value; RaisePropertyChanged("payer", ModelEntityUpdated);
                }
            }
        }
        private string _vat_no;
        public string vat_no
        {
            get
            {
                return _vat_no;
            }
            set
            {
                if (_vat_no != value)
                {
                    _vat_no = value; RaisePropertyChanged("vat_no", ModelEntityUpdated);
                }
            }
        }
        private Nullable<int> _exc_rate_tp;
        public Nullable<int> exc_rate_tp
        {
            get
            {
                return _exc_rate_tp;
            }
            set
            {
                if (_exc_rate_tp != value)
                {
                    _exc_rate_tp = value; RaisePropertyChanged("exc_rate_tp", ModelEntityUpdated);
                }
            }
        }
        private string _div_code;
        public string div_code
        {
            get
            {
                return _div_code;
            }
            set
            {
                if (_div_code != value)
                {
                    _div_code = value; RaisePropertyChanged("div_code", ModelEntityUpdated);
                }
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
                if (_po_no != value)
                {
                    _po_no = value; RaisePropertyChanged("po_no", ModelEntityUpdated);
                }
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
                if (_ref_doc_no != value)
                {
                    _ref_doc_no = value; RaisePropertyChanged("ref_doc_no", ModelEntityUpdated);

                }
            }
        }
        private DateTime? _ref_doc_date;
        public DateTime? ref_doc_date
        {
            get
            {
                return _ref_doc_date;
            }
            set
            {
                if (_ref_doc_date != value)
                {
                    _ref_doc_date = value; RaisePropertyChanged("ref_doc_date", ModelEntityUpdated);

                }
            }
        }
        private string _tax_org;
        public string tax_org
        {
            get
            {
                return _tax_org;
            }
            set
            {
                if (_tax_org != value)
                {
                    _tax_org = value; RaisePropertyChanged("tax_org", ModelEntityUpdated);
                }
            }
        }
        private string _st_org;
        public string st_org
        {
            get
            {
                return _st_org;
            }
            set
            {
                if (_st_org != value)
                {
                    _st_org = value; RaisePropertyChanged("st_org", ModelEntityUpdated);
                }
            }
        }
        private string _country_st_cd;
        public string country_st_cd
        {
            get
            {
                return _country_st_cd;
            }
            set
            {
                if (_country_st_cd != value)
                {
                    _country_st_cd = value; RaisePropertyChanged("country_st_cd", ModelEntityUpdated);
                }
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
                if (_assign_no != value)
                {
                    _assign_no = value; RaisePropertyChanged("assign_no", ModelEntityUpdated);
                }
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
                if (_tax_amount != value)
                {
                    _tax_amount = value; RaisePropertyChanged("tax_amount", ModelEntityUpdated);
                }
            }
        }
        private Nullable<decimal> _sub_total;
        public Nullable<decimal> sub_total
        {
            get
            {
                return _sub_total;
            }
            set
            {
                if (_sub_total != value)
                {
                    _sub_total = value; RaisePropertyChanged("sub_total", ModelEntityUpdated);
                }
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
                if (_amt_word != value)
                {
                    _amt_word = value; RaisePropertyChanged("amt_word", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _disc_amt;
        public Nullable<decimal> disc_amt
        {
            get
            {
                return _disc_amt;
            }
            set
            {
                if (_disc_amt != value)
                {
                    _disc_amt = value; RaisePropertyChanged("disc_amt", ModelEntityUpdated);
                }
            }
        }
        private Nullable<decimal> _ass_value;
        public Nullable<decimal> ass_value
        {
            get
            {
                return _ass_value;
            }
            set
            {
                if (_ass_value != value)
                {
                    _ass_value = value; RaisePropertyChanged("ass_value", ModelEntityUpdated);
                }
            }
        }
        private Nullable<decimal> _fright_values;
        public Nullable<decimal> fright_values
        {
            get
            {
                return _fright_values;
            }
            set
            {
                if (_fright_values != value)
                {
                    _fright_values = value; RaisePropertyChanged("fright_values", ModelEntityUpdated);

                }
            }
        }
        private Nullable<decimal> _invoice_amt;
        public Nullable<decimal> invoice_amt
        {
            get
            {
                return _invoice_amt;
            }
            set
            {
                if (_invoice_amt != value)
                {
                    _invoice_amt = value; RaisePropertyChanged("invoice_amt", ModelEntityUpdated);
                }
            }
        }
        private Nullable<decimal> _invoice_amtr;
        public Nullable<decimal> invoice_amtr
        {
            get
            {
                return _invoice_amtr;
            }
            set
            {
                if (_invoice_amtr != value)
                {
                    _invoice_amtr = value; RaisePropertyChanged("invoice_amtr", ModelEntityUpdated);
                }
            }
        }
        private string _cancel_doc;
        public string cancel_doc
        {
            get
            {
                return _cancel_doc;
            }
            set
            {
                if (_cancel_doc != value)
                {
                    _cancel_doc = value; RaisePropertyChanged("cancel_doc", ModelEntityUpdated);
                }
            }
        }
        private string _lc_curr;
        public string lc_curr
        {
            get
            {
                return _lc_curr;
            }
            set
            {
                if (_lc_curr != value)
                {
                    _lc_curr = value; RaisePropertyChanged("lc_curr", ModelEntityUpdated);
                }
            }
        }
        private Nullable<decimal> _lc_exc_rate;
        public Nullable<decimal> lc_exc_rate
        {
            get
            {
                return _lc_exc_rate;
            }
            set
            {
                if (_lc_exc_rate != value)
                {
                    _lc_exc_rate = value; RaisePropertyChanged("lc_exc_rate", ModelEntityUpdated);
                }
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
                if (_pay_ref != value)
                {
                    _pay_ref = value; RaisePropertyChanged("pay_ref", ModelEntityUpdated);

                }
            }
        }
        private string _party_bank;
        public string party_bank
        {
            get
            {
                return _party_bank;
            }
            set
            {
                if (_party_bank != value)
                {
                    _party_bank = value; RaisePropertyChanged("party_bank", ModelEntityUpdated);

                }
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
                if (_buss_place != value)
                {
                    _buss_place = value; RaisePropertyChanged("buss_place", ModelEntityUpdated);

                }
            }
        }
        private string _contract_acc;
        public string contract_acc
        {
            get
            {
                return _contract_acc;
            }
            set
            {
                if (_contract_acc != value)
                {
                    _contract_acc = value; RaisePropertyChanged("contract_acc", ModelEntityUpdated);
                }
            }
        }
        private string _cancel_re;
        public string cancel_re
        {
            get
            {
                return _cancel_re;
            }
            set
            {
                if (_cancel_re != value)
                {
                    _cancel_re = value; RaisePropertyChanged("cancel_re", ModelEntityUpdated);
                }
            }
        }
        private string _source_type;
        public string source_type
        {
            get
            {
                return _source_type;
            }
            set
            {
                if (_source_type != value)
                {
                    _source_type = value; RaisePropertyChanged("source_type", ModelEntityUpdated);

                }
            }
        }
        private string _source_no;
        public string source_no
        {
            get
            {
                return _source_no;
            }
            set
            {
                if (_source_no != value)
                {
                    _source_no = value; RaisePropertyChanged("source_no", ModelEntityUpdated);

                }
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
                if (_hb_acc != value)
                {
                    _hb_acc = value; RaisePropertyChanged("hb_acc", ModelEntityUpdated);

                }
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
                if (_gl_code != value)
                {
                    _gl_code = value; RaisePropertyChanged("gl_code", ModelEntityUpdated);

                }
            }
        }
        private string _j_code;
        public string j_code
        {
            get
            {
                return _j_code;
            }
            set
            {
                if (_j_code != value)
                {
                    _j_code = value; RaisePropertyChanged("j_code", ModelEntityUpdated);
                }
            }
        }
        private string _cust_acc;
        public string cust_acc
        {
            get
            {
                return _cust_acc;
            }
            set
            {
                if (_cust_acc != value)
                {
                    _cust_acc = value; RaisePropertyChanged("cust_acc", ModelEntityUpdated);

                }
            }
        }
        private string _ProdNmCd;
        public string ProdNmCd
        {
            get
            {
                return _ProdNmCd;
            }
            set
            {
                if (_ProdNmCd != value)
                {
                    _ProdNmCd = value; RaisePropertyChanged("ProdNmCd", ModelEntityUpdated);

                }
            }
        }
        private string _bank_code;
        public string bank_code
        {
            get
            {
                return _bank_code;
            }
            set
            {
                if (_bank_code != value)
                {
                    _bank_code = value; RaisePropertyChanged("bank_code", ModelEntityUpdated);

                }
            }
        }
        private string _para1;
        [Required(ErrorMessage = "Field 'Sales Person' is required.")]
        public string para1
        {
            get
            {
                return _para1;
            }
            set
            {
                if (_para1 != value)
                {
                    _para1 = value; RaisePropertyChanged("para1", ModelEntityUpdated);

                }
            }
        }
        private Nullable<int> _para2;
        public Nullable<int> para2
        {
            get
            {
                return _para2;
            }
            set
            {
                if (_para2 != value)
                {
                    _para2 = value; RaisePropertyChanged("para2", ModelEntityUpdated);

                }
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
                if (_para3 != value)
                {
                    _para3 = value; RaisePropertyChanged("para3", ModelEntityUpdated);

                }
            }
        }
        private string _para4;
        public string para4
        {
            get
            {
                return _para4;
            }
            set
            {
                if (_para4 != value)
                {
                    _para4 = value; RaisePropertyChanged("para4", ModelEntityUpdated);

                }
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
                if (_para5 != value)
                {
                    _para5 = value; RaisePropertyChanged("para5", ModelEntityUpdated);

                }
            }
        }
        private Nullable<int> _para6;
        public Nullable<int> para6
        {
            get
            {
                return _para6;
            }
            set
            {
                if (_para6 != value)
                {
                    _para6 = value; RaisePropertyChanged("para6", ModelEntityUpdated);
                }

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
                if (_para7 != value)
                {
                    _para7 = value; RaisePropertyChanged("para7", ModelEntityUpdated);
                }
            }
        }
        private string _para8;
        public string para8
        {
            get
            {
                return _para8;
            }
            set
            {
                if (_para8 != value)
                {
                    _para8 = value; RaisePropertyChanged("para8", ModelEntityUpdated);
                }
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
                if (_para9 != value)
                {
                    _para9 = value; RaisePropertyChanged("para9", ModelEntityUpdated);

                }
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
                if (_para10 != value)
                {
                    _para10 = value; RaisePropertyChanged("para10", ModelEntityUpdated);
                }
            }
        }
        private string _lc_cond;
        public string lc_cond
        {
            get
            {
                return _lc_cond;
            }
            set
            {
                if (_lc_cond != value)
                {
                    _lc_cond = value; RaisePropertyChanged("lc_cond", ModelEntityUpdated);

                }
            }
        }
        private string _consignee;
        public string consignee
        {
            get
            {
                return _consignee;
            }
            set
            {
                if (_consignee != value)
                {
                    _consignee = value; RaisePropertyChanged("consignee", ModelEntityUpdated);
                }
            }
        }
        //private string _local_export;
        //[Required(ErrorMessage = "Field 'TransactionType' is required.")]
        //public string local_export
        //{
        //    get
        //    {
        //        return _local_export;
        //    }
        //    set
        //    {
        //        if (_local_export != value)
        //        {
        //            _local_export = value; RaisePropertyChanged("local_export", ModelEntityUpdated);

        //        }
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
        private Nullable<int> _form_type;
        public Nullable<int> form_type
        {
            get
            {
                return _form_type;
            }
            set
            {
                if (_form_type != value)
                {
                    _form_type = value; RaisePropertyChanged("form_type", ModelEntityUpdated);

                }
            }
        }
        private string _lr_no;
        public string lr_no
        {
            get
            {
                return _lr_no;
            }
            set
            {
                if (_lr_no != value)
                {
                    _lr_no = value; RaisePropertyChanged("lr_no", ModelEntityUpdated);

                }
            }
        }
        private Nullable<System.DateTime> _lr_date;
        public Nullable<System.DateTime> lr_date
        {
            get
            {
                return _lr_date;
            }
            set
            {
                if (_lr_date != value)
                {
                    _lr_date = value; RaisePropertyChanged("lr_date", ModelEntityUpdated);

                }
            }
        }
        private string _del_no;
        public string del_no
        {
            get
            {
                return _del_no;
            }
            set
            {
                if (_del_no != value)
                {
                    _del_no = value; RaisePropertyChanged("del_no", ModelEntityUpdated);

                }
            }
        }
        private Nullable<System.DateTime> _del_date;
        public Nullable<System.DateTime> del_date
        {
            get
            {
                return _del_date;
            }
            set
            {
                if (_del_date != value)
                {
                    _del_date = value; RaisePropertyChanged("del_date", ModelEntityUpdated);

                }
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
                if (_tr_mode != value)
                {
                    _tr_mode = value; RaisePropertyChanged("tr_mode");
                }
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
                if (_tr_type != value)
                {
                    _tr_type = value; RaisePropertyChanged("tr_type");
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
        private string _pack_det;
        public string pack_det
        {
            get
            {
                return _pack_det;
            }
            set
            {
                if (_pack_det != value)
                {
                    _pack_det = value; RaisePropertyChanged("pack_det", ModelEntityUpdated);

                }
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
                if (_pre_carrage != value)
                {
                    _pre_carrage = value; RaisePropertyChanged("pre_carrage", ModelEntityUpdated);

                }
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
                if (_pre_carrage_place != value)
                {
                    _pre_carrage_place = value; RaisePropertyChanged("pre_carrage_place", ModelEntityUpdated);

                }
            }
        }
        private string _dest_country_cd;
        public string dest_country_cd
        {
            get
            {
                return _dest_country_cd;
            }
            set
            {
                if (_dest_country_cd != value)
                {
                    _dest_country_cd = value; RaisePropertyChanged("dest_country_cd", ModelEntityUpdated);

                }
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
                if (_port_load != value)
                {
                    _port_load = value; RaisePropertyChanged("port_load", ModelEntityUpdated);

                }
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
                if (_port_desc != value)
                {
                    _port_desc = value; RaisePropertyChanged("port_desc", ModelEntityUpdated);

                }
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
                if (_port_final != value)
                {
                    _port_final = value; RaisePropertyChanged("port_final", ModelEntityUpdated);

                }
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
                if (_final_dest != value)
                {
                    _final_dest = value; RaisePropertyChanged("final_dest", ModelEntityUpdated);
                }
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
                if (_ship_terms != value)
                {
                    _ship_terms = value; RaisePropertyChanged("ship_terms", ModelEntityUpdated);

                }
            }
        }
        private string _advance_lic;
        public string advance_lic
        {
            get
            {
                return _advance_lic;
            }
            set
            {
                if (_advance_lic != value)
                {
                    _advance_lic = value; RaisePropertyChanged("advance_lic", ModelEntityUpdated);


                }
            }
        }
        private string _cf_agent_cd;
        public string cf_agent_cd
        {
            get
            {
                return _cf_agent_cd;
            }
            set
            {
                if (_cf_agent_cd != value)
                {
                    _cf_agent_cd = value; RaisePropertyChanged("cf_agent_cd", ModelEntityUpdated);
                }
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
                if (_lic_cod != value)
                {
                    _lic_cod = value; RaisePropertyChanged("lic_cod", ModelEntityUpdated);

                }
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
                if (_org_country_cd != value)
                {
                    _org_country_cd = value; RaisePropertyChanged("org_country_cd", ModelEntityUpdated);

                }
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
                if (_pack_rem != value)
                {
                    _pack_rem = value; RaisePropertyChanged("pack_rem", ModelEntityUpdated);

                }
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
                if (_ship_mark != value)
                {
                    _ship_mark = value; RaisePropertyChanged("ship_mark", ModelEntityUpdated);

                }
            }
        }
        private string _vess_flight;
        public string vess_flight
        {
            get
            {
                return _vess_flight;
            }
            set
            {
                if (_vess_flight != value)
                {
                    _vess_flight = value; RaisePropertyChanged("vess_flight", ModelEntityUpdated);

                }
            }
        }
        private Nullable<decimal> _wt_gross;
        public Nullable<decimal> wt_gross
        {
            get
            {
                return _wt_gross;
            }
            set
            {
                if (_wt_gross != value)
                {
                    _wt_gross = value; RaisePropertyChanged("wt_gross", ModelEntityUpdated);

                }
            }
        }
        private Nullable<decimal> _wt_net;
        public Nullable<decimal> wt_net
        {
            get
            {
                return _wt_net;
            }
            set
            {
                if (_wt_net != value)
                {
                    _wt_net = value; RaisePropertyChanged("wt_net", ModelEntityUpdated);

                }
            }
        }
        private Nullable<decimal> _gross_wt;
        public Nullable<decimal> gross_wt
        {
            get
            {
                return _gross_wt;
            }
            set
            {
                if (_gross_wt != value)
                {
                    _gross_wt = value; RaisePropertyChanged("gross_wt", ModelEntityUpdated);

                }
            }
        }

        private Nullable<decimal> _net_wt;
        public Nullable<decimal> net_wt
        {
            get
            {
                return _net_wt;
            }
            set
            {
                if (_net_wt != value)
                {
                    _net_wt = value; RaisePropertyChanged("net_wt", ModelEntityUpdated);

                }
            }
        }
        private Nullable<decimal> _volume;
        public Nullable<decimal> volume
        {
            get
            {
                return _volume;
            }
            set
            {
                if (_volume != value)
                {
                    _volume = value; RaisePropertyChanged("volume", ModelEntityUpdated);

                }
            }
        }
        //private string _unit_code;
        //public string unit_code
        //{
        //    get
        //    {
        //        return _unit_code;
        //    }
        //    set
        //    {
        //        if (_unit_code != value)
        //        {
        //            _unit_code = value; RaisePropertyChanged("unit_code", ModelEntityUpdated);

        //        }
        //    }
        //}
        private string _weight_unit;
        public string weight_unit
        {
            get
            {
                return _weight_unit;
            }
            set
            {
                if (_weight_unit != value)
                {
                    _weight_unit = value; RaisePropertyChanged("weight_unit", ModelEntityUpdated);

                }
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
                if (_volume_unit != value)
                {
                    _volume_unit = value; RaisePropertyChanged("volume_unit", ModelEntityUpdated);

                }
            }
        }
        private string _ref_data;
        public string ref_data
        {
            get
            {
                return _ref_data;
            }
            set
            {
                if (_ref_data != value)
                {
                    _ref_data = value; RaisePropertyChanged("ref_data", ModelEntityUpdated);

                }
            }
        }
        private string _ref_data2;
        public string ref_data2
        {
            get
            {
                return _ref_data2;
            }
            set
            {
                if (_ref_data2 != value)
                {
                    _ref_data2 = value; RaisePropertyChanged("ref_data2", ModelEntityUpdated);

                }
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
                if (_description != value)
                {
                    _description = value; RaisePropertyChanged("description", ModelEntityUpdated);

                }
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
                if (_t_status != value)
                {
                    _t_status = value; RaisePropertyChanged("t_status", ModelEntityUpdated);

                }
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
                if (_cost_center != value)
                {
                    _cost_center = value; RaisePropertyChanged("cost_center", ModelEntityUpdated);

                }
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
                if (_location_Id != value)
                {
                    _location_Id = value; RaisePropertyChanged("location_Id", ModelEntityUpdated);

                }
            }
        }
        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get
            {
                return _active;
            }
            set
            {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active", ModelEntityUpdated);

                }
            }
        }

        private string _symbol;
        public string symbol
        {
            get
            {
                return _symbol;
            }
            set
            {
                if (_symbol != value)
                {
                    _symbol = value; RaisePropertyChanged("symbol", ModelEntityUpdated);

                }
            }
        }
        private string _tax_declaration;
        public string tax_declaration
        {
            get
            {
                return _tax_declaration;
            }
            set
            {
                if (_tax_declaration != value)
                {
                    _tax_declaration = value; RaisePropertyChanged("tax_declaration");

                }
            }
        }
        //private string _user_source1;
        //public string user_source1
        //{
        //    get
        //    {
        //        return _user_source1;
        //    }
        //    set
        //    {
        //        if (_user_source1 != value)
        //        {
        //            _user_source1 = value; RaisePropertyChanged("user_source1", ModelEntityUpdated);

        //        }
        //    }
        //}
        //private string _user_source2;
        //public string user_source2
        //{
        //    get
        //    {
        //        return _user_source2;
        //    }
        //    set
        //    {
        //        if (_user_source2 != value)
        //        {
        //            _user_source2 = value; RaisePropertyChanged("user_source2", ModelEntityUpdated);

        //        }
        //    }
        //}
        private string _add_by;
        public string add_by
        {
            get
            {
                return _add_by;
            }
            set
            {
                if (_add_by != value)
                {
                    _add_by = value; RaisePropertyChanged("add_by", ModelEntityUpdated);

                }
            }
        }
        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get
            {
                return _add_date;
            }
            set
            {
                if (_add_date != value)
                {
                    _add_date = value; RaisePropertyChanged("_add_date", ModelEntityUpdated);

                }
            }
        }
        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get
            {
                return _edit_date;
            }
            set
            {
                if (_edit_date != value)
                {
                    _edit_date = value; RaisePropertyChanged("edit_date", ModelEntityUpdated);

                }
            }
        }
        private string _editby;
        public string editby
        {
            get
            {
                return _editby;
            }
            set
            {
                if (_editby != value)
                {
                    _editby = value; RaisePropertyChanged("editby", ModelEntityUpdated);

                }
            }
        }
        private string _nastro_bank_cd;
        public string nastro_bank_cd
        {
            get
            {
                return _nastro_bank_cd;
            }
            set
            {
                if (_nastro_bank_cd != value)
                {
                    _nastro_bank_cd = value; RaisePropertyChanged("nastro_bank_cd", ModelEntityUpdated);

                }
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
                if (_notify_party != value)
                {
                    _notify_party = value; RaisePropertyChanged("notify_party", ModelEntityUpdated);

                }
            }
        }
        private string _notify_party2;
        public string notify_party2
        {
            get
            {
                return _notify_party2;
            }
            set
            {
                if (_notify_party2 != value)
                {
                    _notify_party2 = value; RaisePropertyChanged("notify_party2", ModelEntityUpdated);

                }
            }
        }
        private Nullable<decimal> _round_up;
        public Nullable<decimal> round_up
        {
            get
            {
                return _round_up;
            }
            set
            {
                if (_round_up != value)
                {
                    _round_up = value; RaisePropertyChanged("round_up", ModelEntityUpdated);

                }
            }
        }
        private string _account_no;
        public string account_no
        {
            get
            {
                return _account_no;
            }
            set
            {
                if (_account_no != value)
                {
                    _account_no = value; RaisePropertyChanged("account_no", ModelEntityUpdated);

                }
            }
        }
        private string _swift_code;
        public string swift_code
        {
            get { return _swift_code; }
            set
            {
                if (_swift_code != value)
                {
                    _swift_code = value; RaisePropertyChanged("swift_code", ModelEntityUpdated);

                }
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
                if (_ifsc_code != value)
                {
                    _ifsc_code = value; RaisePropertyChanged("ifsc_code", ModelEntityUpdated);

                }
            }
        }

        private string _cust_cat_no;
        public string cust_cat_no
        {
            get
            {
                return _cust_cat_no;
            }
            set
            {
                if (_cust_cat_no != value)
                {
                    _cust_cat_no = value; RaisePropertyChanged("cust_cat_no", ModelEntityUpdated);
                }
            }
        }
        private string _address;
        public string address
        {
            get { return _address; }
            set
            {
                if (_address != value)
                {
                    _address = value; RaisePropertyChanged("address", ModelEntityUpdated);
                }
            }
        }
        private string _address1;
        public string address1
        {
            get { return _address1; }
            set
            {
                if (_address1 != value)
                {
                    _address1 = value; RaisePropertyChanged("address1", ModelEntityUpdated);
                }
            }
        }
        private string _ref_doc_cat;
        public string ref_doc_cat
        {
            get { return _ref_doc_cat; }
            set
            {
                if (_ref_doc_cat != value)
                {
                    _ref_doc_cat = value; RaisePropertyChanged("ref_doc_cat", ModelEntityUpdated);
                }
            }
        }
        private string _ref_doc_type;
        public string ref_doc_type
        {
            get { return _ref_doc_type; }
            set
            {
                if (_ref_doc_type != value)
                {
                    _ref_doc_type = value; RaisePropertyChanged("ref_doc_type", ModelEntityUpdated);
                }
            }
        }


        private Nullable<int> _bill_address_id;

        public Nullable<int> bill_address_id
        {
            get { return _bill_address_id; }
            set
            {
                if (_bill_address_id != value)
                {
                    _bill_address_id = value; RaisePropertyChanged("bill_address_id", ModelEntityUpdated);
                }
            }
        }
        private decimal? _roundup_total;
        public decimal? roundup_total
        {
            get
            {
                return _roundup_total;
            }

            set
            {
                if (_roundup_total != value)
                {
                    _roundup_total = value; RaisePropertyChanged("roundup_total", ModelEntityUpdated);
                }
            }
        }
        private string _shipping_mark;

        public string shipping_mark
        {
            get { return _shipping_mark; }
            set
            {
                if (_shipping_mark != value)
                {
                    _shipping_mark = value; RaisePropertyChanged("shipping_mark");
                }
            }
        }
        private string _insurance;
        public string insurance
        {
            get { return _insurance; }
            set
            {
                if (_insurance != value)
                {
                    _insurance = value; RaisePropertyChanged("insurance");
                }
            }
        }
        private string _packing;
        public string packing
        {
            get { return _packing; }
            set
            {
                if (_packing != value)
                {
                    _packing = value; RaisePropertyChanged("packing");
                }
            }
        }
        private string _transhipment;
        public string transhipment
        {
            get { return _transhipment; }
            set
            {
                if (_transhipment != value)
                {
                    _transhipment = value; RaisePropertyChanged("transhipment");
                }
            }
        }
        private string _partshipment;
        public string partshipment
        {
            get { return _partshipment; }
            set
            {
                if (_partshipment != value)
                {
                    _partshipment = value; RaisePropertyChanged("partshipment");
                }
            }
        }
        private Nullable<System.DateTime> _shipment_date;
        public Nullable<System.DateTime> shipment_date
        {
            get { return _shipment_date; }
            set
            {
                if (_shipment_date != value)
                {
                    _shipment_date = value; RaisePropertyChanged("shipment_date");
                }
            }
        }
        private Nullable<System.DateTime> _validity_date;
        public Nullable<System.DateTime> validity_date
        {
            get { return _validity_date; }
            set
            {
                if (_validity_date != value)
                {
                    _validity_date = value; RaisePropertyChanged("validity_date");
                }
            }
        }

        private string _payment_mode;
        public string payment_mode
        {
            get { return _payment_mode; }
            set
            {
                if (_payment_mode != value)
                {
                    _payment_mode = value; RaisePropertyChanged("payment_mode");
                }
            }
        }

        private string _sg_code;
        public string sg_code
        {
            get { return _sg_code; }
            set
            {
                if (_sg_code != value)
                {
                    _sg_code = value; RaisePropertyChanged("sg_code");
                }
            }
        }

        private Nullable<System.DateTime> _po_date;
        public Nullable<System.DateTime> po_date
        {
            get { return _po_date; }
            set
            {
                if (_po_date != value)
                {
                    _po_date = value; RaisePropertyChanged("po_date");
                }
            }
        }

        private Nullable<System.DateTime> _ref_date;
        public Nullable<System.DateTime> ref_date
        {
            get { return _ref_date; }
            set
            {
                if (_ref_date != value)
                {
                    _ref_date = value; RaisePropertyChanged("ref_date");
                }
            }
        }
        private string _doc_history_no;
        public string doc_history_no
        {
            get { return _doc_history_no; }
            set
            {
                if (_doc_history_no != value)
                {
                    _doc_history_no = value; RaisePropertyChanged("doc_history_no");
                }
            }
        }

        private string _stock_code;
        public string stock_code
        {
            get { return _stock_code; }
            set
            {
                if (_stock_code != value)
                {
                    _stock_code = value; RaisePropertyChanged("stock_code");
                }
            }
        }
        private string _incoterm2;
        public string incoterm2
        {
            get { return _incoterm2; }
            set
            {
                if (_incoterm2 != value)
                {
                    _incoterm2 = value; RaisePropertyChanged("incoterm2");
                }
            }
        }

        private string _note;
        public string note
        {
            get { return _note; }
            set
            {
                if (_note != value)
                {
                    _note = value; RaisePropertyChanged("note");
                }
            }
        }

        private string _PrintOption;
        public string PrintOption
        {
            get { return _PrintOption; }
            set
            {
                if (_PrintOption != value)
                {
                    _PrintOption = value; RaisePropertyChanged("PrintOption");
                }
            }
        }
        private string _status_remark;
        public string status_remark
        {
            get { return _status_remark; }
            set
            {
                if (_status_remark != value)
                {
                    _status_remark = value; RaisePropertyChanged("status_remark");
                }
            }
        }
        private string _awb_inst;
        public string awb_inst
        {
            get { return _awb_inst; }
            set
            {
                if (_awb_inst != value)
                {
                    _awb_inst = value; RaisePropertyChanged("awb_inst");
                }
            }
        }
        public string XmlDataDocument_SEL_T003_A { get; set; }
        public string XmlDataDocument_ACC_T006_C { get; set; }
        public string XmlDataDocument_ACC_T006_D { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }
        

        //scalar 

        private string _sold_to_party_name;
        public string sold_to_party_name
        {
            get { return _sold_to_party_name; }
            set
            {
                if (_sold_to_party_name != value)
                {
                    _sold_to_party_name = value; RaisePropertyChanged("sold_to_party_name", ModelEntityUpdated);
                }
            }
        }
        private string _payer_name;
        public string payer_name
        {
            get { return _payer_name; }
            set
            {
                if (_payer_name != value)
                {
                    _payer_name = value; RaisePropertyChanged("payer_name", ModelEntityUpdated);
                }
            }
        }

        private string _bank_name;
        public string bank_name
        {
            get { return _bank_name; }
            set
            {
                if (_bank_name != value)
                {
                    _bank_name = value; RaisePropertyChanged("bank_name", ModelEntityUpdated);
                }
            }
        }
        private string _nastro_bank_name;
        public string nastro_bank_name
        {
            get { return _nastro_bank_name; }
            set
            {
                if (_nastro_bank_name != value)
                {
                    _nastro_bank_name = value; RaisePropertyChanged("nastro_bank_name", ModelEntityUpdated);
                }
            }
        }
        private string _cf_agent_name;
        public string cf_agent_name
        {
            get { return _cf_agent_name; }
            set
            {
                if (_cf_agent_name != value)
                {
                    _cf_agent_name = value; RaisePropertyChanged("cf_agent_name", ModelEntityUpdated);
                }
            }
        }
        private string _transporter_name;
        public string transporter_name
        {
            get { return _transporter_name; }
            set
            {
                if (_transporter_name != value)
                {
                    _transporter_name = value; RaisePropertyChanged("transporter_name", ModelEntityUpdated);
                }
            }
        }
        private string _sales_org;
        public string sales_org
        {
            get { return _sales_org; }
            set
            {
                if (_sales_org != value)
                {
                    _sales_org = value; RaisePropertyChanged("sales_org", ModelEntityUpdated);
                }
            }
        }
        private string _cost_center_Desc;
        public string cost_center_Desc
        {
            get { return _cost_center_Desc; }
            set
            {
                if (_cost_center_Desc != value)
                {
                    _cost_center_Desc = value; RaisePropertyChanged("cost_center_Desc", ModelEntityUpdated);
                }
            }
        }
        private string _inco_desc;
        public string inco_desc
        {
            get { return _inco_desc; }
            set
            {
                if (_inco_desc != value)
                {
                    _inco_desc = value; RaisePropertyChanged("inco_desc", ModelEntityUpdated);
                }
            }
        }
        private string _PlantName;

        public string PlantName
        {
            get { return _PlantName; }
            set
            {
                if (_PlantName != value)
                {
                    _PlantName = value; RaisePropertyChanged("PlantName", ModelEntityUpdated);
                }
            }
        }
        private string _wa_name;

        public string wa_name
        {
            get { return _wa_name; }
            set
            {
                if (_wa_name != value)
                {
                    _wa_name = value; RaisePropertyChanged("wa_name", ModelEntityUpdated);
                }
            }
        }
        private string _FormDescription;

        public string FormDescription
        {
            get { return _FormDescription; }
            set
            {
                if (_FormDescription != value)
                {
                    _FormDescription = value; RaisePropertyChanged("FormDescription", ModelEntityUpdated);
                }
            }
        }
        private string _dc_name;

        public string dc_name
        {
            get { return _dc_name; }
            set
            {
                if (_dc_name != value)
                {
                    _dc_name = value; RaisePropertyChanged("dc_name", ModelEntityUpdated);
                }
            }
        }
        private string _CountryName;

        public string CountryName
        {
            get { return _CountryName; }
            set
            {
                if (_CountryName != value)
                {
                    _CountryName = value; RaisePropertyChanged("CountryName", ModelEntityUpdated);
                }
            }
        }
        private string _doc_desc;

        public string doc_desc
        {
            get { return _doc_desc; }
            set
            {
                if (_doc_desc != value)
                {
                    _doc_desc = value; RaisePropertyChanged("doc_desc", ModelEntityUpdated);
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
                    _billing_address = value; RaisePropertyChanged("billing_address", ModelEntityUpdated);
                }
            }
        }
        private string _div_name;

        public string div_name
        {
            get { return _div_name; }
            set
            {
                if (_div_name != value)
                {
                    _div_name = value; RaisePropertyChanged("div_name", ModelEntityUpdated);
                }
            }
        }
        private string _ProdNm;

        public string ProdNm
        {
            get { return _ProdNm; }
            set
            {
                if (_ProdNm != value)
                {
                    _ProdNm = value; RaisePropertyChanged("ProdNm", ModelEntityUpdated);
                }
            }
        }

        private string _j_name;

        public string j_name
        {
            get { return _j_name; }
            set
            {
                if (_j_name != value)
                {
                    _j_name = value; RaisePropertyChanged("j_name", ModelEntityUpdated);
                }
            }
        }

        private string _sg_name;
        public string sg_name
        {
            get { return _sg_name; }
            set
            {
                if (_sg_name != value)
                {
                    _sg_name = value; RaisePropertyChanged("sg_name", ModelEntityUpdated);
                }
            }
        }

        private string _seller_name;
        public string seller_name
        {
            get { return _seller_name; }
            set
            {
                if (_seller_name != value)
                {
                    _seller_name = value; RaisePropertyChanged("seller_name", ModelEntityUpdated);
                }
            }
        }

        private string _cust_ref;
        public string cust_ref
        {
            get { return _cust_ref; }
            set
            {
                if (_cust_ref != value)
                {
                    _cust_ref = value; RaisePropertyChanged("cust_ref", ModelEntityUpdated);
                }
            }
        }
        private string _party_ref_no;
        public string party_ref_no
        {
            get { return _party_ref_no; }
            set
            {
                if (_party_ref_no != value)
                {
                    _party_ref_no = value; RaisePropertyChanged("party_ref_no", ModelEntityUpdated);
                }
            }
        }
        private DateTime? _party_ref_date;
        public DateTime? party_ref_date
        {
            get { return _party_ref_date; }
            set
            {
                if (_party_ref_date != value)
                {
                    _party_ref_date = value; RaisePropertyChanged("party_ref_date", ModelEntityUpdated);
                }
            }
        }
        private string _EmailId;
        public string EmailId
        {
            get { return _EmailId; }
            set
            {
                if (_EmailId != value)
                {
                    _EmailId = value; RaisePropertyChanged("EmailId", ModelEntityUpdated);
                }
            }
        }
        private string _PersnEmailId;
        public string PersnEmailId
        {
            get { return _PersnEmailId; }
            set
            {
                if (_PersnEmailId != value)
                {
                    _PersnEmailId = value; RaisePropertyChanged("PersnEmailId", ModelEntityUpdated);
                }
            }
        }

        private string _country_nm;
        public string country_nm
        {
            get { return _country_nm; }
            set
            {
                if (_country_nm != value)
                {
                    _country_nm = value; RaisePropertyChanged("country_nm");
                }
            }
        }

        private string _state_nm;
        public string state_nm
        {
            get { return _state_nm; }
            set
            {
                if (_state_nm != value)
                {
                    _state_nm = value; RaisePropertyChanged("state_nm");
                }
            }
        }

        private string _pincode;
        public string pincode
        {
            get { return _pincode; }
            set
            {
                if (_pincode != value)
                {
                    _pincode = value; RaisePropertyChanged("pincode", ModelEntityUpdated);
                }
            }
        }
        private Nullable<decimal> _order_limit;
        public Nullable<decimal> order_limit
        {
            get { return _order_limit; }
            set
            {
                if (_order_limit != value)
                {
                    _order_limit = value; RaisePropertyChanged("order_limit");
                }
            }
        }

        private Nullable<decimal> _net_value;
        public Nullable<decimal> net_value
        {
            get { return _net_value; }
            set
            {
                if (_net_value != value)
                {
                    _net_value = value; RaisePropertyChanged("net_value");
                }
            }
        }

        private string _withholding_tax;
        public string withholding_tax
        {
            get { return _withholding_tax; }
            set
            {
                if (_withholding_tax != value)
                {
                    _withholding_tax = value;
                    RaisePropertyChanged("withholding_tax", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _withholding_value;
        public Nullable<decimal> withholding_value
        {
            get { return _withholding_value; }
            set
            {
                if (_withholding_value != value)
                {
                    _withholding_value = value; RaisePropertyChanged("withholding_value");
                }
            }
        }

        private Nullable<decimal> _withholding_ex_amt;
        public Nullable<decimal> withholding_ex_amt
        {
            get { return _withholding_ex_amt; }
            set
            {
                if (_withholding_ex_amt != value)
                {
                    _withholding_ex_amt = value; RaisePropertyChanged("withholding_ex_amt");
                }
            }
        }

        private Nullable<decimal> _local_tax_amount;
        public Nullable<decimal> local_tax_amount
        {
            get { return _local_tax_amount; }
            set
            {
                if (_local_tax_amount != value)
                {
                    _local_tax_amount = value; RaisePropertyChanged("local_tax_amount");
                }
            }
        }

        private Nullable<decimal> _local_sub_total;
        public Nullable<decimal> local_sub_total
        {
            get { return _local_sub_total; }
            set
            {
                if (_local_sub_total != value)
                {
                    _local_sub_total = value; RaisePropertyChanged("local_sub_total");
                }
            }
        }

        private Nullable<decimal> _local_discount;
        public Nullable<decimal> local_discount
        {
            get { return _local_discount; }
            set
            {
                if (_local_discount != value)
                {
                    _local_discount = value; RaisePropertyChanged("local_discount");
                }
            }
        }

        private Nullable<decimal> _local_ass_value;
        public Nullable<decimal> local_ass_value
        {
            get { return _local_ass_value; }
            set
            {
                if (_local_ass_value != value)
                {
                    _local_ass_value = value; RaisePropertyChanged("local_ass_value");
                }
            }
        }

        private Nullable<decimal> _local_invoice_amt;
        public Nullable<decimal> local_invoice_amt
        {
            get { return _local_invoice_amt; }
            set
            {
                if (_local_invoice_amt != value)
                {
                    _local_invoice_amt = value; RaisePropertyChanged("local_invoice_amt");
                }
            }
        }

        private Nullable<decimal> _local_net_value;
        public Nullable<decimal> local_net_value
        {
            get { return _local_net_value; }
            set
            {
                if (_local_net_value != value)
                {
                    _local_net_value = value; RaisePropertyChanged("local_net_value");
                }
            }
        }

        private Nullable<decimal> _local_round_up;
        public Nullable<decimal> local_round_up
        {
            get { return _local_round_up; }
            set
            {
                if (_local_round_up != value)
                {
                    _local_round_up = value; RaisePropertyChanged("local_round_up");
                }
            }
        }

        private Nullable<decimal> _local_roundup_total;
        public Nullable<decimal> local_roundup_total
        {
            get { return _local_roundup_total; }
            set
            {
                if (_local_roundup_total != value)
                {
                    _local_roundup_total = value; RaisePropertyChanged("local_roundup_total");
                }
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
                if (_other_charges != value)
                {
                    _other_charges = value; RaisePropertyChanged("other_charges");
                }
            }
        }
        private Nullable<System.DateTime> _inv_due_date;
        public Nullable<System.DateTime> inv_due_date
        {
            get { return _inv_due_date; }
            set
            {
                if (_inv_due_date != value)
                {
                    _inv_due_date = value;
                    RaisePropertyChanged("inv_due_date");
                }
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
                if (_gross_value != value)
                {
                    _gross_value = value; RaisePropertyChanged("gross_value");
                }
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
                if (_effective_value != value)
                {
                    _effective_value = value; RaisePropertyChanged("effective_value");
                }
            }
        }

        private string _acc_group;
        public string acc_group
        {
            get
            {
                return _acc_group;
            }

            set
            {
                if (_acc_group != value)
                {
                    _acc_group = value; RaisePropertyChanged("acc_group");
                }
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
                if (_recon_acc != value)
                {
                    _recon_acc = value; RaisePropertyChanged("recon_acc");
                }
            }
        }

        private string _duty_drawback;
        public string duty_drawback
        {
            get
            {
                return _duty_drawback;
            }

            set
            {
                if (_duty_drawback != value)
                {
                    _duty_drawback = value; RaisePropertyChanged("duty_drawback");
                }
            }
        }

        private decimal? _export_commision;
        public decimal? export_commision
        {
            get
            {
                return _export_commision;
            }

            set
            {
                if (_export_commision != value)
                {
                    _export_commision = value; RaisePropertyChanged("export_commision");
                }
            }
        }

        private decimal? _export_commision_val;
        public decimal? export_commision_val
        {
            get
            {
                return _export_commision_val;
            }

            set
            {
                if (_export_commision_val != value)
                {
                    _export_commision_val = value; RaisePropertyChanged("export_commision_val");
                }
            }
        }

        private string _meis;
        public string meis
        {
            get
            {
                return _meis;
            }

            set
            {
                if (_meis != value)
                {
                    _meis = value; RaisePropertyChanged("meis");
                }
            }
        }

        private string _lc_info;
        public string lc_info
        {
            get
            {
                return _lc_info;
            }

            set
            {
                if (_lc_info != value)
                {
                    _lc_info = value; RaisePropertyChanged("lc_info");
                }
            }
        }

        private string _awb_no;
        public string awb_no
        {
            get
            {
                return _awb_no;
            }

            set
            {
                if (_awb_no != value)
                {
                    _awb_no = value; RaisePropertyChanged("awb_no");
                }
            }
        }

        private Nullable<System.DateTime> _awb_date;
        public Nullable<System.DateTime> awb_date
        {
            get { return _awb_date; }
            set
            {
                if (_awb_date != value)
                {
                    _awb_date = value; RaisePropertyChanged("awb_date");
                }
            }
        }

        private string _custom_inv_no;
        public string custom_inv_no
        {
            get
            {
                return _custom_inv_no;
            }

            set
            {
                if (_custom_inv_no != value)
                {
                    _custom_inv_no = value; RaisePropertyChanged("custom_inv_no");
                }
            }
        }

        private string _proforma_inv_no;
        public string proforma_inv_no
        {
            get
            {
                return _proforma_inv_no;
            }

            set
            {
                if (_proforma_inv_no != value)
                {
                    _proforma_inv_no = value; RaisePropertyChanged("proforma_inv_no");
                }
            }
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
                if (_gst_PartyId != value)
                {
                    _gst_PartyId = value; RaisePropertyChanged("gst_PartyId");
                }
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
                if (_plc_name != value)
                {
                    _plc_name = value; RaisePropertyChanged("plc_name");
                }
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
                if (_ref_gst_PartyId != value)
                {
                    _ref_gst_PartyId = value; RaisePropertyChanged("ref_gst_PartyId");
                }
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
                if (_ref_buss_place != value)
                {
                    _ref_buss_place = value; RaisePropertyChanged("ref_buss_place");
                }
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
            set
            {
                if (_data1 != value)
                {
                    _data1 = value; RaisePropertyChanged("data1", ModelEntityUpdated);
                }
            }
        }
        private string _language;
        public string language
        {
            get { return _language; }
            set
            {
                if (_language != value)
                {
                    _language = value; RaisePropertyChanged("language");
                }
            }
        }
        //private string _client;
        //public string client
        //{
        //    get { return _client; }
        //    set
        //    {
        //        if (_client != value)
        //        {
        //            _client = value; RaisePropertyChanged("client");
        //        }
        //    }
        //}

        public bool? order_limit_tax { get; set; }
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
        private string _report_declr;
        public string report_declr
        {
            get { return _report_declr; }
            set
            {
                if (_report_declr != value)
                {
                    _report_declr = value; RaisePropertyChanged("report_declr");
                }
            }
        }
        private string _declaration;
        public string declaration
        {
            get { return _declaration; }
            set
            {
                if (_declaration != value)
                {
                    _declaration = value; RaisePropertyChanged("declaration");
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

        
        private string _add_code_del;
        public string add_code_del
        {
            get { return _add_code_del; }
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
            get { return _add_code_bil; }
            set
            {
                if (_add_code_bil != value)
                {
                    _add_code_bil = value; RaisePropertyChanged("add_code_bil");
                }
            }
        }
        private DateTime? _rev_date;
        public DateTime? rev_date
        {
            get { return _rev_date; }
            set
            {
                if (_rev_date != value)
                {
                    _rev_date = value; RaisePropertyChanged("rev_date");
                }
            }
        }
        private string _emp_id;
        public string emp_id
        {
            get { return _emp_id; }
            set
            {
                if (_emp_id != value)
                {
                    _emp_id = value; RaisePropertyChanged("emp_id");
                }
            }
        }
        private string _cp_code;
        public string cp_code
        {
            get { return _cp_code; }
            set
            {
                if (_cp_code != value)
                {
                    _cp_code = value; RaisePropertyChanged("cp_code");
                }
            }
        }
        private string _pt_code;
        public string pt_code
        {
            get { return _pt_code; }
            set
            {
                if (_pt_code != value)
                {
                    _pt_code = value; RaisePropertyChanged("pt_code");
                }
            }
        }
        private string _ind_post;
        public string ind_post
        {
            get { return _ind_post; }
            set
            {
                if (_ind_post != value)
                {
                    _ind_post = value; RaisePropertyChanged("ind_post");
                }
            }
        }
        private string _plan_no;
        public string plan_no
        {
            get { return _plan_no; }
            set
            {
                if (_plan_no != value)
                {
                    _plan_no = value; RaisePropertyChanged("plan_no");
                }
            }
        }

        // Scalar Fields
        private string _pt_name;
        public string pt_name
        {
            get { return _pt_name; }
            set
            {
                if (_pt_name != value)
                {
                    _pt_name = value; RaisePropertyChanged("pt_name");
                }
            }
        }
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
        private string _notify_party_name;
        public string notify_party_name
        {
            get
            {
                return _notify_party_name;
            }

            set
            {
                if (_notify_party_name != value)
                {
                    _notify_party_name = value; RaisePropertyChanged("notify_party_name", ModelEntityUpdated);
                }
            }
        }
        private string _notify_party_name2;
        public string notify_party_name2
        {
            get
            {
                return _notify_party_name2;
            }

            set
            {
                if (_notify_party_name2 != value)
                {
                    _notify_party_name2 = value; RaisePropertyChanged("notify_party_name2", ModelEntityUpdated);
                }
            }
        }

        private string _micr_code;
        public string micr_code
        {
            get { return _micr_code; }
            set { if (_micr_code != value) { _micr_code = value; RaisePropertyChanged("micr_code"); } }
        }
        private string _acc_no;
        public string acc_no
        {
            get { return _acc_no; }
            set { if (_acc_no != value) { _acc_no = value; RaisePropertyChanged("acc_no"); } }
        }
        private string _acc_name;
        public string acc_name
        {
            get { return _acc_name; }
            set { if (_acc_name != value) { _acc_name = value; RaisePropertyChanged("acc_name"); } }
        }
        private string _ad_code;
        public string ad_code
        {
            get { return _ad_code; }
            set { if (_ad_code != value) { _ad_code = value; RaisePropertyChanged("ad_code"); } }
        }
        private string _acc_type;
        public string acc_type
        {
            get { return _acc_type; }
            set { if (_acc_type != value) { _acc_type = value; RaisePropertyChanged("acc_type"); } }
        }
        private string _iban_no;
        public string iban_no
        {
            get { return _iban_no; }
            set { if (_iban_no != value) { _iban_no = value; RaisePropertyChanged("iban_no"); } }
        }
        private string _ifsccode;
        public string ifsccode
        {
            get { return _ifsccode; }
            set
            {
                if (_ifsccode != value)
                {
                    _ifsccode = value; RaisePropertyChanged("ifsccode", ModelEntityUpdated);
                }
            }
        }
        private string _tax_reg_no_da;
        public string tax_reg_no_da
        {
            get { return _tax_reg_no_da; }
            set
            {
                if (_tax_reg_no_da != value)
                {
                    _tax_reg_no_da = value; RaisePropertyChanged("tax_reg_no_da");
                }
            }
        }
        private string _tax_reg_date;
        public string tax_reg_date
        {
            get { return _tax_reg_date; }
            set
            {
                if (_tax_reg_date != value)
                {
                    _tax_reg_date = value; RaisePropertyChanged("tax_reg_date");
                }
            }
        }
        private string _tax_reg_no_ba;
        public string tax_reg_no_ba
        {
            get { return _tax_reg_no_ba; }
            set
            {
                if (_tax_reg_no_ba != value)
                {
                    _tax_reg_no_ba = value; RaisePropertyChanged("tax_reg_no_ba");
                }
            }
        }

        
        private string _emp_name;
        public string emp_name
        {
            get { return _emp_name; }
            set
            {
                if (_emp_name != value)
                {
                    _emp_name = value; RaisePropertyChanged("emp_name");
                }
            }
        }
        
        private string _cp_name;
        public string cp_name
        {
            get { return _cp_name; }
            set
            {
                if (_cp_name != value)
                {
                    _cp_name = value; RaisePropertyChanged("cp_name");
                }
            }
        }
        private string _cp_email;
        public string cp_email
        {
            get { return _cp_email; }
            set
            {
                if (_cp_email != value)
                {
                    _cp_email = value; RaisePropertyChanged("cp_email");
                }
            }
        }
        private string _cp_mobile;
        public string cp_mobile
        {
            get { return _cp_mobile; }
            set
            {
                if (_cp_mobile != value)
                {
                    _cp_mobile = value; RaisePropertyChanged("cp_mobile");
                }
            }
        }
        private string _cp_phone;
        public string cp_phone
        {
            get { return _cp_phone; }
            set
            {
                if (_cp_phone != value)
                {
                    _cp_phone = value; RaisePropertyChanged("cp_phone");
                }
            }
        }
        private string _pt_text;
        public string pt_text
        {
            get { return _pt_text; }
            set
            {
                if (_pt_text != value)
                {
                    _pt_text = value; RaisePropertyChanged("pt_text");
                }
            }
        }

        public string ind_tcs { get; set; }
        public string party_code { get; set; }
        public string party_code_del { get; set; }
        public string party_code_bil { get; set; }
        public string vendor_code { get; set; }
        public string party_name { get; set; }
        public string ship_to_party_name { get; set; }
        public string place_name { get; set; }
        public DateTime? supply_date { get; set; }
        public string qr_code { get; set; }
        public byte[] qr_image { get; set; }
        public string print_option { get; set; }
        public string XDOC_TC { get; set; }
        public string reg_no { get; set; }

    }
    public class SEL_T003_A : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        
        private string _party_ref_no;
        public string party_ref_no
        {
            get { return _party_ref_no; }
            set
            {
                if (_party_ref_no != value)
                {
                    _party_ref_no = value; RaisePropertyChanged("party_ref_no");
                }
            }
        }

        private DateTime? _party_ref_date;
        public DateTime? party_ref_date
        {
            get { return _party_ref_date; }
            set
            {
                if (_party_ref_date != value)
                {
                    _party_ref_date = value; RaisePropertyChanged("party_ref_date");
                }
            }
        }

        private Nullable<System.DateTime> _cust_po_date;
        public Nullable<System.DateTime> cust_po_date
        {
            get { return _cust_po_date; }
            set
            {
                if (_cust_po_date != value)
                {
                    _cust_po_date = value; RaisePropertyChanged("cust_po_date");
                }
            }
        }

        private string _cust_po_no;
        public string cust_po_no
        {
            get { return _cust_po_no; }
            set
            {
                if (_cust_po_no != value)
                {
                    _cust_po_no = value; RaisePropertyChanged("cust_po_no");
                }
            }
        }

        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value; RaisePropertyChanged("id");
                }
            }
        }
        private string _symbol;
        public string symbol
        {
            get { return _symbol; }
            set
            {
                if (_symbol != value)
                {
                    _symbol = value; RaisePropertyChanged("symbol", ModelEntityUpdated);
                }
            }
        }
        private string _bill_doc;
        public string bill_doc
        {
            get { return _bill_doc; }
            set
            {
                if (_bill_doc != value)
                {
                    _bill_doc = value; RaisePropertyChanged("bill_doc", ModelEntityUpdated);
                }
            }
        }
        private int _line_id;
        public int line_id
        {
            get { return _line_id; }
            set
            {
                if (_line_id != value)
                {
                    _line_id = value; RaisePropertyChanged("line_id", ModelEntityUpdated);
                }
            }
        }
        private string _ItemCode;
        [Required(ErrorMessage = "Field 'Item' is required.")]
        public string ItemCode
        {
            get { return _ItemCode; }
            set
            {
                if (_ItemCode != value)
                {
                    _ItemCode = value; RaisePropertyChanged("ItemCode", ModelEntityUpdated);
                }
            }
        }
        private string _item_desc;
        public string item_desc
        {
            get { return _item_desc; }
            set
            {
                if (_item_desc != value)
                {
                    _item_desc = value; RaisePropertyChanged("item_desc", ModelEntityUpdated);
                }
            }
        }
        private Nullable<decimal> _qty;
        [Required(ErrorMessage = "Field 'Quantity' is required.")]
        public Nullable<decimal> qty
        {
            get { return _qty; }
            set
            {
                if (_qty != value)
                {
                    _qty = value; RaisePropertyChanged("qty", ModelEntityUpdated);
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
                    _unit_code = value; RaisePropertyChanged("unit_code", ModelEntityUpdated);
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
                    _sku = value; RaisePropertyChanged("sku", ModelEntityUpdated);
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
                    _sku_desc = value; RaisePropertyChanged("sku_desc", ModelEntityUpdated);
                }
            }
        }
        private Nullable<decimal> _unit_price;
        [Required(ErrorMessage = "Field 'Unit Price' is required.")]
        public Nullable<decimal> unit_price
        {
            get { return _unit_price; }
            set
            {
                if (_unit_price != value)
                {
                    _unit_price = value; RaisePropertyChanged("unit_price", ModelEntityUpdated);
                }
            }
        }
        private Nullable<decimal> _conv_fact;
        public Nullable<decimal> conv_fact
        {
            get { return _conv_fact; }
            set
            {
                if (_conv_fact != value)
                {
                    _conv_fact = value; RaisePropertyChanged("conv_fact", ModelEntityUpdated);
                }
            }
        }
        private string _uom_base_cd;
        public string uom_base_cd
        {
            get { return _uom_base_cd; }
            set
            {
                if (_uom_base_cd != value)
                {
                    _uom_base_cd = value; RaisePropertyChanged("uom_base_cd", ModelEntityUpdated);
                }
            }
        }
        private Nullable<decimal> _qty_base_uom;
        public Nullable<decimal> qty_base_uom
        {
            get { return _qty_base_uom; }
            set
            {
                if (_qty_base_uom != value)
                {
                    _qty_base_uom = value; RaisePropertyChanged("qty_base_uom", ModelEntityUpdated);
                }
            }
        }
        private Nullable<decimal> _wt_net;
        public Nullable<decimal> wt_net
        {
            get { return _wt_net; }
            set
            {
                if (_wt_net != value)
                {
                    _wt_net = value; RaisePropertyChanged("wt_net", ModelEntityUpdated);
                }
            }
        }
        private Nullable<decimal> _wt_gross;
        public Nullable<decimal> wt_gross
        {
            get { return _wt_gross; }
            set
            {
                if (_wt_gross != value)
                {
                    _wt_gross = value; RaisePropertyChanged("wt_gross", ModelEntityUpdated);
                }
            }
        }
        private Nullable<decimal> _gross_wt;
        public Nullable<decimal> gross_wt
        {
            get
            {
                return _gross_wt;
            }
            set
            {
                if (_gross_wt != value)
                {
                    _gross_wt = value; RaisePropertyChanged("gross_wt", ModelEntityUpdated);

                }
            }
        }
        private Nullable<decimal> _net_wt;
        public Nullable<decimal> net_wt
        {
            get
            {
                return _net_wt;
            }
            set
            {
                if (_net_wt != value)
                {
                    _net_wt = value; RaisePropertyChanged("net_wt", ModelEntityUpdated);

                }
            }
        }


        private Nullable<decimal> _volume;
        public Nullable<decimal> volume
        {
            get { return _volume; }
            set
            {
                if (_volume != value)
                {
                    _volume = value; RaisePropertyChanged("volume", ModelEntityUpdated);
                }
            }
        }
        private string _weight_unit;
        public string weight_unit
        {
            get { return _weight_unit; }
            set
            {
                if (_weight_unit != value)
                {
                    _weight_unit = value; RaisePropertyChanged("weight_unit", ModelEntityUpdated);
                }
            }
        }
        private string _volume_unit;
        public string volume_unit
        {
            get { return _volume_unit; }
            set
            {
                if (_volume_unit != value)
                {
                    _volume_unit = value; RaisePropertyChanged("volume_unit", ModelEntityUpdated);
                }
            }
        }
        private string _buss_area;
        public string buss_area
        {
            get { return _buss_area; }
            set
            {
                if (_buss_area != value)
                {
                    _buss_area = value; RaisePropertyChanged("buss_area", ModelEntityUpdated);
                }
            }
        }
        private Nullable<System.DateTime> _price_date;
        public Nullable<System.DateTime> price_date
        {
            get { return _price_date; }
            set
            {
                if (_price_date != value)
                {
                    _price_date = value; RaisePropertyChanged("price_date", ModelEntityUpdated);
                }
            }
        }
        private Nullable<System.DateTime> _serv_date;
        public Nullable<System.DateTime> serv_date
        {
            get { return _serv_date; }
            set
            {
                if (_serv_date != value)
                {
                    _serv_date = value; RaisePropertyChanged("serv_date", ModelEntityUpdated);
                }
            }
        }
        private Nullable<decimal> _exch_rate;
        public Nullable<decimal> exch_rate
        {
            get { return _exch_rate; }
            set
            {
                if (_exch_rate != value)
                {
                    _exch_rate = value; RaisePropertyChanged("exch_rate", ModelEntityUpdated);
                }
            }
        }
        private Nullable<decimal> _net_value;
        public Nullable<decimal> net_value
        {
            get { return _net_value; }
            set
            {
                if (_net_value != value)
                {
                    _net_value = value; RaisePropertyChanged("net_value", ModelEntityUpdated);
                }
            }
        }
        private string _tax_id;
        public string tax_id
        {
            get { return _tax_id; }
            set
            {
                if (_tax_id != value)
                {
                    _tax_id = value; RaisePropertyChanged("tax_id", ModelEntityUpdated);
                }
            }
        }
        private Nullable<decimal> _tax_amt;
        public Nullable<decimal> tax_amt
        {
            get { return _tax_amt; }
            set
            {
                if (_tax_amt != value)
                {
                    _tax_amt = value; RaisePropertyChanged("tax_amt", ModelEntityUpdated);
                }
            }
        }
        private Nullable<decimal> _subtotal;
        public Nullable<decimal> subtotal
        {
            get { return _subtotal; }
            set
            {
                if (_subtotal != value)
                {
                    _subtotal = value; RaisePropertyChanged("subtotal", ModelEntityUpdated);
                }
            }
        }
        private Nullable<decimal> _gross_value;
        public Nullable<decimal> gross_value
        {
            get { return _gross_value; }
            set
            {
                if (_gross_value != value)
                {
                    _gross_value = value; RaisePropertyChanged("gross_value", ModelEntityUpdated);
                }
            }
        }
        private string _org_doc;
        public string org_doc
        {
            get { return _org_doc; }
            set
            {
                if (_org_doc != value)
                {
                    _org_doc = value; RaisePropertyChanged("org_doc", ModelEntityUpdated);
                }
            }
        }
        private string _org_item_cd;
        public string org_item_cd
        {
            get { return _org_item_cd; }
            set
            {
                if (_org_item_cd != value)
                {
                    _org_item_cd = value; RaisePropertyChanged("org_item_cd", ModelEntityUpdated);
                }
            }
        }
        private string _ref_doc_type;
        public string ref_doc_type
        {
            get { return _ref_doc_type; }
            set
            {
                if (_ref_doc_type != value)
                {
                    _ref_doc_type = value; RaisePropertyChanged("ref_doc_type", ModelEntityUpdated);
                }
            }
        }
        private string _ref_item_cd;
        public string ref_item_cd
        {
            get { return _ref_item_cd; }
            set
            {
                if (_ref_item_cd != value)
                {
                    _ref_item_cd = value; RaisePropertyChanged("ref_item_cd", ModelEntityUpdated);
                }
            }
        }
        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set
            {
                if (_doc_cat != value)
                {
                    _doc_cat = value; RaisePropertyChanged("doc_cat", ModelEntityUpdated);
                }
            }
        }
        private string _sd_doc;
        public string sd_doc
        {
            get { return _sd_doc; }
            set
            {
                if (_sd_doc != value)
                {
                    _sd_doc = value; RaisePropertyChanged("sd_doc", ModelEntityUpdated);
                }
            }
        }
        private string _sd_item_cd;
        public string sd_item_cd
        {
            get { return _sd_item_cd; }
            set
            {
                if (_sd_item_cd != value)
                {
                    _sd_item_cd = value; RaisePropertyChanged("sd_item_cd", ModelEntityUpdated);
                }
            }
        }
        private string _sd_ref_doc;
        public string sd_ref_doc
        {
            get { return _sd_ref_doc; }
            set
            {
                if (_sd_ref_doc != value)
                {
                    _sd_ref_doc = value; RaisePropertyChanged("sd_ref_doc", ModelEntityUpdated);
                }
            }
        }
        private string _batch;
        public string batch
        {
            get { return _batch; }
            set
            {
                if (_batch != value)
                {
                    _batch = value; RaisePropertyChanged("batch", ModelEntityUpdated);
                }
            }
        }
        private string _item_cat;
        public string item_cat
        {
            get { return _item_cat; }
            set
            {
                if (_item_cat != value)
                {
                    _item_cat = value; RaisePropertyChanged("item_cat", ModelEntityUpdated);
                }
            }
        }
        private string _item_type;
        public string item_type
        {
            get { return _item_type; }
            set
            {
                if (_item_type != value)
                {
                    _item_type = value; RaisePropertyChanged("item_type", ModelEntityUpdated);
                }
            }
        }
        private string _ship_rec_point;
        public string ship_rec_point
        {
            get { return _ship_rec_point; }
            set
            {
                if (_ship_rec_point != value)
                {
                    _ship_rec_point = value; RaisePropertyChanged("ship_rec_point", ModelEntityUpdated);
                }
            }
        }
        private string _replace_part;
        public string replace_part
        {
            get { return _replace_part; }
            set
            {
                if (_replace_part != value)
                {
                    _replace_part = value; RaisePropertyChanged("replace_part", ModelEntityUpdated);
                }
            }
        }
        private string _div_code;
        public string div_code
        {
            get { return _div_code; }
            set
            {
                if (_div_code != value)
                {
                    _div_code = value; RaisePropertyChanged("div_code", ModelEntityUpdated);
                }
            }
        }
        private string _country_code;
        public string country_code
        {
            get { return _country_code; }
            set
            {
                if (_country_code != value)
                {
                    _country_code = value; RaisePropertyChanged("country_code", ModelEntityUpdated);
                }
            }
        }
        private string _region;
        public string region
        {
            get { return _region; }
            set
            {
                if (_region != value)
                {
                    _region = value; RaisePropertyChanged("region", ModelEntityUpdated);
                }
            }
        }
        private string _located_country;
        public string located_country
        {
            get { return _located_country; }
            set
            {
                if (_located_country != value)
                {
                    _located_country = value; RaisePropertyChanged("located_country", ModelEntityUpdated);
                }
            }
        }
        private string _city;
        public string city
        {
            get { return _city; }
            set
            {
                if (_city != value)
                {
                    _city = value; RaisePropertyChanged("city", ModelEntityUpdated);
                }
            }
        }
        private string _tax_class1;
        public string tax_class1
        {
            get { return _tax_class1; }
            set
            {
                if (_tax_class1 != value)
                {
                    _tax_class1 = value; RaisePropertyChanged("tax_class1", ModelEntityUpdated);
                }
            }
        }
        private string _tax_class2;
        public string tax_class2
        {
            get { return _tax_class2; }
            set
            {
                if (_tax_class2 != value)
                {
                    _tax_class2 = value; RaisePropertyChanged("tax_class2", ModelEntityUpdated);
                }
            }
        }
        private string _tax_class3;
        public string tax_class3
        {
            get { return _tax_class3; }
            set
            {
                if (_tax_class3 != value)
                {
                    _tax_class3 = value; RaisePropertyChanged("tax_class3", ModelEntityUpdated);
                }
            }
        }
        private string _hsn_code;
        public string hsn_code
        {
            get { return _hsn_code; }
            set
            {
                if (_hsn_code != value)
                {
                    _hsn_code = value; RaisePropertyChanged("hsn_code");
                }
            }
        }
        private string _hsn_code2;
        public string hsn_code2
        {
            get { return _hsn_code2; }
            set
            {
                if (_hsn_code2 != value)
                {
                    _hsn_code2 = value; RaisePropertyChanged("hsn_code2");
                }
            }
        }
        private string _cash_dis;
        public string cash_dis
        {
            get { return _cash_dis; }
            set
            {
                if (_cash_dis != value)
                {
                    _cash_dis = value; RaisePropertyChanged("cash_dis", ModelEntityUpdated);
                }
            }
        }
        private Nullable<decimal> _disc_amt_elig;
        public Nullable<decimal> disc_amt_elig
        {
            get { return _disc_amt_elig; }
            set
            {
                if (_disc_amt_elig != value)
                {
                    _disc_amt_elig = value; RaisePropertyChanged("disc_amt_elig", ModelEntityUpdated);
                }
            }
        }
        private string _acc_assign;
        public string acc_assign
        {
            get { return _acc_assign; }
            set
            {
                if (_acc_assign != value)
                {
                    _acc_assign = value; RaisePropertyChanged("acc_assign", ModelEntityUpdated);
                }
            }
        }
        private string _cost_center;
        public string cost_center
        {
            get { return _cost_center; }
            set
            {
                if (_cost_center != value)
                {
                    _cost_center = value; RaisePropertyChanged("cost_center", ModelEntityUpdated);
                }
            }
        }
        private string _eu_art;
        public string eu_art
        {
            get { return _eu_art; }
            set
            {
                if (_eu_art != value)
                {
                    _eu_art = value; RaisePropertyChanged("eu_art", ModelEntityUpdated);
                }
            }
        }
        private string _sg_code;
        public string sg_code
        {
            get { return _sg_code; }
            set
            {
                if (_sg_code != value)
                {
                    _sg_code = value; RaisePropertyChanged("sg_code", ModelEntityUpdated);
                }
            }
        }
        private string _soff_code;
        public string soff_code
        {
            get { return _soff_code; }
            set
            {
                if (_soff_code != value)
                {
                    _soff_code = value; RaisePropertyChanged("soff_code", ModelEntityUpdated);
                }
            }
        }
        private string _value_type;
        public string value_type
        {
            get { return _value_type; }
            set
            {
                if (_value_type != value)
                {
                    _value_type = value; RaisePropertyChanged("value_type", ModelEntityUpdated);
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
                    _store_code = value; RaisePropertyChanged("store_code", ModelEntityUpdated);
                }
            }
        }
        private Nullable<decimal> _doc_cost;
        public Nullable<decimal> doc_cost
        {
            get { return _doc_cost; }
            set
            {
                if (_doc_cost != value)
                {
                    _doc_cost = value; RaisePropertyChanged("doc_cost", ModelEntityUpdated);
                }
            }
        }
        private string _art_no;
        public string art_no
        {
            get { return _art_no; }
            set
            {
                if (_art_no != value)
                {
                    _art_no = value; RaisePropertyChanged("art_no", ModelEntityUpdated);
                }
            }
        }
        private string _profit_center;
        public string profit_center
        {
            get { return _profit_center; }
            set
            {
                if (_profit_center != value)
                {
                    _profit_center = value; RaisePropertyChanged("profit_center", ModelEntityUpdated);
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
                    _order_no = value; RaisePropertyChanged("order_no", ModelEntityUpdated);
                }
            }
        }
        private string _tax_juri;
        public string tax_juri
        {
            get { return _tax_juri; }
            set
            {
                if (_tax_juri != value)
                {
                    _tax_juri = value; RaisePropertyChanged("tax_juri", ModelEntityUpdated);
                }
            }
        }
        private string _batch_split;
        public string batch_split
        {
            get { return _batch_split; }
            set
            {
                if (_batch_split != value)
                {
                    _batch_split = value; RaisePropertyChanged("batch_split", ModelEntityUpdated);
                }
            }
        }
        private string _dest_con_so;
        public string dest_con_so
        {
            get { return _dest_con_so; }
            set
            {
                if (_dest_con_so != value)
                {
                    _dest_con_so = value; RaisePropertyChanged("dest_con_so", ModelEntityUpdated);
                }
            }
        }
        private string _so_region;
        public string so_region
        {
            get { return _so_region; }
            set
            {
                if (_so_region != value)
                {
                    _so_region = value; RaisePropertyChanged("so_region", ModelEntityUpdated);
                }
            }
        }

        private string _so_code;
        public string so_code
        {
            get { return _so_code; }
            set
            {
                if (_so_code != value)
                {
                    _so_code = value; RaisePropertyChanged("so_code", ModelEntityUpdated);
                }
            }
        }
        private string _dc_code;
        public string dc_code
        {
            get { return _dc_code; }
            set
            {
                if (_dc_code != value)
                {
                    _dc_code = value; RaisePropertyChanged("dc_code", ModelEntityUpdated);
                }
            }
        }
        private string _sd_doc_cat;
        public string sd_doc_cat
        {
            get { return _sd_doc_cat; }
            set
            {
                if (_sd_doc_cat != value)
                {
                    _sd_doc_cat = value; RaisePropertyChanged("sd_doc_cat", ModelEntityUpdated);
                }
            }
        }
        private Nullable<decimal> _credit_price;
        public Nullable<decimal> credit_price
        {
            get { return _credit_price; }
            set
            {
                if (_credit_price != value)
                {
                    _credit_price = value; RaisePropertyChanged("credit_price", ModelEntityUpdated);
                }
            }
        }
        private string _credit_ind;
        public string credit_ind
        {
            get { return _credit_ind; }
            set
            {
                if (_credit_ind != value)
                {
                    _credit_ind = value; RaisePropertyChanged("credit_ind", ModelEntityUpdated);
                }
            }
        }
        private string _pay_gua;
        public string pay_gua
        {
            get { return _pay_gua; }
            set
            {
                if (_pay_gua != value)
                {
                    _pay_gua = value; RaisePropertyChanged("pay_gua", ModelEntityUpdated);
                }
            }
        }
        private string _value_con;
        public string value_con
        {
            get { return _value_con; }
            set
            {
                if (_value_con != value)
                {
                    _value_con = value; RaisePropertyChanged("value_con", ModelEntityUpdated);
                }
            }
        }
        private string _cont_ItemCode;
        public string cont_ItemCode
        {
            get { return _cont_ItemCode; }
            set
            {
                if (_cont_ItemCode != value)
                {
                    _cont_ItemCode = value; RaisePropertyChanged("cont_ItemCode", ModelEntityUpdated);
                }
            }
        }
        private string _cont_no;
        public string cont_no
        {
            get { return _cont_no; }
            set
            {
                if (_cont_no != value)
                {
                    _cont_no = value; RaisePropertyChanged("cont_no", ModelEntityUpdated);
                }
            }
        }
        private Nullable<decimal> _lc_exch_rate;
        public Nullable<decimal> lc_exch_rate
        {
            get { return _lc_exch_rate; }
            set
            {
                if (_lc_exch_rate != value)
                {
                    _lc_exch_rate = value; RaisePropertyChanged("lc_exch_rate", ModelEntityUpdated);
                }
            }
        }
        private string _ref_doc_no;
        public string ref_doc_no
        {
            get { return _ref_doc_no; }
            set
            {
                if (_ref_doc_no != value)
                {
                    _ref_doc_no = value; RaisePropertyChanged("ref_doc_no", ModelEntityUpdated);
                }
            }
        }
        private string _ref_doc_item_cd;
        public string ref_doc_item_cd
        {
            get { return _ref_doc_item_cd; }
            set
            {
                if (_ref_doc_item_cd != value)
                {
                    _ref_doc_item_cd = value; RaisePropertyChanged("ref_doc_item_cd", ModelEntityUpdated);
                }
            }
        }
        private string _curr_code;
        public string curr_code
        {
            get { return _curr_code; }
            set
            {
                if (_curr_code != value)
                {
                    _curr_code = value; RaisePropertyChanged("curr_code", ModelEntityUpdated);
                }
            }
        }
        private Nullable<decimal> _loc_rate;
        public Nullable<decimal> loc_rate
        {
            get { return _loc_rate; }
            set
            {
                if (_loc_rate != value)
                {
                    _loc_rate = value; RaisePropertyChanged("loc_rate", ModelEntityUpdated);
                }
            }
        }
        private Nullable<decimal> _loc_amt;
        public Nullable<decimal> loc_amt
        {
            get { return _loc_amt; }
            set
            {
                if (_loc_amt != value)
                {
                    _loc_amt = value; RaisePropertyChanged("loc_amt", ModelEntityUpdated);
                }
            }
        }
        private string _acc_code;
        public string acc_code
        {
            get { return _acc_code; }
            set
            {
                if (_acc_code != value)
                {
                    _acc_code = value; RaisePropertyChanged("acc_code", ModelEntityUpdated);
                }
            }
        }
        private string _grade;
        public string grade
        {
            get { return _grade; }
            set
            {
                if (_grade != value)
                {
                    _grade = value; RaisePropertyChanged("grade", ModelEntityUpdated);
                }
            }
        }
        private Nullable<int> _para1;
        public Nullable<int> para1
        {
            get { return _para1; }
            set
            {
                if (_para1 != value)
                {
                    _para1 = value; RaisePropertyChanged("para1", ModelEntityUpdated);
                }
            }
        }
        private string _para2;
        public string para2
        {
            get { return _para2; }
            set
            {
                if (_para2 != value)
                {
                    _para2 = value; RaisePropertyChanged("para2", ModelEntityUpdated);
                }
            }
        }
        private string _para3;
        public string para3
        {
            get { return _para3; }
            set
            {
                if (_para3 != value)
                {
                    _para3 = value; RaisePropertyChanged("para3", ModelEntityUpdated);
                }
            }
        }
        private string _para4;
        public string para4
        {
            get { return _para4; }
            set
            {
                if (_para4 != value)
                {
                    _para4 = value; RaisePropertyChanged("para4", ModelEntityUpdated);
                }
            }
        }
        private string _para5;
        public string para5
        {
            get { return _para5; }
            set
            {
                if (_para5 != value)
                {
                    _para5 = value; RaisePropertyChanged("para5", ModelEntityUpdated);
                }
            }
        }
        private Nullable<int> _para6;
        public Nullable<int> para6
        {
            get { return _para6; }
            set
            {
                if (_para6 != value)
                {
                    _para6 = value; RaisePropertyChanged("para6", ModelEntityUpdated);
                }
            }
        }
        private string _para7;
        public string para7
        {
            get { return _para7; }
            set
            {
                if (_para7 != value)
                {
                    _para7 = value; RaisePropertyChanged("para7", ModelEntityUpdated);
                }
            }
        }
        private string _para8;
        public string para8
        {
            get { return _para8; }
            set
            {
                if (_para8 != value)
                {
                    _para8 = value; RaisePropertyChanged("para8", ModelEntityUpdated);
                }
            }
        }
        private string _para9;
        public string para9
        {
            get { return _para9; }
            set
            {
                if (_para9 != value)
                {
                    _para9 = value; RaisePropertyChanged("para9", ModelEntityUpdated);
                }
            }
        }
        private string _para10;
        public string para10
        {
            get { return _para10; }
            set
            {
                if (_para10 != value)
                {
                    _para10 = value; RaisePropertyChanged("para10", ModelEntityUpdated);
                }
            }
        }
        private Nullable<int> _no_of_pkgs;
        public Nullable<int> no_of_pkgs
        {
            get { return _no_of_pkgs; }
            set
            {
                if (_no_of_pkgs != value)
                {
                    _no_of_pkgs = value; RaisePropertyChanged("no_of_pkgs", ModelEntityUpdated);
                }
            }
        }
        private string _description;
        public string description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value; RaisePropertyChanged("description", ModelEntityUpdated);
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
                    _t_status = value; RaisePropertyChanged("t_status", ModelEntityUpdated);
                }
            }
        }
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                if (_location_Id != value)
                {
                    _location_Id = value; RaisePropertyChanged("location_Id", ModelEntityUpdated);
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
                    _comp_code = value; RaisePropertyChanged("comp_code", ModelEntityUpdated);
                }
            }
        }
        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set
            {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active", ModelEntityUpdated);
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
                    _add_by = value; RaisePropertyChanged("add_by", ModelEntityUpdated);
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
                    _add_date = value; RaisePropertyChanged("add_date", ModelEntityUpdated);
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
                    _editby = value; RaisePropertyChanged("editby", ModelEntityUpdated);
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
                    _edit_date = value; RaisePropertyChanged("edit_date", ModelEntityUpdated);
                }
            }
        }
        private string _fin_year;
        public string fin_year
        {
            get { return _fin_year; }
            set
            {
                if (_fin_year != value)
                {
                    _fin_year = value; RaisePropertyChanged("fin_year", ModelEntityUpdated);
                }
            }
        }
        private string _posting_period;
        public string posting_period
        {
            get { return _posting_period; }
            set
            {
                if (_posting_period != value)
                {
                    _posting_period = value; RaisePropertyChanged("posting_period", ModelEntityUpdated);
                }
            }
        }
        private string _cust_cat_no;
        public string cust_cat_no
        {
            get { return _cust_cat_no; }
            set
            {
                if (_cust_cat_no != value)
                {
                    _cust_cat_no = value; RaisePropertyChanged("cust_cat_no", ModelEntityUpdated);
                }
            }
        }
        private string _ref_doc_cat;
        public string ref_doc_cat
        {
            get { return _ref_doc_cat; }
            set
            {
                if (_ref_doc_cat != value)
                {
                    _ref_doc_cat = value; RaisePropertyChanged("ref_doc_cat", ModelEntityUpdated);
                }
            }
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
                if (value == null)
                {
                    _discount_type = value; RaisePropertyChanged("discount_type", ModelEntityUpdated);
                }
                else if (_discount_type != (value ?? "P").ToUpper())
                {
                    _discount_type = (value ?? "P").ToUpper(); RaisePropertyChanged("discount_type", ModelEntityUpdated);
                }
            }
        }

        private int _ref_item_line_id;
        public int ref_item_line_id
        {
            get { return _ref_item_line_id; }
            set
            {
                if (_ref_item_line_id != value)
                {
                    _ref_item_line_id = value; RaisePropertyChanged("ref_item_line_id", ModelEntityUpdated);
                }
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
                if (_doc_history_no != value)
                {
                    _doc_history_no = value; RaisePropertyChanged("doc_history_no", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _local_net_value;
        public Nullable<decimal> local_net_value
        {
            get { return _local_net_value; }
            set
            {
                if (_local_net_value != value)
                {
                    _local_net_value = value; RaisePropertyChanged("local_net_value");
                }
            }

        }

        private Nullable<decimal> _local_gross_value;
        public Nullable<decimal> local_gross_value
        {
            get { return _local_gross_value; }
            set
            {
                if (_local_gross_value != value)
                {
                    _local_gross_value = value; RaisePropertyChanged("local_gross_value");
                }
            }

        }

        private Nullable<decimal> _local_subtotal;
        public Nullable<decimal> local_subtotal
        {
            get { return _local_subtotal; }
            set
            {
                if (_local_subtotal != value)
                {
                    _local_subtotal = value; RaisePropertyChanged("local_subtotal");
                }
            }

        }

        private Nullable<decimal> _local_discount;
        public Nullable<decimal> local_discount
        {
            get { return _local_discount; }
            set
            {
                if (_local_discount != value)
                {
                    _local_discount = value; RaisePropertyChanged("local_discount");
                }
            }

        }
        private Nullable<decimal> _effective_value;
        public decimal? effective_value
        {
            get
            {
                return _effective_value;
            }

            set
            {
                if (_effective_value != value)
                {
                    _effective_value = value; RaisePropertyChanged("effective_value");
                }
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
                if (_tax_amount != value)
                {
                    _tax_amount = value; RaisePropertyChanged("tax_amount");
                }
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
                if (_article_no != value)
                {
                    _article_no = value; RaisePropertyChanged("article_no");
                }
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
                if (_bom_no != value)
                {
                    _bom_no = value; RaisePropertyChanged("bom_no");
                }
            }
        }
        private int _ref_item_row_id;
        public int ref_item_row_id
        {
            get
            {
                return _ref_item_row_id;
            }

            set
            {
                if (_ref_item_row_id != value)
                {
                    _ref_item_row_id = value; RaisePropertyChanged("ref_item_row_id");
                }
            }
        }
        private int _sd_line_id;
        public int sd_line_id
        {
            get
            {
                return _sd_line_id;
            }

            set
            {
                if (_sd_line_id != value)
                {
                    _sd_line_id = value; RaisePropertyChanged("sd_line_id");
                }
            }
        }
        private int _sd_row_id;
        public int sd_row_id
        {
            get
            {
                return _sd_row_id;
            }

            set
            {
                if (_sd_row_id != value)
                {
                    _sd_row_id = value; RaisePropertyChanged("sd_row_id");
                }
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
                if (_gl_code != value)
                {
                    _gl_code = value; RaisePropertyChanged("gl_code");
                }
            }
        }
        //scalar
        private Nullable<bool> _StockUnt;
        public Nullable<bool> StockUnt
        {
            get { return _StockUnt; }
            set
            {
                if (_StockUnt != value)
                {
                    _StockUnt = value; RaisePropertyChanged("StockUnt", ModelEntityUpdated);
                }
            }
        }
        private string _SubCatCode;

        public string SubCatCode
        {
            get { return _SubCatCode; }
            set
            {
                if (_SubCatCode != value)
                {
                    _SubCatCode = value; RaisePropertyChanged("SubCatCode", ModelEntityUpdated);
                }
            }
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
                if (_textdata != value)
                {
                    _textdata = value; RaisePropertyChanged("textdata", ModelEntityUpdated);
                }
            }
        }
        private string _acc_group;
        public string acc_group
        {
            get
            {
                return _acc_group;
            }

            set
            {
                if (_acc_group != value)
                {
                    _acc_group = value; RaisePropertyChanged("acc_group");
                }
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
                if (_recon_acc != value)
                {
                    _recon_acc = value; RaisePropertyChanged("recon_acc");
                }
            }
        }

        private string _value_class;
        public string value_class
        {
            get
            {
                return _value_class;
            }

            set
            {
                if (_value_class != value)
                {
                    _value_class = value; RaisePropertyChanged("value_class");
                }
            }
        }

        private string _delivery_no;
        public string delivery_no
        {
            get
            {
                return _delivery_no;
            }

            set
            {
                if (_delivery_no != value)
                {
                    _delivery_no = value; RaisePropertyChanged("delivery_no");
                }
            }
        }

        private int _del_item_row_id;
        public int del_item_row_id
        {
            get
            {
                return _del_item_row_id;
            }

            set
            {
                if (_del_item_row_id != value)
                {
                    _del_item_row_id = value; RaisePropertyChanged("del_item_row_id");
                }
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
                if (_ship_to_Party != value)
                {
                    _ship_to_Party = value; RaisePropertyChanged("ship_to_Party");
                }
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
                if (_ship_to_add != value)
                {
                    _ship_to_add = value; RaisePropertyChanged("ship_to_add");
                }
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
                if (_buss_place != value)
                {
                    _buss_place = value; RaisePropertyChanged("buss_place");
                }
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
                if (_ref_ship_to_Party != value)
                {
                    _ref_ship_to_Party = value; RaisePropertyChanged("ref_ship_to_Party");
                }
            }
        }
        private int _ref_ship_to_add;
        public int ref_ship_to_add
        {
            get
            {
                return _ref_ship_to_add;
            }

            set
            {
                if (_ref_ship_to_add != value)
                {
                    _ref_ship_to_add = value; RaisePropertyChanged("ref_ship_to_add");
                }
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
                if (_ref_buss_place != value)
                {
                    _ref_buss_place = value; RaisePropertyChanged("ref_buss_place");
                }
            }
        }
        private string _language;
        public string language
        {
            get { return _language; }
            set
            {
                if (_language != value)
                {
                    _language = value; RaisePropertyChanged("language");
                }
            }
        }
        
        private string _ProdNm;
        public string ProdNm
        {
            get { return _ProdNm; }
            set
            {
                if (_ProdNm != value)
                {
                    _ProdNm = value; RaisePropertyChanged("ProdNm");
                }
            }
        }
        private string _ProdNmCd;
        public string ProdNmCd
        {
            get { return _ProdNmCd; }
            set
            {
                if (_ProdNmCd != value)
                {
                    _ProdNmCd = value; RaisePropertyChanged("ProdNmCd");
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
        private string _sch_no;
        public string sch_no
        {
            get
            {
                return _sch_no;
            }

            set
            {
                if (_sch_no != value)
                {
                    _sch_no = value; RaisePropertyChanged("sch_no");
                }
            }
        }

        private int _sch_item_row_id;
        public int sch_item_row_id
        {
            get
            {
                return _sch_item_row_id;
            }

            set
            {
                if (_sch_item_row_id != value)
                {
                    _sch_item_row_id = value; RaisePropertyChanged("sch_item_row_id");
                }
            }
        }
        private string _service_doc_no;
        public string service_doc_no
        {
            get
            {
                return _service_doc_no;
            }

            set
            {
                if (_service_doc_no != value)
                {
                    _service_doc_no = value; RaisePropertyChanged("service_doc_no");
                }
            }
        }

        private int _service_item_row_id;
        public int service_item_row_id
        {
            get
            {
                return _service_item_row_id;
            }

            set
            {
                if (_service_item_row_id != value)
                {
                    _service_item_row_id = value; RaisePropertyChanged("service_item_row_id");
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

        private string _item_code_party;
        public string item_code_party
        {
            get { return _item_code_party; }
            set
            {
                if (_item_code_party != value)
                {
                    _item_code_party = value; RaisePropertyChanged("item_code_party");
                }
            }
        }
        private string _item_name_party;
        public string item_name_party
        {
            get { return _item_name_party; }
            set
            {
                if (_item_name_party != value)
                {
                    _item_name_party = value; RaisePropertyChanged("item_name_party");
                }
            }
        }

        private DateTime? _ref_doc_date;
        public DateTime? ref_doc_date
        {
            get { return _ref_doc_date; }
            set
            {
                if (_ref_doc_date != value)
                {
                    _ref_doc_date = value; RaisePropertyChanged("ref_doc_date");
                }
            }
        }
        private string _item_cat_code;
        public string item_cat_code
        {
            get { return _item_cat_code; }
            set
            {
                if (_item_cat_code != value)
                {
                    _item_cat_code = value; RaisePropertyChanged("item_cat_code");
                }
            }
        }
    }
    public class SEL_T003_B : ObjectBase
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
                    _id = value; RaisePropertyChanged("id", ModelEntityUpdated);
                }
            }
        }
        private Nullable<int> _item_row_id;
        public Nullable<int> item_row_id
        {
            get { return _item_row_id; }
            set
            {
                if (_item_row_id != value)
                {
                    _item_row_id = value; RaisePropertyChanged("item_row_id", ModelEntityUpdated);
                }
            }
        }
        private int _tax_id;
        public int tax_id
        {
            get { return _tax_id; }
            set
            {
                if (_tax_id != value)
                {
                    _tax_id = value; RaisePropertyChanged("tax_id", ModelEntityUpdated);
                }
            }
        }

        public string item_code_party { get; set; }
        public string item_name_party { get; set; }
    }
    public class SEL_T003_C : ObjectBase  //Database Table ACC_T006_C
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
                    _id = value; RaisePropertyChanged("id", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _tax_amount;
        public Nullable<decimal> tax_amount
        {
            get { return _tax_amount; }
            set
            {
                if (_tax_amount != value)
                {
                    _tax_amount = value; RaisePropertyChanged("tax_amount", ModelEntityUpdated);
                }
            }
        }
        private Nullable<int> _account_id;
        public Nullable<int> account_id
        {
            get { return _account_id; }
            set
            {
                if (_account_id != value)
                {
                    _account_id = value; RaisePropertyChanged("account_id", ModelEntityUpdated);
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
                    _sequence = value; RaisePropertyChanged("sequence", ModelEntityUpdated);
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
                    _doc_no = value; RaisePropertyChanged("doc_no", ModelEntityUpdated);
                }
            }
        }
        private string _manual;
        public string manual
        {
            get { return _manual; }
            set
            {
                if (_manual != value)
                {
                    _manual = value; RaisePropertyChanged("manual", ModelEntityUpdated);
                }
            }
        }
        private Nullable<decimal> _base_amount;
        public Nullable<decimal> base_amount
        {
            get { return _base_amount; }
            set
            {
                if (_base_amount != value)
                {
                    _base_amount = value; RaisePropertyChanged("base_amount", ModelEntityUpdated);
                }
            }
        }
        private Nullable<decimal> _amount;
        public Nullable<decimal> amount
        {
            get { return _amount; }
            set
            {
                if (_amount != value)
                {
                    _amount = value; RaisePropertyChanged("amount", ModelEntityUpdated);
                }
            }
        }
        private Nullable<decimal> _base;
        public Nullable<decimal> @base
        {
            get { return _base; }
            set
            {
                if (_base != value)
                {
                    _base = value; RaisePropertyChanged("base", ModelEntityUpdated);
                }
            }
        }

        private Nullable<int> _tax_code_id;
        public Nullable<int> tax_code_id
        {
            get { return _tax_code_id; }
            set
            {
                if (_tax_code_id != value)
                {
                    _tax_code_id = value; RaisePropertyChanged("tax_code_id", ModelEntityUpdated);
                }
            }
        }
        private Nullable<int> _account_analytic_id;
        public Nullable<int> account_analytic_id
        {
            get { return _account_analytic_id; }
            set
            {
                if (_account_analytic_id != value)
                {
                    _account_analytic_id = value; RaisePropertyChanged("account_analytic_id", ModelEntityUpdated);
                }
            }
        }
        private Nullable<int> _base_code_id;
        public Nullable<int> base_code_id
        {
            get { return _base_code_id; }
            set
            {
                if (_base_code_id != value)
                {
                    _base_code_id = value; RaisePropertyChanged("base_code_id", ModelEntityUpdated);
                }
            }
        }
        private string _tax_name;
        public string tax_name
        {
            get { return _tax_name; }
            set
            {
                if (_tax_name != value)
                {
                    _tax_name = value; RaisePropertyChanged("tax_name", ModelEntityUpdated);
                }
            }
        }
        private string _gl_code;
        public string gl_code
        {
            get { return _gl_code; }
            set
            {
                if (_gl_code != value)
                {
                    _gl_code = value; RaisePropertyChanged("gl_code", ModelEntityUpdated);
                }
            }
        }
        private string _ItemCode;
        public string ItemCode
        {
            get { return _ItemCode; }
            set
            {
                if (_ItemCode != value)
                {
                    _ItemCode = value; RaisePropertyChanged("ItemCode", ModelEntityUpdated);
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
                    _sku = value; RaisePropertyChanged("sku", ModelEntityUpdated);
                }
            }
        }
        private Nullable<int> _item_row_id;
        public Nullable<int> item_row_id
        {
            get { return _item_row_id; }
            set
            {
                if (_item_row_id != value)
                {
                    _item_row_id = value; RaisePropertyChanged("item_row_id", ModelEntityUpdated);
                }
            }
        }
        private Nullable<int> _item_line_id;
        public Nullable<int> item_line_id
        {
            get { return _item_line_id; }
            set
            {
                if (_item_line_id != value)
                {
                    _item_line_id = value; RaisePropertyChanged("item_line_id", ModelEntityUpdated);
                }
            }
        }
        private string _fin_year;
        public string fin_year
        {
            get { return _fin_year; }
            set
            {
                if (_fin_year != value)
                {
                    _fin_year = value; RaisePropertyChanged("fin_year", ModelEntityUpdated);
                }
            }
        }
        private string _posting_period;
        public string posting_period
        {
            get { return _posting_period; }
            set
            {
                if (_posting_period != value)
                {
                    _posting_period = value; RaisePropertyChanged("posting_period", ModelEntityUpdated);
                }
            }
        }
        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set
            {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active", ModelEntityUpdated);
                }
            }
        }
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                if (_location_Id != value)
                {
                    _location_Id = value; RaisePropertyChanged("location_Id", ModelEntityUpdated);
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
                    _comp_code = value; RaisePropertyChanged("comp_code", ModelEntityUpdated);
                }
            }
        }
        private string _dc_ind { get; set; }
        public string dc_ind
        {
            get { return _dc_ind; }
            set
            {
                if (_dc_ind != value)
                {
                    _dc_ind = value; RaisePropertyChanged("dc_ind");
                }
            }
        }
        private string _curr_code { get; set; }
        public string curr_code
        {
            get { return _curr_code; }
            set
            {
                if (_curr_code != value)
                {
                    _curr_code = value; RaisePropertyChanged("curr_code", ModelEntityUpdated);
                }
            }
        }
        private Nullable<decimal> _exch_rate { get; set; }
        public Nullable<decimal> exch_rate
        {
            get { return _exch_rate; }
            set
            {
                if (_exch_rate != value)
                {
                    _exch_rate = value; RaisePropertyChanged("exch_rate", ModelEntityUpdated);
                }
            }
        }
        private string _local_curr { get; set; }
        public string local_curr
        {
            get { return _local_curr; }
            set
            {
                if (_local_curr != value)
                {
                    _local_curr = value; RaisePropertyChanged("local_curr");
                }
            }
        }
        private Nullable<decimal> _amt_local_curr { get; set; }
        public Nullable<decimal> amt_local_curr
        {
            get { return _amt_local_curr; }
            set
            {
                if (_amt_local_curr != value)
                {
                    _amt_local_curr = value; RaisePropertyChanged("amt_local_curr");
                }
            }
        }
        private string _fix_per { get; set; }
        public string fix_per
        {
            get { return _fix_per; }
            set
            {
                if (_fix_per != value)
                {
                    _fix_per = value; RaisePropertyChanged("fix_per");
                }
            }
        }
        private string _symbol { get; set; }
        public string symbol
        {
            get { return _symbol; }
            set
            {
                if (_symbol != value)
                {
                    _symbol = value; RaisePropertyChanged("symbol");
                }
            }
        }

        //Added by Priya
        private string _con_type { get; set; }
        public string con_type
        {
            get
            {
                return _con_type;
            }

            set
            {
                if (_con_type != value)
                {
                    _con_type = value; RaisePropertyChanged("con_type");
                }
            }
        }
        private string _con_cat { get; set; }
        public string con_cat
        {
            get
            {
                return _con_cat;
            }

            set
            {
                if (_con_cat != value)
                {
                    _con_cat = value; RaisePropertyChanged("con_cat");
                }
            }
        }
        private int _acc_seq { get; set; }
        public int acc_seq
        {
            get
            {
                return _acc_seq;
            }

            set
            {
                if (_acc_seq != value)
                {
                    _acc_seq = value; RaisePropertyChanged("acc_seq");
                }
            }
        }
        private string _trns_key_code { get; set; }
        public string trns_key_code
        {
            get
            {
                return _trns_key_code;
            }

            set
            {
                if (_trns_key_code != value)
                {
                    _trns_key_code = value; RaisePropertyChanged("trns_key_code");
                }
            }
        }
        private string _acc_key1 { get; set; }
        public string acc_key1
        {
            get
            {
                return _acc_key1;
            }

            set
            {
                if (_acc_key1 != value)
                {
                    _acc_key1 = value; RaisePropertyChanged("acc_key1");
                }
            }
        }
        private string _record_no { get; set; }
        public string record_no
        {
            get
            {
                return _record_no;
            }

            set
            {
                if (_record_no != value)
                {
                    _record_no = value; RaisePropertyChanged("record_no");
                }
            }
        }
        private decimal? _price_uom;
        public decimal? price_uom
        {
            get
            {
                return _price_uom;
            }

            set
            {
                if (_price_uom != value)
                {
                    _price_uom = value; RaisePropertyChanged("price_uom");
                }
            }
        }
        private string _doc_uom_con { get; set; }
        public string doc_uom_con
        {
            get
            {
                return _doc_uom_con;
            }

            set
            {
                if (_doc_uom_con != value)
                {
                    _doc_uom_con = value; RaisePropertyChanged("doc_uom_con");
                }
            }
        }

        private decimal? _no_base_uom;
        public decimal? no_base_uom
        {
            get
            {
                return _no_base_uom;
            }

            set
            {
                if (_no_base_uom != value)
                {
                    _no_base_uom = value; RaisePropertyChanged("no_base_uom");
                }
            }
        }

        private decimal? _dno_base_uom;
        public decimal? dno_base_uom
        {
            get
            {
                return _dno_base_uom;
            }

            set
            {
                if (_dno_base_uom != value)
                {
                    _dno_base_uom = value; RaisePropertyChanged("dno_base_uom");
                }
            }
        }
        private string _ind_con_acc { get; set; }
        public string ind_con_acc
        {
            get
            {
                return _ind_con_acc;
            }

            set
            {
                if (_ind_con_acc != value)
                {
                    _ind_con_acc = value; RaisePropertyChanged("ind_con_acc");
                }
            }
        }
        private string _vendor_code { get; set; }
        public string vendor_code
        {
            get
            {
                return _vendor_code;
            }

            set
            {
                if (_vendor_code != value)
                {
                    _vendor_code = value; RaisePropertyChanged("vendor_code");
                }
            }
        }
        private string _customera_code { get; set; }
        public string customera_code
        {
            get
            {
                return _customera_code;
            }

            set
            {
                if (_customera_code != value)
                {
                    _customera_code = value; RaisePropertyChanged("customera_code");
                }
            }
        }
        private decimal? _rnd_diff;
        public decimal? rnd_diff
        {
            get
            {
                return _rnd_diff;
            }

            set
            {
                if (_rnd_diff != value)
                {
                    _rnd_diff = value; RaisePropertyChanged("rnd_diff");
                }
            }
        }
        private decimal? _con_value;
        public decimal? con_value
        {
            get
            {
                return _con_value;
            }

            set
            {
                if (_con_value != value)
                {
                    _con_value = value; RaisePropertyChanged("con_value");
                }
            }
        }
        private string _ind_max_base { get; set; }
        public string ind_max_base
        {
            get
            {
                return _ind_max_base;
            }

            set
            {
                if (_ind_max_base != value)
                {
                    _ind_max_base = value; RaisePropertyChanged("ind_max_base");
                }
            }
        }
        private string _ind_max_amt { get; set; }
        public string ind_max_amt
        {
            get
            {
                return _ind_max_amt;
            }

            set
            {
                if (_ind_max_amt != value)
                {
                    _ind_max_amt = value; RaisePropertyChanged("ind_max_amt");
                }
            }
        }
        private string _withholding_tax { get; set; }
        public string withholding_tax
        {
            get
            {
                return _withholding_tax;
            }

            set
            {
                if (_withholding_tax != value)
                {
                    _withholding_tax = value; RaisePropertyChanged("withholding_tax");
                }
            }
        }

        //Added by Priya on 2/5/2017
        private int? _stepno;
        public int? stepno
        {
            get
            {
                return _stepno;
            }

            set
            {
                if (_stepno != value)
                {
                    _stepno = value; RaisePropertyChanged("stepno");
                }
            }
        }
        private int? _scounter;
        public int? scounter
        {
            get
            {
                return _scounter;
            }

            set
            {
                if (_scounter != value)
                {
                    _scounter = value; RaisePropertyChanged("scounter");
                }
            }
        }
        private string _trns_scope { get; set; }
        public string trns_scope
        {
            get
            {
                return _trns_scope;
            }

            set
            {
                if (_trns_scope != value)
                {
                    _trns_scope = value; RaisePropertyChanged("trns_scope");
                }
            }
        }
        private decimal? _pricing_date { get; set; }
        public decimal? pricing_date
        {
            get
            {
                return _pricing_date;
            }

            set
            {
                if (_pricing_date != value)
                {
                    _pricing_date = value; RaisePropertyChanged("pricing_date");
                }
            }
        }
        private string _calc_type { get; set; }
        public string calc_type
        {
            get
            {
                return _calc_type;
            }

            set
            {
                if (_calc_type != value)
                {
                    _calc_type = value; RaisePropertyChanged("calc_type");
                }
            }
        }
        private decimal? _con_qty { get; set; }
        public decimal? con_qty
        {
            get
            {
                return _con_qty;
            }

            set
            {
                if (_con_qty != value)
                {
                    _con_qty = value; RaisePropertyChanged("con_qty");
                }
            }
        }
        private string _ind_stats { get; set; }
        public string ind_stats
        {
            get
            {
                return _ind_stats;
            }

            set
            {
                if (_ind_stats != value)
                {
                    _ind_stats = value; RaisePropertyChanged("ind_stats");
                }
            }
        }
        private string _scale_type { get; set; }
        public string scale_type
        {
            get
            {
                return _scale_type;
            }

            set
            {
                if (_scale_type != value)
                {
                    _scale_type = value; RaisePropertyChanged("scale_type");
                }
            }
        }
        private decimal? _scale_qty { get; set; }
        public decimal? scale_qty
        {
            get
            {
                return _scale_qty;
            }

            set
            {
                if (_scale_qty != value)
                {
                    _scale_qty = value; RaisePropertyChanged("scale_qty");
                }
            }
        }
        private string _ind_con_acr { get; set; }
        public string ind_con_acr
        {
            get
            {
                return _ind_con_acr;
            }

            set
            {
                if (_ind_con_acr != value)
                {
                    _ind_con_acr = value; RaisePropertyChanged("ind_con_acr");
                }
            }
        }
        private string _PartyId { get; set; }
        public string PartyId
        {
            get
            {
                return _PartyId;
            }

            set
            {
                if (_PartyId != value)
                {
                    _PartyId = value; RaisePropertyChanged("PartyId");
                }
            }
        }
        private string _tax_code { get; set; }
        public string tax_code
        {
            get
            {
                return _tax_code;
            }

            set
            {
                if (_tax_code != value)
                {
                    _tax_code = value; RaisePropertyChanged("tax_code");
                }
            }
        }
        private string _origin_ind { get; set; }
        public string origin_ind
        {
            get
            {
                return _origin_ind;
            }

            set
            {
                if (_origin_ind != value)
                {
                    _origin_ind = value; RaisePropertyChanged("origin_ind");
                }
            }
        }
        private string _con_control { get; set; }
        public string con_control
        {
            get
            {
                return _con_control;
            }

            set
            {
                if (_con_control != value)
                {
                    _con_control = value; RaisePropertyChanged("con_control");
                }
            }
        }
        private string _round_method { get; set; }
        public string round_method
        {
            get
            {
                return _round_method;
            }

            set
            {
                if (_round_method != value)
                {
                    _round_method = value; RaisePropertyChanged("round_method");
                }
            }
        }
        private string _grp_con { get; set; }
        public string grp_con
        {
            get
            {
                return _grp_con;
            }

            set
            {
                if (_grp_con != value)
                {
                    _grp_con = value; RaisePropertyChanged("grp_con");
                }
            }
        }
        private string _is_qty { get; set; }
        public string is_qty
        {
            get
            {
                return _is_qty;
            }

            set
            {
                if (_is_qty != value)
                {
                    _is_qty = value; RaisePropertyChanged("is_qty");
                }
            }
        }
        private string _con_record_no { get; set; }
        public string con_record_no
        {
            get
            {
                return _con_record_no;
            }

            set
            {
                if (_con_record_no != value)
                {
                    _con_record_no = value; RaisePropertyChanged("con_record_no");
                }
            }
        }
        private int? _con_seq;
        public int? con_seq
        {
            get
            {
                return _con_seq;
            }

            set
            {
                if (_con_seq != value)
                {
                    _con_seq = value; RaisePropertyChanged("con_seq");
                }
            }
        }
        private string _con_class { get; set; }
        public string con_class
        {
            get
            {
                return _con_class;
            }

            set
            {
                if (_con_class != value)
                {
                    _con_class = value; RaisePropertyChanged("con_class");
                }
            }
        }
        private int? _cc_head;
        public int? cc_head
        {
            get
            {
                return _cc_head;
            }

            set
            {
                if (_cc_head != value)
                {
                    _cc_head = value; RaisePropertyChanged("cc_head");
                }
            }
        }
        private decimal? _f_cbv { get; set; }
        public decimal? f_cbv
        {
            get
            {
                return _f_cbv;
            }

            set
            {
                if (_f_cbv != value)
                {
                    _f_cbv = value; RaisePropertyChanged("f_cbv");
                }
            }
        }
        private decimal? _f_cbp { get; set; }
        public decimal? f_cbp
        {
            get
            {
                return _f_cbp;
            }

            set
            {
                if (_f_cbp != value)
                {
                    _f_cbp = value; RaisePropertyChanged("f_cbp");
                }
            }
        }
        private string _ind_scale { get; set; }
        public string ind_scale
        {
            get
            {
                return _ind_scale;
            }

            set
            {
                if (_ind_scale != value)
                {
                    _ind_scale = value; RaisePropertyChanged("ind_scale");
                }
            }
        }
        private decimal? _scale_value { get; set; }
        public decimal? scale_value
        {
            get
            {
                return _scale_value;
            }

            set
            {
                if (_scale_value != value)
                {
                    _scale_value = value; RaisePropertyChanged("scale_value");
                }
            }
        }
        private string _scale_curr { get; set; }
        public string scale_curr
        {
            get
            {
                return _scale_curr;
            }

            set
            {
                if (_scale_curr != value)
                {
                    _scale_curr = value; RaisePropertyChanged("scale_curr");
                }
            }
        }
        private string _cost_center { get; set; }
        public string cost_center
        {
            get
            {
                return _cost_center;
            }

            set
            {
                if (_cost_center != value)
                {
                    _cost_center = value; RaisePropertyChanged("cost_center");
                }
            }
        }
        private string _profit_center { get; set; }
        public string profit_center
        {
            get
            {
                return _profit_center;
            }

            set
            {
                if (_profit_center != value)
                {
                    _profit_center = value; RaisePropertyChanged("profit_center");
                }
            }
        }
        private string _gross_indicator { get; set; }
        public string gross_indicator
        {
            get
            {
                return _gross_indicator;
            }

            set
            {
                if (_gross_indicator != value)
                {
                    _gross_indicator = value; RaisePropertyChanged("gross_indicator");
                }
            }
        }
        private string _analysis_code { get; set; }
        public string analysis_code
        {
            get
            {
                return _analysis_code;
            }

            set
            {
                if (_analysis_code != value)
                {
                    _analysis_code = value; RaisePropertyChanged("analysis_code");
                }
            }
        }
        private decimal? _rate_uom { get; set; }
        public decimal? rate_uom
        {
            get
            {
                return _rate_uom;
            }

            set
            {
                if (_rate_uom != value)
                {
                    _rate_uom = value; RaisePropertyChanged("rate_uom");
                }
            }
        }
        private string _pay_term { get; set; }
        public string pay_term
        {
            get
            {
                return _pay_term;
            }

            set
            {
                if (_pay_term != value)
                {
                    _pay_term = value; RaisePropertyChanged("pay_term");
                }
            }
        }
        private string _lic_type { get; set; }
        public string lic_type
        {
            get
            {
                return _lic_type;
            }

            set
            {
                if (_lic_type != value)
                {
                    _lic_type = value; RaisePropertyChanged("lic_type");
                }
            }
        }
        private string _lic_no { get; set; }
        public string lic_no
        {
            get
            {
                return _lic_no;
            }

            set
            {
                if (_lic_no != value)
                {
                    _lic_no = value; RaisePropertyChanged("lic_no");
                }
            }
        }
        private string _language;
        public string language
        {
            get { return _language; }
            set
            {
                if (_language != value)
                {
                    _language = value; RaisePropertyChanged("language");
                }
            }
        }
        

    }


    public class MC_SEL_T003 : MC_FICO_BE
    {
        public List<SEL_T003> MasterEntity { get; set; }
        public ObservableCollection<SEL_T003_A> ItemsEntity { get; set; }
        public ObservableCollection<ACC_T006_C> ConditionEntity { get; set; }
        public ObservableCollection<GEN_T011> TermsAndCondition { get; set; }

    }


    //Depricated

    public class SEL_T003Flip
    {
        public string bill_doc { get; set; }
        public Nullable<DateTime> doc_date { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string ref_doc_no { get; set; }
        public string sono { get; set; }
        public string PartyId { get; set; }
        public string sold_to_party_name { get; set; }
        public string t_status { get; set; }
        public string t_display { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string so_code { get; set; }
        public string sales_org { get; set; }
        public string roundup_total { get; set; }
        public string SalesPerson { get; set; }
        public string color_code { get; set; }
        public string cust_ref { get; set; }
        public string sg_code { get; set; }
        public string sg_name { get; set; }
    }
    public class MultipleContext_SEL_T003
    {
        public List<ADM_M0013> STATUS_LIST { get; set; }
        public List<STD_PARTY> PARTY_LIST { get; set; }
        public List<STD_ITEM> STD_ITEM_LIST { get; set; }
        public List<STD_MIS_BE> STD_MIS_LIST { get; set; }
        public List<STD_DOC_TYPE> DOC_TYPE_LIST { get; set; }
        public List<ACC_M003_P> AccountList { get; set; }
        public List<SEL_T003Flip> DocumentDataFlipGrid { get; set; }
        public List<ADM_M028_P> PartyMaster { get; set; }
        public List<SEL_T003_P_RefDoc> Sales_Invoice_Reference { get; set; }
        public List<ACC_M013_P> TaxList { get; set; }
        public List<ADM_M037_P> CurrencysList { get; set; }
        public List<ACC_M004_P> BanksList { get; set; }
        public List<ACC_M025_P> withholdinglist { get; set; }
        public List<ADM_M028_P> ServiceProviders { get; set; }
        public List<ADM_M041_P> LicenseAdvance { get; set; }
        public List<ADM_M041_P> LicenseEPCG { get; set; }
        public List<ADM_M020_P> Product_Description { get; set; }
        public List<ADM_M012_P> CountryList { get; set; }
        public List<ADM_M028_P> Transporters { get; set; }
        public List<MM_M002_P> GodownList { get; set; }
        public List<ACC_M007_P> PayTerms { get; set; }
        public List<ADM_M001_A_P> SalesOrg { get; set; }
        public List<ADM_M001_H_P> SalesGroup { get; set; }
        public List<ADM_M001_D_P> SalesDiv { get; set; }
        public List<ADM_M001_C_P> DistributionChannel { get; set; }
        public List<ACC_M019_P> Cost_Centers { get; set; }
        public List<ACC_M005_P> Journals { get; set; }
        public List<ADM_M031_P> ParameterList { get; set; } //Parameter Master
        public List<ADM_M030_P> ParamValueList { get; set; }
        public List<SYS_M003_P> ItemCategoryList { get; set; }
        public List<ADM_M038_B_P> UnitList { get; set; }
        public List<ZADM_M006_P> Inks { get; set; }
        public List<ZADM_M007_P> ILDs { get; set; }
        public List<ACC_M013_P> FormType { get; set; }
        public List<SEL_T003> MasterEntity { get; set; }
        public ObservableCollection<SEL_T003_A> ItemsEntity { get; set; }
        public ObservableCollection<ACC_T006_C> TaxEntity { get; set; }
        public List<ADM_M028_D_P> PartysSoldToAddresses { get; set; }
        public List<SEL_T003_P_SI_ItemsList> ItemListPopup { get; set; }
        public List<CRM_T001A_P> CustCatlogNo { get; set; }
        public List<SYS_M002> doc_typeList { get; set; }
        public List<RptSalesInvoice> RptSalesInvoice { get; set; }
        public List<RptSalesInvoiceItem> RptSalesInvoiceItem { get; set; }
        public List<RptSalesInvoiceTax> RptSalesInvoiceTax { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<NotificationData> NotificationData { get; set; }
        public List<ADM_M024_P> SalesPerson { get; set; }
        public List<SYS_M001_P> Export_Doc_Type { get; set; }
        public List<RptDeliveryNote> RptDeliveryNoteList { get; set; }
        public List<SYS_M002> DocCategoryList { get; set; }
        public List<RptItemPackingDetail> RptItemPackingDetailList { get; set; }
        public List<RptBatchDetail> RptBatchDetailList { get; set; }
        public List<ADM_M044_P> Incoterm { get; set; }
        public List<ADM_M038_C> UnitConversion { get; set; }
        public List<SEL_T002_A> ScheduleItemsEntity { get; set; }
        public List<ACC_T001_A> PaymentDetail { get; set; }
        public List<ACC_M003_O_P> ConditionTypeList { get; set; }
        public List<ADM_M041_P> LicenceList { get; set; }
        public ObservableCollection<ACC_T006_D> LicenceEntity { get; set; }
        public List<ADM_M003_C_P> BussinessPlaceList { get; set; }
        public List<Report_Data_P> Report_DataList { get; set; }
        public List<Report_Data_P> Report_DataList2 { get; set; }
        public List<SEL_T003_P_RefDoc> SO_ReferenceList { get; set; }
        public List<ADM_M058_A_P> CalcValues { get; set; }
        public List<ADM_M063_P> GSTDeclaration { get; set; }
        public List<SEL_T003_P> Invoice { get; set; }
        public List<SYS_M026> TransportMode { get; set; }
        public List<SYS_M037> Trade_Types { get; set; }
        public List<ACC_M004_P> hbList { get; set; }
        public List<EWayBill_document> EB_BillLists { get; set; }
        public List<EWayBill_itemList> EB_ItemList { get; set; }
        public ObservableCollection<GEN_T011> TermsAndCondition { get; set; }
        public List<ADM_M0051> CONDITION_LIST { get; set; }
    }
    public class SEL_T003_P_SI_ItemsList//Item List for Popup Sales Invoice.
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
        public string weight_unit_cd { get; set; }
        public string volume_unit_cd { get; set; }
        public string weight_unit { get; set; }
        public string volume_unit { get; set; }
        public Nullable<decimal> MinQty { get; set; }
        public Nullable<decimal> MaxQty { get; set; }
        public Nullable<decimal> Reorder { get; set; }
        public Nullable<decimal> stock_total { get; set; }
        public Nullable<decimal> stock_reserve { get; set; }
        public Nullable<decimal> stock_unr { get; set; }
        public Nullable<decimal> stock_in_transit { get; set; }
        public string acc_group { get; set; }
        public string value_class { get; set; }
        public string recon_acc { get; set; }
        public bool? ind_sku;
    }
    public class SalesInvoice_SingleReport
    {
        public string CompanyName { get; set; }
        public byte[] CompLogo { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PinCode { get; set; }
        public string PhoneOffice { get; set; }
        public string FaxNo { get; set; }
        public string Mailid { get; set; }
        public string WebSite { get; set; }
        public string Consignee_Nm { get; set; }
        public string Consignee_Address { get; set; }
        public string Consignee_City { get; set; }
        public string Consignee_State { get; set; }
        public string Consignee_Country { get; set; }
        public string Consignee_PinCode { get; set; }
        public string Consignee_PhoneNo { get; set; }
        public string Consignee_FaxNo { get; set; }
        public string Consignee_EmailID { get; set; }
        public string Consignee_WebSite { get; set; }
        public string Buyer_Nm { get; set; }
        public string Buyer_Address { get; set; }
        public string Buyer_City { get; set; }
        public string Buyer_State { get; set; }
        public string Buyer_Country { get; set; }
        public string Buyer_PinCode { get; set; }
        public string Buyer_PhoneNo { get; set; }
        public string Buyer_FaxNo { get; set; }
        public string Buyer_EmailID { get; set; }
        public string Buyer_WebSite { get; set; }
        public string source_no { get; set; }
        public string doc_date { get; set; }
        public string bill_doc { get; set; }
        public string bill_date { get; set; }
        public string ref_data { get; set; }
        public string ref_data2 { get; set; }
        public string origin_country { get; set; }
        public string dest_country { get; set; }
        public string pre_carrage { get; set; }
        public string pre_carrage_place { get; set; }
        public string vess_flight { get; set; }
        public string port_load { get; set; }
        public string port_desc { get; set; }
        public string final_dest { get; set; }
        public string container_no { get; set; }
        public string pack_det { get; set; }
        public string prod_desc { get; set; }
        public string prod_desc1 { get; set; }
        public string item_code { get; set; }
        public string item_desc { get; set; }
        public Nullable<decimal> qty { get; set; }
        public Nullable<decimal> unit_price { get; set; }
        public Nullable<decimal> subtotal { get; set; }
        public string amt_word { get; set; }
        public Nullable<decimal> invoice_amt { get; set; }
        public Nullable<decimal> invoice_amtr { get; set; }
        public string epcg { get; set; }
        public string adv_lic { get; set; }
        public string ns_wire { get; set; }
        public string tc_ball { get; set; }
        public string transport_party_nm { get; set; }
        public string unit_name { get; set; }
        public string decl { get; set; }
        public string terms { get; set; }
        public string order_date { get; set; }
        public string marks { get; set; }
        public string container { get; set; }
        public string range_no { get; set; }
        public string no_of_pckgs { get; set; }
        public string kind_of_pckgs { get; set; }
        public string rmit_find_to { get; set; }
        public string beneficiary_bnk { get; set; }
        public string benificiary { get; set; }
        public Nullable<decimal> fright_values { get; set; }
        public Nullable<decimal> ass_value { get; set; }
        public Nullable<decimal> p_f { get; set; }
        public Nullable<decimal> cst { get; set; }
        public Nullable<decimal> rndtotal_amt { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string vat_tin { get; set; }
        public string cst_tin { get; set; }
        public string lbt_no { get; set; }
        public string ManuScop { get; set; }
        public string challanno { get; set; }
        public string challandate { get; set; }
        public string lr_no { get; set; }
        public string lr_date { get; set; }
        public string transport_mode { get; set; }
        public string Buyer_VATNo { get; set; }
        public string Buyer_VATDate { get; set; }
        public string Buyer_CSTNo { get; set; }
        public string Buyer_CSTDate { get; set; }
        public string Form_no { get; set; }
        public string Regd_Address { get; set; }
        public string del_at { get; set; }
        public string bin { get; set; }
        public string lc_cond { get; set; }
        public string gross_wt { get; set; }
        public string net_wt { get; set; }
        private decimal disc_amt { get; set; }
        public string CorporateNo { get; set; }
        public string CentralExNo { get; set; }
        public string CentralExDate { get; set; }
        public Nullable<decimal> sumqty { get; set; }
        public string model { get; set; }
        public string ILD { get; set; }
        public string INK { get; set; }
        public string dispatch_date { get; set; }
        public string appr_date { get; set; }
        public string writing_quality { get; set; }
        public string insurance { get; set; }
        public string orderno { get; set; }
        //public Nullable<decimal> unit_price { get; set; }
        //public Nullable<decimal> subtotal { get; set; }
    }
    public class RptSalesInvoice : ObjectBase
    {
        public string bill_doc { get; set; }
        public string ship_cnd { get; set; }
        public Nullable<DateTime> bill_date { get; set; }
        public string incoterms { get; set; }
        public string curr_code { get; set; }
        public string p_term_code { get; set; }
        public string PartyId { get; set; }
        public string amt_word { get; set; }
        public string acc_code { get; set; }
        public string cust_acc { get; set; }
        public string ProdNmCd { get; set; }
        public string ProdNm { get; set; }
        public string bank_code { get; set; }
        public string bank_name { get; set; }
        public string trans_mode { get; set; }
        public string pre_carrage { get; set; }
        public string pre_carrage_place { get; set; }
        public string destNm { get; set; }
        public string port_load { get; set; }
        public string port_desc { get; set; }
        public string port_final { get; set; }
        public string final_dest { get; set; }
        public string ship_terms { get; set; }
        public string advance_lic { get; set; }
        public string lic_cod { get; set; }
        public string orgNm { get; set; }
        public string pack_rem { get; set; }
        public string ship_mark { get; set; }
        public string vess_flight { get; set; }
        public string description { get; set; }
        public string account_no { get; set; }
        public string swift_code { get; set; }
        public Nullable<int> bill_address_id { get; set; }
        public string shipping_mark { get; set; }
        public string insurance { get; set; }
        public string packing { get; set; }
        public string transhipment { get; set; }
        public string partshipment { get; set; }
        public Nullable<DateTime> shipment_date { get; set; }
        public Nullable<DateTime> add_date { get; set; }
        public Nullable<DateTime> validity_date { get; set; }
        public string payment_mode { get; set; }
        public string buyerNm { get; set; }
        public string Add1 { get; set; }
        public string Add2 { get; set; }
        public string city1 { get; set; }
        public string state_code { get; set; }
        public string StatName { get; set; }
        public string country_code { get; set; }
        public string CntryName { get; set; }
        public string PinCode { get; set; }
        public string branch { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string acc_number { get; set; }
        public string zip { get; set; }
        public string ifsccode { get; set; }
        public string MICR_code { get; set; }
        public string cust_ref { get; set; }
        public Nullable<DateTime> cust_ref_date { get; set; }
        public string ref_doc_no { get; set; }
        public Nullable<DateTime> ref_doc_date { get; set; }
        public Nullable<DateTime> lic_dt { get; set; }
        public Nullable<decimal> qty_tol { get; set; }
        public Nullable<decimal> amt_tol { get; set; }
        public Nullable<DateTime> adv_date { get; set; }
        public string consignee { get; set; }
        public string hs_code { get; set; }
        public string hsn_code { get; set; }
        public string hsn_code2 { get; set; }
        public string bin_no { get; set; }
        public string wire { get; set; }
        public string ball { get; set; }
        public string doc_desc_user { get; set; }
        public string delivery_no { get; set; }
        public Nullable<DateTime> delivery_date { get; set; }
        public string transporter { get; set; }
        public string delivery_add { get; set; }
        public string form_type { get; set; }
        public Nullable<decimal> round_up { get; set; }
        public string lr_no { get; set; }
        public Nullable<DateTime> lr_date { get; set; }
        public Nullable<decimal> fright_values { get; set; }
        public string VATNo { get; set; }
        public Nullable<DateTime> VATDate { get; set; }
        public string CSTNo { get; set; }
        public Nullable<DateTime> CSTDate { get; set; }
        public Nullable<decimal> sub_total { get; set; }
        public Nullable<decimal> roundup_total { get; set; }
        public Nullable<decimal> tax_amount { get; set; }
        public Nullable<decimal> invoice_amt { get; set; }
        public Nullable<decimal> ass_value { get; set; }
        public Nullable<DateTime> doc_date { get; set; }
        public Nullable<DateTime> post_date { get; set; }
        public string service_tax_no { get; set; }
        public string PanNo { get; set; }
        public string VendorCd { get; set; }
        public string Customer_pono { get; set; }
        public Nullable<DateTime> po_date { get; set; }
        public Nullable<DateTime> edit_date { get; set; }
        public string Seller { get; set; }
        public string SellerEmailId { get; set; }
        public string SellerMobNo { get; set; }
        public string doc_desc { get; set; }
        public string transporter_name { get; set; }
        public byte[] authorised_signature { get; set; }
        public string party_name { get; set; }
        public string bankStateNm { get; set; }
        public string bankCountryNm { get; set; }
        public string doc_type { get; set; }
        public string notify_party { get; set; }
        public string notify_nm { get; set; }
        public string notify_ph { get; set; }
        public string notify_address { get; set; }
        public string PhNo { get; set; }
        public string FaxNo { get; set; }
        public string consgn_ph { get; set; }
        public string consgn_fax { get; set; }
        public string inco_desc { get; set; }
        public string invoice_details { get; set; }
        public string lc_cond { get; set; }
        public Nullable<DateTime> ref_date { get; set; }
        public string EmailId { get; set; }
        public string PCSTNo { get; set; }
        public string PVATNo { get; set; }
        public string PSTNo { get; set; }
        public string PPanNo { get; set; }
        public string buyer_name { get; set; }
        public string buss_place { get; set; }
        public string stock_code { get; set; }
        public string doc_no { get; set; }
        public string no_of_packages { get; set; }
        public string ship_markL { get; set; }
        public string incoterm2 { get; set; }
        public string symbol { get; set; }
        public string ref_data { get; set; }
        public string ref_data2 { get; set; }
        public Nullable<decimal> net_wt { get; set; }
        public decimal? gross_wt { get; set; }
        public string awb_no { get; set; }
        public Nullable<DateTime> awb_date { get; set; }
        public string custom_no { get; set; }
        public Nullable<DateTime> custom_date { get; set; }
        public string terms_of_delivery { get; set; }
        public string manual_item_desc { get; set; }
        public string manual_desc { get; set; }
        public string proforma_no { get; set; }
        public Nullable<DateTime> proforma_date { get; set; }
        public string duty_drawback { get; set; }
        public Nullable<decimal> export_commision { get; set; }
        public Nullable<decimal> export_commision_val { get; set; }
        public string meis { get; set; }
        public string lc_info { get; set; }
        public string LoctnNm { get; set; }
        public string AddL1 { get; set; }
        public string AddL2 { get; set; }
        public string cityL { get; set; }
        public string stateNmL { get; set; }
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
        public string status_remark { get; set; }
        public string amt_word_tax { get; set; }
        public string declaration { get; set; }
        public string payer_nm { get; set; }
        public string payer_address { get; set; }
        public string tax_declaration { get; set; }
        public Nullable<decimal> wt_gross { get; set; }
        public Nullable<decimal> wt_net { get; set; }
        public string unit_code { get; set; }
        public string ad_code { get; set; }
        public string dec_desc { get; set; }
        public string dec_code { get; set; }
        public string rex_no { get; set; }
        public string end_use_code { get; set; }
        public string reg_declaration { get; set; }
        public string reg_no { get; set; }
        public string notify_party_name2 { get; set; }
        public string notify_address2 { get; set; }
        public string weight_unit { get; set; }
        public string tr_name { get; set; }
        public string ref_incoterms { get; set; }
        public string ref_roundup_total { get; set; }
        public Nullable<decimal> exc_rate { get; set; }
        public Nullable<decimal> ref_exc_rate { get; set; }
        public Nullable<decimal> net_value_wo_tax_item { get; set; }
        public string awb_inst { get; set; }
        public string vendor_remark { get; set; }
        public Nullable<DateTime> del_date { get; set; }
        public string DeptName { get; set; }
        public string PersnEmailId { get; set; }
        public string ref_declaration { get; set; }
        public string PersnMobNo { get; set; }
        public string para5 { get; set; }
        public string para9 { get; set; }
        public string acc_no { get; set; }
        public string acc_name { get; set; }
        public string location_id { get; set; }
        public string location_id_reg { get; set; }//Registered Location from Company Master
        public string contract_acc { get; set; }
        public string lic_name { get; set; }
        public string amt_word_local { get; set; }
        public DateTime? rev_date { get; set; }
    }
    public class RptSalesInvoiceItem
    {
        public string ItemCode { get; set; }
        public string item_desc { get; set; }
        public Nullable<decimal> qty { get; set; }
        public Nullable<decimal> unit_price { get; set; }
        public Nullable<decimal> total_amount { get; set; }
        public Nullable<decimal> wt_gross { get; set; }
        public Nullable<decimal> wt_net { get; set; }
        public string unit_code { get; set; }
        public string marks { get; set; }
        public Nullable<int> NoOfPkgs { get; set; }
        public string container_no { get; set; }
        public string KindOfPkgs { get; set; }
        public string cust_cat_no { get; set; }
        public string CstmrItmCod { get; set; }
        public string CstmrItmDesc { get; set; }
        public Nullable<decimal> subtotal { get; set; }
        public Nullable<decimal> discount { get; set; }
        public Nullable<decimal> discount_amt { get; set; }
        public string Remark { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public string grade_code { get; set; }
        public string textdata { get; set; }
        public string ref_doc_no { get; set; }
        public string ProdNm { get; set; }
        public string hs_code { get; set; }
        public string hsn_code { get; set; }
        public string hsn_code2 { get; set; }
        public string symbol { get; set; }
        public string delivery_no { get; set; }
        public Nullable<decimal> delivery_date { get; set; }
        public string hs_code2 { get; set; }
        public string sono { get; set; }
        public Nullable<System.DateTime> sodate { get; set; }
        public Nullable<decimal> tax_amount { get; set; }
        public string wire_calc { get; set; }
        public string ball_calc { get; set; }
        public string wire_Type { get; set; }
        public string wire_size { get; set; }
        public string ball_type { get; set; }
        public string ball_dia { get; set; }
        public Nullable<decimal> qty_price { get; set; }
        public Nullable<decimal> price_qty { get; set; }
        public string price_qty_uom { get; set; }
        public string weight_unit { get; set; }
        public decimal? gross_wt { get; set; }
        public decimal? net_wt { get; set; }
        public string cust_ref { get; set; }
        public string item_category { get; set; }
        public decimal? net_value { get; set; }
        public decimal? gross_value { get; set; }
        public decimal? effective_value { get; set; }
        public string batch_no { get; set; }
        public Nullable<decimal> exc_rate { get; set; }
        public string carton_count_from { get; set; }
        public string carton_count_to { get; set; }
    }
    public class CreditDebit
    {
        public string bill_doc { get; set; }
        public DateTime? bill_date { get; set; }
        public string ItemCode { get; set; }
        public string item_desc { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string local_export { get; set; }
        public string credit_debit { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public decimal? invoice_amt { get; set; }
        public decimal? sub_total { get; set; }
        public decimal? ass_value { get; set; }
        public decimal? tax_amount { get; set; }

    }
}