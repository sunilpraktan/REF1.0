using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.ReflectionSystem
{
    public class SYS_M026 : ObjectBase
    {
        public string tr_mode { get; set; }
        public string tr_name { get; set; }
        public string tr_type { get; set; }
        public bool active { get; set; }
    }
    public class SYS_M036 : ObjectBase
    {
        public string sch_mode { get; set; }
        public string mode_name { get; set; }
        public string active { get; set; }
    }
    public class SYS_M037 : ObjectBase
    {
        public string ind_trade { get; set; }
        public string trade_name { get; set; }
        public string trade_type { get; set; }
    }
    public class SYS_M038
    {
        public string usage_code { get; set; }
        public string usage_desc { get; set; }
    }
    public class SYS_M039
    {
        public string client { get; set; }
        public string ind_base { get; set; }
        public string base_desc { get; set; }
    }
    public class SYS_M040
    {
        public string client { get; set; }
        public string ind_usage { get; set; }
        public string usage_desc { get; set; }
    }
    public class SYS_M041
    {
        public string client { get; set; }
        public string item_cat_bom { get; set; }
        public string cat_desc { get; set; }
    }
    public class SYS_M042
    {
        public string bom_cat { get; set; }
        public string cat_name { get; set; }
    }
    public class SYS_M043
    {
        public string wc_cat { get; set; }
        public string wc_cat_desc { get; set; }
    }
    public class SYS_M044
    {
        public string order_type { get; set; }
        public string type_desc { get; set; }
    }
    public class SYS_M045
    {
        public string pro_type { get; set; }
        public string pro_desc { get; set; }
    }
    public class SYS_M046
    {
        public string spl_pro { get; set; }
        public string pro_desc { get; set; }
    }
    public class SYS_M047
    {
        public string order_cat { get; set; }
        public string cat_name { get; set; }
    }
    public class SYS_M048
    {
        public string task_list_use { get; set; }
        public string use_name { get; set; }
    }
    public class SYS_M049
    {
        public string task_list_type { get; set; }
        public string type_name { get; set; }
        public string task_app { get; set; }
    }
    public class SYS_M050
    {
        public string bom_cat { get; set; }
        public string cat_name { get; set; }
    }
    public class SYS_M051
    {
        public string control_key { get; set; }
        public string control_key_desc { get; set; }
        public string task_list_application { get; set; }
    }
    public class SYS_M052
    {
        public string record_type { get; set; }
        public string type_name { get; set; }
        public string record_cat { get; set; }
        public string ind_qty { get; set; }
    }
    public class SYS_M054
    {
        public string pack_type { get; set; }
        public string pack_desc { get; set; }
    }
    public class SYS_M055
    {
        public string rpt_code { get; set; }
        public string rpt_name { get; set; }
    }
}
