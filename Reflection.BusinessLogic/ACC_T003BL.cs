using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Reflection.EF;
using Reflection.EF.Finance;
using System.Collections.ObjectModel;
using Reflection.EF.Communication;
using Reflection.EF.ReflectionSystem;
using Reflection.EF.Admin;
using Reflection.BusinessLogic;

namespace Reflection.BusinessLogic
{
   public class ACC_T003BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        MultipleContext_ACC_T003 MC = new MultipleContext_ACC_T003();
        MultipleContext_ACC_T003 MCTemp = new MultipleContext_ACC_T003();
        ACC_T003 masterEntity = new ACC_T003();
        public ACC_T003BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ACC_T003BL()
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
                    var reader = conn.QueryMultiple("ACC_T003Insert", new { @Request = Request },commandTimeout:600, commandType: CommandType.StoredProcedure);

                    var flipGridData = reader.Read<ACC_T003_Flip>().ToList();
                    MC.DocumentDataFlipGrid = flipGridData.ToList();

                    var masterData = reader.Read<ACC_T003>().ToList();
                    MC.MasterEntity = masterData.ToList();

                    var itemData = reader.Read<ACC_T003_A>().ToList();
                    MC.ItemsEntity = itemData.ToList();

                    var employeeData = reader.Read<ACC_T003_C>().ToList();
                    MC.Employee = employeeData.ToList();

                    var workOrderData = reader.Read<ACC_T003_D>().ToList();
                    MC.WorkOrder = workOrderData.ToList();

                    var TransportData = reader.Read<ACC_T003_E>().ToList();
                    MC.Transport = TransportData.ToList();

                    var advanceData = reader.Read<ACC_T003_F>().ToList();
                    MC.Advance = advanceData.ToList();

                    var comInvData = reader.Read<ACC_T003_G>().ToList();
                    MC.ComInvoice = comInvData.ToList();

                    var approvaldata = reader.Read<Approval>().ToList();
                    MC.ApprovalData = approvaldata.ToList();

                    masterEntity = MC.MasterEntity[0];
                    masterEntity.XmlDataDocument_ACC_T003_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                    masterEntity.XmlDataDocument_ACC_T003_C = ObjectSerializationService.ObjectToXML(MC.Employee);
                    masterEntity.XmlDataDocument_ACC_T003_D = ObjectSerializationService.ObjectToXML(MC.WorkOrder);
                    masterEntity.XmlDataDocument_ACC_T003_E = ObjectSerializationService.ObjectToXML(MC.Transport);
                    masterEntity.XmlDataDocument_ACC_T003_F = ObjectSerializationService.ObjectToXML(MC.Advance);
                    masterEntity.XmlDataDocument_ACC_T003_G = ObjectSerializationService.ObjectToXML(MC.ComInvoice);
                    masterEntity.XmlDataDocument_Approval = ObjectSerializationService.ObjectToXML(MC.ApprovalData);
                    masterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
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

