using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity
{
    public class MM_M005 : ObjectBase
    {
        public int QuantID { get; set; }
        public Nullable<int> QuantNumber { get; set; }
        public string QuantName { get; set; }
        public string RowNo { get; set; }
        public string ColumnNo { get; set; }
        public Nullable<bool> status { get; set; }
        public Nullable<int> company_id { get; set; }
        public string location_Id { get; set; }
        public string warehouse { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public Nullable<int> edit_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        private string _item_Name;      
        public string item_Name
        {
            get { return _item_Name; }
            set { _item_Name = value; RaisePropertyChanged("item_Name"); }
        }




        private string _item_id;
        public string item_id
        {
            get { return _item_id; }
            set { _item_id = value; RaisePropertyChanged("item_id"); }
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
        private Nullable<bool> _Stockable { get; set; }
        public Nullable<bool> Stockable { get { return _Stockable; } set { _Stockable = value; RaisePropertyChanged("Stockable"); } }

        private int _SubCategCod;
        public int SubCategCod
        {
            get { return _SubCategCod; }
            set { _SubCategCod = value; RaisePropertyChanged("SubCategCod"); }
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
        private string _stockingunit;
        public string stockingunit { get { return _stockingunit; } set { _stockingunit = value; RaisePropertyChanged("stockingunit"); } }

    }
    public class MultipleContext_MM_M005
    {
        public List<MM_M005> QuantMaster { get; set; }//QuantMaster
        public ObservableCollection<MM_M007_PopUp> StockJournal { get; set; }// StockJournal      
        public List<MM_S003_PopUp> ItemList { get; set; }  // Batch Stock    
        public List<MM_S003_PopUp> Batch_Stock { get; set; }  // Batch Stock         
        public List<ADM_M030_P> parameter_value_list { get; set; }//Flute Master
        //public List<Parameter_PopUp> parameter_list { get; set; }    //Parameter Master
        public List<ADM_M034_PopUp> ParamList { get; set; }

       
    }
}
