using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ADM_M018 : ObjectBase
    {
        public string item_cat { get; set; }
        public string item_cat_name { get; set; }
        public string CatCode { get; set; }
        public int? CatId { get; set; }
        public string CatName { get; set; }
        public string add_by { get; set; }
        public DateTime? add_date { get; set; }
        public string editby { get; set; }
        public DateTime? edit_date { get; set; }
        public string acc_cat { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }
        //Scalar
        public string short_name { get; set; }
        public string cat_desc { get; set; }
    }

}
