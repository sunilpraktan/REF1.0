using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.CRM
{
    public partial class GetItemDetailsEntity
    {
        //Unit Price Details
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public string sku { get; set; }
        public string sku_desc { get; set; }
        public string Grade { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public string Make { get; set; }
        public string Type { get; set; }
        public string mat_condition { get; set; }
        public string sono { get; set; }
        public Nullable<System.DateTime> sodate { get; set; }
        public Nullable<decimal> unit_price { get; set; }
        public Nullable<decimal> so_qty { get; set; }
        public string Source { get; set; }

        //QFR Details
        public string quality_feedback_no { get; set; }
        public Nullable<System.DateTime> quality_feedback_date { get; set; }
        public string cmplnt_RecvBy_cd { get; set; }
        public string cust_complaint { get; set; }
        public string observation_test { get; set; }
        public string result_of_test { get; set; }

        //Dispatch Detail
        public string delivery_no { get; set; }
        public Nullable<System.DateTime> delivery_date { get; set; }
        public Nullable<decimal> del_qty { get; set; }
        public Nullable<decimal> Pending_qty { get; set; }

        //Projected Dispatch
        public string sch_no { get; set; }
        public Nullable<decimal> confirm_qty { get; set; }
        public Nullable<System.DateTime> sch_date { get; set; }
        public Nullable<System.DateTime> confirm_date { get; set; }
        public string Disp_Done { get; set; }

        public int line_id { get; set; }
        public string unit_code { get; set; }
        public bool active { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string ref_doc_no { get; set; }
        public Nullable<System.DateTime> ref_doc_date { get; set; }
        public string ref_doc_type { get; set; }
        public string notify_party { get; set; }
       
      
      
    }
}
