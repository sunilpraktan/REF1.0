using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.SCM.ReportEntitySCM
{
    public class MIS_SCM_Indent
    {
        public string req_no { get; set; }
        public DateTime date_start { get; set; }
        public decimal? qty { get; set; }
        public string t_status { get; set; }

        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string EmpId { get; set; }        
        public bool? active { get; set; }
        public string add_by { get; set; }
        public DateTime add_date { get; set; }
        public string editby { get; set; }
        public DateTime? edit_date { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string EmpName { get; set; }
        public string t_display { get; set; }

    }
}
