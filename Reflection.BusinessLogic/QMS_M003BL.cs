using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Reflection.EF.Communication;
using Reflection.EF.QMS;

namespace Reflection.BusinessLogic
{
    public class QMS_M003BL : ReflectionBusinessLogic
    {
        private static string connectionString;
        QMS_M003 MasterEntity = new QMS_M003();
        MultipleContext_QMS_M003 MC = new MultipleContext_QMS_M003();
        public QMS_M003BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public QMS_M003BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M003Insert", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var dataGrid = reader.Read<QMS_M003Flip>().ToList();
                    MC.DocumentDataFlipGrid = dataGrid.ToList();

                    var instr = reader.Read<QMS_M003>().ToList();
                    MC.MasterEntity = instr.ToList();
                    if (MC.MasterEntity.Count > 0)
                    {
                        MasterEntity = MC.MasterEntity[0];
                    }

                    var Acc = reader.Read<QMS_M003_A>().ToList();
                    MC.Accessory = Acc.ToList();

                    var para = reader.Read<QMS_M003_B>().ToList();
                    MC.DetailEntity = para.ToList();

                    MasterEntity.XmlDataDocument_QMS_M003_A = ObjectSerializationService.ObjectToXML(MC.Accessory);
                    MasterEntity.XmlDataDocument_QMS_M003_B = ObjectSerializationService.ObjectToXML(MC.DetailEntity);
                    MasterEntity.XmlDataDocument_QMS_M003FLIP = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
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
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M003Update", new { @Request = Request }, commandType: CommandType.StoredProcedure);

                    var dataGrid = reader.Read<QMS_M003Flip>().ToList();
                    MC.DocumentDataFlipGrid = dataGrid.ToList();

                    var instr = reader.Read<QMS_M003>().ToList();
                    MC.MasterEntity = instr.ToList();
                    if (MC.MasterEntity.Count > 0)
                    {
                        MasterEntity = MC.MasterEntity[0];
                    }

                    var Acc = reader.Read<QMS_M003_A>().ToList();
                    MC.Accessory = Acc.ToList();

                    var para = reader.Read<QMS_M003_B>().ToList();
                    MC.DetailEntity = para.ToList();

                    MasterEntity.XmlDataDocument_QMS_M003_A = ObjectSerializationService.ObjectToXML(MC.Accessory);
                    MasterEntity.XmlDataDocument_QMS_M003_B = ObjectSerializationService.ObjectToXML(MC.DetailEntity);
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
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
                    int intOut = 0; //conn.Execute("QMS_M003Delete", new { @srNo = Request }, commandType: CommandType.StoredProcedure);
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
            try
            {
                string RequestOption = RequestValue.Split('!')[0];
                string strReturnData = "";

                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("QMS_M003LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var instr = reader.Read<QMS_M003Flip>().ToList();
                        MC.DocumentDataFlipGrid = instr.ToList();

                        var lab = reader.Read<ADM_M003_B_P>().ToList();
                        MC.Laboratory = lab.ToList();

                        var grp = reader.Read<ADM_M018_P>().ToList();
                        MC.Cat = grp.ToList();

                        var sgrp = reader.Read<ADM_M019_P>().ToList();
                        MC.SubCat = sgrp.ToList();

                        var rig = reader.Read<QMS_M008_P>().ToList();
                        MC.Rig = rig.ToList();

                        var purchase = reader.Read<Inst_Pur_Details_P>().ToList();
                        MC.PurOrder = purchase.ToList();

                        var reqNo = reader.Read<Inst_Pur_Details_P>().ToList();
                        MC.ReqNo = reqNo.ToList();

                        var purInvoice = reader.Read<Inst_Pur_Details_P>().ToList();
                        MC.PurInvoice = purInvoice.ToList();

                        var partyMaster = reader.Read<ADM_M028_P>().ToList();
                        MC.Supplier = partyMaster.ToList();

                        var calinst = reader.Read<QMS_M003_P>().ToList();
                        MC.CalInst = calinst.ToList();

                        var acce = reader.Read<ADM_M022_P>().ToList();
                        MC.AccItem = acce.ToList();

                        var scope = reader.Read<QMS_M004_P>().ToList();
                        MC.AccScope = scope.ToList();

                        var employee = reader.Read<ADM_M024_P>().ToList();
                        MC.Employees = employee.ToList();

                        var tracblty = reader.Read<QMS_M010_P>().ToList();
                        MC.Tracibility = tracblty.ToList();

                        var Unitmaster = reader.Read<ADM_M038_B_P>().ToList();
                        MC.UnitMaster = Unitmaster.ToList();

                        var para = reader.Read<QMS_M009_F>().ToList();
                        MC.ParameterCode = para.ToList();
                    }
                    else if (RequestOption == "LoadDocumentByDocumentNumber")
                    {
                        var instr = reader.Read<QMS_M003>().ToList();
                        MC.MasterEntity = instr.ToList();

                        var Acc = reader.Read<QMS_M003_A>().ToList();
                        MC.Accessory = Acc.ToList();

                        var Attachment = reader.Read<COM_T003>().ToList();
                        MC.Attachment = Attachment.ToList();

                        var para = reader.Read<QMS_M003_B>().ToList();
                        MC.DetailEntity = para.ToList();
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
        public class MultipleContext_QMS_M003
        {
            public List<QMS_M003Flip> DocumentDataFlipGrid { get; set; }
            public List<ADM_M003_B_P> Laboratory { get; set; }  //labrotory Master   
            public List<ADM_M018_P> Cat { get; set; }  //Cat Master
            public List<ADM_M019_P> SubCat { get; set; }  //subcat Master
            public List<QMS_M008_P> Rig { get; set; }  //rig Master
            public List<Inst_Pur_Details_P> PurOrder { get; set; }
            public List<Inst_Pur_Details_P> ReqNo { get; set; }
            public List<Inst_Pur_Details_P> PurInvoice { get; set; }
            public List<ADM_M028_P> Supplier { get; set; }  //Party Master  
            public List<QMS_M003_P> CalInst { get; set; }
            public List<ADM_M022_P> AccItem { get; set; }  //Accessories from item Master
            public List<QMS_M004_P> AccScope { get; set; } // Accessory scope
            public List<ADM_M024_P> Employees { get; set; } // Responsible Person
            public List<COM_T003> Attachment { get; set; } // Attachment Collection
            public List<QMS_M010_P> Tracibility { get; set; }       
            public List<ADM_M038_B_P> UnitMaster { get; set; } //Unit Master
            public List<QMS_M009_F> ParameterCode { get; set; } //Parameter Master

            public List<QMS_M003> MasterEntity { get; set; }  //Intrument Master
            public List<QMS_M003_A> Accessory { get; set; }  //Accessory Master
            public List<QMS_M003_B> DetailEntity { get; set; }  //Parameter Master
        }
    }
}