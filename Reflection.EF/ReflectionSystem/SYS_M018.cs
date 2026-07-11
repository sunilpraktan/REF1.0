using Reflection.EF;
using System;

namespace Reflection.BusinessEntity
{
    public partial class SYS_M018 : ObjectBase
    {
        public int id { get; set; }
        public string EmpId { get; set; }
        public string UserId { get; set; }
        public string popup_alert_file { get; set; }
        public string popup_alert_name { get; set; }
        public int alert_before_days { get; set; }
        public int PeriodDays { get; set; }

    }
}
