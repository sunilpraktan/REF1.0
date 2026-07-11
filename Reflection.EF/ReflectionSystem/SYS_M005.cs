using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.ReflectionSystem
{
    public partial class SYS_M005 : ObjectBase
    {
        public int id { get; set; }
        public string comp_code { get; set; }
        public string delivery_type { get; set; }
        public string del_desc { get; set; }
        public string doc_code { get; set; }
        public string doc_cat_code { get; set; }
        public string insp_lot_org { get; set; }
        public Nullable<bool> so_req { get; set; }
    }
}
