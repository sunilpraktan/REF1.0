using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ZADM_M009 : ObjectBase
    {
        public int model_id { get; set; }
        public string basicmodel { get; set; }
        public string modelno { get; set; }
        public string modeldesc { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<int> wire_size_id { get; set; }
        public string drwgno { get; set; }
        public byte[] drgflnm { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string modlnm { get; set; }
        public string editby { get; set; }
        public Nullable<decimal> wire_size { get; set; }
    }

}
