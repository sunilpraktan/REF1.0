using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Production
{
   public partial class EPR_T005_A : ObjectBase
    {
        public string doc_no { get; set; }
        public string doc_cat { get; set; }
        public string doc_type { get; set; }
        public Nullable<System.DateTime> doc_date { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string language { get; set; }
        public string gl_code { get; set; }
        public string fin_year { get; set; }
        public string posting_period { get; set; }
        public string report_type { get; set; }
        public Nullable<int> font { get; set; }
        public Nullable<System.DateTime> prod_date { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public Nullable<bool> label_used_flag{ get; set; }
    }

    public partial class EPR_T005_B
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public string report_type { get; set; }
        public string para { get; set; }
        public string value { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public Nullable<bool> active { get; set; }
        public string para_code { get; set; }
    }

    public class EPR_T005
    {
        public int id { get; set; }
        public string para1 { get; set; }
        public string para2 { get; set; }
        public string para3 { get; set; }
        public string para4 { get; set; }
        public string para5 { get; set; }
        public string para6 { get; set; }
        public string para7 { get; set; }
        public string para8 { get; set; }
        public string para9 { get; set; }
        public string text1 { get; set; }
        public string text2 { get; set; }
        public string report_type { get; set; }
        public string para_code { get; set; }
    }
}
