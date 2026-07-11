using Dapper;
using Reflection.EF;
using Reflection.EF.Admin;
using Reflection.EF.QMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    public class QMS_M001BL : ReflectionBusinessLogic
    {
        MultipleContext_QMS_M001 MC = new MultipleContext_QMS_M001();
        private static string connectionString;
        QMS_M001 MasterEntity = new QMS_M001();

        public QMS_M001BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public QMS_M001BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public byte[] Insert(byte[] RequestStream, string Request, string RequestOption)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M001_Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<QMS_M001Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<QMS_M001>().ToList();
                    List<QMS_M001> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
                    MasterEntity.XmlDataDocument_QMS_M001FLIP = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                }
                return ObjectSerializationService<QMS_M001>.ObjectToStream(MasterEntity);
                
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
                    var reader = conn.QueryMultiple("QMS_M001_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<QMS_M001Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<QMS_M001>().ToList();
                    List<QMS_M001> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    MasterEntity.XmlDataDocument_QMS_M001FLIP = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
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
        public string Delete(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = 0;// conn.Execute("QMS_M001_Delete", new { @doc_no = Request }, commandType: CommandType.StoredProcedure);
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
        public byte[] GetData(string RequestValue, string Request)
        {
            string RequestOption = RequestValue.Split('!')[0];

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M001_LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var FlipGridData = reader.Read<QMS_M001Flip>().ToList();
                        MC.DocumentDataFlipGrid = FlipGridData.ToList();
                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var SubGroup = reader.Read<QMS_M001>().ToList();
                        MC.MasterList = SubGroup.ToList();
                    }

                    return ObjectSerializationService<MultipleContext_QMS_M001>.ObjectToStream(MC);
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
    public class MultipleContext_QMS_M001
    {
        public List<QMS_M001Flip> DocumentDataFlipGrid { get; set; }//Back Flip data        
        public List<QMS_M001> MasterList { get; set; }  //Master Entity List            

    }
}
