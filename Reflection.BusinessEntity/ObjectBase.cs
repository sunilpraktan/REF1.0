using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Reflection.BusinessEntity
{
    public abstract class ObjectBase : IEditableObject, INotifyDataErrorInfo, INotifyPropertyChanged
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private string _ts_code;
        public string ts_code
        {
            get { return _ts_code; }
            set { _ts_code = value; RaisePropertyChanged("ts_code"); }
        }
        private string _ts_name;
        public string ts_name
        {
            get { return _ts_name; }
            set { _ts_name = value; RaisePropertyChanged("ts_name"); }
        }
        private string _client;
        public string client
        {
            get { return _client; }
            set
            {
                if (_client != value)
                {
                    _client = value; RaisePropertyChanged("client");
                }
            }
        }
        //private string _comp_code;
        //public string comp_code
        //{
        //    get { return _comp_code; }
        //    set
        //    {
        //        _comp_code = value;
        //        RaisePropertyChanged("comp_code");
        //    }
        //}
        //private string _location_Id;
        //public string location_Id
        //{
        //    get { return _location_Id; }
        //    set
        //    {
        //        _location_Id = value;
        //        RaisePropertyChanged("location_Id");
        //    }
        //}
        //private string _t_display;
        //public string t_display
        //{
        //    get { return _t_display; }
        //    set
        //    {
        //        if (_t_display != value)
        //        {
        //            _t_display = value; RaisePropertyChanged("t_display");
        //        }
        //    }
        //}
        private string _userid;
        public string userid
        {
            get { return _userid; }
            set
            {
                if (_userid != value)
                {
                    _userid = value; RaisePropertyChanged("userid");
                }
            }
        }
        private string _password;
        public string password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value; RaisePropertyChanged("password");
                }
            }
        }
        private string _username;
        public string username
        {
            get { return _username; }
            set
            {
                if (_username != value)
                {
                    _username = value; RaisePropertyChanged("username");
                }
            }
        }
        private string _user_source1;
        public string user_source1
        {
            get { return _user_source1; }
            set
            {
                _user_source1 = value;
                RaisePropertyChanged("user_source1");
            }
        }

        private string _user_source2;
        public string user_source2
        {
            get { return _user_source2; }
            set
            {
                _user_source2 = value;
                RaisePropertyChanged("user_source2");
            }
        }
        //private Nullable<bool> _active;
        //public Nullable<bool> active
        //{
        //    get { return _active; }
        //    set
        //    {
        //        _active = value;
        //        RaisePropertyChanged("active", ModelEntityUpdated);
        //    }
        //}
        //private string _t_status;
        //public string t_status
        //{
        //    get { return _t_status; }
        //    set
        //    {
        //        _t_status = value;
        //        RaisePropertyChanged("t_status");
        //    }
        //}
        private string _session_id;
        public string session_id
        {
            get { return _session_id; }
            set { _session_id = value; RaisePropertyChanged("session_id"); }
        }

        private string _color_code;
        public string color_code
        {
            get { return _color_code; }
            set { _color_code = value; RaisePropertyChanged("color_code"); }
        }
        private bool? _auto_roundup;
        public bool? auto_roundup
        {
            get { return _auto_roundup; }
            set
            {
                _auto_roundup = value;
                RaisePropertyChanged("auto_roundup", ModelEntityUpdated);
            }
        }
        private int? _roundup_digits;
        public int? roundup_digits
        {
            get { return _roundup_digits; }
            set
            {
                _roundup_digits = value;
                RaisePropertyChanged("roundup_digits", ModelEntityUpdated);
            }
        }
        private int? _t_date;
        public int? t_date
        {
            get { return _t_date; }
            set
            {
                if (_t_date != value)
                {
                    _t_date = value;
                    RaisePropertyChanged("t_date", ModelEntityUpdated);
                }
            }
        }
        private bool? _copy;
        public bool? copy
        {
            get { return _copy; }
            set
            {
                _copy = value;
                RaisePropertyChanged("copy");
            }
        }
        private string _ind_code;
        public string ind_code
        {
            get { return _ind_code; }
            set { _ind_code = value; RaisePropertyChanged("ind_code"); }
        }
        private string _ind_value;
        public string ind_value
        {
            get { return _ind_value; }
            set { _ind_value = value; RaisePropertyChanged("ind_value"); }
        }

        //private byte[] _qr_code;
        //public byte[] qr_code
        //{
        //    get { return _qr_code; }
        //    set
        //    {
        //        if (_qr_code != value)
        //        {
        //            _qr_code = value; RaisePropertyChanged("qr_code");
        //        }
        //    }
        //}
        //private byte[] _qr_image;
        //public byte[] qr_image
        //{
        //    get { return _qr_image; }
        //    set
        //    {
        //        if (_qr_image != value)
        //        {
        //            _qr_image = value; RaisePropertyChanged("qr_image");
        //        }
        //    }
        //}
        // Use this field to search reference record from popup with this key field to standardise pupup function.need to set value from SQL Query and then use this in LINQ query in VM Insert.... Function. REF Implementation : EPR_T001_VM_STD, CollectSelectedReferenceDocuments Function. Benifit: We can use different fields for common Selection Key value if Multiple UNION Queries exists just like example we will filter with record number values and after selection found using other fileds to set on Transaction BE.
        private string _search_key;
        public string search_key // Use this field to search reference record from popup with this key field to standardise pupup function.need to set value from SQL Query and then use this in LINQ query in VM Insert.... Function. REF Implementation : EPR_T001_VM_STD, CollectSelectedReferenceDocuments Function.
        {
            get { return _search_key; }
            set { _search_key = value; RaisePropertyChanged("search_key"); }
        }

        private string _search_key1;
        public string search_key1 // Use this additional key if multiple filters exists. 
        {
            get { return _search_key1; }
            set { _search_key1 = value; RaisePropertyChanged("search_key1"); }
        }

        private string _search_key2;// Use this additional key if multiple filters exists. 
        public string search_key2 // Use this additional key if multiple filters exists. 
        {
            get { return _search_key2; }
            set { _search_key2 = value; RaisePropertyChanged("search_key2"); }
        }


        private string _value_key;
        public string value_key
        {
            get { return _value_key; }
            set { _value_key = value; RaisePropertyChanged("value_key"); }
        }
        private string _value_code;
        public string value_code 
        {
            get { return _value_code; }
            set { _value_code = value; RaisePropertyChanged("value_code"); }
        }
        private string _value_name;
        public string value_name
        {
            get { return _value_name; }
            set { _value_name = value; RaisePropertyChanged("value_name"); }
        }

        private string _key_code;// common master code field, use this for master popup loading to avoide too much fields declaration.
        public string key_code
        {
            get { return _key_code; }
            set { _key_code = value; RaisePropertyChanged("key_code"); }
        }
        private string _key_name;
        public string key_name // common master code Description field, use this for master popup loading to avoide too much fields declaration.
        {
            get { return _key_name; }
            set { _key_name = value; RaisePropertyChanged("key_name"); }
        }
        private string _key_value;
        public string key_value
        {
            get { return _key_value; }
            set { _key_value = value; RaisePropertyChanged("key_value"); }
        }
        public override string ToString()
        {
            return string.Format("{0}", key_code);
        }

        Hashtable props = null;

        #region IEditableObject Members
        /// <summary>
        /// Set object in edit mode and save current values
        /// </summary>
        public void BeginEdit()
        {
            //exit if in Edit mode
            if (null != props) return;

            //enumerate properties
            PropertyInfo[] properties = (this.GetType()).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            props = new Hashtable(properties.Length - 1);

            for (int i = 0; i < properties.Length; i++)
            {
                //check if there is set accessor
                if (null != properties[i].GetSetMethod())
                {
                    object value = properties[i].GetValue(this, null);
                    props.Add(properties[i].Name, value);
                }
            }
        }

        /// <summary>
        /// Reject changes made to object since method BeginEdit() was called
        /// </summary>
        public void CancelEdit()
        {
            //check for unapporpriate call sequence
            if (null == props) return;

            //restore old values
            PropertyInfo[] properties = (this.GetType()).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            for (int i = 0; i < properties.Length; i++)
            {
                //check if there is set accessor
                if (null != properties[i].GetSetMethod())
                {
                    object value = props[properties[i].Name];
                    properties[i].SetValue(this, value, null);
                }
            }

            //delete current values            
            props = null;
        }

        /// <summary>
        /// Commit changes in object since method BeginEdit() was called
        /// </summary>
        public void EndEdit()
        {
            //delete current values            
            props = null;
        }

        #endregion

        #region INotifyDataErrorInfo & INotifyPropertyChanged Members
        private ConcurrentDictionary<string, List<string>> _errors = new ConcurrentDictionary<string, List<string>>();

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
            //ValidateAsync(); NOTE: Temparary Commented
            //bool msg = this.HasErrors; NOTE: Temparary Commented
        }
        public void RaisePropertyChanged(string propertyName, EventHandler ModelEntityUpdated)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
            //ValidateAsync(); NOTE: Temparary Commented
            //bool msg = this.HasErrors; NOTE: Temparary Commented
            ModelEntityUpdated(propertyName, EventArgs.Empty);
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public void OnErrorsChanged(string propertyName)
        {
            var handler = ErrorsChanged;
            if (handler != null)
                handler(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public IEnumerable GetErrors(string propertyName)
        {
            List<string> errorsForName = null;
            if (propertyName != null)
            {
                _errors.TryGetValue(propertyName, out errorsForName);
            }
            return errorsForName;

        }

        public bool HasErrors
        {
            get { return _errors.Any(kv => kv.Value != null && kv.Value.Count > 0); }
        }

        public Task ValidateAsync()
        {
            return Task.Run(() => Validate());
        }

        private object _lock = new object();
        public void Validate()
        {
            lock (_lock)
            {
                var validationContext = new ValidationContext(this, null, null);
                var validationResults = new List<ValidationResult>();
                Validator.TryValidateObject(this, validationContext, validationResults, true);

                foreach (var kv in _errors.ToList())
                {
                    //if (validationResults.All(r => r.MemberNames.All(m => m[0].ToString() != kv.Key)))
                    if (validationResults.All(r => r.MemberNames.All(m => m != kv.Key)))
                    {
                        List<string> outLi;
                        _errors.TryRemove(kv.Key, out outLi);
                        OnErrorsChanged(kv.Key);
                    }
                }

                var q = from r in validationResults
                        from m in r.MemberNames
                        group r by m into g
                        select g;

                foreach (var prop in q)
                {
                    var messages = prop.Select(r => r.ErrorMessage).ToList();

                    if (_errors.ContainsKey(prop.Key))
                    {
                        List<string> outLi;
                        _errors.TryRemove(prop.Key, out outLi);
                    }
                    _errors.TryAdd(prop.Key, messages);
                    OnErrorsChanged(prop.Key);
                }
            }
        }

        #endregion
    }
    //public abstract class ObjectBase : IEditableObject
    //{
    //    Hashtable props = null;

    //    #region IEditableObject Members
    //    /// <summary>
    //    /// Set object in edit mode and save current values
    //    /// </summary>
    //    public void BeginEdit()
    //    {
    //        //exit if in Edit mode
    //        if (null != props) return;

    //        //enumerate properties
    //        PropertyInfo[] properties = (this.GetType()).GetProperties(BindingFlags.Public | BindingFlags.Instance);

    //        props = new Hashtable(properties.Length - 1);

    //        for (int i = 0; i < properties.Length; i++)
    //        {
    //            //check if there is set accessor
    //            if (null != properties[i].GetSetMethod())
    //            {
    //                object value = properties[i].GetValue(this, null);
    //                props.Add(properties[i].Name, value);
    //            }
    //        }
    //    }

    //    /// <summary>
    //    /// Reject changes made to object since method BeginEdit() was called
    //    /// </summary>
    //    public void CancelEdit()
    //    {
    //        //check for unapporpriate call sequence
    //        if (null == props) return;

    //        //restore old values
    //        PropertyInfo[] properties = (this.GetType()).GetProperties(BindingFlags.Public | BindingFlags.Instance);
    //        for (int i = 0; i < properties.Length; i++)
    //        {
    //            //check if there is set accessor
    //            if (null != properties[i].GetSetMethod())
    //            {
    //                object value = props[properties[i].Name];
    //                properties[i].SetValue(this, value, null);
    //            }
    //        }

    //        //delete current values            
    //        props = null;
    //    }

    //    /// <summary>
    //    /// Commit changes in object since method BeginEdit() was called
    //    /// </summary>
    //    public void EndEdit()
    //    {
    //        //delete current values            
    //        props = null;
    //    }

    //    #endregion
    //}
}
