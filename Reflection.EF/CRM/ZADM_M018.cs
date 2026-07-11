using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.CRM
{
    public partial class ZADM_M018 : ObjectBase
    {
        public int id { get; set; }
        public Nullable<int> company_id { get; set; }
        public string plant { get; set; }
        public string entry_no { get; set; }
        public Nullable<System.DateTime> entry_dt { get; set; }
        public string trans_type { get; set; }
        public Nullable<int> party_id { get; set; }
        public string item_code { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public string grade { get; set; }
        public Nullable<decimal> amt { get; set; }
        public string acc_type { get; set; }
        public string debit_credit { get; set; }
        public string note { get; set; }
        public Nullable<int> consig_id { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string edit_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string PlantName { get; set; }
        public string PartyName { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string PartyId { get; set; }
        public string ItemCode { get; set; }
        public string editby { get; set; }
    }
}
