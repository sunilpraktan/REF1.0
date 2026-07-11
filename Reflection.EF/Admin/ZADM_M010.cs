using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ZADM_M010 : ObjectBase
    {
        public int prod_id { get; set; }
        public Nullable<int> model_id { get; set; }
        public Nullable<int> wire_type_id { get; set; }
        public Nullable<int> wire_size_id { get; set; }
        public Nullable<int> ball_dia_id { get; set; }
        public Nullable<int> ball_type_id { get; set; }
        public Nullable<decimal> shank_dia { get; set; }
        public string shank_dia_tolce_plus { get; set; }
        public string shank_dia_tolce_mins { get; set; }
        public Nullable<int> tot_len_id { get; set; }
        public string tipshape { get; set; }
        public string tip_type { get; set; }
        public string blank { get; set; }
        public Nullable<decimal> extrapiece { get; set; }
        public Nullable<int> usedin_id { get; set; }
        public Nullable<decimal> noofball { get; set; }
        public string needlelen { get; set; }
        public string needlelen_tolce_plus { get; set; }
        public string needlelen_tolce_mins { get; set; }
        public string needledia { get; set; }
        public string needledia_tolce_plus { get; set; }
        public string needledia_tolce_mins { get; set; }
        public string shanklen { get; set; }
        public string shanklen_tolce_plus { get; set; }
        public string shanklen_tolce_mins { get; set; }
        public string needleangle { get; set; }
        public string frontpinlength { get; set; }
        public string pinlength { get; set; }
        public string frontpindia { get; set; }
        public string pindia { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string prodnm { get; set; }
        public string ItemCode { get; set; }
        public int ink_id { get; set; }
        public string ink { get; set; }
        public int ild_id { get; set; }
        public string ild { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public Nullable<bool> lifeTest { get; set; }
        public string unit_code { get; set; }
        public Nullable<decimal> ball_wt { get; set; }
        public Nullable<decimal> spring_wt { get; set; }
        public string prodname { get; set; }
        public string ball_content { get; set; }
        public string spring_content { get; set; }
        public string test_code { get; set; }
        //Scalar       
        public string wire_type { get; set; }
        public string modelno { get; set; }
        public decimal wire_size { get; set; }
        public decimal ball_dia { get; set; }
        public string ball_type { get; set; }
        public string total_len { get; set; }
      
    }
}
