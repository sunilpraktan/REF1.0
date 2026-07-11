using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using Reflection.EF.QMS;
using System.Data;
using Dapper;
using Reflection.EF.Communication;

namespace Reflection.BusinessLogic
{
    public class QMS_M009BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        QMS_M009_A MasterEntity = new QMS_M009_A();
        MultipleContext_QMS_M009 MC = new MultipleContext_QMS_M009();
        public QMS_M009BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public QMS_M009BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M009Insert", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<QMS_M009Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var test = reader.Read<QMS_M009_A>().ToList();
                    List<QMS_M009_A> master = test.ToList();
                    if (master.Count > 0)
                    {
                        MasterEntity = master[0];
                    }

                    var testTypeEntity = reader.Read<QMS_M009_B>().ToList();
                    MC.TestTypeEntity = testTypeEntity.ToList();

                    var testHeaderEntity = reader.Read<QMS_M009_C>().ToList();
                    MC.TestHeaderEntity = testHeaderEntity.ToList();

                    var headerValueEntity = reader.Read<QMS_M009_D>().ToList();
                    MC.HeaderValueEntity = headerValueEntity.ToList();

                    var masterHeaderEntity = reader.Read<QMS_M009_E>().ToList();
                    MC.MasterHeaderEntity = masterHeaderEntity.ToList();

                    var instHeaderEntity = reader.Read<QMS_M009_E>().ToList();
                    MC.InstHeaderEntity = instHeaderEntity.ToList();

                    var parameterEntity = reader.Read<QMS_M009_F>().ToList();
                    MC.ParameterEntity = parameterEntity.ToList();

                    var parameterValueEntity = reader.Read<QMS_M009_G>().ToList();
                    MC.ParameterValueEntity = parameterValueEntity.ToList();

                    var tsklistEntity = reader.Read<QMS_M009_H>().ToList();
                    MC.TaskListEntity = tsklistEntity.ToList();

