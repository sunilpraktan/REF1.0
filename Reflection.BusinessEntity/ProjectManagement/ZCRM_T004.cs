using Reflection.BusinessEntity.ADM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Reflection.BusinessEntity
{
    public partial class ZCRM_T004 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                if (_doc_no != value)
                {
                    _doc_no = value; RaisePropertyChanged("doc_no", ModelEntityUpdated);
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

        public Nullable<System.DateTime> _doc_date;
        public Nullable<System.DateTime> doc_date
        {
            get { return _doc_date; }
            set
            {
                if (_doc_date != value)
                {
                    _doc_date = value; RaisePropertyChanged("doc_date");
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

        private string _EmpId;
        public string EmpId
        {
            get { return _EmpId; }
            set
            {
                if (_EmpId != value)
                {
                    _EmpId = value; RaisePropertyChanged("EmpId");
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

        private string _tender_no;
        [Required(ErrorMessage = "Field 'tender_no' is required.")]
        [DisplayName("Tender No")]
        public string tender_no
        {
            get { return _tender_no; }
            set
            {
                if (_tender_no != value)
                {
                    _tender_no = value; RaisePropertyChanged("tender_no");
                }
            }
        }


        private string _tender_name;
        [Required(ErrorMessage = "Field 'tender_name' is required.")]
        [DisplayName("Tender Name")]
        public string tender_name
        {
            get { return _tender_name; }
            set
            {
                if (_tender_name != value)
                {
                    _tender_name = value; RaisePropertyChanged("tender_name");
                }
            }
        }

        private Nullable<System.DateTime> _tender_date;
        public Nullable<System.DateTime> tender_date
        {
            get { return _tender_date; }
            set
            {
                if (_tender_date != value)
                {
                    _tender_date = value; RaisePropertyChanged("tender_date");
                }
            }
        }

        private string _doc_name;
        public string doc_name
        {
            get { return _doc_name; }
            set
            {
                if (_doc_name != value)
                {
                    _doc_name = value; RaisePropertyChanged("doc_name");
                }
            }
        }

        private string _tender_desc;
        public string tender_desc
        {
            get { return _tender_desc; }
            set
            {
                if (_tender_desc != value)
                {
                    _tender_desc = value; RaisePropertyChanged("tender_desc");
                }
            }
        }

        private Nullable<System.DateTime> _release_date;
        public Nullable<System.DateTime> release_date
        {
            get { return _release_date; }
            set
            {
                if (_release_date != value)
                {
                    _release_date = value; RaisePropertyChanged("release_date");
                }
            }
        }

        private Nullable<System.DateTime> _delivery_date;
        public Nullable<System.DateTime> delivery_date
        {
            get { return _delivery_date; }
            set
            {
                if (_delivery_date != value)
                {
                    _delivery_date = value; RaisePropertyChanged("delivery_date");
                }
            }
        }

        private Nullable<decimal> _qty;
        public Nullable<decimal> qty
        {
            get { return _qty; }
            set
            {
                if (_qty != value)
                {
                    _qty = value; RaisePropertyChanged("qty");
                }
            }
        }

        private Nullable<decimal> _unit_price;
        public Nullable<decimal> unit_price
        {
            get { return _unit_price; }
            set
            {
                if (_unit_price != value)
                {
                    _unit_price = value; RaisePropertyChanged("unit_price");
                }
            }
        }


        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set
            {
                if (_unit_code != value)
                {
                    _unit_code = value; RaisePropertyChanged("unit_code");
                }
            }
        }

        private Nullable<decimal> _tender_value;
        public Nullable<decimal> tender_value
        {
            get { return _tender_value; }
            set
            {
                if (_tender_value != value)
                {
                    _tender_value = value; RaisePropertyChanged("tender_value");
                }
            }
        }

        private Nullable<decimal> _emd_amt;
        public Nullable<decimal> emd_amt
        {
            get { return _emd_amt; }
            set
            {
                if (_emd_amt != value)
                {
                    _emd_amt = value; RaisePropertyChanged("emd_amt", ModelEntityUpdated);
                }
            }
        }

        private Nullable<bool> _emd_ex;
        public Nullable<bool> emd_ex
        {
            get { return _emd_ex; }
            set
            {
                if (_emd_ex != value)
                {
                    _emd_ex = value; RaisePropertyChanged("emd_ex");
                }
            }
        }

        private Nullable<bool> _emd_status;
        public Nullable<bool> emd_status
        {
            get { return _emd_status; }
            set
            {
                if (_emd_status != value)
                {
                    _emd_status = value; RaisePropertyChanged("emd_status");
                }
            }
        }


        private Nullable<System.DateTime> _emd_return_date;
        public Nullable<System.DateTime> emd_return_date
        {
            get { return _emd_return_date; }
            set
            {
                if (_emd_return_date != value)
                {
                    _emd_return_date = value; RaisePropertyChanged("emd_return_date");
                }
            }
        }

        private string _abg;
        public string abg
        {
            get { return _abg; }
            set
            {
                if (_abg != value)
                {
                    _abg = value; RaisePropertyChanged("abg");
                }
            }
        }


        private Nullable<decimal> _abg_amt;
        public Nullable<decimal> abg_amt
        {
            get { return _abg_amt; }
            set
            {
                if (_abg_amt != value)
                {
                    _abg_amt = value; RaisePropertyChanged("abg_amt");
                }
            }
        }

        private Nullable<System.DateTime> _abg_return_date;
        public Nullable<System.DateTime> abg_return_date
        {
            get { return _abg_return_date; }
            set
            {
                if (_abg_return_date != value)
                {
                    _abg_return_date = value; RaisePropertyChanged("abg_return_date");
                }
            }
        }

        private string _release_mode;
        public string release_mode
        {
            get { return _release_mode; }
            set
            {
                if (_release_mode != value)
                {
                    _release_mode = value; RaisePropertyChanged("release_mode");
                }
            }
        }

        private Nullable<int> _abg_days;
        public Nullable<int> abg_days
        {
            get { return _abg_days; }
            set
            {
                if (_abg_days != value)
                {
                    _abg_days = value; RaisePropertyChanged("abg_days");
                }
            }
        }

        private Nullable<bool> _abg_status;
        public Nullable<bool> abg_status
        {
            get { return _abg_status; }
            set
            {
                if (_abg_status != value)
                {
                    _abg_status = value; RaisePropertyChanged("abg_status");
                }
            }
        }


        private Nullable<decimal> _tender_form_fee;
        public Nullable<decimal> tender_form_fee
        {
            get { return _tender_form_fee; }
            set
            {
                if (_tender_form_fee != value)
                {
                    _tender_form_fee = value; RaisePropertyChanged("tender_form_fee");
                }
            }
        }


        private Nullable<decimal> _insurance;
        public Nullable<decimal> insurance
        {
            get { return _insurance; }
            set
            {
                if (_insurance != value)
                {
                    _insurance = value; RaisePropertyChanged("insurance");
                }
            }
        }


        private Nullable<decimal> _other;
        public Nullable<decimal> other
        {
            get { return _other; }
            set
            {
                if (_other != value)
                {
                    _other = value; RaisePropertyChanged("other");
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


        private string _fin_year;
        public string fin_year
        {
            get { return _fin_year; }
            set
            {
                if (_fin_year != value)
                {
                    _fin_year = value; RaisePropertyChanged("fin_year");
                }
            }
        }


        private string _posting_period;
        public string posting_period
        {
            get { return _posting_period; }
            set
            {
                if (_posting_period != value)
                {
                    _posting_period = value; RaisePropertyChanged("posting_period ");
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
                    _active = value; RaisePropertyChanged("active ");
                }
            }
        }

        private string _add_by { get; set; }
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

        private Nullable<int> _ContInfoId;
        public Nullable<int> ContInfoId
        {
            get { return _ContInfoId; }
            set
            {
                if (_ContInfoId != value)
                {
                    _ContInfoId = value; RaisePropertyChanged("ContInfoId");
                }
            }
        }

        private string _contact_per_nm;
        public string contact_per_nm
        {
            get { return _contact_per_nm; }
            set
            {
                if (_contact_per_nm != value)
                {
                    _contact_per_nm = value; RaisePropertyChanged("contact_per_nm");
                }
            }
        }

        private string _pay_mode { get; set; }
        public string pay_mode
        {
            get { return _pay_mode; }
            set
            {
                if (_pay_mode != value)
                {
                    _pay_mode = value; RaisePropertyChanged("pay_mode");
                }
            }
        }

        private string _unit_name;
        public string unit_name
        {
            get { return _unit_name; }
            set
            {
                if (_unit_name != value)
                {
                    _unit_name = value; RaisePropertyChanged("unit_name");
                }
            }
        }
        private Nullable<decimal> _emd_deduction;
        public Nullable<decimal> emd_deduction
        {
            get { return _emd_deduction; }
            set
            {
                if (_emd_deduction != value)
                {
                    _emd_deduction = value; RaisePropertyChanged("emd_deduction", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _received_amt;
        public Nullable<decimal> received_amt
        {
            get { return _received_amt; }
            set
            {
                if (_received_amt != value)
                {
                    _received_amt = value; RaisePropertyChanged("received_amt", ModelEntityUpdated);
                }
            }
        }
        private string _deduction_resn;
        public string deduction_resn
        {
            get { return _deduction_resn; }
            set
            {
                if (_deduction_resn != value)
                {
                    _deduction_resn = value; RaisePropertyChanged("deduction_resn");
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
        private string _EmpName;
        public string EmpName
        {
            get { return _EmpName; }
            set
            {
                if (_EmpName != value)
                {
                    _EmpName = value; RaisePropertyChanged("EmpName");
                }
            }
        }
        private string _LoctnNm;
        public string LoctnNm
        {
            get { return _LoctnNm; }
            set
            {
                if (_LoctnNm != value)
                {
                    _LoctnNm = value; RaisePropertyChanged("LoctnNm");
                }
            }
        }
        private string _Fltr_doc_type;
        public string Fltr_doc_type
        {
            get { return _Fltr_doc_type; }
            set
            {
                if (_Fltr_doc_type != value)
                {
                    _Fltr_doc_type = value;
                    RaisePropertyChanged("Fltr_doc_type");
                }
            }
        }
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
        public string XmlDataDocument_FlipGrid { get; set; }

    }
    public class MultipleContext_ZCRM_T004
    {
        public List<ZCRM_T004Flip> DocumentDataFlipGrid { get; set; }
        public List<ADM_M028_P> PartyMaster { get; set; }
        public List<ADM_M022_POPUP> ItemList { get; set; }
        public List<ADM_M038_B_P> UnitList { get; set; }
        public List<ADM_M028_C_P> ContactInfoMaster { get; set; }
        public List<ADM_M028_D> PartyAddress { get; set; }
        public List<ZCRM_T004> DocumentMaster { get; set; }
        public List<ACC_M021_P> PayMethodList { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<SYS_M002> DocumentTypes { get; set; }
        public List<ADM_M024_P> Sellers { get; set; }
        public List<ADM_M0013> t_statusList { get; set; }
    }
    public class ZCRM_T004Flip
    {

        public string doc_no { get; set; }
        public DateTime doc_date { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string contact_per_nm { get; set; }
        public string t_status { get; set; }
        public string tender_no { get; set; }
        public string EmpName { get; set; }
    }
    public class ADM_M022_POPUP
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string unit_code { get; set; }
        public string CatCode { get; set; }
        public bool StockUnt { get; set; }
        public string SubCatCode { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public string Grade { get; set; }
        public Nullable<decimal> para6 { get; set; }
    }

    public class ADM_M022_P1
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string unit_code { get; set; }
        public string CatCode { get; set; }
        public bool? StockUnt { get; set; }
        public string SubCatCode { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public string Grade { get; set; }
    }
}
