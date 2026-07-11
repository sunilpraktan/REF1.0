using Dapper;
using Reflection.EF;
using Reflection.EF.Admin;
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
    class QMS_M008BL : ReflectionBusinessLogic
    {
        private static string connectionString;

        QMS_M008 MasterEntity = new QMS_M008();
        MultipleContext_QMS_M008 MC = new MultipleContext_QMS_M008();

        public QMS_M008BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public QMS_M008BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            MultipleContext_QMS_M008 MC = new MultipleContext_QMS_M008();
            string RequestOption = RequestValue.Split('!')[0];

            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M008LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);
                    {
                        if (RequestOption == "LoadInitialData")
                        {
                            var BackFlipList = reader.Read<QMS_M008_Flip>().ToList();
                            MC.BackFlipList = BackFlipList.ToList();

                            var LabrotaryList = reader.Read<ADM_M003_B_P>().ToList();
                            MC.LabrotaryList = LabrotaryList.ToList();

                            var ContactPersonList = reader.Read<ADM_M024_P>().ToList();
                            MC.ContactPersonList = ContactPersonList.ToList();

                        }
                        else if (RequestOption == "LoadDocumentByDocumentNumber")
                        {
                            var MasterList = reader.Read<QMS_M008>().ToList();
                            MC.MasterEntity = MasterList.ToList();

                        }
                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        return strReturnData;
                    }
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
            MultipleContext_QMS_M008 MC = new MultipleContext_QMS_M008();
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M008Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<QMS_M008>().ToList();
                    List<QMS_M008> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    var BackFlipList = reader.Read<QMS_M008_Flip>().ToList();
                    MC.BackFlipList = BackFlipList.ToList();

                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.BackFlipList);

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
            MultipleContext_QMS_M008 MC = new MultipleContext_QMS_M008();
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M008Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<QMS_M008>().ToList();
                    List<QMS_M008> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    var BackFlipList = reader.Read<QMS_M008_Flip>().ToList();
                    MC.BackFlipList = BackFlipList.ToList();

                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.BackFlipList);
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
    }
    public class MultipleContext_QMS_M008
    {
        public List<QMS_M008> MasterEntity { get; set; }
        public List<ADM_M024_P> ContactPersonList { get; set; }
        public List<ADM_M003_B_P> LabrotaryList { get; set; }
        public List<QMS_M008_Flip> BackFlipList { get; set; }
    }
}
