using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessEntity.Finance
{
    public class RptPaymentBalance
    {
        public string sales_person { get; set; }
        public DateTime? day { get; set; }
        public string month { get; set; }
        public string sono { get; set; }
        public DateTime? so_date { get; set; }
        public string po_no { get; set; }
        public string quotation_no { get; set; }
        public string client_name { get; set; }
        public string site { get; set; }
        public string location { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string bill_doc { get; set; }
        public string square_ft { get; set; }
        public decimal? sq_ft { get; set; }
        public decimal? total { get; set; }
        public decimal? received { get; set; }
        public decimal? balance { get; set; }
        public decimal? wastage { get; set; }
        public decimal? credit_amt { get; set; }
        public decimal? debit_amt { get; set; }
        public string doc_cat { get; set; }
        public decimal? bal { get; set; }
        public decimal? journal_amt { get; set; }
        public string dc_ind { get; set; }
        public decimal? C_amt { get; set; }
        public decimal? D_amt { get; set; }

        // Opening Balance
        public string doc_no { get; set; }
        public DateTime? doc_date { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string fin_year { get; set; }
        public string invoice_no { get; set; }
        public DateTime? invoice_date { get; set; }
        public decimal? para1 { get; set; }
        public decimal? balance_amt { get; set; }
        public decimal? para6 { get; set; }
        public string active1 { get; set; }
        public bool? active2 { get; set; }
    }
}
