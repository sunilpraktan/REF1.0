using Reflection.BusinessEntity.ADM;
using Reflection.BusinessEntity.Production;
using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity
{


    public class EPR_T001_New : ObjectBase
    {
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
        private int _machine_id;
        public int machine_id
        {
            get { return _machine_id; }
            set { _machine_id = value; RaisePropertyChanged("machine_id"); }
        }

        private string _shift;
        public string shift
        {
            get { return _shift; }
            set { _shift = value; RaisePropertyChanged("shift"); }
        }

        private int? _conv;
        public int? conv
        {
            get { return _conv; }
            set { _conv = value; RaisePropertyChanged("conv"); }
        }

        private Nullable<int> _model_id;
        public Nullable<int> model_id
        {
            get { return _model_id; }
            set { _model_id = value; RaisePropertyChanged("model_id"); }
        }



        private string _ball_dia;
        public string ball_dia
        {
            get { return _ball_dia; }
            set { _ball_dia = value; RaisePropertyChanged("ball_dia"); }
        }

        private string _ball_make;
        public string ball_make
        {
            get { return _ball_make; }
            set { _ball_make = value; RaisePropertyChanged("ball_make"); }
        }

        private string _wire_make;
        public string wire_make
        {
            get { return _wire_make; }
            set { _wire_make = value; RaisePropertyChanged("wire_make"); }
        }

        private string _ink;
        public string ink
        {
            get { return _ink; }
            set { _ink = value; RaisePropertyChanged("ink"); }
        }

        private int _pack_style;
        public int pack_style
        {
            get
            {
                return _pack_style;
            }
            set
            {
                if (_pack_style != value)
                {
                    _pack_style = value;
                    RaisePropertyChanged("pack_style");
                }
            }
        }

        private string _po_no;
        public string po_no
        {
            get { return _po_no; }
            set { _po_no = value; RaisePropertyChanged("po_no"); }
        }

        private string _PartyId;
        public string PartyId
        {
            get { return _PartyId; }
            set { _PartyId = value; RaisePropertyChanged("PartyId"); }
        }



        private string _ItemCode;
        public string ItemCode
        {
            get { return _ItemCode; }
            set { _ItemCode = value; RaisePropertyChanged("ItemCode"); }
        }

        
        private string _ild;
        public string ild
        {
            get { return _ild; }
            set { _ild = value; RaisePropertyChanged("ild"); }
        }

        private string _tds_no;
        public string tds_no
        {
            get { return _tds_no; }
            set { _tds_no = value; RaisePropertyChanged("tds_no"); }
        }

        private string _col;
        public string col
        {
            get { return _col; }
            set { _col = value; RaisePropertyChanged("col"); }
        }

        private string _ball_type;
        public string ball_type
        {
            get { return _ball_type; }
            set { _ball_type = value; RaisePropertyChanged("ball_type"); }
        }

        private string _basket;
        public string basket
        {
            get { return _basket; }
            set { _basket = value; RaisePropertyChanged("basket"); }
        }

        private string _spoons;
        public string spoons
        {
            get { return _spoons; }
            set { _spoons = value; RaisePropertyChanged("spoons"); }
        }

        private string _shape;
        public string shape
        {
            get { return _shape; }
            set { _shape = value; RaisePropertyChanged("shape"); }
        }

        private string _sf;
        public string sf
        {
            get { return _sf; }
            set { _sf = value; RaisePropertyChanged("sf"); }
        }

        private string _order_type;
        public string order_type
        {
            get { return _order_type; }
            set { _order_type = value; RaisePropertyChanged("order_type"); }
        }

        private string _shank_len;
        public string shank_len
        {
            get { return _shank_len; }
            set { _shank_len = value; RaisePropertyChanged("shank_len"); }
        }

        private string _needle_dia;
        public string needle_dia
        {
            get { return _needle_dia; }
            set { _needle_dia = value; RaisePropertyChanged("needle_dia"); }
        }

        private string _needle;
        public string needle
        {
            get { return _needle; }
            set { _needle = value; RaisePropertyChanged("needle"); }
        }

        private Nullable<System.DateTime> _start_dt;
        public Nullable<System.DateTime> start_dt
        {
            get { return _start_dt; }
            set { _start_dt = value; RaisePropertyChanged("start_dt"); }
        }

        private Nullable<System.DateTime> _end_dt;
        public Nullable<System.DateTime> end_dt
        {
            get { return _end_dt; }
            set { _end_dt = value; RaisePropertyChanged("end_dt"); }
        }

        private Nullable<bool> _appr;
        public Nullable<bool> appr
        {
            get { return _appr; }
            set { _appr = value; RaisePropertyChanged("appr"); }
        }

        private Nullable<System.DateTime> _apr_dt;
        public Nullable<System.DateTime> apr_dt
        {
            get { return _apr_dt; }
            set { _apr_dt = value; RaisePropertyChanged("apr_dt"); }
        }

        private string _apr_by;
        public string apr_by
        {
            get { return _apr_by; }
            set { _apr_by = value; RaisePropertyChanged("apr_by"); }
        }

        private Nullable<System.DateTime> _pro_dt;
        public Nullable<System.DateTime> pro_dt
        {
            get { return _pro_dt; }
            set { _pro_dt = value; RaisePropertyChanged("pro_dt"); }
        }

        private string _prod_plan;
        public string prod_plan
        {
            get { return _prod_plan; }
            set { _prod_plan = value; RaisePropertyChanged("prod_plan"); }
        }

        private string _t_display;
        public string t_display
        {
            get { return _t_display; }
            set { _t_display = value; RaisePropertyChanged("t_display"); }
        }

        private string _status;
        public string status
        {
            get { return _status; }
            set { _status = value; RaisePropertyChanged("status"); }
        }

        private string _Note;
        public string Note
        {
            get { return _Note; }
            set { _Note = value; RaisePropertyChanged("Note"); }
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

        private string _test_para;
        public string test_para
        {
            get { return _test_para; }
            set { _test_para = value; RaisePropertyChanged("test_para"); }
        }
        private Nullable<decimal> _wire_size;
        public Nullable<decimal> wire_size
        {
            get { return _wire_size; }
            set { _wire_size = value; RaisePropertyChanged("wire_size"); }
        }
        private string _pre_order_no;
        public string pre_order_no
        {
            get
            {
                return _pre_order_no;
            }
            set
            {
                if (_pre_order_no != value)
                {
                    _pre_order_no = value;
                    RaisePropertyChanged("pre_order_no");
                }
            }
        }
        private string _ref_doc_type;
        public string ref_doc_type
        {
            get { return _ref_doc_type; }
            set { _ref_doc_type = value; RaisePropertyChanged("ref_doc_type"); }
        }

        private string _ref_doc_no;
        public string ref_doc_no
        {
            get { return _ref_doc_no; }
            set { _ref_doc_no = value; RaisePropertyChanged("ref_doc_no"); }
        }

        private string _machinecode;
        public string machinecode

        {
            get { return _machinecode; }
            set { _machinecode = value; RaisePropertyChanged("machinecode"); }
        }

        private string _model_code;
        public string model_code
        {
            get { return _model_code; }
            set { _model_code = value; RaisePropertyChanged("model_code"); }
        }

        private string _order_no;
        public string order_no
        {
            get { return _order_no; }
            set { _order_no = value; RaisePropertyChanged("order_no"); }
        }

        private string _wc_code;
        public string wc_code

        {
            get { return _wc_code; }
            set { _wc_code = value; RaisePropertyChanged("wc_code"); }
        }
        //Scalar 

        //private Nullable<decimal> _quantity;
        //public Nullable<decimal> quantity
        //{
        //    get { return _quantity; }
        //    set { _quantity = value; RaisePropertyChanged("quantity"); }
        //}

        private string _PlantName;
        public string PlantName
        {
            get { return _PlantName; }
            set { _PlantName = value; RaisePropertyChanged("PlantName"); }
        }
        private string _MachineType;
        public string MachineType
        {
            get { return _MachineType; }
            set { _MachineType = value; RaisePropertyChanged("MachineType"); }
        }
        public string Type { get; set; }

        private string _PartyName;
        public string PartyName
        {
            get { return _PartyName; }
            set { _PartyName = value; RaisePropertyChanged("PartyName"); }
        }
        private bool _Select { get; set; }
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
        public string ReportType { get; set; }
        public string RptMachineType { get; set; }

        private Nullable<System.DateTime> _Rpt_Date;
        public Nullable<System.DateTime> Rpt_Date
        {
            get { return _Rpt_Date; }
            set { _Rpt_Date = value; RaisePropertyChanged("Rpt_Date"); }
        }
        private string _ItemName;
        public string ItemName
        {
            get { return _ItemName; }
            set { _ItemName = value; RaisePropertyChanged("ItemName"); }
        }

        private string _Conv_lot;
        public string Conv_lot
        {
            get { return _Conv_lot; }
            set { _Conv_lot = value; RaisePropertyChanged("Conv_lot"); }
        }
        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code"); }
        }

        private decimal? _qty;
        public decimal? qty
        {
            get { return _qty; }
            set { _qty = value; RaisePropertyChanged("qty"); }
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

        private string _language;
        public string language
        {
            get { return _language; }
            set { _language = value; RaisePropertyChanged("language"); }
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
        private string _temp_status;
        public string temp_status
        {
            get { return _temp_status; }
            set { _temp_status = value; RaisePropertyChanged("temp_status"); }
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
                if (_PackingUnit != value)
                {
                    _PackingUnit = value;
                    RaisePropertyChanged("PackingUnit");
                }
            }
        }

        private string _Unit;
        public string Unit
        {
            get
            {
                return _Unit;
            }
            set
            {
                if (_Unit != value)
                {
                    _Unit = value;
                    RaisePropertyChanged("Unit");
                }
            }
        }
        private Nullable<int> _ink_id;
        public Nullable<int> ink_id
        {
            get { return _ink_id; }
            set
            { if (_ink_id != value)  { _ink_id = value; RaisePropertyChanged("ink_id");  }  }
        }
        private Nullable<int> _wire_make_id;    
        public Nullable<int> wire_make_id { get { return _wire_make_id; } set { _wire_make_id = value; RaisePropertyChanged("wire_make_id"); } }

        private Nullable<int> _ild_id;
        public Nullable<int> ild_id { get { return _ild_id; } set { _ild_id = value; RaisePropertyChanged("ild_id"); } }

        private Nullable<int> _ball_make_id;
        public Nullable<int> ball_make_id { get { return _ball_make_id; } set { _ball_make_id = value; RaisePropertyChanged("ball_make_id"); } }

        private Nullable<int> _ball_type_id { get; set; }
        public Nullable<int> ball_type_id { get { return _ball_type_id; } set { _ball_type_id = value; RaisePropertyChanged("ball_type_id"); } }

        private Nullable<int> _wire_size_id { get; set; }
        public Nullable<int> wire_size_id { get { return _wire_size_id; } set { _wire_size_id = value; RaisePropertyChanged("wire_size_id"); } }

        #region Scalar 
        private string _location_nm;
        public string location_nm
        {
            get { return _location_nm; }
            set { _location_nm = value; RaisePropertyChanged("location_nm"); }
        }

        public string XmlDataDocument_EPR_T001 { get; set; }
        public string XmlDataDocument_EPR_T001_Flip { get; set; }
        #endregion

        #region //Filter Search Variables
        private DateTime? _Fltr_FrmDate;
        public DateTime? Fltr_FrmDate   //Production FrmDate
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
        public DateTime? Fltr_ToDate    //Production ToDate
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
        private string _Fltr_t_status;
        public string Fltr_t_status
        {
            get { return _Fltr_t_status; }
            set
            {
                if (_Fltr_t_status != value)
                {
                    _Fltr_t_status = value;
                    RaisePropertyChanged("Fltr_t_status");
                }
            }
        }

        private string _Fltr_t_display;
        public string Fltr_t_display
        {
            get { return _Fltr_t_display; }
            set
            {
                if (_Fltr_t_display != value)
                {
                    _Fltr_t_display = value;
                    RaisePropertyChanged("Fltr_t_display");
                }
            }
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

        private string _Fltr_location_Id;
        public string Fltr_location_Id
        {
            get { return _Fltr_location_Id; }
            set
            {
                if (_Fltr_location_Id != value)
                {
                    _Fltr_location_Id = value;
                    RaisePropertyChanged("Fltr_location_Id");
                }
            }
        }

        #endregion

        // adding new fields LifeTest AND TestDone

        private bool _lifeTest;
        public bool lifeTest
        {
            get
            {
                return _lifeTest; }
            set
            {
                
                _lifeTest = value;
                RaisePropertyChanged("lifeTest");
            }
        }

        private bool _TestDone;
        public bool TestDone
        {
            get
            {
                return _TestDone;
            }

            set
            {
               
                {
                    _TestDone = value;
                    RaisePropertyChanged("TestDone");
                }
            }
        }
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }

        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id"); }
        }

        //public string plant { get; set; }



        private string _sono;
        public string sono
        {
            get { return _sono; }
            set { _sono = value; RaisePropertyChanged("sono"); }
        }
        private string _doc_desc_user;
        public string doc_desc_user
        {
            get { return _doc_desc_user; }
            set { _doc_desc_user = value; RaisePropertyChanged("doc_desc_user"); }
        }
        private string _doc_type_user;
        public string doc_type_user
        {
            get { return _doc_type_user; }
            set { _doc_type_user = value; RaisePropertyChanged("doc_type_user"); }
        }
        private string _total_len;
        public string total_len
        {
            get { return _total_len; }
            set { _total_len = value; RaisePropertyChanged("total_len"); }
        }
        private Nullable<int> _plan_item_row_id;
        public Nullable<int> plan_item_row_id
        {
            get { return _plan_item_row_id; }
            set
            { if (_plan_item_row_id != value) { _plan_item_row_id = value; RaisePropertyChanged("plan_item_row_id"); } }
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
        private string _store_code;
        public string store_code { get; set; }

    }
    public class MultipleContext_EPR_T001_Conv
    {
        public List<EPR_T001_New> ILDChart2 { get; set; } // adding  ILD chart
        public List<EPR_T001_Flip> DocumentDataFlipGrid { get; set; }
        public List<PPC_M001_P> MachineList_CN { get; set; }
        public List<ZADM_M013_P> MachineList { get; set; }
        public List<PPC_T004_A_P> ProductionPlanningList { get; set; }
        public List<ZADM_M009_P> ModelMasterList { get; set; }
        public List<ZADM_M006_P> INKMasterList { get; set; }
        public List<ADM_M032_P> WireMakeList { get; set; }
        public List<ZADM_M003_P> WireSizeList { get; set; }
        public List<ADM_M028_P> PartyList { get; set; }
        public List<ZADM_M007_P> ILDMasterList { get; set; }
        public List<ADM_M032_P> BallMakeList { get; set; }
        public List<ZADM_M001_P> BallDia { get; set; } //Ball Dia
        public List<ADM_M022_P_ESSEM> ItemList { get; set; } //Product or item master        
        public List<ZADM_M017_P> PkgUnitList { get; set; }
        public List<ZADM_M002_P> BallTypeList { get; set; }
        public List<ADM_M042_P> Shift { get; set; }
        public List<EPR_T001_New> MasterEntity { get; set; }
        public List<EPR_T001_New> MasterEntityPrev { get; set; }
        public List<ECRM_T002_AFeedbackRpt> RptFeedback { get; set; }
        public List<SYS_M013_P> DocumentTypes { get; set; }
        public List<SEL_T001_P> SalesOrder { get; set; } // Order No / sales Doc.no
        public List<RPT_EPR_T001> RPTINK { get; set; }
        public List<RPT_Approval> Rptapproval { get; set; }
        public List<COM_T003> AttachmentData { get; set; }
        public List<ADM_M043_D> ApprovalData { get; set; }
        public List<ADM_M0013> t_StatusList { get; set; } //Transaction Status Master
        public List<SYS_M002> DocTypeInfo { get; set; }
    }
    public class EPR_T001_Flip
    {
        public int? id { get; set; }
        public string order_no { get; set; }
        public int? conv { get; set; }
        public DateTime start_dt { get; set; }
        public string machinecode { get; set; }
        public string Conv_lot { get; set; }
        public string model_code { get; set; }
        public string status { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int? machine_id { get; set; }
        public string pre_order_no { get; set; }
        public string prod_plan { get; set; }
    }
}
