using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ADM_M036 : ObjectBase
    {
        public int id { get; set; }
        public string location_Id { get; set; }
        public string ItemCode { get; set; }
        public Nullable<bool> active { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
    }
}
