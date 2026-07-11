using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Communication
{
    public partial class BaseTask : ObjectBase
    {
        public int id { get; set; }
        public int folder_id { get; set; }
        public string task_desc { get; set; }
        public Nullable<int> tsk_priority { get; set; }
        public Nullable<System.TimeSpan> est_time { get; set; }
        public Nullable<System.DateTime> start_date { get; set; }
        public Nullable<System.TimeSpan> start_time { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
        public Nullable<System.TimeSpan> end_time { get; set; }
        public Nullable<int> assign_by { get; set; }
        public Nullable<int> assign_to { get; set; }
        public string doc_type { get; set; }
        public Nullable<int> doc_id { get; set; }
        public Nullable<bool> completed { get; set; }
        public string comp_remark { get; set; }
        public Nullable<System.DateTime> close_date { get; set; }
        public string task_type { get; set; }
        public string task_freq { get; set; }
        public Nullable<int> day_freq { get; set; }
        public Nullable<int> freq_no { get; set; }
        public Nullable<System.TimeSpan> trigger_time { get; set; }
        public string tsk_status { get; set; }
        public Nullable<bool> active { get; set; }
        public Nullable<int> add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public Nullable<int> edit_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public int folderid { get; set; }
        public int task_id { get; set; }
        public string folder_name { get; set; }
        public string color_code { get; set; }
    }

}
