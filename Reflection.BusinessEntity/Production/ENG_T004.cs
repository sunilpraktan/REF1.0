using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessEntity.Production
{
   public class ENG_T004:ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private string _doc_no;
        private string _doc_cat;
        private string _doc_type;
        private DateTime _doc_date;
        private string _language;
        private string _fin_year;
        private string _posting_period;
        private string _comp_code;
        private string _location_Id;
        private string _add_by;
        private DateTime _add_date;
        private string _editby;
        private DateTime _edit_date;
        private bool _active;
        private string _t_status;
        private string _ItemCode;
        private int _ink_id;
        private int _ild_id;
        private int _machine_id;
        private string _machinecode;
        private string _sku;
        private string _sku_desc;
        private int _model_id;
        private string _note;
        private string _front_view;
        private string _back_view;
        private string _top_view;
        private string _bottom_view;
        private int _machine_type_id;
        private int _revision_no;
        private DateTime _revision_date;
        private string _parent_no;
        private int _ball_makeCode;
        private int _wire_makeCode;
        private int _wire_type_id;
        private string _unit_code;
        private int _MakeCode;
        private string _ref_doc_no;
        private string _cycle_type;

        public string doc_no

        {
        get { return _doc_no; }
        set
            {
                _doc_no = value;
                RaisePropertyChanged("doc_no");
            }
        }
        public string doc_cat
        {
            get { return _doc_cat; }
            set
            {
                _doc_cat = value;
                RaisePropertyChanged("doc_cat");
            }
        }
        public string doc_type
        {
            get
            { return _doc_type;}

            set{ _doc_type = value;
            RaisePropertyChanged("doc_type");
            }
        }
        public DateTime doc_date
        {
            get
            {
                return _doc_date;
            }

            set
            {
                _doc_date = value;
                RaisePropertyChanged("doc_date");
            }
        }
        
        public string language
        {
            get
            {
                return _language;
            }

            set
            {
                _language = value;
                RaisePropertyChanged("language");
            }
        }
        public string fin_year
        {
            get
            {
                return _fin_year;
            }

            set
            {
                _fin_year = value;
                RaisePropertyChanged("fin_year");
            }
        }
        public string posting_period
        {
            get
            {
                return _posting_period;
            }

            set
            {
                _posting_period = value;
                RaisePropertyChanged("posting_period");
            }
        }
        public string comp_code
        {
            get
            {
                return _comp_code;
            }

            set
            {
                _comp_code = value;
                RaisePropertyChanged("comp_code");
            }
        }
        public string location_Id
        {
            get
            {
                return _location_Id;
            }

            set
            {
                _location_Id = value;
                RaisePropertyChanged("location_Id");
            }
        }
        public string add_by
        {
            get
            {
                return _add_by;
            }

            set
            {
                _add_by = value;
                RaisePropertyChanged("add_by");
            }
        }
        public DateTime add_date
        {
            get
            {
                return _add_date;
            }

            set
            {
                _add_date = value;
                RaisePropertyChanged("add_date");
            }
        }
        public string editby
        {
            get
            {
                return _editby;
            }

            set
            {
                _editby = value;
                RaisePropertyChanged("editby");
            }
        }
        public DateTime edit_date
        {
            get
            {
                return _edit_date;
            }

            set
            {
                _edit_date = value;
                RaisePropertyChanged("edit_date");
            }
        }
        
        public bool active
        {
            get
            {
                return _active;
            }

            set
            {
                _active = value;
                RaisePropertyChanged("active");
            }
        }
        public string t_status
        {
            get
            {
                return _t_status;
            }

            set
            {
                _t_status = value;
                RaisePropertyChanged("t_status");
            }
        }
        public string ItemCode
        {
            get
            {
                return _ItemCode;
            }

            set
            {
                _ItemCode = value;
                RaisePropertyChanged("ItemCode");
            }
        }
        public int ink_id
        {
            get
            {
                return _ink_id;
            }

            set
            {
                _ink_id = value;
                RaisePropertyChanged("ink_id");
            }
        }
        public int ild_id
        {
            get
            {
                return _ild_id;
            }

            set
            {
                _ild_id = value;
                RaisePropertyChanged("ild_id");
            }
        }
        public int machine_id
        {
            get
            {
                return _machine_id;
            }

            set
            {
                _machine_id = value;
                RaisePropertyChanged("machine_id");
            }
        }
        public string machinecode
        {
            get
            {
                return _machinecode;
            }

            set
            {
                _machinecode = value;
                RaisePropertyChanged("machinecode");
            }
        }
        public string sku
        {
            get
            {
                return _sku;
            }

            set
            {
                _sku = value;
                RaisePropertyChanged("sku");
            }
        }
        public string sku_desc
        {
            get
            {
                return _sku_desc;
            }

            set
            {
                _sku_desc = value;
                RaisePropertyChanged("sku_desc");
            }
        }
        public int model_id
        {
            get
            {
                return _model_id;
            }

            set
            {
                _model_id = value;
                RaisePropertyChanged("model_id");
            }
        }
        public string note
        {
            get
            {
                return _note;
            }

            set
            {
                _note = value;
                RaisePropertyChanged("note");
            }
        }
        public string front_view
        {
            get
            {
                return _front_view;
            }

            set
            {
                _front_view = value;
                RaisePropertyChanged("front_view");
            }
        }
        public string back_view
        {
            get
            {
                return _back_view;
            }

            set
            {
                _back_view = value;
                RaisePropertyChanged("back_view");
            }
        }
        public string top_view
        {
            get
            {
                return _top_view;
            }

            set
            {
                _top_view = value;
                RaisePropertyChanged("top_view");
            }
        }
        public string bottom_view
        {
            get
            {
                return _bottom_view;
            }

            set
            {
                _bottom_view = value;
                RaisePropertyChanged("bottom_view");
            }
        }
        public int machine_type_id
        {
            get
            {
                return _machine_type_id;
            }

            set
            {
                _machine_type_id = value;
                RaisePropertyChanged("machine_type_id");
            }
        }
        public int revision_no
        {
            get
            {
                return _revision_no;
            }

            set
            {
                _revision_no = value;
                RaisePropertyChanged("revision_no");
            }
        }
        public DateTime revision_date
        {
            get
            {
                return _revision_date;
            }

            set
            {
                _revision_date = value;
                RaisePropertyChanged("revision_date");
            }
        }
        public string parent_no
        {
            get
            {
                return _parent_no;
            }

            set
            {
                _parent_no = value;
                RaisePropertyChanged("parent_no");
            }
        }
        public int ball_makeCode
        {
            get
            {
                return _ball_makeCode;
            }

            set
            {
                _ball_makeCode = value;
                RaisePropertyChanged("ball_makeCode");
            }
        }
        public int wire_makeCode
        {
            get
            {
                return _wire_makeCode;
            }

            set
            {
                _wire_makeCode = value;
                RaisePropertyChanged("wire_makeCode");
            }
        }

        public string unit_code
        {
            get
            {
                return _unit_code;
            }

            set
            {
                _unit_code = value;
                RaisePropertyChanged("unit_code");
            }
        }
        public int wire_type_id
        {
            get { return _wire_type_id; }
            set { _wire_type_id = value; RaisePropertyChanged("wire_type_id"); }
        }

        public int MakeCode
        {
            get
            {
                return _MakeCode;
            }

            set
            {
                _MakeCode = value;
                RaisePropertyChanged("MakeCode");
            }
        }       
        public string ref_doc_no
        {
            get { return _ref_doc_no; }
            set { _ref_doc_no = value; RaisePropertyChanged("ref_doc_no"); }
        }
        public string cycle_type
        {
            get { return _cycle_type; }
            set { _cycle_type = value; RaisePropertyChanged("cycle_type"); }
        }

        private string _customer_id;
        public string customer_id
        {
            get { return _customer_id; }
            set { _customer_id = value; RaisePropertyChanged("customer_id"); }
        }

        //scalar
        private string _modelno;
        public string modelno
        {
            get {   return _modelno;   }
            set { _modelno = value;  RaisePropertyChanged("modelno"); }
        }

        private string _modeldesc;
        public string modeldesc
        {
            get { return _modeldesc; }
            set { _modeldesc = value; RaisePropertyChanged("modeldesc"); }
        }

        private string _ItemName;
        public string ItemName
        {
            get { return _ItemName; }
            set { _ItemName = value; RaisePropertyChanged("ItemName"); }
        }

        private string _ink;
        public string ink
        {
            get { return _ink; }
            set { _ink = value; RaisePropertyChanged("ink"); }
        }

        private string _ild;
        public string ild
        {
            get { return _ild; }
            set { _ild = value; RaisePropertyChanged("ild"); }
        }

        private string _Ball_Make;
        public string Ball_Make
        {
            get { return _Ball_Make; }
            set { _Ball_Make = value; RaisePropertyChanged("Ball_Make"); }
        }

        private string _Wire_Make;
        public string Wire_Make
        {
            get { return _Wire_Make; }
            set { _Wire_Make = value; RaisePropertyChanged("Wire_Make"); }
        }

        private string _Wire_Type;
        public string Wire_Type
        {
            get { return _Wire_Type; }
            set { _Wire_Type = value; RaisePropertyChanged("Wire_Type"); }
        }

        private string _LoctnNm;
        public string LoctnNm
        {
            get { return _LoctnNm; }
            set { _LoctnNm = value; RaisePropertyChanged("LoctnNm"); }
        }

        private string _doc_no1;
        public string doc_no1
        {
            get { return _doc_no1; }
            set { _doc_no1 = value; RaisePropertyChanged("doc_no1"); }
        }

        private string _doc_no2;
        public string doc_no2
        {
            get { return _doc_no2; }
            set { _doc_no2 = value; RaisePropertyChanged("doc_no2"); }
        }

        private string _doc_no3;
        public string doc_no3
        {
            get { return _doc_no3; }
            set { _doc_no3 = value; RaisePropertyChanged("doc_no3"); }
        }

        private string _doc_no4;
        public string doc_no4
        {
            get { return _doc_no4; }
            set { _doc_no4 = value; RaisePropertyChanged("doc_no4"); }
        }
        private bool _revision;
        public bool revision
        {
            get { return _revision; }
            set
            {
                _revision = value;
                RaisePropertyChanged("revision");
            }

        }
        private string _Make;
        public string Make
        {
            get { return _Make; }
            set { _Make = value; RaisePropertyChanged("Make"); }
        }

        //scalar for filters

        private string _lctn_id_filter;
        public string lctn_id_filter
        {
            get { return _lctn_id_filter; }
            set { _lctn_id_filter = value; RaisePropertyChanged("lctn_id_filter"); }
        }

        private string _lctn_filter;
        public string lctn_filter
        {
            get { return _lctn_filter; }
            set { _lctn_filter = value; RaisePropertyChanged("lctn_filter"); }
        }

        private int _model_id_filter;
        public int model_id_filter
        {
            get { return _model_id_filter; }
            set { _model_id_filter = value; RaisePropertyChanged("model_id_filter"); }
        }

        private string _modelno_filter;
        public string modelno_filter
        {
            get { return _modelno_filter; }
            set { _modelno_filter = value; RaisePropertyChanged("modelno_filter"); }
        }


        private int _ball_dia_filter;
        public int ball_dia_filter
        {
            get { return _ball_dia_filter; }
            set { _ball_dia_filter = value; RaisePropertyChanged("ball_dia_filter"); }
        }

        private int _ink_id_filter;
        public int ink_id_filter
        {
            get { return _ink_id_filter; }
            set { _ink_id_filter = value; RaisePropertyChanged("ink_id_filter"); }
        }

        private string _ink_filter;
        public string ink_filter
        {
            get { return _ink_filter; }
            set { _ink_filter = value; RaisePropertyChanged("ink_filter"); }
        }

        private int _ild_id_filter;
        public int ild_id_filter
        {
            get { return _ild_id_filter; }
            set { _ild_id_filter = value; RaisePropertyChanged("ild_id_filter"); }
        }

        private string _ild_filter;
        public string ild_filter
        {
            get { return _ild_filter; }
            set { _ild_filter = value; RaisePropertyChanged("ild_filter"); }
        }

        private string _Cust_id_filter;
        public string Cust_id_filter
        {
            get { return _Cust_id_filter; }
            set { _Cust_id_filter = value; RaisePropertyChanged("Cust_id_filter"); }
        }

        private string _Cust_nm_filter;
        public string Cust_nm_filter
        {
            get { return _Cust_nm_filter; }
            set { _Cust_nm_filter = value; RaisePropertyChanged("Cust_nm_filter"); }
        }

        private string _cycle_type_filter;
        public string cycle_type_filter
        {
            get { return _cycle_type_filter; }
            set { _cycle_type_filter = value; RaisePropertyChanged("cycle_type_filter"); }
        }

        public string XmlDataDocument_ENG_T004_A { get; set; }
        public string XmlDataDocument_ENG_T004_B { get; set; }
        public string XmlDataDocument_ENG_T004_C { get; set; }
        public string XmlDataDocument_ENG_T004_D { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }
    } 
    public class ENG_T004_A:ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        private string _doc_no;
        private string _doc_cat;
        private string _doc_type;
        private System.DateTime _doc_date;
        private string _language;
        private string _fin_year;
        private string _posting_period;
        private string _comp_code;
        private string _location_Id;
        private string _add_by;
        private System.DateTime _add_date;
        private string _editby;
        private System.DateTime _edit_date;
        private bool _active;
        private string _t_status;
        private string _revision_no;
        private System.DateTime _revision_date;
        private string _parent_no;
        private string _alternate_item;
        private System.DateTime _create_date;
        private string _range;
        private Nullable<decimal> _tol_minus;
        private Nullable<decimal> _tol_plus;
        private string _frequency;
        private string _spec_type_code;
        private string _parametervalue;
        private string _value_code;
        private string _spec_para_code;
        private string _instrument_code;
        private string _para_value;
        private string _remark;
        private string _sr_no;
        private int? _line_id;

        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                RaisePropertyChanged("id");
            }
        }
        public string doc_no
        {
            get
            {
                return _doc_no;
            }

            set
            {
                _doc_no = value;
                RaisePropertyChanged("doc_no");
            }
        }
        public string doc_cat
        {
            get
            {
                return _doc_cat;
            }

            set
            {
                _doc_cat = value;
                RaisePropertyChanged("doc_cat");
            }
        }
        public string doc_type
        {
            get
            {
                return _doc_type;
            }

            set
            {
                _doc_type = value;
                RaisePropertyChanged("doc_type");
            }
        }
        public DateTime doc_date
        {
            get
            {
                return _doc_date;
            }

            set
            {
                _doc_date = value;
                RaisePropertyChanged("doc_date");
            }
        }
        
        public string language
        {
            get
            {
                return _language;
            }

            set
            {
                _language = value;
                RaisePropertyChanged("language");
            }
        }
        public string fin_year
        {
            get
            {
                return _fin_year;
            }

            set
            {
                _fin_year = value;
                RaisePropertyChanged("fin_year");
            }
        }
        public string posting_period
        {
            get
            {
                return _posting_period;
            }

            set
            {
                _posting_period = value;
                RaisePropertyChanged("posting_period");
            }
        }
        public string comp_code
        {
            get
            {
                return _comp_code;
            }

            set
            {
                _comp_code = value;
                RaisePropertyChanged("comp_code");
            }
        }
        public string location_Id
        {
            get
            {
                return _location_Id;
            }

            set
            {
                _location_Id = value;
                RaisePropertyChanged("location_Id");
            }
        }
        public string add_by
        {
            get
            {
                return _add_by;
            }

            set
            {
                _add_by = value;
                RaisePropertyChanged("add_by");
            }
        }
        public DateTime add_date
        {
            get
            {
                return _add_date;
            }

            set
            {
                _add_date = value;
                RaisePropertyChanged("add_date");
            }
        }
        public string editby
        {
            get
            {
                return _editby;
            }

            set
            {
                _editby = value;
                RaisePropertyChanged("editby");
            }
        }
        public DateTime edit_date
        {
            get
            {
                return _edit_date;
            }

            set
            {
                _edit_date = value;
                RaisePropertyChanged("edit_date");
            }
        }
        
        public bool active
        {
            get
            {
                return _active;
            }

            set
            {
                _active = value;
                RaisePropertyChanged("active");
            }
        }
        public string t_status
        {
            get
            {
                return _t_status;
            }

            set
            {
                _t_status = value;
                RaisePropertyChanged("t_status");
            }
        }
        public string revision_no
        {
            get
            {
                return _revision_no;
            }

            set
            {
                _revision_no = value;
                RaisePropertyChanged("revision_no");
            }
        }
        public System.DateTime revision_date
        {
            get
            {
                return _revision_date;
            }

            set
            {
                _revision_date = value;
                RaisePropertyChanged("revision_date");
            }
        }
        public string parent_no
        {
            get
            {
                return _parent_no;
            }

            set
            {
                _parent_no = value;
                RaisePropertyChanged("parent_no");
            }
        }
        public string alternate_item
        {
            get
            {
                return _alternate_item;
            }

            set
            {
                _alternate_item = value;
                RaisePropertyChanged("alternate_item");
            }
        }
        public DateTime create_date
        {
            get
            {
                return _create_date;
            }

            set
            {
                _create_date = value;
                RaisePropertyChanged("create_date");
            }
        }
        public string range
        {
            get
            {
                return _range;
            }

            set
            {
                _range = value;
                RaisePropertyChanged("range");
            }
        }
        public decimal? tol_minus
        {
            get
            {
                return _tol_minus;
            }

            set
            {
                _tol_minus = value;
                RaisePropertyChanged("tol_minus" , ModelEntityUpdated);
            }
        }
        public decimal? tol_plus
        {
            get
            {
                return _tol_plus;
            }

            set
            {
                _tol_plus = value;
                RaisePropertyChanged("tol_plus", ModelEntityUpdated);
            }
        }
        public string frequency
        {
            get
            {
                return _frequency;
            }

            set
            {
                _frequency = value;
                RaisePropertyChanged("frequency");
            }
        }
        public string spec_type_code
        {
            get{ return _spec_type_code; }
            set
            {
                _spec_type_code = value;
                RaisePropertyChanged("spec_type_code");
            }
        }
        public string parametervalue
        {
            get { return _parametervalue; }
            set
            {
                _parametervalue = value;
                RaisePropertyChanged("parametervalue");
            }
        }
        public string value_code
        {
            get { return _value_code; }
            set
            {
                _value_code = value;
                RaisePropertyChanged("value_code");
            }
        }
        public string spec_para_code
        {
            get
            {
                return _spec_para_code;
            }

            set
            {
                _spec_para_code = value;
                RaisePropertyChanged("spec_para_code");
            }
        }
        public string instrument_code
        {
            get
            {
                return _instrument_code;
            }

            set
            {
                _instrument_code = value;
                RaisePropertyChanged("instrument_code");
            }
        }
        public string para_value
        {
            get
            {
                return _para_value;
            }

            set
            {
                _para_value = value;
                RaisePropertyChanged("para_value", ModelEntityUpdated);
            }
        }
        public string remark
        {
            get
            {
                return _remark;
            }

            set
            {
                _remark = value;
                RaisePropertyChanged("remark");
            }
        }
        public string sr_no
        {
            get
            {
                return _sr_no;
            }

            set
            {
                _sr_no = value;
                RaisePropertyChanged("sr_no");
            }
        }
        public int? line_id
        {
            get { return _line_id; }
            set { _line_id = value; RaisePropertyChanged("line_id"); }
        }

        //scaler
        private string _spec_type;
        public string spec_type
        {
            get { return _spec_type; }
            set { _spec_type = value; RaisePropertyChanged("spec_type"); }
        }

        private string _parameter;
        public string parameter
        {
            get { return _parameter; }
            set { _parameter = value; RaisePropertyChanged("parameter"); }
        }
        private string _instrument;
        public string instrument
        {
            get { return _instrument; }
            set { _instrument = value; RaisePropertyChanged("instrument"); }
        }

    }
    public class ENG_T004_B:ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        private string _doc_no;
        private string _doc_cat;
        private string _doc_type;
        private string _datetime;
        private string _language;
        private string _fin_year;
        private string _posting_period;
        private string _comp_code;
        private string _location_Id;
        private string _add_by;
        private System.DateTime _add_date;
        private string _editby;
        private System.DateTime _edit_date;
        private bool _active;
        private string _t_status;
        private string _revision_no;
        private System.DateTime _revision_date;
        private string _parent_no;
        private string _alternate_item;
        private string _section_type;
        private Nullable<decimal> _quantity;
        private string _life_days;
        private string _life_qty;
        private string _remark;
        private Nullable<decimal> _length;
        private string _ItemCode;
        private Nullable<decimal> _degree;
        private string _drill_spec;
        private Nullable<decimal> _drill_section;
        private string _stn_no;
        private string _type;
        private int _MakeCode;
        private string _make;
        private int _ball_dia_id;
        private int _wire_dia_id;
        private int _ball_MakeCode;
        private int _wire_MakeCode;
        private string _ball_grade_code;
        private string _wire_grade_code;
        private int _ink_id;
        private string _material;
        private string _grade;
        private string _ild_aurora;
        private string _surface_fnsh;
        private string _work_type;
        private string _bin_no;
        private string _gbi_obi_type;
        private string _colors;
        private decimal? _tol_minus;
        private decimal? _tol_plus;
        private int? _line_id;
        public int id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
                RaisePropertyChanged("id");
            }
        }
        public string doc_no
        {
            get
            {
                return _doc_no;
            }

            set
            {
                _doc_no = value;
                RaisePropertyChanged("doc_no");
            }
        }
        public string doc_cat
        {
            get
            {
                return _doc_cat;
            }

            set
            {
                _doc_cat = value;
                RaisePropertyChanged("doc_cat");
            }
        }
        public string doc_type
        {
            get
            {
                return _doc_type;
            }

            set
            {
                _doc_type = value;
                RaisePropertyChanged("doc_type");
            }
        }
        public string datetime
        {
            get
            {
                return _datetime;
            }

            set
            {
                _datetime = value;
                RaisePropertyChanged("datetime");
            }
        }
        
        public string language
        {
            get
            {
                return _language;
            }

            set
            {
                _language = value;
                RaisePropertyChanged("language");
            }
        }
        public string fin_year
        {
            get
            {
                return _fin_year;
            }

            set
            {
                _fin_year = value;
                RaisePropertyChanged("fin_year");
            }
        }
        public string posting_period
        {
            get
            {
                return _posting_period;
            }

            set
            {
                _posting_period = value;
                RaisePropertyChanged("posting_period");
            }
        }
        public string comp_code
        {
            get
            {
                return _comp_code;
            }

            set
            {
                _comp_code = value;
                RaisePropertyChanged("comp_code");
            }
        }
        public string location_Id
        {
            get
            {
                return _location_Id;
            }

            set
            {
                _location_Id = value;
                RaisePropertyChanged("location_Id");
            }
        }
        public string add_by
        {
            get
            {
                return _add_by;
            }

            set
            {
                _add_by = value;
                RaisePropertyChanged("add_by");
            }
        }
        public DateTime add_date
        {
            get
            {
                return _add_date;
            }

            set
            {
                _add_date = value;
                RaisePropertyChanged("add_date");
            }
        }
        public string editby
        {
            get
            {
                return _editby;
            }

            set
            {
                _editby = value;
                RaisePropertyChanged("editby");
            }
        }
        public DateTime edit_date
        {
            get
            {
                return _edit_date;
            }

            set
            {
                _edit_date = value;
                RaisePropertyChanged("edit_date");
            }
        }
        
        public bool active
        {
            get
            {
                return _active;
            }

            set
            {
                _active = value;
                RaisePropertyChanged("active");
            }
        }
        public string t_status
        {
            get
            {
                return _t_status;
            }

            set
            {
                _t_status = value;
                RaisePropertyChanged("t_status");
            }
        }
        public string revision_no
        {
            get
            {
                return _revision_no;
            }

            set
            {
                _revision_no = value;
                RaisePropertyChanged("revision_no");
            }
        }
        public DateTime revision_date
        {
            get
            {
                return _revision_date;
            }

            set
            {
                _revision_date = value;
                RaisePropertyChanged("revision_date");
            }
        }
        public string parent_no
        {
            get
            {
                return _parent_no;
            }

            set
            {
                _parent_no = value;
                RaisePropertyChanged("parent_no");
            }
        }
        public string alternate_item
        {
            get
            {
                return _alternate_item;
            }

            set
            {
                _alternate_item = value;
                RaisePropertyChanged("alternate_item");
            }
        }
        public string section_type
        {
            get
            {
                return _section_type;
            }

            set
            {
                _section_type = value;
                RaisePropertyChanged("section_type");
            }
        }
        public decimal? quantity
        {
            get
            {
                return _quantity;
            }

            set
            {
                _quantity = value;
                RaisePropertyChanged("quantity");
            }
        }
        public string life_days
        {
            get
            {
                return _life_days;
            }

            set
            {
                _life_days = value;
                RaisePropertyChanged("life_days");
            }
        }
        public string life_qty
        {
            get
            {
                return _life_qty;
            }

            set
            {
                _life_qty = value;
                RaisePropertyChanged("life_qty");
            }
        }
        public string remark
        {
            get
            {
                return _remark;
            }

            set
            {
                _remark = value;
                RaisePropertyChanged("remark");
            }
        }
        public decimal? length
        {
            get
            {
                return _length;
            }

            set
            {
                _length = value;
                RaisePropertyChanged("length");
            }
        }
        public string ItemCode
        {
            get
            {
                return _ItemCode;
            }

            set
            {
                _ItemCode = value;
                RaisePropertyChanged("ItemCode");
            }
        }
        public decimal? degree
        {
            get
            {
                return _degree;
            }

            set
            {
                _degree = value;
                RaisePropertyChanged("degree");
            }
        }
        public string drill_spec
        {
            get
            {
                return _drill_spec;
            }

            set
            {
                _drill_spec = value;
                RaisePropertyChanged("drill_spec");
            }
        }
        public decimal? drill_section
        {
            get
            {
                return _drill_section;
            }

            set
            {
                _drill_section = value;
                RaisePropertyChanged("drill_section");
            }
        }
        public string stn_no
        {
            get
            {
                return _stn_no;
            }

            set
            {
                _stn_no = value;
                RaisePropertyChanged("_stn_no");
            }
        }
        public string type
        {
            get { return _type; }
            set { _type = value; RaisePropertyChanged("type");   }
        }
        public int MakeCode
        {
            get { return _MakeCode; }
            set { _MakeCode = value; RaisePropertyChanged("MakeCode"); }
        }
        public string make
        {
            get { return _make; }
            set { _make = value; RaisePropertyChanged("make"); }
        }
        public int ball_dia_id
        {
            get { return _ball_dia_id; }
            set { _ball_dia_id = value; RaisePropertyChanged("ball_dia_id"); }
        }
        public int wire_dia_id
        {
            get { return _wire_dia_id; }
            set { _wire_dia_id = value; RaisePropertyChanged("wire_dia_id"); }
        }
        public int ball_MakeCode
        {
            get { return _ball_MakeCode; }
            set { _ball_MakeCode = value; RaisePropertyChanged("ball_MakeCode"); }
        }
        public int wire_MakeCode
        {
            get { return _wire_MakeCode; }
            set { _wire_MakeCode = value; RaisePropertyChanged("wire_MakeCode"); }
        }
        public string ball_grade_code
        {
            get { return _ball_grade_code; }
            set { _ball_grade_code = value; RaisePropertyChanged("ball_grade_code"); }
        }
        public string wire_grade_code
        {
            get { return _wire_grade_code; }
            set { _wire_grade_code = value; RaisePropertyChanged("wire_grade_code"); }
        }
        public int ink_id
        {
            get { return _ink_id; }
            set { _ink_id = value; RaisePropertyChanged("ink_id"); }
        }
        public string material
        {
            get { return _material; }
            set { _material = value; RaisePropertyChanged("material"); }
        }
        public string grade
        {
            get { return _grade; }
            set { _grade = value; RaisePropertyChanged("grade"); }
        }
        public string ild_aurora
        {
            get { return _ild_aurora; }
            set { _ild_aurora = value; RaisePropertyChanged("ild_aurora"); }
        }
        public string surface_fnsh
        {
            get { return _surface_fnsh; }
            set { _surface_fnsh = value; RaisePropertyChanged("surface_fnsh"); }
        }
        public string work_type
        {
            get { return _work_type; }
            set { _work_type = value; RaisePropertyChanged("work_type"); }
        }
        public string bin_no
        {
            get { return _bin_no; }
            set { _bin_no = value; RaisePropertyChanged("bin_no"); }
        }
        public string gbi_obi_type
        {
            get { return _gbi_obi_type; }
            set { _gbi_obi_type = value; RaisePropertyChanged("gbi_obi_type"); }
        }
        public string colors
        {
            get { return _colors; }
            set { _colors = value; RaisePropertyChanged("colors"); }
        }
        public decimal? tol_minus
        {
            get { return _tol_minus; }
            set { _tol_minus = value; RaisePropertyChanged("tol_minus"); }
        }
        public decimal? tol_plus
        {
            get { return _tol_plus; }
            set { _tol_plus = value; RaisePropertyChanged("tol_plus"); }
        }
        public int? line_id
        {
            get { return _line_id; }
            set { _line_id = value; RaisePropertyChanged("line_id"); }
        }
        //scalar
        private string _ItemName;
        public string ItemName
        {
            get { return _ItemName; }
            set {  _ItemName = value; RaisePropertyChanged("ItemName");   }
        }
        private string _alternate_itemName;
        public string alternate_itemName
        {
            get {  return _alternate_itemName;  }
            set { _alternate_itemName = value;  RaisePropertyChanged("alternate_itemName"); }
        }
        private string _ild;
        public string ild
        {
            get {  return _ild;  }
            set {_ild = value;  RaisePropertyChanged("ild");  }
        }
        private string _ink;
        public string ink
        {
            get { return _ink; }
            set { _ink = value; RaisePropertyChanged("ink"); }
        }
        private string _Make;
        public string Make
        {
            get { return _Make;}
            set { _Make = value;RaisePropertyChanged("Make"); }
        }
        private decimal _Ball_dia;
        public decimal Ball_dia
        {
            get { return _Ball_dia; }
            set { _Ball_dia = value; RaisePropertyChanged("Ball_dia"); }
        }
        private decimal _wire_size;
        public decimal wire_size
        {
            get { return _wire_size; }
            set { _wire_size = value; RaisePropertyChanged("wire_size"); }
        }
        private string _BallMake;
        public string BallMake
        {
            get { return _BallMake; }
            set { _BallMake = value; RaisePropertyChanged("BallMake"); }
        }
        private string _WireMake;
        public string WireMake
        {
            get { return _WireMake; }
            set { _WireMake = value; RaisePropertyChanged("WireMake"); }
        }
        private string _Working;
        public string Working
        {
            get { return _Working; }
            set { _Working = value; RaisePropertyChanged("Working"); }
        }
        private string _parametervalue;
        public string parametervalue
        {
            get { return _parametervalue; }
            set
            {
                _parametervalue = value;
                RaisePropertyChanged("parametervalue");
            }
        }
        public string parameter { get; set; }
        public string para_value { get; set; }
        public Nullable<decimal> tol_minus_A { get; set; }
        public Nullable<decimal> tol_plus_A { get; set; }

    }
    public class ENG_T004_C:ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int _id;
        private string _doc_no;
        private string _doc_cat;
        private string _doc_type;
        private string _ild;
        private string _ball_range;
        private string _ball_out;
        private string _hammer;
        private string _spring;
        private bool _active;
        private string _t_status;
        private string _comp_code;
        private string _location_Id;
        private string _add_by;
        private DateTime _add_date;
        private string _editby;
        private DateTime _edit_date;
    
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }
        
        public string doc_no
        {
            get { return _doc_no; }
            set { _doc_no = value; RaisePropertyChanged("doc_no"); }
        }
        public string doc_cat
        {
            get { return _doc_cat; }
            set { _doc_cat = value; RaisePropertyChanged("doc_cat"); }
        }
        public string doc_type
        {
            get { return _doc_type; }
            set { _doc_type = value; RaisePropertyChanged("doc_type"); }
        }
        public string ild
        {
            get { return _ild; }
            set { _ild = value; RaisePropertyChanged("ild"); }
        }
        public string ball_range
        {
            get { return _ball_range; }
            set { _ball_range = value; RaisePropertyChanged("ball_range"); }
        }
        public string ball_out
        {
            get { return _ball_out; }
            set { _ball_out = value; RaisePropertyChanged("ball_out"); }
        }
        public string hammer
        {
            get { return _hammer; }
            set { _hammer = value; RaisePropertyChanged("hammer"); }
        }
        public string spring
        {
            get { return _spring; }
            set { _spring = value; RaisePropertyChanged("spring"); }
        }
        public bool active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }
        }
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id"); }
        }
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }
        public DateTime add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
        }
        public string editby
        {
            get { return _editby; }
            set { _editby = value; RaisePropertyChanged("editby"); }
        }
        public DateTime edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
        }
        
    }
    public class ENG_T004_D : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int _id;
        private string _doc_no;
        private string _doc_cat;
        private string _doc_type;
        private string _PartyId;
        private string _comp_code;
        private string _location_Id;
        private bool _active;
        private string _t_status;
        private string _add_by;
        private DateTime _add_date;
        private string _editby;
        private DateTime _edit_date;
        private string _PartyNm;

        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }

        public string doc_no
        {
            get { return _doc_no; }
            set { _doc_no = value; RaisePropertyChanged("doc_no"); }
        }
        public string doc_cat
        {
            get { return _doc_cat; }
            set { _doc_cat = value; RaisePropertyChanged("doc_cat"); }
        }
        public string doc_type
        {
            get { return _doc_type; }
            set { _doc_type = value; RaisePropertyChanged("doc_type"); }
        }
        public string PartyId
        {
            get { return _PartyId; }
            set { _PartyId = value; RaisePropertyChanged("PartyId"); }
        }
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id"); }
        }
       
        public bool active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }
        }       
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }
        public DateTime add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
        }
        public string editby
        {
            get { return _editby; }
            set { _editby = value; RaisePropertyChanged("editby"); }
        }
        public DateTime edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
        }
        public string PartyNm
        {
            get { return _PartyNm; }
            set { _PartyNm = value; RaisePropertyChanged("PartyNm"); }
        }
    }
    public class MultipleContext_ENG_T004
    {
        public List<COM_T003> MediaList { get; set; }
        public List<ENG_T004> MasterEntity { get; set; }
        public ObservableCollection<ENG_T004_A> ParaDetailEntity { get; set; }
        public ObservableCollection<ENG_T004_B> ControlParaDetailEntity { get; set; }
        public List<ENG_T004_P> BackflipList { get; set; }
        public List<ADM_M022_P> ItemList { get; set; } //Item Master
        public List<ADM_M038_B_P> UnitList { get; set; } //Unit Master
        public List<ZADM_M007_P> ILD { get; set; } //ILD Master
        public List<ZADM_M006_P> Ink { get; set; }  //Ink Master
        public List<ZADM_M013_P> MachineList { get; set; } //Machine Master
        public List<ZADM_M009_P> ModelList { get; set; } //Model Master
        public List<ADM_M030_P> StationNoList { get; set; }//station type master
        public List<ENG_T002> SpecificationTypeList { get; set; }//specification type master
        public List<ENG_T003> SpecificationParaList { get; set; }//specification Parameter master
        public List<ENG_T003> WorkingList { get; set; }//working list
        public List<ENG_T003> InstrumentList { get; set; }//instrument list
        //public List<ADM_M032_P> BallMakeList { get; set; }
        //public List<ADM_M032_P> WireMakeList { get; set; }
        public List<ZADM_M004_P> WireTypeList { get; set; }
        public List<ADM_M045_P> GradeList { get; set; }
        //public List<ADM_M032_P> MakeList { get; set; }       
        public List<ADM_M030_P> ParamValueList { get; set; } 
        public List<COM_T003> Attachment { get; set; }
        public List<ENG_T004_A> SelectedParameterDetails { get; set; }
        public List<ENG_T004_B> SelectedItemDetails { get; set; }
        public List<ZADM_M001_P> BallDiaList { get; set; }
        public List<ZADM_M003_P> WireDiaList { get; set; }
        public ObservableCollection<ENG_T004_C> ReferencesList { get; set; }
        public List<COM_T003_Files> AttachmentFiles { get; set; }
        public List<ADM_M028_P> CustomerList { get; set; } //Customer Master
        public List<ZADM_M007_P> Ref_ILD { get; set; } //ILD Master
        public ObservableCollection<ENG_T004_D> PartyList { get; set; }
        public List<ADM_M028_P> PartyMaster { get; set; } //Party Master

        //Reports
        public List<RptTools> RptToolsDetails { get; set; }
        public List<RptTDS> RptWire_Ball_details { get; set; }
        public List<RptDrills> RptDrillsDetails { get; set; }
        public List<RptSpares> RptSparesDetails { get; set; }
    }
    public class RptTDS
    {
        public int wire_dia_id { get; set; }
        public decimal wire_size { get; set; }
        public int wire_MakeCode { get; set; }
        public string WireMake { get; set; }
        public int ball_dia_id { get; set; }
        public decimal Ball_dia { get; set; }
        public int ball_MakeCode { get; set; }
        public string BallMake { get; set; }

    }
    public class RptTools
    {
        public string stn_no { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int MakeCode { get; set; }
        public string Make { get; set; }
        public string section_type { get; set; }
        public Nullable<decimal> quantity { get; set; }
        public string life_days { get; set; }
        public string life_qty { get; set; }
        public string remark { get; set; }
    }
    public class RptDrills
    {
        public string stn_no { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int MakeCode { get; set; }
        public string Make { get; set; }
        public string section_type { get; set; }
        public Nullable<decimal> degree { get; set; }
        public string drill_spec { get; set; }
        public Nullable<decimal> drill_section { get; set; }
        public Nullable<decimal> quantity { get; set; }
        public string life_days { get; set; }
        public string life_qty { get; set; }
        public string remark { get; set; }
    }
    public class RptSpares
    {
        public string stn_no { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int MakeCode { get; set; }
        public string Make { get; set; }
        public string section_type { get; set; }
        public Nullable<decimal> quantity { get; set; }
        public string life_days { get; set; }
        public string life_qty { get; set; }
        public string remark { get; set; }
    }
}
