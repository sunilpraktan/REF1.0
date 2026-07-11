using System;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.Production;
using Dapper;
using Reflection.EF.Communication;
using Reflection.EF.ReflectionSystem;
using System.Collections.Generic;
using Reflection.EF.HRMS.Production;

namespace Reflection.BusinessLogic
{
    public class EPR_T001_BL_STD : ReflectionBusinessLogic
    {
        private static string connectionString;
        EPR_T001 MasterEntity = new EPR_T001();
        MultipleContext_EPR_T001 MC = new MultipleContext_EPR_T001();
        public EPR_T001_BL_STD(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public EPR_T001_BL_STD()
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
                    var reader = conn.QueryMultiple("EPR_T001_Insert_STD", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    List<EPR_T001> Masterlist = reader.Read<EPR_T001>().ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
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
                    var reader = conn.QueryMultiple("EPR_T001_Update_STD", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    List<EPR_T001> Masterlist = reader.Read<EPR_T001>().ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
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
            MultipleContext_EPR_T001 MC = new MultipleContext_EPR_T001();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T001_LoadAll_STD", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        MC.REF_DOC_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.DocumentTypes = reader.Read<SYS_M013_P>().ToList();
                        MC.ItemMaster = reader.Read<ADM_M022_P1>().ToList();
                        MC.UOM = reader.Read<ADM_M038_B_P>().ToList();
                        MC.ShiftList = reader.Read<ADM_M042_P>().ToList();
                        MC.EmployeeList = reader.Read<ADM_M024_P>().ToList();
                        MC.StatusList = reader.Read<SYS_M025>().ToList();
                        MC.CostCenterList = reader.Read<ACC_M019_P>().ToList();
                        MC.ProfitCenterList = reader.Read<ACC_M020_P>().ToList();
                        MC.StoreCodeList = reader.Read<MM_M001_P>().ToList();
                        MC.WorkCenter = reader.Read<PPC_M001_P>().ToList();
                        MC.ControlKeyMaster = reader.Read<SYS_M051>().ToList();
                        MC.OperationList = reader.Read<PPC_M002>().ToList();
                    }
                    else if (RequestOption == "LoadData_For_Selected_ItemCode")
                    {
                        MC.RoutingList = reader.Read<QMS_M030_P>().ToList();
                        MC.BOMList = reader.Read<ENG_T001_P>().ToList();
                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        MC.MasterEntity = reader.Read<EPR_T001>().ToList();
                        MC.OperationEntity = reader.Read<EPR_T001_A>().ToList();
                        MC.RoutingList = reader.Read<QMS_M030_P>().ToList();
                        MC.BOMList = reader.Read<ENG_T001_P>().ToList();
                    }
                    else if (RequestOption == "ExecuteReferenceDocuments")
                    {
                        MC.MasterEntity = reader.Read<EPR_T001>().ToList();
                        MC.OperationEntity = reader.Read<EPR_T001_A>().ToList();
                        MC.RoutingList = reader.Read<QMS_M030_P>().ToList();
                        MC.BOMList = reader.Read<ENG_T001_P>().ToList();
                    }
                    else if (RequestOption == "LoadBackFlipData")
                    {
                        MC.BackFlipList = reader.Read<EPR_T001>().ToList();
                    }
                    else if (RequestOption == "LoadProductionOrderChart")
                    {
                        MC.MasterEntity = reader.Read<EPR_T001>().ToList();
                    }
                    else if (RequestOption == "Load_Operations_For_Selected_Routing")
                    {
                        MC.OperationEntity = reader.Read<EPR_T001_A>().ToList();
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
    }
}
