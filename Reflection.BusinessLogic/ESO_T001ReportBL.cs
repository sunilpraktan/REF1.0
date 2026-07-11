using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.EF;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Data;
using Reflection.EF.Production;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class ESO_T001ReportBL : ReflectionBusinessLogic
    {
        private static String connectionString;
        MultipleContext_ESO_T001Report MC = new MultipleContext_ESO_T001Report();
        public ESO_T001ReportBL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ESO_T001ReportBL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        private List<ESO_T001_rpt> _dsReport;
        public List<ESO_T001_rpt> dsReport
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
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("MIS_Sorting_Reports", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var MachineCode = reader.Read<ZADM_M013_P>().ToList();
                        MC.MachineCodeList = MachineCode.ToList();

                        var Defect = reader.Read<ZADM_M016_P>().ToList();
                        MC.DefectList = Defect.ToList();

                        var Shift = reader.Read<ADM_M042_P>().ToList();
                        MC.Shift = Shift.ToList();

                        var ShiftIncharge = reader.Read<ADM_M024_P>().ToList();
                        MC.ShiftIncharge = ShiftIncharge.ToList();

                        var EngDetails = reader.Read<ZADM_M013_P>().ToList();
                        MC.EngineerDetails = EngDetails.ToList();

                        var UnitList = reader.Read<ADM_M038_B_P>().ToList();
                        MC.UOMList = UnitList.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);

                    }
                    else if (RequestOption == "Report")
                    {

                        var SortingReport = reader.Read<ESO_T001_rpt>().ToList();
                        dsReport = SortingReport.ToList();
                        strReturnData = ObjectSerializationService.ObjectToXML(dsReport);
                    }


                    return strReturnData;
                }
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
    public class MultipleContext_ESO_T001Report
    {
        public List<ESO_T001Flip> DocumentDataFlipGrid { get; set; }//BF data
        public List<ZADM_M013_P> MachineCodeList { get; set; }//Machine Details
        public List<ADM_M038_B_P> UOMList { get; set; }  //UOM List
        public List<ZADM_M016_P> DefectList { get; set; }  //Defect List
        public List<ADM_M042_P> Shift { get; set; }
        public List<ADM_M024_P> ShiftIncharge { get; set; }
        public List<PPC_T003_Batch> BatchDetails { get; set; }
        public List<ADM_M038_B_P> Engineer { get; set; }
        public List<ESO_T001Sort> SortBy { get; set; }
        public List<ESO_T001> MasterEntity { get; set; }  // Load Doc Data
        public ObservableCollection<ESO_T001_A> SortingDetails { get; set; }  // Load Defect Data
        //------------------REPORT---------------------
        public List<ESO_T001_rpt> sorting_rpt { get; set; } //Sort
        // Only for sorting transaction
        public List<ESO_T001> Sorting { get; set; }//Sorting
        public List<PPC_T001_P> BatchNo { get; set; }
        public List<ESO_T001_P> SortList { get; set; } //Sort
        public List<ZADM_M013_P> EngineerDetails { get; set; }

    }

}
