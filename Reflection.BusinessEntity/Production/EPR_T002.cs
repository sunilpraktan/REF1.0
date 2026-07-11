using System;
using System.Collections.Generic;
using Reflection.BusinessEntity.Production;
using Reflection.BusinessEntity.Admin;
using Reflection.BusinessEntity.ReflectionSystem;

namespace Reflection.BusinessEntity
{
    public class EPR_T002 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        public int id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value; RaisePropertyChanged("id");
            }
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
                _doc_no = value; RaisePropertyChanged("doc_no");
            }
        }

        private DateTime? _entry_dt;
        public DateTime? entry_dt
        {
            get
            {
                return _entry_dt;
            }

            set
            {
                _entry_dt = null;
                if (value <= Convert.ToDateTime("01/01/1900"))
                { _entry_dt = null; }
                else
                { _entry_dt = value; RaisePropertyChanged("entry_dt"); }
            }
        }

        private DateTime? _prod_dt;
        public DateTime? prod_dt
        {
            get
            {
                return _prod_dt;
            }

            set
            {
                _prod_dt = value;
                //_prod_dt = DateTimeOffset.Parse(value.ToString(), null).DateTime;
                RaisePropertyChanged("prod_dt", ModelEntityUpdated);
            }
        }

        private string _ItemCode;
        public string ItemCode
        {
            get
            {
                return _ItemCode;
            }

            set
            {
                _ItemCode = value; RaisePropertyChanged("ItemCode");
            }
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
                _pack_style = value; RaisePropertyChanged("pack_style");
            }
        }

        private int? _ink_id;
        public int? ink_id
        {
            get
            {
                return _ink_id;
            }

            set
            {
                _ink_id = value; RaisePropertyChanged("ink_id");
            }
        }

        private int? _ild_id;
        public int? ild_id
        {
            get
            {
                return _ild_id;
            }

            set
            {
                _ild_id = value; RaisePropertyChanged("ild_id");
            }
        }

        private string _batch_no;
        public string batch_no
        {
            get
            {
                return _batch_no;
            }

            set
            {
                _batch_no = value; RaisePropertyChanged("batch_no");
            }
        }

        private int? _machine_id;
        public int? machine_id
        {
            get
            {
                return _machine_id;
            }

            set
            {
                _machine_id = value; RaisePropertyChanged("machine_id");
            }
        }

        private string _machinecode;
        public string machinecode
        {
            get
            {
                return _machinecode;
            }

            set
            {
                _machinecode = value; RaisePropertyChanged("machinecode");
            }
        }

        private string _shift;
        public string shift
        {
            get
            {
                return _shift;
            }

            set
            {
                _shift = value; RaisePropertyChanged("shift", ModelEntityUpdated);
            }
        }

        private string _conversion;
        public string conversion
        {
            get
            {
                return _conversion;
            }

            set
            {
                _conversion = value; RaisePropertyChanged("conversion");
            }
        }


        private decimal _counter_qty;
        public decimal counter_qty
        {
            get
            {
                return _counter_qty;
            }

            set
            {
                _counter_qty = value; RaisePropertyChanged("counter_qty");
            }
        }

        private decimal? _a_qty;
        public decimal? a_qty
        {
            get
            {
                return _a_qty;
            }

            set
            {
                _a_qty = value; RaisePropertyChanged("a_qty");
            }
        }

        private decimal? _b_qty;
        public decimal? b_qty
        {
            get
            {
                return _b_qty;
            }

            set
            {
                _b_qty = value; RaisePropertyChanged("b_qty");
            }
        }

        private decimal? _c_qty;
        public decimal? c_qty
        {
            get
            {
                return _c_qty;
            }

            set
            {
                _c_qty = value; RaisePropertyChanged("c_qty");
            }
        }

        private decimal _tip_wt_1;
        public decimal tip_wt_1
        {
            get
            {
                return _tip_wt_1;
            }

            set
            {
                _tip_wt_1 = value; RaisePropertyChanged("tip_wt_1", ModelEntityUpdated);
            }
        }

        private decimal _tip_wt_2;
        public decimal tip_wt_2
        {
            get
            {
                return _tip_wt_2;
            }

            set
            {
                _tip_wt_2 = value; RaisePropertyChanged("tip_wt_2", ModelEntityUpdated);
            }
        }

        private decimal _tip_wt_3;
        public decimal tip_wt_3
        {
            get
            {
                return _tip_wt_3;
            }

            set
            {
                _tip_wt_3 = value; RaisePropertyChanged("tip_wt_3", ModelEntityUpdated);
            }
        }

        private decimal? _tip_ave_wt;
        public decimal? tip_ave_wt
        {
            get
            {
                return _tip_ave_wt;
            }

            set
            {
                _tip_ave_wt = value; RaisePropertyChanged("tip_ave_wt");
            }
        }

        private decimal? _blank_wt;
        public decimal? blank_wt
        {
            get
            {
                return _blank_wt;
            }

            set
            {
                _blank_wt = value; RaisePropertyChanged("blank_wt");
            }
        }

        private string _unit_code;
        public string unit_code
        {
            get
            {
                return _unit_code;
            }

            set
            {
                _unit_code = value; RaisePropertyChanged("unit_code");
            }
        }

        private int? _wire_make;
        public int? wire_make
        {
            get
            {
                return _wire_make;
            }

            set
            {
                _wire_make = value; RaisePropertyChanged("wire_make");
            }
        }

        private int? _ball_make;
        public int? ball_make
        {
            get
            {
                return _ball_make;
            }

            set
            {
                _ball_make = value; RaisePropertyChanged("ball_make");
            }
        }

        private bool? _auto_sort;
        public bool? auto_sort
        {
            get
            {
                return _auto_sort;
            }

            set
            {
                _auto_sort = value; RaisePropertyChanged("auto_sort");
            }
        }

        private bool? _breakdown { get; set; }
        public bool? breakdown
        {
            get
            {
                return _breakdown;
            }

            set
            {
                _breakdown = value; RaisePropertyChanged("breakdown");
            }
        }

        private string _starttime { get; set; }
        public string starttime
        {
            get
            {
                return _starttime;
            }

            set
            {
                _starttime = value; RaisePropertyChanged("starttime", ModelEntityUpdated);
            }
        }

        private string _endtime { get; set; }
        public string endtime
        {
            get
            {
                return _endtime;
            }

            set
            {
                _endtime = value; RaisePropertyChanged("endtime", ModelEntityUpdated);
            }
        }

        private string _breakdown_reason { get; set; }
        public string breakdown_reason
        {
            get
            {
                return _breakdown_reason;
            }

            set
            {
                _breakdown_reason = value; RaisePropertyChanged("breakdown_reason");
            }
        }

        private int? _no_of_bags { get; set; }
        public int? no_of_bags
        {
            get
            {
                return _no_of_bags;
            }

            set
            {
                _no_of_bags = value; RaisePropertyChanged("no_of_bags");
            }
        }

        private string _CustomerProductName;
        public string CustomerProductName
        {
            get
            {
                return _CustomerProductName;
            }

            set
            {
                _CustomerProductName = value; RaisePropertyChanged("CustomerProductName");
            }
        }

        private bool? _active;
        public bool? active
        {
            get
            {
                return _active;
            }

            set
            {
                _active = value; RaisePropertyChanged("active");
            }
        }

        private string _add_by;
        public string add_by
        {
            get
            {
                return _add_by;
            }

            set
            {
                _add_by = value; RaisePropertyChanged("add_by");
            }
        }

        private System.DateTime _add_date;
        public DateTime add_date
        {
            get
            {
                return _add_date;
            }

            set
            {
                _add_date = value; RaisePropertyChanged("add_date");
            }
        }

        private string _editby;
        public string editby
        {
            get
            {
                return _editby;
            }

            set
            {
                _editby = value; RaisePropertyChanged("editby");
            }
        }

        private DateTime? _edit_date;
        public DateTime? edit_date
        {
            get
            {
                return _edit_date;
            }

            set
            {
                _edit_date = value; RaisePropertyChanged("edit_date");
            }
        }

        private string _location_Id;
        public string location_Id
        {
            get
            {
                return _location_Id;
            }

            set
            {
                _location_Id = value; RaisePropertyChanged("location_Id");
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
                _comp_code = value; RaisePropertyChanged("comp_code");
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
                _doc_type = value; RaisePropertyChanged("doc_type");
            }
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
                _doc_cat = value; RaisePropertyChanged("doc_cat");
            }
        }

        
        private string _fin_year;
        public string fin_year
        {
            get
            {
                return _fin_year;
            }

            set
            {
                _fin_year = value; RaisePropertyChanged("fin_year");
            }
        }

        private string _posting_period;
        public string posting_period
        {
            get
            {
                return _posting_period;
            }

            set
            {
                _posting_period = value; RaisePropertyChanged("posting_period");
            }
        }

        private string _conversion_no;
        public string conversion_no
        {
            get
            {
                return _conversion_no;
            }

            set
            {
                _conversion_no = value; RaisePropertyChanged("conversion_no");
            }
        }

        private decimal _rejection_qty;
        public decimal rejection_qty
        {
            get
            {
                return _rejection_qty;
            }

            set
            {
                _rejection_qty = value; RaisePropertyChanged("rejection_qty");
            }
        }

        private string _grade;
        public string grade
        {
            get
            {
                return _grade;
            }

            set
            {
                _grade = value; RaisePropertyChanged("grade");
            }
        }

        private string _PartyId;
        public string PartyId
        {
            get
            {
                return _PartyId;
            }

            set
            {
                _PartyId = value; RaisePropertyChanged("PartyId", ModelEntityUpdated);
            }
        }

        private string _m_operator;
        public string m_operator
        {
            get
            {
                return _m_operator;
            }

            set
            {
                _m_operator = value; RaisePropertyChanged("m_operator");
            }
        }

        private string _shift_incharge;
        public string shift_incharge
        {
            get
            {
                return _shift_incharge;
            }

            set
            {
                _shift_incharge = value; RaisePropertyChanged("shift_incharge");
            }
        }

        private string _barcode;
        public string barcode
        {
            get
            {
                return _barcode;
            }

            set
            {
                _barcode = value; RaisePropertyChanged("barcode");
            }
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
                _wc_code = value; RaisePropertyChanged("wc_code", ModelEntityUpdated);
            }
        }
        
        private int? _doc_counter;
        public int? doc_counter
        {
            get
            {
                return _doc_counter;
            }

            set
            {
                _doc_counter = value; RaisePropertyChanged("doc_counter");
            }
        }
        private int? _object_id;
        public int? object_id
        {
            get
            {
                return _object_id;
            }

            set
            {
                _object_id = value; RaisePropertyChanged("object_id");
            }
        }
        private string _lang_key;
        public string lang_key
        {
            get
            {
                return _lang_key;
            }

            set
            {
                _lang_key = value; RaisePropertyChanged("lang_key");
            }
        }
        private decimal? _break_time;
        public decimal? break_time
        {
            get
            {
                return _break_time;
            }

            set
            {
                _break_time = value; RaisePropertyChanged("break_time");
            }
        }
        private string _break_time_uom;
        public string break_time_uom
        {
            get
            {
                return _break_time_uom;
            }

            set
            {
                _break_time_uom = value; RaisePropertyChanged("break_time_uom");
            }
        }
        private decimal? _ac_work;
        public decimal? ac_work
        {
            get
            {
                return _ac_work;
            }

            set
            {
                _ac_work = value; RaisePropertyChanged("ac_work", ModelEntityUpdated);
            }
        }
        private string _ac_work_uom;
        public string ac_work_uom
        {
            get
            {
                return _ac_work_uom;
            }

            set
            {
                _ac_work_uom = value; RaisePropertyChanged("ac_work_uom", ModelEntityUpdated);
            }
        }
        private decimal? _ac_duration;
        public decimal? ac_duration
        {
            get
            {
                return _ac_duration;
            }

            set
            {
                _ac_duration = value; RaisePropertyChanged("ac_duration", ModelEntityUpdated);
            }
        }
        private string _ac_duration_uom;
        public string ac_duration_uom
        {
            get
            {
                return _ac_duration_uom;
            }

            set
            {
                _ac_duration_uom = value; RaisePropertyChanged("ac_duration_uom", ModelEntityUpdated);
            }
        }
        private string _activity_type;
        public string activity_type
        {
            get
            {
                return _activity_type;
            }

            set
            {
                _activity_type = value; RaisePropertyChanged("activity_type");
            }
        }
        private string _wage_type;
        public string wage_type
        {
            get
            {
                return _wage_type;
            }

            set
            {
                _wage_type = value; RaisePropertyChanged("wage_type");
            }
        }
        private string _wage_group;
        public string wage_group
        {
            get
            {
                return _wage_group;
            }

            set
            {
                _wage_group = value; RaisePropertyChanged("wage_group");
            }
        }
        private int? _emp_no;
        public int? emp_no
        {
            get
            {
                return _emp_no;
            }

            set
            {
                _emp_no = value; RaisePropertyChanged("emp_no", ModelEntityUpdated);
            }
        }
        private decimal? _prev_yield;
        public decimal? prev_yield
        {
            get
            {
                return _prev_yield;
            }

            set
            {
                _prev_yield = value; RaisePropertyChanged("prev_yield");
            }
        }
        private decimal? _yield;
        public decimal? yield
        {
            get
            {
                return _yield;
            }

            set
            {
                _yield = value; RaisePropertyChanged("yield", ModelEntityUpdated);
            }
        }
        private decimal? _scrap_qty;
        public decimal? scrap_qty
        {
            get
            {
                return _scrap_qty;
            }

            set
            {
                _scrap_qty = value; RaisePropertyChanged("scrap_qty", ModelEntityUpdated);
            }
        }
        private decimal? _rework_qty;
        public decimal? rework_qty
        {
            get
            {
                return _rework_qty;
            }

            set
            {
                _rework_qty = value; RaisePropertyChanged("rework_qty", ModelEntityUpdated);
            }
        }
        private string _var_reson;
        public string var_reson
        {
            get
            {
                return _var_reson;
            }

            set
            {
                _var_reson = value; RaisePropertyChanged("var_reson");
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
                _emp_id = value; RaisePropertyChanged("emp_id");
            }
        }
        private DateTime? _execution_start;
        public DateTime? execution_start
        {
            get
            {
                return _execution_start;
            }

            set
            {
                _execution_start = value; RaisePropertyChanged("execution_start");
            }
        }
        private DateTime? _finish_setup;
        public DateTime? finish_setup
        {
            get
            {
                return _finish_setup;
            }

            set
            {
                _finish_setup = value; RaisePropertyChanged("finish_setup");
            }
        }
        private DateTime? _process_start;
        public DateTime? process_start
        {
            get
            {
                return _process_start;
            }

            set
            {
                _process_start = value; RaisePropertyChanged("process_start");
            }
        }
        private DateTime? _process_finish;
        public DateTime? process_finish
        {
            get
            {
                return _process_finish;
            }

            set
            {
                _process_finish = value; RaisePropertyChanged("process_finish");
            }
        }
        private DateTime? _teardown_start;
        public DateTime? teardown_start
        {
            get
            {
                return _teardown_start;
            }

            set
            {
                _teardown_start = value; RaisePropertyChanged("teardown_start");
            }
        }
        private DateTime? _execution_finish;
        public DateTime? execution_finish
        {
            get
            {
                return _execution_finish;
            }

            set
            {
                _execution_finish = value; RaisePropertyChanged("execution_finish");
            }
        }
        private string _conf_type;
        public string conf_type
        {
            get
            {
                return _conf_type;
            }

            set
            {
                _conf_type = value; RaisePropertyChanged("conf_type");
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
                _routing_no = value; RaisePropertyChanged("routing_no");
            }
        }
        private int? _order_counter;
        public int? order_counter
        {
            get
            {
                return _order_counter;
            }

            set
            {
                _order_counter = value; RaisePropertyChanged("order_counter");
            }
        }
        private string _order_no;
        public string order_no
        {
            get
            {
                return _order_no;
            }

            set
            {
                _order_no = value; RaisePropertyChanged("order_no", ModelEntityUpdated);
            }
        }
        private int? _order_seq;
        public int? order_seq
        {
            get
            {
                return _order_seq;
            }

            set
            {
                _order_seq = value; RaisePropertyChanged("order_seq");
            }
        }
        private string _operation_no;
        public string operation_no
        {
            get
            {
                return _operation_no;
            }

            set
            {
                if (_operation_no != value)
                {
                    _operation_no = value; RaisePropertyChanged("operation_no", ModelEntityUpdated);
                }
            }
        }
        private string _sub_op_no;
        public string sub_op_no
        {
            get
            {
                return _sub_op_no;
            }

            set
            {
                _sub_op_no = value; RaisePropertyChanged("sub_op_no");
            }
        }
        private int? _op_line_id;
        public int? op_line_id
        {
            get
            {
                return _op_line_id;
            }

            set
            {
                _op_line_id = value; RaisePropertyChanged("op_line_id");
            }
        }
        private int? _op_seq;
        public int? op_seq
        {
            get
            {
                return _op_seq;
            }

            set
            {
                _op_seq = value; RaisePropertyChanged("op_seq");
            }
        }
        private decimal? _op_qty;
        public decimal? op_qty
        {
            get
            {
                return _op_qty;
            }

            set
            {
                _op_qty = value; RaisePropertyChanged("op_qty");
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
                _cost_center = value; RaisePropertyChanged("cost_center");
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
                _profit_center = value; RaisePropertyChanged("profit_center");
            }
        }
        private string _party_batch_no;
        public string party_batch_no
        {
            get
            {
                return _party_batch_no;
            }

            set
            {
                _party_batch_no = value; RaisePropertyChanged("party_batch_no");
            }
        }
        private string _mat_doc_no;
        public string mat_doc_no
        {
            get
            {
                return _mat_doc_no;
            }

            set
            {
                _mat_doc_no = value; RaisePropertyChanged("mat_doc_no");
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
                _ref_doc_no = value; RaisePropertyChanged("ref_doc_no");
            }
        }
        private int? _ref_doc_item_row_id;
        public int? ref_doc_item_row_id
        {
            get
            {
                return _ref_doc_item_row_id;
            }

            set
            {
                _ref_doc_item_row_id = value; RaisePropertyChanged("ref_doc_item_row_id");
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
                _ref_doc_cat = value; RaisePropertyChanged("ref_doc_cat");
            }
        }
        private DateTime? _post_date;
        public DateTime? post_date
        {
            get
            {
                return _post_date;
            }

            set
            {
                _post_date = value; RaisePropertyChanged("post_date");
            }
        }
        private string _record_type;
        public string record_type
        {
            get
            {
                return _record_type;
            }

            set
            {
                _record_type = value; RaisePropertyChanged("record_type");
            }
        }
        private string _total_time;
        public string total_time
        {
            get
            {
                return _total_time;
            }

            set
            {
                _total_time = value; RaisePropertyChanged("total_time");
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
                _store_code = value; RaisePropertyChanged("store_code");
            }
        }
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
        private string _ind_receipt;
        public string ind_receipt
        {
            get
            {
                return _ind_receipt;
            }

            set
            {
                _ind_receipt = value; RaisePropertyChanged("ind_receipt");
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
                _sku = value; RaisePropertyChanged("sku");
            }
        }
        private decimal? _packing_qty;
        public decimal? packing_qty
        {
            get
            {
                return _packing_qty;
            }

            set
            {
                _packing_qty = value; RaisePropertyChanged("packing_qty");
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
        private int? _element_no { get; set; }
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
        //public string total_time
        //{
        //    get
        //    {
        //        return _total_time.ToString();
        //    }

        //    set
        //    {
        //        _total_time = TimeSpan.Parse(value); RaisePropertyChanged("total_time");
        //    }
        //}


        // Scalar
        private string _doc_no_op;
        public string doc_no_op
        {
            get
            {
                return _doc_no_op;
            }

            set
            {
                _doc_no_op = value; RaisePropertyChanged("doc_no_op");
            }
        }
        private string _order_type;
        public string order_type
        {
            get
            {
                return _order_type;
            }

            set
            {
                _order_type = value; RaisePropertyChanged("order_type");
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
                _PartyNm = value; RaisePropertyChanged("PartyNm");
            }
        }
        private string _Ink;
        public string Ink
        {
            get
            {
                return _Ink;
            }

            set
            {
                _Ink = value; RaisePropertyChanged("Ink");
            }
        }

        private string _Ild;
        public string Ild
        {
            get
            {
                return _Ild;
            }

            set
            {
                _Ild = value; RaisePropertyChanged("Ild");
            }
        }

        private string _BallMake;
        public string BallMake
        {
            get
            {
                return _BallMake;
            }

            set
            {
                _BallMake = value; RaisePropertyChanged("BallMake");
            }
        }

        private string _WireMake;
        public string WireMake
        {
            get
            {
                return _WireMake;
            }

            set
            {
                _WireMake = value; RaisePropertyChanged("WireMake");
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
                _PackingUnit = value; RaisePropertyChanged("PackingUnit");
            }
        }

        private Nullable<decimal> _WireSize;
        public decimal? WireSize
        {
            get
            {
                return _WireSize;
            }

            set
            {
                _WireSize = value; RaisePropertyChanged("WireSize");
            }
        }

        private string _WireType;
        public string WireType
        {
            get
            {
                return _WireType;
            }

            set
            {
                _WireType = value; RaisePropertyChanged("WireType");
            }
        }

        private Nullable<decimal> _BallSize;
        public decimal? BallSize
        {
            get
            {
                return _BallSize;
            }

            set
            {
                _BallSize = value; RaisePropertyChanged("BallSize");
            }
        }

        private string _BallType;
        public string BallType
        {
            get
            {
                return _BallType;
            }

            set
            {
                _BallType = value; RaisePropertyChanged("BallType");
            }
        }

        private string _TipLen;
        public string TipLen
        {
            get
            {
                return _TipLen;
            }

            set
            {
                _TipLen = value; RaisePropertyChanged("TipLen");
            }
        }

        private Nullable<bool> _check;
        public bool? check
        {
            get
            {
                return _check;
            }

            set
            {
                _check = value; RaisePropertyChanged("check");
            }
        }

        private string _ItemName;
        public string ItemName
        {
            get
            {
                return _ItemName;
            }

            set
            {
                _ItemName = value; RaisePropertyChanged("ItemName");
            }
        }

        private string _InchargeNm;
        public string InchargeNm
        {
            get
            {
                return _InchargeNm;
            }

            set
            {
                _InchargeNm = value; RaisePropertyChanged("InchargeNm");
            }
        }

        private string _OperatorNm;
        public string OperatorNm
        {
            get
            {
                return _OperatorNm;
            }

            set
            {
                _OperatorNm = value; RaisePropertyChanged("OperatorNm");
            }
        }

        private string _bdr_desc;
        public string bdr_desc
        {
            get
            {
                return _bdr_desc;
            }

            set
            {
                _bdr_desc = value; RaisePropertyChanged("bdr_desc");
            }
        }

        private bool? _ProductionEntryExists;
        public bool? ProductionEntryExists
        {
            get
            {
                return _ProductionEntryExists;
            }

            set
            {
                _ProductionEntryExists = value; RaisePropertyChanged("ProductionEntryExists");
            }
        }
        private DateTime? _from_date;
        public DateTime? from_date
        {
            get
            {
                return _from_date;
            }
            set
            {
                _from_date = null;
                if (value <= Convert.ToDateTime("01/01/1900"))
                { _from_date = null; }
                else
                { _from_date = value; RaisePropertyChanged("from_date"); }
            }
        }
        private DateTime? _to_date;
        public DateTime? to_date
        {
            get
            {
                return _to_date;
            }
            set
            {
                _to_date = null;
                if (value <= Convert.ToDateTime("01/01/1900"))
                { _to_date = null; }
                else
                { _to_date = value; RaisePropertyChanged("to_date"); }
            }
        }
        public byte[] qr_batch { get; set; }
        private string _t_display;
        public string t_display
        {
            get
            {
                return _t_display;
            }

            set
            {
                _t_display = value; RaisePropertyChanged("t_display");
            }
        }

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
        private string _control_key;
        public string control_key
        {
            get
            {
                return _control_key;
            }

            set
            {
                _control_key = value; RaisePropertyChanged("control_key");
            }
        }
        private string _barcode_value;
        public string barcode_value
        {
            get
            {
                return _barcode_value;
            }

            set
            {
                _barcode_value = value; RaisePropertyChanged("barcode_value");
            }
        }
        private string _order_value;
        public string order_value
        {
            get
            {
                return _order_value;
            }

            set
            {
                _order_value = value; RaisePropertyChanged("order_value");
            }
        }

        private decimal? _batch_qty;
        public decimal? batch_qty
        {
            get
            {
                return _batch_qty;
            }

            set
            {
                _batch_qty = value; RaisePropertyChanged("batch_qty");
            }
        }
        private decimal? _batch_qty_balance;
        public decimal? batch_qty_balance
        {
            get
            {
                return _batch_qty_balance;
            }

            set
            {
                _batch_qty_balance = value; RaisePropertyChanged("batch_qty_balance");
            }
        }
        private decimal? _yield_total;
        public decimal? yield_total
        {
            get
            {
                return _yield_total;
            }

            set
            {
                _yield_total = value; RaisePropertyChanged("yield_total");
            }
        }
        private decimal? _rework_total;
        public decimal? rework_total
        {
            get
            {
                return _rework_total;
            }

            set
            {
                _rework_total = value; RaisePropertyChanged("rework_total");
            }
        }
        private decimal? _scrap_total;
        public decimal? scrap_total
        {
            get
            {
                return _scrap_total;
            }

            set
            {
                _scrap_total = value; RaisePropertyChanged("scrap_total");
            }
        }
        private decimal? _op_bal_qty;
        public decimal? op_bal_qty
        {
            get
            {
                return _op_bal_qty;
            }

            set
            {
                _op_bal_qty = value; RaisePropertyChanged("op_bal_qty");
            }
        }
    }
    public class EPR_T002_A : ObjectBase
    {
        private int _id;
        private Nullable<int> _lg_line_id;
        private string _barcode;
        private string _batch_no;
        private Nullable<decimal> _label_qty;
        private string _grade;
        private Nullable<decimal> _bal_qty_merge;
        private Nullable<bool> _prod_entry_stat;
        private Nullable<bool> _carton_cons_stat;
        private Nullable<bool> _label_complete_stat;
        private bool _active;
        private string _add_by;
        private System.DateTime _add_date;
        private string _editby;
        private Nullable<System.DateTime> _edit_date;
        private string _location_Id;
        private string _comp_code;
        private Nullable<decimal> _net_wt;
        private string _doc_no;
        private string _merge_status;
        private string _parent_label;
        private string _t_status;
        private Nullable<decimal> _merge_qty;
        private string _cust_batch_no;

        public int id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value; RaisePropertyChanged("id");
            }
        }

        public int? lg_line_id
        {
            get
            {
                return _lg_line_id;
            }

            set
            {
                _lg_line_id = value; RaisePropertyChanged("lg_line_id");
            }
        }

        public string barcode
        {
            get
            {
                return _barcode;
            }

            set
            {
                _barcode = value; RaisePropertyChanged("barcode");
            }
        }

        public string batch_no
        {
            get
            {
                return _batch_no;
            }

            set
            {
                _batch_no = value; RaisePropertyChanged("batch_no");
            }
        }

        public decimal? label_qty
        {
            get
            {
                return _label_qty;
            }

            set
            {
                _label_qty = value; RaisePropertyChanged("label_qty");
            }
        }

        public string grade
        {
            get
            {
                return _grade;
            }

            set
            {
                _grade = value; RaisePropertyChanged("grade");
            }
        }

        public decimal? bal_qty_merge
        {
            get
            {
                return _bal_qty_merge;
            }

            set
            {
                _bal_qty_merge = value; RaisePropertyChanged("bal_qty_merge");
            }
        }

        public bool? prod_entry_stat
        {
            get
            {
                return _prod_entry_stat;
            }

            set
            {
                _prod_entry_stat = value; RaisePropertyChanged("prod_entry_stat");
            }
        }

        public bool? carton_cons_stat
        {
            get
            {
                return _carton_cons_stat;
            }

            set
            {
                _carton_cons_stat = value; RaisePropertyChanged("carton_cons_stat");
            }
        }

        public bool? label_complete_stat
        {
            get
            {
                return _label_complete_stat;
            }

            set
            {
                _label_complete_stat = value; RaisePropertyChanged("label_complete_stat");
            }
        }

        public bool active
        {
            get
            {
                return _active;
            }

            set
            {
                _active = value; RaisePropertyChanged("active");
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
                _add_by = value; RaisePropertyChanged("add_by");
            }
        }

        public DateTime add_date
        {
            get
            {
                return _add_date;
            }

            set
            {
                _add_date = value; RaisePropertyChanged("add_date");
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
                _editby = value; RaisePropertyChanged("editby");
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
                _edit_date = value; RaisePropertyChanged("edit_date");
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
                _location_Id = value; RaisePropertyChanged("location_Id");
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
                _comp_code = value; RaisePropertyChanged("comp_code");
            }
        }


        public decimal? net_wt
        {
            get
            {
                return _net_wt;
            }

            set
            {
                _net_wt = value; RaisePropertyChanged("net_wt");
            }
        }

        public string doc_no
        {
            get
            {
                return _doc_no;
            }

            set
            {
                _doc_no = value; RaisePropertyChanged("doc_no");
            }
        }

        public string merge_status
        {
            get
            {
                return _merge_status;
            }

            set
            {
                _merge_status = value; RaisePropertyChanged("merge_status");
            }
        }

        public string parent_label
        {
            get
            {
                return _parent_label;
            }

            set
            {
                _parent_label = value; RaisePropertyChanged("parent_label");
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
                _t_status = value; RaisePropertyChanged("t_status");
            }
        }

        public decimal? merge_qty
        {
            get
            {
                return _merge_qty;
            }

            set
            {
                _merge_qty = value; RaisePropertyChanged("merge_qty");
            }
        }

        public string cust_batch_no
        {
            get
            {
                return _cust_batch_no;
            }

            set
            {
                _cust_batch_no = value; RaisePropertyChanged("cust_batch_no");
            }
        }

    }
    public class EPR_T002_B : ObjectBase
    {
        private int _id;
        private string _new_batch_no;
        private string _old_batch_no;
        private Nullable<decimal> _qty;

        public int id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value; RaisePropertyChanged("id");
            }
        }

        public string new_batch_no
        {
            get
            {
                return _new_batch_no;
            }

            set
            {
                _new_batch_no = value; RaisePropertyChanged("new_batch_no");
            }
        }

        public string old_batch_no
        {
            get
            {
                return _old_batch_no;
            }

            set
            {
                _old_batch_no = value; RaisePropertyChanged("old_batch_no");
            }
        }

        public decimal? qty
        {
            get
            {
                return _qty;
            }

            set
            {
                _qty = value; RaisePropertyChanged("qty");
            }
        }

    }
    public class EPR_T002_Flip : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private bool _select { get; set; }
        public bool select
        {
            get
            {
                return _select;
            }

            set
            {
                _select = value; RaisePropertyChanged("select", ModelEntityUpdated);
            }
        }
        public Nullable<System.DateTime> entry_dt { get; set; }
        public Nullable<System.DateTime> prod_dt { get; set; }
        public string ItemCode { get; set; }
        public int? pack_style { get; set; }
        public Nullable<int> ink_id { get; set; }
        public Nullable<int> ild_id { get; set; }
        public Nullable<int> machine_id { get; set; }
        public string machinecode { get; set; }
        public string shift { get; set; }
        public string conversion { get; set; }
        public decimal counter_qty { get; set; }
        public Nullable<decimal> a_qty { get; set; }
        public Nullable<decimal> b_qty { get; set; }
        public Nullable<decimal> c_qty { get; set; }
        public decimal tip_wt_1 { get; set; }
        public decimal tip_wt_2 { get; set; }
        public decimal tip_wt_3 { get; set; }
        public Nullable<decimal> tip_ave_wt { get; set; }
        public Nullable<decimal> blank_wt { get; set; }
        public string unit_code { get; set; }
        public Nullable<int> wire_make { get; set; }
        public Nullable<int> ball_make { get; set; }
        public Nullable<bool> auto_sort { get; set; }
        public string CustomerProductName { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string Ink { get; set; }
        public string Ild { get; set; }
        public string BallMake { get; set; }
        public string WireMake { get; set; }
        public string PackingUnit { get; set; }
        public Nullable<bool> check { get; set; }
        public string conversion_no { get; set; }
        public Nullable<decimal> rejection_qty { get; set; }
        public string MachinePacCode { get; set; }
        public string ItemName { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string OperatorNm { get; set; }
        //Label Generation Table Fields EPR_T002_A
        public int id { get; set; }
        public Nullable<int> lg_line_id { get; set; }
        public string barcode { get; set; }
        public string batch_no { get; set; }
        public string cust_batch_no { get; set; }
        public Nullable<decimal> label_qty { get; set; }
        public string grade { get; set; }
        public Nullable<decimal> bal_qty_merge { get; set; }
        public Nullable<bool> prod_entry_stat { get; set; }

        private Nullable<bool> _carton_cons_stat;
        public Nullable<bool> carton_cons_stat
        {
            get
            {
                return _carton_cons_stat;
            }

            set
            {
                _carton_cons_stat = value; RaisePropertyChanged("carton_cons_stat");
            }
        }

        private Nullable<bool> _label_complete_stat;
        public Nullable<bool> label_complete_stat
        {
            get
            {
                return _label_complete_stat;
            }

            set
            {
                _label_complete_stat = value; RaisePropertyChanged("label_complete_stat");
            }
        }

        public bool active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public Nullable<decimal> net_wt { get; set; }
        public string doc_no { get; set; }
        public string merge_status { get; set; }
        public string parent_label { get; set; }
        public string t_status { get; set; }
        private decimal? _merge_qty { get; set; }
        public decimal? merge_qty
        {
            get
            {
                return _merge_qty;
            }

            set
            {
                _merge_qty = value; RaisePropertyChanged("merge_qty", ModelEntityUpdated);
            }
        }
        private decimal? _packing_qty;
        public decimal? packing_qty
        {
            get
            {
                return _packing_qty;
            }

            set
            {
                _packing_qty = value; RaisePropertyChanged("packing_qty");
            }
        }

        // Below Fields Are Used For Merge Label. For E.g pack_style2 is New Packing Style 
        public int? pack_style2 { get; set; }
        public string PartyId2 { get; set; }
        public string m_operator2 { get; set; }
        private string _t_display;
        public string t_display
        {
            get
            {
                return _t_display;
            }

            set
            {
                _t_display = value; RaisePropertyChanged("t_display");
            }
        }
        private string _merge_display;
        public string merge_display
        {
            get
            {
                return _merge_display;
            }

            set
            {
                _merge_display = value; RaisePropertyChanged("merge_display");
            }
        }
    }
    public partial class EPR_T002_S
    {
        public bool auto_merge { get; set; }
        public string batch_no_format { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public int range1 { get; set; }
        public int doc_no_digits { get; set; }
        public string doc_type { get; set; }
        public string report_name { get; set; }
        public bool auto_prodentry { get; set; }
        public bool auto_goodsrec { get; set; }
        public string report2 { get; set; }
        public string scan_source { get; set; }
        public int min_length { get; set; }
    }
    public class RptLabelGen
    {
        public string modelno { get; set; }
        public string batch_no { get; set; }
        public string barcode { get; set; }
        public decimal? ball_dia { get; set; }
        public string ball_type { get; set; }
        public string wire_type { get; set; }
        public decimal? label_qty { get; set; }
        public decimal? net_wt { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public string unit_code { get; set; }
        public bool? check { get; set; }
        public string cust_batch_no { get; set; }
        public string ABN { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string machinecode { get; set; }
        public string shift { get; set; }
        public DateTime? prod_dt { get; set; }
        public byte[] qr_batch { get; set; }
        public decimal? tot_qty { get; set; }
        public string batch_no_m { get; set; }
        public string doc_type { get; set; }
        public string pack_type { get; set; }
        public string total_len { get; set; }
        public string weight_unit { get; set; }
        public decimal? gross_wt { get; set; }
    }
    public class OperationList
    {
        public string order_no { get; set; }
        public string routing_no { get; set; }
        public string op_code { get; set; }
        public string operation_desc { get; set; }
        public string operation_no { get; set; }
        public string sub_op_no { get; set; }
        public int? line_id { get; set; }
        public string wc_code { get; set; }
        public string control_key { get; set; }
    }
    public class ConfirmationTypes
    {
        public string conf_type { get; set; }
        public string conf_desc { get; set; }
    }

    public class MultipleContext_EPR_T002
    {
        public List<ADM_M038_B_P> UnitList { get; set; }
        public List<ZADM_M017_P> PkgUnitList { get; set; }
        public List<ZADM_M020_P> CustomerProductList { get; set; }
        public List<ADM_M032_P> BallMakeList { get; set; }
        public List<ADM_M032_P> WireMakeList { get; set; }
        public List<ADM_M042_P> ShiftList { get; set; }
        public List<ADM_M028_P> PartyList { get; set; }
        public List<ADM_M024_P> EmployeeList { get; set; }
        public List<EPR_T002_S> SettingsList { get; set; }
        public List<ZADM_M013_P> MachineList { get; set; }
        public List<ZADM_M013_P> MachineList2 { get; set; }
        public List<ZADM_M017_P> BPkgUnitList { get; set; }     // B = BackFlip, Need Different List Coz of Diff Data
        public List<ADM_M022_P> ItemList { get; set; }
        public List<ADM_M022_P> ItemList2 { get; set; }
        public List<ZADM_M006_P> InkList { get; set; }
        public List<ZADM_M007_P> IldList { get; set; }
        public List<ZADM_M006_P> BInkList { get; set; }
        public List<ZADM_M007_P> BIldList { get; set; }
        public List<EPR_T002> LabelGenerationFromILD { get; set; }
        public List<EPR_T002> LabelGenerationList { get; set; }
        public List<EPR_T002_Flip> LabelGenBackFlipList { get; set; }
        public List<RptLabelGen> RptLabelGenList { get; set; }
        public List<EPR_T002> ProductionCounterEntryList { get; set; }
        public List<EPR_T002_Flip> IncompleteLabelList { get; set; }
        public List<ADM_M030_P> GradeList { get; set; }
        public List<PMT_M001_P> BreakdownReasonList { get; set; }
        public List<ADM_M024_P> SInchargeList { get; set; }
        public List<ECRM_T004_P> PDIDupBarcodeList { get; set; }
        public List<RptUltrasonicLabelGen> RptUltraLabelList { get; set; }
        public List<ADM_M066> Remarks { get; set; }
        public List<EPR_T001> ProductionOrderList { get; set; }
        public List<OperationList> OperationsList { get; set; }
        public List<PPC_M001> WorkCenterList { get; set; }
        public List<EPR_T002> OrderExecutionList { get; set; }
        public List<SYS_M052> RecordTypeList { get; set; }
        public List<PPC_M003> VarReasonList { get; set; }
        public List<MIS_STD_PPC_1> MIS_STD_PPC_1_LIST { get; set; }
        public List<ZADM_M013_P> MachineListMaster { get; set; }
        public List<ADM_M028_P> Customer { get; set; }
        public List<STD_DOC_TYPE> DOC_TYPE_LIST { get; set; }
        public List<EPR_T002> REWORK_ORDER_LIST { get; set; }
    }

    public class MIS_STD_PPC_1
    {
        public string client { get; set; }
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public string routing_no { get; set; }
        public string bom_no { get; set; }
        public string op_code { get; set; }
        public string operation_no { get; set; }
        public string operation_desc { get; set; }
        public string sub_op_no { get; set; }
        public string wc_code { get; set; }
        public string order_no { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public string unit_code { get; set; }
        public decimal? order_qty { get; set; }
        public decimal? issue_qty { get; set; }
        public decimal? bal_qty { get; set; }
        public decimal? consumption_qty { get; set; }
        public decimal? curr_stock_qty { get; set; }
        public decimal? required_qty { get; set; }
        public decimal? yield { get; set; }
        public decimal? scrap_qty { get; set; }
        public decimal? rework_qty { get; set; }
        public string t_display { get; set; }
        public DateTime? prod_dt { get; set; }
        public DateTime? start_dt { get; set; }
        public DateTime? end_dt { get; set; }
        public string m_operator { get; set; }
        public string shift_incharge { get; set; }
        public string conf_type { get; set; }
        public string record_type { get; set; }
        public string shift { get; set; }
        public string var_reson { get; set; }
        public string reson_desc { get; set; }
        public string batch_no { get; set; }
        public string barcode { get; set; }
        public DateTime? doc_date { get; set; }
        public string total_time { get; set; }
        public string wc_name { get; set; }
        public string store_code { get; set; }
        public decimal? final_qty { get; set; }
        public string prv_batch { get; set; }
        public decimal? ac_duration { get; set; }
        public string ac_duration_uom { get; set; }
        public decimal? bd_duration { get; set; } // Breakdown duration
        public string bd_duration_uom { get; set; } // Breakdown duration uom
    }

}
