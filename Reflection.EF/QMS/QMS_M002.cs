using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.QMS
{
    public partial class QMS_M002 : ObjectBase
    {
        public int id { get; set; }
        public string sgrcode { get; set; }
        public string sgrname { get; set; }
        public string sgrdesc { get; set; }
        public string grcode { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public Nullable<bool> active { get; set; }
        public string language { get; set; }
        //---Scalar
        public string grname { get; set; }
    }
    
}
