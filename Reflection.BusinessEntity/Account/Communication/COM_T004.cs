using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity.Communication
{
    public class COM_T004 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private string _sch_no;
        public string sch_no
        {
            get { return _sch_no; }
            set
            {
                if (_sch_no != value)
                {
                    _sch_no = value;
                    RaisePropertyChanged("sch_no");
                }
            }
        }

        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set
            {
                if (_doc_type != value)
                {
                    _doc_type = value;
                    RaisePropertyChanged("doc_type");
                }
            }
        }

        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set
            {
                if (_doc_cat != value)
                {
                    _doc_cat = value;
                    RaisePropertyChanged("doc_cat");
                }
            }
        }

        private string _schedule_type;
        public string schedule_type
        {
            get { return _schedule_type; }
            set
            {
                if (_schedule_type != value)
                {
                    _schedule_type = value;
                    RaisePropertyChanged("schedule_type");
                }
            }
        }

        private string _occurs;
        public string occurs
        {
            get { return _occurs; }
            set
            {
                if (_occurs != value)
                {
                    _occurs = value;
                    RaisePropertyChanged("occurs", ModelEntityUpdated);
                }
            }
        }

        private Nullable<int> _recurs_every;
        public Nullable<int> recurs_every
        {
            get { return _recurs_every; }
            set
            {
                if (_recurs_every != value)
                {
                    _recurs_every = value;
                    RaisePropertyChanged("recurs_every");
                }
            }
        }

        private string _occurs_once_tm;
        public string occurs_once_tm
        {
            get { return _occurs_once_tm; }
            set
            {
                if (_occurs_once_tm != value)
                {
                    _occurs_once_tm = value;
                    RaisePropertyChanged("occurs_once_tm");
                }
            }
        }

        private Nullable<int> _occurs_every_int;
        public Nullable<int> occurs_every_int
        {
            get { return _occurs_every_int; }
            set
            {
                if (_occurs_every_int != value)
                {
                    _occurs_every_int = value;
                    RaisePropertyChanged("occurs_every_int");
                }
            }
        }

        private string _start_tm;
        public string start_tm
        {
            get { return _start_tm; }
            set
            {
                if (_start_tm != value)
                {
                    _start_tm = value;
                    RaisePropertyChanged("start_tm");
                }
            }
        }

        private string _end_tm;
        public string end_tm
        {
            get { return _end_tm; }
            set
            {
                if (_end_tm != value)
                {
                    _end_tm = value;
                    RaisePropertyChanged("end_tm");
                }
            }                
        }

        private Nullable<System.DateTime> _start_date;
        public Nullable<System.DateTime> start_date
        {
            get { return _start_date; }
            set
            {
                if (_start_date != value)
                {
                    _start_date = value;
                    RaisePropertyChanged("start_date");
                }
            }              
        }

        private Nullable<System.DateTime> _end_date;
        public Nullable<System.DateTime> end_date
        {
            get { return _end_date; }
            set
            {
                if (_end_date != value)
                {
                    _end_date = value;
                    RaisePropertyChanged("end_date");
                }
            }
        }

        private Nullable<bool> _no_end_dt;
        public Nullable<bool> no_end_dt
        {
            get { return _no_end_dt; }
            set
            {
                if (_no_end_dt != value)
                {
                    _no_end_dt = value;
                    RaisePropertyChanged("no_end_dt");
                }
            }
        }

        private string _description;
        public string description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    RaisePropertyChanged("description");
                }
            }               
        }

        #region Default Fields
        private bool? _active;
        public bool? active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
            }
        }

        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set
            {
                _t_status = value;
                RaisePropertyChanged("t_status");
            }
        }


        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set
            {
                _add_by = value;
                RaisePropertyChanged("add_by");
            }
        }

        private DateTime _add_date;
        public DateTime add_date
        {
            get { return _add_date; }
            set
            {
                _add_date = value;
                RaisePropertyChanged("add_date");
            }
        }

        private string _edit_by;
        public string edit_by
        {
            get { return _edit_by; }
            set
            {
                _edit_by = value;
                RaisePropertyChanged("edit_by");
            }
        }


        private DateTime? _edit_date;
        public DateTime? edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value;
                RaisePropertyChanged("edit_date");
            }
        }
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                _location_Id = value;
                RaisePropertyChanged("location_Id");
            }
        }

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                _comp_code = value;
                RaisePropertyChanged("comp_code");
            }
        }

       

        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                _lang_key = value;
                RaisePropertyChanged("lang_key");
            }
        }

        #endregion

        private string _wk_day;
        public string wk_day
        {
            get { return _wk_day; }
            set
            {
                if (_wk_day != value)
                {
                    _wk_day = value;
                    RaisePropertyChanged("wk_day");
                }
            }               
        }

        private Nullable<int> _month_day;
        public Nullable<int> month_day
        {
            get { return _month_day; }
            set
            {
                if (_month_day != value)
                {
                    _month_day = value;
                    RaisePropertyChanged("month_day");
                }
            }               
        }

        private Nullable<int> _month;
        public Nullable<int> month
        {
            get { return _month; }
            set
            {
                if (_month != value)
                {
                    _month = value;
                    RaisePropertyChanged("month");
                }
            }               
        }

        private Nullable<bool> _day;
        public Nullable<bool> day
        {
            get { return _day; }
            set
            {
                if (_day != value)
                {
                    _day = value;
                    RaisePropertyChanged("day", ModelEntityUpdated);
                }
            }               
        }

        private Nullable<bool> _the;
        public Nullable<bool> the
        {
            get { return _the; }
            set
            {
                if (_the != value)
                {
                    _the = value;
                    RaisePropertyChanged("the");
                }
            }
        }

        private string _the_wk;
        public string the_wk
        {
            get { return _the_wk; }
            set
            {
                if (_the_wk != value)
                {
                    _the_wk = value;
                    RaisePropertyChanged("the_wk");
                }
            }
        }

        private string _the_day;
        public string the_day
        {
            get { return _the_day; }
            set
            {
                if (_the_day != value)
                {
                    _the_day = value;
                    RaisePropertyChanged("the_day");
                }
            }
        }

        private Nullable<bool> _occurs_once_at;
        public Nullable<bool> occurs_once_at
        {
            get { return _occurs_once_at; }
            set
            {
                if (_occurs_once_at != value)
                {
                    _occurs_once_at = value;
                    RaisePropertyChanged("occurs_once_at", ModelEntityUpdated);
                }
            }
        }

        private Nullable<bool> _occurs_every;
        public Nullable<bool> occurs_every
        {
            get { return _occurs_every; }
            set
            {
                if (_occurs_every != value)
                {
                    _occurs_every = value;
                    RaisePropertyChanged("occurs_every");
                }
            }
        }

        private string _occurs_every_var;
        public string occurs_every_var
        {
            get { return _occurs_every_var; }
            set
            {
                if (_occurs_every_var != value)
                {
                    _occurs_every_var = value;
                    RaisePropertyChanged("occurs_every_var");
                }
            }
        }

        private Nullable<bool> _end_dt;
        public Nullable<bool> end_dt
        {
            get { return _end_dt; }
            set
            {
                if (_end_dt != value)
                {
                    _end_dt = value;
                    RaisePropertyChanged("end_dt", ModelEntityUpdated);
                }
            }
        }

        //--------------USED FOR RADIO BUTTONS
        //private Nullable<bool> _ButtonDayIsChecked;
        //public Nullable<bool> ButtonDayIsChecked
        //{
        //    get { return _ButtonDayIsChecked; }
        //    set
        //    {
        //        _ButtonDayIsChecked = value;
        //        RaisePropertyChanged("ButtonDayIsChecked", ModelEntityUpdated);
        //    }
        //}

        //private Nullable<bool> _ButtonTheIsChecked;
        //public Nullable<bool> ButtonTheIsChecked
        //{
        //    get { return _ButtonTheIsChecked; }
        //    set
        //    {
        //        _ButtonTheIsChecked = value;
        //        RaisePropertyChanged("ButtonTheIsChecked");
        //    }
        //}

        //private Nullable<bool> _ButtonOccurrsOnceAtIsChecked;
        //public Nullable<bool> ButtonOccurrsOnceAtIsChecked
        //{
        //    get { return _ButtonOccurrsOnceAtIsChecked; }
        //    set
        //    {
        //        _ButtonOccurrsOnceAtIsChecked = value;
        //        RaisePropertyChanged("ButtonOccurrsOnceAtIsChecked");
        //    }
        //}

        //private Nullable<bool> _ButtonOccursEveryIsChecked;
        //public Nullable<bool> ButtonOccursEveryIsChecked
        //{
        //    get { return _ButtonOccursEveryIsChecked; }
        //    set
        //    {
        //        _ButtonOccursEveryIsChecked = value;
        //        RaisePropertyChanged("ButtonOccursEveryIsChecked");
        //    }
        //}

        //private Nullable<bool> _ButtonEndDtIsChecked;
        //public Nullable<bool> ButtonEndDtIsChecked
        //{
        //    get { return _ButtonEndDtIsChecked; }
        //    set
        //    {
        //        _ButtonEndDtIsChecked = value;
        //        RaisePropertyChanged("ButtonEndDtIsChecked");
        //    }
        //}

        //private Nullable<bool> _ButtonNoEndDtIsChecked;
        //public Nullable<bool> ButtonNoEndDtIsChecked
        //{
        //    get { return _ButtonNoEndDtIsChecked; }
        //    set
        //    {
        //        _ButtonNoEndDtIsChecked = value;
        //        RaisePropertyChanged("ButtonNoEndDtIsChecked");
        //    }
        //}
    }
    public class MultipleContext_COM_T004
    {
        public List<COM_T004> ScheduleEntity { get; set; }
    }
}
