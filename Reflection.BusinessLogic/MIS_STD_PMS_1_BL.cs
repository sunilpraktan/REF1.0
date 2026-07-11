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
using Reflection.EF.Project_Management;

namespace Reflection.BusinessLogic
{
    public class MIS_STD_PMS_1_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        public MIS_STD_PMS_1_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public MIS_STD_PMS_1_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string GetData(string strType, string QueryOption, int intValue, string strValue)
        {

            MC_PMS_OLD_BE MC = new MC_PMS_OLD_BE();
            string RequestOption = strType.Split('!')[0];
            string strReturnData = "";
            try
            {

                if (RequestOption == "LoadInitialData" || RequestOption == "Report")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("MIS_STD_PMS_1", new { @request = strType }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LoadInitialData")
                        {
                            MC.Order = reader.Read<STD_LIST_BE>().ToList();
                            MC.Project = reader.Read<PRO_T001_P>().ToList();
                            MC.SalesGroup = reader.Read<ADM_M001_H_P>().ToList();
                        }
                        else if (RequestOption == "Report")
                        {
                            MC.STD_MIS_BE_OBJ = reader.Read<STD_MIS_BE>().ToList();
                            MC.ProjectInfo = reader.Read<STD_MIS_BE>().ToList();
                            MC.ProcurementInfo = reader.Read<STD_MIS_BE>().ToList();
                            MC.ConsumptionInfo = reader.Read<STD_MIS_BE>().ToList();
                            MC.ExpensesInfo = reader.Read<STD_MIS_BE>().ToList();
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
