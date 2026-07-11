using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Reflection.BusinessEntity.CustomerRelation;
using Reflection.BusinessEntity.ADM;

namespace Reflection.BusinessEntity
{
    public class ECRM_T004_A : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int _id { get; set; }
        public int id
        {
            get { return _id; }
            set {
                if (_id != value)
                {
                    _id = value; RaisePropertyChanged("id");
                }
            }
        }
        private string _pdi_no;
        public string pdi_no
        {
            get { return _pdi_no; }
            set {
                if (_pdi_no != value)
                {
                    _pdi_no = value; RaisePropertyChanged("pdi_no");
                }
            }
        }
        private Nullable<System.DateTime> _pdi_date;
        public Nullable<System.DateTime> pdi_date
        {
            get { return _pdi_date; }
            set
            {
                if (_pdi_date != value)
                {
                    _pdi_date = value; RaisePropertyChanged("pdi_date");
                }
            }
        }
        private string _ref_no;
        public string ref_no
        {
            get { return _ref_no; }
            set
            {
                if (_ref_no != value)
                {
                    _ref_no = value; RaisePropertyChanged("ref_no");
                }
            }
        }
        private string _mod_no;
        public string mod_no
        {
            get { return _mod_no; }
            set
            {
                if (_mod_no != value)
                {
                    _mod_no = value; RaisePropertyChanged("mod_no");
                }
            }
        }
        private string _ItemCode;
        public string ItemCode
        {
            get { return _ItemCode; }
            set
            {
                if (_ItemCode != value)
                {
                    _ItemCode = value; RaisePropertyChanged("ItemCode");
                }
            }
        }
        private string _PartyId;
        public string PartyId
        {
            get { return _PartyId; }
            set
            {
                if (_PartyId != value)
                {
                    _PartyId = value; RaisePropertyChanged("PartyId");
                }
            }
        }
        private Nullable<decimal> _qty;
        //[Required(ErrorMessage = "Field 'qty' is required.")]
        //[DisplayName("qty")]
        public Nullable<decimal> qty
        {
            get { return _qty; }
            set
            {
                if (_qty != value)
                {
                    _qty = value; RaisePropertyChanged("qty", ModelEntityUpdated);
                }
            }
        }
        private string _batchno;
        public string batchno
        {
            get { return _batchno; }
            set
            {
                if (_batchno != value)
                {
                    _batchno = value; RaisePropertyChanged("batchno");
                }
            }
        }
        private Nullable<int> _mach_no;
        public Nullable<int> mach_no
        {
            get { return _mach_no; }
            set
            {
                if (_mach_no != value)
                {
                    _mach_no = value; RaisePropertyChanged("mach_no");
                }
            }
        }
        private string _shift;
        //[Required(ErrorMessage = "Field 'Shift' is required.")]
        //[DisplayName("Shift")]
        public string shift
        {
            get { return _shift; }
            set
            {
                if (_shift != value)
                {
                    _shift = value; RaisePropertyChanged("shift");
                }
            }
        }
        private string _Grade;
        //[Required(ErrorMessage = "Field 'Grade' is required.")]
        [DisplayName("Grade")]
        public string Grade
        {
            get { return _Grade; }
            set
            {
                if (_Grade != value)
                {
                    _Grade = value; RaisePropertyChanged("Grade");
                }
            }
        }
        private string _whout_ball;
        public string whout_ball
        {
            get { return _whout_ball; }
            set
            {
                if (_whout_ball != value)
                {
                    _whout_ball = value; RaisePropertyChanged("whout_ball");
                }
            }
        }
        private string _chips;
        public string chips
        {
            get { return _chips; }
            set
            {
                if (_chips != value)
                {
                    _chips = value; RaisePropertyChanged("chips");
                }
            }
        }
        private string _coll_mdg;
        public string coll_mdg
        {
            get { return _coll_mdg; }
            set
            {
                if (_coll_mdg != value)
                {
                    _coll_mdg = value; RaisePropertyChanged("coll_mdg");
                }
            }
        }
        private string _clngqulit;
        public string clngqulit
        {
            get { return _clngqulit; }
            set
            {
                if (_clngqulit != value)
                {
                    _clngqulit = value; RaisePropertyChanged("clngqulit");
                }
            }
        }
        private string _pltqulit;
        public string pltqulit
        {
            get { return _pltqulit; }
            set
            {
                if (_pltqulit != value)
                {
                    _pltqulit = value; RaisePropertyChanged("pltqulit");
                }
            }
        }
        private string _mixing;
        public string mixing
        {
            get { return _mixing; }
            set
            {
                if (_mixing != value)
                {
                    _mixing = value; RaisePropertyChanged("mixing");
                }
            }
        }
        private string _nonwrt;
        public string nonwrt
        {
            get { return _nonwrt; }
            set
            {
                if (_nonwrt != value)
                {
                    _nonwrt = value; RaisePropertyChanged("nonwrt");
                }
            }
        }
        private string _ildchk;
        public string ildchk
        {
            get { return _ildchk; }
            set
            {
                if (_ildchk != value)
                {
                    _ildchk = value; RaisePropertyChanged("ildchk");
                }
            }
        }
        private string _handfil;
        public string handfil
        {
            get { return _handfil; }
            set
            {
                if (_handfil != value)
                {
                    _handfil = value; RaisePropertyChanged("handfil");
                }
            }
        }
        private string _shdia;
        public string shdia
        {
            get { return _shdia; }
            set
            {
                if (_shdia != value)
                {
                    _shdia = value; RaisePropertyChanged("shdia");
                }
            }
        }
        private string _shlen;
        public string shlen
        {
            get { return _shlen; }
            set
            {
                if (_shlen != value)
                {
                    _shlen = value; RaisePropertyChanged("shlen");
                }
            }
        }
        private string _shchmfr;
        public string shchmfr
        {
            get { return _shchmfr; }
            set
            {
                if (_shchmfr != value)
                {
                    _shchmfr = value; RaisePropertyChanged("shchmfr");
                }
            }
        }
        private string _nedledia;
        public string nedledia
        {
            get { return _nedledia; }
            set
            {
                if (_nedledia != value)
                {
                    _nedledia = value; RaisePropertyChanged("nedledia");
                }
            }
        }
        private string _nedlen;
        public string nedlen
        {
            get { return _nedlen; }
            set
            {
                if (_nedlen != value)
                {
                    _nedlen = value; RaisePropertyChanged("nedlen");
                }
            }
        }
        private string _totlen;
        public string totlen
        {
            get { return _totlen; }
            set
            {
                if (_totlen != value)
                {
                    _totlen = value; RaisePropertyChanged("totlen");
                }
            }
        }
        private string _baout;
        public string baout
        {
            get { return _baout; }
            set
            {
                if (_baout != value)
                {
                    _baout = value; RaisePropertyChanged("baout");
                }
            }
        }
        private Nullable<decimal> _ildmin;
        public Nullable<decimal> ildmin
        {
            get { return _ildmin; }
            set
            {
                if (_ildmin != value)
                {
                    _ildmin = value; RaisePropertyChanged("ildmin");
                }
            }
        }
        private Nullable<decimal> _ildmax;
        public Nullable<decimal> ildmax
        {
            get { return _ildmax; }
            set
            {
                if (_ildmax != value)
                {
                    _ildmax = value; RaisePropertyChanged("ildmax");
                }
            }
        }
        private Nullable<decimal> _ildavg;
        //[Required(ErrorMessage = "Field 'ILD Avg' is required.")]
        //[DisplayName("ILD Avg")]
        public Nullable<decimal> ildavg
        {
            get { return _ildavg; }
            set
            {
                if (_ildavg != value)
                {
                    _ildavg = value; RaisePropertyChanged("ildavg");
                }
            }
        }
        private string _ildrang;
        public string ildrang
        {
            get { return _ildrang; }
            set
            {
                if (_ildrang != value)
                {
                    _ildrang = value; RaisePropertyChanged("ildrang");
                }
            }
        }
        private string _set_ild;
        public string set_ild
        {
            get { return _set_ild; }
            set
            {
                if (_set_ild != value)
                {
                    _set_ild = value; RaisePropertyChanged("set_ild");
                }
            }
        }
        private string _set_ink;
        public string set_ink
        {
            get { return _set_ink; }
            set
            {
                if (_set_ink != value)
                {
                    _set_ink = value; RaisePropertyChanged("set_ink");
                }
            }
        }
        private Nullable<System.DateTime> _prodate;
        public Nullable<System.DateTime> prodate
        {
            get { return _prodate; }
            set
            {
                if (_prodate != value)
                {
                    _prodate = value; RaisePropertyChanged("prodate");
                }
            }
        }
        private string _Conv_no;
        //[Required(ErrorMessage = "Field 'Conversion No' is required.")]
        //[DisplayName("Conversion No")]
        public string Conv_no
        {
            get { return _Conv_no; }
            set
            {
                if (_Conv_no != value)
                {
                    _Conv_no = value; RaisePropertyChanged("Conv_no");
                }
            }
        }
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                if (_location_Id != value)
                {
                    _location_Id = value; RaisePropertyChanged("location_Id");
                }
            }
        }
        private string _comp_code;
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
        
        private Nullable<bool> _active;
        public Nullable<bool> active
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
        private string _note;
        public string note
        {
            get { return _note; }
            set
            {
                if (_note != value)
                {
                    _note = value; RaisePropertyChanged("note");
                }
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
                    _add_by = value; RaisePropertyChanged("add_by");
                }
            }
        }
        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date
        {
            get { return _add_date; }
            set
            {
                if (_add_date != value)
                {
                    _add_date = value; RaisePropertyChanged("add_date");
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
                    _editby = value; RaisePropertyChanged("editby");
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
                    _edit_date = value; RaisePropertyChanged("_edit_date");
                }
            }
        }
        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set
            {
                if (_doc_cat != value)
                {
                    _doc_cat = value; RaisePropertyChanged("doc_cat");
                }
            }
        }
        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set
            {
                if (_doc_type != value)
                {
                    _doc_type = value; RaisePropertyChanged("doc_type");
                }
            }
        }
     
        private string _barcode_no;
        public string barcode_no
        {
            get { return _barcode_no; }
            set
            {
                if (_barcode_no != value)
                {
                    _barcode_no = value; RaisePropertyChanged("barcode_no");
                }
            }
        }
        public string XmlDataDocument_ECRM_T004_B { get; set; }

        private string _type1;
        public string type1
        {
            get { return _type1; }
            set
            {
                if (_type1 != value)
                {
                    _type1 = value; RaisePropertyChanged("type1");
                }
            }
        }


        //private string _Machine_Code;
        //[Required(ErrorMessage = "Field 'Machine Code' is required.")]
        //[DisplayName("Machine Code")]
        //public string Machine_Code
        //{
        //    get { return _Machine_Code; }
        //    set { _Machine_Code = value; RaisePropertyChanged("Machine_Code"); }
        //}

        private string _PartyNm;
        public string PartyNm
        {
            get { return _PartyNm; }
            set
            {
                if (_PartyNm != value)
                {
                    _PartyNm = value; RaisePropertyChanged("PartyNm");
                }
            }
        }
        private Nullable<System.DateTime> _Fromdate;
        public Nullable<System.DateTime> Fromdate
        {
            get { return _Fromdate; }
            set
            {
                if (_Fromdate != value)
                {
                    _Fromdate = value;
                    RaisePropertyChanged("Fromdate");
                }
            }
        }
        private Nullable<System.DateTime> _ToDate;
        public Nullable<System.DateTime> ToDate
        {
            get { return _ToDate; }
            set
            {
                if (_ToDate != value)
                {
                    _ToDate = value;
                    RaisePropertyChanged("ToDate");
                }
            }
        }
        private string _customer_codeBack;
        public string customer_codeBack
        {
            get { return _customer_codeBack; }
            set
            {
                if (_customer_codeBack != value)
                {
                    _customer_codeBack = value;
                    RaisePropertyChanged("customer_codeBack");
                }
            }
        }

        private Nullable<int> _customer_idBack;
        public Nullable<int> customer_codeid
        {
            get { return _customer_idBack; }
            set
            {
                if (_customer_idBack != value)
                {
                    _customer_idBack = value;
                    RaisePropertyChanged("customer_codeid");
                }
            }
        }
        private string _machinecode;
        public string machinecode
        {
            get { return _machinecode; }
            set
            {
                if (_machinecode != value)
                {
                    _machinecode = value; RaisePropertyChanged("machinecode");
                }
            }
        }

        private string _ItemName;
        public string ItemName
        {
            get { return _ItemName; }
            set
            {
                if (_ItemName != value)
                {
                    _ItemName = value; RaisePropertyChanged("ItemName");
                }
            }
        }
        private Nullable<decimal> _addition;
        public Nullable<decimal> addition
        {
            get { return _addition; }
            set
            {
                if (_addition != value)
                {
                    _addition = value; RaisePropertyChanged("addition", ModelEntityUpdated);
                }
            }
        }
        private Nullable<decimal> _rej_qty;
        public Nullable<decimal> rej_qty
        {
            get { return _rej_qty; }
            set
            {
                if (_rej_qty != value)
                {
                    _rej_qty = value; RaisePropertyChanged("rej_qty", ModelEntityUpdated);
                }
            }
        }
        private Nullable<decimal> _check_qty;
        public Nullable<decimal> check_qty
        {
            get { return _check_qty; }
            set
            {
                if (_check_qty != value)
                {
                    _check_qty = value; RaisePropertyChanged("check_qty", ModelEntityUpdated);
                }
            }
        }
        private Nullable<decimal> _sample_qty;
        public Nullable<decimal> sample_qty
        {
            get { return _sample_qty; }
            set
            {
                if (_sample_qty != value)
                {
                    _sample_qty = value; RaisePropertyChanged("sample_qty", ModelEntityUpdated);
                }
            }
        }
        private string _operator;
        public string @operator
        {
            get { return _operator; }
            set
            {
                if (_operator != value)
                {
                    _operator = value; RaisePropertyChanged("@operator");
                }
            }
        }
        private Nullable<decimal> _manual_wt;
        public Nullable<decimal> manual_wt
        {
            get { return _manual_wt; }
            set
            {
                if (_manual_wt != value)
                {
                    _manual_wt = value; RaisePropertyChanged("manual_wt");
                }
            }
        }
        private Nullable<decimal> _refil_qty;
        public Nullable<decimal> refil_qty
        {
            get { return _refil_qty; }
            set
            {
                if (_refil_qty != value)
                {
                    _refil_qty = value; RaisePropertyChanged("refil_qty", ModelEntityUpdated);
                }
            }
        }
        private Nullable<decimal> _final_qty;
        public Nullable<decimal> final_qty
        {
            get { return _final_qty; }
            set
            {
                if (_final_qty != value)
                {
                    _final_qty = value; RaisePropertyChanged("final_qty", ModelEntityUpdated);
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
        private string _EmpNm;
        public string EmpNm
        {
            get { return _EmpNm; }
            set
            {
                if (_EmpNm != value)
                {
                    _EmpNm = value;
                    RaisePropertyChanged("EmpNm");
                }
            }
        }

        private decimal? _wt_qty;
        public decimal? wt_qty
        {
            get { return _wt_qty; }
            set
            {
                if (_wt_qty != value)
                {
                    _wt_qty = value;
                    RaisePropertyChanged("wt_qty");
                }
            }
        }

        private string _decision;
        public string decision
        {
            get { return _decision; }
            set
            {
                if (_decision != value)
                {
                    _decision = value;
                    RaisePropertyChanged("decision");
                }
            }
        }

        private string _recomd_grade;
        public string recomd_grade
        {
            get { return _recomd_grade; }
            set
            {
                if (_recomd_grade != value)
                {
                    _recomd_grade = value;
                    RaisePropertyChanged("recomd_grade");
                }
            }
        }

        private string _remark;
        public string remark
        {
            get { return _remark; }
            set
            {
                if (_remark != value)
                {
                    _remark = value;
                    RaisePropertyChanged("remark");
                }
            }
        }

        private string _remark1;
        public string remark1
        {
            get { return _remark1; }
            set
            {
                if (_remark1 != value)
                {
                    _remark1 = value; RaisePropertyChanged("remark");
                }
            }
        }

        private string _remark2;
        public string remark2
        {
            get { return _remark2; }
            set
            {
                if (_remark2 != value)
                {
                    _remark2 = value; RaisePropertyChanged("remark2");
                }
            }
        }

        private string _EmpId1 { get; set; }
        public string EmpId1
        {
            get { return _EmpId1; }
            set
            {
                if (_EmpId1 != value)
                {
                    _EmpId1 = value; RaisePropertyChanged("EmpId1");
                }
            }
        }

        private string _qc_person1 { get; set; }
        public string qc_person1
        {
            get { return _qc_person1; }
            set
            {
                if (_qc_person1 != value)
                {
                    _qc_person1 = value; RaisePropertyChanged("qc_person1");
                }
            }
        }

        private string _sshift { get; set; }
        public string sshift
        {
            get { return _sshift; }
            set
            {
                if (_sshift != value)
                {
                    _sshift = value; RaisePropertyChanged("sshift");
                }
            }
        }

        private string _item { get; set; }
        public string item
        {
            get { return _item; }
            set
            {
                if (_item != value)
                {
                    _item = value; RaisePropertyChanged("item");
                }
            }
        }

        private string _machine { get; set; }
        public string machine
        {
            get { return _machine; }
            set
            {
                if (_machine != value)
                {
                    _machine = value; RaisePropertyChanged("machine");
                }
            }
        }
        private string _con_no { get; set; }
        public string con_no
        {
            get { return _con_no; }
            set
            {
                if (_con_no != value)
                {
                    _con_no = value; RaisePropertyChanged("con_no");
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
        public string XmlDataDocument_ECRM_T004_C { get; set; }
    }
    public class ECRM_T004_B : ObjectBase
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value; RaisePropertyChanged("id");
                }
            }
        }
        private Nullable<int> _pdien_id;
        public Nullable<int> pdien_id
        {
            get { return _pdien_id; }
            set
            {
                if (_pdien_id != value)
                {
                    _pdien_id = value; RaisePropertyChanged("pdien_id");
                }
            }
        }
        private Nullable<int> _modle;
        public Nullable<int> modle
        {
            get { return _modle; }
            set
            {
                if (_modle != value)
                {
                    _modle = value; RaisePropertyChanged("modle");
                }
            }
        }
        private string _shdia;
        public string shdia
        {
            get { return _shdia; }
            set
            {
                if (_shdia != value)
                {
                    _shdia = value; RaisePropertyChanged("shdia");
                }
            }
        }
        private string _shlength;
        public string shlength
        {
            get { return _shlength; }
            set
            {
                if (_shlength != value)
                {
                    _shlength = value; RaisePropertyChanged("shlength");
                }
            }
        }
        private string _neeldia;
        public string neeldia
        {
            get { return _neeldia; }
            set
            {
                if (_neeldia != value)
                {
                    _neeldia = value; RaisePropertyChanged("neeldia");
                }
            }
        }
        private string _neellength;
        public string neellength
        {
            get { return _neellength; }
            set
            {
                if (_neellength != value)
                {
                    _neellength = value; RaisePropertyChanged("neellength");
                }
            }
        }
        private string _totlength;
        public string totlength
        {
            get { return _totlength; }
            set
            {
                if (_totlength != value)
                {
                    _totlength = value; RaisePropertyChanged("totlength");
                }
            }
        }
        private string _ballout;
        public string ballout
        {
            get { return _ballout; }
            set
            {
                if (_ballout != value)
                {
                    _ballout = value; RaisePropertyChanged("ballout");
                }
            }
        }
        private string _p_top;
        public string p_top
        {
            get { return _p_top; }
            set
            {
                if (_p_top != value)
                {
                    _p_top = value; RaisePropertyChanged("p_top");
                }
            }
        }
        private string _rimthik;
        public string rimthik
        {
            get { return _rimthik; }
            set
            {
                if (_rimthik != value)
                {
                    _rimthik = value; RaisePropertyChanged("rimthik");
                }
            }
        }
        private string _spinlength;
        public string spinlength
        {
            get { return _spinlength; }
            set
            {
                if (_spinlength != value)
                {
                    _spinlength = value; RaisePropertyChanged("spinlength");
                }
            }
        }
        private string _spinangle;
        public string spinangle
        {
            get { return _spinangle; }
            set
            {
                if (_spinangle != value)
                {
                    _spinangle = value; RaisePropertyChanged("spinangle");
                }
            }
        }
        private string _centdrill;
        public string centdrill
        {
            get { return _centdrill; }
            set
            {
                if (_centdrill != value)
                {
                    _centdrill = value; RaisePropertyChanged("centdrill");
                }
            }
        }
        private string _shchmfar;
        public string shchmfar
        {
            get { return _shchmfar; }
            set
            {
                if (_shchmfar != value)
                {
                    _shchmfar = value; RaisePropertyChanged("shchmfar");
                }
            }
        }

        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                if (_location_Id != value)
                {
                    _location_Id = value; RaisePropertyChanged("location_Id");
                }
            }
        }
        private string _comp_code;
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
        private Nullable<bool> _active;
        public Nullable<bool> active
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
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set
            {
                if (_add_by != value)
                {
                    _add_by = value; RaisePropertyChanged("add_by");
                }
            }
        }
        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date
        {
            get { return _add_date; }
            set
            {
                if (_add_date != value)
                {
                    _add_date = value; RaisePropertyChanged("add_date");
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
                    _editby = value; RaisePropertyChanged("editby");
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
                    _edit_date = value; RaisePropertyChanged("edit_date");
                }
            }
        }
        private string _pdi_no;
        public string pdi_no
        {
            get { return _pdi_no; }
            set
            {
                if (_pdi_no != value)
                {
                    _pdi_no = value; RaisePropertyChanged("pdi_no");
                }
            }
        }
    }
    public class ECRM_T004_C : ObjectBase
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value; RaisePropertyChanged("id");
                }
            }
        }

        private string _pdi_no;
        public string pdi_no
        {
            get { return _pdi_no; }
            set
            {
                if (_pdi_no != value)
                {
                    _pdi_no = value; RaisePropertyChanged("pdi_no");
                }
            }
        }

        private string _defect;
        public string defect
        {
            get { return _defect; }
            set
            {
                if (_defect != value)
                {
                    _defect = value; RaisePropertyChanged("defect");
                }
            }
        }

        private string _defectNm;
        public string defectNm
        {
            get { return _defectNm; }
            set
            {
                if (_defectNm != value)
                {
                    _defectNm = value; RaisePropertyChanged("defectNm");
                }
            }
        }

        private string _ParameterNm;
        public String ParameterNm
        {
            get { return _ParameterNm; }
            set
            {
                if (_ParameterNm != value)
                {
                    _ParameterNm = value; RaisePropertyChanged("ParameterNm");
                }
            }
        }

        private string _parameters;
        public string parameters
        {
            get { return _parameters; }
            set
            {
                if (_parameters != value)
                {
                    _parameters = value; RaisePropertyChanged("parameters");
                }
            }
        }

        private string _observation;
        public string observation
        {
            get { return _observation; }
            set
            {
                if (_observation != value)
                {
                    _observation = value; RaisePropertyChanged("observation");
                }
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
                    _add_by = value; RaisePropertyChanged("add_by");
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
                    _add_date = value; RaisePropertyChanged("add_date");
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
                    _editby = value; RaisePropertyChanged("editby");
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
                    _edit_date = value; RaisePropertyChanged("edit_date");
                }
            }
        }
        
        private string _t_status;
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

        private Nullable<bool> _active;
        public Nullable<bool> active
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

        private string _comp_code;
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

        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                if (_location_Id != value)
                {
                    _location_Id = value; RaisePropertyChanged("location_Id");
                }
            }
        }

        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                if (_lang_key != value)
                {
                    _lang_key = value; RaisePropertyChanged("lang_key");
                }
            }
        }

        

        private decimal? _defect_qty;
        public decimal? defect_qty
        {
            get { return _defect_qty; }
            set {
                if (_defect_qty != value)
                {
                    _defect_qty = value; RaisePropertyChanged("defect_qty");
                }
            }
        }

       
    }

    public class PDIRpt_ECRM_T004_A : ObjectBase
    {
        public int id { get; set; }
        public string pdi_no { get; set; }
        public Nullable<System.DateTime> pdi_date { get; set; }
        public string ref_no { get; set; }
        public string mod_no { get; set; }
        public string ItemCode { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public Nullable<decimal> qty { get; set; }
        public string batchno { get; set; }
        public Nullable<int> mach_no { get; set; }
        public string shift { get; set; }
        public string Grade { get; set; }
        public string whout_ball { get; set; }
        public string chips { get; set; }
        public string coll_mdg { get; set; }
        public string clngqulit { get; set; }
        public string pltqulit { get; set; }
        public string mixing { get; set; }
        public string nonwrt { get; set; }
        public string ildchk { get; set; }
        public string handfil { get; set; }
        public string shdia { get; set; }
        public string shlen { get; set; }
        public string shchmfr { get; set; }
        public string nedledia { get; set; }
        public string nedlen { get; set; }
        public string totlen { get; set; }
        public string baout { get; set; }
        public Nullable<decimal> ildmin { get; set; }
        public Nullable<decimal> ildmax { get; set; }
        public Nullable<decimal> ildavg { get; set; }
        public string ildrang { get; set; }
        public string set_ild { get; set; }
        public string set_ink { get; set; }
        public Nullable<System.DateTime> prodate { get; set; }
        public string Conv_no { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string note { get; set; }


        public string MachineCode { get; set; }
        public string LoctnNm { get; set; }


        public int Comp_Id { get; set; }
        public string CompName { get; set; }
        public string Add1 { get; set; }
        public string Add2 { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string PhOffi { get; set; }
        public string FaxNo { get; set; }
        public string MailId { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string BallSize { get; set; }
        public string TipType { get; set; }

    }

    public class MultipleContext_ECRM_T004_A
    {
        public List<ECRM_T004_A> PDIEntry { get; set; }                          //PDI Entry    
        public List<EPR_T001_PopUp> ILDChart { get; set; }                       //ILDChart Master      
        public List<ZADM_M013_PopUp> Machine { get; set; }                       //Machine Master    
      
        public List<ECR_T004_PopUp_Lot> ConvLot { get; set; }  //Conv Lot From ILDChart  
        public ObservableCollection<ECRM_T004_B> PDIEntryDetails { get; set; }                   //PDI Entry Details
        public ObservableCollection<PDIRpt_ECRM_T004_A> PdiRpt { get; set; }                        // PDI Entry Report 
        public ObservableCollection<ADM_M028_PopUp> CustomerForBack { get; set; }
        public List<ECR_T004_PopUp_Lot> ShiftLot { get; set; }
        public List<ADM_M024_P> EmpList { get; set; }
        public List<SEL_T001_PDIQualityInstRpt> PDI_QualityInst { get; set; }

        // public List<ADM_M042_P> ShiftMaster { get; set; }
        public List<ECRM_T003_A> BatchDetails { get; set; }
        public List<ECRM_T003_A> WritingTestPopup { get; set; }
    }

    public class MultipleContext_ECRM_T004_A_New
    {
        public List<ADM_M028_P> PartyMaster { get; set; } // Load Party Data
        public List<ADM_M042_P> ShiftMaster { get; set; } // Load Shift Data
        public List<ADM_M024_P> OperatorData { get; set; } //Load Operator Data
        public List<ECRM_T003_P> BarcodeDetails { get; set; }// Load Barcode Data
        public List<TransHistory> TransactionHistory { get; set; }
        public List<ECRM_T004_Aflip> DocumentDataFlipGrid { get; set; }
        public List<ECRM_T004_A> MasterEntity { get; set; }
        public ObservableCollection<ECRM_T004_C> DefectEntity { get; set; }
        public List<COM_T003> AttachmentData { get; set; } // Load Attachment Data
        public List<ZADM_M016_P> DefectMaster { get; set; } //Load Defect Data
        public List<ENG_T003_P> ParameterMaster { get; set; } //Load ParameterData
        public List<ECRM_T004_A> RescanBarcode { get; set; }
        public ObservableCollection<ECRM_T003_P> SODetails { get; set; }
        public List<ADM_M0013> t_statusList { get; set; }
        public List<ADM_M030_P> GradeList { get; set; }

    }
}
