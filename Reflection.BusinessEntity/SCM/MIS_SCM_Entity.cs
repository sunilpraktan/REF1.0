using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.SCM
{
    public class MIS_SCM_Entity : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

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
        private string _Customer;
        public string Customer
        {
            get { return _Customer; }
            set
            {
                _Customer = value;
                RaisePropertyChanged("Customer");
            }
        }

        private Nullable<Int32> _supplier_id;
        public Nullable<Int32> supplier_id
        {
            get { return _supplier_id; }
            set
            {
                _supplier_id = value;
                RaisePropertyChanged("supplier_id");
            }
        }
        private string _warehouse_id;
        public string warehouse_id
        {
            get { return _warehouse_id; }
            set
            {
                _warehouse_id = value;
                RaisePropertyChanged("warehouse_id");
            }
        }

        private string _CustItemCode;
        public string CustItemCode
        {
            get { return _CustItemCode; }
            set
            {
                _CustItemCode = value;
                RaisePropertyChanged("CustItemCode");
            }
        }

        private string _CustItemDesc;
        public string CustItemDesc
        {
            get { return _CustItemDesc; }
            set
            {
                _CustItemDesc = value;
                RaisePropertyChanged("CustItemDesc");
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

        private string _rec_plant;
        public string rec_plant
        {
            get { return _rec_plant; }
            set
            {
                _rec_plant = value;
                RaisePropertyChanged("rec_plant");
            }
        }
        private string _rec_plantNm;
        public string rec_plantNm
        {
            get { return _rec_plantNm; }
            set
            {
                _rec_plantNm = value;
                RaisePropertyChanged("rec_plantNm");
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

        private string _para1;
        public string para1
        {
            get { return _para1; }
            set
            {
                _para1 = value;
                RaisePropertyChanged("para1");
            }
        }

        private string _para2;
        public string para2
        {
            get { return _para2; }
            set
            {
                _para2 = value;
                RaisePropertyChanged("para2");
            }
        }

        private string _para3;
        public string para3
        {
            get { return _para3; }
            set
            {
                _para3 = value;
                RaisePropertyChanged("para3");
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


        private string _delivery_type;
        public string delivery_type
        {
            get { return _delivery_type; }
            set
            {
                _delivery_type = value;
                RaisePropertyChanged("delivery_type");
            }
        }

        private string _del_desc;
        public string del_desc
        {
            get { return _del_desc; }
            set
            {
                _del_desc = value;
                RaisePropertyChanged("del_desc");
            }
        }
        private string _dept_code;
        public string dept_code
        {
            get { return _dept_code; }
            set
            {

                _dept_code = value;
                RaisePropertyChanged("dept_code");
            }
        }
    }

    public class MultipleContextMISReports4
    {
        public ObservableCollection<ADM_M024_P> EmployeeList { get; set; }
        public List<ADM_M028_P> partyDetails { get; set; }
        public List<ADM_M022_P> ItemDetails { get; set; }
        public List<ADM_M038_B_P> UnitDetails { get; set; }
        public List<SYS_M010_P> DocCatDetails { get; set; }
        public List<SYS_M005_P> DeliveryTyList { get; set; }
        public List<MIS_SCM_Rpt> MIS_SCM_RptList { get; set; }
        public List<ADM_M028_B_P> PartyType { get; set; }
        public List<MM_T001> StatusDetails { get; set; }
        public List<ADM_M025_P> DepartmentDetails { get; set; }
    }
}



