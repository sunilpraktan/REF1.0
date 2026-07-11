using System;
using System.ComponentModel;

namespace Reflection.BusinessEntity
{
    public class ADM_M004 : ObjectBase, INotifyPropertyChanged, IDataErrorInfo
    {
        private int _ActivtCode { get; set; }
        public int ActivtCode
        {
            get { return _ActivtCode; }
            set
            {
                if (_ActivtCode != value)
                {
                    _ActivtCode = value;
                    NotifyPropertyChanged("ActivtCode");
                }
            }
        }
        private string _AddInfo { get; set; }
        public string AddInfo
        {
            get { return _AddInfo; }
            set
            {
                if (_AddInfo != value)
                {
                    _AddInfo = value;
                    NotifyPropertyChanged("AddInfo");
                }
            }
        }
        private string _ActivtNm { get; set; }
        //[DisplayName("Activity Name")]
        public string ActivtNm
        {
            get { return _ActivtNm; }
            set
            {
                if (_ActivtNm != value)
                {
                    _ActivtNm = value;
                    NotifyPropertyChanged("ActivtNm");
                }
            }
        }
        private string _UserId { get; set; }
        public string UserId
        {
            get { return _UserId; }
            set
            {
                if (_UserId != value)
                {
                    _UserId = value;
                    NotifyPropertyChanged("UserId");
                }
            }
        }
        private System.DateTime _AddDate { get; set; }
        public System.DateTime AddDate
        {
            get { return _AddDate; }
            set
            {
                if (_AddDate != value)
                {
                    _AddDate = value;
                    NotifyPropertyChanged("AddDate");
                }
            }
        }
        private string _EditBy;
        public string EditBy
        {
            get { return _EditBy; }
            set
            {
                if (_EditBy != value)
                {
                    _EditBy = value;
                    NotifyPropertyChanged("EditBy");
                }
            }
        }
        private Nullable<System.DateTime> _EditDate;
        public Nullable<System.DateTime> EditDate
        {
            get { return _EditDate; }
            set
            {
                if (_EditDate != value)
                {
                    _EditDate = value;
                    NotifyPropertyChanged("EditDate");
                }
            }
        }
        private string _activity_code;
        public string activity_code
        {
            get { return _activity_code; }
            set
            {
                if (_activity_code != value)
                {
                    _activity_code = value; NotifyPropertyChanged("activity_code");
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
                    _lang_key = value; NotifyPropertyChanged("lang_key");
                }
            }
        }


        string IDataErrorInfo.Error
        {
            get { throw new NotImplementedException(); }
        }

        string IDataErrorInfo.this[string columnName]
        {
            get { throw new NotImplementedException(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        //{
        //    add { throw new NotImplementedException(); }
        //    remove { throw new NotImplementedException(); }
        //}

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
