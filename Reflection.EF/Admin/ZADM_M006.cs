using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ZADM_M006 : ObjectBase
    {
        public int ink_id { get; set; }
        public string ink { get; set; }
        public Nullable<int> make_id { get; set; }
        public string desc { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
        public string Make { get; set; }
        public string viscosity { get; set; }
    }

}
