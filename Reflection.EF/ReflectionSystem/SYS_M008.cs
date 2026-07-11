using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.ReflectionSystem
{
    public partial class SYS_M008 : ObjectBase
    {
        public int id { get; set; }
        public string item_cat { get; set; }
        public string cat_desc { get; set; }
        public string good_rec_ind { get; set; }
        public string invoice_rec_ind { get; set; }
    }
}
