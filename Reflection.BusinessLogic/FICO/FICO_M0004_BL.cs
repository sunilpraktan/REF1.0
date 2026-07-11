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
using Reflection.EF.ADM;

namespace Reflection.BusinessLogic.FICO
{
    public class FICO_M0004_BL : ReflectionBusinessLogic
    {
        FICO_M0004 MasterEntity = new FICO_M0004();
        MC_FICO_M0004 MC = new MC_FICO_M0004();
        public FICO_M0004_BL()
        { }
        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("FICO_M0004_INS", new { @Request = Request }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    MC.MASTER_ENTITY_LIST = reader.Read<FICO_M0004>().ToList();

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
                    var reader = conn.QueryMultiple("FICO_M0004_GET", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);
                    
                    if (RequestOption == "LOAD_INI_BANK")
                    {
                        MC.MASTER_ENTITY_LIST = reader.Read<FICO_M0004>().ToList();
                        MC.COUNTRY_LIST = reader.Read<STD_LIST_BE>().ToList();
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

    public class FICO_M0004_A_BL : ReflectionBusinessLogic
    {
        FICO_M0004 MasterEntity = new FICO_M0004();
        MC_FICO_M0004 MC = new MC_FICO_M0004();
        public FICO_M0004_A_BL()
        { }
        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("FICO_M0004_A_INS", new { @Request = Request }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    MC.MASTER_ENTITY_LIST = reader.Read<FICO_M0004>().ToList();

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
                    var reader = conn.QueryMultiple("FICO_M0004_GET", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_INI_HBANK")
                    {
                        MC.MASTER_ENTITY_LIST = reader.Read<FICO_M0004>().ToList();
                        MC.BANK_LIST = reader.Read<FICO_M0004>().ToList();
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

    public class FICO_M0004_B_BL : ReflectionBusinessLogic
    {
        FICO_M0004 MasterEntity = new FICO_M0004();
        MC_FICO_M0004 MC = new MC_FICO_M0004();
        public FICO_M0004_B_BL()
        { }
        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("FICO_M0004_B_INS", new { @Request = Request }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    MC.MASTER_ENTITY_LIST = reader.Read<FICO_M0004>().ToList();

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
                    var reader = conn.QueryMultiple("FICO_M0004_GET", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_INI_ACC")
                    {
                        MC.MASTER_ENTITY_LIST = reader.Read<FICO_M0004>().ToList();
                        MC.COMPANY_LIST = reader.Read<ADM_M0002>().ToList();
                        MC.BANK_LIST = reader.Read<FICO_M0004>().ToList();
                        MC.CURRENCY_LIST = reader.Read<ADM_M037>().ToList();
                        MC.AC_TYPE_LIST = reader.Read<FICO_M0004>().ToList();
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
