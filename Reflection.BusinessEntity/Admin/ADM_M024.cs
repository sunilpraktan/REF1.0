using Reflection.BusinessEntity.ADM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity
{
    public class ADM_M024 : ObjectBase
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
                    _id = value;
                    RaisePropertyChanged("id");
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
                    _EmpId = value;
                    RaisePropertyChanged("EmpId"); RaisePropertyChanged("EmpId", ModelEntityUpdated);
                }
            }
        }
        private string _EmpLName;
        public string EmpLName
        {

            get { return _EmpLName; }
            set
            {
                if (_EmpLName != value)
                {
                    _EmpLName = value;
                    RaisePropertyChanged("EmpLName"); RaisePropertyChanged("EmpLName", ModelEntityUpdated);
                }
            }
        }
        private string _EmpFName;
       public string EmpFName
        {
            get { return _EmpFName; }
            set
            {
                if (_EmpFName != value)
                {
                    _EmpFName = value;
                    RaisePropertyChanged("EmpFName"); RaisePropertyChanged("EmpFName", ModelEntityUpdated);
                }
            }
        }
        private string _EmpMName;
        public string EmpMName
        {
            get { return _EmpMName; }
            set
            {
                if (_EmpMName != value)
                {
                    _EmpMName = value;
                    RaisePropertyChanged("EmpMName");
                }
            }
        }
        private string _EmpPermtAdd;
        public string EmpPermtAdd
        {
            get { return _EmpPermtAdd; }
            set
            {
                if (_EmpPermtAdd != value)
                {
                    _EmpPermtAdd = value;
                    RaisePropertyChanged("EmpPermtAdd");
                }
            }
        }
        private string _EmpTempAdd;
        public string EmpTempAdd
        {
            get { return _EmpTempAdd; }
            set
            {
                if (_EmpTempAdd != value)
                {
                    _EmpTempAdd = value;
                    RaisePropertyChanged("EmpTempAdd");
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
                    _EmpMobNo = value;
                    RaisePropertyChanged("EmpMobNo");
                }
            }
        }
        private string _EmpPhNo;
        public string EmpPhNo
        {
            get { return _EmpPhNo; }
            set
            {
                if (_EmpPhNo != value)
                {
                    _EmpPhNo = value;
                    RaisePropertyChanged("EmpPhNo");
                }
            }
        }
        private string _EmpPhExt;

        public string EmpPhExt
        {
            get { return _EmpPhExt; }
            set
            {
                if (_EmpPhExt != value)
                {
                    _EmpPhExt = value;
                    RaisePropertyChanged("EmpPhExt");
                }
            }
        }
        private string _EmpFaxNo;
        public string EmpFaxNo
        {
            get { return _EmpFaxNo; }
            set
            {
                if (_EmpFaxNo != value)
                {
                    _EmpFaxNo = value;
                    RaisePropertyChanged("EmpFaxNo");
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
                    _EmpEmailId = value;
                    RaisePropertyChanged("EmpEmailId");
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
                    _desig_code = value;
                    RaisePropertyChanged("desig_code");
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
                    _dept_code = value;
                    RaisePropertyChanged("dept_code");
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
                    _location_Id = value;
                    RaisePropertyChanged("location_Id");
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
                    _active = value;
                    RaisePropertyChanged("active");
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
                    _add_by = value;
                    RaisePropertyChanged("add_by");
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
                    _add_date = value;
                    RaisePropertyChanged("add_date");
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
                    _editby = value;
                    RaisePropertyChanged("editby");
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
                    _edit_date = value;
                    RaisePropertyChanged("edit_date");
                }
            }
        }
        private byte[] _Photo;
        public byte[] Photo
        {
            get { return _Photo; }
            set
            {
                if (_Photo != value)
                {
                    _Photo = value;
                    RaisePropertyChanged("Photo");
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
        private string _emp_type;
        public string emp_type
        {
            get { return _emp_type; }
            set
            {
                if (_emp_type != value)
                {
                    _emp_type = value; RaisePropertyChanged("emp_type");
                }
            }
        }
        private string _empl_type_name;
        public string empl_type_name
        {
            get { return _empl_type_name; }
            set
            {
                if (_empl_type_name != value)
                {
                    _empl_type_name = value; RaisePropertyChanged("empl_type_name");
                }
            }
        }
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
        private string _DeptName;
        public string DeptName
        {
            get { return _DeptName; }
            set
            {
                if (_DeptName != value)
                {
                    _DeptName = value; RaisePropertyChanged("DeptName");
                }
            }
        }
        private string _DesigName;
        public string DesigName
        {
            get { return _DesigName; }
            set
            {
                if (_DesigName != value)
                {
                    _DesigName = value; RaisePropertyChanged("DesigName");
                }
            }
        }
        private string _so_code;
        public string so_code
        {
            get { return _so_code; }
            set
            {
                if (_so_code != value)
                {
                    _so_code = value; RaisePropertyChanged("so_code");
                }
            }
        }


        private string _sg_code;
        public string sg_code
        {
            get { return _sg_code; }
            set
            {
                if (_sg_code != value)
                {
                    _sg_code = value; RaisePropertyChanged("sg_code");
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
        private byte[] _digi_sign;
        public byte[] digi_sign
        {
            get { return _digi_sign; }
            set
            {
                if (_digi_sign != value)
                {
                    _digi_sign = value;
                    RaisePropertyChanged("digi_sign");
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
                    _comp_code = value;
                    RaisePropertyChanged("comp_code", ModelEntityUpdated);
                }
            }
        }
        //scalar Variable
        private string _sales_org;

        public string sales_org
        {
            get { return _sales_org; }
            set
            {
                if (_sales_org != value)
                {
                    _sales_org = value; RaisePropertyChanged("sales_org");
                }
            }
        }

        private string _sg_name;

        public string sg_name
        {
            get { return _sg_name; }
            set
            {
                if (_sg_name != value)
                {
                    _sg_name = value; RaisePropertyChanged("sg_name");
                }
            }
        }
        private string _pur_org;

        public string pur_org
        {
            get { return _pur_org; }
            set
            {
                if (_pur_org != value)
                {
                    _pur_org = value; RaisePropertyChanged("pur_org");
                }
            }
        }

        private string _pg_name;

        public string pg_name
        {
            get { return _pg_name; }
            set
            {
                if (_pg_name != value)
                {
                    _pg_name = value; RaisePropertyChanged("pg_name");
                }
            }
        }
        private string _CompName;
        public string CompName
        {
            get { return _CompName; }
            set
            {
                if (_CompName != value)
                {
                    _CompName = value; RaisePropertyChanged("CompName");
                }
            }
        }
         //Added By Karishma
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
        private bool _ind_phy_dis;
        public bool ind_phy_dis
        {
            get { return _ind_phy_dis; }
            set
            {
                if (_ind_phy_dis != value)
                {
                    _ind_phy_dis = value; RaisePropertyChanged("ind_phy_dis");
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

        public string XmlDataDocument_ADM_M024_A { get; set; }
        public string XmlDataDocument_ADM_M024_B { get; set; }
        public string XmlDataDocument_ADM_M024_C { get; set; }
        public string XmlDataDocument_ADM_M024BackFlip { get; set; }
        public string tempString { get; set; }

        public string XmlDataDocument_HRM_M001_D { get; set; }
      

        //Scaler

        private string _sal_desc;
        public string sal_desc
        {
            get { return _sal_desc; }
            set
            {
                if (_sal_desc != value)
                {
                    _sal_desc = value;
                    RaisePropertyChanged("sal_desc");
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
                    _CntryName = value;
                    RaisePropertyChanged("CntryName");
                }
            }
        }

        private string _reli_name;
        public string reli_name
        {
            get { return _reli_name; }
            set
            {
                if (_reli_name != value)
                {
                    _reli_name = value;
                    RaisePropertyChanged("reli_name");
                }
            }
        }
        private string _cast_name;
        public string cast_name
        {
            get { return _cast_name; }
            set
            {
                if (_cast_name != value)
                {
                    _cast_name = value;
                    RaisePropertyChanged("cast_name");
                }
            }
        }
        private string _cat_name;
        public string cat_name
        {
            get { return _cat_name; }
            set
            {
                if (_cat_name != value)
                {
                    _cat_name = value;
                    RaisePropertyChanged("cat_name");
                }
            }
        }
        private string _nation_desc;
        public string nation_desc
        {
            get { return _nation_desc; }
            set
            {
                if (_nation_desc != value)
                {
                    _nation_desc = value;
                    RaisePropertyChanged("nation_desc");
                }
            }
        }
        private string _phy_dis_nm;
        public string phy_dis_nm
        {
            get { return _phy_dis_nm; }
            set
            {
                if (_phy_dis_nm != value)
                {
                    _phy_dis_nm = value;
                    RaisePropertyChanged("phy_dis_nm");
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
                    _t_name = value; RaisePropertyChanged("t_name");
                }
            }
        }

    }
    public class ADM_M024_A : ObjectBase
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
                    _id = value;
                    RaisePropertyChanged("id");
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
                    _comp_code = value;
                    RaisePropertyChanged("comp_code");
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
                    _location_Id = value;
                    RaisePropertyChanged("location_Id");
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
                    _EmpId = value;
                    RaisePropertyChanged("EmpId");
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

        private string _so_code;
        public string so_code
        {
            get { return _so_code; }
            set
            {
                if (_so_code != value)
                {
                    _so_code = value;
                    RaisePropertyChanged("so_code");
                }
            }
        }

        private string _sg_code;
        public string sg_code
        {
            get { return _sg_code; }
            set
            {
                if (_sg_code != value)
                {
                    _sg_code = value;
                    RaisePropertyChanged("sg_code");
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
                    _active = value;
                    RaisePropertyChanged("active");
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
                    _t_status = value;
                    RaisePropertyChanged("t_status");
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
                    _add_by = value;
                    RaisePropertyChanged("add_by");
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
                    _add_date = value;
                    RaisePropertyChanged("add_date");
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
                    _editby = value;
                    RaisePropertyChanged("editby");
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
                    _edit_date = value;
                    RaisePropertyChanged("edit_date");
                }
            }
        }

       
        private bool? _default_org_code;
        public bool? default_org_code
        {
            get { return _default_org_code; }
            set { if (_default_org_code != value) { _default_org_code = value; RaisePropertyChanged("default_org_code"); } }
        }
    }
    
    public class ADM_M024_B : ObjectBase
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
                    _id = value;
                    RaisePropertyChanged("id");
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
                    _comp_code = value;
                    RaisePropertyChanged("comp_code");
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
                    _location_Id = value;
                    RaisePropertyChanged("location_Id");
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
                    _EmpId = value;
                    RaisePropertyChanged("EmpId");
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
        private string _po_code;
        public string po_code
        {
            get { return _po_code; }
            set
            {
                if (_po_code != value)
                {
                    _po_code = value;
                    RaisePropertyChanged("po_code");
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
                    _pg_code = value;
                    RaisePropertyChanged("pg_code");
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
                    _active = value;
                    RaisePropertyChanged("active");
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
                    _t_status = value;
                    RaisePropertyChanged("t_status");
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
                    _add_by = value;
                    RaisePropertyChanged("add_by");
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
                    _add_date = value;
                    RaisePropertyChanged("add_date");
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
                    _editby = value;
                    RaisePropertyChanged("editby");
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
                    _edit_date = value;
                    RaisePropertyChanged("edit_date");
                }
            }
        }
        
        private bool? _default_org_code;
        public bool? default_org_code
        {
            get { return _default_org_code; }
            set { if (_default_org_code != value) { _default_org_code = value; RaisePropertyChanged("default_org_code"); } }
        }
    }
    public class ADM_M024_C : ObjectBase
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
                    _id = value;
                    RaisePropertyChanged("id");
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
                    _EmpId = value;
                    RaisePropertyChanged("EmpId");
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
                    _PartyId = value;
                    RaisePropertyChanged("PartyId");
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
                    _active = value;
                    RaisePropertyChanged("active");
                }
            }
        }

        // SCAlar Variables
        private string _PartyNm;
        public string PartyNm
        {
            get { return _PartyNm; }
            set
            {
                if (_PartyNm != value)
                {
                    _PartyNm = value;
                    RaisePropertyChanged("PartyNm");
                }
            }
        }

        private string _Location;
        public string Location
        {
            get { return _Location; }
            set
            {
                if (_Location != value)
                {
                    _Location = value;
                    RaisePropertyChanged("Location");
                }
            }
        }
        private string _PartyType;
        public string PartyType
        {
            get { return _PartyType; }
            set
            {
                if (_PartyType != value)
                {
                    _PartyType = value;
                    RaisePropertyChanged("PartyType");
                }
            }
        }
        private string _grpNm;
        public string grpNm
        {
            get { return _grpNm; }
            set
            {
                if (_grpNm != value)
                {
                    _grpNm = value;
                    RaisePropertyChanged("grpNm");
                }
            }
        }
       
    }

    //Classes for HRM Module

    public class HRM_M001_D : ObjectBase   //Language known Details
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
        private string _language_key;
        public string language_key
        {
            get { return _language_key; }
            set
            {
                if (_language_key != value)
                {
                    _language_key = value; RaisePropertyChanged("language_key");
                }
            }
        }
        private bool _readable;
        public bool readable
        {
            get { return _readable; }
            set
            {
                if (_readable != value)
                {
                    _readable = value; RaisePropertyChanged("readable");
                }
            }
        }
        private bool _write;
        public bool write
        {
            get { return _write; }
            set
            {
                if (_write != value)
                {
                    _write = value; RaisePropertyChanged("write");
                }
            }
        }
        private bool _speak;
        public bool speak
        {
            get { return _speak; }
            set
            {
                if (_speak != value)
                {
                    _speak = value; RaisePropertyChanged("speak");
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
        //Scaler 

        private string _language_desc;
        public string language_desc
        {
            get { return _language_desc; }
            set
            {
                if (_language_desc != value)
                {
                    _language_desc = value; RaisePropertyChanged("language_desc");
                }
            }
        }

    }
    



    public class MultipleContext_ADM_M024
    {
        public List<ADM_M024_P> DocumentDataFlipGrid { get; set; }//BF data
        public List<ADM_M024> Employees { get; set; }
        public List<ADM_M003_P> Locations { get; set; }
        public List<ADM_M025_P> Departments { get; set; }
        public List<ADM_M026_P> Disignations { get; set; }
        public List<ADM_M001_H_P> SalesGroup { get; set; }
        public List<ADM_M001_P_P> PurchaseGroup { get; set; }
        public List<ADM_M028_P> Customers { get; set; }
        public ObservableCollection<ADM_M024_A> SalesEntity { get; set; }
        public ObservableCollection<ADM_M024_B> PurchaseEntity { get; set; }
        public ObservableCollection<ADM_M024_C> CustEntity { get; set; }
        public List<ADM_M002_P> Company { get; set; }
        public List<COM_T003> AttachmentList { get; set; }
        public List<HRM_M004_P> EmployeeTypeList { get; set; }
    }

    public class MultipleContext_HRM_M001
    {
        public List<ADM_M024_P> BackFlipEntity { get; set; }
        public List<ADM_M024> Employees { get; set; }
        public List<ADM_M050_P> SalList { get; set; }  //Popup for Salutation
        public List<ADM_M012_P> CountryList { get; set; }  //Popup for Country
        public List<HRM_M010_P> ReligionList { get; set; }  //Popup for Religion
        public List<HRM_M012_P> CastList { get; set; }  //Popup for Cast
        public List<HRM_M011_P> CatList { get; set; }  //Popup for Category of cast
        public List<ADM_M051_P> NationalityList { get; set; }  //Popup for Nationality
        public List<HRM_M021_P> PhyDisList { get; set; }  //Popup for Physical Disability
        public List<ADM_M038_B_P> HeightList { get; set; }  //Popup for Height
        public List<ADM_M038_B_P> WeightList { get; set; }  //Popup for Weight
        public List<ADM_M0013> StatusList { get; set; }  //Popup for Status
        
        //Details Data
        public ObservableCollection<HRM_M001_D> LaguageKnown { get; set; } // Language Known


        //Popup for childs
        public List<HRM_M022_P> LanguageList { get; set; }  //Popup for Language

    }
}
