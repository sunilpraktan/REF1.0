using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ZADM_M014 : ObjectBase
    {
        public int writingtest_id { get; set; }
        public string tip_type { get; set; }
        public string writspeed { get; set; }
        public string paperfeed { get; set; }
        public Nullable<int> machine_id { get; set; }
        public string effwt { get; set; }
        public string arialrotation { get; set; }
        public string papertype { get; set; }
        public string remarks { get; set; }
        public string angle { get; set; }
        public string weight { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string edit_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
    }
}
