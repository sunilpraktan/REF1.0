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
    public class ADM_M001_L_BL : ReflectionBusinessLogic
    {
        private static String connectionString;
        MultipleContext_ADM_M001_L MC = new MultipleContext_ADM_M001_L();
        ADM_M001_L MasterEntity = new ADM_M001_L();

        public ADM_M001_L_BL(String BussinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }

        public ADM_M001_L_BL()
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
                    var reader = conn.QueryMultiple("ADM_M001_L_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);
                    if (RequestOption == "LoadInitialData")
                    {
                        var _AssignSalesList = reader.Read<ADM_M001_L>().ToList();
                        MC.AssignSalesList = _AssignSalesList.ToList();

                        var _SOlist = reader.Read<ADM_M001_A_P>().ToList();
                        MC.SOlist = _SOlist.ToList();

                        var _ChannelList = reader.Read<ADM_M001_C_P>().ToList();
                        MC.ChannelList = _ChannelList.ToList();

                        var _DivisionList = reader.Read<ADM_M001_D_P>().ToList();
                        MC.DivisionList = _DivisionList.ToList();

                        var _SalesOfficeList = reader.Read<ADM_M001_I_P>().ToList();
                        MC.SalesOfficeList = _SalesOfficeList.ToList();
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
            ADM_M001_L MasterEntity = new ADM_M001_L();
            MultipleContext_ADM_M001_L MC = new MultipleContext_ADM_M001_L();

            try
            {
                using (IDbConnection Conn = new SqlConnection(connectionString))
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var Reader = conn.QueryMultiple("ADM_M001_L_InsertUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                        var _AssignSalesList = Reader.Read<ADM_M001_L>().ToList();
                        MC.AssignSalesList = _AssignSalesList.ToList();
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

    public class MultipleContext_ADM_M001_L
    {
        public List<ADM_M001_L> AssignSalesList { get; set; }

        public List<ADM_M001_A_P> SOlist { get; set; }

        public List<ADM_M001_C_P> ChannelList { get; set; }

        public List<ADM_M001_D_P> DivisionList { get; set; }

        public List<ADM_M001_I_P> SalesOfficeList { get; set; }


    }
}
