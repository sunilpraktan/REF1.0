using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.QMS;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class EQCR_T001BL : ReflectionBusinessLogic
    {
       
        private static string connectionString;
        
        EQCR_T001_A eQCR_T001_A = new EQCR_T001_A();
        public EQCR_T001BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public EQCR_T001BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                eQCR_T001_A = (EQCR_T001_A)ObjectSerializationService.XMLToObject(Request, eQCR_T001_A);

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("EQCR_T001Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    //eQCR_T001_A = new EQCR_T001_A();
                    MultipleContext_EQCR Mc = new MultipleContext_EQCR();

                    var EQCR_T001_A_data = reader.Read<EQCR_T001_A>().ToList();
                    Mc.masterList = EQCR_T001_A_data.ToList();
                  
                    var EQCR_T001_B_data = reader.Read<EQCR_T001_B>().ToList();                  
                    Mc.details_B_List = EQCR_T001_B_data.ToList();
                  
                    var EQCR_T001_C_data = reader.Read<EQCR_T001_C>().ToList();
                    Mc.detail_C_List = EQCR_T001_C_data.ToList();
                   
                    eQCR_T001_A = Mc.masterList[0];
                    eQCR_T001_A.XmlDataDocument_EQCR_T001_B = ObjectSerializationService.ObjectToXML(Mc.details_B_List);
                    eQCR_T001_A.XmlDataDocument_EQCR_T001_C = ObjectSerializationService.ObjectToXML(Mc.detail_C_List);

                    string strReturnData = ObjectSerializationService.ObjectToXML(eQCR_T001_A);
                    return strReturnData;
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
        public string Update(string Request)
        {
            try
            {
                eQCR_T001_A = (EQCR_T001_A)ObjectSerializationService.XMLToObject(Request, eQCR_T001_A);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("EQCR_T001Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    //eQCR_T001_A = new EQCR_T001_A();
                    MultipleContext_EQCR Mc = new MultipleContext_EQCR();

                    var EQCR_T001_A_data = reader.Read<EQCR_T001_A>().ToList();
                    Mc.masterList = EQCR_T001_A_data.ToList();
                  
                    var EQCR_T001_B_data = reader.Read<EQCR_T001_B>().ToList();
                    Mc.details_B_List = EQCR_T001_B_data.ToList();                 

                    var EQCR_T001_C_data = reader.Read<EQCR_T001_C>().ToList();
                    Mc.detail_C_List = EQCR_T001_C_data.ToList();

                    eQCR_T001_A = Mc.masterList[0];
                    eQCR_T001_A.XmlDataDocument_EQCR_T001_B = ObjectSerializationService.ObjectToXML(Mc.details_B_List);
                    eQCR_T001_A.XmlDataDocument_EQCR_T001_C = ObjectSerializationService.ObjectToXML(Mc.detail_C_List);

                    string strReturnData = ObjectSerializationService.ObjectToXML(eQCR_T001_A);
                    return strReturnData;
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
        public string Delete(int Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                   int intOut = conn.Execute("EQCR_T001Delete", new { @id = Request }, commandType: CommandType.StoredProcedure);
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
        public string GetData(string strType, int intValue, string strValue)
        {
            MultipleContext_EQCR MC = new MultipleContext_EQCR();
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("EQCR_T001LoadAll", new { @request = strType, @comp_loc = strValue, @id = intValue }, commandType: CommandType.StoredProcedure);

                    if (strType == "LoadAll")
                    {
                        var masterList1 = reader.Read<EQCR_T001_A>().ToList();
                        MC.masterList = masterList1.ToList();                      

                        var SupplierList = reader.Read<ADM_M028_PopUp>().ToList();                     
                        MC.SupplierList = SupplierList.ToList();

                        var materialList1 = reader.Read<ADM_M022_ESSEM_PopUp>().ToList();
                        MC.itemList = materialList1.ToList();
 
                        var uomList1 = reader.Read<ADM_M038_B_PopUp>().ToList();
                        MC.uomList = uomList1.ToList();

                        var defectList1 = reader.Read<ZADM_M016_PopUp>().ToList();
                        MC.defectList = defectList1.ToList();

                        //var itemList1 = reader.Read<ADM_M022_ESSEM_PopUp>().ToList();
                        //MC.itemList = itemList1.ToList();

                        var sample_DetailsList1 = reader.Read<ADM_M021_PopUp>().ToList();
                        MC.sample_DetailsList = sample_DetailsList1.ToList();
                    }
                    if (strType == "LoadAll_RN")
                    {
                        var masterList1 = reader.Read<EQCR_T001_A>().ToList();
                        MC.masterList = masterList1.ToList();

                        var SupplierList = reader.Read<ADM_M028_PopUp>().ToList();
                        MC.SupplierList = SupplierList.ToList();

                        var materialList1 = reader.Read<ADM_M021_PopUp>().ToList();
                        MC.materialList = materialList1.ToList();

                        var uomList1 = reader.Read<ADM_M038_B_PopUp>().ToList();
                        MC.uomList = uomList1.ToList();

                        var defectList1 = reader.Read<ZADM_M016_PopUp>().ToList();
                        MC.defectList = defectList1.ToList();

                        //var itemList1 = reader.Read<ADM_M022_ESSEM_PopUp>().ToList();
                        //MC.itemList = itemList1.ToList();

                        var sample_DetailsList1 = reader.Read<ADM_M021_PopUp>().ToList();
                        MC.sample_DetailsList = sample_DetailsList1.ToList();
                    }
                    else if (strType == "LoadDetail")
                    {
                        var details_B_List1 = reader.Read<EQCR_T001_B>().ToList();
                        MC.details_B_List = details_B_List1.ToList();

                        var details_C_List1 = reader.Read<EQCR_T001_C>().ToList();
                        MC.detail_C_List = details_C_List1.ToList();
                    }
                    else if (strType == "LoadDocumentDetailsFromBackFlip")
                    {
                        var masterList1 = reader.Read<EQCR_T001_A>().ToList();
                        MC.masterList = masterList1.ToList();

                        var details_B_List1 = reader.Read<EQCR_T001_B>().ToList();
                        MC.details_B_List = details_B_List1.ToList();

                        var details_C_List1 = reader.Read<EQCR_T001_C>().ToList();
                        MC.detail_C_List = details_C_List1.ToList();
                    }

                    string strData = ObjectSerializationService.ObjectToXML(MC);
                    return strData;
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
        public class MultipleContext_EQCR
        {
            public List<EQCR_T001_A> masterList { get; set; }
            public List<EQCR_T001_B> details_B_List { get; set; }
            public List<EQCR_T001_C> detail_C_List { get; set; }
            public List<ADM_M028_PopUp> SupplierList { get; set; }
            public List<ADM_M021_PopUp> materialList { get; set; }
            public List<ADM_M038_B_PopUp> uomList { get; set; }
            public List<ZADM_M016_PopUp> defectList { get; set; }
            public List<ADM_M022_ESSEM_PopUp> itemList { get; set; }
            public List<ADM_M021_PopUp> sample_DetailsList { get; set; }
            public string Title { get; set; }
            public string Company { get; set; }
        }
    }
}
