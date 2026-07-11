using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Reflection.EF.ADM;
using Reflection.EF.Admin;
using Reflection.EF.QMS;

namespace Reflection.BusinessLogic.QMS
{
   public class QMS_M0044_BL:ReflectionBusinessLogic//reference BL
    {
        MC_QMS_M0044 MC = new MC_QMS_M0044();
        public QMS_M0044_BL()
        {

        }
        public string Insert(string Request)
        {
            try
            {

                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M0044_INS", new { Request = Request }, commandTimeout: 300, commandType: CommandType.StoredProcedure);
                    MC.MASTER_LIST = reader.Read<QMS_M0044>().ToList();
                }
                return ObjectSerializationService.ObjectToXML(MC);

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
            string RequestOption = RequestValue.Split('!')[0];
            string strData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M0044_GET", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure, commandTimeout: 600);

                    if (RequestOption == "LOAD_INI")
                    {

                        MC.MASTER_LIST = reader.Read<QMS_M0044>().ToList();
                        MC.ITEM_LIST = reader.Read<STD_ITEM>().ToList();





                    }

                }
                strData = ObjectSerializationService.ObjectToXML(MC);

                return strData;
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
    public class MC_QMS_M0044 : MC_QMS_BE
    {
        public List<QMS_M0044> MASTER_LIST { get; set; }
    }
}
