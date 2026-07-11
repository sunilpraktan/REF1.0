using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.CRM
{
    public partial class ECRM_T003_A : ObjectBase
    {
        public string client { get; set; }
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
     //   public string Conv_no { get; set; }
        public string obrem { get; set; }
        public string uhdec { get; set; }
        public string uhrem { get; set; }
        public string itemname { get; set; }
        public string EmpId { get; set; }
        public Nullable<decimal> check_qty { get; set; }
        public Nullable<decimal> counter_qty { get; set; }
        public string test_code { get; set; }
        public string EmpNm { get; set; }
        public string order_no { get; set; }
        public string batch_no { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string ild { get; set; }
        public decimal shank_dia { get; set; }
        public string shanklen { get; set; }
        public string ShankChamfer { get; set; }
        public string needlelen { get; set; }
        public string needledia { get; set; }
        public string TotalLen { get; set; }
        public string ballout { get; set; }
        
    }

    public partial class ECRM_T003_B
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
    }

}
