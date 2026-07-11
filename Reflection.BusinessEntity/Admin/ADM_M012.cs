using System;

namespace Reflection.BusinessEntity
{
    public class ADM_M012 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private string _country_code;
        public string country_code
        {
            get { return _country_code; }
            set
            {
                if (_country_code != value)
                {
                    _country_code = value;
                    RaisePropertyChanged("country_code"); RaisePropertyChanged("country_code", ModelEntityUpdated);
                }
            }
        }


        private int _CntryCode;
        public int CntryCode
        {
            get { return _CntryCode; }

            set
            {
                if (_CntryCode != value)
                {
                    _CntryCode = value;
                    RaisePropertyChanged("CntryCode");
                }
            }
        }
        private string _CntryName;
        public string CntryName
        {
            get { return _CntryName; }
            set
            {
                if (_CntryName != value)
                {
                    _CntryName = value;
                    RaisePropertyChanged("CntryName"); RaisePropertyChanged("CntryName", ModelEntityUpdated);
                }
            }
        }
        private string _CntryAbbre;
        public string CntryAbbre
        {
            get { return _CntryAbbre; }
            set
            {
                if (_CntryAbbre != value)
                {
                    _CntryAbbre = value;
                    RaisePropertyChanged("CntryAbbre"); RaisePropertyChanged("CntryAbbre", ModelEntityUpdated);
                }
            }
        }

        private string _CntryCurncy;
        public string CntryCurncy
        {
            get { return _CntryCurncy; }
            set
            {
                if (_CntryCurncy != value)
                {
                    _CntryCurncy = value;
                    RaisePropertyChanged("CntryCurncy"); RaisePropertyChanged("CntryCurncy", ModelEntityUpdated);
                }
            }
        }
        private byte[] _CntryFlag;
        public byte[] CntryFlag
        {
            get { return _CntryFlag; }
            set
            {
                if (_CntryFlag != value)
                {
                    _CntryFlag = value;
                    RaisePropertyChanged("CntryFlag");
                }
            }
        }
        
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set
            {
                if (_add_by != value)
                {
                    _add_by = value;
                    RaisePropertyChanged("add_by");
                }
            }
        }
        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set
            {
                if (_add_date != value)
                {
                    _add_date = value;
                    RaisePropertyChanged("add_date");
                }
            }
        }
        private string _editby;
        public string editby
        {
            get { return _editby; }
            set
            {
                if (_editby != value)
                {
                    _editby = value;
                    RaisePropertyChanged("editby");
                }
            }
        }
        private Nullable<System.DateTime> _edit_date;

        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                if (_edit_date != value)
                {
                    _edit_date = value;
                    RaisePropertyChanged("edit_date");
                }
            }
        }


    }
}
