using Dapper;
using Reflection.EF;
using Reflection.EF.ADM;
using Reflection.EF.Communication;
using Reflection.EF.Finance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Reflection.BusinessLogic.FICO
{
    public class ACC_T006_BL : ReflectionBusinessLogic
    {
        ACC_T006 MasterEntity = new ACC_T006();
        MultipleContext_ACC_T006 MC = new MultipleContext_ACC_T006();
        public ACC_T006_BL()
        { }

        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("ACC_T006_INS", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    List<ACC_T006> Masterlist = reader.Read<ACC_T006>().ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }
                    MC.DetailData = reader.Read<ACC_T006_A>().ToList();
                    MasterEntity.XmlDataDocument_ACC_T006_A = ObjectSerializationService.ObjectToXML(MC.DetailData);
                }
                return ObjectSerializationService.ObjectToXML(MasterEntity);
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
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("ACC_T006_UPD", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    List<ACC_T006> Masterlist = reader.Read<ACC_T006>().ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    MC.DetailData = reader.Read<ACC_T006_A>().ToList();

                    MasterEntity.XmlDataDocument_ACC_T006_A = ObjectSerializationService.ObjectToXML(MC.DetailData);
                }

                return ObjectSerializationService.ObjectToXML(MasterEntity);
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
                    int intOut = conn.Execute("ACC_T006_DEL", new { @id = Request }, commandType: CommandType.StoredProcedure);
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
        public string GetData(string RequestValue, string strType, int intValue, string strValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            try
            {
                if (RequestOption == "GetLedgerView")
                {
                    using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                    {
                        var reader = conn.QueryMultiple("ACC_T006_GET_LGR", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);
                        MC.MasterData = reader.Read<ACC_T006>().ToList();
                        MC.DetailData = reader.Read<ACC_T006_A>().ToList();
                    }
                    return ObjectSerializationService.ObjectToXML(MC);
                }

                else
                {
                    using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                    {
                        var reader = conn.QueryMultiple("ACC_T006_GET", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                        if (RequestOption == "LOAD_INI")
                        {
                            MC.PartyMaster = reader.Read<ADM_M028_P>().ToList();
                            MC.RefDocData = reader.Read<SEL_T003_PUR_T005_RefDoc>().ToList();
                            MC.CurrencyMaster = reader.Read<ADM_M037_P>().ToList();
                            MC.GLCodeMaster = reader.Read<ACC_M003_P>().ToList();
                            MC.CostCenterMaster = reader.Read<ACC_M019_P>().ToList();
                            MC.BanksMaster = reader.Read<ACC_M004_P>().ToList();
                            MC.GeneralLedgerList = reader.Read<General_Ledger_P>().ToList();
                            MC.PostingKeyList = reader.Read<ACC_M003_Q_P>().ToList();
                            MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                            MC.DocTypeList = reader.Read<SYS_M015_P>().ToList();
                            MC.DOC_TYPE_LIST = reader.Read<STD_DOC_TYPE>().ToList();
                            MC.PayMethodList = reader.Read<ACC_M027_P>().ToList();
                            MC.REF_DOC_LIST = reader.Read<STD_LIST_BE>().ToList();
                        }
                        else if (RequestOption == "LOAD_INI_VR")
                        {
                            MC.CurrencyMaster = reader.Read<ADM_M037_P>().ToList();
                            MC.GLCodeMaster = reader.Read<ACC_M003_P>().ToList();
                            MC.CostCenterMaster = reader.Read<ACC_M019_P>().ToList();
                            MC.GeneralLedgerList = reader.Read<General_Ledger_P>().ToList();
                            MC.PostingKeyList = reader.Read<ACC_M003_Q_P>().ToList();
                            MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                            MC.DOC_TYPE_LIST = reader.Read<STD_DOC_TYPE>().ToList();
                        }
                        else if (RequestOption == "LOAD_DOCUMENT")
                        {
                            MC.MasterData = reader.Read<ACC_T006>().ToList();
                            MC.DetailData = reader.Read<ACC_T006_A>().ToList();
                        }
                        else if (RequestOption == "EXECUTE_REFERENCE")
                        {
                            MC.MasterData = reader.Read<ACC_T006>().ToList();
                            MC.DetailData = reader.Read<ACC_T006_A>().ToList();
                        }
                        else if (RequestOption == "LOAD_BACKFLIP")
                        {
                            MC.BACK_FLIP_LIST = reader.Read<STD_LIST_BE>().ToList();
                        }
                    }
                    return ObjectSerializationService.ObjectToXML(MC);
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
}
