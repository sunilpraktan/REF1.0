using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.CRM
{
    public partial class CRM_T001A : ObjectBase
    {
        public int CatNo { get; set; }
        public string cust_cat_no { get; set; }
        public Nullable<System.DateTime> CatDate { get; set; }
        public string PartyId { get; set; }
        public Nullable<System.DateTime> Fdate { get; set; }
        public Nullable<System.DateTime> Tdate { get; set; }
        public string remark { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string description { get; set; }
        public string so_code { get; set; }
        public string po_code { get; set; }
        public string party_name { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public Nullable<bool> generate_batch { get; set; }
        public string client { get; set; }
    }

}
