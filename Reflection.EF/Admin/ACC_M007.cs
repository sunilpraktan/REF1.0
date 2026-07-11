using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public class ACC_M007 : ObjectBase
    {

        public string pt_code { get; set; }
        public string pt_name { get; set; }
        public string short_text { get; set; }
        public string pay_method { get; set; }
        public bool? active { get; set; }
        public string ind_default { get; set; }
        public string XDOC_A { get; set; }

       
    }
    public class ACC_M007_A : ObjectBase
    {
        public int? id { get; set; }
        public string pt_code { get; set; }
        public int? days { get; set; }
        public string disc_type { get; set; }
        public decimal? discount { get; set; }
        public int? fix_day { get; set; }
        public int? add_month { get; set; }
        public string active { get; set; }
        public string ind_delivery { get; set; }
        public string ind_billing { get; set; }
        public decimal? pay_amount { get; set; }

    }
}
