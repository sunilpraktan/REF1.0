using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
     public partial class ENG_T003 : ObjectBase
    {
        public int id { get; set; }
        public string spec_para_code { get; set; }  
        public string spec_type_code { get; set; }
        public string para_details { get; set; }
        public string parameter { get; set; }
        public string posting_period { get; set; }
        public string fin_year { get; set; }
        public System.DateTime add_date { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }
        public Nullable<bool> active { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string t_status { get; set; }
        public string type { get; set; }
    }
  
     
      
}
