using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using Reflection.EF.CRM;
using System.Xml.Serialization;
using Reflection.EF.Admin;
using Dapper;


namespace Reflection.BusinessLogic
{
    public class ADM_M038_CBL : ReflectionBusinessLogic
    {        
        static int obj = 0;
        private static string connectionString;

        ADM_M038_C aDM_M038_C = new ADM_M038_C();
        ADM_M038_D aDM_M038_D = new ADM_M038_D();
        ADM_M038_E aDM_M038_E = new ADM_M038_E();
        MultipleContext_ADM_M038_C MC = new MultipleContext_ADM_M038_C();
        MultipleContext_ADM_M038_D MCD = new MultipleContext_ADM_M038_D();
        MultipleContext_ADM_M038_E MCE = new MultipleContext_ADM_M038_E();
        public ADM_M038_CBL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M038_CBL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                ADM_M038 aDM_M038 = new ADM_M038();

                aDM_M038 = (ADM_M038)ObjectSerializationService.XMLToObject(Request, aDM_M038);

              
                string strReturnData = "";

                    if (aDM_M038.Index == 0)
                    {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("ADM_M038_CInsert", new
                        {
                            @Request = aDM_M038.XmlDataDocument

                        }, commandType: CommandType.StoredProcedure);



                        var uom_std = reader.Read<ADM_M038_C>().ToList();
                        MC.UOM_Convrsn_Stand = uom_std.ToList();
                        if (MC.UOM_Convrsn_Stand.Count > 0)
                        {
                            aDM_M038.XmlDataDocument = ObjectSerializationService.ObjectToXML(MC.UOM_Convrsn_Stand[0]);
                        }
                    }
                    strReturnData = ObjectSerializationService.ObjectToXML(aDM_M038);
                }
                else if (aDM_M038.Index == 1)
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("ADM_M038_DInsert", new
                        {
                            @Request = aDM_M038.XmlDataDocument

                        }, commandType: CommandType.StoredProcedure);

