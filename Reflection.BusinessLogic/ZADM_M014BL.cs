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
    public class ZADM_M014BL : ReflectionBusinessLogic
    {            
        private static string connectionString;
        static int obj = 0;
       
        ZADM_M014 zADM_M014 = new ZADM_M014();

        public ZADM_M014BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ZADM_M014BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        #region Insert
        public string Insert(string Request)
        {
            try
            {
                zADM_M014 = (ZADM_M014)ObjectSerializationService.XMLToObject(Request, zADM_M014);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZADM_M014Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var WritingTest = reader.Read<ZADM_M014>().ToList();
                    List<ZADM_M014> writingTestList = WritingTest.ToList();
                    if (writingTestList.Count > 0)
                    {
                        zADM_M014 = writingTestList[0];
                    }
                    //else
                    //{
                    //    zADM_M014=new ZADM_M014();
                    //}
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(zADM_M014);
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
        #endregion
        #region Get Data
        public string GetData()
        {
            MultipleContext_ZADM_M014 MC = new MultipleContext_ZADM_M014();
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZADM_M014LoadAll", commandType: CommandType.StoredProcedure);

                    var WritingTestMaster = reader.Read<ZADM_M014>().ToList();
                    MC.WritingTestMaster_1 = WritingTestMaster.ToList();

                    var MachineMaster = reader.Read<ZADM_M013_PopUp>().ToList();
                    MC.MachineMaster_1 = MachineMaster.ToList();
                }
                string strData = ObjectSerializationService.ObjectToXML(MC);
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
        #endregion
        #region Update
        public string Update(string Request)
        {
            try
            {
                zADM_M014 = (ZADM_M014)ObjectSerializationService.XMLToObject(Request, zADM_M014);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("ZADM_M014Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);
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
        #endregion
        #region Delete
        public string Delete(int Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("ZADM_M014Delete", new { @writingtest_id = Request }, commandType: CommandType.StoredProcedure);
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
        #endregion
    }
    public class MultipleContext_ZADM_M014
    {
        public List<ZADM_M014> WritingTestMaster_1 { get; set; }   //Machine Master   
        public List<ZADM_M013_PopUp> MachineMaster_1 { get; set; }   //Machine Master   
    }
}
