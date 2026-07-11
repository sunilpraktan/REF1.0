using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Admin
{
    public class ADM_M058 : ObjectBase
    {           
        private string _group_code;
        public string group_code
        {
            get { return _group_code; }
            set
            {
                if (_group_code != value)
                {
                    _group_code = value; RaisePropertyChanged("group_code");
                }
            }
        }
        
        private string _group_name;
        public string group_name
        {
            get { return _group_name; }
            set
            {
                if (_group_name != value)
                {
                    _group_name = value; RaisePropertyChanged("group_name");
                }
            }
        }

        #region Default Fields
        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set
            {
                _active = value; RaisePropertyChanged("active");
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

        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set
            {
                _add_date = value;
                RaisePropertyChanged("add_date");
            }
        }

        private string _edit_by;
        public string edit_by
        {
            get { return _edit_by; }
            set
            {
                _edit_by = value; RaisePropertyChanged("edit_by");
            }
        }

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value; RaisePropertyChanged("edit_date");
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

        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                _lang_key = value;
                RaisePropertyChanged("lang_key");
            }
        }
        
        #endregion

        //XML doc 
        public string XmlDataDocument_ADM_M058_A { get; set; }
        public string XmlDataDocument_ADM_M058_Flip { get; set; }
    }
    public class ADM_M058_A : ObjectBase
    {        
        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value; RaisePropertyChanged("id");
                }
            }
        }
        
        private string _group_code;
        public string group_code
        {
            get { return _group_code; }
            set
            {
                if (_group_code != value)
                {
                    _group_code = value; RaisePropertyChanged("group_code");
                }
            }
        }
        
        private string _obj_name;
        public string obj_name
        {
            get { return _obj_name; }
            set
            {
                if (_obj_name != value)
                {
                    _obj_name = value; RaisePropertyChanged("obj_name");
                }
            }
        }
        
        private Nullable<decimal> _qty;
        public Nullable<decimal> qty
        {
            get { return _qty; }
            set
            {
                if (_qty != value)
                {
                    _qty = value; RaisePropertyChanged("qty");
                }
            }
        }
        
        private string _qty_unit;
        public string qty_unit
        {
            get { return _qty_unit; }
            set
            {
                if (_qty_unit != value)
                {
                    _qty_unit = value; RaisePropertyChanged("qty_unit");
                }
            }
        }
        
        private Nullable<decimal> _wt;
        public Nullable<decimal> wt
        {
            get { return _wt; }
            set
            {
                if (_wt != value)
                {
                    _wt = value; RaisePropertyChanged("wt");
                }
            }
        }
        
        private string _wt_unit;
        public string wt_unit
        {
            get { return _wt_unit; }
            set
            {
                if (_wt_unit != value)
                {
                    _wt_unit = value; RaisePropertyChanged("wt_unit");
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
                    _ItemCode = value; RaisePropertyChanged("ItemCode");
                }
            }
        }

        #region Default Fields
        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set
            {
                _active = value; RaisePropertyChanged("active");
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

        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set
            {
                _add_date = value;
                RaisePropertyChanged("add_date");
            }
        }

        private string _edit_by;
        public string edit_by
        {
            get { return _edit_by; }
            set
            {
                _edit_by = value; RaisePropertyChanged("edit_by");
            }
        }

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value; RaisePropertyChanged("edit_date");
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

        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                _lang_key = value;
                RaisePropertyChanged("lang_key");
            }
        }
        
        #endregion
    }
    public class MultipleContext_ADM_M058
    {
        public List<ADM_M058_BackFlip> BackFlipEntity { get; set; }
        public List<ADM_M058> MasterData { get; set; }
        public ObservableCollection<ADM_M058_A> DetailData { get; set; }
        public List<ADM_M038_C_P> Unit { get; set; }
        public List<ADM_M022_P> Item { get; set; }
    }
    public class ADM_M058_BackFlip
    {
        public string group_code { get; set; }
        public string group_name { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string edit_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string client { get; set; }
        public string lang_key { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
    }
}
