using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Communication
{
    public partial class COM_T002_A : ObjectBase
    {
        public int id { get; set; }
        public string from_id { get; set; }
        public string to_id { get; set; }
        public string msg_body { get; set; }
        public string doc_type { get; set; }
        public string doc_name { get; set; }
        public Nullable<System.DateTime> msg_date { get; set; }
        public string subject { get; set; }
        public string msg_id { get; set; }
        public Nullable<int> parent_id { get; set; }
        public Nullable<int> doc_id { get; set; }
        public Nullable<int> msg_type_id { get; set; }
        public Nullable<int> author_id { get; set; }
        public string msg_category { get; set; }
        public string sender_email { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
    }
}
