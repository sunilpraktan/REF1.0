using Dapper;
using Reflection.EF;
using Reflection.EF.CRM.ReportEntityCRM;
using Reflection.EF.QMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    public class MIS_QMS_CTBL : ReflectionBusinessLogic
    {
        private static string connectionString;
        public MIS_QMS_CTBL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public MIS_QMS_CTBL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        MultipleContextMIS_QMS_CT MC = new MultipleContextMIS_QMS_CT();

        private List<RptMISInspection> _dsReport;
        public List<RptMISInspection> dsReport
        {
            get { return _dsReport; }
            set
            {
                _dsReport = value;
            }
        }
        public string GetData(string Request, string QueryOption, int intValue, string strValue)
        {
            string RequestOption = Request.Split('!')[0];
            string strReturnData = "";
            try
            {
                if (RequestOption == "LoadInitialData" || RequestOption == "Report")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("MIS_QMS_CT", new { @request = Request }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LoadInitialData")
                        {
                            var insp = reader.Read<QMS_M013_P>().ToList();
                            MC.InspType = insp.ToList();

                            var test = reader.Read<QMS_M009Flip>().ToList();
                            MC.TestCode = test.ToList();

                            var inst = reader.Read<QMS_M003_P>().ToList();
                            MC.Instrument = inst.ToList();

                            var partyData = reader.Read<ADM_M028_P>().ToList();
                            MC.PartyMaster = partyData.ToList();
                        
                            var Lab = reader.Read<ADM_M003_B_P>().ToList();
                            MC.Laboratory = Lab.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "Report")
                        {
                            var RptMIS_QMS_CT = reader.Read<RptMISInspection>().ToList();
                            dsReport = RptMIS_QMS_CT.ToList();

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
        public class MultipleContextMIS_QMS_CT
        {
            public List<ADM_M003_B_P> Laboratory { get; set; }
            public List<QMS_M009Flip> TestCode { get; set; }
            public List<ADM_M028_P> PartyMaster { get; set; }
            public List<QMS_M003_P> Instrument { get; set; }
            public List<QMS_M013_P> InspType { get; set; }  //Insp type Master
            public List<RptMISInspection> RptMISInspectionList { get; set; }
        }
    }
}
