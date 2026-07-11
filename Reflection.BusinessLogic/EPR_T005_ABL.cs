using Dapper;
using Reflection.EF;
using Reflection.EF.Communication;
using Reflection.EF.Production;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    class EPR_T005_ABL : ReflectionBusinessLogic
    {
        private static string connectionString;
        MultipleContext_EPR_T005_A MC = new MultipleContext_EPR_T005_A();
        EPR_T005_A MasterEntity = new EPR_T005_A();

        public EPR_T005_ABL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }

        public EPR_T005_ABL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            MultipleContext_EPR_T005_A MC = new MultipleContext_EPR_T005_A();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T005_ALoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var flipGridData = reader.Read<EPR_T005_A_Flip>().ToList();
                        MC.DocumentDataFlipGrid = flipGridData.ToList();

                        var parameterDetails = reader.Read<EPR_T005>().ToList();
                        MC.ParameterDetails = parameterDetails.ToList();

                        MC.ParameterValues = reader.Read<ADM_M030_P>().ToList();
                    }
                    if (RequestOption == "LoadDocumentByDocumentNumber")
                    {

                        var masterData = reader.Read<EPR_T005_A>().ToList();
                        MC.MasterEntity = masterData.ToList();

                        var itemData = reader.Read<EPR_T005_B>().ToList();
                        MC.ItemsEntity = itemData.ToList();

                        var attachmentData = reader.Read<COM_T003>().ToList();
                        MC.AttachmentData = attachmentData.ToList();
                    }

                }
                strReturnData = ObjectSerializationService.ObjectToXML(MC);
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
        public string Insert(string Request)
        {
            try
            {
                string strReturnData = "";
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T005_AInsert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var flipGridData = reader.Read<EPR_T005_A_Flip>().ToList();
                    MC.DocumentDataFlipGrid = flipGridData.ToList();

                    var masterData = reader.Read<EPR_T005_A>().ToList();
                    MC.MasterEntity = masterData.ToList();

                    var itemData = reader.Read<EPR_T005_B>().ToList();
                    MC.ItemsEntity = itemData.ToList();

                    MasterEntity = MC.MasterEntity[0];
                    MasterEntity.XmlDataDocument_EPR_T005_B = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
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
            try
            {
                string strReturnData = "";
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T005_AUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<EPR_T005_A_Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<EPR_T005_A>().ToList();
                    MC.MasterEntity = MasterData.ToList();
                    MasterEntity = MC.MasterEntity[0];

                    var ItemData = reader.Read<EPR_T005_B>().ToList();
                    MC.ItemsEntity = ItemData.ToList();

                    MasterEntity.XmlDataDocument_EPR_T005_B = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
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
                    int intOut = conn.Execute("EPR_T005_ADelete", new { @doc_no = Request }, commandType: CommandType.StoredProcedure);
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
    }

    public class MultipleContext_EPR_T005_A
    {
        public List<EPR_T005_A_Flip> DocumentDataFlipGrid { get; set; }
        public List<EPR_T005> ParameterDetails { get; set; }
        public List<EPR_T005_A> MasterEntity { get; set;}
        public List<EPR_T005_B> ItemsEntity { get; set; }
        public List<COM_T003> AttachmentData { get; set; }
        public List<ADM_M030_P> ParameterValues { get; set; }
    }
}
