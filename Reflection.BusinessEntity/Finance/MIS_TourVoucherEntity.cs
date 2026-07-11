using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity.Finance
{
    public class MIS_TourVoucherEntity : ObjectBase
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

        private string _sg_code;
        public string sg_code
        {
            get { return _sg_code; }
            set
            {
                _sg_code = value;
                RaisePropertyChanged("sg_code");
            }
        }
        private string _sales_org;
        public string sales_org
        {
            get { return _sales_org; }
            set
            {
                _sales_org = value;
                RaisePropertyChanged("sales_org");
            }
        }
        private string _so_code;
        public string so_code
        {
            get { return _so_code; }
            set
            {
                _so_code = value;
                RaisePropertyChanged("so_code");
            }
        }

       

        private string _sg_name;
        public string sg_name
        {
            get { return _sg_name; }
            set
            {
                _sg_name = value;
                RaisePropertyChanged("sg_name");
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
    }

    public class MultipleContextMIS_Tour_Management
    {
        public List<ADM_M024_P> EmployeeList { get; set; }
        public List<ADM_M001_A_P> SalesOrg { get; set; }
        public List<ADM_M001_H_P> SalesGroup { get; set; }
        public List<MIS_Tour_Voucher> RptMIS_MIS_Tour_Voucher { get; set; }




    }
}
