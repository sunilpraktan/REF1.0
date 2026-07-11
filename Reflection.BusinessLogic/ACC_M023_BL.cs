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
    class ACC_M023_BL : ReflectionBusinessLogic
    {
        MultipleContext_ACC_M023 MC = new MultipleContext_ACC_M023();

        private static string connectionString;
        ACC_M023 MasterEntity = new ACC_M023();

        public ACC_M023_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ACC_M023_BL()
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
                    var reader = conn.QueryMultiple("ACC_M023_Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var _FlipGridData = reader.Read<ACC_M023_Flip>().ToList();
                    MC.FlipGridData = _FlipGridData.ToList();

                    var _MasterData = reader.Read<ACC_M023>().ToList();
                    List<ACC_M023> Masterlist = _MasterData.ToList();
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
                    var reader = conn.QueryMultiple("ACC_M023_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var _FlipGridData = reader.Read<ACC_M023_Flip>().ToList();
                    MC.FlipGridData = _FlipGridData.ToList();

                    var _MasterData = reader.Read<ACC_M023>().ToList();
                    List<ACC_M023> Masterlist = _MasterData.ToList();
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
            MultipleContext_ACC_M023 MC = new MultipleContext_ACC_M023();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ACC_M023_LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);
                    {
                        if (RequestOption == "LoadInitialData")
                        {
                            var _FlipGridData = reader.Read<ACC_M023_Flip>().ToList();
                            MC.FlipGridData = _FlipGridData.ToList();

                            var _BaseMethodList = reader.Read<ACC_M023_A_P>().ToList();
                            MC.BaseMethodList = _BaseMethodList.ToList();

                            var _DecliningBalList = reader.Read<ACC_M023_B_P>().ToList();
                            MC.DecliningBalList = _DecliningBalList.ToList();

                            var _PeriodControlList = reader.Read<ACC_M023_C_P>().ToList();
                            MC.PeriodControlList = _PeriodControlList.ToList();

                            var _MultilevelList = reader.Read<ACC_M023_D_P>().ToList();
                            MC.MultilevelList = _MultilevelList.ToList();

                            var _CODList = reader.Read<ACC_M002_J_P>().ToList();
                            MC.CODList = _CODList.ToList();

                            var _DepKeyList = reader.Read<ACC_M002_K_P>().ToList();
                            MC.DepKeyList = _DepKeyList.ToList();
                        }
                        else if (RequestOption == "LoadDocumentByDocumentNumber")
                        {
                            var _MasterList = reader.Read<ACC_M023>().ToList();
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
    public class MultipleContext_ACC_M023
    {
        public List<ACC_M023_Flip> FlipGridData { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<ACC_M023> MasterList { get; set; }
        public List<ACC_M023_A_P> BaseMethodList { get; set; }
        public List<ACC_M023_B_P> DecliningBalList { get; set; }
        public List<ACC_M023_C_P> PeriodControlList { get; set; }
        public List<ACC_M023_D_P> MultilevelList { get; set; }
        public List<ACC_M002_J_P> CODList { get; set; }
        public List<ACC_M002_K_P> DepKeyList { get; set; }
    }
}
