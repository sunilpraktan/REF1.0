using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.SCM
{
    public partial class MM_S010 : ObjectBase
    {
        public int? id { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string store_code { get; set; }
        public string wa_code { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string trns_type { get; set; }
        public string doc_no { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string sp_stock { get; set; }
        public Nullable<System.DateTime> plann_date { get; set; }
        public Nullable<System.DateTime> last_count_date { get; set; }
        public Nullable<System.DateTime> post_date { get; set; }
        public Nullable<bool> posting_block { get; set; }
        public string count_sts { get; set; }
        public string ref_no { get; set; }
        public string freeze { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
        public string t_status { get; set; }
        public Nullable<bool> active { get; set; }
        public string LoadItems{ get; set; }
        public int? Count { get; set; }
        public bool? NewRecord { get; set; }
        public bool? selectall { get; set; }
        public string XmlDataDocument_MM_S010_A { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }
        public string Grade { get; set; }
        public string localimport { get; set; }
    }
    
    public partial class MM_S010_A
    {
        public int id { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string store_code { get; set; }
        public string wa_code { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string doc_no { get; set; }
        public string ItemCode { get; set; }
        public string sku { get; set; }
        public string unit_code { get; set; }
        public string batch_no { get; set; }
        public string sp_stock { get; set; }
        public string store_type { get; set; }
        public string sono { get; set; }
        public Nullable<int> so_item_no { get; set; }
        public string sch_no { get; set; }
        public string vendor_accno { get; set; }
        public string customer_accno { get; set; }
        public string dist_diff { get; set; }
        public Nullable<System.DateTime> last_count_date { get; set; }
        public Nullable<System.DateTime> post_date { get; set; }
        public string ref_no { get; set; }
        public Nullable<bool> item_counted { get; set; }
        public Nullable<bool> difference_posted { get; set; }
        public Nullable<bool> item_delete { get; set; }
        public Nullable<decimal> prebook_qty { get; set; }
        public Nullable<bool> zero_count { get; set; }
        public Nullable<decimal> quantity { get; set; }
        public string base_unit_code { get; set; }
        public Nullable<decimal> qty_unit_entry { get; set; }
        public string entry_unit { get; set; }
        public string item_doc_no { get; set; }
        public Nullable<int> item_doc_year { get; set; }
        public string item_doc { get; set; }
        public string rec_doc_no { get; set; }
        public Nullable<decimal> diff_amt { get; set; }
        public string curr_code { get; set; }
        public string inv_ind { get; set; }
        public Nullable<decimal> sales_value { get; set; }
        public Nullable<decimal> ext_sales_value { get; set; }
        public Nullable<decimal> book_value_sp { get; set; }
        public string value_ind { get; set; }
        public Nullable<decimal> sales_value_ex { get; set; }
        public Nullable<decimal> sales_value_diff { get; set; }
        public Nullable<decimal> sales_value_diff2 { get; set; }
        public Nullable<decimal> phy_count_value { get; set; }
        public Nullable<decimal> book_value { get; set; }
        public Nullable<decimal> qty_diff { get; set; }
        public Nullable<decimal> inv_diff { get; set; }
        public Nullable<System.DateTime> count_date { get; set; }
        public Nullable<System.TimeSpan> count_time { get; set; }
        public Nullable<System.DateTime> freeze_date { get; set; }
        public Nullable<System.TimeSpan> freeze_time { get; set; }
        public string count_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
        public string t_status { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public Nullable<bool> active { get; set; }
        public Nullable<decimal> shortage_access { get; set; }
        public Nullable<decimal> varience { get; set; }
        public Nullable<decimal> rate { get; set; }
        public string remark { get; set; }
        public string make { get; set; }
        public string grade { get; set; }
        public string type { get; set; }
        public string mat_cond { get; set; }
        public string sku_desc { get; set; } 
        //scalar
        public string LoctnNm { get; set; }
        public string store_name { get; set; }
        public string CompName { get; set; }
        public string ItemName { get; set; }
        public Nullable<bool> StockUnt { get; set; }
        public string  SubCatCode { get; set; }      
        public int? ink_id { get; set; }
        public string ink { get; set; }
        public int? ild_id { get; set; }
        public string ild { get; set; }
        public string ItemTypeCd { get; set; }
        public string SubItemTpCd { get; set; }
        public bool? check { get; set; }


    }
}
