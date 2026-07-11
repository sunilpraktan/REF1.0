using System.Linq;
using System.Data;
using Reflection.EF.SCM;
using Dapper;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using Reflection.EF;
using Reflection.EF.Communication;
using Reflection.EF.ReflectionSystem;

namespace Reflection.BusinessLogic
{
    public class MM_T001BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        MC_MM_T001 MC = new MC_MM_T001();
        MM_T001 masterEntity = new MM_T001();

        public MM_T001BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }

        public MM_T001BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string Insert(string Request)
        {
            try
            {
                string strReturnData = "";
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("MM_T001_PC_Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure,commandTimeout:0);


                    var FlipGridData = reader.Read<MM_T001Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<MM_T001>().ToList();
                    MC.MasterEntity = MasterData.ToList();

                    var ItemsData = reader.Read<MM_T001_A>().ToList();
                    MC.ItemsEntity = ItemsData.ToList();

                    masterEntity = MC.MasterEntity[0];
                    masterEntity.XmlDataDocument_MM_T001_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                    masterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);

                }
                strReturnData = ObjectSerializationService.ObjectToXML(masterEntity);
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
                    var reader = conn.QueryMultiple("MM_T001_PC_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure,commandTimeout: 0);

                    var FlipGridData = reader.Read<MM_T001Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<MM_T001>().ToList();
                    MC.MasterEntity = MasterData.ToList();
                    masterEntity = MC.MasterEntity[0];

                    var ItemData = reader.Read<MM_T001_A>().ToList();
                    MC.ItemsEntity = ItemData.ToList();

                    masterEntity.XmlDataDocument_MM_T001_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                    masterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                }
                strReturnData = ObjectSerializationService.ObjectToXML(masterEntity);
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
                    int intOut = conn.Execute("MM_T001_PC_Delete", new { @doc_no = Request }, commandType: CommandType.StoredProcedure);
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
            MC_MM_T001 MC = new MC_MM_T001();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("MM_T001_PC_LoadAll", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var IldData = reader.Read<ZADM_M007_P>().ToList();
                        MC.IldDetails = IldData.ToList();

                        var FlipGridData = reader.Read<MM_T001Flip>().ToList();
                        MC.DocumentDataFlipGrid = FlipGridData.ToList();

                        var MovementData = reader.Read<MM_M004_P>().ToList();
                        MC.MovementDetails = MovementData.ToList();

                        var InkData = reader.Read<ZADM_M006_P>().ToList();
                        MC.InkDetails = InkData.ToList();

                        

                        var GradeData = reader.Read<ADM_M045_P>().ToList();
                        MC.GradeDetails = GradeData.ToList();

                        var SourceItemData = reader.Read<ADM_M022_POPUP>().ToList();
                        MC.SourceItemDetails = SourceItemData.ToList();

                        var RMItemData = reader.Read<ADM_M022_POPUP>().ToList();
                        MC.RMItemDetails = RMItemData.ToList();

                        var ParameterData = reader.Read<ADM_M031_P>().ToList();
                        MC.ParameterDetails = ParameterData.ToList();

                        var ParaValueData = reader.Read<ADM_M030_P>().ToList();
                        MC.ParameterValueDetails = ParaValueData.ToList();

                        var UOMData = reader.Read<ADM_M038_B_P>().ToList();
                        MC.UOMDetails = UOMData.ToList();

                        var MakeData = reader.Read<ADM_M030_P>().ToList();
                        MC.MakeDetails = MakeData.ToList();

                        var TypeData = reader.Read<ADM_M030_P>().ToList();
                        MC.TypeDetails = TypeData.ToList();

                        var MaterialCondition = reader.Read<ADM_M030_P>().ToList();
                        MC.MaterialConditionDetails = MaterialCondition.ToList();
                    }
                    if (RequestOption == "LoadDocumentByDocumentNumber")
                    {

                        var MasterData = reader.Read<MM_T001>().ToList();
                        MC.MasterEntity = MasterData.ToList();

                        var ItemData = reader.Read<MM_T001_A>().ToList();
                        MC.ItemsEntity = ItemData.ToList();
                        
                        var Attachment = reader.Read<COM_T003>().ToList();
                        MC.AttachmentData = Attachment.ToList();
                    }
                    if(RequestOption== "LoadFromDateToDate")
                    {
                        var FlipGridData = reader.Read<MM_T001Flip>().ToList();
                        MC.DocumentDataFlipGrid = FlipGridData.ToList();
                    }

                    if(RequestOption== "LoadFromProductionDateAndGrade")
                    {
                        var itemsEntity = reader.Read<MM_T001_A>().ToList();
                        MC.ItemsEntity = itemsEntity.ToList();

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
    }

}