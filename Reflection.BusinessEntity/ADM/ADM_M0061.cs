using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessEntity.ADM
{
    public class ADM_M0061 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                if (_comp_code != value)
                {
                    _comp_code = value;
                    RaisePropertyChanged("comp_code",ModelEntityUpdated);
                }
            }
        }
        private string _location_id;
        public string location_id
        {
            get { return _location_id; }
            set
            {
                if (_location_id != value)
                {
                    _location_id = value;
                    RaisePropertyChanged("location_id", ModelEntityUpdated);
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
                    _doc_no = value;
                    RaisePropertyChanged("doc_no");
                }
            }
        }
        private DateTime? _doc_date;
        public DateTime? doc_date
        {
            get { return _doc_date; }
            set
            {
                if (_doc_date != value)
                {
                    _doc_date = value;
                    RaisePropertyChanged("doc_date");
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
        private string _doc_title;
        public string doc_title
        {
            get { return _doc_title; }
            set
            {
                if (_doc_title != value)
                {
                    _doc_title = value;
                    RaisePropertyChanged("doc_title");
                }
            }
        }
        private string _obj_type;
        public string obj_type
        {
            get { return _obj_type; }
            set
            {
                if (_obj_type != value)
                {
                    _obj_type = value;
                    RaisePropertyChanged("obj_type");
                }
            }
        }
        private string _party_code;
        public string party_code
        {
            get { return _party_code; }
            set
            {
                if (_party_code != value)
                {
                    _party_code = value;
                    RaisePropertyChanged("party_code");
                }
            }
        }
        private DateTime? _price_date;
        public DateTime? price_date
        {
            get { return _price_date; }
            set
            {
                if (_price_date != value)
                {
                    _price_date = value;
                    RaisePropertyChanged("price_date");
                }
            }
        }
        private DateTime? _validity_date;
        public DateTime? validity_date
        {
            get { return _validity_date; }
            set
            {
                if (_validity_date != value)
                {
                    _validity_date = value;
                    RaisePropertyChanged("validity_date");
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
                    _t_status = value;
                    RaisePropertyChanged("t_status");
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
        private string _org_code;
        public string org_code
        {
            get { return _org_code; }
            set
            {
                if (_org_code != value)
                {
                    _org_code = value;
                    RaisePropertyChanged("org_code", ModelEntityUpdated);
                }
            }
        }
        private string _group_code;
        public string group_code
        {
            get { return _group_code; }
            set
            {
                if (_group_code != value)
                {
                    _group_code = value;
                    RaisePropertyChanged("group_code", ModelEntityUpdated);
                }
            }
        }
        private string _div_code;
        public string div_code
        {
            get { return _div_code; }
            set
            {
                if (_div_code != value)
                {
                    _div_code = value;
                    RaisePropertyChanged("div_code");
                }
            }
        }
        private string _ref_doc_no;
        public string ref_doc_no
        {
            get { return _ref_doc_no; }
            set
            {
                if (_ref_doc_no != value)
                {
                    _ref_doc_no = value;
                    RaisePropertyChanged("ref_doc_no");
                }
            }
        }
        private string _ref_doc_cat;
        public string ref_doc_cat
        {
            get { return _ref_doc_cat; }
            set
            {
                if (_ref_doc_cat != value)
                {
                    _ref_doc_cat = value;
                    RaisePropertyChanged("ref_doc_cat");
                }
            }
        }
        private string _notes;
        public string notes
        {
            get { return _notes; }
            set
            {
                if (_notes != value)
                {
                    _notes = value;
                    RaisePropertyChanged("notes");
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

        //Scallar
        private string _t_display;

        public string t_display
        {
            get { return _t_display; }
            set
            {
                if (_t_display != value)
                {
                    _t_display = value;
                    RaisePropertyChanged("t_display");
                }
            }
        }
        private string _party_name;
        public string party_name
        {
            get { return _party_name; }
            set
            {
                if (_party_name != value)
                {
                    _party_name = value;
                    RaisePropertyChanged("party_name");
                }
            }
        }
        private string _org_name;
        public string org_name
        {
            get { return _org_name; }
            set
            {
                if (_org_name != value)
                {
                    _org_name = value;
                    RaisePropertyChanged("org_name");
                }
            }
        }
        private string _group_name;
        public string group_name
        {
            get { return _group_name; }
            set
            {
                if (_group_name != value)
                {
                    _group_name = value;
                    RaisePropertyChanged("group_name");
                }
            }
        }
        public string XDOC_A { get; set; }
    }

    public class ADM_M0061_A : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
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
                    RaisePropertyChanged("comp_code", ModelEntityUpdated);
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
                    _doc_no = value;
                    RaisePropertyChanged("doc_no");
                }
            }
        }
        private string _item_code;
        public string item_code
        {
            get { return _item_code; }
            set
            {
                if (_item_code != value)
                {
                    _item_code = value;
                    RaisePropertyChanged("item_code");
                }
            }
        }
        
        private string _item_name;
        public string item_name
        {
            get { return _item_name; }
            set
            {
                if (_item_name != value)
                {
                    _item_name = value;
                    RaisePropertyChanged("item_name");
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
        private string _item_code_party;
        public string item_code_party
        {
            get { return _item_code_party; }
            set
            {
                if (_item_code_party != value)
                {
                    _item_code_party = value;
                    RaisePropertyChanged("item_code_party");
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
                    _sku = value;
                    RaisePropertyChanged("sku");
                }
            }
        }
        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set
            {
                if (_unit_code != value)
                {
                    _unit_code = value;
                    RaisePropertyChanged("unit_code");
                }
            }
        }
        private int? _lead_time;
        public int? lead_time
        {
            get { return _lead_time; }
            set
            {
                if (_lead_time != value)
                {
                    _lead_time = value;
                    RaisePropertyChanged("lead_time");
                }
            }
        }
        private decimal? _min_order_qty;
        public decimal? min_order_qty
        {
            get { return _min_order_qty; }
            set
            {
                if (_min_order_qty != value)
                {
                    _min_order_qty = value;
                    RaisePropertyChanged("min_order_qty");
                }
            }
        }
        private decimal? _max_order_qty;
        public decimal? max_order_qty
        {
            get { return _max_order_qty; }
            set
            {
                if (_max_order_qty != value)
                {
                    _max_order_qty = value;
                    RaisePropertyChanged("max_order_qty");
                }
            }
        }
        private decimal? _min_order_value;
        public decimal? min_order_value
        {
            get { return _min_order_value; }
            set
            {
                if (_min_order_value != value)
                {
                    _min_order_value = value;
                    RaisePropertyChanged("min_order_value");
                }
            }
        }
        private decimal? _max_order_value;
        public decimal? max_order_value
        {
            get { return _max_order_value; }
            set
            {
                if (_max_order_value != value)
                {
                    _max_order_value = value;
                    RaisePropertyChanged("max_order_value");
                }
            }
        }
        private string _uom_qty;
        public string uom_qty
        {
            get { return _uom_qty; }
            set
            {
                if (_uom_qty != value)
                {
                    _uom_qty = value;
                    RaisePropertyChanged("uom_qty");
                }
            }
        }
        private string _uom_value;
        public string uom_value
        {
            get { return _uom_value; }
            set
            {
                if (_uom_value != value)
                {
                    _uom_value = value;
                    RaisePropertyChanged("uom_value");
                }
            }
        }
        private string _uom_price;
        public string uom_price
        {
            get { return _uom_price; }
            set
            {
                if (_uom_price != value)
                {
                    _uom_price = value;
                    RaisePropertyChanged("uom_price");
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
        private decimal? _unit_price;
        public decimal? unit_price
        {
            get { return _unit_price; }
            set
            {
                if (_unit_price != value)
                {
                    _unit_price = value;
                    RaisePropertyChanged("unit_price");
                }
            }
        }
        private decimal? _max_price;
        public decimal? max_price
        {
            get { return _max_price; }
            set
            {
                if (_max_price != value)
                {
                    _max_price = value;
                    RaisePropertyChanged("max_price");
                }
            }
        }
        private decimal? _base_price;
        public decimal? base_price
        {
            get { return _base_price; }
            set
            {
                if (_base_price != value)
                {
                    _base_price = value;
                    RaisePropertyChanged("base_price", ModelEntityUpdated);
                }
            }
        }
        private decimal? _min_price;
        public decimal? min_price
        {
            get { return _min_price; }
            set
            {
                if (_min_price != value)
                {
                    _min_price = value;
                    RaisePropertyChanged("min_price");
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
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set
            {
                if (_t_status != value)
                {
                    _t_status = value;
                    RaisePropertyChanged("t_status");
                }
            }
        }
        private string _tax_code;
        public string tax_code
        {
            get { return _tax_code; }
            set
            {
                if (_tax_code != value)
                {
                    _tax_code = value;
                    RaisePropertyChanged("tax_code");
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
        private string _note;
        public string note
        {
            get { return _note; }
            set
            {
                if (_note != value)
                {
                    _note = value;
                    RaisePropertyChanged("note");
                }
            }
        }
        private string _ind_revision;
        public string ind_revision
        {
            get { return _ind_revision; }
            set
            {
                if (_ind_revision != value)
                {
                    _ind_revision = value;
                    RaisePropertyChanged("ind_revision");
                }
            }
        }
        private DateTime? _price_date;
        public DateTime? price_date
        {
            get { return _price_date; }
            set
            {
                if (_price_date != value)
                {
                    _price_date = value;
                    RaisePropertyChanged("price_date");
                }
            }
        }
        private DateTime? _validity_date;
        public DateTime? validity_date
        {
            get { return _validity_date; }
            set
            {
                if (_validity_date != value)
                {
                    _validity_date = value;
                    RaisePropertyChanged("validity_date");
                }
            }
        }
        private decimal? _qty_price;
        public decimal? qty_price
        {
            get { return _qty_price; }
            set
            {
                if (_qty_price != value)
                {
                    _qty_price = value;
                    RaisePropertyChanged("qty_price");
                }
            }
        }
        private decimal? _price_qty;
        public decimal? price_qty
        {
            get { return _price_qty; }
            set
            {
                if (_price_qty != value)
                {
                    _price_qty = value;
                    RaisePropertyChanged("price_qty");
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
                    _price_qty_uom = value;
                    RaisePropertyChanged("price_qty_uom");
                }
            }
        }
        private string _billing_doc_cat;
        public string billing_doc_cat
        {
            get { return _billing_doc_cat; }
            set
            {
                if (_billing_doc_cat != value)
                {
                    _billing_doc_cat = value;
                    RaisePropertyChanged("billing_doc_cat");
                }
            }
        }
        private string _billing_doc;
        public string billing_doc
        {
            get { return _billing_doc; }
            set
            {
                if (_billing_doc != value)
                {
                    _billing_doc = value;
                    RaisePropertyChanged("billing_doc");
                }
            }
        }
        private int? _billing_item_row_id;
        public int? billing_item_row_id
        {
            get { return _billing_item_row_id; }
            set
            {
                if (_billing_item_row_id != value)
                {
                    _billing_item_row_id = value;
                    RaisePropertyChanged("billing_item_row_id");
                }
            }
        }
        private string _ref_doc_cat;
        public string ref_doc_cat
        {
            get { return _ref_doc_cat; }
            set
            {
                if (_ref_doc_cat != value)
                {
                    _ref_doc_cat = value;
                    RaisePropertyChanged("ref_doc_cat");
                }
            }
        }
        private string _ref_doc_no;
        public string ref_doc_no
        {
            get { return _ref_doc_no; }
            set
            {
                if (_ref_doc_no != value)
                {
                    _ref_doc_no = value;
                    RaisePropertyChanged("ref_doc_no");
                }
            }
        }
        private int? _ref_item_row_id;
        public int? ref_item_row_id
        {
            get { return _ref_item_row_id; }
            set
            {
                if (_ref_item_row_id != value)
                {
                    _ref_item_row_id = value;
                    RaisePropertyChanged("ref_item_row_id");
                }
            }
        }
        private decimal? _freight1;
        public decimal? freight1
        {
            get { return _freight1; }
            set
            {
                if (_freight1 != value)
                {
                    _freight1 = value;
                    RaisePropertyChanged("freight1", ModelEntityUpdated);
                }
            }
        }
        private decimal? _freight2;
        public decimal? freight2
        {
            get { return _freight2; }
            set
            {
                if (_freight2 != value)
                {
                    _freight2 = value;
                    RaisePropertyChanged("freight2", ModelEntityUpdated);
                }
            }
        }
        private decimal? _freight3;
        public decimal? freight3
        {
            get { return _freight3; }
            set
            {
                if (_freight3 != value)
                {
                    _freight3 = value;
                    RaisePropertyChanged("freight3", ModelEntityUpdated);
                }
            }
        }
        private decimal? _duties;
        public decimal? duties
        {
            get { return _duties; }
            set
            {
                if (_duties != value)
                {
                    _duties = value;
                    RaisePropertyChanged("duties", ModelEntityUpdated);
                }
            }
        }
        private decimal? _other_cost;
        public decimal? other_cost
        {
            get { return _other_cost; }
            set
            {
                if (_other_cost != value)
                {
                    _other_cost = value;
                    RaisePropertyChanged("other_cost", ModelEntityUpdated);
                }
            }
        }
        private decimal? _landed_cost;
        public decimal? landed_cost
        {
            get { return _landed_cost; }
            set
            {
                if (_landed_cost != value)
                {
                    _landed_cost = value;
                    RaisePropertyChanged("landed_cost", ModelEntityUpdated);
                }
            }
        }
        private decimal? _profit_ratio;
        public decimal? profit_ratio
        {
            get { return _profit_ratio; }
            set
            {
                if (_profit_ratio != value)
                {
                    _profit_ratio = value;
                    RaisePropertyChanged("profit_ratio", ModelEntityUpdated);
                }
            }
        }
        private decimal? _profit_value;
        public decimal? profit_value
        {
            get { return _profit_value; }
            set
            {
                if (_profit_value != value)
                {
                    _profit_value = value;
                    RaisePropertyChanged("profit_value", ModelEntityUpdated);
                }
            }
        }
        private decimal? _price_var;
        public decimal? price_var
        {
            get { return _price_var; }
            set
            {
                if (_price_var != value)
                {
                    _price_var = value;
                    RaisePropertyChanged("price_var", ModelEntityUpdated);
                }
            }
        }
        private decimal? _price_var_value;
        public decimal? price_var_value
        {
            get { return _price_var_value; }
            set
            {
                if (_price_var_value != value)
                {
                    _price_var_value = value;
                    RaisePropertyChanged("price_var_value", ModelEntityUpdated);
                }
            }
        }
        private decimal? _price_tol;
        public decimal? price_tol
        {
            get { return _price_tol; }
            set
            {
                if (_price_tol != value)
                {
                    _price_tol = value;
                    RaisePropertyChanged("price_tol", ModelEntityUpdated);
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
        private decimal? _purchase_price;
        public decimal? purchase_price
        {
            get { return _purchase_price; }
            set
            {
                if (_purchase_price != value)
                {
                    _purchase_price = value;
                    RaisePropertyChanged("purchase_price", ModelEntityUpdated);
                }
            }
        }
        private string _party_code;
        public string party_code
        {
            get { return _party_code; }
            set
            {
                if (_party_code != value)
                {
                    _party_code = value;
                    RaisePropertyChanged("party_code");
                }
            }
        }
        //Scallar
        public bool? ind_sku { get; set; }

        private string _curr_code_purchase;
        public string curr_code_purchase
        {
            get { return _curr_code_purchase; }
            set
            {
                if (_curr_code_purchase != value)
                {
                    _curr_code_purchase = value;
                    RaisePropertyChanged("curr_code_purchase");
                }
            }
        }
        private decimal? _exch_rate_pur;
        public decimal? exch_rate_pur
        {
            get { return _exch_rate_pur; }
            set
            {
                if (_exch_rate_pur != value)
                {
                    _exch_rate_pur = value;
                    RaisePropertyChanged("exch_rate_pur");
                }
            }
        }
        private string _party_name;
        public string party_name
        {
            get { return _party_name; }
            set
            {
                if (_party_name != value)
                {
                    _party_name = value;
                    RaisePropertyChanged("party_name");
                }
            }
        }
        private string _curr_code_leg1;
        public string curr_code_leg1
        {
            get { return _curr_code_leg1; }
            set
            {
                if (_curr_code_leg1 != value)
                {
                    _curr_code_leg1 = value;
                    RaisePropertyChanged("curr_code_leg1");
                }
            }
        }
        private decimal? _leg1_percent;
        public decimal? leg1_percent
        {
            get { return _leg1_percent; }
            set
            {
                if (_leg1_percent != value)
                {
                    _leg1_percent = value;
                    RaisePropertyChanged("leg1_percent");
                }
            }
        }
        private decimal? _freight_rate2;
        public decimal? freight_rate2
        {
            get { return _freight_rate2; }
            set
            {
                if (_freight_rate2 != value)
                {
                    _freight_rate2 = value;
                    RaisePropertyChanged("freight_rate2");
                }
            }
        }

    }

    public class ADM_M0061_MC : STD_MC_BE
    {
        public List<ADM_M0061> MASTER_ENTITY_LIST { get; set; }
        public ObservableCollection<ADM_M0061_A> ITEM_ENTITY_LIST { get; set; }
        public List<ADM_M0061_A> CATLOG_SETTING_LIST { get; set; }
    }
}
