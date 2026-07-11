using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.SCM.ReportEntitySCM
{
    public class RptPackingList
    {
        public string Sold_to_partyNm { get; set; }
        public string Sold_To_Party_add { get; set; }
        public string ship_to_PartyNm { get; set; }
        public string ship_To_Party_add { get; set; }
        public string Item_desc { get; set; }
        public string FaxNo { get; set; }
        public string PhNo { get; set; }
        public string country_code { get; set; }
        public string origion_country { get; set; }
        public Nullable<decimal> wt_goods { get; set; }
        public Nullable<decimal> net_weight { get; set; }
        public string ship_terms { get; set; }
        public string pre_carrage { get; set; }
        public string pre_carrage_place { get; set; }
        public string vess_flight { get; set; }
        public string port_load { get; set; }
        public string port_desc { get; set; }
        public string final_dest { get; set; }
        public Nullable<int> NoOfPkgs { get; set; }
        public string KindOfPkgs { get; set; }
        public Nullable<decimal> qty { get; set; }
        public string marks { get; set; }
        public string container_no { get; set; }
        public string p_term_code { get; set; }
        public string sono { get; set; }
        public Nullable<DateTime> sodate { get; set; }
        public string cust_ref { get; set; }
        public Nullable<DateTime> cust_ref_date { get; set; }
        public string shipment_mode { get; set; }
        public string bill_doc { get; set; }
        public Nullable<DateTime> bill_date { get; set; }
        public string ProdNm { get; set; }
        public string ItemCode { get; set; }
        public string description { get; set; }
        public Nullable<DateTime> add_date { get; set; }
        public Nullable<DateTime> edit_date { get; set; }
        public string order_no { get; set; }
        public string unit_code { get; set; }

        //Added By Priya
        public string incoterms { get; set; }
        public string incoterm2 { get; set; }
        public string inco_desc { get; set; }
        public string consignee_ph { get; set; }
        public string consignee_fax { get; set; }
        public string notify_nm { get; set; }
        public string notify_ph { get; set; }
        public string notify_address { get; set; }
        public string pack_rem { get; set; }
        public string stock_code { get; set; }
        public string stk { get; set; }
        public Nullable<DateTime> order_date { get; set; }
        public string no_of_packages { get; set; }
        public string ship_mark { get; set; }
        public string yr_ref_no { get; set; }
        public Nullable<DateTime> yr_ref_date { get; set; }
        public string ref_data { get; set; }
        public string ref_data2 { get; set; }
        public string awb_no { get; set; }
        public Nullable<DateTime> awb_date { get; set; }
        public string custom_no { get; set; }
        public Nullable<DateTime> custom_date { get; set; }
        public string proforma_no { get; set; }
        public Nullable<DateTime> proforma_date { get; set; }
        public string terms_of_delivery { get; set; }
        public string manual_item_desc { get; set; }
        public string manual_desc { get; set; }
        public string text_data { get; set; }
        public string ship_term { get; set; }
        public string packing_remark { get; set; }
        public string LoctnNm { get; set; }
        public string AddL1 { get; set; }
        public string AddL2 { get; set; }
        public string cityL { get; set; }
        public string stateNmL { get; set; }
        // Add By Santosh
        public Nullable<decimal> Ball_Weight { get; set; }
        public Nullable<decimal> Spring_Weight { get; set; }
        public string prodname { get; set; }
        public string ball_content { get; set; }
        public string spring_content { get; set; }
        public Nullable<decimal>  noofball { get; set; }
        public Nullable<decimal> Tips_Weight { get; set; }
        public string hs_code2 { get; set; }
        public string data1 { get; set; }
        public Nullable<decimal> gross_wt { get; set; }
        public Nullable<decimal> net_wt { get; set; }
        public string reg_declaration { get; set; }
        public string declaration { get; set; }
        public string dec_code { get; set; }
        public string dec_desc { get; set; }
        public string rex_no { get; set; }
        public string end_use_code { get; set; }
        public string ad_code { get; set; }
        public string bank_name { get; set; }
        public string acc_number { get; set; }
        public string hs_code { get; set; }
        public string hsn_code { get; set; }
        public string hsn_code2 { get; set; }
        public string weight_unit { get; set; }
        public string notify_party_name2 { get; set; }
        public string notify_address2 { get; set; }
        public string lc_info { get; set; }
        public string lc_cond { get; set; }
        public string para5 { get; set; }
        public string para9 { get; set; }
        public string carton_count_from { get; set; }
        public string carton_count_to { get; set; }
        public string location_id { get; set; }
        public string location_id_reg { get; set; }//Registered Location from Company Master
        public string packing { get; set; }
        public string j_code { get; set; }
        public string contract_acc { get; set; }
        public string lic_name { get; set; }
    }
}
