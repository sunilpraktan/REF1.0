using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF.Procurement;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class PUR_T001_A_CANCELBL : ReflectionBusinessLogic
    {

        
        private static string connectionString;
        PUR_T001_A MasterEntity = new PUR_T001_A();
        public PUR_T001_A_CANCELBL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public PUR_T001_A_CANCELBL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string Update(string Request)
        {
            MultipleContext_PUR_T001_A MC = new MultipleContext_PUR_T001_A();
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("PUR_T001_A_CANCEL_Update", new { @Request = Request }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<PUR_T001_A>().ToList();
                    MC.Pur_Req = MasterData.ToList();
                   
                    var ItemsData = reader.Read<PUR_T001_B>().ToList();
                    MC.Pur_Req_Details = ItemsData.ToList();
                   
                    strReturnData = ObjectSerializationService.ObjectToXML(MC);
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
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            MultipleContext_PUR_T001_A MC = new MultipleContext_PUR_T001_A();
           
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("PUR_T001_A_CANCEL_LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var DocDataFlipGrid = reader.Read<PUR_T001_AFlip>().ToList();
                        MC.DocumentDataFlipGrid = DocDataFlipGrid.ToList();
                      
                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "LoadDocumentWithDocumentNumber")
                    {

                        var MasterData = reader.Read<PUR_T001_A>().ToList();
                        MC.Pur_Req = MasterData.ToList();
                    
                        var ItemDetail = reader.Read<PUR_T001_B>().ToList();
                        MC.Pur_Req_Details = ItemDetail.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);                      
                        return strReturnData;
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
        public class MultipleContext_PUR_T001_A
        {
            public List<PUR_T001_AFlip> DocumentDataFlipGrid { get; set; }
            public List<PUR_T001_A> Pur_Req { get; set; }//Purchase Requisition
            public List<PUR_T001_B> Pur_Req_Details { get; set; }//Purchase Requisition Items        
        }
     }
}
