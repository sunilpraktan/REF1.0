using Reflection.BusinessEntity.ADM;
using Reflection.BusinessEntity.CustomerRelation;
using Reflection.BusinessEntity.ReflectionSystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Reflection.BusinessEntity
{
    public class LOG_T001_A : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }

        private string _delivery_no;
        public string delivery_no
        {
            get { return _delivery_no; }
            set { _delivery_no = value; RaisePropertyChanged("delivery_no"); }
        }

        private Nullable<System.DateTime> _delivery_date;
        //[Required(ErrorMessage = "Field 'Delivery Date' is required.")]
        public Nullable<System.DateTime> delivery_date
        {
            get { return _delivery_date; }
            set { _delivery_date = value; RaisePropertyChanged("delivery_date", ModelEntityUpdated); }
        }

        private string _del_time;
        public string del_time
        {
            get { return _del_time; }
            set { _del_time = value; RaisePropertyChanged("del_time"); }
        }

        private string _PartyId;
        // [Required(ErrorMessage = "Field 'Sold To Party' is required.")]
        public string PartyId
        {
            get { return _PartyId; }
            set { _PartyId = value; RaisePropertyChanged("PartyId", ModelEntityUpdated); }
        }

        private string _ship_to_party;
        //[Required(ErrorMessage = "Field 'Ship To Party' is required.")]
        public string ship_to_party
        {
            get { return _ship_to_party; }
            set { _ship_to_party = value; RaisePropertyChanged("ship_to_party", ModelEntityUpdated); }
        }

        private string _notify_party;
        public string notify_party
        {
            get { return _notify_party; }
            set { _notify_party = value; RaisePropertyChanged("notify_party"); }
        }

        private string _order_no;
        public string order_no
        {
            get { return _order_no; }
            set { _order_no = value; RaisePropertyChanged("order_no"); }
        }

        private string _delivery_type;
        // [Required(ErrorMessage = "Field 'Delivery Type' is required.")]
        public string delivery_type
        {
            get { return _delivery_type; }
            set { _delivery_type = value; RaisePropertyChanged("delivery_type", ModelEntityUpdated); }
        }

        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set { _doc_cat = value; RaisePropertyChanged("doc_cat"); }
        }

        private Nullable<System.DateTime> _pick_date;
        public Nullable<System.DateTime> pick_date
        {
            get { return _pick_date; }
            set { _pick_date = value; RaisePropertyChanged("pick_date"); }
        }

        private string _pick_time;
        public string pick_time
        {
            get { return _pick_time; }
            set { _pick_time = value; RaisePropertyChanged("pick_time"); }
        }

        private string _shipment_mode;
        public string shipment_mode
        {
            get { return _shipment_mode; }
            set { _shipment_mode = value; RaisePropertyChanged("shipment_mode"); }
        }




        private string _ladding_bill;
        public string ladding_bill
        {
            get { return _ladding_bill; }
            set { _ladding_bill = value; RaisePropertyChanged("ladding_bill"); }
        }

        private Nullable<System.DateTime> _ladding_date;
        public Nullable<System.DateTime> ladding_date
        {
            get { return _ladding_date; }
            set { _ladding_date = value; RaisePropertyChanged("ladding_date"); }
        }

        private Nullable<decimal> _wt_goods;
        public Nullable<decimal> wt_goods
        {
            get { return _wt_goods; }
            set { _wt_goods = value; RaisePropertyChanged("wt_goods"); }
        }
        private decimal? _gross_wt;
        public decimal? gross_wt
        {
            get { return _gross_wt; }
            set { _gross_wt = value; RaisePropertyChanged("gross_wt", ModelEntityUpdated); }
        }

        private decimal? _net_wt;
        public decimal? net_wt
        {
            get { return _net_wt; }
            set { _net_wt = value; RaisePropertyChanged("net_wt", ModelEntityUpdated); }
        }

        private Nullable<decimal> _net_weight;
        public Nullable<decimal> net_weight
        {
            get { return _net_weight; }
            set { _net_weight = value; RaisePropertyChanged("net_weight"); }
        }

        private Nullable<decimal> _volume;
        public Nullable<decimal> volume
        {
            get { return _volume; }
            set { _volume = value; RaisePropertyChanged("volume"); }
        }

        private string _weight_unit;
        public string weight_unit
        {
            get { return _weight_unit; }
            set { _weight_unit = value; RaisePropertyChanged("weight_unit"); }
        }

        private string _volume_unit;
        public string volume_unit
        {
            get { return _volume_unit; }
            set { _volume_unit = value; RaisePropertyChanged("volume_unit"); }
        }

        private string _report_name;
        public string report_name
        {
            get { return _report_name; }
            set { _report_name = value; RaisePropertyChanged("report_name"); }
        }

        private int? _no_of_packages;
        public int? no_of_packages
        {
            get { return _no_of_packages; }
            set { _no_of_packages = value; RaisePropertyChanged("no_of_packages"); }
        }

        private Nullable<System.DateTime> _loading_datetime;
        public Nullable<System.DateTime> loading_datetime
        {
            get { return _loading_datetime; }
            set { _loading_datetime = value; RaisePropertyChanged("loading_datetime"); }
        }

        private string _cost_center;
        public string cost_center
        {
            get { return _cost_center; }
            set { _cost_center = value; RaisePropertyChanged("cost_center"); }
        }

        private string _profit_center;
        public string profit_center
        {
            get { return _profit_center; }
            set { _profit_center = value; RaisePropertyChanged("profit_center"); }
        }

        private Nullable<decimal> _net_value;
        public Nullable<decimal> net_value
        {
            get { return _net_value; }
            set { _net_value = value; RaisePropertyChanged("net_value"); }
        }

        private Nullable<decimal> _round_up;
        public Nullable<decimal> round_up
        {
            get { return _round_up; }
            set { _round_up = value; RaisePropertyChanged("round_up"); }
        }

        private string _curr_code;
        public string curr_code
        {
            get { return _curr_code; }
            set { _curr_code = value; RaisePropertyChanged("curr_code"); }
        }

        private Nullable<decimal> _exchange_rate;
        public Nullable<decimal> exchange_rate
        {
            get { return _exchange_rate; }
            set { _exchange_rate = value; RaisePropertyChanged("exchange_rate"); }
        }

        private Nullable<System.DateTime> _invoice_date;
        public Nullable<System.DateTime> invoice_date
        {
            get { return _invoice_date; }
            set { _invoice_date = value; RaisePropertyChanged("invoice_date"); }
        }

        private string _tz_del_loc;
        public string tz_del_loc
        {
            get { return _tz_del_loc; }
            set { _tz_del_loc = value; RaisePropertyChanged("tz_del_loc"); }
        }

        private string _tz_rec_loc;
        public string tz_rec_loc
        {
            get { return _tz_rec_loc; }
            set { _tz_rec_loc = value; RaisePropertyChanged("tz_rec_loc"); }
        }

        private string _delivery_status;
        public string delivery_status
        {
            get { return _delivery_status; }
            set { _delivery_status = value; RaisePropertyChanged("delivery_status"); }
        }

        private string _so_code;
        public string so_code
        {
            get { return _so_code; }
            set { _so_code = value; RaisePropertyChanged("so_code"); }
        }

        private string _dc_code;
        public string dc_code
        {
            get { return _dc_code; }
            set { _dc_code = value; RaisePropertyChanged("dc_code"); }
        }

        private string _div_code;
        public string div_code
        {
            get { return _div_code; }
            set { _div_code = value; RaisePropertyChanged("div_code"); }
        }

        private string _soff_code;
        public string soff_code
        {
            get { return _soff_code; }
            set { _soff_code = value; RaisePropertyChanged("soff_code"); }
        }

        private string _sg_code;
        public string sg_code
        {
            get { return _sg_code; }
            set { _sg_code = value; RaisePropertyChanged("sg_code"); }
        }

        private string _bus_area;
        public string bus_area
        {
            get { return _bus_area; }
            set { _bus_area = value; RaisePropertyChanged("bus_area"); }
        }

        private Nullable<bool> _goods_issue;
        public Nullable<bool> goods_issue
        {
            get { return _goods_issue; }
            set { _goods_issue = value; RaisePropertyChanged("goods_issue"); }
        }

        private Nullable<System.DateTime> _goods_issue_date;
        public Nullable<System.DateTime> goods_issue_date
        {
            get { return _goods_issue_date; }
            set { _goods_issue_date = value; RaisePropertyChanged("goods_issue_date"); }
        }

        private string _bill_doc;
        public string bill_doc
        {
            get { return _bill_doc; }
            set { _bill_doc = value; RaisePropertyChanged("bill_doc"); }
        }

        private string _description;
        public string description
        {
            get { return _description; }
            set { _description = value; RaisePropertyChanged("description"); }
        }

        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }
        }

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }

        private string _location_Id;
        //[Required(ErrorMessage = "Field 'Supplying Plant' is required.")]
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id"); }
        }

        private string _wa_code;
        public string wa_code
        {
            get { return _wa_code; }
            set { _wa_code = value; RaisePropertyChanged("wa_code"); }
        }

        private string _store_code;
        public string store_code
        {
            get { return _store_code; }
            set { _store_code = value; RaisePropertyChanged("store_code"); }
        }

        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }

        private System.DateTime _add_date;
        public System.DateTime add_date
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

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
        }

        private string _mov_tp;
        public string mov_tp
        {
            get { return _mov_tp; }
            set { _mov_tp = value; RaisePropertyChanged("mov_tp"); }
        }

        private string _mov_tpw;
        public string mov_tpw
        {
            get { return _mov_tpw; }
            set { _mov_tpw = value; RaisePropertyChanged("mov_tpw"); }
        }

        private Nullable<System.DateTime> _act_move;
        public Nullable<System.DateTime> act_move
        {
            get { return _act_move; }
            set { _act_move = value; RaisePropertyChanged("act_move"); }
        }

        private string _del_block;
        public string del_block
        {
            get { return _del_block; }
            set { _del_block = value; RaisePropertyChanged("del_block"); }
        }

        private string _bill_block;
        public string bill_block
        {
            get { return _bill_block; }
            set { _bill_block = value; RaisePropertyChanged("bill_block"); }
        }

        private Nullable<System.DateTime> _bill_date;
        public Nullable<System.DateTime> bill_date
        {
            get { return _bill_date; }
            set { _bill_date = value; RaisePropertyChanged("bill_date"); }
        }

        private Nullable<System.DateTime> _pod_date;
        public Nullable<System.DateTime> pod_date
        {
            get { return _pod_date; }
            set { _pod_date = value; RaisePropertyChanged("pod_date"); }
        }

        private string _incoterms;
        public string incoterms
        {
            get { return _incoterms; }
            set { _incoterms = value; RaisePropertyChanged("incoterms"); }
        }
        private string _incoterm2;
        public string incoterm2
        {
            get { return _incoterm2; }
            set { _incoterm2 = value; RaisePropertyChanged("incoterm2"); }
        }

        private string _rec_plant;
        // [Required(ErrorMessage = "Field 'Receiving Plant' is required.")]
        public string rec_plant
        {
            get { return _rec_plant; }
            set { _rec_plant = value; RaisePropertyChanged("rec_plant", ModelEntityUpdated); }
        }

        private string _ref_docno;
        public string ref_docno
        {
            get { return _ref_docno; }
            set { _ref_docno = value; RaisePropertyChanged("ref_docno"); }
        }

        private string _ref_doc_type;
        public string ref_doc_type
        {
            get { return _ref_doc_type; }
            set { _ref_doc_type = value; RaisePropertyChanged("ref_doc_type"); }
        }

        private string _ref_doc_cat;
        public string ref_doc_cat
        {
            get { return _ref_doc_cat; }
            set { _ref_doc_cat = value; RaisePropertyChanged("ref_doc_cat"); }
        }
        private string _ship_status;
        public string ship_status
        {
            get { return _ship_status; }
            set { _ship_status = value; RaisePropertyChanged("ship_status"); }
        }

        private string _insp_status;
        public string insp_status
        {
            get { return _insp_status; }
            set { _insp_status = value; RaisePropertyChanged("insp_status"); }
        }

        private string _pre_carrage;
        public string pre_carrage
        {
            get { return _pre_carrage; }
            set { _pre_carrage = value; RaisePropertyChanged("pre_carrage"); }
        }

        private string _pre_carrage_place;
        public string pre_carrage_place
        {
            get { return _pre_carrage_place; }
            set { _pre_carrage_place = value; RaisePropertyChanged("pre_carrage_place"); }
        }

        private string _country_code;
        public string country_code
        {
            get { return _country_code; }
            set { _country_code = value; RaisePropertyChanged("country_code"); }
        }

        private string _port_load;
        public string port_load
        {
            get { return _port_load; }
            set { _port_load = value; RaisePropertyChanged("port_load"); }
        }

        private string _port_desc;
        public string port_desc
        {
            get { return _port_desc; }
            set { _port_desc = value; RaisePropertyChanged("port_desc"); }
        }

        private string _port_final;
        public string port_final
        {
            get { return _port_final; }
            set { _port_final = value; RaisePropertyChanged("port_final"); }
        }

        private string _final_dest;
        public string final_dest
        {
            get { return _final_dest; }
            set { _final_dest = value; RaisePropertyChanged("final_dest"); }
        }

        private string _ship_terms;
        public string ship_terms
        {
            get { return _ship_terms; }
            set { _ship_terms = value; RaisePropertyChanged("ship_terms"); }
        }

        private string _cf_agent_code;
        public string cf_agent_code
        {
            get { return _cf_agent_code; }
            set { _cf_agent_code = value; RaisePropertyChanged("cf_agent_code"); }
        }

        private string _lic_cod;
        public string lic_cod
        {
            get { return _lic_cod; }
            set { _lic_cod = value; RaisePropertyChanged("lic_cod"); }
        }

        private string _advance_lic;
        public string advance_lic
        {
            get { return _advance_lic; }
            set { _advance_lic = value; RaisePropertyChanged("advance_lic"); }
        }

        private string _origion_country;
        public string origion_country
        {
            get { return _origion_country; }
            set { _origion_country = value; RaisePropertyChanged("origion_country"); }
        }

        private string _pack_rem;
        public string pack_rem
        {
            get { return _pack_rem; }
            set { _pack_rem = value; RaisePropertyChanged("pack_rem"); }
        }

        private string _ship_mark;
        public string ship_mark
        {
            get { return _ship_mark; }
            set { _ship_mark = value; RaisePropertyChanged("ship_mark"); }
        }

        private string _vess_flight;
        public string vess_flight
        {
            get { return _vess_flight; }
            set { _vess_flight = value; RaisePropertyChanged("vess_flight"); }
        }

        private string _cntrl_no;
        public string cntrl_no
        {
            get { return _cntrl_no; }
            set { _cntrl_no = value; RaisePropertyChanged("cntrl_no"); }
        }

        private string _packing_no;
        public string packing_no
        {
            get { return _packing_no; }
            set { _packing_no = value; RaisePropertyChanged("packing_no"); }
        }

        private Nullable<int> _bill_address_id;
        public Nullable<int> bill_address_id
        {
            get { return _bill_address_id; }
            set { _bill_address_id = value; RaisePropertyChanged("bill_address_id"); }
        }

        private Nullable<int> _del_address;
        public Nullable<int> del_address
        {
            get { return _del_address; }
            set { _del_address = value; RaisePropertyChanged("del_address"); }
        }

        private string _KindOfPkgs;
        public string KindOfPkgs
        {
            get { return _KindOfPkgs; }
            set { _KindOfPkgs = value; RaisePropertyChanged("KindOfPkgs"); }
        }

        private string _marksAndNos;
        public string marksAndNos
        {
            get { return _marksAndNos; }
            set { _marksAndNos = value; RaisePropertyChanged("marksAndNos"); }
        }

        private Nullable<bool> _road_permit;
        public Nullable<bool> road_permit
        {
            get { return _road_permit; }
            set { _road_permit = value; RaisePropertyChanged("road_permit"); }
        }

        private string _permit_no;
        public string permit_no
        {
            get { return _permit_no; }
            set { _permit_no = value; RaisePropertyChanged("permit_no"); }
        }

        private Nullable<System.DateTime> _permit_date;
        public Nullable<System.DateTime> permit_date
        {
            get { return _permit_date; }
            set { _permit_date = value; RaisePropertyChanged("permit_date"); }
        }

        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set { _doc_type = value; RaisePropertyChanged("doc_type"); }
        }
        private string _fin_year;
        public string fin_year
        {
            get
            {
                return _fin_year;
            }

            set
            {
                _fin_year = value; RaisePropertyChanged("fin_year");
            }
        }

        private string _posting_period;
        public string posting_period
        {
            get
            {
                return _posting_period;
            }

            set
            {
                _posting_period = value; RaisePropertyChanged("posting_period");
            }
        }

        private string _EmpId;
        public string EmpId
        {
            get { return _EmpId; }
            set { _EmpId = value; RaisePropertyChanged("EmpId"); }
        }
        private string _ContPersnNm;
        public string ContPersnNm
        {
            get { return _ContPersnNm; }
            set { _ContPersnNm = value; RaisePropertyChanged("ContPersnNm"); }
        }
        private string _PersnEmailId;
        public string PersnEmailId
        {
            get { return _PersnEmailId; }
            set { _PersnEmailId = value; RaisePropertyChanged("PersnEmailId"); }
        }
        private string _PersnPhNo;
        public string PersnPhNo
        {
            get { return _PersnPhNo; }
            set { _PersnPhNo = value; RaisePropertyChanged("PersnPhNo"); }

        }
        private string _doc_history_no;
        public string doc_history_no
        {
            get { return _doc_history_no; }
            set { _doc_history_no = value; RaisePropertyChanged("doc_history_no"); }
        }

        private string _status_remark;
        public string status_remark
        {
            get { return _status_remark; }
            set { _status_remark = value; RaisePropertyChanged("status_remark"); }
        }

        private string _rec_info;
        public string rec_info
        {
            get { return _rec_info; }
            set { _rec_info = value; RaisePropertyChanged("rec_info"); }
        }

        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set { _lang_key = value; RaisePropertyChanged("lang_key"); }
        }

        private string _bom_no;
        public string bom_no
        {
            get { return _bom_no; }
            set { _bom_no = value; RaisePropertyChanged("bom_no"); }
        }
        private string _PrintOption;
        public string PrintOption
        {
            get { return _PrintOption; }
            set { _PrintOption = value; RaisePropertyChanged("PrintOption"); }
        }

        private string _tr_mode;
        public string tr_mode
        {
            get { return _tr_mode; }
            set { _tr_mode = value; RaisePropertyChanged("tr_mode"); }
        }
        private string _tr_type;
        public string tr_type
        {
            get { return _tr_type; }
            set { _tr_type = value; RaisePropertyChanged("tr_type"); }
        }
        private string _tr_party;
        public string tr_party
        {
            get { return _tr_party; }
            set { _tr_party = value; RaisePropertyChanged("tr_party"); }
        }
        // Scalers

        private string _del_desc;
        public string del_desc
        {
            get { return _del_desc; }
            set
            {
                _del_desc = value;
                RaisePropertyChanged("del_desc");
            }
        }

        private string _soldpartynm;
        public string soldpartynm
        {
            get { return _soldpartynm; }
            set
            {
                _soldpartynm = value;
                RaisePropertyChanged("soldpartynm");
            }
        }

        private string _shippartynm;
        public string shippartynm
        {
            get { return _shippartynm; }
            set
            {
                _shippartynm = value;
                RaisePropertyChanged("shippartynm");
            }
        }

        private string _transporternm;
        public string transporternm
        {
            get { return _transporternm; }
            set
            {
                _transporternm = value;
                RaisePropertyChanged("transporternm");
            }
        }

        private string _dest_countrynm;
        public string dest_countrynm
        {
            get { return _dest_countrynm; }
            set
            {
                _dest_countrynm = value;
                RaisePropertyChanged("dest_countrynm");
            }
        }

        private string _cf_agentnm;
        public string cf_agentnm
        {
            get { return _cf_agentnm; }
            set
            {
                _cf_agentnm = value;
                RaisePropertyChanged("cf_agentnm");
            }
        }

        private string _epcgnm;
        public string epcgnm
        {
            get { return _epcgnm; }
            set
            {
                _epcgnm = value;
                RaisePropertyChanged("epcgnm");
            }
        }

        private string _adv_lic_nm;
        public string adv_lic_nm
        {
            get { return _adv_lic_nm; }
            set
            {
                _adv_lic_nm = value;
                RaisePropertyChanged("adv_lic_nm");
            }
        }

        private string _countrynm;
        public string countrynm
        {
            get { return _countrynm; }
            set
            {
                _countrynm = value;
                RaisePropertyChanged("countrynm");
            }
        }

        private string _sales_orgnm;                        // sales organization
        public string sales_orgnm
        {
            get { return _sales_orgnm; }
            set
            {
                _sales_orgnm = value;
                RaisePropertyChanged("sales_orgnm");
            }
        }

        private string _dcnm;                              // distribution channel
        public string dcnm
        {
            get { return _dcnm; }
            set
            {
                _dcnm = value;
                RaisePropertyChanged("dcnm");
            }
        }

        private string _divnm;                            // sales division
        public string divnm
        {
            get { return _divnm; }
            set
            {
                _divnm = value;
                RaisePropertyChanged("divnm");
            }
        }

        private string _sales_offnm;                  // sales office
        public string sales_offnm
        {
            get { return _sales_offnm; }
            set
            {
                _sales_offnm = value;
                RaisePropertyChanged("sales_offnm");
            }
        }

        private string _sgnm;                         // sales group
        public string sgnm
        {
            get { return _sgnm; }
            set
            {
                _sgnm = value;
                RaisePropertyChanged("sgnm");
            }
        }

        private string _currnm;
        public string currnm
        {
            get { return _currnm; }
            set
            {
                _currnm = value;
                RaisePropertyChanged("currnm");
            }
        }

        private string _bill_addloc;
        public string bill_addloc
        {
            get { return _bill_addloc; }
            set { _bill_addloc = value; RaisePropertyChanged("bill_addloc"); }
        }

        private string _del_addloc;
        public string del_addloc
        {
            get { return _del_addloc; }
            set { _del_addloc = value; RaisePropertyChanged("del_addloc"); }
        }

        private string _supplantnm;
        public string supplantnm
        {
            get { return _supplantnm; }
            set { _supplantnm = value; RaisePropertyChanged("supplantnm"); }
        }

        private string _recplantnm;
        public string recplantnm
        {
            get { return _recplantnm; }
            set { _recplantnm = value; RaisePropertyChanged("recplantnm"); }
        }

        private string _EmpName;
        public string EmpName
        {
            get { return _EmpName; }
            set { _EmpName = value; RaisePropertyChanged("EmpName"); }
        }

        private string _yr_ref_no;
        public string yr_ref_no
        {
            get { return _yr_ref_no; }
            set { _yr_ref_no = value; RaisePropertyChanged("yr_ref_no"); }
        }
        private Nullable<System.DateTime> _yr_ref_date;
        public Nullable<System.DateTime> yr_ref_date
        {
            get { return _yr_ref_date; }
            set { _yr_ref_date = value; RaisePropertyChanged("yr_ref_date"); }
        }
        private string _data1;
        public string data1
        {
            get { return _data1; }
            set { _data1 = value; RaisePropertyChanged("data1", ModelEntityUpdated); }
        }
        private string _t_display;
        public string t_display
        {
            get { return _t_display; }
            set { _t_display = value; RaisePropertyChanged("t_display"); }
        }
        private string _add_info;
        public string add_info
        {
            get { return _add_info; }
            set { _add_info = value; RaisePropertyChanged("add_info"); }
        }
        private string _way_bill_no;
        public string way_bill_no
        {
            get { return _way_bill_no; }
            set { _way_bill_no = value; RaisePropertyChanged("way_bill_no"); }
        }

        private Nullable<System.DateTime> _way_bill_date;
        public Nullable<System.DateTime> way_bill_date
        {
            get { return _way_bill_date; }
            set { _way_bill_date = value; RaisePropertyChanged("way_bill_date"); }
        }

        private Nullable<decimal> _way_bill_value;
        public Nullable<decimal> way_bill_value
        {
            get { return _way_bill_value; }
            set { _way_bill_value = value; RaisePropertyChanged("way_bill_value"); }
        }
        private string _add_code_del;
        public string add_code_del
        {
            get
            {
                return _add_code_del;
            }

            set
            {
                if (_add_code_del != value)
                {
                    _add_code_del = value; RaisePropertyChanged("add_code_del");
                }
            }
        }

        private string _add_code_bil;
        public string add_code_bil
        {
            get
            {
                return _add_code_bil;
            }

            set
            {
                if (_add_code_bil != value)
                {
                    _add_code_bil = value; RaisePropertyChanged("add_code_bil");
                }
            }
        }

        private string _add_del;
        public string add_del
        {
            get
            {
                return _add_del;
            }
            set
            {
                if (_add_del != value)
                {
                    _add_del = value; RaisePropertyChanged("add_del");
                }
            }
        }

        private string _doc_type_name;
        public string doc_type_name
        {
            get
            {
                return _doc_type_name;
            }

            set
            {
                if (_doc_type_name != value)
                {
                    _doc_type_name = value; RaisePropertyChanged("doc_type_name");
                }
            }
        }

        #region Filter Search Variables
        private DateTime? _Fltr_FrmDate;
        public DateTime? Fltr_FrmDate   //Production FrmDate
        {
            get { return _Fltr_FrmDate; }
            set
            {
                if (_Fltr_FrmDate != value)
                {
                    _Fltr_FrmDate = value;
                    RaisePropertyChanged("Fltr_FrmDate");
                }
            }
        }
        private DateTime? _Fltr_ToDate;
        public DateTime? Fltr_ToDate    //Production ToDate
        {

            get { return _Fltr_ToDate; }
            set
            {
                if (_Fltr_ToDate != value)
                {
                    _Fltr_ToDate = value;
                    RaisePropertyChanged("Fltr_ToDate");
                }
            }
        }
        private string _Fltr_t_status;
        public string Fltr_t_status
        {
            get { return _Fltr_t_status; }
            set
            {
                if (_Fltr_t_status != value)
                {
                    _Fltr_t_status = value;
                    RaisePropertyChanged("Fltr_t_status");
                }
            }
        }
        private string _Fltr_t_display;
        public string Fltr_t_display
        {
            get { return _Fltr_t_display; }
            set
            {
                if (_Fltr_t_display != value)
                {
                    _Fltr_t_display = value;
                    RaisePropertyChanged("Fltr_t_display");
                }
            }
        }
        private string _Fltr_doc_type;
        public string Fltr_doc_type
        {
            get { return _Fltr_doc_type; }
            set
            {
                if (_Fltr_doc_type != value)
                {
                    _Fltr_doc_type = value;
                    RaisePropertyChanged("Fltr_doc_type");
                }
            }
        }
        private bool _Fltr_active;
        public bool Fltr_active
        {
            get { return _Fltr_active; }
            set
            {
                if (_Fltr_active != value)
                {
                    _Fltr_active = value;
                    RaisePropertyChanged("Fltr_active");
                }
            }
        }
        private string _Fltr_PartyId;
        public string Fltr_PartyId
        {
            get { return _Fltr_PartyId; }
            set
            {
                if (_Fltr_PartyId != value)
                {
                    _Fltr_PartyId = value;
                    RaisePropertyChanged("Fltr_PartyId");
                }
            }
        }
        private string _Fltr_PartyNm;
        public string Fltr_PartyNm
        {
            get { return _Fltr_PartyNm; }
            set
            {
                if (_Fltr_PartyNm != value)
                {
                    _Fltr_PartyNm = value;
                    RaisePropertyChanged("Fltr_PartyNm");
                }
            }
        }

        #endregion

        // XML
        public string XmlDataDocument_LOG_T001_B { get; set; }
        public string XmlDataDocument_LOG_T001_C { get; set; }
        public string XmlDataDocument_LOG_T001_D { get; set; }
    }
    public class LOG_T001_B : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };


        private Nullable<System.DateTime> _cust_po_date;
        public Nullable<System.DateTime> cust_po_date
        {
            get { return _cust_po_date; }
            set { _cust_po_date = value; RaisePropertyChanged("cust_po_date"); }
        }

        private string _cust_po_no;
        public string cust_po_no
        {
            get { return _cust_po_no; }
            set { _cust_po_no = value; RaisePropertyChanged("cust_po_no"); }
        }
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }

        private string _delivery_no;
        public string delivery_no
        {
            get { return _delivery_no; }
            set { _delivery_no = value; RaisePropertyChanged("delivery_no"); }
        }

        private string _sono;
        public string sono
        {
            get { return _sono; }
            set { _sono = value; RaisePropertyChanged("sono"); }
        }

        private int _line_id;
        public int line_id
        {
            get { return _line_id; }
            set { _line_id = value; RaisePropertyChanged("line_id"); }
        }

        private string _item_cat;
        public string item_cat
        {
            get { return _item_cat; }
            set { _item_cat = value; RaisePropertyChanged("item_cat"); }
        }

        private string _ItemCode;
        [Required(ErrorMessage = "Field 'Item Code' is required.")]
        public string ItemCode
        {
            get { return _ItemCode; }
            set { _ItemCode = value; RaisePropertyChanged("ItemCode", ModelEntityUpdated); }
        }

        private string _Item_desc;
        [Required(ErrorMessage = "Field 'Item Description' is required.")]
        public string Item_desc
        {
            get { return _Item_desc; }
            set { _Item_desc = value; RaisePropertyChanged("Item_desc", ModelEntityUpdated); }
        }

        private decimal _qty;
        [Required(ErrorMessage = "Field 'Quantity' is required.")]
        public decimal qty
        {
            get { return _qty; }
            set { _qty = value; RaisePropertyChanged("qty", ModelEntityUpdated); }
        }

        private string _unit_code;
        [Required(ErrorMessage = "Field 'Unit' is required.")]
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code", ModelEntityUpdated); }
        }

        private string _insp_lot;
        public string insp_lot
        {
            get { return _insp_lot; }
            set { _insp_lot = value; RaisePropertyChanged("insp_lot"); }
        }

        private string _Partial_lot_no;
        public string partial_lot_no
        {
            get { return _Partial_lot_no; }
            set { _Partial_lot_no = value; RaisePropertyChanged("partial_lot_no"); }
        }

        private string _batch_no;
        public string batch_no
        {
            get { return _batch_no; }
            set { _batch_no = value; RaisePropertyChanged("batch_no"); }
        }

        private Nullable<bool> _goods_issue;
        public Nullable<bool> goods_issue
        {
            get { return _goods_issue; }
            set { _goods_issue = value; RaisePropertyChanged("goods_issue"); }
        }

        private string _bill_doc;
        public string bill_doc
        {
            get { return _bill_doc; }
            set { _bill_doc = value; RaisePropertyChanged("bill_doc"); }
        }

        private string _description;
        public string description
        {
            get { return _description; }
            set { _description = value; RaisePropertyChanged("description"); }
        }

        private decimal? _gross_wt;
        public decimal? gross_wt
        {
            get { return _gross_wt; }
            set { _gross_wt = value; RaisePropertyChanged("gross_wt", ModelEntityUpdated); }
        }

        private decimal? _net_wt;
        public decimal? net_wt
        {
            get { return _net_wt; }
            set { _net_wt = value; RaisePropertyChanged("net_wt", ModelEntityUpdated); }
        }

        private string _weight_unit;
        public string weight_unit
        {
            get { return _weight_unit; }
            set { _weight_unit = value; RaisePropertyChanged("weight_unit"); }
        }

        private decimal? _volume;
        public decimal? volume
        {
            get { return _volume; }
            set { _volume = value; RaisePropertyChanged("volume", ModelEntityUpdated); }
        }

        private string _volumeunit;
        public string volumeunit
        {
            get { return _volumeunit; }
            set { _volumeunit = value; RaisePropertyChanged("volumeunit"); }
        }
        private string _volume_unit;
        public string volume_unit
        {
            get { return _volume_unit; }
            set { _volume_unit = value; RaisePropertyChanged("volume_unit"); }
        }

        private Nullable<bool> _split_allowed;
        public Nullable<bool> split_allowed
        {
            get { return _split_allowed; }
            set { _split_allowed = value; RaisePropertyChanged("split_allowed"); }
        }

        private Nullable<bool> _block;
        public Nullable<bool> block
        {
            get { return _block; }
            set { _block = value; RaisePropertyChanged("block"); }
        }

        private string _cost_center;
        public string cost_center
        {
            get { return _cost_center; }
            set { _cost_center = value; RaisePropertyChanged("cost_center"); }
        }

        private string _so_item_code;
        public string so_item_code
        {
            get { return _so_item_code; }
            set { _so_item_code = value; RaisePropertyChanged("so_item_code"); }
        }

        private decimal? _convesion_factor;
        public decimal? convesion_factor
        {
            get { return _convesion_factor; }
            set { _convesion_factor = value; RaisePropertyChanged("convesion_factor"); }
        }

        private decimal? _net_price;
        public decimal? net_price
        {
            get { return _net_price; }
            set { _net_price = value; RaisePropertyChanged("net_price", ModelEntityUpdated); }
        }

        private string _curr_code;
        public string curr_code
        {
            get { return _curr_code; }
            set { _curr_code = value; RaisePropertyChanged("curr_code"); }
        }

        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set { _t_status = value; RaisePropertyChanged("t_status"); }
        }

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }

        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id"); }
        }

        private string _wa_code;
        public string wa_code
        {
            get { return _wa_code; }
            set { _wa_code = value; RaisePropertyChanged("wa_code"); }
        }

        private string _store_code;
        public string store_code
        {
            get { return _store_code; }
            set { _store_code = value; RaisePropertyChanged("store_code", ModelEntityUpdated); }
        }

        private string _storage_bin;
        public string storage_bin
        {
            get { return _storage_bin; }
            set { _storage_bin = value; RaisePropertyChanged("storage_bin"); }
        }

        private string _sku;
        public string sku
        {
            get { return _sku; }
            set { _sku = value; RaisePropertyChanged("sku"); }
        }
        private string _sku_desc;
        public string sku_desc
        {
            get { return _sku_desc; }
            set { _sku_desc = value; RaisePropertyChanged("sku_desc"); }
        }
        private string _mov_tp;
        public string mov_tp
        {
            get { return _mov_tp; }
            set { _mov_tp = value; RaisePropertyChanged("mov_tp"); }
        }

        private string _mov_tpw;
        public string mov_tpw
        {
            get { return _mov_tpw; }
            set { _mov_tpw = value; RaisePropertyChanged("mov_tpw"); }
        }

        private string _batch_no_ven;
        public string batch_no_ven
        {
            get { return _batch_no_ven; }
            set { _batch_no_ven = value; RaisePropertyChanged("batch_no_ven"); }
        }

        private string _org_doc;
        public string org_doc
        {
            get { return _org_doc; }
            set { _org_doc = value; RaisePropertyChanged("org_doc"); }
        }

        private string _origion_item;
        public string origion_item
        {
            get { return _origion_item; }
            set { _origion_item = value; RaisePropertyChanged("origion_item"); }
        }

        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set { _doc_cat = value; RaisePropertyChanged("doc_cat"); }
        }

        private string _profit_center;
        public string profit_center
        {
            get { return _profit_center; }
            set { _profit_center = value; RaisePropertyChanged("profit_center"); }
        }

        private string _order_no;
        public string order_no
        {
            get { return _order_no; }
            set { _order_no = value; RaisePropertyChanged("order_no"); }
        }

        private string _order_item_code;
        public string order_item_code
        {
            get { return _order_item_code; }
            set { _order_item_code = value; RaisePropertyChanged("order_item_code"); }
        }

        private string _ref_doc;
        public string ref_doc
        {
            get { return _ref_doc; }
            set { _ref_doc = value; RaisePropertyChanged("ref_doc"); }
        }

        private string _ref_doc_item_code;
        public string ref_doc_item_code
        {
            get { return _ref_doc_item_code; }
            set { _ref_doc_item_code = value; RaisePropertyChanged("ref_doc_item_code"); }
        }

        private string _ref_doc_type;
        public string ref_doc_type
        {
            get { return _ref_doc_type; }
            set { _ref_doc_type = value; RaisePropertyChanged("ref_doc_type"); }
        }

        private Nullable<bool> _relv_billing;
        public Nullable<bool> relv_billing
        {
            get { return _relv_billing; }
            set { _relv_billing = value; RaisePropertyChanged("relv_billing"); }
        }

        private string _int_art;
        public string int_art
        {
            get { return _int_art; }
            set { _int_art = value; RaisePropertyChanged("int_art"); }
        }

        private string _cons_post;
        public string cons_post
        {
            get { return _cons_post; }
            set { _cons_post = value; RaisePropertyChanged("cons_post"); }
        }

        private decimal? _net_value;
        public decimal? net_value
        {
            get { return _net_value; }
            set { _net_value = value; RaisePropertyChanged("net_value"); }
        }

        private string _sch_no;
        public string sch_no
        {
            get { return _sch_no; }
            set { _sch_no = value; RaisePropertyChanged("sch_no"); }
        }

        private string _mov_ind;
        public string mov_ind
        {
            get { return _mov_ind; }
            set { _mov_ind = value; RaisePropertyChanged("mov_ind"); }
        }

        private string _reciss_item;
        public string reciss_item
        {
            get { return _reciss_item; }
            set { _reciss_item = value; RaisePropertyChanged("reciss_item"); }
        }

        private string _reciss_plant;
        public string reciss_plant
        {
            get { return _reciss_plant; }
            set { _reciss_plant = value; RaisePropertyChanged("reciss_plant"); }
        }

        private string _reciss_sl;
        public string reciss_sl
        {
            get { return _reciss_sl; }
            set { _reciss_sl = value; RaisePropertyChanged("reciss_sl"); }
        }

        private string _reciss_batch;
        public string reciss_batch
        {
            get { return _reciss_batch; }
            set { _reciss_batch = value; RaisePropertyChanged("reciss_batch"); }
        }

        private string _glacc;
        public string glacc
        {
            get { return _glacc; }
            set { _glacc = value; RaisePropertyChanged("glacc"); }
        }

        private Nullable<System.DateTime> _mfg_date;
        public Nullable<System.DateTime> mfg_date
        {
            get { return _mfg_date; }
            set { _mfg_date = value; RaisePropertyChanged("mfg_date"); }
        }

        private Nullable<System.DateTime> _exp_date;
        public Nullable<System.DateTime> exp_date
        {
            get { return _exp_date; }
            set { _exp_date = value; RaisePropertyChanged("exp_date"); }
        }

        private string _ref_doc2;
        public string ref_doc2
        {
            get { return _ref_doc2; }
            set { _ref_doc2 = value; RaisePropertyChanged("ref_doc2"); }
        }

        private string _ref_doc_itemno;
        public string ref_doc_itemno
        {
            get { return _ref_doc_itemno; }
            set { _ref_doc_itemno = value; RaisePropertyChanged("ref_doc_itemno"); }
        }

        private Nullable<int> _reason;
        public Nullable<int> reason
        {
            get { return _reason; }
            set { _reason = value; RaisePropertyChanged("reason"); }
        }

        private string _del_cat;
        public string del_cat
        {
            get { return _del_cat; }
            set { _del_cat = value; RaisePropertyChanged("del_cat"); }
        }

        private string _pod_ind;
        public string pod_ind
        {
            get { return _pod_ind; }
            set { _pod_ind = value; RaisePropertyChanged("pod_ind"); }
        }

        private string _pod_con;
        public string pod_con
        {
            get { return _pod_con; }
            set { _pod_con = value; RaisePropertyChanged("pod_con"); }
        }

        private string _stock_trns;
        public string stock_trns
        {
            get { return _stock_trns; }
            set { _stock_trns = value; RaisePropertyChanged("stock_trns"); }
        }

        private string _del_copm;
        public string del_copm
        {
            get { return _del_copm; }
            set { _del_copm = value; RaisePropertyChanged("del_copm"); }
        }

        private string _ret_valid_from;
        public string ret_valid_from
        {
            get { return _ret_valid_from; }
            set { _ret_valid_from = value; RaisePropertyChanged("ret_valid_from"); }
        }

        private string _ret_valid_to;
        public string ret_valid_to
        {
            get { return _ret_valid_to; }
            set { _ret_valid_to = value; RaisePropertyChanged("ret_valid_to"); }
        }

        private string _country_code;
        public string country_code
        {
            get { return _country_code; }
            set { _country_code = value; RaisePropertyChanged("country_code"); }
        }

        private string _grade;
        public string grade
        {
            get { return _grade; }
            set { _grade = value; RaisePropertyChanged("grade"); }
        }

        private string _para1;
        public string para1
        {
            get { return _para1; }
            set { _para1 = value; RaisePropertyChanged("para1"); }
        }

        private string _para2;
        public string para2
        {
            get { return _para2; }
            set { _para2 = value; RaisePropertyChanged("para2"); }
        }

        private string _para3;
        public string para3
        {
            get { return _para3; }
            set { _para3 = value; RaisePropertyChanged("para3"); }
        }

        private string _para4;
        public string para4
        {
            get { return _para4; }
            set { _para4 = value; RaisePropertyChanged("para4"); }
        }

        private string _para5;
        public string para5
        {
            get { return _para5; }
            set { _para5 = value; RaisePropertyChanged("para5"); }
        }

        private string _marks;
        public string marks
        {
            get { return _marks; }
            set { _marks = value; RaisePropertyChanged("marks"); }
        }

        private string _container_no;
        public string container_no
        {
            get { return _container_no; }
            set { _container_no = value; RaisePropertyChanged("container_no"); }
        }

        private Nullable<int> _NoOfPkgs;
        public Nullable<int> NoOfPkgs
        {
            get { return _NoOfPkgs; }
            set { _NoOfPkgs = value; RaisePropertyChanged("NoOfPkgs", ModelEntityUpdated); }
        }

        private string _KindOfPkgs;
        public string KindOfPkgs
        {
            get { return _KindOfPkgs; }
            set { _KindOfPkgs = value; RaisePropertyChanged("KindOfPkgs"); }
        }

        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }

        private System.DateTime _add_date;
        public System.DateTime add_date
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

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
        }

        private string _fin_year;
        public string fin_year
        {
            get
            {
                return _fin_year;
            }

            set
            {
                _fin_year = value; RaisePropertyChanged("fin_year");
            }
        }
        private string _posting_period;
        public string posting_period
        {
            get
            {
                return _posting_period;
            }

            set
            {
                _posting_period = value; RaisePropertyChanged("posting_period");
            }
        }

        private string _bom_no;
        public string bom_no
        {
            get
            {
                return _bom_no;
            }

            set
            {
                _bom_no = value; RaisePropertyChanged("bom_no");
            }
        }

        private string _status_remark;
        public string status_remark
        {
            get
            {
                return _status_remark;
            }

            set
            {
                _status_remark = value; RaisePropertyChanged("status_remark");
            }
        }

        private string _gl_code;
        public string gl_code
        {
            get
            {
                return _gl_code;
            }

            set
            {
                _gl_code = value; RaisePropertyChanged("gl_code");
            }
        }

        private string _lang_key;
        public string lang_key
        {
            get
            {
                return _lang_key;
            }

            set
            {
                _lang_key = value; RaisePropertyChanged("lang_key");
            }
        }

        private Nullable<System.DateTime> _goods_issue_date;
        public Nullable<System.DateTime> goods_issue_date
        {
            get
            {
                return _goods_issue_date;
            }

            set
            {
                _goods_issue_date = value; RaisePropertyChanged("goods_issue_date");
            }
        }
        private int _so_item_line_id;
        public int so_item_line_id
        {
            get { return _so_item_line_id; }
            set
            {
                _so_item_line_id = value;
                RaisePropertyChanged("so_item_line_id");
            }
        }

        private int _so_item_row_id;
        public int so_item_row_id
        {
            get { return _so_item_row_id; }
            set
            {
                _so_item_row_id = value;
                RaisePropertyChanged("so_item_row_id");
            }
        }
        private int _ref_item_line_id;
        public int ref_item_line_id
        {
            get { return _ref_item_line_id; }
            set
            {
                _ref_item_line_id = value;
                RaisePropertyChanged("ref_item_line_id");
            }
        }
        private int _ref_item_row_id;
        public int ref_item_row_id
        {
            get { return _ref_item_row_id; }
            set
            {
                _ref_item_row_id = value;
                RaisePropertyChanged("ref_item_row_id");
            }
        }
        private int _sch_item_row_id;
        public int sch_item_row_id
        {
            get { return _sch_item_row_id; }
            set
            {
                _sch_item_row_id = value;
                RaisePropertyChanged("sch_item_row_id");
            }
        }
        private int? _order_item_row_id;
        public int? order_item_row_id
        {
            get { return _order_item_row_id; }
            set
            {
                _order_item_row_id = value;
                RaisePropertyChanged("order_item_row_id");
            }
        }
        private int? _grn_item_row_id;
        public int? grn_item_row_id
        {
            get { return _grn_item_row_id; }
            set
            {
                _grn_item_row_id = value;
                RaisePropertyChanged("grn_item_row_id");
            }
        }
        private int? _to_item_row_id;
        public int? to_item_row_id
        {
            get { return _to_item_row_id; }
            set
            {
                _to_item_row_id = value;
                RaisePropertyChanged("to_item_row_id");
            }
        }
        private string _order_doc_cat;
        public string order_doc_cat
        {
            get { return _order_doc_cat; }
            set
            {
                _order_doc_cat = value;
                RaisePropertyChanged("order_doc_cat");
            }
        }
        private string _ref_doc_cat;
        public string ref_doc_cat
        {
            get { return _ref_doc_cat; }
            set
            {
                _ref_doc_cat = value;
                RaisePropertyChanged("ref_doc_cat");
            }
        }
        // scalar

        private string _SubCatCode;
        public string SubCatCode
        {
            get { return _SubCatCode; }
            set
            {
                _SubCatCode = value;
                RaisePropertyChanged("SubCatCode");
            }
        }

        private Nullable<bool> _StockUnt;
        public Nullable<bool> StockUnt
        {
            get { return _StockUnt; }
            set
            {
                _StockUnt = value;
                RaisePropertyChanged("StockUnt");
            }
        }
        private string _textdata;
        public string textdata
        {
            get { return _textdata; }
            set
            {
                _textdata = value;
                RaisePropertyChanged("textdata");
            }
        }
        private string _t_display;
        public string t_display
        {
            get { return _t_display; }
            set { _t_display = value; RaisePropertyChanged("t_display"); }
        }
        private string _ind_batch_req;
        public string ind_batch_req
        {
            get { return _ind_batch_req; }
            set { _ind_batch_req = value; RaisePropertyChanged("ind_batch_req"); }
        }

        // Scaler
        private string _item_cat_code;
        public string item_cat_code
        {
            get { return _item_cat_code; }
            set { _item_cat_code = value; RaisePropertyChanged("item_cat_code"); }
        }
    }
    public class LOG_T001_C : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        public int id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value; RaisePropertyChanged("id");
            }
        }

        private string _delivery_no;
        public string delivery_no
        {
            get
            {
                return _delivery_no;
            }

            set
            {
                _delivery_no = value; RaisePropertyChanged("delivery_no");
            }
        }

        private string _ItemCode;
        public string ItemCode
        {
            get
            {
                return _ItemCode;
            }

            set
            {
                _ItemCode = value; RaisePropertyChanged("ItemCode");
            }
        }

        private string _sku;
        public string sku
        {
            get
            {
                return _sku;
            }

            set
            {
                _sku = value; RaisePropertyChanged("sku");
            }
        }

        private string _barcode;
        public string barcode
        {
            get
            {
                return _barcode;
            }

            set
            {
                _barcode = value; RaisePropertyChanged("barcode");
            }
        }

        private string _pack_no;
        public string pack_no
        {
            get
            {
                return _pack_no;
            }

            set
            {
                _pack_no = value; RaisePropertyChanged("pack_no");
            }
        }

        private string _batch_no;
        [Required(ErrorMessage = "Field 'Batch No' is required.")]
        public string batch_no
        {
            get
            {
                return _batch_no;
            }

            set
            {
                _batch_no = value; RaisePropertyChanged("batch_no", ModelEntityUpdated);
            }
        }

        private Nullable<decimal> _qty;
        [Required(ErrorMessage = "'Quantity' is required.")]
        public decimal? qty
        {
            get
            {
                return _qty;
            }

            set
            {
                _qty = value; RaisePropertyChanged("qty", ModelEntityUpdated);
            }
        }

        private string _unit_code;
        public string unit_code
        {
            get
            {
                return _unit_code;
            }

            set
            {
                _unit_code = value; RaisePropertyChanged("unit_code");
            }
        }

        private string _description;
        public string description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value; RaisePropertyChanged("description");
            }
        }

        private string _t_status;
        public string t_status
        {
            get
            {
                return _t_status;
            }

            set
            {
                _t_status = value; RaisePropertyChanged("t_status");
            }
        }

        private string _location_Id;
        public string location_Id
        {
            get
            {
                return _location_Id;
            }

            set
            {
                _location_Id = value; RaisePropertyChanged("location_Id");
            }
        }

        private string _wa_code;
        public string wa_code
        {
            get
            {
                return _wa_code;
            }

            set
            {
                _wa_code = value; RaisePropertyChanged("wa_code");
            }
        }

        private string _store_code;
        public string store_code
        {
            get
            {
                return _store_code;
            }

            set
            {
                _store_code = value; RaisePropertyChanged("store_code");
            }
        }

        private Nullable<bool> _active;
        public bool? active
        {
            get
            {
                return _active;
            }

            set
            {
                _active = value; RaisePropertyChanged("active");
            }
        }

        private string _add_by;
        public string add_by
        {
            get
            {
                return _add_by;
            }

            set
            {
                _add_by = value; RaisePropertyChanged("add_by");
            }
        }

        private System.DateTime _add_date;
        public DateTime add_date
        {
            get
            {
                return _add_date;
            }

            set
            {
                _add_date = value; RaisePropertyChanged("add_date");
            }
        }

        private string _editby;
        public string editby
        {
            get
            {
                return _editby;
            }

            set
            {
                _editby = value; RaisePropertyChanged("editby");
            }
        }

        private Nullable<System.DateTime> _edit_date;
        public DateTime? edit_date
        {
            get
            {
                return _edit_date;
            }

            set
            {
                _edit_date = value; RaisePropertyChanged("edit_date");
            }
        }

        private string _comp_code;
        public string comp_code
        {
            get
            {
                return _comp_code;
            }

            set
            {
                _comp_code = value; RaisePropertyChanged("comp_code");
            }
        }

        private string _ink_id;
        public string ink_id
        {
            get
            {
                return _ink_id;
            }

            set
            {
                _ink_id = value; RaisePropertyChanged("ink_id");
            }
        }

        private string _ild_id;
        public string ild_id
        {
            get
            {
                return _ild_id;
            }

            set
            {
                _ild_id = value; RaisePropertyChanged("ild_id");
            }
        }

        private string _grade;
        public string grade
        {
            get
            {
                return _grade;
            }

            set
            {
                _grade = value; RaisePropertyChanged("grade");
            }
        }

        private decimal? _net_wt;
        public decimal? net_wt
        {
            get
            {
                return _net_wt;
            }

            set
            {
                if (_net_wt != value)
                {
                    _net_wt = value;
                    RaisePropertyChanged("net_wt", ModelEntityUpdated);
                }
            }
        }

        private decimal? _gross_wt;
        public decimal? gross_wt
        {
            get
            {
                return _gross_wt;
            }

            set
            {
                if (_gross_wt != value)
                {
                    _gross_wt = value;
                    RaisePropertyChanged("gross_wt", ModelEntityUpdated);
                }
            }
        }

        private string _fin_year;
        public string fin_year
        {
            get
            {
                return _fin_year;
            }

            set
            {
                _fin_year = value; RaisePropertyChanged("fin_year");
            }
        }

        private string _posting_period;
        public string posting_period
        {
            get
            {
                return _posting_period;
            }

            set
            {
                _posting_period = value; RaisePropertyChanged("posting_period");
            }
        }
        //scalra
        private string _Ink;
        public string Ink
        {
            get
            {
                return _Ink;
            }

            set
            {
                _Ink = value; RaisePropertyChanged("Ink");
            }
        }
        private string _Ild;
        public string Ild
        {
            get
            {
                return _Ild;
            }

            set
            {
                _Ild = value; RaisePropertyChanged("Ild");
            }
        }
        private string _t_display;
        public string t_display
        {
            get { return _t_display; }
            set { _t_display = value; RaisePropertyChanged("t_display"); }
        }
        
        private int _del_item_row_id;
        public int del_item_row_id
        {
            get
            {
                return _del_item_row_id;
            }

            set
            {
                _del_item_row_id = value; RaisePropertyChanged("del_item_row_id");
            }
        }
        private int _line_id;
        public int line_id
        {
            get
            {
                return _line_id;
            }

            set
            {
                _line_id = value; RaisePropertyChanged("line_id");
            }
        }

    }
    public class MultipleContext_LOG_T001_A
    {
        public List<ADM_M028_P> PartyList { get; set; }//Party_Master
        public List<ADM_M028_D_P> PartyAddressList { get; set; }
        public List<ADM_M028_C_P> PartyContactList { get; set; }
        public List<Order_No_P> OrderList { get; set; }//Sales_Order
        public List<SYS_M005_P> DeliveryTypeList { get; set; }//delivery_type
        public List<SYS_M002_P> DocTypeList { get; set; }
        public List<ADM_M028_P> PartyTranList { get; set; }// PartySupplier
        public List<ADM_M037_P> CurrencyList { get; set; }//Currency Master
        public List<ADM_M001_A_P> SalesOrgList { get; set; }
        public List<ADM_M001_C_P> DistributionChannelList { get; set; }
        public List<ADM_M001_D_P> SalesDivisionList { get; set; }
        public List<ADM_M001_I_P> SalesOfficeList { get; set; }
        public List<ADM_M001_H_P> SalesGroupList { get; set; }
        public List<MM_M001_P> StoreLocList { get; set; }//Store_Loc
        public List<SYS_M003_P> ItemCategoryList { get; set; }//Item Master
        public List<ADM_M038_B_P> UomList { get; set; }// UOM_Master  
        public List<ADM_M012_P> CountryList { get; set; }  //Country Master     
        public List<ADM_M037_P> licList { get; set; }
        public List<ADM_M022_P> ItemList { get; set; } // Order Item Details
        public List<ADM_M030_P> ParamValueList { get; set; }//Flute Master
        public List<ADM_M031_P> ParameterList { get; set; } //Parameter Master
        public List<OrderDetails_P> OrderDataList { get; set; } // Order Load
        public List<MM_S003_P> BatchesList { get; set; } // Already Exist item Batches (like Batch Master)
        public List<LOG_T001_A> Delivery_Note { get; set; }//Delivery_Note
        public List<LOG_T001_A_FLIP> FlipGridList { get; set; }
        public ObservableCollection<LOG_T001_B> DelNoteItemDetails { get; set; }
        public ObservableCollection<LOG_T001_C> ItemBatchDetails { get; set; }
        public List<ADM_M038_C_P> ConFactorList { get; set; }
        public List<RptDeliveryNote> RptDeliveryNoteList { get; set; }
        public List<RptPackingList> RptPackingListList { get; set; }
        public List<EPR_T003_A_P> CartonsList { get; set; }
        public List<ADM_M024_P> SellerList { get; set; }
        public List<SYS_M002> DocCategoryList { get; set; }
        public List<ADM_M044_P> IncoTermsList { get; set; }
        public List<RptSalesInvoiceTax> RptSalesInvoiceTax { get; set; }
        public List<MM_T001_P> ReserveDateList { get; set; }
        public List<EPR_T003_S> SettingsList { get; set; }
        public List<Report_Data_P> Report_DataList2 { get; set; }
        public List<ADM_M0013> t_statusList { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<SYS_M026> TransportMode { get; set; }
        public List<OrderItemData> OrderItems { get; set; }
        public List<MM_S003_P> HandlingUnitList { get; set; }
        public List<EWayBill_document> EB_BillLists { get; set; }
        public List<EWayBill_itemList> EB_ItemList { get; set; }
        public List<STD_PARTY> STD_PLANT_PARTY_LIST { get; set; }
        public List<STD_MIS_BE> Batch_List { get; set; }
        public List<STD_LIST_BE> RESERVATION_LIST { get; set; }
    }
    public class LOG_T001_A_FLIP
    {
        public string delivery_no { get; set; }
        public Nullable<System.DateTime> delivery_date { get; set; }
        public string PartyId { get; set; }
        public string order_no { get; set; }
        public string delivery_type { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public Nullable<System.DateTime> invoice_date { get; set; }
        public string t_status { get; set; }
        public string del_desc { get; set; }
        public string soldpartynm { get; set; }
        public string recplantnm { get; set; }
        public string description { get; set; }
        public string EmpId { get; set; }
        public string t_display { get; set; }
        public string yr_ref_no { get; set; }

    }
    public class RptDeliveryNote
    {
        public string delivery_no { get; set; }
        public Nullable<DateTime> delivery_date { get; set; }
        public string delivery_type { get; set; }
        public string delivery_desc { get; set; }
        public string shipment_mode { get; set; }
        public string Sold_to_partyNm { get; set; }
        public string Sold_To_Party_add { get; set; }
        public string ship_to_PartyNm { get; set; }
        public string ship_To_Party_add { get; set; }
        public string TransporterNm { get; set; }
        public string ItemCode { get; set; }
        public string Item_desc { get; set; }
        public string unit_code { get; set; }
        public Nullable<decimal> qty { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public string sku { get; set; }
        public string sku_desc { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string pack_no { get; set; }
        public string PlantNm { get; set; }
        public string PlantAdd { get; set; }
        public string CSTNo { get; set; }
        public string VATNo { get; set; }
        public string service_tax_no { get; set; }
        public string PanNo { get; set; }
        public string ref_docno { get; set; }
        public string description { get; set; }
        public Nullable<DateTime> add_date { get; set; }
        public Nullable<DateTime> edit_date { get; set; }
        public string EmpName { get; set; }
        public string EmpPhNo { get; set; }
        public string EmpEmailId { get; set; }
        public string order_no { get; set; }
        // public string prepared_by { get; set; }
        public string ContPersnNm { get; set; }
        public string PersnEmailId { get; set; }
        public string PersnPhNo { get; set; }
        public byte[] authorised_signature { get; set; }
        public string bill_doc { get; set; }
        public Nullable<DateTime> doc_date { get; set; }
        public string cust_ref { get; set; }
        public Nullable<DateTime> cust_ref_date { get; set; }
        public string lr_no { get; set; }
        public Nullable<DateTime> lr_date { get; set; }
        public string sold_ph { get; set; }
        public string sold_fax { get; set; }
        public string sold_email { get; set; }
        public string form_type { get; set; }
        public Nullable<DateTime> VATDate { get; set; }
        public Nullable<DateTime> CSTDate { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public string grade { get; set; }
        public string ProdNm { get; set; }
        public int? NoOfPkgs { get; set; }
        public Nullable<decimal> qtyC { get; set; }
        public int? NoOfPkgsC { get; set; }
        public string ladding_bill { get; set; }
        public Nullable<DateTime> ladding_date { get; set; }
        public string yr_ref_no { get; set; }
        public Nullable<DateTime> yr_ref_date { get; set; }
        public string inkC { get; set; }
        public string ildC { get; set; }
        public string gradeC { get; set; }
        public string descriptionC { get; set; }
        public string EmpMobNo { get; set; }
        public string C_active { get; set; }
        public Nullable<decimal> gross_wt { get; set; }
        public Nullable<decimal> net_wt { get; set; }
        public string cf_agent_code { get; set; }
        public string cf_party { get; set; }
        public string cf_address { get; set; }
        public string board_line { get; set; }
        public string cf_fax { get; set; }
        public string cf_mobile { get; set; }
        public string cf_email { get; set; }
        public Nullable<decimal> invoice_amtr { get; set; }
        public Nullable<decimal> unit_price { get; set; }
        public string textdata { get; set; }
        public string no_ofpackages { get; set; }
        public Nullable<decimal> gross_wtC { get; set; }
        public string qty_wrd { get; set; }
        public string NoOfPkgs_wrd { get; set; }
        public string no_ofpackagesA { get; set; }
        public string gstinno { get; set; }
        public Nullable<System.DateTime> gstindate { get; set; }
        public string hs_code { get; set; }
        public string hsn_code { get; set; }
        public string hsn_code2 { get; set; }

        public string shipto_gstinno { get; set; }
        public Nullable<System.DateTime> shipto_gstindate { get; set; }
        public string soldto_buss_place { get; set; }
        public string shipto_buss_place { get; set; }
        //Added by Priya
        public string city1 { get; set; }
        public string StatName { get; set; }
        public string PinCode { get; set; }
        public string STP_state_code { get; set; }
        public string DTP_state_code { get; set; }
        public string data1 { get; set; }
        public string owner_name { get; set; }
        public string DEmp_PhNo { get; set; }
        public string DEmp_FaxNo { get; set; }
        public string DEmp_EmailId { get; set; }
        public string supp_PlantNm { get; set; }
        public string supp_PlantAdd { get; set; }
        public string status_remark { get; set; }
        public string delivery_type_desc { get; set; }
        public string soldto_ContPersnNm { get; set; }
        public string add_info { get; set; }
        public string weight_unit { get; set; }
        public string KindOfPkgs { get; set; }
        public decimal? gross_wt_A { get; set; }
        public decimal? net_wt_A { get; set; }
        public int? no_of_packages { get; set; }
        public string pack_rem { get; set; }
        public string ship_mark { get; set; }
    }
    public class RptPackingList
    {
        public string Sold_to_partyNm { get; set; }
        public string Sold_To_Party_add { get; set; }
        public string ship_to_PartyNm { get; set; }
        public string ship_To_Party_add { get; set; }
        public string Item_desc { get; set; }
        public string FaxNo { get; set; }
        public string PhNo { get; set; }
        public string country_code { get; set; }
        public string origion_country { get; set; }
        public Nullable<decimal> wt_goods { get; set; }
        public Nullable<decimal> net_weight { get; set; }
        public string ship_terms { get; set; }
        public string pre_carrage { get; set; }
        public string pre_carrage_place { get; set; }
        public string vess_flight { get; set; }
        public string port_load { get; set; }
        public string port_desc { get; set; }
        public string final_dest { get; set; }
        public Nullable<int> NoOfPkgs { get; set; }
        public string KindOfPkgs { get; set; }
        public Nullable<decimal> qty { get; set; }
        public string marks { get; set; }
        public string container_no { get; set; }
        public string p_term_code { get; set; }
        public string sono { get; set; }
        public Nullable<DateTime> sodate { get; set; }
        public string cust_ref { get; set; }
        public Nullable<DateTime> cust_ref_date { get; set; }
        public string shipment_mode { get; set; }
        public string bill_doc { get; set; }
        public Nullable<DateTime> bill_date { get; set; }
        public string ProdNm { get; set; }
        public string ItemCode { get; set; }
        public string description { get; set; }
        public Nullable<DateTime> add_date { get; set; }
        public Nullable<DateTime> edit_date { get; set; }
        public string order_no { get; set; }
        public string unit_code { get; set; }

        //Added By Priya
        public string incoterms { get; set; }
        public string incoterm2 { get; set; }
        public string inco_desc { get; set; }
        public string consignee_ph { get; set; }
        public string consignee_fax { get; set; }
        public string notify_nm { get; set; }
        public string notify_ph { get; set; }
        public string notify_address { get; set; }
        public string pack_rem { get; set; }
        public string stock_code { get; set; }
        public string stk { get; set; }
        public Nullable<DateTime> order_date { get; set; }
        public string no_of_packages { get; set; }
        public string ship_mark { get; set; }
        public string yr_ref_no { get; set; }
        public Nullable<DateTime> yr_ref_date { get; set; }
        public string ref_data { get; set; }
        public string ref_data2 { get; set; }
        public string awb_no { get; set; }
        public Nullable<DateTime> awb_date { get; set; }
        public string custom_no { get; set; }
        public Nullable<DateTime> custom_date { get; set; }
        public string proforma_no { get; set; }
        public Nullable<DateTime> proforma_date { get; set; }
        public string terms_of_delivery { get; set; }
        public string manual_item_desc { get; set; }
        public string manual_desc { get; set; }
        public string text_data { get; set; }
        public string ship_term { get; set; }
        public string packing_remark { get; set; }
        public string LoctnNm { get; set; }
        public string AddL1 { get; set; }
        public string AddL2 { get; set; }
        public string cityL { get; set; }
        public string stateNmL { get; set; }
        // Add By Santosh
        public Nullable<decimal> Ball_Weight { get; set; }
        public Nullable<decimal> Spring_Weight { get; set; }
        public string prodname { get; set; }
        public string ball_content { get; set; }
        public string spring_content { get; set; }
        public Nullable<decimal> noofball { get; set; }
        public Nullable<decimal> Tips_Weight { get; set; }
        public string hs_code2 { get; set; }
        public string data1 { get; set; }
        public Nullable<decimal> gross_wt { get; set; }
        public Nullable<decimal> net_wt { get; set; }
        public string reg_declaration { get; set; }
        public string declaration { get; set; }
        public string dec_code { get; set; }
        public string dec_desc { get; set; }
        public string rex_no { get; set; }
        public string end_use_code { get; set; }
        public string ad_code { get; set; }
        public string bank_name { get; set; }
        public string acc_number { get; set; }
        public string hs_code { get; set; }
        public string hsn_code { get; set; }
        public string hsn_code2 { get; set; }
        public string weight_unit { get; set; }
        public string notify_party_name2 { get; set; }
        public string notify_address2 { get; set; }
        public string lc_info { get; set; }
        public string lc_cond { get; set; }
        public string para5 { get; set; }
        public string para9 { get; set; }
        public string carton_count_from { get; set; }
        public string carton_count_to { get; set; }
        public string location_id { get; set; }
        public string location_id_reg { get; set; }//Registered Location from Company Master
        public string packing { get; set; }
        public string j_code { get; set; }
        public string contract_acc { get; set; }
        public string lic_name { get; set; }
    }
}

