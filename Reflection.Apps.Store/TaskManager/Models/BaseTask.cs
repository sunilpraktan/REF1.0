using Reflection.BusinessEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.Apps.Store.TaskManager
{
    public class BaseTask : ObjectBase, INotifyPropertyChanged
    {
        #region Properties

        public int _id;
        public int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;

                    RaisePropertyChanged("id");
                }
            }
        }

        public string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                if (_doc_no != value)
                {
                    _doc_no = value;

                    RaisePropertyChanged("doc_no");
                }
            }
        }
        public int _folder_id;
      
        public int folder_id
        {
            get { return _folder_id; }
            set
            {
                if (_folder_id != value)
                {
                    _folder_id = value;

                    RaisePropertyChanged("folder_id");
                }
            }
        }



        public string _task_desc;
      
        public string task_desc
        {
            get { return _task_desc; }
            set
            {
                if (_task_desc != value)
                {
                    _task_desc = value;

                    RaisePropertyChanged("task_desc");
                }
            }
        }
        public string _tsk_priority;
       
        public string tsk_priority
        {
            get { return _tsk_priority; }
            set
            {
                if (_tsk_priority != value)
                {
                    _tsk_priority = value;

                    RaisePropertyChanged("tsk_priority");
                }
            }
        }
        public string _est_time;
     
        public string est_time
        {
            get { return _est_time; }
            set
            {
                if (_est_time != value)
                {
                    _est_time = value;

                    RaisePropertyChanged("est_time");
                }
            }
        }
        public Nullable<System.DateTime> _start_date;
      
        public Nullable<System.DateTime> start_date
        {
            get { return _start_date; }
            set
            {
                _start_date = value;

                RaisePropertyChanged("start_date");
               
            }
        }
        public string _start_time;
      
        public string start_time
        {
            get { return _start_time; }
            set
            {
                if (_start_time != value)
                {
                    _start_time = value;

                    RaisePropertyChanged("start_time");
                }
            }
        }
        public Nullable<System.DateTime> _end_date;
       
        public Nullable<System.DateTime> end_date
        {
            get { return _end_date; }
            set
            {
                if (_end_date != value)
                {
                    _end_date = value;

                    RaisePropertyChanged("end_date");
                }
            }
        }
        public string _end_time;
     
        public string end_time
        {
            get { return _end_time; }
            set
            {
                if (_end_time != value)
                {
                    _end_time = value;

                    RaisePropertyChanged("end_time");
                }
            }
        }
        public string _assign_by;
      
        public string assign_by
        {
            get { return _assign_by; }
            set
            {
                if (_assign_by != value)
                {
                    _assign_by = value;

                    RaisePropertyChanged("assign_by");
                }
            }
        }
        public string _assign_to;
        public string assign_to
      
        {
            get { return _assign_to; }
            set
            {
                if (_assign_to != value)
                {
                    _assign_to = value;

                    RaisePropertyChanged("assign_to");
                }
            }
        }
        public string _doc_type;
      
        public string doc_type
        {
            get { return _doc_type; }
            set
            {
                if (_doc_type != value)
                {
                    _doc_type = value;

                    RaisePropertyChanged("doc_type");
                }
            }
        }
        public Nullable<int> _doc_id;
      
        public Nullable<int> doc_id
        {
            get { return _doc_id; }
            set
            {
                if (_doc_id != value)
                {
                    _doc_id = value;

                    RaisePropertyChanged("doc_id");
                }
            }
        }
        public Nullable<System.DateTime> _doc_date;
    
        public Nullable<System.DateTime> doc_date
        {
            get { return _doc_date; }
            set
            {
                if (_doc_date != value)
                {
                    _doc_date = value;

                    RaisePropertyChanged("doc_date");
                }
            }
        }
        public string _doc_cat;
     
        public string doc_cat
        {
            get { return _doc_cat; }
            set
            {
                if (_doc_cat != value)
                {
                    _doc_cat = value;

                    RaisePropertyChanged("doc_cat");
                }
            }
        }
        public Nullable<bool> _completed;
     
        public Nullable<bool> completed
        {
            get { return _completed; }
            set
            {
                if (_completed != value)
                {
                    _completed = value;

                    RaisePropertyChanged("completed");
                    OnPropertyChanged(new PropertyChangedEventArgs("completed"));
                }
            }
        }
        public string _comp_remark;
       
        public string comp_remark
        {
            get { return _comp_remark; }
            set
            {
                if (_comp_remark != value)
                {
                    _comp_remark = value;

                    RaisePropertyChanged("comp_remark");
                }
            }
        }
        public Nullable<System.DateTime> _close_date;
       
        public Nullable<System.DateTime> close_date
        {
            get { return _close_date; }
            set
            {
                if (_close_date != value)
                {
                    _close_date = value;

                    RaisePropertyChanged("close_date");
                }
            }
        }
        public string _task_type;
     
        public string task_type
        {
            get { return _task_type;; }
            set
            {
                if (_task_type != value)
                {
                    _task_type = value;

                    RaisePropertyChanged("task_type;");
                }
            }
        }
        public string _task_freq;
        
        public string task_freq
        {
            get { return _task_freq; }
            set
            {
                if (_task_freq != value)
                {
                    _task_freq = value;

                    RaisePropertyChanged("task_freq");
                }
            }
        }
        public Nullable<int> _day_freq;
      
        public Nullable<int> day_freq
        {
            get { return _day_freq; }
            set
            {
                if (_day_freq != value)
                {
                    _day_freq = value;

                    RaisePropertyChanged("day_freq");
                }
            }
        }
        public Nullable<int> _freq_no;
     
        public Nullable<int> freq_no
        {
            get { return _freq_no; }
            set
            {
                if (_freq_no != value)
                {
                    _freq_no = value;

                    RaisePropertyChanged("freq_no");
                }
            }
        }
        public string _trigger_time;
      
        public string trigger_time
        {
            get { return _trigger_time; }
            set
            {
                if (_trigger_time != value)
                {
                    _trigger_time = value;

                    RaisePropertyChanged("trigger_time");
                }
            }
        }
        public string _t_status;
       
        public string t_status
        {
            get { return _t_status; }
            set
            {
                if (_t_status != value)
                {
                    _t_status = value;

                    RaisePropertyChanged("t_status");
                }
            }
        }
        public Nullable<bool> _active;
   
        public Nullable<bool> active
        {
            get { return _active; }
            set
            {
                if (_active != value)
                {
                    _active = value;

                    RaisePropertyChanged("active");
                }
            }
        }
        public string _add_by;
       
        public string add_by
        {
            get { return _add_by; }
            set
            {
                if (_add_by != value)
                {
                    _add_by = value;

                    RaisePropertyChanged("add_by");
                }
            }
        }
        public System.DateTime _add_date;
       
        public System.DateTime add_date
        {
            get { return _add_date; }
            set
            {
                if (_add_date != value)
                {
                    _add_date = value;

                    RaisePropertyChanged("add_date");
                }
            }
        }
        public string _editby;
     
        public string editby
        {
            get { return _editby; }
            set
            {
                if (_editby != value)
                {
                    _editby = value;

                    RaisePropertyChanged("editby");
                }
            }
        }
        public Nullable<System.DateTime> _edit_date;
       
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                if (_edit_date != value)
                {
                    _edit_date = value;

                    RaisePropertyChanged("edit_date");
                }
            }
        }
        public string _referring_party;
      
        public string referring_party
        {
            get { return _referring_party; }
            set
            {
                if (_referring_party != value)
                {
                    _referring_party = value;

                    RaisePropertyChanged("referring_party");
                }
            }
        }
        public string _referring_partyNm;
       
        public string referring_partyNm
        {
            get { return _referring_partyNm; }
            set
            {
                if (_referring_partyNm != value)
                {
                    _referring_partyNm = value;

                    RaisePropertyChanged("referring_partyNm");
                }
            }
        }
        public string _designation;
       
        public string designation
        {
            get { return _designation; }
            set
            {
                if (_designation != value)
                {
                    _designation = value;

                    RaisePropertyChanged("designation");
                }
            }
        }
        public string _EmailId;
       
        public string EmailId
        {
            get { return _EmailId; }
            set
            {
                if (_EmailId != value)
                {
                    _EmailId = value;

                    RaisePropertyChanged("EmailId");
                }
            }
        }
        public string _duration;
      
        public string duration
        {
            get { return _duration; }
            set
            {
                if (_duration != value)
                {
                    _duration = value;

                    RaisePropertyChanged("duration");
                }
            }
        }
        public string _stage_id;
      
        public string stage_id
        {
            get { return _stage_id; }
            set
            {
                if (_stage_id != value)
                {
                    _stage_id = value;

                    RaisePropertyChanged("stage_id");
                }
            }
        }
        public string _cat_id;
      
        public string cat_id
        {
            get { return _cat_id; }
            set
            {
                if (_cat_id != value)
                {
                    _cat_id = value;

                    RaisePropertyChanged("cat_id");
                }
            }
        }
        public string _section_id;
      
        public string section_id
        {
            get { return _section_id; }
            set
            {
                if (_section_id != value)
                {
                    _section_id = value;

                    RaisePropertyChanged("section_id");
                }
            }
        }
        public string _note;
    
        public string note
        {
            get { return _note; }
            set
            {
                if (_note != value)
                {
                    _note = value;

                    RaisePropertyChanged("note");
                }
            }
        }
        public string _lead_id;
     
        public string lead_id
        {
            get { return _lead_id; }
            set
            {
                if (_lead_id != value)
                {
                    _lead_id = value;

                    RaisePropertyChanged("lead_id");
                }
            }
        }
        public string _lead_title;
       
        public string lead_title
        {
            get { return _lead_title; }
            set
            {
                if (_lead_title != value)
                {
                    _lead_title = value;

                    RaisePropertyChanged("lead_title");
                }
            }
        }
        public string _sono;
       
        public string sono
        {
            get { return _sono; }
            set
            {
                if (_sono != value)
                {
                    _sono = value;

                    RaisePropertyChanged("sono");
                }
            }
        }
        public string _contact_person;
       
        public string contact_person
        {
            get { return _contact_person; }
            set
            {
                if (_contact_person != value)
                {
                    _contact_person = value;

                    RaisePropertyChanged("contact_person");
                }
            }
        }
        public string _person_number;
      
        public string person_number
        {
            get { return _person_number; }
            set
            {
                if (_person_number != value)
                {
                    _person_number = value;

                    RaisePropertyChanged("person_number");
                }
            }
        }
        public string _activity_type;
      
        public string activity_type
        {
            get { return _activity_type; }
            set
            {
                if (_activity_type != value)
                {
                    _activity_type = value;

                    RaisePropertyChanged("activity_type");
                }
            }
        }
        public string _action_type;

        public string action_type
        {
            get { return _action_type; }
            set
            {
                if (_action_type != value)
                {
                    _action_type = value;

                    RaisePropertyChanged("action_type");
                }
            }
        }
        public string _act_summary;
      
        public string act_summary
        {
            get { return _act_summary; }
            set
            {
                if (_act_summary != value)
                {
                    _act_summary = value;

                    RaisePropertyChanged("act_summary");
                }
            }
        }
        public Nullable<System.DateTime> _act_date;
      
        public Nullable<System.DateTime> act_date
        {
            get { return _act_date; }
            set
            {
                if (_act_date != value)
                {
                    _act_date = value;

                    RaisePropertyChanged("act_date");
                }
            }
        }
        public string _act_time;
      
        public string act_time
        {
            get { return _act_time; }
            set
            {
                if (_act_time != value)
                {
                    _act_time = value;

                    RaisePropertyChanged("act_time");
                }
            }
        }
        public string _act_desc;
      
        public string act_desc
        {
            get { return _act_desc; }
            set
            {
                if (_act_desc != value)
                {
                    _act_desc = value;

                    RaisePropertyChanged("act_desc");
                }
            }
        }
        public string _act_action;
       
        public string act_action
        {
            get { return _act_action; }
            set
            {
                if (_act_action != value)
                {
                    _act_action = value;

                    RaisePropertyChanged("act_action");
                }
            }
        }
        public string _parent_activity;
      
        public string parent_activity
        {
            get { return _parent_activity; }
            set
            {
                if (_parent_activity != value)
                {
                    _parent_activity = value;

                    RaisePropertyChanged("parent_activity");
                }
            }
        }
        public string _location_Id;
       
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                if (_location_Id != value)
                {
                    _location_Id = value;

                    RaisePropertyChanged("location_Id");
                }
            }
        }
        public string _comp_code;
       
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                if (_comp_code != value)
                {
                    _comp_code = value;

                    RaisePropertyChanged("comp_code");
                }
            }
        }
        public string _fin_year;
       
        public string fin_year
        {
            get { return _fin_year; }
            set
            {
                if (_fin_year != value)
                {
                    _fin_year = value;

                    RaisePropertyChanged("fin_year");
                }
            }
        }
        public string _posting_period;
     
        public string posting_period
        {
            get { return _posting_period; }
            set
            {
                if (_posting_period != value)
                {
                    _posting_period = value;

                    RaisePropertyChanged("posting_period");
                }
            }
        }
        public string _place;
      
        public string place
        {
            get { return _place; }
            set
            {
                if (_place != value)
                {
                    _place = value;

                    RaisePropertyChanged("place");
                }
            }
        }
        public string _address;
       
        public string address
        {
            get { return _address; }
            set
            {
                if (_address != value)
                {
                    _address = value;

                    RaisePropertyChanged("address");
                }
            }
        }
        public Nullable<bool> _visiblity_user;
   
        public Nullable<bool> visiblity_user
        {
            get { return _visiblity_user; }
            set
            {
                if (_visiblity_user != value)
                {
                    _visiblity_user = value;

                    RaisePropertyChanged("visiblity_user");
                }
            }
        }
        public string _other_participants;
      
        public string other_participants
        {
            get { return _other_participants; }
            set
            {
                if (_other_participants != value)
                {
                    _other_participants = value;

                    RaisePropertyChanged("other_participants");
                }
            }
        }
        public string _s_status;
        public string s_status
        {
            get { return _s_status; }
            set
            {
                if (_s_status != value)
                {
                    _s_status = value;

                    RaisePropertyChanged("s_status");
                }
            }
        }

        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }


        private bool? m_isImportant = null;
        public bool? IsImportant
        {
            get { return m_isImportant; }
            set
            {
                if (value != m_isImportant)
                {
                    m_isImportant = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("IsImportant"));
                }
            }
        }



        private Nullable<DateTime> m_due;
        public Nullable<DateTime> Due
        {
            get { return m_due; }
            set
            {
                if (value != m_due)
                {
                    m_due = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Due"));
                }
            }
        }
        //end of set priority

        //Scaler Value


        public string _AssignToUser;
        public string AssignToUser
        {
            get { return _AssignToUser; }
            set
            {
                if (_AssignToUser != value)
                {
                    _AssignToUser = value;

                    RaisePropertyChanged("AssignToUser");
                }
            }
        }

        public string _assign_by_name;
        public string assign_by_name
        {
            get { return _assign_by_name; }
            set
            {
                if (_assign_by_name != value)
                {
                    _assign_by_name = value;

                    RaisePropertyChanged("assign_by_name");
                }
            }
        }
        public string _folder_name;
        public string folder_name
        {
            get { return _folder_name; }
            set
            {
                if (_folder_name != value)
                {
                    _folder_name = value;

                    RaisePropertyChanged("folder_name");
                }
            }
        }

        public string _color_code;
        public string color_code
        {
            get { return _color_code; }
            set
            {
                if (_color_code != value)
                {
                    _color_code = value;

                    RaisePropertyChanged("color_code");
                }
            }
        }

        public Nullable<int> _folderid;
        public Nullable<int> folderid
        {
            get { return _folderid; }
            set
            {
                if (_folderid != value)
                {
                    _folderid = value;

                    RaisePropertyChanged("folderid");
                }
            }
        }


        public int FOLDERID
        {
            get;
            set;
        }
        #endregion Properties

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
            //ValidateAsync();
        }

        #endregion Events

        #region Public Methods

        public Task CloneWithFolder(Folder folder)
        {
            return new Task()
            {
                 id=this.id,
                doc_no=this.doc_no,
                folder_id = this.folder_id,
                task_desc = this.task_desc,
                tsk_priority = this.tsk_priority,
                est_time = this.est_time,
                start_date = this.start_date,
                start_time = this.start_time,
                end_date = this.end_date,
                end_time = this.end_time,
                assign_by = this.assign_by,
                assign_to = this.assign_to,
                doc_type = this.doc_type,
                doc_id = this.doc_id,
                doc_date = this.doc_date,
                doc_cat = this.doc_cat,
                completed = this.completed,
                comp_remark = this.comp_remark,
                close_date = this.close_date,
                task_type = this.task_type,
                task_freq = this.task_freq,
                day_freq = this.day_freq,
                freq_no = this.freq_no,
                trigger_time = this.trigger_time,
                t_status = this.t_status,
                active = this.active,
                add_by = this.add_by,
                add_date = this.add_date,
                editby = this.editby,
                edit_date = this.edit_date,
                referring_party = this.referring_party,
                referring_partyNm = this.referring_partyNm,
                designation = this.designation,
                EmailId = this.EmailId,
                duration = this.duration,
                stage_id = this.stage_id,
                cat_id = this.cat_id,
                section_id = this.section_id,
                note = this.note,
                lead_id = this.lead_id,
                lead_title = this.lead_title,
                sono = this.sono,
                contact_person = this.contact_person,
                person_number = this.person_number,
                activity_type = this.activity_type,
                action_type = this.action_type,
                act_summary = this.act_summary,
                act_date = this.act_date,
                act_time = this.act_time,
                act_desc = this.act_desc,
                act_action = this.act_action,
                parent_activity = this.parent_activity,
                location_Id = this.location_Id,
                comp_code = this.comp_code,
                fin_year = this.fin_year,
                posting_period = this.posting_period,
                place = this.place,
                address = this.address,
                visiblity_user = this.visiblity_user,
                other_participants = this.other_participants,
                s_status = this.s_status,
                AssignToUser = this.AssignToUser,
                assign_by_name = this.assign_by_name,
                folder_name = this.folder_name,
                color_code = this.color_code,
                folderid = this.folderid,


            };
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}",
                base.ToString(),
                _task_desc);
        }

        #endregion Public Methods

        
        

    }
}
