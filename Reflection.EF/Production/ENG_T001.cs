using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Production
{
    public partial class ENG_T001 : ObjectBase
    {
        public string doc_no { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public System.DateTime? doc_date { get; set; }
        public string location_id { get; set; }
        public string comp_code { get; set; }
        public int? counter_no { get; set; }
        public string bom_cat { get; set; }
        public string item_code { get; set; }
        public string emp_id { get; set; }
        public string party_code { get; set; }
        public string unit_code { get; set; }
        public decimal? bom_qty { get; set; }
        public bool? alternate_bom { get; set; }
        public string revision_no { get; set; }
        public DateTime? revision_date { get; set; }
        public string ref_doc_no { get; set; }
        public string order_doc_type { get; set; }
        public string order_no { get; set; }
        public DateTime? valid_from { get; set; }
        public DateTime? valid_to { get; set; }
        public string bom_name { get; set; }
        public string note { get; set; }
        public string active { get; set; }
        public string t_status { get; set; }

        //Scalar
        public string item_name { get; set; }
        public string remark { get; set; }
        public string party_name { get; set; }
        public string item_cat { get; set; }
        public string cat_code { get; set; }
        public string curr_code { get; set; }
        public string bom_cat_code { get; set; }
        public string XDOC_A { get; set; }



    }
    public partial class ENG_T001_A
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public int? counter_no { get; set; }
        public string bom_cat { get; set; }
        public int? bom_item_node_no { get; set; }
        public DateTime? valid_from { get; set; }
        public DateTime? valid_to { get; set; }
        public string change_no { get; set; }
        public string parent_node { get; set; }
        public int? previous_counter { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public string issuing_plant { get; set; }
        public string line_cat { get; set; }
        public int? bom_item_no { get; set; }
        public string unit_code { get; set; }
        public decimal? qty { get; set; }
        public string fixed_qty { get; set; }
        public decimal? component_scrap { get; set; }
        public decimal? operation_scrap { get; set; }
        public string ind_net_scrap { get; set; }
        public string ind_item_prd { get; set; }
        public string ind_item_sales { get; set; }
        public string ind_plant { get; set; }
        public string ind_costing { get; set; }
        public string ind_engg { get; set; }
        public string ind_recursive { get; set; }
        public string ind_recursive_allowed { get; set; }
        public string ind_alternative_item { get; set; }
        public string ind_subitem_exit { get; set; }
        public string item_code_alt { get; set; }
        public string revision_no { get; set; }
        public DateTime? revision_date { get; set; }
        public string ref_revision_no { get; set; }
        public string ind_pm_assembly { get; set; }
        public string active { get; set; }
        public string t_status { get; set; }
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public string sku { get; set; }
        public string sku_desc { get; set; }
        public string info1 { get; set; }
        public string info2 { get; set; }
        public string info3 { get; set; }
        public decimal? con_qty { get; set; }
        public string con_uom { get; set; }
        public decimal? per_qty { get; set; }
        public string per_uom { get; set; }
        public string ind_usage { get; set; }
        public string ind_base { get; set; }
        public int? line_id { get; set; }

        // scalar
        public string item_name_alt { get; set; }
        public string sub_cat { get; set; }
        public bool? ind_stock { get; set; }
        public bool? ind_sku { get; set; }


    }
}
