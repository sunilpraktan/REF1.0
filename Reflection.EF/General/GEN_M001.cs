using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.General
{
    public partial class ADM_M053 : ObjectBase
    {
        public string party_id { get; set; }
        public string PartyId { get; set; }
        public string sal_code { get; set; }
        public string party_name { get; set; }
        public string abbr { get; set; }
        public string party_type { get; set; }
        public string party_group { get; set; }
        public string buss_type { get; set; }
        public string acc_group { get; set; }
        public string refer_by { get; set; }
        public string party_location { get; set; }
        public string provider { get; set; }
        public byte[] photo { get; set; }
        public string so_code { get; set; }
        public string sg_code { get; set; }
        public string responsible_contact { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string edit_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string lang_key { get; set; }
        //Scaler
        public string grpNm { get; set; }
        public string PartyType_Nm { get; set; }
        public string group_desc { get; set; }
        public string acc_group_type { get; set; }
        public string refer_by_name { get; set; }
    }
}
