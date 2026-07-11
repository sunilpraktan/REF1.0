using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity
{

    public class MIS_ClosureEntity : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private string _Customer;
        public string Customer
        {
            get { return _Customer; }
            set
            {
                if (_Customer != value)
                {
                    _Customer = value;
                    RaisePropertyChanged("Customer");
                }
            }
        }
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
                    _add_by = value; RaisePropertyChanged("add_by");
                }
            }
        }

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


        private string _StatusName;
        public string StatusName
        {
            get { return _StatusName; }
            set
            {
                if (_StatusName != value)
                {
                    _StatusName = value;
                    RaisePropertyChanged("StatusName");
                }
            }
        }
        private string _StatusCode;
        public string StatusCode
        {
            get { return _StatusCode; }
            set
            {
                if (_StatusCode != value)
                {
                    _StatusCode = value;
                    RaisePropertyChanged("StatusCode");
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

        private string _Location_Id;
        public string Location_Id
        {
            get { return _Location_Id; }
            set
            {
                if (_Location_Id != value)
                {
                    _Location_Id = value;
                    RaisePropertyChanged("Location_Id");
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

        private string _PartyType;
        public string PartyType
        {
            get { return _PartyType; }
            set
            {
                if (_PartyType != value)
                {
                    _PartyType = value;
                    RaisePropertyChanged("PartyType");
                }
            }
        }
        private string _PartyType_Nm;
        public string PartyType_Nm
        {
            get
            {
                return _PartyType_Nm;
            }

            set
            {
                if (_PartyType_Nm != value)
                {
                    _PartyType_Nm = value;
                    RaisePropertyChanged("PartyType_Nm");
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
                    _so_code = value;
                    RaisePropertyChanged("so_code");
                }
            }
        }
        private string _sales_org;
        public string sales_org
        {
            get
            {
                return _sales_org;
            }

            set
            {
                if (_sales_org != value)
                {
                    _sales_org = value;
                    RaisePropertyChanged("sales_org");
                }
            }
        }

        private string _sg_code;
        public string sg_code
        {
            get
            {
                return _sg_code;
            }

            set
            {
                if (_sg_code != value)
                {
                    _sg_code = value;
                    RaisePropertyChanged("sg_code");
                }
            }
        }
        private string _sg_name;
        public string sg_name
        {
            get
            {
                return _sg_name;
            }

            set
            {
                if (_sg_name != value)
                {
                    _sg_name = value;
                    RaisePropertyChanged("sg_name");
                }
            }
        }

    }

    public class MultipleContextMISClosure
    {
        public List<ADM_M028_P> partyDetails { get; set; }
        public List<ADM_M024_P> Employee { get; set; }
        public List<ADM_M028_B_P> PartyType { get; set; }
        public List<ADM_M001_A_P> SalesOrg { get; set; }
        public List<ADM_M001_H_P> SalesGroup { get; set; }
    }

}
