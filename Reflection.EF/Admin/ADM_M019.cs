using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ADM_M019 : ObjectBase
    {
        public string item_subcat { get; set; }
        public string item_subcat_name { get; set; }
        public string item_cat { get; set; }
        public string active { get; set; }
        public bool? selected { get; set; }

        public string SubCatCode { get; set; }
        public int? SubCatId { get; set; }
        public string SubCatName { get; set; }
        public string CatCode { get; set; }
        public string add_by { get; set; }
        public DateTime? add_date { get; set; }
        public string editby { get; set; }
        public DateTime? edit_date { get; set; }
        public string CatName { get; set; }
        public string lang_key { get; set; }
    }
}
