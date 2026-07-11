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
    public class ADM_M002BL : ReflectionBusinessLogic
    {
        
        private static string connectionString;       
        ADM_M002 aDM_M002 = new ADM_M002();
        public ADM_M002BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M002BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                aDM_M002 = (ADM_M002)ObjectSerializationService.XMLToObject(Request, aDM_M002);

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M002Insert", new { @Request = Request, @CompLogo = aDM_M002.CompLogo, @CompLogo2 = aDM_M002.CompLogo2 }, commandType: CommandType.StoredProcedure);

                    var COMP = reader.Read<ADM_M002>().ToList();
                    List<ADM_M002> Companies = COMP.ToList();

                    if (Companies.Count > 0)
                    {
                        aDM_M002 = Companies[0];
                    }
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(aDM_M002);
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
                aDM_M002 = (ADM_M002)ObjectSerializationService.XMLToObject(Request, aDM_M002);

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M002Update", new { @Request = Request, @CompLogo = aDM_M002.CompLogo, @CompLogo2 = aDM_M002.CompLogo2 }, commandType: CommandType.StoredProcedure);

                    var COMP = reader.Read<ADM_M002>().ToList();
                    List<ADM_M002> Companies = COMP.ToList();
                    if (Companies.Count > 0)
                    {
                        aDM_M002 = Companies[0];
                    }
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(aDM_M002);
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
        public string Delete(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("ADM_M002Delete", new { @comp_code = Request }, commandType: CommandType.StoredProcedure);

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
            MultipleContext2 CMC2 = new MultipleContext2();
            try
            {
                string RequestOption = RequestValue.Split('!')[0];
                string strReturnData = "";
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M002LoadAll", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var CompanyMaster1 = reader.Read<ADM_M002>().ToList();
                        CMC2.CompanyMaster = CompanyMaster1.ToList();

                        var Country = reader.Read<ADM_M012_P>().ToList();
                        CMC2.Kntry = Country.ToList();

                        var State = reader.Read<ADM_M013_P>().ToList();
                        CMC2.Shtate = State.ToList();

                        var GrpCode = reader.Read<ADM_M001_PG>().ToList();
                        CMC2.GroupCode = GrpCode.ToList();

                        var EmployeeCode = reader.Read<ADM_M024_P>().ToList();
                        CMC2.Employee = EmployeeCode.ToList();

                        var DesigCode = reader.Read<ADM_M026_P>().ToList();
                        CMC2.Designation = DesigCode.ToList();

                        var CurrCode = reader.Read<ADM_M037_P>().ToList();
                        CMC2.Currency = CurrCode.ToList();

                        var BusinessPlc = reader.Read<ADM_M003_C_P>().ToList();
                        CMC2.BusinessPlace = BusinessPlc.ToList();
                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var CompanyMaster1 = reader.Read<ADM_M002>().ToList();
                        CMC2.CompanyMaster = CompanyMaster1.ToList();
                    }
                }
                    string strData = ObjectSerializationService.ObjectToXML(CMC2);
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
    public class MultipleContext2
    {
        public List<ADM_M002> CompanyMaster { get; set; }
        public List<ADM_M012_P> Kntry { get; set; }
        public List<ADM_M013_P> Shtate { get; set; }
        public List<ADM_M001_PG> GroupCode { get; set; }
        public List<ADM_M024_P> Employee { get; set; }
        public List<ADM_M026_P> Designation { get; set; }
        public List<ADM_M037_P> Currency { get; set; }
        public List<ADM_M003_C_P> BusinessPlace { get; set; }
    }
}
