using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Reflection.BusinessEntity.ReflectionSystem;

namespace Reflection.BusinessEntity
{
    public class EPR_T003_A : ObjectBase
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

        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                _doc_no = value;
                RaisePropertyChanged("doc_no");
            }
        }

        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set
            {
                _doc_type = value;
                RaisePropertyChanged("doc_type");
            }
        }

        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set
            {
                _doc_cat = value;
                RaisePropertyChanged("doc_cat");
            }
        }

        private string _carton_type;
        public string carton_type
        {
            get { return _carton_type; }
            set
            {
                _carton_type = value;
                RaisePropertyChanged("carton_type");
            }
        }

        private string _packing_type;
        public string packing_type
        {
            get { return _packing_type; }
            set
            {
                _packing_type = value;
                RaisePropertyChanged("packing_type");
            }
        }

        private string _carton_no;
        public string carton_no
        {
            get { return _carton_no; }
            set
            {
                _carton_no = value;
                RaisePropertyChanged("carton_no");
            }
        }

        private DateTime? _carton_pack_dt;
        public DateTime? carton_pack_dt
        {

            get { return _carton_pack_dt; }
            set
            {
                _carton_pack_dt = value;
                RaisePropertyChanged("carton_pack_dt");
            }
        }

        private string _barcode;
        public string barcode
        {
            get { return _barcode; }
            set
            {
                _barcode = value;
                RaisePropertyChanged("barcode");
            }
        }

        private string _batch_no;
        public string batch_no
        {

            get { return _batch_no; }
            set
            {
                _batch_no = value;
                RaisePropertyChanged("batch_no");
            }
        }

        private string _cust_batch_no;
        public string cust_batch_no
        {

            get { return _cust_batch_no; }
            set
            {
                _cust_batch_no = value;
                RaisePropertyChanged("cust_batch_no");
            }
        }

        private string _ItemCode;
        public string ItemCode
        {

            get { return _ItemCode; }
            set
            {
                _ItemCode = value;
                RaisePropertyChanged("ItemCode", ModelEntityUpdated);
            }
        }

        private string _grade;
        public string grade
        {
            get { return _grade; }
            set
            {
                _grade = value;
                RaisePropertyChanged("grade");
            }
        }

        private int? _ink_id;
        public int? ink_id
        {
            get { return _ink_id; }
            set
            {
                _ink_id = value;
                RaisePropertyChanged("ink_id");
            }
        }

        private int? _ild_id;
        public int? ild_id
        {
            get { return _ild_id; }
            set
            {
                _ild_id = value;
                RaisePropertyChanged("ild_id");
            }
        }

        private string _tip_type;
        public string tip_type
        {
            get { return _tip_type; }
            set
            {
                _tip_type = value;
                RaisePropertyChanged("tip_type");
            }
        }

        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set
            {
                _unit_code = value;
                RaisePropertyChanged("unit_code", ModelEntityUpdated);
            }
        }

        private int? _pack_style;
        public int? pack_style
        {
            get { return _pack_style; }
            set
            {
                _pack_style = value;
                RaisePropertyChanged("pack_style");
            }
        }

        private decimal? _qty_per_bag;
        public decimal? qty_per_bag
        {
            get { return _qty_per_bag; }
            set
            {
                _qty_per_bag = value;
                RaisePropertyChanged("qty_per_bag", ModelEntityUpdated);
            }
        }

        private decimal? _tot_no_bags;
        public decimal? tot_no_bags
        {
            get { return _tot_no_bags; }
            set
            {
                _tot_no_bags = value;
                RaisePropertyChanged("tot_no_bags", ModelEntityUpdated);
            }
        }

        private decimal? _tot_qty;
        public decimal? tot_qty
        {
            get { return _tot_qty; }
            set
            {
                _tot_qty = value;
                RaisePropertyChanged("tot_qty", ModelEntityUpdated);
            }
        }

        private decimal? _bal_qty;
        public decimal? bal_qty
        {
            get { return _bal_qty; }
            set
            {
                _bal_qty = value;
                RaisePropertyChanged("bal_qty");
            }
        }

        private int? _wire_make_id;
        public int? wire_make_id
        {
            get { return _wire_make_id; }
            set
            {
                _wire_make_id = value;
                RaisePropertyChanged("wire_make_id");
            }
        }

        private int? _ball_make_id;
        public int? ball_make_id
        {
            get { return _ball_make_id; }
            set
            {
                _ball_make_id = value;
                RaisePropertyChanged("ball_make_id");
            }
        }

        private decimal? _net_wt;
        public decimal? net_wt
        {
            get { return _net_wt; }
            set
            {
                _net_wt = value;
                RaisePropertyChanged("net_wt", ModelEntityUpdated);
            }
        }

        private decimal? _gross_wt;
        public decimal? gross_wt
        {
            get { return _gross_wt; }
            set
            {
                _gross_wt = value;
                RaisePropertyChanged("gross_wt", ModelEntityUpdated);
            }
        }

        private int? _prod_desc_id;
        public int? prod_desc_id
        {
            get { return _prod_desc_id; }
            set
            {
                _prod_desc_id = value;
                RaisePropertyChanged("prod_desc_id");
            }
        }
        private string _dimension;
        public string dimension
        {
            get { return _dimension; }
            set
            {
                _dimension = value;
                RaisePropertyChanged("dimension");
            }
        }

        private string _shipping_mrk;
        public string shipping_mrk
        {
            get { return _shipping_mrk; }
            set
            {
                _shipping_mrk = value;
                RaisePropertyChanged("shipping_mrk");
            }
        }
        private string _no_kind_pack;
        public string no_kind_pack
        {
            get { return _no_kind_pack; }
            set
            {
                _no_kind_pack = value;
                RaisePropertyChanged("no_kind_pack");
            }
        }

        private string _mark_and_nos;
        public string mark_and_nos
        {
            get { return _mark_and_nos; }
            set
            {
                _mark_and_nos = value;
                RaisePropertyChanged("mark_and_nos");
            }
        }

        private string _cust_prod_no;
        public string cust_prod_no
        {
            get { return _cust_prod_no; }
            set
            {
                _cust_prod_no = value;
                RaisePropertyChanged("cust_prod_no");
            }
        }

        private string _cust_prod_code;
        public string cust_prod_code
        {
            get { return _cust_prod_code; }
            set
            {
                _cust_prod_code = value;
                RaisePropertyChanged("cust_prod_code");
            }
        }

        private int? _cpnsrno;
        public int? cpnsrno
        {
            get { return _cpnsrno; }
            set
            {
                _cpnsrno = value;
                RaisePropertyChanged("cpnsrno");
            }
        }

        private string _cpn_model_no;
        public string cpn_model_no
        {
            get { return _cpn_model_no; }
            set
            {
                _cpn_model_no = value;
                RaisePropertyChanged("cpn_model_no");
            }
        }

        private string _partno;
        public string partno
        {
            get { return _partno; }
            set
            {
                _partno = value;
                RaisePropertyChanged("partno");
            }
        }

        private string _po_no;
        public string po_no
        {
            get { return _po_no; }
            set
            {
                _po_no = value;
                RaisePropertyChanged("po_no");
            }
        }

        private string _note;
        public string note
        {
            get { return _note; }
            set
            {
                _note = value;
                RaisePropertyChanged("note");
            }
        }

        private bool? _carton_used_Flg;
        public bool? carton_used_Flg
        {
            get { return _carton_used_Flg; }
            set
            {
                _carton_used_Flg = value;
                RaisePropertyChanged("carton_used_Flg");
            }
        }

        private string _free_sale;
        public string free_sale
        {
            get { return _free_sale; }
            set
            {
                _free_sale = value;
                RaisePropertyChanged("free_sale");
            }
        }

        private bool _active;
        public bool active
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

        private int? _no_of_carton;
        public int? no_of_carton
        {
            get { return _no_of_carton; }
            set
            {
                _no_of_carton = value;
                RaisePropertyChanged("no_of_carton", ModelEntityUpdated);
            }
        }

        private int? _bags_per_carton;
        public int? bags_per_carton
        {
            get { return _bags_per_carton; }
            set
            {
                _bags_per_carton = value;
                RaisePropertyChanged("bags_per_carton", ModelEntityUpdated);
            }
        }

        private string _fin_year;
        public string fin_year
        {
            get { return _fin_year; }
            set
            {
                _fin_year = value;
                RaisePropertyChanged("fin_year");
            }
        }

        private string _posting_period;
        public string posting_period
        {
            get { return _posting_period; }
            set
            {
                _posting_period = value;
                RaisePropertyChanged("posting_period");
            }
        }
        private string _PartyId;
        public string PartyId
        {
            get { return _PartyId; }
            set { _PartyId = value; RaisePropertyChanged("PartyId"); }
        }

        private string _m_operator;
        public string m_operator
        {
            get { return _m_operator; }
            set { _m_operator = value; RaisePropertyChanged("m_operator"); }
        }
        private int? _machine_id;
        public int? machine_id
        {
            get { return _machine_id; }
            set { _machine_id = value; RaisePropertyChanged("machine_id"); }
        }
        private string _machinecode { get; set; }
        public string machinecode
        {
            get { return _machinecode; }
            set { _machinecode = value; RaisePropertyChanged("machinecode"); }
        }
        private string _wc_code { get; set; }
        public string wc_code
        {
            get { return _wc_code; }
            set { _wc_code = value; RaisePropertyChanged("wc_code"); }
        }
        
        public string _dn_doc_no;
        public string dn_doc_no
        {
            get { return _dn_doc_no; }
            set
            {
                _dn_doc_no = value;
                RaisePropertyChanged("dn_doc_no");
            }
        }
        public int? _dn_row_id;
        public int? dn_row_id
        {
            get { return _dn_row_id; }
            set
            {
                _dn_row_id = value;
                RaisePropertyChanged("dn_row_id");
            }
        }
        public int? _dn_batch_row_id;
        public int? dn_batch_row_id
        {
            get { return _dn_batch_row_id; }
            set
            {
                _dn_batch_row_id = value;
                RaisePropertyChanged("dn_batch_row_id");
            }
        }
        private decimal? _volume;
        public decimal? volume
        {
            get { return _volume; }
            set
            {
                _volume = value;
                RaisePropertyChanged("volume", ModelEntityUpdated);
            }
        }
        public string _volume_unit;
        public string volume_unit
        {
            get { return _volume_unit; }
            set
            {
                _volume_unit = value;
                RaisePropertyChanged("volume_unit");
            }
        }
        private decimal? _volume_loading;
        public decimal? volume_loading
        {
            get { return _volume_loading; }
            set
            {
                _volume_loading = value;
                RaisePropertyChanged("volume_loading", ModelEntityUpdated);
            }
        }
        private decimal? _volume_loading_allowed;
        public decimal? volume_loading_allowed
        {
            get { return _volume_loading_allowed; }
            set
            {
                _volume_loading_allowed = value;
                RaisePropertyChanged("volume_loading_allowed", ModelEntityUpdated);
            }
        }
        private decimal? _tare_volume;
        public decimal? tare_volume
        {
            get { return _tare_volume; }
            set
            {
                _tare_volume = value;
                RaisePropertyChanged("tare_volume", ModelEntityUpdated);
            }
        }
        private decimal? _loading_wt;
        public decimal? loading_wt
        {
            get { return _loading_wt; }
            set
            {
                _loading_wt = value;
                RaisePropertyChanged("loading_wt");
            }
        }
        private decimal? _loading_wt_allowed;
        public decimal? loading_wt_allowed
        {
            get { return _loading_wt_allowed; }
            set
            {
                _loading_wt_allowed = value;
                RaisePropertyChanged("loading_wt_allowed", ModelEntityUpdated);
            }
        }
        private decimal? _tare_wt;
        public decimal? tare_wt
        {
            get { return _tare_wt; }
            set
            {
                _tare_wt = value;
                RaisePropertyChanged("tare_wt", ModelEntityUpdated);
            }
        }
        private string _weight_unit;
        public string weight_unit
        {
            get { return _weight_unit; }
            set { _weight_unit = value; RaisePropertyChanged("weight_unit"); }
        }
        private string _item_code_pack;
        public string item_code_pack
        {
            get { return _item_code_pack; }
            set { if (_item_code_pack != value) { _item_code_pack = value; RaisePropertyChanged("item_code_pack", ModelEntityUpdated); } }
        }
        private decimal? _pack_length;
        public decimal? pack_length
        {
            get { return _pack_length; }
            set
            {
                _pack_length = value;
                RaisePropertyChanged("pack_length");
            }
        }
        private decimal? _pack_width;
        public decimal? pack_width
        {
            get { return _pack_width; }
            set
            {
                _pack_width = value;
                RaisePropertyChanged("pack_width");
            }
        }
        private decimal? _pack_height;
        public decimal? pack_height
        {
            get { return _pack_height; }
            set
            {
                _pack_height = value;
                RaisePropertyChanged("pack_height");
            }
        }
        private string _dim_uom;
        public string dim_uom
        {
            get { return _dim_uom; }
            set { _dim_uom = value; RaisePropertyChanged("dim_uom"); }
        }
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }
        }
        private decimal? _wt_tol;
        public decimal? wt_tol
        {
            get { return _wt_tol; }
            set
            {
                _wt_tol = value;
                RaisePropertyChanged("wt_tol");
            }
        }
        private decimal? _vol_tol;
        public decimal? vol_tol
        {
            get { return _vol_tol; }
            set
            {
                _vol_tol = value;
                RaisePropertyChanged("vol_tol");
            }
        }
        private string _sku;
        public string sku
        {
            get { return _sku; }
            set { _sku = value; RaisePropertyChanged("sku"); }
        }
        private decimal? _qty_item_code_pack;
        public decimal? qty_item_code_pack
        {
            get { return _qty_item_code_pack; }
            set
            {
                _qty_item_code_pack = value;
                RaisePropertyChanged("qty_item_code_pack", ModelEntityUpdated);
            }
        }
        private string _uom_item_code_pack;
        public string uom_item_code_pack
        {
            get { return _uom_item_code_pack; }
            set { _uom_item_code_pack = value; RaisePropertyChanged("uom_item_code_pack"); }
        }
        private string _pack_type;
        public string pack_type
        {
            get { return _pack_type; }
            set { _pack_type = value; RaisePropertyChanged("pack_type"); }
        }
        private string _store_code;
        public string store_code
        {
            get { return _store_code; }
            set { _store_code = value; RaisePropertyChanged("store_code"); }
        }
        private string _wa_code;
        public string wa_code
        {
            get { return _wa_code; }
            set { _wa_code = value; RaisePropertyChanged("wa_code"); }
        }
        private string _hu_h_level;
        public string hu_h_level
        {
            get { return _hu_h_level; }
            set { _hu_h_level = value; RaisePropertyChanged("hu_h_level"); }
        }
        private string _pack_inst;
        public string pack_inst
        {
            get { return _pack_inst; }
            set { _pack_inst = value; RaisePropertyChanged("pack_inst"); }
        }
        private int? _level_no;
        public int? level_no
        {
            get { return _level_no; }
            set { _level_no = value; RaisePropertyChanged("level_no"); }
        }
        private string _ind_print;
        public string ind_print
        {
            get { return _ind_print; }
            set { _ind_print = value; RaisePropertyChanged("ind_print"); }
        }
        private string _packing_location;
        public string packing_location
        {
            get { return _packing_location; }
            set { _packing_location = value; RaisePropertyChanged("packing_location"); }
        }

        //Extra  Scalars
        public string XmlDataDocument_EPR_T003_B { get; set; }
        public string XmlDataDocument_EPR_T003_A { get; set; }
        public string _ind_packing; // indicator for Packing process type i.e Split Material Packing, Standard Material Packing,Split HUs Packing and Standard Hus Packing.
        public string ind_packing
        {
            get { return _ind_packing; }
            set { _ind_packing = value; RaisePropertyChanged("ind_packing"); }
        }
        private string _Ink;
        public string Ink
        {
            get { return _Ink; }
            set { _Ink = value; RaisePropertyChanged("Ink"); }
        }

        private string _Ild;
        public string Ild
        {
            get { return _Ild; }
            set { _Ild = value; RaisePropertyChanged("Ild"); }
        }

        private string _BallMake;
        public string BallMake
        {
            get { return _BallMake; }
            set { _BallMake = value; RaisePropertyChanged("BallMake"); }
        }
        private decimal? _ball_dia;
        public decimal? ball_dia
        {
            get { return _ball_dia; }
            set
            {
                _ball_dia = value;
                RaisePropertyChanged("ball_dia", ModelEntityUpdated);
            }
        }
        private string _WireMake;
        public string WireMake
        {
            get { return _WireMake; }
            set { _WireMake = value; RaisePropertyChanged("WireMake"); }
        }

        private string _PackingUnit;
        public string PackingUnit
        {
            get { return _PackingUnit; }
            set { _PackingUnit = value; RaisePropertyChanged("PackingUnit"); }
        }

        private string _AllMachine;
        public string AllMachine
        {
            get { return _AllMachine; }
            set { _AllMachine = value; RaisePropertyChanged("AllMachine"); }
        }

        private string _AllShift;
        public string AllShift
        {
            get { return _AllShift; }
            set { _AllShift = value; RaisePropertyChanged("AllShift"); }
        }
        private string _ItemName;
        public string ItemName
        {
            get { return _ItemName; }
            set { _ItemName = value; RaisePropertyChanged("ItemName"); }
        }

        private string _PartyNm;
        public string PartyNm
        {
            get { return _PartyNm; }
            set { _PartyNm = value; RaisePropertyChanged("PartyNm"); }
        }
        private string _OperatorNm;
        public string OperatorNm
        {
            get { return _OperatorNm; }
            set { _OperatorNm = value; RaisePropertyChanged("OperatorNm"); }
        }

        private bool? _check;
        public bool? check
        {
            get { return _check; }
            set { _check = value; RaisePropertyChanged("check"); }
        }
        private string _wire_type;
        public string wire_type
        {
            get { return _wire_type; }
            set
            {
                _wire_type = value;
                RaisePropertyChanged("wire_type");
            }
        }
        private string _ball_type;
        public string ball_type
        {
            get { return _ball_type; }
            set { _ball_type = value; RaisePropertyChanged("ball_type"); }
        }
        private string _modelno;
        public string modelno
        {
            get { return _modelno; }
            set { _modelno = value; RaisePropertyChanged("modelno"); }
        }
        private bool? _selected;
        public bool? selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                RaisePropertyChanged("selected", ModelEntityUpdated);
            }
        }
        private string _item_code;
        public string item_code
        {
            get { return _item_code; }
            set { _item_code = value; RaisePropertyChanged("item_code"); }
        }
        private string _item_name;
        public string item_name
        {
            get { return _item_name; }
            set { _item_name = value; RaisePropertyChanged("item_name"); }
        }
        private int? _line_no;
        public int? line_no
        {
            get { return _line_no; }
            set
            {
                _line_no = value;
                RaisePropertyChanged("line_no");
            }
        }
        private string _total_len;
        public string total_len
        {
            get { return _total_len; }
            set { _total_len = value; RaisePropertyChanged("total_len"); }
        }
    }
    public class EPR_T003_B : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int _id;
        public int id
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

        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set
            {
                _doc_type = value;
                RaisePropertyChanged("doc_type");
            }
        }
        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set
            {
                _doc_cat = value;
                RaisePropertyChanged("doc_cat");
            }
        }

        private string _carton_no;
        public string carton_no
        {
            get { return _carton_no; }
            set
            {
                _carton_no = value;
                RaisePropertyChanged("carton_no");
            }
        }

        private string _batch_no;
        public string batch_no
        {

            get { return _batch_no; }
            set
            {
                _batch_no = value;
                RaisePropertyChanged("batch_no");
            }
        }

        private string _cust_batch_no;
        public string cust_batch_no
        {

            get { return _cust_batch_no; }
            set
            {
                _cust_batch_no = value;
                RaisePropertyChanged("cust_batch_no");
            }
        }

        private decimal _qty;
        public decimal qty
        {
            get { return _qty; }
            set
            {
                _qty = value;
                RaisePropertyChanged("qty", ModelEntityUpdated);
            }
        }

        private string _note;
        public string note
        {
            get { return _note; }
            set
            {
                _note = value;
                RaisePropertyChanged("note");
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

        private bool _active;
        public bool active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active", ModelEntityUpdated);
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

        private string _fin_year;
        public string fin_year
        {
            get { return _fin_year; }
            set
            {
                _fin_year = value;
                RaisePropertyChanged("fin_year");
            }
        }

        private string _posting_period;
        public string posting_period
        {
            get { return _posting_period; }
            set
            {
                _posting_period = value;
                RaisePropertyChanged("posting_period");
            }
        }

        public string _hu_content_type;
        public string hu_content_type
        {
            get { return _hu_content_type; }
            set
            {
                _hu_content_type = value;
                RaisePropertyChanged("hu_content_type");
            }
        }
        public string _item_code;
        public string item_code
        {
            get { return _item_code; }
            set
            {
                _item_code = value;
                RaisePropertyChanged("item_code", ModelEntityUpdated);
            }
        }
        public string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set
            {
                _unit_code = value;
                RaisePropertyChanged("unit_code");
            }
        }
        public string _dn_doc_no;
        public string dn_doc_no
        {
            get { return _dn_doc_no; }
            set
            {
                _dn_doc_no = value;
                RaisePropertyChanged("dn_doc_no");
            }
        }
        public int? _dn_row_id;
        public int? dn_row_id
        {
            get { return _dn_row_id; }
            set
            {
                _dn_row_id = value;
                RaisePropertyChanged("dn_row_id");
            }
        }
        public int? _dn_batch_row_id;
        public int? dn_batch_row_id
        {
            get { return _dn_batch_row_id; }
            set
            {
                _dn_batch_row_id = value;
                RaisePropertyChanged("dn_batch_row_id");
            }
        }
        
        public int? _line_id;
        public int? line_id
        {
            get { return _line_id; }
            set
            {
                _line_id = value;
                RaisePropertyChanged("line_id");
            }
        }
        public string _hu_l_level;
        public string hu_l_level
        {
            get { return _hu_l_level; }
            set
            {
                _hu_l_level = value;
                RaisePropertyChanged("hu_l_level");
            }
        }
        public string _store_code;
        public string store_code
        {
            get { return _store_code; }
            set
            {
                _store_code = value;
                RaisePropertyChanged("store_code");
            }
        }
        public DateTime? _shelf_life;
        public DateTime? shelf_life
        {
            get { return _shelf_life; }
            set
            {
                _shelf_life = value;
                RaisePropertyChanged("shelf_life");
            }
        }
        private string _barcode;
        public string barcode
        {
            get { return _barcode; }
            set
            {
                _barcode = value;
                RaisePropertyChanged("barcode");
            }
        }
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }
        }
        public DateTime? _prod_date;
        public DateTime? prod_date
        {
            get { return _prod_date; }
            set
            {
                _prod_date = value;
                RaisePropertyChanged("prod_date");
            }
        }
        private string _ind_residue_packing;
        public string ind_residue_packing
        {
            get { return _ind_residue_packing; }
            set { _ind_residue_packing = value; RaisePropertyChanged("ind_residue_packing"); }
        }
        private string _sku;
        public string sku
        {
            get { return _sku; }
            set { _sku = value; RaisePropertyChanged("sku"); }
        }
        // Scalar Fields
        public decimal? _partial_qty;
        public decimal? partial_qty
        {
            get { return _partial_qty; }
            set
            {
                _partial_qty = value;
                RaisePropertyChanged("partial_qty");
            }
        }
        public decimal? _net_wt;
        public decimal? net_wt
        {
            get { return _net_wt; }
            set
            {
                _net_wt = value;
                RaisePropertyChanged("net_wt", ModelEntityUpdated);
            }
        }
        public string _weight_unit;
        public string weight_unit
        {
            get { return _weight_unit; }
            set
            {
                _weight_unit = value;
                RaisePropertyChanged("weight_unit");
            }
        }
        public decimal? _volume;
        public decimal? volume
        {
            get { return _volume; }
            set
            {
                _volume = value;
                RaisePropertyChanged("volume", ModelEntityUpdated);
            }
        }
        public string _volume_unit;
        public string volume_unit
        {
            get { return _volume_unit; }
            set
            {
                _volume_unit = value;
                RaisePropertyChanged("volume_unit");
            }
        }
        private string _MachinePacCode;
        public string MachinePacCode
        {
            get { return _MachinePacCode; }
            set
            {
                _MachinePacCode = value;
                RaisePropertyChanged("MachinePacCode");
            }
        }

        private string _Shift;
        public string Shift
        {
            get { return _Shift; }
            set
            {
                _Shift = value;
                RaisePropertyChanged("Shift");
            }
        }
        private string _item_name;
        public string item_name
        {
            get { return _item_name; }
            set
            {
                _item_name = value;
                RaisePropertyChanged("item_name");
            }
        }

        private bool? _selected;
        public bool? selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                RaisePropertyChanged("selected", ModelEntityUpdated);
            }
        }
        private int? _line_no;
        public int? line_no
        {
            get { return _line_no; }
            set
            {
                _line_no = value;
                RaisePropertyChanged("line_no");
            }
        }
        public decimal? _packing_qty;
        public decimal? packing_qty
        {
            get { return _packing_qty; }
            set
            {
                _packing_qty = value;
                RaisePropertyChanged("packing_qty");
            }
        }
        public decimal? _available_qty;
        public decimal? available_qty
        {
            get { return _available_qty; }
            set
            {
                _available_qty = value;
                RaisePropertyChanged("available_qty");
            }
        }
        public decimal? _yield;
        public decimal? yield
        {
            get { return _yield; }
            set
            {
                _yield = value;
                RaisePropertyChanged("yield");
            }
        }

    }

    public class EPR_T003_A_Flip : ObjectBase
    {
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

        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                _doc_no = value;
                RaisePropertyChanged("doc_no");
            }
        }

        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set
            {
                _doc_type = value;
                RaisePropertyChanged("doc_type");
            }
        }

        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set
            {
                _doc_cat = value;
                RaisePropertyChanged("doc_cat");
            }
        }

        private string _carton_type;
        public string carton_type
        {
            get { return _carton_type; }
            set
            {
                _carton_type = value;
                RaisePropertyChanged("carton_type");
            }
        }

        private string _packing_type;
        public string packing_type
        {
            get { return _packing_type; }
            set
            {
                _packing_type = value;
                RaisePropertyChanged("packing_type");
            }
        }

        private string _carton_no;
        public string carton_no
        {
            get { return _carton_no; }
            set
            {
                _carton_no = value;
                RaisePropertyChanged("carton_no");
            }
        }


        private Nullable<System.DateTime> _carton_pack_dt;
        public Nullable<System.DateTime> carton_pack_dt
        {

            get { return _carton_pack_dt; }
            set
            {
                _carton_pack_dt = value;
                RaisePropertyChanged("carton_pack_dt");
            }
        }

        private string _barcode;
        public string barcode
        {
            get { return _barcode; }
            set
            {
                _barcode = value;
                RaisePropertyChanged("barcode");
            }
        }

        private string _batch_no;
        public string batch_no
        {

            get { return _batch_no; }
            set
            {
                _batch_no = value;
                RaisePropertyChanged("batch_no");
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

        private string _ItemName;
        public string ItemName
        {

            get { return _ItemName; }
            set
            {
                _ItemName = value;
                RaisePropertyChanged("ItemName");
            }
        }

        private string _grade;
        public string grade
        {
            get { return _grade; }
            set
            {
                _grade = value;
                RaisePropertyChanged("grade");
            }
        }

        private int? _ink_id;
        public int? ink_id
        {
            get { return _ink_id; }
            set
            {
                _ink_id = value;
                RaisePropertyChanged("ink_id");
            }
        }

        private int? _ild_id;
        public int? ild_id
        {
            get { return _ild_id; }
            set
            {
                _ild_id = value;
                RaisePropertyChanged("ild_id");
            }
        }

        private string _tip_type;
        public string tip_type
        {
            get { return _tip_type; }
            set
            {
                _tip_type = value;
                RaisePropertyChanged("tip_type");
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

        private Nullable<int> _pack_style;
        public Nullable<int> pack_style
        {
            get { return _pack_style; }
            set
            {
                _pack_style = value;
                RaisePropertyChanged("pack_style");
            }
        }

        private Nullable<decimal> _qty_per_bag;
        public Nullable<decimal> qty_per_bag
        {
            get { return _qty_per_bag; }
            set
            {
                _qty_per_bag = value;
                RaisePropertyChanged("qty_per_bag");
            }
        }

        private Nullable<decimal> _tot_no_bags;
        public Nullable<decimal> tot_no_bags
        {
            get { return _tot_no_bags; }
            set
            {
                _tot_no_bags = value;
                RaisePropertyChanged("tot_no_bags");
            }
        }

        private Nullable<decimal> _tot_qty;
        public Nullable<decimal> tot_qty
        {
            get { return _tot_qty; }
            set
            {
                _tot_qty = value;
                RaisePropertyChanged("tot_qty");
            }
        }

        private Nullable<decimal> _bal_qty;
        public Nullable<decimal> bal_qty
        {
            get { return _bal_qty; }
            set
            {
                _bal_qty = value;
                RaisePropertyChanged("bal_qty");
            }
        }


        private int _wire_make_id;
        public int wire_make_id
        {
            get { return _wire_make_id; }
            set
            {
                _wire_make_id = value;
                RaisePropertyChanged("wire_make_id");
            }
        }


        private int _ball_make_id;
        public int ball_make_id
        {
            get { return _ball_make_id; }
            set
            {
                _ball_make_id = value;
                RaisePropertyChanged("ball_make_id");
            }
        }


        private Nullable<decimal> _net_wt;
        public Nullable<decimal> net_wt
        {
            get { return _net_wt; }
            set
            {
                _net_wt = value;
                RaisePropertyChanged("net_wt");
            }
        }


        private Nullable<decimal> _gross_wt;
        public Nullable<decimal> gross_wt
        {
            get { return _gross_wt; }
            set
            {
                _gross_wt = value;
                RaisePropertyChanged("gross_wt");
            }
        }


        private Nullable<int> _prod_desc_id;
        public Nullable<int> prod_desc_id
        {
            get { return _prod_desc_id; }
            set
            {
                _prod_desc_id = value;
                RaisePropertyChanged("prod_desc_id");
            }
        }

        private string _dimension;
        public string dimension
        {
            get { return _dimension; }
            set
            {
                _dimension = value;
                RaisePropertyChanged("dimension");
            }
        }


        private string _shipping_mrk;
        public string shipping_mrk
        {
            get { return _shipping_mrk; }
            set
            {
                _shipping_mrk = value;
                RaisePropertyChanged("shipping_mrk");
            }
        }


        private string _no_kind_pack;
        public string no_kind_pack
        {
            get { return _no_kind_pack; }
            set
            {
                _no_kind_pack = value;
                RaisePropertyChanged("no_kind_pack");
            }
        }


        private string _mark_and_nos;
        public string mark_and_nos
        {
            get { return _mark_and_nos; }
            set
            {
                _mark_and_nos = value;
                RaisePropertyChanged("mark_and_nos");
            }
        }

        private string _cust_prod_no;
        public string cust_prod_no
        {
            get { return _cust_prod_no; }
            set
            {
                _cust_prod_no = value;
                RaisePropertyChanged("cust_prod_no");
            }
        }

        private string _cust_prod_code;
        public string cust_prod_code
        {
            get { return _cust_prod_code; }
            set
            {
                _cust_prod_code = value;
                RaisePropertyChanged("cust_prod_code");
            }
        }



        private Nullable<int> _cpnsrno;
        public Nullable<int> cpnsrno
        {
            get { return _cpnsrno; }
            set
            {
                _cpnsrno = value;
                RaisePropertyChanged("cpnsrno");
            }
        }

        private string _cpn_model_no;
        public string cpn_model_no
        {
            get { return _cpn_model_no; }
            set
            {
                _cpn_model_no = value;
                RaisePropertyChanged("cpn_model_no");
            }
        }


        private string _partno;
        public string partno
        {
            get { return _partno; }
            set
            {
                _partno = value;
                RaisePropertyChanged("partno");
            }
        }

        private string _po_no;
        public string po_no
        {
            get { return _po_no; }
            set
            {
                _po_no = value;
                RaisePropertyChanged("po_no");
            }
        }


        private string _note;
        public string note
        {
            get { return _note; }
            set
            {
                _note = value;
                RaisePropertyChanged("note");
            }
        }


        private Nullable<bool> _carton_used_Flg;
        public Nullable<bool> carton_used_Flg
        {
            get { return _carton_used_Flg; }
            set
            {
                _carton_used_Flg = value;
                RaisePropertyChanged("carton_used_Flg");
            }
        }

        private string _free_sale;
        public string free_sale
        {
            get { return _free_sale; }
            set
            {
                _free_sale = value;
                RaisePropertyChanged("free_sale");
            }
        }


        private bool _active;
        public bool active
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

        private Nullable<int> _no_of_carton;
        public Nullable<int> no_of_carton
        {
            get { return _no_of_carton; }
            set
            {
                _no_of_carton = value;
                RaisePropertyChanged("no_of_carton");
            }
        }


        private Nullable<int> _bags_per_carton;
        public Nullable<int> bags_per_carton
        {
            get { return _bags_per_carton; }
            set
            {
                _bags_per_carton = value;
                RaisePropertyChanged("bags_per_carton");
            }
        }


        private string _fin_year;
        public string fin_year
        {
            get { return _fin_year; }
            set
            {
                _fin_year = value;
                RaisePropertyChanged("fin_year");
            }
        }

        private string _posting_period;
        public string posting_period
        {
            get { return _posting_period; }
            set
            {
                _posting_period = value;
                RaisePropertyChanged("posting_period");
            }
        }

        //Extra  Scalars
        private string _Ink;
        public string Ink
        {
            get { return _Ink; }
            set { _Ink = value; RaisePropertyChanged("Ink"); }
        }

        private string _Ild;
        public string Ild
        {
            get { return _Ild; }
            set { _Ild = value; RaisePropertyChanged("Ild"); }
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

        private string _PackingUnit;
        public string PackingUnit
        {
            get { return _PackingUnit; }
            set { _PackingUnit = value; RaisePropertyChanged("PackingUnit"); }
        }

        private string _status;
        public string status
        {
            get { return _status; }
            set { _status = value; RaisePropertyChanged("status"); }
        }

        //detail
        public string batch_no_a { get; set; }
        public decimal qty { get; set; }

        //extra
        private DateTime? _FromDate;
        public DateTime? FromDate
        {
            get { return _FromDate; }
            set
            {
                if (_FromDate != value)
                {
                    _FromDate = value;
                    RaisePropertyChanged("FromDate");
                }
            }
        }

        private DateTime? _ToDate;
        public DateTime? ToDate
        {
            get { return _ToDate; }
            set
            {
                if (_ToDate != value)
                {
                    _ToDate = value;
                    RaisePropertyChanged("ToDate");
                }
            }
        }


    }


    public partial class EPR_T003_Batch_Data
    {
        public string batch_no { get; set; }
        public string itemcode { get; set; }
        public string grade { get; set; }
        public Nullable<int> ink_id { get; set; }
        public string ink { get; set; }
        public Nullable<int> ild_id { get; set; }
        public string ild { get; set; }
        public Nullable<int> unit_id { get; set; }
        public string uom { get; set; }
        public Nullable<int> pack_style { get; set; }
        public string pkgunit { get; set; }
        public Nullable<decimal> label_qty { get; set; }
        public Nullable<int> wire_make_id { get; set; }
        public string wire_make { get; set; }
        public Nullable<int> ball_make_id { get; set; }
        public string ball_make { get; set; }
        public Nullable<decimal> NetWt { get; set; }
        public Nullable<decimal> GrossWt { get; set; }
        public Nullable<decimal> tot_no_bags { get; set; }
        public string tip_type { get; set; }
        public Nullable<DateTime> prod_dt { get; set; }

    }
    public class EPR_T003_S
    {
        public string batch_no_format { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public int range1 { get; set; }
        public int doc_no_digits { get; set; }
        public string doc_type { get; set; }
        public string report_name { get; set; }
        public string report_name2 { get; set; }
        public string report_name3 { get; set; }
        public string report_name4 { get; set; }
        public string report_name5 { get; set; }
        public string report_name6 { get; set; }
        public decimal net_wt { get; set; }
        public decimal gross_wt { get; set; }
        public Nullable<decimal> no_of_bags { get; set; }
        public Nullable<int> no_of_cartons { get; set; }
        public string dimension { get; set; }
        public string scan_source { get; set; }
        public int min_length { get; set; }
    }

    public class RptSmallCarton
    {
        public string modelno { get; set; }
        public string barcode { get; set; }
        public string batch_no { get; set; }
        public string batch1 { get; set; }
        public string batch2 { get; set; }
        public string barcode1 { get; set; }
        public string barcode2 { get; set; }
        public decimal? ball_dia { get; set; }
        public string ball_type { get; set; }
        public string wire_type { get; set; }
        public decimal? tot_qty { get; set; }
        public decimal? net_wt { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public string unit_code { get; set; }
        public string ABN { get; set; }
        public bool? check { get; set; }
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public string grade { get; set; }
        public float? qty { get; set; }
        public DateTime? batch_date1 { get; set; }
        public DateTime? batch_date2 { get; set; }
        public string machinecode1 { get; set; }
        public string machinecode2 { get; set; }
        public string location_Nm { get; set; }
        public string comp_Nm { get; set; }
        public float? qty1 { get; set; }
        public float? qty2 { get; set; }
        public byte[] qr_batch1 { get; set; }
        public byte[] qr_batch2 { get; set; }
        public byte[] qr_batch3 { get; set; }
    }

    public class RptLocalExportCarton
    {
        public string modelno { get; set; }
        public string barcode { get; set; }
        public string batch_no { get; set; }
        public decimal? ball_dia { get; set; }
        public string ball_type { get; set; }
        public string wire_type { get; set; }
        public decimal? tot_qty { get; set; }
        public decimal? net_wt { get; set; }
        public decimal? gross_wt { get; set; }
        public string carton { get; set; }
        public string pallet_no { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public string unit_code { get; set; }
        public string doc_no { get; set; }
        public string cust_prod_code { get; set; }
        public string cust_prod_no { get; set; }
        public string ItemCode { get; set; }
        public string grade { get; set; }
        public decimal? qty_per_bag { get; set; }
        public decimal? tot_no_bags { get; set; }
        public string cust_no { get; set; }
        public int? no_of_carton { get; set; }
        public decimal? qty_per_carton { get; set; }
        public bool? check { get; set; }
        public string item_name { get; set; }
        public string shipping_mrk { get; set; }
        public byte[] qr_batch { get; set; }
    }

    public class RptExportLabel
    {
        public string modelno { get; set; }
        public string barcode { get; set; }
        public string batch_no { get; set; }
        public decimal? ball_dia { get; set; }
        public string ball_type { get; set; }
        public string wire_type { get; set; }
        public decimal? tot_qty { get; set; }
        public decimal? net_wt { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public string unit_code { get; set; }
        public string doc_no { get; set; }
        public string cust_prod_code { get; set; }
        public string cust_prod_no { get; set; }
        public string ItemCode { get; set; }
        public string grade { get; set; }
        public decimal? qty_per_bag { get; set; }
        public decimal? tot_no_bags { get; set; }
        public string pallet_no { get; set; }
        public decimal? gross_wt { get; set; }
        public string carton { get; set; }
        public string shipping_mrk { get; set; }
    }

    public class RptCartonPacking
    {
        public string doc_no { get; set; }
        public string carton_type { get; set; }
        public string carton_no { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public Nullable<int> ink_id { get; set; }
        public string ink { get; set; }
        public Nullable<int> ild_id { get; set; }
        public string ild { get; set; }
        public string grade { get; set; }
        public Nullable<decimal> tot_qty { get; set; }
        public string batch_no { get; set; }
        public string unit_code { get; set; }
        public string batch_noB { get; set; }
        public Nullable<decimal> batch_qty { get; set; }
        public Nullable<int> machine_id { get; set; }
        public string machinecode { get; set; }
        public Nullable<decimal> net_wt { get; set; }
        public Nullable<decimal> gross_wt { get; set; }
        public DateTime? batch_date { get; set; }

    }

    public class RptCartonBatchDetails
    {
        public string batch_no { get; set; }
        public string grade { get; set; }
        public string ItemName { get; set; }
        public string Ink { get; set; }
        public string Ild { get; set; }
        public string batch_inner { get; set; }
        public string batch_label { get; set; }
        public decimal? label_qty { get; set; }
        public string machinecode { get; set; }
        public DateTime? prod_dt { get; set; }
        public decimal? inner_qty { get; set; }
        public string inner_unit { get; set; }
        public string label_unit { get; set; }
        public bool? check { get; set; }
        public decimal? tot_qty { get; set; }
        public string SrNo { get; set; }
        public byte[] qr_batch { get; set; }
    }

    public class MultipleContext_EPR_T003
    {
        public List<ZADM_M020_P> CustProdNameList { get; set; }
        public List<ADM_M020_P> DescGoodsList { get; set; }
        public List<EPR_T002_Flip> LabelGeneratedList { get; set; }
        public ObservableCollection<EPR_T003_B> LabelGeneratedEntity { get; set; }
        public List<ADM_M022_P> ItemList { get; set; }
        public List<ZADM_M006_P> InkList { get; set; }
        public List<ZADM_M007_P> IidList { get; set; }
        public List<ADM_M022_P> ItemList2 { get; set; }
        public List<ZADM_M006_P> InkList2 { get; set; }
        public List<ZADM_M007_P> IidList2 { get; set; }
        public List<ADM_M032_P> WireMakeList { get; set; }
        public List<ADM_M032_P> BallMakeList { get; set; }
        public List<ZADM_M017_P> PackingUnitList { get; set; }
        public List<ADM_M038_B_P> UnitList { get; set; }
        public List<EPR_T003_S> SettingsList { get; set; }
        public List<EPR_T003_A> MasterEntityList { get; set; }
        public List<EPR_T003_A> SmallCartonList { get; set; }
        public ObservableCollection<EPR_T003_B> SmallCartonEntity { get; set; }
        public List<RptSmallCarton> RptSmallCartonList { get; set; }
        public List<RptLocalExportCarton> RptLocalExportCartonList { get; set; }
        public List<RptExportLabel> RptExportLabelList { get; set; }
        public List<RptCartonPacking> RptCartonPackingList { get; set; }
        public List<RptCartonBatchDetails> RptCartonBatchDetailsList { get; set; }
        public List<ZADM_M013_P> MachineList { get; set; }
        public List<ADM_M024_P> EmployeeList { get; set; }
        public List<RptLabelGen> RptLabelGenList { get; set; }
        public List<ADM_M030_P> GradeList { get; set; }

    }

    public class MultipleContext_SearchLabel
    {
        public string doc_type { get; set; }
        public List<EPR_T002_Flip> LabelEntity { get; set; }
        public List<EPR_T002_B> MergeList { get; set; }
        public List<EPR_T003_A_Flip> SmallCartonEntity { get; set; }
        public List<EPR_T003_B> SmallCartonDetails { get; set; }
        public List<EPR_T003_A_Flip> OuterCartonEntity { get; set; }
        public List<LOG_T001_A_P> DispatchEntity { get; set; }
        public List<SEL_T003_P> InvoiceEntity { get; set; }
        //public List<EPR_T003_S> SettingsList { get; set; }
    }
    public class EPR_T003_ReportData
    {
        public string ReportType { get; set; }

    }

    public class MC_EPR_T003 : STD_MC_BE
    {
        public List<SYS_M054> HU_TYPE_LIST { get; set; }
        public ObservableCollection<EPR_T003_A> MASTER_ENTITY_LIST { get; set; }
        public ObservableCollection<EPR_T003_B> ITEMS_ENTITY_LIST { get; set; }
        public List<PPC_M001_P> STD_WC_LIST { get; set; }
        public List<STD_ITEM> STD_ITEM_LIST_PKG { get; set; }
        public ObservableCollection<EPR_T003_A> MASTER_ENTITY_HU_LIST { get; set; }
        public ObservableCollection<EPR_T003_A> ITEMS_ENTITY_HU_LIST { get; set; }
    }


}
