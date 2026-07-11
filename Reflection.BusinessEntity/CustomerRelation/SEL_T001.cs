using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Reflection.BusinessEntity.ADM;
using Reflection.BusinessEntity.CustomerRelation;
using Reflection.BusinessEntity.ReflectionSystem;

namespace Reflection.BusinessEntity
{
    public class SEL_T001 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        private string _sono;
        private DateTime? _sodate;
        private string _order_to_plant;
        private int? _bill_address_id;
        private int? _del_address;
        private string _cust_ref;
        private DateTime? _cust_ref_date;
        private DateTime? _valid_from_date;
        private string _quotation_no;
        private DateTime? _quotation_submt_dt;
        private string _buyer_name;
        private DateTime? _expect_date;
        private int? _buyer;
        private string _EmpId;
        private string _address;
        private string _address1;
        private string _country_nm;
        private string _state_nm;
        private string _city;
        private string _pincode;
        private string _phone_no;
        private string _mobile_no;
        private string _phone_ext;
        private string _mail_id;
        private string _web_site;
        private string _p_term_code;
        private string _notes;
        private bool? _delivered;
        private bool? _invoice;
        private decimal? _tax_amt;
        private decimal? _untax_amt;
        private decimal? _total_amt;
        private string _amt_inword;
        private bool _active;
        private DateTime? _add_date;
        private string _add_by;
        private DateTime? _edit_date;
        private string _editby;
        private string _doc_type;
        private string _doc_cat;
        private string _ref_doc_no;
        private string _ref_doc_type;
        private DateTime? _valid_to_date;
        private string _so_code;
        private string _div_code;
        private string _sales_person_cd;
        private string _j_code;
        private string _PartyId;
        private string _party_name;
        private string _fin_year;
        private string _posting_period;
        private string _store_code;
        private string _cust_cat_no;
        private string _curr_code;
        private string _wa_code;
        private DateTime? _date_approve;
        private string _reference;
        private string _invoice_method;
        private bool? _shipped;
        private DateTime? _shipped_date;
        private DateTime? _min_planned_date;
        private string _dc_code;
        private string _sg_code;
        private string _sales_office;
        private string _business_area;
        private string _cost_center;
        private string _po_no;
        private string _po_type;
        private DateTime? _po_date;
        private string _version;
        private string _location_Id;
        private string _comp_code;
        private string _ship_to_party;
        private string _t_status;
        private string _para1;
        private string _para2;
        private string _para3;
        private string _pre_carrage;
        private string _pre_carrage_place;
        private string _country_code;
        private string _port_load;
        private string _port_desc;
        private string _port_final;
        private string _final_dest;
        private string _ship_terms;
        private string _cf_agent_cd;
        private string _lic_cod;
        private string _adv_lic_cd;
        private string _org_country_cd;
        private string _pack_rem;
        private string _ship_mark;
        private string _ship_mode;
        private string _bank_code;
        private string _nastro_bank_cd;
        private string _ship_cond;
        private string _del_plant;
        private string _transporter_cd;
        private decimal? _gross_wt;
        private decimal? _net_wt;
        private string _unit_code;
        private string _volume_unit;
        private decimal? _qty_tol;
        private decimal? _amt_tol;
        private string _ref_version;
        private decimal? _volume;
        private string _incoterms;
        private DateTime? _app_closing_dt;
        private DateTime? _quotation_deadline;
        private string _bid_inv_no;
        private decimal? _short_excess_amt;
        private string _short_excess_flag;
        private string _gr_ind;
        private string _invoice_ind;
        private string _gr_inv_ind;
        private string _order_ack_ind;
        private string _order_ack_no;
        private string _pur_agree_no;
        private string _pur_agree_item_cd;
        private string _cust_mat_no;
        private decimal? _abs_deviation_qty;
        private decimal? _per_deviation_qty;
        private decimal? _over_del_tol;
        private decimal? _under_del_tol;
        private string _vendor_bank_code;
        private string _revision_no;
        private string _revision_ind;
        private string _rev_ref_no;
        private string _down_ind;
        private decimal? _down_per;
        private decimal? _down_pay;
        private DateTime? _down_date;
        private string _refferencing_party;
        private string _hb_acc;
        private string _swift_code;
        private string _ifsc_code;
        private string _terms_cond;
        private decimal? _round_up;
        private string _gl_code;
        private string _notify_party;
        private string _notify_party2;
        private string _referring_party;
        private string _catalogue_code;
        private decimal? _ex_rate;
        private DateTime? _order_ack_date;
        private bool? _acknowledged;
        private bool? _abg_flag;
        private int? _abg_days;
        private DateTime? _abg_release_date;
        private string _release_mode;
        private decimal? _roundup_total;
        private DateTime? _ref_doc_date;
        private DateTime? _expiration_date;
        private string _validator;
        private string _delivery_ind;
        private string _seller_name;
        private string _ship_to_party_name;
        private string _notify_party_name;
        private string _notify_party_name2;
        private string _bank_name;
        private string _nastro_bank_name;
        private string _cf_agent_name;
        private string _transporter_name;
        private string _referring_party_name;
        private string _sales_org;
        private string _sg_name;
        private string _cost_center_Desc;
        private string _inco_desc;
        private string _doc_type_doc_no;
        private string _doc_type_user;
        private string _doc_desc;
        private string _delivery_address;
        private string _billing_address;
        private string _payment_term;
        private string _shipping_mark;
        private string _insurance;
        private string _packing;
        private string _transhipment;
        private string _partshipment;
        private Nullable<System.DateTime> _shipment_date;
        private Nullable<System.DateTime> _validity_date;
        private string _payment_mode;
        private string _ship_to_address;
        private string _ifsccode;
        private string _acc_number;
        private string _branch;
        private string _user_source11;
        private string _EmpMobNo;
        private string _EmpPhNo;
        private string _EmpEmailId;
        private string _PersnEmailId;
        private string _PersnMobNo;
        private string _PersnPhNo;
        private string _address1_s;
        private string _address2_s;
        private string _country_nm_s;
        private string _state_nm_s;
        private string _city_s;
        private string _pincode_s;
        private bool? _qty_percent;
        private bool? _amt_percent;
        private string _sold_to_address;
        private string _status_remark;
        private string _dcat_name;
        private string _LoctnNm;
        private string _PersonEmailId;
        private string _PartyEmailId;
        private Nullable<int> _ref_party_contact;
        private string _ref_contact_name;
        private string _language;
        private string _doc_history_no;
        private string _CSTNo;
        private string _VATNo;
        private string _service_tax_no;
        private string _PanNo;
        private string _PhNo;
        private string _FaxNo;
        private string _PhNos;
        private string _FaxNos;
        private string _TranParty_name;
        private string _remark1;
        private string _remark2;
        private string _remark3;
        private string _remark4;
        private string _notify_nm;
        private string _notify_ph;
        private string _notify_address;
        private string _bank_city;
        private string _bank_zip;
        private string _bank_country;
        private string _location;
        private string _incoterm2;
        private decimal? _order_limit;
        private bool? _order_limit_tax;
        private string _symbol;
        private decimal? _net_value;
        private string _withholding_tax;
        private decimal? _withholding_value;
        private decimal? _withholding_ex_amt;
        private decimal? _local_tax_amt;
        private decimal? _local_total_amt;
        private decimal? _local_round_up;
        private decimal? _local_roundup_total;
        private decimal? _local_net_value;
        private decimal? _other_charges;
        private string _bom_no;
        private decimal? _gross_value;
        private decimal? _effective_value;
        private decimal? _disc_amt;
        private decimal? _tax_amount;
        private string _gst_PartyId;
        private string _buss_place;
        private string _plc_name;
        private string _gstinno;
        private Nullable<System.DateTime> _gstindate;
        private string _soldto_buss_place;
        private string _shipto_buss_place;

        public string plc_name
        {
            get { return _plc_name; }
            set
            {
                if (_plc_name != value)
                {
                    _plc_name = value;

                    RaisePropertyChanged("plc_name");
                }
            }
        }
        public string bank_city
        {
            get { return _bank_city; }
            set
            {
                if (_bank_city != value)
                {
                    _bank_city = value;
                    RaisePropertyChanged("bank_city");
                }
            }
        }
        public string bank_zip
        {
            get { return _bank_zip; }
            set
            {
                if (_bank_zip != value)
                {
                    _bank_zip = value;
                    RaisePropertyChanged("bank_zip");
                }
            }
        }
        public string bank_country
        {
            get { return _bank_country; }
            set
            {
                if (_bank_country != value)
                {
                    _bank_country = value;
                    RaisePropertyChanged("bank_country");
                }
            }
        }


        private byte[] _authorised_signature;

        public byte[] authorised_signature
        {
            get { return _authorised_signature; }
            set
            {
                if (_authorised_signature != value)
                {
                    _authorised_signature = value;
                    RaisePropertyChanged("authorised_signature");
                }
            }
        }
        public string dcat_name
        {
            get { return _dcat_name; }
            set
            {
                if (_dcat_name != value)
                {
                    _dcat_name = value;
                    RaisePropertyChanged("dcat_name");
                }
            }
        }

        public int id
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

        public string sono
        {
            get { return _sono; }
            set
            {
                if (_sono != value)
                {
                    _sono = value; RaisePropertyChanged("sono", ModelEntityUpdated);
                }
            }
        }

        public DateTime? sodate
        {
            get { return _sodate; }
            set
            {
                if (_sodate != value)
                {
                    _sodate = value; RaisePropertyChanged("sodate");
                }
            }
        }

        public string order_to_plant
        {
            get { return _order_to_plant; }
            set
            {
                if (_order_to_plant != value)
                {
                    _order_to_plant = value; RaisePropertyChanged("order_to_plant", ModelEntityUpdated);
                }
            }
        }


        public int? bill_address_id
        {
            get { return _bill_address_id; }
            set
            {
                if (_bill_address_id != value)
                {
                    _bill_address_id = value;
                    RaisePropertyChanged("bill_address_id", ModelEntityUpdated);
                }
            }

        }


        public int? del_address
        {
            get { return _del_address; }
            set
            {
                if (_del_address != value)
                {
                    _del_address = value; RaisePropertyChanged("del_address", ModelEntityUpdated);
                }
            }
        }

        public string cust_ref
        {
            get { return _cust_ref; }
            set
            {
                if (_cust_ref != value)
                {
                    _cust_ref = value; RaisePropertyChanged("cust_ref", ModelEntityUpdated);
                }
            }
        }

        public DateTime? cust_ref_date
        {
            get { return _cust_ref_date; }
            set
            { _cust_ref_date = value; RaisePropertyChanged("cust_ref_date", ModelEntityUpdated); }
        }

        public DateTime? valid_from_date
        {
            get { return _valid_from_date; }
            set
            {
                if (_valid_from_date != value)
                {
                    _valid_from_date = value; RaisePropertyChanged("valid_from_date", ModelEntityUpdated);
                }
            }
        }


        public string quotation_no
        {
            get { return _quotation_no; }
            set
            {
                if (_quotation_no != value)
                {
                    _quotation_no = value; RaisePropertyChanged("quotation_no", ModelEntityUpdated);
                }
            }
        }
        public DateTime? quotation_submt_dt
        {
            get
            {
                return _quotation_submt_dt;
            }

            set
            {
                if (_quotation_submt_dt != value)
                {
                    _quotation_submt_dt = value; RaisePropertyChanged("quotation_submt_dt", ModelEntityUpdated);
                }
            }
        }

        public string buyer_name
        {
            get
            {
                return _buyer_name;
            }

            set
            {
                if (_buyer_name != value)
                {
                    _buyer_name = value; RaisePropertyChanged("buyer_name", ModelEntityUpdated);
                }
            }
        }

        public DateTime? expect_date
        {
            get
            {
                return _expect_date;
            }

            set
            {
                if (_expect_date != value)
                {
                    _expect_date = value; RaisePropertyChanged("expect_date", ModelEntityUpdated);
                }
            }
        }

        public int? buyer
        {
            get
            {
                return _buyer;
            }

            set
            {
                if (_buyer != value)
                {
                    _buyer = value; RaisePropertyChanged("buyer", ModelEntityUpdated);
                }
            }
        }

        public string EmpId
        {
            get
            {
                return _EmpId;
            }

            set
            {
                if (_EmpId != value)
                {
                    _EmpId = value; RaisePropertyChanged("EmpId", ModelEntityUpdated);
                }
            }
        }

        public string address
        {
            get
            {
                return _address;
            }

            set
            {
                if (_address != value)
                {
                    _address = value; RaisePropertyChanged("address", ModelEntityUpdated);
                }
            }
        }

        public string address1
        {
            get
            {
                return _address1;
            }

            set
            {
                if (_address1 != value)
                {
                    _address1 = value; RaisePropertyChanged("address1", ModelEntityUpdated);
                }
            }
        }

        public string country_nm
        {
            get
            {
                return _country_nm;
            }

            set
            {
                if (_country_nm != value)
                {
                    _country_nm = value; RaisePropertyChanged("country_nm", ModelEntityUpdated);
                }
            }
        }

        public string state_nm
        {
            get
            {
                return _state_nm;
            }

            set
            {
                if (_state_nm != value)
                {
                    _state_nm = value; RaisePropertyChanged("state_nm", ModelEntityUpdated);
                }
            }
        }

        public string city
        {
            get
            {
                return _city;
            }

            set
            {
                if (_city != value)
                {
                    _city = value; RaisePropertyChanged("city", ModelEntityUpdated);
                }
            }
        }

        public string symbol
        {
            get
            {
                return _symbol;
            }

            set
            {
                if (_symbol != value)
                {
                    _symbol = value; RaisePropertyChanged("symbol", ModelEntityUpdated);
                }
            }
        }

        public string pincode
        {
            get
            {
                return _pincode;
            }

            set
            {
                if (_pincode != value)
                {
                    _pincode = value; RaisePropertyChanged("pincode", ModelEntityUpdated);
                }
            }
        }

        public string phone_no
        {
            get
            {
                return _phone_no;
            }

            set
            {
                if (_phone_no != value)
                {
                    _phone_no = value; RaisePropertyChanged("phone_no", ModelEntityUpdated);
                }
            }
        }

        public string mobile_no
        {
            get
            {
                return _mobile_no;
            }

            set
            {
                if (_mobile_no != value)
                {
                    _mobile_no = value; RaisePropertyChanged("mobile_no", ModelEntityUpdated);
                }
            }
        }

        public string phone_ext
        {
            get
            {
                return _phone_ext;
            }

            set
            {
                if (_phone_ext != value)
                {
                    _phone_ext = value; RaisePropertyChanged("phone_ext", ModelEntityUpdated);
                }
            }
        }

        public string mail_id
        {
            get
            {
                return _mail_id;
            }

            set
            {
                if (_mail_id != value)
                {
                    _mail_id = value; RaisePropertyChanged("mail_id", ModelEntityUpdated);
                }
            }
        }

        public string web_site
        {
            get
            {
                return _web_site;
            }

            set
            {
                if (_web_site != value)
                {
                    _web_site = value; RaisePropertyChanged("web_site", ModelEntityUpdated);
                }
            }
        }

        public string p_term_code
        {
            get
            {
                return _p_term_code;
            }

            set
            {
                if (_p_term_code != value)
                {
                    _p_term_code = value; RaisePropertyChanged("p_term_code", ModelEntityUpdated);
                }
            }
        }

        public string notes
        {
            get
            {
                return _notes;
            }

            set
            {
                if (_notes != value)
                {
                    _notes = value; RaisePropertyChanged("notes", ModelEntityUpdated);
                }
            }
        }
        public bool? delivered
        {
            get
            {
                return _delivered;
            }

            set
            {
                if (_delivered != value)
                {
                    _delivered = value; RaisePropertyChanged("delivered", ModelEntityUpdated);
                }
            }
        }

        public bool? invoice
        {
            get
            {
                return _invoice;
            }

            set
            {
                if (_invoice != value)
                {
                    _invoice = value; RaisePropertyChanged("invoice", ModelEntityUpdated);
                }
            }
        }

        public decimal? tax_amt
        {
            get
            {
                return _tax_amt;
            }

            set
            {
                if (_tax_amt != value)
                {
                    _tax_amt = value; RaisePropertyChanged("tax_amt", ModelEntityUpdated);
                }
            }
        }

        public decimal? untax_amt
        {
            get
            {
                return _untax_amt;
            }

            set
            {
                if (_untax_amt != value)
                {
                    _untax_amt = value; RaisePropertyChanged("untax_amt", ModelEntityUpdated);
                }
            }
        }

        public decimal? total_amt
        {
            get
            {
                return _total_amt;
            }

            set
            {
                if (_total_amt != value)
                {
                    _total_amt = value; RaisePropertyChanged("total_amt", ModelEntityUpdated);
                }
            }
        }

        public string amt_inword
        {
            get
            {
                return _amt_inword;
            }

            set
            {
                if (_amt_inword != value)
                {
                    _amt_inword = value; RaisePropertyChanged("amt_inword", ModelEntityUpdated);
                }
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
                if (_active = value)
                {
                    _active = value; RaisePropertyChanged("active", ModelEntityUpdated);
                }
            }
        }

        public DateTime? add_date
        {
            get
            {
                return _add_date;
            }

            set
            {
                if (_add_date != value)
                {
                    _add_date = value; RaisePropertyChanged("add_date", ModelEntityUpdated);
                }
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
                if (_add_by != value)
                {
                    _add_by = value; RaisePropertyChanged("add_by", ModelEntityUpdated);
                }
            }
        }

        public DateTime? edit_date
        {
            get
            {
                return _edit_date;
            }

            set
            {
                if (_edit_date != value)
                {
                    _edit_date = value; RaisePropertyChanged("edit_date", ModelEntityUpdated);
                }
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
                if (_editby != value)
                {
                    _editby = value; RaisePropertyChanged("editby", ModelEntityUpdated);
                }
            }
        }

        [Required(ErrorMessage = "Field Document Type is required.")]
        public string doc_type
        {
            get
            {
                return _doc_type;
            }

            set
            {
                if (_doc_type != value)
                {
                    _doc_type = value; RaisePropertyChanged("doc_type", ModelEntityUpdated);
                }
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
                if (_doc_cat != value)
                {
                    _doc_cat = value; RaisePropertyChanged("doc_cat", ModelEntityUpdated);
                }
            }
        }

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

        public string ref_doc_type
        {
            get
            {
                return _ref_doc_type;
            }

            set
            {
                if (_ref_doc_type != value)
                {
                    _ref_doc_type = value; RaisePropertyChanged("ref_doc_type", ModelEntityUpdated);
                }
            }
        }

        public DateTime? valid_to_date
        {
            get
            {
                return _valid_to_date;
            }

            set
            {
                if (_valid_to_date != value)
                {
                    _valid_to_date = value; RaisePropertyChanged("valid_to_date", ModelEntityUpdated);
                }
            }
        }

        [Required(ErrorMessage = "Field 'Sales Orgnisation' is required.")]
        public string so_code
        {
            get
            {
                return _so_code;
            }

            set
            {
                if (_so_code != value)
                {
                    _so_code = value; RaisePropertyChanged("so_code", ModelEntityUpdated);
                }
            }
        }

        public string div_code
        {
            get
            {
                return _div_code;
            }

            set
            {
                if (_div_code != value)
                {
                    _div_code = value; RaisePropertyChanged("div_code", ModelEntityUpdated);
                }
            }
        }
        [Required(ErrorMessage = "Field 'Sales Person' is required.")]
        public string sales_person_cd
        {
            get
            {
                return _sales_person_cd;
            }

            set
            {
                if (_sales_person_cd != value)
                {
                    _sales_person_cd = value; RaisePropertyChanged("sales_person_cd");
                }
            }
        }

