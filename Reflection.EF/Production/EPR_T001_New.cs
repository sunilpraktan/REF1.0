using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Production
{
    public partial class EPR_T001_New : ObjectBase
    {
        public int id { get; set; }
        public int machine_id { get; set; }
        public string shift { get; set; }
        public Nullable<int> conv { get; set; }
        public Nullable<int> model_id { get; set; }
        public string ball_dia { get; set; }
        public string ball_make { get; set; }
        public string wire_make { get; set; }
        public string ink { get; set; }
        public int pack_style { get; set; }
        public string ild { get; set; }
        public string tds_no { get; set; }
        public string col { get; set; }
        public string ball_type { get; set; }
        public string basket { get; set; }
        public string spoons { get; set; }
        public string shape { get; set; }
        public string sf { get; set; }
        public string order_type { get; set; }
        public DateTime? start_dt { get; set; }
        public Nullable<System.DateTime> end_dt { get; set; }
        public Nullable<System.DateTime> apr_dt { get; set; }
        public string apr_by { get; set; }
        public Nullable<System.DateTime> pro_dt { get; set; }
        public string prod_plan { get; set; }
        public string t_display { get; set; }
        public string status { get; set; }
        public bool active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string Note { get; set; }
        public string po_no { get; set; }
        public string Conv_lot { get; set; }
        public Nullable<bool> appr { get; set; }
        public string order_no { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string sono { get; set; }
        public string PartyId { get; set; }
        public string model_code { get; set; }
        public string ItemCode { get; set; }
        public string editby { get; set; }
        public string test_para { get; set; }
        public Nullable<decimal> wire_size { get; set; }
        public string ref_doc_type { get; set; }
        public string ref_doc_no { get; set; }
        public string PlantName { get; set; }
        public string PartyName { get; set; }
        public string shank_len { get; set; }
        public string needle_dia { get; set; }
        public string needle { get; set; }
        public string Type { get; set; }
        public string machinecode { get; set; }
        public string ItemName { get; set; }
        public string unit_code { get; set; }
        public string Unit { get; set; }
        public Nullable<decimal> qty { get; set; }
        public string PackingUnit { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string language { get; set; }
        public Nullable<int> ink_id { get; set; }
        public Nullable<int> wire_make_id { get; set; }
        public Nullable<int> ild_id { get; set; }
        public Nullable<int> ball_make_id { get; set; }
        public Nullable<int> ball_type_id { get; set; }
        public Nullable<int> wire_size_id { get; set; }
        public string ILDChart2 { get; set;} //adding new
        public string pre_order_no { get; set; }
        public string doc_type_user { get; set; }
        public string doc_desc_user { get; set; }
        public string total_len { get; set; }
        private Nullable<int> plan_item_row_id { get; set; }
        public string ind_batch { get; set; }
        public string store_code { get; set; }
    }
}
