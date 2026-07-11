using Dapper;
using Reflection.BusinessEntity.SCM;
using Reflection.EF;
using Reflection.EF.SCM.ReportEntitySCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    public class MIS_SCM_Report5BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        public MIS_SCM_Report5BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public MIS_SCM_Report5BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        MultipleContextMISReports4 MC = new MultipleContextMISReports4();
        private List<MIS_SCM_Rpt> _dsReport;
        public List<MIS_SCM_Rpt> dsReport
        {
            get { return _dsReport; }
            set
            {
                _dsReport = value;
            }
        }
        public string GetData(string strType, string QueryOption, int intValue, string strValue)
        {
            MultipleContextMISReports4 MC = new MultipleContextMISReports4();
            string RequestOption = strType.Split('!')[0];
            string strReturnData = "";
            try
            {

                if (RequestOption == "LoadInitialData" || RequestOption == "Report")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("MIS_SCM_Report5", new { @request = strType }, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LoadInitialData")
                        {
                            var EmployeeMaster = reader.Read<ADM_M024_P>().ToList();
                            MC.EmployeeList = EmployeeMaster.ToList();

                            var partyData = reader.Read<ADM_M028_P>().ToList();
                            MC.partyDetails = partyData.ToList();

                            var ItemData = reader.Read<ADM_M022_P>().ToList();
                            MC.ItemDetails = ItemData.ToList();

                            var UnitList = reader.Read<ADM_M038_B_P>().ToList();
                            MC.UnitDetails = UnitList.ToList();

                            var DocCat = reader.Read<SYS_M010_P>().ToList();
                            MC.DocCatDetails = DocCat.ToList();

                            var DeliveryTy = reader.Read<SYS_M005_P>().ToList();
                            MC.DeliveryTyList = DeliveryTy.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);

                        }

                        else if (RequestOption == "Report")
                        {
                            var RptMIS_SCM = reader.Read<MIS_SCM_Rpt>().ToList();
                            dsReport = RptMIS_SCM.ToList();
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

        public class MultipleContextMISReports4
        {
            public List<ADM_M024_P> EmployeeList { get; set; }
            public List<ADM_M028_P> partyDetails { get; set; }
            public List<ADM_M022_P> ItemDetails { get; set; }
            public List<ADM_M038_B_P> UnitDetails { get; set; }
            public List<SYS_M010_P> DocCatDetails { get; set; }
            public List<SYS_M005_P> DeliveryTyList { get; set; }
            public List<MIS_SCM_Rpt> MIS_SCM_RptList { get; set; }

            public List<ADM_M028_B_P> PartyType;

        }
    }
}
