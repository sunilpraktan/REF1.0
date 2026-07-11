using Dapper;
using Reflection.EF;
using Reflection.EF.QMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    //public class QMS_T003_BL : ReflectionBusinessLogic
    //{
    //    private static string connectionString;
    //    QMS_T003 masterEntity = new QMS_T003();
    //    MultipleContext_QMS_T003 MC = new MultipleContext_QMS_T003();

    //    public QMS_T003_BL(string BusinessEntity)
    //    {
    //        connectionString = base.ReflectionConnectionString;
    //    }
    //    public QMS_T003_BL()
    //    {
    //        connectionString = base.ReflectionConnectionString;
    //    }
    //    public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
    //    {
    //        try
    //        {
    //            string RequestOption = RequestValue.Split('!')[0];
    //            string strReturnData = "";

    //            using (IDbConnection conn = new SqlConnection(connectionString))
    //            {
    //                var reader = conn.QueryMultiple("QMS_T003_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

    //                if (RequestOption == "LoadInitialData")
    //                {
    //                    var BackFlip = reader.Read<QMS_T003_Flip>().ToList();
    //                    MC.BackFlipData = BackFlip.ToList();

    //                    var ItemData = reader.Read<ADM_M022_P>().ToList();
    //                    MC.ItemMaster = ItemData.ToList();

    //                    var LotOrigin = reader.Read<QMS_P002_P>().ToList();
    //                    MC.LotOriginMaster = LotOrigin.ToList();

    //                    var InspPlan = reader.Read<QMS_M030_P>().ToList();
    //                    MC.InspPlanMaster = InspPlan.ToList();

    //                    var PartyData = reader.Read<ADM_M028_P>().ToList();
    //                    MC.PartyMaster = PartyData.ToList();

    //                    var PurOrgData = reader.Read<ADM_M001_M_P>().ToList();
    //                    MC.PurchaseOrg = PurOrgData.ToList();

    //                    var UnitData = reader.Read<ADM_M038_B_P>().ToList();
    //                    MC.UnitMaster = UnitData.ToList();
    //                }
    //                else if (RequestOption == "LoadDocumentByDocumentNumber")
    //                {
    //                    var MasterData = reader.Read<QMS_T003>().ToList();
    //                    MC.MasterEntity = MasterData.ToList();

    //                }
    //                strReturnData = ObjectSerializationService.ObjectToXML(MC);
    //                return strReturnData;
    //            }
    //        }
    //        catch (SqlException ex)
    //        {
    //            throw new CreateException(ex.ErrorCode, ex.Message, ex);
    //        }
    //        catch (DivideByZeroException ex)
    //        {
    //            throw new CreateException(ex.Message, ex);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new CreateException(ex.Message, ex);
    //        }
    //    }
    //    public string Insert(string Request)
    //    {
    //        try
    //        {
    //            using (IDbConnection conn = new SqlConnection(connectionString))
    //            {
    //                var reader = conn.QueryMultiple("QMS_T003_Insert", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

    //                var BackFlip = reader.Read<QMS_T003_Flip>().ToList();
    //                MC.BackFlipData = BackFlip.ToList();

    //                var masterData = reader.Read<QMS_T003>().ToList();
    //                MC.MasterEntity = masterData.ToList();

    //                masterEntity = MC.MasterEntity[0];
    //                masterEntity.XmlDataDocument_QMS_T003_Flip = ObjectSerializationService.ObjectToXML(MC.BackFlipData);
    //            }
    //            string strReturnData = ObjectSerializationService.ObjectToXML(masterEntity);
    //            return strReturnData;
    //        }
    //        catch (SqlException ex)
    //        {
    //            throw new CreateException(ex.ErrorCode, ex.Message, ex);
    //        }
    //        catch (CreateException ex)
    //        {
    //            throw new CreateException(ex.Message, ex);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new CreateException(ex.Message, ex);
    //        }
    //    }
    //    public string Update(string Request)
    //    {
    //        try
    //        {
    //            string strReturnData = "";
    //            using (IDbConnection conn = new SqlConnection(connectionString))
    //            {
    //                var reader = conn.QueryMultiple("QMS_T003_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

    //                var BackFlip = reader.Read<QMS_T003_Flip>().ToList();
    //                MC.BackFlipData = BackFlip.ToList();

    //                var masterData = reader.Read<QMS_T003>().ToList();
    //                MC.MasterEntity = masterData.ToList();

    //                masterEntity = MC.MasterEntity[0];
    //                masterEntity.XmlDataDocument_QMS_T003_Flip = ObjectSerializationService.ObjectToXML(MC.BackFlipData);
    //            }
    //            strReturnData = ObjectSerializationService.ObjectToXML(masterEntity);
    //            return strReturnData;
    //        }
    //        catch (SqlException ex)
    //        {
    //            throw new CreateException(ex.ErrorCode, ex.Message, ex);
    //        }
    //        catch (CreateException ex)
    //        {
    //            throw new CreateException(ex.Message, ex);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new CreateException(ex.Message, ex);
    //        }
    //    }
    //}

}
