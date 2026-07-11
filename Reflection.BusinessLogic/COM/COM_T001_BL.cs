using System;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Reflection.EF.COM;
using Reflection.EF.ADM;
using Reflection.EF.Communication;

namespace Reflection.BusinessLogic.COM
{
    public class COM_T001_BL : ReflectionBusinessLogic
    {
        COM_T001 MasterEntity = new COM_T001();
        MC_COM_T001_BE MC = new MC_COM_T001_BE();
        public COM_T001_BL()
        { }

        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("COM_T001_GET", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_INI")
                    {
                        MC.DOC_TYPE_LIST = reader.Read<STD_DOC_TYPE>().ToList();
                        MC.NOT_TYPE_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.COMPANY_LIST = reader.Read<ADM_M0002>().ToList();
                        MC.LOCATION_LIST = reader.Read<ADM_M0003>().ToList();
                        MC.REF_DOC_LIST = reader.Read<STD_LIST_BE>().ToList(); // PM Order List
                        MC.FUNC_LOCATION_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.ITEM_LIST = reader.Read<STD_ITEM>().ToList();
                        MC.WC_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.UOM_LIST = reader.Read<UOMS>().ToList();
                        MC.PERSONNEL_LIST = reader.Read<STD_PERSONNEL>().ToList();
                        MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                        MC.NOTIFICATION_LIST = reader.Read<NotificationData>().ToList();

                    }
                    else if (RequestOption == "LOAD_DOC_BY_DOC_NO")
                    {
                        MC.MasterEntity = reader.Read<COM_T001>().ToList();
                        MC.ItemsEntity = reader.Read<COM_T001_A>().ToList();
                        MC.TaskEntity = reader.Read<COM_T001_B>().ToList();
                        MC.ActivityEntity = reader.Read<COM_T001_C>().ToList();
                        MC.ATTACHMENT_LIST = reader.Read<COM_T003>().ToList();

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
                    var reader = conn.QueryMultiple("COM_T001_INS", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    MC.MasterEntity = reader.Read<COM_T001>().ToList();
                    if (MC.MasterEntity != null)
                    {
                        if (MC.MasterEntity.Count > 0)
                        {
                            MasterEntity = MC.MasterEntity[0];
                            MC.ItemsEntity = reader.Read<COM_T001_A>().ToList();
                            MC.TaskEntity = reader.Read<COM_T001_B>().ToList();
                            MC.ActivityEntity = reader.Read<COM_T001_C>().ToList();

                            MasterEntity.XDOC_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                            MasterEntity.XDOC_B = ObjectSerializationService.ObjectToXML(MC.TaskEntity);
                            MasterEntity.XDOC_C = ObjectSerializationService.ObjectToXML(MC.ActivityEntity);

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
                    var reader = conn.QueryMultiple("COM_T001_UPD", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    MC.MasterEntity = reader.Read<COM_T001>().ToList();
                    if (MC.MasterEntity != null)
                    {
                        if (MC.MasterEntity.Count > 0)
                        {
                            MasterEntity = MC.MasterEntity[0];
                            MC.ItemsEntity = reader.Read<COM_T001_A>().ToList();
                            MC.TaskEntity = reader.Read<COM_T001_B>().ToList();
                            MC.ActivityEntity = reader.Read<COM_T001_C>().ToList();

                            MasterEntity.XDOC_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                            MasterEntity.XDOC_B = ObjectSerializationService.ObjectToXML(MC.TaskEntity);
                            MasterEntity.XDOC_C = ObjectSerializationService.ObjectToXML(MC.ActivityEntity);

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
                    int intOut = conn.Execute("COM_T001_DEL", new { @req_no = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);
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
