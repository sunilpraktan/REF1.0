using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Reflection.BusinessEntity
{
    public class ADM_M005 : INotifyPropertyChanged, IDataErrorInfo
    {
        private int _AuthFldCod;  
        public int AuthFldCod
        {
            get { return _AuthFldCod; }
            set
            {
                if (_AuthFldCod != value)
                {
                    _AuthFldCod = value;
                    NotifyPropertyChanged("AuthFldCod");
                }
            }
        }
        private string _AuthFldNm;
        public string AuthFldNm
        {
            get { return _AuthFldNm; }
            set
            {
                if (_AuthFldNm != value)
                {
                    _AuthFldNm = value;
                    NotifyPropertyChanged("AuthFldNm");
                }
            }
        }
        private Nullable<System.DateTime> _AddDate;
        public Nullable<System.DateTime> AddDate
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
