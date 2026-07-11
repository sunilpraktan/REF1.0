using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.CRM
{
    public partial class COM_T002_B : ObjectBase
    {
        public int id { get; set; }
        public string doc_type { get; set; }
        public Nullable<int> doc_id { get; set; }
        public Nullable<int> follower_id { get; set; }
        public Nullable<bool> active { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string edit_by { get; set; }
        public string follower_type { get; set; }
        public string editby { get; set; }
    }

    public partial class COM_T002_C
    {
        public int id { get; set; }
        public Nullable<bool> msg_read { get; set; }
        public Nullable<System.DateTime> read_date { get; set; }
        public Nullable<bool> starred { get; set; }
        public Nullable<System.DateTime> starred_date { get; set; }
        public Nullable<int> follower_id { get; set; }
        public Nullable<int> msg_id { get; set; }
        public Nullable<bool> active { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string edit_by { get; set; }
        public string follower_type { get; set; }
        public string editby { get; set; }
    }

}
