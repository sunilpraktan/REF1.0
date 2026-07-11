using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity.CustomerRelation
{
    public class MIS_InsuranceEntity : ObjectBase
    {
        private Nullable<DateTime> _FromDate;
        public Nullable<DateTime> FromDate
        {
            get { return _FromDate; }
            set
            {
                if (_FromDate != value)
                {
                    _FromDate = value;
                    RaisePropertyChanged("FromDate");
                }
            }
        }

        private Nullable<DateTime> _ToDate;
        public Nullable<DateTime> ToDate
        {
            get { return _ToDate; }
            set
            {
                if (_ToDate != value)
                {
                    _ToDate = value;
                    RaisePropertyChanged("ToDate");
                }
            }
        }

        private string _Balance;
        public string Balance
        {
            get { return _Balance; }
            set
            {
                if (_Balance != value)
                {
                    _Balance = value;
                    RaisePropertyChanged("Balance");
                }
            }
        }

        private string _Duration;
        public string Duration
        {
            get { return _Duration; }
            set
            {
                if (_Duration != value)
                {
                    _Duration = value;
                    RaisePropertyChanged("Duration");
                }
            }
        }

        private string _ReportName;
        public string ReportName
        {
            get { return _ReportName; }
            set
            {
                if (_ReportName != value)
                {
                    _ReportName = value;
                    RaisePropertyChanged("ReportName");
                }
            }
        }

        private string _ReportCode;
        public string ReportCode
        {
            get { return _ReportCode; }
            set
            {
                if (_ReportCode != value)
                {
                    _ReportCode = value;
                    RaisePropertyChanged("ReportCode");
                }
            }
        }


        private string _PartyId;
        public string PartyId
        {
            get { return _PartyId; }
            set
            {
                if (_PartyId != value)
                {
                    _PartyId = value;
                    RaisePropertyChanged("PartyId");
                }
            }
        }

        private string _PartyNm;
        public string PartyNm
        {
            get { return _PartyNm; }
            set
            {
                if (_PartyNm != value)
                {
                    _PartyNm = value;
                    RaisePropertyChanged("PartyNm");
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
                    _location_Id = value;
                    RaisePropertyChanged("location_Id");
                }
            }
        }
        private string _LoctnNm;
        public string LoctnNm
        {
            get { return _LoctnNm; }
            set
            {
                if (_LoctnNm != value)
                {
                    _LoctnNm = value;
                    RaisePropertyChanged("LoctnNm");
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
                    _comp_code = value;
                    RaisePropertyChanged("comp_code");
                }
            }
        }
        private string _compName;
        public string CompName
        {
            get { return _compName; }
            set
            {
                if (_compName != value)
                {
                    _compName = value;
                    RaisePropertyChanged("CompName");
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
                    RaisePropertyChanged("doc_no");
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
                    _doc_cat = value;
                    RaisePropertyChanged("doc_cat");
                }
            }
        }

        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set
            {
                if (_doc_type != value)
                {
                    _doc_type = value;
                    RaisePropertyChanged("doc_type");
                }
            }
        }

        private string _para1;
        public string para1
        {
            get { return _para1; }
            set
            {
                if (_para1 != value)
                {
                    _para1 = value;
                    RaisePropertyChanged("para1");
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
                    _para2 = value;
                    RaisePropertyChanged("para2");
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
                    _para3 = value;
                    RaisePropertyChanged("para3");
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
                    RaisePropertyChanged("t_status");
                }
            }
        }

        private string _EmpName;
        public string EmpName
        {
            get { return _EmpName; }
            set
            {
                if (_EmpName != value)
                {
                    _EmpName = value;
                    RaisePropertyChanged("EmpName");
                }
            }
        }

        private string _EmpId;
        public string EmpId
        {
            get { return _EmpId; }
            set
            {
                if (_EmpId != value)
                {
                    _EmpId = value;
                    RaisePropertyChanged("EmpId");
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
                    _unit_code = value;
                    RaisePropertyChanged("unit_code");
                }
            }
        }

        private string _unit_name;
        public string unit_name
        {
            get { return _unit_name; }
            set
            {
                if (_unit_name != value)
                {
                    _unit_name = value;
                    RaisePropertyChanged("unit_name");
                }
            }
        }
   
        private string _ReportType;
        public string ReportType
        {
            get { return _ReportType; }
            set
            {
                if (_ReportType != value)
                {
                    _ReportType = value;
                    RaisePropertyChanged("ReportType");
                }
            }
        }


        private bool _Select;//scaler
        public bool Select
        {
            get { return _Select; }
            set
            {
                if (_Select != value)
                {
                    _Select = value;
                    RaisePropertyChanged("Select");
                }
            }
        }
      

        //Fin yr and Posting Period
        private string _short_desc;
        public string short_desc
        {
            get { return _short_desc; }
            set
            {
                if (_short_desc != value)
                {
                    _short_desc = value;
                    RaisePropertyChanged("short_desc");
                }
            }
        }

        private int _post_year;
        public int post_year
        {
            get { return _post_year; }
            set
            {
                if (_post_year != value)
                {
                    _post_year = value;
                    RaisePropertyChanged("post_year");
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
                    _fin_year = value;
                    RaisePropertyChanged("fin_year");
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
                    _posting_period = value;
                    RaisePropertyChanged("posting_period");
                }
            }
        }



        private string _SalesAccount;
        public string SalesAccount
        {
            get { return _SalesAccount; }
            set
            {
                if (_SalesAccount != value)
                {
                    _SalesAccount = value;
                    RaisePropertyChanged("SalesAccount");
                }
            }
        }

        private string _SalesAccCd;
        public string SalesAccCd
        {
            get { return _SalesAccCd; }
            set
            {
                if (_SalesAccCd != value)
                {
                    _SalesAccCd = value;
                    RaisePropertyChanged("_SalesAccCd");
                }
            }
        }

    }
    public class MultipleContext_MIS_Sales_InsuranceBL
    {
        public List<ADM_M038_B_P> UnitDetails { get; set; }
        public List<ACC_M001A_P> FinYear { get; set; }
        public List<ACC_M001A_P> PostPeriod { get; set; }
        public List<MIS_InsuranceRptEntity> FinReportData { get; set; }

    }
}
