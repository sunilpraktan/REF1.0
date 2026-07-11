using System;

namespace Reflection.BusinessEntity
{

    public class ACC_T006_C : ObjectBase
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
                    _id = value; RaisePropertyChanged("id", ModelEntityUpdated);
                }
            }
        }
        private Nullable<decimal> _tax_amount;
        public Nullable<decimal> tax_amount
        {
            get { return _tax_amount; }
            set
            {
                if (_tax_amount != value)
                {
                    _tax_amount = value; RaisePropertyChanged("tax_amount", ModelEntityUpdated);
                }
            }
        }
        private Nullable<int> _account_id;
        public Nullable<int> account_id
        {
            get { return _account_id; }
            set
            {
                if (_account_id != value)
                {
                    _account_id = value; RaisePropertyChanged("account_id", ModelEntityUpdated);
                }
            }
        }
        private Nullable<int> _sequence;
        public Nullable<int> sequence
        {
            get { return _sequence; }
            set
            {
                if (_sequence != value)
                {
                    _sequence = value; RaisePropertyChanged("sequence", ModelEntityUpdated);
                }
            }
        }
        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                if (_doc_no != value)
                {
                    _doc_no = value; RaisePropertyChanged("doc_no", ModelEntityUpdated);
                }
            }
        }
        private string _manual;
        public string manual
        {
            get { return _manual; }
            set
            {
                if (_manual != value)
                {
                    _manual = value; RaisePropertyChanged("manual", ModelEntityUpdated);
                }
            }
        }
        private Nullable<decimal> _base_amount;
        public Nullable<decimal> base_amount
        {
            get { return _base_amount; }
            set
            {
                if (_base_amount != value)
                {
                    _base_amount = value; RaisePropertyChanged("base_amount", ModelEntityUpdated);
                }
            }
        }
        private Nullable<decimal> _amount;
        public Nullable<decimal> amount
        {
            get { return _amount; }
            set
            {
                if (_amount != value)
                {
                    _amount = value; RaisePropertyChanged("amount", ModelEntityUpdated);
                }
            }
        }
        private Nullable<decimal> _base;
        public Nullable<decimal> @base
        {
            get { return _base; }
            set
            {
                if (_base != value)
                {
                    _base = value; RaisePropertyChanged("base", ModelEntityUpdated);
                }
            }
        }

        private Nullable<int> _tax_code_id;
        public Nullable<int> tax_code_id
        {
            get { return _tax_code_id; }
            set
            {
                if (_tax_code_id != value)
                {
                    _tax_code_id = value; RaisePropertyChanged("tax_code_id", ModelEntityUpdated);
                }
            }
        }
        private Nullable<int> _account_analytic_id;
        public Nullable<int> account_analytic_id
        {
            get { return _account_analytic_id; }
            set
            {
                if (_account_analytic_id != value)
                {
                    _account_analytic_id = value; RaisePropertyChanged("account_analytic_id", ModelEntityUpdated);
                }
            }
        }
        private Nullable<int> _base_code_id;
        public Nullable<int> base_code_id
        {
            get { return _base_code_id; }
            set
            {
                if (_base_code_id != value)
                {
                    _base_code_id = value; RaisePropertyChanged("base_code_id", ModelEntityUpdated);
                }
            }
        }
        private string _tax_name;
        public string tax_name
        {
            get { return _tax_name; }
            set
            {
                if (_tax_name != value)
                {
                    _tax_name = value; RaisePropertyChanged("tax_name", ModelEntityUpdated);
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
                    _gl_code = value; RaisePropertyChanged("gl_code", ModelEntityUpdated);
                }
            }
        }
        private string _ItemCode;
        public string ItemCode
        {
            get { return _ItemCode; }
            set
            {
                if (_ItemCode != value)
                {
                    _ItemCode = value; RaisePropertyChanged("ItemCode", ModelEntityUpdated);
                }
            }
        }
        private string _sku;
        public string sku
        {
            get { return _sku; }
            set
            {
                if (_sku != value)
                {
                    _sku = value; RaisePropertyChanged("sku", ModelEntityUpdated);
                }
            }
        }
        private Nullable<int> _item_row_id;
        public Nullable<int> item_row_id
        {
            get { return _item_row_id; }
            set
            {
                if (_item_row_id != value)
                {
                    _item_row_id = value; RaisePropertyChanged("item_row_id", ModelEntityUpdated);
                }
            }
        }
        private Nullable<int> _item_line_id;
        public Nullable<int> item_line_id
        {
            get { return _item_line_id; }
            set
            {
                if (_item_line_id != value)
                {
                    _item_line_id = value; RaisePropertyChanged("item_line_id", ModelEntityUpdated);
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
                    _fin_year = value; RaisePropertyChanged("fin_year", ModelEntityUpdated);
                }
            }
        }
        private string _posting_period;
        public string posting_period
        {
            get { return _posting_period; }
            set
            {
                if (_posting_period != value)
                {
                    _posting_period = value; RaisePropertyChanged("posting_period", ModelEntityUpdated);
                }
            }
        }
        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set
            {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active", ModelEntityUpdated);
                }
            }
        }
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                if (_location_Id != value)
                {
                    _location_Id = value; RaisePropertyChanged("location_Id", ModelEntityUpdated);
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
                    _comp_code = value; RaisePropertyChanged("comp_code", ModelEntityUpdated);
                }
            }
        }
        private string _dc_ind { get; set; }
        public string dc_ind
        {
            get { return _dc_ind; }
            set
            {
                if (_dc_ind != value)
                {
                    _dc_ind = value; RaisePropertyChanged("dc_ind");
                }
            }
        }
        private string _curr_code { get; set; }
        public string curr_code
        {
            get { return _curr_code; }
            set
            {
                if (_curr_code != value)
                {
                    _curr_code = value; RaisePropertyChanged("curr_code", ModelEntityUpdated);
                }
            }
        }
        private decimal? _exch_rate { get; set; }
        public decimal? exch_rate
        {
            get { return _exch_rate; }
            set
            {
                if (_exch_rate != value)
                {
                    _exch_rate = value; RaisePropertyChanged("exch_rate", ModelEntityUpdated);
                }
            }
        }
        private string _local_curr { get; set; }
        public string local_curr
        {
            get { return _local_curr; }
            set
            {
                if (_local_curr != value)
                {
                    _local_curr = value; RaisePropertyChanged("local_curr");
                }
            }
        }
        private Nullable<decimal> _amt_local_curr { get; set; }
        public Nullable<decimal> amt_local_curr
        {
            get { return _amt_local_curr; }
            set
            {
                if (_amt_local_curr != value)
                {
                    _amt_local_curr = value; RaisePropertyChanged("amt_local_curr");
                }
            }
        }
        private string _fix_per { get; set; }
        public string fix_per
        {
            get { return _fix_per; }
            set
            {
                if (_fix_per != value)
                {
                    _fix_per = value; RaisePropertyChanged("fix_per");
                }
            }
        }
       
        private string _symbol { get; set; }
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

        //Added by Priya
        private string _con_type { get; set; }
        public string con_type
        {
            get
            {
                return _con_type;
            }

            set
            {
                if (_con_type != value)
                {
                    _con_type = value; RaisePropertyChanged("con_type");
                }
            }
        }
        private string _con_cat { get; set; }
        public string con_cat
        {
            get
            {
                return _con_cat;
            }

            set
            {
                if (_con_cat != value)
                {
                    _con_cat = value; RaisePropertyChanged("con_cat");
                }
            }
        }
        private int _acc_seq { get; set; }
        public int acc_seq
        {
            get
            {
                return _acc_seq;
            }

            set
            {
                if (_acc_seq != value)
                {
                    _acc_seq = value; RaisePropertyChanged("acc_seq");
                }
            }
        }
        private string _trns_key_code { get; set; }
        public string trns_key_code
        {
            get
            {
                return _trns_key_code;
            }

            set
            {
                if (_trns_key_code != value)
                {
                    _trns_key_code = value; RaisePropertyChanged("trns_key_code");
                }
            }
        }
        private string _acc_key1 { get; set; }
        public string acc_key1
        {
            get
            {
                return _acc_key1;
            }

            set
            {
                if (_acc_key1 != value)
                {
                    _acc_key1 = value; RaisePropertyChanged("acc_key1");
                }
            }
        }
        private string _record_no { get; set; }
        public string record_no
        {
            get
            {
                return _record_no;
            }

            set
            {
                if (_record_no != value)
                {
                    _record_no = value; RaisePropertyChanged("record_no");
                }
            }
        }
        private decimal? _price_uom;
        public decimal? price_uom
        {
            get
            {
                return _price_uom;
            }

            set
            {
                if (_price_uom != value)
                {
                    _price_uom = value; RaisePropertyChanged("price_uom");
                }
            }
        }

        private string _doc_uom_con { get; set; }
        public string doc_uom_con
        {
            get
            {
                return _doc_uom_con;
            }

            set
            {
                if (_doc_uom_con != value)
                {
                    _doc_uom_con = value; RaisePropertyChanged("doc_uom_con");
                }
            }
        }

        private decimal? _no_base_uom;
        public decimal? no_base_uom
        {
            get
            {
                return _no_base_uom;
            }

            set
            {
                if (_no_base_uom != value)
                {
                    _no_base_uom = value; RaisePropertyChanged("no_base_uom");
                }
            }
        }

        private decimal? _dno_base_uom;
        public decimal? dno_base_uom
        {
            get
            {
                return _dno_base_uom;
            }

            set
            {
                if (_dno_base_uom != value)
                {
                    _dno_base_uom = value; RaisePropertyChanged("dno_base_uom");
                }
            }
        }
        private string _ind_con_acc { get; set; }
        public string ind_con_acc
        {
            get
            {
                return _ind_con_acc;
            }

            set
            {
                if (_ind_con_acc != value)
                {
                    _ind_con_acc = value; RaisePropertyChanged("ind_con_acc");
                }
            }
        }
        private string _vendor_code { get; set; }
        public string vendor_code
        {
            get
            {
                return _vendor_code;
            }

            set
            {
                if (_vendor_code != value)
                {
                    _vendor_code = value; RaisePropertyChanged("vendor_code");
                }
            }
        }
        private string _customera_code { get; set; }
        public string customera_code
        {
            get
            {
                return _customera_code;
            }

            set
            {
                if (_customera_code != value)
                {
                    _customera_code = value; RaisePropertyChanged("customera_code");
                }
            }
        }
        private decimal? _rnd_diff;
        public decimal? rnd_diff
        {
            get
            {
                return _rnd_diff;
            }

            set
            {
                if (_rnd_diff != value)
                {
                    _rnd_diff = value; RaisePropertyChanged("rnd_diff");
                }
            }
        }
        private decimal? _con_value;
        public decimal? con_value
        {
            get
            {
                return _con_value;
            }

            set
            {
                if (_con_value != value)
                {
                 _con_value = value; RaisePropertyChanged("con_value");
                }                
            }
        }
        private string _ind_max_base { get; set; }
        public string ind_max_base
        {
            get
            {
                return _ind_max_base;
            }

            set
            {
                if (_ind_max_base != value)
                {
                    _ind_max_base = value; RaisePropertyChanged("ind_max_base");
                }                
            }
        }
        private string _ind_max_amt { get; set; }
        public string ind_max_amt
        {
            get
            {
                return _ind_max_amt;
            }

            set
            {
                if (_ind_max_amt != value)
                {
                    _ind_max_amt = value; RaisePropertyChanged("ind_max_amt");
                }               
            }
        }
        private string _withholding_tax { get; set; }
        public string withholding_tax
        {
            get
            {
                return _withholding_tax;
            }

            set
            {
                if (_withholding_tax != value)
                {
                    _withholding_tax = value; RaisePropertyChanged("withholding_tax");
                }               
            }
        }

        //Added by Priya on 2/5/2017
        private int? _stepno;
        public int? stepno
        {
            get
            {
                return _stepno;
            }

            set
            {
                if (_stepno != value)
                {
                    _stepno = value; RaisePropertyChanged("stepno");
                }                
            }
        }
        private int? _scounter;
        public int? scounter
        {
            get
            {
                return _scounter;
            }

            set
            {
                if (_scounter != value)
                {
                    _scounter = value; RaisePropertyChanged("scounter");
                }               
            }
        }
        private string _trns_scope { get; set; }
        public string trns_scope
        {
            get
            {
                return _trns_scope;
            }

            set
            {
                if (_trns_scope != value)
                {
                    _trns_scope = value; RaisePropertyChanged("trns_scope");
                }                
            }
        }
        private Nullable<System.DateTime> _pricing_date { get; set; }
        public Nullable<System.DateTime> pricing_date
        {
            get
            {
                return _pricing_date;
            }

            set
            {
                if (_pricing_date != value)
                {
                    _pricing_date = value; RaisePropertyChanged("pricing_date");
                }                
            }
        }
        private string _calc_type { get; set; }
        public string calc_type
        {
            get
            {
                return _calc_type;
            }

            set
            {
                if (_calc_type != value)
                {
                    _calc_type = value; RaisePropertyChanged("calc_type");
                }               
            }
        }
        private decimal? _con_qty { get; set; }
        public decimal? con_qty
        {
            get
            {
                return _con_qty;
            }

            set
            {
                if (_con_qty != value)
                {
                    _con_qty = value; RaisePropertyChanged("con_qty");
                }               
            }
        }
        private string _ind_stats { get; set; }
        public string ind_stats
        {
            get
            {
                return _ind_stats;
            }

            set
            {
                if (_ind_stats != value)
                {
                    _ind_stats = value; RaisePropertyChanged("ind_stats");
                }                
            }
        }
        private string _scale_type { get; set; }
        public string scale_type
        {
            get
            {
                return _scale_type;
            }

            set
            {
                if (_scale_type != value)
                {
                    _scale_type = value; RaisePropertyChanged("scale_type");
                }
            }               
        }
        private decimal? _scale_qty { get; set; }
        public decimal? scale_qty
        {
            get
            {
                return _scale_qty;
            }

            set
            {
                if (_scale_qty != value)
                {
                    _scale_qty = value; RaisePropertyChanged("scale_qty");
                }                
            }
        }
        private string _ind_con_acr { get; set; }
        public string ind_con_acr
        {
            get
            {
                return _ind_con_acr;
            }

            set
            {
                if (_ind_con_acr != value)
                {
                    _ind_con_acr = value; RaisePropertyChanged("ind_con_acr");
                }               
            }
        }
        private string _PartyId { get; set; }
        public string PartyId
        {
            get
            {
                return _PartyId;
            }

            set
            {
                if (_PartyId != value)
                {
                    _PartyId = value; RaisePropertyChanged("PartyId");
                }                
            }
        }
        private string _tax_code { get; set; }
        public string tax_code
        {
            get
            {
                return _tax_code;
            }

            set
            {
                if (_tax_code != value)
                {
                    _tax_code = value; RaisePropertyChanged("tax_code");
                }              
            }
        }
        private string _origin_ind { get; set; }
        public string origin_ind
        {
            get
            {
                return _origin_ind;
            }

            set
            {
                if (_origin_ind != value)
                {
                    _origin_ind = value; RaisePropertyChanged("origin_ind");
                }               
            }
        }
        private string _con_control { get; set; }
        public string con_control
        {
            get
            {
                return _con_control;
            }

            set
            {
                if (_con_control != value)
                {
                    _con_control = value; RaisePropertyChanged("con_control");
                }                
            }
        }
        private string _round_method { get; set; }
        public string round_method
        {
            get
            {
                return _round_method;
            }

            set
            {
                if (_round_method != value)
                {
                    _round_method = value; RaisePropertyChanged("round_method");
                }               
            }
        }
        private string _grp_con { get; set; }
        public string grp_con
        {
            get
            {
                return _grp_con;
            }

            set
            {
                if (_grp_con != value)
                {
                    _grp_con = value; RaisePropertyChanged("grp_con");
                }                
            }
        }
        private string _is_qty { get; set; }
        public string is_qty
        {
            get
            {
                return _is_qty;
            }

            set
            {
                if (_is_qty != value)
                {
                    _is_qty = value; RaisePropertyChanged("is_qty");
                }               
            }
        }
        private string _con_record_no { get; set; }
        public string con_record_no
        {
            get
            {
                return _con_record_no;
            }

            set
            {
                if (_con_record_no != value)
                {
                    _con_record_no = value; RaisePropertyChanged("con_record_no");
                }               
            }
        }
        private int? _con_seq;
        public int? con_seq
        {
            get
            {
                return _con_seq;
            }

            set
            {
                if (_con_seq != value)
                {
                    _con_seq = value; RaisePropertyChanged("con_seq");
                }                
            }
        }
        private string _con_class { get; set; }
        public string con_class
        {
            get
            {
                return _con_class;
            }

            set
            {
                if (_con_class != value)
                {
                    _con_class = value; RaisePropertyChanged("con_class");
                }               
            }
        }
        private int? _cc_head;
        public int? cc_head
        {
            get
            {
                return _cc_head;
            }

            set
            {
                if (_cc_head != value)
                {
                    _cc_head = value; RaisePropertyChanged("cc_head");
                }                
            }
        }
        private decimal? _f_cbv { get; set; }
        public decimal? f_cbv
        {
            get
            {
                return _f_cbv;
            }

            set
            {
                if (_f_cbv != value)
                {
                    _f_cbv = value; RaisePropertyChanged("f_cbv");
                }               
            }
        }
        private decimal? _f_cbp { get; set; }
        public decimal? f_cbp
        {
            get
            {
                return _f_cbp;
            }

            set
            {
                if (_f_cbp != value)
                {
                    _f_cbp = value; RaisePropertyChanged("f_cbp");
                }                
            }
        }
        private string _ind_scale { get; set; }
        public string ind_scale
        {
            get
            {
                return _ind_scale;
            }

            set
            {
                if (_ind_scale != value)
                {
                    _ind_scale = value; RaisePropertyChanged("ind_scale");
                }
            }
        }
        private decimal? _scale_value { get; set; }
        public decimal? scale_value
        {
            get
            {
                return _scale_value;
            }

            set
            {
                if (_scale_value != value)
                {
                    _scale_value = value; RaisePropertyChanged("scale_value");
                }

            }
        }
        private string _scale_curr { get; set; }
        public string scale_curr
        {
            get
            {
                return _scale_curr;
            }

            set
            {
                if (_scale_curr != value)
                {
                    _scale_curr = value; RaisePropertyChanged("scale_curr");
                }

            }
        }
        private string _cost_center { get; set; }
        public string cost_center
        {
            get
            {
                return _cost_center;
            }

            set
            {
                if (_cost_center != value)
                {
                    _cost_center = value; RaisePropertyChanged("cost_center");
                }
            }
        }
        private string _profit_center { get; set; }
        public string profit_center
        {
            get
            {
                return _profit_center;
            }

            set
            {
                if (_profit_center != value)
                {
                    _profit_center = value; RaisePropertyChanged("profit_center");
                }
            }
        }
        private string _gross_indicator { get; set; }
        public string gross_indicator
        {
            get
            {
                return _gross_indicator;
            }

            set
            {
                if (_gross_indicator != value)
                {
                    _gross_indicator = value; RaisePropertyChanged("gross_indicator");
                }
            }
        }
        private string _analysis_code { get; set; }
        public string analysis_code
        {
            get
            {
                return _analysis_code;
            }

            set
            {
                if (_analysis_code != value)
                {
                    _analysis_code = value; RaisePropertyChanged("analysis_code");
                }
            }
        }
        private decimal? _rate_uom { get; set; }
        public decimal? rate_uom
        {
            get
            {
                return _rate_uom;
            }

            set
            {
                if (_rate_uom != value)
                {
                    _rate_uom = value; RaisePropertyChanged("rate_uom");
                }

            }

        }
        private string _pay_term { get; set; }
        public string pay_term
        {
            get
            {
                return _pay_term;
            }

            set
            {
                if (_pay_term != value)
                {
                    _pay_term = value; RaisePropertyChanged("pay_term");
                }
            }
        }
        private string _lic_type { get; set; }
        public string lic_type
        {
            get
            {
                return _lic_type;
            }

            set
            {
                if (_lic_type != value)
                {
                    _lic_type = value; RaisePropertyChanged("lic_type");
                }
            }
        }
        private string _lic_no { get; set; }
        public string lic_no
        {
            get
            {
                return _lic_no;
            }

            set
            {
                if (_lic_no != value)
                {
                    _lic_no = value; RaisePropertyChanged("lic_no");
                }
            }
        }
        private string _language;
        public string language
        {
            get { return _language; }
            set
            {
                if (_language != value)
                {
                    _language = value; RaisePropertyChanged("language");
                }
            }
        }
        
        private string _ind_computation { get; set; }
        public string ind_computation
        {
            get
            {
                return _ind_computation;
            }

            set
            {
                if (_ind_computation != value)
                {
                    _ind_computation = value; RaisePropertyChanged("ind_computation");
                }
            }
        }

        //Added By Karishma

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
        private string _PartyNm { get; set; }
        public string PartyNm
        {
            get
            {
                return _PartyNm;
            }

            set
            {
                if (_PartyNm != value)
                {
                    _PartyNm = value; RaisePropertyChanged("PartyNm");
                }
            }
        }
        // Scaller
        private string _req_no { get; set; }
        public string req_no
        {
            get
            {
                return _req_no;
            }

            set
            {
                if (_req_no != value)
                {
                    _req_no = value; RaisePropertyChanged("req_no");
                }

            }
        }
        private string _hsn_code { get; set; }
        public string hsn_code
        {
            get
            {
                return _hsn_code;
            }

            set
            {
                if (_hsn_code != value)
                {
                    _hsn_code = value; RaisePropertyChanged("hsn_code");
                }

            }
        }

        private string _price_qty_uom;
        public string price_qty_uom
        {
            get { return _price_qty_uom; }
            set
            {
                if (_price_qty_uom != value)
                {
                    _price_qty_uom = value; RaisePropertyChanged("price_qty_uom");
                }
            }
        }

        private decimal? _price_qty;
        public decimal? price_qty
        {
            get
            {
                return _price_qty;
            }

            set
            {
                if (_price_qty != value)
                {
                    _price_qty = value; RaisePropertyChanged("price_qty");
                }
            }
        }

        private decimal? _qty_price;
        public decimal? qty_price
        {
            get
            {
                return _qty_price;
            }

            set
            {
                if (_qty_price != value)
                {
                    _qty_price = value; RaisePropertyChanged("qty_price");
                }
            }
        }
    }
}
