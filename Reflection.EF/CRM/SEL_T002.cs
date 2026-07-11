using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.CRM
{
    public partial class SEL_T002 : ObjectBase
    {
        public string sch_no { get; set; }
        public int? id { get; set; }
        public string ref_type { get; set; }
        public string PartyId { get; set; }
        public string ref_no { get; set; }
        public System.DateTime? sch_date { get; set; }
        public string sch_time { get; set; }
        public string EmpId { get; set; }
        public string sch_mode { get; set; }
        public string sch_rec_by_cd { get; set; }
        public string remark { get; set; }
        public Nullable<bool> active { get; set; }
        public System.DateTime? add_date { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
        public string t_status { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string sch_by { get; set; }
        public string PartyNm { get; set; }
        public string employee_name { get; set; }
        public string contact_name { get; set; }
        public int? ContInfoId { get; set; }
        public string cust_ref { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string ref_doc_no { get; set; }
        public string ref_doc_type { get; set; }
        public string ref_doc_cat { get; set; }
        public int? del_address { get; set; }
        public string del_add { get; set; }
        public string Location { get; set; }
        public Nullable<System.DateTime> ref_doc_date { get; set; }
        public string status_remark { get; set; }
        public string add_code_del { get; set; }
        public string cp_code { get; set; }
        public string t_display { get; set; }
    }
    public partial class SEL_T002_A : ObjectBase
    {
        public int? id { get; set; }
        public string sch_cat { get; set; }
        public string del_rel { get; set; }
        public string sch_no { get; set; }
        public string sono { get; set; }
        public string ref_no { get; set; }
        public int? line_id { get; set; }
        public string ItemCode { get; set; }
        public string unit_code { get; set; }
        public Nullable<decimal> sch_qty { get; set; }
        public Nullable<System.DateTime> exp_date { get; set; }
        public Nullable<System.DateTime> desp_date { get; set; }
        public Nullable<decimal> confirm_qty { get; set; }
        public Nullable<decimal> confirm_qty_org { get; set; }
        public Nullable<System.DateTime> confirm_date { get; set; }
        public Nullable<decimal> del_qty { get; set; }
        public Nullable<System.DateTime> del_date { get; set; }
        public string po_req_no { get; set; }
        public Nullable<int> item_no_po_req { get; set; }
        public string remark { get; set; }
        public string desp_id { get; set; }
        public Nullable<bool> active { get; set; }
        public System.DateTime? add_date { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
        public string t_status { get; set; }
        public string sku { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public Nullable<decimal> rate { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string rel_delivery { get; set; }
        public string rel_billing { get; set; }
        public Nullable<int> so_item_id { get; set; }
        public Nullable<decimal> order_qty { get; set; }
        public string confirm_status { get; set; }
        public Nullable<bool> del_block { get; set; }
        public string mov_tp { get; set; }
        public string sku_desc { get; set; }
        public string ItemName { get; set; }
        public string unit_name { get; set; }
        public Nullable<System.DateTime> sch_date { get; set; }
        public int? Lead_Time1 { get; set; }
        public int? Lead_Time2 { get; set; }
        public string custItemcode { get; set; }
        public string ship_mode { get; set; }
        public string PartyId { get; set; }
        public string para1 { get; set; }
        public string para2 { get; set; }
        public string para3 { get; set; }
        public string PartyNm { get; set; }
        public string ref_doc_no { get; set; }
        public string ref_doc_type { get; set; }
        public string ref_doc_cat { get; set; }
        public Nullable<System.DateTime> ref_doc_date { get; set; }
        public string status_remark { get; set; }
        public string lead_uom { get; set; }
        public decimal? lead_time { get; set; }
        public decimal? bal_qty { get; set; }
        public string t_display { get; set; }
        public string ship_to_party { get; set; }
        public string ship_to_party_name { get; set; }
        public string ship_to_add { get; set; }
        public string ship_to_addNm { get; set; }
        public string pur_req_no { get; set; }
        public int? pur_req_row_id { get; set; }
        public string price_qty_uom { get; set; }
        public decimal? price_qty { get; set; }
        public decimal? qty_price { get; set; }
        public string tr_mode { get; set; }
        public string tr_type { get; set; }
        public string tr_party { get; set; }
        public string address_info { get; set; }
        public string tr_name { get; set; }
        public int? item_line_id { get; set; }
        public string add_code_del { get; set; }
}
    public partial class Delivery_Schedule
    {
        public string sch_no { get; set; }
        public DateTime? sch_date { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string remark { get; set; }
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public string unit_code { get; set; }
        public string ref_doc_no { get; set; }
        public DateTime? ref_doc_date { get; set; }
        public Nullable<decimal> unit_price { get; set; }
        public string ink { get; set; }
        public string grade { get; set; }
        public string ild { get; set; }
        public DateTime? confirm_date { get; set; }
        public Nullable<decimal> confirm_qty { get; set; }
        public string remark1 { get; set; }
        public Nullable<decimal> bal_qty { get; set; }
        public string trans_mode { get; set; }
        public DateTime? estimation_date { get; set; }
        public Nullable<decimal> quantity { get; set; }
        public int cycle_no { get; set; }
    }

}
