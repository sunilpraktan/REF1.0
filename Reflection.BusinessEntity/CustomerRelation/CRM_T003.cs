using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Reflection.BusinessEntity.Admin;

namespace Reflection.BusinessEntity.CustomerRelation
{
    public class CRM_T003 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };


        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                if (_doc_no != value)
                {
                    _doc_no = value; RaisePropertyChanged("doc_no", ModelEntityUpdated);
                }
            }
        }
        private DateTime? _doc_date;
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

        private string _source;
        public string source
        {
            get
            {
                return _source;
            }

            set
            {
                if (_source != value)
                {
                    _source = value; RaisePropertyChanged("source", ModelEntityUpdated);
                }
            }
        }
        private int? _address_id;
        public int? address_id
        {
            get { return _address_id; }
            set
            {
                if (_address_id != value)
                {
                    _address_id = value; RaisePropertyChanged("address_id", ModelEntityUpdated);
                }
            }
        }
        private DateTime? _expect_date;
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
        private int? _buyer;
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

        private string _notes;
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
        private string _doc_type;
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

        private string _doc_cat;
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

        private string _fin_year;
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

        private string _posting_period;
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

        private string _curr_code { get; set; }
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

        private string _version;
        public string version
        {
            get
            {
                return _version;
            }

            set
            {
                if (_version!= value)
                {
                    _version = value; RaisePropertyChanged("version", ModelEntityUpdated);
                }
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
                if (_location_Id != value)
                {
                    _location_Id = value; RaisePropertyChanged("location_Id", ModelEntityUpdated);
                }
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
                if (_comp_code != value)
                {
                    _comp_code = value; RaisePropertyChanged("comp_code", ModelEntityUpdated);
                }
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
                if (_t_status != value)
                {
                    _t_status = value; RaisePropertyChanged("t_status", ModelEntityUpdated);
                }
            }
        }
        private decimal? _ex_rate;
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
        private string _para1;
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
        private string _para2;
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

        private string _para3;
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

        private string _revision_no;
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
        private string _revision_ind;
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
        private string _rev_ref_no;
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
        
        private string _reference_by;
        public string reference_by
        {
            get
            {
                return _reference_by;
            }

            set
            {
                if (_reference_by != value)
                {
                    _reference_by = value; RaisePropertyChanged("reference_by", ModelEntityUpdated);
                }
            }
        }
        private string _reference_details;
        public string reference_details
        {
            get
            {
                return _reference_details;
            }

            set
            {
                if (_reference_details != value)
                {
                    _reference_details = value; RaisePropertyChanged("reference_details", ModelEntityUpdated);
                }
            }
        }

        private string _t_status_remark;
        public string t_status_remark
        {
            get
            {
                return _t_status_remark;
            }

            set
            {
                if (_t_status_remark != value)
                {
                    _t_status_remark = value; RaisePropertyChanged("t_status_remark", ModelEntityUpdated);
                }
            }
        }
        
        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                if (_lang_key != value)
                {
                    _lang_key = value; RaisePropertyChanged("lang_key", ModelEntityUpdated);
                }
            }
        }
        private string _doc_history_no;
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
        private bool _active;
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
        private System.DateTime _add_date;
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
        private string _add_by;
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
        private DateTime? _edit_date;
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
        private string _editby;
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

        private string _group_key;
        public string group_key
        {
            get
            {
                return _group_key;
            }

            set
            {
                if (_group_key != value)
                {
                    _group_key = value; RaisePropertyChanged("group_key");
                }
            }
        }
        private string _priority;
        public string priority
        {
            get
            {
                return _priority;
            }

            set
            {
                if (_priority != value)
                {
                    _priority = value; RaisePropertyChanged("priority");
                }
            }
        }
        private string _doc_score;
        public string doc_score
        {
            get { return _doc_score; }
            set
            {
                if (_doc_score != value)
                {
                    _doc_score = value; RaisePropertyChanged("doc_score");
                }
            }
        }
        private string _doc_rec;
        public string doc_rec
        {
            get
            {
                return _doc_rec;
            }

            set
            {
                if (_doc_rec != value)
                {
                    _doc_rec = value; RaisePropertyChanged("doc_rec");
                }
            }
        }
        private string _camp_no;
        public string camp_no
        {
            get
            {
                return _camp_no;
            }

            set
            {
                if (_camp_no!= value)
                {
                    _camp_no = value; RaisePropertyChanged("camp_no");
                }
            }
        }
        private string _project_no;
        public string project_no
        {
            get
            {
                return _project_no;
            }

            set
            {
                if (_project_no != value)
                {
                    _project_no = value; RaisePropertyChanged("project_no");
                }
            }
        }
        private string _doc_title;
        public string doc_title
        {
            get
            {
                return _doc_title;
            }

            set
            {
                if (_doc_title != value)
                {
                    _doc_title = value; RaisePropertyChanged("doc_title");
                }
            }
        }
        private string _origin_code;
        public string origin_code
        {
            get
            {
                return _origin_code;
            }

            set
            {
                if (_origin_code != value)
                {
                    _origin_code = value; RaisePropertyChanged("origin_code");
                }
            }
        }
        private string _ind_privacy;
        public string ind_privacy
        {
            get
            {
                return _ind_privacy;
            }

            set
            {
                if (_ind_privacy != value)
                {
                    _ind_privacy = value; RaisePropertyChanged("ind_privacy");
                }
            }
        }
        private Nullable<int> _annual_revenue;
        public Nullable<int> annual_revenue
        {
            get { return _annual_revenue; }
            set
            {
                if (_annual_revenue != value)
                {
                    _annual_revenue = value; RaisePropertyChanged("annual_revenue");
                }
            }
        }
        private Nullable<int> _emp_strength;
        public Nullable<int> emp_strength
        {
            get { return _emp_strength; }
            set
            {
                if (_emp_strength != value)
                {
                    _emp_strength = value; RaisePropertyChanged("emp_strength");
                }
            }
        }
        private decimal? _exp_sales_opp;
        public decimal? exp_sales_opp
        {
            get { return _exp_sales_opp; }
            set
            {
                if (_exp_sales_opp != value)
                {
                    _exp_sales_opp = value; RaisePropertyChanged("exp_sales_opp");
                }
            }
        }

        private string _seg_code;
        public string seg_code
        {
            get
            {
                return _seg_code;
            }

            set
            {
                if (_seg_code != value)
                {
                    _seg_code = value; RaisePropertyChanged("seg_code");
                }
            }
        }
        private DateTime? _exp_closing_date;
        public DateTime? exp_closing_date
        {
            get
            {
                return _exp_closing_date;
            }

            set
            {
                if (_exp_closing_date != value)
                {
                    _exp_closing_date = value; RaisePropertyChanged("exp_closing_date");
                }
            }
        }

        private decimal? _success_chance;
        public decimal? success_chance
        {
            get { return _success_chance; }
            set
            {
                if (_success_chance != value)
                {
                    _success_chance = value; RaisePropertyChanged("success_chance");
                }
            }
        }
        private string _ind_forecast;
        public string ind_forecast
        {
            get
            {
                return _ind_forecast;
            }

            set
            {
                if (_ind_forecast != value)
                {
                    _ind_forecast = value; RaisePropertyChanged("ind_forecast");
                }
            }
        }
        private string _doc_qulif_Level;
        public string doc_qulif_Level
        {
            get
            {
                return _doc_qulif_Level;
            }

            set
            {
                if (_doc_qulif_Level != value)
                {
                    _doc_qulif_Level = value; RaisePropertyChanged("doc_qulif_Level");
                }
            }
        }
        private string _forcast_no;
        public string forcast_no
        {
            get
            {
                return _forcast_no;
            }

            set
            {
                if (_forcast_no != value)
                {
                    _forcast_no = value; RaisePropertyChanged("forcast_no");
                }
            }
        }
        private string _planning_no;
        public string planning_no
        {
            get
            {
                return _planning_no;
            }

            set
            {
                if (_planning_no != value)
                {
                    _planning_no = value; RaisePropertyChanged("planning_no");
                }
            }
        }
        private string _ind_io;
        public string ind_io
        {
            get
            {
                return _ind_io;
            }

            set
            {
                if (_ind_io != value)
                {
                    _ind_io = value; RaisePropertyChanged("ind_io");
                }
            }
        }
        private string _survey_no;
        public string survey_no
        {
            get
            {
                return _survey_no;
            }

            set
            {
                if (_survey_no != value)
                {
                    _survey_no = value; RaisePropertyChanged("survey_no");
                }
            }
        }
        private string _cgroup_code;
        public string cgroup_code
        {
            get
            {
                return _cgroup_code;
            }

            set
            {
                if (_cgroup_code != value)
                {
                    _cgroup_code = value; RaisePropertyChanged("cgroup_code");
                }
            }
        }

        private string _pref_contact;
        public string pref_contact
        {
            get
            {
                return _pref_contact;
            }

            set
            {
                if (_pref_contact != value)
                {
                    _pref_contact = value; RaisePropertyChanged("pref_contact");
                }
            }
        }
        private string _reason_code;
        public string reason_code
        {
            get
            {
                return _reason_code;
            }

            set
            {
                if (_reason_code != value)
                {
                    _reason_code = value; RaisePropertyChanged("reason_code");
                }
            }
        }
        private string _doc_stage;
        public string doc_stage
        {
            get
            {
                return _doc_stage;
            }

            set
            {
                if (_doc_stage != value)
                {
                    _doc_stage = value; RaisePropertyChanged("doc_stage");
                }
            }
        }
        private string _color_code;
        public string color_code
        {
            get
            {
                return _color_code;
            }

            set
            {
                if (_color_code != value)
                {
                    _color_code = value; RaisePropertyChanged("color_code");
                }
            }
        }
        private string _rank_star;
        public string rank_star
        {
            get
            {
                return _rank_star;
            }

            set
            {
                if (_rank_star != value)
                {
                    _rank_star = value; RaisePropertyChanged("rank_star");
                }
            }
        }
        private decimal? _probability;
        public decimal? probability
        {
            get { return _probability; }
            set
            {
                if (_probability != value)
                {
                    _probability = value; RaisePropertyChanged("probability");
                }
            }
        }

        private int _user_score;
        public int user_score
        {
            get
            {
                return _user_score;
            }

            set
            {
                if (_user_score != value)
                {
                    _user_score = value; RaisePropertyChanged("user_score");
                }
            }
        }
        private string _doc_status;
        public string doc_status
        {
            get
            {
                return _doc_status;
            }

            set
            {
                if (_doc_status != value)
                {
                    _doc_status = value; RaisePropertyChanged("doc_status");
                }
            }
        }
        private string _doc_ref;
        public string doc_ref
        {
            get
            {
                return _doc_ref;
            }

            set
            {
                if (_doc_ref != value)
                {
                    _doc_ref = value; RaisePropertyChanged("doc_ref");
                }
            }
        }
        private DateTime? _ref_date;
        public DateTime? ref_date
        {
            get
            {
                return _ref_date;
            }

            set
            {
                if (_ref_date != value)
                {
                    _ref_date = value; RaisePropertyChanged("ref_date");
                }
            }
        }
        private string _ref_party;
        public string ref_party
        {
            get
            {
                return _ref_party;
            }

            set
            {
                if (_ref_party != value)
                {
                    _ref_party = value; RaisePropertyChanged("ref_party");
                }
            }
        }
        private string _ref_contact_person;
        public string ref_contact_person
        {
            get
            {
                return _ref_contact_person;
            }

            set
            {
                if (_ref_contact_person != value)
                {
                    _ref_contact_person = value; RaisePropertyChanged("ref_contact_person");
                }
            }
        }
        //Scaler

        private string _PartyNm;
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
        private string _seller_name;
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

        private string _cost_center_Desc;
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
        private string _PersonEmailId;
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
        private string _PartyEmailId;
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

        private string _dcat_name;
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
                    _symbol = value; RaisePropertyChanged("symbol", ModelEntityUpdated);
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
                    _doc_desc = value; RaisePropertyChanged("doc_desc", ModelEntityUpdated);
                }
            }
        }

        private string _LoctnNm;
        public string LoctnNm
        {
            get { return _LoctnNm; }
            set
            {
                if (_LoctnNm != value)
                {
                    _LoctnNm = value; RaisePropertyChanged("LoctnNm", ModelEntityUpdated);
                }
            }
        }

        private string _doc_type_user;
        public string doc_type_user
        {
            get { return _doc_type_user; }
            set
            {
                if (_doc_type_user != value)
                {
                    _doc_type_user = value; RaisePropertyChanged("doc_type_user", ModelEntityUpdated);
                }
            }
        }

        private string _address_name;
        public string address_name
        {
            get { return _address_name; }
            set
            {
                if (_address_name != value)
                {
                    _address_name = value; RaisePropertyChanged("address_name", ModelEntityUpdated);
                }
            }
        }

        private string _buyer_name;
        public string buyer_name
        {
            get { return _buyer_name; }
            set
            {
                if (_buyer_name != value)
                {
                    _buyer_name = value; RaisePropertyChanged("buyer_name", ModelEntityUpdated);
                }
            }
        }
        private string _ref_contact_name;
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
        private string _origin_desc;
        public string origin_desc
        {
            get { return _origin_desc; }
            set
            {
                if (_origin_desc != value)
                {
                    _origin_desc = value; RaisePropertyChanged("origin_desc", ModelEntityUpdated);
                }
            }
        }
        private string _ref_party_name;
        public string ref_party_name
        {
            get { return _ref_party_name; }
            set
            {
                if (_ref_party_name != value)
                {
                    _ref_party_name = value; RaisePropertyChanged("ref_party_name", ModelEntityUpdated);
                }
            }
        }
        private string _pref_contact_name;
        public string pref_contact_name
        {
            get { return _pref_contact_name; }
            set
            {
                if (_pref_contact_name != value)
                {
                    _pref_contact_name = value; RaisePropertyChanged("pref_contact_name", ModelEntityUpdated);
                }
            }
        }

        private string _seg_name;
        public string seg_name
        {
            get
            {
                return _seg_name;
            }

            set
            {
                if (_seg_name != value)
                {
                    _seg_name = value; RaisePropertyChanged("seg_name");
                }
            }
        }
        //Scaler
        public string sales_person_name { get; set; }
        public string so_name { get; set; }
        public string sg_name { get; set; }
        public string party_name { get; set; }
        public string party_location { get; set; }
        private string _doc_status_name;
        public string doc_status_name
        {
            get
            {
                return _doc_status_name;
            }

            set
            {
                if (_doc_status_name != value)
                {
                    _doc_status_name = value; RaisePropertyChanged("doc_status_name", ModelEntityUpdated);
                }
            }
        }

        private string _doc_stage_name;
        public string doc_stage_name
        {
            get
            {
                return _doc_stage_name;
            }

            set
            {
                if (_doc_stage_name != value)
                {
                    _doc_stage_name = value; RaisePropertyChanged("doc_stage_name", ModelEntityUpdated);
                }
            }
        }
        private string _doc_rec_name;
        public string doc_rec_name
        {
            get
            {
                return _doc_rec_name;
            }

            set
            {
                if (_doc_rec_name != value)
                {
                    _doc_rec_name = value; RaisePropertyChanged("doc_rec_name", ModelEntityUpdated);
                }
            }
        }
        private string _doc_score_name;
        public string doc_score_name
        {
            get
            {
                return _doc_score_name;
            }

            set
            {
                if (_doc_score_name != value)
                {
                    _doc_score_name = value; RaisePropertyChanged("doc_score_name", ModelEntityUpdated);
                }
            }
        }
        private string _qulif_Level_name;
        public string qulif_Level_name
        {
            get
            {
                return _qulif_Level_name;
            }

            set
            {
                if (_qulif_Level_name != value)
                {
                    _qulif_Level_name = value; RaisePropertyChanged("qulif_Level_name", ModelEntityUpdated);
                }
            }
        }

        private string _priority_name;
        public string priority_name
        {
            get
            {
                return _priority_name;
            }

            set
            {
                if (_priority_name != value)
                {
                    _priority_name = value; RaisePropertyChanged("priority_name");
                }
            }
        }

        public string XmlDataDocument_CRM_T003_A { get; set; }
        public string XmlDataDocument_CRM_T003_B { get; set; }
        public string XmlDataDocument_CRM_T003_C { get; set; }
        public string XmlDataDocument_CRM_T003_D { get; set; }
        public string XmlDataDocument_ADM_M053 { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }
        public string XmlDataDocument_COM_T003 { get; set; }

    }
    public class CRM_T003_A : ObjectBase
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
                if (_id != value)
                {
                    _id = value; RaisePropertyChanged("id", ModelEntityUpdated);
                }
            }
        }

        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                if (_doc_no != value)
                {
                    _doc_no = value; RaisePropertyChanged("doc_no", ModelEntityUpdated);
                }
            }
        }

        private int _line_id;
        public int line_id
        {
            get { return _line_id; }
            set
            {
                if (_line_id!=value)
                {
                    _line_id = value; RaisePropertyChanged("line_id", ModelEntityUpdated);
                }
            }
        }

        private string _ItemCode;
        public string ItemCode
        {
            get { return _ItemCode; }
            set
            {
                if (_ItemCode != value)
                {
                    _ItemCode = value; RaisePropertyChanged("ItemCode", ModelEntityUpdated);
                }
            }
        }

        private string _sku;
        public string sku
        {
            get { return _sku; }
            set
            {
                if (_sku != value)
                {
                    _sku = value; RaisePropertyChanged("sku", ModelEntityUpdated);
                }
            }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set
            {
                if (_Description != value)
                {
                    _Description = value; RaisePropertyChanged("Description", ModelEntityUpdated);
                }
            }
        }

        private decimal? _quantity;
        public decimal? quantity
        {
            get { return _quantity; }
            set
            {
                if (_quantity != value)
                {
                    _quantity = value; RaisePropertyChanged("quantity", ModelEntityUpdated);
                }
            }
        }

        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set
            {
                if (_unit_code != value)
                {
                    _unit_code = value; RaisePropertyChanged("unit_code", ModelEntityUpdated);
                }
            }
        }

        private decimal? _unit_price;
        public decimal? unit_price
        {
            get { return _unit_price; }
            set
            {
                if (_unit_price != value)
                {
                    _unit_price = value; RaisePropertyChanged("unit_price", ModelEntityUpdated);
                }
            }
        }

        private DateTime? _date_planned;
        public DateTime? date_planned
        {
            get { return _date_planned; }
            set
            {
                if (_date_planned!= value)
                {
                    _date_planned = value; RaisePropertyChanged("date_planned", ModelEntityUpdated);
                }
            }
        }

        private string _para1;
        public string para1
        {
            get { return _para1; }
            set
            {
                if (_para1 != value)
                {
                    _para1 = value; RaisePropertyChanged("para1", ModelEntityUpdated);
                }
            }
        }

        private string _para2;
        public string para2
        {
            get { return _para2; }
            set
            {
                if (_para2 != value)
                {
                    _para2 = value; RaisePropertyChanged("para2", ModelEntityUpdated);
                }
            }
        }

        private string _para3;
        public string para3
        {
            get { return _para3; }
            set
            {
                if (_para3 != value)
                {
                    _para3 = value; RaisePropertyChanged("para3", ModelEntityUpdated);
                }
            }
        }

        private string _doc_history_no;
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

        private string _bom_no;
        public string bom_no
        {
            get { return _bom_no; }
            set
            {
                if (_bom_no != value)
                {
                    _bom_no = value; RaisePropertyChanged("bom_no", ModelEntityUpdated);
                }
            }
        }

        private decimal? _net_value;
        public decimal? net_value
        {
            get { return _net_value; }
            set
            {
                if (_net_value != value)
                {
                    _net_value = value; RaisePropertyChanged("net_value", ModelEntityUpdated);
                }
            }
        }

        private decimal? _discount;
        public decimal? discount
        {
            get { return _discount; }
            set
            {
                if (_discount != value)
                {
                    _discount = value; RaisePropertyChanged("discount", ModelEntityUpdated);
                }
            }
        }

        private string _discount_type;
        public string discount_type
        {
            get { return _discount_type; }
            set
            {
                if (_discount_type != value)
                {
                    _discount_type = value; RaisePropertyChanged("discount_type", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _discount_amt;
        public Nullable<decimal> discount_amt
        {
            get { return _discount_amt; }
            set
            {
                if (_discount_amt != value)
                {
                    _discount_amt = value; RaisePropertyChanged("discount_amt", ModelEntityUpdated);
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
                if (_fin_year != value)
                {
                    _fin_year = value; RaisePropertyChanged("fin_year", ModelEntityUpdated);
                }
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
                if (_posting_period != value)
                {
                    _posting_period = value; RaisePropertyChanged("posting_period", ModelEntityUpdated);
                }
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
                if (_location_Id != value)
                {
                    _location_Id = value; RaisePropertyChanged("location_Id", ModelEntityUpdated);
                }
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
                if (_comp_code != value)
                {
                    _comp_code = value; RaisePropertyChanged("comp_code", ModelEntityUpdated);
                }
            }
        }

        private bool _active;
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
        private string _t_status;
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
        private string _status_remark;
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
        private System.DateTime _add_date;
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
        private string _add_by;
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
        private DateTime? _edit_date;
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

        private string _editby;
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
                    _symbol = value; RaisePropertyChanged("symbol", ModelEntityUpdated);
                }
            }
        }




    }
    public class CRM_T003_B : ObjectBase
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
                if (_id != value)
                {
                    _id = value; RaisePropertyChanged("id", ModelEntityUpdated);
                }
            }
        }

        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                if (_doc_no != value)
                {
                    _doc_no = value; RaisePropertyChanged("doc_no", ModelEntityUpdated);
                }
            }
        }
        private DateTime? _distb_date;
        public DateTime? distb_date
        {
            get
            {
                return _distb_date;
            }

            set
            {
                if (_distb_date != value)
                {
                    _distb_date = value; RaisePropertyChanged("distb_date", ModelEntityUpdated);
                }
            }
        }
        private DateTime? _effec_date;
        public DateTime? effec_date
        {
            get
            {
                return _effec_date;
            }

            set
            {
                if (_effec_date != value)
                {
                    _effec_date = value; RaisePropertyChanged("effec_date", ModelEntityUpdated);
                }
            }
        }
        private string _sales_person;
        public string sales_person
        {
            get { return _sales_person; }
            set
            {
                if (_sales_person != value)
                {
                    _sales_person = value; RaisePropertyChanged("sales_person", ModelEntityUpdated);
                }
            }
        }
        private string _so_code;
        public string so_code
        {
            get { return _so_code; }
            set
            {
                if (_so_code != value)
                {
                    _so_code = value; RaisePropertyChanged("so_code", ModelEntityUpdated);
                }
            }
        }
        private string _sg_code;
        public string sg_code
        {
            get { return _sg_code; }
            set
            {
                if (_sg_code != value)
                {
                    _sg_code = value; RaisePropertyChanged("sg_code", ModelEntityUpdated);
                }
            }
        }
        private string _dc_code;
        public string dc_code
        {
            get { return _dc_code; }
            set
            {
                if (_dc_code != value)
                {
                    _dc_code = value; RaisePropertyChanged("dc_code", ModelEntityUpdated);
                }
            }
        }
        private string _soff_code;
        public string soff_code
        {
            get { return _soff_code; }
            set
            {
                if (_soff_code != value)
                {
                    _soff_code = value; RaisePropertyChanged("soff_code", ModelEntityUpdated);
                }
            }
        }
        private string _sales_area;
        public string sales_area
        {
            get { return _sales_area; }
            set
            {
                if (_sales_area != value)
                {
                    _sales_area = value; RaisePropertyChanged("sales_area", ModelEntityUpdated);
                }
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
                if (_t_status != value)
                {
                    _t_status = value; RaisePropertyChanged("t_status", ModelEntityUpdated);
                }
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
                if (_status_remark != value)
                {
                    _status_remark = value; RaisePropertyChanged("status_remark", ModelEntityUpdated);
                }
            }
        }

        private string _role_code;
        public string role_code
        {
            get
            {
                return _role_code;
            }

            set
            {
                if (_role_code != value)
                {
                    _role_code = value; RaisePropertyChanged("role_code", ModelEntityUpdated);
                }
            }
        }
        private Nullable<bool> _ind_primary;
        public Nullable<bool> ind_primary
        {
            get
            {
                return _ind_primary;
            }

            set
            {
                if (_ind_primary != value)
                {
                    _ind_primary = value; RaisePropertyChanged("ind_primary", ModelEntityUpdated);
                }
            }
        }
        private string _distbt_mcode;
        public string distbt_mcode
        {
            get
            {
                return _distbt_mcode;
            }

            set
            {
                if (_distbt_mcode != value)
                {
                    _distbt_mcode = value; RaisePropertyChanged("distbt_mcode", ModelEntityUpdated);
                }
            }
        }
        private bool _active;
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
        private System.DateTime _add_date;
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
        private string _add_by;
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
        private DateTime? _edit_date;
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
        private string _editby;
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

        //Scaler
        private string _sales_person_name;
        public string sales_person_name
        {
            get { return _sales_person_name; }
            set
            {
                if (_sales_person_name != value)
                {
                    _sales_person_name = value; RaisePropertyChanged("sales_person_name", ModelEntityUpdated);
                }
            }
        }
    }
    public class CRM_T003_C : ObjectBase
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
                if (_id != value)
                {
                    _id = value; RaisePropertyChanged("id", ModelEntityUpdated);
                }
            }
        }

        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                if (_doc_no != value)
                {
                    _doc_no = value; RaisePropertyChanged("doc_no", ModelEntityUpdated);
                }
            }
        }
        private string _party_id;
        public string party_id
        {
            get { return _party_id; }
            set
            {
                if (_party_id != value)
                {
                    _party_id = value; RaisePropertyChanged("party_id");
                }
            }
        }

        private string _ind_primary;
        public string ind_primary
        {
            get { return _ind_primary; }
            set
            {
                if (_ind_primary != value)
                {
                    _ind_primary = value; RaisePropertyChanged("ind_primary");
                }
            }
        }

        #region Default Fields
        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set
            {
                _active = value; RaisePropertyChanged("active");
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

        private string _edit_by;
        public string edit_by
        {
            get { return _edit_by; }
            set
            {
                _edit_by = value; RaisePropertyChanged("edit_by");
            }
        }

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value; RaisePropertyChanged("edit_date");
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
        

        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                _lang_key = value;
                RaisePropertyChanged("lang_key");
            }
        }
        
        //Scaler
        private string _party_name;
        public string party_name
        {
            get
            {
                return _party_name;
            }

            set
            {
                _party_name = value;
                RaisePropertyChanged("party_name");
            }
        }

        private Nullable<bool> _SelectParty;
        public Nullable<bool> SelectParty
        {
            get { return _SelectParty; }
            set
            {
                _SelectParty = value; RaisePropertyChanged("SelectParty");
            }
        }
        #endregion        
    }
    public class CRM_T003_D : ObjectBase
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
                if (_id != value)
                {
                    _id = value; RaisePropertyChanged("id", ModelEntityUpdated);
                }
            }
        }

        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                if (_doc_no != value)
                {
                    _doc_no = value; RaisePropertyChanged("doc_no", ModelEntityUpdated);
                }
            }
        }
        private string _cp_code;
        public string cp_code
        {
            get { return _cp_code; }
            set
            {
                if (_cp_code != value)
                {
                    _cp_code = value; RaisePropertyChanged("cp_code");
                }
            }
        }

        private string _ind_primary;
        public string ind_primary
        {
            get { return _ind_primary; }
            set
            {
                if (_ind_primary != value)
                {
                    _ind_primary = value; RaisePropertyChanged("ind_primary");
                }
            }
        }

        #region Default Fields
        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set
            {
                _active = value; RaisePropertyChanged("active");
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

        private string _edit_by;
        public string edit_by
        {
            get { return _edit_by; }
            set
            {
                _edit_by = value; RaisePropertyChanged("edit_by");
            }
        }

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value; RaisePropertyChanged("edit_date");
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

        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                _lang_key = value;
                RaisePropertyChanged("lang_key");
            }
        }
        
        //Scaler
        private string _cp_name;
        public string cp_name
        {
            get
            {
                return _cp_name;
            }

            set
            {
                _cp_name = value;
                RaisePropertyChanged("cp_name");
            }
        }

      
        #endregion        
    }
    public class CRM_M003_P_RefDoc //Sales Order Reference Documents as per Paarty
    {
        public string doc_no { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string PartyId { get; set; }
        public string party_name { get; set; }
        public string ItemCode { get; set; }

    }
    public class CRM_T003_Flip:ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private bool _Check;
        public bool Check
        {
            get
            {
                return _Check;
            }
            set
            {
                if (_Check != value)
                {
                    _Check = value;
                    RaisePropertyChanged("Check");
                }
            }
        }

        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                if (_doc_no != value)
                {
                    _doc_no = value; RaisePropertyChanged("doc_no", ModelEntityUpdated);
                }
            }
        }
        private DateTime? _doc_date;
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

        private string _source;
        public string source
        {
            get
            {
                return _source;
            }

            set
            {
                if (_source != value)
                {
                    _source = value; RaisePropertyChanged("source", ModelEntityUpdated);
                }
            }
        }
        private int? _address_id;
        public int? address_id
        {
            get { return _address_id; }
            set
            {
                if (_address_id != value)
                {
                    _address_id = value; RaisePropertyChanged("address_id", ModelEntityUpdated);
                }
            }
        }
        private DateTime? _expect_date;
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
        private int? _buyer;
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

        private string _notes;
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
        private string _doc_type;
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

        private string _doc_cat;
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

        private string _fin_year;
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

        private string _posting_period;
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

        private string _curr_code { get; set; }
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

        private string _version;
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
        private string _location_Id;
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

        private string _comp_code;
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

        private string _t_status;
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
        private decimal? _ex_rate;
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
        private string _para1;
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
        private string _para2;
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

        private string _para3;
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

        private string _revision_no;
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
        private string _revision_ind;
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
        private string _rev_ref_no;
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
        
        private string _reference_by;
        public string reference_by
        {
            get
            {
                return _reference_by;
            }

            set
            {
                if (_reference_by != value)
                {
                    _reference_by = value; RaisePropertyChanged("reference_by", ModelEntityUpdated);
                }
            }
        }
        private string _reference_details;
        public string reference_details
        {
            get
            {
                return _reference_details;
            }

            set
            {
                if (_reference_details != value)
                {
                    _reference_details = value; RaisePropertyChanged("reference_details", ModelEntityUpdated);
                }
            }
        }

        private string _t_status_remark;
        public string t_status_remark
        {
            get
            {
                return _t_status_remark;
            }

            set
            {
                if (_t_status_remark != value)
                {
                    _t_status_remark = value; RaisePropertyChanged("t_status_remark", ModelEntityUpdated);
                }
            }
        }

        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                if (_lang_key != value)
                {
                    _lang_key = value; RaisePropertyChanged("lang_key", ModelEntityUpdated);
                }
            }
        }
        private string _doc_history_no;
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
        private bool _active;
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
        private System.DateTime _add_date;
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
        private string _add_by;
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
        private DateTime? _edit_date;
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
        private string _editby;
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

        private string _group_key;
        public string group_key
        {
            get
            {
                return _group_key;
            }

            set
            {
                if (_group_key != value)
                {
                    _group_key = value; RaisePropertyChanged("group_key");
                }
            }
        }
        private string _priority;
        public string priority
        {
            get
            {
                return _priority;
            }

            set
            {
                if (_priority != value)
                {
                    _priority = value; RaisePropertyChanged("priority");
                }
            }
        }
        private string _doc_score;
        public string doc_score
        {
            get { return _doc_score; }
            set
            {
                if (_doc_score != value)
                {
                    _doc_score = value; RaisePropertyChanged("doc_score");
                }
            }
        }
        private string _doc_rec;
        public string doc_rec
        {
            get
            {
                return _doc_rec;
            }

            set
            {
                if (_doc_rec != value)
                {
                    _doc_rec = value; RaisePropertyChanged("doc_rec");
                }
            }
        }
        private string _camp_no;
        public string camp_no
        {
            get
            {
                return _camp_no;
            }

            set
            {
                if (_camp_no != value)
                {
                    _camp_no = value; RaisePropertyChanged("camp_no");
                }
            }
        }
        private string _project_no;
        public string project_no
        {
            get
            {
                return _project_no;
            }

            set
            {
                if (_project_no != value)
                {
                    _project_no = value; RaisePropertyChanged("project_no");
                }
            }
        }
        private string _doc_title;
        public string doc_title
        {
            get
            {
                return _doc_title;
            }

            set
            {
                if (_doc_title != value)
                {
                    _doc_title = value; RaisePropertyChanged("doc_title");
                }
            }
        }
        private string _origin_code;
        public string origin_code
        {
            get
            {
                return _origin_code;
            }

            set
            {
                if (_origin_code != value)
                {
                    _origin_code = value; RaisePropertyChanged("origin_code");
                }
            }
        }
        private string _ind_privacy;
        public string ind_privacy
        {
            get
            {
                return _ind_privacy;
            }

            set
            {
                if (_ind_privacy != value)
                {
                    _ind_privacy = value; RaisePropertyChanged("ind_privacy");
                }
            }
        }
        private Nullable<int> _annual_revenue;
        public Nullable<int> annual_revenue
        {
            get { return _annual_revenue; }
            set
            {
                if (_annual_revenue != value)
                {
                    _annual_revenue = value; RaisePropertyChanged("annual_revenue");
                }
            }
        }
        private Nullable<int> _emp_strength;
        public Nullable<int> emp_strength
        {
            get { return _emp_strength; }
            set
            {
                if (_emp_strength != value)
                {
                    _emp_strength = value; RaisePropertyChanged("emp_strength");
                }
            }
        }
        private decimal? _exp_sales_opp;
        public decimal? exp_sales_opp
        {
            get { return _exp_sales_opp; }
            set
            {
                if (_exp_sales_opp != value)
                {
                    _exp_sales_opp = value; RaisePropertyChanged("exp_sales_opp");
                }
            }
        }

        private string _seg_code;
        public string seg_code
        {
            get
            {
                return _seg_code;
            }

            set
            {
                if (_seg_code != value)
                {
                    _seg_code = value; RaisePropertyChanged("seg_code");
                }
            }
        }
        private DateTime? _exp_closing_date;
        public DateTime? exp_closing_date
        {
            get
            {
                return _exp_closing_date;
            }

            set
            {
                if (_exp_closing_date != value)
                {
                    _exp_closing_date = value; RaisePropertyChanged("exp_closing_date");
                }
            }
        }

        private decimal? _success_chance;
        public decimal? success_chance
        {
            get { return _success_chance; }
            set
            {
                if (_success_chance != value)
                {
                    _success_chance = value; RaisePropertyChanged("success_chance");
                }
            }
        }
        private string _ind_forecast;
        public string ind_forecast
        {
            get
            {
                return _ind_forecast;
            }

            set
            {
                if (_ind_forecast != value)
                {
                    _ind_forecast = value; RaisePropertyChanged("ind_forecast");
                }
            }
        }
        private string _doc_qulif_Level;
        public string doc_qulif_Level
        {
            get
            {
                return _doc_qulif_Level;
            }

            set
            {
                if (_doc_qulif_Level != value)
                {
                    _doc_qulif_Level = value; RaisePropertyChanged("doc_qulif_Level");
                }
            }
        }
        private string _forcast_no;
        public string forcast_no
        {
            get
            {
                return _forcast_no;
            }

            set
            {
                if (_forcast_no != value)
                {
                    _forcast_no = value; RaisePropertyChanged("forcast_no");
                }
            }
        }
        private string _planning_no;
        public string planning_no
        {
            get
            {
                return _planning_no;
            }

            set
            {
                if (_planning_no != value)
                {
                    _planning_no = value; RaisePropertyChanged("planning_no");
                }
            }
        }
        private string _ind_io;
        public string ind_io
        {
            get
            {
                return _ind_io;
            }

            set
            {
                if (_ind_io != value)
                {
                    _ind_io = value; RaisePropertyChanged("ind_io");
                }
            }
        }
        private string _survey_no;
        public string survey_no
        {
            get
            {
                return _survey_no;
            }

            set
            {
                if (_survey_no != value)
                {
                    _survey_no = value; RaisePropertyChanged("survey_no");
                }
            }
        }
        private string _cgroup_code;
        public string cgroup_code
        {
            get
            {
                return _cgroup_code;
            }

            set
            {
                if (_cgroup_code != value)
                {
                    _cgroup_code = value; RaisePropertyChanged("cgroup_code");
                }
            }
        }

        private string _pref_contact;
        public string pref_contact
        {
            get
            {
                return _pref_contact;
            }

            set
            {
                if (_pref_contact != value)
                {
                    _pref_contact = value; RaisePropertyChanged("pref_contact");
                }
            }
        }
        private string _reason_code;
        public string reason_code
        {
            get
            {
                return _reason_code;
            }

            set
            {
                if (_reason_code != value)
                {
                    _reason_code = value; RaisePropertyChanged("reason_code");
                }
            }
        }
        private string _doc_stage;
        public string doc_stage
        {
            get
            {
                return _doc_stage;
            }

            set
            {
                if (_doc_stage != value)
                {
                    _doc_stage = value; RaisePropertyChanged("doc_stage");
                }
            }
        }
        private string _color_code;
        public string color_code
        {
            get
            {
                return _color_code;
            }

            set
            {
                if (_color_code != value)
                {
                    _color_code = value; RaisePropertyChanged("color_code");
                }
            }
        }
        private string _rank_star;
        public string rank_star
        {
            get
            {
                return _rank_star;
            }

            set
            {
                if (_rank_star != value)
                {
                    _rank_star = value; RaisePropertyChanged("rank_star");
                }
            }
        }
        private decimal? _probability;
        public decimal? probability
        {
            get { return _probability; }
            set
            {
                if (_probability != value)
                {
                    _probability = value; RaisePropertyChanged("probability");
                }
            }
        }

        private int _user_score;
        public int user_score
        {
            get
            {
                return _user_score;
            }

            set
            {
                if (_user_score != value)
                {
                    _user_score = value; RaisePropertyChanged("user_score");
                }
            }
        }
        private string _doc_status;
        public string doc_status
        {
            get
            {
                return _doc_status;
            }

            set
            {
                if (_doc_status != value)
                {
                    _doc_status = value; RaisePropertyChanged("doc_status");
                }
            }
        }
        private string _doc_ref;
        public string doc_ref
        {
            get
            {
                return _doc_ref;
            }

            set
            {
                if (_doc_ref != value)
                {
                    _doc_ref = value; RaisePropertyChanged("doc_ref");
                }
            }
        }
        private DateTime? _ref_date;
        public DateTime? ref_date
        {
            get
            {
                return _ref_date;
            }

            set
            {
                if (_ref_date != value)
                {
                    _ref_date = value; RaisePropertyChanged("ref_date");
                }
            }
        }
        private string _ref_party;
        public string ref_party
        {
            get
            {
                return _ref_party;
            }

            set
            {
                if (_ref_party != value)
                {
                    _ref_party = value; RaisePropertyChanged("ref_party");
                }
            }
        }
        private string _ref_contact_person;
        public string ref_contact_person
        {
            get
            {
                return _ref_contact_person;
            }

            set
            {
                if (_ref_contact_person != value)
                {
                    _ref_contact_person = value; RaisePropertyChanged("ref_contact_person");
                }
            }
        }
        //Scaler

        private string _PartyNm;
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
        private string _seller_name;
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

        private string _cost_center_Desc;
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
        private string _PersonEmailId;
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
        private string _PartyEmailId;
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

        private string _dcat_name;
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
                    _symbol = value; RaisePropertyChanged("symbol", ModelEntityUpdated);
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
                    _doc_desc = value; RaisePropertyChanged("doc_desc", ModelEntityUpdated);
                }
            }
        }

        private string _LoctnNm;
        public string LoctnNm
        {
            get { return _LoctnNm; }
            set
            {
                if (_LoctnNm != value)
                {
                    _LoctnNm = value; RaisePropertyChanged("LoctnNm", ModelEntityUpdated);
                }
            }
        }

        private string _doc_type_user;
        public string doc_type_user
        {
            get { return _doc_type_user; }
            set
            {
                if (_doc_type_user != value)
                {
                    _doc_type_user = value; RaisePropertyChanged("doc_type_user", ModelEntityUpdated);
                }
            }
        }

        private string _address_name;
        public string address_name
        {
            get { return _address_name; }
            set
            {
                if (_address_name != value)
                {
                    _address_name = value; RaisePropertyChanged("address_name", ModelEntityUpdated);
                }
            }
        }

        private string _buyer_name;
        public string buyer_name
        {
            get { return _buyer_name; }
            set
            {
                if (_buyer_name != value)
                {
                    _buyer_name = value; RaisePropertyChanged("buyer_name", ModelEntityUpdated);
                }
            }
        }
        private string _ref_contact_name;
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
        private string _origin_desc;
        public string origin_desc
        {
            get { return _origin_desc; }
            set
            {
                if (_origin_desc != value)
                {
                    _origin_desc = value; RaisePropertyChanged("origin_desc", ModelEntityUpdated);
                }
            }
        }
        private string _ref_party_name;
        public string ref_party_name
        {
            get { return _ref_party_name; }
            set
            {
                if (_ref_party_name != value)
                {
                    _ref_party_name = value; RaisePropertyChanged("ref_party_name", ModelEntityUpdated);
                }
            }
        }
        private string _pref_contact_name;
        public string pref_contact_name
        {
            get { return _pref_contact_name; }
            set
            {
                if (_pref_contact_name != value)
                {
                    _pref_contact_name = value; RaisePropertyChanged("pref_contact_name", ModelEntityUpdated);
                }
            }
        }

        private string _seg_name;
        public string seg_name
        {
            get
            {
                return _seg_name;
            }

            set
            {
                if (_seg_name != value)
                {
                    _seg_name = value; RaisePropertyChanged("seg_name");
                }
            }
        }
        //Extra Fields
        private string _action_type;
        public string action_type
        {
            get
            {
                return _action_type;
            }

            set
            {
                if (_action_type != value)
                {
                    _action_type = value; RaisePropertyChanged("action_type", ModelEntityUpdated);
                }
            }
        }
        private string _activity_cat;
        public string activity_cat
        {
            get { return _activity_cat; }
            set
            {
                if (_activity_cat != value)
                {
                    _activity_cat = value; RaisePropertyChanged("activity_cat");
                }
            }
        }
        public string sales_person_name { get; set; }
        public string so_name { get; set; }
        public string sg_name { get; set; }
        public string party_name { get; set; }
        public string party_location { get; set; }
        public string location_name { get; set; }
     
        private string _doc_status_name;
        public string doc_status_name
        {
            get
            {
                return _doc_status_name;
            }

            set
            {
                if (_doc_status_name != value)
                {
                    _doc_status_name = value; RaisePropertyChanged("doc_status_name", ModelEntityUpdated);
                }
            }
        }
     
        private string _doc_stage_name;
        public string doc_stage_name
        {
            get
            {
                return _doc_stage_name;
            }

            set
            {
                if (_doc_stage_name != value)
                {
                    _doc_stage_name = value; RaisePropertyChanged("doc_stage_name", ModelEntityUpdated);
                }
            }
        }
        private string _doc_rec_name;
        public string doc_rec_name
        {
            get
            {
                return _doc_rec_name;
            }

            set
            {
                if (_doc_rec_name != value)
                {
                    _doc_rec_name = value; RaisePropertyChanged("doc_rec_name", ModelEntityUpdated);
                }
            }
        }
        private string _doc_score_name;
        public string doc_score_name
        {
            get
            {
                return _doc_score_name;
            }

            set
            {
                if (_doc_score_name != value)
                {
                    _doc_score_name = value; RaisePropertyChanged("doc_score_name", ModelEntityUpdated);
                }
            }
        }
        private string _qulif_Level_name;
        public string qulif_Level_name
        {
            get
            {
                return _qulif_Level_name;
            }

            set
            {
                if (_qulif_Level_name != value)
                {
                    _qulif_Level_name = value; RaisePropertyChanged("qulif_Level_name", ModelEntityUpdated);
                }
            }
        }
        private string _priority_name;
        public string priority_name
        {
            get
            {
                return _priority_name;
            }

            set
            {
                if (_priority_name != value)
                {
                    _priority_name = value; RaisePropertyChanged("priority_name");
                }
            }
        }
        //Extra Fields
        private string _owner;
        public string owner
        {
            get
            {
                return _owner;
            }

            set
            {
                if (_owner != value)
                {
                    _owner = value; RaisePropertyChanged("owner", ModelEntityUpdated);
                }
            }
        }
        private string _EmpName;
        public string EmpName
        {
            get
            {
                return _EmpName;
            }

            set
            {
                if (_EmpName != value)
                {
                    _EmpName = value; RaisePropertyChanged("EmpName", ModelEntityUpdated);
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
        private string _contact_person;
        public string contact_person
        {
            get
            {
                return _contact_person;
            }

            set
            {
                if (_contact_person != value)
                {
                    _contact_person = value; RaisePropertyChanged("contact_person", ModelEntityUpdated);
                }
            }
        }
        private string _person_number;
        public string person_number
        {
            get
            {
                return _person_number;
            }

            set
            {
                if (_person_number != value)
                {
                    _person_number = value; RaisePropertyChanged("person_number", ModelEntityUpdated);
                }
            }
        }
        private string _EmailId;
        public string EmailId
        {
            get
            {
                return _EmailId;
            }

            set
            {
                if (_EmailId != value)
                {
                    _EmailId = value; RaisePropertyChanged("EmailId", ModelEntityUpdated);
                }
            }
        }
        private string _place;
        public string place
        {
            get
            {
                return _place;
            }

            set
            {
                if (_place != value)
                {
                    _place = value; RaisePropertyChanged("place", ModelEntityUpdated);
                }
            }
        }
        private string _party_name2;
        public string party_name2
        {
            get
            {
                return _party_name2;
            }

            set
            {
                if (_party_name2 != value)
                {
                    _party_name2 = value; RaisePropertyChanged("party_name2");
                }
            }
        }
        private string _cp_name;
        public string cp_name
        {
            get
            {
                return _cp_name;
            }

            set
            {
                if (_cp_name != value)
                {
                    _cp_name = value; RaisePropertyChanged("cp_name");
                }
            }
        }
    }
    public class MultipleContext_CRM_T003
    {
        public List<SYS_M002> DocumentTypes { get; set; }
        public List<CRM_M003_P_RefDoc> ReferenceList { get; set; }
        public List<CRM_T003_Flip> DocumentDataFlipGrid { get; set; }
        public List<ADM_M053_P> PartyMaster { get; set; }
        public List<ADM_M054_P> BuyerList { get; set; }
        public List<ADM_M040_P> PriorityList { get; set; }
        public List<ADM_M037_P> Currencys { get; set; }
        public List<CRM_M002_P> StatusValueList { get; set; }
        public List<CRM_M005_P> OriginList { get; set; }
        public List<SYS_P004_P> IndustryTyList { get; set; }
        public List<ADM_M057_A_P> PrefContactList { get; set; }
        public List<CRM_T003_ItemsList> ItemListPopup { get; set; }
        public List<ADM_M038_B_P> UOM { get; set; }
        public List<ADM_M024_P> EmployeeList { get; set; }
        public List<CRM_M009_P> RoleList { get; set; }
        public List<ADM_M001_C_P> DistributionChannel { get; set; }
        public List<ACC_M019_P> Cost_Centers { get; set; }

        public List<CRM_T003> MasterEntity { get; set; }
        public ObservableCollection<CRM_T003_A> ItemsEntity { get; set; }
        public ObservableCollection<CRM_T003_B> LeadDistbnEntity { get; set; }
        public ObservableCollection<CRM_T003_C> LeadPartyEntity { get; set; }
        public ObservableCollection<CRM_T003_D> LeadContactEntity { get; set; }
        public ObservableCollection<ADM_M053> PartyEntityList { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<NotificationData> NotificationData { get; set; }
        public List<GetItemDetailsEntity> UnitPriceList { get; set; }
        public List<GetItemDetailsEntity> QFRList { get; set; }
        public List<GetItemDetailsEntity> DispatchList { get; set; }
        public List<GetItemDetailsEntity> ProjectedDispList { get; set; }
    }
}
