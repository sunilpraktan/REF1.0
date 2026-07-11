using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessEntity.SCM
{
    public class MIS_SCM_Rpt
    {
        public string delivery_no { get; set; }
        public DateTime? delivery_date { get; set; }
        public string delivery_type { get; set; }
        public string doc_type { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string ItemCode { get; set; }
        public string Item_desc { get; set; }
        public decimal? qty { get; set; }
        public decimal? net_price { get; set; }
        public decimal? net_value { get; set; }
        public int? bill_address_id { get; set; }
        public string billing_add { get; set; }
        public int? del_address { get; set; }
        public string delivery_add { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string rec_plant { get; set; }
        public string receiving_plant { get; set; }
        public string location_Id { get; set; }
        public string suply_plant { get; set; }
        public string doc_no { get; set; }
        public DateTime? doc_date { get; set; }
        public string mov_tp { get; set; }
        public string mov_name { get; set; }
        public string tranp_mode { get; set; }
        public string po_no { get; set; }
        public DateTime? po_date { get; set; }
        public string vendor { get; set; }
        public string issued_to_nm { get; set; }
        public string pod_no { get; set; }
        public decimal? weight { get; set; }
        public string location { get; set; }
        public string material_order_for { get; set; }
        public string service_provider_id { get; set; }
        public string service_provider_nm { get; set; }
        public string store_code { get; set; }
        public string store_name { get; set; }
        public decimal? stock_total { get; set; }
        public decimal? stock_reserve { get; set; }
        public string stock_category { get; set; }
        public string comp_code { get; set; }
        public string unit_code { get; set; }
        public string sku { get; set; }
        public string sku_desc { get; set; }
        public string notes { get; set; }
        public string pack_rem { get; set; }
        public string rec_info { get; set; }
        public DateTime? pod_date { get; set; }
        public string project_name { get; set; }
        public string ref_doc_no { get; set; }
        public string batch_no { get; set; }
    }
}
