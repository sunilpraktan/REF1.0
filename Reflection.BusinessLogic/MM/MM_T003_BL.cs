using System;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.SCM;
using Dapper;
using Reflection.EF.Production;
using Reflection.EF.ADM;
using Reflection.EF.MM;
using Reflection.EF.Admin;
using Reflection.EF.COM;

namespace Reflection.BusinessLogic.MM
{
    public class MM_T003_BL : ReflectionBusinessLogic
    {
        MC_MM_T003 MC = new MC_MM_T003();
        MM_T003 MasterEntity = new MM_T003();
        public MM_T003_BL()
        { }

        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("MM_T003_GET", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure, commandTimeout: 0);

                    if (RequestOption == "LOAD_INI")
                    {
                        MC.ITEM_LIST = reader.Read<STD_ITEM>().ToList();
                        MC.BOM_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.COMPANY_LIST = reader.Read<ADM_M0002>().ToList();
                        MC.LOCATION_LIST = reader.Read<ADM_M0003>().ToList();
                        MC.STORE_LIST = reader.Read<MM_M0001>().ToList();
                        MC.PRIORITY_LIST = reader.Read<ADM_M0040>().ToList();
                        MC.PERSONNEL_LIST = reader.Read<STD_PERSONNEL>().ToList();
                        MC.DEPARTMENT_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.LINE_CAT_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.UOM_LIST = reader.Read<UOMS>().ToList();
                        MC.WC_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.DOC_TYPE_LIST = reader.Read<STD_DOC_TYPE>().ToList();
                        MC.ORDER_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                        MC.MM_SETTING_LIST = reader.Read<MM_T003_S>().ToList();
                        MC.EQUIPMENT_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.NOTIFICATION_LIST = reader.Read<NotificationData>().ToList();
                    }
                    else if (RequestOption == "LOAD_DOC_BY_DOC_NO")
                    {
                        MC.MASTER_ENTITY_LIST = reader.Read<MM_T003>().ToList();
                        MC.ITEMS_ENTITY_LIST = reader.Read<MM_T003_A>().ToList();
                        MC.WORKFLOW_LIST = reader.Read<COM_T011>().ToList();
                    }
                    else if (RequestOption == "ExecuteReference")
                    {
                        MC.ITEMS_ENTITY_LIST = reader.Read<MM_T003_A>().ToList();
                    }
                    else if (RequestOption == "LOAD_BACKFLIP")
                    {
                        MC.BACK_FLIP_LIST = reader.Read<STD_LIST_BE>().ToList();
                    }
                    else if (RequestOption == "GET_INFO")
                    {
                        MC.STANDARD_LIST = reader.Read<STD_LIST_BE>().ToList();
                    }
                    else if (RequestOption == "GET_BATCH_DATA")
                    {
                        MC.BATCH_LIST = reader.Read<STD_ITEM>().ToList();
                        //MC.STANDARD_LIST = reader.Read<STD_LIST_BE>().ToList();
                    }
                }
                ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                return ReturnValue;
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
                IDbConnection conn = new SqlConnection(ReflectionConnectionString);
                var reader = conn.QueryMultiple("MM_T003_INS", new { @Request = Request }, commandType: CommandType.StoredProcedure, commandTimeout: 0);

                MC.MASTER_ENTITY_LIST = reader.Read<MM_T003>().ToList();
                if (MC.MASTER_ENTITY_LIST.Count > 0)
                {
                    MasterEntity = MC.MASTER_ENTITY_LIST[0];
                }
                MC.ITEMS_ENTITY_LIST = reader.Read<MM_T003_A>().ToList();

                MasterEntity = MC.MASTER_ENTITY_LIST[0];
                MasterEntity.XDOC_A = ObjectSerializationService.ObjectToXML(MC.ITEMS_ENTITY_LIST);

                ReturnValue = ObjectSerializationService.ObjectToXML(MasterEntity);
                return ReturnValue;
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
                    var reader = conn.QueryMultiple("MM_T003_UPD", new { @Request = Request }, commandType: CommandType.StoredProcedure, commandTimeout: 0);

                    MC.MASTER_ENTITY_LIST = reader.Read<MM_T003>().ToList();
                    if (MC.MASTER_ENTITY_LIST.Count > 0)
                    {
                        MasterEntity = MC.MASTER_ENTITY_LIST[0];
                    }
                    MC.ITEMS_ENTITY_LIST = reader.Read<MM_T003_A>().ToList();

                    MasterEntity = MC.MASTER_ENTITY_LIST[0];
                    MasterEntity.XDOC_A = ObjectSerializationService.ObjectToXML(MC.ITEMS_ENTITY_LIST);

                    ReturnValue = ObjectSerializationService.ObjectToXML(MasterEntity);
                    return ReturnValue;
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
        public string Delete(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    int intOut = conn.Execute("MM_T003_DEL", new { @req_no = Request }, commandType: CommandType.StoredProcedure);
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
