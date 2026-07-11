using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Finance
{
    public partial class ACC_M003_X //Account Modifier for Movement Type
    {
        public int id { get; set; }
        public string mov_tp { get; set; }
        public Nullable<bool> val_update { get; set; }
        public Nullable<bool> qty_update { get; set; }
        public string key_value { get; set; }
        public string mov_ind { get; set; }
        public string cons_post { get; set; }
        public string item_cat { get; set; }
        public string sp_stock { get; set; }
        public string acc_var { get; set; }
        public string client { get; set; }
        //Scalar
        public string tran_key { get; set; }
        public bool Click { get; set; }
    }   
}
