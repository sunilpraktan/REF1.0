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
using Reflection.EF.PMM;

namespace Reflection.BusinessLogic.PMM
{
    public class PMM_M0001_BL : ReflectionBusinessLogic
    {
        PMM_M0001 MasterEntity = new PMM_M0001();
        MC_PMM_BE MC = new MC_PMM_BE();
        public PMM_M0001_BL()
        { }

        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("PMM_M0001_INS", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    MC.EQUIPMENT_MASTER_LIST = reader.Read<PMM_M0001>().ToList();
                    MC.FLEET_LIST = reader.Read<PMM_M0021>().ToList();
                    if (MC.EQUIPMENT_MASTER_LIST.Count > 0)
                    {
                        MasterEntity = MC.EQUIPMENT_MASTER_LIST[0];
                    }
                    if (MC.FLEET_LIST.Count > 0)
                    {
                        MasterEntity.XDOC_A = ObjectSerializationService.ObjectToXML(MC.FLEET_LIST);
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
                    var reader = conn.QueryMultiple("PMM_M0001_UPD", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    MC.EQUIPMENT_MASTER_LIST = reader.Read<PMM_M0001>().ToList();
                    MC.FLEET_LIST = reader.Read<PMM_M0021>().ToList();
                    if (MC.EQUIPMENT_MASTER_LIST.Count > 0)
                    {
                        MasterEntity = MC.EQUIPMENT_MASTER_LIST[0];
                    }
                    if (MC.FLEET_LIST.Count > 0)
                    {
                        MasterEntity.XDOC_A = ObjectSerializationService.ObjectToXML(MC.FLEET_LIST);
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
                    var reader = conn.QueryMultiple("PMM_M0001_GET", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_INI")
                    {
                        MC.COMPANY_LIST = reader.Read<ADM_M0002>().ToList();
                        MC.LOCATION_LIST = reader.Read<ADM_M0003>().ToList();
                        MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                        MC.UOM_LIST = reader.Read<UOMS>().ToList();
                        MC.CURR_LIST = reader.Read<FICO_M0033>().ToList();
                        MC.CATEGORY_LIST = reader.Read<STD_LIST_BE>().ToList(); // Equioment Category
                        MC.ITEM_LIST = reader.Read<STD_ITEM>().ToList();
                        MC.OBJECT_TYPE_LIST = reader.Read<STD_LIST_BE>().ToList(); // Object Type
                        MC.COUNTRY_LIST = reader.Read<STD_LIST_BE>().ToList();
                        //MC.CHAR_LIST = reader.Read<Classification>().ToList();
                        MC.CHAR_VALUE_LIST = reader.Read<Classification>().ToList();
                        MC.PERSONNEL_LIST = reader.Read<STD_PERSONNEL>().ToList();
                        MC.PARTY_LIST = reader.Read<STD_PARTY>().ToList();
                        MC.GROUP_LIST = reader.Read<STD_LIST_BE>().ToList();

                        ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "LOAD_BACKFLIP")
                    {
                        MC.BACK_FLIP_LIST = reader.Read<STD_LIST_BE>().ToList();
                    }
                    else if (RequestOption == "LOAD_TREE_DATA")
                    {
                        //MC.PROJECT_LIST = reader.Read<PMS_T001>().ToList();
                    }
                    else if (RequestOption == "LOAD_DOC_BY_DOC_NO")
                    {
                        MC.EQUIPMENT_MASTER_LIST = reader.Read<PMM_M0001>().ToList();
                        MC.FLEET_LIST = reader.Read<PMM_M0021>().ToList();
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
