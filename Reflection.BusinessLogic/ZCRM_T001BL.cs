
using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.CRM;
using Dapper;


namespace Reflection.BusinessLogic
{
    public class ZCRM_T001BL : ReflectionBusinessLogic
    {      
        private static string connectionString;       
        static int obj = 0;
        
        ZCRM_T001_A aCC_T001_A = new ZCRM_T001_A();

        public ZCRM_T001BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ZCRM_T001BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {                
                aCC_T001_A = (ZCRM_T001_A)ObjectSerializationService.XMLToObject(Request, aCC_T001_A);

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZCRM_T001Insert", new
                    {

                        @type = aCC_T001_A.type,
                        @inv_dt = aCC_T001_A.inv_dt,
                        @warehouse_id = aCC_T001_A.wa_code,
                        @add_by = aCC_T001_A.add_by,
                        @location_id = aCC_T001_A.location_Id,
                        @xdoc_ACC_T001_A = aCC_T001_A.xdoc_ACC_T001_A,
                        @xdoc_ACC_T001_B = aCC_T001_A.xdoc_ACC_T001_B,
                        @customer_id = aCC_T001_A.PartyId,
                        @company_id = aCC_T001_A.comp_code

                    }, commandTimeout: 900, commandType: CommandType.StoredProcedure);

                    MultipleContextACC_T001_A MC = new MultipleContextACC_T001_A();

                    var Invoice = reader.Read<ZCRM_T001_A>().ToList();
                    MC.InvoiceMaster = Invoice.ToList();

                    if (MC.InvoiceMaster.Count > 0)
                    {
                        aCC_T001_A = MC.InvoiceMaster[0];
                    }
                    //aCC_T001_A = MC.InvoiceMaster[0];
                    aCC_T001_A.xdoc_ACC_T001_B = ObjectSerializationService.ObjectToXML(MC.InvoiceMaster);
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(aCC_T001_A);
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
                aCC_T001_A = (ZCRM_T001_A)ObjectSerializationService.XMLToObject(Request, aCC_T001_A);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZCRM_T001Update", new
                    {
                        @type = aCC_T001_A.type,
                        @id = aCC_T001_A.id,
                        @active = aCC_T001_A.active,
                        @inv_dt = aCC_T001_A.inv_dt,
                        @customer_id = aCC_T001_A.PartyId,
                        @warehouse_id = aCC_T001_A.wa_code,
                        @add_by = aCC_T001_A.add_by,
                        @location_id = aCC_T001_A.location_Id,
                        @xdoc_ACC_T001_A = aCC_T001_A.xdoc_ACC_T001_A,
                        @xdoc_ACC_T001_B = aCC_T001_A.xdoc_ACC_T001_B,
                        @ack_dt = aCC_T001_A.ack_date,
                        @recd_dt = aCC_T001_A.recd_date,
                        @company_id = aCC_T001_A.comp_code
                    }, commandType: CommandType.StoredProcedure);

                    MultipleContextACC_T001_A MC = new MultipleContextACC_T001_A();
                    var Invoice = reader.Read<ZCRM_T001_A>().ToList();
                    MC.InvoiceMaster = Invoice.ToList();

