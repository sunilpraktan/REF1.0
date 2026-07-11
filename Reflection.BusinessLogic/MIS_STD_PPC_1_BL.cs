using Reflection.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Reflection.EF.Production.ReportEntityProduction;
using Dapper;
using Reflection.EF.Production;
using Reflection.EF.HRMS.Production;
using Reflection.EF.ReflectionSystem;

namespace Reflection.BusinessLogic
{
    public class MIS_STD_PPC_1_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        public MIS_STD_PPC_1_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public MIS_STD_PPC_1_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string GetData(string strType, string QueryOption, int intValue, string strValue)
        {

            MultipleContext_EPR_T002 MC = new MultipleContext_EPR_T002();
            string RequestOption = strType.Split('!')[0];
            string strReturnData = "";
            try
            {

                if (RequestOption == "LoadInitialData" || RequestOption == "Report")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("MIS_STD_PPC_1", new { @request = strType }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LoadInitialData")
                        {
                            MC.ItemList = reader.Read<ADM_M022_P>().ToList();
                            MC.OperationsList = reader.Read<OperationList>().ToList();
                            MC.WorkCenterList = reader.Read<PPC_M001>().ToList();
                            MC.ShiftList = reader.Read<ADM_M042_P>().ToList();
                            MC.UnitList = reader.Read<ADM_M038_B_P>().ToList();
                            MC.EmployeeList = reader.Read<ADM_M024_P>().ToList();
                            MC.RecordTypeList = reader.Read<SYS_M052>().ToList();
                            MC.VarReasonList = reader.Read<PPC_M003>().ToList();
                        }
                        else if (RequestOption == "Report")
                        {
                            MC.MIS_STD_PPC_1_LIST = reader.Read<MIS_STD_PPC_1>().ToList();
                        }
                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
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
    }
}
