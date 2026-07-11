using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Reflection.BusinessEntity
{
    public class MM_M007 : ObjectBase
    {
        private int _trnsID;
        public int trnsID
        {
            get { return _trnsID; }
            set
            {
                _trnsID = value;
                RaisePropertyChanged("trnsID");
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
        private string _sku;
        public string sku
        {
            get { return _sku; }
            set
            {
                _sku = value;
                RaisePropertyChanged("sku");
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
        private Nullable<decimal> _Qty;
        public Nullable<decimal> Qty
        {
            get { return _Qty; }
            set
            {
                _Qty = value;
                RaisePropertyChanged("Qty");
            }
        }
        private string _TrnsType;
        public string TrnsType
        {
            get { return _TrnsType; }
            set
            {
                _TrnsType = value;
                RaisePropertyChanged("TrnsType");
            }
        }
        private string _SourceLoc;
        public string SourceLoc
        {
            get { return _SourceLoc; }
            set
            {
                _SourceLoc = value;
                RaisePropertyChanged("SourceLoc");
            }
        }
        private string _DestLoc;
        public string DestLoc
        {
            get { return _DestLoc; }
            set
            {
                _DestLoc = value;
                RaisePropertyChanged("DestLoc");
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
        private string _warehouse;
        public string warehouse
        {
            get { return _warehouse; }
            set
            {
                _warehouse = value;
                RaisePropertyChanged("warehouse");
            }
        }
        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
            }
        }
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set
            {
                _add_by = value;
                RaisePropertyChanged("add_by");
            }
        }
        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date
        {
            get { return _add_date; }
            set
            {
                _add_date = value;
                RaisePropertyChanged("add_date");
            }
        }
        private Nullable<int> _edit_by;
        public Nullable<int> edit_by
        {
            get { return _edit_by; }
            set
            {
                _edit_by = value;
                RaisePropertyChanged("edit_by");
            }
        }
        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value;
                RaisePropertyChanged("edit_date");
            }
        }
        private string _item_Name;
        //[DisplayName("Item Name")]
        public string item_Name
        {
            get { return _item_Name; }
            set { _item_Name = value; RaisePropertyChanged("item_Name"); }
        }
        private string _item_code;       
        [DisplayName("Item Code")]
        public string item_code
        {
            get { return _item_code; }
            set { _item_code = value; RaisePropertyChanged("item_code"); }
        }
        private string _item_id;
        public string item_id
        {
            get { return _item_id; }
            set { _item_id = value; RaisePropertyChanged("item_id"); }
        }
        private string _subCategCod;
        public string subCategCod { get { return _subCategCod; } set { _subCategCod = value; RaisePropertyChanged("subCategCod"); } }

        private string _stockingunit;
        public string stockingunit { get { return _stockingunit; } set { _stockingunit = value; RaisePropertyChanged("stockingunit"); } }

        private string _stocking_unit1;
        public string stocking_unit1 { get { return _stocking_unit1; } set { _stocking_unit1 = value; RaisePropertyChanged("stocking_unit1"); } }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
                RaisePropertyChanged("Description");
            }
        }       

        private int _SubCategCod;
        public int SubCategCod
        {
            get { return _SubCategCod; }
            set { _SubCategCod = value; RaisePropertyChanged("SubCategCod"); }
        }
        private Nullable<bool> _Stockable { get; set; }
        public Nullable<bool> Stockable { get { return _Stockable; } set { _Stockable = value; RaisePropertyChanged("Stockable"); } }

    }
    public class MultipleContext_MM_M007
    {
        public List<MM_M007> StckJurnl { get; set; }  //StockJournal
        public List<MM_S003_PopUp> ItemList { get; set; }  // Batch Stock 
        public List<MM_S003_PopUp> Batch_Stock { get; set; }  // Batch Stock         
        public List<ADM_M030_P> parameter_value_list { get; set; }//Flute Master
        //public List<Parameter_PopUp > parameter_list { get; set; }    //Parameter Master
        public List<ADM_M034_PopUp> ParamList { get; set; }
        //public List<ParameterSelection> ParameterSelectionList { get; set; }
        public ObservableCollection<MM_M005_PopUp> Stock_Chart { get; set; }  // Stock Chart

    }
}
