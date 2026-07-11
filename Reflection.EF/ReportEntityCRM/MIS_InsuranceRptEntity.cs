using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.CRM.ReportEntityCRM
{

    public class MIS_InsuranceRptEntity
    {
        public DateTime? doc_date { get; set; }
        public string doc_no { get; set; }
        public string transporter { get; set; }

        public string lr_no { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Cover { get; set; }
        public Decimal? bal_insurance { get; set; }
        public Decimal? qty { get; set; }
        public Decimal? inv_value { get; set; }
        public Decimal? tax_value { get; set; }
        public Decimal? total_inv_value { get; set; }
        public Decimal? per_inv_val { get; set; }
        public Decimal? tot_per__inv_val { get; set; }
        public Decimal? undecl_insurance { get; set; }

        public string PartyId { get; set; }
        public string PartyNm { get; set; }

        public string location_Id { get; set; }
        public string LoctnNm { get; set; }
        public string store_code { get; set; }
        public string store_name { get; set; }
        public bool default_storage_loc { get; set; }
        public string comp_code { get; set; }
        public string ItemCode { get; set; }
        public string description { get; set; }
        public string unit_code { get; set; }
        public string sku { get; set; }
        public string sku_desc { get; set; }
        public string Grade { get; set; }

        public string para1 { get; set; }
        public string para2 { get; set; }
        public string para3 { get; set; }
        public string para4 { get; set; }
        public string para5 { get; set; }
        public string Type { get; set; }
        public string value1 { get; set; }
        public string value2 { get; set; }
        public string value3 { get; set; }
        public string value4 { get; set; }
        public string value5 { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string remark { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string doc_type_user { get; set; }
        public string doc_desc_user { get; set; }
        public string EmpId { get; set; }

        public string CstmrItmCod { get; set; }
        public string CstmrItmDesc { get; set; }
        public Decimal? unit_price { get; set; }
        public Decimal? amount { get; set; }


        public string ItemTypeCd { get; set; }
        public string SubItemTpCd { get; set; }
        public string t_status { get; set; }
        public DateTime? post_date { get; set; }
        public string po_no { get; set; }
        public DateTime? po_date { get; set; }
        public string sono { get; set; }
        public DateTime? so_date { get; set; }
        public string mat_con { get; set; }
        public Nullable<int> var1 { get; set; }
        public Decimal? opening { get; set; }
        public Decimal? purchase { get; set; }
        public Decimal? consumption { get; set; }
        public Decimal? ret { get; set; }
        public Decimal? exchange { get; set; }
        public Decimal? sales { get; set; }
        public Decimal? closing { get; set; }


        public Decimal? TotalQty { get; set; }
        public Decimal? TotalAmt { get; set; }

        public Decimal? quantity { get; set; }
        public string wire_type { get; set; }
        public string tip_type { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public Decimal? stock_total { get; set; }
        public Decimal? Reorder { get; set; }


    }
}