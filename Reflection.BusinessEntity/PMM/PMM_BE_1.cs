using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessEntity.PMM
{
    public class PMM_M0001 : ObjectBase
    {
        private string _comp_code { get; set; }
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
        private string _location_id { get; set; }
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
        private string _equip_no { get; set; }
        public string equip_no
        {
            get { return _equip_no; }
            set
            {
                if (_equip_no != value)
                {
                    _equip_no = value; RaisePropertyChanged("equip_no");
                }
            }
        }
        private string _equip_name { get; set; }
        public string equip_name
        {
            get { return _equip_name; }
            set
            {
                if (_equip_name != value)
                {
                    _equip_name = value; RaisePropertyChanged("equip_name");
                }
            }
        }
        private string _short_text { get; set; }
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
        private string _store_code { get; set; }
        public string store_code
        {
            get { return _store_code; }
            set
            {
                if (_store_code != value)
                {
                    _store_code = value; RaisePropertyChanged("store_code");
                }
            }
        }
        private string _batch_no { get; set; }
        public string batch_no
        {
            get { return _batch_no; }
            set
            {
                if (_batch_no != value)
                {
                    _batch_no = value; RaisePropertyChanged("batch_no");
                }
            }
        }
        private DateTime? _create_date { get; set; }
        public DateTime? create_date
        {
            get { return _create_date; }
            set
            {
                if (_create_date != value)
                {
                    _create_date = value; RaisePropertyChanged("create_date");
                }
            }
        }
        private string _lang_key { get; set; }
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
        private string _equip_cat { get; set; }
        public string equip_cat
        {
            get { return _equip_cat; }
            set
            {
                if (_equip_cat != value)
                {
                    _equip_cat = value; RaisePropertyChanged("equip_cat");
                }
            }
        }
        private string _obj_type { get; set; }
        public string obj_type
        {
            get { return _obj_type; }
            set
            {
                if (_obj_type != value)
                {
                    _obj_type = value; RaisePropertyChanged("obj_type");
                }
            }
        }
        private string _obj_no { get; set; }
        public string obj_no
        {
            get { return _obj_no; }
            set
            {
                if (_obj_no != value)
                {
                    _obj_no = value; RaisePropertyChanged("obj_no");
                }
            }
        }
        private string _dimension { get; set; }
        public string dimension
        {
            get { return _dimension; }
            set
            {
                if (_dimension != value)
                {
                    _dimension = value; RaisePropertyChanged("dimension");
                }
            }
        }
        private decimal? _obj_weight { get; set; }
        public decimal? obj_weight
        {
            get { return _obj_weight; }
            set
            {
                if (_obj_weight != value)
                {
                    _obj_weight = value; RaisePropertyChanged("obj_weight");
                }
            }
        }
        private string _uom_weight { get; set; }
        public string uom_weight
        {
            get { return _uom_weight; }
            set
            {
                if (_uom_weight != value)
                {
                    _uom_weight = value; RaisePropertyChanged("uom_weight");
                }
            }
        }
        private DateTime? _aquisition_date { get; set; }
        public DateTime? aquisition_date
        {
            get { return _aquisition_date; }
            set
            {
                if (_aquisition_date != value)
                {
                    _aquisition_date = value; RaisePropertyChanged("aquisition_date");
                }
            }
        }
        private decimal? _aquisition_value { get; set; }
        public decimal? aquisition_value
        {
            get { return _aquisition_value; }
            set
            {
                if (_aquisition_value != value)
                {
                    _aquisition_value = value; RaisePropertyChanged("aquisition_value");
                }
            }
        }
        private string _curr_code { get; set; }
        public string curr_code
        {
            get { return _curr_code; }
            set
            {
                if (_curr_code != value)
                {
                    _curr_code = value; RaisePropertyChanged("curr_code");
                }
            }
        }
        private string _vendor_code { get; set; }
        public string vendor_code
        {
            get { return _vendor_code; }
            set
            {
                if (_vendor_code != value)
                {
                    _vendor_code = value; RaisePropertyChanged("vendor_code");
                }
            }
        }
        private string _customer_code { get; set; }
        public string customer_code
        {
            get { return _customer_code; }
            set
            {
                if (_customer_code != value)
                {
                    _customer_code = value; RaisePropertyChanged("customer_code");
                }
            }
        }
        private DateTime? _warranty_date_sd { get; set; }
        public DateTime? warranty_date_sd
        {
            get { return _warranty_date_sd; }
            set
            {
                if (_warranty_date_sd != value)
                {
                    _warranty_date_sd = value; RaisePropertyChanged("warranty_date_sd");
                }
            }
        }
        private string _warranty_code { get; set; }
        public string warranty_code
        {
            get { return _warranty_code; }
            set
            {
                if (_warranty_code != value)
                {
                    _warranty_code = value; RaisePropertyChanged("warranty_code");
                }
            }
        }
        private DateTime? _warranty_start { get; set; }
        public DateTime? warranty_start
        {
            get { return _warranty_start; }
            set
            {
                if (_warranty_start != value)
                {
                    _warranty_start = value; RaisePropertyChanged("warranty_start");
                }
            }
        }
        private DateTime? _warranty_end { get; set; }
        public DateTime? warranty_end
        {
            get { return _warranty_end; }
            set
            {
                if (_warranty_end != value)
                {
                    _warranty_end = value; RaisePropertyChanged("warranty_end");
                }
            }
        }
        private string _manufacturer { get; set; }
        public string manufacturer
        {
            get { return _manufacturer; }
            set
            {
                if (_manufacturer != value)
                {
                    _manufacturer = value; RaisePropertyChanged("manufacturer");
                }
            }
        }
        private string _mfg_srno { get; set; }
        public string mfg_srno
        {
            get { return _mfg_srno; }
            set
            {
                if (_mfg_srno != value)
                {
                    _mfg_srno = value; RaisePropertyChanged("mfg_srno");
                }
            }
        }
        private string _mfg_model { get; set; }
        public string mfg_model
        {
            get { return _mfg_model; }
            set
            {
                if (_mfg_model != value)
                {
                    _mfg_model = value; RaisePropertyChanged("mfg_model");
                }
            }
        }
        private string _mfg_country { get; set; }
        public string mfg_country
        {
            get { return _mfg_country; }
            set
            {
                if (_mfg_country != value)
                {
                    _mfg_country = value; RaisePropertyChanged("mfg_country");
                }
            }
        }
        private string _mfg_drawing { get; set; }
        public string mfg_drawing
        {
            get { return _mfg_drawing; }
            set
            {
                if (_mfg_drawing != value)
                {
                    _mfg_drawing = value; RaisePropertyChanged("mfg_drawing");
                }
            }
        }
        private DateTime? _mfg_date { get; set; }
        public DateTime? mfg_date
        {
            get { return _mfg_date; }
            set
            {
                if (_mfg_date != value)
                {
                    _mfg_date = value; RaisePropertyChanged("mfg_date");
                }
            }
        }
        private string _mfg_year { get; set; }
        public string mfg_year
        {
            get { return _mfg_year; }
            set
            {
                if (_mfg_year != value)
                {
                    _mfg_year = value; RaisePropertyChanged("mfg_year");
                }
            }
        }
        private string _mfg_month { get; set; }
        public string mfg_month
        {
            get { return _mfg_month; }
            set
            {
                if (_mfg_month != value)
                {
                    _mfg_month = value; RaisePropertyChanged("mfg_month");
                }
            }
        }
        private string _serial_no { get; set; }
        public string serial_no
        {
            get { return _serial_no; }
            set
            {
                if (_serial_no != value)
                {
                    _serial_no = value; RaisePropertyChanged("serial_no");
                }
            }
        }
        private string _item_code_config { get; set; }
        public string item_code_config
        {
            get { return _item_code_config; }
            set
            {
                if (_item_code_config != value)
                {
                    _item_code_config = value; RaisePropertyChanged("item_code_config");
                }
            }
        }
        private string _item_code { get; set; }
        public string item_code
        {
            get { return _item_code; }
            set
            {
                if (_item_code != value)
                {
                    _item_code = value; RaisePropertyChanged("item_code");
                }
            }
        }
        private string _maint_plan { get; set; }
        public string maint_plan
        {
            get { return _maint_plan; }
            set
            {
                if (_maint_plan != value)
                {
                    _maint_plan = value; RaisePropertyChanged("maint_plan");
                }
            }
        }
        private string _unique_code { get; set; }
        public string unique_code
        {
            get { return _unique_code; }
            set
            {
                if (_unique_code != value)
                {
                    _unique_code = value; RaisePropertyChanged("unique_code");
                }
            }
        }
        private string _barcode { get; set; }
        public string barcode
        {
            get { return _barcode; }
            set
            {
                if (_barcode != value)
                {
                    _barcode = value; RaisePropertyChanged("barcode");
                }
            }
        }
        private string _party_code { get; set; }
        public string party_code
        {
            get { return _party_code; }
            set
            {
                if (_party_code != value)
                {
                    _party_code = value; RaisePropertyChanged("party_code");
                }
            }
        }
        private string _active { get; set; }
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
        private string _t_status { get; set; }
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
        private string _lab_code { get; set; }
        public string lab_code
        {
            get { return _lab_code; }
            set
            {
                if (_lab_code != value)
                {
                    _lab_code = value; RaisePropertyChanged("lab_code");
                }
            }
        }
        private DateTime? _valid_from { get; set; }
        public DateTime? valid_from
        {
            get { return _valid_from; }
            set
            {
                if (_valid_from != value)
                {
                    _valid_from = value; RaisePropertyChanged("valid_from");
                }
            }
        }
        private DateTime? _valid_to { get; set; }
        public DateTime? valid_to
        {
            get { return _valid_to; }
            set
            {
                if (_valid_to != value)
                {
                    _valid_to = value; RaisePropertyChanged("valid_to");
                }
            }
        }
        private double? _range_h { get; set; }
        public double? range_h
        {
            get { return _range_h; }
            set
            {
                if (_range_h != value)
                {
                    _range_h = value; RaisePropertyChanged("range_h");
                }
            }
        }
        private string _range_h_uom { get; set; }
        public string range_h_uom
        {
            get { return _range_h_uom; }
            set
            {
                if (_range_h_uom != value)
                {
                    _range_h_uom = value; RaisePropertyChanged("range_h_uom");
                }
            }
        }
        private double? _range_l { get; set; }
        public double? range_l
        {
            get { return _range_l; }
            set
            {
                if (_range_l != value)
                {
                    _range_l = value; RaisePropertyChanged("range_l");
                }
            }
        }
        private string _range_l_uom { get; set; }
        public string range_l_uom
        {
            get { return _range_l_uom; }
            set
            {
                if (_range_l_uom != value)
                {
                    _range_l_uom = value; RaisePropertyChanged("range_l_uom");
                }
            }
        }
        private double? _accuracy_h { get; set; }
        public double? accuracy_h
        {
            get { return _accuracy_h; }
            set
            {
                if (_accuracy_h != value)
                {
                    _accuracy_h = value; RaisePropertyChanged("accuracy_h");
                }
            }
        }
        private double? _accuracy_l { get; set; }
        public double? accuracy_l
        {
            get { return _accuracy_l; }
            set
            {
                if (_accuracy_l != value)
                {
                    _accuracy_l = value; RaisePropertyChanged("accuracy_l");
                }
            }
        }
        private double? _accuracy_h_var { get; set; }
        public double? accuracy_h_var
        {
            get { return _accuracy_h_var; }
            set
            {
                if (_accuracy_h_var != value)
                {
                    _accuracy_h_var = value; RaisePropertyChanged("accuracy_h_var");
                }
            }
        }
        private double? _accuracy_l_var { get; set; }
        public double? accuracy_l_var
        {
            get { return _accuracy_l_var; }
            set
            {
                if (_accuracy_l_var != value)
                {
                    _accuracy_l_var = value; RaisePropertyChanged("accuracy_l_var");
                }
            }
        }
        private double? _least_count { get; set; }
        public double? least_count
        {
            get { return _least_count; }
            set
            {
                if (_least_count != value)
                {
                    _least_count = value; RaisePropertyChanged("least_count");
                }
            }
        }
        private string _lc_uom { get; set; }
        public string lc_uom
        {
            get { return _lc_uom; }
            set
            {
                if (_lc_uom != value)
                {
                    _lc_uom = value; RaisePropertyChanged("lc_uom");
                }
            }
        }
        private double? _resolution { get; set; }
        public double? resolution
        {
            get { return _resolution; }
            set
            {
                if (_resolution != value)
                {
                    _resolution = value; RaisePropertyChanged("resolution");
                }
            }
        }
        private string _resolution_uom { get; set; }
        public string resolution_uom
        {
            get { return _resolution_uom; }
            set
            {
                if (_resolution_uom != value)
                {
                    _resolution_uom = value; RaisePropertyChanged("resolution_uom");
                }
            }
        }
        private double? _uncertainty { get; set; }
        public double? uncertainty
        {
            get { return _uncertainty; }
            set
            {
                if (_uncertainty != value)
                {
                    _uncertainty = value; RaisePropertyChanged("uncertainty");
                }
            }
        }
        private string _uncertainty_uom { get; set; }
        public string uncertainty_uom
        {
            get { return _uncertainty_uom; }
            set
            {
                if (_uncertainty_uom != value)
                {
                    _uncertainty_uom = value; RaisePropertyChanged("_uncertainty_uom");
                }
            }
        }
        private string _invoice_no { get; set; }
        public string invoice_no
        {
            get { return _invoice_no; }
            set
            {
                if (_invoice_no != value)
                {
                    _invoice_no = value; RaisePropertyChanged("invoice_no");
                }
            }
        }

        private decimal? _avg_consump { get; set; }
        public decimal? avg_consump
        {
            get { return _avg_consump; }
            set
            {
                if (_avg_consump != value)
                {
                    _avg_consump = value; RaisePropertyChanged("avg_consump");
                }
            }
        }
        private string _avg_uom { get; set; }
        public string avg_uom
        {
            get { return _avg_uom; }
            set
            {
                if (_avg_uom != value)
                {
                    _avg_uom = value; RaisePropertyChanged("avg_uom");
                }
            }
        }
        private string _emp_id { get; set; }
        public string emp_id
        {
            get { return _emp_id; }
            set
            {
                if (_emp_id != value)
                {
                    _emp_id = value; RaisePropertyChanged("emp_id");
                }
            }
        }
        private string _emp_name { get; set; }
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

        private string _ah_uom { get; set; }
        public string ah_uom
        {
            get { return _ah_uom; }
            set
            {
                if (_ah_uom != value)
                {
                    _ah_uom = value; RaisePropertyChanged("ah_uom");
                }
            }
        }
        private string _al_uom { get; set; }
        public string al_uom
        {
            get { return _al_uom; }
            set
            {
                if (_al_uom != value)
                {
                    _al_uom = value; RaisePropertyChanged("al_uom");
                }
            }
        }
        private string _tsb_code { get; set; }
        public string tsb_code
        {
            get { return _tsb_code; }
            set
            {
                if (_tsb_code != value)
                {
                    _tsb_code = value; RaisePropertyChanged("tsb_code");
                }
            }
        }
        private double? _ucmc { get; set; }
        public double? ucmc
        {
            get { return _ucmc; }
            set
            {
                if (_ucmc != value)
                {
                    _ucmc = value; RaisePropertyChanged("ucmc");
                }
            }
        }
        private double? _utot { get; set; }
        public double? utot
        {
            get { return _utot; }
            set
            {
                if (_utot != value)
                {
                    _utot = value; RaisePropertyChanged("utot");
                }
            }
        }
        private DateTime? _cal_date { get; set; }
        public DateTime? cal_date
        {
            get { return _cal_date; }
            set
            {
                if (_cal_date != value)
                {
                    _cal_date = value; RaisePropertyChanged("cal_date");
                }
            }
        }
        private string _cert_no { get; set; }
        public string cert_no
        {
            get { return _cert_no; }
            set
            {
                if (_cert_no != value)
                {
                    _cert_no = value; RaisePropertyChanged("cert_no");
                }
            }
        }
        private string _group_code { get; set; }
        public string group_code
        {
            get { return _group_code; }
            set
            {
                if (_group_code != value)
                {
                    _group_code = value; RaisePropertyChanged("group_code");
                }
            }
        }
        private string _ratio { get; set; }
        public string ratio
        {
            get { return _ratio; }
            set
            {
                if (_ratio != value)
                {
                    _ratio = value; RaisePropertyChanged("ratio");
                }
            }
        }
        private string _ratio_uom { get; set; }
        public string ratio_uom
        {
            get { return _ratio_uom; }
            set
            {
                if (_ratio_uom != value)
                {
                    _ratio_uom = value; RaisePropertyChanged("ratio_uom");
                }
            }
        }
        private string _rating_uom { get; set; }
        public string rating_uom
        {
            get { return _rating_uom; }
            set
            {
                if (_rating_uom != value)
                {
                    _rating_uom = value; RaisePropertyChanged("rating_uom");
                }
            }
        }
        private string _rating { get; set; }
        public string rating
        {
            get { return _rating; }
            set
            {
                if (_rating != value)
                {
                    _rating = value; RaisePropertyChanged("rating");
                }
            }
        }

        //Scalar
        private string _long_text { get; set; }
        public string long_text
        {
            get { return _long_text; }
            set
            {
                if (_long_text != value)
                {
                    _long_text = value; RaisePropertyChanged("long_text");
                }
            }
        }
        private string _object_name { get; set; }
        public string object_name
        {
            get { return _object_name; }
            set
            {
                if (_object_name != value)
                {
                    _object_name = value; RaisePropertyChanged("object_name");
                }
            }
        }
        private string _party_name { get; set; }
        public string party_name
        {
            get { return _party_name; }
            set
            {
                if (_party_name != value)
                {
                    _party_name = value; RaisePropertyChanged("party_name");
                }
            }
        }
        private string _t_display { get; set; }
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
        private string _cat_name { get; set; } 
        public string cat_name
        {
            get { return _cat_name; }
            set
            {
                if (_cat_name != value)
                {
                    _cat_name = value; RaisePropertyChanged("cat_name");
                }
            }
        }
        private string _group_name { get; set; }
        public string group_name
        {
            get { return _group_name; }
            set
            {
                if (_group_name != value)
                {
                    _group_name = value; RaisePropertyChanged("group_name");
                }
            }
        }
        private string _XDOC_A { get; set; } // Fleet Info
        public string XDOC_A
        {
            get { return _XDOC_A; }
            set
            {
                if (_XDOC_A != value)
                {
                    _XDOC_A = value; RaisePropertyChanged("XDOC_A");
                }
            }
        }

    }

    public class PMM_M0021 : ObjectBase
    {
        private string _comp_code { get; set; }
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
        private string _obj_no { get; set; }
        public string obj_no
        {
            get { return _obj_no; }
            set
            {
                if (_obj_no != value)
                {
                    _obj_no = value; RaisePropertyChanged("obj_no");
                }
            }
        }
        private string _obj_group { get; set; }
        public string obj_group
        {
            get { return _obj_group; }
            set
            {
                if (_obj_group != value)
                {
                    _obj_group = value; RaisePropertyChanged("obj_group");
                }
            }
        }
        private string _obj_type { get; set; }
        public string obj_type
        {
            get { return _obj_type; }
            set
            {
                if (_obj_type != value)
                {
                    _obj_type = value; RaisePropertyChanged("obj_type");
                }
            }
        }
        private string _equip_cat { get; set; }
        public string equip_cat
        {
            get { return _equip_cat; }
            set
            {
                if (_equip_cat != value)
                {
                    _equip_cat = value; RaisePropertyChanged("equip_cat");
                }
            }
        }
        private string _equip_no { get; set; }
        public string equip_no
        {
            get { return _equip_no; }
            set
            {
                if (_equip_no != value)
                {
                    _equip_no = value; RaisePropertyChanged("equip_no");
                }
            }
        }
        private string _fleet_no { get; set; }
        public string fleet_no
        {
            get { return _fleet_no; }
            set
            {
                if (_fleet_no != value)
                {
                    _fleet_no = value; RaisePropertyChanged("fleet_no");
                }
            }
        }
        private string _short_text { get; set; }
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
        private string _fleet_no_mfg { get; set; }
        public string fleet_no_mfg
        {
            get { return _fleet_no_mfg; }
            set
            {
                if (_fleet_no_mfg != value)
                {
                    _fleet_no_mfg = value; RaisePropertyChanged("fleet_no_mfg");
                }
            }
        }
        private string _chassis_no { get; set; }
        public string chassis_no
        {
            get { return _chassis_no; }
            set
            {
                if (_chassis_no != value)
                {
                    _chassis_no = value; RaisePropertyChanged("chassis_no");
                }
            }
        }
        private string _lic_no { get; set; }
        public string lic_no
        {
            get { return _lic_no; }
            set
            {
                if (_lic_no != value)
                {
                    _lic_no = value; RaisePropertyChanged("lic_no");
                }
            }
        }
        private DateTime? _valid_from { get; set; }
        public DateTime? valid_from
        {
            get { return _valid_from; }
            set
            {
                if (_valid_from != value)
                {
                    _valid_from = value; RaisePropertyChanged("valid_from");
                }
            }
        }
        private DateTime? _valid_to { get; set; }
        public DateTime? valid_to
        {
            get { return _valid_to; }
            set
            {
                if (_valid_to != value)
                {
                    _valid_to = value; RaisePropertyChanged("valid_to");
                }
            }
        }
        private decimal? _obj_height { get; set; }
        public decimal? obj_height
        {
            get { return _obj_height; }
            set
            {
                if (_obj_height != value)
                {
                    _obj_height = value; RaisePropertyChanged("obj_height");
                }
            }
        }
        private decimal? _obj_width { get; set; }
        public decimal? obj_width
        {
            get { return _obj_width; }
            set
            {
                if (_obj_width != value)
                {
                    _obj_width = value; RaisePropertyChanged("obj_width");
                }
            }
        }
        private decimal? _obj_length { get; set; }
        public decimal? obj_length
        {
            get { return _obj_length; }
            set
            {
                if (_obj_length != value)
                {
                    _obj_length = value; RaisePropertyChanged("obj_length");
                }
            }
        }
        private string _uom_length { get; set; }
        public string uom_length
        {
            get { return _uom_length; }
            set
            {
                if (_uom_length != value)
                {
                    _uom_length = value; RaisePropertyChanged("uom_length");
                }
            }
        }
        private string _ind_cal { get; set; }
        public string ind_cal
        {
            get { return _ind_cal; }
            set
            {
                if (_ind_cal != value)
                {
                    _ind_cal = value; RaisePropertyChanged("ind_cal");
                }
            }
        }
        private DateTime? _date_replace { get; set; }
        public DateTime? date_replace
        {
            get { return _date_replace; }
            set
            {
                if (_date_replace != value)
                {
                    _date_replace = value; RaisePropertyChanged("date_replace");
                }
            }
        }
        private string _odo_reading { get; set; }
        public string odo_reading
        {
            get { return _odo_reading; }
            set
            {
                if (_odo_reading != value)
                {
                    _odo_reading = value; RaisePropertyChanged("odo_reading");
                }
            }
        }
        private string _hr_reading { get; set; }
        public string hr_reading
        {
            get { return _hr_reading; }
            set
            {
                if (_hr_reading != value)
                {
                    _hr_reading = value; RaisePropertyChanged("hr_reading");
                }
            }
        }
        private int? _axel_no { get; set; }
        public int? axel_no
        {
            get { return _axel_no; }
            set
            {
                if (_axel_no != value)
                {
                    _axel_no = value; RaisePropertyChanged("axel_no");
                }
            }
        }
        private int? _max_ocu { get; set; }
        public int? max_ocu
        {
            get { return _max_ocu; }
            set
            {
                if (_max_ocu != value)
                {
                    _max_ocu = value; RaisePropertyChanged("max_ocu");
                }
            }
        }
        private string _fuel_card { get; set; }
        public string fuel_card
        {
            get { return _fuel_card; }
            set
            {
                if (_fuel_card != value)
                {
                    _fuel_card = value; RaisePropertyChanged("fuel_card");
                }
            }
        }
        private string _key_no { get; set; }
        public string key_no
        {
            get { return _key_no; }
            set
            {
                if (_key_no != value)
                {
                    _key_no = value; RaisePropertyChanged("key_no");
                }
            }
        }
        private string _ind_use { get; set; }
        public string ind_use
        {
            get { return _ind_use; }
            set
            {
                if (_ind_use != value)
                {
                    _ind_use = value; RaisePropertyChanged("ind_use");
                }
            }
        }
        private string _engine_type { get; set; }
        public string engine_type
        {
            get { return _engine_type; }
            set
            {
                if (_engine_type != value)
                {
                    _engine_type = value; RaisePropertyChanged("engine_type");
                }
            }
        }
        private decimal? _eng_power { get; set; }
        public decimal? eng_power
        {
            get { return _eng_power; }
            set
            {
                if (_eng_power != value)
                {
                    _eng_power = value; RaisePropertyChanged("eng_power");
                }
            }
        }
        private string _uom_power { get; set; }
        public string uom_power
        {
            get { return _uom_power; }
            set
            {
                if (_uom_power != value)
                {
                    _uom_power = value; RaisePropertyChanged("uom_power");
                }
            }
        }
        private decimal? _rpm { get; set; }
        public decimal? rpm
        {
            get { return _rpm; }
            set
            {
                if (_rpm != value)
                {
                    _rpm = value; RaisePropertyChanged("rpm");
                }
            }
        }
        private int? _cyl_no { get; set; }
        public int? cyl_no
        {
            get { return _cyl_no; }
            set
            {
                if (_cyl_no != value)
                {
                    _cyl_no = value; RaisePropertyChanged("cyl_no");
                }
            }
        }
        private decimal? _eng_capacity { get; set; }
        public decimal? eng_capacity
        {
            get { return _eng_capacity; }
            set
            {
                if (_eng_capacity != value)
                {
                    _eng_capacity = value; RaisePropertyChanged("eng_capacity");
                }
            }
        }
        private string _uom_eng { get; set; }
        public string uom_eng
        {
            get { return _uom_eng; }
            set
            {
                if (_uom_eng != value)
                {
                    _uom_eng = value; RaisePropertyChanged("uom_eng");
                }
            }
        }
        private string _eng_sr { get; set; }
        public string eng_sr
        {
            get { return _eng_sr; }
            set
            {
                if (_eng_sr != value)
                {
                    _eng_sr = value; RaisePropertyChanged("eng_sr");
                }
            }
        }
        private string _con_type1 { get; set; }
        public string con_type1
        {
            get { return _con_type1; }
            set
            {
                if (_con_type1 != value)
                {
                    _con_type1 = value; RaisePropertyChanged("con_type1");
                }
            }
        }
        private string _con_type2 { get; set; }
        public string con_type2
        {
            get { return _con_type2; }
            set
            {
                if (_con_type2 != value)
                {
                    _con_type2 = value; RaisePropertyChanged("con_type2");
                }
            }
        }
        private string _oil_type { get; set; }
        public string oil_type
        {
            get { return _oil_type; }
            set
            {
                if (_oil_type != value)
                {
                    _oil_type = value; RaisePropertyChanged("oil_type");
                }
            }
        }
        private decimal? _wt_allowed { get; set; }
        public decimal? wt_allowed
        {
            get { return _wt_allowed; }
            set
            {
                if (_wt_allowed != value)
                {
                    _wt_allowed = value; RaisePropertyChanged("wt_allowed");
                }
            }
        }
        private decimal? _max_load { get; set; }
        public decimal? max_load
        {
            get { return _max_load; }
            set
            {
                if (_max_load != value)
                {
                    _max_load = value; RaisePropertyChanged("max_load");
                }
            }
        }
        private string _uom_wt { get; set; }
        public string uom_wt
        {
            get { return _uom_wt; }
            set
            {
                if (_uom_wt != value)
                {
                    _uom_wt = value; RaisePropertyChanged("uom_wt");
                }
            }
        }
        private decimal? _load_height { get; set; }
        public decimal? load_height
        {
            get { return _load_height; }
            set
            {
                if (_load_height != value)
                {
                    _load_height = value; RaisePropertyChanged("load_height");
                }
            }
        }
        private decimal? _load_width { get; set; }
        public decimal? load_width
        {
            get { return _load_width; }
            set
            {
                if (_load_width != value)
                {
                    _load_width = value; RaisePropertyChanged("load_width");
                }
            }
        }
        private decimal? _load_length { get; set; }
        public decimal? load_length
        {
            get { return _load_length; }
            set
            {
                if (_load_length != value)
                {
                    _load_length = value; RaisePropertyChanged("load_length");
                }
            }
        }
        private string _uom_freight { get; set; }
        public string uom_freight
        {
            get { return _uom_freight; }
            set
            {
                if (_uom_freight != value)
                {
                    _uom_freight = value; RaisePropertyChanged("uom_freight");
                }
            }
        }
        private decimal? _load_volume { get; set; }
        public decimal? load_volume
        {
            get { return _load_volume; }
            set
            {
                if (_load_volume != value)
                {
                    _load_volume = value; RaisePropertyChanged("load_volume");
                }
            }
        }
        private string _uom_volume { get; set; }
        public string uom_volume
        {
            get { return _uom_volume; }
            set
            {
                if (_uom_volume != value)
                {
                    _uom_volume = value; RaisePropertyChanged("uom_volume");
                }
            }
        }
        private int? _comp_no { get; set; }
        public int? comp_no
        {
            get { return _comp_no; }
            set
            {
                if (_comp_no != value)
                {
                    _comp_no = value; RaisePropertyChanged("comp_no");
                }
            }
        }
        private decimal? _max_speed { get; set; }
        public decimal? max_speed
        {
            get { return _max_speed; }
            set
            {
                if (_max_speed != value)
                {
                    _max_speed = value; RaisePropertyChanged("max_speed");
                }
            }
        }
        private string _uom_speed { get; set; }
        public string uom_speed
        {
            get { return _uom_speed; }
            set
            {
                if (_uom_speed != value)
                {
                    _uom_speed = value; RaisePropertyChanged("uom_speed");
                }
            }
        }
        private decimal? _trailer_load { get; set; }
        public decimal? trailer_load
        {
            get { return _trailer_load; }
            set
            {
                if (_trailer_load != value)
                {
                    _trailer_load = value; RaisePropertyChanged("trailer_load");
                }
            }
        }
        private string _uom_weight { get; set; }
        public string uom_weight
        {
            get { return _uom_weight; }
            set
            {
                if (_uom_weight != value)
                {
                    _uom_weight = value; RaisePropertyChanged("uom_weight");
                }
            }
        }
        private string _active { get; set; }
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
        private string _color { get; set; }
        public string color
        {
            get { return _color; }
            set
            {
                if (_color != value)
                {
                    _color = value; RaisePropertyChanged("color");
                }
            }
        }
        private DateTime? _reg_date { get; set; }
        public DateTime? reg_date
        {
            get { return _reg_date; }
            set
            {
                if (_reg_date != value)
                {
                    _reg_date = value; RaisePropertyChanged("reg_date");
                }
            }
        }
        


        private string _long_text { get; set; }
        public string long_text
        {
            get { return _long_text; }
            set
            {
                if (_long_text != value)
                {
                    _long_text = value; RaisePropertyChanged("long_text");
                }
            }
        }


    }

    public class PMM_T001 : ObjectBase
    {

        private int? _id;
        public int? id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }

        private string _location_id;
        public string location_id
        {
            get { return _location_id; }
            set { _location_id = value; RaisePropertyChanged("location_id"); }
        }

        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set { _doc_no = value; RaisePropertyChanged("doc_no"); }
        }

        private DateTime? _doc_date;
        public DateTime? doc_date
        {
            get { return _doc_date; }
            set { _doc_date = value; RaisePropertyChanged("doc_date"); }
        }

        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set { _doc_cat = value; RaisePropertyChanged("doc_cat"); }
        }

        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set { _doc_type = value; RaisePropertyChanged("doc_type"); }
        }

        private string _short_text;
        public string short_text
        {
            get { return _short_text; }
            set { _short_text = value; RaisePropertyChanged("short_text"); }
        }

        private string _mp_cat;
        public string mp_cat
        {
            get { return _mp_cat; }
            set { _mp_cat = value; RaisePropertyChanged("mp_cat"); }
        }

        private string _str_code;
        public string str_code
        {
            get { return _str_code; }
            set { _str_code = value; RaisePropertyChanged("str_code"); }
        }

        private int? _sch_period;
        public int? sch_period
        {
            get { return _sch_period; }
            set { _sch_period = value; RaisePropertyChanged("sch_period"); }
        }

        private string _sch_unit;
        public string sch_unit
        {
            get { return _sch_unit; }
            set { _sch_unit = value; RaisePropertyChanged("sch_unit"); }
        }

        private string _equip_no;
        public string equip_no
        {
            get { return _equip_no; }
            set { _equip_no = value; RaisePropertyChanged("equip_no"); }
        }

        private string _fun_loc;
        public string fun_loc
        {
            get { return _fun_loc; }
            set { _fun_loc = value; RaisePropertyChanged("fun_loc"); }
        }

        private string _cust_id;
        public string cust_id
        {
            get { return _cust_id; }
            set { _cust_id = value; RaisePropertyChanged("cust_id"); }
        }

        private string _party_code;
        public string party_code
        {
            get { return _party_code; }
            set { _party_code = value; RaisePropertyChanged("party_code"); }
        }

        private int? _call_no;
        public int? call_no
        {
            get { return _call_no; }
            set { _call_no = value; RaisePropertyChanged("call_no"); }
        }

        private int? _shift_late;
        public int? shift_late
        {
            get { return _shift_late; }
            set { _shift_late = value; RaisePropertyChanged("shift_late"); }
        }

        private int? _shift_early;
        public int? shift_early
        {
            get { return _shift_early; }
            set { _shift_early = value; RaisePropertyChanged("shift_early"); }
        }

        private int? _tol_late;
        public int? tol_late
        {
            get { return _tol_late; }
            set { _tol_late = value; RaisePropertyChanged("tol_late"); }
        }

        private int? _tol_early;
        public int? tol_early
        {
            get { return _tol_early; }
            set { _tol_early = value; RaisePropertyChanged("tol_early"); }
        }

        private decimal _mod_factor;
        public decimal mod_factor
        {
            get { return _mod_factor; }
            set { _mod_factor = value; RaisePropertyChanged("mod_factor"); }
        }

        private string _ind_sch;
        public string ind_sch
        {
            get { return _ind_sch; }
            set { _ind_sch = value; RaisePropertyChanged("ind_sch"); }
        }

        private int? _re_sch;
        public int? re_sch
        {
            get { return _re_sch; }
            set { _re_sch = value; RaisePropertyChanged("re_sch"); }
        }

        private int? _trigger_point;
        public int? trigger_point
        {
            get { return _trigger_point; }
            set { _trigger_point = value; RaisePropertyChanged("trigger_point"); }
        }

        private string _ind_or_and;
        public string ind_or_and
        {
            get { return _ind_or_and; }
            set { _ind_or_and = value; RaisePropertyChanged("ind_or_and"); }
        }

        private string _ind_reserved;
        public string ind_reserved
        {
            get { return _ind_reserved; }
            set { _ind_reserved = value; RaisePropertyChanged("ind_reserved"); }
        }

        private string _obj_no;
        public string obj_no
        {
            get { return _obj_no; }
            set { _obj_no = value; RaisePropertyChanged("obj_no"); }
        }

        private DateTime? _start_date;
        public DateTime? start_date
        {
            get { return _start_date; }
            set { _start_date = value; RaisePropertyChanged("start_date"); }
        }

        private string _start_counter;
        public string start_counter
        {
            get { return _start_counter; }
            set { _start_counter = value; RaisePropertyChanged("start_counter"); }
        }

        private int? _l_float;
        public int? l_float
        {
            get { return _l_float; }
            set { _l_float = value; RaisePropertyChanged("l_float"); }
        }

        private int? _f_float;
        public int? f_float
        {
            get { return _f_float; }
            set { _f_float = value; RaisePropertyChanged("f_float"); }
        }

        private DateTime? _sch_start;
        public DateTime? sch_start
        {
            get { return _sch_start; }
            set { _sch_start = value; RaisePropertyChanged("sch_start"); }
        }

        private string _sch_time;
        public string sch_time
        {
            get { return _sch_time; }
            set { _sch_time = value; RaisePropertyChanged("sch_time"); }
        }

        private string _active;
        public string active
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


        //Scalar Fields

        private string _long_text;
        public string long_text
        {
            get { return _long_text; }
            set { _long_text = value; RaisePropertyChanged("long_text"); }
        }
        public string XDOC_A { get; set; }
        public string XDOC_B { get; set; }
        public string XDOC_C { get; set; }
        public string XDOC_D { get; set; }
        public string XDOC_E { get; set; }

    }

    public class PMM_T001_A : ObjectBase
    {
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }

        private string _location_id;
        public string location_id
        {
            get { return _location_id; }
            set { _location_id = value; RaisePropertyChanged("location_id"); }
        }

        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set { _doc_no = value; RaisePropertyChanged("doc_no"); }
        }

        private int? _id;
        public int? id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }

        private string _mp_item;
        public string mp_item
        {
            get { return _mp_item; }
            set { _mp_item = value; RaisePropertyChanged("mp_item"); }
        }

        private string _str_code;
        public string str_code
        {
            get { return _str_code; }
            set { _str_code = value; RaisePropertyChanged("str_code"); }
        }

        private int? _line_id;
        public int? line_id
        {
            get { return _line_id; }
            set { _line_id = value; RaisePropertyChanged("line_id"); }
        }

        private string _short_text;
        public string short_text
        {
            get { return _short_text; }
            set { _short_text = value; RaisePropertyChanged("short_text"); }
        }

        private string _equip_no;
        public string equip_no
        {
            get { return _equip_no; }
            set { _equip_no = value; RaisePropertyChanged("equip_no"); }
        }

        private int? _obj_list_no;
        public int? obj_list_no
        {
            get { return _obj_list_no; }
            set { _obj_list_no = value; RaisePropertyChanged("obj_list_no"); }
        }

        private string _tl_type;
        public string tl_type
        {
            get { return _tl_type; }
            set { _tl_type = value; RaisePropertyChanged("tl_type"); }
        }

        private string _tl_key;
        public string tl_key
        {
            get { return _tl_key; }
            set { _tl_key = value; RaisePropertyChanged("tl_key"); }
        }

        private int? _op_row_id;
        public int? op_row_id
        {
            get { return _op_row_id; }
            set { _op_row_id = value; RaisePropertyChanged("op_row_id"); }
        }

        private string _group_counter;
        public string group_counter
        {
            get { return _group_counter; }
            set { _group_counter = value; RaisePropertyChanged("group_counter"); }
        }

        private string _wc_code;
        public string wc_code
        {
            get { return _wc_code; }
            set { _wc_code = value; RaisePropertyChanged("wc_code"); }
        }

        private string _mp_plant;
        public string mp_plant
        {
            get { return _mp_plant; }
            set { _mp_plant = value; RaisePropertyChanged("mp_plant"); }
        }

        private string _order_no;
        public string order_no
        {
            get { return _order_no; }
            set { _order_no = value; RaisePropertyChanged("order_no"); }
        }

        private string _order_cat;
        public string order_cat
        {
            get { return _order_cat; }
            set { _order_cat = value; RaisePropertyChanged("order_cat"); }
        }

        private string _assembly_code;
        public string assembly_code
        {
            get { return _assembly_code; }
            set { _assembly_code = value; RaisePropertyChanged("assembly_code"); }
        }

        private string _mp_act;
        public string mp_act
        {
            get { return _mp_act; }
            set { _mp_act = value; RaisePropertyChanged("mp_act"); }
        }

        private string _obj_no;
        public string obj_no
        {
            get { return _obj_no; }
            set { _obj_no = value; RaisePropertyChanged("obj_no"); }
        }

        private string _element_id;
        public string element_id
        {
            get { return _element_id; }
            set { _element_id = value; RaisePropertyChanged("element_id"); }
        }

        private string _tl_key2;
        public string tl_key2
        {
            get { return _tl_key2; }
            set { _tl_key2 = value; RaisePropertyChanged("tl_key2"); }
        }

        private int? _tl_node;
        public int? tl_node
        {
            get { return _tl_node; }
            set { _tl_node = value; RaisePropertyChanged("tl_node"); }
        }

        private string _sd_doc_no;
        public string sd_doc_no
        {
            get { return _sd_doc_no; }
            set { _sd_doc_no = value; RaisePropertyChanged("sd_doc_no"); }
        }

        private int? _sd_item_row_id;
        public int? sd_item_row_id
        {
            get { return _sd_item_row_id; }
            set { _sd_item_row_id = value; RaisePropertyChanged("sd_item_row_id"); }
        }

        private string _item_cat;
        public string item_cat
        {
            get { return _item_cat; }
            set { _item_cat = value; RaisePropertyChanged("item_cat"); }
        }

        private string _po_no;
        public string po_no
        {
            get { return _po_no; }
            set { _po_no = value; RaisePropertyChanged("po_no"); }
        }

        private int? _po_tem_row_id;
        public int? po_tem_row_id
        {
            get { return _po_tem_row_id; }
            set { _po_tem_row_id = value; RaisePropertyChanged("po_tem_row_id"); }
        }

        private int? _pack_no;
        public int? pack_no
        {
            get { return _pack_no; }
            set { _pack_no = value; RaisePropertyChanged("pack_no"); }
        }

        private decimal _net_price;
        public decimal net_price
        {
            get { return _net_price; }
            set { _net_price = value; RaisePropertyChanged("net_price"); }
        }

        private string _curr_code;
        public string curr_code
        {
            get { return _curr_code; }
            set { _curr_code = value; RaisePropertyChanged("curr_code"); }
        }

        private string _set_order;
        public string set_order
        {
            get { return _set_order; }
            set { _set_order = value; RaisePropertyChanged("set_order"); }
        }

        private decimal _exe_fact;
        public decimal exe_fact
        {
            get { return _exe_fact; }
            set { _exe_fact = value; RaisePropertyChanged("exe_fact"); }
        }

        private string _serial_no;
        public string serial_no
        {
            get { return _serial_no; }
            set { _serial_no = value; RaisePropertyChanged("serial_no"); }
        }

        private string _item_code;
        public string item_code
        {
            get { return _item_code; }
            set { _item_code = value; RaisePropertyChanged("item_code"); }
        }

        private string _device_data;
        public string device_data
        {
            get { return _device_data; }
            set { _device_data = value; RaisePropertyChanged("device_data"); }
        }

        private string _not_no;
        public string not_no
        {
            get { return _not_no; }
            set { _not_no = value; RaisePropertyChanged("not_no"); }
        }

        private string _not_type;
        public string not_type
        {
            get { return _not_type; }
            set { _not_type = value; RaisePropertyChanged("not_type"); }
        }

        private string _entry_no;
        public string entry_no
        {
            get { return _entry_no; }
            set { _entry_no = value; RaisePropertyChanged("entry_no"); }
        }

        private string _cat_type;
        public string cat_type
        {
            get { return _cat_type; }
            set { _cat_type = value; RaisePropertyChanged("cat_type"); }
        }

        private string _code_group;
        public string code_group
        {
            get { return _code_group; }
            set { _code_group = value; RaisePropertyChanged("code_group"); }
        }

        private string _value_code;
        public string value_code
        {
            get { return _value_code; }
            set { _value_code = value; RaisePropertyChanged("value_code"); }
        }

        private string _sample_no;
        public string sample_no
        {
            get { return _sample_no; }
            set { _sample_no = value; RaisePropertyChanged("sample_no"); }
        }

        private string _insp_type;
        public string insp_type
        {
            get { return _insp_type; }
            set { _insp_type = value; RaisePropertyChanged("insp_type"); }
        }

        private string _insp_lot;
        public string insp_lot
        {
            get { return _insp_lot; }
            set { _insp_lot = value; RaisePropertyChanged("insp_lot"); }
        }

        private int? _cycle_seq;
        public int? cycle_seq
        {
            get { return _cycle_seq; }
            set { _cycle_seq = value; RaisePropertyChanged("cycle_seq"); }
        }

        private string _ref_element;
        public string ref_element
        {
            get { return _ref_element; }
            set { _ref_element = value; RaisePropertyChanged("ref_element"); }
        }

        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }
        }

        private string _active;
        public string active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }



        // Scalar

        private string _item_name;
        public string item_name
        {
            get { return _item_name; }
            set { _item_name = value; RaisePropertyChanged("item_name"); }
        }
        private string _equip_name;
        public string equip_name
        {
            get { return _equip_name; }
            set { _equip_name = value; RaisePropertyChanged("equip_name"); }
        }
        private string _location_name;
        public string location_name
        {
            get { return _location_name; }
            set { _location_name = value; RaisePropertyChanged("location_name"); }
        }
        private string _wc_name;
        public string wc_name
        {
            get { return _wc_name; }
            set { _wc_name = value; RaisePropertyChanged("wc_name"); }
        }
        private string _strategy_name;
        public string strategy_name
        {
            get { return _strategy_name; }
            set { _strategy_name = value; RaisePropertyChanged("strategy_name"); }
        }
        private string _plan_cat_name;
        public string plan_cat_name
        {
            get { return _plan_cat_name; }
            set { _plan_cat_name = value; RaisePropertyChanged("plan_cat_name"); }
        }
        private string _order_cat_name;
        public string order_cat_name
        {
            get { return _order_cat_name; }
            set { _order_cat_name = value; RaisePropertyChanged("order_cat_name"); }
        }
        private string _tl_name;
        public string tl_name
        {
            get { return _tl_name; }
            set { _tl_name = value; RaisePropertyChanged("tl_name"); }
        }

    }

    public class PMM_T001_B : ObjectBase
    {
        private int? _id;
        public int? id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }

        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set { _doc_no = value; RaisePropertyChanged("doc_no"); }
        }

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }

        private string _location_id;
        public string location_id
        {
            get { return _location_id; }
            set { _location_id = value; RaisePropertyChanged("location_id"); }
        }

        private int? _item_row_id;
        public int? item_row_id
        {
            get { return _item_row_id; }
            set { _item_row_id = value; RaisePropertyChanged("item_row_id"); }
        }

        private int? _t_counter;
        public int? t_counter
        {
            get { return _t_counter; }
            set { _t_counter = value; RaisePropertyChanged("t_counter"); }
        }

        private string _comp_opr;
        public string comp_opr
        {
            get { return _comp_opr; }
            set { _comp_opr = value; RaisePropertyChanged("comp_opr"); }
        }

        private double? _mp_cycle;
        public double? mp_cycle
        {
            get { return _mp_cycle; }
            set { _mp_cycle = value; RaisePropertyChanged("mp_cycle"); }
        }

        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code"); }
        }

        private string _short_text;
        public string short_text
        {
            get { return _short_text; }
            set { _short_text = value; RaisePropertyChanged("short_text"); }
        }

        private string _mp_no;
        public string mp_no
        {
            get { return _mp_no; }
            set { _mp_no = value; RaisePropertyChanged("mp_no"); }
        }

        private double? _mp_offset;
        public double? mp_offset
        {
            get { return _mp_offset; }
            set { _mp_offset = value; RaisePropertyChanged("mp_offset"); }
        }

        private string _ind_event;
        public string ind_event
        {
            get { return _ind_event; }
            set { _ind_event = value; RaisePropertyChanged("ind_event"); }
        }

        private double? _next_read;
        public double? next_read
        {
            get { return _next_read; }
            set { _next_read = value; RaisePropertyChanged("next_read"); }
        }

        private int? _pack_no;
        public int? pack_no
        {
            get { return _pack_no; }
            set { _pack_no = value; RaisePropertyChanged("pack_no"); }
        }

        private string _note;
        public string note
        {
            get { return _note; }
            set { _note = value; RaisePropertyChanged("note"); }
        }

        private int? _cycle_seq;
        public int? cycle_seq
        {
            get { return _cycle_seq; }
            set { _cycle_seq = value; RaisePropertyChanged("cycle_seq"); }
        }

        private int? _rep_factor;
        public int? rep_factor
        {
            get { return _rep_factor; }
            set { _rep_factor = value; RaisePropertyChanged("rep_factor"); }
        }

        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }
        }

        private string _active;
        public string active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }


    }

    public class PMM_T002 : ObjectBase
    {
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }

        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set { _doc_no = value; RaisePropertyChanged("doc_no"); }
        }

        private int? _call_no;
        public int? call_no
        {
            get { return _call_no; }
            set { _call_no = value; RaisePropertyChanged("call_no"); }
        }

        private int? _pack_no;
        public int? pack_no
        {
            get { return _pack_no; }
            set { _pack_no = value; RaisePropertyChanged("pack_no"); }
        }

        private string _location_id;
        public string location_id
        {
            get { return _location_id; }
            set { _location_id = value; RaisePropertyChanged("location_id"); }
        }

        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set { _doc_cat = value; RaisePropertyChanged("doc_cat"); }
        }

        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set { _doc_type = value; RaisePropertyChanged("doc_type"); }
        }

        private DateTime? _next_plan_date;
        public DateTime? next_plan_date
        {
            get { return _next_plan_date; }
            set { _next_plan_date = value; RaisePropertyChanged("next_plan_date"); }
        }

        private DateTime? _last_plan_date;
        public DateTime? last_plan_date
        {
            get { return _last_plan_date; }
            set { _last_plan_date = value; RaisePropertyChanged("last_plan_date"); }
        }

        private string _sch_type;
        public string sch_type
        {
            get { return _sch_type; }
            set { _sch_type = value; RaisePropertyChanged("sch_type"); }
        }

        private DateTime? _start_date;
        public DateTime? start_date
        {
            get { return _start_date; }
            set { _start_date = value; RaisePropertyChanged("start_date"); }
        }

        private DateTime? _last_comp_date;
        public DateTime? last_comp_date
        {
            get { return _last_comp_date; }
            set { _last_comp_date = value; RaisePropertyChanged("last_comp_date"); }
        }

        private double? _offset_curr;
        public double? offset_curr
        {
            get { return _offset_curr; }
            set { _offset_curr = value; RaisePropertyChanged("offset_curr"); }
        }

        private double? _offset_prev;
        public double? offset_prev
        {
            get { return _offset_prev; }
            set { _offset_prev = value; RaisePropertyChanged("offset_prev"); }
        }

        private DateTime? _call_date;
        public DateTime? call_date
        {
            get { return _call_date; }
            set { _call_date = value; RaisePropertyChanged("call_date"); }
        }

        private string _emp_id;
        public string emp_id
        {
            get { return _emp_id; }
            set { _emp_id = value; RaisePropertyChanged("emp_id"); }
        }

        private decimal? _mod_factor;
        public decimal? mod_factor
        {
            get { return _mod_factor; }
            set { _mod_factor = value; RaisePropertyChanged("mod_factor"); }
        }

        private string _ind_sch;
        public string ind_sch
        {
            get { return _ind_sch; }
            set { _ind_sch = value; RaisePropertyChanged("ind_sch"); }
        }

        private int? _sf_late;
        public int? sf_late
        {
            get { return _sf_late; }
            set { _sf_late = value; RaisePropertyChanged("sf_late"); }
        }

        private int? _tol_late;
        public int? tol_late
        {
            get { return _tol_late; }
            set { _tol_late = value; RaisePropertyChanged("tol_late"); }
        }

        private DateTime? _manual_date;
        public DateTime? manual_date
        {
            get { return _manual_date; }
            set { _manual_date = value; RaisePropertyChanged("manual_date"); }
        }

        private double? _prf_annual;
        public double? prf_annual
        {
            get { return _prf_annual; }
            set { _prf_annual = value; RaisePropertyChanged("prf_annual"); }
        }

        private double? _shift_factor;
        public double? shift_factor
        {
            get { return _shift_factor; }
            set { _shift_factor = value; RaisePropertyChanged("shift_factor"); }
        }

        private string _ind_reserved;
        public string ind_reserved
        {
            get { return _ind_reserved; }
            set { _ind_reserved = value; RaisePropertyChanged("ind_reserved"); }
        }

        private string _ind_call_date;
        public string ind_call_date
        {
            get { return _ind_call_date; }
            set { _ind_call_date = value; RaisePropertyChanged("ind_call_date"); }
        }

        private string _ind_call_out;
        public string ind_call_out
        {
            get { return _ind_call_out; }
            set { _ind_call_out = value; RaisePropertyChanged("ind_call_out"); }
        }

        private string _ind_call_reached;
        public string ind_call_reached
        {
            get { return _ind_call_reached; }
            set { _ind_call_reached = value; RaisePropertyChanged("ind_call_reached"); }
        }

        private string _ind_stop;
        public string ind_stop
        {
            get { return _ind_stop; }
            set { _ind_stop = value; RaisePropertyChanged("ind_stop"); }
        }

        private DateTime? _call_date2;
        public DateTime? call_date2
        {
            get { return _call_date2; }
            set { _call_date2 = value; RaisePropertyChanged("call_date2"); }
        }

        private string _sch_status;
        public string sch_status
        {
            get { return _sch_status; }
            set { _sch_status = value; RaisePropertyChanged("sch_status"); }
        }

        private int? _prev_call;
        public int? prev_call
        {
            get { return _prev_call; }
            set { _prev_call = value; RaisePropertyChanged("prev_call"); }
        }

        private double? _pkg_offset;
        public double? pkg_offset
        {
            get { return _pkg_offset; }
            set { _pkg_offset = value; RaisePropertyChanged("pkg_offset"); }
        }

        private double? _call_date_reading;
        public double? call_date_reading
        {
            get { return _call_date_reading; }
            set { _call_date_reading = value; RaisePropertyChanged("call_date_reading"); }
        }

        private int? _lead_float;
        public int? lead_float
        {
            get { return _lead_float; }
            set { _lead_float = value; RaisePropertyChanged("lead_float"); }
        }

        private int? _follow_float;
        public int? follow_float
        {
            get { return _follow_float; }
            set { _follow_float = value; RaisePropertyChanged("follow_float"); }
        }

        private double? _start_reading;
        public double? start_reading
        {
            get { return _start_reading; }
            set { _start_reading = value; RaisePropertyChanged("start_reading"); }
        }

        private double? _read_confirm;
        public double? read_confirm
        {
            get { return _read_confirm; }
            set { _read_confirm = value; RaisePropertyChanged("read_confirm"); }
        }

        private double? _next_reading;
        public double? next_reading
        {
            get { return _next_reading; }
            set { _next_reading = value; RaisePropertyChanged("next_reading"); }
        }

        private string _sch_emp_id;
        public string sch_emp_id
        {
            get { return _sch_emp_id; }
            set { _sch_emp_id = value; RaisePropertyChanged("sch_emp_id"); }
        }

        private string _mp_no;
        public string mp_no
        {
            get { return _mp_no; }
            set { _mp_no = value; RaisePropertyChanged("mp_no"); }
        }

        private string _ind_or_and;
        public string ind_or_and
        {
            get { return _ind_or_and; }
            set { _ind_or_and = value; RaisePropertyChanged("ind_or_and"); }
        }

        private int? _re_sch;
        public int? re_sch
        {
            get { return _re_sch; }
            set { _re_sch = value; RaisePropertyChanged("re_sch"); }
        }

        private double? _pkg_offset1;
        public double? pkg_offset1
        {
            get { return _pkg_offset1; }
            set { _pkg_offset1 = value; RaisePropertyChanged("pkg_offset1"); }
        }

        private string _per_unit;
        public string per_unit
        {
            get { return _per_unit; }
            set { _per_unit = value; RaisePropertyChanged("per_unit"); }
        }

        private double? _time_offset;
        public double? time_offset
        {
            get { return _time_offset; }
            set { _time_offset = value; RaisePropertyChanged("time_offset"); }
        }

        private double? _next_plan_reading;
        public double? next_plan_reading
        {
            get { return _next_plan_reading; }
            set { _next_plan_reading = value; RaisePropertyChanged("next_plan_reading"); }
        }

        private string _start_time;
        public string start_time
        {
            get { return _start_time; }
            set { _start_time = value; RaisePropertyChanged("start_time"); }
        }

        private string _last_comp_time;
        public string last_comp_time
        {
            get { return _last_comp_time; }
            set { _last_comp_time = value; RaisePropertyChanged("last_comp_time"); }
        }

        private int? _cycle_seq;
        public int? cycle_seq
        {
            get { return _cycle_seq; }
            set { _cycle_seq = value; RaisePropertyChanged("cycle_seq"); }
        }

        private string _obj_no;
        public string obj_no
        {
            get { return _obj_no; }
            set { _obj_no = value; RaisePropertyChanged("obj_no"); }
        }

        private string _start_time_sch;
        public string start_time_sch
        {
            get { return _start_time_sch; }
            set { _start_time_sch = value; RaisePropertyChanged("start_time_sch"); }
        }

        private string _active;
        public string active
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

    }

    public class PMM_T003 : ObjectBase
    {
        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set { _doc_no = value; RaisePropertyChanged("doc_no"); }
        }

        private int? _call_no;
        public int? call_no
        {
            get { return _call_no; }
            set { _call_no = value; RaisePropertyChanged("call_no"); }
        }

        private string _mp_item;
        public string mp_item
        {
            get { return _mp_item; }
            set { _mp_item = value; RaisePropertyChanged("mp_item"); }
        }

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }

        private int? _item_row_id;
        public int? item_row_id
        {
            get { return _item_row_id; }
            set { _item_row_id = value; RaisePropertyChanged("item_row_id"); }
        }

        private string _order_no;
        public string order_no
        {
            get { return _order_no; }
            set { _order_no = value; RaisePropertyChanged("order_no"); }
        }

        private DateTime? _comp_date;
        public DateTime? comp_date
        {
            get { return _comp_date; }
            set { _comp_date = value; RaisePropertyChanged("comp_date"); }
        }

        private string _entry_no;
        public string entry_no
        {
            get { return _entry_no; }
            set { _entry_no = value; RaisePropertyChanged("entry_no"); }
        }

        private string _ind_call;
        public string ind_call
        {
            get { return _ind_call; }
            set { _ind_call = value; RaisePropertyChanged("ind_call"); }
        }

        private string _ind_sch;
        public string ind_sch
        {
            get { return _ind_sch; }
            set { _ind_sch = value; RaisePropertyChanged("ind_sch"); }
        }

        private DateTime? _start_date;
        public DateTime? start_date
        {
            get { return _start_date; }
            set { _start_date = value; RaisePropertyChanged("start_date"); }
        }

        private string _not_no;
        public string not_no
        {
            get { return _not_no; }
            set { _not_no = value; RaisePropertyChanged("not_no"); }
        }

        private string _comp_time;
        public string comp_time
        {
            get { return _comp_time; }
            set { _comp_time = value; RaisePropertyChanged("comp_time"); }
        }

        private string _insp_lot;
        public string insp_lot
        {
            get { return _insp_lot; }
            set { _insp_lot = value; RaisePropertyChanged("insp_lot"); }
        }

        private string _emp_id;
        public string emp_id
        {
            get { return _emp_id; }
            set { _emp_id = value; RaisePropertyChanged("emp_id"); }
        }

    }

    public class PMM_T005 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private string _comp_code { get; set; }
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
        private string _location_id { get; set; }
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
        private string _doc_no { get; set; }
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                if (_doc_no != value)
                {
                    _doc_no = value; RaisePropertyChanged("doc_no");
                }
            }
        }
        private string _doc_cat { get; set; }
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
        private string _doc_type { get; set; }
        public string doc_type
        {
            get { return _doc_type; }
            set
            {
                if (_doc_type != value)
                {
                    _doc_type = value; RaisePropertyChanged("doc_type");
                }
            }
        }
        private DateTime? _doc_date { get; set; }
        public DateTime? doc_date
        {
            get { return _doc_date; }
            set
            {
                if (_doc_date != value)
                {
                    _doc_date = value; RaisePropertyChanged("doc_date");
                }
            }
        }
        private string _mp_no { get; set; }
        public string mp_no
        {
            get { return _mp_no; }
            set
            {
                if (_mp_no != value)
                {
                    _mp_no = value; RaisePropertyChanged("mp_no");
                }
            }
        }
        private DateTime? _record_date { get; set; }
        public DateTime? record_date
        {
            get { return _record_date; }
            set
            {
                if (_record_date != value)
                {
                    _record_date = value; RaisePropertyChanged("record_date");
                }
            }
        }
        private string _record_time { get; set; }
        public string record_time
        {
            get { return _record_time; }
            set
            {
                if (_record_time != value)
                {
                    _record_time = value; RaisePropertyChanged("record_time");
                }
            }
        }
        private string _time_stamp { get; set; }
        public string time_stamp
        {
            get { return _time_stamp; }
            set
            {
                if (_time_stamp != value)
                {
                    _time_stamp = value; RaisePropertyChanged("time_stamp");
                }
            }
        }
        private string _ind_counter { get; set; }
        public string ind_counter
        {
            get { return _ind_counter; }
            set
            {
                if (_ind_counter != value)
                {
                    _ind_counter = value; RaisePropertyChanged("ind_counter");
                }
            }
        }
        private string _short_text { get; set; }
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
        private string _emp_id { get; set; }
        public string emp_id
        {
            get { return _emp_id; }
            set
            {
                if (_emp_id != value)
                {
                    _emp_id = value; RaisePropertyChanged("emp_id");
                }
            }
        }
        private string _emp_name { get; set; }
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
        private string _ind_org { get; set; }
        public string ind_org
        {
            get { return _ind_org; }
            set
            {
                if (_ind_org != value)
                {
                    _ind_org = value; RaisePropertyChanged("ind_org");
                }
            }
        }
        private string _lot_no { get; set; }
        public string lot_no
        {
            get { return _lot_no; }
            set
            {
                if (_lot_no != value)
                {
                    _lot_no = value; RaisePropertyChanged("lot_no");
                }
            }
        }
        private int? _order_node_no { get; set; }
        public int? order_node_no
        {
            get { return _order_node_no; }
            set
            {
                if (_order_node_no != value)
                {
                    _order_node_no = value; RaisePropertyChanged("order_node_no");
                }
            }
        }
        private int? _char_no { get; set; }
        public int? char_no
        {
            get { return _char_no; }
            set
            {
                if (_char_no != value)
                {
                    _char_no = value; RaisePropertyChanged("char_no");
                }
            }
        }
        private string _source_doc { get; set; }
        public string source_doc
        {
            get { return _source_doc; }
            set
            {
                if (_source_doc != value)
                {
                    _source_doc = value; RaisePropertyChanged("source_doc");
                }
            }
        }
        private string _prt_no { get; set; }
        public string prt_no
        {
            get { return _prt_no; }
            set
            {
                if (_prt_no != value)
                {
                    _prt_no = value; RaisePropertyChanged("prt_no");
                }
            }
        }
        private string _obj_no { get; set; }
        public string obj_no
        {
            get { return _obj_no; }
            set
            {
                if (_obj_no != value)
                {
                    _obj_no = value; RaisePropertyChanged("obj_no");
                }
            }
        }
        private double? _read_value { get; set; }
        public double? read_value
        {
            get { return _read_value; }
            set
            {
                if (_read_value != value)
                {
                    _read_value = value; RaisePropertyChanged("read_value", ModelEntityUpdated);
                }
            }
        }
        private string _ind_value { get; set; }
        public string ind_value
        {
            get { return _ind_value; }
            set
            {
                if (_ind_value != value)
                {
                    _ind_value = value; RaisePropertyChanged("ind_value");
                }
            }
        }
        private double? _read_ue { get; set; }
        public double? read_ue
        {
            get { return _read_ue; }
            set
            {
                if (_read_ue != value)
                {
                    _read_ue = value; RaisePropertyChanged("read_ue");
                }
            }
        }
        private string _ind_value1 { get; set; }
        public string ind_value1
        {
            get { return _ind_value1; }
            set
            {
                if (_ind_value1 != value)
                {
                    _ind_value1 = value; RaisePropertyChanged("ind_value1");
                }
            }
        }
        private string _unit_code { get; set; }
        public string unit_code
        {
            get { return _unit_code; }
            set
            {
                if (_unit_code != value)
                {
                    _unit_code = value; RaisePropertyChanged("unit_code");
                }
            }
        }
        private double? _read_counter { get; set; }
        public double? read_counter
        {
            get { return _read_counter; }
            set
            {
                if (_read_counter != value)
                {
                    _read_counter = value; RaisePropertyChanged("read_counter");
                }
            }
        }
        private string _ind_value2 { get; set; }
        public string ind_value2
        {
            get { return _ind_value2; }
            set
            {
                if (_ind_value2 != value)
                {
                    _ind_value2 = value; RaisePropertyChanged("ind_value2");
                }
            }
        }
        private double? _read_diff { get; set; }
        public double? read_diff
        {
            get { return _read_diff; }
            set
            {
                if (_read_diff != value)
                {
                    _read_diff = value; RaisePropertyChanged("read_diff");
                }
            }
        }
        private string _ind_value3 { get; set; }
        public string ind_value3
        {
            get { return _ind_value3; }
            set
            {
                if (_ind_value3 != value)
                {
                    _ind_value3 = value; RaisePropertyChanged("ind_value3");
                }
            }
        }
        private string _ind_diff { get; set; }
        public string ind_diff
        {
            get { return _ind_diff; }
            set
            {
                if (_ind_diff != value)
                {
                    _ind_diff = value; RaisePropertyChanged("ind_diff");
                }
            }
        }
        private string _ind_replace { get; set; }
        public string ind_replace
        {
            get { return _ind_replace; }
            set
            {
                if (_ind_replace != value)
                {
                    _ind_replace = value; RaisePropertyChanged("ind_replace");
                }
            }
        }
        private string _ind_ext { get; set; }
        public string ind_ext
        {
            get { return _ind_ext; }
            set
            {
                if (_ind_ext != value)
                {
                    _ind_ext = value; RaisePropertyChanged("ind_ext");
                }
            }
        }
        private string _cat_type { get; set; }
        public string cat_type
        {
            get { return _cat_type; }
            set
            {
                if (_cat_type != value)
                {
                    _cat_type = value; RaisePropertyChanged("cat_type");
                }
            }
        }
        private string _cat_group { get; set; }
        public string cat_group
        {
            get { return _cat_group; }
            set
            {
                if (_cat_group != value)
                {
                    _cat_group = value; RaisePropertyChanged("cat_group");
                }
            }
        }
        private string _value_code { get; set; }
        public string value_code
        {
            get { return _value_code; }
            set
            {
                if (_value_code != value)
                {
                    _value_code = value; RaisePropertyChanged("value_code");
                }
            }
        }
        private string _ver_no { get; set; }
        public string ver_no
        {
            get { return _ver_no; }
            set
            {
                if (_ver_no != value)
                {
                    _ver_no = value; RaisePropertyChanged("ver_no");
                }
            }
        }
        private string _ind_rev { get; set; }
        public string ind_rev
        {
            get { return _ind_rev; }
            set
            {
                if (_ind_rev != value)
                {
                    _ind_rev = value; RaisePropertyChanged("ind_rev");
                }
            }
        }
        private string _obj_no_order { get; set; }
        public string obj_no_order
        {
            get { return _obj_no_order; }
            set
            {
                if (_obj_no_order != value)
                {
                    _obj_no_order = value; RaisePropertyChanged("obj_no_order");
                }
            }
        }
        private string _part_sample_no { get; set; }
        public string part_sample_no
        {
            get { return _part_sample_no; }
            set
            {
                if (_part_sample_no != value)
                {
                    _part_sample_no = value; RaisePropertyChanged("part_sample_no");
                }
            }
        }
        private string _result_val { get; set; }
        public string result_val
        {
            get { return _result_val; }
            set
            {
                if (_result_val != value)
                {
                    _result_val = value; RaisePropertyChanged("result_val");
                }
            }
        }
        private string _ind_time { get; set; }
        public string ind_time
        {
            get { return _ind_time; }
            set
            {
                if (_ind_time != value)
                {
                    _ind_time = value; RaisePropertyChanged("ind_time");
                }
            }
        }
        private DateTime? _int_date { get; set; }
        public DateTime? int_date
        {
            get { return _int_date; }
            set
            {
                if (_int_date != value)
                {
                    _int_date = value; RaisePropertyChanged("int_date");
                }
            }
        }
        private string _int_time { get; set; }
        public string int_time
        {
            get { return _int_time; }
            set
            {
                if (_int_time != value)
                {
                    _int_time = value; RaisePropertyChanged("int_time");
                }
            }
        }
        private decimal? _time_stamp_d { get; set; }
        public decimal? time_stamp_d
        {
            get { return _time_stamp_d; }
            set
            {
                if (_time_stamp_d != value)
                {
                    _time_stamp_d = value; RaisePropertyChanged("time_stamp_d");
                }
            }
        }
        private string _active { get; set; }
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
        private string _t_status { get; set; }
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
        private string _source { get; set; }
        public string source
        {
            get { return _source; }
            set
            {
                if (_source != value)
                {
                    _source = value; RaisePropertyChanged("source");
                }
            }
        }
        private string _destination { get; set; }
        public string destination
        {
            get { return _destination; }
            set
            {
                if (_destination != value)
                {
                    _destination = value; RaisePropertyChanged("destination");
                }
            }
        }
        private string _from_date { get; set; }
        public string from_date
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
        private string _to_date { get; set; }
        public string to_date
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
        private string _start_time { get; set; }
        public string start_time
        {
            get { return _start_time; }
            set
            {
                if (_start_time != value)
                {
                    _start_time = value; RaisePropertyChanged("start_time");
                }
            }
        }
        private string _end_time { get; set; }
        public string end_time
        {
            get { return _end_time; }
            set
            {
                if (_end_time != value)
                {
                    _end_time = value; RaisePropertyChanged("end_time");
                }
            }
        }

        //Scalar
        private string _mp_name { get; set; }
        public string mp_name
        {
            get { return _mp_name; }
            set
            {
                if (_mp_name != value)
                {
                    _mp_name = value; RaisePropertyChanged("mp_name");
                }
            }
        }
        private string _pos_no { get; set; }
        public string pos_no
        {
            get { return _pos_no; }
            set
            {
                if (_pos_no != value)
                {
                    _pos_no = value; RaisePropertyChanged("pos_no");
                }
            }
        }
        private string _obj_name { get; set; }
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
        private string _char_name { get; set; }
        public string char_name
        {
            get { return _char_name; }
            set
            {
                if (_char_name != value)
                {
                    _char_name = value; RaisePropertyChanged("char_name");
                }
            }
        }
        private string _char_unit { get; set; }
        public string char_unit
        {
            get { return _char_unit; }
            set
            {
                if (_char_unit != value)
                {
                    _char_unit = value; RaisePropertyChanged("char_unit");
                }
            }
        }
        private string _long_text { get; set; }
        public string long_text
        {
            get { return _long_text; }
            set
            {
                if (_long_text != value)
                {
                    _long_text = value; RaisePropertyChanged("long_text");
                }
            }
        }
        private string _mp_cat { get; set; }
        public string mp_cat
        {
            get { return _mp_cat; }
            set
            {
                if (_mp_cat != value)
                {
                    _mp_cat = value; RaisePropertyChanged("mp_cat");
                }
            }
        }
        private string _cat_name { get; set; }
        public string cat_name
        {
            get { return _cat_name; }
            set
            {
                if (_cat_name != value)
                {
                    _cat_name = value; RaisePropertyChanged("cat_name");
                }
            }
        }
        private double? _target_value { get; set; }
        public double? target_value
        {
            get { return _target_value; }
            set
            {
                if (_target_value != value)
                {
                    _target_value = value; RaisePropertyChanged("target_value");
                }
            }
        }
        private double? _previous_value { get; set; }
        public double? previous_value
        {
            get { return _previous_value; }
            set
            {
                if (_previous_value != value)
                {
                    _previous_value = value; RaisePropertyChanged("previous_value", ModelEntityUpdated);
                }
            }
        }
        public string XDOC_A { get; set; }

    }





    public class MC_PMM_T001_BE : MC_PMM_BE
    {
        public List<PMM_T001> MasterEntity { get; set; }
        public ObservableCollection<PMM_T001_A> ItemsEntity { get; set; }
        public ObservableCollection<PMM_T001_B> CycleEntity { get; set; }
        public ObservableCollection<PMM_T002> ScheduleEntity { get; set; }
        public ObservableCollection<PMM_T003> CallObjectEntity { get; set; }

    }
}
