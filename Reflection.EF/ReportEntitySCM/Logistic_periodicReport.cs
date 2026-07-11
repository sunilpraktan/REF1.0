using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.SCM
{
    public class Logistic_periodicReport
    {
        public string inv_no { get; set; }
        public string InvoiceDate { get; set; }
        public string Godown { get; set; }
        public string Customer { get; set; }
        public string docket_no { get; set; }
        public Nullable<decimal> amount_untaxed { get; set; }
        public Nullable<decimal> amount_taxed { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string Country { get; set; }

        public string State { get; set; }
        public string pono { get; set; }
        public string PODate { get; set; }

        public Nullable<decimal> DispatchQty { get; set; }
        public Nullable<decimal> INVQty { get; set; }
        public Nullable<decimal> balqty { get; set; }

        public Nullable<decimal> unit_price { get; set; }
        public Nullable<decimal> sub_total { get; set; }
        public Nullable<decimal> boxqty { get; set; }

        public string item_code { get; set; }
        public string item_name { get; set; }
        public string unit_name { get; set; }

        public string ackDate { get; set; }
        public Nullable<decimal> ReceivedQty { get; set; }
        public Nullable<decimal> BalanceQty1 { get; set; }

        public Nullable<int> supplier_id { get; set; }

        public Nullable<int> warehouse_id { get; set; }

        public string CustItemCode { get; set; }
        public string CustItemDesc { get; set; }


    }
    public class BalanceOFClosedPO
    {
        public string sono { get; set; }
        public string sodate { get; set; }
        public string PartyNm { get; set; }
        public string UnitName { get; set; }
        public Nullable<decimal> quantity { get; set; }
        public Nullable<decimal> unit_price { get; set; }
        public Nullable<decimal> sub_total { get; set; }
        public string CstmrItmCod { get; set; }
        public string CstmrItmDesc { get; set; }
        public Nullable<decimal> poqty { get; set; }
        public Nullable<decimal> schwithoupo { get; set; }
        public string ItemCode { get; set; }
        public Nullable<decimal> SO_qty { get; set; }
        public string sch_date { get; set; }
        public Nullable<decimal> schquantity { get; set; }
        public string dc_entrydt { get; set; }
        public string bill_doc { get; set; }
        public Nullable<decimal> invqty { get; set; }
        public Nullable<decimal> spltupqty { get; set; }
        public string del_status { get; set; }
        public int id { get; set; }
        public int item_id { get; set; }
        public string POType { get; set; }
        public Nullable<decimal> SchduleValue { get; set; }
        public string desp_date { get; set; }
        public string inv_no { get; set; }
        public Nullable<decimal> SpiltUp { get; set; }
        public Nullable<decimal> SchduleValueComplete { get; set; }
        public string pono { get; set; }
        public string SchduleNo { get; set; }
        public string description { get; set; }
        public Nullable<decimal> bal_qty { get; set; }
    }
    public class ItemPeriodicReportStock
    {

        public Nullable<Int32> _item_id { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public Nullable<decimal> cur_qty { get; set; }
    }
    public class EWayBill_document
    {
        public string docNo_ewayBill { get; set; } //Text(50) , Document number of EwayBill 
        public string ewayBillNo { get; set; } // Number(12) , Unique E-Way Bill No
        public string ewayBillDate { get; set; } //Text(22) , Date and Time  of E-Way Bill Generation , dd/mm/yyyy hh:mm:ss AM/PM
        public string transType { get; set; }
        public string userGstin { get; set; }
        public string supplyType { get; set; }
        public string subSupplyType { get; set; }
        public string docType { get; set; }
        public string docNo { get; set; }
        public string docDate { get; set; }
        public string fromGstin { get; set; }
        public string fromTrdName { get; set; }
        public string fromAddr1 { get; set; }
        public string fromAddr2 { get; set; }
        public string fromPlace { get; set; }
        public string fromPincode { get; set; }
        public string fromStateCode { get; set; }
        public string fromState { get; set; } // Number(2) , State of Consignor
        public string actualFromStateCode { get; set; }
        public string toGstin { get; set; }
        public string toTrdName { get; set; }
        public string toAddr1 { get; set; }
        public string toAddr2 { get; set; }
        public string toPlace { get; set; }
        public string toPincode { get; set; }
        public string toStateCode { get; set; }
        public string actualToStateCode { get; set; }
        public decimal? totalValue { get; set; }
        public decimal? cgstValue { get; set; }
        public decimal? sgstValue { get; set; }
        public decimal? igstValue { get; set; }
        public decimal? cessValue { get; set; }
        public decimal? TotNonAdvolVal { get; set; }
        public decimal? OthValue { get; set; }
        public decimal? totInvValue { get; set; }
        public string transMode { get; set; }
        public string vehicleType { get; set; }
        public int? transDistance { get; set; }
        public string transporterId { get; set; }
        public string transporterName { get; set; }
        public string transDocNo { get; set; }
        public string transDocDate { get; set; }
        public string vehicleNo { get; set; }
        public string mainHsnCode { get; set; }
        public string Status { get; set; }
        public string errorCodes { get; set; }
        public string tripSheetEwbBills { get; set; }
        public string ewbNo { get; set; } // Number(20) , E-way bill Number generated
        //public IList<EWayBill_itemList> itemList { get; set; }
    }

    public class EWayBill_itemList
    {
        public string itemNo { get; set; }
        public string productName { get; set; } //Text(10)
        public string productDesc { get; set; } //Text(100)
        public string hsnCode { get; set; } // Number(8)
        public decimal? quantity { get; set; } //Decimal(8,2)
        public string qtyUnit { get; set; } //Text(3)
        public decimal? taxableAmount { get; set; } //Decimal(18,2)
        public decimal? sgstRate { get; set; } //Decimal(6,3)
        public decimal? cgstRate { get; set; } //Decimal(6,3)
        public decimal? igstRate { get; set; } //Decimal(6,3)
        public decimal? cessRate { get; set; } //Decimal(6,3)
        public decimal? cessNonAdvol { get; set; } //Decimal(18,2)
    }
}
