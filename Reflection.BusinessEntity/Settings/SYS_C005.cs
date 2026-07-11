using System;

namespace Reflection.BusinessEntity.Settings
{
    public class SYS_C005 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }

        private string _def_culture;
        public string def_culture
        {
            get { return _def_culture; }
            set
            {
                if (_def_culture != value)
                {
                    _def_culture = value;
                    RaisePropertyChanged("def_culture", ModelEntityUpdated);
                }
            }
        }

        private string _time_zone;
        public string time_zone
        {
            get { return _time_zone; }
            set { _time_zone = value; RaisePropertyChanged("time_zone"); }
        }

        private string _date_format;
        public string date_format
        {
            get { return _date_format; }
            set { _date_format = value; RaisePropertyChanged("date_format"); }
        }
        private string _date_separator;
        public string date_separator
        {
            get { return _date_separator; }
            set { _date_separator = value; RaisePropertyChanged("date_separator"); }
        }
        private int _decimal_digits;
        public int decimal_digits
        {
            get { return _decimal_digits; }
            set { _decimal_digits = value; RaisePropertyChanged("decimal_digits", ModelEntityUpdated); }
        }
        private string _round_up_method_code;
        public string round_up_method_code
        {
            get { return _round_up_method_code; }
            set { _round_up_method_code = value; RaisePropertyChanged("round_up_method_code"); }
        }
        private bool _value_suffix;
        public bool value_suffix
        {
            get { return _value_suffix; }
            set { _value_suffix = value; RaisePropertyChanged("value_suffix", ModelEntityUpdated); }
        }
        private string _theme_code;
        public string theme_code
        {
            get { return _theme_code; }
            set { _theme_code = value; RaisePropertyChanged("theme_code"); }
        }
        //private byte[] _desktop_file;
        //public byte[] desktop_file
        //{
        //    get { return _desktop_file; }
        //    set { _desktop_file = value; RaisePropertyChanged("desktop_file"); }
        //}
        private bool _round_up;
        public bool round_up
        {
            get { return _round_up; }
            set { _round_up = value; }
        }
        private bool _curr_notation;
        public bool curr_notation
        {
            get { return _curr_notation; }
            set { _curr_notation = value; RaisePropertyChanged("curr_notation", ModelEntityUpdated); }
        }
        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set { _doc_cat = value; RaisePropertyChanged("doc_cat"); }
        }
        private string _UserId;
        public string UserId
        {
            get { return _UserId; }
            set { _UserId = value; RaisePropertyChanged("UserId"); }
        }
        private string _field_name;
        public string field_name
        {
            get { return _field_name; }
            set { _field_name = value; RaisePropertyChanged("field_name"); }
        }
        private bool _active;
        public bool active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }
        //Scalar
        private string _date_sample;
        public string date_sample
        {
            get { return _date_sample; }
            set { _date_sample = value; RaisePropertyChanged("date_sample"); }
        }
        private string _def_culture_name;
        public string def_culture_name
        {
            get { return _def_culture_name; }
            set { _def_culture_name = value; RaisePropertyChanged("def_culture_name"); }
        }
        private string _decimal_format_code;
        public string decimal_format_code
        {
            get { return _decimal_format_code; }
            set { _decimal_format_code = value; RaisePropertyChanged("decimal_format_code"); }
        }
        private string _round_up_method_name;
        public string round_up_method_name
        {
            get { return _round_up_method_name; }
            set { _round_up_method_name = value; RaisePropertyChanged("round_up_method_name"); }
        }

        private string _sample_decimal_value;
        public string sample_decimal_value
        {
            get { return _sample_decimal_value; }
            set { _sample_decimal_value = value; RaisePropertyChanged("sample_decimal_value"); }
        }
        
        private string _sample_curr;
        public string sample_curr
        {
            get { return _sample_curr; }
            set { _sample_curr = value; RaisePropertyChanged("sample_curr"); }
        }
        private string _doc_desc;
        public string doc_desc
        {
            get { return _doc_desc; }
            set { _doc_desc = value; RaisePropertyChanged("doc_desc"); }
        }
        
    }
}
