using Reflection.BusinessEntity.QMS;
using Reflection.Modules.QMS.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Reflection.Modules.QMS.Views
{
    /// <summary>
    /// Interaction logic for Uncertainty.xaml
    /// </summary>
    public partial class Uncertainty : WindowElement
    {
        QMS_UNC_VM vmObj = new QMS_UNC_VM();
        public Uncertainty()
        {
            InitializeComponent();
            this.DataContext = vmObj;
        }
        public Uncertainty(string ts_code)
        {
            InitializeComponent();
            this.DataContext = vmObj;
        }
        public Uncertainty(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = vmObj;
        }

        int mn;
        internal string TestTypeParameter;
        private void Load_button(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btnTestType = (Button)sender;
                TestTypeParameter = btnTestType.CommandParameter.ToString();
                //vmObj.TestTypeParameter = TestTypeParameter;
                int HeaderValueDefCountTemp = 0;
                int HeaderValueDefCount = 0;

                if (vmObj.MC.TestType != null && vmObj.MC.TestType.Count > 0)
                {
                    if (vmObj.MC.TestType[0].formula_code == "S350" || vmObj.MC.TestType[0].formula_code == "L350")
                    {
                        if (vmObj.MC.TestType[0].test_code == "Sp_S350" || vmObj.MC.TestType[0].test_code == "Sp_L350")
                        {
                            for (int i = 71; i <= 83; i++)
                            {
                                dgDataSheet.Columns[i].Header = null;
                                dgDataSheet.Columns[i].Visibility = Visibility.Collapsed;
                                dgDataSheet.Columns[i].IsReadOnly = false;
                            }

                            dgDataSheet.Columns[71].Header = "Walze/Can";
                            dgDataSheet.Columns[71].Visibility = Visibility.Visible;
                            dgDataSheet.Columns[71].IsReadOnly = true;
                            dgDataSheet.Columns[72].Header = "Old Factor";
                            dgDataSheet.Columns[72].Visibility = Visibility.Visible;
                            dgDataSheet.Columns[73].Header = "New Factor";
                            dgDataSheet.Columns[73].Visibility = Visibility.Visible;
                            dgDataSheet.Columns[73].IsReadOnly = true;

                            if (TestTypeParameter == "Test" || TestTypeParameter == "Test Resul")
                            {
                                dgDataSheet.Columns[75].Header = "Deviation in %";
                                dgDataSheet.Columns[75].Visibility = Visibility.Visible;
                                dgDataSheet.Columns[75].IsReadOnly = true;
                            }
                            else
                            {
                                if (TestTypeParameter == "Test at -3")
                                {
                                    dgDataSheet.Columns[76].Header = "Lateral Angle At -30";
                                    dgDataSheet.Columns[76].Visibility = Visibility.Visible;
                                    dgDataSheet.Columns[77].Header = "Walze Speed";
                                    dgDataSheet.Columns[77].Visibility = Visibility.Visible;
                                    dgDataSheet.Columns[78].Header = "Can Speed";
                                    dgDataSheet.Columns[78].Visibility = Visibility.Visible;
                                }
                                else if (TestTypeParameter == "Test at 30")
                                {
                                    dgDataSheet.Columns[76].Header = "Lateral Angle At 30";
                                    dgDataSheet.Columns[76].Visibility = Visibility.Visible;
                                    dgDataSheet.Columns[77].Header = "Walze Speed";
                                    dgDataSheet.Columns[77].Visibility = Visibility.Visible;
                                    dgDataSheet.Columns[78].Header = "Can Speed";
                                    dgDataSheet.Columns[78].Visibility = Visibility.Visible;
                                }
                            }
                        }
                    }
                    else if (vmObj.MC.TestType[0].formula_code == "SD10001")
                    {
                        for (int i = 71; i <= 83; i++)
                        {
                            dgDataSheet.Columns[i].Header = null;
                            dgDataSheet.Columns[i].Visibility = Visibility.Collapsed;
                            dgDataSheet.Columns[i].IsReadOnly = false;
                        }
                        // Value61 --Error
                        dgDataSheet.Columns[71].Header = "Variation";
                        dgDataSheet.Columns[71].Visibility = Visibility.Visible;
                        dgDataSheet.Columns[71].IsReadOnly = true;

                        // Value62 --Error in %
                        if (vmObj.MasterEntity.test_code == "HVC_DS")
                        {
                            dgDataSheet.Columns[72].Header = "% in FS";
                        }
                        else
                        {
                            dgDataSheet.Columns[72].Header = "% of Rdg";
                        }
                        dgDataSheet.Columns[72].Visibility = Visibility.Visible;
                        dgDataSheet.Columns[72].IsReadOnly = true;

                        dgDataSheet.Columns[81].Header = "Result";
                        dgDataSheet.Columns[81].Visibility = Visibility.Visible;
                        if (vmObj.MasterEntity.test_code != "HVC_DS")
                        {
                            dgDataSheet.Columns[82].Header = "Expanded Uncertaintity";
                            //dgDataSheet.Columns[82].Visibility = Visibility.Visible;
                            dgDataSheet.Columns[82].IsReadOnly = true;

                            dgDataSheet.Columns[83].Header = "Expanded Uncertaintity(In %)";
                            dgDataSheet.Columns[83].Visibility = Visibility.Visible;
                            dgDataSheet.Columns[83].IsReadOnly = true;
                        }
                    }
                    dgDataSheet.Visibility = 0;

                    // removable
                    #region Assign Bench Headers to datagrid
                    if (vmObj.MC.BenchHeader.Count > 0)
                    {
                        List<QMS_M009_C> tempBenchHeader = vmObj.MC.BenchHeader.Where(x => x.test_type_code == TestTypeParameter).ToList();

                        for (int i = 0; i < 9; i++)
                        {
                            dgDataSheet.Columns[i].Header = null;
                            dgDataSheet.Columns[i].Visibility = Visibility.Collapsed;
                        }

                        for (int i = 0; i < tempBenchHeader.Count; i++)
                        {
                            dgDataSheet.Columns[i].Header = tempBenchHeader[i].hdr_name;
                            dgDataSheet.Columns[i].Visibility = 0;

                            //if (i == 0)
                            //{
                            //    var items = from o in vmObj.MC.HeaderValue
                            //                where o.hdr_id == tempBenchHeader[i].hdr_id
                            //                select o;
                            //    vmObj.BenchValueList1 = items.ToList();

                            //    QMS_T001_VM.SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_D)x).column_value ?? "");
                            //    vmObj.TheFilter = (o, prefix) => (((QMS_M009_D)o).column_value ?? "").Contains(prefix.ToString().ToLower());
                            //    vmObj.ASBValue1 = new AutoSuggestTextViewModel<dynamic>(vmObj.BenchValueList1, vmObj.TheFilter, QMS_T001_VM.SuggestedValue, "column_value1", "column_value", false);
                            //    vmObj.ASBValue1.AutoSuggestVM.IsEmptyValueAllowed = true;

                            //    var defvalueCount = from o in vmObj.MC.HeaderValue
                            //                        where o.hdr_id == tempBenchHeader[i].hdr_id && o.def_bit == true
                            //                        select o;
                            //    HeaderValueDefCountTemp = defvalueCount.Count();
                            //}
                            //else if (i == 1)
                            //{
                            //    var items = from o in vmObj.MC.HeaderValue
                            //                where o.hdr_id == tempBenchHeader[i].hdr_id
                            //                select o;
                            //    vmObj.BenchValueList2 = items.ToList();

                            //    QMS_T001_VM.SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_D)x).column_value ?? "");
                            //    vmObj.TheFilter = (o, prefix) => (((QMS_M009_D)o).column_value ?? "").Contains(prefix.ToString().ToLower());
                            //    vmObj.ASBValue2 = new AutoSuggestTextViewModel<dynamic>(vmObj.BenchValueList2, vmObj.TheFilter, QMS_T001_VM.SuggestedValue, "column_value2", "column_value", false);
                            //    vmObj.ASBValue2.AutoSuggestVM.IsEmptyValueAllowed = true;

                            //    var defvalueCount = from o in vmObj.MC.HeaderValue
                            //                        where o.hdr_id == tempBenchHeader[i].hdr_id && o.def_bit == true
                            //                        select o;
                            //    HeaderValueDefCountTemp = defvalueCount.Count();
                            //}
                            //else if (i == 2)
                            //{
                            //    var items = from o in vmObj.MC.HeaderValue
                            //                where o.hdr_id == tempBenchHeader[i].hdr_id
                            //                select o;
                            //    vmObj.BenchValueList3 = items.ToList();

                            //    QMS_T001_VM.SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_D)x).column_value ?? "");
                            //    vmObj.TheFilter = (o, prefix) => (((QMS_M009_D)o).column_value ?? "").Contains(prefix.ToString().ToLower());
                            //    vmObj.ASBValue3 = new AutoSuggestTextViewModel<dynamic>(vmObj.BenchValueList3, vmObj.TheFilter, QMS_T001_VM.SuggestedValue, "column_value3", "column_value", false);
                            //    vmObj.ASBValue3.AutoSuggestVM.IsEmptyValueAllowed = true;

                            //    var defvalueCount = from o in vmObj.MC.HeaderValue
                            //                        where o.hdr_id == tempBenchHeader[i].hdr_id && o.def_bit == true
                            //                        select o;
                            //    HeaderValueDefCountTemp = defvalueCount.Count();
                            //}
                            //else if (i == 3)
                            //{
                            //    var items = from o in vmObj.MC.HeaderValue
                            //                where o.hdr_id == tempBenchHeader[i].hdr_id
                            //                select o;
                            //    vmObj.BenchValueList4 = items.ToList();

                            //    QMS_T001_VM.SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_D)x).column_value ?? "");
                            //    vmObj.TheFilter = (o, prefix) => (((QMS_M009_D)o).column_value ?? "").Contains(prefix.ToString().ToLower());
                            //    vmObj.ASBValue4 = new AutoSuggestTextViewModel<dynamic>(vmObj.BenchValueList4, vmObj.TheFilter, QMS_T001_VM.SuggestedValue, "column_value4", "column_value", false);
                            //    vmObj.ASBValue4.AutoSuggestVM.IsEmptyValueAllowed = true;

                            //    var defvalueCount = from o in vmObj.MC.HeaderValue
                            //                        where o.hdr_id == tempBenchHeader[i].hdr_id && o.def_bit == true
                            //                        select o;
                            //    HeaderValueDefCountTemp = defvalueCount.Count();
                            //}
                            //else if (i == 4)
                            //{
                            //    var items = from o in vmObj.MC.HeaderValue
                            //                where o.hdr_id == tempBenchHeader[i].hdr_id
                            //                select o;
                            //    vmObj.BenchValueList5 = items.ToList();

                            //    QMS_T001_VM.SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_D)x).column_value ?? "");
                            //    vmObj.TheFilter = (o, prefix) => (((QMS_M009_D)o).column_value ?? "").Contains(prefix.ToString().ToLower());
                            //    vmObj.ASBValue5 = new AutoSuggestTextViewModel<dynamic>(vmObj.BenchValueList5, vmObj.TheFilter, QMS_T001_VM.SuggestedValue, "column_value5", "column_value", false);
                            //    vmObj.ASBValue5.AutoSuggestVM.IsEmptyValueAllowed = true;

                            //    var defvalueCount = from o in vmObj.MC.HeaderValue
                            //                        where o.hdr_id == tempBenchHeader[i].hdr_id && o.def_bit == true
                            //                        select o;
                            //    HeaderValueDefCountTemp = defvalueCount.Count();
                            //}
                            //else if (i == 5)
                            //{
                            //    var items = from o in vmObj.MC.HeaderValue
                            //                where o.hdr_id == tempBenchHeader[i].hdr_id
                            //                select o;
                            //    vmObj.BenchValueList6 = items.ToList();

                            //    QMS_T001_VM.SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_D)x).column_value ?? "");
                            //    vmObj.TheFilter = (o, prefix) => (((QMS_M009_D)o).column_value ?? "").ToString().Contains(prefix.ToString().ToLower());
                            //    vmObj.ASBValue6 = new AutoSuggestTextViewModel<dynamic>(vmObj.BenchValueList6, vmObj.TheFilter, QMS_T001_VM.SuggestedValue, "column_value6", "column_value", false);
                            //    vmObj.ASBValue6.AutoSuggestVM.IsEmptyValueAllowed = true;

                            //    var defvalueCount = from o in vmObj.MC.HeaderValue
                            //                        where o.hdr_id == tempBenchHeader[i].hdr_id && o.def_bit == true
                            //                        select o;
                            //    HeaderValueDefCountTemp = defvalueCount.Count();
                            //}
                            //else if (i == 6)
                            //{
                            //    var items = from o in vmObj.MC.HeaderValue
                            //                where o.hdr_id == tempBenchHeader[i].hdr_id
                            //                select o;
                            //    vmObj.BenchValueList7 = items.ToList();

                            //    QMS_T001_VM.SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_D)x).column_value ?? "");
                            //    vmObj.TheFilter = (o, prefix) => (((QMS_M009_D)o).column_value ?? "").Contains(prefix.ToString().ToLower());
                            //    vmObj.ASBValue7 = new AutoSuggestTextViewModel<dynamic>(vmObj.BenchValueList7, vmObj.TheFilter, QMS_T001_VM.SuggestedValue, "column_value7", "column_value", false);
                            //    vmObj.ASBValue7.AutoSuggestVM.IsEmptyValueAllowed = true;

                            //    var defvalueCount = from o in vmObj.MC.HeaderValue
                            //                        where o.hdr_id == tempBenchHeader[i].hdr_id && o.def_bit == true
                            //                        select o;
                            //    HeaderValueDefCountTemp = defvalueCount.Count();
                            //}
                            //else if (i == 7)
                            //{
                            //    var items = from o in vmObj.MC.HeaderValue
                            //                where o.hdr_id == tempBenchHeader[i].hdr_id
                            //                select o;
                            //    vmObj.BenchValueList8 = items.ToList();

                            //    QMS_T001_VM.SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_D)x).column_value ?? "");
                            //    vmObj.TheFilter = (o, prefix) => (((QMS_M009_D)o).column_value ?? "").Contains(prefix.ToString().ToLower());
                            //    vmObj.ASBValue8 = new AutoSuggestTextViewModel<dynamic>(vmObj.BenchValueList8, vmObj.TheFilter, QMS_T001_VM.SuggestedValue, "column_value8", "column_value", false);
                            //    vmObj.ASBValue8.AutoSuggestVM.IsEmptyValueAllowed = true;

                            //    var defvalueCount = from o in vmObj.MC.HeaderValue
                            //                        where o.hdr_id == tempBenchHeader[i].hdr_id && o.def_bit == true
                            //                        select o;
                            //    HeaderValueDefCountTemp = defvalueCount.Count();
                            //}
                            //else if (i == 8)
                            //{
                            //    var items = from o in vmObj.MC.HeaderValue
                            //                where o.hdr_id == tempBenchHeader[i].hdr_id
                            //                select o;
                            //    vmObj.BenchValueList9 = items.ToList();

                            //    QMS_T001_VM.SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_D)x).column_value ?? "");
                            //    vmObj.TheFilter = (o, prefix) => (((QMS_M009_D)o).column_value ?? "").Contains(prefix.ToString().ToLower());
                            //    vmObj.ASBValue9 = new AutoSuggestTextViewModel<dynamic>(vmObj.BenchValueList9, vmObj.TheFilter, QMS_T001_VM.SuggestedValue, "column_value9", "column_value", false);
                            //    vmObj.ASBValue9.AutoSuggestVM.IsEmptyValueAllowed = true;

                            //    var defvalueCount = from o in vmObj.MC.HeaderValue
                            //                        where o.hdr_id == tempBenchHeader[i].hdr_id && o.def_bit == true
                            //                        select o;
                            //    HeaderValueDefCountTemp = defvalueCount.Count();
                            //}
                            //else if (i == 9)
                            //{
                            //    var items = from o in vmObj.MC.HeaderValue
                            //                where o.hdr_id == tempBenchHeader[i].hdr_id
                            //                select o;
                            //    vmObj.BenchValueList10 = items.ToList();

                            //    QMS_T001_VM.SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_D)x).column_value ?? "");
                            //    vmObj.TheFilter = (o, prefix) => (((QMS_M009_D)o).column_value ?? "").Contains(prefix.ToString().ToLower());
                            //    vmObj.ASBValue10 = new AutoSuggestTextViewModel<dynamic>(vmObj.BenchValueList10, vmObj.TheFilter, QMS_T001_VM.SuggestedValue, "column_value10", "column_value", false);
                            //    vmObj.ASBValue10.AutoSuggestVM.IsEmptyValueAllowed = true;

                            //    var defvalueCount = from o in vmObj.MC.HeaderValue
                            //                        where o.hdr_id == tempBenchHeader[i].hdr_id && o.def_bit == true
                            //                        select o;
                            //    HeaderValueDefCountTemp = defvalueCount.Count();
                            //}
                            //else
                            //{
                            //    dgDataSheet.Columns[i].Visibility = Visibility.Collapsed;
                            //}

                            //if (HeaderValueDefCount == 0)
                            //{
                            //    HeaderValueDefCount = HeaderValueDefCountTemp;
                            //}
                            //else if (HeaderValueDefCountTemp < HeaderValueDefCount)
                            //{
                            //    HeaderValueDefCount = HeaderValueDefCountTemp;
                            //}
                        }
                    }
                    #endregion

                    #region For Master Headers
                    //For Master headers...
                    if (vmObj.MC.MasterHeader.Count > 0)
                    {
                        for (int i = 10; i < 30; i++)
                        {
                            dgDataSheet.Columns[i].Header = null;
                            dgDataSheet.Columns[i].Visibility = Visibility.Collapsed;
                        }
                        List<QMS_M009_E> tempMasterHeader = new List<QMS_M009_E>();
                        tempMasterHeader = vmObj.MC.MasterHeader.Where(x => x.test_type_code == TestTypeParameter).ToList();

                        for (int i = 0; i < tempMasterHeader.Count; i++)
                        {
                            dgDataSheet.Columns[i + 10].Header = tempMasterHeader[i].short_name;
                            dgDataSheet.Columns[i + 10].Visibility = 0;
                        }
                    }
                    #endregion

                    #region For unit Headers
                    // For Unit Headers...
                    if (vmObj.MC.UnitHeader.Count > 0)
                    {
                        if (vmObj.MC.MasterHeader.Count == 0)
                        {
                            for (int i = 10; i < 30; i++)
                            {
                                dgDataSheet.Columns[i].Header = null;
                                dgDataSheet.Columns[i].Visibility = Visibility.Collapsed;
                            }
                        }
                        for (int i = 40; i < 60; i++)
                        {
                            dgDataSheet.Columns[i].Header = null;
                            dgDataSheet.Columns[i].Visibility = Visibility.Collapsed;
                        }
                        List<QMS_M009_E> tempUnitHeader = new List<QMS_M009_E>();
                        tempUnitHeader = vmObj.MC.UnitHeader.Where(x => x.test_type_code == TestTypeParameter).ToList();

                        for (int i = 0; i < tempUnitHeader.Count; i++)
                        {
                            dgDataSheet.Columns[i + 40].Header = tempUnitHeader[i].short_name;
                            dgDataSheet.Columns[i + 40].Visibility = 0;
                        }
                    }
                    #endregion

                    #region For Op Headers
                    //For Output Header
                    if (vmObj.MC.TestType.Count > 0)
                    {
                        for (int i = 30; i < 40; i++)
                        {
                            dgDataSheet.Columns[i].Header = null;
                            dgDataSheet.Columns[i].Visibility = Visibility.Collapsed;
                        }
                        for (int i = 60; i < 70; i++)
                        {
                            dgDataSheet.Columns[i].Header = null;
                            dgDataSheet.Columns[i].Visibility = Visibility.Collapsed;
                        }

                        List<QMS_M009_B> tempTestType = new List<QMS_M009_B>();
                        tempTestType = vmObj.MC.TestType.Where(x => x.test_type_code == TestTypeParameter).ToList();

                        for (int i = 0; i < tempTestType.Count; i++)
                        {
                            if (tempTestType[i].op_hdr == "Minimum")
                            {
                                if (vmObj.MC.MasterHeader.Count > 0)
                                {
                                    dgDataSheet.Columns[30].Header = tempTestType[i].op_hdr;
                                    dgDataSheet.Columns[30].Visibility = 0;
                                }
                                if (vmObj.MC.UnitHeader.Count > 0)
                                {
                                    dgDataSheet.Columns[60].Header = tempTestType[i].op_hdr;
                                    dgDataSheet.Columns[60].Visibility = 0;
                                }
                            }
                            else if (tempTestType[i].op_hdr == "Maximum")
                            {
                                if (vmObj.MC.MasterHeader.Count > 0)
                                {
                                    dgDataSheet.Columns[31].Header = tempTestType[i].op_hdr;
                                    dgDataSheet.Columns[31].Visibility = 0;
                                }
                                if (vmObj.MC.UnitHeader.Count > 0)
                                {
                                    dgDataSheet.Columns[61].Header = tempTestType[i].op_hdr;
                                    dgDataSheet.Columns[61].Visibility = 0;
                                }
                            }
                            else if (tempTestType[i].op_hdr == "Average")
                            {
                                if (vmObj.MC.MasterHeader.Count > 0)
                                {
                                    dgDataSheet.Columns[32].Header = tempTestType[i].op_hdr;
                                    dgDataSheet.Columns[32].Visibility = 0;
                                }
                                if (vmObj.MC.UnitHeader.Count > 0)
                                {
                                    dgDataSheet.Columns[62].Header = tempTestType[i].op_hdr;
                                    dgDataSheet.Columns[62].Visibility = 0;
                                }
                            }

                            //dgDataSheet.Columns[i + 33].Header = tempTestType[i].op_hdr;
                            //dgDataSheet.Columns[i + 33].Visibility = 0;

                            //dgDataSheet.Columns[i + 63].Header = tempTestType[i].op_hdr;
                            //dgDataSheet.Columns[i + 63].Visibility = 0;
                        }
                    }
                    #endregion

                    // removable
                    #region Default Values to Datagrid
                    //// For Add default values to datagrid
                    if (vmObj.TestTypeEntity.Where(x => x.test_type_code == TestTypeParameter).FirstOrDefault() == null && vmObj.MCTemp.TestType == null)
                    {
                    //    for (int i = 0; i < HeaderValueDefCount; i++)
                    //    {
                    //        QMS_T001_B DataSheetObject = new QMS_T001_B();
                    //        int HeaderNo = 0;
                    //        if (HeaderNo < vmObj.MC.BenchHeader.Count && vmObj.BenchValueList1 != null && vmObj.BenchValueList1.Count > i)
                    //        {
                    //            DataSheetObject.deletion_id = mn++;
                    //            List<QMS_M009_B> tempTestType = vmObj.MC.TestType.Where(x => x.test_type_code == TestTypeParameter).ToList();
                    //            if (tempTestType.Count > 0)
                    //            {
                    //                DataSheetObject.master_inst = tempTestType[0].master_inst;
                    //                DataSheetObject.master_inst_name = tempTestType[0].master_inst_name;
                    //            }
                    //            DataSheetObject.test_type_code = TestTypeParameter;
                    //            DataSheetObject.value_id1 = vmObj.BenchValueList1[i].value_id;
                    //            DataSheetObject.column_value1 = vmObj.BenchValueList1[i].column_value;
                    //            HeaderNo++;
                    //        }
                    //        if (HeaderNo < vmObj.MC.BenchHeader.Count && vmObj.BenchValueList2 != null && vmObj.BenchValueList2.Count > i)
                    //        {
                    //            DataSheetObject.deletion_id = mn++;
                    //            List<QMS_M009_B> tempTestType = vmObj.MC.TestType.Where(x => x.test_type_code == TestTypeParameter).ToList();
                    //            if (tempTestType.Count > 0)
                    //            {
                    //                DataSheetObject.master_inst = tempTestType[0].master_inst;
                    //                DataSheetObject.master_inst_name = tempTestType[0].master_inst_name;
                    //            }
                    //            DataSheetObject.test_type_code = TestTypeParameter;
                    //            DataSheetObject.value_id2 = vmObj.BenchValueList2[i].value_id;
                    //            DataSheetObject.column_value2 = vmObj.BenchValueList2[i].column_value;
                    //            HeaderNo++;
                    //        }
                    //        if (HeaderNo < vmObj.MC.BenchHeader.Count && vmObj.BenchValueList3 != null && vmObj.BenchValueList3.Count > i)
                    //        {
                    //            DataSheetObject.deletion_id = mn++;
                    //            List<QMS_M009_B> tempTestType = vmObj.MC.TestType.Where(x => x.test_type_code == TestTypeParameter).ToList();
                    //            if (tempTestType.Count > 0)
                    //            {
                    //                DataSheetObject.master_inst = tempTestType[0].master_inst;
                    //                DataSheetObject.master_inst_name = tempTestType[0].master_inst_name;
                    //            }
                    //            DataSheetObject.test_type_code = TestTypeParameter;
                    //            DataSheetObject.value_id3 = vmObj.BenchValueList3[i].value_id;
                    //            DataSheetObject.column_value3 = vmObj.BenchValueList3[i].column_value;
                    //            HeaderNo++;
                    //        }
                    //        if (HeaderNo < vmObj.MC.BenchHeader.Count && vmObj.BenchValueList4 != null && vmObj.BenchValueList4.Count > i)
                    //        {
                    //            DataSheetObject.deletion_id = mn++;
                    //            List<QMS_M009_B> tempTestType = vmObj.MC.TestType.Where(x => x.test_type_code == TestTypeParameter).ToList();
                    //            if (tempTestType.Count > 0)
                    //            {
                    //                DataSheetObject.master_inst = tempTestType[0].master_inst;
                    //                DataSheetObject.master_inst_name = tempTestType[0].master_inst_name;
                    //            }
                    //            DataSheetObject.test_type_code = TestTypeParameter;
                    //            DataSheetObject.value_id4 = vmObj.BenchValueList4[i].value_id;
                    //            DataSheetObject.column_value4 = vmObj.BenchValueList4[i].column_value;
                    //            HeaderNo++;
                    //        }
                    //        if (HeaderNo < vmObj.MC.BenchHeader.Count && vmObj.BenchValueList5 != null && vmObj.BenchValueList5.Count > i)
                    //        {
                    //            DataSheetObject.deletion_id = mn++;
                    //            List<QMS_M009_B> tempTestType = vmObj.MC.TestType.Where(x => x.test_type_code == TestTypeParameter).ToList();
                    //            if (tempTestType.Count > 0)
                    //            {
                    //                DataSheetObject.master_inst = tempTestType[0].master_inst;
                    //                DataSheetObject.master_inst_name = tempTestType[0].master_inst_name;
                    //            }
                    //            DataSheetObject.test_type_code = TestTypeParameter;
                    //            DataSheetObject.value_id5 = vmObj.BenchValueList5[i].value_id;
                    //            DataSheetObject.column_value5 = vmObj.BenchValueList5[i].column_value;
                    //            HeaderNo++;
                    //        }
                    //        if (HeaderNo < vmObj.MC.BenchHeader.Count && vmObj.BenchValueList6 != null && vmObj.BenchValueList6.Count > i)
                    //        {
                    //            DataSheetObject.deletion_id = mn++;
                    //            List<QMS_M009_B> tempTestType = vmObj.MC.TestType.Where(x => x.test_type_code == TestTypeParameter).ToList();
                    //            if (tempTestType.Count > 0)
                    //            {
                    //                DataSheetObject.master_inst = tempTestType[0].master_inst;
                    //                DataSheetObject.master_inst_name = tempTestType[0].master_inst_name;
                    //            }
                    //            DataSheetObject.test_type_code = TestTypeParameter;
                    //            DataSheetObject.value_id6 = vmObj.BenchValueList6[i].value_id;
                    //            DataSheetObject.column_value6 = vmObj.BenchValueList6[i].column_value;
                    //            HeaderNo++;
                    //        }
                    //        if (HeaderNo < vmObj.MC.BenchHeader.Count && vmObj.BenchValueList7 != null && vmObj.BenchValueList7.Count > i)
                    //        {
                    //            DataSheetObject.deletion_id = mn++;
                    //            List<QMS_M009_B> tempTestType = vmObj.MC.TestType.Where(x => x.test_type_code == TestTypeParameter).ToList();
                    //            if (tempTestType.Count > 0)
                    //            {
                    //                DataSheetObject.master_inst = tempTestType[0].master_inst;
                    //                DataSheetObject.master_inst_name = tempTestType[0].master_inst_name;
                    //            }
                    //            DataSheetObject.test_type_code = TestTypeParameter;
                    //            DataSheetObject.value_id7 = vmObj.BenchValueList7[i].value_id;
                    //            DataSheetObject.column_value7 = vmObj.BenchValueList7[i].column_value;
                    //            HeaderNo++;
                    //        }
                    //        if (HeaderNo < vmObj.MC.BenchHeader.Count && vmObj.BenchValueList8 != null && vmObj.BenchValueList8.Count > i)
                    //        {
                    //            DataSheetObject.deletion_id = mn++;
                    //            List<QMS_M009_B> tempTestType = vmObj.MC.TestType.Where(x => x.test_type_code == TestTypeParameter).ToList();
                    //            if (tempTestType.Count > 0)
                    //            {
                    //                DataSheetObject.master_inst = tempTestType[0].master_inst;
                    //                DataSheetObject.master_inst_name = tempTestType[0].master_inst_name;
                    //            }
                    //            DataSheetObject.test_type_code = TestTypeParameter;
                    //            DataSheetObject.value_id8 = vmObj.BenchValueList8[i].value_id;
                    //            DataSheetObject.column_value8 = vmObj.BenchValueList8[i].column_value;
                    //            HeaderNo++;
                    //        }
                    //        if (HeaderNo < vmObj.MC.BenchHeader.Count && vmObj.BenchValueList9 != null && vmObj.BenchValueList9.Count > i)
                    //        {
                    //            DataSheetObject.deletion_id = mn++;
                    //            List<QMS_M009_B> tempTestType = vmObj.MC.TestType.Where(x => x.test_type_code == TestTypeParameter).ToList();
                    //            if (tempTestType.Count > 0)
                    //            {
                    //                DataSheetObject.master_inst = tempTestType[0].master_inst;
                    //                DataSheetObject.master_inst_name = tempTestType[0].master_inst_name;
                    //            }
                    //            DataSheetObject.test_type_code = TestTypeParameter;
                    //            DataSheetObject.value_id9 = vmObj.BenchValueList9[i].value_id;
                    //            DataSheetObject.column_value9 = vmObj.BenchValueList9[i].column_value;
                    //            HeaderNo++;
                    //        }
                    //        if (HeaderNo < vmObj.MC.BenchHeader.Count && vmObj.BenchValueList10 != null && vmObj.BenchValueList10.Count > i)
                    //        {
                    //            DataSheetObject.deletion_id = mn++;
                    //            List<QMS_M009_B> tempTestType = vmObj.MC.TestType.Where(x => x.test_type_code == TestTypeParameter).ToList();
                    //            if (tempTestType.Count > 0)
                    //            {
                    //                DataSheetObject.master_inst = tempTestType[0].master_inst;
                    //                DataSheetObject.master_inst_name = tempTestType[0].master_inst_name;
                    //            }
                    //            DataSheetObject.test_type_code = TestTypeParameter;
                    //            DataSheetObject.value_id10 = vmObj.BenchValueList10[i].value_id;
                    //            DataSheetObject.column_value10 = vmObj.BenchValueList10[i].column_value;
                    //            HeaderNo++;
                    //        }
                    //        vmObj.TestTypeEntity.Add(DataSheetObject);
                    //        if (vmObj.TestTypeEntity != null && vmObj.TestTypeEntity.Count > 0)
                    //        {
                    //            vmObj.TestTypeDataGrid = CollectionViewSource.GetDefaultView(vmObj.TestTypeEntity);
                    //            vmObj.TestTypeDataGrid.Filter = adv => (((QMS_T001_B)adv).test_type_code ?? "").Equals(TestTypeParameter);
                    //            vmObj.TestTypeDataGrid.Refresh();
                    //        }
                    //    }
                    }
                    else if (vmObj.TestTypeEntity.Count > 0)
                    {
                        //if (vmObj.TestTypeEntity.Where(x => x.test_type_code == TestTypeParameter).FirstOrDefault() != null)
                        //{
                        if (vmObj.TestTypeEntity != null && vmObj.TestTypeEntity.Count > 0)
                        {
                            vmObj.TestTypeDataGrid = CollectionViewSource.GetDefaultView(vmObj.TestTypeEntity);
                            vmObj.TestTypeDataGrid.Filter = adv => (((QMS_T001_B)adv).test_type_code ?? "").Equals(TestTypeParameter);
                            vmObj.TestTypeDataGrid.Refresh();
                        }
                        //}
                    }
                    #endregion

                    #region Master Instrument Details
                    //var masterinst = from o in vmObj.MC.TestType where o.test_type_code == TestTypeParameter select o;
                    //if (vmObj.MasterEquipmentEntity != null && masterinst != null && masterinst.ToList().Count > 0)
                    //{
                    //    vmObj.MasterEntity.master_inst_name = masterinst.ToList()[0].master_inst_name;
                    //    QMS_M003_P POPUPEntityObject = new QMS_M003_P();
                    //    POPUPEntityObject = vmObj.MCTemp1.EqCode.Where(x => x.inst_code == masterinst.ToList()[0].master_inst).FirstOrDefault();

                    //    var InputValueIfExists = vmObj.MasterEquipmentEntity.Where(x => x.ItemCode == masterinst.ToList()[0].master_inst).FirstOrDefault();

                    //    if (InputValueIfExists == null && POPUPEntityObject != null)
                    //    {
                    //        vmObj.MasterEquipmentEntity.Add(new QMS_T001_A()
                    //        {
                    //            ItemCode = POPUPEntityObject.inst_code,
                    //            ItemName = POPUPEntityObject.inst_name,
                    //            range = POPUPEntityObject.range,
                    //            resolution = POPUPEntityObject.resolution,
                    //            accuracy = POPUPEntityObject.accuracy,
                    //            due_date = POPUPEntityObject.due_date,
                    //            tr_code = POPUPEntityObject.tr_code,
                    //            tr_name = POPUPEntityObject.tr_name,
                    //            location_Id = AppSessionState.location_Id,
                    //            comp_code = AppSessionState.comp_code,
                    //            add_by = AppSessionState.UserID,
                    //            editby = AppSessionState.UserID,
                    //            active = true,
                    //            t_status = "Draft",
                    //            user_source1 = AppSessionState.UserSource1,
                    //            user_source2 = AppSessionState.UserSource2,
                    //        });
                    //    }
                    //}

                    #endregion
                }
                e.Handled = true;
            }
            catch (Exception ex)
            { }
        }
        
    }
}
