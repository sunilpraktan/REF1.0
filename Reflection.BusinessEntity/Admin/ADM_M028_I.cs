using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Admin
{
    public partial class ADM_M028_I : ObjectBase //Master
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
        private string _wtax_type;
        public string wtax_type
        {
            get { return _wtax_type; }
            set
            {
                if (_wtax_type != value)
                {
                    _wtax_type = value; RaisePropertyChanged("wtax_type");
                }
            }
        }
        private string _wtax_code;
        public string wtax_code
        {
            get { return _wtax_code; }
            set
            {
                if (_wtax_code != value)
                {
                    _wtax_code = value; RaisePropertyChanged("wtax_code");
                }
            }
        }
        private string _exemption_no;
        public string exemption_no
        {
            get { return _exemption_no; }
            set
            {
                if (_exemption_no != value)
                {
                    _exemption_no = value; RaisePropertyChanged("exemption_no");
                }
            }
        }
        private string _exemption_rate;
        public string exemption_rate
        {
            get { return _exemption_rate; }
            set
            {
                if (_exemption_rate != value)
                {
                    _exemption_rate = value; RaisePropertyChanged("exemption_rate");
                }
            }
        }
        private Nullable<System.DateTime> _exemp_start_date;
        public Nullable<System.DateTime> exemp_start_date
        {
            get { return _exemp_start_date; }
            set
            {
                if (_exemp_start_date != value)
                {
                    _exemp_start_date = value; RaisePropertyChanged("exemp_start_date");
                }
            }
        }
        private Nullable<System.DateTime> _exemp_end_date;
        public Nullable<System.DateTime> exemp_end_date
        {
            get { return _exemp_end_date; }
            set
            {
                if (_exemp_end_date != value)
                {
                    _exemp_end_date = value; RaisePropertyChanged("exemp_end_date");
                }
            }
        }


        private string _exemption_reason;
        public string exemption_reason
        {
            get { return _exemption_reason; }
            set
            {
                if (_exemption_reason != value)
                {
                    _exemption_reason = value; RaisePropertyChanged("exemption_reason");
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

        private bool _Click;
        public bool Click
        {
            get { return _Click; }
            set { _Click = value; RaisePropertyChanged("Click"); }
        }
        //XML doc
        public string XmlDataDocument_ADM_M028_I { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }
    
    }
   

    public class MultipleContext_ADM_M028_I
        {
            public List<ADM_M028_I_Flip> DocumentDataFlipGrid { get; set; }
            public ObservableCollection<ADM_M028_I> MasterEntity { get; set; }
            public List<ADM_M028_P> PartyList { get; set; }
            public List<ACC_M025_P> TaxTypeCodeList { get; set; }
            public List<ACC_M025_A_P> TaxTypeList { get; set; }
        }
}
