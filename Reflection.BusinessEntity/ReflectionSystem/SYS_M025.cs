using Reflection.BusinessEntity.ADM;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.ReflectionSystem
{
    public class SYS_M025 : ObjectBase
    {
        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set
            {
                if (_doc_type != value)
                {
                    _doc_type = value; RaisePropertyChanged("doc_type");
                }
            }
        }
        private string _t_status;
      
        public string t_status
        {
            get { return _t_status; }
            set
            {
                if (_t_status != value)
                {
                    _t_status = value; RaisePropertyChanged("t_status");
                }
            }
        }
        private string _t_name;

        public string t_name
        {
            get { return _t_name; }
            set
            {
                if (_t_name != value)
                {
                    _t_name = value; RaisePropertyChanged("t_name");
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
                    _id = value; RaisePropertyChanged("id");
                }
            }

        }
        private int? _t_sequence;
        public int? t_sequence
        {
            get { return _t_sequence; }
            set
            {
                if (_t_sequence != value)
                {
                    _t_sequence = value; RaisePropertyChanged("t_sequence");
                }
            }

        }
        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set
            {
                if (_doc_cat != value)
                {
                    _doc_cat = value; RaisePropertyChanged("doc_cat");
                }
            }
        }
        private string _t_module;
        public string t_module
        {
            get { return _t_module; }
            set
            {
                if (_t_module != value)
                {
                    _t_module = value; RaisePropertyChanged("t_module");
                }
            }
        }
        private string _t_display;
        public string t_display
        {
            get { return _t_display; }
            set
            {
                if (_t_display != value)
                {
                    _t_display = value; RaisePropertyChanged("t_display");
                }
            }
        }
        private int? _t_weight;
        public int? t_weight
        {
            get { return _t_weight; }
            set
            {
                if (_t_weight != value)
                {
                    _t_weight = value; RaisePropertyChanged("t_weight");
                }
            }

        }
        private string _t_next;
        public string t_next
        {
            get { return _t_next; }
            set
            {
                if (_t_next != value)
                {
                    _t_next = value; RaisePropertyChanged("t_next");
                }
            }
        }
        private string _t_prev;
        public string t_prev
        {
            get { return _t_prev; }
            set
            {
                if (_t_prev != value)
                {
                    _t_prev = value; RaisePropertyChanged("t_prev");
                }
            }
        }
        private string _ind_closing;
        public string ind_closing
        {
            get { return _ind_closing; }
            set
            {
                if (_ind_closing != value)
                {
                    _ind_closing = value; RaisePropertyChanged("ind_closing");
                }
            }
        }
        private string _ind_custom;
        public string ind_custom
        {
            get { return _ind_custom; }
            set
            {
                if (_ind_custom != value)
                {
                    _ind_custom = value; RaisePropertyChanged("ind_custom");
                }
            }
        }
        private string _ind_manual;
        public string ind_manual
        {
            get { return _ind_manual; }
            set
            {
                if (_ind_manual != value)
                {
                    _ind_manual = value; RaisePropertyChanged("ind_manual");
                }
            }
        }
        private string _ind_doc_type;
        public string ind_doc_type
        {
            get { return _ind_doc_type; }
            set
            {
                if (_ind_doc_type != value)
                {
                    _ind_doc_type = value; RaisePropertyChanged("ind_doc_type");
                }
            }
        }
        private string _ind_change;
        public string ind_change
        {
            get { return _ind_change; }
            set
            {
                if (_ind_change != value)
                {
                    _ind_change = value; RaisePropertyChanged("ind_change");
                }
            }
        }
        private string _ind_cancel;
        public string ind_cancel
        {
            get { return _ind_cancel; }
            set
            {
                if (_ind_cancel != value)
                {
                    _ind_cancel = value; RaisePropertyChanged("ind_cancel");
                }
            }
        }
        private string _ind_modify;
        public string ind_modify
        {
            get { return _ind_modify; }
            set
            {
                if (_ind_modify != value)
                {
                    _ind_modify = value; RaisePropertyChanged("ind_modify");
                }
            }
        }
        private string _ind_valid;
        public string ind_valid
        {
            get { return _ind_valid; }
            set
            {
                if (_ind_valid != value)
                {
                    _ind_valid = value; RaisePropertyChanged("ind_valid");
                }
            }
        }
        private string _ind_active;
        public string ind_active
        {
            get { return _ind_active; }
            set
            {
                if (_ind_active != value)
                {
                    _ind_active = value; RaisePropertyChanged("ind_active");
                }
            }
        }
        private string _color_code;
        public string color_code
        {
            get { return _color_code; }
            set
            {
                if (_color_code != value)
                {
                    _color_code = value; RaisePropertyChanged("color_code");
                }
            }
        }
        
        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                if (_lang_key != value)
                {
                    _lang_key = value; RaisePropertyChanged("lang_key");
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
                    _active = value; RaisePropertyChanged("active");
                }
            }
        }
        //scalar
        private bool? _Click;
        public bool? Click
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
        private string _doc_desc_user;

        public string doc_desc_user
        {
            get { return _doc_desc_user; }
            set
            {
                if (_doc_desc_user != value)
                {
                    _doc_desc_user = value; RaisePropertyChanged("doc_desc_user");
                }
            }

        }

    }
    public class MultipleContext_SYS_M025
    {

        public ObservableCollection<SYS_M025> Statuslist { get; set; }
        public List<SYS_M002_P> Documentlist { get; set; }

        public List<ADM_M0013> Tlist { get; set; }


    }
}

