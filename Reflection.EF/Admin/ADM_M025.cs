using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ADM_M025 : ObjectBase
    {
        public int id { get; set; }
        public string dept_code { get; set; }
        public string DeptName { get; set; }
        public string active { get; set; }
        public bool? selected { get; set; }


        /// <summary>
        ///  all bellow depricated
        /// </summary>
        public string add_by { get; set; }
        public DateTime add_date { get; set; }
        public string editby { get; set; }
        public DateTime? edit_date { get; set; }
        public string EmpId { get; set; }
        public string PhNo { get; set; }
        public string PhExt { get; set; }
        public string FaxNo { get; set; }
        public string EmailId { get; set; }
        //scalar
        public string EmpNm { get; set; }
        public string XmlDataDocument_FlipGrid { get; set; }
    }
}
