using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.ReflectionSystem
{
   public class SYS_M023 : ObjectBase
    {
        public string doc_type { get; set; }

        public string comp_code { get; set; }
        public string CatCode { get; set; }

        public Nullable<bool> active { get; set; }

        //scalar
        public string doc_cat { get; set; }
        public string doc_desc_user { get; set; }
    }
}
