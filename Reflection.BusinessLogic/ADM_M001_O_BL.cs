/*using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.Admin;
using Dapper;

/namespace Reflection.BusinessLogic
{
    public class ADM_M001_O_BL : ReflectionBusinessLogic
    {

        string strReturnData = "";
        static int obj = 0;
        private static string connectionString;

        ADM_M001_O_BL aDM_M001_O = new ADM_M001_O_BL();

        public ADM_M001_O_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M001_O_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string GetData()
        {
            MultipleContext MC = new MultipleContext();

            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M001_O_LoadAll", commandType: CommandType.StoredProcedure);

                    var COMP = reader.Read<ADM_M001>().ToList();
                    MC.Companies = COMP.ToList();

                    var CNTRY = reader.Read<ADM_M012_P>().ToList();
                    MC.Countrys = CNTRY.ToList();

                    var STAT = reader.Read<ADM_M013_P>().ToList();
                    MC.States = STAT.ToList();
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
    }
    public string Insert(string Request)
        {
            try
            {
                aDM_M001_O = new ADM_M001_O_BL();
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M001_O_InsertUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var COMP = reader.Read<ADM_M001_O>().ToList();
                    List<ADM_M001_O> Id= Id.ToList();
                    if (Id.Count > 0)
                    {
                        aDM_M001_O = CompaniesList[0];
                    }

                }
                string strReturnData = ObjectSerializationService.ObjectToXML(aDM_M001_O);
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
                aDM_M001 = new ADM_M001();
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M001Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var COMP = reader.Read<ADM_M001>().ToList();
                    List<ADM_M001> CompaniesList = COMP.ToList();
                    if (CompaniesList.Count > 0)
                    {
                        aDM_M001 = CompaniesList[0];
                    }
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(aDM_M001);
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
        public string GetData()
        {
            MultipleContext MC = new MultipleContext();

            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M001LoadAll", commandType: CommandType.StoredProcedure);

                    var COMP = reader.Read<ADM_M001>().ToList();
                    MC.Companies = COMP.ToList();

                    var CNTRY = reader.Read<ADM_M012_P>().ToList();
                    MC.Countrys = CNTRY.ToList();

                    var STAT = reader.Read<ADM_M013_P>().ToList();
                    MC.States = STAT.ToList();
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
    public class MultipleContext
    {
        public ObservableCollection<ADM_M001_O> PurOrg { get; set; }
        public List<ADM_M001_M_P> POCode { get; set; }
        public List<ADM_M003_P> Location { get; set; }
    }
}*/
