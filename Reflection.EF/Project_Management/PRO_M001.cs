using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Project_Management
{ 
    public partial class PRO_M001 : ObjectBase
    {
        public string cat_id { get; set; }
        public string cat_title { get; set; }
        public bool active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string XmlDataDocument_DataGridView { get; set; }
        
    }
    
}
