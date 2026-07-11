using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.CRM
{
    public partial class SEL_T002Insert_Result
    {
        public int id { get; set; }
        public Nullable<int> party_id { get; set; }
        public string party_name { get; set; }
        public string sch_no { get; set; }
        public Nullable<System.DateTime> sch_date { get; set; }
        public Nullable<System.TimeSpan> sch_time { get; set; }
        public Nullable<int> sch_by { get; set; }
        public string schedular_name { get; set; }
        public string sch_mode { get; set; }
        public Nullable<int> sch_rec_by { get; set; }
        public string sch_rec_name { get; set; }
        public string remark { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string edit_by { get; set; }
    }


    public partial class SEL_T002LoadAll_Result
    {
        public int id { get; set; }
        public Nullable<int> party_id { get; set; }
        public string party_name { get; set; }
        public string sch_no { get; set; }
        public Nullable<System.DateTime> sch_date { get; set; }
        public Nullable<System.TimeSpan> sch_time { get; set; }
        public Nullable<int> sch_by { get; set; }
        public string schedular_name { get; set; }
        public string sch_mode { get; set; }
        public Nullable<int> sch_rec_by { get; set; }
        public string sch_rec_name { get; set; }
        public string remark { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string edit_by { get; set; }
    }

}
