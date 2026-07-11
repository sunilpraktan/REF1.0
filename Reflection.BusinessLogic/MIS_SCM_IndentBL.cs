using Dapper;
using Reflection.EF;
using Reflection.EF.Procurement;
using Reflection.EF.SCM.ReportEntitySCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    public class MIS_SCM_IndentBL : ReflectionBusinessLogic
    {
        private static string connectionString;
        MultipleContext_MIS_SCM_Indent MC = new MultipleContext_MIS_SCM_Indent();

        public MIS_SCM_IndentBL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public MIS_SCM_IndentBL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        private List<MIS_SCM_Indent> _dsReport;
        public List<MIS_SCM_Indent> dsReport
        {
            get { return _dsReport; }
            set
            {
                _dsReport = value;
            }
        }

        public string GetData(string strType, string QueryOption, int intValue, string strValue)
        {
            MultipleContext_MIS_SCM_Indent MC = new MultipleContext_MIS_SCM_Indent();
            string RequestOption = strType.Split('!')[0];
            string strReturnData = "";
            try
            {
                if (RequestOption == "LoadInitialData" || RequestOption == "Report")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("MIS_SCM_Indent", new { @request = strType }, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LoadInitialData")
                        {
                            var EmployeeMaster = reader.Read<ADM_M024_P>().ToList();
                            MC.EmployeeList = EmployeeMaster.ToList();

                            var partyData = reader.Read<ADM_M025_P>().ToList();
                            MC.DepartmentDetails = partyData.ToList();

                            var ItemData = reader.Read<ADM_M022_P>().ToList();
                            MC.ItemDetails = ItemData.ToList();

                            var StatusData = reader.Read<MIS_SCM_Indent>().ToList();
                            MC.StatusDetails = StatusData.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "Report")
                        {
                            var RptMIS_SCMINdent = reader.Read<MIS_SCM_Indent>().ToList();
                            dsReport = RptMIS_SCMINdent.ToList();
                            strReturnData = ObjectSerializationService.ObjectToXML(dsReport);
                        }
                    }
                }
                return strReturnData;
            }
            catch (SqlException ex)
            {
                throw new CreateException(ex.ErrorCode, ex.Message, ex);
            }
            catch (DivideByZeroException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new CreateException(ex.Message, ex);
            }
        }
        public class MultipleContext_MIS_SCM_Indent
        {
            public List<ADM_M024_P> EmployeeList { get; set; }
            public List<ADM_M025_P> DepartmentDetails { get; set; }
            public List<ADM_M022_P> ItemDetails { get; set; }
            public List<MIS_SCM_Indent> StatusDetails { get; set; }

        }
    }
}