        public string j_code
        {
            get
            {
                return _j_code;
            }

            set
            {
                if (_j_code != value)
                {
                    _j_code = value; RaisePropertyChanged("j_code", ModelEntityUpdated);
                }
            }
        }


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
        [Required(ErrorMessage = "Field 'Party Name' is required.")]
        public string party_name
        {
            get
            {
                return _party_name;
            }

            set
            {
                if (_party_name != value)
                {
                    _party_name = value; RaisePropertyChanged("party_name", ModelEntityUpdated);
                }
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
                if (_fin_year != value)
                {
                    _fin_year = value; RaisePropertyChanged("fin_year", ModelEntityUpdated);
                }
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
                if (_posting_period != value)
                {
                    _posting_period = value; RaisePropertyChanged("posting_period", ModelEntityUpdated);
                }
            }
        }

        public string store_code
        {
            get
            {
                return _store_code;
            }

            set
            {
                if (_store_code != value)
                {
                    _store_code = value; RaisePropertyChanged("store_code", ModelEntityUpdated);
                }
            }
        }

        public string cust_cat_no
        {
            get
            {
                return _cust_cat_no;
            }

            set
            {
                if (_cust_cat_no != value)
                {
                    _cust_cat_no = value; RaisePropertyChanged("Cust_cat_no", ModelEntityUpdated);
                }
            }
        }

        [Required(ErrorMessage = "Field 'Currency' is required.")]
        public string curr_code
        {
            get
            {
                return _curr_code;
            }

            set
            {
                if (_curr_code != value)
                {
                    _curr_code = value; RaisePropertyChanged("curr_code", ModelEntityUpdated);
                }
            }
        }

        public string wa_code
        {
            get
            {
                return _wa_code;
            }

            set
            {
                if (_wa_code != value)
                {
                    _wa_code = value; RaisePropertyChanged("wa_code", ModelEntityUpdated);
                }
            }
        }

        public DateTime? date_approve
        {
            get
            {
                return _date_approve;
            }

            set
            {
                if (_date_approve != value)
                {
                    _date_approve = value; RaisePropertyChanged("date_approve", ModelEntityUpdated);
                }
            }
        }

        public string reference
        {
            get
            {
                return _reference;
            }

            set
            {
                if (_reference != value)
                {
                    _reference = value; RaisePropertyChanged("reference", ModelEntityUpdated);
                }
            }
        }

        public string invoice_method
        {
            get
            {
                return _invoice_method;
            }

            set
            {
                if (_invoice_method != value)
                {
                    _invoice_method = value; RaisePropertyChanged("invoice_method", ModelEntityUpdated);
                }
            }
        }

        public bool? shipped
        {
            get
            {
                return _shipped;
            }

            set
            {
                if (_shipped != value)
                {
                    _shipped = value; RaisePropertyChanged("shipped", ModelEntityUpdated);
                }
            }
        }

        public DateTime? shipped_date
        {
            get
            {
                return _shipped_date;
            }

            set
            {
                if (_shipped_date != value)
                {
                    _shipped_date = value; RaisePropertyChanged("shipped_date", ModelEntityUpdated);
                }
            }
        }

        public DateTime? min_planned_date
        {
            get
            {
                return _min_planned_date;
            }

            set
            {
                if (_min_planned_date != value)
                {
                    _min_planned_date = value; RaisePropertyChanged("min_planned_date", ModelEntityUpdated);
                }
            }
        }

        public string dc_code
        {
            get
            {
                return _dc_code;
            }

            set
            {
                if (_dc_code != value)
                {
                    _dc_code = value; RaisePropertyChanged("dc_code", ModelEntityUpdated);
                }
            }
        }

        public string sg_code
        {
            get
            {
                return _sg_code;
            }

            set
            {
                if (_sg_code != value)
                {
                    _sg_code = value; RaisePropertyChanged("sg_code", ModelEntityUpdated);
                }
            }
        }

        public string sales_office
        {
            get
            {
                return _sales_office;
            }

            set
            {
                if (_sales_office != value)
                {
                    _sales_office = value; RaisePropertyChanged("sales_office", ModelEntityUpdated);
                }
            }
        }

        public string business_area
        {
            get
            {
                return _business_area;
            }

            set
            {
                if (_business_area != value)
                {
                    _business_area = value; RaisePropertyChanged("business_area", ModelEntityUpdated);
                }
            }
        }

        public string cost_center
        {
            get
            {
                return _cost_center;
            }

            set
            {
                if (_cost_center != value)
                {
                    _cost_center = value; RaisePropertyChanged("cost_center", ModelEntityUpdated);
                }
            }
        }

        public string po_no
        {
            get
            {
                return _po_no;
            }

            set
            {
                if (_po_no != value)
                {
                    _po_no = value; RaisePropertyChanged("po_no", ModelEntityUpdated);
                }
            }
        }

        public string po_type
        {
            get
            {
                return _po_type;
            }

            set
            {
                if (_po_type != value)
                {
                    _po_type = value; RaisePropertyChanged("po_type", ModelEntityUpdated);
                }
            }
        }

        public DateTime? po_date
        {
            get
            {
                return _po_date;
            }

            set
            {
                if (_po_date != value)
                {
                    _po_date = value; RaisePropertyChanged("po_date", ModelEntityUpdated);
                }
            }
        }

        public string version
        {
            get
            {
                return _version;
            }

            set
            {
                if (_version != value)
                {
                    _version = value; RaisePropertyChanged("version", ModelEntityUpdated);
                }
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
                if (_location_Id != value)
                {
                    _location_Id = value; RaisePropertyChanged("location_Id", ModelEntityUpdated);
                }
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
                if (_comp_code != value)
                {
                    _comp_code = value; RaisePropertyChanged("comp_code", ModelEntityUpdated);
                }
            }
        }


        public string ship_to_party
        {
            get
            {
                return _ship_to_party;
            }

            set
            {
                if (_ship_to_party != value)
                {
                    _ship_to_party = value; RaisePropertyChanged("ship_to_party", ModelEntityUpdated);
                }
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
                if (_t_status != value)
                {
                    _t_status = value; RaisePropertyChanged("t_status", ModelEntityUpdated);
                }
            }
        }

        public string para1
        {
            get
            {
                return _para1;
            }

            set
            {
                if (_para1 != value)
                {
                    _para1 = value; RaisePropertyChanged("para1", ModelEntityUpdated);
                }
            }
        }

        public string para2
        {
            get
            {
                return _para2;
            }

            set
            {
                if (_para2 != value)
                {
                    _para2 = value; RaisePropertyChanged("para2", ModelEntityUpdated);
                }
            }
        }

        public string para3
        {
            get
            {
                return _para3;
            }

            set
            {
                if (_para3 != value)
                {
                    _para3 = value; RaisePropertyChanged("para3", ModelEntityUpdated);
                }
            }
        }

        public string pre_carrage
        {
            get
            {
                return _pre_carrage;
            }

            set
            {
                if (_pre_carrage != value)
                {
                    _pre_carrage = value; RaisePropertyChanged("pre_carrage", ModelEntityUpdated);
                }
            }
        }

        public string pre_carrage_place
        {
            get
            {
                return _pre_carrage_place;
            }

            set
            {
                if (_pre_carrage_place != value)
                {
                    _pre_carrage_place = value; RaisePropertyChanged("pre_carrage_place", ModelEntityUpdated);
                }
            }
        }

        public string country_code
        {
            get
            {
                return _country_code;
            }

            set
            {
                if (_country_code != value)
                {
                    _country_code = value; RaisePropertyChanged("country_code", ModelEntityUpdated);
                }
            }
        }

        public string port_load
        {
            get
            {
                return _port_load;
            }

            set
            {
                if (_port_load != value)
                {
                    _port_load = value; RaisePropertyChanged("port_load", ModelEntityUpdated);
                }
            }
        }

        public string port_desc
        {
            get
            {
                return _port_desc;
            }

            set
            {
                if (_port_desc != value)
                {
                    _port_desc = value; RaisePropertyChanged("port_desc", ModelEntityUpdated);
                }
            }
        }

        public string port_final
        {
            get
            {
                return _port_final;
            }

            set
            {
                if (_port_final != value)
                {
                    _port_final = value; RaisePropertyChanged("port_final", ModelEntityUpdated);
                }
            }
        }

        public string final_dest
        {
            get
            {
                return _final_dest;
            }

            set
            {
                if (_final_dest != value)
                {
                    _final_dest = value; RaisePropertyChanged("final_dest", ModelEntityUpdated);
                }
            }
        }

        public string ship_terms
        {
            get
            {
                return _ship_terms;
            }

            set
            {
                if (_ship_terms != value)
                {
                    _ship_terms = value; RaisePropertyChanged("ship_terms", ModelEntityUpdated);
                }
            }
        }

        public string cf_agent_cd
        {
            get
            {
                return _cf_agent_cd;
            }

            set
            {
                if (_cf_agent_cd != value)
                {
                    _cf_agent_cd = value; RaisePropertyChanged("cf_agent_cd", ModelEntityUpdated);
                }
            }
        }

        public string lic_cod
        {
            get
            {
                return _lic_cod;
            }

            set
            {
                if (_lic_cod != value)
                {
                    _lic_cod = value; RaisePropertyChanged("lic_cod", ModelEntityUpdated);
                }
            }
        }

        public string adv_lic_cd
        {
            get
            {
                return _adv_lic_cd;
            }

            set
            {
                if (_adv_lic_cd != value)
                {
                    _adv_lic_cd = value; RaisePropertyChanged("adv_lic_cd", ModelEntityUpdated);
                }
            }
        }

        public string org_country_cd
        {
            get
            {
                return _org_country_cd;
            }

            set
            {
                if (_org_country_cd != value)
                {
                    _org_country_cd = value; RaisePropertyChanged("org_country_cd", ModelEntityUpdated);
                }
            }
        }

        public string pack_rem
        {
            get
            {
                return _pack_rem;
            }

            set
            {
                if (_pack_rem != value)
                {
                    _pack_rem = value; RaisePropertyChanged("pack_rem", ModelEntityUpdated);
                }
            }
        }

