namespace Reflection.BusinessEntity.ReflectionSystem
{
    public class SYS_M026 : ObjectBase
    {
        public string _tr_mode { get; set; }
        public string tr_mode
        {
            get { return _tr_mode; }
            set
            {
                if (_tr_mode != value)
                {
                    _tr_mode = value; RaisePropertyChanged("tr_mode");
                }
            }
        }
        public string _tr_name { get; set; }
        public string tr_name
        {
            get { return _tr_name; }
            set
            {
                if (_tr_name != value)
                {
                    _tr_name = value; RaisePropertyChanged("tr_name");
                }
            }
        }
        public string _tr_type { get; set; }
        public string tr_type
        {
            get { return _tr_type; }
            set
            {
                if (_tr_type != value)
                {
                    _tr_type = value; RaisePropertyChanged("tr_type");
                }
            }
        }
        public bool _active { get; set; }
        public bool active
        {
            get { return _active; }
            set
            {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active");
                }
            }
        }
       
    }

    public class SYS_M036 : ObjectBase
    {
        public string _sch_mode { get; set; }
        public string sch_mode
        {
            get { return _sch_mode; }
            set
            {
                if (_sch_mode != value)
                {
                    _sch_mode = value; RaisePropertyChanged("sch_mode");
                }
            }
        }
        public string _mode_name { get; set; }
        public string mode_name
        {
            get { return _mode_name; }
            set
            {
                if (_mode_name != value)
                {
                    _mode_name = value; RaisePropertyChanged("mode_name");
                }
            }
        }
        public string _active { get; set; }
        public string active
        {
            get { return _active; }
            set
            {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active");
                }
            }
        }
       
    }

    public class SYS_M037 : ObjectBase
    {
        private string _ind_trade;
        public string ind_trade
        {
            get { return _ind_trade; }
            set
            {
                if (_ind_trade != value)
                { _ind_trade = value; RaisePropertyChanged("ind_trade"); }
            }
        }
        public string _trade_name { get; set; }
        public string trade_name
        {
            get { return _trade_name; }
            set
            {
                if (_trade_name != value)
                {
                    _trade_name = value; RaisePropertyChanged("trade_name");
                }
            }
        }
        public string _trade_type { get; set; }
        public string trade_type
        {
            get { return _trade_type; }
            set
            {
                if (_trade_type != value)
                {
                    _trade_type = value; RaisePropertyChanged("trade_type");
                }
            }
        }
    }

    public class SYS_M038
    {
        public string usage_code { get; set; }
        public string usage_desc { get; set; }
    }
    public class SYS_M039
    {
        public string client { get; set; }
        public string ind_base { get; set; }
        public string base_desc { get; set; }
    }
    public class SYS_M040
    {
        public string client { get; set; }
        public string ind_usage { get; set; }
        public string usage_desc { get; set; }
    }
    public class SYS_M041
    {
        public string client { get; set; }
        public string item_cat_bom { get; set; }
        public string cat_desc { get; set; }
    }
    public class SYS_M042
    {
        public string bom_cat { get; set; }
        public string cat_name { get; set; }
    }
    public class SYS_M043
    {
        public string wc_cat { get; set; }
        public string wc_cat_desc { get; set; }
    }
    public class SYS_M044
    {
        public string order_type { get; set; }
        public string type_desc { get; set; }
    }
    public class SYS_M045
    {
        public string pro_type { get; set; }
        public string pro_desc { get; set; }
    }
    public class SYS_M046
    {
        public string spl_pro { get; set; }
        public string pro_desc { get; set; }
    }
    public class SYS_M047
    {
        public string order_cat { get; set; }
        public string cat_name { get; set; }
    }
    public class SYS_M048
    {
        public string task_list_use { get; set; }
        public string use_name { get; set; }
    }
    public class SYS_M049
    {
        public string task_list_type { get; set; }
        public string type_name { get; set; }
        public string task_app { get; set; }
    }
    public class SYS_M050
    {
        public string bom_cat { get; set; }
        public string cat_name { get; set; }
    }
    public class SYS_M051
    {
        public string control_key { get; set; }
        public string control_key_desc { get; set; }
        public string task_list_application { get; set; }
    }
    public class SYS_M052
    {
        public string record_type { get; set; }
        public string type_name { get; set; }
        public string record_cat { get; set; }
        public string ind_qty { get; set; }
    }
    public class SYS_M054
    {
        public string pack_type { get; set; }
        public string pack_desc { get; set; }
    }
    public class SYS_M055
    {
        public string rpt_code { get; set; }
        public string rpt_name { get; set; }
    }
    

}
