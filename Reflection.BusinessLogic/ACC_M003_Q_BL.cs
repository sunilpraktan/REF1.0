using Dapper;
using Reflection.EF;
using Reflection.EF.Admin;
using Reflection.EF.Communication;
using Reflection.EF.Finance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Reflection.BusinessLogic
{
    public class ACC_M003_Q_BL : ReflectionBusinessLogic
    {
        MultipleContext_ACC_M003_Q MC = new MultipleContext_ACC_M003_Q();

        private static string connectionString;
        ACC_M003_Q MasterEntity = new ACC_M003_Q();

        public ACC_M003_Q_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ACC_M003_Q_BL()
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
                    var reader = conn.QueryMultiple("ACC_M003_Q_Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var _FlipGridData = reader.Read<ACC_M003_Q>().ToList();
                    MC.FlipGridData = _FlipGridData.ToList();

                    var _MasterData = reader.Read<ACC_M003_Q>().ToList();
                    List<ACC_M003_Q> Masterlist = _MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
                    MasterEntity.XmlDataDocument_ACC_M003_Q_FLIP = ObjectSerializationService.ObjectToXML(MC.FlipGridData);
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
                    var reader = conn.QueryMultiple("ACC_M003_Q_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var _FlipGridData = reader.Read<ACC_M003_Q>().ToList();
                    MC.FlipGridData = _FlipGridData.ToList();

                    var _MasterData = reader.Read<ACC_M003_Q>().ToList();
                    List<ACC_M003_Q> Masterlist = _MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    MasterEntity.XmlDataDocument_ACC_M003_Q_FLIP = ObjectSerializationService.ObjectToXML(MC.FlipGridData);

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
            MultipleContext_ACC_M003_Q MC = new MultipleContext_ACC_M003_Q();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ACC_M003_Q_LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);
                    {
                        if (RequestOption == "LoadInitialData")
                        {
                            var _FlipGridData = reader.Read<ACC_M003_Q>().ToList();
                            MC.FlipGridData = _FlipGridData.ToList();
                        }
                        else if (RequestOption == "LoadDocumentByDocumentNumber")
                        {
                            var _MasterList = reader.Read<ACC_M003_Q>().ToList();
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
    public class MultipleContext_ACC_M003_Q
    {
        public List<ACC_M003_Q> MasterEntity { get; set; }
        public List<ACC_M003_Q> FlipGridData { get; set; }
        public List<COM_T003> Attachment { get; set; }
    }
}
