using Reflection.BusinessEntity.QMS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.ADM
{
    public class Classification : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        internal bool? _selected { get; set; }
        public bool? selected
        {
            get { return _selected; }
            set
            {
                if (_selected != value)
                {
                    _selected = value;
                    RaisePropertyChanged("selected");
                }
            }
        }
        private int? _int_char { get; set; }
        public int? int_char
        {
            get { return _int_char; }
            set
            {
                if (_int_char != value)
                {
                    _int_char = value;
                    RaisePropertyChanged("int_char");
                }
            }
        }
        private int? _int_char_obj { get; set; }
        public int? int_char_obj
        {
            get { return _int_char_obj; }
            set
            {
                if (_int_char_obj != value)
                {
                    _int_char_obj = value;
                    RaisePropertyChanged("int_char_obj");
                }
            }
        }
        private int? _eco_counter { get; set; }
        public int? eco_counter
        {
            get { return _eco_counter; }
            set
            {
                if (_eco_counter != value)
                {
                    _eco_counter = value;
                    RaisePropertyChanged("eco_counter");
                }
            }
        }
        private int? _value_counter { get; set; }
        public int? value_counter
        {
            get { return _value_counter; }
            set
            {
                if (_value_counter != value)
                {
                    _value_counter = value;
                    RaisePropertyChanged("value_counter");
                }
            }
        }
        private int? _class_no { get; set; }
        public int? class_no
        {
            get { return _class_no; }
            set
            {
                if (_class_no != value)
                {
                    _class_no = value;
                    RaisePropertyChanged("class_no");
                }
            }
        }
        private string _config_id { get; set; }
        public string config_id
        {
            get { return _config_id; }
            set
            {
                if (_config_id != value)
                {
                    _config_id = value;
                    RaisePropertyChanged("config_id");
                }
            }
        }
        private string _obj_type { get; set; }
        public string obj_type
        {
            get { return _obj_type; }
            set
            {
                if (_obj_type != value)
                {
                    _obj_type = value;
                    RaisePropertyChanged("obj_type");
                }
            }
        }
        private string _obj_type_name { get; set; }
        public string obj_type_name
        {
            get { return _obj_type_name; }
            set
            {
                if (_obj_type_name != value)
                {
                    _obj_type_name = value;
                    RaisePropertyChanged("obj_type_name");
                }
            }
        }
        private string _obj_key { get; set; }
        public string obj_key
        {
            get { return _obj_key; }
            set
            {
                if (_obj_key != value)
                {
                    _obj_key = value;
                    RaisePropertyChanged("obj_key");
                }
            }
        }
        private string _obj_name { get; set; }
        public string obj_name
        {
            get { return _obj_name; }
            set
            {
                if (_obj_name != value)
                {
                    _obj_name = value;
                    RaisePropertyChanged("obj_name");
                }
            }
        }
        private string _ind_obj_class { get; set; }
        public string ind_obj_class
        {
            get { return _ind_obj_class; }
            set
            {
                if (_ind_obj_class != value)
                {
                    _ind_obj_class = value;
                    RaisePropertyChanged("ind_obj_class");
                }
            }
        }
        private int? _item_no { get; set; }
        public int? item_no
        {
            get { return _item_no; }
            set
            {
                if (_item_no != value)
                {
                    _item_no = value;
                    RaisePropertyChanged("item_no");
                }
            }
        }
        private int? _int_counter { get; set; }
        public int? int_counter
        {
            get { return _int_counter; }
            set
            {
                if (_int_counter != value)
                {
                    _int_counter = value;
                    RaisePropertyChanged("int_counter");
                }
            }
        }
        private string _class_code { get; set; }
        public string class_code
        {
            get { return _class_code; }
            set
            {
                if (_class_code != value)
                {
                    _class_code = value;
                    RaisePropertyChanged("class_code");
                }
            }
        }
        private string _class_type { get; set; }
        public string class_type
        {
            get { return _class_type; }
            set
            {
                if (_class_type != value)
                {
                    _class_type = value;
                    RaisePropertyChanged("class_type");
                }
            }
        }
        private string _class_group { get; set; }
        public string class_group
        {
            get { return _class_group; }
            set
            {
                if (_class_group != value)
                {
                    _class_group = value;
                    RaisePropertyChanged("class_group");
                }
            }
        }
        private string _class_name { get; set; }
        public string class_name
        {
            get { return _class_name; }
            set
            {
                if (_class_name != value)
                {
                    _class_name = value;
                    RaisePropertyChanged("class_name");
                }
            }
        }
        private string _char_code { get; set; }
        public string char_code
        {
            get { return _char_code; }
            set
            {
                if (_char_code != value)
                {
                    _char_code = value;
                    RaisePropertyChanged("char_code");
                }
            }
        }
        private string _char_name { get; set; }
        public string char_name
        {
            get { return _char_name; }
            set
            {
                if (_char_name != value)
                {
                    _char_name = value;
                    RaisePropertyChanged("char_name");
                }
            }
        }
        private string _char_value { get; set; }
        public string char_value
        {
            get { return _char_value; }
            set
            {
                if (_char_value != value)
                {
                    _char_value = value;
                    RaisePropertyChanged("char_value");
                }
            }
        }
        private string _long_text { get; set; }
        public string long_text
        {
            get { return _long_text; }
            set
            {
                if (_long_text != value)
                {
                    _long_text = value;
                    RaisePropertyChanged("long_text");
                }
            }
        }
        private string _data_type { get; set; }
        public string data_type
        {
            get { return _data_type; }
            set
            {
                if (_data_type != value)
                {
                    _data_type = value;
                    RaisePropertyChanged("data_type");
                }
            }
        }
        private int? _priority { get; set; }
        public int? priority
        {
            get { return _priority; }
            set
            {
                if (_priority != value)
                {
                    _priority = value;
                    RaisePropertyChanged("priority");
                }
            }
        }
        private int? _no_of_char { get; set; }
        public int? no_of_char
        {
            get { return _no_of_char; }
            set
            {
                if (_no_of_char != value)
                {
                    _no_of_char = value;
                    RaisePropertyChanged("no_of_char");
                }
            }
        }
        private int? _no_of_dec { get; set; }
        public int? no_of_dec
        {
            get { return _no_of_dec; }
            set
            {
                if (_no_of_dec != value)
                {
                    _no_of_dec = value;
                    RaisePropertyChanged("no_of_dec");
                }
            }
        }
        private string _ind_sign { get; set; }
        public string ind_sign
        {
            get { return _ind_sign; }
            set
            {
                if (_ind_sign != value)
                {
                    _ind_sign = value;
                    RaisePropertyChanged("ind_sign");
                }
            }
        }
        private string _ind_case { get; set; }
        public string ind_case
        {
            get { return _ind_case; }
            set
            {
                if (_ind_case != value)
                {
                    _ind_case = value;
                    RaisePropertyChanged("ind_case");
                }
            }
        }
        private string _char_group { get; set; }
        public string char_group
        {
            get { return _char_group; }
            set
            {
                if (_char_group != value)
                {
                    _char_group = value;
                    RaisePropertyChanged("char_group");
                }
            }
        }
        private string _group_name { get; set; }
        public string group_name
        {
            get { return _group_name; }
            set
            {
                if (_group_name != value)
                {
                    _group_name = value;
                    RaisePropertyChanged("group_name");
                }
            }
        }
        private string _ind_char { get; set; }
        public string ind_char
        {
            get { return _ind_char; }
            set
            {
                if (_ind_char != value)
                {
                    _ind_char = value;
                    RaisePropertyChanged("ind_char");
                }
            }
        }
        private string _unit_code { get; set; }
        public string unit_code
        {
            get { return _unit_code; }
            set
            {
                if (_unit_code != value)
                {
                    _unit_code = value;
                    RaisePropertyChanged("unit_code");
                }
            }
        }
        private string _unit_code2 { get; set; }
        public string unit_code2
        {
            get { return _unit_code2; }
            set
            {
                if (_unit_code2 != value)
                {
                    _unit_code2 = value;
                    RaisePropertyChanged("unit_code2");
                }
            }
        }
        private string _base_uom { get; set; }
        public string base_uom
        {
            get { return _base_uom; }
            set
            {
                if (_base_uom != value)
                {
                    _base_uom = value;
                    RaisePropertyChanged("base_uom");
                }
            }
        }
        private string _ind_add { get; set; }
        public string ind_add
        {
            get { return _ind_add; }
            set
            {
                if (_ind_add != value)
                {
                    _ind_add = value;
                    RaisePropertyChanged("ind_add");
                }
            }
        }
        private string _ind_mv { get; set; }
        public string ind_mv
        {
            get { return _ind_mv; }
            set
            {
                if (_ind_mv != value)
                {
                    _ind_mv = value;
                    RaisePropertyChanged("ind_mv");
                }
            }
        }
        private string _t_status { get; set; }
        public string t_status
        {
            get { return _t_status; }
            set
            {
                if (_t_status != value)
                {
                    _t_status = value;
                    RaisePropertyChanged("t_status");
                }
            }
        }
        private string _t_display { get; set; }
        public string t_display
        {
            get { return _t_display; }
            set
            {
                if (_t_display != value)
                {
                    _t_display = value;
                    RaisePropertyChanged("t_display");
                }
            }
        }
        private string _active { get; set; }
        public string active
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
        private string _doc_no { get; set; }
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                if (_doc_no != value)
                {
                    _doc_no = value;
                    RaisePropertyChanged("doc_no");
                }
            }
        }
        private string _doc_cat { get; set; }
        public string doc_cat
        {
            get { return _doc_cat; }
            set
            {
                if (_doc_cat != value)
                {
                    _doc_cat = value;
                    RaisePropertyChanged("doc_cat");
                }
            }
        }
        private string _doc_type { get; set; }
        public string doc_type
        {
            get { return _doc_type; }
            set
            {
                if (_doc_type != value)
                {
                    _doc_type = value;
                    RaisePropertyChanged("doc_type");
                }
            }
        }
        private string _prof_type { get; set; }
        public string prof_type
        {
            get { return _prof_type; }
            set
            {
                if (_prof_type != value)
                {
                    _prof_type = value;
                    RaisePropertyChanged("prof_type");
                }
            }
        }
        private string _prof_code { get; set; }
        public string prof_code
        {
            get { return _prof_code; }
            set
            {
                if (_prof_code != value)
                {
                    _prof_code = value;
                    RaisePropertyChanged("prof_code");
                }
            }
        }
        private string _para_type { get; set; }
        public string para_type
        {
            get { return _para_type; }
            set
            {
                if (_para_type != value)
                {
                    _para_type = value;
                    RaisePropertyChanged("para_type");
                }
            }
        }
        private string _para_code { get; set; }
        public string para_code
        {
            get { return _para_code; }
            set
            {
                if (_para_code != value)
                {
                    _para_code = value;
                    RaisePropertyChanged("para_code");
                }
            }
        }
        private string _para_name { get; set; }
        public string para_name
        {
            get { return _para_name; }
            set
            {
                if (_para_name != value)
                {
                    _para_name = value;
                    RaisePropertyChanged("para_name");
                }
            }
        }
        private string _para_value { get; set; }
        public string para_value
        {
            get { return _para_value; }
            set
            {
                if (_para_value != value)
                {
                    _para_value = value;
                    RaisePropertyChanged("para_value");
                }
            }
        }
        private string _para_set { get; set; }
        public string para_set
        {
            get { return _para_set; }
            set
            {
                if (_para_set != value)
                {
                    _para_set = value;
                    RaisePropertyChanged("para_set");
                }
            }
        }
        private DateTime? _valid_from { get; set; }
        public DateTime? valid_from
        {
            get { return _valid_from; }
            set
            {
                if (_valid_from != value)
                {
                    _valid_from = value;
                    RaisePropertyChanged("valid_from");
                }
            }
        }
        private DateTime? _valid_to { get; set; }
        public DateTime? valid_to
        {
            get { return _valid_to; }
            set
            {
                if (_valid_to != value)
                {
                    _valid_to = value;
                    RaisePropertyChanged("valid_to");
                }
            }
        }
        private string _dep_code { get; set; }
        public string dep_code
        {
            get { return _dep_code; }
            set
            {
                if (_dep_code != value)
                {
                    _dep_code = value;
                    RaisePropertyChanged("dep_code");
                }
            }
        }
        private string _default_value { get; set; }
        public string default_value
        {
            get { return _default_value; }
            set
            {
                if (_default_value != value)
                {
                    _default_value = value;
                    RaisePropertyChanged("default_value");
                }
            }
        }
        private string _obj_id { get; set; }
        public string obj_id
        {
            get { return _obj_id; }
            set
            {
                if (_obj_id != value)
                {
                    _obj_id = value;
                    RaisePropertyChanged("obj_id");
                }
            }
        }
        private double? _floating_from { get; set; }
        public double? floating_from
        {
            get { return _floating_from; }
            set
            {
                if (_floating_from != value)
                {
                    _floating_from = value;
                    RaisePropertyChanged("floating_from");
                }
            }
        }
        private double? _floating_to { get; set; }
        public double? floating_to
        {
            get { return _floating_to; }
            set
            {
                if (_floating_to != value)
                {
                    _floating_to = value;
                    RaisePropertyChanged("floating_to");
                }
            }
        }
        private double? _tol_from { get; set; }
        public double? tol_from
        {
            get { return _tol_from; }
            set
            {
                if (_tol_from != value)
                {
                    _tol_from = value;
                    RaisePropertyChanged("tol_from");
                }
            }
        }
        private double? _tol_to { get; set; }
        public double? tol_to
        {
            get { return _tol_to; }
            set
            {
                if (_tol_to != value)
                {
                    _tol_to = value;
                    RaisePropertyChanged("tol_to");
                }
            }
        }
        private string _ind_tol { get; set; }
        public string ind_tol
        {
            get { return _ind_tol; }
            set
            {
                if (_ind_tol != value)
                {
                    _ind_tol = value;
                    RaisePropertyChanged("ind_tol");
                }
            }
        }
        private double? _tol_inc { get; set; }
        public double? tol_inc
        {
            get { return _tol_inc; }
            set
            {
                if (_tol_inc != value)
                {
                    _tol_inc = value;
                    RaisePropertyChanged("tol_inc");
                }
            }
        }
        private string _lang_key { get; set; }
        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                if (_lang_key != value)
                {
                    _lang_key = value;
                    RaisePropertyChanged("lang_key");
                }
            }
        }
        private string _ind_comp { get; set; }
        public string ind_comp
        {
            get { return _ind_comp; }
            set
            {
                if (_ind_comp != value)
                {
                    _ind_comp = value;
                    RaisePropertyChanged("ind_comp");
                }
            }
        }
        private string _ind_bom { get; set; }
        public string ind_bom
        {
            get { return _ind_bom; }
            set
            {
                if (_ind_bom != value)
                {
                    _ind_bom = value;
                    RaisePropertyChanged("ind_bom");
                }
            }
        }
        private string _ind_task_list { get; set; }
        public string ind_task_list
        {
            get { return _ind_task_list; }
            set
            {
                if (_ind_task_list != value)
                {
                    _ind_task_list = value;
                    RaisePropertyChanged("ind_task_list");
                }
            }
        }
        private string _ind_rel { get; set; }
        public string ind_rel
        {
            get { return _ind_rel; }
            set
            {
                if (_ind_rel != value)
                {
                    _ind_rel = value;
                    RaisePropertyChanged("ind_rel");
                }
            }
        }
        private string _profile_code { get; set; }
        public string profile_code
        {
            get { return _profile_code; }
            set
            {
                if (_profile_code != value)
                {
                    _profile_code = value;
                    RaisePropertyChanged("profile_code");
                }
            }
        }
        private string _profile_name { get; set; }
        public string profile_name
        {
            get { return _profile_name; }
            set
            {
                if (_profile_name != value)
                {
                    _profile_name = value;
                    RaisePropertyChanged("profile_name");
                }
            }
        }
        private string _sort_field { get; set; }
        public string sort_field
        {
            get { return _sort_field; }
            set
            {
                if (_sort_field != value)
                {
                    _sort_field = value;
                    RaisePropertyChanged("sort_field");
                }
            }
        }
        private string _curr_code { get; set; }
        public string curr_code
        {
            get { return _curr_code; }
            set
            {
                if (_curr_code != value)
                {
                    _curr_code = value;
                    RaisePropertyChanged("curr_code");
                }
            }
        }
        private string _short_text { get; set; }
        public string short_text
        {
            get { return _short_text; }
            set
            {
                if (_short_text != value)
                {
                    _short_text = value;
                    RaisePropertyChanged("short_text");
                }
            }
        }
        private string _char_type { get; set; }
        public string char_type
        {
            get { return _char_type; }
            set
            {
                if (_char_type != value)
                {
                    _char_type = value;
                    RaisePropertyChanged("char_type");
                }
            }
        }
        private string _char_ver { get; set; }
        public string char_ver
        {
            get { return _char_ver; }
            set
            {
                if (_char_ver != value)
                {
                    _char_ver = value;
                    RaisePropertyChanged("char_ver");
                }
            }
        }
        private string _char_loc { get; set; }
        public string char_loc
        {
            get { return _char_loc; }
            set
            {
                if (_char_loc != value)
                {
                    _char_loc = value;
                    RaisePropertyChanged("char_loc");
                }
            }
        }
        private string _way_char { get; set; }
        public string way_char
        {
            get { return _way_char; }
            set
            {
                if (_way_char != value)
                {
                    _way_char = value;
                    RaisePropertyChanged("way_char");
                }
            }
        }
        private string _qual_code { get; set; }
        public string qual_code
        {
            get { return _qual_code; }
            set
            {
                if (_qual_code != value)
                {
                    _qual_code = value;
                    RaisePropertyChanged("qual_code");
                }
            }
        }
        private double? _up_limit { get; set; }
        public double? up_limit
        {
            get { return _up_limit; }
            set
            {
                if (_up_limit != value)
                {
                    _up_limit = value;
                    RaisePropertyChanged("up_limit");
                }
            }
        }
        private double? _low_limit { get; set; }
        public double? low_limit
        {
            get { return _low_limit; }
            set
            {
                if (_low_limit != value)
                {
                    _low_limit = value;
                    RaisePropertyChanged("low_limit");
                }
            }
        }
        private string _separator { get; set; }
        public string separator
        {
            get { return _separator; }
            set
            {
                if (_separator != value)
                {
                    _separator = value;
                    RaisePropertyChanged("separator");
                }
            }
        }
        private string _location_id { get; set; }
        public string location_id
        {
            get { return _location_id; }
            set
            {
                if (_location_id != value)
                {
                    _location_id = value;
                    RaisePropertyChanged("location_id");
                }
            }
        }
        private string _comp_code { get; set; }
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
        //private string _value_code { get; set; }
        //public string value_code
        //{
        //    get { return _value_code; }
        //    set
        //    {
        //        if (_value_code != value)
        //        {
        //            _value_code = value;
        //            RaisePropertyChanged("value_code");
        //        }
        //    }
        //}
        //private string _value_name { get; set; }
        //public string value_name
        //{
        //    get { return _value_name; }
        //    set
        //    {
        //        if (_value_name != value)
        //        {
        //            _value_name = value;
        //            RaisePropertyChanged("value_name");
        //        }
        //    }
        //}
        private string _ver_no { get; set; }
        public string ver_no
        {
            get { return _ver_no; }
            set
            {
                if (_ver_no != value)
                {
                    _ver_no = value;
                    RaisePropertyChanged("ver_no");
                }
            }
        }
        private string _def_class { get; set; }
        public string def_class
        {
            get { return _def_class; }
            set
            {
                if (_def_class != value)
                {
                    _def_class = value;
                    RaisePropertyChanged("def_class");
                }
            }
        }
        private string _def_class_name { get; set; }
        public string def_class_name
        {
            get { return _def_class_name; }
            set
            {
                if (_def_class_name != value)
                {
                    _def_class_name = value;
                    RaisePropertyChanged("def_class_name");
                }
            }
        }
        private double? _quality_score { get; set; }
        public double? quality_score
        {
            get { return _quality_score; }
            set
            {
                if (_quality_score != value)
                {
                    _quality_score = value;
                    RaisePropertyChanged("quality_score");
                }
            }
        }
        private string _v_code { get; set; }
        public string v_code
        {
            get { return _v_code; }
            set
            {
                if (_v_code != value)
                {
                    _v_code = value;
                    RaisePropertyChanged("v_code");
                }
            }
        }
        private string _v_name { get; set; }
        public string v_name
        {
            get { return _v_name; }
            set
            {
                if (_v_name != value)
                {
                    _v_name = value;
                    RaisePropertyChanged("v_name");
                }
            }
        }
        private string _ud_code { get; set; }
        public string ud_code
        {
            get { return _ud_code; }
            set
            {
                if (_ud_code != value)
                {
                    _ud_code = value;
                    RaisePropertyChanged("ud_code");
                }
            }
        }

        private string _XDOC_A { get; set; }
        public string XDOC_A
        {
            get { return _XDOC_A; }
            set
            {
                if (_XDOC_A != value)
                {
                    _XDOC_A = value;
                    RaisePropertyChanged("XDOC_A");
                }
            }
        }
        private string _XDOC_B { get; set; }
        public string XDOC_B
        {
            get { return _XDOC_B; }
            set
            {
                if (_XDOC_B != value)
                {
                    _XDOC_B = value;
                    RaisePropertyChanged("XDOC_B");
                }
            }
        }
        //private string _key_value { get; set; }
        //public string key_value
        //{
        //    get { return _key_value; }
        //    set
        //    {
        //        if (_key_value != value)
        //        {
        //            _key_value = value;
        //            RaisePropertyChanged("key_value");
        //        }
        //    }
        //}

        public override string ToString()
        {
            return string.Format("{0}", key_value);
        }

    }

    public class ADM_M0111 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int? _int_char;
        public int? int_char
        {
            get { return _int_char; }
            set { _int_char = value; RaisePropertyChanged("int_char"); }
        }

        private int? _eco_counter;
        public int? eco_counter
        {
            get { return _eco_counter; }
            set { _eco_counter = value; RaisePropertyChanged("eco_counter"); }
        }

        private string _char_code;
        public string char_code
        {
            get { return _char_code; }
            set { _char_code = value; RaisePropertyChanged("char_code"); }
        }

        private string _char_name;
        public string char_name
        {
            get { return _char_name; }
            set { _char_name = value; RaisePropertyChanged("char_name"); }
        }

        private string _data_type;
        public string data_type
        {
            get { return _data_type; }
            set { _data_type = value; RaisePropertyChanged("data_type"); }
        }

        private int? _no_of_char;
        public int? no_of_char
        {
            get { return _no_of_char; }
            set { _no_of_char = value; RaisePropertyChanged("no_of_char"); }
        }

        private int? _no_of_dec;
        public int? no_of_dec
        {
            get { return _no_of_dec; }
            set { _no_of_dec = value; RaisePropertyChanged("no_of_dec"); }
        }

        private string _ind_sign;
        public string ind_sign
        {
            get { return _ind_sign; }
            set { _ind_sign = value; RaisePropertyChanged("ind_sign"); }
        }

        private string _ind_case;
        public string ind_case
        {
            get { return _ind_case; }
            set { _ind_case = value; RaisePropertyChanged("ind_case"); }
        }

        private string _char_group;
        public string char_group
        {
            get { return _char_group; }
            set { _char_group = value; RaisePropertyChanged("char_group"); }
        }

        private string _ind_char;
        public string ind_char
        {
            get { return _ind_char; }
            set { _ind_char = value; RaisePropertyChanged("ind_char"); }
        }

        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code"); }
        }

        private string _ind_mv;
        public string ind_mv
        {
            get { return _ind_mv; }
            set { _ind_mv = value; RaisePropertyChanged("ind_mv"); }
        }

        private string _ind_add;
        public string ind_add
        {
            get { return _ind_add; }
            set { _ind_add = value; RaisePropertyChanged("ind_add"); }
        }

        private string _ind_interval;
        public string ind_interval
        {
            get { return _ind_interval; }
            set { _ind_interval = value; RaisePropertyChanged("ind_interval"); }
        }

        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }
        }

        private string _active;
        public string active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }

        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set { _doc_no = value; RaisePropertyChanged("doc_no"); }
        }

        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set { _doc_cat = value; RaisePropertyChanged("doc_cat"); }
        }

        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set { _doc_type = value; RaisePropertyChanged("doc_type"); }
        }
        private string _prof_type;
        public string prof_type
        {
            get { return _prof_type; }
            set { _prof_type = value; RaisePropertyChanged("prof_type"); }
        }
        private string _para_code;
        public string para_code
        {
            get { return _para_code; }
            set { _para_code = value; RaisePropertyChanged("para_code"); }
        }

        private string _para_set;
        public string para_set
        {
            get { return _para_set; }
            set { _para_set = value; RaisePropertyChanged("para_set"); }
        }

        private DateTime? _valid_from;
        public DateTime? valid_from
        {
            get { return _valid_from; }
            set { _valid_from = value; RaisePropertyChanged("valid_from"); }
        }

        private DateTime? _valid_to;
        public DateTime? valid_to
        {
            get { return _valid_to; }
            set { _valid_to = value; RaisePropertyChanged("valid_to"); }
        }

        private string _curr_code;
        public string curr_code
        {
            get { return _curr_code; }
            set { _curr_code = value; RaisePropertyChanged("curr_code"); }
        }

        private string _char_type;
        public string char_type
        {
            get { return _char_type; }
            set { _char_type = value; RaisePropertyChanged("char_type"); }
        }

        private string _ver_no;
        public string ver_no
        {
            get { return _ver_no; }
            set { _ver_no = value; RaisePropertyChanged("ver_no"); }
        }

        private string _record_use;
        public string record_use
        {
            get { return _record_use; }
            set { _record_use = value; RaisePropertyChanged("record_use"); }
        }

        private string _control_data;
        public string control_data
        {
            get { return _control_data; }
            set { _control_data = value; RaisePropertyChanged("control_data"); }
        }

        private string _way_char;
        public string way_char
        {
            get { return _way_char; }
            set { _way_char = value; RaisePropertyChanged("way_char"); }
        }

        private string _tol_key;
        public string tol_key
        {
            get { return _tol_key; }
            set { _tol_key = value; RaisePropertyChanged("tol_key"); }
        }

        private int? _dc_place;
        public int? dc_place
        {
            get { return _dc_place; }
            set { _dc_place = value; RaisePropertyChanged("dc_place"); }
        }

        private double? _target_value;
        public double? target_value
        {
            get { return _target_value; }
            set { _target_value = value; RaisePropertyChanged("target_value"); }
        }

        private string _value1;
        public string value1
        {
            get { return _value1; }
            set { _value1 = value; RaisePropertyChanged("value1"); }
        }

        private double? _up_limit;
        public double? up_limit
        {
            get { return _up_limit; }
            set { _up_limit = value; RaisePropertyChanged("up_limit"); }
        }

        private string _value2;
        public string value2
        {
            get { return _value2; }
            set { _value2 = value; RaisePropertyChanged("value2"); }
        }

        private double? _low_limit;
        public double? low_limit
        {
            get { return _low_limit; }
            set { _low_limit = value; RaisePropertyChanged("low_limit"); }
        }

        private double? _up_tol_limit;
        public double? up_tol_limit
        {
            get { return _up_tol_limit; }
            set { _up_tol_limit = value; RaisePropertyChanged("up_tol_limit"); }
        }

        private double? _low_tol_limit;
        public double? low_tol_limit
        {
            get { return _low_tol_limit; }
            set { _low_tol_limit = value; RaisePropertyChanged("low_tol_limit"); }
        }

        private double? _low_limit1;
        public double? low_limit1
        {
            get { return _low_limit1; }
            set { _low_limit1 = value; RaisePropertyChanged("low_limit1"); }
        }

        private double? _up_limit1;
        public double? up_limit1
        {
            get { return _up_limit1; }
            set { _up_limit1 = value; RaisePropertyChanged("up_limit1"); }
        }

        private string _profile_d1;
        public string profile_d1
        {
            get { return _profile_d1; }
            set { _profile_d1 = value; RaisePropertyChanged("profile_d1"); }
        }

        private string _profile_d2;
        public string profile_d2
        {
            get { return _profile_d2; }
            set { _profile_d2 = value; RaisePropertyChanged("profile_d2"); }
        }

        private string _profile_d3;
        public string profile_d3
        {
            get { return _profile_d3; }
            set { _profile_d3 = value; RaisePropertyChanged("profile_d3"); }
        }

        private string _profile_d4;
        public string profile_d4
        {
            get { return _profile_d4; }
            set { _profile_d4 = value; RaisePropertyChanged("profile_d4"); }
        }

        private string _fract_cal;
        public string fract_cal
        {
            get { return _fract_cal; }
            set { _fract_cal = value; RaisePropertyChanged("fract_cal"); }
        }

        private string _internal_char;
        public string internal_char
        {
            get { return _internal_char; }
            set { _internal_char = value; RaisePropertyChanged("internal_char"); }
        }

        private double? _low_limit2;
        public double? low_limit2
        {
            get { return _low_limit2; }
            set { _low_limit2 = value; RaisePropertyChanged("low_limit2"); }
        }

        private double? _up_limit2;
        public double? up_limit2
        {
            get { return _up_limit2; }
            set { _up_limit2 = value; RaisePropertyChanged("up_limit2"); }
        }

        private string _ind_sp;
        public string ind_sp
        {
            get { return _ind_sp; }
            set { _ind_sp = value; RaisePropertyChanged("ind_sp"); }
        }

        private string _ind_spc;
        public string ind_spc
        {
            get { return _ind_spc; }
            set { _ind_spc = value; RaisePropertyChanged("ind_spc"); }
        }

        private string _ind_as;
        public string ind_as
        {
            get { return _ind_as; }
            set { _ind_as = value; RaisePropertyChanged("ind_as"); }
        }

        private string _ind_ds;
        public string ind_ds
        {
            get { return _ind_ds; }
            set { _ind_ds = value; RaisePropertyChanged("ind_ds"); }
        }

        private string _ind_lti;
        public string ind_lti
        {
            get { return _ind_lti; }
            set { _ind_lti = value; RaisePropertyChanged("ind_lti"); }
        }

        private string _ind_ss;
        public string ind_ss
        {
            get { return _ind_ss; }
            set { _ind_ss = value; RaisePropertyChanged("ind_ss"); }
        }

        private string _ind_ea;
        public string ind_ea
        {
            get { return _ind_ea; }
            set { _ind_ea = value; RaisePropertyChanged("ind_ea"); }
        }

        private string _ind_dr;
        public string ind_dr
        {
            get { return _ind_dr; }
            set { _ind_dr = value; RaisePropertyChanged("ind_dr"); }
        }

        //private string _ind_value;
        //public string ind_value
        //{
        //    get { return _ind_value; }
        //    set { _ind_value = value; RaisePropertyChanged("ind_value");}
        //}

        private string _insp_qual;
        public string insp_qual
        {
            get { return _insp_qual; }
            set { _insp_qual = value; RaisePropertyChanged("insp_qual"); }
        }

        private string _spec_info;
        public string spec_info
        {
            get { return _spec_info; }
            set { _spec_info = value; RaisePropertyChanged("spec_info"); }
        }

        private string _short_text;
        public string short_text
        {
            get { return _short_text; }
            set { _short_text = value; RaisePropertyChanged("short_text"); }
        }
        private string _vs_code;
        public string vs_code
        {
            get { return _vs_code; }
            set { _vs_code = value; RaisePropertyChanged("vs_code"); }
        }
        private string _ref_class;
        public string ref_class
        {
            get { return _ref_class; }
            set { _ref_class = value; RaisePropertyChanged("ref_class"); }
        }
        private string _ind_neg;
        public string ind_neg
        {
            get { return _ind_neg; }
            set { _ind_neg = value; RaisePropertyChanged("ind_neg"); }
        }
        private string _table_name;
        public string table_name
        {
            get { return _table_name; }
            set { _table_name = value; RaisePropertyChanged("table_name"); }
        }
        private string _field_name;
        public string field_name
        {
            get { return _field_name; }
            set { _field_name = value; RaisePropertyChanged("field_name"); }
        }


        // Scalar
        private string _t_display { get; set; }
        public string t_display
        {
            get { return _t_display; }
            set
            {
                if (_t_display != value)
                {
                    _t_display = value;
                    RaisePropertyChanged("t_display");
                }
            }
        }
        private string _sys_char_name;
        public string sys_char_name
        {
            get { return _sys_char_name; }
            set { _sys_char_name = value; RaisePropertyChanged("sys_char_name"); }
        }
        private string _class_name;
        public string class_name
        {
            get { return _class_name; }
            set { _class_name = value; RaisePropertyChanged("class_name"); }
        }
        public string XDOC_A { get; set; }


        public override string ToString()
        {
            return string.Format("{0}", char_code);
        }

    }

    public class ADM_M0112 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        
        private bool? _selected;
        public bool? selected
        {
            get { return _selected; }
            set { _selected = value; RaisePropertyChanged("_selected"); }
        }

        private int? _int_char;
        public int? int_char
        {
            get { return _int_char; }
            set { _int_char = value; RaisePropertyChanged("int_char"); }
        }

        private int? _int_counter;
        public int? int_counter
        {
            get { return _int_counter; }
            set { _int_counter = value; RaisePropertyChanged("int_char"); }
        }

        private int? _eco_counter;
        public int? eco_counter
        {
            get { return _eco_counter; }
            set { _eco_counter = value; RaisePropertyChanged("int_char"); }
        }

        private string _char_code;
        public string char_code
        {
            get { return _char_code; }
            set { _char_code = value; RaisePropertyChanged("char_code"); }
        }

        private string _char_value;
        public string char_value
        {
            get { return _char_value; }
            set { _char_value = value; RaisePropertyChanged("int_char"); }
        }

        private string _long_text;
        public string long_text
        {
            get { return _long_text; }
            set { _long_text = value; RaisePropertyChanged("int_char"); }
        }

        private double? _floating_from;
        public double? floating_from
        {
            get { return _floating_from; }
            set { _floating_from = value; RaisePropertyChanged("int_char"); }
        }

        private double? _floating_to;
        public double? floating_to
        {
            get { return _floating_to; }
            set { _floating_to = value; RaisePropertyChanged("int_char"); }
        }

        private string _dep_code;
        public string dep_code
        {
            get { return _dep_code; }
            set { _dep_code = value; RaisePropertyChanged("int_char"); }
        }

        private string _default_value;
        public string default_value
        {
            get { return _default_value; }
            set { _default_value = value; RaisePropertyChanged("int_char"); }
        }

        private string _obj_id;
        public string obj_id
        {
            get { return _obj_id; }
            set { _obj_id = value; RaisePropertyChanged("int_char"); }
        }

        private double? _tol_from;
        public double? tol_from
        {
            get { return _tol_from; }
            set { _tol_from = value; RaisePropertyChanged("int_char"); }
        }

        private double? _tol_to;
        public double? tol_to
        {
            get { return _tol_to; }
            set { _tol_to = value; RaisePropertyChanged("int_char"); }
        }

        private string _ind_tol;
        public string ind_tol
        {
            get { return _ind_tol; }
            set { _ind_tol = value; RaisePropertyChanged("int_char"); }
        }

        private double? _tol_inc;
        public double? tol_inc
        {
            get { return _tol_inc; }
            set { _tol_inc = value; RaisePropertyChanged("int_char"); }
        }

        private string _active;
        public string active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("int_char"); }
        }

        // scalar
        private string _char_name;
        public string char_name
        {
            get { return _char_name; }
            set { _char_name = value; RaisePropertyChanged("char_name"); }
        }

    }

    public class ADM_M0111_MC : MC_ADM_BE
    {
        public List<ADM_M0111> MASTER_LIST { get; set; }
        public ObservableCollection<ADM_M0112> CHAR_VALUE_OBV_LIST { get; set; }
        public List<QMS_M0032> ProfileTypeList { get; set; }

        //public ObservableCollection<Classification> OBJECT_CLASS_LIST { get; set; }
        //public ObservableCollection<Classification> PROFILE_LIST { get; set; }

    }

    public class ADM_M0126 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private string _obj_key;
        public string obj_key
        {
            get { return _obj_key; }
            set { _obj_key = value; RaisePropertyChanged("obj_key"); }
        }

        private string _class_type;
        public string class_type
        {
            get { return _class_type; }
            set { _class_type = value; RaisePropertyChanged("class_type"); }
        }

        private string _vc_code;
        public string vc_code
        {
            get { return _vc_code; }
            set { _vc_code = value; RaisePropertyChanged("vc_code"); }
        }

        private string _short_text;
        public string short_text
        {
            get { return _short_text; }
            set { _short_text = value; RaisePropertyChanged("short_text"); }
        }

        private string _class_code;
        public string class_code
        {
            get { return _class_code; }
            set { _class_code = value; RaisePropertyChanged("class_code"); }
        }

        private int? _class_no;
        public int? class_no
        {
            get { return _class_no; }
            set { _class_no = value; RaisePropertyChanged("class_no"); }
        }

        private int? _int_counter;
        public int? int_counter
        {
            get { return _int_counter; }
            set { _int_counter = value; RaisePropertyChanged("int_counter"); }
        }

        private string _vc_code_parent;
        public string vc_code_parent
        {
            get { return _vc_code_parent; }
            set { _vc_code_parent = value; RaisePropertyChanged("vc_code_parent"); }
        }

        private string _vc_code_root;
        public string vc_code_root
        {
            get { return _vc_code_root; }
            set { _vc_code_root = value; RaisePropertyChanged("vc_code_root"); }
        }
        private string _obj_type;
        public string obj_type
        {
            get { return _obj_type; }
            set { _obj_type = value; RaisePropertyChanged("obj_type"); }
        }
        private string _active;
        public string active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }

        //Scalar
        private string _class_name;
        public string class_name
        {
            get { return _class_name; }
            set { _class_name = value; RaisePropertyChanged("class_name"); }
        }
        public string XDOC_A { get; set; }
    }

    public class ADM_M0127 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int? _id;
        public int? id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }

        private string _vc_code;
        public string vc_code
        {
            get { return _vc_code; }
            set { _vc_code = value; RaisePropertyChanged("vc_code"); }
        }

        private string _char_code;
        public string char_code
        {
            get { return _char_code; }
            set { _char_code = value; RaisePropertyChanged("char_code"); }
        }

        private string _char_value;
        public string char_value
        {
            get { return _char_value; }
            set { _char_value = value; RaisePropertyChanged("char_value"); }
        }

        //Scalar

        private string _char_name;
        public string char_name
        {
            get { return _char_name; }
            set { _char_name = value; RaisePropertyChanged("char_name"); }
        }
        private string _obj_key;
        public string obj_key
        {
            get { return _obj_key; }
            set { _obj_key = value; RaisePropertyChanged("obj_key"); }
        }
        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code"); }
        }
        private int? _int_char;
        public int? int_char
        {
            get { return _int_char; }
            set { _int_char = value; RaisePropertyChanged("int_char"); }
        }
        private string _ind_interval;
        public string ind_interval
        {
            get { return _ind_interval; }
            set
            {
                _ind_interval = value;
                RaisePropertyChanged("ind_interval");
            }
        }
        private string _ind_mv;
        public string ind_mv
        {
            get { return _ind_mv; }
            set
            {
                _ind_mv = value;
                RaisePropertyChanged("ind_mv");
            }
        }
        private string _text_info;
        public string text_info
        {
            get { return _text_info; }
            set
            {
                _text_info = value;
                RaisePropertyChanged("text_info");
            }
        }
    }

    public class Classification_MC : MC_ADM_BE
    {
        public List<Classification> MASTER_LIST { get; set; }
        public ObservableCollection<Classification> OBJECT_CLASS_LIST { get; set; }
        public ObservableCollection<Classification> PROFILE_LIST { get; set; }
        public ObservableCollection<Classification> CHAR_VALUE_OBV_LIST { get; set; }
    }
    public class MC_ADM_M0126 : MC_ADM_BE
    {
        //public List<ADM_M0126> CHAR_LIST { get; set; }
        //public List<ADM_M0127> VC_VALUE_LIST { get; set; }
        //public ObservableCollection<Classification> OBJECT_CLASS_LIST { get; set; }
        //public ObservableCollection<Classification> PROFILE_LIST { get; set; }
        //public ObservableCollection<Classification> CHAR_VALUE_OBV_LIST { get; set; }
    }


}
