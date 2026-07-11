using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ZADM_M027 : ObjectBase
    {
        public int id { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string language { get; set; }
        public Nullable<decimal> wire_size { get; set; }
        public string wire_type { get; set; }
        public Nullable<decimal> ball_size { get; set; }
        public string ball_type { get; set; }
        public string total_len { get; set; }
        public decimal? gradeA_rate { get; set; }
        public decimal? ex_grA_rate { get; set; }
        public decimal? gradeB_rate { get; set; }
        public decimal? ex_grB_rate { get; set; }
        public decimal? gradeC_rate { get; set; }
        public decimal? ex_grC_rate { get; set; }
        public string rate_unit { get; set; }
        public string month { get; set; }
        public string year { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public Nullable<System.DateTime> revised_date { get; set; }
        public string monthyear { get; set; }
        public Nullable<int> post_year { get; set; }
        public Nullable<int> post_mon { get; set; }

    }
    public partial class ZADM_M027_A
    {
        public int id { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string ball_type { get; set; }
        public Nullable<decimal> dia_from { get; set; }
        public Nullable<decimal> dia_to { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public Nullable<System.DateTime> revised_date { get; set; }
        public string month { get; set; }
        public string year { get; set; }
        public string monthyear { get; set; }
        public Nullable<int> post_year { get; set; }
        public Nullable<int> post_mon { get; set; }
    }   
}
