using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessEntity.QMS
{
   public class QMS_M0002:ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private string _insp_method;
        public string insp_method
        {
            get { return _insp_method; }
            set
            {
                _insp_method = value;
                RaisePropertyChanged("insp_method");
            }
        }
        private string _method_name;
        public string method_name
        {
            get { return _method_name; }
            set
            {
                _method_name = value;
                RaisePropertyChanged("method_name");
            }
        }

        private string _version_no;
        public string version_no
        {
            get { return _version_no; }
            set
            {
                _version_no = value;
                RaisePropertyChanged("version_no");
            }
        }

        private Nullable<System.DateTime> _valid_from;
        public Nullable<System.DateTime> valid_from
        {
            get { return _valid_from; }
            set
            {
                _valid_from = value;
                RaisePropertyChanged("valid_from");
            }
        }

        private string _qualification;
        public string qualification
        {
            get { return _qualification; }
            set
            {
                _qualification = value;
                RaisePropertyChanged("qualification");
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

        private string _method_code;
        public string method_code
        {
            get { return _method_code; }
            set
            {
                _method_code = value;
                RaisePropertyChanged("method_code");
            }
        }
        private string _clause;
        public string clause
        {
            get { return _clause; }
            set
            {
                _clause = value;
                RaisePropertyChanged("clause");
            }
        }
        private string _insp_type;
        public string insp_type
        {
            get { return _insp_type; }
            set
            {
                _insp_type = value;
                RaisePropertyChanged("insp_type");
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
        private bool? _selected { get; set; }
        public bool? selected
        {
            get { return _selected; }
            set
            {
                if (_selected != value)
                {
                    _selected = value; RaisePropertyChanged("selected");
                }
            }
        }



    }
    public class MC_QMS_M0002 : MC_QMS_BE
    {
        public ObservableCollection<QMS_M0002> MASTER_LIST { get; set; }
    }

}
