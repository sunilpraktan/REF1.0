using Reflection.EF.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    public class ENG_T003BL : ReflectionBusinessLogic
    {
        MultipleContext_ENG_T003 MC = new MultipleContext_ENG_T003();
       
        private static string connectionString;
        ENG_T003 MasterEntity = new ENG_T003();

        public ENG_T003BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }

        public ENG_T003BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string Insert(string Request)
        {
            String strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ENG_T003Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<ENG_T003Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<ENG_T003>().ToList();
                    List<ENG_T003> Masterlist = MasterData.ToList();

                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    MasterEntity.XmlDataDocument_ENG_T003FLIP = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                    
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
            String strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ENG_T003_Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<ENG_T003Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<ENG_T003>().ToList();
                    List<ENG_T003> Masterlist = MasterData.ToList();

                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    

                    MasterEntity.XmlDataDocument_ENG_T003FLIP = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                   

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

        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            MultipleContext_ENG_T003 MC = new MultipleContext_ENG_T003();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ENG_T003LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);
                    {
                        if (RequestOption == "LoadInitialData")
                        {
                            var FlipGridData = reader.Read<ENG_T003Flip>().ToList();
                            MC.DocumentDataFlipGrid = FlipGridData.ToList();
                        }
                        else if (RequestOption == "LoadDocumentByDocumentNumber")
                        {
                            var MasterList1 = reader.Read<ENG_T003>().ToList();
                            MC.MasterList = MasterList1.ToList();
                           
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
    }
    public class MultipleContext_ENG_T003
    {
        public List<ENG_T003Flip> DocumentDataFlipGrid { get; set; }//Back Flip data
        public List<ENG_T003> MasterList { get; set; }//Master list
              
    }
    public class ENG_T003Flip
    {
        public int id { get; set; }
        public string spec_para_code { get; set; }
        public string parameter { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
    }
}
