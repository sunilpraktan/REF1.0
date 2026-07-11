using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.Admin;
using Dapper;
using Reflection.EF.Communication;

namespace Reflection.BusinessLogic
{
    class ZADM_M010BL : ReflectionBusinessLogic
    {
        private static string connectionString;

        ZADM_M010 MasterEntity = new ZADM_M010();
        MultipleContext_ZADM_M010 MC = new MultipleContext_ZADM_M010();

        public ZADM_M010BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ZADM_M010BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            MultipleContext_ZADM_M010 MC = new MultipleContext_ZADM_M010();
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZADM_M010Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<ZADM_M010>().ToList();
                    List<ZADM_M010> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    var BackflipData = reader.Read<ZADM_M010_Flip>().ToList();
                    MC.BackflipData = BackflipData.ToList();

                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.BackflipData);


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
            MultipleContext_ZADM_M010 MC = new MultipleContext_ZADM_M010();
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZADM_M010Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var MasterData = reader.Read<ZADM_M010>().ToList();
                    List<ZADM_M010> Masterlist = MasterData.ToList();
                    if (Masterlist.Count > 0)
                    {
                        MasterEntity = Masterlist[0];
                    }

                    var BackflipData = reader.Read<ZADM_M010_Flip>().ToList();
                    MC.BackflipData = BackflipData.ToList();

                    MasterEntity.XmlDataDocument_FlipGrid = ObjectSerializationService.ObjectToXML(MC.BackflipData);
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
        public string GetData(string RequestValue, string QueryOption, int intValue, string strValue)
        {
            MultipleContext_ZADM_M010 MC = new MultipleContext_ZADM_M010();
            string RequestOption = RequestValue.Split('!')[0];

            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ZADM_M010LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);
                    {
                        if (RequestOption == "LoadInitialData")
                        {
                            var BackflipData = reader.Read<ZADM_M010_Flip>().ToList();
                            MC.BackflipData = BackflipData.ToList();

                            var ModelList = reader.Read<ZADM_M009_P>().ToList();
                            MC.ModelList= ModelList.ToList();

                            var WireTypeList = reader.Read<ZADM_M004_P>().ToList();
                            MC.WireTypeList = WireTypeList.ToList();

                            var WireSizeList = reader.Read<ZADM_M003_P>().ToList();
                            MC.WireSizeList = WireSizeList.ToList();

                            var BallDiameterList = reader.Read<ZADM_M001_P>().ToList();
                            MC.BallDiameterList = BallDiameterList.ToList();

                            var BallTypeList = reader.Read<ZADM_M002_P>().ToList();
                            MC.BallTypeList = BallTypeList.ToList();

                            var TipLengthList = reader.Read<ZADM_M008_P>().ToList();
                            MC.TipLengthList = TipLengthList.ToList();

                            var InkList = reader.Read<ZADM_M006_P>().ToList();
                            MC.InkList = InkList.ToList();

                            var IldList = reader.Read<ZADM_M007_P>().ToList();
                            MC.IldList = IldList.ToList();

                            var _UnitCodeList = reader.Read<ADM_M038_B_P>().ToList();
                            MC.UnitCodeList = _UnitCodeList.ToList();

                            var testtype = reader.Read<ECRM_T003_C_P>().ToList();
                            MC.TestType = testtype.ToList();

                        }
                        if (RequestOption == "LoadDocumentByDocumentNumber")
                        {
                            var MasterList = reader.Read<ZADM_M010>().ToList();
                            MC.MasterEntity = MasterList.ToList();

                            var AttachmentList = reader.Read<COM_T003>().ToList();
                            MC.AttachmentList = AttachmentList.ToList();
                        }
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
    }
    public class MultipleContext_ZADM_M010
    {
        public List<ZADM_M010_Flip> BackflipData { get; set; }
        public List<ZADM_M010> MasterEntity { get; set; }
        public List<ZADM_M009_P> ModelList { get; set; }
        public List<ZADM_M004_P> WireTypeList { get; set; }
        public List<ZADM_M003_P> WireSizeList { get; set; }
        public List<ZADM_M001_P> BallDiameterList { get; set; }
        public List<ZADM_M002_P> BallTypeList { get; set; }
        public List<ZADM_M008_P> TipLengthList { get; set; }
        public List<ZADM_M006_P> InkList { get; set; }
        public List<ZADM_M007_P> IldList { get; set; }
        public List<ADM_M038_B_P> UnitCodeList { get; set; }
        public List<COM_T003> AttachmentList { get; set; }
        public List<ECRM_T003_C_P> TestType { get; set; } // Test TYpe master

    }
    //public class ZADM_M010BL
    //{
    //    private static string connectionString;
    //    ZADM_M010 ZaDM_M010 = new ZADM_M010();


