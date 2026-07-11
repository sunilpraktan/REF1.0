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
    public class QMS_M002BL : ReflectionBusinessLogic
    {
       MultipleContext_QMS_M002 MC = new MultipleContext_QMS_M002();


        private static string connectionString;
        QMS_M002 MasterEntity = new QMS_M002();

        public QMS_M002BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public QMS_M002BL()
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
                    var reader = conn.QueryMultiple("QMS_M002_Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<QMS_M002Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<QMS_M002>().ToList();
                    List<QMS_M002> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }                    
                    MasterEntity.XmlDataDocument_QMS_M002FLIP = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);                  
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
                    var reader = conn.QueryMultiple("QMS_M002_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<QMS_M002Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<QMS_M002>().ToList();
                    List<QMS_M002> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    
                    MasterEntity.XmlDataDocument_QMS_M002FLIP = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                   
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
                    int intOut = 0;// conn.Execute("QMS_M002_Delete", new { @doc_no = Request }, commandType: CommandType.StoredProcedure);
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
            MultipleContext_QMS_M002 MC = new MultipleContext_QMS_M002();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M002_LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);
                    {
                        if (RequestOption == "LoadInitialData")
                        {
                            var FlipGridData = reader.Read<QMS_M002Flip>().ToList();
                            MC.DocumentDataFlipGrid = FlipGridData.ToList();

                            var GroupCode = reader.Read<QMS_M001_P>().ToList();
                            MC.GroupCodeList = GroupCode.ToList();

                        }
                        else if (RequestOption == "LoadDocumentByDocumentNumber")
                        {
                            var SubGroupMaster = reader.Read<QMS_M002>().ToList();
                            MC.MasterList = SubGroupMaster.ToList();
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
    public class MultipleContext_QMS_M002
    {
        public List<QMS_M002Flip> DocumentDataFlipGrid { get; set; }//Back Flip data
        public List<QMS_M001_P> GroupCodeList { get; set; }//Group Details
        public List<QMS_M002> MasterList { get; set; }  //Master Entity List            

    }
   
}
