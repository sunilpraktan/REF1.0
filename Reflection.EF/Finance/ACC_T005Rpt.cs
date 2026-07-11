using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Finance
{
   public class ACC_T005Rpt
    {
        public string Inquiry_no { get; set; }
        public string doc_no { get; set; }

        public Nullable<System.DateTime> doc_date;
        public decimal? Inquiry_amt { get; set; }
        public decimal? Inquiry_payment { get; set; }
        public string Lead { get; set; }
        public string Quotation_no { get; set; }
        public decimal? Quotation_amt { get; set; }
        public decimal? Quotation_payment { get; set; }
        public string Quotation_status { get; set; }
        public string So_no { get; set; }
        public decimal? So_amt { get; set; }
        public decimal? So_payment { get; set; }
        public string So_status { get; set; }
        public string Sales_person { get; set; }
        public string Party_id { get; set; }
        public string Party_name { get; set; }

    }
}
