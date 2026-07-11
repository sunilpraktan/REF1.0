using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.Admin;
using Dapper;

namespace Reflection.BusinessLogic.ADM
{
    public class ADM_M0002_BL : ReflectionBusinessLogic
    {
        ADM_M002 MasterEntity = new ADM_M002();
        MultipleContext2 MC = new MultipleContext2();

        public ADM_M0002_BL()
        {
        }
        public string Insert(string Request, string RequestOption)
        {
            try
            {
                MasterEntity = (ADM_M002)ObjectSerializationService.XMLToObject(Request, MasterEntity);
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M0002_INS", new { @Request = Request, @CompLogo = MasterEntity.CompLogo, @CompLogo2 = MasterEntity.CompLogo2 }, commandType: CommandType.StoredProcedure);

                    List<ADM_M002> COMPANY_LIST = reader.Read<ADM_M002>().ToList();

                    if (COMPANY_LIST.Count > 0)
                    {
                        MasterEntity = COMPANY_LIST[0];
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
                MasterEntity = (ADM_M002)ObjectSerializationService.XMLToObject(Request, MasterEntity);
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M0002_UPD", new { @Request = Request, @CompLogo = MasterEntity.CompLogo, @CompLogo2 = MasterEntity.CompLogo2 }, commandType: CommandType.StoredProcedure);

                    List<ADM_M002> COMPANY_LIST = reader.Read<ADM_M002>().ToList();

                    if (COMPANY_LIST.Count > 0)
                    {
                        MasterEntity = COMPANY_LIST[0];
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
                    var reader = conn.QueryMultiple("ADM_M0002_GET", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        MC.CompanyMaster = reader.Read<ADM_M002>().ToList();
                        MC.Kntry = reader.Read<ADM_M012_P>().ToList();
                        MC.Shtate = reader.Read<ADM_M013_P>().ToList();
                        MC.GroupCode = reader.Read<ADM_M001_PG>().ToList();
                        MC.Employee = reader.Read<ADM_M024_P>().ToList();
                        MC.Designation = reader.Read<ADM_M026_P>().ToList();
                        MC.Currency = reader.Read<ADM_M037_P>().ToList();
                        MC.BusinessPlace = reader.Read<ADM_M003_C_P>().ToList();
                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        MC.CompanyMaster = reader.Read<ADM_M002>().ToList();
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
