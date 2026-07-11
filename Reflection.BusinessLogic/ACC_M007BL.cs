using Dapper;
using Reflection.EF;
using Reflection.EF.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Reflection.BusinessLogic
{
    public class ACC_M007BL: ReflectionBusinessLogic
    {//
        MC_ACC_M007 MC = new MC_ACC_M007();

        private static string connectionString;
        ACC_M007 MasterEntity = new ACC_M007();

        public ACC_M007BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }

        public ACC_M007BL()
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
                    var reader = conn.QueryMultiple("ACC_M007_INS", new { @Request = Request }, commandType: CommandType.StoredProcedure, commandTimeout:0);
                    
                    var MasterData = reader.Read<ACC_M007>().ToList();
                    List<ACC_M007> Masterlist = MasterData.ToList();
                   
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
                    MC.ItemsList = reader.Read<ACC_M007_A>().ToList();

                    MasterEntity.XDOC_A = ObjectSerializationService.ObjectToXML(MC.ItemsList);
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
                    var reader = conn.QueryMultiple("ACC_M007_UPD", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<ACC_M007>().ToList();
                    List<ACC_M007> Masterlist = MasterData.ToList();
                   
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    MC.ItemsList = reader.Read<ACC_M007_A>().ToList();

                    MasterEntity.XDOC_A = ObjectSerializationService.ObjectToXML(MC.ItemsList);

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
        public string Delete(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = 0;// conn.Execute("CAL_M002_Delete", new { @doc_no = Request }, commandType: CommandType.StoredProcedure);
                    return intOut.ToString();
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
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            MC_ACC_M007 MC = new MC_ACC_M007();
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ACC_M007_GET", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);
                    {
                        if (RequestOption == "LOAD_INI")
                        {
                            MC.BACK_FLIP_LIST = reader.Read<STD_LIST_BE>().ToList();
                        }
                        if (RequestOption == "LOAD_DOCUMENT")
                        {
                            MC.MasterList = reader.Read<ACC_M007>().ToList();
                            MC.ItemsList = reader.Read<ACC_M007_A>().ToList();
                        }
                        else if (RequestOption == "LOAD_BACKFLIP")
                        {
                            MC.BACK_FLIP_LIST = reader.Read<STD_LIST_BE>().ToList();
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
    public class MC_ACC_M007 : MC_FICO_BE
    {
        public List<ACC_M007> MasterList  { get; set; }//Master list
        public List<ACC_M007_A> ItemsList { get; set; }  //Details Entity List            
    }


  
    //public class ACC_M007_Flip
    //{
    //    public string p_term_code { get; set; }
    //    public string p_term { get; set; }
    //    public string p_note { get; set; }
    //    public Nullable<bool> active { get; set; }
    //}
}
