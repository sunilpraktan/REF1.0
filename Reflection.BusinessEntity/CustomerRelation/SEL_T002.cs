using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Reflection.BusinessEntity.ReflectionSystem;

namespace Reflection.BusinessEntity
{
    public class SEL_T002 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private string _sch_no;
        private int? _id;
        private string _doc_type;
        private string _doc_cat;
        private string _ref_type;
        private string _PartyId;
        private string _ref_no;
        private System.DateTime? _sch_date;
        private string _sch_time;
        private string _EmpId;
        private string _sch_mode;
        private string _sch_rec_by_cd;
        private string _remark;
        private Nullable<bool> _active;
        private System.DateTime? _add_date;
        private string _add_by;
        private Nullable<System.DateTime> _edit_date;
        private string _editby;
        private string _t_status;
        private string _location_Id;
        private string _comp_code;
        private string _fin_year;
        private string _posting_period;
        private string _sch_by;
        private string _PartyNm;
        private string _employee_name;
        private string _contact_name;
        private int? _ContInfoId;
        private string _status_remark;

        public string sch_no
        {
            get
            {
                return _sch_no;
            }

            set
            {
                if (_sch_no != value)
                {
                    _sch_no = value; RaisePropertyChanged("sch_no");
                }
            }
        }
        
        public int? id
        {
            get
            {
                return _id;
            }

            set
            {
                if (_id != value)
                {
                    _id = value; RaisePropertyChanged("id");
                }
            }
        }

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
                    _doc_type = value; RaisePropertyChanged("doc_type");
                }
            }

        }
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
                    _doc_cat = value; RaisePropertyChanged("doc_cat");
                }
            }

        }


        public string ref_type
        {
            get
            {
                return _ref_type;
            }

            set
            {
                if (_ref_type != value)
                {
                    _ref_type = value; RaisePropertyChanged("ref_type");
                }
            }
        }

        //[Required(ErrorMessage = "Field 'Party Name' is required.")]
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

        public string ref_no
        {
            get
            {
                return _ref_no;
            }

            set
            {
                if (_ref_no != value)
                {
                    _ref_no = value; RaisePropertyChanged("ref_no");
                }
            }
        }

        public System.DateTime? sch_date
        {
            get
            {
                return _sch_date;
            }

            set
            {
                if (_sch_date != value)
                {
                    _sch_date = value; RaisePropertyChanged("sch_date");
                }
            }
        }

        public string sch_time
        {
            get
            {
                return _sch_time;
            }

            set
            {
                if (_sch_time != value)
                {
                    _sch_time = value; RaisePropertyChanged("sch_time");
                }
            }
        }

        // [Required(ErrorMessage = "Field 'Schedule Received By' is required.")]
        public string EmpId
        {
            get
            {
                return _EmpId;
            }

            set
            {
                if (_EmpId != value)
                {
                    _EmpId = value; RaisePropertyChanged("EmpId");
                }
            }
        }

        public string sch_mode
        {
            get
            {
                return _sch_mode;
            }

            set
            {
                if (_sch_mode != value)
                {
                    _sch_mode = value; RaisePropertyChanged("sch_mode");
                }
            }
        }

        public string sch_rec_by_cd
        {
            get
            {
                return _sch_rec_by_cd;
            }

            set
            {
                if (_sch_rec_by_cd != value)
                {
                    _sch_rec_by_cd = value; RaisePropertyChanged("sch_rec_by_cd");
                }
            }
        }

        public string remark
        {
            get
            {
                return _remark;
            }

            set
            {
                if (_remark != value)
                {
                    _remark = value; RaisePropertyChanged("remark");
                }
            }
        }

        public Nullable<bool> active
        {
            get
            {
                return _active;
            }

            set
            {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active");
                }
            }
        }
        
        public DateTime? add_date
        {
            get
            {
                return _add_date;
            }

            set
            {
                if (_add_date != value)
                {
                    _add_date = value; RaisePropertyChanged("add_date");
                }
            }
        }

        public string add_by
        {
            get
            {
                return _add_by;
            }

            set
            {
                if (_add_by != value)
                {
                    _add_by = value; RaisePropertyChanged("add_by");
                }
            }
        }

        public Nullable<System.DateTime> edit_date
        {
            get
            {
                return _edit_date;
            }

            set
            {
                if (_edit_date != value)
                {
                    _edit_date = value; RaisePropertyChanged("edit_date");
                }
            }
        }

        public string editby
        {
            get
            {
                return _editby;
            }

            set
            {
                if (_editby != value)
                {
                    _editby = value; RaisePropertyChanged("editby");
                }
            }
        }

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
        public string location_Id
        {
            get
            {
                return _location_Id;
            }

            set
            {
                if (_location_Id != value)
                {
                    _location_Id = value; RaisePropertyChanged("location_Id");
                }
            }
        }

        public string comp_code
        {
            get
            {
                return _comp_code;
            }

            set
            {
                if (_comp_code != value)
                {
                    _comp_code = value; RaisePropertyChanged("comp_code");
                }
            }
        }

        public string fin_year
        {
            get
            {
                return _fin_year;
            }

            set
            {
                if (_fin_year != value)
                {
                    _fin_year = value; RaisePropertyChanged("fin_year");
                }
            }
        }

        public string posting_period
        {
            get
            {
                return _posting_period;
            }

            set
            {
                if (_posting_period != value)
                {
                    _posting_period = value; RaisePropertyChanged("posting_period");
                }
            }
        }

        public string sch_by
        {
            get
            {
                return _sch_by;
            }

            set
            {
                if (_sch_by != value)
                {
                    _sch_by = value; RaisePropertyChanged("sch_by");
                }
            }
        }

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

        public string employee_name
        {
            get
            {
                return _employee_name;
            }

            set
            {
                if (_employee_name != value)
                {
                    _employee_name = value; RaisePropertyChanged("employee_name");
                }
            }
        }

        public string contact_name
        {
            get
            {
                return _contact_name;
            }

            set
            {
                if (_contact_name != value)
                {
                    _contact_name = value; RaisePropertyChanged("contact_name");
                }
            }
        }

        public int? ContInfoId
        {
            get
            {
                return _ContInfoId;
            }

            set
            {
                if (_ContInfoId != value)
                {
                    _ContInfoId = value; RaisePropertyChanged("ContInfoId");
                }
            }
        }
        private string _cust_ref;
        public string cust_ref
        {
            get
            {
                return _cust_ref;
            }

            set
            {
                if (_cust_ref != value)
                {
                    _cust_ref = value; RaisePropertyChanged("cust_ref");
                }
            }
        }
        private string _ref_doc_no;
        public string ref_doc_no
        {
            get
            {
                return _ref_doc_no;
            }

            set
            {
                if (_ref_doc_no != value)
                {
                    _ref_doc_no = value; RaisePropertyChanged("ref_doc_no");
                }
            }
        }
        private string _ref_doc_type;
        public string ref_doc_type
        {
            get
            {
                return _ref_doc_type;
            }

            set
            {
                if (_ref_doc_type != value)
                {
                    _ref_doc_type = value; RaisePropertyChanged("ref_doc_type");
                }
            }
        }
        private string _ref_doc_cat;
        public string ref_doc_cat
        {
            get
            {
                return _ref_doc_cat;
            }

            set
            {
                if (_ref_doc_cat != value)
                {
                    _ref_doc_cat = value; RaisePropertyChanged("ref_doc_cat");
                }
            }
        }
        private Nullable<System.DateTime> _ref_doc_date;
        public Nullable<System.DateTime> ref_doc_date
        {
            get
            {
                return _ref_doc_date;
            }

            set
            {
                if (_ref_doc_date != value)
                {
                    _ref_doc_date = value; RaisePropertyChanged("ref_doc_date");
                }
            }
        }
        private int? _del_address;
        public int? del_address
        {
            get
            {
                return _del_address;
            }

            set
            {
                if (_del_address != value)
                {
                    _del_address = value; RaisePropertyChanged("del_address");
                }
            }
        }
        private string _del_add;
        public string del_add
        {
            get
            {
                return _del_add;
            }

            set
            {
                if (_del_add != value)
                {
                    _del_add = value; RaisePropertyChanged("del_add");
                }
            }
        }

        private string _Location;
        public string Location
        {
            get
            {
                return _Location;
            }

            set
            {
                if (_Location != value)
                {
                    _Location = value; RaisePropertyChanged("Location");
                }
            }
        }
        public string status_remark
        {
            get
            {
                return _status_remark;
            }

            set
            {
                if (_status_remark != value)
                {
                    _status_remark = value; RaisePropertyChanged("status_remark");
                }
            }
        }
        private string _add_code_del;
        public string add_code_del
        {
            get
            {
                return _add_code_del;
            }

            set
            {
                if (_add_code_del != value)
                {
                    _add_code_del = value; RaisePropertyChanged("add_code_del");
                }
            }
        }
        private string _cp_code;
        public string cp_code
        {
            get
            {
                return _cp_code;
            }

            set
            {
                if (_cp_code != value)
                {
                    _cp_code = value; RaisePropertyChanged("cp_code");
                }
            }
        }
        public string XmlDataDocument_SEL_T002_A { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }

    }
    public class SEL_T002_A : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        //public static event EventHandler ModelEntityUpdated = delegate { };
        private int? _id;
        private string _sch_cat;
        private string _del_rel;
        private string _sch_no;
        private string _sono;
        private string _ref_no;
        private int? _line_id;
        private string _ItemCode;
        private string _unit_code;
        private decimal? _sch_qty;
        private DateTime? _exp_date;
        private DateTime? _desp_date;
        private decimal? _confirm_qty;
        private decimal? _confirm_qty_org;
        private DateTime? _confirm_date;
        private decimal? _del_qty;
        private DateTime? _del_date;
        private string _po_req_no;
        private Nullable<int> _item_no_po_req;
        private string _remark;
        private string _desp_id;
        private Nullable<bool> _active;
        private System.DateTime? _add_date;
        private string _add_by;
        private DateTime? _edit_date;
        private string _editby;
        private string _t_status;
        private string _sku;
        private string _location_Id;
        private string _comp_code;
        private decimal? _rate;
        private string _fin_year;
        private string _posting_period;
        private string _rel_delivery;
        private string _rel_billing;
        private int? _so_item_id;
        private decimal? _order_qty;
        private string _confirm_status;
        private bool? _del_block;
        private string _mov_tp;
        private string _sku_desc;
        private string _ItemName;
        private string _unit_name;
        private Nullable<System.DateTime> _sch_date;
        private int? _Lead_Time1;
        private int? _Lead_Time2;
        private string _ship_mode;
        private string _PartyId;
        private string _para1;
        private string _para2;
        private string _para3;
        private string _status_remark;

        

        private decimal? _lead_time;
        public decimal? lead_time
        {
            get
            {
                return _lead_time;
            }

            set
            {
                if (_lead_time != value)
                {
                    _lead_time = value; RaisePropertyChanged("lead_time", ModelEntityUpdated);
                }
            }
        }
        private string _lead_uom;
        public string lead_uom
        {
            get
            {
                return _lead_uom;
            }

            set
            {
                if (_lead_uom != value)
                {
                    _lead_uom = value; RaisePropertyChanged("lead_uom");
                }
            }
        }

        private decimal? _bal_qty;
        public decimal? bal_qty
        {
            get
            {
                return _bal_qty;
            }

            set
            {
                if (_bal_qty != value)
                {
                    _bal_qty = value; RaisePropertyChanged("bal_qty");
                }
            }
        }
        public int? id
        {
            get
            {
                return _id;
            }

            set
            {
                if (_id != value)
                {
                    _id = value; RaisePropertyChanged("id");
                }
            }
        }

        public string sch_cat
        {
            get
            {
                return _sch_cat;
            }

            set
            {
                if (_sch_cat != value)
                {
                    _sch_cat = value; RaisePropertyChanged("sch_cat");
                }
            }
        }

        public string del_rel
        {
            get
            {
                return _del_rel;
            }

            set
            {
                if (_del_rel != value)
                {
                    _del_rel = value; RaisePropertyChanged("del_rel");
                }
            }
        }

        public string sch_no
        {
            get
            {
                return _sch_no;
            }

            set
            {
                if (_sch_no != value)
                {
                    _sch_no = value; RaisePropertyChanged("sch_no");
                }
            }
        }

        public string sono
        {
            get
            {
                return _sono;
            }

            set
            {
                if (_sono != value)
                {
                    _sono = value; RaisePropertyChanged("sono");
                }
            }
        }

        public string ref_no
        {
            get
            {
                return _ref_no;
            }

            set
            {
                if (_ref_no != value)
                {
                    _ref_no = value; RaisePropertyChanged("ref_no");
                }
            }
        }

        public int? line_id
        {
            get
            {
                return _line_id;
            }

            set
            {
                if (_line_id != value)
                {
                    _line_id = value; RaisePropertyChanged("line_id");
                }
            }
        }
        [Required(ErrorMessage = "Field 'Item Code' is required.")]
        public string ItemCode
        {
            get
            {
                return _ItemCode;
            }

            set
            {
                if (_ItemCode != value)
                {
                    _ItemCode = value; RaisePropertyChanged("ItemCode");
                }
            }
        }
        [Required(ErrorMessage = "Field 'Unit Code' is required.")]
        public string unit_code
        {
            get
            {
                return _unit_code;
            }

            set
            {
                if (_unit_code != value)
                {
                    _unit_code = value; RaisePropertyChanged("unit_code");
                }
            }
        }

        public decimal? sch_qty
        {
            get
            {
                return _sch_qty;
            }

            set
            {
                if (_sch_qty != value)
                {
                    _sch_qty = value; RaisePropertyChanged("sch_qty", ModelEntityUpdated);
                }
            }
        }

        public DateTime? exp_date
        {
            get
            {
                return _exp_date;
            }

            set
            {
                if (_exp_date != value)
                {
                    _exp_date = value; RaisePropertyChanged("exp_date");
                }
            }
        }

        public DateTime? desp_date
        {
            get
            {
                return _desp_date;
            }

            set
            {
                if (_desp_date != value)
                {
                    _desp_date = value; RaisePropertyChanged("desp_date", ModelEntityUpdated);
                }
            }
        }

        public decimal? confirm_qty
        {
            get
            {
                return _confirm_qty;
            }

            set
            {
                if (_confirm_qty != value)
                {
                    _confirm_qty = value; RaisePropertyChanged("confirm_qty", ModelEntityUpdated);
                }
            }
        }
        public decimal? confirm_qty_org
        {
            get
            {
                return _confirm_qty_org;
            }

            set
            {
                if (_confirm_qty_org != value)
                {
                    _confirm_qty_org = value; RaisePropertyChanged("confirm_qty_org");
                }
            }
        }

        public DateTime? confirm_date
        {
            get
            {
                return _confirm_date;
            }

            set
            {
                if (_confirm_date != value)
                {
                    _confirm_date = value; RaisePropertyChanged("confirm_date", ModelEntityUpdated);
                }
            }
        }

        public decimal? del_qty
        {
            get
            {
                return _del_qty;
            }

            set
            {
                if (_del_qty != value)
                {
                    _del_qty = value; RaisePropertyChanged("del_qty");
                }
            }
        }

        public DateTime? del_date
        {
            get
            {
                return _del_date;
            }

            set
            {
                if (_del_date != value)
                {
                    _del_date = value; RaisePropertyChanged("del_date");
                }
            }
        }

        public string po_req_no
        {
            get
            {
                return _po_req_no;
            }

            set
            {
                if (_po_req_no != value)
                {
                    _po_req_no = value; RaisePropertyChanged("po_req_no");
                }
            }
        }

        public Nullable<int> item_no_po_req
        {
            get
            {
                return _item_no_po_req;
            }

            set
            {
                if (_item_no_po_req != value)
                {
                    _item_no_po_req = value; RaisePropertyChanged("item_no_po_req");
                }
            }
        }

        public string remark
        {
            get
            {
                return _remark;
            }

            set
            {
                if (_remark != value)
                {
                    _remark = value; RaisePropertyChanged("remark");
                }
            }
        }

        public string desp_id
        {
            get
            {
                return _desp_id;
            }

            set
            {
                if (_desp_id != value)
                {
                    _desp_id = value; RaisePropertyChanged("desp_id");
                }
            }
        }

        public Nullable<bool> active
        {
            get
            {
                return _active;
            }

            set
            {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active");
                }
            }
        }
        
        public DateTime? add_date
        {
            get
            {
                return _add_date;
            }

            set
            {
                if (_add_date != value)
                {
                    _add_date = value; RaisePropertyChanged("add_date");
                }
            }
        }

        public string add_by
        {
            get
            {
                return _add_by;
            }

            set
            {
                if (_add_by != value)
                {
                    _add_by = value; RaisePropertyChanged("add_by");
                }
            }
        }

        public DateTime? edit_date
        {
            get
            {
                return _edit_date;
            }

            set
            {
                if (_edit_date != value)
                {
                    _edit_date = value; RaisePropertyChanged("edit_date");
                }
            }
        }

        public string editby
        {
            get
            {
                return _editby;
            }

            set
            {
                if (_editby != value)
                {
                    _editby = value; RaisePropertyChanged("editby");
                }
            }
        }

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
                    _sku = value; RaisePropertyChanged("sku");
                }
            }
        }

        public string location_Id
        {
            get
            {
                return _location_Id;
            }

            set
            {
                if (_location_Id != value)
                {
                    _location_Id = value; RaisePropertyChanged("location_Id");
                }
            }
        }

        public string comp_code
        {
            get
            {
                return _comp_code;
            }

            set
            {
                if (_comp_code != value)
                {
                    _comp_code = value; RaisePropertyChanged("comp_code");
                }
            }
        }

        public decimal? rate
        {
            get
            {
                return _rate;
            }

            set
            {
                if (_rate != value)
                {
                    _rate = value; RaisePropertyChanged("rate");
                }
            }
        }

        public string fin_year
        {
            get
            {
                return _fin_year;
            }

            set
            {
                if (_fin_year != value)
                {
                    _fin_year = value; RaisePropertyChanged("fin_year");
                }
            }
        }

        public string posting_period
        {
            get
            {
                return _posting_period;
            }

            set
            {
                if (_posting_period != value)
                {
                    _posting_period = value; RaisePropertyChanged("posting_period");
                }
            }
        }

        public string rel_delivery
        {
            get
            {
                return _rel_delivery;
            }

            set
            {
                if (_rel_delivery != value)
                {
                    _rel_delivery = value; RaisePropertyChanged("rel_delivery");
                }
            }
        }

        public string rel_billing
        {
            get
            {
                return _rel_billing;
            }

            set
            {
                if (_rel_billing != value)
                {
                    _rel_billing = value; RaisePropertyChanged("rel_billing");
                }
            }
        }

        public int? so_item_id
        {
            get
            {
                return _so_item_id;
            }

            set
            {
                if (_so_item_id != value)
                {
                    _so_item_id = value; RaisePropertyChanged("so_item_id");
                }
            }
        }

        public decimal? order_qty
        {
            get
            {
                return _order_qty;
            }

            set
            {
                if (_order_qty != value)
                {
                    _order_qty = value; RaisePropertyChanged("order_qty");
                }
            }
        }

        public string confirm_status
        {
            get
            {
                return _confirm_status;
            }

            set
            {
                if (_confirm_status != value)
                {
                    _confirm_status = value; RaisePropertyChanged("confirm_status");
                }
            }
        }

        public bool? del_block
        {
            get
            {
                return _del_block;
            }

            set
            {
                if (_del_block != value)
                {
                    _del_block = value; RaisePropertyChanged("del_block");
                }
            }
        }

        public string mov_tp
        {
            get
            {
                return _mov_tp;
            }

            set
            {
                if (_mov_tp != value)
                {
                    _mov_tp = value; RaisePropertyChanged("mov_tp");
                }
            }
        }

        public string sku_desc
        {
            get
            {
                return _sku_desc;
            }

            set
            {
                if (_sku_desc != value)
                {
                    _sku_desc = value; RaisePropertyChanged("sku_desc");
                }
            }
        }
        //scalar

        public string ItemName
        {
            get
            {
                return _ItemName;

            }
            set
            {
                if (_ItemName != value)
                {
                    _ItemName = value; RaisePropertyChanged("ItemName");
                }
            }
        }

        public string unit_name
        {
            get
            {
                return _unit_name;

            }
            set
            {
                if (_unit_name != value)
                {
                    _unit_name = value; RaisePropertyChanged("unit_name");
                }
            }
        }
        public Nullable<System.DateTime> sch_date
        {
            get
            {
                return _sch_date;
            }
            set
            {
                if (_sch_date != value)
                {
                    _sch_date = value; RaisePropertyChanged("sch_date");
                }
            }
        }

        public int? Lead_Time1
        {
            get
            {
                return _Lead_Time1;
            }

            set
            {
                if (_Lead_Time1 != value)
                {
                    _Lead_Time1 = value; RaisePropertyChanged("Lead_Time1");
                }
            }
        }

        public int? Lead_Time2
        {
            get
            {
                return _Lead_Time2;
            }

            set
            {
                if (_Lead_Time2 != value)
                {
                    _Lead_Time2 = value; RaisePropertyChanged("Lead_Time2");
                }
            }
        }

        public string ship_mode
        {
            get
            {
                return _ship_mode;
            }

            set
            {
                if (_ship_mode != value)
                {
                    _ship_mode = value; RaisePropertyChanged("ship_mode");
                }
            }
        }

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

        public string para1
        {
            get
            {
                return _para1;
            }

            set
            {
                if (_para1 != value)
                {
                    _para1 = value; RaisePropertyChanged("para1");
                }
            }
        }

        public string para2
        {
            get
            {
                return _para2;
            }

            set
            {
                if (_para2 != value)
                {
                    _para2 = value; RaisePropertyChanged("para2");
                }
            }
        }

        public string para3
        {
            get
            {
                return _para3;
            }

            set
            {
                if (_para3 != value)
                {
                    _para3 = value; RaisePropertyChanged("para3");
                }
            }
        }
        private string _ref_doc_no;
        public string ref_doc_no
        {
            get
            {
                return _ref_doc_no;
            }

            set
            {
                if (_ref_doc_no != value)
                {
                    _ref_doc_no = value; RaisePropertyChanged("ref_doc_no");
                }
            }
        }
        private string _ref_doc_type;
        public string ref_doc_type
        {
            get
            {
                return _ref_doc_type;
            }

            set
            {
                if (_ref_doc_type != value)
                {
                    _ref_doc_type = value; RaisePropertyChanged("ref_doc_type");
                }
            }
        }
        private string _ref_doc_cat;
        public string ref_doc_cat
        {
            get
            {
                return _ref_doc_cat;
            }

            set
            {
                if (_ref_doc_cat != value)
                {
                    _ref_doc_cat = value; RaisePropertyChanged("ref_doc_cat");
                }
            }
        }
        private Nullable<System.DateTime> _ref_doc_date;
        public Nullable<System.DateTime> ref_doc_date
        {
            get
            {
                return _ref_doc_date;
            }

            set
            {
                if (_ref_doc_date != value)
                {
                    _ref_doc_date = value; RaisePropertyChanged("ref_doc_date");
                }
            }
        }
        //Scaler 
        private string _custItemcode;
        public string custItemcode
        {
            get
            {
                return _custItemcode;
            }

            set
            {
                if (_custItemcode != value)
                {
                    _custItemcode = value; RaisePropertyChanged("custItemcode");
                }
            }
        }
        private string _PartyNm;
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
        public string status_remark
        {
            get
            {
                return _status_remark;
            }

            set
            {
                if (_status_remark != value)
                {
                    _status_remark = value; RaisePropertyChanged("status_remark");
                }
            }
        }

        private string _ship_to_party;
        public string ship_to_party
        {
            get
            {
                return _ship_to_party;
            }

            set
            {
                if (_ship_to_party != value)
                {
                    _ship_to_party = value; RaisePropertyChanged("ship_to_party");
                }
            }
        }
        private string _ship_to_party_name;
        public string ship_to_party_name
        {
            get
            {
                return _ship_to_party_name;
            }

            set
            {
                if (_ship_to_party_name != value)
                {
                    _ship_to_party_name = value; RaisePropertyChanged("ship_to_party_name");
                }
            }
        }
        private string _ship_to_add;
        public string ship_to_add
        {
            get
            {
                return _ship_to_add;
            }

            set
            {
                if (_ship_to_add != value)
                {
                    _ship_to_add = value; RaisePropertyChanged("ship_to_add");
                }
            }
        }
        private string _ship_to_addNm;
        public string ship_to_addNm
        {
            get
            {
                return _ship_to_addNm;
            }

            set
            {
                if (_ship_to_addNm != value)
                {
                    _ship_to_addNm = value; RaisePropertyChanged("ship_to_addNm");
                }
            }
        }
        private string _pur_req_no;
        public string pur_req_no
        {
            get
            {
                return _pur_req_no;
            }

            set
            {
                if (_pur_req_no != value)
                {
                    _pur_req_no = value; RaisePropertyChanged("pur_req_no");
                }
            }
        }
        private int? _pur_req_row_id;
        public int? pur_req_row_id
        {
            get
            {
                return _pur_req_row_id;
            }

            set
            {
                if (_pur_req_row_id != value)
                {
                    _pur_req_row_id = value; RaisePropertyChanged("pur_req_row_id");
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

        private string _tr_mode;
        public string tr_mode
        {
            get
            {
                return _tr_mode;
            }

            set
            {
                if (_tr_mode != value)
                {
                    _tr_mode = value; RaisePropertyChanged("tr_mode");
                }
            }
        }
        private string _tr_type;
        public string tr_type
        {
            get
            {
                return _tr_type;
            }

            set
            {
                if (_tr_type != value)
                {
                    _tr_type = value; RaisePropertyChanged("tr_type", ModelEntityUpdated);
                }
            }
        }
        private string _tr_party;
        public string tr_party
        {
            get
            {
                return _tr_party;
            }

            set
            {
                if (_tr_party != value)
                {
                    _tr_party = value; RaisePropertyChanged("tr_party");
                }
            }
        }

        private string _address_info;
        public string address_info
        {
            get { return _address_info; }
            set
            {
                if (_address_info != value)
                {
                    _address_info = value; RaisePropertyChanged("address_info");
                }
            }
        }
        private string _tr_name;
        public string tr_name
        {
            get
            {
                return _tr_name;
            }

            set
            {
                if (_tr_name != value)
                {
                    _tr_name = value; RaisePropertyChanged("tr_name");
                }
            }
        }
        private int? _item_line_id;
        public int? item_line_id
        {
            get
            {
                return _item_line_id;
            }

            set
            {
                if (_item_line_id != value)
                {
                    _item_line_id = value; RaisePropertyChanged("item_line_id");
                }
            }
        }
        private string _add_code_del;
        public string add_code_del
        {
            get
            {
                return _add_code_del;
            }

            set
            {
                if (_add_code_del != value)
                {
                    _add_code_del = value; RaisePropertyChanged("add_code_del");
                }
            }
        }
    }

    public partial class Delivery_Schedule
    {
        public string sch_no { get; set; }
        public DateTime? sch_date { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string remark { get; set; }
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public string unit_code { get; set; }
        public string ref_doc_no { get; set; }
        public DateTime? ref_doc_date { get; set; }
        public Nullable<decimal> unit_price { get; set; }
        public string ink { get; set; }
        public string grade { get; set; }
        public string ild { get; set; }
        public DateTime? confirm_date { get; set; }
        public Nullable<decimal> confirm_qty { get; set; }
        public string remark1 { get; set; }
        public Nullable<decimal> bal_qty { get; set; }
        public string trans_mode { get; set; }
        public DateTime? estimation_date { get; set; }
        public Nullable<decimal> quantity { get; set; }
        public int cycle_no { get; set; }

    }

    public class SEL_T002_BackFlip
    {
        public string sch_no { get; set; }
        public Nullable<System.DateTime> sch_date { get; set; }
        public string sch_mode { get; set; }
        public string sch_by { get; set; }
        public string sch_rec_by_cd { get; set; }
        public string t_status { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public bool active { get; set; }
        public string contact_name { get; set; }
        public string employee_name { get; set; }
        public string cust_ref { get; set; }
        public int del_address { get; set; }
        public string del_add { get; set; }
        public string Location { get; set; }
        public string t_display { get; set; }
        public string sono { get; set; }
    }
    public class MultipleContext_SEL_T002
    {
        public List<SEL_T002> MasterEntity { get; set; }
        public ObservableCollection<SEL_T002_A> ItemsEntity { get; set; }
        public List<ADM_M028_sch_P> PartyMaster { get; set; }
        public List<ADM_M028_C_P> contactInfoMaster { get; set; }
        public List<ADM_M024_P> EmployeeEntity { get; set; }
        public List<ADM_M038_B_P> UOM { get; set; }
        public List<ADM_M022_P> ItemsMaster { get; set; }
        public List<SEL_T002_BackFlip> BackFlipEntity { get; set; }
        public List<SEL_T001_P> Reference_Docs { get; set; }
        public ObservableCollection<SEL_T001_schedule_P> so_schedule { get; set; }
        public List<SEL_T002_Req_P> Req_Details { get; set; }
        public List<SEL_T002_P_RefDoc> ScheduleReference { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<ADM_M028_D_Add> DeliveryAddress { get; set; }
        public List<NotificationData> NotificationData { get; set; }
        public List<Delivery_Schedule> RptDelivery_Schedule { get; set; }
        public List<SYS_M025> t_statusList { get; set; }
        public List<ADM_M038_C> UnitConversion { get; set; }
        public List<SYS_M036> ScheduleMode { get; set; }
        public List<SYS_M026> TransportMode { get; set; }
        public List<ADM_M028_P> ServiceProviders { get; set; }
        public List<SEL_T001> SalesOrderMaster { get; set; }
        public List<SEL_T001_A> SalesOrderEntity { get; set; }

    }

    public class SEL_T002_P_RefDoc : ObjectBase
    {
        private bool _Select;
        public bool Select
        {
            get { return _Select; }
            set
            {
                _Select = value;
                RaisePropertyChanged("Select");
            }
        }
        public string Ref_DocNo { get; set; }
        public DateTime Ref_date { get; set; }
        public string doc_cat { get; set; }
        public string Ref_DocType { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string so_code { get; set; }
        public string curr_code { get; set; }
        public string country_nm_s { get; set; }
        public string del_address { get; set; }
        public string bill_address_id { get; set; }
        public string p_term_code { get; set; }
        public string incoterms { get; set; }
        public string color_code { get; set; }
        public string t_status { get; set; }
        public string t_display { get; set; }

    }

    public class ADM_M028_D_Add
    {
        public int SrNo { get; set; }
        public string AddType { get; set; }
        public string del_add { get; set; }
        public string Location { get; set; }
        public string PartyId { get; set; }
        public string add_code { get; set; }
    }
}
