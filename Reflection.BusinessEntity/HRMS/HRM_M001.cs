using System;

namespace Reflection.BusinessEntity.HRMS
{
    public class HRM_M001 : ObjectBase
    {
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
        private string _sal_code;
        public string sal_code
        {
            get { return _sal_code; }
            set
            {
                if (_sal_code != value)
                {
                    _sal_code = value; RaisePropertyChanged("sal_code");
                }
            }
        }
        private string _alias_name;
        public string alias_name
        {
            get { return _alias_name; }
            set
            {
                if (_alias_name != value)
                {
                    _alias_name = value; RaisePropertyChanged("alias_name");
                }
            }
        }

        private Nullable<System.DateTime> _emp_dob;
        public Nullable<System.DateTime> emp_dob
        {
            get { return _emp_dob; }
            set
            {
                if (_emp_dob != value)
                {
                    _emp_dob = value; RaisePropertyChanged("emp_dob");
                }
            }
        }
        private string _emp_pob;
        public string emp_pob
        {
            get { return _emp_pob; }
            set
            {
                if (_emp_pob != value)
                {
                    _emp_pob = value; RaisePropertyChanged("emp_pob");
                }
            }
        }
        private string _emp_cob;
        public string emp_cob
        {
            get { return _emp_cob; }
            set
            {
                if (_emp_cob != value)
                {
                    _emp_cob = value; RaisePropertyChanged("emp_cob");
                }
            }
        }
        private string _reli_code;
        public string reli_code
        {
            get { return _reli_code; }
            set
            {
                if (_reli_code != value)
                {
                    _reli_code = value; RaisePropertyChanged("reli_code");
                }
            }
        }
        private string _cast_code;
        public string cast_code
        {
            get { return _cast_code; }
            set
            {
                if (_cast_code != value)
                {
                    _cast_code = value; RaisePropertyChanged("cast_code");
                }
            }
        }
        private string _cat_code;
        public string cat_code
        {
            get { return _cat_code; }
            set
            {
                if (_cat_code != value)
                {
                    _cat_code = value; RaisePropertyChanged("cat_code");
                }
            }
        }
        private string _gender;
        public string gender
        {
            get { return _gender; }
            set
            {
                if (_gender != value)
                {
                    _gender = value; RaisePropertyChanged("gender");
                }
            }
        }
        private string _blood_group;
        public string blood_group
        {
            get { return _blood_group; }
            set
            {
                if (_blood_group != value)
                {
                    _blood_group = value; RaisePropertyChanged("blood_group");
                }
            }
        }
        private Nullable<System.DateTime> _emp_dom;
        public Nullable<System.DateTime> emp_dom
        {
            get { return _emp_dom; }
            set
            {
                if (_emp_dom != value)
                {
                    _emp_dom = value; RaisePropertyChanged("emp_dom");
                }
            }
        }
        private string _marital_status;
        public string marital_status
        {
            get { return _marital_status; }
            set
            {
                if (_marital_status != value)
                {
                    _marital_status = value; RaisePropertyChanged("marital_status");
                }
            }
        }
        private string _nation_code;
        public string nation_code
        {
            get { return _nation_code; }
            set
            {
                if (_nation_code != value)
                {
                    _nation_code = value; RaisePropertyChanged("nation_code");
                }
            }
        }
        private string _nation_code1;
        public string nation_code1
        {
            get { return _nation_code1; }
            set
            {
                if (_nation_code1 != value)
                {
                    _nation_code1 = value; RaisePropertyChanged("nation_code1");
                }
            }
        }
        private string _phy_dis;
        public string phy_dis
        {
            get { return _phy_dis; }
            set
            {
                if (_phy_dis != value)
                {
                    _phy_dis = value; RaisePropertyChanged("phy_dis");
                }
            }
        }
        private string _height_val;
        public string height_val
        {
            get { return _height_val; }
            set
            {
                if (_height_val != value)
                {
                    _height_val = value; RaisePropertyChanged("height_val");
                }
            }
        }
        private string _height_unit;
        public string height_unit
        {
            get { return _height_unit; }
            set
            {
                if (_height_unit != value)
                {
                    _height_unit = value; RaisePropertyChanged("height_unit");
                }
            }
        }
        private string _weight_val;
        public string weight_val
        {
            get { return _weight_val; }
            set
            {
                if (_weight_val != value)
                {
                    _weight_val = value; RaisePropertyChanged("weight_val");
                }
            }
        }
        private string _weight_unit;
        public string weight_unit
        {
            get { return _weight_unit; }
            set
            {
                if (_weight_unit != value)
                {
                    _weight_unit = value; RaisePropertyChanged("weight_unit");
                }
            }
        }
        private Nullable<System.DateTime> _join_date;
        public Nullable<System.DateTime> join_date
        {
            get { return _join_date; }
            set
            {
                if (_join_date != value)
                {
                    _join_date = value; RaisePropertyChanged("join_date");
                }
            }
        }
        private string _applicant_id;
        public string applicant_id
        {
            get { return _applicant_id; }
            set
            {
                if (_applicant_id != value)
                {
                    _applicant_id = value; RaisePropertyChanged("applicant_id");
                }
            }
        }

