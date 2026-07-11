using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Reflection.EF.CRM;
using System.Threading.Tasks;
using Reflection.EF;

namespace Reflection.BusinessLogic
{
  public  class ZADM_M025BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        ZADM_M025 MasterEntity = new ZADM_M025();
        MultipleContext_ZADM_M025 MC = new MultipleContext_ZADM_M025();

        public ZADM_M025BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ZADM_M025BL()
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

                    var reader = conn.QueryMultiple("ZADM_M025Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<ZADM_M025_Flip>().ToList();
                    MC.BackFlipEntity = FlipGridData.ToList();


                    var MasterData = reader.Read<ZADM_M025>().ToList();
                    MasterEntity=  MasterData[0];

                    var DetailData = reader.Read<ZADM_M025_A>().ToList();
                    MC.AreaEntity = DetailData.ToList();

                    MasterEntity.BackFlipEntity = ObjectSerializationService.ObjectToXML(MC.BackFlipEntity);
                    MasterEntity.XmlDataDocumentZADM_M025_A = ObjectSerializationService.ObjectToXML(MC.AreaEntity);
                  



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

                    var reader = conn.QueryMultiple("ZADM_M025Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<ZADM_M025_Flip>().ToList();
                    MC.BackFlipEntity = FlipGridData.ToList();


                    var MasterData = reader.Read<ZADM_M025>().ToList();
                    MasterEntity = MasterData[0];

                    var DetailData = reader.Read<ZADM_M025_A>().ToList();
                    MC.AreaEntity = DetailData.ToList();

                    MasterEntity.BackFlipEntity = ObjectSerializationService.ObjectToXML(MC.BackFlipEntity);
                    MasterEntity.XmlDataDocumentZADM_M025_A = ObjectSerializationService.ObjectToXML(MC.AreaEntity);



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
        public string Delete(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("ZADM_M025Delete", new { @doc_no = Request }, commandType: CommandType.StoredProcedure);
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
        public string GetData(string RequestValue, string strType, int intValue, string strValue)
        {
            MultipleContext_ZADM_M025 MC = new MultipleContext_ZADM_M025();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZADM_M025LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var FlipEntity = reader.Read<ZADM_M025_Flip>().ToList();
                        MC.BackFlipEntity = FlipEntity.ToList();

                        var ItemCollection = reader.Read<ADM_M022_P>().ToList();
                        MC.ItemListPopup = ItemCollection.ToList();

                        var LocationCollection = reader.Read<ADM_M003_P>().ToList();
                        MC.LocationMaster = LocationCollection.ToList();



                     strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if(RequestOption== "LoadDocumentWithDocumentNumber")
                    {
                        var MasterData = reader.Read<ZADM_M025>().ToList();
                          MC.MasterEntity = MasterData;

                        var DetailData = reader.Read<ZADM_M025_A>().ToList();
                        MC.AreaEntity = DetailData.ToList();
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



    }

    public class MultipleContext_ZADM_M025
    {
        public List<ZADM_M025> MasterEntity { get; set; }
        public List<ZADM_M025_A> AreaEntity { get; set; }
        public List <ZADM_M025_Flip> BackFlipEntity { get; set; }
        public List<ADM_M022_P> ItemListPopup { get; set; }
        public List<ADM_M003_P> LocationMaster { get; set; }
        public List<ADM_M001_A_P> SalesOrg { get; set; }
        public List<ADM_M001_H_P> SalesGroup { get; set; }

    }
}
