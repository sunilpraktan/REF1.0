using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Admin
{
    public class ADM_M053 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private string _party_id;
        public string party_id
        {
            get { return _party_id; }
            set
            {
                _party_id = value; RaisePropertyChanged("party_id");
            }
        }

        private string _PartyId;
        public string PartyId
        {
            get { return _PartyId; }
            set
            {
                _PartyId = value; RaisePropertyChanged("PartyId");
            }
        }

        private string _sal_code;
        public string sal_code
        {
            get { return _sal_code; }
            set
            {
                _sal_code = value; RaisePropertyChanged("sal_code");
            }
        }

        private string _party_name;
        public string party_name
        {
            get { return _party_name; }
            set
            {
                _party_name = value; RaisePropertyChanged("party_name");
            }
        }

        private string _abbr;
        public string abbr
        {
            get { return _abbr; }
            set
            {
                _abbr = value; RaisePropertyChanged("abbr");
            }
        }

        private string _party_type;
        public string party_type
        {
            get { return _party_type; }
            set
            {
                _party_type = value; RaisePropertyChanged("party_type");
            }
        }

        private string _party_group;
        public string party_group
        {
            get { return _party_group; }
            set
            {
                _party_group = value; RaisePropertyChanged("party_group");
            }
        }

        private string _buss_type;
        public string buss_type
        {
            get { return _buss_type; }
            set
            {
                _buss_type = value; RaisePropertyChanged("buss_type");
            }
        }
        private string _acc_group;
        public string acc_group
        {
            get { return _acc_group; }
            set
            {
                _acc_group = value; RaisePropertyChanged("acc_group");
            }
        }

        private string _refer_by;
        public string refer_by
        {
            get { return _refer_by; }
            set
            {
                _refer_by = value; RaisePropertyChanged("refer_by");
            }
        }
        private string _party_location;
        public string party_location
        {
            get { return _party_location; }
            set
            {
                _party_location = value; RaisePropertyChanged("party_location");
            }
        }
        private string _provider;
        public string provider
        {
            get { return _provider; }
            set
            {
                _provider = value; RaisePropertyChanged("provider");
            }
        }
        private byte[] _photo;
        public byte[] photo
        {
            get { return _photo; }
            set
            {
                _photo = value; RaisePropertyChanged("photo");
            }
        }
        private string _so_code;
        public string so_code
        {
            get { return _so_code; }
            set
            { _so_code = value; RaisePropertyChanged("so_code", ModelEntityUpdated); }
        }
        private string _sg_code;
        public string sg_code
        {
            get { return _sg_code; }
            set
            { _sg_code = value; RaisePropertyChanged("sg_code", ModelEntityUpdated); }
        }
        private string _responsible_contact;
        public string responsible_contact
        {
            get { return _responsible_contact; }
            set
            { _responsible_contact = value; RaisePropertyChanged("responsible_contact", ModelEntityUpdated); }
        }
        #region Default Fields
        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set
            {
                _active = value; RaisePropertyChanged("active");
            }
        }

        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set
            {
                _t_status = value;
                RaisePropertyChanged("t_status");
            }
        }

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set
            {
                _add_by = value;
                RaisePropertyChanged("add_by");
            }
        }

        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set
            {
                _add_date = value;
                RaisePropertyChanged("add_date");
            }
        }

        private string _edit_by;
        public string edit_by
        {
            get { return _edit_by; }
            set
            {
                _edit_by = value; RaisePropertyChanged("edit_by");
            }
        }

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value; RaisePropertyChanged("edit_date");
            }
        }

        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                _location_Id = value;
                RaisePropertyChanged("location_Id");
            }
        }

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                _comp_code = value;
                RaisePropertyChanged("comp_code");
            }
        }
        
        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                _lang_key = value;
                RaisePropertyChanged("lang_key");
            }
        }

        private string _grpNm;
        public string grpNm
        {
            get
            {
                return _grpNm;
            }

            set
            {
                _grpNm = value;
                RaisePropertyChanged("grpNm");
            }
        }

        private string _PartyType_Nm;
        public string PartyType_Nm
        {
            get
            {
                return _PartyType_Nm;
            }
            set
            {
                _PartyType_Nm = value;
                RaisePropertyChanged("PartyType_Nm");
            }
        }
        private string _group_desc;
        public string group_desc
        {
            get { return _group_desc; }
            set
            {
                _group_desc = value; RaisePropertyChanged("group_desc");
            }
        }

        private string _acc_group_type;
        public string acc_group_type
        {
            get { return _acc_group_type; }
            set
            {
                _acc_group_type = value; RaisePropertyChanged("acc_group_type");
            }
        }
        private string _refer_by_name;
        public string refer_by_name
        {
            get { return _refer_by_name; }
            set
            {
                _refer_by_name = value; RaisePropertyChanged("refer_by_name");
            }
        }
        public string XmlDocument { get; set; }
        public string XmlDataDocument_ADM_M055 { get; set; }
        public string XmlDataDocument_ADM_M057 { get; set; }
        public string XmlDataDocument_ADM_M053Flip { get; set; }
        #endregion        
    }
    public class MultipleContext_ADM_M053
    {
        public List<ADM_M053Flip> DocumentDataFlipGrid { get; set; }
        public List<ADM_M053> MasterEntity { get; set; }
        public ObservableCollection<ADM_M055> AddressEntity { get; set; }
        public ObservableCollection<ADM_M057> CommunicationEntity { get; set; }
        public List<ADM_M053Rpt> ADM_M053RptList { get; set; }
        public List<ADM_M050_P> SalutationList { get; set; }
        public List<ADM_M028_B_P> PartyType { get; set; }
        public List<ADM_M028_A_P> Group { get; set; }
        public List<ACC_M003_H_P> AccountingGroupList { get; set; }
        public List<ADM_M054_P> RefContPersonList { get; set; }
        public List<ADM_M013_P> State { get; set; }
        public List<ADM_M012_P> Country { get; set; }
        public List<ADM_M057_A_P> TypeList { get; set; }
    }
}
