using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.BusinessEntity.CustomerRelation;

namespace Reflection.BusinessEntity
{
    public class InquiryOppourtinityHand
    {
        public string Inq_sono { get; set; }
        public DateTime? Inq_sodate { get; set; }
        public string Inq_doc_type { get; set; }
        public string Inq_doc_cat { get; set; }
        public string Inq_PartyId { get; set; }
        public string Inq_party_name { get; set; }
        public string Inq_location_Id { get; set; }
        public string Inq_comp_code { get; set; }
        public string Inq_EmpId { get; set; }
        public string Inq_ItemCode { get; set; }
        public string Inq_Description { get; set; }
        public decimal? Inq_quantity { get; set; }
        public decimal? Inq_unit_price { get; set; }
        public decimal? Inq_amount { get; set; }
        public string Inq_buyer_name { get; set; }
        public string Inq_unit_code { get; set; }
        public string Inq_seller_name { get; set; }
        public string Inq_ref_doc_no { get; set; }
        public string Inq_PartyNm { get; set; }
        public decimal? Inq_tax_amount { get; set; }
        public decimal? Inq_sub_total { get; set; }
        public decimal? Inq_roundup_total { get; set; }
    }
}
