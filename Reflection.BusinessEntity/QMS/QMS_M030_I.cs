using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity.QMS
{
    public class QMS_M030_I : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

       

        private string _insp_char;
        public string insp_char
        {
            get { return _insp_char; }
            set
            {
                _insp_char = value;
                RaisePropertyChanged("insp_char");
            }
        }

        private string _char_desc;
        public string char_desc
        {
            get { return _char_desc; }
            set
            {
                _char_desc = value;
                RaisePropertyChanged("char_desc");
            }
        }

        private string _insp_char_type;
        public string insp_char_type
        {
            get { return _insp_char_type; }
            set
            {
                _insp_char_type = value;
                RaisePropertyChanged("insp_char_type");
            }
        }

        private string _version_no;
        public string version_no
        {
            get { return _version_no; }
            set
            {
                _version_no = value;
                RaisePropertyChanged("version_no");
            }
        }

        private string _insp_char_location;
        public string insp_char_location
        {
            get { return _insp_char_location; }
            set
            {
                _insp_char_location = value;
                RaisePropertyChanged("insp_char_location");
            }
        }

        private Nullable<System.DateTime> _from_date;
        public Nullable<System.DateTime> from_date
        {
            get { return _from_date; }
            set
            {
                _from_date = value;
                RaisePropertyChanged("from_date");
            }
        }

        private string _record_use;
        public string record_use
        {
            get { return _record_use; }
            set
            {
                _record_use = value;
                RaisePropertyChanged("record_use");
            }
        }

        private string _control_data;
        public string control_data
        {
            get { return _control_data; }
            set
            {
                _control_data = value;
                RaisePropertyChanged("control_data");
            }
        }

        private string _way_char;
        public string way_char
        {
            get { return _way_char; }
            set
            {
                _way_char = value;
                RaisePropertyChanged("way_char");
            }
        }

        private string _inspector_qualification;
        public string inspector_qualification
        {
            get { return _inspector_qualification; }
            set
            {
                _inspector_qualification = value;
                RaisePropertyChanged("inspector_qualification");
            }
        }

        private string _tol_key;
        public string tol_key
        {
            get { return _tol_key; }
            set
            {
                _tol_key = value;
                RaisePropertyChanged("tol_key");
            }
        }

        private Nullable<int> _dc_place;
        public Nullable<int> dc_place
        {
            get { return _dc_place; }
            set
            {
                _dc_place = value;
                RaisePropertyChanged("dc_place");
            }
        }

        private string _uom_quantitative;
        public string uom_quantitative
        {
            get { return _uom_quantitative; }
            set
            {
                _uom_quantitative = value;
                RaisePropertyChanged("uom_quantitative");
            }
        }

        private Nullable<decimal> _target_value_char;
        public Nullable<decimal> target_value_char
        {
            get { return _target_value_char; }
            set
            {
                _target_value_char = value;
                RaisePropertyChanged("target_value_char");
            }
        }

        private string _value1;
        public string value1
        {
            get { return _value1; }
            set
            {
                _value1 = value;
                RaisePropertyChanged("value1");
            }
        }

        private Nullable<decimal> _upp_limit;
        public Nullable<decimal> upp_limit
        {
            get { return _upp_limit; }
            set
            {
                _upp_limit = value;
                RaisePropertyChanged("upp_limit");
            }
        }

        private string _value2;
        public string value2
        {
            get { return _value2; }
            set
            {
                _value2 = value;
                RaisePropertyChanged("value2");
            }
        }

        private Nullable<decimal> _lower_limit;
        public Nullable<decimal> lower_limit
        {
            get { return _lower_limit; }
            set
            {
                _lower_limit = value;
                RaisePropertyChanged("lower_limit");
            }
        }

        private Nullable<decimal> _upper_tol_limit;
        public Nullable<decimal> upper_tol_limit
        {
            get { return _upper_tol_limit; }
            set
            {
                _upper_tol_limit = value;
                RaisePropertyChanged("upper_tol_limit");
            }
        }

        private Nullable<decimal> _lower_tol_limit;
        public Nullable<decimal> lower_tol_limit
        {
            get { return _lower_tol_limit; }
            set
            {
                _lower_tol_limit = value;
                RaisePropertyChanged("lower_tol_limit");
            }
        }

        private Nullable<decimal> _lower_limit1;
        public Nullable<decimal> lower_limit1
        {
            get { return _lower_limit1; }
            set
            {
                _lower_limit1 = value;
                RaisePropertyChanged("lower_limit1");
            }
        }

        private Nullable<decimal> _upp_limit1;
        public Nullable<decimal> upp_limit1
        {
            get { return _upp_limit1; }
            set
            {
                _upp_limit1 = value;
                RaisePropertyChanged("upp_limit1");
            }
        }

        private string _qm_para_group;
        public string qm_para_group
        {
            get { return _qm_para_group; }
            set
            {
                _qm_para_group = value;
                RaisePropertyChanged("qm_para_group");
            }
        }

        private string _qm_para;
        public string qm_para
        {
            get { return _qm_para; }
            set
            {
                _qm_para = value;
                RaisePropertyChanged("qm_para");
            }
        }

        private string _lower_ver_no;
        public string lower_ver_no
        {
            get { return _lower_ver_no; }
            set
            {
                _lower_ver_no = value;
                RaisePropertyChanged("lower_ver_no");
            }
        }

        private string _qm_para_group1;
        public string qm_para_group1
        {
            get { return _qm_para_group1; }
            set
            {
                _qm_para_group1 = value;
                RaisePropertyChanged("qm_para_group1");
            }
        }

        private string _qm_para1;
        public string qm_para1
        {
            get { return _qm_para1; }
            set
            {
                _qm_para1 = value;
                RaisePropertyChanged("qm_para1");
            }
        }

        private string _upper_ver_no;
        public string upper_ver_no
        {
            get { return _upper_ver_no; }
            set
            {
                _upper_ver_no = value;
                RaisePropertyChanged("upper_ver_no");
            }
        }

        private string _qm_para_group2;
        public string qm_para_group2
        {
            get { return _qm_para_group2; }
            set
            {
                _qm_para_group2 = value;
                RaisePropertyChanged("qm_para_group2");
            }
        }

        private string _qm_para2;
        public string qm_para2
        {
            get { return _qm_para2; }
            set
            {
                _qm_para2 = value;
                RaisePropertyChanged("qm_para2");
            }
        }

        private string _fract_cal;
        public string fract_cal
        {
            get { return _fract_cal; }
            set
            {
                _fract_cal = value;
                RaisePropertyChanged("fract_cal");
            }
        }

        private string _internal_char;
        public string internal_char
        {
            get { return _internal_char; }
            set
            {
                _internal_char = value;
                RaisePropertyChanged("internal_char");
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

        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
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

        private string _editby;
        public string editby
        {
            get { return _editby; }
            set
            {
                _editby = value;
                RaisePropertyChanged("editby");
            }
        }

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value;
                RaisePropertyChanged("edit_date");
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

        private decimal? _lower_limit2;
        public decimal? lower_limit2
        {
            get { return _lower_limit2; }
            set
            {
                _lower_limit2 = value;
                RaisePropertyChanged("lower_limit2");
            }
        }

        private decimal? _upp_limit2;
        public decimal? upp_limit2
        {
            get { return _upp_limit2; }
            set
            {
                _upp_limit2 = value;
                RaisePropertyChanged("upp_limit2");
            }
        }

        private Nullable<System.DateTime> _doc_date;
        public Nullable<System.DateTime> doc_date
        {
            get { return _doc_date; }
            set
            {
                _doc_date = value;
                RaisePropertyChanged("doc_date");
            }
        }

        private bool _value3;
        public bool value3
        {
            get { return _value3; }
            set
            {
                _value3 = value;
                RaisePropertyChanged("value3");
            }
        }

        private bool _value4;
        public bool value4
        {
            get { return _value4; }
            set
            {
                _value4 = value;
                RaisePropertyChanged("value4");
            }
        }

        private bool _value5;
        public bool value5
        {
            get { return _value5; }
            set
            {
                _value5 = value;
                RaisePropertyChanged("value5");
            }
        }

        private bool _value6;
        public bool value6
        {
            get { return _value6; }
            set
            {
                _value6 = value;
                RaisePropertyChanged("value6");
            }
        }

        private bool _value7;
        public bool value7
        {
            get { return _value7; }
            set
            {
                _value7 = value;
                RaisePropertyChanged("value7");
            }
        }

        private bool _value8;
        public bool value8
        {
            get { return _value8; }
            set
            {
                _value8 = value;
                RaisePropertyChanged("value8");
            }
        }

        private bool _value9;
        public bool value9
        {
            get { return _value9; }
            set
            {
                _value9 = value;
                RaisePropertyChanged("value9");
            }
        }

        private bool _value10;
        public bool value10
        {
            get { return _value10; }
            set
            {
                _value10 = value;
                RaisePropertyChanged("value10");
            }
        }

        private string _ind_value11;
        public string ind_value11
        {
            get { return _ind_value11; }
            set
            {
                _ind_value11 = value;
                RaisePropertyChanged("ind_value11");
            }
        }
        public string XmlDataDocument_QMS_M030_I_Flip { get; set; }
        // Scalar
        private bool _x1;
        public bool x1
        {
            get { return _x1; }
            set
            {
                _x1 = value;
                RaisePropertyChanged("x1");
            }
        }

        private bool _x2;
        public bool x2
        {
            get { return _x2; }
            set
            {
                _x2 = value;
                RaisePropertyChanged("x2");
            }
        }

        private bool _x3;
        public bool x3
        {
            get { return _x3; }
            set
            {
                _x3 = value;
                RaisePropertyChanged("x3");
            }
        }

        private bool _x4;
        public bool x4
        {
            get { return _x4; }
            set
            {
                _x4 = value;
                RaisePropertyChanged("x4");
            }
        }

        private bool _m1;
        public bool m1
        {
            get { return _m1; }
            set
            {
                _m1 = value;
                RaisePropertyChanged("m1");
            }
        }
        private bool _m2;
        public bool m2
        {
            get { return _m2; }
            set
            {
                _m2 = value;
                RaisePropertyChanged("m2");
            }
        }
        private bool _m3;
        public bool m3
        {
            get { return _m3; }
            set
            {
                _m3 = value;
                RaisePropertyChanged("m3");
            }
        }

        private bool _a1;
        public bool a1
        {
            get { return _a1; }
            set
            {
                _a1 = value;
                RaisePropertyChanged("a1");
            }
        }
        private bool _a2;
        public bool a2
        {
            get { return _a2; }
            set
            {
                _a2 = value;
                RaisePropertyChanged("a2");
            }
        }
        private bool _a3;
        public bool a3
        {
            get { return _a3; }
            set
            {
                _a3 = value;
                RaisePropertyChanged("a3");
            }
        }
        private bool _a4;
        public bool a4
        {
            get { return _a4; }
            set
            {
                _a4 = value;
                RaisePropertyChanged("a4");
            }
        }

    }

    public class MultipleContext_QMS_M030_I
    {
        public List<QMS_M030_I_Flip> BackFlipData { get; set; }
        public List<QMS_M022_P> QualiMaster { get; set; }
        public List<ADM_M038_B_P> UnitMaster { get; set; }
        public List<QMS_M030_I> MasterEntity { get; set; }
    }
}
      
