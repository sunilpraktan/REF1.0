using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Finance
{
   public class ACC_M003_B
    {
        public int id { get; set; }
        public string ac_sg_code { get; set; }
        public string ac_group_code { get; set; }
        public string ac_sg_name { get; set; }
        public Nullable<int> sg_parent_Id { get; set; }
        public string sg_parent_code { get; set; }
        public string s_desc { get; set; }
        public Nullable<int> seq_no { get; set; }
        public string code_format { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string ac_group_name { get; set; }
    }
}
