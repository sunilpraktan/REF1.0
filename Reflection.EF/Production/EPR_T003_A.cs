using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Production
{
    public partial class EPR_T003_A : ObjectBase
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string carton_type { get; set; }
        public string packing_type { get; set; }
        public string carton_no { get; set; }
        public DateTime? carton_pack_dt { get; set; }
        public string barcode { get; set; }
        public string batch_no { get; set; }
        public string cust_batch_no { get; set; }
        public string ItemCode { get; set; }
        public string grade { get; set; }
        public int? ink_id { get; set; }
        public int? ild_id { get; set; }
        public string tip_type { get; set; }
        public string unit_code { get; set; }
        public int? pack_style { get; set; }
        public decimal? qty_per_bag { get; set; }
        public decimal? tot_no_bags { get; set; }
        public decimal? tot_qty { get; set; }
        public decimal? bal_qty { get; set; }
        public int? wire_make_id { get; set; }
        public int? ball_make_id { get; set; }
        public decimal? net_wt { get; set; }
        public decimal? gross_wt { get; set; }
        public int? prod_desc_id { get; set; }
        public string dimension { get; set; }
        public string shipping_mrk { get; set; }
        public string no_kind_pack { get; set; }
        public string mark_and_nos { get; set; }
        public string cust_prod_no { get; set; }
        public string cust_prod_code { get; set; }
        public int? cpnsrno { get; set; }
        public string cpn_model_no { get; set; }
        public string partno { get; set; }
        public string po_no { get; set; }
        public string note { get; set; }
        public bool? carton_used_Flg { get; set; }
        public string free_sale { get; set; }
        public bool active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public DateTime? edit_date { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public int? no_of_carton { get; set; }
        public int? bags_per_carton { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string PartyId { get; set; }
        public string m_operator { get; set; }
        public int? machine_id { get; set; }
        public string machinecode { get; set; }
        public string wc_code { get; set; }
        public string dn_doc_no { get; set; }
        public int? dn_row_id { get; set; }
        public int? dn_batch_row_id { get; set; }
        public decimal? volume { get; set; }
        public string volume_unit { get; set; }
        public decimal? volume_loading { get; set; }
        public decimal? volume_loading_allowed { get; set; }
        public decimal? tare_volume { get; set; }
        public decimal? loading_wt { get; set; }
        public decimal? loading_wt_allowed { get; set; }
        public decimal? tare_wt { get; set; }
        public string weight_unit { get; set; }
        public string item_code_pack { get; set; }
        public decimal? pack_length { get; set; }
        public decimal? pack_width { get; set; }
        public decimal? pack_height { get; set; }
        public string dim_uom { get; set; }
        public string t_status { get; set; }
        public decimal? wt_tol { get; set; }
        public decimal? vol_tol { get; set; }
        public string sku { get; set; }
        public decimal? qty_item_code_pack { get; set; }
        public string uom_item_code_pack { get; set; }
        public string pack_type { get; set; }
        public string store_code { get; set; }
        public string wa_code { get; set; }
        public string hu_h_level { get; set; }
        public string pack_inst { get; set; }
        public int? level_no { get; set; }
        public string ind_print { get; set; }
        public string packing_location { get; set; }

        // Scalar Fields
        public string XmlDataDocument_EPR_T003_B { get; set; }
        public string XmlDataDocument_EPR_T003_A { get; set; }
        public string ind_packing { get; set; } // indicator for Packing process type i.e Split packing or Standard Packing.
        public string Ink { get; set; }
        public string Ild { get; set; }
        public string BallMake { get; set; }
        public decimal? ball_dia { get; set; }
        public string WireMake { get; set; }
        public string PackingUnit { get; set; }
        public string AllMachine { get; set; }
        public string AllShift { get; set; }
        public string ItemName { get; set; }
        public string PartyNm { get; set; }
        public string OperatorNm { get; set; }
        public bool? check { get; set; }
        public string wire_type { get; set; }
        public string ball_type { get; set; }
        public string modelno { get; set; }
        public bool? selected { get; set; }
        public string item_code { get; set; } // Actual packed Material Code
        public string item_name { get; set; } // Actual packed Material Name
        public int? line_no { get; set; }
        public string total_len { get; set; }


    }

    public class EPR_T003_B
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string carton_no { get; set; }
        public string batch_no { get; set; }
        public string cust_batch_no { get; set; }
        public decimal qty { get; set; }
        public string note { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public bool active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public DateTime? edit_date { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string hu_content_type { get; set; }
        public string item_code { get; set; }
        public string unit_code { get; set; }
        public string dn_doc_no { get; set; }
        public int? dn_row_id { get; set; }
        public int? dn_batch_row_id { get; set; }
        public string client { get; set; }
        public int? line_id { get; set; }
        public string hu_l_level { get; set; }
        public string store_code { get; set; }
        public DateTime? shelf_life { get; set; }
        public string barcode { get; set; }
        public string t_status { get; set; }
        public DateTime? prod_date { get; set; }
        public string ind_residue_packing { get; set; }
        public string sku { get; set; }


        // Scalar Fields
        public decimal? partial_qty { get; set; }
        public decimal? net_wt { get; set; }
        public string weight_unit { get; set; }
        public decimal? volume { get; set; }
        public string volume_unit { get; set; }
        public string MachinePacCode { get; set; }
        public string Shift { get; set; }
        public string item_name { get; set; }
        public bool? selected { get; set; }
        public int? line_no { get; set; }
        public decimal? packing_qty { get; set; }
        public decimal? available_qty { get; set; }
        public decimal? yield { get; set; }

    }

    public class EPR_T003_S
    {
        public string batch_no_format { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public int range1 { get; set; }
        public int doc_no_digits { get; set; }
        public string doc_type { get; set; }
        public string report_name { get; set; }
        public string report_name2 { get; set; }
        public string report_name3 { get; set; }
        public string report_name4 { get; set; }
        public string report_name5 { get; set; }
        public string report_name6 { get; set; }
        public decimal net_wt { get; set; }
        public decimal gross_wt { get; set; }
        public Nullable<decimal> no_of_bags { get; set; }
        public Nullable<int> no_of_cartons { get; set; }
        public string scan_source { get; set; }
        public int min_length { get; set; }

    }

}
