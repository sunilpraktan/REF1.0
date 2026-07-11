using Reflection.EF;
using Reflection.EF.CRM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    public class CRM_T002BL : ReflectionBusinessLogic
    {
        
        static int obj = 0;
        private static string connectionString;
        CRM_T002A cRM_T002A = new CRM_T002A();

        public CRM_T002BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public CRM_T002BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                MultipleContextCRM_T002 MC = new MultipleContextCRM_T002();

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("CRM_T002AInsert", new { @Request = Request }, commandType: CommandType.StoredProcedure);
                  

                    var CRM_T002ADataFlipGrid1 = reader.Read<CRM_T002AFlip>().ToList();
                    MC.CRM_T002ADataFlipGrid = CRM_T002ADataFlipGrid1.ToList();

                    var suppliercatalog_Master = reader.Read<CRM_T002A>().ToList();
                    MC.supplier_catalog_Master = suppliercatalog_Master.ToList();
                  
                    var suppliercatalog_details = reader.Read<CRM_T002B>().ToList();
                    MC.supplier_catalog_details = suppliercatalog_details.ToList();
                 
                    cRM_T002A = MC.supplier_catalog_Master[0];
                    cRM_T002A.XmlData_CRM_T002B = ObjectSerializationService.ObjectToXML(MC.supplier_catalog_details);

                    cRM_T002A.XmlData_CRM_T002A_FlipGrid = ObjectSerializationService.ObjectToXML(MC.CRM_T002ADataFlipGrid);
                }
                
                string strReturnData = ObjectSerializationService.ObjectToXML(cRM_T002A);
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
                MultipleContextCRM_T002 MC = new MultipleContextCRM_T002();
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("CRM_T002AUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var CRM_T002ADataFlipGrid1 = reader.Read<CRM_T002AFlip>().ToList();
                    MC.CRM_T002ADataFlipGrid = CRM_T002ADataFlipGrid1.ToList();

                    var suppliercatalog_Master = reader.Read<CRM_T002A>().ToList();
                    MC.supplier_catalog_Master = suppliercatalog_Master.ToList();

                    var suppliercatalog_details = reader.Read<CRM_T002B>().ToList();
                    MC.supplier_catalog_details = suppliercatalog_details.ToList();

                    cRM_T002A = MC.supplier_catalog_Master[0];
                    cRM_T002A.XmlData_CRM_T002B = ObjectSerializationService.ObjectToXML(MC.supplier_catalog_details);

                    cRM_T002A.XmlData_CRM_T002A_FlipGrid = ObjectSerializationService.ObjectToXML(MC.CRM_T002ADataFlipGrid);
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(cRM_T002A);
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

                    int intOut = conn.Execute("CRM_T002ADelete", new { @supp_cat_code = Request }, commandType: CommandType.StoredProcedure);

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
            MultipleContextCRM_T002 MC = new MultipleContextCRM_T002();
            string RequestOption = RequestValue.Split('!')[0];
            string strData = "";
            try
            {
               

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("CRM_T002ALoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);
                    if (RequestOption == "LoadInitialData")
                    {

                        var CRM_T002AFlipGrid = reader.Read<CRM_T002AFlip>().ToList(); 
                        MC.CRM_T002ADataFlipGrid = CRM_T002AFlipGrid.ToList();
                     

                        var partymaster = reader.Read<ADM_M028_P>().ToList();
                        MC.party_master = partymaster.ToList();
                       
                        var itemmaster = reader.Read<ADM_M022_P>().ToList();
                        MC.item_master = itemmaster.ToList();
                   

                        var unitmaster = reader.Read<ADM_M038_B_P>().ToList();
                        MC.unit_master = unitmaster.ToList();
                       

                        var taxmaster = reader.Read<ACC_M013_P>().ToList();
                        MC.Tax_Master = taxmaster.ToList();
                        

                        var ParameterTemp = reader.Read<ADM_M031_P>().ToList();
                        MC.ParameterList = ParameterTemp.ToList();
                       

                        var ParamValueTemp = reader.Read<ADM_M030_P>().ToList();
                        MC.ParamValueList = ParamValueTemp.ToList();
                      
                    }

                    else if (RequestOption == "Load_CRM_T002B_Details")
                    {

                        var suppliercatalogmaster = reader.Read<CRM_T002A>().ToList();
                        MC.supplier_catalog_Master = suppliercatalogmaster.ToList();

                        var suppliercatalogdetails = reader.Read<CRM_T002B>().ToList();
                        MC.supplier_catalog_details = suppliercatalogdetails.ToList();
                       
                        var suppliercatalog_taxdetails = reader.Read<CRM_T002D>().ToList();
                        MC.supplier_catalog_tax_details = suppliercatalog_taxdetails.ToList();
                       

                        cRM_T002A = MC.supplier_catalog_Master[0];
                        cRM_T002A.XmlData_CRM_T002B = ObjectSerializationService.ObjectToXML(MC.supplier_catalog_details);
                        cRM_T002A.XmlData_CRM_T002D = ObjectSerializationService.ObjectToXML(MC.supplier_catalog_tax_details);
                       
                        strData = ObjectSerializationService.ObjectToXML(cRM_T002A);
                        return strData;


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

        public class MultipleContextCRM_T002
        {

            public List<CRM_T002AFlip> CRM_T002ADataFlipGrid { get; set; }           //Flip Grid
            public List<ADM_M028_P> party_master { get; set; }                       //Party Master
            public List<ADM_M022_P> item_master { get; set; }                        //Item Master
            public List<ADM_M038_B_P> unit_master { get; set; }                      // Unit Master
            public List<ACC_M013_P> Tax_Master { get; set; }                          // Tax master

            public List<ADM_M031_P> ParameterList { get; set; }                    //Parameter Master
            public List<ADM_M030_P> ParamValueList { get; set; }                  //Flute Master

            public List<CRM_T002A> supplier_catalog_Master { get; set; }            // CRM_T002A Master Details
            public List<CRM_T002B> supplier_catalog_details { get; set; }            // CRM_T002B Details
           // public List<CRM_T002C> supplier_catalog_range { get; set; }              //CRM_T002C Range
            public List<CRM_T002D> supplier_catalog_tax_details { get; set; }         //CRM_T002D Tax_Details

        }

    }
}
