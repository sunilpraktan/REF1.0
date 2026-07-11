using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.EF;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using Reflection.EF.CRM;
using System.Xml.Serialization;
using Reflection.EF.Communication;

namespace Reflection.BusinessLogic
{
    public class ECRM_T002_ABL : ReflectionBusinessLogic
    {
        
        private static string connectionString;        
        static int obj = 0;
        MultipleContext_ECRM_T002_A MC = new MultipleContext_ECRM_T002_A();

        ECRM_T002_A eCRM_T002_A = new ECRM_T002_A();
        public ECRM_T002_ABL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ECRM_T002_ABL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                MultipleContext_ECRM_T002_A MC = new MultipleContext_ECRM_T002_A();
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ECRM_T002_AInsert", new { @Request = Request }, commandType: CommandType.StoredProcedure);
                  
                    var QFR = reader.Read<ECRM_T002_A>().ToList();
                    eCRM_T002_A = new ECRM_T002_A();
                    MC.QulityFeedback = QFR.ToList();
                  
                    var QFRDtl = reader.Read<ECRM_T002_B>().ToList();
                    MC.QFRDetails = QFRDtl.ToList();

                    var TestDetails = reader.Read<ECRM_T002_C>().ToList();
                    MC.testDetails = TestDetails.ToList();

                    eCRM_T002_A = MC.QulityFeedback[0];
                    if (MC.QFRDetails.Count() > 0)
                    {
                        eCRM_T002_A.XmlDataDocument_ECRM_T002_B = ObjectSerializationService.ObjectToXML(MC.QFRDetails);
                        eCRM_T002_A.XmlDataDocument_ECRM_T002_C = ObjectSerializationService.ObjectToXML(MC.testDetails);
                    }
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(eCRM_T002_A);
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
                MultipleContext_ECRM_T002_A MC = new MultipleContext_ECRM_T002_A();

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ECRM_T002_AUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);
                 
                    var QFR = reader.Read<ECRM_T002_A>().ToList();
                    eCRM_T002_A = new ECRM_T002_A();
                    MC.QulityFeedback = QFR.ToList();
                   
                    var QFRDtl = reader.Read<ECRM_T002_B>().ToList();
                    eCRM_T002_A = new ECRM_T002_A();
                    MC.QFRDetails = QFRDtl.ToList();

                    var TestDetails = reader.Read<ECRM_T002_C>().ToList();
                    MC.testDetails = TestDetails.ToList();

