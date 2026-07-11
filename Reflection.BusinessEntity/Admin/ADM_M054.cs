using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Admin
{

    public class ADM_M054 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private string _cp_code;
        public string cp_code
        {
            get { return _cp_code; }
            set
            {
                _cp_code = value; RaisePropertyChanged("cp_code");
            }
        }

        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                _id = value; RaisePropertyChanged("id");
            }
        }

        private string _party_id;
        public string party_id
        {
            get { return _party_id; }
            set
            {
                _party_id = value; RaisePropertyChanged("party_id");
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

        private string _f_name;
        public string f_name
        {
            get { return _f_name; }
            set
            {
                _f_name = value; RaisePropertyChanged("f_name");
            }
        }

        private string _m_name;
        public string m_name
        {
            get { return _m_name; }
            set
            {
                _m_name = value; RaisePropertyChanged("m_name");
            }
        }

        private string _l_name;
        public string l_name
        {
            get { return _l_name; }
            set
            {
                _l_name = value; RaisePropertyChanged("l_name");
            }
        }

        private string _nick_name;
        public string nick_name
        {
            get { return _nick_name; }
            set
            {
                _nick_name = value; RaisePropertyChanged("nick_name");
            }
        }

        private string _addr_code;
        public string addr_code
        {
            get { return _addr_code; }
            set
            {
                _addr_code = value; RaisePropertyChanged("addr_code");
            }
        }

        private string _cp_code1;
        public string cp_code1
        {
            get { return _cp_code1; }
            set
            {
                _cp_code1 = value; RaisePropertyChanged("cp_code1");
            }
        }

        private string _gender;
        public string gender
        {
            get { return _gender; }
            set
            {
                _gender = value; RaisePropertyChanged("gender");
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

        private string _ind_mar_status;
        public string ind_mar_status
        {
            get { return _ind_mar_status; }
            set
            {
                _ind_mar_status = value; RaisePropertyChanged("ind_mar_status");
            }
        }

        private string _dept_code;
        public string dept_code
        {
            get { return _dept_code; }
            set
            {
                _dept_code = value; RaisePropertyChanged("dept_code");
            }
        }

        private string _desig_code;
        public string desig_code
        {
            get { return _desig_code; }
            set
            {
                _desig_code = value; RaisePropertyChanged("desig_code");
            }
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
        
        //Scaler
        private string _party_name;
        public string party_name
        {
            get { return _party_name; }
            set
            { _party_name = value; RaisePropertyChanged("party_name", ModelEntityUpdated); }
        }
        private int? _address_id;
        public int? address_id
        {
            get { return _address_id; }
            set
            { _address_id = value; RaisePropertyChanged("address_id", ModelEntityUpdated); }
        }
        private string _address_name;
        public string address_name
        {
            get { return _address_name; }
            set
            { _address_name = value; RaisePropertyChanged("address_name", ModelEntityUpdated); }
        }
        private string _symbol { get; set; }
        public string symbol
        {
            get
            {
                return _symbol;
            }

            set
            {
                _symbol = value; RaisePropertyChanged("symbol", ModelEntityUpdated);
            }
        }
        private string _DesigName { get; set; }
        public string DesigName
        {
            get
            {
                return _DesigName;
            }

            set
            {
                _DesigName = value; RaisePropertyChanged("DesigName", ModelEntityUpdated);
            }
        }

        private string _DeptName { get; set; }
        public string DeptName
        {
            get
            {
                return _DeptName;
            }

            set
            {
                _DeptName = value; RaisePropertyChanged("DeptName", ModelEntityUpdated);
            }
        }
        private string _add_type_code;
        public string add_type_code
        {
            get { return _add_type_code; }
            set
            {
                _add_type_code = value;
                RaisePropertyChanged("add_type_code");
            }
        }
        private string _add_type_name;
        public string add_type_name
        {
            get { return _add_type_name; }
            set
            {
                _add_type_name = value;
                RaisePropertyChanged("add_type_name");
            }
        }
        private string _addr_type;
        public string addr_type
        {
            get { return _addr_type; }
            set
            {
                _addr_type = value; RaisePropertyChanged("addr_type");
            }
        }

        #endregion
        public string XmlDocument { get; set; }
        public string XmlDataDocument_ADM_M055 { get; set; }
        public string XmlDataDocument_ADM_M057 { get; set; }
        public string XmlDataDocument_ADM_M054Flip { get; set; }
    }
    public class MultipleContext_ADM_M054
    {
        public List<ADM_M054Flip> DocumentDataFlipGrid { get; set; }
        public List<ADM_M054> MasterEntity { get; set; }
        public ObservableCollection<ADM_M055> AddressEntity { get; set; }
        public ObservableCollection<ADM_M057> CommunicationEntity { get; set; }
        public List<ADM_M054Rpt> ADM_M054RptList { get; set; }
        public List<ADM_M053_P> PartyList { get; set; }
        public List<ADM_M050_P> SalutationList { get; set; }
        public List<ADM_M025_P> DepartmentList { get; set; }
        public List<ADM_M026_P> DesignationList { get; set; }
        public List<ADM_M013_P> State { get; set; }
        public List<ADM_M012_P> Country { get; set; }
        public List<ADM_M057_A_P> TypeList { get; set; }
        
    }
   
  
}
