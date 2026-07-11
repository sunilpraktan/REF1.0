using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ADM_M022 : ObjectBase
    {
        public int Srno { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemTypeCd { get; set; }
        public string SubItemTpCd { get; set; }
        public string ProdNmCd { get; set; }
        public string CommCode { get; set; }
        public string MateCode { get; set; }
        public Nullable<bool> BtchFlg { get; set; }
        public string CatCode { get; set; }
        public string SubCatCode { get; set; }
        public string revision { get; set; }
        public string ISCode { get; set; }
        public string AssetCode { get; set; }
        public string DrwgNo { get; set; }
        public string DrgFlNm { get; set; }
        public string unit_code { get; set; }
        public string weight_unit { get; set; }
        public Nullable<decimal> UnitWt { get; set; }
        public string volume_unit { get; set; }
        public Nullable<decimal> UnitVol { get; set; }
        public Nullable<decimal> LdTmManf { get; set; }
        public string SpcFlNm { get; set; }
        public Nullable<bool> BomAlwd { get; set; }
        public string BomItTp { get; set; }
        public Nullable<decimal> ShrkRate { get; set; }
        public Nullable<bool> OutPrsng { get; set; }
        public Nullable<bool> BuildWip { get; set; }
        public Nullable<bool> CostEnbl { get; set; }
        public bool Stockble { get; set; }
        public Nullable<decimal> AvgCon { get; set; }
        public Nullable<decimal> MaxQty { get; set; }
        public Nullable<decimal> MinQty { get; set; }
        public string ItClass { get; set; }
        public Nullable<int> ShelfDay { get; set; }
        public Nullable<decimal> Reorder { get; set; }
        public Nullable<bool> BlkInvnt { get; set; }
        public Nullable<decimal> CarrCost { get; set; }
        public Nullable<bool> StockUnt { get; set; }
        public Nullable<bool> Prchsble { get; set; }
        public Nullable<bool> Sob { get; set; }
        public Nullable<decimal> RandQty { get; set; }
        public string PayTerms { get; set; }
        public Nullable<bool> UnRecpt { get; set; }
        public Nullable<bool> Import { get; set; }
        public Nullable<bool> BlckPurch { get; set; }
        public Nullable<int> RcptErly { get; set; }
        public Nullable<int> RcptLat { get; set; }
        public Nullable<bool> RinReq { get; set; }
        public Nullable<int> SlotSize { get; set; }
        public string RgCode { get; set; }
        public Nullable<bool> Invicble { get; set; }
        public Nullable<bool> Trnstble { get; set; }
        public Nullable<decimal> ExDuty { get; set; }
        public string Warranty { get; set; }
        public Nullable<bool> Taxable { get; set; }
        public Nullable<int> SerDays { get; set; }
        public Nullable<bool> BlckSales { get; set; }
        public string IdentMrk { get; set; }
        public Nullable<bool> CurrSts { get; set; }
        public Nullable<bool> active { get; set; }
        public string prod_type { get; set; }
        public Nullable<decimal> sales_price { get; set; }
        public Nullable<decimal> purchs_price { get; set; }
        public string barcode { get; set; }
        public string Procur_mthd { get; set; }
        public string supply_mthd { get; set; }
        public Nullable<bool> pr_required { get; set; }
        public string purchase_unit { get; set; }
        public Nullable<decimal> cust_leadtm { get; set; }
        public Nullable<int> incm_accnt { get; set; }
        public Nullable<int> expns_accnt { get; set; }
        public string cust_tax { get; set; }
        public string supplier_tax { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string PartyId { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string para1 { get; set; }
        public string para2 { get; set; }
        public string para3 { get; set; }
        public Nullable<int> para4 { get; set; }
        public Nullable<decimal> para5 { get; set; }
        public Nullable<decimal> para6 { get; set; }
        public string para7 { get; set; }
        public string value_class { get; set; }
        public string acc_group { get; set; }
        public string recon_acc { get; set; }
        public string gst_item_group { get; set; }
        public string tax_cat_code { get; set; }
        public string hsn { get; set; }

        public string base_unit { get; set; }
        public string issue_unit { get; set; }
        public string target_qm_sys { get; set; }
        public Nullable<bool> post_insp_stock { get; set; }
        public string mat_auth_grp { get; set; }
        public string control_key { get; set; }
        public string certi_tp { get; set; }
        public Nullable<bool> qm_pur { get; set; }
        public Nullable<System.DateTime> valid_from { get; set; }
        public string sales_unit { get; set; }
        public string stock_unit { get; set; }
        public string lang_key { get; set; }
        public Nullable<bool> batch_auto { get; set; }
        public string item_name_ex { get; set; }
        public string item_name_pi { get; set; }
        public string item_name_awb { get; set; }
        public string item_name_pl { get; set; }
        public string item_name_ci { get; set; }
        public string item_group_code { get; set; }
        public string ind_price { get; set; }
        public string ind_batch_req { get; set; }
        public bool? ind_adv_batch { get; set; }

        //Scalar
        public string gl_name { get; set; }
        public string value_class_desc { get; set; }
        public string group_desc { get; set; }
        public string acc_group_type { get; set; }
        public string CatName { get; set; }
        public string SubCatName { get; set; }
        public string ItemTypeNm { get; set; }
        public string SubItemTpNm { get; set; }
        public string ProdNm { get; set; }
        public string CommName { get; set; }
        public string MateName { get; set; }
        public string AssetNm { get; set; }
        public string unit_name { get; set; }
        public string Weightunit_name { get; set; }
        public string Volumeunit_name { get; set; }
        public string Purchesunit_name { get; set; }
        public string RgName { get; set; }
        public string PartyNm { get; set; }
        public string gst_item_group_Nm { get; set; }
        public string tax_indicator_desc { get; set; }
    }

    public class ADM_M022_B : ObjectBase
    {
        public string item_group_code { get; set; }
        public string item_group_desc { get; set; }
        public string prod_desc { get; set; }
        public string comp_code { get; set; }
    }
}
