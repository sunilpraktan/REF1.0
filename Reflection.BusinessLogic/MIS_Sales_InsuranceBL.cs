using Reflection.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Reflection.EF.CRM.ReportEntityCRM;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class MIS_Sales_InsuranceBL : ReflectionBusinessLogic
    {
        MultipleContext_MIS_Sales_InsuranceBL MC = new MultipleContext_MIS_Sales_InsuranceBL();
        private static string ConnectionString;
        public MIS_Sales_InsuranceBL(string BusinessEntity)
        {
            ConnectionString = base.ReflectionConnectionString;
        }
        public MIS_Sales_InsuranceBL()
        {
            ConnectionString = base.ReflectionConnectionString;
        }

        private List<MIS_InsuranceRptEntity> _dsReport;
        public List<MIS_InsuranceRptEntity> dsReport
        {
            get { return _dsReport; }
            set
            {
                _dsReport = value;
            }
        }

        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {

            try
            {
                MultipleContext_MIS_Sales_InsuranceBL MC = new MultipleContext_MIS_Sales_InsuranceBL();
                string RequestOption = RequestValue.Split('!')[0];
                string strReturnData = "";
                using (IDbConnection conn = new SqlConnection(ConnectionString))
                {
                    var reader = conn.QueryMultiple("MIS_Sales_Insurance", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);
                    if (RequestOption == "LoadInitialData" || RequestOption == "Report")
                    {

                            if (RequestOption == "LoadInitialData")
                            {

                                var UnitList = reader.Read<ADM_M038_B_P>().ToList();
                                MC.UnitDetails = UnitList.ToList();

                                var FinYearList = reader.Read<ACC_M001A_P>().ToList();
                                MC.FinYear = FinYearList.ToList();

                                var PostPeriodList = reader.Read<ACC_M001A_P>().ToList();
                                MC.PostPeriod = PostPeriodList.ToList();

                                strReturnData = ObjectSerializationService.ObjectToXML(MC);

                            }

                            else if (RequestOption == "Report")
                            {
                                var rptDataList = reader.Read<MIS_InsuranceRptEntity>().ToList();
                                dsReport = rptDataList.ToList();
                                strReturnData = ObjectSerializationService.ObjectToXML(dsReport);
                            }


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


        public class MultipleContext_MIS_Sales_InsuranceBL
        {
            public List<ADM_M038_B_P> UnitDetails { get; set; }
            public List<ACC_M001A_P> FinYear { get; set; }
            public List<ACC_M001A_P> PostPeriod { get; set; }
            public List<MIS_InsuranceRptEntity> FinReportData { get; set; }

        }
    }
}