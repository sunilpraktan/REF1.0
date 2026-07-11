using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessEntity.ENG
{
    public partial class ENG_T001 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                _doc_no = value;
                RaisePropertyChanged("doc_no");
            }
        }

        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set
            {
                _doc_cat = value;
                RaisePropertyChanged("doc_cat");
            }
        }

        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set
            {
                _doc_type = value;
                RaisePropertyChanged("doc_type");
            }
        }

        private System.DateTime? _doc_date;
        public System.DateTime? doc_date
        {
            get { return _doc_date; }
            set
            {
                _doc_date = value;
                RaisePropertyChanged("doc_date");
            }
        }

        private string _location_id;
        public string location_id
        {
            get { return _location_id; }
            set
            {
                _location_id = value;
                RaisePropertyChanged("location_id");
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

        private int? _counter_no;
        public int? counter_no
        {
            get { return _counter_no; }
            set
            {
                _counter_no = value;
                RaisePropertyChanged("counter_no");
            }
        }
        private string _bom_cat;

        public string bom_cat
        {
            get { return _bom_cat; }
            set
            {
                _bom_cat = value;
                RaisePropertyChanged("bom_cat");
            }
        }

        private string _item_code;
        public string item_code
        {
            get { return _item_code; }
            set
            {
                _item_code = value;
                RaisePropertyChanged("item_code");
            }
        }

        private string _emp_id;
        public string emp_id
        {
            get { return _emp_id; }
            set
            {
                _emp_id = value;
                RaisePropertyChanged("emp_id");
            }
        }

        private string _party_code;
        public string party_code
        {
            get { return _party_code; }
            set
            {
                _party_code = value;
                RaisePropertyChanged("party_code");
            }
        }

        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set
            {
                _unit_code = value;
                RaisePropertyChanged("unit_code");
            }
        }

        private decimal? _bom_qty;
        public decimal? bom_qty
        {

            get { return _bom_qty; }
            set
            {
                _bom_qty = value;
                RaisePropertyChanged("bom_qty");
            }
        }

        private bool? _alternate_bom;
        public bool? alternate_bom
        {
            get { return _alternate_bom; }
            set
            {
                _alternate_bom = value;
                RaisePropertyChanged("alternate_bom");
            }
        }

        private string _revision_no;
        public string revision_no
        {
            get { return _revision_no; }
            set
            {
                _revision_no = value;
                RaisePropertyChanged("revision_no");
            }
        }

        private DateTime? _revision_date;
        public DateTime? revision_date
        {
            get { return _revision_date; }
            set
            {
                _revision_date = value;
                RaisePropertyChanged("revision_date");
            }
        }

        private string _ref_doc_no;
        public string ref_doc_no
        {
            get { return _ref_doc_no; }
            set
            {
                _ref_doc_no = value;
                RaisePropertyChanged("ref_doc_no");
            }
        }

        private string _order_doc_type;
        public string order_doc_type
        {
            get { return _order_doc_type; }
            set
            {
                _order_doc_type = value;
                RaisePropertyChanged("order_doc_type");
            }
        }

        private string _order_no;
        public string order_no
        {
            get { return _order_no; }
            set
            {
                _order_no = value;
                RaisePropertyChanged("order_no");
            }
        }

        private DateTime? _valid_from;
        public DateTime? valid_from
        {
            get { return _valid_from; }
            set
            {
                _valid_from = value;
                RaisePropertyChanged("valid_from");
            }
        }

        private DateTime? _valid_to;
        public DateTime? valid_to
        {
            get { return _valid_to; }
            set
            {
                _valid_to = value;
                RaisePropertyChanged("valid_to");
            }
        }

        private string _bom_name;
        public string bom_name
        {
            get { return _bom_name; }
            set
            {
                _bom_name = value;
                RaisePropertyChanged("bom_name");
            }
        }

        private string _note;
        public string note
        {
            get { return _note; }
            set
            {
                _note = value;
                RaisePropertyChanged("note");
            }
        }

        private string _active;
        public string active
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


        //scalar
        private string _item_name;
        public string item_name
        {
            get { return _item_name; }
            set
            {
                _item_name = value;
                RaisePropertyChanged("item_name");
            }
        }

        private string _remark;
        public string remark
        {
            get { return _remark; }
            set
            {
                _remark = value;
                RaisePropertyChanged("remark");
            }
        }

        private string _party_name;
        public string party_name
        {
            get { return _party_name; }
            set
            {
                _party_name = value;
                RaisePropertyChanged("party_name");
            }
        }

        private string _item_cat;
        public string item_cat
        {
            get { return _item_cat; }
            set
            {
                _item_cat = value;
                RaisePropertyChanged("item_cat");
            }

        }

        private string _cat_code;
        public string cat_code
        {
            get { return _cat_code; }
            set
            {
                _cat_code = value;
                RaisePropertyChanged("cat_code");
            }

        }

        private string _curr_code;
        public string curr_code
        {
            get { return _curr_code; }
            set
            {
                _curr_code = value;
                RaisePropertyChanged("curr_code");
            }
        }

        private string _bom_cat_code;
        public string bom_cat_code
        {
            get { return _bom_cat_code; }
            set
            {
                _bom_cat_code = value;
                RaisePropertyChanged("bom_cat_code");
            }
        }

        public string XDOC_A { get; set; }
        public string XDOC_C { get; set; }


    }
    public partial class ENG_T001_A : ObjectBase
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

        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                _doc_no = value;
                RaisePropertyChanged("_doc_no");
            }
        }

        private int? _counter_no;
        public int? counter_no
        {
            get { return _counter_no; }
            set
            {
                _counter_no = value;
                RaisePropertyChanged("counter_no");
            }
        }

        private string _bom_cat;
        public string bom_cat
        {
            get { return _bom_cat; }
            set
            {
                if (_bom_cat != value)
                {
                    _bom_cat = value; RaisePropertyChanged("bom_cat", ModelEntityUpdated);
                }
            }
        }

        private int? _bom_item_node_no;
        public int? bom_item_node_no
        {
            get { return _bom_item_node_no; }
            set
            {
                if (_bom_item_node_no != value)
                {
                    _bom_item_node_no = value; RaisePropertyChanged("bom_item_node_no", ModelEntityUpdated);
                }
            }
        }

        private DateTime? _valid_from;
        public DateTime? valid_from
        {
            get { return _valid_from; }
            set
            {
                if (_valid_from != value)
                {
                    _valid_from = value;RaisePropertyChanged("valid_from", ModelEntityUpdated);
                }
            }
        }

        private DateTime? _valid_to { get; set; }
        public DateTime? valid_to
        {
            get { return _valid_to; }
            set
            {
                if (_valid_to != value)
                {
                    _valid_to = value;RaisePropertyChanged("valid_to", ModelEntityUpdated);
                }
            }
        }

        private string _change_no;
        public string change_no
        {
            get { return _change_no; }
            set
            {
                if (_change_no != value)
                {
                    _change_no = value;RaisePropertyChanged("change_no", ModelEntityUpdated);
                }
            }
        }

        private string _parent_node;
        public string parent_node
        {
            get { return _parent_node; }
            set
            {
                if (_parent_node != value)
                {
                    _parent_node = value;RaisePropertyChanged("parent_node", ModelEntityUpdated);
                }
            }
        }

        private int? _previous_counter;
        public int? previous_counter
        {
            get { return _previous_counter; }
            set
            {
                if (_previous_counter != value)
                {
                    _previous_counter = value;RaisePropertyChanged("previous_counter", ModelEntityUpdated);
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
                    _item_code = value;RaisePropertyChanged("item_code", ModelEntityUpdated);
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
                    _item_name = value; RaisePropertyChanged("item_name", ModelEntityUpdated);
                }
            }
        }

        private string _issuing_plant;
        public string issuing_plant
        {
            get { return _issuing_plant; }
            set
            {
                if (_issuing_plant != value)
                {
                    _issuing_plant = value; RaisePropertyChanged("issuing_plant", ModelEntityUpdated);
                }
            }
        }

        private string _line_cat;
        public string line_cat
        {
            get { return _line_cat; }
            set
            {
                if (_line_cat != value)
                {
                    _line_cat = value; RaisePropertyChanged("line_cat", ModelEntityUpdated);
                }
            }
        }

        private int? _bom_item_no;
        public int? bom_item_no
        {
            get { return _bom_item_no; }
            set
            {
                if (_bom_item_no != value)
                {
                    _bom_item_no = value;RaisePropertyChanged("bom_item_no", ModelEntityUpdated);
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
                    _unit_code = value;RaisePropertyChanged("unit_code", ModelEntityUpdated);
                }
            }
        }

        private decimal? _qty;
        public decimal? qty
        {
            get { return _qty; }
            set
            {
                if (_qty != value)
                {
                    _qty = value;RaisePropertyChanged("qty", ModelEntityUpdated);
                }
            }
        }

        private string _fixed_qty;
        public string fixed_qty
        {
            get { return _fixed_qty; }
            set
            {
                if (_fixed_qty != value)
                {
                    _fixed_qty = value;RaisePropertyChanged("fixed_qty", ModelEntityUpdated);
                }
            }
        }

        private decimal? _component_scrap;
        public decimal? component_scrap
        {
            get { return _component_scrap; }
            set
            {
                if (_component_scrap != value)
                {
                    _component_scrap = value;RaisePropertyChanged("component_scrap", ModelEntityUpdated);
                }
            }
        }

        private decimal? _operation_scrap;
        public decimal? operation_scrap
        {
            get { return _operation_scrap; }
            set
            {
                if (_operation_scrap != value)
                {
                    _operation_scrap = value;RaisePropertyChanged("operation_scrap", ModelEntityUpdated);
                }
            }
        }

        private string _ind_net_scrap;
        public string ind_net_scrap
        {
            get { return _ind_net_scrap; }
            set
            {
                if (_ind_net_scrap != value)
                {
                    _ind_net_scrap = value;RaisePropertyChanged("ind_net_scrap", ModelEntityUpdated);
                }
            }
        }

        private string _ind_item_prd;
        public string ind_item_prd
        {
            get { return _ind_item_prd; }
            set
            {
                if (_ind_item_prd != value)
                {
                    _ind_item_prd = value;RaisePropertyChanged("ind_item_prd", ModelEntityUpdated);
                }
            }
        }

        private string _ind_item_sales;
        public string ind_item_sales
        {
            get { return _ind_item_sales; }
            set
            {
                if (_ind_item_sales != value)
                {
                    _ind_item_sales = value;RaisePropertyChanged("ind_item_sales", ModelEntityUpdated);
                }
            }
        }

        private string _ind_plant;
        public string ind_plant
        {
            get { return _ind_plant; }
            set
            {
                if (_ind_plant != value)
                {
                    _ind_plant = value;RaisePropertyChanged("ind_plant", ModelEntityUpdated);
                }
            }
        }

        private string _ind_costing;
        public string ind_costing
        {
            get { return _ind_costing; }
            set
            {
                if (_ind_costing != value)
                {
                    _ind_costing = value;RaisePropertyChanged("ind_costing", ModelEntityUpdated);
                }
            }
        }

        private string _ind_engg;
        public string ind_engg
        {
            get { return _ind_engg; }
            set
            {
                if (_ind_engg != value)
                {
                    _ind_engg = value;RaisePropertyChanged("ind_engg", ModelEntityUpdated);
                }
            }
        }

        private string _ind_recursive;
        public string ind_recursive
        {
            get { return _ind_recursive; }
            set
            {
                if (_ind_recursive != value)
                {
                    _ind_recursive = value;RaisePropertyChanged("ind_recursive", ModelEntityUpdated);
                }
            }
        }

        private string _ind_recursive_allowed;
        public string ind_recursive_allowed
        {
            get { return _ind_recursive_allowed; }
            set
            {
                if (_ind_recursive_allowed != value)
                {
                    _ind_recursive_allowed = value;RaisePropertyChanged("ind_recursive_allowed", ModelEntityUpdated);
                }
            }
        }

        private string _ind_alternative_item;
        public string ind_alternative_item
        {
            get { return _ind_alternative_item; }
            set
            {
                if (_ind_alternative_item != value)
                {
                    _ind_alternative_item = value;RaisePropertyChanged("ind_alternative_item", ModelEntityUpdated);
                }
            }
        }

        private string _ind_subitem_exit;
        public string ind_subitem_exit
        {
            get { return _ind_subitem_exit; }
            set
            {
                if (_ind_subitem_exit != value)
                {
                    _ind_subitem_exit = value;RaisePropertyChanged("ind_subitem_exit", ModelEntityUpdated);
                }
            }
        }

        private string _item_code_alt;
        public string item_code_alt
        {
            get { return _item_code_alt; }
            set
            {
                if (_item_code_alt != value)
                {
                    _item_code_alt = value;RaisePropertyChanged("item_code_alt", ModelEntityUpdated);
                }
            }

        }

        private string _revision_no;
        public string revision_no
        {
            get { return _revision_no; }
            set
            {
                if (_revision_no != value)
                {
                    _revision_no = value;RaisePropertyChanged("revision_no", ModelEntityUpdated);
                }
            }
        }

        private DateTime? _revision_date;
        public DateTime? revision_date
        {
            get { return _revision_date; }
            set
            {
                if (_revision_date != value)
                {
                    _revision_date = value;RaisePropertyChanged("revision_date", ModelEntityUpdated);
                }
            }
        }

        private string _ref_revision_no;
        public string ref_revision_no
        {
            get { return _ref_revision_no; }
            set
            {
                if (_ref_revision_no != value)
                {
                    _ref_revision_no = value;RaisePropertyChanged("ref_revision_no", ModelEntityUpdated);
                }
            }
        }

        private string _ind_pm_assembly;
        public string ind_pm_assembly
        {
            get { return _ind_pm_assembly; }
            set
            {
                if (_ind_pm_assembly != value)
                {
                    _ind_pm_assembly = value;RaisePropertyChanged("ind_pm_assembly", ModelEntityUpdated);
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
                    _active = value;RaisePropertyChanged("active", ModelEntityUpdated);
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
                    _t_status = value;RaisePropertyChanged("t_status", ModelEntityUpdated);
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
                    _comp_code = value;RaisePropertyChanged("comp_code", ModelEntityUpdated);
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
                    _location_id = value;RaisePropertyChanged("location_id", ModelEntityUpdated);
                }
            }
        }

        private string _sku;
        public string sku
        {
            get { return _sku; }
            set {
                if (_sku != value)
                {
                    _sku = value; RaisePropertyChanged("sku", ModelEntityUpdated);
                }
            }
        }

        private string _sku_desc;
        public string sku_desc
        {
            get { return _sku_desc; }
            set {
                if (_sku_desc != value)
                {
                    _sku_desc = value; RaisePropertyChanged("sku_desc", ModelEntityUpdated);
                }
            }
        }

        private string _info1;
        public string info1
        {
            get { return _info1; }
            set {
                if (_info1 != value)
                {
                    _info1 = value; RaisePropertyChanged("info1", ModelEntityUpdated);
                }
            }
        }

        private string _info2;
        public string info2
        {
            get { return _info2; }
            set
            {
                if (_info2 != value)
                {
                    _info2 = value; RaisePropertyChanged("info2", ModelEntityUpdated);
                }
            }
        }

        private string _info3;
        public string info3
        {
            get { return _info3; }
            set {
                if (_info3 != value)
                {
                    _info3 = value; RaisePropertyChanged("info3", ModelEntityUpdated);
                }
            }
        }

        private decimal? _con_qty;
        public decimal? con_qty
        {
            get { return _con_qty; }
            set
            {
                if (_con_qty != value)
                {
                    _con_qty = value;RaisePropertyChanged("con_qty", ModelEntityUpdated);
                }
            }
        }

        private string _con_uom;
        public string con_uom
        {
            get { return _con_uom; }
            set {
                if (_con_uom != value)
                {
                    _con_uom = value; RaisePropertyChanged("con_uom", ModelEntityUpdated);
                }
            }
        }

        private decimal? _per_qty;
        public decimal? per_qty
        {
            get { return _per_qty; }
            set
            {
                if (_per_qty != value)
                {
                    _per_qty = value;RaisePropertyChanged("per_qty", ModelEntityUpdated);
                }
            }
        }

        private string _per_uom;
        public string per_uom
        {
            get { return _per_uom; }
            set {
                if (_per_uom != value)
                {
                    _per_uom = value; RaisePropertyChanged("per_uom", ModelEntityUpdated);
                }
            }
        }

        private string _ind_usage;
        public string ind_usage
        {
            get { return _ind_usage; }
            set {
                if (_ind_usage != value)
                {
                    _ind_usage = value; RaisePropertyChanged("ind_usage", ModelEntityUpdated);
                }
            }
        }

        private string _ind_base;
        public string ind_base
        {
            get { return _ind_base; }
            set {
                if (_ind_base != value)
                {
                    _ind_base = value; RaisePropertyChanged("ind_base", ModelEntityUpdated);
                }
            }
        }

        private int? _line_id;
        public int? line_id
        {
            get { return _line_id; }
            set {
                if (_line_id != value)
                {
                    _line_id = value; RaisePropertyChanged("line_id", ModelEntityUpdated);
                }
            }
        }

        private double? _unit_price;
        public double? unit_price
        {
            get { return _unit_price; }
            set {
                if (_unit_price != value)
                {
                    _unit_price = value; RaisePropertyChanged("unit_price", ModelEntityUpdated);
                }
            }
        }

        private double? _price_unit;
        public double? price_unit
        {
            get { return _price_unit; }
            set {
                if (_price_unit != value)
                {
                    _price_unit = value; RaisePropertyChanged("price_unit", ModelEntityUpdated);
                }
            }
        }

        private string _curr_code;
        public string curr_code
        {
            get { return _curr_code; }
            set {
                if (_curr_code != value)
                {
                    _curr_code = value; RaisePropertyChanged("curr_code", ModelEntityUpdated);
                }
            }
        }

        private decimal? _total_value;
        public decimal? total_value
        {
            get { return _total_value; }
            set {
                if (_total_value != value)
                {
                    _total_value = value; RaisePropertyChanged("total_value", ModelEntityUpdated);
                }
            }
        }

        private double? _base_price;
        public double? base_price
        {
            get { return _base_price; }
            set {
                if (_base_price != value)
                {
                    _base_price = value; RaisePropertyChanged("base_price", ModelEntityUpdated);
                }
            }
        }

        private decimal? _total_base;
        public decimal? total_base
        {
            get { return _total_base; }
            set {
                if (_total_base != value)
                {
                    _total_base = value; RaisePropertyChanged("total_base", ModelEntityUpdated);
                }
            }
        }

        private decimal? _lead_time;
        public decimal? lead_time
        {
            get { return _lead_time; }
            set {
                if (_lead_time != value)
                {
                    _lead_time = value; RaisePropertyChanged("lead_time", ModelEntityUpdated);
                }
            }
        }

        private string _po_code;
        public string po_code
        {
            get { return _po_code; }
            set {
                if (_po_code != value)
                {
                    _po_code = value; RaisePropertyChanged("po_code", ModelEntityUpdated);
                }
            }
        }

        private string _pg_code;
        public string pg_code
        {
            get { return _pg_code; }
            set {
                if (_pg_code != value)
                {
                    _pg_code = value; RaisePropertyChanged("pg_code", ModelEntityUpdated);
                }
            }
        }

        private string _ind_req_comp;
        public string ind_req_comp
        {
            get { return _ind_req_comp; }
            set
            {
                if (_ind_req_comp != value)
                {
                    _ind_req_comp = value; RaisePropertyChanged("ind_req_comp", ModelEntityUpdated);
                }
            }
        }

        private string _stoce_code;
        public string stoce_code
        {
            get { return _stoce_code; }
            set {
                if (_stoce_code != value)
                {
                    _stoce_code = value; RaisePropertyChanged("stoce_code", ModelEntityUpdated);
                }
            }
        }

        private string _ind_co_product;
        public string ind_co_product
        {
            get { return _ind_co_product; }
            set {
                if (_ind_co_product != value)
                {
                    _ind_co_product = value; RaisePropertyChanged("ind_co_product", ModelEntityUpdated);
                }
            }
        }

        private int? _line_no;
        public int? line_no
        {
            get { return _line_no; }
            set {
                if (_line_no != value)
                {
                    _line_no = value; RaisePropertyChanged("line_no", ModelEntityUpdated);
                }
            }
        }

        private string _node_no;
        public string node_no
        {
            get { return _node_no; }
            set {
                if (_node_no != value)
                {
                    _node_no = value; RaisePropertyChanged("node_no", ModelEntityUpdated);
                }
            }
        }

        private int? _node_line;
        public int? node_line
        {
            get { return _node_line; }
            set {
                if (_node_line != value)
                {
                    _node_line = value; RaisePropertyChanged("node_line", ModelEntityUpdated);
                }
            }
        }

        private string _ind_hl_config;
        public string ind_hl_config
        {
            get { return _ind_hl_config; }
            set {
                if (_ind_hl_config != value)
                {
                    _ind_hl_config = value; RaisePropertyChanged("ind_hl_config", ModelEntityUpdated);
                }
            }
        }

        private double? _budget_price;
        public double? budget_price
        {
            get { return _budget_price; }
            set {
                if (_budget_price != value)
                {
                    _budget_price = value; RaisePropertyChanged("budget_price", ModelEntityUpdated);
                }
            }
        }

        private double? _target_price;
        public double? target_price
        {
            get { return _target_price; }
            set {
                if (_target_price != value)
                {
                    _target_price = value; RaisePropertyChanged("target_price", ModelEntityUpdated);
                }
            }
        }

        private double? _sale_price;
        public double? sale_price
        {
            get { return _sale_price; }
            set {
                if (_sale_price != value)
                {
                    _sale_price = value; RaisePropertyChanged("sale_price", ModelEntityUpdated);
                }
            }
        }

        private string _ind_claim;
        public string ind_claim
        {
            get { return _ind_claim; }
            set {
                if (_ind_claim != value)
                {
                    _ind_claim = value; RaisePropertyChanged("ind_claim", ModelEntityUpdated);
                }
            }
        }

        private string _ind_rev;
        public string ind_rev
        {
            get { return _ind_rev; }
            set {
                if (_ind_rev != value)
                {
                    _ind_rev = value; RaisePropertyChanged("ind_rev", ModelEntityUpdated);
                }
            }
        }

        private string _ind_var;
        public string ind_var
        {
            get { return _ind_var; }
            set {
                if (_ind_var != value)
                {
                    _ind_var = value; RaisePropertyChanged("ind_var", ModelEntityUpdated);
                }
            }
        }

        private string _ind_freeze;
        public string ind_freeze
        {
            get { return _ind_freeze; }
            set {
                if (_ind_freeze != value)
                {
                    _ind_freeze = value; RaisePropertyChanged("ind_freeze", ModelEntityUpdated);
                }
            }
        }


        //scalar fields
        private string _sub_cat;
        public string sub_cat
        {
            get { return _sub_cat; }
            set
            {
                _sub_cat = value;
                RaisePropertyChanged("sub_cat");
            }
        }

        private Nullable<bool> _ind_stock;
        public Nullable<bool> ind_stock
        {
            get { return _ind_stock; }
            set
            {
                _ind_stock = value;
                RaisePropertyChanged("ind_stock");
            }
        }

        private Nullable<bool> _ind_sku;
        public Nullable<bool> ind_sku
        {
            get { return _ind_sku; }
            set
            {
                _ind_sku = value;
                RaisePropertyChanged("ind_sku");
            }
        }

        private string _item_name_alt;
        public string item_name_alt
        {
            get { return _item_name_alt; }
            set
            {
                if (_item_name_alt != value)
                {
                    _item_name_alt = value; RaisePropertyChanged("item_name_alt");
                }
            }
        }

        private string _long_text;
        public string long_text
        {
            get { return _long_text; }
            set { _long_text = value; RaisePropertyChanged("long_text"); }
        }

        private bool? _selected;
        public bool? selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                RaisePropertyChanged("selected");
            }
        }
        private bool? _read_only;
        public bool? read_only
        {
            get { return _read_only; }
            set
            {
                _read_only = value;
                RaisePropertyChanged("read_only");
            }
        }

    }
    public class ENG_T001_C : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                _comp_code = value; RaisePropertyChanged("comp_code");
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
                    _location_id = value; RaisePropertyChanged("location_id", ModelEntityUpdated);
                }
            }
        }
        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                _doc_no = value; RaisePropertyChanged("doc_no");
            }
        }
        private string _item_code;
        public string item_code
        {
            get { return _item_code; }
            set
            {
                _item_code = value; RaisePropertyChanged("item_code");
            }
        }
        private string _bom_use;
        public string bom_use
        {
            get { return _bom_use; }
            set
            {
                _bom_use = value; RaisePropertyChanged("bom_use");
            }
        }
        private string _alternate_bom;
        public string alternate_bom
        {
            get { return _alternate_bom; }
            set
            {
                _alternate_bom = value; RaisePropertyChanged("alternate_bom");
            }
        }
        private string _ind_variant;
        public string ind_variant
        {

            get { return _ind_variant; }
            set
            {
                _ind_variant = value;
                RaisePropertyChanged("ind_variant");
            }
        }
        private DateTime? _valid_from;
        public DateTime? valid_from
        {
            get { return _valid_from; }
            set
            {
                _valid_from = value;
                RaisePropertyChanged("valid_from");
            }
        }
        
        
        private string _active;
        public string active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
            }
        }
        

        //Scalar
        private string _item_name;
        public string item_name
        {
            get { return _item_name; }
            set
            {
                _item_name = value;
                RaisePropertyChanged("item_name");
            }
        }
        
    }

    public class ENG_T005 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                _doc_no = value;
                RaisePropertyChanged("doc_no");
            }
        }
        private string _short_text;
        public string short_text
        {
            get { return _short_text; }
            set
            {
                _short_text = value;
                RaisePropertyChanged("short_text");
            }
        }
        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set
            {
                _doc_type = value;
                RaisePropertyChanged("doc_type");
            }
        }
        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set
            {
                _doc_cat = value;
                RaisePropertyChanged("doc_cat");
            }
        }
        private DateTime? _doc_date;
        public DateTime? doc_date
        {
            get { return _doc_date; }
            set
            {
                _doc_date = value;
                RaisePropertyChanged("doc_date");
            }
        }
        private string _task_list;
        public string task_list
        {
            get { return _task_list; }
            set
            {
                _task_list = value;
                RaisePropertyChanged("task_list");
            }
        }
        private string _group_counter;
        public string group_counter
        {
            get { return _group_counter; }
            set
            {
                _group_counter = value;
                RaisePropertyChanged("group_counter");
            }
        }
        private int? _plan_counter;
        public int? plan_counter
        {
            get { return _plan_counter; }
            set
            {
                _plan_counter = value;
                RaisePropertyChanged("plan_counter");
            }
        }
        private DateTime? _valid_from;
        public DateTime? valid_from
        {
            get { return _valid_from; }
            set
            {
                _valid_from = value;
                RaisePropertyChanged("valid_from");
            }
        }
        private string _tl_use;
        public string tl_use
        {
            get { return _tl_use; }
            set
            {
                _tl_use = value;
                RaisePropertyChanged("tl_use");
            }
        }
        private string _tl_type;
        public string tl_type
        {
            get { return _tl_type; }
            set
            {
                _tl_type = value;
                RaisePropertyChanged("tl_type");
            }
        }
        private string _tl_unit;
        public string tl_unit
        {
            get { return _tl_unit; }
            set
            {
                _tl_unit = value;
                RaisePropertyChanged("tl_unit");
            }
        }
        private decimal? _lot_size_from;
        public decimal? lot_size_from
        {
            get { return _lot_size_from; }
            set
            {
                _lot_size_from = value;
                RaisePropertyChanged("lot_size_from");
            }
        }
        private decimal? _lot_size_to;
        public decimal? lot_size_to
        {
            get { return _lot_size_to; }
            set
            {
                _lot_size_to = value;
                RaisePropertyChanged("lot_size_to");
            }
        }
        private string _tl_name;
        public string tl_name
        {
            get { return _tl_name; }
            set
            {
                _tl_name = value;
                RaisePropertyChanged("tl_name");
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
        private string _assign_para_set;
        public string assign_para_set
        {
            get { return _assign_para_set; }
            set
            {
                _assign_para_set = value;
                RaisePropertyChanged("assign_para_set");
            }
        }
        private string _para_set_location;
        public string para_set_location
        {
            get { return _para_set_location; }
            set
            {
                _para_set_location = value;
                RaisePropertyChanged("para_set_location");
            }
        }
        private string _dynamic_rule;
        public string dynamic_rule
        {
            get { return _dynamic_rule; }
            set
            {
                _dynamic_rule = value;
                RaisePropertyChanged("dynamic_rule");
            }
        }
        private string _para_group;
        public string para_group
        {
            get { return _para_group; }
            set
            {
                _para_group = value;
                RaisePropertyChanged("para_group");
            }
        }
        private string _para_value;
        private string para_value
        {
            get { return _para_value; }
            set
            {
                _para_value = value;
                RaisePropertyChanged("para_value");
            }
        }
        private string _sd_no;
        public string sd_no
        {
            get { return _sd_no; }
            set
            {
                _sd_no = value;
                RaisePropertyChanged("sd_no");
            }
        }
        private string _sd_version;
        public string sd_version
        {
            get { return _sd_version; }
            set
            {
                _sd_version = value;
                RaisePropertyChanged("sd_version");
            }
        }
        private string _insp_point;
        public string insp_point
        {
            get { return _insp_point; }
            set
            {
                _insp_point = value;
                RaisePropertyChanged("insp_point");
            }
        }
        private string _item_code;
        public string item_code
        {
            get { return _item_code; }
            set
            {
                _item_code = value;
                RaisePropertyChanged("item_code");
            }
        }
        private string _bom_no;
        public string bom_no
        {
            get { return _bom_no; }
            set
            {
                _bom_no = value;
                RaisePropertyChanged("bom_no");
            }
        }
        private string _bom_cat;
        public string bom_cat
        {
            get { return _bom_cat; }
            set
            {
                _bom_cat = value;
                RaisePropertyChanged("bom_cat");
            }
        }
        private string _bom_no_alt;
        public string bom_no_alt
        {
            get { return _bom_no_alt; }
            set
            {
                _bom_no_alt = value;
                RaisePropertyChanged("bom_no_alt");
            }
        }
        private decimal? _base_qty;
        public decimal? base_qty
        {
            get { return _base_qty; }
            set
            {
                _base_qty = value;
                RaisePropertyChanged("base_qty");
            }
        }
        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set
            {
                _unit_code = value;
                RaisePropertyChanged("unit_code");
            }
        }
        private decimal? _num_operation;
        public decimal? num_operation
        {
            get { return _num_operation; }
            set
            {
                _num_operation = value;
                RaisePropertyChanged("num_operation");
            }
        }
        private decimal? _deno_operation;
        public decimal? deno_operation
        {
            get { return _deno_operation; }
            set
            {
                _deno_operation = value;
                RaisePropertyChanged("deno_operation");
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
        private string _active;
        public string active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
            }
        }
        private string _location_id;
        public string location_id
        {
            get { return _location_id; }
            set
            {
                _location_id = value;
                RaisePropertyChanged("location_id");
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
        private string _plan_app;
        public string plan_app
        {
            get { return _plan_app; }
            set
            {
                _plan_app = value;
                RaisePropertyChanged("plan_app");
            }
        }

        //Scallar

        private string _item_name;
        public string item_name
        {
            get { return _item_name; }
            set
            {
                _item_name = value;
                RaisePropertyChanged("item_name");
            }
        }
        private string _letter_text;
        public string letter_text
        {
            get { return _letter_text; }
            set { if (_letter_text != value) { _letter_text = value; RaisePropertyChanged("letter_text"); } }
        }
        private string _body_text;
        public string body_text
        {
            get { return _body_text; }
            set { if (_body_text != value) { _body_text = value; RaisePropertyChanged("body_text"); } }
        }
        private string _header_text;
        public string header_text
        {
            get { return _header_text; }
            set { if (_header_text != value) { _header_text = value; RaisePropertyChanged("header_text"); } }
        }
        private string _footer_text;
        public string footer_text
        {
            get { return _footer_text; }
            set { if (_footer_text != value) { _footer_text = value; RaisePropertyChanged("footer_text"); } }
        }
        public string XDOC_A { get; set; }
        public string XDOC_B { get; set; }
        public string XDOC_C { get; set; }
        public string XDOC_R { get; set; }
        public string XDOC_M { get; set; }

        private string _class_code;
        public string class_code
        {
            get { return _class_code; }
            set
            {
                _class_code = value;
                RaisePropertyChanged("class_code");
            }
        }
        private string _class_name;
        public string class_name
        {
            get { return _class_name; }
            set
            {
                _class_name = value;
                RaisePropertyChanged("class_name");
            }
        }
    }
    public class ENG_T005_A : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int? _id;
        public int? id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged("id");
            }
        }
        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                _doc_no = value;
                RaisePropertyChanged("doc_no");
            }
        }
        private string _tl_type;
        public string tl_type
        {
            get { return _tl_type; }
            set
            {
                _tl_type = value;
                RaisePropertyChanged("tl_type");
            }
        }
        private int? _plan_counter;
        public int? plan_counter
        {
            get { return _plan_counter; }
            set
            {
                _plan_counter = value;
                RaisePropertyChanged("plan_counter");
            }
        }
        private DateTime? _valid_from;
        public DateTime? valid_from
        {
            get { return _valid_from; }
            set
            {
                _valid_from = value;
                RaisePropertyChanged("valid_from");
            }
        }
        private string _op_no;
        public string op_no
        {
            get { return _op_no; }
            set
            {
                _op_no = value;
                RaisePropertyChanged("op_no");
            }
        }
        private string _sub_op_no;
        public string sub_op_no
        {
            get { return _sub_op_no; }
            set
            {
                _sub_op_no = value;
                RaisePropertyChanged("sub_op_no");
            }
        }
        private string _control_key;
        public string control_key
        {
            get { return _control_key; }
            set
            {
                _control_key = value;
                RaisePropertyChanged("control_key");
            }
        }
        private string _obj_id;
        public string obj_id
        {
            get { return _obj_id; }
            set
            {
                _obj_id = value;
                RaisePropertyChanged("obj_id");
            }
        }
        private string _obj_type;
        public string obj_type
        {
            get { return _obj_type; }
            set
            {
                _obj_type = value;
                RaisePropertyChanged("obj_type");
            }
        }
        private string _op_code;
        public string op_code
        {
            get { return _op_code; }
            set
            {
                _op_code = value;
                RaisePropertyChanged("op_code");
            }
        }
        private string _short_text;
        public string short_text
        {
            get { return _short_text; }
            set
            {
                _short_text = value;
                RaisePropertyChanged("short_text");
            }
        }
        private string _op_name;
        public string op_name
        {
            get { return _op_name; }
            set
            {
                _op_name = value;
                RaisePropertyChanged("op_name");
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
        private decimal? _base_qty;
        public decimal? base_qty
        {
            get { return _base_qty; }
            set
            {
                _base_qty = value;
                RaisePropertyChanged("base_qty");
            }
        }
        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set
            {
                _unit_code = value;
                RaisePropertyChanged("unit_code");
            }
        }
        private decimal? _num_operation;
        public decimal? num_operation
        {
            get { return _num_operation; }
            set
            {
                _num_operation = value;
                RaisePropertyChanged("num_operation");
            }
        }
        private decimal? _deno_operation;
        public decimal? deno_operation
        {
            get { return _deno_operation; }
            set
            {
                _deno_operation = value;
                RaisePropertyChanged("deno_operation");
            }
        }
        private string _activity_type1;
        public string activity_type1
        {
            get { return _activity_type1; }
            set
            {
                _activity_type1 = value;
                RaisePropertyChanged("activity_type1");
            }
        }
        private string _unit_code1;
        public string unit_code1
        {
            get { return _unit_code1; }
            set
            {
                _unit_code1 = value;
                RaisePropertyChanged("unit_code1");
            }
        }
        private decimal? _std_value1;
        public decimal? std_value1
        {
            get { return _std_value1; }
            set
            {
                _std_value1 = value;
                RaisePropertyChanged("std_value1");
            }
        }
        private string _activity_type2;
        public string activity_type2
        {
            get { return _activity_type2; }
            set
            {
                _activity_type2 = value;
                RaisePropertyChanged("activity_type2");
            }
        }
        private string _unit_code2;
        public string unit_code2
        {
            get { return _unit_code2; }
            set
            {
                _unit_code2 = value;
                RaisePropertyChanged("unit_code2");
            }
        }
        private decimal? _std_value2;
        public decimal? std_value2
        {
            get { return _std_value2; }
            set
            {
                _std_value2 = value;
                RaisePropertyChanged("std_value2");
            }
        }
        private string _activity_type3;
        public string activity_type3
        {
            get { return _activity_type3; }
            set
            {
                _activity_type3 = value;
                RaisePropertyChanged("activity_type3");
            }
        }
        private string _unit_code3;
        public string unit_code3
        {
            get { return _unit_code3; }
            set
            {
                _unit_code3 = value;
                RaisePropertyChanged("unit_code3");
            }
        }
        private decimal? _std_value3;
        public decimal? std_value3
        {
            get { return _std_value3; }
            set
            {
                _std_value3 = value;
                RaisePropertyChanged("std_value3");
            }
        }
        private string _std_value_cal;
        public string std_value_cal
        {
            get { return _std_value_cal; }
            set
            {
                _std_value_cal = value;
                RaisePropertyChanged("std_value_cal");
            }
        }
        private decimal? _scrap_factor;
        public decimal? scrap_factor
        {
            get { return _scrap_factor; }
            set
            {
                _scrap_factor = value;
                RaisePropertyChanged("scrap_factor");
            }
        }
        private string _cust_id;
        public string cust_id
        {
            get { return _cust_id; }
            set
            {
                _cust_id = value;
                RaisePropertyChanged("cust_id");
            }
        }
        private string _vendor_id;
        public string vendor_id
        {
            get { return _vendor_id; }
            set
            {
                _vendor_id = value;
                RaisePropertyChanged("vendor_id");
            }
        }
        private string _bom_no;
        public string bom_no
        {
            get { return _bom_no; }
            set
            {
                _bom_no = value;
                RaisePropertyChanged("bom_no");
            }
        }
        private string _bom_cat;
        public string bom_cat
        {
            get { return _bom_cat; }
            set
            {
                _bom_cat = value;
                RaisePropertyChanged("bom_cat");
            }
        }
        private int? _bom_item_row_id;
        public int? bom_item_row_id
        {
            get { return _bom_item_row_id; }
            set
            {
                _bom_item_row_id = value;
                RaisePropertyChanged("bom_item_row_id");
            }
        }
        private string _priority;
        public string priority
        {
            get { return _priority; }
            set
            {
                _priority = value;
                RaisePropertyChanged("priority");
            }
        }
        private string _service_no;
        public string service_no
        {
            get { return _service_no; }
            set
            {
                _service_no = value;
                RaisePropertyChanged("service_no");
            }
        }
        private string _pur_doc_no;
        public string pur_doc_no
        {
            get { return _pur_doc_no; }
            set
            {
                _pur_doc_no = value;
                RaisePropertyChanged("pur_doc_no");
            }
        }
        private int? _pur_doc_item_row_id;
        public int? pur_doc_item_row_id
        {
            get { return _pur_doc_item_row_id; }
            set
            {
                _pur_doc_item_row_id = value;
                RaisePropertyChanged("pur_doc_item_row_id");
            }
        }
        private string _inst_code;
        public string inst_code
        {
            get { return _inst_code; }
            set
            {
                _inst_code = value;
                RaisePropertyChanged("inst_code");
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
        private string _active;
        public string active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
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
        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set
            {
                _doc_type = value;
                RaisePropertyChanged("doc_type");
            }
        }
        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set
            {
                _doc_cat = value;
                RaisePropertyChanged("doc_cat");
            }
        }
        private int? _line_id;
        public int? line_id
        {
            get { return _line_id; }
            set
            {
                _line_id = value;
                RaisePropertyChanged("line_id");
            }
        }
        private string _wc_code;
        public string wc_code
        {
            get { return _wc_code; }
            set
            {
                _wc_code = value;
                RaisePropertyChanged("wc_code");
            }
        }
        private string _insp_type;
        public string insp_type
        {
            get { return _insp_type; }
            set
            {
                _insp_type = value;
                RaisePropertyChanged("insp_type");
            }
        }
        private int? _op_seq;
        public int? op_seq
        {
            get { return _op_seq; }
            set
            {
                _op_seq = value;
                RaisePropertyChanged("op_seq");
            }
        }
        private string _task_id;
        public string task_id
        {
            get { return _task_id; }
            set
            {
                _task_id = value;
                RaisePropertyChanged("task_id");
            }
        }
        private decimal? _op_cost;
        public decimal? op_cost
        {
            get { return _op_cost; }
            set
            {
                _op_cost = value;
                RaisePropertyChanged("op_cost");
            }
        }
        private string _usage;
        public string usage
        {
            get { return _usage; }
            set
            {
                _usage = value;
                RaisePropertyChanged("usage");
            }
        }
        private int? _node_no;
        public int? node_no
        {
            get { return _node_no; }
            set
            {
                _node_no = value;
                RaisePropertyChanged("node_no");
            }
        }
        private string _tlgroup_key;
        public string tlgroup_key
        {
            get { return _tlgroup_key; }
            set
            {
                _tlgroup_key = value;
                RaisePropertyChanged("tlgroup_key");
            }
        }
    }
    public class ENG_T005_B : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int? _id;
        public int? id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged("id");
            }
        }
        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                _doc_no = value;
                RaisePropertyChanged("doc_no");
            }
        }
        private string _tl_type;
        public string tl_type
        {
            get { return _tl_type; }
            set
            {
                _tl_type = value;
                RaisePropertyChanged("tl_type");
            }
        }
        private string _char_type;
        public string char_type
        {
            get { return _char_type; }
            set
            {
                _char_type = value;
                RaisePropertyChanged("char_type");
            }
        }
        private int? _line_id;
        public int? line_id
        {
            get { return _line_id; }
            set
            {
                _line_id = value;
                RaisePropertyChanged("line_id");
            }
        }
        private string _char_code;
        public string char_code
        {
            get { return _char_code; }
            set
            {
                _char_code = value;
                RaisePropertyChanged("char_code");
            }
        }
        private string _char_name;
        public string char_name
        {
            get { return _char_name; }
            set
            {
                _char_name = value;
                RaisePropertyChanged("char_name");
            }
        }
        private int? _char_no;
        public int? char_no
        {
            get { return _char_no; }
            set
            {
                _char_no = value;
                RaisePropertyChanged("char_no");
            }
        }
        private int? _plan_counter;
        public int? plan_counter
        {
            get { return _plan_counter; }
            set
            {
                _plan_counter = value;
                RaisePropertyChanged("plan_counter");
            }
        }
        private DateTime? _valid_from;
        public DateTime? valid_from
        {
            get { return _valid_from; }
            set
            {
                _valid_from = value;
                RaisePropertyChanged("valid_from");
            }
        }
        private string _insp_method;
        public string insp_method
        {
            get { return _insp_method; }
            set
            {
                _insp_method = value;
                RaisePropertyChanged("insp_method");
            }
        }
        private string _insp_method_loc;
        public string insp_method_loc
        {
            get { return _insp_method_loc; }
            set
            {
                _insp_method_loc = value;
                RaisePropertyChanged("insp_method_loc");
            }
        }
        private string _insp_method_version;
        public string insp_method_version
        {

            get { return _insp_method_version; }
            set
            {
                _insp_method_version = value;
                RaisePropertyChanged("insp_method_version");
            }
        }
        private string _ref_char;
        public string ref_char
        {
            get { return _ref_char; }
            set
            {
                _ref_char = value;
                RaisePropertyChanged("ref_char");
            }
        }
        private string _char_location;
        public string char_location
        {
            get { return _char_location; }
            set
            {
                _char_location = value;
                RaisePropertyChanged("char_location");
            }
        }
        private string _char_ver;
        public string char_ver
        {
            get { return _char_ver; }
            set
            {
                _char_ver = value;
                RaisePropertyChanged("char_ver");
            }
        }
        private DateTime? _ver_date;
        public DateTime? ver_date
        {
            get { return _ver_date; }
            set
            {
                _ver_date = value;
                RaisePropertyChanged("ver_date");
            }
        }
        private string _way_char;
        public string way_char
        {
            get { return _way_char; }
            set
            {
                _way_char = value;
                RaisePropertyChanged("way_char");
            }
        }
        private string _insp_qual;
        public string insp_qual
        {
            get { return _insp_qual; }
            set
            {
                _insp_qual = value;
                RaisePropertyChanged("insp_qual");
            }
        }
        private string _tol_key;
        public string tol_key
        {
            get { return _tol_key; }
            set
            {
                _tol_key = value;
                RaisePropertyChanged("tol_key");
            }
        }
        private string _short_text;
        public string short_text
        {
            get { return _short_text; }
            set
            {
                _short_text = value;
                RaisePropertyChanged("short_text");
            }
        }
        private string _long_text;
        public string long_text
        {
            get { return _long_text; }
            set
            {
                _long_text = value;
                RaisePropertyChanged("long_text");
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
        private int? _dc_place;
        public int? dc_place
        {
            get { return _dc_place; }
            set
            {
                _dc_place = value;
                RaisePropertyChanged("dc_place");
            }
        }
        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set
            {
                _unit_code = value;
                RaisePropertyChanged("unit_code");
            }
        }
        private double? _target_value;
        public double? target_value
        {
            get { return _target_value; }
            set
            {
                _target_value = value;
                RaisePropertyChanged("target_value");
            }
        }
        private string _value1;
        public string value1
        {
            get { return _value1; }
            set
            {
                _value1 = value;
                RaisePropertyChanged("value1");
            }
        }
        private double? _low_limit;
        public double? low_limit
        {
            get { return _low_limit; }
            set
            {
                _low_limit = value;
                RaisePropertyChanged("low_limit");
            }
        }
        private double? _up_limit;
        public double? up_limit
        {
            get { return _up_limit; }
            set
            {
                _up_limit = value;
                RaisePropertyChanged("up_limit");
            }
        }
        private double? _low_limit1;
        public double? low_limit1
        {
            get { return _low_limit1; }
            set
            {
                _low_limit1 = value;
                RaisePropertyChanged("low_limit1");
            }
        }
        private double? _up_limit1;
        public double? up_limit1
        {
            get { return _up_limit1; }
            set
            {
                _up_limit1 = value;
                RaisePropertyChanged("up_limit1");
            }
        }
        private string _value2;
        public string value2
        {
            get { return _value2; }
            set
            {
                _value2 = value;
                RaisePropertyChanged("value2");
            }
        }
        private double? _low_tol_limit;
        public double? low_tol_limit
        {
            get { return _low_tol_limit; }
            set
            {
                _low_tol_limit = value;
                RaisePropertyChanged("low_tol_limit");
            }
        }
        private double? _up_tol_limit;
        public double? up_tol_limit
        {
            get { return _up_tol_limit; }
            set
            {
                _up_tol_limit = value;
                RaisePropertyChanged("up_tol_limit");
            }
        }
        private string _sample_uom;
        public string sample_uom
        {
            get { return _sample_uom; }
            set
            {
                _sample_uom = value;
                RaisePropertyChanged("sample_uom");
            }
        }
        private string _samp_pro_char;
        public string samp_pro_char
        {
            get { return _samp_pro_char; }
            set
            {
                _samp_pro_char = value;
                RaisePropertyChanged("samp_pro_char");
            }
        }
        private double? _cf_sample;
        public double? cf_sample
        {
            get { return _cf_sample; }
            set
            {
                _cf_sample = value;
                RaisePropertyChanged("cf_sample");
            }
        }
        private double? _cf_material;
        public double? cf_material
        {
            get { return _cf_material; }
            set
            {
                _cf_material = value;
                RaisePropertyChanged("cf_material");
            }
        }
        private double? _sampl_qty_factor;
        public double? sampl_qty_factor
        {
            get { return _sampl_qty_factor; }
            set
            {
                _sampl_qty_factor = value;
                RaisePropertyChanged("sampl_qty_factor");
            }
        }
        private string _mod_data;
        public string mod_data
        {
            get { return _mod_data; }
            set
            {
                _mod_data = value;
                RaisePropertyChanged("mod_data");
            }
        }
        private string _cal_formula;
        public string cal_formula
        {
            get { return _cal_formula; }
            set
            {
                _cal_formula = value;
                RaisePropertyChanged("cal_formula");
            }
        }
        private string _formula1;
        public string formula1
        {
            get { return _formula1; }
            set
            {
                _formula1 = value;
                RaisePropertyChanged("formula1");
            }
        }
        private string _formula2;
        public string formula2
        {
            get { return _formula2; }
            set
            {
                _formula2 = value;
                RaisePropertyChanged("formula2");
            }
        }
        private string _qm_para_group;
        public string qm_para_group
        {
            get { return _qm_para_group; }
            set
            {
                _qm_para_group = value;
                RaisePropertyChanged("qm_para_group");
            }
        }
        private string _qm_para;
        public string qm_para
        {
            get { return _qm_para; }
            set
            {
                _qm_para = value;
                RaisePropertyChanged("qm_para");
            }
        }
        private string _lower_ver_no;
        public string lower_ver_no
        {
            get { return _lower_ver_no; }
            set
            {
                _lower_ver_no = value;
                RaisePropertyChanged("lower_ver_no");
            }
        }
        private string _qm_para_group1;
        public string qm_para_group1
        {
            get { return _qm_para_group1; }
            set
            {
                _qm_para_group1 = value;
                RaisePropertyChanged("qm_para_group1");
            }
        }
        private string _qm_para1;
        public string qm_para1
        {
            get { return _qm_para1; }
            set
            {
                _qm_para1 = value;
                RaisePropertyChanged("qm_para1");
            }
        }
        private string _upper_ver_no;
        public string upper_ver_no
        {
            get { return _upper_ver_no; }
            set
            {
                _upper_ver_no = value;
                RaisePropertyChanged("upper_ver_no");
            }
        }
        private string _catlog_para_set;
        public string catlog_para_set
        {
            get { return _catlog_para_set; }
            set
            {
                _catlog_para_set = value;
                RaisePropertyChanged("catlog_para_set");
            }
        }
        private string _cat_type_para_set;
        public string cat_type_para_set
        {
            get { return _cat_type_para_set; }
            set
            {
                _cat_type_para_set = value;
                RaisePropertyChanged("cat_type_para_set");
            }
        }
        private string _assign_para_set;
        public string assign_para_set
        {
            get { return _assign_para_set; }
            set
            {
                _assign_para_set = value;
                RaisePropertyChanged("assign_para_set");
            }
        }
        private string _plant_para_set;
        public string plant_para_set
        {
            get { return _plant_para_set; }
            set
            {
                _plant_para_set = value;
                RaisePropertyChanged("plant_para_set");
            }
        }
        private string _version1;
        public string version1
        {
            get { return _version1; }
            set
            {
                _version1 = value;
                RaisePropertyChanged("version1");
            }
        }
        private string _mod_rule;
        public string mod_rule
        {
            get { return _mod_rule; }
            set
            {
                _mod_rule = value;
                RaisePropertyChanged("mod_rule");
            }
        }
        private string _equip_no;
        public string equip_no
        {
            get { return _equip_no; }
            set
            {
                _equip_no = value;
                RaisePropertyChanged("equip_no");
            }
        }
        private string _qm_para_group2;
        public string qm_para_group2
        {
            get { return _qm_para_group2; }
            set
            {
                _qm_para_group2 = value;
                RaisePropertyChanged("qm_para_group2");
            }
        }
        private string _qm_para2;
        public string qm_para2
        {
            get { return _qm_para2; }
            set
            {
                _qm_para2 = value;
                RaisePropertyChanged("qm_para2");
            }
        }
        private string _control_method;
        public string control_method
        {
            get { return _control_method; }
            set
            {
                _control_method = value;
                RaisePropertyChanged("control_method");
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
        private string _active;
        public string active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
            }
        }
        private string _location_id;
        public string location_id
        {
            get { return _location_id; }
            set
            {
                if(_location_id != value)
                {
                    _location_id = value;
                    RaisePropertyChanged("location_id", ModelEntityUpdated);
                }
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
        private string _control_data;
        public string control_data
        {
            get { return _control_data; }
            set
            {
                _control_data = value;
                RaisePropertyChanged("control_data");
            }
        }
        private string _fract_cal;
        public string fract_cal
        {
            get { return _fract_cal; }
            set
            {
                _fract_cal = value;
                RaisePropertyChanged("fract_cal");
            }
        }
        private string _op_no;
        public string op_no
        {
            get { return _op_no; }
            set
            {
                _op_no = value;
                RaisePropertyChanged("op_no");
            }
        }
        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set
            {
                _doc_type = value;
                RaisePropertyChanged("doc_type");
            }
        }
        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set
            {
                _doc_cat = value;
                RaisePropertyChanged("doc_cat");
            }
        }
        private string _para_prof_code;
        public string para_prof_code
        {
            get { return _para_prof_code; }
            set
            {
                _para_prof_code = value;
                RaisePropertyChanged("para_prof_code");
            }
        }
        private string _gc_or_ss;
        public string gc_or_ss
        {
            get { return _gc_or_ss; }
            set
            {
                _gc_or_ss = value;
                RaisePropertyChanged("gc_or_ss");
            }
        }
        private string _ind_char;
        public string ind_char
        {
            get { return _ind_char; }
            set
            {
                _ind_char = value;
                RaisePropertyChanged("ind_char");
            }
        }
        private int? _line_id_op;
        public int? line_id_op
        {
            get { return _line_id_op; }
            set
            {
                _line_id_op = value;
                RaisePropertyChanged("line_id_op");
            }
        }
        private int? _op_row_id;
        public int? op_row_id
        {
            get { return _op_row_id; }
            set
            {
                _op_row_id = value;
                RaisePropertyChanged("op_row_id");
            }
        }
        private string _spec_info;
        public string spec_info
        {
            get { return _spec_info; }
            set
            {
                _spec_info = value;
                RaisePropertyChanged("spec_info");
            }
        }
        private string _ref_class;
        public string ref_class
        {
            get { return _ref_class; }
            set
            {
                _ref_class = value;
                RaisePropertyChanged("ref_class");
            }
        }
        private string _vc_code;
        public string vc_code
        {
            get { return _vc_code; }
            set
            {
                _vc_code = value;
                RaisePropertyChanged("vc_code");
            }
        }
        private string _fcode;
        public string fcode
        {
            get { return _fcode; }
            set
            {
                _fcode = value;
                RaisePropertyChanged("fcode");
            }
        }
        private string _lot_no;
        public string lot_no
        {
            get { return _lot_no; }
            set
            {
                _lot_no = value;
                RaisePropertyChanged("lot_no");
            }
        }


        //Scalar Fields
        private string _char_group;
        public string char_group
        {
            get { return _char_group; }
            set
            {
                _char_group = value;
                RaisePropertyChanged("char_group");
            }
        }
        private string _group_name;
        public string group_name
        {
            get { return _group_name; }
            set
            {
                _group_name = value;
                RaisePropertyChanged("group_name");
            }
        }
        private string _prof_tpye_name;
        public string prof_tpye_name
        {
            get { return _prof_tpye_name; }
            set
            {
                _prof_tpye_name = value;
                RaisePropertyChanged("prof_tpye_name");
            }
        }
        private string _vc_name;
        public string vc_name
        {
            get { return _vc_name; }
            set
            {
                _vc_name = value;
                RaisePropertyChanged("vc_name");
            }
        }
        private string _class_code;
        public string class_code
        {
            get { return _class_code; }
            set
            {
                _class_code = value;
                RaisePropertyChanged("class_code");
            }
        }
        private string _class_name;
        public string class_name
        {
            get { return _class_name; }
            set
            {
                _class_name = value;
                RaisePropertyChanged("class_name");
            }
        }
        private string _ind_interval;
        public string ind_interval
        {
            get { return _ind_interval; }
            set
            {
                _ind_interval = value;
                RaisePropertyChanged("ind_interval");
            }
        }
        private string _ind_mv;
        public string ind_mv
        {
            get { return _ind_mv; }
            set
            {
                _ind_mv = value;
                RaisePropertyChanged("ind_mv");
            }
        }
        private int? _char_seq;
        public int? char_seq
        {
            get { return _char_seq; }
            set
            {
                _char_seq = value;
                RaisePropertyChanged("char_seq");
            }
        }
        public override string ToString()
        {
            return string.Format("{0}", char_code);
        }

    }
    public class ENG_T005_C : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int? _id;
        public int? id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged("id");
            }
        }
        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                _doc_no = value;
                RaisePropertyChanged("doc_no");
            }
        }
        private string _op_no;
        public string op_no
        {
            get { return _op_no; }
            set
            {
                _op_no = value;
                RaisePropertyChanged("op_no");
            }
        }
        private string _char_code;
        public string char_code
        {
            get { return _char_code; }
            set
            {
                _char_code = value;
                RaisePropertyChanged("char_code");
            }
        }
        private string _prof_type;
        public string prof_type
        {
            get { return _prof_type; }
            set
            {
                _prof_type = value;
                RaisePropertyChanged("prof_type");
            }
        }
        private string _prof_code;
        public string prof_code
        {
            get { return _prof_code; }
            set
            {
                _prof_code = value;
                RaisePropertyChanged("prof_code");
            }
        }
        private string _plant_gc;
        public string plant_gc
        {
            get { return _plant_gc; }
            set
            {
                _plant_gc = value;
                RaisePropertyChanged("plant_gc");
            }
        }
        private bool? _ind_gc_or_ss;
        public bool? ind_gc_or_ss
        {
            get { return _ind_gc_or_ss; }
            set
            {
                _ind_gc_or_ss = value;
                RaisePropertyChanged("ind_gc_or_ss");
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
        private string _active;
        public string active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
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
        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set
            {
                _doc_type = value;
                RaisePropertyChanged("doc_type");
            }
        }
        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set
            {
                _doc_cat = value;
                RaisePropertyChanged("doc_cat");
            }
        }
        private int? _line_id_ic;
        public int? line_id_ic
        {
            get { return _line_id_ic; }
            set
            {
                _line_id_ic = value;
                RaisePropertyChanged("line_id_ic");
            }
        }
        private int? _line_id_op;
        public int? line_id_op
        {
            get { return _line_id_op; }
            set
            {
                _line_id_op = value;
                RaisePropertyChanged("line_id_op");
            }
        }
        private int? _op_row_id;
        public int? op_row_id
        {
            get { return _op_row_id; }
            set
            {
                _op_row_id = value;
                RaisePropertyChanged("op_row_id");
            }
        }
        private int? _char_row_id;
        public int? char_row_id
        {
            get { return _char_row_id; }
            set
            {
                _char_row_id = value;
                RaisePropertyChanged("char_row_id");
            }
        }

        //Scalar

        private string _para_name;
        public string para_name
        {
            get { return _para_name; }
            set
            {
                _para_name = value;
                RaisePropertyChanged("para_name");
            }
        }


    }
    public class ENG_T005_R : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int? _id;
        public int? id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged("id");
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
                _doc_no = value;
                RaisePropertyChanged("doc_no");
            }
        }
        private string _tl_type;
        public string tl_type
        {
            get { return _tl_type; }
            set
            {
                _tl_type = value;
                RaisePropertyChanged("tl_type");
            }
        }
        private string _group_counter;
        public string group_counter
        {
            get { return _group_counter; }
            set
            {
                _group_counter = value;
                RaisePropertyChanged("group_counter");
            }
        }
        private int? _plan_counter;
        public int? plan_counter
        {
            get { return _plan_counter; }
            set
            {
                _plan_counter = value;
                RaisePropertyChanged("plan_counter");
            }
        }
        private int? _int_counter;
        public int? int_counter
        {
            get { return _int_counter; }
            set
            {
                _int_counter = value;
                RaisePropertyChanged("int_counter");
            }
        }
        private DateTime? _valid_from;
        public DateTime? valid_from
        {
            get { return _valid_from; }
            set
            {
                _valid_from = value;
                RaisePropertyChanged("valid_from");
            }
        }
        private int? _op_row_id;
        public int? op_row_id
        {
            get { return _op_row_id; }
            set
            {
                _op_row_id = value;
                RaisePropertyChanged("op_row_id");
            }
        }
        private int? _node_no;
        public int? node_no
        {
            get { return _node_no; }
            set
            {
                _node_no = value;
                RaisePropertyChanged("node_no");
            }
        }
        private decimal? _qty;
        public decimal? qty
        {
            get { return _qty; }
            set
            {
                _qty = value;
                RaisePropertyChanged("qty");
            }
        }
        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set
            {
                _unit_code = value;
                RaisePropertyChanged("unit_code");
            }
        }
        private string _ind_backflush;
        public string ind_backflush
        {
            get { return _ind_backflush; }
            set
            {
                _ind_backflush = value;
                RaisePropertyChanged("ind_backflush");
            }
        }
        private string _ind_external;
        public string ind_external
        {
            get { return _ind_external; }
            set
            {
                _ind_external = value;
                RaisePropertyChanged("ind_external");
            }
        }
        private string _item_code;
        public string item_code
        {
            get { return _item_code; }
            set
            {
                _item_code = value;
                RaisePropertyChanged("item_code");
            }
        }
        private string _store_code;
        public string store_code
        {
            get { return _store_code; }
            set
            {
                _store_code = value;
                RaisePropertyChanged("store_code");
            }
        }
        private string _active;
        public string active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
            }
        }
        private string _bom_no;
        public string bom_no
        {
            get { return _bom_no; }
            set
            {
                _bom_no = value;
                RaisePropertyChanged("bom_no");
            }
        }
        private string _bom_cat;
        public string bom_cat
        {
            get { return _bom_cat; }
            set
            {
                _bom_cat = value;
                RaisePropertyChanged("bom_cat");
            }
        }
        private string _bom_no_alt;
        public string bom_no_alt
        {
            get { return _bom_no_alt; }
            set
            {
                _bom_no_alt = value;
                RaisePropertyChanged("bom_no_alt");
            }
        }
        private int? _bom_item_row_id;
        public int? bom_item_row_id
        {
            get { return _bom_item_row_id; }
            set
            {
                _bom_item_row_id = value;
                RaisePropertyChanged("bom_item_row_id");
            }
        }


        //Scalar
        private string _item_name;
        public string item_name
        {
            get { return _item_name; }
            set
            {
                _item_name = value;
                RaisePropertyChanged("item_name");
            }
        }
        private int? _line_id_A;
        public int? line_id_A
        {
            get { return _line_id_A; }
            set
            {
                _line_id_A = value;
                RaisePropertyChanged("_line_id_A");
            }
        }
    }
    public class ENG_T005_M : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int? _id;
        public int? id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged("id");
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
                _doc_no = value;
                RaisePropertyChanged("doc_no");
            }
        }
        private string _item_code;
        public string item_code
        {
            get { return _item_code; }
            set
            {
                _item_code = value;
                RaisePropertyChanged("item_code");
            }
        }
        private string _tl_type;
        public string tl_type
        {
            get { return _tl_type; }
            set
            {
                _tl_type = value;
                RaisePropertyChanged("tl_type");
            }
        }
        private string _group_counter;
        public string group_counter
        {
            get { return _group_counter; }
            set
            {
                _group_counter = value;
                RaisePropertyChanged("group_counter");
            }
        }
        private int? _plan_counter;
        public int? plan_counter
        {
            get { return _plan_counter; }
            set
            {
                _plan_counter = value;
                RaisePropertyChanged("plan_counter");
            }
        }
        private int? _int_counter;
        public int? int_counter
        {
            get { return _int_counter; }
            set
            {
                _int_counter = value;
                RaisePropertyChanged("int_counter");
            }
        }
        private DateTime? _valid_from;
        public DateTime? valid_from
        {
            get { return _valid_from; }
            set
            {
                _valid_from = value;
                RaisePropertyChanged("valid_from");
            }
        }
        private string _customer;
        public string customer
        {

            get { return _customer; }
            set
            {
                _customer = value;
                RaisePropertyChanged("customer");
            }
        }
        private string _supplier;
        public string supplier
        {
            get { return _supplier; }
            set
            {
                _supplier = value;
                RaisePropertyChanged("supplier");
            }
        }
        private string _sd_doc_no;
        public string sd_doc_no
        {
            get { return _sd_doc_no; }
            set
            {
                _sd_doc_no = value;
                RaisePropertyChanged("sd_doc_no");
            }
        }
        private int? _sd_item_row_id;
        public int? sd_item_row_id
        {
            get { return _sd_item_row_id; }
            set
            {
                _sd_item_row_id = value;
                RaisePropertyChanged("sd_item_row_id");
            }
        }
        private string _element_id;
        public string element_id
        {
            get { return _element_id; }
            set
            {
                _element_id = value;
                RaisePropertyChanged("element_id");
            }
        }
        private string _active;
        public string active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
            }
        }
        private string _obj_code;
        public string obj_code
        {
            get { return _obj_code; }
            set
            {
                _obj_code = value;
                RaisePropertyChanged("obj_code");
            }
        }
        private string _ind_sgroup;
        public string ind_sgroup
        {
            get { return _ind_sgroup; }
            set
            {
                _ind_sgroup = value;
                RaisePropertyChanged("ind_sgroup");
            }
        }
        private string _dept_code;
        public string dept_code
        {
            get { return _dept_code; }
            set
            {
                _dept_code = value;
                RaisePropertyChanged("dept_code");
            }
        }

        //Scalar
        private string _item_name;
        public string item_name
        {
            get { return _item_name; }
            set
            {
                _item_name = value;
                RaisePropertyChanged("item_name");
            }
        }
        private string _obj_name;
        public string obj_name
        {
            get { return _obj_name; }
            set
            {
                _obj_name = value;
                RaisePropertyChanged("obj_name");
            }
        }
        private string _dept_name;
        public string dept_name
        {
            get { return _dept_name; }
            set
            {
                _dept_name = value;
                RaisePropertyChanged("dept_name");
            }
        }
    }

    public class ENG_M0005 : ObjectBase
    {
        public string _comp_code { get; set; }
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                if (_comp_code != value)
                {
                    _comp_code = value; RaisePropertyChanged("comp_code");
                }
            }
        }
        private string _location_id { get; set; }
        public string location_id
        {
            get { return _location_id; }
            set
            {
                if (_location_id != value)
                {
                    _location_id = value; RaisePropertyChanged("location_id");
                }
            }
        }
        private string _mp_no { get; set; }
        public string mp_no
        {
            get { return _mp_no; }
            set
            {
                if (_mp_no != value)
                {
                    _mp_no = value; RaisePropertyChanged("mp_no");
                }
            }
        }
        private string _obj_no { get; set; }
        public string obj_no
        {
            get { return _obj_no; }
            set
            {
                if (_obj_no != value)
                {
                    _obj_no = value; RaisePropertyChanged("obj_no");
                }
            }
        }
        private string _pos_no { get; set; }
        public string pos_no
        {
            get { return _pos_no; }
            set
            {
                if (_pos_no != value)
                {
                    _pos_no = value; RaisePropertyChanged("pos_no");
                }
            }
        }
        private string _short_text { get; set; }
        public string short_text
        {
            get { return _short_text; }
            set
            {
                if (_short_text != value)
                {
                    _short_text = value; RaisePropertyChanged("short_text");
                }
            }
        }
        private string _mp_cat { get; set; }
        public string mp_cat
        {
            get { return _mp_cat; }
            set
            {
                if (_mp_cat != value)
                {
                    _mp_cat = value; RaisePropertyChanged("mp_cat");
                }
            }
        }
        private string _ind_pose { get; set; }
        public string ind_pose
        {
            get { return _ind_pose; }
            set
            {
                if (_ind_pose != value)
                {
                    _ind_pose = value; RaisePropertyChanged("ind_pose");
                }
            }
        }
        private string _ind_ref { get; set; }
        public string ind_ref
        {
            get { return _ind_ref; }
            set
            {
                if (_ind_ref != value)
                {
                    _ind_ref = value; RaisePropertyChanged("ind_ref");
                }
            }
        }
        private string _ref_mp { get; set; }
        public string ref_mp
        {
            get { return _ref_mp; }
            set
            {
                if (_ref_mp != value)
                {
                    _ref_mp = value; RaisePropertyChanged("ref_mp");
                }
            }
        }
        private string _char_code { get; set; }
        public string char_code
        {
            get { return _char_code; }
            set
            {
                if (_char_code != value)
                {
                    _char_code = value; RaisePropertyChanged("_char_code");
                }
            }
        }
        private int? _char_no { get; set; }
        public int? char_no
        {
            get { return _char_no; }
            set
            {
                if (_char_no != value)
                {
                    _char_no = value; RaisePropertyChanged("char_no");
                }
            }
        }
        private string _ind_ma_ref { get; set; }
        public string ind_ma_ref
        {
            get { return _ind_ma_ref; }
            set
            {
                if (_ind_ma_ref != value)
                {
                    _ind_ma_ref = value; RaisePropertyChanged("ind_ma_ref");
                }
            }
        }
        private int? _expon { get; set; }
        public int? expon
        {
            get { return _expon; }
            set
            {
                if (_expon != value)
                {
                    _expon = value; RaisePropertyChanged("expon");
                }
            }
        }
        private int? _decno { get; set; }
        public int? decno
        {
            get { return _decno; }
            set
            {
                if (_decno != value)
                {
                    _decno = value; RaisePropertyChanged("decno");
                }
            }
        }
        private double? _target_value { get; set; }
        public double? target_value
        {
            get { return _target_value; }
            set
            {
                if (_target_value != value)
                {
                    _target_value = value; RaisePropertyChanged("target_value");
                }
            }
        }
        //private string _ind_value { get; set; }
        //public string ind_value
        //{
        //    get { return _ind_value; }
        //    set
        //    {
        //        if (_ind_value != value)
        //        {
        //            _ind_value = value; RaisePropertyChanged("ind_value");
        //        }
        //    }
        //}
        private string _ind_value_ref { get; set; }
        public string ind_value_ref
        {
            get { return _ind_value_ref; }
            set
            {
                if (_ind_value_ref != value)
                {
                    _ind_value_ref = value; RaisePropertyChanged("ind_value_ref");
                }
            }
        }
        private string _note { get; set; }
        public string note
        {
            get { return _note; }
            set
            {
                if (_note != value)
                {
                    _note = value; RaisePropertyChanged("note");
                }
            }
        }
        private double? _low_limit { get; set; }
        public double? low_limit
        {
            get { return _low_limit; }
            set
            {
                if (_low_limit != value)
                {
                    _low_limit = value; RaisePropertyChanged("low_limit");
                }
            }
        }
        private string _ind_value1 { get; set; }
        public string ind_value1
        {
            get { return _ind_value1; }
            set
            {
                if (_ind_value1 != value)
                {
                    _ind_value1 = value; RaisePropertyChanged("ind_value1");
                }
            }
        }
        private double? _up_limit { get; set; }
        public double? up_limit
        {
            get { return _up_limit; }
            set
            {
                if (_up_limit != value)
                {
                    _up_limit = value; RaisePropertyChanged("up_limit");
                }
            }
        }
        private string _ind_value2 { get; set; }
        public string ind_value2
        {
            get { return _ind_value2; }
            set
            {
                if (_ind_value2 != value)
                {
                    _ind_value2 = value; RaisePropertyChanged("ind_value2");
                }
            }
        }
        private string _unit_code { get; set; }
        public string unit_code
        {
            get { return _unit_code; }
            set
            {
                if (_unit_code != value)
                {
                    _unit_code = value; RaisePropertyChanged("unit_code");
                }
            }
        }
        private string _ind_counter { get; set; }
        public string ind_counter
        {
            get { return _ind_counter; }
            set
            {
                if (_ind_counter != value)
                {
                    _ind_counter = value; RaisePropertyChanged("ind_counter");
                }
            }
        }
        private string _ind_back { get; set; }
        public string ind_back
        {
            get { return _ind_back; }
            set
            {
                if (_ind_back != value)
                {
                    _ind_back = value; RaisePropertyChanged("ind_back");
                }
            }
        }
        private string _ind_transfer { get; set; }
        public string ind_transfer
        {
            get { return _ind_transfer; }
            set
            {
                if (_ind_transfer != value)
                {
                    _ind_transfer = value; RaisePropertyChanged("ind_transfer");
                }
            }
        }
        private string _mp_no_t { get; set; }
        public string mp_no_t
        {
            get { return _mp_no_t; }
            set
            {
                if (_mp_no_t != value)
                {
                    _mp_no_t = value; RaisePropertyChanged("mp_no_t");
                }
            }
        }
        private double? _overflow { get; set; }
        public double? overflow
        {
            get { return _overflow; }
            set
            {
                if (_overflow != value)
                {
                    _overflow = value; RaisePropertyChanged("overflow");
                }
            }
        }
        private string _ind_value3 { get; set; }
        public string ind_value3
        {
            get { return _ind_value3; }
            set
            {
                if (_ind_value3 != value)
                {
                    _ind_value3 = value; RaisePropertyChanged("ind_value3");
                }
            }
        }
        private double? _anual_value { get; set; }
        public double? anual_value
        {
            get { return _anual_value; }
            set
            {
                if (_anual_value != value)
                {
                    _anual_value = value; RaisePropertyChanged("anual_value");
                }
            }
        }
        private string _ind_value4 { get; set; }
        public string ind_value4
        {
            get { return _ind_value4; }
            set
            {
                if (_ind_value4 != value)
                {
                    _ind_value4 = value; RaisePropertyChanged("ind_value4");
                }
            }
        }
        private string _cat_type { get; set; }
        public string cat_type
        {
            get { return _cat_type; }
            set
            {
                if (_cat_type != value)
                {
                    _cat_type = value; RaisePropertyChanged("cat_type");
                }
            }
        }
        private string _cat_group { get; set; }
        public string cat_group
        {
            get { return _cat_group; }
            set
            {
                if (_cat_group != value)
                {
                    _cat_group = value; RaisePropertyChanged("cat_group");
                }
            }
        }
        private string _ind_cat { get; set; }
        public string ind_cat
        {
            get { return _ind_cat; }
            set
            {
                if (_ind_cat != value)
                {
                    _ind_cat = value; RaisePropertyChanged("ind_cat");
                }
            }
        }
        private string _ind_suf { get; set; }
        public string ind_suf
        {
            get { return _ind_suf; }
            set
            {
                if (_ind_suf != value)
                {
                    _ind_suf = value; RaisePropertyChanged("ind_suf");
                }
            }
        }
        private string _tr_mode { get; set; }
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
        private string _ind_mode { get; set; }
        public string ind_mode
        {
            get { return _ind_mode; }
            set
            {
                if (_ind_mode != value)
                {
                    _ind_mode = value; RaisePropertyChanged("ind_mode");
                }
            }
        }
        private string _active { get; set; }
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
        private string _t_status { get; set; }
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

        //Scalar
        private string _obj_name { get; set; }
        public string obj_name
        {
            get { return _obj_name; }
            set
            {
                if (_obj_name != value)
                {
                    _obj_name = value; RaisePropertyChanged("obj_name");
                }
            }
        }
        private string _char_name { get; set; }
        public string char_name
        {
            get { return _char_name; }
            set
            {
                if (_char_name != value)
                {
                    _char_name = value; RaisePropertyChanged("char_name");
                }
            }
        }
        private string _long_text { get; set; }
        public string long_text
        {
            get { return _long_text; }
            set
            {
                if (_long_text != value)
                {
                    _long_text = value; RaisePropertyChanged("long_text");
                }
            }
        }
        public string XDOC_A { get; set; }

    }
}
