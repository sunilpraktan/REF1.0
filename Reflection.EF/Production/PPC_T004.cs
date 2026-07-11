using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Production
{
    //class name changed to EPR_T004_A => PPC_T004
    public partial class PPC_T004 : ObjectBase
    {
        public string plan_no { get; set; }
        public Nullable<System.DateTime> plan_date { get; set; }
        public string source_type { get; set; }
        public string source_no { get; set; }
        public string planning_plant { get; set; }
        public string production_plant { get; set; }
        public string cost_center { get; set; }
        public string t_status { get; set; }
        public bool active { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string t_display { get; set; }
    }

    //class name changed to EPR_T004_B => PPC_T004_A
    public partial class PPC_T004_A
    {
        public int id { get; set; }
        public int line_id { get; set; }
        public string plan_no { get; set; }
        public Nullable<System.DateTime> plan_date { get; set; }
        public string sales_order_no { get; set; }
        public string machine_no { get; set; }
        public string ItemCode { get; set; }
        public string sku { get; set; }
        public string unit_code { get; set; }
        public Nullable<decimal> plan_qty { get; set; }
        public Nullable<System.DateTime> production_date_start { get; set; }
        public Nullable<System.DateTime> production_date_finish { get; set; }
        public string priority { get; set; }
        public string planning_plant { get; set; }
        public string production_plant { get; set; }
        public string reference_no { get; set; }
        public string PartyId { get; set; }
        public Nullable<System.DateTime> order_confirm_date { get; set; }
        public Nullable<decimal> order_qty { get; set; }
        public string sch_no { get; set; }
        public string source_no { get; set; }
        public Nullable<int> week_no { get; set; }
        public Nullable<bool> job_card_done { get; set; }
        public string sono { get; set; }
        public string remark { get; set; }
        public string para1 { get; set; }
        public string para2 { get; set; }
        public string para3 { get; set; }
        public string para4 { get; set; }
        public string para5 { get; set; }
        public string para6 { get; set; }
        public string para7 { get; set; }
        public string para8 { get; set; }
        public string para9 { get; set; }
        public string para10 { get; set; }
        public string t_status { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public bool active { get; set; }
        public string add_by { get; set; }
        public System.DateTime? add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public Nullable<int> machine_id { get; set; }
        public string bom_no { get; set; }
        public string client { get; set; }
        public string wc_code { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string order_type { get; set; }
        public string pro_type { get; set; }
        public string spl_pro_type { get; set; }
        public decimal? scrap_qty { get; set; }
        public decimal? req_qty { get; set; }
        public string ind_conv { get; set; }
        public string acc_cat { get; set; }
        public string po_code { get; set; }
        public string pg_code { get; set; }
        public string con_posting { get; set; }
        public string task_list_group { get; set; }
        public int? group_counter { get; set; }
        public string task_list_type { get; set; }
        public string ind_backflush { get; set; }
        public string req_plan_no { get; set; }
        public string routing_no { get; set; }
        public string bom_exp_no { get; set; }

        //scaler
        public string uom_name { get; set; }
        public string ItemName { get; set; }
        public string ink_SCLR { get; set; }
        public string ild_SCLR { get; set; }
        public string BallMake_SCLR { get; set; }
        public string WireMake_SCLR { get; set; }
        public string BallType_SCLR { get; set; }
        public string WireSize_SCLR { get; set; }
        public int? sr_no { get; set; }
        public bool? order_exists { get; set; }
        public string order_no { get; set; }
        public string pre_order_no { get; set; }
        public int pack_style { get; set; }
        public string pk_unit_code { get; set; }
        public string store_code { get; set; }
        public decimal? produced_qty { get; set; }
        public decimal? balance_qty { get; set; }
    }

    //class name changed to EPR_T004_C => PPC_T004_B
    public partial class PPC_T004_B
    {
        public int id { get; set; }
        public int line_id { get; set; }
        public string plan_no { get; set; }
        public string machine_no { get; set; }
        public string ItemCode { get; set; }
        public string sku { get; set; }
        public Nullable<decimal> qty { get; set; }
        public string unit_code { get; set; }
        public string t_status { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public bool active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string sono { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public Nullable<int> so_item_row_id { get; set; }
        public Nullable<int> plan_item_row_id { get; set; }
        public string revision { get; set; }
        public int? sr_no { get; set; }
        public string order_no { get; set; }
        public string PartyNm { get; set; }
        public string CustNm { get; set; }
        public Nullable<System.DateTime> sodate { get; set; }
    }
}
