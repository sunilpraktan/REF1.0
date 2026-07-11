using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity
{
    public class ESO_T001_RptEntity : ObjectBase
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

        private string _mctype;
        public string mctype
        {
            get { return _mctype; }
            set
            {
                _mctype = value;
                RaisePropertyChanged("mctype");
            }
        }

        private string _PMtype;
        public string PMtype
        {
            get { return _PMtype; }
            set
            {
                _PMtype = value;
                RaisePropertyChanged("PMtype");
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

        private string _machinedesc;
        public string machinedesc
        {
            get { return _machinedesc; }
            set
            {
                _machinedesc = value;
                RaisePropertyChanged("machinedesc");
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
        private string _Sort_Code;
        public string Sort_Code
        {
            get { return _Sort_Code; }
            set
            {
                _Sort_Code = value;
                RaisePropertyChanged("_Sort_Code");
            }
        }
        private Nullable<decimal> _sorted_qty;
        public Nullable<decimal> sorted_qty
        {
            get { return _sorted_qty; }
            set
            {
                _sorted_qty = value;
                RaisePropertyChanged("sorted_qty");
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
   
  

        #region Report 
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

        private string _ReportName;
        public string ReportName
        {
            get { return _ReportName; }
            set
            {
                _ReportName = value;
                RaisePropertyChanged("ReportName");
            }
        }

        private string _ReportCode;
        public string ReportCode
        {
            get { return _ReportCode; }
            set
            {
                _ReportCode = value;
                RaisePropertyChanged("ReportCode");
            }
        }
        private int _no_of_months;
        public int no_of_months
        {
            get { return _no_of_months; }
            set
            {
                _no_of_months = value;
                RaisePropertyChanged("no_of_months");
            }
        }

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
        private string _engineer;
        public string engineer
        {
            get { return _engineer; }
            set
            {
                _engineer = value;
                RaisePropertyChanged("engineer");
            }
        }
        private bool _Select;//scaler
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

        #endregion
    }
        public class MultipleContext_ESO_T001Report
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
        //------------------REPORT---------------------
        public List<ESO_T001_rpt> sorting_rpt { get; set; } //Sort
        // Only for sorting transaction
        public List<ESO_T001> Sorting { get; set; }//Sorting
        public List<PPC_T001_P> BatchNo { get; set; }
        public List<ESO_T001_P> SortList { get; set; } //Sort
        public List<ZADM_M013_P> EngineerDetails { get; set; }

    }

  

  
  
}
