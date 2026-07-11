using Dapper;
using Reflection.EF;
using Reflection.EF.Finance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.EF.Asset_Management;
using Reflection.EF.Communication;
namespace Reflection.BusinessLogic
{
   public class ACC_M002_D_BL: ReflectionBusinessLogic
    {
        
        MultipleContext_ACC_M002_D MC = new MultipleContext_ACC_M002_D();

        private static string connectionString;
        ACC_M002_D MasterEntity = new ACC_M002_D();

        public ACC_M002_D_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ACC_M002_D_BL()
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
                    var reader = conn.QueryMultiple("ACC_M002_D_Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var _FlipGridData = reader.Read<ACC_M002_D_Flip>().ToList();
                    MC.FlipGridData = _FlipGridData.ToList();

                    var _MasterData = reader.Read<ACC_M002_D>().ToList();
                    List<ACC_M002_D> Masterlist = _MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
                    MasterEntity.XmlDataDocument_ACC_M002_D_FLIP = ObjectSerializationService.ObjectToXML(MC.FlipGridData);
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
                    var reader = conn.QueryMultiple("ACC_M002_D_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var _FlipGridData = reader.Read<ACC_M002_D_Flip>().ToList();
                    MC.FlipGridData = _FlipGridData.ToList();

                    var _MasterData = reader.Read<ACC_M002_D>().ToList();
                    List<ACC_M002_D> Masterlist = _MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
                    MasterEntity.XmlDataDocument_ACC_M002_D_FLIP = ObjectSerializationService.ObjectToXML(MC.FlipGridData);
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
            MultipleContext_ACC_M002_D MC = new MultipleContext_ACC_M002_D();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ACC_M002_D_LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);
                    {
                        if (RequestOption == "LoadInitialData")
                        {
                            var _FlipGridData = reader.Read<ACC_M002_D_Flip>().ToList();
                            MC.FlipGridData = _FlipGridData.ToList();

                            var _AssetClassList = reader.Read<ACC_M002_C_P>().ToList();
                            MC.AssetClassList = _AssetClassList.ToList();

                            var _DepAreaList = reader.Read<ACC_M002_R_P>().ToList();
                            MC.DepAreaList = _DepAreaList.ToList();

                            var _DepKeyList = reader.Read<ACC_M002_K_P>().ToList();
                            MC.DepKeyList = _DepKeyList.ToList();

                            var _CODList = reader.Read<ACC_M002_J_P>().ToList();
                            MC.CODList = _CODList.ToList();

                        }
                        else if (RequestOption == "LoadDocumentByDocumentNumber")
                        {
                            var _MasterList = reader.Read<ACC_M002_D>().ToList();
                            MC.MasterList = _MasterList.ToList();
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
    public class MultipleContext_ACC_M002_D
    {
        public List<ACC_M002_D_Flip> FlipGridData { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<ACC_M002_D> MasterList { get; set; }
        public List<ACC_M002_C_P> AssetClassList { get; set; }
        public List<ACC_M002_R_P> DepAreaList { get; set; }
        public List<ACC_M002_K_P> DepKeyList { get; set; }
        public List<ACC_M002_J_P> CODList { get; set; }
    }
}
