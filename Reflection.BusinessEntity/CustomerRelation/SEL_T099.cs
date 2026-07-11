using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Reflection.BusinessEntity.CustomerRelation
{
    public partial class SEL_T099:ObjectBase  //Master
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set {
                if (_doc_no != value)
                {
                    _doc_no = value; RaisePropertyChanged("doc_no");
                }
            }
        }
        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set {
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
            set {
                if (_doc_type != value)
                {
                    _doc_type = value; RaisePropertyChanged("doc_type");
                }
            }
        }
        private Nullable<System.DateTime> _doc_date;
        public Nullable<System.DateTime> doc_date
        {
            get { return _doc_date; }
            set {
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
            set {
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
            set {
                if (_comp_code != value)
                {
                    _comp_code = value; RaisePropertyChanged("comp_code");
                }
            }
        }
        private string _PartyId;
        public string PartyId
        {
            get { return _PartyId; }
            set {
                if (_PartyId != value)
                {
                    _PartyId = value; RaisePropertyChanged("PartyId");
                }
            }

        }
        private string _fin_year;
        public string fin_year
        {
            get { return _fin_year; }
            set {
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
            set {
                if (_posting_period != value)
                {
                    _posting_period = value; RaisePropertyChanged("posting_period");
                }
            }

        }
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set {
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
            set {
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
            set {
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
            set {
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
            set {
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
            set {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active", ModelEntityUpdated);
                }
            }

        }
        
        private string _language;
        public string language
        {
            get { return _language; }
            set {
                if (_language != value)
                {
                    _language = value; RaisePropertyChanged("language");
                }
            }

        }
        
        private string _para1;
        public string para1
        {
            get { return _para1; }
            set {
                if (_para1 != value)
                {
                    _para1 = value; RaisePropertyChanged("para1");
                }
            }

        }
        private Nullable<int> _para2;
        public Nullable<int> para2
        {
            get { return _para2; }
            set {
                if (_para2 != value)
                {
                    _para2 = value; RaisePropertyChanged("para2");
                }
            }

        }
        private Nullable<decimal> _para3;
        public Nullable<decimal> para3
        {
            get { return _para3; }
            set {
                if (_para3 != value)
                {
                    _para3 = value; RaisePropertyChanged("para3", ModelEntityUpdated);
                }
            }

        }
        //scaler Fields
        private string _CustomerNm;
        public string CustomerNm
        {
            get { return _CustomerNm; }
            set {
                if (_CustomerNm != value)
                {
                    _CustomerNm = value; RaisePropertyChanged("CustomerNm");
                }
            }

        }
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
        public string XmlDataDocument_SEL_T099_A { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }
    }
    public partial class SEL_T099_A:ObjectBase  //Detail
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
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
        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set {
                if (_doc_no != value)
                {
                    _doc_no = value; RaisePropertyChanged("doc_no");
                }
            }

        }
        private string _PartyId;
        public string PartyId
        {
            get { return _PartyId; }
            set {
                if (_PartyId != value)
                {
                    _PartyId = value; RaisePropertyChanged("PartyId");
                }
            }

        }
        private string _invoice_no;
        public string invoice_no
        {
            get { return _invoice_no; }
            set {
                if (_invoice_no != value)
                {
                    _invoice_no = value; RaisePropertyChanged("invoice_no");
                }
            }

        }
        private string _ItemCode;
        public string ItemCode
        {
            get { return _ItemCode; }
            set {
                if (_ItemCode != value)
                {
                    _ItemCode = value; RaisePropertyChanged("ItemCode");
                }
            }

        }
        private string _Description;
        public string Description
        {
            get { return _Description; }
            set {
                if (_Description != value)
                {
                    _Description = value; RaisePropertyChanged("Description");
                }
            }

        }
        private Nullable<decimal> _quantity;
        public Nullable<decimal> quantity
        {
            get { return _quantity; }
            set {
                if (_quantity != value)
                {
                    _quantity = value; RaisePropertyChanged("quantity", ModelEntityUpdated);
                }
            }

        }
        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set {
                if (_unit_code != value)
                {
                    _unit_code = value; RaisePropertyChanged("unit_code");
                }
            }

        }
        private Nullable<decimal> _rate;
        public Nullable<decimal> rate
        {
            get { return _rate; }
            set {
                if (_rate != value)
                {
                    _rate = value; RaisePropertyChanged("rate", ModelEntityUpdated);
                }
            }

        }
        private Nullable<decimal> _subtotal;
        public Nullable<decimal> subtotal
        {
            get { return _subtotal; }
            set {
                if (_subtotal != value)
                {
                    _subtotal = value; RaisePropertyChanged("subtotal", ModelEntityUpdated);
                }
            }

        }
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set {
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
            set {
                if (comp_code != value)
                {
                    _comp_code = value; RaisePropertyChanged("comp_code");

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
            set {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active", ModelEntityUpdated);

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
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set {
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
            set {
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
            set {
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
            set {
                if (_edit_date != value)
                {
                    _edit_date = value; RaisePropertyChanged("edit_date");

                }
            }

        }
        
        private Nullable<decimal> _para1;
        public Nullable<decimal> para1
        {
            get { return _para1; }
            set {
                if (_para1 != value)
                {
                    _para1 = value; RaisePropertyChanged("para1");

                }
            }

        }
        private Nullable<decimal> _para2;
        public Nullable<decimal> para2
        {
            get { return _para2; }
            set {
                if (_para2 != value)
                {
                    _para2 = value; RaisePropertyChanged("para2");

                }
            }

        }
        private string _ref_doc_type;
        public string ref_doc_type
        {
            get { return _ref_doc_type; }
            set {
                if (_ref_doc_type != value)
                {
                    _ref_doc_type = value; RaisePropertyChanged("ref_doc_type");

                }
            }
        }
        private string _ref_doc_cat;
        public string ref_doc_cat
        {
            get { return _ref_doc_cat; }
            set {
                if (_ref_doc_cat != value)
                {
                    _ref_doc_cat = value; RaisePropertyChanged("ref_doc_cat");

                }
            }

        }
        private Nullable<System.DateTime> _ref_doc_date;
        public Nullable<System.DateTime> ref_doc_date
        {
            get { return _ref_doc_date; }
            set {
                if (_ref_doc_date != value)
                {
                    _ref_doc_date = value; RaisePropertyChanged("ref_doc_date");

                }
            }

        }
        
        //scaler Fields
        private string _CustomerNm;
        public string CustomerNm
        {
            get { return _CustomerNm; }
            set {
                if (_CustomerNm != value)
                {
                    _CustomerNm = value; RaisePropertyChanged("CustomerNm");

                }
            }

        }
    }

    public class MultipleContext_SEL_T099
    {
        public List<SEL_T099> MasterEntity { get; set; }
        public ObservableCollection<SEL_T099_A> ItemsEntity { get; set; }
        public List<SEL_T099_Flip> DocumentDataFlipGrid { get; set; }
        public List<ADM_M028_P> CustomerDetails { get; set; }
        public List<SEL_T003_POP> InvoiceNoDetails { get; set; }
        public List<ADM_M022_P> ItemDetails { get; set; }
        public List<ADM_M038_B_P> UomDetails { get; set; }
        public List<COM_T003> Attachment { get; set; }
    }
}
