using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Admin
{
    public class ZADM_M027 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged("id");
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
        private string _language;
        public string language
        {
            get { return _language; }
            set
            {
                _language = value;
                RaisePropertyChanged("language");
            }
        }
        
        private decimal? _wire_size;
        public Nullable<decimal> wire_size
        {
            get { return _wire_size; }
            set
            {
                _wire_size = value;
                RaisePropertyChanged("wire_size");
            }
        }

        private string _wire_type;
        public string wire_type
        {
            get { return _wire_type; }
            set
            {
                _wire_type = value;
                RaisePropertyChanged("wire_type");
            }
        }
        private decimal? _ball_size;
        public decimal? ball_size
        {
            get { return _ball_size; }
            set
            {
                _ball_size = value;
                RaisePropertyChanged("ball_size");
            }
        }
        private string _ball_type;
        public string ball_type
        {
            get { return _ball_type; }
            set
            {
                _ball_type = value;
                RaisePropertyChanged("ball_type");
            }
        }
        private string _total_len;
        public string total_len
        {
            get { return _total_len; }
            set
            {
                _total_len = value;
                RaisePropertyChanged("total_len");
            }
        }
        private decimal? _gradeA_rate;
        public decimal? gradeA_rate
        {
            get { return _gradeA_rate; }
            set
            {
                _gradeA_rate = value;
                RaisePropertyChanged("gradeA_rate");
            }
        }
        private decimal? _ex_grA_rate;
        public decimal? ex_grA_rate
        {
            get { return _ex_grA_rate; }
            set
            {
                _ex_grA_rate = value;
                RaisePropertyChanged("ex_grA_rate");
            }
        }
        private decimal? _gradeB_rate;
        public decimal? gradeB_rate
        {
            get { return _gradeB_rate; }
            set
            {
                _gradeB_rate = value;
                RaisePropertyChanged("gradeB_rate");
            }
        }
        private decimal? _ex_grB_rate;
        public decimal? ex_grB_rate
        {
            get { return _ex_grB_rate; }
            set
            {
                _ex_grB_rate = value;
                RaisePropertyChanged("ex_grB_rate");
            }
        }
        private decimal? _gradeC_rate;
        public decimal? gradeC_rate
        {
            get { return _gradeC_rate; }
            set
            {
                _gradeC_rate = value;
                RaisePropertyChanged("gradeC_rate");
            }
        }
        private decimal? _ex_grC_rate;
        public decimal? ex_grC_rate
        {
            get { return _ex_grC_rate; }
            set
            {
                _ex_grC_rate = value;
                RaisePropertyChanged("ex_grC_rate");
            }
        }
        private string _rate_unit;
        public string rate_unit
        {
            get { return _rate_unit; }
            set
            {
                _rate_unit = value;
                RaisePropertyChanged("rate_unit");
            }
        }

        private string _month;
        public string month
        {
            get { return _month; }
            set
            {
                _month = value;
                RaisePropertyChanged("month");
            }
        }

        private string _year;
        public string year
        {
            get { return _year; }
            set
            {
                _year = value;
                RaisePropertyChanged("year");
            }
        }

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

        private string _editby;
        public string editby
        {
            get { return _editby; }
            set
            {
                _editby = value;
                RaisePropertyChanged("editby");
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

        
        private string _fin_year;
        public string fin_year
        {
            get { return _fin_year; }
            set
            {
                _fin_year = value;
                RaisePropertyChanged("fin_year");
            }
        }
        private string _posting_period;
        public string posting_period
        {
            get { return _posting_period; }
            set
            {
                _posting_period = value;
                RaisePropertyChanged("posting_period");
            }
        }

        private DateTime? _revised_date;
        public DateTime? revised_date
        {
            get { return _revised_date; }
            set
            {
                _revised_date = value;
                RaisePropertyChanged("revised_date");
            }
        }
        private int? _post_year;
        public int? post_year
        {
            get { return _post_year; }
            set
            {
                _post_year = value;
                RaisePropertyChanged("post_year");
            }
        }
        private int? _post_mon;
        public int? post_mon
        {
            get { return _post_mon; }
            set
            {
                _post_mon = value;
                RaisePropertyChanged("post_mon");
            }
        }

        //Scalar Fields
        private string _monthyear;
        public string monthyear
        {
            get { return _monthyear; }
            set
            {
                _monthyear = value;
                RaisePropertyChanged("monthyear");
            }
        }
        private int _calender_year;
        public int calender_year
        {
            get { return _calender_year; }
            set
            {
                _calender_year = value;
                RaisePropertyChanged("calender_year");
            }
        }
        private string _s_monthyear;
        public string s_monthyear
        {
            get { return _s_monthyear; }
            set
            {
                _s_monthyear = value;
                RaisePropertyChanged("s_monthyear");
            }
        }
        private string _s_month;
        public string s_month
        {
            get { return _s_month; }
            set
            {
                _s_month = value;
                RaisePropertyChanged("s_month");
            }
        }
        private string _s_year;
        public string s_year
        {
            get { return _s_year; }
            set
            {
                _s_year = value;
                RaisePropertyChanged("s_year");
            }
        }      
        private int _s_calenderyear;
        public int s_calenderyear
        {
            get { return _s_calenderyear; }
            set
            {
                _s_calenderyear = value;
                RaisePropertyChanged("s_calenderyear");
            }
        }
        private int _s_post_mon;
        public int s_post_mon
        {
            get { return _s_post_mon; }
            set
            {
                _s_post_mon = value;
                RaisePropertyChanged("s_post_mon");
            }
        }
        private int _s_post_year;
        public int s_post_year
        {
            get { return _s_post_year; }
            set
            {
                _s_post_year = value;
                RaisePropertyChanged("s_post_year");
            }
        }
        public string XmlDataDocument_ZADM_M027 { get; set; }
        public string XmlDataDocument_ZADM_M027_A { get; set; }
    }   
    public class ZADM_M027_A : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged("id");
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

        private string _ball_type;
        public string ball_type
        {
            get { return _ball_type; }
            set
            {
                _ball_type = value;
                RaisePropertyChanged("ball_type");
            }
        }

        private decimal? _dia_from;
        public Nullable<decimal> dia_from
        {
            get { return _dia_from; }
            set
            {
                _dia_from = value;
                RaisePropertyChanged("dia_from");
            }
        }

        private decimal? _dia_to;
        public decimal? dia_to
        {
            get { return _dia_to; }
            set
            {
                _dia_to = value;
                RaisePropertyChanged("dia_to");
            }
        }

        private decimal? _price;
        public decimal? price
        {
            get { return _price; }
            set
            {
                _price = value;
                RaisePropertyChanged("price");
            }
        }

        private string _month;
        public string month
        {
            get { return _month; }
            set
            {
                _month = value;
                RaisePropertyChanged("month");
            }
        }

        private string _year;
        public string year
        {
            get { return _year; }
            set
            {
                _year = value;
                RaisePropertyChanged("year");
            }
        }

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

        private string _editby;
        public string editby
        {
            get { return _editby; }
            set
            {
                _editby = value;
                RaisePropertyChanged("editby");
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

        

        private string _fin_year;
        public string fin_year
        {
            get { return _fin_year; }
            set
            {
                _fin_year = value;
                RaisePropertyChanged("fin_year");
            }
        }
        private string _posting_period;
        public string posting_period
        {
            get { return _posting_period; }
            set
            {
                _posting_period = value;
                RaisePropertyChanged("posting_period");
            }
        }

        private DateTime? _revised_date;
        public DateTime? revised_date
        {
            get { return _revised_date; }
            set
            {
                _revised_date = value;
                RaisePropertyChanged("revised_date");
            }
        }
        private int? _post_year;
        public int? post_year
        {
            get { return _post_year; }
            set
            {
                _post_year = value;
                RaisePropertyChanged("post_year");
            }
        }
        private int? _post_mon;
        public int? post_mon
        {
            get { return _post_mon; }
            set
            {
                _post_mon = value;
                RaisePropertyChanged("post_mon");
            }
        }
    }
    public class MultipleContext_ZADM_M027
    {
        public List<ZADM_M027Flip> DocumentDataFlipGrid { get; set; } //BF data
        public List<ZADM_M003_P> WireSizeList { get; set; } //wiresize popup
        public List<ZADM_M004_P> WireTypeList { get; set; } //wiretype popup
        public List<ZADM_M002_P> BallTypeList { get; set; } //Balltype popup
        public List<ZADM_M008_P> TotalLenList { get; set; } //TipLen popup
        public List<ADM_M038_B_P> UnitList { get; set; } //UOM popup
        public List<ACC_M001A_P> DateList { get; set; } // date popup
        public ObservableCollection<ZADM_M027_A> ItemEntity { get; set; } //Detail table
        public ObservableCollection<ZADM_M027> MasterEntity { get; set; } //Master table
    }
}
