using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
     public class ACC_M019 : ObjectBase
    {
        public string cost_center { get; set; }
        public int id { get; set; }
        public string cost_center_Desc { get; set; }
        public int cc_mgr { get; set; }
        public string cc_dept_code { get; set; }
        public int cc_category { get; set; }
        public Nullable<System.DateTime> valid_from { get; set; }
        public Nullable<System.DateTime> valid_to { get; set; }
        public string cc_curr_code { get; set; }
        public string cc_profit_center { get; set; }
        public string comp_code { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string pin { get; set; }
        public string region { get; set; }
        public string phone_no { get; set; }
        public string fax_no { get; set; }
        public string cell_no { get; set; }
        public string location_Id { get; set; }
        public Nullable<bool> active { get; set; }
        public System.DateTime add_date { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string editby { get; set; }

        //scalar
        public string DeptName { get; set; }
        public string curr_name { get; set; }
        public string profit_center_Desc { get; set; }
        public string dept_code { get; set; }
        public string curr_code { get; set; }
        public string profit_center { get; set; }


    }
}
