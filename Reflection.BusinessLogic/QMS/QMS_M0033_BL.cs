using Dapper;
using Reflection.EF;
using Reflection.EF.ADM;
using Reflection.EF.QMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic.QMS
{
    public class QMS_M0033_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        QMS_M0033 MasterEntity = new QMS_M0033();
        MC_QMS_M0033 MC = new MC_QMS_M0033();

        public QMS_M0033_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public QMS_M0033_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string GetData(string Request, string QueryOption, int intValue, string strValue)
        {
            try
            {
                RequestOption = Request.Split('!')[0];

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M0033_GET", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_INI")
                    {
                        MC.DefectClassList = reader.Read<QMS_M0031>().ToList();
                        MC.ProfileTypeList = reader.Read<QMS_M0032>().ToList(); // Profile/Catlog type
                        MC.CHAR_VALUE_LIST = reader.Read<Classification>().ToList();
                    }
                    else if (RequestOption == "LOAD_DOCUMENT")
                    {
                        MC.MasterList = reader.Read<QMS_M0033>().ToList();
                        MC.ItemsEntity = reader.Read<QMS_M0033_A>().ToList();
                    }
                    else if (RequestOption == "LOAD_BACKFLIP")
                    {
                        MC.BACK_FLIP_LIST = reader.Read<STD_LIST_BE>().ToList();
                    }


                    ReturnValue = ObjectSerializationService.ObjectToXML(MC);
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
                MC = (MC_QMS_M0033)ObjectSerializationService.XMLToObject(Request, MC);
                MasterEntity = MC.MasterList[0];
                MasterEntity.XDOC_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                string Request2 = ObjectSerializationService.ObjectToXML(MasterEntity);

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M0033_INS", new { @Request = Request2 }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    MC.MasterList = reader.Read<QMS_M0033>().ToList();
                    MC.ItemsEntity = reader.Read<QMS_M0033_A>().ToList();
                }
                ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                return ReturnValue;
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
                MC = (MC_QMS_M0033)ObjectSerializationService.XMLToObject(Request, MC);
                MasterEntity = MC.MasterList[0];
                MasterEntity.XDOC_A = ObjectSerializationService.ObjectToXML(MC.ItemsEntity);
                string Request2 = ObjectSerializationService.ObjectToXML(MasterEntity);

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M0033_UPD", new { @Request = Request2 }, commandType: CommandType.StoredProcedure);


                    MC.MasterList = reader.Read<QMS_M0033>().ToList();
                    MC.ItemsEntity = reader.Read<QMS_M0033_A>().ToList();
                }
                ReturnValue = ObjectSerializationService.ObjectToXML(MC);
                return ReturnValue;
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

    public class MC_QMS_M0033 : MC_QMS_BE
    {
        public List<QMS_M0033> MasterList { get; set; }
        public List<QMS_M0033_A> ItemsEntity { get; set; }
        public List<QMS_M0031> DefectClassList { get; set; }
        public List<QMS_M0032> ProfileTypeList { get; set; }
    }
}
