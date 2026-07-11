using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity
{
    public class ADM_M034 : ObjectBase
    {
        private string _para_code;
        public string para_code
        {
            get { return _para_code; }
            set{ _para_code = value; RaisePropertyChanged("para_code"); }
        }
        private string _SubCatCode;
        public string SubCatCode
        {
            get { return _SubCatCode; }
            set { _SubCatCode = value; RaisePropertyChanged("SubCatCode"); }
        }
        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }
        private string _ItemCode;
        public string ItemCode
        {
            get { return _ItemCode; }
            set { _ItemCode = value; RaisePropertyChanged("ItemCode"); }
        }
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }
        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
        }
        private string _editby;
        public string editby
        {
            get { return _editby; }
            set { _editby = value; RaisePropertyChanged("editby"); }
        }
        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
        }
        private Nullable<int> _srno;
        public Nullable<int> srno
        {
            get { return _srno; }
            set { _srno = value; RaisePropertyChanged("srno"); }
        }
        private string _SubCatName;
        public string SubCatName
        {
            get { return _SubCatName; }
            set { _SubCatName = value; RaisePropertyChanged("SubCatName"); }
        }
        private string _para_name;
        public string para_name
        {
            get { return _para_name; }
            set { _para_name = value; RaisePropertyChanged("para_name"); }
        }
    }
    public class MultipleContextADM_M034
    {
        public List<ADM_M034> PARAM { get; set; }
        public ObservableCollection<ADM_M019> Subcat { get; set; }
        public ObservableCollection<ADM_M031> ParamList { get; set; }////Parameter Master    
  
    }

}
