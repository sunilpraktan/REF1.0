using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.MM
{
    public class MM_T005 : ObjectBase
    {
        public string comp_code { get; set; }
        public string doc_no { get; set; }
        public int? res_no { get; set; }
        public string location_id { get; set; }
        public DateTime? doc_date { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string ref_doc_cat { get; set; }
        public string ref_doc_type { get; set; }
        public string ref_doc_no { get; set; }
        public int? ref_item_row_id { get; set; }
        public string short_text { get; set; }
        public string order_no { get; set; }
        public int? order_item_row_id { get; set; }
        public string rec_type { get; set; }
        public string res_type { get; set; }
        public string origin { get; set; }
        public DateTime? res_date { get; set; }
        public string mov_tp { get; set; }
        public string recipient { get; set; }
        public string cc_code { get; set; }
        public string pc_code { get; set; }
        public string project_id { get; set; }
        public string element_id { get; set; }
        public string asset_no { get; set; }
        public string sub_asset_no { get; set; }
        public string customer { get; set; }
        public string po_no { get; set; }
        public int? po_item_row_id { get; set; }
        public string so_no { get; set; }
        public int? so_item_row_id { get; set; }
        public int? sch_item_row_id { get; set; }
        public string plant { get; set; }
        public string store_code { get; set; }
        public string bom_exp_no { get; set; }
        public string comp_code_clr { get; set; }
        public int? routing_op_row_id { get; set; }
        public int? int_counter { get; set; }
        public string party_code { get; set; }
        public string t_status { get; set; }
        public string active { get; set; }
        public string note { get; set; }


        //Scalar
        public string rec_type_name { get; set; }
        public string res_type_name { get; set; }
        public string origin_name { get; set; }
        public string mov_type_name { get; set; }
        public string recipient_name { get; set; }
        public string cc_name { get; set; }
        public string pc_name { get; set; }
        public string project_name { get; set; }
        public string element_name { get; set; }
        public string asset_name { get; set; }
        public string sub_asset_name { get; set; }
        public string customer_name { get; set; }
        public string supplier_name { get; set; }
        public string t_display { get; set; }
        public string party_name { get; set; }
        public string long_text { get; set; }
        public string XDOC_A { get; set; }
        public string XDOC_B { get; set; }
        
    }

    public class MM_T005_A : ObjectBase
    {
        public int? id { get; set; }
        public string comp_code { get; set; }
        public string doc_no { get; set; }
        public int? res_no { get; set; }
        public string location_id { get; set; }
        public int? line_id { get; set; }
        public string rec_type { get; set; }
        public string res_type { get; set; }
        public string t_status { get; set; }
        public string active { get; set; }
        public string item_code { get; set; }
        public string sku { get; set; }
        public string store_code { get; set; }
        public string batch_no { get; set; }
        public DateTime? req_date { get; set; }
        public decimal? qty { get; set; }
        public string unit_code { get; set; }
        public string ind_dc { get; set; }
        public string curr_code { get; set; }
        public string plan_order_no { get; set; }
        public string pr_no { get; set; }
        public int? pr_item_row_id { get; set; }
        public string order_no { get; set; }
        public int? order_item_row_id { get; set; }
        public string item_code_hl { get; set; }
        public string bom_exp_no { get; set; }
        public string po_no { get; set; }
        public int? po_item_row_id { get; set; }
        public string so_no { get; set; }
        public int? so_item_row_id { get; set; }
        public int? sch_item_row_id { get; set; }
        public string mov_tp { get; set; }
        public string project_id { get; set; }
        public string element_id { get; set; }
        public string plant { get; set; }
        public string store_code1 { get; set; }
        public string item_cat { get; set; }
        public string bom_no { get; set; }
        public int? bom_item_row_id { get; set; }
        public string bom_cat { get; set; }
        public int? int_counter { get; set; }
        public string bom_item_text { get; set; }
        public string ind_costing { get; set; }
        public string ind_alt { get; set; }
        public string ind_cp { get; set; }
        public string ind_backflush { get; set; }
        public string ind_config { get; set; }
        public string ind_external { get; set; }
        public decimal? scrap_comp { get; set; }
        public decimal? scrap_op { get; set; }
        public string pro_doc_no { get; set; }
        public int? pro_item_row_id { get; set; }
        public int? psch_item_row_id { get; set; }
        public int? op_row_id { get; set; }
        public int? op_seq { get; set; }
        public string op_no { get; set; }
        public int? counter { get; set; }
        public string obj_no { get; set; }
        public string seq_cat { get; set; }
        public decimal? unit_price { get; set; }
        public string price_uom { get; set; }
        public string pg_code { get; set; }
        public decimal? delivery { get; set; }
        public string rev_level { get; set; }
        public string wh_code { get; set; }
        public string store_type { get; set; }
        public string store_bin { get; set; }
        public int? res_item_row_id { get; set; }
        public string supplier { get; set; }
        public decimal? gr_time { get; set; }
        public decimal? amount { get; set; }
        public string bom_alt { get; set; }
        public string req_plan_no { get; set; }



        //Scalar
        public string op_name { get; set; } // Operation Name
        public string obj_name { get; set; } // Object Name
        public string mov_tp_name { get; set; }
        public string project_name { get; set; }
        public string element_name { get; set; }
        public string customer_name { get; set; }
        public string supplier_name { get; set; }
        public string t_display { get; set; }
        public string party_name { get; set; }
        public string long_text { get; set; }

    }

    public class MM_T005_B
    {
        public int? id { get; set; }
        public string client { get; set; }
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public string wa_code { get; set; }
        public string store_code { get; set; }
        public int? line_id { get; set; }
        public int? item_row_id { get; set; }
        public int? item_line_id { get; set; }
        public string doc_no { get; set; }
        public string item_code { get; set; }
        public string sku { get; set; }
        public string batch_no { get; set; }
        public string batch_no_v { get; set; }
        public string barcode { get; set; }
        public string pack_no { get; set; }
        public decimal? qty { get; set; }
        public string unit_code { get; set; }
        public string t_status { get; set; }
        public string active { get; set; }
        
    }

    public class MM_T011 : ObjectBase // PRT/Resource Assignment to Order
    {
        public string comp_code { get; set; }
        public int? id { get; set; }
        public int? op_row_id { get; set; }
        public int? item_no { get; set; }
        public string order_no { get; set; }
        public string op_no { get; set; }
        public string obj_type { get; set; }
        public string obj_id { get; set; }
        public string tl_type { get; set; }
        public string tl_key { get; set; }
        public int? item_counter_prt { get; set; }
        public int? int_counter_prt { get; set; }
        public int? item_row_id_prt { get; set; }
        public string tl_object { get; set; }
        public int? int_counter { get; set; }
        public string obj_no { get; set; }
        public string ctl_key { get; set; }
        public decimal? qty { get; set; }
        public string unit_code { get; set; }
        public decimal? usage_value { get; set; }
        public string usage_unit { get; set; }
        public string active { get; set; }


        //Scalar Fields
        public string itemp_name { get; set; } // No use now because we are using obj_name for the same.
        public string op_name { get; set; }
        public string obj_name { get; set; }
        public string XDOC_A { get; set; }
    }
}
