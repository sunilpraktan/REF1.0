using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity
{

    public partial class CRM_T004 : ObjectBase
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
                    _doc_cat = value; RaisePropertyChanged("doc_cat", ModelEntityUpdated);
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
                    _doc_type = value; RaisePropertyChanged("doc_type", ModelEntityUpdated);
                }
            }
        }
        private System.DateTime _doc_date;
        public System.DateTime doc_date
        {
            get { return _doc_date; }
            set
            {
                if (_doc_date != value)
                {
                    _doc_date = value; RaisePropertyChanged("doc_date", ModelEntityUpdated);
                }
            }
        }
        private Nullable<System.DateTime> _clouser_date;
        public Nullable<System.DateTime> clouser_date
        {
            get { return _clouser_date; }
            set
            {
                if (_clouser_date != value)
                {
                    _clouser_date = value; RaisePropertyChanged("clouser_date", ModelEntityUpdated);
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
                    _EmpId = value; RaisePropertyChanged("EmpId", ModelEntityUpdated);
                }
            }
        }

        private string _EmpName;//scalar field
        public string EmpName
        {
            get { return _EmpName; }
            set
            {
                if (_EmpName != value)
                {
                    _EmpName = value; RaisePropertyChanged("EmpName", ModelEntityUpdated);
                }
            }
        }

        private string _monthyear;//scaler field
        public string monthyear
        {
            get { return _monthyear; }
            set
            {
                if (_monthyear != value)
                {
                    _monthyear = value; RaisePropertyChanged("monthyear", ModelEntityUpdated);
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
                    _comp_code = value; RaisePropertyChanged("comp_code", ModelEntityUpdated);
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
                    _location_Id = value; RaisePropertyChanged("location_Id", ModelEntityUpdated);
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
                    _language = value; RaisePropertyChanged("language", ModelEntityUpdated);
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
                    _active = value; RaisePropertyChanged("active", ModelEntityUpdated);
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
                    _t_status = value; RaisePropertyChanged("t_status", ModelEntityUpdated);
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
                    _add_by = value; RaisePropertyChanged("add_by", ModelEntityUpdated);
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
                    _add_date = value; RaisePropertyChanged("add_date", ModelEntityUpdated);
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
                    _editby = value; RaisePropertyChanged("editby", ModelEntityUpdated);
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
                    _edit_date = value; RaisePropertyChanged("edit_date", ModelEntityUpdated);
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
                    _fin_year = value; RaisePropertyChanged("fin_year", ModelEntityUpdated);
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
                    _posting_period = value; RaisePropertyChanged("posting_period", ModelEntityUpdated);
                }
            }
        }
        
        private string _month;
        public string month
        {
            get { return _month; }
            set
            {
                if (_month != value)
                {
                    _month = value; RaisePropertyChanged("month", ModelEntityUpdated);
                }
            }
        }
        private string _year;
        public string year
        {
            get { return _year; }
            set
            {
                if (_year != value)
                {
                    _year = value; RaisePropertyChanged("year", ModelEntityUpdated);
                }
            }
        }
        private string _plant;
        public string plant
        {
            get { return _plant; }
            set
            {
                if (_plant != value)
                {
                    _plant = value; RaisePropertyChanged("plant", ModelEntityUpdated);
                }
            }
        }
        private string _company;
        public string company
        {
            get { return _company; }
            set
            {
                if (_company != value)
                {
                    _company = value; RaisePropertyChanged("company", ModelEntityUpdated);
                }
            }
        }
        private string _CompanyNm;
        public string CompanyNm
        {
            get { return _CompanyNm; }
            set
            {
                if (_CompanyNm != value)
                {
                    _CompanyNm = value; RaisePropertyChanged("CompanyNm", ModelEntityUpdated);
                }
            }
        }

        private string _LocationNm;
        public string LocationNm
        {
            get { return _LocationNm; }
            set
            {
                if (_LocationNm != value)
                {
                    _LocationNm = value; RaisePropertyChanged("LocationNm", ModelEntityUpdated);
                }
            }
        }

        private string _sg_code;
        public string sg_code
        {
            get { return _sg_code; }
            set
            {
                if (_sg_code != value)
                {
                    sg_code = value;
                    RaisePropertyChanged("sg_code");
                }
            }
        }

        private string _sales_org;
        public string sales_org
        {
            get { return _sales_org; }
            set
            {
                if (_sales_org != value)
                {
                    _sales_org = value;
                    RaisePropertyChanged("sales_org");
                }
            }
        }

        private string _so_code;
        public string so_code
        {
            get { return _so_code; }
            set
            {
                if (_so_code != value)
                {
                    _so_code = value;
                    RaisePropertyChanged("so_code");
                }
            }
        }


        private string _sg_name;
        public string sg_name
        {
            get { return _sg_name; }
            set
            {
                if (_sg_name != value)
                {
                    _sg_name = value;
                    RaisePropertyChanged("sg_name");
                }
            }
        }

        public string XmlDataDocument_CRM_T004_A { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }

    }

    public partial class CRM_T004_A : ObjectBase
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
                    _id = value; RaisePropertyChanged("id", ModelEntityUpdated);
                }
            }
        }
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
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                if (_comp_code != value)
                {
                    _comp_code = value; RaisePropertyChanged("comp_code", ModelEntityUpdated);
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
                    _location_Id = value; RaisePropertyChanged("location_Id", ModelEntityUpdated);
                }
            }
        }
        private string _week_no;
        public string week_no
        {
            get { return _week_no; }
            set
            {
                if (_week_no != value)
                {
                    _week_no = value; RaisePropertyChanged("week_no", ModelEntityUpdated);
                }
            }
        }
        private Nullable<System.DateTime> _week_date;
        public Nullable<System.DateTime> week_date
        {
            get { return _week_date; }
            set
            {
                if (_week_date != value)
                {
                    _week_date = value; RaisePropertyChanged("week_date", ModelEntityUpdated);
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
                    _PartyId = value; RaisePropertyChanged("PartyId", ModelEntityUpdated);
                }
            }
        }
        private string _PartyNm;//scaler field
        public string PartyNm
        {
            get { return _PartyNm; }
            set
            {
                if (_PartyNm != value)
                {
                    _PartyNm = value; RaisePropertyChanged("PartyNm", ModelEntityUpdated);
                }
            }
        }
        private string _PartyType;
        public string PartyType
        {
            get { return _PartyType; }
            set
            {
                if (_PartyType != value)
                {
                    _PartyType = value; RaisePropertyChanged("PartyType", ModelEntityUpdated);
                }
            }
        }
        private string _project_name { get; set; }
        public string project_name
        {
            get { return _project_name; }
            set
            {
                if (_project_name != value)
                {
                    _project_name = value; RaisePropertyChanged("project_name", ModelEntityUpdated);
                }
            }
        }
        private string _site_location;
        public string site_location
        {
            get { return _site_location; }
            set
            {
                if (_site_location != value)
                {
                    _site_location = value; RaisePropertyChanged("site_location", ModelEntityUpdated);
                }
            }
        }
        private Nullable<System.DateTime> _project_date;
        public Nullable<System.DateTime> project_date
        {
            get { return _project_date; }
            set
            {
                if (_project_date != value)
                {
                    _project_date = value; RaisePropertyChanged("project_date", ModelEntityUpdated);
                }
            }
        }
             
        private Nullable<decimal> _value1;
        public Nullable<decimal> value1
        {
            get { return _value1; }
            set
            {
                if (_value1 != value)
                {
                    _value1 = value; RaisePropertyChanged("value1", ModelEntityUpdated);
                }
            }
        }
             
        private string _value2;
        public string value2
        {
            get { return _value2; }
            set
            {
                if (_value2 != value)
                {
                    _value2 = value; RaisePropertyChanged("value2", ModelEntityUpdated);
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
                    _unit_code = value; RaisePropertyChanged("unit_code", ModelEntityUpdated);
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
                    _qty = value; RaisePropertyChanged("qty", ModelEntityUpdated);
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
                    _t_status = value; RaisePropertyChanged("t_status", ModelEntityUpdated);
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
                    _remark = value; RaisePropertyChanged("remark", ModelEntityUpdated);
                }
            }
        } 
        private int _prevoius;
        public int prevoius
        {
            get { return _prevoius; }
            set
            {
                if (_prevoius != value)
                {
                    _prevoius = value; RaisePropertyChanged("prevoius", ModelEntityUpdated);
                }
            }
        } 
        private int _first;
        public int first
        {
            get { return _first; }
            set
            {
                if (_first != value)
                {
                    _first = value; RaisePropertyChanged("first", ModelEntityUpdated);
                }
            }
        } 
        private string _parent_no;
        public string parent_no
        {
            get { return _parent_no; }
            set
            {
                if (_parent_no != value)
                {
                    _parent_no = value; RaisePropertyChanged("parent_no", ModelEntityUpdated);
                }
            }
        }
                
        private Nullable<decimal> _area;
        public Nullable<decimal> area
        {
            get { return _area; }
            set
            {
                if (_area != value)
                {
                    _area = value; RaisePropertyChanged("area", ModelEntityUpdated);
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
                    _add_by = value; RaisePropertyChanged("add_by", ModelEntityUpdated);
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
                    add_date = value; RaisePropertyChanged("add_date", ModelEntityUpdated);
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
                    _editby = value; RaisePropertyChanged("editby", ModelEntityUpdated);
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
                    _edit_date = value; RaisePropertyChanged("edit_date", ModelEntityUpdated);
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

                    _active = value; RaisePropertyChanged("active", ModelEntityUpdated);
                }
            }
        }
        
        private string _para1;
        public string para1
        {
            get { return _para1; }
            set
            {
                if (_para1 != value)
                {
                    _para1 = value; RaisePropertyChanged("para1", ModelEntityUpdated);
                }
            }
        }
        private string _para2;
        public string para2
        {
            get { return _para2; }
            set
            {
                if (_para2 != value)
                {
                    _para2 = value; RaisePropertyChanged("para2", ModelEntityUpdated);
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
                    _fin_year = value; RaisePropertyChanged("fin_year", ModelEntityUpdated);
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
                    _posting_period = value; RaisePropertyChanged("posting_period", ModelEntityUpdated);
                }
            }
        } 
        private string _month;
        public string month
        {
            get { return _month; }
            set
            {
                if (_month != value)
                {
                    _month = value; RaisePropertyChanged("month", ModelEntityUpdated);
                }
            }
        } 
        private string _year;
        public string year
        {
            get { return _year; }
            set
            {
                if (_year != value)
                {
                    _year = value; RaisePropertyChanged("year", ModelEntityUpdated);
                }
            }
        } 
        //scaler Fields
        private string _amt_in_words;
        public string amt_in_words
        {
            get { return _amt_in_words; }
            set
            {
                if (_amt_in_words != value)
                {
                    _amt_in_words = value;
                    RaisePropertyChanged("amt_in_words", ModelEntityUpdated);
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
                    _ref_doc_type = value;
                    RaisePropertyChanged("ref_doc_type");
                }

            }
        }
               
        private string _ref_doc_cat;
        public string ref_doc_cat
        {
            get { return _ref_doc_cat; }
            set
            {
                if (_ref_doc_cat != value)
                {
                    _ref_doc_cat = value;
                    RaisePropertyChanged("ref_doc_cat");
                }

            }
        }
                

        private Nullable<System.DateTime> _ref_doc_date;
        public Nullable<System.DateTime> ref_doc_date
        {
            get { return _ref_doc_date; }
            set
            {
                if (_ref_doc_date != value)
                {
                    _ref_doc_date = value;
                    RaisePropertyChanged("ref_doc_date");
                }
            }
        }
                
        private string _ref_doc_no;
        public string ref_doc_no
        {
            get { return _ref_doc_no; }
            set
            {
                if (_ref_doc_no != value)
                {
                    _ref_doc_no = value;
                    RaisePropertyChanged("ref_doc_no");
                }

            }
        }
                

    }
    public class MultipleContext_CRM_T004
    {
        public List<CRM_T004> MasterEntity { get; set; }
        public ObservableCollection<CRM_T004_A> ItemsEntity { get; set; }
        public List<CRM_T004_Flip> DocumentDataFlipGrid { get; set; }
        public List<SEL_T003_POP> PartyDetails { get; set; }
        public List<ADM_M024_POP> EmpDetails { get; set; }
        public List<ACC_M001A_P> MonthAndYear { get; set; }
        public List<ADM_M028_B_P> PartyType { get; set; }
        public List<ADM_M003_P> LocationDetails { get; set; }
        public List<ADM_M002_P> CompanyDetails { get; set; }
        public List<ADM_M038_B_P> UomDetails { get; set; }
        public List<ADM_M001_A_P> SalesOrg { get; set; }
        public List<ADM_M001_H_P> SalesGroup { get; set; }
        public List<COM_T003> Attachment { get; set; }
    }


}
