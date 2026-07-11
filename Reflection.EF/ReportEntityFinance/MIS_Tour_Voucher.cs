using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Finance.ReportEntityFinance
{
    public class MIS_Tour_Voucher
    {
        public string so_code { get; set; }
        public string sg_code { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string doc_no { get; set; }
        public DateTime? doc_date { get; set; }
        public string sales_org { get; set; }
        public string sg_name { get; set; }
        public decimal? grand_total { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public decimal? approved_amt { get; set; }
        public decimal? advance { get; set; }
        public decimal? bal_amount { get; set; }
        public string additional_person { get; set; }
        public DateTime? from_date { get; set; }
        public DateTime? to_date { get; set; }

    }
}
