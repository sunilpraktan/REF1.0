using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.SCM
{
    public partial class MM_M001 : ObjectBase
    {
        public string store_code { get; set; }
        public int? id { get; set; }
        public string comp_code { get; set; }
        public string CompName { get; set; }
        public string location_Id { get; set; }
        public string LoctnNm { get; set; }
        public string store_name { get; set; }
        public string div_code { get; set; }
        public Nullable<bool> neg_stock_ind { get; set; }
        public string rec_ship_point { get; set; }
        public bool default_storage_loc { get; set; }
        public Nullable<bool> active { get; set; }
        public string location_id { get; set; }
    }

    public class MM_M004
    {
        public string mov_tp { get; set; }
        public string mov_tp_name { get; set; }
        public string mov_tp_desc { get; set; }
        public string debit_credit { get; set; }
        public string con_post { get; set; }
        public string gr_block_stock { get; set; }
        public string batch_control { get; set; }
        public string insp_qa { get; set; }
        public string mov_cat { get; set; }
        public string rev_mov_tp { get; set; }
        public bool? active { get; set; }
        public string post_key_ref { get; set; }

        // Scaler Fields
        public string doc_type { get; set; }

    }
}
