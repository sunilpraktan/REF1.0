using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Production
{
    public partial class ZCRM_T002_1 : ObjectBase
    {
        public string doc_no { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string ItemCode { get; set; }
        public string token_no { get; set; }
        public string batch_no { get; set; }
        public Nullable<System.DateTime> posting_date { get; set; }
        public string machinecode { get; set; }
        public string shift { get; set; }
        public string shift_supervisor { get; set; }
        public Nullable<decimal> qty { get; set; }
        public string spelling_damage { get; set; }
        public string ball_griping_force { get; set; }
        public string body_damage { get; set; }
        public string channel_out { get; set; }
        public string hammer_out { get; set; }
        public string capillary_out { get; set; }
        public string other_problems { get; set; }
        public string remark { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string sku { get; set; }
        public string sku_desc { get; set; }
        public string t_status { get; set; }
        public Nullable<bool> active { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string conversion_no { get; set; }
        public string unit_code { get; set; }
    }
}
