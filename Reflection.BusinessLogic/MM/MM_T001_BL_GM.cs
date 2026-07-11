using Reflection.EF;
using Reflection.EF.SCM;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Reflection.EF.Communication;
using Reflection.EF.SCM.ReportEntitySCM;
using Reflection.EF.ReflectionSystem;

namespace Reflection.BusinessLogic
{
    public class MM_T001_BL_GM : ReflectionBusinessLogic
    {

        MM_T001 mM_T001 = new MM_T001();
        MC_MM_T001 MC = new MC_MM_T001();

        public MM_T001_BL_GM()
        {
        }
        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("MM_T001_INS", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    var BackFilptemp = reader.Read<MM_T001Flip>().ToList();
                    MC.DocumentDataFlipGrid = BackFilptemp.ToList();

                    var MasterData = reader.Read<MM_T001>().ToList();
                    MC.DocumentMaster = MasterData.ToList();

                    var MIDetails = reader.Read<MM_T001_A>().ToList();
                    MC.GoodsA = MIDetails.ToList();

                    var BatchDetailsTemp = reader.Read<MM_T001_B>().ToList();
                    MC.ItemBatchDetails = BatchDetailsTemp.ToList();

                    mM_T001 = MC.DocumentMaster[0];
                    mM_T001.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                    mM_T001.XmlDataDocument_MM_T001 = ObjectSerializationService.ObjectToXML(MC.GoodsA);
                    mM_T001.XmlDataDocument_MM_T001_B = ObjectSerializationService.ObjectToXML(MC.ItemBatchDetails);

                }
                string strReturnData = ObjectSerializationService.ObjectToXML(mM_T001);
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
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("MM_T001_UPD", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    var BackFilptemp = reader.Read<MM_T001Flip>().ToList();
                    MC.DocumentDataFlipGrid = BackFilptemp.ToList();

                    var MasterData = reader.Read<MM_T001>().ToList();
                    MC.DocumentMaster = MasterData.ToList();

                    var MIDetails = reader.Read<MM_T001_A>().ToList();
                    MC.GoodsA = MIDetails.ToList();

                    var BatchDetailsTemp = reader.Read<MM_T001_B>().ToList();
                    MC.ItemBatchDetails = BatchDetailsTemp.ToList();

                    mM_T001 = MC.DocumentMaster[0];
                    mM_T001.XmlDataDocument_MM_T001 = ObjectSerializationService.ObjectToXML(MC.GoodsA);
                    mM_T001.XmlDataDocument_MM_T001_B = ObjectSerializationService.ObjectToXML(MC.ItemBatchDetails);
                    mM_T001.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(mM_T001);
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
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    int intOut = conn.Execute("MM_T001_DEL", new { @doc_no = Request }, commandType: CommandType.StoredProcedure);
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
            string RequestOption = RequestValue.Split('!')[0];
            string strData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("MM_T001_GET", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var BackFilptemp = reader.Read<MM_T001Flip>().ToList();
                        MC.DocumentDataFlipGrid = BackFilptemp.ToList();

                        var movementTypeList = reader.Read<MM_M004_P>().ToList();
                        MC.MovementTypeList = movementTypeList.ToList();

                        var requster = reader.Read<ADM_M024_P>().ToList();
                        MC.Requster = requster.ToList();

                        var DeptList = reader.Read<ADM_M025_P>().ToList();
                        MC.deptList = DeptList.ToList();

                        var Items = reader.Read<ADM_M022_P>().ToList();
                        MC.items = Items.ToList();

                        var parameterList = reader.Read<ADM_M031_P>().ToList();
                        MC.ParameterList = parameterList.ToList();

                        var paramValueList = reader.Read<ADM_M030_P>().ToList();
                        MC.ParamValueList = paramValueList.ToList();

                        var UnitList = reader.Read<ADM_M038_B_P>().ToList();
                        MC.unitList = UnitList.ToList();

                        var Store = reader.Read<MM_M001_P>().ToList();
                        MC.store = Store.ToList();

                        var BatchList = reader.Read<MM_S003_P>().ToList();
                        MC.batchList = BatchList.ToList();

                        var machineCodeList = reader.Read<ZADM_M013_P>().ToList();
                        MC.MachineCodeList = machineCodeList.ToList();

                        var notificationData = reader.Read<NotificationData>().ToList();
                        MC.NotificationData = notificationData.ToList();

                        var t_statusData = reader.Read<SYS_M025>().ToList();
                        MC.t_statusList = t_statusData.ToList();

                        var RIndentNo = reader.Read<MM_T003_P>().ToList();
                        MC.ReturnIndentNo = RIndentNo.ToList();

                        var CartonsTemp = reader.Read<EPR_T003_A_P>().ToList();
                        MC.CartonsList = CartonsTemp.ToList();

                        var indentOrIndentNoList = reader.Read<MM_T003_P>().ToList();
                        MC.IndentOrIndentNoList = indentOrIndentNoList.ToList();

                        var orderDocNoList = reader.Read<Order_No_P>().ToList();
                        MC.OrderDocNoList = orderDocNoList.ToList();
                        
                        MC.Project = reader.Read<PRO_T001_P>().ToList();

                    }
                    else if (RequestOption == "LoadRecordsofSelectedDate")
                    {
                        var BackFilptemp = reader.Read<MM_T001Flip>().ToList();
                        MC.DocumentDataFlipGrid = BackFilptemp.ToList();
                    }
                    else if (RequestOption == "LoadDocumentWithReferenceDocumentNumber")
                    {
                        var MasterData = reader.Read<MM_T001>().ToList();
                        MC.DocumentMaster = MasterData.ToList();

                        var GoodsA = reader.Read<MM_T001_A>().ToList();
                        MC.GoodsA = GoodsA.ToList();

                        var BatchDetailsTemp = reader.Read<MM_T001_B>().ToList();
                        MC.ItemBatchDetails = BatchDetailsTemp.ToList();

                        var attachment = reader.Read<COM_T003>().ToList();
                        MC.Attachment = attachment.ToList();

                        mM_T001 = MC.DocumentMaster[0];
                        mM_T001.XmlDataDocument_MM_T001 = ObjectSerializationService.ObjectToXML(MC.GoodsA);
                        mM_T001.XmlDataDocument_MM_T001_B = ObjectSerializationService.ObjectToXML(MC.ItemBatchDetails);

                        strData = ObjectSerializationService.ObjectToXML(mM_T001);
                        return strData;
                    }
                    else if (RequestOption == "MaterialIssue")
                    {
                        var MaterialIssueData = reader.Read<MaterialIssue>().ToList();
                        MC.RptMaterialIssue = MaterialIssueData.ToList();

                        var MaterialIssueItemData = reader.Read<MaterialIssueItem>().ToList();
                        MC.RptMaterialIssueItem = MaterialIssueItemData.ToList();

                        var MaterialIssueBatchTemp = reader.Read<MaterialIssueBatch>().ToList();
                        MC.RptMaterialIssueBatch = MaterialIssueBatchTemp.ToList();

                        strData = ObjectSerializationService.ObjectToXML(MC);
                        return strData;
                    }
                    //MR Section Start
                    else if (RequestOption == "LoadReturnIndent")
                    {
                        var Masterdata = reader.Read<MM_T001>().ToList();
                        MC.DocumentMaster = Masterdata.ToList();

                        var DetailData = reader.Read<MM_T001_A>().ToList();
                        MC.GoodsA = DetailData.ToList();
                    }
                    else if (RequestOption == "LoadProductionOrder")
                    {
                        MC.DocumentMaster = reader.Read<MM_T001>().ToList();
                        MC.GoodsA = reader.Read<MM_T001_A>().ToList();
                        MC.ItemBatchDetails = reader.Read<MM_T001_B>().ToList();
                    }
                    else if (RequestOption == "LoadRecordsofSelectedDate")
                    {
                        var BackFilptemp = reader.Read<MM_T001Flip>().ToList();
                        MC.DocumentDataFlipGrid = BackFilptemp.ToList();

                    }
                    else if (RequestOption == "MaterialReceipt")
                    {

                        var MaterialIssueData = reader.Read<MaterialIssue>().ToList();
                        MC.RptMaterialIssue = MaterialIssueData.ToList();


                        var MaterialIssueItemData = reader.Read<MaterialIssueItem>().ToList();
                        MC.RptMaterialIssueItem = MaterialIssueItemData.ToList();


                        var MaterialIssueBatchTemp = reader.Read<MaterialIssueBatch>().ToList();
                        MC.RptMaterialIssueBatch = MaterialIssueBatchTemp.ToList();

                        strData = ObjectSerializationService.ObjectToXML(MC);
                        return strData;
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
