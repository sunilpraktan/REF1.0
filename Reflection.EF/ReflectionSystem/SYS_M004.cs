using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.ReflectionSystem
{
    public partial class SYS_M004 : ObjectBase
    {
        public int id { get; set; }
        public string comp_code { get; set; }
        public string sch_cat { get; set; }
        public string cat_desc { get; set; }
        public Nullable<bool> del_req { get; set; }
        public string mov_tp { get; set; }
        public string order_type { get; set; }
        public string pitem_cat { get; set; }
    }
}
