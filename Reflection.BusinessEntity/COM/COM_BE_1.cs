using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessEntity.COM
{
    public class COM_T001 : ObjectBase
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

        private string _not_type;
        public string not_type
        {
            get { return _not_type; }
            set { _not_type = value; RaisePropertyChanged("not_type"); }
        }

        private string _short_text;
        public string short_text
        {
            get { return _short_text; }
            set { _short_text = value; RaisePropertyChanged("short_text"); }
        }

        private string _pri_code;
        public string pri_code
        {
            get { return _pri_code; }
            set { _pri_code = value; RaisePropertyChanged("pri_code"); }
        }

        private DateTime? _not_date;
        public DateTime? not_date
        {
            get { return _not_date; }
            set { _not_date = value; RaisePropertyChanged("not_date"); }
        }

        private TimeSpan? _note_time;
        public TimeSpan? note_time
        {
            get { return _note_time; }
            set { _note_time = value; RaisePropertyChanged("note_time"); }
        }

        private string _emp_id;
        public string emp_id
        {
            get { return _emp_id; }
            set { _emp_id = value; RaisePropertyChanged("emp_id"); }
        }

        private string _emp_name;
        public string emp_name
        {
            get { return _emp_name; }
            set { _emp_name = value; RaisePropertyChanged("emp_name"); }
        }

        private DateTime? _start_date;
        public DateTime? start_date
        {
            get { return _start_date; }
            set { _start_date = value; RaisePropertyChanged("start_date"); }
        }

        private TimeSpan? _start_time;
        public TimeSpan? start_time
        {
            get { return _start_time; }
            set { _start_time = value; RaisePropertyChanged("start_time"); }
        }

        private DateTime? _end_date;
        public DateTime? end_date
        {
            get { return _end_date; }
            set { _end_date = value; RaisePropertyChanged("end_date"); }
        }

        private TimeSpan? _end_time;
        public TimeSpan? end_time
        {
            get { return _end_time; }
            set { _end_time = value; RaisePropertyChanged("end_time"); }
        }

        private string _curr_code;
        public string curr_code
        {
            get { return _curr_code; }
            set { _curr_code = value; RaisePropertyChanged("curr_code"); }
        }

        private string _order_no;
        public string order_no
        {
            get { return _order_no; }
            set { _order_no = value; RaisePropertyChanged("order_no"); }
        }

        private string _item_code;
        public string item_code
        {
            get { return _item_code; }
            set { _item_code = value; RaisePropertyChanged("item_code"); }
        }

        private string _ppc_plant;
        public string ppc_plant
        {
            get { return _ppc_plant; }
            set { _ppc_plant = value; RaisePropertyChanged("ppc_plant"); }
        }

        private string _party_code;
        public string party_code
        {
            get { return _party_code; }
            set { _party_code = value; RaisePropertyChanged("party_code"); }
        }

        private string _party_code2;
        public string party_code2
        {
            get { return _party_code2; }
            set { _party_code2 = value; RaisePropertyChanged("party_code2"); }
        }

        private DateTime? _ref_date;
        public DateTime? ref_date
        {
            get { return _ref_date; }
            set { _ref_date = value; RaisePropertyChanged("ref_date"); }
        }

        private string _ref_no;
        public string ref_no
        {
            get { return _ref_no; }
            set { _ref_no = value; RaisePropertyChanged("ref_no"); }
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

        private string _po_no;
        public string po_no
        {
            get { return _po_no; }
            set { _po_no = value; RaisePropertyChanged("po_no"); }
        }

        private int? _po_item_row_id;
        public int? po_item_row_id
        {
            get { return _po_item_row_id; }
            set { _po_item_row_id = value; RaisePropertyChanged("po_item_row_id"); }
        }

        private string _item_plant;
        public string item_plant
        {
            get { return _item_plant; }
            set { _item_plant = value; RaisePropertyChanged("item_plant"); }
        }

        private string _lot_no;
        public string lot_no
        {
            get { return _lot_no; }
            set { _lot_no = value; RaisePropertyChanged("lot_no"); }
        }

        private string _batch_no;
        public string batch_no
        {
            get { return _batch_no; }
            set { _batch_no = value; RaisePropertyChanged("batch_no"); }
        }

        private string _store_code;
        public string store_code
        {
            get { return _store_code; }
            set { _store_code = value; RaisePropertyChanged("store_code"); }
        }

        private string _batch_no_party;
        public string batch_no_party
        {
            get { return _batch_no_party; }
            set { _batch_no_party = value; RaisePropertyChanged("batch_no_party"); }
        }

        private string _doc_no_ppc;
        public string doc_no_ppc
        {
            get { return _doc_no_ppc; }
            set { _doc_no_ppc = value; RaisePropertyChanged("doc_no_ppc"); }
        }

        private string _doc_no_dn;
        public string doc_no_dn
        {
            get { return _doc_no_dn; }
            set { _doc_no_dn = value; RaisePropertyChanged("doc_no_dn"); }
        }

        private int? _item_row_id_dn;
        public int? item_row_id_dn
        {
            get { return _item_row_id_dn; }
            set { _item_row_id_dn = value; RaisePropertyChanged("item_row_id_dn"); }
        }

        private string _obj_type;
        public string obj_type
        {
            get { return _obj_type; }
            set { _obj_type = value; RaisePropertyChanged("obj_type"); }
        }

        private string _obj_no;
        public string obj_no
        {
            get { return _obj_no; }
            set { _obj_no = value; RaisePropertyChanged("obj_no"); }
        }

        private DateTime? _cloase_date;
        public DateTime? cloase_date
        {
            get { return _cloase_date; }
            set { _cloase_date = value; RaisePropertyChanged("cloase_date"); }
        }

        private string _close_time;
        public string close_time
        {
            get { return _close_time; }
            set { _close_time = value; RaisePropertyChanged("close_time"); }
        }

        private string _wc_plant;
        public string wc_plant
        {
            get { return _wc_plant; }
            set { _wc_plant = value; RaisePropertyChanged("wc_plant"); }
        }

        private string _wc_obj_code;
        public string wc_obj_code
        {
            get { return _wc_obj_code; }
            set { _wc_obj_code = value; RaisePropertyChanged("wc_obj_code"); }
        }

        private int? _order_counter;
        public int? order_counter
        {
            get { return _order_counter; }
            set { _order_counter = value; RaisePropertyChanged("order_counter"); }
        }

        private decimal _qty_internal;
        public decimal qty_internal
        {
            get { return _qty_internal; }
            set { _qty_internal = value; RaisePropertyChanged("qty_internal"); }
        }

        private decimal _qty_external;
        public decimal qty_external
        {
            get { return _qty_external; }
            set { _qty_external = value; RaisePropertyChanged("qty_external"); }
        }

        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code"); }
        }

        private decimal _qty_complaint;
        public decimal qty_complaint
        {
            get { return _qty_complaint; }
            set { _qty_complaint = value; RaisePropertyChanged("qty_complaint"); }
        }

        private decimal _qty_return;
        public decimal qty_return
        {
            get { return _qty_return; }
            set { _qty_return = value; RaisePropertyChanged("qty_return"); }
        }

        private DateTime? _return_date;
        public DateTime? return_date
        {
            get { return _return_date; }
            set { _return_date = value; RaisePropertyChanged("return_date"); }
        }

        private string _serail_no;
        public string serail_no
        {
            get { return _serail_no; }
            set { _serail_no = value; RaisePropertyChanged("serail_no"); }
        }

        private string _equip_no;
        public string equip_no
        {
            get { return _equip_no; }
            set { _equip_no = value; RaisePropertyChanged("equip_no"); }
        }

        private string _equip_master;
        public string equip_master
        {
            get { return _equip_master; }
            set { _equip_master = value; RaisePropertyChanged("equip_master"); }
        }

        private string _floc_no;
        public string floc_no
        {
            get { return _floc_no; }
            set { _floc_no = value; RaisePropertyChanged("floc_no"); }
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

        private string _not_org;
        public string not_org
        {
            get { return _not_org; }
            set { _not_org = value; RaisePropertyChanged("not_org"); }
        }

        private string _ref_doc_cat;
        public string ref_doc_cat
        {
            get { return _ref_doc_cat; }
            set { _ref_doc_cat = value; RaisePropertyChanged("ref_doc_cat"); }
        }

        private string _ref_doc_no;
        public string ref_doc_no
        {
            get { return _ref_doc_no; }
            set { _ref_doc_no = value; RaisePropertyChanged("ref_doc_no"); }
        }

        private string _catlog_type;
        public string catlog_type
        {
            get { return _catlog_type; }
            set { _catlog_type = value; RaisePropertyChanged("catlog_type"); }
        }

        private string _code_group;
        public string code_group
        {
            get { return _code_group; }
            set { _code_group = value; RaisePropertyChanged("code_group"); }
        }

        //private string _value_code;
        //public string value_code
        //{
        //    get { return _value_code; }
        //    set { _value_code = value; RaisePropertyChanged("value_code"); }
        //}

        private string _ver_no;
        public string ver_no
        {
            get { return _ver_no; }
            set { _ver_no = value; RaisePropertyChanged("ver_no"); }
        }

        private string _so_code;
        public string so_code
        {
            get { return _so_code; }
            set { _so_code = value; RaisePropertyChanged("so_code"); }
        }

        private string _sg_code;
        public string sg_code
        {
            get { return _sg_code; }
            set { _sg_code = value; RaisePropertyChanged("sg_code"); }
        }

        private string _po_code;
        public string po_code
        {
            get { return _po_code; }
            set { _po_code = value; RaisePropertyChanged("po_code"); }
        }

        private string _pg_code;
        public string pg_code
        {
            get { return _pg_code; }
            set { _pg_code = value; RaisePropertyChanged("pg_code"); }
        }

        private string _mm_doc_no;
        public string mm_doc_no
        {
            get { return _mm_doc_no; }
            set { _mm_doc_no = value; RaisePropertyChanged("mm_doc_no"); }
        }

        private int? _mm_item_row_id;
        public int? mm_item_row_id
        {
            get { return _mm_item_row_id; }
            set { _mm_item_row_id = value; RaisePropertyChanged("mm_item_row_id"); }
        }

        private string _delivery_no;
        public string delivery_no
        {
            get { return _delivery_no; }
            set { _delivery_no = value; RaisePropertyChanged("delivery_no"); }
        }

        private int? _del_item_row_id;
        public int? del_item_row_id
        {
            get { return _del_item_row_id; }
            set { _del_item_row_id = value; RaisePropertyChanged("del_item_row_id"); }
        }

        private int? _node_no;
        public int? node_no
        {
            get { return _node_no; }
            set { _node_no = value; RaisePropertyChanged("node_no"); }
        }

        private string _ref_not_no;
        public string ref_not_no
        {
            get { return _ref_not_no; }
            set { _ref_not_no = value; RaisePropertyChanged("ref_not_no"); }
        }

        private string _ext_ref_no;
        public string ext_ref_no
        {
            get { return _ext_ref_no; }
            set { _ext_ref_no = value; RaisePropertyChanged("ext_ref_no"); }
        }

        private string _item_code_c;
        public string item_code_c
        {
            get { return _item_code_c; }
            set { _item_code_c = value; RaisePropertyChanged("item_code_c"); }
        }

        private string _item_code_v;
        public string item_code_v
        {
            get { return _item_code_v; }
            set { _item_code_v = value; RaisePropertyChanged("item_code_v"); }
        }

        private DateTime? _prod_date;
        public DateTime? prod_date
        {
            get { return _prod_date; }
            set { _prod_date = value; RaisePropertyChanged("prod_date"); }
        }

        private string _qm_doc_no;
        public string qm_doc_no
        {
            get { return _qm_doc_no; }
            set { _qm_doc_no = value; RaisePropertyChanged("qm_doc_no"); }
        }

        private string _pm_doc_no;
        public string pm_doc_no
        {
            get { return _pm_doc_no; }
            set { _pm_doc_no = value; RaisePropertyChanged("pm_doc_no"); }
        }

        private int? _int_counter;
        public int? int_counter
        {
            get { return _int_counter; }
            set { _int_counter = value; RaisePropertyChanged("int_counter"); }
        }

        private string _element_id;
        public string element_id
        {
            get { return _element_id; }
            set { _element_id = value; RaisePropertyChanged("element_id"); }
        }

        private string _fun_loc;
        public string fun_loc
        {
            get { return _fun_loc; }
            set { _fun_loc = value; RaisePropertyChanged("fun_loc"); }
        }

        private string _unique_id;
        public string unique_id
        {
            get { return _unique_id; }
            set { _unique_id = value; RaisePropertyChanged("unique_id"); }
        }

        private decimal _cost_estimate;
        public decimal cost_estimate
        {
            get { return _cost_estimate; }
            set { _cost_estimate = value; RaisePropertyChanged("cost_estimate"); }
        }

        private decimal _cost_claimed;
        public decimal cost_claimed
        {
            get { return _cost_claimed; }
            set { _cost_claimed = value; RaisePropertyChanged("cost_claimed"); }
        }

        private decimal _cost_accepted;
        public decimal cost_accepted
        {
            get { return _cost_accepted; }
            set { _cost_accepted = value; RaisePropertyChanged("cost_accepted"); }
        }
        private string _emp_id_res;
        public string emp_id_res
        {
            get { return _emp_id_res; }
            set { _emp_id_res = value; RaisePropertyChanged("emp_id_res"); }
        }

        //Scalar Fields

        private string _long_text;
        public string long_text
        {
            get { return _long_text; }
            set { _long_text = value; RaisePropertyChanged("long_text"); }
        }

        private string _t_display;
        public string t_display
        {
            get { return _t_display; }
            set { _t_display = value; RaisePropertyChanged("t_display"); }
        }
        public string XDOC_A { get; set; }
        public string XDOC_B { get; set; }
        public string XDOC_C { get; set; }
        public string XDOC_D { get; set; }
        public string XDOC_E { get; set; }

        private string _emp_name_res;
        public string emp_name_res
        {
            get { return _emp_name_res; }
            set { _emp_name_res = value; RaisePropertyChanged("emp_name_res"); }
        }
        private string _not_type_name;
        public string not_type_name
        {
            get { return _not_type_name; }
            set { _not_type_name = value; RaisePropertyChanged("not_type_name"); }
        }
        private string _equip_name;
        public string equip_name
        {
            get { return _equip_name; }
            set { _equip_name = value; RaisePropertyChanged("equip_name"); }
        }
        private string _obj_name;
        public string obj_name
        {
            get { return _obj_name; }
            set { _obj_name = value; RaisePropertyChanged("obj_name"); }
        }
        public string email_res { get; set; }
        public string doc_type_name { get; set; }

        public string manufacturer { get; set; }
        public string model { get; set; }
        public string serial_no { get; set; }
        public string range { get; set; }
        public string accuracy { get; set; }
        public string asset_status { get; set; }
        public string repair_by { get; set; }
        public DateTime? repair_plan_dt { get; set; }
        public DateTime? repair_dt { get; set; }
    }
    public class COM_T001_A : ObjectBase
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

        private string _catlog_type;
        public string catlog_type
        {
            get { return _catlog_type; }
            set { _catlog_type = value; RaisePropertyChanged("catlog_type"); }
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

        private string _ver_no;
        public string ver_no
        {
            get { return _ver_no; }
            set { _ver_no = value; RaisePropertyChanged("ver_no"); }
        }

        private string _catlog_type_obj;
        public string catlog_type_obj
        {
            get { return _catlog_type_obj; }
            set { _catlog_type_obj = value; RaisePropertyChanged("catlog_type_obj"); }
        }

        private string _code_group_obj;
        public string code_group_obj
        {
            get { return _code_group_obj; }
            set { _code_group_obj = value; RaisePropertyChanged("code_group_obj"); }
        }

        private string _value_code_obj;
        public string value_code_obj
        {
            get { return _value_code_obj; }
            set { _value_code_obj = value; RaisePropertyChanged("value_code_obj"); }
        }

        private string _assembly_code;
        public string assembly_code
        {
            get { return _assembly_code; }
            set { _assembly_code = value; RaisePropertyChanged("assembly_code"); }
        }

        private string _ind_org;
        public string ind_org
        {
            get { return _ind_org; }
            set { _ind_org = value; RaisePropertyChanged("ind_org"); }
        }

        private string _ind_repet;
        public string ind_repet
        {
            get { return _ind_repet; }
            set { _ind_repet = value; RaisePropertyChanged("ind_repet"); }
        }

        private string _defect_code;
        public string defect_code
        {
            get { return _defect_code; }
            set { _defect_code = value; RaisePropertyChanged("defect_code"); }
        }

        private string _defect_class;
        public string defect_class
        {
            get { return _defect_class; }
            set { _defect_class = value; RaisePropertyChanged("defect_class"); }
        }

        private string _order_no;
        public string order_no
        {
            get { return _order_no; }
            set { _order_no = value; RaisePropertyChanged("order_no"); }
        }

        private decimal _qty_external;
        public decimal qty_external
        {
            get { return _qty_external; }
            set { _qty_external = value; RaisePropertyChanged("qty_external"); }
        }

        private decimal _qty_internal;
        public decimal qty_internal
        {
            get { return _qty_internal; }
            set { _qty_internal = value; RaisePropertyChanged("qty_internal"); }
        }

        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code"); }
        }

        private int? _defect_no;
        public int? defect_no
        {
            get { return _defect_no; }
            set { _defect_no = value; RaisePropertyChanged("defect_no"); }
        }

        private double? _defect_val;
        public double? defect_val
        {
            get { return _defect_val; }
            set { _defect_val = value; RaisePropertyChanged("defect_val"); }
        }

        private string _val_unit;
        public string val_unit
        {
            get { return _val_unit; }
            set { _val_unit = value; RaisePropertyChanged("val_unit"); }
        }

        private int? _node_no;
        public int? node_no
        {
            get { return _node_no; }
            set { _node_no = value; RaisePropertyChanged("node_no"); }
        }

        private int? _char_no;
        public int? char_no
        {
            get { return _char_no; }
            set { _char_no = value; RaisePropertyChanged("char_no"); }
        }

        private string _char_code;
        public string char_code
        {
            get { return _char_code; }
            set { _char_code = value; RaisePropertyChanged("char_code"); }
        }

        private int? _sample_no;
        public int? sample_no
        {
            get { return _sample_no; }
            set { _sample_no = value; RaisePropertyChanged("sample_no"); }
        }

        private string _phy_sample_no;
        public string phy_sample_no
        {
            get { return _phy_sample_no; }
            set { _phy_sample_no = value; RaisePropertyChanged("phy_sample_no"); }
        }

        private string _unit_no;
        public string unit_no
        {
            get { return _unit_no; }
            set { _unit_no = value; RaisePropertyChanged("unit_no"); }
        }

        private string _wc_obj_code;
        public string wc_obj_code
        {
            get { return _wc_obj_code; }
            set { _wc_obj_code = value; RaisePropertyChanged("wc_obj_code"); }
        }

        private string _wc_plant;
        public string wc_plant
        {
            get { return _wc_plant; }
            set { _wc_plant = value; RaisePropertyChanged("wc_plant"); }
        }

        private int? _org_item;
        public int? org_item
        {
            get { return _org_item; }
            set { _org_item = value; RaisePropertyChanged("org_item"); }
        }

        private string _item_code;
        public string item_code
        {
            get { return _item_code; }
            set { _item_code = value; RaisePropertyChanged("item_code"); }
        }

        private string _po_code;
        public string po_code
        {
            get { return _po_code; }
            set { _po_code = value; RaisePropertyChanged("po_code"); }
        }

        private string _pur_doc_no;
        public string pur_doc_no
        {
            get { return _pur_doc_no; }
            set { _pur_doc_no = value; RaisePropertyChanged("pur_doc_no"); }
        }

        private string _cc_code;
        public string cc_code
        {
            get { return _cc_code; }
            set { _cc_code = value; RaisePropertyChanged("cc_code"); }
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
    public class COM_T001_B : ObjectBase
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

        private int? _line_id;
        public int? line_id
        {
            get { return _line_id; }
            set { _line_id = value; RaisePropertyChanged("line_id"); }
        }

        private int? _item_row_id;
        public int? item_row_id
        {
            get { return _item_row_id; }
            set { _item_row_id = value; RaisePropertyChanged("item_row_id"); }
        }

        private int? _seq_no;
        public int? seq_no
        {
            get { return _seq_no; }
            set { _seq_no = value; RaisePropertyChanged("seq_no"); }
        }

        private string _catlog_type;
        public string catlog_type
        {
            get { return _catlog_type; }
            set { _catlog_type = value; RaisePropertyChanged("catlog_type"); }
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

        private string _ver_no;
        public string ver_no
        {
            get { return _ver_no; }
            set { _ver_no = value; RaisePropertyChanged("ver_no"); }
        }

        private string _short_text;
        public string short_text
        {
            get { return _short_text; }
            set { _short_text = value; RaisePropertyChanged("short_text"); }
        }

        private string _follow_act;
        public string follow_act
        {
            get { return _follow_act; }
            set { _follow_act = value; RaisePropertyChanged("follow_act"); }
        }

        private string _obj_no;
        public string obj_no
        {
            get { return _obj_no; }
            set { _obj_no = value; RaisePropertyChanged("obj_no"); }
        }

        private string _ind_log;
        public string ind_log
        {
            get { return _ind_log; }
            set { _ind_log = value; RaisePropertyChanged("ind_log"); }
        }

        private DateTime? _start_date;
        public DateTime? start_date
        {
            get { return _start_date; }
            set { _start_date = value; RaisePropertyChanged("start_date"); }
        }

        private DateTime? _end_date;
        public DateTime? end_date
        {
            get { return _end_date; }
            set { _end_date = value; RaisePropertyChanged("end_date"); }
        }

        private string _obj_name;
        public string obj_name
        {
            get { return _obj_name; }
            set { _obj_name = value; RaisePropertyChanged("obj_name"); }
        }

        private string _start_time;
        public string start_time
        {
            get { return _start_time; }
            set { _start_time = value; RaisePropertyChanged("start_time"); }
        }

        private string _end_time;
        public string end_time
        {
            get { return _end_time; }
            set { _end_time = value; RaisePropertyChanged("end_time"); }
        }

        private string _emp_id;
        public string emp_id
        {
            get { return _emp_id; }
            set { _emp_id = value; RaisePropertyChanged("emp_id"); }
        }

        private string _emp_name;
        public string emp_name
        {
            get { return _emp_name; }
            set { _emp_name = value; RaisePropertyChanged("emp_name"); }
        }

        private DateTime? _comp_date;
        public DateTime? comp_date
        {
            get { return _comp_date; }
            set { _comp_date = value; RaisePropertyChanged("comp_date"); }
        }

        private string _comp_time;
        public string comp_time
        {
            get { return _comp_time; }
            set { _comp_time = value; RaisePropertyChanged("comp_time"); }
        }

        private DateTime? _resubmit_date;
        public DateTime? resubmit_date
        {
            get { return _resubmit_date; }
            set { _resubmit_date = value; RaisePropertyChanged("resubmit_date"); }
        }

        private int? _item_no;
        public int? item_no
        {
            get { return _item_no; }
            set { _item_no = value; RaisePropertyChanged("item_no"); }
        }

        private int? _seq_no_cause;
        public int? seq_no_cause
        {
            get { return _seq_no_cause; }
            set { _seq_no_cause = value; RaisePropertyChanged("seq_no_cause"); }
        }

        private string _pf_code;
        public string pf_code
        {
            get { return _pf_code; }
            set { _pf_code = value; RaisePropertyChanged("pf_code"); }
        }

        private string _party_code;
        public string party_code
        {
            get { return _party_code; }
            set { _party_code = value; RaisePropertyChanged("party_code"); }
        }

        private string _cp_code;
        public string cp_code
        {
            get { return _cp_code; }
            set { _cp_code = value; RaisePropertyChanged("cp_code"); }
        }

        private string _cp_name;
        public string cp_name
        {
            get { return _cp_name; }
            set { _cp_name = value; RaisePropertyChanged("cp_name"); }
        }

        private decimal _qty;
        public decimal qty
        {
            get { return _qty; }
            set { _qty = value; RaisePropertyChanged("qty"); }
        }

        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code"); }
        }

        private string _assembly_code;
        public string assembly_code
        {
            get { return _assembly_code; }
            set { _assembly_code = value; RaisePropertyChanged("assembly_code"); }
        }

        private int? _sort_no;
        public int? sort_no
        {
            get { return _sort_no; }
            set { _sort_no = value; RaisePropertyChanged("sort_no"); }
        }

        private string _unique_id;
        public string unique_id
        {
            get { return _unique_id; }
            set { _unique_id = value; RaisePropertyChanged("unique_id"); }
        }

        private string _time_zone;
        public string time_zone
        {
            get { return _time_zone; }
            set { _time_zone = value; RaisePropertyChanged("time_zone"); }
        }

        private string _time_zone_task;
        public string time_zone_task
        {
            get { return _time_zone_task; }
            set { _time_zone_task = value; RaisePropertyChanged("time_zone_task"); }
        }

        private DateTime? _time_stamp;
        public DateTime? time_stamp
        {
            get { return _time_stamp; }
            set { _time_stamp = value; RaisePropertyChanged("time_stamp"); }
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
    public class COM_T001_C : ObjectBase
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

        private int? _act_no;
        public int? act_no
        {
            get { return _act_no; }
            set { _act_no = value; RaisePropertyChanged("act_no"); }
        }

        private int? _line_id;
        public int? line_id
        {
            get { return _line_id; }
            set { _line_id = value; RaisePropertyChanged("line_id"); }
        }

        private int? _item_row_id;
        public int? item_row_id
        {
            get { return _item_row_id; }
            set { _item_row_id = value; RaisePropertyChanged("item_row_id"); }
        }

        private int? _seq_no;
        public int? seq_no
        {
            get { return _seq_no; }
            set { _seq_no = value; RaisePropertyChanged("seq_no"); }
        }

        private string _catlog_type;
        public string catlog_type
        {
            get { return _catlog_type; }
            set { _catlog_type = value; RaisePropertyChanged("catlog_type"); }
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

        private string _ver_no;
        public string ver_no
        {
            get { return _ver_no; }
            set { _ver_no = value; RaisePropertyChanged("ver_no"); }
        }

        private string _short_text;
        public string short_text
        {
            get { return _short_text; }
            set { _short_text = value; RaisePropertyChanged("short_text"); }
        }

        private string _task_class;
        public string task_class
        {
            get { return _task_class; }
            set { _task_class = value; RaisePropertyChanged("task_class"); }
        }

        private string _ind_class;
        public string ind_class
        {
            get { return _ind_class; }
            set { _ind_class = value; RaisePropertyChanged("ind_class"); }
        }

        private DateTime? _start_date;
        public DateTime? start_date
        {
            get { return _start_date; }
            set { _start_date = value; RaisePropertyChanged("start_date"); }
        }

        private DateTime? _end_date;
        public DateTime? end_date
        {
            get { return _end_date; }
            set { _end_date = value; RaisePropertyChanged("end_date"); }
        }

        private string _start_time;
        public string start_time
        {
            get { return _start_time; }
            set { _start_time = value; RaisePropertyChanged("start_time"); }
        }

        private string _end_time;
        public string end_time
        {
            get { return _end_time; }
            set { _end_time = value; RaisePropertyChanged("end_time"); }
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


    

    public class MC_COM_T001_BE : MC_COM_BE
    {
        public List<COM_T001> MasterEntity { get; set; }
        public ObservableCollection<COM_T001_A> ItemsEntity { get; set; }
        public ObservableCollection<COM_T001_B> TaskEntity { get; set; }
        public ObservableCollection<COM_T001_C> ActivityEntity { get; set; }

    }


    public class COM_T011 : ObjectBase
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

        private int? _auth_level;
        public int? auth_level
        {
            get { return _auth_level; }
            set { _auth_level = value; RaisePropertyChanged("auth_level"); }
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

        private string _doc_no_wf;
        public string doc_no_wf
        {
            get { return _doc_no_wf; }
            set { _doc_no_wf = value; RaisePropertyChanged("doc_no_wf"); }
        }

        private string _short_text;
        public string short_text
        {
            get { return _short_text; }
            set { _short_text = value; RaisePropertyChanged("short_text"); }
        }

        private string _pr_code;
        public string pr_code
        {
            get { return _pr_code; }
            set { _pr_code = value; RaisePropertyChanged("pr_code"); }
        }
        private string _obj_type;
        public string obj_type
        {
            get { return _obj_type; }
            set { _obj_type = value; RaisePropertyChanged("obj_type"); }
        }

        private string _obj_no;
        public string obj_no
        {
            get { return _obj_no; }
            set { _obj_no = value; RaisePropertyChanged("obj_no"); }
        }
        //private string _userid;
        //public string userid
        //{
        //    get { return _userid; }
        //    set { _userid = value; RaisePropertyChanged("userid"); }
        //}
        private string _creator;
        public string creator
        {
            get { return _creator; }
            set { _creator = value; RaisePropertyChanged("creator"); }
        }
        private string _sender;
        public string sender
        {
            get { return _sender; }
            set { _sender = value; RaisePropertyChanged("sender"); }
        }
        private DateTime? _rec_date;
        public DateTime? rec_date
        {
            get { return _rec_date; }
            set { _rec_date = value; RaisePropertyChanged("rec_date"); }
        }
        private string _rec_type;
        public string rec_type
        {
            get { return _rec_type; }
            set { _rec_type = value; RaisePropertyChanged("rec_type"); }
        }
        private string _rec_status;
        public string rec_status
        {
            get { return _rec_status; }
            set { _rec_status = value; RaisePropertyChanged("rec_status"); }
        }
        private DateTime? _read_date;
        public DateTime? read_date
        {
            get { return _read_date; }
            set { _read_date = value; RaisePropertyChanged("read_date"); }
        }
        private DateTime? _act_date;
        public DateTime? act_date
        {
            get { return _act_date; }
            set { _act_date = value; RaisePropertyChanged("act_date"); }
        }
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }
        }
        private string _notes;
        public string notes
        {
            get { return _notes; }
            set { _notes = value; RaisePropertyChanged("notes"); }
        }
        private string _feedback;
        public string feedback
        {
            get { return _feedback; }
            set { _feedback = value; RaisePropertyChanged("feedback"); }
        }
        private string _auth_type;
        public string auth_type
        {
            get { return _auth_type; }
            set { _auth_type = value; RaisePropertyChanged("auth_type"); }
        }



        //Scalar Fields

        private string _emp_id;
        public string emp_id
        {
            get { return _emp_id; }
            set { _emp_id = value; RaisePropertyChanged("emp_id"); }
        }

        private string _emp_name;
        public string emp_name
        {
            get { return _emp_name; }
            set { _emp_name = value; RaisePropertyChanged("emp_name"); }
        }

        private string _t_display;
        public string t_display
        {
            get { return _t_display; }
            set { _t_display = value; RaisePropertyChanged("t_display"); }
        }

        private string _ceator_name;
        public string ceator_name
        {
            get { return _ceator_name; }
            set { _ceator_name = value; RaisePropertyChanged("ceator_name"); }
        }

    }
    public class MC_COM_T011_BE : MC_COM_BE
    {
        public ObservableCollection<COM_T011> MasterList { get; set; }

    }
}
