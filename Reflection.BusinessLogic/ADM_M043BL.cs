using Reflection.EF;
using Reflection.EF.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
namespace Reflection.BusinessLogic
{
    class ADM_M043BL : ReflectionBusinessLogic
    {
       
        private static string connectionString;
        ADM_M043 aDM_M043;
        public ADM_M043BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }

        public ADM_M043BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                MultipleContext_ADM_M043 MC_ADM_M043 = new MultipleContext_ADM_M043();
                aDM_M043 = new ADM_M043();

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M043Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var workflowtemp =reader.Read<ADM_M043>().ToList();
                    MC_ADM_M043.workflowlist = workflowtemp.ToList();


                    var detaildata = reader.Read<ADM_M043_A>().ToList();
                    MC_ADM_M043.detailslist = detaildata.ToList();

                    aDM_M043 = MC_ADM_M043.workflowlist[0];
                    aDM_M043.XmlDataDocument_ADM_M043_A = ObjectSerializationService.ObjectToXML(MC_ADM_M043.detailslist);
                }

                string strReturnData = ObjectSerializationService.ObjectToXML(aDM_M043);
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
                MultipleContext_ADM_M043 MC_ADM_M043 = new MultipleContext_ADM_M043();
                aDM_M043 = new ADM_M043();
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M043Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var workflowtemp = reader.Read<ADM_M043>().ToList();
                    MC_ADM_M043.workflowlist = workflowtemp.ToList();


                    var detaildata = reader.Read<ADM_M043_A>().ToList();
                    MC_ADM_M043.detailslist = detaildata.ToList();

                    aDM_M043 = MC_ADM_M043.workflowlist[0];
                    aDM_M043.XmlDataDocument_ADM_M043_A = ObjectSerializationService.ObjectToXML(MC_ADM_M043.detailslist);
                }

                string strReturnData = ObjectSerializationService.ObjectToXML(aDM_M043);
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
                    int intOut = conn.Execute("ADM_M043Delete", new { @workflow_id = Request }, commandType: CommandType.StoredProcedure);
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
        public string GetData(string RequestValue, int intValue, string strValue)
        {
            try
            {
                MultipleContext_ADM_M043 MC_ADM_M043 = new MultipleContext_ADM_M043();
                string RequestOption = RequestValue.Split('!')[0];
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M043LoadAll", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_INI")
                    {
                        var workflowmaster = reader.Read<ADM_M043>().ToList();
                        MC_ADM_M043.workflowlist = workflowmaster.ToList();

                        var companymaster = reader.Read<ADM_M002_P>().ToList();
                        MC_ADM_M043.companylist = companymaster.ToList();

                        var plantmaster = reader.Read<ADM_M003_P>().ToList();
                        MC_ADM_M043.plantlist = plantmaster.ToList();

                        var transactionmaster = reader.Read<ADM_M008B_P>().ToList();
                        MC_ADM_M043.transactionlist = transactionmaster.ToList();

                        var categorymaster = reader.Read<SYS_M001_P>().ToList();
                        MC_ADM_M043.categorymaster = categorymaster.ToList();

                        var categorytypemaster = reader.Read<SYS_M002_P>().ToList();
                        MC_ADM_M043.categoryTypemaster = categorytypemaster.ToList();

                        var employeemaster = reader.Read<ADM_M024_P>().ToList();
                        MC_ADM_M043.employeelist = employeemaster.ToList();

                        var uommaster = reader.Read<ADM_M038_B_P>().ToList();
                        MC_ADM_M043.uomlist = uommaster.ToList();

                        var Department = reader.Read<ADM_M025_P>().ToList();
                        MC_ADM_M043.Departments = Department.ToList();

                        var OrgDetails = reader.Read<ORG_Data>().ToList();
                        MC_ADM_M043.OrgData = OrgDetails.ToList();
                    }
                    else if (RequestOption == "LOAD_DOC")
                    {
                        var detail = reader.Read<ADM_M043_A>().ToList();
                        MC_ADM_M043.detailslist = detail.ToList();
                    }

                }
                string strReturnData = ObjectSerializationService.ObjectToXML(MC_ADM_M043);
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
    public class MultipleContext_ADM_M043
    {
        public List<ADM_M002_P> companylist { get; set; }
        public List<ADM_M003_P> plantlist { get; set; }
        public List<ADM_M008B_P> transactionlist { get; set; }
        public List<SYS_M001_P> categorymaster { get; set; }
        public List<SYS_M002_P> categoryTypemaster { get; set; }
        public List<ADM_M024_P> employeelist { get; set; }
        public List<ADM_M038_B_P> uomlist { get; set; }
        public List<ADM_M043> workflowlist { get; set; }
        public List<ADM_M043_A> detailslist { get; set; }
        public List<NotificationData> NotificationData { get; set; }
        public List<ADM_M025_P> Departments { get; set; }
        public List<ORG_Data> OrgData { get; set; }
    }
}
