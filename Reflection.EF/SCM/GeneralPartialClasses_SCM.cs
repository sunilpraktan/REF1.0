using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.SCM
{
    class GeneralPartialClasses_SCM
    {
    }

    public class MM_S010_BackFlip
    {
        public string doc_no { get; set; }
        public Nullable<DateTime> doc_date { get; set; }
        public string t_status { get; set; }
        public Nullable<DateTime> plann_date { get; set; }
        public Nullable<DateTime> post_date { get; set; }
        public string location_Id  { get; set; }
        public string fin_year { get; set; }
        public string posting_period{ get; set; }
        public string user_source1 { get; set; }
    }
    public class LOG_T001_A_FLIP
    {
        public string delivery_no  { get; set;}
        public Nullable<System.DateTime> delivery_date  { get; set;}
        public string PartyId  { get; set; }
        public string order_no { get; set; }
        public string delivery_type  { get; set;}
        public string doc_type  { get; set;}
        public string doc_cat  { get; set;}
        public Nullable<System.DateTime> invoice_date  { get; set;}
        public string t_status  { get; set;}
        public string del_desc { get; set;}
        public string soldpartynm { get; set;}
        public string recplantnm { get; set; }
        public string description { get; set; }
        public string EmpId { get; set; }
        public string t_display { get; set; }
        public string yr_ref_no { get; set; }
    }
    public class MM_T001Flip
    {
        public string doc_no { get; set; }
        public Nullable<DateTime> doc_date { get; set; }
        public Nullable<DateTime> post_date { get; set; }
        public string doc_type { get; set; }
        public string ref_doc { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string dept_code { get; set; }
        public string DeptName { get; set; }
        public string mov_tp { get; set; }
        public string mov_tp_name { get; set; }
        public string t_status { get; set; }
        public string location_Id { get; set; }
        public string loctaionName { get; set; }
        public string comp_code { get; set; }
        public string t_display { get; set; }
    }
   
    //public class MM_T003Flip
    //{
    //    public string req_no { get; set; }
    //    public Nullable<DateTime> date_start { get; set; }
    //    public string Requester_Nm { get; set; }
    //    public string priorityNm { get; set; }
    //    public string Dept_Name { get; set; }
    //    public Nullable<DateTime> deadline { get; set; }
    //    public string req_type { get; set; }
    //    public string t_display { get; set; }
    //    public string comp_code { get; set; }
    //    public string location_id { get; set; }
    //    public string doc_cat { get; set; }
    //    public string doc_type { get; set; }

    //}
    public partial class LOG_T001_A
    { 
        public string XmlDataDocument_LOG_T001_B { get; set; }
        public string XmlDataDocument_LOG_T001_C { get; set; }
        public string XmlDataDocument_LOG_T001_D { get; set; }
    }
   
    public partial class ZSCM_T001_A
    {
        public string XmlDataDocument_ZSCM_T001_B { get; set; }

    }
    public partial class MM_T001
    {
        public string XmlDataDocument_MM_T001 { get; set; }
        public string XmlDataDocument_MM_T001_A { get; set; }
        public string XmlDataDocument_MM_T001_B { get; set; }
        public string XmlDataDocument_MM_T001_C { get; set; }
        public string XML_DOC_ATTACHMENT { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }
    }
    public class CurrentStock
    {
        public string CatCode { get; set; }
        public string CatName { get; set; }
        public string SubCatCode { get; set; }
        public string SubCatName { get; set; }
        public string ItemTypeCd { get; set; }
        public string ItemTypeNm { get; set; }
        public string SubItemTpCd { get; set; }
        public string SubItemTpNm { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string para_code { get; set; }
        public string para_name { get; set; }
        public string value_code { get; set; }
        public string parametervalue { get; set; }
        public string location_Id { get; set; }
        public string LoctnNm { get; set; }
        public string store_code { get; set; }
        public string batch_no { get; set; }
        public string comp_code { get; set; }
        public string client { get; set; }
        public string stockcategory { get; set; }
        public decimal stock_total { get; set; }
        public Nullable<decimal> stock_reserve { get; set; }
        public string sku { get; set; }
        public string sku_desc { get; set; }
        public string unit_code { get; set; }
        public decimal? stock_unr { get; set; }
        public decimal? stock_in_insp { get; set; }
        public string description { get; set; }
        public bool? stock_level { get; set; }
        public string CompName { get; set; }
        public string store_name { get; set; }
        public string storage_level { get; set; }
    }



    public partial class CurrentStock_details
    {
        public string Item { get; set; }
        public string Description { get; set; }
        public string StockingUnit { get; set; }
        public string BatchNo { get; set; }
        public string StorageLocation { get; set; }
        public decimal Current_Stock { get; set; }
        public string Plant { get; set; }

    }
    public class CurrentStock_Report
    {
        public string Item { get; set; }
        public string Description { get; set; }
        public string StockingUnit { get; set; }
        public string BatchNo { get; set; }
        public string StorageLocation { get; set; }
        public decimal Current_Stock { get; set; }
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

    public class RptCurrentStock
    {
        public string ItemCode { get; set; }
        public string sku { get; set; }
        public string unit_code { get; set; }
        public string comp_code { get; set; }
        public string Location_Id { get; set; }
        public decimal stock_total { get; set; }
        public decimal? stock_in_transit { get; set; }
        public decimal? stock_in_transfer { get; set; }
        public decimal? stock_blocked { get; set; }
    }

    
    public partial class MM_T004
    {
        public string XmlDataDocument_FlipGrid { get; set; }

    }

}
