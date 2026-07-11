using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.Admin;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class ZADM_M008BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        MultipleContext_ZADM_M008 MC = new MultipleContext_ZADM_M008();
        static int obj = 0;
        
        ZADM_M008 masterEntity = new ZADM_M008();
        public ZADM_M008BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
         }
        public ZADM_M008BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string Insert(string Request)
        {
            try
            {
                string strReturnData = "";
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZADM_M008Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var flipGridData = reader.Read<ZADM_M008Flip>().ToList();
                    MC.FlipGridData = flipGridData.ToList();

                    var masterData = reader.Read<ZADM_M008>().ToList();
                    MC.MasterEntity = masterData.ToList();

                    masterEntity = MC.MasterEntity[0];
                    masterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.FlipGridData);
                }
                strReturnData = ObjectSerializationService.ObjectToXML(masterEntity);
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
                string strReturnData = "";
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZADM_M008Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var flipGridData = reader.Read<ZADM_M008Flip>().ToList();
                    MC.FlipGridData = flipGridData.ToList();

                    var masterData = reader.Read<ZADM_M008>().ToList();
                    MC.MasterEntity = masterData.ToList();

                    masterEntity = MC.MasterEntity[0];
                    masterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.FlipGridData);
                }
                strReturnData = ObjectSerializationService.ObjectToXML(masterEntity);
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
        public string Delete(int Request)
    {
        try
        {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("ZADM_M008Delete", new { @tot_len_id = Request }, commandType: CommandType.StoredProcedure);
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
            MultipleContext_ZADM_M008 MC = new  MultipleContext_ZADM_M008();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZADM_M008LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var flipGridData = reader.Read<ZADM_M008Flip>().ToList();
                        MC.FlipGridData = flipGridData.ToList();

                    }
                    if (RequestOption == "LoadDocumentByDocumentNumber")
                    {

                        var masterData = reader.Read<ZADM_M008>().ToList();
                        MC.MasterEntity = masterData.ToList();

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


        public class MultipleContext_ZADM_M008
        {
            public List<ZADM_M008> MasterEntity { get; set; }
            public List<ZADM_M008Flip> FlipGridData { get; set; }
        }

    }
}
