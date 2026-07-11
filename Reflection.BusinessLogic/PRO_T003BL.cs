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
   public class PRO_T003BL : ReflectionBusinessLogic
    {
        private static string ConnectionString;
        PRO_T003 MasterEntity = new PRO_T003();
        MultipleContext_PRO_T003 MC = new MultipleContext_PRO_T003();
        public PRO_T003BL(string BusinessEntity)
        {
            ConnectionString = base.ReflectionConnectionString;
        }
        public PRO_T003BL()
        {
            ConnectionString = base.ReflectionConnectionString;
        }

        public string Insert(string Request)
        {

            string strReturnData = "";
            PRO_T003 MasterEntity = new PRO_T003();
            MultipleContext_PRO_T003 MC = new MultipleContext_PRO_T003();
            try
            {
                using (IDbConnection conn = new SqlConnection(ConnectionString))
                {
                    var reader = conn.QueryMultiple("PRO_T003Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<PRO_T003>().ToList();
                    List<PRO_T003> Masterlist = MasterData.ToList();

                   
                        MasterEntity = Masterlist[0];
                   

                    var ActionLogTemp = reader.Read<PRO_T003_A>().ToList();
                    MC.ActionLogList = ActionLogTemp.ToList();

                    var IssueViewTemp = reader.Read<PRO_T003_View>().ToList();
                    MC.IssueViewList = IssueViewTemp.ToList();

                    MasterEntity.XmlDataDocument_PRO_T003_A = ObjectSerializationService.ObjectToXML(MC.ActionLogList);
                    MasterEntity.XmlDataDocument_View = ObjectSerializationService.ObjectToXML(MC.IssueViewList);

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

        public string GetData(string RequestValue, string strType, int intValue, string strValue)
        {
            MultipleContext_PRO_T003 MC = new MultipleContext_PRO_T003();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(ConnectionString))
                {
                    var reader = conn.QueryMultiple("PRO_T003LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var Projecttemp = reader.Read<PRO_T001_P>().ToList();
                        MC.ProjectList = Projecttemp.ToList();

                        var Phasetemp = reader.Read<PRO_T001_A_P>().ToList();
                        MC.PhasesList = Phasetemp.ToList();

                        var Tasktemp = reader.Read<PRO_T002_P>().ToList();
                        MC.TaskList = Tasktemp.ToList();

                        var AssignedTotemp = reader.Read<PRO_T001_B_P>().ToList();
                        MC.AssignedToList = AssignedTotemp.ToList();

                        var ReporterNametemp = reader.Read<ADM_M024_P>().ToList();
                        MC.ReporterNameList = ReporterNametemp.ToList();

                        var Workdonetemp = reader.Read<PRO_T001_B_P>().ToList();
                        MC.WorkDoneByList = Workdonetemp.ToList();

                        var IssueCatTemp = reader.Read<PRO_M001_P>().ToList();
                        MC.IssueCategoryList = IssueCatTemp.ToList();

                        var DocTypeTemp = reader.Read<SYS_M017_P>().ToList();
                        MC.Doc_typeList = DocTypeTemp.ToList();

                        var IssueViewtemp = reader.Read<PRO_T003_View>().ToList();
                        MC.IssueViewList = IssueViewtemp.ToList();

                    }

                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var IssueTemp = reader.Read<PRO_T003>().ToList();
                        MC.IssueList = IssueTemp.ToList();

                        var ActionLogTemp = reader.Read<PRO_T003_A>().ToList();
                        MC.ActionLogList = ActionLogTemp.ToList();

                        var attachmentData = reader.Read<COM_T003>().ToList();
                        MC.AttachmentData = attachmentData.ToList();
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

        public string Update(string Request)
        {
            string strReturnData = "";
            PRO_T003 MasterEntity = new PRO_T003();
            MultipleContext_PRO_T003 MC = new MultipleContext_PRO_T003();
            try
            {
                using (IDbConnection conn = new SqlConnection(ConnectionString))
                {

                    var reader = conn.QueryMultiple("PRO_T003Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);
                    var MasterData = reader.Read<PRO_T003>().ToList();
                    List<PRO_T003> Masterlist = MasterData.ToList();
                  
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    var ActionLogTemp = reader.Read<PRO_T003_A>().ToList();
                    MC.ActionLogList = ActionLogTemp.ToList();

                    MasterEntity.XmlDataDocument_PRO_T003_A = ObjectSerializationService.ObjectToXML(MC.ActionLogList);

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
    }
    public class MultipleContext_PRO_T003
    {
        public List<PRO_T001_P> ProjectList { get; set; }
        public List<PRO_T001_A_P> PhasesList { get; set; }
        public List<PRO_T002_P> TaskList { get; set; }
        public List<PRO_T001_B_P> AssignedToList { get; set; }
        public List<ADM_M024_P> ReporterNameList { get; set; }
        public List<PRO_T001_B_P> WorkDoneByList { get; set; }           
        public List<PRO_T003_View> IssueViewList { get; set; }
        public List<SYS_M017_P> Doc_typeList { get; set; }
        public List <PRO_T002_A_3_A> TimesheetList { get; set; }
        public List<PRO_T003_A> ActionLogList { get; set; }
        public List<PRO_T003> IssueList { get; set; }
        public List<COM_T003> AttachmentData { get; set; }
        public List<PRO_M001_P> IssueCategoryList { get; set; }
    }
}
