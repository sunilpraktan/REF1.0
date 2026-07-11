using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Admin
{
    public class ACC_M007 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private string _pt_code;
        public string pt_code
        {
            get { return _pt_code; }
            set
            {
                if (_pt_code != value)
                {
                    _pt_code = value;
                    RaisePropertyChanged("pt_code");
                }
            }
        }


        private string _pt_name;
        public string pt_name
        {
            get { return _pt_name; }
            set
            {
                if (_pt_name != value)
                {
                    _pt_name = value;
                    RaisePropertyChanged("pt_name");
                }
            }
        }

        private string _short_text;
        public string short_text
        {
            get { return _short_text; }
            set
            {
                if (_short_text != value)
                {
                    _short_text = value;
                    RaisePropertyChanged("short_text");
                }
            }
        }
        private string _pay_method;
        public string pay_method
        {
            get { return _pay_method; }
            set
            {
                if (_pay_method != value)
                {
                    _pay_method = value;
                    RaisePropertyChanged("pay_method");
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

        private string _ind_default;
        public string ind_default
        {
            get { return _ind_default; }
            set
            {
                if (_ind_default != value)
                {
                    _ind_default = value;
                    RaisePropertyChanged("ind_default");
                }
            }
        }

        public string XDOC_A { get; set; }
    }
    public class ACC_M007_A :ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        public int id
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

        private string _pt_code;
        public string pt_code
        {
            get { return _pt_code; }
            set
            {
                if (_pt_code != value)
                {
                    _pt_code = value;
                    RaisePropertyChanged("pt_code");
                }
            }
        }

        private int _days;
        public int days
        {
            get { return _days; }
            set
            {
                if (_days != value)
                { 
                _days = value;
                RaisePropertyChanged("days");
            }
        }
        }

        private string _disc_type;
        public string disc_type
        {
            get { return _disc_type; }
            set
            {
                if (_disc_type != value)
                {
                    _disc_type = value;
                    RaisePropertyChanged("disc_type");
                }
            }
        }

        private decimal? _discount;
        public decimal? discount
        {
            get { return _discount; }
            set
            {
                if (_discount != value)
                {
                    _discount = value;
                    RaisePropertyChanged("discount");
                }
            }
        }

        private int? _fix_day;
        public int? fix_day
        {
            get { return _fix_day; }
            set
            {
                if (_fix_day != value)
                {
                    _fix_day = value;
                    RaisePropertyChanged("fix_day");
                }
            }
        }

        private int? _add_month;
        public int? add_month
        {
            get { return _add_month; }
            set
            {
                if (_add_month != value)
                {
                    _add_month = value;
                    RaisePropertyChanged("add_month");
                }
            }
        }

        private string _active;
        public string active
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
       
        private string _ind_delivery;
        public string ind_delivery
        {
            get { return _ind_delivery; }
            set
            {
                if (_ind_delivery != value)
                {
                    _ind_delivery = value;
                    RaisePropertyChanged("ind_delivery");
                }
            }
        }
        private string _ind_billing;
        public string ind_billing
        {
            get { return _ind_billing; }
            set
            {
                if (_ind_billing != value)
                {
                    _ind_billing = value;
                    RaisePropertyChanged("ind_billing");
                }
            }
        }
        private decimal? _pay_amount;
        public decimal? pay_amount
        {
            get { return _pay_amount; }
            set
            {
                if (_pay_amount != value)
                {
                    _pay_amount = value;
                    RaisePropertyChanged("pay_amount");
                }
            }
        }

    }

    public class MC_ACC_M007 : MC_FICO_BE
    {
        public List<ACC_M007> MasterList { get; set; }//Master list
        public ObservableCollection<ACC_M007_A> ItemsList { get; set; }  //Details Entity List            
    }

    //public class ACC_M007_Flip
    //{
    //    public string p_term_code { get; set; }
    //    public string p_term { get; set; }
    //    public string p_note { get; set; }
    //    public Nullable<bool> active { get; set; }
    //}
}
