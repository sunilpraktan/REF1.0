using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.Admin;
using Dapper;

namespace Reflection.BusinessLogic
{
     public class ADM_M028_E_BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        MultipleContext_ADM_M028_E MC = new MultipleContext_ADM_M028_E();
        ADM_M028_E MasterEntity = new ADM_M028_E();

        public ADM_M028_E_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M028_E_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string GetData(string RequestValue, string strType, int intValue, string strValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M028_E_LoadAll", new { @Request = RequestValue }, commandTimeout: 600, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var _PartyList = reader.Read<ADM_M028_E>().ToList();
                        MC.PartyList = _PartyList.ToList();

                        var _CountryList = reader.Read<ADM_M012_P>().ToList();
                        MC.CountryList = _CountryList.ToList();

                        var _BankcodeList = reader.Read<ACC_M004_P>().ToList();
                        MC.BankcodeList = _BankcodeList.ToList();

                        var _PartyIDList = reader.Read<ADM_M028_P>().ToList();
                        MC.PartyIDList = _PartyIDList.ToList();

                       


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
            ADM_M028_E MasterEntity = new ADM_M028_E();
            MultipleContext_ADM_M028_E MC = new MultipleContext_ADM_M028_E();
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M028_E_InsertUpdate", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var _PartyList = reader.Read<ADM_M028_E>().ToList();
                    MC.PartyList = _PartyList.ToList();

                }
                strReturnData = ObjectSerializationService.ObjectToXML(MC);
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
    public class MultipleContext_ADM_M028_E
    {
        public List<ADM_M028_E> PartyList { get; set; }  //Details Entity List 

        public List<ADM_M012_P> CountryList { get; set; }

        public List<ACC_M004_P> BankcodeList { get; set; }

        public List<ADM_M028_P> PartyIDList { get; set; }

        public List<ADM_M028_J_P> BussGroupList { get; set; }



    }

}
