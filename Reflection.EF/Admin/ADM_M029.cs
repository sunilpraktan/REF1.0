using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ADM_M029 : ObjectBase
    {
        public int SrNo { get; set; }
        public string PartyId { get; set; }
        public string Location { get; set; }
        public string AddType { get; set; }
        public string Add1 { get; set; }
        public string Add2 { get; set; }
        public string LandMark { get; set; }
        public string City { get; set; }
        public string state_code { get; set; }
        public string country_code { get; set; }
        public string PinCode { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public Nullable<bool> active { get; set; }
        public string PartyNm { get; set; }
        public string CntryName { get; set; }
        public string StatName { get; set; }
    }
}
