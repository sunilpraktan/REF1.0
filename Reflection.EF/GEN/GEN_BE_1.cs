using Reflection.EF.General;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.GEN
{
	public class GEN_M0001 : ObjectBase // Praposed party master.
	{
		public string comp_code { get; set; }
		public string party_code { get; set; }
		public string party_name { get; set; }
		public string abbr { get; set; }
		public string place { get; set; }
		public string vendor_code { get; set; }
		public string ind_cust { get; set; }
		public string ind_supp { get; set; }
		public string ind_sp { get; set; } // service provider
		public string party_type { get; set; }
		public string vat_no { get; set; }
		public DateTime? vat_date { get; set; }
		public string pan_no { get; set; }
		public string pt_code { get; set; } // Payment term
		public string curr_code { get; set; }
		public decimal? credit_limit { get; set; }
		public int? credit_days { get; set; }
		public bool? active { get; set; }
		public string active_code { get; set; }
		public string prin_party { get; set; } // principle_party
		public string party_group { get; set; } // group of companies under which this party assign. like we can give gredit to entire group like all companies under Tata Sons.
		public string group_code { get; set; } // old field name was group1
		public string ind_otp { get; set; } // one time Party or regular. or new client of marketting data.
		public string iec_code { get; set; }
		public string acc_group { get; set; }
		public string recon_acc { get; set; }
		public string sal_code { get; set; }
		public string buss_type { get; set; }
		public byte[] photo { get; set; }
		public string t_status { get; set; }
		public string ind_cat { get; set; }
		public string ind_type { get; set; }
		public DateTime? doe { get; set; } // Date of Establishment or birth
		public string ind_gender { get; set; }
		public string f_name { get; set; }
		public string m_name { get; set; }
		public string l_name { get; set; }
		public string short_text { get; set; }

		

		// Scalar Fields
		public string sal_text { get; set; }
        public string age { get; set; } // aproximate age to calculate DOB/E. if no DOB/E exists.

        public string XDOC_A { get; set; }
		public string XDOC_B { get; set; }
		public string XDOC_C { get; set; }
		public string doc_cat { get; set; }
		public string doc_type { get; set; }

	}

	public class GEN_M0011 : ObjectBase // Praposed Address master.
	{
		public int? SrNo { get; set; }
		public string add_code { get; set; }
		public string add_cat { get; set; }
		public string add_type { get; set; }
		public string obj_type { get; set; }
		public string obj_code { get; set; }
		public string doc_cat { get; set; }
		public string doc_type { get; set; }
		public string place { get; set; }
		public string add_line1 { get; set; }
		public string add_line2 { get; set; }
		public string city { get; set; }
		public string district { get; set; }
		public string state_code { get; set; }
		public string state_name { get; set; }
		public string postal_code { get; set; }
		public string ctry_code { get; set; }
		public string land_mark { get; set; }
		public string map_link { get; set; }
		public decimal? longitude { get; set; }
		public decimal? latitude { get; set; }
		public string sat_view { get; set; }
		public string care_name { get; set; }
		public string train_station { get; set; }
		public string airport { get; set; }
		public string int_loc1 { get; set; }
		public string int_loc2 { get; set; }
		public string location_id { get; set; }
		public string time_zone { get; set; }
		public string city_lang { get; set; }
		public string city2 { get; set; }
		public string build_code { get; set; }
		public string build_floor { get; set; }
		public string room_no { get; set; }
		public string house_no { get; set; }
		public string add_house_no { get; set; }
		public string township { get; set; }
		public string add_title { get; set; }
		public string language { get; set; }
		public bool? active { get; set; }
		public string active_code { get; set; }
		public string t_status { get; set; }
		public DateTime? from_date { get; set; }
		public DateTime? to_date { get; set; }
		public string from_time { get; set; }
		public string to_time { get; set; }
		public string ind_add { get; set; }
		public string ind_type { get; set; }
		public string tax_reg_no { get; set; }
		public DateTime? tax_reg_date { get; set; }
		public string buss_place { get; set; }

	}

	public class GEN_M0021 : ObjectBase // Contact person master.
	{
		public string place { get; set; }
		public string dept_code { get; set; }
		public string desig_code { get; set; }
		public int? age { get; set; }
		public string gender { get; set; }
		public string active { get; set; }
		public string cp_code { get; set; }
		public string party_code { get; set; }
		public string sal_code { get; set; }
		public string f_name { get; set; }
		public string m_name { get; set; }
		public string l_name { get; set; }
		public string nick_name { get; set; }
		public string add_code { get; set; }
		public byte[] photo { get; set; }
		public string ind_mar { get; set; }
		public bool?  active_code { get; set; }
		public string t_status { get; set; }
		public string obj_type { get; set; }
		public string obj_code { get; set; }

	}

	public class GEN_M0031 : ObjectBase // Praposed contact no/id master.
	{
		public int? id { get; set; }
		public string cn_code { get; set; }
		public string obj_type { get; set; }
		public string obj_code { get; set; }
		public string add_code { get; set; }
		public string parent_id { get; set; }
		public string type_code { get; set; }
		public string sub_type { get; set; }
		public string ind_primary { get; set; }
		public string cn_text { get; set; }
		public string ext_no { get; set; }
		public string acc_name { get; set; }
		public string short_text { get; set; }
		public string aso_cn { get; set; }
		public string ind_phone { get; set; }
		public string ind_pcm { get; set; }
		public string ind_default { get; set; }
		public DateTime? valid_from { get; set; }
		public DateTime? valid_to { get; set; }
		public string seq_no { get; set; }
		public string ctry_code { get; set; }
		public string ind_sms { get; set; }
		public string active { get; set; }
		public string t_status { get; set; }

		// Scalar Field Section
		public string type_name { get; set; }

	}

	public class GEN_T011 : ObjectBase 
	{
		public int? id { get; set; }
		public string comp_code { get; set; }
		public string doc_no { get; set; }
		public string doc_cat { get; set; }
		public string tc_code { get; set; }
		public int? seq_no { get; set; }
		public int? sr_no { get; set; }
		public string short_text { get; set; }
		public string long_text { get; set; }
		public string con_group { get; set; }
		public string con_type { get; set; }
		public string active { get; set; }

	}

    public class GEN_T021 : ObjectBase
    {
        public bool? selected { get; set; }
        public int? id { get; set; }
        public string comp_code { get; set; }
        public string doc_no { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string char_code { get; set; }
        public int? int_char { get; set; }
        public string char_value { get; set; }
        public string unit_code { get; set; }
        public string note { get; set; }
        public string active { get; set; }

        
        //Scalar Fields
        public string char_name { get; set; }
        public string group_name { get; set; }
       

    }

    public class GEN_M0101 : ObjectBase // Font Style entity
    {
        public bool? selected { get; set; }
        public string comp_code { get; set; }
        public string obj_type { get; set; }
        public string obj_code { get; set; }
        public int? row_id { get; set; }
        public string font_family { get; set; }
        public float font_size { get; set; }
        public bool? bold { get; set; }
        public string font_wt { get; set; }
        public string color { get; set; }
        public string char_code { get; set; }
        public string v_code { get; set; }
        public string active { get; set; }


        // Scalar
        public string demo_value { get; set; } //  this is only for demo value. style will apply on this to show how it will display, this will not save in database. we can take any fix value or user can edit as per requirement like Numeric, alfabetic etc.


    }

    public class GEN_M0101_MC : STD_MC_BE
    {
        public List<GEN_M0101> MASTER_ENTITY_LIST { get; set; }
    }
    public class MC_GEN_M0001 : MC_GEN_BE
	{
		public List<GEN_M0001> PARTY_M_LIST { get; set; } // Party Master
		public List<GEN_M0011> ADDRESS_M_LIST { get; set; }  // Address Master
		public List<GEN_M0021> CP_M_LIST { get; set; }  // Contact Person Master
		public List<GEN_M0031> CN_M_LIST { get; set; }  // Contact no Master
		public List<GEN_M0031> CN_M_LIST_TEMP { get; set; }  // Contact no Master for default new list
	}
    public class MC_REF_T001 : MC_GEN_BE
    {
        public List<REF_T001> REF_T001_LIST { get; set; } // Party Master
    }
}
