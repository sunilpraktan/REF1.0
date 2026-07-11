using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Finance
{
   public class ACC_M003_S
    {
        public string acc_pro { get; set; }
        public string acc_pro_desc { get; set; }
        public Nullable<bool> active { get; set; }
    }
   public class ACC_M003_S1
    {
        public string acc_pro { get; set; }
        public string con_type { get; set; }
        public Nullable<int> step { get; set; }
        public Nullable<int> sequence { get; set; }
        public string con_type_desc { get; set; }
    }

    public class ACC_M003_S2
    {
        public int id { get; set; }
        public string acc_pro { get; set; }
        public string doc_type { get; set; }
        public Nullable<bool> active { get; set; }
    }
}
