using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Reflection.BusinessEntity.ProjectManagement
{
    public class PRO_T003:ObjectBase
    {               
        private string _issue_id;
        public string issue_id
        {
            get { return _issue_id; }
            set
            {
                if (_issue_id != value)
                {
                    _issue_id = value; RaisePropertyChanged("issue_id");
                }
            }
        }
                
       
  
        private string _issue_name;
        [Required(ErrorMessage = "Field 'Issue Name' is required.")]
        public string issue_name
        {
            get { return _issue_name; }
            set
            {
                if (_issue_name != value)
                {
                    _issue_name = value; RaisePropertyChanged("issue_name");
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
            set
            {
                if (_doc_type != value)
                {
                    _doc_type = value; RaisePropertyChanged("doc_type");
                }
            }
        } 

        private System.DateTime _facing_from_date;

        [Required(ErrorMessage = "Field 'Facing From Date' is required.")]
        public System.DateTime facing_from_date
        {
            get { return _facing_from_date; }
            set
            {
                if (_facing_from_date != value)
                {
                    _facing_from_date = value; RaisePropertyChanged("facing_from_date");
                }
            }
        } 

        private System.DateTime _reporting_date;
        [Required(ErrorMessage = "Field 'Reporting Date' is required.")]
        public System.DateTime reporting_date
        {
            get { return _reporting_date; }
            set
            {
                if (_reporting_date != value)
                {
                    _reporting_date = value; RaisePropertyChanged("reporting_date");
                }
            }
        }

        private string _reporter_id;
        public string reporter_id
        {
            get { return _reporter_id; }
            set
            {
                if (_reporter_id != value)
                {
                    _reporter_id = value; RaisePropertyChanged("reporter_id");
                }
            }
        } 

        private string _reporter_name;
        [Required(ErrorMessage = "Field 'Reporter Name' is required.")]
        public string reporter_name
        {
            get { return _reporter_name; }
            set
            {
                if (_reporter_name != value)
                {
                    _reporter_name = value; RaisePropertyChanged("reporter_name");
                }
            }
        } 

        private string _project_id;
        [Required(ErrorMessage = "Field 'Project' is required.")]
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

        private string _task_id;
        public string task_id
        {
            get { return _task_id; }
            set
            {
                if (_task_id != value)
                {
                    _task_id = value; RaisePropertyChanged("task_id");
                }
            }
        }
                

        private string _assign_to;
        public string assign_to
        {
            get { return _assign_to; }
            set
            {
                if (_assign_to != value)
                {
                    _assign_to = value; RaisePropertyChanged("assign_to");
                }
            }
        } 

        private Nullable<int> _ver_id;
        public Nullable<int> ver_id
        {
            get { return _ver_id; }
            set {
                if (_ver_id != value)
                {
                    _ver_id = value; RaisePropertyChanged("ver_id");
                }
            }
        }
               

        private string _description;
        [Required(ErrorMessage = "Field 'Issue Description' is required.")]
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

        private Nullable<decimal> _hours_to_close;
        public Nullable<decimal> hours_to_close
        {
            get { return _hours_to_close; }
            set
            {
                if (_hours_to_close != value)
                {
                    _hours_to_close = value; RaisePropertyChanged("hours_to_close");
                }
            }
        } 

        private Nullable<decimal> _hours_to_open;
        public Nullable<decimal> hours_to_open
        {
            get { return _hours_to_open; }
            set
            {
                if (_hours_to_open != value)
                {
                    _hours_to_open = value; RaisePropertyChanged("hours_to_open");
                }
            }
        } 

        private Nullable<System.DateTime> _last_action_date;
        public Nullable<System.DateTime> last_action_date
        {
            get { return _last_action_date; }
            set
            {
                if (_last_action_date != value)
                {
                    _last_action_date = value; RaisePropertyChanged("last_action_date");
                }
            }
        } 

        private Nullable<System.DateTime> _next_action_date;
        public Nullable<System.DateTime> next_action_date
        {
            get { return _next_action_date; }
            set
            {
                if (_next_action_date != value)
                {
                    _next_action_date = value; RaisePropertyChanged("next_action_date");
                }
            }
        }
                

        private Nullable<System.DateTime> _closing_date;
        public Nullable<System.DateTime> closing_date
        {
            get { return _closing_date; }
            set
            {
                if (_closing_date != value)
                {
                    _closing_date = value; RaisePropertyChanged("closing_date");
                }
            }
        }

        private Nullable<System.DateTime> _reopen_date;
        public Nullable<System.DateTime> reopen_date
        {
            get { return _reopen_date; }
            set
            {
                if (_reopen_date != value)
                {
                    _reopen_date = value; RaisePropertyChanged("reopen_date");
                }
            }
        }
               

        private Nullable<decimal> _progress;
        public Nullable<decimal> progress
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

        private Nullable<decimal> _duration;
        public Nullable<decimal> duration
        {
            get { return _duration; }
            set
            {
                if (_duration != value)
                {
                    _duration = value; RaisePropertyChanged("duration");
                }
            }
        } 

        private Nullable<decimal> _day_open;
        public Nullable<decimal> day_open
        {
            get { return _day_open; }
            set
            {
                if (_day_open != value)
                {
                    _day_open = value; RaisePropertyChanged("day_open");
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

        private string _comp_code;
        public string comp_code
        { get
            { return _comp_code; }
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

        private string _kanban_state;
        public string kanban_state
        {
            get { return _kanban_state; }
            set
            {
                if (_kanban_state != value)
                {
                    _kanban_state = value; RaisePropertyChanged("kanban_state");
                }
            }
        } 

        private Nullable<int> _section_id;
        public Nullable<int> section_id
        {
            get { return _section_id; }
            set
            {
                if (_section_id != value)
                {
                    _section_id = value; RaisePropertyChanged("section_id");
                }
            }
        }

        private string _email_cc;
        public string email_cc
        {
            get { return _email_cc; }
            set
            {
                if (_email_cc != value)
                {
                    _email_cc = value; RaisePropertyChanged("email_cc");
                }
            }
        } 

        private Nullable<int> _channel_id;
        public Nullable<int> channel_id
        {
            get { return _channel_id; }
            set
            {
                if (_channel_id != value)
                {
                    _channel_id = value; RaisePropertyChanged("channel_id");
                }
            }
        } 

        private string _email_from;
        public string email_from
        {
            get { return _email_from; }
            set
            {
                if (_email_from != value)
                {
                    _email_from = value; RaisePropertyChanged("email_from");
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

        //Scalar variables

        private string _project_name;
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

        private string _phase_name;
        public string phase_name
        {
            get { return _phase_name; }
            set
            {
                if (_phase_name != value)
                {
                    _phase_name = value; RaisePropertyChanged("phase_name");
                }
            }
        } 

        private string _assignto_name;
        public string assignto_name
        {
            get { return _assignto_name; }
            set
            {
                if (_assignto_name != value)
                {
                    _assignto_name = value; RaisePropertyChanged("assignto_name");
                }
            }
        } 

        private string _title;
        public string title
        {
            get { return _title; }
            set {
                if (_title != value)
                {
                    _title = value; RaisePropertyChanged("title");
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


        public string XmlDataDocument_PRO_T003_A;
        public string XmlDataDocument_View;

    }
    public class PRO_T003_A : ObjectBase
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

        private string _issue_id;
        public string issue_id
        {
            get { return _issue_id; }
            set
            {
                if (_issue_id != value)
                {
                    _issue_id = value; RaisePropertyChanged("issue_id");
                }
            }
        }
                

        private string _done_by;
        public string done_by
        {
            get { return _done_by; }
            set
            {
                if (_done_by != value)
                {
                    _done_by = value; RaisePropertyChanged("done_by");
                }
            }
        }
               

        private decimal _hours_spent;
        public decimal hours_spent
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
               

        private string _action_summary;
        public string action_summary
        {
            get { return _action_summary; }
            set
            {
                if (_action_summary != value)
                {
                    _action_summary = value; RaisePropertyChanged("action_summary", ModelEntityUpdated);
                }
            }
        } 

        private Nullable<System.DateTime> _start_date;
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

        private string _start_time;
        public string start_time
        {
            get { return _start_time; }
            set
            {
                if (_start_time != value)
                {
                    _start_time = value; RaisePropertyChanged("start_time");
                }
            }
        }
               

        private System.DateTime _end_date;
        public System.DateTime end_date
        {
            get { return _end_date; }
            set
            {
                if (_end_date != value)
                {
                    _end_date = value; RaisePropertyChanged("end_date", ModelEntityUpdated);
                }
            }
        }

        private string _end_time;
        public string end_time
        {
            get { return _end_time; }
            set
            {
                if (_end_time != value)
                {
                    _end_time = value; RaisePropertyChanged("end_time");
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
               

        private string _t_status;
        public string t_status
        { get { return _t_status; }
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
               
        private Nullable<bool> _invoicable;
        public Nullable<bool> invoicable
        {
            get { return _invoicable; }
            set
            {
                if (_invoicable != value)
                {
                    _invoicable = value; RaisePropertyChanged("invoicable");
                }
            }
        } 

        private Nullable<bool> _invoice_generated;
        public Nullable<bool> invoice_generated
        {
            get { return _invoice_generated; }
            set
            {
                if (_invoice_generated != value)
                {
                    _invoice_generated = value; RaisePropertyChanged("invoice_generated");
                }
            }
        } 

        private Nullable<decimal> _invoice_percentage;
        public Nullable<decimal> invoice_percentage
        {
            get { return _invoice_percentage; }
            set
            {
                if (_invoice_percentage != value)
                {
                    _invoice_percentage = value; RaisePropertyChanged("invoice_percentage");
                }
            }
        } 

        //Scalar Variables

        private string _done_by_name;
        public string done_by_name
        {
            get { return _done_by_name; }
            set
            {
                if (_done_by_name != value)
                {
                    _done_by_name = value; RaisePropertyChanged("done_by_name");
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
    public class PRO_T003_View
    {
        public string issue_id { get; set; }
        public string issue_name { get; set; }
        public System.DateTime reporting_date { get; set; }
        public string reporter_name { get; set; }
        public string t_status { get; set; }
        public string assignto_name { get; set; }
        public string task_name { get; set; }
        public string phase_name { get; set; }
        public string project_name { get; set; }
        public string project_id { get; set; }

    }
    public class MultipleContext_PRO_T003
    {
        public List<PRO_T001_P> ProjectList { get; set; }
        public List<PRO_T001_A_P> PhasesList { get; set; }
        public List<PRO_T002_P> TaskList { get; set; }
        public List<PRO_T001_B_P> AssignedToList { get; set; }
        public List<ADM_M024_P> ReporterNameList { get; set; }
        public List<PRO_T001_B_P> WorkDoneByList { get; set; }
        public List<PRO_T003_View> IssueViewList { get; set; }
        public List<SYS_M017_P> Doc_typeList { get; set; }
        public List<PRO_T003> IssueList { get; set; }
        public List<PRO_T003_View> TaskViewList { get; set; }
        public ObservableCollection<PRO_T003_A> ActionLogList { get; set; }
        public ObservableCollection<PRO_T002_A_3_A> TimesheetList { get; set; }
        public List<COM_T003> AttachmentData { get; set; }
        public List<PRO_M001_P> IssueCategoryList { get; set; }
    }
}
