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
using Reflection.EF.Admin;

namespace Reflection.BusinessLogic.MM
{
    public class MM_T005_BL : ReflectionBusinessLogic
    {
        MM_T005 MasterEntity = new MM_T005();
        MC_MM_T005 MC = new MC_MM_T005();
        public MM_T005_BL()
        { }

        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("MM_T005_GET", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_INI")
                    {
                        MC.STD_ITEM_LIST = reader.Read<STD_ITEM>().ToList();
                        MC.COMPANY_LIST = reader.Read<ADM_M0002>().ToList();
                        MC.LOCATION_LIST = reader.Read<ADM_M0003>().ToList();
                        MC.DOC_TYPE_LIST = reader.Read<STD_DOC_TYPE>().ToList();
                        MC.REF_DOC_TYPE_LIST = reader.Read<STD_DOC_TYPE>().ToList();
                        MC.MOV_TYPE_LIST = reader.Read<MM_M0004>().ToList();
                        MC.UOM_LIST = reader.Read<UOMS>().ToList();
                        MC.STORE_LIST = reader.Read<MM_M0001>().ToList();
                        MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                        MC.CURRENCY_LIST = reader.Read<ADM_M037>().ToList();
                        MC.REF_DOC_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.NOTIFICATION_LIST = reader.Read<NotificationData>().ToList();

                    }
                    else if (RequestOption == "LOAD_DOC_BY_DOC_NO")
                    {
                        MC.MASTER_ENTITY_LIST = reader.Read<MM_T005>().ToList();
                        MC.ITEMS_ENTITY_LIST = reader.Read<MM_T005_A>().ToList();
                        MC.BATCH_ENTITY_LIST = reader.Read<MM_T005_B>().ToList();
                    }
                    else if (RequestOption == "EXEC_REF_DOC")
                    {
                        MC.MASTER_ENTITY_LIST = reader.Read<MM_T005>().ToList();
                        MC.ITEMS_ENTITY_LIST = reader.Read<MM_T005_A>().ToList();
                        MC.BATCH_ENTITY_LIST = reader.Read<MM_T005_B>().ToList();
                    }
                    else if (RequestOption == "LOAD_BACKFLIP")
                    {
                        MC.BACK_FLIP_LIST = reader.Read<STD_LIST_BE>().ToList();
                    }
                    else if (RequestOption == "REFRESH_REF_DOC")
                    {
                        MC.REF_DOC_LIST = reader.Read<STD_LIST_BE>().ToList();
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
                    var reader = conn.QueryMultiple("MM_T005_INS", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    MC.MASTER_ENTITY_LIST = reader.Read<MM_T005>().ToList();
                    MC.ITEMS_ENTITY_LIST = reader.Read<MM_T005_A>().ToList();
                    MC.BATCH_ENTITY_LIST = reader.Read<MM_T005_B>().ToList();
                    MasterEntity = MC.MASTER_ENTITY_LIST[0];
                    MasterEntity.XDOC_A = ObjectSerializationService.ObjectToXML(MC.ITEMS_ENTITY_LIST);
                    MasterEntity.XDOC_B = ObjectSerializationService.ObjectToXML(MC.BATCH_ENTITY_LIST);
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
                    var reader = conn.QueryMultiple("MM_T005_UPD", new { @Request = Request }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    MC.MASTER_ENTITY_LIST = reader.Read<MM_T005>().ToList();
                    MC.ITEMS_ENTITY_LIST = reader.Read<MM_T005_A>().ToList();
                    MC.BATCH_ENTITY_LIST = reader.Read<MM_T005_B>().ToList();
                    MasterEntity = MC.MASTER_ENTITY_LIST[0];
                    MasterEntity.XDOC_A = ObjectSerializationService.ObjectToXML(MC.ITEMS_ENTITY_LIST);
                    MasterEntity.XDOC_B = ObjectSerializationService.ObjectToXML(MC.BATCH_ENTITY_LIST);
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
                    int intOut = conn.Execute("MM_T005_DEL", new { @doc_no = Request }, commandType: CommandType.StoredProcedure);
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
