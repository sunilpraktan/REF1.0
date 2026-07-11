using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Production
{
    public partial class ECRM_T003_A_New : ObjectBase
    {
        public int id { get; set; }
        public Nullable<int> mchn_id { get; set; }
        public string machinecode { get; set; }
        public string lotno { get; set; }
        public Nullable<System.DateTime> prddt { get; set; }
        public string wtno { get; set; }
        public Nullable<System.DateTime> wtdt { get; set; }
        public string tiptp { get; set; }
        public string modlno { get; set; }
        public string ink { get; set; }
        public string prdct_code { get; set; }
        public string timefr { get; set; }
        public string timeto { get; set; }
        public string tmp { get; set; }
        public string humdt { get; set; }
        public string shift { get; set; }
        public Nullable<int> tm { get; set; }
        public string remusr { get; set; }
        public Nullable<decimal> tmnild { get; set; }
        public Nullable<decimal> tmxild { get; set; }
        public Nullable<decimal> tavild { get; set; }
        public Nullable<decimal> tavgoo { get; set; }
        public Nullable<decimal> amnild { get; set; }
        public Nullable<decimal> amxild { get; set; }
        public Nullable<decimal> aavild { get; set; }
        public Nullable<decimal> aavgoo { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string Conv_lot { get; set; }
        public string obrem { get; set; }
        public string uhdec { get; set; }
        public string uhrem { get; set; }
        public string EmpId { get; set; }
        public Nullable<decimal> check_qty { get; set; }
        public Nullable<decimal> counter_qty { get; set; }
        public string test_code { get; set; }
        public string order_no { get; set; }
        public string t_status { get; set; }
        public string batch_no { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string language { get; set; }
        public decimal? Ranget{ get; set; }
        public string barcode { get; set; }
        public string PartyId { get; set; }
        public string sono { get; set; }
        public string sa_no { get; set; }
        public string ball_make { get; set; }
        public string wire_make { get; set; }
        public Nullable<decimal> wire_size { get; set; }
        public string ball_size { get; set; }
        public Nullable<decimal> line_width { get; set; }
        public string wt_machine { get; set; }
        public Nullable<decimal> pages { get; set; }
        public string ItemCode { get; set; }
        public string sheet_cond { get; set; }
        public Nullable<decimal> writing_angle { get; set; }
        public Nullable<decimal> paper_feed { get; set; }
        public Nullable<decimal> writing_speed { get; set; }
        public Nullable<decimal> Pt_load { get; set; }
        public Nullable<int> pices_count { get; set; }
        public string position { get; set; }
        public string period { get; set; }
        public string PartyNm { get; set; }
        public string Ref_doc_type { get; set; }
        public string itemname { get; set; }
        public string unit_code { get; set; }
        public decimal? batch_qty { get; set; }
        public string qc_person1 { get; set; }
        public string sshift { get; set; }
        public string item { get; set; }
        public string machine { get; set; }
        public string con_no { get; set; }
        public Nullable<decimal> sample_qty { get; set; }
        public string t_display { get; set; }
        public string wc_code { get; set; }
        public string grade { get; set; }
        public string counter_remark { get; set; }
    }

    public partial class ECRM_T003_B_New
    {
        public int id { get; set; }
        public Nullable<int> wtid { get; set; }
        public string wtno { get; set; }
        public string refilno { get; set; }
        public Nullable<decimal> wbtsta { get; set; }
        public Nullable<decimal> watstb { get; set; }
        public Nullable<decimal> waclgc { get; set; }
        public Nullable<decimal> ild { get; set; }
        public Nullable<decimal> gooping { get; set; }
        public string defects { get; set; }
        public string remusr { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }

        public string t_status { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string batch_no { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }

        public Nullable<decimal> tot_life { get; set; }
        public string skping { get; set; }
        public string deeplight { get; set; }
        public string DefectNm { get; set; }




    }

    public partial class ECRM_T003_D_New
    {
        public string DefectNm { get; set; }
        public string parameterNm { get; set; }
        public decimal? defect_qty { get; set; }
        public int id { get; set; }
        public string wtno { get; set; }
        public string defect { get; set; }
        public string parameters { get; set; }
        public string observation { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string t_status { get; set; }
        public Nullable<bool> active { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string lang_key { get; set; }
        public string client { get; set; }
        public int? refillno { get; set; }
    }
}