        public string Update(string Request)
        {
            try
            {
                string strReturnData = "";
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ACC_T003Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var flipGridData = reader.Read<ACC_T003_Flip>().ToList();
                    MC.DocumentDataFlipGrid = flipGridData.ToList();

                    var masterData = reader.Read<ACC_T003>().ToList();
                    MC.MasterEntity = masterData.ToList();

                    if (MC.MasterEntity.Count > 0)
                    {
                        masterEntity = MC.MasterEntity[0];
                    }
                    

                    var itemData = reader.Read<ACC_T003_A>().ToList();
                    MC.ItemsEntity = itemData.ToList();

                    var employeeData = reader.Read<ACC_T003_C>().ToList();
                    MC.Employee = employeeData.ToList();

                    var workOrderData = reader.Read<ACC_T003_D>().ToList();
                    MC.WorkOrder = workOrderData.ToList();

                    var TransportData = reader.Read<ACC_T003_E>().ToList();
                    MC.Transport = TransportData.ToList();

                    var advanceData = reader.Read<ACC_T003_F>().ToList();
                    MC.Advance = advanceData.ToList();

                    var comInvData = reader.Read<ACC_T003_G>().ToList();
                    MC.ComInvoice = comInvData.ToList();

                    var approvaldata = reader.Read<Approval>().ToList();
                    MC.ApprovalData = approvaldata.ToList();

                    masterEntity.XmlDataDocument_ACC_T003_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                    masterEntity.XmlDataDocument_ACC_T003_C = ObjectSerializationService.ObjectToXML(MC.Employee);
                    masterEntity.XmlDataDocument_ACC_T003_D = ObjectSerializationService.ObjectToXML(MC.WorkOrder);
                    masterEntity.XmlDataDocument_ACC_T003_E = ObjectSerializationService.ObjectToXML(MC.Transport);
                    masterEntity.XmlDataDocument_ACC_T003_F = ObjectSerializationService.ObjectToXML(MC.Advance);
                    masterEntity.XmlDataDocument_ACC_T003_G = ObjectSerializationService.ObjectToXML(MC.ComInvoice);
                    masterEntity.XmlDataDocument_Approval = ObjectSerializationService.ObjectToXML(MC.ApprovalData);

                    masterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
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

        public string Delete(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("ACC_T003Delete", new { @doc_no = Request }, commandType: CommandType.StoredProcedure);
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
            MultipleContext_ACC_T003 MC = new MultipleContext_ACC_T003();
            MultipleContext_ACC_T003 MCTemp = new MultipleContext_ACC_T003();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ACC_T003LoadAll", new { @Request = RequestValue }, commandTimeout:600,  commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var docinfo = reader.Read<SYS_M002>().ToList();
                        MC.DocTypeInfo = docinfo.ToList();

                        var flipGridData = reader.Read<ACC_T003_Flip>().ToList();
                        MC.DocumentDataFlipGrid = flipGridData.ToList();

                        var customerDetails = reader.Read<ADM_M028_P>().ToList();
                        MC.CustomerDetails = customerDetails.ToList();

                        var empData = reader.Read<ADM_M024_POP>().ToList();
                        MC.EmpDetails = empData.ToList();

                        var headDatagrid = reader.Read<ACC_T003_B_P>().ToList();
                        MC.HeadDetailsForGrid = headDatagrid.ToList();

                        var glcodeDetails = reader.Read<ACC_M003_P>().ToList();
                        MC.GlcodeDetails = glcodeDetails.ToList();

                        var location = reader.Read<ADM_M003_P>().ToList();
                        MC.LocationMaster = location.ToList();

                        var localcon = reader.Read<ACC_T003_P>().ToList();
                        MC.LocalConDetails = localcon.ToList();

                        var vehicle = reader.Read<ACC_T003_H_POPUP>().ToList();
                        MC.VehicleDetails = vehicle.ToList();

                        var driver = reader.Read<ADM_M024_POP>().ToList();
                        MC.DriverDetails = driver.ToList();

                        var SalesOrderList = reader.Read<SEL_T001_P>().ToList();
                        MC.SalesList = SalesOrderList.ToList();

                        var ProjectList = reader.Read<PRO_T001_P>().ToList();
                        MC.Project = ProjectList.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);

                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {

                        var masterData = reader.Read<ACC_T003>().ToList();
                        MCTemp.MasterEntity = masterData.ToList();

                        var itemData = reader.Read<ACC_T003_A>().ToList();
                        MCTemp.ItemsEntity = itemData.ToList();

                        var employeeData = reader.Read<ACC_T003_C>().ToList();
                        MCTemp.Employee = employeeData.ToList();

                        var workOrderData = reader.Read<ACC_T003_D>().ToList();
                        MCTemp.WorkOrder = workOrderData.ToList();

                        var TransportData = reader.Read<ACC_T003_E>().ToList();
                        MCTemp.Transport = TransportData.ToList();

                        var advanceData = reader.Read<ACC_T003_F>().ToList();
                        MCTemp.Advance = advanceData.ToList();

                        var comInvData = reader.Read<ACC_T003_G>().ToList();
                        MCTemp.ComInvoice = comInvData.ToList();

                        var Attachment = reader.Read<COM_T003>().ToList();
                        MCTemp.Attachment = Attachment.ToList();

                        var approvaldata = reader.Read<Approval>().ToList();
                        MCTemp.ApprovalData = approvaldata.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MCTemp);
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

    }
    public class MultipleContext_ACC_T003
    {
        public List<ACC_T003> MasterEntity { get; set; }
        public List<ACC_T003_A> ItemsEntity { get; set; }
        public List<ACC_T003_C> Employee { get; set; }
        public List<ACC_T003_D> WorkOrder { get; set; }
        public List<ACC_T003_E> Transport { get; set; }
        public List<ACC_T003_F> Advance { get; set; }
        public List<ACC_T003_G> ComInvoice { get; set; }
        public List<SYS_M002> DocTypeInfo { get; set; }
        public List<ACC_T003_Flip> DocumentDataFlipGrid { get; set; }
        public List<ADM_M028_P> CustomerDetails { get; set; }
        public List<ADM_M024_POP> EmpDetails { get; set; }
        public List<ACC_T003_B_P> HeadDetailsForGrid { get; set; }
        public List<ACC_M003_P> GlcodeDetails { get; set; }
        public List<ADM_M003_P> LocationMaster { get; set; }
        public List<ADM_M001_A_P> SalesOrg { get; set; }
        public List<ADM_M001_H_P> SalesGroup { get; set; }
        public List<ACC_T003_P> LocalConDetails { get; set; }
        public List<ACC_T003_H_POPUP> VehicleDetails { get; set; }
        public List<ADM_M024_POP> DriverDetails { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<SEL_T001_P> SalesList { get; set; }
        public List<Approval> ApprovalData { get; set; }
        public List<PRO_T001_P> Project { get; set; }
    }
}
