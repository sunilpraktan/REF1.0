using System;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Reflection.EF.PMS;
using Reflection.EF.ADM;
using Reflection.EF.Admin;
using Reflection.EF.Production;
using Reflection.EF.FICO;
using Reflection.EF.Communication;

namespace Reflection.BusinessLogic.PMS
{
    public class PMS_T002_BL : ReflectionBusinessLogic
    {
        PMS_T002 MasterEntity = new PMS_T002();
        MC_PMS_BE MC = new MC_PMS_BE();
        public PMS_T002_BL()
        { }

        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("PMS_T002_INS", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    MC.ELEMENT_LIST = reader.Read<PMS_T002>().ToList();
                    MC.SCHEDULE_LIST = reader.Read<PMS_T006>().ToList();
                    if (MC.ELEMENT_LIST.Count > 0)
                    {
                        MasterEntity = MC.ELEMENT_LIST[0];
                    }
                    MasterEntity.XDOC_A = ObjectSerializationService.ObjectToXML(MC.SCHEDULE_LIST);
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
                    var reader = conn.QueryMultiple("PMS_T002_UPD", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    MC.ELEMENT_LIST = reader.Read<PMS_T002>().ToList();
                    MC.SCHEDULE_LIST = reader.Read<PMS_T006>().ToList();
                    if (MC.ELEMENT_LIST.Count > 0)
                    {
                        MasterEntity = MC.ELEMENT_LIST[0];
                    }
                    MasterEntity.XDOC_A = ObjectSerializationService.ObjectToXML(MC.SCHEDULE_LIST);
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
                    int intOut = conn.Execute("PUR_T001_ADelete", new { @req_no = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);
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
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("PMS_T002_GET", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_INI")
                    {
                        MC.DOC_TYPE_LIST = reader.Read<STD_DOC_TYPE>().ToList();
                        MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                        MC.LOCATION_LIST = reader.Read<ADM_M0003>().ToList();
                        MC.UOM_LIST = reader.Read<UOMS>().ToList();
                        MC.PERSONNEL_LIST = reader.Read<STD_PERSONNEL>().ToList();
                        MC.COST_CENTER_LIST = reader.Read<FICO_M0019>().ToList();
                        MC.PROFIT_CENTER_LIST = reader.Read<FICO_M0020>().ToList();
                        MC.PROJECT_LIST = reader.Read<PMS_T001>().ToList();
                        //MC.PHASE_LIST = reader.Read<STD_LIST_BE>().ToList();

                        ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "LOAD_DOC_BY_DOC_NO")
                    {
                        MC.ELEMENT_LIST = reader.Read<PMS_T002>().ToList();
                        MC.SCHEDULE_LIST = reader.Read<PMS_T006>().ToList();
                        MC.ATTACHMENT_LIST = reader.Read<COM_T003>().ToList();
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
    }
}
