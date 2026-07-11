using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using Reflection.EF.CRM;
using System.Xml.Serialization;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class ECRM_T003_ABL : ReflectionBusinessLogic
    {
       
        private static string connectionString;
        
        static int obj = 0;

        ECRM_T003_A eCRM_T003_A = new ECRM_T003_A();
        WTRpt_ECRM_T003_A RPTECRM_T003_A = new WTRpt_ECRM_T003_A();
        public ECRM_T003_ABL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ECRM_T003_ABL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                MultipleContext_ECRM_T003_A MC = new MultipleContext_ECRM_T003_A();
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ECRM_T003_AInsert", new { @Request = Request }, commandType: CommandType.StoredProcedure,commandTimeout:3000);

                    var wt = reader.Read<ECRM_T003_A>().ToList();
                    eCRM_T003_A = new ECRM_T003_A();
                    MC.WritingTest = wt.ToList();

                    var wtDtl = reader.Read<ECRM_T003_B>().ToList();
                    eCRM_T003_A = new ECRM_T003_A();
                    MC.WTDetails = wtDtl.ToList();

                    eCRM_T003_A = MC.WritingTest[0];
                    eCRM_T003_A.XmlDataDocument_ECRM_T003_B = ObjectSerializationService.ObjectToXML(MC.WTDetails);
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(eCRM_T003_A);
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
                MultipleContext_ECRM_T003_A MC = new MultipleContext_ECRM_T003_A();
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ECRM_T003_AUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var wt = reader.Read<ECRM_T003_A>().ToList();
                    eCRM_T003_A = new ECRM_T003_A();
                    MC.WritingTest = wt.ToList();

                    var wtDtl = reader.Read<ECRM_T003_B>().ToList();
                    eCRM_T003_A = new ECRM_T003_A();
                    MC.WTDetails = wtDtl.ToList();
                    if (MC.WritingTest.Count > 0)
                    {
                        eCRM_T003_A = MC.WritingTest[0];
                    }
                    eCRM_T003_A.XmlDataDocument_ECRM_T003_B = ObjectSerializationService.ObjectToXML(MC.WTDetails);
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(eCRM_T003_A);
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
                int intOut = 0;// dbContext.ECRM_T003_ADelete(Request);
                return intOut.ToString();
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
        public string GetData(string Request,string strType, int intValue, string strValue)
        {
            MultipleContext_WTRpt_ECRM_T003_A MCRpt = new MultipleContext_WTRpt_ECRM_T003_A();
            MultipleContext_ECRM_T003_A MC = new MultipleContext_ECRM_T003_A();
            string strData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ECRM_T003_ALoadAll", new
                    {

                        @param = strType,
                        @machine_Id = intValue,
                        @podct_date = strValue,
                        @location_Id = strValue,
                        @wt_id = intValue,
                        @y = intValue,
                        @wtno = Request,
                    }, commandType: CommandType.StoredProcedure,commandTimeout:1600);

                    if (strType == "LoadAll")
                    {
                        var wt = reader.Read<ECRM_T003_A>().ToList();
                        MC.WritingTest = wt.ToList();

                        var wtDtl = reader.Read<ECRM_T003_B>().ToList();
                        MC.WTDetails = wtDtl.ToList();

                        var model = reader.Read<EPR_T001_P>().ToList();
                        MC.ILDChart = model.ToList();

                        var product = reader.Read<ADM_M022_P_ESSEM>().ToList();
                        MC.Products = product.ToList();

                        var ild = reader.Read<ZADM_M007_P>().ToList();
                        MC.ILD = ild.ToList();

                        var modeltm = reader.Read<ZADM_M009_P>().ToList();
                        MC.Models = modeltm.ToList();

                        var ink = reader.Read<ZADM_M006_P>().ToList();
                        MC.INK = ink.ToList();

                        var defct = reader.Read<ZADM_M016_P>().ToList();
                        MC.Defect = defct.ToList();

                        var prodctWT = reader.Read<ECRM_T003_A_P>().ToList();
                        MC.ProductFrmWT = prodctWT.ToList();

                        var EmpMaster = reader.Read<ADM_M024_P>().ToList();
                        MC.EmpList = EmpMaster.ToList();

                        var testtype  = reader.Read<ECRM_T003_C_P>().ToList();
                        MC.Test_Type = testtype.ToList();

                        var Barcode = reader.Read<PPC_T003_Batch>().ToList();
                        MC.BatchDetails = Barcode.ToList();

                    }
                    else if (strType == "WT_Details")
                    {
                        var wt = reader.Read<ECRM_T003_A>().ToList();
                        MC.WritingTest = wt.ToList();

                        var wtDtl = reader.Read<ECRM_T003_B>().ToList();
                        MC.WTDetails = wtDtl.ToList();
                    }
                    else if (strType == "Machine_Details")
                    {
                        //-----------------------------Change By Pallavi--------------------------------------
                        var Convlot = reader.Read<EPR_T001_P>().ToList();
                        MC.ConvLot = Convlot.ToList();

                        //--------------------------------------------------------------------------

                        var RefDtl = reader.Read<ECRM_T003_B_P>().ToList();
                        MC.Refil = RefDtl.ToList();

                    }
                    else if (strType == "WTReport")
                    {
                        var WTReport = reader.Read<WTRpt_ECRM_T003_A>().ToList();
                        MCRpt.WritingTest = WTReport.ToList();
                    }
                    else if (strType == "WTProdcReport")
                    {
                        var WTProdcRpt = reader.Read<WTRpt_ECRM_T003_A>().ToList();
                        MCRpt.WritingTest = WTProdcRpt.ToList();

                        var ILD1 = reader.Read<ILD1>().ToList();
                        MCRpt.ILD1 = ILD1.ToList();

                        var ILD2 = reader.Read<ILD2>().ToList();
                        MCRpt.ILD2 = ILD2.ToList();

                        var TempWritingTest = reader.Read<WTRpt_ECRM_T003_A>().ToList();
                        MCRpt.TempWritingTest = TempWritingTest.ToList();
                        //---------------------------------------------------------
                        int CountDS = 0; int CountDS1 = 0; int CountDS2 = 0;

                        try
                        {
                            CountDS = MCRpt.WritingTest.Count;
                        }
                        catch
                        {
                            CountDS = 0;
                        }
                        //--------------------------------------
                        try
                        {
                            CountDS1 = MCRpt.ILD1.Count;
                        }
                        catch
                        {
                            CountDS1 = 0;
                        }
                        //--------------------------------------
                        try
                        {
                            CountDS2 = MCRpt.ILD2.Count;
                        }
                        catch
                        {
                            CountDS2 = 0;
                        }
                        //--------------------------------------                   
                        if (CountDS1 > CountDS || CountDS2 > CountDS)
                        {
                            int CountDiff = 0;
                            if (CountDS1 > CountDS2)
                            {
                                CountDiff = CountDS1 - CountDS;
                            }
                            else
                            {
                                CountDiff = CountDS2 - CountDS;
                            }
                            try
                            {
                                for (int p = 0; p < CountDiff; p++)
                                {

                                    foreach (WTRpt_ECRM_T003_A itm in MCRpt.TempWritingTest.ToList())
                                    {
                                        MCRpt.WritingTest.Add(itm);
                                    }
                                }
                            }
                            catch
                            { }
                        }
                        try
                        {
                            for (int i = 0; i < MCRpt.WritingTest.Count(); i++)
                            {
                                if (MCRpt.ILD1.Count() > 0)
                                {
                                    if (i <= MCRpt.ILD1.Count() - 1)
                                    {
                                        MCRpt.WritingTest.ToList()[i].ildp1 = MCRpt.ILD1.ToList()[i].ILD;
                                    }
                                    else
                                    {
                                        MCRpt.WritingTest.ToList()[i].ildp1 = Convert.ToDecimal(0);
                                    }
                                }
                                else
                                {
                                    WTProdcRpt.ToList()[i].ildp1 = Convert.ToDecimal(0);
                                }
                                if (MCRpt.ILD2.Count() > 0)
                                {
                                    if (i <= MCRpt.ILD2.Count() - 1)
                                    {
                                        MCRpt.WritingTest.ToList()[i].ild2 = MCRpt.ILD2.ToList()[i].ILD;
                                    }
                                    else
                                    {
                                        MCRpt.WritingTest.ToList()[i].ild2 = Convert.ToDecimal(0);
                                    }
                                }
                                else
                                {
                                    MCRpt.WritingTest.ToList()[i].ild2 = Convert.ToDecimal(0);
                                }
                            }
                        }
                        catch
                        { }
                    }
                    if (strType == "WTReport" || strType == "WTProdcReport")
                    {
                        strData = ObjectSerializationService.ObjectToXML(MCRpt);
                    }
                    else
                    {
                        strData = ObjectSerializationService.ObjectToXML(MC);
                    }
                }
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
    }
    public class MultipleContext_ECRM_T003_A
    {
        public List<ECRM_T003_A> WritingTest { get; set; }//WritingTest       
        public List<EPR_T001_P> ILDChart { get; set; }//ILDChart Master
        public List<ADM_M022_P_ESSEM> Products { get; set; }//Item Master     
        public List<ZADM_M007_P> ILD { get; set; }//ILD Master  
        public List<EPR_T001_P> ConvLot { get; set; }//Conv Lot From ILDChart           
        public List<ZADM_M009_P> Models { get; set; }//Model Master
        public List<ZADM_M006_P> INK { get; set; }//Ink Master 
        public List<ECRM_T003_B_P> Refil { get; set; }// Refil Frm WritingTest Details  
        public List<ECRM_T003_B> WTDetails { get; set; }//WritingTest Details
        public List<ZADM_M016_P> Defect { get; set; }// Defect Master
        public List<ECRM_T003_A_P> ProductFrmWT { get; set; }//Writing Test 
        public List<ADM_M024_P> EmpList { get; set; }
        public List<ECRM_T003_C_P> Test_Type { get; set; }
        public List<PPC_T003_Batch> BatchDetails { get; set; }
    }
    public class MultipleContext_WTRpt_ECRM_T003_A
    {
        public List<WTRpt_ECRM_T003_A> WritingTest { get; set; }//WritingTest  
        public List<EPR_T001_P> ILDChart { get; set; }//ILDChart Master
        public List<ADM_M022_P_ESSEM> Products { get; set; }//Item Master     
        public List<ZADM_M007_P> ILD { get; set; }//ILD Master  
        public List<EPR_T001_P> ConvLot { get; set; }//Conv Lot From ILDChart   

        public List<ZADM_M009_P> Models { get; set; }//Model Master
        public List<ZADM_M006_P> INK { get; set; }//Ink Master 

        public List<ECRM_T003_B_P> Refil { get; set; }// Refil Frm WritingTest Details  

        public List<ECRM_T003_B> WTDetails { get; set; }//WritingTest Details


        public List<WTRpt_ECRM_T003_A> TempWritingTest { get; set; }//WritingTest  
        public List<ILD1> ILD1 { get; set; }//Ink Master 
        public List<ILD2> ILD2 { get; set; }//Ink Master 
     
    }
}
