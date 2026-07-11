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
    public class MIS_SCM_StoreBL : ReflectionBusinessLogic
    {
        MultipleContext_MIS_SCM_Store MC = new MultipleContext_MIS_SCM_Store();
        private static string ConnectionString;
        public MIS_SCM_StoreBL(string BusinessEntity)
        {
            ConnectionString = base.ReflectionConnectionString;
        }
        public MIS_SCM_StoreBL()
        {
            ConnectionString = base.ReflectionConnectionString;
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

        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            MultipleContext_MIS_SCM_Store MC = new MultipleContext_MIS_SCM_Store();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(ConnectionString))
                {
                    var reader = conn.QueryMultiple("MIS_SCM_Store", new { @Request = RequestValue }, commandTimeout: 800, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData" || RequestOption == "Report" || RequestOption == "UpdateClosing")
                    {

                        if (RequestOption == "LoadInitialData")
                        {
                            var PartyList = reader.Read<ADM_M028_P>().ToList();
                            MC.PartyMaster = PartyList.ToList();

                            var ItemList = reader.Read<ADM_M022_P>().ToList();
                            MC.ItemDetails = ItemList.ToList();

                            var WireTyList = reader.Read<ZADM_M004_P>().ToList();
                            MC.WireTypeDetails = WireTyList.ToList();

                            var BallTyList = reader.Read<ZADM_M002_P>().ToList();
                            MC.BallTypeDetails = BallTyList.ToList();

                            var ILDTyList = reader.Read<ZADM_M007_P>().ToList();
                            MC.ILDDetails = ILDTyList.ToList();

                            var InkList = reader.Read<ZADM_M006_P>().ToList();
                            MC.InkDetails = InkList.ToList();

                            var CategoryList = reader.Read<ADM_M018_P>().ToList();
                            MC.CategoryDetails = CategoryList.ToList();

                            var SubCategoryList = reader.Read<ADM_M019_P>().ToList();
                            MC.SubCategoryDetails = SubCategoryList.ToList();

                            var UnitList = reader.Read<ADM_M038_B_P>().ToList();
                            MC.UnitDetails = UnitList.ToList();          

                            var FinYearList = reader.Read<ACC_M001A_P>().ToList();
                            MC.FinYear = FinYearList.ToList();

                            var PostPeriodList = reader.Read<ACC_M001A_P>().ToList();
                            MC.PostPeriod = PostPeriodList.ToList();

                            var ParamValue = reader.Read<ADM_M030_P>().ToList();
                            MC.ParamValueList = ParamValue.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);

                        }

                        else if (RequestOption == "Report")
                        {
                            var StorelistDetails = reader.Read<MIS_SCM_StoreRpt>().ToList();
                            MC.StoreList= StorelistDetails.ToList();

                            strReturnData = ObjectSerializationService.ObjectToXML(MC);
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
        public class MultipleContext_MIS_SCM_Store
        {
            public List<ADM_M028_P> PartyMaster { get; set; }
            public List<ADM_M022_P> ItemDetails { get; set; }
            public List<ZADM_M004_P> WireTypeDetails { get; set; }
            public List<ZADM_M002_P> BallTypeDetails { get; set; }
            public List<ZADM_M007_P> ILDDetails { get; set; }
            public List<ZADM_M006_P> InkDetails { get; set; }
            public List<ADM_M018_P> CategoryDetails { get; set; }
            public List<ADM_M019_P> SubCategoryDetails { get; set; }
            public List<ADM_M038_B_P> UnitDetails { get; set; }
            public List<ADM_M031_P> ParameterList { get; set; }
            public List<ADM_M030_P> ParamValueList { get; set; }
            public List<ACC_M001A_P> FinYear { get; set; }
            public List<ACC_M001A_P> PostPeriod { get; set; }
            public List<MIS_SCM_StoreRpt> StoreList { get; set; }
        }
    }
}
