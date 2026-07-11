using Reflection.BusinessEntity.ADM;
using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity.CustomerRelation
{
    public class Approval:ObjectBase
    {
        private int _srno;
        public int srno
        {
            get
            {
                return _srno;
            }

            set
            {
                if (_srno != value)
                {
                    _srno = value;
                    RaisePropertyChanged("srno");
                }                
            }
        }
        private string _id;
        public string id
        {
            get
            {
                return _id;
            }

            set
            {
                if (_id != value)
                {
                    _id = value;
                    RaisePropertyChanged("id");
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
                if (_Click = value)
                {
                    _Click = value;
                    RaisePropertyChanged("Click");
                }               
            }
        }
 
        private string _doc_type;
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
                    _doc_type = value;

                    RaisePropertyChanged("doc_type");
                }               
            }
        }

        private string _doc_no;
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
                    _doc_no = value;
                    RaisePropertyChanged("doc_no");
                }               
            }
        }

        private string _doc_cat;
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
                    _doc_cat = value;
                    RaisePropertyChanged("doc_cat");
                }          
            }
        }

        private string _workflow_id;
        public string workflow_id
        {
            get
            {
                return _workflow_id;
            }

            set
            {
                if (_workflow_id != value)
                {
                    _workflow_id = value;
                    RaisePropertyChanged("workflow_id");
                }                
            }
        }

        private string _approver_id;
        public string approver_id
        {
            get
            {
                return _approver_id;
            }

            set
            {
                if (_approver_id != value)
                {
                    _approver_id = value;
                    RaisePropertyChanged("approver_id");
                }                
            }
        }

        private string _UserId;
        public string UserId
        {
            get
            {
                return _UserId;
            }

            set
            {
                if (_UserId != value)
                {
                    _UserId = value;
                    RaisePropertyChanged("UserId");
                }              
            }
        }

        private string _authority;
        public string authority
        {
            get
            {
                return _authority;
            }

            set
            {
                if (_authority != value)
                {
                    _authority = value;
                    RaisePropertyChanged("authority");
                }                
            }
        }

        private string _appro_status;
        public string appro_status
        {
            get
            {
                return _appro_status;
            }

            set
            {
                if (_appro_status != value)
                {
                    _appro_status = value;
                    RaisePropertyChanged("appro_status");
                }                
            }
        }

        private Nullable<System.DateTime> _appro_date;
        public DateTime? appro_date
        {
            get
            {
                return _appro_date;
            }

            set
            {
                if (_appro_date != value)
                {
                    _appro_date = value;
                    RaisePropertyChanged("appro_date");
                }                
            }
        }

        private string _read_status;
        public string read_status
        {
            get
            {
                return _read_status;
            }

            set
            {
                if (_read_status != value)
                {
                    _read_status = value;
                    RaisePropertyChanged("read_status");
                }               
            }
        }

        private Nullable<System.DateTime> _read_date;
        public DateTime? read_date
        {
            get
            {
                return _read_date;
            }

            set
            {
                if (_read_date != value)
                {
                    _read_date = value;
                    RaisePropertyChanged("read_date");
                }                
            }
        }

        private string _remarks;
        public string remarks
        {
            get
            {
                return _remarks;
            }

            set
            {
                if (_remarks != value)
                {
                    _remarks = value;
                    RaisePropertyChanged("remarks");
                }                
            }
        }

        private string _ref_id;
        public string ref_id
        {
            get
            {
                return _ref_id;
            }

            set
            {
                if (_ref_id != value)
                {
                    _ref_id = value;
                    RaisePropertyChanged("ref_id");
                }                
            }
        }

        private string _forward;
        public string forward
        {
            get
            {
                return _forward;
            }

            set
            {
                if (_forward != value)
                {
                    _forward = value;
                    RaisePropertyChanged("forward");
                }
            }
        }

        private int _level_no;
        public int level_no
        {
            get
            {
                return _level_no;
            }

            set
            {
                if (_level_no != value)
                {
                    _level_no = value;
                    RaisePropertyChanged("level_no");
                }                
            }
        }

        private string _creator;
        public string creator
        {
            get
            {
                return _creator;
            }

            set
            {
                if (_creator != value)
                {
                    _creator = value;
                    RaisePropertyChanged("creator");
                }                
            }
        }

        private DateTime _create_date;
        public DateTime create_date
        {
            get
            {
                return _create_date;
            }

            set
            {
                if (_create_date != value)
                {
                    _create_date = value;
                    RaisePropertyChanged("create_date");
                }              
            }
        }

        private string _add_by;
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
                    _add_by = value;
                    RaisePropertyChanged("add_by");
                }               
            }
        }

        private DateTime _add_date;
        public DateTime add_date
        {
            get
            {
                return _add_date;
            }

            set
            {
                if (_add_date != value)
                {
                    _add_date = value;
                    RaisePropertyChanged("add_date");
                }                
            }
        }

        private string _editby;
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
                    _editby = value;
                    RaisePropertyChanged("editby");
                }                
            }
        }

        private DateTime? _edit_date;
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
                    _edit_date = value;
                    RaisePropertyChanged("edit_date");
                }              
            }
        }

        private string _TranCode;
        public string TranCode
        {
            get
            {
                return _TranCode;
            }

            set
            {
                if (_TranCode != value)
                {
                    _TranCode = value;
                    RaisePropertyChanged("TranCode");
                }               
            }
        }

        private string _doc_desc;
        public string doc_desc
        {
            get
            {
                return _doc_desc;
            }

            set
            {
                if (_doc_desc != value)
                {
                    _doc_desc = value;
                    RaisePropertyChanged("doc_desc");
                }                
            }
        }

        private string _ApproverName;
        public string ApproverName
        {
            get
            {
                return _ApproverName;
            }

            set
            {
                if (_ApproverName != value)
                {
                    _ApproverName = value;
                    RaisePropertyChanged("ApproverName");
                }                
            }
        }

        private string _ApproverEmailId;
        public string ApproverEmailId
        {
            get
            {
                return _ApproverEmailId;
            }

            set
            {
                if (_ApproverEmailId != value)
                {
                    _ApproverEmailId = value;
                    RaisePropertyChanged("ApproverEmailId");
                }                
            }
        }

        private string _CreatorName;
        public string CreatorName
        {
            get
            {
                return _CreatorName;
            }

            set
            {
                if (_CreatorName != value)
                {
                    _CreatorName = value;
                    RaisePropertyChanged("CreatorName");
                }               
            }
        }
 
        private string _CreatorEmailId;
        public string CreatorEmailId
        {
            get
            {
                return _CreatorEmailId;
            }

            set
            {
                if (_CreatorEmailId != value)
                {
                    _CreatorEmailId = value;
                    RaisePropertyChanged("CreatorEmailId");
                }               
            }
        }

        private string _note_subject;
        public string note_subject
        {
            get
            {
                return _note_subject;
            }

            set
            {
                if (_note_subject != value)
                {
                    _note_subject = value;
                    RaisePropertyChanged("note_subject");
                }                
            }
        }

        private string _note_messagebody;
        public string note_messagebody
        {
            get
            {
                return _note_messagebody;
            }

            set
            {
                if (_note_messagebody != value)
                {
                    _note_messagebody = value;
                    RaisePropertyChanged("note_messagebody");
                }                
            }
        }

        private string _approvar_remark;
        public string approvar_remark
        {
            get
            {
                return _approvar_remark;
            }

            set
            {
                if (_approvar_remark != value)
                {
                    _approvar_remark = value;
                    RaisePropertyChanged("approvar_remark");
                }               
            }
        }

        private string _sender;
        public string sender
        {
            get
            {
                return _sender;
            }

            set
            {
                if (_sender != value)
                {
                    _sender = value;
                    RaisePropertyChanged("sender");
                }                
            }
        }

        private string _record_src;
        public string record_src
        {
            get
            {
                return _record_src;
            }

            set
            {
                if (_record_src != value)
                {
                    _record_src = value;
                    RaisePropertyChanged("record_src");
                }                
            }
        }
        private string _doc_info;
        public string doc_info
        {
            get
            {
                return _doc_info;
            }

            set
            {
                if (_doc_info != value)
                {
                    _doc_info = value;
                    RaisePropertyChanged("doc_info");
                }               
            }
        }
        // Scalar Fields
        private string _ReadyToUpdate;
        public string ReadyToUpdate
        {
            get
            {
                return _ReadyToUpdate;
            }

            set
            {
                if (_ReadyToUpdate != value)
                {
                    _ReadyToUpdate = value;
                    RaisePropertyChanged("ReadyToUpdate");
                }                
            }
        }
        private string _UpdateInfo;
        public string UpdateInfo
        {
            get
            {
                return _UpdateInfo;
            }

            set
            {
                if (_UpdateInfo != value)
                {
                    _UpdateInfo = value;
                    RaisePropertyChanged("UpdateInfo");
                }                
            }
        }
        private string _t_display;
        public string t_display
        {
            get
            {
                return _t_display;
            }

            set
            {
                if (_t_display != value)
                {
                    _t_display = value;
                    RaisePropertyChanged("t_display");
                }
            }
        }
        private string _user_name;
        public string user_name
        {
            get
            {
                return _user_name;
            }

            set
            {
                if (_user_name != value)
                {
                    _user_name = value;
                    RaisePropertyChanged("user_name");
                }                
            }
        }
        private DateTime? _FrmDate;
        public DateTime? FrmDate
        {
            get
            {
                return _FrmDate;
            }
            set
            {
                if (_FrmDate != value)
                {
                    _FrmDate = value;
                    RaisePropertyChanged("FrmDate");
                }                
            }
        }

        private DateTime? _ToDate;
        public DateTime? ToDate
        {
            get
            {
                return _ToDate;
            }
            set
            {
                if (_ToDate != value)
                {
                    _ToDate = value;
                    RaisePropertyChanged("ToDate");
                }               
            }
        }

        public string _comp_code;
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
                    _comp_code = value;
                    RaisePropertyChanged("comp_code");
                }
            }
        }
        public string _location_id;
        public string location_id
        {
            get
            {
                return _location_id;
            }
            set
            {
                if (_location_id != value)
                {
                    _location_id = value;
                    RaisePropertyChanged("location_id");
                }
            }
        }
        public string _obj_code;
        public string obj_code
        {
            get
            {
                return _obj_code;
            }
            set
            {
                if (_obj_code != value)
                {
                    _obj_code = value;
                    RaisePropertyChanged("obj_code");
                }
            }
        }
        public string _obj_name;
        public string obj_name
        {
            get
            {
                return _obj_name;
            }
            set
            {
                if (_obj_name != value)
                {
                    _obj_name = value;
                    RaisePropertyChanged("obj_name");
                }
            }
        }
        public string _party_code;
        public string party_code
        {
            get
            {
                return _party_code;
            }
            set
            {
                if (_party_code != value)
                {
                    _party_code = value;
                    RaisePropertyChanged("party_code");
                }
            }
        }
        public string _party_name;
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
                    _party_name = value;
                    RaisePropertyChanged("party_name");
                }
            }
        }
        public string _order_no;
        public string order_no
        {
            get
            {
                return _order_no;
            }
            set
            {
                if (_order_no != value)
                {
                    _order_no = value;
                    RaisePropertyChanged("order_no");
                }
            }
        }
        public string _tl_code;
        public string tl_code
        {
            get
            {
                return _tl_code;
            }
            set
            {
                if (_tl_code != value)
                {
                    _tl_code = value;
                    RaisePropertyChanged("tl_code");
                }
            }
        }

    }
    public class MultipleContext_DocApprove
    {
        public List<Approval> ApprovalList { get; set; }
        public List<ADM_M043_P> WorkFlowList { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<NotificationData> NotificationData { get; set; }
        public List<ADM_M043_D_P> DocDesc { get; set; }
        public List<ADM_M024_P> Employees { get; set; }
        public List<ADM_M0013> StatusData { get; set; }
    }
}
