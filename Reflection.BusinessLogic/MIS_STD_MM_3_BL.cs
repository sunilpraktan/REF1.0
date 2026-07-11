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
using Reflection.EF.Admin;
using Reflection.EF.SCM;
using Reflection.EF.Finance;
using Reflection.EF.MM;
using Reflection.EF.ADM;

namespace Reflection.BusinessLogic
{
    public class MIS_STD_MM_3_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        public MIS_STD_MM_3_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public MIS_STD_MM_3_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string GetData(string strType, string QueryOption, int intValue, string strValue)
        {

            STD_MIS_MC_BE MC = new STD_MIS_MC_BE();
            string RequestOption = strType.Split('!')[0];
            string strReturnData = "";
            try
            {

                if (RequestOption == "LoadInitialData" || RequestOption == "Report" || RequestOption == "UpdateClosing")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("MIS_STD_MM_3", new { @request = strType }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LoadInitialData")
                        {
                            MC.REPORT_LIST = reader.Read<STD_LIST_BE>().ToList();
                            MC.COMPANY_LIST = reader.Read<ADM_M0002>().ToList();
                            MC.LOCATION_LIST = reader.Read<ADM_M0003>().ToList();
                            MC.STORE_LIST = reader.Read<MM_M0001>().ToList();
                            MC.ITEM_CAT_LIST = reader.Read<ADM_M018>().ToList();
                            MC.ITEM_SUBCAT_LIST = reader.Read<ADM_M019>().ToList();
                            MC.ITEM_TYPE_LIST = reader.Read<ADM_M015>().ToList();
                            MC.ITEM_SUBTYPE_LIST = reader.Read<ADM_M016>().ToList();
                            MC.STD_ITEM_LIST = reader.Read<STD_ITEM>().ToList();
                            MC.UOM_LIST = reader.Read<UOMS>().ToList();
                            MC.POSTING_PERIOD_LIST = reader.Read<STD_LIST_BE>().ToList();
                        }
                        else if (RequestOption == "Report" || RequestOption == "UpdateClosing")
                        {
                            MC.STD_MIS_LIST = reader.Read<STD_MIS_BE>().ToList();
                        }
                        //else if (RequestOption == "UpdateClosing")
                        //{
                        //    MC.STD_MIS_LIST = reader.Read<STD_MIS_BE>().ToList();
                        //}
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
