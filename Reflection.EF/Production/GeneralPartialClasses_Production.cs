using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Production
{

    public partial class EPR_T001_New
    {
        public string XmlDataDocument_EPR_T001 { get; set; }
        public string XmlDataDocument_EPR_T001_Flip { get; set; }
    }
    public class EPR_T002_Flip
    {
        public bool select { get; set; }
        public Nullable<System.DateTime> entry_dt { get; set; }
        public Nullable<System.DateTime> prod_dt { get; set; }
        public string ItemCode { get; set; }
        public int? pack_style { get; set; }
        public Nullable<int> ink_id { get; set; }
        public Nullable<int> ild_id { get; set; }
        public Nullable<int> machine_id { get; set; }
        public string machinecode { get; set; }
        public string shift { get; set; }
        public string conversion { get; set; }
        public decimal counter_qty { get; set; }
        public Nullable<decimal> a_qty { get; set; }
        public Nullable<decimal> b_qty { get; set; }
        public Nullable<decimal> c_qty { get; set; }
        public decimal tip_wt_1 { get; set; }
        public decimal tip_wt_2 { get; set; }
        public decimal tip_wt_3 { get; set; }
        public Nullable<decimal> tip_ave_wt { get; set; }
        public Nullable<decimal> blank_wt { get; set; }
        public string unit_code { get; set; }
        public Nullable<int> wire_make { get; set; }
        public Nullable<int> ball_make { get; set; }
        public Nullable<bool> auto_sort { get; set; }
        public string CustomerProductName { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string Ink { get; set; }
        public string Ild { get; set; }
        public string BallMake { get; set; }
        public string WireMake { get; set; }
        public string PackingUnit { get; set; }
        public Nullable<bool> check { get; set; }
        public string conversion_no { get; set; }
        public Nullable<decimal> rejection_qty { get; set; }
        public string MachinePacCode { get; set; }
        public string ItemName { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string OperatorNm { get; set; }
        //Label Generation Table Fields EPR_T002_A
        public int id { get; set; }
        public Nullable<int> lg_line_id { get; set; }
        public string barcode { get; set; }
        public string batch_no { get; set; }
        public string cust_batch_no { get; set; }
        public Nullable<decimal> label_qty { get; set; }
        public string grade { get; set; }
        public Nullable<decimal> bal_qty_merge { get; set; }
        public Nullable<bool> prod_entry_stat { get; set; }
        public Nullable<bool> carton_cons_stat { get; set; }
        public Nullable<bool> label_complete_stat { get; set; }
        public bool active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public Nullable<decimal> net_wt { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string doc_no { get; set; }
        public string merge_status { get; set; }
        public string parent_label { get; set; }
        public string t_status { get; set; }
        public Nullable<decimal> merge_qty { get; set; }
        public decimal? packing_qty { get; set; }

        // Below Fields Are Used For Merge Label. For E.g pack_style2 is New Packing Style 
        public int? pack_style2 { get; set; }
        public string PartyId2 { get; set; }
        public string m_operator2 { get; set; }
        public string t_display { get; set; }
        public string merge_display { get; set; }
    }

    public partial class ECRM_T003_A_New
    {
        public string XmlDataDocument_ECRM_T003_AFlip { get; set; }
        public string XmlDataDocument_ECRM_T003_B { get; set; }
        public string XmlDataDocument_ECRM_T003_D { get; set; }

    }


    public class EPR_T003_A_Flip
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string carton_type { get; set; }
        public string packing_type { get; set; }
        public string carton_no { get; set; }
        public Nullable<System.DateTime> carton_pack_dt { get; set; }
        public string barcode { get; set; }
        public string batch_no { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string grade { get; set; }
        public int? ink_id { get; set; }
        public int? ild_id { get; set; }
        public string tip_type { get; set; }
        public string unit_code { get; set; }
        public Nullable<int> pack_style { get; set; }
        public Nullable<decimal> qty_per_bag { get; set; }
        public Nullable<decimal> tot_no_bags { get; set; }
        public Nullable<decimal> tot_qty { get; set; }
        public Nullable<decimal> bal_qty { get; set; }
        public int wire_make_id { get; set; }
        public int ball_make_id { get; set; }
        public Nullable<decimal> net_wt { get; set; }
        public Nullable<decimal> gross_wt { get; set; }
        public Nullable<int> prod_desc_id { get; set; }
        public string dimension { get; set; }
        public string shipping_mrk { get; set; }
        public string no_kind_pack { get; set; }
        public string mark_and_nos { get; set; }
        public string cust_prod_no { get; set; }
        public string cust_prod_code { get; set; }
        public Nullable<int> cpnsrno { get; set; }
        public string cpn_model_no { get; set; }
        public string partno { get; set; }
        public string po_no { get; set; }
        public string note { get; set; }
        public Nullable<bool> carton_used_Flg { get; set; }
        public string free_sale { get; set; }
        public bool active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public Nullable<int> no_of_carton { get; set; }
        public Nullable<int> bags_per_carton { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string Ink { get; set; }
        public string Ild { get; set; }
        public string BallMake { get; set; }
        public string WireMake { get; set; }
        public string PackingUnit { get; set; }

        //detail
        public string batch_no_a { get; set; }
        public decimal qty { get; set; }

        //extra

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

    }
    //public partial class EPR_T003_A
    //{
    //    public string XmlDataDocument_EPR_T003_B { get; set; }
    //}
    //public partial class EPR_T002
    //{
    //    public string XmlDataDocument { get; set; }
    //}
    public class ZCRM_T003_BackFlip
    {
        public string doc_no { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string insp_date { get; set; }
        public string machinecode { get; set; }
        public string shift { get; set; }
        public string EmpName { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string t_display { get; set; }

    }
    public partial class ZCRM_T003
    {
        public string BackFlipEntity { get; set; }
        public string XmlDataDocument_ZCRM_T003_A { get; set; }
    }
    public partial class PPC_T003
    {
        public string XmlDataDocument_FlipGrid { get; set; }
        public string BackFlipEntity { get; set; }

    }
    //public partial class ESO_T001
    //{
    //    public string XmlDataDocument_ESO_T001 { get; set; }
    //    public string XmlDataDocument_ESO_T001_A { get; set; }

    //}

    public partial class PPC_T001
    {
        public string XmlDataDocument_PPC_T001 { get; set; }
    }

    public partial class EPR_T002_ILD
    {
        public string shift { get; set; }
        public Nullable<int> machine_id { get; set; }
        public string machinecode { get; set; }
        public string ItemCode { get; set; }
        public string product { get; set; }
        public Nullable<int> ink_id { get; set; }
        public Nullable<int> ild_id { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public Nullable<int> ball_make_id { get; set; }
        public string ball_make { get; set; }
        public Nullable<int> wire_make_id { get; set; }
        public string wire_make { get; set; }
        public Nullable<decimal> counterqty { get; set; }
        public Nullable<decimal> a_qty { get; set; }
        public Nullable<decimal> b_qty { get; set; }
        public Nullable<decimal> c_qty { get; set; }
        public Nullable<decimal> tip_wt_1 { get; set; }
        public Nullable<decimal> tip_wt_2 { get; set; }
        public Nullable<decimal> tip_wt_3 { get; set; }
        public Nullable<decimal> tip_ave_wt { get; set; }
        public Nullable<decimal> avg_blank_wt { get; set; }
        public Nullable<int> uom { get; set; }
        public string Unit { get; set; }
        public Nullable<int> pack_style { get; set; }
        public string unit_name { get; set; }
        public string conv { get; set; }
        public string batch_no { get; set; }
        public int id { get; set; }
        public Nullable<bool> auto_sort { get; set; }
        public string grade { get; set; }
        public string prod_dt { get; set; }
        public string cust_name { get; set; }
        public Nullable<int> cust_prod_nm { get; set; }


    }
    //public partial class EPR_T003_A
    //{
    //    public string XmlDataDocument_EPR_T003_B { get; set; }

    //}
    public partial class EPR_T003_Batch_Data
    {
        public string batch_no { get; set; }
        public string ItemCode { get; set; }
        public string grade { get; set; }
        public Nullable<int> ink_id { get; set; }
        public string ink { get; set; }
        public Nullable<int> ild_id { get; set; }
        public string ild { get; set; }
        public Nullable<int> unit_id { get; set; }
        public string uom { get; set; }
        public Nullable<int> pack_style { get; set; }
        public string pkgunit { get; set; }
        public Nullable<decimal> label_qty { get; set; }
        public Nullable<int> wire_make_id { get; set; }
        public string wire_make { get; set; }
        public Nullable<int> ball_make_id { get; set; }
        public string ball_make { get; set; }
        public Nullable<decimal> NetWt { get; set; }
        public Nullable<decimal> GrossWt { get; set; }
        public Nullable<decimal> tot_no_bags { get; set; }
        public string tip_type { get; set; }

    }


    public partial class EPR_T002_ILD_Report
    {
        public string modelno { get; set; }
        public string batch_no { get; set; }
        public string batch_no1 { get; set; }
        public string batch_no2 { get; set; }
        public string ball_type { get; set; }
        public string shift { get; set; }

        public Nullable<decimal> ball_dia { get; set; }
        public Nullable<int> machine_id { get; set; }
        public string machinecode { get; set; }
        public string ItemCode { get; set; }
        public string product { get; set; }
        public Nullable<int> ink_id { get; set; }
        public Nullable<int> ild_id { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public Nullable<int> ball_make_id { get; set; }
        public string ball_make { get; set; }
        public Nullable<int> wire_make_id { get; set; }
        public string wire_make { get; set; }
        public Nullable<decimal> counterqty { get; set; }
        public Nullable<decimal> a_qty { get; set; }
        public Nullable<decimal> b_qty { get; set; }
        public Nullable<decimal> c_qty { get; set; }
        public Nullable<decimal> tip_wt_1 { get; set; }
        public Nullable<decimal> tip_wt_2 { get; set; }
        public Nullable<decimal> tip_wt_3 { get; set; }
        public Nullable<decimal> tip_ave_wt { get; set; }
        public Nullable<decimal> avg_blank_wt { get; set; }
        public Nullable<int> uom { get; set; }
        public string Unit { get; set; }
        public Nullable<int> pack_style { get; set; }
        public string unit_name { get; set; }
        public string conv { get; set; }
        public int id { get; set; }
        public Nullable<bool> auto_sort { get; set; }
        public string grade { get; set; }
        public string prod_dt { get; set; }
        public Nullable<decimal> net_wt { get; set; }
        public string barcode { get; set; }
        public string barcode1 { get; set; }
        public string barcode2 { get; set; }
        public string ABN { get; set; }
        public string wire_type { get; set; }
        public string shipping_mrk { get; set; }
        public string cust_prod_no { get; set; }
        public Nullable<decimal> gross_wt { get; set; }
        public string Date { get; set; }
        public Nullable<decimal> qtybatch { get; set; }
        public string batchdate { get; set; }
        public Nullable<decimal> netpack { get; set; }
        public string InnerCarton { get; set; }

        public string partno { get; set; }
        public string pono { get; set; }
    }

    //-----------------------------------------

    public class RPT_EPR_T001_ILDChart
    {
        public string MCNo { get; set; }
        public string CodeNo { get; set; }
        public string CPONo { get; set; }
        public string PartyCode { get; set; }
        public string Party { get; set; }
        public string Model { get; set; }
        public string Ballsize { get; set; }
        public string BallMake { get; set; }

        public string WireMake { get; set; }
        public string Ild { get; set; }
        public string Date { get; set; }
        public string ink { get; set; }
        public string remark { get; set; }
        public Nullable<decimal> machineorder { get; set; }
        public string color { get; set; }
        public string ProductCode { get; set; }
        public string Product { get; set; }
        public string BallType { get; set; }
        public string Basket { get; set; }
        public string Spoon { get; set; }
        public string MachineType { get; set; }
        public Nullable<System.DateTime> UDate { get; set; }
        public string INKChanged { get; set; }
        public string ProdChanged { get; set; }
        public string DimChanged { get; set; }
        public string Shape { get; set; }
        public string SF { get; set; }

        public string TotalLen { get; set; }
        public string ShankDia { get; set; }
        public string ShankLen { get; set; }
        public string NeedleDia { get; set; }
        public string NeedleLen { get; set; }
        public string CustEL { get; set; }
        public string location_Id { get; set; }
        public string TipMaterial { get; set; }

    }
    //----------------------------------------
    public class RPT_EPR_T001
    {

        public string order_no { get; set; }
        //public Nullable<System.DateTime> edit_date { get; set; }
        //public System.DateTime add_date { get; set; }
        //public string machinecode{ get; set; }
        //public string model_code{ get; set; }
        //public string ball_dia{ get; set; }
        //public string ild{ get; set; }
        //public string ink{ get; set; }
        //public string wire_make{ get; set; }
        //public string ball_type{ get; set; }
        //public string ball_make{ get; set; }
        //public string sf{ get; set; }
        //public System.DateTime start_dt { get; set; }
        //public string PartyName { get; set; }
        //public string PlantName{ get; set; }

        public int id { get; set; }
        public string company_id { get; set; }
        public string plant { get; set; }
        public int machine_id { get; set; }
        public string so_no { get; set; }
        public string po_no { get; set; }
        public string party_id { get; set; }
        public string shift { get; set; }
        public Nullable<int> conv { get; set; }
        public Nullable<int> model_id { get; set; }
        public string item_code { get; set; }
        public string ball_dia { get; set; }
        public string ball_make { get; set; }
        public string wire_make { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public string tds_no { get; set; }
        public string col { get; set; }
        public string ball_type { get; set; }
        public string basket { get; set; }
        public string spoons { get; set; }
        public string shape { get; set; }
        public string sf { get; set; }
        public string order_type { get; set; }
        public string shank_len { get; set; }
        public string needle_dia { get; set; }
        public string needle { get; set; }
        public System.DateTime start_dt { get; set; }
        public Nullable<System.DateTime> end_dt { get; set; }
        public Nullable<bool> appr { get; set; }
        public Nullable<System.DateTime> apr_dt { get; set; }
        public string apr_by { get; set; }
        public Nullable<System.DateTime> pro_dt { get; set; }
        public string prod_plan { get; set; }
        public string status { get; set; }
        public string Note { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string PlantName { get; set; }
        public string MachineType { get; set; }
        public string MachineCode { get; set; }
        public string ModelCode { get; set; }
        public string Type { get; set; }
        public string PartyName { get; set; }

        public System.DateTime UDate { get; set; }
        public string CodeNo { get; set; }
        public string CPONo { get; set; }
        public string machineorder { get; set; }
        public string Product { get; set; }

        public string INKChanged { get; set; }
        public string ProdChanged { get; set; }
        public string DimChanged { get; set; }
        public Nullable<decimal> TotalLen { get; set; }
        public string ShankDia { get; set; }
        public string CustEL { get; set; }
        public string wire_size { get; set; }
        public string wire_type { get; set; }
        public string tip_type { get; set; }
        public Nullable<decimal> plan_qty { get; set; }
        public string unit_code { get; set; }
        public Nullable<decimal> order_qty { get; set; }

        public string url { get; set; }
        public Nullable<int> plan_item_row_id { get; set; }
    }

    public class RPT_Approval
    {
        public string doc_no { get; set; }
        public Nullable<System.DateTime> appro_date { get; set; }
        public string approvar_remark { get; set; }
        public string appro_status { get; set; }
        public string EmpName { get; set; }
        public string DeptName { get; set; }
    }

    public partial class PPC_T002_A
    {
        public string XmlDataDocument_PPC_T002 { get; set; }

    }

    //class name changed to EPR_T004_A => PPC_T004
    public partial class PPC_T004
    {
        public string XmlDataDocument_PPC_T004_A { get; set; }// name changed to XmlDataDocument_EPR_T004_B => XmlDataDocument_PPC_T004_A      
        public string XmlDataDocument_PPC_T004_B { get; set; }  // name changed to XmlDataDocument_EPR_T004_c => XmlDataDocument_PPC_T004_B
        public string XmlDataDocument_BackFlip { get; set; }
        public string xdoc_PPC_T004_B { get; set; } // name changed to xdoc_EPR_T004_C => xdoc_PPC_T004_B
        public string xdoc_PPC_T004_A { get; set; } // name changed to xdoc_EPR_T004_B => xdoc_PPC_T004_A
        public string xdoc_SEL_T001_P1 { get; set; }

    }

    public partial class ECRM_T005              //Post Export Transaction
    {
        public string XmlDataDocument_ECRM_T005 { get; set; }

    }
    public class ZCRM_T004_RI_Flip
    {
        public string doc_no { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string ItemName { get; set; }
        public string machinecode { get; set; }
        public string shift { get; set; }
        public string EmpLName { get; set; }
        public Nullable<System.DateTime> posting_date { get; set; }
        public string t_display { get; set; }
    }
    public partial class ZCRM_T002
    {
        public string XmlDataDocument_ZCRM_T002_Flip { get; set; }
        public string XmlDataDocument_ZCRM_T002_A { get; set; }
    }
    public partial class ESO_T001
    {
        public string XmlDataDocument_ESO_T001 { get; set; }
        public string XmlDataDocument_ESO_T001_A { get; set; }
        public string XmlDataDocument_ESO_T001FLIP { get; set; }
        public string XmlDataDocument_ESO_T001_B { get; set; }

        private Nullable<System.DateTime> _FrmDate;
        public Nullable<System.DateTime> FrmDate
        {

            get;
            set;
        }//Production FrmDate
        private Nullable<System.DateTime> _ToDate;
        public Nullable<System.DateTime> ToDate
        {
            get;
            set;
        }//Production ToDate

        public Nullable<System.DateTime> SortingDate { get; set; }
        public string FinYear { get; set; }
        //public string shift { get; set; }
        public string Engineer { get; set; }
        public Nullable<int> Engineer_id { get; set; }

        public Nullable<int> machine_id { get; set; }
        //public string defects { get; set; }
        public Nullable<int> defects_id { get; set; }
        public string RptFormat { get; set; }


    }
    
    public partial class ENG_T001Flip
    {
        public string doc_no { get; set; }
        public System.DateTime doc_date { get; set; }
        public string PartyId { get; set; }
        public string bom_cat { get; set; }
        public string t_status { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
    }

    public partial class EPR_T005_A_Flip
    {
        public string doc_no { get; set; }
        public string report_type { get; set; }
        public System.DateTime doc_date { get; set; }
        public System.DateTime prod_date { get; set; }
        public string t_status { get; set; }
        public string value { get; set; }
        public string inkvalue { get; set; }
    }
    public partial class EPR_T005_A
    {
        public string XmlDataDocument_EPR_T005_B { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }
    }


    public class ECRM_T002_AFeedbackRpt
    {
        public int id { get; set; }
        public string quality_feedback_no { get; set; }
        public Nullable<System.DateTime> quality_feedback_date { get; set; }
        public string party_ref_no { get; set; }
        public Nullable<System.DateTime> party_ref_date { get; set; }
        public Nullable<int> model_id { get; set; }
        public string product_name { get; set; }
        public string PartyId { get; set; }
        public int ild_id { get; set; }
        public int ink_id { get; set; }
        public string ild { get; set; }
        public string ink { get; set; }
        public string ink_details { get; set; }
        public Nullable<decimal> invoice_qty { get; set; }
        public Nullable<decimal> defected_qty { get; set; }
        public string note { get; set; }
        public Nullable<bool> rtqfr { get; set; }
        public string rtqfr_no { get; set; }
        public Nullable<System.DateTime> rtqfr_date { get; set; }
        public Nullable<bool> quality_feedback_flg { get; set; }
        public Nullable<System.DateTime> rtqfradddt { get; set; }
        public string rtqfreditby { get; set; }
        public string EmpId { get; set; }
        public Nullable<System.DateTime> rtqfreditdt { get; set; }
        public string test_procedure { get; set; }
        public string test_procedure_result { get; set; }
        public string conclusion { get; set; }
        public string invno { get; set; }
        public Nullable<System.DateTime> invdt { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string cmplnt_RecvBy_cd { get; set; }
        public string cmplnt_HandlBy_cd { get; set; }
        public Nullable<decimal> sampl_qty { get; set; }
        public string sampl_mark { get; set; }
        public string sampl_nm { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string ModelNm { get; set; }
        public string LoctnNm { get; set; }
        public string t_status { get; set; }
        public string sample_status { get; set; }
        public string ItemCode { get; set; }
        public string corrective { get; set; }
        public string verification_effect { get; set; }
        public string suggestion { get; set; }
        public string PartyNm { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string cmplnt_HandlBy_Name { get; set; }
        public string cmplnt_RecvBy_Name { get; set; }
        public string imp_note { get; set; }
        public Nullable<int> defect_id { get; set; }
        public string defect_description { get; set; }
        public Nullable<decimal> no_of_sample { get; set; }
        public string batch_no { get; set; }
        public string observation_test { get; set; }
        public string obsnqa { get; set; }
        public string result_of_test { get; set; }
        public string result_of_test_cust { get; set; }
    }
    public class EPR_T004_AMRPReportEntity
    {
        public string plan_no { get; set; }
        public string planning_item { get; set; }
        public Nullable<decimal> plan_qty { get; set; }
        public string plan_unit { get; set; }
        public string Bom_item { get; set; }
        public Nullable<decimal> bom_qty { get; set; }
        public string BOMUnit { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public Nullable<decimal> qty { get; set; }
        public string sku { get; set; }
        public string unit_code { get; set; }
        public Nullable<decimal> c_factor { get; set; }
        public Nullable<decimal> TotalQty { get; set; }
        public Nullable<decimal> stock_total { get; set; }
        public Nullable<decimal> po_qty { get; set; }
        public Nullable<decimal> stock_reserve { get; set; }
        public Nullable<decimal> ShortageQty { get; set; }


    }

}