                    if (MC.QulityFeedback.Count > 0)
                    {
                        eCRM_T002_A = MC.QulityFeedback[0];
                    }
                    eCRM_T002_A.XmlDataDocument_ECRM_T002_B = ObjectSerializationService.ObjectToXML(MC.QFRDetails);
                    eCRM_T002_A.XmlDataDocument_ECRM_T002_C = ObjectSerializationService.ObjectToXML(MC.testDetails);
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(eCRM_T002_A);
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
        public string Delete(string Request)
        {
            try
            {
                 using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("ECRM_T002_ADelete", new {@quality_feedback_no = Request }, commandType: CommandType.StoredProcedure);
                    return intOut.ToString();
                }
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
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ECRM_T002ALoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        //var QFR = reader.Read<ECRM_T002_A>().ToList();
                        //MC.QulityFeedback = QFR.ToList();

                        var model = reader.Read<ZADM_M009_P>().ToList();
                        MC.Models = model.ToList();

                        var product = reader.Read<ADM_M022_P_ESSEM>().ToList();
                        MC.Products = product.ToList();

                        var Party = reader.Read<ADM_M028_P>().ToList();
                        MC.Parties = Party.ToList();

                        var ild = reader.Read<ZADM_M007_P>().ToList();
                        MC.ILD = ild.ToList();

                        var ink = reader.Read<ZADM_M006_P>().ToList();
                        MC.INK = ink.ToList();

                        var emp = reader.Read<ADM_M024_P>().ToList();
                        MC.Employees = emp.ToList();

                        var defct = reader.Read<ZADM_M016_P>().ToList();
                        MC.Defect = defct.ToList();
                        //reader.NextResult();

                        var make = reader.Read<ADM_M032_P>().ToList();
                        MC.MakeMaster = make.ToList();

                        var unitMaster = reader.Read<ADM_M038_B_P>().ToList();
                        MC.UnitMaster = unitMaster.ToList();

                        var TestPro = reader.Read<ADM_M065_P>().ToList();
                        MC.TestProcedure = TestPro.ToList();

                        var Attachment = reader.Read<COM_T003>().ToList();
                        MC.Attachment = Attachment.ToList();

                        var NotifiData = reader.Read<NotificationData>().ToList();
                        MC.NotificationData = NotifiData.ToList();

                        var QFRNo = reader.Read<ECRM_T002_A_P>().ToList();
                        MC.QFRNo = QFRNo.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);

                    }
                    else if (RequestOption == "LoadDocumentWithReferenceDocumentNumber")
                    {
                        var QFR = reader.Read<ECRM_T002_A>().ToList();
                        MC.QulityFeedback = QFR.ToList();

                        var QFRDetl = reader.Read<ECRM_T002_B>().ToList();
                        MC.QFRDetails = QFRDetl.ToList();

                        var TestDetails = reader.Read<ECRM_T002_C>().ToList();
                        MC.testDetails = TestDetails.ToList();

                        var Attachment = reader.Read<COM_T003>().ToList();
                        MC.Attachment = Attachment.ToList();
                    }
                   
                    else if (RequestOption == "LoadBackFlipData")
                    {
                        var QFR = reader.Read<ECRM_T002_A>().ToList();
                        MC.QulityFeedback = QFR.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
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
        //public string GetData(string strType, int intValue, string strValue)
        //{
        //    MultipleContext_ECRM_T002_A MC = new MultipleContext_ECRM_T002_A();
        //    string strData = "";
        //    try
        //    {
        //        using (IDbConnection conn = new SqlConnection(connectionString))
        //        {
        //            var reader = conn.QueryMultiple("ECRM_T002_ALoadAll", new
        //            {
        //                @param = strType,
        //                @QFR_id = intValue,
        //                @QFR_No = strValue
        //            }, commandType: CommandType.StoredProcedure);
        //            if (strType == "LoadAllRTQFR")
        //            {
        //                var QFR = reader.Read<ECRM_T002_A>().ToList();
        //                MC.QulityFeedback = QFR.ToList();

        //                var QFRDetl = reader.Read<ECRM_T002_B>().ToList();
        //                MC.QFRDetails = QFRDetl.ToList();

        //                var TestDetails = reader.Read<ECRM_T002_C>().ToList();
        //                MC.testDetails = TestDetails.ToList();

        //                var defct1 = reader.Read<ECRM_T002_B_P>().ToList();
        //                MC.DefectList = defct1.ToList();

        //                var QFRNo = reader.Read<ECRM_T002_A_P>().ToList();
        //                MC.QFRNo = QFRNo.ToList();

        //                var TestPro = reader.Read<ADM_M065_P>().ToList();
        //                MC.TestProcedure = TestPro.ToList();

        //                var Attachment = reader.Read<COM_T003>().ToList();
        //                MC.Attachment = Attachment.ToList();



        //            }
        //            if (strType == "LoadAll")
        //            {
        //                var QFR = reader.Read<ECRM_T002_A>().ToList();
        //                MC.QulityFeedback = QFR.ToList();

        //                var model = reader.Read<ZADM_M009_P>().ToList();
        //                MC.Models = model.ToList();

        //                var product = reader.Read<ADM_M022_P_ESSEM>().ToList();
        //                MC.Products = product.ToList();

        //                var Party = reader.Read<ADM_M028_P>().ToList();
        //                MC.Parties = Party.ToList();

        //                var ild = reader.Read<ZADM_M007_P>().ToList();
        //                MC.ILD = ild.ToList();

        //                var ink = reader.Read<ZADM_M006_P>().ToList();
        //                MC.INK = ink.ToList();

        //                var emp = reader.Read<ADM_M024_P>().ToList();
        //                MC.Employees = emp.ToList();

        //                var defct = reader.Read<ZADM_M016_P>().ToList();
        //                MC.Defect = defct.ToList();
        //                //reader.NextResult();

        //                var make = reader.Read<ADM_M032_P>().ToList();
        //                MC.MakeMaster = make.ToList();

        //                var unitMaster = reader.Read<ADM_M038_B_P>().ToList();
        //                MC.UnitMaster = unitMaster.ToList();

        //                var TestPro = reader.Read<ADM_M065_P>().ToList();
        //                MC.TestProcedure = TestPro.ToList();

        //                var Attachment = reader.Read<COM_T003>().ToList();
        //                MC.Attachment = Attachment.ToList();

        //                var NotifiData = reader.Read<NotificationData>().ToList();
        //                MC.NotificationData = NotifiData.ToList();
        //                //var QFRNo = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ECRM_T002_A_P>(reader);
        //                //MC.QFRNo = QFRNo.ToList();  
        //            }
        //            else if (strType == "QFR_Details")
        //            {
        //                var QFR = reader.Read<ECRM_T002_A>().ToList();
        //                MC.QulityFeedback = QFR.ToList();

        //                var QFRDetl = reader.Read<ECRM_T002_B>().ToList();
        //                MC.QFRDetails = QFRDetl.ToList();

        //                var TestDetails = reader.Read<ECRM_T002_C>().ToList();
        //                MC.testDetails = TestDetails.ToList();

        //                var Attachment = reader.Read<COM_T003>().ToList();
        //                MC.Attachment = Attachment.ToList();


        //            }
        //            else if (strType == "QFR_No")
        //            {
        //                var QFR = reader.Read<ECRM_T002_A>().ToList();
        //                MC.QulityFeedback = QFR.ToList();

        //                var QFRDetl = reader.Read<ECRM_T002_B>().ToList();
        //                MC.QFRDetails = QFRDetl.ToList();

        //                var TestDetails = reader.Read<ECRM_T002_C>().ToList();
        //                MC.testDetails = TestDetails.ToList();

        //                var Attachment = reader.Read<COM_T003>().ToList();
        //                MC.Attachment = Attachment.ToList();


        //            }
        //            else if (strType == "rptQFR")
        //            {
        //                var QFR = reader.Read<ECRM_T002_A>().ToList();
        //                MC.QulityFeedback = QFR.ToList();

        //                var QFRDetl = reader.Read<ECRM_T002_B>().ToList();
        //                MC.QFRDetails = QFRDetl.ToList();

        //                var TestDetails = reader.Read<ECRM_T002_C>().ToList();
        //                MC.testDetails = TestDetails.ToList();

        //                var Attachment = reader.Read<COM_T003>().ToList();
        //                MC.Attachment = Attachment.ToList();

        //                //var QFR1 = reader.Read<SalesInvoice_SingleReport>().ToList();
        //                //MC.rptQFR = QFR1.ToList();
        //                //var QFR = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<Reflection.BusinessLogic.SEL_T003BL.SalesInvoice_SingleReport>(reader).ToList();
        //                //MC.rptQFR = QFR.ToList();
        //            }
        //            else if (strType == "Load_RTQFR")
        //            {
        //                var QFR = reader.Read<ECRM_T002_A>().ToList();
        //                MC.QulityFeedback = QFR.ToList();

        //                var QFRDetl = reader.Read<ECRM_T002_B>().ToList();
        //                MC.QFRDetails = QFRDetl.ToList();

        //                var TestDetails = reader.Read<ECRM_T002_C>().ToList();
        //                MC.testDetails = TestDetails.ToList();

        //                var Attachment = reader.Read<COM_T003>().ToList();
        //                MC.Attachment = Attachment.ToList();


        //            }
        //            else if (strType == "LoadBackFlipData")
        //            {
        //                var QFR = reader.Read<ECRM_T002_A>().ToList();
        //                MC.QulityFeedback = QFR.ToList();
        //            }
        //        }
        //        strData = ObjectSerializationService.ObjectToXML(MC);
        //        return strData;
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new CreateException(ex.ErrorCode, ex.Message, ex);
        //    }
        //    catch (DivideByZeroException ex)
        //    {
        //        throw new CreateException(ex.Message, ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new CreateException(ex.Message, ex);
        //    }
        //}
    }
    public class MultipleContext_ECRM_T002_A
    {
        public List<ECRM_T002_A> QulityFeedback { get; set; }//QulityFeedback
        public List<ECRM_T002_B> QFRDetails { get; set; }//QFR Details
        public List<ECRM_T002_C> testDetails { get; set; }//Test Procedure Details
        public List<ADM_M065_P> TestProcedure { get; set; } //Test Procedure Master
        public List<ECRM_T002_B_P> DefectList { get; set; } //Test Procedure Master
        public List<ZADM_M009_P> Models { get; set; }//Model Master
        public List<ADM_M022_P_ESSEM> Products { get; set; }//Item Master
        public List<ADM_M028_P> Parties { get; set; }//Party_Master
        public List<ZADM_M007_P> ILD { get; set; }//ILD Master  
        public List<ZADM_M006_P> INK { get; set; }//Ink Master 
        public List<ADM_M003_P> Plants { get; set; }//Plant_Master 
        public List<ADM_M024_P> Employees { get; set; }//Employee_Master 
        public List<ZADM_M016_P> Defect { get; set; }// Defect Master 
        public List<ADM_M032_P> MakeMaster { get; set; }//Make Master
        public List<ECRM_T002_A_P> QFRNo { get; set; }//QulityFeedbackno
        public List<ADM_M001_A_P> SalesOrg { get; set; }
        public List<ADM_M001_H_P> SalesGroup { get; set; }
        public List<SalesInvoice_SingleReport> rptQFR { get; set; }
        public List<ADM_M038_B_P> UnitMaster { get; set; }
        public List<COM_T003> Attachment { get; set; }
        public List<NotificationData> NotificationData { get; set; }
    }
}