    //    public ZADM_M010BL(string BusinessEntity)
    //    {
    //        connectionString = System.Configuration.ConfigurationManager.AppSettings["strConnectionString"];
    //    }
    //    public ZADM_M010BL()
    //    {
    //        connectionString = System.Configuration.ConfigurationManager.AppSettings["strConnectionString"];
    //    }
    //    public string Insert(string Request)
    //    {
    //        try
    //        {
    //            ZaDM_M010 = (ZADM_M010)ObjectSerializationService.XMLToObject(Request, ZaDM_M010);
    //            using (IDbConnection conn = new SqlConnection(connectionString))
    //            {
    //                var reader = conn.QueryMultiple("ZADM_M010Insert", new
    //                {
    //                    @model_id = ZaDM_M010.model_id,
    //                    @wire_type_id = ZaDM_M010.wire_type_id,
    //                    @wire_size_id = ZaDM_M010.wire_size_id,
    //                    @ball_dia_id = ZaDM_M010.ball_dia_id,
    //                    @ball_type_id = ZaDM_M010.ball_type_id,
    //                    @shank_dia = ZaDM_M010.shank_dia,
    //                    @tot_len_id = ZaDM_M010.tot_len_id,
    //                    @tipshape = ZaDM_M010.tipshape,
    //                    @tip_type = ZaDM_M010.tip_type,
    //                    @blank = ZaDM_M010.blank,
    //                    @extrapiece = ZaDM_M010.extrapiece,
    //                    @usedin_id = ZaDM_M010.usedin_id,
    //                    @noofball = ZaDM_M010.noofball,
    //                    @needlelen = ZaDM_M010.needlelen,
    //                    @needledia = ZaDM_M010.needledia,
    //                    @shanklen = ZaDM_M010.shanklen,
    //                    @prodnm = ZaDM_M010.prodnm,
    //                    @add_by = (object)ZaDM_M010.add_by ?? DBNull.Value,
    //                    @ItemCode = ZaDM_M010.ItemCode,
    //                    @ink = ZaDM_M010.ink,
    //                    @ild = ZaDM_M010.ild,
    //                    @comp_code=ZaDM_M010.comp_code
    //                }, commandType: CommandType.StoredProcedure);

    //                string strReturnData = ObjectSerializationService.ObjectToXML(ZaDM_M010);
    //                return strReturnData;
    //            }
    //        }
    //        catch (SqlException ex)
    //        {
    //            throw new CreateException(ex.ErrorCode, ex.Message, ex);
    //        }
    //        catch (CreateException ex)
    //        {
    //            throw new CreateException(ex.Message, ex);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new CreateException(ex.Message, ex);
    //        }
    //    }
    //    public string Update(string Request)
    //    {
    //        try
    //        {
    //            ZaDM_M010 = (ZADM_M010)ObjectSerializationService.XMLToObject(Request, ZaDM_M010);

    //            using (IDbConnection conn = new SqlConnection(connectionString))
    //            {
    //                var reader = conn.QueryMultiple("ZADM_M010Update", new
    //                {
    //                    @prod_id = ZaDM_M010.prod_id,
    //                    @model_id = ZaDM_M010.model_id,
    //                    @wire_type_id = ZaDM_M010.wire_type_id,
    //                    @wire_size_id = ZaDM_M010.wire_size_id,
    //                    @ball_dia_id = ZaDM_M010.ball_dia_id,
    //                    @ball_type_id = ZaDM_M010.ball_type_id,
    //                    @shank_dia = ZaDM_M010.shank_dia,
    //                    @tot_len_id = ZaDM_M010.tot_len_id,
    //                    @tipshape = ZaDM_M010.tipshape,
    //                    @tip_type = ZaDM_M010.tip_type,
    //                    @blank = ZaDM_M010.blank,
    //                    @extrapiece = ZaDM_M010.extrapiece,
    //                    @usedin_id = ZaDM_M010.usedin_id,
    //                    @noofball = ZaDM_M010.noofball,
    //                    @needlelen = ZaDM_M010.needlelen,
    //                    @needledia = ZaDM_M010.needledia,
    //                    @shanklen = ZaDM_M010.shanklen,
    //                    @prodnm = ZaDM_M010.prodnm,
    //                    @editby = (object)ZaDM_M010.editby ?? DBNull.Value,
    //                    @ItemCode = ZaDM_M010.ItemCode,
    //                    @ink = ZaDM_M010.ink,
    //                    @ild = ZaDM_M010.ild,
    //                    @comp_code=ZaDM_M010.comp_code
    //                }, commandType: CommandType.StoredProcedure);

