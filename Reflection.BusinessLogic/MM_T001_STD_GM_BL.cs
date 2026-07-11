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
using Reflection.EF.Admin;
using Reflection.EF.SDM;
using Reflection.EF.ADM;
using Reflection.EF.MM;

namespace Reflection.BusinessLogic
{
    public class MM_T001_STD_GM_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        MM_T001 MasterEntity = new MM_T001();
        MC_MM_T001_STD MC = new MC_MM_T001_STD();
        public MM_T001_STD_GM_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public MM_T001_STD_GM_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("MM_T001_STD_Insert", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    MC.MASTER_BE_LIST = reader.Read<MM_T001>().ToList();
                    MC.ITEM_BE_LIST = reader.Read<MM_T001_A>().ToList();
                    MC.BATCH_BE_LIST = reader.Read<MM_T001_B>().ToList();
                    MC.ALLOCATION_BE_LIST = reader.Read<MM_T001_C>().ToList();
                    MasterEntity = MC.MASTER_BE_LIST[0];
                    MasterEntity.XmlDataDocument_MM_T001_A = ObjectSerializationService.ObjectToXML(MC.ITEM_BE_LIST);
                    MasterEntity.XmlDataDocument_MM_T001_B = ObjectSerializationService.ObjectToXML(MC.BATCH_BE_LIST);
                    MasterEntity.XmlDataDocument_MM_T001_C = ObjectSerializationService.ObjectToXML(MC.ALLOCATION_BE_LIST);
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
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("MM_T001_STD_Update", new { @Request = Request }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    MC.MASTER_BE_LIST = reader.Read<MM_T001>().ToList();
                    MC.ITEM_BE_LIST = reader.Read<MM_T001_A>().ToList();
                    MC.BATCH_BE_LIST = reader.Read<MM_T001_B>().ToList();
                    MC.ALLOCATION_BE_LIST = reader.Read<MM_T001_C>().ToList();
                    MasterEntity = MC.MASTER_BE_LIST[0];
                    MasterEntity.XmlDataDocument_MM_T001_A = ObjectSerializationService.ObjectToXML(MC.ITEM_BE_LIST);
                    MasterEntity.XmlDataDocument_MM_T001_B = ObjectSerializationService.ObjectToXML(MC.BATCH_BE_LIST);
                    MasterEntity.XmlDataDocument_MM_T001_C = ObjectSerializationService.ObjectToXML(MC.ALLOCATION_BE_LIST);
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
            string RequestOption = RequestValue.Split('!')[0];
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple((RequestOption == "LoadInitialData" ? "MM_T001_GM_STD_LoadAll" : "MM_T001_STD_LoadAll"), new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);


                    if (RequestOption == "LoadInitialData")
                    {
                        MC.DOC_TYPE_LIST = reader.Read<STD_DOC_TYPE>().ToList();
                        MC.REF_DOC_CAT_LIST = reader.Read<STD_DOC_CAT>().ToList();
                        MC.REF_DOC_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.MOV_TYPE_LIST = reader.Read<MM_M004>().ToList();
                        MC.UOM_LIST = reader.Read<UOMS>().ToList();
                        MC.STORE_LIST = reader.Read<MM_M0001>().ToList();
                        MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                        MC.STD_ITEM_LIST = reader.Read<STD_ITEM>().ToList();
                        MC.PARAMETERS_LIST = reader.Read<ADM_M0071>().ToList();
                        MC.PARAMETERS_VALUES_LIST = reader.Read<ADM_M0071>().ToList();
                        //MC.STD_PERSONNEL_LIST = reader.Read<STD_PERSONNEL>().ToList();
                        //MC.TRANSPORT_MODE_LIST = reader.Read<SYS_M026>().ToList();
                        //MC.TRANSPORTER_LIST = reader.Read<ADM_M028_P>().ToList();
                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        MC.MASTER_BE_LIST = reader.Read<MM_T001>().ToList();
                        MC.ITEM_BE_LIST = reader.Read<MM_T001_A>().ToList();
                        MC.BATCH_BE_LIST = reader.Read<MM_T001_B>().ToList();
                        MC.ALLOCATION_BE_LIST = reader.Read<MM_T001_C>().ToList();
                        MC.ATTACHMENT_LIST = reader.Read<COM_T003>().ToList();
                    }
                    else if (RequestOption == "ExecuteReferenceDocument")
                    {
                        MC.MASTER_BE_LIST = reader.Read<MM_T001>().ToList();
                        MC.ITEM_BE_LIST = reader.Read<MM_T001_A>().ToList();
                        MC.BATCH_BE_LIST = reader.Read<MM_T001_B>().ToList();
                    }
                    else if (RequestOption == "Load_BackFlip_Data")
                    {
                        MC.BACK_FLIP_LIST = reader.Read<STD_LIST_BE>().ToList();
                    }
                    else if (RequestOption == "Load_Batch_Data")
                    {
                        MC.BATCH_LIST = reader.Read<STD_ITEM>().ToList();
                    }
                    else if (RequestOption == "RefreshReferenceDocuments")
                    {
                        MC.REF_DOC_LIST = reader.Read<STD_LIST_BE>().ToList();
                    }
                    else if (RequestOption == "LoadHandlingUnits")
                    {
                        MC.STD_ITEM_HU_LIST = reader.Read<STD_ITEM>().ToList();
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
