using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.SCM.ReportEntitySCM
{
    public class MIS_SCM_Report1
    {
        public string doc_no { get; set; }
        public DateTime? doc_date { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string comp_code { get; set; }
        public string doc_type_user { get; set; }
        public string doc_desc_user { get; set; }
        public string EmpId { get; set; }
        public string PartyId { get; set; }
        public string PartyNm { get; set; }
        public string location_Id { get; set; }
        public string ItemCode { get; set; }
        public string description { get; set; }
        public string CstmrItmCod { get; set; }
        public string CstmrItmDesc { get; set; }
        public string machinecode { get; set; }
        public Nullable<int> machine_id { get; set; }
        public Decimal? qty { get; set; }
        public Decimal? unit_price { get; set; }
        public Decimal? amount { get; set; }
        public string unit_code { get; set; }
        public string sku { get; set; }
        public string sku_desc { get; set; }
        public string sending_plant { get; set; }
        public string rec_plant { get; set; }
        public string notes { get; set; }
        public string CatCode { get; set; }
        public string SubCatCode { get; set; }
        public string ItemTypeCd { get; set; }
        public string SubItemTpCd { get; set; }
        public string t_status { get; set; }
        public string mov_tp { get; set; }
        public string del_note { get; set; }
        public DateTime? del_note_date { get; set; }
        public DateTime? post_date { get; set; }
        public string source_doc_no { get; set; }
        public DateTime? source_doc_date { get; set; }
        public string po_no { get; set; }
        public DateTime? po_date { get; set; }
        public string sono { get; set; }
        public DateTime? so_date { get; set; }
    }
}
