using Reflection.EF;
using Reflection.EF.Procurement;
using Reflection.EF.SCM;
using Reflection.EF.SCM.ReportEntitySCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Reflection.EF.Communication;
using Reflection.EF.ReflectionSystem;

namespace Reflection.BusinessLogic
{
    public class MM_T001_STD_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        MM_T001 MasterEntity = new MM_T001();
        public MM_T001_STD_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public MM_T001_STD_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    MC_MM_T001 MC = new MC_MM_T001();
                    MasterEntity = new MM_T001();
                    var reader = conn.QueryMultiple("MM_T001_STD_Insert", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);
                    MC.GRNMasterList = reader.Read<MM_T001>().ToList();
                    MC.ItemDetailsList = reader.Read<MM_T001_A>().ToList();
                    MC.BatchDetailsList = reader.Read<MM_T001_B>().ToList();
                    MC.POAllocDetailsList = reader.Read<MM_T001_C>().ToList();
                    MasterEntity = MC.GRNMasterList[0];
                    MasterEntity.XmlDataDocument_MM_T001_A = ObjectSerializationService.ObjectToXML(MC.ItemDetailsList);
                    MasterEntity.XmlDataDocument_MM_T001_B = ObjectSerializationService.ObjectToXML(MC.BatchDetailsList);
                    MasterEntity.XmlDataDocument_MM_T001_C = ObjectSerializationService.ObjectToXML(MC.POAllocDetailsList);
                }
                return ObjectSerializationService.ObjectToXML(MasterEntity);
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
                MasterEntity = new MM_T001();
                MC_MM_T001 MC = new MC_MM_T001();
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("MM_T001_STD_Update", new { @Request = Request }, commandTimeout: 600, commandType: CommandType.StoredProcedure);
                    MC.GRNMasterList = reader.Read<MM_T001>().ToList();
                    MC.ItemDetailsList = reader.Read<MM_T001_A>().ToList();
                    MC.BatchDetailsList = reader.Read<MM_T001_B>().ToList();
                    MC.POAllocDetailsList = reader.Read<MM_T001_C>().ToList();
                    MasterEntity = MC.GRNMasterList[0];
                    MasterEntity.XmlDataDocument_MM_T001_A = ObjectSerializationService.ObjectToXML(MC.ItemDetailsList);
                    MasterEntity.XmlDataDocument_MM_T001_B = ObjectSerializationService.ObjectToXML(MC.BatchDetailsList);
                    MasterEntity.XmlDataDocument_MM_T001_C = ObjectSerializationService.ObjectToXML(MC.POAllocDetailsList);
                }
                return ObjectSerializationService.ObjectToXML(MasterEntity);
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
                    int intOut = conn.Execute("MM_T001_MI_Delete", new { @doc_no = Request }, commandType: CommandType.StoredProcedure);
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
            MC_MM_T001 MC = new MC_MM_T001();
            string RequestOption = RequestValue.Split('!')[0];
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("MM_T001_STD_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        MC.MovementTypeList = reader.Read<MM_M004_P>().ToList();
                        MC.TransportMode = reader.Read<SYS_M026>().ToList();
                        MC.TransporterList = reader.Read<ADM_M028_P>().ToList();
                        MC.UOMList = reader.Read<ADM_M038_B_P>().ToList();
                        MC.StoreCodeList = reader.Read<MM_M001_P>().ToList();
                        MC.t_statusList = reader.Read<SYS_M025>().ToList();
                        MC.NotificationData = reader.Read<NotificationData>().ToList();
                        MC.SourceDocNoList = reader.Read<PUR_T002_A_P>().ToList();
                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        MC.GRNMasterList = reader.Read<MM_T001>().ToList();
                        MC.ItemDetailsList = reader.Read<MM_T001_A>().ToList();
                        MC.BatchDetailsList = reader.Read<MM_T001_B>().ToList();
                        MC.POAllocDetailsList = reader.Read<MM_T001_C>().ToList();
                        MC.Attachment = reader.Read<COM_T003>().ToList();
                    }
                    else if (RequestOption == "ExecuteReferenceDocument")
                    {
                        MC.GRNMasterList = reader.Read<MM_T001>().ToList();
                        MC.ItemDetailsList = reader.Read<MM_T001_A>().ToList();
                        MC.BatchDetailsList = reader.Read<MM_T001_B>().ToList();
                        MC.POAllocDetailsList = reader.Read<MM_T001_C>().ToList();
                    }
                    else if (RequestOption == "Rpt_GRN")
                    {
                        MC.RptGRN = reader.Read<RptGRN>().ToList();
                    }
                    else if (RequestOption == "Opening_Stock")
                    {
                        MC.RptGRN = reader.Read<RptGRN>().ToList();
                    }
                    else if (RequestOption == "Load_BackFlip_Data")
                    {
                        MC.FlipGridList = reader.Read<MM_T001_FLIP>().ToList();
                    }
                    else if (RequestOption == "RefreshData")
                    {
                        MC.SourceDocNoList = reader.Read<PUR_T002_A_P>().ToList();
                    }
                }
                return ObjectSerializationService.ObjectToXML(MC);
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
