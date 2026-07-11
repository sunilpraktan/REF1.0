using Reflection.BusinessEntity.ADM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity
{
    public class ESO_T001 : ObjectBase
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
        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                _doc_no = value;
                RaisePropertyChanged("doc_no");
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
        private Nullable<System.DateTime> _entry_dt;
        public Nullable<System.DateTime> entry_dt
        {
            get { return _entry_dt; }
            set
            {
                _entry_dt = value;
                RaisePropertyChanged("entry_dt");
            }
        }
        private Nullable<System.DateTime> _prod_dt;
        public Nullable<System.DateTime> prod_dt
        {
            get { return _prod_dt; }
            set
            {
                _prod_dt = value;
                RaisePropertyChanged("prod_dt");
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
        private decimal? _rej_qty_1;
        public Nullable<decimal> rej_qty_1
        {
            get { return _rej_qty_1; }
            set
            {
                _rej_qty_1 = value;
                RaisePropertyChanged("rej_qty_1", ModelEntityUpdated);
            }
        }
        private Nullable<decimal> _rej_qty_2;
        public Nullable<decimal> rej_qty_2
        {
            get { return _rej_qty_2; }
            set
            {
                _rej_qty_2 = value;
                RaisePropertyChanged("rej_qty_2", ModelEntityUpdated);
            }
        }
        private Nullable<decimal> _tot_rej;
        public Nullable<decimal> tot_rej
        {
            get { return _tot_rej; }
            set
            {
                _tot_rej = value;
                RaisePropertyChanged("tot_rej", ModelEntityUpdated);
            }
        }
        private string _sort_by;
        public string sort_by
        {
            get { return _sort_by; }
            set
            {
                _sort_by = value;
                RaisePropertyChanged("sort_by");
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
        private Nullable<decimal> _rej_qty_3;
        public Nullable<decimal> rej_qty_3
        {
            get { return _rej_qty_3; }
            set
            {
                _rej_qty_3 = value;
                RaisePropertyChanged("rej_qty_3", ModelEntityUpdated);
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
        private string _ref_doc_no;
        public string ref_doc_no
        {
            get { return _ref_doc_no; }
            set
            {
                _ref_doc_no = value;
                RaisePropertyChanged("ref_doc_no");
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
        private string _shift_incharge;
        public string shift_incharge
        {
            get { return _shift_incharge; }
            set
            {
                _shift_incharge = value;
                RaisePropertyChanged("shift_incharge");
            }
        }
        private Nullable<int> _machine_id;
        public Nullable<int> machine_id
        {
            get { return _machine_id; }
            set
            {
                _machine_id = value;
                RaisePropertyChanged("machine_id");
            }
        }
        private Nullable<decimal> _excess_qty;
        public Nullable<decimal> excess_qty
        {
            get { return _excess_qty; }
            set
            {
                _excess_qty = value;
                RaisePropertyChanged("excess_qty", ModelEntityUpdated);
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
        private Nullable<decimal> _uc_qty;
        public Nullable<decimal> uc_qty
        {
            get { return _uc_qty; }
            set
            {
                _uc_qty = value;
                RaisePropertyChanged("uc_qty", ModelEntityUpdated);
            }
        }
        private string _sort_cat;
        public string sort_cat
        {
            get { return _sort_cat; }
            set
            {
                _sort_cat = value;
                RaisePropertyChanged("sort_cat");
            }
        }
        private string _sort_type;
        public string sort_type
        {
            get { return _sort_type; }
            set
            {
                _sort_type = value;
                RaisePropertyChanged("sort_type");
            }
        }
        private Nullable<decimal> _sorted_qty;
        public Nullable<decimal> sorted_qty
        {
            get { return _sorted_qty; }
            set
            {
                _sorted_qty = value;
                RaisePropertyChanged("sorted_qty", ModelEntityUpdated);
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
        private Nullable<decimal> _refill_qty;
        public Nullable<decimal> refill_qty
        {
            get { return _refill_qty; }
            set
            {
                _refill_qty = value;
                RaisePropertyChanged("refill_qty", ModelEntityUpdated);
            }
        }
        private string _Col;
        public string Col
        {
            get { return _Col; }
            set
            {
                _Col = value;
                RaisePropertyChanged("Col");
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

        private string _remark1;
        public string remark1
        {
            get { return _remark1; }
            set { _remark1 = value;RaisePropertyChanged("remark1"); }
        }

        private string _remark2;
        public string remark2
        {
            get { return _remark2; }
            set { _remark2 = value;RaisePropertyChanged("remark2"); }
        }

        private decimal? _sample_qty;
        public decimal?sample_qty
        {
            get { return _sample_qty; }
            set { _sample_qty = value;RaisePropertyChanged("sample_qty", ModelEntityUpdated); }
        }
        // scalar fields 
        private System.DateTime? _Fromdt { get; set; }
        public System.DateTime? Fromdt
        {
            get { return _Fromdt; }
            set { _Fromdt = value; RaisePropertyChanged("Fromdt"); }
        }

        private System.DateTime? _Todt { get; set; }
        public System.DateTime? Todt
        {
            get { return _Todt; }
            set { _Todt = value; RaisePropertyChanged("Todt"); }
        }

        private string _EmpId1 { get; set; }
        public string EmpId1
        {
            get { return _EmpId1; }
            set { _EmpId1 = value; RaisePropertyChanged("EmpId1"); }
        }

        private string _qc_person1 { get; set; }
        public string qc_person1
        {
            get { return _qc_person1; }
            set { _qc_person1 = value; RaisePropertyChanged("qc_person1"); }
        }

        private string _sshift { get; set; }
        public string sshift
        {
            get { return _sshift; }
            set { _sshift = value; RaisePropertyChanged("sshift"); }
        }

        private string _item { get; set; }
        public string item
        {
            get { return _item; }
            set { _item = value; RaisePropertyChanged("item"); }
        }

        private string _machine { get; set; }
        public string machine
        {
            get { return _machine; }
            set { _machine = value; RaisePropertyChanged("machine"); }
        }

        private string _con_no { get; set; }
        public string con_no
        {
            get { return _con_no; }
            set { _con_no = value; RaisePropertyChanged("con_no"); }
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
            set { if (_wc_code != value) { _wc_code = value; RaisePropertyChanged("wc_code"); } }
        }
        private string _grade;
        public string grade
        {
            get { return _grade; }
            set { if (_grade != value) { _grade = value; RaisePropertyChanged("grade"); } }
        }
        private string _counter_remark;
        public string counter_remark
        {
            get { return _counter_remark; }
            set { if (_counter_remark != value) { _counter_remark = value; RaisePropertyChanged("counter_remark"); } }
        }
        private System.DateTime? _in_date { get; set; }
        public System.DateTime? in_date
        {
            get { return _in_date; }
            set { _in_date = value; RaisePropertyChanged("in_date"); }
        }
        private System.DateTime? _out_date { get; set; }
        public System.DateTime? out_date
        {
            get { return _out_date; }
            set { _out_date = value; RaisePropertyChanged("out_date"); }
        }
        private decimal? _c_qty;
        public decimal? c_qty
        {
            get { return _c_qty; }
            set { _c_qty = value; RaisePropertyChanged("c_qty"); }
        }

        public string XmlDataDocument_ESO_T001 { get; set; }
        public string XmlDataDocument_ESO_T001_A { get; set; }
        public string XmlDataDocument_ESO_T001_B { get; set; }
        public string XmlDataDocument_ESO_T001FLIP { get; set; }

        #region Rreport 
        //------------SCALARS-------------------------------------
        private string _plant;//USED IN SORTING REPORT XAML FORM BUT ITS COLLAPSED
        public string plant
        {
            get { return _plant; }
            set
            {
                _plant = value;
                RaisePropertyChanged("plant");
            }
        }


        private string _OperatorName;
        public string OperatorName
        {
            get { return _OperatorName; }
            set
            {
                _OperatorName = value;
                RaisePropertyChanged("OperatorName");
            }
        }
        private string _ShiftInchargeName;
        public string ShiftInchargeName
        {
            get { return _ShiftInchargeName; }
            set
            {
                _ShiftInchargeName = value;
                RaisePropertyChanged("ShiftInchargeName");
            }
        }

        //--------------USED FOR RADIO BUTTONS
        private Nullable<bool> _ButtonAIsChecked;
        public Nullable<bool> ButtonAIsChecked
        {
            get { return _ButtonAIsChecked; }
            set
            {
                _ButtonAIsChecked = value;
                RaisePropertyChanged("ButtonAIsChecked");
            }
        }
        private Nullable<bool> _ButtonBIsChecked;
        public Nullable<bool> ButtonBIsChecked
        {
            get { return _ButtonBIsChecked; }
            set
            {
                _ButtonBIsChecked = value;
                RaisePropertyChanged("ButtonBIsChecked");
            }
        }
        private Nullable<decimal> _Total;//USED TO STORE TOTAL
        public Nullable<decimal> Total
        {
            get { return _Total; }
            set
            {
                _Total = value;
                RaisePropertyChanged("Total");
            }
        }

        public string rpttpe { get; set; }      //USED FOR REPORT TYPE
        /// <summary>
        /// //REPORT
        /// </summary>
        private Nullable<System.DateTime> _FrmDate;
        public Nullable<System.DateTime> FrmDate//Production FrmDate
        {
            get { return _FrmDate; }
            set
            {
                _FrmDate = value;
                RaisePropertyChanged("FrmDate");
            }
        }
        private Nullable<System.DateTime> _ToDate;
        public Nullable<System.DateTime> ToDate//Production ToDate
        {
            get { return _ToDate; }
            set
            {
                _ToDate = value;
                RaisePropertyChanged("ToDate");
            }
        }
        public Nullable<System.DateTime> SortingDate { get; set; }//USED IN SORTING REPORT XAML FORM BUT ITS COLLAPSED
                                                                  // public string FinYear { get; set; }
        private string _Engineer;
        public string Engineer
        {
            get { return _Engineer; }
            set
            {
                _Engineer = value;
                RaisePropertyChanged("Engineer");
            }
        }
        private Nullable<int> _Engineer_id;
        public Nullable<int> Engineer_id
        {
            get { return _Engineer_id; }
            set
            {
                _Engineer_id = value;
                RaisePropertyChanged("Engineer_id");
            }
        }

        //public Nullable<int> defects_id { get; set; }
        private Nullable<int> _defects_id;
        public Nullable<int> defects_id
        {
            get { return _defects_id; }
            set
            {
                _defects_id = value;
                RaisePropertyChanged("defects_id");
            }
        }
        // public string RptFormat { get; set; }
        private string _RptFormat;
        public string RptFormat
        {
            get { return _RptFormat; }
            set
            {
                _RptFormat = value;
                RaisePropertyChanged("RptFormat");
            }
        }
        //public string Col { get; set; }

        #endregion
    }
    public class ESO_T001_A : ObjectBase
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
        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                _doc_no = value;
                RaisePropertyChanged("doc_no");
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
        private Nullable<System.DateTime> _doc_date;
        public Nullable<System.DateTime> doc_date
        {
            get { return _doc_date; }
            set
            {
                _doc_date = value;
                RaisePropertyChanged("doc_date");
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
        private string _sort_cat;
        public string sort_cat
        {
            get { return _sort_cat; }
            set
            {
                _sort_cat = value;
                RaisePropertyChanged("sort_cat");
            }
        }
        private string _defect_type;
        public string defect_type
        {
            get { return _defect_type; }
            set
            {
                _defect_type = value;
                RaisePropertyChanged("defect_type");
            }
        }

        private string _shift1;
        public string shift1
        {
            get { return _shift1; }
            set
            {
                _shift1 = value;
                RaisePropertyChanged("shift1");
            }
        }
        private string _shift2;
        public string shift2
        {
            get { return _shift2; }
            set
            {
                _shift2 = value;
                RaisePropertyChanged("shift2");
            }
        }
        private string _shift3;
        public string shift3
        {
            get { return _shift3; }
            set
            {
                _shift3 = value;
                RaisePropertyChanged("shift3");
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
        private Nullable<decimal> _rej_qty1;
        public Nullable<decimal> rej_qty1
        {
            get { return _rej_qty1; }
            set
            {
                _rej_qty1 = value;
                RaisePropertyChanged("rej_qty1", ModelEntityUpdated);
            }
        }
        private Nullable<decimal> _rej_qty2;
        public Nullable<decimal> rej_qty2
        {
            get { return _rej_qty2; }
            set
            {
                _rej_qty2 = value;
                RaisePropertyChanged("rej_qty2", ModelEntityUpdated);
            }
        }
        private Nullable<decimal> _total;
        public Nullable<decimal> total
        {
            get { return _total; }
            set
            {
                _total = value;
                RaisePropertyChanged("total", ModelEntityUpdated);
            }
        }
        private string _Col;
        public string Col
        {
            get { return _Col; }
            set
            {
                _Col = value;
                RaisePropertyChanged("Col");
            }
        }
        private string _sort_by;
        public string sort_by
        {
            get { return _sort_by; }
            set
            {
                _sort_by = value; RaisePropertyChanged("sort_by");
            }
        }
        private string _defect_condition;
        public string defect_condition
        {
            get { return _defect_condition; }
            set
            {
                _defect_condition = value;
                RaisePropertyChanged("defect_condition");
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
        
        
    }
    public class MultipleContext_ESO_T001_A
    {
        public List<ESO_T001Flip> DocumentDataFlipGrid { get; set; }//BF data
        public List<ZADM_M013_P> MachineCodeList { get; set; }//Machine Details
        public List<ADM_M038_B_P> UOMList { get; set; }  //UOM List
        public List<ZADM_M016_P> DefectList { get; set; }  //Defect List
        public List<ADM_M042_P> Shift { get; set; }
        public List<ADM_M024_P> ShiftIncharge { get; set; }
        public List<PPC_T003_Batch> BatchDetails { get; set; }
        public List<ADM_M038_B_P> Engineer { get; set; }
        public List<ESO_T001Sort> SortBy { get; set; }
        public List<ESO_T001> MasterEntity { get; set; }  // Load Doc Data
        public ObservableCollection<ESO_T001_A> SortingDetails { get; set; }  // Load Defect Data
        public ObservableCollection<ESO_T001_B> DefectEntity { get; set; }
        public ObservableCollection<PPC_T003_Batch> SODetails { get; set; }
        public List<SYS_M002> DocTypeInfo { get; set; }
        //------------------REPORT---------------------
        public List<ESO_T001_rpt> sorting_rpt { get; set; } //Sort
        // Only for sorting transaction
        public List<ESO_T001> Sorting { get; set; }//Sorting
        public List<PPC_T001_P> BatchNo { get; set; }
        public List<ESO_T001_P> SortList { get; set; } //Sort
        public List<ESO_T001Sort> Machine { get; set; }
        public List<ESO_T001> RescanBarcode { get; set; }
        public List<ADM_M0013> t_statusList { get; set; }
        public List<ADM_M030_P> GradeList { get; set; }
    }
    public partial class ESO_T001_B : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _deletion_id { get; set; }
        public int deletion_id
        {
            get { return _deletion_id; }
            set
            {
                _deletion_id = value;
                RaisePropertyChanged("deletion_id");
            }
        }
        
        private int _id { get; set; }
        public int id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged("id");
            }
        }

        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                _doc_no = value;
                RaisePropertyChanged("doc_no");
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

        private Nullable<System.DateTime> _doc_date;
        public Nullable<System.DateTime> doc_date
        {
            get { return _doc_date; }
            set
            {
                _doc_date = value;
                RaisePropertyChanged("doc_date");
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
        private string _sort_cat;
        public string sort_cat
        {
            get { return _sort_cat; }
            set
            {
                _sort_cat = value;
                RaisePropertyChanged("sort_cat");
            }
        }

        private string _defect_type;
        public string defect_type
        {
            get { return _defect_type; }
            set
            {
                _defect_type = value;
                RaisePropertyChanged("defect_type");
            }
        }

        private string _shift1;
        public string shift1
        {
            get { return _shift1; }
            set
            {
                _shift1 = value;
                RaisePropertyChanged("shift1");
            }
        }
        private string _shift2;
        public string shift2
        {
            get { return _shift2; }
            set
            {
                _shift2 = value;
                RaisePropertyChanged("shift2");
            }
        }
        private string _shift3;
        public string shift3
        {
            get { return _shift3; }
            set
            {
                _shift3 = value;
                RaisePropertyChanged("shift3");
            }
        }

        private Nullable<decimal> _defect_qty;
        public Nullable<decimal> defect_qty
        {
            get { return _defect_qty; }
            set
            {
                _defect_qty = value;
                RaisePropertyChanged("defect_qty", ModelEntityUpdated);
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

        public string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set
            {
                _t_status = value;
                RaisePropertyChanged("t_status");
            }
        }
        public string _status_remark;
        public string status_remark
        {
            get { return _status_remark; }
            set
            {
                _status_remark = value;
                RaisePropertyChanged("status_remark");
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
        private Nullable<decimal> _rej_qty1;
        public Nullable<decimal> rej_qty1
        {
            get { return _rej_qty1; }
            set
            {
                _rej_qty1 = value;
                RaisePropertyChanged("rej_qty1", ModelEntityUpdated);
            }
        }
        private Nullable<decimal> _rej_qty2;
        public Nullable<decimal> rej_qty2
        {
            get { return _rej_qty2; }
            set
            {
                _rej_qty2 = value;
                RaisePropertyChanged("rej_qty2", ModelEntityUpdated);
            }
        }
        private Nullable<decimal> _total;
        public Nullable<decimal> total
        {
            get { return _total; }
            set
            {
                _total = value;
                RaisePropertyChanged("total", ModelEntityUpdated);
            }
        }
        private string _sort_by;
        public string sort_by
        {
            get { return _sort_by; }
            set
            {
                _sort_by = value;
                RaisePropertyChanged("sort_by");
            }
        }
        private string _defect_condition;
        public string defect_condition
        {
            get { return _defect_condition; }
            set
            {
                _defect_condition = value;
                RaisePropertyChanged("defect_condition");
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

        private string _parent_defect;
        public string parent_defect
        {
            get { return _parent_defect; }
            set
            {
                _parent_defect = value;
                RaisePropertyChanged("parent_defect");
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
    }
    public class MultipleContext_ESO_T001
    {
        public List<ESO_T001Flip> DocumentDataFlipGrid { get; set; }//BF data
        public List<ESO_T001> Sorting { get; set; }//Sorting
        public List<ESO_T001_P> SortList { get; set; }  //Sort 
        public List<ZADM_M013_P> MachineCodeList { get; set; }//machinecode
        public List<ADM_M038_B_P> UOMList { get; set; }  //UOM
        public List<ZADM_M016_P> DefectList { get; set; }  //Defect            
        public List<ADM_M038_B_P> Engineer { get; set; }
        public List<PPC_T001_P> BatchNo { get; set; }
        public List<ADM_M042_P> Shift { get; set; }
        public List<ADM_M024_P> ShiftIncharge { get; set; }
        public List<ESO_T001_rpt> sorting_rpt { get; set; } //Sort
        

    }
    public class ESO_T001_rpt
    {
        public string doc_no { get; set; }
        public Nullable<System.DateTime> entry_dt { get; set; }
        public Nullable<System.DateTime> prod_dt { get; set; }
        public Nullable<System.DateTime> FrmDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string machinecode { get; set; }
        public string defect_type { get; set; }
        public Nullable<decimal> rej_qty_1 { get; set; }
        public Nullable<decimal> rej_qty_2 { get; set; }
        public Nullable<decimal> total { get; set; }
        public Nullable<decimal> Grandtotal { get; set; }
        public string sort_by { get; set; }
        public string shift { get; set; }
        public string defect_condition { get; set; }
        public Nullable<bool> active { get; set; }
        public Nullable<int> add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public Nullable<int> edit_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string sort_type { get; set; }
        public string sort_cat { get; set; }

        public string shift_incharge { get; set; }
        public string ModelNm { get; set; }
        public Nullable<System.DateTime> SortingDate { get; set; }

        public string Month { get; set; }
        public string MonthNm { get; set; }
        public string remark { get; set; }
        public string machinecode1 { get; set; }
        public string machineorder { get; set; }
        public string unit_code { get; set; }
        public Nullable<decimal> counter_qty { get; set; }

        public Nullable<System.DateTime> in_date { get; set; }
        public Nullable<System.DateTime> out_date { get; set; }
        public Nullable<decimal> c_qty { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public string ild { get; set; }

    }
    public class ESO_T001_ReportParameter : ObjectBase
    {
        private Nullable<System.DateTime> _FrmDate;
        public Nullable<System.DateTime> FrmDate//Production FrmDate
        {
            get { return _FrmDate; }
            set
            {
                _FrmDate = value;
                RaisePropertyChanged("FrmDate");
            }
        }
        private Nullable<System.DateTime> _ToDate;
        public Nullable<System.DateTime> ToDate//Production ToDate
        {
            get { return _ToDate; }
            set
            {
                _ToDate = value;
                RaisePropertyChanged("ToDate");
            }
        }
        private Nullable<System.DateTime> _SortingDate;
        public Nullable<System.DateTime> SortingDate
        {
            get { return _SortingDate; }
            set
            {
                _SortingDate = value;
                RaisePropertyChanged("SortingDate");
            }
        }
        public string shift { get; set; }
        public string FinYear { get; set; }
        public string Engineer { get; set; }
        public string machine { get; set; }
        public string defect { get; set; }
        public Nullable<int> Engineer_id { get; set; }
        public Nullable<int> machine_id { get; set; }
        public Nullable<int> defects_id { get; set; }
        public string RptFormat { get; set; }

        private Nullable<System.DateTime> _entry_dt;
        public Nullable<System.DateTime> entry_dt
        {
            get { return _entry_dt; }
            set
            {
                _entry_dt = value;
                RaisePropertyChanged("entry_dt");
            }
        }

    }
    public class ESO_T001_Filter
    {
        public string plant { get; set; }
        public string rpttpe { get; set; }
        public Nullable<System.DateTime> FrmDate { get; set; }//Production FrmDate
        public Nullable<System.DateTime> ToDate { get; set; }//Production ToDate
        public Nullable<System.DateTime> SortingDate { get; set; }
        public string FinYear { get; set; }
        public string shift { get; set; }
        public string Engineer { get; set; }
        public string mc_code_rpt { get; set; }
        public string defects { get; set; }
        public string RptFormat { get; set; }
    }
    public class ESO_T001Sort
    {
        public string sort_by { get; set; }
        public string machinecode { get; set; }

    }
}
