using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessEntity.CustomerRelation
{
    public class RptBatchDetail
    {
        public string bill_doc { get; set; }
        public string doc_no { get; set; }
        public DateTime? doc_date { get; set; }
        public string batch_no { get; set; }
        public string grade { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Ink { get; set; }
        public string Ild { get; set; }
        public string batch_inner { get; set; }
        public string batch_label { get; set; }
        public decimal? label_qty { get; set; }
        public string machinecode { get; set; }
        public DateTime? prod_dt { get; set; }
        public decimal? inner_qty { get; set; }
        public string inner_unit { get; set; }
        public string label_unit { get; set; }
        public bool? check { get; set; }
        public decimal? tot_qty { get; set; }
        public decimal? qty { get; set; }
        public decimal? net_wt { get; set; }
        public decimal? gross_wt { get; set; }
        public string cf_agent_code { get; set; }
        public string cf_party { get; set; }
        public string cf_address { get; set; }
        public string board_line { get; set; }
        public string cf_fax { get; set; }
        public string cf_mobile { get; set; }
        public string cf_email { get; set; }
        public string transporter { get; set; }
        public string lr_no { get; set; }
        public DateTime? lr_date { get; set; }
        public string yr_ref_no { get; set; }
        public DateTime? yr_ref_date { get; set; }
        public string trans_mode { get; set; }
        public string ref_doc_no { get; set; }
        public DateTime? ref_doc_date { get; set; }

    }
}
