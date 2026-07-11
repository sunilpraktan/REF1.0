using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.EF;
using System.Data.SqlClient;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Web;
using System;
using System.Collections.Generic;
using Reflection.EF.CRM;
using System.Data;
using Dapper;
//santosh
namespace Reflection.BusinessLogic
{
    public class CRM_T001ABL : ReflectionBusinessLogic
    {
       
        CRM_T001A cRM_T001A = new CRM_T001A();
        MultipleContextCRM_T001A MC = new MultipleContextCRM_T001A();
        private static string connectionString;
        public CRM_T001ABL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public CRM_T001ABL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                MultipleContextCRM_T001A MC = new MultipleContextCRM_T001A();
                cRM_T001A = new CRM_T001A();


                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("CRM_T001AInsert", new { @Request = Request }, commandType: CommandType.StoredProcedure,commandTimeout:300);

                    var DocumentDataFlipGrid1 = reader.Read<CRM_T001A_Flip>().ToList();
                    MC.DocumentDataFlipGrid = DocumentDataFlipGrid1.ToList();

                    var MasterData = reader.Read<CRM_T001A>().ToList();                   
                    MC.MasterEntity = MasterData.ToList();

                    var ItemsData = reader.Read<CRM_T001B>().ToList();
                    MC.ItemsEntity = ItemsData.ToList();
                                
                    cRM_T001A = MC.MasterEntity[0];
                    cRM_T001A.XmlData_CRM_T001B = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                    cRM_T001A.XmlDocumentDataFlipGrid = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
              
                    string strReturnData = ObjectSerializationService.ObjectToXML(cRM_T001A);
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
                MultipleContextCRM_T001A MC = new MultipleContextCRM_T001A();
             

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("CRM_T001AUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure,commandTimeout:300);

                    var DocumentDataFlipGrid1 = reader.Read<CRM_T001A_Flip>().ToList();
                    MC.DocumentDataFlipGrid = DocumentDataFlipGrid1.ToList();

                    var MasterData = reader.Read<CRM_T001A>().ToList();
                    MC.MasterEntity = MasterData.ToList();
 
                    var ItemsData = reader.Read<CRM_T001B>().ToList();
                    MC.ItemsEntity = ItemsData.ToList();


                    cRM_T001A = MC.MasterEntity[0];
                    cRM_T001A.XmlData_CRM_T001B = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                  
                    cRM_T001A.XmlDocumentDataFlipGrid = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);

                   
                    string strReturnData = ObjectSerializationService.ObjectToXML(cRM_T001A);
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
                int intOut = 0;//dbContext.CRM_T001ADelete(Request);
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

        public string GetData(string RequestValue, string strType, int intValue, string strValue)
        {
           
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";

            try
            {


                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("CRM_T001ALoadAll", new { @request = RequestValue }, commandType: CommandType.StoredProcedure);



                    if (RequestOption == "LoadInitialData")
                    {
                        #region LoadInitialData

                        MC.DocumentDataFlipGrid = reader.Read<CRM_T001A_Flip>().ToList();

                        MC.PartyMaster = reader.Read<ADM_M028_P>().ToList();
                       
                        MC.ItemMaster = reader.Read<ADM_M022_P>().ToList();
                        
                        MC.UnitMaster = reader.Read<ADM_M038_B_P>().ToList();
                       
                        MC.Tax_Master = reader.Read<ACC_M013_P>().ToList();
                       
                        #endregion
                    }

                    else if (RequestOption == "LoadDocumentWithReferenceDocumentNumber")
                    {
                        #region LoadDocumentWithReferenceDocumentNumber

                        var MasterData = reader.Read<CRM_T001A>().ToList();
                        MC.MasterEntity = MasterData.ToList();
                      
                        var ItemsData = reader.Read<CRM_T001B>().ToList();
                        MC.ItemsEntity = ItemsData.ToList();
                      

                        //var TaxData = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<CRM_T001D>(reader);
                        //MC.Tax_Details = TaxData.ToList();
                        //reader.NextResult();


                        cRM_T001A = MC.MasterEntity[0];

                        cRM_T001A.XmlData_CRM_T001B = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                        //cRM_T001A.XmlData_CRM_T001D = ObjectSerializationService.ObjectToXML(MC.Tax_Details);

                      
                        strReturnData = ObjectSerializationService.ObjectToXML(cRM_T001A);
                        return strReturnData;

                        #endregion
                    }
                   
                    strReturnData = ObjectSerializationService.ObjectToXML(MC);
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
        public class MultipleContextCRM_T001A
        {
            public List<CRM_T001A_Flip> DocumentDataFlipGrid { get; set; }           
            public List<ADM_M028_P> PartyMaster { get; set; }
            public List<ADM_M022_P> ItemMaster { get; set; }
            public List<ADM_M038_B_P> UnitMaster { get; set; }
            public List<CRM_T001A> MasterEntity { get; set; }
            public List<CRM_T001B> ItemsEntity { get; set; }
            public List<CRM_T001C> Tax_Details { get; set; }          
            public List<ACC_M013_P> Tax_Master { get; set; }// Tax master

        }

        public class CRM_T001A_Flip
        {
            public string cust_cat_no { get; set; }
            public Nullable<System.DateTime> CatDate { get; set; }
            public string PartyId { get; set; }
            public Nullable<System.DateTime> Fdate { get; set; }
            public Nullable<System.DateTime> Tdate { get; set; }
            public string remark { get; set; }
            public string location_Id { get; set; }
            public string comp_code { get; set; }
            public string fin_year { get; set; }
            public bool active { get; set; }          
            public string description { get; set; }
            public string so_code { get; set; }
            public string po_code { get; set; }
            public string party_name { get; set; }

        }
    }
}
