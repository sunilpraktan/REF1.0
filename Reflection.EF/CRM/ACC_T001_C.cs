using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.CRM
{
    public partial class ACC_T001_C : ObjectBase
    {
        public int id { get; set; }
        public Nullable<int> inv_line_id { get; set; }
        public Nullable<int> tax_id { get; set; }
    }

}