    //                string strReturnData = ObjectSerializationService.ObjectToXML(ZaDM_M010);
    //                return strReturnData;
    //            }
    //        }
    //        catch (SqlException ex)
    //        {
    //            throw new CreateException(ex.ErrorCode, ex.Message, ex);
    //        }
    //        catch (CreateException ex)
    //        {
    //            throw new CreateException(ex.Message, ex);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new CreateException(ex.Message, ex);
    //        }
    //    }
    //    public string Delete(int Request)
    //    {
    //        try
    //        {
    //            using (IDbConnection conn = new SqlConnection(connectionString))
    //            {
    //                int intOut = conn.Execute("ZADM_M010Delete", new { @prod_id = Request }, commandType: CommandType.StoredProcedure);
    //                return intOut.ToString();
    //            }
    //        }
    //        catch (SqlException ex)
    //        {
    //            throw new CreateException(ex.ErrorCode, ex.Message, ex);
    //        }
    //        catch (CreateException ex)
    //        {
    //            throw new CreateException(ex.Message, ex);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new CreateException(ex.Message, ex);
    //        }
    //    }
    //    public string GetData(string strType, int intValue, string strValue)
    //    {
    //        MultipleContext_ZADM_M010 MC = new MultipleContext_ZADM_M010();
    //        try
    //        {
    //            using (IDbConnection conn = new SqlConnection(connectionString))
    //            {
    //                var reader = conn.QueryMultiple("ZADM_M010LoadAll", new { @item_code = strValue, @strType = strType }, commandType: CommandType.StoredProcedure);
    //                if (strType == "LoadInitialData")
    //                {
    //                    var finishgood = reader.Read<ZADM_M010>().ToList();
    //                    MC.FinishGood = finishgood.ToList();

    //                    var model = reader.Read<ZADM_M009_P>().ToList();
    //                    MC.Model = model.ToList();

    //                    var wiretype = reader.Read<ZADM_M004_P>().ToList();
    //                    MC.wiretype_master = wiretype.ToList();

    //                    var wiresize = reader.Read<ZADM_M003_P>().ToList();
    //                    MC.wiresize_master = wiresize.ToList();

    //                    var balldia = reader.Read<ZADM_M001_P>().ToList();
    //                    MC.Balldia = balldia.ToList();

    //                    var balltype = reader.Read<ZADM_M002_P>().ToList();
    //                    MC.balltype_master = balltype.ToList();

    //                    var totlength = reader.Read<ZADM_M008_P>().ToList();
    //                    MC.totlength_master = totlength.ToList();

    //                    var ink = reader.Read<ZADM_M006_P>().ToList();
    //                    MC.INKMaster = ink.ToList();

    //                    var ild = reader.Read<ZADM_M007_P>().ToList();
    //                    MC.ILDMaster = ild.ToList();                               

    //                }
    //                else if (strType == "LoadAttachment")
    //                {
    //                    var Attachment = reader.Read<COM_T003>().ToList();
    //                    MC.Attachment = Attachment.ToList();
    //                }

    //                string strData = ObjectSerializationService.ObjectToXML(MC);
    //                return strData;
    //            }
    //        }
    //        catch (SqlException ex)
    //        {
    //            throw new CreateException(ex.ErrorCode, ex.Message, ex);
    //        }
    //        catch (DivideByZeroException ex)
    //        {
    //            throw new CreateException(ex.Message, ex);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new CreateException(ex.Message, ex);
    //        }
    //    }
    //    public string GetData(int intValue)
    //    {
    //        ADM_M036 aDM_M036 = new ADM_M036();
    //        try
    //        {
    //            using (IDbConnection conn = new SqlConnection(connectionString))
    //            {
    //                var reader = conn.QueryMultiple("ZADM_M010LoadAll", commandType: CommandType.StoredProcedure);
    //                {
    //                    string strData = ObjectSerializationService.ObjectToXML(aDM_M036);
    //                    return strData;
    //                }
    //            }
    //        }
    //        catch (SqlException ex)
    //        {
    //            throw new CreateException(ex.ErrorCode, ex.Message, ex);
    //        }
    //        catch (DivideByZeroException ex)
    //        {
    //            throw new CreateException(ex.Message, ex);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new CreateException(ex.Message, ex);
    //        }
    //    }
    //}
    //public class MultipleContext_ZADM_M010
    //{
    //    public List<ZADM_M010> FinishGood { get; set; }
    //    public List<ZADM_M009_P> Model { get; set; }
    //    public List<ZADM_M004_P> wiretype_master { get; set; }
    //    public List<ZADM_M003_P> wiresize_master { get; set; }
    //    public List<ZADM_M001_P> Balldia { get; set; }
    //    public List<ZADM_M002_P> balltype_master { get; set; }
    //    public List<ZADM_M008_P> totlength_master { get; set; }

    //    public List<ZADM_M006_P> INKMaster { get; set; }
    //    public List<ZADM_M007_P> ILDMaster { get; set; }
    //    public List<COM_T003> Attachment { get; set; }


    //}
}
