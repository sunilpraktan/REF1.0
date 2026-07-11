using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessEntity.MM
{
    public class MM_T005 : ObjectBase
    {
        private string _comp_code { get; set; }
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
        private string _doc_no { get; set; }
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                if (_doc_no != value)
                {
                    _doc_no = value; RaisePropertyChanged("doc_no");
                }
            }
        }
        private int? _res_no { get; set; }
        public int? res_no
        {
            get { return _res_no; }
            set
            {
                if (_res_no != value)
                {
                    _res_no = value; RaisePropertyChanged("res_no");
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
        private DateTime? _doc_date { get; set; }
        public DateTime? doc_date
        {
            get { return _doc_date; }
            set
            {
                if (_doc_date != value)
                {
                    _doc_date = value; RaisePropertyChanged("doc_date");
                }
            }
        }
        private string _doc_cat { get; set; }
        public string doc_cat
        {
            get { return _doc_cat; }
            set
            {
                if (_doc_cat != value)
                {
                    _doc_cat = value; RaisePropertyChanged("doc_cat");
                }
            }
        }
        private string _doc_type { get; set; }
        public string doc_type
        {
            get { return _doc_type; }
            set
            {
                if (_doc_type != value)
                {
                    _doc_type = value; RaisePropertyChanged("doc_type");
                }
            }
        }
        private string _ref_doc_cat { get; set; }
        public string ref_doc_cat
        {
            get { return _ref_doc_cat; }
            set
            {
                if (_ref_doc_cat != value)
                {
                    _ref_doc_cat = value; RaisePropertyChanged("ref_doc_cat");
                }
            }
        }
        private string _ref_doc_type { get; set; }
        public string ref_doc_type
        {
            get { return _ref_doc_type; }
            set
            {
                if (_ref_doc_type != value)
                {
                    _ref_doc_type = value; RaisePropertyChanged("ref_doc_type");
                }
            }
        }
        private string _ref_doc_no { get; set; }
        public string ref_doc_no
        {
            get { return _ref_doc_no; }
            set
            {
                if (_ref_doc_no != value)
                {
                    _ref_doc_no = value; RaisePropertyChanged("ref_doc_no");
                }
            }
        }
        private int? _ref_item_row_id { get; set; }
        public int? ref_item_row_id
        {
            get { return _ref_item_row_id; }
            set
            {
                if (_ref_item_row_id != value)
                {
                    _ref_item_row_id = value; RaisePropertyChanged("ref_item_row_id");
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
        private string _order_no { get; set; }
        public string order_no
        {
            get { return _order_no; }
            set
            {
                if (_order_no != value)
                {
                    _order_no = value; RaisePropertyChanged("order_no");
                }
            }
        }
        private int? _order_item_row_id { get; set; }
        public int? order_item_row_id
        {
            get { return _order_item_row_id; }
            set
            {
                if (_order_item_row_id != value)
                {
                    _order_item_row_id = value; RaisePropertyChanged("order_item_row_id");
                }
            }
        }
        private string _rec_type { get; set; }
        public string rec_type
        {
            get { return _rec_type; }
            set
            {
                if (_rec_type != value)
                {
                    _rec_type = value; RaisePropertyChanged("rec_type");
                }
            }
        }
        private string _res_type { get; set; }
        public string res_type
        {
            get { return _res_type; }
            set
            {
                if (_res_type != value)
                {
                    _res_type = value; RaisePropertyChanged("res_type");
                }
            }
        }
        private string _origin { get; set; }
        public string origin
        {
            get { return _origin; }
            set
            {
                if (_origin != value)
                {
                    _origin = value; RaisePropertyChanged("origin");
                }
            }
        }
        private DateTime? _res_date { get; set; }
        public DateTime? res_date
        {
            get { return _res_date; }
            set
            {
                if (_res_date != value)
                {
                    _res_date = value; RaisePropertyChanged("res_date");
                }
            }
        }
        private string _mov_tp { get; set; }
        public string mov_tp
        {
            get { return _mov_tp; }
            set
            {
                if (_mov_tp != value)
                {
                    _mov_tp = value; RaisePropertyChanged("mov_tp");
                }
            }
        }
        private string _recipient { get; set; }
        public string recipient
        {
            get { return _recipient; }
            set
            {
                if (_recipient != value)
                {
                    _recipient = value; RaisePropertyChanged("recipient");
                }
            }
        }
        private string _cc_code { get; set; }
        public string cc_code
        {
            get { return _cc_code; }
            set
            {
                if (_cc_code != value)
                {
                    _cc_code = value; RaisePropertyChanged("cc_code");
                }
            }
        }
        private string _pc_code { get; set; }
        public string pc_code
        {
            get { return _pc_code; }
            set
            {
                if (_pc_code != value)
                {
                    _pc_code = value; RaisePropertyChanged("pc_code");
                }
            }
        }
        private string _project_id { get; set; }
        public string project_id
        {
            get { return _project_id; }
            set
            {
                if (_project_id != value)
                {
                    _project_id = value; RaisePropertyChanged("project_id");
                }
            }
        }
        private string _element_id { get; set; }
        public string element_id
        {
            get { return _element_id; }
            set
            {
                if (_element_id != value)
                {
                    _element_id = value; RaisePropertyChanged("element_id");
                }
            }
        }
        private string _asset_no { get; set; }
        public string asset_no
        {
            get { return _asset_no; }
            set
            {
                if (_asset_no != value)
                {
                    _asset_no = value; RaisePropertyChanged("asset_no");
                }
            }
        }
        private string _sub_asset_no { get; set; }
        public string sub_asset_no
        {
            get { return _sub_asset_no; }
            set
            {
                if (_sub_asset_no != value)
                {
                    _sub_asset_no = value; RaisePropertyChanged("sub_asset_no");
                }
            }
        }
        private string _customer { get; set; }
        public string customer
        {
            get { return _customer; }
            set
            {
                if (_customer != value)
                {
                    _customer = value; RaisePropertyChanged("customer");
                }
            }
        }
        private string _po_no { get; set; }
        public string po_no
        {
            get { return _po_no; }
            set
            {
                if (_po_no != value)
                {
                    _po_no = value; RaisePropertyChanged("po_no");
                }
            }
        }
        private int? _po_item_row_id { get; set; }
        public int? po_item_row_id
        {
            get { return _po_item_row_id; }
            set
            {
                if (_po_item_row_id != value)
                {
                    _po_item_row_id = value; RaisePropertyChanged("po_item_row_id");
                }
            }
        }
        private string _so_no { get; set; }
        public string so_no
        {
            get { return _so_no; }
            set
            {
                if (_so_no != value)
                {
                    _so_no = value; RaisePropertyChanged("so_no");
                }
            }
        }
        private int? _so_item_row_id { get; set; }
        public int? so_item_row_id
        {
            get { return _so_item_row_id; }
            set
            {
                if (_so_item_row_id != value)
                {
                    _so_item_row_id = value; RaisePropertyChanged("so_item_row_id");
                }
            }
        }
        private int? _sch_item_row_id { get; set; }
        public int? sch_item_row_id
        {
            get { return _sch_item_row_id; }
            set
            {
                if (_sch_item_row_id != value)
                {
                    _sch_item_row_id = value; RaisePropertyChanged("sch_item_row_id");
                }
            }
        }
        private string _plant { get; set; }
        public string plant
        {
            get { return _plant; }
            set
            {
                if (_plant != value)
                {
                    _plant = value; RaisePropertyChanged("plant");
                }
            }
        }
        private string _store_code { get; set; }
        public string store_code
        {
            get { return _store_code; }
            set
            {
                if (_store_code != value)
                {
                    _store_code = value; RaisePropertyChanged("store_code");
                }
            }
        }
        private string _bom_exp_no { get; set; }
        public string bom_exp_no
        {
            get { return _bom_exp_no; }
            set
            {
                if (_bom_exp_no != value)
                {
                    _bom_exp_no = value; RaisePropertyChanged("bom_exp_no");
                }
            }
        }
        private string _comp_code_clr { get; set; }
        public string comp_code_clr
        {
            get { return _comp_code_clr; }
            set
            {
                if (_comp_code_clr != value)
                {
                    _comp_code_clr = value; RaisePropertyChanged("comp_code_clr");
                }
            }
        }
        private int? _routing_op_row_id { get; set; }
        public int? routing_op_row_id
        {
            get { return _routing_op_row_id; }
            set
            {
                if (_routing_op_row_id != value)
                {
                    _routing_op_row_id = value; RaisePropertyChanged("routing_op_row_id");
                }
            }
        }
        private int? _int_counter { get; set; }
        public int? int_counter
        {
            get { return _int_counter; }
            set
            {
                if (_int_counter != value)
                {
                    _int_counter = value; RaisePropertyChanged("int_counter");
                }
            }
        }
        private string _party_code { get; set; }
        public string party_code
        {
            get { return _party_code; }
            set
            {
                if (_party_code != value)
                {
                    _party_code = value; RaisePropertyChanged("party_code");
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


        //Scalar
        private string _rec_type_name { get; set; }
        public string rec_type_name
        {
            get { return _rec_type_name; }
            set
            {
                if (_rec_type_name != value)
                {
                    _rec_type_name = value; RaisePropertyChanged("rec_type_name");
                }
            }
        }
        private string _res_type_name { get; set; }
        public string res_type_name
        {
            get { return _res_type_name; }
            set
            {
                if (_res_type_name != value)
                {
                    _res_type_name = value; RaisePropertyChanged("res_type_name");
                }
            }
        }
        private string _origin_name { get; set; }
        public string origin_name
        {
            get { return _origin_name; }
            set
            {
                if (_origin_name != value)
                {
                    _origin_name = value; RaisePropertyChanged("origin_name");
                }
            }
        }
        private string _mov_type_name { get; set; }
        public string mov_type_name
        {
            get { return _mov_type_name; }
            set
            {
                if (_mov_type_name != value)
                {
                    _mov_type_name = value; RaisePropertyChanged("mov_type_name");
                }
            }
        }
        private string _recipient_name { get; set; }
        public string recipient_name
        {
            get { return _recipient_name; }
            set
            {
                if (_recipient_name != value)
                {
                    _recipient_name = value; RaisePropertyChanged("recipient_name");
                }
            }
        }
        private string _cc_name { get; set; }
        public string cc_name
        {
            get { return _cc_name; }
            set
            {
                if (_cc_name != value)
                {
                    _cc_name = value; RaisePropertyChanged("cc_name");
                }
            }
        }
        private string _pc_name { get; set; }
        public string pc_name
        {
            get { return _pc_name; }
            set
            {
                if (_pc_name != value)
                {
                    _pc_name = value; RaisePropertyChanged("pc_name");
                }
            }
        }
        private string _project_name { get; set; }
        public string project_name
        {
            get { return _project_name; }
            set
            {
                if (_project_name != value)
                {
                    _project_name = value; RaisePropertyChanged("project_name");
                }
            }
        }
        private string _element_name { get; set; }
        public string element_name
        {
            get { return _element_name; }
            set
            {
                if (_element_name != value)
                {
                    _element_name = value; RaisePropertyChanged("element_name");
                }
            }
        }
        private string _asset_name { get; set; }
        public string asset_name
        {
            get { return _asset_name; }
            set
            {
                if (_asset_name != value)
                {
                    _asset_name = value; RaisePropertyChanged("asset_name");
                }
            }
        }
        private string _sub_asset_name { get; set; }
        public string sub_asset_name
        {
            get { return _sub_asset_name; }
            set
            {
                if (_sub_asset_name != value)
                {
                    _sub_asset_name = value; RaisePropertyChanged("sub_asset_name");
                }
            }
        }
        private string _customer_name { get; set; }
        public string customer_name
        {
            get { return _customer_name; }
            set
            {
                if (_customer_name != value)
                {
                    _customer_name = value; RaisePropertyChanged("customer_name");
                }
            }
        }
        private string _supplier_name { get; set; }
        public string supplier_name
        {
            get { return _supplier_name; }
            set
            {
                if (_supplier_name != value)
                {
                    _supplier_name = value; RaisePropertyChanged("supplier_name");
                }
            }
        }
        private string _t_display { get; set; }
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
        private string _party_name { get; set; }
        public string party_name
        {
            get { return _party_name; }
            set
            {
                if (_party_name != value)
                {
                    _party_name = value; RaisePropertyChanged("party_name");
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
        public string XDOC_B { get; set; }

    }

    public class MM_T005_A : ObjectBase
    {
        private int? _id { get; set; }
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
        private string _comp_code { get; set; }
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
        private string _doc_no { get; set; }
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                if (_doc_no != value)
                {
                    _doc_no = value; RaisePropertyChanged("doc_no");
                }
            }
        }
        private int? _res_no { get; set; }
        public int? res_no
        {
            get { return _res_no; }
            set
            {
                if (_res_no != value)
                {
                    _res_no = value; RaisePropertyChanged("res_no");
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
        private int? _line_id { get; set; }
        public int? line_id
        {
            get { return _line_id; }
            set
            {
                if (_line_id != value)
                {
                    _line_id = value; RaisePropertyChanged("line_id");
                }
            }
        }
        private string _rec_type { get; set; }
        public string rec_type
        {
            get { return _rec_type; }
            set
            {
                if (_rec_type != value)
                {
                    _rec_type = value; RaisePropertyChanged("rec_type");
                }
            }
        }
        private string _res_type { get; set; }
        public string res_type
        {
            get { return _res_type; }
            set
            {
                if (_res_type != value)
                {
                    _res_type = value; RaisePropertyChanged("res_type");
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
        private string _item_code { get; set; }
        public string item_code
        {
            get { return _item_code; }
            set
            {
                if (_item_code != value)
                {
                    _item_code = value; RaisePropertyChanged("item_code");
                }
            }
        }
        private string _sku { get; set; }
        public string sku
        {
            get { return _sku; }
            set
            {
                if (_sku != value)
                {
                    _sku = value; RaisePropertyChanged("sku");
                }
            }
        }
        private string _store_code { get; set; }
        public string store_code
        {
            get { return _store_code; }
            set
            {
                if (_store_code != value)
                {
                    _store_code = value; RaisePropertyChanged("store_code");
                }
            }
        }
        private string _batch_no { get; set; }
        public string batch_no
        {
            get { return _batch_no; }
            set
            {
                if (_batch_no != value)
                {
                    _batch_no = value; RaisePropertyChanged("batch_no");
                }
            }
        }
        private DateTime? _req_date { get; set; }
        public DateTime? req_date
        {
            get { return _req_date; }
            set
            {
                if (_req_date != value)
                {
                    _req_date = value; RaisePropertyChanged("req_date");
                }
            }
        }
        private decimal? _qty { get; set; }
        public decimal? qty
        {
            get { return _qty; }
            set
            {
                if (_qty != value)
                {
                    _qty = value; RaisePropertyChanged("qty");
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
        private string _ind_dc { get; set; }
        public string ind_dc
        {
            get { return _ind_dc; }
            set
            {
                if (_ind_dc != value)
                {
                    _ind_dc = value; RaisePropertyChanged("ind_dc");
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
                    _curr_code = value; RaisePropertyChanged("curr_code");
                }
            }
        }
        private string _plan_order_no { get; set; }
        public string plan_order_no
        {
            get { return _plan_order_no; }
            set
            {
                if (_plan_order_no != value)
                {
                    _plan_order_no = value; RaisePropertyChanged("plan_order_no");
                }
            }
        }
        private string _pr_no { get; set; }
        public string pr_no
        {
            get { return _pr_no; }
            set
            {
                if (_pr_no != value)
                {
                    _pr_no = value; RaisePropertyChanged("pr_no");
                }
            }
        }
        private int? _pr_item_row_id { get; set; }
        public int? pr_item_row_id
        {
            get { return _pr_item_row_id; }
            set
            {
                if (_pr_item_row_id != value)
                {
                    _pr_item_row_id = value; RaisePropertyChanged("pr_item_row_id");
                }
            }
        }
        private string _order_no { get; set; }
        public string order_no
        {
            get { return _order_no; }
            set
            {
                if (_order_no != value)
                {
                    _order_no = value; RaisePropertyChanged("order_no");
                }
            }
        }
        private int? _order_item_row_id { get; set; }
        public int? order_item_row_id
        {
            get { return _order_item_row_id; }
            set
            {
                if (_order_item_row_id != value)
                {
                    _order_item_row_id = value; RaisePropertyChanged("order_item_row_id");
                }
            }
        }
        private string _item_code_hl { get; set; }
        public string item_code_hl
        {
            get { return _item_code_hl; }
            set
            {
                if (_item_code_hl != value)
                {
                    _item_code_hl = value; RaisePropertyChanged("item_code_hl");
                }
            }
        }
        private string _bom_exp_no { get; set; }
        public string bom_exp_no
        {
            get { return _bom_exp_no; }
            set
            {
                if (_bom_exp_no != value)
                {
                    _bom_exp_no = value; RaisePropertyChanged("bom_exp_no");
                }
            }
        }
        private string _po_no { get; set; }
        public string po_no
        {
            get { return _po_no; }
            set
            {
                if (_po_no != value)
                {
                    _po_no = value; RaisePropertyChanged("po_no");
                }
            }
        }
        private int? _po_item_row_id { get; set; }
        public int? po_item_row_id
        {
            get { return _po_item_row_id; }
            set
            {
                if (_po_item_row_id != value)
                {
                    _po_item_row_id = value; RaisePropertyChanged("po_item_row_id");
                }
            }
        }
        private string _so_no { get; set; }
        public string so_no
        {
            get { return _so_no; }
            set
            {
                if (_so_no != value)
                {
                    _so_no = value; RaisePropertyChanged("so_no");
                }
            }
        }
        private int? _so_item_row_id { get; set; }
        public int? so_item_row_id
        {
            get { return _so_item_row_id; }
            set
            {
                if (_so_item_row_id != value)
                {
                    _so_item_row_id = value; RaisePropertyChanged("so_item_row_id");
                }
            }
        }
        private int? _sch_item_row_id { get; set; }
        public int? sch_item_row_id
        {
            get { return _sch_item_row_id; }
            set
            {
                if (_sch_item_row_id != value)
                {
                    _sch_item_row_id = value; RaisePropertyChanged("sch_item_row_id");
                }
            }
        }
        private string _mov_tp { get; set; }
        public string mov_tp
        {
            get { return _mov_tp; }
            set
            {
                if (_mov_tp != value)
                {
                    _mov_tp = value; RaisePropertyChanged("mov_tp");
                }
            }
        }
        private string _project_id { get; set; }
        public string project_id
        {
            get { return _project_id; }
            set
            {
                if (_project_id != value)
                {
                    _project_id = value; RaisePropertyChanged("project_id");
                }
            }
        }
        private string _element_id { get; set; }
        public string element_id
        {
            get { return _element_id; }
            set
            {
                if (_element_id != value)
                {
                    _element_id = value; RaisePropertyChanged("element_id");
                }
            }
        }
        private string _plant { get; set; }
        public string plant
        {
            get { return _plant; }
            set
            {
                if (_plant != value)
                {
                    _plant = value; RaisePropertyChanged("plant");
                }
            }
        }
        private string _store_code1 { get; set; }
        public string store_code1
        {
            get { return _store_code1; }
            set
            {
                if (_store_code1 != value)
                {
                    _store_code1 = value; RaisePropertyChanged("store_code1");
                }
            }
        }
        private string _item_cat { get; set; }
        public string item_cat
        {
            get { return _item_cat; }
            set
            {
                if (_item_cat != value)
                {
                    _item_cat = value; RaisePropertyChanged("item_cat");
                }
            }
        }
        private string _bom_no { get; set; }
        public string bom_no
        {
            get { return _bom_no; }
            set
            {
                if (_bom_no != value)
                {
                    _bom_no = value; RaisePropertyChanged("bom_no");
                }
            }
        }
        private int? _bom_item_row_id { get; set; }
        public int? bom_item_row_id
        {
            get { return _bom_item_row_id; }
            set
            {
                if (_bom_item_row_id != value)
                {
                    _bom_item_row_id = value; RaisePropertyChanged("bom_item_row_id");
                }
            }
        }
        private string _bom_cat { get; set; }
        public string bom_cat
        {
            get { return _bom_cat; }
            set
            {
                if (_bom_cat != value)
                {
                    _bom_cat = value; RaisePropertyChanged("bom_cat");
                }
            }
        }
        private int? _int_counter { get; set; }
        public int? int_counter
        {
            get { return _int_counter; }
            set
            {
                if (_int_counter != value)
                {
                    _int_counter = value; RaisePropertyChanged("int_counter");
                }
            }
        }
        private string _bom_item_text { get; set; }
        public string bom_item_text
        {
            get { return _bom_item_text; }
            set
            {
                if (_bom_item_text != value)
                {
                    _bom_item_text = value; RaisePropertyChanged("bom_item_text");
                }
            }
        }
        private string _ind_costing { get; set; }
        public string ind_costing
        {
            get { return _ind_costing; }
            set
            {
                if (_ind_costing != value)
                {
                    _ind_costing = value; RaisePropertyChanged("ind_costing");
                }
            }
        }
        private string _ind_alt { get; set; }
        public string ind_alt
        {
            get { return _ind_alt; }
            set
            {
                if (_ind_alt != value)
                {
                    _ind_alt = value; RaisePropertyChanged("ind_alt");
                }
            }
        }
        private string _ind_cp { get; set; }
        public string ind_cp
        {
            get { return _ind_cp; }
            set
            {
                if (_ind_cp != value)
                {
                    _ind_cp = value; RaisePropertyChanged("ind_cp");
                }
            }
        }
        private string _ind_backflush { get; set; }
        public string ind_backflush
        {
            get { return _ind_backflush; }
            set
            {
                if (_ind_backflush != value)
                {
                    _ind_backflush = value; RaisePropertyChanged("ind_backflush");
                }
            }
        }
        private string _ind_config { get; set; }
        public string ind_config
        {
            get { return _ind_config; }
            set
            {
                if (_ind_config != value)
                {
                    _ind_config = value; RaisePropertyChanged("ind_config");
                }
            }
        }
        private string _ind_external { get; set; }
        public string ind_external
        {
            get { return _ind_external; }
            set
            {
                if (_ind_external != value)
                {
                    _ind_external = value; RaisePropertyChanged("ind_external");
                }
            }
        }
        private decimal? _scrap_comp { get; set; }
        public decimal? scrap_comp
        {
            get { return _scrap_comp; }
            set
            {
                if (_scrap_comp != value)
                {
                    _scrap_comp = value; RaisePropertyChanged("scrap_comp");
                }
            }
        }
        private decimal? _scrap_op { get; set; }
        public decimal? scrap_op
        {
            get { return _scrap_op; }
            set
            {
                if (_scrap_op != value)
                {
                    _scrap_op = value; RaisePropertyChanged("scrap_op");
                }
            }
        }
        private string _pro_doc_no { get; set; }
        public string pro_doc_no
        {
            get { return _pro_doc_no; }
            set
            {
                if (_pro_doc_no != value)
                {
                    _pro_doc_no = value; RaisePropertyChanged("pro_doc_no");
                }
            }
        }
        private int? _pro_item_row_id { get; set; }
        public int? pro_item_row_id
        {
            get { return _pro_item_row_id; }
            set
            {
                if (_pro_item_row_id != value)
                {
                    _pro_item_row_id = value; RaisePropertyChanged("pro_item_row_id");
                }
            }
        }
        private int? _psch_item_row_id { get; set; }
        public int? psch_item_row_id
        {
            get { return _psch_item_row_id; }
            set
            {
                if (_psch_item_row_id != value)
                {
                    _psch_item_row_id = value; RaisePropertyChanged("psch_item_row_id");
                }
            }
        }
        private int? _op_row_id { get; set; }
        public int? op_row_id
        {
            get { return _op_row_id; }
            set
            {
                if (_op_row_id != value)
                {
                    _op_row_id = value; RaisePropertyChanged("op_row_id");
                }
            }
        }
        private int? _op_seq { get; set; }
        public int? op_seq
        {
            get { return _op_seq; }
            set
            {
                if (_op_seq != value)
                {
                    _op_seq = value; RaisePropertyChanged("op_seq");
                }
            }
        }
        private string _op_no { get; set; }
        public string op_no
        {
            get { return _op_no; }
            set
            {
                if (_op_no != value)
                {
                    _op_no = value; RaisePropertyChanged("op_no");
                }
            }
        }
        private int? _counter { get; set; }
        public int? counter
        {
            get { return _counter; }
            set
            {
                if (_counter != value)
                {
                    _counter = value; RaisePropertyChanged("counter");
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
        private string _seq_cat { get; set; }
        public string seq_cat
        {
            get { return _seq_cat; }
            set
            {
                if (_seq_cat != value)
                {
                    _seq_cat = value; RaisePropertyChanged("seq_cat");
                }
            }
        }
        private decimal? _unit_price { get; set; }
        public decimal? unit_price
        {
            get { return _unit_price; }
            set
            {
                if (_unit_price != value)
                {
                    _unit_price = value; RaisePropertyChanged("unit_price");
                }
            }
        }
        private string _price_uom { get; set; }
        public string price_uom
        {
            get { return _price_uom; }
            set
            {
                if (_price_uom != value)
                {
                    _price_uom = value; RaisePropertyChanged("price_uom");
                }
            }
        }
        private string _pg_code { get; set; }
        public string pg_code
        {
            get { return _pg_code; }
            set
            {
                if (_pg_code != value)
                {
                    _pg_code = value; RaisePropertyChanged("pg_code");
                }
            }
        }
        private decimal? _delivery { get; set; }
        public decimal? delivery
        {
            get { return _delivery; }
            set
            {
                if (_delivery != value)
                {
                    _delivery = value; RaisePropertyChanged("delivery");
                }
            }
        }
        private string _rev_level { get; set; }
        public string rev_level
        {
            get { return _rev_level; }
            set
            {
                if (_rev_level != value)
                {
                    _rev_level = value; RaisePropertyChanged("rev_level");
                }
            }
        }
        private string _wh_code { get; set; }
        public string wh_code
        {
            get { return _wh_code; }
            set
            {
                if (_wh_code != value)
                {
                    _wh_code = value; RaisePropertyChanged("wh_code");
                }
            }
        }
        private string _store_type { get; set; }
        public string store_type
        {
            get { return _store_type; }
            set
            {
                if (_store_type != value)
                {
                    _store_type = value; RaisePropertyChanged("store_type");
                }
            }
        }
        private string _store_bin { get; set; }
        public string store_bin
        {
            get { return _store_bin; }
            set
            {
                if (_store_bin != value)
                {
                    _store_bin = value; RaisePropertyChanged("store_bin");
                }
            }
        }
        private int? _res_item_row_id { get; set; }
        public int? res_item_row_id
        {
            get { return _res_item_row_id; }
            set
            {
                if (_res_item_row_id != value)
                {
                    _res_item_row_id = value; RaisePropertyChanged("res_item_row_id");
                }
            }
        }
        private string _supplier { get; set; }
        public string supplier
        {
            get { return _supplier; }
            set
            {
                if (_supplier != value)
                {
                    _supplier = value; RaisePropertyChanged("supplier");
                }
            }
        }
        private decimal? _gr_time { get; set; }
        public decimal? gr_time
        {
            get { return _gr_time; }
            set
            {
                if (_gr_time != value)
                {
                    _gr_time = value; RaisePropertyChanged("gr_time");
                }
            }
        }
        private decimal? _amount { get; set; }
        public decimal? amount
        {
            get { return _amount; }
            set
            {
                if (_amount != value)
                {
                    _amount = value; RaisePropertyChanged("amount");
                }
            }
        }
        private string _bom_alt { get; set; }
        public string bom_alt
        {
            get { return _bom_alt; }
            set
            {
                if (_bom_alt != value)
                {
                    _bom_alt = value; RaisePropertyChanged("bom_alt");
                }
            }
        }
        private string _req_plan_no { get; set; }
        public string req_plan_no
        {
            get { return _req_plan_no; }
            set
            {
                if (_req_plan_no != value)
                {
                    _req_plan_no = value; RaisePropertyChanged("req_plan_no");
                }
            }
        }



        //Scalar
        private string _op_name { get; set; } // Operation Name
        public string op_name
        {
            get { return _op_name; }
            set
            {
                if (_op_name != value)
                {
                    _op_name = value; RaisePropertyChanged("op_name");
                }
            }
        }
        private string _obj_name { get; set; } // Object Name
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
        private string _mov_tp_name { get; set; }
        public string mov_tp_name
        {
            get { return _mov_tp_name; }
            set
            {
                if (_mov_tp_name != value)
                {
                    _mov_tp_name = value; RaisePropertyChanged("mov_tp_name");
                }
            }
        }
        private string _project_name { get; set; }
        public string project_name
        {
            get { return _project_name; }
            set
            {
                if (_project_name != value)
                {
                    _project_name = value; RaisePropertyChanged("project_name");
                }
            }
        }
        private string _element_name { get; set; }
        public string element_name
        {
            get { return _element_name; }
            set
            {
                if (_element_name != value)
                {
                    _element_name = value; RaisePropertyChanged("element_name");
                }
            }
        }
        private string _customer_name { get; set; }
        public string customer_name
        {
            get { return _customer_name; }
            set
            {
                if (_customer_name != value)
                {
                    _customer_name = value; RaisePropertyChanged("customer_name");
                }
            }
        }
        private string _supplier_name { get; set; }
        public string supplier_name
        {
            get { return _supplier_name; }
            set
            {
                if (_supplier_name != value)
                {
                    _supplier_name = value; RaisePropertyChanged("supplier_name");
                }
            }
        }
        private string _t_display { get; set; }
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
        private string _party_name { get; set; }
        public string party_name
        {
            get { return _party_name; }
            set
            {
                if (_party_name != value)
                {
                    _party_name = value; RaisePropertyChanged("party_name");
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

    }

    public class MM_T005_B : ObjectBase
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
            get
            {
                return _comp_code;
            }
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
        private string _wh_code;
        public string wh_code
        {
            get { return _wh_code; }
            set
            {
                _wh_code = value;
                RaisePropertyChanged("wh_code");
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
        private Nullable<int> _line_id { get; set; }
        public Nullable<int> line_id
        {
            get { return _line_id; }
            set { _line_id = value; RaisePropertyChanged("line_id"); }
        }
        private int? _item_row_id;
        public int? item_row_id
        {
            get { return _item_row_id; }
            set { _item_row_id = value; RaisePropertyChanged("item_row_id"); }
        }
        private int? _item_line_id;
        public int? item_line_id
        {
            get { return _item_line_id; }
            set { _item_line_id = value; RaisePropertyChanged("item_line_id"); }
        }
        private string _doc_no;
        public string doc_no
        {
            get
            {
                return _doc_no;
            }
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
        private string _sku;
        public string sku
        {
            get { return _sku; }
            set { _sku = value; RaisePropertyChanged("sku"); }
        }
        private string _batch_no;
        public string batch_no
        {
            get { return _batch_no; }
            set
            {
                _batch_no = value;
                RaisePropertyChanged("batch_no");
            }
        }
        private string _batch_no_v;
        public string batch_no_v
        {
            get { return _batch_no_v; }
            set
            {
                _batch_no_v = value;
                RaisePropertyChanged("batch_no_v");
            }
        }
        private string _barcode;
        public string barcode
        {
            get { return _barcode; }
            set
            {
                _barcode = value;
                RaisePropertyChanged("barcode");
            }
        }
        private string _pack_no;
        public string pack_no
        {
            get
            {
                return _pack_no;
            }
            set
            {
                _pack_no = value;
                RaisePropertyChanged("pack_no");
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
        private string _t_status;
        public string t_status
        {
            get
            {
                return _t_status;
            }

            set
            {
                _t_status = value;
                RaisePropertyChanged("t_status");
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

    }


    public class MM_T011 : ObjectBase
    {
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
        private int? _id { get; set; }
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
        private int? _op_row_id { get; set; }
        public int? op_row_id
        {
            get { return _op_row_id; }
            set
            {
                if (_op_row_id != value)
                {
                    _op_row_id = value; RaisePropertyChanged("op_row_id");
                }
            }
        }
        private int? _item_no { get; set; }
        public int? item_no
        {
            get { return _item_no; }
            set
            {
                if (_item_no != value)
                {
                    _item_no = value; RaisePropertyChanged("item_no");
                }
            }
        }
        private string _order_no { get; set; }
        public string order_no
        {
            get { return _order_no; }
            set
            {
                if (_order_no != value)
                {
                    _order_no = value; RaisePropertyChanged("order_no");
                }
            }
        }
        private string _op_no { get; set; }
        public string op_no
        {
            get { return _op_no; }
            set
            {
                if (_op_no != value)
                {
                    _op_no = value; RaisePropertyChanged("op_no");
                }
            }
        }
        private string _obj_type { get; set; }
        public string obj_type
        {
            get { return _obj_type; }
            set
            {
                if (_obj_type != value)
                {
                    _obj_type = value; RaisePropertyChanged("obj_type");
                }
            }
        }
        private string _obj_id { get; set; }
        public string obj_id
        {
            get { return _obj_id; }
            set
            {
                if (_obj_id != value)
                {
                    _obj_id = value; RaisePropertyChanged("obj_id");
                }
            }
        }
        private string _tl_type { get; set; }
        public string tl_type
        {
            get { return _tl_type; }
            set
            {
                if (_tl_type != value)
                {
                    _tl_type = value; RaisePropertyChanged("tl_type");
                }
            }
        }
        private string _tl_key { get; set; }
        public string tl_key
        {
            get { return _tl_key; }
            set
            {
                if (_tl_key != value)
                {
                    _tl_key = value; RaisePropertyChanged("tl_key");
                }
            }
        }
        private int? _item_counter_prt { get; set; }
        public int? item_counter_prt
        {
            get { return _item_counter_prt; }
            set
            {
                if (_item_counter_prt != value)
                {
                    _item_counter_prt = value; RaisePropertyChanged("item_counter_prt");
                }
            }
        }
        private int? _int_counter_prt { get; set; }
        public int? int_counter_prt
        {
            get { return _int_counter_prt; }
            set
            {
                if (_int_counter_prt != value)
                {
                    _int_counter_prt = value; RaisePropertyChanged("int_counter_prt");
                }
            }
        }
        private int? _item_row_id_prt { get; set; }
        public int? item_row_id_prt
        {
            get { return _item_row_id_prt; }
            set
            {
                if (_item_row_id_prt != value)
                {
                    _item_row_id_prt = value; RaisePropertyChanged("item_row_id_prt");
                }
            }
        }
        private string _tl_object { get; set; }
        public string tl_object
        {
            get { return _tl_object; }
            set
            {
                if (_tl_object != value)
                {
                    _tl_object = value; RaisePropertyChanged("tl_object");
                }
            }
        }
        private int? _int_counter { get; set; }
        public int? int_counter
        {
            get { return _int_counter; }
            set
            {
                if (_int_counter != value)
                {
                    _int_counter = value; RaisePropertyChanged("int_counter");
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
        private string _ctl_key { get; set; }
        public string ctl_key
        {
            get { return _ctl_key; }
            set
            {
                if (_ctl_key != value)
                {
                    _ctl_key = value; RaisePropertyChanged("ctl_key");
                }
            }
        }
        private decimal? _qty { get; set; }
        public decimal? qty
        {
            get { return _qty; }
            set
            {
                if (_qty != value)
                {
                    _qty = value; RaisePropertyChanged("qty");
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
        private decimal? _usage_value { get; set; }
        public decimal? usage_value
        {
            get { return _usage_value; }
            set
            {
                if (_usage_value != value)
                {
                    _usage_value = value; RaisePropertyChanged("usage_value");
                }
            }
        }
        private string _usage_unit { get; set; }
        public string usage_unit
        {
            get { return _usage_unit; }
            set
            {
                if (_usage_unit != value)
                {
                    _usage_unit = value; RaisePropertyChanged("usage_unit");
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


        //Scalar Fields
        private string _itemp_name { get; set; }
        public string itemp_name
        {
            get { return _itemp_name; }
            set
            {
                if (_itemp_name != value)
                {
                    _itemp_name = value; RaisePropertyChanged("itemp_name");
                }
            }
        }
        private string _op_name { get; set; }
        public string op_name
        {
            get { return _op_name; }
            set
            {
                if (_op_name != value)
                {
                    _op_name = value; RaisePropertyChanged("op_name");
                }
            }
        }
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

        public string XDOC_A { get; set; }
    }

}
