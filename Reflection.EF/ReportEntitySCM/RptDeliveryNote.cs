using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.SCM.ReportEntitySCM
{
    public class RptDeliveryNote
    {
        public string delivery_no { get; set; }
        public Nullable<DateTime> delivery_date { get; set; }
        public string delivery_type { get; set; }
        public string delivery_desc { get; set; }
        public string shipment_mode { get; set; }
        public string Sold_to_partyNm { get; set; }
        public string Sold_To_Party_add  { get; set; }
        public string ship_to_PartyNm{ get; set; }
        public string ship_To_Party_add  { get; set; }
        public string TransporterNm{ get; set; }
        public string ItemCode { get; set; }
        public string Item_desc { get; set; }
        public string unit_code { get; set; }
        public Nullable<decimal> qty { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public string sku  { get; set; }
        public string sku_desc { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string pack_no { get; set; }
        public string PlantNm { get; set; }
        public string PlantAdd { get; set; }
        public string CSTNo { get; set; }
        public string VATNo { get; set; }
        public string service_tax_no { get; set; }
        public string PanNo { get; set; }
        public string ref_docno { get; set; }
        public string description { get; set; }
        public Nullable<DateTime> add_date { get; set; }
        public Nullable<DateTime> edit_date { get; set; }
        public string EmpName { get; set; }
        public string EmpPhNo { get; set; }
        public string EmpEmailId { get; set; }
        public string order_no { get; set; }
        //   public string prepared_by { get; set; }
        public string ContPersnNm { get; set; }
        public string PersnEmailId { get; set; }
        public string PersnPhNo { get; set; }
        public byte[] authorised_signature { get; set; }
        public string bill_doc { get; set; }
        public Nullable<DateTime> doc_date { get; set; }
        public string cust_ref { get; set; }
        public Nullable<DateTime> cust_ref_date { get; set; }
        public string lr_no { get; set; }
        public Nullable<DateTime> lr_date { get; set; }
        public string sold_ph { get; set; }
        public string sold_fax { get; set; }
        public string sold_email { get; set; }
        public string form_type { get; set; }
        public Nullable<DateTime> VATDate { get; set; }
        public Nullable<DateTime> CSTDate { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public string grade { get; set; }
        public string ProdNm { get; set; }
        public int? NoOfPkgs { get; set; }
        public Nullable<decimal> qtyC { get; set; }
        public int? NoOfPkgsC { get; set; }
        public string ladding_bill { get; set; }
        public Nullable<DateTime> ladding_date { get; set; }
        public string yr_ref_no { get; set; }
        public Nullable<DateTime> yr_ref_date { get; set; }
        public string inkC { get; set; }
        public string ildC { get; set; }
        public string gradeC { get; set; }
        public string descriptionC { get; set; }
        public string EmpMobNo { get; set; }
        public string C_active { get; set; }
        public Nullable<decimal> gross_wt { get; set; }
        public Nullable<decimal> net_wt { get; set; }
        public string cf_agent_code { get; set; }
        public string cf_party { get; set; }
        public string cf_address { get; set; }
        public string board_line { get; set; }
        public string cf_fax { get; set; }
        public string cf_mobile { get; set; }
        public string cf_email { get; set; }
        public Nullable<decimal> invoice_amtr { get; set; }
        public Nullable<decimal> unit_price { get; set; }
        public string textdata { get; set; }
        public string no_ofpackages { get; set; }
         public Nullable<decimal> gross_wtC { get; set; }
        public string qty_wrd { get; set; }
        public string NoOfPkgs_wrd { get; set; }
        public string no_ofpackagesA { get; set; }
        public string gstinno { get; set; }
        public Nullable<System.DateTime> gstindate { get; set; }
        public string hs_code { get; set; }
        public string hsn_code { get; set; }
        public string hsn_code2 { get; set; }

        public string shipto_gstinno { get; set; }
        public Nullable<System.DateTime> shipto_gstindate { get; set; }
        public string soldto_buss_place { get; set; }
        public string shipto_buss_place { get; set; }
        //Added by Priya
        public string city1 { get; set; }
        public string StatName { get; set; }
        public string PinCode { get; set; }
        public string STP_state_code { get; set; }
        public string DTP_state_code { get; set; }
        public string data1 { get; set; }
        public string owner_name { get; set; }
        public string DEmp_PhNo { get; set; }
        public string DEmp_FaxNo { get; set; }
        public string DEmp_EmailId { get; set; }
        public string supp_PlantNm { get; set; }
        public string supp_PlantAdd { get; set; }
        public string status_remark { get; set; }
        public string delivery_type_desc { get; set; }
        public string soldto_ContPersnNm { get; set; }
        public string add_info { get; set; }
        public string weight_unit { get; set; }
        public string KindOfPkgs { get; set; }
        public decimal? gross_wt_A { get; set; }
        public decimal? net_wt_A { get; set; }
        public int? no_of_packages { get; set; }
        public string pack_rem { get; set; }
        public string ship_mark { get; set; }
    }
}
