using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Communication
{
    public partial class COM_T004 : ObjectBase
    {
        public string sch_no { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string schedule_type { get; set; }
        public string occurs { get; set; }
        public Nullable<int> recurs_every { get; set; }
        public string occurs_once_tm { get; set; }
        public Nullable<int> occurs_every_int { get; set; }
        public string start_tm { get; set; }
        public string end_tm { get; set; }
        public Nullable<System.DateTime> start_date { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
        public Nullable<bool> no_end_dt { get; set; }
        public string description { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string edit_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string lang_key { get; set; }
        public string wk_day { get; set; }
        public Nullable<int> month_day { get; set; }
        public Nullable<int> month { get; set; }
        public Nullable<bool> day { get; set; }
        public Nullable<bool> the { get; set; }
        public string the_wk { get; set; }
        public string the_day { get; set; }
        public Nullable<bool> occurs_once_at { get; set; }
        public Nullable<bool> occurs_every { get; set; }
        public string occurs_every_var { get; set; }
        public Nullable<bool> end_dt { get; set; }

        //For Radio Button
        //public Nullable<bool> ButtonDayIsChecked { get; set; }
        //public Nullable<bool> ButtonTheIsChecked { get; set; }
        //public Nullable<bool> ButtonOccurrsOnceAtIsChecked { get; set; }
        //public Nullable<bool> ButtonOccursEveryIsChecked { get; set; }
        //public Nullable<bool> ButtonEndDtIsChecked { get; set; }
        //public Nullable<bool> ButtonNoEndDtIsChecked { get; set; }
    }
}
