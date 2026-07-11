using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Reflection.BusinessEntity
{
    public class PUR_T001_A : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        
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
        private string _userid;
        public string userid
        {
            get { return _userid; }
            set
            {
                if (_userid != value)
                {
                    _userid = value; RaisePropertyChanged("userid");
                }
            }
        }
        
        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active", ModelEntityUpdated);
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
        private string _req_no;
        public string req_no
        {
            get { return _req_no; }
            set
            {
                _req_no = value;
                RaisePropertyChanged("req_no");
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

        private Nullable<System.DateTime> _date_start;
        public Nullable<System.DateTime> date_start
        {
            get { return _date_start; }
            set
            {
                if (value != null)
                {
                    //_date_start = value;
                    _date_start = DateTimeOffset.Parse(value.ToString(), null).DateTime;
                    RaisePropertyChanged("date_start");
                }
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


        private string _origin;
        public string origin
        {
            get { return _origin; }
            set
            {
                _origin = value;
                RaisePropertyChanged("origin");
            }
        }
        private string _description;
        public string description
        {
            get { return _description; }
            set
            {
                _description = value;
                RaisePropertyChanged("description");
            }
        }
        private string _req_type;
        public string req_type
        {
            get { return _req_type; }
            set
            {
                _req_type = value;
                RaisePropertyChanged("req_type");
            }
        }
        private Nullable<System.DateTime> _deadline;
        public Nullable<System.DateTime> deadline
        {
            get { return _deadline; }
            set
            {
                _deadline = value;
                RaisePropertyChanged("deadline");
            }
        }
        private string _wa_code;
        public string wa_code
        {
            get { return _wa_code; }
            set
            {
                _wa_code = value;
                RaisePropertyChanged("wa_code");
            }
        }


        private string _EmpId;

        public string EmpId
        {
            get { return _EmpId; }
            set
            {
                _EmpId = value;
                RaisePropertyChanged("EmpId");
            }
        }

        private string _req_ref;
        public string req_ref
        {
            get { return _req_ref; }
            set
            {
                _req_ref = value;
                RaisePropertyChanged("req_ref");
            }
        }




        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set
            {
                if (_add_by != value)
                {
                    _add_by = value;

                    RaisePropertyChanged("add_by");
                }
            }
        }
        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set
            {
                if (_add_date != value)
                {
                    _add_date = value;

                    RaisePropertyChanged("add_date");
                }
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
                if (_edit_date != value)
                {
                    _edit_date = value;

                    RaisePropertyChanged("edit_date");
                }
            }
        }

        private string _priorityNm;
        public string priorityNm
        {
            get { return _priorityNm; }
            set
            {
                _priorityNm = value;
                RaisePropertyChanged("priorityNm");
            }
        }
        private string _EmpNm;
        public string EmpNm
        {
            get { return _EmpNm; }
            set
            {
                _EmpNm = value;
                RaisePropertyChanged("EmpNm");
            }
        }
        private string _status_remark;
        public string status_remark
        {
            get { return _status_remark; }
            set
            {
                _status_remark = value;
                RaisePropertyChanged("status_remark");
            }
        }

        private string _purchase_type;
        public string purchase_type
        {
            get { return _purchase_type; }
            set
            {
                _purchase_type = value;
                RaisePropertyChanged("purchase_type");
            }
        }
        private string _doc_history_no;
        public string doc_history_no
        {
            get { return _doc_history_no; }
            set
            {
                _doc_history_no = value;
                RaisePropertyChanged("doc_history_no");
            }
        }
        private string _po_code;
        public string po_code
        {
            get { return _po_code; }
            set
            {
                _po_code = value;
                RaisePropertyChanged("po_code");
            }
        }
        private string _pg_code;
        public string pg_code
        {
            get { return _pg_code; }
            set
            {
                _pg_code = value;
                RaisePropertyChanged("pg_code");
            }
        }
        private string _pur_org;
        public string pur_org { get { return _pur_org; } set { _pur_org = value; RaisePropertyChanged("pur_org", ModelEntityUpdated); } }

        private string _pg_name;
        public string pg_name { get { return _pg_name; } set { _pg_name = value; RaisePropertyChanged("pg_name", ModelEntityUpdated); } }

        private string _dept_code;
        public string dept_code { get { return _dept_code; } set { _dept_code = value; RaisePropertyChanged("dept_code", ModelEntityUpdated); } }

        private string _dept_name;
        public string dept_name { get { return _dept_name; } set { _dept_name = value; RaisePropertyChanged("dept_name", ModelEntityUpdated); } }

        private string _tr_mode;
        public string tr_mode { get { return _tr_mode; } set { _tr_mode = value; RaisePropertyChanged("tr_mode"); } }
        private string _tr_party;
        public string tr_party { get { return _tr_party; } set { _tr_party = value; RaisePropertyChanged("tr_party"); } }
        private string _ship_inst;
        public string ship_inst { get { return _ship_inst; } set { _ship_inst = value; RaisePropertyChanged("ship_inst"); } }
        private string _location_del;
        public string location_del { get { return _location_del; } set { _location_del = value; RaisePropertyChanged("location_del"); } }



        private string _cerate_by;
        public string cerate_by { get { return _cerate_by; } set { _cerate_by = value; RaisePropertyChanged("cerate_by", ModelEntityUpdated); } }


        internal bool _Select { get; set; }
        [DisplayName("")]
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
        public string XmlDataDocument_PUR_T001_B { get; set; }
        public string XmlDataDocument_PUR_T001_C { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }
        public string doc_type_name { get; set; }
    }
    public class PUR_T001_B : ObjectBase
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

        private string _req_no;
        public string req_no
        {
            get { return _req_no; }
            set
            {
                _req_no = value;
                RaisePropertyChanged("req_no");
            }
        }


        private int _line_id;
        public int line_id
        {
            get { return _line_id; }
            set
            {
                if (_line_id != value)
                {
                    _line_id = value;

                    RaisePropertyChanged("line_id");
                }
            }
        }
        private string _ItemCode;
        [Required(ErrorMessage = "Field 'Item Code' is required.")]
        [DisplayName("Item Code")]
        public string ItemCode
        {
            get { return _ItemCode; }
            set
            {
                _ItemCode = value;
                RaisePropertyChanged("ItemCode");
                RaisePropertyChanged("ItemCode", ModelEntityUpdated);
            }
        }

        private string _description;
        public string description
        {
            get { return _description; }
            set
            {
                _description = value;
                RaisePropertyChanged("description");
            }
        }
        private string _sku;
        public string sku
        {
            get { return _sku; }
            set
            {
                _sku = value;
                RaisePropertyChanged("sku");
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

        private Nullable<decimal> _qty;
        public Nullable<decimal> qty
        {
            get { return _qty; }
            set
            {
                _qty = value;
                RaisePropertyChanged("qty");
            }
        }

        private Nullable<decimal> _appr_qty;
        public Nullable<decimal> appr_qty
        {
            get { return _appr_qty; }
            set
            {
                _appr_qty = value;
                RaisePropertyChanged("appr_qty");
            }
        }

        private Nullable<decimal> _cost;
        public Nullable<decimal> cost
        {
            get { return _cost; }
            set
            {
                _cost = value;
                // RaisePropertyChanged("cost");
                RaisePropertyChanged("cost", ModelEntityUpdated);
            }
        }

        private Nullable<System.DateTime> _expected_date;
        public Nullable<System.DateTime> expected_date
        {
            get { return _expected_date; }
            set
            {
                //_expected_date = value;
                _expected_date = DateTimeOffset.Parse(value.ToString(), null).DateTime;
                RaisePropertyChanged("expected_date");
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

        private Nullable<bool> _shipped;
        public Nullable<bool> shipped
        {
            get { return _shipped; }
            set
            {
                _shipped = value;
                RaisePropertyChanged("shipped");
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
                if (_add_by != value)
                {
                    _add_by = value;

                    RaisePropertyChanged("add_by");
                }
            }
        }
        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set
            {
                if (_add_date != value)
                {
                    _add_date = value;

                    RaisePropertyChanged("add_date");
                }
            }
        }

        private string _editby;
        public string editby
        {
            get { return _editby; }
            set
            {
                if (_editby != value)
                {
                    _editby = value;

                    RaisePropertyChanged("editby");
                }
            }
        }
        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                if (_edit_date != value)
                {
                    _edit_date = value;

                    RaisePropertyChanged("edit_date");
                }
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


        private Nullable<bool> _StockUnt;
        public Nullable<bool> StockUnt
        {
            get { return _StockUnt; }
            set
            {
                _StockUnt = value;
                RaisePropertyChanged("StockUnt");
            }
        }
        private string _SubCatCode { get; set; }

        public string SubCatCode { get { return _SubCatCode; } set { _SubCatCode = value; RaisePropertyChanged("SubCatCode"); } }
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
        private string _sku_desc;
        public string sku_desc
        {
            get { return _sku_desc; }
            set
            {
                _sku_desc = value;
                RaisePropertyChanged("sku_desc");
            }
        }
        private string _status_remark;
        public string status_remark
        {
            get { return _status_remark; }
            set
            {
                _status_remark = value;
                RaisePropertyChanged("status_remark");
            }
        }
        private string _textdata;
        public string textdata
        {
            get
            {
                return _textdata;
            }

            set
            {
                _textdata = value; RaisePropertyChanged("textdata", ModelEntityUpdated);
            }
        }
        //scalar
        private string _SubCatName;
        public string SubCatName
        {
            get { return _SubCatName; }
            set
            {
                _SubCatName = value;
                RaisePropertyChanged("SubCatName");
            }
        }

        private string _sono;
        [Required(ErrorMessage = "Field 'SO No' is required.")]
        public string sono
        {
            get { return _sono; }
            set
            {
                _sono = value;
                RaisePropertyChanged("sono", ModelEntityUpdated);
            }
        }
        private string _po_code;
        public string po_code
        {
            get { return _po_code; }
            set
            {
                _po_code = value;
                RaisePropertyChanged("po_code", ModelEntityUpdated);
            }
        }
        private string _pg_code;
        public string pg_code
        {
            get { return _pg_code; }
            set
            {
                _pg_code = value;
                RaisePropertyChanged("pg_code", ModelEntityUpdated);
            }
        }

        private string _store_code;
        public string store_code
        {
            get { return _store_code; }
            set
            {
                _store_code = value;
                RaisePropertyChanged("store_code", ModelEntityUpdated);
            }
        }
        private string _bom_no;
        public string bom_no
        {
            get { return _bom_no; }
            set
            {
                _bom_no = value;
                RaisePropertyChanged("bom_no", ModelEntityUpdated);
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
        private string _para1;
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
        private string _para2;
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

        private string _acca_cat;
        public string acca_cat
        {
            get { return _acca_cat; }
            set
            {
                if (_acca_cat != value)
                {
                    _acca_cat = value; RaisePropertyChanged("acca_cat");
                }
            }
        }
        private string _cost_center;
        public string cost_center
        {
            get { return _cost_center; }
            set
            {
                if (_cost_center != value)
                {
                    _cost_center = value; RaisePropertyChanged("cost_center");
                }
            }
        }
        private string _project_id;
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
        private string _order_no;
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
        private int? _order_res_row_id;
        public int? order_res_row_id
        {
            get { return _order_res_row_id; }
            set
            {
                if (_order_res_row_id != value)
                {
                    _order_res_row_id = value; RaisePropertyChanged("order_res_row_id");
                }
            }
        }
        private int? _op_row_id;
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
        private int? _project_no;
        public int? project_no
        {
            get { return _project_no; }
            set
            {
                if (_project_no != value)
                {
                    _project_no = value; RaisePropertyChanged("project_no");
                }
            }
        }
        private string _element_id;
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
            get { return _element_no; }
            set
            {
                if (_element_no != value)
                {
                    _element_no = value; RaisePropertyChanged("element_no");
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
                    _ref_doc_cat = value; RaisePropertyChanged("ref_doc_cat");
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
                    _ref_doc_no = value; RaisePropertyChanged("ref_doc_no");
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
                    _ref_item_row_id = value; RaisePropertyChanged("ref_item_row_id");
                }
            }
        }

        // Scallar
        private string _operation_no;
        public string operation_no
        {
            get { return _operation_no; }
            set
            {
                if (_operation_no != value)
                {
                    _operation_no = value; RaisePropertyChanged("operation_no");
                }
            }
        }
        private string _operation_desc;
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
        private string _project_name;
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
        private string _element_name;
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
    }
    public class PUR_T001_C : ObjectBase
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

        private int _line_id;
        public int line_id
        {
            get { return _line_id; }
            set
            {
                if (_line_id != value)
                {
                    _line_id = value;

                    RaisePropertyChanged("line_id");
                }
            }
        }

        private int _item_line_id;
        public int item_line_id
        {
            get { return _item_line_id; }
            set
            {
                if (_item_line_id != value)
                {
                    _item_line_id = value;

                    RaisePropertyChanged("item_line_id");
                }
            }
        }

        private int _req_item_row_id;
        public int req_item_row_id
        {
            get { return _req_item_row_id; }
            set
            {
                if (_req_item_row_id != value)
                {
                    _req_item_row_id = value;

                    RaisePropertyChanged("req_item_row_id");
                }
            }
        }

        private string _req_no;
        public string req_no
        {
            get { return _req_no; }
            set
            {
                _req_no = value;
                RaisePropertyChanged("req_no");
            }
        }

        private Nullable<decimal> _qty;
        public Nullable<decimal> qty
        {
            get { return _qty; }
            set
            {
                _qty = value;
                RaisePropertyChanged("qty");
            }
        }

        private Nullable<System.DateTime> _exp_date;
        public Nullable<System.DateTime> exp_date
        {
            get { return _exp_date; }
            set
            {
                _exp_date = value;
                RaisePropertyChanged("exp_date");
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

        private string _t_display { get; set; }
        public string t_display
        {
            get { return _t_display; }
            set
            {
                _t_display = value;
                RaisePropertyChanged("t_display");
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
    }
    public class PUR_T001_AFlip : ObjectBase
    {
        public string req_no { get; set; }
        public string doc_type { get; set; }
        public Nullable<DateTime> date_start { get; set; }
        public Nullable<DateTime> deadline { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string priorityNm { get; set; }
        public string t_status { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string purchase_type { get; set; }
        public string status_remark { get; set; }
        public string req_ref { get; set; }

        private bool _Click;
        public bool Click
        {
            get
            {
                return _Click;
            }
            set
            {
                _Click = value;
                RaisePropertyChanged("Click");
            }
        }
        public string t_display { get; set; }
        public string pur_org { get; set; }
        public string pg_name { get; set; }
        public string color_code { get; set; }
    }
    public class MultipleContext_PUR_T001_A : STD_MC_BE
    {
        public List<ADM_M043_D> APPROVALS { get; set; }
        //public List<STD_DOC_TYPE> DOC_TYPE_LIST { get; set; }
        public List<PUR_T001_AFlip> DocumentDataFlipGrid { get; set; }
        public List<ADM_M040_P> Priorities { get; set; }//Priority Master        
        public List<ADM_M024_P> Employees { get; set; }//Employee_Master
        public List<ADM_M022_P> ItemList { get; set; }
        public List<ADM_M031_P> ParameterList { get; set; } //Parameter Master
        public List<ADM_M030_P> ParamValueList { get; set; }//Flute Master
        public List<ADM_M038_B_P> uoms { get; set; }// UOM_Master 

        public List<SYS_M008_P> ItemCategoryList { get; set; }
        public List<PUR_T001_A> Pur_Req { get; set; }//Purchase Requisition

        public ObservableCollection<PUR_T001_B> Pur_Req_Details { get; set; }//Purchase Requisition Items
        public ObservableCollection<PUR_T001_C> Pur_Req_Schedule { get; set; }//Purchase Requisition Schedule
        public List<SYS_M007> doc_typeList { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<NotificationData> NotificationData { get; set; }
        public List<PUR_T001_A> MasterEntity { get; set; }
        public ObservableCollection<PUR_T001_B> ItemsEntity { get; set; }
        public List<SEL_T001_P> SalesList { get; set; }
        public List<ADM_M001_M_P> purchase_orgList { get; set; }
        public List<ADM_M001_P_P> Purchase_groupList { get; set; }
        public List<ENG_T001_P> BOM_List { get; set; }
        public List<ADM_M025_P> DepartmentList { get; set; }
        public List<PRO_T001_P> Project { get; set; }
        public List<STD_LIST_BE> PRODUCTION_ORDER_OPERATIONS { get; set; }
        //public List<ADM_M043_D> ApprovalData { get; set; }
    }


    public class ADM_M024_PopUp
    {
        public int id { get; set; }
        public string EmpId { get; set; }
        [DisplayName("Requster Name")]
        public string EmpLName { get; set; }
        public string EmpFName { get; set; }
        public string EmpMName { get; set; }
        public string EmailId { get; set; }
        public string PartyId { get; set; }
        public string Currency { get; set; }
        public string dept_code { get; set; }
        public string DeptName { get; set; }
    }

    public class ADM_M022_PopUp : ObjectBase
    {

        public int SrNo { get; set; }
        [DisplayName("Item Code")]
        public string ItemCode { get; set; }
        [DisplayName("Item Name")]
        public string ItemName { get; set; }
        public Nullable<int> unit_id { get; set; }
        [DisplayName("Unit Name")]
        public string unit_name { get; set; }
        [DisplayName("CustItemCode")]
        public string CustItemCode { get; set; }
        [DisplayName("CustItemName")]
        public string CustItemName { get; set; }
        internal bool _Select { get; set; }
        [DisplayName("")]
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
        public string unit_code { get; set; }
        public Nullable<Boolean> StockUnt { get; set; }
        public string SubCatCode { get; set; }
    }
    public class ADM_M038_B_PopUp
    {
        public int id { get; set; }
        [DisplayName("Unit")]

        public string unit_code { get; set; }
        public string unit_name { get; set; }
        //[DisplayName("Unit")]
        public string unit_abbrv { get; set; }
    }

    public class Purchase_Requision_Data
    {
        public bool select { get; set; }
        public int id { get; set; }
        public string req_no { get; set; }
        public Nullable<System.DateTime> req_date { get; set; }
        public int line_id { get; set; }
        public string ItemCode { get; set; }
        public string description { get; set; }
        public string sku { get; set; }
        public string sku_desc { get; set; }
        public string unit_code { get; set; }
        public Nullable<decimal> qty { get; set; }
        public Nullable<decimal> appr_qty { get; set; }
        public Nullable<decimal> cost { get; set; }
        public Nullable<System.DateTime> expected_date { get; set; }
        public string note { get; set; }
        public string t_status { get; set; }
        public Nullable<bool> active { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string ItemCat { get; set; }
        public string item_cat { get; set; }
        public string status_remark { get; set; }
        public string textdata { get; set; }
        public string ItemCatName { get; set; }
        public string po_code { get; set; }
        public string pg_code { get; set; }
        public string bom_no { get; set; }
        public string t_display { get; set; }
        public string color_code { get; set; }
        public string requester { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public decimal? stock_total { get; set; }

    }
}
