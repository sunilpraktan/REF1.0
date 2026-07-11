using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity
{
    public class MM_M001 : ObjectBase
    {
        private string _store_code;
        public string store_code
        {
            get { return _store_code; }
            set
            {
                if (_store_code != value)
                {
                    _store_code = value;

                    RaisePropertyChanged("store_code");
                }
            }
        }
        private int? _id;
        public int? id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;

                    RaisePropertyChanged("id");
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
        private string _CompName;
        public string CompName
        {
            get { return _CompName; }
            set
            {
                if (_CompName != value)
                {
                    _CompName = value;

                    RaisePropertyChanged("CompName");
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
        private string _store_name;
        public string store_name
        {
            get { return _store_name; }
            set
            {
                if (_store_name != value)
                {
                    _store_name = value;
                    RaisePropertyChanged("store_name");
                }
            }
        }
        private string _div_code;
        public string div_code
        {
            get { return _div_code; }
            set
            {
                if (_div_code != value)
                {
                    _div_code = value;
                    RaisePropertyChanged("div_code");
                }
            }
        }
        private Nullable<bool> _neg_stock_ind;
        public Nullable<bool> neg_stock_ind
        {
            get { return _neg_stock_ind; }
            set
            {
                if (_neg_stock_ind != value)
                {
                    _neg_stock_ind = value;
                    RaisePropertyChanged("neg_stock_ind");
                }
            }
        }
        private string _rec_ship_point;
        public string rec_ship_point
        {
            get { return _rec_ship_point; }
            set
            {
                if (_rec_ship_point != value)
                {
                    _rec_ship_point = value;
                    RaisePropertyChanged("rec_ship_point");
                }
            }
        }
        private bool _default_storage_loc;
        public bool default_storage_loc
        {
            get { return _default_storage_loc; }
            set
            {
                if (_default_storage_loc != value)
                {
                    _default_storage_loc = value;
                    RaisePropertyChanged("default_storage_loc");
                }
            }
        }
        private bool? _active;
        public bool? active
        {
            get { return _active; }
            set
            {
                if (_active != value)
                {
                    _active = value;

                    RaisePropertyChanged("active");
                }
            }
        }

        private bool _Click;
        public bool Click
        {
            get
            {
                return _Click;
            }
            set
            {
                if (_Click != value)
                {
                    _Click = value;
                    RaisePropertyChanged("Click");
                }
            }
        }
        private string _location_id;
        public string location_id
        {
            get { return _location_id; }
            set
            {
                if (_location_id != value)
                {
                    _location_id = value;
                    RaisePropertyChanged("location_Id");
                }
            }
        }
       
    }
    public class MM_M004
    {
        public string mov_tp { get; set; }
        public string mov_tp_name { get; set; }
        public string mov_tp_desc { get; set; }
        public string debit_credit { get; set; }
        public string con_post { get; set; }
        public string gr_block_stock { get; set; }
        public string batch_control { get; set; }
        public string insp_qa { get; set; }
        public string mov_cat { get; set; }
        public string rev_mov_tp { get; set; }
        public bool? active { get; set; }
        public string post_key_ref { get; set; }

        // Scaler Fields
        public string doc_type { get; set; }

    }
    public class MultipleContext_MM_M001
    {
        public ObservableCollection<MM_M001> StorageLocationList { get; set; }
        public List<ADM_M002_P> CompanyList { get; set; }
        public List<ADM_M003_P> LocationList { get; set; }
    }
}
