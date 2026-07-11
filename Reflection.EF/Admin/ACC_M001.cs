using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Finance
{
    public class ACC_M001
    {
        public string group_comp { get; set; }
        public string fin_year_var { get; set; }
        public string fin_year_desc { get; set; }
        public bool? period_cal { get; set; }
        public bool? year_dep { get; set; }
        public int? num_per { get; set; }
        public int? num_spe { get; set; }
    }

    public class ACC_M001_A : ObjectBase
    {
        public string posting_period { get; set; }
        public string fin_year { get; set; }
        public string short_desc { get; set; }
        public int? post_year { get; set; }
        public int? calender_year { get; set; }
        public int? post_per { get; set; }
        public int? post_mon { get; set; }
        public string long_desc { get; set; }
        public string qtr { get; set; }
        public int? id { get; set; }
        public int? group_comp { get; set; }
        public string fyear_var { get; set; }
        public int? cal_days { get; set; }
        public string shift_year { get; set; }
        public string status { get; set; }
        public bool? active { get; set; }
        public string add_by { get; set; }
        public DateTime? add_date { get; set; }
        public string editby { get; set; }
        public DateTime? edit_date { get; set; }
    }
}
