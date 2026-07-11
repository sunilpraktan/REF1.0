using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.QMS
{
    public partial class QMS_M009 : ObjectBase
    {
        private string _tcm_code;
        public string tcm_code
        {
            get { return _tcm_code; }
            set { _tcm_code = value; RaisePropertyChanged("tcm_code"); }
        }
        private string _tcm_name;
        public string tcm_name
        {
            get { return _tcm_name; }
            set { _tcm_name = value; RaisePropertyChanged("tcm_name"); }
        }
        private string _tcm_desc;
        public string tcm_desc
        {
            get { return _tcm_desc; }
            set { _tcm_desc = value; RaisePropertyChanged("tcm_desc"); }
        }
        private string _test_code;
        public string test_code
        {
            get { return _test_code; }
            set { _test_code = value; RaisePropertyChanged("test_code"); }
        }
        private bool? _active;
        public bool? active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }
        }
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }
        private DateTime _add_date;
        public DateTime add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
        }
        private string _editby;
        public string editby
        {
            get { return _editby; }
            set { _editby = value; RaisePropertyChanged("editby"); }
        }
        private DateTime? _edit_date;
        public DateTime? edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
        }
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id"); }
        }
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }
        
        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set { _lang_key = value; RaisePropertyChanged("lang_key"); }
        }
        
    }

    public partial class QMS_M009_A : ObjectBase
    {
        private string _test_code;
        public string test_code
        {
            get { return _test_code; }
            set { _test_code = value; RaisePropertyChanged("test_code"); }
        }
        private string _test_name;
        public string test_name
        {
            get { return _test_name; }
            set { _test_name = value; RaisePropertyChanged("test_name"); }
        }
        private string _short_name;
        public string short_name
        {
            get { return _short_name; }
            set { _short_name = value; RaisePropertyChanged("short_name"); }
        }
        private string _test_desc;
        public string test_desc
        {
            get { return _test_desc; }
            set { _test_desc = value; RaisePropertyChanged("test_desc"); }
        }
        private string _CatCode;
        public string CatCode
        {
            get { return _CatCode; }
            set { _CatCode = value; RaisePropertyChanged("CatCode"); }
        }
        private string _insp_type;
        public string insp_type
        {
            get { return _insp_type; }
            set { _insp_type = value; RaisePropertyChanged("insp_type"); }
        }
        private string _test_cat;
        public string test_cat
        {
            get { return _test_cat; }
            set { _test_cat = value; RaisePropertyChanged("test_cat"); }
        }
        private string _tp_code;
        public string tp_code
        {
            get { return _tp_code; }
            set { _tp_code = value; RaisePropertyChanged("tp_code"); }
        }
        private string _wi_code;
        public string wi_code
        {
            get { return _wi_code; }
            set { _wi_code = value; RaisePropertyChanged("wi_code"); }
        }
        private string _note;
        public string note
        {
            get { return _note; }
            set { _note = value; RaisePropertyChanged("note"); }
        }
        private bool? _active;
        public bool? active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }
        }
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }
        private DateTime _add_date;
        public DateTime add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
        }
        private string _editby;
        public string editby
        {
            get { return _editby; }
            set { _editby = value; RaisePropertyChanged("editby"); }
        }
        private DateTime? _edit_date;
        public DateTime? edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
        }
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id"); }
        }
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }
       
        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set { _lang_key = value; RaisePropertyChanged("lang_key"); }
        }
        
        private string _ItemCode;
        public string ItemCode
        {
            get { return _ItemCode; }
            set { _ItemCode = value; RaisePropertyChanged("ItemCode"); }
        }
        // Xml Documents Variables
        public string XmlDataDocument_QMS_M009Flip { get; set; }
        public string XmlDataDocument_QMS_M009_B { get; set; }
        public string XmlDataDocument_QMS_M009_C { get; set; }
        public string XmlDataDocument_QMS_M009_D { get; set; }
        public string XmlDataDocument_QMS_M009_E_M { get; set; }
        public string XmlDataDocument_QMS_M009_E_I { get; set; }
        public string XmlDataDocument_QMS_M009_F { get; set; }
        public string XmlDataDocument_QMS_M009_G { get; set; }
        public string XmlDataDocument_QMS_M009_H { get; set; }
        public string XmlDataDocument_QMS_M009_I { get; set; }
        public string XmlDataDocument_QMS_M009_J { get; set; }
        public string XmlDataDocument_QMS_M009_K { get; set; }

        //Scalars
        private string _CatName;
        public string CatName
        {
            get { return _CatName; }
            set { _CatName = value; RaisePropertyChanged("CatName"); }
        }
        private string _insp_type_name;
        public string insp_type_name
        {
            get { return _insp_type_name; }
            set { _insp_type_name = value; RaisePropertyChanged("insp_type_name"); }
        }
        private string _tp_desc;
        public string tp_desc
        {
            get { return _tp_desc; }
            set { _tp_desc = value; RaisePropertyChanged("tp_desc"); }
        }
        private string _wi_desc;
        public string wi_desc
        {
            get { return _wi_desc; }
            set { _wi_desc = value; RaisePropertyChanged("wi_desc"); }
        }
        private string _ItemName;
        public string ItemName
        {
            get { return _ItemName; }
            set { _ItemName = value; RaisePropertyChanged("ItemName"); }
        }
    }

    public partial class QMS_M009_B : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }
        private string _test_code;
        public string test_code
        {
            get { return _test_code; }
            set { _test_code = value; RaisePropertyChanged("test_code"); }
        }
        private string _test_type_code;
        public string test_type_code
        {
            get { return _test_type_code; }
            set { _test_type_code = value; RaisePropertyChanged("test_type_code"); }
        }
        private string _test_type_name;
        public string test_type_name
        {
            get { return _test_type_name; }
            set { _test_type_name = value; RaisePropertyChanged("test_type_name"); }
        }
        private int? _seq_no;
        public int? seq_no
        {
            get { return _seq_no; }
            set { _seq_no = value; RaisePropertyChanged("seq_no"); }
        }
        private string _short_name;
        public string short_name
        {
            get { return _short_name; }
            set { _short_name = value; RaisePropertyChanged("short_name"); }
        }
        private string _description;
        public string description
        {
            get { return _description; }
            set { _description = value; RaisePropertyChanged("description"); }
        }
        private string _master_inst;
        public string master_inst
        {
            get { return _master_inst; }
            set { _master_inst = value; RaisePropertyChanged("master_inst"); }
        }
        private int? _line_id;
        public int? line_id
        {
            get { return _line_id; }
            set { _line_id = value; RaisePropertyChanged("line_id"); }
        }
        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code"); }
        }
        private string _note;
        public string note
        {
            get { return _note; }
            set { _note = value; RaisePropertyChanged("note"); }
        }
        private bool? _active;
        public bool? active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }
        }
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }
        private DateTime _add_date;
        public DateTime add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
        }
        private string _editby;
        public string editby
        {
            get { return _editby; }
            set { _editby = value; RaisePropertyChanged("editby"); }
        }
        private DateTime? _edit_date;
        public DateTime? edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
        }
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id"); }
        }
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }
       
        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set { _lang_key = value; RaisePropertyChanged("lang_key"); }
        }
        
        private string _op_hdr;
        public string op_hdr
        {
            get { return _op_hdr; }
            set { _op_hdr = value; RaisePropertyChanged("op_hdr"); }
        }
        private string _formula_code;
        public string formula_code
        {
            get { return _formula_code; }
            set { _formula_code = value; RaisePropertyChanged("formula_code"); }
        }
        private decimal? _coverage_factor;
        public decimal? coverage_factor
        {
            get { return _coverage_factor; }
            set { _coverage_factor = value; RaisePropertyChanged("coverage_factor"); }
        }
        private string _conf_level;
        public string conf_level
        {
            get { return _conf_level; }
            set { _conf_level = value; RaisePropertyChanged("conf_level"); }
        }
        private string _decimal_format_code;
        public string decimal_format_code
        {
            get { return _decimal_format_code; }
            set { _decimal_format_code = value; RaisePropertyChanged("decimal_format_code"); }
        }
        //Scalar
        private string _master_inst_name;
        public string master_inst_name
        {
            get { return _master_inst_name; }
            set { _master_inst_name = value; RaisePropertyChanged("master_inst_name"); }
        }
        private string _formula_desc;
        public string formula_desc
        {
            get { return _formula_desc; }
            set { _formula_desc = value; RaisePropertyChanged("formula_desc"); }
        }
    }

    public partial class QMS_M009_C : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _hdr_id;
        public int hdr_id
        {
            get { return _hdr_id; }
            set { _hdr_id = value; RaisePropertyChanged("hdr_id"); }
        }
        private string _test_type_code;
        public string test_type_code
        {
            get { return _test_type_code; }
            set { _test_type_code = value; RaisePropertyChanged("test_type_code"); }
        }
        private int? _seq_no;
        public int? seq_no
        {
            get { return _seq_no; }
            set { _seq_no = value; RaisePropertyChanged("seq_no"); }
        }
        private string _hdr_name;
        public string hdr_name
        {
            get { return _hdr_name; }
            set { _hdr_name = value; RaisePropertyChanged("hdr_name"); }
        }
        private string _hdr_desc;
        public string hdr_desc
        {
            get { return _hdr_desc; }
            set { _hdr_desc = value; RaisePropertyChanged("hdr_desc"); }
        }
        private decimal? _std_value;
        public decimal? std_value
        {
            get { return _std_value; }
            set { _std_value = value; RaisePropertyChanged("std_value"); }
        }
        private decimal? _l_value;
        public decimal? l_value
        {
            get { return _l_value; }
            set { _l_value = value; RaisePropertyChanged("l_value"); }
        }
        private decimal? _h_value;
        public decimal? h_value
        {
            get { return _h_value; }
            set { _h_value = value; RaisePropertyChanged("h_value"); }
        }
        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code"); }
        }
        private bool? _active;
        public bool? active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }
        }
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }
        private DateTime _add_date;
        public DateTime add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
        }
        private string _editby;
        public string editby
        {
            get { return _editby; }
            set { _editby = value; RaisePropertyChanged("editby"); }
        }
        private DateTime? _edit_date;
        public DateTime? edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
        }
        
        private string _insp_char;
        public string insp_char
        {
            get { return _insp_char; }
            set { _insp_char = value; RaisePropertyChanged("insp_char"); }
        }
        // Scalar 
        private int? _srno;
        public int? srno
        {
            get { return _srno; }
            set { _srno = value; RaisePropertyChanged("srno"); }
        }
    }

    public partial class QMS_M009_D : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _value_id;
        public int value_id
        {
            get { return _value_id; }
            set { _value_id = value; RaisePropertyChanged("value_id"); }
        }
        private int _hdr_id;
        public int hdr_id
        {
            get { return _hdr_id; }
            set { _hdr_id = value; RaisePropertyChanged("hdr_id"); }
        }
        private string _column_value;
        public string column_value
        {
            get { return _column_value; }
            set { _column_value = value; RaisePropertyChanged("column_value"); }
        }
        private int? _seq_no;
        public int? seq_no
        {
            get { return _seq_no; }
            set { _seq_no = value; RaisePropertyChanged("seq_no"); }
        }
        private bool? _def_bit;
        public bool? def_bit
        {
            get { return _def_bit; }
            set { _def_bit = value; RaisePropertyChanged("def_bit"); }
        }
        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code"); }
        }
        private bool? _active;
        public bool? active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }
        }
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }
        private DateTime _add_date;
        public DateTime add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
        }
        private string _editby;
        public string editby
        {
            get { return _editby; }
            set { _editby = value; RaisePropertyChanged("editby"); }
        }
        private DateTime? _edit_date;
        public DateTime? edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
        }
        
        private decimal? _std_value;
        public decimal? std_value
        {
            get { return _std_value; }
            set { _std_value = value; RaisePropertyChanged("std_value"); }
        }
        private decimal? _l_value;
        public decimal? l_value
        {
            get { return _l_value; }
            set { _l_value = value; RaisePropertyChanged("l_value"); }
        }
        private decimal? _h_value;
        public decimal? h_value
        {
            get { return _h_value; }
            set { _h_value = value; RaisePropertyChanged("h_value"); }
        }
        private decimal? _value_from;
        public decimal? value_from
        {
            get { return _value_from; }
            set
            {
                if (_value_from != value)
                {
                    _value_from = value;
                    RaisePropertyChanged("value_from", ModelEntityUpdated);
                }              
            }
        }
        private string _value_from_unit;
        public string value_from_unit
        {
            get { return _value_from_unit; }
            set
            {
                if (_value_from_unit != value)
                {
                    _value_from_unit = value;
                    RaisePropertyChanged("value_from_unit", ModelEntityUpdated);
                }
            }
        }
        private decimal? _value_to;
        public decimal? value_to
        {
            get { return _value_to; }
            set
            {
                if (_value_to != value)
                {
                    _value_to = value;
                    RaisePropertyChanged("value_to", ModelEntityUpdated);
                }
            }
        }
        private string _value_to_unit;
        public string value_to_unit
        {
            get { return _value_to_unit; }
            set
            {
                if (_value_to_unit != value)
                {
                    _value_to_unit = value;
                    RaisePropertyChanged("value_to_unit", ModelEntityUpdated);
                }
            }
        }
        // Scalar 
        private int? _srno;
        public int? srno
        {
            get { return _srno; }
            set { _srno = value; RaisePropertyChanged("srno"); }
        }
        private int? _deletion_id;
        public int? deletion_id
        {
            get { return _deletion_id; }
            set { _deletion_id = value; RaisePropertyChanged("deletion_id"); }
        }
        private string _test_type_code;
        public string test_type_code
        {
            get { return _test_type_code; }
            set { _test_type_code = value; RaisePropertyChanged("test_type_code"); }
        }
    }

    public partial class QMS_M009_E : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _header_id;
        public int header_id
        {
            get { return _header_id; }
            set { _header_id = value; RaisePropertyChanged("header_id"); }
        }
        private string _test_type_code;
        public string test_type_code
        {
            get { return _test_type_code; }
            set { _test_type_code = value; RaisePropertyChanged("test_type_code"); }
        }
        private int? _seq_no;
        public int? seq_no
        {
            get { return _seq_no; }
            set { _seq_no = value; RaisePropertyChanged("seq_no"); }
        }
        private string _rdg_header;
        public string rdg_header
        {
            get { return _rdg_header; }
            set { _rdg_header = value; RaisePropertyChanged("rdg_header"); }
        }
        private string _short_name;
        public string short_name
        {
            get { return _short_name; }
            set { _short_name = value; RaisePropertyChanged("short_name"); }
        }
        private string _rdg_type;
        public string rdg_type
        {
            get { return _rdg_type; }
            set { _rdg_type = value; RaisePropertyChanged("rdg_type"); }
        }
        private bool? _active;
        public bool? active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }
        //Scalar
        private int? _deletion_id;
        public int? deletion_id
        {
            get { return _deletion_id; }
            set { _deletion_id = value; RaisePropertyChanged("deletion_id"); }
        }
    }

    public partial class QMS_M009_F : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private string _para_code;
        public string para_code
        {
            get { return _para_code; }
            set { _para_code = value; RaisePropertyChanged("para_code", ModelEntityUpdated); }
        }
        private string _para_name;
        public string para_name
        {
            get { return _para_name; }
            set { _para_name = value; RaisePropertyChanged("para_name"); }
        }
        private string _tcm_code;
        public string tcm_code
        {
            get { return _tcm_code; }
            set { _tcm_code = value; RaisePropertyChanged("tcm_code"); }
        }
        private string _test_code;
        public string test_code
        {
            get { return _test_code; }
            set { _test_code = value; RaisePropertyChanged("test_code"); }
        }
        private bool? _allow_null;
        public bool? allow_null
        {
            get { return _allow_null; }
            set { _allow_null = value; RaisePropertyChanged("allow_null"); }
        }
        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code"); }
        }
        private bool? _active;
        public bool? active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }
        }
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }
        private DateTime _add_date;
        public DateTime add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
        }
        private string _editby;
        public string editby
        {
            get { return _editby; }
            set { _editby = value; RaisePropertyChanged("editby"); }
        }
        private DateTime? _edit_date;
        public DateTime? edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
        }
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id"); }
        }
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }
        
        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set { _lang_key = value; RaisePropertyChanged("lang_key"); }
        }
        
        private string _para_type;
        public string para_type
        {
            get { return _para_type; }
            set { _para_type = value; RaisePropertyChanged("para_type"); }
        }

        private string _record_use;
        public string record_use
        {
            get { return _record_use; }
            set { _record_use = value; RaisePropertyChanged("record_use"); }
        }

        private Nullable<System.DateTime> _valid_from;
        public Nullable<System.DateTime> valid_from
        {
            get { return _valid_from; }
            set { _valid_from = value; RaisePropertyChanged("valid_from"); }
        }

        private string _CatlogName;
        public string CatlogName
        {
            get { return _CatlogName; }
            set { _CatlogName = value; RaisePropertyChanged("CatlogName"); }
        }

        //scalar
        public int value_id { get; set; }
        public string value_code { get; set; }
        public string para_value { get; set; }
        public string unit_value { get; set; }

        public string XmlDataDocument_FlipGrid { get; set; }
    }

    public partial class QMS_M009_G : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }
        private string _value_code;
        public string value_code
        {
            get { return _value_code; }
            set { _value_code = value; RaisePropertyChanged("value_code", ModelEntityUpdated); }
        }
        private string _para_value;
        public string para_value
        {
            get { return _para_value; }
            set { _para_value = value; RaisePropertyChanged("para_value"); }
        }
        private string _para_code;
        public string para_code
        {
            get { return _para_code; }
            set { _para_code = value; RaisePropertyChanged("para_code"); }
        }
        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code"); }
        }
        private bool? _active;
        public bool? active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }
        }
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }
        private DateTime _add_date;
        public DateTime add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
        }
        private string _editby;
        public string editby
        {
            get { return _editby; }
            set { _editby = value; RaisePropertyChanged("editby"); }
        }
        private DateTime? _edit_date;
        public DateTime? edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
        }
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id"); }
        }
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }
        
        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set { _lang_key = value; RaisePropertyChanged("lang_key"); }
        }
        
        private string _para_type;
        public string para_type
        {
            get { return _para_type; }
            set { _para_type = value; RaisePropertyChanged("para_type"); }
        }

        private string _version_no;
        public string version_no
        {
            get { return _version_no; }
            set { _version_no = value; RaisePropertyChanged("version_no"); }
        }
        private Nullable<System.DateTime> _valid_from;
        public Nullable<System.DateTime> valid_from
        {
            get { return _valid_from; }
            set { _valid_from = value; RaisePropertyChanged("valid_from"); }
        }

        private string _defect_class;
        public string defect_class
        {
            get { return _defect_class; }
            set { _defect_class = value; RaisePropertyChanged("defect_class"); }
        }

        private string _record_use;
        public string record_use
        {
            get { return _record_use; }
            set { _record_use = value; RaisePropertyChanged("record_use"); }
        }

        //Scalar
        private string _defect_desc;
        public string defect_desc
        {
            get { return _defect_desc; }
            set { _defect_desc = value; RaisePropertyChanged("defect_desc"); }
        }

        private bool _Click;
        public bool Click
        {
            get { return _Click; }
            set { _Click = value; RaisePropertyChanged("Click"); }
        }
    }

    public partial class QMS_M009_H : ObjectBase
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }
        private string _test_code;
        public string test_code
        {
            get { return _test_code; }
            set { _test_code = value; RaisePropertyChanged("test_code"); }
        }
        private string _test_type_code;
        public string test_type_code
        {
            get { return _test_type_code; }
            set { _test_type_code = value; RaisePropertyChanged("test_type_code"); }
        }
        private string _tl_code;
        public string tl_code
        {
            get { return _tl_code; }
            set { _tl_code = value; RaisePropertyChanged("tl_code"); }
        }
        private bool? _active;
        public bool? active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }

        //Scalar
        private string _short_text;
        public string short_text
        {
            get { return _short_text; }
            set { _short_text = value; RaisePropertyChanged("short_text"); }
        }
    }

    public partial class QMS_M009_J : ObjectBase
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }
        private string _test_code;
        public string test_code
        {
            get { return _test_code; }
            set { _test_code = value; RaisePropertyChanged("test_code"); }
        }
        private string _test_type_code;
        public string test_type_code
        {
            get { return _test_type_code; }
            set { _test_type_code = value; RaisePropertyChanged("test_type_code"); }
        }
        private int _hdr_id;
        public int hdr_id
        {
            get { return _hdr_id; }
            set { _hdr_id = value; RaisePropertyChanged("hdr_id"); }
        }
        private int? _value_id1;
        public int? value_id1
        {
            get { return _value_id1; }
            set
            {
                _value_id1 = value;
                RaisePropertyChanged("value_id1");
            }
        }

        private int? _value_id2;
        public int? value_id2
        {
            get { return _value_id2; }
            set
            {
                _value_id2 = value;
                RaisePropertyChanged("value_id2");
            }
        }

        private int? _value_id3;
        public int? value_id3
        {
            get { return _value_id3; }
            set
            {
                _value_id3 = value;
                RaisePropertyChanged("value_id3");
            }
        }

        private int? _value_id4;
        public int? value_id4
        {
            get { return _value_id4; }
            set
            {
                _value_id4 = value;
                RaisePropertyChanged("value_id4");
            }
        }

        private int? _value_id5;
        public int? value_id5
        {
            get { return _value_id5; }
            set
            {
                _value_id5 = value;
                RaisePropertyChanged("value_id5");
            }
        }

        private int? _value_id6;
        public int? value_id6
        {
            get { return _value_id6; }
            set
            {
                _value_id6 = value;
                RaisePropertyChanged("value_id6");
            }
        }

        private int? _value_id7;
        public int? value_id7
        {
            get { return _value_id7; }
            set
            {
                _value_id7 = value;
                RaisePropertyChanged("value_id7");
            }
        }

        private int? _value_id8;
        public int? value_id8
        {
            get { return _value_id8; }
            set
            {
                _value_id8 = value;
                RaisePropertyChanged("value_id8");
            }
        }

        private int? _value_id9;
        public int? value_id9
        {
            get { return _value_id9; }
            set
            {
                _value_id9 = value;
                RaisePropertyChanged("value_id9");
            }
        }

        private int? _value_id10;
        public int? value_id10
        {
            get { return _value_id10; }
            set
            {
                _value_id10 = value;
                RaisePropertyChanged("value_id10");
            }
        }
        private int _header_id;
        public int header_id
        {
            get { return _header_id; }
            set { _header_id = value; RaisePropertyChanged("header_id"); }
        }
        private decimal? _header_value;
        public decimal? header_value
        {
            get { return _header_value; }
            set { _header_value = value; RaisePropertyChanged("header_value"); }
        }
        private decimal? _uncertainty;
        public decimal? uncertainty
        {
            get { return _uncertainty; }
            set { _uncertainty = value; RaisePropertyChanged("uncertainty"); }
        }
        private string _uncertainty_unit;
        public string uncertainty_unit
        {
            get { return _uncertainty_unit; }
            set { _uncertainty_unit = value; RaisePropertyChanged("uncertainty_unit"); }
        }
        private DateTime? _due_date;
        public DateTime? due_date
        {
            get { return _due_date; }
            set { _due_date = value; RaisePropertyChanged("due_date"); }
        }
        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code"); }
        }
        private bool? _active;
        public bool? active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }
        }
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }
        private DateTime _add_date;
        public DateTime add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
        }
        private string _editby;
        public string editby
        {
            get { return _editby; }
            set { _editby = value; RaisePropertyChanged("editby"); }
        }
        private DateTime? _edit_date;
        public DateTime? edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
        }
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id"); }
        }
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }
        
        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set { _lang_key = value; RaisePropertyChanged("lang_key"); }
        }
        
        private decimal? _accuracy_up;
        public decimal? accuracy_up
        {
            get { return _accuracy_up; }
            set { _accuracy_up = value; RaisePropertyChanged("accuracy_up"); }
        }
        private string _accuracy_up_unit;
        public string accuracy_up_unit
        {
            get { return _accuracy_up_unit; }
            set { _accuracy_up_unit = value; RaisePropertyChanged("accuracy_up_unit"); }
        }
        private decimal? _accuracy_down;
        public decimal? accuracy_down
        {
            get { return _accuracy_down; }
            set { _accuracy_down = value; RaisePropertyChanged("accuracy_down"); }
        }
        private string _accuracy_down_unit;
        public string accuracy_down_unit
        {
            get { return _accuracy_down_unit; }
            set { _accuracy_down_unit = value; RaisePropertyChanged("accuracy_down_unit"); }
        }
        private decimal? _resolution;
        public decimal? resolution
        {
            get { return _resolution; }
            set { _resolution = value; RaisePropertyChanged("resolution"); }
        }
        private string _resolution_unit;
        public string resolution_unit
        {
            get { return _resolution_unit; }
            set { _resolution_unit = value; RaisePropertyChanged("resolution_unit"); }
        }
        // Scalar
        private string _test_type_name;
        public string test_type_name
        {
            get { return _test_type_name; }
            set { _test_type_name = value; RaisePropertyChanged("test_type_name"); }
        }
        private string _column_value1;
        public string column_value1
        {
            get { return _column_value1; }
            set
            {
                if (value != _column_value1)
                {
                    _column_value1 = value;
                    RaisePropertyChanged("column_value1");
                }
            }
        }

        private string _column_value2;
        public string column_value2
        {
            get { return _column_value2; }
            set
            {
                if (value != _column_value2)
                {
                    _column_value2 = value;
                    RaisePropertyChanged("column_value2");
                }
            }
        }

        private string _column_value3;
        public string column_value3
        {
            get { return _column_value3; }
            set
            {
                if (value != _column_value3)
                {
                    _column_value3 = value;
                    RaisePropertyChanged("column_value3");
                }
            }
        }

        private string _column_value4;
        public string column_value4
        {
            get { return _column_value4; }
            set
            {
                _column_value4 = value;
                RaisePropertyChanged("column_value4");
            }
        }

        private string _column_value5;
        public string column_value5
        {
            get { return _column_value5; }
            set
            {
                _column_value5 = value;
                RaisePropertyChanged("column_value5");
            }
        }

        private string _column_value6;
        public string column_value6
        {
            get { return _column_value6; }
            set
            {
                _column_value6 = value;
                RaisePropertyChanged("column_value6");
            }
        }

        private string _column_value7;
        public string column_value7
        {
            get { return _column_value7; }
            set
            {
                _column_value7 = value;
                RaisePropertyChanged("column_value7");
            }
        }

        private string _column_value8;
        public string column_value8
        {
            get { return _column_value8; }
            set
            {
                _column_value8 = value;
                RaisePropertyChanged("column_value8");
            }
        }

        private string _column_value9;
        public string column_value9
        {
            get { return _column_value9; }
            set
            {
                _column_value9 = value;
                RaisePropertyChanged("column_value9");
            }
        }

        private string _column_value10;
        public string column_value10
        {
            get { return _column_value10; }
            set
            {
                _column_value10 = value;
                RaisePropertyChanged("column_value10");
            }
        }
        private string _header_name;
        public string header_name
        {
            get { return _header_name; }
            set { _header_name = value; RaisePropertyChanged("header_name"); }
        }
        private int _deletion_id;
        public int deletion_id
        {
            get { return _deletion_id; }
            set { _deletion_id = value; RaisePropertyChanged("deletion_id"); }
        }
    }

    public partial class QMS_M009_K : ObjectBase
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }
        private string _test_code;
        public string test_code
        {
            get { return _test_code; }
            set { _test_code = value; RaisePropertyChanged("test_code"); }
        }
        private string _test_type_code;
        public string test_type_code
        {
            get { return _test_type_code; }
            set { _test_type_code = value; RaisePropertyChanged("test_type_code"); }
        }
        private string _env_code;
        public string env_code
        {
            get { return _env_code; }
            set { _env_code = value; RaisePropertyChanged("env_code"); }
        }
        private string _env_name;
        public string env_name
        {
            get { return _env_name; }
            set { _env_name = value; RaisePropertyChanged("env_name"); }
        }
        private decimal? _std_value;
        public decimal? std_value
        {
            get { return _std_value; }
            set { _std_value = value; RaisePropertyChanged("std_value"); }
        }
        private decimal? _upper_value;
        public decimal? upper_value
        {
            get { return _upper_value; }
            set { _upper_value = value; RaisePropertyChanged("upper_value"); }
        }
        private decimal? _lower_value;
        public decimal? lower_value
        {
            get { return _lower_value; }
            set { _lower_value = value; RaisePropertyChanged("lower_value"); }
        }
        private string _std_value_unit;
        public string std_value_unit
        {
            get { return _std_value_unit; }
            set { _std_value_unit = value; RaisePropertyChanged("std_value_unit"); }
        }
        private decimal? _resolution;
        public decimal? resolution
        {
            get { return _resolution; }
            set { _resolution = value; RaisePropertyChanged("resolution"); }
        }
        private string _resolution_unit;
        public string resolution_unit
        {
            get { return _resolution_unit; }
            set { _resolution_unit = value; RaisePropertyChanged("lower_value"); }
        }
        private bool? _active;
        public bool? active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }
        }
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }
        private DateTime _add_date;
        public DateTime add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
        }
        private string _editby;
        public string editby
        {
            get { return _editby; }
            set { _editby = value; RaisePropertyChanged("editby"); }
        }
        private DateTime? _edit_date;
        public DateTime? edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
        }
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id"); }
        }
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }
        
        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set { _lang_key = value; RaisePropertyChanged("lang_key"); }
        }
        
        //Scalar
        private int _deletion_id;
        public int deletion_id
        {
            get { return _deletion_id; }
            set { _deletion_id = value; RaisePropertyChanged("deletion_id"); }
        }
    }

    public class MultipleContext_QMS_M009
    {
        public List<QMS_M009Flip> DocumentDataFlipGrid { get; set; } //DataGridCollection
        public List<ADM_M018_P> Cat { get; set; }  //Cat Master
        public List<QMS_M003_P> CalMaster { get; set; }  //Cal Master
        public List<QMS_M013_P> InspType { get; set; }  //Insp type Master
        public List<QMS_M006_P> TpCode { get; set; } //Test Procedure popup
        public List<QMS_M007_P> WiCode { get; set; } //Work Instruction popup
        public List<ADM_M038_B_P> UnitCode { get; set; }  //UOM List
        public List<QMS_M024Flip> TaskList { get; set; }  //Task List
        public List<ADM_M022_P> ItemService { get; set; }  //Item services
        public List<QMS_M011> FormulaCode { get; set; }  //Formula Codes
        public List<QMS_M017> EnvCond { get; set; }  //Env Conditions
        public List<QMS_M030_I_P> InspectionChar { get; set; }  //Master Inspection Characteristics

        public ObservableCollection<QMS_M009_B> TestTypeEntity { get; set; }    //test types
        public ObservableCollection<QMS_M009_C> TestHeaderEntity { get; set; } //Benchmark headers
        public ObservableCollection<QMS_M009_D> HeaderValueEntity { get; set; } // Bench header values
        public ObservableCollection<QMS_M009_E> MasterHeaderEntity { get; set; } // master headers
        public ObservableCollection<QMS_M009_E> InstHeaderEntity { get; set; }  // instrument headers
        public ObservableCollection<QMS_M009_F> ParameterEntity { get; set; }   //parameter codes
        public ObservableCollection<QMS_M009_G> ParameterValueEntity { get; set; }  //parameter values
        public ObservableCollection<QMS_M009_H> TaskListEntity { get; set; }  //Task List
        public ObservableCollection<QMS_M009_J> MasterValueEntity { get; set; }  //Default Master Readings
        public ObservableCollection<QMS_M009_K> EnvConditionEntity { get; set; }  //Default Environmental Conditions
        public List<QMS_M009_A> MasterEntity { get; set; }  //Test identification
        public List<COM_T003> Attachment { get; set; }
    }

    public class MultipleContext_QMS_M009_F
    {
        public List<QMS_M009_FFlip> FlipGridData { get; set; }
        public List<QMS_M032_P> CatlogMaster { get; set; }
        public List<QMS_M009_F> MasterEntity { get; set; }
    }

    public class MultipleContext_QMS_M009_G
    {
        public List<QMS_M009_GFlip> FlipGridData { get; set; }
        public List<QMS_M009_F_P> GroupCodeMaster { get; set; }
        public ObservableCollection<QMS_M009_G> MasterEntity { get; set; }
        public List<QMS_M031_P> DefectClass { get; set; }
    }
}
