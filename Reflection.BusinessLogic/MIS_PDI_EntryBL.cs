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
    public class MIS_PDI_EntryBL : ReflectionBusinessLogic
    {
        MultipleContext_MIS_PDI_Entry MC = new MultipleContext_MIS_PDI_Entry();
        private static string ConnectionString;
        public MIS_PDI_EntryBL(string BusinessEntity)
        {
            ConnectionString = base.ReflectionConnectionString;
        }
        public MIS_PDI_EntryBL()
        {
            ConnectionString = base.ReflectionConnectionString;
        }

        private List<Rpt_MIS_PDI_Entry> _dsReport;
        public List<Rpt_MIS_PDI_Entry> dsReport
        {
            get { return _dsReport; }
            set
            {
                _dsReport = value;
            }
        }

        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            MultipleContext_MIS_PDI_Entry MC = new MultipleContext_MIS_PDI_Entry();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(ConnectionString))
                {
                    var reader = conn.QueryMultiple("MIS_PDI_Entry", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData" || RequestOption == "Report")
                    {

                        if (RequestOption == "LoadInitialData")
                        {

                            var PartyList = reader.Read<ADM_M028_P>().ToList();
                            MC.PartyMaster = PartyList.ToList();

                            var MachineList = reader.Read<ZADM_M013_P>().ToList();
                            MC.machineDetails = MachineList.ToList();

                            var ILDTyList = reader.Read<ZADM_M007_P>().ToList();
                            MC.ILDDetails = ILDTyList.ToList();

                            var InkList = reader.Read<ZADM_M006_P>().ToList();
                            MC.InkDetails = InkList.ToList();

                            var ShiftList = reader.Read<ADM_M042_P>().ToList();
                            MC.ShiftDetails = ShiftList.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);

                        }

                        else if (RequestOption == "Report")
                        {
                            var rptPDIList = reader.Read<Rpt_MIS_PDI_Entry>().ToList();
                            dsReport = rptPDIList.ToList();

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
        public class MultipleContext_MIS_PDI_Entry
        {
            public List<ADM_M028_P> PartyMaster { get; set; }
            public List<ZADM_M013_P> machineDetails { get; set; }
            public List<ZADM_M007_P> ILDDetails { get; set; }
            public List<ZADM_M006_P> InkDetails { get; set; }
            public List<ADM_M042_P> ShiftDetails { get; set; }
            public List<Rpt_MIS_PDI_Entry> RptPDIEntryList { get; set; }

        }
    }
}

