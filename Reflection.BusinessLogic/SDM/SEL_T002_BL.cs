using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using Reflection.EF.CRM;
using System.Data;
using Dapper;
using Reflection.EF.Communication;
using Reflection.EF.Admin;
using Reflection.EF.ReflectionSystem;

namespace Reflection.BusinessLogic.SDM
{
    public class SEL_T002_BL : ReflectionBusinessLogic
    {
        MultipleContext_SEL_T002 MC = new MultipleContext_SEL_T002();

        SEL_T002 MasterEntity = new SEL_T002();
        public SEL_T002_BL()
        { }

        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("SEL_T002_INS", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    List<SEL_T002> Masterlist = reader.Read<SEL_T002>().ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
                    MC.ItemsEntity = reader.Read<SEL_T002_A>().ToList();

                    MasterEntity.XmlDataDocument_SEL_T002_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);


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
                    var reader = conn.QueryMultiple("SEL_T002_UPD", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    List<SEL_T002> Masterlist = reader.Read<SEL_T002>().ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
                    MC.ItemsEntity = reader.Read<SEL_T002_A>().ToList();

                    MasterEntity.XmlDataDocument_SEL_T002_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);

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
                    int intOut = conn.Execute("SEL_T002_DEL", new { @sch_no = Request }, commandType: CommandType.StoredProcedure);
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
        public string GetData(string RequestValue, string strType, int intValue, string strValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("SEL_T002_GET", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        MC.Reference_Docs = reader.Read<SEL_T001_P>().ToList();
                        MC.ScheduleMode = reader.Read<SYS_M036>().ToList();
                        MC.TransportMode = reader.Read<SYS_M026>().ToList();
                        MC.ServiceProviders = reader.Read<ADM_M028_P>().ToList();
                        MC.t_statusList = reader.Read<SYS_M025>().ToList();
                        MC.UOM = reader.Read<ADM_M038_B_P>().ToList();
                        MC.UnitConversion = reader.Read<ADM_M038_C>().ToList();
                        MC.NotificationData = reader.Read<NotificationData>().ToList();
                        //MC.contactInfoMaster = reader.Read<ADM_M028_C_P>().ToList();
                        //MC.DeliveryAddress = reader.Read<ADM_M028_D_Add>().ToList();

                    }
                    else if (RequestOption == "LoadBackFlipData")
                    {
                        MC.BackFlipEntity = reader.Read<SEL_T002_BackFlip>().ToList();
                    }
                    else if (RequestOption == "LOAD_PARTY_INFO")
                    {
                        MC.contactInfoMaster = reader.Read<ADM_M028_C_P>().ToList();
                        MC.DeliveryAddress = reader.Read<ADM_M028_D_Add>().ToList();
                    }
                    else if (RequestOption == "LoadDocumentWithReferenceDocumentNumber")
                    {
                        MC.MasterEntity = reader.Read<SEL_T002>().ToList();
                        MC.ItemsEntity = reader.Read<SEL_T002_A>().ToList();
                        MC.contactInfoMaster = reader.Read<ADM_M028_C_P>().ToList();
                        MC.DeliveryAddress = reader.Read<ADM_M028_D_Add>().ToList();
                        MC.Attachment = reader.Read<COM_T003>().ToList();

                    }
                    else if (RequestOption == "SO_Report")
                    {
                        var MasterData = reader.Read<SEL_T001>().ToList();
                        MC.SalesOrderMaster = MasterData.ToList();
                        //MasterEntity = MC.MasterEntity[0];
                        var ItemsData = reader.Read<SEL_T001_A>().ToList();
                        MC.SalesOrderEntity = ItemsData.ToList();

                        var ScheduleEntity = reader.Read<SEL_T002_A>().ToList();
                        MC.ItemsEntity = ScheduleEntity.ToList();

                        base.ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "Refresh")
                    {
                        var Reference_Docs = reader.Read<SEL_T001_P>().ToList();
                        MC.Reference_Docs = Reference_Docs.ToList();

                        base.ReturnValue = ObjectSerializationService.ObjectToXML(MC);
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
    }
}
