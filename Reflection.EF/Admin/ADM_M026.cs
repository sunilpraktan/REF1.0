using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ADM_M026 : ObjectBase
    {
        public string desig_code { get; set; }
        public int id { get; set; }
        public string DesigName { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        //scalar
        public string XmlDataDocument_FlipGrid { get; set; }
    }
}
