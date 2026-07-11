using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class COM_T002_G : ObjectBase
    {
        public int id { get; set; }
        public string host { get; set; }
        public Nullable<int> port { get; set; }
        public Nullable<bool> enableSSL { get; set; }
        public Nullable<int> timeOut { get; set; }
        public string deliveryMethod { get; set; }
        public Nullable<bool> defaultCredentials { get; set; }
        public string mailID { get; set; }
        public string displayName { get; set; }
        public string password { get; set; }
        public string domain { get; set; }
    }
}
