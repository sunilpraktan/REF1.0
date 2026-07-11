using Reflection.BusinessEntity.Production;
using Reflection.BusinessEntity.ReflectionSystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.QMS
{
    public class QMS_M030 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

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

        private Nullable<System.DateTime> _plan_date;
        public Nullable<System.DateTime> plan_date
        {
            get { return _plan_date; }
            set
            {
                _plan_date = value;
                RaisePropertyChanged("plan_date");
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

        private Nullable<int> _plan_counter;
        public Nullable<int> plan_counter
        {
            get { return _plan_counter; }
            set
            {
                _plan_counter = value;
                RaisePropertyChanged("plan_counter");
            }
        }

        private Nullable<System.DateTime> _valid_from;
        public Nullable<System.DateTime> valid_from
        {
            get { return _valid_from; }
            set
            {
                _valid_from = value;
                RaisePropertyChanged("valid_from");
            }
        }

        private string _task_list_use;
        public string task_list_use
        {
            get { return _task_list_use; }
            set
            {
                _task_list_use = value;
                RaisePropertyChanged("task_list_use");
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

        private string _task_list_unit;
        public string task_list_unit
        {
            get { return _task_list_unit; }
            set
            {
                _task_list_unit = value;
                RaisePropertyChanged("task_list_unit");
            }
        }

        private Nullable<decimal> _lot_size_from;
        public Nullable<decimal> lot_size_from
        {
            get { return _lot_size_from; }
            set
            {
                _lot_size_from = value;
                RaisePropertyChanged("lot_size_from");
            }
        }

        private Nullable<decimal> _lot_size_to;
        public Nullable<decimal> lot_size_to
        {
            get { return _lot_size_to; }
            set
            {
                _lot_size_to = value;
                RaisePropertyChanged("lot_size_to");
            }
        }

        private string _task_list_desc;
        public string task_list_desc
        {
            get { return _task_list_desc; }
            set
            {
                _task_list_desc = value;
                RaisePropertyChanged("task_list_desc");
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

        private string _ItemCode;
        public string ItemCode
        {
            get { return _ItemCode; }
            set
            {
                _ItemCode = value;
                RaisePropertyChanged("ItemCode");
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

        private string _alternate_bom_no;
        public string alternate_bom_no
        {
            get { return _alternate_bom_no; }
            set
            {
                _alternate_bom_no = value;
                RaisePropertyChanged("alternate_bom_no");
            }
        }

        private Nullable<decimal> _base_qty;
        public Nullable<decimal> base_qty
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

        private Nullable<decimal> _num_operation;
        public Nullable<decimal> num_operation
        {
            get { return _num_operation; }
            set
            {
                _num_operation = value;
                RaisePropertyChanged("num_operation");
            }
        }

        private Nullable<decimal> _deno_operation;
        public Nullable<decimal> deno_operation
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

        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
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

        private System.DateTime _add_date;
        public System.DateTime add_date
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

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value;
                RaisePropertyChanged("edit_date");
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

        private string _plan_desc;
        public string plan_desc
        {
            get { return _plan_desc; }
            set
            {
                _plan_desc = value;
                RaisePropertyChanged("plan_desc");
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

        private string _ItemName;
        public string ItemName
        {
            get { return _ItemName; }
            set
            {
                _ItemName = value;
                RaisePropertyChanged("ItemName");
            }
        }

        public string XmlDataDocument_QMS_M030_Flip { get; set; }
        public string XmlDataDocument_QMS_M030_A { get; set; }
        public string XmlDataDocument_QMS_M030_B { get; set; }
        public string XmlDataDocument_QMS_M030_C { get; set; }
        public string XmlDataDocument_QMS_M030_D { get; set; }
    }

    public class QMS_M030_A : ObjectBase
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

        private string _ItemCode;
        public string ItemCode
        {
            get { return _ItemCode; }
            set
            {
                _ItemCode = value;
                RaisePropertyChanged("ItemCode");
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

        private Nullable<int> _plan_counter;
        public Nullable<int> plan_counter
        {
            get { return _plan_counter; }
            set
            {
                _plan_counter = value;
                RaisePropertyChanged("plan_counter");
            }
        }

        private Nullable<System.DateTime> _valid_from;
        public Nullable<System.DateTime> valid_from
        {
            get { return _valid_from; }
            set
            {
                _valid_from = value;
                RaisePropertyChanged("valid_from");
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

        private string _vender_id;
        public string vender_id
        {
            get { return _vender_id; }
            set
            {
                _vender_id = value;
                RaisePropertyChanged("vender_id");
            }
        }

        private string _sales_doc_no;
        public string sales_doc_no
        {
            get { return _sales_doc_no; }
            set
            {
                _sales_doc_no = value;
                RaisePropertyChanged("sales_doc_no");
            }
        }

        private Nullable<int> _sales_doc_item_row_id;
        public Nullable<int> sales_doc_item_row_id
        {
            get { return _sales_doc_item_row_id; }
            set
            {
                _sales_doc_item_row_id = value;
                RaisePropertyChanged("sales_doc_item_row_id");
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

        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
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

        private System.DateTime _add_date;
        public System.DateTime add_date
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

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value;
                RaisePropertyChanged("edit_date");
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
        private string _inspector;
        public string inspector
        {
            get { return _inspector; }
            set
            {
                _inspector = value;
                RaisePropertyChanged("inspector");
            }
        }
        private string _approve_by;
        public string approve_by
        {
            get { return _approve_by; }
            set
            {
                _approve_by = value;
                RaisePropertyChanged("approve_by");
            }
        }

        private int? _seq_op;
        public int? seq_op
        {
            get { return _seq_op; }
            set
            {
                _seq_op = value;
                RaisePropertyChanged("seq_op");
            }
        }
        private int? _bom_item_line_id;
        public int? bom_item_line_id
        {
            get { return _bom_item_line_id; }
            set
            {
                _bom_item_line_id = value;
                RaisePropertyChanged("bom_item_line_id");
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
        private string _alternet_bom;
        public string alternet_bom
        {
            get { return _alternet_bom; }
            set
            {
                _alternet_bom = value;
                RaisePropertyChanged("alternet_bom");
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


        //Scalar
        private string _ItemName;
        public string ItemName
        {
            get { return _ItemName; }
            set
            {
                _ItemName = value;
                RaisePropertyChanged("ItemName");
            }
        }
    }

    public class QMS_M030_B : ObjectBase
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

        
        private Nullable<int> _plan_counter;
        public Nullable<int> plan_counter
        {
            get { return _plan_counter; }
            set
            {
                _plan_counter = value;
                RaisePropertyChanged("plan_counter");
            }
        }

        private Nullable<System.DateTime> _valid_from;
        public Nullable<System.DateTime> valid_from
        {
            get { return _valid_from; }
            set
            {
                _valid_from = value;
                RaisePropertyChanged("valid_from");
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

        private Nullable<decimal> _base_qty;
        public Nullable<decimal> base_qty
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

        private Nullable<decimal> _num_operation;
        public Nullable<decimal> num_operation
        {
            get { return _num_operation; }
            set
            {
                _num_operation = value;
                RaisePropertyChanged("num_operation");
            }
        }

        private Nullable<decimal> _deno_operation;
        public Nullable<decimal> deno_operation
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

        private Nullable<decimal> _std_value1;
        public Nullable<decimal> std_value1
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

        private Nullable<decimal> _std_value2;
        public Nullable<decimal> std_value2
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

        private Nullable<decimal> _std_value3;
        public Nullable<decimal> std_value3
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

        private Nullable<decimal> _scrap_factor;
        public Nullable<decimal> scrap_factor
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

        private Nullable<int> _pur_doc_item_row_id;
        public Nullable<int> pur_doc_item_row_id
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

        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
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

        private System.DateTime _add_date;
        public System.DateTime add_date
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

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value;
                RaisePropertyChanged("edit_date");
            }
        }

        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                _location_Id = value;
                RaisePropertyChanged("location_Id", ModelEntityUpdated);
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
    }
    

    public class QMS_M030_C : ObjectBase
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

        private string _insp_char_type;
        public string insp_char_type
        {
            get { return _insp_char_type; }
            set
            {
                _insp_char_type = value;
                RaisePropertyChanged("insp_char_type");
            }
        }
        private int _line_id;
        public int line_id
        {
            get { return _line_id; }
            set
            {
                _line_id = value;
                RaisePropertyChanged("line_id");
            }
        }
        private string _insp_char;
        public string insp_char
        {
            get { return _insp_char; }
            set
            {
                _insp_char = value;
                RaisePropertyChanged("insp_char");
            }
        }

        private Nullable<int> _insp_char_no;
        public Nullable<int> insp_char_no
        {
            get { return _insp_char_no; }
            set
            {
                _insp_char_no = value;
                RaisePropertyChanged("insp_char_no");
            }
        }

        private Nullable<int> _plan_counter;
        public Nullable<int> plan_counter
        {
            get { return _plan_counter; }
            set
            {
                _plan_counter = value;
                RaisePropertyChanged("plan_counter");
            }
        }

        private Nullable<System.DateTime> _valid_from;
        public Nullable<System.DateTime> valid_from
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

        private string _Ref_inspc_char;
        public string Ref_inspc_char
        {
            get { return _Ref_inspc_char; }
            set
            {
                _Ref_inspc_char = value;
                RaisePropertyChanged("Ref_inspc_char");
            }
        }

        private string _insp_char_location;
        public string insp_char_location
        {
            get { return _insp_char_location; }
            set
            {
                _insp_char_location = value;
                RaisePropertyChanged("insp_char_location");
            }
        }

        private string _insp_char_version_no;
        public string insp_char_version_no
        {
            get { return _insp_char_version_no; }
            set
            {
                _insp_char_version_no = value;
                RaisePropertyChanged("insp_char_version_no");
            }
        }

        private Nullable<System.DateTime> _ver_date;
        public Nullable<System.DateTime> ver_date
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

        private string _inspector_qualification;
        public string inspector_qualification
        {
            get { return _inspector_qualification; }
            set
            {
                _inspector_qualification = value;
                RaisePropertyChanged("inspector_qualification");
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

        private string _short_txt;
        public string short_txt
        {
            get { return _short_txt; }
            set
            {
                _short_txt = value;
                RaisePropertyChanged("short_txt");
            }
        }

        private string _desc;
        public string desc
        {
            get { return _desc; }
            set
            {
                _desc = value;
                RaisePropertyChanged("_desc");
            }
        }

        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                _lang_key = value;
                RaisePropertyChanged("_lang_key");
            }
        }

        private Nullable<int> _dc_place;
        public Nullable<int> dc_place
        {
            get { return _dc_place; }
            set
            {
                _dc_place = value;
                RaisePropertyChanged("dc_place");
            }
        }

        private string _uom_quantitative;
        public string uom_quantitative
        {
            get { return _uom_quantitative; }
            set
            {
                _uom_quantitative = value;
                RaisePropertyChanged("uom_quantitative");
            }
        }

        private Nullable<decimal> _target_value_char;
        public Nullable<decimal> target_value_char
        {
            get { return _target_value_char; }
            set
            {
                _target_value_char = value;
                RaisePropertyChanged("target_value_char");
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

        private Nullable<decimal> _lower_limit;
        public Nullable<decimal> lower_limit
        {
            get { return _lower_limit; }
            set
            {
                _lower_limit = value;
                RaisePropertyChanged("lower_limit");
            }
        }

        private Nullable<decimal> _upp_limit;
        public Nullable<decimal> upp_limit
        {
            get { return _upp_limit; }
            set
            {
                _upp_limit = value;
                RaisePropertyChanged("upp_limit");
            }
        }

        private Nullable<decimal> _lower_limit1;
        public Nullable<decimal> lower_limit1
        {
            get { return _lower_limit1; }
            set
            {
                _lower_limit1 = value;
                RaisePropertyChanged("lower_limit1");
            }
        }

        private Nullable<decimal> _upp_limit1;
        public Nullable<decimal> upp_limit1
        {
            get { return _upp_limit1; }
            set
            {
                _upp_limit1 = value;
                RaisePropertyChanged("upp_limit1");
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

        private Nullable<decimal> _lower_tol_limit;
        public Nullable<decimal> lower_tol_limit
        {
            get { return _lower_tol_limit; }
            set
            {
                _lower_tol_limit = value;
                RaisePropertyChanged("lower_tol_limit");
            }
        }

        private Nullable<decimal> _upper_tol_limit;
        public Nullable<decimal> upper_tol_limit
        {
            get { return _upper_tol_limit; }
            set
            {
                _upper_tol_limit = value;
                RaisePropertyChanged("upper_tol_limit");
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

        private Nullable<decimal> _cf_sample;
        public Nullable<decimal> cf_sample
        {
            get { return _cf_sample; }
            set
            {
                _cf_sample = value;
                RaisePropertyChanged("cf_sample");
            }
        }

        private Nullable<decimal> _cf_material;
        public Nullable<decimal> cf_material
        {
            get { return _cf_material; }
            set
            {
                _cf_material = value;
                RaisePropertyChanged("cf_material");
            }
        }

        private Nullable<decimal> _sampl_qty_factor;
        public Nullable<decimal> sampl_qty_factor
        {
            get { return _sampl_qty_factor; }
            set
            {
                _sampl_qty_factor = value;
                RaisePropertyChanged("sampl_qty_factor");
            }
        }

        private string _modification_data;
        public string modification_data
        {
            get { return _modification_data; }
            set
            {
                _modification_data = value;
                RaisePropertyChanged("modification_data");
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

        private string _modification_rule;
        public string modification_rule
        {
            get { return _modification_rule; }
            set
            {
                _modification_rule = value;
                RaisePropertyChanged("modification_rule");
            }
        }

        private string _test_equipment;
        public string test_equipment
        {
            get { return _test_equipment; }
            set
            {
                _test_equipment = value;
                RaisePropertyChanged("test_equipment");
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

        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
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

        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date
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

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value;
                RaisePropertyChanged("edit_date");
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

        private string _MethodNm;
        public string MethodNm
        {
            get { return _MethodNm; }
            set
            {
                _MethodNm = value;
                RaisePropertyChanged("MethodNm");
            }
        }

        private string _CharName;
        public string CharName
        {
            get { return _CharName; }
            set
            {
                _CharName = value;
                RaisePropertyChanged("CharName");
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

    }

    public class QMS_M030_D : ObjectBase
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

        private string _insp_char;
        public string insp_char
        {
            get { return _insp_char; }
            set
            {
                _insp_char = value;
                RaisePropertyChanged("insp_char");
            }
        }

        private string _para_type;
        public string para_type
        {
            get { return _para_type; }
            set
            {
                _para_type = value;
                RaisePropertyChanged("para_type");
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

        private Nullable<bool> _ind_gc_or_ss;
        public Nullable<bool> ind_gc_or_ss
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

        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
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

        private System.DateTime _add_date;
        public System.DateTime add_date
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

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value;
                RaisePropertyChanged("edit_date");
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
        //Scalar
        private string _ParaName;
        public string ParaName
        {
            get { return _ParaName; }
            set
            {
                _ParaName = value;
                RaisePropertyChanged("ParaName");
            }
        }


    }

    public class MultipleContext_QMS_M030
    {
        public List<QMS_M030_Flip> BackFlipData { get; set; }
        public List<ADM_M022_P> ItemMaster { get; set; }
        public List<QMS_M030_G_P> InspMethod { get; set; }
        public List<QMS_M034_P> SampleProcedure { get; set; }
        public List<ADM_M038_B_P> UnitMaster { get; set; }
        public List<QMS_M022_P> QualiMaster { get; set; }
        public List<PPC_M001_P> WorkCenter { get; set; }
        public List<ENG_T001_P> BOMData { get; set; }
        public List<QMS_M030> MasterEntity { get; set; }
        public ObservableCollection<QMS_M030_A> AssignmentEntity { get; set; }
        public ObservableCollection<QMS_M030_B> OperationEntity { get; set; }
        public ObservableCollection<QMS_M030_C> InspCharEntity { get; set; }
        public ObservableCollection<QMS_M030_D> SelectedSetEntity { get; set; }
        public List<QMS_M030_I_P> MICMaster { get; set; }
        public List<SYS_M051> ControlKeyMaster { get; set; }
        public List<SYS_M048> UsageMaster { get; set; }
        public List<QMS_M032_P> ParaTypeMaster { get; set; }
        public List<Group_Set> GroupSetMaster { get; set; }
        public List<ADM_M024_P> EmployeeList { get; set; }
        public List<PPC_M002> OperationList { get; set; }

    }
}
