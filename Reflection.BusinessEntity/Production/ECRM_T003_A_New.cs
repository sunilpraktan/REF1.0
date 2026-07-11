using Reflection.BusinessEntity.ADM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Reflection.BusinessEntity
{
    public class ECRM_T003_A_New : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }
        private string _readonlly;
        public string readonlly
        {
            get { return _readonlly; }
            set
            {
                _readonlly = value;
                RaisePropertyChanged("readonlly");
            }
        }
        private Nullable<int> _mchn_id;
        [Required(ErrorMessage = "Field 'Machine no' is required.")]
        [DisplayName("Machine no")]
        public Nullable<int> mchn_id
        {
            get { return _mchn_id; }
            set
            {
                _mchn_id = value;
                RaisePropertyChanged("mchn_id", ModelEntityUpdated);
            }
        }
        private string _lotno;
        public string lotno
        {
            get { return _lotno; }
            set
            {
                _lotno = value;
                RaisePropertyChanged("lotno");
            }
        }
        private Nullable<System.DateTime> _prddt;
        public Nullable<System.DateTime> prddt
        {
            get { return _prddt; }
            set
            {
                _prddt = value;
                RaisePropertyChanged("prddt");
            }
        }
        private string _wtno;
        public string wtno
        {
            get { return _wtno; }
            set
            {
                _wtno = value;
                RaisePropertyChanged("wtno");
            }
        }
        private Nullable<System.DateTime> _wtdt;
        public Nullable<System.DateTime> wtdt
        {
            get { return _wtdt; }
            set
            {
                _wtdt = value;
                RaisePropertyChanged("wtdt");
            }
        }
        private string _tiptp;
        public string tiptp
        {
            get { return _tiptp; }
            set
            {
                _tiptp = value;
                RaisePropertyChanged("tiptp");
            }
        }
        private string _modlno;
        public string modlno
        {
            get { return _modlno; }
            set
            {
                _modlno = value;
                RaisePropertyChanged("modlno");
            }
        }
        private string _ink;
        public string ink
        {
            get { return _ink; }
            set
            {
                _ink = value;
                RaisePropertyChanged("ink");
            }
        }
        private string _prdct_code;
        public string prdct_code
        {
            get { return _prdct_code; }
            set
            {
                _prdct_code = value;
                RaisePropertyChanged("prdct_code");
            }
        }
        private string _timefr;
        public string timefr
        {
            get { return _timefr; }
            set
            {
                _timefr = value;
                RaisePropertyChanged("timefr");
            }
        }
        private string _timeto;
        public string timeto
        {
            get { return _timeto; }
            set
            {
                _timeto = value;
                RaisePropertyChanged("timeto");
            }
        }
        private string _tmp;
        [Required(ErrorMessage = "Field 'Tempature' is required.")]
        [DisplayName("Tempature")]
        public string tmp
        {
            get { return _tmp; }
            set
            {
                _tmp = value;
                RaisePropertyChanged("tmp", ModelEntityUpdated);
            }
        }
        private string _humdt;
        [Required(ErrorMessage = "Field 'Humidity' is required.")]
        [DisplayName("Humidity")]
        public string humdt
        {
            get { return _humdt; }
            set
            {
                _humdt = value;
                RaisePropertyChanged("humdt", ModelEntityUpdated);
            }
        }
        private string _shift;
        public string shift
        {
            get { return _shift; }
            set
            {
                _shift = value;
                RaisePropertyChanged("shift");
            }
        }
        private Nullable<int> _tm;
        public Nullable<int> tm
        {
            get { return _tm; }
            set
            {
                _tm = value;
                RaisePropertyChanged("tm", ModelEntityUpdated);
            }
        }
        private string _remusr;
        public string remusr
        {
            get { return _remusr; }
            set
            {
                _remusr = value;
                RaisePropertyChanged("remusr");
            }
        }
        private Nullable<decimal> _tmnild;
        public Nullable<decimal> tmnild
        {
            get { return _tmnild; }
            set
            {
                _tmnild = value;
                RaisePropertyChanged("tmnild", ModelEntityUpdated);
            }
        }
        private Nullable<decimal> _tmxild;
        public Nullable<decimal> tmxild
        {
            get { return _tmxild; }
            set
            {
                _tmxild = value;
                RaisePropertyChanged("tmxild", ModelEntityUpdated);
            }
        }
        private Nullable<decimal> _tavild;
        public Nullable<decimal> tavild
        {
            get { return _tavild; }
            set
            {
                _tavild = value;
                RaisePropertyChanged("tavild", ModelEntityUpdated);
            }
        }
        private Nullable<decimal> _tavgoo;
        public Nullable<decimal> tavgoo
        {
            get { return _tavgoo; }
            set
            {
                _tavgoo = value;
                RaisePropertyChanged("tavgoo", ModelEntityUpdated);
            }
        }
        private Nullable<decimal> _amnild;
        public Nullable<decimal> amnild
        {
            get { return _amnild; }
            set
            {
                _amnild = value;
                RaisePropertyChanged("amnild", ModelEntityUpdated);
            }
        }

        private Nullable<decimal> _amxild;
        public Nullable<decimal> amxild
        {
            get { return _amxild; }
            set
            {
                _amxild = value;
                RaisePropertyChanged("amxild", ModelEntityUpdated);
            }
        }
        private Nullable<decimal> _aavild;
        public Nullable<decimal> aavild
        {
            get { return _aavild; }
            set
            {
                _aavild = value;
                RaisePropertyChanged("aavild", ModelEntityUpdated);
            }
        }
        private Nullable<decimal> _aavgoo;
        public Nullable<decimal> aavgoo
        {
            get { return _aavgoo; }
            set
            {
                _aavgoo = value;
                RaisePropertyChanged("aavgoo", ModelEntityUpdated);
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
        private string _machinecode;
        public string machinecode
        {
            get { return _machinecode; }
            set
            {
                _machinecode = value;
                RaisePropertyChanged("machinecode");
            }
        }
        private string _Conv_lot;
        //[Required(ErrorMessage = "Field 'Conversion Lot' is required.")]
        //[DisplayName("Conversion Lot")]
        public string Conv_lot
        {
            get { return _Conv_lot; }
            set
            {
                _Conv_lot = value;
                RaisePropertyChanged("Conv_lot", ModelEntityUpdated);
            }
        }
        private decimal? _Ranget;
        public decimal? Ranget
        {
            get { return _Ranget; }
            set
            {
                _Ranget = value;
                RaisePropertyChanged("Ranget", ModelEntityUpdated);
            }
        }
        private decimal _Rangea;
        public decimal Rangea
        {
            get { return _Rangea; }
            set
            {
                _Rangea = value;
                RaisePropertyChanged("Rangea", ModelEntityUpdated);
            }
        }
        private string _obrem;
        public string obrem
        {
            get { return _obrem; }
            set
            {
                _obrem = value;
                RaisePropertyChanged("obrem");
            }
        }
        private string _uhdec;
        public string uhdec
        {
            get { return _uhdec; }
            set
            {
                _uhdec = value;
                RaisePropertyChanged("uhdec");
            }
        }
        private string _uhrem;
        public string uhrem
        {
            get { return _uhrem; }
            set
            {
                _uhrem = value;
                RaisePropertyChanged("uhrem");
            }
        }
        private Nullable<System.DateTime> _Fromdate;
        public Nullable<System.DateTime> Fromdate
        {
            get { return _Fromdate; }
            set
            {
                _Fromdate = value;
                RaisePropertyChanged("Fromdate");
            }
        }
        private Nullable<System.DateTime> _ToDate;
        public Nullable<System.DateTime> ToDate
        {
            get { return _ToDate; }
            set
            {
                _ToDate = value;
                RaisePropertyChanged("ToDate");
            }
        }
        private string _prdct_codeBack;
        public string prdct_codeBack
        {
            get { return _prdct_codeBack; }
            set
            {
                _prdct_codeBack = value;
                RaisePropertyChanged("prdct_codeBack");
            }
        }
        private string _itemname;
        public string itemname
        {
            get { return _itemname; }
            set
            {
                _itemname = value;
                RaisePropertyChanged("itemname");
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
        private Nullable<decimal> _check_qty;
        public Nullable<decimal> check_qty
        {
            get { return _check_qty; }
            set
            {
                _check_qty = value;
                RaisePropertyChanged("check_qty", ModelEntityUpdated);
            }
        }
        private Nullable<decimal> _counter_qty;
        public Nullable<decimal> counter_qty
        {
            get { return _counter_qty; }
            set
            {
                _counter_qty = value;
                RaisePropertyChanged("counter_qty", ModelEntityUpdated);
            }
        }
        private string _test_code;
        public string test_code
        {
            get { return _test_code; }
            set
            {
                _test_code = value;
                RaisePropertyChanged("test_code");
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

        private string _fin_year;
        public string fin_year
        {
            get { return _fin_year; }
            set
            {
                _fin_year = value;
                RaisePropertyChanged("fin_year");
            }
        }

        private string _posting_period;
        public string posting_period
        {
            get { return _posting_period; }
            set
            {
                _posting_period = value;
                RaisePropertyChanged("posting_period");
            }
        }
        
        private string _language;
        public string language
        {
            get { return _language; }
            set
            {
                _language = value;
                RaisePropertyChanged("language");
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

        public string _PartyId;
        public string PartyId
        {
            get { return _PartyId; }
            set
            {
                _PartyId = value;
                RaisePropertyChanged("PartyId");
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

        private string _sa_no;
        public string sa_no
        {
            get { return _sa_no; }
            set
            {
                _sa_no = value;
                RaisePropertyChanged("sa_no");
            }
        }

        private string _ball_make;
        public string ball_make
        {
            get { return _ball_make; }
            set
            {
                _ball_make = value;
                RaisePropertyChanged("ball_make");
            }
        }

        private string _wire_make;
        public string wire_make
        {
            get { return _wire_make; }
            set
            {
                _wire_make = value;
                RaisePropertyChanged("wire_make");
            }
        }

        private Nullable<decimal> _wire_size;
        public Nullable<decimal> wire_size
        {
            get { return _wire_size; }
            set
            {
                _wire_size = value;
                RaisePropertyChanged("wire_size");
            }
        }

        private string _ball_size;
        public string ball_size
        {
            get { return _ball_size; }
            set
            {
                _ball_size = value;
                RaisePropertyChanged("ball_size");
            }
        }

        public Nullable<decimal> _line_width;
        public Nullable<decimal> line_width
        {
            get { return _line_width; }
            set
            {
                _line_width = value;
                RaisePropertyChanged("line_width");
            }
        }

        private string _wt_machine;
        public string wt_machine
        {
            get { return _wt_machine; }
            set
            {
                _wt_machine = value;
                RaisePropertyChanged("wt_machine");
            }
        }

        private Nullable<decimal> _pages;
        public Nullable<decimal> pages
        {
            get { return _pages; }
            set
            {
                _pages = value;
                RaisePropertyChanged("pages");
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

        private string _sheet_cond;
        public string sheet_cond
        {
            get { return _sheet_cond; }
            set
            {
                _sheet_cond = value;
                RaisePropertyChanged("sheet_cond");
            }
        }

        private Nullable<decimal> _writing_angle;
        public Nullable<decimal> writing_angle
        {
            get { return _writing_angle; }
            set
            {
                _writing_angle = value;
                RaisePropertyChanged("writing_angle");
            }
        }

        private Nullable<decimal> _paper_feed;
        public Nullable<decimal> paper_feed
        {
            get { return _paper_feed; }
            set
            {
                _paper_feed = value;
                RaisePropertyChanged("paper_feed");
            }
        }

        private Nullable<decimal>_writing_speed;
        public Nullable<decimal> writing_speed
        {
            get { return _writing_speed; }
            set
            {
                _writing_speed = value;
                RaisePropertyChanged("writing_speed");
            }
        }

        private Nullable<decimal> _Pt_load;
        public Nullable<decimal> Pt_load
        {
            get { return _Pt_load; }
            set
            {
                _Pt_load = value;
                RaisePropertyChanged("Pt_load");
            }
        }

        private Nullable<int> _pices_count;
        public Nullable<int> pices_count
        {
            get { return _pices_count; }
            set
            {
                _pices_count = value;
                RaisePropertyChanged("pices_count");
            }
        }

        public string _position;
        public string position
        {
            get { return _position; }
            set
            {
                _position = value;
                RaisePropertyChanged("position");
            }
        }

        private string _period;
        public string period
        {
            get { return _period; }
            set
            {
                _period = value;
                RaisePropertyChanged("period");
            }
        }

        private string _PartyNm;
        public string PartyNm
        {
            get { return _PartyNm; }
            set
            {
                _PartyNm = value;
                RaisePropertyChanged("PartyNm");
            }
        }

        private string _Ref_doc_type;
        public string Ref_doc_type
        {
            get { return _Ref_doc_type; }
            set
            {
                _Ref_doc_type = value;
                RaisePropertyChanged("Ref_doc_type");
            }
        }

        private string _ref_doctp;
        public string ref_doctp
        {
            get { return _ref_doctp; }
            set
            {
                _ref_doctp = value;
                RaisePropertyChanged("ref_doctp");
            }
        }

        private string _RefDocNo;
        public string RefDocNo
        {
            get { return _RefDocNo; }
            set
            {
                _RefDocNo = value;
                RaisePropertyChanged("RefDocNo");
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

        private decimal? _batch_qty;
        public decimal? batch_qty
        {
            get { return _batch_qty; }
            set { _batch_qty = value;RaisePropertyChanged("batch_qty", ModelEntityUpdated); }
        }

        private string _qc_person1;
        public string qc_person1
        {
            get { return _qc_person1; }
            set { _qc_person1 = value; RaisePropertyChanged("batch_qty"); }
        }

        private string _sshift;
        public string sshift
        {
            get { return _sshift; }
            set { _sshift = value; RaisePropertyChanged("sshift"); }
        }

        private string _item;
        public string item
        {
            get { return _item; }
            set { _item = value; RaisePropertyChanged("item"); }
        }

        private string _machine;
        public string machine
        {
            get { return _machine; }
            set { _machine = value; RaisePropertyChanged("machine"); }
        }

        private string _con_no;
        public string con_no
        {
            get { return _con_no; }
            set { _con_no = value;RaisePropertyChanged("con_no");}
        }

        private Nullable<decimal> _sample_qty;
        public Nullable<decimal> sample_qty
        {
            get { return _sample_qty; }
            set { _sample_qty = value; RaisePropertyChanged("sample_qty"); }
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
        private string _wc_code;
        public string wc_code
        {
            get { return _wc_code; }
            set
            {
                if (_wc_code != value)
                {
                    _wc_code = value; RaisePropertyChanged("wc_code");
                }
            }
        }
        private string _grade;
        public string grade
        {
            get { return _grade; }
            set
            {
                if (_grade != value)
                {
                    _grade = value; RaisePropertyChanged("grade");
                }
            }
        }
        private string _counter_remark;
        public string counter_remark
        {
            get { return _counter_remark; }
            set
            {
                if (_counter_remark != value)
                {
                    _counter_remark = value; RaisePropertyChanged("counter_remark");
                }
            }
        }
        public string XmlDataDocument_FlipGrid { get; set; }
        public string XmlDataDocument_ECRM_T003_B { get; set; }
        public string XmlDataDocument_ECRM_T003_D { get; set; }
    }
    public class ECRM_T003_B_New : ObjectBase
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
        private Nullable<int> _wtid;
        public Nullable<int> wtid
        {
            get { return _wtid; }
            set
            {
                _wtid = value;
                RaisePropertyChanged("wtid");
            }
        }

        private string _refilno;
        public string refilno
        {
            get { return _refilno; }
            set
            {
                _refilno = value;
                RaisePropertyChanged("refilno", ModelEntityUpdated);
            }
        }
        private decimal _wbtsta;
        public decimal wbtsta
        {
            get { return _wbtsta; }
            set
            {
                _wbtsta = value;
                RaisePropertyChanged("wbtsta", ModelEntityUpdated);
            }
        }
        private decimal _watstb;
        public decimal watstb
        {
            get { return _watstb; }
            set
            {
                _watstb = value;
                RaisePropertyChanged("watstb", ModelEntityUpdated);
            }
        }
        private decimal _waclgc;
        public decimal waclgc
        {
            get { return _waclgc; }
            set
            {
                _waclgc = value;
                RaisePropertyChanged("waclgc", ModelEntityUpdated);
            }
        }
        private decimal _ild;
        public decimal ild
        {
            get { return _ild; }
            set
            {
                _ild = value;
                RaisePropertyChanged("ild", ModelEntityUpdated);
            }
        }
        private decimal _gooping;
        public decimal gooping
        {
            get { return _gooping; }
            set
            {
                _gooping = value;
                RaisePropertyChanged("gooping", ModelEntityUpdated);
            }
        }
        private string _defects;
        public string defects
        {
            get { return _defects; }
            set
            {
                _defects = value;
                RaisePropertyChanged("defects");
            }
        }
        private string _remusr;
        public string remusr
        {
            get { return _remusr; }
            set
            {
                _remusr = value;
                RaisePropertyChanged("remusr");
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
        private string _wtno;
        public string Wtno
        {
            get { return _wtno; }
            set { _wtno = value; }
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

        private string _fin_year;
        public string fin_year
        {
            get { return _fin_year; }
            set
            {
                _fin_year = value;
                RaisePropertyChanged("fin_year");
            }
        }

        private string _posting_period;
        public string posting_period
        {
            get { return _posting_period; }
            set
            {
                _posting_period = value;
                RaisePropertyChanged("posting_period");
            }
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

        private Nullable<decimal> _tot_life;
        public Nullable<decimal> tot_life
        {
            get { return _tot_life; }
            set
            {
                _tot_life = value;
                RaisePropertyChanged("tot_life");
            }
        }

        private string _skping;
        public string skping
        {
            get { return _skping; }
            set
            {
                _skping = value;
                RaisePropertyChanged("skping");
            }
        }

        private string _deeplight;
        public string deeplight
        {
            get { return _deeplight; }
            set
            {
                _deeplight = value;
                RaisePropertyChanged("deeplight");
            }
        }

        private string _DefectNm;
        public string DefectNm
        {
            get { return _DefectNm; }
            set
            {
                _DefectNm = value;
                RaisePropertyChanged("DefectNm");
            }
        }   
    }

    public class ECRM_T003_D_New: ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };


        private string _DefectNm;
        public string DefectNm
        {
            get { return _DefectNm; }
            set
            {
                _DefectNm = value;
                RaisePropertyChanged("DefectNm");
            }
        }

        private string _parameterNm;
        public string parameterNm
        {
            get { return _parameterNm; }
            set
            {
                _parameterNm = value;
                RaisePropertyChanged("parameterNm");
            }
        }

        private decimal? _defect_qty;
        public decimal? defect_qty
        {
            get { return _defect_qty; }
            set
            {
                _defect_qty = value;
                RaisePropertyChanged("defect_qty");
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

        private string _wtno;
        public string wtno
        {
            get { return _wtno; }
            set
            {
                _wtno = value;
                RaisePropertyChanged("wtno");
            }
        }

        private string _defect;
        public string defect
        {
            get { return _defect; }
            set
            {
                _defect = value;
                RaisePropertyChanged("defect");
            }
        }

        private string _parameters;
        public string parameters
        {
            get { return _parameters; }
            set
            {
                _parameters = value;
                RaisePropertyChanged("parameters");
            }
        }

        private string _observation;
        public string observation
        {
            get { return _observation; }
            set
            {
                _observation = value;
                RaisePropertyChanged("observation");
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

        private string _fin_year;
        public string fin_year
        {
            get { return _fin_year; }
            set
            {
                _fin_year = value;
                RaisePropertyChanged("fin_year");
            }
        }

        private string _posting_period;
        public string posting_period
        {
            get { return _posting_period; }
            set
            {
                _posting_period = value;
                RaisePropertyChanged("posting_period");
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

        private int? _refillno;
        public int? refillno
        {
            get { return _refillno; }
            set
            {
                _refillno = value;
                RaisePropertyChanged("refillno");
            }
        }



    }
    public class MultipleContext_ECRM_T003
    {
        public List<ECRM_T003_AFlip> DocumentDataFlipGrid { get; set; }// BF data
        public List<ZADM_M013_P> MachineCodeList { get; set; }//Machine details 
        public List<ADM_M022_P_ESSEM> ItemList { get; set; }//Item Master  
        public List<ZADM_M007_P> ILD { get; set; }//ILD Master
        public List<ZADM_M009_P> Models { get; set; }//Model Master
        public List<ZADM_M006_P> INK { get; set; }//Ink Master 
        public List<ZADM_M016_P> DefectList { get; set; }// Defect Master
        public List<ADM_M042_P> Shift { get; set; }// Shift Master           
        public List<ADM_M024_P> EmpList { get; set; } // Employee Master
        public List<ECRM_T003_C_P> TestType { get; set; } // Test TYpe master
        public List<PPC_T003_Batch> BatchDetails { get; set; }// Batch Details
        public List<ECRM_T003_A_New> MasterEntity { get; set; }// Master data
        public ObservableCollection<ECRM_T003_B_New> ItemEntity { get; set; }  // Load Item Data
        public List<ADM_M028_P> PartyMaster { get; set; }// Load Party Data
        public ObservableCollection<ECRM_T003_D_New> DefectEntity { get; set; }
        public List<ENG_T003_P> ParameterMaster { get; set; } // Load Parameter Data 
        public List<SEL_T001_P> SalesOrderData { get; set; } //sales order data
        public List<ECRM_T001_A_P> SampleData { get; set; } //Load Sample Analysis Data
        public List<ZADM_M013_P> WTMachineData { get; set; } // Load Writing Test Machine Data
        public List<ADM_M022_P> ItemData { get; set; } // Load  Items(papers) Data 
        public List<SYS_M013_P> RefDocType { get; set; } // Load Ref Doc Type Data
        public List<COM_T003> AttachmentData { get; set; } //Load Attachment Data
        public List<ZADM_M007_P> TipTypeData { get; set; } // Load Tip type Data
        public List<ADM_M032_P> BallMakeData { get; set; } // Load Ball make Data
        public List<ZADM_M001_P> BallSizeData { get; set; } // Load Ball Size Data
        public List<ZADM_M003_P> WireSizeData { get; set; } // Load Wire Size Data
        public List<ZADM_M006_P> InkMaster { get; set; } //Load Ink Master
        public List<SYS_M013_P> DocTypeData { get; set; } // Load Doc Type Data
        public List<ADM_M032_P1> WireMakeData { get; set; }// Load Wire Make Data
        public List<SYS_M002> DocTypeInfo { get; set; }
        public List<ADM_M038_B_P> UnitMaster { get; set; }
        public List<ECRM_T003_A_New> RescanBarcode { get; set; }
        public ObservableCollection<PPC_T003_Batch> SODetails { get; set; }
        public List<ADM_M0013> t_statusList { get; set; }
        public List<ADM_M030_P> GradeList { get; set; }

    }
}
