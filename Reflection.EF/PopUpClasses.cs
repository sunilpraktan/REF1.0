using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF
{
    public class ADM_M022_ItemPopup // shifted from general partial classes of business logic
    {
        public int item_id { get; set; }
        public string CstmrItmCod { get; set; }
        public string CstmrItmDesc { get; set; }
        public Nullable<int> party_id { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public Nullable<int> unit_id { get; set; }
        public string unit_name { get; set; }
        public decimal total_schedule_qty { get; set; }
        public int lead_time { get; set; }
        public string sono { get; set; }
        public Nullable<int> so_id { get; set; }
        public string cust_ref { get; set; }
        public string stocking_unit { get; set; }
    }
    public class ZACC_T001
    {
        public string Month { get; set; }
        public string Year { get; set; }
    }
    public class ZACC_T001_WireSize
    {
        public string WireSize { get; set; }
    }

    public class ZACC_T001_WireType
    {
        public string WireType { get; set; }
    }

    public class ZACC_T001_BallType
    {
        public string BallType { get; set; }
    }

    public class ZACC_T001_TipLength
    {
        public string TipLength { get; set; }
    }

    public class ZACC_T001_Unit
    {
        public string Unit { get; set; }
    }

    public class ADM_M028_A_PopUp
    {

        public string group1 { get; set; }
        public string grpNm { get; set; }

    }
    public class ADM_M028_B_PopUp
    {
        public string PartyType { get; set; }
        public string PartyType_Nm { get; set; }

    }

    public class ZACC_T001_Pre_Year
    {
        public string Pre_Year { get; set; }
    }
    #region "Pup Up used for Item Master"
    public class ADM_M018_PopUp
    {
        public int CatId { get; set; }
        public string CatName { get; set; }

        public string CatCode { get; set; }
    }
    public class ADM_M019_PopUp_1
    {
        public int SubCatId { get; set; }
        public string SubCatName { get; set; }
        public String SubCatCode { get; set; }
        public int CatId { get; set; }
        public string CatName { get; set; }
        public string CatCode { get; set; }
    }
    public class ADM_M015_PopUp
    {
        public int id { get; set; }
        public string ItemTypeCd { get; set; }
        public string ItemTypeNm { get; set; }
        public String SubCatCode { get; set; }
        public int sub_category_id { get; set; }
        public string subcatagory_name { get; set; }
    }
    public class ADM_M016_PopUp
    {
        public int id { get; set; }
        public string ItemTypeCd { get; set; }
        public string SubItemTpNm { get; set; }
        public string SubItemTpCd { get; set; }
        public int ItemType_id { get; set; }
        public string ItemTypeNm { get; set; }
    }
    public class ADM_M020_PopUp
    {
        public int id { get; set; }
        public string ProdNm { get; set; }
        public string ProdNmCd { get; set; }
    }
    public class ADM_M014_PopUp
    {
        public int id { get; set; }


        public string CommName { get; set; }
        public string CommCode { get; set; }
    }
    public class ADM_M021_PopUp
    {
        public int id { get; set; }
        public string MateCode { get; set; }
        public string MateName { get; set; }
    }
    public class ADM_M017_PopUp
    {
        public int id { get; set; }
        public string AssetNm { get; set; }
        public string AssetCode { get; set; }
    }
    //public class ADM_M038_B_PopUp
    //{
    //    public int id { get; set; }
    //    public string unit_name { get; set; }
    //}
    public class ADM_M023_PopUp
    {
        public int id { get; set; }
        public string RgName { get; set; }

        public string RgCode { get; set; }
    }
    #endregion

    public class ADM_M011_PopUp
    {
        public int id { get; set; }
        public string warehouse_name { get; set; }
        public string ProductName { get; set; }

    }
    public class ADM_M012_PopUp
    {
        public int CntryCode { get; set; }
        public string CntryName { get; set; }
        public string country_code { get; set; }
    }
    public partial class ECRM_T003_B_PopUp//Wrting TestDetails
    {
        public int id { get; set; }
        public Nullable<int> wtid { get; set; }
        public string refilno { get; set; }

        public int tm { get; set; }
    }

    public class ADM_M013_PopUp
    {
        public int StatCode { get; set; }
        public string StatName { get; set; }
        public int CntryCode { get; set; }
        public string state_code { get; set; }
        public string country_code { get; set; }


    }

    public class ZADM_M011_PopUp
    {
        public Nullable<int> machine_type_id { get; set; }
        public string machine_type { get; set; }
    }
    public class ESO_T001_PopUp // Sorting
    {
        public DateTime prod_dt { get; set; }
        public string mc_code { get; set; }
    }
    public class ZADM_M012_PopUp
    {
        public Nullable<int> machine_subtype_id { get; set; }
        public string machine_subtype { get; set; }
    }

    public class ZADM_M013_PopUp
    {
        public Nullable<int> machine_id { get; set; }
        public string machinecode { get; set; }

    }

    public class ADM_M041_PopUp
    {
        //public Nullable<int> machinecap_id { get; set; }
        public string Capacity { get; set; }
    }

    public class ADM_M015_PopUp_1
    {
        public int id { get; set; }
        public string ItemTypeCd { get; set; }
        public string ItemTypeNm { get; set; }
    }
    public class ADM_M019_PopUp
    {
        public int SubCatId { get; set; }
        public string SubCatName { get; set; }
    }
    public class ADM_M002_PopUp
    {
        public int Comp_Id { get; set; }
        public string CompName { get; set; }
        public string comp { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
    }
    public class ADM_M003_PopUp
    {
        public string Location_Id { get; set; }
        public string LoctnNm { get; set; }
        public string plant_code { get; set; }
    }
    public class ADM_M005_PopUp
    {
        public int AuthFldCod { get; set; }

        public string AuthFldNm { get; set; }

    }
    public class ADM_M007_PopUp
    {
        public int UserTypCode { get; set; }
        public string UserTyp { get; set; }
        public Nullable<System.DateTime> AddDate { get; set; }
        public string EditBy { get; set; }
        public Nullable<System.DateTime> EditDate { get; set; }
    }
    public class ADM_M008B_PopUp
    {
        public int id { get; set; }
        public string TranCode { get; set; }
        public string TranName { get; set; }

    }
    public class ADM_M009_PopUp
    {
        public int id { get; set; }
        public string RoleName { get; set; }

    }
    public class ADM_M022_PopUp
    {
        public int SrNo { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        //public Nullable<int> unit_id { get; set; }
        public string unit_name { get; set; }
        public string CustItemCode { get; set; }
        public string CustItemName { get; set; }
        public string SubCatCode { get; set; }
        public string unit_code { get; set; }
        public Nullable<Boolean> StockUnt { get; set; }
    }
    public class ADM_M022_PopUp_CRM2B
    {
        public int SrNo { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public Nullable<int> unit_id { get; set; }
        public string unit_name { get; set; }
        public int SubCategCod { get; set; }
        public bool Stockble { get; set; }
    }
    //public class ADM_M022_PopUp_PUR_T1A
    //{
    //    public int id { get; set; }

    //    public string ItemCode { get; set; }

    //    public string ItemName { get; set; }
    //    public int SubCategCod { get; set; }
    //    public string CustCode { get; set; }
    //    public string CustDecrName { get; set; }
    //    public Nullable<int> unit_id { get; set; }

    //    public string unit_name { get; set; }
    //    internal bool _Select { get; set; }    

    //}
    public class ADM_M022_PopUp_Inst
    {
        public int item_id { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int unit_id { get; set; }
        public string unit_name { get; set; }
        public string unit_code { get; set; }
        public string unit_abbrv { get; set; }
        public int SubCategCod { get; set; }
        public Nullable<bool> Stockable { get; set; }
        //public string batch_no { get; set; }
        public int SrNo { get; set; }

    }
    public class CRM_T001B_PopUp
    {
        public int id { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string CustCode { get; set; }
        public string CustDecrName { get; set; }
        public Nullable<int> unit_id { get; set; }
        public string unit_name { get; set; }
    }
    public class CRM_T001B_PopUp_PUR
    {
        public int id { get; set; }//ADM_M022 SrNo as id

        public string ItemCode { get; set; }//ADM_M022

        public string ItemName { get; set; }//ADM_M022
        public int SubCategCod { get; set; }//ADM_M022
        public string CustCode { get; set; }//CRM_T001B CstmrItmCod as 
        public string CustDecrName { get; set; }//CRM_T001B CstmrItmDesc as
        public Nullable<int> unit_id { get; set; } //ADM_M038_B     
        public string unit_name { get; set; }//ADM_M038_B

        public string req_no { get; set; }
        //public Nullable<int> requsition_id { get; set; }
        public int requsition_id { get; set; }//new
        public Nullable<decimal> appr_qty { get; set; }

        public Nullable<decimal> rate { get; set; }
        public Nullable<decimal> subtotal { get; set; }
        public string stockingunit { get; set; }//ADM_M022

        public string req_type { get; set; }//ADM_M022

        public string req_ref { get; set; }//ADM_M022

        public string tax_id { get; set; }

        public Nullable<bool> Stockble { get; set; }
        public string unit_code { get; set; }//new 
        public Nullable<decimal> amount_tax { get; set; }
        public Nullable<decimal> amount_untaxed { get; set; }
        public Nullable<decimal> amount_total { get; set; }
        public string amt_in_words { get; set; }

    }

    public class CRM_T002B_PopUp_PUR
    {
        public int id { get; set; }//ADM_M022 SrNo as id

        public string ItemCode { get; set; }//ADM_M022

        public string ItemName { get; set; }//ADM_M022

        public string CatCode { get; set; }
        public int SubCategCod { get; set; }//ADM_M022
        public string CustCode { get; set; }//CRM_T001B CstmrItmCod as 
        public string CustDecrName { get; set; }//CRM_T001B CstmrItmDesc as
        public Nullable<int> unit_id { get; set; } //ADM_M038_B     
        public string unit_name { get; set; }//ADM_M038_B

        public string unit_code { get; set; }
        public Nullable<int> requsition_id { get; set; }
        public Nullable<decimal> appr_qty { get; set; }

        public Nullable<decimal> rate { get; set; }
        public bool Stockble { get; set; }
    }

    public class MM_T001_A_PopUp_PUR
    {
        public string doc_no { get; set; }//ADM_M022  
        public Nullable<int> grn_id { get; set; }//ADM_M022 SrNo as id
        public string ItemCode { get; set; }//ADM_M022
        public string ItemName { get; set; }//ADM_M022
        public string po_no { get; set; }
        public Nullable<int> SubCategCod { get; set; }//ADM_M022
        public string CustCode { get; set; }//CRM_T001B CstmrItmCod as 
        public string CustDecrName { get; set; }//CRM_T001B CstmrItmDesc as
        public Nullable<decimal> appr_qty { get; set; }
        public Nullable<decimal> rate { get; set; }
        public string stockingunit { get; set; }//ADM_M022
        public string tax_id { get; set; }
        public Nullable<int> unit_id { get; set; } //ADM_M038_B     
        public string unit_name { get; set; }//ADM_M038_B    
        public Nullable<int> item_id { get; set; } //ADM_M038_B  

        public string grnno { get; set; }//ADM_M038_B    

        public Nullable<decimal> amount_total { get; set; }

        public Nullable<decimal> amount_untaxed { get; set; }
        public Nullable<decimal> amount_tax { get; set; }

        public string amt_in_words { get; set; }

        public string item_cat { get; set; }

        public Nullable<decimal> sub_total { get; set; }

        public string invoiceNo { get; set; }
        public Nullable<DateTime> Invoicedate { get; set; }

        public string challanno { get; set; }
        public Nullable<DateTime> challandate { get; set; }
        public string bill_ladding { get; set; }
        public Nullable<int> pay_term_id { get; set; }
        public string p_term { get; set; }
        public string doc_cat { get; set; }
        public string entry_time { get; set; }
        public Nullable<DateTime> post_date { get; set; }

        public Nullable<int> company_id { get; set; }
        public string companyname { get; set; }



    }


    public class Parameter_PopUp
    {
        public int id { get; set; }
        public string CatParamCode { get; set; }
        public string CatParamName { get; set; }
        public string Type { get; set; }
        public string SubCatCode { get; set; }
        public string SubCatCd { get; set; }
        public string Name { get; set; }
        public bool StockUnt { get; set; }

        public string value_code { get; set; }
        public string para_code { get; set; }
    }

    public class ADM_M024_PopUp
    {
        public int id { get; set; }
        public string EmpId { get; set; }
        public string EmpLName { get; set; }
        public string EmpFName { get; set; }
        public string EmpMName { get; set; }
        public string EmailId { get; set; }
        public string PartyId { get; set; }
        public string Currency { get; set; }
        public string dept_code { get; set; }
        public string DeptName { get; set; }
    }
    public class ADM_M024_PopUp_Emp
    {

        public int id { get; set; }
        public string emp_id { get; set; }
        public string EmpLName { get; set; }
        public string EmpFName { get; set; }
        public string EmpMName { get; set; }
        public string EmpMobNo { get; set; }
        public Nullable<int> DesigCode { get; set; }
        public byte[] Photo { get; set; }

    }

    public class ADM_M024_PopUp1
    {
        public int id { get; set; }

        public string MachineOwner { get; set; }
    }

    public class ADM_M027_PopUp
    {
        public int ContInfoId { get; set; }
        public string PersnFName { get; set; }
        public string PersnMName { get; set; }
        public string PersnLName { get; set; }
    }

    public class ADM_M028_PopUp
    {
        public int id { get; set; }
        public string PartyId { get; set; }

        public string PartyNm { get; set; }

        public string EmailId { get; set; }

        public string Currency { get; set; }

        public string curr_code { get; set; }
        public string contryNm { get; set; }
        public string PersnEmailId { get; set; }
    }
    public class ADM_M025_Popup//Department Master
    {

        public int id { get; set; }
        public string DeptName { get; set; }
        public string dept_code { get; set; }

    }
    public class ADM_M029_PopUp
    {
        public int id { get; set; }
        public string AddType { get; set; }
        public string Party_Id { get; set; }
        public string Location { get; set; }
        public string Add1 { get; set; }
        public string Add2 { get; set; }
    }
    public class ADM_M029_PopUp1
    {
        public int id { get; set; }
        public string Location { get; set; }
        public string AddType { get; set; }
        public string Add1 { get; set; }
        public string Add2 { get; set; }
    }
    public class ADM_M030_PopUp
    {
        public string code { get; set; }
        public string paramcode { get; set; }
        public string parametervalue { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string selectedValue { get; set; }
        public string selectedindex { get; set; }
    }

    public class ParameterSelection
    {
        public int code { get; set; }
        public string parametervalue { get; set; }

        public string type { get; set; }

        public int Srno { get; set; }
    }


    //public class ADM_M031_PopUp
    //{
    //    public int ShdCode { get; set; }      
    //    public string Shade { get; set; }
    //}
    public class ADM_M032_PopUp
    {
        public int MakeCode { get; set; }
        public string Make { get; set; }

    }
    public class ADM_M033_PopUp
    {
        public string ColurCode { get; set; }
        public string Colour { get; set; }
    }
    public class ADM_M034_PopUp
    {
        public int id { get; set; }
        public string Type { get; set; }
        public int SubCatCode { get; set; }
    }
    public class ADM_M027_PopUp1
    {
        public int ContInfoId { get; set; }
        public string PersnLName { get; set; }
        public string PersnFName { get; set; }
        public string PersnMName { get; set; }

    }
    public class ADM_M038_A_PopUp
    {
        public int id { get; set; }
        public string class_name { get; set; }
        public string unit_code { get; set; }

    }
    public class ADM_M038_B_PopUp
    {
        public int id { get; set; }
        public string unit_code { get; set; }
        public string unit_name { get; set; }
        public string unit_abbrv { get; set; }
    }
    public class ADM_M038_B_PopUp_UOMConersion
    {
        public int id { get; set; }
        public int class_id { get; set; }
        public string unit_name { get; set; }
        public Nullable<bool> is_base_unit { get; set; }
        public string unit_code { get; set; }
    }

    public class ADM_M040_PopUp
    {
        public int id { get; set; }

        public string priority { get; set; }

    }
    public class ADM_M026_Popup
    {

        public int id { get; set; }
        public string DesigName { get; set; }
        public string desig_code { get; set; }
    }
    //public class ADM_M038_B_PopUp_Capacity
    //{        
    //    public string Capacity { get; set; }
    //}  
    public class SEL_T002_B_POItem
    {
        public int item_id { get; set; }
        public string stocking_unit { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public Nullable<int> unit_id { get; set; }
        public string unit_name { get; set; }
        public Nullable<int> po_id { get; set; }
        public string po_no { get; set; }
        public string cust_ref { get; set; }
        public string po_type { get; set; }
        public int party_id { get; set; }
        public Nullable<decimal> actual_po_qty { get; set; }
        public Nullable<decimal> schedule_bal_qty { get; set; }
        public Nullable<decimal> accepeted_qty { get; set; }
        public Nullable<decimal> dispatched_qty { get; set; }
        public Nullable<decimal> porequired_qty { get; set; }
        public Nullable<decimal> schQty { get; set; }
        public Nullable<System.DateTime> sodate { get; set; }
        public Nullable<System.DateTime> cust_ref_date { get; set; }
        public Nullable<decimal> shrot_excess_amt { get; set; }
        public Nullable<decimal> confirmation_bal_qty { get; set; }

    }
    public class ACC_M003_PopUp
    {
        public int id { get; set; }
        public string p_code { get; set; }
        public string p_name { get; set; }
    }
    public class EPR_T001_PopUp //ILD Master AND Maschine Master
    {
        public int id { get; set; }
        public int machine_id { get; set; }
        public string machinecode { get; set; }
        public string machinedesc { get; set; }
        public string machine_type { get; set; }
        public Nullable<int> model_id { get; set; }
        public string model_no { get; set; }
        public string item_code { get; set; }
        public string ink { get; set; }
        public Nullable<System.DateTime> start_dt { get; set; }

    }

    public class EPR_T001_PopUp_Lot //Conv Lot From ILDChart 
    {
        public int id { get; set; }
        public string MachineCode { get; set; }
        public Nullable<int> Conv_lot { get; set; }
        public string Status { get; set; }
        public Nullable<int> model_id { get; set; }
        public string model_no { get; set; }
        public string item_code { get; set; }
        public Nullable<int> party_id { get; set; }
        public string PartyNm { get; set; }
        public string shift { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public Nullable<System.DateTime> start_dt { get; set; }
        public decimal min_val { get; set; }
        public decimal max_val { get; set; }
        public string shank_len { get; set; }
        public Nullable<decimal> shank_dia { get; set; }
        public string needle_dia { get; set; }
        public string needle { get; set; }
        public string total_len { get; set; }
        public Nullable<decimal> amnild { get; set; }
        public Nullable<decimal> amxild { get; set; }
        public Nullable<decimal> aavild { get; set; }

    }
    public class ECR_T004_PopUp_Lot //Conv Lot From ILDChart 
    {
        public int id { get; set; }
        public string MachineCode { get; set; }
        public Nullable<int> Conv_lot { get; set; }
        public string Status { get; set; }
        public Nullable<int> model_id { get; set; }
        public string model_no { get; set; }
        public string item_code { get; set; }
        public string ItemName { get; set; }
        public Nullable<int> party_id { get; set; }
        public string PartyId { get; set; }//newly  added
        public string PartyNm { get; set; }
        public string shift { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public Nullable<System.DateTime> start_dt { get; set; }
        public decimal min_val { get; set; }
        public decimal max_val { get; set; }
        public string shank_len { get; set; }
        public string shank_dia { get; set; }
        public string needle_dia { get; set; }
        public string needle { get; set; }
        public string total_len { get; set; }
        public Nullable<decimal> amnild { get; set; }
        public Nullable<decimal> amxild { get; set; }
        public Nullable<decimal> aavild { get; set; }

        public string ballout { get; set; }
        public string ShankChamfer { get; set; }

    }
    public class ACC_M005_PopUp
    {
        public int id { get; set; }
        public string journal_name { get; set; }
        public string j_code { get; set; }
    }

    public class ACC_M014_PopUp
    {
        public int id { get; set; }
        public string t_code { get; set; }
        public string t_name { get; set; }
    }
    public class ACC_M007_PopUp
    {
        public int id { get; set; }
        public string p_term { get; set; }
        public string p_term_code { get; set; }

    }
    public class ACC_M013_PopUp
    {
        public int id { get; set; }
        public string description { get; set; }
        public decimal amount { get; set; }

        public string t_type { get; set; }
        public Nullable<Boolean> include_base_amount { get; set; }
        public Nullable<Boolean> child_depend { get; set; }
        public Nullable<Int32> parent_id { get; set; }

        public string taxaccount { get; set; }

        public Nullable<int> accountcollectdid { get; set; }

        public Nullable<Boolean> Price_include { get; set; }

    }
    public class ACC_M013_PopUp_TaxAccount
    {
        public string taxaccount { get; set; }

        public Nullable<int> accountcollectdid { get; set; }

    }
    public class SEL_T002_total_SchQty
    {
        public int item_id { get; set; }
        public string total_sch_qty { get; set; }
    }

    public class COM_T002_B_PopUp
    {
        public int id { get; set; }
        public Nullable<int> follower_id { get; set; }
        public string follower_type { get; set; }
        public string name { get; set; }
        public byte[] Photo { get; set; }
    }
    public class COM_T002_A_PopUp
    {
        public int id { get; set; }
        public int author_id { get; set; }
        public string msg_body { get; set; }
        public byte[] Photo { get; set; }
        public Nullable<bool> starred { get; set; }
        public Nullable<bool> msg_read { get; set; }
        public string add_by { get; set; }
        public string sent_to { get; set; }
    }

    public class ADM_M024_PopUp_FollowerListToadd
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email_id { get; set; }
        public string type { get; set; }
        public Nullable<int> type_id { get; set; }
        public byte[] photo { get; set; }
    }
    public class ADM_M003_PopUpwarehouse
    {
        public string warehouse_id { get; set; }
        public string Warehouse_Name { get; set; }
    }

    public class ZCRM_M001_Invoice
    {
        public int id { get; set; }
        public string inv_no { get; set; }
    }

    public class Para_PopUp
    {
        public int id { get; set; }
        public string Type { get; set; }
        public string SubCatCode { get; set; }
        public int Srno { get; set; }
    }

    public class PUR_T002_A_popup
    {
        public int id { get; set; }
        public string po_no { get; set; }
        public int supplier_id { get; set; }

    }
    public class ZADM_M003_PopUp
    {
        public int wire_size_id { get; set; }
        public Nullable<decimal> wire_size { get; set; }
    }
    public class ZADM_M004_PopUp
    {
        public int wire_type_id { get; set; }
        public string wire_type { get; set; }
    }
    public class ZADM_M008_PopUp
    {
        public int tot_len_id { get; set; }
        public string total_len { get; set; }
    }
    public class ADM_M0032_PopUp
    {
        public int MakeCode { get; set; }

        public string Make { get; set; }
    }

    public class ZSCM_T001_A_Mon
    {

        public int Ord { get; set; }
        public string Month { get; set; }

    }

    public class ZSCM_T001_A_YR
    {
        public string Year { get; set; }

    }
    public class ZSCM_T001_A_Rpt
    {
        public string Month { get; set; }
        public string Year { get; set; }
        public Nullable<DateTime> Date { get; set; }
        public string Header1 { get; set; }
        public Nullable<decimal> avg_blank_wt { get; set; }
        public string Plant { get; set; }
        public Nullable<int> id { get; set; }

    }
    public class ZSCM_T001_A_P
    {
        public Nullable<int> id { get; set; }
        public string average_wt_no { get; set; }
        public Nullable<DateTime> average_wt_dt { get; set; }
    }

    public class ADM_M010_PopUp
    {
        public Nullable<int> id { get; set; }
        //public Nullable<int> empid { get; set; }
        public string AssignToUser { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }

    }
    public class CAL_M004A_EI_PopUp
    {
        public int ExtInstCod { get; set; }
        public string ItemName { get; set; }
    }
    public class QMS_M003_PopUp
    {
        public int id { get; set; }
        public string qualification { get; set; }

    }

    public class SYS_M003_PopUp//Item Category
    {
        public string sditem_cat_code { get; set; }
        public string item_cat_desc { get; set; }
    }
    public class SYS_M005_PopUp// Delivery Type
    {
        public string delivery_type { get; set; }

        public string del_desc { get; set; }

    }
    public class ADM_M022_PopUp_SO//Items From SO
    {
        public int SrNo { get; set; }
        public string sono { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int SubCategCod { get; set; }
        public int unit_id { get; set; }
        public string unit_name { get; set; }
        public int item_id { get; set; }
        public string Description { get; set; }
        public bool Select { get; set; }
        public string stockingunit { get; set; }
        public decimal quantity { get; set; }
        public decimal rate { get; set; }
        public bool Stockble { get; set; }
        public string ild { get; set; }
        public string ink { get; set; }
        public string grade { get; set; }
        public string gross_wt { get; set; }
        public string net_wt { get; set; }
        public Nullable<int> wt_unit { get; set; }
        public string volume { get; set; }
        public Nullable<int> volume_unit { get; set; }
        public string doc_type { get; set; }
    }
    public class SYS_M002_Popup //Document Type
    {
        public string display_doc_type { get; set; }
        public string doc_type { get; set; }
        public string sdoc_type { get; set; }
    }
    public class ADM_M037_Popup//Currency Master
    {
        public int id { get; set; }
        public string curr_code { get; set; }
        public string curr_name { get; set; }
    }
    public class SEL_T001_Popup//Reference doc no's
    {
        public int id { get; set; }
        public string sono { get; set; }
        public string cust_ref { get; set; }
        public string Description { get; set; }
        public string doc_type_id { get; set; }
        public bool Select { get; set; }

        public int item_id { get; set; }
        public string ItemCode { get; set; }
        public string sku { get; set; }
        public decimal quantity { get; set; }
        public decimal bal_qty { get; set; }
        public decimal acc_qty { get; set; }
        public Nullable<System.DateTime> po_date { get; set; }//take as ref_doc_date

    }
    public class ADM_M001_A_Popup//Sale Organisation
    {
        public string so_code { get; set; }
        public string sales_org { get; set; }
    }
    public class ADM_M001_C_Popup//--Distribution Channel
    {
        public string dc_code { get; set; }
        public string dc_name { get; set; }
    }
    public class ADM_M001_D_Popup//---Sales Division
    {
        public string div_code { get; set; }
        public string div_name { get; set; }
    }
    public class ADM_M024_Popup//---Sales Person
    {
        public int id { get; set; }
        public string EmpId { get; set; }
        public string name { get; set; }

    }
    public class ADM_M001_I_Popup//---Sales Office
    {
        public string soff_code { get; set; }
        public string sales_off { get; set; }
    }
    public class ADM_M001_H_Popup//---Sales Group
    {
        public string sg_code { get; set; }
        public string sg_name { get; set; }
    }
    public class ADM_M001_P_Popup//---Sales Group
    {
        public string pg_code { get; set; }
        public string pg_name { get; set; }
    }
    public class ACC_M019_Popup//---Cost Center
    {

        public int id { get; set; }
        public string cc_profit_center { get; set; }
        public string cost_center { get; set; }
    }

    public class ACC_M020_Popup//---Profit Center
    {
        public int id { get; set; }
        public string profit_center { get; set; }
    }

    public class MM_M002_PopUp
    {
        public int id { get; set; }
        public string wa_code { get; set; }
        public string wa_name { get; set; }
    }
    public class MM_M001_PopUp
    {
        public int id { get; set; }

        public string store_code { get; set; }
        public string store_name { get; set; }
    }
    public class SYS_M007_Popup //Document Type (po/quat)
    {
        public int id { get; set; }
        public Nullable<int> company_id { get; set; }
        public string doc_type { get; set; }
        public string doc_type_user { get; set; }
        public string doc_desc { get; set; }
        public string doc_cat { get; set; }
        public string display_doc_type { get; set; }
        public Nullable<bool> default_dc { get; set; }
        public string delivery_type { get; set; }
        public string billing_type { get; set; }
        public string report_name { get; set; }
    }
    public class ADM_M001_M_Popup//po organisation
    {
        public string po_code { get; set; }
        public string pur_org { get; set; }
    }
    public class ADM_M028_PopUp_Deli_Note//Party Master with supplier//
    {
        public int id { get; set; }
        public string PartyNm { get; set; }
        public Nullable<bool> Supplier { get; set; }
        public string PartyId { get; set; }

    }
    public class TSK_T001_B_Folder
    {
        public int id { get; set; }
        public string folder_name { get; set; }
    }
    public class MM_M004_Popup
    {

        public string mov_tp { get; set; }
        public string mov_name { get; set; }

    }

    public class PRO_M003_Popup
    {
        public int PhaseId { get; set; }
        public string phase_name { get; set; }
        public int sequence { get; set; }
        public string description { get; set; }
    }

    public class ADM_M031_PopUp
    {
        public int id { get; set; }
        public string CatParamName { get; set; }

    }
    public class CRM_T002B_PopUp_GRN
    {
        public int id { get; set; }//ADM_M022 SrNo as id
        public string ItemCode { get; set; }//ADM_M022

        public string pono { get; set; }//PUR_T002_B
        public string ItemName { get; set; }//ADM_M022       

        public string customer_code { get; set; }//CRM_T001B CstmrItmCod as 

        public string customer_description { get; set; }//CRM_T001B CstmrItmDesc as
        public string description { get; set; }
        public Nullable<int> unit_id { get; set; } //ADM_M038_B     

        public string unit_name { get; set; }//ADM_M038_B
        public int party_id { get; set; }//ADM_M038_B
        public string SubCategCod { get; set; }//ADM_M022
        public Nullable<bool> Stockble { get; set; }
        public string stockingunit { get; set; }//ADM_M022
        public int poid { get; set; }//PUR_T002_B
        public int po_lineid { get; set; }//PUR_T002_B
        public Nullable<decimal> bal_qty { get; set; }//PUR_T002_B
        public Nullable<decimal> poqty { get; set; }//PUR_T002_B
        public string item_cat { get; set; }
    }

    public class ADM_M037_Popup_PartyWise//Currency Master
    {
        public int id { get; set; }
        public string curr_name { get; set; }
        public Nullable<decimal> rate { get; set; }
    }
    public class MM_T001_GRN_PopUp//Currency Master
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public string grndate { get; set; }
        public string reference { get; set; }
    }

    public class PUR_T005_Popup//Reference doc no's
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public string doc_type { get; set; }
    }

    public class SEL_T001_PopUp_Deli_Note //SO For Delivery Note
    {
        public int id { get; set; }
        public string sono { get; set; }
        public string doc_type_id { get; set; }
        internal bool _Select { get; set; }
        public bool Select { get; set; }
        public Nullable<bool> active { get; set; }
        public string doc_category_id { get; set; }
        public string ref_doc_no { get; set; }
        public string sales_org { get; set; }
        public string sales_div { get; set; }
        public string warehouse_id { get; set; }
        public string distribution_channel { get; set; }
        public string sales_grp { get; set; }
        public string sales_office { get; set; }
        public string business_area { get; set; }
        public Nullable<int> cost_center_id { get; set; }
        public string plant_id { get; set; }
        public Nullable<int> bill_address_id { get; set; }
        public Nullable<int> del_address { get; set; }
        public string InvicAdd { get; set; }
        public string DelAdd { get; set; }
        public string ship_mode { get; set; }
        public string port_load { get; set; }
        public string port_desc { get; set; }
        public string stock_location_id { get; set; }
        public string stock_location { get; set; }
        public string cost_center { get; set; }
        public Nullable<decimal> gross_wt { get; set; }
        public Nullable<decimal> net_wt { get; set; }
        public Nullable<decimal> volume { get; set; }
        public Nullable<int> weightunitid { get; set; }
        public Nullable<int> volumeunitid { get; set; }
        public string doc_type { get; set; }
    }

    public class Order_No_Popup // for delivery note
    {
        public string order_no { get; set; }
        public string doc_category_id { get; set; }
        public string doc_type_id { get; set; }
    }
    public class OrderDetails
    {
        public int bill_address_id { get; set; }
        public int del_address { get; set; }
        public string sales_org { get; set; }
        public string sales_div { get; set; }
        public string sold_to_party { get; set; }
        public string distribution_channel { get; set; }
        public string sales_grp { get; set; }
        public string sales_office { get; set; }
        public string business_area { get; set; }
        public string ship_to_party { get; set; }
        public string pre_carrage { get; set; }
        public string pre_carrage_place { get; set; }
        public string country_code { get; set; }
        public string cf_agent_cd { get; set; }
        public string lic_cod { get; set; }
        public string adv_lic_cd { get; set; }
        public string org_country_cd { get; set; }
        public string transporter_cd { get; set; }
        public string ship_mode { get; set; }
        public string port_desc { get; set; }
        public string final_dest { get; set; }
        public string ship_terms { get; set; }
        public string ship_mark { get; set; }
        public string port_load { get; set; }
    }

    public class ItemDetails
    {
        public string item_code { get; set; }
        public string Description { get; set; }
        public decimal quantity { get; set; }
        public string unit_code { get; set; }
    }
    public class ADM_M028_PopUp_Rpt
    {
        public int id { get; set; }
        public string PartyNm { get; set; }
        public string EmailId { get; set; }

    }


    public class ZADM_M013_Popup1     //Machine Type
    {
        public string mctype { get; set; }

    }

    public class ZADM_M006_PopUp //INK Master
    {
        public int ink_id { get; set; }
        public string ink { get; set; }
        public string desc { get; set; }
        public string make { get; set; }
    }

    public class ZADM_M007_PopUp //ILD Master
    {
        public int ild_id { get; set; }
        public string ild { get; set; }
        public string tip_type { get; set; }
    }


    public class ZADM_M009_PopUp //Model Master
    {
        public int model_id { get; set; }
        public string basicmodel { get; set; }
        public string modelno { get; set; }
        public string modeldesc { get; set; }

    }

    public class SYS_M001_PopUp //Document Category
    {
        public string doc_cat { get; set; }
    }

    public class ZADM_M016_PopUp //Defect Master
    {
        //public Nullable<decimal> dfctcda { get; set; }       
        public int id { get; set; }
        public string dfctdsc { get; set; }
        public string scope { get; set; }
        //public int dftcdu { get; set; }

    }

    public class ZADM_M002_PopUp  //Ball types
    {
        //public int ball_type_id { get; set; }
        public string ball_type { get; set; }
    }

    public class ADM_M028_PopUp1 //Ink Supplier
    {
        public int id { get; set; }
        public string PartyNm { get; set; }
        public bool Customer { get; set; }
        public bool Supplier { get; set; }
    }

    public class ZADM_M001_PopUp  //BallDia
    {
        //public int ball_dia_id { get; set; }
        public decimal Ball_dia { get; set; }
    }

    public class ADM_M022_ESSEM_PopUp
    {
        public int SrNo { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public string shanklen { get; set; }
        public string needle_dia { get; set; }
        public string needlelen { get; set; }
        public string tip_type { get; set; }
        public string prdct_code { get; set; }
        public int Model_id { get; set; }
        public string ModelCode { get; set; }
        public string wire_material { get; set; }
        public string wire_dia { get; set; }
        public string grade { get; set; }


    }
    public class PRO_M001_Popup     //Category master, phasemaster, project transaction
    {
        public int id { get; set; }
        public string sid { get; set; }
        public string name { get; set; }

        // public string Phase_Name { get; set; }
        public string prj_id { get; set; }
        public Nullable<int> sequence { get; set; }
    }




    //public class LOG_T00_PopUp_Sale
    //{

    //    public string grnno { get; set; }//ADM_M038_B    

    //    public string doc_no { get; set; }//ADM_M022  
    //    public Nullable<int> dc_id { get; set; }//ADM_M022 SrNo as id

    //    public string ItemCode { get; set; }//ADM_M022

    //    public string ItemName { get; set; }//ADM_M022
    //    public string so_no { get; set; }
    //    public Nullable<int> SubCategCod { get; set; }//ADM_M022
    //    public string CustCode { get; set; }//CRM_T001B CstmrItmCod as 
    //    public string CustDecrName { get; set; }//CRM_T001B CstmrItmDesc as

    //    public Nullable<decimal> appr_qty { get; set; }
    //    public bool Stockble { get; set; }
    //    public Nullable<decimal> rate { get; set; }
    //    public string stockingunit { get; set; }//ADM_M022
    //    public string tax_id { get; set; }
    //    public Nullable<int> unit_id { get; set; } //ADM_M038_B     
    //    public string unit_name { get; set; }//ADM_M038_B    
    //    public Nullable<int> item_id { get; set; } //ADM_M038_B  
    //    public Nullable<decimal> amount_total { get; set; }
    //    public Nullable<decimal> amount_untaxed { get; set; }
    //    public Nullable<decimal> amount_tax { get; set; }
    //    public string amt_in_words { get; set; }
    //    public string item_cat { get; set; }
    //    public Nullable<decimal> sub_total { get; set; }
    //    public string marks { get; set; }
    //    public string container_no { get; set; }
    //    public string range_no { get; set; }

    //    //public string invoiceNo { get; set; }
    //    //public Nullable<DateTime> Invoicedate { get; set; }
    //    public string challanno { get; set; }
    //    public Nullable<DateTime> challandate { get; set; }
    //    //public string bill_ladding { get; set; }
    //    public Nullable<int> pay_term_id { get; set; }
    //    public string p_term { get; set; }
    //    public string doc_cat { get; set; }
    //    public string entry_time { get; set; }
    //    public Nullable<DateTime> post_date { get; set; }
    //    //public string company_id { get; set; }
    //    //public string companyname { get; set; }

    //    public Nullable<decimal> net_wt { get; set; }//
    //    public Nullable<decimal> gross_wt { get; set; }///
    //    public Nullable<int> wt_unit { get; set; }//
    //    public string wt_unit_nm { get; set; }//
    //    public Nullable<decimal> volume { get; set; }//
    //    public Nullable<int> volume_unit { get; set; }//
    //    public string vol_unit_nm { get; set; }//
    //    public string ladding_bill { get; set; }//
    //    public Nullable<DateTime> ladding_date { get; set; }//
    //    //public string delivery_no { get; set; }
    //    //public Nullable<DateTime> delivery_date { get; set; }
    //    public string shipment_mode { get; set; }//
    //    public string no_of_packages_A { get; set; }//
    //    public Nullable<int> transporter { get; set; }
    //    public Nullable<int> no_of_pkgs { get; set; }//done
    //    public string kind_of_pkgs { get; set; }//done
    //    public Nullable<int> prod_descr_id { get; set; }//
    //    public string prod_descr_nm { get; set; }//done
    //    public Nullable<int> consignee_id { get; set; }//
    //    public string consignee_nm { get; set; }//done

    //    public string pre_carrage { get; set; }//
    //    public string pre_carrage_place { get; set; }//

    //    public string port_load { get; set; }//
    //    public string port_desc { get; set; }//
    //    public string port_final { get; set; }
    //    public string final_dest { get; set; }//
    //    public string ship_terms { get; set; }//
    //    public Nullable<int> cf_agent_id { get; set; }//
    //    public string cf_agent_nm { get; set; }//
    //    public Nullable<int> epcg_id { get; set; }//
    //    public string epcg_nm { get; set; }//
    //    public Nullable<int> adv_lic_id { get; set; }//
    //    public string adv_lic_nm { get; set; }//
    //    public Nullable<int> doc_curr_id { get; set; }//
    //    public string doc_curr_nm { get; set; }//
    //    public Nullable<int> transporter_id { get; set; }//
    //    public string transporter_nm { get; set; }//        
    //    public string warehouse { get; set; }//
    //    public string so_code { get; set; }// 
    //    public string div_code { get; set; }// 
    //    public string dc_code { get; set; }//         
    //    public Nullable<int> dest_country { get; set; }// 
    //    public string dest_country_nm { get; set; }// 
    //    public Nullable<int> cost_center { get; set; }// 
    //    public string cost_center_nm { get; set; }// 
    //    public string fiscal_pos { get; set; }// 
    //    public string journal { get; set; }// 
    //    public Nullable<int> org_country { get; set; }//
    //    public string pack_rem { get; set; }
    //    public string ship_mark { get; set; }//
    //    public string vess_flight { get; set; }//

    //    public string net_weight { get; set; }
    //    public string wt_goods { get; set; }
    //    public Nullable<decimal> item_volume { get; set; }
    //    public string type { get; set; }

    //    public string container { get; set; }
    //    public string currency_nm { get; set; }
    //    public Nullable<int> currency { get; set; }
    //    public string buyer_nm { get; set; }
    //    public Nullable<int> buyer { get; set; }



    //}

    //public class LOG_T00_PopUp_Sale 
    //{
    //    public string doc_no { get; set; }//ADM_M022  
    //    public Nullable<int> dc_id { get; set; }//ADM_M022 SrNo as id

    //    public string ItemCode { get; set; }//ADM_M022

    //    public string ItemName { get; set; }//ADM_M022
    //    public string so_no { get; set; }
    //    public Nullable<int> SubCategCod { get; set; }//ADM_M022
    //    public string CustCode { get; set; }//CRM_T001B CstmrItmCod as 
    //    public string CustDecrName { get; set; }//CRM_T001B CstmrItmDesc as

    //    public Nullable<decimal> appr_qty { get; set; }
    //    public Nullable<decimal> rate { get; set; }
    //    public string stockingunit { get; set; }//ADM_M022
    //    public string tax_id { get; set; }
    //    public Nullable<int> unit_id { get; set; } //ADM_M038_B     
    //    public string unit_name { get; set; }//ADM_M038_B    
    //    public Nullable<int> item_id { get; set; } //ADM_M038_B  

    //    public string grnno { get; set; }//ADM_M038_B    

    //    public Nullable<decimal> amount_total { get; set; }

    //    public Nullable<decimal> amount_untaxed { get; set; }
    //    public Nullable<decimal> amount_tax { get; set; }

    //    public string amt_in_words { get; set; }

    //    public string item_cat { get; set; }

    //    public Nullable<decimal> sub_total { get; set; }

    //    public string invoiceNo { get; set; }

    //    public Nullable<DateTime> Invoicedate { get; set; }

    //    public string challanno { get; set; }
    //    public Nullable<DateTime> challandate { get; set; }
    //    public string bill_ladding { get; set; }
    //    public Nullable<int> pay_term_id { get; set; }
    //    public string p_term { get; set; }
    //    public string doc_cat { get; set; }
    //    public string entry_time { get; set; }
    //    public Nullable<DateTime> post_date { get; set; }

    //    public string company_id { get; set; }
    //    public string companyname { get; set; }

    //    public Nullable<decimal> net_wt { get; set; }
    //    public Nullable<decimal> gross_wt { get; set; }
    //    public Nullable<int> wt_unit { get; set; }
    //    public Nullable<decimal> volume { get; set; }
    //    public Nullable<int> volume_unit { get; set; }
    //    public Nullable<int> cost_center { get; set; }
    //    public string so_code { get; set; }
    //    public string dc_code { get; set; }
    //    public string div_code { get; set; }
    //    public string ladding_bill { get; set; }
    //    public Nullable<DateTime> ladding_date { get; set; }
    //    public string delivery_no { get; set; }
    //    public Nullable<DateTime> delivery_date { get; set; }
    //    public string shipment_mode { get; set; }
    //    public Nullable<int> transporter { get; set; }
    //    public string no_of_packages { get; set; }
    //    public string pre_carrage { get; set; }
    //    public string pre_carrage_place { get; set; }
    //    public Nullable<int> dest_country { get; set; }
    //    public string port_load { get; set; }
    //    public string port_desc { get; set; }
    //    public string port_final { get; set; }
    //    public string final_dest { get; set; }
    //    public string ship_terms { get; set; }
    //    public Nullable<int> cf_agent { get; set; }
    //    public Nullable<int> epcg { get; set; }
    //    public Nullable<int> org_country { get; set; }
    //    public string pack_rem { get; set; }
    //    public string ship_mark { get; set; }
    //    public string vess_flight { get; set; }
    //    public string net_weight { get; set; }
    //    public string wt_goods { get; set; }
    //    public Nullable<decimal> item_volume { get; set; }
    //    public string type { get; set; }


    //}
    public class LOG_T00_PopUp_Sale
    {
        public string grnno { get; set; }//ADM_M038_B    

        public string doc_no { get; set; }//ADM_M022  
        public Nullable<int> dc_id { get; set; }//ADM_M022 SrNo as id
        public string ItemCode { get; set; }//ADM_M022
        public string ItemName { get; set; }//ADM_M022
        public string so_no { get; set; }
        public string SubCategCod { get; set; }//ADM_M022
        public string CustCode { get; set; }//CRM_T001B CstmrItmCod as 
        public string CustDecrName { get; set; }//CRM_T001B CstmrItmDesc as
        public Nullable<decimal> appr_qty { get; set; }
        public bool Stockble { get; set; }
        public Nullable<decimal> rate { get; set; }
        public string sku { get; set; }//ADM_M022
        public string tax_id { get; set; }
        public Nullable<int> unit_id { get; set; } //ADM_M038_B     
        public string unit_code { get; set; } //ADM_M038_B     
        public string unit_name { get; set; }//ADM_M038_B    
        public Nullable<int> item_id { get; set; } //ADM_M038_B  
        public Nullable<decimal> amount_total { get; set; }
        public Nullable<decimal> amount_untaxed { get; set; }
        public Nullable<decimal> amount_tax { get; set; }
        public string amt_in_words { get; set; }
        public string item_cat { get; set; }
        public Nullable<decimal> sub_total { get; set; }
        public string marks { get; set; }
        public string container_no { get; set; }
        public string range_no { get; set; }

        //public string invoiceNo { get; set; }
        //public Nullable<DateTime> Invoicedate { get; set; }
        public string challanno { get; set; }
        public Nullable<DateTime> challandate { get; set; }
        //public string bill_ladding { get; set; }
        public Nullable<int> pay_term_id { get; set; }
        public string p_term { get; set; }
        public string doc_cat { get; set; }
        public string entry_time { get; set; }//string
        public Nullable<DateTime> post_date { get; set; }
        //public string company_id { get; set; }
        //public string companyname { get; set; }

        public Nullable<decimal> net_wt { get; set; }//
        public Nullable<decimal> gross_wt { get; set; }///
        public string wt_unit { get; set; }//
        public string wt_unit_nm { get; set; }//
        public Nullable<decimal> volume { get; set; }//
        public string volume_unit { get; set; }//
        public string vol_unit_nm { get; set; }//
        public string ladding_bill { get; set; }//
        public Nullable<DateTime> ladding_date { get; set; }//
        //public string delivery_no { get; set; }
        //public Nullable<DateTime> delivery_date { get; set; }
        public string shipment_mode { get; set; }//
        public string no_of_packages_A { get; set; }//
        public Nullable<int> transporter { get; set; }
        public Nullable<int> no_of_pkgs { get; set; }//done
        public string kind_of_pkgs { get; set; }//done
        public Nullable<int> prod_descr_id { get; set; }//
        public string prod_descr_nm { get; set; }//done
        public string consignee { get; set; }//
        public string consignee_nm { get; set; }//


        public string pre_carrage { get; set; }//
        public string pre_carrage_place { get; set; }//

        public string port_load { get; set; }//
        public string port_desc { get; set; }//
        public string port_final { get; set; }
        public string final_dest { get; set; }//
        public string ship_terms { get; set; }//
        public Nullable<int> cf_agent_id { get; set; }//
        public string cf_agent_id1 { get; set; }//
        public string cf_agent_nm { get; set; }//
        public Nullable<int> epcg_id { get; set; }//
        public string epcg_nm { get; set; }//
        public Nullable<int> adv_lic_id { get; set; }//
        public string adv_lic_nm { get; set; }//
        public Nullable<int> doc_curr_id { get; set; }//
        public string doc_curr_nm { get; set; }//
        public string transporter_id { get; set; }//
        public string transporter_nm { get; set; }//        
        public string warehouse { get; set; }//
        public string so_code { get; set; }// 
        public string div_code { get; set; }// 
        public string dc_code { get; set; }//         
        public string dest_country { get; set; }// 
        public string dest_country_nm { get; set; }// 
        public string cost_center { get; set; }// 
        public string cost_center_nm { get; set; }// 
        public string fiscal_pos { get; set; }// 
        public string journal { get; set; }// 
        public string org_country_cd { get; set; }//
        public string pack_rem { get; set; }
        public string ship_mark { get; set; }//
        public string vess_flight { get; set; }//
        public decimal net_weight { get; set; }
        public decimal wt_goods { get; set; }
        public Nullable<decimal> item_volume { get; set; }
        public string type { get; set; }

        public string container { get; set; }
        public string curr_code { get; set; }
        public string currency { get; set; }
        public string buyer_nm { get; set; }
        public Nullable<int> buyer { get; set; }
        public string buyer1 { get; set; }
        public Nullable<decimal> discount { get; set; }


        //public string grnno { get; set; }//ADM_M038_B    

        //public string doc_no { get; set; }//ADM_M022  
        //public Nullable<int> dc_id { get; set; }//ADM_M022 SrNo as id

        //public string ItemCode { get; set; }//ADM_M022

        //public string ItemName { get; set; }//ADM_M022
        //public string so_no { get; set; }
        //public Nullable<int> SubCategCod { get; set; }//ADM_M022
        //public string CustCode { get; set; }//CRM_T001B CstmrItmCod as 
        //public string CustDecrName { get; set; }//CRM_T001B CstmrItmDesc as

        //public Nullable<decimal> appr_qty { get; set; }
        //public bool Stockble { get; set; }
        //public Nullable<decimal> rate { get; set; }
        //public string stockingunit { get; set; }//ADM_M022
        //public string tax_id { get; set; }
        //public Nullable<int> unit_id { get; set; } //ADM_M038_B     
        //public string unit_name { get; set; }//ADM_M038_B    
        //public Nullable<int> item_id { get; set; } //ADM_M038_B  
        //public Nullable<decimal> amount_total { get; set; }
        //public Nullable<decimal> amount_untaxed { get; set; }
        //public Nullable<decimal> amount_tax { get; set; }
        //public string amt_in_words { get; set; }
        //public string item_cat { get; set; }
        //public Nullable<decimal> sub_total { get; set; }
        //public string marks { get; set; }
        //public string container_no { get; set; }
        //public string range_no { get; set; }

        ////public string invoiceNo { get; set; }
        ////public Nullable<DateTime> Invoicedate { get; set; }
        //public string challanno { get; set; }
        //public Nullable<DateTime> challandate { get; set; }
        ////public string bill_ladding { get; set; }
        //public Nullable<int> pay_term_id { get; set; }
        //public string p_term { get; set; }
        //public string doc_cat { get; set; }
        //public string entry_time { get; set; }
        //public Nullable<DateTime> post_date { get; set; }
        ////public string company_id { get; set; }
        ////public string companyname { get; set; }

        //public Nullable<decimal> net_wt { get; set; }//
        //public Nullable<decimal> gross_wt { get; set; }///
        //public Nullable<int> wt_unit { get; set; }//
        //public string wt_unit_nm { get; set; }//
        //public Nullable<decimal> volume { get; set; }//
        //public Nullable<int> volume_unit { get; set; }//
        //public string vol_unit_nm { get; set; }//
        //public Nullable<DateTime> ladding_bill { get; set; }//
        //public string ladding_date { get; set; }//
        ////public string delivery_no { get; set; }
        ////public Nullable<DateTime> delivery_date { get; set; }
        //public string shipment_mode { get; set; }//
        //public string no_of_packages_A { get; set; }//
        //public Nullable<int> transporter { get; set; }
        //public Nullable<int> no_of_pkgs { get; set; }//done
        //public string kind_of_pkgs { get; set; }//done
        //public Nullable<int> prod_descr_id { get; set; }//
        //public string prod_descr_nm { get; set; }//done
        //public Nullable<int> consignee_id { get; set; }//
        //public string consignee_nm { get; set; }//done

        //public string pre_carrage { get; set; }//
        //public string pre_carrage_place { get; set; }//

        //public string port_load { get; set; }//
        //public string port_desc { get; set; }//
        //public string port_final { get; set; }
        //public string final_dest { get; set; }//
        //public string ship_terms { get; set; }//
        //public Nullable<int> cf_agent_id { get; set; }//
        //public string cf_agent_nm { get; set; }//
        //public Nullable<int> epcg_id { get; set; }//
        //public string epcg_nm { get; set; }//
        //public Nullable<int> adv_lic_id { get; set; }//
        //public string adv_lic_nm { get; set; }//
        //public Nullable<int> doc_curr_id { get; set; }//
        //public string doc_curr_nm { get; set; }//
        //public Nullable<int> transporter_id { get; set; }//
        //public string transporter_nm { get; set; }//        
        //public string warehouse { get; set; }//
        //public string so_code { get; set; }// 
        //public string div_code { get; set; }// 
        //public string dc_code { get; set; }//         
        //public Nullable<int> dest_country { get; set; }// 
        //public string dest_country_nm { get; set; }// 
        //public Nullable<int> cost_center { get; set; }// 
        //public string cost_center_nm { get; set; }// 
        //public string fiscal_pos { get; set; }// 
        //public string journal { get; set; }// 
        //public Nullable<int> org_country { get; set; }//
        //public string pack_rem { get; set; }
        //public string ship_mark { get; set; }//
        //public string vess_flight { get; set; }//

        //public Nullable<decimal> net_weight { get; set; }
        //public Nullable<decimal> wt_goods { get; set; }
        //public Nullable<decimal> item_volume { get; set; }
        //public string type { get; set; }

        //public string container { get; set; }
        //public string currency_nm { get; set; }
        //public Nullable<int> currency { get; set; }
        //public string buyer_nm { get; set; }
        //public Nullable<int> buyer { get; set; }

        //public string ild { get; set; }
        //public string ink1 { get; set; }
        //public string ink2 { get; set; }
        //public string ink3 { get; set; }
        //public Nullable<int> our_bank { get; set; }
        //public string our_bank_name { get; set; }
        //public Nullable<int> nastro_bank { get; set; }
        //public string nastro_bank_name { get; set; }
        //public Nullable<int> modelpublic { get; set; }


    }

    public class PPC_T001_PopUp // JobCart
    {
        public string doc_no { get; set; }
        public string item_code { get; set; }
        public string so_no { get; set; }
        public decimal jc_qty { get; set; }
        public decimal bal_qty { get; set; }
        public string unit_code { get; set; }
        public string unit_name { get; set; }
        public string description { get; set; }
        public string sku { get; set; }
        public string source_doc_no { get; set; }
        public string batch_no { get; set; }
        public bool Select { get; set; }
        public string SubCategCod { get; set; }
        public Nullable<bool> Stockable { get; set; }
        public string item_srno { get; set; }
        public string sch_no { get; set; }
        public string PartyId { get; set; }
        public Nullable<System.DateTime> ref_date { get; set; }

    }


    public class SEL_T003_A_Popup //invoice
    {
        public int id { get; set; }
        public int sold_party { get; set; }
        public int form_type { get; set; }
        public int fin_year { get; set; }
        public string bill_doc { get; set; }
        public DateTime doc_date { get; set; }
        public decimal sub_total { get; set; }
        public decimal tax_amount { get; set; }
        public decimal invoice_amt { get; set; }
        public string PartyName { get; set; }
        public string Period { get; set; }
        public int adv_lic { get; set; }  //advance Licence No
        public string adv_lic_nm { get; set; }  //advance Licence No
        public int epcg { get; set; }     //EPCG Licence No
        public string epcg_nm { get; set; }     //EPCG Licence No
        public string doc_curr { get; set; } //Currency
        public decimal exc_rate { get; set; } //Exchange Rate
        public int cf_agent { get; set; }  //C&F Agent Id
        public string cf_agent_nm { get; set; }  //C&F Agent Name
        public string trans_mode { get; set; } //Dispach Mode
        public int dest_con { get; set; }    //Final Destination Country
        public string dest_con_nm { get; set; }  //Final Destination Country name
        public string port_final { get; set; } //Final Destination Port
        public decimal wt_gross { get; set; }
        public decimal wt_net { get; set; }
        public string lr_no { get; set; }      //Bill Of ladding
        public DateTime lr_date { get; set; } //Bill Of ladding Date
    }
    public class EPR_T003_A_PopUp //Carton Packing
    {
        public string carton_no { get; set; }
        public string itemcode { get; set; }
        public Nullable<int> unit_id { get; set; }
        public string UOM { get; set; }
        public decimal tot_qty { get; set; }
        public string note { get; set; }
        public string barcode { get; set; }
        public string batch_no { get; set; }
        public decimal net_wt { get; set; }
        public decimal gross_wt { get; set; }
        public string ItemName { get; set; }
        public int Srno { get; set; }
        public string stockingunit { get; set; }
        public Nullable<decimal> bal_qty { get; set; }
        public string INK { get; set; }
        public string ILD { get; set; }
        public string GRADE { get; set; }
        public int id { get; set; }
    }

    public class ZADM_M017_Popup          //Packing Unit
    {
        public int packing_id { get; set; }
        public string pkgunit { get; set; }
    }

    public class ACC_M004_Popup          //Packing Unit
    {
        public int id { get; set; }
        public string bank_name { get; set; }
        public string branch { get; set; }
        public string bank_code { get; set; }
        public string comp_code { get; set; }
    }

    public class MM_S003_PopUp //Batch Stock
    {

        public string batch_no { get; set; }
        public string item_id { get; set; }
        public string sku { get; set; }
        public string unit_Name { get; set; }
        public int uom { get; set; }
        public bool Select { get; set; }
        public string item_Name { get; set; }
        public int SubCategCod { get; set; }
        public Nullable<bool> Stockable { get; set; }
        public int item_srno { get; set; }
        public string so_no { get; set; }
        public decimal packetWt { get; set; }
    }

    public class MM_S003_PopUpBatch //Batch 
    {
        public string batch_no { get; set; }
        public string item_id { get; set; }
        public string sku { get; set; }
        public string item_Name { get; set; }

        public bool Stockable { get; set; }
        public decimal packetWt { get; set; }
    }

    public class ZADM_M019_Popup
    {
        public string airline { get; set; }
    }
    public class ZADM_M022_Popup
    {
        public string CPN { get; set; }
        public string PNO { get; set; }
    }
    public class ECRM_T003_A_PopUp //Writing Test 
    {
        public string prdct_code { get; set; }//prdct_code
    }
    public class ADM_M018_Popup
    {
        public int id { get; set; }
        public string Category { get; set; }
    }
    public class ADM_M019_Popup
    {
        public int id { get; set; }
        public string ItemType { get; set; }
    }
    public class Batch_Popup
    {
        public string Batch { get; set; }
    }
    public class ZADM_M013_PopUp_Engineer          //Engineer From MachineMasterand emp
    {
        public string Engineer { get; set; }
        public Nullable<int> Engineer_id { get; set; }
    }
    public class MM_M005_PopUp // Stock Chart
    {
        public int QuantID { get; set; }
        public int QuantNumber { get; set; }
        public string QuantName { get; set; }
    }
    public class MM_M007_PopUp // StockJournal
    {
        public int trnsID { get; set; }
        public string ItemCode { get; set; }
        public string sku { get; set; }
        public string batch_no { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public string TrnsType { get; set; }
        public string item_Name { get; set; }
        public bool Stockable { get; set; }
        public int SubCategCod { get; set; }
        public string SourceLoc { get; set; }
        public string DestLoc { get; set; }

    }
    public partial class EPR_T002_PopUp
    {
        public string itemcode { get; set; }
        public string batch_no { get; set; }
        public Nullable<int> uom { get; set; }
        public string Unit { get; set; }
        public Nullable<decimal> qty { get; set; }
        //public Nullable<decimal> a_qty { get; set; }
        //public Nullable<decimal> b_qty { get; set; }
        //public Nullable<decimal> c_qty { get; set; }
        public bool Select { get; set; }
    }
    public partial class MM_T003_PopUp
    {
        public Nullable<int> id { get; set; }
        public Nullable<int> req_id { get; set; }
        public string req_no { get; set; }
        public string Emp_code { get; set; }
        public Nullable<int> Emp_id { get; set; }
        public string EmpNm { get; set; }
        public Nullable<int> dept { get; set; }
        public string dept_code { get; set; }
        public string Dept_Name { get; set; }
        public Nullable<int> item_id { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string stockingunit { get; set; }
        public Nullable<int> uom_id { get; set; }
        public string unit_code { get; set; }
        public string UOMNm { get; set; }
        public decimal qty { get; set; }
        public Nullable<int> SubCategCod { get; set; }
        public Nullable<bool> Stockble { get; set; }
        public Nullable<System.DateTime> expected_date { get; set; }
        public string req_ref { get; set; }
        public string location { get; set; }
        public string store_loc { get; set; }
    }
    public class MM_T001_IssueNOPOPup //issueno
    {
        public string doc_no { get; set; }
        public string EmpId { get; set; }
        public string EmpNm { get; set; }
        public string recipient { get; set; }
        public string dept { get; set; }
        public string dept_code { get; set; }
        public string Dept_Name { get; set; }
        public string item_id { get; set; }
        public string ItemName { get; set; }
        public string stockingunit { get; set; }
        public string amt_loc { get; set; }
        public decimal qty { get; set; }
        public string challan_qty { get; set; }
        public string uom { get; set; }
        //public Nullable<int> uom_id { get; set; }
        public string unit_code { get; set; }
        public string unit_price { get; set; }
        public string party_cd { get; set; }
        public string SubCategCod { get; set; }
        public Nullable<bool> Stockble { get; set; }
        public Nullable<System.DateTime> expected_date { get; set; }
        public string location { get; set; }
        public string store_loc { get; set; }


    }
    class PopUpClasses
    {
    }
    public class RequestParameter
    {
        public string REQUEST_TYPE { get; set; }
        public string PLANT { get; set; }
        public int COMPANY { get; set; }
        public int CUSTOMER { get; set; }
        public string ID { get; set; }
    }

    //public class PRO_T001
    //{
    //    public string project_id { get; set; }
    //    public string pcode_1 { get; set; }
    //    public string pcode_2 { get; set; }
    //    public string project_name { get; set; }
    //    public int project_manager { get; set; }
    //    public string privacy_visibility { get; set; }
    //    public string priority { get; set; }
    //    public string status { get; set; }
    //    public Nullable<System.DateTime> start_date { get; set; }
    //    public Nullable<System.DateTime> actual_start { get; set; }
    //    public Nullable<System.DateTime> dead_date { get; set; }
    //    public Nullable<System.DateTime> actual_end { get; set; }
    //    public Nullable<decimal> planned_hours { get; set; }
    //    public Nullable<decimal> hours_spent { get; set; }
    //    public Nullable<decimal> rem_hours { get; set; }
    //    public Nullable<decimal> total_hours { get; set; }
    //    public Nullable<decimal> progress_rate { get; set; }
    //    public int party_id { get; set; }
    //    public string plant_id { get; set; }
    //    public string po_number { get; set; }
    //    public Nullable<decimal> b_amt { get; set; }

    //}
    public class soListForPlan
    {
        public int id { get; set; }
        public string sono { get; set; }
        public string plant_id { get; set; }
        public int company_id { get; set; }
        public string customer_code { get; set; }
        public string customer_name { get; set; }
        public int item_id { get; set; }
        public string ItemCode { get; set; }
        public int machine_id { get; set; }
        public string machine_no { get; set; }
        public string stocking_unit { get; set; }
        public int item_line_id { get; set; }
        public Nullable<decimal> quantity { get; set; } //order qty
        public Nullable<int> uom { get; set; }
        public string uom_name { get; set; }
        public Nullable<int> model_id { get; set; }
        public string model_no { get; set; }
        public string model_description { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public string ball_make { get; set; }
        public string wire_make { get; set; }
        public Nullable<decimal> producedQty { get; set; }
        public Nullable<decimal> balanceQty { get; set; }
        public string orderConfirmDate { get; set; }
    }

    public class ADM_M042_Popup    // shift
    {
        public string shift { get; set; }
    }

    public class PRO_M004_Popup
    {
        public int role_id { get; set; }
        public string role_name { get; set; }
    }
    public class SampleRequest_Rpt
    {
        public string CompName { get; set; }
        private string _LoctnNm;
        public string LoctnNm { get; set; }
        public string Add1 { get; set; }
        public string Add2 { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }
        private string _modelno;
        public string modelno { get; set; }
        public string para1 { get; set; }
        public string para2 { get; set; }
        public string para3 { get; set; }
        public string para5 { get; set; }
        public string para6 { get; set; }
        public string para7 { get; set; }
        public Nullable<decimal> para8 { get; set; }
        public string para10 { get; set; }
        public Nullable<System.DateTime> para13 { get; set; }
        public string para14 { get; set; }
        public string InkSupplier { get; set; }
        public Nullable<System.DateTime> min_planned_date { get; set; }
        public string ContPersnNm { get; set; }
        public string PAdd1 { get; set; }
        public string PAdd2 { get; set; }
        public string PCity { get; set; }
        public string P_Pin { get; set; }
        public string P_CntryName { get; set; }
        public string P_StatName { get; set; }
        public byte[] CompLogo { get; set; }
        public string sono { get; set; }
        public Nullable<System.DateTime> sodate { get; set; }
        public string cust_ref { get; set; }
        public Nullable<decimal> quantity { get; set; }
        public string notes { get; set; }
    }

    public class SaleQuotation_RPT
    {
        public string CompLogo { get; set; }
        public string CompanyName { get; set; }
        public string Company_Address { get; set; }
        public string Add2 { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string PhoneOffice { get; set; }
        public string FaxNo { get; set; }
        public string Mailid { get; set; }
        public string WebSite { get; set; }
        public string StatName { get; set; }
        public string CntryName { get; set; }
        public string PlantCode { get; set; }
        public string PlantNm { get; set; }
        public string Party_Nm { get; set; }
        public string Party_PhoneNo { get; set; }
        public string Party_FaxNo { get; set; }
        public string Party_EmailID { get; set; }
        public string Party_WebSite { get; set; }
        public string Party_Address { get; set; }
        public string Party_City { get; set; }
        public string Party_State { get; set; }
        public string Party_Country { get; set; }
        public string Party_PinCode { get; set; }
        public string buyerNm { get; set; }

        public string so_no { get; set; }
        public Nullable<System.DateTime> so_date { get; set; }
        public string cust_ref { get; set; }
        public Nullable<int> customer_id { get; set; }
        public Nullable<System.DateTime> from_date { get; set; }
        public Nullable<System.DateTime> to_date { get; set; }
        public string notes { get; set; }
        public string item_code { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> quantity { get; set; }
        public string unitNm { get; set; }
        public string pay_term { get; set; }
        public string curr_name { get; set; }
        public Nullable<decimal> unit_price { get; set; }
        public Nullable<decimal> sub_total { get; set; }
        public Nullable<decimal> untax_amt { get; set; }
        public Nullable<decimal> tax_amt { get; set; }
        public Nullable<decimal> total_amt { get; set; }
        public string amt_inword { get; set; }
    }
    public class PUR_T002_A_PopUp //Load Qtn Data on PO using Reference doc no's
    {
        public string po_no { get; set; }
        public Nullable<System.DateTime> po_date { get; set; }
        public string address { get; set; }
        public string supplier_ref { get; set; }
        public Nullable<int> validator { get; set; }
        public string validator_code { get; set; }
        public Nullable<int> del_address_id { get; set; }
        public Nullable<int> bill_address_id { get; set; }
        public string plant_id { get; set; }
        public string comp_code { get; set; }
        public Nullable<int> doc_currency { get; set; }
        public string curr_code { get; set; }
        public Nullable<int> pay_term_id { get; set; }
        public string p_term_code { get; set; }
        public string terms_cond { get; set; }
        public string notes { get; set; }
        public Nullable<System.DateTime> valid_from_date { get; set; }
        public Nullable<System.DateTime> valid_to_date { get; set; }
        public Nullable<System.DateTime> quotation_validity { get; set; }
        public Nullable<System.DateTime> min_planned_date { get; set; }
        public string version { get; set; }
        public string status_po { get; set; }
        public string sales_org { get; set; }
        public string pg_code { get; set; }
        public Nullable<int> supplier_id { get; set; }
        public string PartyId { get; set; }
        public string doc_type { get; set; }
        public Nullable<decimal> amount_tax { get; set; }
        public Nullable<decimal> amount_untaxed { get; set; }
        public Nullable<decimal> amount_total { get; set; }
        public string amt_in_words { get; set; }
    }

    public class ScanSearchLabel
    {
        public string IdNo { get; set; }
        public string SearchTitle { get; set; }
    }
    public class SmallLocalExportBatchDetails
    {
        public int id { get; set; }
        public Nullable<int> carton_id { get; set; }
        public string batch_no { get; set; }
        public Nullable<decimal> qty { get; set; }
        public string note { get; set; }
        public Nullable<int> company_id { get; set; }
        public Nullable<bool> active { get; set; }
        public Nullable<int> add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public Nullable<int> edit_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string plant { get; set; }
        public Nullable<decimal> noofbags { get; set; }
    }
    public class SmallLocalExport
    {
        //public int id { get; set; }
        public string carton_type { get; set; }
        public string packing_type { get; set; }
        public string carton_no { get; set; }
        public Nullable<System.DateTime> carton_pack_dt { get; set; }
        public string barcode { get; set; }
        public string batch_no { get; set; }
        public string itemcode { get; set; }
        public string grade { get; set; }
        public string tip_type { get; set; }
        public Nullable<decimal> qty_per_bag { get; set; }
        public Nullable<decimal> tot_no_bags { get; set; }
        public Nullable<decimal> tot_qty { get; set; }
        public Nullable<decimal> bal_qty { get; set; }
        public Nullable<decimal> net_wt { get; set; }
        public Nullable<decimal> gross_wt { get; set; }
        public string dimension { get; set; }
        public string shipping_mrk { get; set; }
        public string no_kind_pack { get; set; }
        public string mark_and_nos { get; set; }
        public string cust_prod_no { get; set; }
        public Nullable<int> cpnsrno { get; set; }
        public Nullable<int> cpn_model_no { get; set; }
        public string partno { get; set; }
        public string pono { get; set; }
        public string note { get; set; }
        public Nullable<bool> active { get; set; }
        public string ink { get; set; }
        public string UOM { get; set; }
        public string ild { get; set; }
        public string pkgunit { get; set; }
        public string wire_make { get; set; }
        public string ball_make { get; set; }
        public string prod_desc { get; set; }
        public string plant { get; set; }
        public string cust_prod_code { get; set; }
        public string Cust_name { get; set; }

        public Nullable<bool> carton_used_Flg { get; set; }
    }
    public class MergeLabelsSearch
    {
        public string new_batch_no { get; set; }
        public string old_batch_no { get; set; }
        public Nullable<decimal> qty { get; set; }
    }

    public class ProdCartonType
    {
        public string carton_no { get; set; }
        public string CartonType { get; set; }
    }

    public class ProductionLabelsSearch
    {
        public string itemcode { get; set; }
        public string PackingStyle { get; set; }
        public Nullable<decimal> pkgqty { get; set; }
        public Nullable<decimal> label_qty { get; set; }
        public string grade { get; set; }
        public string lblsts { get; set; }
        public int location_id { get; set; }
        public Nullable<decimal> blank_wt { get; set; }
        public string B_batch_no { get; set; }
        public string Prod_Date { get; set; }
        public Nullable<decimal> tip_wt_1 { get; set; }
        public Nullable<decimal> tip_wt_2 { get; set; }
        public Nullable<decimal> tip_wt_3 { get; set; }
        public string INK { get; set; }
        public string ILD { get; set; }
        public Nullable<decimal> counter_qty { get; set; }
        public string Machine { get; set; }
        public string shift { get; set; }
        public string Unit { get; set; }
        public string WireMake { get; set; }
        public string BallMake { get; set; }
        public Nullable<bool> auto_sort { get; set; }
        public string A_batch_no { get; set; }
        public Nullable<decimal> bal_qty_merge { get; set; }
        public Nullable<decimal> net_wt { get; set; }
        public Nullable<bool> mrgflg { get; set; }
        public Nullable<decimal> tip_ave_wt { get; set; }
        public string doc_type { get; set; }
        public Nullable<bool> carton_cons_stat { get; set; }
    }
    public class ACC_M019_CostCenterPopup//---Cost Center
    {
        public string cost_center { get; set; }
        public string cost_center_Desc { get; set; }
    }
    public class ADM_M003_Location_PopUp
    {
        public string Location_Id { get; set; }
        public string LoctnNm { get; set; }
    }

    public class SYS_C011
    {
        public int id { get; set; }
        public string doc_cat { get; set; }
        public string module_code { get; set; }
        public string doc_desc { get; set; }
    }
    public class SYS_C006_A
    {
        public string decimal_format_code { get; set; }
        public string round_up_method_code { get; set; }
        public bool after_decimal { get; set; }
        public string round_type { get; set; }
        public string round_up_value { get; set; }
        public int decimal_digits { get; set; }
        public string decimal_stringformat { get; set; }
    }
    public class SYS_D001
    {
        public int id { get; set; }
        public string field_name { get; set; }
        public string datatype { get; set; }
        public string length { get; set; }
        public bool mandatory { get; set; }
        public string constraints { get; set; }
        public string src_table { get; set; }
        public string src_table_field { get; set; }
        public string info { get; set; }
        public string display_text { get; set; }
        public string trans_mandt { get; set; }
        public string visibility { get; set; }
        public string datatype_code { get; set; }
        public string feature_group { get; set; }
        public string doc_cat { get; set; }
        public string module_code { get; set; }
    }




}
