using Reflection.BusinessEntity.ADM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity
{
    public class GEN_T009 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                _doc_no = value;
                RaisePropertyChanged("doc_no", ModelEntityUpdated);
            }
        }
        private Nullable<System.DateTime> _doc_date;
        public Nullable<System.DateTime> doc_date
        {
            get { return _doc_date; }
            set
            {
                _doc_date = value;
                RaisePropertyChanged("doc_date", ModelEntityUpdated);
            }
        }

        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set
            {
                _doc_type = value;
                RaisePropertyChanged("doc_type", ModelEntityUpdated);
            }
        }
        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set
            {
                _doc_cat = value;
                RaisePropertyChanged("doc_cat", ModelEntityUpdated);
            }
        }
        private string _trans_type;
        public string trans_type
        {
            get { return _trans_type; }
            set
            {
                _trans_type = value;
                RaisePropertyChanged("trans_type", ModelEntityUpdated);
            }
        }
        private string _trans_sub_type;
        public string trans_sub_type
        {
            get { return _trans_sub_type; }
            set
            {
                _trans_sub_type = value;
                RaisePropertyChanged("trans_sub_type", ModelEntityUpdated);
            }
        }
        private string _way_bill_no;
        public string way_bill_no
        {
            get { return _way_bill_no; }
            set
            {
                _way_bill_no = value;
                RaisePropertyChanged("way_bill_no", ModelEntityUpdated);
            }
        }
        private System.DateTime _way_bill_date;
        public System.DateTime way_bill_date
        {
            get { return _way_bill_date; }
            set
            {
                _way_bill_date = value;
                RaisePropertyChanged("way_bill_date", ModelEntityUpdated);
            }
        }

        private System.TimeSpan _wb_time;
        public System.TimeSpan wb_time
        {
            get { return _wb_time; }
            set
            {
                _wb_time = value;
                RaisePropertyChanged("wb_time", ModelEntityUpdated);
            }
        }
        private string _ref_doc_no;
        public string ref_doc_no
        {
            get { return _ref_doc_no; }
            set
            {
                _ref_doc_no = value;
                RaisePropertyChanged("ref_doc_no", ModelEntityUpdated);
            }
        }
        private string _ref_doc_cat;
        public string ref_doc_cat
        {
            get { return _ref_doc_cat; }
            set
            {
                _ref_doc_cat = value;
                RaisePropertyChanged("ref_doc_cat", ModelEntityUpdated);
            }
        }

        private string _ref_doc_type;
        public string ref_doc_type
        {
            get { return _ref_doc_type; }
            set
            {
                _ref_doc_type = value;
                RaisePropertyChanged("ref_doc_type", ModelEntityUpdated);
            }
        }
        private string _distance;
        public string distance
        {
            get { return _distance; }
            set
            {
                _distance = value;
                RaisePropertyChanged("distance", ModelEntityUpdated);
            }
        }
        private System.DateTime _validity_from;
        public System.DateTime validity_from
        {
            get { return _validity_from; }
            set
            {
                _validity_from = value;
                RaisePropertyChanged("validity_from", ModelEntityUpdated);
            }
        }
    
        private System.DateTime _validity_to;
        public System.DateTime validity_to
        {
            get { return _validity_to; }
            set
            {
                _validity_to = value;
                RaisePropertyChanged("validity_to", ModelEntityUpdated);
            }
        }
        private string _t_status;
        public string t_status
        {
            get
            {
                return _t_status;
            }

            set
            {
                _t_status = value;
                RaisePropertyChanged("t_status", ModelEntityUpdated);
            }
        }
        private System.DateTime _rec_date;
        public System.DateTime rec_date
        {
            get { return _rec_date; }
            set
            {
                _rec_date = value;
                RaisePropertyChanged("rec_date", ModelEntityUpdated);
            }
        }
        private string _ref_way_bill_no;
        public string ref_way_bill_no
        {
            get { return _ref_way_bill_no; }
            set
            {
                _ref_way_bill_no = value;
                RaisePropertyChanged("ref_way_bill_no", ModelEntityUpdated);
            }
        }
        private string _mode_of_gen;
        public string mode_of_gen
        {
            get { return _mode_of_gen; }
            set
            {
                _mode_of_gen = value;
                RaisePropertyChanged("mode_of_gen", ModelEntityUpdated);
            }
        }
        private bool _active;
        public bool active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active", ModelEntityUpdated);
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
        
        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set { _lang_key = value; RaisePropertyChanged("lang_key", ModelEntityUpdated); }
        }

        //Scaller
        private string _t_name;
        public string t_name
        {
            get { return _t_name; }
            set { _t_name = value; RaisePropertyChanged("t_name", ModelEntityUpdated); }
        }

        private string _location_Id;
        public string location_Id
        {
            get
            { return _location_Id;}

            set
            {
                if (_location_Id != value)
                {
                    _location_Id = value; RaisePropertyChanged("location_Id", ModelEntityUpdated);
                }
            }
        }
        private string _comp_code;
        public string comp_code
        {
            get
            {
                return _comp_code;
            }

            set
            {
                if (_comp_code != value)
                {
                    _comp_code = value; RaisePropertyChanged("comp_code", ModelEntityUpdated);
                }
            }
        }
    }
    public class MultipleContext_GEN_T009
    {
        public List<GEN_T009_BackFlip> BackFlipEntity { get; set; }
        public ObservableCollection<GEN_T009> MasterEntity { get; set; }
        public List<SEL_T003> SalesData { get; set; }
        public List<SEL_T003_A> ItemsEntity { get; set; }
        public List<LOG_T001_A> ItemsEntitydel { get; set; }
        //public List<HRM_M015_A> DetailData { get; set; }
        public List<ADM_M0013> StatusList { get; set; }

        public List<SEL_T003_P_RefDoc> Sales_Invoice_Reference { get; set; }
        public List<GEN_T009_P> waybill { get; set; }
    }
    public class GEN_T009_BackFlip
    {
        public string doc_no { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string trans_type { get; set; }
        public string trans_sub_type { get; set; }
        public string way_bill_no { get; set; }
        public Nullable<System.DateTime> way_bill_date { get; set; }
        public string wb_time { get; set; }
        public string ref_doc_no { get; set; }
        public string ref_doc_cat { get; set; }
        public string ref_doc_type { get; set; }
        public string distance { get; set; }
        public Nullable<System.DateTime> validity_from { get; set; }
        public Nullable<System.DateTime> validity_to { get; set; }
        public string t_status { get; set; }
        public Nullable<System.DateTime> rec_date { get; set; }
        public string ref_way_bill_no { get; set; }
        public string mode_of_gen { get; set; }
        public Nullable<bool> active { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public System.DateTime add_date { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
        public string client { get; set; }
        public string lang_key { get; set; }
    }
}

