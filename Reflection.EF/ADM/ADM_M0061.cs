using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.ADM
{
    public class ADM_M0061 : ObjectBase
    {
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public string doc_no { get; set; }
        public DateTime? doc_date { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string doc_title { get; set; }
        public string obj_type { get; set; }
        public string party_code { get; set; }
        public DateTime? price_date { get; set; }
        public DateTime? validity_date { get; set; }
        public string t_status { get; set; }
        public string active { get; set; }
        public string org_code { get; set; }
        public string group_code { get; set; }
        public string div_code { get; set; }
        public string ref_doc_no { get; set; }
        public string ref_doc_cat { get; set; }
        public string notes { get; set; }
        public string curr_code { get; set; }

        //Scallar
        public string t_display { get; set; }
        public string party_name { get; set; }
        public string org_name { get; set; }
        public string group_name { get; set; }
        public string XDOC_A { get; set; }
    }
    public class ADM_M0061_A 
    {
        public int? id { get; set; }
        public string client { get; set; }
        public string comp_code { get; set; }
        public string doc_no { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public string long_text { get; set; }
        public string item_code_party { get; set; }
        public string sku { get; set; }
        public string unit_code { get; set; }
        public int? lead_time { get; set; }
        public decimal? min_order_qty { get; set; }
        public decimal? max_order_qty { get; set; }
        public decimal? min_order_value { get; set; }
        public decimal? max_order_value { get; set; }
        public string uom_qty { get; set; }
        public string uom_value { get; set; }
        public string uom_price { get; set; }
        public string curr_code { get; set; }
        public decimal? unit_price { get; set; }
        public decimal? max_price { get; set; }
        public decimal? base_price { get; set; }
        public decimal? min_price { get; set; }
        public string active { get; set; }
        public string t_status { get; set; }
        public string tax_code { get; set; }
        public string disc_type { get; set; }
        public decimal? discount { get; set; }
        public string note { get; set; }
        public string ind_revision { get; set; }
        public DateTime? price_date { get; set; }
        public DateTime? validity_date { get; set; }
        public decimal? qty_price { get; set; }
        public decimal? price_qty { get; set; }
        public string price_qty_uom { get; set; }
        public string ref_doc_cat { get; set; }
        public string ref_doc_no { get; set; }
        public int? ref_item_row_id { get; set; }
        public string billing_doc_cat { get; set; }
        public string billing_doc { get; set; }
        public int? billing_item_row_id { get; set; }
        public decimal? freight1 { get; set; }
        public decimal? freight2 { get; set; }
        public decimal? freight3 { get; set; }
        public decimal? duties { get; set; }
        public decimal? other_cost { get; set; }
        public decimal? landed_cost { get; set; }
        public decimal? profit_ratio { get; set; }
        public decimal? profit_value { get; set; }
        public decimal? price_var { get; set; }
        public decimal? price_var_value { get; set; }
        public decimal? price_tol { get; set; }
        public string ind_trade { get; set; }
        public decimal? purchase_price { get; set; }
        public string party_code { get; set; }

        //Scallar
        public bool? ind_sku { get; set; }
        public string curr_code_purchase { get; set; }
        public decimal? exch_rate_pur { get; set; }
        public string party_name { get; set; }
        public string curr_code_leg1 { get; set; }
        public decimal? leg1_percent { get; set; }
        public decimal? freight_rate2 { get; set; }

    }
    public class ADM_M0061_MC : STD_MC_BE
    {
        public List<ADM_M0061> MASTER_ENTITY_LIST { get; set; }
        public List<ADM_M0061_A> ITEM_ENTITY_LIST { get; set; }
        public List<ADM_M0061_A> CATLOG_SETTING_LIST { get; set; }
    }
}
