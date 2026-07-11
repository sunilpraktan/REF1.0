using System;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Reflection.EF.ADM;
using Reflection.EF.Communication;
using Reflection.EF.ENG;

namespace Reflection.BusinessLogic.PMS
{
    public class ENG_T005_BL : ReflectionBusinessLogic
    {
        ENG_T005 MasterEntity = new ENG_T005();
        MC_ENG_BE MC = new MC_ENG_BE();
        public ENG_T005_BL()
        { }

        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("ENG_T005_INS", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    MC.MasterEntityTask = reader.Read<ENG_T005>().ToList();
                    MC.OperationEntity = reader.Read<ENG_T005_A>().ToList();
                    MC.CharEntity = reader.Read<ENG_T005_B>().ToList();
                    MC.SelectedSetEntity = reader.Read<ENG_T005_C>().ToList();
                    MC.ComponantEntity = reader.Read<ENG_T005_R>().ToList();
                    MC.AssignmentEntity = reader.Read<ENG_T005_M>().ToList();
                    MasterEntity = MC.MasterEntityTask[0];
                    MasterEntity.XDOC_A = ObjectSerializationService.ObjectToXML(MC.OperationEntity);
                    MasterEntity.XDOC_B = ObjectSerializationService.ObjectToXML(MC.CharEntity);
                    MasterEntity.XDOC_C = ObjectSerializationService.ObjectToXML(MC.SelectedSetEntity);
                    MasterEntity.XDOC_R = ObjectSerializationService.ObjectToXML(MC.ComponantEntity);
                    MasterEntity.XDOC_M = ObjectSerializationService.ObjectToXML(MC.AssignmentEntity);
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
                    var reader = conn.QueryMultiple("ENG_T005_UPD", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    MC.MasterEntityTask = reader.Read<ENG_T005>().ToList();
                    MC.OperationEntity = reader.Read<ENG_T005_A>().ToList();
                    MC.CharEntity = reader.Read<ENG_T005_B>().ToList();
                    MC.SelectedSetEntity = reader.Read<ENG_T005_C>().ToList();
                    MC.ComponantEntity = reader.Read<ENG_T005_R>().ToList();
                    MC.AssignmentEntity = reader.Read<ENG_T005_M>().ToList();
                    MasterEntity = MC.MasterEntityTask[0];
                    MasterEntity.XDOC_A = ObjectSerializationService.ObjectToXML(MC.OperationEntity);
                    MasterEntity.XDOC_B = ObjectSerializationService.ObjectToXML(MC.CharEntity);
                    MasterEntity.XDOC_C = ObjectSerializationService.ObjectToXML(MC.SelectedSetEntity);
                    MasterEntity.XDOC_R = ObjectSerializationService.ObjectToXML(MC.ComponantEntity);
                    MasterEntity.XDOC_M = ObjectSerializationService.ObjectToXML(MC.AssignmentEntity);
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
                    int intOut = conn.Execute("ENG_T005_DEL", new { @req_no = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);
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
                    var reader = conn.QueryMultiple("ENG_T005_GET", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_INI")
                    {
                        MC.COMPONANT_LIST = reader.Read<STD_ITEM>().ToList();
                        MC.STD_ITEM_LIST = reader.Read<STD_ITEM>().ToList();
                        MC.COMPANY_LIST = reader.Read<ADM_M0002>().ToList();
                        MC.LOCATION_LIST = reader.Read<ADM_M0003>().ToList();
                        MC.DOC_TYPE_LIST = reader.Read<STD_DOC_TYPE>().ToList();
                        MC.METHOD_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.PROCEDURE_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.UOM_LIST = reader.Read<UOMS>().ToList();
                        MC.QUALIFICATION_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.WC_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.BOM_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.VCHAR_LIST = reader.Read<ENG_T005_B>().ToList();
                        MC.KEY_DATA_LIST = reader.Read<STD_LIST_BE>().ToList(); // Control Key List
                        MC.USAGE_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.PARA_TYPE_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.CLASS_GROUP_LIST = reader.Read<Classification>().ToList();
                        //MC.PERSONNEL_LIST = reader.Read<STD_PERSONNEL>().ToList();
                        MC.OPERATION_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                        MC.DEPT_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.CHAR_GROUP_LIST = reader.Read<STD_LIST_BE>().ToList();

                    }
                    else if (RequestOption == "LOAD_DOC_BY_DOC_NO")
                    {
                        MC.MasterEntityTask = reader.Read<ENG_T005>().ToList();
                        MC.OperationEntity = reader.Read<ENG_T005_A>().ToList();
                        MC.CharEntity = reader.Read<ENG_T005_B>().ToList();
                        MC.SelectedSetEntity = reader.Read<ENG_T005_C>().ToList();
                        MC.ComponantEntity = reader.Read<ENG_T005_R>().ToList();
                        MC.AssignmentEntity = reader.Read<ENG_T005_M>().ToList();
                        MC.ATTACHMENT_LIST = reader.Read<COM_T003>().ToList();
                        MC.VC_LIST = reader.Read<ADM_M0126>().ToList();
                        MC.VC_VALUE_LIST = reader.Read<ADM_M0127>().ToList();
                        MC.CHAR_VALUE_LIST = reader.Read<Classification>().ToList();
                       
                    }
                    else if (RequestOption == "LOAD_BACKFLIP")
                    {
                        MC.BACK_FLIP_LIST = reader.Read<STD_LIST_BE>().ToList();
                    }
                    else if (RequestOption == "LOAD_BOM_DATA")
                    {
                        MC.COMPONANT_LIST = reader.Read<STD_ITEM>().ToList();
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
