using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Reflection.BusinessEntity.ProjectManagement
{
    public class PRO_T002 : ObjectBase
    {        
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

        private DateTime _doc_date;
        [Required(ErrorMessage = "Field 'Document Date' is required.")]
        public DateTime doc_date
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
                

        private string _project_id;
        [Required(ErrorMessage = "Field 'Project' is required.")]
        public string project_id
        {
            get { return _project_id; }
            set {
                if (_project_id != value)
                {
                    _project_id = value; RaisePropertyChanged("project_id");
                }
            }
        }
              

        private string _phase_id;
        [Required(ErrorMessage = "Field 'Phase' is required.")]
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

        private string _EmpId;
        [Required(ErrorMessage = "Field 'Assgined To' is required.")]
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

        private string _reviewer_id;
        public string reviewer_id
        {
            get { return _reviewer_id; }
            set
            {
                if (_reviewer_id != value)
                {
                    _reviewer_id = value; RaisePropertyChanged("reviewer_id");
                }
            }
        } 

        private string _title;
        [Required(ErrorMessage = "Field 'Task Title' is required.")]
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

        private decimal _plan_hours;
        [Required(ErrorMessage = "Field 'Planned hours' is required.")]
        public decimal plan_hours
        {
            get { return _plan_hours; }
            set
            {
                if (_plan_hours != value)
                {
                    _plan_hours = value; RaisePropertyChanged("plan_hours");
                }
            }
        } 

        private decimal? _hours_spent;
        public decimal? hours_spent
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

        private decimal? _remaining_hours;
        public decimal? remaining_hours
        {
            get { return _remaining_hours; }
            set
            {
                if (_remaining_hours != value)
                {
                    _remaining_hours = value; RaisePropertyChanged("remaining_hours");
                }
            }
        } 

        private decimal? _delay_hours;
        public decimal? delay_hours
        {
            get { return _delay_hours; }
            set
            {
                if (_delay_hours != value)
                {
                    _delay_hours = value; RaisePropertyChanged("delay_hours");
                }
            }
        }

        private decimal? _total_hours;
        public decimal? total_hours
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

        private DateTime? _start_date;
        public DateTime? start_date
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

        private DateTime? _actual_start;
        public DateTime? actual_start
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

        private DateTime? _dead_date;
        public DateTime? dead_date
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
                

        private DateTime? _actual_end;
        public DateTime? actual_end
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

        private decimal? _progress;
        public decimal? progress
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

        private int _sequence;
        [Required(ErrorMessage = "Field 'Sequence' is required.")]
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
                

        private int? _color;
        public int? color
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

        private string _repeat_id;
        public string repeat_id
        {
            get { return _repeat_id; }
            set
            {
                if (_repeat_id != value)
                {
                    _repeat_id = value; RaisePropertyChanged("repeat_id");
                }
            }
        } 

        private int? _procurement_id;
        public int? procurement_id
        {
            get { return _procurement_id; }
            set
            {
                if (_procurement_id != value)
                {
                    _procurement_id = value; RaisePropertyChanged("procurement_id");
                }
            }
        }
               

        private int? _sale_line_id;
        public int? sale_line_id
        {
            get { return _sale_line_id; }
            set
            {
                if (_sale_line_id != value)
                {
                    _sale_line_id = value; RaisePropertyChanged("sale_line_id");
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

        private DateTime _add_date;
        public DateTime add_date
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

        private DateTime? _edit_date;
        public DateTime? edit_date
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

        private string _t_description;
        public string t_description
        {
            get { return _t_description; }
            set
            {
                if (_t_description != value)
                {
                    _t_description = value; RaisePropertyChanged("t_description");
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

        private string _r_accept;
        public string r_accept
        {
            get { return _r_accept; }
            set
            {
                if (_r_accept != value)
                {
                    _r_accept = value; RaisePropertyChanged("r_accept");
                }
            }
        } 

        private string _review_by;
        public string review_by
        {
            get { return _review_by; }
            set
            {
                if (_review_by != value)
                {
                    _review_by = value; RaisePropertyChanged("review_by");
                }
            }
        }
               

        private DateTime? _review_date;
        public DateTime? review_date
        {
            get { return _review_date; }
            set
            {
                if (_review_date != value)
                {
                    _review_date = value; RaisePropertyChanged("review_date");
                }
            }
        } 

        private string _dependancy;
        public string dependancy
        {
            get { return _dependancy; }
            set
            {
                if (_dependancy != value)
                {
                    _dependancy = value; RaisePropertyChanged("dependancy");
                }
            }
        }

        private bool? _t_complete;
        public bool? t_complete
        {
            get { return _t_complete; }
            set
            {
                if (_t_complete != value)
                {
                    _t_complete = value; RaisePropertyChanged("t_complete");
                }
            }
        }

        private string _task_type;
        public string task_type
        {
            get { return _task_type; }
            set
            {
                if (_task_type != value)
                {
                    _task_type = value; RaisePropertyChanged("task_type");
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
        private string _task_code;
        public string task_code
        {
            get { return _task_code; }
            set
            {
                if (_task_code != value)
                {
                    _task_code = value; RaisePropertyChanged("task_code");
                }
            }
        }

        //Extra Scalars
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

        private string _reviewer_name;
        public string reviewer_name
        {
            get { return _reviewer_name; }
            set
            {
                if (_reviewer_name != value)
                {
                    _reviewer_name = value; RaisePropertyChanged("reviewer_name");
                }
            }
        }

        private string _dependancy_name;
        public string dependancy_name
        {
            get { return _dependancy_name; }
            set
            {
                if (_dependancy_name != value)
                {
                    _dependancy_name = value; RaisePropertyChanged("dependancy_name");
                }
            }
        } 

        private string _repeat_name;
        public string repeat_name
        {
            get { return _repeat_name; }
            set
            {
                if (_repeat_name != value)
                {
                    _repeat_name = value; RaisePropertyChanged("repeat_name");
                }
            }
        }

        private int _SrNo;
        public int SrNo
        {
            get { return _SrNo; }
            set
            {
                if (_SrNo != value)
                {
                    _SrNo = value; RaisePropertyChanged("SrNo");
                }
            }
        } 
        public string XmlDataDocument_PRO_T002_A;
        public string XmlDataDocument_View;

    }
    public class PRO_T002_A : ObjectBase
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

        private decimal _hours_spent;
        public decimal hours_spent
        {
            get { return _hours_spent; }
            set
            {
                if (_hours_spent != value)
                {
                    _hours_spent = value; RaisePropertyChanged("hours_spent", ModelEntityUpdated);
                }
            }
        }

        private string _work_summary;
        public string work_summary
        {
            get { return _work_summary; }
            set
            {
                if (_work_summary != value)
                {
                    _work_summary = value; RaisePropertyChanged("work_summary", ModelEntityUpdated);
                }
            }
        }


        private Nullable<System.DateTime> _start_date;
        public Nullable<System.DateTime> start_date
        { get
            { return _start_date; }
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

        private DateTime _end_date;
        public DateTime end_date
        {
            get { return _end_date; }
            set
            {
                if (_end_date != value)
                {
                    _end_date = value; RaisePropertyChanged("end_date");
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

        private int? _hr_ana_ts_id;
        public int? hr_ana_ts_id
        {
            get { return _hr_ana_ts_id; }
            set
            {
                if (_hr_ana_ts_id != value)
                {
                    _hr_ana_ts_id = value; RaisePropertyChanged("hr_ana_ts_id");
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
            set {
                if (_add_by != value)
                {
                    _add_by = value; RaisePropertyChanged("add_by");
                }
            }
        }
               

        private DateTime _add_date;
        public DateTime add_date
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

        private DateTime? _edit_date;
        public DateTime? edit_date
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
        
        //Extra Scalars
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

    }

    public class PRO_T002_A_3_A : ObjectBase        // Timesheet Entity
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

        private string _work_summary;
        public string work_summary
        {
            get { return _work_summary; }
            set
            {
                if (_work_summary != value)
                {
                    _work_summary = value; RaisePropertyChanged("work_summary");
                }
            }
        }
                


        private Nullable<System.DateTime> _start_date;
        public Nullable<System.DateTime> start_date
        {
            get
            { return _start_date; }
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
               

        private DateTime _end_date;
        public DateTime end_date
        {
            get { return _end_date; }
            set
            {
                if (_end_date != value)
                {
                    _end_date = value; RaisePropertyChanged("end_date");
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

        private int? _hr_ana_ts_id;
        public int? hr_ana_ts_id
        {
            get { return _hr_ana_ts_id; }
            set
            {
                if (_hr_ana_ts_id != value)
                {
                    _hr_ana_ts_id = value; RaisePropertyChanged("hr_ana_ts_id");
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

        private DateTime _add_date;
        public DateTime add_date
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

        private DateTime? _edit_date;
        public DateTime? edit_date
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

        //Extra Scalars
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

        private Nullable<bool> _check;
        public Nullable<bool> check
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
    }

    public class PRO_T002_View
    {
        public string task_id { get; set; }
        public string title { get; set; }
        public DateTime? doc_date { get; set; }
        public string project_id { get; set; }
        public string project_name { get; set; }
        public string phase_id { get; set; }
        public string EmpId { get; set; }
        public string phase_name { get; set; }
        public string reviewer_id { get; set; }
        public string assignto_name { get; set; }
        public string reviewer_name { get; set; }
        public string t_status { get; set; }
        public decimal plan_hours { get; set; }
        public decimal? hours_spent { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? actual_start { get; set; }
        public DateTime? dead_date { get; set; }
        public DateTime? actual_end { get; set; }
        public decimal? progress { get; set; }
        public string repeat_id { get; set; }
        public string repeat_name { get; set; }
        public string dependancy { get; set; }
        public string dependancy_name { get; set; }
    }

    public class MultipleContext_PRO_T002
    {
        public List<PRO_T001_P> ProjectList { get; set; }
        public List<PRO_T001_A_P> PhasesList { get; set; }
        public List<PRO_T001_B_P> AssignedToList { get; set; }
        public List<PRO_T001_B_P> ReviewerList { get; set; }
        public List<SYS_M017_P> Doc_typeList { get; set; }
        public List<PRO_T001_B_P> WorkDoneByList { get; set; }
        public List<PRO_T002_View> TaskViewList { get; set; }
        public List<PRO_T002> TaskList { get; set; }
        public List<PRO_T002_A_P> WorkSummaryForPopUPList { get; set; }
        public ObservableCollection<PRO_T002_A> WorkSummaryList { get; set; }
        public ObservableCollection<PRO_T002_A_3_A> TimesheetList { get; set; }
        public List<COM_T003> AttachmentData { get; set; }
        public List<PRO_M006> TaskMasterList { get; set; }
    }

}
