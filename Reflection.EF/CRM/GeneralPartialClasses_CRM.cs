using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.CRM
{
    public class SEL_T099_Flip
    {
        public string doc_no { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string t_status { get; set; }
        public string PartyId { get; set; }
        public string CustomerNm { get; set; }
        public string PartyNm { get; set; }
        public string invoice_no { get; set; }
        public Nullable<decimal> para3 { get; set; }
    }
    public partial class SEL_T099
    {
        public string XmlDataDocument_SEL_T099_A { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }

    }
    public partial class ZACC_T001_A
    {
        public string XmlDataDocument_ZACC_T001 { get; set; }

    }
    public partial class SEL_T002
    {
        public string XmlDataDocument_SEL_T002_A { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }

    }
    public partial class TSK_T001_C
    {
        public string XmlDataDocument_ItemsEntity { get; set; }
        public string BackFlipEntity { get; set; }

    }
    public partial class ZADM_M025
    {
        public string XmlDataDocumentZADM_M025_A { get; set; }
        public string BackFlipEntity { get; set; }
    }
    public partial class ESEL_T001_A
    {
        public string XmlDataDocument_ESEL_T001_B { get; set; }
        public string XmlDataDocument_ESEL_T001_Flip { get; set; }

    }
    public class SEL_T002_BackFlip
    {
        public string sch_no { get; set; }
        public Nullable<System.DateTime> sch_date { get; set; }
        public string sch_mode { get; set; }
        public string sch_by { get; set; }
        public string sch_rec_by_cd { get; set; }
        public string t_status { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public bool active { get; set; }
        public string contact_name { get; set; }
        public string employee_name { get; set; }
        public string cust_ref { get; set; }
        public int del_address { get; set; }
        public string del_add { get; set; }
        public string Location { get; set; }
        public string t_display { get; set; }
        public string sono { get; set; }
    }
    public class SEL_T002_P_RefDoc
    {
        public string Ref_DocNo { get; set; }
        public DateTime Ref_date { get; set; }
        public string doc_cat { get; set; }
        public string Ref_DocType { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string so_code { get; set; }
        public string curr_code { get; set; }
        public string country_nm_s { get; set; }
        public string del_address { get; set; }
        public string bill_address_id { get; set; }
        public string p_term_code { get; set; }
        public string incoterms { get; set; }
        public string color_code { get; set; }
        public string t_status { get; set; }
        public string t_display { get; set; }

    }
    public class TSK_T001_C_BackFlip
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string act_action { get; set; }
        public string owner { get; set; }
        public string place { get; set; }
        public string address { get; set; }
        public string act_desc { get; set; }
        public string PartyId { get; set; }
        public string priority { get; set; }
        public System.DateTime start_date { get; set; }
        public string from_time { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
        public string to_time { get; set; }
        public Nullable<System.DateTime> close_date { get; set; }
        public string stage_id { get; set; }
        public string cat_id { get; set; }
        public string section_id { get; set; }
        public string note { get; set; }
        public string lead_id { get; set; }
        public string lead_title { get; set; }
        public string sono { get; set; }
        public string contact_person { get; set; }
        public string person_number { get; set; }
        public string activity_type { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string parent_activity { get; set; }
        public string action_type { get; set; }
        public string EmpName { get; set; }
        public string fin_year { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string posting_period { get; set; }
        public string s_status { get; set; }
        public string so_code { get; set; }
        public string sg_code { get; set; }
        public string EmailId { get; set; }
        public string project_name { get; set; }
        public string project_location { get; set; }
        public string project_type { get; set; }
        public string architect_grade { get; set; }
        public string para1 { get; set; }
        public string para2 { get; set; }
        public string para3 { get; set; }
        public string para4 { get; set; }
        public string para5 { get; set; }
        public Nullable<System.DateTime> pay_expected_date { get; set; }
        public Nullable<decimal> payment { get; set; }
        public string architect_name { get; set; }
        //New fields added
        public int folder_id { get; set; }
        public string assign_by { get; set; }
        public Nullable<bool> completed { get; set; }
        public string ref_doc_cat { get; set; }
        public string ref_doc_type { get; set; }
        public string po_code { get; set; }
        public string pg_code { get; set; }
        public string ind_assist { get; set; }
        public string assist_doc_no { get; set; }
        public string sch_no { get; set; }
        public string project_id { get; set; }
        public Nullable<int> phase_id { get; set; }
        public string status_remark { get; set; }
        public Nullable<decimal> plan_hours { get; set; }
        public Nullable<decimal> hours_spent { get; set; }
        public Nullable<decimal> remaining_hours { get; set; }
        public Nullable<decimal> delay_hours { get; set; }
        public Nullable<decimal> total_hours { get; set; }
        public Nullable<System.DateTime> actual_start { get; set; }
        public Nullable<System.DateTime> actual_end { get; set; }
        public Nullable<decimal> progress { get; set; }
        public Nullable<int> sequence { get; set; }
        public Nullable<int> color { get; set; }
        public string kanban_state { get; set; }
        public string repeat_id { get; set; }
        public Nullable<int> procurement_id { get; set; }
        public string r_accept { get; set; }
        public string review_by { get; set; }
        public Nullable<System.DateTime> review_date { get; set; }
        public string dependancy { get; set; }
        public string language { get; set; }
        public string client { get; set; }
        //Added by Priya
        public string comp_plant { get; set; }
        public string ref_doc_no { get; set; }
        public Nullable<int> ref_item_row_id { get; set; }
        public Nullable<System.DateTime> dead_date { get; set; }
        public string activity_goal { get; set; }
        public string activity_cat { get; set; }
        public string ind_privacy { get; set; }
        public string activity_depend { get; set; }
        public string sub_task { get; set; }
        public string party_name { get; set; }
        public Nullable<System.DateTime> act_date { get; set; }
        public string duration { get; set; }
        public string prospectus { get; set; }
        public string EmpNameDisplay { get; set; }
        public string cat_desc { get; set; }
        public string msg_body { get; set; }
        //Extra
        public string so_name { get; set; }
        public string sg_name { get; set; }
        public string LoctnNm { get; set; }
        public string address_name { get; set; }

    }
    public class SEL_T001_PDIQualityInstRpt
    {
        public string sono { get; set; }
        public string PartyId { get; set; }
        public string party_name { get; set; }
        public Nullable<System.DateTime> sodate { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string para1 { get; set; }
        public string para5 { get; set; }
        public string para27 { get; set; }

    }

    public partial class CRM_T003
    {

        public string XmlDataDocument_CRM_T003_A { get; set; }
        public string XmlDataDocument_CRM_T003_B { get; set; }
        public string XmlDataDocument_CRM_T003_C { get; set; }
        public string XmlDataDocument_CRM_T003_D { get; set; }
        public string XmlDataDocument_ADM_M053 { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }
        public string XmlDataDocument_COM_T003 { get; set; }


    }
    
    public partial class SEL_T001_B    //03/11/2015--by charu
    {
        public string item_name { get; set; }
        public string cust_code { get; set; }
        public string UOMNm { get; set; }
        public string Brate { get; set; }
        public string LoctnNm { get; set; }
        public string ILD { get; set; }
        public string Ink { get; set; }
        public string Ink1 { get; set; }
        public string Ink2 { get; set; }
        public string modelno { get; set; }
        public string modeldesc { get; set; }
        public string InkSupplier { get; set; }
        public string SubCategCod { get; set; }
        public string sku_flag { get; set; }
    }

    public partial class ZADM_M018               //Debit credit
    {
        public string XmlDataDocument_ZADM_M018 { get; set; }

    }
    public partial class CRM_T001A
    {
        public string XmlDocumentDataFlipGrid { get; set; }
        public string XmlData_CRM_T001B { get; set; }
        public string XmlData_CRM_T001C { get; set; }
        public string XmlData_CRM_T001D { get; set; }

        //--------------------------LOGGING 
        public string XmlData_C0M_T002A { get; set; }
        public string XmlData_C0M_T002B { get; set; }
        //--------------------------LOGGING 
    }
    public partial class ZCRM_T001_A
    {
        public string xdoc_ACC_T001_A { get; set; }
        public string xdoc_ACC_T001_B { get; set; }
        public string type { get; set; }

    }
    public partial class CRM_T002A
    {
        public string XmlData_CRM_T002B { get; set; }
        public string XmlData_CRM_T002D { get; set; }
        public string XmlData_CRM_T002A_FlipGrid { get; set; }
    }

    public partial class SEL_T003
    {
        public string XmlDataDocument_SEL_T003_A { get; set; }
        public string XmlDataDocument_ACC_T006_C { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }
        public string XmlDataDocument_PartysSoldToAddresses { get; set; }
        public string XmlDataDocument_ItemListPopup { get; set; }
        public string XmlDataDocument_CustCatlogNo { get; set; }
        public string XmlDataDocument_ACC_T006_D { get; set; }


    }
    public class SEL_T003Flip
    {
        public string bill_doc { get; set; }
        public Nullable<DateTime> doc_date { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string t_status { get; set; }
        public string t_display { get; set; }
        public string ref_doc_no { get; set; }
        public string sono { get; set; }
        public string PartyId { get; set; }
        public string sold_to_party_name { get; set; }
        public string so_code { get; set; }
        public string sales_org { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string roundup_total { get; set; }
        public string SalesPerson { get; set; }
        public string color_code { get; set; }
        public string cust_ref { get; set; }
        public string sg_code { get; set; }
        public string sg_name { get; set; }
    }
    public partial class ZSEL_T003
    {
        public string XmlDataDocument_ZSEL_T003 { get; set; }
        public string XmlDataDocument_ZSEL_T003_Flip { get; set; }
        
    }
    public partial class SEL_T004
    {
        public string XmlDataDocument_SEL_T004_A { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }
    }
    public class SEL_T004Flip
    {
        public Nullable<bool> selected { get; set; }
        public string doc_no { get; set; }
        public Nullable<DateTime> doc_date { get; set; }
        public string mov_tp { get; set; }
        public string delivery_no { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string t_status { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string ref_doc_cat { get; set; }
        public string ship_to_party { get; set; }
        public string PartyNm { get; set; }
        public Nullable<DateTime> plan_date { get; set; }
        public Nullable<DateTime> dispatch_date { get; set; }
        public string shipping_location { get; set; }
        public string t_display { get; set; }
        public string way_bill_no { get; set; }
        public string way_bill_value { get; set; }
        public string date { get; set; }
        public string shipping_mode_name { get; set; }
        public string transportar_name { get; set; }
        public string color_code { get; set; }
        public string screen_namespace { get; set; }
        public string screen_class_path { get; set; }
        public string screen_namespace2 { get; set; }
        public string screen_class_path2 { get; set; }
        public string ts_code { get; set; }
        public string ts_code2 { get; set; }
        public string ts_name_display { get; set; }
        public string ts_name_display2 { get; set; }
        public string sono { get; set; }
        public Nullable<DateTime> sodate { get; set; }
        public string cust_ref { get; set; }
        public Nullable<DateTime> cust_ref_date { get; set; }
        public string so_code { get; set; }
        public string curr_code { get; set; }
        public string addr_del { get; set; }
        public string addr_bill { get; set; }
        public string pterm { get; set; }
        public string incoterm { get; set; }
        public string ctry_code { get; set; }
        public string party_code { get; set; }
        public string party_code_ship { get; set; }

    }
    public partial class ZCRM_T002_A
    {
        public string xdoc_LOG_T001_A { get; set; }

    }
    public partial class ENVELOPE
    {

        public string Customer_name { get; set; }

        public string inv_no { get; set; }


        public string inv_dt { get; set; }


        public string pono { get; set; }


        public Nullable<DateTime> po_dt { get; set; }


        public string MDPARTNO { get; set; }
        public string MDITEMSHWETANAME { get; set; }
        public string sono { get; set; }

        public string item_name { get; set; }

        public string unit_name { get; set; }


        public Nullable<decimal> qty { get; set; }

        public Nullable<decimal> unit_price { get; set; }


        public Nullable<decimal> sub_total { get; set; }

        public Nullable<decimal> amount_total { get; set; }

        public bool selectall;

        public string sch_no { get; set; }
        public string PartyId { get; set; }
        public bool checkallcust { get; set; }
     

        
    }
    public partial class DeliveryEntry
    {


        public string inv_no { get; set; }


        public string inv_dt { get; set; }


        // public Nullable<int> item_id { get; set; }

        public string item_code { get; set; }

        public string item_name { get; set; }

        public string unit_code { get; set; }


        public string unit_name { get; set; }


        public Nullable<decimal> qty { get; set; }

        public Nullable<decimal> unit_price { get; set; }

        public Nullable<decimal> balqty { get; set; }

        public Nullable<int> inv_id { get; set; }
        public Nullable<int> id { get; set; }

        public Nullable<bool> active { get; set; }

        public bool check { get; set; }

    }
    public partial class DeliveryEntryM
    {


        public string inv_no { get; set; }


        public string inv_dt { get; set; }

        public Nullable<decimal> amount_total { get; set; }

        public Nullable<int> id { get; set; }


    }

    public partial class InvoiceStock
    {

        public Nullable<int> id { get; set; }
        public Nullable<int> inv_id { get; set; }

        public Nullable<int> uom_id { get; set; }
        public Nullable<int> item_id { get; set; }

        public string item_code { get; set; }


        public Nullable<decimal> qty { get; set; }
        public Nullable<decimal> Invoicesqty { get; set; }
        public Nullable<decimal> dispatchqty { get; set; }
        public Nullable<decimal> dcqty { get; set; }

        public Nullable<decimal> ackqty { get; set; }

        public string inv_no { get; set; }
        public string inv_dt { get; set; }

        public Nullable<decimal> boxqty { get; set; }
        public string docket_no { get; set; }

        public string item_name { get; set; }

        public Nullable<decimal> godownstock { get; set; }

        public bool check { get; set; }

        public string CustPartno { get; set; }

    }
    public partial class DCStock
    {



        public string CustPartno { get; set; }
        public string item_code { get; set; }

        public string item_name { get; set; }

        public Nullable<decimal> godownstock { get; set; }

        public bool check { get; set; }

    }
    public partial class PLC
    {
        public Nullable<int> ItemId { get; set; }
        public Nullable<int> unit_id { get; set; }
        public string CstmrItmCod { get; set; }
    }
    public partial class CRM_T001B_ItemPopup
    {
        public int Srno { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public Nullable<int> UnitCode { get; set; }
        public string unit_name { get; set; }
        public Nullable<int> PartyId { get; set; }
        public int ItemId { get; set; }
        public string CstmrItmCod { get; set; }
        public string CstmrItmDesc { get; set; }
        public decimal Brate { get; set; }
        public Nullable<bool> Stockble { get; set; }
        public string SubCategCod { get; set; }

    }

    public class SalesInvoice_SingleReport
    {
        public string CompanyName { get; set; }
        public byte[] CompLogo { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PinCode { get; set; }
        public string PhoneOffice { get; set; }
        public string FaxNo { get; set; }
        public string Mailid { get; set; }
        public string WebSite { get; set; }

        public string Consignee_Nm { get; set; }
        public string Consignee_Address { get; set; }
        public string Consignee_City { get; set; }
        public string Consignee_State { get; set; }
        public string Consignee_Country { get; set; }
        public string Consignee_PinCode { get; set; }
        public string Consignee_PhoneNo { get; set; }
        public string Consignee_FaxNo { get; set; }
        public string Consignee_EmailID { get; set; }
        public string Consignee_WebSite { get; set; }


        public string Buyer_Nm { get; set; }
        public string Buyer_Address { get; set; }
        public string Buyer_City { get; set; }
        public string Buyer_State { get; set; }
        public string Buyer_Country { get; set; }
        public string Buyer_PinCode { get; set; }
        public string Buyer_PhoneNo { get; set; }
        public string Buyer_FaxNo { get; set; }
        public string Buyer_EmailID { get; set; }
        public string Buyer_WebSite { get; set; }

        public string source_no { get; set; }
        public string doc_date { get; set; }

        public string bill_doc { get; set; }
        public string bill_date { get; set; }
        public string ref_data { get; set; }
        public string ref_data2 { get; set; }
        public string origin_country { get; set; }

        public string dest_country { get; set; }
        public string pre_carrage { get; set; }
        public string pre_carrage_place { get; set; }
        public string vess_flight { get; set; }
        public string port_load { get; set; }

        public string port_desc { get; set; }
        public string final_dest { get; set; }
        public string container_no { get; set; }
        public string pack_det { get; set; }
        public string prod_desc { get; set; }
        public string prod_desc1 { get; set; }

        public string item_code { get; set; }
        public string item_desc { get; set; }
        public Nullable<decimal> qty { get; set; }
        public Nullable<decimal> unit_price { get; set; }
        public Nullable<decimal> subtotal { get; set; }
        public string amt_word { get; set; }
        public Nullable<decimal> invoice_amt { get; set; }
        public Nullable<decimal> invoice_amtr { get; set; }
        public string epcg { get; set; }
        public string adv_lic { get; set; }
        public string ns_wire { get; set; }
        public string tc_ball { get; set; }
        public string transport_party_nm { get; set; }
        public string unit_name { get; set; }
        public string decl { get; set; }
        public string terms { get; set; }
        public string order_date { get; set; }
        public string marks { get; set; }
        public string container { get; set; }
        public string range_no { get; set; }
        public string no_of_pckgs { get; set; }
        public string kind_of_pckgs { get; set; }
        public string rmit_find_to { get; set; }
        public string beneficiary_bnk { get; set; }
        public string benificiary { get; set; }
        public Nullable<decimal> fright_values { get; set; }
        public Nullable<decimal> ass_value { get; set; }
        public Nullable<decimal> p_f { get; set; }
        public Nullable<decimal> cst { get; set; }
        public Nullable<decimal> rndtotal_amt { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string vat_tin { get; set; }
        public string cst_tin { get; set; }
        public string lbt_no { get; set; }
        public string ManuScop { get; set; }
        public string challanno { get; set; }
        public string challandate { get; set; }
        public string lr_no { get; set; }
        public string lr_date { get; set; }
        public string transport_mode { get; set; }
        public string Buyer_VATNo { get; set; }
        public string Buyer_VATDate { get; set; }
        public string Buyer_CSTNo { get; set; }
        public string Buyer_CSTDate { get; set; }
        public string Form_no { get; set; }
        public string Regd_Address { get; set; }
        public string del_at { get; set; }
        public string bin { get; set; }
        public string lc_cond { get; set; }
        public string gross_wt { get; set; }
        public string net_wt { get; set; }
        private decimal disc_amt { get; set; }
        public string CorporateNo { get; set; }
        public string CentralExNo { get; set; }
        public string CentralExDate { get; set; }
        public Nullable<decimal> sumqty { get; set; }
        public string model { get; set; }
        public string ILD { get; set; }
        public string INK { get; set; }
        public string dispatch_date { get; set; }
        public string appr_date { get; set; }
        public string writing_quality { get; set; }
        public string insurance { get; set; }

        public string orderno { get; set; }


        //public Nullable<decimal> unit_price { get; set; }
        //public Nullable<decimal> subtotal { get; set; }


    }
    public partial class CRM_T001B_ItemPopup_sale
    {
        public int Srno { get; set; }

        public string ItemCode { get; set; }

        public string ItemName { get; set; }

        public Nullable<int> UnitCode { get; set; }
        public string unit_code { get; set; }

        public string unit_name { get; set; }
        public string PartyId { get; set; }
        public Nullable<int> ItemId { get; set; }
        public string CstmrItmCod { get; set; }
        public string CstmrItmDesc { get; set; }
        public decimal Brate { get; set; }

        public Nullable<bool> Stockble { get; set; }
        public string SubCategCod { get; set; }
        public string tax_id { get; set; }
        public Nullable<int> model_id { get; set; }

    }
    public class ADM_M028_PopUpMasterItemData
    {
        public int ItemId { get; set; }
        public string CstmrItmCod { get; set; }
        public string CstmrItmDesc { get; set; }
    }
    public class ADM_M028_PopUpMasterItem
    {
        public string ItemId { get; set; }
        public string CstmrItmCod { get; set; }
        public string CstmrItmDesc { get; set; }
    }
    public class ADM_M028_PopUp_Report
    {
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string EmailId { get; set; }

    }
    public class ADM_M028_PopUp_rpt
    {
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string EmailId { get; set; }

    }

    public partial class CompanyData
    {

        public string CompName { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }
        public string Country { get; set; }
        public string PinCode { get; set; }

        public string PhoneOffice { get; set; }
        public string FaxNo { get; set; }
        public string Mailid { get; set; }

    }
    public partial class SalesOrder_deliveryschedule
    {
        public string cust_code { get; set; }

        public string cust_descr { get; set; }

        public Nullable<decimal> qty { get; set; }

        public Nullable<int> item { get; set; }

        public Nullable<int> po_id { get; set; }

        public string stockingunit { get; set; }


    }

    public partial class Inquiry_PopUp
    {

        public string ItemName { get; set; }

        public string doc_no { get; set; }
        public Nullable<int> item_id { get; set; }

        public string SubCategCod { get; set; }

        public Nullable<int> Inq_id { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> quantity { get; set; }
        public Nullable<decimal> unit_price { get; set; }
        public string tax_id { get; set; }
        public string stocking_unit { get; set; }
        public Nullable<System.DateTime> valid_from_date { get; set; }
        public Nullable<System.DateTime> valid_to_date { get; set; }

        public string ContPersnNm { get; set; }
        public Nullable<int> buyer { get; set; }

        public string validator_name { get; set; }
        public Nullable<int> pay_term { get; set; }
        public string p_term { get; set; }
        public string InvicAdd { get; set; }
        public string DelAdd { get; set; }
        public Nullable<int> bill_address_id { get; set; }
        public Nullable<int> del_address { get; set; }
        public Nullable<System.DateTime> expect_date { get; set; }
        public string CstmrItmCod { get; set; }
        public string CstmrItmDesc { get; set; }

        public Nullable<int> uom { get; set; }
        public string UOMNm { get; set; }
        public Nullable<decimal> discount { get; set; }
        public Nullable<decimal> sub_total { get; set; }
        public string sales_org { get; set; }
        public string sales_org_name { get; set; }
        public string sales_div_name { get; set; }
        public string sales_person_name { get; set; }
        public string journal_name { get; set; }
        public string stock_location { get; set; }
        public string warehouse { get; set; }
        public string distribution_channel_name { get; set; }
        public string sales_grp_person { get; set; }
        public string sales_office_person { get; set; }
        public string sales_div { get; set; }
        public Nullable<int> sales_person { get; set; }
        public Nullable<int> journal_id { get; set; }
        public string distribution_channel { get; set; }
        public string sales_grp { get; set; }
        public string sales_office { get; set; }
        public string business_area { get; set; }
        public string cost_center { get; set; }
        public Nullable<int> cost_center_id { get; set; }
        public string profit_center { get; set; }
        public string doc_currency_name { get; set; }

        public Nullable<bool> invoice { get; set; }
        public Nullable<decimal> tax_amt { get; set; }
        public Nullable<decimal> untax_amt { get; set; }
        public Nullable<decimal> total_amt { get; set; }
        public string amt_inword { get; set; }

        public string doc_type_id { get; set; }
        public string doc_category_id { get; set; }

        public string stock_location_id { get; set; }
        public Nullable<int> doc_currency { get; set; }
        public string warehouse_id { get; set; }
        public string invoice_method { get; set; }
        public Nullable<bool> shipped { get; set; }
        public Nullable<System.DateTime> shipped_date { get; set; }
        public Nullable<int> validator { get; set; }
        public Nullable<System.DateTime> min_planned_date { get; set; }


        public Nullable<int> ship_to { get; set; }
        public string ship_to_party { get; set; }

        public string item_cat_id { get; set; }
        public Nullable<int> customer_id { get; set; }
        public string PartyNm { get; set; }

        public Nullable<bool> Stockable { get; set; }

    }
    public partial class ECRM_T001_A
    {
        public string XmlDataDocument_ECRM_T001_B { get; set; }
        public string XmlDataDocument_ECRM_T001_A_Flip { get; set; }
    }
    public partial class ECRM_T001_C
    {
        public string XmlDataDocument_ECRM_T001_D { get; set; }
        public string XmlDataDocument_ECRM_T001_C_Flip { get; set; }
    }
    public partial class ECRM_T004_A
    {
        public string XmlDataDocument_ECRM_T004_B { get; set; }

    }
    public partial class ECRM_T002_A
    {
        public string XmlDataDocument_ECRM_T002_B { get; set; }
        public string XmlDataDocument_ECRM_T002_C { get; set; }

    }
    public partial class ECRM_T003_A
    {
        public string XmlDataDocument_ECRM_T003_AFlip { get; set; }
        public string XmlDataDocument_ECRM_T003_B { get; set; }

    }
    
    
    public partial class ILD1
    {
        public decimal ILD { get; set; }

    }

    public partial class ILD2
    {
        public decimal ILD { get; set; }

    }
    public class WTRpt_ECRM_T003_A
    {
       
        //public int id { get; set; }
        //public Nullable<int> mchn_id { get; set; }
        //public string lotno { get; set; }
        //public Nullable<System.DateTime> prddt { get; set; }
        //public string wtno { get; set; }
        //public Nullable<System.DateTime> wtdt { get; set; }
        //public string modlno { get; set; }
        //public string ink { get; set; }
        //public string timefr { get; set; }
        //public string timeto { get; set; }
        //public string tmp { get; set; }
        //public string humdt { get; set; }
        //public string shift { get; set; }
        //public Nullable<int> tm { get; set; }
        //public decimal tmnild { get; set; }
        //public decimal tmxild { get; set; }
        //public decimal tavild { get; set; }
        //public decimal tavgoo { get; set; }
        //public decimal amnild { get; set; }
        //public decimal amxild { get; set; }
        //public decimal aavild { get; set; }
        //public decimal aavgoo { get; set; }
        //public Nullable<int> company_id { get; set; }
        //public string plant_id { get; set; }
        //public string LoctnNm { get; set; }
        //public string doc_type { get; set; }
        //public string MachineCode { get; set; }
        //public string Conv_lot { get; set; }
        //public decimal Ranget { get; set; }
        //public decimal Rangea { get; set; }
        //public string obrem { get; set; }
        //public Nullable<int> wtid { get; set; }
        //public string refilno { get; set; }
        //public decimal wbtsta { get; set; }
        //public decimal watstb { get; set; }
        //public decimal waclgc { get; set; }
        //public decimal ild { get; set; }
        //public decimal gooping { get; set; }
        //public string defects { get; set; }
        //public string remusr { get; set; }
        //public string prdct_code { get; set; }
        //public Nullable<System.DateTime> add_date { get; set; }
        //public int id_Prv1 { get; set; }
        //public Nullable<System.DateTime> date_Prv1 { get; set; }
        //public string time_Prv1 { get; set; }
        //public int Comp_Id { get; set; }
        //public string CompName { get; set; }
        //public string Add1 { get; set; }
        //public string Add2 { get; set; }
        //public string City { get; set; }
        //public string PinCode { get; set; }
        //public string PhOffi { get; set; }
        //public string FaxNo { get; set; }
        //public string MailId { get; set; }
        //public string CountryName { get; set; }
        //public string StateName { get; set; }
        //public decimal ildp1 { get; set; }
        //public decimal ildp2 { get; set; }

        //------------------------------------------

        public string shift { get; set; }
        public int docnoc { get; set; }
        public int docnop1 { get; set; }
        public int docnop2 { get; set; }
        public string targetild { get; set; }
        public string atempc { get; set; }
        public string humid { get; set; }
        public string lotno { get; set; }
        public Nullable<System.DateTime> wtrdate { get; set; }
        public string ink { get; set; }
        public string refilno { get; set; }
        public string ild { get; set; }

        public string product { get; set; }
        public Nullable<System.DateTime> time { get; set; }

        public string mchncdu { get; set; }
        public string comnm { get; set; }
        public string unit { get; set; }
        public decimal maxc { get; set; }
        public decimal minc { get; set; }
        public decimal avgc { get; set; }
        public string targetildp1 { get; set; }

        public string targetildp2 { get; set; }
        public string atempp1 { get; set; }
        public string atempp2 { get; set; }
        public string humidp1 { get; set; }
        public string humidp2 { get; set; }

        public Nullable<System.DateTime> timep1 { get; set; }
        public Nullable<System.DateTime> timep2 { get; set; }

        public decimal max1 { get; set; }
        public decimal min1 { get; set; }
        public decimal avg1 { get; set; }
        public decimal max2 { get; set; }
        public decimal min2 { get; set; }
        public decimal avg2 { get; set; }
        public decimal wtrno { get; set; }
        public string prddt { get; set; }
        public string wtno { get; set; }
        public decimal ildc { get; set; }
        public string remusr { get; set; }
        public Nullable<System.DateTime> PDItime { get; set; }
        public Nullable<System.DateTime> PDITime1 { get; set; }
        public Nullable<System.DateTime> PDITime2 { get; set; }
        public decimal ildp1 { get; set; }

        public decimal ild2 { get; set; }

        public decimal Tmax1 { get; set; }
        public decimal Tmin1 { get; set; }
        public decimal Tmax2 { get; set; }
        public decimal Tmin2 { get; set; }
        public decimal Tmax { get; set; }
        public decimal Tmin { get; set; }
        public string EmpNm { get; set; }
        

    }
    public class PDIRpt_ECRM_T004_A
    {
        public int id { get; set; }
        public string pdi_no { get; set; }
        public Nullable<System.DateTime> pdi_date { get; set; }
        public string ref_no { get; set; }
        public string mod_no { get; set; }
        public string Item_Code { get; set; }
        public Nullable<int> party { get; set; }
        public string PartyNm { get; set; }
        public Nullable<decimal> qty { get; set; }
        public string batchno { get; set; }
        public Nullable<int> mach_no { get; set; }
        public string shift { get; set; }
        public string Grade { get; set; }
        public string whout_ball { get; set; }
        public string chips { get; set; }
        public string coll_mdg { get; set; }
        public string clngqulit { get; set; }
        public string pltqulit { get; set; }
        public string mixing { get; set; }
        public string nonwrt { get; set; }
        public string ildchk { get; set; }
        public string handfil { get; set; }
        public string shdia { get; set; }
        public string shlen { get; set; }
        public string shchmfr { get; set; }
        public string nedledia { get; set; }
        public string nedlen { get; set; }
        public string totlen { get; set; }
        public string baout { get; set; }
        public Nullable<decimal> ildmin { get; set; }
        public Nullable<decimal> ildmax { get; set; }
        public Nullable<decimal> ildavg { get; set; }
        public string ildrang { get; set; }
        public string set_ild { get; set; }
        public string set_ink { get; set; }
        public Nullable<System.DateTime> prodate { get; set; }
        public string Conv_no { get; set; }
        public string PlantCode { get; set; }
        public Nullable<int> ComCode { get; set; }
        public string note { get; set; }


        public string MachineCode { get; set; }
        public string LoctnNm { get; set; }


        public int Comp_Id { get; set; }
        public string CompName { get; set; }
        public string Add1 { get; set; }
        public string Add2 { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string PhOffi { get; set; }
        public string FaxNo { get; set; }
        public string MailId { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string BallSize { get; set; }
        public string TipType { get; set; }
    }


    public partial class ECRM_T005              //Post Export Transaction
    {
        public string XmlDataDocument_ECRM_T005 { get; set; }

    }

    public partial class PUR_T002_G            //PO Approve
    {
        public string XmlDataDocument_PUR_T002_G { get; set; }
    }
    class GeneralPartialClasses_CRM
    {
    }

    public class ECRM_T001_A_Flip
    {
        public string sa_no { get; set; }
        public Nullable<System.DateTime> sa_date { get; set; }
        public string Plant_Nm { get; set; }
        public string sample_frm { get; set; }
        public string sample_when { get; set; }
        public string purpose { get; set; }
        public string trans_type { get; set; }

    }

    public class ECRM_T001_C_Flip
    {
        public string sr_no { get; set; }
        public Nullable<System.DateTime> sr_date { get; set; }
        public string sa_no { get; set; }
        public string analysis_for { get; set; }
        public string samp_details { get; set; }
        public string test_no { get; set; }
        public string ball_material { get; set; }
        public DateTime? sa_date { get; set; }
        public DateTime? sample_re_date { get; set; }

    }
    public class CRM_T004_Flip
    {
        public string doc_no { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string EmpId { get; set; }
        public string company { get; set; }
        public string plant { get; set; }
        public string month { get; set; }
        public string t_status { get; set; }
        public string year { get; set; }
        public string EmpName { get; set; }
        public Nullable<System.DateTime> clouser_date { get; set; }


    }
    public partial class CRM_T004
    {
        public string XmlDataDocument_CRM_T004_A { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }

    }
}