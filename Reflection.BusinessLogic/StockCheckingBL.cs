using Reflection.EF;
using Reflection.EF.SCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class StockCheckingBL : ReflectionBusinessLogic
    {
        //GenericRepository<MM_T001> repository = new GenericRepository<MM_T001>();
        
        MM_T001 mM_T001 = new MM_T001();
        private static string connectionString;
        public StockCheckingBL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public StockCheckingBL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string Insert(string Request)
        {
            throw new NotImplementedException();
        }

        public string Update(string Request)
        {
            throw new NotImplementedException();
        }

        public string Delete(int Request)
        {
            throw new NotImplementedException();
        }


        public string GetData(string strType, int intValue, string strValue)
        {
            MultipleContext_CurrentStock MC = new MultipleContext_CurrentStock();
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("StockCheck", new
                    {
                        @param = strType,
                        @ItemCode = strValue
                    }, commandType: CommandType.StoredProcedure);
                

                    if (strType == "CurrentStock")
                    {
                        var currentstock = reader.Read<CurrentStock_details>().ToList();
                        MC.CurrentStock_details = currentstock.ToList();
                    }

                    else if (strType == "LoadCurrentStock")
                    {
                        var Item = reader.Read<ADM_M022_ESSEM_PopUp>().ToList();
                        MC.Item = Item.ToList();
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
       
        public class MultipleContext_CurrentStock
        {
            public List<CurrentStock_details> CurrentStock { get; set; }  //Goods Issue
            public List<CurrentStock_details> CurrentStock_details { get; set; }  // MM_T001_A     
            //public List<ADM_M018_Popup> Category { get; set; }  // MM_T001_A
            //public List<ADM_M019_Popup> ItemType { get; set; }  // MM_T001_A
            public List<ADM_M022_ESSEM_PopUp> Item { get; set; }  // MM_T001_A
            public List<ADM_M003_PopUp> Plant { get; set; }  // MM_T001_A
            public List<MM_M001_PopUp> StorageLocation { get; set; }  // MM_T001_A
            public List<Batch_Popup> Batch { get; set; }  // MM_T001_A
            public List<ADM_M034_PopUp> parameter { get; set; }  // MM_T001_A
            public List<ADM_M030_PopUp> paraval { get; set; }  // MM_T001_A

        }

        //public class MultipleContext_CurrentStock
        //{
        //    public List<CurrentStock_details> CurrentStock { get; set; }  //Goods Issue
        //    public List<CurrentStock_details> CurrentStock_details { get; set; }  // MM_T001_A     
        //    public List<ADM_M022_ESSEM_PopUp> Item { get; set; }  // MM_T001_A
        //    public List<ADM_M003_PopUp> Plant { get; set; }  // MM_T001_A
        //    public List<MM_M001_PopUp> StorageLocation { get; set; }  // MM_T001_A
        //    public List<Batch_Popup> Batch { get; set; }  // MM_T001_A
        
        //    public List<ADM_M034_PopUp> parameter { get; set; }  // MM_T001_A
        //    public List<ADM_M030_PopUp> paraval { get; set; }  // MM_T001_A

        //}

    }
}
