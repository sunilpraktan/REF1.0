using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Dapper;


namespace Reflection.BusinessLogic
{
    public class TSK_T001_ABL : ReflectionBusinessLogic
    {
        private static string connectionString;
        MultipleContext_Task MC = new MultipleContext_Task();
        
        Reflection.EF.Communication.Task TaskData = new Reflection.EF.Communication.Task();
        static int obj = 0;
      
        public TSK_T001_ABL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public TSK_T001_ABL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                string strReturnData = "";
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("TSK_T001_AInsert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<Reflection.EF.Communication.Task>().ToList();
                    MC.taskData = MasterData.ToList();
                    TaskData = MC.taskData[0];
                }
                strReturnData = ObjectSerializationService.ObjectToXML(TaskData);
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
        public string Update(string Request)
        {
            try
            {
                string strReturnData = "";
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("TSK_T001_AUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<Reflection.EF.Communication.Task>().ToList();
                    MC.taskData = MasterData.ToList();
                    TaskData = MC.taskData[0];
                }
                strReturnData = ObjectSerializationService.ObjectToXML(TaskData);
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
        public string GetData(string Request)
        {
            string strReturnData = "";
            try
            {            
               using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("TSK_T001_AGetAll", new { @Request = Request }, commandType: CommandType.StoredProcedure);
        
                    if (Request == "Task_Data")
                    {
                        MC.taskData = reader.Read<Reflection.EF.Communication.Task>().ToList();
                       
                        MC.PartyMaster = reader.Read<ADM_M028_P>().ToList();
                       
                        MC.UserMaster_1 = reader.Read<ADM_M010_PopUp>().ToList();
                       
                        MC.SalesInquiry = reader.Read<SEL_T001_P>().ToList();
                        strReturnData = ObjectSerializationService.ObjectToXML(MC);                       
                        MC.FolderDetails = reader.Read<TSK_T001_B_Folder>().ToList();
                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    }                  
               }
                return strReturnData;
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
        #region Delete
        //public string Delete(int Request)
        //{
        //    try
        //    {
        //        int intOut = dbContext.TSK_T001_ADelete(Request);
        //        return intOut.ToString();
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new CreateException(ex.ErrorCode, ex.Message, ex);
        //    }
        //    catch (CreateException ex)
        //    {
        //        throw new CreateException(ex.Message, ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new CreateException(ex.Message, ex);
        //    }
        //}
        #endregion
        public class MultipleContext_Task
        {
            public List<Reflection.EF.Communication.Task> taskData { get; set; }
            public List<ADM_M028_P> PartyMaster { get; set; }  
            public List<ADM_M010_PopUp> UserMaster_1 { get; set; }  
            public List<SEL_T001_P> SalesInquiry { get; set; }
            public List<TSK_T001_B_Folder> FolderDetails { get; set; }  //Task
            
        }
    }
}
