using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.Admin;
using Dapper;
using Reflection.EF.Finance;
using Reflection.EF.Communication;

namespace Reflection.BusinessLogic.ADM
{
    public class ADM_M0001_BL : ReflectionBusinessLogic
    {
        ADM_M001 MasterEntity = new ADM_M001();
        MultipleContext MC = new MultipleContext();

        public ADM_M0001_BL()
        {
        }
        public string Insert(string Request, string RequestOption)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M0001_INS", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    List<ADM_M001> GROUP_COMAPNY_LIST = reader.Read<ADM_M001>().ToList();
                    
                    if (GROUP_COMAPNY_LIST.Count > 0)
                    {
                        MasterEntity = GROUP_COMAPNY_LIST[0];
                    }
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
        public string Update(string Request, string RequestOption)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M0001_UPD", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    List<ADM_M001> GROUP_COMAPNY_LIST = reader.Read<ADM_M001>().ToList();

                    if (GROUP_COMAPNY_LIST.Count > 0)
                    {
                        MasterEntity = GROUP_COMAPNY_LIST[0];
                    }
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
                    var reader = conn.QueryMultiple("ADM_M0001_GET", commandType: CommandType.StoredProcedure);

                    MC.Companies = reader.Read<ADM_M001>().ToList();
                    MC.Countrys = reader.Read<ADM_M012_P>().ToList();
                    MC.States = reader.Read<ADM_M013_P>().ToList();
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
