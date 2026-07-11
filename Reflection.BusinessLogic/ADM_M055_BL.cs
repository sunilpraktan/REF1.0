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
    public class ADM_M055_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        ADM_M055 MasterEntity = new ADM_M055();
        MultipleContext_ADM_M055 MC = new MultipleContext_ADM_M055();
        public ADM_M055_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M055_BL()
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
                    var reader = conn.QueryMultiple("ADM_M055LoadAll", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var _AddressList = reader.Read<ADM_M055>().ToList();
                        MC.AddressList = _AddressList.ToList();

                        var _AddressTypeList = reader.Read<ADM_M055_A_P>().ToList();
                        MC.AddressTypeList = _AddressTypeList.ToList();


                        var _CountryList = reader.Read<ADM_M012_P>().ToList();
                        MC.CountryList = _CountryList.ToList();

                        var _StateList = reader.Read<ADM_M013_P>().ToList();
                        MC.StateList = _StateList.ToList();

                        
                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var _AddressList = reader.Read<ADM_M055>().ToList();
                        MC.AddressList = _AddressList.ToList();
                        
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
                    var reader = conn.QueryMultiple("ADM_M055Insert", new { @Request = Request}, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    var _AddressList = reader.Read<ADM_M055>().ToList();
                    MC.AddressList = _AddressList.ToList();

                    if (MC.AddressList.Count > 0)
                    {
                        MasterEntity = MC.AddressList[0];
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
                    var reader = conn.QueryMultiple("ADM_M055_Update", new { @Request = Request, }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    var _AddressList = reader.Read<ADM_M055>().ToList();
                    MC.AddressList = _AddressList.ToList();
                    if(MC.AddressList.Count>0)
                    {
                        MasterEntity = MC.AddressList[0];
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
    public class MultipleContext_ADM_M055
    {
        public List<ADM_M055> AddressList { get; set; }
        public List<ADM_M055_A_P> AddressTypeList { get; set; }
        public List<ADM_M012_P> CountryList { get; set; }
        public List<ADM_M013_P> StateList { get; set; }
       
    }
}
