using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Reflection.BusinessEntity
{

    public partial class ZCRM_T004_A : ObjectBase
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

        private string _doc_no;
        [Required(ErrorMessage = "Field 'Document No' is required.")]
        [DisplayName("Doc No")]
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                if (_doc_no != value)
                {
                    _doc_no = value; RaisePropertyChanged("doc_no");
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

        private string _tender_no;
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

        private string _doc_type;
        [Required(ErrorMessage = "Field 'Document Type' is required.")]
        [DisplayName("Doc Type")]
        public string doc_type
        {
            get { return _doc_type; }
            set { _doc_type = value; RaisePropertyChanged("doc_type"); }
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
        private Nullable<System.DateTime> _doc_date;
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
            set
            {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active");
                }
            }
        }

        private Nullable<System.DateTime> _entry_date;
        public Nullable<System.DateTime> entry_date
        {
            get { return _entry_date; }
            set
            {
                if (_entry_date != value)
                {
                    _entry_date = value; RaisePropertyChanged("entry_date");
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
        private string _sub_doc_cat;
        public string sub_doc_cat
        {
            get { return _sub_doc_cat; }
            set
            {
                if (_sub_doc_cat != value)
                {
                    _sub_doc_cat = value; RaisePropertyChanged("sub_doc_cat");
                }
            }
        }

        private string _tender_doc_type;
        public string tender_doc_type
        {
            get { return _tender_doc_type; }
            set
            {
                if (_tender_doc_type != value)
                {
                    _tender_doc_type = value; RaisePropertyChanged("tender_doc_type");
                }
            }
        }

        private string _tender_doc_cat;
        public string tender_doc_cat
        {
            get { return _tender_doc_cat; }
            set
            {
                if (_tender_doc_cat != value)
                {
                    _tender_doc_cat = value; RaisePropertyChanged("tender_doc_cat");
                }
            }
        }
       
        //Scalar
        private string _cat_desc;
        public string cat_desc
        {
            get { return _cat_desc; }
            set
            {
                if (_cat_desc != value)
                {
                    _cat_desc = value; RaisePropertyChanged("cat_desc");
                }
            }
        }

        private string _sub_cat_desc;
        public string sub_cat_desc
        {
            get { return _sub_cat_desc; }
            set
            {
                if (_sub_cat_desc != value)
                {
                    _sub_cat_desc = value; RaisePropertyChanged("sub_cat_desc");
                }
            }
        }

        public string XmlDataDocument_FlipGrid { get; set; }


    }
    public class MultipleContext_ZCRM_T004_A
    {
        public List<ZCRM_T004_AFlip> DocumentDataFlipGrid { get; set; }
        public List<ZCRM_T004_P> TenderDocDetails { get; set; }
        public List<ZADM_M023_P> TenderDocCatDetails { get; set; }
        public List<ZADM_M024_P> SubDocCatDetails { get; set; }
        public List<ZCRM_T004_A> DocumentMaster { get; set; }
        public List<COM_T003> Attachment { get; set; }

    }
}
