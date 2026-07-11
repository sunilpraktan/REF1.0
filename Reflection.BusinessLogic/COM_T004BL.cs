using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Reflection.EF.Communication;
using Reflection.EF.Project_Management;

namespace Reflection.BusinessLogic
{
    public class COM_T004BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        COM_T004 ScheduleEntity = new COM_T004();
        MultipleContext_COM_T004 MC = new MultipleContext_COM_T004();
        public COM_T004BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public COM_T004BL()
        {
            connectionString = base.ReflectionConnectionString;
        }        
        public string InsertUpdateSchedule(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("COM_T004InsertUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var schedule = reader.Read<COM_T004>().ToList();
                    MC.ScheduleEntity = schedule.ToList();
                                        
                    //MasterEntity.XmlDataDocument_COM_T004 = ObjectSerializationService.ObjectToXML(MC.ScheduleEntity);
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(MC);
                return strReturnData;

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
            try
            {
                MultipleContext_COM_T004 MC = new MultipleContext_COM_T004();
                string RequestOption = RequestValue.Split('!')[0];
                string strReturnData = "";

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("COM_T004LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {                        
                        var schedule = reader.Read<COM_T004>().ToList();
                        MC.ScheduleEntity = schedule.ToList();
                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                    }
                    strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    return strReturnData;
                }
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
        public class MultipleContext_COM_T004
        {            
            public List<COM_T004> ScheduleEntity { get; set; }
        }
    }
}

