using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Serialization;
using Reflection.EF.SCM;
using Reflection.EF.CRM;
using Reflection.EF.Procurement;
using Dapper;
using Reflection.EF.SCM.ReportEntitySCM;
using Reflection.EF.ADM;

namespace Reflection.BusinessLogic
{
    public class GEN_T009_BL : ReflectionBusinessLogic
    {
        GEN_T009 MasterEntity = new GEN_T009();
        private static string connectionString;
        MultipleContext_GEN_T009 MC = new MultipleContext_GEN_T009();

        public GEN_T009_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public GEN_T009_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }

        public string Insert(string Request)
        {
            MultipleContext_GEN_T009 MC = new MultipleContext_GEN_T009();
            string strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("GEN_T009_Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var _MasterData = reader.Read<GEN_T009>().ToList();
                    MC.MasterEntity = _MasterData.ToList();
                    if (MC.MasterEntity.Count > 0)
                    {
                        MasterEntity = MC.MasterEntity[0];
                    }
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
        public string GetData(string RequestValue, string strType, int intValue, string strValue)
        {
            string RequestOption = RequestValue.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("GEN_T009_LoadAll", new { @request = RequestValue }, commandType: CommandType.StoredProcedure);


                    if (RequestOption == "LoadInitialData")
                    {
                        var _BackFlipEntity = reader.Read<GEN_T009_BackFlip>().ToList();
                        MC.BackFlipEntity = _BackFlipEntity.ToList();

                        var Sales_Invoice_Reference = reader.Read<SEL_T003_P_RefDoc>().ToList();
                        MC.Sales_Invoice_Reference = Sales_Invoice_Reference.ToList();

                        var _statuslist = reader.Read<ADM_M0013>().ToList();
                        MC.StatusList = _statuslist.ToList();

                        var _refwaybill = reader.Read<GEN_T009_P>().ToList();
                        MC.waybill = _refwaybill.ToList();
                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var _MasterData = reader.Read<GEN_T009>().ToList();
                        MC.MasterEntity = _MasterData.ToList();

                        //var _DetailData = reader.Read<HRM_M015_A>().ToList();
                        //MC.DetailData = _DetailData.ToList();
                    }
                    else if (RequestOption == "LoadDocumentWithReferenceDocumentNumber")
                    {
                        //var _MasterData = reader.Read<GEN_T009>().ToList();
                        //MC.MasterEntity = _MasterData.ToList();
                        var _SalesData = reader.Read<SEL_T003>().ToList();
                        MC.SalesData = _SalesData.ToList();
                        var ItemDetails = reader.Read<SEL_T003_A>().ToList();
                        MC.ItemsEntity = ItemDetails.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        return strReturnData;
                    }
                    else if (RequestOption == "LoadDocumentFromDeliveryNumber")
                    {
                        //var _MasterData = reader.Read<GEN_T009>().ToList();
                        //MC.MasterEntity = _MasterData.ToList();
                        var _SalesData = reader.Read<SEL_T003>().ToList();
                        MC.SalesData = _SalesData.ToList();
                        var ItemDetails = reader.Read<SEL_T003_A>().ToList();
                        MC.ItemsEntity = ItemDetails.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        return strReturnData;
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

        

        public class MultipleContext_GEN_T009
        {
            public List<GEN_T009_BackFlip> BackFlipEntity { get; set; }
            public List<GEN_T009> MasterEntity { get; set; }
            public List<SEL_T003> SalesData { get; set; }
            public List<SEL_T003_A> ItemsEntity { get; set; }
            public List<LOG_T001_A> ItemsEntitydel { get; set; }



            //public List<HRM_M015_A> DetailData { get; set; }
            public List<ADM_M0013> StatusList { get; set; }
            public List<SEL_T003_P_RefDoc> Sales_Invoice_Reference { get; set; }
            public List<GEN_T009_P> waybill { get; set; }

        }
        public class GEN_T009_BackFlip
        {
            public string doc_no { get; set; }
            public Nullable<System.DateTime> doc_date { get; set; }
            public string doc_type { get; set; }
            public string doc_cat { get; set; }
            public string trans_type { get; set; }
            public string trans_sub_type { get; set; }
            public string way_bill_no { get; set; }
            public Nullable<System.DateTime> way_bill_date { get; set; }
            public string wb_time { get; set; }
            public string ref_doc_no { get; set; }
            public string ref_doc_cat { get; set; }
            public string ref_doc_type { get; set; }
            public string distance { get; set; }
            public Nullable<System.DateTime> validity_from { get; set; }
            public Nullable<System.DateTime> validity_to { get; set; }
            public string t_status { get; set; }
            public Nullable<System.DateTime> rec_date { get; set; }
            public string ref_way_bill_no { get; set; }
            public string mode_of_gen { get; set; }
            public Nullable<bool> active { get; set; }
            public string user_source1 { get; set; }
            public string user_source2 { get; set; }
            public System.DateTime add_date { get; set; }
            public string add_by { get; set; }
            public Nullable<System.DateTime> edit_date { get; set; }
            public string editby { get; set; }
            public string client { get; set; }
            public string lang_key { get; set; }
        }
    }

}

