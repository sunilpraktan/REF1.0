using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.CRM.ReportEntityCRM
{
     public class CreditDebit
    {
        public string bill_doc { get; set; }
        public DateTime? bill_date { get; set; }
        public string ItemCode { get; set; }
        public string item_desc { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string local_export { get; set; }
        public string credit_debit { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public decimal? invoice_amt { get; set; }
        public decimal? sub_total { get; set; }
        public decimal? ass_value { get; set; }
        public decimal? tax_amount { get; set; }

    }
}
