using Reflection.BusinessEntity.ADM;
using Reflection.BusinessEntity.ReflectionSystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Reflection.BusinessEntity
{
    public class SEL_T004 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set {
                if (_doc_no != value)
                {
                    _doc_no = value; RaisePropertyChanged("doc_no");
                }
            }
        }
        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set {
                if (_doc_cat != value)
                {
                    _doc_cat = value; RaisePropertyChanged("doc_cat");
                }
            }
        }
        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set {
                if (_doc_type != value)
                {
                    _doc_type = value; RaisePropertyChanged("doc_type");
                }
            }
        }
        private Nullable<System.DateTime> _doc_date;
        public Nullable<System.DateTime> doc_date
        {
            get { return _doc_date; }
            set {
                if (_doc_date != value)
                {
                    _doc_date = value; RaisePropertyChanged("doc_date");
                }
            }
        }
       
        private string _wa_code;
        public string wa_code
        {
            get { return _wa_code; }
            set {
                if (_wa_code != value)
                {
                    _wa_code = value; RaisePropertyChanged("wa_code");
                }
            }
        }
        private string _mov_tp;
        public string mov_tp
        {
            get { return _mov_tp; }
            set {
                if (_mov_tp != value)
                {
                    _mov_tp = value; RaisePropertyChanged("mov_tp");
                }
            }
        }
        private string _mov_type_wh;
        public string mov_type_wh
        {
            get { return _mov_type_wh; }
            set {
                if (_mov_type_wh != value)
                {
                    _mov_type_wh = value; RaisePropertyChanged("mov_type_wh");
                }
            }
        }
        private string _to_priority;
        public string to_priority
        {
            get { return _to_priority; }
            set {
                if (_to_priority != value)
                {
                    _to_priority = value; RaisePropertyChanged("to_priority");
                }
            }
        }
        private string _shipping_type_name;
        public string shipping_type_name
        {
            get { return _shipping_type_name; }
            set
            {
                if (_shipping_type_name != value)
                {
                    _shipping_type_name = value; RaisePropertyChanged("shipping_type_name");
                }
            }
        }
        private string _to_time;
        public string to_time
        {
            get { return _to_time; }
            set {
                if (_to_time != value)
                {
                    _to_time = value; RaisePropertyChanged("to_time");
                }
            }
        }
        private string _sgroup;
        public string sgroup
        {
            get { return _sgroup; }
            set {
                if (_sgroup != value)
                {
                    _sgroup = value; RaisePropertyChanged("sgroup");
                }
            }
        }

        private string _to_req_no;
        public string to_req_no
        {
            get { return _to_req_no; }
            set {
                if (_to_req_no != value)
                {
                    _to_req_no = value; RaisePropertyChanged("to_req_no");
                }
            }
        }
        private string _delivery_no;
        [Required(ErrorMessage = "Field 'delivery_no' is required.")]
        public string delivery_no
        {
            get { return _delivery_no; }
            set {
                if (_delivery_no != value)
                {
                    _delivery_no = value; RaisePropertyChanged("delivery_no", ModelEntityUpdated);
                }
            }
        }
        private string _confirm_ind;
        public string confirm_ind
        {
            get { return _confirm_ind; }
            set {
                if (_confirm_ind != value)
                {
                    _confirm_ind = value; RaisePropertyChanged("confirm_ind");
                }
            }
        }
        private Nullable<System.DateTime> _confirm_date;
        public Nullable<System.DateTime> confirm_date
        {
            get { return _confirm_date; }
            set {
                if (_confirm_date != value)
                {
                    _confirm_date = value; RaisePropertyChanged("confirm_date");
                }
            }
        }
        private string _mat_doc_no;
        public string mat_doc_no
        {
            get { return _mat_doc_no; }
            set {
                if (_mat_doc_no != value)
                {
                    _mat_doc_no = value; RaisePropertyChanged("mat_doc_no");
                }
            }
        }

        private Nullable<int> _mat_doc_year;
        public Nullable<int> mat_doc_year
        {
            get { return _mat_doc_year; }
            set {
                if (_mat_doc_year != value)
                {
                    _mat_doc_year = value; RaisePropertyChanged("mat_doc_year");
                }
            }
        }
        private string _req_type;
        public string req_type
        {
            get { return _req_type; }
            set {
                if (_req_type != value)
                {
                    _req_type = value; RaisePropertyChanged("req_type");
                }
            }
        }

        private string _req_no;
        public string req_no
        {
            get { return _req_no; }
            set {
                if (_req_no != value)
                {
                    _req_no = value; RaisePropertyChanged("req_no");
                }
            }
        }
        private string _print_ind;
        public string print_ind
        {
            get { return _print_ind; }
            set {
                if (_print_ind != value)
                {
                    _print_ind = value; RaisePropertyChanged("print_ind");
                }
            }
        }
        private string _pre_plan_to;
        public string pre_plan_to
        {
            get { return _pre_plan_to; }
            set {
                if (_pre_plan_to != value)
                {
                    _pre_plan_to = value; RaisePropertyChanged("pre_plan_to");
                }
            }
        }
        private Nullable<System.DateTime> _plan_ex_date;
        public Nullable<System.DateTime> plan_ex_date
        {
            get { return _plan_ex_date; }
            set {
                if (_plan_ex_date != value)
                {
                    _plan_ex_date = value; RaisePropertyChanged("plan_ex_date");
                }
            }
        }
        private string _add_ref_no;
        public string add_ref_no
        {
            get { return _add_ref_no; }
            set {
                if (_add_ref_no != value)
                {
                    _add_ref_no = value; RaisePropertyChanged("add_ref_no");
                }
            }
        }
        private Nullable<decimal> _plan_time;
        public Nullable<decimal> plan_time
        {
            get { return _plan_time; }
            set {
                if (_plan_time != value)
                {
                    _plan_time = value; RaisePropertyChanged("plan_time");
                }
            }
        }
        private Nullable<decimal> _actual_time;
        public Nullable<decimal> actual_time
        {
            get { return _actual_time; }
            set {
                if (_actual_time != value)
                {
                    _actual_time = value; RaisePropertyChanged("actual_time");
                }
            }
        }
        private string _time_unit;
        public string time_unit
        {
            get { return _time_unit; }
            set {
                if (_time_unit != value)
                {
                    _time_unit = value; RaisePropertyChanged("time_unit");
                }
            }
        }
        private Nullable<System.DateTime> _start_date;
        public Nullable<System.DateTime> start_date
        {
            get { return _start_date; }
            set {
                if (_start_date != value)
                {
                    _start_date = value; RaisePropertyChanged("start_date");
                }
            }
        }
        private Nullable<System.DateTime> _end_date;
        public Nullable<System.DateTime> end_date
        {
            get { return _end_date; }
            set {
                if (_end_date != value)
                {
                    _end_date = value; RaisePropertyChanged("end_date");
                }
            }
        }
        private string _start_time;
        public string start_time
        {
            get { return _start_time; }
            set {
                if (_start_time != value)
                {
                    _start_time = value; RaisePropertyChanged("start_time");
                }
            }
        }
        private string _end_time;
        public string end_time
        {
            get { return _end_time; }
            set {
                if (_end_time != value)
                {
                    _end_time = value; RaisePropertyChanged("end_time");
                }
            }
        }
        private string _wh_door;
        public string wh_door
        {
            get { return _wh_door; }
            set {
                if (_wh_door != value)
                {
                    _wh_door = value; RaisePropertyChanged("wh_door");
                }
            }
        }
        private string _wh_staging_area;
        public string wh_staging_area
        {
            get { return _wh_staging_area; }
            set {
                if (_wh_staging_area != value)
                {
                    _wh_staging_area = value; RaisePropertyChanged("wh_staging_area");
                }
            }
        }
        private Nullable<int> _th_act_time;
        public Nullable<int> th_act_time
        {
            get { return _th_act_time; }
            set {
                if (_th_act_time != value)
                {
                    _th_act_time = value; RaisePropertyChanged("th_act_time");
                }
            }
        }
        private string _sd_doc_cat;
        public string sd_doc_cat
        {
            get { return _sd_doc_cat; }
            set {
                if (_sd_doc_cat != value)
                {
                    _sd_doc_cat = value; RaisePropertyChanged("sd_doc_cat");
                }
            }
        }
        private string _queue;
        public string queue
        {
            get { return _queue; }
            set {
                if (_queue != value)
                {
                    _queue = value; RaisePropertyChanged("queue");
                }
            }
        }
        private string _pick_confirm;
        public string pick_confirm
        {
            get { return _pick_confirm; }
            set {
                if (_pick_confirm != value)
                {
                    _pick_confirm = value; RaisePropertyChanged("pick_confirm");
                }
            }
        }
        private Nullable<int> _item_no_curr;
        public Nullable<int> item_no_curr
        {
            get { return _item_no_curr; }
            set {
                if (_item_no_curr != value)
                {
                    _item_no_curr = value; RaisePropertyChanged("item_no_curr");
                }
            }
        }
        private string _confirm_delivery;
        public string confirm_delivery
        {
            get { return _confirm_delivery; }
            set {
                if (_confirm_delivery != value)
                {
                    _confirm_delivery = value; RaisePropertyChanged("confirm_delivery");
                }
            }
        }
        private string _to_multiple;
        public string to_multiple
        {
            get { return _to_multiple; }
            set {
                if (_to_multiple != value)
                {
                    _to_multiple = value; RaisePropertyChanged("to_multiple");
                }
            }
        }
        private string _to_note;
        public string to_note
        {
            get { return _to_note; }
            set {
                if (_to_note != value)
                {
                    _to_note = value; RaisePropertyChanged("to_note");
                }
            }
        }
        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set {
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
            set {
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
            set {
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
            set {
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
            set {
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
            set {
                if (_edit_date != value)
                {
                    _edit_date = value; RaisePropertyChanged("_edit_date");
                }
            }
        }
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set {
                if (_location_Id != value)
                {
                    _location_Id = value; RaisePropertyChanged("location_Id");
                }
            }
        }
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set {
                if (_comp_code != value)
                {
                    _comp_code = value; RaisePropertyChanged("comp_code");
                }
            }
        }
        
        private string _fin_year;
        public string fin_year
        {
            get { return _fin_year; }
            set {
                if (_fin_year != value)
                {
                    _fin_year = value; RaisePropertyChanged("fin_year");
                }
            }
        }
        private string _posting_period;
        public string posting_period
        {
            get { return _posting_period; }
            set {
                if (_posting_period != value)
                {
                    _posting_period = value; RaisePropertyChanged("posting_period");
                }
            }
        }
        private string _ref_doc_cat;
        public string ref_doc_cat
        {
            get { return _ref_doc_cat; }
            set {
                if (_ref_doc_cat != value)
                {
                    _ref_doc_cat = value; RaisePropertyChanged("ref_doc_cat", ModelEntityUpdated);
                }
            }
        }

        private string _dispatch_time;
        public string dispatch_time
        {
            get { return _dispatch_time; }
            set {
                if (_dispatch_time != value)
                {
                    _dispatch_time = value; RaisePropertyChanged("dispatch_time");
                }
            }
        }

        private string _pickup_time;
        public string pickup_time
        {
            get { return _pickup_time; }
            set {
                if (_pickup_time != value)
                {
                    _pickup_time = value; RaisePropertyChanged("pickup_time");
                }
            }

        }

        private Nullable<System.DateTime> _way_bill_date;
        public Nullable <System.DateTime> way_bill_date
        {
            get { return _way_bill_date; }
            set {
                if (_way_bill_date != value)
                {
                    _way_bill_date = value; RaisePropertyChanged("way_bill_date");
                }
            }

        }

        private Nullable<System.DateTime> _client_del_receive_date;
        public Nullable<System.DateTime> client_del_receive_date
        {
            get { return _client_del_receive_date; }
            set {
                if (_client_del_receive_date != value)
                {
                    _client_del_receive_date = value; RaisePropertyChanged("client_del_receive_date");
                }
            }
        }

        private string _way_bill_no;
        public string way_bill_no
        {
            get { return _way_bill_no; }
            set {
                if (_way_bill_no != value)
                {
                    _way_bill_no = value; RaisePropertyChanged("way_bill_no");
                }
            }
        }

        private decimal? _way_bill_value;
        public decimal? way_bill_value
        {
            get { return _way_bill_value; }
            set {
                if (_way_bill_value != value)
                {
                    _way_bill_value = value; RaisePropertyChanged("way_bill_value");
                }
            }
        }

        private Nullable<System.DateTime> _order_date;
        public Nullable<System.DateTime> order_date
        {
            get { return _order_date; }
            set {
                if (_order_date != value)
                {
                    _order_date = value; RaisePropertyChanged("order_date");
                }
            }
        }
        //scalar

        private Nullable<System.DateTime> _SO_date;
        public Nullable<System.DateTime> SO_date
        {
            get { return _SO_date; }
            set {
                if (_SO_date != value)
                {
                    _SO_date = value; RaisePropertyChanged("SO_date");
                }
            }
        }

        private string _sono;
        public string sono
        {
            get { return _sono; }
            set
            {
                if (_sono != value)
                {
                    _sono = value;
                    RaisePropertyChanged("sono");
                }
            }
        }

        private string _wa_name;

        public string wa_name
        {
            get { return _wa_name; }
            set {
                if (_wa_name != value)
                {
                    _wa_name = value; RaisePropertyChanged("wa_name");
                }
            }
        }
        private string _mov_name;
        public string mov_name
        {
            get { return _mov_name; }
            set
            {
                if (_mov_name != value)
                {
                    _mov_name = value;
                    RaisePropertyChanged("mov_name");
                }
            }
        }
        private string _ship_to_party;
        public string ship_to_party
        {
            get { return _ship_to_party; }
            set
            {
                if (_ship_to_party != value)
                {
                    _ship_to_party = value;
                    RaisePropertyChanged("ship_to_party");
                }
            }
        }
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
        private string _del_address;
        public string del_address
        {
            get { return _del_address; }
            set
            {
                if (_del_address != value)
                {
                    _del_address = value;
                    RaisePropertyChanged("del_address");
                }
            }
        }
        private string _sold_to_party;
        public string sold_to_party
        {
            get { return _sold_to_party; }
            set
            {
                if (_sold_to_party != value)
                {
                    _sold_to_party = value;
                    RaisePropertyChanged("sold_to_party");
                }
            }
        }
        private string _ref_doc_no;
        public string ref_doc_no
        {
            get
            {
                return _ref_doc_no;
            }
            set
            {
                if (_ref_doc_no != value)
                {
                    _ref_doc_no = value; RaisePropertyChanged("ref_doc_no", ModelEntityUpdated);

                }
            }
        }
        private string _ref_doc_type;
        public string ref_doc_type
        {
            get { return _ref_doc_type; }
            set
            {
                if (_ref_doc_type != value)
                {
                    _ref_doc_type = value; RaisePropertyChanged("ref_doc_type", ModelEntityUpdated);
                }
            }
        }

        private string _ship_to_party_name;
        public string ship_to_party_name
        {
            get
            {
                return _ship_to_party_name;
            }

            set
            {
                if (_ship_to_party_name != value)
                {
                    _ship_to_party_name = value; RaisePropertyChanged("ship_to_party_name", ModelEntityUpdated);
                }
            }
        }

        private string _PartyId;
        public string PartyId
        {
            get
            {
                return _PartyId;
            }

            set
            {
                if (_PartyId != value)
                {
                    _PartyId = value; RaisePropertyChanged("PartyId", ModelEntityUpdated);
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

        private string _tr_party;
        public string tr_party
        {
            get
            {
                return _tr_party;
            }

            set
            {
                if (_tr_party != value)
                {
                    _tr_party = value; RaisePropertyChanged("tr_party");
                }
            }
        }

        private string _transporter_name;
        public string transporter_name
        {
            get
            {
                return _transporter_name;
            }

            set
            {
                if (_transporter_name != value)
                {
                    _transporter_name = value; RaisePropertyChanged("transporter_name", ModelEntityUpdated);
                }
            }
        }
        private string _shipping_mark;
        public string shipping_mark
        {
            get
            {
                return _shipping_mark;
            }

            set
            {
                if (_shipping_mark != value)
                {
                    _shipping_mark = value; RaisePropertyChanged("_shipping_mark", ModelEntityUpdated);
                }
            }
        }

        private string _ship_to_add;
        public string ship_to_add
        {
            get
            {
                return _ship_to_add;
            }

            set
            {
                if (_ship_to_add != value)
                {
                    _ship_to_add = value; RaisePropertyChanged("ship_to_add", ModelEntityUpdated);
                }
            }
        }

        private Nullable<System.DateTime> _dispatch_date;
        public Nullable<System.DateTime> dispatch_date
        {
            get { return _dispatch_date; }
            set
            {
                if (_dispatch_date != value)
                {
                    _dispatch_date = value; RaisePropertyChanged("dispatch_date");
                }
            }
        }
        private string _tr_mode;
        public string tr_mode
        {
            get { return _tr_mode; }
            set
            {
                if (_tr_mode != value)
                {
                    _tr_mode = value; RaisePropertyChanged("tr_mode");
                }
            }
        }
        private string _tr_type;
        public string tr_type
        {
            get { return _tr_type; }
            set
            {
                if (_tr_type != value)
                {
                    _tr_type = value; RaisePropertyChanged("tr_type");
                }
            }
        }
        private string _ts_code;
        public string ts_code
        {
            get { return _ts_code; }
            set
            {
                if (_ts_code != value)
                {
                    _ts_code = value; RaisePropertyChanged("ts_code");
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
                    _remark = value; RaisePropertyChanged("remark");
                }
            }
        }
        private string _ship_to_address_location;
        public string ship_to_address_location
        {
            get { return _ship_to_address_location; }
            set
            {
                if (_ship_to_address_location != value)
                {
                    _ship_to_address_location = value; RaisePropertyChanged("ship_to_address_location");
                }
            }
        }
        private string _add_info;
        public string add_info
        { get { return _add_info; }
           set
            {
                if (_add_info != value)
                {
                    _add_info = value; RaisePropertyChanged("add_info");
                }
            }
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

        private string _gstinno;
        public string gstinno
        {
            get { return _gstinno; }
            set
            {
                if (_gstinno != value)
                {
                    _gstinno = value; RaisePropertyChanged("gstinno");
                }
            }
        }
        public string XmlDataDocument_SEL_T004_A { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }

        #region Scalars for Filtering View
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
        private string _fltr_location_Id;
        public string fltr_location_Id
        {
            get { return _fltr_location_Id; }
            set
            {
                if (_fltr_location_Id != value)
                {
                    _fltr_location_Id = value; RaisePropertyChanged("fltr_location_Id");
                }
            }
        }

        private string _fltr_t_status;
        public string fltr_t_status
        {
            get { return _fltr_t_status; }
            set
            {
                if (_fltr_t_status != value)
                {
                    _fltr_t_status = value; RaisePropertyChanged("fltr_t_status");
                }
            }
        }

        private string _fltr_t_display;
        public string fltr_t_display
        {
            get { return _fltr_t_display; }
            set
            {
                if (_fltr_t_display != value)
                {
                    _fltr_t_display = value; RaisePropertyChanged("fltr_t_display");
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
                    _Fltr_PartyId = value; RaisePropertyChanged("Fltr_PartyId");
                }
            }
        }

        private string _fltr_SoldToPartyID;
        public string fltr_SoldToPartyID
        {
            get { return _fltr_SoldToPartyID; }
            set
            {
                if (_fltr_SoldToPartyID != value)
                {
                    _fltr_SoldToPartyID = value; RaisePropertyChanged("fltr_SoldToPartyID");
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
                    _Fltr_PartyNm = value; RaisePropertyChanged("Fltr_PartyNm");
                }
            }
        }

        private string _fltr_SoldToPartyNM;
        public string fltr_SoldToPartyNM
        {
            get { return _fltr_SoldToPartyNM; }
            set
            {
                if (_fltr_SoldToPartyNM != value)
                {
                    _fltr_SoldToPartyNM = value; RaisePropertyChanged("fltr_SoldToPartyNM");
                }
            }
        }

        private string _Fltr_SalesPersonID;
        public string Fltr_SalesPersonID
        {
            get { return _Fltr_SalesPersonID; }
            set
            {
                if (_Fltr_SalesPersonID != value)
                {
                    _Fltr_SalesPersonID = value; RaisePropertyChanged("Fltr_SalesPersonID");
                }
            }
        }

        private string _fltr_SalesPersonID;
        public string fltr_SalesPersonID
        {
            get { return _fltr_SalesPersonID; }
            set
            {
                if (_fltr_SalesPersonID != value)
                {
                    _fltr_SalesPersonID = value; RaisePropertyChanged("fltr_SalesPersonID");
                }
            }
        }



        private string _fltr_SalesPersonNM;
        public string fltr_SalesPersonNM
        {
            get { return _fltr_SalesPersonNM; }
            set
            {
                if (_fltr_SalesPersonNM != value)
                {
                    _fltr_SalesPersonNM = value; RaisePropertyChanged("fltr_SalesPersonNM");
                }
            }
        }

        private string _Fltr_SalesPersonNM;
        public string Fltr_SalesPersonNM
        {
            get { return _Fltr_SalesPersonNM; }
            set
            {
                if (_Fltr_SalesPersonNM != value)
                {
                    _Fltr_SalesPersonNM = value; RaisePropertyChanged("Fltr_SalesPersonNM");
                }
            }
        }

        private DateTime? _Fltr_FrmDate;
        public DateTime? Fltr_FrmDate   //FrmDate
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
        public DateTime? Fltr_ToDate    //ToDate
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
        
        #endregion 
    }
    public partial class SEL_T004_A:ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private Nullable<System.DateTime> _cust_po_date;
        public Nullable<System.DateTime> cust_po_date
        {
            get { return _cust_po_date; }
            set {
                if (_cust_po_date != value)
                {
                    _cust_po_date = value; RaisePropertyChanged("cust_po_date");
                }
            }
        }

        private int _line_id;
        public int line_id
        {
            get
            { return _line_id; }
            set
            {
                if (_line_id != value)
                {
                    _line_id = value; RaisePropertyChanged("line_id", ModelEntityUpdated);
                }
            }
        }

        private string _cust_po_no;
        public string cust_po_no
        {
            get { return _cust_po_no; }
            set {
                if (_cust_po_no != value)
                {
                    _cust_po_no = value; RaisePropertyChanged("cust_po_no");
                }
            }
        }
        private int _id;
        public int id
        {
            get { return _id; }
            set {
                if (_id != value)
                {
                    _id = value; RaisePropertyChanged("id");
                }
            }
        }
        
        private string _wa_code;
        public string wa_code
        {
            get { return _wa_code; }
            set {
                if (_wa_code != value)
                {
                    _wa_code = value; RaisePropertyChanged("wa_code");
                }
            }
        }
        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set {
                if (_doc_no != value)
                {
                    _doc_no = value; RaisePropertyChanged("doc_no");
                }
            }
        }
        private Nullable<int> _item_code;
        public Nullable<int> item_code
        {
            get { return _item_code; }
            set {
                if (_item_code != value)
                {
                    _item_code = value; RaisePropertyChanged("item_code");
                }
            }
        }
        private Nullable<int> _to_req_item;
        public Nullable<int> to_req_item
        {
            get { return _to_req_item; }
            set {
                if (_to_req_item != value)
                {
                    _to_req_item = value; RaisePropertyChanged("to_req_item");
                }
            }
        }
        private Nullable<int> _sd_item_no;
        public Nullable<int> sd_item_no
        {
            get { return _sd_item_no; }
            set {
                if (_sd_item_no != value)
                {
                    _sd_item_no = value; RaisePropertyChanged("sd_item_no");
                }
            }
        }
        private string _ItemCode;
        public string ItemCode
        {
            get { return _ItemCode; }
            set {
                if (_ItemCode != value)
                {
                    _ItemCode = value; RaisePropertyChanged("ItemCode");
                }
                }
        }
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set {
                if (_location_Id != value)
                {
                    _location_Id = value; RaisePropertyChanged("location_Id");
                }
            }
        }
        private string _batch_no;
        public string batch_no
        {
            get { return _batch_no; }
            set {
                if (_batch_no != value)
                {
                    _batch_no = value; RaisePropertyChanged("batch_no");
                }
            }
        }
        private string _stock_cat;
        public string stock_cat
        {
            get { return _stock_cat; }
            set {
                if (_stock_cat != value)
                {
                    _stock_cat = value; RaisePropertyChanged("stock_cat");
                }
                }
        }
        private string _sp_stock;
        public string sp_stock
        {
            get { return _sp_stock; }
            set {
                if (_sp_stock != value)
                {
                    _sp_stock = value; RaisePropertyChanged("sp_stock");
                }
            }
        }
        private string _sp_number;
        public string sp_number
        {
            get { return _sp_number; }
            set {
                if (_sp_number != value)
                {
                    _sp_number = value; RaisePropertyChanged("sp_number");
                }
            }
        }
        private string _haz_material;
        public string haz_material
        {
            get { return _haz_material; }
            set {
                if (_haz_material != value)
                {
                    _haz_material = value; RaisePropertyChanged("haz_material");
                }
            }
        }
        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set {
                if (_unit_code != value)
                {
                    _unit_code = value; RaisePropertyChanged("unit_code");
                }
            }
        }
        private string _unit_name;
        public string unit_name
        {
            get { return _unit_name; }
            set
            {
                if (_unit_name != value)
                {
                    _unit_name = value; RaisePropertyChanged("unit_name");
                }
            }
        }
        private string _sku;
        public string sku
        {
            get { return _sku; }
            set {
                if (_sku != value)
                {
                    _sku = value; RaisePropertyChanged("sku");
                }
            }
        }
        private string _sku_desc;
        public string sku_desc
        {
            get { return _sku_desc; }
            set {
                if (_sku_desc != value)
                {
                    _sku_desc = value; RaisePropertyChanged("sku_desc");
                }
            }
        }
        private string _unit_alt;
        public string unit_alt
        {
            get { return _unit_alt; }
            set {
                if (_unit_alt != value)
                {
                    _unit_alt = value; RaisePropertyChanged("unit_alt");
                }
            }
        }
        private Nullable<decimal> _c_factor;
        public Nullable<decimal> c_factor
        {
            get { return _c_factor; }
            set {
                if (_c_factor != value)
                {
                    _c_factor = value; RaisePropertyChanged("c_factor");
                }
            }
        }
        private Nullable<decimal> _denom;
        public Nullable<decimal> denom
        {
            get { return _denom; }
            set {
                if (_denom != value)
                {
                    _denom = value; RaisePropertyChanged("denom");
                }
            }
        }
        private string _storage_unit_type;
        public string storage_unit_type
        {
            get { return _storage_unit_type; }
            set {
                if (_storage_unit_type != value)
                {
                    _storage_unit_type = value; RaisePropertyChanged("storage_unit_type");
                }
            }
        }
        private string _pre_stock_ind;
        public string pre_stock_ind
        {
            get { return _pre_stock_ind; }
            set {
                if (_pre_stock_ind != value)
                {
                    _pre_stock_ind = value; RaisePropertyChanged("pre_stock_ind");
                }
            }
        }
        private Nullable<int> _sequence_item;
        public Nullable<int> sequence_item
        {
            get { return _sequence_item; }
            set {
                if (_sequence_item != value)
                {
                    _sequence_item = value; RaisePropertyChanged("sequence_item");
                }
            }
        }
        private string _confirm_req;
        public string confirm_req
        {
            get { return _confirm_req; }
            set {
                if (_confirm_req != value)
                {
                    _confirm_req = value; RaisePropertyChanged("confirm_req");
                }
            }
        }
        private string _confirm_complete_ind;
        public string confirm_complete_ind
        {
            get { return _confirm_complete_ind; }
            set {
                if (_confirm_complete_ind != value)
                {
                    _confirm_complete_ind = value; RaisePropertyChanged("confirm_complete_ind");
                }
            }
        }
        private Nullable<System.DateTime> _confirm_date;
        public Nullable<System.DateTime> confirm_date
        {
            get { return _confirm_date; }
            set {
                if (_confirm_date != value)
                {
                    _confirm_date = value; RaisePropertyChanged("confirm_date");
                }
            }
        }
        private string _confirm_time;
        public string confirm_time
        {
            get { return _confirm_time; }
            set {
                if (_confirm_time != value)
                {
                    _confirm_time = value; RaisePropertyChanged("confirm_time");
                }
            }
        }
        private Nullable<decimal> _gross_wt;
        public Nullable<decimal> gross_wt
        {
            get { return _gross_wt; }
            set {
                if (_gross_wt != value)
                {
                    _gross_wt = value; RaisePropertyChanged("gross_wt");
                }
            }
        }
        private Nullable<decimal> _net_wt;
        public Nullable<decimal> net_wt
        {
            get { return _net_wt; }
            set {
                if (_net_wt != value)
                {
                    _net_wt = value; RaisePropertyChanged("net_wt");
                }
            }
        }
        private string _weight_unit;
        public string weight_unit
        {
            get { return _weight_unit; }
            set {
                if (_weight_unit != value)
                {
                    _weight_unit = value; RaisePropertyChanged("weight_unit");
                }
            }
        }
        private Nullable<int> _item_mat_doc;
        public Nullable<int> item_mat_doc
        {
            get { return _item_mat_doc; }
            set {
                if (_item_mat_doc != value)
                {
                    _item_mat_doc = value; RaisePropertyChanged("item_mat_doc");
                }
            }
        }
        private string _gr_ship_to_party;
        public string gr_ship_to_party
        {
            get { return _gr_ship_to_party; }
            set {
                if (_gr_ship_to_party != value)
                {
                    _gr_ship_to_party = value; RaisePropertyChanged("gr_ship_to_party");
                }
            }
        }
        private string _unloading_point;
        public string unloading_point
        {
            get { return _unloading_point; }
            set {
                if (_unloading_point != value)
                {
                    _unloading_point = value; RaisePropertyChanged("unloading_point");
                }
            }
        }
        private Nullable<System.DateTime> _gr_date;
        public Nullable<System.DateTime> gr_date
        {
            get { return _gr_date; }
            set {
                if (_gr_date != value)
                {
                    _gr_date = value; RaisePropertyChanged("gr_date");
                }
            }
        }
        private string _gr_no;
        public string gr_no
        {
            get { return _gr_no; }
            set {
                if (_gr_no != value)
                {
                    _gr_no = value; RaisePropertyChanged("gr_no");
                }
            }
        }
        private Nullable<int> _gr_item;
        public Nullable<int> gr_item
        {
            get { return _gr_item; }
            set {
                if (_gr_item != value)
                {
                    _gr_item = value; RaisePropertyChanged("gr_item");
                }
            }
        }
        private string _cert_no;
        public string cert_no
        {
            get { return _cert_no; }
            set {
                if (_cert_no != value)
                {
                    _cert_no = value; RaisePropertyChanged("cert_no");
                }
            }
        }
        private string _trns_pro;
        public string trns_pro
        {
            get { return _trns_pro; }
            set {
                if (_trns_pro != value)
                {
                    _trns_pro = value; RaisePropertyChanged("trns_pro");
                }
            }
        }
        private string _storage_type;
        public string storage_type
        {
            get { return _storage_type; }
            set {
                if (_storage_type != value)
                {
                    _storage_type = value; RaisePropertyChanged("storage_type");
                }
            }
        }
        private string _storage_sec;
        public string storage_sec
        {
            get { return _storage_sec; }
            set {
                if (_storage_sec != value)
                {
                    _storage_sec = value; RaisePropertyChanged("storage_sec");
                }
            }
        }
        private string _storage_bin;
        public string storage_bin
        {
            get { return _storage_bin; }
            set {
                if (_storage_bin != value)
                {
                    _storage_bin = value; RaisePropertyChanged("storage_bin");
                }
            }
        }
        private Nullable<int> _quant;
        public Nullable<int> quant
        {
            get { return _quant; }
            set {
                if (_quant != value)
                {
                    _quant = value; RaisePropertyChanged("quant");
                }
            }
        }
        private string _dest_storage_type;
        public string dest_storage_type
        {
            get { return _dest_storage_type; }
            set {
                if (_dest_storage_type != value)
                {
                    _dest_storage_type = value; RaisePropertyChanged("dest_storage_type");
                }
            }
        }
        private string _dest_storage_sec;
        public string dest_storage_sec
        {
            get { return _dest_storage_sec; }
            set {
                if (_dest_storage_sec != value)
                {
                    _dest_storage_sec = value; RaisePropertyChanged("dest_storage_sec");
                }
            }
        }
        private string _dest_storage_bin;
        public string dest_storage_bin
        {
            get { return _dest_storage_bin; }
            set {
                if (_dest_storage_bin != value)
                {
                    _dest_storage_bin = value; RaisePropertyChanged("dest_storage_bin");
                }
            }
        }
        private string _pick_area;
        public string pick_area
        {
            get { return _pick_area; }
            set {
                if (_pick_area != value)
                {
                    _pick_area = value; RaisePropertyChanged("pick_area");
                }
            }
        }
        private string _store_code;
        public string store_code
        {
            get { return _store_code; }
            set {
                if (_store_code != value)
                {
                    _store_code = value; RaisePropertyChanged("store_code");
                }
            }
        }
        private string _store_name;
        public string store_name
        {
            get { return _store_name; }
            set
            {
                if (_store_name != value)
                {
                    _store_name = value; RaisePropertyChanged("store_name");
                }
            }
        }
        
        private Nullable<decimal> _volume;
        public Nullable<decimal> volume
        {
            get { return _volume; }
            set {
                if (_volume != value)
                {
                    _volume = value; RaisePropertyChanged("volume");
                }
            }
        }
        private string _volume_unit;
        public string volume_unit
        {
            get { return _volume_unit; }
            set {
                if (_volume_unit != value)
                {
                    _volume_unit = value; RaisePropertyChanged("volume_unit");
                }
            }
        }
        private string _pick_confirm;
        public string pick_confirm
        {
            get { return _pick_confirm; }
            set {
                if (_pick_confirm != value)
                {
                    _pick_confirm = value; RaisePropertyChanged("pick_confirm");
                }
            }
        }
        private Nullable<System.DateTime> _pick_confirm_date;
        public Nullable<System.DateTime> pick_confirm_date
        {
            get { return _pick_confirm_date; }
            set {
                if (_pick_confirm_date != value)
                {
                    _pick_confirm_date = value; RaisePropertyChanged("pick_confirm_date");
                }
            }
        }
        private string _pick_confirm_time;
        public string pick_confirm_time
        {
            get { return _pick_confirm_time; }
            set {
                if (_pick_confirm_time != value)
                {
                    _pick_confirm_time = value; RaisePropertyChanged("pick_confirm_time");
                }
            }
        }
        private string _pack_material;
        public string pack_material
        {
            get { return _pack_material; }
            set {
                if (_pack_material != value)
                {
                    _pack_material = value; RaisePropertyChanged("pack_material");
                }
            }
        }
        private string _confirm_data_trns;
        public string confirm_data_trns
        {
            get { return _confirm_data_trns; }
            set {
                if (_confirm_data_trns != value)
                {
                    _confirm_data_trns = value; RaisePropertyChanged("confirm_data_trns");
                }
            }
        }
        private string _delivery;
        public string delivery
        {
            get { return _delivery; }
            set {
                if (_delivery != value)
                {
                    _delivery = value; RaisePropertyChanged("delivery");
                }
            }
        }
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set {
                if (_t_status != value)
                {
                    _t_status = value; RaisePropertyChanged("t_status");
                }
            }
        }
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set {
                if (_comp_code != value)
                {
                    _comp_code = value; RaisePropertyChanged("comp_code");
                }
            }
        }
        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active");
                }
            }
        }
        
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set {
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
            set {
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
            set {
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
            set {
                if (_edit_date != value)
                {
                    _edit_date = value; RaisePropertyChanged("edit_date");
                }
            }
        }
        
        private Nullable<decimal> _qty;
        public Nullable<decimal> qty
        {
            get { return _qty; }
            set {
                if (_qty != value)
                {
                    _qty = value; RaisePropertyChanged("qty");
                }
            }
        }
        private string _ItemName;
        public string ItemName
        {
            get { return _ItemName; }
            set {
                if (_ItemName != value)
                {
                    _ItemName = value; RaisePropertyChanged("ItemName");
                }
            }
        }
        private Nullable<System.DateTime> _exp_date;
        public Nullable<System.DateTime> exp_date
        {
            get { return _exp_date; }
            set
            {
                if (_exp_date != value)
                {
                    _exp_date = value; RaisePropertyChanged("exp_date");
                }
            }
        }
        private string _sch_no;
        public string sch_no
        {
            get { return _sch_no; }
            set
            {
                if (_sch_no != value)
                {
                    _sch_no = value; RaisePropertyChanged("sch_no");
                }
            }
        }
        private string _doc_type;
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
        private string _doc_desc;
        public string doc_desc
        {
            get { return _doc_desc; }
            set
            {
                if (_doc_desc != value)
                {
                    _doc_desc = value; RaisePropertyChanged("doc_desc");
                }
            }
        }
        private string _sono;
        public string sono
        {
            get { return _sono; }
            set
            {
                if (_sono != value)
                {
                    _sono = value; RaisePropertyChanged("sono");
                }
            }
        }

        private string _schedule_item_row_id;
        public string schedule_item_row_id
        {
            get { return _schedule_item_row_id; }
            set
            {
                if (_schedule_item_row_id != value)
                {
                    _schedule_item_row_id = value; RaisePropertyChanged("schedule_item_row_id");
                }
            }
        }

        private string _order_item_row_id;
        public string order_item_row_id
        {
            get { return _order_item_row_id; }
            set
            {
                if (_order_item_row_id != value)
                {
                    _order_item_row_id = value; RaisePropertyChanged("order_item_row_id");
                }
            }
        }

        private string _unit_price;
        public string unit_price
        {
            get { return _unit_price; }
            set
            {
                if (_unit_price != value)
                {
                    _unit_price = value; RaisePropertyChanged("unit_price");
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
                    _remark = value; RaisePropertyChanged("remark");
                }
            }
        }
        private string _symbol { get; set; }
        public string symbol
        {
            get { return _symbol; }
            set
            {
                if (_symbol != value)
                {
                    _symbol = value; RaisePropertyChanged("symbol");
                }
            }
        }

    }
    public class SEL_T004Flip
    {
        public Nullable<bool> selected { get; set; }
        public string doc_no { get; set; }
        public Nullable<DateTime> doc_date { get; set; }
        public string mov_tp { get; set; }
        public string delivery_no { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string t_status { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string ref_doc_cat { get; set; }
        public string ship_to_party { get; set; }
        public string PartyNm { get; set; }
        public Nullable<DateTime> plan_date { get; set; }
        public Nullable<DateTime> dispatch_date { get; set; }
        public string shipping_location { get; set; }
        public string t_display { get; set; }
        public string way_bill_no { get; set; }
        public string way_bill_value { get; set; }
        public string date { get; set; }
        public string shipping_mode_name { get; set; }
        public string transportar_name { get; set; }
        public string color_code { get; set; }
        public string screen_namespace { get; set; }
        public string screen_class_path { get; set; }
        public string screen_namespace2 { get; set; }
        public string screen_class_path2 { get; set; }
        public string ts_code { get; set; }
        public string ts_code2 { get; set; }
        public string ts_name_display { get; set; }
        public string ts_name_display2 { get; set; }
        public string sono { get; set; }
        public Nullable<DateTime> sodate { get; set; }
        public string cust_ref { get; set; }
        public Nullable<DateTime> cust_ref_date { get; set; }
        public string so_code { get; set; }
        public string curr_code { get; set; }
        public string addr_del { get; set; }
        public string addr_bill { get; set; }
        public string pterm { get; set; }
        public string incoterm { get; set; }
        public string ctry_code { get; set; }
        public string party_code { get; set; }
        public string party_code_ship { get; set; }
    }
    public class MultipleContext_SEL_T004
    {
        public List<SEL_T004Flip> DocumentDataFlipGrid { get; set; }
        public List<ADM_M038_B_P> uom { get; set; }
        public List<MM_M001_P> storage_loc { get; set; }
        public List<LOG_T001_A_P> DeliveryNoList { get; set; }
        public List<SEL_T004> MasterEntity { get; set; }
        public ObservableCollection<SEL_T004_A> ItemsEntity { get; set; }
        public List<Log_T001_A_ItemsList> ItemList { get; set; }
        public List<SYS_M002_P> doc_typeList { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<NotificationData> NotificationData { get; set; }
        public List<SEL_T003_P_RefDoc> Dispatch_Order_Reference { get; set; }
        public List<ADM_M028_P> PartyMaster { get; set; }
        public List<ADM_M0013> t_statusList { get; set; }
        public List<ADM_M028_P> Transporters { get; set; }
        public List<ADM_M024_P> Sellers { get; set; }
        public List<SYS_M026> ShippingTypes { get; set; }
        public List<ADM_M028_D> PartysShipToAddresses { get; set; }

    }
    public class Log_T001_A_ItemsList//Item List for Popup transfer Documents from delivery no
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string CatCode { get; set; }
        public string SubCatCode { get; set; }
        public string unit_code { get; set; }
        public Nullable<bool> Stockble { get; set; }
        public string PartyId { get; set; }
        public string sku { get; set; }
        public decimal qty { get; set; }
        public string sku_desc { get; set; }
        public string wa_code { get; set; }
        public string location_Id { get; set; }
        public string store_code { get; set; }
        public Nullable<decimal> MinQty { get; set; }
        public Nullable<decimal> MaxQty { get; set; }
        public Nullable<decimal> Reorder { get; set; }
        public Nullable<decimal> stock_total { get; set; }
        public Nullable<decimal> stock_reserve { get; set; }
        public Nullable<decimal> stock_unr { get; set; }
        public Nullable<decimal> stock_in_transit { get; set; }

    }

}
