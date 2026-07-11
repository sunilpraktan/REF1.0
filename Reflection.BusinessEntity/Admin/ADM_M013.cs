using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity
{
    public class ADM_M013 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };


        private string _StatAbbre;
        public string StatAbbre
        {
            get { return _StatAbbre; }
            set
            {
                if (_StatAbbre != value)
                {
                    _StatAbbre = value;
                    RaisePropertyChanged("StatAbbre"); RaisePropertyChanged("StatAbbre", ModelEntityUpdated);
                }
            }
        }


        private string _state_code;
        public string state_code
        {
            get { return _state_code; }
            set
            {
                if (_state_code != value)
                {
                    _state_code = value;
                    RaisePropertyChanged("state_Code");
                }
            }
        }

        private string _StatName;
        public string StatName
        {
            get { return _StatName; }
            set
            {
                if (_StatName != value)
                {
                    _StatName = value;
                    RaisePropertyChanged("StatName"); RaisePropertyChanged("StatName", ModelEntityUpdated);
                }
            }
        }


        private string _country_code;
        public string country_code
        {
            get { return _country_code; }
            set
            {
                if (_country_code != value)
                {
                    _country_code = value;
                    RaisePropertyChanged("country_code");
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
                    RaisePropertyChanged("CntryName", ModelEntityUpdated);
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
                    RaisePropertyChanged("_add_by");
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
    public class MultipleContext_ADM_M013
    {
        public List<ADM_M013> State_1 { get; set; }   //State Master   
        public ObservableCollection<ADM_M012_P> Country_1 { get; set; }  //Country Master       
    }



}

