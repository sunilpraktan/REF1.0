using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Project_Management
{
    public class MC_PMS_OLD_BE
    {
        public List<PRO_T001_P> Project { get; set; }
        public List<STD_LIST_BE> Order { get; set; }
        public List<STD_MIS_BE> STD_MIS_BE_OBJ { get; set; }
        public List<STD_MIS_BE> ProjectInfo { get; set; }
        public List<STD_MIS_BE> ProcurementInfo { get; set; }
        public List<STD_MIS_BE> ConsumptionInfo { get; set; }
        public List<STD_MIS_BE> ExpensesInfo { get; set; }
        public List<ADM_M001_H_P> SalesGroup { get; set; }
    }
}
