using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.SCM.ReportEntitySCM
{
    public class MIS_RptFinStatement
    {
        public int day { get; set; }
        public Decimal? ProdLXQty { get; set; }
        public Decimal? ProdPMQty { get; set; }

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


        //FG Report
        public Decimal? SampleQty { get; set; }
        public Decimal? SampleRate { get; set; }
        public Decimal? SampleValue { get; set; }

        public Decimal? DespatchQty { get; set; }
        public Decimal? DespatchRate { get; set; }
        public Decimal? DespatchValue { get; set; }

        public Decimal? StockRtnQty { get; set; }
        public Decimal? StockRtnRate { get; set; }
        public Decimal? StockRtnValue { get; set; }

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
        public string wire_size { get; set; }
        public string wire_size_id { get; set; }
        public string tip_type { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public Decimal? stock_total { get; set; }
        public Decimal? Reorder { get; set; }

        public Decimal? OpenQtyUptodate { get; set; }
        public Decimal? PurQtyUptodate { get; set; }
        public Decimal? SalesQtyUptodate { get; set; }
        public Decimal? IssueQtyUptodate { get; set; }
        public Decimal? RecieptQtyUptodate { get; set; }

        public Decimal? OpenValueUptodate { get; set; }
        public Decimal? PurchaseValueUptodate { get; set; }
        public Decimal? SalesValueUptodate { get; set; }
        public Decimal? IssueValueUptodate { get; set; }
        public Decimal? RecieptValueUptodate { get; set; }

        public Decimal? ProdQtyUptodate { get; set; }
        public Decimal? ProdRateUptodate { get; set; }
        public Decimal? ProdValueUptodate { get; set; }

        public Decimal? SalesRtnQtyUptodate { get; set; }
        public Decimal? SalesRtnRateUptodate { get; set; }
        public Decimal? SalesRtnValueUptodate { get; set; }

        public Decimal? SampleQtyUptodate { get; set; }
        public Decimal? SampleRateUptodate { get; set; }
        public Decimal? SampleValueUptodate { get; set; }

        public Decimal? ShortageQtyUptodate { get; set; }
        public Decimal? ShortageRateUptodate { get; set; }
        public Decimal? ShortageValueUptodate { get; set; }

        public Decimal? ExcessShortageUptodate { get; set; }



    }
    public class UptoDateFG
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


        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string remark { get; set; }

        public Decimal? OpenQty { get; set; }
        public Decimal? OpenRate { get; set; }
        public Decimal? OpenValue { get; set; }

        public Decimal? ProdQty { get; set; }
        public Decimal? ProdRate { get; set; }
        public Decimal? ProdValue { get; set; }

        public Decimal? SalesRtnQty { get; set; }
        public Decimal? SalesRtnRate { get; set; }
        public Decimal? SalesRtnValue { get; set; }

        public Decimal? SalesQty { get; set; }
        public Decimal? SalesRate { get; set; }
        public Decimal? SalesValue { get; set; }

        public Decimal? ClosingQty { get; set; }
        public Decimal? ClosingRate { get; set; }
        public Decimal? ClosingValue { get; set; }


        public Decimal? SampleQty { get; set; }
        public Decimal? SampleRate { get; set; }
        public Decimal? SampleValue { get; set; }

        public Decimal? ShortageQty { get; set; }
        public Decimal? ShortageRate { get; set; }
        public Decimal? ShortageValue { get; set; }


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
        public string wire_size { get; set; }
        public string wire_size_id { get; set; }
        public string tip_type { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }


    }
    public class UptoDateTotal
    {
        public string XmlDataDocument_UptoDateFG { get; set; }
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


        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string remark { get; set; }


        private Decimal? _UptoDateOpenQty;
        public Decimal? UptoDateOpenQty
        {
            get { return _UptoDateOpenQty; }
            set
            {
                _UptoDateOpenQty = value;
                RaisePropertyChanged("UptoDateOpenQty");
            }
        }

        #region INotifyPropertyChanged Interface Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion

        private Decimal? _UptoDateOpenValue;
        public Decimal? UptoDateOpenValue
        {
            get { return _UptoDateOpenValue; }
            set
            {
                _UptoDateOpenValue = value;
                RaisePropertyChanged("UptoDateOpenValue");
            }
        }

        private Decimal? _UptoDateProdQty;
        public Decimal? UptoDateProdQty
        {
            get { return _UptoDateProdQty; }
            set
            {
                _UptoDateProdQty = value;
                RaisePropertyChanged("UptoDateProdQty");
            }
        }
        private Decimal? _UptoDateProdValue;
        public Decimal? UptoDateProdValue
        {
            get { return _UptoDateProdValue; }
            set
            {
                _UptoDateProdValue = value;
                RaisePropertyChanged("UptoDateProdValue");
            }
        }

        private Decimal? _UptoDateSalesRtnQty;
        public Decimal? UptoDateSalesRtnQty
        {
            get { return _UptoDateSalesRtnQty; }
            set
            {
                _UptoDateSalesRtnQty = value;
                RaisePropertyChanged("UptoDateSalesRtnQty");
            }
        }
        private Decimal? _UptoDateSalesRtnValue;
        public Decimal? UptoDateSalesRtnValue
        {
            get { return _UptoDateSalesRtnValue; }
            set
            {
                _UptoDateSalesRtnValue = value;
                RaisePropertyChanged("UptoDateSalesRtnValue");
            }
        }

        private Decimal? _UptoDateSalesQty;
        public Decimal? UptoDateSalesQty
        {
            get { return _UptoDateSalesQty; }
            set
            {
                _UptoDateSalesQty = value;
                RaisePropertyChanged("UptoDateSalesQty");
            }
        }
        private Decimal? _UptoDateSalesValue;
        public Decimal? UptoDateSalesValue
        {
            get { return _UptoDateSalesValue; }
            set
            {
                _UptoDateSalesValue = value;
                RaisePropertyChanged("UptoDateSalesValue");
            }
        }

        private Decimal? _UptoDateClosingQty;
        public Decimal? UptoDateClosingQty
        {
            get { return _UptoDateClosingQty; }
            set
            {
                _UptoDateClosingQty = value;
                RaisePropertyChanged("UptoDateClosingQty");
            }
        }

        private Decimal? _UptoDateClosingValue;
        public Decimal? UptoDateClosingValue
        {
            get { return _UptoDateClosingValue; }
            set
            {
                _UptoDateClosingValue = value;
                RaisePropertyChanged("UptoDateClosingValue");
            }
        }
        private Decimal? _UptoDateSampleQty;
        public Decimal? UptoDateSampleQty
        {
            get { return _UptoDateSampleQty; }
            set
            {
                _UptoDateSampleQty = value;
                RaisePropertyChanged("UptoDateSampleQty");
            }
        }
        private Decimal? _UptoDateSampleValue;
        public Decimal? UptoDateSampleValue
        {
            get { return _UptoDateSampleValue; }
            set
            {
                _UptoDateSampleValue = value;
                RaisePropertyChanged("UptoDateSampleValue");
            }
        }
        private Decimal? _UptoDateShortageQty;
        public Decimal? UptoDateShortageQty
        {
            get { return _UptoDateShortageQty; }
            set
            {
                _UptoDateShortageQty = value;
                RaisePropertyChanged("UptoDateShortageQty");
            }
        }
        private Decimal? _UptoDateShortageValue;
        public Decimal? UptoDateShortageValue
        {
            get { return _UptoDateShortageValue; }
            set
            {
                _UptoDateShortageValue = value;
                RaisePropertyChanged("UptoDateShortageValue");
            }
        }


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
        public string wire_size { get; set; }
        public string wire_size_id { get; set; }
        public string tip_type { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }


    }
    public class PreviousUptoDateFG
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


        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string remark { get; set; }

        public Decimal? OpenQty { get; set; }
        public Decimal? OpenRate { get; set; }
        public Decimal? OpenValue { get; set; }

        public Decimal? ProdQty { get; set; }
        public Decimal? ProdRate { get; set; }
        public Decimal? ProdValue { get; set; }

        public Decimal? SalesRtnQty { get; set; }
        public Decimal? SalesRtnRate { get; set; }
        public Decimal? SalesRtnValue { get; set; }

        public Decimal? SalesQty { get; set; }
        public Decimal? SalesRate { get; set; }
        public Decimal? SalesValue { get; set; }

        public Decimal? ClosingQty { get; set; }
        public Decimal? ClosingRate { get; set; }
        public Decimal? ClosingValue { get; set; }


        public Decimal? SampleQty { get; set; }
        public Decimal? SampleRate { get; set; }
        public Decimal? SampleValue { get; set; }

        public Decimal? ShortageQty { get; set; }
        public Decimal? ShortageRate { get; set; }
        public Decimal? ShortageValue { get; set; }


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
        public string wire_size { get; set; }
        public string wire_size_id { get; set; }
        public string tip_type { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }


    }
    public class UptoDateTS
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
        public string Type { get; set; }

        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string remark { get; set; }

        public Decimal? OpenQty { get; set; }
        public Decimal? OpenRate { get; set; }
        public Decimal? OpenValue { get; set; }

        public Decimal? PurQty { get; set; }
        public Decimal? PurRate { get; set; }
        public Decimal? PurValue { get; set; }

        public Decimal? DebitQty { get; set; }
        public Decimal? DebitRate { get; set; }
        public Decimal? DebitValue { get; set; }

        public Decimal? IssueQty { get; set; }
        public Decimal? IssueRate { get; set; }
        public Decimal? IssueValue { get; set; }

        public Decimal? ReceiptQty { get; set; }
        public Decimal? ReceiptRate { get; set; }
        public Decimal? ReceiptValue { get; set; }

        public Decimal? SalesQty { get; set; }
        public Decimal? SalesRate { get; set; }
        public Decimal? SalesValue { get; set; }

        public Decimal? ShortageQty { get; set; }
        public Decimal? ShortageRate { get; set; }
        public Decimal? ShortageValue { get; set; }

        public Decimal? ClosingQty { get; set; }
        public Decimal? ClosingRate { get; set; }
        public Decimal? ClosingValue { get; set; }

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
        public string XmlDataDocument_UptoDateFG { get; set; }


    }
    public class PreviousUptoDateTS
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


        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string remark { get; set; }

        public Decimal? OpenQty { get; set; }
        public Decimal? OpenRate { get; set; }
        public Decimal? OpenValue { get; set; }

        public Decimal? PurQty { get; set; }
        public Decimal? PurRate { get; set; }
        public Decimal? PurValue { get; set; }

        public Decimal? DebitQty { get; set; }
        public Decimal? DebitRate { get; set; }
        public Decimal? DebitValue { get; set; }

        public Decimal? IssueQty { get; set; }
        public Decimal? IssueRate { get; set; }
        public Decimal? IssueValue { get; set; }

        public Decimal? ReceiptQty { get; set; }
        public Decimal? ReceiptRate { get; set; }
        public Decimal? ReceiptValue { get; set; }

        public Decimal? SalesQty { get; set; }
        public Decimal? SalesRate { get; set; }
        public Decimal? SalesValue { get; set; }

        public Decimal? ShortageQty { get; set; }
        public Decimal? ShortageRate { get; set; }
        public Decimal? ShortageValue { get; set; }

        public Decimal? ClosingQty { get; set; }
        public Decimal? ClosingRate { get; set; }
        public Decimal? ClosingValue { get; set; }

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
        public string XmlDataDocument_UptoDateFG { get; set; }

    }
    public class UptoDateTotalTS
    {
        public string XmlDataDocument_UptoDateFG { get; set; }
        public string XmlDataDocument_dsUptoDateImp { get; set; }
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

        public string ImportLocalCode { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string remark { get; set; }


        private Decimal? _UptoDateOpenQty;
        public Decimal? UptoDateOpenQty
        {
            get { return _UptoDateOpenQty; }
            set
            {
                _UptoDateOpenQty = value;
                RaisePropertyChanged("UptoDateOpenQty");
            }
        }

        #region INotifyPropertyChanged Interface Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion

        private Decimal? _UptoDateOpenValue;
        public Decimal? UptoDateOpenValue
        {
            get { return _UptoDateOpenValue; }
            set
            {
                _UptoDateOpenValue = value;
                RaisePropertyChanged("UptoDateOpenValue");
            }
        }

        private Decimal? _UptoDatePurQty;
        public Decimal? UptoDatePurQty
        {
            get { return _UptoDatePurQty; }
            set
            {
                _UptoDatePurQty = value;
                RaisePropertyChanged("UptoDatePurQty");
            }
        }

        private Decimal? _UptoDatePurValue;
        public Decimal? UptoDatePurValue
        {
            get { return _UptoDatePurValue; }
            set
            {
                _UptoDatePurValue = value;
                RaisePropertyChanged("UptoDatePurValue");
            }
        }

        private Decimal? _UptoDateDebitQty;
        public Decimal? UptoDateDebitQty
        {
            get { return _UptoDateDebitQty; }
            set
            {
                _UptoDateDebitQty = value;
                RaisePropertyChanged("UptoDateDebitQty");
            }
        }
        private Decimal? _UptoDateDebitValue;
        public Decimal? UptoDateDebitValue
        {
            get { return _UptoDateDebitValue; }
            set
            {
                _UptoDateDebitValue = value;
                RaisePropertyChanged("UptoDateDebitValue");
            }
        }

        private Decimal? _UptoDateIssueQty;
        public Decimal? UptoDateIssueQty
        {
            get { return _UptoDateIssueQty; }
            set
            {
                _UptoDateIssueQty = value;
                RaisePropertyChanged("UptoDateIssueQty");
            }
        }

        private Decimal? _UptoDateIssueValue;
        public Decimal? UptoDateIssueValue
        {
            get { return _UptoDateIssueValue; }
            set
            {
                _UptoDateIssueValue = value;
                RaisePropertyChanged("UptoDateIssueValue");
            }
        }

        private Decimal? _UptoDateRecieptQty;
        public Decimal? UptoDateRecieptQty
        {
            get { return _UptoDateRecieptQty; }
            set
            {
                _UptoDateRecieptQty = value;
                RaisePropertyChanged("UptoDateRecieptQty");
            }
        }
        private Decimal? _UptoDateRecieptValue;
        public Decimal? UptoDateRecieptValue
        {
            get { return _UptoDateRecieptValue; }
            set
            {
                _UptoDateRecieptValue = value;
                RaisePropertyChanged("UptoDateRecieptValue");
            }
        }
        private Decimal? _UptoDateSalesRtnQty;
        public Decimal? UptoDateSalesRtnQty
        {
            get { return _UptoDateSalesRtnQty; }
            set
            {
                _UptoDateSalesRtnQty = value;
                RaisePropertyChanged("UptoDateSalesRtnQty");
            }
        }
        private Decimal? _UptoDateSalesRtnValue;
        public Decimal? UptoDateSalesRtnValue
        {
            get { return _UptoDateSalesRtnValue; }
            set
            {
                _UptoDateSalesRtnValue = value;
                RaisePropertyChanged("UptoDateSalesRtnValue");
            }
        }

        private Decimal? _UptoDateSalesQty;
        public Decimal? UptoDateSalesQty
        {
            get { return _UptoDateSalesQty; }
            set
            {
                _UptoDateSalesQty = value;
                RaisePropertyChanged("UptoDateSalesQty");
            }
        }
        private Decimal? _UptoDateSalesValue;
        public Decimal? UptoDateSalesValue
        {
            get { return _UptoDateSalesValue; }
            set
            {
                _UptoDateSalesValue = value;
                RaisePropertyChanged("UptoDateSalesValue");
            }
        }

        private Decimal? _UptoDateShortageQty;
        public Decimal? UptoDateShortageQty
        {
            get { return _UptoDateShortageQty; }
            set
            {
                _UptoDateShortageQty = value;
                RaisePropertyChanged("UptoDateShortageQty");
            }
        }
        private Decimal? _UptoDateShortageValue;
        public Decimal? UptoDateShortageValue
        {
            get { return _UptoDateShortageValue; }
            set
            {
                _UptoDateShortageValue = value;
                RaisePropertyChanged("UptoDateShortageValue");
            }
        }

        private Decimal? _UptoDateClosingQty;
        public Decimal? UptoDateClosingQty
        {
            get { return _UptoDateClosingQty; }
            set
            {
                _UptoDateClosingQty = value;
                RaisePropertyChanged("UptoDateClosingQty");
            }
        }

        private Decimal? _UptoDateClosingValue;
        public Decimal? UptoDateClosingValue
        {
            get { return _UptoDateClosingValue; }
            set
            {
                _UptoDateClosingValue = value;
                RaisePropertyChanged("UptoDateClosingValue");
            }
        }



        private Decimal? _UptoDateOpenQtyLoc;
        public Decimal? UptoDateOpenQtyLoc
        {
            get { return _UptoDateOpenQtyLoc; }
            set
            {
                _UptoDateOpenQtyLoc = value;
                RaisePropertyChanged("UptoDateOpenQtyLoc");
            }
        }

        private Decimal? _UptoDateOpenQtyImp;
        public Decimal? UptoDateOpenQtyImp
        {
            get { return _UptoDateOpenQtyImp; }
            set
            {
                _UptoDateOpenQtyImp = value;
                RaisePropertyChanged("UptoDateOpenQtyImp");
            }
        }

        private Decimal? _UptoDateOpenValueLoc;
        public Decimal? UptoDateOpenValueLoc
        {
            get { return _UptoDateOpenValueLoc; }
            set
            {
                _UptoDateOpenValueLoc = value;
                RaisePropertyChanged("UptoDateOpenValueLoc");
            }
        }
        private Decimal? _UptoDateOpenValueImp;
        public Decimal? UptoDateOpenValueImp
        {
            get { return _UptoDateOpenValueImp; }
            set
            {
                _UptoDateOpenValueImp = value;
                RaisePropertyChanged("UptoDateOpenValueImp");
            }
        }

        private Decimal? _UptoDatePurQtyLoc;
        public Decimal? UptoDatePurQtyLoc
        {
            get { return _UptoDatePurQtyLoc; }
            set
            {
                _UptoDatePurQtyLoc = value;
                RaisePropertyChanged("UptoDatePurQtyLoc");
            }
        }
        private Decimal? _UptoDatePurQtyImp;
        public Decimal? UptoDatePurQtyImp
        {
            get { return _UptoDatePurQtyImp; }
            set
            {
                _UptoDatePurQtyImp = value;
                RaisePropertyChanged("UptoDatePurQtyImp");
            }
        }
        private Decimal? _UptoDatePurValueLoc;
        public Decimal? UptoDatePurValueLoc
        {
            get { return _UptoDatePurValueLoc; }
            set
            {
                _UptoDatePurValueLoc = value;
                RaisePropertyChanged("UptoDatePurValueLoc");
            }
        }

        private Decimal? _UptoDatePurValueImp;
        public Decimal? UptoDatePurValueImp
        {
            get { return _UptoDatePurValueImp; }
            set
            {
                _UptoDatePurValueImp = value;
                RaisePropertyChanged("UptoDatePurValueImp");
            }
        }

        private Decimal? _UptoDateDebitQtyLoc;
        public Decimal? UptoDateDebitQtyLoc
        {
            get { return _UptoDateDebitQtyLoc; }
            set
            {
                _UptoDateDebitQtyLoc = value;
                RaisePropertyChanged("UptoDateDebitQtyLoc");
            }
        }
        private Decimal? _UptoDateDebitQtyImp;
        public Decimal? UptoDateDebitQtyImp
        {
            get { return _UptoDateDebitQtyImp; }
            set
            {
                _UptoDateDebitQtyImp = value;
                RaisePropertyChanged("UptoDateDebitQtyImp");
            }
        }
        private Decimal? _UptoDateDebitValueLoc;
        public Decimal? UptoDateDebitValueLoc
        {
            get { return _UptoDateDebitValueLoc; }
            set
            {
                _UptoDateDebitValueLoc = value;
                RaisePropertyChanged("UptoDateDebitValueLoc");
            }
        }

        private Decimal? _UptoDateDebitValueImp;
        public Decimal? UptoDateDebitValueImp
        {
            get { return _UptoDateDebitValueImp; }
            set
            {
                _UptoDateDebitValueImp = value;
                RaisePropertyChanged("UptoDateDebitValueImp");
            }
        }

        private Decimal? _UptoDateIssueQtyLoc;
        public Decimal? UptoDateIssueQtyLoc
        {
            get { return _UptoDateIssueQtyLoc; }
            set
            {
                _UptoDateIssueQtyLoc = value;
                RaisePropertyChanged("UptoDateIssueQtyLoc");
            }
        }
        private Decimal? _UptoDateIssueQtyImp;
        public Decimal? UptoDateIssueQtyImp
        {
            get { return _UptoDateIssueQtyImp; }
            set
            {
                _UptoDateIssueQtyImp = value;
                RaisePropertyChanged("UptoDateIssueQtyImp");
            }
        }

        private Decimal? _UptoDateIssueValueLoc;
        public Decimal? UptoDateIssueValueLoc
        {
            get { return _UptoDateIssueValueLoc; }
            set
            {
                _UptoDateIssueValueLoc = value;
                RaisePropertyChanged("UptoDateIssueValueLoc");
            }
        }

        private Decimal? _UptoDateIssueValueImp;
        public Decimal? UptoDateIssueValueImp
        {
            get { return _UptoDateIssueValueImp; }
            set
            {
                _UptoDateIssueValueImp = value;
                RaisePropertyChanged("UptoDateIssueValueImp");
            }
        }

        private Decimal? _UptoDateRecieptQtyLoc;
        public Decimal? UptoDateRecieptQtyLoc
        {
            get { return _UptoDateRecieptQtyLoc; }
            set
            {
                _UptoDateRecieptQtyLoc = value;
                RaisePropertyChanged("UptoDateRecieptQtyLoc");
            }
        }
        private Decimal? _UptoDateRecieptValueLoc;
        public Decimal? UptoDateRecieptValueLoc
        {
            get { return _UptoDateRecieptValueLoc; }
            set
            {
                _UptoDateRecieptValueLoc = value;
                RaisePropertyChanged("UptoDateRecieptValueLoc");
            }
        }

        private Decimal? _UptoDateRecieptQtyImp;
        public Decimal? UptoDateRecieptQtyImp
        {
            get { return _UptoDateRecieptQtyImp; }
            set
            {
                _UptoDateRecieptQtyImp = value;
                RaisePropertyChanged("UptoDateRecieptQtyImp");
            }
        }
        private Decimal? _UptoDateRecieptValueImp;
        public Decimal? UptoDateRecieptValueImp
        {
            get { return _UptoDateRecieptValueImp; }
            set
            {
                _UptoDateRecieptValueImp = value;
                RaisePropertyChanged("UptoDateRecieptValueImp");
            }
        }

        private Decimal? _UptoDateSalesRtnQtyLoc;
        public Decimal? UptoDateSalesRtnQtyLoc
        {
            get { return _UptoDateSalesRtnQtyLoc; }
            set
            {
                _UptoDateSalesRtnQtyLoc = value;
                RaisePropertyChanged("UptoDateSalesRtnQtyLoc");
            }
        }

        private Decimal? _UptoDateSalesRtnValueLoc;
        public Decimal? UptoDateSalesRtnValueLoc
        {
            get { return _UptoDateSalesRtnValueLoc; }
            set
            {
                _UptoDateSalesRtnValueLoc = value;
                RaisePropertyChanged("UptoDateSalesRtnValueLoc");
            }
        }
        private Decimal? _UptoDateSalesRtnQtyImp;
        public Decimal? UptoDateSalesRtnQtyImp
        {
            get { return _UptoDateSalesRtnQtyImp; }
            set
            {
                _UptoDateSalesRtnQtyImp = value;
                RaisePropertyChanged("UptoDateSalesRtnQtyImp");
            }
        }
        private Decimal? _UptoDateSalesRtnValueImp;
        public Decimal? UptoDateSalesRtnValueImp
        {
            get { return _UptoDateSalesRtnValueImp; }
            set
            {
                _UptoDateSalesRtnValueImp = value;
                RaisePropertyChanged("UptoDateSalesRtnValueImp");
            }
        }

        private Decimal? _UptoDateSalesQtyLoc;
        public Decimal? UptoDateSalesQtyLoc
        {
            get { return _UptoDateSalesQtyLoc; }
            set
            {
                _UptoDateSalesQtyLoc = value;
                RaisePropertyChanged("UptoDateSalesQtyLoc");
            }
        }
        private Decimal? _UptoDateSalesQtyImp;
        public Decimal? UptoDateSalesQtyImp
        {
            get { return _UptoDateSalesQtyImp; }
            set
            {
                _UptoDateSalesQtyImp = value;
                RaisePropertyChanged("UptoDateSalesQtyImp");
            }
        }

        private Decimal? _UptoDateSalesValueLoc;
        public Decimal? UptoDateSalesValueLoc
        {
            get { return _UptoDateSalesValueLoc; }
            set
            {
                _UptoDateSalesValueLoc = value;
                RaisePropertyChanged("UptoDateSalesValueLoc");
            }
        }

        private Decimal? _UptoDateSalesValueImp;
        public Decimal? UptoDateSalesValueImp
        {
            get { return _UptoDateSalesValueImp; }
            set
            {
                _UptoDateSalesValueImp = value;
                RaisePropertyChanged("UptoDateSalesValueImp");
            }
        }

        private Decimal? _UptoDateShortageQtyLoc;
        public Decimal? UptoDateShortageQtyLoc
        {
            get { return _UptoDateShortageQtyLoc; }
            set
            {
                _UptoDateShortageQtyLoc = value;
                RaisePropertyChanged("UptoDateShortageQtyLoc");
            }
        }

        private Decimal? _UptoDateShortageQtyImp;
        public Decimal? UptoDateShortageQtyImp
        {
            get { return _UptoDateShortageQtyImp; }
            set
            {
                _UptoDateShortageQtyImp = value;
                RaisePropertyChanged("UptoDateShortageQtyImp");
            }
        }


        private Decimal? _UptoDateShortageValueLoc;
        public Decimal? UptoDateShortageValueLoc
        {
            get { return _UptoDateShortageValueLoc; }
            set
            {
                _UptoDateShortageValueLoc = value;
                RaisePropertyChanged("UptoDateShortageValueLoc");
            }
        }

        private Decimal? _UptoDateShortageValueImp;
        public Decimal? UptoDateShortageValueImp
        {
            get { return _UptoDateShortageValueImp; }
            set
            {
                _UptoDateShortageValueImp = value;
                RaisePropertyChanged("UptoDateShortageValueImp");
            }
        }

        private Decimal? _UptoDateClosingQtyLoc;
        public Decimal? UptoDateClosingQtyLoc
        {
            get { return _UptoDateClosingQtyLoc; }
            set
            {
                _UptoDateClosingQtyLoc = value;
                RaisePropertyChanged("UptoDateClosingQtyLoc");
            }
        }

        private Decimal? _UptoDateClosingQtyImp;
        public Decimal? UptoDateClosingQtyImp
        {
            get { return _UptoDateClosingQtyImp; }
            set
            {
                _UptoDateClosingQtyImp = value;
                RaisePropertyChanged("UptoDateClosingQtyImp");
            }
        }



        private Decimal? _UptoDateClosingValueLoc;
        public Decimal? UptoDateClosingValueLoc
        {
            get { return _UptoDateClosingValueLoc; }
            set
            {
                _UptoDateClosingValueLoc = value;
                RaisePropertyChanged("UptoDateClosingValueLoc");
            }
        }


        private Decimal? _UptoDateClosingValueImp;
        public Decimal? UptoDateClosingValueImp
        {
            get { return _UptoDateClosingValueImp; }
            set
            {
                _UptoDateClosingValueImp = value;
                RaisePropertyChanged("UptoDateClosingValueImp");
            }
        }



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

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }
    }


}
