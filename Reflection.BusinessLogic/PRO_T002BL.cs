using Reflection.EF;
using Reflection.EF.Project_Management;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using Dapper;
using Reflection.EF.Communication;

namespace Reflection.BusinessLogic
{
    public class PRO_T002BL : ReflectionBusinessLogic
    {
      
        private static string ConnectionString;
        PRO_T002 MasterEntity= new PRO_T002();
        MultipleContext_PRO_T002 MC = new MultipleContext_PRO_T002 ();
        public PRO_T002BL(string BusinessEntity)
        {
            ConnectionString = base.ReflectionConnectionString;
        }
        public PRO_T002BL()
        {
            ConnectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {

            string strReturnData = "";
            PRO_T002 MasterEntity = new PRO_T002();
            MultipleContext_PRO_T002 MC = new MultipleContext_PRO_T002();
            try
            {
                using (IDbConnection conn = new SqlConnection(ConnectionString))
                {
                    var reader = conn.QueryMultiple("PRO_T002Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<PRO_T002>().ToList();
                    List<PRO_T002> Masterlist = MasterData.ToList();

                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    var WorkSumTemp = reader.Read<PRO_T002_A>().ToList();
                    MC.WorkSummaryList = WorkSumTemp.ToList();

                    var TaskViewTemp = reader.Read<PRO_T002_View>().ToList();
                    MC.TaskViewList = TaskViewTemp.ToList();

                    MasterEntity.XmlDataDocument_PRO_T002_A = ObjectSerializationService.ObjectToXML(MC.WorkSummaryList);
                    MasterEntity.XmlDataDocument_View = ObjectSerializationService.ObjectToXML(MC.TaskViewList);

                }
                strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
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
            string strReturnData = "";
            PRO_T002 MasterEntity = new PRO_T002();
            MultipleContext_PRO_T002 MC = new MultipleContext_PRO_T002();
            try
            {
                using (IDbConnection conn = new SqlConnection(ConnectionString))
                {

                    var reader = conn.QueryMultiple("PRO_T002Update", new { @Request =Request }, commandType: CommandType.StoredProcedure);
                    var MasterData = reader.Read<PRO_T002>().ToList();
                    List<PRO_T002> Masterlist = MasterData.ToList();

                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }                 

                    var WorkSumTemp = reader.Read<PRO_T002_A>().ToList();
                    MC.WorkSummaryList = WorkSumTemp.ToList();

                    MasterEntity.XmlDataDocument_PRO_T002_A = ObjectSerializationService.ObjectToXML(MC.WorkSummaryList);

                }


                strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
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
        public string delete(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ConnectionString))
                {
                    int intOut = conn.Execute("PRO_T002Delete", new { @task_id = Request }, commandType: CommandType.StoredProcedure);
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

        public string GetData(string RequestValue,string strType, int intValue, string strValue)
        {
            MultipleContext_PRO_T002 MC = new MultipleContext_PRO_T002();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(ConnectionString))
                {
                    var reader = conn.QueryMultiple("PRO_T002LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var Projecttemp = reader.Read<PRO_T001_P>().ToList();
                        MC.ProjectList = Projecttemp.ToList();

                        var Phasetemp = reader.Read<PRO_T001_A_P>().ToList();
                        MC.PhasesList = Phasetemp.ToList();

                        var AssignedTotemp = reader.Read<PRO_T001_B_P>().ToList();
                        MC.AssignedToList = AssignedTotemp.ToList();

                        var Reviewertemp = reader.Read<PRO_T001_B_P>().ToList();
                        MC.ReviewerList = Reviewertemp.ToList();

                        var Workdonetemp = reader.Read<PRO_T001_B_P>().ToList();
                        MC.WorkDoneByList = Reviewertemp.ToList();

                        var DocTypeTemp = reader.Read<SYS_M017_P>().ToList();
                        MC.Doc_typeList = DocTypeTemp.ToList();

                        var WorkSumaryTemp = reader.Read<PRO_T002_A_P>().ToList();
                        MC.WorkSummaryForPopUPList = WorkSumaryTemp.ToList();

                        var TaskViewtemp = reader.Read<PRO_T002_View>().ToList();
                        MC.TaskViewList = TaskViewtemp.ToList();

                        var TaskMastertemp = reader.Read<PRO_M006>().ToList();
                        MC.TaskMasterList = TaskMastertemp.ToList();

                    }

                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var TaskTemp = reader.Read<PRO_T002>().ToList();
                        MC.TaskList = TaskTemp.ToList();

                        var WorkSummaryTemp = reader.Read<PRO_T002_A>().ToList();
                        MC.WorkSummaryList = WorkSummaryTemp.ToList();

                        var attachmentData = reader.Read<COM_T003>().ToList();
                        MC.AttachmentData = attachmentData.ToList();
                    }

                    else if (RequestOption == "LoadIntialDataofTimesheet")
                    {
                            var Timesheettemp = reader.Read<PRO_T002_A_3_A>().ToList();
                            MC.TimesheetList = Timesheettemp.ToList();
                    }

                    strReturnData = ObjectSerializationService.ObjectToXML(MC);
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

        public class MultipleContext_PRO_T002
        {
            public List<PRO_T001_P> ProjectList { get; set; }
            public List<PRO_T001_A_P> PhasesList { get; set; }
            public List<PRO_T001_B_P> AssignedToList { get; set; }
            public List<PRO_T001_B_P> ReviewerList { get; set; }
            public List<SYS_M017_P> Doc_typeList { get; set; }
            public List<PRO_T001_B_P> WorkDoneByList { get; set; }
            public List<PRO_T002> TaskList { get; set; }
            public List<PRO_T002_A_P> WorkSummaryForPopUPList { get; set; }
            public List<PRO_T002_View> TaskViewList { get; set; }
            public List<PRO_T002_A> WorkSummaryList { get; set; }
            public List<PRO_T002_A_3_A> TimesheetList { get; set; }
            public List<COM_T003> AttachmentData { get; set; }
            public List<PRO_M006> TaskMasterList { get; set; }
        }

    }
}
