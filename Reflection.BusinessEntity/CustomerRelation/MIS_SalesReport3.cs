using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Reflection.BusinessEntity.ReflectionSystem;

namespace Reflection.BusinessEntity
{
    public class MIS_SalesReport3 : ObjectBase
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

        private string _doc_desc;
        public string doc_desc
        {
            get { return _doc_desc; }
            set
            {
                if (_doc_desc != value)
                {
                    _doc_desc = value;
                    RaisePropertyChanged("doc_desc");
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

        private string _sg_code;
        public string sg_code
        {
            get { return _sg_code; }
            set
            {
                if (_sg_code != value)
                {
                    _sg_code = value;
                    RaisePropertyChanged("sg_code");
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
                    _sales_org = value;
                    RaisePropertyChanged("sales_org");
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
                    _so_code = value;
                    RaisePropertyChanged("so_code");
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
                    _sg_name = value;
                    RaisePropertyChanged("sg_name");
                }
            }
        }
        private Nullable<int> _agingperiod;
        public Nullable<int> agingperiod
        {
            get { return _agingperiod; }
            set
            {
                if (_agingperiod != value)
                {
                    _agingperiod = value;
                    RaisePropertyChanged("agingperiod");
                }
            }
        }

        private string _CatCode;
        public string CatCode
        {
            get { return _CatCode; }
            set
            {
                _CatCode = value;
                RaisePropertyChanged("CatCode");
            }
        }
        private string _CatName;
        public string CatName
        {
            get { return _CatName; }
            set
            {
                _CatName = value;
                RaisePropertyChanged("CatName");
            }
        }

        private string _SubCatCode;
        public string SubCatCode
        {
            get { return _SubCatCode; }
            set
            {
                _SubCatCode = value;
                RaisePropertyChanged("SubCatCode");
            }
        }
        private string _SubCatName;
        public string SubCatName
        {
            get { return _SubCatName; }
            set
            {
                _SubCatName = value;
                RaisePropertyChanged("SubCatName");
            }
        }
        private string _ind_trade;
        public string ind_trade
        {
            get { return _ind_trade; }
            set
            {
                _ind_trade = value;
                RaisePropertyChanged("ind_trade");
            }
        }
        private string _trade_name;
        public string trade_name
        {
            get { return _trade_name; }
            set
            {
                _trade_name = value;
                RaisePropertyChanged("trade_name");
            }
        }
    }
  
    public class MultipleContextMISReports3
    {
        public ObservableCollection<ADM_M024_P> EmployeeList { get; set; }
        public List<ADM_M028_P> partyDetails { get; set; }
        public List<ADM_M022_P> ItemDetails { get; set; }
        public List<SYS_M001_P> DocCatDetails { get; set; }
        public List<SYS_M002_P> DocTypeDetails { get; set; }
        public List<ADM_M001_A_P> SalesOrg { get; set; }
        public List<ADM_M001_H_P> SalesGroup { get; set; }
        public List<MIS_CRM_SalesEntity3> RptMIS_CRMSales_List { get; set; }
        public List<ADM_M028_B_P> PartyType;
        public List<ADM_M018_P> CategoryList { get; set; }
        public List<ADM_M019_P> SubCategoryList { get; set; }
        public List<SYS_M037> Trade_Types { get; set; }

    }
}
