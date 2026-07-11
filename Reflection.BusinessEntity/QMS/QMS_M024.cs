using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity.QMS
{
    public class QMS_M024 : ObjectBase
    {
        private string _tl_code;
        public string tl_code
        {
            get { return _tl_code; }
            set
            {
                _tl_code = value;
                RaisePropertyChanged("tl_code");
            }
        }
        private string _tl_type;
        public string tl_type
        {
            get { return _tl_type; }
            set
            {
                _tl_type = value;
                RaisePropertyChanged("tl_type");
            }
        }
        private string _tl_key;
        public string tl_key
        {
            get { return _tl_key; }
            set
            {
                _tl_key = value;
                RaisePropertyChanged("tl_key");
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
        private string _tech_status_from;
        public string tech_status_from
        {
            get { return _tech_status_from; }
            set
            {
                _tech_status_from = value;
                RaisePropertyChanged("tech_status_from");
            }
        }
        private DateTime? _valid_from_date;
        public DateTime? valid_from_date
        {
            get { return _valid_from_date; }
            set
            {
                _valid_from_date = value;
                RaisePropertyChanged("valid_from_date");
            }
        }
        private string _tl_usage;
        public string tl_usage
        {
            get { return _tl_usage; }
            set
            {
                _tl_usage = value;
                RaisePropertyChanged("tl_usage");
            }
        }
        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set
            {
                _unit_code = value;
                RaisePropertyChanged("unit_code");
            }
        }
        private decimal? _from_lot_size;
        public decimal? from_lot_size
        {
            get { return _from_lot_size; }
            set
            {
                _from_lot_size = value;
                RaisePropertyChanged("from_lot_size");
            }
        }
        private decimal? _to_lot_size;
        public decimal? to_lot_size
        {
            get { return _to_lot_size; }
            set
            {
                _to_lot_size = value;
                RaisePropertyChanged("to_lot_size");
            }
        }
        private string _EmpId;
        public string EmpId
        {
            get { return _EmpId; }
            set
            {
                _EmpId = value;
                RaisePropertyChanged("EmpId");
            }
        }
        private DateTime? _last_call_date;
        public DateTime? last_call_date
        {
            get { return _last_call_date; }
            set
            {
                _last_call_date = value;
                RaisePropertyChanged("last_call_date");
            }
        }
        private decimal? _number_of_calls;
        public decimal? number_of_calls
        {
            get { return _number_of_calls; }
            set
            {
                _number_of_calls = value;
                RaisePropertyChanged("number_of_calls");
            }
        }
        private string _sel_set_usage_decision;
        public string sel_set_usage_decision
        {
            get { return _sel_set_usage_decision; }
            set
            {
                _sel_set_usage_decision = value;
                RaisePropertyChanged("sel_set_usage_decision");
            }
        }
        private DateTime? _usage_decision_date;
        public DateTime? usage_decision_date
        {
            get { return _usage_decision_date; }
            set
            {
                _usage_decision_date = value;
                RaisePropertyChanged("usage_decision_date");
            }
        }
        private string _sample_drawing_proc;
        public string sample_drawing_proc
        {
            get { return _sample_drawing_proc; }
            set
            {
                _sample_drawing_proc = value;
                RaisePropertyChanged("sample_drawing_proc");
            }
        }
        private string _insp_point;
        public string insp_point
        {
            get { return _insp_point; }
            set
            {
                _insp_point = value;
                RaisePropertyChanged("insp_point");
            }
        }
        private string _maint_strategy;
        public string maint_strategy
        {
            get { return _maint_strategy; }
            set
            {
                _maint_strategy = value;
                RaisePropertyChanged("maint_strategy");
            }
        }
        private string _maint_package_pool;
        public string maint_package_pool
        {
            get { return _maint_package_pool; }
            set
            {
                _maint_package_pool = value;
                RaisePropertyChanged("maint_package_pool");
            }
        }
        private string _maint_location_Id;
        public string maint_location_Id
        {
            get { return _maint_location_Id; }
            set
            {
                _maint_location_Id = value;
                RaisePropertyChanged("maint_location_Id");
            }
        }
        private string _sys_condition;
        public string sys_condition
        {
            get { return _sys_condition; }
            set
            {
                _sys_condition = value;
                RaisePropertyChanged("sys_condition");
            }
        }
        private string _lab_code;
        public string lab_code
        {
            get { return _lab_code; }
            set
            {
                _lab_code = value;
                RaisePropertyChanged("lab_code");
            }
        }
        private string _insp_lot_no;
        public string insp_lot_no
        {
            get { return _insp_lot_no; }
            set
            {
                _insp_lot_no = value;
                RaisePropertyChanged("insp_lot_no");
            }
        }
        private string _ind_deletion;
        public string ind_deletion
        {
            get { return _ind_deletion; }
            set
            {
                _ind_deletion = value;
                RaisePropertyChanged("ind_deletion");
            }
        }
        private string _obj_type;
        public string obj_type
        {
            get { return _obj_type; }
            set
            {
                _obj_type = value;
                RaisePropertyChanged("obj_type");
            }
        }
        private string _setup_recipe;
        public string setup_recipe
        {
            get { return _setup_recipe; }
            set
            {
                _setup_recipe = value;
                RaisePropertyChanged("setup_recipe");
            }
        }
        private string _clean_out_recipe;
        public string clean_out_recipe
        {
            get { return _clean_out_recipe; }
            set
            {
                _clean_out_recipe = value;
                RaisePropertyChanged("clean_out_recipe");
            }
        }
        private DateTime? _archieve_date;
        public DateTime? archieve_date
        {
            get { return _archieve_date; }
            set
            {
                _archieve_date = value;
                RaisePropertyChanged("archieve_date");
            }
        }
        private string _obj_id;
        public string obj_id
        {
            get { return _obj_id; }
            set
            {
                _obj_id = value;
                RaisePropertyChanged("obj_id");
            }
        }
        private string _ind_submission;
        public string ind_submission
        {
            get { return _ind_submission; }
            set
            {
                _ind_submission = value;
                RaisePropertyChanged("ind_submission");
            }
        }
        private int? _routing_no;
        public int? routing_no
        {
            get { return _routing_no; }
            set
            {
                _routing_no = value;
                RaisePropertyChanged("routing_no");
            }
        }
        private decimal? _base_qty;
        public decimal? base_qty
        {
            get { return _base_qty; }
            set
            {
                _base_qty = value;
                RaisePropertyChanged("base_qty");
            }
        }
        private bool? _active;
        public bool? active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
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

        private DateTime _add_date;
        public DateTime add_date
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
                _edit_by = value;
                RaisePropertyChanged("edit_by");
            }
        }

        private DateTime? _edit_date;
        public DateTime? edit_date
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

        public string XmlDataDocument_FlipGrid { get; set; }
    }

    public class MultipleContext_QMS_M024 
    {
        public List<QMS_M024Flip> DocumentDataFlipGrid { get; set; } //DataGridCollection        
        public List<QMS_M024> MasterEntity { get; set; }
        public List<COM_T003> Attachment { get; set; } // Attachment Collection
    }
}
