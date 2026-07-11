
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Serialization;
using Reflection.EF.Production;
using Reflection.EF.Production.ReportEntityProduction;
using Dapper;
using Reflection.EF.Admin;
using Reflection.EF.HRMS.Production;
using Reflection.EF.ReflectionSystem;

namespace Reflection.BusinessLogic
{
    public class EPR_T002_BL_STD : ReflectionBusinessLogic
    {
        private static string connectionString;
        EPR_T002 MasterEntity = new EPR_T002();

        public EPR_T002_BL_STD(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public EPR_T002_BL_STD()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string Insert(string Request)
        {
            try
            {
                String strReturnData = "";
                List<EPR_T002> MasterEntityList = new List<EPR_T002>();
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var dbreader = conn.QueryMultiple("EPR_T002_STD_Insert", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    MasterEntityList = dbreader.Read<EPR_T002>().ToList();
                    //if (MasterEntityList.Count > 0)
                    //{
                    //    MasterEntity = MasterEntityList[0];
                    //}
                }

                strReturnData = ObjectSerializationService.ObjectToXML(MasterEntityList);
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
        public string Update(string Request)    //Production Entry Flag Update
        {
            try
            {
                int reader;
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    reader = conn.Execute("EPR_T002_STD_Update", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);
                }
                string strReturnData = reader.ToString();
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
        public string GetData(string RequestValue, string strType, int intValue, string strValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            MultipleContext_EPR_T002 MC = new MultipleContext_EPR_T002();
            string strData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T002_STD_LoadAll", new { @request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData_FAST")
                    {
                        MC.ProductionOrderList = reader.Read<EPR_T001>().ToList();
                        //MC.OperationsList = reader.Read<OperationList>().ToList();
                        MC.WorkCenterList = reader.Read<PPC_M001>().ToList();
                        MC.ShiftList = reader.Read<ADM_M042_P>().ToList();
                        MC.UnitList = reader.Read<ADM_M038_B_P>().ToList();
                        MC.EmployeeList = reader.Read<ADM_M024_P>().ToList();
                        MC.SettingsList = reader.Read<EPR_T002_S>().ToList();
                        MC.RecordTypeList = reader.Read<SYS_M052>().ToList();
                        MC.VarReasonList = reader.Read<PPC_M003>().ToList();
                        MC.DOC_TYPE_LIST = reader.Read<STD_DOC_TYPE>().ToList();
                    }
                    if (RequestOption == "LoadInitialData_SINGLE")
                    {
                        MC.ProductionOrderList = reader.Read<EPR_T001>().ToList();
                        //MC.OperationsList = reader.Read<OperationList>().ToList();
                        MC.WorkCenterList = reader.Read<PPC_M001>().ToList();
                        MC.ShiftList = reader.Read<ADM_M042_P>().ToList();
                        MC.UnitList = reader.Read<ADM_M038_B_P>().ToList();
                        MC.EmployeeList = reader.Read<ADM_M024_P>().ToList();
                        MC.SettingsList = reader.Read<EPR_T002_S>().ToList();
                        MC.RecordTypeList = reader.Read<SYS_M052>().ToList();
                        MC.VarReasonList = reader.Read<PPC_M003>().ToList();
                        MC.DOC_TYPE_LIST = reader.Read<STD_DOC_TYPE>().ToList();
                        MC.MIS_STD_PPC_1_LIST = reader.Read<MIS_STD_PPC_1>().ToList();
                        MC.Customer = reader.Read<ADM_M028_P>().ToList();
                    }
                    if (RequestOption == "GetOrderInfo")
                    {
                        MC.ProductionOrderList = reader.Read<EPR_T001>().ToList();
                        MC.OperationsList = reader.Read<OperationList>().ToList();
                    }
                    if (RequestOption == "BarcodeScanning")
                    {
                        MC.OrderExecutionList = reader.Read<EPR_T002>().ToList();
                        MC.OperationsList = reader.Read<OperationList>().ToList();
                        MC.ProductionOrderList = reader.Read<EPR_T001>().ToList();
                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber" || RequestOption == "LoadBackFlipData" || RequestOption == "OrderExecutionByOperation")
                    {
                        MC.OrderExecutionList = reader.Read<EPR_T002>().ToList();
                    }
                }

                strData = ObjectSerializationService.ObjectToXML(MC);
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
    }
}
