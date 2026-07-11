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
    class ACC_M002_K_BL : ReflectionBusinessLogic
    {
        MultipleContext_ACC_M002_K MC = new MultipleContext_ACC_M002_K();

        private static string connectionString;
        ACC_M002_K MasterEntity = new ACC_M002_K();

        public ACC_M002_K_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ACC_M002_K_BL()
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
                    var reader = conn.QueryMultiple("ACC_M002_K_Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var _FlipGridData = reader.Read<ACC_M002_K_Flip>().ToList();
                    MC.FlipGridData = _FlipGridData.ToList();

                    var _MasterData = reader.Read<ACC_M002_K>().ToList();
                    List<ACC_M002_K> Masterlist = _MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.FlipGridData);
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
                    var reader = conn.QueryMultiple("ACC_M002_K_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var _FlipGridData = reader.Read<ACC_M002_K_Flip>().ToList();
                    MC.FlipGridData = _FlipGridData.ToList();

                    var _MasterData = reader.Read<ACC_M002_K>().ToList();
                    List<ACC_M002_K> Masterlist = _MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.FlipGridData);
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
            MultipleContext_ACC_M002_K MC = new MultipleContext_ACC_M002_K();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ACC_M002_K_LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);
                    {
                        if (RequestOption == "LoadInitialData")
                        {
                            var _FlipGridData = reader.Read<ACC_M002_K_Flip>().ToList();
                            MC.FlipGridData = _FlipGridData.ToList();

                            var _MaxAmountMethodList = reader.Read<ACC_M023_E_P>().ToList();
                            MC.MaxAmountMethodList  = _MaxAmountMethodList.ToList();

                            var _CutOffValList = reader.Read<ACC_M023_H_P>().ToList();
                            MC.CutOffValList = _CutOffValList.ToList();

                            var _CODList = reader.Read<ACC_M002_J_P>().ToList();
                            MC.CODList = _CODList.ToList();

                        }
                        else if (RequestOption == "LoadDocumentByDocumentNumber")
                        {
                            var _MasterList = reader.Read<ACC_M002_K>().ToList();
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
    public class MultipleContext_ACC_M002_K
    {
        public List<ACC_M002_K_Flip> FlipGridData { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<ACC_M002_K> MasterList { get; set; }
        public List<ACC_M023_E_P> MaxAmountMethodList { get; set; }
        public List<ACC_M023_H_P> CutOffValList { get; set; }
        public List<ACC_M002_J_P> CODList { get; set; }
    }
}