        private byte[] _emp_photo;
        public byte[] emp_photo
        {
            get { return _emp_photo; }
            set
            {
                if (_emp_photo != value)
                {
                    _emp_photo = value; RaisePropertyChanged("emp_photo");
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
    }
    public class HRM_M001_A : ObjectBase //Nominee Details
    {
        private string _id;
        public string id
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
        private string _f_name;
        public string f_name
        {
            get { return _f_name; }
            set
            {
                if (_f_name != value)
                {
                    _f_name = value; RaisePropertyChanged("f_name");
                }
            }
        }
        private string _m_name;
        public string m_name
        {
            get { return _m_name; }
            set
            {
                if (_m_name != value)
                {
                    _m_name = value; RaisePropertyChanged("m_name");
                }
            }
        }
        private string _l_name;
        public string l_name
        {
            get { return _l_name; }
            set
            {
                if (_l_name != value)
                {
                    _l_name = value; RaisePropertyChanged("l_name");
                }
            }
        }
        private string _occupation;
        public string occupation
        {
            get { return _occupation; }
            set
            {
                if (_occupation != value)
                {
                    _occupation = value; RaisePropertyChanged("occupation");
                }
            }
        }
        private Nullable<System.DateTime> _dob;
        public Nullable<System.DateTime> dob
        {
            get { return _dob; }
            set
            {
                if (_dob != value)
                {
                    _dob = value; RaisePropertyChanged("dob");
                }
            }
        }
        private byte[] _nom_photo;
        public byte[] nom_photo
        {
            get { return _nom_photo; }
            set
            {
                if (_nom_photo != value)
                {
                    _nom_photo = value; RaisePropertyChanged("nom_photo");
                }
            }
        }
        private string _rele_code;
        public string rele_code
        {
            get { return _rele_code; }
            set
            {
                if (_rele_code != value)
                {
                    _rele_code = value; RaisePropertyChanged("rele_code");
                }
            }
        }
        private string _prof_code;
        public string prof_code
        {
            get { return _prof_code; }
            set
            {
                if (_prof_code != value)
                {
                    _prof_code = value; RaisePropertyChanged("prof_code");
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
    }
    public class HRM_M001_B : ObjectBase   //Family Details
    {
        private string _id;
        public string id
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
        private string _no_of_mem;
        public string no_of_mem
        {
            get { return _no_of_mem; }
            set
            {
                if (_no_of_mem != value)
                {
                    _no_of_mem = value; RaisePropertyChanged("no_of_mem ");
                }
            }
        }

        private string _f_name;
        public string f_name
        {
            get { return _f_name; }
            set
            {
                if (_f_name != value)
                {
                    _f_name = value; RaisePropertyChanged("f_name");
                }
            }
        }
        private string _m_name;
        public string m_name
        {
            get { return _m_name; }
            set
            {
                if (_m_name != value)
                {
                    _m_name = value; RaisePropertyChanged("m_name");
                }
            }
        }
        private string _l_name;
        public string l_name
        {
            get { return _l_name; }
            set
            {
                if (_l_name != value)
                {
                    _l_name = value; RaisePropertyChanged("l_name");
                }
            }
        }
        private Nullable<System.DateTime> _dob;
        public Nullable<System.DateTime> dob
        {
            get { return _dob; }
            set
            {
                if (_dob != value)
                {
                    _dob = value; RaisePropertyChanged("dob");
                }
            }
        }
        private byte[] _photo;
        public byte[] photo
        {
            get { return _photo; }
            set
            {
                if (_photo != value)
                {
                    _photo = value; RaisePropertyChanged("photo");
                }
            }
        }
        private bool _ind_dep;
        public bool ind_dep
        {
            get { return _ind_dep; }
            set
            {
                if (_ind_dep != value)
                {
                    _ind_dep = value; RaisePropertyChanged("ind_dep");
                }
            }
        }
        private string _rele_code;
        public string rele_code
        {
            get { return _rele_code; }
            set
            {
                if (_rele_code != value)
                {
                    _rele_code = value; RaisePropertyChanged("rele_code");
                }
            }
        }
        private string _doc_code;
        public string doc_code
        {
            get { return _doc_code; }
            set
            {
                if (_doc_code != value)
                {
                    _doc_code = value; RaisePropertyChanged("doc_code");
                }
            }
        }
        private string _prof_code;
        public string prof_code
        {
            get { return _prof_code; }
            set
            {
                if (_prof_code != value)
                {
                    _prof_code = value; RaisePropertyChanged("prof_code");
                }
            }
        }
        private string _prof_details;
        public string prof_details
        {
            get { return _prof_details; }
            set
            {
                if (_prof_details != value)
                {
                    _prof_details = value; RaisePropertyChanged("prof_details");
                }
            }
        }
        private string _prof_org;
        public string prof_org
        {
            get { return _prof_org; }
            set
            {
                if (_prof_org != value)
                {
                    _prof_org = value; RaisePropertyChanged("prof_org");
                }
            }
        }
        private string _desig_code;
        public string desig_code
        {
            get { return _desig_code; }
            set
            {
                if (_desig_code != value)
                {
                    _desig_code = value; RaisePropertyChanged("desig_code");
                }
            }
        }
        private Nullable<System.DateTime> _doj;
        public Nullable<System.DateTime> doj
        {
            get { return _doj; }
            set
            {
                if (_doj != value)
                {
                    _doj = value; RaisePropertyChanged("doj");
                }
            }
        }
        private string _income;
        public string income
        {
            get { return _income; }
            set
            {
                if (_income != value)
                {
                    _income = value; RaisePropertyChanged("income");
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
    }
    public class HRM_M001_C : ObjectBase   //Employment(Experience)  Details
    {
        private string _employment_id;
        public string employment_id
        {
            get { return _employment_id; }
            set
            {
                if (_employment_id != value)
                {
                    _employment_id = value; RaisePropertyChanged("employment_id");
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
        private string _com_name;
        public string com_name
        {
            get { return _com_name; }
            set
            {
                if (_com_name != value)
                {
                    _com_name = value; RaisePropertyChanged("com_name");
                }
            }
        }
        private Nullable<System.DateTime> _doj;
        public Nullable<System.DateTime> doj
        {
            get { return _doj; }
            set
            {
                if (_doj != value)
                {
                    _doj = value; RaisePropertyChanged("doj");
                }
            }
        }
        private Nullable<System.DateTime> _leave_date;
        public Nullable<System.DateTime> leave_date
        {
            get { return _leave_date; }
            set
            {
                if (_leave_date != value)
                {
                    _leave_date = value; RaisePropertyChanged("leave_date");
                }
            }
        }
        private string _st_desg;
        public string st_desg
        {
            get { return _st_desg; }
            set
            {
                if (_st_desg != value)
                {
                    _st_desg = value; RaisePropertyChanged("st_desg");
                }
            }
        }
        private string _lt_desg;
        public string lt_desg
        {
            get { return _lt_desg; }
            set
            {
                if (_lt_desg != value)
                {
                    _lt_desg = value; RaisePropertyChanged("lt_desg");
                }
            }
        }
        private string _resion_code;
        public string resion_code
        {
            get { return _resion_code; }
            set
            {
                if (_resion_code != value)
                {
                    _resion_code = value; RaisePropertyChanged("resion_code");
                }
            }
        }
        private string _resign_desc;
        public string resign_desc
        {
            get { return _resign_desc; }
            set
            {
                if (_resign_desc != value)
                {
                    _resign_desc = value; RaisePropertyChanged("resign_desc");
                }
            }
        }
        private string _ctc;
        public string ctc
        {
            get { return _ctc; }
            set
            {
                if (_ctc != value)
                {
                    _ctc = value; RaisePropertyChanged("ctc");
                }
            }
        }
        private string _job_pro;
        public string job_pro
        {
            get { return _job_pro; }
            set
            {
                if (_job_pro != value)
                {
                    _job_pro = value; RaisePropertyChanged("job_pro");
                }
            }
        }
        private string _fun_area;
        public string fun_area
        {
            get { return _fun_area; }
            set
            {
                if (_fun_area != value)
                {
                    _fun_area = value; RaisePropertyChanged("fun_area");
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
    }
    

    public class HRM_M001_E : ObjectBase  //Hobbies Details
    {
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
        private string _hobby_code;
        public string hobby_code
        {
            get { return _hobby_code; }
            set
            {
                if (_hobby_code != value)
                {
                    _hobby_code = value; RaisePropertyChanged("hobby_code");
                }
            }
        }
        private string _hobby_desc;
        public string hobby_desc
        {
            get { return _hobby_desc; }
            set
            {
                if (_hobby_desc != value)
                {
                    _hobby_desc = value; RaisePropertyChanged("hobby_desc");
                }
            }
        }
        private string _achive;
        public string achive
        {
            get { return _achive; }
            set
            {
                if (_achive != value)
                {
                    _achive = value; RaisePropertyChanged("achive");
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
    }
    public class HRM_M001_F : ObjectBase  //Refference Master Details
    {
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
        private string _reff_name;
        public string reff_name
        {
            get { return _reff_name; }
            set
            {
                if (_reff_name != value)
                {
                    _reff_name = value; RaisePropertyChanged("reff_name");
                }
            }
        }
        private string _reff_occ;
        public string reff_occ
        {
            get { return _reff_occ; }
            set
            {
                if (_reff_occ != value)
                {
                    _reff_occ = value; RaisePropertyChanged("reff_occ");
                }
            }
        }
        private string _rele_code;
        public string rele_code
        {
            get { return _rele_code; }
            set
            {
                if (_rele_code != value)
                {
                    _rele_code = value; RaisePropertyChanged("rele_code");
                }
            }
        }
        private string _reff_ind;
        public string reff_ind
        {
            get { return _reff_ind; }
            set
            {
                if (_reff_ind != value)
                {
                    _reff_ind = value; RaisePropertyChanged("reff_ind");
                }
            }
        }
        private string _prof_code;
        public string prof_code
        {
            get { return _prof_code; }
            set
            {
                if (_prof_code != value)
                {
                    _prof_code = value; RaisePropertyChanged("prof_code");
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
    }
    public class HRM_M001_G : ObjectBase  //Criminal Record Details
    {
        private string _id;
        public string id
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
        private string _ind_off_type;
        public string ind_off_type
        {
            get { return _ind_off_type; }
            set
            {
                if (_ind_off_type != value)
                {
                    _ind_off_type = value; RaisePropertyChanged("ind_off_type");
                }
            }
        }
        private Nullable<System.DateTime> _date;
        public Nullable<System.DateTime> date
        {
            get { return _date; }
            set
            {
                if (_date != value)
                {
                    _date = value; RaisePropertyChanged("date");
                }
            }
        }
        private string _crime_desc;
        public string crime_desc
        {
            get { return _crime_desc; }
            set
            {
                if (_crime_desc != value)
                {
                    _crime_desc = value; RaisePropertyChanged("crime_desc");
                }
            }
        }
        private string _penelty;
        public string penelty
        {
            get { return _penelty; }
            set
            {
                if (_penelty != value)
                {
                    _penelty = value; RaisePropertyChanged("penelty");
                }
            }
        }
        private string _action;
        public string action
        {
            get { return _action; }
            set
            {
                if (_action != value)
                {
                    _action = value; RaisePropertyChanged("action");
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
    }
    public class HRM_M001_H : ObjectBase  //Employment Details (History)
    {
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
        private string _empl_type;
        public string empl_type
        {
            get { return _empl_type; }
            set
            {
                if (_empl_type != value)
                {
                    _empl_type = value; RaisePropertyChanged("empl_type");
                }
            }
        }
        private Nullable<System.DateTime> _empl_from;
        public Nullable<System.DateTime> empl_from
        {
            get { return _empl_from; }
            set
            {
                if (_empl_from != value)
                {
                    _empl_from = value; RaisePropertyChanged("empl_from");
                }
            }
        }
        private Nullable<System.DateTime> _empl_to;
        public Nullable<System.DateTime> empl_to
        {
            get { return _empl_to; }
            set
            {
                if (_empl_to != value)
                {
                    _empl_to = value; RaisePropertyChanged("empl_to");
                }
            }
        }
        private Nullable<System.DateTime> _due_date;
        public Nullable<System.DateTime> due_date
        {
            get { return _due_date; }
            set
            {
                if (_due_date != value)
                {
                    _due_date = value; RaisePropertyChanged("due_date");
                }
            }
        }
        private string _key_area;
        public string key_area
        {
            get { return _key_area; }
            set
            {
                if (_key_area != value)
                {
                    _key_area = value; RaisePropertyChanged("key_area");
                }
            }
        }
        private string _fun_area;
        public string fun_area
        {
            get { return _fun_area; }
            set
            {
                if (_fun_area != value)
                {
                    _fun_area = value; RaisePropertyChanged("fun_area");
                }
            }
        }
        private string _desig_code;
        public string desig_code
        {
            get { return _desig_code; }
            set
            {
                if (_desig_code != value)
                {
                    _desig_code = value; RaisePropertyChanged("desig_code");
                }
            }
        }
        private string _dept_code;
        public string dept_code
        {
            get { return _dept_code; }
            set
            {
                if (_dept_code != value)
                {
                    _dept_code = value; RaisePropertyChanged("dept_code");
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
    }
    public class HRM_M001_I : ObjectBase  //Additional Activities Details
    {
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
        private Nullable<System.DateTime> _from_date;
        public Nullable<System.DateTime> from_date
        {
            get { return _from_date; }
            set
            {
                if (_from_date != value)
                {
                    _from_date = value; RaisePropertyChanged("from_date");
                }
            }
        }
        private Nullable<System.DateTime> _to_date;
        public Nullable<System.DateTime> to_date
        {
            get { return _to_date; }
            set
            {
                if (_to_date != value)
                {
                    _to_date = value; RaisePropertyChanged("to_date");
                }
            }
        }
        private string _Description;
        public string Description
        {
            get { return _Description; }
            set
            {
                if (_Description != value)
                {
                    _Description = value; RaisePropertyChanged("Description");
                }
            }
        }
        private string _act_type;
        public string act_type
        {
            get { return _act_type; }
            set
            {
                if (_act_type != value)
                {
                    _act_type = value; RaisePropertyChanged("act_type");
                }
            }
        }
        private string _asub_type;
        public string asub_type
        {
            get { return _asub_type; }
            set
            {
                if (_asub_type != value)
                {
                    _asub_type = value; RaisePropertyChanged("asub_type");
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
    }
    public class HRM_M001_J : ObjectBase  //Current Skill Details
    {
        private string _skill_id;
        public string skill_id
        {
            get { return _skill_id; }
            set
            {
                if (_skill_id != value)
                {
                    _skill_id = value; RaisePropertyChanged("skill_id");
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
        private string _skill_code;
        public string skill_code
        {
            get { return _skill_code; }
            set
            {
                if (_skill_code != value)
                {
                    _skill_code = value; RaisePropertyChanged("skill_code");
                }
            }
        }
        private string _skill_type;
        public string skill_type
        {
            get { return _skill_type; }
            set
            {
                if (_skill_type != value)
                {
                    _skill_type = value; RaisePropertyChanged("skill_type");
                }
            }
        }
        private Nullable<System.DateTime> _updated;
        public Nullable<System.DateTime> updated
        {
            get { return _updated; }
            set
            {
                if (_updated != value)
                {
                    _updated = value; RaisePropertyChanged("updated");
                }
            }
        }
        private string _skill_desc;
        public string skill_desc
        {
            get { return _skill_desc; }
            set
            {
                if (_skill_desc != value)
                {
                    _skill_desc = value; RaisePropertyChanged("skill_desc");
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
    }
    public class HRM_M001_K : ObjectBase //Tag Details
    {
        private string _parentId;
        public string parentId
        {
            get { return _parentId; }
            set
            {
                if (_parentId != value)
                {
                    _parentId = value; RaisePropertyChanged("parentId");
                }
            }
        }
        private string _tag_code;
        public string tag_code
        {
            get { return _tag_code; }
            set
            {
                if (_tag_code != value)
                {
                    _tag_code = value; RaisePropertyChanged("tag_code");
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
        private Nullable<System.DateTime> _issue_date;
        public Nullable<System.DateTime> issue_date
        {
            get { return _issue_date; }
            set
            {
                if (_issue_date != value)
                {
                    _issue_date = value; RaisePropertyChanged("issue_date");
                }
            }
        }
        private Nullable<System.DateTime> _effective_date;
        public Nullable<System.DateTime> effective_date
        {
            get { return _effective_date; }
            set
            {
                if (_effective_date != value)
                {
                    _effective_date = value; RaisePropertyChanged("effective_date");
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
    }
}