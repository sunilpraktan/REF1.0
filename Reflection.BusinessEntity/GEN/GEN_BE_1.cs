using Reflection.BusinessEntity.MM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.GEN
{
    public class GEN_M0001 : ObjectBase
	{
        public static event EventHandler ModelEntityUpdated = delegate { };
        private string _comp_code;
		public string comp_code
		{
			get { return _comp_code; }
			set { _comp_code = value; RaisePropertyChanged("comp_code"); }
		}

		private string _party_code;
		public string party_code
		{
			get { return _party_code; }
			set { _party_code = value; RaisePropertyChanged("party_code"); }
		}

		private string _party_name;
		public string party_name
		{
			get { return _party_name; }
			set { _party_name = value; RaisePropertyChanged("party_name"); }
		}

		private string _abbr;
		public string abbr
		{
			get { return _abbr; }
			set { _abbr = value; RaisePropertyChanged("abbr"); }
		}

		private string _place;
		public string place
		{
			get { return _place; }
			set { _place = value; RaisePropertyChanged("place"); }
		}

		private string _vendor_code;
		public string vendor_code
		{
			get { return _vendor_code; }
			set { _vendor_code = value; RaisePropertyChanged("vendor_code"); }
		}

		private string _ind_cust;
		public string ind_cust
		{
			get { return _ind_cust; }
			set { _ind_cust = value; RaisePropertyChanged("ind_cust"); }
		}

		private string _ind_supp;
		public string ind_supp
		{
			get { return _ind_supp; }
			set { _ind_supp = value; RaisePropertyChanged("ind_supp"); }
		}

		private string _ind_sp;
		public string ind_sp
		{
			get { return _ind_sp; }
			set { _ind_sp = value; RaisePropertyChanged("ind_sp"); }
		}

		private string _party_type;
		public string party_type
		{
			get { return _party_type; }
			set { _party_type = value; RaisePropertyChanged("party_type"); }
		}

		private string _vat_no;
		public string vat_no
		{
			get { return _vat_no; }
			set { _vat_no = value; RaisePropertyChanged("vat_no"); }
		}

		private DateTime? _vat_date;
		public DateTime? vat_date
		{
			get { return _vat_date; }
			set { _vat_date = value; RaisePropertyChanged("vat_date"); }
		}

		private string _pan_no;
		public string pan_no
		{
			get { return _pan_no; }
			set { _pan_no = value; RaisePropertyChanged("pan_no"); }
		}

		private string _pt_code;
		public string pt_code
		{
			get { return _pt_code; }
			set { _pt_code = value; RaisePropertyChanged("pt_code"); }
		}

		private string _curr_code;
		public string curr_code
		{
			get { return _curr_code; }
			set { _curr_code = value; RaisePropertyChanged("curr_code"); }
		}

		private decimal? _credit_limit;
		public decimal? credit_limit
		{
			get { return _credit_limit; }
			set { _credit_limit = value; RaisePropertyChanged("credit_limit"); }
		}

		private int? _credit_days;
		public int? credit_days
		{
			get { return _credit_days; }
			set { _credit_days = value; RaisePropertyChanged("credit_days"); }
		}

		private bool? _active;
		public bool? active
		{
			get { return _active; }
			set { _active = value; RaisePropertyChanged("active"); }
		}

		private string _active_code;
		public string active_code
		{
			get { return _active_code; }
			set { _active_code = value; RaisePropertyChanged("active_code"); }
		}

		private string _prin_party;
		public string prin_party
		{
			get { return _prin_party; }
			set { _prin_party = value; RaisePropertyChanged("prin_party"); }
		}

		private string _party_group;
		public string party_group
		{
			get { return _party_group; }
			set { _party_group = value; RaisePropertyChanged("party_group"); }
		}

		private string _group_code;
		public string group_code
		{
			get { return _group_code; }
			set { _group_code = value; RaisePropertyChanged("group_code"); }
		}

		private string _ind_otp;
		public string ind_otp
		{
			get { return _ind_otp; }
			set { _ind_otp = value; RaisePropertyChanged("ind_otp"); }
		}

		private string _iec_code;
		public string iec_code
		{
			get { return _iec_code; }
			set { _iec_code = value; RaisePropertyChanged("iec_code"); }
		}

		private string _acc_group;
		public string acc_group
		{
			get { return _acc_group; }
			set { _acc_group = value; RaisePropertyChanged("acc_group"); }
		}

		private string _recon_acc;
		public string recon_acc
		{
			get { return _recon_acc; }
			set { _recon_acc = value; RaisePropertyChanged("recon_acc"); }
		}

		
		private string _sal_code;
		public string sal_code
		{
			get { return _sal_code; }
			set { _sal_code = value; RaisePropertyChanged("sal_code"); }
		}

		private string _buss_type;
		public string buss_type
		{
			get { return _buss_type; }
			set { _buss_type = value; RaisePropertyChanged("buss_type"); }
		}
		
		private byte[] _photo;
		public byte[] photo
		{
			get { return _photo; }
			set { _photo = value; RaisePropertyChanged("photo"); }
		}
	
		private string _t_status;
		public string t_status
		{
			get { return _t_status; }
			set { _t_status = value; RaisePropertyChanged("t_status"); }
		}

		private string _ind_cat;
		public string ind_cat
		{
			get { return _ind_cat; }
			set
            {
                if (_ind_cat != value)
                {
                    _ind_cat = value;
                    RaisePropertyChanged("ind_cat", ModelEntityUpdated);
                }
            }
		}

		private string _ind_type;
		public string ind_type
		{
			get { return _ind_type; }
			set { _ind_type = value; RaisePropertyChanged("ind_type"); }
		}

		private DateTime? _doe;
		public DateTime? doe
		{
			get { return _doe; }
			set {
                if (_doe != value)
                {
                    _doe = value; RaisePropertyChanged("doe", ModelEntityUpdated);
                }
            }
		}

		private string _ind_gender;
		public string ind_gender
		{
			get { return _ind_gender; }
            set
            {
                if (_ind_gender != value)
                {
                    _ind_gender = value; RaisePropertyChanged("ind_gender", ModelEntityUpdated);
                }
            }
		}

		private string _f_name;
		public string f_name
		{
			get { return _f_name; }
			set {

				if (value != null)
				{
					if (!char.IsUpper(value[0]))
					{
						_f_name = char.ToUpper(value[0]) + value.Substring(1);
					}
                    else { _f_name = value; }
                }
                    RaisePropertyChanged("f_name", ModelEntityUpdated); 
			}
		}

		private string _m_name;
		public string m_name
		{
			get { return _m_name; }
            set
            {

                if (value != null)
                {
                    if (!char.IsUpper(value[0]))
                    {
                        _m_name = char.ToUpper(value[0]) + value.Substring(1);
                    }
                    else { _m_name = value; }
                }
                RaisePropertyChanged("f_name", ModelEntityUpdated);
            }
        }

		private string _l_name;
		public string l_name
		{
			get { return _l_name; }
            set
            {

                if (value != null)
                {
                    if (!char.IsUpper(value[0]))
                    {
                        _l_name = char.ToUpper(value[0]) + value.Substring(1);
                    }
                    else { _l_name = value; }
                }
                RaisePropertyChanged("f_name", ModelEntityUpdated);
            }
        }

		private string _short_text;
		public string short_text
		{
			get { return _short_text; }
			set { _short_text = value; RaisePropertyChanged("short_text"); }
		}

		

		// Scalar Fields
		private string _sal_text;
		public string sal_text
		{
			get { return _sal_text; }
			set { _sal_text = value; RaisePropertyChanged("sal_text"); }
		}
        private string _age;
        public string age
        {
            get { return _age; }
            set {
                if (_age != value)
                {
                    _age = value; RaisePropertyChanged("age", ModelEntityUpdated);
                }
            }
        }

        public string XDOC_A { get; set; }
		public string XDOC_B { get; set; }
		public string XDOC_C { get; set; }
		public string doc_cat { get; set; }
		public string doc_type { get; set; }

	}

	public class GEN_M0011 : ObjectBase
	{
		private int? _SrNo;
		public int? SrNo
		{
			get { return _SrNo; }
			set { _SrNo = value; RaisePropertyChanged("SrNo"); }
		}

		private string _add_code;
		public string add_code
		{
			get { return _add_code; }
			set { _add_code = value; RaisePropertyChanged("add_code"); }
		}

		private string _add_cat;
		public string add_cat
		{
			get { return _add_cat; }
			set { _add_cat = value; RaisePropertyChanged("add_cat"); }
		}

		private string _add_type;
		public string add_type
		{
			get { return _add_type; }
			set { _add_type = value; RaisePropertyChanged("add_type"); }
		}

		private string _obj_type;
		public string obj_type
		{
			get { return _obj_type; }
			set { _obj_type = value; RaisePropertyChanged("obj_type"); }
		}

		private string _obj_code;
		public string obj_code
		{
			get { return _obj_code; }
			set { _obj_code = value; RaisePropertyChanged("obj_code"); }
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

		private string _place;
		public string place
		{
			get { return _place; }
			set { _place = value; RaisePropertyChanged("place"); }
		}

		private string _add_line1;
		public string add_line1
		{
			get { return _add_line1; }
			set { _add_line1 = value; RaisePropertyChanged("add_line1"); }
		}

		private string _add_line2;
		public string add_line2
		{
			get { return _add_line2; }
			set { _add_line2 = value; RaisePropertyChanged("add_line2"); }
		}

		private string _city;
		public string city
		{
			get { return _city; }
			set { _city = value; RaisePropertyChanged("city"); }
		}

		private string _district;
		public string district
		{
			get { return _district; }
			set { _district = value; RaisePropertyChanged("district"); }
		}

		private string _state_code;
		public string state_code
		{
			get { return _state_code; }
			set { _state_code = value; RaisePropertyChanged("state_code"); }
		}

		private string _state_name;
		public string state_name
		{
			get { return _state_name; }
			set { _state_name = value; RaisePropertyChanged("state_name"); }
		}

		private string _postal_code;
		public string postal_code
		{
			get { return _postal_code; }
			set { _postal_code = value; RaisePropertyChanged("postal_code"); }
		}

		private string _ctry_code;
		public string ctry_code
		{
			get { return _ctry_code; }
			set { _ctry_code = value; RaisePropertyChanged("ctry_code"); }
		}

		private string _land_mark;
		public string land_mark
		{
			get { return _land_mark; }
			set { _land_mark = value; RaisePropertyChanged("land_mark"); }
		}

		private string _map_link;
		public string map_link
		{
			get { return _map_link; }
			set { _map_link = value; RaisePropertyChanged("map_link"); }
		}

		private decimal? _longitude;
		public decimal? longitude
		{
			get { return _longitude; }
			set { _longitude = value; RaisePropertyChanged("longitude"); }
		}

		private decimal? _latitude;
		public decimal? latitude
		{
			get { return _latitude; }
			set { _latitude = value; RaisePropertyChanged("latitude"); }
		}

		private string _sat_view;
		public string sat_view
		{
			get { return _sat_view; }
			set { _sat_view = value; RaisePropertyChanged("sat_view"); }
		}

		private string _care_name;
		public string care_name
		{
			get { return _care_name; }
			set { _care_name = value; RaisePropertyChanged("care_name"); }
		}

		private string _train_station;
		public string train_station
		{
			get { return _train_station; }
			set { _train_station = value; RaisePropertyChanged("train_station"); }
		}

		private string _airport;
		public string airport
		{
			get { return _airport; }
			set { _airport = value; RaisePropertyChanged("airport"); }
		}

		private string _int_loc1;
		public string int_loc1
		{
			get { return _int_loc1; }
			set { _int_loc1 = value; RaisePropertyChanged("int_loc1"); }
		}

		private string _int_loc2;
		public string int_loc2
		{
			get { return _int_loc2; }
			set { _int_loc2 = value; RaisePropertyChanged("int_loc2"); }
		}

		private string _location_id;
		public string location_id
		{
			get { return _location_id; }
			set { _location_id = value; RaisePropertyChanged("location_id"); }
		}

		private string _time_zone;
		public string time_zone
		{
			get { return _time_zone; }
			set { _time_zone = value; RaisePropertyChanged("time_zone"); }
		}

		private string _city_lang;
		public string city_lang
		{
			get { return _city_lang; }
			set { _city_lang = value; RaisePropertyChanged("city_lang"); }
		}

		private string _city2;
		public string city2
		{
			get { return _city2; }
			set { _city2 = value; RaisePropertyChanged("city2"); }
		}

		private string _build_code;
		public string build_code
		{
			get { return _build_code; }
			set { _build_code = value; RaisePropertyChanged("build_code"); }
		}

		private string _build_floor;
		public string build_floor
		{
			get { return _build_floor; }
			set { _build_floor = value; RaisePropertyChanged("build_floor"); }
		}

		private string _room_no;
		public string room_no
		{
			get { return _room_no; }
			set { _room_no = value; RaisePropertyChanged("room_no"); }
		}

		private string _house_no;
		public string house_no
		{
			get { return _house_no; }
			set { _house_no = value; RaisePropertyChanged("house_no"); }
		}

		private string _add_house_no;
		public string add_house_no
		{
			get { return _add_house_no; }
			set { _add_house_no = value; RaisePropertyChanged("add_house_no"); }
		}

		private string _township;
		public string township
		{
			get { return _township; }
			set { _township = value; RaisePropertyChanged("township"); }
		}

		private string _add_title;
		public string add_title
		{
			get { return _add_title; }
			set { _add_title = value; RaisePropertyChanged("add_title"); }
		}

		private string _language;
		public string language
		{
			get { return _language; }
			set { _language = value; RaisePropertyChanged("language"); }
		}
		private bool? _active;
		public bool? active
		{
			get { return _active; }
			set { _active = value; RaisePropertyChanged("active"); }
		}
		private string _active_code;
		public string active_code
		{
			get { return _active_code; }
			set { _active_code = value; RaisePropertyChanged("active_code"); }
		}

		private string _t_status;
		public string t_status
		{
			get { return _t_status; }
			set { _t_status = value; RaisePropertyChanged("t_status"); }
		}

		private DateTime? _from_date;
		public DateTime? from_date
		{
			get { return _from_date; }
			set { _from_date = value; RaisePropertyChanged("from_date"); }
		}

		private DateTime? _to_date;
		public DateTime? to_date
		{
			get { return _to_date; }
			set { _to_date = value; RaisePropertyChanged("to_date"); }
		}

		private string _from_time;
		public string from_time
		{
			get { return _from_time; }
			set { _from_time = value; RaisePropertyChanged("from_time"); }
		}

		private string _to_time;
		public string to_time
		{
			get { return _to_time; }
			set { _to_time = value; RaisePropertyChanged("to_time"); }
		}

		private string _ind_add;
		public string ind_add
		{
			get { return _ind_add; }
			set { _ind_add = value; RaisePropertyChanged("ind_add"); }
		}

		private string _ind_type;
		public string ind_type
		{
			get { return _ind_type; }
			set { _ind_type = value; RaisePropertyChanged("ind_type"); }
		}

		private string _tax_reg_no;
		public string tax_reg_no
		{
			get { return _tax_reg_no; }
			set { _tax_reg_no = value; RaisePropertyChanged("tax_reg_no"); }
		}

		private DateTime? _tax_reg_date;
		public DateTime? tax_reg_date
		{
			get { return _tax_reg_date; }
			set { _tax_reg_date = value; RaisePropertyChanged("tax_reg_date"); }
		}

		private string _buss_place;
		public string buss_place
		{
			get { return _buss_place; }
			set { _buss_place = value; RaisePropertyChanged("buss_place"); }
		}


	}

	public class GEN_M0021 : ObjectBase
	{
		private string _place;
		public string place
		{
			get { return _place; }
			set { _place = value; RaisePropertyChanged("place"); }
		}

		private string _dept_code;
		public string dept_code
		{
			get { return _dept_code; }
			set { _dept_code = value; RaisePropertyChanged("dept_code"); }
		}

		private string _desig_code;
		public string desig_code
		{
			get { return _desig_code; }
			set { _desig_code = value; RaisePropertyChanged("desig_code"); }
		}

		private int? _age;
		public int? age
		{
			get { return _age; }
			set { _age = value; RaisePropertyChanged("age"); }
		}

		private string _gender;
		public string gender
		{
			get { return _gender; }
			set { _gender = value; RaisePropertyChanged("gender"); }
		}
		
		private string _active;
		public string active
		{
			get { return _active; }
			set { _active = value; RaisePropertyChanged("active"); }
		}

		private string _cp_code;
		public string cp_code
		{
			get { return _cp_code; }
			set { _cp_code = value; RaisePropertyChanged("cp_code"); }
		}

		private string _party_code;
		public string party_code
		{
			get { return _party_code; }
			set { _party_code = value; RaisePropertyChanged("party_code"); }
		}

		private string _sal_code;
		public string sal_code
		{
			get { return _sal_code; }
			set { _sal_code = value; RaisePropertyChanged("sal_code"); }
		}

		private string _f_name;
		public string f_name
		{
			get { return _f_name; }
			set { _f_name = value; RaisePropertyChanged("f_name"); }
		}

		private string _m_name;
		public string m_name
		{
			get { return _m_name; }
			set { _m_name = value; RaisePropertyChanged("m_name"); }
		}

		private string _l_name;
		public string l_name
		{
			get { return _l_name; }
			set { _l_name = value; RaisePropertyChanged("l_name"); }
		}

		private string _nick_name;
		public string nick_name
		{
			get { return _nick_name; }
			set { _nick_name = value; RaisePropertyChanged("nick_name"); }
		}

		private string _add_code;
		public string add_code
		{
			get { return _add_code; }
			set { _add_code = value; RaisePropertyChanged("add_code"); }
		}

		private byte[] _photo;
		public byte[] photo
		{
			get { return _photo; }
			set { _photo = value; RaisePropertyChanged("photo"); }
		}

		private string _ind_mar;
		public string ind_mar
		{
			get { return _ind_mar; }
			set { _ind_mar = value; RaisePropertyChanged("ind_mar"); }
		}

		private bool? _active_code;
		public bool? active_code
		{
			get { return _active_code; }
			set { _active_code = value; RaisePropertyChanged("active_code"); }
		}

		private string _t_status;
		public string t_status
		{
			get { return _t_status; }
			set { _t_status = value; RaisePropertyChanged("t_status"); }
		}

		private string _obj_type;
		public string obj_type
		{
			get { return _obj_type; }
			set { _obj_type = value; RaisePropertyChanged("obj_type"); }
		}

		private string _obj_code;
		public string obj_code
		{
			get { return _obj_code; }
			set { _obj_code = value; RaisePropertyChanged("obj_code"); }
		}


	}

	public class GEN_M0031 : ObjectBase
	{
		private int? _id;
		public int? id
		{
			get { return _id; }
			set { _id = value; RaisePropertyChanged("id"); }
		}

		private string _cn_code;
		public string cn_code
		{
			get { return _cn_code; }
			set { _cn_code = value; RaisePropertyChanged("cn_code"); }
		}

		private string _obj_type;
		public string obj_type
		{
			get { return _obj_type; }
			set { _obj_type = value; RaisePropertyChanged("obj_type"); }
		}

		private string _obj_code;
		public string obj_code
		{
			get { return _obj_code; }
			set { _obj_code = value; RaisePropertyChanged("obj_code"); }
		}

		private string _add_code;
		public string add_code
		{
			get { return _add_code; }
			set { _add_code = value; RaisePropertyChanged("add_code"); }
		}

		private string _parent_id;
		public string parent_id
		{
			get { return _parent_id; }
			set { _parent_id = value; RaisePropertyChanged("parent_id"); }
		}

		private string _type_code;
		public string type_code
		{
			get { return _type_code; }
			set { _type_code = value; RaisePropertyChanged("type_code"); }
		}

		private string _sub_type;
		public string sub_type
		{
			get { return _sub_type; }
			set { _sub_type = value; RaisePropertyChanged("sub_type"); }
		}

		private string _ind_primary;
		public string ind_primary
		{
			get { return _ind_primary; }
			set { _ind_primary = value; RaisePropertyChanged("ind_primary"); }
		}

		private string _cn_text;
		public string cn_text
		{
			get { return _cn_text; }
			set { _cn_text = value; RaisePropertyChanged("cn_text"); }
		}

		private string _ext_no;
		public string ext_no
		{
			get { return _ext_no; }
			set { _ext_no = value; RaisePropertyChanged("ext_no"); }
		}

		private string _acc_name;
		public string acc_name
		{
			get { return _acc_name; }
			set { _acc_name = value; RaisePropertyChanged("acc_name"); }
		}

		private string _short_text;
		public string short_text
		{
			get { return _short_text; }
			set { _short_text = value; RaisePropertyChanged("short_text"); }
		}

		private string _aso_cn;
		public string aso_cn
		{
			get { return _aso_cn; }
			set { _aso_cn = value; RaisePropertyChanged("aso_cn"); }
		}

		private string _ind_phone;
		public string ind_phone
		{
			get { return _ind_phone; }
			set { _ind_phone = value; RaisePropertyChanged("ind_phone"); }
		}

		private string _ind_pcm;
		public string ind_pcm
		{
			get { return _ind_pcm; }
			set { _ind_pcm = value; RaisePropertyChanged("ind_pcm"); }
		}

		private string _ind_default;
		public string ind_default
		{
			get { return _ind_default; }
			set { _ind_default = value; RaisePropertyChanged("ind_default"); }
		}

		private DateTime? _valid_from;
		public DateTime? valid_from
		{
			get { return _valid_from; }
			set { _valid_from = value; RaisePropertyChanged("valid_from"); }
		}

		private DateTime? _valid_to;
		public DateTime? valid_to
		{
			get { return _valid_to; }
			set { _valid_to = value; RaisePropertyChanged("valid_to"); }
		}

		private string _seq_no;
		public string seq_no
		{
			get { return _seq_no; }
			set { _seq_no = value; RaisePropertyChanged("seq_no"); }
		}

		private string _ctry_code;
		public string ctry_code
		{
			get { return _ctry_code; }
			set { _ctry_code = value; RaisePropertyChanged("ctry_code"); }
		}

		private string _ind_sms;
		public string ind_sms
		{
			get { return _ind_sms; }
			set { _ind_sms = value; RaisePropertyChanged("ind_sms"); }
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

		// Scalar Field Section

		private string _type_name;
		public string type_name
	{
			get { return _type_name; }
			set { _type_name = value; RaisePropertyChanged("type_name"); }
		}



	}

	public class GEN_T011 : ObjectBase
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

		private string _doc_cat;
		public string doc_cat
		{
			get { return _doc_cat; }
			set { _doc_cat = value; RaisePropertyChanged("doc_cat"); }
		}

		private string _doc_no;
		public string doc_no
		{
			get { return _doc_no; }
			set { _doc_no = value; RaisePropertyChanged("doc_no"); }
		}

		private string _tc_code;
		public string tc_code
		{
			get { return _tc_code; }
			set { _tc_code = value; RaisePropertyChanged("tc_code"); }
		}

		private int? _seq_no;
		public int? seq_no
		{
			get { return _seq_no; }
			set { _seq_no = value; RaisePropertyChanged("seq_no"); }
		}

		private int? _sr_no;
		public int? sr_no
		{
			get { return _sr_no; }
			set { _sr_no = value; RaisePropertyChanged("sr_no"); }
		}

		private string _short_text;
		public string short_text
		{
			get { return _short_text; }
			set { _short_text = value; RaisePropertyChanged("short_text"); }
		}

		private string _long_text;
		public string long_text
		{
			get { return _long_text; }
			set { _long_text = value; RaisePropertyChanged("long_text"); }
		}

		private string _con_group;
		public string con_group
		{
			get { return _con_group; }
			set { _con_group = value; RaisePropertyChanged("con_group"); }
		}

		private string _con_type;
		public string con_type
		{
			get { return _con_type; }
			set { _con_type = value; RaisePropertyChanged("con_type"); }
		}

		private string _active;
		public string active
		{
			get { return _active; }
			set { _active = value; RaisePropertyChanged("active"); }
		}


	}

    public class GEN_T021 : ObjectBase
    {
        private bool? _selected;
        public bool? selected
        {
            get { return _selected; }
            set { _selected = value; RaisePropertyChanged("selected"); }
        }
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

        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set { _doc_no = value; RaisePropertyChanged("doc_no"); }
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

        private string _char_code;
        public string char_code
        {
            get { return _char_code; }
            set { _char_code = value; RaisePropertyChanged("char_code"); }
        }

        private int? _int_char;
        public int? int_char
        {
            get { return _int_char; }
            set { _int_char = value; RaisePropertyChanged("int_char"); }
        }

        private string _char_value;
        public string char_value
        {
            get { return _char_value; }
            set { _char_value = value; RaisePropertyChanged("char_value"); }
        }

        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code"); }
        }

        private string _note;
        public string note
        {
            get { return _note; }
            set { _note = value; RaisePropertyChanged("note"); }
        }

        private string _active;
        public string active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }


        //Scalar Fields

        private string _char_name;
        public string char_name
        {
            get { return _char_name; }
            set { _char_name = value; RaisePropertyChanged("char_name"); }
        }

        private string _group_name;
        public string group_name
        {
            get { return _group_name; }
            set { _group_name = value; RaisePropertyChanged("group_name"); }
        }

    }

    public class GEN_M0101 : ObjectBase
    {
        private bool? _selected;
        public bool? selected
        {
            get { return _selected; }
            set { _selected = value; RaisePropertyChanged("selected"); }
        }


        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }
        private string _obj_type;
        public string obj_type
        {
            get { return _obj_type; }
            set { _obj_type = value; RaisePropertyChanged("obj_type"); }
        }
        private string _obj_code;
        public string obj_code
        {
            get { return _obj_code; }
            set { _obj_code = value; RaisePropertyChanged("obj_code"); }
        }
        private int? _row_id;
        public int? row_id
        {
            get { return _row_id; }
            set { _row_id = value; RaisePropertyChanged("row_id"); }
        }
        private string _font_family;
        public string font_family
        {
            get { return _font_family; }
            set { _font_family = value; RaisePropertyChanged("font_family"); }
        }
        private float _font_size;
        public float font_size
        {
            get { return _font_size; }
            set { _font_size = value; RaisePropertyChanged("font_size"); }
        }
        private bool? _bold;
        public bool? bold
        {
            get { return _bold; }
            set { _bold = value; RaisePropertyChanged("bold"); }
        }
        private string _font_wt;
        public string font_wt
        {
            get { return _font_wt; }
            set { _font_wt = value; RaisePropertyChanged("font_wt"); }
        }
        private string _color;
        public string color
        {
            get { return _color; }
            set { _color = value; RaisePropertyChanged("color"); }
        }

        private string _char_code;
        public string char_code
        {
            get { return _char_code; }
            set { _char_code = value; RaisePropertyChanged("char_code"); }
        }

        private string _v_code;
        public string v_code
        {
            get { return _v_code; }
            set { _v_code = value; RaisePropertyChanged("v_code"); }
        }

        private string _active;
        public string active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }

        // Scalar
        private string _demo_value;
        public string demo_value
        {
            get { return _demo_value; }
            set { _demo_value = value; RaisePropertyChanged("demo_value"); }
        }

    }

    public class GEN_M0101_MC : STD_MC_BE
    {
        public ObservableCollection<GEN_M0101> MASTER_ENTITY_LIST { get; set; }
    }

    public class MC_GEN_M0001 : MC_GEN_BE
	{
		public List<GEN_M0001> PARTY_M_LIST { get; set; } // Party Master
		public ObservableCollection<GEN_M0011> ADDRESS_M_LIST { get; set; }  // Address Master
		public ObservableCollection<GEN_M0021> CP_M_LIST { get; set; }  // Contact Person Master
		public ObservableCollection<GEN_M0031> CN_M_LIST { get; set; }  // Contact no Master
		public ObservableCollection<GEN_M0031> CN_M_LIST_TEMP { get; set; }
	}

    public class MC_REF_T001 : MC_GEN_BE
    {
        public List<REF_T001> REF_T001_LIST { get; set; } // Party Master
    }


    public class REF_T001 // This is dupicate entity, also available in ReflectionFunctionService.cs file. Make at one only
    {
        public int? id { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string doc_no { get; set; }
        public string ts_code { get; set; }
        public string client { get; set; }
        public string comp_code { get; set; }
        public string op_type { get; set; }
        public string t_type { get; set; }
        public string userid { get; set; }
        public DateTime? t_date { get; set; }
        public string t_stamp { get; set; }
        public DateTimeOffset? t_datetimeoffset { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string lang_key { get; set; }
        public string location_Id { get; set; }
        public string t_status { get; set; }
        public string screen_namespace { get; set; }
        public string screen_class_path { get; set; }
        public string ts_name_display { get; set; }
    }
}
