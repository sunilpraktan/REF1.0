using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.Production;
using Dapper;
using Reflection.EF.ReflectionSystem;
using Reflection.EF.ADM;
using Reflection.EF.MM;

namespace Reflection.BusinessLogic.MM
{
    public class MM_T007_BL : ReflectionBusinessLogic
    {
        EPR_T003_A MasterEntity = new EPR_T003_A();
        MC_EPR_T003 MC = new MC_EPR_T003();
        public MM_T007_BL()
        { }

        public string Insert(string Request)
        {
            try
            {
                List<EPR_T003_A> ItemEntityListObj = new List<EPR_T003_A>();
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T003_INS", new { @Request = Request }, commandTimeout: 300, commandType: CommandType.StoredProcedure);

                    MC.MASTER_ENTITY_LIST = reader.Read<EPR_T003_A>().ToList();
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
        public string Insert_HU(string Request)
        {
            try
            {
                List<EPR_T003_A> ItemEntityListObj = new List<EPR_T003_A>();
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T003_INS_HU", new { @Request = Request }, commandTimeout: 300, commandType: CommandType.StoredProcedure);

                    MC.MASTER_ENTITY_HU_LIST = reader.Read<EPR_T003_A>().ToList();
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
        public string Insert_Merge(string Request)
        {
            try
            {
                List<EPR_T003_A> ItemEntityListObj = new List<EPR_T003_A>();
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T003_INS_MRG", new { @Request = Request }, commandTimeout: 300, commandType: CommandType.StoredProcedure);

                    MC.MASTER_ENTITY_HU_LIST = reader.Read<EPR_T003_A>().ToList();
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
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T003_UPD", new { @Request = Request }, commandType: CommandType.StoredProcedure);
                    MasterEntity = reader.Read<EPR_T003_A>().ToList()[0];
                    MC.ITEMS_ENTITY_LIST = reader.Read<EPR_T003_B>().ToList();
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
        public string Update_HU(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T003_UPD_HU", new { @Request = Request }, commandType: CommandType.StoredProcedure);
                    MasterEntity = reader.Read<EPR_T003_A>().ToList()[0];
                    MC.ITEMS_ENTITY_LIST = reader.Read<EPR_T003_B>().ToList();
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
        public string GetData(string RequestValue, string strType, int intValue, string strValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            string strData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T003_GET", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure, commandTimeout: 600);

                    if (RequestOption == "LoadInitialData")
                    {
                        MC.DOC_TYPE_LIST = reader.Read<STD_DOC_TYPE>().ToList();
                        MC.DOC_TYPE_SETTINGS_LIST = reader.Read<STD_DOC_TYPE_SETTINGS>().ToList();
                        MC.STD_ITEM_LIST = reader.Read<STD_ITEM>().ToList();
                        MC.HU_TYPE_LIST = reader.Read<SYS_M054>().ToList();
                        MC.UOM_LIST = reader.Read<UOMS>().ToList();
                        MC.STORE_LIST = reader.Read<MM_M0001>().ToList();
                        MC.STATUS_LIST = reader.Read<ADM_M0013>().ToList();
                        MC.STD_WC_LIST = reader.Read<PPC_M001_P>().ToList();
                        MC.STD_ITEM_LIST_PKG = reader.Read<STD_ITEM>().ToList();
                        //MC.STD_PERSONNEL_LIST = reader.Read<STD_PERSONNEL>().ToList();
                    }
                    else if (RequestOption == "LoadMaterialForPacking")
                    {
                        MC.ITEMS_ENTITY_LIST = reader.Read<EPR_T003_B>().ToList();
                        MC.ITEMS_ENTITY_HU_LIST = reader.Read<EPR_T003_A>().ToList();
                    }
                    else if (RequestOption == "LoadMaterialForPackingOnBarcodeScanning")
                    {
                        MC.ITEMS_ENTITY_LIST = reader.Read<EPR_T003_B>().ToList();
                    }
                    else if (RequestOption == "LOAD_HU_VIEW_DATA" || RequestOption == "LOAD_TRACE_DATA")
                    {
                        MC.MASTER_ENTITY_HU_LIST = reader.Read<EPR_T003_A>().ToList();
                    }
                    else if (RequestOption == "MakeEmptyHU")
                    {
                        MC = new MC_EPR_T003();
                        //MC.MASTER_ENTITY_HU_LIST = reader.Read<EPR_T003_A>().ToList();
                    }
                    else if (RequestOption == "Update_Print_Indicator")
                    {
                        MC = new MC_EPR_T003();
                        //MC.MASTER_ENTITY_HU_LIST = reader.Read<EPR_T003_A>().ToList();
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
}
