using System;
using System.ComponentModel;

namespace Reflection.BusinessEntity
{
    public class ZADM_M002 : ObjectBase, INotifyPropertyChanged, IDataErrorInfo
    {
        private int _BallType_id;
        [DisplayName("ball_type_id")]

        public int ball_type_id
        {
            get { return _BallType_id; }
            set
            {
                _BallType_id = value;
                NotifyPropertyChanged("ball_type_id");
            }
        }


        private string _Ball_type;
        [DisplayName("ball_type")]

        public string ball_type
        {
            get { return _Ball_type; }
            set
            {
                _Ball_type = value;
                NotifyPropertyChanged("ball_type");
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
