using Reflection.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Reflection.EF.Finance.ReportEntityFinance;
using Dapper;

namespace Reflection.BusinessLogic
{
  
    public class MIS_Finance_ExpenceBL : ReflectionBusinessLogic
    {
        private static string connectionString;
        public MIS_Finance_ExpenceBL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public MIS_Finance_ExpenceBL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        MultipleContextMISExpence MC = new MultipleContextMISExpence();
        private List<MIS_Expence_RptEntity> _dsReport;
        public List<MIS_Expence_RptEntity> dsReport
        {
            get { return _dsReport; }
            set
            {
                _dsReport = value;
            }
        }
        public string GetData(string strType, string QueryOption, int intValue, string strValue)
        {
            MultipleContextMISExpence MC = new MultipleContextMISExpence();
            string RequestOption = strType.Split('!')[0];
            string strReturnData = "";
            try
            {

                if (RequestOption == "LoadInitialData" || RequestOption == "Report")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("MIS_Finance_Expence", new { @request = strType }, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LoadInitialData")
                        {
                            var EmployeeMaster = reader.Read<ADM_M024_P>().ToList();
                            MC.EmployeeList = EmployeeMaster.ToList();

                            var partyData = reader.Read<ADM_M028_P>().ToList();
                            MC.partyDetails = partyData.ToList();

                            var DocType = reader.Read<SYS_M002_P>().ToList();
                            MC.DocTypeDetails = DocType.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);

                        }
                        else if (RequestOption == "Report")
                        {
                            var RptExpence = reader.Read<MIS_Expence_RptEntity>().ToList();
                            dsReport = RptExpence.ToList();
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

        public class MultipleContextMISExpence
        {
            public List<ADM_M024_P> EmployeeList { get; set; }
            public List<ADM_M028_P> partyDetails { get; set; }
            public List<ADM_M022_P> ItemDetails { get; set; }
            public List<SYS_M001_P> DocCatDetails { get; set; }
            public List<SYS_M002_P> DocTypeDetails { get; set; }
            public List<ADM_M001_A_P> SalesOrg { get; set; }
            public List<ADM_M001_H_P> SalesGroup { get; set; }
  
        }
    }
}
