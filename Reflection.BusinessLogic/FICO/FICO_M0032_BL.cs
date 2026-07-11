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
    public class FICO_M0032_BL : ReflectionBusinessLogic
    {
        ACC_T001 MasterEntity = new ACC_T001();
        MC_ACC_M0032 MC = new MC_ACC_M0032();

        public FICO_M0032_BL()
        { }

        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("ACC_M0032_INS", new { @Request = Request }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    MC.MASTER_ENTITY_LIST = reader.Read<ACC_M0032>().ToList();

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
                    var reader = conn.QueryMultiple("ACC_M0032_GET", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_INI")
                    {

                        MC.CURRENCY_LIST = reader.Read<ADM_M037>().ToList();
                        ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "LOAD_RECORDS")
                    {

                        MC.MASTER_ENTITY_LIST = reader.Read<ACC_M0032>().ToList();
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
