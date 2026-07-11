using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessEntity
{
    public class ADM_M006 : INotifyPropertyChanged, IDataErrorInfo
    {        
        private string _ModGrpCode;
        public string ModGrpCode
        {
            get { return _ModGrpCode; }
            set
            {
                if (_ModGrpCode != value)
                {
                    _ModGrpCode = value;
                    NotifyPropertyChanged("ModGrpCode");
                }
            }
        }
       //this.
        private string _ModGrpNm;
        public string ModGrpNm
        {
            get { return _ModGrpNm; }
            set
            {
                if (_ModGrpNm != value)
                {
                    _ModGrpNm = value;
                    NotifyPropertyChanged("ModGrpNm");
                }
            }
        }
        private Nullable<System.DateTime> _ImplimtDt;
        public Nullable<System.DateTime> ImplimtDt
        {
            get { return _ImplimtDt; }
            set
            {
                if (_ImplimtDt != value)
                {
                    _ImplimtDt = value;
                    NotifyPropertyChanged("ImplimtDt");
                }
            }
        }
        private string _Title;
        public string Title
        {
            get { return _Title; }
            set
            {
                if (_Title != value)
                {
                    _Title = value;
                    NotifyPropertyChanged("Title");
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
