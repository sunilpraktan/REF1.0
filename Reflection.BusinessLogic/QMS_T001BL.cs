using Dapper;
using Reflection.EF;
using Reflection.EF.Communication;
using Reflection.EF.QMS;
using Reflection.EF.ReflectionSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Reflection.BusinessLogic
{
    public class QMS_T001BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        QMS_T001 MasterEntity = new QMS_T001();
        MultipleContext_QMS_T001 MC = new MultipleContext_QMS_T001();
        public QMS_T001BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public QMS_T001BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_T001Insert", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<QMS_T001Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var masterList = reader.Read<QMS_T001>().ToList();
                    List<QMS_T001> MasterList = masterList.ToList();
                    if (MasterList.Count > 0)
                    {
                        MasterEntity = MasterList[0];
                    }

                    var MasterEq = reader.Read<QMS_T001_A>().ToList();
                    MC.MasterEquipment = MasterEq.ToList();

                    var testTypeEntity = reader.Read<QMS_T001_B>().ToList();
                    MC.TestTypeEntity = testTypeEntity.ToList();

                    var parameterEntity = reader.Read<QMS_M003_B>().ToList();
                    MC.ParameterEntity = parameterEntity.ToList();

                    var testType = reader.Read<QMS_M009_B>().ToList();
                    MC.TestType = testType.ToList();

                    var benchHeader = reader.Read<QMS_M009_C>().ToList();
                    MC.BenchHeader = benchHeader.ToList();

                    var headerValue = reader.Read<QMS_M009_D>().ToList();
                    MC.HeaderValue = headerValue.ToList();

                    var masterHeader = reader.Read<QMS_M009_E>().ToList();
                    MC.MasterHeader = masterHeader.ToList();

                    var unitHeader = reader.Read<QMS_M009_E>().ToList();
                    MC.UnitHeader = unitHeader.ToList();

                    var tasklist = reader.Read<QMS_T001_E>().ToList();
                    MC.TaskListEntity = tasklist.ToList();

                    var envcond = reader.Read<QMS_T001_F>().ToList();
                    MC.EnvCondEntity = envcond.ToList();

                    var mastervalues = reader.Read<QMS_M009_J>().ToList();
                    MC.MasterValueEntity = mastervalues.ToList();

                    MasterEntity.XmlDataDocument_QMS_T001Flip = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                    MasterEntity.XmlDataDocument_QMS_T001_A = ObjectSerializationService.ObjectToXML(MC.MasterEquipment);
                    MasterEntity.XmlDataDocument_QMS_T001_B = ObjectSerializationService.ObjectToXML(MC.TestTypeEntity);
                    //MasterEntity.XmlDataDocument_QMS_T001_C = ObjectSerializationService.ObjectToXML(MC.HeaderValueEntity);
                    MasterEntity.XmlDataDocument_QMS_M003_B = ObjectSerializationService.ObjectToXML(MC.ParameterEntity);
                    MasterEntity.XmlDataDocument_QMS_M009_B = ObjectSerializationService.ObjectToXML(MC.TestType);
                    MasterEntity.XmlDataDocument_QMS_M009_C = ObjectSerializationService.ObjectToXML(MC.BenchHeader);
                    MasterEntity.XmlDataDocument_QMS_M009_D = ObjectSerializationService.ObjectToXML(MC.HeaderValue);
                    MasterEntity.XmlDataDocument_QMS_M009_E_M = ObjectSerializationService.ObjectToXML(MC.MasterHeader);
                    MasterEntity.XmlDataDocument_QMS_M009_E_I = ObjectSerializationService.ObjectToXML(MC.UnitHeader);
                    MasterEntity.XmlDataDocument_QMS_T001_E = ObjectSerializationService.ObjectToXML(MC.TaskListEntity);
                    MasterEntity.XmlDataDocument_QMS_T001_F = ObjectSerializationService.ObjectToXML(MC.EnvCondEntity);
                    MasterEntity.XmlDataDocument_QMS_M009_J = ObjectSerializationService.ObjectToXML(MC.MasterValueEntity);
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
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_T001Update", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<QMS_T001Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var masterList = reader.Read<QMS_T001>().ToList();
                    List<QMS_T001> MasterList = masterList.ToList();
                    if (MasterList.Count > 0)
                    {
                        MasterEntity = MasterList[0];
                    }

                    var MasterEq = reader.Read<QMS_T001_A>().ToList();
                    MC.MasterEquipment = MasterEq.ToList();

                    var testTypeEntity = reader.Read<QMS_T001_B>().ToList();
                    MC.TestTypeEntity = testTypeEntity.ToList();

                    var parameterEntity = reader.Read<QMS_M003_B>().ToList();
                    MC.ParameterEntity = parameterEntity.ToList();

                    var testType = reader.Read<QMS_M009_B>().ToList();
                    MC.TestType = testType.ToList();

                    var benchHeader = reader.Read<QMS_M009_C>().ToList();
                    MC.BenchHeader = benchHeader.ToList();

                    var headerValue = reader.Read<QMS_M009_D>().ToList();
                    MC.HeaderValue = headerValue.ToList();

                    var masterHeader = reader.Read<QMS_M009_E>().ToList();
                    MC.MasterHeader = masterHeader.ToList();

                    var unitHeader = reader.Read<QMS_M009_E>().ToList();
                    MC.UnitHeader = unitHeader.ToList();

                    var tasklist = reader.Read<QMS_T001_E>().ToList();
                    MC.TaskListEntity = tasklist.ToList();

                    var envcond = reader.Read<QMS_T001_F>().ToList();
                    MC.EnvCondEntity = envcond.ToList();
                    
                    var mastervalues = reader.Read<QMS_M009_J>().ToList();
                    MC.MasterValueEntity = mastervalues.ToList();

                    MasterEntity.XmlDataDocument_QMS_T001_A = ObjectSerializationService.ObjectToXML(MasterEntity);
                    MasterEntity.XmlDataDocument_QMS_T001Flip = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                    MasterEntity.XmlDataDocument_QMS_T001_A = ObjectSerializationService.ObjectToXML(MC.MasterEquipment);
                    MasterEntity.XmlDataDocument_QMS_T001_B = ObjectSerializationService.ObjectToXML(MC.TestTypeEntity);
                    //MasterEntity.XmlDataDocument_QMS_T001_C = ObjectSerializationService.ObjectToXML(MC.HeaderValueEntity);
                    MasterEntity.XmlDataDocument_QMS_M003_B = ObjectSerializationService.ObjectToXML(MC.ParameterEntity);
                    MasterEntity.XmlDataDocument_QMS_M009_B = ObjectSerializationService.ObjectToXML(MC.TestType);
                    MasterEntity.XmlDataDocument_QMS_M009_C = ObjectSerializationService.ObjectToXML(MC.BenchHeader);
                    MasterEntity.XmlDataDocument_QMS_M009_D = ObjectSerializationService.ObjectToXML(MC.HeaderValue);
                    MasterEntity.XmlDataDocument_QMS_M009_E_M = ObjectSerializationService.ObjectToXML(MC.MasterHeader);
                    MasterEntity.XmlDataDocument_QMS_M009_E_I = ObjectSerializationService.ObjectToXML(MC.UnitHeader);
                    MasterEntity.XmlDataDocument_QMS_T001_E = ObjectSerializationService.ObjectToXML(MC.TaskListEntity);
                    MasterEntity.XmlDataDocument_QMS_T001_F = ObjectSerializationService.ObjectToXML(MC.EnvCondEntity);
                    MasterEntity.XmlDataDocument_QMS_M009_J = ObjectSerializationService.ObjectToXML(MC.MasterValueEntity);
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
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = 0; //conn.Execute("CAL_T001Delete", new { @srNo = Request }, commandType: CommandType.StoredProcedure);
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
            try
            {
                string RequestOption = RequestValue.Split('!')[0];
                string strReturnData = "";

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_T001LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var docinfo = reader.Read<SYS_M002>().ToList();
                        MC.DocTypeInfo = docinfo.ToList();

                        var calview = reader.Read<QMS_T001Flip>().ToList();
                        MC.DocumentDataFlipGrid = calview.ToList();

                        var employee = reader.Read<ADM_M024_P>().ToList();
                        MC.Employees = employee.ToList();

                        var UOM = reader.Read<ADM_M038_B_P>().ToList();
                        MC.UnitCode = UOM.ToList();

                        var tracblty = reader.Read<QMS_M010_P>().ToList();
                        MC.Tracibility = tracblty.ToList();

                        var rig = reader.Read<QMS_M008_P>().ToList();
                        MC.Rig = rig.ToList();

                        var tasklist = reader.Read<QMS_M024Flip>().ToList();
                        MC.TaskList = tasklist.ToList();

                        var InstCode = reader.Read<QMS_M003_P>().ToList();
                        MC.EqCode = InstCode.ToList();

                        var envcond = reader.Read<QMS_M017>().ToList();
                        MC.StdEnvCond = envcond.ToList();

                        var cov_factor = reader.Read<QMS_M016>().ToList();
                        MC.CovFactorChart = cov_factor.ToList();

                        var formula = reader.Read<QMS_M011>().ToList();
                        MC.FormulaDetails = formula.ToList();
                    }
                    else if (RequestOption == "LoadDocumentByRefDocNumber")
                    {
                        var refdoc = reader.Read<QMS_T002>().ToList();
                        MC.RefDocCollection = refdoc.ToList();

                        var testCode = reader.Read<QMS_M009_A>().ToList();
                        MC.TestCode = testCode.ToList();

                        var testType = reader.Read<QMS_M009_B>().ToList();
                        MC.TestType = testType.ToList();

                        var benchHeader = reader.Read<QMS_M009_C>().ToList();
                        MC.BenchHeader = benchHeader.ToList();

                        var headerValue = reader.Read<QMS_M009_D>().ToList();
                        MC.HeaderValue = headerValue.ToList();

                        var masterHeader = reader.Read<QMS_M009_E>().ToList();
                        MC.MasterHeader = masterHeader.ToList();

                        var unitHeader = reader.Read<QMS_M009_E>().ToList();
                        MC.UnitHeader = unitHeader.ToList();

                        var parameter = reader.Read<QMS_M009_F>().ToList();
                        MC.Parameter = parameter.ToList();

                        //var purorder = reader.Read<Inst_Pur_Details_P>().ToList();
                        //MC.PurOrder = purorder.ToList();

                        var tasklist = reader.Read<QMS_T001_E>().ToList();
                        MC.TaskListEntity = tasklist.ToList();

                        var mastervalues = reader.Read<QMS_M009_J>().ToList();
                        MC.MasterValueEntity = mastervalues.ToList();

                        var envcond = reader.Read<QMS_M009_K>().ToList();
                        MC.EnvConditionEntity = envcond.ToList();

                        var unscope = reader.Read<QMS_T004>().ToList();
                        MC.UncertaintyScope = unscope.ToList();
                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var masterEntity = reader.Read<QMS_T001>().ToList();
                        MC.MasterEntity = masterEntity.ToList();

                        var MasterEq = reader.Read<QMS_T001_A>().ToList();
                        MC.MasterEquipment = MasterEq.ToList();

                        var testTypeEntity = reader.Read<QMS_T001_B>().ToList();
                        MC.TestTypeEntity = testTypeEntity.ToList();

                        var parameterEntity = reader.Read<QMS_M003_B>().ToList();
                        MC.ParameterEntity = parameterEntity.ToList();

                        var testType = reader.Read<QMS_M009_B>().ToList();
                        MC.TestType = testType.ToList();

                        var benchHeader = reader.Read<QMS_M009_C>().ToList();
                        MC.BenchHeader = benchHeader.ToList();

                        var headerValue = reader.Read<QMS_M009_D>().ToList();
                        MC.HeaderValue = headerValue.ToList();

                        var masterHeader = reader.Read<QMS_M009_E>().ToList();
                        MC.MasterHeader = masterHeader.ToList();

                        var unitHeader = reader.Read<QMS_M009_E>().ToList();
                        MC.UnitHeader = unitHeader.ToList();

                        var tasklist = reader.Read<QMS_T001_E>().ToList();
                        MC.TaskListEntity = tasklist.ToList();

                        var Attachment = reader.Read<COM_T003>().ToList();
                        MC.Attachment = Attachment.ToList();

                        var formula = reader.Read<QMS_M011>().ToList();
                        MC.FormulaDetails = formula.ToList();

                        var envcond = reader.Read<QMS_T001_F>().ToList();
                        MC.EnvCondEntity = envcond.ToList();

                        var mastervalues = reader.Read<QMS_M009_J>().ToList();
                        MC.MasterValueEntity = mastervalues.ToList();

                        var unscope = reader.Read<QMS_T004>().ToList();
                        MC.UncertaintyScope = unscope.ToList();
                    }
                    else if (RequestOption == "LoadReportData")
                    {
                        var masterEntity = reader.Read<QMS_T001>().ToList();
                        MC.MasterEntity = masterEntity.ToList();

                        var MasterEq = reader.Read<QMS_T001_A>().ToList();
                        MC.MasterEquipment = MasterEq.ToList();

                        var rpttest = reader.Read<RptTestType>().ToList();
                        MC.RptDatasheet = rpttest.ToList();

                        var parameterEntity = reader.Read<QMS_M003_B>().ToList();
                        MC.ParameterEntity = parameterEntity.ToList();

                        var envcond = reader.Read<QMS_T001_F>().ToList();
                        MC.EnvCondEntity = envcond.ToList();
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
        public class MultipleContext_QMS_T001
        {
            public List<SYS_M002> DocTypeInfo { get; set; }
            public List<QMS_T001Flip> DocumentDataFlipGrid { get; set; } //DataGridCollection        
            public List<ADM_M038_B_P> UnitCode { get; set; }  //UOM List
            public List<QMS_M003_P> EqCode { get; set; } // Equipement Code List
            public List<ADM_M024_P> Employees { get; set; } //Responsible Person
            //public List<Inst_Pur_Details_P> PurOrder { get; set; } //PO Number
            public List<QMS_T002> RefDocCollection { get; set; }    // Ref Doc Collection  
            public List<QMS_M009_A> TestCode { get; set; }    // Test Code Collection  
            public List<QMS_M024Flip> TaskList { get; set; }    // TaskList Collection  
            public List<QMS_M009_B> TestType { get; set; }    // TestType Collection  
            public List<QMS_M009_C> BenchHeader { get; set; }    // BenchHeader Collection  
            public List<QMS_M009_D> HeaderValue { get; set; }    // HeaderValue Collection  
            public List<QMS_M009_E> MasterHeader { get; set; }    // MasterHeader Collection  
            public List<QMS_M009_E> UnitHeader { get; set; }    // UnitHeader Collection   
            public List<QMS_M009_F> Parameter { get; set; }    // ParaValue Collection 
            public List<QMS_M009_J> MasterValueEntity { get; set; }  //Default Master Readings
            public List<QMS_M009_K> EnvConditionEntity { get; set; }  //Default Environment Conditions
            public List<QMS_M010_P> Tracibility { get; set; }
            public List<QMS_M008_P> Rig { get; set; }
            public List<QMS_T001> MasterEntity { get; set; }
            public List<QMS_T001_B> TestTypeEntity { get; set; }
            public List<QMS_M003_B> ParameterEntity { get; set; }
            public List<QMS_T001_E> TaskListEntity { get; set; }
            public List<QMS_T001_F> EnvCondEntity { get; set; }
            public List<RptTestType> RptDatasheet { get; set; }
            public List<COM_T003> Attachment { get; set; }
            public List<NotificationData> NotificationData { get; set; }
            public List<QMS_T001_A> MasterEquipment { get; set; }
            public List<QMS_M011> FormulaDetails { get; set; }
            public List<QMS_M017> StdEnvCond { get; set; }
            public List<QMS_M016> CovFactorChart { get; set; }
            public List<QMS_T004> UncertaintyScope { get; set; }

        }
    }
}
