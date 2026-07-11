using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Reflection.EF.Production
{  //namespace Reflection.EF.Admin  namespace Reflection.EF.CRM

    public partial class ACC_T002
    {
        public string doc_no { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string ref_doc_no { get; set; }
        public Nullable<System.DateTime> ref_doc_date { get; set; }
        public string ref_doc_type { get; set; }
        public string client { get; set; }
        public string language { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string PartyId { get; set; }
        public Nullable<decimal> debit { get; set; }
        public Nullable<decimal> credit { get; set; }
        public string gl_code { get; set; }
        public string remark { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
    }

    public partial class ADM_M038_A
    {
        public int id { get; set; }
        public string class_name { get; set; }
        public string unit_code { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
        public string base_unit { get; set; }
    }
    public partial class ADM_M029
    {
        public int SrNo { get; set; }
        public string PartyId { get; set; }
        public string Location { get; set; }
        public string AddType { get; set; }
        public string Add1 { get; set; }
        public string Add2 { get; set; }
        public string LandMark { get; set; }
        public string City { get; set; }
        public string state_code { get; set; }
        public string country_code { get; set; }
        public string PinCode { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public Nullable<bool> active { get; set; }
        public string PartyNm { get; set; }
        public string CntryName { get; set; }
        public string StatName { get; set; }
    }
    
    public partial class CAL_M003A
    {
        public int SrNo { get; set; }
        public int inst_id { get; set; }
        public string IdNo { get; set; }
        public Nullable<System.DateTime> PurchDate { get; set; }
        public string InstMake { get; set; }
        public string Range { get; set; }
        public string MaintSrc { get; set; }
        public Nullable<int> Rig_id { get; set; }
        public string CalSrc { get; set; }
        public string CatlogNo { get; set; }
        public string CatlogNm { get; set; }
        public string CdName { get; set; }
        public string FileName { get; set; }
        public string Accurcy { get; set; }
        public string LeastCnt { get; set; }
        public Nullable<decimal> CalFreq { get; set; }
        public string CalPerid { get; set; }
        public string CalInstNo { get; set; }
        public string CalCatgry { get; set; }
        public Nullable<decimal> AppxCost { get; set; }
        public string TechSpec { get; set; }
        public string PoNo { get; set; }
        public Nullable<System.DateTime> PoDate { get; set; }
        public string ReqNo { get; set; }
        public Nullable<System.DateTime> ReqDate { get; set; }
        public string BdgtTyp { get; set; }
        public string CalRptNo { get; set; }
        public string SuppDtl { get; set; }
        public string InvNo { get; set; }
        public Nullable<System.DateTime> InvDate { get; set; }
        public string CalAgncy { get; set; }
        public string MstrStats { get; set; }
        public byte[] Barcode { get; set; }
        public Nullable<int> lab_id { get; set; }
        public Nullable<bool> AiSts { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<System.DateTime> AddDate { get; set; }
        public Nullable<int> EditBy { get; set; }
        public Nullable<System.DateTime> EditDate { get; set; }
        public string po_no { get; set; }
        public Nullable<System.DateTime> po_date { get; set; }
        public string req_no { get; set; }
        public Nullable<System.DateTime> req_date { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
    }
    public partial class CAL_M004A
    {
        public int ExtInst_Id { get; set; }
        public int ExtInstCod { get; set; }
        public int PrtyId { get; set; }
        public string ExtInstIdNo { get; set; }
        public string LabCode { get; set; }
        public string InstMake { get; set; }
        public string Range { get; set; }
        public string CalSrc { get; set; }
        public string FileName { get; set; }
        public string Accuracy { get; set; }
        public string LeastCnt { get; set; }
        public Nullable<decimal> CalFreq { get; set; }
        public string CalPerid { get; set; }
        public string CalInstNo { get; set; }
        public string TechSpec { get; set; }
        public string CalRptNo { get; set; }
        public Nullable<decimal> CalChrgs { get; set; }
        public Nullable<bool> AiSts { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<System.DateTime> AddDate { get; set; }
        public Nullable<int> EditBy { get; set; }
        public Nullable<System.DateTime> EditDate { get; set; }
        public string PartyId { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
    }
    public partial class CAL_M005
    {
        public int Rcpt_Id { get; set; }
        public string RcptNo { get; set; }
        public string ExtInst_Id { get; set; }
        public Nullable<System.DateTime> RcptDate { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public string CalStat { get; set; }
        public Nullable<int> PrtyId { get; set; }
        public Nullable<int> RcvBy { get; set; }
        public string RcvPerContNo { get; set; }
        public string RcvPerContEx { get; set; }
        public string InstrDesc { get; set; }
        public string UserId { get; set; }
        public Nullable<System.DateTime> AddDate { get; set; }
        public string EditBy { get; set; }
        public Nullable<System.DateTime> EditDate { get; set; }
        public string PartyId { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
    }
    public partial class ADM_M010
    {
        public int id { get; set; }
        public string UserId { get; set; }
        public Nullable<int> UserTypCode { get; set; }
        public string Password { get; set; }
        public string Title { get; set; }
        public string EmpId { get; set; }
        public Nullable<bool> LogSts { get; set; }
        public Nullable<System.DateTime> ValidFrm { get; set; }
        public Nullable<System.DateTime> ValidTo { get; set; }
        public Nullable<bool> UserBlkSts { get; set; }
        public Nullable<bool> LockStat { get; set; }
        public string LockBy { get; set; }
        public Nullable<System.DateTime> LockDate { get; set; }
        public string UnlockBy { get; set; }
        public Nullable<System.DateTime> UnlockDate { get; set; }
        public byte[] Photo { get; set; }
        public Nullable<bool> active { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string add_by { get; set; }
        public string EmpNm { get; set; }
        public string UserTyp { get; set; }
    }
    public partial class ZADM_M001
    {
        public int ball_dia_id { get; set; }
        public decimal ball_dia { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string edit_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
    }
    public partial class ZADM_M003
    {
        public int wire_size_id { get; set; }
        public decimal wire_size { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string edit_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
    }
    public partial class ZADM_M004
    {
        public int wire_type_id { get; set; }
        public string wire_type { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string edit_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
    }
    public partial class ZADM_M005
    {
        public int usedin_id { get; set; }
        public string usedin { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string edit_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
    }
    public partial class ZADM_M006
    {
        public int ink_id { get; set; }
        public string ink { get; set; }
        public Nullable<int> make_id { get; set; }
        public string desc { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
        public string Make { get; set; }
    }
    public partial class ZADM_M007
    {
        public int ild_id { get; set; }
        public string ild { get; set; }
        public string ild_type { get; set; }
        public string tip_type { get; set; }
        public Nullable<decimal> min_val { get; set; }
        public Nullable<decimal> max_val { get; set; }
        public Nullable<decimal> avg_max { get; set; }
        public Nullable<decimal> avg_min { get; set; }
        public string desc { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
        public string show_ild { get; set; }
    }
    public partial class ZADM_M008
    {
        public int tot_len_id { get; set; }
        public string total_len { get; set; }
        public string details { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string edit_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
    }
    public partial class ZADM_M009
    {
        public int model_id { get; set; }
        public string basicmodel { get; set; }
        public string modelno { get; set; }
        public string modeldesc { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<int> wire_size_id { get; set; }
        public string drwgno { get; set; }
        public byte[] drgflnm { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string modlnm { get; set; }
        public string editby { get; set; }
        public Nullable<decimal> wire_size { get; set; }
    }
    public partial class ZADM_M010
    {
        public int prod_id { get; set; }
        public Nullable<int> model_id { get; set; }
        public Nullable<int> wire_type_id { get; set; }
        public Nullable<int> wire_size_id { get; set; }
        public Nullable<int> ball_dia_id { get; set; }
        public Nullable<int> ball_type_id { get; set; }
        public Nullable<decimal> shank_dia { get; set; }
        public Nullable<int> tot_len_id { get; set; }
        public string tipshape { get; set; }
        public string tip_type { get; set; }
        public string blank { get; set; }
        public Nullable<decimal> extrapiece { get; set; }
        public Nullable<int> usedin_id { get; set; }
        public Nullable<decimal> noofball { get; set; }
        public string needlelen { get; set; }
        public string needledia { get; set; }
        public string shanklen { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string prodnm { get; set; }
        public string editby { get; set; }
        public string model { get; set; }
        public string wiretype { get; set; }
        public string totallength { get; set; }
        public string balltype { get; set; }
        public Nullable<decimal> balldia { get; set; }
        public Nullable<decimal> wiresize { get; set; }
        public string ItemCode { get; set; }
        public string ink { get; set; }
        public string ild { get; set; }
    }
    public partial class ZADM_M011
    {
        public int machine_type_id { get; set; }
        public string machine_type { get; set; }
        public string remark { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string edit_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
    }
    public partial class ZADM_M012
    {
        public int machine_subtype_id { get; set; }
        public string machine_subtype { get; set; }
        public string remark { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string edit_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
    }
    public partial class ZADM_M013
    {
        public int machine_id { get; set; }
        public string machinecode { get; set; }
        public Nullable<int> machine_type_id { get; set; }
        public string machinedesc { get; set; }
        public string packingcode { get; set; }
        public Nullable<decimal> machineorder { get; set; }
        public Nullable<int> make_id { get; set; }
        public string electricitypara { get; set; }
        public string mechpara { get; set; }
        public string machinesrno { get; set; }
        public string actualsrno { get; set; }
        public string connload { get; set; }
        public string otherpara { get; set; }
        public string purchaseyr { get; set; }
        public Nullable<int> machine_subtype_id { get; set; }
        public string mctype { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public Nullable<int> machinecap_id { get; set; }
        public string comp_code { get; set; }
        public string EmpId { get; set; }
        public string editby { get; set; }
        public string location_Id { get; set; }
        public string CompName { get; set; }
        public string machine_type { get; set; }
        public string machine_subtype { get; set; }
        public string EmpName { get; set; }
        public string Make { get; set; }
    }
    public partial class ZADM_M014
    {
        public int writingtest_id { get; set; }
        public string tip_type { get; set; }
        public string writspeed { get; set; }
        public string paperfeed { get; set; }
        public Nullable<int> machine_id { get; set; }
        public string effwt { get; set; }
        public string arialrotation { get; set; }
        public string papertype { get; set; }
        public string remarks { get; set; }
        public string angle { get; set; }
        public string weight { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string edit_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
    }

}
