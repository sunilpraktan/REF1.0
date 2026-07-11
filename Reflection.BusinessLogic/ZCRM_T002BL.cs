namespace Reflection.BusinessLogic
{
    public class ZCRM_T002BL : ReflectionBusinessLogic
    {
        //CRMDBEntities dbContext = new CRMDBEntities();
        //GenericRepository<ZCRM_T001_A> repository = new GenericRepository<ZCRM_T001_A>();
        //static int obj = 0;
        //ObjectParameter objpara = new ObjectParameter("id", obj);
        //ZCRM_T001_A ZCRM_T002_A = new ZCRM_T001_A();

        //public ZCRM_T002BL(string BusinessEntity)
        //{
        //connectionString = base.ReflectionConnectionString;
        //}
        //public ZCRM_T002BL()
        //{
        //connectionString = base.ReflectionConnectionString;
        //}
        //public string Insert(string Request)
        //{
        //    try
        //    {
        //        MultipleContextZCRM_T002A mc = new MultipleContextZCRM_T002A();
        //        ZCRM_T002_A = (ZCRM_T001_A)ObjectSerializationService.XMLToObject(Request, ZCRM_T002_A);
        //        SqlParameter[] param = new SqlParameter[] 


        //        {
        //            new SqlParameter("@dc_dt",ZCRM_T002_A.inv_dt),
        //            new SqlParameter("@add_by",ZCRM_T002_A.add_by),
        //            new SqlParameter("@location_Id",ZCRM_T002_A.location_Id),                   
        //            new SqlParameter("@xdoc_LOG_T001_A",ZCRM_T002_A.xdoc_ACC_T001_A ) ,
        //            new SqlParameter("@customer_id",ZCRM_T002_A.PartyId)

        //        };
        //        var cmd = dbContext.Database.Connection.CreateCommand();
        //        cmd.CommandText = "ZCRM_T002_AInsert";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddRange(param);
        //        dbContext.Database.Connection.Open();
        //        var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        //        MultipleContextZCRM_T002A MC = new MultipleContextZCRM_T002A();

        //        var Invoice = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ZCRM_T001_A>(reader);
        //        MC.DCMaster = Invoice.ToList();

        //        reader.NextResult();
        //        var DCDetails1 = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<DeliveryEntry>(reader);
        //        MC.Details = DCDetails1.ToList();

        //        reader.NextResult();

        //        if (MC.DCMaster.Count > 0)
        //        {
        //            ZCRM_T002_A = MC.DCMaster[0];
        //        }
        //        ZCRM_T002_A.xdoc_ACC_T001_A = ObjectSerializationService.ObjectToXML(MC.DCMaster);

        //        if (!reader.Read())
        //        {
        //            reader.Close();
        //        }
        //        string strReturnData = ObjectSerializationService.ObjectToXML(ZCRM_T002_A);
        //        return strReturnData;
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new CreateException(ex.ErrorCode, ex.Message, ex);
        //    }
        //    catch (CreateException ex)
        //    {
        //        throw new CreateException(ex.Message, ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new CreateException(ex.Message, ex);
        //    }

        //}
        //public string Update(string Request)
        //{
        //    try
        //    {
        //        ZCRM_T002_A = (ZCRM_T001_A)ObjectSerializationService.XMLToObject(Request, ZCRM_T002_A);
        //        SqlParameter[] param = new SqlParameter[] 
        //        {
        //             new SqlParameter("@active",ZCRM_T002_A.active),
        //            new SqlParameter("@id",ZCRM_T002_A.id),
        //            //new SqlParameter("@dc_dt",ZCRM_T002_A.dc_entrydt),
        //            new SqlParameter("@add_by",ZCRM_T002_A.add_by),
        //            new SqlParameter("@location_Id",ZCRM_T002_A.location_Id),                   
        //            new SqlParameter("@xdoc_LOG_T001_A",ZCRM_T002_A.xdoc_ACC_T001_A ) ,
        //            new SqlParameter("@PartyId",ZCRM_T002_A.PartyId)
        //        };
        //        var cmd = dbContext.Database.Connection.CreateCommand();
        //        cmd.CommandText = "ZCRM_T002_AUpdate";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddRange(param);
        //        dbContext.Database.Connection.Open();
        //        var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        //        MultipleContextZCRM_T002A MC = new MultipleContextZCRM_T002A();

        //        var Invoice = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ZCRM_T001_A>(reader);
        //        MC.DCMaster = Invoice.ToList();

        //        reader.NextResult();
        //        var DCDetails1 = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<DeliveryEntry>(reader);
        //        MC.Details = DCDetails1.ToList();


        //        if (MC.DCMaster.Count > 0)
        //        {
        //            ZCRM_T002_A = MC.DCMaster[0];
        //            ZCRM_T002_A.xdoc_ACC_T001_A = ObjectSerializationService.ObjectToXML(MC.DCMaster);

        //        }
        //        else
        //        {
        //            ZCRM_T002_A = new ZCRM_T001_A();
        //        }
        //        if (!reader.Read())
        //        {
        //            reader.Close();
        //        }
        //        string strReturnData = ObjectSerializationService.ObjectToXML(ZCRM_T002_A);
        //        return strReturnData;
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new CreateException(ex.ErrorCode, ex.Message, ex);
        //    }
        //    catch (CreateException ex)
        //    {
        //        throw new CreateException(ex.Message, ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new CreateException(ex.Message, ex);
        //    }

        //}
        //public string Delete(int Request)
        //{
        //    try
        //    {
        //        int intOut = dbContext.ZCRM_T002ADelete(Request);
        //        return intOut.ToString();
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new CreateException(ex.ErrorCode, ex.Message, ex);
        //    }
        //    catch (CreateException ex)
        //    {
        //        throw new CreateException(ex.Message, ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new CreateException(ex.Message, ex);
        //    }

        //}

        //public string GetData(string strType, int intValue)
        //{
        //    MultipleContextZCRM_T002A MC = new MultipleContextZCRM_T002A();
        //    try
        //    {

        //        SqlParameter[] param = new SqlParameter[] 
        //        {                 
        //            new SqlParameter("@request",strType),
        //            new SqlParameter("@dc_id",intValue),
        //              new SqlParameter("@supplier_id",intValue)
        //        };
        //        var cmd = dbContext.Database.Connection.CreateCommand();
        //        cmd.CommandText = "ZCRM_T002_ALoadAll";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddRange(param);
        //        dbContext.Database.Connection.Open();
        //        var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

        //        if (strType == "LoadAll")
        //        {
        //            var Invoice = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ZCRM_T001_A>(reader);
        //            MC.DCMaster = Invoice.ToList();
        //            reader.NextResult();

        //            var Party = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ADM_M028_PopUp>(reader);
        //            MC.partyDetails = Party.ToList();
        //            reader.NextResult();



        //        }
        //        else if (strType == "LoadItemsDetails")
        //        {
        //            var Details = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<DeliveryEntry>(reader);
        //            MC.Details = Details.ToList();
        //            reader.NextResult();


        //        }
        //        else if (strType == "LoadDCDetails")
        //        {
        //            var MDetails = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<DeliveryEntryM>(reader);
        //            MC.MDetails = MDetails.ToList();
        //            reader.NextResult();

        //            var Details = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<DeliveryEntry>(reader);
        //            MC.Details = Details.ToList();
        //            reader.NextResult();


        //        }
        //        if (!reader.Read())
        //        {
        //            reader.Close();
        //        }
        //        string strReturnData = ObjectSerializationService.ObjectToXML(MC);
        //        return strReturnData;
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new CreateException(ex.ErrorCode, ex.Message, ex);
        //    }
        //    catch (DivideByZeroException ex)
        //    {
        //        throw new CreateException(ex.Message, ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new CreateException(ex.Message, ex);
        //    }
    }

    //public class MultipleContextZCRM_T002A
    //{
    //    public List<ZCRM_T001_A> DCMaster { get; set; }

    //    public List<ZCRM_T002_B> DCDetails { get; set; }
    //    public List<ADM_M028_PopUp> partyDetails { get; set; }

    //    public List<DeliveryEntry> Details { get; set; }

    //    public List<DeliveryEntryM> MDetails { get; set; }


    //    //public List<ADM_M003_V_CRM> Location { get; set; }
    //}

}
