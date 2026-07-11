using Reflection.EF.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using Reflection.EF;


namespace Reflection.BusinessLogic
{
    public class ZADM_M026BL : ReflectionBusinessLogic
    {
        private static string connectionString;

        ZADM_M026 MasterEntity = new ZADM_M026();
        ZADM_M026 ItemEntity = new ZADM_M026();

        MultipleContext_ZADM_M026 MC = new MultipleContext_ZADM_M026();

        public ZADM_M026BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ZADM_M026BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string Insert(string Request)
        {
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZADM_M026Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var ItemsData = reader.Read<ZADM_M026>().ToList();
                    MC.ItemEntity = ItemsData.ToList();

                    MasterEntity.XmlDataDocument_ItemsEntity = ObjectSerializationService.ObjectToXML(MC.ItemEntity);

                }
                strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
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
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZADM_M026Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);


                    var ItemsData = reader.Read<ZADM_M026>().ToList();
                    MC.ItemEntity = ItemsData.ToList();

                    MasterEntity.XmlDataDocument_ItemsEntity = ObjectSerializationService.ObjectToXML(MC.ItemEntity);
                }
                strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
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
        public string Delete(int Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("ZADM_M026Delete", new { @id = Request }, commandType: CommandType.StoredProcedure);
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
                    var reader = conn.QueryMultiple("ZADM_M026LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);


                    if (RequestOption == "LoadInitialData")
                    {
                        var documentDataFlipGrid = reader.Read<ZADM_M026Flip>().ToList();
                        MC.DocumentDataFlipGrid = documentDataFlipGrid.ToList();

                        var supplierList = reader.Read<ADM_M028_P>().ToList();
                        MC.SupplierList = supplierList.ToList();

                        var customerList = reader.Read<ADM_M028_P>().ToList();
                        MC.CustomerList = customerList.ToList();

                        var itemList = reader.Read<ADM_M022_P>().ToList();
                        MC.ItemList = itemList.ToList();

                        var parameterlist = reader.Read<ADM_M031_P>().ToList();
                        MC.ParameterList = parameterlist.ToList();

                        var parameterValueList = reader.Read<ADM_M030_P>().ToList();
                        MC.ParamValueList = parameterValueList.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "Load")
                    {
                        var ItemData = reader.Read<ZADM_M026>().ToList();
                        MC.ItemEntity = ItemData.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "LoadAll")
                    {
                        var ItemData = reader.Read<ZADM_M026>().ToList();
                        MC.ItemEntity = ItemData.ToList();
                     
                        strReturnData = ObjectSerializationService.ObjectToXML(MC);                     
                    }
                    else if (RequestOption == "LoadAllDetails")
                    {
                        var ItemData = reader.Read<ZADM_M026>().ToList();
                        MC.ItemEntity = ItemData.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
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
        public class MultipleContext_ZADM_M026
        {
            public List<ZADM_M026Flip> DocumentDataFlipGrid { get; set; }
            public List<ZADM_M026> MasterEntity { get; set; }
            public List<ADM_M028_P> SupplierList { get; set; }
            public List<ADM_M028_P> CustomerList{get;set;}
            public List<ADM_M022_P> ItemList { get; set; }
            public List<ADM_M030_P> ParamValueList { get; set; }//Flute Master
            public List<ADM_M031_P> ParameterList { get; set; } //Parameter Master
            public List<ZADM_M026> ItemEntity { get; set; }
            
        }
    }
}
