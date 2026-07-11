using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.EF;
using System.Data.SqlClient;
using System.Data;
using Reflection.EF.Production;
using Dapper;

namespace Reflection.BusinessLogic
{
    public class ESO_T001_BL : ReflectionBusinessLogic
    {
        private static String connectionString;

        ESO_T001 MasterEntity = new ESO_T001();
        MultipleContext_ESO_T001 MC = new MultipleContext_ESO_T001();
        public ESO_T001_BL(string BusinessEntity)
        {
            connectionString = base.ReflectionConnectionString;
        }
        public ESO_T001_BL()
        {
            connectionString = base.ReflectionConnectionString;
        }
        public string Insert(string Request)
        {
            MasterEntity = (ESO_T001)ObjectSerializationService.XMLToObject(Request, MasterEntity);
            String strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ESO_T001_Insert", new
                    {
                        @entry_dt = MasterEntity.entry_dt,
                        @prod_dt = MasterEntity.prod_dt,
                        @unit_code = MasterEntity.unit_code,
                        @machinecode = MasterEntity.machinecode,
                        @Request = Request,
                        @add_by = MasterEntity.add_by,
                        @comp_code = MasterEntity.comp_code,
                        @location_Id = MasterEntity.location_Id,
                        @doc_cat = MasterEntity.doc_cat,
                        @doc_type = MasterEntity.doc_type

                    }, commandType: CommandType.StoredProcedure);

                    //var FlipGridData = reader.Read<ESO_T001_P>().ToList();
                    //MC.SortList = FlipGridData.ToList();

                    var sorting = reader.Read<ESO_T001>().ToList();
                    List<ESO_T001> sortingList = sorting.ToList();
                    if (sortingList.Count > 0)
                    {
                        MasterEntity = sortingList[0];
                    }
                    strReturnData = ObjectSerializationService.ObjectToXML(MasterEntity);
                    return strReturnData;
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
        public string Update(string Request)
        {
            String strReturnData = "";

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ESO_T001Update", new { @Request = Request },commandTimeout: 0, commandType: CommandType.StoredProcedure);

                    var FlipGridData = reader.Read<ESO_T001_P>().ToList();
                    MC.SortList = FlipGridData.ToList();

                    var MasterData = reader.Read<ESO_T001>().ToList();
                    List<ESO_T001> Masterlist = MasterData.ToList();
                    MasterEntity = Masterlist[0];

                    MasterEntity.XmlDataDocument_ESO_T001 = ObjectSerializationService.ObjectToXML(MC.SortList);
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
        public string Delete(int Request)
        {
            try
            {
                int intOut = 0;// dbContext.ESO_T001Delete(Request);
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
        public string GetData(string Request, string strType, int intValue, string strValue, string doc_code, string comp_code, string location_Id, string add_by, string request1, string request2, string request3, string request4, string request5)
        {
            //string RequestOption = Request.Split('!')[0];
            string strReturnData = "";
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    var reader = conn.QueryMultiple("ESO_T001_LoadAll", new
                    {
                        @request_type = strType,
                        @comp_code = comp_code,
                        @location_Id = location_Id,
                        @add_by = add_by,
                        @machinecode = request1 ,
                        @prod_dt = request2,
                        @defect = request3,
                        @EmpId = request4,
                        @doc_cat =request5,
                        @request = strValue,
                        @doc_type = request5
                    }, commandType: CommandType.StoredProcedure);

                    if (strType == "LoadAll")
                    {
                        var sort = reader.Read<ESO_T001_P>().ToList();
                        MC.SortList = sort.ToList();

                        var MachineCode = reader.Read<ZADM_M013_P>().ToList();
                        MC.MachineCodeList = MachineCode.ToList();

                        var UOM = reader.Read<ADM_M038_B_P>().ToList();
                        MC.UOMList = UOM.ToList();

                        var Defect = reader.Read<ZADM_M016_P>().ToList();
                        MC.DefectList = Defect.ToList();

                        var Engineer = reader.Read<ADM_M038_B_P>().ToList();
                        MC.Engineer = Engineer.ToList();

                        var Batch = reader.Read<PPC_T001_P>().ToList();
                        MC.BatchNo = Batch.ToList();

                        var Shift = reader.Read<ADM_M042_P>().ToList();
                        MC.Shift = Shift.ToList();

                        var ShiftIncharge = reader.Read<ADM_M024_P>().ToList();
                        MC.ShiftIncharge = ShiftIncharge.ToList();

                    }
                    else if (strType == "LoadDetail" || strType == "LoadMachineDetail")
                    {
                        var Sorting = reader.Read<ESO_T001>().ToList();
                        MC.Sorting = Sorting.ToList();
                    }
                    else if (strType == "DailyDefectReport")
                    {
                        var Sorting1 = reader.Read<ESO_T001_rpt>().ToList();
                        MC.sorting_rpt = Sorting1.ToList();
                    }
                    else if (strType == "DatewiseDefectReport")
                    {
                        var Sorting1 = reader.Read<ESO_T001_rpt>().ToList();
                        MC.sorting_rpt = Sorting1.ToList();
                    }
                    else if (strType == "MonthwiseDefectReport")
                    {
                        var Sorting1 = reader.Read<ESO_T001_rpt>().ToList();
                        MC.sorting_rpt = Sorting1.ToList();
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
    }
    public class MultipleContext_ESO_T001
    {
        public List<ESO_T001Flip> DocumentDataFlipGrid { get; set; }//BF data
        public List<ESO_T001> Sorting { get; set; }//Sorting
        public List<ESO_T001_P> SortList { get; set; }  //Sort 
        public List<ZADM_M013_P> MachineCodeList { get; set; }//machinecode
        public List<ADM_M038_B_P> UOMList { get; set; }  //UOM
        public List<ZADM_M016_P> DefectList { get; set; }  //Defect            
        public List<ADM_M038_B_P> Engineer { get; set; }
        public List<PPC_T001_P> BatchNo { get; set; }
        public List<ADM_M042_P> Shift { get; set; }
        public List<ADM_M024_P> ShiftIncharge { get; set; }
        public List<ESO_T001_rpt> sorting_rpt { get; set; } //Sort

    }
    public class ESO_T001_rpt
    {
        public string doc_no { get; set; }
        public Nullable<System.DateTime> entry_dt { get; set; }
        public Nullable<System.DateTime> prod_dt { get; set; }
        public Nullable<System.DateTime> FrmDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string machinecode { get; set; }
        public string defect_type { get; set; }
        public Nullable<decimal> rej_qty_1 { get; set; }
        public Nullable<decimal> rej_qty_2 { get; set; }
        public Nullable<decimal> total { get; set; }
        public Nullable<decimal> Grandtotal { get; set; }
        public string sort_by { get; set; }
        public string shift { get; set; }
        public string defect_condition { get; set; }
        public Nullable<bool> active { get; set; }
        public Nullable<int> add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public Nullable<int> edit_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string sort_type { get; set; }
        public string sort_cat { get; set; }

        public string shift_incharge { get; set; }
        public string ModelNm { get; set; }
        public Nullable<System.DateTime> SortingDate { get; set; }

        public string Month { get; set; }
        public string MonthNm { get; set; }
        public string remark { get; set; }
        public string machinecode1 { get; set; }
        public string machineorder { get; set; }
        public string unit_code { get; set; }
        public Nullable<decimal> counter_qty { get; set; }
        public Nullable<System.DateTime> in_date { get; set; }
        public Nullable<System.DateTime> out_date { get; set; }
        public Nullable<decimal> c_qty { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public string ild { get; set; }

    }
}
