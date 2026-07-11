using System;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Reflection.EF.ADM;

namespace Reflection.BusinessLogic.ADM
{
    public class ADM_M0126_BL : ReflectionBusinessLogic
    {
        ADM_M0126 MasterEntity = new ADM_M0126();
        MC_ADM_M0126 MC = new MC_ADM_M0126();

        public ADM_M0126_BL()
        {
        }
        public string Insert(string Request, string RequestOption)
        {
            try
            {
                MC = (MC_ADM_M0126)ObjectSerializationService.XMLToObject(Request, MC);
                MasterEntity = MC.VC_LIST[0];
                MasterEntity.XDOC_A = ObjectSerializationService.ObjectToXML(MC.VC_VALUE_LIST);
                Request = ObjectSerializationService.ObjectToXML(MasterEntity);

                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M0126_INS", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    MC.VC_LIST = reader.Read<ADM_M0126>().ToList();
                    MC.VC_VALUE_LIST = reader.Read<ADM_M0127>().ToList();
                    //if (MC.VC_LIST.Count > 0)
                    //{
                    //    MasterEntity = MC.VC_LIST[0];
                    //}
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
        public string Update(string Request, string RequestOption)
        {
            try
            {
                MC = (MC_ADM_M0126)ObjectSerializationService.XMLToObject(Request, MC);
                MasterEntity = MC.VC_LIST[0];
                MasterEntity.XDOC_A = ObjectSerializationService.ObjectToXML(MC.VC_VALUE_LIST);
                Request = ObjectSerializationService.ObjectToXML(MasterEntity);

                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M0126_UPD", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    MC.VC_LIST = reader.Read<ADM_M0126>().ToList();
                    MC.VC_VALUE_LIST = reader.Read<ADM_M0127>().ToList();
                    //if (MC.VC_LIST.Count > 0)
                    //{
                    //    MasterEntity = MC.VC_LIST[0];
                    //}
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
        public string Delete(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    int intOut = 0; //conn.Execute("ADM_M028Delete", new { @PartyId = Request }, commandType: CommandType.StoredProcedure);
                    return intOut.ToString();
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
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            try
            {
                string RequestOption = RequestValue.Split('!')[0];

                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M0126_GET", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_INI")
                    {

                    }
                    else if (RequestOption == "LOAD_DOCUMENT")
                    {
                        MC.VC_LIST = reader.Read<ADM_M0126>().ToList();
                        MC.VC_VALUE_LIST = reader.Read<ADM_M0127>().ToList();
                        MC.CHAR_VALUE_LIST = reader.Read<Classification>().ToList();
                    }
                    else if (RequestOption == "LOAD_VC_INFO")
                    {
                        MC.VC_LIST = reader.Read<ADM_M0126>().ToList();
                        MC.VC_VALUE_LIST = reader.Read<ADM_M0127>().ToList();
                    }
                }
                return ObjectSerializationService.ObjectToXML(MC);
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
