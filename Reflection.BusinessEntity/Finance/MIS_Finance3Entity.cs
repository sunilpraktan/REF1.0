using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity.Finance
{
    public class MIS_Finance3Entity : ObjectBase
    {
        
        private string _EmpName;
        public string EmpName
        {
            get { return _EmpName; }
            set
            {
                _EmpName = value;
                RaisePropertyChanged("EmpName");
            }
        }

        private string _EmpId;
        public string EmpId
        {
            get { return _EmpId; }
            set
            {
                _EmpId = value;
                RaisePropertyChanged("EmpId");
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


        private string _ReportName;
        public string ReportName
        {
            get { return _ReportName; }
            set
            {
                _ReportName = value;
                RaisePropertyChanged("ReportName");
            }
        }

        private string _ReportCode;
        public string ReportCode
        {
            get { return _ReportCode; }
            set
            {
                _ReportCode = value;
                RaisePropertyChanged("ReportCode");
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

        private string _ItemName;
        public string ItemName
        {
            get { return _ItemName; }
            set
            {
                _ItemName = value;
                RaisePropertyChanged("ItemName");
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

        private string _JE_desc;
        public string JE_desc
        {
            get { return _JE_desc; }
            set
            {
                _JE_desc = value;
                RaisePropertyChanged("JE_desc");
            }
        }

        private string _JE_type;
        public string JE_type
        {
            get { return _JE_type; }
            set
            {
                _JE_type = value;
                RaisePropertyChanged("JE_type");
            }
        }

        private string _vendor_code;
        public string vendor_code
        {
            get { return _vendor_code; }
            set
            {
                _vendor_code = value;
                RaisePropertyChanged("vendor_code");
            }
        }
    }

   public class MultipleContextMIS_Finance3
    {
        public List<ADM_M024_P> EmployeeList { get; set; }
        public List<ADM_M028_P> PartyDetails { get; set; }
        public List<ACC_M004_P> BankDetails { get; set; }
        public List<ACC_M022> JEType { get; set; }
        public List<VendorPopup> Vendors { get; set; }
        public List<ACC_T006_A> MIS_FinanceReportsEntity { get; set; }

    }
}
