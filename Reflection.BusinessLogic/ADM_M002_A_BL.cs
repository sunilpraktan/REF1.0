using System;
using Dapper;
using Reflection.EF.Admin;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.Finance;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class ADM_M002_A_BL : ReflectionBusinessLogic
    {
        MultipleContext_ADM_M002_A MC = new MultipleContext_ADM_M002_A();

        private static string connectionString;
        ADM_M002_A MasterEntity = new ADM_M002_A();

        public ADM_M002_A_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M002_A_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string GetData(string RequestValue, string strType, int intValue, string srtValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M002_A_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);
                    if (RequestOption == "LoadInitialData")
                    {
                        var _CompList = reader.Read<ADM_M002_A>().ToList();
                        MC.CompList = _CompList.ToList();
                    }
                }
                strReturnData = ObjectSerializationService.ObjectToXML(MC);
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

        public string Insert(string Request)
        {
            string strReturnData = "";

            try
            {
                using (IDbConnection Conn = new SqlConnection(connectionString))
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var Reader = conn.QueryMultiple("ADM_M002_A_Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                        var _CompList = Reader.Read<ADM_M002_A>().ToList();
                        MC.CompList = _CompList.ToList();
                    }

                    strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    return strReturnData;
                }
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
            string strReturnData = "";

            try
            {
                using (IDbConnection Conn = new SqlConnection(connectionString))
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var Reader = conn.QueryMultiple("ADM_M002_A_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                        var _CompList = Reader.Read<ADM_M002_A>().ToList();
                        MC.CompList = _CompList.ToList();
                    }

                    strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    return strReturnData;
                }
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
    }
    public class MultipleContext_ADM_M002_A
    {
        public List<ADM_M002_A> CompList { get; set; }
  
    }
}


