using Reflection.EF;
using Reflection.EF.Asset_Management;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Reflection.EF.Communication;

namespace Reflection.BusinessLogic
{
    class ACC_M002_M_BL : ReflectionBusinessLogic
    {
        static int obj = 0;
        private static string ConnectionString;
        public ACC_M002_M_BL(string BusinessEntity)
        {
            ConnectionString = base.ReflectionConnectionString;
        }
        public ACC_M002_M_BL()
        {
            ConnectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {

                return "";
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
                return "";
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
            string strReturnData = "";
            try
            {
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
        public class MultipleContext_ACC_M002_M
        {

        }
    }
}
