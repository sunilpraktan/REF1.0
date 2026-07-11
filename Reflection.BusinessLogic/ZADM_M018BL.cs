namespace Reflection.BusinessLogic
{
    public class ZADM_M018BL : ReflectionBusinessLogic
    {

        //private static string connectionString;
        //ZADM_M018 ZADM_M018 = new ZADM_M018();
        //public ZADM_M018BL(string BusinessEntity)
        //{
        //    connectionString =  base.ReflectionConnectionString;
        //}
        //public ZADM_M018BL()
        //{
        //    connectionString =  base.ReflectionConnectionString;
        //}
        //public string Insert(string Request)
        //{
        //    try
        //    {
        //        MultipleContext_ZADM_M018 MC = new MultipleContext_ZADM_M018();
        //        ZADM_M018 = new ZADM_M018();
        //        ZADM_M018 = (ZADM_M018)ObjectSerializationService.XMLToObject(Request, ZADM_M018);
        //        SqlParameter[] param = new SqlParameter[]
        //       {
        //             new SqlParameter("@Request",ZADM_M018.XmlDataDocument_ZADM_M018)
        //       };
        //        var cmd = dbContext.Database.Connection.CreateCommand();
        //        cmd.CommandText = "ZADM_M018Insert";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddRange(param);
        //        dbContext.Database.Connection.Open();

        //        var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);





        //        var ILDChart = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ZADM_M018>(reader).ToList();
        //        MC.DebitCreditDetails = ILDChart.ToList();
        //        reader.NextResult();

        //        ZADM_M018 = MC.DebitCreditDetails[0];

        //        if (!reader.Read())
        //        {
        //            reader.Close();
        //        }
        //        string strReturnData = ObjectSerializationService.ObjectToXML(ZADM_M018);
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
        //        MultipleContext_ZADM_M018 MC = new MultipleContext_ZADM_M018();
        //        ZADM_M018 = new ZADM_M018();
        //        ZADM_M018 = (ZADM_M018)ObjectSerializationService.XMLToObject(Request, ZADM_M018);
        //        SqlParameter[] param = new SqlParameter[]
        //       {
        //             //new SqlParameter("@Type",ZADM_M018.Type),                                           
        //             //new SqlParameter("@Plant",ZADM_M018.plant),
        //             //new SqlParameter("@Date",ZADM_M018.start_dt),
        //             new SqlParameter("@Request",ZADM_M018.XmlDataDocument_ZADM_M018)
        //       };
        //        var cmd = dbContext.Database.Connection.CreateCommand();
        //        cmd.CommandText = "ZADM_M018Update";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddRange(param);
        //        dbContext.Database.Connection.Open();
        //        var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

        //        var ILDChart = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ZADM_M018>(reader).ToList();
        //        MC.DebitCreditDetails = ILDChart.ToList();
        //        reader.NextResult();

        //        ZADM_M018 = MC.DebitCreditDetails[0];

        //        if (!reader.Read())
        //        {
        //            reader.Close();
        //        }

        //        string strReturnData = ObjectSerializationService.ObjectToXML(ZADM_M018);
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
        //        int intOut = dbContext.ZADM_M018Delete(Request);
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
        //public string GetData(string strType, string strValue, int intValue)
        //{
        //    MultipleContext_ZADM_M018 MC = new MultipleContext_ZADM_M018();
        //    //ZADM_M018 = new ZADM_M018();
        //    //ZADM_M018 = (ZADM_M018)ObjectSerializationService.XMLToObject(Request, ZADM_M018);
        //    string strData = "";
        //    try
        //    {
        //        SqlParameter[] param = new SqlParameter[]
        //            {
        //                new SqlParameter("@param",strType) ,
        //                new SqlParameter("@id",intValue) //,        
        //               //new SqlParameter("@start_dt",strValue)

        //            };

        //        var cmd = dbContext.Database.Connection.CreateCommand();
        //        cmd.CommandText = "ZADM_M018LoadAll";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddRange(param);
        //        dbContext.Database.Connection.Open();
        //        var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

        //        if (strType == "LoadAll")
        //        {

        //            var Goods1 = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ZADM_M018>(reader).ToList();
        //            MC.DebitCreditDetails = Goods1.ToList();
        //            reader.NextResult();

        //            var Customer = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ADM_M028_PopUp>(reader).ToList();
        //            MC.Customer = Customer.ToList();
        //            reader.NextResult();

        //            var Product = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ADM_M022_ESSEM_PopUp>(reader).ToList();
        //            MC.Product = Product.ToList();
        //            reader.NextResult();

        //            var INK = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ZADM_M006_PopUp>(reader).ToList();
        //            MC.INK = INK.ToList();
        //            reader.NextResult();

        //            var ILD = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ZADM_M007_PopUp>(reader).ToList();
        //            MC.ILD = ILD.ToList();
        //            reader.NextResult();

        //            var plant1 = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ADM_M003_PopUp>(reader).ToList();
        //            MC.plant = plant1.ToList();
        //            reader.NextResult();
        //        }

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
    }
    //public class MultipleContext_ZADM_M018
    //{
    //    public List<ZADM_M018> DebitCreditDetails { get; set; } //ZADM_M018
    //    public List<ZADM_M018> GoodsDetails { get; set; } //ZADM_M018
    //    public List<ADM_M028_PopUp> Customer { get; set; } //Customer /Party
    //    public List<ADM_M022_ESSEM_PopUp> Product { get; set; } //Product /Item         
    //    public List<ZADM_M006_PopUp> INK { get; set; }     //INK
    //    public List<ZADM_M007_PopUp> ILD { get; set; }    //ILD
    //    public List<ADM_M003_PopUp> plant { get; set; }  //Plant/Location Master    


    //}
}
