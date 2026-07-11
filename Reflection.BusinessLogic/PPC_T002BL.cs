using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.Production;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class PPC_T002BL : ReflectionBusinessLogic
    {
                   
         private static string connectionString;
         PPC_T002_A pPC_T002 = new  PPC_T002_A();
         public PPC_T002BL(string BusinessEntity)
         {
            connectionString = base.ReflectionConnectionString;
         }
        public PPC_T002BL()
         {
            connectionString = base.ReflectionConnectionString;
         }
        public string Insert(string Request)
         {
             try
             {
                 MultipleContext_PPC_T002 MC = new MultipleContext_PPC_T002();
                 pPC_T002 = new PPC_T002_A();
                 pPC_T002 = (PPC_T002_A)ObjectSerializationService.XMLToObject(Request, pPC_T002);
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("PPC_T002Insert", new
                        {
                            @Request = pPC_T002.XmlDataDocument_PPC_T002
                        }, commandType: CommandType.StoredProcedure);

                        var Details = reader.Read<PPC_T002_A>().ToList();
                        MC.Details = Details.ToList();

                        pPC_T002 = MC.Details[0];
                    }

                    string strReturnData = ObjectSerializationService.ObjectToXML(pPC_T002);
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
                 MultipleContext_PPC_T002 MC = new MultipleContext_PPC_T002();
                 pPC_T002 = new PPC_T002_A();
                 pPC_T002 = (PPC_T002_A)ObjectSerializationService.XMLToObject(Request, pPC_T002);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("PPC_T002Update", new
                    {
                        @Request = pPC_T002.XmlDataDocument_PPC_T002
                    }, commandType: CommandType.StoredProcedure);

                    var Details = reader.Read<PPC_T002_A>().ToList();
                    MC.Details = Details.ToList();

                    string strReturnData = ObjectSerializationService.ObjectToXML(pPC_T002);
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
         //public string Delete(int Request)
         //{
         //    try
         //    {
         //        int intOut =  dbContext.PPC_T002Delete(Request);
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
                 MultipleContext_PPC_T002 MC = new MultipleContext_PPC_T002();
                 pPC_T002 = new PPC_T002_A();
                 pPC_T002 = (PPC_T002_A)ObjectSerializationService.XMLToObject(Request, pPC_T002);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("PPC_T002Delete", new
                    {
                        @Request = pPC_T002.XmlDataDocument_PPC_T002
                    }, commandType: CommandType.StoredProcedure);

                }
                 string strReturnData = ObjectSerializationService.ObjectToXML(pPC_T002);
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
             MultipleContext_PPC_T002 MC = new MultipleContext_PPC_T002();
             //ePR_T001 = new EPR_T001();
             //ePR_T001 = (EPR_T001)ObjectSerializationService.XMLToObject(Request, ePR_T001);
             string strData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("PPC_T002LoadAll", new
                    {
                        @param = strType,
                        @id = strValue,
                        @Comp_id = intValue
                    }, commandType: CommandType.StoredProcedure);

                    if (strType == "LoadAll")
                    {
                        var Details = reader.Read<PPC_T002_A>().ToList();
                        MC.Details = Details.ToList();

                        var Machine = reader.Read<ZADM_M013_PopUp>().ToList();
                        MC.Machine = Machine.ToList();

                        var JobCart = reader.Read<PPC_T001_PopUp>().ToList();
                        MC.JobCart = JobCart.ToList();
                    }
                    strData = ObjectSerializationService.ObjectToXML(MC);
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
    }
   public class MultipleContext_PPC_T002
   {
       public List<PPC_T002_A> Details { get; set; }   //PPC_T002 
       public List<ZADM_M013_PopUp> Machine { get; set; }  //Machine Master
       public List<PPC_T001_PopUp> JobCart { get; set; }  //Job Cart
    
   }
}
