namespace Reflection.BusinessLogic
{
    public class SEL_T002BLReq : ReflectionBusinessLogic
    {
        
        static int obj = 0;
        private static string connectionString;
        //ObjectParameter objpara = new ObjectParameter("InstCode", obj);
        //SEL_T002 sEL_T002 = new SEL_T002();       
        public SEL_T002BLReq(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public SEL_T002BLReq()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            //try
            //{
            //    SEL_T002 sEL_T002 = new SEL_T002();
            //    sEL_T002 = (SEL_T002)ObjectSerializationService.XMLToObject(Request, sEL_T002);
            //    sEL_T002.sch_no = "";
            //    SqlParameter[] param = new SqlParameter[] 
            //    {
            //        new SqlParameter("@count",1),
            //        new SqlParameter("@sch_no_from_so",sEL_T002.sch_no),
            //        new SqlParameter("@party_id",sEL_T002.PartyId ),
            //        new SqlParameter("@sch_date",sEL_T002.sch_date),
            //        new SqlParameter("@sch_time",sEL_T002.sch_time),
            //        new SqlParameter("@sch_by",sEL_T002.EmpId),
            //        new SqlParameter("@sch_mode",sEL_T002.sch_mode),
            //        new SqlParameter("@sch_rec_by",sEL_T002.sch_rec_by_cd),
            //        new SqlParameter("@remark",sEL_T002.remark),
            //         new SqlParameter("@location_id",sEL_T002.location_Id),
            //        new SqlParameter("@company_id",sEL_T002.comp_code ),                    
            //          new SqlParameter("@ref_type",sEL_T002.ref_type ),
            //        new SqlParameter("@ref_no",sEL_T002.ref_no ), 
            //        new SqlParameter("@add_by",sEL_T002.add_by ),
            //        new SqlParameter("@xdoc",sEL_T002.XmlDataDocument)                    
            //    };

            //    var cmd = dbContext.Database.Connection.CreateCommand();
            //    cmd.CommandText = "SEL_T002InsertReq";
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddRange(param);
            //    dbContext.Database.Connection.Open();
            //    var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            //    MultipleContext_SEL_T002Req MC = new MultipleContext_SEL_T002Req();
            //    sEL_T002 = new SEL_T002();

            //    var deliverySchedule = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<SEL_T002>(reader, "SEL_T002", MergeOption.AppendOnly);
            //    MC.deliveryOrder = deliverySchedule.ToList();
            //    reader.NextResult();

            //    var deliveryScheduleItm = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<SEL_T002_B>(reader, "SEL_T002_B", MergeOption.AppendOnly);
            //    MC.deliveryOrderItems = deliveryScheduleItm.ToList();
            //    //reader.NextResult();

            //    //var salesOrderItems1 = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<SEL_T002_B_POItem>(reader);
            //    //MC.purchaseOrderItems = salesOrderItems1.ToList();
            //    //reader.NextResult();

            //    //var catloag = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ADM_M022_ItemPopup>(reader);
            //    //MC.CatalogItems = catloag.ToList();

            //    //reader.NextResult();

            //    //var sales1 = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<SEL_T001_Popup>(reader);
            //    //MC.requirement_docList = sales1.ToList();
            //    if (MC.deliveryOrder.Count > 0)
            //    {
            //        sEL_T002 = MC.deliveryOrder[0];
            //    }
            //    sEL_T002.XmlDataDocument = ObjectSerializationService.ObjectToXML(MC.deliveryOrderItems);
            //    //sEL_T002.XmlDataDocument_CatalogItems = ObjectSerializationService.ObjectToXML(MC.CatalogItems);
            //    //sEL_T002.XmlDataDocument_purchaseOrderItems = ObjectSerializationService.ObjectToXML(MC.purchaseOrderItems);
            //    //sEL_T002.XmlDataDocument_reuirement = ObjectSerializationService.ObjectToXML(MC.requirement_docList);

            //    if (!reader.Read())
            //    {
            //        reader.Close();
            //    }
            string strReturnData = "";// ObjectSerializationService.ObjectToXML(sEL_T002);
            return strReturnData;
            //}
            //catch (SqlException ex)
            //{
            //    throw new CreateException(ex.ErrorCode, ex.Message, ex);
            //}
            //catch (CreateException ex)
            //{
            //    throw new CreateException(ex.Message, ex);
            //}
            //catch (Exception ex)
            //{
            //    throw new CreateException(ex.Message, ex);
            //}
        }
        public string Update(string Request)
        {
            //try
            //{
            //    SEL_T002 sEL_T002 = new SEL_T002();
            //    sEL_T002 = (SEL_T002)ObjectSerializationService.XMLToObject(Request, sEL_T002);
            //    SqlParameter[] param = new SqlParameter[] 
            //    {   
            //        new SqlParameter("@id",sEL_T002.id),
            //        new SqlParameter("@party_id",sEL_T002.PartyId),
            //        new SqlParameter("@sch_date",sEL_T002.sch_date),
            //        new SqlParameter("@sch_time",sEL_T002.sch_time),
            //        new SqlParameter("@sch_by",sEL_T002.EmpId),
            //        new SqlParameter("@sch_mode",sEL_T002.sch_mode),
            //        new SqlParameter("@sch_rec_by",sEL_T002.sch_rec_by_cd),
            //        new SqlParameter("@remark",sEL_T002.remark),
            //        new SqlParameter("@add_by",sEL_T002.add_by),                    
            //        new SqlParameter("@active",sEL_T002.active),    
            //        new SqlParameter("@xdoc",sEL_T002.XmlDataDocument)   ,
            //        new SqlParameter("@location_id",sEL_T002.location_Id),                       
            //        new SqlParameter("@ref_no",sEL_T002.ref_no ),   
            //        new SqlParameter("@company_id",sEL_T002.comp_code)
            //    };

            //    var cmd = dbContext.Database.Connection.CreateCommand();
            //    cmd.CommandText = "SEL_T002UpdateReq";
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddRange(param);
            //    dbContext.Database.Connection.Open();
            //    var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            //    MultipleContext_SEL_T002Req MC = new MultipleContext_SEL_T002Req();
            //    sEL_T002 = new SEL_T002();

            //    var deliverySchedule = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<SEL_T002>(reader, "SEL_T002", MergeOption.AppendOnly);
            //    MC.deliveryOrder = deliverySchedule.ToList();

            //    reader.NextResult();
            //    var deliveryScheduleItm = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<SEL_T002_B>(reader, "SEL_T002_B", MergeOption.AppendOnly);
            //    MC.deliveryOrderItems = deliveryScheduleItm.ToList();
            //    reader.NextResult();

            //    var salesOrderItems1 = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<SEL_T002_B_POItem>(reader);
            //    MC.purchaseOrderItems = salesOrderItems1.ToList();
            //    reader.NextResult();

            //    var catloag = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ADM_M022_ItemPopup>(reader);
            //    MC.CatalogItems = catloag.ToList();

            //    reader.NextResult();

            //    var sales1 = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<SEL_T001_Popup>(reader);
            //    MC.requirement_docList = sales1.ToList();
            //    if (MC.deliveryOrder.Count > 0)
            //    {
            //        sEL_T002 = MC.deliveryOrder[0];
            //        sEL_T002.XmlDataDocument = ObjectSerializationService.ObjectToXML(MC.deliveryOrderItems);
            //        sEL_T002.XmlDataDocument = ObjectSerializationService.ObjectToXML(MC.deliveryOrderItems);
            //        sEL_T002.XmlDataDocument_CatalogItems = ObjectSerializationService.ObjectToXML(MC.CatalogItems);
            //        sEL_T002.XmlDataDocument_purchaseOrderItems = ObjectSerializationService.ObjectToXML(MC.purchaseOrderItems);
            //        sEL_T002.XmlDataDocument_reuirement = ObjectSerializationService.ObjectToXML(MC.requirement_docList);

            //    }
            //    else { sEL_T002 = new SEL_T002(); }
            //    if (!reader.Read())
            //    {
            //        reader.Close();
            //    }
            string strReturnData = "";// ObjectSerializationService.ObjectToXML(sEL_T002);
            return strReturnData;
            //}
            //catch (SqlException ex)
            //{
            //    throw new CreateException(ex.ErrorCode, ex.Message, ex);
            //}
            //catch (CreateException ex)
            //{
            //    throw new CreateException(ex.Message, ex);
            //}
            //catch (Exception ex)
            //{
            //    throw new CreateException(ex.Message, ex);
            //}
        }
        //public string Delete(int Request)
        //{
        //    try
        //    {
        //        int intOut = 0;
        //        intOut = dbContext.SEL_T002Delete(Request);
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
        public string GetData(string strType, int intValue, string strValue)
        {
            //MultipleContext_SEL_T002Req MC = new MultipleContext_SEL_T002Req();
            //try
            //{
            //    SqlParameter[] param = new SqlParameter[] 
            //    {
            //        new SqlParameter("@partyId",intValue),
            //        new SqlParameter("@param",strType)  ,
            //         new SqlParameter("@comp",strValue)
            //    };
            //    var cmd = dbContext.Database.Connection.CreateCommand();
            //    cmd.CommandText = "SEL_T002LoadAllReq";
            //    cmd.Parameters.AddRange(param);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    dbContext.Database.Connection.Open();
            //    var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            //    if (strType == "LoadParty")
            //    {
            //        var deliveryOrder1 = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<SEL_T002>(reader);
            //        MC.deliveryOrder = deliveryOrder1.ToList();
            //        reader.NextResult();

            //        var employeeInfoMaster1 = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ADM_M024_PopUp>(reader);
            //        MC.employeeInfoMaster = employeeInfoMaster1.ToList();
            //        reader.NextResult();

            //        var unitMaster1 = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ADM_M038_B_PopUp>(reader);
            //        MC.unitMaster = unitMaster1.ToList();

            //    }
            //    else if (strType == "LoadScheduleData")
            //    {
            //        var deliveryOrderItems1 = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<SEL_T002_B>(reader);
            //        MC.deliveryOrderItems = deliveryOrderItems1.ToList();
            //        reader.NextResult();

            //        var salesOrderItems1 = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<SEL_T002_B_POItem>(reader);
            //        MC.purchaseOrderItems = salesOrderItems1.ToList();
            //        reader.NextResult();

            //        var catloag = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ADM_M022_ItemPopup>(reader);
            //        MC.CatalogItems = catloag.ToList();
            //        reader.NextResult();

            //        var sales = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<SEL_T001_Popup>(reader);
            //        MC.reference_docList = sales.ToList();
            //        reader.NextResult();

            //        var sales1 = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<SEL_T001_Popup>(reader);
            //        MC.requirement_docList = sales1.ToList();
            //    }
            //    else if (strType == "LoadPartyData")
            //    {
            //        var contactInfoMaster1 = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ADM_M027_PopUp>(reader);
            //        MC.contactInfoMaster = contactInfoMaster1.ToList();
            //        reader.NextResult();

            //        var catloag = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ADM_M022_ItemPopup>(reader);
            //        MC.CatalogItems = catloag.ToList();
            //        reader.NextResult();

            //        var salesOrderItems1 = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<SEL_T002_B_POItem>(reader);
            //        MC.purchaseOrderItems = salesOrderItems1.ToList();
            //        reader.NextResult();

            //        var sales = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<SEL_T001_Popup>(reader);
            //        MC.reference_docList = sales.ToList();
            //        reader.NextResult();

            //        var sales1 = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<SEL_T001_Popup>(reader);
            //        MC.requirement_docList = sales1.ToList();
            //    }
            //    else if (strType == "LoadPartyData_requirement")
            //    {
            //        var deliveryOrderItems1 = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<SEL_T002_B>(reader);
            //        MC.deliveryOrderItems = deliveryOrderItems1.ToList();
            //        reader.NextResult();

            //        var unitMaster1 = ((IObjectContextAdapter)dbContext).ObjectContext.Translate<ADM_M038_B_PopUp>(reader);
            //        MC.unitMaster = unitMaster1.ToList();
            //    }

            //    if (!reader.Read())
            //    {
            //        reader.Close();
            //    }
            string strData = "";// = ObjectSerializationService.ObjectToXML(MC);
            return strData;
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
    }
    public class MultipleContext_SEL_T002Req
    {
        //public List<SEL_T002> deliveryOrder { get; set; }
        //public List<SEL_T002_B> deliveryOrderItems { get; set; }
        //public List<ADM_M028_PopUp> partyMaster { get; set; }
        //public List<ADM_M027_PopUp> contactInfoMaster { get; set; }
        //public List<ADM_M024_PopUp> employeeInfoMaster { get; set; }
        //public List<ADM_M038_B_PopUp> unitMaster { get; set; }
        //public List<ADM_M022_ItemPopup> CatalogItems { get; set; }
        //public List<SEL_T002_B_POItem> purchaseOrderItems { get; set; }
        //public List<SEL_T001_Popup> reference_docList { get; set; }
        //public List<SEL_T001_Popup> requirement_docList { get; set; }
    }
}
