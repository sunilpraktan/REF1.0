using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using Reflection.EF.Admin;
using System.Data;
using Dapper;
namespace Reflection.BusinessLogic
{//
    public class ADM_M034BL : ReflectionBusinessLogic
    {
       
        ADM_M034 aDM_M034 = new ADM_M034();
        private static string connectionString;
        MultipleContextADM_M034 MC = new MultipleContextADM_M034();
        public ADM_M034BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }

        public ADM_M034BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                aDM_M034 = (ADM_M034)ObjectSerializationService.XMLToObject(Request, aDM_M034);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M034Insert", new
                    {
                        @para_code = aDM_M034.para_code,
                        @SubCatCode = aDM_M034.SubCatCode,
                        @active = aDM_M034.active,
                        @add_by = aDM_M034.add_by,
                    }, commandType: CommandType.StoredProcedure);

                    var Item1 = reader.Read<ADM_M034>().ToList();
                    List<ADM_M034> Item = Item1.ToList();
                    if (Item.Count > 0)
                    {
                        aDM_M034 = Item[0];
                    }
                    //else
                    //{
                    //    aDM_M034 = new ADM_M034();
                    //}
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(aDM_M034);
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

                aDM_M034 = (ADM_M034)ObjectSerializationService.XMLToObject(Request, aDM_M034);
                int intOut = 0;//dbContext.ADM_M034Update(aDM_M034.id,aDM_M034.CatParamCode, aDM_M034.CatParamName, aDM_M034.SubCatCode, aDM_M034.Status, aDM_M034.UserId);
                return intOut.ToString();
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
                int intOut = 0;// dbContext.ADM_M034Delete(Request);
                return intOut.ToString();
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
            MultipleContextADM_M034 MC = new MultipleContextADM_M034();
            try
            {
               
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M034LoadAll", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    var PARAM = reader.Read<ADM_M034>().ToList();
                    MC.PARAM = PARAM.ToList();

                    var Subcat = reader.Read<ADM_M019>().ToList();
                    MC.Subcat = Subcat.ToList();

                    var Param = reader.Read<ADM_M031>().ToList();
                    MC.ParamList = Param.ToList();
                }
                string strData = ObjectSerializationService.ObjectToXML(MC);
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
    public class MultipleContextADM_M034
    {
        public List<ADM_M034> PARAM { get; set; }
        public List<ADM_M019> Subcat { get; set; }
        public List<ADM_M031> ParamList { get; set; }////Parameter Master    
    }
}
