using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.QMS
{
    public partial class QMS_M022 : ObjectBase
    {
        public string comp_code { get; set; }
        public int id { get; set; }
        public string qualification { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string description { get; set; }
        public Nullable<bool> active { get; set; }
        public string location_Id { get; set; }
        public string editby { get; set; }
        public string XmlDataDocument_QMS_M022_Flip { get; set; }
        public string abbreviation { get; set; }
        public string EmpId { get; set; }
        public string qua_spe { get; set; }
        public Nullable<System.DateTime> from_date { get; set; }
        public Nullable<System.DateTime> to_date { get; set; }
        public string institution { get; set; }
        public string marks { get; set; }
        public string qua_grade { get; set; }
        public string remark { get; set; }

    }
}
