using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.Admin;
using Dapper;


namespace Reflection.BusinessLogic
{
    class ADM_M057_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        ADM_M057 MasterEntity = new ADM_M057();
        MultipleContext_ADM_M057 MC = new MultipleContext_ADM_M057();
        public ADM_M057_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M057_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            try
            {
                string RequestOption = RequestValue.Split('!')[0];
                string strReturnData = "";

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M057LoadAll", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var _CommunicationList = reader.Read<ADM_M057>().ToList();
                        MC.CommunicationList = _CommunicationList.ToList();

                        var _CommunicationTypeList = reader.Read<ADM_M057_A_P>().ToList();
                        MC.CommunicationTypeList = _CommunicationTypeList.ToList();


                        var _CountryList = reader.Read<ADM_M012_P>().ToList();
                        MC.CountryList = _CountryList.ToList();

                       


                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var _CommunicationList = reader.Read<ADM_M057>().ToList();
                        MC.CommunicationList = _CommunicationList.ToList();


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
            try
            {

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M057Insert", new { @Request = Request }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    var _CommunicationList = reader.Read<ADM_M057>().ToList();
                    MC.CommunicationList = _CommunicationList.ToList();

                    if (MC.CommunicationList.Count > 0)
                    {
                        MasterEntity = MC.CommunicationList[0];
                    }


                }
                string strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
                return strReturnData;
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

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M057_Update", new { @Request = Request, }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    var _CommunicationList = reader.Read<ADM_M057>().ToList();
                    MC.CommunicationList = _CommunicationList.ToList();

                    if (MC.CommunicationList.Count > 0)
                    {
                        MasterEntity = MC.CommunicationList[0];
                    }

                }
                string strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
                return strReturnData;
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
    public class MultipleContext_ADM_M057
    {
        public List<ADM_M057> CommunicationList { get; set; }
        public List<ADM_M057_A_P> CommunicationTypeList { get; set; }
        public List<ADM_M012_P> CountryList { get; set; }
       

    }
}
