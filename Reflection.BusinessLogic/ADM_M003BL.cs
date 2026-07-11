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
    public class ADM_M003BL : ReflectionBusinessLogic
    {
       
        private static string connectionString;
        static int obj = 0;
        ADM_M003 aDM_M003 = new ADM_M003();

        public ADM_M003BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M003BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                aDM_M003 = new ADM_M003();
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M003Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var location = reader.Read<ADM_M003>().ToList();
                    List<ADM_M003> location1 = location.ToList();
                    if (location1.Count > 0)
                    {
                        aDM_M003 = location1[0];
                    }
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(aDM_M003);
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
                aDM_M003 = new ADM_M003();
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M003Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var location = reader.Read<ADM_M003>().ToList();
                    List<ADM_M003> location1 = location.ToList();
                    if (location1.Count > 0)
                    {
                        aDM_M003 = location1[0];
                    }
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(aDM_M003);
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
                    int intOut = conn.Execute("ADM_M003Delete", new { @location_id = Request }, commandType: CommandType.StoredProcedure);

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
            MultipleContextADM_M003 LOC = new MultipleContextADM_M003();
            try
            {
                string RequestOption = RequestValue.Split('!')[0];
                string strReturnData = "";
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    //var reader = conn.QueryMultiple("ADM_M003LoadAll", commandType: CommandType.StoredProcedure);
                    var reader = conn.QueryMultiple("ADM_M003LoadAll", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var Location = reader.Read<ADM_M003>().ToList();
                        LOC.Locationes = Location.ToList();

                        var Countries = reader.Read<ADM_M012_P>().ToList();
                        LOC.Countrys = Countries.ToList();

                        var State = reader.Read<ADM_M013_P>().ToList();
                        LOC.States = State.ToList();

                        //var Activity = reader.Read<ADM_M004_P>().ToList();
                        //LOC.Activityes = Activity.ToList();

                        var Company = reader.Read<ADM_M002_P>().ToList();
                        LOC.Companyes = Company.ToList();

                        var BusinessPlc = reader.Read<ADM_M003_C_P>().ToList();
                        LOC.BusinessPlace = BusinessPlc.ToList();
                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var Location = reader.Read<ADM_M003>().ToList();
                        LOC.Locationes = Location.ToList();
                    }
                }
                string strData = ObjectSerializationService.ObjectToXML(LOC);
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

    public class MultipleContextADM_M003
    {
        public List<ADM_M003> Locationes { get; set; }
        public List<ADM_M012_P> Countrys { get; set; }
        public List<ADM_M013_P> States { get; set; }
        public List<ADM_M004_P> Activityes { get; set; }
        public List<ADM_M002_P> Companyes { get; set; }
        public List<ADM_M003_C_P> BusinessPlace { get; set; }
    }
}
