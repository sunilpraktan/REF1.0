using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessEntity
{
    public class STD_BE_A : ObjectBase //  Client Level. HSN Code Table.
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private string _group_code;
        public string group_code
        {
            get { return _group_code; }
            set
            {
                if (_group_code != value)
                {
                    _group_code = value;
                    RaisePropertyChanged("group_code");
                }
            }
        }
        private string _ctry_code;
        public string ctry_code
        {
            get { return _ctry_code; }
            set
            {
                if (_ctry_code != value)
                {
                    _ctry_code = value;
                    RaisePropertyChanged("ctry_code");
                }
            }
        }
        private string _hsn_code;
        public string hsn_code
        {
            get { return _hsn_code; }
            set
            {
                if (_hsn_code != value)
                {
                    _hsn_code = value;
                    RaisePropertyChanged("hsn_code");
                }
            }
        }
        private string _short_text;
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
        private string _group_cat;
        public string group_cat
        {
            get { return _group_cat; }
            set
            {
                if (_group_cat != value)
                {
                    _group_cat = value;
                    RaisePropertyChanged("group_cat");
                }
            }
        }
        private string _cat_name;
        public string cat_name
        {
            get { return _cat_name; }
            set
            {
                if (_cat_name != value)
                {
                    _cat_name = value;
                    RaisePropertyChanged("cat_name");
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
                    _group_name = value;
                    RaisePropertyChanged("group_name");
                }
            }
        }
        
        private string _active;
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
        private bool? _selected;
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

        private string _obj_type;
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
        private string _obj_name;
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
        private string _obj_group;
        public string obj_group
        {
            get { return _obj_group; }
            set
            {
                if (_obj_group != value)
                {
                    _obj_group = value;
                    RaisePropertyChanged("obj_group");
                }
            }
        }
        private string _equip_cat;
        public string equip_cat
        {
            get { return _equip_cat; }
            set
            {
                if (_equip_cat != value)
                {
                    _equip_cat = value;
                    RaisePropertyChanged("equip_cat");
                }
            }
        }
        private string _fun_loc;
        public string fun_loc
        {
            get { return _fun_loc; }
            set
            {
                if (_fun_loc != value)
                {
                    _fun_loc = value;
                    RaisePropertyChanged("fun_loc");
                }
            }
        }

    }
}
