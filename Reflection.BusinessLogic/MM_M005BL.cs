namespace Reflection.BusinessLogic
{
    public class MM_M005BL : ReflectionBusinessLogic
    {
        //SCM_DBEntities dbContext = new SCM_DBEntities();

        //GenericRepository<MM_M005> repository = new GenericRepository<MM_M005>();
        //static int obj = 0;
        //ObjectParameter objpara = new ObjectParameter("id", obj);
        //MM_M005 mM_M005 = new MM_M005();
        //public MM_M005BL(string BusinessEntity)
        //{
        // ConnectionString = base.ReflectionConnectionString;
        //}
        //public MM_M005BL()
        //{
        //ConnectionString = base.ReflectionConnectionString;
        //}

    //public string GetData()
    //{
    //    MultipleContext_MM_M005 MC = new MultipleContext_MM_M005();
    //    try
    //    {
    //        var cmd = dbContext.Database.Connection.CreateCommand();
    //        cmd.CommandText = "MM_M005LoadAll";
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        dbContext.Database.Connection.Open();
    //        var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);


    //        var quant = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<MM_M005>(reader);
    //        MC.QuantMaster = quant.ToList();
    //        reader.NextResult();

    //        var StockJrnl = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<MM_M007_PopUp>(reader);
    //        MC.StockJournal = StockJrnl.ToList();
    //        reader.NextResult();

    //        var itmDtl = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<MM_S003_PopUp>(reader).ToList();
    //        MC.Batch_Stock = itmDtl.ToList();
    //        reader.NextResult();

    //        //var makeDtl = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<MM_S003_PopUp>(reader).ToList();
    //        //MC.Batch_Stock = makeDtl.ToList();
    //        //reader.NextResult();

    //        var flutetemp = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ADM_M030_PopUp>(reader);
    //        MC.parameter_value_list = flutetemp.ToList();
    //        reader.NextResult();

    //        var ParamvalList = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<Parameter_PopUp>(reader);
    //        MC.parameter_list = ParamvalList.ToList();
    //        reader.NextResult();

    //        if (!reader.Read())
    //        {
    //            reader.Close();
    //        }

    //        string strData = ObjectSerializationService.ObjectToXML(MC);
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
}
    //public class MultipleContext_MM_M005
    //{
    //    public List<MM_M005> QuantMaster { get; set; }//QuantMaster
    //    public List<MM_M007_PopUp> StockJournal { get; set; }// StockJournal

    //    public List<MM_S003_PopUp> ItemList { get; set; }  // Batch Stock 
    //    public List<MM_S003_PopUp> Batch_Stock { get; set; }  // Batch Stock         
    //    public List<ADM_M030_PopUp> parameter_value_list { get; set; }//Flute Master
    //    public List<Parameter_PopUp> parameter_list { get; set; }    //Parameter Master
    //    public List<ADM_M034_PopUp> ParamList { get; set; }
    //}
}
