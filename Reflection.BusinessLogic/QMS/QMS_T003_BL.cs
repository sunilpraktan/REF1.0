using System;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Reflection.EF.ADM;
using System.Collections.Generic;
using Reflection.EF.QMS;

namespace Reflection.BusinessLogic.QMS
{
    public class QMS_T003_BL : ReflectionBusinessLogic
    {
        QMS_T003 MasterEntity = new QMS_T003();
        MC_QMS_T003 MC = new MC_QMS_T003();
        public QMS_T003_BL()
        { }

        public string Insert(string Request)
        {
            try
            {
                MC = (MC_QMS_T003)ObjectSerializationService.XMLToObject(Request, MC);
                MasterEntity = MC.MASTER_LIST[0];
                RequestValue = ObjectSerializationService.ObjectToXML(MasterEntity);

                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("QMS_T003_INS", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);
                    MC.MASTER_LIST = reader.Read<QMS_T003>().ToList();
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
        public string Update(string Request)
        {
            try
            {
                MC = (MC_QMS_T003)ObjectSerializationService.XMLToObject(Request, MC);
                MasterEntity = MC.MASTER_LIST[0];
                RequestValue = ObjectSerializationService.ObjectToXML(MasterEntity);

                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("QMS_T003_UPD", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);
                    MC.MASTER_LIST = reader.Read<QMS_T003>().ToList();
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
        public string Delete(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    int intOut = conn.Execute("QMS_T003_DEL", new { @req_no = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);
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
            string RequestOption = RequestValue.Split('!')[0];
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("QMS_T003_GET", new { @Request = RequestValue }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LOAD_INI")
                    {
                        MC.MATERIAL_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.INSP_TYPE_LOT_ORG = reader.Read<QMS_M0047>().ToList();
                        MC.PROCEDURE_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.PERSONNEL_LIST = reader.Read<STD_PERSONNEL>().ToList();
                        MC.FUNC_LOCATION_LIST = reader.Read<STD_LIST_BE>().ToList();
                        MC.DOC_TYPE_LIST = reader.Read<STD_DOC_TYPE>().ToList();
                        MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                        MC.UOM_LIST = reader.Read<UOMS>().ToList();

                    }
                    else if (RequestOption == "LOAD_INI_UD")
                    {
                        MC.CLASS_PROFILE_LIST = reader.Read<Classification>().ToList();
                        MC.USAGE_DECISION = reader.Read<QMS_T003_U>().ToList();
                    }
                    else if (RequestOption == "LOAD_INSP_LOT")
                    {
                        MC.DOC_TYPE_LIST = reader.Read<STD_DOC_TYPE>().ToList();
                        MC.INSP_LOT_LIST = reader.Read<QMS_T003>().ToList();
                        MC.RPT_SETTING = reader.Read<SYS_C0101>().ToList();
                    }
                    else if (RequestOption == "LOAD_INI_SUM_RR")
                    {
                        MC.DOC_TYPE_LIST = reader.Read<STD_DOC_TYPE>().ToList();
                        MC.SUMMURY_RR = reader.Read<QMS_T003_A>().ToList();
                        MC.CHAR_RR = reader.Read<QMS_T003_B>().ToList();
                        MC.SINGLE_RR = reader.Read<QMS_T003_C>().ToList();
                        MC.CLASS_PROFILE_LIST = reader.Read<Classification>().ToList();
                        //MC.CHAR_SPECS_LIST = reader.Read<ENG_T005_B>().ToList();
                        //MC.MASTER_CHAR_LIST = reader.Read<ADM_M0111>().ToList();
                    }
                    if (RequestOption == "EXECUTE_REFERENCE")
                    {
                    }
                    else if (RequestOption == "LOAD_DOC_BY_DOC_NO")
                    {
                    }
                    else if (RequestOption == "LOAD_BACKFLIP")
                    {
                        MC.BACK_FLIP_LIST = reader.Read<STD_LIST_BE>().ToList();
                    }
                    else if (RequestOption == "PRINT_RR")
                    {
                        MC.STD_MIS_LIST = reader.Read<STD_MIS_BE>().ToList();
                    }
                    else if (RequestOption == "REPORT") // Certificate Report
                    {
                        MC.MASTER_LIST = reader.Read<QMS_T003>().ToList();
                        MC.SUMMURY_RR = reader.Read<QMS_T003_A>().ToList();
                        MC.TEST_HEADER = reader.Read<Test_Header>().ToList();
                    }

                    ReturnValue = ObjectSerializationService.ObjectToXML(MC);

                }
                return ReturnValue;
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

    public class MC_QMS_T003 : MC_QMS_BE
    {
        public List<QMS_T003> MASTER_LIST { get; set; }
        public List<QMS_T003_A> SUMMURY_RR { get; set; }
        public List<QMS_T003_B> CHAR_RR { get; set; }
        public List<QMS_T003_C> SINGLE_RR { get; set; }
        public List<QMS_T003_N> DEFECT_RR { get; set; }
        public List<QMS_T003_U> USAGE_DECISION { get; set; }

    }
}
