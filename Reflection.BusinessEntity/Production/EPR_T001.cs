using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Reflection.BusinessEntity.Production;
using Reflection.BusinessEntity.ReflectionSystem;

namespace Reflection.BusinessEntity
{
    public class EPR_T001 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int _id { get; set; }
        public int id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged("id");
            }
        }
        private string _order_no;
        public string order_no
        {
            get { return _order_no; }
            set { _order_no = value; RaisePropertyChanged("order_no", ModelEntityUpdated); }
        }
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id", ModelEntityUpdated); }
        }
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code", ModelEntityUpdated); }
        }
        private int? _machine_id;
        public int? machine_id
        {
            get { return _machine_id; }
            set { _machine_id = value; RaisePropertyChanged("machine_id"); }
        }
        private string _machinecode;
        public string machinecode

        {
            get { return _machinecode; }
            set { _machinecode = value; RaisePropertyChanged("machinecode"); }
        }
        private string _sono;
        public string sono
        {
            get { return _sono; }
            set { _sono = value; RaisePropertyChanged("sono"); }
        }
        private string _po_no;
        public string po_no
        {
            get { return _po_no; }
            set { _po_no = value; RaisePropertyChanged("po_no"); }
        }
        private string _PartyId;
        public string PartyId
        {
            get { return _PartyId; }
            set { _PartyId = value; RaisePropertyChanged("PartyId"); }
        }

        private string _shift;
        public string shift
        {
            get { return _shift; }
            set { _shift = value; RaisePropertyChanged("shift"); }
        }
        private int? _conv;
        public int? conv
        {
            get { return _conv; }
            set { _conv = value; RaisePropertyChanged("conv"); }
        }
        private int? _model_id;
        public int? model_id
        {
            get { return _model_id; }
            set { _model_id = value; RaisePropertyChanged("model_id"); }
        }
        private string _model_code;
        public string model_code
        {
            get { return _model_code; }
            set { _model_code = value; RaisePropertyChanged("model_code"); }
        }
        private string _ItemCode;
        public string ItemCode
        {
            get { return _ItemCode; }
            set { _ItemCode = value; RaisePropertyChanged("ItemCode", ModelEntityUpdated); }
        }
        private string _ball_dia;
        public string ball_dia
        {
            get { return _ball_dia; }
            set { _ball_dia = value; RaisePropertyChanged("ball_dia"); }
        }
        private string _ball_make;
        public string ball_make
        {
            get { return _ball_make; }
            set { _ball_make = value; RaisePropertyChanged("ball_make"); }
        }
        private string _wire_make;
        public string wire_make
        {
            get { return _wire_make; }
            set { _wire_make = value; RaisePropertyChanged("wire_make"); }
        }
        private string _ink;
        public string ink
        {
            get { return _ink; }
            set { _ink = value; RaisePropertyChanged("ink"); }
        }
        private int? _pack_style;
        public int? pack_style
        {
            get
            {
                return _pack_style;
            }
            set
            {
                if (_pack_style != value)
                {
                    _pack_style = value;
                    RaisePropertyChanged("pack_style");
                }
            }
        }
        private string _ild;
        public string ild
        {
            get { return _ild; }
            set { _ild = value; RaisePropertyChanged("ild"); }
        }
        
        private string _ball_type;
        public string ball_type
        {
            get { return _ball_type; }
            set { _ball_type = value; RaisePropertyChanged("ball_type"); }
        }
        
        private string _shape;
        public string shape
        {
            get { return _shape; }
            set { _shape = value; RaisePropertyChanged("shape"); }
        }
        private string _sf;
        public string sf
        {
            get { return _sf; }
            set { _sf = value; RaisePropertyChanged("sf"); }
        }

        private string _order_type;
        public string order_type
        {
            get { return _order_type; }
            set { _order_type = value; RaisePropertyChanged("order_type", ModelEntityUpdated); }
        }

        private string _shank_len;
        public string shank_len
        {
            get { return _shank_len; }
            set { _shank_len = value; RaisePropertyChanged("shank_len"); }
        }

        private string _needle_dia;
        public string needle_dia
        {
            get { return _needle_dia; }
            set { _needle_dia = value; RaisePropertyChanged("needle_dia"); }
        }

        private string _needle;
        public string needle
        {
            get { return _needle; }
            set { _needle = value; RaisePropertyChanged("needle"); }
        }

        private DateTime? _start_dt;
        public DateTime? start_dt
        {
            get { return _start_dt; }
            set { _start_dt = value; RaisePropertyChanged("start_dt"); }
        }
        private DateTime? _end_dt;
        public DateTime? end_dt
        {
            get { return _end_dt; }
            set { _end_dt = value; RaisePropertyChanged("end_dt"); }
        }
        private bool? _appr;
        public bool? appr
        {
            get { return _appr; }
            set { _appr = value; RaisePropertyChanged("appr"); }
        }
        
        private DateTime? _pro_dt;
        public DateTime? pro_dt
        {
            get { return _pro_dt; }
            set { _pro_dt = value; RaisePropertyChanged("pro_dt"); }
        }
        private string _prod_plan;
        public string prod_plan
        {
            get { return _prod_plan; }
            set { _prod_plan = value; RaisePropertyChanged("prod_plan"); }
        }
        private string _status;
        public string status
        {
            get { return _status; }
            set { _status = value; RaisePropertyChanged("status", ModelEntityUpdated); }
        }
        
        private bool _active;
        public bool active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }
        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
        }
        private string _editby;
        public string editby
        {
            get { return _editby; }
            set { _editby = value; RaisePropertyChanged("editby"); }
        }
        private DateTime? _edit_date;
        public DateTime? edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
        }
        
        
        private decimal? _wire_size;
        public decimal? wire_size
        {
            get { return _wire_size; }
            set { _wire_size = value; RaisePropertyChanged("wire_size"); }
        }
        private string _ref_doc_type;
        public string ref_doc_type
        {
            get { return _ref_doc_type; }
            set { _ref_doc_type = value; RaisePropertyChanged("ref_doc_type"); }
        }
        private string _ref_doc_no;
        public string ref_doc_no
        {
            get { return _ref_doc_no; }
            set { _ref_doc_no = value; RaisePropertyChanged("ref_doc_no"); }
        }
        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code"); }
        }
        private decimal? _qty;
        public decimal? qty
        {
            get { return _qty; }
            set { _qty = value; RaisePropertyChanged("qty"); }
        }
        private string _doc_cat;
        public string doc_cat
        {
            get
            {
                return _doc_cat;
            }
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
            get
            {
                return _doc_type;
            }
            set
            {
                if (_doc_type != value)
                {
                    _doc_type = value;
                    RaisePropertyChanged("doc_type");
                }
            }
        }
        
        private string _pre_order_no;
        public string pre_order_no
        {
            get
            {
                return _pre_order_no;
            }
            set
            {
                if (_pre_order_no != value)
                {
                    _pre_order_no = value;
                    RaisePropertyChanged("pre_order_no");
                }
            }
        }
        private decimal? _order_qty;
        public decimal? order_qty
        {
            get { return _order_qty; }
            set { _order_qty = value; RaisePropertyChanged("order_qty"); }
        }
        private string _wc_code;
        public string wc_code
        {
            get
            {
                return _wc_code;
            }
            set
            {
                if (_wc_code != value)
                {
                    _wc_code = value;
                    RaisePropertyChanged("wc_code");
                }
            }
        }
        private int? _plan_item_row_id;
        public int? plan_item_row_id
        {
            get { return _plan_item_row_id; }
            set { _plan_item_row_id = value; RaisePropertyChanged("plan_item_row_id"); }
        }
        private string _ref_order_no;
        public string ref_order_no
        {
            get
            {
                return _ref_order_no;
            }
            set
            {
                if (_ref_order_no != value)
                {
                    _ref_order_no = value;
                    RaisePropertyChanged("ref_order_no");
                }
            }
        }
        private string _cost_center;
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
                    _cost_center = value;
                    RaisePropertyChanged("cost_center");
                }
            }
        }
        private string _profit_center;
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
                    _profit_center = value;
                    RaisePropertyChanged("profit_center");
                }
            }
        }
        private string _emp_id;
        public string emp_id
        {
            get
            {
                return _emp_id;
            }
            set
            {
                if (_emp_id != value)
                {
                    _emp_id = value;
                    RaisePropertyChanged("emp_id");
                }
            }
        }
        private DateTime? _sch_start_date;
        public DateTime? sch_start_date
        {
            get { return _sch_start_date; }
            set { _sch_start_date = value; RaisePropertyChanged("sch_start_date"); }
        }
        private DateTime? _sch_end_date;
        public DateTime? sch_end_date
        {
            get { return _sch_end_date; }
            set { _sch_end_date = value; RaisePropertyChanged("sch_end_date"); }
        }
        private decimal? _scrap_qty;
        public decimal? scrap_qty
        {
            get { return _scrap_qty; }
            set { _scrap_qty = value; RaisePropertyChanged("scrap_qty"); }
        }
        private string _task_list_type;
        public string task_list_type
        {
            get
            {
                return _task_list_type;
            }
            set
            {
                if (_task_list_type != value)
                {
                    _task_list_type = value;
                    RaisePropertyChanged("task_list_type");
                }
            }
        }
        private string _task_list_group;
        public string task_list_group
        {
            get
            {
                return _task_list_group;
            }
            set
            {
                if (_task_list_group != value)
                {
                    _task_list_group = value;
                    RaisePropertyChanged("task_list_group");
                }
            }
        }
        private int? _group_counter;
        public int? group_counter
        {
            get { return _group_counter; }
            set { _group_counter = value; RaisePropertyChanged("group_counter"); }
        }
        private int? _plan_counter;
        public int? plan_counter
        {
            get { return _plan_counter; }
            set { _plan_counter = value; RaisePropertyChanged("plan_counter"); }
        }
        private string _sss;
        public string sss
        {
            get
            {
                return _sss;
            }
            set
            {
                if (_sss != value)
                {
                    _sss = value;
                    RaisePropertyChanged("sss");
                }
            }
        }
        private string _ind_backflush;
        public string ind_backflush
        {
            get
            {
                return _ind_backflush;
            }
            set
            {
                if (_ind_backflush != value)
                {
                    _ind_backflush = value;
                    RaisePropertyChanged("ind_backflush");
                }
            }
        }
        private string _req_plan_no;
        public string req_plan_no
        {
            get
            {
                return _req_plan_no;
            }
            set
            {
                if (_req_plan_no != value)
                {
                    _req_plan_no = value;
                    RaisePropertyChanged("req_plan_no");
                }
            }
        }
        private string _routing_no;
        public string routing_no
        {
            get
            {
                return _routing_no;
            }
            set
            {
                if (_routing_no != value)
                {
                    _routing_no = value;
                    RaisePropertyChanged("routing_no");
                }
            }
        }
        private string _bom_exp_no;
        public string bom_exp_no
        {
            get
            {
                return _bom_exp_no;
            }
            set
            {
                if (_bom_exp_no != value)
                {
                    _bom_exp_no = value;
                    RaisePropertyChanged("bom_exp_no");
                }
            }
        }
        private string _bom_no;
        public string bom_no
        {
            get
            {
                return _bom_no;
            }
            set
            {
                if (_bom_no != value)
                {
                    _bom_no = value;
                    RaisePropertyChanged("bom_no");
                }
            }
        }
        private string _planned_order_no;
        public string planned_order_no
        {
            get
            {
                return _planned_order_no;
            }
            set
            {
                if (_planned_order_no != value)
                {
                    _planned_order_no = value;
                    RaisePropertyChanged("planned_order_no");
                }
            }
        }
        private int? _planned_order_row_id;
        public int? planned_order_row_id
        {
            get { return _planned_order_row_id; }
            set { _planned_order_row_id = value; RaisePropertyChanged("planned_order_row_id"); }
        }
        private DateTime? _doc_date;
        public DateTime? doc_date
        {
            get { return _doc_date; }
            set { _doc_date = value; RaisePropertyChanged("doc_date"); }
        }
        private string _planning_plant;
        public string planning_plant
        {
            get
            {
                return _planning_plant;
            }
            set
            {
                if (_planning_plant != value)
                {
                    _planning_plant = value;
                    RaisePropertyChanged("planning_plant");
                }
            }
        }
        private string _store_code;
        public string store_code
        {
            get
            {
                return _store_code;
            }
            set
            {
                if (_store_code != value)
                {
                    _store_code = value;
                    RaisePropertyChanged("store_code");
                }
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
                if (_t_status != value)
                {
                    _t_status = value;
                    RaisePropertyChanged("t_status", ModelEntityUpdated);
                }
            }
        }
        private string _ind_gr;
        public string ind_gr
        {
            get
            {
                return _ind_gr;
            }

            set
            {
                _ind_gr = value; RaisePropertyChanged("ind_gr");
            }
        }
        private string _obj_no;
        public string obj_no
        {
            get
            {
                return _obj_no;
            }

            set
            {
                _obj_no = value; RaisePropertyChanged("obj_no");
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
        private int? _element_no;
        public int? element_no
        {
            get
            {
                return _element_no;
            }

            set
            {
                _element_no = value; RaisePropertyChanged("element_no");
            }
        }
        private string _project_id;
        public string project_id
        {
            get
            {
                return _project_id;
            }

            set
            {
                _project_id = value; RaisePropertyChanged("project_id");
            }
        }

        private string _not_no;
        public string not_no
        {
            get
            {
                return _not_no;
            }

            set
            {
                _not_no = value; RaisePropertyChanged("not_no");
            }
        }
        private string _equip_no;
        public string equip_no
        {
            get
            {
                return _equip_no;
            }

            set
            {
                _equip_no = value; RaisePropertyChanged("equip_no");
            }
        }
        private string _item_code_asm;
        public string item_code_asm
        {
            get
            {
                return _item_code_asm;
            }

            set
            {
                _item_code_asm = value; RaisePropertyChanged("item_code_asm");
            }
        }
        private decimal? _down_time;
        public decimal? down_time
        {
            get
            {
                return _down_time;
            }

            set
            {
                _down_time = value; RaisePropertyChanged("down_time");
            }
        }
        private string _unit_code_bd;
        public string unit_code_bd
        {
            get
            {
                return _unit_code_bd;
            }

            set
            {
                _unit_code_bd = value; RaisePropertyChanged("unit_code_bd");
            }
        }
        private string _pm_plan_no;
        public string pm_plan_no
        {
            get
            {
                return _pm_plan_no;
            }

            set
            {
                _pm_plan_no = value; RaisePropertyChanged("pm_plan_no");
            }
        }
        private string _pm_plan_item;
        public string pm_plan_item
        {
            get
            {
                return _pm_plan_item;
            }
            set
            {
                _pm_plan_item = value; RaisePropertyChanged("pm_plan_item");
            }
        }
        private int? _pm_plan_call;
        public int? pm_plan_call
        {
            get
            {
                return _pm_plan_call;
            }
            set
            {
                _pm_plan_call = value; RaisePropertyChanged("pm_plan_call");
            }
        }
        private string _serial_no;
        public string serial_no
        {
            get
            {
                return _serial_no;
            }
            set
            {
                _serial_no = value; RaisePropertyChanged("serial_no");
            }
        }
        private string _master_equip_no;
        public string master_equip_no
        {
            get
            {
                return _master_equip_no;
            }
            set
            {
                _master_equip_no = value; RaisePropertyChanged("master_equip_no");
            }
        }
        private string _unique_code;
        public string unique_code
        {
            get
            {
                return _unique_code;
            }
            set
            {
                _unique_code = value; RaisePropertyChanged("unique_code");
            }
        }
        private int? _task_no { get; set; }
        public int? task_no
        {
            get { return _task_no; }
            set
            {
                if (_task_no != value)
                {
                    _task_no = value; RaisePropertyChanged("task_no");
                }
            }
        }
        private int? _seq_no { get; set; }
        public int? seq_no
        {
            get { return _seq_no; }
            set
            {
                if (_seq_no != value)
                {
                    _seq_no = value; RaisePropertyChanged("seq_no");
                }
            }
        }


        //========================================Replaced

        private string _char_code;
        public string char_code
        {
            get { return _char_code; }
            set { _char_code = value; RaisePropertyChanged("char_code"); }
        }
        private string _char_spec;
        public string char_spec
        {
            get { return _char_spec; }
            set { _char_spec = value; RaisePropertyChanged("char_spec"); }
        }
        private string _char_point;
        public string char_point
        {
            get { return _char_point; }
            set { _char_point = value; RaisePropertyChanged("char_point"); }
        }
        private string _frequency;
        public string frequency
        {
            get { return _frequency; }
            set { _frequency = value; RaisePropertyChanged("frequency"); }
        }
        private string _method;
        public string method
        {
            get { return _method; }
            set { _method = value; RaisePropertyChanged("method"); }
        }
       
        private double? _accuracy;
        public double? accuracy
        {
            get { return _accuracy; }
            set { _accuracy = value; RaisePropertyChanged("accuracy"); }
        }
        private string _accuracy_uom;
        public string accuracy_uom
        {
            get { return _accuracy_uom; }
            set { _accuracy_uom = value; RaisePropertyChanged("accuracy_uom"); }
        }
        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set { _lang_key = value; RaisePropertyChanged("lang_key"); }
        }
        private string _ind_cap;
        public string ind_cap
        {
            get
            {
                return _ind_cap;
            }
            set
            {
                if (_ind_cap != value)
                {
                    _ind_cap = value;
                    RaisePropertyChanged("ind_cap");
                }
            }
        }
        private string _ind_rm;
        public string ind_rm
        {
            get
            {
                return _ind_rm;
            }
            set
            {
                if (_ind_rm != value)
                {
                    _ind_rm = value;
                    RaisePropertyChanged("ind_rm");
                }
            }
        }
        private string _ind_sch;
        public string ind_sch
        {
            get
            {
                return _ind_sch;
            }
            set
            {
                if (_ind_sch != value)
                {
                    _ind_sch = value;
                    RaisePropertyChanged("ind_sch");
                }
            }
        }
        private string _ind_pay;
        public string ind_pay
        {
            get { return _ind_pay; }
            set { _ind_pay = value; RaisePropertyChanged("ind_pay"); }
        }
        private string _ind_ud;
        public string ind_ud
        {
            get { return _ind_ud; }
            set { _ind_ud = value; RaisePropertyChanged("ind_ud"); }
        }
        private string _ud_rule;
        public string ud_rule
        {
            get { return _ud_rule; }
            set { _ud_rule = value; RaisePropertyChanged("ud_rule"); }
        }
        private string _com_method;
        public string com_method
        {
            get { return _com_method; }
            set { _com_method = value; RaisePropertyChanged("com_method"); }
        }
        private string _request;
        public string request
        {
            get { return _request; }
            set { _request = value; RaisePropertyChanged("request"); }
        }
        private string _remark;
        public string remark
        {
            get { return _remark; }
            set { _remark = value; RaisePropertyChanged("remark"); }
        }
        private string _note;
        public string note
        {
            get { return _note; }
            set { _note = value; RaisePropertyChanged("note"); }
        }
        private string _note_diff;
        public string note_diff
        {
            get { return _note_diff; }
            set { _note_diff = value; RaisePropertyChanged("note_diff"); }
        }
        private string _con_note;
        public string con_note
        {
            get { return _con_note; }
            set { _con_note = value; RaisePropertyChanged("con_note"); }
        }

        private string _title { get; set; }
        public string title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value; RaisePropertyChanged("title");
                }
            }
        }
        //========================================ReplaceEnd


        //Scalar Fields

        private string _PlantName;
        public string PlantName
        {
            get { return _PlantName; }
            set { _PlantName = value; RaisePropertyChanged("PlantName"); }
        }
        private string _PartyName;
        public string PartyName
        {
            get { return _PartyName; }
            set { _PartyName = value; RaisePropertyChanged("PartyName"); }
        }
        public string Type { get; set; }
        private string _ItemName;
        public string ItemName
        {
            get { return _ItemName; }
            set { _ItemName = value; RaisePropertyChanged("ItemName"); }
        }
        private string _Unit;
        public string Unit
        {
            get
            {
                return _Unit;
            }
            set
            {
                if (_Unit != value)
                {
                    _Unit = value;
                    RaisePropertyChanged("Unit");
                }
            }
        }
        private string _PackingUnit;
        public string PackingUnit
        {
            get
            {
                return _PackingUnit;
            }
            set
            {
                if (_PackingUnit != value)
                {
                    _PackingUnit = value;
                    RaisePropertyChanged("PackingUnit");
                }
            }
        }

        private string _t_display;
        public string t_display
        {
            get
            {
                return _t_display;
            }
            set
            {
                if (_t_display != value)
                {
                    _t_display = value;
                    RaisePropertyChanged("t_display");
                }
            }
        }
        private string _sku;
        public string sku
        {
            get
            {
                return _sku;
            }
            set
            {
                if (_sku != value)
                {
                    _sku = value;
                    RaisePropertyChanged("sku");
                }
            }
        }
        private decimal? _prod_qty;
        public decimal? prod_qty
        {
            get { return _prod_qty; }
            set
            {
                if (_prod_qty != value)
                {
                    _prod_qty = value;
                    RaisePropertyChanged("prod_qty");
                }
            }
        }
        private decimal? _bal_qty;
        public decimal? bal_qty
        {
            get { return _bal_qty; }
            set
            {
                if (_bal_qty != value)
                {
                    _bal_qty = value;
                    RaisePropertyChanged("bal_qty");
                }
            }
        }
        public string XDOC_A { get; set; }
        public string XDOC_B { get; set; }
        public string XDOC_C { get; set; }
        public string XDOC_VC { get; set; } // Classification
        public string XmlDataDocument_EPR_T001 { get; set; }
        public string XmlDataDocument_EPR_T001_A { get; set; }
        public string XmlDataDocument_EPR_T001_Flip { get; set; }

        private string _ind_batch;
        public string ind_batch
        {
            get
            {
                return _ind_batch;
            }

            set
            {
                _ind_batch = value; RaisePropertyChanged("ind_batch");
            }
        }

        // Extra
        private string _MachineType;
        public string MachineType
        {
            get { return _MachineType; }
            set { _MachineType = value; RaisePropertyChanged("MachineType"); }
        }
        private bool _Select { get; set; }
        public bool Select
        {
            get { return _Select; }
            set
            {
                if (_Select != value)
                {
                    _Select = value;
                    RaisePropertyChanged("Select");
                }
            }
        }
        public string ReportType { get; set; }
        public string RptMachineType { get; set; }

        private DateTime? _Rpt_Date;
        public DateTime? Rpt_Date
        {
            get { return _Rpt_Date; }
            set { _Rpt_Date = value; RaisePropertyChanged("Rpt_Date"); }
        }

        private DateTime? _Fromdate;
        public DateTime? Fromdate
        {
            get { return _Fromdate; }
            set
            {
                _Fromdate = value;
                RaisePropertyChanged("Fromdate");
            }
        }
        private DateTime? _ToDate;
        public DateTime? ToDate
        {
            get { return _ToDate; }
            set
            {
                _ToDate = value;
                RaisePropertyChanged("ToDate");
            }
        }
        private string _temp_status;
        public string temp_status
        {
            get { return _temp_status; }
            set { _temp_status = value; RaisePropertyChanged("temp_status"); }
        }
        //private string _color_code;
        //public string color_code
        //{
        //    get { return _color_code; }
        //    set { _color_code = value; RaisePropertyChanged("color_code"); }
        //}
        private decimal? _final_qty;
        public decimal? final_qty
        {
            get
            {
                return _final_qty;
            }

            set
            {
                _final_qty = value; RaisePropertyChanged("final_qty");
            }
        }

        private string _prev_batch;
        public string prev_batch
        {
            get
            {
                return _prev_batch;
            }

            set
            {
                _prev_batch = value; RaisePropertyChanged("prev_batch");
            }
        }

        private int? _order_item_row_id;
        public int? order_item_row_id
        {
            get
            {
                return _order_item_row_id;
            }

            set
            {
                _order_item_row_id = value; RaisePropertyChanged("order_item_row_id");
            }
        }

        private string _short_text;
        public string short_text
        {
            get
            {
                return _short_text;
            }

            set
            {
                _short_text = value; RaisePropertyChanged("short_text");
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
        private string _emp_name { get; set; }
        public string emp_name
        {
            get { return _emp_name; }
            set
            {
                if (_emp_name != value)
                {
                    _emp_name = value; RaisePropertyChanged("emp_name");
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

        private string _para1 { get; set; }
        public string para1
        {
            get { return _para1; }
            set
            {
                if (_para1 != value)
                {
                    _para1 = value; RaisePropertyChanged("para1");
                }
            }
        }
        private string _para2 { get; set; }
        public string para2
        {
            get { return _para2; }
            set
            {
                if (_para2 != value)
                {
                    _para2 = value; RaisePropertyChanged("para2");
                }
            }
        }
        private string _doc_title { get; set; }
        public string doc_title
        {
            get { return _doc_title; }
            set
            {
                if (_doc_title != value)
                {
                    _doc_title = value; RaisePropertyChanged("doc_title");
                }
            }
        }
        private byte[] _qr_image { get; set; }
        public byte[] qr_image
        {
            get { return _qr_image; }
            set
            {
                if (_qr_image != value)
                {
                    _qr_image = value; RaisePropertyChanged("qr_image");
                }
            }
        }

        private string _method_name { get; set; }
        public string method_name
        {
            get { return _method_name; }
            set
            {
                if (_method_name != value)
                {
                    _method_name = value; RaisePropertyChanged("method_name");
                }
            }
        }
        private string _com_name { get; set; }
        public string com_name
        {
            get { return _com_name; }
            set
            {
                if (_com_name != value)
                {
                    _com_name = value; RaisePropertyChanged("com_name");
                }
            }
        }

        private string _doc_type_name { get; set; }
        public string doc_type_name
        {
            get { return _doc_type_name; }
            set
            {
                if (_doc_type_name != value)
                {
                    _doc_type_name = value; RaisePropertyChanged("doc_type_name");
                }
            }
        }
        //private DateTime? _sch_date_max { get; set; }
        //public DateTime? sch_date_max
        //{
        //    get { return _sch_date_max; }
        //    set
        //    {
        //        if (_sch_date_max != value)
        //        {
        //            _sch_date_max = value; RaisePropertyChanged("sch_date_max");
        //        }
        //    }
        //}
        //private DateTime? _sch_date_min { get; set; }
        //public DateTime? sch_date_min
        //{
        //    get { return _sch_date_min; }
        //    set
        //    {
        //        if (_sch_date_min != value)
        //        {
        //            _sch_date_min = value; RaisePropertyChanged("sch_date_min");
        //        }
        //    }
        //}

        public string cp_name { get; set; }
        public string add_del { get; set; }
        public string fl_name { get; set; }
        public string ref_no { get; set; }
        public DateTime? ref_date { get; set; }
        public DateTime? del_date { get; set; }

        private string _equip_name { get; set; }
        public string equip_name
        {
            get { return _equip_name; }
            set
            {
                if (_equip_name != value)
                {
                    _equip_name = value; RaisePropertyChanged("equip_name");
                }
            }
        }


        public override string ToString()
        {
            return string.Format("{0}", order_no);
        }
    }
    public class EPR_T001_A : ObjectBase
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
        private string _task_list_type;
        public string task_list_type
        {
            get { return _task_list_type; }
            set
            {
                _task_list_type = value;
                RaisePropertyChanged("task_list_type");
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
        private string _operation_no;
        public string operation_no
        {
            get { return _operation_no; }
            set
            {
                _operation_no = value;
                RaisePropertyChanged("operation_no");
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
        private string _operation_desc;
        public string operation_desc
        {
            get { return _operation_desc; }
            set
            {
                _operation_desc = value;
                RaisePropertyChanged("operation_desc");
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
        private string _location_id;
        public string location_id
        {
            get { return _location_id; }
            set
            {
                _location_id = value;
                RaisePropertyChanged("location_id", ModelEntityUpdated);
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
        private string _plan_no;
        public string plan_no
        {
            get { return _plan_no; }
            set
            {
                _plan_no = value;
                RaisePropertyChanged("plan_no");
            }
        }
        private int? _operation_row_id;
        public int? operation_row_id
        {
            get { return _operation_row_id; }
            set
            {
                _operation_row_id = value;
                RaisePropertyChanged("operation_row_id");
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
        private int? _ref_line_id;
        public int? ref_line_id
        {
            get { return _ref_line_id; }
            set
            {
                _ref_line_id = value;
                RaisePropertyChanged("ref_line_id");
            }
        }
        private string _tl_key;
        public string tl_key
        {
            get { return _tl_key; }
            set
            {
                _tl_key = value;
                RaisePropertyChanged("tl_key");
            }
        }
        private decimal? _op_increment;
        public decimal? op_increment
        {
            get { return _op_increment; }
            set
            {
                _op_increment = value;
                RaisePropertyChanged("op_increment");
            }
        }
        private decimal? _no_of_emp;
        public decimal? no_of_emp
        {
            get { return _no_of_emp; }
            set
            {
                _no_of_emp = value;
                RaisePropertyChanged("no_of_emp");
            }
        }
        private string _line_id_super;
        public string line_id_super
        {
            get { return _line_id_super; }
            set
            {
                _line_id_super = value;
                RaisePropertyChanged("line_id_super");
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
        private Nullable<int> _bom_item_row_id;
        public Nullable<int> bom_item_row_id
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
        private DateTime? _add_date;
        public DateTime? add_date
        {
            get { return _add_date; }
            set
            {
                _add_date = value;
                RaisePropertyChanged("add_date");
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
        private string _inst_type;
        public string inst_type
        {
            get { return _inst_type; }
            set
            {
                _inst_type = value;
                RaisePropertyChanged("inst_type");
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
        private string _doc_no_oc;
        public string doc_no_oc
        {
            get { return _doc_no_oc; }
            set
            {
                _doc_no_oc = value;
                RaisePropertyChanged("doc_no_oc");
            }
        }
        private int? _order_counter;
        public int? order_counter
        {
            get { return _order_counter; }
            set
            {
                _order_counter = value;
                RaisePropertyChanged("order_counter");
            }
        }
        private decimal? _cost_of_operation;
        public decimal? cost_of_operation
        {
            get { return _cost_of_operation; }
            set
            {
                _cost_of_operation = value;
                RaisePropertyChanged("cost_of_operation");
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
        private string _obj_no;
        public string obj_no
        {
            get { return _obj_no; }
            set
            {
                _obj_no = value;
                RaisePropertyChanged("obj_no");
            }
        }
        private string _cost_element;
        public string cost_element
        {
            get { return _cost_element; }
            set
            {
                _cost_element = value;
                RaisePropertyChanged("cost_element");
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
        private string _tl_group_key;
        public string tl_group_key
        {
            get { return _tl_group_key; }
            set
            {
                _tl_group_key = value;
                RaisePropertyChanged("tl_group_key");
            }
        }
        private string _emp_id;
        public string emp_id
        {
            get
            {
                return _emp_id;
            }
            set
            {
                if (_emp_id != value)
                {
                    _emp_id = value;
                    RaisePropertyChanged("emp_id");
                }
            }
        }
        private int? _element_no;
        public int? element_no
        {
            get { return _element_no; }
            set
            {
                _element_no = value;
                RaisePropertyChanged("element_no");
            }
        }
        private string _po_code;
        public string po_code
        {
            get
            {
                return _po_code;
            }
            set
            {
                if (_po_code != value)
                {
                    _po_code = value;
                    RaisePropertyChanged("po_code");
                }
            }
        }
        private string _pg_code;
        public string pg_code
        {
            get
            {
                return _pg_code;
            }
            set
            {
                if (_pg_code != value)
                {
                    _pg_code = value;
                    RaisePropertyChanged("pg_code");
                }
            }
        }
        private string _requester;
        public string requester
        {
            get
            {
                return _requester;
            }
            set
            {
                if (_requester != value)
                {
                    _requester = value;
                    RaisePropertyChanged("requester");
                }
            }
        }
        private string _recipient;
        public string recipient
        {
            get
            {
                return _recipient;
            }
            set
            {
                if (_recipient != value)
                {
                    _recipient = value;
                    RaisePropertyChanged("recipient");
                }
            }
        }
        private decimal? _unit_price;
        public decimal? unit_price
        {
            get { return _unit_price; }
            set
            {
                _unit_price = value;
                RaisePropertyChanged("unit_price");
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

        //Scalar Fields
        private string _t_display;
        public string t_display
        {
            get
            {
                return _t_display;
            }
            set
            {
                if (_t_display != value)
                {
                    _t_display = value;
                    RaisePropertyChanged("t_display");
                }
            }
        }
        
        private string _emp_name;
        public string emp_name
        {
            get
            {
                return _emp_name;
            }
            set
            {
                if (_emp_name != value)
                {
                    _emp_name = value;
                    RaisePropertyChanged("emp_name");
                }
            }
        }
        public string XDOC_B;
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        public string order_title { get; set; }
        public DateTime? start_date_order { get; set; }
        public DateTime? end_date_order { get; set; }
        public string emp_name_order { get; set; }

        // Scalar

        //private DateTime? _sch_date_max { get; set; }
        //public DateTime? sch_date_max
        //{
        //    get { return _sch_date_max; }
        //    set
        //    {
        //        if (_sch_date_max != value)
        //        {
        //            _sch_date_max = value; RaisePropertyChanged("sch_date_max");
        //        }
        //    }
        //}
        //private DateTime? _sch_date_min { get; set; }
        //public DateTime? sch_date_min
        //{
        //    get { return _sch_date_min; }
        //    set
        //    {
        //        if (_sch_date_min != value)
        //        {
        //            _sch_date_min = value; RaisePropertyChanged("sch_date_min");
        //        }
        //    }
        //}

        public override string ToString()
        {
            return string.Format("{0}", doc_no);
        }
    }
    public class EPR_T001_B : ObjectBase
    {
        private int? _plan_counter { get; set; }
        public int? plan_counter
        {
            get { return _plan_counter; }
            set
            {
                if (_plan_counter != value)
                {
                    _plan_counter = value; RaisePropertyChanged("plan_counter");
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
        private string _plan_no { get; set; }
        public string plan_no
        {
            get { return _plan_no; }
            set
            {
                if (_plan_no != value)
                {
                    _plan_no = value; RaisePropertyChanged("plan_no");
                }
            }
        }
        private int? _operation_row_id { get; set; }
        public int? operation_row_id
        {
            get { return _operation_row_id; }
            set
            {
                if (_operation_row_id != value)
                {
                    _operation_row_id = value; RaisePropertyChanged("operation_row_id");
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
        private string _unit_code_sv { get; set; }
        public string unit_code_sv
        {
            get { return _unit_code_sv; }
            set
            {
                if (_unit_code_sv != value)
                {
                    _unit_code_sv = value; RaisePropertyChanged("unit_code_sv");
                }
            }
        }
        private decimal? _std_value { get; set; }
        public decimal? std_value
        {
            get { return _std_value; }
            set
            {
                if (_std_value != value)
                {
                    _std_value = value; RaisePropertyChanged("std_value");
                }
            }
        }
        private string _unit_code_work { get; set; }
        public string unit_code_work
        {
            get { return _unit_code_work; }
            set
            {
                if (_unit_code_work != value)
                {
                    _unit_code_work = value; RaisePropertyChanged("unit_code_work");
                }
            }
        }
        private decimal? _opr_qty { get; set; }
        public decimal? opr_qty
        {
            get { return _opr_qty; }
            set
            {
                if (_opr_qty != value)
                {
                    _opr_qty = value; RaisePropertyChanged("opr_qty");
                }
            }
        }
        private decimal? _opr_scrap { get; set; }
        public decimal? opr_scrap
        {
            get { return _opr_scrap; }
            set
            {
                if (_opr_scrap != value)
                {
                    _opr_scrap = value; RaisePropertyChanged("opr_scrap");
                }
            }
        }
        private DateTime? _sch_start { get; set; }
        public DateTime? sch_start
        {
            get { return _sch_start; }
            set
            {
                if (_sch_start != value)
                {
                    _sch_start = value; RaisePropertyChanged("sch_start");
                }
            }
        }
        private DateTime? _sch_end { get; set; }
        public DateTime? sch_end
        {
            get { return _sch_end; }
            set
            {
                if (_sch_end != value)
                {
                    _sch_end = value; RaisePropertyChanged("sch_end");
                }
            }
        }
        private DateTime? _forecast_start { get; set; }
        public DateTime? forecast_start
        {
            get { return _forecast_start; }
            set
            {
                if (_forecast_start != value)
                {
                    _forecast_start = value; RaisePropertyChanged("forecast_start");
                }
            }
        }
        private DateTime? _forecast_end { get; set; }
        public DateTime? forecast_end
        {
            get { return _forecast_end; }
            set
            {
                if (_forecast_end != value)
                {
                    _forecast_end = value; RaisePropertyChanged("forecast_end");
                }
            }
        }
        private DateTime? _actual_start { get; set; }
        public DateTime? actual_start
        {
            get { return _actual_start; }
            set
            {
                if (_actual_start != value)
                {
                    _actual_start = value; RaisePropertyChanged("actual_start");
                }
            }
        }
        private DateTime? _actual_end { get; set; }
        public DateTime? actual_end
        {
            get { return _actual_end; }
            set
            {
                if (_actual_end != value)
                {
                    _actual_end = value; RaisePropertyChanged("actual_end");
                }
            }
        }
        private decimal? _length_schedule { get; set; }
        public decimal? length_schedule
        {
            get { return _length_schedule; }
            set
            {
                if (_length_schedule != value)
                {
                    _length_schedule = value; RaisePropertyChanged("length_schedule");
                }
            }
        }
        private decimal? _length_forecast { get; set; }
        public decimal? length_forecast
        {
            get { return _length_forecast; }
            set
            {
                if (_length_forecast != value)
                {
                    _length_forecast = value; RaisePropertyChanged("length_forecast");
                }
            }
        }
        private decimal? _length_actual { get; set; }
        public decimal? length_actual
        {
            get { return _length_actual; }
            set
            {
                if (_length_actual != value)
                {
                    _length_actual = value; RaisePropertyChanged("length_actual");
                }
            }
        }
        private string _uom_schedule { get; set; }
        public string uom_schedule
        {
            get { return _uom_schedule; }
            set
            {
                if (_uom_schedule != value)
                {
                    _uom_schedule = value; RaisePropertyChanged("uom_schedule");
                }
            }
        }
        private string _uom_forecast { get; set; }
        public string uom_forecast
        {
            get { return _uom_forecast; }
            set
            {
                if (_uom_forecast != value)
                {
                    _uom_forecast = value; RaisePropertyChanged("uom_forecast");
                }
            }
        }
        private string _uom_actual { get; set; }
        public string uom_actual
        {
            get { return _uom_actual; }
            set
            {
                if (_uom_actual != value)
                {
                    _uom_actual = value; RaisePropertyChanged("uom_actual");
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
        private decimal? _qty_work { get; set; }
        public decimal? qty_work
        {
            get { return _qty_work; }
            set
            {
                if (_qty_work != value)
                {
                    _qty_work = value; RaisePropertyChanged("qty_work");
                }
            }
        }
        private string _uom_work { get; set; }
        public string uom_work
        {
            get { return _uom_work; }
            set
            {
                if (_uom_work != value)
                {
                    _uom_work = value; RaisePropertyChanged("uom_work");
                }
            }
        }

        private int? _line_id_opr { get; set; }
        public int? line_id_opr
        {
            get { return _line_id_opr; }
            set
            {
                if (_line_id_opr != value)
                {
                    _line_id_opr = value; RaisePropertyChanged("line_id_opr");
                }
            }
        }


        // Scalar

        //private DateTime? _sch_date_max { get; set; }
        //public DateTime? sch_date_max
        //{
        //    get { return _sch_date_max; }
        //    set
        //    {
        //        if (_sch_date_max != value)
        //        {
        //            _sch_date_max = value; RaisePropertyChanged("sch_date_max");
        //        }
        //    }
        //}
        //private DateTime? _sch_date_min { get; set; }
        //public DateTime? sch_date_min
        //{
        //    get { return _sch_date_min; }
        //    set
        //    {
        //        if (_sch_date_min != value)
        //        {
        //            _sch_date_min = value; RaisePropertyChanged("sch_date_min");
        //        }
        //    }
        //}
    }
    public class EPR_T001_C : ObjectBase
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
        private string _op_doc { get; set; }
        public string op_doc
        {
            get { return _op_doc; }
            set
            {
                if (_op_doc != value)
                {
                    _op_doc = value; RaisePropertyChanged("op_doc");
                }
            }
        }
        private string _op_doc_dep { get; set; }
        public string op_doc_dep
        {
            get { return _op_doc_dep; }
            set
            {
                if (_op_doc_dep != value)
                {
                    _op_doc_dep = value; RaisePropertyChanged("op_doc_dep");
                }
            }
        }
        //private int? _op_row_id { get; set; }
        //public int? op_row_id
        //{
        //    get { return _op_row_id; }
        //    set
        //    {
        //        if (_op_row_id != value)
        //        {
        //            _op_row_id = value; RaisePropertyChanged("op_row_id");
        //        }
        //    }
        //}
        //private int? _op_row_id_dep { get; set; }
        //public int? op_row_id_dep
        //{
        //    get { return _op_row_id_dep; }
        //    set
        //    {
        //        if (_op_row_id_dep != value)
        //        {
        //            _op_row_id_dep = value; RaisePropertyChanged("op_row_id_dep");
        //        }
        //    }
        //}
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
       

        // Scalar

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
        private string _order_title { get; set; }
        public string order_title
        {
            get { return _order_title; }
            set
            {
                if (_order_title != value)
                {
                    _order_title = value; RaisePropertyChanged("order_title");
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
        private string _operation_desc { get; set; }
        public string operation_desc
        {
            get { return _operation_desc; }
            set
            {
                if (_operation_desc != value)
                {
                    _operation_desc = value; RaisePropertyChanged("operation_desc");
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


    }
    public class MultipleContext_EPR_T001
    {
        public List<EPR_T001> ILDChart { get; set; }  //ILD Chart
        public ObservableCollection<EPR_T001> GoodsDetails { get; set; }  // ILD Chart
        public List<ADM_M003_PopUp1> plant { get; set; }  //Plant/Location Master     
        public List<ZADM_M013_P_machine_type> MachineType { get; set; }  //Machine Type
        public List<ZADM_M013_P> Machine { get; set; }  //Machine Master
        public List<ZADM_M009_P> Model { get; set; }  //Model Master
        public List<ADM_M022_P_ESSEM> Product { get; set; } //Product /Item 
        public List<ZADM_M001_P> BallDia { get; set; } //Ball Dia
        public List<ADM_M032_P> BallMake { get; set; } //Ball Make
        public List<ADM_M032_P> WireMake { get; set; } //Wire Make 
        public List<ZADM_M003_P> WireSize { get; set; } //Wire Size 
        public List<ZADM_M002_P> BallType { get; set; } //Ball Type
        public List<ZADM_M006_P> INK { get; set; }     //INK
        public List<ZADM_M007_P> ILD { get; set; }    //ILD
        public List<EPR_T001> ILDChart_New { get; set; }  //ILD Chart
        public List<SEL_T001_P> SalesOrder { get; set; } // Order No / sales Doc.no
        public List<EPR_T004_A_P> ProductionPlan { get; set; }//Order No/Sample
        public List<ADM_M028_P> Customer { get; set; } //Customer /Party
        public List<ZADM_M017_P> PkgUnitList { get; set; }
        public ObservableCollection<RPT_EPR_T001> RPTINK { get; set; }
        public ObservableCollection<RPT_EPR_T001_ILDChart> RptILDChart { get; set; }
        public List<ECRM_T002_AFeedbackRpt> RptFeedback { get; set; }
        public List<SYS_M013_P> DocumentTypes { get; set; }
        public List<ADM_M042_P> ShiftList { get; set; }
        public List<RPT_Approval> Rptapproval { get; set; }
        public List<COM_T003> AttachmentData { get; set; }
        public List<PPC_T004_A> PlannedOrders { get; set; }
        public List<ADM_M038_B_P> UOM { get; set; }
        public List<ADM_M022_P1> ItemMaster { get; set; }
        public List<ADM_M003_P> LocationMaster { get; set; }
        public List<ADM_M024_P> EmployeeList { get; set; }
        public List<QMS_M030_P> RoutingList { get; set; }
        public List<ENG_T001_P> BOMList { get; set; }
        public List<SYS_M025> StatusList { get; set; }
        public List<ACC_M019_P> CostCenterList { get; set; }
        public List<ACC_M020_P> ProfitCenterList { get; set; }
        public List<EPR_T001> MasterEntity { get; set; }
        public List<EPR_T001> BackFlipList { get; set; }
        public List<MM_M001_P> StoreCodeList { get; set; }
        public List<PPC_M001_P> WorkCenter { get; set; }
        public List<SYS_M051> ControlKeyMaster { get; set; }
        public List<PPC_M002> OperationList { get; set; }
        public ObservableCollection<EPR_T001_A> OperationEntity { get; set; }
        public List<STD_LIST_BE> REF_DOC_LIST { get; set; }
    }
    public class RPT_EPR_T001
    {

        public string order_no { get; set; }
        //public Nullable<System.DateTime> edit_date { get; set; }
        //public System.DateTime add_date { get; set; }
        //public string machinecode{ get; set; }
        //public string model_code{ get; set; }
        //public string ball_dia{ get; set; }
        //public string ild{ get; set; }
        //public string ink{ get; set; }
        //public string wire_make{ get; set; }
        //public string ball_type{ get; set; }
        //public string ball_make{ get; set; }
        //public string sf{ get; set; }
        //public System.DateTime start_dt { get; set; }
        //public string PartyName { get; set; }
        //public string PlantName{ get; set; }

        public int id { get; set; }
        public string company_id { get; set; }
        public string plant { get; set; }
        public int machine_id { get; set; }
        public string so_no { get; set; }
        public string po_no { get; set; }
        public string party_id { get; set; }
        public string shift { get; set; }
        public Nullable<int> conv { get; set; }
        public Nullable<int> model_id { get; set; }
        public string item_code { get; set; }
        public string ball_dia { get; set; }
        public string ball_make { get; set; }
        public string wire_make { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public string tds_no { get; set; }
        public string col { get; set; }
        public string ball_type { get; set; }
        public string basket { get; set; }
        public string spoons { get; set; }
        public string shape { get; set; }
        public string sf { get; set; }
        public string order_type { get; set; }
        public string shank_len { get; set; }
        public string needle_dia { get; set; }
        public string needle { get; set; }
        public System.DateTime start_dt { get; set; }
        public Nullable<System.DateTime> end_dt { get; set; }
        public Nullable<bool> appr { get; set; }
        public Nullable<System.DateTime> apr_dt { get; set; }
        public string apr_by { get; set; }
        public Nullable<System.DateTime> pro_dt { get; set; }
        public string prod_plan { get; set; }
        public string status { get; set; }
        public string Note { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string PlantName { get; set; }
        public string MachineType { get; set; }
        public string MachineCode { get; set; }
        public string ModelCode { get; set; }
        public string Type { get; set; }
        public string PartyName { get; set; }

        public System.DateTime UDate { get; set; }
        public string CodeNo { get; set; }
        public string CPONo { get; set; }
        public string machineorder { get; set; }
        public string Product { get; set; }

        public string INKChanged { get; set; }
        public string ProdChanged { get; set; }
        public string DimChanged { get; set; }
        public Nullable<decimal> TotalLen { get; set; }
        public string ShankDia { get; set; }
        public string CustEL { get; set; }
        public string wire_size { get; set; }
        public string wire_type { get; set; }
        public string tip_type { get; set; }
        public Nullable<decimal> plan_qty { get; set; }
        public string unit_code { get; set; }
        public Nullable<decimal> order_qty { get; set; }
        public string url { get; set; }
        public Nullable<int> plan_item_row_id { get; set; }
    }

    public class RPT_Approval
    {
        public string doc_no { get; set; }
        public Nullable<System.DateTime> appro_date { get; set; }
        public string approvar_remark { get; set; }
        public string appro_status { get; set; }
        public string EmpName { get; set; }
        public string DeptName { get; set; }
    }

    public class RPT_EPR_T001_ILDChart
    {
        public string MCNo { get; set; }
        public string CodeNo { get; set; }
        public string CPONo { get; set; }
        public string PartyCode { get; set; }
        public string Party { get; set; }
        public string Model { get; set; }
        public string Ballsize { get; set; }
        public string BallMake { get; set; }
        public string WireMake { get; set; }
        public string Ild { get; set; }
        public string Date { get; set; }
        public string ink { get; set; }
        public string remark { get; set; }
        public Nullable<decimal> machineorder { get; set; }
        public string color { get; set; }
        public string ProductCode { get; set; }
        public string Product { get; set; }
        public string BallType { get; set; }
        public string Basket { get; set; }
        public string Spoon { get; set; }
        public string MachineType { get; set; }
        public Nullable<System.DateTime> UDate { get; set; }
        public string INKChanged { get; set; }
        public string ProdChanged { get; set; }
        public string DimChanged { get; set; }
        public string Shape { get; set; }
        public string SF { get; set; }

        public string TotalLen { get; set; }
        public string ShankDia { get; set; }
        public string ShankLen { get; set; }
        public string NeedleDia { get; set; }
        public string NeedleLen { get; set; }
        public string CustEL { get; set; }
        public string location_Id { get; set; }
        public string TipMaterial { get; set; }

    }

    public class ORDER_TYPE
    {
        public string order_type { get; set; }
        public string order_type_name { get; set; }


    }
    //----------------------------------------


    
}
