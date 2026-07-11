using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class UserVerification_Result
    {
        public int SrNo { get; set; }
        public int inst_id { get; set; }
        public string instName { get; set; }
        public string IdNo { get; set; }
        public Nullable<System.DateTime> PurchDate { get; set; }
        public string InstMake { get; set; }
        public string Range { get; set; }
        public string MaintSrc { get; set; }
        public string RigName { get; set; }
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
        public string LabName { get; set; }
        public Nullable<int> lab_id { get; set; }
        public Nullable<bool> AiSts { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<System.DateTime> AddDate { get; set; }
        public Nullable<int> EditBy { get; set; }
        public Nullable<System.DateTime> EditDate { get; set; }
    }
}
