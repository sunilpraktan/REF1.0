using System;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Reflection.EF.ADM;
using Reflection.EF.PMM;
using Reflection.EF.ENG;

namespace Reflection.BusinessLogic.PMS
{
    public class PMM_T001_BL : ReflectionBusinessLogic
    {
        PMM_T001 MasterEntity = new PMM_T001();
        MC_PMM_T001_BE MC = new MC_PMM_T001_BE();
        public PMM_T001_BL()
        { }

        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("PMM_T001_GET", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_INI")
                    {
                        MC.DOC_TYPE_LIST = reader.Read<STD_DOC_TYPE>().ToList();
                        MC.FUNC_LOCATION_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.WC_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.COMPANY_LIST = reader.Read<ADM_M0002>().ToList();
                        MC.LOCATION_LIST = reader.Read<ADM_M0003>().ToList();
                        MC.ITEM_LIST = reader.Read<STD_ITEM>().ToList();
                        MC.UOM_LIST = reader.Read<UOMS>().ToList();
                        MC.PERSONNEL_LIST = reader.Read<STD_PERSONNEL>().ToList();
                        MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                        MC.ORDER_CAT_LIST = reader.Read<STD_DOC_TYPE>().ToList();
                        MC.PLAN_CAT_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.STRATEGY_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.MASTER_TASK_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.MP_LIST = reader.Read<STD_LIST_BE>().ToList();

                    }
                    else if (RequestOption == "LOAD_DOC_BY_DOC_NO")
                    {
                        MC.MasterEntity = reader.Read<PMM_T001>().ToList();
                        MC.ItemsEntity = reader.Read<PMM_T001_A>().ToList();
                        MC.CycleEntity = reader.Read<PMM_T001_B>().ToList();
                        MC.ScheduleEntity = reader.Read<PMM_T002>().ToList();
                        MC.CallObjectEntity = reader.Read<PMM_T003>().ToList();
                    }
                    else if (RequestOption == "LOAD_BACKFLIP")
                    {
                        MC.BACK_FLIP_LIST = reader.Read<STD_LIST_BE>().ToList();
                    }
                    ReturnValue = ObjectSerializationService.ObjectToXML(MC);

                }
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
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("PMM_T001_INS", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    MC.MasterEntity = reader.Read<PMM_T001>().ToList();
                    if(MC.MasterEntity != null)
                    {
                        if(MC.MasterEntity.Count > 0)
                        {
                            MasterEntity = MC.MasterEntity[0];
                            MC.ItemsEntity = reader.Read<PMM_T001_A>().ToList();
                            MC.CycleEntity = reader.Read<PMM_T001_B>().ToList();
                            MC.ScheduleEntity = reader.Read<PMM_T002>().ToList();
                            MC.CallObjectEntity = reader.Read<PMM_T003>().ToList();

                            MasterEntity.XDOC_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                            MasterEntity.XDOC_B = ObjectSerializationService.ObjectToXML(MC.CycleEntity);
                            MasterEntity.XDOC_C = ObjectSerializationService.ObjectToXML(MC.ScheduleEntity);
                            MasterEntity.XDOC_D = ObjectSerializationService.ObjectToXML(MC.CallObjectEntity);

                        }
                    }
                    
                }
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
                    var reader = conn.QueryMultiple("PMM_T001_UPD", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);
                    MC.MasterEntity = reader.Read<PMM_T001>().ToList();
                    if (MC.MasterEntity != null)
                    {
                        if (MC.MasterEntity.Count > 0)
                        {
                            MasterEntity = MC.MasterEntity[0];
                            MC.ItemsEntity = reader.Read<PMM_T001_A>().ToList();
                            MC.CycleEntity = reader.Read<PMM_T001_B>().ToList();
                            MC.ScheduleEntity = reader.Read<PMM_T002>().ToList();
                            MC.CallObjectEntity = reader.Read<PMM_T003>().ToList();

                            MasterEntity.XDOC_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                            MasterEntity.XDOC_B = ObjectSerializationService.ObjectToXML(MC.CycleEntity);
                            MasterEntity.XDOC_C = ObjectSerializationService.ObjectToXML(MC.ScheduleEntity);
                            MasterEntity.XDOC_D = ObjectSerializationService.ObjectToXML(MC.CallObjectEntity);

                        }
                    }
                }
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
        public string Delete(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    int intOut = conn.Execute("PMM_T001_DEL", new { @req_no = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);
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
