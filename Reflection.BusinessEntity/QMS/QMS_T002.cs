using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.QMS
{
    public class QMS_T002 : ObjectBase
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

        private string _barcode;
        public string barcode
        {
            get { return _barcode; }
            set { _barcode = value; RaisePropertyChanged("barcode"); }
        }

        private System.DateTime _doc_date;
        public System.DateTime doc_date
        {
            get { return _doc_date; }
            set { _doc_date = value; RaisePropertyChanged("doc_date"); }
        }

        private string _serv_type;
        public string serv_type
        {
            get { return _serv_type; }
            set
            {
                if (serv_type != value)
                {
                    _serv_type = value;
                    RaisePropertyChanged("serv_type", ModelEntityUpdated);
                }
            }
        }

        private string _ref_doc_no;
        public string ref_doc_no
        {
            get { return _ref_doc_no; }
            set { _ref_doc_no = value; RaisePropertyChanged("ref_doc_no"); }
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

        private string _inst_id;
        public string inst_id
        {
            get { return _inst_id; }
            set { _inst_id = value; RaisePropertyChanged("inst_id"); }
        }

        private string _model_no;
        public string model_no
        {
            get { return _model_no; }
            set { _model_no = value; RaisePropertyChanged("model_no"); }
        }

        private string _inst_name;
        public string inst_name
        {
            get { return _inst_name; }
            set { _inst_name = value; RaisePropertyChanged("inst_name"); }
        }

        private int? _qty;
        public int? qty
        {
            get { return _qty; }
            set { _qty = value; RaisePropertyChanged("qty"); }
        }

        private decimal? _least_count;
        public decimal? least_count
        {
            get { return _least_count; }
            set { _least_count = value; RaisePropertyChanged("least_count"); }
        }

        private string _inst_make;
        public string inst_make
        {
            get { return _inst_make; }
            set { _inst_make = value; RaisePropertyChanged("inst_make"); }
        }

        private string _range;
        public string range
        {
            get { return _range; }
            set { _range = value; RaisePropertyChanged("range"); }
        }

        private decimal? _accuracy_up;
        public decimal? accuracy_up
        {
            get { return _accuracy_up; }
            set { _accuracy_up = value; RaisePropertyChanged("accuracy_up"); }
        }

        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code"); }
        }

        private string _tech_spec;
        public string tech_spec
        {
            get { return _tech_spec; }
            set { _tech_spec = value; RaisePropertyChanged("tech_spec"); }
        }

        private string _sp_remark1;
        public string sp_remark1
        {
            get { return _sp_remark1; }
            set { _sp_remark1 = value; RaisePropertyChanged("sp_remark1"); }
        }

        private string _sp_remark2;
        public string sp_remark2
        {
            get { return _sp_remark2; }
            set { _sp_remark2 = value; RaisePropertyChanged("sp_remark2"); }
        }

        private string _sent_cf_to;
        public string sent_cf_to
        {
            get { return _sent_cf_to; }
            set { _sent_cf_to = value; RaisePropertyChanged("sent_cf_to"); }
        }

        private string _inst_cond;
        public string inst_cond
        {
            get { return _inst_cond; }
            set { _inst_cond = value; RaisePropertyChanged("inst_cond"); }
        }

        private string _remark;
        public string remark
        {
            get { return _remark; }
            set { _remark = value; RaisePropertyChanged("remark"); }
        }

        private string _cal_type;
        public string cal_type
        {
            get { return _cal_type; }
            set { _cal_type = value; RaisePropertyChanged("cal_type"); }
        }

        private string _PartyId;
        public string PartyId
        {
            get { return _PartyId; }
            set { _PartyId = value; RaisePropertyChanged("PartyId"); }
        }

        private string _PartyNm;
        public string PartyNm
        {
            get { return _PartyNm; }
            set { _PartyNm = value; RaisePropertyChanged("PartyNm"); }
        }

        private bool? _active;
        public bool? active
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

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }

        private DateTime _add_date;
        public DateTime add_date
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

        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id"); }
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

        private string _test_code;
        public string test_code
        {
            get { return _test_code; }
            set { _test_code = value; RaisePropertyChanged("test_code"); }
        }

        private string _inst_srno;
        public string inst_srno
        {
            get { return _inst_srno; }
            set { _inst_srno = value; RaisePropertyChanged("inst_srno"); }
        }

        private DateTime? _req_date;
        public DateTime? req_date
        {
            get { return _req_date; }
            set { _req_date = value; RaisePropertyChanged("req_date"); }
        }

        private DateTime? _exp_date;
        public DateTime? exp_date
        {
            get { return _exp_date; }
            set { _exp_date = value; RaisePropertyChanged("exp_date"); }
        }

        private int? _ref_item_row_id;
        public int? ref_item_row_id
        {
            get { return _ref_item_row_id; }
            set { _ref_item_row_id = value; RaisePropertyChanged("ref_item_row_id"); }
        }

        private DateTime? _last_date;
        public DateTime? last_date
        {
            get { return _last_date; }
            set { _last_date = value; RaisePropertyChanged("last_date", ModelEntityUpdated); }
        }

        private int? _cal_freq;
        public int? cal_freq
        {
            get { return _cal_freq; }
            set { _cal_freq = value; RaisePropertyChanged("cal_freq", ModelEntityUpdated); }
        }

        private string _cal_period;
        public string cal_period
        {
            get { return _cal_period; }
            set { _cal_period = value; RaisePropertyChanged("cal_period", ModelEntityUpdated); }
        }

        private DateTime? _next_date;
        public DateTime? next_date
        {
            get { return _next_date; }
            set { _next_date = value; RaisePropertyChanged("next_date"); }
        }

        private DateTime? _due_date;
        public DateTime? due_date
        {
            get { return _due_date; }
            set { _due_date = value; RaisePropertyChanged("due_date"); }
        }

        private string _lab_code;
        public string lab_code
        {
            get { return _lab_code; }
            set { _lab_code = value; RaisePropertyChanged("lab_code"); }
        }

        private string _insp_lot_no;
        public string insp_lot_no
        {
            get { return _insp_lot_no; }
            set
            {
                _insp_lot_no = value;
                RaisePropertyChanged("insp_lot_no");
            }
        }
        private string _sono;
        public string sono
        {
            get { return _sono; }
            set
            {
                _sono = value;
                RaisePropertyChanged("sono");
            }
        }
        private string _cont_per_name;
        public string cont_per_name
        {
            get { return _cont_per_name; }
            set { _cont_per_name = value; RaisePropertyChanged("cont_per_name"); }
        }

        private int? _ContInfoId;
        public int? ContInfoId
        {
            get { return _ContInfoId; }
            set { _ContInfoId = value; RaisePropertyChanged("ContInfoId"); }
        }
        private string _po_no;
        public string po_no
        {
            get { return _po_no; }
            set { _po_no = value; RaisePropertyChanged("po_no"); }
        }
        private string _ref_doc_cat;
        public string ref_doc_cat
        {
            get { return _ref_doc_cat; }
            set { _ref_doc_cat = value; RaisePropertyChanged("ref_doc_cat"); }
        }
        private string _ref_doc_type;
        public string ref_doc_type
        {
            get { return _ref_doc_type; }
            set { _ref_doc_type = value; RaisePropertyChanged("ref_doc_type"); }
        }
        private int? _ref_item_line_id;
        public int? ref_item_line_id
        {
            get { return _ref_item_line_id; }
            set { _ref_item_line_id = value; RaisePropertyChanged("ref_item_line_id"); }
        }
        private string _ItemCode;
        public string ItemCode
        {
            get { return _ItemCode; }
            set { _ItemCode = value; RaisePropertyChanged("ItemCode"); }
        }
        private string _so_doc_cat;
        public string so_doc_cat
        {
            get { return _so_doc_cat; }
            set { _so_doc_cat = value; RaisePropertyChanged("so_doc_cat"); }
        }
        private string _so_doc_type;
        public string so_doc_type
        {
            get { return _so_doc_type; }
            set { _so_doc_type = value; RaisePropertyChanged("so_doc_type"); }
        }
        private int? _so_item_line_id;
        public int? so_item_line_id
        {
            get { return _so_item_line_id; }
            set { _so_item_line_id = value; RaisePropertyChanged("so_item_line_id"); }
        }
        private int? _so_item_row_id;
        public int? so_item_row_id
        {
            get { return _so_item_row_id; }
            set { _so_item_row_id = value; RaisePropertyChanged("so_item_row_id"); }
        }
        private decimal? _resolution;
        public decimal? resolution
        {
            get { return _resolution; }
            set { _resolution = value; RaisePropertyChanged("resolution"); }
        }
        private string _insp_cat;
        public string insp_cat
        {
            get { return _insp_cat; }
            set { _insp_cat = value; RaisePropertyChanged("insp_cat"); }
        }

        private string _range_unit;
        public string range_unit
        {
            get { return _range_unit; }
            set { _range_unit = value; RaisePropertyChanged("range_unit"); }
        }

        private string _accuracy_up_unit;
        public string accuracy_up_unit
        {
            get { return _accuracy_up_unit; }
            set { _accuracy_up_unit = value; RaisePropertyChanged("accuracy_up_unit"); }
        }

        private string _least_count_unit;
        public string least_count_unit
        {
            get { return _least_count_unit; }
            set { _least_count_unit = value; RaisePropertyChanged("least_count_unit"); }
        }

        private string _resolution_unit;
        public string resolution_unit
        {
            get { return _resolution_unit; }
            set { _resolution_unit = value; RaisePropertyChanged("resolution_unit"); }
        }

        private decimal? _upper_range;
        public decimal? upper_range
        {
            get { return _upper_range; }
            set { _upper_range = value; RaisePropertyChanged("upper_range"); }
        }

        private decimal? _lower_range;
        public decimal? lower_range
        {
            get { return _lower_range; }
            set { _lower_range = value; RaisePropertyChanged("lower_range"); }
        }

        private string _upper_range_unit;
        public string upper_range_unit
        {
            get { return _upper_range_unit; }
            set { _upper_range_unit = value; RaisePropertyChanged("upper_range_unit"); }
        }

        private string _lower_range_unit;
        public string lower_range_unit
        {
            get { return _lower_range_unit; }
            set { _lower_range_unit = value; RaisePropertyChanged("lower_range_unit"); }
        }

        private decimal? _accuracy_down;
        public decimal? accuracy_down
        {
            get { return _accuracy_down; }
            set { _accuracy_down = value; RaisePropertyChanged("accuracy_down"); }
        }

        private string _accuracy_down_unit;
        public string accuracy_down_unit
        {
            get { return _accuracy_down_unit; }
            set { _accuracy_down_unit = value; RaisePropertyChanged("accuracy_down_unit"); }
        }
        private string _grn_no;
        public string grn_no
        {
            get { return _grn_no; }
            set { _grn_no = value; RaisePropertyChanged("grn_no"); }
        }
        private int? _grn_item_row_id;
        public int? grn_item_row_id
        {
            get { return _grn_item_row_id; }
            set { _grn_item_row_id = value; RaisePropertyChanged("grn_item_row_id"); }
        }
        // Scalar
        private string _lab_name;
        public string lab_name
        {
            get { return _lab_name; }
            set { _lab_name = value; RaisePropertyChanged("lab_name"); }
        }
        public string TranCode { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        private string _test_name;
        public string test_name
        {
            get { return _test_name; }
            set { _test_name = value; RaisePropertyChanged("test_name"); }
        }
        private string _cust_name;
        public string cust_name
        {
            get { return _cust_name; }
            set { _cust_name = value; RaisePropertyChanged("cust_name"); }
        }
        private string _assigned_to;
        public string assigned_to
        {
            get { return _assigned_to; }
            set { _assigned_to = value; RaisePropertyChanged("assigned_to"); }
        }
        private string _assigned_to_name;
        public string assigned_to_name
        {
            get { return _assigned_to_name; }
            set { _assigned_to_name = value; RaisePropertyChanged("assigned_to_name"); }
        }
        public string XmlDataDocument_QMS_T002_A { get; set; }
        public string XmlDataDocument_QMS_T002_B { get; set; }
        public string XmlDataDocument_QMS_T002_C { get; set; }
        public string XmlDataDocument_QMS_T002_D { get; set; }
        public string XmlDataDocument_QMS_T002Flip { get; set; }
    }
    public partial class QMS_T002_A : ObjectBase
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }

        private string _ItemCode;
        public string ItemCode
        {
            get { return _ItemCode; }
            set { _ItemCode = value; RaisePropertyChanged("ItemCode"); }
        }
        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set { _doc_no = value; RaisePropertyChanged("doc_no"); }
        }
        private string _ItemId;
        public string ItemId
        {
            get { return _ItemId; }
            set { _ItemId = value; RaisePropertyChanged("ItemId"); }
        }
        private string _ItemScope;
        public string ItemScope
        {
            get { return _ItemScope; }
            set { _ItemScope = value; RaisePropertyChanged("ItemScope"); }
        }
        private string _ItemType;
        public string ItemType
        {
            get { return _ItemType; }
            set { _ItemType = value; RaisePropertyChanged("ItemType"); }
        }
        private bool? _active;
        public bool? active
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

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }

        private DateTime _add_date;
        public DateTime add_date
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

        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id"); }
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

        private string _ItemName;
        public string ItemName
        {
            get { return _ItemName; }
            set { _ItemName = value; RaisePropertyChanged("ItemName"); }
        }
        private int _inst_row_id;
        public int inst_row_id
        {
            get { return _inst_row_id; }
            set { _inst_row_id = value; RaisePropertyChanged("inst_row_id"); }
        }
        // Scalar
        private int _srno;
        public int srno
        {
            get { return _srno; }
            set { _srno = value; RaisePropertyChanged("srno"); }
        }
    }
    public partial class QMS_T002_B : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int _id;
        public int id
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
        private string _inst_code;
        public string inst_code
        {
            get { return _inst_code; }
            set { _inst_code = value; RaisePropertyChanged("inst_code"); }
        }
        private string _insp_lot_no;
        public string insp_lot_no
        {
            get { return _insp_lot_no; }
            set
            {
                _insp_lot_no = value;
                RaisePropertyChanged("insp_lot_no");
            }
        }
        private string _inst_id;
        public string inst_id
        {
            get { return _inst_id; }
            set
            {
                _inst_id = value;
                RaisePropertyChanged("inst_id");
            }
        }
        private string _inst_name;
        public string inst_name
        {
            get { return _inst_name; }
            set
            {
                _inst_name = value;
                RaisePropertyChanged("inst_name");
            }
        }
        private int _qty;
        public int qty
        {
            get { return _qty; }
            set
            {
                _qty = value;
                RaisePropertyChanged("qty");
            }
        }
        private DateTime? _exp_date;
        public DateTime? exp_date
        {
            get { return _exp_date; }
            set { _exp_date = value; RaisePropertyChanged("exp_date"); }
        }
        private DateTime? _completion_date;
        public DateTime? completion_date
        {
            get { return _completion_date; }
            set { _completion_date = value; RaisePropertyChanged("completion_date"); }
        }
        private bool? _active;
        public bool? active
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

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }

        private DateTime _add_date;
        public DateTime add_date
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

        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id"); }
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

        private string _po_no;
        public string po_no
        {
            get { return _po_no; }
            set { _po_no = value; RaisePropertyChanged("po_no"); }
        }
        private string _ref_doc_no;
        public string ref_doc_no
        {
            get { return _ref_doc_no; }
            set { _ref_doc_no = value; RaisePropertyChanged("ref_doc_no"); }
        }
        private string _ref_doc_cat;
        public string ref_doc_cat
        {
            get { return _ref_doc_cat; }
            set { _ref_doc_cat = value; RaisePropertyChanged("ref_doc_cat"); }
        }
        private string _ref_doc_type;
        public string ref_doc_type
        {
            get { return _ref_doc_type; }
            set { _ref_doc_type = value; RaisePropertyChanged("ref_doc_type"); }
        }
        private int? _ref_item_line_id;
        public int? ref_item_line_id
        {
            get { return _ref_item_line_id; }
            set { _ref_item_line_id = value; RaisePropertyChanged("ref_item_line_id"); }
        }
        private int? _ref_item_row_id;
        public int? ref_item_row_id
        {
            get { return _ref_item_row_id; }
            set { _ref_item_row_id = value; RaisePropertyChanged("ref_item_row_id"); }
        }
        private string _sono;
        public string sono
        {
            get { return _sono; }
            set { _sono = value; RaisePropertyChanged("sono"); }
        }
        private string _so_doc_cat;
        public string so_doc_cat
        {
            get { return _so_doc_cat; }
            set { _so_doc_cat = value; RaisePropertyChanged("so_doc_cat"); }
        }
        private string _so_doc_type;
        public string so_doc_type
        {
            get { return _so_doc_type; }
            set { _so_doc_type = value; RaisePropertyChanged("so_doc_type"); }
        }
        private int? _so_item_line_id;
        public int? so_item_line_id
        {
            get { return _so_item_line_id; }
            set { _so_item_line_id = value; RaisePropertyChanged("so_item_line_id"); }
        }
        private int? _so_item_row_id;
        public int? so_item_row_id
        {
            get { return _so_item_row_id; }
            set { _so_item_row_id = value; RaisePropertyChanged("so_item_row_id"); }
        }
        private string _ItemCode;
        public string ItemCode
        {
            get { return _ItemCode; }
            set { _ItemCode = value; RaisePropertyChanged("ItemCode"); }
        }
        private string _inst_srno;
        public string inst_srno
        {
            get { return _inst_srno; }
            set { _inst_srno = value; RaisePropertyChanged("inst_srno"); }
        }
        private string _model_no;
        public string model_no
        {
            get { return _model_no; }
            set { _model_no = value; RaisePropertyChanged("model_no"); }
        }
        private decimal? _least_count;
        public decimal? least_count
        {
            get { return _least_count; }
            set { _least_count = value; RaisePropertyChanged("least_count"); }
        }
        private string _inst_make;
        public string inst_make
        {
            get { return _inst_make; }
            set { _inst_make = value; RaisePropertyChanged("inst_make"); }
        }
        private string _inst_cond;
        public string inst_cond
        {
            get { return _inst_cond; }
            set { _inst_cond = value; RaisePropertyChanged("inst_cond"); }
        }
        private string _range;
        public string range
        {
            get { return _range; }
            set { _range = value; RaisePropertyChanged("range"); }
        }

        private decimal? _accuracy_up;
        public decimal? accuracy_up
        {
            get { return _accuracy_up; }
            set { _accuracy_up = value; RaisePropertyChanged("accuracy_up"); }
        }

        private decimal? _accuracy_down;
        public decimal? accuracy_down
        {
            get { return _accuracy_down; }
            set { _accuracy_down = value; RaisePropertyChanged("accuracy_down"); }
        }

        private decimal? _resolution;
        public decimal? resolution
        {
            get { return _resolution; }
            set { _resolution = value; RaisePropertyChanged("resolution"); }
        }

        private string _insp_cat;
        public string insp_cat
        {
            get { return _insp_cat; }
            set { _insp_cat = value; RaisePropertyChanged("insp_cat"); }
        }

        private string _range_unit;
        public string range_unit
        {
            get { return _range_unit; }
            set { _range_unit = value; RaisePropertyChanged("range_unit"); }
        }

        private string _accuracy_up_unit;
        public string accuracy_up_unit
        {
            get { return _accuracy_up_unit; }
            set { _accuracy_up_unit = value; RaisePropertyChanged("accuracy_up_unit"); }
        }

        private string _accuracy_down_unit;
        public string accuracy_down_unit
        {
            get { return _accuracy_down_unit; }
            set { _accuracy_down_unit = value; RaisePropertyChanged("accuracy_down_unit"); }
        }

        private string _least_count_unit;
        public string least_count_unit
        {
            get { return _least_count_unit; }
            set { _least_count_unit = value; RaisePropertyChanged("least_count_unit"); }
        }

        private string _resolution_unit;
        public string resolution_unit
        {
            get { return _resolution_unit; }
            set { _resolution_unit = value; RaisePropertyChanged("resolution_unit"); }
        }

        private decimal? _upper_range;
        public decimal? upper_range
        {
            get { return _upper_range; }
            set { _upper_range = value; RaisePropertyChanged("upper_range"); }
        }

        private decimal? _lower_range;
        public decimal? lower_range
        {
            get { return _lower_range; }
            set { _lower_range = value; RaisePropertyChanged("lower_range"); }
        }

        private string _upper_range_unit;
        public string upper_range_unit
        {
            get { return _upper_range_unit; }
            set { _upper_range_unit = value; RaisePropertyChanged("upper_range_unit"); }
        }

        private string _lower_range_unit;
        public string lower_range_unit
        {
            get { return _lower_range_unit; }
            set { _lower_range_unit = value; RaisePropertyChanged("lower_range_unit"); }
        }

        private DateTime? _last_date;
        public DateTime? last_date
        {
            get { return _last_date; }
            set { _last_date = value; RaisePropertyChanged("last_date", ModelEntityUpdated); }
        }

        private int? _cal_freq;
        public int? cal_freq
        {
            get { return _cal_freq; }
            set { _cal_freq = value; RaisePropertyChanged("cal_freq", ModelEntityUpdated); }
        }

        private string _cal_period;
        public string cal_period
        {
            get { return _cal_period; }
            set { _cal_period = value; RaisePropertyChanged("cal_period", ModelEntityUpdated); }
        }

        private DateTime? _next_date;
        public DateTime? next_date
        {
            get { return _next_date; }
            set { _next_date = value; RaisePropertyChanged("next_date"); }
        }

        private DateTime? _due_date;
        public DateTime? due_date
        {
            get { return _due_date; }
            set { _due_date = value; RaisePropertyChanged("due_date"); }
        }

        //Scalar
        private int _srno;
        public int srno
        {
            get { return _srno; }
            set { _srno = value; RaisePropertyChanged("srno"); }
        }
    }
    public partial class QMS_T002_C : ObjectBase
    {
        //public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        public int id
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
        private string _inst_code;
        public string inst_code
        {
            get { return _inst_code; }
            set { _inst_code = value; RaisePropertyChanged("inst_code"); }
        }
        private string _test_code;
        public string test_code
        {
            get { return _test_code; }
            set { _test_code = value; RaisePropertyChanged("test_code"); }
        }
        private string _EmpId;
        public string EmpId
        {
            get { return _EmpId; }
            set { _EmpId = value; RaisePropertyChanged("EmpId"); }
        }
        private int _inst_row_id;
        public int inst_row_id
        {
            get { return _inst_row_id; }
            set { _inst_row_id = value; RaisePropertyChanged("inst_row_id"); }
        }
        private DateTime? _completion_date;
        public DateTime? completion_date
        {
            get { return _completion_date; }
            set { _completion_date = value; RaisePropertyChanged("completion_date"); }
        }
        private DateTime? _exp_date;
        public DateTime? exp_date
        {
            get { return _exp_date; }
            set { _exp_date = value; RaisePropertyChanged("exp_date"); }
        }
        private bool? _active;
        public bool? active
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

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }

        private DateTime _add_date;
        public DateTime add_date
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

        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id"); }
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

        private string _lab_code;
        public string lab_code
        {
            get { return _lab_code; }
            set { _lab_code = value; RaisePropertyChanged("lab_code"); }
        }
        private string _assigned_to;
        public string assigned_to
        {
            get { return _assigned_to; }
            set { _assigned_to = value; RaisePropertyChanged("assigned_to"); }
        }
        //Scalar
        private string _test_name;
        public string test_name
        {
            get { return _test_name; }
            set { _test_name = value; RaisePropertyChanged("test_name"); }
        }
        private int _srno;
        public int srno
        {
            get { return _srno; }
            set { _srno = value; RaisePropertyChanged("srno"); }
        }
        private int _deletion_id;
        public int deletion_id
        {
            get { return _deletion_id; }
            set { _deletion_id = value; RaisePropertyChanged("deletion_id"); }
        }
        private bool _Click;
        public bool Click
        {
            get { return _Click; }
            set { _Click = value; RaisePropertyChanged("Click"); }
        }
        private string _insp_type_name;
        public string insp_type_name
        {
            get { return _insp_type_name; }
            set { _insp_type_name = value; RaisePropertyChanged("insp_type_name"); }
        }
        private string _lab_name;
        public string lab_name
        {
            get { return _lab_name; }
            set { _lab_name = value; RaisePropertyChanged("lab_name"); }
        }
        private string _assigned_to_name;
        public string assigned_to_name
        {
            get { return _assigned_to_name; }
            set { _assigned_to_name = value; RaisePropertyChanged("assigned_to_name"); }
        }
    }
    public partial class QMS_T002_D : ObjectBase
    {
        private int _id;
        public int id
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
        private string _para_code;
        public string para_code
        {
            get { return _para_code; }
            set
            {
                _para_code = value;
                RaisePropertyChanged("para_code");
            }
        }
        private string _value_code;
        public string value_code
        {
            get { return _value_code; }
            set
            {
                _value_code = value;
                RaisePropertyChanged("value_code");
            }
        }
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
        private string _para_value;
        public string para_value
        {
            get { return _para_value; }
            set
            {
                _para_value = value;
                RaisePropertyChanged("para_value");
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
        private bool? _active;
        public bool? active
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
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }
        private DateTime _add_date;
        public DateTime add_date
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
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id"); }
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
        
        private int _inst_row_id;
        public int inst_row_id
        {
            get { return _inst_row_id; }
            set { _inst_row_id = value; RaisePropertyChanged("inst_row_id"); }
        }
        // Scalar
        private int _srno;
        public int srno
        {
            get { return _srno; }
            set { _srno = value; RaisePropertyChanged("srno"); }
        }
    }
    public class MultipleContext_QMS_T002
    {
        public List<SYS_M002> DocTypeInfo { get; set; }
        public List<QMS_T002> DocumentDataGrid { get; set; } //DataGridCollection used for calibration due  
        public List<QMS_T002Flip> DocumentDataFlipGrid { get; set; } //DataGridCollection 
        public List<SEL_T003_PUR_T005_RefDoc> RefDocData { get; set; }
        public List<ADM_M003_B_P> Laboratory { get; set; }
        public List<QMS_M009Flip> TestCode { get; set; }
        public List<ADM_M028_P> PartyMaster { get; set; }
        public List<ADM_M022_PopUp_Inst> AccItem { get; set; }
        public List<QMS_M004_P> AccScope { get; set; }
        public List<ADM_M024_P> Employees { get; set; }
        public List<QMS_M003_P> Instrument { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<QMS_M009_F> AdditionalParameter { get; set; }    // Additional Parameter Collection 
        public List<QMS_M009_F> ParameterValue { get; set; }    // ParameterValue Collection 
        public List<ADM_M038_B_P> UnitCode { get; set; }  //UOM List

        public List<QMS_T002> MasterEntity { get; set; }
        public ObservableCollection<QMS_T002_A> ItemEntity { get; set; }
        public ObservableCollection<QMS_T002_B> InstrumentEntity { get; set; }
        public ObservableCollection<QMS_T002_C> TestEntity { get; set; }
        public ObservableCollection<QMS_T002_D> ParameterEntity { get; set; }
    }
}