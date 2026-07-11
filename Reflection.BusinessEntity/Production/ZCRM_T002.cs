using Reflection.BusinessEntity.ADM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Reflection.BusinessEntity
{
    public class ZCRM_T002 : ObjectBase
    {

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
        private string _doc_type { get; set; }
        public string doc_type
        {
            get { return _doc_type; }
            set { _doc_type = value; RaisePropertyChanged("doc_type"); }
        }
        private System.DateTime? _doc_date;
        public System.DateTime? doc_date
        {
            get { return _doc_date; }
            set
            {
                if (value == null)
                {
                    _doc_date = DateTime.Now;
                }
                else
                {
                    _doc_date = value;
                }
                RaisePropertyChanged("doc_date");
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
        private string _ItemCode;
        [DisplayName("Item Code")]
        [Required(ErrorMessage = "Field 'ItemCode' is required.")]
        public string ItemCode
        {
            get { return _ItemCode; }
            set { _ItemCode = value; RaisePropertyChanged("ItemCode"); }
        }
        private string _token_no;
        public string token_no
        {
            get { return _token_no; }
            set { _token_no = value; RaisePropertyChanged("token_no"); }
        }
        private string _batch_no;
        public string batch_no
        {
            get { return _batch_no; }
            set { _batch_no = value; RaisePropertyChanged("batch_no"); }
        }

        private Nullable<System.DateTime> _posting_date;
        public Nullable<System.DateTime> posting_date
        {
            get { return _posting_date; }
            set { _posting_date = value; RaisePropertyChanged("posting_date"); }
        }
        private string _machinecode;
        [DisplayName("Machine Code")]
        [Required(ErrorMessage = "Field 'machinecode' is required.")]
        public string machinecode
        {
            get { return _machinecode; }
            set { _machinecode = value; RaisePropertyChanged("machinecode"); }
        }

        private string _shift;
        [DisplayName("Shift")]
        [Required(ErrorMessage = "Field 'shift' is required.")]
        public string shift
        {
            get { return _shift; }
            set { _shift = value; RaisePropertyChanged("shift"); }
        }
        private string _shift_supervisor;
        public string shift_supervisor
        {
            get { return _shift_supervisor; }
            set { _shift_supervisor = value; RaisePropertyChanged("shift_supervisor"); }
        }
        private Nullable<decimal> _qty;
        public Nullable<decimal> qty
        {
            get { return _qty; }
            set { _qty = value; RaisePropertyChanged("qty"); }
        }
        private string _spelling_damage;
        public string spelling_damage
        {
            get { return _spelling_damage; }
            set { _spelling_damage = value; RaisePropertyChanged("spelling_damage"); }
        }
        private decimal? _ball_griping_force_min;
        public decimal? ball_griping_force_min
        {
            get { return _ball_griping_force_min; }
            set { _ball_griping_force_min = value; RaisePropertyChanged("ball_griping_force_min"); }
        }
        public string _body_damage;
        public string body_damage
        {
            get { return _body_damage; }
            set { _body_damage = value; RaisePropertyChanged("body_damage"); }
        }
        private string _channel_out;
        public string channel_out
        {
            get { return _channel_out; }
            set { _channel_out = value; RaisePropertyChanged("channel_out"); }
        }
        private string _hammer_out;
        public string hammer_out
        {
            get { return _hammer_out; }
            set { _hammer_out = value; RaisePropertyChanged("hammer_out"); }
        }
        private string _capillary_out;
        public string capillary_out
        {
            get { return _capillary_out; }
            set { _capillary_out = value; RaisePropertyChanged("capillary_out"); }
        }
        private string _other_problems;
        public string other_problems
        {
            get { return _other_problems; }
            set { _other_problems = value; RaisePropertyChanged("other_problems"); }
        }
        private string _remark;
        public string remark
        {
            get { return _remark; }
            set { _remark = value; RaisePropertyChanged("remark"); }
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
        private string _sku;
        public string sku
        {
            get { return _sku; }
            set { _sku = value; RaisePropertyChanged("sku"); }
        }
        private string _sku_desc;
        public string sku_desc
        {
            get { return _sku_desc; }
            set { _sku_desc = value; RaisePropertyChanged("sku_desc"); }
        }
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }
        }
        private Nullable<bool> _active;
        public Nullable<bool> active
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
        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date
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
        private string _conversion_no;
        [DisplayName("Conversion No")]
        [Required(ErrorMessage = "Field 'conversion_no' is required.")]
        public string conversion_no
        {
            get { return _conversion_no; }
            set { _conversion_no = value; RaisePropertyChanged("conversion_no"); }
        }
        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code"); }
        }
        private string _EmpLName;
        public string EmpLName
        {
            get { return _EmpLName; }
            set { _EmpLName = value; RaisePropertyChanged("EmpLName"); }
        }
        private string _ItemName;     
        public string ItemName
        {
            get { return _ItemName; }
            set { _ItemName = value; RaisePropertyChanged("ItemName"); }
        }

        private DateTime? _prod_dt;
        public DateTime ? prod_dt
        {
            get { return _prod_dt; }
            set { _prod_dt = value; RaisePropertyChanged("prod_dt"); }
        }

        private string _barcode;
        public string barcode
        {
            get { return _barcode; }
            set { _barcode = value; RaisePropertyChanged("barcode"); }
        }

        private string _qc_person;
        public string qc_person
        {
            get { return _qc_person; }
            set { _qc_person = value; RaisePropertyChanged("qc_person"); }
        }

        private string _QcName;
        public string QcName
        {
            get { return _QcName; }
            set { _QcName = value; RaisePropertyChanged("QcName"); }
        }

        private Decimal? _ball_griping_force_max;
        public decimal? ball_griping_force_max
        {
            get { return _ball_griping_force_max; }
            set { _ball_griping_force_max = value;RaisePropertyChanged("ball_griping_force_max"); }
        }

        private string _Ref_doc_type;
        public string Ref_doc_type
        {
            get { return _Ref_doc_type; }
            set { _Ref_doc_type = value; RaisePropertyChanged("Ref_doc_type"); }
        }

        private string _ref_doctp;
        public string ref_doctp
        {
            get { return _ref_doctp; }
            set { _ref_doctp = value; RaisePropertyChanged("ref_doctp"); }
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

        private System.DateTime? _Fromdt;
        public System.DateTime? Fromdt
        {
            get { return _Fromdt; }
            set { _Fromdt = value; RaisePropertyChanged("Fromdt"); }
        }

        private System.DateTime? _Todt;
        public System.DateTime? Todt
        {
            get { return _Todt; }
            set { _Todt = value; RaisePropertyChanged("Todt"); }
        }

        private string _machine;
        public string machine
        {
            get { return _machine; }
            set { _machine = value; RaisePropertyChanged("machine"); }
        }

        private string _item;
        public string item
        {
            get { return _item; }
            set { _item = value; RaisePropertyChanged("item"); }
        }

        private Nullable<decimal> _check_qty;
        public Nullable<decimal> check_qty
        {
            get { return _check_qty; }
            set { _check_qty = value; RaisePropertyChanged("check_qty"); }
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
            set
            {
                if (_wc_code != value)
                {
                    _wc_code = value;
                    RaisePropertyChanged("wc_code");
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
                    _grade = value;
                    RaisePropertyChanged("grade");
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
                    _counter_remark = value;
                    RaisePropertyChanged("counter_remark");
                }
            }
        }
        public string XmlDataDocument_ZCRM_T002_Flip { get; set; }
        public string XmlDataDocument_ZCRM_T002_A { get; set; }
        public static EventHandler ModelEntityUpdated { get; set; }
    }

    public partial class ZCRM_T002_A:ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private string _ParameterNm;
        public string ParameterNm
        {
            get { return _ParameterNm; }
            set { _ParameterNm = value; RaisePropertyChanged("ParameterNm"); }
        }

        private string _defectNm;
        public string defectNm
        {
            get { return _defectNm; }
            set { _defectNm = value; RaisePropertyChanged("defectNm"); }
        }

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

        private string _defect;
        public string defect
        {
            get { return _defect; }
            set { _defect = value; RaisePropertyChanged("defect"); }
        }

        private string _parameters;
        public string parameters
        {
            get { return _parameters; }
            set { _parameters = value; RaisePropertyChanged("parameters"); }
        }

        private string _observation;
        public string observation
        {
            get { return _observation; }
            set { _observation = value; RaisePropertyChanged("observation"); }
        }

        private Nullable<decimal> _defect_qty;
        public Nullable<decimal> defect_qty
        {
            get { return _defect_qty; }
            set { _defect_qty = value; RaisePropertyChanged("defect_qty"); }
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

        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set { _lang_key = value; RaisePropertyChanged("lang_key"); }
        }

        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }
        }

        private string _remark;
        public string remark
        {
            get { return _remark; }
            set { _remark = value; RaisePropertyChanged("remark"); }
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

        private bool _active;
        public bool active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }
    }

    public class MultipleContext_ZCRM_T002
        {
        public List<ZCRM_T004_RI_Flip> DocumentDataFlipGrid { get; set; }
        public List<ADM_M024_P> EmpList { get; set; }
        public List<ZADM_M013_P> MachineList { get; set; }
        public List<ZADM_M016_P> DefectList { get; set; }
        public List<ADM_M038_B_P> unitList { get; set; }
        public List<EPR_T001_P> ItemList { get; set; }
        public List<ECRM_T003_A_P> MachinShiftList { get; set; }
        public List<ZCRM_T002> MasterEntity { get; set; }
        public ObservableCollection<ZCRM_T002_A> DefectEntity { get; set; }
        public List<Ref_Doc_no> BatchDetails { get; set; }
        public List<ADM_M042_P> ShiftMaster { get; set; }
        public List<SYS_M013_P> RefDocTypeData { get; set; }
        public List<ENG_T003_P> Parameters { get; set; }
        public List<COM_T003> AttachmentData { get; set; }
        public List<SYS_M002> DocTypeInfo { get; set; }
        public List <ZCRM_T002> RescanBarcode { get; set; }
        public ObservableCollection<Ref_Doc_no> SODetails { get; set; }
        public List<ADM_M0013> t_statusList { get; set; }
        public List<ADM_M030_P> GradeList { get; set; }

    }
}
