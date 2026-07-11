using Dapper;
using Reflection.EF;
using Reflection.EF.Production.ReportEntityProduction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    public class MIS_QualityBL : ReflectionBusinessLogic
    {
        private static string connectionString;
        public MIS_QualityBL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public MIS_QualityBL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        MultipleContextMIS_Quality MC = new MultipleContextMIS_Quality();
        private List<Rpt_MIS_PDI_Entry> _dsReport;
        public List<Rpt_MIS_PDI_Entry> dsReport
        {
            get { return _dsReport; }
            set
            {
                _dsReport = value;
            }
        }
        public string GetData(string strType, string QueryOption, int intValue, string strValue)
        {

            MultipleContextMIS_Quality MC = new MultipleContextMIS_Quality();
            string RequestOption = strType.Split('!')[0];
            string strReturnData = "";
            try
            {

                if (RequestOption == "LoadInitialData" || RequestOption == "Report")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("MIS_Quality", new { @request = strType }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LoadInitialData")
                        {
                            var MachineMaster = reader.Read<ZADM_M013_P>().ToList();
                            MC.machineDetails = MachineMaster.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);

                        }
                        else if (RequestOption == "Report")
                        {
                            var Rpt_MIS_PDI_Entry = reader.Read<Rpt_MIS_PDI_Entry>().ToList();
                            dsReport = Rpt_MIS_PDI_Entry.ToList();
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

        public class MultipleContextMIS_Quality
        {
            public List<ZADM_M013_P> machineDetails { get; set; }
            public List<Rpt_MIS_PDI_Entry> QualityReport { get; set; }
        }
    }
}
