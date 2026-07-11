using Reflection.BusinessEntity.ADM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Finance
{
    public class ACC_T006 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                _doc_no = value;
                RaisePropertyChanged("doc_no");
            }
        }

        private DateTime _doc_date;
        public DateTime doc_date
        {
            get { return _doc_date; }
            set
            {
                _doc_date = value;
                RaisePropertyChanged("doc_date");
            }
        }

        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set
            {
                _doc_cat = value;
                RaisePropertyChanged("doc_cat");
            }
        }

        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set
            {
                _doc_type = value;
                RaisePropertyChanged("doc_type");
            }
        }

        private string _PartyId;
        public string PartyId
        {
            get { return _PartyId; }
            set
            {
                _PartyId = value;
                RaisePropertyChanged("PartyId");
            }
        }

        private string _PartyId1;
        public string PartyId1
        {
            get { return _PartyId1; }
            set
            {
                _PartyId1 = value;
                RaisePropertyChanged("PartyId1");
            }
        }

        private decimal? _credit;
        public decimal? credit
        {
            get { return _credit; }
            set
            {
                _credit = value;
                RaisePropertyChanged("credit", ModelEntityUpdated);
            }
        }

        private decimal? _debit;
        public decimal? debit
        {
            get { return _debit; }
            set
            {
                _debit = value;
                RaisePropertyChanged("debit", ModelEntityUpdated);
            }
        }

        private string _ref_doc_no;
        public string ref_doc_no
        {
            get { return _ref_doc_no; }
            set
            {
                _ref_doc_no = value;
                RaisePropertyChanged("ref_doc_no");
            }
        }

        private string _ref_doc_no1;
        public string ref_doc_no1
        {
            get { return _ref_doc_no1; }
            set
            {
                _ref_doc_no1 = value;
                RaisePropertyChanged("ref_doc_no1");
            }
        }

        private DateTime? _ref_doc_date;
        public DateTime? ref_doc_date
        {
            get { return _ref_doc_date; }
            set
            {
                _ref_doc_date = value;
                RaisePropertyChanged("ref_doc_date");
            }
        }

        private DateTime? _ref_doc_date1;
        public DateTime? ref_doc_date1
        {
            get { return _ref_doc_date1; }
            set
            {
                _ref_doc_date1 = value;
                RaisePropertyChanged("ref_doc_date1");
            }
        }

        private string _ref_doc_type;
        public string ref_doc_type
        {
            get { return _ref_doc_type; }
            set
            {
                _ref_doc_type = value;
                RaisePropertyChanged("ref_doc_type");
            }
        }

        private string _ref_doc_type1;
        public string ref_doc_type1
        {
            get { return _ref_doc_type1; }
            set
            {
                _ref_doc_type1 = value;
                RaisePropertyChanged("ref_doc_type1");
            }
        }

        private string _local_currency;
        public string local_currency
        {
            get { return _local_currency; }
            set
            {
                _local_currency = value;
                RaisePropertyChanged("local_currency");
            }
        }

        private string _local_currency2;
        public string local_currency2
        {
            get { return _local_currency2; }
            set
            {
                _local_currency2 = value;
                RaisePropertyChanged("local_currency2");
            }
        }

        private string _local_currency3;
        public string local_currency3
        {
            get { return _local_currency3; }
            set
            {
                _local_currency3 = value;
                RaisePropertyChanged("local_currency3");
            }
        }

        private decimal? _exc_rate;
        public decimal? exc_rate
        {
            get { return _exc_rate; }
            set
            {
                _exc_rate = value;
                RaisePropertyChanged("exc_rate", ModelEntityUpdated);
            }
        }

        private decimal? _exc_rate_curr2;
        public decimal? exc_rate_curr2
        {
            get { return _exc_rate_curr2; }
            set
            {
                _exc_rate_curr2 = value;
                RaisePropertyChanged("exc_rate_curr2", ModelEntityUpdated);
            }
        }

        private decimal? _exc_rate_curr3;
        public decimal? exc_rate_curr3
        {
            get { return _exc_rate_curr3; }
            set
            {
                _exc_rate_curr3 = value;
                RaisePropertyChanged("exc_rate_curr3", ModelEntityUpdated);
            }
        }

        private string _exch_rate_type;
        public string exch_rate_type
        {
            get { return _exch_rate_type; }
            set
            {
                _exch_rate_type = value;
                RaisePropertyChanged("exch_rate_type");
            }
        }

        private string _exch_rate_type2;
        public string exch_rate_type2
        {
            get { return _exch_rate_type2; }
            set
            {
                _exch_rate_type2 = value;
                RaisePropertyChanged("exch_rate_type2");
            }
        }

        private decimal? _exc_rate_tax;
        public decimal? exc_rate_tax
        {
            get { return _exc_rate_tax; }
            set
            {
                _exc_rate_tax = value;
                RaisePropertyChanged("exc_rate_tax");
            }
        }

        private string _analysis_code;
        public string analysis_code
        {
            get { return _analysis_code; }
            set
            {
                _analysis_code = value;
                RaisePropertyChanged("analysis_code");
            }
        }

        private string _cost_center;
        public string cost_center
        {
            get { return _cost_center; }
            set
            {
                _cost_center = value;
                RaisePropertyChanged("cost_center");
            }
        }

        private string _gl_amt_extax;
        public string gl_amt_extax
        {
            get { return _gl_amt_extax; }
            set
            {
                _gl_amt_extax = value;
                RaisePropertyChanged("gl_amt_extax");
            }
        }

        private string _source_comp;
        public string source_comp
        {
            get { return _source_comp; }
            set
            {
                _source_comp = value;
                RaisePropertyChanged("source_comp");
            }
        }

        private DateTime? _inv_reciept_date;
        public DateTime? inv_reciept_date
        {
            get { return _inv_reciept_date; }
            set
            {
                _inv_reciept_date = value;
                RaisePropertyChanged("inv_reciept_date");
            }
        }

        private string _src_curr;
        public string src_curr
        {
            get { return _src_curr; }
            set
            {
                _src_curr = value;
                RaisePropertyChanged("src_curr");
            }
        }

        private string _trans_datetp_sec_curr;
        public string trans_datetp_sec_curr
        {
            get { return _trans_datetp_sec_curr; }
            set
            {
                _trans_datetp_sec_curr = value;
                RaisePropertyChanged("trans_datetp_sec_curr");
            }
        }

        private string _curr_type_sec;
        public string curr_type_sec
        {
            get { return _curr_type_sec; }
            set
            {
                _curr_type_sec = value;
                RaisePropertyChanged("curr_type_sec");
            }
        }

        private string _trans_datetp_thir_curr;
        public string trans_datetp_thir_curr
        {
            get { return _trans_datetp_thir_curr; }
            set
            {
                _trans_datetp_thir_curr = value;
                RaisePropertyChanged("trans_datetp_thir_curr");
            }
        }

        private string _curr_type_thir;
        public string curr_type_thir
        {
            get { return _curr_type_thir; }
            set
            {
                _curr_type_thir = value;
                RaisePropertyChanged("curr_type_thir");
            }
        }

        private string _entry_time;
        public string entry_time
        {
            get { return _entry_time; }
            set
            {
                _entry_time = value;
                RaisePropertyChanged("entry_time");
            }
        }

        private DateTime? _doc_add_date;
        public DateTime? doc_add_date
        {
            get { return _doc_add_date; }
            set
            {
                _doc_add_date = value;
                RaisePropertyChanged("doc_add_date");
            }
        }

        private string _ind_doc_posted;
        public string ind_doc_posted
        {
            get { return _ind_doc_posted; }
            set
            {
                _ind_doc_posted = value;
                RaisePropertyChanged("ind_doc_posted");
            }
        }

        private decimal? _group_exch_rate;
        public decimal? group_exch_rate
        {
            get { return _group_exch_rate; }
            set
            {
                _group_exch_rate = value;
                RaisePropertyChanged("group_exch_rate");
            }
        }

        private string _grp_curr_code;
        public string grp_curr_code
        {
            get { return _grp_curr_code; }
            set
            {
                _grp_curr_code = value;
                RaisePropertyChanged("grp_curr_code");
            }
        }

        private string _curr_code;
        public string curr_code
        {
            get { return _curr_code; }
            set
            {
                _curr_code = value;
                RaisePropertyChanged("curr_code", ModelEntityUpdated);
            }
        }

        private DateTime? _post_date;
        public DateTime? post_date
        {
            get { return _post_date; }
            set
            {
                _post_date = value;
                RaisePropertyChanged("post_date");
            }
        }

        private string _gl_code;
        public string gl_code
        {
            get { return _gl_code; }
            set
            {
                _gl_code = value;
                RaisePropertyChanged("gl_code");
            }
        }

        private string _gl_code1;
        public string gl_code1
        {
            get { return _gl_code1; }
            set
            {
                _gl_code1 = value;
                RaisePropertyChanged("gl_code1");
            }
        }

        private string _PartyNm;
        public string PartyNm
        {
            get { return _PartyNm; }
            set
            {
                _PartyNm = value;
                RaisePropertyChanged("PartyNm");
            }
        }

        private string _PartyNm1;
        public string PartyNm1
        {
            get { return _PartyNm1; }
            set
            {
                _PartyNm1 = value;
                RaisePropertyChanged("PartyNm1");
            }
        }

        private string _gl_subgrp;
        public string gl_subgrp
        {
            get { return _gl_subgrp; }
            set
            {
                _gl_subgrp = value;
                RaisePropertyChanged("gl_subgrp");
            }
        }

        private string _gl_grp;
        public string gl_grp
        {
            get { return _gl_grp; }
            set
            {
                _gl_grp = value;
                RaisePropertyChanged("gl_grp");
            }
        }

        private string _fin_year;
        public string fin_year
        {
            get { return _fin_year; }
            set
            {
                _fin_year = value;
                RaisePropertyChanged("fin_year");
            }
        }

        private string _posting_period;
        public string posting_period
        {
            get { return _posting_period; }
            set
            {
                _posting_period = value;
                RaisePropertyChanged("posting_period");
            }
        }

        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set
            {
                _t_status = value;
                RaisePropertyChanged("t_status");
            }
        }

        private bool _active;
        public bool active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
            }
        }

        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                _lang_key = value;
                RaisePropertyChanged("lang_key");
            }
        }

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                _comp_code = value;
                RaisePropertyChanged("comp_code");
            }
        }

        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                _location_Id = value;
                RaisePropertyChanged("location_Id");
            }
        }

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set
            {
                _add_by = value;
                RaisePropertyChanged("add_by");
            }
        }

        private DateTime _add_date;
        public DateTime add_date
        {
            get { return _add_date; }
            set
            {
                _add_date = value;
                RaisePropertyChanged("add_date");
            }
        }

        private string _editby;
        public string editby
        {
            get { return _editby; }
            set
            {
                _editby = value;
                RaisePropertyChanged("editby");
            }
        }

        private DateTime? _edit_date;
        public DateTime? edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value;
                RaisePropertyChanged("edit_date");
            }
        }

        private string _remark;
        public string remark
        {
            get { return _remark; }
            set
            {
                _remark = value;
                RaisePropertyChanged("remark");
            }
        }

        private string _note;
        public string note
        {
            get { return _note; }
            set
            {
                _note = value;
                RaisePropertyChanged("note");
            }
        }
        private decimal? _doc_curr_amt;
        public decimal? doc_curr_amt
        {
            get { return _doc_curr_amt; }
            set
            {
                _doc_curr_amt = value;
                RaisePropertyChanged("doc_curr_amt", ModelEntityUpdated);
            }
        }
        private decimal? _loc_curr_amt;
        public decimal? loc_curr_amt
        {
            get { return _loc_curr_amt; }
            set
            {
                _loc_curr_amt = value;
                RaisePropertyChanged("loc_curr_amt");
            }
        }
        private string _TranCode;
        public string TranCode
        {
            get { return _TranCode; }
            set
            {
                _TranCode = value;
                RaisePropertyChanged("TranCode");
            }
        }
        private string _emp_id;
        public string emp_id
        {
            get { return _emp_id; }
            set
            {
                _emp_id = value;
                RaisePropertyChanged("emp_id");
            }
        }
        private string _dc_ind;
        public string dc_ind
        {
            get { return _dc_ind; }
            set
            {
                _dc_ind = value;
                RaisePropertyChanged("dc_ind", ModelEntityUpdated);
            }
        }
        private string _party_ref_no;
        public string party_ref_no
        {
            get { return _party_ref_no; }
            set
            {
                _party_ref_no = value;
                RaisePropertyChanged("party_ref_no");
            }
        }

        private string _bank_no_payee;
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

        private string _ref_doc_cat;
        public string ref_doc_cat
        {
            get
            {
                return _ref_doc_cat;
            }

            set
            {
                _ref_doc_cat = value; RaisePropertyChanged("ref_doc_cat");
            }
        }

        private string _pay_method;
        public string pay_method
        {
            get { return _pay_method; }
            set { _pay_method = value; RaisePropertyChanged("pay_method"); }
        }

        private string _instrument_no;
        public string instrument_no
        {
            get { return _instrument_no; }
            set { _instrument_no = value; RaisePropertyChanged("instrument_no"); }
        }

        private Nullable<System.DateTime> _instrument_date;
        public Nullable<System.DateTime> instrument_date
        {
            get { return _instrument_date; }
            set { _instrument_date = value; RaisePropertyChanged("instrument_date"); }
        }

        //Scalar
        public string XmlDataDocument_FlipGrid { get; set; }
        public string XmlDataDocument_ACC_T006_A { get; set; }

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

        private string _curr_name;
        public string curr_name
        {
            get { return _curr_name; }
            set
            {
                _curr_name = value;
                RaisePropertyChanged("curr_name");
            }
        }

        private string _emp_name;
        public string emp_name
        {
            get { return _emp_name; }
            set
            {
                _emp_name = value;
                RaisePropertyChanged("emp_name");
            }
        }

        private string _PayeeBankName;
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

        private string _fltr_t_status;
        public string fltr_t_status
        {
            get { return _fltr_t_status; }
            set
            {
                if (_fltr_t_status != value)
                {
                    _fltr_t_status = value; RaisePropertyChanged("fltr_t_status");
                }
            }
        }

        private string _fltr_docType;
        public string fltr_docType
        {
            get { return _fltr_docType; }
            set
            {
                if (_fltr_docType != value)
                {
                    _fltr_docType = value; RaisePropertyChanged("fltr_docType");
                }
            }
        }

        private string _fltr_docTypeDesc;
        public string fltr_docTypeDesc
        {
            get { return _fltr_docTypeDesc; }
            set
            {
                if (_fltr_docTypeDesc != value)
                {
                    _fltr_docTypeDesc = value; RaisePropertyChanged("fltr_docTypeDesc");
                }
            }
        }

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

        private string _fltr_t_display;
        public string fltr_t_display
        {
            get { return _fltr_t_display; }
            set
            {
                if (_fltr_t_display != value)
                {
                    _fltr_t_display = value; RaisePropertyChanged("fltr_t_display");
                }
            }
        }

        private string _fltr_location_Id;
        public string fltr_location_Id
        {
            get { return _fltr_location_Id; }
            set
            {
                if (_fltr_location_Id != value)
                {
                    _fltr_location_Id = value; RaisePropertyChanged("fltr_location_Id");
                }
            }
        }

        private string _t_display;
        public string t_display
        {
            get { return _t_display; }
            set
            {
                _t_display = value;
                RaisePropertyChanged("t_display");
            }
        }

        private string _posting_key;
        public string posting_key
        {
            get { return _posting_key; }
            set
            {
                _posting_key = value;
                RaisePropertyChanged("posting_key");
            }
        }

        private string _postingPrd_desc;
        public string postingPrd_desc
        {
            get { return _postingPrd_desc; }
            set
            {
                _postingPrd_desc = value;
                RaisePropertyChanged("postingPrd_desc");
            }
        }

        private string _compName;
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
        private DateTime? _Fltr_FrmDate;
        public DateTime? Fltr_FrmDate   //FrmDate
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
        public DateTime? Fltr_ToDate    //ToDate
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

        #region .Scalar for Bank Reco.

        private string _fin_year_Sclr;
        public string fin_year_Sclr
        {
            get { return _fin_year_Sclr; }
            set
            {
                _fin_year_Sclr = value;
                RaisePropertyChanged("fin_year_Sclr");
            }
        }

        private string _posting_period_Sclr;
        public string posting_period_Sclr
        {
            get { return _posting_period_Sclr; }
            set
            {
                _posting_period_Sclr = value;
                RaisePropertyChanged("posting_period_Sclr");
            }
        }

        private string _bank_no_payee_Sclr;
        public string bank_no_payee_Sclr
        {
            get
            {
                return _bank_no_payee_Sclr;
            }

            set
            {
                _bank_no_payee_Sclr = value; RaisePropertyChanged("bank_no_payee_Sclr");
            }
        }

        private string _comp_code_Sclr;
        public string comp_code_Sclr
        {
            get { return _comp_code_Sclr; }
            set
            {
                _comp_code_Sclr = value;
                RaisePropertyChanged("comp_code_Sclr");
            }
        }

        #endregion

    }

    public class ACC_T006_A : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged("id");
            }
        }



        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                _doc_no = value;
                RaisePropertyChanged("doc_no");
            }
        }
        private int _line_id;
        public int line_id
        {
            get { return _line_id; }
            set
            {
                _line_id = value;
                RaisePropertyChanged("line_id");
            }
        }
        private int? _no_of_line;
        public int? no_of_line
        {
            get { return _no_of_line; }
            set
            {
                _no_of_line = value;
                RaisePropertyChanged("no_of_line");
            }
        }
        private int? _item_identity;
        public int? item_identity
        {
            get { return _item_identity; }
            set
            {
                _item_identity = value;
                RaisePropertyChanged("item_identity");
            }
        }
        private DateTime? _clrg_date { get; set; }
        public DateTime? clrg_date
        {
            get { return _clrg_date; }
            set
            {
                _clrg_date = value;
                RaisePropertyChanged("clrg_date");
            }
        }
        private DateTime? _clrg_entry_date;
        public DateTime? clrg_entry_date
        {
            get { return _clrg_entry_date; }
            set
            {
                _clrg_entry_date = value;
                RaisePropertyChanged("clrg_entry_date");
            }
        }
        private string _clrg_doc_no;
        public string clrg_doc_no
        {
            get { return _clrg_doc_no; }
            set
            {
                _clrg_doc_no = value;
                RaisePropertyChanged("clrg_doc_no");
            }
        }
        private string _posting_key;
        public string posting_key
        {
            get { return _posting_key; }
            set
            {
                _posting_key = value;
                RaisePropertyChanged("posting_key");
            }
        }
        private string _acc_type;
        public string acc_type
        {
            get { return _acc_type; }
            set
            {
                _acc_type = value;
                RaisePropertyChanged("acc_type");
            }
        }
        private string _gl_code;
        public string gl_code
        {
            get { return _gl_code; }
            set
            {
                _gl_code = value;
                RaisePropertyChanged("gl_code");
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
        private string _ind_gl;
        public string ind_gl
        {
            get { return _ind_gl; }
            set
            {
                _ind_gl = value;
                RaisePropertyChanged("ind_gl");
            }
        }
        private string _sp_gltype;
        public string sp_gltype
        {
            get { return _sp_gltype; }
            set
            {
                _sp_gltype = value;
                RaisePropertyChanged("sp_gltype");
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
        private decimal? _exc_rate;
        public decimal? exc_rate
        {
            get { return _exc_rate; }
            set
            {
                _exc_rate = value;
                RaisePropertyChanged("exc_rate", ModelEntityUpdated);
            }
        }
        private string _local_curr_code;
        public string local_curr_code
        {
            get { return _local_curr_code; }
            set
            {
                _local_curr_code = value;
                RaisePropertyChanged("local_curr_code", ModelEntityUpdated);
            }
        }
        private string _dc_ind;
        public string dc_ind
        {
            get { return _dc_ind; }
            set
            {
                _dc_ind = value;
                RaisePropertyChanged("dc_ind", ModelEntityUpdated);
            }
        }
        private decimal? _doc_curr_amt;
        public decimal? doc_curr_amt
        {
            get { return _doc_curr_amt; }
            set
            {
                _doc_curr_amt = value;
                RaisePropertyChanged("doc_curr_amt", ModelEntityUpdated);
            }
        }
        private decimal? _loc_curr_amt;
        public decimal? loc_curr_amt
        {
            get { return _loc_curr_amt; }
            set
            {
                _loc_curr_amt = value;
                RaisePropertyChanged("loc_curr_amt", ModelEntityUpdated);
            }
        }

        private string _analysis_code;
        public string analysis_code
        {
            get { return _analysis_code; }
            set
            {
                _analysis_code = value;
                RaisePropertyChanged("analysis_code");
            }
        }
        private string _cost_center;
        public string cost_center
        {
            get { return _cost_center; }
            set
            {
                _cost_center = value;
                RaisePropertyChanged("cost_center");
            }
        }
        private string _tax_code;
        public string tax_code
        {
            get { return _tax_code; }
            set
            {
                _tax_code = value;
                RaisePropertyChanged("tax_code");
            }
        }
        private decimal? _amt_loc_taxbase;
        public decimal? amt_loc_taxbase
        {
            get { return _amt_loc_taxbase; }
            set
            {
                _amt_loc_taxbase = value;
                RaisePropertyChanged("amt_loc_taxbase");
            }
        }
        private decimal? _amt_doc_taxbase;
        public decimal? amt_doc_taxbase
        {
            get { return _amt_doc_taxbase; }
            set
            {
                _amt_doc_taxbase = value;
                RaisePropertyChanged("amt_doc_taxbase");
            }
        }
        private decimal? _amt_tax_local_curr;
        public decimal? amt_tax_local_curr
        {
            get { return _amt_tax_local_curr; }
            set
            {
                _amt_tax_local_curr = value;
                RaisePropertyChanged("amt_tax_local_curr");
            }
        }
        private decimal? _amt_tax_doc_curr;
        public decimal? amt_tax_doc_curr
        {
            get { return _amt_tax_doc_curr; }
            set
            {
                _amt_tax_doc_curr = value;
                RaisePropertyChanged("amt_tax_doc_curr");
            }
        }
        private decimal? _amt_taxbase_local_curr;
        public decimal? amt_taxbase_local_curr
        {
            get { return _amt_taxbase_local_curr; }
            set
            {
                _amt_taxbase_local_curr = value;
                RaisePropertyChanged("amt_taxbase_local_curr");
            }
        }
        private decimal? _amt_taxbase_doc_curr;
        public decimal? amt_taxbase_doc_curr
        {
            get { return _amt_taxbase_doc_curr; }
            set
            {
                _amt_taxbase_doc_curr = value;
                RaisePropertyChanged("amt_taxbase_doc_curr");
            }
        }
        private string _ds_cash;
        public string ds_cash
        {
            get { return _ds_cash; }
            set
            {
                _ds_cash = value;
                RaisePropertyChanged("ds_cash");
            }
        }
        private decimal? _amt_withhold_tax;
        public decimal? amt_withhold_tax
        {
            get { return _amt_withhold_tax; }
            set
            {
                _amt_withhold_tax = value;
                RaisePropertyChanged("amt_withhold_tax");
            }
        }
        private decimal? _headge_rate;
        public decimal? headge_rate
        {
            get { return _headge_rate; }
            set
            {
                _headge_rate = value;
                RaisePropertyChanged("headge_rate");
            }
        }
        private decimal? _amt_headge;
        public decimal? amt_headge
        {
            get { return _amt_headge; }
            set
            {
                _amt_headge = value;
                RaisePropertyChanged("amt_headge");
            }
        }
        private decimal? _value_diff;
        public decimal? value_diff
        {
            get { return _value_diff; }
            set
            {
                _value_diff = value;
                RaisePropertyChanged("value_diff");
            }
        }
        private decimal? _value_diff_sec_curr;
        public decimal? value_diff_sec_curr
        {
            get { return _value_diff_sec_curr; }
            set
            {
                _value_diff_sec_curr = value;
                RaisePropertyChanged("value_diff_sec_curr");
            }
        }
        private string _assign_no;
        public string assign_no
        {
            get { return _assign_no; }
            set
            {
                _assign_no = value;
                RaisePropertyChanged("assign_no");
            }
        }
        private string _item_text;
        public string item_text
        {
            get { return _item_text; }
            set
            {
                _item_text = value;
                RaisePropertyChanged("item_text");
            }
        }
        private string _expt_int;
        public string expt_int
        {
            get { return _expt_int; }
            set
            {
                _expt_int = value;
                RaisePropertyChanged("expt_int");
            }
        }
        private string _group_acc_no;
        public string group_acc_no
        {
            get { return _group_acc_no; }
            set
            {
                _group_acc_no = value;
                RaisePropertyChanged("group_acc_no");
            }
        }
        private string _gl_trns_type;
        public string gl_trns_type
        {
            get { return _gl_trns_type; }
            set
            {
                _gl_trns_type = value;
                RaisePropertyChanged("gl_trns_type");
            }
        }
        private string _PartyId;
        public string PartyId
        {
            get { return _PartyId; }
            set
            {
                _PartyId = value;
                RaisePropertyChanged("PartyId");
            }
        }
        private string _vendor_no;
        public string vendor_no
        {
            get { return _vendor_no; }
            set
            {
                _vendor_no = value;
                RaisePropertyChanged("vendor_no");
            }
        }
        private string _ind_bal_sheet;
        public string ind_bal_sheet
        {
            get { return _ind_bal_sheet; }
            set
            {
                _ind_bal_sheet = value;
                RaisePropertyChanged("ind_bal_sheet");
            }
        }
        private string _pl_acctype;
        public string pl_acctype
        {
            get { return _pl_acctype; }
            set
            {
                _pl_acctype = value;
                RaisePropertyChanged("pl_acctype");
            }
        }
        private string _gl_assign;
        public string gl_assign
        {
            get { return _gl_assign; }
            set
            {
                _gl_assign = value;
                RaisePropertyChanged("gl_assign");
            }
        }
        private string _plan_level;
        public string plan_level
        {
            get { return _plan_level; }
            set
            {
                _plan_level = value;
                RaisePropertyChanged("plan_level");
            }
        }
        private string _plan_group;
        public string plan_group
        {
            get { return _plan_group; }
            set
            {
                _plan_group = value;
                RaisePropertyChanged("plan_group");
            }
        }
        private decimal? _amt_plan;
        public decimal? amt_plan
        {
            get { return _amt_plan; }
            set
            {
                _amt_plan = value;
                RaisePropertyChanged("amt_plan");
            }
        }
        private DateTime? _plan_date;
        public DateTime? plan_date
        {
            get { return _plan_date; }
            set
            {
                _plan_date = value;
                RaisePropertyChanged("plan_date");
            }
        }
        private string _budget_item;
        public string budget_item
        {
            get { return _budget_item; }
            set
            {
                _budget_item = value;
                RaisePropertyChanged("budget_item");
            }
        }
        private string _control_area;
        public string control_area
        {
            get { return _control_area; }
            set
            {
                _control_area = value;
                RaisePropertyChanged("control_area");
            }
        }
        private string _order_no;
        public string order_no
        {
            get { return _order_no; }
            set
            {
                _order_no = value;
                RaisePropertyChanged("order_no");
            }
        }
        private string _bill_doc;
        public string bill_doc
        {
            get { return _bill_doc; }
            set
            {
                _bill_doc = value;
                RaisePropertyChanged("bill_doc");
            }
        }
        private string _sales_doc;
        public string sales_doc
        {
            get { return _sales_doc; }
            set
            {
                _sales_doc = value;
                RaisePropertyChanged("sales_doc");
            }
        }
        private int? _sales_doc_item;
        public int? sales_doc_item
        {
            get { return _sales_doc_item; }
            set
            {
                _sales_doc_item = value;
                RaisePropertyChanged("sales_doc_item");
            }
        }
        private int? _del_sch_lineno;
        public int? del_sch_lineno
        {
            get { return _del_sch_lineno; }
            set
            {
                _del_sch_lineno = value;
                RaisePropertyChanged("del_sch_lineno");
            }
        }
        private string _main_asset_no;
        public string main_asset_no
        {
            get { return _main_asset_no; }
            set
            {
                _main_asset_no = value;
                RaisePropertyChanged("main_asset_no");
            }
        }
        private string _asse_subno;
        public string asse_subno
        {
            get { return _asse_subno; }
            set
            {
                _asse_subno = value;
                RaisePropertyChanged("asse_subno");
            }
        }
        private string _asset_trns_type;
        public string asset_trns_type
        {
            get { return _asset_trns_type; }
            set
            {
                _asset_trns_type = value;
                RaisePropertyChanged("asset_trns_type");
            }
        }
        private DateTime? _asset_value_date;
        public DateTime? asset_value_date
        {
            get { return _asset_value_date; }
            set
            {
                _asset_value_date = value;
                RaisePropertyChanged("asset_value_date");
            }
        }
        private decimal? _cash_disc1;
        public decimal? cash_disc1
        {
            get { return _cash_disc1; }
            set
            {
                _cash_disc1 = value;
                RaisePropertyChanged("cash_disc1");
            }
        }
        private decimal? _cash_disc2;
        public decimal? cash_disc2
        {
            get { return _cash_disc2; }
            set
            {
                _cash_disc2 = value;
                RaisePropertyChanged("cash_disc2");
            }
        }
        private string _payterm_key;
        public string payterm_key
        {
            get { return _payterm_key; }
            set
            {
                _payterm_key = value;
                RaisePropertyChanged("payterm_key");
            }
        }
        private decimal? _payterm_period;
        public decimal? payterm_period
        {
            get { return _payterm_period; }
            set
            {
                _payterm_period = value;
                RaisePropertyChanged("payterm_period");
            }
        }
        private decimal? _disc_per1;
        public decimal? disc_per1
        {
            get { return _disc_per1; }
            set
            {
                _disc_per1 = value;
                RaisePropertyChanged("disc_per1");
            }
        }
        private decimal? _disc_per2;
        public decimal? disc_per2
        {
            get { return _disc_per2; }
            set
            {
                _disc_per2 = value;
                RaisePropertyChanged("disc_per2");
            }
        }
        private decimal? _amt_cd_eligible;
        public decimal? amt_cd_eligible
        {
            get { return _amt_cd_eligible; }
            set
            {
                _amt_cd_eligible = value;
                RaisePropertyChanged("amt_cd_eligible");
            }
        }
        private decimal? _cd_loc_curr;
        public decimal? cd_loc_curr
        {
            get { return _cd_loc_curr; }
            set
            {
                _cd_loc_curr = value;
                RaisePropertyChanged("cd_loc_curr");
            }
        }
        private decimal? _cd_doc_curr;
        public decimal? cd_doc_curr
        {
            get { return _cd_doc_curr; }
            set
            {
                _cd_doc_curr = value;
                RaisePropertyChanged("cd_doc_curr");
            }
        }
        private string _pay_method;
        public string pay_method
        {
            get { return _pay_method; }
            set
            {
                _pay_method = value;
                RaisePropertyChanged("pay_method");
            }
        }
        private string _pay_block_key;
        public string pay_block_key
        {
            get { return _pay_block_key; }
            set
            {
                _pay_block_key = value;
                RaisePropertyChanged("pay_block_key");
            }
        }
        private string _fix_payterm;
        public string fix_payterm
        {
            get { return _fix_payterm; }
            set
            {
                _fix_payterm = value;
                RaisePropertyChanged("fix_payterm");
            }
        }
        private string _hb_key;
        public string hb_key
        {
            get { return _hb_key; }
            set
            {
                _hb_key = value;
                RaisePropertyChanged("hb_key");
            }
        }
        private string _partner_bank_type;
        public string partner_bank_type
        {
            get { return _partner_bank_type; }
            set
            {
                _partner_bank_type = value;
                RaisePropertyChanged("partner_bank_type");
            }
        }
        private decimal? _net_pay_amt;
        public decimal? net_pay_amt
        {
            get { return _net_pay_amt; }
            set
            {
                _net_pay_amt = value;
                RaisePropertyChanged("net_pay_amt");
            }
        }
        private string _tax_code_dist;
        public string tax_code_dist
        {
            get { return _tax_code_dist; }
            set
            {
                _tax_code_dist = value;
                RaisePropertyChanged("tax_code_dist");
            }
        }
        private decimal? _amt_taxdist_local_curr;
        public decimal? amt_taxdist_local_curr
        {
            get { return _amt_taxdist_local_curr; }
            set
            {
                _amt_taxdist_local_curr = value;
                RaisePropertyChanged("amt_taxdist_local_curr");
            }
        }
        private decimal? _amt_taxdist_for_curr;
        public decimal? amt_taxdist_for_curr
        {
            get { return _amt_taxdist_for_curr; }
            set
            {
                _amt_taxdist_for_curr = value;
                RaisePropertyChanged("amt_taxdist_for_curr");
            }
        }
        private int? _no_of_inv;
        public int? no_of_inv
        {
            get { return _no_of_inv; }
            set
            {
                _no_of_inv = value;
                RaisePropertyChanged("no_of_inv");
            }
        }
        private string _fin_year_inv;
        public string fin_year_inv
        {
            get { return _fin_year_inv; }
            set
            {
                _fin_year_inv = value;
                RaisePropertyChanged("fin_year_inv");
            }
        }
        private int? _line_item_inv;
        public int? line_item_inv
        {
            get { return _line_item_inv; }
            set
            {
                _line_item_inv = value;
                RaisePropertyChanged("line_item_inv");
            }
        }
        private string _ex_bill_no;
        public string ex_bill_no
        {
            get { return _ex_bill_no; }
            set
            {
                _ex_bill_no = value;
                RaisePropertyChanged("ex_bill_no");
            }
        }
        private string _ex_bill_finyear;
        public string ex_bill_finyear
        {
            get { return _ex_bill_finyear; }
            set
            {
                _ex_bill_finyear = value;
                RaisePropertyChanged("ex_bill_finyear");
            }
        }
        private int? _ex_bill_line;
        public int? ex_bill_line
        {
            get { return _ex_bill_line; }
            set
            {
                _ex_bill_line = value;
                RaisePropertyChanged("ex_bill_line");
            }
        }
        private string _ex_bill_usage;
        public string ex_bill_usage
        {
            get { return _ex_bill_usage; }
            set
            {
                _ex_bill_usage = value;
                RaisePropertyChanged("ex_bill_usage");
            }
        }
        private string _ex_bill_doc;
        public string ex_bill_doc
        {
            get { return _ex_bill_doc; }
            set
            {
                _ex_bill_doc = value;
                RaisePropertyChanged("ex_bill_doc");
            }
        }
        private string _ex_bill_req;
        public string ex_bill_req
        {
            get { return _ex_bill_req; }
            set
            {
                _ex_bill_req = value;
                RaisePropertyChanged("ex_bill_req");
            }
        }
        private string _ex_bill_comp;
        public string ex_bill_comp
        {
            get { return _ex_bill_comp; }
            set
            {
                _ex_bill_comp = value;
                RaisePropertyChanged("ex_bill_comp");
            }
        }
        private DateTime? _ex_bill_duedate;
        public DateTime? ex_bill_duedate
        {
            get { return _ex_bill_duedate; }
            set
            {
                _ex_bill_duedate = value;
                RaisePropertyChanged("ex_bill_duedate");
            }
        }
        private string _ItemCode;
        public string ItemCode
        {
            get { return _ItemCode; }
            set
            {
                _ItemCode = value;
                RaisePropertyChanged("ItemCode");
            }
        }
        private string _plant_code;
        public string plant_code
        {
            get { return _plant_code; }
            set
            {
                _plant_code = value;
                RaisePropertyChanged("plant_code");
            }
        }
        private decimal? _qty;
        public decimal? qty
        {
            get { return _qty; }
            set
            {
                _qty = value;
                RaisePropertyChanged("qty", ModelEntityUpdated);
            }
        }
        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set
            {
                _unit_code = value;
                RaisePropertyChanged("unit_code");
            }
        }
        private decimal? _qty_unit;
        public decimal? qty_unit
        {
            get { return _qty_unit; }
            set
            {
                _qty_unit = value;
                RaisePropertyChanged("qty_unit");
            }
        }
        private decimal? _qty_pur;
        public decimal? qty_pur
        {
            get { return _qty_pur; }
            set
            {
                _qty_pur = value;
                RaisePropertyChanged("qty_pur");
            }
        }
        private decimal? _order_price;
        public decimal? order_price
        {
            get { return _order_price; }
            set
            {
                _order_price = value;
                RaisePropertyChanged("order_price");
            }
        }
        private string _po_no;
        public string po_no
        {
            get { return _po_no; }
            set
            {
                _po_no = value;
                RaisePropertyChanged("po_no");
            }
        }
        private int? _po_item_no;
        public int? po_item_no
        {
            get { return _po_item_no; }
            set
            {
                _po_item_no = value;
                RaisePropertyChanged("po_item_no");
            }
        }
        private int? _seq_assign;
        public int? seq_assign
        {
            get { return _seq_assign; }
            set
            {
                _seq_assign = value;
                RaisePropertyChanged("seq_assign");
            }
        }
        private string _ind_delivery;
        public string ind_delivery
        {
            get { return _ind_delivery; }
            set
            {
                _ind_delivery = value;
                RaisePropertyChanged("ind_delivery");
            }
        }
        private string _base_unit;
        public string base_unit
        {
            get { return _base_unit; }
            set
            {
                _base_unit = value;
                RaisePropertyChanged("base_unit");
            }
        }
        private decimal? _price_unit;
        public decimal? price_unit
        {
            get { return _price_unit; }
            set
            {
                _price_unit = value;
                RaisePropertyChanged("price_unit");
            }
        }
        private string _value_type;
        public string value_type
        {
            get { return _value_type; }
            set
            {
                _value_type = value;
                RaisePropertyChanged("value_type");
            }
        }
        private decimal? _inv_val_loc;
        public decimal? inv_val_loc
        {
            get { return _inv_val_loc; }
            set
            {
                _inv_val_loc = value;
                RaisePropertyChanged("inv_val_loc");
            }
        }
        private decimal? _inv_val_for;
        public decimal? inv_val_for
        {
            get { return _inv_val_for; }
            set
            {
                _inv_val_for = value;
                RaisePropertyChanged("inv_val_for");
            }
        }
        private decimal? _amt_qual_loc;
        public decimal? amt_qual_loc
        {
            get { return _amt_qual_loc; }
            set
            {
                _amt_qual_loc = value;
                RaisePropertyChanged("amt_qual_loc");
            }
        }
        private string _block_price;
        public string block_price
        {
            get { return _block_price; }
            set
            {
                _block_price = value;
                RaisePropertyChanged("block_price");
            }
        }
        private string _block_qty;
        public string block_qty
        {
            get { return _block_qty; }
            set
            {
                _block_qty = value;
                RaisePropertyChanged("block_qty");
            }
        }
        private string _block_date;
        public string block_date
        {
            get { return _block_date; }
            set
            {
                _block_date = value;
                RaisePropertyChanged("block_date");
            }
        }
        private string _block_orderpriceqty;
        public string block_orderpriceqty
        {
            get { return _block_orderpriceqty; }
            set
            {
                _block_orderpriceqty = value;
                RaisePropertyChanged("block_orderpriceqty");
            }
        }
        private string _block_project;
        public string block_project
        {
            get { return _block_project; }
            set
            {
                _block_project = value;
                RaisePropertyChanged("block_project");
            }
        }
        private string _block_manual;
        public string block_manual
        {
            get { return _block_manual; }
            set
            {
                _block_manual = value;
                RaisePropertyChanged("block_manual");
            }
        }
        private string _vat_no;
        public string vat_no
        {
            get { return _vat_no; }
            set
            {
                _vat_no = value;
                RaisePropertyChanged("vat_no");
            }
        }
        private string _dest_country;
        public string dest_country
        {
            get { return _dest_country; }
            set
            {
                _dest_country = value;
                RaisePropertyChanged("dest_country");
            }
        }
        private string _country_code;
        public string country_code
        {
            get { return _country_code; }
            set
            {
                _country_code = value;
                RaisePropertyChanged("country_code");
            }
        }
        private string _reason_code;
        public string reason_code
        {
            get { return _reason_code; }
            set
            {
                _reason_code = value;
                RaisePropertyChanged("reason_code");
            }
        }
        private decimal? _ex_rate_rea;
        public decimal? ex_rate_rea
        {
            get { return _ex_rate_rea; }
            set
            {
                _ex_rate_rea = value;
                RaisePropertyChanged("ex_rate_rea");
            }
        }
        private decimal? _ex_rate_diff;
        public decimal? ex_rate_diff
        {
            get { return _ex_rate_diff; }
            set
            {
                _ex_rate_diff = value;
                RaisePropertyChanged("ex_rate_diff");
            }
        }
        private string _profit_center;
        public string profit_center
        {
            get { return _profit_center; }
            set
            {
                _profit_center = value;
                RaisePropertyChanged("profit_center");
            }
        }
        private string _gl_assign_man;
        public string gl_assign_man
        {
            get { return _gl_assign_man; }
            set
            {
                _gl_assign_man = value;
                RaisePropertyChanged("gl_assign_man");
            }
        }
        private string _equity_group;
        public string equity_group
        {
            get { return _gl_assign_man; }
            set
            {
                _gl_assign_man = value;
                RaisePropertyChanged("gl_assign_man");
            }
        }
        private string _tax_jurisdiction;
        public string tax_jurisdiction
        {
            get { return _tax_jurisdiction; }
            set
            {
                _tax_jurisdiction = value;
                RaisePropertyChanged("tax_jurisdiction");
            }
        }
        private string _payroll_type;
        public string payroll_type
        {
            get { return _payroll_type; }
            set
            {
                _payroll_type = value;
                RaisePropertyChanged("payroll_type");
            }
        }
        private string _payee_payer;
        public string payee_payer
        {
            get { return _payee_payer; }
            set
            {
                _payee_payer = value;
                RaisePropertyChanged("payee_payer");
            }
        }
        private int? _inst1;
        public int? inst1
        {
            get { return _inst1; }
            set
            {
                _inst1 = value;
                RaisePropertyChanged("inst1");
            }
        }
        private int? _inst2;
        public int? inst2
        {
            get { return _inst2; }
            set
            {
                _inst2 = value;
                RaisePropertyChanged("inst2");
            }
        }
        
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                _comp_code = value;
                RaisePropertyChanged("comp_code");
            }
        }
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                _location_Id = value;
                RaisePropertyChanged("location_Id");
            }
        }
        private string _fin_year;
        public string fin_year
        {
            get { return _fin_year; }
            set
            {
                _fin_year = value;
                RaisePropertyChanged("fin_year");
            }
        }
        private string _posting_period;
        public string posting_period
        {
            get { return _posting_period; }
            set
            {
                _posting_period = value;
                RaisePropertyChanged("posting_period");
            }
        }
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set
            {
                _add_by = value;
                RaisePropertyChanged("add_by");
            }
        }
        private DateTime _add_date;
        public DateTime add_date
        {
            get { return _add_date; }
            set
            {
                _add_date = value;
                RaisePropertyChanged("add_date");
            }
        }
        private string _editby;
        public string editby
        {
            get { return _editby; }
            set
            {
                _editby = value;
                RaisePropertyChanged("editby");
            }
        }
        private DateTime? _edit_date;
        public DateTime? edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value;
                RaisePropertyChanged("edit_date");
            }
        }
        private string _remark;
        public string remark
        {
            get { return _remark; }
            set
            {
                _remark = value;
                RaisePropertyChanged("remark");
            }
        }
        private bool? _active;
        public bool? active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active", ModelEntityUpdated);
            }
        }
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set
            {
                _t_status = value;
                RaisePropertyChanged("t_status");
            }
        }
        
        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set
            {
                _doc_cat = value;
                RaisePropertyChanged("doc_cat");
            }
        }
        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set
            {
                _doc_type = value;
                RaisePropertyChanged("doc_type");
            }
        }
        private DateTime _doc_date;
        public DateTime doc_date
        {
            get { return _doc_date; }
            set
            {
                _doc_date = value;
                RaisePropertyChanged("doc_date");
            }
        }
        private string _ref_doc_no;
        public string ref_doc_no
        {
            get { return _ref_doc_no; }
            set
            {
                _ref_doc_no = value;
                RaisePropertyChanged("ref_doc_no");
            }
        }

        private string _ref_doc_type;
        public string ref_doc_type
        {
            get { return _ref_doc_type; }
            set
            {
                _ref_doc_type = value;
                RaisePropertyChanged("ref_doc_type");
            }
        }
        private string _ref_doc_cat;
        public string ref_doc_cat
        {
            get { return _ref_doc_cat; }
            set
            {
                _ref_doc_cat = value;
                RaisePropertyChanged("ref_doc_cat");
            }
        }
        private int _analytical_id;
        public int analytical_id
        {
            get { return _analytical_id; }
            set
            {
                _analytical_id = value;
                RaisePropertyChanged("analytical_id");
            }
        }
        private decimal? _debit_amt;
        public decimal? debit_amt
        {
            get { return _debit_amt; }
            set
            {
                _debit_amt = value;
                RaisePropertyChanged("debit_amt");
            }
        }
        private decimal? _credit_amt;
        public decimal? credit_amt
        {
            get { return _credit_amt; }
            set
            {
                _credit_amt = value;
                RaisePropertyChanged("credit_amt");
            }
        }
        private decimal? _balance_amt;
        public decimal? balance_amt
        {
            get { return _balance_amt; }
            set
            {
                _balance_amt = value;
                RaisePropertyChanged("balance_amt");
            }
        }
        private string _TranCode;
        public string TranCode
        {
            get { return _TranCode; }
            set
            {
                _TranCode = value;
                RaisePropertyChanged("TranCode");
            }
        }
        private decimal? _amt_residual;
        public decimal? amt_residual
        {
            get { return _amt_residual; }
            set
            {
                _amt_residual = value;
                RaisePropertyChanged("amt_residual");
            }
        }
        private string _amt_residual_curr;
        public string amt_residual_curr
        {
            get { return _amt_residual_curr; }
            set
            {
                _amt_residual_curr = value;
                RaisePropertyChanged("amt_residual_curr");
            }
        }
        private bool? _reconcile;
        public bool? reconcile
        {
            get { return _reconcile; }
            set
            {
                _reconcile = value;
                RaisePropertyChanged("reconcile");
            }
        }

        private string _party_ref_no;
        public string party_ref_no
        {
            get { return _party_ref_no; }
            set
            {
                _party_ref_no = value;
                RaisePropertyChanged("party_ref_no");
            }
        }

        private Nullable<int> _ref_doc_item_row_id;
        public Nullable<int> ref_doc_item_row_id
        {
            get { return _ref_doc_item_row_id; }
            set
            {
                _ref_doc_item_row_id = value;
                RaisePropertyChanged("ref_doc_item_row_id");
            }
        }

        private Nullable<int> _ref_doc_line_id;
        public Nullable<int> ref_doc_line_id
        {
            get { return _ref_doc_line_id; }
            set
            {
                _ref_doc_line_id = value;
                RaisePropertyChanged("ref_doc_line_id");
            }
        }

        private Nullable<int> _parent_row_id;
        public Nullable<int> parent_row_id
        {
            get { return _parent_row_id; }
            set
            {
                _parent_row_id = value;
                RaisePropertyChanged("parent_row_id");
            }
        }

        private Nullable<int> _parent_ref_doc_row_id;
        public Nullable<int> parent_ref_doc_row_id
        {
            get { return _parent_ref_doc_row_id; }
            set
            {
                _parent_ref_doc_row_id = value;
                RaisePropertyChanged("parent_ref_doc_row_id");
            }
        }

        private string _trns_key_code;
        public string trns_key_code
        {
            get { return _trns_key_code; }
            set
            {
                _trns_key_code = value;
                RaisePropertyChanged("trns_key_code");
            }
        }

        private Nullable<System.DateTime> _post_date;
        public Nullable<System.DateTime> post_date
        {
            get { return _post_date; }
            set
            {
                _post_date = value;
                RaisePropertyChanged("post_date");
            }
        }

        #region .Scalars fro ACC_T006_A.
        private string _gl_name;
        public string gl_name
        {
            get { return _gl_name; }
            set
            {
                _gl_name = value;
                RaisePropertyChanged("gl_name");
            }
        }

        private string _PartyNm;
        public string PartyNm
        {
            get { return _PartyNm; }
            set
            {
                _PartyNm = value;
                RaisePropertyChanged("PartyNm");
            }
        }

        private string _t_display;
        public string t_display
        {
            get { return _t_display; }
            set
            {
                _t_display = value;
                RaisePropertyChanged("t_display");
            }
        }

        private string _ledger_gen_desc;
        public string ledger_gen_desc
        {
            get { return _ledger_gen_desc; }
            set { _ledger_gen_desc = value; RaisePropertyChanged("ledger_gen_desc"); }

        }
        #endregion
    }
    public class MultipleContext_ACC_T006 : MC_FICO_BE
    {
        //public List<ADM_M0013> STATUS_LIST { get; set; }
        //public List<STD_DOC_TYPE> DOC_TYPE_LIST { get; set; }
        public List<ACC_T006> MasterData { get; set; }
        public ObservableCollection<ACC_T006_A> DetailData { get; set; }
        public List<ADM_M028_P> PartyMaster { get; set; }
        public List<ACC_T002_Flip> FlipGridData { get; set; }
        public List<SEL_T003_PUR_T005_RefDoc> RefDocData { get; set; }
        public List<SYS_M015_P> DocTypeList { get; set; }
        public List<ACC_M027_P> PayMethodList { get; set; }
        public List<ADM_M037_P> CurrencyMaster { get; set; }
        public List<ACC_M003_P> GLCodeMaster { get; set; }
        public List<ACC_M019_P> CostCenterMaster { get; set; }
        public List<ACC_M022> JEType { get; set; }
        public List<VendorPopup> VendorDetails { get; set; }
        public List<ACC_M004_P> BanksMaster { get; set; }
        public List<ACC_M001A_P> PostingPeriodMaster { get; set; }
        public List<ACC_M001A_P> FinYearMaster { get; set; }
        public List<General_Ledger_P> GeneralLedgerList { get; set; }
        public List<ACC_M003_Q_P> PostingKeyList { get; set; }
        public List<ADM_M0013> t_statusList { get; set; }
        public List<COM_T003> AttachmentData { get; set; }
    }
}
