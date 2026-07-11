using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity
{
    public class MIS_PurchaseReport : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

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

        private Nullable<Int32> _supplier_id;
        public Nullable<Int32> supplier_id
        {
            get { return _supplier_id; }
            set
            {
                if (_supplier_id != value)
                {
                    _supplier_id = value;
                    RaisePropertyChanged("supplier_id");
                }
            }
        }
        private string _warehouse_id;
        public string warehouse_id
        {
            get { return _warehouse_id; }
            set
            {
                if (_warehouse_id != value)
                {
                    _warehouse_id = value;
                    RaisePropertyChanged("warehouse_id");
                }
            }
        }

        private string _CustItemCode;
        public string CustItemCode
        {
            get { return _CustItemCode; }
            set
            {
                if (_CustItemCode != value)
                {
                    _CustItemCode = value;
                    RaisePropertyChanged("CustItemCode");
                }
            }
        }

        private string _CustItemDesc;
        public string CustItemDesc
        {
            get { return _CustItemDesc; }
            set
            {
                if (_CustItemDesc != value)
                {
                    _CustItemDesc = value;
                    RaisePropertyChanged("CustItemDesc");
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
        private Nullable<DateTime> _po_date;
        public Nullable<DateTime> po_date
        {
            get { return _po_date; }
            set
            {
                if (_po_date != value)
                {
                    _po_date = value;
                    RaisePropertyChanged("po_date");

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

        private string _ItemCode;
        public string ItemCode
        {
            get { return _ItemCode; }
            set
            {
                if (_ItemCode != value)
                {
                    _ItemCode = value;
                    RaisePropertyChanged("ItemCode");
                }
            }
        }

        private string _ItemName;
        public string ItemName
        {
            get { return _ItemName; }
            set
            {
                if (_ItemName != value)
                {
                    _ItemName = value;
                    RaisePropertyChanged("ItemName");
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
        private string _po_no;
        public string po_no
        {
            get { return _po_no; }
            set
            {
                if (_po_no != value)
                {
                    _po_no = value;
                    RaisePropertyChanged("po_no");
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
        private string _dcat_name;
        public string dcat_name
        {
            get { return _dcat_name; }
            set
            {
                if (_dcat_name != value)
                {
                    _dcat_name = value;
                    RaisePropertyChanged("dcat_name");
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

        private string _curr_code;
        public string curr_code
        {
            get { return _curr_code; }
            set {
                if (_curr_code != value)
                {
                    _curr_code = value; RaisePropertyChanged("curr_code");

                }
            }
        }

        private string _curr_name;
        public string curr_name
        {
            get { return _curr_name; }
            set {
                if (_curr_name != value)
                {
                    _curr_name = value; RaisePropertyChanged("curr_name");

                }
            }
        }
        private string _CatCode;
        public string CatCode
        {
            get { return _CatCode; }
            set
            {
                if (_CatCode != value)
                {
                    _CatCode = value; RaisePropertyChanged("CatCode");

                }
            }
        }

    }

    public class MultipleContextMIS_CRM_Purchase
    {
        public List<ADM_M024_P> EmployeeList { get; set; }
        public List<ADM_M028_P> partyDetails { get; set; }
        public List<ADM_M022_P> ItemDetails { get; set; }
        public List<PUR_T001_A> StatusDetails { get; set; }
        public List<ADM_M028_B_P> PartyType { get; set; }
        public List<PUR_T002_A_P> DocNoList { get; set; }
        public List<ADM_M037_P> CurrencyList { get; set; }
        public List<ADM_M018_P> CategoryDetails { get; set; }

    }
}
