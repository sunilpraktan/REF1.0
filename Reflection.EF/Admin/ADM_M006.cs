using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ADM_M006 : ObjectBase
    {
        public string ModGrpCode { get; set; }
        public string ModGrpNm { get; set; }
        public Nullable<System.DateTime> ImplimtDt { get; set; }
        public string Title { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string add_by { get; set; }
    }

}
