using System;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Reflection.EF.Communication;
using Reflection.EF.Production;
using Reflection.EF.ENG;
using Reflection.EF.ADM;

namespace Reflection.BusinessLogic.PMS
{
    public class ENG_T001_BL : ReflectionBusinessLogic
    {
        ENG_T001 MasterEntity = new ENG_T001();
        MC_ENG_BE MC = new MC_ENG_BE();
        public ENG_T001_BL()
        { }

        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("ENG_T001_INS", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    MC.MasterEntity = reader.Read<ENG_T001>().ToList();
                    MasterEntity = MC.MasterEntity[0];
                    MC.ItemsEntity = reader.Read<ENG_T001_A>().ToList();
                    MasterEntity.XDOC_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                    MC.BOMAssignmentEntity = reader.Read<ENG_T001_C>().ToList();
                    MasterEntity.XDOC_C = ObjectSerializationService.ObjectToXML(MC.BOMAssignmentEntity);
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
                    var reader = conn.QueryMultiple("ENG_T001_UPD", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    MC.MasterEntity = reader.Read<ENG_T001>().ToList();
                    MasterEntity = MC.MasterEntity[0];
                    MC.ItemsEntity = reader.Read<ENG_T001_A>().ToList();
                    MasterEntity.XDOC_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                    MC.BOMAssignmentEntity = reader.Read<ENG_T001_C>().ToList();
                    MasterEntity.XDOC_C = ObjectSerializationService.ObjectToXML(MC.BOMAssignmentEntity);
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
                    int intOut = conn.Execute("ENG_T001_DEL", new { @req_no = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);
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
                    var reader = conn.QueryMultiple("ENG_T001_GET", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_INI")
                    {
                        MC.COMPONANT_LIST = reader.Read<STD_ITEM>().ToList();
                        MC.ITEM_LIST = reader.Read<STD_ITEM>().ToList();
                        MC.UOM_LIST = reader.Read<UOMS>().ToList();
                        MC.BOM_CAT_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.DOC_TYPE_LIST = reader.Read<STD_DOC_TYPE>().ToList();
                        MC.USAGE_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.LINE_CAT_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.COMPANY_LIST = reader.Read<ADM_M0002>().ToList();
                        MC.LOCATION_LIST = reader.Read<ADM_M0003>().ToList();
                    }
                    if (RequestOption == "LOAD_DOC_BY_DOC_NO")
                    {
                        MC.MasterEntity = reader.Read<ENG_T001>().ToList();
                        MC.ItemsEntity = reader.Read<ENG_T001_A>().ToList();
                        MC.BOMAssignmentEntity = reader.Read<ENG_T001_C>().ToList();
                        MC.ATTACHMENT_LIST = reader.Read<COM_T003>().ToList();
                    }
                    else if (RequestOption == "LOAD_BACKFLIP")
                    {
                        MC.BACK_FLIP_LIST = reader.Read<STD_LIST_BE>().ToList();
                    }
                    else if (RequestOption == "BM_Report")
                    {
                        //var RptBillOfMaterialTemp = reader.Read<Rpt_BillOfMaterial>().ToList();
                        //MC.RptBillOfMaterial = RptBillOfMaterialTemp.ToList();

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
