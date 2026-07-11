using Dapper;
using Reflection.EF;
using Reflection.EF.Admin;
using Reflection.EF.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.Production;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class PMT_M001BL : ReflectionBusinessLogic
    {
        MultipleContext_PMT_M001 MC = new MultipleContext_PMT_M001();

        private static string connectionString;
        PMT_M001 MasterEntity = new PMT_M001();

        public PMT_M001BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public PMT_M001BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string Insert(string Request)
        {
            String strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("PMT_M001_Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var _FlipGridData = reader.Read<PMT_M001>().ToList();
                    MC.FlipGridData = _FlipGridData.ToList();

                    var _MasterData = reader.Read<PMT_M001>().ToList();
                    List<PMT_M001> Masterlist = _MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
                    MasterEntity.XmlDataDocument_PMT_M001_FLIP = ObjectSerializationService.ObjectToXML(MC.FlipGridData);
                }

                strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
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
            String strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("PMT_M001_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var _FlipGridData = reader.Read<PMT_M001>().ToList();
                    MC.FlipGridData = _FlipGridData.ToList();

                    var _MasterData = reader.Read<PMT_M001>().ToList();
                    List<PMT_M001> Masterlist = _MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    MasterEntity.XmlDataDocument_PMT_M001_FLIP = ObjectSerializationService.ObjectToXML(MC.FlipGridData);

                }

                strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
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
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            MultipleContext_PMT_M001 MC = new MultipleContext_PMT_M001();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("PMT_M001_LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);
                    {
                        if (RequestOption == "LoadInitialData")
                        {
                            var _FlipGridData = reader.Read<PMT_M001>().ToList();
                            MC.FlipGridData = _FlipGridData.ToList();
                        }
                        else if (RequestOption == "LoadDocumentByDocumentNumber")
                        {
                            var _MasterList = reader.Read<PMT_M001>().ToList();
                            MC.MasterEntity = _MasterList.ToList();
                        }
                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        return strReturnData;
                    }
                }
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
    public class MultipleContext_PMT_M001
    {
        public List<PMT_M001> MasterEntity { get; set; }
        public List<PMT_M001> FlipGridData { get; set; }
    }
}
