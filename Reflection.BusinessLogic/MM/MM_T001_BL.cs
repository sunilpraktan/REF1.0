using Reflection.EF;
using Reflection.EF.SCM;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Reflection.EF.Communication;
using Reflection.EF.ADM;
using Reflection.EF.MM;
using Reflection.EF.PPC;

namespace Reflection.BusinessLogic.MM
{
    public class MM_T001_BL : ReflectionBusinessLogic
    {
        MM_T001 MasterEntity = new MM_T001();
        //MC_MM_T001_BE MC = new MC_MM_T001_BE();
        MC_MM_T001 MC = new MC_MM_T001();
        public MM_T001_BL()
        { }

        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("MM_T001_GET", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_INI_MI" || RequestOption == "LOAD_INI_MR")
                    {
                        MC.STD_ITEM_LIST = reader.Read<STD_ITEM>().ToList();
                        MC.COMPANY_LIST = reader.Read<ADM_M0002>().ToList();
                        MC.LOCATION_LIST = reader.Read<ADM_M0003>().ToList();
                        MC.DOC_CAT_LIST = reader.Read<STD_DOC_CAT>().ToList();
                        MC.DOC_TYPE_LIST = reader.Read<STD_DOC_TYPE>().ToList();
                        MC.REF_DOC_TYPE_LIST = reader.Read<STD_DOC_TYPE>().ToList();
                        MC.MOV_TYPE_LIST = reader.Read<MM_M0004>().ToList();
                        MC.UOM_LIST = reader.Read<UOMS>().ToList();
                        MC.STORE_LIST = reader.Read<MM_M0001>().ToList();
                        MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                        MC.PERSONNEL_LIST = reader.Read<STD_PERSONNEL>().ToList();
                        MC.WC_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.NOTIFICATION_LIST = reader.Read<NotificationData>().ToList();
                        MC.REF_DOC_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.DEPARTMENT_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.EQUIPMENT_LIST = reader.Read<STD_LIST_BE>().ToList();

                    }
                    else if (RequestOption == "LOAD_INI_GM") // Load Initial Data for Goods Movement Transaction.
                    {
                        MC.STD_ITEM_LIST = reader.Read<STD_ITEM>().ToList();
                        MC.DOC_TYPE_LIST = reader.Read<STD_DOC_TYPE>().ToList();
                        MC.REF_DOC_CAT_LIST = reader.Read<STD_DOC_CAT>().ToList();
                        MC.REF_DOC_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.MOV_TYPE_LIST = reader.Read<MM_M0004>().ToList();
                        MC.UOM_LIST = reader.Read<UOMS>().ToList();
                        MC.STORE_LIST = reader.Read<MM_M0001>().ToList();
                        MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                        
                        ////MC.STD_PERSONNEL_LIST = reader.Read<STD_PERSONNEL>().ToList();
                        ////MC.TRANSPORT_MODE_LIST = reader.Read<SYS_M026>().ToList();
                        ////MC.TRANSPORTER_LIST = reader.Read<ADM_M028_P>().ToList();
                    }
                    else if (RequestOption == "LOAD_INI_RMGR") // RM Sales order GRN for third party material for Repair, Maint & Quality services
                    {
                        MC.GRID_COLLECTION = reader.Read<STD_LIST_BE>().ToList();
                        MC.DOCTYPE_LIST = reader.Read<ADM_M0010>().ToList();
                        //MC.BACK_FLIP_LIST = reader.Read<STD_LIST_BE>().ToList(); // Load GRN data if already created for above Sales Order in GRID_COLLECTION LIST
                        //MC.ORDER_LIST = reader.Read<STD_LIST_BE>().ToList(); // Load Service Order data if already created for above Sales Order in GRID_COLLECTION LIST

                    }
                    else if (RequestOption == "LOAD_DOC_BY_DOC_NO")
                    {
                        MC.MASTER_ENTITY_LIST = reader.Read<MM_T001>().ToList();
                        MC.ITEMS_ENTITY_LIST = reader.Read<MM_T001_A>().ToList();
                        MC.BATCH_ENTITY_LIST = reader.Read<MM_T001_B>().ToList();
                        MC.ATTACHMENT_LIST = reader.Read<COM_T003>().ToList();
                    }
                    else if (RequestOption == "EXEC_REF_DOC")
                    {
                        MC.MASTER_ENTITY_LIST = reader.Read<MM_T001>().ToList();
                        MC.ITEMS_ENTITY_LIST = reader.Read<MM_T001_A>().ToList();
                        MC.BATCH_ENTITY_LIST = reader.Read<MM_T001_B>().ToList();
                    }
                    else if (RequestOption == "EXECUTE_GRN")
                    {
                        MC.MASTER_ENTITY_LIST = reader.Read<MM_T001>().ToList();
                        MC.ITEMS_ENTITY_LIST = reader.Read<MM_T001_A>().ToList();
                        MC.BATCH_ENTITY_LIST = reader.Read<MM_T001_B>().ToList();
                    }
                    else if (RequestOption == "LOAD_BACKFLIP")
                    {
                        MC.BACK_FLIP_LIST = reader.Read<STD_LIST_BE>().ToList();
                    }
                    else if (RequestOption == "REFRESH_REF_DOC")
                    {
                        MC.REF_DOC_LIST = reader.Read<STD_LIST_BE>().ToList();
                    }
                    else if (RequestOption == "LOAD_HUS")
                    {
                        MC.STD_ITEM_HU_LIST = reader.Read<STD_ITEM>().ToList();
                    }
                    else if (RequestOption == "Load_Batch_Data")
                    {
                        MC.BATCH_LIST = reader.Read<STD_ITEM>().ToList();
                    }
                    else if (RequestOption == "LOAD_BATCHES")
                    {
                        MC.BatchDetailsList = reader.Read<MM_T001_B>().ToList();
                    }
                    else if (RequestOption == "LOAD_INI_OUTSOURCE") // RM Sales order PO,DN & GRN for Outsource services with Speciman object send to supplier by creating PO, DN, GRN & Incomming Invoice. 
                    {
                        MC.GRID_COLLECTION = reader.Read<STD_LIST_BE>().ToList(); // List Will show all outsource items having supplier selected in SO and Task List to get Speciman for outsource.
                        MC.DOCTYPE_LIST = reader.Read<ADM_M0010>().ToList();
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
        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("MM_T001_INS", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    MC.MASTER_ENTITY_LIST = reader.Read<MM_T001>().ToList();
                    MC.ITEMS_ENTITY_LIST = reader.Read<MM_T001_A>().ToList();
                    MC.BATCH_ENTITY_LIST = reader.Read<MM_T001_B>().ToList();
                    MC.ATTACHMENT_LIST = reader.Read<COM_T003>().ToList();
                    MasterEntity = MC.MASTER_ENTITY_LIST[0];
                    MasterEntity.XmlDataDocument_MM_T001_A = ObjectSerializationService.ObjectToXML(MC.ITEMS_ENTITY_LIST);
                    MasterEntity.XmlDataDocument_MM_T001_B = ObjectSerializationService.ObjectToXML(MC.BATCH_ENTITY_LIST);
                    MasterEntity.XML_DOC_ATTACHMENT = ObjectSerializationService.ObjectToXML(MC.ATTACHMENT_LIST);
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
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("MM_T001_UPD", new { @Request = Request }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    MC.MASTER_ENTITY_LIST = reader.Read<MM_T001>().ToList();
                    MC.ITEMS_ENTITY_LIST = reader.Read<MM_T001_A>().ToList();
                    MC.BATCH_ENTITY_LIST = reader.Read<MM_T001_B>().ToList();
                    MC.ATTACHMENT_LIST = reader.Read<COM_T003>().ToList();
                    MasterEntity = MC.MASTER_ENTITY_LIST[0];
                    MasterEntity.XmlDataDocument_MM_T001_A = ObjectSerializationService.ObjectToXML(MC.ITEMS_ENTITY_LIST);
                    MasterEntity.XmlDataDocument_MM_T001_B = ObjectSerializationService.ObjectToXML(MC.BATCH_ENTITY_LIST);
                    MasterEntity.XML_DOC_ATTACHMENT = ObjectSerializationService.ObjectToXML(MC.ATTACHMENT_LIST);
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

    }
}
