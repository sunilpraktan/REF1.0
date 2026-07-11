using Reflection.EF.Communication;
using Reflection.EF.Procurement;
using Reflection.EF.ReflectionSystem;
using Reflection.EF.SCM.ReportEntitySCM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.SCM
{
    public partial class MM_T001 : ObjectBase
    {
        public string doc_no { get; set; }
        public Nullable<int> id { get; set; }
        public string comp_code { get; set; }
        public Nullable<System.DateTime> doc_edate { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public Nullable<int> doc_year { get; set; }
        public string trns_type { get; set; }
        public string ge_no { get; set; }
        public Nullable<System.DateTime> ge_date { get; set; }
        public string doc_code { get; set; }
        public string doc_cat { get; set; }
        public string source_doc_cat { get; set; }
        public string source_doc_type { get; set; }
        public string source_doc_no { get; set; }
        public string vendor { get; set; }
        public string PartyId { get; set; }
        public Nullable<System.DateTime> post_date { get; set; }
        public string bill_ladding { get; set; }
        public Nullable<System.DateTime> bill_ladding_dt { get; set; }
        public string grgi_slip_no { get; set; }
        public string del_note { get; set; }
        public Nullable<System.DateTime> del_note_date { get; set; }
        public Nullable<System.DateTime> receipt_date { get; set; }
        public string tranp_mode { get; set; }
        public string transport_party { get; set; }
        public Nullable<System.TimeSpan> entry_time { get; set; }
        public string ref_doc { get; set; }
        public string order_doc_type { get; set; }
        public string order_doc_no { get; set; }
        public Nullable<System.DateTime> ref_doc_date { get; set; }
        public string time_zone { get; set; }
        public string mov_tp { get; set; }
        public string EmpId { get; set; }
        public string dept_code { get; set; }
        public string notes { get; set; }
        public Nullable<bool> active { get; set; }
        public System.DateTime add_date { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
        public string t_status { get; set; }
        public string location_Id { get; set; }
        public string vehicle_no { get; set; }
        public string doc_type { get; set; }
        public string cash_credit_pur { get; set; }
        public string posting_period { get; set; }
        public string fin_year { get; set; }
        public string mov_name { get; set; }
        public string Req_Name { get; set; }
        public string Dept_Name { get; set; }
        public string tranp_agency_name { get; set; }
        public string PlantName { get; set; }
        public string vendor_name { get; set; }
        public string sending_plant { get; set; }
        public string rec_plant { get; set; }
        public string sendplantnm { get; set; }
        public string recplantnm { get; set; }
        public string doc_history_no { get; set; }
        public string pur_org { get; set; }
        public string pg_name { get; set; }
        public string po_code { get; set; }
        public string pg_code { get; set; }
        public string com_inv_no { get; set; }

        //New Fields Added on 12/12/2016
        public string curr_code { get; set; }
        public Nullable<decimal> amt_doccurr { get; set; }
        public Nullable<decimal> amt_loccurr { get; set; }
        public Nullable<decimal> ex_rate { get; set; }
        public Nullable<bool> debcr_ind { get; set; }
        public string gl_code { get; set; }
        public string posting_key { get; set; }
        public string lang_key { get; set; }
        public string status_remark { get; set; }
        public string way_bill_no { get; set; }
        public Nullable<System.DateTime> way_bill_date { get; set; }
        public Nullable<decimal> way_bill_value { get; set; }
        public string project_id { get; set; }
        public string project_name { get; set; }
        public string project_loc { get; set; }
        public string sono { get; set; }
        public string bom_no { get; set; }
        public string tr_party { get; set; }
        public string tr_mode { get; set; }
        public string tr_type { get; set; }

        //Scalar
        public Nullable<System.DateTime> From_Date { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public string Grade { get; set; }
        public Nullable<System.DateTime> ProdDate { get; set; }
        public string ink_id { get; set; }
        public string ink { get; set; }
        public string ild_id { get; set; }
        public string ild { get; set; }
        public string t_display { get; set; }
        public string tr_name { get; set; }
        public string barcode { get; set; }
        

        public string party_address { get; set; }
        public string billing_address { get; set; }
        public string delivery_address { get; set; }

        public string add_code_del { get; set; } // NOTE: Make this column and address for plant. do not use plant code for address, use adress code for plant. now we are using plant code as address.
        public string add_code_bil { get; set; } // NOTE: Make this column and address for plant. do not use plant code for address, use adress code for plant. now we are using plant code as address.
        public string emp_id { get; set; }
        public string emp_name { get; set; }
        public string party_name { get; set; }
        //public string ts_code { get; set; }
        public string doc_type_name { get; set; }
        public string released_by { get; set; }
    }
    public partial class MM_T001_A : ObjectBase
    {
        public int id { get; set; }
        public int line_id { get; set; }
        public Nullable<int> sr_no { get; set; }
        public string group_code { get; set; }
        public string group_company { get; set; }
        public string comp_code { get; set; }
        public Nullable<int> doc_year { get; set; }
        public Nullable<System.DateTime> doc_edate { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string doc_no { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string mov_tp { get; set; }
        public string wa_code { get; set; }
        public string store_code { get; set; }
        public string store_bin_code { get; set; }
        public string mat_no { get; set; }
        public string mov_ind { get; set; }
        public Nullable<int> wear_mov_tp { get; set; }
        public string wh_mov_no { get; set; }
        public string sp_stock_ind { get; set; }
        public string stock_type { get; set; }
        public Nullable<decimal> c_factor { get; set; }
        public string batch_no { get; set; }
        public Nullable<bool> batch_split { get; set; }
        public string batch_rus { get; set; }
        public string ItemCode { get; set; }
        public string sku { get; set; }
        public string sku_desc { get; set; }
        public string vendor { get; set; }
        public string PartyId { get; set; }
        public string sono { get; set; }
        public string so_item_cd { get; set; }
        public string curr_code { get; set; }
        public Nullable<decimal> amt_loc { get; set; }
        public Nullable<decimal> qty { get; set; }
        public Nullable<decimal> challan_qty { get; set; }
        public string unit_code { get; set; }
        public Nullable<decimal> unit_price { get; set; }
        public string debcr_ind { get; set; }
        public string delv_completed_ind { get; set; }
        public string source_doc_type { get; set; }
        public string source_doc_no { get; set; }
        public string po_no { get; set; }
        public Nullable<int> po_line_no { get; set; }
        public string fin_year_rd { get; set; }
        public string ref_doc_no { get; set; }
        public string ref_doc_type { get; set; }
        public string order_doc_type { get; set; }
        public string order_doc_no { get; set; }
        public string ref_doc_item_cd { get; set; }
        public string mat_doc_no { get; set; }
        public string mat_doc_item_cd { get; set; }
        public string receipient_party_cd { get; set; }
        public string bus_area { get; set; }
        public string cost_center { get; set; }
        public string profit_center { get; set; }
        public string order_no { get; set; }
        public string asset_no { get; set; }
        public string fin_year { get; set; }
        public string per_posting { get; set; }
        public string acc_doc_no { get; set; }
        public Nullable<int> acc_doc_line { get; set; }
        public string res_no { get; set; }
        public Nullable<int> res_line { get; set; }
        public string ri_item { get; set; }
        public string ri_sku { get; set; }
        public string ri_unit_cd { get; set; }
        public Nullable<decimal> ri_qty { get; set; }
        public string ri_plant { get; set; }
        public string ri_wa_code { get; set; }
        public string ri_store_code { get; set; }
        public Nullable<int> ir_bin { get; set; }
        public string ir_batch { get; set; }
        public string sts_tbatch { get; set; }
        public string tr_req_no { get; set; }
        public string tr_req_item_cd { get; set; }
        public string to_no { get; set; }
        public string cons_post { get; set; }
        public string receipt_ind { get; set; }
        public string gl_acc_no { get; set; }
        public Nullable<System.DateTime> shelf_life_date { get; set; }
        public string gr_insp_sts { get; set; }
        public string storage_tp { get; set; }
        public string stock_cat { get; set; }
        public string wm_mov_tp_cd { get; set; }
        public Nullable<int> mov_reason { get; set; }
        public Nullable<int> tax_code { get; set; }
        public string tax_jur { get; set; }
        public Nullable<System.DateTime> mfg_date { get; set; }
        public string note { get; set; }
        public Nullable<int> machine_id { get; set; }

        public string mat_con { get; set; }
        public string para1 { get; set; }
        public string para2 { get; set; }
        public string para3 { get; set; }
        public string para4 { get; set; }
        public string para5 { get; set; }
        public bool active { get; set; }
        public System.DateTime add_date { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
        public string item_cat { get; set; }
        public Nullable<bool> item_ok { get; set; }
        public string t_status { get; set; }
        public string location_Id { get; set; }
        public string vendor_batch_no { get; set; }
        public Nullable<decimal> para6 { get; set; }
        public Nullable<decimal> para7 { get; set; }
        public string cash_credit_pur { get; set; }
        public string description { get; set; }
        public string gl_code { get; set; }
        public string posting_period { get; set; }
        public Nullable<bool> StockUnt { get; set; }
        public string unit_Name { get; set; }
        public string cost_center_Nm { get; set; }
        public string SubCatCode { get; set; }
        public string Plant_Name { get; set; }
        public string machinecode { get; set; }
        public Nullable<decimal> po_qty { get; set; }
        public string ItemNm { get; set; }
        public string po_code { get; set; }
        public string pg_code { get; set; }
        public string CompName { get; set; }
        //public Nullable<decimal> tip_ave_wt { get; set; }


        //New Fields Added on 12/12/2016
        public Nullable<int> ref_item_line_id { get; set; }
        public string bom_no { get; set; }
        public string status_remark { get; set; }
        public Nullable<int> source_doc_itemline_id { get; set; }
        public Nullable<int> order_doc_item_id { get; set; }
        public string lang_key { get; set; }
        public string client { get; set; }
        public Nullable<System.DateTime> post_date { get; set; }
        public string project_id { get; set; }
        public string project_name { get; set; }
        public string project_loc { get; set; }
        public string wc_code { get; set; }
        public int? ref_doc_item_row_id { get; set; }
        public string ref_doc_cat { get; set; }
        public int? po_item_row_id { get; set; }
        public int? req_item_row_id { get; set; }
        public int? so_item_row_id { get; set; }
        public string order_doc_cat { get; set; }
        public int? dn_item_row_id { get; set; }
        public string posting_key { get; set; }

        //Scalar
        public decimal? IssuedQty { get; set; }
        public string t_display { get; set; }
        public string textdata { get; set; }
        public string confirmation_no { get; set; }
        public string barcode { get; set; }
        public string store_name { get; set; }

        public string equip_no { get; set; }
        public string equip_name { get; set; }
        public string manufacturer { get; set; }
        public string mfg_model { get; set; }
        public string mfg_srno { get; set; }
        public string emp_id { get; set; }
        public string emp_name { get; set; }
        public DateTime? return_date { get; set; }
        public string return_doc { get; set; }

    }
    public partial class MM_T001_B
    {
        public int id { get; set; }
        public Nullable<int> grn_id { get; set; }
        public int item_line_id { get; set; }
        public string doc_no { get; set; }
        public string ItemCode { get; set; }
        public Nullable<int> sr_line_no { get; set; }
        public string batch_no { get; set; }
        public string vendor_batch_no { get; set; }
        public Nullable<decimal> qty { get; set; }
        public Nullable<decimal> rec_qty { get; set; }
        public string unit_code { get; set; }
        public string description { get; set; }
        public string t_status { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string wa_code { get; set; }
        public string store_code { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public Nullable<decimal> para1 { get; set; }
        public Nullable<decimal> para2 { get; set; }
        public Nullable<decimal> para3 { get; set; }
        public Nullable<decimal> para4 { get; set; }
        public Nullable<decimal> para5 { get; set; }
        public Nullable<decimal> para6 { get; set; }
        public Nullable<decimal> para7 { get; set; }
        public string sku { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string po_code { get; set; }
        public string pg_code { get; set; }
        public string client { get; set; }
        public int? ref_batch_row_id { get; set; }
        //Scalar
        public string t_display { get; set; }
        public string confirmation_no { get; set; }
        public string barcode { get; set; }
        public string pack_no { get; set; }
        public string order_no { get; set; }
        public string ref_doc_cat { get; set; }
        public string ref_doc_no { get; set; }
        public string ref_item_row_id { get; set; }

        //Scalar
        public string item_name { get; set; }
        public string item_name_order { get; set; }


    }
    public partial class MM_T001_C
    {
        public int id { get; set; }
        public Nullable<int> line_id { get; set; }
        public Nullable<int> sr_line_no { get; set; }
        public string ItemCode { get; set; }
        public string sku { get; set; }
        public string po_no { get; set; }
        public Nullable<int> po_line_no { get; set; }
        public decimal po_qty { get; set; }
        public decimal allocated_qty { get; set; }
        public Nullable<decimal> challan_qty { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string t_status { get; set; }
        public Nullable<bool> active { get; set; }
        public System.DateTime add_date { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string doc_no { get; set; }
        public Nullable<decimal> rec_qty { get; set; }
        //Scalar
        public string t_display { get; set; }
    }

    public class MC_MM_T001 : MC_MM_BE
    {
        public List<STD_LIST_BE> GATE_ENTRY_LIST { get; set; }
        public List<MM_T001> MASTER_ENTITY_LIST { get; set; }
        public List<MM_T001_A> ITEMS_ENTITY_LIST { get; set; }
        public List<MM_T001_B> BATCH_ENTITY_LIST { get; set; }




        public List<ADM_M028_P> PartyList { get; set; }
        public List<ADM_M028_P> TransporterList { get; set; }
        public List<MM_M004_P> MovementTypeList { get; set; }
        public List<SYS_M007_P> DocTypeList { get; set; } // PO Document Type List
        public List<SYS_DOC_CAT> DocCatList { get; set; }
        public List<SYS_DOC_CAT> ReferenceDocCatList { get; set; } // Need Reference doc_cat list
        public List<REF_DOC_MM_T001> ReferenceDocumentList { get; set; }   // Make Common for all Reference doc
        public List<ADM_M038_B_P> UOMList { get; set; }
        public List<MM_M001_P> StoreCodeList { get; set; }
        public List<ADM_M030_P> ParamValueList { get; set; } // Load this on Execute of Reference Document
        public List<ADM_M031_P> ParameterList { get; set; }
        public List<MM_T001_FLIP> FlipGridList { get; set; }  // Change to Standard
        public List<MM_T001> MasterList { get; set; }
        public List<MM_T001_A> ItemList { get; set; }
        public List<MM_T001_B> BatchList { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<NotificationData> NotificationData { get; set; }
        public List<SYS_M025> StatusList { get; set; }
        public List<SYS_M026> TransportMode { get; set; }
        public List<ADM_M024_POP> PersonnelList { get; set; }
        public List<ADM_M025_P> DepartmentList { get; set; }
        public List<PUR_T002_A_P> SourceDocNoList { get; set; }   // PO Number List
        public List<ADM_M022_P> ItemPopupList { get; set; }  // Item List
        public List<SYS_M008_P> ItemCatList { get; set; }  // Item Category List
        public List<MM_T001> GRNMasterList { get; set; }   // Goods Receipt Note List Master Transaction
        public List<MM_T001_A> ItemDetailsList { get; set; }  // Item Details List of GRN
        public List<MM_T001_B> BatchDetailsList { get; set; } // Batch Details List of GRN
        public List<MM_T001_C> POAllocDetailsList { get; set; } // PO Allocation Details List
        public List<PUR_T002_A> LoadDocList { get; set; } // PO LOAD LIST
        public List<PUR_T002_B> LoadPOItemsList { get; set; } // PO LOAD LIST
        public List<RptGRN> RptGRN { get; set; }
        public List<SYS_M025> t_statusList { get; set; }


        public List<MM_T001Flip> DocumentDataFlipGrid { get; set; }
        public List<ADM_M024_P> Requster { get; set; }
        public List<ADM_M025_P> deptList { get; set; }  //Department Master   
                                                        //public List<ADM_M003_P> plant { get; set; }  //Plant Master
        public List<ADM_M022_P> items { get; set; }  //Item Master
        public List<ADM_M038_B_P> unitList { get; set; }  //Unit Master
        public List<MM_M001_P> store { get; set; }  //Storage Location Master
        public List<MM_S003_P> batchList { get; set; }
        public List<MM_T003_P> IndentOrIndentNoList { get; set; }//Indent Order
        public List<Order_No_P> OrderDocNoList { get; set; }
        public List<MM_T001> DocumentMaster { get; set; }  //Goods Issue
        public List<MM_T001_A> GoodsA { get; set; }  // MM_T001_A 
        public List<MM_T001_B> ItemBatchDetails { get; set; }
        public List<ZADM_M013_P> MachineCodeList { get; set; }
        public List<EPR_T003_A_P> CartonsList { get; set; }
        public List<MaterialIssue> RptMaterialIssue { get; set; }
        public List<MaterialIssueItem> RptMaterialIssueItem { get; set; }
        public List<MaterialIssueBatch> RptMaterialIssueBatch { get; set; }
        public List<MM_T003_P> ReturnIndentNo { get; set; }


        public List<MM_M004_P> MovementDetails { get; set; }
        public List<ZADM_M006_P> InkDetails { get; set; }
        public List<ZADM_M007_P> IldDetails { get; set; }
        public List<ADM_M045_P> GradeDetails { get; set; }
        public List<ADM_M022_POPUP> SourceItemDetails { get; set; }
        public List<ADM_M022_POPUP> RMItemDetails { get; set; }
        public List<ADM_M031_P> ParameterDetails { get; set; }
        public List<ADM_M030_P> ParameterValueDetails { get; set; }
        public List<ADM_M038_B_P> UOMDetails { get; set; }
        public List<MM_T001> MasterEntity { get; set; }
        public List<MM_T001_A> ItemsEntity { get; set; }
        public List<COM_T003> AttachmentData { get; set; }
        public List<ADM_M030_P> MakeDetails { get; set; }
        public List<ADM_M030_P> TypeDetails { get; set; }
        public List<ADM_M030_P> MaterialConditionDetails { get; set; }
        public List<PRO_T001_P> Project { get; set; }
    }
    public class MM_T001_FLIP // Standard Backflip Entity
    {
        public string doc_no { get; set; }
        public System.DateTime doc_date { get; set; }
        public System.DateTime post_date { get; set; }
        public string t_status { get; set; }
        public string source_doc_no { get; set; }
        public string mov_name { get; set; }
        public string vendor { get; set; }
        public string sendplantnm { get; set; }
        public string recplantnm { get; set; }
        public string com_inv_no { get; set; }
        public bool allocation { get; set; }
        public string mov_tp { get; set; }
        public string t_display { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string del_note { get; set; }
        public string ref_doc { get; set; }
        public string way_bill_no { get; set; }
        public string color_code { get; set; }
    }

    public class MC_MM_T001_STD : STD_MC_BE
    {
        public List<MM_M004> MOV_TYPE_LIST { get; set; }
        public List<SYS_M026> TRANSPORT_MODE_LIST { get; set; }
        public List<ADM_M028_P> TRANSPORTER_LIST { get; set; }
        public List<MM_T001> MASTER_BE_LIST { get; set; }
        public List<MM_T001_A> ITEM_BE_LIST { get; set; }
        public List<MM_T001_B> BATCH_BE_LIST { get; set; }
        public List<MM_T001_C> ALLOCATION_BE_LIST { get; set; }

    }
}
