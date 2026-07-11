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
    public class QMS_M033_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        QMS_M0033 masterEntity = new QMS_M0033();
        //MultipleContext_QMS_M033 MC = new MultipleContext_QMS_M033();

        public QMS_M033_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public QMS_M033_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            try
            {
                string RequestOption = RequestValue.Split('!')[0];

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M033_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    //if (RequestOption == "LoadInitialData")
                    //{
                    //    MC.CatlogMaster = reader.Read<QMS_M032_P>().ToList();
                    //    MC.DefectClassMaster = reader.Read<QMS_M031_P>().ToList();
                    //    MC.BackFlipData = reader.Read<QMS_M033_Flip>().ToList();
                    //    MC.CodeMaster = reader.Read<QMS_M009_G_P>().ToList();
                    //}

                    //else if (RequestOption == "LoadDocumentByDocumentNumber")
                    //{
                    //    var MasterData = reader.Read<QMS_M0033>().ToList();
                    //    MC.MasterEntity = MasterData.ToList();

                    //    var ItemsData = reader.Read<QMS_M0033_A>().ToList();
                    //    MC.ItemsEntity = ItemsData.ToList();
                    //}
                    //else if(RequestOption == "LoadGroupCode")
                    //{
                    //    var Groupcode = reader.Read<QMS_M009_G_P>().ToList();
                    //    MC.GroupCodeData = Groupcode.ToList();
                    //}

                    //else if (RequestOption == "LoadCode")
                    //{
                    //    var CodeData = reader.Read<QMS_M009_G_P>().ToList();
                    //    MC.CodeMaster = CodeData.ToList();
                    //}

                    //    ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                    return ReturnValue;
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
        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M033_Insert", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    //var BackFlip = reader.Read<QMS_M033_Flip>().ToList();
                    //MC.BackFlipData = BackFlip.ToList();

                    //var masterData = reader.Read<QMS_M0033>().ToList();
                    //List<QMS_M0033> MasterList = masterData.ToList();
                    //if (MasterList.Count > 0)
                    //{
                    //    masterEntity = MasterList[0];
                    //}

                    //var ItemsData = reader.Read<QMS_M0033_A>().ToList();
                    //MC.ItemsEntity = ItemsData.ToList();

                    //masterEntity.XmlDataDocument_QMS_M033_Flip = ObjectSerializationService.ObjectToXML(MC.BackFlipData);
                    //masterEntity.XmlDataDocument_QMS_M033_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                   
                   }
                string strReturnData = ObjectSerializationService.ObjectToXML(masterEntity);
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
                    var reader = conn.QueryMultiple("QMS_M033_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    //var BackFlip = reader.Read<QMS_M033_Flip>().ToList();
                    //MC.BackFlipData = BackFlip.ToList();

                    //var masterData = reader.Read<QMS_M0033>().ToList();
                    //MC.MasterEntity = masterData.ToList();

                    //var ItemData = reader.Read<QMS_M0033_A>().ToList();
                    //MC.ItemsEntity = ItemData.ToList();

                    //masterEntity = MC.MasterEntity[0];
                    //masterEntity.XmlDataDocument_QMS_M033_Flip = ObjectSerializationService.ObjectToXML(MC.BackFlipData);
                    //masterEntity.XmlDataDocument_QMS_M033_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
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
    }

    //public class MultipleContext_QMS_M033
    //{
    //    public List<QMS_M032_P> CatlogMaster { get; set; }
    //    public List<QMS_M031_P> DefectClassMaster { get; set; }
    //    public List<QMS_M033_Flip> BackFlipData { get; set; }
    //    public List<QMS_M0033> MasterEntity { get; set; }
    //    public List<QMS_M0033_A> ItemsEntity { get; set; }
    //    public List<QMS_M009_G_P> GroupCodeData { get; set; }
    //    public List<QMS_M009_G_P> CodeMaster { get; set; }
    //}
}
