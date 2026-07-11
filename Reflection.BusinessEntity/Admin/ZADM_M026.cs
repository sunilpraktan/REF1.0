using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Admin
{
    public class ZADM_M026:ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged("id");
            }
        }

        private string _supplier_id;
        public string supplier_id
        {
            get { return _supplier_id; }
            set
            {
                _supplier_id = value;
                RaisePropertyChanged("supplier_id",ModelEntityUpdated);
            }
        }
     
        private string _ItemCode;
        public string ItemCode
        {
            get { return _ItemCode; }
            set
            {
                _ItemCode = value;
                RaisePropertyChanged("ItemCode",ModelEntityUpdated);
            }
        }
        private string _sku;

        public string sku
        {
            get { return _sku; }
            set
            {
                _sku = value;
                RaisePropertyChanged("sku", ModelEntityUpdated);
            }
        }
        private string _sku_desc;
        public string sku_desc
        {
            get { return _sku_desc; }
            set
            {
                _sku_desc = value;
                RaisePropertyChanged("sku_desc", ModelEntityUpdated);
            }
        }
        private string _ink_code;
        public string ink_code
        {
            get { return _ink_code; }
            set
            {
                _ink_code = value;
                RaisePropertyChanged("ink_code", ModelEntityUpdated);
            }
        }
     
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set
            {
                _add_by = value;
                RaisePropertyChanged("add_by", ModelEntityUpdated);
            }
        }
        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set
            {
                _add_date = value;
                RaisePropertyChanged("add_date", ModelEntityUpdated);
            }
        }
        private string _editby;
        public string editby
        {
            get { return _editby; }
            set
            {
                _editby = value;
                RaisePropertyChanged("editby", ModelEntityUpdated);
            }
        }
        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value;
                RaisePropertyChanged("edit_date", ModelEntityUpdated);
            }
        }
        
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                _comp_code = value;
                RaisePropertyChanged("comp_code", ModelEntityUpdated);
            }
        }
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                _location_Id = value;
                RaisePropertyChanged("location_Id", ModelEntityUpdated);
            }
        }
        private string _SupplierNm;
        public string SupplierNm
        {
            get { return _SupplierNm; }
            set
            {
                _SupplierNm = value;
                RaisePropertyChanged("SupplierNm", ModelEntityUpdated);
            }
        }
       
        private string _ItemNm;
        public string ItemNm
        {
            get { return _ItemNm; }
            set
            {
                _ItemNm = value;
                RaisePropertyChanged("ItemNm", ModelEntityUpdated);
            }
        }
        private string _SubCatCode;
        public string SubCatCode
        {
            get { return _SubCatCode; }
            set
            {
                _SubCatCode = value;
                RaisePropertyChanged("SubCatCode", ModelEntityUpdated);
            }
        }

        private Nullable<bool> _StockUnt;
        public Nullable<bool> StockUnt
        {
            get { return _StockUnt; }
            set
            {
                _StockUnt = value;
                RaisePropertyChanged("StockUnt", ModelEntityUpdated);
            }
        }

        private string _parametervalue;
        public string parametervalue
        {
            get { return _parametervalue; }
            set
            {
                _parametervalue = value;
                RaisePropertyChanged("parametervalue", ModelEntityUpdated);
            }
        }
        private bool _Select { get; set; }
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

       

        private string _customer_id;
        public string customer_id
        {
            get { return _customer_id; }
            set
            {
                _customer_id = value;
                RaisePropertyChanged("customer_id", ModelEntityUpdated);
            }
        }
        private Nullable<decimal> _price;
        public Nullable<decimal> price
        {
            get { return _price; }
            set
            {
                _price = value;
                RaisePropertyChanged("price", ModelEntityUpdated);
            }
        }

        private Nullable<decimal> _unit_price;
        public Nullable<decimal> unit_price
        {
            get { return _unit_price; }
            set
            {
                _unit_price = value;
                RaisePropertyChanged("unit_price", ModelEntityUpdated);
            }
        }

        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active", ModelEntityUpdated);
            }
        }
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set
            {
                _t_status = value;
                RaisePropertyChanged("t_status", ModelEntityUpdated);
            }
        }

        private string _CustomerNm;
        public string CustomerNm
        {
            get { return _CustomerNm; }
            set
            {
                _CustomerNm = value;
                RaisePropertyChanged("CustomerNm", ModelEntityUpdated);
            }
        }
        public string XmlDataDocument_FlipGrid { get; set; }
        public string XmlDataDocument_ItemsEntity { get; set; }
    

    }

    public class MultipleContext_ZADM_M026
    {
        public List<ZADM_M026Flip> DocumentDataFlipGrid { get; set; }
        public List<ZADM_M026> MasterEntity { get; set; }
        public List<ADM_M028_P> SupplierList { get; set; }
        public List<ADM_M028_P> CustomerList { get; set; }
        public List<ADM_M022_P> ItemList { get; set; }
        public List<ADM_M030_P> ParamValueList { get; set; }//Flute Master
        public List<ADM_M031_P> ParameterList { get; set; } //Parameter Master
        public ObservableCollection<ZADM_M026> ItemEntity { get; set; }
    }
    public class ZADM_M026Flip
    {
        public int id { get; set; }
        public string supplier_id { get; set; }
        public string SupplierNm { get; set; }
        public string customer_id { get; set; }
        public string CustomerNm { get; set; }
        public string ItemCode { get; set; }
        public string sku { get; set; }
        public string ink_code { get; set; }
        public Nullable<decimal> price { get; set; }
        public string t_status { get; set; }
    }
}
