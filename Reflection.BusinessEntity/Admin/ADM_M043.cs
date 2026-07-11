using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity
{
    public class ADM_M043 : ObjectBase
    {
        private string _workflow_id;
        public string workflow_id
        {
            get { return _workflow_id; }
            set { _workflow_id = value; RaisePropertyChanged("workflow_id"); }
        }
        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set { _doc_type = value;RaisePropertyChanged("doc_type"); }
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

        private string _transaction_id;
        public string transaction_id
        {
            get { return _transaction_id; }
            set { _transaction_id = value; RaisePropertyChanged("transaction_id"); }
        }

        private Nullable<System.DateTime> _create_date;
        public Nullable<System.DateTime> create_date
        {
            get { return _create_date; }
            set { _create_date = value; RaisePropertyChanged("create_date"); }
        }

        private bool _active;
        public bool active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
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
        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set { _doc_cat = value; RaisePropertyChanged("doc_cat"); }
        }
        private string _ref_doc_cat;
        public string ref_doc_cat
        {
            get { return _ref_doc_cat; }
            set { _ref_doc_cat = value; RaisePropertyChanged("ref_doc_cat"); }
        }

        private string _ref_doc_type;
        public string ref_doc_type
        {
            get { return _ref_doc_type; }
            set { _ref_doc_type = value; RaisePropertyChanged("ref_doc_type"); }
        }
        
        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set { _lang_key = value; RaisePropertyChanged("lang_key"); }
        }
        //scalar
        private string _LoctnNm;
        public string LoctnNm
        {
            get { return _LoctnNm; }
            set { _LoctnNm = value; RaisePropertyChanged("LoctnNm"); }
        }

        private string _CompName;
        public string CompName
        {
            get { return _CompName; }
            set { _CompName = value; RaisePropertyChanged("CompName"); }
        }

        private string _TranName;
        public string TranName
        {
            get { return _TranName; }
            set { _TranName = value; RaisePropertyChanged("TranName"); }
        }

        //XML
        public string XmlDataDocument_ADM_M043_A { get; set; }
    }

    public class ADM_M043_A : ObjectBase
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }

        private string _workflow_id;
        public string workflow_id
        {
            get { return _workflow_id; }
            set { _workflow_id = value; RaisePropertyChanged("workflow_id"); }
        }

        private int _level_no;
        public int level_no
        {
            get { return _level_no; }
            set { _level_no = value; RaisePropertyChanged("level_no"); }
        }

        private string _approver_id;
        public string approver_id
        {
            get { return _approver_id; }
            set { _approver_id = value; RaisePropertyChanged("approver_id"); }
        }

        private string _UserId;
        public string UserId
        {
            get { return _UserId; }
            set { _UserId = value; RaisePropertyChanged("UserId"); }
        }

        private string _authority;      
        public string authority
        {
            get { return _authority; }
            set { _authority = value; RaisePropertyChanged("authority"); }
        }

        private string _access_field;
        public string access_field
        {
            get { return _access_field; }
            set { _access_field = value; RaisePropertyChanged("access_field"); }
        }

        private decimal _field_value;
        public decimal field_value
        {
            get { return _field_value; }
            set { _field_value = value; RaisePropertyChanged("field_value"); }
        }

        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code"); }
        }

        private string _roperator;
        public string roperator
        {
            get { return _roperator; }
            set { _roperator = value; RaisePropertyChanged("roperator"); }
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
       
        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set { _lang_key = value; RaisePropertyChanged("lang_key"); }
        }

        //scalar
        private string _approvernm;
        public string approvernm
        {
            get { return _approvernm; }
            set { _approvernm = value; RaisePropertyChanged("approvernm"); }
        }

        private string _unit_name;
        public string unit_name
        {
            get { return _unit_name; }
            set { _unit_name = value; RaisePropertyChanged("unit_name"); }
        }
        private string _authorise_location;
        public string authorise_location
        {
            get { return _authorise_location; }
            set { _authorise_location = value; RaisePropertyChanged("authorise_location"); }
        }
        private string _authorise_comp;
        public string authorise_comp
        {
            get { return _authorise_comp; }
            set { _authorise_comp = value; RaisePropertyChanged("authorise_comp"); }
        }
        private string _authorise_locNm;
        public string authorise_locNm
        {
            get { return _authorise_locNm; }
            set { _authorise_locNm = value; RaisePropertyChanged("authorise_locNm"); }
        }
        private string _authorise_compNm;
        public string authorise_compNm
        {
            get { return _authorise_compNm; }
            set { _authorise_compNm = value; RaisePropertyChanged("authorise_compNm"); }
        }

        private string _dept_code;
        public string dept_code
        {
            get { return _dept_code; }
            set { _dept_code = value; RaisePropertyChanged("dept_code"); }
        }

        private string _org_code;
        public string org_code
        {
            get { return _org_code; }
            set { _org_code = value; RaisePropertyChanged("org_code"); }
        }
    }

    public class MultipleContext_ADM_M043
    {
        public List<ADM_M002_P> companylist { get; set; }
        public List<ADM_M003_P> plantlist { get; set; }
        public List<ADM_M008B_P> transactionlist { get; set; }
        public List<SYS_M001_P> categorymaster { get; set; }
        public List<SYS_M002_P> categoryTypemaster { get; set; }
        public List<ADM_M024_P> employeelist { get; set; }
        public List<ADM_M038_B_P> uomlist { get; set; }
        public List<ADM_M043> workflowlist { get; set; }
        public ObservableCollection<ADM_M043_A> detailslist { get; set; }
        public List<NotificationData> NotificationData { get; set; }
        public List<ADM_M025_P> Departments { get; set; }
        public List<ORG_Data> OrgData { get; set; }


    }
}
