using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessEntity
{
    public class ADM_M033 : INotifyPropertyChanged, IDataErrorInfo
    {
        private string _ColurCode;
        public string ColurCode
        {
            get { return _ColurCode; }
            set
            {
                _ColurCode = value;
                NotifyPropertyChanged("ColurCode");
            }
        }
        private string _ColurSrNo;
        public string ColurSrNo
        {
            get { return _ColurSrNo; }
            set
            {
                _ColurSrNo = value;
                NotifyPropertyChanged("ColurSrNo");
            }
        }
        private string _Colour;
        public string Colour
        {
            get { return _Colour; }
            set
            {
                _Colour = value;
                NotifyPropertyChanged("Colour");
            }
        }
        private string _LoctnCode;
        public string LoctnCode
        {
            get { return _LoctnCode; }
            set
            {
                _LoctnCode = value;
                NotifyPropertyChanged("LoctnCode");
            }
        }

        private Nullable<System.DateTime> _AddDate;
        public Nullable<System.DateTime> AddDate
        {
            get { return _AddDate; }
            set
            {
                _AddDate = value;
                NotifyPropertyChanged("AddDate");
            }
        }
        private string _EditBy;
        public string EditBy
        {
            get { return _EditBy; }
            set
            {
                _EditBy = value;
                NotifyPropertyChanged("EditBy");
            }
        }
        private Nullable<System.DateTime> _EditDate;
        public Nullable<System.DateTime> EditDate
        {
            get { return _EditDate; }
            set
            {
                _EditDate = value;
                NotifyPropertyChanged("EditDate");
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
