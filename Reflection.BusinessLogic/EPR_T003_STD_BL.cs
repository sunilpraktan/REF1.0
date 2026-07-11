
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Serialization;
using Reflection.EF.Production;
using Dapper;
using Reflection.EF.Production.ReportEntityProduction;
using Reflection.EF.ReflectionSystem;
using Reflection.EF.Admin;
using Reflection.EF.SCM;
using Reflection.EF.SDM;
using Reflection.EF.ADM;
using Reflection.EF.MM;

namespace Reflection.BusinessLogic
{
    public class EPR_T003_STD_BL : ReflectionBusinessLogic
    {

        EPR_T003_A MasterEntity = new EPR_T003_A();
        MC_EPR_T003 MC = new MC_EPR_T003();
        public string Insert(string Request)
        {
            try
            {
                List<EPR_T003_A> ItemEntityListObj = new List<EPR_T003_A>();
                using (IDbConnection conn = new SqlConnection(base.ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T003_STD_Insert", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    MC.MASTER_ENTITY_LIST = reader.Read<EPR_T003_A>().ToList();
                    //MC.MASTER_ENTITY_HU_LIST = reader.Read<EPR_T003_A>().ToList();
                    //MC.ITEMS_ENTITY_HU_LIST = reader.Read<EPR_T003_A>().ToList();
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
                using (IDbConnection conn = new SqlConnection(base.ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T003_INS_HU", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    MC.MASTER_ENTITY_HU_LIST = reader.Read<EPR_T003_A>().ToList();
                    //MC.MASTER_ENTITY_HU_LIST = reader.Read<EPR_T003_A>().ToList();
                    //MC.ITEMS_ENTITY_HU_LIST = reader.Read<EPR_T003_A>().ToList();

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
                using (IDbConnection conn = new SqlConnection(base.ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T003_INS_MRG", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);

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
                using (IDbConnection conn = new SqlConnection(base.ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T003_UPD", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);
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
                using (IDbConnection conn = new SqlConnection(base.ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T003_UPD_HU", new { @Request = Request }, commandTimeout: 0, commandType: CommandType.StoredProcedure);
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
                using (IDbConnection conn = new SqlConnection(base.ReflectionConnectionString))
                {
                    var reader = conn.QueryMultiple("EPR_T003_STD_LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure, commandTimeout: 0);

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
                    }
                    else if (RequestOption == "LoadHUsForPacking")
                    {
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

    public class MC_EPR_T003 : STD_MC_BE
    {
        public List<SYS_M054> HU_TYPE_LIST { get; set; }
        public List<EPR_T003_A> MASTER_ENTITY_LIST { get; set; }
        public List<EPR_T003_B> ITEMS_ENTITY_LIST { get; set; }
        public List<PPC_M001_P> STD_WC_LIST { get; set; }
        public List<STD_ITEM> STD_ITEM_LIST_PKG { get; set; }
        public List<EPR_T003_A> MASTER_ENTITY_HU_LIST { get; set; }
        public List<EPR_T003_A> ITEMS_ENTITY_HU_LIST { get; set; }
    }

}
