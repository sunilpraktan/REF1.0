using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.SCM
{
    public partial class MM_M005 : ObjectBase
    {
        public int QuantID { get; set; }
        public Nullable<int> QuantNumber { get; set; }
        public string QuantName { get; set; }
        public string RowNo { get; set; }
        public string ColumnNo { get; set; }
        public string t_status { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string wa_code { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
    }

}
