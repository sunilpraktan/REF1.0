using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessEntity.QMS
{
    public class QMS_M0003 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
       
        private string _fl_code;
        public string fl_code
        {
            get { return _fl_code; }
            set
            {
                if (_fl_code != value)
                {
                    _fl_code = value; RaisePropertyChanged("fl_code");
                }
            }
        }
        private string _fl_name;
        public string fl_name
        {
            get { return _fl_name; }
            set
            {
                if (_fl_name != value)
                {
                    _fl_name = value; RaisePropertyChanged("fl_name");
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
                    _short_text = value; RaisePropertyChanged("short_text");
                }
            }
        }
        private DateTime? _doe;
        public DateTime? doe
        {
            get { return _doe; }
            set
            {
                _doe = value;
                RaisePropertyChanged("doe", ModelEntityUpdated);
            }
        }
        private string _reg_no;
        public string reg_no
        {
            get { return _reg_no; }
            set
            {
                if (_reg_no != value)
                {
                    _reg_no = value; RaisePropertyChanged("reg_no");
                }
            }
        }
        private string _auth_name;
        public string auth_name
        {
            get { return _auth_name; }
            set
            {
                if (_auth_name != value)
                {
                    _auth_name = value; RaisePropertyChanged("auth_name");
                }
            }
        }
        private string _lab_name_lang1;
        public string lab_name_lang1
        {
            get { return _lab_name_lang1; }
            set
            {
                if (_lab_name_lang1 != value)
                {
                    _lab_name_lang1 = value; RaisePropertyChanged("lab_name_lang1");
                }
            }
        }
        private string _lab_name_lang2;
        public string lab_name_lang2
        {
            get { return _lab_name_lang2; }
            set
            {
                if (_lab_name_lang2 != value)
                {
                    _lab_name_lang2 = value; RaisePropertyChanged("lab_name_lang2");
                }
            }
        }
        private string _lab_name_lang3;
        public string lab_name_lang3
        {
            get { return _lab_name_lang3; }
            set
            {
                if (_lab_name_lang3 != value)
                {
                    _lab_name_lang3 = value; RaisePropertyChanged("lab_name_lang3");
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
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                if (_comp_code != value)
                {
                    _comp_code = value; RaisePropertyChanged("comp_code");
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
                    _location_id = value; RaisePropertyChanged("location_id");
                }
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
    }
    //public class MC_QMS_M0003 : MC_QMS_BE
    //{
    //    public ObservableCollection<QMS_M0003> MASTER_LIST { get; set; }
    //}
}
