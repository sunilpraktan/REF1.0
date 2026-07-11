using Reflection.BusinessEntity.ADM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.HRMS
{
    public class HRM_M016 : ObjectBase
    {
        private string _equ_id;
        public string equ_id
        {
            get { return _equ_id; }
            set
            {
                if (_equ_id != value)
                {
                    _equ_id = value; RaisePropertyChanged("equ_id");
                }
            }
        }
        private string _equ_name;
        public string equ_name
        {
            get { return _equ_name; }
            set
            {
                if (_equ_name != value)
                {
                    _equ_name = value; RaisePropertyChanged("equ_name");
                }
            }
        }
        private string _dev_code;
        public string dev_code
        {
            get { return _dev_code; }
            set
            {
                if (_dev_code != value)
                {
                    _dev_code = value; RaisePropertyChanged("dev_code");
                }
            }
        }
        private string _dev_serial_no;
        public string dev_serial_no
        {
            get { return _dev_serial_no; }
            set
            {
                if (_dev_serial_no != value)
                {
                    _dev_serial_no = value; RaisePropertyChanged("dev_serial_no");
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
        private string _boud_rate;
        public string boud_rate
        {
            get { return _boud_rate; }
            set
            {
                if (_boud_rate != value)
                {
                    _boud_rate = value; RaisePropertyChanged("boud_rate");
                }
            }
        }
        private string _tcp_ip;
        public string tcp_ip
        {
            get { return _tcp_ip; }
            set
            {
                if (_tcp_ip != value)
                {
                    _tcp_ip = value; RaisePropertyChanged("tcp_ip");
                }
            }
        }
        private string _mac_add;
        public string mac_add
        {
            get { return _mac_add; }
            set
            {
                if (_mac_add != value)
                {
                    _mac_add = value; RaisePropertyChanged("mac_add");
                }
            }
        }
        private string _port;
        public string port
        {
            get { return _port; }
            set
            {
                if (_port != value)
                {
                    _port = value; RaisePropertyChanged("port");
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
        public string XmlDataDocument_HRM_M016_A { get; set; }
        public string XmlDataDocument_HRM_M016_Flip { get; set; }
    }
    public class HRM_M016_A : ObjectBase
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

        private string _equ_id;
        public string equ_id
        {
            get { return _equ_id; }
            set
            {
                if (_equ_id != value)
                {
                    _equ_id = value; RaisePropertyChanged("equ_id");
                }
            }
        }
        private string _control_code;
        public string control_code
        {
            get { return _control_code; }
            set
            {
                if (_control_code != value)
                {
                    _control_code = value; RaisePropertyChanged("control_code");
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
        private string _control_desc;
        public string control_desc
        {
            get { return _control_desc; }
            set
            {
                if (_control_desc != value)
                {
                    _control_desc = value;
                    RaisePropertyChanged("control_desc");
                }
            }
        }
      
    }
    public class HRM_M016_BackFlip
    {
        public string equ_id { get; set; }
        public string equ_name { get; set; }
        public string dev_code { get; set; }
        public string t_status { get; set; }
    }
    public class MultipleContext_HRM_M016
    {
        public ObservableCollection<HRM_M016> EquipmentList { get; set; }
        public ObservableCollection<HRM_M016_A> ControlDescList { get; set; }
        public List<HRM_M016_BackFlip> BackFlipEntity { get; set; }
        public List<ADM_M0013> StatusList { get; set; }
        public List<SYS_M028_P> ControlList { get; set; }
    }
}