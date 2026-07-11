using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ADM_M001 : ObjectBase
    {
        public string group_code { get; set; }
        public string Abbrv { get; set; }
        public string GrpName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string state_code { get; set; }
        public string country_code { get; set; }
        public string PinCode { get; set; }
        public string PhOffi { get; set; }
        public string PhOffiExtn { get; set; }
        public string FaxNo { get; set; }
        public string MailID { get; set; }
        public string WebSite { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public string lang_key { get; set; }
        public DateTime? edit_date { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
    }
   
}

