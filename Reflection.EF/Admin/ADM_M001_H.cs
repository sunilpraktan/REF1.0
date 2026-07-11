using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public class ADM_M001_H : ObjectBase
    {
        public int id { get; set; }
        public string sg_code { get; set; }
        public string sg_name { get; set; }
        public string sg_desc { get; set; }
        public bool? active { get; set; }
        public string so_code { get; set; }
    }

}
