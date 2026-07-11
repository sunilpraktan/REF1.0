using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.SCM
{
    public partial class MM_T003 : ObjectBase
    {
        public string comp_code { get; set; }
        public string doc_no { get; set; }
        public DateTime? doc_date { get; set; }
        public string location_id { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string ref_doc_cat { get; set; }
        public string ref_doc_no { get; set; }
        public string pr_code { get; set; }
        public string origin { get; set; }
        public string req_type { get; set; }
        public DateTime? deadline { get; set; }
        public string wa_code { get; set; }
        public string emp_id { get; set; }
        public string dept_code { get; set; }
        public string t_status { get; set; }
        public string note { get; set; }
        public string active { get; set; }
        public DateTime? from_date { get; set; }
        public DateTime? to_date { get; set; }
        public string from_time { get; set; }
        public string to_time { get; set; }

        // Scalar Fields
        public string bom_no { get; set; }
        public string pri_name { get; set; }
        public string emp_name { get; set; }
        public string dept_name { get; set; }
        public string doc_type_name { get; set; }
        public string t_display { get; set; }
        public decimal? order_qty { get; set; }
        public string XDOC_A { get; set; }

    }

    public partial class MM_T003_A
    {
        public int? id { get; set; }
        public string doc_no { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public string sku { get; set; }
        public string sku_desc { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public decimal? qty { get; set; }
        public decimal? appr_qty { get; set; }
        public decimal? cost { get; set; }
        public DateTime? expected_date { get; set; }
        public string note { get; set; }
        public string t_status { get; set; }
        public string active { get; set; }
        public string location_id { get; set; }
        public string comp_code { get; set; }
        public string item_cat { get; set; }
        public string unit_code { get; set; }
        public int line_id { get; set; }
        public int? order_item_row_id { get; set; }
        public string order_no { get; set; }
        public string store_code { get; set; }
        public string batch_no { get; set; }
        public string wc_code { get; set; }
        public string equip_no { get; set; }
        public decimal? equip_counter { get; set; }
        public string counter_unit { get; set; }
        public string ref_doc_cat { get; set; }
        public string ref_doc_no { get; set; }
        public int? re_item_row_id { get; set; }


        // Scalar Fields
        public string ind_vc { get; set; } // variant config indicator, sku_indicator
        public string sub_cat { get; set; }
        public decimal? issue_qty { get; set; }
        public string t_display { get; set; }
        public string short_text { get; set; } // display order_no title if any

    }

    public partial class MM_T003_S
    {
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string ind_ack { get; set; }
        public string ind_store_code { get; set; }
        public string ind_batch_no { get; set; }

    }
}
