using Reflection.BusinessEntity.ADM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Production
{
    public class ZCRM_T003 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private string _doc_no;
        private string _doc_cat;
        private string _doc_type;
        private Nullable<System.DateTime> _doc_date;
        private Nullable<System.DateTime> _insp_date;
        private string _token_no;
        private string _batch_no;
        private string _comp_code;
        private string _location_Id;
        private string _ItemCode;
        private string _sku;
        private string _sku_desc;
        private string _machinecode;
        private string _shift;
        private string _EmpId;
        private Nullable<decimal> _shank_dia_max;
        private Nullable<decimal> _shank_dia_min;
        private Nullable<decimal> _shank_champer_max;
        private Nullable<decimal> _shank_champer_min;
        private Nullable<decimal> _shank_length_max;
        private Nullable<decimal> _shank_length_min;
        private Nullable<decimal> _pin_needle_dia_max;
        private Nullable<decimal> _pin_needle_dia_min;
        private Nullable<decimal> _front_pin_dia_max;
        private Nullable<decimal> _front_pin_dia_min;
        private Nullable<decimal> _needle_length_max;
        private Nullable<decimal> _needle_length_min;
        private Nullable<decimal> _front_pin_len_max;
        private Nullable<decimal> _front_pin_len_min;
        private Nullable<decimal> _cone_len_max;
        private Nullable<decimal> _cone_len_min;
        private Nullable<decimal> _body_dia;
        private string _lock_prob;
        private string _surface_shin;
        private string _central_drill;
        private string _first_drill;
        private string _loose_ball;
        private Nullable<decimal> _finish_tip_ball_ht_max;
        private Nullable<decimal> _finish_tip_ball_ht_min;
        private string _in_out_profile;
        private string _tip_ball_spin;
        private Nullable<decimal> _finish_tip_len_max;
        private Nullable<decimal> _finish_tip_len_min;
        private string _t_status;
        private Nullable<bool> _active;
        private string _add_by;
        private Nullable<System.DateTime> _add_date;
        private string _editby;
        private Nullable<System.DateTime> _edit_date;
        private DateTime? _prod_dt;
        private string _conversion_no;
        private string _unit_code { get; set; }
        private string _fin_year { get; set; }
        private string _posting_period { get; set; }
        private string _EmpName { get; set; }
        private string _ItemName { get; set; }
        private Nullable<decimal> _pin_length_min { get; set; }
        private Nullable<decimal> _pin_length_max { get; set; }
        private string _barcode { get; set; }
        private string _ref_doc_type { get; set; }
        private string _ref_Doc_TypeNm { get; set; }
        private string _RefDocNo { get; set; }
        private decimal? _ball_gripping_force_min { get; set; }
        private decimal? _ball_gripping_force_max { get; set; }
        private string _remark { get; set; }
        private string _qc_person { get; set; }
        private string _QcName { get; set; }
        private string _remark1 { get; set; }
        private string _remark2 { get; set; }
        private decimal? _pin_dia_min { get; set; }
        private decimal? _pin_dia_max { get; set; }
        private decimal? _wt1no_of_pieces { get; set; }
        private Decimal? _wt2no_of_pieces { get; set; }
        private string _wt1decision { get; set; }
        private string _wt2decision { get; set; }
        private string _wt1remark { get; set; }
        private string _wt2remark { get; set; }
        private bool? _life_test { get; set; }
        private string _decision { get; set; }
        private decimal? _no_of_pages { get; set; }
        private string _ltremark { get; set; }

        private string _qc_person1 { get; set; }
        private string _EmpId1 { get; set; }
        private System.DateTime? _Fromdt { get; set; }
        private System.DateTime? _Todt { get; set; }
        private string _con_no { get; set; }
        private string _sshift { get; set; }
        private string _machine { get; set; }
        private string _item { get; set; }

        private Nullable<decimal> _check_qty { get; set; }

        public string doc_no
        {
            get
            {
                return _doc_no;
            }

            set
            {
                _doc_no = value; RaisePropertyChanged("doc_no", ModelEntityUpdated);
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
                _doc_cat = value; RaisePropertyChanged("doc_cat", ModelEntityUpdated);
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
                _doc_type = value; RaisePropertyChanged("doc_type", ModelEntityUpdated);
            }
        }

        public DateTime? doc_date
        {
            get
            {
                return _doc_date;
            }

            set
            {
                _doc_date = value; RaisePropertyChanged("doc_date", ModelEntityUpdated);
            }
        }

        public DateTime? insp_date
        {
            get
            {
                return _insp_date;
            }

            set
            {
                _insp_date = value; RaisePropertyChanged("insp_date", ModelEntityUpdated);
            }
        }

        public string token_no
        {
            get
            {
                return _token_no;
            }

            set
            {
                _token_no = value; RaisePropertyChanged("token_no", ModelEntityUpdated);
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
                _batch_no = value; RaisePropertyChanged("batch_no", ModelEntityUpdated);
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
                _comp_code = value; RaisePropertyChanged("comp_code", ModelEntityUpdated);
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
                _location_Id = value; RaisePropertyChanged("location_Id", ModelEntityUpdated);
            }
        }

        public string ItemCode
        {
            get
            {
                return _ItemCode;
            }

            set
            {
                _ItemCode = value; RaisePropertyChanged("ItemCode", ModelEntityUpdated);
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
                _sku = value; RaisePropertyChanged("sku", ModelEntityUpdated);
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
                _sku_desc = value; RaisePropertyChanged("sku_desc", ModelEntityUpdated);
            }
        }

        public string machinecode
        {
            get
            {
                return _machinecode;
            }

            set
            {
                _machinecode = value; RaisePropertyChanged("machinecode", ModelEntityUpdated);
            }
        }

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

        public string EmpId
        {
            get
            {
                return _EmpId;
            }

            set
            {
                _EmpId = value; RaisePropertyChanged("EmpId", ModelEntityUpdated);
            }
        }

        public decimal? shank_dia_max
        {
            get
            {
                return _shank_dia_max;
            }

            set
            {
                _shank_dia_max = value; RaisePropertyChanged("shank_dia_max", ModelEntityUpdated);
            }
        }

        public decimal? shank_dia_min
        {
            get
            {
                return _shank_dia_min;
            }

            set
            {
                _shank_dia_min = value; RaisePropertyChanged("shank_dia_min", ModelEntityUpdated);
            }
        }

        public decimal? shank_champer_max
        {
            get
            {
                return _shank_champer_max;
            }

            set
            {
                _shank_champer_max = value; RaisePropertyChanged("shank_champer_max", ModelEntityUpdated);
            }
        }

        public decimal? shank_champer_min
        {
            get
            {
                return _shank_champer_min;
            }

            set
            {
                _shank_champer_min = value; RaisePropertyChanged("shank_champer_min", ModelEntityUpdated);
            }
        }

        public decimal? shank_length_max
        {
            get
            {
                return _shank_length_max;
            }

            set
            {
                _shank_length_max = value; RaisePropertyChanged("shank_length_max", ModelEntityUpdated);
            }
        }

        public decimal? shank_length_min
        {
            get
            {
                return _shank_length_min;
            }

            set
            {
                _shank_length_min = value; RaisePropertyChanged("shank_length_min", ModelEntityUpdated);
            }
        }

        public decimal? pin_needle_dia_max
        {
            get
            {
                return _pin_needle_dia_max;
            }

            set
            {
                _pin_needle_dia_max = value; RaisePropertyChanged("pin_needle_dia_max", ModelEntityUpdated);
            }
        }

        public decimal? pin_needle_dia_min
        {
            get
            {
                return _pin_needle_dia_min;
            }

            set
            {
                _pin_needle_dia_min = value; RaisePropertyChanged("pin_needle_dia_min", ModelEntityUpdated);
            }
        }

        public decimal? front_pin_dia_max
        {
            get
            {
                return _front_pin_dia_max;
            }

            set
            {
                _front_pin_dia_max = value; RaisePropertyChanged("front_pin_dia_max", ModelEntityUpdated);
            }
        }

        public decimal? front_pin_dia_min
        {
            get
            {
                return _front_pin_dia_min;
            }

            set
            {
                _front_pin_dia_min = value; RaisePropertyChanged("front_pin_dia_min", ModelEntityUpdated);
            }
        }

        public decimal? needle_length_max
        {
            get
            {
                return _needle_length_max;
            }

            set
            {
                _needle_length_max = value; RaisePropertyChanged("needle_length_max", ModelEntityUpdated);
            }
        }

        public decimal? needle_length_min
        {
            get
            {
                return _needle_length_min;
            }

            set
            {
                _needle_length_min = value; RaisePropertyChanged("needle_length_min", ModelEntityUpdated);
            }
        }

        public decimal? front_pin_len_max
        {
            get
            {
                return _front_pin_len_max;
            }

            set
            {
                _front_pin_len_max = value; RaisePropertyChanged("front_pin_len_max", ModelEntityUpdated);
            }
        }

        public decimal? front_pin_len_min
        {
            get
            {
                return _front_pin_len_min;
            }

            set
            {
                _front_pin_len_min = value; RaisePropertyChanged("front_pin_len_min", ModelEntityUpdated);
            }
        }

        public decimal? cone_len_max
        {
            get
            {
                return _cone_len_max;
            }

            set
            {
                _cone_len_max = value; RaisePropertyChanged("cone_len_max", ModelEntityUpdated);
            }
        }

        public decimal? cone_len_min
        {
            get
            {
                return _cone_len_min;
            }

            set
            {
                _cone_len_min = value; RaisePropertyChanged("cone_len_min", ModelEntityUpdated);
            }
        }

        public decimal? body_dia
        {
            get
            {
                return _body_dia;
            }

            set
            {
                _body_dia = value; RaisePropertyChanged("body_dia", ModelEntityUpdated);
            }
        }

        public string lock_prob
        {
            get
            {
                return _lock_prob;
            }

            set
            {
                _lock_prob = value; RaisePropertyChanged("lock_prob", ModelEntityUpdated);
            }
        }

        public string surface_shin
        {
            get
            {
                return _surface_shin;
            }

            set
            {
                _surface_shin = value; RaisePropertyChanged("surface_shin", ModelEntityUpdated);
            }
        }

        public string central_drill
        {
            get
            {
                return _central_drill;
            }

            set
            {
                _central_drill = value; RaisePropertyChanged("central_drill", ModelEntityUpdated);
            }
        }

        public string first_drill
        {
            get
            {
                return _first_drill;
            }

            set
            {
                _first_drill = value; RaisePropertyChanged("first_drill", ModelEntityUpdated);
            }
        }

        public string loose_ball
        {
            get
            {
                return _loose_ball;
            }

            set
            {
                _loose_ball = value; RaisePropertyChanged("loose_ball", ModelEntityUpdated);
            }
        }

        public decimal? finish_tip_ball_ht_max
        {
            get
            {
                return _finish_tip_ball_ht_max;
            }

            set
            {
                _finish_tip_ball_ht_max = value; RaisePropertyChanged("finish_tip_ball_ht_max", ModelEntityUpdated);
            }
        }

        public decimal? finish_tip_ball_ht_min
        {
            get
            {
                return _finish_tip_ball_ht_min;
            }

            set
            {
                _finish_tip_ball_ht_min = value; RaisePropertyChanged("finish_tip_ball_ht_min", ModelEntityUpdated);
            }
        }

        public string in_out_profile
        {
            get
            {
                return _in_out_profile;
            }

            set
            {
                _in_out_profile = value; RaisePropertyChanged("in_out_profile", ModelEntityUpdated);
            }
        }

        public string tip_ball_spin
        {
            get
            {
                return _tip_ball_spin;
            }

            set
            {
                _tip_ball_spin = value; RaisePropertyChanged("tip_ball_spin", ModelEntityUpdated);
            }
        }

        public decimal? finish_tip_len_max
        {
            get
            {
                return _finish_tip_len_max;
            }

            set
            {
                _finish_tip_len_max = value; RaisePropertyChanged("finish_tip_len_max", ModelEntityUpdated);
            }
        }

        public decimal? finish_tip_len_min
        {
            get
            {
                return _finish_tip_len_min;
            }

            set
            {
                _finish_tip_len_min = value; RaisePropertyChanged("finish_tip_len_min", ModelEntityUpdated);
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
                _t_status = value; RaisePropertyChanged("t_status", ModelEntityUpdated);
            }
        }

        public bool? active
        {
            get
            {
                return _active;
            }

            set
            {
                _active = value; RaisePropertyChanged("active", ModelEntityUpdated);
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
                _add_by = value; RaisePropertyChanged("add_by", ModelEntityUpdated);
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
                _add_date = value; RaisePropertyChanged("add_date", ModelEntityUpdated);
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
                _editby = value; RaisePropertyChanged("editby", ModelEntityUpdated);
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
                _edit_date = value; RaisePropertyChanged("edit_date", ModelEntityUpdated);
            }
        }

        public DateTime? prod_dt
        {
            get
            {
                return _prod_dt;
            }

            set
            {
                _prod_dt = value; RaisePropertyChanged("prod_dt", ModelEntityUpdated);
            }
        }
        public string conversion_no
        {
            get
            {
                return _conversion_no;
            }

            set
            {
                _conversion_no = value; RaisePropertyChanged("conversion_no", ModelEntityUpdated);
            }
        }
        public string unit_code
        {
            get
            {
                return _unit_code;
            }

            set
            {
                _unit_code = value; RaisePropertyChanged("unit_code", ModelEntityUpdated);
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
                _fin_year = value; RaisePropertyChanged("fin_year", ModelEntityUpdated);
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
                _posting_period = value; RaisePropertyChanged("posting_period", ModelEntityUpdated);
            }
        }

        public Nullable<decimal> pin_length_min
        {
            get
            {
                return _pin_length_min;
            }
            set
            {
                _pin_length_min = value; RaisePropertyChanged("pin_length_min", ModelEntityUpdated);
            }
        }
        public Nullable<decimal> pin_length_max
        {
            get
            {
                return _pin_length_max;
            }
            set
            {
                _pin_length_max = value; RaisePropertyChanged("pin_length_max", ModelEntityUpdated);
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
                _barcode = value; RaisePropertyChanged("barcode", ModelEntityUpdated);
            }
        }
        public decimal? ball_gripping_force_min
        {
            get
            {
                return _ball_gripping_force_min;
            }
            set
            {
                _ball_gripping_force_min = value; RaisePropertyChanged("ball_gripping_force_min");
            }
        }
        public decimal? ball_gripping_force_max
        {
            get
            {
                return _ball_gripping_force_max;
            }
            set
            {
                _ball_gripping_force_max = value; RaisePropertyChanged("ball_gripping_force_max");
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
                _remark = value; RaisePropertyChanged("remark");
            }
        }
        public string qc_person
        {
            get
            {
                return _qc_person;
            }
            set
            {
                _qc_person = value; RaisePropertyChanged("qc_person");
            }
        }
        public string QcName
        {
            get { return _QcName; }
            set { _QcName = value; RaisePropertyChanged("QcName"); }
        }
        public string remark1
        {
            get { return _remark1; }
            set { _remark1 = value; RaisePropertyChanged("remark1"); }
        }
        public string remark2
        {
            get { return _remark2; }
            set { _remark2 = value; RaisePropertyChanged("remark2"); }
        }
        public decimal? pin_dia_min
        {
            get { return _pin_dia_min; }
            set { _pin_dia_min = value; RaisePropertyChanged("pin_dia_min"); }
        }
        public decimal? pin_dia_max
        {
            get { return _pin_dia_max; }
            set { _pin_dia_max = value; RaisePropertyChanged("pin_dia_max"); }
        }

        public decimal? wt1no_of_pieces
        {
            get { return _wt1no_of_pieces; }
            set { _wt1no_of_pieces = value; RaisePropertyChanged("wt1no_of_pieces"); }
        }
        public decimal? wt2no_of_pieces
        {
            get { return _wt2no_of_pieces; }
            set { _wt2no_of_pieces = value; RaisePropertyChanged("wt2no_of_pieces"); }
        }

        public string wt1decision
        {
            get { return _wt1decision; }
            set { _wt1decision = value; RaisePropertyChanged("wt1decision"); }
        }
        public string wt2decision
        {
            get { return _wt2decision; }
            set { _wt2decision = value; RaisePropertyChanged("wt2decision"); }
        }
        public string wt1remark
        {
            get { return _wt1remark; }
            set { _wt1remark = value; RaisePropertyChanged("wt1remark"); }
        }
        public string wt2remark
        {
            get { return _wt2remark; }
            set { _wt2remark = value; RaisePropertyChanged("wt2remark"); }
        }
        public bool? life_test
        {
            get { return _life_test; }
            set { _life_test = value; RaisePropertyChanged("life_test"); }
        }
        public string decision
        {
            get { return _decision; }
            set { _decision = value; RaisePropertyChanged("decision"); }
        }
        public decimal? no_of_pages
        {
            get { return _no_of_pages; }
            set { _no_of_pages = value; RaisePropertyChanged("no_of_pages"); }
        }
        public string ltremark
        {
            get { return _ltremark; }
            set { _ltremark = value; RaisePropertyChanged("ltremark"); }
        }
        //scalar Variable
        public string EmpName
        {
            get
            {
                return _EmpName;
            }

            set
            {
                _EmpName = value; RaisePropertyChanged("EmpName", ModelEntityUpdated);
            }
        }
        public string ItemName
        {
            get
            {
                return _ItemName;
            }

            set
            {
                _ItemName = value; RaisePropertyChanged("ItemName", ModelEntityUpdated);
            }
        }
        public string BackFlipEntity { get; set; }
        public string XmlDataDocument_ZCRM_T003_A { get; set; }
        public string ref_doc_type
        {
            get
            { return _ref_doc_type; }
            set
            {
                _ref_doc_type = value; RaisePropertyChanged("ref_doc_type");
            }
        }
        public string ref_Doc_TypeNm
        {
            get
            { return _ref_Doc_TypeNm; }
            set
            {
                _ref_Doc_TypeNm = value; RaisePropertyChanged("ref_Doc_TypeNm");
            }
        }
        public string RefDocNo
        {
            get
            { return _RefDocNo; }
            set
            {
                _RefDocNo = value; RaisePropertyChanged("RefDocNo");
            }
        }
        public string qc_person1
        {
            get
            { return _qc_person1; }
            set
            {
                _qc_person1 = value; RaisePropertyChanged("qc_person1");
            }
        }
        public string EmpId1
        {
            get
            { return _EmpId1; }
            set
            {
                _EmpId1 = value; RaisePropertyChanged("EmpId1");
            }
        }

        public System.DateTime? Fromdt
        {
            get
            { return _Fromdt; }
            set
            {
                _Fromdt = value; RaisePropertyChanged("Fromdt");
            }
        }
        public System.DateTime? Todt
        {
            get
            { return _Todt; }
            set
            {
                _Todt = value; RaisePropertyChanged("Todt");
            }
        }
        public string con_no
        {
            get
            { return _con_no; }
            set
            {
                _con_no = value; RaisePropertyChanged("con_no");
            }
        }
        public string sshift
        {
            get
            { return _sshift; }
            set
            {
                _sshift = value; RaisePropertyChanged("sshift");
            }
        }
        public string machine
        {
            get
            { return _machine; }
            set
            {
                _machine = value; RaisePropertyChanged("machine");
            }
        }
        public string item
        {
            get
            { return _item; }
            set
            {
                _item = value; RaisePropertyChanged("item");
            }
        }

        public Nullable<decimal> check_qty
        {
            get
            { return _check_qty; }
            set
            {
                _check_qty = value; RaisePropertyChanged("check_qty");
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
                    _t_display = value;
                    RaisePropertyChanged("t_display");
                }
            }
        }
        private string _wc_code;
        public string wc_code
        {
            get { return _wc_code; }
            set { if (_wc_code != value) { _wc_code = value; RaisePropertyChanged("wc_code"); } }
        }
        private string _grade;
        public string grade
        {
            get { return _grade; }
            set { if (_grade != value) { _grade = value; RaisePropertyChanged("grade"); } }
        }
        private decimal? _counter_qty;
        public decimal? counter_qty
        {
            get { return _counter_qty; }
            set { if (_counter_qty != value) { _counter_qty = value; RaisePropertyChanged("counter_qty"); } }
        }
        private string _counter_remark;
        public string counter_remark
        {
            get { return _counter_remark; }
            set { if (_counter_remark != value) { _counter_remark = value; RaisePropertyChanged("counter_remark"); } }
        }
    }

    public class ZCRM_T003_A : ObjectBase
    {
        private int _id;
        public int id
        {
            get
            { return _id; }

            set
            {
                _id = value; RaisePropertyChanged("id");
            }
        }
        private string _doc_no;
        public string doc_no
        {
            get
            { return _doc_no; }

            set
            {
                _doc_no = value; RaisePropertyChanged("doc_no");
            }
        }
        private string _defect;
        public string defect
        {
            get
            { return _defect; }

            set
            {
                _defect = value; RaisePropertyChanged("defect");
            }
        }
        private string _DefectNm;
        public string DefectNm
        {
            get
            { return _DefectNm; }

            set
            {
                _DefectNm = value; RaisePropertyChanged("DefectNm");
            }
        }
        private string _parameters;
        public string parameters
        {
            get
            { return _parameters; }

            set
            {
                _parameters = value; RaisePropertyChanged("parameters");
            }
        }
        private string _parameterNm;
        public string parameterNm
        {
            get
            { return _parameterNm; }

            set
            {
                _parameterNm = value; RaisePropertyChanged("parameterNm");
            }
        }
        private string _observation;
        public string observation
        {
            get
            { return _observation; }

            set
            {
                _observation = value; RaisePropertyChanged("observation");
            }
        }
        private Nullable<decimal> _defect_qty;
        public Nullable<decimal> defect_qty
        {
            get
            { return _defect_qty; }

            set
            {
                _defect_qty = value; RaisePropertyChanged("defect_qty");
            }
        }
        private string _comp_code;
        public string comp_code
        {
            get
            { return _comp_code; }

            set
            {
                _comp_code = value; RaisePropertyChanged("comp_code");
            }
        }
        private string _location_Id;
        public string location_Id
        {
            get
            { return _location_Id; }

            set
            {
                _location_Id = value; RaisePropertyChanged("location_Id");
            }
        }
        private string _fin_year;
        public string fin_year
        {
            get
            { return _fin_year; }

            set
            {
                _fin_year = value; RaisePropertyChanged("fin_year");
            }
        }
        private string _posting_period;
        public string posting_period
        {
            get
            { return _posting_period; }

            set
            {
                _posting_period = value; RaisePropertyChanged("posting_period");
            }
        }
        
        private string _lang_key;
        public string lang_key
        {
            get
            { return _lang_key; }

            set
            {
                _lang_key = value; RaisePropertyChanged("lang_key");
            }
        }
        private string _t_status;
        public string t_status
        {
            get
            { return _t_status; }

            set
            {
                _t_status = value; RaisePropertyChanged("t_status");
            }
        }
        private string _remark;
        public string remark
        {
            get
            { return _remark; }

            set
            {
                _remark = value; RaisePropertyChanged("remark");
            }
        }
        
        private string _add_by;
        public string add_by
        {
            get
            { return _add_by; }

            set
            {
                _add_by = value; RaisePropertyChanged("add_by");
            }
        }
        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get
            { return _add_date; }

            set
            {
                _add_date = value; RaisePropertyChanged("add_date");
            }
        }
        private string _editby;
        public string editby
        {
            get
            { return _editby; }

            set
            {
                _editby = value; RaisePropertyChanged("editby");
            }
        }
        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get
            { return _edit_date; }

            set
            {
                _edit_date = value; RaisePropertyChanged("edit_date");
            }
        }
        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get
            { return _active; }

            set
            {
                _active = value; RaisePropertyChanged("active");
            }
        }
        private string _defect_source;
        public string defect_source
        {
            get
            { return _defect_source; }
            set
            {
                _defect_source = value; RaisePropertyChanged("defect_source");
            }
        }
    }
    public class ZCRM_T003_BackFlip
    {
        public string doc_no { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string insp_date { get; set; }
        public string machinecode { get; set; }
        public string shift { get; set; }
        public string EmpName { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string t_display { get; set; }
    }
    public class MultipleContext_ZCRM_T003
    {
        public List<ZCRM_T003_BackFlip> BackFlipEntity { get; set; }
        public List<ZCRM_T003> MasterEntity { get; set; }
        public ObservableCollection<ZCRM_T003_A> DefectEntity { get; set; }
        public List<ZADM_M013_P> MachinMaster { get; set; }
        public List<ADM_M024_P> EmployeeMaster { get; set; }
        public List<EPR_T001_P> ItemDetail { get; set; }
        public List<ECRM_T003_A_P> MachinShift { get; set; }
        public List<ZCRM_T003_Batch> BarcodeDetails { get; set; }
        public List<COM_T003> AttachmentData { get; set; }
        public List<SYS_M013_P> Ref_DocTypeData { get; set; }
        public List<ADM_M042_P> ShiftMaster { get; set; }
        public List<ZADM_M016_P> DefectData { get; set; }
        public List<ENG_T003_P> ParameterData { get; set; }
        public List<SYS_M002> DocTypeInfo { get; set; }
        public List<ZCRM_T003> RescanBarcode { get; set; }
        public ObservableCollection<ZCRM_T003_Batch> SODetails { get; set; }
        public List<ADM_M0013> t_statusList { get; set; }
        public List<ADM_M030_P> GradeList { get; set; }
    }


}