                    MasterEntity.XmlDataDocument_QMS_M009Flip = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                    MasterEntity.XmlDataDocument_QMS_M009_B = ObjectSerializationService.ObjectToXML(MC.TestTypeEntity);
                    MasterEntity.XmlDataDocument_QMS_M009_C = ObjectSerializationService.ObjectToXML(MC.TestHeaderEntity);
                    MasterEntity.XmlDataDocument_QMS_M009_D = ObjectSerializationService.ObjectToXML(MC.HeaderValueEntity);
                    MasterEntity.XmlDataDocument_QMS_M009_E_M = ObjectSerializationService.ObjectToXML(MC.MasterHeaderEntity);
                    MasterEntity.XmlDataDocument_QMS_M009_E_I = ObjectSerializationService.ObjectToXML(MC.InstHeaderEntity);
                    MasterEntity.XmlDataDocument_QMS_M009_F = ObjectSerializationService.ObjectToXML(MC.ParameterEntity);
                    MasterEntity.XmlDataDocument_QMS_M009_G = ObjectSerializationService.ObjectToXML(MC.ParameterValueEntity);
                    MasterEntity.XmlDataDocument_QMS_M009_H = ObjectSerializationService.ObjectToXML(MC.TaskListEntity);
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
                    var reader = conn.QueryMultiple("QMS_M009Update", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<QMS_M009Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var test = reader.Read<QMS_M009_A>().ToList();
                    List<QMS_M009_A> master = test.ToList();
                    if (master.Count > 0)
                    {
                        MasterEntity = master[0];
                    }

                    var testTypeEntity = reader.Read<QMS_M009_B>().ToList();
                    MC.TestTypeEntity = testTypeEntity.ToList();

                    var testHeaderEntity = reader.Read<QMS_M009_C>().ToList();
                    MC.TestHeaderEntity = testHeaderEntity.ToList();

                    var headerValueEntity = reader.Read<QMS_M009_D>().ToList();
                    MC.HeaderValueEntity = headerValueEntity.ToList();

                    var masterHeaderEntity = reader.Read<QMS_M009_E>().ToList();
                    MC.MasterHeaderEntity = masterHeaderEntity.ToList();

                    var instHeaderEntity = reader.Read<QMS_M009_E>().ToList();
                    MC.InstHeaderEntity = instHeaderEntity.ToList();

                    var parameterEntity = reader.Read<QMS_M009_F>().ToList();
                    MC.ParameterEntity = parameterEntity.ToList();

                    var parameterValueEntity = reader.Read<QMS_M009_G>().ToList();
                    MC.ParameterValueEntity = parameterValueEntity.ToList();

                    var tsklistEntity = reader.Read<QMS_M009_H>().ToList();
                    MC.TaskListEntity = tsklistEntity.ToList();

                    var mastervalues = reader.Read<QMS_M009_J>().ToList();
                    MC.MasterValueEntity = mastervalues.ToList();

                    var envcond = reader.Read<QMS_M009_K>().ToList();
                    MC.EnvConditionEntity = envcond.ToList();

                    MasterEntity.XmlDataDocument_QMS_M009Flip = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                    MasterEntity.XmlDataDocument_QMS_M009_B = ObjectSerializationService.ObjectToXML(MC.TestTypeEntity);
                    MasterEntity.XmlDataDocument_QMS_M009_C = ObjectSerializationService.ObjectToXML(MC.TestHeaderEntity);
                    MasterEntity.XmlDataDocument_QMS_M009_D = ObjectSerializationService.ObjectToXML(MC.HeaderValueEntity);
                    MasterEntity.XmlDataDocument_QMS_M009_E_M = ObjectSerializationService.ObjectToXML(MC.MasterHeaderEntity);
                    MasterEntity.XmlDataDocument_QMS_M009_E_I = ObjectSerializationService.ObjectToXML(MC.InstHeaderEntity);
                    MasterEntity.XmlDataDocument_QMS_M009_F = ObjectSerializationService.ObjectToXML(MC.ParameterEntity);
                    MasterEntity.XmlDataDocument_QMS_M009_G = ObjectSerializationService.ObjectToXML(MC.ParameterValueEntity);
                    MasterEntity.XmlDataDocument_QMS_M009_H = ObjectSerializationService.ObjectToXML(MC.TaskListEntity);
                    MasterEntity.XmlDataDocument_QMS_M009_J = ObjectSerializationService.ObjectToXML(MC.MasterValueEntity);
                    MasterEntity.XmlDataDocument_QMS_M009_K = ObjectSerializationService.ObjectToXML(MC.EnvConditionEntity);
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
                    int intOut = 0; //conn.Execute("QMS_M009Delete", new { @srNo = Request }, commandType: CommandType.StoredProcedure);
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
                    var reader = conn.QueryMultiple("QMS_M009LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var instr = reader.Read<QMS_M009Flip>().ToList();
                        MC.DocumentDataFlipGrid = instr.ToList();

                        var calmaster = reader.Read<QMS_M003_P>().ToList();
                        MC.CalMaster = calmaster.ToList();

                        var grp = reader.Read<ADM_M018_P>().ToList();
                        MC.Cat = grp.ToList();

                        var insptype = reader.Read<QMS_M013_P>().ToList();
                        MC.InspType = insptype.ToList();

                        var tp = reader.Read<QMS_M006_P>().ToList();
                        MC.TpCode = tp.ToList();

                        var wi = reader.Read<QMS_M007_P>().ToList();
                        MC.WiCode = wi.ToList();

                        var UOM = reader.Read<ADM_M038_B_P>().ToList();
                        MC.UnitCode = UOM.ToList();

                        var tasklist = reader.Read<QMS_M024Flip>().ToList();
                        MC.TaskList = tasklist.ToList();

                        var item = reader.Read<ADM_M022_P>().ToList();
                        MC.ItemService = item.ToList();

                        var formula = reader.Read<QMS_M011>().ToList();
                        MC.FormulaCode = formula.ToList();

                        var envcond = reader.Read<QMS_M017>().ToList();
                        MC.EnvCond = envcond.ToList();

                        var inspchar = reader.Read<QMS_M030_I_P>().ToList();
                        MC.InspectionChar = inspchar.ToList();
                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var test = reader.Read<QMS_M009_A>().ToList();
                        MC.MasterEntity = test.ToList();

                        var testTypeEntity = reader.Read<QMS_M009_B>().ToList();
                        MC.TestTypeEntity = testTypeEntity.ToList();

                        var testHeaderEntity = reader.Read<QMS_M009_C>().ToList();
                        MC.TestHeaderEntity = testHeaderEntity.ToList();

                        var headerValueEntity = reader.Read<QMS_M009_D>().ToList();
                        MC.HeaderValueEntity = headerValueEntity.ToList();

                        var masterHeaderEntity = reader.Read<QMS_M009_E>().ToList();
                        MC.MasterHeaderEntity = masterHeaderEntity.ToList();

                        var instHeaderEntity = reader.Read<QMS_M009_E>().ToList();
                        MC.InstHeaderEntity = instHeaderEntity.ToList();

                        var parameterEntity = reader.Read<QMS_M009_F>().ToList();
                        MC.ParameterEntity = parameterEntity.ToList();

                        var parameterValueEntity = reader.Read<QMS_M009_G>().ToList();
                        MC.ParameterValueEntity = parameterValueEntity.ToList();

                        var tsklistEntity = reader.Read<QMS_M009_H>().ToList();
                        MC.TaskListEntity = tsklistEntity.ToList();

                        var Attachment = reader.Read<COM_T003>().ToList();
                        MC.Attachment = Attachment.ToList();

                        var mastervalues = reader.Read<QMS_M009_J>().ToList();
                        MC.MasterValueEntity = mastervalues.ToList();

                        var envcond = reader.Read<QMS_M009_K>().ToList();
                        MC.EnvConditionEntity = envcond.ToList();
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
        public class MultipleContext_QMS_M009
        {
            public List<QMS_M009Flip> DocumentDataFlipGrid { get; set; } //DataGridCollection
            public List<QMS_M003_P> CalMaster { get; set; }  //Cal Master
            public List<ADM_M018_P> Cat { get; set; }  //Cat Master
            public List<QMS_M013_P> InspType { get; set; }  //Insp type Master
            public List<QMS_M006_P> TpCode { get; set; } //Test Procedure popup
            public List<QMS_M007_P> WiCode { get; set; } //Work Instruction popup
            public List<ADM_M038_B_P> UnitCode { get; set; }  //UOM List
            public List<QMS_M024Flip> TaskList { get; set; }  //Task List
            public List<ADM_M022_P> ItemService { get; set; }  //Item services
            public List<QMS_M011> FormulaCode { get; set; }  //Formula Codes
            public List<QMS_M017> EnvCond { get; set; }  //Env Conditions
            public List<QMS_M030_I_P> InspectionChar { get; set; }  //Master Inspection Characteristics

            public List<QMS_M009_B> TestTypeEntity { get; set; }    //test types
            public List<QMS_M009_C> TestHeaderEntity { get; set; } //Benchmark headers
            public List<QMS_M009_D> HeaderValueEntity { get; set; } // Bench header values
            public List<QMS_M009_E> MasterHeaderEntity { get; set; } // master headers
            public List<QMS_M009_E> InstHeaderEntity { get; set; }  // instrument headers
            public List<QMS_M009_F> ParameterEntity { get; set; }   //parameter codes
            public List<QMS_M009_G> ParameterValueEntity { get; set; }  //parameter values
            public List<QMS_M009_H> TaskListEntity { get; set; }  //Task List
            public List<QMS_M009_J> MasterValueEntity { get; set; }  //Default Master Readings
            public List<QMS_M009_K> EnvConditionEntity { get; set; }  //Default Environmental Conditions
            public List<QMS_M009_A> MasterEntity { get; set; }  //Test identification
            public List<COM_T003> Attachment { get; set; }
        }
    }
}
