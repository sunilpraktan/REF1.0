using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ADM_M030 : ObjectBase
    {
        public int id { get; set; }
        public string value_code { get; set; }
        public string parametervalue { get; set; }
        public string para_code { get; set; }
        public string type { get; set; }
        public string location_Id { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string unit_code { get; set; }
        public string para_name { get; set; }
        public string unit_name { get; set; }
        public bool active { get; set; }
        public string XmlDataDocument_ADM_M030 { get; set; }
    }
}
