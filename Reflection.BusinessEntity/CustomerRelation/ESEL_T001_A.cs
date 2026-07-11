using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.CustomerRelation
{
    public class ESEL_T001_A : ObjectBase
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
       
        private string _entry_no;
        public string entry_no
        {
            get { return _entry_no; }
            set
            {
                if (_entry_no != value)
                {
                    _entry_no = value; RaisePropertyChanged("entry_no");
                }
            }
        }
       
        private Nullable<System.DateTime> _entry_dt;
        public Nullable<System.DateTime> entry_dt
        {
            get { return _entry_dt; }
            set
            {
                if (_entry_dt != value)
                {
                    _entry_dt = value; RaisePropertyChanged("entry_dt");
                }
            }
        }
        
        private Nullable<int> _frm_type;
        public Nullable<int> frm_type
        {
            get { return _frm_type; }
            set
            {
                if (_frm_type != value)
                {
                    _frm_type = value; RaisePropertyChanged("frm_type");
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
       
        private string _cust_ref_no;
        public string cust_ref_no
        {
            get { return _cust_ref_no; }
            set
            {
                if (_cust_ref_no != value)
                {
                    _cust_ref_no = value; RaisePropertyChanged("cust_ref_no");
                }
            }
        }
       
        private string _serial_no;
        public string serial_no
        {
            get { return _serial_no; }
            set
            {
                if (_serial_no != value)
                {
                    _serial_no = value; RaisePropertyChanged("serial_no");
                }
            }
        }
        
        private Nullable<System.DateTime> _issue_dt;
        public Nullable<System.DateTime> issue_dt
        {
            get { return _issue_dt; }
            set
            {
                if (_issue_dt != value)
                {
                    _issue_dt = value; RaisePropertyChanged("issue_dt");
                }
            }
        }
       
        private string _period;
        public string period
        {
            get { return _period; }
            set
            {
                if (_period != value)
                {
                    _period = value; RaisePropertyChanged("period");
                }
            }
        }
        

        private Nullable<decimal> _total;
        public Nullable<decimal> total
        {
            get { return _total; }
            set
            {
                if (_total != value)
                {
                    _total = value; RaisePropertyChanged("total");
                }
            }
        }
        

        private Nullable<decimal> _total_form;
        public Nullable<decimal> total_form
        {
            get { return _total_form; }
            set
            {
                if (_total_form != value)
                {
                    _total_form = value; RaisePropertyChanged("total_form");
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
                    _posting_period = value; RaisePropertyChanged("posting_period");
                }
            }
        }

        private string _qtr;
        public string qtr
        {
            get { return _qtr; }
            set
            {
                if (_qtr != value)
                {
                    _qtr = value; RaisePropertyChanged("qtr");
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
                    _remark = value; RaisePropertyChanged("remark");
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
        
        
       
        private string _language;
        public string language
        {
            get { return _language; }
            set
            {
                if (_language != value)
                {
                    _language = value; RaisePropertyChanged("language");
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

        private string _ref_doc_type;
        public string ref_doc_type
        {
            get { return _ref_doc_type; }
            set
            {
                if (_ref_doc_type != value)
                {
                    _ref_doc_type = value; RaisePropertyChanged("ref_doc_type");
                }
            }
        }
        //Scalar
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

        private string _description;
        public string description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value; RaisePropertyChanged("description");
                }
            }
        }

        private string _PartyIdReport;
        public string PartyIdReport
        {
            get { return _PartyIdReport; }
            set
            {
                if (_PartyIdReport != value)
                {
                    _PartyIdReport = value; RaisePropertyChanged("PartyIdReport");
                }
            }
        }

        private string _PartyNmReport;
        public string PartyNmReport
        {
            get { return _PartyNmReport; }
            set
            {
                if (_PartyNmReport != value)
                {
                    _PartyNmReport = value; RaisePropertyChanged("PartyNmReport");
                }
            }
        }

        private Nullable<int> _frm_typeReport;
        public Nullable<int> frm_typeReport
        {
            get { return _frm_typeReport; }
            set
            {
                if (_frm_typeReport != value)
                {
                    _frm_typeReport = value; RaisePropertyChanged("frm_typeReport");
                }
            }
        }

        private string _descriptionReport;
        public string descriptionReport
        {
            get { return _descriptionReport; }
            set
            {
                if (_descriptionReport != value)
                {
                    _descriptionReport = value; RaisePropertyChanged("descriptionReport");
                }
            }
        }

        private string _qtrReport;
        public string qtrReport
        {
            get { return _qtrReport; }
            set
            {
                if (_qtrReport != value)
                {
                    _qtrReport = value; RaisePropertyChanged("qtrReport");
                }
            }
        }

        private string _fin_yearReport;
        public string fin_yearReport
        {
            get { return _fin_yearReport; }
            set
            {
                if (_fin_yearReport != value)
                {
                    _fin_yearReport = value; RaisePropertyChanged("fin_yearReport");
                }
            }
        }

        //XML doc 
        public string XmlDataDocument_ESEL_T001_B { get; set; }
        public string XmlDataDocument_ESEL_T001_Flip{ get; set; }

    }
    public class ESEL_T001_B : ObjectBase
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
                    _id = value; RaisePropertyChanged("id");
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
               
        private string _entry_no;
        public string entry_no
        {
            get { return _entry_no; }
            set
            {
                if (_entry_no != value)
                {
                    _entry_no = value; RaisePropertyChanged("entry_no");
                }
            }
        }
               
        private string _inv_no;
        public string inv_no
        {
            get { return _inv_no; }
            set
            {
                if (_inv_no != value)
                {
                    _inv_no = value; RaisePropertyChanged("inv_no");
                }
            }
        }
        
        private Nullable<System.DateTime> _inv_dt;
        public Nullable<System.DateTime> inv_dt
        {
            get { return _inv_dt; }
            set
            {
                if (_inv_dt != value)
                {
                    _inv_dt = value; RaisePropertyChanged("inv_dt");
                }
            }
        }
                
        private Nullable<decimal> _val_of_goods;
        public Nullable<decimal> val_of_goods
        {
            get { return _val_of_goods; }
            set
            {
                if (_val_of_goods != value)
                {
                    _val_of_goods = value; RaisePropertyChanged("val_of_goods");
                }
            }
        }
        
        private Nullable<decimal> _tax;
        public Nullable<decimal> tax
        {
            get { return _tax; }
            set
            {
                if (_tax != value)
                {
                    _tax = value; RaisePropertyChanged("tax");
                }
            }
        }
       
        private Nullable<decimal> _total;
        public Nullable<decimal> total
        {
            get { return _total; }
            set
            {
                if (_total != value)
                {
                    _total = value; RaisePropertyChanged("total", ModelEntityUpdated);
                }
            }
        }
        
        private Nullable<decimal> _total_form;
        public Nullable<decimal> total_form
        {
            get { return _total_form; }
            set
            {
                if (_total_form != value)
                {
                    _total_form = value; RaisePropertyChanged("total_form", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _total_inv_amt;
        public Nullable<decimal> total_inv_amt
        {
            get { return _total_inv_amt; }
            set
            {
                if (_total_inv_amt != value)
                {
                    _total_inv_amt = value; RaisePropertyChanged("total_inv_amt", ModelEntityUpdated);
                }
            }
        }

        private string _period;
        public string period
        {
            get { return _period; }
            set
            {
                if (_period != value)
                {
                    _period = value; RaisePropertyChanged("period");
                }
            }
        }
       
        private string _serial_no;
        public string serial_no
        {
            get { return _serial_no; }
            set
            {
                if (_serial_no != value)
                {
                    _serial_no = value; RaisePropertyChanged("serial_no");
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
                    _posting_period = value; RaisePropertyChanged("posting_period");
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
                    _remark = value; RaisePropertyChanged("remark");
                }
            }
        }
        
        private Nullable<System.DateTime> _issue_dt;
        public Nullable<System.DateTime> issue_dt
        {
            get { return _issue_dt; }
            set
            {
                if (_issue_dt != value)
                {
                    _issue_dt = value; RaisePropertyChanged("issue_dt");
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
       
        private string _language;
        public string language
        {
            get { return _language; }
            set
            {
                if (_language != value)
                {
                    _language = value; RaisePropertyChanged("language");
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

        private string _ref_doc_type;
        public string ref_doc_type
        {
            get { return _ref_doc_type; }
            set
            {
                if (_ref_doc_type != value)
                {
                    _ref_doc_type = value; RaisePropertyChanged("ref_doc_type");
                }
            }
        }

    }
    public class MultipleContext_ESEL_T001_A
    {
        public List<ESEL_T001_A_BackFlip> BackFlipEntity { get; set; }  
        public List<ESEL_T001_A> MasterData { get; set; }       
        public ObservableCollection<ESEL_T001_B> DetailData { get; set; }       
        public List<ACC_M013_P> FormType { get; set; }
        public List<SEL_T003_P> Customer { get; set; }        
        public List<ACC_M001A_P> FinYear { get; set; }
        public List<ACC_M001A_P> PostPeriod { get; set; }
        public List<SEL_T003_P> Invoice { get; set; }       
        public List<ACC_M013_P> TaxData { get; set; }
        public List<ACC_M001A_P> Quarter { get; set; }
        public List<SEL_T003_P> CustomerInReport { get; set; }
        public List<ACC_M001A_P> QuarterInReport { get; set; }
    }
    public class ESEL_T001_A_BackFlip
    {
        public string sch_no { get; set; }
        public string entry_no { get; set; }
        public string entry_dt { get; set; }
        public string frm_type { get; set; }
        public string PartyId { get; set; }
        public string PartyName { get; set; }
        public string serial_no { get; set; }
        public string post_period { get; set; }
        public string fin_year { get; set; }
        public string qtr { get; set; }

    }
}
