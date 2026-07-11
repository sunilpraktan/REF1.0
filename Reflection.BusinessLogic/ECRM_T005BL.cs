using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Serialization;
using Reflection.EF.CRM;

namespace Reflection.BusinessLogic
{
    public class ECRM_T005BL : ReflectionBusinessLogic
    {
        // GenericRepository<ECRM_T005> repository = new GenericRepository<ECRM_T005>();
        //CRMDBEntities dbContext = new CRMDBEntities();

        // ECRM_T005 ECRM_T005 = new ECRM_T005();
        // public ECRM_T005BL(string BusinessEntity)
        //{
        //   connectionString = base.ReflectionConnectionString;
        //}
        // public ECRM_T005BL()
        //{
        //   connectionString = base.ReflectionConnectionString;
        //}

        // public string Insert(string Request)
        // {
        //     try
        //     {
        //         MultipleContext_ECRM_T005 MC = new MultipleContext_ECRM_T005();
        //         ECRM_T005 = new ECRM_T005();
        //         ECRM_T005 = (ECRM_T005)ObjectSerializationService.XMLToObject(Request, ECRM_T005);
        //         SqlParameter[] param = new SqlParameter[] 
        //        {                     
        //             new SqlParameter("@Request",ECRM_T005.XmlDataDocument_ECRM_T005)               
        //        };
        //         var cmd = dbContext.Database.Connection.CreateCommand();
        //         cmd.CommandText = "ECRM_T005Insert";
        //         cmd.CommandType = CommandType.StoredProcedure;
        //         cmd.Parameters.AddRange(param);
        //         dbContext.Database.Connection.Open();

        //         var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

        //         var ILDChart = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ECRM_T005>(reader).ToList();
        //         MC.PostDetails = ILDChart.ToList();
        //         reader.NextResult();

        //         ECRM_T005 = MC.PostDetails[0];

        //         if (!reader.Read())
        //         {
        //             reader.Close();
        //         }
        //         string strReturnData = ObjectSerializationService.ObjectToXML(ECRM_T005);
        //         return strReturnData;
        //     }
        //     catch (SqlException ex)
        //     {
        //         throw new CreateException(ex.ErrorCode, ex.Message, ex);
        //     }
        //     catch (CreateException ex)
        //     {
        //         throw new CreateException(ex.Message, ex);
        //     }
        //     catch (Exception ex)
        //     {
        //         throw new CreateException(ex.Message, ex);
        //     }
        // }

        // public string Update(string Request)
        // {
        //     try
        //     {
        //         MultipleContext_ECRM_T005 MC = new MultipleContext_ECRM_T005();
        //         ECRM_T005 = new ECRM_T005();
        //         ECRM_T005 = (ECRM_T005)ObjectSerializationService.XMLToObject(Request, ECRM_T005);
        //         SqlParameter[] param = new SqlParameter[] 
        //        {
        //             new SqlParameter("@Request",ECRM_T005.XmlDataDocument_ECRM_T005)           
        //        };
        //         var cmd = dbContext.Database.Connection.CreateCommand();
        //         cmd.CommandText = "ECRM_T005Update";
        //         cmd.CommandType = CommandType.StoredProcedure;
        //         cmd.Parameters.AddRange(param);
        //         dbContext.Database.Connection.Open();
        //         var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

        //         var ILDChart = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ECRM_T005>(reader).ToList();
        //         MC.PostDetails = ILDChart.ToList();
        //         reader.NextResult();

        //         ECRM_T005 = MC.PostDetails[0];

        //         if (!reader.Read())
        //         {
        //             reader.Close();
        //         }

        //         string strReturnData = ObjectSerializationService.ObjectToXML(ECRM_T005);
        //         return strReturnData;

        //     }
        //     catch (SqlException ex)
        //     {
        //         throw new CreateException(ex.ErrorCode, ex.Message, ex);
        //     }
        //     catch (CreateException ex)
        //     {
        //         throw new CreateException(ex.Message, ex);
        //     }
        //     catch (Exception ex)
        //     {
        //         throw new CreateException(ex.Message, ex);
        //     }
        // }

        // public string Delete(int Request)
        // {
        //     try
        //     {
        //         int intOut = dbContext.ECRM_T005Delete(Request);
        //         return intOut.ToString();
        //     }
        //     catch (SqlException ex)
        //     {
        //         throw new CreateException(ex.ErrorCode, ex.Message, ex);
        //     }
        //     catch (CreateException ex)
        //     {
        //         throw new CreateException(ex.Message, ex);
        //     }
        //     catch (Exception ex)
        //     {
        //         throw new CreateException(ex.Message, ex);
        //     }

        // }
        // public string GetData(string strType, string strValue, int intValue)
        // {
        //     MultipleContext_ECRM_T005 MC = new MultipleContext_ECRM_T005();           
        //     string strData = "";
        //     try
        //     {
        //         SqlParameter[] param = new SqlParameter[] 
        //            {                       
        //                new SqlParameter("@param",strType) ,
        //                new SqlParameter("@id",intValue) //,        
        //               //new SqlParameter("@start_dt",strValue)

        //            };

        //         var cmd = dbContext.Database.Connection.CreateCommand();
        //         cmd.CommandText = "ECRM_T005LoadAll";
        //         cmd.CommandType = CommandType.StoredProcedure;
        //         cmd.Parameters.AddRange(param);
        //         dbContext.Database.Connection.Open();
        //         var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

        //         if (strType == "LoadAll")
        //         {

        //             var Goods1 = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ECRM_T005>(reader).ToList();
        //             MC.PostDetails = Goods1.ToList();
        //             reader.NextResult();

        //             var Invoice = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<SEL_T003_A_Popup>(reader).ToList();
        //             MC.Invoice = Invoice.ToList();
        //             reader.NextResult();

        //             var Agent = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ADM_M027_PopUp>(reader).ToList();
        //             MC.Agent = Agent.ToList();
        //             reader.NextResult();

        //             var Bank = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ACC_M004_Popup>(reader).ToList();
        //             MC.Bank = Bank.ToList();
        //             reader.NextResult();

        //             var Airline = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ZADM_M019_Popup>(reader).ToList();
        //             MC.Airline = Airline.ToList();
        //             reader.NextResult();   
        //         }

        //         {
        //             reader.Close();
        //         }
        //         strData = ObjectSerializationService.ObjectToXML(MC);
        //         return strData;
        //     }
        //     catch (SqlException ex)
        //     {
        //         throw new CreateException(ex.ErrorCode, ex.Message, ex);
        //     }
        //     catch (DivideByZeroException ex)
        //     {
        //         throw new CreateException(ex.Message, ex);
        //     }
        //     catch (Exception ex)
        //     {
        //         throw new CreateException(ex.Message, ex);
        //     }
        // }
    }

    //public class MultipleContext_ECRM_T005
    //{
    //    public List<ECRM_T005> PostDetails { get; set; } //ECRM_T005
    //    public List<ECRM_T005> GoodsDetails { get; set; } //ECRM_T005
    //    public List<SEL_T003_A_Popup> Invoice { get; set; } //Invoice
    //    public List<ADM_M027_PopUp> Agent { get; set; } //Agent        
    //    public List<ACC_M004_Popup> Bank { get; set; } //Bank     
    //    public List<ZADM_M019_Popup> Airline { get; set; } //Airline
    //}
}
