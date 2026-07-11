using Dapper;
using Reflection.EF;
using Reflection.EF.HRMS.Production;
using Reflection.EF.QMS;
using Reflection.EF.ReflectionSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    public class QMS_M030_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        QMS_M030 masterEntity = new QMS_M030();
        MultipleContext_QMS_M030 MC = new MultipleContext_QMS_M030();

        public QMS_M030_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public QMS_M030_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            try
            {
                string RequestOption = RequestValue.Split('!')[0];
                string strReturnData = "";

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M030_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {

                        var BackFlip = reader.Read<QMS_M030_Flip>().ToList();
                        MC.BackFlipData = BackFlip.ToList();

                        var ItemData = reader.Read<ADM_M022_P>().ToList();
                        MC.ItemMaster = ItemData.ToList();

                        var Inspmethod = reader.Read<QMS_M030_G_P>().ToList();
                        MC.InspMethod = Inspmethod.ToList();

                        var sampleProcedure = reader.Read<QMS_M034_P>().ToList();
                        MC.SampleProcedure = sampleProcedure.ToList();

                        var UnitData = reader.Read<ADM_M038_B_P>().ToList();
                        MC.UnitMaster = UnitData.ToList();

                        var Qualification = reader.Read<QMS_M022_P>().ToList();
                        MC.QualiMaster = Qualification.ToList();

                        var workCenter = reader.Read<PPC_M001_P>().ToList();
                        MC.WorkCenter = workCenter.ToList();

                        var BOM = reader.Read<ENG_T001_P>().ToList();
                        MC.BOMData = BOM.ToList();

                        var MicData = reader.Read<QMS_M030_I_P>().ToList();
                        MC.MICMaster = MicData.ToList();

                        MC.ControlKeyMaster = reader.Read<SYS_M051>().ToList();

                        var UsageData = reader.Read<SYS_M048>().ToList();
                        MC.UsageMaster = UsageData.ToList();

                        var Paratype = reader.Read<QMS_M032_P>().ToList();
                        MC.ParaTypeMaster = Paratype.ToList();

                        var GroupSet = reader.Read<Group_Set>().ToList();
                        MC.GroupSetMaster = GroupSet.ToList();

                        MC.EmployeeList = reader.Read<ADM_M024_P>().ToList();
                        MC.OperationList = reader.Read<PPC_M002>().ToList();

                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var MasterData = reader.Read<QMS_M030>().ToList();
                        MC.MasterEntity = MasterData.ToList();

                        var AssignData = reader.Read<QMS_M030_A>().ToList();
                        MC.AssignmentEntity = AssignData.ToList();

                        var OperationData = reader.Read<QMS_M030_B>().ToList();
                        MC.OperationEntity = OperationData.ToList();

                        var InspChar = reader.Read<QMS_M030_C>().ToList();
                        MC.InspCharEntity = InspChar.ToList();

                        var Selectedset = reader.Read<QMS_M030_D>().ToList();
                        MC.SelectedSetEntity = Selectedset.ToList();
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

        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M030_Insert", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    var BackFlip = reader.Read<QMS_M030_Flip>().ToList();
                    MC.BackFlipData = BackFlip.ToList();

                    var masterData = reader.Read<QMS_M030>().ToList();
                    MC.MasterEntity = masterData.ToList();

                    var AssignData = reader.Read<QMS_M030_A>().ToList();
                    MC.AssignmentEntity = AssignData.ToList();

                    var OperationData = reader.Read<QMS_M030_B>().ToList();
                    MC.OperationEntity = OperationData.ToList();

                    var InspChar = reader.Read<QMS_M030_C>().ToList();
                    MC.InspCharEntity = InspChar.ToList();

                    var Selectedset = reader.Read<QMS_M030_D>().ToList();
                    MC.SelectedSetEntity = Selectedset.ToList();

                    masterEntity = MC.MasterEntity[0];
                    masterEntity.XmlDataDocument_QMS_M030_Flip = ObjectSerializationService.ObjectToXML(MC.BackFlipData);
                    masterEntity.XmlDataDocument_QMS_M030_A = ObjectSerializationService.ObjectToXML(MC.AssignmentEntity);
                    masterEntity.XmlDataDocument_QMS_M030_B = ObjectSerializationService.ObjectToXML(MC.OperationEntity);
                    masterEntity.XmlDataDocument_QMS_M030_C = ObjectSerializationService.ObjectToXML(MC.InspCharEntity);
                    masterEntity.XmlDataDocument_QMS_M030_D = ObjectSerializationService.ObjectToXML(MC.SelectedSetEntity);
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(masterEntity);
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
                    var reader = conn.QueryMultiple("QMS_M030_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var BackFlip = reader.Read<QMS_M030_Flip>().ToList();
                    MC.BackFlipData = BackFlip.ToList();

                    var masterData = reader.Read<QMS_M030>().ToList();
                    MC.MasterEntity = masterData.ToList();

                    var AssignData = reader.Read<QMS_M030_A>().ToList();
                    MC.AssignmentEntity = AssignData.ToList();

                    var OperationData = reader.Read<QMS_M030_B>().ToList();
                    MC.OperationEntity = OperationData.ToList();

                    var InspChar = reader.Read<QMS_M030_C>().ToList();
                    MC.InspCharEntity = InspChar.ToList();

                    var Selectedset = reader.Read<QMS_M030_D>().ToList();
                    MC.SelectedSetEntity = Selectedset.ToList();

                    if (MC.MasterEntity.Count > 0)
                    {
                        masterEntity = MC.MasterEntity[0];
                    }
                    masterEntity.XmlDataDocument_QMS_M030_Flip = ObjectSerializationService.ObjectToXML(MC.BackFlipData);
                    masterEntity.XmlDataDocument_QMS_M030_A = ObjectSerializationService.ObjectToXML(MC.AssignmentEntity);
                    masterEntity.XmlDataDocument_QMS_M030_B = ObjectSerializationService.ObjectToXML(MC.OperationEntity);
                    masterEntity.XmlDataDocument_QMS_M030_C = ObjectSerializationService.ObjectToXML(MC.InspCharEntity);
                    masterEntity.XmlDataDocument_QMS_M030_D = ObjectSerializationService.ObjectToXML(MC.SelectedSetEntity);
                }
                strReturnData = ObjectSerializationService.ObjectToXML(masterEntity);
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

    public class MultipleContext_QMS_M030
    {
        public List<QMS_M030_Flip> BackFlipData { get; set; }
        public List<ADM_M022_P> ItemMaster { get; set; }
        public List<QMS_M030_G_P> InspMethod { get; set; }
        public List<QMS_M034_P> SampleProcedure { get; set; }
        public List<ADM_M038_B_P> UnitMaster { get; set; }
        public List<QMS_M022_P> QualiMaster { get; set; }
        public List<PPC_M001_P> WorkCenter { get; set; }
        public List<ENG_T001_P> BOMData { get; set; }
        public List<QMS_M030> MasterEntity { get; set; }
        public List<QMS_M030_A> AssignmentEntity { get; set; }
        public List<QMS_M030_B> OperationEntity { get; set; }
        public List<QMS_M030_C> InspCharEntity { get; set; }
        public List<QMS_M030_D> SelectedSetEntity { get; set; }
        public List<QMS_M030_I_P> MICMaster { get; set; }
        public List<SYS_M051> ControlKeyMaster { get; set; }
        public List<SYS_M048> UsageMaster { get; set; }
        public List<QMS_M032_P> ParaTypeMaster { get; set; }
        public List<Group_Set> GroupSetMaster { get; set; }
        public List<ADM_M024_P> EmployeeList { get; set; }
        public List<PPC_M002> OperationList { get; set; }

    }
}
