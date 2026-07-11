using Dapper;
using Reflection.EF;
using Reflection.EF.Communication;
using Reflection.EF.QMS;
using Reflection.EF.ReflectionSystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    public class QMS_T002BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        QMS_T002 MasterEntity = new QMS_T002();
        MultipleContext_QMS_T002 MC = new MultipleContext_QMS_T002();

        public QMS_T002BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public QMS_T002BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_T002Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var dataGrid = reader.Read<QMS_T002Flip>().ToList();
                    MC.DocumentDataFlipGrid = dataGrid.ToList();

                    var master = reader.Read<QMS_T002>().ToList();
                    MC.MasterEntity = master.ToList();
                    if (MC.MasterEntity.Count > 0)
                    {
                        MasterEntity = MC.MasterEntity[0];
                    }

                    var Acc = reader.Read<QMS_T002_A>().ToList();
                    MC.ItemEntity = Acc.ToList();

                    var parameter = reader.Read<QMS_T002_D>().ToList();
                    MC.ParameterEntity = parameter.ToList();

                    var request = reader.Read<QMS_T002_B>().ToList();
                    MC.InstrumentEntity = request.ToList();

                    var tests = reader.Read<QMS_T002_C>().ToList();
                    MC.TestEntity = tests.ToList();

                    MasterEntity.XmlDataDocument_QMS_T002_A = ObjectSerializationService.ObjectToXML(MC.ItemEntity);
                    MasterEntity.XmlDataDocument_QMS_T002_B = ObjectSerializationService.ObjectToXML(MC.InstrumentEntity);
                    MasterEntity.XmlDataDocument_QMS_T002_C = ObjectSerializationService.ObjectToXML(MC.TestEntity);
                    MasterEntity.XmlDataDocument_QMS_T002_D = ObjectSerializationService.ObjectToXML(MC.ParameterEntity);
                    MasterEntity.XmlDataDocument_QMS_T002Flip = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
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
                    var reader = conn.QueryMultiple("QMS_T002Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var dataGrid = reader.Read<QMS_T002Flip>().ToList();
                    MC.DocumentDataFlipGrid = dataGrid.ToList();

                    var master = reader.Read<QMS_T002>().ToList();
                    MC.MasterEntity = master.ToList();
                    if (MC.MasterEntity.Count > 0)
                    {
                        MasterEntity = MC.MasterEntity[0];
                    }

                    var Acc = reader.Read<QMS_T002_A>().ToList();
                    MC.ItemEntity = Acc.ToList();

                    var parameter = reader.Read<QMS_T002_D>().ToList();
                    MC.ParameterEntity = parameter.ToList();

                    var request = reader.Read<QMS_T002_B>().ToList();
                    MC.InstrumentEntity = request.ToList();

                    var tests = reader.Read<QMS_T002_C>().ToList();
                    MC.TestEntity = tests.ToList();

                    MasterEntity.XmlDataDocument_QMS_T002_A = ObjectSerializationService.ObjectToXML(MC.ItemEntity);
                    MasterEntity.XmlDataDocument_QMS_T002_B = ObjectSerializationService.ObjectToXML(MC.InstrumentEntity);
                    MasterEntity.XmlDataDocument_QMS_T002_C = ObjectSerializationService.ObjectToXML(MC.TestEntity);
                    MasterEntity.XmlDataDocument_QMS_T002_D = ObjectSerializationService.ObjectToXML(MC.ParameterEntity);
                    MasterEntity.XmlDataDocument_QMS_T002Flip = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
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
                    #region For QMS Dues
                    if (RequestOption == "LoadInitialDataForDue" || RequestOption == "LoadFromDateToDateForDue")
                    {
                        var reader = conn.QueryMultiple("QMS_DUELoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LoadInitialDataForDue")
                        {
                            var docinfo = reader.Read<SYS_M002>().ToList();
                            MC.DocTypeInfo = docinfo.ToList();

                            var datagrid = reader.Read<QMS_T002>().ToList();
                            MC.DocumentDataGrid = datagrid.ToList();
                        }
                        else if (RequestOption == "LoadFromDateToDateForDue")
                        {
                            var datagrid = reader.Read<QMS_T002>().ToList();
                            MC.DocumentDataGrid = datagrid.ToList();
                        }
                    }

                    #endregion

                    else
                    {
                        var reader = conn.QueryMultiple("QMS_T002LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure, commandTimeout: 600);

                        if (RequestOption == "LoadInitialData")
                        {
                            var docinfo = reader.Read<SYS_M002>().ToList();
                            MC.DocTypeInfo = docinfo.ToList();

                            var datagrid = reader.Read<QMS_T002Flip>().ToList();
                            MC.DocumentDataFlipGrid = datagrid.ToList();

                            var RefDocData = reader.Read<SEL_T003_PUR_T005_RefDoc>().ToList();
                            MC.RefDocData = RefDocData.ToList();

                            var lab = reader.Read<ADM_M003_B_P>().ToList();
                            MC.Laboratory = lab.ToList();

                            var inst = reader.Read<QMS_M003_P>().ToList();
                            MC.Instrument = inst.ToList();

                            var testCode = reader.Read<QMS_M009Flip>().ToList();
                            MC.TestCode = testCode.ToList();

                            var PartyMaster = reader.Read<ADM_M028_P>().ToList();
                            MC.PartyMaster = PartyMaster.ToList();

                            var acce = reader.Read<ADM_M022_PopUp_Inst>().ToList();
                            MC.AccItem = acce.ToList();

                            var scope = reader.Read<QMS_M004_P>().ToList();
                            MC.AccScope = scope.ToList();

                            var employee = reader.Read<ADM_M024_P>().ToList();
                            MC.Employees = employee.ToList();

                            var parameter = reader.Read<QMS_M009_F>().ToList();
                            MC.AdditionalParameter = parameter.ToList();

                            var paravalue = reader.Read<QMS_M009_F>().ToList();
                            MC.ParameterValue = paravalue.ToList();

                            var UOM = reader.Read<ADM_M038_B_P>().ToList();
                            MC.UnitCode = UOM.ToList();

                        }
                        else if (RequestOption == "LoadDocumentByDocumentNumber")
                        {
                            var Mastr = reader.Read<QMS_T002>().ToList();
                            MC.MasterEntity = Mastr.ToList();

                            var item = reader.Read<QMS_T002_A>().ToList();
                            MC.ItemEntity = item.ToList();

                            var Attachment = reader.Read<COM_T003>().ToList();
                            MC.Attachment = Attachment.ToList();

                            var parameter = reader.Read<QMS_T002_D>().ToList();
                            MC.ParameterEntity = parameter.ToList();

                            var request = reader.Read<QMS_T002_B>().ToList();
                            MC.InstrumentEntity = request.ToList();

                            var tests = reader.Read<QMS_T002_C>().ToList();
                            MC.TestEntity = tests.ToList();
                        }
                        if (RequestOption == "LoadItemDetails")
                        {
                            var instcode = reader.Read<QMS_M003_P>().ToList();
                            MC.Instrument = instcode.ToList();
                        }

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
        public class MultipleContext_QMS_T002
        {
            public List<SYS_M002> DocTypeInfo { get; set; }
            public List<QMS_T002> DocumentDataGrid { get; set; } //DataGridCollection used for calibration due  
            public List<QMS_T002Flip> DocumentDataFlipGrid { get; set; } //DataGridCollection 
            public List<SEL_T003_PUR_T005_RefDoc> RefDocData { get; set; }
            public List<ADM_M003_B_P> Laboratory { get; set; }
            public List<QMS_M009Flip> TestCode { get; set; }
            public List<ADM_M028_P> PartyMaster { get; set; }
            public List<ADM_M022_PopUp_Inst> AccItem { get; set; }
            public List<QMS_M004_P> AccScope { get; set; }
            public List<ADM_M024_P> Employees { get; set; }
            public List<QMS_M003_P> Instrument { get; set; }
            public List<COM_T003> Attachment { get; set; }
            public List<QMS_M009_F> AdditionalParameter { get; set; }    // Additional Parameter Collection 
            public List<QMS_M009_F> ParameterValue { get; set; }    // ParameterValue Collection 
            public List<ADM_M038_B_P> UnitCode { get; set; }  //UOM List

            public List<QMS_T002> MasterEntity { get; set; }
            public List<QMS_T002_A> ItemEntity { get; set; }
            public List<QMS_T002_B> InstrumentEntity { get; set; }
            public List<QMS_T002_C> TestEntity { get; set; }
            public List<QMS_T002_D> ParameterEntity { get; set; }
        }
    }
}
