using System;

namespace Reflection.BusinessEntity.Finance
{
    public class ACC_M001 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private string _group_comp;
        public string group_comp
        {
            get { return _group_comp; }
            set
            {
                if (_group_comp != value)
                {
                    _group_comp = value;
                    RaisePropertyChanged("group_comp", ModelEntityUpdated);
                }
            }
        }
        private string _fin_year_var;
        public string fin_year_var
        {
            get { return _fin_year_var; }
            set
            {
                if (_fin_year_var != value)
                {
                    _fin_year_var = value;
                    RaisePropertyChanged("fin_year_var", ModelEntityUpdated);
                }
            }
        }
        private string _fin_year_desc;
        public string fin_year_desc
        {
            get { return _fin_year_desc; }
            set
            {
                if (_fin_year_desc != value)
                {
                    _fin_year_desc = value;
                    RaisePropertyChanged("fin_year_desc", ModelEntityUpdated);
                }
            }
        }
        private bool? _period_cal;
        public bool? period_cal
        {
            get { return _period_cal; }
            set
            {
                if (_period_cal != value)
                {
                    _period_cal = value;
                    RaisePropertyChanged("period_cal", ModelEntityUpdated);
                }
            }
        }
        private bool? _year_dep;
        public bool? year_dep
        {
            get { return _year_dep; }
            set
            {
                if (_year_dep != value)
                {
                    _year_dep = value;
                    RaisePropertyChanged("year_dep", ModelEntityUpdated);
                }
            }
        }
        private int? _num_per;
        public int? num_per
        {
            get { return _num_per; }
            set
            {
                if (_num_per != value)
                {
                    _num_per = value;
                    RaisePropertyChanged("num_per", ModelEntityUpdated);
                }
            }
        }
        private int? _num_spe;
        public int? num_spe
        {
            get { return _num_spe; }
            set
            {
                if (_num_spe != value)
                {
                    _num_spe = value;
                    RaisePropertyChanged("num_spe", ModelEntityUpdated);
                }
            }
        }
    }

    public class ACC_M001_A : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private string _posting_period;
        public string posting_period
        {
            get { return _posting_period; }
            set
            {
                if (_posting_period != value)
                {
                    _posting_period = value;
                    RaisePropertyChanged("posting_period", ModelEntityUpdated);
                }
            }
        }

        private string _fin_year;
        public string fin_year
        {
            get { return _fin_year; }
            set
            {
                if (_fin_year != value)
                {
                _fin_year = value;
                    RaisePropertyChanged("fin_year", ModelEntityUpdated);
                }
            }
        }
        private string _short_desc;
        public string short_desc
        {
            get { return _short_desc; }
            set
            {
                if (_short_desc != value)
                {
                    _short_desc = value;
                    RaisePropertyChanged("short_desc", ModelEntityUpdated);
                }
            }
        }
        private int? _post_year;
        public int? post_year
        {
            get { return _post_year; }
            set
            {
                if (_post_year != value)
                {
                    _post_year = value;
                    RaisePropertyChanged("post_year", ModelEntityUpdated);
                }
            }
        }
        private int? _calender_year;
        public int? calender_year
        {
            get { return _calender_year; }
            set
            {
                if (_calender_year != value)
                {
                    _calender_year = value;
                    RaisePropertyChanged("calender_year", ModelEntityUpdated);
                }
            }
        }
        private int? _post_per;
        public int? post_per
        {
            get { return _post_per; }
            set
            {
                if (_post_per != value)
                {
                    _post_per = value;
                    RaisePropertyChanged("post_per", ModelEntityUpdated);
                }
            }
        }
        private int? _post_mon;
        public int? post_mon
        {
            get { return _post_mon; }
            set
            {
                if (_post_mon != value)
                {
                    _post_mon = value;
                    RaisePropertyChanged("post_mon", ModelEntityUpdated);
                }
            }
        }
        private string _long_desc;
        public string long_desc
        {
            get { return _long_desc; }
            set
            {
                if (_long_desc != value)
                {
                    _long_desc = value;
                    RaisePropertyChanged("long_desc", ModelEntityUpdated);
                }
            }
        }
        private string _qtr;
        public string qtr
        {
            get { return _qtr; }
            set
            {
                if (_qtr != value)
                {
                    _qtr = value;
                    RaisePropertyChanged("qtr", ModelEntityUpdated);
                }
            }
        }

        private int? _id;
        public int? id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    RaisePropertyChanged("id");
                }
            }
        }
        private int? _group_comp;
        public int? group_comp
        {
            get { return _group_comp; }
            set
            {
                if (_group_comp != value)
                {
                    _group_comp = value;
                    RaisePropertyChanged("group_comp");
                }
            }
        }
        private string _fyear_var;
        public string fyear_var
        {
            get { return _fyear_var; }
            set
            {
                if (_fyear_var != value)
                {
                    _fyear_var = value;
                    RaisePropertyChanged("fyear_var");
                }
            }
        }
       
       
        
        private int? _cal_days;
        public int? cal_days
        {
            get { return _cal_days; }
            set
            {
                if (_cal_days != value)
                {
                    _cal_days = value;
                    RaisePropertyChanged("cal_days");
                }
            }
        }
        
        
        private string _shift_year;
        public string shift_year
        {
            get { return _shift_year; }
            set
            {
                if (_shift_year != value)
                {
                    _shift_year = value;
                    RaisePropertyChanged("shift_year");
                }
            }
        }
        
        
        private string _status;
        public string status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    RaisePropertyChanged("status");
                }
            }
        }
        private bool? _active;
        public bool? active
        {
            get { return _active; }
            set
            {
                if (_active != value)
                {
                    _active = value;
                    RaisePropertyChanged("active");
                }
            }
        }
        
        private DateTime? _add_date;
        public DateTime? add_date
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
        private DateTime? _edit_date;
        public DateTime? edit_date
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
       
    }
}
