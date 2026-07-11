using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity
{
    public class CurrentStock : ObjectBase    
     {
        public static event EventHandler ModelEntityUpdated = delegate { };
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
        private string _grade_code;
        public string grade_code
        {
            get { return _grade_code; }
            set
            {
                _grade_code = value;
                RaisePropertyChanged("grade_code");
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

        private string _ItemTypeCd;
        public string ItemTypeCd
        {
            get { return _ItemTypeCd; }
            set
            {
                _ItemTypeCd = value;
                RaisePropertyChanged("ItemTypeCd");
            }
        }
        private string _ItemTypeNm;
        public string ItemTypeNm
        {
            get { return _ItemTypeNm; }
            set
            {
                _ItemTypeNm = value;
                RaisePropertyChanged("ItemTypeNm");
            }
        }

        private string _ImportLocalCode;
        public string ImportLocalCode
        {
            get { return _ImportLocalCode; }
            set
            {

                _ImportLocalCode = value;
                RaisePropertyChanged("ImportLocalCode");
            }
        }
        private string _ImportLocalValue;
        public string ImportLocalValue
        {
            get { return _ImportLocalValue; }
            set
            {

                _ImportLocalValue = value;
                RaisePropertyChanged("ImportLocalValue");
            }
        }
        private string _SubItemTpCd;
        public string SubItemTpCd
        {
            get { return _SubItemTpCd; }
            set
            {
                _SubItemTpCd = value;
                RaisePropertyChanged("SubItemTpCd");
            }
        }
        private string _SubItemTpNm;
        public string SubItemTpNm
        {
            get { return _SubItemTpNm; }
            set
            {
                _SubItemTpNm = value;
                RaisePropertyChanged("SubItemTpNm");
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
        private string _para_code;
        public string para_code
        {
            get { return _para_code; }
            set
            {
                _para_code = value;
                RaisePropertyChanged("para_code");
            }
        }
        private string _para_name;
        public string para_name
        {
            get { return _para_name; }
            set
            {
                _para_name = value;
                RaisePropertyChanged("para_name");
            }
        }
        private string _value_code;
        public string value_code
        {
            get { return _value_code; }
            set
            {
                _value_code = value;
                RaisePropertyChanged("value_code");
            }
        }
        private string _parametervalue;
        public string parametervalue
        {
            get { return _parametervalue; }
            set
            {
                _parametervalue = value;
                RaisePropertyChanged("parametervalue");
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

        private string _store_code;
        public string store_code
        {
            get { return _store_code; }
            set
            {
                _store_code = value;
                RaisePropertyChanged("store_code");
            }
        }
        private string _batch_no;
        public string batch_no
        {
            get { return _batch_no; }
            set
            {
                _batch_no = value;
                RaisePropertyChanged("batch_no");
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
       
        private string _stockcategory;
        public string stockcategory
        {
            get { return _stockcategory; }
            set
            {
                _stockcategory = value;
                RaisePropertyChanged("stockcategory", ModelEntityUpdated);
            }
        }
        private decimal _stock_total;
        public decimal stock_total
        {
            get { return _stock_total; }
            set
            {
                _stock_total = value;
                RaisePropertyChanged("stock_total");
            }
        }
        private decimal? _stock_reserve;
        public decimal? stock_reserve
        {
            get { return _stock_reserve; }
            set
            {
                _stock_reserve = value;
                RaisePropertyChanged("stock_reserve");
            }
        }

        private string _sku;
        public string sku
        {
            get { return _sku; }
            set { _sku = value; RaisePropertyChanged("sku"); }
        }

        private string _sku_desc;
        public string sku_desc
        {
            get { return _sku_desc; }
            set { _sku_desc = value; RaisePropertyChanged("sku_desc"); }
        }

        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code"); }
        }

        private decimal? _stock_unr;
        public decimal? stock_unr
        {
            get { return _stock_unr; }
            set
            {
                _stock_unr = value;
                RaisePropertyChanged("stock_unr");
            }
        }

        private decimal? _stock_in_insp;
        public decimal? stock_in_insp
        {
            get { return _stock_in_insp; }
            set
            {
                _stock_in_insp = value;
                RaisePropertyChanged("stock_in_insp");
            }
        }

        private DateTime _Date;
        public DateTime Date
        {
            get { return _Date; }
            set
            {
                _Date = value;
                RaisePropertyChanged("Date");
            }
        }

        private string _description;
        public string description
        {
            get { return _description; }
            set { _description = value; RaisePropertyChanged("description"); }
        }

        private bool? _stock_level;
        public bool? stock_level
        {
            get { return _stock_level; }
            set { _stock_level = value; RaisePropertyChanged("stock_level"); }
        }
        private string _CompName;
        public string CompName
        {
            get { return _CompName; } set { _CompName = value; RaisePropertyChanged("CompName"); }
        }
        private string _store_name;
        public string store_name
        {
            get { return _store_name; }
            set { _store_name = value; RaisePropertyChanged("store_name"); }
        }
        private string _storage_level;
        public string storage_level
        {
            get { return _storage_level; }
            set { _storage_level = value; RaisePropertyChanged("storage_level"); }
        }

    }

    public class CurrentStock_details
    {
        public string Item { get; set; }
       
        public string Description { get; set; }
        //public string StockingUnit { get; set; }
        public string BatchNo { get; set; }
        public string StorageLocation { get; set; }
        public string Plant { get; set; }
        public decimal Current_Stock { get; set; }
    }

    public class CurrentStock_Report
    {
        public string Item { get; set; }
        public string Description { get; set; }
        public string StockingUnit { get; set; }
        public string BatchNo { get; set; }
        public string StorageLocation { get; set; }
        public decimal Current_Stock { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PinCode { get; set; }
        public string PhoneOffice { get; set; }
        public string FaxNo { get; set; }
        public string Mailid { get; set; }

    }

    public class RptCurrentStock
    {
        public string ItemCode { get; set; }
        public string sku { get; set; }
        public string unit_code { get; set; }
        public string comp_code { get; set; }
        public string Location_Id { get; set; }
        public decimal stock_total { get; set; }
        public decimal? stock_in_transit { get; set; }
        public decimal? stock_in_transfer { get; set; }
        public decimal? stock_blocked { get; set; }
    }

    public class selectioncriteria
    {
        public string Type { get; set; }  
        public string Code { get; set; }  
        public string Values { get; set; }
        public string plant { get; set; } 
      
    }
   
    public class MultipleContext_CurrentStock
    {
        public List<ADM_M018_P> CategoryList { get; set; }
        public List<ADM_M019_P> SubCategoryList { get; set; }
        public List<ADM_M015_P> ItemTypeList { get; set; }
        public List<ADM_M016_P> SubItemTypeList { get; set; }
        public List<ADM_M022_P> ItemList { get; set; }
        public List<ADM_M038_B_P> UomDetails { get; set; }
        public List<ADM_M031_P> Parameter { get; set; }
        public List<ADM_M030_P> ParameterVal { get; set; }
        public List<CurrentStock> CurrentStockList { get; set; }
        public List<CurrentStock_details> CurrentStockDetail { get; set; }
        public List<CurrentStock_Report> CurrentStockReport { get; set; }
        public List<RptCurrentStock> CurrentStock_Report { get; set; }
        public List<MIS_SCM_StoreRpt> StoreList { get; set; }
        public List<ADM_M045_P> GradeDetails { get; set; }
        public List<MM_M001_P> StoreLocation { get; set; }
    }

}
