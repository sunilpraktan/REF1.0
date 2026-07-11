using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Reflection.BusinessEntity.ADM;

namespace Reflection.BusinessEntity.Finance
{
    public partial class ACC_T004 : ObjectBase //Master
        {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set { _doc_no = value; RaisePropertyChanged("doc_no"); }
        }
        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set { _doc_cat = value; RaisePropertyChanged("doc_cat"); }
        }
        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set { _doc_type = value; RaisePropertyChanged("doc_type"); }
        }
        private Nullable<System.DateTime> _doc_date;
        public Nullable<System.DateTime> doc_date
        {
            get { return _doc_date; }
            set { _doc_date = value; RaisePropertyChanged("doc_date"); }
        }
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id"); }
        }
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }
        private string _PartyId;
        public string PartyId
        {
            get { return _PartyId; }
            set { _PartyId = value; RaisePropertyChanged("PartyId"); }

        }
        private string _fin_year;
        public string fin_year
        {
            get { return _fin_year; }
            set { _fin_year = value; RaisePropertyChanged("fin_year"); }

        }
        private string _posting_period;
        public string posting_period
        {
            get { return _posting_period; }
            set { _posting_period = value; RaisePropertyChanged("posting_period"); }

        }
        private string _gl_code;
        public string gl_code
        {
            get { return _gl_code; }
            set { _gl_code = value; RaisePropertyChanged("gl_code"); }

        }
        private string _gl_name;
        public string gl_name
        {
            get { return _gl_name; }
            set { _gl_name = value; RaisePropertyChanged("gl_name"); }

        }

        private Nullable<decimal> _credit_balance;
        public Nullable<decimal> credit_balance
        {
            get { return _credit_balance; }
            set { _credit_balance = value; RaisePropertyChanged("credit_balance"); }

        }

        private Nullable<decimal> _debit_balance;
        public Nullable<decimal> debit_balance
        {
            get { return _debit_balance; }
            set { _debit_balance = value; RaisePropertyChanged("debit_balance"); }

        }

        private Nullable<int> _para3;
        public Nullable<int> para3
        {
            get { return _para3; }
            set { _para3 = value; RaisePropertyChanged("para3"); }

        }

        private Nullable<decimal> _para6;
        public Nullable<decimal> para6
        {
            get { return _para6; }
            set { _para6 = value; RaisePropertyChanged("para6"); }
        }

        private Nullable<bool> _credit_amt;
        public Nullable<bool> credit_amt
        {
            get { return _credit_amt; }
            set { _credit_amt = value; RaisePropertyChanged("credit_amt"); }
        }

        private Nullable<bool> _debit_amt;
        public Nullable<bool> debit_amt
        {
            get { return _debit_amt; }
            set { _debit_amt = value; RaisePropertyChanged("debit_amt"); }
        }

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }

        }
        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
        }
        private string _editby;
        public string editby
        {
            get { return _editby; }
            set { _editby = value; RaisePropertyChanged("editby"); }

        }
        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }

        }
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }

        }
        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }

        }
        
        private string _language;
        public string language
        {
            get { return _language; }
            set { _language = value; RaisePropertyChanged("language"); }

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

        #region .Scalar Variables : ACC_T004.

        private decimal? _exc_rate;
        public decimal? exc_rate
        {
            get { return _exc_rate; }
            set
            {
                _exc_rate = value;
                RaisePropertyChanged("exc_rate");
            }
        }

        private string _short_desc;
        public string short_desc
        {
            get { return _short_desc; }
            set { _short_desc = value; RaisePropertyChanged("short_desc"); }

        }

        private int _post_per;
        public int post_per
        {
            get { return _post_per; }
            set { _post_per = value; RaisePropertyChanged("post_per"); }

        }

        private string _t_display;
        public string t_display
        {
            get { return _t_display; }
            set { _t_display = value; RaisePropertyChanged("t_display"); }

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

        private string _location_NM;
        public string location_NM
        {
            get { return _location_NM; }
            set { _location_NM = value; RaisePropertyChanged("location_NM"); }
        }

        public string XmlDataDocument_ACC_T004_A { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }

        #endregion
       
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

        #endregion
    }
    public partial class ACC_T004_A : ObjectBase //Detail
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
                set { _doc_no = value; RaisePropertyChanged("doc_no"); }

            }
         
            private string _location_Id;
            public string location_Id
            {
                get { return _location_Id; }
                set { _location_Id = value; RaisePropertyChanged("location_Id"); }

            }
            private string _comp_code;
            public string comp_code
            {
                get { return _comp_code; }
                set { _comp_code = value; RaisePropertyChanged("comp_code"); }

            }
            private string _t_status;
            public string t_status
            {
                get { return _t_status; }
                set { _t_status = value; RaisePropertyChanged("t_status"); }

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
                set { _add_by = value; RaisePropertyChanged("add_by"); }

            }
            private System.DateTime _add_date;
            public System.DateTime add_date
            {
                get { return _add_date; }
                set { _add_date = value; RaisePropertyChanged("add_date"); }

            }
            private string _editby;
            public string editby
            {
                get { return _editby; }
                set { _editby = value; RaisePropertyChanged("editby"); }

            }
            private Nullable<System.DateTime> _edit_date;
            public Nullable<System.DateTime> edit_date
            {
                get { return _edit_date; }
                set { _edit_date = value; RaisePropertyChanged("edit_date"); }

            }
            
            private Nullable<decimal> _para1;
            public Nullable<decimal> para1
            {
                get { return _para1; }
                set { _para1 = value; RaisePropertyChanged("para1"); }

            }
            private string _para2;
            public string para2
            {
                get { return _para2; }
                set { _para2 = value; RaisePropertyChanged("para2"); }

            }

            private string _para3;
            public string para3
            {
                get { return _para3; }
                set { _para3 = value; RaisePropertyChanged("para3"); }
            }

            private string _para4;
            public string para4
            {
                get { return _para4; }
                set { _para4 = value; RaisePropertyChanged("para4"); }
            }

            private string _para6;
            public string para6
            {
                get { return _para6; }
                set { _para6 = value; RaisePropertyChanged("para6"); }
            }

            private string _para7;
            public string para7
            {
                get { return _para7; }
                set { _para7 = value; RaisePropertyChanged("para7"); }
            }

            private string _ref_doc_no;
            public string ref_doc_no
            {
                get { return _ref_doc_no; }
                set { _ref_doc_no = value; RaisePropertyChanged("ref_doc_no"); }
            }

            private Nullable<System.DateTime> _ref_doc_date;
            public Nullable<System.DateTime> ref_doc_date
            {
                get { return _ref_doc_date; }
                set { _ref_doc_date = value; RaisePropertyChanged("ref_doc_date"); }
            }

            private string _ref_doc_type;
            public string ref_doc_type
            {
                get { return _ref_doc_type; }
                set { _ref_doc_type = value; RaisePropertyChanged("ref_doc_type"); }
            }

            private string _ref_doc_cat;
            public string ref_doc_cat
            {
                get { return _ref_doc_cat; }
                set { _ref_doc_cat = value; RaisePropertyChanged("ref_doc_cat"); }
            }

            private string _gl_code;
            public string gl_code
            {
                get { return _gl_code; }
                set { _gl_code = value; RaisePropertyChanged("gl_code"); }
            }

            private string _ledger_gen;
            public string ledger_gen
            {
                get { return _ledger_gen; }
                set { _ledger_gen = value; RaisePropertyChanged("ledger_gen"); }
            }

            private string _acc_type;
            public string acc_type
            {
                get { return _acc_type; }
                set { _acc_type = value; RaisePropertyChanged("acc_type"); }
            }

        
            private string _doc_curr_code;
            public string doc_curr_code
            {
                get { return _doc_curr_code; }
                set { _doc_curr_code = value; RaisePropertyChanged("doc_curr_code"); }
            }

            private string _dc_ind;
            public string dc_ind
            {
                get { return _dc_ind; }
                set { _dc_ind = value; RaisePropertyChanged("dc_ind"); }
            }

            private Nullable<decimal> _exc_rate;
            public Nullable<decimal> exc_rate
            {
                get { return _exc_rate; }
                set
                {
                    if (_exc_rate != value)
                    {
                        _exc_rate = value; RaisePropertyChanged("exc_rate", ModelEntityUpdated);
                    }
                }
            }

            private string _fin_year;
            public string fin_year
            {
                get { return _fin_year; }
                set { _fin_year = value; RaisePropertyChanged("fin_year"); }
            }

            private string _posting_period;
            public string posting_period
            {
                get { return _posting_period; }
                set { _posting_period = value; RaisePropertyChanged("posting_period"); }
            }

            private Nullable<decimal> _balance_amt_lc;
            public Nullable<decimal> balance_amt_lc
            {
                get { return _balance_amt_lc; }
                set { _balance_amt_lc = value; RaisePropertyChanged("balance_amt_lc"); }
            }

            private Nullable<decimal> _balance_amt_dc;
            public Nullable<decimal> balance_amt_dc
            {
                get { return _balance_amt_dc; }
                set { _balance_amt_dc = value; RaisePropertyChanged("balance_amt_dc"); }
            }

            private string _bill_doc_no;
            public string bill_doc_no
            {
                get { return _bill_doc_no; }
                set { _bill_doc_no = value; RaisePropertyChanged("bill_doc_no"); }
            }

            private Nullable<System.DateTime> _bill_doc_date;
            public Nullable<System.DateTime> bill_doc_date
            {
                get { return _bill_doc_date; }
                set { _bill_doc_date = value; RaisePropertyChanged("bill_doc_date"); }
            }

            private Nullable<decimal> _debit_amt_lc;
            public Nullable<decimal> debit_amt_lc
            {
                get { return _debit_amt_lc; }
                set { _debit_amt_lc = value; RaisePropertyChanged("debit_amt_lc"); }
            }

            private Nullable<decimal> _credit_amt_lc;
            public Nullable<decimal> credit_amt_lc
            {
                get { return _credit_amt_lc; }
                set { _credit_amt_lc = value; RaisePropertyChanged("credit_amt_lc"); }
            }

            private Nullable<decimal> _debit_amt_dc;
            public Nullable<decimal> debit_amt_dc
            {
                get { return _debit_amt_dc; }
                set
                {
                    if (_debit_amt_dc != value)
                    {
                        _debit_amt_dc = value; RaisePropertyChanged("debit_amt_dc", ModelEntityUpdated);
                    }  
                }
            }

            private Nullable<decimal> _credit_amt_dc;
            public Nullable<decimal> credit_amt_dc
            {
                get { return _credit_amt_dc; }
                set
                {
                    if (_credit_amt_dc != value)
                    {
                        _credit_amt_dc = value; RaisePropertyChanged("credit_amt_dc", ModelEntityUpdated);
                    }
                
                }
            }
            private string _doc_cat;
            public string doc_cat
            {
                get { return _doc_cat; }
                set { _doc_cat = value; RaisePropertyChanged("doc_cat"); }
            }
            private string _doc_type;
            public string doc_type
            {
                get { return _doc_type; }
                set { _doc_type = value; RaisePropertyChanged("doc_type"); }
            }
            

        private string _invoice_no;
        public string invoice_no
        {
            get { return _invoice_no; }
            set { _invoice_no = value; RaisePropertyChanged("invoice_no"); }

        }

        private Nullable<DateTime> _invoice_date;
        public Nullable<DateTime> invoice_date
        {
            get { return _invoice_date; }
            set
            {
                if (_invoice_date != value)
                {
                    _invoice_date = value; RaisePropertyChanged("invoice_date");
                }

            }
        }

        private Nullable<decimal> _balance_amt;
        public Nullable<decimal> balance_amt
        {
            get { return _balance_amt; }
            set
            {
                if (_balance_amt != value)
                {
                    _balance_amt = value; RaisePropertyChanged("balance_amt", ModelEntityUpdated);
                }

            }
        }

        #region . Scalar Variables : ACC_T004_A .

        private string _t_display;
            public string t_display
            {
                get { return _t_display; }
                set { _t_display = value; RaisePropertyChanged("t_display"); }

            }

            private string _ledger_gen_desc;
            public string ledger_gen_desc
            {
                get { return _ledger_gen_desc; }
                set { _ledger_gen_desc = value; RaisePropertyChanged("ledger_gen_desc"); }

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

        public int _line_id;
        public int line_id
        {
            get
            {
                return _line_id;
            }

            set
            {
                if (_line_id != value)
                {
                    _line_id = value; RaisePropertyChanged("line_id", ModelEntityUpdated);
                }
            }
        }
        #endregion
    }
    public class MultipleContext_ACC_T004
    {
        public List<ADM_M0013> STATUS_LIST { get; set; }
        public List<ACC_T004> MasterEntityList { get; set; }
        public ObservableCollection<ACC_T004_A> ItemsEntityList { get; set; }
        public List<ACC_T004_Flip> DocDataFlipGridList { get; set; }
        public List<General_Ledger_P> GeneralLedgerList { get; set; }
        public List<ACC_M001A_P> FinYearList { get; set; }
        public List<ACC_M001A_P> PostPeriodList { get; set; }
        public List<ACC_M003_P> GL_CodeDetailsList { get; set; }
        public List<ADM_M037_P> CurrencyList { get; set; }
        public List<SEL_T003_P> BillDocList { get; set; }
        public List<ADM_M0013> t_statusList { get; set; }
        public List<COM_T003> AttachmentList { get; set; }
       
    }
}
