using System;

namespace Reflection.BusinessEntity
{
    public class SYS_AUTH : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int? _id;
        public int? id
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
        private bool? _selected;
        public bool? selected
        {
            get { return _selected; }
            set
            {
                if (_selected != value)
                {
                    _selected = value; RaisePropertyChanged("selected");
                }
            }
        }
        private int? _row_no;
        public int? row_no
        {
            get { return _row_no; }
            set
            {
                if (_row_no != value)
                {
                    _row_no = value; RaisePropertyChanged("row_no");
                }
            }
        }
        private int? _seq_no;
        public int? seq_no
        {
            get { return _seq_no; }
            set
            {
                if (_seq_no != value)
                {
                    _seq_no = value; RaisePropertyChanged("seq_no");
                }
            }
        }
        private string _role_code;
        public string role_code
        {
            get { return _role_code; }
            set
            {
                if (_role_code != value)
                {
                    _role_code = value; RaisePropertyChanged("role_code");
                }
            }
        }
        private string _role_name;
        public string role_name
        {
            get { return _role_name; }
            set
            {
                if (_role_name != value)
                {
                    _role_name = value; RaisePropertyChanged("role_name");
                }
            }
        }
        private string _role_alias;
        public string role_alias
        {
            get { return _role_alias; }
            set
            {
                if (_role_alias != value)
                {
                    _role_alias = value; RaisePropertyChanged("role_alias");
                }
            }
        }
        private string _active;
        public string active
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
        private string _t_display;
        public string t_display
        {
            get { return _t_display; }
            set
            {
                if (_t_display != value)
                {
                    _t_display = value; RaisePropertyChanged("t_display");
                }
            }
        }
        private string _auth_code;
        public string auth_code
        {
            get { return _auth_code; }
            set
            {
                if (_auth_code != value)
                {
                    _auth_code = value; RaisePropertyChanged("auth_code");
                }
            }
        }
        private string _auth_name;
        public string auth_name
        {
            get { return _auth_name; }
            set
            {
                if (_auth_name != value)
                {
                    _auth_name = value; RaisePropertyChanged("auth_name");
                }
            }
        }
        private DateTime? _from_date;
        public DateTime? from_date
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
        private DateTime? _to_date;
        public DateTime? to_date
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
        private string _ts_alias;
        public string ts_alias
        {
            get { return _ts_alias; }
            set
            {
                if (_ts_alias != value)
                {
                    _ts_alias = value; RaisePropertyChanged("ts_alias");
                }
            }
        }
        private string _ts_parent;
        public string ts_parent
        {
            get { return _ts_parent; }
            set
            {
                if (_ts_parent != value)
                {
                    _ts_parent = value; RaisePropertyChanged("ts_parent");
                }
            }
        }
        private string _module_code;
        public string module_code
        {
            get { return _module_code; }
            set
            {
                if (_module_code != value)
                {
                    _module_code = value; RaisePropertyChanged("module_code");
                }
            }
        }
        private string _ind_parent;
        public string ind_parent
        {
            get { return _ind_parent; }
            set
            {
                if (_ind_parent != value)
                {
                    _ind_parent = value; RaisePropertyChanged("ind_parent");
                }
            }
        }
        private string _ind_navigation;
        public string ind_navigation
        {
            get { return _ind_navigation; }
            set
            {
                if (_ind_navigation != value)
                {
                    _ind_navigation = value; RaisePropertyChanged("ind_navigation");
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
        private string _location_id;
        public string location_id
        {
            get { return _location_id; }
            set
            {
                if (_location_id != value)
                {
                    _location_id = value; RaisePropertyChanged("location_id");
                }
            }
        }
        private string _ts_namespace;
        public string ts_namespace
        {
            get { return _ts_namespace; }
            set
            {
                if (_ts_namespace != value)
                {
                    _ts_namespace = value; RaisePropertyChanged("ts_namespace");
                }
            }
        }
        private string _ts_nspath;
        public string ts_nspath
        {
            get { return _ts_nspath; }
            set
            {
                if (_ts_nspath != value)
                {
                    _ts_nspath = value; RaisePropertyChanged("ts_nspath");
                }
            }
        }
        private string _class_file;
        public string class_file
        {
            get { return _class_file; }
            set
            {
                if (_class_file != value)
                {
                    _class_file = value; RaisePropertyChanged("class_file");
                }
            }
        }
        private string _obj_code;
        public string obj_code
        {
            get { return _obj_code; }
            set
            {
                if (_obj_code != value)
                {
                    _obj_code = value; RaisePropertyChanged("obj_code");
                }
            }
        }
        private string _obj_name;
        public string obj_name
        {
            get { return _obj_name; }
            set
            {
                if (_obj_name != value)
                {
                    _obj_name = value; RaisePropertyChanged("obj_name");
                }
            }
        }
        private string _obj_class;
        public string obj_class
        {
            get { return _obj_class; }
            set
            {
                if (_obj_class != value)
                {
                    _obj_class = value; RaisePropertyChanged("obj_class");
                }
            }
        }
        private string _obj_cat;
        public string obj_cat
        {
            get { return _obj_cat; }
            set
            {
                if (_obj_cat != value)
                {
                    _obj_cat = value; RaisePropertyChanged("obj_cat");
                }
            }
        }
        private string _ts_cat;
        public string ts_cat
        {
            get { return _ts_cat; }
            set
            {
                if (_ts_cat != value)
                {
                    _ts_cat = value; RaisePropertyChanged("ts_cat");
                }
            }
        }
        private string _ts_type;
        public string ts_type
        {
            get { return _ts_type; }
            set
            {
                if (_ts_type != value)
                {
                    _ts_type = value; RaisePropertyChanged("ts_type");
                }
            }
        }
        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set
            {
                if (_doc_cat != value)
                {
                    _doc_cat = value; RaisePropertyChanged("doc_cat");
                }
            }
        }
        private string _menu_code;
        public string menu_code
        {
            get { return _menu_code; }
            set
            {
                if (_menu_code != value)
                {
                    _menu_code = value; RaisePropertyChanged("menu_code");
                }
            }
        }
        private string _menu_name;
        public string menu_name
        {
            get { return _menu_name; }
            set
            {
                if (_menu_name != value)
                {
                    _menu_name = value; RaisePropertyChanged("menu_name");
                }
            }
        }
        private string _menu_parent;
        public string menu_parent
        {
            get { return _menu_parent; }
            set
            {
                if (_menu_parent != value)
                {
                    _menu_parent = value; RaisePropertyChanged("menu_parent");
                }
            }
        }
        private string _user_type;
        public string user_type
        {
            get { return _user_type; }
            set
            {
                if (_user_type != value)
                {
                    _user_type = value; RaisePropertyChanged("user_type");
                }
            }
        }
        private string _user_type_name;
        public string user_type_name
        {
            get { return _user_type_name; }
            set
            {
                if (_user_type_name != value)
                {
                    _user_type_name = value; RaisePropertyChanged("user_type_name");
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
                    _title = value; RaisePropertyChanged("title",ModelEntityUpdated);
                }
            }
        }
        private string _emp_id;
        public string emp_id
        {
            get { return _emp_id; }
            set
            {
                if (_emp_id != value)
                {
                    _emp_id = value; RaisePropertyChanged("emp_id", ModelEntityUpdated);
                }
            }
        }
        private string _emp_name;
        public string emp_name
        {
            get { return _emp_name; }
            set
            {
                if (_emp_name != value)
                {
                    _emp_name = value; RaisePropertyChanged("emp_name");
                }
            }
        }
        private string _ind_login;
        public string ind_login
        {
            get { return _ind_login; }
            set
            {
                if (_ind_login != value)
                {
                    _ind_login = value; RaisePropertyChanged("ind_login");
                }
            }
        }
        private string _ind_lock;
        public string ind_lock
        {
            get { return _ind_lock; }
            set
            {
                if (_ind_lock != value)
                {
                    _ind_lock = value; RaisePropertyChanged("ind_lock");
                }
            }
        }
        private string _ind_block;
        public string ind_block
        {
            get { return _ind_block; }
            set
            {
                if (_ind_block != value)
                {
                    _ind_block = value; RaisePropertyChanged("ind_block");
                }
            }
        }
        private string _admin_user;
        public string admin_user
        {
            get { return _admin_user; }
            set
            {
                if (_admin_user != value)
                {
                    _admin_user = value; RaisePropertyChanged("admin_user");
                }
            }
        }
        private DateTime? _block_date;
        public DateTime? block_date
        {
            get { return _block_date; }
            set
            {
                if (_block_date != value)
                {
                    _block_date = value; RaisePropertyChanged("block_date");
                }
            }
        }
        private byte[] _user_image;
        public byte[] user_image
        {
            get { return _user_image; }
            set
            {
                if (_user_image != value)
                {
                    _user_image = value; RaisePropertyChanged("user_image");
                }
            }
        }
        private string _short_text;
        public string short_text
        {
            get { return _short_text; }
            set
            {
                if (_short_text != value)
                {
                    _short_text = value; RaisePropertyChanged("short_text");
                }
            }
        }

        public string XML_DOC_A { get; set; }
        public string XML_DOC_B { get; set; }
        public string XML_DOC_C { get; set; }
        public string XML_DOC_D { get; set; }
        public string XML_DOC_E { get; set; }
    }

    public class SYS_C0101 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
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
        private string _loc_code;
        public string loc_code
        {
            get { return _loc_code; }
            set
            {
                if (_loc_code != value)
                {
                    _loc_code = value; RaisePropertyChanged("loc_code");
                }
            }
        }
        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set
            {
                if (_doc_cat != value)
                {
                    _doc_cat = value; RaisePropertyChanged("doc_cat", ModelEntityUpdated);
                }
            }
        }
        private string _rpt_code;
        public string rpt_code
        {
            get { return _rpt_code; }
            set
            {
                if (_rpt_code != value)
                {
                    _rpt_code = value; RaisePropertyChanged("rpt_code");
                }
            }
        }

