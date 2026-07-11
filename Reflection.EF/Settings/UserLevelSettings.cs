using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Settings
{
    public class UserLevelSettings : ObjectBase
    {
        public int id { get; set; }
        public string UserId { get; set; }
        public string theme_code { get; set; }
        public string theme_name { get; set; }
        public string lang_key { get; set; }
        public byte[] desktop_file { get; set; }
        public string cmd_code { get; set; }
        // Scalars
        public string theme_title { get; set; }
        public string lang_desc { get; set; }
        public string cmd_name { get; set; }
        public string old_password { get; set; }
        public string new_password { get; set; }
        public string conf_password { get; set; }

        public string XmlDataDocument_SYS_C005 { get; set; }
        public string XmlDataDocument_SET_M005 { get; set; }
    }
}
