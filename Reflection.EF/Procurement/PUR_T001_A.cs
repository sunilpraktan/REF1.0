using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Procurement
{
    public partial class PUR_T001_A : ObjectBase
    {
        public int id { get; set; }
        public string req_no { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public Nullable<System.DateTime> date_start { get; set; }
        public string priority { get; set; }
        public string origin { get; set; }
        public string description { get; set; }
        public string req_type { get; set; }
        public Nullable<System.DateTime> deadline { get; set; }
        public string wa_code { get; set; }
        public string EmpId { get; set; }
        public string req_ref { get; set; }

        public string t_status { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_display { get; set; }

        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }

        public string priorityNm { get; set; }
        public string EmpNm { get; set; }
        public string status_remark { get; set; }
        public string purchase_type { get; set; }
        public string doc_history_no { get; set; }
        public string po_code { get; set; }
        public string pg_code { get; set; }
        public string pur_org { get; set; }
        public string pg_name { get; set; }
        public string dept_code { get; set; }
        public string dept_name { get; set; }
        public string tr_mode { get; set; }
        public string tr_party { get; set; }
        public string ship_inst { get; set; }
        public string location_del { get; set; }
        public string cerate_by { get; set; }
        public string XmlDataDocument_PUR_T001_B { get; set; }
        public string XmlDataDocument_PUR_T001_C { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }
        public string doc_type_name { get; set; }

    }

    public partial class PUR_T001_B
    {
        public int id { get; set; }
        public string req_no { get; set; }
        public int line_id { get; set; }
        public string ItemCode { get; set; }
        public string description { get; set; }
        public string sku { get; set; }
        public string unit_code { get; set; }
        public Nullable<decimal> qty { get; set; }
        public Nullable<decimal> appr_qty { get; set; }
        public Nullable<decimal> cost { get; set; }
        public Nullable<System.DateTime> expected_date { get; set; }
        public string note { get; set; }
        public Nullable<bool> shipped { get; set; }
        public string t_status { get; set; }
        public Nullable<bool> active { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public Nullable<bool> StockUnt { get; set; }
        public string SubCatCode { get; set; }
        public string item_cat { get; set; }
        public string sku_desc { get; set; }
        public string status_remark { get; set; }
        public string textdata { get; set; }
        public string SubCatName { get; set; }
        public string sono { get; set; }
        public string po_code { get; set; }
        public string pg_code { get; set; }
        public string bom_no { get; set; }
        public string store_code { get; set; }
        public string t_display { get; set; }
        public string para1 { get; set; }
        public string para2 { get; set; }
        public string acca_cat { get; set; }
        public string cost_center { get; set; }
        public string project_id { get; set; }
        public string order_no { get; set; }
        public int? order_res_row_id { get; set; }
        public int? op_row_id { get; set; }
        public int? project_no { get; set; }
        public string element_id { get; set; }
        public int? element_no { get; set; }
        public string ref_doc_cat { get; set; }
        public string ref_doc_no { get; set; }
        public int? ref_item_row_id { get; set; }

        //Scalar
        public string operation_no { get; set; }
        public string operation_desc { get; set; }
        public string project_name { get; set; }
        public string element_name { get; set; }
    }

    public partial class PUR_T001_C
    {
        public int id { get; set; }
        public int line_id { get; set; }
        public int item_line_id { get; set; }
        public int req_item_row_id { get; set; }
        public string req_no { get; set; }
        public Nullable<decimal> qty { get; set; }
        public Nullable<System.DateTime> exp_date { get; set; }
        public string remark { get; set; }
        public string t_status { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_display { get; set; }
        public string ItemCode { get; set; }
    }

    public partial class Purchase_Requision_Data
    {
        public bool select { get; set; }
        public int id { get; set; }
        public string req_no { get; set; }
        public Nullable<System.DateTime> req_date { get; set; }
        public int line_id { get; set; }
        public string ItemCode { get; set; }
        public string description { get; set; }
        public string sku { get; set; }
        public string sku_desc { get; set; }
        public string unit_code { get; set; }
        public Nullable<decimal> qty { get; set; }
        public Nullable<decimal> appr_qty { get; set; }
        public Nullable<decimal> cost { get; set; }
        public Nullable<System.DateTime> expected_date { get; set; }
        public string note { get; set; }
        public string t_status { get; set; }
        public Nullable<bool> active { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string ItemCat { get; set; }
        public string item_cat { get; set; }
        public string status_remark { get; set; }
        public string textdata { get; set; }
        public string ItemCatName { get; set; }
        public string po_code { get; set; }
        public string pg_code { get; set; }
        public string bom_no { get; set; }
        public string t_display { get; set; }
        public string color_code { get; set; }
        public string requester { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public decimal? stock_total { get; set; }
    }
}
