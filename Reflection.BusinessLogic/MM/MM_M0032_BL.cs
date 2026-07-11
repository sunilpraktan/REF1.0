using System;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Reflection.EF.ADM;

namespace Reflection.BusinessLogic.MM
{
    public class MM_M0032_BL : ReflectionBusinessLogic
    {
        STD_BE_A MasterEntity = new STD_BE_A();
        MC_GEN_BE MC = new MC_GEN_BE();
        public MM_M0032_BL()
        { }

        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("MM_M0032_INS_UPD", new { @Request = Request }, commandTimeout: 300, commandType: CommandType.StoredProcedure);
                    //MasterEntity = reader.Read<STD_BE_A>().ToList()[0];
                    MC.ItemsEntity = reader.Read<STD_BE_A>().ToList();
                }
                return ObjectSerializationService.ObjectToXML(MC);
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
        public string Update(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("MM_M0032_INS_UPD", new { @Request = Request }, commandType: CommandType.StoredProcedure);
                    //MasterEntity = reader.Read<STD_BE_A>().ToList()[0];
                    MC.ItemsEntity = reader.Read<STD_BE_A>().ToList();
                }
                return ObjectSerializationService.ObjectToXML(MasterEntity);
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
            string strData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("MM_M0032_GET", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure, commandTimeout: 600);

                    if (RequestOption == "LOAD_INI")
                    {
                        MC.ItemsEntity = reader.Read<STD_BE_A>().ToList();
                        MC.COMPANY_LIST = reader.Read<ADM_M0002>().ToList();
                        MC.COUNTRY_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.GROUP_LIST = reader.Read<STD_LIST_BE>().ToList();
                    }
                    else if (RequestOption == "LOAD_DOCS")
                    {
                        MC.ItemsEntity = reader.Read<STD_BE_A>().ToList();
                    }
                }
                strData = ObjectSerializationService.ObjectToXML(MC);

                return strData;
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
