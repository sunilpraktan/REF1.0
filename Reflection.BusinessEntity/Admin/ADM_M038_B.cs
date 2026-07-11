using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity
{
    public class ADM_M038_B : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int _id;
        public int id
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
        private int _class_id;
        public int class_id
        {
            get { return _class_id; }
            set
            {
                if (_class_id != value)
                {
                    _class_id = value;

                    RaisePropertyChanged("class_id");
                }
            }
        }
        private string _unit_abbrv;
        public string unit_abbrv
        {
            get { return _unit_abbrv; }
            set
            {
                if (_unit_abbrv != value)
                {
                    _unit_abbrv = value;

                    RaisePropertyChanged("unit_abbrv");
                }
            }
        }
        private string _unit_name;
        public string unit_name
        {
            get { return _unit_name; }
            set
            {
                if (_unit_name != value)
                {
                    _unit_name = value;

                    RaisePropertyChanged("unit_name", ModelEntityUpdated);
                }
            }
        }
        private string _unit_desc;
        public string unit_desc
        {
            get { return _unit_desc; }
            set
            {
                if (_unit_desc != value)
                {
                    _unit_desc = value;

                    RaisePropertyChanged("unit_desc");
                }
            }
        }
        private Nullable<bool> _is_base_unit;
        public Nullable<bool> is_base_unit
        {
            get { return _is_base_unit; }
            set
            {
                if (_is_base_unit != value)
                {
                    _is_base_unit = value;

                    RaisePropertyChanged("is_base_unit");
                }
            }
        }
        private Nullable<bool> _active;
        public Nullable<bool> active
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
        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set
            {
                if (_add_date != value)
                {
                    _add_date = value;

                    RaisePropertyChanged("add_date");
                }
            }
        }
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set
            {
                if (_add_by != value)
                {
                    _add_by = value;

                    RaisePropertyChanged("add_by");
                }
            }
        }
        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                if (_edit_date != value)
                {
                    _edit_date = value;

                    RaisePropertyChanged("edit_date");
                }
            }
        }

        private string _editby;
        public string editby
        {
            get { return _editby; }
            set
            {
                if (_editby != value)
                {
                    _editby = value;
                    RaisePropertyChanged("editby");
                }
            }

        }
        private string _class_name;
        public string class_name
        {
            get { return _class_name; }
            set
            {
                if (_class_name != value)
                {
                    _class_name = value;

                    RaisePropertyChanged("class_name", ModelEntityUpdated);
                }
            }
        }
        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set
            {
                if (_unit_code != value)
                {
                    _unit_code = value;

                    RaisePropertyChanged("unit_code", ModelEntityUpdated);
                }
            }
        }
        
        private string _unit_symbol;
        public string unit_symbol
        {
            get { return _unit_symbol; }
            set
            {
                if (_unit_symbol != value)
                {
                    _unit_symbol = value;
                    RaisePropertyChanged("unit_symbol");
                }
            }
        }
        
    }
    public class MultipleContext_ADM_M038_B
    {
        public List<ADM_M038_B> UOM_Master { get; set; }//UOM Master    
        public List<ADM_M038_A_P> Measur_Cls { get; set; }//Measurement Class       
    }
}
