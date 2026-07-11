using Dapper;
using Reflection.EF;
using Reflection.EF.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    public class ADM_M001_E_BL : ReflectionBusinessLogic
    {
        private static String connectionString;
        MultipleContext_ADM_M001_E MC = new MultipleContext_ADM_M001_E();
        ADM_M001_E MasterEntity = new ADM_M001_E();

        public ADM_M001_E_BL(String BussinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }

        public ADM_M001_E_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string GetData(string RequestValue, string strType, int intValue, string srtValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M001_E_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);
                    if (RequestOption == "LoadInitialData")
                    {
                        var _AssignDClist = reader.Read<ADM_M001_E>().ToList();
                        MC.AssignDClist = _AssignDClist.ToList();

                        var _ChannelList = reader.Read<ADM_M001_C_P>().ToList();
                        MC.ChannelList = _ChannelList.ToList();

                        var _SOlist = reader.Read<ADM_M001_A_P>().ToList();
                        MC.SOlist = _SOlist.ToList();
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
            string strReturnData = "";
            ADM_M001_E MasterEntity = new ADM_M001_E();
            MultipleContext_ADM_M001_E MC = new MultipleContext_ADM_M001_E();

            try
            {
                using (IDbConnection Conn = new SqlConnection(connectionString))
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var Reader = conn.QueryMultiple("ADM_M001_E_InsertUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                        var _AssignDClist = Reader.Read<ADM_M001_E>().ToList();
                        MC.AssignDClist = _AssignDClist.ToList();
                    }

                    strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    return strReturnData;
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

    public class MultipleContext_ADM_M001_E
    {
        public List<ADM_M001_E> AssignDClist { get; set; }

        public List<ADM_M001_C_P> ChannelList { get; set; }

        public List<ADM_M001_A_P> SOlist { get; set; }
    }

}

