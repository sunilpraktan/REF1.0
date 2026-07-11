using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessEntity.Production
{

    public class Rpt_MIS_Periodic1
    {
        public string doc_no { get; set; }
        public DateTime? entry_dt { get; set; }
        public DateTime? prod_dt { get; set; }
        public string ItemCode { get; set; }
        public string shift { get; set; }
        public Nullable<int> ink_id { get; set; }
        public string ink { get; set; }
        public Nullable<int> ild_id { get; set; }
        public string ild { get; set; }
        public Nullable<int> machine_id { get; set; }
        public string machinecode { get; set; }
        public Decimal? counter_qty { get; set; }
        public Decimal? a_qty { get; set; }
        public Decimal? b_qty { get; set; }
        public Decimal? c_qty { get; set; }
        public string batch_no { get; set; }
        public string unit_code { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string conversion_no { get; set; }
        public string grade { get; set; }
        public string CustomerProductName { get; set; }
        public Nullable<int> ball_make { get; set; }
        public Nullable<int> wire_make { get; set; }
        public string CatCode { get; set; }
        public string SubCatCode { get; set; }
        public string ItemTypeCd { get; set; }
        public string SubItemTpCd { get; set; }
        public string ItemName { get; set; }
        public Decimal? total_qty { get; set; }
        public string tip_type { get; set; }
        public int? model_id { get; set; }
        public string modeldesc { get; set; }
        public int? ball_type_id { get; set; }
        public string ball_type { get; set; }
        public int? wire_type_id { get; set; }
        public string wire_type { get; set; }
        public Decimal? para1 { get; set; }
        public string para2 { get; set; }
        public Decimal? workday { get; set; }
        public Decimal? average { get; set; }
        public Decimal? rejectionA { get; set; }
        public Decimal? rejectionB { get; set; }
        public Decimal? rejectionC { get; set; }
        public Decimal? blank_wt { get; set; }
        public Decimal? tip_ave_wt { get; set; }
        public Decimal? chip_wt { get; set; }
        public Decimal? wire_con { get; set; }
        public Decimal? chip_prod { get; set; }
        public string machineorder { get; set; }

        //Conversion Note
        public string status { get; set; }
        public string order_no { get; set; }
        public DateTime? start_dt { get; set; }
        public string model_code { get; set; }
        public string ball_dia { get; set; }
        public DateTime? pro_dt { get; set; }

        public string machinecodeA { get; set; }
        public string ildA { get; set; }
        public string statusA { get; set; }
        public string order_noA { get; set; }
        public DateTime? start_dtA { get; set; }
        public string model_codeA { get; set; }
        public string ball_diaA { get; set; }
        public int Conv { get; set; }
        public string model_codeB { get; set; }
        public string ball_diaB { get; set; }
        public string ildB { get; set; }
        public string ink1 { get; set; }
        public string ild1 { get; set; }
        public string make { get; set; }
        public string type { get; set; }
        public string mat_con { get; set; }
        public string month { get; set; }
        public string engineer { get; set; }
        public string average_wt_no { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public Nullable<DateTime> Date { get; set; }
        public string Header1 { get; set; }
        public Nullable<decimal> avg_blank_wt { get; set; }
        public string Plant { get; set; }
        public Nullable<int> id { get; set; }

        //Production Planning
        public string machine_no { get; set; }
        public string para9 { get; set; }
        public string para6 { get; set; }
        public string Make { get; set; }
        public Nullable<decimal> shank_dia { get; set; }
        public string total_len { get; set; }
        public string PartyNm { get; set; }
        public string sales_order_no { get; set; }
        public Nullable<decimal> quantity { get; set; }
        public DateTime? production_date_start { get; set; }
        public DateTime? production_date_finish { get; set; }

    }
    public class Rpt_MIS_Pro_MFG
    {
        public string doc_no { get; set; }
        public DateTime? entry_dt { get; set; }
        public DateTime? prod_dt { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string tip_type { get; set; }
        public string shift { get; set; }
        public int? machine_id { get; set; }
        public string machinecode { get; set; }
        public decimal? a_qty { get; set; }
        public decimal? b_qty { get; set; }
        public decimal? c_qty { get; set; }
        public decimal? total_amt { get; set; }
        public int? model_id { get; set; }
        public string modeldesc { get; set; }
        public string unit_code { get; set; }
        public int? ink_id { get; set; }
        public int? ild_id { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
        public int? ball_type_id { get; set; }
        public string ball_type { get; set; }
        public int? wire_type_id { get; set; }
        public string wire_type { get; set; }
        public int? para1 { get; set; }
        public string para2 { get; set; }

    }
}
