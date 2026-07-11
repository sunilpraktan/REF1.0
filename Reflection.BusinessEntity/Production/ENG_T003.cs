using System;

namespace Reflection.BusinessEntity.Production
{
    public class ENG_T003 : ObjectBase
    {
        private string _spec_para_code ;
        private string _spec_type_code ;
        private string _para_details ;
        private string _parameter ;
        private string _language ;
        private string _fin_year ;
        private string _posting_period ;
        private string _comp_code ;
        private string _location_Id ;
        private string _add_by ;
        private Nullable<DateTime> _add_date ;
        private string _editby ;
        private Nullable<DateTime> _edit_date ;
        private bool _active ;
        private string _t_status ;
        private string _type;

        public string spec_para_code
        {
            get
            {
                return _spec_para_code;
            }

            set
            {
                _spec_para_code = value;
                RaisePropertyChanged("spec_para_code");
            }
        }

        public string spec_type_code
        {
            get
            {
                return _spec_type_code;
            }

            set
            {
                _spec_type_code = value;
                RaisePropertyChanged("spec_type_code");
            }
        }

        public string para_details
        {
            get
            {
                return _para_details;
            }

            set
            {
                _para_details = value;
                RaisePropertyChanged("para_details");
            }
        }

        public string parameter
        {
            get
            {
                return _parameter;
            }

            set
            {
                _parameter = value;
                RaisePropertyChanged("parameter");
            }
        }

        public string language
        {
            get
            {
                return _language;
            }

            set
            {
                _language = value;
                RaisePropertyChanged("language");
            }
        }

        public string fin_year
        {
            get
            {
                return _fin_year;
            }

            set
            {
                _fin_year = value;
                RaisePropertyChanged("fin_year");
            }
        }

        public string posting_period
        {
            get
            {
                return _posting_period;
            }

            set
            {
                _posting_period = value;
                RaisePropertyChanged("posting_period");
            }
        }

        public string comp_code
        {
            get
            {
                return _comp_code;
            }

            set
            {
                _comp_code = value;
                RaisePropertyChanged("comp_code");
            }
        }

        public string location_Id
        {
            get
            {
                return _location_Id;
            }

            set
            {
                _location_Id = value;
                RaisePropertyChanged("location_Id");
            }
        }

        public string add_by
        {
            get
            {
                return _add_by;
            }

            set
            {
                _add_by = value;
                RaisePropertyChanged("add_by");
            }
        }

        public DateTime? add_date
        {
            get
            {
                return _add_date;
            }

            set
            {
                _add_date = value;
                RaisePropertyChanged("add_date");
            }
        }

        public string editby
        {
            get
            {
                return _editby;
            }

            set
            {
                _editby = value;
                RaisePropertyChanged("editby");
            }
        }

        public DateTime? edit_date
        {
            get
            {
                return _edit_date;
            }

            set
            {
                _edit_date = value;
                RaisePropertyChanged("edit_date");
            }
        }

        public bool active
        {
            get
            {
                return _active;
            }

            set
            {

                _active = value;
                RaisePropertyChanged("active");
            }
        }

        public string t_status
        {
            get
            {
                return _t_status;
            }

            set
            {
                _t_status = value;
                RaisePropertyChanged("t_status");
            }
        }


        public string type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
                RaisePropertyChanged("type");
            }
        }
    }
}
