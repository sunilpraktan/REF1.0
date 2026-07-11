using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Reflection.BusinessEntity.ProjectManagement
{
    public class PRO_T001 : ObjectBase
    {
        private string _project_id;
        public string project_id
        {
            get { return _project_id; }
            set
            {
                if (_project_id != value)
                {
                    _project_id = value; RaisePropertyChanged("project_id");
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

        private System.DateTime _doc_date;
        [Required(ErrorMessage = "Field 'Document Date' is required.")]
        public System.DateTime doc_date
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


        private bool _use_tasks;
        public bool use_tasks
        {
            get { return _use_tasks; }
            set
            {
                if (_use_tasks = value)
                {
                    _use_tasks = value; RaisePropertyChanged("use_tasks");
                }
            }
        }

        private bool _use_timesheet;
        public bool use_timesheet
        {
            get { return _use_timesheet; }
            set
            {
                if (_use_timesheet = value)
                {
                    _use_timesheet = value; RaisePropertyChanged("use_timesheet");
                }
            }
        }


        private bool _use_issue;
        public bool use_issue
        {
            get { return _use_issue; }
            set
            {
                if (_use_issue != value)
                {
                    _use_issue = value; RaisePropertyChanged("use_issue");
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
                    _ref_doc_no = value; RaisePropertyChanged("ref_doc_no");
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


        private string _ref_doc_cat;
        public string ref_doc_cat
        {
            get { return _ref_doc_cat; }
            set
            {
                if (_ref_doc_cat != value)
                {
                    _ref_doc_cat = value; RaisePropertyChanged("ref_doc_cat");
                }
            }
        }


        private string _work_order;
        public string work_order
        {
            get { return _work_order; }
            set
            {
                if (_work_order != value)
                {
                    _work_order = value; RaisePropertyChanged("work_order");
                }
            }
        }


        private string _pcode_1;
        public string pcode_1
        {
            get { return _pcode_1; }
            set
            {
                if (_pcode_1 != value)
                {
                    _pcode_1 = value; RaisePropertyChanged("pcode_1");
                }
            }
        }


        private string _pcode_2;
        public string pcode_2
        {
            get { return _pcode_2; }
            set
            {
                if (_pcode_2 != value)
                {
                    _pcode_2 = value; RaisePropertyChanged("pcode_2");
                }
            }
        }

        private string _project_name;
        [Required(ErrorMessage = "Field 'Project Name' is required.")]
        public string project_name
        {
            get { return _project_name; }
            set
            {
                if (_project_name != value)
                {
                    _project_name = value; RaisePropertyChanged("project_name");
                }
            }
        }


        private string _project_manager;
        [Required(ErrorMessage = "Field 'Project Manager' is required.")]
        public string project_manager
        {
            get { return _project_manager; }
            set
            {
                if (_project_manager != value)
                {
                    _project_manager = value; RaisePropertyChanged("project_manager");
                }
            }
        }

        private Nullable<int> _alias_id;
        public Nullable<int> alias_id
        {
            get { return _alias_id; }
            set
            {
                if (_alias_id != value)
                {
                    _alias_id = value; RaisePropertyChanged("alias_id");
                }
            }
        }

        private string _alias_model;
        public string alias_model
        {
            get { return _alias_model; }
            set
            {
                if (_alias_model != value)
                {
                    _alias_model = value; RaisePropertyChanged("alias_model");
                }
            }
        }

        private string _privacy_visibility;
        public string privacy_visibility
        {
            get { return _privacy_visibility; }
            set
            {
                if (_privacy_visibility != value)
                {
                    _privacy_visibility = value; RaisePropertyChanged("privacy_visibility");
                }
            }
        }


        private bool _active;
        public bool active
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


        private string _priority;
        public string priority
        {
            get { return _priority; }
            set
            {
                if (_priority != value)
                {
                    _priority = value; RaisePropertyChanged("priority");
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


        private Nullable<System.DateTime> _start_date;
        [Required(ErrorMessage = "Field 'Schedule Start Date' is required.")]
        public Nullable<System.DateTime> start_date
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


        private Nullable<System.DateTime> _actual_start;
        public Nullable<System.DateTime> actual_start
        {
            get { return _actual_start; }
            set
            {
                if (_actual_start != value)
                {
                    _actual_start = value; RaisePropertyChanged("actual_start");
                }
            }
        }


        private Nullable<System.DateTime> _dead_date;
        [Required(ErrorMessage = "Field 'Deadline Date' is required.")]
        public Nullable<System.DateTime> dead_date
        {
            get { return _dead_date; }
            set
            {
                if (_dead_date != value)
                {
                    _dead_date = value; RaisePropertyChanged("dead_date");
                }
            }
        }


        private Nullable<System.DateTime> _actual_end;
        public Nullable<System.DateTime> actual_end
        {
            get { return _actual_end; }
            set
            {
                if (_actual_end != value)
                {
                    _actual_end = value; RaisePropertyChanged("actual_end");
                }
            }
        }


        private Nullable<decimal> _planned_hours;
        public Nullable<decimal> planned_hours
        {
            get { return _planned_hours; }
            set
            {
                if (_planned_hours != value)
                {
                    _planned_hours = value; RaisePropertyChanged("planned_hours");
                }
            }
        }

        private Nullable<decimal> _hours_spent;
        public Nullable<decimal> hours_spent
        {
            get { return _hours_spent; }
            set
            {
                if (_hours_spent != value)
                {
                    _hours_spent = value; RaisePropertyChanged("hours_spent");
                }
            }
        }

        private Nullable<decimal> _rem_hours;
        public Nullable<decimal> rem_hours
        {
            get { return _rem_hours; }
            set
            {
                if (_rem_hours != value)
                {
                    _rem_hours = value; RaisePropertyChanged("rem_hours");
                }
            }
        }


        private Nullable<decimal> _total_hours;
        public Nullable<decimal> total_hours
        {
            get { return _total_hours; }
            set
            {
                if (_total_hours != value)
                {
                    _total_hours = value; RaisePropertyChanged("total_hours");
                }
            }
        }

        private Nullable<decimal> _work_hours_day;
        public Nullable<decimal> work_hours_day
        {
            get { return _work_hours_day; }
            set
            {
                if (_work_hours_day != value)
                {
                    _work_hours_day = value; RaisePropertyChanged("work_hours_day");
                }
            }
        }


        private Nullable<decimal> _progress_rate;
        public Nullable<decimal> progress_rate
        {
            get { return _progress_rate; }
            set
            {
                if (_progress_rate != value)
                {
                    _progress_rate = value; RaisePropertyChanged("progress_rate");
                }
            }
        }

        private Nullable<int> _analytic_accid;
        public Nullable<int> analytic_accid
        {
            get { return _analytic_accid; }
            set
            {
                if (_analytic_accid != value)
                {
                    _analytic_accid = value; RaisePropertyChanged("analytic_accid");
                }
            }
        }

        private string _customer_id;
        [Required(ErrorMessage = "Field 'Customer' is required.")]
        public string customer_id
        {
            get { return _customer_id; }
            set
            {
                if (_customer_id != value)
                {
                    _customer_id = value; RaisePropertyChanged("customer_id");
                }
            }
        }


        private string _location_Id;
        [Required(ErrorMessage = "Field 'Location(Plant)' is required.")]
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

        private string _po_no;
        public string po_no
        {
            get { return _po_no; }
            set
            {
                if (_po_no != value)
                {
                    _po_no = value; RaisePropertyChanged("po_no");
                }
            }
        }

        private Nullable<decimal> _b_amt;
        public Nullable<decimal> b_amt
        {
            get { return _b_amt; }
            set
            {
                if (_b_amt != value)
                {
                    _b_amt = value; RaisePropertyChanged("b_amt");
                }
            }
        }


        private Nullable<int> _color;
        public Nullable<int> color
        {
            get { return _color; }
            set
            {
                if (_color != value)
                {
                    _color = value; RaisePropertyChanged("color");
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

        private bool? _use_appchecklist;
        public bool? use_appchecklist
        {
            get { return _use_appchecklist; }
            set
            {
                if (_use_appchecklist != value)
                {
                    _use_appchecklist = value; RaisePropertyChanged("use_appchecklist");
                }
            }
        }


        private string _status_remark;
        public string status_remark
        {
            get { return _status_remark; }
            set
            {
                if (_status_remark != value)
                {
                    _status_remark = value; RaisePropertyChanged("status_remark");
                }
            }
        }


        private bool? _addactionlog_ts;
        public bool? addactionlog_ts
        {
            get { return _addactionlog_ts; }
            set
            {
                if (_addactionlog_ts != value)
                {
                    _addactionlog_ts = value; RaisePropertyChanged("addactionlog_ts");
                }
            }
        }

        private string _curr_code;
        public string curr_code
        {
            get { return _curr_code; }
            set
            {
                if (_curr_code != value)
                {
                    _curr_code = value; RaisePropertyChanged("curr_code");
                }
            }
        }

        private string _local_curr;
        public string local_curr
        {
            get { return _local_curr; }
            set
            {
                if (_local_curr != value)
                {
                    _local_curr = value; RaisePropertyChanged("local_curr");
                }
            }
        }


        private decimal? _local_exc_rate;
        public decimal? local_exc_rate
        {
            get { return _local_exc_rate; }
            set
            {
                if (_local_exc_rate != value)
                {
                    _local_exc_rate = value; RaisePropertyChanged("local_exc_rate");
                }
            }
        }


        private string _cat_id;
        public string cat_id
        {
            get { return _cat_id; }
            set
            {
                if (_cat_id != value)
                {
                    _cat_id = value; RaisePropertyChanged("cat_id");
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
                    _para1 = value; RaisePropertyChanged("para1");
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
                    _para2 = value; RaisePropertyChanged("para2");
                }
            }
        }
        private string _para3;
        public string para3
        {
            get { return _para3; }
            set
            {
                if (_para3 != value)
                {
                    _para3 = value; RaisePropertyChanged("para3");
                }
            }
        }
        private string _para4;
        public string para4
        {
            get { return _para4; }
            set
            {
                if (_para4 != value)
                {
                    _para4 = value; RaisePropertyChanged("para4");
                }
            }
        }
        //scalar

        private string _projectmanagernm;
        public string projectmanagernm
        {
            get { return _projectmanagernm; }
            set
            {
                if (_projectmanagernm != value)
                {
                    _projectmanagernm = value; RaisePropertyChanged("projectmanagernm");
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


        private string _customernm;
        public string customernm
        {
            get { return _customernm; }
            set
            {
                if (_customernm != value)
                {
                    _customernm = value; RaisePropertyChanged("customernm");
                }
            }
        }

        private int _taskcount;
        public int taskcount
        {
            get { return _taskcount; }
            set
            {
                if (_taskcount != value)
                {
                    _taskcount = value; RaisePropertyChanged("taskcount");
                }
            }
        }

        private int _issuescount;
        public int issuescount
        {
            get { return _issuescount; }
            set
            {
                if (_issuescount != value)
                {
                    _issuescount = value; RaisePropertyChanged("issuescount");
                }
            }
        }

        private string _cat_title;
        public string cat_title
        {
            get { return _cat_title; }
            set
            {
                if (_cat_title != value)
                {
                    _cat_title = value; RaisePropertyChanged("cat_title");
                }
            }
        }

        private string _title;
        public string title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value; RaisePropertyChanged("title");
                }
            }
        }


        private string _Hoursspent;
        public string Hoursspent
        {
            get { return _Hoursspent; }
            set
            {
                if (_Hoursspent != value)
                {
                    _Hoursspent = value; RaisePropertyChanged("Hoursspent");
                }
            }
        }

        private string _RemHours;
        public string RemHours
        {
            get { return _RemHours; }
            set
            {
                if (_RemHours != value)
                {
                    _RemHours = value; RaisePropertyChanged("RemHours");
                }
            }
        }


        private string _progress;
        public string progress
        {
            get { return _progress; }
            set
            {
                if (_progress != value)
                {
                    _progress = value; RaisePropertyChanged("progress");
                }
            }
        }
        private string _sub_cat;
        public string sub_cat
        {
            get { return _sub_cat; }
            set
            {
                if (_sub_cat != value)
                {
                    _sub_cat = value; RaisePropertyChanged("sub_cat");
                }
            }
        }
        private string _make;
        public string make
        {
            get { return _make; }
            set
            {
                if (_make != value)
                {
                    _make = value; RaisePropertyChanged("make");
                }
            }
        }
        private string _model;
        public string model
        {
            get { return _model; }
            set
            {
                if (_model != value)
                {
                    _model = value; RaisePropertyChanged("model");
                }
            }
        }
        //XML string

        public string XmlDataDocument_PRO_T001_A;
        public string XmlDataDocument_PRO_T001_B;
        public string XmlDataDocument_PRO_T001_C;
        public string XmlDataDocument_PRO_T001_D;
        public string XmlDataDocument_PRO_T002; // For Task Creation Entity
        public string XmlDataDocument_FlipGrid;
    }
    public class PRO_T001_A : ObjectBase
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


        private string _project_id;
        public string project_id
        {
            get { return _project_id; }
            set
            {
                if (_project_id != value)
                {
                    _project_id = value; RaisePropertyChanged("project_id");
                }
            }
        }


        private string _phase_id;
        public string phase_id
        {
            get { return _phase_id; }
            set
            {
                if (_phase_id != value)
                {
                    _phase_id = value; RaisePropertyChanged("phase_id");
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


        private System.DateTime _start_date;
        public System.DateTime start_date
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

        private Nullable<System.DateTime> _actual_start;
        public Nullable<System.DateTime> actual_start
        {
            get { return _actual_start; }
            set
            {
                if (_actual_start != value)
                {
                    _actual_start = value; RaisePropertyChanged("actual_start");
                }
            }
        }

        private System.DateTime _dead_date;
        public System.DateTime dead_date
        {
            get { return _dead_date; }
            set
            {
                if (_dead_date != value)
                {
                    _dead_date = value; RaisePropertyChanged("dead_date");
                }
            }
        }


        private Nullable<System.DateTime> _actual_end;
        public Nullable<System.DateTime> actual_end
        {
            get { return _actual_end; }
            set
            {
                if (_actual_end != value)
                {
                    _actual_end = value; RaisePropertyChanged("actual_end");
                }
            }
        }


        private int _sequence;
        public int sequence
        {
            get { return _sequence; }
            set
            {
                if (_sequence != value)
                {
                    _sequence = value; RaisePropertyChanged("sequence");
                }
            }
        }

        private bool _active;
        public bool active
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
        

        // scalar property

        private string _phasenm;
        public string phasenm
        {
            get { return _phasenm; }
            set
            {
                if (_phasenm != value)
                {
                    _phasenm = value; RaisePropertyChanged("phasenm");
                }
            }
        }
    }
    public class PRO_T001_B : ObjectBase
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

        private string _Emp_Type;
        public string Emp_Type
        {
            get { return _Emp_Type; }
            set
            {
                if (_Emp_Type != value)
                {
                    _Emp_Type = value; RaisePropertyChanged("Emp_Type");
                }
            }
        }

        private string _project_id;
        public string project_id
        {
            get { return _project_id; }
            set
            {
                if (_project_id != value)
                {
                    _project_id = value; RaisePropertyChanged("project_id");
                }
            }
        }

        private string _RoleCode;
        public string RoleCode
        {
            get { return _RoleCode; }
            set
            {
                if (_RoleCode != value)
                {
                    _RoleCode = value; RaisePropertyChanged("RoleCode");
                }
            }
        }

        private bool _active;
        public bool active
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
                    _editby = value; RaisePropertyChanged("_editby");
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
        
        //scalar

        private string _empname;
        public string empname
        {
            get { return _empname; }
            set
            {
                if (_empname != value)
                {
                    _empname = value; RaisePropertyChanged("empname");
                }
            }
        }

        private string _role_name;
        public string role_name
        {
            get { return _role_name; }
            set
            {
                if (_role_name != value)
                {
                    _role_name = value; RaisePropertyChanged("role_name");
                }
            }
        }



    }
    public class PRO_T001_C : ObjectBase
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

        private string _project_id;
        public string project_id
        {
            get { return _project_id; }
            set
            {
                if (_project_id != value)
                {
                    _project_id = value; RaisePropertyChanged("project_id");
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

        private string _sku;
        public string sku
        {
            get { return _sku; }
            set
            {
                if (_sku != value)
                {
                    _sku = value; RaisePropertyChanged("sku");
                }
            }
        }


        private string _sku_desc;
        public string sku_desc
        {
            get { return _sku_desc; }
            set
            {
                if (_sku_desc != value)
                {
                    _sku_desc = value; RaisePropertyChanged("sku_desc");
                }
            }
        }

        private decimal _quantity;
        public decimal quantity
        {
            get { return _quantity; }
            set
            {
                if (_quantity != value)
                {
                    _quantity = value; RaisePropertyChanged("quantity");
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


        private bool _active;
        public bool active
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
                    _editby = value; RaisePropertyChanged("_editby");
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

                }
                _edit_date = value; RaisePropertyChanged("edit_date");
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


        private string _store_code;
        public string store_code
        {
            get { return _store_code; }
            set
            {
                if (_store_code != value)
                {
                    _store_code = value; RaisePropertyChanged("store_code");
                }
            }
        }

        // scalar property

        private string _itemname;
        public string itemname
        {
            get { return _itemname; }
            set
            {
                if (_itemname != value)
                {
                    _itemname = value; RaisePropertyChanged("itemname");
                }
            }
        }
    }
    public class PRO_T001_D : ObjectBase
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


        private string _project_id;
        public string project_id
        {
            get { return _project_id; }
            set
            {
                if (_project_id != value)
                {
                    _project_id = value; RaisePropertyChanged("project_id");
                }
            }
        }


        private string _point_id;
        public string point_id
        {
            get { return _point_id; }
            set
            {
                if (_point_id != value)
                {
                    _point_id = value; RaisePropertyChanged("point_id");
                }
            }
        }


        private bool _check;
        public bool check
        {
            get { return _check; }
            set
            {
                if (_check != value)
                {
                    _check = value; RaisePropertyChanged("check");
                }
            }
        }


        private bool _active;
        public bool active
        {
            get { return _active; }
            set
            {
                if (_active = value)
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


        private string _point_description;
        public string point_description
        {
            get { return _point_description; }
            set
            {
                if (_point_description != value)
                {
                    _point_description = value; RaisePropertyChanged("point_description");
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
    public class PRO_T001_FLIP : ObjectBase
    {
        public string project_id { get; set; }
        public string project_name { get; set; }
        public string project_manager { get; set; }
        public string t_status { get; set; }
        public string ref_doc_no { get; set; }
        public Nullable<System.DateTime> start_date { get; set; }
        public Nullable<System.DateTime> actual_start { get; set; }
        public Nullable<System.DateTime> dead_date { get; set; }
        public Nullable<System.DateTime> actual_end { get; set; }
        public Nullable<decimal> planned_hours { get; set; }
        public Nullable<decimal> hours_spent { get; set; }
        public Nullable<decimal> rem_hours { get; set; }
        public Nullable<decimal> total_hours { get; set; }
        public Nullable<decimal> progress_rate { get; set; }
        public Nullable<decimal> b_amt { get; set; }
        public string customernm { get; set; }
        public string projectmanagernm { get; set; }
        public string plantname { get; set; }
        public int taskcount { get; set; }
        public string pcode_1 { get; set; }
        public string pcode_2 { get; set; }
    }
    public class MultipleContext_PRO_T001
    {
        public List<ADM_M028_P> PartyList { get; set; }
        public List<ADM_M024_P> EmployeeList { get; set; }
        public List<SEL_T001_P> SonoList { get; set; }
        public List<SYS_M017_P> Doc_typeList { get; set; }
        public List<PRO_M003_P> PhaseList { get; set; }
        public List<ADM_M022_P> ItemList { get; set; }
        public List<ADM_M038_B_P> UomList { get; set; }
        public List<PRO_M004_P> RoleList { get; set; }
        public List<PRO_M005_P> ProjectCheckList { get; set; }
        public List<PRO_T001_FLIP> ProjectList { get; set; }
        public ObservableCollection<PRO_T001_A> ProjectPhaseList { get; set; }
        public ObservableCollection<PRO_T001_B> ProjectEmployeeList { get; set; }
        public ObservableCollection<PRO_T001_C> ProjectItemList { get; set; }
        public ObservableCollection<PRO_T001_D> ProjectApprovalCheckList { get; set; }
        public List<PRO_T001> ProjectMasterList { get; set; }
        public ObservableCollection<PRO_T002> ProjectTaskList { get; set; }
        public List<PRO_T002_P_1> TaskList { get; set; }
        public int? EmpCount { get; set; }
        public int? PhaseCount { get; set; }
        public int? TaskCount { get; set; }
        public List<COM_T003> AttachmentData { get; set; }
        public List<PRO_M001_P> ProjectCategoryList { get; set; }
        public List<PRO_M001_A_P> ProjectSubCategoryList { get; set; }
        public List<ADM_M031_P> MakeList { get; set; }
        public List<ADM_M031_P> ModelList { get; set; }
    }
}

