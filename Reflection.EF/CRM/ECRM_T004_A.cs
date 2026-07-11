using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.CRM
{
    public partial class ECRM_T004_A : ObjectBase
    {
        public int id { get; set; }
        public string pdi_no { get; set; }
        public string client { get; set; }
        public Nullable<System.DateTime> pdi_date { get; set; }
        public string ref_no { get; set; }
        public string mod_no { get; set; }
        public Nullable<decimal> qty { get; set; }
        public string batchno { get; set; }
        public Nullable<int> mach_no { get; set; }
        public string shift { get; set; }
        public string Grade { get; set; }
        public string whout_ball { get; set; }
        public string chips { get; set; }
        public string coll_mdg { get; set; }
        public string clngqulit { get; set; }
        public string pltqulit { get; set; }
        public string mixing { get; set; }
        public string nonwrt { get; set; }
        public string ildchk { get; set; }
        public string handfil { get; set; }
        public string shdia { get; set; }
        public string shlen { get; set; }
        public string shchmfr { get; set; }
        public string nedledia { get; set; }
        public string nedlen { get; set; }
        public string totlen { get; set; }
        public string baout { get; set; }
        public Nullable<decimal> ildmin { get; set; }
        public Nullable<decimal> ildmax { get; set; }
        public Nullable<decimal> ildavg { get; set; }
        public string ildrang { get; set; }
        public string set_ild { get; set; }
        public string set_ink { get; set; }
        public Nullable<System.DateTime> prodate { get; set; }
        public string Conv_no { get; set; }
        public string note { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public string PartyNm { get; set; }
        public string ItemCode { get; set; }
        public string PartyId { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public Nullable<bool> active { get; set; }
        public string editby { get; set; }
        public string machinecode { get; set; }
        public string ItemName { get; set; }
        public Nullable<decimal> addition { get; set; }
        public Nullable<decimal> rej_qty { get; set; }
        public Nullable<decimal> check_qty { get; set; }
        public Nullable<decimal> sample_qty { get; set; }
        public string @operator { get; set; }
        public Nullable<decimal> manual_wt { get; set; }
        public Nullable<decimal> refil_qty { get; set; }
        public Nullable<decimal> final_qty { get; set; }
        public string order_no { get; set; }
        public string barcode_no { get; set; }
        public decimal? wt_qty { get; set; }
        public string decision { get; set; }
        public string recomd_grade { get; set; }
        public string remark { get; set; }
        public string remark1 { get; set; }
        public string remark2 { get; set; }
        public Nullable<System.DateTime> Fromdate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public string EmpId1 { get; set; }
        public string qc_person1 { get; set; }
        public string sshift { get; set; }
        public string item { get; set; }
        public string machine { get; set; }
        public string con_no { get; set; }
        public string t_status { get; set; }
        public string t_display { get; set; }
        public string wc_code { get; set; }
        public string counter_remark { get; set; }
        public string XmlDataDocument_ECRM_T004_C { get; set; }
    }

    public partial class ECRM_T004_B
    {
        public int id { get; set; }
        public Nullable<int> pdien_id { get; set; }
        public Nullable<int> modle { get; set; }
        public string shdia { get; set; }
        public string shlength { get; set; }
        public string neeldia { get; set; }
        public string neellength { get; set; }
        public string totlength { get; set; }
        public string ballout { get; set; }
        public string p_top { get; set; }
        public string rimthik { get; set; }
        public string spinlength { get; set; }
        public string spinangle { get; set; }
        public string centdrill { get; set; }
        public string shchmfar { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public Nullable<bool> active { get; set; }
        public string pdi_no { get; set; }
    }

    public partial class ECRM_T004_C
    {
        public int id { get; set; }
        public string pdi_no { get; set; }
        public string defect { get; set; }
        public string parameters { get; set; }
        public string defectNm { get; set; }
        public string ParameterNm { get; set; }
       
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
        public string lang_key { get; set; }
        public string client { get; set; }
        public decimal ? defect_qty { get; set; }
    }
}
