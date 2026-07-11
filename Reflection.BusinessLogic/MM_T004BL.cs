using Reflection.EF;
using Reflection.EF.SCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Reflection.EF.Communication;
using Reflection.EF.ReflectionSystem;

namespace Reflection.BusinessLogic
{
    public class MM_T004BL : ReflectionBusinessLogic
    {
  
        private static string connectionString;
        MM_T004 MasterEntity = new MM_T004();
        MultipleContext_MM_T004 MC = new MultipleContext_MM_T004();

        public MM_T004BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public MM_T004BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("MM_T004_INS", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<MM_T004Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<MM_T004>().ToList();
                    List<MM_T004> Masterlist = MasterData.ToList();
                   
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
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
            string strReturnData = "";
            try
            {

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("MM_T004_UPD", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<MM_T004Flip>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var MasterData = reader.Read<MM_T004>().ToList();
                    List<MM_T004> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
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
        public string Delete(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("MM_T004_DEL", new { @doc_no = Request }, commandType: CommandType.StoredProcedure);
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
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("MM_T004_GET", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);
                 
                    if (RequestOption == "LoadInitialData")
                    {
                        var documentDataFlipGrid = reader.Read<MM_T004Flip>().ToList();
                        MC.DocumentDataFlipGrid = documentDataFlipGrid.ToList();

                        var party = reader.Read<ADM_M028_P>().ToList();
                        MC.partyList = party.ToList();

                        var empList = reader.Read<ADM_M024_P>().ToList();
                        MC.EmpList = empList.ToList();

                        var UnitList = reader.Read<ADM_M038_B_P>().ToList();
                        MC.unitList = UnitList.ToList();

                        var DeptList = reader.Read<ADM_M025_P>().ToList();
                        MC.deptList = DeptList.ToList();

                        var itemList = reader.Read<ADM_M022_P>().ToList();
                        MC.ItemList = itemList.ToList();

                        var transporters = reader.Read<ADM_M028_P> ().ToList();
                        MC.Transporters = transporters.ToList();

                        var docinfo = reader.Read<SYS_M002>().ToList();
                        MC.DocTypeInfo = docinfo.ToList();

                        var NotificationData = reader.Read<NotificationData>().ToList();
                        MC.NotificationData = NotificationData.ToList();
                        MC.DOC_TYPE_LIST = reader.Read<STD_DOC_TYPE>().ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    }
                    else if (RequestOption == "LoadRecordsofSelectedDate")
                    {
                        var BackFilptemp = reader.Read<MM_T004Flip>().ToList();
                        MC.DocumentDataFlipGrid = BackFilptemp.ToList();
                    }
                    else if (RequestOption == "LoadPartyDetails")
                    {
                        var ContactMaster = reader.Read<ADM_M028_C_P>().ToList();
                        MC.contactInfoMaster = ContactMaster.ToList();
                    }
                    else if (RequestOption == "LoadDocumentWithReferenceDocumentNumber")
                    {
                        var _DocumentMaster = reader.Read<MM_T004>().ToList();
                        MC.DocumentMaster = _DocumentMaster.ToList();
                        MasterEntity = MC.DocumentMaster[0];

                        var Attachment = reader.Read<COM_T003>().ToList();
                        MC.Attachment = Attachment.ToList();
                        //MasterEntity = MC.Attachment[1];

                        var documentDataFlipGrid = reader.Read<MM_T004Flip>().ToList();
                        MC.DocumentDataFlipGrid = documentDataFlipGrid.ToList();


                        strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
                        return strReturnData;



                    }
                    else if (RequestOption == "Report")
                    {
                        MC.DocumentMaster = reader.Read<MM_T004>().ToList();
                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                        return strReturnData;



                    }
                    strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    return strReturnData;

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
        public class MultipleContext_MM_T004
        {
            public List<SYS_M002> DocTypeInfo { get; set; }
            public List<MM_T004Flip> DocumentDataFlipGrid { get; set; }
            public List<ADM_M028_P> partyList { get; set; }
            public List<ADM_M024_P> EmpList { get; set; }
            public List<ADM_M038_B_P> unitList { get; set; }
            public List<ADM_M025_P> deptList { get; set; }
            public List<ADM_M022_P> ItemList { get; set; }
            public List<ADM_M028_P> Transporters { get; set; }
            public List<ADM_M028_C_P> contactInfoMaster { get; set; }
            public List<MM_T004> DocumentMaster { get; set; }
            public List<COM_T003> Attachment { get; set; }
            public List<NotificationData> NotificationData { get; set; }
            public List<STD_DOC_TYPE> DOC_TYPE_LIST { get; set; }
        }
    }
}
