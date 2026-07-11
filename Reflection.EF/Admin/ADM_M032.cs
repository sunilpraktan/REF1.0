using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ADM_M032 : ObjectBase
    {
        public int MakeCode { get; set; }
        public string Make { get; set; }
        public string Descriptn { get; set; }
        public string make_type { get; set; }
        public string ink { get; set; }
        public string location_Id { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public Nullable<bool> active { get; set; }
    }
}
