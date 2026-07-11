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
    public class PPC_T001BL : ReflectionBusinessLogic
    {
            
            private static string connectionString;
            static int obj = 0;
           
            PPC_T001 pPC_T001 = new PPC_T001();

            public PPC_T001BL(string BusinessEntity)
            {
                connectionString = base.ReflectionConnectionString;
            }
            public PPC_T001BL()
            {
                connectionString = base.ReflectionConnectionString;
            }
        public string Insert(string Request)
            {
                try
                {
                    pPC_T001 = (PPC_T001)ObjectSerializationService.XMLToObject(Request, pPC_T001);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("PPC_T001Insert", new
                    { @Request = pPC_T001.XmlDataDocument_PPC_T001 }, commandType: CommandType.StoredProcedure);

                    var JobCardA = reader.Read<PPC_T001>().ToList();
                    List<PPC_T001> JobCard_List = JobCardA.ToList();
                    if (JobCard_List.Count > 0)
                    {
                        pPC_T001 = JobCard_List[0];
                    }
                }
                    string strReturnData = ObjectSerializationService.ObjectToXML(pPC_T001);
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
                    //PPC_T001 pPC_T001 = new PPC_T001();               
                    pPC_T001 = (PPC_T001)ObjectSerializationService.XMLToObject(Request, pPC_T001);
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("PPC_T001Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);
                    
                        string strReturnData = ObjectSerializationService.ObjectToXML(pPC_T001);
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
                int intOut = 0;// dbContext.PPC_T001Delete(Request);
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
            public string GetData(string strType, int intValue, string strValue)
            {
                MultipleContext_PPC_T001 MC = new MultipleContext_PPC_T001();
                try
                {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("PPC_T001LoadAll", new
                    {
                        @para = strType,
                        @id = strValue,
                        @Comp_id = intValue

                    }, commandType: CommandType.StoredProcedure);

                    if (strType == "LoadAll")
                    {
                        var jobcart = reader.Read<PPC_T001>().ToList();
                        MC.JobCartDetails = jobcart.ToList();
                    }
                    else
                    {
                        var jobcart = reader.Read<PPC_T001>().ToList();
                        MC.JobCartList = jobcart.ToList();

                        var Item = reader.Read<SEL_T001_Popup>().ToList();
                        MC.ItemList = Item.ToList();

                        var SoNo = reader.Read<SEL_T001_PopUp_Deli_Note>().ToList();
                        MC.SoNoList = SoNo.ToList();

                        //var jobcartDetailsA = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<PPC_T001>(reader).ToList();
                        //MC.JobCartDetails = jobcartDetailsA.ToList();
                    }
                }
                    string strData = ObjectSerializationService.ObjectToXML(MC);
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
    public class MultipleContext_PPC_T001
    {
        public List<PPC_T001> JobCartList { get; set; } //jobCart            
        public List<SEL_T001_Popup> ItemList { get; set; }//itemcode
        public List<SEL_T001_PopUp_Deli_Note> SoNoList { get; set; }//SoNo       
        public List<PPC_T001> JobCartDetails { get; set; } //jobCartDetails
    }
   
}