                        var uom_intra = reader.Read<ADM_M038_D>().ToList();
                        MCD.UOM_Convrsn_Intra = uom_intra.ToList();
                        if (MCD.UOM_Convrsn_Intra.Count > 0)
                        {
                            aDM_M038.XmlDataDocument = ObjectSerializationService.ObjectToXML(MCD.UOM_Convrsn_Intra[0]);
                        }
                    }
                    strReturnData = ObjectSerializationService.ObjectToXML(aDM_M038);
                }
                else if (aDM_M038.Index == 2)
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("ADM_M038_EInsert", new
                        {
                            @Request = aDM_M038.XmlDataDocument

                        }, commandType: CommandType.StoredProcedure);


                        var uom_inter = reader.Read<ADM_M038_E>().ToList();
                        MCE.UOM_Convrsn_Inter = uom_inter.ToList();
                        if (MCE.UOM_Convrsn_Inter.Count > 0)
                        {
                            aDM_M038.XmlDataDocument = ObjectSerializationService.ObjectToXML(MCE.UOM_Convrsn_Inter[0]);
                        }
                    }
                    strReturnData = ObjectSerializationService.ObjectToXML(aDM_M038);
                }
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
                ADM_M038 aDM_M038 = new ADM_M038();
                int intOut = 0;
                aDM_M038 = (ADM_M038)ObjectSerializationService.XMLToObject(Request, aDM_M038);
                if (aDM_M038.Index == 0)
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        intOut = conn.Execute("ADM_M038_CInsert", new
                        {
                            @Request = aDM_M038.XmlDataDocument

                        }, commandType: CommandType.StoredProcedure);
                    }

                }
                else if (aDM_M038.Index == 1)
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        intOut = conn.Execute("ADM_M038_DUpdate", new
                        {
                            @Request = aDM_M038.XmlDataDocument

                        }, commandType: CommandType.StoredProcedure);
                    }
                   
                }
                else if (aDM_M038.Index == 2)
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        intOut = conn.Execute("ADM_M038_EUpdate", new
                        {
                            @Request = aDM_M038.XmlDataDocument

                        }, commandType: CommandType.StoredProcedure);
                    }                
                }
                return intOut.ToString();
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
                ADM_M038_Delete aDM_M038_Delete = new ADM_M038_Delete();
                int intOut = 0;
                aDM_M038_Delete = (ADM_M038_Delete)ObjectSerializationService.XMLToObject(Request, aDM_M038_Delete);
                if (aDM_M038_Delete.Index == 0)
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                         intOut = conn.Execute("ADM_M038_CDelete", new { @id = Request }, commandType: CommandType.StoredProcedure);

                        return intOut.ToString();
                    }
                
                }
                else if (aDM_M038_Delete.Index == 1)
                {
                     using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                         intOut = conn.Execute("ADM_M038_DDelete", new { @id = Request }, commandType: CommandType.StoredProcedure);

                        return intOut.ToString();
                    }

                }
                else if (aDM_M038_Delete.Index == 2)
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        intOut = conn.Execute("ADM_M038_EDelete", new { @id = Request }, commandType: CommandType.StoredProcedure);

                        return intOut.ToString();
                    }

                }
                return intOut.ToString();
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
        public string GetData(string strType)
        {

            string strData = "";
            try
            {
                if (strType == "ADM_M038_CLoadAll")//UOM Conversion - Standard   
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("ADM_M038_CLoadAll", //new { // @strType = strType },
                            commandType: CommandType.StoredProcedure);


                        var uom_std = reader.Read<ADM_M038_C>().ToList();
                        MC.UOM_Convrsn_Stand = uom_std.ToList();

                        var meascls = reader.Read<ADM_M038_A_P>().ToList();
                        MC.Measur_Cls = meascls.ToList();

                        var Uom = reader.Read<ADM_M038_B_P>().ToList();
                        MC.UOM_Master = Uom.ToList();
                    }
                    strData = ObjectSerializationService.ObjectToXML(MC);
                }
                else if (strType == "ADM_M038_DLoadAll")//UOM Conversion - Intra 
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("ADM_M038_DLoadAll",// new{ @strType = strType }, 
                                commandType: CommandType.StoredProcedure);

                        var uom_intra = reader.Read<ADM_M038_D>().ToList();
                        MCD.UOM_Convrsn_Intra = uom_intra.ToList();
                      
                        var itm = reader.Read<ADM_M022_P>().ToList();
                        MCD.Items = itm.ToList();
                      
                        var Uom = reader.Read<ADM_M038_B_P>().ToList();
                        MCD.UOM_Master = Uom.ToList();
                    }
                    strData = ObjectSerializationService.ObjectToXML(MCD);
                }
                else if (strType == "ADM_M038_ELoadAll")//UOM Conversion - Inter 
                {
                    using (IDbConnection conn = new SqlConnection(connectionString))
                    {
                        var reader = conn.QueryMultiple("ADM_M038_ELoadAll", //new{@strType = strType}, 
                            commandType: CommandType.StoredProcedure);


                        var uom_inter = reader.Read<ADM_M038_E>().ToList();
                        MCE.UOM_Convrsn_Inter = uom_inter.ToList();
                     
                        var itm = reader.Read<ADM_M022_P>().ToList();
                        MCE.Items = itm.ToList();
                      
                        var Uom = reader.Read<ADM_M038_B_P>().ToList();
                        MCE.UOM_Master = Uom.ToList();
                    }
                    strData = ObjectSerializationService.ObjectToXML(MCE);
                }
                return strData;
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
    public class MultipleContext_ADM_M038_C
    {
        public List<ADM_M038_C> UOM_Convrsn_Stand { get; set; }//UOM Conversion - Standard         
        public List<ADM_M038_A_P> Measur_Cls { get; set; }//Measurement Class    
        public List<ADM_M038_B_P> UOM_Master { get; set; }//UOM Master         
    }
    public class MultipleContext_ADM_M038_D
    {
        public List<ADM_M038_D> UOM_Convrsn_Intra { get; set; }//UOM Conversion - Intra 
        public List<ADM_M022_P> Items { get; set; }//Item Master      
        public List<ADM_M038_B_P> UOM_Master { get; set; }//UOM Master 
    }
    public class MultipleContext_ADM_M038_E
    {
        public List<ADM_M038_E> UOM_Convrsn_Inter { get; set; }//UOM Conversion - Inter 
        public List<ADM_M022_P> Items { get; set; }//Item Master      
        public List<ADM_M038_B_P> UOM_Master { get; set; }//UOM Master 
    }
}
