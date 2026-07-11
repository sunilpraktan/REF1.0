using Reflection.EF.SCM;
using Reflection.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Reflection.EF.SCM.ReportEntitySCM;
using Dapper;
using Reflection.BusinessEntity.SCM;

namespace Reflection.BusinessLogic
{
    public class MIS_FinStatementBL : ReflectionBusinessLogic
    {
        MultipleContext_MIS_FinStatement MC = new MultipleContext_MIS_FinStatement();
        private static string ConnectionString;
        public MIS_FinStatementBL(string BusinessEntity)
        {
            ConnectionString = base.ReflectionConnectionString;
        }
        public MIS_FinStatementBL()
        {
            ConnectionString = base.ReflectionConnectionString;
        }
 
        private List<MIS_RptFinStatement> _dsReport;
        public List<MIS_RptFinStatement> dsReport
        {
            get { return _dsReport; }
            set
            {
                _dsReport = value;
            }
        }
        private List<UptoDateTotal> _dsUptoDateFG;
        public List<UptoDateTotal> dsUptoDateFG
        {
            get { return _dsUptoDateFG; }
            set
            {
                _dsUptoDateFG = value;
            }
        }

        private List<UptoDateTotalTS> _dsUptoDateTS;
        public List<UptoDateTotalTS> dsUptoDateTS
        {
            get { return _dsUptoDateTS; }
            set
            {
                _dsUptoDateTS = value;
            }
        }
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {

            try
            {
                MultipleContext_MIS_FinStatement MC = new MultipleContext_MIS_FinStatement();
                string RequestOption = RequestValue.Split('!')[0];
                string RequestOption1 = RequestValue.Split('!')[1];

                string strReturnData = "";
                using (IDbConnection conn = new SqlConnection(ConnectionString))
                {
                    var reader = conn.QueryMultiple("MIS_Financial_Statement", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);
                  if (RequestOption == "LoadInitialData" || RequestOption == "Report" || RequestOption == "UpdateClosing" || RequestOption == "LoadUptodate" || RequestOption == "UpdateCurrStock" || RequestOption == "LoadUptodateTS")
                    {

                        if (strValue == "MIS_FinStatement_FG")
                        {

                            if (RequestOption == "LoadInitialData")
                            {
                                var CategoryList = reader.Read<ADM_M018_P>().ToList();
                                MC.CategoryDetails = CategoryList.ToList();

                                var SubCategoryList = reader.Read<ADM_M019_P>().ToList();
                                MC.SubCategoryDetails = SubCategoryList.ToList();

                                var UnitList = reader.Read<ADM_M038_B_P>().ToList();
                                MC.UnitDetails = UnitList.ToList();

                                var parameterList = reader.Read<ADM_M031_P>().ToList();
                                MC.ParameterList = parameterList.ToList();

                                var paramValueList = reader.Read<ADM_M030_P>().ToList();
                                MC.ParamValueList = paramValueList.ToList();

                                var FinYearList = reader.Read<ACC_M001A_P>().ToList();
                                MC.FinYear = FinYearList.ToList();

                                var PostPeriodList = reader.Read<ACC_M001A_P>().ToList();
                                MC.PostPeriod = PostPeriodList.ToList();

                                var TipType = reader.Read<ZADM_M010_P>().ToList();
                                MC.TipTypes = TipType.ToList();

                                var WireTyList = reader.Read<ZADM_M004_P>().ToList();
                                MC.WireTypeDetails = WireTyList.ToList();

                                var WireSzList = reader.Read<ZADM_M003_P>().ToList();
                                MC.WireSizeDetails = WireSzList.ToList();

                                var ItemList = reader.Read<ADM_M022_P>().ToList();
                                MC.ItemDetails = ItemList.ToList();

                                strReturnData = ObjectSerializationService.ObjectToXML(MC);

                            }

                            else if (RequestOption == "Report")
                            {
                                if (RequestOption1 == "@R005" || RequestOption1 == "@R011")

                                {
                                    var rptDataList = reader.Read<MIS_RptFinStatement>().ToList();
                                    MC.FinReportData = rptDataList.ToList();
                                    var rptDataList2 = reader.Read<UptoDateFG>().ToList();
                                    MC.UpToDateFGList = rptDataList2.ToList();
                                }
                                else
                                {
                                    var rptDataList = reader.Read<MIS_RptFinStatement>().ToList();
                                    MC.FinReportData = rptDataList.ToList();
                                }
                                strReturnData = ObjectSerializationService.ObjectToXML(MC);

                            }
                            else if (RequestOption == "LoadUptodate")
                            {
                                if (RequestOption1 == "@R005" || RequestOption1 == "@R011")

                                {
                                    var rptDataList = reader.Read<MIS_RptFinStatement>().ToList();
                                    MC.FinReportData = rptDataList.ToList();
                                    var rptDataList2 = reader.Read<UptoDateFG>().ToList();
                                    MC.PreviousUptoDateFG = rptDataList2.ToList();
                                }
                                else
                                {
                                    var rptDataList = reader.Read<MIS_RptFinStatement>().ToList();
                                    MC.FinReportData = rptDataList.ToList();
                                }
                                strReturnData = ObjectSerializationService.ObjectToXML(MC);

                            }
                        }
                        else
                        {

                            if (RequestOption == "LoadInitialData")
                            {
                                var CategoryList = reader.Read<ADM_M018_P>().ToList();
                                MC.CategoryDetails = CategoryList.ToList();

                                var SubCategoryList = reader.Read<ADM_M019_P>().ToList();
                                MC.SubCategoryDetails = SubCategoryList.ToList();

                                var UnitList = reader.Read<ADM_M038_B_P>().ToList();
                                MC.UnitDetails = UnitList.ToList();

                                var parameterList = reader.Read<ADM_M031_P>().ToList();
                                MC.ParameterList = parameterList.ToList();

                                var paramValueList = reader.Read<ADM_M030_P>().ToList();
                                MC.ParamValueList = paramValueList.ToList();

                                var FinYearList = reader.Read<ACC_M001A_P>().ToList();
                                MC.FinYear = FinYearList.ToList();

                                var PostPeriodList = reader.Read<ACC_M001A_P>().ToList();
                                MC.PostPeriod = PostPeriodList.ToList();

                                var TipType = reader.Read<ZADM_M010_P>().ToList();
                                MC.TipTypes = TipType.ToList();

                                var WireTyList = reader.Read<ZADM_M004_P>().ToList();
                                MC.WireTypeDetails = WireTyList.ToList();

                                var WireSzList = reader.Read<ZADM_M003_P>().ToList();
                                MC.WireSizeDetails = WireSzList.ToList();

                                var ItemList = reader.Read<ADM_M022_P>().ToList();
                                MC.ItemDetails = ItemList.ToList();

                                strReturnData = ObjectSerializationService.ObjectToXML(MC);

                            }

                            else if (RequestOption == "Report")
                            {
                              
                                if (RequestOption1 == "@R002" || RequestOption1 == "@R010")

                                {
                                    var rptDataList = reader.Read<MIS_RptFinStatement>().ToList();
                                    MC.FinReportData = rptDataList.ToList();
                                    var rptDataList2 = reader.Read<UptoDateTS>().ToList();
                                    MC.CurrrentUptoDateTS = rptDataList2.ToList();
                                }
                                else
                                {
                                    var rptDataList = reader.Read<MIS_RptFinStatement>().ToList();
                                    MC.FinReportData = rptDataList.ToList();
                                }
                                strReturnData = ObjectSerializationService.ObjectToXML(MC);
                            }
                            else if (RequestOption == "LoadUptodateTS")
                            {

                                var rptDataList = reader.Read<MIS_RptFinStatement>().ToList();
                                MC.FinReportData = rptDataList.ToList();
                                var rptDataList2 = reader.Read<UptoDateTS>().ToList();
                                MC.PreviousUptoDateTS = rptDataList2.ToList();

                                strReturnData = ObjectSerializationService.ObjectToXML(MC);

                            }
                            else if (RequestOption == "UpdateClosing")
                            {
                                var rptDataList = reader.Read<MIS_RptFinStatement>().ToList();
                                dsReport = rptDataList.ToList();
                                strReturnData = ObjectSerializationService.ObjectToXML(dsReport);
                            }
                            else if (RequestOption == "UpdateCurrStock")
                            {
                                var rptDataList = reader.Read<MIS_RptFinStatement>().ToList();
                                dsReport = rptDataList.ToList();
                                strReturnData = ObjectSerializationService.ObjectToXML(dsReport);
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

        public string InsertFG(string Request)
        {
           
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(ConnectionString))
                {
                    
                        var reader = conn.QueryMultiple("MIS_FinStatement_Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);
                        var UptoDateTotalFG = reader.Read<UptoDateTotal>().ToList();
                        dsUptoDateFG = UptoDateTotalFG.ToList();
                        strReturnData = ObjectSerializationService.ObjectToXML(dsUptoDateFG);
                    
                }
               
                return strReturnData;
            }
            catch (SqlException ex)
            {
                throw new CreateException(ex.ErrorCode, ex.Message, ex);
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new CreateException(ex.Message, ex);
            }
        }
        public string InsertTS(string Request)
        {

            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(ConnectionString))
                {
                        var reader = conn.QueryMultiple("MIS_FinStatement_InsertTS", new { @Request = Request }, commandType: CommandType.StoredProcedure);
                        var UptoDateTotalTS = reader.Read<UptoDateTotalTS>().ToList();
                        dsUptoDateTS = UptoDateTotalTS.ToList();
                        strReturnData = ObjectSerializationService.ObjectToXML(dsUptoDateTS);

                }

                return strReturnData;
            }
            catch (SqlException ex)
            {
                throw new CreateException(ex.ErrorCode, ex.Message, ex);
            }
            catch (CreateException ex)
            {
                throw new CreateException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new CreateException(ex.Message, ex);
            }
        }
        public class MultipleContext_MIS_FinStatement
        {

            public List<ADM_M018_P> CategoryDetails { get; set; }
            public List<ADM_M019_P> SubCategoryDetails { get; set; }
            public List<ADM_M038_B_P> UnitDetails { get; set; }
            public List<ADM_M031_P> ParameterList { get; set; }
            public List<ADM_M030_P> ParamValueList { get; set; }
            public List<ACC_M001A_P> FinYear { get; set; }
            public List<ACC_M001A_P> PostPeriod { get; set; }
            public List<ZADM_M010_P> TipTypes { get; set; }
            public List<ZADM_M004_P> WireTypeDetails { get; set; }
            public List<UptoDateFG> UpToDateFGList { get; set; }
            public List<UptoDateFG> PreviousUptoDateFG { get; set; }
            public List<UptoDateTotal> UptoDateTotal { get; set; }
            public List<UptoDateTS> PreviousUptoDateTS { get; set; }
            public List<UptoDateTotalTS> UptoDateTotalTS { get; set; }
            public List<UptoDateTS> CurrrentUptoDateTS { get; set; }
            public List<MIS_RptFinStatement> FinReportData { get; set; }
            public List<ZADM_M003_P> WireSizeDetails { get; set; }
            public List<ADM_M022_P> ItemDetails { get; set; }

        }
    }
}