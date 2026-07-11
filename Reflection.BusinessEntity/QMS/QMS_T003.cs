using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.QMS
{
    public class QMS_T003 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set { _doc_no = value; RaisePropertyChanged("doc_no"); }
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

        private string _insp_type;
        public string insp_type
        {
            get { return _insp_type; }
            set { _insp_type = value; RaisePropertyChanged("insp_type"); }
        }

        private string _doc_source;
        public string doc_source
        {
            get { return _doc_source; }
            set { _doc_source = value; RaisePropertyChanged("doc_source"); }
        }

        private string _obj_no;
        public string obj_no
        {
            get { return _obj_no; }
            set { _obj_no = value; RaisePropertyChanged("obj_no"); }
        }

        private string _obj_cat;
        public string obj_cat
        {
            get { return _obj_cat; }
            set { _obj_cat = value; RaisePropertyChanged("obj_cat"); }
        }

        private string _sample_proc;
        public string sample_proc
        {
            get { return _sample_proc; }
            set { _sample_proc = value; RaisePropertyChanged("sample_proc"); }
        }

        private DateTime? _lot_create_date;
        public DateTime? lot_create_date
        {
            get { return _lot_create_date; }
            set { _lot_create_date = value; RaisePropertyChanged("lot_create_date"); }
        }

        private string _lot_create_time;
        public string lot_create_time
        {
            get { return _lot_create_time; }
            set { _lot_create_time = value; RaisePropertyChanged("lot_create_time"); }
        }

        private DateTime? _insp_start_date;
        public DateTime? insp_start_date
        {
            get { return _insp_start_date; }
            set { _insp_start_date = value; RaisePropertyChanged("insp_start_date"); }
        }

        private string _insp_start_time;
        public string insp_start_time
        {
            get { return _insp_start_time; }
            set { _insp_start_time = value; RaisePropertyChanged("insp_start_time"); }
        }

        private DateTime? _insp_end_date;
        public DateTime? insp_end_date
        {
            get { return _insp_end_date; }
            set { _insp_end_date = value; RaisePropertyChanged("insp_end_date"); }
        }

        private string _insp_end_time;
        public string insp_end_time
        {
            get { return _insp_end_time; }
            set { _insp_end_time = value; RaisePropertyChanged("insp_end_time"); }
        }

        private string _insp_point_type;
        public string insp_point_type
        {
            get { return _insp_point_type; }
            set { _insp_point_type = value; RaisePropertyChanged("insp_point_type"); }
        }

        private string _task_list_type;
        public string task_list_type
        {
            get { return _task_list_type; }
            set { _task_list_type = value; RaisePropertyChanged("task_list_type"); }
        }

        private string _tl_code;
        public string tl_code
        {
            get { return _tl_code; }
            set { _tl_code = value; RaisePropertyChanged("tl_code"); }
        }

        private string _task_list_usage;
        public string task_list_usage
        {
            get { return _task_list_usage; }
            set { _task_list_usage = value; RaisePropertyChanged("task_list_usage"); }
        }

        private string _sample_draw_proc;
        public string sample_draw_proc
        {
            get { return _sample_draw_proc; }
            set { _sample_draw_proc = value; RaisePropertyChanged("sample_draw_proc"); }
        }

        private string _item_code;
        public string item_code
        {
            get { return _item_code; }
            set { _item_code = value; RaisePropertyChanged("item_code"); }
        }

        private string _rev_level;
        public string rev_level
        {
            get { return _rev_level; }
            set { _rev_level = value; RaisePropertyChanged("rev_level"); }
        }

        private string _supplier_code;
        public string supplier_code
        {
            get { return _supplier_code; }
            set { _supplier_code = value; RaisePropertyChanged("supplier_code"); }
        }

        private string _mfg_no;
        public string mfg_no
        {
            get { return _mfg_no; }
            set { _mfg_no = value; RaisePropertyChanged("mfg_no"); }
        }

        private string _customer_code;
        public string customer_code
        {
            get { return _customer_code; }
            set { _customer_code = value; RaisePropertyChanged("customer_code"); }
        }

        private string _order_no;
        public string order_no
        {
            get { return _order_no; }
            set { _order_no = value; RaisePropertyChanged("order_no"); }
        }

        private int? _routing_no;
        public int? routing_no
        {
            get { return _routing_no; }
            set { _routing_no = value; RaisePropertyChanged("routing_no"); }
        }

        private string _ship_to_party;
        public string ship_to_party
        {
            get { return _ship_to_party; }
            set { _ship_to_party = value; RaisePropertyChanged("ship_to_party"); }
        }

        private string _sold_to_party;
        public string sold_to_party
        {
            get { return _sold_to_party; }
            set { _sold_to_party = value; RaisePropertyChanged("sold_to_party"); }
        }

        private string _vendor_code;
        public string vendor_code
        {
            get { return _vendor_code; }
            set { _vendor_code = value; RaisePropertyChanged("vendor_code"); }
        }

        private string _party_item_code;
        public string party_item_code
        {
            get { return _party_item_code; }
            set { _party_item_code = value; RaisePropertyChanged("party_item_code"); }
        }

        private string _ref_doc_type;
        public string ref_doc_type
        {
            get { return _ref_doc_type; }
            set { _ref_doc_type = value; RaisePropertyChanged("ref_doc_type"); }
        }

        private string _ref_doc_cat;
        public string ref_doc_cat
        {
            get { return _ref_doc_cat; }
            set { _ref_doc_cat = value; RaisePropertyChanged("ref_doc_cat"); }
        }

        private string _ref_doc_no;
        public string ref_doc_no
        {
            get { return _ref_doc_no; }
            set { _ref_doc_no = value; RaisePropertyChanged("ref_doc_no"); }
        }

        private int? _ref_doc_row_id;
        public int? ref_doc_row_id
        {
            get { return _ref_doc_row_id; }
            set { _ref_doc_row_id = value; RaisePropertyChanged("ref_doc_row_id"); }
        }

        private string _sono;
        public string sono
        {
            get { return _sono; }
            set { _sono = value; RaisePropertyChanged("sono"); }
        }

        private int? _so_item_row_id;
        public int? so_item_row_id
        {
            get { return _so_item_row_id; }
            set { _so_item_row_id = value; RaisePropertyChanged("so_item_row_id"); }
        }

        private string _po_no;
        public string po_no
        {
            get { return _po_no; }
            set { _po_no = value; RaisePropertyChanged("po_no"); }
        }

        private int? _po_item_row_id;
        public int? po_item_row_id
        {
            get { return _po_item_row_id; }
            set { _po_item_row_id = value; RaisePropertyChanged("po_item_row_id"); }
        }

        private int? _del_sch_row_id;
        public int? del_sch_row_id
        {
            get { return _del_sch_row_id; }
            set { _del_sch_row_id = value; RaisePropertyChanged("del_sch_row_id"); }
        }

        private string _so_code;
        public string so_code
        {
            get { return _so_code; }
            set { _so_code = value; RaisePropertyChanged("so_code"); }
        }

        private string _po_code;
        public string po_code
        {
            get { return _po_code; }
            set { _po_code = value; RaisePropertyChanged("po_code"); }
        }

        private string _delivery;
        public string delivery
        {
            get { return _delivery; }
            set { _delivery = value; RaisePropertyChanged("delivery"); }
        }

        private int? _delivery_items;
        public int? delivery_items
        {
            get { return _delivery_items; }
            set { _delivery_items = value; RaisePropertyChanged("delivery_items"); }
        }

        private string _delivery_type;
        public string delivery_type
        {
            get { return _delivery_type; }
            set { _delivery_type = value; RaisePropertyChanged("delivery_type"); }
        }

        private string _delivery_cat;
        public string delivery_cat
        {
            get { return _delivery_cat; }
            set { _delivery_cat = value; RaisePropertyChanged("delivery_cat"); }
        }

        private int? _route;
        public int? route
        {
            get { return _route; }
            set { _route = value; RaisePropertyChanged("route"); }
        }

        private string _country_code;
        public string country_code
        {
            get { return _country_code; }
            set { _country_code = value; RaisePropertyChanged("country_code"); }
        }

        private string _wa_code;
        public string wa_code
        {
            get { return _wa_code; }
            set { _wa_code = value; RaisePropertyChanged("wa_code"); }
        }

        private string _storage_type;
        public string storage_type
        {
            get { return _storage_type; }
            set { _storage_type = value; RaisePropertyChanged("storage_type"); }
        }
        private string _store_bin_code;
        public string store_bin_code
        {
            get { return _store_bin_code; }
            set { _store_bin_code = value; RaisePropertyChanged("store_bin_code"); }
        }

        private string _insp_stock_location_Id;
        public string insp_stock_location_Id
        {
            get { return _insp_stock_location_Id; }
            set { _insp_stock_location_Id = value; RaisePropertyChanged("insp_stock_location_Id"); }
        }

        private string _insp_stock_store_code;
        public string insp_stock_store_code
        {
            get { return _insp_stock_store_code; }
            set { _insp_stock_store_code = value; RaisePropertyChanged("insp_stock_store_code"); }
        }

        private string _mov_tp;
        public string mov_tp
        {
            get { return _mov_tp; }
            set { _mov_tp = value; RaisePropertyChanged("mov_tp"); }
        }

        private DateTime? _posting_date;
        public DateTime? posting_date
        {
            get { return _posting_date; }
            set { _posting_date = value; RaisePropertyChanged("posting_date"); }
        }

        private string _store_code;
        public string store_code
        {
            get { return _store_code; }
            set { _store_code = value; RaisePropertyChanged("store_code"); }
        }

        private string _item_code_2;
        public string item_code_2
        {
            get { return _item_code_2; }
            set { _item_code_2 = value; RaisePropertyChanged("item_code_2"); }
        }

        private string _rev_level_2;
        public string rev_level_2
        {
            get { return _rev_level_2; }
            set { _rev_level_2 = value; RaisePropertyChanged("rev_level_2"); }
        }

        private string _batch_no;
        public string batch_no
        {
            get { return _batch_no; }
            set { _batch_no = value; RaisePropertyChanged("batch_no"); }
        }

        private DateTime? _validity_date;
        public DateTime? validity_date
        {
            get { return _validity_date; }
            set { _validity_date = value; RaisePropertyChanged("validity_date"); }
        }

        private DateTime? _exp_date;
        public DateTime? exp_date
        {
            get { return _exp_date; }
            set { _exp_date = value; RaisePropertyChanged("exp_date"); }
        }

        private string _vendor_batch;
        public string vendor_batch
        {
            get { return _vendor_batch; }
            set { _vendor_batch = value; RaisePropertyChanged("vendor_batch"); }
        }

        private double? _insp_lot_qty;
        public double? insp_lot_qty
        {
            get { return _insp_lot_qty; }
            set { _insp_lot_qty = value; RaisePropertyChanged("insp_lot_qty"); }
        }

        private string _unit_code_base;
        public string unit_code_base
        {
            get { return _unit_code_base; }
            set { _unit_code_base = value; RaisePropertyChanged("unit_code_base"); }
        }

        private double? _sample_size;
        public double? sample_size
        {
            get { return _sample_size; }
            set { _sample_size = value; RaisePropertyChanged("sample_size"); }
        }

        private string _unit_code_sample;
        public string unit_code_sample
        {
            get { return _unit_code_sample; }
            set { _unit_code_sample = value; RaisePropertyChanged("unit_code_sample"); }
        }

        private string _insp_stage;
        public string insp_stage
        {
            get { return _insp_stage; }
            set { _insp_stage = value; RaisePropertyChanged("insp_stage"); }
        }

        private string _insp_severity;
        public string insp_severity
        {
            get { return _insp_severity; }
            set { _insp_severity = value; RaisePropertyChanged("insp_severity"); }
        }

        private double? _qty_unrestrict_stock;
        public double? qty_unrestrict_stock
        {
            get { return _qty_unrestrict_stock; }
            set { _qty_unrestrict_stock = value; RaisePropertyChanged("qty_unrestrict_stock"); }
        }

        private double? _qty_scrap;
        public double? qty_scrap
        {
            get { return _qty_scrap; }
            set { _qty_scrap = value; RaisePropertyChanged("qty_scrap"); }
        }

        private double? _qty_sample;
        public double? qty_sample
        {
            get { return _qty_sample; }
            set { _qty_sample = value; RaisePropertyChanged("qty_sample"); }
        }

        private double? _qty_block_stock;
        public double? qty_block_stock
        {
            get { return _qty_block_stock; }
            set { _qty_block_stock = value; RaisePropertyChanged("qty_block_stock"); }
        }

        private double? _qty_reserves;
        public double? qty_reserves
        {
            get { return _qty_reserves; }
            set { _qty_reserves = value; RaisePropertyChanged("qty_reserves"); }
        }

        private double? _qty_material;
        public double? qty_material
        {
            get { return _qty_material; }
            set { _qty_material = value; RaisePropertyChanged("qty_material"); }
        }

        private string _post_item_code;
        public string post_item_code
        {
            get { return _post_item_code; }
            set { _post_item_code = value; RaisePropertyChanged("post_item_code"); }
        }

        private string _batch_transferred;
        public string batch_transferred
        {
            get { return _batch_transferred; }
            set { _batch_transferred = value; RaisePropertyChanged("batch_transferred"); }
        }

        private double? _qty_vendor;
        public double? qty_vendor
        {
            get { return _qty_vendor; }
            set { _qty_vendor = value; RaisePropertyChanged("qty_vendor"); }
        }

        private double? _qty_other_stock;
        public double? qty_other_stock
        {
            get { return _qty_other_stock; }
            set { _qty_other_stock = value; RaisePropertyChanged("qty_other_stock"); }
        }

        private double? _qty_other_stock_2;
        public double? qty_other_stock_2
        {
            get { return _qty_other_stock_2; }
            set { _qty_other_stock_2 = value; RaisePropertyChanged("qty_other_stock_2"); }
        }

        private double? _qty_posted;
        public double? qty_posted
        {
            get { return _qty_posted; }
            set { _qty_posted = value; RaisePropertyChanged("qty_posted"); }
        }

        private double? _qty_inspected;
        public double? qty_inspected
        {
            get { return _qty_inspected; }
            set { _qty_inspected = value; RaisePropertyChanged("qty_inspected"); }
        }

        private double? _qty_destroyed;
        public double? qty_destroyed
        {
            get { return _qty_destroyed; }
            set { _qty_destroyed = value; RaisePropertyChanged("qty_destroyed"); }
        }

        private double? _qty_actual;
        public double? qty_actual
        {
            get { return _qty_actual; }
            set { _qty_actual = value; RaisePropertyChanged("qty_actual"); }
        }

        private double? _qty_defective;
        public double? qty_defective
        {
            get { return _qty_defective; }
            set { _qty_defective = value; RaisePropertyChanged("qty_defective"); }
        }

        private string _ind_logs_decision;
        public string ind_logs_decision
        {
            get { return _ind_logs_decision; }
            set { _ind_logs_decision = value; RaisePropertyChanged("ind_logs_decision"); }
        }

        private double? _qty_insp_scrap;
        public double? qty_insp_scrap
        {
            get { return _qty_insp_scrap; }
            set { _qty_insp_scrap = value; RaisePropertyChanged("qty_insp_scrap"); }
        }

        private string _qual_cal_proc;
        public string qual_cal_proc
        {
            get { return _qual_cal_proc; }
            set { _qual_cal_proc = value; RaisePropertyChanged("qual_cal_proc"); }
        }

        private double? _qty_allowed_scrap;
        public double? qty_allowed_scrap
        {
            get { return _qty_allowed_scrap; }
            set { _qty_allowed_scrap = value; RaisePropertyChanged("qty_allowed_scrap"); }
        }

        private string _consumption_posting;
        public string consumption_posting
        {
            get { return _consumption_posting; }
            set { _consumption_posting = value; RaisePropertyChanged("consumption_posting"); }
        }

        private string _account_cat;
        public string account_cat
        {
            get { return _account_cat; }
            set { _account_cat = value; RaisePropertyChanged("account_cat"); }
        }

        private string _po_item_cat;
        public string po_item_cat
        {
            get { return _po_item_cat; }
            set { _po_item_cat = value; RaisePropertyChanged("po_item_cat"); }
        }

        private string _account_key;
        public string account_key
        {
            get { return _account_key; }
            set { _account_key = value; RaisePropertyChanged("account_key"); }
        }

        private string _cost_center;
        public string cost_center
        {
            get { return _cost_center; }
            set { _cost_center = value; RaisePropertyChanged("cost_center"); }
        }

        private string _asset_number;
        public string asset_number
        {
            get { return _asset_number; }
            set { _asset_number = value; RaisePropertyChanged("asset_number"); }
        }

        private string _asset_subnumber;
        public string asset_subnumber
        {
            get { return _asset_subnumber; }
            set { _asset_subnumber = value; RaisePropertyChanged("asset_subnumber"); }
        }

        private string _profit_center;
        public string profit_center
        {
            get { return _profit_center; }
            set { _profit_center = value; RaisePropertyChanged("profit_center"); }
        }

        private string _business_area;
        public string business_area
        {
            get { return _business_area; }
            set { _business_area = value; RaisePropertyChanged("business_area"); }
        }

        private string _gl_code;
        public string gl_code
        {
            get { return _gl_code; }
            set { _gl_code = value; RaisePropertyChanged("gl_code"); }
        }

        private string _ref_insp_lot_no;
        public string ref_insp_lot_no
        {
            get { return _ref_insp_lot_no; }
            set { _ref_insp_lot_no = value; RaisePropertyChanged("ref_insp_lot_no"); }
        }

        private string _insp_stab_study;
        public string insp_stab_study
        {
            get { return _insp_stab_study; }
            set { _insp_stab_study = value; RaisePropertyChanged("insp_stab_study"); }
        }

        private string _maint_plan;
        public string maint_plan
        {
            get { return _maint_plan; }
            set { _maint_plan = value; RaisePropertyChanged("maint_plan"); }
        }

        private string _maint_item;
        public string maint_item
        {
            get { return _maint_item; }
            set { _maint_item = value; RaisePropertyChanged("maint_item"); }
        }

        private int? _maint_call_no;
        public int? maint_call_no
        {
            get { return _maint_call_no; }
            set { _maint_call_no = value; RaisePropertyChanged("maint_call_no"); }
        }

        private string _maint_strategy;
        public string maint_strategy
        {
            get { return _maint_strategy; }
            set { _maint_strategy = value; RaisePropertyChanged("maint_strategy"); }
        }

        private string _trial_no;
        public string trial_no
        {
            get { return _trial_no; }
            set { _trial_no = value; RaisePropertyChanged("trial_no"); }
        }

        private string _emp_id;
        public string emp_id
        {
            get { return _emp_id; }
            set { _emp_id = value; RaisePropertyChanged("emp_id"); }
        }

        private string _barcode;
        public string barcode
        {
            get { return _barcode; }
            set { _barcode = value; RaisePropertyChanged("barcode"); }
        }

        private string _ind_block_stock;
        public string ind_block_stock
        {
            get { return _ind_block_stock; }
            set { _ind_block_stock = value; RaisePropertyChanged("ind_block_stock"); }
        }

        private string _ind_qty_status;
        public string ind_qty_status
        {
            get { return _ind_qty_status; }
            set { _ind_qty_status = value; RaisePropertyChanged("ind_qty_status"); }
        }

        private string _ind_insp_lot_creattion;
        public string ind_insp_lot_creattion
        {
            get { return _ind_insp_lot_creattion; }
            set { _ind_insp_lot_creattion = value; RaisePropertyChanged("ind_insp_lot_creattion"); }
        }

        private string _ind_partial_lot;
        public string ind_partial_lot
        {
            get { return _ind_partial_lot; }
            set { _ind_partial_lot = value; RaisePropertyChanged("ind_partial_lot"); }
        }

        private string _ind_insp_point;
        public string ind_insp_point
        {
            get { return _ind_insp_point; }
            set { _ind_insp_point = value; RaisePropertyChanged("ind_insp_point"); }
        }

        private string _ind_usage_decision;
        public string ind_usage_decision
        {
            get { return _ind_usage_decision; }
            set { _ind_usage_decision = value; RaisePropertyChanged("ind_usage_decision"); }
        }

        private string _ind_insp_source;
        public string ind_insp_source
        {
            get { return _ind_insp_source; }
            set { _ind_insp_source = value; RaisePropertyChanged("ind_insp_source"); }
        }

        private string _ind_ref_doc_no;
        public string ind_ref_doc_no
        {
            get { return _ind_ref_doc_no; }
            set { _ind_ref_doc_no = value; RaisePropertyChanged("ind_ref_doc_no"); }
        }

        private string _ind_insp_plan;
        public string ind_insp_plan
        {
            get { return _ind_insp_plan; }
            set { _ind_insp_plan = value; RaisePropertyChanged("ind_insp_plan"); }
        }

        private string _ind_sample;
        public string ind_sample
        {
            get { return _ind_sample; }
            set { _ind_sample = value; RaisePropertyChanged("ind_sample"); }
        }

        private string _ind_insp_approval;
        public string ind_insp_approval
        {
            get { return _ind_insp_approval; }
            set { _ind_insp_approval = value; RaisePropertyChanged("ind_insp_approval"); }
        }

        private string _ind_char;
        public string ind_char
        {
            get { return _ind_char; }
            set { _ind_char = value; RaisePropertyChanged("ind_char"); }
        }

        private string _ind_sample_cal;
        public string ind_sample_cal
        {
            get { return _ind_sample_cal; }
            set { _ind_sample_cal = value; RaisePropertyChanged("ind_sample_cal"); }
        }

        private string _ind_stock_posting;
        public string ind_stock_posting
        {
            get { return _ind_stock_posting; }
            set { _ind_stock_posting = value; RaisePropertyChanged("ind_stock_posting"); }
        }

        private string _ind_status_uasge_decision;
        public string ind_status_uasge_decision
        {
            get { return _ind_status_uasge_decision; }
            set { _ind_status_uasge_decision = value; RaisePropertyChanged("ind_status_uasge_decision"); }
        }

        private string _ind_lot_skipped;
        public string ind_lot_skipped
        {
            get { return _ind_lot_skipped; }
            set { _ind_lot_skipped = value; RaisePropertyChanged("ind_lot_skipped"); }
        }

        private string _ind_allow_skipped;
        public string ind_allow_skipped
        {
            get { return _ind_allow_skipped; }
            set { _ind_allow_skipped = value; RaisePropertyChanged("ind_allow_skipped"); }
        }

        private string _ind_complete_insp;
        public string ind_complete_insp
        {
            get { return _ind_complete_insp; }
            set { _ind_complete_insp = value; RaisePropertyChanged("ind_complete_insp"); }
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

        private DateTime? _doc_date;
        public DateTime? doc_date
        {
            get { return _doc_date; }
            set { _doc_date = value; RaisePropertyChanged("doc_date"); }
        }

        private string _location_id;
        public string location_id
        {
            get { return _location_id; }
            set { _location_id = value; RaisePropertyChanged("location_id"); }
        }

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }

        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set { _lang_key = value; RaisePropertyChanged("lang_key"); }
        }

        private string _cp_name;
        public string cp_name
        {
            get { return _cp_name; }
            set { _cp_name = value; RaisePropertyChanged("cp_name"); }
        }

        private string _cp_code;
        public string cp_code
        {
            get { return _cp_code; }
            set { _cp_code = value; RaisePropertyChanged("cp_code"); }
        }

        private string _insp_cat;
        public string insp_cat
        {
            get { return _insp_cat; }
            set { _insp_cat = value; RaisePropertyChanged("insp_cat"); }
        }

        public string XmlDataDocument_QMS_T003_Flip { get; set; }

        //Scalar

        private string _OriginName;
        public string OriginName
        {
            get { return _OriginName; }
            set { _OriginName = value; RaisePropertyChanged("OriginName"); }
        }

        private string _item_name;
        public string item_name
        {
            get { return _item_name; }
            set { _item_name = value; RaisePropertyChanged("item_name"); }
        }
        private string _PurOrgNm;
        public string PurOrgNm
        {
            get { return _PurOrgNm; }
            set { _PurOrgNm = value; RaisePropertyChanged("PurOrgNm"); }
        }

        private string _notes;
        public string notes
        {
            get { return _notes; }
            set { _source = value; RaisePropertyChanged("notes"); }
        }

        private string _source;
        public string source
        {
            get { return _source; }
            set { _source = value; RaisePropertyChanged("source"); }
        }

        private string _party_name;
        public string party_name
        {
            get { return _party_name; }
            set { _party_name = value; RaisePropertyChanged("party_name"); }
        }

        private string _customer_name;
        public string customer_name
        {
            get { return _customer_name; }
            set { _customer_name = value; RaisePropertyChanged("customer_name"); }
        }

        private string _supplier_name;
        public string supplier_name
        {
            get { return _supplier_name; }
            set { _supplier_name = value; RaisePropertyChanged("supplier_name"); }
        }

        private string _MfgNm;
        public string MfgNm
        {
            get { return _MfgNm; }
            set { _MfgNm = value; RaisePropertyChanged("MfgNm"); }
        }

        private string _insp_typeNm;
        public string insp_typeNm
        {
            get { return _insp_typeNm; }
            set { _insp_typeNm = value; RaisePropertyChanged("insp_typeNm"); }
        }

        private string _buyer;
        public string buyer
        {
            get { return _buyer; }
            set { _buyer = value; RaisePropertyChanged("buyer"); }
        }

        private string _grn_by;
        public string grn_by
        {
            get { return _grn_by; }
            set { _grn_by = value; RaisePropertyChanged("grn_by"); }
        }

        private string _t_display;
        public string t_display
        {
            get { return _t_display; }
            set { _t_display = value; RaisePropertyChanged("t_display"); }
        }
        private bool? _selected;
        public bool? selected
        {
            get { return _selected; }
            set { _selected = value; RaisePropertyChanged("selected"); }
        }
        private string _ts_namespace;
        public string ts_namespace
        {
            get { return _ts_namespace; }
            set { _ts_namespace = value; RaisePropertyChanged("ts_namespace"); }
        }
        private string _ts_class_file;
        public string ts_class_file
        {
            get { return _ts_class_file; }
            set { _ts_class_file = value; RaisePropertyChanged("ts_class_file"); }
        }

        private string _doc_desc;
        public string doc_desc
        {
            get { return _doc_desc; }
            set { _doc_desc = value; RaisePropertyChanged("doc_desc"); }
        }


        private float _age;
        public float age
        {
            get { return _age; }
            set { _age = value; RaisePropertyChanged("age"); }
        }
        private string _gender;
        public string gender
        {
            get { return _gender; }
            set { _gender = value; RaisePropertyChanged("gender"); }
        }
        private string _party_code;
        public string party_code
        {
            get { return _party_code; }
            set { _party_code = value; RaisePropertyChanged("party_code"); }
        }
        private string _ref_party;
        public string ref_party
        {
            get { return _ref_party; }
            set { _ref_party = value; RaisePropertyChanged("ref_party"); }
        }
        private string _cons_party;
        public string cons_party
        {
            get { return _cons_party; }
            set { _cons_party = value; RaisePropertyChanged("cons_party"); }
        }
        private string _coll_branch;
        public string coll_branch
        {
            get { return _coll_branch; }
            set { _coll_branch = value; RaisePropertyChanged("coll_branch"); }

        }
        private DateTime? _so_date;
        public DateTime? so_date
        {
            get { return _so_date; }
            set { _so_date = value; RaisePropertyChanged("so_date"); }
        }
        private DateTime? _rel_date;
        public DateTime? rel_date
        {
            get { return _rel_date; }
            set { _rel_date = value; RaisePropertyChanged("rel_date"); }
        }

        private string _emp_name;
        public string emp_name
        {
            get { return _emp_name; }
            set { _emp_name = value; RaisePropertyChanged("emp_name"); }
        }
        private string _tl_name;
        public string tl_name
        {
            get { return _tl_name; }
            set { _tl_name = value; RaisePropertyChanged("tl_name"); }
        }
        private string _short_text;
        public string short_text
        {
            get { return _short_text; }
            set { _short_text = value; RaisePropertyChanged("short_text"); }
        }
        public string wc_name { get; set; }
        public string para1 { get; set; }
        public string para2 { get; set; }
        public string para3 { get; set; }
        // Scallar
        private string _wc_code;
        public string wc_code
        {
            get { return _wc_code; }
            set { _wc_code = value; RaisePropertyChanged("wc_code"); }
        }
        public string plan_no { get; set; }
        public string XDOC_A { get; set; }
        public string XDOC_B { get; set; }
        public string XDOC_C { get; set; }
        public string XDOC_D { get; set; }
        public string XDOC_E { get; set; }
        public string XDOC_N { get; set; }
        public string XDOC_U { get; set; }
        private string _ip_text;
        public string ip_text
        {
            get { return _ip_text; }
            set { _ip_text = value; RaisePropertyChanged("ip_text"); }
        }
    }

    public class QMS_T003_A : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int? _id;
        public int? id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }
        
        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set { _doc_no = value; RaisePropertyChanged("doc_no"); }
        }

        private int? _line_no;
        public int? line_no
        {
            get { return _line_no; }
            set { _line_no = value; RaisePropertyChanged("line_no"); }
        }
        private string _char_code;
        public string char_code
        {
            get { return _char_code; }
            set { _char_code = value; RaisePropertyChanged("char_code"); }
        }

        private int? _mic_line_id;
        public int? mic_line_id
        {
            get { return _mic_line_id; }
            set { _mic_line_id = value; RaisePropertyChanged("mic_line_id"); }
        }

        private int? _sample_no;
        public int? sample_no
        {
            get { return _sample_no; }
            set { _sample_no = value; RaisePropertyChanged("sample_no"); }
        }

        private int? _valid_sample_no;
        public int? valid_sample_no
        {
            get { return _valid_sample_no; }
            set { _valid_sample_no = value; RaisePropertyChanged("valid_sample_no"); }
        }

        private string _r_status;
        public string r_status
        {
            get { return _r_status; }
            set { _r_status = value; RaisePropertyChanged("r_status"); }
        }

        private string _attribute;
        public string attribute
        {
            get { return _attribute; }
            set { _attribute = value; RaisePropertyChanged("attribute"); }
        }
        private string _ind_source;
        public string ind_source
        {
            get { return _ind_source; }
            set { _ind_source = value; RaisePropertyChanged("ind_source"); }
        }
        private string _ind_equipment;
        public string ind_equipment
        {
            get { return _ind_equipment; }
            set { _ind_equipment = value; RaisePropertyChanged("ind_equipment"); }
        }
        private string _v_code;
        public string v_code
        {
            get { return _v_code; }
            set { _v_code = value; RaisePropertyChanged("v_code"); }
        }

        private string _v_code_dm;
        public string v_code_dm
        {
            get { return _v_code_dm; }
            set { _v_code_dm = value; RaisePropertyChanged("v_code_dm"); }
        }

        private string _inspector;
        public string inspector
        {
            get { return _inspector; }
            set { _inspector = value; RaisePropertyChanged("inspector"); }
        }
        public DateTime? _start_date;
        public DateTime? start_date
        {
            get { return _start_date; }
            set { _start_date = value; RaisePropertyChanged("start_date"); }
        }
        public DateTime? _end_date;
        public DateTime? end_date
        {
            get { return _end_date; }
            set { _end_date = value; RaisePropertyChanged("end_date"); }
        }
        private string _short_desc;
        public string short_desc
        {
            get { return _short_desc; }
            set { _short_desc = value; RaisePropertyChanged("short_desc"); }
        }
        private int? _sample_recorded;
        public int? sample_recorded
        {
            get { return _sample_recorded; }
            set { _sample_recorded = value; RaisePropertyChanged("sample_recorded"); }
        }
        private int? _sample_nonc { get; set; } //(int, null)
        public int? sample_nonc
        {
            get { return _sample_nonc; }
            set { _sample_nonc = value; RaisePropertyChanged("sample_nonc"); }
        }
        private int? _defect_no;
        public int? defect_no
        {
            get { return _defect_no; }
            set { _defect_no = value; RaisePropertyChanged("defect_no"); }
        }
        private int? _above_values;
        public int? above_values
        {
            get { return _above_values; }
            set { _above_values = value; RaisePropertyChanged("above_values"); }
        }
        private int? _below_values;
        public int? below_values
        {
            get { return _below_values; }
            set { _below_values = value; RaisePropertyChanged("below_values"); }
        }
        private int? _sample_inspected;
        public int? sample_inspected
        {
            get { return _sample_inspected; }
            set { _sample_inspected = value; RaisePropertyChanged("sample_inspected"); }
        }
        public double? _max_value;
        public double? max_value
        {
            get { return _max_value; }
            set { _max_value = value; RaisePropertyChanged("max_value"); }
        }
        public double? _min_value;
        public double? min_value
        {
            get { return _min_value; }
            set { _min_value = value; RaisePropertyChanged("min_value"); }
        }
        public double? _median_value;
        public double? median_value
        {
            get { return _median_value; }
            set { _median_value = value; RaisePropertyChanged("median_value"); }
        }
        public double? _mean_value;
        public double? mean_value
        {
            get { return _mean_value; }
            set { _mean_value = value; RaisePropertyChanged("mean_value"); }
        }
        private int? _sample_valid;
        public int? sample_valid
        {
            get { return _sample_valid; }
            set { _sample_valid = value; RaisePropertyChanged("sample_valid"); }
        }
        private string _para_type;
        public string para_type
        {
            get { return _para_type; }
            set { _para_type = value; RaisePropertyChanged("para_type"); }
        }
        private string _para_code;
        public string para_code
        {
            get { return _para_code; }
            set { _para_code = value; RaisePropertyChanged("para_code"); }
        }
        //private string _value_code;
        //public string value_code
        //{
        //    get { return _value_code; }
        //    set { _value_code = value; RaisePropertyChanged("value_code"); }
        //}
        private string _char_value;
        public string char_value
        {
            get { return _char_value; }
            set
            {
                if (_char_value != value)
                {
                    _char_value = value; RaisePropertyChanged("char_value", ModelEntityUpdated);
                }
            }
        }
        private string _version;
        public string version
        {
            get { return _version; }
            set { _version = value; RaisePropertyChanged("version"); }
        }
        private string _defect_class;
        public string defect_class
        {
            get { return _defect_class; }
            set { _defect_class = value; RaisePropertyChanged("defect_class"); }
        }
        private string _equipment;
        public string equipment
        {
            get { return _equipment; }
            set { _equipment = value; RaisePropertyChanged("equipment"); }
        }
        public DateTime _add_date;
        public DateTime add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
        }
        public string _active;
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
        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set { _lang_key = value; RaisePropertyChanged("lang_key"); }
        }
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }
        private string _location_id;
        public string location_id
        {
            get { return _location_id; }
            set { _location_id = value; RaisePropertyChanged("location_id"); }
        }
        private string _fun_loc;
        public string fun_loc
        {
            get { return _fun_loc; }
            set { _fun_loc = value; RaisePropertyChanged("fun_loc"); }
        }
        private string _ind_complete;
        public string ind_complete
        {
            get { return _ind_complete; }
            set { _ind_complete = value; RaisePropertyChanged("ind_complete"); }
        }
        private string _insp_level;
        public string insp_level
        {
            get { return _insp_level; }
            set
            {
                _insp_level = value;
                RaisePropertyChanged("insp_level", ModelEntityUpdated);
            }
        }
        private string _op_no;
        public string op_no
        {
            get { return _op_no; }
            set
            {
                _op_no = value;
                RaisePropertyChanged("op_no", ModelEntityUpdated);
            }
        }
        private int? _op_seq;
        public int? op_seq
        {
            get { return _op_seq; }
            set
            {
                _op_seq = value;
                RaisePropertyChanged("op_seq", ModelEntityUpdated);
            }
        }
        private int? _line_id_op;
        public int? line_id_op
        {
            get { return _line_id_op; }
            set
            {
                _line_id_op = value;
                RaisePropertyChanged("line_id_op", ModelEntityUpdated);
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

        // Scalar
        private string _specifications;
        public string specifications
        {
            get { return _specifications; }
            set
            {
                _specifications = value;
                RaisePropertyChanged("specifications");
            }
        }
        public string char_spec { get; set; }
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
        private double? _sample_size;
        public double? sample_size
        {
            get { return _sample_size; }
            set { _sample_size = value; RaisePropertyChanged("sample_size"); }
        }
        private string _char_name;
        public string char_name
        {
            get { return _char_name; }
            set { _char_name = value; RaisePropertyChanged("char_name"); }
        }
        private string _char_result;
        public string char_result
        {
            get { return _char_result; }
            set { _char_result = value; RaisePropertyChanged("char_result", ModelEntityUpdated); }
        }
        private string _char_type;
        public string char_type
        {
            get { return _char_type; }
            set { _char_type = value; RaisePropertyChanged("char_type", ModelEntityUpdated); }
        }
        private string _v_code_text;
        public string v_code_text
        {
            get { return _v_code_text; }
            set { _v_code_text = value; RaisePropertyChanged("v_code_text"); }
        }

        private double? _low_limit;
        public double? low_limit
        {
            get { return _low_limit; }
            set { _low_limit = value; RaisePropertyChanged("low_limit"); }
        }
        private double? _up_limit;
        public double? up_limit
        {
            get { return _up_limit; }
            set { _up_limit = value; RaisePropertyChanged("up_limit"); }
        }
        private double? _target_value;
        public double? target_value
        {
            get { return _target_value; }
            set { _target_value = value; RaisePropertyChanged("target_value"); }
        }
        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code"); }
        }

        private int? _line_id_a;
        public int? line_id_a
        {
            get { return _line_id_a; }
            set { _line_id_a = value; RaisePropertyChanged("line_id_a"); }
        }
        private string _ind_char;
        public string ind_char
        {
            get { return _ind_char; }
            set { _ind_char = value; RaisePropertyChanged("ind_char"); }
        }
        private string _sample_uom;
        public string sample_uom
        {
            get { return _sample_uom; }
            set { _sample_uom = value; RaisePropertyChanged("sample_uom"); }
        }
        private int? _no_of_char;
        public int? no_of_char
        {
            get { return _no_of_char; }
            set { _no_of_char = value; RaisePropertyChanged("no_of_char"); }
        }
        private int? _no_of_dec;
        public int? no_of_dec
        {
            get { return _no_of_dec; }
            set { _no_of_dec = value; RaisePropertyChanged("no_of_dec"); }
        }
        private string _ind_case;
        public string ind_case
        {
            get { return _ind_case; }
            set { _ind_case = value; RaisePropertyChanged("ind_case"); }
        }
        private string _ind_mv;
        public string ind_mv
        {
            get { return _ind_mv; }
            set { _ind_mv = value; RaisePropertyChanged("ind_mv"); }
        }
        private string _ind_interval;
        public string ind_interval
        {
            get { return _ind_interval; }
            set { _ind_interval = value; RaisePropertyChanged("ind_interval"); }
        }
        private string _long_text;
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

        private string _fcode;
        public string fcode
        {
            get { return _fcode; }
            set
            {
                if (_fcode != value)
                {
                    _fcode = value; RaisePropertyChanged("fcode");
                }
            }
        }
        private string _formula1;
        public string formula1
        {
            get { return _formula1; }
            set
            {
                if (_formula1 != value)
                {
                    _formula1 = value; RaisePropertyChanged("formula1");
                }
            }
        }
        private string _formula2;
        public string formula2
        {
            get { return _formula2; }
            set
            {
                if (_formula2 != value)
                {
                    _formula2 = value; RaisePropertyChanged("formula2");
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
                    _group_name = value; RaisePropertyChanged("group_name");
                }
            }
        }
        private string _tl_name;
        public string tl_name
        {
            get { return _tl_name; }
            set { _tl_name = value; RaisePropertyChanged("tl_name"); }
        }
        private string _usage_text;
        public string usage_text
        {
            get { return _usage_text; }
            set { _usage_text = value; RaisePropertyChanged("usage_text"); }
        }
        private string _method_name;
        public string method_name
        {
            get { return _method_name; }
            set { _method_name = value; RaisePropertyChanged("method_name"); }
        }

        private int? _char_seq;
        public int? char_seq
        {
            get { return _char_seq; }
            set { _char_seq = value; RaisePropertyChanged("_char_seq"); }
        }
        private string _ip_text;
        public string ip_text
        {
            get { return _ip_text; }
            set { _ip_text = value; RaisePropertyChanged("ip_text"); }
        }
    }

    public class QMS_T003_B : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int? _id;
        public int? id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }
        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set { _doc_no = value; RaisePropertyChanged("doc_no"); }
        }

        private int? _line_no;
        public int? line_no
        {
            get { return _line_no; }
            set { _line_no = value; RaisePropertyChanged("line_no"); }
        }

        private int? _mic_line_id;
        public int? mic_line_id
        {
            get { return _mic_line_id; }
            set { _mic_line_id = value; RaisePropertyChanged("mic_line_id"); }
        }
        private string _char_code;
        public string char_code
        {
            get { return _char_code; }
            set { _char_code = value; RaisePropertyChanged("char_code"); }
        }
        private int? _sample_no;
        public int? sample_no
        {
            get { return _sample_no; }
            set { _sample_no = value; RaisePropertyChanged("sample_no"); }
        }
        private int? _valid_sample_no;
        public int? valid_sample_no
        {
            get { return _valid_sample_no; }
            set { _valid_sample_no = value; RaisePropertyChanged("valid_sample_no"); }
        }
        private string _r_status;
        public string r_status
        {
            get { return _r_status; }
            set { _r_status = value; RaisePropertyChanged("r_status"); }
        }

        private string _attribute;
        public string attribute
        {
            get { return _attribute; }
            set { _attribute = value; RaisePropertyChanged("attribute"); }
        }
        private string _ind_source;
        public string ind_source
        {
            get { return _ind_source; }
            set { _ind_source = value; RaisePropertyChanged("ind_source"); }
        }
        private string _ind_equipment;
        public string ind_equipment
        {
            get { return _ind_equipment; }
            set { _ind_equipment = value; RaisePropertyChanged("ind_equipment"); }
        }
        private string _v_code;
        public string v_code
        {
            get { return _v_code; }
            set { _v_code = value; RaisePropertyChanged("v_code"); }
        }

        private string _v_code_dm;
        public string v_code_dm
        {
            get { return _v_code_dm; }
            set { _v_code_dm = value; RaisePropertyChanged("v_code_dm"); }
        }

        private string _inspector;
        public string inspector
        {
            get { return _inspector; }
            set { _inspector = value; RaisePropertyChanged("inspector"); }
        }
        public DateTime? _start_date;
        public DateTime? start_date
        {
            get { return _start_date; }
            set { _start_date = value; RaisePropertyChanged("start_date"); }
        }
        public DateTime? _end_date;
        public DateTime? end_date
        {
            get { return _end_date; }
            set { _end_date = value; RaisePropertyChanged("end_date"); }
        }
        private string _short_desc;
        public string short_desc
        {
            get { return _short_desc; }
            set { _short_desc = value; RaisePropertyChanged("short_desc"); }
        }
        private int? _sample_recorded;
        public int? sample_recorded
        {
            get { return _sample_recorded; }
            set { _sample_recorded = value; RaisePropertyChanged("sample_recorded"); }
        }
        private int? _sample_nonc { get; set; } //(int, null)
        public int? sample_nonc
        {
            get { return _sample_nonc; }
            set { _sample_nonc = value; RaisePropertyChanged("sample_nonc"); }
        }
        private int? _defect_no;
        public int? defect_no
        {
            get { return _defect_no; }
            set { _defect_no = value; RaisePropertyChanged("defect_no"); }
        }
        private int? _above_values;
        public int? above_values
        {
            get { return _above_values; }
            set { _above_values = value; RaisePropertyChanged("above_values"); }
        }
        private int? _below_values;
        public int? below_values
        {
            get { return _below_values; }
            set { _below_values = value; RaisePropertyChanged("below_values"); }
        }
        private int? _sample_inspected;
        public int? sample_inspected
        {
            get { return _sample_inspected; }
            set { _sample_inspected = value; RaisePropertyChanged("sample_inspected"); }
        }
        public double? _max_value;
        public double? max_value
        {
            get { return _max_value; }
            set { _max_value = value; RaisePropertyChanged("max_value"); }
        }
        public double? _min_value;
        public double? min_value
        {
            get { return _min_value; }
            set { _min_value = value; RaisePropertyChanged("min_value"); }
        }
        public double? _median_value;
        public double? median_value
        {
            get { return _median_value; }
            set { _median_value = value; RaisePropertyChanged("median_value"); }
        }
        public double? _mean_value;
        public double? mean_value
        {
            get { return _mean_value; }
            set { _mean_value = value; RaisePropertyChanged("mean_value"); }
        }
        private int? _sample_valid;
        public int? sample_valid
        {
            get { return _sample_valid; }
            set { _sample_valid = value; RaisePropertyChanged("sample_valid"); }
        }
        private string _para_type;
        public string para_type
        {
            get { return _para_type; }
            set { _para_type = value; RaisePropertyChanged("para_type"); }
        }
        private string _para_code;
        public string para_code
        {
            get { return _para_code; }
            set { _para_code = value; RaisePropertyChanged("para_code"); }
        }
        //private string _value_code;
        //public string value_code
        //{
        //    get { return _value_code; }
        //    set { _value_code = value; RaisePropertyChanged("value_code"); }
        //}
        private string _char_value;
        public string char_value
        {
            get { return _char_value; }
            set
            {
                if (_char_value != value)
                {
                    _char_value = value; RaisePropertyChanged("char_value", ModelEntityUpdated);
                }
            }
        }
        private string _version;
        public string version
        {
            get { return _version; }
            set { _version = value; RaisePropertyChanged("version"); }
        }
        private string _defect_class;
        public string defect_class
        {
            get { return _defect_class; }
            set { _defect_class = value; RaisePropertyChanged("defect_class"); }
        }
        private string _equipment;
        public string equipment
        {
            get { return _equipment; }
            set { _equipment = value; RaisePropertyChanged("equipment"); }
        }
        public DateTime _add_date;
        public DateTime add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
        }
        public string _active;
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
        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set { _lang_key = value; RaisePropertyChanged("lang_key"); }
        }
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }
        private string _location_id;
        public string location_id
        {
            get { return _location_id; }
            set { _location_id = value; RaisePropertyChanged("location_id"); }
        }
        private string _lab_code;
        public string lab_code
        {
            get { return _lab_code; }
            set { _lab_code = value; RaisePropertyChanged("lab_code"); }
        }
        private string _ind_complete;
        public string ind_complete
        {
            get { return _ind_complete; }
            set { _ind_complete = value; RaisePropertyChanged("ind_complete"); }
        }
        private string _insp_level;
        public string insp_level
        {
            get { return _insp_level; }
            set
            {
                _insp_level = value;
                RaisePropertyChanged("insp_level", ModelEntityUpdated);
            }
        }
        private string _op_no;
        public string op_no
        {
            get { return _op_no; }
            set
            {
                _op_no = value;
                RaisePropertyChanged("op_no", ModelEntityUpdated);
            }
        }
        private int? _op_seq;
        public int? op_seq
        {
            get { return _op_seq; }
            set
            {
                _op_seq = value;
                RaisePropertyChanged("op_seq", ModelEntityUpdated);
            }
        }
        private int? _line_id_op;
        public int? line_id_op
        {
            get { return _line_id_op; }
            set
            {
                _line_id_op = value;
                RaisePropertyChanged("line_id_op", ModelEntityUpdated);
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

        // Scalar
        private string _specifications;
        public string specifications
        {
            get { return _specifications; }
            set
            {
                _specifications = value;
                RaisePropertyChanged("specifications");
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
        private double? _sample_size;
        public double? sample_size
        {
            get { return _sample_size; }
            set { _sample_size = value; RaisePropertyChanged("sample_size"); }
        }
        private string _char_name;
        public string char_name
        {
            get { return _char_name; }
            set { _char_name = value; RaisePropertyChanged("char_name"); }
        }
        private string _char_result;
        public string char_result
        {
            get { return _char_result; }
            set { _char_result = value; RaisePropertyChanged("char_result", ModelEntityUpdated); }
        }
        private string _char_type;
        public string char_type
        {
            get { return _char_type; }
            set { _char_type = value; RaisePropertyChanged("char_type", ModelEntityUpdated); }
        }
        private string _v_code_text;
        public string v_code_text
        {
            get { return _v_code_text; }
            set { _v_code_text = value; RaisePropertyChanged("v_code_text"); }
        }

        private double? _low_limit;
        public double? low_limit
        {
            get { return _low_limit; }
            set { _low_limit = value; RaisePropertyChanged("low_limit"); }
        }
        private double? _up_limit;
        public double? up_limit
        {
            get { return _up_limit; }
            set { _up_limit = value; RaisePropertyChanged("up_limit"); }
        }
        private double? _target_value;
        public double? target_value
        {
            get { return _target_value; }
            set { _target_value = value; RaisePropertyChanged("target_value"); }
        }
        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code"); }
        }
        private int? _line_id_a;
        public int? line_id_a
        {
            get { return _line_id_a; }
            set { _line_id_a = value; RaisePropertyChanged("line_id_a"); }
        }
        private string _ind_char;
        public string ind_char
        {
            get { return _ind_char; }
            set { _ind_char = value; RaisePropertyChanged("ind_char"); }
        }
        private string _sample_uom;
        public string sample_uom
        {
            get { return _sample_uom; }
            set { _sample_uom = value; RaisePropertyChanged("sample_uom"); }
        }
        private int? _no_of_char;
        public int? no_of_char
        {
            get { return _no_of_char; }
            set { _no_of_char = value; RaisePropertyChanged("no_of_char"); }
        }
        private int? _no_of_dec;
        public int? no_of_dec
        {
            get { return _no_of_dec; }
            set { _no_of_dec = value; RaisePropertyChanged("no_of_dec"); }
        }
        private string _ind_case;
        public string ind_case
        {
            get { return _ind_case; }
            set { _ind_case = value; RaisePropertyChanged("ind_case"); }
        }
        private string _ind_mv;
        public string ind_mv
        {
            get { return _ind_mv; }
            set { _ind_mv = value; RaisePropertyChanged("ind_mv"); }
        }
        private string _ind_interval;
        public string ind_interval
        {
            get { return _ind_interval; }
            set { _ind_interval = value; RaisePropertyChanged("ind_interval"); }
        }
        private string _long_text;
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
        private string _fcode;
        public string fcode
        {
            get { return _fcode; }
            set
            {
                if (_fcode != value)
                {
                    _fcode = value; RaisePropertyChanged("fcode");
                }
            }
        }
        private string _formula1;
        public string formula1
        {
            get { return _formula1; }
            set
            {
                if (_formula1 != value)
                {
                    _formula1 = value; RaisePropertyChanged("formula1");
                }
            }
        }
        private string _formula2;
        public string formula2
        {
            get { return _formula2; }
            set
            {
                if (_formula2 != value)
                {
                    _formula2 = value; RaisePropertyChanged("formula2");
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
                    _group_name = value; RaisePropertyChanged("group_name");
                }
            }
        }

    }

    public class QMS_T003_C : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int? _id;
        public int? id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }
        
        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set { _doc_no = value; RaisePropertyChanged("doc_no"); }
        }
        private int? _line_no;
        public int? line_no
        {
            get { return _line_no; }
            set { _line_no = value; RaisePropertyChanged("line_no"); }
        }

        private int? _mic_line_id;
        public int? mic_line_id
        {
            get { return _mic_line_id; }
            set { _mic_line_id = value; RaisePropertyChanged("mic_line_id"); }
        }
        private string _char_code;
        public string char_code
        {
            get { return _char_code; }
            set { _char_code = value; RaisePropertyChanged("char_code"); }
        }
        private int? _rr_number;
        public int? rr_number
        {
            get { return _rr_number; }
            set { _rr_number = value; RaisePropertyChanged("rr_number"); }
        }
        private int? _sample_no;
        public int? sample_no
        {
            get { return _sample_no; }
            set { _sample_no = value; RaisePropertyChanged("sample_no"); }
        }
        private string _attribute;
        public string attribute
        {
            get { return _attribute; }
            set { _attribute = value; RaisePropertyChanged("attribute"); }
        }
        private string _ind_source;
        public string ind_source
        {
            get { return _ind_source; }
            set { _ind_source = value; RaisePropertyChanged("ind_source"); }
        }
        private string _ind_equipment;
        public string ind_equipment
        {
            get { return _ind_equipment; }
            set { _ind_equipment = value; RaisePropertyChanged("ind_equipment"); }
        }
        private string _v_code;
        public string v_code
        {
            get { return _v_code; }
            set { _v_code = value; RaisePropertyChanged("v_code"); }
        }

        private int? _counter_insp_unit_no;
        public int? counter_insp_unit_no
        {
            get { return _counter_insp_unit_no; }
            set { _counter_insp_unit_no = value; RaisePropertyChanged("counter_insp_unit_no"); }
        }
        private string _inspector;
        public string inspector
        {
            get { return _inspector; }
            set { _inspector = value; RaisePropertyChanged("inspector"); }
        }
        private DateTime? _start_date;
        public DateTime? start_date
        {
            get { return _start_date; }
            set { _start_date = value; RaisePropertyChanged("start_date"); }
        }
        private DateTime? _end_date;
        public DateTime? end_date
        {
            get { return _end_date; }
            set { _end_date = value; RaisePropertyChanged("end_date"); }
        }
        private string _short_desc;
        public string short_desc
        {
            get { return _short_desc; }
            set { _short_desc = value; RaisePropertyChanged("short_desc"); }
        }
        private string _measured_mode;
        public string measured_mode
        {
            get { return _measured_mode; }
            set { _measured_mode = value; RaisePropertyChanged("measured_mode"); }
        }
        private double? _measured_value;
        public double? measured_value
        {
            get { return _measured_value; }
            set { _measured_value = value; RaisePropertyChanged("measured_value"); }
        }
        private int? _defect_no;
        public int? defect_no
        {
            get { return _defect_no; }
            set { _defect_no = value; RaisePropertyChanged("defect_no"); }
        }
        private string _para_type;
        public string para_type
        {
            get { return _para_type; }
            set { _para_type = value; RaisePropertyChanged("para_type"); }
        }
        private string _para_code;
        public string para_code
        {
            get { return _para_code; }
            set { _para_code = value; RaisePropertyChanged("para_code"); }
        }
        //private string _value_code;
        //public string value_code
        //{
        //    get { return _value_code; }
        //    set { _value_code = value; RaisePropertyChanged("value_code"); }
        //}
        private string _char_value;
        public string char_value
        {
            get { return _char_value; }
            set
            {
                if (_char_value != value)
                {
                    _char_value = value; RaisePropertyChanged("char_value", ModelEntityUpdated);
                }
            }
        }
        private string _version;
        public string version
        {
            get { return _version; }
            set { _version = value; RaisePropertyChanged("version"); }
        }
        private string _defect_class;
        public string defect_class
        {
            get { return _defect_class; }
            set { _defect_class = value; RaisePropertyChanged("defect_class"); }
        }
        private string _equipment;
        public string equipment
        {
            get { return _equipment; }
            set { _equipment = value; RaisePropertyChanged("equipment"); }
        }
        private int? _single_unit_lot;
        public int? single_unit_lot
        {
            get { return _single_unit_lot; }
            set { _single_unit_lot = value; RaisePropertyChanged("single_unit_lot"); }
        }
        private string _single_unit_no;
        public string single_unit_no
        {
            get { return _single_unit_no; }
            set { _single_unit_no = value; RaisePropertyChanged("single_unit_no"); }
        }
        private DateTime _add_date;
        public DateTime add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
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
        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set { _lang_key = value; RaisePropertyChanged("lang_key"); }
        }
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }
        private string _location_id;
        public string location_id
        {
            get { return _location_id; }
            set { _location_id = value; RaisePropertyChanged("location_id"); }
        }
        private string _lab_code;
        public string lab_code
        {
            get { return _lab_code; }
            set { _lab_code = value; RaisePropertyChanged("lab_code"); }
        }
        private string _ind_complete;
        public string ind_complete
        {
            get { return _ind_complete; }
            set { _ind_complete = value; RaisePropertyChanged("ind_complete"); }
        }
        private int? _a_row_id;
        public int? a_row_id
        {
            get { return _a_row_id; }
            set { _a_row_id = value; RaisePropertyChanged("a_row_id"); }
        }

        // Scalar
        private string _specifications;
        public string specifications
        {
            get { return _specifications; }
            set
            {
                _specifications = value;
                RaisePropertyChanged("specifications");
            }
        }
        public string char_spec { get; set; }
        private string _op_no;
        public string op_no
        {
            get { return _op_no; }
            set
            {
                _op_no = value;
                RaisePropertyChanged("op_no", ModelEntityUpdated);
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
        private double? _sample_size;
        public double? sample_size
        {
            get { return _sample_size; }
            set { _sample_size = value; RaisePropertyChanged("sample_size"); }
        }
        private string _char_name;
        public string char_name
        {
            get { return _char_name; }
            set { _char_name = value; RaisePropertyChanged("char_name"); }
        }
        private string _char_result;
        public string char_result
        {
            get { return _char_result; }
            set { _char_result = value; RaisePropertyChanged("char_result", ModelEntityUpdated); }
        }
        private string _char_type;
        public string char_type
        {
            get { return _char_type; }
            set { _char_type = value; RaisePropertyChanged("char_type", ModelEntityUpdated); }
        }
        private string _v_code_text;
        public string v_code_text
        {
            get { return _v_code_text; }
            set { _v_code_text = value; RaisePropertyChanged("v_code_text"); }
        }

        private double? _low_limit;
        public double? low_limit
        {
            get { return _low_limit; }
            set { _low_limit = value; RaisePropertyChanged("low_limit"); }
        }
        private double? _up_limit;
        public double? up_limit
        {
            get { return _up_limit; }
            set { _up_limit = value; RaisePropertyChanged("up_limit"); }
        }
        private double? _target_value;
        public double? target_value
        {
            get { return _target_value; }
            set { _target_value = value; RaisePropertyChanged("target_value"); }
        }
        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code"); }
        }
        private int? _line_id_a;
        public int? line_id_a
        {
            get { return _line_id_a; }
            set { _line_id_a = value; RaisePropertyChanged("line_id_a"); }
        }
        private string _ind_char;
        public string ind_char
        {
            get { return _ind_char; }
            set { _ind_char = value; RaisePropertyChanged("ind_char"); }
        }
        private string _sample_uom;
        public string sample_uom
        {
            get { return _sample_uom; }
            set { _sample_uom = value; RaisePropertyChanged("sample_uom"); }
        }
        private int? _no_of_char;
        public int? no_of_char
        {
            get { return _no_of_char; }
            set { _no_of_char = value; RaisePropertyChanged("no_of_char"); }
        }
        private int? _no_of_dec;
        public int? no_of_dec
        {
            get { return _no_of_dec; }
            set { _no_of_dec = value; RaisePropertyChanged("no_of_dec"); }
        }
        private string _ind_case;
        public string ind_case
        {
            get { return _ind_case; }
            set { _ind_case = value; RaisePropertyChanged("ind_case"); }
        }
        private string _ind_mv;
        public string ind_mv
        {
            get { return _ind_mv; }
            set { _ind_mv = value; RaisePropertyChanged("ind_mv"); }
        }
        private string _ind_interval;
        public string ind_interval
        {
            get { return _ind_interval; }
            set { _ind_interval = value; RaisePropertyChanged("ind_interval"); }
        }
        private string _group_name;
        public string group_name
        {
            get { return _group_name; }
            set
            {
                if (_group_name != value)
                {
                    _group_name = value; RaisePropertyChanged("group_name");
                }
            }
        }
    }

    public class QMS_T003_U : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }
        private string _location_id;
        public string location_id
        {
            get { return _location_id; }
            set { _location_id = value; RaisePropertyChanged("location_id"); }
        }
        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set { _doc_no = value; RaisePropertyChanged("doc_no"); }
        }
        private string _ind_cat;
        public string ind_cat
        {
            get { return _ind_cat; }
            set { _ind_cat = value; RaisePropertyChanged("ind_cat"); }
        }
        private int? _mic_row_id;
        public int? mic_row_id
        {
            get { return _mic_row_id; }
            set { _mic_row_id = value; RaisePropertyChanged("mic_row_id"); }
        }
        private int? _p_lot_no;
        public int? p_lot_no
        {
            get { return _p_lot_no; }
            set { _p_lot_no = value; RaisePropertyChanged("p_lot_no"); }
        }
        private string _ud_no;
        public string ud_no
        {
            get { return _ud_no; }
            set { _ud_no = value; RaisePropertyChanged("ud_no"); }
        }
        private string _prof_type;
        public string prof_type
        {
            get { return _prof_type; }
            set { _prof_type = value; RaisePropertyChanged("prof_type"); }
        }
        private string _prof_code;
        public string prof_code
        {
            get { return _prof_code; }
            set { _prof_code = value; RaisePropertyChanged("prof_code"); }
        }
        private string _char_code;
        public string char_code
        {
            get { return _char_code; }
            set { _char_code = value; RaisePropertyChanged("char_code"); }
        }
        private string _char_value;
        public string char_value
        {
            get { return _char_value; }
            set
            {
                if (_char_value != value)
                {
                    _char_value = value; RaisePropertyChanged("char_value", ModelEntityUpdated);
                }
            }
        }
        private string _v_code;
        public string v_code
        {
            get { return _v_code; }
            set { _v_code = value; RaisePropertyChanged("v_code"); }
        }
        private string _v_code_dm;
        public string v_code_dm
        {
            get { return _v_code_dm; }
            set { _v_code_dm = value; RaisePropertyChanged("v_code_dm"); }
        }
        private string _fa_code;
        public string fa_code
        {
            get { return _fa_code; }
            set { _fa_code = value; RaisePropertyChanged("fa_code"); }
        }
        private double? _q_score;
        public double? q_score
        {
            get { return _q_score; }
            set { _q_score = value; RaisePropertyChanged("q_score"); }
        }
        private string _emp_id;
        public string emp_id
        {
            get { return _emp_id; }
            set { _emp_id = value; RaisePropertyChanged("emp_id"); }
        }
        private double? _qty_ustock;
        public double? qty_ustock
        {
            get { return _qty_ustock; }
            set { _qty_ustock = value; RaisePropertyChanged("qty_ustock"); }
        }
        private double? _qty_scrap;
        public double? qty_scrap
        {
            get { return _qty_scrap; }
            set { _qty_scrap = value; RaisePropertyChanged("qty_scrap"); }
        }
        private double? _qty_sample;
        public double? qty_sample
        {
            get { return _qty_sample; }
            set { _qty_sample = value; RaisePropertyChanged("qty_sample"); }
        }
        private double? _qty_bstock;
        public double? qty_bstock
        {
            get { return _qty_bstock; }
            set { _qty_bstock = value; RaisePropertyChanged("qty_bstock"); }
        }
        private double? _qty_return;
        public double? qty_return
        {
            get { return _qty_return; }
            set { _qty_return = value; RaisePropertyChanged("qty_return"); }
        }
        private double? _qty_destroyed;
        public double? qty_destroyed
        {
            get { return _qty_destroyed; }
            set { _qty_destroyed = value; RaisePropertyChanged("qty_destroyed"); }
        }
        private double? _qty_inspected;
        public double? qty_inspected
        {
            get { return _qty_inspected; }
            set { _qty_inspected = value; RaisePropertyChanged("qty_inspected"); }
        }
        private double? _qty_defective;
        public double? qty_defective
        {
            get { return _qty_defective; }
            set { _qty_defective = value; RaisePropertyChanged("qty_defective"); }
        }
        private string _qs_pro;
        public string qs_pro
        {
            get { return _qs_pro; }
            set { _qs_pro = value; RaisePropertyChanged("qs_pro"); }
        }
        private string _remark;
        public string remark
        {
            get { return _remark; }
            set { _remark = value; RaisePropertyChanged("remark"); }
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

        //Scalar
        private string _short_text;
        public string short_text
        {
            get { return _short_text; }
            set { _short_text = value; RaisePropertyChanged("short_text"); }
        }
        private string _v_name;
        public string v_name
        {
            get { return _v_name; }
            set { _v_name = value; RaisePropertyChanged("v_name"); }
        }
        private string _long_text;
        public string long_text
        {
            get { return _long_text; }
            set { _long_text = value; RaisePropertyChanged("long_text"); }
        }
    }
    public class QMS_T003_N : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
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
        private string _location_id;
        public string location_id
        {
            get { return _location_id; }
            set { _location_id = value; RaisePropertyChanged("location_id"); }
        }
        private string _defect_level;
        public string defect_level
        {
            get { return _defect_level; }
            set { _defect_level = value; RaisePropertyChanged("defect_level"); }
        }
        private string _op_no;
        public string op_no
        {
            get { return _op_no; }
            set
            {
                _op_no = value;
                RaisePropertyChanged("op_no", ModelEntityUpdated);
            }
        }
        
        private int? _mic_line_id;
        public int? mic_line_id
        {
            get { return _mic_line_id; }
            set { _mic_line_id = value; RaisePropertyChanged("mic_line_id"); }
        }
        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set { _doc_no = value; RaisePropertyChanged("doc_no"); }
        }
        private int? _line_no;
        public int? line_no
        {
            get { return _line_no; }
            set { _line_no = value; RaisePropertyChanged("line_no"); }
        }
        private string _char_code;
        public string char_code
        {
            get { return _char_code; }
            set { _char_code = value; RaisePropertyChanged("char_code"); }
        }
        private int? _sample_no;
        public int? sample_no
        {
            get { return _sample_no; }
            set { _sample_no = value; RaisePropertyChanged("sample_no"); }
        }
        private int? _ref_line_id;
        public int? ref_line_id
        {
            get { return _ref_line_id; }
            set { _ref_line_id = value; RaisePropertyChanged("ref_line_id"); }
        }
        private string _para_type;
        public string para_type
        {
            get { return _para_type; }
            set { _para_type = value; RaisePropertyChanged("para_type"); }
        }
        private string _para_code;
        public string para_code
        {
            get { return _para_code; }
            set { _para_code = value; RaisePropertyChanged("para_code"); }
        }
        //private string _value_code;
        //public string value_code
        //{
        //    get { return _value_code; }
        //    set { _value_code = value; RaisePropertyChanged("value_code", ModelEntityUpdated); }
        //}
        private string _char_value;
        public string char_value
        {
            get { return _char_value; }
            set
            {
                if (_char_value != value)
                {
                    _char_value = value; RaisePropertyChanged("char_value", ModelEntityUpdated);
                }
            }
        }
        private string _version;
        public string version
        {
            get { return _version; }
            set { _version = value; RaisePropertyChanged("version"); }
        }
        private string _defect_desc;
        public string defect_desc
        {
            get { return _defect_desc; }
            set { _defect_desc = value; RaisePropertyChanged("defect_desc"); }
        }
        private string _defect_class;
        public string defect_class
        {
            get { return _defect_class; }
            set { _defect_class = value; RaisePropertyChanged("defect_class"); }
        }
        private int? _no_of_defects;
        public int? no_of_defects
        {
            get { return _no_of_defects; }
            set { _no_of_defects = value; RaisePropertyChanged("no_of_defects"); }
        }
        private string _defect_location;
        public string defect_location
        {
            get { return _defect_location; }
            set { _defect_location = value; RaisePropertyChanged("defect_location"); }
        }
        private double? _defect_valuation;
        public double? defect_valuation
        {
            get { return _defect_valuation; }
            set { _defect_valuation = value; RaisePropertyChanged("defect_valuation"); }
        }
        private string _qn_process;
        public string qn_process
        {
            get { return _qn_process; }
            set { _qn_process = value; RaisePropertyChanged("qn_process"); }
        }
        private DateTime? _add_date;
        public DateTime? add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
        }
        private string _remark;
        public string remark
        {
            get { return _remark; }
            set { _remark = value; RaisePropertyChanged("remark"); }
        }
        private bool? _active;
        public bool? active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }
        private int? _a_row_id;
        public int? a_row_id
        {
            get { return _a_row_id; }
            set { _a_row_id = value; RaisePropertyChanged("a_row_id"); }
        }

        // Scallar
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
        private double? _sample_size;
        public double? sample_size
        {
            get { return _sample_size; }
            set { _sample_size = value; RaisePropertyChanged("sample_size"); }
        }
        private string _char_name;
        public string char_name
        {
            get { return _char_name; }
            set { _char_name = value; RaisePropertyChanged("char_name"); }
        }
        private string _para_name;
        public string para_name
        {
            get { return _para_name; }
            set { _para_name = value; RaisePropertyChanged("para_name"); }
        }
        private string _para_value;
        public string para_value
        {
            get { return _para_value; }
            set { _para_value = value; RaisePropertyChanged("para_value"); }
        }
        private string _def_class_name;
        public string def_class_name
        {
            get { return _def_class_name; }
            set { _def_class_name = value; RaisePropertyChanged("def_class_name"); }
        }
    }


    public class MC_QMS_T003 : MC_QMS_BE
    {
        public List<QMS_T003> MASTER_LIST { get; set; }
        public ObservableCollection<QMS_T003_A> SUMMURY_RR { get; set; }
        public ObservableCollection<QMS_T003_B> CHAR_RR { get; set; }
        public ObservableCollection<QMS_T003_C> SINGLE_RR { get; set; }
        public ObservableCollection<QMS_T003_N> DEFECT_RR { get; set; }
        public List<QMS_T003_U> USAGE_DECISION { get; set; }

    }





    ////Depricated
    //public class MultipleContext_QMS_T003
    //{
    //    //public List<QMS_T003_Flip> BackFlipData { get; set; }
    //    //public List<ADM_M022_P> ItemMaster { get; set; }
    //    //public List<QMS_P002_P> LotOriginMaster { get; set; }
    //    //public List<QMS_M030_P> InspPlanMaster { get; set; }
    //    //public List<ADM_M028_P> PartyMaster { get; set; }
    //    //public List<ADM_M001_M_P> PurchaseOrg { get; set; }
    //    //public List<QMS_T003> MasterEntity { get; set; }
    //    //public List<ADM_M038_B_P> UnitMaster { get; set; }
    //    //public ObservableCollection<QMS_T003_A> Insp_process_RR1 { get; set; }
    //    //public ObservableCollection<QMS_T003_B> Insp_process_RR2 { get; set; }
    //    //public ObservableCollection<QMS_T003_C> Insp_process_RR3 { get; set; }
    //    //public List<Classification> Profile_Values { get; set; }
    //    //public ObservableCollection<QMS_T003_N> Defect_Data { get; set; }
    //    //public List<QMS_T003_U> Usage_Decision { get; set; }
    //    //public List<QMS_M048> Folloup_Action { get; set; }
    //    //public List<MM_M001_P> StorageLocations { get; set; }
    //}
}
