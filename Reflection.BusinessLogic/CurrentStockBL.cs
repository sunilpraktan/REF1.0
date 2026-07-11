
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Serialization;
using Reflection.EF.SCM;
using Reflection.EF.CRM;
using Reflection.EF.Procurement;
using Dapper;
using Reflection.EF.SCM.ReportEntitySCM;

namespace Reflection.BusinessLogic
{
    public class CurrentStockBL : ReflectionBusinessLogic
    {             
        MM_T001 MasterEntity = new MM_T001();
        private static string connectionString;
        MultipleContext_CurrentStock MC = new MultipleContext_CurrentStock();

        public CurrentStockBL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public CurrentStockBL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        private List<MIS_SCM_StoreRpt> _dsReport;
        public List<MIS_SCM_StoreRpt> dsReport
        {
            get { return _dsReport; }
            set
            {
                _dsReport = value;
            }
        }
        public string GetData(string RequestValue, string strType, int intValue, string strValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                if (RequestOption == "LoadInitialData" || RequestOption == "LoadStockDetails")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("MIS_MM_Stocks", new { @request = RequestValue }, commandType: CommandType.StoredProcedure);


                        if (RequestOption == "LoadInitialData")
                        {
                            MC.CategoryList = reader.Read<ADM_M018_P>().ToList();

                            MC.SubCategoryList = reader.Read<ADM_M019_P>().ToList();

                            MC.ItemTypeList = reader.Read<ADM_M015_P>().ToList();

                            MC.SubItemTypeList = reader.Read<ADM_M016_P>().ToList();

                            MC.ItemList = reader.Read<ADM_M022_P>().ToList();

                            MC.UomDetails = reader.Read<ADM_M038_B_P>().ToList();

                            MC.Parameter = reader.Read<ADM_M031_P>().ToList();

                            MC.ParameterVal = reader.Read<ADM_M030_P>().ToList();

                            var GradeList = reader.Read<ADM_M045_P>().ToList();
                            MC.GradeDetails = GradeList.ToList();

                            var StoreLocation1 = reader.Read<MM_M001_P>().ToList();
                            MC.StoreLocation = StoreLocation1.ToList();
                            strReturnData = ObjectSerializationService.ObjectToXML(MC);

                         
                        }
                        else if (RequestOption == "LoadStockDetails")
                        {
                            MC.CurrentStockList = reader.Read<CurrentStock>().ToList();
                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        }
                    }
                }
                else
                {
                    if (RequestOption == "Report")
                    {
                        using (IDbConnection conn = new SqlConnection(connectionString))
                        {
                            var reader = conn.QueryMultiple("MIS_SCM_Store", new { @Request = RequestValue }, commandTimeout: 800, commandType: CommandType.StoredProcedure);


                            if (RequestOption == "Report")
                            {
                                //var rptDataList = reader.Read<MIS_SCM_StoreRpt>().ToList();
                             
                                //dsReport = rptDataList.ToList();

                                var StorelistDetails = reader.Read<MIS_SCM_StoreRpt>().ToList();
                                MC.StoreList = StorelistDetails.ToList();

                                strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            }
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
    }
    public class MultipleContext_CurrentStock
    {
        public List<ADM_M018_P> CategoryList { get; set; } 
        public List<ADM_M019_P> SubCategoryList { get; set; }
        public List<ADM_M015_P> ItemTypeList { get; set; }
        public List<ADM_M016_P> SubItemTypeList { get; set; }
        public List<ADM_M022_P> ItemList { get; set; }
        public List<ADM_M038_B_P> UomDetails { get; set; }
        public List<ADM_M031_P> Parameter { get; set; } 
        public List<ADM_M030_P> ParameterVal { get; set; }
        public List<CurrentStock> CurrentStockList { get; set; }
        public List<CurrentStock_details> CurrentStockDetail { get; set; }
        public List<CurrentStock_Report> CurrentStockReport { get; set; }
        public List<RptCurrentStock> CurrentStock_Report { get; set; }
        public List<MIS_SCM_StoreRpt> StoreList { get; set; }
        public List<ADM_M045_P> GradeDetails { get; set; }
        public List<MM_M001_P> StoreLocation { get; set; }
    }
}
