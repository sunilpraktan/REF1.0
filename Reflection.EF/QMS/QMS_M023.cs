using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.QMS
{
    public partial class QMS_M023 : ObjectBase
    {
        public int id { get; set; }
        public int qualification_id { get; set; }
        public string descriptn_short { get; set; }
        public string descriptn_long { get; set; }
        public string location_Id { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string qualification { get; set; }
    }
}
