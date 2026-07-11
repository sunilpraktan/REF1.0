using Reflection.BusinessEntity.ADM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.HRMS
{
    public class HRM_T001 : ObjectBase
    {
        private string _requestid;
        public string requestid
        {
            get { return _requestid; }
            set
            {
                if (_requestid != value)
                {
                    _requestid = value; RaisePropertyChanged("requestid");
                }
            }
        }
        private string _request_type;
        public string request_type
        {
            get { return _request_type; }
            set
            {
                if (_request_type != value)
                {
                    _request_type = value; RaisePropertyChanged("request_type");
                }
            }
        }

        private string _sub_req_type;
        public string sub_req_type
        {
            get { return _sub_req_type; }
            set
            {
                if (_sub_req_type != value)
                {
                    _sub_req_type = value; RaisePropertyChanged("sub_req_type");
                }
            }
        }
        private string _obj_type;
        public string obj_type
        {
            get { return _obj_type; }
            set
            {
                if (_obj_type != value)
                {
                    _obj_type = value; RaisePropertyChanged("obj_type");
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
        private string _note;
        public string note
        {
            get { return _note; }
            set
            {
                if (_note != value)
                {
                    _note = value; RaisePropertyChanged("note");
                }
            }
        }
        private string _reason_code;
        public string reason_code
        {
            get { return _reason_code; }
            set
            {
                if (_reason_code != value)
                {
                    _reason_code = value; RaisePropertyChanged("reason_code");
                }
            }
        }
        private string _sub_reason_code;
        public string sub_reason_code
        {
            get { return _sub_reason_code; }
            set
            {
                if (_sub_reason_code != value)
                {
                    _sub_reason_code = value; RaisePropertyChanged("sub_reason_code");
                }
            }
        }
        private string _descript;
        public string descript
        {
            get { return _descript; }
            set
            {
                if (_descript != value)
                {
                    _descript = value; RaisePropertyChanged("descript");
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
        private string _sub_object;
        public string sub_object
        {
            get { return _sub_object; }
            set
            {
                if (_sub_object != value)
                {
                    _sub_object = value; RaisePropertyChanged("sub_object");
                }
            }
        }
        private string _reff_request_id;
        public string reff_request_id
        {
            get { return _reff_request_id; }
            set
            {
                if (_reff_request_id != value)
                {
                    _reff_request_id = value; RaisePropertyChanged("reff_request_id");
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
        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                if (_lang_key != value)
                {
                    _lang_key = value; RaisePropertyChanged("lang_key");
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
                    _remark = value;
                    RaisePropertyChanged("remark");
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
       
        //Scalar Fields

        private string _req_type_desc;
        public string req_type_desc
        {
            get { return _req_type_desc; }
            set
            {
                if (_req_type_desc != value)
                {
                    _req_type_desc = value;
                    RaisePropertyChanged("req_type_desc");
                }
            }
        }
        private string _sub_req_desc;
        public string sub_req_desc
        {
            get { return _sub_req_desc; }
            set
            {
                if (_sub_req_desc != value)
                {
                    _sub_req_desc = value;
                    RaisePropertyChanged("sub_req_desc");
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
        private string _t_name;
        public string t_name
        {
            get { return _t_name; }
            set
            {
                if (_t_name != value)
                {
                    _t_name = value;
                    RaisePropertyChanged("t_name");
                }
            }
        }
        private string _reason_type;
        public string reason_type
        {
            get { return _reason_type; }
            set
            {
                if (_reason_type != value)
                {
                    _reason_type = value;
                    RaisePropertyChanged("reason_type");
                }
            }
        }
        private string _doc_type_name;
        public string doc_type_name
        {
            get { return _doc_type_name; }
            set
            {
                if (_doc_type_name != value)
                {
                    _doc_type_name = value;
                    RaisePropertyChanged("doc_type_name");
                }
            }
        }
        private string _cat_name;
        public string cat_name
        {
            get { return _cat_name; }
            set
            {
                if (_cat_name != value)
                {
                    _cat_name = value;
                    RaisePropertyChanged("cat_name");
                }
            }
        }
        private string _sub_reason_type;
        public string sub_reason_type
        {
            get { return _sub_reason_type; }
            set
            {
                if (_sub_reason_type != value)
                {
                    _sub_reason_type = value;
                    RaisePropertyChanged("sub_reason_type");
                }
            }
        }
        private string _obj_type_desc;
        public string obj_type_desc
        {
            get { return _obj_type_desc; }
            set
            {
                if (_obj_type_desc != value)
                {
                    _obj_type_desc = value;
                    RaisePropertyChanged("obj_type_desc");
                }
            }
        }

        public string XmlDataDocument_HRM_T001_A { get; set; }
        public string XmlDataDocument_HRM_T001_Flip { get; set; }
    }
    public class HRM_T001_A : ObjectBase
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
        private string _requestid;
        public string requestid
        {
            get { return _requestid; }
            set
            {
                if (_requestid != value)
                {
                    _requestid = value; RaisePropertyChanged("requestid");
                }
            }
        }
        private string _day_code;
        public string day_code
        {
            get { return _day_code; }
            set
            {
                if (_day_code != value)
                {
                    _day_code = value; RaisePropertyChanged("day_code");
                }
            }
        }

        private string _leave_code;
        public string leave_code
        {
            get { return _leave_code; }
            set
            {
                if (_leave_code != value)
                {
                    _leave_code = value; RaisePropertyChanged("leave_code");
                }
            }
        }
        private string _no_of_days;
        public string no_of_days
        {
            get { return _no_of_days; }
            set
            {
                if (_no_of_days != value)
                {
                    _no_of_days = value; RaisePropertyChanged("no_of_days");
                }
            }
        }
        private string _no_of_hours;
        public string no_of_hours
        {
            get { return _no_of_hours; }
            set
            {
                if (_no_of_hours != value)
                {
                    _no_of_hours = value; RaisePropertyChanged("no_of_hours");
                }
            }
        }
        private string _payroll_days;
        public string payroll_days
        {
            get { return _payroll_days; }
            set
            {
                if (_payroll_days != value)
                {
                    _payroll_days = value; RaisePropertyChanged("payroll_days");
                }
            }
        }
        private string _payroll_hours;
        public string payroll_hours
        {
            get { return _payroll_hours; }
            set
            {
                if (_payroll_hours != value)
                {
                    _payroll_hours = value; RaisePropertyChanged("payroll_hours");
                }
            }
        }
        private Nullable<System.DateTime> _appl_date;
        public Nullable<System.DateTime> appl_date
        {
            get { return _appl_date; }
            set
            {
                if (_appl_date != value)
                {
                    _appl_date = value; RaisePropertyChanged("appl_date");
                }
            }
        }
        private Nullable<System.DateTime> _date_from;
        public Nullable<System.DateTime> date_from
        {
            get { return _date_from; }
            set
            {
                if (_date_from != value)
                {
                    _date_from = value; RaisePropertyChanged("date_from");
                }
            }
        }
        private Nullable<System.DateTime> _date_to;
        public Nullable<System.DateTime> date_to
        {
            get { return _date_to; }
            set
            {
                if (_date_to != value)
                {
                    _date_to = value; RaisePropertyChanged("date_to");
                }
            }
        }
        private string _request_type;
        public string request_type
        {
            get { return _request_type; }
            set
            {
                if (_request_type != value)
                {
                    _request_type = value; RaisePropertyChanged("request_type");
                }
            }
        }
        private string _sub_req_type;
        public string sub_req_type
        {
            get { return _sub_req_type; }
            set
            {
                if (_sub_req_type != value)
                {
                    _sub_req_type = value; RaisePropertyChanged("sub_req_type");
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
        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                if (_lang_key != value)
                {
                    _lang_key = value; RaisePropertyChanged("lang_key");
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
                    _remark = value;
                    RaisePropertyChanged("remark");
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
       
        //Scalar Fields

        private string _request_name;
        public string request_name
        {
            get { return _request_name; }
            set
            {
                if (_request_name != value)
                {
                    _request_name = value;
                    RaisePropertyChanged("request_name");
                }
            }
        }
        private string _sub_req_name;
        public string sub_req_name
        {
            get { return _sub_req_name; }
            set
            {
                if (_sub_req_name != value)
                {
                    _sub_req_name = value;
                    RaisePropertyChanged("sub_req_name");
                }
            }
        }
        private string _day_type;
        public string day_type
        {
            get { return _day_type; }
            set
            {
                if (_day_type != value)
                {
                    _day_type = value;
                    RaisePropertyChanged("day_type");
                }
            }
        }
        private string _req_type_desc;
        public string req_type_desc
        {
            get { return _req_type_desc; }
            set
            {
                if (_req_type_desc != value)
                {
                    _req_type_desc = value;
                    RaisePropertyChanged("req_type_desc");
                }
            }
        }
        private string _sub_req_desc;
        public string sub_req_desc
        {
            get { return _sub_req_desc; }
            set
            {
                if (_sub_req_desc != value)
                {
                    _sub_req_desc = value;
                    RaisePropertyChanged("sub_req_desc");
                }
            }
        }
    }
    public class HRM_T001_B : ObjectBase
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
        private string _requestid;
        public string requestid
        {
            get { return _requestid; }
            set
            {
                if (_requestid != value)
                {
                    _requestid = value; RaisePropertyChanged("requestid");
                }
            }
        }
        private string _request_type;
        public string request_type
        {
            get { return _request_type; }
            set
            {
                if (_request_type != value)
                {
                    _request_type = value; RaisePropertyChanged("request_type");
                }
            }
        }
        private Nullable<System.DateTime> _date_from;
        public Nullable<System.DateTime> date_from
        {
            get { return _date_from; }
            set
            {
                if (_date_from != value)
                {
                    _date_from = value; RaisePropertyChanged("date_from");
                }
            }
        }
        private Nullable<System.DateTime> _date_to;
        public Nullable<System.DateTime> date_to
        {
            get { return _date_to; }
            set
            {
                if (_date_to != value)
                {
                    _date_to = value; RaisePropertyChanged("date_to");
                }
            }
        }
        private string _no_of_days;
        public string no_of_days
        {
            get { return _no_of_days; }
            set
            {
                if (_no_of_days != value)
                {
                    _no_of_days = value; RaisePropertyChanged("no_of_days");
                }
            }
        }
        private string _start_date;
        public string start_date
        {
            get { return _start_date; }
            set
            {
                if (_start_date != value)
                {
                    _start_date = value; RaisePropertyChanged("start_date");
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
        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                if (_lang_key != value)
                {
                    _lang_key = value; RaisePropertyChanged("lang_key");
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
                    _remark = value;
                    RaisePropertyChanged("remark");
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
        
    }
    public class HRM_T001_BackFlip
    {
        public string requestid { get; set; }
        public string request_type { get; set; }
        public string req_type_desc { get; set; }
        public string obj_type { get; set; }
        public string t_name { get; set; }
    }
    public class MultipleContext_HRM_T001
    {
        public ObservableCollection<HRM_T001> RequestList { get; set; }
        public ObservableCollection<HRM_T001_A> DetailList { get; set; }
        //public ObservableCollection<HRM_T001_B> HistoryList { get; set; }
        public List<HRM_T001_BackFlip> BackFlipEntity { get; set; }
        public List<HRM_M009_P> ReasonList { get; set; }
        public List<HRM_M009_A_P> SubReasonList { get; set; }
        public List<SYS_M022_P> DocTypeList { get; set; }
        public List<SYS_M021_P> DocCategoryList { get; set; }     
        public List<HRM_M008_P> RequestTypeList { get; set; }
        public List<HRM_M008_A_P> SubRequestList { get; set; }
        public List<ADM_M0013> StatusList { get; set; }
        public List<SYS_M033_P> DayTypeList { get; set; }
        public List<SYS_M034_P> ObjectTypeList { get; set; }
    }
}
