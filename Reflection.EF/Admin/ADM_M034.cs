using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ADM_M034 : ObjectBase
    {
        public string para_code { get; set; }
        public string SubCatCode { get; set; }
        public Nullable<bool> active { get; set; }
        public string ItemCode { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public Nullable<int> srno { get; set; }
        public string SubCatName { get; set; }
        public string para_name { get; set; }
    }
}
