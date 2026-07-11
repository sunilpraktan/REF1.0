using Reflection.BusinessEntity.ADM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reflection.BusinessEntity.Production
{
    public class PPC_T003 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private string _doc_no;
        private System.DateTime _prod_date;
        private System.DateTime? _clean_date;
        private System.DateTime? _doc_date;
        private string _batch_no;
        private Nullable<int> _machine_id;
        private string _machinecode;
        private string _shift1;
        private string _shift2;
        private string _shift3;
        private decimal? _quantity;
        private Nullable<decimal> _counter_q;
        private Nullable<decimal> _rejection_q;
        private string _remarks;
        private string _m_operator;
        private string _shift_incharge;
        private bool _active;
        private string _doc_type;
        private string _doc_cat;
        private string _add_by;
        private System.DateTime _add_date;
        private string _editby;
        private Nullable<System.DateTime> _edit_date;
        private string _comp_code;
        private string _location_Id;
        private string _ItemCode;
        private string _unit_code;
        private string _fin_year;
        private string _posting_period;
        private string _barcode;

        private string _operatornm;
        private string _EmpName;
        private string _t_status;
        private string _order_no;
        private Nullable<int> _conversion_no;
        private  Nullable<decimal> _excess_qty;
        private string _ref_doc_type;
        private string _ref_doc_no;
        //saclar
        private string _ref_Doc_TypeNm;
        private decimal? _sample_qty;
        private string _remark1;
        private string _remark2;
        public string doc_no
        {
            get { return _doc_no; }
            set { _doc_no = value; RaisePropertyChanged("doc_no", ModelEntityUpdated); }
        }
        //[Required(ErrorMessage = "Field 'Production Date' is required.")]
        public System.DateTime prod_date
        {
            get { return _prod_date; }
            set { _prod_date = value; RaisePropertyChanged("prod_date", ModelEntityUpdated); }
        }
        //[Required(ErrorMessage = "Field 'Cleaning Date' is required.")]
        public System.DateTime? clean_date
        {
            get { return _clean_date; }
            set { _clean_date = value; RaisePropertyChanged("clean_date", ModelEntityUpdated); }
        }
        //[Required(ErrorMessage = "Field 'Document Date' is required.")]
        public System.DateTime? doc_date
        {
            get { return _doc_date; }
            set { _doc_date = value; RaisePropertyChanged("doc_date", ModelEntityUpdated); }
        }
        public string batch_no
        {
            get { return _batch_no; }
            set { _batch_no = value; RaisePropertyChanged("batch_no", ModelEntityUpdated); }
        }
        //[Required(ErrorMessage = "Field 'Machine Number' is required.")]
        public Nullable<int> machine_id
        {
            get { return _machine_id; }
            set { _machine_id = value; RaisePropertyChanged("machine_id", ModelEntityUpdated); }
        }
        public string machinecode
        {
            get { return _machinecode; }
            set { _machinecode = value; RaisePropertyChanged("machinecode", ModelEntityUpdated); }
        }
        [Required(ErrorMessage = "Field 'Shift' is required.")]
        public string shift1
        {
            get { return _shift1; }
            set { _shift1 = value; RaisePropertyChanged("shift1", ModelEntityUpdated); }
        }
        public string shift2
        {
            get { return _shift2; }
            set { _shift2 = value; RaisePropertyChanged("shift2", ModelEntityUpdated); }
        }
        public string shift3
        {
            get { return _shift3; }
            set { _shift3 = value; RaisePropertyChanged("shift3", ModelEntityUpdated); }
        }
        [Required(ErrorMessage = "Field 'Quantity' is required.")]
        public decimal? quantity
        {
            get { return _quantity; }
            set { _quantity = value; RaisePropertyChanged("quantity", ModelEntityUpdated); }
        }
        public Nullable<decimal> counter_q
        {
            get { return _counter_q; }
            set { _counter_q = value; RaisePropertyChanged("counter_q", ModelEntityUpdated); }
        }
        public Nullable<decimal> rejection_q
        {
            get { return _rejection_q; }
            set { _rejection_q = value; RaisePropertyChanged("rejection_q", ModelEntityUpdated); }
        }
        public string remarks
        {
            get { return _remarks; }
            set { _remarks = value; RaisePropertyChanged("remarks", ModelEntityUpdated); }
        }
        public string m_operator
        {
            get { return _m_operator; }
            set { _m_operator = value; RaisePropertyChanged("m_operator", ModelEntityUpdated); }
        }
        public string shift_incharge
        {
            get { return _shift_incharge; }
            set { _shift_incharge = value; RaisePropertyChanged("shift_incharge", ModelEntityUpdated); }
        }
        public bool active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active", ModelEntityUpdated); }
        }
        public string doc_type
        {
            get { return _doc_type; }
            set { _doc_type = value; RaisePropertyChanged("doc_type", ModelEntityUpdated); }
        }
        public string doc_cat
        {
            get { return _doc_cat; }
            set { _doc_cat = value; RaisePropertyChanged("doc_cat", ModelEntityUpdated); }
        }
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by", ModelEntityUpdated); }
        }
        public DateTime add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date", ModelEntityUpdated); }
        }
        public string editby
        {
            get { return _editby; }
            set { _editby = value; RaisePropertyChanged("editby", ModelEntityUpdated); }
        }
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date", ModelEntityUpdated); }
        }
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code", ModelEntityUpdated); }
        }
       
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id", ModelEntityUpdated); }
        }
        public string ItemCode
        {
            get { return _ItemCode; }
            set { _ItemCode = value; RaisePropertyChanged("ItemCode", ModelEntityUpdated); }
        }
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code", ModelEntityUpdated); }
        }
        public string fin_year
        {
            get { return _fin_year; }
            set { _fin_year = value; RaisePropertyChanged("fin_year", ModelEntityUpdated); }
        }
        public string posting_period
        {
            get { return _posting_period; }
            set { _posting_period = value; RaisePropertyChanged("posting_period", ModelEntityUpdated); }
        }
        
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status", ModelEntityUpdated); }
        }
        public string barcode
        {
            get { return _barcode; }
            set { _barcode = value; RaisePropertyChanged("barcode"); }
        }
        public string ref_doc_type
        {
            get { return _ref_doc_type; }
            set { _ref_doc_type = value; RaisePropertyChanged("ref_doc_type"); }
        }
        public string ref_doc_no
        {
            get { return _ref_doc_no; }
            set { _ref_doc_no = value; RaisePropertyChanged("ref_doc_no"); }
        }
        private string _wc_code;
        public string wc_code
        {
            get { return _wc_code; }
            set { _wc_code = value; RaisePropertyChanged("wc_code"); }
        }
        private string _grade;
        public string grade
        {
            get { return _grade; }
            set { _grade = value; RaisePropertyChanged("grade"); }
        }
        //scalar      
        public string operatornm
        {
            get { return _operatornm; }
            set { _operatornm = value; RaisePropertyChanged("operatornm", ModelEntityUpdated); }
        }
        public string EmpName
        {
            get { return _EmpName; }
            set { _EmpName = value; RaisePropertyChanged("EmpName", ModelEntityUpdated); }
        }
        private string _ItemName;
        public string ItemName
        {
            get { return _ItemName; }
            set { _ItemName = value; RaisePropertyChanged("ItemName", ModelEntityUpdated); }
        }
        public string order_no
        {
            get { return _order_no; }
            set { _order_no = value; RaisePropertyChanged("order_no", ModelEntityUpdated); }
        }
        public Nullable<decimal> excess_qty
        {
            get { return _excess_qty; }
            set { _excess_qty = value; RaisePropertyChanged("excess_qty", ModelEntityUpdated); }
        }
        public Nullable<int> conversion_no
        {
            get { return _conversion_no; }
            set { _conversion_no = value; RaisePropertyChanged("conversion_no", ModelEntityUpdated); }
        }
        public string ref_Doc_TypeNm
        {
            get { return _ref_Doc_TypeNm; }
            set { _ref_Doc_TypeNm = value; RaisePropertyChanged("ref_Doc_TypeNm"); }
        }

        public decimal? sample_qty
        {
            get { return _sample_qty; }
            set { _sample_qty = value; RaisePropertyChanged("sample_qty", ModelEntityUpdated); }
        }

        public string remark1
        {
            get { return _remark1; }
            set { _remark1 = value;RaisePropertyChanged("remark1"); }
        }
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

        private string _EmpId1;
        public string EmpId1
        {
            get { return _EmpId1; }
            set { _EmpId1 = value; RaisePropertyChanged("EmpId1"); }
        }

        private string _qc_person1;
        public string qc_person1
        {
            get { return _qc_person1; }
            set { _qc_person1 = value; RaisePropertyChanged("qc_person1"); }
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

        private string _con_no;
        public string con_no
        {
            get { return _con_no; }
            set { _con_no = value; RaisePropertyChanged("con_no"); }
        }

        private string _machine;
        public string machine
        {
            get { return _machine; }
            set { _machine = value; RaisePropertyChanged("machine"); }
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
        public string XmlDataDocument_FlipGrid { get; set; }
    }

    public class MultipleContext_PPC_T003
    {
        public List<PPC_T003_BackFlip> BackFlipEntity { get; set; }
        public List<PPC_T003> MasterEntity { get; set; }
        public List<EPR_T001_P> MachineMaster { get; set; }
        public List<ADM_M024_P> EmployeeMaster { get; set; }
        public List<ADM_M042_P> ShiftMaster { get; set; }
        public List<ADM_M038_B_P> UOMList { get; set; }  //UOM List
        public List<RptUltrasonicLabelGen> RptUltraLabelList { get; set; }
        public List<COM_T003> AttachmentData { get; set; }
        public List<SYS_M013_P> Ref_DocTypeData { get; set; }
        public List<Ref_Doc_no> Ref_DocNoData { get; set; }
        public List<PPC_T003> RescanBarcode { get; set; }
        public List<SYS_M002> DocTypeInfo { get; set; }
        public List<ADM_M0013> t_statusList { get; set; }
        public List<ADM_M030_P> GradeList { get; set; }
    }
   
    public class PPC_T003_BackFlip
    {
        public string doc_no { get; set; }
        public System.DateTime prod_date { get; set; }
        public Nullable<System.DateTime> clean_date { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string batch_no { get; set; }
        public string machinecode { get; set; }
        public string shift1 { get; set; }
        public string shift_incharge { get; set; }
        public string m_operator { get; set; }
        public string EmpName { get; set; }
        public bool active { get; set; }
        public string barcode { get; set; }
        public decimal quantity { get; set; }
        public string t_display { get; set; }

    }

    public class RptUltrasonicLabelGen
    {
        public string batch_no { get; set; }
        public string barcode { get; set; }
        public string shift1 { get; set; }
        public string machinecode { get; set; }
        public string ItemCode { get; set; }
        public decimal quantity { get; set; }
        public string doc_no { get; set; }
        public System.DateTime prod_date { get; set; }


    }
    

}