                    if (MC.InvoiceMaster.Count > 0)
                    {
                        //aCC_T001_A = MC.InvoiceMaster[0];
                        aCC_T001_A.xdoc_ACC_T001_B = ObjectSerializationService.ObjectToXML(MC.InvoiceMaster);
                    }
                    else
                    {
                        aCC_T001_A.xdoc_ACC_T001_B = ObjectSerializationService.ObjectToXML(MC.InvoiceMaster);
                    }
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(aCC_T001_A);
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
        public string Delete(int Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    int intOut = conn.Execute("ZCRM_T001Delete", new { @id = Request }, commandType: CommandType.StoredProcedure);
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
        public string GetData(string strType, int intValue, string strValue)
        {
            MultipleContextACC_T001_A MC = new MultipleContextACC_T001_A();
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZCRM_T001LoadAll", new
                    {
                        @inv_id = intValue,
                        @supplier_id = strType,
                        @request = strType,
                        @company = strValue,
                        @xml = strValue
                    }, commandTimeout: 900, commandType: CommandType.StoredProcedure);

                    if (strType == "LoadAll")
                    {
                        var Invoice = reader.Read<ZCRM_T001_A>().ToList();
                        MC.InvoiceMaster = Invoice.ToList();

                        var Party = reader.Read<ADM_M028_PopUp>().ToList();
                        MC.partyDetails = Party.ToList();

                        var Location = reader.Read<ADM_M003_PopUpwarehouse>().ToList();
                        MC.LocationDetails = Location.ToList();

                        var Items1 = reader.Read<ADM_M022_PopUp>().ToList();
                        MC.itemMaster = Items1.ToList();

                        var unit1 = reader.Read<ADM_M038_B_PopUp>().ToList();
                        MC.unitDetails = unit1.ToList();
                    }
                    if (strType == "LoadAllParty")
                    {
                        var Invoice = reader.Read<ZCRM_T001_A>().ToList();
                        MC.InvoiceMaster = Invoice.ToList();

                        var Location = reader.Read<ADM_M003_PopUpwarehouse>().ToList();
                        MC.LocationDetails = Location.ToList();

                        var custSoPoList1 = reader.Read<PPC_T001_PopUp>().ToList();
                        MC.custSoPoList = custSoPoList1.ToList();

                        var custSoPoWithItemsList1 = reader.Read<PPC_T001_PopUp>().ToList();
                        MC.custSoPoWithItemsList = custSoPoWithItemsList1.ToList();

                        var ScheduleListTemp = reader.Read<PPC_T001_PopUp>().ToList();
                        MC.ScheduleList = ScheduleListTemp.ToList();

                        var ScheduleListWithItemsTemp = reader.Read<PPC_T001_PopUp>().ToList();
                        MC.ScheduleListWithItems = ScheduleListWithItemsTemp.ToList();
                    }
                    if (strType == "LoadAll1")
                    {
                        var Invoice = reader.Read<ZCRM_T001_A>();
                        MC.DCMaster = Invoice.ToList();

                        var Party = reader.Read<ADM_M028_PopUp>().ToList();
                        MC.partyDetails = Party.ToList();

                        var Location = reader.Read<ADM_M003_PopUpwarehouse>().ToList();
                        MC.LocationDetails = Location.ToList();

                        var Items1 = reader.Read<ADM_M022_PopUp>().ToList();
                        MC.itemMaster = Items1.ToList();

                        var unit1 =reader.Read<ADM_M038_B_PopUp>().ToList();
                        MC.unitDetails = unit1.ToList();
                    }
                    else if (strType == "LoadItemsDetails")
                    {
                        var ENVELOPEDetails = reader.Read<ENVELOPE>().ToList();
                        MC.ENVELOPEDetails = ENVELOPEDetails.ToList();
                    }
                    else if (strType == "PLCDetails")
                    {
                        var PLC = reader.Read<PLC>().ToList();
                        MC.PLC = PLC.ToList();
                    }
                    else if (strType == "LoadItemsDetailsDC")
                    {
                        var Details = reader.Read<DeliveryEntry>().ToList();
                        MC.Details = Details.ToList();
                    }
                    else if (strType == "LoadDCDetails")
                    {
                        var MDetails = reader.Read<DeliveryEntryM>().ToList();
                        MC.MDetails = MDetails.ToList();

                        var Details = reader.Read<DeliveryEntry>().ToList();
                        MC.Details = Details.ToList();
                    }
                    else if (strType == "LoadItemsDetailsDC")
                    {
                        var Details = reader.Read<DeliveryEntry>().ToList();
                        MC.Details = Details.ToList();
                    }
                    else if (strType == "LoadInvoiceAck")
                    {
                        var Details = reader.Read<DeliveryEntry>().ToList();
                        MC.Details = Details.ToList();
                    }
                    else if (strType == "LoadInvoiceStock")
                    {
                        var InvoiceStock = reader.Read<InvoiceStock>().ToList();
                        MC.InvoiceStock = InvoiceStock.ToList();
                    }
                    else if (strType == "LoadDCStock")
                    {
                        var DCStock = reader.Read<DCStock>().ToList();
                        MC.DCStock = DCStock.ToList();

                        var InvoiceStock = reader.Read<InvoiceStock>().ToList();
                        MC.InvoiceStock = InvoiceStock.ToList();
                    }
                    else if (strType == "LoadSOandSchedule")
                    {
                        var custSoPoList1 = reader.Read<PPC_T001_PopUp>().ToList();
                        MC.custSoPoList = custSoPoList1.ToList();

                        var custSoPoWithItemsList1 = reader.Read<PPC_T001_PopUp>().ToList();
                        MC.custSoPoWithItemsList = custSoPoWithItemsList1.ToList();

                        var ScheduleListTemp = reader.Read<PPC_T001_PopUp>().ToList();
                        MC.ScheduleList = ScheduleListTemp.ToList();

                        var ScheduleListWithItemsTemp = reader.Read<PPC_T001_PopUp>().ToList();
                        MC.ScheduleListWithItems = ScheduleListWithItemsTemp.ToList();
                    }

                }
                string strReturnData = ObjectSerializationService.ObjectToXML(MC);
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
        public class MultipleContextACC_T001_A
        {
            public List<ZCRM_T001_A> InvoiceMaster { get; set; }
            public List<ZCRM_T001_A> InvoiceDetails { get; set; }
            public List<ADM_M028_PopUp> partyDetails { get; set; }
            public List<ADM_M003_PopUpwarehouse> LocationDetails { get; set; }
            public List<ADM_M022_PopUp> itemMaster { get; set; }
            public List<ADM_M038_B_PopUp> unitDetails { get; set; }
            public List<ENVELOPE> ENVELOPEDetails { get; set; }
            public List<PLC> PLC { get; set; }
            public List<ZCRM_T001_A> DCMaster { get; set; }
            public List<ZCRM_T002_B> DCDetails { get; set; }
            public List<DeliveryEntry> Details { get; set; }
            public List<DeliveryEntryM> MDetails { get; set; }
            public List<DCStock> DCStock { get; set; }
            public List<InvoiceStock> InvoiceStock { get; set; }
            public List<PPC_T001_PopUp> custSoPoList { get; set; }//for customer sono and pono list 
            public List<PPC_T001_PopUp> custSoPoWithItemsList { get; set; }//for customer sono and pono list WITH ITEMS
            public List<PPC_T001_PopUp> ScheduleList { get; set; } 
            public List<PPC_T001_PopUp> ScheduleListWithItems { get; set; }
        }
    }
}
