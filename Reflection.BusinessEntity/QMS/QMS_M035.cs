using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.QMS
{
    public class QMS_M035 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private string _sample_scheme;
        public string sample_scheme
        {
            get { return _sample_scheme; }
            set
            {
                _sample_scheme = value;
                RaisePropertyChanged("sample_scheme");
            }
        }

        private string _desc;
        public string desc
        {
            get { return _desc; }
            set
            {
                _desc = value;
                RaisePropertyChanged("desc");
            }
        }

        private string _ind_attr_insp;
        public string ind_attr_insp
        {
            get { return _ind_attr_insp; }
            set
            {
                _ind_attr_insp = value;
                RaisePropertyChanged("ind_attr_insp");
            }
        }

        private string _ind_var_insp;
        public string ind_var_insp
        {
            get { return _ind_var_insp; }
            set
            {
                _ind_var_insp = value;
                RaisePropertyChanged("ind_var_insp");
            }
        }

        private string _without_val_para;
        public string without_val_para
        {
            get { return _without_val_para; }
            set
            {
                _without_val_para = value;
                RaisePropertyChanged("without_val_para");
            }
        }

        private string _ind_lot_based_insp;
        public string ind_lot_based_insp
        {
            get { return _ind_lot_based_insp; }
            set
            {
                _ind_lot_based_insp = value;
                RaisePropertyChanged("ind_lot_based_insp");
            }
        }

        private string _interval_rel_insp;
        public string interval_rel_insp
        {
            get { return _interval_rel_insp; }
            set
            {
                _interval_rel_insp = value;
                RaisePropertyChanged("interval_rel_insp");
            }
        }

        private string _ind_item_level_para;
        public string ind_item_level_para
        {
            get { return _ind_item_level_para; }
            set
            {
                _ind_item_level_para = value;
                RaisePropertyChanged("ind_item_level_para");
            }
        }

        private string _ind_aql_val;
        public string ind_aql_val
        {
            get { return _ind_aql_val; }
            set
            {
                _ind_aql_val = value;
                RaisePropertyChanged("ind_aql_val");
            }
        }

        private string _ind_sc_used;
        public string ind_sc_used
        {
            get { return _ind_sc_used; }
            set
            {
                _ind_sc_used = value;
                RaisePropertyChanged("ind_sc_used");
            }
        }

        private string _intd_sc_not_used;
        public string intd_sc_not_used
        {
            get { return _intd_sc_not_used; }
            set
            {
                _intd_sc_not_used = value;
                RaisePropertyChanged("intd_sc_not_used");
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

        private string _editby;
        public string editby
        {
            get { return _editby; }
            set
            {
                _editby = value;
                RaisePropertyChanged("editby");
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

        private Nullable<System.DateTime> _doc_date;
        public Nullable<System.DateTime> doc_date
        {
            get { return _doc_date; }
            set
            {
                _doc_date = value;
                RaisePropertyChanged("doc_date");
            }
        }

        private Nullable<int> _aql_value;
        public Nullable<int> aql_value
        {
            get { return _aql_value; }
            set
            {
                _aql_value = value;
                RaisePropertyChanged("aql_value");
            }
        }

        public string XmlDataDocument_QMS_M035_Flip { get; set; }
        public string XmlDataDocument_QMS_M035_A { get; set; }

        //Scalar
        private bool _x1;
        public bool x1
        {
            get { return _x1; }
            set
            {
                _x1 = value;
                RaisePropertyChanged("x1");
            }
        }

        private bool _x2;
        public bool x2
        {
            get { return _x2; }
            set
            {
                _x2 = value;
                RaisePropertyChanged("x2");
            }
        }

        private bool _r1;
        public bool r1
        {
            get { return _r1; }
            set
            {
                _r1 = value;
                RaisePropertyChanged("r1");
            }
        }

        private bool _r2;
        public bool r2
        {
            get { return _r2; }
            set
            {
                _r2 = value;
                RaisePropertyChanged("r2");
            }
        }

        private bool _r3;
        public bool r3
        {
            get { return _r3; }
            set
            {
                _r3 = value;
                RaisePropertyChanged("r3");
            }
        }

        private string _severity;
        public string severity
        {
            get { return _severity; }
            set
            {
                _severity = value;
                RaisePropertyChanged("severity");
            }
        }
    }

    public class QMS_M035_A : ObjectBase
    {
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

        private string _sample_scheme;
        public string sample_scheme
        {
            get { return _sample_scheme; }
            set
            {
                _sample_scheme = value;
                RaisePropertyChanged("sample_scheme");
            }
        }

        private Nullable<int> _sample_item_counter;
        public Nullable<int> sample_item_counter
        {
            get { return _sample_item_counter; }
            set
            {
                _sample_item_counter = value;
                RaisePropertyChanged("sample_item_counter");
            }
        }

        private string _insp_severity;
        public string insp_severity
        {
            get { return _insp_severity; }
            set
            {
                _insp_severity = value;
                RaisePropertyChanged("insp_severity");
            }
        }

        private Nullable<int> _lot_size;
        public Nullable<int> lot_size
        {
            get { return _lot_size; }
            set
            {
                _lot_size = value;
                RaisePropertyChanged("lot_size");
            }
        }

        private Nullable<int> _no_of_units;
        public Nullable<int> no_of_units
        {
            get { return _no_of_units; }
            set
            {
                _no_of_units = value;
                RaisePropertyChanged("no_of_units");
            }
        }

        private Nullable<int> _no_of_samples;
        public Nullable<int> no_of_samples
        {
            get { return _no_of_samples; }
            set
            {
                _no_of_samples = value;
                RaisePropertyChanged("no_of_samples");
            }
        }

        private Nullable<int> _accept_no;
        public Nullable<int> accept_no
        {
            get { return _accept_no; }
            set
            {
                _accept_no = value;
                RaisePropertyChanged("accept_no");
            }
        }

        private Nullable<int> _reject_no;
        public Nullable<int> reject_no
        {
            get { return _reject_no; }
            set
            {
                _reject_no = value;
                RaisePropertyChanged("reject_no");
            }
        }

        private Nullable<int> _accept_no2;
        public Nullable<int> accept_no2
        {
            get { return _accept_no2; }
            set
            {
                _accept_no2 = value;
                RaisePropertyChanged("accept_no2");
            }
        }

        private Nullable<int> _reject_no2;
        public Nullable<int> reject_no2
        {
            get { return _reject_no2; }
            set
            {
                _reject_no2 = value;
                RaisePropertyChanged("reject_no2");
            }
        }

        private Nullable<int> _accept_no3;
        public Nullable<int> accept_no3
        {
            get { return _accept_no3; }
            set
            {
                _accept_no3 = value;
                RaisePropertyChanged("accept_no3");
            }
        }

        private Nullable<int> _reject_no3;
        public Nullable<int> reject_no3
        {
            get { return _reject_no3; }
            set
            {
                _reject_no3 = value;
                RaisePropertyChanged("reject_no3");
            }
        }

        private Nullable<int> _accept_no4;
        public Nullable<int> accept_no4
        {
            get { return _accept_no4; }
            set
            {
                _accept_no4 = value;
                RaisePropertyChanged("accept_no4");
            }
        }

        private Nullable<int> _reject_no4;
        public Nullable<int> reject_no4
        {
            get { return _reject_no4; }
            set
            {
                _reject_no4 = value;
                RaisePropertyChanged("reject_no4");
            }
        }

        private Nullable<int> _accept_no5;
        public Nullable<int> accept_no5
        {
            get { return _accept_no5; }
            set
            {
                _accept_no5 = value;
                RaisePropertyChanged("accept_no5");
            }
        }

        private Nullable<int> _reject_no5;
        public Nullable<int> reject_no5
        {
            get { return _reject_no5; }
            set
            {
                _reject_no5 = value;
                RaisePropertyChanged("reject_no5");
            }
        }

        private Nullable<int> _accept_no6;
        public Nullable<int> accept_no6
        {
            get { return _accept_no6; }
            set
            {
                _accept_no6 = value;
                RaisePropertyChanged("accept_no6");
            }
        }

        private Nullable<int> _reject_no6;
        public Nullable<int> reject_no6
        {
            get { return _reject_no6; }
            set
            {
                _reject_no6 = value;
                RaisePropertyChanged("reject_no6");
            }
        }

        private Nullable<int> _accept_no7;
        public Nullable<int> accept_no7
        {
            get { return _accept_no7; }
            set
            {
                _accept_no7 = value;
                RaisePropertyChanged("accept_no7");
            }
        }

        private Nullable<int> _reject_no7;
        public Nullable<int> reject_no7
        {
            get { return _reject_no7; }
            set
            {
                _reject_no7 = value;
                RaisePropertyChanged("reject_no7");
            }
        }

        private string _k_factor;
        public string k_factor
        {
            get { return _k_factor; }
            set
            {
                _k_factor = value;
                RaisePropertyChanged("k_factor");
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

        private string _editby;
        public string editby
        {
            get { return _editby; }
            set
            {
                _editby = value;
                RaisePropertyChanged("editby");
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

        private Nullable<System.DateTime> _doc_date;
        public Nullable<System.DateTime> doc_date
        {
            get { return _doc_date; }
            set
            {
                _doc_date = value;
                RaisePropertyChanged("doc_date");
            }
        }

        private Nullable<int> _sample_size;
        public Nullable<int> sample_size
        {
            get { return _sample_size; }
            set
            {
                _sample_size = value;
                RaisePropertyChanged("sample_size");
            }
        }


    }

    public class MultipleContext_QMS_M035
    {
        public List<QMS_M038_P> SeverityMaster { get; set; }
        public List<QMS_M035_Flip> BackFlipData { get; set; }
        public List<QMS_M035> MasterEntity { get; set; }
        public ObservableCollection <QMS_M035_A> ItemsEntity { get; set; }
    }
}
