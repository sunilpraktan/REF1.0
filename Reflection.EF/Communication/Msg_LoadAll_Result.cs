using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Communication
{
    public partial class Msg_LoadAll_Result
    {
        public int id { get; set; }
        public string msg_body { get; set; }
        public Nullable<int> author_id { get; set; }
        public Nullable<int> parent_id { get; set; }
        public string msg_category { get; set; }
        public string sender_email { get; set; }
        public Nullable<bool> msg_read { get; set; }
        public Nullable<bool> starred { get; set; }
        public Nullable<int> follower_id { get; set; }
        public byte[] Photo { get; set; }
    }

}
