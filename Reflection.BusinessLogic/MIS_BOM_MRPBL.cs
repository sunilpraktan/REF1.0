using Dapper;
using Reflection.EF;
using Reflection.EF.Production.ReportEntityProduction;
using Reflection.EF.SCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
   public class MIS_BOM_MRPBL : ReflectionBusinessLogic
    {
        private static string connectionString;
        public MIS_BOM_MRPBL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public MIS_BOM_MRPBL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        MultipleContextMIS_BOM_MRP MC = new MultipleContextMIS_BOM_MRP();
        private List<Rpt_BillOfMaterial> _dsReport;
        public List<Rpt_BillOfMaterial> dsReport
        {
            get { return _dsReport; }
            set
            {
                _dsReport = value;
            }
        }
        public string GetData(string strType, string QueryOption, int intValue, string strValue)
        {

            MultipleContextMIS_BOM_MRP MC = new MultipleContextMIS_BOM_MRP();
            string RequestOption = strType.Split('!')[0];
            string strReturnData = "";
            try
            {

                if (RequestOption == "LoadInitialData" || RequestOption == "Report")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("MIS_BOM_MRPReport", new { @request = strType }, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LoadInitialData")
                        {
                            var BOMDetails = reader.Read<ENG_T001_P>().ToList();
                            MC.BOMList = BOMDetails.ToList();

                            var _UnitList = reader.Read<ADM_M038_B_P>().ToList();
                            MC.UnitList = _UnitList.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);

                        }
                        else if (RequestOption == "Report")
                        {
                            var Rpt_BillOfMaterial = reader.Read<Rpt_BillOfMaterial>().ToList();
                            dsReport = Rpt_BillOfMaterial.ToList();
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

        public class MultipleContextMIS_BOM_MRP
        {
            public List<ENG_T001_P> BOMList { get; set; }
            public List<Rpt_BillOfMaterial> Rpt_BillOfMaterialReport { get; set; }
            public List<MM_T003_A> ItemsEntity { get; set; }
            public List<MM_T003> MasterEntityIndent { get; set; }
            public List<ADM_M038_B_P> UnitList { get; set; }
        }
    }
}
