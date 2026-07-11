using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Admin
{
    public class ADM_M041 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        public int _id;
        public int id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged("id");
            }
        }

        private string _lic_cod;
        public string lic_cod
        {
            get { return _lic_cod; }
            set
            {
                _lic_cod = value;
                RaisePropertyChanged("lic_cod");
            }
        }

        private string _lic_type;
        public string lic_type
        {
            get { return _lic_type; }
            set
            {
                _lic_type = value;
                RaisePropertyChanged("lic_type");
            }
        }

        private string _lic_desc;
        public string lic_desc
        {
            get { return _lic_desc; }
            set
            {
                _lic_desc = value;
                RaisePropertyChanged("lic_desc");
            }
        }

        private DateTime? _issue_date;
        public DateTime? issue_date
        {
            get { return _issue_date; }
            set
            {
                _issue_date = value;
                RaisePropertyChanged("issue_date");
            }
        }

        private DateTime? _export_expiry_date;
        public DateTime? export_expiry_date
        {
            get { return _export_expiry_date; }
            set
            {
                _export_expiry_date = value;
                RaisePropertyChanged("export_expiry_date");
            }
        }

        private DateTime? _export_expiry_date1;
        public DateTime? export_expiry_date1
        {
            get { return _export_expiry_date1; }
            set
            {
                _export_expiry_date1 = value;
                RaisePropertyChanged("export_expiry_date1");
            }
        }

        private DateTime? _import_expiry_date;
        public DateTime? import_expiry_date
        {
            get { return _import_expiry_date; }
            set
            {
                _import_expiry_date = value;
                RaisePropertyChanged("import_expiry_date");
            }
        }

        private DateTime? _import_expiry_date1;
        public DateTime? import_expiry_date1
        {
            get { return _import_expiry_date1; }
            set
            {
                _import_expiry_date1 = value;
                RaisePropertyChanged("import_expiry_date1");
            }
        }

        private string _sion_no;
        public string sion_no
        {
            get { return _sion_no; }
            set
            {
                _sion_no = value;
                RaisePropertyChanged("sion_no");
            }
        }

        private string _registration_port;
        public string registration_port
        {
            get { return _registration_port; }
            set
            {
                _registration_port = value;
                RaisePropertyChanged("registration_port");
            }
        }

        private string _file_no;
        public string file_no
        {
            get { return _file_no; }
            set
            {
                _file_no = value;
                RaisePropertyChanged("file_no");
            }
        }

        private string _bgb_no;
        public string bgb_no
        {
            get { return _bgb_no; }
            set
            {
                _bgb_no = value;
                RaisePropertyChanged("bgb_no");
            }
        }

        private decimal? _bgb_amt;
        public decimal? bgb_amt
        {
            get { return _bgb_amt; }
            set
            {
                _bgb_amt = value;
                RaisePropertyChanged("bgb_amt");
            }
        }

        private DateTime? _bgb_from_date;
        public DateTime? bgb_from_date
        {
            get { return _bgb_from_date; }
            set
            {
                _bgb_from_date = value;
                RaisePropertyChanged("bgb_from_date");
            }
        }

        private DateTime? _bgb_to_date;
        public DateTime? bgb_to_date
        {
            get { return _bgb_to_date; }
            set
            {
                _bgb_to_date = value;
                RaisePropertyChanged("bgb_to_date");
            }
        }

        private DateTime? _bgb_to_date1;
        public DateTime? bgb_to_date1
        {
            get { return _bgb_to_date1; }
            set
            {
                _bgb_to_date1 = value;
                RaisePropertyChanged("bgb_to_date1");
            }
        }

        private DateTime? _bgb_to_date2;
        public DateTime? bgb_to_date2
        {
            get { return _bgb_to_date2; }
            set
            {
                _bgb_to_date2 = value;
                RaisePropertyChanged("bgb_to_date2");
            }
        }

        private string _lic_reg_no_imp;
        public string lic_reg_no_imp
        {
            get { return _lic_reg_no_imp; }
            set
            {
                _lic_reg_no_imp = value;
                RaisePropertyChanged("lic_reg_no_imp");
            }
        }

        private string _lic_reg_no_exp;
        public string lic_reg_no_exp
        {
            get { return _lic_reg_no_exp; }
            set
            {
                _lic_reg_no_exp = value;
                RaisePropertyChanged("lic_reg_no_exp");
            }
        }

        private string _file_imp;
        public string file_imp
        {
            get { return _file_imp; }
            set
            {
                _file_imp = value;
                RaisePropertyChanged("file_imp");
            }
        }

        private string _file_exp;
        public string file_exp
        {
            get { return _file_exp; }
            set
            {
                _file_exp = value;
                RaisePropertyChanged("file_exp");
            }
        }

        private string _lic_short_text;
        public string lic_short_text
        {
            get { return _lic_short_text; }
            set
            {
                _lic_short_text = value;
                RaisePropertyChanged("lic_short_text");
            }
        }

        private string _scop;
        public string scop
        {
            get { return _scop; }
            set
            {
                _scop = value;
                RaisePropertyChanged("scop");
            }
        }

        private string _release_status;
        public string release_status
        {
            get { return _release_status; }
            set
            {
                _release_status = value;
                RaisePropertyChanged("release_status");
            }
        }

        private string _release_mode;
        public string release_mode
        {
            get { return _release_mode; }
            set
            {
                _release_mode = value;
                RaisePropertyChanged("release_mode");
            }
        }

        private decimal? _release_amt;
        public decimal? release_amt
        {
            get { return _release_amt; }
            set
            {
                _release_amt = value;
                RaisePropertyChanged("release_amt");
            }
        }

        private int? _days;
        public int? days
        {
            get { return _days; }
            set
            {
                _days = value;
                RaisePropertyChanged("days");
            }
        }

        private DateTime? _release_date;
        public DateTime? release_date
        {
            get { return _release_date; }
            set
            {
                _release_date = value;
                RaisePropertyChanged("release_date");
            }
        }

        private string _lic_cat_code;
        public string lic_cat_code
        {
            get { return _lic_cat_code; }
            set
            {
                _lic_cat_code = value;
                RaisePropertyChanged("lic_cat_code");
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

        private bool? _active;
        public bool? active
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

        private DateTime _add_date;
        public DateTime add_date
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
                _edit_by = value;
                RaisePropertyChanged("edit_by");
            }
        }

        private DateTime? _edit_date;
        public DateTime? edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value;
                RaisePropertyChanged("edit_date");
            }
        }

        private string _para1;
        public string para1
        {
            get { return _para1; }
            set
            {
                _para1 = value;
                RaisePropertyChanged("para1");
            }
        }

        private string _para2;
        public string para2
        {
            get { return _para2; }
            set
            {
                _para2 = value;
                RaisePropertyChanged("para2");
            }
        }

        private string _para3;
        public string para3
        {
            get { return _para3; }
            set
            {
                _para3 = value;
                RaisePropertyChanged("para3");
            }
        }

        private string _para4;
        public string para4
        {
            get { return _para4; }
            set
            {
                _para4 = value;
                RaisePropertyChanged("para4");
            }
        }

        private string _para5;
        public string para5
        {
            get { return _para5; }
            set
            {
                _para5 = value;
                RaisePropertyChanged("para5");
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

        private string _bgb_register_at;
        public string bgb_register_at
        {
            get { return _bgb_register_at; }
            set
            {
                _bgb_register_at = value;
                RaisePropertyChanged("bgb_register_at");
            }
        }

        private string _bgb_details;
        public string bgb_details
        {
            get { return _bgb_details; }
            set
            {
                _bgb_details = value;
                RaisePropertyChanged("bgb_details");
            }
        }

        private Nullable<bool> _ButtonAIsChecked;
        public Nullable<bool> ButtonAIsChecked
        {
            get { return _ButtonAIsChecked; }
            set
            {
                _ButtonAIsChecked = value;
                RaisePropertyChanged("ButtonAIsChecked");
            }
        }
        private Nullable<bool> _ButtonBIsChecked;
        public Nullable<bool> ButtonBIsChecked
        {
            get { return _ButtonBIsChecked; }
            set
            {
                _ButtonBIsChecked = value;
                RaisePropertyChanged("ButtonBIsChecked");
            }
        }
        
        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set { _lang_key = value; RaisePropertyChanged("lang_key"); }
        }
        public string XmlDataDocument_FlipGrid { get; set; }
        public string XmlDataDocument_ADM_M041_C { get; set; }
        private string _CompName;
        public string CompName
        {
            get { return _CompName; }
            set
            {
                _CompName = value;
                RaisePropertyChanged("CompName");
            }
        }
    }
    public class ADM_M041_A : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int _id { get; set; }
        public int id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged("id");
            }
        }
        private string _licn_type { get; set; }
        public string licn_type
        {
            get { return _licn_type; }
            set
            {
                _licn_type = value;
                RaisePropertyChanged("licn_type");
            }
        }
        private string _licn_desc { get; set; }
        public string licn_desc
        {
            get { return _licn_desc; }
            set
            {
                _licn_desc = value;
                RaisePropertyChanged("licn_desc");
            }
        }
        private bool? _active { get; set; }
        public bool? active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
            }
        }
      
        private string _add_by { get; set; }
        public string add_by
        {
            get { return _add_by; }
            set
            {
                _add_by = value;
                RaisePropertyChanged("add_by");
            }
        }
        private DateTime _add_date { get; set; }
        public DateTime add_date
        {
            get { return _add_date; }
            set
            {
                _add_date = value;
                RaisePropertyChanged("add_date");
            }
        }
        private string _edit_by { get; set; }
        public string edit_by
        {
            get { return _edit_by; }
            set
            {
                _edit_by = value;
                RaisePropertyChanged("edit_by");
            }
        }
        private DateTime? _edit_date { get; set; }
        public DateTime? edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value;
                RaisePropertyChanged("edit_date");
            }
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

    public class ADM_M041_C : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged("id");
            }
        }

        private string _lic_cod;
        public string lic_cod
        {
            get { return _lic_cod; }
            set
            {
                _lic_cod = value;
                RaisePropertyChanged("lic_cod");
            }
        }

        private string _ItemCode;
        public string ItemCode
        {
            get { return _ItemCode; }
            set
            {
                _ItemCode = value;
                RaisePropertyChanged("ItemCode");
            }
        }

        private string _description;
        public string description
        {
            get { return _description; }
            set
            {
                _description = value;
                RaisePropertyChanged("description");
            }
        }

        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set
            {
                _unit_code = value;
                RaisePropertyChanged("unit_code");
            }
        }

        private decimal? _qty;
        public decimal? qty
        {
            get { return _qty; }
            set
            {
                _qty = value;
                RaisePropertyChanged("qty");
            }
        }

        private decimal? _weight;
        public decimal? weight
        {
            get { return _weight; }
            set
            {
                _weight = value;
                RaisePropertyChanged("weight");
            }
        }

        private string _wt_unit;
        public string wt_unit
        {
            get { return _wt_unit; }
            set
            {
                _wt_unit = value;
                RaisePropertyChanged("wt_unit");
            }
        }

        private string _sion_type;
        public string sion_type
        {
            get { return _sion_type; }
            set
            {
                _sion_type = value;
                RaisePropertyChanged("sion_type");
            }
        }

        private string _incoterms;
        public string incoterms
        {
            get { return _incoterms; }
            set
            {
                _incoterms = value;
                RaisePropertyChanged("incoterms");
            }
        }

        private decimal? _incoterm_val;
        public decimal? incoterm_val
        {
            get { return _incoterm_val; }
            set
            {
                _incoterm_val = value;
                RaisePropertyChanged("incoterm_val");
            }
        }

        private string _currency;
        public string currency
        {
            get { return _currency; }
            set
            {
                _currency = value;
                RaisePropertyChanged("currency");
            }
        }

        private string _item_group_code;
        public string item_group_code
        {
            get { return _item_group_code; }
            set
            {
                _item_group_code = value;
                RaisePropertyChanged("item_group_code");
            }
        }

        private string _sion_no;
        public string sion_no
        {
            get { return _sion_no; }
            set
            {
                _sion_no = value;
                RaisePropertyChanged("sion_no");
            }
        }

        private string _sion_desc;
        public string sion_desc
        {
            get { return _sion_desc; }
            set
            {
                _sion_desc = value;
                RaisePropertyChanged("sion_desc");
            }
        }

        private string _prod_desc;
        public string prod_desc
        {
            get { return _prod_desc; }
            set
            {
                _prod_desc = value;
                RaisePropertyChanged("prod_desc");
            }
        }

        private decimal? _qty_limit_max;
        public decimal? qty_limit_max
        {
            get { return _qty_limit_max; }
            set
            {
                _qty_limit_max = value;
                RaisePropertyChanged("qty_limit_max");
            }
        }

        private decimal? _qty_limit_min;
        public decimal? qty_limit_min
        {
            get { return _qty_limit_min; }
            set
            {
                _qty_limit_min = value;
                RaisePropertyChanged("qty_limit_min");
            }
        }

        private decimal? _wt_limit_min;
        public decimal? wt_limit_min
        {
            get { return _wt_limit_min; }
            set
            {
                _wt_limit_min = value;
                RaisePropertyChanged("wt_limit_min");
            }
        }

        private decimal? _wt_limit_max;
        public decimal? wt_limit_max
        {
            get { return _wt_limit_max; }
            set
            {
                _wt_limit_max = value;
                RaisePropertyChanged("wt_limit_max");
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

        private bool? _active;
        public bool? active
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

        private DateTime _add_date;
        public DateTime add_date
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
                _edit_by = value;
                RaisePropertyChanged("edit_by");
            }
        }

        private DateTime? _edit_date;
        public DateTime? edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value;
                RaisePropertyChanged("edit_date");
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

        private decimal? _incoterm_val_local;
        public decimal? incoterm_val_local
        {
            get { return _incoterm_val_local; }
            set
            {
                _incoterm_val_local = value;
                RaisePropertyChanged("incoterm_val_local");
            }
        }

        private string _local_currency;
        public string local_currency
        {
            get { return _local_currency; }
            set
            {
                _local_currency = value;
                RaisePropertyChanged("local_currency");
            }
        }

        private DateTime? _obgl_from;
        public DateTime? obgl_from
        {
            get { return _obgl_from; }
            set
            {
                _obgl_from = value;
                RaisePropertyChanged("obgl_from");
            }
        }

        private DateTime? _obgl_to;
        public DateTime? obgl_to
        {
            get { return _obgl_to; }
            set
            {
                _obgl_to = value;
                RaisePropertyChanged("obgl_to");
            }
        }
    }

    public class MultipleContext_ADM_M041
    {
        public List<ADM_M041Flip> FlipGridData { get; set; }
        public List<ADM_M041> MasterEntity { get; set; }
        public ObservableCollection<ADM_M041_C> ItemsEntity { get; set; }
        public List<ADM_M041_A> LicenseType { get; set; }
        public List<ADM_M041_B_P> SionNo { get; set; }
        public List<ADM_M041_D_P> LicenseCatMaster { get; set; }
        public List<ADM_M022_B_P> ItemGroupMaster { get; set; }
        public List<ADM_M044_P> Incoterms { get; set; }
        public List<ADM_M037_P> Currency { get; set; }
        public List<ADM_M038_B_P> UnitMaster { get; set; }
        //public List<ADM_M002> Company { get; set; }
    }

}
