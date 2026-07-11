using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Reflection.BusinessEntity.ReflectionSystem;

namespace Reflection.BusinessEntity.Production
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
                _bom_cat = value;
                RaisePropertyChanged("bom_cat");
            }
        }

        private int? _bom_item_node_no;
        public int? bom_item_node_no
        {
            get { return _bom_item_node_no; }
            set
            {
                _bom_item_node_no = value;
                RaisePropertyChanged("bom_item_node_no");
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

        private DateTime? _valid_to { get; set; }
        public DateTime? valid_to
        {
            get { return _valid_to; }
            set
            {
                _valid_to = value;
                RaisePropertyChanged("valid_to");
            }
        }

        private string _change_no;
        public string change_no
        {
            get { return _change_no; }
            set
            {
                _change_no = value;
                RaisePropertyChanged("change_no");
            }
        }

        private string _parent_node;
        public string parent_node
        {
            get { return _parent_node; }
            set
            {
                _parent_node = value;
                RaisePropertyChanged("parent_node");
            }
        }

        private int? _previous_counter;
        public int? previous_counter
        {
            get { return _previous_counter; }
            set
            {
                _previous_counter = value;
                RaisePropertyChanged("previous_counter");
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

        private string _issuing_plant;
        public string issuing_plant
        {
            get { return _issuing_plant; }
            set
            {
                _issuing_plant = value;
                RaisePropertyChanged("issuing_plant");
            }
        }

        private string _line_cat;
        public string line_cat
        {
            get { return _line_cat; }
            set
            {
                _line_cat = value;
                RaisePropertyChanged("line_cat");
            }
        }

        private int? _bom_item_no;
        public int? bom_item_no
        {
            get { return _bom_item_no; }
            set
            {
                _bom_item_no = value;
                RaisePropertyChanged("bom_item_no");
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

        private string _fixed_qty;
        public string fixed_qty
        {
            get { return _fixed_qty; }
            set
            {
                _fixed_qty = value;
                RaisePropertyChanged("fixed_qty");
            }
        }

        private decimal? _component_scrap;
        public decimal? component_scrap
        {
            get { return _component_scrap; }
            set
            {
                _component_scrap = value;
                RaisePropertyChanged("component_scrap");
            }
        }

        private decimal? _operation_scrap;
        public decimal? operation_scrap
        {
            get { return _operation_scrap; }
            set
            {
                _operation_scrap = value;
                RaisePropertyChanged("operation_scrap");
            }
        }

        private string _ind_net_scrap;
        public string ind_net_scrap
        {
            get { return _ind_net_scrap; }
            set
            {
                _ind_net_scrap = value;
                RaisePropertyChanged("ind_net_scrap");
            }
        }

        private string _ind_item_prd;
        public string ind_item_prd
        {
            get { return _ind_item_prd; }
            set
            {
                _ind_item_prd = value;
                RaisePropertyChanged("ind_item_prd");
            }
        }

        private string _ind_item_sales;
        public string ind_item_sales
        {
            get { return _ind_item_sales; }
            set
            {
                _ind_item_sales = value;
                RaisePropertyChanged("ind_item_sales");
            }
        }

        private string _ind_plant;
        public string ind_plant
        {
            get { return _ind_plant; }
            set
            {
                _ind_plant = value;
                RaisePropertyChanged("ind_plant");
            }
        }

        private string _ind_costing;
        public string ind_costing
        {
            get { return _ind_costing; }
            set
            {
                _ind_costing = value;
                RaisePropertyChanged("ind_costing");
            }
        }

        private string _ind_engg;
        public string ind_engg
        {
            get { return _ind_engg; }
            set
            {
                _ind_engg = value;
                RaisePropertyChanged("ind_engg");
            }
        }

        private string _ind_recursive;
        public string ind_recursive
        {
            get { return _ind_recursive; }
            set
            {
                _ind_recursive = value;
                RaisePropertyChanged("ind_recursive");
            }
        }

        private string _ind_recursive_allowed;
        public string ind_recursive_allowed
        {
            get { return _ind_recursive_allowed; }
            set
            {
                _ind_recursive_allowed = value;
                RaisePropertyChanged("ind_recursive_allowed");
            }
        }

        private string _ind_alternative_item;
        public string ind_alternative_item
        {
            get { return _ind_alternative_item; }
            set
            {
                _ind_alternative_item = value;
                RaisePropertyChanged("ind_alternative_item");
            }
        }

        private string _ind_subitem_exit;
        public string ind_subitem_exit
        {
            get { return _ind_subitem_exit; }
            set
            {
                _ind_subitem_exit = value;
                RaisePropertyChanged("ind_subitem_exit");
            }
        }

        private string _item_code_alt;
        public string item_code_alt
        {
            get { return _item_code_alt; }
            set
            {
                _item_code_alt = value;
                RaisePropertyChanged("item_code_alt");
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

        private string _ref_revision_no;
        public string ref_revision_no
        {
            get { return _ref_revision_no; }
            set
            {
                _ref_revision_no = value;
                RaisePropertyChanged("ref_revision_no");
            }
        }

        private string _ind_pm_assembly;
        public string ind_pm_assembly
        {
            get { return _ind_pm_assembly; }
            set
            {
                _ind_pm_assembly = value;
                RaisePropertyChanged("ind_pm_assembly");
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
                _location_id = value;
                RaisePropertyChanged("location_id");
            }
        }

        private string _sku;
        public string sku
        {
            get { return _sku; }
            set { _sku = value; RaisePropertyChanged("sku"); }
        }

        private string _sku_desc;
        public string sku_desc
        {
            get { return _sku_desc; }
            set { _sku_desc = value; RaisePropertyChanged("sku_desc"); }
        }

        private string _info1;
        public string info1
        {
            get { return _info1; }
            set { _info1 = value; RaisePropertyChanged("info1"); }

        }

        private string _info2;
        public string info2
        {
            get { return _info2; }
            set { _info2 = value; RaisePropertyChanged("info2"); }
        }

        private string _info3;
        public string info3
        {
            get { return _info3; }
            set { _info3 = value; RaisePropertyChanged("info3"); }
        }

        private decimal? _con_qty;
        public decimal? con_qty
        {
            get { return _con_qty; }
            set
            {
                _con_qty = value;
                RaisePropertyChanged("con_qty");
            }
        }

        private string _con_uom;
        public string con_uom
        {
            get { return _con_uom; }
            set { _con_uom = value; RaisePropertyChanged("con_uom"); }
        }

        private decimal? _per_qty;
        public decimal? per_qty
        {
            get { return _per_qty; }
            set
            {
                _per_qty = value;
                RaisePropertyChanged("per_qty");
            }
        }

        private string _per_uom;
        public string per_uom
        {
            get { return _per_uom; }
            set { _per_uom = value; RaisePropertyChanged("per_uom"); }
        }

        private string _ind_usage;
        public string ind_usage
        {
            get { return _ind_usage; }
            set { _ind_usage = value; RaisePropertyChanged("ind_usage"); }
        }

        private string _ind_base;
        public string ind_base
        {
            get { return _ind_base; }
            set { _ind_base = value; RaisePropertyChanged("ind_base"); }
        }

        private int? _line_id;
        public int? line_id
        {
            get { return _line_id; }
            set { _line_id = value; RaisePropertyChanged("line_id"); }
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
            set { _item_name_alt = value; RaisePropertyChanged("item_name_alt"); }
        }
    }
    
}
