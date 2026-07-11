namespace Reflection.BusinessLogic
{
    public class MM_M007BL : ReflectionBusinessLogic
    {
        //GenericRepository<MM_M007> repository = new GenericRepository<MM_M007>();
        //SCM_DBEntities dbContext = new SCM_DBEntities();
        //static int obj = 0;
        //ObjectParameter objpara = new ObjectParameter("trnsID", obj);    
        //MM_M007 mM_M007 = new MM_M007();

        //public MM_M007BL(string BusinessEntity)
        //{
        //ConnectionString = base.ReflectionConnectionString;
        //}
        //public MM_M007BL()
        //{
        //ConnectionString = base.ReflectionConnectionString;
        //}
    //public string Insert(string Request)
    //{
    //    try
    //    {
    //        MultipleContext_MM_M007 MC = new MultipleContext_MM_M007();
    //        SqlParameter[] param = new SqlParameter[] 
    //        {
    //            new SqlParameter("@Request",Request)                            

    //        };
    //        var cmd = dbContext.Database.Connection.CreateCommand();
    //        cmd.CommandText = "MM_M007Insert";
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.Parameters.AddRange(param);
    //        dbContext.Database.Connection.Open();
    //        var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

    //        var StckJurnltemp = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<MM_M007>(reader);
    //        mM_M007 = new MM_M007();
    //        MC.StckJurnl = StckJurnltemp.ToList();
    //        //reader.NextResult();

    //        //var AvgWtDtl = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ZSCM_T001_B>(reader);
    //        //zSCM_T001_A = new ZSCM_T001_A();
    //        //MC.Avg_Wt_Details = AvgWtDtl.ToList();

    //        //zSCM_T001_A = MC.Avg_Wt[0];
    //        //zSCM_T001_A.XmlDataDocument_ZSCM_T001_B = ObjectSerializationService.ObjectToXML(MC.Avg_Wt_Details);
    //        if (!reader.Read())
    //        {
    //            reader.Close();
    //        }


    //        string strReturnData = ObjectSerializationService.ObjectToXML(MC.StckJurnl[0]);
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
    //        MultipleContext_MM_M007 MC = new MultipleContext_MM_M007(); 

    //        SqlParameter[] param = new SqlParameter[] 
    //        {
    //            new SqlParameter("@Request",Request)                            

    //        };
    //        var cmd = dbContext.Database.Connection.CreateCommand();
    //        cmd.CommandText = "MM_M007Update";
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.Parameters.AddRange(param);
    //        dbContext.Database.Connection.Open();
    //        var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

    //        var StckJurnltemp = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<MM_M007>(reader);
    //        mM_M007 = new MM_M007();
    //        MC.StckJurnl = StckJurnltemp.ToList();

    //        //var AvgWtDtl = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ZSCM_T001_B>(reader);
    //        //zSCM_T001_A = new ZSCM_T001_A();
    //        //MC.Avg_Wt_Details = AvgWtDtl.ToList();

    //        //zSCM_T001_A = MC.Avg_Wt[0];

    //        //zSCM_T001_A.XmlDataDocument_ZSCM_T001_B = ObjectSerializationService.ObjectToXML(MC.Avg_Wt_Details);
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
    //        int intOut = dbContext.MM_M007Delete(Request);
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
    //public string GetData()
    //{
    //    try
    //    {
    //        MultipleContext_MM_M007 MC = new MultipleContext_MM_M007();
    //        string strData = "";

    //        var cmd = dbContext.Database.Connection.CreateCommand();
    //        cmd.CommandText = "MM_M007LoadAll";
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        dbContext.Database.Connection.Open();
    //        var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);


    //        var StckJurnl = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<MM_M007>(reader).ToList();
    //        MC.StckJurnl = StckJurnl.ToList();
    //        reader.NextResult();

    //        var itmDtl = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<MM_S003_PopUp>(reader).ToList();
    //        MC.ItemList = itmDtl.ToList();
    //        reader.NextResult();

    //        var makeDtl = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<MM_S003_PopUp>(reader).ToList();
    //        MC.Batch_Stock = makeDtl.ToList();
    //        reader.NextResult();

    //        var flutetemp = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ADM_M030_PopUp>(reader);
    //        MC.parameter_value_list = flutetemp.ToList();
    //        reader.NextResult();

    //        var ParamvalList = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<Parameter_PopUp>(reader);
    //        MC.parameter_list = ParamvalList.ToList();
    //        reader.NextResult();

    //        var Stock_Chart = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<MM_M005_PopUp>(reader).ToList();
    //        MC.Stock_Chart = Stock_Chart.ToList();

    //        if (!reader.Read())
    //        {
    //            reader.Close();
    //        }
    //        strData = ObjectSerializationService.ObjectToXML(MC);
    //        return strData;

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
    //}
    //public class MultipleContext_MM_M007
    //{
    //    public List<MM_M007> StckJurnl { get; set; }  //StockJournal
    //    public List<MM_S003_PopUp> ItemList { get; set; }  // Batch Stock 
    //    public List<MM_S003_PopUp> Batch_Stock { get; set; }  // Batch Stock 
    //    public List<ADM_M030_PopUp> parameter_value_list { get; set; }//Flute Master
    //    public List<Parameter_PopUp> parameter_list { get; set; }    //Parameter Master

    //    public List<MM_M005_PopUp> Stock_Chart { get; set; }  // Stock Chart

    //}
}
}
