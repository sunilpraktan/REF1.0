using System;

namespace Reflection.BusinessEntity
{

    public class MIS_SCM_StoreRpt
    {
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
        public string doc_no { get; set; }
        public string Grade { get; set; }

        public string para1 { get; set; }
        public string para2 { get; set; }
        public string para3 { get; set; }
        public string para4 { get; set; }
        public string para5 { get; set; }
        public string CurUnCur { get; set; }
        public string Current { get; set; }
        public string UnCurrent { get; set; }
        public string Type { get; set; }
        public string Import { get; set; }
        public string Local { get; set; }
        public string Mat_Condition { get; set; }
        public string Make { get; set; }
        public string New { get; set; }
        public string Used { get; set; }
        public string New_Used { get; set; }
        public string value1 { get; set; }
        public string value2 { get; set; }
        public string value3 { get; set; }
        public string value4 { get; set; }
        public string value5 { get; set; }

        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string remark { get; set; }

        public Decimal? OpenQty { get; set; }
        public Decimal? OpenRate { get; set; }
        public Decimal? OpenValue { get; set; }

        public Decimal? PurQty { get; set; }
        public Decimal? PurRate { get; set; }
        public Decimal? PurValue { get; set; }

        public Decimal? IssueQty { get; set; }
        public Decimal? IssueRate { get; set; }
        public Decimal? IssueValue { get; set; }

        public Decimal? RecieptQty { get; set; }
        public Decimal? RecieptRate { get; set; }
        public Decimal? RecieptValue { get; set; }

        public Decimal? DebitQty { get; set; }
        public Decimal? DebitRate { get; set; }
        public Decimal? DebitValue { get; set; }

        public Decimal? SalesQty { get; set; }
        public Decimal? SalesRate { get; set; }
        public Decimal? SalesValue { get; set; }

        public Decimal? ShortageQty { get; set; }
        public Decimal? ShortageRate { get; set; }
        public Decimal? ShortageValue { get; set; }

        public Decimal? ClosingQty { get; set; }
        public Decimal? ClosingRate { get; set; }
        public Decimal? ClosingValue { get; set; }

        public Decimal? RejQty { get; set; }
        public Decimal? RejRate { get; set; }
        public Decimal? RejValue { get; set; }

        public Decimal? ProdQty { get; set; }
        public Decimal? ProdRate { get; set; }
        public Decimal? ProdValue { get; set; }

        public Decimal? SalesRtnQty { get; set; }
        public Decimal? SalesRtnRate { get; set; }
        public Decimal? SalesRtnValue { get; set; }

        public Decimal? FreeSalesQty { get; set; }
        public Decimal? FreeSalesRate { get; set; }
        public Decimal? FreeSalesValue { get; set; }

        public Decimal? PurRtnQty { get; set; }
        public Decimal? PurRtnRate { get; set; }
        public Decimal? PurRtnValue { get; set; }

        public Decimal? ProfitQty { get; set; }
        public Decimal? ProfitRate { get; set; }
        public Decimal? ProfitValue { get; set; }

        public string CatCode { get; set; }
        public string SubCatCode { get; set; }


        public DateTime? doc_date { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string doc_type_user { get; set; }
        public string doc_desc_user { get; set; }
        public string EmpId { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string CstmrItmCod { get; set; }
        public string CstmrItmDesc { get; set; }
        public Decimal? qty { get; set; }
        public Decimal? unit_price { get; set; }
        public Decimal? amount { get; set; }


        public string ItemTypeCd { get; set; }
        public string SubItemTpCd { get; set; }
        public string t_status { get; set; }
        public string post_date { get; set; }
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

        //Acc to Machine Consumption report Entity

        public Decimal? ConsmpLXQty { get; set; }
        public Decimal? ConsmpLXAmt { get; set; }
        public Decimal? ConsmpPMQty { get; set; }
        public Decimal? ConsmpPMAmt { get; set; }
        public Decimal? ConsmpTotalQty { get; set; }
        public Decimal? ConsmpRate { get; set; }
        public Decimal? ConsmpTotalAmt { get; set; }

        public Decimal? ShopRtnLXQty { get; set; }
        public Decimal? ShopRtnLXAmt { get; set; }
        public Decimal? ShopRtnPMQty { get; set; }
        public Decimal? ShopRtnPMAmt { get; set; }
        public Decimal? ShopRtnTotalQty { get; set; }
        public Decimal? ShopRtnRate { get; set; }
        public Decimal? ShopRtnTotalAmt { get; set; }

        public Decimal? TotalQty { get; set; }
        public Decimal? TotalAmt { get; set; }

        public Decimal? quantity { get; set; }
        public string wire_type { get; set; }
        public string tip_type { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public Decimal? stock_total { get; set; }
        public Decimal? Reorder { get; set; }
        public Decimal? rate { get; set; }
        public Decimal? value { get; set; }

        public Decimal? prebook_qty { get; set; }
        public Decimal? phy_count_value { get; set; }
        public Decimal? book_value { get; set; }

        public string make { get; set; }
        public string type { get; set; }
        public Decimal? qty_unit_entry { get; set; }
        public Decimal? qty_diff { get; set; }
        public Decimal? shortage_access { get; set; }
        public string entry_unit { get; set; }
        public Decimal? StockUnt { get; set; }




    }

}
