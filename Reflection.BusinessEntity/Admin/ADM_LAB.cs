using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity
{
    public class ADM_M003_B : ObjectBase
    {
        private int _lab_id;
        public int lab_id
        {
            get { return _lab_id; }
            set
            {
                if (_lab_id != value)
                {
                    _lab_id = value; RaisePropertyChanged("lab_id");
                }
            }
        }

        private string _lab_code;
        public string lab_code
        {
            get { return _lab_code; }
            set
            {
                if (_lab_code!= value)
                {
                    _lab_code = value; RaisePropertyChanged("lab_code");
                }
            }
        }
        private string _lab_name;
        public string lab_name
        {
            get { return _lab_name; }
            set
            {
                if (_lab_name != value)
                {
                    _lab_name = value; RaisePropertyChanged("lab_name");
                }
            }
        }

        private string _lab_abbr;
        public string lab_abbr
        {
            get { return _lab_abbr; }
            set
            {
                if (_lab_abbr != value)
                {
                    _lab_abbr = value; RaisePropertyChanged("lab_abbr");
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

        private string _addr1;
        public string addr1
        {
            get { return _addr1; }
            set
            {
                if (_addr1 != value)
                {
                    _addr1 = value; RaisePropertyChanged("addr1");
                }
            }
        }

        private string _addr2;
        public string addr2
        {
            get { return _addr2; }
            set
            {
                if (_addr2 != value)
                {
                    _addr2 = value; RaisePropertyChanged("addr2");
                }
            }
        }

        private string _city;
        public string city
        {
            get { return _city; }
            set
            {
                if (_addr2 != value)
                {
                    _city = value; RaisePropertyChanged("city");
                }
            }
        }

        private string _state_code;
        public string state_code
        {
            get { return _state_code; }
            set
            {
                if (_state_code != value)
                {
                    _state_code = value; RaisePropertyChanged("state_code");
                }
            }
        }

        private string _country_code;
        public string country_code
        {
            get { return _country_code; }
            set
            {
                if (_country_code != value)
                {
                    _country_code = value; RaisePropertyChanged("country_code");
                }
            }
        }
        private string _pin_no;
        public string pin_no
        {
            get { return _pin_no; }
            set
            {
                if (_pin_no != value)
                {
                    _pin_no = value; RaisePropertyChanged("pin_no");
                }
            }
        }

        private string _ph_off;
        public string ph_off
        {
            get { return _ph_off; }
            set
            {
                if (_ph_off != value)
                {
                    _ph_off = value; RaisePropertyChanged("ph_off");
                }
            }
        }

        private string _ph_ext;
        public string ph_ext
        {
            get { return _ph_ext; }
            set
            {
                if (_ph_ext != value)
                {
                    _ph_ext = value; RaisePropertyChanged("ph_ext");
                }
            }
        }

        private string _faxno;
        public string faxno
        {
            get { return _faxno; }
            set
            {
                if (_faxno != value)
                {
                    _faxno = value; RaisePropertyChanged("faxno");
                }
            }
        }

        private string _email;
        public string email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value; RaisePropertyChanged("email");
                }
            }
        }

        private string _activity_code;
        public string activity_code
        {
            get { return _activity_code; }
            set
            {
                if (_activity_code != value)
                {
                    _activity_code = value; RaisePropertyChanged("activity_code");
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

        private DateTime? _add_date;
        public DateTime? add_date
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

        private bool? _active;
        public bool? active
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

        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                if (_lang_key != value)
                {
                    _lang_key = value;
                    RaisePropertyChanged("lang_key");
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

        

        //Scalar

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

        private string _CntryName;
        public string CntryName
        {
            get { return _CntryName; }
            set
            {
                if (_CntryName != value)
                {
                    _CntryName = value; RaisePropertyChanged("CntryName");
                }
            }
        }

        private string _StatName;
        public string StatName
        {
            get { return _StatName; }
            set
            {
                if (_StatName != value)
                {
                    _StatName = value; RaisePropertyChanged("StatName");
                }
            }
        }

        private string _activtNm;
        public string activtNm
        {
            get { return _activtNm; }
            set
            {
                if (_activtNm != value)
                {
                    _activtNm = value; RaisePropertyChanged("activtNm");
                }
            }
        }

        private string _CompName;
        public string CompName
        {
            get { return _CompName; }
            set
            {
                if (_activtNm != value)
                {
                    _CompName = value; RaisePropertyChanged("CompName");
                }
            }
        }

        private string _EmpName;
        public string EmpName
        {
            get { return _EmpName; }
            set
            {
                if (_EmpName != value)
                {
                    _EmpName = value; RaisePropertyChanged("EmpName");
                }
            }
        }

        private string _EmpEmailId;
        public string EmpEmailId
        {
            get { return _EmpEmailId; }
            set
            {
                if (_EmpEmailId != value)
                {
                    _EmpEmailId = value; RaisePropertyChanged("EmpEmailId");
                }
            }
        }

        private string _EmpMobNo;
        public string EmpMobNo
        {
            get { return _EmpMobNo; }
            set
            {
                if (_EmpMobNo != value)
                {
                    _EmpMobNo = value; RaisePropertyChanged("EmpMobNo");
                }
            }
        }

        public string XMLDataDocument_ADM_M003_B { get; set; }
    }
    public class MultipleContext_ADM_M003_B
    {
        public List<ADM_M003_B> MasterEntity { get; set; }
        public List<ADM_M003_B_Flip> BackFlipList { get; set; }
        public List<ADM_M003_P> LocationList { get; set; }
        public List<ADM_M012_P> CountryList { get; set; }
        public List<ADM_M013_P> StateList { get; set; }
        public List<ADM_M004_P> ActivityList { get; set; }
        public List<ADM_M002_P> CompanyList { get; set; }
        public List<ADM_M024_P> ContactPerson { get; set; }
    }
  
}