        private string _orientation;
        public string orientation
        {
            get { return _orientation; }
            set
            {
                if (_orientation != value)
                {
                    _orientation = value; RaisePropertyChanged("orientation");
                }
            }
        }
        private double? _pm_left;
        public double? pm_left
        {
            get { return _pm_left; }
            set
            {
                if (_pm_left != value)
                {
                    _pm_left = value; RaisePropertyChanged("pm_left");
                }
            }
        }
        private double? _pm_top;
        public double? pm_top
        {
            get { return _pm_top; }
            set
            {
                if (_pm_top != value)
                {
                    _pm_top = value; RaisePropertyChanged("pm_top");
                }
            }
        }
        private double? _pm_right;
        public double? pm_right
        {
            get { return _pm_right; }
            set
            {
                if (_pm_right != value)
                {
                    _pm_right = value; RaisePropertyChanged("pm_right");
                }
            }
        }
        private double? _pm_bottom;
        public double? pm_bottom
        {
            get { return _pm_bottom; }
            set
            {
                if (_pm_bottom != value)
                {
                    _pm_bottom = value; RaisePropertyChanged("pm_bottom");
                }
            }
        }
        private double? _header_height;
        public double? header_height
        {
            get { return _header_height; }
            set
            {
                if (_header_height != value)
                {
                    _header_height = value; RaisePropertyChanged("header_height");
                }
            }
        }
        private bool _header_vis;
        public bool header_vis
        {
            get { return _header_vis; }
            set
            {
                if (_header_vis != value)
                {
                    _header_vis = value; RaisePropertyChanged("header_vis");
                }
            }
        }
        private string _hi_display;
        public string hi_display
        {
            get { return _hi_display; }
            set
            {
                if (_hi_display != value)
                {
                    _hi_display = value; RaisePropertyChanged("hi_display");
                }
            }
        }
        private string _header_img;
        public string header_img
        {
            get { return _header_img; }
            set
            {
                if (_header_img != value)
                {
                    _header_img = value; RaisePropertyChanged("header_img");
                }
            }
        }
        private string _header_img2;
        public string header_img2
        {
            get { return _header_img2; }
            set
            {
                if (_header_img2 != value)
                {
                    _header_img2 = value; RaisePropertyChanged("header_img");
                }
            }
        }
        private double? _footer_height;
        public double? footer_height
        {
            get { return _footer_height; }
            set
            {
                if (_footer_height != value)
                {
                    _footer_height = value; RaisePropertyChanged("footer_height");
                }
            }
        }
        private bool _footer_vis;
        public bool footer_vis
        {
            get { return _footer_vis; }
            set
            {
                if (_footer_vis != value)
                {
                    _footer_vis = value; RaisePropertyChanged("footer_vis");
                }
            }
        }
        private string _fi_display;
        public string fi_display
        {
            get { return _fi_display; }
            set
            {
                if (_fi_display != value)
                {
                    _fi_display = value; RaisePropertyChanged("fi_display");
                }
            }
        }
        private string _footer_img;
        public string footer_img
        {
            get { return _footer_img; }
            set
            {
                if (_footer_img != value)
                {
                    _footer_img = value; RaisePropertyChanged("footer_img");
                }
            }
        }
        private double? _sign_height;
        public double? sign_height
        {
            get { return _sign_height; }
            set
            {
                if (_sign_height != value)
                {
                    _sign_height = value; RaisePropertyChanged("sign_height");
                }
            }
        }
        private double? _sign_width;
        public double? sign_width
        {
            get { return _sign_width; }
            set
            {
                if (_sign_width != value)
                {
                    _sign_width = value; RaisePropertyChanged("sign_width");
                }
            }
        }
        private string _sign_align;
        public string sign_align
        {
            get { return _sign_align; }
            set
            {
                if (_sign_align != value)
                {
                    _sign_align = value; RaisePropertyChanged("sign_align");
                }
            }
        }
        private string _sign_display;
        public string sign_display
        {
            get { return _sign_display; }
            set
            {
                if (_sign_display != value)
                {
                    _sign_display = value; RaisePropertyChanged("sign_display");
                }
            }
        }
        private string _sign_vis;
        public string sign_vis
        {
            get { return _sign_vis; }
            set
            {
                if (_sign_vis != value)
                {
                    _sign_vis = value; RaisePropertyChanged("sign_vis");
                }
            }
        }
        private string _party_align;
        public string party_align
        {
            get { return _party_align; }
            set
            {
                if (_party_align != value)
                {
                    _party_align = value; RaisePropertyChanged("party_align");
                }
            }
        }

