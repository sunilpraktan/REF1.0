using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Reflection.EF;
using Reflection.EF.SCM;
using System.Data;
using System.Data.SqlClient;


namespace Reflection.BusinessLogic
{
    public class MM_M001_BL : ReflectionBusinessLogic
    {
        private static String connectionString;
        MultipleContext_MM_M001 MC = new MultipleContext_MM_M001();
        MM_M001 MasterEntity = new MM_M001();
        public MM_M001_BL(String BussinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }

        public MM_M001_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string GetData(string RequestValue, string strType, int intValue, string srtValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var Reader = conn.QueryMultiple("MM_M0001_GET", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);
                    if (RequestOption == "LoadInitialData")
                    {
                        var _StoreLocationList = Reader.Read<MM_M001>().ToList();
                        MC.StorageLocationList = _StoreLocationList.ToList();

                        var _CompanyList = Reader.Read<ADM_M002_P>().ToList();
                        MC.CompanyList = _CompanyList.ToList();

                        var _LocationList = Reader.Read<ADM_M003_P>().ToList();
                        MC.LocationList = _LocationList.ToList();
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
            MM_M001 MasterEntity = new MM_M001();
            MultipleContext_MM_M001 MC = new MultipleContext_MM_M001();

            try
            {
                using (IDbConnection Conn = new SqlConnection(connectionString))
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var Reader = conn.QueryMultiple("MM_M0001_INS", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                        var _StoreLocationList = Reader.Read<MM_M001>().ToList();
                        MC.StorageLocationList = _StoreLocationList.ToList();
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
    public class MultipleContext_MM_M001
    {
        public List<MM_M001> StorageLocationList { get; set; }
        public List<ADM_M002_P> CompanyList { get; set; }
        public List<ADM_M003_P> LocationList { get; set; }
    }
}