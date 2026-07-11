using Reflection.EF;
using Reflection.EF.Asset_Management;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Reflection.EF.Finance;
using Reflection.EF.Admin;
using Reflection.EF.FICO;

namespace Reflection.BusinessLogic.FICO
{
    public class FICO_M0033_BL : ReflectionBusinessLogic
    {
        FICO_M0033 MasterEntity = new FICO_M0033();
        MC_FICO_BE MC = new MC_FICO_BE();

        public FICO_M0033_BL()
        { }

        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("FICO_M0033_INS", new { @Request = Request }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    MC.CURR_OC_LIST = reader.Read<FICO_M0033>().ToList();

                }
                ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                return ReturnValue;
            }
            catch (SqlException ex)
            {
                throw new CreateException(ex.ErrorCode, ex.Message, ex);
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new CreateException(ex.Message, ex);
            }
        }
        public string GetData(string RequestValue, string strType, int intValue, string strValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("FICO_M0033_GET", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_INI")
                    {

                        MC.CURR_OC_LIST = reader.Read<FICO_M0033>().ToList();
                        ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "LOAD_RECORDS")
                    {

                        MC.CURR_OC_LIST = reader.Read<FICO_M0033>().ToList();
                        ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                    }
                }
                return ReturnValue;
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
