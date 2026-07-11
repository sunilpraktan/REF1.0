using System;



namespace Reflection.EF.Procurement
{
    class GeneralPartialClasses_Procurement
    { }

    public partial class PUR_T002_A
    {
        public string XmlDataDocument_PUR_T002_B { get; set; }
        public string XmlDataDocument_PUR_T002_C { get; set; }
        public string XmlDataDocument_PUR_T002_D { get; set; }
        public string XmlDataDocument_ACC_T006_B { get; set; }
        public string XmlDataDocument_PUR_T004_A { get; set; }
        public string XmlDataDocument_PUR_T004_B { get; set; }
        public string XmlDataDocument_PUR_T002_H { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }
        public string XmlDataDocument_ACC_T006_D { get; set; }
        public string XDOC_TC { get; set; }
    }
    public partial class PurchaseOrder_SingleReport
    {
        public string compmailid { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }
        public string Country { get; set; }
        public string PinCode { get; set; }

        public string PhoneOffice { get; set; }
        public string FaxNo { get; set; }
        public string Mailid { get; set; }

        public string Supplier { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierCity { get; set; }


        public string SupplierState { get; set; }
        public string SupplierCountry { get; set; }
        public string SupplierPinCode { get; set; }




        public string SupplierPhoneNo { get; set; }
        public string SupplierFaxNo { get; set; }

        public string SupplierEmailID { get; set; }
        public string SupplierWebSite { get; set; }

        public string DeliveryAddress { get; set; }
        public string BillingAddress { get; set; }

        public string po_no { get; set; }
        public string po_date { get; set; }

        public Nullable<decimal> amount_untaxed { get; set; }

        public Nullable<decimal> amount_tax { get; set; }
        public Nullable<decimal> amount_total { get; set; }
        public string amt_in_words { get; set; }



        public string item_code { get; set; }
        public string ItemCode { get; set; }
        public string item_name { get; set; }
        public string unit_name { get; set; }

        public Nullable<decimal> qty { get; set; }
        public Nullable<decimal> unit_price { get; set; }

        public Nullable<decimal> totalRs { get; set; }


        public string add_by { get; set; }

        public Nullable<Int32> po_id { get; set; }

        public string p_term { get; set; }

        public string poExpirationdate { get; set; }

        public string supplier_ref { get; set; }
        public string notes { get; set; }

        public string status_po { get; set; }

        public string buyer_name { get; set; }
        public string Range { get; set; }
        public string Division { get; set; }

        public string CommissionRate { get; set; }
        public string ECCCode { get; set; }
        public string PanNo { get; set; }
        public string VatTinNo { get; set; }
        public string LBTNo { get; set; }
        public string remark { get; set; }
        public string VatCSTNo { get; set; }
        public string currency { get; set; }
        public string valid_from_date { get; set; }
        public string valid_to_date { get; set; }
        public string update_date { get; set; }
        public string supplier_ref_doc_no { get; set; }
        public string supplier_ref_doc_date { get; set; }
        public byte[] CompLogo { get; set; }
        public string CINno { get; set; }
        public string iec_code { get; set; }
        public string service_tax_no { get; set; }
    }
    public partial class PurchaseOrder_SingleReportTax
    {
        public string Tax { get; set; }

        public Nullable<decimal> TaxamountPer { get; set; }
        public Nullable<decimal> tax_amount { get; set; }

    }
    public partial class PurchaseOrder_deliveryschedule
    {
        public string item_code { get; set; }
        public string ItemCode { get; set; }

        public string item_name { get; set; }

        public Nullable<decimal> qty { get; set; }

        public Nullable<int> item_id { get; set; }

        public Nullable<int> po_id { get; set; }

        public string stockingunit { get; set; }
    }
    public partial class PUR_T005
    {
        public string XmlDataDocument_PUR_T005_A { get; set; }
        public string XmlDataDocument_PUR_T005_C { get; set; }
        public string XmlDataDocument_ACC_T006_C { get; set; }
        public string XmlDataDocument_ACC_T006_D { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }
        public string XmlDataDocument_PUR_T005_E { get; set; }

    }
    public partial class SupplierCatalogueRange
    {
        public string stocking_unit { get; set; }

        public Nullable<int> item_id { get; set; }
        public string ItemCode { get; set; }
        public Nullable<decimal> range1 { get; set; }
        public Nullable<decimal> range2 { get; set; }
        public Nullable<decimal> gsm_range1 { get; set; }
        public Nullable<decimal> gsm_range2 { get; set; }
        public Nullable<decimal> chop_range1 { get; set; }
        public Nullable<decimal> chop_range2 { get; set; }
        public Nullable<decimal> deckle_range1 { get; set; }
        public Nullable<decimal> deckle_range2 { get; set; }

        public Nullable<decimal> b_rate { get; set; }

        public string tax_id { get; set; }
        public Nullable<int> parameter_id { get; set; }


    }
    public class PUR_T001_AFlip
    {
        public string req_no { get; set; }
        public string doc_type { get; set; }
        public Nullable<DateTime> date_start { get; set; }
        public Nullable<DateTime> deadline { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string priorityNm { get; set; }
        public string t_status { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string purchase_type { get; set; }
        public string status_remark { get; set; }
        public bool Click { get; set; }
        public string t_display { get; set; }
        public string pur_org { get; set; }
        public string pg_name { get; set; }
        public string color_code { get; set; }
        public string req_ref { get; set; }

    }

    public class PUR_T005_Flip
    {
        public string doc_no { get; set; }
        public Nullable<DateTime> doc_date { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string t_status { get; set; }
        public string ref_doc_no { get; set; }
        public string PartyId { get; set; }
        public string supplier_party_Nm { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string inv_no { get; set; }
        public Nullable<DateTime> inv_date { get; set; }
        public Nullable<DateTime> post_date { get; set; }
        public Nullable<decimal> roundup_total { get; set; }
        public string curr_code { get; set; }
        public string t_display { get; set; }
        public string color_code { get; set; }
    }
}
