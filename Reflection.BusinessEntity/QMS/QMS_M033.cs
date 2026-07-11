using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.QMS
{
    public class QMS_M0033 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private string _prof_code;
        public string prof_code
        {
            get { return _prof_code; }
            set
            {
                _prof_code = value;
                RaisePropertyChanged("prof_code");
            }
        }

        private string _short_text;
        public string short_text
        {
            get { return _short_text; }
            set
            {
                _short_text = value;
                RaisePropertyChanged("short_text");
            }
        }

        private string _prof_type;
        public string prof_type
        {
            get { return _prof_type; }
            set
            {
                _prof_type = value;
                RaisePropertyChanged("prof_type");
            }
        }

        private string _record_use;
        public string record_use
        {
            get { return _record_use; }
            set
            {
                _record_use = value;
                RaisePropertyChanged("record_use");
            }
        }

        private string _active;
        public string active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
            }
        }

        private string _Location_id;
        public string Location_id
        {
            get { return _Location_id; }
            set
            {
                _Location_id = value;
                RaisePropertyChanged("Location_id");
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



        //Scalar
        public string XDOC_A { get; set; }


        private string _prof_type_name;
        public string prof_type_name
        {
            get { return _prof_type_name; }
            set
            {
                _prof_type_name = value;
                RaisePropertyChanged("prof_type_name");
            }
        }
        

    }

    public class QMS_M0033_A : ObjectBase
    {
        private int? _id;
        public int? id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged("id");
            }
        }

        private string _prof_code;
        public string prof_code
        {
            get { return _prof_code; }
            set
            {
                _prof_code = value;
                RaisePropertyChanged("prof_code");
            }
        }

        private string _prof_type;
        public string prof_type
        {
            get { return _prof_type; }
            set
            {
                _prof_type = value;
                RaisePropertyChanged("prof_type");
            }
        }

        private string _char_code;
        public string char_code
        {
            get { return _char_code; }
            set
            {
                _char_code = value;
                RaisePropertyChanged("char_code");
            }
        }

        private string _char_value;
        public string char_value
        {
            get { return _char_value; }
            set
            {
                _char_value = value;
                RaisePropertyChanged("char_value");
            }
        }

        private string _ver_nos;
        public string ver_nos
        {
            get { return _ver_nos; }
            set
            {
                _ver_nos = value;
                RaisePropertyChanged("ver_nos");
            }
        }

        private DateTime? _valid_from;
        public DateTime? valid_from
        {
            get { return _valid_from; }
            set
            {
                _valid_from = value;
                RaisePropertyChanged("valid_from");
            }
        }

        private string _ver_noc;
        public string ver_noc 
        {
            get { return _ver_noc; }
            set
            {
                _ver_noc = value;
                RaisePropertyChanged("ver_noc");
            }
        }

        private string _short_text;
        public string short_text
        {
            get { return _short_text; }
            set
            {
                _short_text = value;
                RaisePropertyChanged("short_text");
            }
        }

        private string _long_text;
        public string long_text
        {
            get { return _long_text; }
            set
            {
                _long_text = value;
                RaisePropertyChanged("long_text");
            }
        }

        private string _v_code;
        public string v_code
        {
            get { return _v_code; }
            set
            {
                _v_code = value;
                RaisePropertyChanged("v_code");
            }
        }

        private string _def_class;
        public string def_class
        {
            get { return _def_class; }
            set
            {
                _def_class = value;
                RaisePropertyChanged("def_class");
            }
        }

        private string _curr_key;
        public string curr_key
        {
            get { return _curr_key; }
            set
            {
                _curr_key = value;
                RaisePropertyChanged("curr_key");
            }
        }

        private decimal? _nc_cost;
        public decimal? nc_cost
        {
            get { return _nc_cost; }
            set
            {
                _nc_cost = value;
                RaisePropertyChanged("nc_cost");
            }
        }

        private int? _quality_score;
        public int? quality_score
        {
            get { return _quality_score; }
            set
            {
                _quality_score = value;
                RaisePropertyChanged("quality_score");
            }
        }

        private string _fa_code;
        public string fa_code
        {
            get { return _fa_code; }
            set
            {
                _fa_code = value;
                RaisePropertyChanged("fa_code");
            }
        }

        private string _ud_code;
        public string ud_code
        {
            get { return _ud_code; }
            set
            {
                _ud_code = value;
                RaisePropertyChanged("ud_code");
            }
        }

        private string _active;
        public string active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
            }
        }

        private string _location_id;
        public string location_id
        {
            get { return _location_id; }
            set
            {
                _location_id = value;
                RaisePropertyChanged("location_id");
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

        //Scalar
        private string _char_name;
        public string char_name
        {
            get { return _char_name; }
            set
            {
                _char_name = value;
                RaisePropertyChanged("char_name");
            }
        }

        private string _prof_name;
        public string prof_name
        {
            get { return _prof_name; }
            set
            {
                _prof_name = value;
                RaisePropertyChanged("prof_name");
            }
        }

        private string _def_class_name;
        public string def_class_name
        {
            get { return _def_class_name; }
            set
            {
                _def_class_name = value;
                RaisePropertyChanged("def_class_name");
            }
        }


        private string _font_family;
        public string font_family
        {
            get { return _font_family; }
            set { _font_family = value; RaisePropertyChanged("font_family"); }
        }
        private float _font_size;
        public float font_size
        {
            get { return _font_size; }
            set { _font_size = value; RaisePropertyChanged("font_size"); }
        }
        private bool? _bold;
        public bool? bold
        {
            get { return _bold; }
            set { _bold = value; RaisePropertyChanged("bold"); }
        }
        private string _color;
        public string color
        {
            get { return _color; }
            set { _color = value; RaisePropertyChanged("color"); }
        }

    }

    //public class QMS_M033 : ObjectBase
    //{
    //    public static event EventHandler ModelEntityUpdated = delegate { };
    //    private string _para_prof_code;
    //    public string para_prof_code
    //    {
    //        get { return _para_prof_code; }
    //        set
    //        {
    //            _para_prof_code = value;
    //            RaisePropertyChanged("para_prof_code");
    //        }
    //    }

    //    private string _para_prof_desc;
    //    public string para_prof_desc
    //    {
    //        get { return _para_prof_desc; }
    //        set
    //        {
    //            _para_prof_desc = value;
    //            RaisePropertyChanged("para_prof_desc");
    //        }
    //    }

    //    private string _para_type;
    //    public string para_type
    //    {
    //        get { return _para_type; }
    //        set
    //        {
    //            _para_type = value;
    //            RaisePropertyChanged("para_type");
    //        }
    //    }

    //    private string _record_use;
    //    public string record_use
    //    {
    //        get { return _record_use; }
    //        set
    //        {
    //            _record_use = value;
    //            RaisePropertyChanged("record_use");
    //        }
    //    }

    //    private Nullable<bool> _active;
    //    public Nullable<bool> active
    //    {
    //        get { return _active; }
    //        set
    //        {
    //            _active = value;
    //            RaisePropertyChanged("active");
    //        }
    //    }

    //    private string _add_by;
    //    public string add_by
    //    {
    //        get { return _add_by; }
    //        set
    //        {
    //            _add_by = value;
    //            RaisePropertyChanged("add_by");
    //        }
    //    }

    //    private System.DateTime _add_date;
    //    public System.DateTime add_date
    //    {
    //        get { return _add_date; }
    //        set
    //        {
    //            _add_date = value;
    //            RaisePropertyChanged("add_date");
    //        }
    //    }

    //    private string _editby;
    //    public string editby
    //    {
    //        get { return _editby; }
    //        set
    //        {
    //            _editby = value;
    //            RaisePropertyChanged("editby");
    //        }
    //    }

    //    private Nullable<System.DateTime> _edit_date;
    //    public Nullable<System.DateTime> edit_date
    //    {
    //        get { return _edit_date; }
    //        set
    //        {
    //            _edit_date = value;
    //            RaisePropertyChanged("edit_date");
    //        }
    //    }

    //    private string _Location_Id;
    //    public string Location_Id
    //    {
    //        get { return _Location_Id; }
    //        set
    //        {
    //            _Location_Id = value;
    //            RaisePropertyChanged("Location_Id");
    //        }
    //    }

    //    private string _t_status;
    //    public string t_status
    //    {
    //        get { return _t_status; }
    //        set
    //        {
    //            _t_status = value;
    //            RaisePropertyChanged("t_status");
    //        }
    //    }

    //    private string _lang_key;
    //    public string lang_key
    //    {
    //        get { return _lang_key; }
    //        set
    //        {
    //            _lang_key = value;
    //            RaisePropertyChanged("lang_key");
    //        }
    //    }

    //    private string _comp_code;
    //    public string comp_code
    //    {
    //        get { return _comp_code; }
    //        set
    //        {
    //            _comp_code = value;
    //            RaisePropertyChanged("comp_code");
    //        }
    //    }


    //    public string XmlDataDocument_QMS_M033_Flip { get; set; }
    //    public string XmlDataDocument_QMS_M033_A { get; set; }

    //    //Scalar
    //    private string _para_name;
    //    public string para_name
    //    {
    //        get { return _para_name; }
    //        set
    //        {
    //            _para_name = value;
    //            RaisePropertyChanged("para_name");
    //        }
    //    }
    //}

    //public class QMS_M033_A : ObjectBase
    //{
    //    private int _id;
    //    public int id
    //    {
    //        get { return _id; }
    //        set
    //        {
    //            _id = value;
    //            RaisePropertyChanged("id");
    //        }
    //    }

    //    private string _para_prof_code;
    //    public string para_prof_code
    //    {
    //        get { return _para_prof_code; }
    //        set
    //        {
    //            _para_prof_code = value;
    //            RaisePropertyChanged("para_prof_code");
    //        }
    //    }

    //    private string _para_type;
    //    public string para_type
    //    {
    //        get { return _para_type; }
    //        set
    //        {
    //            _para_type = value;
    //            RaisePropertyChanged("para_type");
    //        }
    //    }

    //    private string _para_code;
    //    public string para_code
    //    {
    //        get { return _para_code; }
    //        set
    //        {
    //            _para_code = value;
    //            RaisePropertyChanged("para_code");
    //        }
    //    }

    //    private string _value_code;
    //    public string value_code
    //    {
    //        get { return _value_code; }
    //        set
    //        {
    //            _value_code = value;
    //            RaisePropertyChanged("value_code");
    //        }
    //    }

    //    private string _version_no_set;
    //    public string version_no_set
    //    {
    //        get { return _version_no_set; }
    //        set
    //        {
    //            _version_no_set = value;
    //            RaisePropertyChanged("version_no_set");
    //        }
    //    }

    //    private Nullable<System.DateTime> _valid_from;
    //    public Nullable<System.DateTime> valid_from
    //    {
    //        get { return _valid_from; }
    //        set
    //        {
    //            _valid_from = value;
    //            RaisePropertyChanged("valid_from");
    //        }
    //    }

    //    private string _version_no_code;
    //    public string version_no_code
    //    {
    //        get { return _version_no_code; }
    //        set
    //        {
    //            _version_no_code = value;
    //            RaisePropertyChanged("version_no_code");
    //        }
    //    }

    //    private string _short_desc;
    //    public string short_desc
    //    {
    //        get { return _short_desc; }
    //        set
    //        {
    //            _short_desc = value;
    //            RaisePropertyChanged("short_desc");
    //        }
    //    }

    //    private string _long_desc;
    //    public string long_desc
    //    {
    //        get { return _long_desc; }
    //        set
    //        {
    //            _long_desc = value;
    //            RaisePropertyChanged("long_desc");
    //        }
    //    }

    //    private string _valuation_code;
    //    public string valuation_code
    //    {
    //        get { return _valuation_code; }
    //        set
    //        {
    //            _valuation_code = value;
    //            RaisePropertyChanged("valuation_code");
    //        }
    //    }

    //    private string _defect_class;
    //    public string defect_class
    //    {
    //        get { return _defect_class; }
    //        set
    //        {
    //            _defect_class = value;
    //            RaisePropertyChanged("defect_class");
    //        }
    //    }

    //    private string _curr_key;
    //    public string curr_key
    //    {
    //        get { return _curr_key; }
    //        set
    //        {
    //            _curr_key = value;
    //            RaisePropertyChanged("curr_key");
    //        }
    //    }

    //    private Nullable<decimal> _non_confirm_cost;
    //    public Nullable<decimal> non_confirm_cost
    //    {
    //        get { return _non_confirm_cost; }
    //        set
    //        {
    //            _non_confirm_cost = value;
    //            RaisePropertyChanged("non_confirm_cost");
    //        }
    //    }

    //    private Nullable<int> _quality_score;
    //    public Nullable<int> quality_score
    //    {
    //        get { return _quality_score; }
    //        set
    //        {
    //            _quality_score = value;
    //            RaisePropertyChanged("quality_score");
    //        }
    //    }

    //    private string _follow_action;
    //    public string follow_action
    //    {
    //        get { return _follow_action; }
    //        set
    //        {
    //            _follow_action = value;
    //            RaisePropertyChanged("follow_action");
    //        }
    //    }

    //    private string _prob_usage_decision;
    //    public string prob_usage_decision
    //    {
    //        get { return _prob_usage_decision; }
    //        set
    //        {
    //            _prob_usage_decision = value;
    //            RaisePropertyChanged("prob_usage_decision");
    //        }
    //    }

    //    private Nullable<bool> _active;
    //    public Nullable<bool> active
    //    {
    //        get { return _active; }
    //        set
    //        {
    //            _active = value;
    //            RaisePropertyChanged("active");
    //        }
    //    }

    //    private string _add_by;
    //    public string add_by
    //    {
    //        get { return _add_by; }
    //        set
    //        {
    //            _add_by = value;
    //            RaisePropertyChanged("add_by");
    //        }
    //    }

    //    private System.DateTime _add_date;
    //    public System.DateTime add_date
    //    {
    //        get { return _add_date; }
    //        set
    //        {
    //            _add_date = value;
    //            RaisePropertyChanged("add_date");
    //        }
    //    }

    //    private string _editby;
    //    public string editby
    //    {
    //        get { return _editby; }
    //        set
    //        {
    //            _editby = value;
    //            RaisePropertyChanged("editby");
    //        }
    //    }

    //    private Nullable<System.DateTime> _edit_date;
    //    public Nullable<System.DateTime> edit_date
    //    {
    //        get { return _edit_date; }
    //        set
    //        {
    //            _edit_date = value;
    //            RaisePropertyChanged("edit_date");
    //        }
    //    }

    //    private string _Location_Id;
    //    public string Location_Id
    //    {
    //        get { return _Location_Id; }
    //        set
    //        {
    //            _Location_Id = value;
    //            RaisePropertyChanged("Location_Id");
    //        }
    //    }

    //    private string _t_status;
    //    public string t_status
    //    {
    //        get { return _t_status; }
    //        set
    //        {
    //            _t_status = value;
    //            RaisePropertyChanged("t_status");
    //        }
    //    }

    //    private string _comp_code;
    //    public string comp_code
    //    {
    //        get { return _comp_code; }
    //        set
    //        {
    //            _comp_code = value;
    //            RaisePropertyChanged("comp_code");
    //        }
    //    }

    //    private string _lang_key;
    //    public string lang_key
    //    {
    //        get { return _lang_key; }
    //        set
    //        {
    //            _lang_key = value;
    //            RaisePropertyChanged("lang_key");
    //        }
    //    }

    //    //Scalar
    //    private string _para_value;
    //    public string para_value
    //    {
    //        get { return _para_value; }
    //        set
    //        {
    //            _para_value = value;
    //            RaisePropertyChanged("para_value");
    //        }
    //    }

    //    private string _group_code_name;
    //    public string group_code_name
    //    {
    //        get { return _group_code_name; }
    //        set
    //        {
    //            _group_code_name = value;
    //            RaisePropertyChanged("group_code_name");
    //        }
    //    }

    //    private string _def_class_name;
    //    public string def_class_name
    //    {
    //        get { return _def_class_name; }
    //        set
    //        {
    //            _def_class_name = value;
    //            RaisePropertyChanged("def_class_name");
    //        }
    //    }

    //    private string _char_code;
    //    public string char_code
    //    {
    //        get { return _char_code; }
    //        set
    //        {
    //            _char_code = value;
    //            RaisePropertyChanged("char_code");
    //        }
    //    }
    //    private string _para_name;
    //    public string para_name
    //    {
    //        get { return _para_name; }
    //        set
    //        {
    //            _para_name = value;
    //            RaisePropertyChanged("para_name");
    //        }
    //    }
    //    private string _para_prof_desc;
    //    public string para_prof_desc
    //    {
    //        get { return _para_prof_desc; }
    //        set
    //        {
    //            _para_prof_desc = value;
    //            RaisePropertyChanged("para_prof_desc");
    //        }
    //    }

    //}

    //public class MultipleContext_QMS_M033
    //{
    //    public List<QMS_M032_P> CatlogMaster { get; set; }
    //    public List<QMS_M031_P> DefectClassMaster { get; set; }
    //    public List<QMS_M033_Flip> BackFlipData { get; set; }
    //    public List<QMS_M0033> MasterEntity { get; set; }
    //    public ObservableCollection<QMS_M0033_A> ItemsEntity { get; set; }
    //    public List<QMS_M009_G_P> GroupCodeData { get; set; }
    //    public List<QMS_M009_G_P> CodeMaster { get; set; }
    //}
}
