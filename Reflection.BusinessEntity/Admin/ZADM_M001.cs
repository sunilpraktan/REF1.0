using System;
using System.ComponentModel;

namespace Reflection.BusinessEntity
{
    public class ZADM_M001 : ObjectBase, INotifyPropertyChanged, IDataErrorInfo
    {

       private int _BallDia_id;
        [DisplayName("ball_dia_id")]

       public int ball_dia_id
        {
            get { return _BallDia_id; }
            set
            {
                _BallDia_id = value;
                NotifyPropertyChanged("ball_dia_id");
            }
        }


        private decimal _Balldia;
        [DisplayName("ball_dia")]

        public decimal ball_dia
        {
            get { return _Balldia; }
            set
            {
                _Balldia = value;
                NotifyPropertyChanged("ball_dia");
            }
        }

        private string _UserId;
        [DisplayName("")]
        public string add_by
        {
            get { return _UserId; }
            set
            {
                _UserId = value;
                NotifyPropertyChanged("add_by");
            }
        }

        private Nullable<System.DateTime> _AddDt;
        [DisplayName("")]
        public Nullable<System.DateTime> add_date
        {
            get { return _AddDt; }
            set
            {
                _AddDt = value;
                NotifyPropertyChanged("add_date");
            }
        }


        private string _EditBy;
        [DisplayName("")]
        public string edit_by
        {
            get { return _EditBy; }
            set
            {
                _EditBy = value;
                NotifyPropertyChanged("edit_by");
            }
        }


        private Nullable<System.DateTime> _EditDt;
        [DisplayName("")]
        public Nullable<System.DateTime> edit_date
        {
            get { return _EditDt; }
            set
            {
                _EditDt = value;
                NotifyPropertyChanged("edit_date");
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
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
