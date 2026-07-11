using Dapper;
using Reflection.EF.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Reflection.EF;


namespace Reflection.BusinessLogic
{
    public class ACC_M025_BL : ReflectionBusinessLogic
    {
        MultipleContext_ACC_M025 MC = new MultipleContext_ACC_M025();

        private static string connectionString;
        ACC_M025 MasterEntity = new ACC_M025();

        public ACC_M025_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }

        public ACC_M025_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string GetData(string RequestValue, string strType, int intValue, string strValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ACC_M025_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var _TaxList = reader.Read<ACC_M025>().ToList();
                        MC.TaxList = _TaxList.ToList();

                        var _CountryList = reader.Read<ADM_M012_P>().ToList();
                        MC.CountryList = _CountryList.ToList();

                        var _WithholdingtaxtypeList = reader.Read<ACC_M025_A_P>().ToList();
                        MC.withholdingtaxtypeList = _WithholdingtaxtypeList.ToList();
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
            //ACC_M025 MasterEntity = new ACC_M025();
            //MultipleContext_ACC_M025 MC = new MultipleContext_ACC_M025();
            try
            {
                using (IDbConnection Conn = new SqlConnection(connectionString))
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("ACC_M025_Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                        var _TaxList = reader.Read<ACC_M025>().ToList();
                        MC.TaxList = _TaxList.ToList();
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
            ACC_M025 MasterEntity = new ACC_M025();
            MultipleContext_ACC_M025 MC = new MultipleContext_ACC_M025();
            try
            {
                using (IDbConnection Conn = new SqlConnection(connectionString))
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("ACC_M025_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                        var _TaxList = reader.Read<ACC_M025>().ToList();
                        MC.TaxList = _TaxList.ToList();
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
 public class MultipleContext_ACC_M025
    {
        public List<ACC_M025> TaxList { get; set; }  //Details Entity List 
        public List<ADM_M012_P> CountryList { get; set; }
        public List<ACC_M025_A_P> withholdingtaxtypeList { get; set; }

    }
}
