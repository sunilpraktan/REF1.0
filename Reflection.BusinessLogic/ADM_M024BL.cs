using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.EF;
using System.Data.SqlClient;
using Reflection.EF.Admin;
using System.Data;
using Dapper;
using Reflection.EF.Communication;

namespace Reflection.BusinessLogic
{
    public class ADM_M024BL : ReflectionBusinessLogic
    {
        MultipleContext_ADM_M024 MC = new MultipleContext_ADM_M024();


        private static string connectionString;
        ADM_M024 aDM_M024 = new ADM_M024();

        public ADM_M024BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ADM_M024BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            try
            {
                aDM_M024 = (ADM_M024)ObjectSerializationService.XMLToObject(Request, aDM_M024);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M024Insert", new
                    {
                        @Request = Request,
                        @Photo = aDM_M024.Photo,
                        @digi_sign=aDM_M024.digi_sign
                    }, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<ADM_M024_P>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var master = reader.Read<ADM_M024>().ToList();
                    List<ADM_M024> Master = master.ToList();
                    if (Master.Count > 0)
                    {
                        aDM_M024 = Master[0];
                    }

                    var sales = reader.Read<ADM_M024_A>().ToList();
                    MC.SalesEntity = sales.ToList();

                    var purchase = reader.Read<ADM_M024_B>().ToList();
                    MC.PurchaseEntity = purchase.ToList();

                    var Customer = reader.Read<ADM_M024_C>().ToList();
                    MC.CustEntity = Customer.ToList();

                    aDM_M024.XmlDataDocument_ADM_M024BackFlip = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                    aDM_M024.XmlDataDocument_ADM_M024_A = ObjectSerializationService.ObjectToXML(MC.SalesEntity);
                    aDM_M024.XmlDataDocument_ADM_M024_B = ObjectSerializationService.ObjectToXML(MC.PurchaseEntity);
                    aDM_M024.XmlDataDocument_ADM_M024_C = ObjectSerializationService.ObjectToXML(MC.CustEntity);
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(aDM_M024);
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
                aDM_M024 = (ADM_M024)ObjectSerializationService.XMLToObject(Request, aDM_M024);
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ADM_M024Update", new
                    {
                        @Request = Request,
                        @Photo = aDM_M024.Photo,
                        @digi_sign = aDM_M024.digi_sign
                    }, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<ADM_M024_P>().ToList();
                    MC.DocumentDataFlipGrid = FlipGridData.ToList();

                    var master = reader.Read<ADM_M024>().ToList();
                    List<ADM_M024> Master = master.ToList();
                    if (Master.Count > 0)
                    {
                        aDM_M024 = Master[0];
                    }
                    var sales = reader.Read<ADM_M024_A>().ToList();
                    MC.SalesEntity = sales.ToList();

                    var purchase = reader.Read<ADM_M024_B>().ToList();
                    MC.PurchaseEntity = purchase.ToList();

                    var Customer = reader.Read<ADM_M024_C>().ToList();
                    MC.CustEntity = Customer.ToList();

                    aDM_M024.XmlDataDocument_ADM_M024BackFlip = ObjectSerializationService.ObjectToXML(MC.DocumentDataFlipGrid);
                    aDM_M024.XmlDataDocument_ADM_M024_A = ObjectSerializationService.ObjectToXML(MC.SalesEntity);
                    aDM_M024.XmlDataDocument_ADM_M024_B = ObjectSerializationService.ObjectToXML(MC.PurchaseEntity);
                    aDM_M024.XmlDataDocument_ADM_M024_C = ObjectSerializationService.ObjectToXML(MC.CustEntity);
                }
                string strReturnData = ObjectSerializationService.ObjectToXML(aDM_M024);
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
                    int intOut = conn.Execute("ADM_M024Delete", new { @EmpId = Request }, commandType: CommandType.StoredProcedure);
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
                    var reader = conn.QueryMultiple("ADM_M024_LoadAll", new { @Request = RequestValue }, commandType: CommandType.StoredProcedure);

                    if (RequestOption == "LoadInitialData")
                    {
                        var FlipGridData = reader.Read<ADM_M024_P>().ToList();
                        MC.DocumentDataFlipGrid = FlipGridData.ToList();

                        var company = reader.Read<ADM_M002_P>().ToList();
                        MC.Company = company.ToList();

                        var Location = reader.Read<ADM_M003_P>().ToList();
                        MC.Locations = Location.ToList();
                      
                        var Department = reader.Read<ADM_M025_P>().ToList();
                        MC.Departments = Department.ToList();

                        var Disignation = reader.Read<ADM_M026_P>().ToList();
                        MC.Disignations = Disignation.ToList();

                        var salesgroup = reader.Read<ADM_M001_H_P>().ToList();
                        MC.SalesGroup = salesgroup.ToList();

                        var purchasegroup = reader.Read<ADM_M001_P_P>().ToList();
                        MC.PurchaseGroup = purchasegroup.ToList();

                        var customer = reader.Read<ADM_M028_P>().ToList();
                        MC.Customers = customer.ToList();

                        var EmployeeType = reader.Read<HRM_M004_P>().ToList();
                        MC.EmployeeTypeList = EmployeeType.ToList();

                        //var ReportingTo = reader.Read<ADM_M024>().ToList();
                        //MC.Employees = ReportingTo.ToList();


                    }
                    else if (RequestOption == "LoadDocumentById")
                    {
                        var emps = reader.Read<ADM_M024>().ToList();
                        MC.Employees = emps.ToList();

                        var sales = reader.Read<ADM_M024_A>().ToList();
                        MC.SalesEntity = sales.ToList();

                        var purchase = reader.Read<ADM_M024_B>().ToList();
                        MC.PurchaseEntity = purchase.ToList();

                        var customer = reader.Read<ADM_M024_C>().ToList();
                        MC.CustEntity = customer.ToList();

                        var AttachmentList = reader.Read<COM_T003>().ToList();
                        MC.AttachmentList = AttachmentList.ToList();
                    }
                    else if (RequestOption == "Employee_Report")
                    {
                        var emps = reader.Read<ADM_M024>().ToList();
                        MC.Employees = emps.ToList();
                    }
                    else if (RequestOption == "LoadBackFlipData")
                    {
                        var FlipGridData = reader.Read<ADM_M024_P>().ToList();
                        MC.DocumentDataFlipGrid = FlipGridData.ToList();

                        strReturnData = ObjectSerializationService.ObjectToXML(MC);
                    }
                    string strData = ObjectSerializationService.ObjectToXML(MC);
                    return strData;
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
    }
    public class MultipleContext_ADM_M024
    {
        public List<ADM_M024_P> DocumentDataFlipGrid { get; set; }//BF data
        public List<ADM_M024> Employees { get; set; }
        public List<ADM_M003_P> Locations { get; set; }
        public List<ADM_M025_P> Departments { get; set; }
        public List<ADM_M026_P> Disignations { get; set; }
        public List<ADM_M001_H_P> SalesGroup { get; set; }  
        public List<ADM_M001_P_P> PurchaseGroup { get; set; }
        public List<ADM_M028_P> Customers { get; set; }
        public List<ADM_M024_A> SalesEntity { get; set; }
        public List<ADM_M024_B> PurchaseEntity { get; set; }
        public List<ADM_M024_C> CustEntity { get; set; }
        public List<ADM_M002_P> Company { get; set; }
        public List<COM_T003> AttachmentList { get; set; }
        public List<HRM_M004_P> EmployeeTypeList { get; set; }

    }
}
