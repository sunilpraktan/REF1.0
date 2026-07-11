using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.QMS
{
    public partial class QMS_M008 : ObjectBase
    {
        public string rig_code { get; set; }
        public int id { get; set; }
        public string lab_code { get; set; }
        public string rig_abbr { get; set; }
        public string rig_name { get; set; }
        public string contprsn_code { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public Nullable<bool> active { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        //SCALAR
        public string EmpName { get; set; }
        public string lab_name { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }
    }
}
