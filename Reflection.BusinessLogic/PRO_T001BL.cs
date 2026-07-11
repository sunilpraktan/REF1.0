using Reflection.EF;
using Reflection.EF.Project_Management;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Reflection.EF.Communication;

namespace Reflection.BusinessLogic
{
    public class PRO_T001BL : ReflectionBusinessLogic
    {      
        static int obj = 0;
        private static string ConnectionString;
        public PRO_T001BL(string BusinessEntity)
        {
            ConnectionString = base.ReflectionConnectionString;
        }
        public PRO_T001BL()
        {
            ConnectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            MultipleContext_PRO_T001 MC = new MultipleContext_PRO_T001();
            PRO_T001 MasterEntity = new PRO_T001();
            try
            {
                using (IDbConnection conn = new SqlConnection(ConnectionString))
                {
                    var reader = conn.QueryMultiple("PRO_T001Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<PRO_T001>().ToList();
                    List<PRO_T001> Masterlist = MasterData.ToList();
                    MasterEntity = Masterlist[0];

                    var ProjectPhaseTemp = reader.Read<PRO_T001_A>().ToList();
                    MC.ProjectPhaseList = ProjectPhaseTemp.ToList();

                    var ProjectEmployeeTemp = reader.Read<PRO_T001_B>().ToList();
                    MC.ProjectEmployeeList = ProjectEmployeeTemp.ToList();

                    var ProjectMatTemp = reader.Read<PRO_T001_C>().ToList();
                    MC.ProjectItemList = ProjectMatTemp.ToList();

                    var ProjectApprovalCheckListTemp = reader.Read<PRO_T001_D>().ToList();
                    MC.ProjectApprovalCheckList = ProjectApprovalCheckListTemp.ToList();

                    var projecttasktemp = reader.Read<PRO_T002>().ToList();
                    MC.ProjectTaskList = projecttasktemp.ToList();

                    var FlipData = reader.Read<PRO_T001_FLIP>().ToList();
                    MC.ProjectList = FlipData.ToList();

                    MasterEntity.XmlDataDocument_PRO_T001_A = ObjectSerializationService.ObjectToXML(MC.ProjectPhaseList);
                    MasterEntity.XmlDataDocument_PRO_T001_B = ObjectSerializationService.ObjectToXML(MC.ProjectEmployeeList);
                    MasterEntity.XmlDataDocument_PRO_T001_C = ObjectSerializationService.ObjectToXML(MC.ProjectItemList);
                    MasterEntity.XmlDataDocument_PRO_T001_D = ObjectSerializationService.ObjectToXML(MC.ProjectApprovalCheckList);
                    MasterEntity.XmlDataDocument_PRO_T002 = ObjectSerializationService.ObjectToXML(MC.ProjectTaskList);
                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.ProjectList);
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
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
            MultipleContext_PRO_T001 MC = new MultipleContext_PRO_T001();
            PRO_T001 MasterEntity = new PRO_T001();
            try
            {
                using (IDbConnection conn = new SqlConnection(ConnectionString))
                {

                    var reader = conn.QueryMultiple("PRO_T001Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);
                  
                    var MasterData = reader.Read<PRO_T001>().ToList();
                    List<PRO_T001> Masterlist = MasterData.ToList();

                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }                    

                    var ProjectPhaseTemp = reader.Read<PRO_T001_A>().ToList();
                    MC.ProjectPhaseList = ProjectPhaseTemp.ToList();

                    var ProjectEmployeeTemp = reader.Read<PRO_T001_B>().ToList();
                    MC.ProjectEmployeeList = ProjectEmployeeTemp.ToList();

                    var ProjectMatTemp = reader.Read<PRO_T001_C>().ToList();
                    MC.ProjectItemList = ProjectMatTemp.ToList();

                    var ProjectApprovalCheckListTemp = reader.Read<PRO_T001_D>().ToList();
                    MC.ProjectApprovalCheckList = ProjectApprovalCheckListTemp.ToList();

                    var projecttasktemp = reader.Read<PRO_T002>().ToList();
                    MC.ProjectTaskList = projecttasktemp.ToList();


                    MasterEntity.XmlDataDocument_PRO_T001_A = ObjectSerializationService.ObjectToXML(MC.ProjectPhaseList);
                    MasterEntity.XmlDataDocument_PRO_T001_B = ObjectSerializationService.ObjectToXML(MC.ProjectEmployeeList);
                    MasterEntity.XmlDataDocument_PRO_T001_C = ObjectSerializationService.ObjectToXML(MC.ProjectItemList);
                    MasterEntity.XmlDataDocument_PRO_T001_D = ObjectSerializationService.ObjectToXML(MC.ProjectApprovalCheckList);
                    MasterEntity.XmlDataDocument_PRO_T002 = ObjectSerializationService.ObjectToXML(MC.ProjectTaskList);
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
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
        public string Delete(string Request)
        {
            try
            {               
                using (IDbConnection conn = new SqlConnection(ConnectionString))
                {
                    int intOut = conn.Execute("PRO_T001Delete", new { @project_id = Request }, commandType: CommandType.StoredProcedure);
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
            MultipleContext_PRO_T001 MC = new MultipleContext_PRO_T001();
    
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(ConnectionString))
                {
                    var reader = conn.QueryMultiple("PRO_T001LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var PartyMaster = reader.Read<ADM_M028_P>().ToList();
                        MC.PartyList = PartyMaster.ToList();            

                        var EmployeeMaster = reader.Read<ADM_M024_P>().ToList();
                        MC.EmployeeList = EmployeeMaster.ToList();

                        var SONumber = reader.Read<SEL_T001_P>().ToList();
                        MC.SonoList = SONumber.ToList();

                        var DocTypeTemp = reader.Read<SYS_M017_P>().ToList();
                        MC.Doc_typeList = DocTypeTemp.ToList();

                        var PhaseMaster = reader.Read<PRO_M003_P>().ToList();
                        MC.PhaseList = PhaseMaster.ToList();

                        var MaterialMaster = reader.Read<ADM_M022_P>().ToList();
                        MC.ItemList = MaterialMaster.ToList();

                        var UomMaster = reader.Read<ADM_M038_B_P>().ToList();
                        MC.UomList = UomMaster.ToList();

                        var RoleMaster = reader.Read<PRO_M004_P>().ToList();
                        MC.RoleList = RoleMaster.ToList();

                        var CheckListMaster = reader.Read<PRO_M005_P>().ToList();
                        MC.ProjectCheckList = CheckListMaster.ToList();

                        var ProCatTemp = reader.Read<PRO_M001_P>().ToList();
                        MC.ProjectCategoryList = ProCatTemp.ToList();

                        var ProSubCatTemp = reader.Read<PRO_M001_A_P>().ToList();
                        MC.ProjectSubCategoryList = ProSubCatTemp.ToList();

                        var TaskMasterTemp = reader.Read<PRO_T002_P_1>().ToList();
                        MC.TaskList  = TaskMasterTemp.ToList();

                        var Project = reader.Read<PRO_T001_FLIP>().ToList();
                        MC.ProjectList = Project.ToList();

                        MC.MakeList = reader.Read<ADM_M031_P>().ToList();

                        MC.ModelList = reader.Read<ADM_M031_P>().ToList();
                    }
                    
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var MasterData = reader.Read<PRO_T001>().ToList();
                        MC.ProjectMasterList = MasterData.ToList();

                        var ProjectPhaseTemp = reader.Read<PRO_T001_A>().ToList();
                        MC.ProjectPhaseList = ProjectPhaseTemp.ToList();

                        var ProjectEmployeeTemp = reader.Read<PRO_T001_B>().ToList();
                        MC.ProjectEmployeeList = ProjectEmployeeTemp.ToList();

                        var ProjectMatTemp = reader.Read<PRO_T001_C>().ToList();
                        MC.ProjectItemList = ProjectMatTemp.ToList();

                        var ProjectAppCheckListTemp = reader.Read<PRO_T001_D>().ToList();
                        MC.ProjectApprovalCheckList = ProjectAppCheckListTemp.ToList();

                        var projecttasktemp = reader.Read<PRO_T002>().ToList();
                        MC.ProjectTaskList = projecttasktemp.ToList();

                        var attachmentData = reader.Read<COM_T003>().ToList();
                        MC.AttachmentData = attachmentData.ToList();
                    }
                    //else if (RequestOption == "KickOff")
                    //{
                    //    var Ecount = reader.Read<Int32>().ToList();
                    //    MC.EmpCount = Convert.ToInt32(Ecount[0]);

                    //    var Phcount = reader.Read<Int32>().ToList();
                    //    MC.PhaseCount = Convert.ToInt32(Phcount[0]);

                    //    var Tcount = reader.Read<Int32>().ToList();
                    //    MC.TaskCount = Convert.ToInt32(Tcount[0]);

                    //    strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    //}               
                }
                strReturnData = ObjectSerializationService.ObjectToXML(MC);
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
        public class MultipleContext_PRO_T001
        {
            public List<ADM_M028_P> PartyList { get; set; }
            public List<ADM_M024_P> EmployeeList { get; set; }
            public List<SEL_T001_P> SonoList { get; set; }
            public List<SYS_M017_P> Doc_typeList { get; set; }
            public List<PRO_M003_P> PhaseList { get; set; }
            public List<ADM_M022_P> ItemList { get; set; }
            public List<ADM_M038_B_P> UomList { get; set; }
            public List<PRO_M004_P> RoleList { get; set; }
            public List<PRO_M005_P> ProjectCheckList { get; set; }
            public List<PRO_T001_FLIP> ProjectList { get; set; }
            public List<PRO_T001_A> ProjectPhaseList { get; set; }
            public List<PRO_T001_B> ProjectEmployeeList { get; set; }
            public List<PRO_T001_C> ProjectItemList { get; set; }
            public List<PRO_T001_D> ProjectApprovalCheckList { get; set; }
            public List<PRO_T001> ProjectMasterList { get; set; }
            public List<PRO_T002> ProjectTaskList { get; set; }
            public List<PRO_T002_P_1> TaskList { get; set; }
            public int? EmpCount { get; set; }
            public int? PhaseCount { get; set; }
            public int? TaskCount { get; set; }
            public List<COM_T003> AttachmentData { get; set; }
            public List<PRO_M001_P> ProjectCategoryList { get; set; }
            public List<PRO_M001_A_P> ProjectSubCategoryList { get; set; }
            public List<ADM_M031_P> MakeList { get; set; }
            public List<ADM_M031_P> ModelList { get; set; }
        }
    }
}
