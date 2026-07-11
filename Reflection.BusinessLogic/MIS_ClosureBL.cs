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
   
    public class MIS_ClosureBL : ReflectionBusinessLogic
    {
        private static string connectionString;

        MultipleContextMISClosure MC = new MultipleContextMISClosure();
     
        private List<MIS_ClosureRptEntity> _dsReport;
        public List<MIS_ClosureRptEntity> dsReport
        {
            get { return _dsReport; }
            set
            {
                _dsReport = value;
            }
        }
        public MIS_ClosureBL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public MIS_ClosureBL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string GetData(string strType, string QueryOption, int intValue, string strValue)
        {
            MultipleContextMISClosure MC = new MultipleContextMISClosure();
            string RequestOption = strType.Split('!')[0];
            string strReturnData = "";
            try
            {             
                    if (RequestOption == "LoadInitialData" || RequestOption == "Report")
                    {
                        using (IDbConnection conn = new SqlConnection(connectionString))
                        {
                            var reader = conn.QueryMultiple("MIS_Closure", new { @request = strType }, commandType: CommandType.StoredProcedure);

                            if (RequestOption == "LoadInitialData")
                            {
                                var partyData = reader.Read<ADM_M028_P>().ToList();
                                MC.partyDetails = partyData.ToList();

                                var EmployeeData = reader.Read<ADM_M024_P>().ToList();
                                MC.Employee = EmployeeData.ToList();
                                strReturnData = ObjectSerializationService.ObjectToXML(MC);

                                var PartytypeData = reader.Read<ADM_M028_B_P>().ToList();
                                MC.PartyType = PartytypeData.ToList();
                                strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            
                            }
                            else if (RequestOption == "Report")
                            {
                                var RptMIS_Closure = reader.Read<MIS_ClosureRptEntity>().ToList();
                                dsReport = RptMIS_Closure.ToList();
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

        public class MultipleContextMISClosure
        {
            public List<ADM_M028_P> partyDetails { get; set; }
            public List<ADM_M024_P> Employee { get; set; }
            public List<ADM_M028_B_P> PartyType { get; set; }
            public List<ADM_M001_A_P> SalesOrg { get; set; }
            public List<ADM_M001_H_P> SalesGroup { get; set; }
        }
    }
}
