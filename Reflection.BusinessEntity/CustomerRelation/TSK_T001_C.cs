using Reflection.BusinessEntity.ADM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace Reflection.BusinessEntity.CustomerRelation
{
    public  class TSK_T001_C : ObjectBase
    {
       
       
           public static event EventHandler ModelEntityUpdated = delegate { };
            private int _id;
            private string _doc_no;
            private Nullable<System.DateTime> _doc_date;
            private string _doc_type;
            private string _doc_cat;
            private string _act_action;
            private string _owner;
            private string _place;
            private string _address;
            private string _act_desc;
            private string _PartyId;         
            private string _priority;
            private Nullable<System.DateTime> _start_date;
            private string _from_time;
            private Nullable<System.DateTime> _end_date;
            private string _to_time;
            private Nullable<System.DateTime> _close_date;
            private string _stage_id;
            private string _cat_id;
            private string _section_id;
            private string _note;
            private string _lead_id;
            private string _lead_title;
            private string _sono;
            private string _contact_person;
            private string _person_number;
            private string _activity_type;
            private Nullable<bool> _active;
            private string _t_status;
            private string _add_by;
            private Nullable<System.DateTime> _add_date;
            private string _editby;
            private Nullable<System.DateTime> _edit_date;
            private string _parent_activity;
            private string _action_type;
            private string _EmpName;
            private string _fin_year;
            private string _location_Id;
            private string _comp_code;
            private string _posting_period;
            private string _s_status;
            private string _so_code;
            private string _sg_code;
            private string _EmailId;
            private string _project_name;
            private string _project_location;
            private string _project_type;
            private string _architect_grade;
            private string _para1;
            private string _para2;
            private string _para3;
            private string _para4;
            private string _para5;
            private Nullable<System.DateTime> _pay_expected_date;
            private Nullable<decimal> _payment;
            private string _architect_name;
            private string _party_name;
            private Nullable<System.DateTime> _act_date;
            private string _duration;
            private string _prospectus;

        public int id
                {
                    get
                    {
                        return _id;
                    }

                    set
            {
                if (_id != value)
                {
                    _id = value; RaisePropertyChanged("id", ModelEntityUpdated);
                }
            }
                }
        public string doc_no
            {
                get
                {
                    return _doc_no;
                }

                set
            {
                if (_doc_no != value)
                {
                    _doc_no = value; RaisePropertyChanged("doc_no", ModelEntityUpdated);
                }
            }
            }

            public DateTime? doc_date
            {
                get
                {
                    return _doc_date;
                }

                set
            {
                if (_doc_date != value)
                {
                    _doc_date = value; RaisePropertyChanged("doc_date", ModelEntityUpdated);
                }
            }
            }

            public string doc_type
            {
                get
                {
                    return _doc_type;
                }

                set
            {
                if (_doc_type != value)
                {
                    _doc_type = value; RaisePropertyChanged("doc_type", ModelEntityUpdated);
                }
            }
            }

            public string doc_cat
            {
                get
                {
                    return _doc_cat;
                }

                set
            {
                if (_doc_cat != value)
                {
                    _doc_cat = value; RaisePropertyChanged("doc_cat", ModelEntityUpdated);
                }
            }
            }

            public string act_action
            {
                get
                {
                    return _act_action;
                }

                set
            {
                if (_act_action != value)
                {
                    _act_action = value; RaisePropertyChanged("act_action", ModelEntityUpdated);
                }
            }
            }
       
            public string owner
            {
                get
                {
                    return _owner;
                }

                set
            {
                if (_owner != value)
                {
                    _owner = value; RaisePropertyChanged("owner", ModelEntityUpdated);
                }
            }
            }
      
           public string place
            {
                get
                {
                    return _place;
                }

                set
            {
                if (_place != value)
                {
                    _place = value; RaisePropertyChanged("place", ModelEntityUpdated);
                }
            }
            }
     
           public string address
            {
                get
                {
                    return _address;
                }

                set
            {
                if (_address != value)
                {
                    _address = value; RaisePropertyChanged("address", ModelEntityUpdated);
                }
            }
            }

            public string act_desc
            {
                get
                {
                    return _act_desc;
                }

                set
            {
                if (_act_desc != value)
                {
                    _act_desc = value; RaisePropertyChanged("act_desc", ModelEntityUpdated);
                }
            }
            }

            public string PartyId
            {
                get
                {
                    return _PartyId;
                }

                set
            {
                if (_PartyId != value)
                {
                    _PartyId = value; RaisePropertyChanged("PartyId", ModelEntityUpdated);
                }
            }
            }
      
        public string priority
            {
                get
                {
                    return _priority;
                }

                set
            {
                if (_priority != value)
                {
                    _priority = value; RaisePropertyChanged("priority", ModelEntityUpdated);
                }
            }
            }

            public DateTime? start_date
            {
                get
                {
                    return _start_date;
                }

                set
            {
                if (_start_date != value)
                {
                    _start_date = value; RaisePropertyChanged("start_date", ModelEntityUpdated);
                }
            }
            }
   
        public string from_time
            {
                get
                {
                    return _from_time;
                }

                set
            {
                if (_from_time != value)
                {
                    _from_time = value; RaisePropertyChanged("from_time", ModelEntityUpdated);
                }
            }
            }

            public DateTime? end_date
            {
                get
                {
                    return _end_date;
                }

                set
            {
                if (_end_date != value)
                {
                    _end_date = value; RaisePropertyChanged("end_date", ModelEntityUpdated);
                }
            }
            }

            public string to_time
            {
                get
                {
                    return _to_time;
                }

                set
            {
                if (_to_time != value)
                {
                    _to_time = value; RaisePropertyChanged("to_time", ModelEntityUpdated);
                }
            }
            }

            public DateTime? close_date
            {
                get
                {
                    return _close_date;
                }

                set
            {
                if (_close_date != value)
                {
                    _close_date = value; RaisePropertyChanged("close_date", ModelEntityUpdated);
                }
            }
            }
        

            public string stage_id
            {
                get
                {
                    return _stage_id;
                }

                set
            {
                if (_stage_id!= value)
                {
                    _stage_id = value; RaisePropertyChanged("stage_id", ModelEntityUpdated);
                }
            }
            }

            public string cat_id
        {
            get
            {
                return _cat_id;
            }

            set
            {
                if (_cat_id != value)
                {
                    _cat_id = value; RaisePropertyChanged("cat_id", ModelEntityUpdated);
                }
            }
        }
            public string section_id
            {
                get
                {
                    return _section_id;
                }

                set
            {
                if (_section_id != value)
                {
                    _section_id = value; RaisePropertyChanged("section_id", ModelEntityUpdated);
                }
            }
            }

            public string note
            {
                get
                {
                    return _note;
                }

                set
            {
                if (_note != value)
                {
                    _note = value; RaisePropertyChanged("note", ModelEntityUpdated);
                }
            }
            }

            public string lead_id
            {
                get
                {
                    return _lead_id;
                }

                set
            {
                if (_lead_id != value)
                {
                    _lead_id = value; RaisePropertyChanged("lead_id", ModelEntityUpdated);
                }
            }
            }

            public string lead_title
            {
                get
                {
                    return _lead_title;
                }

                set
            {
                if (_lead_title != value)
                {
                    _lead_title = value; RaisePropertyChanged("lead_title", ModelEntityUpdated);
                }
            }
            }

            public string sono
            {
                get
                {
                    return _sono;
                }

                set
            {
                if (_sono != value)
                {
                    _sono = value; RaisePropertyChanged("sono", ModelEntityUpdated);
                }
            }
            }
      
        public string contact_person
            {
                get
                {
                    return _contact_person;
                }

                set
            {
                if (_contact_person != value)
                {
                    _contact_person = value; RaisePropertyChanged("contact_person", ModelEntityUpdated);
                }
            }
            }
     
        public string person_number
            {
                get
                {
                    return _person_number;
                }

                set
            {
                if (_person_number != value)
                {
                    _person_number = value; RaisePropertyChanged("person_number", ModelEntityUpdated);
                }
            }
            }

            public string activity_type
            {
                get
                {
                    return _activity_type;
                }

                set
            {
                if (_activity_type != value)
                {
                    _activity_type = value; RaisePropertyChanged("activity_type", ModelEntityUpdated);
                }
            }
            }

            public bool? active
            {
                get
                {
                    return _active;
                }

                set
            {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active", ModelEntityUpdated);
                }
            }
            }
    
        public string t_status
            {
                get
                {
                    return _t_status;
                }

                set
            {
                if (_t_status != value)
                {
                    _t_status = value; RaisePropertyChanged("t_status", ModelEntityUpdated);
                }
            }
            }

            public string add_by
            {
                get
                {
                    return _add_by;
                }

                set
            {
                if (_add_by != value)
                {
                    _add_by = value; RaisePropertyChanged("add_by", ModelEntityUpdated);
                }
            }
            }

            public DateTime? add_date
            {
                get
                {
                    return _add_date;
                }

                set
            {
                if (_add_date != value)
                {
                    _add_date = value; RaisePropertyChanged("add_date", ModelEntityUpdated);
                }
            }
            }

            public string editby
            {
                get
                {
                    return _editby;
                }

                set
            {
                if (_editby != value)
                {
                    _editby = value; RaisePropertyChanged("editby", ModelEntityUpdated);
                }
            }
            }

            public DateTime? edit_date
            {
                get
                {
                    return _edit_date;
                }

                set
            {
                if (_edit_date != value)
                {
                    _edit_date = value; RaisePropertyChanged("edit_date", ModelEntityUpdated);
                }
            }
            }

            public string parent_activity
            {
                get
                {
                    return _parent_activity;
                }

                set
            {
                if (_parent_activity != value)
                {
                    _parent_activity = value; RaisePropertyChanged("parent_activity", ModelEntityUpdated);
                }
            }
            }

            public string action_type
        {
            get
            {
                return _action_type;
            }

            set
            {
                if (_action_type != value)
                {
                    _action_type = value; RaisePropertyChanged("action_type", ModelEntityUpdated);
                }
            }
        }
            public string EmpName
            {
                get
                {
                    return _EmpName;
                }

                set
            {
                if (_EmpName != value)
                {
                    _EmpName = value; RaisePropertyChanged("EmpName", ModelEntityUpdated);
                }
            }
            }

        private string _EmpNameDisplay;
        public string EmpNameDisplay
        {
            get
            {
                return _EmpNameDisplay;
            }

            set
            {
                if (_EmpNameDisplay != value)
                {
                    _EmpNameDisplay = value; RaisePropertyChanged("EmpNameDisplay");
                }
            }
        }
        public string fin_year
            {
                get
                {
                    return _fin_year;
                }

                set
            {
                if (_fin_year != value)
                {
                    _fin_year = value; RaisePropertyChanged("fin_year", ModelEntityUpdated);
                }
            }
            }
            public string location_Id
            {
                get
                {
                    return _location_Id;
                }

                set
            {
                if (_location_Id != value)
                {
                    _location_Id = value; RaisePropertyChanged("location_Id", ModelEntityUpdated);
                }
            }
            }
            public string comp_code
            {
                get
                {
                    return _comp_code;
                }

                set
            {
                if (_comp_code != value)
                {
                    _comp_code = value; RaisePropertyChanged("comp_code", ModelEntityUpdated);
                }
            }
            }
            public string posting_period
            {
                get
                {
                    return _posting_period;
                }

                set
            {
                if (_posting_period != value)
                {
                    _posting_period = value; RaisePropertyChanged("  posting_period", ModelEntityUpdated);
                }
            }
            }

            public string s_status
            {
                get
                {
                    return _s_status;
                }

                set
            {
                if (_s_status != value)
                {
                    _s_status = value; RaisePropertyChanged("s_status", ModelEntityUpdated);
                }
            }
            }
        public string so_code
        {
            get
            {
                return _so_code;
            }

            set
            {
                if (_so_code != value)
                {
                    _so_code = value; RaisePropertyChanged("so_code", ModelEntityUpdated);
                }
            }
        }

        public string sg_code
        {
            get
            {
                return _sg_code;
            }

            set
            {
                if (_sg_code != value)
                {
                    _sg_code = value; RaisePropertyChanged("sg_code", ModelEntityUpdated);
                }
            }
        }
      
        public string EmailId
        {
            get
            {
                return _EmailId; 
            }

            set
            {
                if (_EmailId != value)
                {
                    _EmailId = value; RaisePropertyChanged("EmailId", ModelEntityUpdated);
                }
            }
        }
       
        public string project_name
        {
            get
            {
                return _project_name;
            }

            set
            {
                if (_project_name != value)
                {
                    _project_name = value; RaisePropertyChanged("project_name", ModelEntityUpdated);
                }
            }
        }
     
        public string project_location
        {
            get
            {
                return _project_location;
            }

            set
            {
                if (_project_location != value)
                {
                    _project_location = value; RaisePropertyChanged("project_location", ModelEntityUpdated);
                }
            }
        }

        public string project_type
        {
            get
            {
                return _project_type;
            }

            set
            {
                if (_project_type != value)
                {
                    _project_type = value; RaisePropertyChanged("project_type", ModelEntityUpdated);
                }
            }
        }
        public string architect_grade
        {
            get
            {
                return _architect_grade;
            }

            set
            {
                if (_architect_grade != value)
                {
                    _architect_grade = value; RaisePropertyChanged("architect_grade", ModelEntityUpdated);
                }
            }
        }
        
        public string para1
        {
            get
            {
                return _para1;
            }

            set
            {
                if (_para1 != value)
                {
                    _para1 = value; RaisePropertyChanged("para1", ModelEntityUpdated);
                }
            }
        }
        public string para2
        {
            get
            {
                return _para2;
            }

            set
            {
                if (_para2 != value)
                {
                    _para2 = value; RaisePropertyChanged("para2", ModelEntityUpdated);
                }
            }
        }
        public string para3
        {
            get
            {
                return _para3;
            }

            set
            {
                if (_para3 != value)
                {
                    _para3 = value; RaisePropertyChanged("para3", ModelEntityUpdated);
                }
            }
        }

        public string para4
        {
            get
            {
                return _para4;
            }

            set
            {
                if (_para4 != value)
                {
                    _para4 = value; RaisePropertyChanged("para4", ModelEntityUpdated);
                }
            }
        }
        public string para5
        {
            get
            {
                return _para5;
            }

            set
            {
                if (_para5 != value)
                {
                    _para5 = value; RaisePropertyChanged("para5", ModelEntityUpdated);
                }
            }
        }
        public Nullable<decimal> payment
        {
            get
            {
                return _payment;
            }

            set
            {
                if (_payment != value)
                {
                    _payment = value; RaisePropertyChanged("payment", ModelEntityUpdated);
                }
            }
        }

        public Nullable<System.DateTime> pay_expected_date
        {
            get
            {
                return _pay_expected_date;
            }

            set
            {
                if (_pay_expected_date != value)
                {
                    _pay_expected_date = value; RaisePropertyChanged("pay_expected_date", ModelEntityUpdated);
                }
            }
        }
        public string architect_name
        {
            get
            {
                return _architect_name;
            }

            set
            {
                if (_architect_name != value)
                {
                    _architect_name = value; RaisePropertyChanged("architect_name", ModelEntityUpdated);
                }
            }
        }
        public string party_name
        {
            get
            {
                return _party_name;
            }

            set
            {
                if (_party_name != value)
                {
                    _party_name = value; RaisePropertyChanged("party_name", ModelEntityUpdated);
                }
            }
        }
        public Nullable<System.DateTime> act_date
        {
            get
            {
                return _act_date;
            }

            set
            {
                if (_act_date != value)
                {
                    _act_date = value; RaisePropertyChanged("act_date", ModelEntityUpdated);
                }
            }
        }
        public string duration
        {
            get
            {
                return _duration;
            }

            set
            {
                if (_duration != value)
                {
                    _duration = value; RaisePropertyChanged("duration", ModelEntityUpdated);
                }
            }
        }
        public string prospectus
        {
            get
            {
                return _prospectus;
            }

            set
            {
                if (_prospectus != value)
                {
                    _prospectus = value; RaisePropertyChanged("prospectus", ModelEntityUpdated);
                }
            }
        }

        private int _folder_id;
        public int folder_id
        {
            get { return _folder_id; }
            set
            {
                if (_folder_id != value)
                {
                    _folder_id = value; RaisePropertyChanged("folder_id");
                }
            }
        }
        
        private string _assign_by;
        public string assign_by
        {
            get { return _assign_by; }
            set
            {
                if (_assign_by != value)
                {
                    _assign_by = value; RaisePropertyChanged("assign_by");
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

        private Nullable<int> _doc_id;
        public Nullable<int> doc_id
        {
            get { return _doc_id; }
            set
            {
                if (_doc_id != value)
                {
                    _doc_id = value; RaisePropertyChanged("doc_id");
                }
            }
        }


        private Nullable<bool> _completed;
        public Nullable<bool> completed
        {
            get { return _completed; }
            set
            {
                if (_completed != value)
                {
                    _completed = value; RaisePropertyChanged("completed");
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

        private string _po_code;
        public string po_code
        {
            get { return _po_code; }
            set
            {
                if (_po_code != value)
                {
                    _po_code = value; RaisePropertyChanged("po_code");
                }
            }
        }

        private string _pg_code;
        public string pg_code
        {
            get { return _pg_code; }
            set
            {
                if (_pg_code != value)
                {
                    _pg_code = value; RaisePropertyChanged("pg_code");
                }
            }
        }

        private string _ind_assist;
        public string ind_assist
        {
            get { return _ind_assist; }
            set
            {
                if (_ind_assist != value)
                {
                    _ind_assist = value; RaisePropertyChanged("ind_assist");
                }
            }
        }

        private string _assist_doc_no;
        public string assist_doc_no
        {
            get { return _assist_doc_no; }
            set
            {
                if (_assist_doc_no != value)
                {
                    _assist_doc_no = value; RaisePropertyChanged("assist_doc_no");
                }
            }
        }

        private string _sch_no;
        public string sch_no
        {
            get { return _sch_no; }
            set
            {
                if (_sch_no != value)
                {
                    _sch_no = value; RaisePropertyChanged("sch_no");
                }
            }
        }

        private bool _Click;
        public bool Click
        {
            get
            {
                return _Click;
            }
            set
            {
                if (_Click != value)
                {
                    _Click = value;
                    RaisePropertyChanged("Click");
                }
            }
        }
        private bool _Check;
        public bool Check
        {
            get
            {
                return _Check;
            }
            set
            {
                if (_Check != value)
                {
                    _Check = value;
                    RaisePropertyChanged("Check");
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

        private Nullable<int> _phase_id;
        public Nullable<int> phase_id
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
        private Nullable<decimal> _plan_hours;
        public Nullable<decimal> plan_hours
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

        private Nullable<decimal> _remaining_hours;
        public Nullable<decimal> remaining_hours
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

        private Nullable<decimal> _delay_hours;
        public Nullable<decimal> delay_hours
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

        private Nullable<int> _sequence;
        public Nullable<int> sequence
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


        private Nullable<int> _procurement_id;
        public Nullable<int> procurement_id
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

        private Nullable<System.DateTime> _review_date;
        public Nullable<System.DateTime> review_date
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

        
        //Added by Priya
        private string _comp_plant;
        public string comp_plant
        {
            get { return _comp_plant; }
            set
            {
                if (_comp_plant != value)
                {
                    _comp_plant = value; RaisePropertyChanged("comp_plant");
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
        private Nullable<int> _ref_item_row_id;
        public Nullable<int> ref_item_row_id
        {
            get { return _ref_item_row_id; }
            set
            {
                if (_ref_item_row_id != value)
                {
                    _ref_item_row_id = value; RaisePropertyChanged("ref_item_row_id");
                }
            }
        }
        private Nullable<System.DateTime> _dead_date;
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
        private string _activity_goal;
        public string activity_goal
        {
            get { return _activity_goal; }
            set
            {
                if (_activity_goal != value)
                {
                    _activity_goal = value; RaisePropertyChanged("activity_goal");
                }
            }
        }
        private string _activity_cat;
        public string activity_cat
        {
            get { return _activity_cat; }
            set
            {
                if (_activity_cat != value)
                {
                    _activity_cat = value; RaisePropertyChanged("activity_cat");
                }
            }
        }
        private string _ind_privacy;
        public string ind_privacy
        {
            get { return _ind_privacy; }
            set
            {
                if (_ind_privacy != value)
                {
                    _ind_privacy = value; RaisePropertyChanged("ind_privacy");
                }
            }
        }
        private string _activity_depend;
        public string activity_depend
        {
            get { return _activity_depend; }
            set
            {
                if (_activity_depend != value)
                {
                    _activity_depend = value; RaisePropertyChanged("activity_depend");
                }
            }
        }
        private string _sub_task;
        public string sub_task
        {
            get { return _sub_task; }
            set
            {
                if (_sub_task != value)
                {
                    _sub_task = value; RaisePropertyChanged("sub_task");
                }
            }
        }
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
        public string XmlDataDocument_ItemsEntity { get; set; }
        public string BackFlipEntity { get; set; }
        }
    public class TSK_T001_D : ObjectBase
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
                if (_active!= value)
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
    public class TSK_T001_E : ObjectBase
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
                { _Emp_Type = value; RaisePropertyChanged("Emp_Type"); }
            }
        }


        private string _role_code;
        public string role_code
        {
            get { return _role_code; }
            set
            {
                if (_role_code != value)
                { _role_code = value; RaisePropertyChanged("role_code"); }
            }
        }

        private bool _active;
        public bool active
        {
            get { return _active; }
            set
            {
                if (_active != value)
                { _active = value; RaisePropertyChanged("active"); }
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
                { _add_date = value; RaisePropertyChanged("add_date"); }
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
    public class TSK_T001_C_BackFlip : ObjectBase
    {


        public static event EventHandler ModelEntityUpdated = delegate { };
        private int _id;
        private string _doc_no;
        private Nullable<System.DateTime> _doc_date;
        private string _doc_type;
        private string _doc_cat;
        private string _act_action;
        private string _owner;
        private string _place;
        private string _address;
        private string _act_desc;
        private string _PartyId;
        private string _priority;
        private Nullable<System.DateTime> _start_date;
        private string _from_time;
        private Nullable<System.DateTime> _end_date;
        private string _to_time;
        private Nullable<System.DateTime> _close_date;
        private string _stage_id;
        private string _cat_id;
        private string _section_id;
        private string _note;
        private string _lead_id;
        private string _lead_title;
        private string _sono;
        private string _contact_person;
        private string _person_number;
        private string _activity_type;
        private Nullable<bool> _active;
        private string _t_status;
        private string _add_by;
        private Nullable<System.DateTime> _add_date;
        private string _editby;
        private Nullable<System.DateTime> _edit_date;
        private string _parent_activity;
        private string _action_type;
        private string _EmpName;
        private string _fin_year;
        private string _location_Id;
        private string _comp_code;
        private string _posting_period;
        private string _s_status;
        private string _so_code;
        private string _sg_code;
        private string _EmailId;
        private string _project_name;
        private string _project_location;
        private string _project_type;
        private string _architect_grade;
        private string _para1;
        private string _para2;
        private string _para3;
        private string _para4;
        private string _para5;
        private Nullable<System.DateTime> _pay_expected_date;
        private Nullable<decimal> _payment;
        private string _architect_name;
        private string _party_name;
        private Nullable<System.DateTime> _act_date;
        private string _duration;
        private string _prospectus;

        public int id
        {
            get
            {
                return _id;
            }

            set
            {
                if (_id != value)
                {
                    _id = value; RaisePropertyChanged("id", ModelEntityUpdated);
                }
            }
        }
        public string doc_no
        {
            get
            {
                return _doc_no;
            }

            set
            {
                if (_doc_no != value)
                {
                    _doc_no = value; RaisePropertyChanged("doc_no", ModelEntityUpdated);
                }
            }
        }

        public DateTime? doc_date
        {
            get
            {
                return _doc_date;
            }

            set
            {
                if (_doc_date != value)
                {
                    _doc_date = value; RaisePropertyChanged("doc_date", ModelEntityUpdated);
                }
            }
        }

        public string doc_type
        {
            get
            {
                return _doc_type;
            }

            set
            {
                if (_doc_type != value)
                {
                    _doc_type = value; RaisePropertyChanged("doc_type", ModelEntityUpdated);
                }
            }
        }

        public string doc_cat
        {
            get
            {
                return _doc_cat;
            }

            set
            {
                if (_doc_cat != value)
                {
                    _doc_cat = value; RaisePropertyChanged("doc_cat", ModelEntityUpdated);
                }
            }
        }

        public string act_action
        {
            get
            {
                return _act_action;
            }

            set
            {
                if (_act_action != value)
                {
                    _act_action = value; RaisePropertyChanged("act_action", ModelEntityUpdated);
                }
            }
        }

        public string owner
        {
            get
            {
                return _owner;
            }

            set
            {
                if (_owner != value)
                {
                    _owner = value; RaisePropertyChanged("owner", ModelEntityUpdated);
                }
            }
        }

        public string place
        {
            get
            {
                return _place;
            }

            set
            {
                if (_place != value)
                {
                    _place = value; RaisePropertyChanged("place", ModelEntityUpdated);
                }
            }
        }

        public string address
        {
            get
            {
                return _address;
            }

            set
            {
                if (_address != value)
                {
                    _address = value; RaisePropertyChanged("address", ModelEntityUpdated);
                }
            }
        }

        public string act_desc
        {
            get
            {
                return _act_desc;
            }

            set
            {
                if (_act_desc != value)
                {
                    _act_desc = value; RaisePropertyChanged("act_desc", ModelEntityUpdated);
                }
            }
        }

        public string PartyId
        {
            get
            {
                return _PartyId;
            }

            set
            {
                if (_PartyId != value)
                {
                    _PartyId = value; RaisePropertyChanged("partyId", ModelEntityUpdated);
                }
            }
        }

        public string priority
        {
            get
            {
                return _priority;
            }

            set
            {
                if (_priority != value)
                {
                    _priority = value; RaisePropertyChanged("priority", ModelEntityUpdated);
                }
            }
        }

        public DateTime? start_date
        {
            get
            {
                return _start_date;
            }

            set
            {
                if (_start_date != value)
                {
                    _start_date = value; RaisePropertyChanged("start_date", ModelEntityUpdated);
                }
            }
        }

        public string from_time
        {
            get
            {
                return _from_time;
            }

            set
            {
                if (_from_time != value)
                {
                    _from_time = value; RaisePropertyChanged("from_time", ModelEntityUpdated);
                }
            }
        }

        public DateTime? end_date
        {
            get
            {
                return _end_date;
            }

            set
            {
                if (_end_date != value)
                {
                    _end_date = value; RaisePropertyChanged("end_date", ModelEntityUpdated);
                }
            }
        }

        public string to_time
        {
            get
            {
                return _to_time;
            }

            set
            {
                if (_to_time != value)
                {
                    _to_time = value; RaisePropertyChanged("to_time", ModelEntityUpdated);
                }
            }
        }

        public DateTime? close_date
        {
            get
            {
                return _close_date;
            }

            set
            {
                if (_close_date != value)
                {
                    _close_date = value; RaisePropertyChanged("close_date", ModelEntityUpdated);
                }
            }
        }


        public string stage_id
        {
            get
            {
                return _stage_id;
            }

            set
            {
                if (_stage_id != value)
                {
                    _stage_id = value; RaisePropertyChanged("stage_id", ModelEntityUpdated);
                }
            }
        }

        public string cat_id
        {
            get
            {
                return _cat_id;
            }

            set
            {
                if (_cat_id != value)
                {
                    _cat_id = value; RaisePropertyChanged("cat_id", ModelEntityUpdated);
                }
            }
        }

        public string section_id
        {
            get
            {
                return _section_id;
            }

            set
            {
                if (_section_id != value)
                {
                    _section_id = value; RaisePropertyChanged("section_id", ModelEntityUpdated);
                }
            }
        }

        public string note
        {
            get
            {
                return _note;
            }

            set
            {
                if (_note != value)
                {
                    _note = value; RaisePropertyChanged("note", ModelEntityUpdated);
                }
            }
        }

        public string lead_id
        {
            get
            {
                return _lead_id;
            }

            set
            {
                if (_lead_id != value)
                {
                    _lead_id = value; RaisePropertyChanged("lead_id", ModelEntityUpdated);
                }
            }
        }

        public string lead_title
        {
            get
            {
                return _lead_title;
            }

            set
            {
                if (_lead_title != value)
                {
                    _lead_title = value; RaisePropertyChanged("lead_title", ModelEntityUpdated);
                }
            }
        }

        public string sono
        {
            get
            {
                return _sono;
            }

            set
            {
                if (_sono != value)
                {
                    _sono = value; RaisePropertyChanged("sono", ModelEntityUpdated);
                }
            }
        }

        public string contact_person
        {
            get
            {
                return _contact_person;
            }

            set
            {
                if (_contact_person != value)
                {
                    _contact_person = value; RaisePropertyChanged("contact_person", ModelEntityUpdated);
                }
            }
        }

        public string person_number
        {
            get
            {
                return _person_number;
            }

            set
            {
                if (_person_number != value)
                {
                    _person_number = value; RaisePropertyChanged("person_number", ModelEntityUpdated);
                }
            }
        }

        public string activity_type
        {
            get
            {
                return _activity_type;
            }

            set
            {
                if (_activity_type != value)
                {
                    _activity_type = value; RaisePropertyChanged("activity_type", ModelEntityUpdated);
                }
            }
        }

        public bool? active
        {
            get
            {
                return _active;
            }

            set
            {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active", ModelEntityUpdated);
                }
            }
        }

        public string t_status
        {
            get
            {
                return _t_status;
            }

            set
            {
                if (_t_status != value)
                {
                    _t_status = value; RaisePropertyChanged("t_status", ModelEntityUpdated);
                }
            }
        }

        public string add_by
        {
            get
            {
                return _add_by;
            }

            set
            {
                if (_add_by != value)
                {
                    _add_by = value; RaisePropertyChanged("add_by", ModelEntityUpdated);
                }
            }
        }

        public DateTime? add_date
        {
            get
            {
                return _add_date;
            }

            set
            {
                if (_add_date != value)
                {
                    _add_date = value; RaisePropertyChanged("add_date", ModelEntityUpdated);
                }
            }
        }

        public string editby
        {
            get
            {
                return _editby;
            }

            set
            {
                if (_editby != value)
                {
                    _editby = value; RaisePropertyChanged("editby", ModelEntityUpdated);
                }
            }
        }

        public DateTime? edit_date
        {
            get
            {
                return _edit_date;
            }

            set
            {
                if (_edit_date != value)
                {
                    _edit_date = value; RaisePropertyChanged("edit_date", ModelEntityUpdated);
                }
            }
        }

        public string parent_activity
        {
            get
            {
                return _parent_activity;
            }

            set
            {
                if (_parent_activity != value)
                {
                    _parent_activity = value; RaisePropertyChanged("parent_activity", ModelEntityUpdated);
                }
            }
        }

        public string action_type
        {
            get
            {
                return _action_type;
            }

            set
            {
                if (_action_type != value)
                {
                    _action_type = value; RaisePropertyChanged("action_type", ModelEntityUpdated);
                }
            }
        }
        public string EmpName
        {
            get
            {
                return _EmpName;
            }

            set
            {
                if (_EmpName != value)
                {
                    _EmpName = value; RaisePropertyChanged("EmpName", ModelEntityUpdated);
                }
            }
        }

        private string _EmpNameDisplay;
        public string EmpNameDisplay
        {
            get
            {
                return _EmpNameDisplay;
            }

            set
            {
                if (_EmpNameDisplay != value)
                {
                    _EmpNameDisplay = value; RaisePropertyChanged("EmpNameDisplay");
                }
            }
        }
        public string fin_year
        {
            get
            {
                return _fin_year;
            }

            set
            {
                if (_fin_year != value)
                {
                    _fin_year = value; RaisePropertyChanged("fin_year", ModelEntityUpdated);
                }
            }
        }
        public string location_Id
        {
            get
            {
                return _location_Id;
            }

            set
            {
                if (_location_Id != value)
                {
                    _location_Id = value; RaisePropertyChanged("location_Id", ModelEntityUpdated);
                }
            }
        }
        public string comp_code
        {
            get
            {
                return _comp_code;
            }

            set
            {
                if (_comp_code != value)
                {
                    _comp_code = value; RaisePropertyChanged("comp_code", ModelEntityUpdated);
                }
            }
        }
        public string posting_period
        {
            get
            {
                return _posting_period;
            }

            set
            {
                if (_posting_period != value)
                {
                    _posting_period = value; RaisePropertyChanged("  posting_period", ModelEntityUpdated);
                }
            }
        }

        public string s_status
        {
            get
            {
                return _s_status;
            }

            set
            {
                if (_s_status != value)
                {
                    _s_status = value; RaisePropertyChanged("s_status", ModelEntityUpdated);
                }
            }
        }
        public string so_code
        {
            get
            {
                return _so_code;
            }

            set
            {
                if (_so_code != value)
                {
                    _so_code = value; RaisePropertyChanged("so_code", ModelEntityUpdated);
                }
            }
        }

        public string sg_code
        {
            get
            {
                return _sg_code;
            }

            set
            {
                if (_sg_code != value)
                {
                    _sg_code = value; RaisePropertyChanged("sg_code", ModelEntityUpdated);
                }
            }
        }

        public string EmailId
        {
            get
            {
                return _EmailId;
            }

            set
            {
                if (_EmailId != value)
                {
                    _EmailId = value; RaisePropertyChanged("EmailId", ModelEntityUpdated);
                }
            }
        }

        public string project_name
        {
            get
            {
                return _project_name;
            }

            set
            {
                if (_project_name != value)
                {
                    _project_name = value; RaisePropertyChanged("project_name", ModelEntityUpdated);
                }
            }
        }

        public string project_location
        {
            get
            {
                return _project_location;
            }

            set
            {
                if (_project_location != value)
                {
                    _project_location = value; RaisePropertyChanged("project_location", ModelEntityUpdated);
                }
            }
        }

        public string project_type
        {
            get
            {
                return _project_type;
            }

            set
            {
                if (_project_type != value)
                {
                    _project_type = value; RaisePropertyChanged("project_type", ModelEntityUpdated);
                }
            }
        }
        public string architect_grade
        {
            get
            {
                return _architect_grade;
            }

            set
            {
                if (_architect_grade != value)
                {
                    _architect_grade = value; RaisePropertyChanged("architect_grade", ModelEntityUpdated);
                }
            }
        }

        public string para1
        {
            get
            {
                return _para1;
            }

            set
            {
                if (_para1 != value)
                {
                    _para1 = value; RaisePropertyChanged("para1", ModelEntityUpdated);
                }
            }
        }
        public string para2
        {
            get
            {
                return _para2;
            }

            set
            {
                if (_para2 != value)
                {
                    _para2 = value; RaisePropertyChanged("para2", ModelEntityUpdated);
                }
            }
        }
        public string para3
        {
            get
            {
                return _para3;
            }

            set
            {
                if (_para3 != value)
                {
                    _para3 = value; RaisePropertyChanged("para3", ModelEntityUpdated);
                }
            }
        }

        public string para4
        {
            get
            {
                return _para4;
            }

            set
            {
                if (_para4 != value)
                {
                    _para4 = value; RaisePropertyChanged("para4", ModelEntityUpdated);
                }
            }
        }
        public string para5
        {
            get
            {
                return _para5;
            }

            set
            {
                if (_para5 != value)
                {
                    _para5 = value; RaisePropertyChanged("para5", ModelEntityUpdated);
                }
            }
        }
        public Nullable<decimal> payment
        {
            get
            {
                return _payment;
            }

            set
            {
                if (_payment != value)
                {
                    _payment = value; RaisePropertyChanged("payment", ModelEntityUpdated);
                }
            }
        }

        public Nullable<System.DateTime> pay_expected_date
        {
            get
            {
                return _pay_expected_date;
            }

            set
            {
                if (_pay_expected_date != value)
                {
                    _pay_expected_date = value; RaisePropertyChanged("pay_expected_date", ModelEntityUpdated);
                }
            }
        }
        public string architect_name
        {
            get
            {
                return _architect_name;
            }

            set
            {
                if (_architect_name != value)
                {
                    _architect_name = value; RaisePropertyChanged("architect_name", ModelEntityUpdated);
                }
            }
        }
        public string party_name
        {
            get
            {
                return _party_name;
            }

            set
            {
                if (_party_name != value)
                {
                    _party_name = value; RaisePropertyChanged("party_name", ModelEntityUpdated);
                }
            }
        }
        public Nullable<System.DateTime> act_date
        {
            get
            {
                return _act_date;
            }

            set
            {
                if (_act_date != value)
                {
                    _act_date = value; RaisePropertyChanged("act_date", ModelEntityUpdated);
                }
            }
        }
        public string duration
        {
            get
            {
                return _duration;
            }

            set
            {
                if (_duration != value)
                {
                    _duration = value; RaisePropertyChanged("duration", ModelEntityUpdated);
                }
            }
        }
        public string prospectus
        {
            get
            {
                return _prospectus;
            }

            set
            {
                if (_prospectus != value)
                {
                    _prospectus = value; RaisePropertyChanged("prospectus", ModelEntityUpdated);
                }
            }
        }

        private int _folder_id;
        public int folder_id
        {
            get { return _folder_id; }
            set
            {
                if (_folder_id != value)
                {
                    _folder_id = value; RaisePropertyChanged("folder_id");
                }
            }
        }

        private string _assign_by;
        public string assign_by
        {
            get { return _assign_by; }
            set
            {
                if (_assign_by != value)
                {
                    _assign_by = value; RaisePropertyChanged("assign_by");
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

        private Nullable<int> _doc_id;
        public Nullable<int> doc_id
        {
            get { return _doc_id; }
            set
            {
                if (_doc_id != value)
                {
                    _doc_id = value; RaisePropertyChanged("doc_id");
                }
            }
        }


        private Nullable<bool> _completed;
        public Nullable<bool> completed
        {
            get { return _completed; }
            set
            {
                if (_completed != value)
                {
                    _completed = value; RaisePropertyChanged("completed");
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

        private string _po_code;
        public string po_code
        {
            get { return _po_code; }
            set
            {
                if (_po_code != value)
                {
                    _po_code = value; RaisePropertyChanged("po_code");
                }
            }
        }

        private string _pg_code;
        public string pg_code
        {
            get { return _pg_code; }
            set
            {
                if (_pg_code != value)
                {
                    _pg_code = value; RaisePropertyChanged("pg_code");
                }
            }
        }

        private string _ind_assist;
        public string ind_assist
        {
            get { return _ind_assist; }
            set
            {
                if (_ind_assist != value)
                {
                    _ind_assist = value; RaisePropertyChanged("ind_assist");
                }
            }
        }

        private string _assist_doc_no;
        public string assist_doc_no
        {
            get { return _assist_doc_no; }
            set
            {
                if (_assist_doc_no != value)
                {
                    _assist_doc_no = value; RaisePropertyChanged("assist_doc_no");
                }
            }
        }

        private string _sch_no;
        public string sch_no
        {
            get { return _sch_no; }
            set
            {
                if (_sch_no != value)
                {
                    _sch_no = value; RaisePropertyChanged("sch_no");
                }
            }
        }

        private bool _Click;
        public bool Click
        {
            get
            {
                return _Click;
            }
            set
            {
                if (_Click != value)
                {
                    _Click = value;
                    RaisePropertyChanged("Click");
                }
            }
        }
        private bool _Check;
        public bool Check
        {
            get
            {
                return _Check;
            }
            set
            {
                if (_Check != value)
                {
                    _Check = value;
                    RaisePropertyChanged("Check");
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

        private Nullable<int> _phase_id;
        public Nullable<int> phase_id
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
        private Nullable<decimal> _plan_hours;
        public Nullable<decimal> plan_hours
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

        private Nullable<decimal> _remaining_hours;
        public Nullable<decimal> remaining_hours
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

        private Nullable<decimal> _delay_hours;
        public Nullable<decimal> delay_hours
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

        private Nullable<int> _sequence;
        public Nullable<int> sequence
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


        private Nullable<int> _procurement_id;
        public Nullable<int> procurement_id
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

        private Nullable<System.DateTime> _review_date;
        public Nullable<System.DateTime> review_date
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
        
        //Added by Priya
        private string _comp_plant;
        public string comp_plant
        {
            get { return _comp_plant; }
            set
            {
                if (_comp_plant != value)
                {
                    _comp_plant = value; RaisePropertyChanged("comp_plant");
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
        private Nullable<int> _ref_item_row_id;
        public Nullable<int> ref_item_row_id
        {
            get { return _ref_item_row_id; }
            set
            {
                if (_ref_item_row_id != value)
                {
                    _ref_item_row_id = value; RaisePropertyChanged("ref_item_row_id");
                }
            }
        }
        private Nullable<System.DateTime> _dead_date;
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
        private string _activity_goal;
        public string activity_goal
        {
            get { return _activity_goal; }
            set
            {
                if (_activity_goal != value)
                {
                    _activity_goal = value; RaisePropertyChanged("activity_goal");
                }
            }
        }
        private string _activity_cat;
        public string activity_cat
        {
            get { return _activity_cat; }
            set
            {
                if (_activity_cat != value)
                {
                    _activity_cat = value; RaisePropertyChanged("activity_cat");
                }
            }
        }
        private string _ind_privacy;
        public string ind_privacy
        {
            get { return _ind_privacy; }
            set
            {
                if (_ind_privacy != value)
                {
                    _ind_privacy = value; RaisePropertyChanged("ind_privacy");
                }
            }
        }
        private string _activity_depend;
        public string activity_depend
        {
            get { return _activity_depend; }
            set
            {
                if (_activity_depend != value)
                {
                    _activity_depend = value; RaisePropertyChanged("activity_depend");
                }
            }
        }
        private string _sub_task;
        public string sub_task
        {
            get { return _sub_task; }
            set
            {
                if (_sub_task != value)
                {
                    _sub_task = value; RaisePropertyChanged("sub_task");
                }
            }
        }
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
        public string msg_body { get; set; }
        //Extra
        public string so_name { get; set; }
        public string sg_name { get; set; }
        public string LoctnNm { get; set; }
        public string address_name { get; set; }
        public string XmlDataDocument_ItemsEntity { get; set; }
        public string BackFlipEntity { get; set; }
    }
    public class MultipleContext_TSK_T001_C
        {
            public List<TSK_T001_C_BackFlip> BackFlipEntity { get; set; }
            public List<TSK_T001_C> MasterEntity { get; set; }
            public List<ADM_M028_P> PartyMaster { get; set; }
            public List<ADM_M024_P> EmployeeMaster { get; set; }
            public List<SEL_T001_P> SalesInquiryMaster { get; set; }
            public List<TSK_T001_C_P> SheduleNumber { get; set; }
            public List<COM_T003> Attachment { get; set; }
            public List<NotificationData> NotificationData { get; set; }
            public List<ADM_M028_D_P> ContactInfo { get; set; }
            public List<SEL_T001_QN> SalesOrderAndQuotation { get; set; }        
            public ObservableCollection<TSK_T001_C> ItemEntity { get; set; }
            public List<ADM_M024_P> UnvisitedList { get; set; }
            public List<ADM_M054_P> BuyerList { get; set; }
            public List<CRM_M007_P> ActicityCatList { get; set; }

    }
    public class MultipleContext_TSK_T001_C_Bulk
    {
        public List<COM_T003> ATTACHMENT_LIST { get; set; }
        public List<STD_LIST_BE> ACTIVITY_TYPE_LIST { get; set; }
        public List<TSK_T001_C_BackFlip> BackFlipEntity { get; set; }
        public List<TSK_T001_C> MasterEntity { get; set; }
        public List<ADM_M028_P> PartyMaster { get; set; }
        public List<ADM_M024_P> EmployeeMaster { get; set; }
        public List<SEL_T001_P> SalesInquiryMaster { get; set; }
        public List<TSK_T001_C_P> SheduleNumber { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<NotificationData> NotificationData { get; set; }
        public List<ADM_M028_D_P> ContactInfo { get; set; }
        public List<SEL_T001_QN> SalesOrderAndQuotation { get; set; }
        public ObservableCollection<TSK_T001_C> BulkActivityEntity { get; set; }
        public List<ADM_M0013> STATUS_LIST { get; set; }
        public List<ADM_M0071> PARAMETERS_VALUES_LIST { get; set; }


    }
}
