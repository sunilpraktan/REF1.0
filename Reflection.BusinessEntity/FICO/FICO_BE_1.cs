using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessEntity.FICO
{
    public class STD_FICO_BE : STD_LIST_BE  //--- Standard Business Entity for FICO Module
    {
        public string con_type { get; set; }
        public string con_desc { get; set; }
        public string con_cat { get; set; }
        public string pricing_pro { get; set; }
        public string acc_key { get; set; }
        public string trns_key_code { get; set; }

        public string lic_cod { get; set; }
        public string lic_desc { get; set; }
        public string lic_type { get; set; }
        public DateTime? issue_date { get; set; }
        public DateTime? export_expiry_date { get; set; }
        public string file_no { get; set; }
        public string cc_code { get; set; }
        public string cc_name { get; set; }

        public string wtax_code { get; set; }
        public string wtax_ncode { get; set; }
        public decimal? wtax_rate { get; set; }
        public decimal? wtax_per { get; set; }
        public string wtax_type { get; set; }

    }
    public class FICO_M0019//---Cost Center
    {
        public string cc_code { get; set; }
        public string cc_name { get; set; }
    }
    public class FICO_M0020//---Profit Center
    {
        public string pc_code { get; set; }
        public string pc_name { get; set; }
    }
    public class FICO_M0004 : ObjectBase // Bank
    {
        private bool? _selected;
        public Nullable<bool> selected
        {
            get { return _selected; }
            set
            {
                if (_selected != value)
                {
                    _selected = value;
                    RaisePropertyChanged("selected");
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
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                if (_comp_code != value)
                {
                    _comp_code = value;

                    RaisePropertyChanged("comp_code");
                }
            }
        }
        private string _hb_code;
        public string hb_code
        {
            get { return _hb_code; }
            set
            {
                if (_hb_code != value)
                {
                    _hb_code = value;
                    RaisePropertyChanged("hb_code");
                }
            }
        }
        private string _hb_acc;
        public string hb_acc
        {
            get { return _hb_acc; }
            set
            {
                if (_hb_acc != value)
                {
                    _hb_acc = value;
                    RaisePropertyChanged("hb_acc");
                }
            }
        }
        private string _acc_no;
        public string acc_no
        {
            get { return _acc_no; }
            set
            {
                if (_acc_no != value)
                {
                    _acc_no = value;
                    RaisePropertyChanged("acc_no");
                }
            }
        }
        private string _acc_name;
        public string acc_name
        {
            get { return _acc_name; }
            set
            {
                if (_acc_name != value)
                {
                    _acc_name = value;
                    RaisePropertyChanged("acc_name");
                }
            }
        }
        private string _acc_type;
        public string acc_type
        {
            get { return _acc_type; }
            set
            {
                if (_acc_type != value)
                {
                    _acc_type = value;
                    RaisePropertyChanged("acc_type");
                }
            }
        }
        private string _curr_code;
        public string curr_code
        {
            get { return _curr_code; }
            set
            {
                if (_curr_code != value)
                {
                    _curr_code = value;
                    RaisePropertyChanged("curr_code");
                }
            }
        }
        private string _iban_no;
        public string iban_no
        {
            get { return _iban_no; }
            set
            {
                if (_iban_no != value)
                {
                    _iban_no = value;
                    RaisePropertyChanged("iban_no");
                }
            }
        }
        private bool? _active;
        public Nullable<bool> active
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
        private string _bank_code;
        public string bank_code
        {
            get { return _bank_code; }
            set
            {
                if (_bank_code != value)
                {
                    _bank_code = value;
                    RaisePropertyChanged("bank_code");
                }
            }
        }
        private string _bank_name;
        public string bank_name
        {
            get { return _bank_name; }
            set
            {
                if (_bank_name != value)
                {
                    _bank_name = value;
                    RaisePropertyChanged("bank_name");
                }
            }
        }
        private string _branch;
        public string branch
        {
            get { return _branch; }
            set
            {
                if (_branch != value)
                {
                    _branch = value;
                    RaisePropertyChanged("branch");
                }
            }
        }
        private string _ifsc_code;
        public string ifsc_code
        {
            get { return _ifsc_code; }
            set
            {
                if (_ifsc_code != value)
                {
                    _ifsc_code = value;
                    RaisePropertyChanged("ifsc_code");
                }
            }
        }
        private string _swift_code;
        public string swift_code
        {
            get { return _swift_code; }
            set
            {
                if (_swift_code != value)
                {
                    _swift_code = value;
                    RaisePropertyChanged("swift_code");
                }
            }
        }
        private string _ad_code;
        public string ad_code
        {
            get { return _ad_code; }
            set
            {
                if (_ad_code != value)
                {
                    _ad_code = value;
                    RaisePropertyChanged("ad_code");
                }
            }
        }
        private string _micr_code;
        public string micr_code
        {
            get { return _micr_code; }
            set
            {
                if (_micr_code != value)
                {
                    _micr_code = value;
                    RaisePropertyChanged("micr_code");
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
        private string _long_text;
        public string long_text
        {
            get { return _long_text; }
            set
            {
                if (_long_text != value)
                {
                    _long_text = value;
                    RaisePropertyChanged("long_text");
                }
            }
        }
        private string _abbr;
        public string abbr
        {
            get { return _abbr; }
            set
            {
                if (_abbr != value)
                {
                    _abbr = value;
                    RaisePropertyChanged("abbr");
                }
            }
        }
        private string _ctry_code;
        public string ctry_code
        {
            get { return _ctry_code; }
            set
            {
                if (_ctry_code != value)
                {
                    _ctry_code = value;

                    RaisePropertyChanged("ctry_code");
                }
            }
        }
        private string _ctry_name;
        public string ctry_name
        {
            get { return _ctry_name; }
            set
            {
                if (_ctry_name != value)
                {
                    _ctry_name = value;

                    RaisePropertyChanged("ctry_name");
                }
            }
        }
        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                if (_lang_key != value)
                {
                    _lang_key = value;

                    RaisePropertyChanged("lang_key");
                }
            }
        }
        private bool? _ind_default;
        public bool? ind_default
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
        private string _ind_trade;
        public string ind_trade
        {
            get { return _ind_trade; }
            set
            {
                if (_ind_trade != value)
                {
                    _ind_trade = value;

                    RaisePropertyChanged("ind_trade");
                }
            }
        }
        private string _recon_acc;
        public string recon_acc
        {
            get { return _recon_acc; }
            set
            {
                if (_recon_acc != value)
                {
                    _recon_acc = value;

                    RaisePropertyChanged("recon_acc");
                }
            }
        }
        private string _gl_code;
        public string gl_code
        {
            get { return _gl_code; }
            set
            {
                if (_gl_code != value)
                {
                    _gl_code = value;

                    RaisePropertyChanged("gl_code");
                }
            }
        }
        private string _gl_name;
        public string gl_name
        {
            get { return _gl_name; }
            set
            {
                if (_gl_name != value)
                {
                    _gl_name = value;

                    RaisePropertyChanged("gl_name");
                }
            }
        }
    }

    
    public class ACC_M0032 : ObjectBase  //--- Exchange Rate Related Entity
    {
        
        private int? _id;
        public int? id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value; RaisePropertyChanged("id");
                }
            }
        }
        private string _exch_rate_type;
        public string exch_rate_type
        {
            get { return _exch_rate_type; }
            set
            {
                if (_exch_rate_type != value)
                {
                    _exch_rate_type = value; RaisePropertyChanged("exch_rate_type");
                }
            }
        }
        private string _curr_code_from;
        public string curr_code_from
        {
            get { return _curr_code_from; }
            set
            {
                if (_curr_code_from != value)
                {
                    _curr_code_from = value; RaisePropertyChanged("curr_code_from");
                }
            }
        }
        private string _curr_code_to;
        public string curr_code_to
        {
            get { return _curr_code_to; }
            set
            {
                if (_curr_code_to != value)
                {
                    _curr_code_to = value; RaisePropertyChanged("curr_code_to");
                }
            }
        }
        private DateTime? _date_effective;
        public DateTime? date_effective
        {
            get { return _date_effective; }
            set
            {
                if (_date_effective != value)
                {
                    _date_effective = value; RaisePropertyChanged("date_effective");
                }
            }
        }
        private decimal? _exch_rate;
        public decimal? exch_rate
        {
            get { return _exch_rate; }
            set
            {
                if (_exch_rate != value)
                {
                    _exch_rate = value; RaisePropertyChanged("exch_rate");
                }
            }
        }
        private decimal? _exch_rate_direct;
        public decimal? exch_rate_direct
        {
            get { return _exch_rate_direct; }
            set
            {
                if (_exch_rate_direct != value)
                {
                    _exch_rate_direct = value; RaisePropertyChanged("exch_rate_direct");
                }
            }
        }
        private decimal? _ratio_from;
        public decimal? ratio_from
        {
            get { return _ratio_from; }
            set
            {
                if (_ratio_from != value)
                {
                    _ratio_from = value; RaisePropertyChanged("ratio_from");
                }
            }
        }
        private decimal? _ratio_to;
        public decimal? ratio_to
        {
            get { return _ratio_to; }
            set
            {
                if (_ratio_to != value)
                {
                    _ratio_to = value; RaisePropertyChanged("ratio_to");
                }
            }
        }
        private string _ind_cal;
        public string ind_cal
        {
            get { return _ind_cal; }
            set
            {
                if (_ind_cal != value)
                {
                    _ind_cal = value; RaisePropertyChanged("ind_cal");
                }
            }
        }
        private string _cur_code;
        public string cur_code
        {
            get { return _cur_code; }
            set
            {
                if (_cur_code != value)
                {
                    _cur_code = value; RaisePropertyChanged("cur_code");
                }
            }
        }
        private string _ind_from;
        public string ind_from
        {
            get { return _ind_from; }
            set
            {
                if (_ind_from != value)
                {
                    _ind_from = value; RaisePropertyChanged("ind_from");
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
                    _active = value; RaisePropertyChanged("active");
                }
            }
        }

        // Scalar
        private bool? _selected;
        public bool? selected
        {
            get { return _selected; }
            set
            {
                if (_selected != value)
                {
                    _selected = value; RaisePropertyChanged("selected");
                }
            }
        }
    }
    public class FICO_M0033 : ObjectBase // Currency Master
    {
        private int? _id;
        public int? id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value; RaisePropertyChanged("id");
                }
            }
        }
        private string _curr_code;
        public string curr_code
        {
            get { return _curr_code; }
            set
            {
                if (_curr_code != value)
                {
                    _curr_code = value; RaisePropertyChanged("curr_code");
                }
            }
        }
        private string _curr_name;
        public string curr_name
        {
            get { return _curr_name; }
            set
            {
                if (_curr_name != value)
                {
                    _curr_name = value; RaisePropertyChanged("curr_name");
                }
            }
        }
        private decimal? _rounding;
        public decimal? rounding
        {
            get { return _rounding; }
            set
            {
                if (_rounding != value)
                {
                    _rounding = value; RaisePropertyChanged("rounding");
                }
            }
        }
        private string _symbol;
        public string symbol
        {
            get { return _symbol; }
            set
            {
                if (_symbol != value)
                {
                    _symbol = value; RaisePropertyChanged("symbol");
                }
            }
        }
        private bool? _curr_base;
        public bool? curr_base
        {
            get { return _curr_base; }
            set
            {
                if (_curr_base != value)
                {
                    _curr_base = value; RaisePropertyChanged("curr_base");
                }
            }
        }
        private string _position;
        public string position
        {
            get { return _position; }
            set
            {
                if (_position != value)
                {
                    _position = value; RaisePropertyChanged("position");
                }
            }
        }
        private int? _accuracy;
        public int? accuracy
        {
            get { return _accuracy; }
            set
            {
                if (_accuracy != value)
                {
                    _accuracy = value; RaisePropertyChanged("accuracy");
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
                    _active = value; RaisePropertyChanged("active");
                }
            }
        }
        private int? _no_of_deci;
        public int? no_of_deci
        {
            get { return _no_of_deci; }
            set
            {
                if (_no_of_deci != value)
                {
                    _no_of_deci = value; RaisePropertyChanged("no_of_deci");
                }
            }
        }
        private string _monitory_unit;
        public string monitory_unit
        {
            get { return _monitory_unit; }
            set
            {
                if (_monitory_unit != value)
                {
                    _monitory_unit = value; RaisePropertyChanged("monitory_unit");
                }
            }
        }
        private string _monitory_unit_prefix;
        public string monitory_unit_prefix
        {
            get { return _monitory_unit_prefix; }
            set
            {
                if (_monitory_unit_prefix != value)
                {
                    _monitory_unit_prefix = value; RaisePropertyChanged("monitory_unit_prefix");
                }
            }
        }
        private string _tail_word;
        public string tail_word
        {
            get { return _tail_word; }
            set
            {
                if (_tail_word != value)
                {
                    _tail_word = value; RaisePropertyChanged("tail_word");
                }
            }
        }
        private decimal? _exch_rate;
        public decimal? exch_rate
        {
            get { return _exch_rate; }
            set
            {
                if (_exch_rate != value)
                {
                    _exch_rate = value; RaisePropertyChanged("exch_rate");
                }
            }
        }
        private decimal? _exch_rate_direct;
        public decimal? exch_rate_direct
        {
            get { return _exch_rate_direct; }
            set
            {
                if (_exch_rate_direct != value)
                {
                    _exch_rate_direct = value; RaisePropertyChanged("exch_rate_direct");
                }
            }
        }
        private DateTime? _date_effective;
        public DateTime? date_effective
        {
            get { return _date_effective; }
            set
            {
                if (_date_effective != value)
                {
                    _date_effective = value; RaisePropertyChanged("date_effective");
                }
            }
        }
        private string _curr_code_to;
        public string curr_code_to
        {
            get { return _curr_code_to; }
            set
            {
                if (_curr_code_to != value)
                {
                    _curr_code_to = value; RaisePropertyChanged("curr_code_to");
                }
            }
        }
        private string _word_format;
        public string word_format
        {
            get { return _word_format; }
            set
            {
                if (_word_format != value)
                {
                    _word_format = value; RaisePropertyChanged("word_format");
                }
            }
        }
        private string _word_prefix;
        public string word_prefix
        {
            get { return _word_prefix; }
            set
            {
                if (_word_prefix != value)
                {
                    _word_prefix = value; RaisePropertyChanged("word_prefix");
                }
            }
        }
        private string _word_suffix;
        public string word_suffix
        {
            get { return _word_suffix; }
            set
            {
                if (_word_suffix != value)
                {
                    _word_suffix = value; RaisePropertyChanged("word_suffix");
                }
            }
        }

        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set
            {
                if (_t_status != value)
                {
                    _t_status = value; RaisePropertyChanged("t_status");
                }
            }
        }
        private string _t_display;
        public string t_display
        {
            get { return _t_display; }
            set
            {
                if (_t_display != value)
                {
                    _t_display = value; RaisePropertyChanged("t_display");
                }
            }
        }
        private bool? _selected;
        public bool? selected
        {
            get { return _selected; }
            set
            {
                if (_selected != value)
                {
                    _selected = value; RaisePropertyChanged("selected");
                }
            }
        }

    }

    public class ACC_T021 : ObjectBase // Billing Plan Table
    {
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; }
        }

        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set { _doc_no = value; }
        }

        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set { _doc_cat = value; }
        }

        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set { _doc_type = value; }
        }

        private string _plan_cat;
        public string plan_cat
        {
            get { return _plan_cat; }
            set { _plan_cat = value; }
        }

        private string _short_text;
        public string short_text
        {
            get { return _short_text; }
            set { _short_text = value; }
        }

        private DateTime? _date_start;
        public DateTime? date_start
        {
            get { return _date_start; }
            set { _date_start = value; }
        }

        private DateTime? _date_end;
        public DateTime? date_end
        {
            get { return _date_end; }
            set { _date_end = value; }
        }

        private DateTime? _create_date;
        public DateTime? create_date
        {
            get { return _create_date; }
            set { _create_date = value; }
        }

        private string _ref_doc_cat;
        public string ref_doc_cat
        {
            get { return _ref_doc_cat; }
            set { _ref_doc_cat = value; }
        }

        private string _ref_doc_no;
        public string ref_doc_no
        {
            get { return _ref_doc_no; }
            set { _ref_doc_no = value; }
        }

        private decimal? _target_value;
        public decimal? target_value
        {
            get { return _target_value; }
            set { _target_value = value; }
        }

        private string _ind_advance;
        public string ind_advance
        {
            get { return _ind_advance; }
            set { _ind_advance = value; }
        }

        private string _pro_doc_no;
        public string pro_doc_no
        {
            get { return _pro_doc_no; }
            set { _pro_doc_no = value; }
        }

        private string _element_id;
        public string element_id
        {
            get { return _element_id; }
            set { _element_id = value; }
        }

        private string _active;
        public string active
        {
            get { return _active; }
            set { _active = value; }
        }

        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; }
        }

        private string _curr_code;
        public string curr_code
        {
            get { return _curr_code; }
            set { _curr_code = value; }
        }

        // Scalar
        private string _t_display;
        public string t_display
        {
            get { return _t_display; }
            set { _t_display = value; }
        }

    }


    public class MC_ACC_M0032 : MC_FICO_BE // Transaction specific MC Class
    {
        public ObservableCollection<ACC_M0032> MASTER_ENTITY_LIST { get; set; }
       
    }
    public class MC_FICO_M0004 : MC_FICO_BE // Transaction specific MC Class
    {
        public ObservableCollection<FICO_M0004> MASTER_ENTITY_LIST { get; set; }
        public ObservableCollection<FICO_M0004> ItemsEntity { get; set; }
    }

    public class ACC_T051 : ObjectBase // einvoice/eWay Bill acknoledgement Table
    {
        private int? _id;
        public int? id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }

        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set { _doc_no = value; RaisePropertyChanged("doc_no"); }
        }

        private string _ack_no;
        public string ack_no
        {
            get { return _ack_no; }
            set { _ack_no = value; RaisePropertyChanged("ack_no"); }
        }
        private string _irn_no;
        public string irn_no
        {
            get { return _irn_no; }
            set { _irn_no = value; RaisePropertyChanged("irn_no"); }
        }

        private DateTime? _irn_date;
        public DateTime? irn_date
        {
            get { return _irn_date; }
            set { _irn_date = value; RaisePropertyChanged("irn_date"); }
        }

        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set { _doc_cat = value; RaisePropertyChanged("doc_cat"); }
        }

        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set { _doc_type = value; RaisePropertyChanged("doc_type"); }
        }

        private string _cat_code;
        public string cat_code
        {
            get { return _cat_code; }
            set { _cat_code = value; RaisePropertyChanged("cat_code"); }
        }

        private string _qr_code;
        public string qr_code
        {
            get { return _qr_code; }
            set { _qr_code = value; RaisePropertyChanged("qr_code"); }
        }

        private string _active;
        public string active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }

        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }
        }

        // Scalar
        private string _t_display;
        public string t_display
        {
            get { return _t_display; }
            set { _t_display = value; RaisePropertyChanged("t_display"); }
        }

    }
}
