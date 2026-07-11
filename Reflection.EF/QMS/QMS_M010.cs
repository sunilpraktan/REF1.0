using System;

namespace Reflection.EF.QMS
{
    public partial class QMS_M010 : ObjectBase
    {
        public string tr_code { get; set; }
        public string tr_name { get; set; }
        public string tr_desc { get; set; }
        public bool? active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public DateTime add_date { get; set; }
        public string editby { get; set; }
        public DateTime? edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string lang_key { get; set; }
        public string uncertainty { get; set; }
        public string XmlDataDocument_QMS_M010FLIP { get; set; }
    }
}
