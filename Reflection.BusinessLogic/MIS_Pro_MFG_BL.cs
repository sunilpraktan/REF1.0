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
   public class MIS_Pro_MFG_BL : ReflectionBusinessLogic
    {
        MultipleContext_MIS_Pro_MFG MC = new MultipleContext_MIS_Pro_MFG();
        private static string ConnectionString;
        public MIS_Pro_MFG_BL(string BusinessEntity)
        {
            ConnectionString = base.ReflectionConnectionString;
        }
        public MIS_Pro_MFG_BL()
        {
            ConnectionString = base.ReflectionConnectionString;
        }

        private List<Rpt_MIS_Pro_MFG> _dsReport;
        public List<Rpt_MIS_Pro_MFG> dsReport
        {
            get { return _dsReport; }
            set
            {
                _dsReport = value;
            }
        }

        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(ConnectionString))
                {
                    var reader = conn.QueryMultiple("MIS_PRO_MFG", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData" || RequestOption == "Report")
                    {
                        if (RequestOption == "LoadInitialData")
                        {
                            var ItemList = reader.Read<ZADM_M010_P>().ToList();
                            MC.ItemDetails = ItemList.ToList();

                            var EmployeeList = reader.Read<ADM_M024_P>().ToList();
                            MC.Employee = EmployeeList.ToList();

                            var UnitList = reader.Read<ADM_M038_B_P>().ToList();
                            MC.UnitDetails = UnitList.ToList();

                            var WireTyList = reader.Read<ZADM_M004_P>().ToList();
                            MC.WireTypeDetails = WireTyList.ToList();

                            var BallTyList = reader.Read<ZADM_M002_P>().ToList();
                            MC.BallTypeDetails = BallTyList.ToList();

                            var ILDTyList = reader.Read<ZADM_M007_P>().ToList();
                            MC.ILDDetails = ILDTyList.ToList();

                            var InkList = reader.Read<ZADM_M006_P>().ToList();
                            MC.InkDetails = InkList.ToList();

                            var TipType = reader.Read<ZADM_M010_P>().ToList();
                            MC.TipTypes = TipType.ToList();

                            var Blank = reader.Read<ZADM_M010_P>().ToList();
                            MC.BlankDetails = Blank.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        }
                        else if (RequestOption == "Report")
                        {
                            var rptProductionList = reader.Read<Rpt_MIS_Pro_MFG>().ToList();
                            dsReport = rptProductionList.ToList();
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

        public class MultipleContext_MIS_Pro_MFG
        {
            public List<ZADM_M010_P> ItemDetails { get; set; }
            public List<ADM_M024_P> Employee { get; set; }
            public List<ADM_M038_B_P> UnitDetails { get; set; }         
            public List<ZADM_M004_P> WireTypeDetails { get; set; }
            public List<ZADM_M002_P> BallTypeDetails { get; set; }
            public List<ZADM_M007_P> ILDDetails { get; set; }
            public List<ZADM_M006_P> InkDetails { get; set; }
            public List<ZADM_M010_P> TipTypes { get; set; }
            public List<ZADM_M010_P> BlankDetails { get; set; }
            public List<Rpt_MIS_Pro_MFG> RptProduction { get; set; }

        }
    }
}
