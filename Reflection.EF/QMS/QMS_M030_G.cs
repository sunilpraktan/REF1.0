using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.QMS
{
    public partial class QMS_M030_G
    {
        public string client { get; set; }
        public string insp_method { get; set; }
        public string version_no { get; set; }
        public Nullable<System.DateTime> valid_from { get; set; }
        public string inspector_qualification { get; set; }
        public string method_desc { get; set; }
        public string comp_code { get; set; }
        public Nullable<bool> active { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string user_source1 { get; set; }
        public string user_source2 { get; set; }
        public string t_status { get; set; }
        public string lang_key { get; set; }
        public string XmlDataDocument_QMS_M030_G_Flip { get; set; }

        public string qualiDesc { get; set; }
    }
}
