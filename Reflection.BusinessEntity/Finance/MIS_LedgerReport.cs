using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity.Finance
{
    public class MIS_LedgerReport : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private string _sr_no;
        public string sr_no
        {
            get { return _sr_no; }
            set
            {
                _sr_no = value;
                RaisePropertyChanged("sr_no");
            }
        }

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

        private string _LoctnNm;
        public string LoctnNm
        {
            get { return _LoctnNm; }
            set
            {
                _LoctnNm = value;
                RaisePropertyChanged("LoctnNm");
            }
        }
        private string _ac_group_code;
        public string ac_group_code
        {
            get { return _ac_group_code; }
            set
            {
                _ac_group_code = value;
                RaisePropertyChanged("ac_group_code");
            }
        }
        private string _ac_group_name;
        public string ac_group_name
        {
            get { return _ac_group_name; }
            set
            {
                _ac_group_name = value;
                RaisePropertyChanged("ac_group_name");
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
        private string _CompName;
        public string CompName
        {
            get { return _CompName; }
            set
            {
                _CompName = value;
                RaisePropertyChanged("CompName");
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
        private Nullable<System.DateTime> _doc_date;
        public Nullable<System.DateTime> doc_date
        {
            get { return _doc_date; }
            set
            {
                _doc_date = value;
                RaisePropertyChanged("doc_date");
            }
        }
        private string _opening;
        public string opening
        {
            get { return _opening; }
            set
            {
                _opening = value;
                RaisePropertyChanged("opening");
            }
        }
        private string _Opening;
        public string Opening
        {
            get { return _Opening; }
            set
            {
                _Opening = value;
                RaisePropertyChanged("Opening");
            }
        }
        private string _Debit;
        public string Debit
        {
            get { return _Debit; }
            set
            {
                _Debit = value;
                RaisePropertyChanged("Debit");
            }
        }

        private string _Credit;
        public string Credit
        {
            get { return _Credit; }
            set
            {
                _Credit = value;
                RaisePropertyChanged("Credit");
            }
        }
        private decimal _closing;
        public decimal closing
        {
            get { return _closing; }
            set
            {
                _closing = value;
                RaisePropertyChanged("closing");
            }
        }
        private string _Closing;
        public string Closing
        {
            get { return _Closing; }
            set
            {
                _Closing = value;
                RaisePropertyChanged("Closing");
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
        private Nullable<DateTime> _FromDate;
        public Nullable<DateTime> FromDate
        {
            get { return _FromDate; }
            set
            {
                _FromDate = value;
                RaisePropertyChanged("FromDate");
            }
        }

        private Nullable<DateTime> _ToDate;
        public Nullable<DateTime> ToDate
        {
            get { return _ToDate; }
            set
            {
                _ToDate = value;
                RaisePropertyChanged("ToDate");
            }
        }

        private string _Balance;
        public string Balance
        {
            get { return _Balance; }
            set
            {
                _Balance = value;
                RaisePropertyChanged("Balance");
            }
        }
        private decimal? _Closing1;
        public decimal? Closing1
        {
            get { return _Closing1; }
            set
            {
                _Closing1 = value;
                RaisePropertyChanged("Closing1");
            }
        }
        private decimal? _balance1;
        public decimal? balance1
        {
            get { return _balance1; }
            set
            {
                _balance1 = value;
                RaisePropertyChanged("balance1");
            }
        }
        private string _doc_desc;
        public string doc_desc
        {
            get { return _doc_desc; }
            set
            {
                _doc_desc = value;
                RaisePropertyChanged("doc_desc");
            }
        }
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                RaisePropertyChanged("Name");
            }
        }
        private string _ID;
        public string ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
                RaisePropertyChanged("ID");
            }
        }

        private string _dcat_name;
        public string dcat_name
        {
            get { return _dcat_name; }
            set
            {
                _dcat_name = value;
                RaisePropertyChanged("dcat_name");
            }
        }
        private string _cat_name;
        public string cat_name
        {
            get { return _cat_name; }
            set
            {
                _cat_name = value;
                RaisePropertyChanged("cat_name");
            }
        }
        private string _ReportType;
        public string ReportType
        {
            get { return _ReportType; }
            set
            {
                _ReportType = value;
                RaisePropertyChanged("ReportType");
            }
        }

        private bool _R1;
        public bool R1
        {
            get { return _R1; }
            set
            {
                _R1 = value;
                RaisePropertyChanged("R1");
            }
        }
        private bool _R2;
        public bool R2
        {
            get { return _R2; }
            set
            {
                _R2 = value;
                RaisePropertyChanged("R2");
            }
        }
        private bool _R3;
        public bool R3
        {
            get { return _R3; }
            set
            {
                _R3 = value;
                RaisePropertyChanged("R3");
            }
        }


        private string _ts_code;
        public string ts_code
        {
            get { return _ts_code; }
            set
            {
                _ts_code = value;
                RaisePropertyChanged("ts_code");
            }
        }

        private string _ts_namespace;
        public string ts_namespace
        {
            get { return _ts_namespace; }
            set
            {
                _ts_namespace = value;
                RaisePropertyChanged("ts_namespace");
            }
        }

        private string _ts_class_file;
        public string ts_class_file
        {
            get { return _ts_class_file; }
            set
            {
                _ts_class_file = value;
                RaisePropertyChanged("ts_class_file");
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

        private string _ledger_gen_name;
        public string ledger_gen_name
        {
            get { return _ledger_gen_name; }
            set
            {
                _ledger_gen_name = value;
                RaisePropertyChanged("ledger_gen_name");
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

    }

    public class MultipleContextMIS_FinanceLedgerReport
    {
        public List<MIS_LedgerReport> LedgerReportList { get; set; }
        public List<ACC_M003_A_P> AccGroupList { get; set; }
        public List<ACC_M003_P> AccLedgerList { get; set; }
        public List<ADM_M003_P> LocationList { get; set; }
        public List<ADM_M002_P> CompanyList { get; set; }
        public List<General_Ledger_P> GeneralLedgerList { get; set; }
        public List<PP_FICO_Ledger> LedgerList { get; set; }
    }
    public class MultipleContext_MISTrialBalance
    {
        public List<MIS_LedgerReport> TrialBalanceList { get; set; }
        public List<ADM_M002_P> CompanyList { get; set; }
    }
    public class MultipleContext_MIS_BalanceSheet
    {
        public List<MIS_LedgerReport> BalanceSheetList { get; set; }
        public List<ADM_M002_P> CompanyList { get; set; }
    }
    public class MultipleContext_MIS_ProfitAndLoss
    {
        public List<MIS_LedgerReport> ProfitLossList { get; set; }
        public List<ADM_M002_P> CompanyList { get; set; }

    }
    public class MultipleContextMIS_Finance_DayBook
    {
        public List<MIS_LedgerReport> DayBookList { get; set; }
        public List<ACC_M003_A_P> AccGroupList { get; set; }
        public List<ACC_M003_P> AccLedgerList { get; set; }
        public List<SYS_M014_P> DocCategoryList { get; set; }
        public List<ADM_M003_P> LocationList { get; set; }
        public List<ADM_M002_P> CompanyList { get; set; }
    }
}
