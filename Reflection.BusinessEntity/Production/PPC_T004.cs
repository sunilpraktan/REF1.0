using Reflection.BusinessEntity.ADM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Production
{
    public class PPC_T004 : ObjectBase
    {
        private string _plan_no;
        public string plan_no
        {
            get { return _plan_no; }
            set { _plan_no = value; RaisePropertyChanged("plan_no"); }
        }

        private DateTime? _plan_date;
        public DateTime? plan_date
        {
            get { return _plan_date; }
            set { _plan_date = value; RaisePropertyChanged("plan_date"); }
        }

        private string _source_type;
        public string source_type
        {
            get { return _source_type; }
            set { _source_type = value; RaisePropertyChanged("source_type"); }
        }

        private string _source_no;
        public string source_no
        {
            get { return _source_no; }
            set { _source_no = value; RaisePropertyChanged("source_no"); }
        }

        private string _planning_plant;
        public string planning_plant
        {
            get { return _planning_plant; }
            set { _planning_plant = value; RaisePropertyChanged("planning_plant"); }
        }

        private string _production_plant;
        public string production_plant
        {
            get { return _production_plant; }
            set { _production_plant = value; RaisePropertyChanged("production_plant"); }
        }

        private string _cost_center;
        public string cost_center
        {
            get { return _cost_center; }
            set { _cost_center = value; RaisePropertyChanged("cost_center"); }
        }


        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }
        }

        private bool _active;
        public bool active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
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

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }

        private System.DateTime _add_date;
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

        private Nullable<System.DateTime> _edit_date;
        public DateTime? edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
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

        private string _fin_year;
        public string fin_year
        {
            get { return _fin_year; }
            set { _fin_year = value; RaisePropertyChanged("fin_year"); }
        }

        private string _posting_period;
        public string posting_period
        {
            get { return _posting_period; }
            set { _posting_period = value; RaisePropertyChanged("posting_period"); }
        }

        //scaler

        private Nullable<int> _machine_id;
        public Nullable<int> machine_id
        {
            get
            {
                return _machine_id;
            }
            set { _machine_id = value; RaisePropertyChanged(" machine_id"); }
        }

        private string _MachineCode;
        public string MachineCode
        {
            get { return _MachineCode; }
            set { _MachineCode = value; RaisePropertyChanged("MachineCode"); }
        }

        private string _wc_code;
        public string wc_code
        {
            get { return _wc_code; }
            set { _wc_code = value; RaisePropertyChanged("wc_code"); }
        }


        private string _LocationNm;
        public string LocationNm
        {
            get { return _LocationNm; }
            set { _LocationNm = value; RaisePropertyChanged("LocationNm"); }
        }
        private int? _ball_dia_id;
        public int? ball_dia_id
        {
            get { return _ball_dia_id; }
            set { _ball_dia_id = value; RaisePropertyChanged("ball_dia_id"); }
        }

        private Nullable<decimal> _Ball_dia;
        public Nullable<decimal> Ball_dia
        {
            get { return _Ball_dia; }
            set { _Ball_dia = value; RaisePropertyChanged("Ball_dia"); }
        }

        private int? _ball_type_id;
        public int? ball_type_id
        {
            get { return _ball_type_id; }
            set { _ball_type_id = value; RaisePropertyChanged("ball_type_id"); }
        }

        private string _ball_type;
        public string ball_type
        {
            get { return _ball_type; }
            set { _ball_type = value; RaisePropertyChanged("ball_type"); }
        }

        private int? _wire_size_id;
        public int? wire_size_id
        {
            get { return _wire_size_id; }
            set { _wire_size_id = value; RaisePropertyChanged("wire_size_id"); }
        }

        private Nullable<decimal> _wire_size;
        public Nullable<decimal> wire_size
        {
            get { return _wire_size; }
            set { _wire_size = value; RaisePropertyChanged("wire_size"); }
        }

        private string _location_Id2;
        public string location_Id2
        {
            get { return _location_Id2; }
            set { _location_Id2 = value; RaisePropertyChanged("location_Id2"); }
        }

        private string _LocationNm2;
        public string LocationNm2
        {
            get { return _LocationNm2; }
            set { _LocationNm2 = value; RaisePropertyChanged("LocationNm2"); }
        }

        private string _location_Id3;
        public string location_Id3
        {
            get { return _location_Id3; }
            set { _location_Id3 = value; RaisePropertyChanged("location_Id3"); }
        }

        private string _LocationNm3;
        public string LocationNm3
        {
            get { return _LocationNm3; }
            set { _LocationNm3 = value; RaisePropertyChanged("LocationNm3"); }
        }

        private int? _wire_type_id;
        public int? wire_type_id
        {
            get { return _wire_type_id; }
            set { _wire_type_id = value; RaisePropertyChanged("wire_type_id"); }
        }

        private string _wire_type;
        public string wire_type
        {
            get { return _wire_type; }
            set { _wire_type = value; RaisePropertyChanged("wire_type"); }
        }

        private bool _Fltr_active;
        public bool Fltr_active
        {
            get { return _Fltr_active; }
            set
            {
                if (_Fltr_active != value)
                {
                    _Fltr_active = value;
                    RaisePropertyChanged("Fltr_active");
                }
            }
        }

        private DateTime? _Fltr_FrmDate;
        public DateTime? Fltr_FrmDate   //FrmDate
        {
            get { return _Fltr_FrmDate; }
            set
            {
                if (_Fltr_FrmDate != value)
                {
                    _Fltr_FrmDate = value;
                    RaisePropertyChanged("Fltr_FrmDate");
                }
            }
        }

        private DateTime? _Fltr_ToDate;
        public DateTime? Fltr_ToDate    //ToDate
        {

            get { return _Fltr_ToDate; }
            set
            {
                if (_Fltr_ToDate != value)
                {
                    _Fltr_ToDate = value;
                    RaisePropertyChanged("Fltr_ToDate");
                }
            }
        }

        private string _fltr_t_status;
        public string fltr_t_status
        {
            get { return _fltr_t_status; }
            set
            {
                if (_fltr_t_status != value)
                {
                    _fltr_t_status = value; RaisePropertyChanged("fltr_t_status");
                }
            }
        }

        private string _fltr_t_display;
        public string fltr_t_display
        {
            get { return _fltr_t_display; }
            set
            {
                if (_fltr_t_display != value)
                {
                    _fltr_t_display = value; RaisePropertyChanged("fltr_t_display");
                }
            }
        }
        
        private string _t_display;
        public string t_display
        {
            get { return _t_display; }
            set { _t_display = value; RaisePropertyChanged("t_display"); }
        }
        public string xdoc_PPC_T004_A { get; set; }
        public string xdoc_PPC_T004_B { get; set; }
        public string XmlDataDocument_BackFlip { get; set; }
        public string xdoc_SEL_T001_P1 { get; set; }
    }
    public class PPC_T004_A : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }

        private int _line_id;
        public int line_id
        {
            get { return _line_id; }
            set { _line_id = value; RaisePropertyChanged("line_id", ModelEntityUpdated); }
        }

        private string _plan_no;
        public string plan_no
        {
            get { return _plan_no; }
            set { _plan_no = value; RaisePropertyChanged("plan_no"); }
        }

        private DateTime? _plan_date;
        public DateTime? plan_date
        {
            get { return _plan_date; }
            set { _plan_date = value; RaisePropertyChanged("plan_date"); }
        }

        private string _sales_order_no;
        public string sales_order_no
        {
            get { return _sales_order_no; }
            set { _sales_order_no = value; RaisePropertyChanged("sales_order_no"); }
        }

        private string _machine_no;
        public string machine_no
        {
            get { return _machine_no; }
            set { _machine_no = value; RaisePropertyChanged("machine_no"); }
        }

        private string _ItemCode;
        public string ItemCode
        {
            get { return _ItemCode; }
            set { _ItemCode = value; RaisePropertyChanged("ItemCode"); }
        }

        private string _sku;
        public string sku
        {
            get { return _sku; }
            set { _sku = value; RaisePropertyChanged("sku"); }
        }

        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code"); }
        }

        private Nullable<decimal> _plan_qty;
        public Nullable<decimal> plan_qty
        {
            get { return _plan_qty; }
            set { _plan_qty = value; RaisePropertyChanged("plan_qty", ModelEntityUpdated); }
        }

        private Nullable<System.DateTime> _production_date_start;
        public Nullable<System.DateTime> production_date_start
        {
            get { return _production_date_start; }
            set { _production_date_start = value; RaisePropertyChanged("production_date_start", ModelEntityUpdated); }
        }

        private Nullable<System.DateTime> _production_date_finish;
        public Nullable<System.DateTime> production_date_finish
        {
            get { return _production_date_finish; }
            set { _production_date_finish = value; RaisePropertyChanged("production_date_finish"); }
        }

        private string _priority;
        public string priority
        {
            get { return _priority; }
            set { _priority = value; RaisePropertyChanged("priority"); }
        }

        private string _planning_plant;
        public string planning_plant
        {
            get { return _planning_plant; }
            set { _planning_plant = value; RaisePropertyChanged("planning_plant"); }
        }

        private string _production_plant;
        public string production_plant
        {
            get { return _production_plant; }
            set { _production_plant = value; RaisePropertyChanged("production_plant"); }
        }

        private string _reference_no;
        public string reference_no
        {
            get { return _reference_no; }
            set { _reference_no = value; RaisePropertyChanged("reference_no"); }
        }

        private string _PartyId;
        public string PartyId
        {
            get { return _PartyId; }
            set { _PartyId = value; RaisePropertyChanged("PartyId"); }
        }

        private Nullable<System.DateTime> _order_confirm_date;
        public Nullable<System.DateTime> order_confirm_date
        {
            get { return _order_confirm_date; }
            set { _order_confirm_date = value; RaisePropertyChanged("order_confirm_date"); }
        }

        private Nullable<decimal> _order_qty;
        public Nullable<decimal> order_qty
        {
            get { return _order_qty; }
            set { _order_qty = value; RaisePropertyChanged("order_qty"); }
        }

        private string _sch_no;
        public string sch_no
        {
            get { return _sch_no; }
            set { _sch_no = value; RaisePropertyChanged("sch_no"); }
        }

        private string _source_no;
        public string source_no
        {
            get { return _source_no; }
            set { _source_no = value; RaisePropertyChanged("source_no"); }
        }

        private Nullable<int> _week_no;
        public Nullable<int> week_no
        {
            get { return _week_no; }
            set { _week_no = value; RaisePropertyChanged("week_no"); }
        }

        private Nullable<bool> _job_card_done;
        public Nullable<bool> job_card_done
        {
            get { return _job_card_done; }
            set { _job_card_done = value; RaisePropertyChanged("job_card_done"); }
        }

        private string _sono;
        public string sono
        {
            get { return _sono; }
            set { _sono = value; RaisePropertyChanged("sono"); }
        }

        private string _remark;
        public string remark
        {
            get { return _remark; }
            set { _remark = value; RaisePropertyChanged("remark"); }
        }

        private string _para1;
        public string para1
        {
            get { return _para1; }
            set { _para1 = value; RaisePropertyChanged("para1"); }
        }

        private string _para2;
        public string para2
        {
            get { return _para2; }
            set { _para2 = value; RaisePropertyChanged("para2"); }
        }

        private string _para3;
        public string para3
        {
            get { return _para3; }
            set { _para3 = value; RaisePropertyChanged("para3"); }
        }

        private string _para4;
        public string para4
        {
            get { return _para4; }
            set { _para4 = value; RaisePropertyChanged("para4"); }
        }

        private string _para5;
        public string para5
        {
            get { return _para5; }
            set { _para5 = value; RaisePropertyChanged("para5"); }
        }

        private string _para6;
        public string para6
        {
            get { return _para6; }
            set { _para6 = value; RaisePropertyChanged("para6"); }
        }

        private string _para7;
        public string para7
        {
            get { return _para7; }
            set { _para7 = value; RaisePropertyChanged("para7"); }
        }

        private string _para8;
        public string para8
        {
            get { return _para8; }
            set { _para8 = value; RaisePropertyChanged("para8"); }
        }

        private string _para9;
        public string para9
        {
            get { return _para9; }
            set { _para9 = value; RaisePropertyChanged("para9"); }
        }

        private string _para10;
        public string para10
        {
            get { return _para10; }
            set { _para10 = value; RaisePropertyChanged("para10"); }
        }

        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }
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

        private System.DateTime? _add_date;
        public System.DateTime? add_date
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

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
        }

        private Nullable<int> _machine_id;
        public Nullable<int> machine_id
        {
            get
            {
                return _machine_id;
            }
            set { _machine_id = value; RaisePropertyChanged("machine_id"); }
        }
        private string _bom_no;
        public string bom_no
        {
            get
            {
                return _bom_no;
            }
            set { _bom_no = value; RaisePropertyChanged("bom_no"); }
        }
        private string _wc_code;
        public string wc_code
        {
            get { return _wc_code; }
            set { _wc_code = value; RaisePropertyChanged("wc_code"); }
        }
        
        private string _doc_cat;
        public string doc_cat
        {
            get
            {
                return _doc_cat;
            }
            set { _doc_cat = value; RaisePropertyChanged("doc_cat"); }
        }
        private string _doc_type;
        public string doc_type
        {
            get
            {
                return _doc_type;
            }
            set { _doc_type = value; RaisePropertyChanged("doc_type"); }
        }
        private string _order_type;
        public string order_type
        {
            get
            {
                return _order_type;
            }
            set { _order_type = value; RaisePropertyChanged("order_type"); }
        }
        private string _pro_type;
        public string pro_type
        {
            get
            {
                return _pro_type;
            }
            set { _pro_type = value; RaisePropertyChanged("pro_type"); }
        }
        private string _spl_pro_type;
        public string spl_pro_type
        {
            get
            {
                return _spl_pro_type;
            }
            set { _spl_pro_type = value; RaisePropertyChanged("spl_pro_type"); }
        }
        private decimal? _scrap_qty;
        public decimal? scrap_qty
        {
            get
            {
                return _scrap_qty;
            }
            set { _scrap_qty = value; RaisePropertyChanged("scrap_qty"); }
        }
        private decimal? _req_qty;
        public decimal? req_qty
        {
            get
            {
                return _req_qty;
            }
            set { _req_qty = value; RaisePropertyChanged("req_qty"); }
        }
        private string _ind_conv;
        public string ind_conv
        {
            get
            {
                return _ind_conv;
            }
            set { _ind_conv = value; RaisePropertyChanged("ind_conv"); }
        }
        private string _acc_cat;
        public string acc_cat
        {
            get
            {
                return _acc_cat;
            }
            set { _acc_cat = value; RaisePropertyChanged("acc_cat"); }
        }
        private string _po_code;
        public string po_code
        {
            get
            {
                return _po_code;
            }
            set { _po_code = value; RaisePropertyChanged("po_code"); }
        }
        private string _pg_code;
        public string pg_code
        {
            get
            {
                return _pg_code;
            }
            set { _pg_code = value; RaisePropertyChanged("pg_code"); }
        }
        private string _con_posting;
        public string con_posting
        {
            get
            {
                return _con_posting;
            }
            set { _con_posting = value; RaisePropertyChanged("con_posting"); }
        }
        private string _task_list_group;
        public string task_list_group
        {
            get
            {
                return _task_list_group;
            }
            set { _task_list_group = value; RaisePropertyChanged("task_list_group"); }
        }
        private int? _group_counter;
        public int? group_counter
        {
            get
            {
                return _group_counter;
            }
            set { _group_counter = value; RaisePropertyChanged("group_counter"); }
        }
        private string _task_list_type;
        public string task_list_type
        {
            get
            {
                return _task_list_type;
            }
            set { _task_list_type = value; RaisePropertyChanged("task_list_type"); }
        }
        private string _ind_backflush;
        public string ind_backflush
        {
            get
            {
                return _ind_backflush;
            }
            set { _ind_backflush = value; RaisePropertyChanged("ind_backflush"); }
        }
        private string _req_plan_no;
        public string req_plan_no
        {
            get
            {
                return _req_plan_no;
            }
            set { _req_plan_no = value; RaisePropertyChanged("req_plan_no"); }
        }
        private string _routing_no;
        public string routing_no
        {
            get
            {
                return _routing_no;
            }
            set { _routing_no = value; RaisePropertyChanged("routing_no"); }
        }
        private string _bom_exp_no;
        public string bom_exp_no
        {
            get
            {
                return _bom_exp_no;
            }
            set { _bom_exp_no = value; RaisePropertyChanged("bom_exp_no"); }
        }

        #region Scalar Variables PPC_T004_A

        private string _ItemName;
        public string ItemName
        {
            get { return _ItemName; }
            set { _ItemName = value; RaisePropertyChanged("ItemName"); }
        }

        private string _uom_name;
        public string uom_name
        {
            get { return _uom_name; }
            set { _uom_name = value; RaisePropertyChanged(" uom_name "); }
        }

        private Nullable<decimal> _diff_in_qty;
        public Nullable<decimal> diff_in_qty
        {
            get { return _diff_in_qty; }
            set { _diff_in_qty = value; RaisePropertyChanged("diff_in_qty"); }
        }

        private string _ink_SCLR;
        public string ink_SCLR
        {
            get { return _ink_SCLR; }
            set { _ink_SCLR = value; RaisePropertyChanged("ink_SCLR"); }
        }

        private string _ild_SCLR;
        public string ild_SCLR
        {
            get { return _ild_SCLR; }
            set { _ild_SCLR = value; RaisePropertyChanged("ild_SCLR"); }
        }

        private string _BallMake_SCLR;
        public string BallMake_SCLR
        {
            get { return _BallMake_SCLR; }
            set { _BallMake_SCLR = value; RaisePropertyChanged("BallMake_SCLR"); }
        }


        private string _WireMake_SCLR;
        public string WireMake_SCLR
        {
            get { return _WireMake_SCLR; }
            set { _WireMake_SCLR = value; RaisePropertyChanged("WireMake_SCLR"); }
        }


        private string _BallType_SCLR;
        public string BallType_SCLR
        {
            get { return _BallType_SCLR; }
            set { _BallType_SCLR = value; RaisePropertyChanged("BallType_SCLR"); }
        }

        private string _WireSize_SCLR;
        public string WireSize_SCLR
        {
            get { return _WireSize_SCLR; }
            set { _WireSize_SCLR = value; RaisePropertyChanged("WireSize_SCLR"); }
        }

        private Nullable<int> _sr_no;
        public Nullable<int> sr_no
        {
            get { return _sr_no; }
            set { _sr_no = value; RaisePropertyChanged("sr_no"); }
        }

        #endregion

        //private Nullable<int> _edit_by;
        //public Nullable<int> edit_by
        //{
        //    get { return _edit_by; }
        //    set { _edit_by = value; RaisePropertyChanged(" edit_by "); }
        //}

        //private Nullable<int> _customer;
        //public Nullable<int> customer
        //{
        //    get { return _customer; }
        //    set { _customer = value; RaisePropertyChanged("customer"); }
        //}

        //private string _schedule_no;
        //public string schedule_no
        //{
        //    get { return _schedule_no; }
        //    set { _schedule_no = value; RaisePropertyChanged("schedule_no"); }
        //}

        //private string _so_no;
        //public string so_no
        //{
        //  get { return _so_no; }
        //  set { _so_no = value; RaisePropertyChanged("so_no"); }
        //}

        //private Nullable<int> _so_item;
        //public Nullable<int> so_item
        //{
        //    get { return _so_item; }
        //    set { _so_item = value; RaisePropertyChanged("so_item"); }
        //}

        //private string _plant;
        //public string plant
        //{
        //    get{return _plant; }
        //    set { _plant = value; RaisePropertyChanged("plant"); }
        //}

        //private int _company;
        //public int company
        //{
        //    get { return _company; }
        //    set { _company = value; RaisePropertyChanged("company"); }
        //}

        //private string _Property1;
        //public string Property1
        //{
        //    get{ return _Property1; }
        //    set { _Property1 = value; RaisePropertyChanged(" Property1 "); }
        //}

        //private string _Property2;
        //public string Property2
        //{
        //    get{return _Property2;}
        //    set { _Property2 = value; RaisePropertyChanged(" Property2 "); }
        //}

        //private Nullable<int> _uom;
        //public Nullable<int> uom
        //{
        //    get { return _uom; }
        //    set { _uom = value; RaisePropertyChanged("uom"); }
        //}



        private bool? _order_exists;
        public bool? order_exists
        {
            get
            {
                return _order_exists;
            }
            set { _order_exists = value; RaisePropertyChanged("order_exists"); }
        }

        private string _order_no;
        public string order_no
        {
            get
            {
                return _order_no;
            }
            set { _order_no = value; RaisePropertyChanged("order_no"); }
        }

        private string _pre_order_no;
        public string pre_order_no
        {
            get
            {
                return _pre_order_no;
            }
            set { _pre_order_no = value; RaisePropertyChanged("pre_order_no"); }
        }

        private decimal? _produced_qty;
        public decimal? produced_qty
        {
            get { return _produced_qty; }
            set { _produced_qty = value; RaisePropertyChanged("produced_qty"); }
        }

        private decimal? _balance_qty;
        public decimal? balance_qty
        {
            get { return _balance_qty; }
            set { _balance_qty = value; RaisePropertyChanged("balance_qty"); }
        }
        private int _pack_style;
        public int pack_style
        {
            get { return _pack_style; }
            set { _pack_style = value; RaisePropertyChanged("pack_style "); }
        }
        private string _pk_unit_code;
        public string pk_unit_code
        {
            get { return _pk_unit_code; }
            set { _pk_unit_code = value; RaisePropertyChanged("pk_unit_code "); }
        }
       
        private string _store_code;
        public string store_code
        {
            get { return _store_code; }
            set { _store_code = value; RaisePropertyChanged("store_code "); }
        }

    }
    public class PPC_T004_B : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }

        private int _line_id;
        public int line_id
        {
            get { return _line_id; }
            set { _line_id = value; RaisePropertyChanged("line_id"); }
        }

        private string _plan_no;
        public string plan_no
        {
            get { return _plan_no; }
            set { _plan_no = value; RaisePropertyChanged("plan_no"); }
        }

        private string _machine_no;
        public string machine_no
        {
            get { return _machine_no; }
            set { _machine_no = value; RaisePropertyChanged("machine_no"); }
        }

        private string _ItemCode;
        public string ItemCode
        {
            get { return _ItemCode; }
            set { _ItemCode = value; RaisePropertyChanged("ItemCode"); }
        }

        private string _sku;
        public string sku
        {
            get { return _sku; }
            set { _sku = value; RaisePropertyChanged("sku"); }
        }

        private Nullable<decimal> _qty;
        public Nullable<decimal> qty
        {
            get { return _qty; }
            set { _qty = value; RaisePropertyChanged("qty"); }
        }

        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code"); }
        }

        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }
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

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
        }

        private string _sono;
        public string sono
        {
            get { return _sono; }
            set { _sono = value; RaisePropertyChanged("sono"); }
        }

        private Nullable<int> _so_item_row_id;
        public Nullable<int> so_item_row_id
        {
            get { return _so_item_row_id; }
            set { _so_item_row_id = value; RaisePropertyChanged("so_item_row_id"); }
        }

        private Nullable<int> _plan_item_row_id;
        public Nullable<int> plan_item_row_id
        {
            get { return _plan_item_row_id; }
            set { _plan_item_row_id = value; RaisePropertyChanged("plan_item_row_id"); }
        }

        #region Scalar Variables PPC_T004_B

        private string _revision;
        public string revision
        {
            get { return _revision; }
            set { _revision = value; RaisePropertyChanged("revision"); }
        }

        private Nullable<int> _sr_no;
        public Nullable<int> sr_no
        {
            get { return _sr_no; }
            set { _sr_no = value; RaisePropertyChanged("sr_no"); }
        }

        private string _order_no;
        public string order_no
        {
            get { return _order_no; }
            set { _order_no = value; RaisePropertyChanged("order_no"); }
        }

        private string _PartyNm;
        public string PartyNm
        {
            get { return _PartyNm; }
            set { _PartyNm = value; RaisePropertyChanged("PartyNm"); }
        }

        private string _CustNm;
        public string CustNm
        {
            get { return _CustNm; }
            set { _CustNm = value; RaisePropertyChanged("CustNm"); }
        }

        private Nullable<System.DateTime> _sodate;
        public Nullable<System.DateTime> sodate
        {
            get { return _sodate; }
            set { _sodate = value; RaisePropertyChanged("sodate"); }
        }

        #endregion




    }
    public class MultipleContext_PPC_T004
    {
        public List<PPC_T004> MasterEntity { get; set; }
        public ObservableCollection<PPC_T004_A> MachineDetailEntity { get; set; }
        public ObservableCollection<PPC_T004_B> SoDetailEntity { get; set; }
        public List<PPC_T004_P> BackflipList { get; set; }
        public List<EPR_T001_P1> IldChartList { get; set; }
        public List<SEL_T001_P1> SalesOrderList { get; set; }
        public List<ZADM_M001_P> BallSizeList { get; set; }
        public List<ZADM_M002_P> BallTypeList { get; set; }
        public List<ZADM_M003_P> WireSizeList { get; set; }
        //public List<ZADM_M013_P> MachineList { get; set; }//old table Machine Master
        public List<PPC_M001_P> MachineList { get; set; }//New table Work Center ie M/c Master
        public List<ADM_M038_B_P> UnitList { get; set; }
        public List<ADM_M022_P> ItemList { get; set; } //Item Master
        public List<ZADM_M006_P> InkList { get; set; }  //Ink Master     
        public List<ZADM_M007_P> ILDList { get; set; } //ILD Master
        public List<ADM_M032_P> MakeList { get; set; }//Make Master       
        public List<ZADM_M004_P> WireTypeList { get; set; } //WireType Master  
        public List<ENG_T001_P> BomNoList { get; set; } //All BOM      
        //public List<EPR_T004_AMRPReportEntity> MRPRpt { get; set; }
        public List<Rpt_BillOfMaterial> MRPRpt { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<ADM_M0013> t_statusList { get; set; }
        public List<PPC_T004_B> SoDetailsILDChart { get; set; }
        public List<SYS_M013> DocCategoryList { get; set; }
        public List<ZADM_M017_P> PkgUnitList { get; set; }
        public List<MM_M001_P> store { get; set; }  //Storage Location Master
    }
}