        private string _comp_align;
        public string comp_align
        {
            get { return _comp_align; }
            set
            {
                if (_comp_align != value)
                {
                    _comp_align = value; RaisePropertyChanged("comp_align");
                }
            }
        }
        private bool _qr_vis;
        public bool qr_vis
        {
            get { return _qr_vis; }
            set
            {
                if (_qr_vis != value)
                {
                    _qr_vis = value; RaisePropertyChanged("qr_vis");
                }
            }
        }
        private string _bar_vis;
        public string bar_vis
        {
            get { return _bar_vis; }
            set
            {
                if (_bar_vis != value)
                {
                    _bar_vis = value; RaisePropertyChanged("bar_vis");
                }
            }
        }

        private string _ind_default;
        public string ind_default
        {
            get { return _ind_default; }
            set
            {
                if (_ind_default != value)
                {
                    _ind_default = value; RaisePropertyChanged("ind_default");
                }
            }
        }
        private string _active;
        public string active
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

        public string report_code { get; set; }
        public string left_margin { get; set; }
        public string top_margin { get; set; }
        public string right_margin { get; set; }
        public string bottom_margin { get; set; }
        public string header_img_display_view { get; set; }
        public string footer_img_display_view { get; set; }
        public string comp_hori_align_left { get; set; }
        public string comp_hori_align_right { get; set; }
        public string cust_hori_align_left { get; set; }
        public string cust_hori_align_right { get; set; }
        public string digi_sign_width { get; set; }
        public string digi_sign_height { get; set; }
        public bool first_doc_sign_vis { get; set; }
        public bool second_doc_sign_vis { get; set; }
        public bool bottom_logo_vis { get; set; }
        public bool bottom_logo2_vis { get; set; }
        public bool bottom_logo3_vis { get; set; }
        public string bottom_logo_img { get; set; }
        public string bottom_logo2_img { get; set; }
        public string bottom_logo3_img { get; set; }
        public bool barcode_vis { get; set; }
        public string first_doc_sign_img { get; set; }
        public string second_doc_sign_img { get; set; }
        public string first_doctor_name { get; set; }
        public string second_doctor_name { get; set; }
        public string first_doctor_desig { get; set; }
        public string second_doctor_desig { get; set; }
        public string first_doctor_reg { get; set; }
        public string second_doctor_reg { get; set; }
        public string check_by { get; set; }
        public string nabl_logo_img { get; set; }
        public string header_left_margin { get; set; }
        public string header_top_margin { get; set; }
        public string header_right_margin { get; set; }
        public string header_bottom_margin { get; set; }
        public string footer_left_margin { get; set; }
        public string footer_top_margin { get; set; }
        public string footer_right_margin { get; set; }
        public string footer_bottom_margin { get; set; }
    }

    public class Test_Header
    {
        public string patient_name { get; set; }
        public string patient_age { get; set; }
        public string patient_gender { get; set; }
        public string consulting_party { get; set; }
        public string sold_to_party { get; set; }
        public string lab_case_no { get; set; }
        public string grn_date { get; set; }
        public string report_date { get; set; }
        public string qr_img { get; set; }
        public string barcode_img { get; set; }
        public string clinical_note { get; set; }
        public string signature_img_display_size { get; set; }
        public string refered_by_doctor { get; set; }
        public string partner_in { get; set; }
        public string partner_out { get; set; }
        public string shift_to_party { get; set; }
        public string bill_to_party { get; set; }
        public string payer { get; set; }
        public string order_date { get; set; }
        public string lab_code { get; set; }
        public string collection_center { get; set; }
    }
}
