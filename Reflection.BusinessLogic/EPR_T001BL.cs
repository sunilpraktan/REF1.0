using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Serialization;
using Reflection.EF.Production;
using Dapper;
using Reflection.EF.Communication;
using Reflection.EF.ReflectionSystem;
using Reflection.EF.HRMS.Production;

namespace Reflection.BusinessLogic
{
    public class EPR_T001BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        EPR_T001 ePR_T001 = new EPR_T001();
        public EPR_T001BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public EPR_T001BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                MultipleContext_EPR_T001 MC = new MultipleContext_EPR_T001();
                ePR_T001 = new EPR_T001();
                ePR_T001 = (EPR_T001)ObjectSerializationService.XMLToObject(Request, ePR_T001);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T001Insert", new
                    {
                        @Type = ePR_T001.Type,
                        @location_Id = ePR_T001.location_Id,
                        @comp_code = ePR_T001.comp_code,
                        @Date = ePR_T001.start_dt,
                        @Request = ePR_T001.XmlDataDocument_EPR_T001
                    }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    var ILDChart = reader.Read<EPR_T001>().ToList();
                    MC.ILDChart = ILDChart.ToList();
                    ePR_T001 = MC.ILDChart[0];
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(ePR_T001);
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
        public string Update(string Request)
        {
            try
            {
                MultipleContext_EPR_T001 MC = new MultipleContext_EPR_T001();
                ePR_T001 = new EPR_T001();
                ePR_T001 = (EPR_T001)ObjectSerializationService.XMLToObject(Request, ePR_T001);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T001Update", new
                    {
                        @Type = ePR_T001.Type,
                        @location_Id = ePR_T001.location_Id,
                        @comp_code = ePR_T001.comp_code,
                        @Date = ePR_T001.start_dt,
                        @Request = ePR_T001.XmlDataDocument_EPR_T001
                    }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    //var ILDChart = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<EPR_T001>(reader).ToList();
                    //MC.ILDChart = ILDChart.ToList();
                    //reader.NextResult();

                    //ePR_T001 = MC.ILDChart[0];
                    // ePR_T001.XmlDataDocument_EPR_T001 = ObjectSerializationService.ObjectToXML(MC.GoodsA);

                }
                string strReturnData = ObjectSerializationService.ObjectToXML(ePR_T001);
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
        //public string Delete(int Request)
        //{
        //    try
        //    {
        //        int intOut = dbContext.EPR_T001Delete(Request);
        //        return intOut.ToString();
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new CreateException(ex.ErrorCode, ex.Message, ex);
        //    }
        //    catch (CreateException ex)
        //    {
        //        throw new CreateException(ex.Message, ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new CreateException(ex.Message, ex);
        //    }

        //}

        public string Delete(string Request)
        {
            try
            {
                MultipleContext_EPR_T001 MC = new MultipleContext_EPR_T001();
                ePR_T001 = new EPR_T001();
                ePR_T001 = (EPR_T001)ObjectSerializationService.XMLToObject(Request, ePR_T001);

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T001Delete", new
                    {
                        @Type = ePR_T001.Type,
                        @location_Id = ePR_T001.location_Id,
                        @comp_code = ePR_T001.comp_code,
                        @Date = ePR_T001.start_dt,
                        @Request = ePR_T001.XmlDataDocument_EPR_T001
                    }, commandType: CommandType.StoredProcedure);

                    //var ILDChart = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<EPR_T001>(reader).ToList();
                    //MC.ILDChart = ILDChart.ToList();
                    //reader.NextResult();
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(ePR_T001);
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
        public string GetData(string strType, string strValue, int intValue)
        {
            MultipleContext_EPR_T001 MC = new MultipleContext_EPR_T001();
            //ePR_T001 = new EPR_T001();
            //ePR_T001 = (EPR_T001)ObjectSerializationService.XMLToObject(Request, ePR_T001);
            string strData = "";
            try
            {
                if (strType != ("RPTINK") && strType != "RPTConversion")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("EPR_T001LoadAll", new
                        {
                            @request_type = strType,
                            @id = intValue,
                            @request = strValue

                        }, commandType: CommandType.StoredProcedure);

                        if (strType == "LoadAllILD")
                        {
                            var Goods1 = reader.Read<EPR_T001>().ToList();
                            MC.ILDChart = Goods1.ToList();

                            //var plant1 = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ADM_M003_P>(reader).ToList();
                            //MC.plant = plant1.ToList();
                            // reader.NextResult();

                            //var MachineType = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ZADM_M013_P_machine_type>(reader).ToList();
                            //MC.MachineType = MachineType.ToList();
                            //reader.NextResult();

                            var Machine = reader.Read<ZADM_M013_P>().ToList();
                            MC.Machine = Machine.ToList();

                            var Model = reader.Read<ZADM_M009_P>().ToList();
                            MC.Model = Model.ToList();

                            var Product = reader.Read<ADM_M022_P_ESSEM>().ToList();
                            MC.Product = Product.ToList();

                            //var BallDia = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ZADM_M001_P>(reader).ToList();
                            //MC.BallDia = BallDia.ToList();
                            // reader.NextResult();

                            var BallMake = reader.Read<ADM_M032_P>().ToList();
                            MC.BallMake = BallMake.ToList();

                            //var WireMake = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ADM_M032_P>(reader).ToList();
                            //MC.WireMake = WireMake.ToList();
                            //reader.NextResult();

                            //var BallType = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ZADM_M002_P>(reader).ToList();
                            //MC.BallType = BallType.ToList();
                            // reader.NextResult();

                            var INK = reader.Read<ZADM_M006_P>().ToList();
                            MC.INK = INK.ToList();

                            var ILD = reader.Read<ZADM_M007_P>().ToList();
                            MC.ILD = ILD.ToList();

                            var SalesOrder = reader.Read<SEL_T001_P>().ToList();
                            MC.SalesOrder = SalesOrder.ToList();

                            var Customer = reader.Read<ADM_M028_P>().ToList();
                            MC.Customer = Customer.ToList();
                            //reader.NextResult();

                            //var GoodsNew = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<EPR_T001>(reader).ToList();
                            //MC.ILDChart_New = GoodsNew.ToList();
                            //reader.NextResult();
                        }
                        else if (strType == "LoadAll")
                        {
                            var Goods1 = reader.Read<EPR_T001>().ToList();
                            MC.ILDChart = Goods1.ToList();

                            var plant1 = reader.Read<ADM_M003_P>().ToList();
                            MC.plant = plant1.ToList();

                            var MachineType = reader.Read<ZADM_M013_P_machine_type>().ToList();
                            MC.MachineType = MachineType.ToList();

                            var Machine = reader.Read<ZADM_M013_P>().ToList();
                            MC.Machine = Machine.ToList();

                            var Model = reader.Read<ZADM_M009_P>().ToList();
                            MC.Model = Model.ToList();

                            var Product = reader.Read<ADM_M022_P_ESSEM>().ToList();
                            MC.Product = Product.ToList();

                            var BallDia = reader.Read<ZADM_M001_P>().ToList();
                            MC.BallDia = BallDia.ToList();

                            var BallMake = reader.Read<ADM_M032_P>().ToList();
                            MC.BallMake = BallMake.ToList();

                            var WireMake = reader.Read<ADM_M032_P>().ToList();
                            MC.WireMake = WireMake.ToList();

                            var BallType = reader.Read<ZADM_M002_P>().ToList();
                            MC.BallType = BallType.ToList();

                            var INK = reader.Read<ZADM_M006_P>().ToList();
                            MC.INK = INK.ToList();

                            var ILD = reader.Read<ZADM_M007_P>().ToList();
                            MC.ILD = ILD.ToList();

                            var SalesOrder = reader.Read<SEL_T001_P>().ToList();
                            MC.SalesOrder = SalesOrder.ToList();

                            var ProductionPlanNo = reader.Read<EPR_T004_A_P>().ToList();
                            MC.ProductionPlan = ProductionPlanNo.ToList();

                            var Customer = reader.Read<ADM_M028_P>().ToList();
                            MC.Customer = Customer.ToList();

                            var WireSize = reader.Read<ZADM_M003_P>().ToList();
                            MC.WireSize = WireSize.ToList();

                            var PkgUnitListTemp = reader.Read<ZADM_M017_P>().ToList();
                            MC.PkgUnitList = PkgUnitListTemp.ToList();

                            var DocumentTypesTemp = reader.Read<SYS_M013_P>().ToList();
                            MC.DocumentTypes = DocumentTypesTemp.ToList();

                            var shift = reader.Read<ADM_M042_P>().ToList();
                            MC.ShiftList = shift.ToList();

                            MC.UOM = reader.Read<ADM_M038_B_P>().ToList();

                        }
                        else if (strType == "Load")
                        {
                            var Goods1 = reader.Read<EPR_T001>().ToList();
                            MC.ILDChart = Goods1.ToList();

                        }
                        else if (strType == "LoadMachine")
                        {
                            var Goods1 = reader.Read<EPR_T001>().ToList();
                            MC.ILDChart_New = Goods1.ToList();

                        }
                        else if (strType == "LoadPrevMachine")
                        {
                            var Goods1 = reader.Read<EPR_T001>().ToList();
                            MC.ILDChart_New = Goods1.ToList();
                        }
                    }
                }
                else if (strType == "RPTINK" || strType == "RPTConversion")
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("RPT_EPR_T001", new
                        {
                            @request_type = strType,
                            @id = intValue,
                            @request = strValue
                        }, commandType: CommandType.StoredProcedure);

                        if (strType == "RPTINK")
                        {
                            var RptILDChart = reader.Read<RPT_EPR_T001_ILDChart>().ToList();
                            MC.RptILDChart = RptILDChart.ToList();
                        }
                        else if (strType == "RPTConversion")
                        {
                            var RPTINK = reader.Read<RPT_EPR_T001>().ToList();
                            MC.RPTINK = RPTINK.ToList();

                            var Rptapproval = reader.Read<RPT_Approval>().ToList();
                            MC.Rptapproval = Rptapproval.ToList();

                            var _AttachmentData = reader.Read<COM_T003>().ToList();
                            MC.AttachmentData = _AttachmentData.ToList();

                            var DocumentTypesTemp = reader.Read<SYS_M013_P>().ToList();
                            MC.DocumentTypes = DocumentTypesTemp.ToList();
                        }
                    }
                }
                strData = ObjectSerializationService.ObjectToXML(MC);
                return strData;
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
        public string GetData2(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            MultipleContext_EPR_T001 MC = new MultipleContext_EPR_T001();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T001LoadAllFeedback", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadFeedbackRpt")
                    {
                        var feedback = reader.Read<ECRM_T002_AFeedbackRpt>().ToList();
                        MC.RptFeedback = feedback.ToList();
                    }
                    else if (RequestOption == "LoadFeedbackRpt2")
                    {
                        var feedback = reader.Read<ECRM_T002_AFeedbackRpt>().ToList();
                        MC.RptFeedback = feedback.ToList();
                    }
                    else if (RequestOption == "LoadFromDateToDate")
                    {
                        var Loadfromdate = reader.Read<EPR_T001>().ToList();
                        MC.ILDChart = Loadfromdate.ToList();
                    }
                }

                strReturnData = ObjectSerializationService.ObjectToXML(MC);
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
        public string UpdateStatusCancel(string Request)
        {
            try
            {
                Request = (string)ObjectSerializationService.XMLToObject(Request, Request);
                int reader;
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    reader = conn.Execute("EPR_T001UpdateStaus", new { @Request = Request }, commandType: CommandType.StoredProcedure);
                }
                string strReturnData = reader.ToString();
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
        public string UpdateStatusStop(string Request)
        {
            try
            {
                Request = (string)ObjectSerializationService.XMLToObject(Request, Request);
                int reader;
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    reader = conn.Execute("EPR_T001UpdateStaus", new { @Request = Request }, commandType: CommandType.StoredProcedure);
                }
                string strReturnData = reader.ToString();
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
        public string UpdateStatusCurrent(string Request)
        {
            try
            {
                Request = (string)ObjectSerializationService.XMLToObject(Request, Request);
                int reader;
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    reader = conn.Execute("EPR_T001UpdateStaus", new { @Request = Request }, commandType: CommandType.StoredProcedure);
                }
                string strReturnData = reader.ToString();
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
    }
    public class MultipleContext_EPR_T001
    {
        public List<EPR_T001> ILDChart { get; set; }   //EPR_T001 ILD Chart
        public List<ADM_M003_P> plant { get; set; }  //Plant Master
        public List<ZADM_M013_P_machine_type> MachineType { get; set; }  //Machine Type
        public List<ZADM_M013_P> Machine { get; set; }  //Machine Master
        public List<ZADM_M009_P> Model { get; set; }  //Model Master
        public List<ADM_M022_P_ESSEM> Product { get; set; } //Product /Item 
        public List<ZADM_M001_P> BallDia { get; set; } //Ball Dia
        public List<ADM_M032_P> BallMake { get; set; } //Ball Make
        public List<ADM_M032_P> WireMake { get; set; } //Wire Make 
        public List<ZADM_M003_P> WireSize { get; set; } //Wire Size 
        public List<ZADM_M002_P> BallType { get; set; } //Ball Type
        public List<ZADM_M006_P> INK { get; set; } //INK
        public List<ZADM_M007_P> ILD { get; set; } //ILD
        public List<EPR_T001> ILDChart_New { get; set; }  //ILD Chart
        public List<SEL_T001_P> SalesOrder { get; set; } // Order No / sales Doc.no
        public List<EPR_T004_A_P> ProductionPlan { get; set; }//Order No/Sample
        public List<ADM_M028_P> Customer { get; set; } //Customer /Party
        public List<ZADM_M017_P> PkgUnitList { get; set; }
        public List<RPT_EPR_T001> RPTINK { get; set; }
        public List<RPT_EPR_T001_ILDChart> RptILDChart { get; set; }
        public List<ECRM_T002_AFeedbackRpt> RptFeedback { get; set; }
        public List<SYS_M013_P> DocumentTypes { get; set; }
        public List<ADM_M042_P> ShiftList { get; set; }
        public List<RPT_Approval> Rptapproval { get; set; }
        public List<COM_T003> AttachmentData { get; set; }
        public List<PPC_T004_A> PlannedOrders { get; set; }
        public List<ADM_M038_B_P> UOM { get; set; }
        public List<ADM_M022_P1> ItemMaster { get; set; }
        public List<ADM_M003_P> LocationMaster { get; set; }
        public List<ADM_M024_P> EmployeeList { get; set; }
        public List<QMS_M030_P> RoutingList { get; set; }
        public List<ENG_T001_P> BOMList { get; set; }
        public List<SYS_M025> StatusList { get; set; }
        public List<ACC_M019_P> CostCenterList { get; set; }
        public List<ACC_M020_P> ProfitCenterList { get; set; }
        public List<EPR_T001> MasterEntity { get; set; }
        public List<EPR_T001> BackFlipList { get; set; }
        public List<MM_M001_P> StoreCodeList { get; set; }
        public List<PPC_M001_P> WorkCenter { get; set; }
        public List<SYS_M051> ControlKeyMaster { get; set; }
        public List<PPC_M002> OperationList { get; set; }
        public List<EPR_T001_A> OperationEntity { get; set; }
        public List<STD_LIST_BE> REF_DOC_LIST { get; set; }

    }
}