        public string ship_mark
        {
            get
            {
                return _ship_mark;
            }

            set
            {
                if (_ship_mark != value)
                {
                    _ship_mark = value; RaisePropertyChanged("ship_mark", ModelEntityUpdated);
                }
            }
        }
        private string _tr_mode;
        public string tr_mode
        {
            get
            {
                return _tr_mode;
            }

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
            get
            {
                return _tr_type;
            }

            set
            {
                if (_tr_type != value)
                {
                    _tr_type = value; RaisePropertyChanged("tr_type");
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
        public string ship_mode
        {
            get
            {
                return _ship_mode;
            }

            set
            {
                if (_ship_mode != value)
                {
                    _ship_mode = value; RaisePropertyChanged("ship_mode");
                }
            }
        }

        public string bank_code
        {
            get
            {
                return _bank_code;
            }

            set
            {
                if (_bank_code != value)
                {
                    _bank_code = value; RaisePropertyChanged("bank_code", ModelEntityUpdated);
                }
            }
        }

        public string nastro_bank_cd
        {
            get
            {
                return _nastro_bank_cd;
            }

            set
            {
                if (_nastro_bank_cd != value)
                {
                    _nastro_bank_cd = value; RaisePropertyChanged("nastro_bank_cd", ModelEntityUpdated);
                }
            }
        }

        public string ship_cond
        {
            get
            {
                return _ship_cond;
            }

            set
            {
                if (_ship_cond != value)
                {
                    _ship_cond = value; RaisePropertyChanged("ship_cond", ModelEntityUpdated);
                }
            }
        }

        public string del_plant
        {
            get
            {
                return _del_plant;
            }

            set
            {
                if (_del_plant != value)
                {
                    _del_plant = value; RaisePropertyChanged("del_plant", ModelEntityUpdated);
                }
            }
        }
        //private string _local_export;
        //[Required(ErrorMessage = "Field Local/Export indicator is required.")]
        //public string local_export
        //{
        //    get
        //    {
        //        return _local_export;
        //    }

        //    set
        //    {
        //        if (_local_export != value)
        //        {
        //            _local_export = value; RaisePropertyChanged("local_export", ModelEntityUpdated);
        //        }
        //    }
        //}
        private string _ind_trade;
        [Required(ErrorMessage = "Field 'Transaction Trade Type' is required.")]
        public string ind_trade
        {
            get
            {
                return _ind_trade;
            }
            set
            {
                if (_ind_trade != value)
                {
                    _ind_trade = value; RaisePropertyChanged("ind_trade", ModelEntityUpdated);

                }
            }
        }
        public string transporter_cd
        {
            get
            {
                return _transporter_cd;
            }

            set
            {
                if (_transporter_cd != value)
                {
                    _transporter_cd = value; RaisePropertyChanged("transporter_cd", ModelEntityUpdated);
                }
            }
        }

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
                    _gross_wt = value; RaisePropertyChanged("gross_wt", ModelEntityUpdated);
                }
            }
        }

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
                    _net_wt = value; RaisePropertyChanged("net_wt", ModelEntityUpdated);
                }
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
                if (_unit_code != value)
                {
                    _unit_code = value; RaisePropertyChanged("unit_code", ModelEntityUpdated);
                }
            }
        }

        public string volume_unit
        {
            get
            {
                return _volume_unit;
            }

            set
            {
                if (_volume_unit != value)
                {
                    _volume_unit = value; RaisePropertyChanged("volume_unit", ModelEntityUpdated);
                }
            }
        }

        public decimal? qty_tol
        {
            get
            {
                return _qty_tol;
            }

            set
            {
                if (_qty_tol != value)
                {
                    _qty_tol = value; RaisePropertyChanged("qty_tol", ModelEntityUpdated);
                }
            }
        }

        public decimal? amt_tol
        {
            get
            {
                return _amt_tol;
            }

            set
            {
                if (_amt_tol != value)
                {
                    _amt_tol = value; RaisePropertyChanged("amt_tol", ModelEntityUpdated);
                }
            }
        }

        public string ref_version
        {
            get
            {
                return _ref_version;
            }

            set
            {
                if (_ref_version != value)
                {
                    _ref_version = value; RaisePropertyChanged("ref_version", ModelEntityUpdated);
                }
            }
        }

        public decimal? volume
        {
            get
            {
                return _volume;
            }

            set
            {
                if (_volume != value)
                {

                }
                _volume = value; RaisePropertyChanged("volume", ModelEntityUpdated);
            }
        }

        public string incoterms
        {
            get
            {
                return _incoterms;
            }

            set
            {
                if (_incoterms != value)
                {
                    _incoterms = value; RaisePropertyChanged("incoterms", ModelEntityUpdated);
                }
            }
        }

        public DateTime? app_closing_dt
        {
            get
            {
                return _app_closing_dt;
            }

            set
            {
                if (_app_closing_dt != value)
                {
                    _app_closing_dt = value; RaisePropertyChanged("app_closing_dt", ModelEntityUpdated);
                }
            }
        }

        public DateTime? quotation_deadline
        {
            get
            {
                return _quotation_deadline;
            }

            set
            {
                if (_quotation_deadline != value)
                {
                    _quotation_deadline = value; RaisePropertyChanged("quotation_deadline", ModelEntityUpdated);
                }
            }
        }

        public string bid_inv_no
        {
            get
            {
                return _bid_inv_no;
            }

            set
            {
                if (_bid_inv_no != value)
                {
                    _bid_inv_no = value; RaisePropertyChanged("bid_inv_no", ModelEntityUpdated);
                }
            }
        }

        public decimal? short_excess_amt
        {
            get
            {
                return _short_excess_amt;
            }

            set
            {
                if (_short_excess_amt != value)
                {
                    _short_excess_amt = value; RaisePropertyChanged("short_excess_amt", ModelEntityUpdated);
                }
            }
        }

        public string short_excess_flag
        {
            get
            {
                return _short_excess_flag;
            }

            set
            {
                if (_short_excess_flag != value)
                {
                    _short_excess_flag = value; RaisePropertyChanged("short_excess_flag", ModelEntityUpdated);
                }
            }
        }

        public string gr_ind
        {
            get
            {
                return _gr_ind;
            }

            set
            {
                if (_gr_ind != value)
                {
                    _gr_ind = value; RaisePropertyChanged("gr_ind", ModelEntityUpdated);
                }
            }
        }

        public string invoice_ind
        {
            get
            {
                return _invoice_ind;
            }

            set
            {
                if (_invoice_ind != value)
                {
                    _invoice_ind = value; RaisePropertyChanged("invoice_ind", ModelEntityUpdated);
                }
            }
        }

        public string gr_inv_ind
        {
            get
            {
                return _gr_inv_ind;
            }

            set
            {
                if (_gr_inv_ind != value)
                {
                    _gr_inv_ind = value; RaisePropertyChanged("gr_inv_ind", ModelEntityUpdated);
                }
            }
        }

        public string order_ack_ind
        {
            get
            {
                return _order_ack_ind;
            }

            set
            {
                if (_order_ack_ind != value)
                {
                    _order_ack_ind = value; RaisePropertyChanged("order_ack_ind", ModelEntityUpdated);
                }
            }
        }

        public string order_ack_no
        {
            get
            {
                return _order_ack_no;
            }

            set
            {
                if (_order_ack_no != value)
                {
                    _order_ack_no = value; RaisePropertyChanged("order_ack_no", ModelEntityUpdated);
                }
            }
        }

        public string pur_agree_no
        {
            get
            {
                return _pur_agree_no;
            }

            set
            {
                if (_pur_agree_no != value)
                {
                    _pur_agree_no = value; RaisePropertyChanged("pur_agree_no", ModelEntityUpdated);
                }
            }
        }

        public string pur_agree_item_cd
        {
            get
            {
                return _pur_agree_item_cd;
            }

            set
            {
                if (_pur_agree_item_cd != value)
                {
                    _pur_agree_item_cd = value; RaisePropertyChanged("pur_agree_item_cd", ModelEntityUpdated);
                }
            }
        }

        public string cust_mat_no
        {
            get
            {
                return _cust_mat_no;
            }

            set
            {
                _cust_mat_no = value; RaisePropertyChanged("cust_mat_no", ModelEntityUpdated);
            }
        }

        public decimal? abs_deviation_qty
        {
            get
            {
                return _abs_deviation_qty;
            }

            set
            {
                if (_abs_deviation_qty != value)
                {
                    _abs_deviation_qty = value; RaisePropertyChanged("abs_deviation_qty", ModelEntityUpdated);
                }
            }
        }

        public decimal? per_deviation_qty
        {
            get
            {
                return _per_deviation_qty;
            }

            set
            {
                if (_per_deviation_qty != value)
                {
                    _per_deviation_qty = value; RaisePropertyChanged("per_deviation_qty", ModelEntityUpdated);
                }
            }
        }

        public decimal? over_del_tol
        {
            get
            {
                return _over_del_tol;
            }

            set
            {
                if (_over_del_tol != value)
                {
                    _over_del_tol = value; RaisePropertyChanged("over_del_tol", ModelEntityUpdated);
                }
            }
        }

        public decimal? under_del_tol
        {
            get
            {
                return _under_del_tol;
            }

            set
            {
                if (_under_del_tol != value)
                {
                    _under_del_tol = value; RaisePropertyChanged("under_del_tol", ModelEntityUpdated);
                }
            }
        }

        public string vendor_bank_code
        {
            get
            {
                return _vendor_bank_code;
            }

            set
            {
                if (_vendor_bank_code != value)
                {
                    _vendor_bank_code = value; RaisePropertyChanged("vendor_bank_code", ModelEntityUpdated);
                }
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
                if (_revision_no != value)
                {
                    _revision_no = value; RaisePropertyChanged("revision_no", ModelEntityUpdated);
                }
            }
        }

        public string revision_ind
        {
            get
            {
                return _revision_ind;
            }

            set
            {
                if (_revision_ind != value)
                {
                    _revision_ind = value; RaisePropertyChanged("revision_ind", ModelEntityUpdated);
                }
            }
        }

        public string rev_ref_no
        {
            get
            {
                return _rev_ref_no;
            }

            set
            {
                if (_rev_ref_no != value)
                {
                    _rev_ref_no = value; RaisePropertyChanged("rev_ref_no", ModelEntityUpdated);
                }
            }
        }

        public string down_ind
        {
            get
            {
                return _down_ind;
            }

            set
            {
                if (_down_ind != value)
                {
                    _down_ind = value; RaisePropertyChanged("down_ind", ModelEntityUpdated);
                }
            }
        }

        public decimal? down_per
        {
            get
            {
                return _down_per;
            }

            set
            {
                if (_down_per != value)
                {
                    _down_per = value; RaisePropertyChanged("down_per", ModelEntityUpdated);
                }
            }
        }

        public decimal? down_pay
        {
            get
            {
                return _down_pay;
            }

            set
            {
                if (_down_pay != value)
                {
                    _down_pay = value; RaisePropertyChanged("down_pay", ModelEntityUpdated);
                }
            }
        }

        public DateTime? down_date
        {
            get
            {
                return _down_date;
            }

            set
            {
                if (_down_date != value)
                {
                    _down_date = value; RaisePropertyChanged("down_date", ModelEntityUpdated);
                }
            }
        }

        public string refferencing_party
        {
            get
            {
                return _refferencing_party;
            }

            set
            {
                if (_refferencing_party != value)
                {
                    _refferencing_party = value; RaisePropertyChanged("refferencing_party", ModelEntityUpdated);
                }
            }
        }

        

        public string hb_acc
        {
            get
            {
                return _hb_acc;
            }

            set
            {
                if (_hb_acc != value)
                {
                    _hb_acc = value; RaisePropertyChanged("hb_acc", ModelEntityUpdated);
                }
            }
        }

        public string swift_code
        {
            get
            {
                return _swift_code;
            }

            set
            {
                if (_swift_code != value)
                {
                    _swift_code = value; RaisePropertyChanged("swift_code", ModelEntityUpdated);
                }
            }
        }

        public string ifsc_code
        {
            get
            {
                return _ifsc_code;
            }

            set
            {
                if (_ifsc_code != value)
                {
                    _ifsc_code = value; RaisePropertyChanged("ifsc_code", ModelEntityUpdated);
                }
            }
        }

        public string terms_cond
        {
            get
            {
                return _terms_cond;
            }

            set
            {
                if (_terms_cond != value)
                {
                    _terms_cond = value; RaisePropertyChanged("terms_cond", ModelEntityUpdated);
                }
            }
        }

        public decimal? round_up
        {
            get
            {
                return _round_up;
            }

            set
            {
                if (_round_up != value)
                {
                    _round_up = value; RaisePropertyChanged("round_up", ModelEntityUpdated);
                }
            }
        }

        public string gl_code
        {
            get
            {
                return _gl_code;
            }

            set
            {
                if (_gl_code != value)
                {
                    _gl_code = value; RaisePropertyChanged("gl_code", ModelEntityUpdated);
                }
            }
        }

        public string notify_party
        {
            get
            {
                return _notify_party;
            }

            set
            {
                if (_notify_party != value)
                {
                    _notify_party = value; RaisePropertyChanged("notify_party");
                }
            }
        }
        public string notify_party2
        {
            get
            {
                return _notify_party2;
            }

            set
            {
                if (_notify_party2 != value)
                {
                    _notify_party2 = value; RaisePropertyChanged("notify_party2");
                }
            }
        }
        private string _tr_name;
        public string tr_name
        {
            get
            {
                return _tr_name;
            }

            set
            {
                if (_tr_name != value)
                {
                    _tr_name = value; RaisePropertyChanged("tr_name");
                }
            }
        }

        public string referring_party
        {
            get
            {
                return _referring_party;
            }

            set
            {
                if (_referring_party != value)
                {
                    _referring_party = value; RaisePropertyChanged("referring_party", ModelEntityUpdated);
                }
            }
        }

        public string catalogue_code
        {
            get
            {
                return _catalogue_code;
            }

            set
            {
                if (_catalogue_code != value)
                {
                    _catalogue_code = value; RaisePropertyChanged("catalogue_code", ModelEntityUpdated);
                }
            }
        }

        public decimal? ex_rate
        {
            get
            {
                return _ex_rate;
            }

            set
            {
                if (_ex_rate != value)
                {
                    _ex_rate = value; RaisePropertyChanged("ex_rate", ModelEntityUpdated);
                }
            }
        }

        public DateTime? order_ack_date
        {
            get
            {
                return _order_ack_date;
            }

            set
            {
                if (_order_ack_date != value)
                {
                    _order_ack_date = value; RaisePropertyChanged("order_ack_date", ModelEntityUpdated);
                }
            }
        }

        public bool? acknowledged
        {
            get
            {
                return _acknowledged;
            }

            set
            {
                if (_acknowledged != value)
                {
                    _acknowledged = value; RaisePropertyChanged("acknowledged", ModelEntityUpdated);
                }
            }
        }

        public bool? abg_flag
        {
            get
            {
                return _abg_flag;
            }

            set
            {
                if (_abg_flag != value)
                {
                    _abg_flag = value; RaisePropertyChanged("abg_flag", ModelEntityUpdated);
                }
            }
        }

        public int? abg_days
        {
            get
            {
                return _abg_days;
            }

            set
            {
                if (_abg_days != value)
                {
                    _abg_days = value; RaisePropertyChanged("abg_days", ModelEntityUpdated);
                }
            }
        }

        public DateTime? abg_release_date
        {
            get
            {
                return _abg_release_date;
            }

            set
            {
                if (_abg_release_date != value)
                {
                    _abg_release_date = value; RaisePropertyChanged("abg_release_date", ModelEntityUpdated);
                }
            }
        }

        public string release_mode
        {
            get
            {
                return _release_mode;
            }

            set
            {
                if (_release_mode != value)
                {
                    _release_mode = value; RaisePropertyChanged("release_mode", ModelEntityUpdated);
                }
            }
        }

        public decimal? roundup_total
        {
            get
            {
                return _roundup_total;
            }

            set
            {
                if (_roundup_total != value)
                {
                    _roundup_total = value; RaisePropertyChanged("roundup_total", ModelEntityUpdated);
                }
            }
        }

        public DateTime? ref_doc_date
        {
            get
            {
                return _ref_doc_date;
            }

            set
            {
                if (_ref_doc_date != value)
                {
                    _ref_doc_date = value; RaisePropertyChanged("ref_doc_date", ModelEntityUpdated);
                }
            }
        }

        public DateTime? expiration_date
        {
            get
            {
                return _expiration_date;
            }

            set
            {
                if (_expiration_date != value)
                {
                    _expiration_date = value; RaisePropertyChanged("expiration_date", ModelEntityUpdated);
                }
            }
        }

        public string validator
        {
            get
            {
                return _validator;
            }

            set
            {
                if (_validator != value)
                {
                    _validator = value; RaisePropertyChanged("validator", ModelEntityUpdated);
                }
            }
        }

        public string delivery_ind
        {
            get
            {
                return _delivery_ind;
            }

            set
            {
                if (_delivery_ind != value)
                {
                    _delivery_ind = value; RaisePropertyChanged("delivery_ind", ModelEntityUpdated);
                }
            }
        }

        public string seller_name
        {
            get
            {
                return _seller_name;
            }

            set
            {
                if (_seller_name != value)
                {
                    _seller_name = value; RaisePropertyChanged("seller_name", ModelEntityUpdated);
                }
            }
        }
        //[Required(ErrorMessage = "Field 'Ship to Party' is required.")]
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

        public string notify_party_name
        {
            get
            {
                return _notify_party_name;
            }

            set
            {
                if (_notify_party_name != value)
                {
                    _notify_party_name = value; RaisePropertyChanged("notify_party_name", ModelEntityUpdated);
                }
            }
        }
        public string notify_party_name2
        {
            get
            {
                return _notify_party_name2;
            }

            set
            {
                if (_notify_party_name2 != value)
                {
                    _notify_party_name2 = value; RaisePropertyChanged("notify_party_name2", ModelEntityUpdated);
                }
            }
        }

        public string bank_name
        {
            get
            {
                return _bank_name;
            }

            set
            {
                if (_bank_name != value)
                {
                    _bank_name = value; RaisePropertyChanged("bank_name", ModelEntityUpdated);
                }
            }
        }

        public string nastro_bank_name
        {
            get
            {
                return _nastro_bank_name;
            }

            set
            {
                if (_nastro_bank_name != value)
                {
                    _nastro_bank_name = value; RaisePropertyChanged("nastro_bank_name", ModelEntityUpdated);
                }
            }
        }

        public string cf_agent_name
        {
            get
            {
                return _cf_agent_name;
            }

            set
            {
                if (_cf_agent_name != value)
                {
                    _cf_agent_name = value; RaisePropertyChanged("cf_agent_name", ModelEntityUpdated);
                }
            }
        }

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

        public string referring_party_name
        {
            get
            {
                return _referring_party_name;
            }

            set
            {
                if (_referring_party_name != value)
                {
                    _referring_party_name = value; RaisePropertyChanged("referring_party_name", ModelEntityUpdated);
                }
            }
        }

        public string sales_org
        {
            get
            {
                return _sales_org;
            }

            set
            {
                if (_sales_org != value)
                {
                    _sales_org = value; RaisePropertyChanged("sales_org", ModelEntityUpdated);
                }
            }
        }

        public string sg_name
        {
            get
            {
                return _sg_name;
            }

            set
            {
                if (_sg_name != value)
                {
                    _sg_name = value; RaisePropertyChanged("sg_name", ModelEntityUpdated);
                }
            }
        }

        public string cost_center_Desc
        {
            get
            {
                return _cost_center_Desc;
            }

            set
            {
                if (_cost_center_Desc != value)
                {
                    _cost_center_Desc = value; RaisePropertyChanged("cost_center_Desc", ModelEntityUpdated);
                }
            }
        }

        public string inco_desc
        {
            get
            {
                return _inco_desc;
            }

            set
            {
                if (_inco_desc != value)
                {
                    _inco_desc = value; RaisePropertyChanged("inco_desc", ModelEntityUpdated);
                }
            }
        }
        public string doc_type_doc_no
        {
            get
            {
                return _doc_type_doc_no;
            }

            set
            {
                if (_doc_type_doc_no != value)
                {
                    _doc_type_doc_no = value; RaisePropertyChanged("doc_type_doc_no", ModelEntityUpdated);
                }
            }
        }

        public string doc_type_user
        {
            get
            {
                return _doc_type_user;
            }

            set
            {
                if (_doc_type_user != value)
                {
                    _doc_type_user = value;
                    RaisePropertyChanged("doc_type_user", ModelEntityUpdated);
                }
            }
        }

        public string doc_desc
        {
            get
            {
                return _doc_desc;
            }

            set
            {
                if (_doc_desc != value)
                {
                    _doc_desc = value; RaisePropertyChanged("doc_desc", ModelEntityUpdated);
                }
            }
        }

        public string delivery_address
        {
            get { return _delivery_address; }
            set
            {
                if (_delivery_address != value)
                {
                    _delivery_address = value; RaisePropertyChanged("delivery_address", ModelEntityUpdated);
                }
            }
        }

        public string billing_address
        {
            get { return _billing_address; }
            set
            {
                if (_billing_address != value)
                {
                    _billing_address = value; RaisePropertyChanged("billing_address", ModelEntityUpdated);
                }
            }
        }

        public string payment_term
        {
            get { return _payment_term; }
            set
            {
                if (_payment_term != value)
                {
                    _payment_term = value; RaisePropertyChanged("payment_term", ModelEntityUpdated);
                }
            }
        }
        public string shipping_mark
        {
            get { return _shipping_mark; }
            set
            {
                if (_shipping_mark != value)
                {
                    _shipping_mark = value; RaisePropertyChanged("shipping_mark", ModelEntityUpdated);
                }
            }
        }
        public string insurance
        {
            get { return _insurance; }
            set
            {
                if (_insurance != value)
                {
                    _insurance = value; RaisePropertyChanged("insurance", ModelEntityUpdated);
                }
            }
        }
        public string packing
        {
            get { return _packing; }
            set
            {
                if (_packing != value)
                {
                    _packing = value; RaisePropertyChanged("packing", ModelEntityUpdated);
                }
            }
        }
        public string transhipment
        {
            get { return _transhipment; }
            set
            {
                if (_transhipment != value)
                {
                    _transhipment = value; RaisePropertyChanged("transhipment", ModelEntityUpdated);
                }
            }
        }
        public string partshipment
        {
            get { return _partshipment; }
            set
            {
                if (_partshipment != value)
                {
                    _partshipment = value; RaisePropertyChanged("partshipment", ModelEntityUpdated);
                }
            }
        }
        public Nullable<System.DateTime> shipment_date
        {
            get { return _shipment_date; }
            set
            {
                if (_shipment_date != value)
                {
                    _shipment_date = value; RaisePropertyChanged("shipment_date", ModelEntityUpdated);
                }
            }
        }
        public Nullable<System.DateTime> validity_date
        {
            get { return _validity_date; }
            set
            {
                if (_validity_date != value)
                {
                    _validity_date = value; RaisePropertyChanged("validity_date", ModelEntityUpdated);
                }
            }
        }
        public string payment_mode
        {
            get { return _payment_mode; }
            set
            {
                if (_payment_mode != value)
                {
                    _payment_mode = value; RaisePropertyChanged("payment_mode", ModelEntityUpdated);
                }
            }
        }
        public string ship_to_address
        {
            get { return _ship_to_address; }
            set
            {
                if (_ship_to_address != value)
                {
                    _ship_to_address = value; RaisePropertyChanged("ship_to_address", ModelEntityUpdated);
                }
            }
        }

        public string ifsccode
        {
            get { return _ifsccode; }
            set
            {
                if (_ifsccode != value)
                {
                    _ifsccode = value; RaisePropertyChanged("ifsccode", ModelEntityUpdated);
                }
            }
        }
        public string acc_number
        {
            get { return _acc_number; }
            set
            {
                if (_acc_number != value)
                {
                    _acc_number = value; RaisePropertyChanged("acc_number", ModelEntityUpdated);
                }
            }
        }
        public string branch
        {
            get { return _branch; }
            set
            {
                if (_branch != value)
                {
                    _branch = value; RaisePropertyChanged("branch", ModelEntityUpdated);
                }
            }
        }
        public string user_source11
        {
            get { return _user_source11; }
            set
            {
                if (_user_source11 != value)
                {
                    _user_source11 = value; RaisePropertyChanged("user_source11", ModelEntityUpdated);
                }
            }
        }

        public string EmpMobNo
        {
            get { return _EmpMobNo; }
            set
            {
                if (_EmpMobNo != value)
                {
                    _EmpMobNo = value; RaisePropertyChanged("EmpMobNo", ModelEntityUpdated);
                }
            }
        }


        public string EmpPhNo
        {
            get { return _EmpPhNo; }
            set
            {
                if (_EmpPhNo != value)
                {
                    _EmpPhNo = value; RaisePropertyChanged("EmpPhNo", ModelEntityUpdated);
                }
            }
        }

        public string EmpEmailId
        {
            get { return _EmpEmailId; }
            set
            {
                if (_EmpEmailId != value)
                {
                    _EmpEmailId = value; RaisePropertyChanged("EmpEmailId", ModelEntityUpdated);
                }
            }
        }

        public string PersnEmailId
        {
            get { return _PersnEmailId; }
            set
            {
                if (_PersnEmailId != value)
                {
                    _PersnEmailId = value; RaisePropertyChanged("PersnEmailId", ModelEntityUpdated);
                }
            }
        }


        public string PersnMobNo
        {
            get { return _PersnMobNo; }
            set
            {
                if (_PersnMobNo != value)
                {
                    _PersnMobNo = value; RaisePropertyChanged("PersnMobNo", ModelEntityUpdated);
                }
            }
        }

        public string PersnPhNo
        {
            get { return _PersnPhNo; }
            set
            {
                if (_PersnPhNo != value)
                {
                    _PersnPhNo = value; RaisePropertyChanged("PersnPhNo", ModelEntityUpdated);
                }
            }
        }

        public string pincode_s
        {
            get { return _pincode_s; }
            set
            {
                if (_pincode_s != value)
                {
                    _pincode_s = value; RaisePropertyChanged("pincode_s", ModelEntityUpdated);
                }
            }
        }

        public string address1_s
        {
            get { return _address1_s; }
            set
            {
                if (_address1_s != value)
                {
                    _address1_s = value; RaisePropertyChanged("address1_s", ModelEntityUpdated);
                }
            }
        }

        public string address2_s
        {
            get { return _address2_s; }
            set
            {
                if (_address2_s != value)
                {
                    _address2_s = value; RaisePropertyChanged("address2_s", ModelEntityUpdated);
                }
            }
        }

        public string country_nm_s
        {
            get { return _country_nm_s; }
            set
            {
                if (_country_nm_s != value)
                {
                    _country_nm_s = value; RaisePropertyChanged("country_nm_s", ModelEntityUpdated);
                }
            }
        }

        public string state_nm_s
        {
            get { return _state_nm_s; }
            set
            {
                if (_state_nm_s != value)
                {
                    _state_nm_s = value; RaisePropertyChanged("state_nm_s", ModelEntityUpdated);
                }
            }
        }

        public string city_s
        {
            get { return _city_s; }
            set
            {
                if (_city_s != value)
                {
                    _city_s = value; RaisePropertyChanged("city_s", ModelEntityUpdated);
                }
            }
        }

        public bool? qty_percent
        {
            get
            {
                return _qty_percent;
            }

            set
            {
                if (_qty_percent != value)
                {
                    _qty_percent = value; RaisePropertyChanged("qty_percent", ModelEntityUpdated);
                }
            }
        }

        public bool? amt_percent
        {
            get
            {
                return _amt_percent;
            }

            set
            {
                if (_amt_percent != value)
                {
                    _amt_percent = value; RaisePropertyChanged("amt_percent", ModelEntityUpdated);
                }
            }
        }

        public string sold_to_address
        {
            get
            {
                return _sold_to_address;
            }

            set
            {
                if (_sold_to_address != value)
                {
                    _sold_to_address = value; RaisePropertyChanged("sold_to_address", ModelEntityUpdated);
                }
            }
        }
        public string status_remark
        {
            get
            {
                return _status_remark;
            }

            set
            {
                if (_status_remark != value)
                {
                    _status_remark = value; RaisePropertyChanged("status_remark", ModelEntityUpdated);
                }
            }
        }
        private string _p_term { get; set; }
        public string p_term
        {
            get
            {
                return _p_term;
            }

            set
            {
                if (_p_term != value)
                {
                    _p_term = value; RaisePropertyChanged("p_term", ModelEntityUpdated);
                }
            }
        }
        
        public string LoctnNm
        {
            get
            {
                return _LoctnNm;
            }

            set
            {
                if (_LoctnNm != value)
                {
                    _LoctnNm = value; RaisePropertyChanged("LoctnNm", ModelEntityUpdated);
                }
            }
        }

        public string PartyEmailId
        {
            get
            {
                return _PartyEmailId;
            }

            set
            {
                if (_PartyEmailId != value)
                {
                    _PartyEmailId = value; RaisePropertyChanged("PartyEmailId", ModelEntityUpdated);
                }
            }
        }

        public string PersonEmailId
        {
            get
            {
                return _PersonEmailId;
            }

            set
            {
                if (_PersonEmailId != value)
                {
                    _PersonEmailId = value; RaisePropertyChanged("PersonEmailId", ModelEntityUpdated);
                }
            }
        }

        public Nullable<int> ref_party_contact
        {
            get { return _ref_party_contact; }
            set
            {
                if (_ref_party_contact != value)
                {
                    _ref_party_contact = value; RaisePropertyChanged("ref_party_contact", ModelEntityUpdated);
                }
            }
        }

        public string ref_contact_name
        {
            get { return _ref_contact_name; }
            set
            {
                if (_ref_contact_name != value)
                {
                    _ref_contact_name = value; RaisePropertyChanged("ref_contact_name", ModelEntityUpdated);
                }
            }
        }
        
        public string language
        {
            get { return _language; }
            set
            {
                if (_language != value)
                {
                    _language = value; RaisePropertyChanged("language", ModelEntityUpdated);
                }
            }
        }
        public string doc_history_no
        {
            get { return _doc_history_no; }
            set
            {
                if (_doc_history_no != value)
                {
                    _doc_history_no = value; RaisePropertyChanged("doc_history_no", ModelEntityUpdated);
                }
            }
        }

        public string CSTNo
        {
            get { return _CSTNo; }
            set
            {
                if (_CSTNo != value)
                {
                    _CSTNo = value; RaisePropertyChanged("CSTNo", ModelEntityUpdated);
                }
            }
        }

        public string VATNo
        {
            get { return _VATNo; }
            set
            {
                if (_VATNo != value)
                {
                    _VATNo = value; RaisePropertyChanged("VATNo", ModelEntityUpdated);
                }
            }
        }

        public string service_tax_no
        {
            get { return _service_tax_no; }
            set
            {
                if (_service_tax_no != value)
                {
                    _service_tax_no = value; RaisePropertyChanged("service_tax_no", ModelEntityUpdated);
                }
            }
        }

        public string PanNo
        {
            get { return _PanNo; }
            set
            {
                if (_PanNo != value)
                {
                    _PanNo = value; RaisePropertyChanged("PanNo", ModelEntityUpdated);
                }
            }
        }
        public string PhNo
        {
            get { return _PhNo; }
            set
            {
                if (_PhNo != value)
                {
                    _PhNo = value; RaisePropertyChanged("PhNo", ModelEntityUpdated);
                }
            }
        }
        public string FaxNo
        {
            get { return _FaxNo; }
            set
            {
                if (_FaxNo != value)
                {
                    _FaxNo = value; RaisePropertyChanged("FaxNo", ModelEntityUpdated);
                }
            }
        }
        public string PhNos
        {
            get { return _PhNos; }
            set
            {
                if (_PhNos != value)
                {
                    _PhNos = value; RaisePropertyChanged("PhNos", ModelEntityUpdated);
                }
            }
        }
        public string FaxNos
        {
            get { return _FaxNos; }
            set
            {
                if (_FaxNos != value)
                {
                    _FaxNos = value; RaisePropertyChanged("FaxNos", ModelEntityUpdated);
                }
            }
        }

        public string TranParty_name
        {
            get { return _TranParty_name; }
            set
            {
                if (_TranParty_name != value)
                {
                    _TranParty_name = value; RaisePropertyChanged("TranParty_name", ModelEntityUpdated);
                }
            }
        }

        public string remark1
        {
            get { return _remark1; }
            set
            {
                if (_remark1 != value)
                {
                    _remark1 = value; RaisePropertyChanged("remark1", ModelEntityUpdated);
                }
            }
        }
        public string remark2
        {
            get { return _remark2; }
            set
            {
                if (_remark2 != value)
                {
                    _remark2 = value; RaisePropertyChanged("remark2", ModelEntityUpdated);
                }
            }
        }
        public string remark3
        {
            get { return _remark3; }
            set
            {
                if (_remark3 != value)
                {
                    _remark3 = value; RaisePropertyChanged("remark3", ModelEntityUpdated);
                }
            }
        }
        public string remark4
        {
            get { return _remark4; }
            set
            {
                if (_remark4 != value)
                {
                    _remark4 = value; RaisePropertyChanged("remark4", ModelEntityUpdated);
                }
            }
        }
        public string notify_nm
        {
            get { return _notify_nm; }
            set
            {
                if (_notify_nm != value)
                {
                    _notify_nm = value; RaisePropertyChanged("notify_nm", ModelEntityUpdated);
                }
            }
        }
        public string notify_ph
        {
            get { return _notify_ph; }
            set
            {
                if (_notify_ph != value)
                {
                    _notify_ph = value; RaisePropertyChanged("notify_ph", ModelEntityUpdated);
                }
            }
        }
        public string notify_address
        {
            get { return _notify_address; }
            set
            {
                if (_notify_address != value)
                {
                    _notify_address = value; RaisePropertyChanged("notify_address", ModelEntityUpdated);
                }
            }
        }
        public string location
        {
            get { return _location; }
            set
            {
                if (_location != value)
                {
                    _location = value; RaisePropertyChanged("location", ModelEntityUpdated);
                }
            }
        }
        public string incoterm2
        {
            get { return _incoterm2; }
            set
            {
                if (_incoterm2 != value)
                {
                    _incoterm2 = value; RaisePropertyChanged("incoterm2", ModelEntityUpdated);
                }
            }
        }
        public decimal? order_limit
        {
            get { return _order_limit; }
            set
            {
                if (_order_limit != value)
                {
                    _order_limit = value; RaisePropertyChanged("order_limit", ModelEntityUpdated);
                }
            }
        }
        public bool? order_limit_tax
        {
            get { return _order_limit_tax; }
            set
            {
                if (_order_limit_tax != value)
                {
                    _order_limit_tax = value; RaisePropertyChanged("order_limit_tax", ModelEntityUpdated);
                }
            }
        }
        public decimal? net_value
        {
            get { return _net_value; }
            set
            {
                if (_net_value != value)
                {
                    _net_value = value; RaisePropertyChanged("net_value");
                }
            }
        }
        public string withholding_tax
        {
            get { return _withholding_tax; }
            set
            {
                if (_withholding_tax != value)
                {
                    _withholding_tax = value; RaisePropertyChanged("withholding_tax");
                }
            }
        }
        public decimal? withholding_value
        {
            get { return _withholding_value; }
            set
            {
                if (_withholding_value != value)
                {
                    _withholding_value = value; RaisePropertyChanged("withholding_value");
                }
            }
        }
        public decimal? withholding_ex_amt
        {
            get { return _withholding_ex_amt; }
            set
            {
                if (_withholding_ex_amt != value)
                {
                    _withholding_ex_amt = value; RaisePropertyChanged("withholding_ex_amt");
                }
            }
        }
        public decimal? local_tax_amt
        {
            get { return _local_tax_amt; }
            set
            {
                if (_local_tax_amt != value)
                {
                    _local_tax_amt = value; RaisePropertyChanged("local_tax_amt");
                }
            }
        }
        public decimal? local_total_amt
        {
            get { return _local_total_amt; }
            set
            {
                if (_local_total_amt != value)
                {
                    _local_total_amt = value; RaisePropertyChanged("local_total_amt");
                }
            }
        }
        public decimal? local_round_up
        {
            get { return _local_round_up; }
            set
            {
                if (_local_round_up != value)
                {
                    _local_round_up = value; RaisePropertyChanged("local_round_up");
                }
            }
        }
        public decimal? local_roundup_total
        {
            get { return _local_roundup_total; }
            set
            {
                if (_local_roundup_total != value)
                {
                    _local_roundup_total = value; RaisePropertyChanged("local_roundup_total");
                }
            }
        }
        public decimal? local_net_value
        {
            get { return _local_net_value; }
            set
            {
                if (_local_net_value != value)
                {
                    _local_net_value = value; RaisePropertyChanged("local_net_value");
                }
            }
        }
        public decimal? other_charges
        {
            get
            {
                return _other_charges;
            }

            set
            {
                if (_other_charges != value)
                {
                    _other_charges = value; RaisePropertyChanged("other_charges");
                }
            }
        }
        public string bom_no
        {
            get
            {
                return _bom_no;
            }

            set
            {
                if (_bom_no != value)
                {
                    _bom_no = value; RaisePropertyChanged("bom_no");
                }
            }
        }

        public decimal? gross_value
        {
            get
            {
                return _gross_value;
            }

            set
            {
                if (_gross_value != value)
                {
                    _gross_value = value; RaisePropertyChanged("gross_value");
                }
            }
        }
        public decimal? effective_value
        {
            get
            {
                return _effective_value;
            }

            set
            {
                if (_effective_value != value)
                {
                    _effective_value = value; RaisePropertyChanged("effective_value");
                }
            }
        }
        public decimal? disc_amt
        {
            get
            {
                return _disc_amt;
            }

            set
            {
                if (_disc_amt != value)
                {
                    _disc_amt = value; RaisePropertyChanged("disc_amt");
                }
            }
        }
        public decimal? tax_amount
        {
            get
            {
                return _tax_amount;
            }

            set
            {
                if (_tax_amount != value)
                {
                    _tax_amount = value; RaisePropertyChanged("tax_amount");
                }
            }
        }

        public string gst_PartyId
        {
            get { return _gst_PartyId; }
            set
            {
                if (_gst_PartyId != value)
                {
                    _gst_PartyId = value; RaisePropertyChanged("gst_PartyId", ModelEntityUpdated);
                }
            }
        }
        public string buss_place
        {
            get { return _buss_place; }
            set
            {
                if (_buss_place != value)
                {
                    _buss_place = value; RaisePropertyChanged("buss_place", ModelEntityUpdated);
                }
            }
        }

        public string gstinno
        {
            get { return _gstinno; }
            set
            {
                if (_gstinno != value)
                {
                    _gstinno = value; RaisePropertyChanged("gstinno", ModelEntityUpdated);
                }
            }
        }
        public Nullable<System.DateTime> gstindate
        {
            get { return _gstindate; }
            set
            {
                if (_gstindate != value)
                {
                    _gstindate = value; RaisePropertyChanged("gstindate", ModelEntityUpdated);
                }
            }
        }

        public string soldto_buss_place
        {
            get { return _soldto_buss_place; }
            set
            {
                if (_soldto_buss_place != value)
                {
                    _soldto_buss_place = value; RaisePropertyChanged("soldto_buss_place", ModelEntityUpdated);
                }
            }
        }

        public string shipto_buss_place
        {
            get { return _shipto_buss_place; }
            set
            {
                if (_shipto_buss_place != value)
                {
                    _shipto_buss_place = value; RaisePropertyChanged("shipto_buss_place", ModelEntityUpdated);
                }
            }
        }
        private string _crm_doc_no;
        public string crm_doc_no
        {
            get { return _crm_doc_no; }
            set
            {
                if (_crm_doc_no != value)
                {
                    _crm_doc_no = value; RaisePropertyChanged("crm_doc_no");
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
        private string _notify2_address;
        public string notify2_address
        {
            get { return _notify2_address; }
            set
            {
                if(_notify2_address != value)
                {
                    _notify2_address = value; RaisePropertyChanged("notify2_address");
                }
            }
        }
        private string _weight_unit;
        public string weight_unit
        {
            get { return _weight_unit; }
            set
            {
                if (_weight_unit != value)
                {
                    _weight_unit = value; RaisePropertyChanged("weight_unit");
                }
            }
        }
        private string _account_no;
        public string account_no
        {
            get
            {
                return _account_no;
            }

            set
            {
                if (_account_no != value)
                {
                    _account_no = value; RaisePropertyChanged("account_no", ModelEntityUpdated);
                }
            }
        }
        private string _project_location;
        public string project_location
        {
            get { return _project_location; }
            set
            {
                if (_project_location != value)
                {
                    _project_location = value; RaisePropertyChanged("project_location", ModelEntityUpdated);
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
                    _title = value; RaisePropertyChanged("title", ModelEntityUpdated);
                }
            }
        }
        private string _DesigName;
        public string DesigName
        {
            get { return _DesigName; }
            set
            {
                if (_DesigName != value)
                {
                    _DesigName = value; RaisePropertyChanged("DesigName", ModelEntityUpdated);
                }
            }
        }
        private string _vendor_remark;
        public string vendor_remark
        {
            get { return _vendor_remark; }
            set
            {
                if (_vendor_remark != value)
                {
                    _vendor_remark = value; RaisePropertyChanged("vendor_remark", ModelEntityUpdated);
                }
            }
        }
        private string _textdata;
        public string textdata
        {
            get { return _textdata; }
            set { if (_textdata != value) { _textdata = value; RaisePropertyChanged("textdata", ModelEntityUpdated); } }
        }
        private string _micr_code;
        public string micr_code
        {
            get { return _micr_code; }
            set { if (_micr_code != value) { _micr_code = value; RaisePropertyChanged("micr_code"); } }
        }
        private string _acc_no;
        public string acc_no
        {
            get { return _acc_no; }
            set { if (_acc_no != value) { _acc_no = value; RaisePropertyChanged("acc_no"); } }
        }
        private string _acc_name;
        public string acc_name
        {
            get { return _acc_name; }
            set { if (_acc_name != value) { _acc_name = value; RaisePropertyChanged("acc_name"); } }
        }
        private string _ad_code;
        public string ad_code
        {
            get { return _ad_code; }
            set { if (_ad_code != value) { _ad_code = value; RaisePropertyChanged("ad_code"); } }
        }
        private string _acc_type;
        public string acc_type
        {
            get { return _acc_type; }
            set { if (_acc_type != value) { _acc_type = value; RaisePropertyChanged("acc_type"); } }
        }
        private string _iban_no;
        public string iban_no
        {
            get { return _iban_no; }
            set { if (_iban_no != value) { _iban_no = value; RaisePropertyChanged("iban_no"); } }
        }
        private string _letter_text;
        public string letter_text
        {
            get { return _letter_text; }
            set { if (_letter_text != value) { _letter_text = value; RaisePropertyChanged("letter_text"); } }
        }
        private string _body_text;
        public string body_text
        {
            get { return _body_text; }
            set { if (_body_text != value) {_body_text = value; RaisePropertyChanged("body_text"); } }
        }
        private string _header_text;
        public string header_text
        {
            get { return _header_text; }
            set { if (_header_text != value) { _header_text = value; RaisePropertyChanged("header_text"); } }
        }
        private string _footer_text;
        public string footer_text
        {
            get { return _footer_text; }
            set { if (_footer_text != value) { _footer_text = value; RaisePropertyChanged("footer_text"); } }
        }
        private string _project_id;
        public string project_id
        {
            get
            {
                return _project_id;
            }

            set
            {
                if (_project_id != value)
                {
                    _project_id = value; RaisePropertyChanged("project_id", ModelEntityUpdated);
                }
            }
        }

        private string _element_id;
        public string element_id
        {
            get
            {
                return _element_id;
            }

            set
            {
                if (_element_id != value)
                {
                    _element_id = value; RaisePropertyChanged("element_id", ModelEntityUpdated);
                }
            }
        }
        private int? _element_no;
        public int? element_no
        {
            get
            {
                return _element_no;
            }

            set
            {
                if (_element_no != value)
                {
                    _element_no = value; RaisePropertyChanged("element_no", ModelEntityUpdated);
                }
            }
        }
        private string _date_type;
        public string date_type
        {
            get
            {
                return _date_type;
            }

            set
            {
                if (_date_type != value)
                {
                    _date_type = value; RaisePropertyChanged("date_type");
                }
            }
        }
        private string _billing_type;
        public string billing_type
        {
            get
            {
                return _billing_type;
            }

            set
            {
                if (_billing_type != value)
                {
                    _billing_type = value; RaisePropertyChanged("billing_type");
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
        
        private string _cp_code;
        public string cp_code
        {
            get
            {
                return _cp_code;
            }

            set
            {
                if (_cp_code != value)
                {
                    _cp_code = value; RaisePropertyChanged("cp_code");
                }
            }
        }


        public string billing_type_name { get; set; }
        public string date_type_name { get; set; }

        private string _abg_bank;
        public string abg_bank
        {
            get
            {
                return _abg_bank;
            }

            set
            {
                if (_abg_bank != value)
                {
                    _abg_bank = value; RaisePropertyChanged("abg_bank", ModelEntityUpdated);
                }
            }
        }
        private decimal? _abg_value;
        public decimal? abg_value
        {
            get
            {
                return _abg_value;
            }

            set
            {
                if (_abg_value != value)
                {
                    _abg_value = value; RaisePropertyChanged("abg_value", ModelEntityUpdated);
                }
            }
        }
        private string _abg_type;
        public string abg_type
        {
            get
            {
                return _abg_type;
            }

            set
            {
                if (_abg_type != value)
                {
                    _abg_type = value; RaisePropertyChanged("abg_type", ModelEntityUpdated);
                }
            }
        }
        private string _abg_no;
        public string abg_no
        {
            get
            {
                return _abg_no;
            }

            set
            {
                if (_abg_no != value)
                {
                    _abg_no = value; RaisePropertyChanged("abg_no", ModelEntityUpdated);
                }
            }
        }
        private DateTime? _abg_start_date;
        public DateTime? abg_start_date
        {
            get
            {
                return _abg_start_date;
            }

            set
            {
                if (_abg_start_date != value)
                {
                    _abg_start_date = value; RaisePropertyChanged("abg_start_date", ModelEntityUpdated);
                }
            }
        }

        private string _project_name;
        public string project_name
        {
            get
            {
                return _project_name;
            }

            set
            {
                if (_project_name != value)
                {
                    _project_name = value; RaisePropertyChanged("project_name", ModelEntityUpdated);
                }
            }
        }

        private string _element_name;
        public string element_name
        {
            get
            {
                return _element_name;
            }

            set
            {
                if (_element_name != value)
                {
                    _element_name = value; RaisePropertyChanged("element_name", ModelEntityUpdated);
                }
            }
        }

        private string _catlog_name;
        public string catlog_name
        {
            get
            {
                return _catlog_name;
            }

            set
            {
                if (_catlog_name != value)
                {
                    _catlog_name = value; RaisePropertyChanged("catlog_name", ModelEntityUpdated);
                }
            }
        }

        private bool? _ind_source;
        [Required(ErrorMessage = "Field 'Transaction Trade Type' is required.")]
        public bool? ind_source
        {
            get
            {
                return _ind_source;
            }
            set
            {
                if (_ind_source != value)
                {
                    _ind_source = value; RaisePropertyChanged("ind_source", ModelEntityUpdated);

                }
            }
        }
        public string XmlDataDocument_SEL_T001_A { get; set; }
        public string XDOC_SEL_T001_PART { get; set; }
        public string XmlDataDocument_ACC_T006_B { get; set; }
        public string XmlDataDocument_SEL_T002 { get; set; }
        public string XmlDataDocument_SEL_T002_A { get; set; }
        public string XmlDataDocument_ACC_T006_D { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }
        public string XmlDataDocument_COM_T003 { get; set; }
        public string XmlDataDocument_SEL_T001_E { get; set; }
        public string XDOC_TC { get; set; }
        public string XDOC_RS { get; set; }

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
        private string _ref_doc_cat;
        public string ref_doc_cat
        {
            get { return _ref_doc_cat; }
            set
            {
                if (_ref_doc_cat != value)
                {
                    _ref_doc_cat = value; RaisePropertyChanged("ref_doc_cat", ModelEntityUpdated);
                }
            }
        }
        #endregion 
    }
    public class SEL_T001_PART : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id { get; set; }
        public int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;

                    RaisePropertyChanged("id");
                }
            }
        }
        private string _comp_code { get; set; }
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                if (_comp_code != value)
                {
                    _comp_code = value;

                    RaisePropertyChanged("comp_code");
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
                    _doc_no = value;

                    RaisePropertyChanged("doc_no");
                }
            }
        }
        private int? _sd_item_row_id { get; set; }
        public int? sd_item_row_id
        {
            get { return _sd_item_row_id; }
            set
            {
                if (_sd_item_row_id != value)
                {
                    _sd_item_row_id = value;

                    RaisePropertyChanged("sd_item_row_id");
                }
            }
        }
        private string _pf_code { get; set; }
        public string pf_code
        {
            get { return _pf_code; }
            set
            {
                if (_pf_code != value)
                {
                    _pf_code = value;

                    RaisePropertyChanged("pf_code");
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
                    _party_code = value;

                    RaisePropertyChanged("party_code");
                }
            }
        }
        private string _party_code2 { get; set; }
        public string party_code2
        {
            get { return _party_code2; }
            set
            {
                if (_party_code2 != value)
                {
                    _party_code2 = value;

                    RaisePropertyChanged("party_code2");
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
                    _emp_id = value;

                    RaisePropertyChanged("emp_id");
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
                    _emp_name = value;

                    RaisePropertyChanged("emp_name");
                }
            }
        }
        private string _contact_no { get; set; }
        public string contact_no
        {
            get { return _contact_no; }
            set
            {
                if (_contact_no != value)
                {
                    _contact_no = value;

                    RaisePropertyChanged("contact_no");
                }
            }
        }
        private string _email_id { get; set; }
        public string email_id
        {
            get { return _email_id; }
            set
            {
                if (_email_id != value)
                {
                    _email_id = value;

                    RaisePropertyChanged("email_id");
                }
            }
        }
        private string _add_code { get; set; }
        public string add_code
        {
            get { return _add_code; }
            set
            {
                if (_add_code != value)
                {
                    _add_code = value;

                    RaisePropertyChanged("add_code");
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
                    _short_text = value;

                    RaisePropertyChanged("short_text");
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
                    _active = value;

                    RaisePropertyChanged("active");
                }
            }
        }

        private string _pf_name { get; set; }
        public string pf_name
        {
            get { return _pf_name; }
            set
            {
                if (_pf_name != value)
                {
                    _pf_name = value;

                    RaisePropertyChanged("pf_name");
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
                    _party_name = value;

                    RaisePropertyChanged("party_name");
                }
            }
        }
        private string _party_name2 { get; set; }
        public string party_name2
        {
            get { return _party_name2; }
            set
            {
                if (_party_name2 != value)
                {
                    _party_name2 = value;

                    RaisePropertyChanged("party_name2");
                }
            }
        }
        private string _location { get; set; }
        public string location
        {
            get { return _location; }
            set
            {
                if (_location != value)
                {
                    _location = value;

                    RaisePropertyChanged("location");
                }
            }
        }

    }
    public class SEL_T001_A : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int _id;
        private string _sono;
        private string _order_to_plant;
        private string _ItemCode;
        private string _Description;
        private decimal? _quantity;
        private int _line_id;
        private string _unit_code;
        private decimal? _unit_price;
        private string _tax_id;
        private decimal? _discount;
        private decimal? _sub_total;
        private bool _active;
        private string _location_Id;
        private string _comp_code;
        private string _PartyId;
        private System.DateTime _add_date;
        private string _add_by;
        private DateTime? _edit_date;
        private string _editby;
        private string _req_no;
        private string _plan_b_id;
        private string _item_cat;
        private string _sku;
        private string _sku_desc;
        private DateTime? _min_planned_date;
        private string _t_status;
        private decimal? _conversn_fact;
        private decimal? _gross_wt;
        private decimal? _net_wt;
        private string _weight_unit_cd;
        private decimal? _volume;
        private string _volume_unit_cd;
        private string _move_dest_id;
        private bool? _invoiced;
        private DateTime? _date_planned;
        private int? _account_analytic_id;
        private string _acc_code;
        private string _store_code;
        private string _wa_code;
        private string _para1;
        private string _para2;
        private string _para3;
        private int? _para4;
        private string _para5;
        private string _para6;
        private string _para7;
        private decimal? _para8;
        private string _para9;
        private string _para10;
        private string _para11;
        private bool? _para12;
        private DateTime? _para13;
        private string _para14;
        private string _para15;
        private string _para16;
        private decimal? _para17;
        private string _para18;
        private string _para19;
        private string _para20;
        private string _para21;
        private string _para22;
        private string _para23;
        private int? _para24;
        private string _supp_code;
        private string _para26;
        private string _para27;
        private int? _para28;
        private string _cust_ref;
        private DateTime? _cust_ref_date;
        private string _bid_inv_no;
        private string _quotation_no;
        private decimal? _short_excess_amt;
        private string _short_excess_flag;
        private string _delivery_ind;
        private string _gr_inv_ind;
        private string _order_ack_ind;
        private string _order_ack_no;
        private string _pur_agree_no;
        private string _pur_agree_item_cd;
        private string _ref_doc_no;
        private DateTime? _ref_doc_date;
        private string _ref_doc_type;
        private string _cust_mat_no;
        private decimal? _abs_deviation_qty;
        private decimal? _per_deviation_qty;
        private decimal? _over_del_tol;
        private decimal? _under_del_tol;
        private string _gr_ind;
        private string _incoterms;
        private string _p_term_code;
        private int? _pack_style;
        private string _terms_cond;
        private string _gl_code;
        private string _notify_party;
        private string _fin_year;
        private string _posting_period;
        private string _rel_delivery;
        private string _rel_billing;
        private int? _ref_item_row_id;
        private string _status_remark;
        private string _CstmrItmCod;
        private string _textdata;
        private string _PartyNm;
        private string _sch_no;
        private string _sch_date;
        private string _ink;
        private string _ild;
        private decimal? _shank_dia;
        private int? _tot_len_id;
        private string _total_len;
        private string _ink1;
        private string _ild1;
        private string _ModelNo;
        private string _BallType;
        private string _WireType;
        private Nullable<decimal> _BallDia;
        private int _ref_item_line_id;
        private string _doc_history_no;
        private Nullable<decimal> _local_discount;
        private Nullable<decimal> _local_sub_total;
        private Nullable<decimal> _net_value;
        private Nullable<decimal> _local_net_value;
        private string _bom_no;
        private Nullable<decimal> _gross_value;
        private Nullable<decimal> _effective_value;
        private Nullable<decimal> _tax_amount;
        private string _discount_type;
        private Nullable<decimal> _discount_amt;
        private string _article_no;
        //Added by Priya
        private int _pkgid { get; set; }
        private string _pkgunit { get; set; }
        private string _alert1 { get; set; }
        private string _symbol { get; set; }

        private string _ship_to_Party { get; set; }
        private int? _ship_to_add { get; set; }
        private string _buss_place { get; set; }
        private string _hs_code { get; set; }

        private decimal? _bal_qty;

        public decimal? bal_qty
        {
            get
            {
                return _bal_qty;
            }

            set
            {
                if (_bal_qty != value)
                {
                    _bal_qty = value; RaisePropertyChanged("bal_qty", ModelEntityUpdated);
                }
            }
        }
        public string symbol
        {
            get
            {
                return _symbol;
            }

            set
            {
                if (_symbol != value)
                {
                    _symbol = value; RaisePropertyChanged("symbol", ModelEntityUpdated);
                }
            }
        }

        public int id
        {
            get
            {
                return _id;
            }

            set
            {
                if (_id != value)
                {
                    _id = value; RaisePropertyChanged("id", ModelEntityUpdated);
                }
            }
        }

        public string sono
        {
            get
            {
                return _sono;
            }

            set
            {
                if (_sono != value)
                {
                    _sono = value; RaisePropertyChanged("sono", ModelEntityUpdated);
                }
            }
        }

        public string order_to_plant
        {
            get
            {
                return _order_to_plant;
            }

            set
            {
                if (_order_to_plant != value)
                {
                    _order_to_plant = value; RaisePropertyChanged("order_to_plant", ModelEntityUpdated);
                }
            }
        }

        //[Required(ErrorMessage = "Field 'Item' is required.")]
        public string ItemCode
        {
            get
            {
                return _ItemCode;
            }

            set
            {
                if (_ItemCode != value)
                {
                    _ItemCode = value; RaisePropertyChanged("ItemCode", ModelEntityUpdated);
                }
            }
        }

        public string Description
        {
            get
            {
                return _Description;
            }

            set
            {
                if (_Description != value)
                {
                    _Description = value; RaisePropertyChanged("Description", ModelEntityUpdated);
                }
            }
        }

        [Required(ErrorMessage = "Field 'Quantity' is required.")]
        public decimal? quantity
        {
            get
            {
                return _quantity;
            }

            set
            {
                if (_quantity != value)
                {
                    _quantity = value; RaisePropertyChanged("quantity", ModelEntityUpdated);
                }
            }
        }

        public int line_id
        {
            get
            {
                return _line_id;
            }

            set
            {
                if (_line_id != value)
                {
                    _line_id = value; RaisePropertyChanged("line_id", ModelEntityUpdated);
                }
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
                if (_unit_code != value)
                {
                    _unit_code = value; RaisePropertyChanged("unit_code", ModelEntityUpdated);
                }
            }
        }

        [Required(ErrorMessage = "Field 'Unit Price' is required.")]
        public decimal? unit_price
        {
            get
            {
                return _unit_price;
            }

            set
            {
                if (_unit_price != value)
                {
                    _unit_price = value; RaisePropertyChanged("unit_price", ModelEntityUpdated);
                }
            }
        }

        public string tax_id
        {
            get
            {
                return _tax_id;
            }

            set
            {
                if (_tax_id != value)
                {
                    _tax_id = value; RaisePropertyChanged("tax_id", ModelEntityUpdated);
                }
            }
        }

        public decimal? discount
        {
            get
            {
                return _discount;
            }

            set
            {
                if (_discount != value)
                {
                    _discount = value; RaisePropertyChanged("discount", ModelEntityUpdated);
                }
            }
        }

        public decimal? sub_total
        {
            get
            {
                return _sub_total;
            }

            set
            {
                if (_sub_total != value)
                {
                    _sub_total = value; RaisePropertyChanged("sub_total", ModelEntityUpdated);
                }
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
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active", ModelEntityUpdated);
                }
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
                if (_location_Id != value)
                {
                    _location_Id = value; RaisePropertyChanged("location_Id", ModelEntityUpdated);
                }
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
                if (_comp_code != value)
                {
                    _comp_code = value; RaisePropertyChanged("comp_code", ModelEntityUpdated);
                }
            }
        }

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

        public DateTime add_date
        {
            get
            {
                return _add_date;
            }

            set
            {
                if (_add_date != value)
                {
                    _add_date = value; RaisePropertyChanged("add_date", ModelEntityUpdated);
                }
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
                if (_add_by != value)
                {
                    _add_by = value; RaisePropertyChanged("add_by", ModelEntityUpdated);
                }
            }
        }

        public DateTime? edit_date
        {
            get
            {
                return _edit_date;
            }

            set
            {
                if (_edit_date != value)
                {
                    _edit_date = value; RaisePropertyChanged("edit_date", ModelEntityUpdated);
                }
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
                if (_editby != value)
                {
                    _editby = value; RaisePropertyChanged("editby", ModelEntityUpdated);
                }
            }
        }

        public string req_no
        {
            get
            {
                return _req_no;
            }

            set
            {
                if (_req_no != value)
                {
                    _req_no = value; RaisePropertyChanged("req_no", ModelEntityUpdated);
                }
            }
        }

        public string plan_b_id
        {
            get
            {
                return _plan_b_id;
            }

            set
            {
                if (_plan_b_id != value)
                {
                    _plan_b_id = value; RaisePropertyChanged("plan_b_id", ModelEntityUpdated);
                }
            }
        }

        public string item_cat
        {
            get
            {
                return _item_cat;
            }

            set
            {
                if (_item_cat != value)
                {
                    _item_cat = value; RaisePropertyChanged("item_cat", ModelEntityUpdated);
                }
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
                if (_sku != value)
                {
                    _sku = value; RaisePropertyChanged("sku", ModelEntityUpdated);
                }
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
                if (_sku_desc != value)
                {
                    _sku_desc = value; RaisePropertyChanged("sku_desc", ModelEntityUpdated);
                }
            }
        }

        public DateTime? min_planned_date
        {
            get
            {
                return _min_planned_date;
            }

            set
            {
                if (_min_planned_date != value)
                {
                    _min_planned_date = value; RaisePropertyChanged("min_planned_date", ModelEntityUpdated);
                }
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
                if (_t_status != value)
                {
                    _t_status = value; RaisePropertyChanged("t_status", ModelEntityUpdated);
                }
            }
        }

        public decimal? conversn_fact
        {
            get
            {
                return _conversn_fact;
            }

            set
            {
                if (_conversn_fact != value)
                {
                    _conversn_fact = value; RaisePropertyChanged("conversn_fact", ModelEntityUpdated);
                }
            }
        }

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
                    _gross_wt = value; RaisePropertyChanged("gross_wt", ModelEntityUpdated);
                }
            }
        }

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
                    _net_wt = value; RaisePropertyChanged("net_wt", ModelEntityUpdated);
                }
            }
        }

        public string weight_unit_cd
        {
            get
            {
                return _weight_unit_cd;
            }

            set
            {
                if (_weight_unit_cd != value)
                {
                    _weight_unit_cd = value; RaisePropertyChanged("weight_unit_cd", ModelEntityUpdated);
                }
            }
        }

        public decimal? volume
        {
            get
            {
                return _volume;
            }

            set
            {
                if (_volume != value)
                {
                    _volume = value; RaisePropertyChanged("volume", ModelEntityUpdated);
                }
            }
        }

        public string volume_unit_cd
        {
            get
            {
                return _volume_unit_cd;
            }

            set
            {
                if (_volume_unit_cd != value)
                {
                    _volume_unit_cd = value; RaisePropertyChanged("volume_unit_cd", ModelEntityUpdated);
                }
            }
        }

        public string move_dest_id
        {
            get
            {
                return _move_dest_id;
            }

            set
            {
                if (_move_dest_id != value)
                {
                    _move_dest_id = value; RaisePropertyChanged("move_dest_id", ModelEntityUpdated);
                }
            }
        }

        public bool? invoiced
        {
            get
            {
                return _invoiced;
            }

            set
            {
                if (_invoiced != value)
                {
                    _invoiced = value; RaisePropertyChanged("invoiced", ModelEntityUpdated);
                }
            }
        }

        public DateTime? date_planned
        {
            get
            {
                return _date_planned;
            }

            set
            {
                if (_date_planned != value)
                {
                    _date_planned = value; RaisePropertyChanged("date_planned", ModelEntityUpdated);
                }
            }
        }

        public int? account_analytic_id
        {
            get
            {
                return _account_analytic_id;
            }

            set
            {
                if (_account_analytic_id != value)
                {
                    _account_analytic_id = value; RaisePropertyChanged("account_analytic_id", ModelEntityUpdated);
                }
            }
        }

        public string acc_code
        {
            get
            {
                return _acc_code;
            }

            set
            {
                if (_acc_code != value)
                {
                    _acc_code = value; RaisePropertyChanged("acc_code", ModelEntityUpdated);
                }
            }
        }

        public string store_code
        {
            get
            {
                return _store_code;
            }

            set
            {
                if (_store_code != value)
                {
                    _store_code = value; RaisePropertyChanged("store_code", ModelEntityUpdated);
                }
            }
        }

        public string wa_code
        {
            get
            {
                return _wa_code;
            }

            set
            {
                if (_wa_code != value)
                {
                    _wa_code = value; RaisePropertyChanged("wa_code", ModelEntityUpdated);
                }
            }
        }

        public string para1
        {
            get
            {
                return _para1;
            }

            set
            {
                if (_para1 != value)
                {
                    _para1 = value; RaisePropertyChanged("para1", ModelEntityUpdated);
                }
            }
        }

        public string para2
        {
            get
            {
                return _para2;
            }

            set
            {
                if (_para2 != value)
                {
                    _para2 = value; RaisePropertyChanged("para2", ModelEntityUpdated);
                }
            }
        }

        public string para3
        {
            get
            {
                return _para3;
            }

            set
            {
                if (_para3 != value)
                {
                    _para3 = value; RaisePropertyChanged("para3", ModelEntityUpdated);
                }
            }
        }

        public int? para4
        {
            get
            {
                return _para4;
            }

            set
            {
                if (_para4 != value)
                {
                    _para4 = value; RaisePropertyChanged("para4", ModelEntityUpdated);
                }
            }
        }

        public string para5
        {
            get
            {
                return _para5;
            }

            set
            {
                if (_para5 != value)
                {
                    _para5 = value; RaisePropertyChanged("para5", ModelEntityUpdated);
                }
            }
        }

        public string para6
        {
            get
            {
                return _para6;
            }

            set
            {
                if (_para6 != value)
                {
                    _para6 = value; RaisePropertyChanged("para6", ModelEntityUpdated);
                }
            }
        }

        public string para7
        {
            get
            {
                return _para7;
            }

            set
            {
                if (_para7 != value)
                {
                    _para7 = value; RaisePropertyChanged("para7", ModelEntityUpdated);
                }
            }
        }

        public decimal? para8
        {
            get
            {
                return _para8;
            }

            set
            {
                if (_para8 != value)
                {
                    _para8 = value; RaisePropertyChanged("para8", ModelEntityUpdated);
                }
            }
        }

        public string para9
        {
            get
            {
                return _para9;
            }

            set
            {
                if (_para9 != value)
                {
                    _para9 = value; RaisePropertyChanged("para9", ModelEntityUpdated);
                }
            }
        }

        public string para10
        {
            get
            {
                return _para10;
            }

            set
            {
                if (_para10 != value)
                {
                    _para10 = value; RaisePropertyChanged("para10", ModelEntityUpdated);
                }
            }
        }

        public string para11
        {
            get
            {
                return _para11;
            }

            set
            {
                if (_para11 != value)
                {
                    _para11 = value; RaisePropertyChanged("para11", ModelEntityUpdated);
                }
            }
        }

        public bool? para12
        {
            get
            {
                return _para12;
            }

            set
            {
                if (_para12 != value)
                {
                    _para12 = value; RaisePropertyChanged("para12", ModelEntityUpdated);
                }
            }
        }

        public DateTime? para13
        {
            get
            {
                return _para13;
            }

            set
            {
                if (_para13 != value)
                {
                    _para13 = value; RaisePropertyChanged("para13", ModelEntityUpdated);
                }
            }
        }

        public string para14
        {
            get
            {
                return _para14;
            }

            set
            {
                if (_para14 != value)
                {
                    _para14 = value; RaisePropertyChanged("para14", ModelEntityUpdated);
                }
            }
        }

        public string para15
        {
            get
            {
                return _para15;
            }

            set
            {
                if (_para15 != value)
                {
                    _para15 = value; RaisePropertyChanged("para15", ModelEntityUpdated);
                }
            }
        }

        public string para16
        {
            get
            {
                return _para16;
            }

            set
            {
                if (_para16 != value)
                {
                    _para16 = value; RaisePropertyChanged("para16", ModelEntityUpdated);
                }
            }
        }

        public decimal? para17
        {
            get
            {
                return _para17;
            }

            set
            {
                if (_para17 != value)
                {
                    _para17 = value; RaisePropertyChanged("para17", ModelEntityUpdated);
                }
            }
        }

        public string para18
        {
            get
            {
                return _para18;
            }

            set
            {
                if (_para18 != value)
                {
                    _para18 = value; RaisePropertyChanged("para18", ModelEntityUpdated);
                }
            }
        }

        public string para19
        {
            get
            {
                return _para19;
            }

            set
            {
                if (_para19 != value)
                {
                    _para19 = value; RaisePropertyChanged("para19", ModelEntityUpdated);
                }
            }
        }

        public string para20
        {
            get
            {
                return _para20;
            }

            set
            {
                if (_para20 != value)
                {
                    _para20 = value; RaisePropertyChanged("para20", ModelEntityUpdated);
                }
            }
        }

        public string para21
        {
            get
            {
                return _para21;
            }

            set
            {
                if (_para21 != value)
                {
                    _para21 = value; RaisePropertyChanged("para21", ModelEntityUpdated);
                }
            }
        }

        public string para22
        {
            get
            {
                return _para22;
            }

            set
            {
                if (_para22 != value)
                {
                    _para22 = value; RaisePropertyChanged("para22", ModelEntityUpdated);
                }
            }
        }

        public string para23
        {
            get
            {
                return _para23;
            }

            set
            {
                if (_para23 != value)
                {
                    _para23 = value; RaisePropertyChanged("para23", ModelEntityUpdated);
                }
            }
        }

        public int? para24
        {
            get
            {
                return _para24;
            }

            set
            {
                if (_para24 != value)
                {
                    _para24 = value; RaisePropertyChanged("para24", ModelEntityUpdated);
                }
            }
        }

        public string supp_code
        {
            get
            {
                return _supp_code;
            }

            set
            {
                if (_supp_code != value)
                {
                    _supp_code = value; RaisePropertyChanged("supp_code", ModelEntityUpdated);
                }
            }
        }

        public string para26
        {
            get
            {
                return _para26;
            }

            set
            {
                if (_para26 != value)
                {
                    _para26 = value; RaisePropertyChanged("para26", ModelEntityUpdated);
                }
            }
        }

        public string para27
        {
            get
            {
                return _para27;
            }

            set
            {
                if (_para27 != value)
                {
                    _para27 = value; RaisePropertyChanged("para27", ModelEntityUpdated);
                }
            }
        }

        public int? para28
        {
            get
            {
                return _para28;
            }

            set
            {
                if (_para28 != value)
                {
                    _para28 = value; RaisePropertyChanged("para28", ModelEntityUpdated);
                }
            }
        }

        public string cust_ref
        {
            get
            {
                return _cust_ref;
            }

            set
            {
                if (_cust_ref != value)
                {
                    _cust_ref = value; RaisePropertyChanged("cust_ref", ModelEntityUpdated);
                }
            }
        }

        public DateTime? cust_ref_date
        {
            get
            {
                return _cust_ref_date;
            }

            set
            {
                if (_cust_ref_date != value)
                {
                    _cust_ref_date = value; RaisePropertyChanged("cust_ref_date", ModelEntityUpdated);
                }
            }
        }

        public string bid_inv_no
        {
            get
            {
                return _bid_inv_no;
            }

            set
            {
                if (_bid_inv_no != value)
                {
                    _bid_inv_no = value; RaisePropertyChanged("bid_inv_no", ModelEntityUpdated);
                }
            }
        }

        public string quotation_no
        {
            get
            {
                return _quotation_no;
            }

            set
            {
                if (_quotation_no != value)
                {
                    _quotation_no = value; RaisePropertyChanged("quotation_no", ModelEntityUpdated);
                }
            }
        }

        public decimal? short_excess_amt
        {
            get
            {
                return _short_excess_amt;
            }

            set
            {
                if (_short_excess_amt != value)
                {
                    _short_excess_amt = value; RaisePropertyChanged("short_excess_amt", ModelEntityUpdated);
                }
            }
        }

        public string short_excess_flag
        {
            get
            {
                return _short_excess_flag;
            }

            set
            {
                if (_short_excess_flag != value)
                {
                    _short_excess_flag = value; RaisePropertyChanged("short_excess_flag", ModelEntityUpdated);
                }
            }
        }

        public string delivery_ind
        {
            get
            {
                return _delivery_ind;
            }

            set
            {
                if (_delivery_ind != value)
                {
                    _delivery_ind = value; RaisePropertyChanged("delivery_ind", ModelEntityUpdated);
                }
            }
        }

        public string gr_inv_ind
        {
            get
            {
                return _gr_inv_ind;
            }

            set
            {
                if (_gr_inv_ind != value)
                {
                    _gr_inv_ind = value; RaisePropertyChanged("gr_inv_ind", ModelEntityUpdated);
                }
            }
        }

        public string order_ack_ind
        {
            get
            {
                return _order_ack_ind;
            }

            set
            {
                if (_order_ack_ind != value)
                {
                    _order_ack_ind = value; RaisePropertyChanged("order_ack_ind", ModelEntityUpdated);
                }
            }
        }

        public string order_ack_no
        {
            get
            {
                return _order_ack_no;
            }

            set
            {
                if (_order_ack_no != value)
                {
                    _order_ack_no = value; RaisePropertyChanged("order_ack_no", ModelEntityUpdated);
                }
            }
        }

        public string pur_agree_no
        {
            get
            {
                return _pur_agree_no;
            }

            set
            {
                if (_pur_agree_no != value)
                {
                    _pur_agree_no = value; RaisePropertyChanged("pur_agree_no", ModelEntityUpdated);
                }
            }
        }

        public string pur_agree_item_cd
        {
            get
            {
                return _pur_agree_item_cd;
            }

            set
            {
                if (_pur_agree_item_cd != value)
                {
                    _pur_agree_item_cd = value; RaisePropertyChanged("pur_agree_item_cd", ModelEntityUpdated);
                }
            }
        }

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

        public DateTime? ref_doc_date
        {
            get
            {
                return _ref_doc_date;
            }

            set
            {
                if (_ref_doc_date != value)
                {
                    _ref_doc_date = value; RaisePropertyChanged("ref_doc_date", ModelEntityUpdated);
                }
            }
        }

        public string ref_doc_type
        {
            get
            {
                return _ref_doc_type;
            }

            set
            {
                if (_ref_doc_type != value)
                {
                    _ref_doc_type = value; RaisePropertyChanged("ref_doc_type", ModelEntityUpdated);
                }
            }
        }

        public string cust_mat_no
        {
            get
            {
                return _cust_mat_no;
            }

            set
            {
                if (_cust_mat_no != value)
                {
                    _cust_mat_no = value; RaisePropertyChanged("cust_mat_no", ModelEntityUpdated);
                }
            }
        }

        public decimal? abs_deviation_qty
        {
            get
            {
                return _abs_deviation_qty;
            }

            set
            {
                if (_abs_deviation_qty != value)
                {
                    _abs_deviation_qty = value; RaisePropertyChanged("abs_deviation_qty", ModelEntityUpdated);
                }
            }
        }

        public decimal? per_deviation_qty
        {
            get
            {
                return _per_deviation_qty;
            }

            set
            {
                if (_per_deviation_qty != value)
                {
                    _per_deviation_qty = value; RaisePropertyChanged("per_deviation_qty", ModelEntityUpdated);
                }
            }
        }

        public decimal? over_del_tol
        {
            get
            {
                return _over_del_tol;
            }

            set
            {
                if (_over_del_tol != value)
                {
                    _over_del_tol = value; RaisePropertyChanged("over_del_tol", ModelEntityUpdated);
                }
            }
        }

        public decimal? under_del_tol
        {
            get
            {
                return _under_del_tol;
            }

            set
            {
                if (_under_del_tol != value)
                {
                    _under_del_tol = value; RaisePropertyChanged("under_del_tol", ModelEntityUpdated);
                }
            }
        }

        public string gr_ind
        {
            get
            {
                return _gr_ind;
            }

            set
            {
                if (_gr_ind != value)
                {
                    _gr_ind = value; RaisePropertyChanged("gr_ind", ModelEntityUpdated);
                }
            }
        }

        public string incoterms
        {
            get
            {
                return _incoterms;
            }

            set
            {
                if (_incoterms != value)
                {
                    _incoterms = value; RaisePropertyChanged("incoterms", ModelEntityUpdated);
                }
            }
        }
        
        public string p_term_code
        {
            get
            {
                return _p_term_code;
            }

            set
            {
                if (_p_term_code != value)
                {
                    _p_term_code = value; RaisePropertyChanged("p_term_code", ModelEntityUpdated);
                }
            }
        }

        public int? pack_style
        {
            get
            {
                return _pack_style;
            }

            set
            {
                if (_pack_style != value)
                {
                    _pack_style = value; RaisePropertyChanged("pack_style", ModelEntityUpdated);
                }
            }
        }

        public string terms_cond
        {
            get
            {
                return _terms_cond;
            }

            set
            {
                if (_terms_cond != value)
                {
                    _terms_cond = value; RaisePropertyChanged("terms_cond", ModelEntityUpdated);
                }
            }
        }

        public string gl_code
        {
            get
            {
                return _gl_code;
            }

            set
            {
                if (_gl_code != value)
                {
                    _gl_code = value; RaisePropertyChanged("gl_code", ModelEntityUpdated);
                }
            }
        }

        public string notify_party
        {
            get
            {
                return _notify_party;
            }

            set
            {
                if (_notify_party != value)
                {
                    _notify_party = value; RaisePropertyChanged("notify_party", ModelEntityUpdated);
                }
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
                if (_fin_year != value)
                {
                    _fin_year = value; RaisePropertyChanged("fin_year", ModelEntityUpdated);
                }
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
                if (_posting_period != value)
                {
                    _posting_period = value; RaisePropertyChanged("posting_period", ModelEntityUpdated);
                }
            }
        }

        public string rel_delivery
        {
            get
            {
                return _rel_delivery;
            }

            set
            {
                if (_rel_delivery != value)
                {
                    _rel_delivery = value; RaisePropertyChanged("rel_delivery", ModelEntityUpdated);
                }
            }
        }

        public string rel_billing
        {
            get
            {
                return _rel_billing;
            }

            set
            {
                if (_rel_billing != value)
                {
                    _rel_billing = value; RaisePropertyChanged("rel_billing", ModelEntityUpdated);
                }
            }
        }

        public int? ref_item_row_id
        {
            get
            {
                return _ref_item_row_id;
            }

            set
            {
                if (_ref_item_row_id != value)
                {
                    _ref_item_row_id = value; RaisePropertyChanged("ref_item_row_id", ModelEntityUpdated);
                }
            }
        }

        public int ref_item_line_id
        {
            get
            {
                return _ref_item_line_id;
            }

            set
            {
                if (_ref_item_line_id != value)
                {
                    _ref_item_line_id = value; RaisePropertyChanged("ref_item_line_id", ModelEntityUpdated);
                }
            }
        }
        //Scaler 

        private Nullable<bool> _StockUnt;
        public Nullable<bool> StockUnt
        {
            get { return _StockUnt; }
            set
            {
                if (_StockUnt != value)
                {
                    _StockUnt = value;
                    RaisePropertyChanged("StockUnt");
                }
            }
        }
        private string _SubCatCode;
        public string SubCatCode
        {
            get { return _SubCatCode; }
            set
            {
                if (_SubCatCode != value)
                {
                    _SubCatCode = value;
                    RaisePropertyChanged("SubCatCode");
                }
            }
        }
        public string CstmrItmCod
        {
            get
            {
                return _CstmrItmCod;
            }

            set
            {
                if (_CstmrItmCod != value)
                {
                    _CstmrItmCod = value; RaisePropertyChanged("CstmrItmCod", ModelEntityUpdated);
                }
            }
        }

        public string status_remark
        {
            get
            {
                return _status_remark;
            }

            set
            {
                if (_status_remark != value)
                {
                    _status_remark = value; RaisePropertyChanged("status_remark", ModelEntityUpdated);
                }
            }
        }

        public string textdata
        {
            get
            {
                return _textdata;
            }

            set
            {
                if (_textdata != value)
                {
                    _textdata = value; RaisePropertyChanged("textdata", ModelEntityUpdated);
                }
            }
        }

        public string PartyNm
        {
            get
            {
                return _PartyNm;
            }

            set
            {
                if (_PartyNm != value)
                {
                    _PartyNm = value; RaisePropertyChanged("PartyNm", ModelEntityUpdated);
                }
            }
        }

        public string sch_no
        {
            get
            {
                return _sch_no;
            }

            set
            {
                if (_sch_no != value)
                {
                    _sch_no = value; RaisePropertyChanged("sch_no", ModelEntityUpdated);
                }
            }
        }


        public string sch_date
        {
            get
            {
                return _sch_date;
            }

            set
            {
                if (_sch_date != value)
                {
                    _sch_date = value; RaisePropertyChanged("sch_date", ModelEntityUpdated);
                }
            }
        }
        public string ink
        {
            get
            {
                return _ink;
            }

            set
            {
                if (_ink != value)
                {
                    _ink = value; RaisePropertyChanged("ink", ModelEntityUpdated);
                }
            }
        }

        public string ild
        {
            get
            {
                return _ild;
            }

            set
            {
                if (_ild != value)
                {
                    _ild = value; RaisePropertyChanged("ild", ModelEntityUpdated);
                }
            }
        }

        public decimal? shank_dia
        {
            get
            {
                return _shank_dia;
            }

            set
            {
                if (_shank_dia != value)
                {
                    _shank_dia = value; RaisePropertyChanged("shank_dia", ModelEntityUpdated);
                }
            }
        }

        public int? tot_len_id
        {
            get
            {
                return _tot_len_id;
            }

            set
            {
                if (_tot_len_id != value)
                {
                    _tot_len_id = value; RaisePropertyChanged("tot_len_id", ModelEntityUpdated);
                }
            }
        }

        public string total_len
        {
            get
            {
                return _total_len;
            }

            set
            {
                if (_total_len != value)
                {
                    _total_len = value; RaisePropertyChanged("total_len", ModelEntityUpdated);
                }
            }
        }

        public string ink1
        {
            get
            {
                return _ink1;
            }

            set
            {
                if (_ink1 != value)
                {
                    _ink1 = value; RaisePropertyChanged("ink1", ModelEntityUpdated);
                }
            }
        }

        public string ild1
        {
            get
            {
                return _ild1;
            }

            set
            {
                if (_ild1 != value)
                {
                    _ild1 = value; RaisePropertyChanged("ild1", ModelEntityUpdated);
                }
            }
        }
        public string ModelNo
        {
            get
            {
                return _ModelNo;
            }

            set
            {
                if (_ModelNo != value)
                {
                    _ModelNo = value; RaisePropertyChanged("ModelNo", ModelEntityUpdated);
                }
            }
        }
        public string BallType
        {
            get
            {
                return _BallType;
            }

            set
            {
                if (_BallType != value)
                {
                    _BallType = value; RaisePropertyChanged("BallType", ModelEntityUpdated);
                }
            }
        }
        public string WireType
        {
            get
            {
                return _WireType;
            }

            set
            {
                if (_WireType != value)
                {
                    _WireType = value; RaisePropertyChanged("WireType", ModelEntityUpdated);
                }
            }
        }
        public Nullable<decimal> BallDia
        {
            get
            {
                return _BallDia;
            }

            set
            {
                if (_BallDia != value)
                {
                    _BallDia = value; RaisePropertyChanged("BallDia", ModelEntityUpdated);
                }
            }
        }
        public int pkgid
        {
            get
            {
                return _pkgid;
            }

            set
            {
                if (_pkgid != value)
                {
                    _pkgid = value; RaisePropertyChanged("pkgid");
                }
            }
        }
        public string pkgunit
        {
            get
            {
                return _pkgunit;
            }

            set
            {
                if (_pkgunit != value)
                {
                    _pkgunit = value; RaisePropertyChanged("pkgunit");
                }
            }
        }

        public string alert1
        {
            get
            {
                return _alert1;
            }

            set
            {
                if (_alert1 != value)
                {
                    _alert1 = value; RaisePropertyChanged("alert1");
                }
            }
        }

        public string doc_history_no
        {
            get
            {
                return _doc_history_no;
            }

            set
            {
                if (_doc_history_no != value)
                {
                    _doc_history_no = value; RaisePropertyChanged("doc_history_no");
                }
            }
        }

        public decimal? local_discount
        {
            get
            {
                return _local_discount;
            }

            set
            {
                if (_local_discount != value)
                {
                    _local_discount = value; RaisePropertyChanged("local_discount");
                }
            }
        }
        public decimal? local_sub_total
        {
            get
            {
                return _local_sub_total;
            }

            set
            {
                if (_local_sub_total != value)
                {
                    _local_sub_total = value; RaisePropertyChanged("local_sub_total");
                }
            }
        }
        public decimal? net_value
        {
            get
            {
                return _net_value;
            }

            set
            {
                if (_net_value != value)
                {
                    _net_value = value; RaisePropertyChanged("net_value");
                }
            }
        }
        public decimal? local_net_value
        {
            get
            {
                return _local_net_value;
            }

            set
            {
                if (_local_net_value != value)
                {
                    _local_net_value = value; RaisePropertyChanged("local_net_value");
                }
            }
        }
        public string bom_no
        {
            get
            {
                return _bom_no;
            }

            set
            {
                if (_bom_no != value)
                {
                    _bom_no = value; RaisePropertyChanged("bom_no");
                }
            }
        }
        public decimal? gross_value
        {
            get
            {
                return _gross_value;
            }

            set
            {
                if (_gross_value != value)
                {
                    _gross_value = value; RaisePropertyChanged("gross_value");
                }
            }
        }
        public decimal? effective_value
        {
            get
            {
                return _effective_value;
            }

            set
            {
                if (_effective_value != value)
                {
                    _effective_value = value; RaisePropertyChanged("effective_value");
                }
            }
        }
        public decimal? tax_amount
        {
            get
            {
                return _tax_amount;
            }

            set
            {
                if (_tax_amount != value)
                {
                    _tax_amount = value; RaisePropertyChanged("tax_amount");
                }
            }
        }
        public string discount_type
        {
            get
            {
                return _discount_type;
            }

            set
            {
                if (value == null)
                {
                    _discount_type = value; RaisePropertyChanged("discount_type", ModelEntityUpdated);
                }
                else if (_discount_type != value)
                {
                    _discount_type = (value ?? "P").ToUpper() ; RaisePropertyChanged("discount_type", ModelEntityUpdated);
                }
            }
        }
        public decimal? discount_amt
        {
            get
            {
                return _discount_amt;
            }

            set
            {
                if (_discount_amt != value)
                {
                    _discount_amt = value; RaisePropertyChanged("discount_amt", ModelEntityUpdated);
                }
            }
        }
        public string article_no
        {
            get
            {
                return _article_no;
            }

            set
            {
                if (_article_no != value)
                {
                    _article_no = value; RaisePropertyChanged("article_no");
                }
            }
        }
        public string ship_to_Party
        {
            get
            {
                return _ship_to_Party;
            }

            set
            {
                if (_ship_to_Party != value)
                {
                    _ship_to_Party = value; RaisePropertyChanged("ship_to_Party");
                }
            }
        }
        public int? ship_to_add
        {
            get
            {
                return _ship_to_add;
            }

            set
            {
                if (_ship_to_add != value)
                {
                    _ship_to_add = value; RaisePropertyChanged("ship_to_add");
                }
            }
        }
        public string buss_place
        {
            get
            {
                return _buss_place;
            }

            set
            {
                if (_buss_place != value)
                {
                    _buss_place = value; RaisePropertyChanged("buss_place");
                }
            }
        }

        public string hs_code
        {
            get
            {
                return _hs_code;
            }

            set
            {
                if (_hs_code != value)
                {
                    _hs_code = value; RaisePropertyChanged("hs_code");
                }
            }
        }
        private string _crm_doc_no;
        public string crm_doc_no
        {
            get { return _crm_doc_no; }
            set
            {
                if (_crm_doc_no != value)
                {
                    _crm_doc_no = value; RaisePropertyChanged("crm_doc_no");
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
        

        private string _price_qty_uom;
        public string price_qty_uom
        {
            get { return _price_qty_uom; }
            set
            {
                if (_price_qty_uom != value)
                {
                    _price_qty_uom = value; RaisePropertyChanged("price_qty_uom", ModelEntityUpdated);
                }
            }
        }

        private decimal? _price_qty;
        public decimal? price_qty
        {
            get
            {
                return _price_qty;
            }

            set
            {
                if (_price_qty != value)
                {
                    _price_qty = value; RaisePropertyChanged("price_qty", ModelEntityUpdated);
                }
            }
        }

        private decimal? _qty_price;
        public decimal? qty_price
        {
            get
            {
                return _qty_price;
            }

            set
            {
                if (_qty_price != value)
                {
                    _qty_price = value; RaisePropertyChanged("qty_price", ModelEntityUpdated);
                }
            }
        }
        private string _element_id;
        public string element_id
        {
            get
            {
                return _element_id;
            }

            set
            {
                if (_element_id != value)
                {
                    _element_id = value; RaisePropertyChanged("element_id", ModelEntityUpdated);
                }
            }
        }
        private int? _element_no;
        public int? element_no
        {
            get
            {
                return _element_no;
            }

            set
            {
                if (_element_no != value)
                {
                    _element_no = value; RaisePropertyChanged("element_no", ModelEntityUpdated);
                }
            }
        }
        private string _tl_code;
        public string tl_code
        {
            get
            {
                return _tl_code;
            }

            set
            {
                if (_tl_code != value)
                {
                    _tl_code = value; RaisePropertyChanged("tl_code", ModelEntityUpdated);
                }
            }
        }
        private int? _tl_counter;
        public int? tl_counter
        {
            get
            {
                return _tl_counter;
            }

            set
            {
                if (_tl_counter != value)
                {
                    _tl_counter = value; RaisePropertyChanged("tl_counter", ModelEntityUpdated);
                }
            }
        }
        private int? _bom_counter;
        public int? bom_counter
        {
            get
            {
                return _bom_counter;
            }

            set
            {
                if (_bom_counter != value)
                {
                    _bom_counter = value; RaisePropertyChanged("bom_counter", ModelEntityUpdated);
                }
            }
        }
        public bool? ind_sku { get; set; }
        private string _weight_unit;
        public string weight_unit
        {
            get
            {
                return _weight_unit;
            }

            set
            {
                if (_weight_unit != value)
                {
                    _weight_unit = value; RaisePropertyChanged("weight_unit", ModelEntityUpdated);
                }
            }
        }

        private string _volume_unit;
        public string volume_unit
        {
            get
            {
                return _volume_unit;
            }

            set
            {
                if (_volume_unit != value)
                {
                    _volume_unit = value; RaisePropertyChanged("volume_unit", ModelEntityUpdated);
                }
            }
        }
        public string ProdNm { get; set; }
        public string ItemName { get; set; }
        public string PhNo { get; set; }
        public string FaxNo { get; set; }
        public string PhNos { get; set; }
        public string FaxNos { get; set; }
        public string item_category { get; set; }
        public string item_code_party { get; set; }
        public string item_name_party { get; set; }
    }
    public class SEL_T001_C : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int _id;
        private decimal? _tax_amount;
        private int? _account_id;
        private int _item_line_id;
        private int? _sequence;
        private string _doc_no;
        private string _manual;
        private decimal? _base_amount;
        private decimal? _amount;
        private decimal? _base;
        private int? _tax_code_id;
        private int? _account_analytic_id;
        private int? _base_code_id;
        private string _tax_name;
        private string _gl_code;
        private string _ItemCode;
        private string _sku;
        private int? _item_row_id;
        private string _fin_year;
        private string _posting_period;
        private bool? _active;
        private string _location_Id;
        private string _comp_code;
        private string _dc_ind { get; set; }
        private string _curr_code { get; set; }
        private Nullable<decimal> _exch_rate { get; set; }
        private string _local_curr { get; set; }
        private Nullable<decimal> _amt_local_curr { get; set; }
        private string _fix_per { get; set; }



        private string _symbol { get; set; }
        public string symbol
        {
            get
            {
                return _symbol;
            }

            set
            {
                if (_symbol != value)
                {
                    _symbol = value; RaisePropertyChanged("symbol");
                }
            }
        }

        public int id
        {
            get
            {
                return _id;
            }

            set
            {
                if (_id != value)
                {
                    _id = value; RaisePropertyChanged("id", ModelEntityUpdated);
                }
            }
        }

        public decimal? tax_amount
        {
            get
            {
                return _tax_amount;
            }

            set
            {
                if (_tax_amount != value)
                {
                    _tax_amount = value; RaisePropertyChanged("tax_amount", ModelEntityUpdated);
                }
            }
        }

        public int? account_id
        {
            get
            {
                return _account_id;
            }

            set
            {
                if (_account_id != value)
                {
                    _account_id = value; RaisePropertyChanged("account_id", ModelEntityUpdated);
                }
            }
        }
        public int item_line_id
        {
            get
            {
                return _item_line_id;
            }

            set
            {
                if (_item_line_id != value)
                {
                    _item_line_id = value; RaisePropertyChanged("item_line_id", ModelEntityUpdated);
                }
            }
        }
        public int? sequence
        {
            get
            {
                return _sequence;
            }

            set
            {
                if (_sequence != value)
                {
                    _sequence = value; RaisePropertyChanged("sequence", ModelEntityUpdated);
                }
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
                if (_doc_no != value)
                {
                    _doc_no = value; RaisePropertyChanged("doc_no", ModelEntityUpdated);
                }
            }
        }

        public string manual
        {
            get
            {
                return _manual;
            }

            set
            {
                if (_manual != value)
                {
                    _manual = value; RaisePropertyChanged("manual", ModelEntityUpdated);
                }
            }
        }

        public decimal? base_amount
        {
            get
            {
                return _base_amount;
            }

            set
            {
                if (_base_amount != value)
                {
                    _base_amount = value; RaisePropertyChanged("base_amount", ModelEntityUpdated);
                }
            }
        }

        public decimal? amount
        {
            get
            {
                return _amount;
            }

            set
            {
                if (_amount != value)
                {
                    _amount = value; RaisePropertyChanged("amount", ModelEntityUpdated);
                }
            }
        }

        public decimal? @base
        {
            get
            {
                return _base;
            }

            set
            {
                if (_base != value)
                {
                    _base = value; RaisePropertyChanged("@base", ModelEntityUpdated);
                }
            }
        }

        public int? tax_code_id
        {
            get
            {
                return _tax_code_id;
            }

            set
            {
                if (_tax_code_id != value)
                {
                    _tax_code_id = value; RaisePropertyChanged("tax_code_id", ModelEntityUpdated);
                }
            }
        }

        public int? account_analytic_id
        {
            get
            {
                return _account_analytic_id;
            }

            set
            {
                if (_account_analytic_id != value)
                {
                    _account_analytic_id = value; RaisePropertyChanged("account_analytic_id", ModelEntityUpdated);
                }
            }
        }

        public int? base_code_id
        {
            get
            {
                return _base_code_id;
            }

            set
            {
                if (_base_code_id != value)
                {
                    _base_code_id = value; RaisePropertyChanged("base_code_id", ModelEntityUpdated);
                }
            }
        }

        public string tax_name
        {
            get
            {
                return _tax_name;
            }

            set
            {
                if (_tax_name != value)
                {
                    _tax_name = value; RaisePropertyChanged("tax_name", ModelEntityUpdated);
                }
            }
        }

        public string gl_code
        {
            get
            {
                return _gl_code;
            }

            set
            {
                if (_gl_code != value)
                {
                    _gl_code = value; RaisePropertyChanged("gl_code", ModelEntityUpdated);
                }
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
                if (_ItemCode != value)
                {
                    _ItemCode = value; RaisePropertyChanged("ItemCode", ModelEntityUpdated);
                }
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
                if (_sku != value)
                {
                    _sku = value; RaisePropertyChanged("sku", ModelEntityUpdated);
                }
            }
        }

        public int? item_row_id
        {
            get
            {
                return _item_row_id;
            }

            set
            {
                if (_item_row_id != value)
                {
                    _item_row_id = value; RaisePropertyChanged("item_row_id", ModelEntityUpdated);
                }
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
                if (_fin_year != value)
                {
                    _fin_year = value; RaisePropertyChanged("fin_year", ModelEntityUpdated);
                }
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
                if (_posting_period != value)
                {
                    _posting_period = value; RaisePropertyChanged("posting_period", ModelEntityUpdated);
                }
            }
        }

        public bool? active
        {
            get
            {
                return _active;
            }

            set
            {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active", ModelEntityUpdated);
                }
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
                if (_location_Id != value)
                {
                    _location_Id = value; RaisePropertyChanged("location_Id", ModelEntityUpdated);
                }
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
                if (_comp_code != value)
                {
                    _comp_code = value; RaisePropertyChanged("comp_code", ModelEntityUpdated);
                }
            }
        }

        public string dc_ind
        {
            get { return _dc_ind; }
            set
            {
                if (_dc_ind != value)
                {
                    _dc_ind = value; RaisePropertyChanged("dc_ind");
                }
            }
        }

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

        public Nullable<decimal> exch_rate
        {
            get { return _exch_rate; }
            set
            {
                if (_exch_rate != value)
                {
                    _exch_rate = value; RaisePropertyChanged("exch_rate");
                }
            }
        }

        public string local_curr
        {
            get { return _local_curr; }
            set
            {
                if (_local_curr != value)
                {
                    _local_curr = value; RaisePropertyChanged("local_curr");
                }
            }
        }

        public Nullable<decimal> amt_local_curr
        {
            get { return _amt_local_curr; }
            set
            {
                if (_amt_local_curr != value)
                {
                    _amt_local_curr = value; RaisePropertyChanged("amt_local_curr");
                }
            }
        }

        public string fix_per
        {
            get { return _fix_per; }
            set
            {
                if (_fix_per != value)
                {
                    _fix_per = value; RaisePropertyChanged("fix_per");
                }
            }
        }
        //Added by Priya
        private string _con_type { get; set; }
        public string con_type
        {
            get
            {
                return _con_type;
            }

            set
            {
                if (_con_type != value)
                {
                    _con_type = value; RaisePropertyChanged("con_type");
                }
            }
        }
        private string _con_cat { get; set; }
        public string con_cat
        {
            get
            {
                return _con_cat;
            }

            set
            {
                if (_con_cat != value)
                {
                    _con_cat = value; RaisePropertyChanged("con_cat");
                }
            }
        }
        private int _acc_seq { get; set; }
        public int acc_seq
        {
            get
            {
                return _acc_seq;
            }

            set
            {
                if (_acc_seq != value)
                {
                    _acc_seq = value; RaisePropertyChanged("acc_seq");
                }
            }
        }
        private string _trns_key_code { get; set; }
        public string trns_key_code
        {
            get
            {
                return _trns_key_code;
            }

            set
            {
                if (_trns_key_code != value)
                {
                    _trns_key_code = value; RaisePropertyChanged("trns_key_code");
                }
            }
        }
        private string _acc_key1 { get; set; }
        public string acc_key1
        {
            get
            {
                return _acc_key1;
            }

            set
            {
                if (_acc_key1 != value)
                {
                    _acc_key1 = value; RaisePropertyChanged("acc_key1");
                }
            }
        }
        private string _record_no { get; set; }
        public string record_no
        {
            get
            {
                return _record_no;
            }

            set
            {
                if (_record_no != value)
                {
                    _record_no = value; RaisePropertyChanged("record_no");
                }
            }
        }
        private decimal? _price_uom;
        public decimal? price_uom
        {
            get
            {
                return _price_uom;
            }

            set
            {
                if (_price_uom != value)
                {
                    _price_uom = value; RaisePropertyChanged("price_uom");
                }
            }
        }
        private string _doc_uom_con { get; set; }
        public string doc_uom_con
        {
            get
            {
                return _doc_uom_con;
            }

            set
            {
                if (_doc_uom_con != value)
                {
                    _doc_uom_con = value; RaisePropertyChanged("doc_uom_con");
                }
            }
        }

        private decimal? _no_base_uom;
        public decimal? no_base_uom
        {
            get
            {
                return _no_base_uom;
            }

            set
            {
                if (_no_base_uom != value)
                {
                    _no_base_uom = value; RaisePropertyChanged("no_base_uom");
                }
            }
        }

        private decimal? _dno_base_uom;
        public decimal? dno_base_uom
        {
            get
            {
                return _dno_base_uom;
            }

            set
            {
                if (_dno_base_uom != value)
                {
                    _dno_base_uom = value; RaisePropertyChanged("dno_base_uom");
                }
            }
        }
        private string _ind_con_acc { get; set; }
        public string ind_con_acc
        {
            get
            {
                return _ind_con_acc;
            }

            set
            {
                if (_ind_con_acc != value)
                {
                    _ind_con_acc = value; RaisePropertyChanged("ind_con_acc");
                }
            }
        }
        private string _vendor_code { get; set; }
        public string vendor_code
        {
            get
            {
                return _vendor_code;
            }

            set
            {
                if (_vendor_code != value)
                {
                    _vendor_code = value; RaisePropertyChanged("vendor_code");
                }
            }
        }
        private string _customera_code { get; set; }
        public string customera_code
        {
            get
            {
                return _customera_code;
            }

            set
            {
                if (_customera_code != value)
                {
                    _customera_code = value; RaisePropertyChanged("customera_code");
                }
            }
        }
        private decimal? _rnd_diff;
        public decimal? rnd_diff
        {
            get
            {
                return _rnd_diff;
            }

            set
            {
                if (_rnd_diff != value)
                {
                    _rnd_diff = value; RaisePropertyChanged("rnd_diff");
                }
            }
        }
        private decimal? _con_value;
        public decimal? con_value
        {
            get
            {
                return _con_value;
            }

            set
            {
                if (_con_value != value)
                {
                    _con_value = value; RaisePropertyChanged("con_value");
                }
            }
        }
        private string _ind_max_base { get; set; }
        public string ind_max_base
        {
            get
            {
                return _ind_max_base;
            }

            set
            {
                if (_ind_max_base != value)
                {
                    _ind_max_base = value; RaisePropertyChanged("ind_max_base");
                }
            }
        }
        private string _ind_max_amt { get; set; }
        public string ind_max_amt
        {
            get
            {
                return _ind_max_amt;
            }

            set
            {
                if (_ind_max_amt != value)
                {
                    _ind_max_amt = value; RaisePropertyChanged("ind_max_amt");
                }
            }
        }
        private string _withholding_tax { get; set; }
        public string withholding_tax
        {
            get
            {
                return _withholding_tax;
            }

            set
            {
                if (_withholding_tax != value)
                {
                    _withholding_tax = value; RaisePropertyChanged("withholding_tax");
                }
            }
        }

        //Added by Priya on 2/5/2017
        private int? _stepno;
        public int? stepno
        {
            get
            {
                return _stepno;
            }

            set
            {
                if (_stepno != value)
                {
                    _stepno = value; RaisePropertyChanged("stepno");
                }
            }
        }
        private int? _scounter;
        public int? scounter
        {
            get
            {
                return _scounter;
            }

            set
            {
                if (_scounter != value)
                {
                    _scounter = value; RaisePropertyChanged("scounter");
                }
            }
        }
        private string _trns_scope { get; set; }
        public string trns_scope
        {
            get
            {
                return _trns_scope;
            }

            set
            {
                if (_trns_scope != value)
                {
                    _trns_scope = value; RaisePropertyChanged("trns_scope");
                }
            }
        }
        private decimal? _pricing_date { get; set; }
        public decimal? pricing_date
        {
            get
            {
                return _pricing_date;
            }

            set
            {
                if (_pricing_date != value)
                {
                    _pricing_date = value; RaisePropertyChanged("pricing_date");
                }
            }
        }
        private string _calc_type { get; set; }
        public string calc_type
        {
            get
            {
                return _calc_type;
            }

            set
            {
                if (_calc_type != value)
                {
                    _calc_type = value; RaisePropertyChanged("calc_type");
                }
            }
        }
        private decimal? _con_qty { get; set; }
        public decimal? con_qty
        {
            get
            {
                return _con_qty;
            }

            set
            {
                if (_con_qty != value)
                {
                    _con_qty = value; RaisePropertyChanged("con_qty");
                }
            }
        }
        private string _ind_stats { get; set; }
        public string ind_stats
        {
            get
            {
                return _ind_stats;
            }

            set
            {
                if (_ind_stats != value)
                {
                    _ind_stats = value; RaisePropertyChanged("ind_stats");
                }
            }
        }
        private string _scale_type { get; set; }
        public string scale_type
        {
            get
            {
                return _scale_type;
            }

            set
            {
                if (_scale_type != value)
                {
                    _scale_type = value; RaisePropertyChanged("scale_type");
                }
            }
        }
        private decimal? _scale_qty { get; set; }
        public decimal? scale_qty
        {
            get
            {
                return _scale_qty;
            }

            set
            {
                if (_scale_qty != value)
                {
                    _scale_qty = value; RaisePropertyChanged("scale_qty");
                }
            }
        }
        private string _ind_con_acr { get; set; }
        public string ind_con_acr
        {
            get
            {
                return _ind_con_acr;
            }

            set
            {
                if (_ind_con_acr != value)
                {
                    _ind_con_acr = value; RaisePropertyChanged("ind_con_acr");
                }
            }
        }
        private string _PartyId { get; set; }
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
                    _PartyId = value; RaisePropertyChanged("PartyId");
                }
            }
        }
        private string _tax_code { get; set; }
        public string tax_code
        {
            get
            {
                return _tax_code;
            }

            set
            {
                if (_tax_code != value)
                {
                    _tax_code = value; RaisePropertyChanged("tax_code");
                }
            }
        }
        private string _origin_ind { get; set; }
        public string origin_ind
        {
            get
            {
                return _origin_ind;
            }

            set
            {
                if (_origin_ind != value)
                {
                    _origin_ind = value; RaisePropertyChanged("origin_ind");
                }
            }
        }
        private string _con_control { get; set; }
        public string con_control
        {
            get
            {
                return _con_control;
            }

            set
            {
                if (_con_control != value)
                {
                    _con_control = value; RaisePropertyChanged("con_control");
                }
            }
        }
        private string _round_method { get; set; }
        public string round_method
        {
            get
            {
                return _round_method;
            }

            set
            {
                if (_round_method != value)
                {
                    _round_method = value; RaisePropertyChanged("round_method");
                }
            }
        }
        private string _grp_con { get; set; }
        public string grp_con
        {
            get
            {
                return _grp_con;
            }

            set
            {
                if (_grp_con != value)
                {
                    _grp_con = value; RaisePropertyChanged("grp_con");
                }
            }
        }
        private string _is_qty { get; set; }
        public string is_qty
        {
            get
            {
                return _is_qty;
            }

            set
            {
                if (_is_qty != value)
                {
                    _is_qty = value; RaisePropertyChanged("is_qty");
                }
            }
        }
        private string _con_record_no { get; set; }
        public string con_record_no
        {
            get
            {
                return _con_record_no;
            }

            set
            {
                if (_con_record_no != value)
                {
                    _con_record_no = value; RaisePropertyChanged("con_record_no");
                }
            }
        }
        private int? _con_seq;
        public int? con_seq
        {
            get
            {
                return _con_seq;
            }

            set
            {
                if (_con_seq != value)
                {
                    _con_seq = value; RaisePropertyChanged("con_seq");
                }
            }
        }
        private string _con_class { get; set; }
        public string con_class
        {
            get
            {
                return _con_class;
            }

            set
            {
                if (_con_class != value)
                {
                    _con_class = value; RaisePropertyChanged("con_class");
                }
            }
        }
        private int? _cc_head;
        public int? cc_head
        {
            get
            {
                return _cc_head;
            }

            set
            {
                if (_cc_head != value)
                {
                    _cc_head = value; RaisePropertyChanged("cc_head");
                }
            }
        }
        private decimal? _f_cbv { get; set; }
        public decimal? f_cbv
        {
            get
            {
                return _f_cbv;
            }

            set
            {
                if (_f_cbv != value)
                {
                    _f_cbv = value; RaisePropertyChanged("f_cbv");
                }
            }
        }
        private decimal? _f_cbp { get; set; }
        public decimal? f_cbp
        {
            get
            {
                return _f_cbp;
            }

            set
            {
                if (_f_cbp != value)
                {
                    _f_cbp = value; RaisePropertyChanged("f_cbp");
                }
            }
        }
        private string _ind_scale { get; set; }
        public string ind_scale
        {
            get
            {
                return _ind_scale;
            }

            set
            {
                if (_ind_scale != value)
                {
                    _ind_scale = value; RaisePropertyChanged("ind_scale");
                }
            }
        }
        private decimal? _scale_value { get; set; }
        public decimal? scale_value
        {
            get
            {
                return _scale_value;
            }

            set
            {
                if (_scale_value != value)
                {
                    _scale_value = value; RaisePropertyChanged("scale_value");
                }
            }
        }
        private string _scale_curr { get; set; }
        public string scale_curr
        {
            get
            {
                return _scale_curr;
            }

            set
            {
                if (_scale_curr != value)
                {
                    _scale_curr = value; RaisePropertyChanged("scale_curr");
                }
            }
        }
        private string _cost_center { get; set; }
        public string cost_center
        {
            get
            {
                return _cost_center;
            }

            set
            {
                if (_cost_center != value)
                {
                    _cost_center = value; RaisePropertyChanged("cost_center");
                }
            }
        }
        private string _profit_center { get; set; }
        public string profit_center
        {
            get
            {
                return _profit_center;
            }

            set
            {
                if (_profit_center != value)
                {
                    _profit_center = value; RaisePropertyChanged("profit_center");
                }
            }
        }
        private string _gross_indicator { get; set; }
        public string gross_indicator
        {
            get
            {
                return _gross_indicator;
            }

            set
            {
                if (_gross_indicator != value)
                {
                    _gross_indicator = value; RaisePropertyChanged("gross_indicator");
                }
            }
        }
        private string _analysis_code { get; set; }
        public string analysis_code
        {
            get
            {
                return _analysis_code;
            }

            set
            {
                if (_analysis_code != value)
                {
                    _analysis_code = value; RaisePropertyChanged("analysis_code");
                }
            }
        }
        private decimal? _rate_uom { get; set; }
        public decimal? rate_uom
        {
            get
            {
                return _rate_uom;
            }

            set
            {
                if (_rate_uom != value)
                {
                    _rate_uom = value; RaisePropertyChanged("rate_uom");
                }
            }
        }
        private string _pay_term { get; set; }
        public string pay_term
        {
            get
            {
                return _pay_term;
            }

            set
            {
                if (_pay_term != value)
                {
                    _pay_term = value; RaisePropertyChanged("pay_term");
                }
            }
        }
        private string _lic_type { get; set; }
        public string lic_type
        {
            get
            {
                return _lic_type;
            }

            set
            {
                if (_lic_type != value)
                {
                    _lic_type = value; RaisePropertyChanged("lic_type");
                }
            }
        }
        private string _lic_no { get; set; }
        public string lic_no
        {
            get
            {
                return _lic_no;
            }

            set
            {
                if (_lic_no != value)
                {
                    _lic_no = value; RaisePropertyChanged("lic_no");
                }
            }
        }
    }
    public class SEL_T001_E : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private string _tc_code;
        private int _id;
        private Nullable<int> _sequence_code;
        private string _doc_no;
        private string _doc_cat;
        private string _doc_type;
        private Nullable<System.DateTime> _doc_date;
        private string _comp_code;
        private string _location_Id;
        private string _PartyId;
        private string _sg_code;
        private string _so_code;
        private string _CatCode;
        private string _ItemTypeCd;
        private string _ItemCode;
        private Nullable<int> _sequence1;
        private Nullable<int> _sequence2;
        private Nullable<int> _sequence3;
        private string _short_text;
        private string _long_text;
        private string _unit_code;
        private Nullable<bool> _compulsory;
        private string _language_code;
        private string _con_type;
        private string _con_desc;
        private string _info_group;
        private string _info_desc;
        private string _info_sub_group;
        private string _info_sub_desc;
        private Nullable<bool> _active;
        private string _add_by;
        private System.DateTime _add_date;
        private string _editby;
        private Nullable<System.DateTime> _edit_date;

        public string tc_code
        {
            get
            {
                return _tc_code;
            }

            set
            {
                if (_tc_code != value)
                {
                    _tc_code = value; RaisePropertyChanged("tc_code", ModelEntityUpdated);
                }
            }
        }

        public int id
        {
            get
            {
                return _id;
            }

            set
            {
                if (_id != value)
                {
                    _id = value; RaisePropertyChanged("id", ModelEntityUpdated);
                }
            }
        }

        public int? sequence_code
        {
            get
            {
                return _sequence_code;
            }

            set
            {
                if (_sequence_code != value)
                {
                    _sequence_code = value; RaisePropertyChanged("sequence_code", ModelEntityUpdated);
                }
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
                if (_doc_no != value)
                {
                    _doc_no = value; RaisePropertyChanged("doc_no", ModelEntityUpdated);
                }
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
                if (_doc_cat != value)
                {
                    _doc_cat = value; RaisePropertyChanged("doc_cat", ModelEntityUpdated);
                }
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
                if (_doc_type != value)
                {
                    _doc_type = value; RaisePropertyChanged("doc_type", ModelEntityUpdated);
                }
            }
        }

        public DateTime? doc_date
        {
            get
            {
                return _doc_date;
            }

            set
            {
                if (_doc_date != value)
                {
                    _doc_date = value; RaisePropertyChanged("doc_date", ModelEntityUpdated);
                }
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
                if (_comp_code != value)
                {
                    _comp_code = value; RaisePropertyChanged("comp_code", ModelEntityUpdated);
                }
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
                if (_location_Id != value)
                {
                    _location_Id = value; RaisePropertyChanged("location_Id", ModelEntityUpdated);
                }
            }
        }
        
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

        public string sg_code
        {
            get
            {
                return _sg_code;
            }

            set
            {
                if (_sg_code != value)
                {
                    _sg_code = value; RaisePropertyChanged("sg_code", ModelEntityUpdated);
                }
            }
        }

        public string so_code
        {
            get
            {
                return _so_code;
            }

            set
            {
                if (_so_code != value)
                {
                    _so_code = value; RaisePropertyChanged("so_code", ModelEntityUpdated);
                }
            }
        }

        public string CatCode
        {
            get
            {
                return _CatCode;
            }

            set
            {
                if (_CatCode != value)
                {
                    _CatCode = value; RaisePropertyChanged("CatCode", ModelEntityUpdated);
                }
            }
        }

        public string ItemTypeCd
        {
            get
            {
                return _ItemTypeCd;
            }

            set
            {
                if (_ItemTypeCd != value)
                {
                    _ItemTypeCd = value; RaisePropertyChanged("ItemTypeCd", ModelEntityUpdated);
                }
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
                if (_ItemCode != value)
                {
                    _ItemCode = value; RaisePropertyChanged("ItemCode", ModelEntityUpdated);
                }
            }
        }

        public int? sequence1
        {
            get
            {
                return _sequence1;
            }

            set
            {
                if (_sequence1 != value)
                {
                    _sequence1 = value; RaisePropertyChanged("sequence1", ModelEntityUpdated);
                }
            }
        }

        public int? sequence2
        {
            get
            {
                return _sequence2;
            }

            set
            {
                if (_sequence2 != value)
                {
                    _sequence2 = value; RaisePropertyChanged("sequence2", ModelEntityUpdated);
                }
            }
        }

        public int? sequence3
        {
            get
            {
                return _sequence3;
            }

            set
            {
                if (_sequence3 != value)
                {
                    _sequence3 = value; RaisePropertyChanged("sequence3", ModelEntityUpdated);
                }
            }
        }

        public string short_text
        {
            get
            {
                return _short_text;
            }

            set
            {
                if (_short_text != value)
                {
                    _short_text = value; RaisePropertyChanged("short_text", ModelEntityUpdated);
                }
            }
        }

        public string long_text
        {
            get
            {
                return _long_text;
            }

            set
            {
                if (_long_text != value)
                {
                    _long_text = value; RaisePropertyChanged("long_text", ModelEntityUpdated);
                }
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
                if (_unit_code != value)
                {
                    _unit_code = value; RaisePropertyChanged("unit_code", ModelEntityUpdated);
                }
            }
        }

        public bool? compulsory
        {
            get
            {
                return _compulsory;
            }

            set
            {
                if (_compulsory != value)
                {
                    _compulsory = value; RaisePropertyChanged("compulsory", ModelEntityUpdated);
                }
            }
        }

        public string language_code
        {
            get
            {
                return _language_code;
            }

            set
            {
                if (_language_code != value)
                {
                    _language_code = value; RaisePropertyChanged("language_code", ModelEntityUpdated);
                }
            }
        }

        public string con_type
        {
            get
            {
                return _con_type;
            }

            set
            {
                if (_con_type != value)
                {
                    _con_type = value; RaisePropertyChanged("con_type", ModelEntityUpdated);
                }
            }
        }

        public string con_desc
        {
            get
            {
                return _con_desc;
            }

            set
            {
                if (_con_desc != value)
                {
                    _con_desc = value; RaisePropertyChanged("con_desc", ModelEntityUpdated);
                }
            }
        }

        public string info_group
        {
            get
            {
                return _info_group;
            }

            set
            {
                if (_info_group != value)
                {
                    _info_group = value; RaisePropertyChanged("info_group", ModelEntityUpdated);
                }
            }
        }

        public string info_desc
        {
            get
            {
                return _info_desc;
            }

            set
            {
                if (_info_desc != value)
                {
                    _info_desc = value; RaisePropertyChanged("info_desc", ModelEntityUpdated);
                }
            }
        }

        public string info_sub_group
        {
            get
            {
                return _info_sub_group;
            }

            set
            {
                if (_info_sub_group != value)
                {
                    _info_sub_group = value; RaisePropertyChanged("info_sub_group", ModelEntityUpdated);
                }
            }
        }

        public string info_sub_desc
        {
            get
            {
                return _info_sub_desc;
            }

            set
            {
                if (_info_sub_desc != value)
                {
                    _info_sub_desc = value; RaisePropertyChanged("info_sub_desc", ModelEntityUpdated);
                }
            }
        }

        public bool? active
        {
            get
            {
                return _active;
            }

            set
            {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active", ModelEntityUpdated);
                }

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
                if (_add_by != value)
                {
                    _add_by = value; RaisePropertyChanged("add_by", ModelEntityUpdated);
                }
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
                if (_add_date != value)
                {
                    _add_date = value; RaisePropertyChanged("add_date", ModelEntityUpdated);
                }
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
                if (_editby != value)
                {
                    _editby = value; RaisePropertyChanged("editby", ModelEntityUpdated);
                }
            }
        }

        public DateTime? edit_date
        {
            get
            {
                return _edit_date;
            }

            set
            {
                if (_edit_date != value)
                {
                    _edit_date = value; RaisePropertyChanged("edit_date", ModelEntityUpdated);
                }
            }
        }


    }
    public class MultipleContext_SEL_T001
    {
        public List<ADM_M0013> STATUS_LIST { get; set; }
        public List<STD_DOC_TYPE> DOC_TYPE_LIST { get; set; }
        public List<ACC_M003_P> AccountList { get; set; }
        public List<ADM_M012_P> CountryMaster { get; set; }
        public List<ADM_M013_P> StateMaster { get; set; }
        public List<SYS_M002> DocumentTypes { get; set; }
        public List<SEL_T001_Flip> DocumentDataFlipGrid { get; set; }
        public List<ADM_M028_P> PartyMaster { get; set; }
        public List<ADM_M028_P> Transporters { get; set; }
        public List<ADM_M028_P> ServiceProviders { get; set; }
        public List<ADM_M028_P> Supplier { get; set; }
        public List<ADM_M038_B_P> UOM { get; set; }
        public List<ADM_M024_P> Sellers { get; set; }
        public List<ACC_M005_P> Journals { get; set; }
        public List<ACC_M013_P> TaxList { get; set; }
        public List<ACC_M003_P> GLCodes { get; set; }
        public List<ACC_M007_P> PayTerms { get; set; }
        public List<ADM_M037_P> Currencys { get; set; }
        public List<ADM_M001_A_P> SalesOrg { get; set; }
        public List<ADM_M001_H_P> SalesGroup { get; set; }
        public List<ADM_M001_D_P> SalesDiv { get; set; }
        public List<SYS_M003_P> ItemLineCategory { get; set; }
        public List<ACC_M019_P> Cost_Centers { get; set; }
        public List<ACC_M004_P> Banks { get; set; }
        public List<ZADM_M002_P> BallTypes { get; set; }
        public List<ZADM_M007_P> ILDs { get; set; }
        public List<ZADM_M004_P> WireTypes { get; set; }
        public List<ZADM_M001_P> BallDias { get; set; }
        public List<ZADM_M006_P> Inks { get; set; }
        public List<SEL_T001> MasterEntity { get; set; }//Sales_Order
        public ObservableCollection<SEL_T001_A> ItemsEntity { get; set; }//Sales_Order_Items Details 
        public ObservableCollection<ACC_T006_B> TaxEntity { get; set; }//Tax_Details
        public List<SEL_T002> ScheduleMasterEntity { get; set; }
        public ObservableCollection<SEL_T002_A> ScheduleDetailsEntity { get; set; }
        public List<ADM_M028_C_P> PartysContactInfo { get; set; }
        public List<ADM_M028_D> PartysSoldToAddresses { get; set; }
        public List<ADM_M028_D> PartysShipToAddresses { get; set; }
        public List<SEL_T001_P_RefDoc> Sales_Order_Reference { get; set; }
        public List<SEL_T001_P_SO_ItemsList> ItemListPopup { get; set; }
        public List<CRM_M001_P> TermsConditionCollection { get; set; }
        public List<ADM_M044_P> Incoterms { get; set; }
        public List<ADM_M041_P> LicenseAdvance { get; set; }
        public List<ADM_M041_P> LicenseEPCG { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<NotificationData> NotificationData { get; set; }
        public ObservableCollection<SEL_T001_E> TermsAndCondition { get; set; }
        public List<ADM_M028_C_P> RefPartyContactInfo { get; set; }
        public List<ADM_M045_P> GradeCollection { get; set; }
        public List<ADM_M031_P> ParameterDetails { get; set; }
        public List<ADM_M030_P> ParameterValueDetails { get; set; }
        public List<ADM_M038_C> UnitConversion { get; set; }
        public List<ZADM_M009_P> ModelNo { get; set; }
        public List<ZADM_M010> FinishGoodMaster { get; set; }
        public List<ADM_M030_P> ParamValueList { get; set; }//Flute Master
        public List<ADM_M031_P> ParameterList { get; set; } //Parameter Master
        public List<ZADM_M017_P> PackingList { get; set; }
        public List<SEL_T001_A> SalesData { get; set; }
        public List<ACC_M003_O_P> ConditionTypeList { get; set; }
        public List<GetItemDetailsEntity> UnitPriceList { get; set; }
        public List<GetItemDetailsEntity> QFRList { get; set; }
        public List<GetItemDetailsEntity> DispatchList { get; set; }
        public List<GetItemDetailsEntity> ProjectedDispList { get; set; }
        public List<ADM_M041_P> LicenceList { get; set; }
        public ObservableCollection<ACC_T006_D> LicenceEntity { get; set; }
        public List<ADM_M003_C_P> BussinessPlaceList { get; set; }
        public List<ADM_M032_P> Make { get; set; }
        public List<SYS_M026> TransportMode { get; set; }
        public List<SYS_M037> Trade_Types { get; set; }
        public List<ACC_M004_P> hbList { get; set; }
        public List<ADM_M002_B> ScopeList { get; set; }
    }
    public class SEL_T001_Flip
    {
        public string sono { get; set; }
        public DateTime? sodate { get; set; }
        public string cust_ref { get; set; }
        public DateTime? cust_ref_date { get; set; }
        public string doc_type { get; set; }
        public string dcat_name { get; set; }
        public string doc_cat { get; set; }
        public string doc_type_user { get; set; }
        public string doc_desc_user { get; set; }
        public string ref_doc_no { get; set; }
        public DateTime? valid_to_date { get; set; }
        public string Seller { get; set; }
        public string buyer_name { get; set; }
        public string so_code { get; set; }
        public string sales_org { get; set; }
        public string party_name { get; set; }
        public string PartyId { get; set; }
        public string ship_to_party { get; set; }
        public string t_status { get; set; }
        public string t_display { get; set; }
        public string location_id { get; set; }
        public string comp_code { get; set; }
        public string roundup_total { get; set; }
        public string sg_code { get; set; }
        public string sg_name { get; set; }
        public string add_by { get; set; }
        public string reference { get; set; }
        public string remark1 { get; set; }
    }
    public class SEL_T001_P_RefDoc : ObjectBase //Sales Order Reference Documents as per Paarty
    {
        private bool _Select;
        public bool Select
        {
            get { return _Select; }
            set
            {
                _Select = value;
                RaisePropertyChanged("Select");
            }
        }
        public string sono { get; set; }
        public DateTime sodate { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string cust_ref { get; set; }
        public Nullable<System.DateTime> cust_ref_date { get; set; }
        public string quotation_no { get; set; }
        public string PartyId { get; set; }
        public string party_name { get; set; }
        public string ItemCode { get; set; }
        public string para3 { get; set; }
        public string so_code { get; set; }
        public string curr_code { get; set; }
        public string country_nm_s { get; set; }
        public string del_address { get; set; }
        public string bill_address_id { get; set; }
        public string p_term_code { get; set; }
        public string incoterms { get; set; }
        public string color_code { get; set; }
        public string t_status { get; set; }
        public string t_display { get; set; }

    }
    public class SEL_T001_P_SO_ItemsList//Item List for Popup Sales Documents.
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string CatCode { get; set; }
        public string SubCatCode { get; set; }
        public string unit_code { get; set; }
        public Nullable<bool> StockUnt { get; set; }
        public string cstmr_itemcode { get; set; }
        public string cstmr_itemdescr { get; set; }
        public string CstmrItmCod { get; set; }
        public string CstmrItmDesc { get; set; }
        public Nullable<decimal> rate { get; set; }
        public string sku { get; set; }
        public string tax_id { get; set; }
        public string Catlog_UOM { get; set; }
        public string sku_desc { get; set; }
        public string item_cat_id { get; set; }
        public Nullable<decimal> Rate_Suggested { get; set; }
        public Nullable<decimal> Rate_Catlog { get; set; }
        public Nullable<decimal> MinQty { get; set; }
        public Nullable<decimal> MaxQty { get; set; }
        public Nullable<decimal> Reorder { get; set; }
        public Nullable<decimal> stock_total { get; set; }
        public Nullable<decimal> stock_reserve { get; set; }
        public Nullable<decimal> stock_unr { get; set; }
        public Nullable<decimal> stock_in_transit { get; set; }
        public string needledia { get; set; }
        public string needleangle { get; set; }
        public string needlelen { get; set; }
        public Nullable<int> model_id { get; set; }
        public string modelno { get; set; }
        public Nullable<int> wire_type_id { get; set; }
        public string wire_type { get; set; }
        public Nullable<int> ball_dia_id { get; set; }
        public Nullable<decimal> ball_dia { get; set; }
        public Nullable<int> ball_type_id { get; set; }
        public string ball_type { get; set; }
        public string tip_type { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public string tipshape { get; set; }
        public int wire_size_id { get; set; }
        public Nullable<decimal> wire_size { get; set; }
        public string total_len { get; set; }
        public Nullable<decimal> higher_limit { get; set; }
        public Nullable<decimal> lower_limit { get; set; }
        public string store_name { get; set; }
        public string plant_name { get; set; }
        public string comp_name { get; set; }
        public string weight_unit { get; set; }
        public string volume_unit { get; set; }
        
    }
    public class MultipleContext_SEL_T001SSE
    {
        public List<SEL_T001SSE_Flip> DocumentDataFlipGrid { get; set; }
        public List<SEL_T001> MasterEntity { get; set; }//Sales_Order
        public ObservableCollection<SEL_T001_A> ItemsEntity { get; set; }//Sales_Order_Items Details 
        public List<SEL_T002> ScheduleMasterEntity { get; set; }
        public ObservableCollection<SEL_T002_A> ScheduleDetailsEntity { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<NotificationData> NotificationData { get; set; }
        public List<SYS_M037> Trade_Types { get; set; }
    }
}




