using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.General
{
    public partial class ADM_M055 : ObjectBase
    {
        public string addr_code { get; set; }
        public int id { get; set; }
        public string addr_type { get; set; }
        public string trans_code { get; set; }
        public string parent_id { get; set; }
        public string addr_place { get; set; }
        public string addr_line1 { get; set; }
        public string addr_line2 { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string state_code { get; set; }
        public string postal_code { get; set; }
        public string country_code { get; set; }
        public string land_mark { get; set; }
        public string map_link { get; set; }
        public string sat_view { get; set; }
        public string care_name { get; set; }
        public string train_station { get; set; }
        public string airport { get; set; }
        public string int_loc1 { get; set; }
        public string int_loc2 { get; set; }
        public string location_id { get; set; }
        public string ind_cust_supp { get; set; }
        public string time_zone { get; set; }
        public string city_def_lang { get; set; }
        public string city1 { get; set; }
        public string build_code { get; set; }
        public string build_floor { get; set; }
        public string room_no { get; set; }
        public string house_no { get; set; }
        public string add_house_no { get; set; }
        public string township { get; set; }
        public string addr_title { get; set; }
        public string language { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string edit_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id1 { get; set; }
        public string comp_code { get; set; }
        public string lang_key { get; set; }
        //Scaler
        public string CntryName { get; set; }
        public string StatName { get; set; }
    }
}
