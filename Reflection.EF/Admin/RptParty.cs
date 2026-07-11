using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public class RptParty
    {
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string Location { get; set; }
        public string address { get; set; }
        public string contact_person { get; set; }
        public string PersnMobNo { get; set; }
        public string PersnEmailId { get; set; }
        public Nullable<bool> Customer { get; set; }
        public Nullable<bool> Supplier { get; set; }
        public Nullable<bool> transporter { get; set; }
        public string PanNo { get; set; }
        public string curr_code { get; set; }
        public string VendorCd { get; set; }
        public string p_term_code { get; set; }
        public string gstinno { get; set; }
        public string BusinesTyp { get; set; }
    }
}
