using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity
{
    public class ECRM_T003_A : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        
        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    RaisePropertyChanged("id");
                }
            }
        }
        private string _readonlly;
        public string readonlly
        {
            get { return _readonlly; }
            set
            {
                if (_readonlly != value)
                {
                    _readonlly = value;
                    RaisePropertyChanged("readonlly");

                }
            }
        }
        private Nullable<int> _mchn_id;
        //[Required(ErrorMessage = "Field 'Machine no' is required.")]
        //[DisplayName("Machine no")]
        public Nullable<int> mchn_id
        {
            get { return _mchn_id; }
            set
            {
                if (_mchn_id != value)
                {
                    _mchn_id = value;
                    RaisePropertyChanged("mchn_id", ModelEntityUpdated);
                }
            }
        }
        private string _lotno;        
        public string lotno
        {
            get { return _lotno; }
            set
            {
                if (_lotno != value)
                {
                    _lotno = value;
                    RaisePropertyChanged("lotno");
                }
            }
        }
        private Nullable<System.DateTime> _prddt;
        public Nullable<System.DateTime> prddt
        {
            get { return _prddt; }
            set
            {
                if (_prddt != value)
                {
                    _prddt = value;
                    RaisePropertyChanged("prddt");
                }
            }
        }
        private string _wtno;
        public string wtno
        {
            get { return _wtno; }
            set
            {
                if (_wtno != value)
                {
                    _wtno = value;
                    RaisePropertyChanged("wtno");
                }
            }
        }
        private Nullable<System.DateTime> _wtdt;
        public Nullable<System.DateTime> wtdt
        {
            get { return _wtdt; }
            set
            {
                if (_wtdt != value)
                {
                    _wtdt = value;
                    RaisePropertyChanged("wtdt");
                }
            }
        }
        private string _tiptp;
        public string tiptp
        {
            get { return _tiptp; }
            set
            {
                if (_tiptp != value)
                {
                    _tiptp = value;
                    RaisePropertyChanged("tiptp");
                }
            }
        }
        private string _modlno;
        public string modlno
        {
            get { return _modlno; }
            set
            {
                if (_modlno != value)
                {
                    _modlno = value;
                    RaisePropertyChanged("modlno");
                }
            }
        }
        private string _ink;
        public string ink
        {
            get { return _ink; }
            set
            {
                if (_ink != value)
                {
                    _ink = value;
                    RaisePropertyChanged("ink");
                }
            }
        }
        private string _prdct_code;
        public string prdct_code
        {
            get { return _prdct_code; }
            set
            {
                if (_prdct_code != value)
                {
                    _prdct_code = value;
                    RaisePropertyChanged("prdct_code");
                }
            }
        }
        private string _timefr;
        public string timefr
        {
            get { return _timefr; }
            set
            {
                if (_timefr != value)
                {
                    _timefr = value;
                    RaisePropertyChanged("timefr");
                }
            }
        }
        private string _timeto;
        public string timeto
        {
            get { return _timeto; }
            set
            {
                if (_timeto != value)
                {
                    _timeto = value;
                    RaisePropertyChanged("timeto");
                }
            }
        }
        private string _tmp;
        //[Required(ErrorMessage = "Field 'Tempature' is required.")]
        //[DisplayName("Tempature")]
        public string tmp
        {
            get { return _tmp; }
            set
            {
                if (_tmp != value)
                {
                    _tmp = value;
                    RaisePropertyChanged("tmp", ModelEntityUpdated);
                }
            }
        }
        private string _humdt;
        //[Required(ErrorMessage = "Field 'Humidity' is required.")]
        //[DisplayName("Humidity")]
        public string humdt
        {
            get { return _humdt; }
            set
            {
                if (_humdt != value)
                {

                    _humdt = value;
                    RaisePropertyChanged("humdt", ModelEntityUpdated);
                }
            }
        }
        private string _shift;
        public string shift
        {
            get { return _shift; }
            set
            {
                if (_shift != value)
                {
                    _shift = value;
                    RaisePropertyChanged("shift");
                }
            }
        }
        private Nullable<int> _tm;
        public Nullable<int> tm
        {
            get { return _tm; }
            set
            {
                if (_tm != value)
                {
                    _tm = value;
                    RaisePropertyChanged("tm");
                }
            }
        }
        private string _remusr;
        public string remusr
        {
            get { return _remusr; }
            set
            {
                if (_remusr != value)
                {
                    _remusr = value;
                    RaisePropertyChanged("remusr");
                }
            }
        }
        private Nullable<decimal> _tmnild;
        public Nullable<decimal> tmnild
        {
            get { return _tmnild; }
            set
            {
                if (_tmnild != value)
                {
                    _tmnild = value;
                    RaisePropertyChanged("tmnild");
                }
            }
        }
        private Nullable<decimal> _tmxild;
        public Nullable<decimal> tmxild
        {
            get { return _tmxild; }
            set
            {
                if (_tmxild != value)
                {
                    _tmxild = value;
                    RaisePropertyChanged("tmxild");
                }
            }
        }
        private Nullable<decimal> _tavild;
        public Nullable<decimal> tavild
        {
            get { return _tavild; }
            set
            {
                if (_tavild != value)
                {
                    _tavild = value;
                    RaisePropertyChanged("tavild");
                }
            }
        }
        private Nullable<decimal> _tavgoo;
        public Nullable<decimal> tavgoo
        {
            get { return _tavgoo; }
            set
            {
                if (_tavgoo != value)
                {
                    _tavgoo = value;
                    RaisePropertyChanged("tavgoo");
                }
            }
        }
        private Nullable<decimal> _amnild;
        public Nullable<decimal> amnild
        {
            get { return _amnild; }
            set
            {
                if (_amnild != value)
                {
                    _amnild = value;
                    RaisePropertyChanged("amnild");
                }
            }
        }

        private Nullable<decimal> _amxild;
        public Nullable<decimal> amxild
        {
            get { return _amxild; }
            set
            {
                if (_amxild != value)
                {
                    _amxild = value;
                    RaisePropertyChanged("amxild");
                }
            }
        }
        private Nullable<decimal> _aavild;
        public Nullable<decimal> aavild
        {
            get { return _aavild; }
            set
            {
                if (_aavild != value)
                {
                    _aavild = value;
                    RaisePropertyChanged("aavild");
                }
            }
        }
        private Nullable<decimal> _aavgoo;
        public Nullable<decimal> aavgoo
        {
            get { return _aavgoo; }
            set
            {
                if (_aavgoo != value)
                {
                    _aavgoo = value;
                    RaisePropertyChanged("aavgoo");
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
                    _comp_code = value;
                    RaisePropertyChanged("comp_code");
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
                    _location_Id = value;
                    RaisePropertyChanged("location_Id");
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
                    _doc_cat = value;
                    RaisePropertyChanged("doc_cat");
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
                    _doc_type = value;
                    RaisePropertyChanged("doc_type");
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
                    _active = value;
                    RaisePropertyChanged("active");
                }
            }
        }
        private string  _add_by;
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
        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date
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
        private string _machinecode;
        public string machinecode
        {
            get { return _machinecode; }
            set
            {
                if (_machinecode != value)
                {
                    _machinecode = value;
                    RaisePropertyChanged("machinecode");
                }
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
                if (_Conv_lot != value)
                {
                    _Conv_lot = value;
                    RaisePropertyChanged("Conv_lot", ModelEntityUpdated);
                }
            }
        }
        private decimal? _Ranget;
        public decimal? Ranget
        {
            get { return _Ranget; }
            set
            {
                if (_Ranget != value)
                {
                    _Ranget = value;
                    RaisePropertyChanged("Ranget");
                }
            }
        }
        private decimal _Rangea;
        public decimal Rangea
        {
            get { return _Rangea; }
            set
            {
                if (_Rangea != value)
                {
                    _Rangea = value;
                    RaisePropertyChanged("Rangea");
                }
            }
        }
        private string _obrem;
        public string obrem
        {
            get { return _obrem; }
            set
            {
                if (_obrem != value)
                {
                    _obrem = value;
                    RaisePropertyChanged("obrem");
                }
            }
        }
        private string _uhdec;
        public string uhdec
        {
            get { return _uhdec; }
            set
            {
                if (_uhdec != value)
                {
                    _uhdec = value;
                    RaisePropertyChanged("uhdec");
                }
            }
        }
        private string _uhrem;
        public string uhrem
        {
            get { return _uhrem; }
            set
            {
                if (_uhrem != value)
                {
                    _uhrem = value;
                    RaisePropertyChanged("uhrem");
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
        private string _prdct_codeBack;
        public string prdct_codeBack
        {
            get { return _prdct_codeBack; }
            set
            {
                if (_prdct_codeBack != value)
                {
                    _prdct_codeBack = value;
                    RaisePropertyChanged("prdct_codeBack");
                }
            }
        }
        private string _itemname;
        public string itemname
        {
            get { return _itemname; }
            set
            {
                if (_itemname != value)
                {
                    _itemname = value;
                    RaisePropertyChanged("itemname");
                }
            }
        }
        private string _EmpId;
        public string EmpId
        {
            get { return _EmpId; }
            set
            {
                if (_EmpId != value)
                {
                    _EmpId = value;
                    RaisePropertyChanged("EmpId");
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
                    _check_qty = value;
                    RaisePropertyChanged("check_qty");
                }
            }
        }
        private Nullable<decimal> _counter_qty;
        public Nullable<decimal> counter_qty
        {
            get { return _counter_qty; }
            set
            {
                if (_counter_qty != value)
                {
                    _counter_qty = value;
                    RaisePropertyChanged("counter_qty");
                }
            }
        }
        private string _test_code;
        public string test_code
        {
            get { return _test_code; }
            set
            {
                if (_test_code != value)
                {
                    _test_code = value;
                    RaisePropertyChanged("test_code");
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

        private string _order_no;
        public string order_no
        {
            get { return _order_no; }
            set
            {
                if (_order_no != value)
                {
                    _order_no = value;
                    RaisePropertyChanged("order_no");
                }
            }
        }
        private string _batch_no;
        public string batch_no
        {
            get { return _batch_no; }
            set
            {
                if (_batch_no != value)
                {
                    _batch_no = value;
                    RaisePropertyChanged("batch_no");
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
                    _PartyId = value;
                    RaisePropertyChanged("PartyId");
                }
            }
        }

        private string _PartyNm;
        public string PartyNm
        {
            get { return _PartyNm; }
            set
            {
                if (_PartyNm != value)
                {
                    _PartyNm = value;
                    RaisePropertyChanged("PartyNm");
                }
            }
        }
        private string _ild;
        public string ild
        {
            get { return _ild; }
            set
            {
                if (_ild != value)
                {
                    _ild = value;
                    RaisePropertyChanged("ild");
                }
            }
        }

        //private string _Conv_no;
        //public string Conv_no
        //{
        //    get { return _Conv_no; }
        //    set
        //    {
        //        _Conv_no = value;
        //        RaisePropertyChanged("Conv_no");
        //    }
        //}
        public decimal shank_dia { get; set; }
        public string shanklen { get; set; }
        public string ShankChamfer { get; set; }
        public string needlelen { get; set; }
        public string needledia { get; set; }
        public string TotalLen { get; set; }
        public string ballout { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }
        public string XmlDataDocument_ECRM_T003_B { get; set; }       
    }
    public class ECRM_T003_B : ObjectBase
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    RaisePropertyChanged("id");
                }
            }
        }
        private Nullable<int> _wtid;
        public Nullable<int> wtid
        {
            get { return _wtid; }
            set
            {
                if (_wtid != value)
                {
                    _wtid = value;
                    RaisePropertyChanged("wtid");
                }
            }
        }

        private string _refilno;
        public string refilno
        {
            get { return _refilno; }
            set
            {
                if (_refilno != value)
                {
                    _refilno = value;
                    RaisePropertyChanged("refilno");
                }
            }
        }
        private decimal _wbtsta;
        public decimal wbtsta
        {
            get { return _wbtsta; }
            set
            {
                if (_wbtsta != value)
                {
                    _wbtsta = value;
                    RaisePropertyChanged("wbtsta");
                }
            }
        }
        private decimal _watstb;
        public decimal watstb
        {
            get { return _watstb; }
            set
            {
                if (_watstb != value)
                {
                    _watstb = value;
                    RaisePropertyChanged("watstb");
                }
            }
        }
        private decimal _waclgc;
        public decimal waclgc
        {
            get { return _waclgc; }
            set
            {
                if (_waclgc != value)
                {
                    _waclgc = value;
                    RaisePropertyChanged("waclgc");
                }
            }
        }
        private decimal _ild;
        public decimal ild
        {
            get { return _ild; }
            set
            {
                if (_ild != value)
                {
                    _ild = value;
                    RaisePropertyChanged("ild");
                }
            }
        }
        private decimal _gooping;
        public decimal gooping
        {
            get { return _gooping; }
            set
            {
                if (_gooping != value)
                {
                    _gooping = value;
                    RaisePropertyChanged("gooping");
                }
            }
        }
        private string _defects;
        public string defects
        {
            get { return _defects; }
            set
            {
                if (_defects != value)
                {
                    _defects = value;
                    RaisePropertyChanged("defects");
                }
            }
        }
        private string _remusr;
        public string remusr
        {
            get { return _remusr; }
            set
            {
                if (_remusr != value)
                {
                    _remusr = value;
                    RaisePropertyChanged("remusr");
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
                    _comp_code = value;
                    RaisePropertyChanged("comp_code");
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
                    _location_Id = value;
                    RaisePropertyChanged("location_Id");
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
                    _doc_cat = value;
                    RaisePropertyChanged("doc_cat");
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
                    _doc_type = value;
                    RaisePropertyChanged("doc_type");
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
                    _active = value;
                    RaisePropertyChanged("active");
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
                    _add_by = value;
                    RaisePropertyChanged("add_by");
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
        private string _wtno;
        public string Wtno
        {
            get { return _wtno; }
            set { _wtno = value; }
        }
      
    }
    public class MultipleContext_ECRM_T003_A
    {
        public List<ECRM_T003_A> WritingTest { get; set; }//WritingTest  
        public List<EPR_T001_P> ILDChart { get; set; }//ILDChart Master
        public List<ADM_M022_P_ESSEM> Products { get; set; }//Item Master     
        public List<ZADM_M007_P> ILD { get; set; }//ILD Master  remove
        public List<EPR_T001_P> ConvLot { get; set; }//Conv Lot From ILDChart   
        public List<ZADM_M009_P> Models { get; set; }//Model Master remove
        public List<ZADM_M006_P> INK { get; set; }//Ink Master  remove
        public List<ECRM_T003_B_P> Refil { get; set; }// Refil Frm WritingTest Details remove
        public ObservableCollection<ECRM_T003_B> WTDetails { get; set; }//WritingTest Details
        public List<ZADM_M016_P> Defect { get; set; }// Defect Master
        public List<ECRM_T003_A_P> ProductFrmWT { get; set; }//Writing Test 
        public List<ADM_M024_P> EmpList { get; set; }
        public List<ECRM_T003_C_P> Test_Type { get; set; }
        public List<PPC_T003_Batch> BatchDetails { get; set; }
    }
 
}
