using Reflection.Modules.QMS.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Reflection.BusinessEntity.QMS;
using System.Linq;
using System;
using System.Windows.Data;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI.Core;
using Reflection.Presentation.Controls;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;
using Reflection.Presentation.Services;
using System.Windows.Input;
using Reflection.Presentation.Services.Convertors;

namespace Reflection.Modules.QMS.Views
{
    /// <summary>
    /// Interaction logic for CalibrationView.xaml
    /// </summary>
    public partial class CalibrationView : WindowElement
    {
        QMS_T001_VM vmObj;
        public CalibrationView()
        {
            InitializeComponent();
            vmObj = new QMS_T001_VM();
            this.DataContext = vmObj;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public CalibrationView(string ts_code)
        {
            InitializeComponent();
            vmObj = new QMS_T001_VM(ts_code);
            this.DataContext = vmObj;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public CalibrationView(string ts_code, string doc_no)
        {
            InitializeComponent();
            vmObj = new QMS_T001_VM(ts_code, doc_no);
            this.DataContext = vmObj;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        int mn;
        internal string TestTypeParameter;
        public string decimal_format_code_temp;
        private void Load_button(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btnTestType = (Button)sender;
                TestTypeParameter = btnTestType.CommandParameter.ToString();
                vmObj.TestTypeParameter = TestTypeParameter;
                int HeaderValueDefCountTemp = 0;
                int HeaderValueDefCount = 0;

                if (vmObj.MC.TestType != null && vmObj.MC.TestType.Count > 0)
                {
                    vmObj.decimal_digits = (from o in vmObj.MC.TestType where o.test_type_code == TestTypeParameter select o).FirstOrDefault().decimal_format_code;
                    Settings.decimal_digits = Convert.ToInt16(vmObj.decimal_digits);
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
                        if (vmObj.MasterEntity.test_code == "HVC-Probe" || vmObj.MasterEntity.test_code == "HVC-Divid")
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
                        if (vmObj.MasterEntity.test_code != "HVC-Probe" && vmObj.MasterEntity.test_code != "HVC-Divid")
                        {
                            dgDataSheet.Columns[82].Header = "Expanded Uncertaintity";
                            //dgDataSheet.Columns[82].Visibility = Visibility.Visible;
                            dgDataSheet.Columns[82].IsReadOnly = true;

                            dgDataSheet.Columns[83].Header = "Expanded Uncertainty(In %)";
                            dgDataSheet.Columns[83].Visibility = Visibility.Visible;
                            dgDataSheet.Columns[83].IsReadOnly = true;
                        }
                    }
                    dgDataSheet.Visibility = 0;

                    #region Master Instrument Details
                    var masterinst = from o in vmObj.MC.TestType where o.test_type_code == TestTypeParameter select o;
                    if (vmObj.MasterEquipmentEntity != null && masterinst != null && masterinst.ToList().Count > 0)
                    {
                        vmObj.MasterEntity.master_inst_name = masterinst.ToList()[0].master_inst_name;
                        QMS_M003_P POPUPEntityObject = new QMS_M003_P();
                        POPUPEntityObject = vmObj.MCTemp1.EqCode.Where(x => x.inst_code == masterinst.ToList()[0].master_inst).FirstOrDefault();

                        var InputValueIfExists = vmObj.MasterEquipmentEntity.Where(x => x.ItemCode == masterinst.ToList()[0].master_inst).FirstOrDefault();

                        if (InputValueIfExists == null && POPUPEntityObject != null)
                        {
                            vmObj.MasterEquipmentEntity.Add(new QMS_T001_A()
                            {
                                ItemCode = POPUPEntityObject.inst_code,
                                ItemName = POPUPEntityObject.inst_name,
                                range = POPUPEntityObject.range,
                                //uncertainty = POPUPEntityObject.uncertainty,
                                //uncertainty_unit = POPUPEntityObject.uncertainty_unit,
                                resolution = POPUPEntityObject.resolution,
                                //resolution_unit = POPUPEntityObject.resolution_unit,
                                accuracy_up = POPUPEntityObject.accuracy_up,
                                //accuracy_up_unit = POPUPEntityObject.accuracy_up_unit,
                                due_date = POPUPEntityObject.due_date,
                                tr_code = POPUPEntityObject.tr_code,
                                tr_name = POPUPEntityObject.tr_name,
                                location_Id = AppSessionState.location_Id,
                                comp_code = AppSessionState.comp_code,
                                add_by = AppSessionState.UserID,
                                editby = AppSessionState.UserID,
                                active = true,
                                t_status = "Draft",
                                user_source1 = AppSessionState.UserSource1,
                                user_source2 = AppSessionState.UserSource2,
                            });
                        }
                    }

                    #endregion

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

                            if (i == 0)
                            {
                                var items = from o in vmObj.MC.HeaderValue
                                            where o.hdr_id == tempBenchHeader[i].hdr_id && o.test_type_code == TestTypeParameter
                                            select o;
                                vmObj.BenchValueList1 = items.ToList();

                                QMS_T001_VM.SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_D)x).column_value ?? "");
                                vmObj.TheFilter = (o, prefix) => (((QMS_M009_D)o).column_value ?? "").Contains(prefix.ToString().ToLower());
                                vmObj.ASBValue1 = new AutoSuggestTextViewModel<dynamic>(vmObj.BenchValueList1, vmObj.TheFilter, QMS_T001_VM.SuggestedValue, "column_value1", "column_value", true);
                                vmObj.ASBValue1.AutoSuggestVM.IsEmptyValueAllowed = true;

                                var defvalueCount = from o in vmObj.MC.HeaderValue
                                                    where o.hdr_id == tempBenchHeader[i].hdr_id && o.def_bit == true && o.test_type_code == TestTypeParameter
                                                    select o;
                                HeaderValueDefCountTemp = defvalueCount.Count();
                            }
                            else if (i == 1)
                            {
                                var items = from o in vmObj.MC.HeaderValue
                                            where o.hdr_id == tempBenchHeader[i].hdr_id && o.test_type_code == TestTypeParameter
                                            select o;
                                vmObj.BenchValueList2 = items.ToList();

                                QMS_T001_VM.SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_D)x).column_value ?? "");
                                vmObj.TheFilter = (o, prefix) => (((QMS_M009_D)o).column_value ?? "").Contains(prefix.ToString().ToLower());
                                vmObj.ASBValue2 = new AutoSuggestTextViewModel<dynamic>(vmObj.BenchValueList2, vmObj.TheFilter, QMS_T001_VM.SuggestedValue, "column_value2", "column_value", true);
                                vmObj.ASBValue2.AutoSuggestVM.IsEmptyValueAllowed = true;

                                var defvalueCount = from o in vmObj.MC.HeaderValue
                                                    where o.hdr_id == tempBenchHeader[i].hdr_id && o.def_bit == true && o.test_type_code == TestTypeParameter
                                                    select o;
                                HeaderValueDefCountTemp = defvalueCount.Count();
                            }
                            else if (i == 2)
                            {
                                var items = from o in vmObj.MC.HeaderValue
                                            where o.hdr_id == tempBenchHeader[i].hdr_id && o.test_type_code == TestTypeParameter
                                            select o;
                                vmObj.BenchValueList3 = items.ToList();

                                QMS_T001_VM.SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_D)x).column_value ?? "");
                                vmObj.TheFilter = (o, prefix) => (((QMS_M009_D)o).column_value ?? "").Contains(prefix.ToString().ToLower());
                                vmObj.ASBValue3 = new AutoSuggestTextViewModel<dynamic>(vmObj.BenchValueList3, vmObj.TheFilter, QMS_T001_VM.SuggestedValue, "column_value3", "column_value", true);
                                vmObj.ASBValue3.AutoSuggestVM.IsEmptyValueAllowed = true;

                                var defvalueCount = from o in vmObj.MC.HeaderValue
                                                    where o.hdr_id == tempBenchHeader[i].hdr_id && o.def_bit == true && o.test_type_code == TestTypeParameter
                                                    select o;
                                HeaderValueDefCountTemp = defvalueCount.Count();
                            }
                            else if (i == 3)
                            {
                                var items = from o in vmObj.MC.HeaderValue
                                            where o.hdr_id == tempBenchHeader[i].hdr_id && o.test_type_code == TestTypeParameter
                                            select o;
                                vmObj.BenchValueList4 = items.ToList();

                                QMS_T001_VM.SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_D)x).column_value ?? "");
                                vmObj.TheFilter = (o, prefix) => (((QMS_M009_D)o).column_value ?? "").Contains(prefix.ToString().ToLower());
                                vmObj.ASBValue4 = new AutoSuggestTextViewModel<dynamic>(vmObj.BenchValueList4, vmObj.TheFilter, QMS_T001_VM.SuggestedValue, "column_value4", "column_value", true);
                                vmObj.ASBValue4.AutoSuggestVM.IsEmptyValueAllowed = true;

                                var defvalueCount = from o in vmObj.MC.HeaderValue
                                                    where o.hdr_id == tempBenchHeader[i].hdr_id && o.def_bit == true && o.test_type_code == TestTypeParameter
                                                    select o;
                                HeaderValueDefCountTemp = defvalueCount.Count();
                            }
                            else if (i == 4)
                            {
                                var items = from o in vmObj.MC.HeaderValue
                                            where o.hdr_id == tempBenchHeader[i].hdr_id && o.test_type_code == TestTypeParameter
                                            select o;
                                vmObj.BenchValueList5 = items.ToList();

                                QMS_T001_VM.SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_D)x).column_value ?? "");
                                vmObj.TheFilter = (o, prefix) => (((QMS_M009_D)o).column_value ?? "").Contains(prefix.ToString().ToLower());
                                vmObj.ASBValue5 = new AutoSuggestTextViewModel<dynamic>(vmObj.BenchValueList5, vmObj.TheFilter, QMS_T001_VM.SuggestedValue, "column_value5", "column_value", true);
                                vmObj.ASBValue5.AutoSuggestVM.IsEmptyValueAllowed = true;

                                var defvalueCount = from o in vmObj.MC.HeaderValue
                                                    where o.hdr_id == tempBenchHeader[i].hdr_id && o.def_bit == true && o.test_type_code == TestTypeParameter
                                                    select o;
                                HeaderValueDefCountTemp = defvalueCount.Count();
                            }
                            else if (i == 5)
                            {
                                var items = from o in vmObj.MC.HeaderValue
                                            where o.hdr_id == tempBenchHeader[i].hdr_id && o.test_type_code == TestTypeParameter
                                            select o;
                                vmObj.BenchValueList6 = items.ToList();

                                QMS_T001_VM.SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_D)x).column_value ?? "");
                                vmObj.TheFilter = (o, prefix) => (((QMS_M009_D)o).column_value ?? "").ToString().Contains(prefix.ToString().ToLower());
                                vmObj.ASBValue6 = new AutoSuggestTextViewModel<dynamic>(vmObj.BenchValueList6, vmObj.TheFilter, QMS_T001_VM.SuggestedValue, "column_value6", "column_value", true);
                                vmObj.ASBValue6.AutoSuggestVM.IsEmptyValueAllowed = true;

                                var defvalueCount = from o in vmObj.MC.HeaderValue
                                                    where o.hdr_id == tempBenchHeader[i].hdr_id && o.def_bit == true && o.test_type_code == TestTypeParameter
                                                    select o;
                                HeaderValueDefCountTemp = defvalueCount.Count();
                            }
                            else if (i == 6)
                            {
                                var items = from o in vmObj.MC.HeaderValue
                                            where o.hdr_id == tempBenchHeader[i].hdr_id && o.test_type_code == TestTypeParameter
                                            select o;
                                vmObj.BenchValueList7 = items.ToList();

                                QMS_T001_VM.SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_D)x).column_value ?? "");
                                vmObj.TheFilter = (o, prefix) => (((QMS_M009_D)o).column_value ?? "").Contains(prefix.ToString().ToLower());
                                vmObj.ASBValue7 = new AutoSuggestTextViewModel<dynamic>(vmObj.BenchValueList7, vmObj.TheFilter, QMS_T001_VM.SuggestedValue, "column_value7", "column_value", true);
                                vmObj.ASBValue7.AutoSuggestVM.IsEmptyValueAllowed = true;

                                var defvalueCount = from o in vmObj.MC.HeaderValue
                                                    where o.hdr_id == tempBenchHeader[i].hdr_id && o.def_bit == true && o.test_type_code == TestTypeParameter
                                                    select o;
                                HeaderValueDefCountTemp = defvalueCount.Count();
                            }
                            else if (i == 7)
                            {
                                var items = from o in vmObj.MC.HeaderValue
                                            where o.hdr_id == tempBenchHeader[i].hdr_id && o.test_type_code == TestTypeParameter
                                            select o;
                                vmObj.BenchValueList8 = items.ToList();

                                QMS_T001_VM.SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_D)x).column_value ?? "");
                                vmObj.TheFilter = (o, prefix) => (((QMS_M009_D)o).column_value ?? "").Contains(prefix.ToString().ToLower());
                                vmObj.ASBValue8 = new AutoSuggestTextViewModel<dynamic>(vmObj.BenchValueList8, vmObj.TheFilter, QMS_T001_VM.SuggestedValue, "column_value8", "column_value", true);
                                vmObj.ASBValue8.AutoSuggestVM.IsEmptyValueAllowed = true;

                                var defvalueCount = from o in vmObj.MC.HeaderValue
                                                    where o.hdr_id == tempBenchHeader[i].hdr_id && o.def_bit == true && o.test_type_code == TestTypeParameter
                                                    select o;
                                HeaderValueDefCountTemp = defvalueCount.Count();
                            }
                            else if (i == 8)
                            {
                                var items = from o in vmObj.MC.HeaderValue
                                            where o.hdr_id == tempBenchHeader[i].hdr_id && o.test_type_code == TestTypeParameter
                                            select o;
                                vmObj.BenchValueList9 = items.ToList();

                                QMS_T001_VM.SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_D)x).column_value ?? "");
                                vmObj.TheFilter = (o, prefix) => (((QMS_M009_D)o).column_value ?? "").Contains(prefix.ToString().ToLower());
                                vmObj.ASBValue9 = new AutoSuggestTextViewModel<dynamic>(vmObj.BenchValueList9, vmObj.TheFilter, QMS_T001_VM.SuggestedValue, "column_value9", "column_value", true);
                                vmObj.ASBValue9.AutoSuggestVM.IsEmptyValueAllowed = true;

                                var defvalueCount = from o in vmObj.MC.HeaderValue
                                                    where o.hdr_id == tempBenchHeader[i].hdr_id && o.def_bit == true && o.test_type_code == TestTypeParameter
                                                    select o;
                                HeaderValueDefCountTemp = defvalueCount.Count();
                            }
                            else if (i == 9)
                            {
                                var items = from o in vmObj.MC.HeaderValue
                                            where o.hdr_id == tempBenchHeader[i].hdr_id && o.test_type_code == TestTypeParameter
                                            select o;
                                vmObj.BenchValueList10 = items.ToList();

                                QMS_T001_VM.SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_D)x).column_value ?? "");
                                vmObj.TheFilter = (o, prefix) => (((QMS_M009_D)o).column_value ?? "").Contains(prefix.ToString().ToLower());
                                vmObj.ASBValue10 = new AutoSuggestTextViewModel<dynamic>(vmObj.BenchValueList10, vmObj.TheFilter, QMS_T001_VM.SuggestedValue, "column_value10", "column_value", true);
                                vmObj.ASBValue10.AutoSuggestVM.IsEmptyValueAllowed = true;

                                var defvalueCount = from o in vmObj.MC.HeaderValue
                                                    where o.hdr_id == tempBenchHeader[i].hdr_id && o.def_bit == true && o.test_type_code == TestTypeParameter
                                                    select o;
                                HeaderValueDefCountTemp = defvalueCount.Count();
                            }
                            else
                            {
                                dgDataSheet.Columns[i].Visibility = Visibility.Collapsed;
                            }

                            if (HeaderValueDefCount == 0)
                            {
                                HeaderValueDefCount = HeaderValueDefCountTemp;
                            }
                            else if (HeaderValueDefCountTemp > HeaderValueDefCount)
                            {
                                HeaderValueDefCount = HeaderValueDefCountTemp;
                            }
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

                    #region Default Values to Datagrid
                    // For Add default values to datagrid
                    if (vmObj.TestTypeEntity.Where(x => x.test_type_code == TestTypeParameter).FirstOrDefault() == null && vmObj.MCTemp.TestType == null)
                    {
                        for (int i = 0; i < HeaderValueDefCount; i++)
                        {
                            QMS_T001_B DataSheetObject = new QMS_T001_B();
                            int HeaderNo = 0;
                            if (HeaderNo < vmObj.MC.BenchHeader.Count && vmObj.BenchValueList1 != null && vmObj.BenchValueList1.Count > i)
                            {
                                DataSheetObject.deletion_id = mn++;
                                List<QMS_M009_B> tempTestType = vmObj.MC.TestType.Where(x => x.test_type_code == TestTypeParameter).ToList();
                                if (tempTestType.Count > 0)
                                {
                                    DataSheetObject.master_inst = tempTestType[0].master_inst;
                                    DataSheetObject.master_inst_name = tempTestType[0].master_inst_name;
                                }
                                DataSheetObject.test_type_code = TestTypeParameter;
                                DataSheetObject.value_id1 = vmObj.BenchValueList1[i].value_id;
                                DataSheetObject.column_value1 = vmObj.BenchValueList1[i].column_value;
                                DataSheetObject.unit_code = vmObj.BenchValueList1[i].unit_code;
                                HeaderNo++;
                            }
                            if (HeaderNo < vmObj.MC.BenchHeader.Count && vmObj.BenchValueList2 != null && vmObj.BenchValueList2.Count > i)
                            {
                                DataSheetObject.deletion_id = mn++;
                                List<QMS_M009_B> tempTestType = vmObj.MC.TestType.Where(x => x.test_type_code == TestTypeParameter).ToList();
                                if (tempTestType.Count > 0)
                                {
                                    DataSheetObject.master_inst = tempTestType[0].master_inst;
                                    DataSheetObject.master_inst_name = tempTestType[0].master_inst_name;
                                }
                                DataSheetObject.test_type_code = TestTypeParameter;
                                DataSheetObject.value_id2 = vmObj.BenchValueList2[i].value_id;
                                DataSheetObject.column_value2 = vmObj.BenchValueList2[i].column_value;
                                DataSheetObject.unit_code = vmObj.BenchValueList2[i].unit_code;
                                HeaderNo++;
                            }
                            if (HeaderNo < vmObj.MC.BenchHeader.Count && vmObj.BenchValueList3 != null && vmObj.BenchValueList3.Count > i)
                            {
                                DataSheetObject.deletion_id = mn++;
                                List<QMS_M009_B> tempTestType = vmObj.MC.TestType.Where(x => x.test_type_code == TestTypeParameter).ToList();
                                if (tempTestType.Count > 0)
                                {
                                    DataSheetObject.master_inst = tempTestType[0].master_inst;
                                    DataSheetObject.master_inst_name = tempTestType[0].master_inst_name;
                                }
                                DataSheetObject.test_type_code = TestTypeParameter;
                                DataSheetObject.value_id3 = vmObj.BenchValueList3[i].value_id;
                                DataSheetObject.column_value3 = vmObj.BenchValueList3[i].column_value;
                                DataSheetObject.unit_code = vmObj.BenchValueList3[i].unit_code;
                                HeaderNo++;
                            }
                            if (HeaderNo < vmObj.MC.BenchHeader.Count && vmObj.BenchValueList4 != null && vmObj.BenchValueList4.Count > i)
                            {
                                DataSheetObject.deletion_id = mn++;
                                List<QMS_M009_B> tempTestType = vmObj.MC.TestType.Where(x => x.test_type_code == TestTypeParameter).ToList();
                                if (tempTestType.Count > 0)
                                {
                                    DataSheetObject.master_inst = tempTestType[0].master_inst;
                                    DataSheetObject.master_inst_name = tempTestType[0].master_inst_name;
                                }
                                DataSheetObject.test_type_code = TestTypeParameter;
                                DataSheetObject.value_id4 = vmObj.BenchValueList4[i].value_id;
                                DataSheetObject.column_value4 = vmObj.BenchValueList4[i].column_value;
                                DataSheetObject.unit_code = vmObj.BenchValueList4[i].unit_code;
                                HeaderNo++;
                            }
                            if (HeaderNo < vmObj.MC.BenchHeader.Count && vmObj.BenchValueList5 != null && vmObj.BenchValueList5.Count > i)
                            {
                                DataSheetObject.deletion_id = mn++;
                                List<QMS_M009_B> tempTestType = vmObj.MC.TestType.Where(x => x.test_type_code == TestTypeParameter).ToList();
                                if (tempTestType.Count > 0)
                                {
                                    DataSheetObject.master_inst = tempTestType[0].master_inst;
                                    DataSheetObject.master_inst_name = tempTestType[0].master_inst_name;
                                }
                                DataSheetObject.test_type_code = TestTypeParameter;
                                DataSheetObject.value_id5 = vmObj.BenchValueList5[i].value_id;
                                DataSheetObject.column_value5 = vmObj.BenchValueList5[i].column_value;
                                DataSheetObject.unit_code = vmObj.BenchValueList5[i].unit_code;
                                HeaderNo++;
                            }
                            if (HeaderNo < vmObj.MC.BenchHeader.Count && vmObj.BenchValueList6 != null && vmObj.BenchValueList6.Count > i)
                            {
                                DataSheetObject.deletion_id = mn++;
                                List<QMS_M009_B> tempTestType = vmObj.MC.TestType.Where(x => x.test_type_code == TestTypeParameter).ToList();
                                if (tempTestType.Count > 0)
                                {
                                    DataSheetObject.master_inst = tempTestType[0].master_inst;
                                    DataSheetObject.master_inst_name = tempTestType[0].master_inst_name;
                                }
                                DataSheetObject.test_type_code = TestTypeParameter;
                                DataSheetObject.value_id6 = vmObj.BenchValueList6[i].value_id;
                                DataSheetObject.column_value6 = vmObj.BenchValueList6[i].column_value;
                                DataSheetObject.unit_code = vmObj.BenchValueList6[i].unit_code;
                                HeaderNo++;
                            }
                            if (HeaderNo < vmObj.MC.BenchHeader.Count && vmObj.BenchValueList7 != null && vmObj.BenchValueList7.Count > i)
                            {
                                DataSheetObject.deletion_id = mn++;
                                List<QMS_M009_B> tempTestType = vmObj.MC.TestType.Where(x => x.test_type_code == TestTypeParameter).ToList();
                                if (tempTestType.Count > 0)
                                {
                                    DataSheetObject.master_inst = tempTestType[0].master_inst;
                                    DataSheetObject.master_inst_name = tempTestType[0].master_inst_name;
                                }
                                DataSheetObject.test_type_code = TestTypeParameter;
                                DataSheetObject.value_id7 = vmObj.BenchValueList7[i].value_id;
                                DataSheetObject.column_value7 = vmObj.BenchValueList7[i].column_value;
                                DataSheetObject.unit_code = vmObj.BenchValueList7[i].unit_code;
                                HeaderNo++;
                            }
                            if (HeaderNo < vmObj.MC.BenchHeader.Count && vmObj.BenchValueList8 != null && vmObj.BenchValueList8.Count > i)
                            {
                                DataSheetObject.deletion_id = mn++;
                                List<QMS_M009_B> tempTestType = vmObj.MC.TestType.Where(x => x.test_type_code == TestTypeParameter).ToList();
                                if (tempTestType.Count > 0)
                                {
                                    DataSheetObject.master_inst = tempTestType[0].master_inst;
                                    DataSheetObject.master_inst_name = tempTestType[0].master_inst_name;
                                }
                                DataSheetObject.test_type_code = TestTypeParameter;
                                DataSheetObject.value_id8 = vmObj.BenchValueList8[i].value_id;
                                DataSheetObject.column_value8 = vmObj.BenchValueList8[i].column_value;
                                DataSheetObject.unit_code = vmObj.BenchValueList8[i].unit_code;
                                HeaderNo++;
                            }
                            if (HeaderNo < vmObj.MC.BenchHeader.Count && vmObj.BenchValueList9 != null && vmObj.BenchValueList9.Count > i)
                            {
                                DataSheetObject.deletion_id = mn++;
                                List<QMS_M009_B> tempTestType = vmObj.MC.TestType.Where(x => x.test_type_code == TestTypeParameter).ToList();
                                if (tempTestType.Count > 0)
                                {
                                    DataSheetObject.master_inst = tempTestType[0].master_inst;
                                    DataSheetObject.master_inst_name = tempTestType[0].master_inst_name;
                                }
                                DataSheetObject.test_type_code = TestTypeParameter;
                                DataSheetObject.value_id9 = vmObj.BenchValueList9[i].value_id;
                                DataSheetObject.column_value9 = vmObj.BenchValueList9[i].column_value;
                                DataSheetObject.unit_code = vmObj.BenchValueList9[i].unit_code;
                                HeaderNo++;
                            }
                            if (HeaderNo < vmObj.MC.BenchHeader.Count && vmObj.BenchValueList10 != null && vmObj.BenchValueList10.Count > i)
                            {
                                DataSheetObject.deletion_id = mn++;
                                List<QMS_M009_B> tempTestType = vmObj.MC.TestType.Where(x => x.test_type_code == TestTypeParameter).ToList();
                                if (tempTestType.Count > 0)
                                {
                                    DataSheetObject.master_inst = tempTestType[0].master_inst;
                                    DataSheetObject.master_inst_name = tempTestType[0].master_inst_name;
                                }
                                DataSheetObject.test_type_code = TestTypeParameter;
                                DataSheetObject.value_id10 = vmObj.BenchValueList10[i].value_id;
                                DataSheetObject.column_value10 = vmObj.BenchValueList10[i].column_value;
                                DataSheetObject.unit_code = vmObj.BenchValueList10[i].unit_code;
                                HeaderNo++;
                            }
                            vmObj.TestTypeEntity.Add(DataSheetObject);

                            if (vmObj.TestTypeEntity != null && vmObj.TestTypeEntity.Count > 0)
                            {
                                vmObj.TestTypeDataGrid = CollectionViewSource.GetDefaultView(vmObj.TestTypeEntity);
                                vmObj.TestTypeDataGrid.Filter = adv => (((QMS_T001_B)adv).test_type_code ?? "").Equals(TestTypeParameter);
                                vmObj.TestTypeDataGrid.Refresh();
                            }
                        }
                        MasterValues();
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

                    #region Datasheet for uncertainty budget

                    #region Set Visibility For Unc Datasheet                 
                    if (vmObj.MC.TestType[0].formula_code == "S350" || vmObj.MC.TestType[0].formula_code == "L350")
                    {
                        if (vmObj.MC.TestType[0].test_code == "Sp_S350" || vmObj.MC.TestType[0].test_code == "Sp_L350")
                        {
                            for (int i = 71; i <= 83; i++)
                            {
                                dgDataSheetForUnc.Columns[i].Header = null;
                                dgDataSheetForUnc.Columns[i].Visibility = Visibility.Collapsed;
                                dgDataSheetForUnc.Columns[i].IsReadOnly = false;
                            }

                            dgDataSheetForUnc.Columns[71].Header = "Walze/Can";
                            dgDataSheetForUnc.Columns[71].Visibility = Visibility.Visible;
                            dgDataSheetForUnc.Columns[71].IsReadOnly = true;
                            dgDataSheetForUnc.Columns[72].Header = "Old Factor";
                            dgDataSheetForUnc.Columns[72].Visibility = Visibility.Visible;
                            dgDataSheetForUnc.Columns[73].Header = "New Factor";
                            dgDataSheetForUnc.Columns[73].Visibility = Visibility.Visible;
                            dgDataSheetForUnc.Columns[73].IsReadOnly = true;

                            if (TestTypeParameter == "Test" || TestTypeParameter == "Test Resul")
                            {
                                dgDataSheetForUnc.Columns[75].Header = "Deviation in %";
                                dgDataSheetForUnc.Columns[75].Visibility = Visibility.Visible;
                                dgDataSheetForUnc.Columns[75].IsReadOnly = true;
                            }
                            else
                            {
                                if (TestTypeParameter == "Test at -3")
                                {
                                    dgDataSheetForUnc.Columns[76].Header = "Lateral Angle At -30";
                                    dgDataSheetForUnc.Columns[76].Visibility = Visibility.Visible;
                                    dgDataSheetForUnc.Columns[77].Header = "Walze Speed";
                                    dgDataSheetForUnc.Columns[77].Visibility = Visibility.Visible;
                                    dgDataSheetForUnc.Columns[78].Header = "Can Speed";
                                    dgDataSheetForUnc.Columns[78].Visibility = Visibility.Visible;
                                }
                                else if (TestTypeParameter == "Test at 30")
                                {
                                    dgDataSheetForUnc.Columns[76].Header = "Lateral Angle At 30";
                                    dgDataSheetForUnc.Columns[76].Visibility = Visibility.Visible;
                                    dgDataSheetForUnc.Columns[77].Header = "Walze Speed";
                                    dgDataSheetForUnc.Columns[77].Visibility = Visibility.Visible;
                                    dgDataSheetForUnc.Columns[78].Header = "Can Speed";
                                    dgDataSheetForUnc.Columns[78].Visibility = Visibility.Visible;
                                }
                            }
                        }
                    }
                    else if (vmObj.MC.TestType[0].formula_code == "SD10001")
                    {
                        for (int i = 71; i <= 83; i++)
                        {
                            dgDataSheetForUnc.Columns[i].Header = null;
                            dgDataSheetForUnc.Columns[i].Visibility = Visibility.Collapsed;
                            dgDataSheetForUnc.Columns[i].IsReadOnly = false;
                        }
                        // Value61 --Error
                        //dgDataSheetForUnc.Columns[71].Header = "Variation";
                        //dgDataSheetForUnc.Columns[71].Visibility = Visibility.Visible;
                        //dgDataSheetForUnc.Columns[71].IsReadOnly = true;

                        // Value62 --Error in %
                        //if (vmObj.MasterEntity.test_code == "HVC-Probe" || vmObj.MasterEntity.test_code == "HVC-Divid")
                        //{
                        //    dgDataSheetForUnc.Columns[72].Header = "% in FS";
                        //}
                        //else
                        //{
                        //    dgDataSheetForUnc.Columns[72].Header = "% of Rdg";
                        //}
                        //dgDataSheetForUnc.Columns[72].Visibility = Visibility.Visible;
                        //dgDataSheetForUnc.Columns[72].IsReadOnly = true;

                        dgDataSheetForUnc.Columns[81].Header = "Result";
                        dgDataSheetForUnc.Columns[81].Visibility = Visibility.Visible;
                        dgDataSheetForUnc.Columns[81].IsReadOnly = true;
                        //if (vmObj.MasterEntity.test_code != "HVC-Probe" || vmObj.MasterEntity.test_code != "HVC-Divid")
                        //{
                        //    dgDataSheetForUnc.Columns[82].Header = "Expanded Uncertaintity";
                        //    //dgDataSheetForUnc.Columns[82].Visibility = Visibility.Visible;
                        //    dgDataSheetForUnc.Columns[82].IsReadOnly = true;

                        //    dgDataSheetForUnc.Columns[83].Header = "Expanded Uncertaintity(In %)";
                        //    dgDataSheetForUnc.Columns[83].Visibility = Visibility.Visible;
                        //    dgDataSheetForUnc.Columns[83].IsReadOnly = true;
                        //}
                    }
                    dgDataSheetForUnc.Visibility = 0;
                    #endregion

                    #region Assign Bench Headers to datagrid
                    if (vmObj.MC.BenchHeader.Count > 0)
                    {
                        List<QMS_M009_C> tempBenchHeader = vmObj.MC.BenchHeader.Where(x => x.test_type_code == TestTypeParameter).ToList();

                        for (int i = 0; i < 9; i++)
                        {
                            dgDataSheetForUnc.Columns[i].Header = null;
                            dgDataSheetForUnc.Columns[i].Visibility = Visibility.Collapsed;
                            dgDataSheetForUnc.Columns[i].IsReadOnly = true;
                        }

                        for (int i = 0; i < tempBenchHeader.Count; i++)
                        {
                            dgDataSheetForUnc.Columns[i].Header = tempBenchHeader[i].hdr_name;
                            dgDataSheetForUnc.Columns[i].Visibility = 0;
                        }
                    }

                    #endregion

                    #region For Master Headers
                    //For Master headers...
                    if (vmObj.MC.MasterHeader.Count > 0)
                    {
                        for (int i = 10; i < 30; i++)
                        {
                            dgDataSheetForUnc.Columns[i].Header = null;
                            dgDataSheetForUnc.Columns[i].Visibility = Visibility.Collapsed;
                            dgDataSheetForUnc.Columns[i].IsReadOnly = true;
                        }
                        List<QMS_M009_E> tempMasterHeader = new List<QMS_M009_E>();
                        tempMasterHeader = vmObj.MC.MasterHeader.Where(x => x.test_type_code == TestTypeParameter).ToList();

                        for (int i = 0; i < tempMasterHeader.Count; i++)
                        {
                            dgDataSheetForUnc.Columns[i + 10].Header = tempMasterHeader[i].short_name;
                            dgDataSheetForUnc.Columns[i + 10].Visibility = 0;
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
                                dgDataSheetForUnc.Columns[i].Header = null;
                                dgDataSheetForUnc.Columns[i].Visibility = Visibility.Collapsed;
                            }
                        }
                        for (int i = 40; i < 60; i++)
                        {
                            dgDataSheetForUnc.Columns[i].Header = null;
                            dgDataSheetForUnc.Columns[i].Visibility = Visibility.Collapsed;
                        }
                        List<QMS_M009_E> tempUnitHeader = new List<QMS_M009_E>();
                        tempUnitHeader = vmObj.MC.UnitHeader.Where(x => x.test_type_code == TestTypeParameter).ToList();

                        for (int i = 0; i < tempUnitHeader.Count; i++)
                        {
                            dgDataSheetForUnc.Columns[i + 40].Header = tempUnitHeader[i].short_name;
                            dgDataSheetForUnc.Columns[i + 40].Visibility = 0;
                        }
                    }
                    #endregion

                    #region For Op Headers
                    //For Output Header
                    if (vmObj.MC.TestType.Count > 0)
                    {
                        for (int i = 30; i < 40; i++)
                        {
                            dgDataSheetForUnc.Columns[i].Header = null;
                            dgDataSheetForUnc.Columns[i].Visibility = Visibility.Collapsed;
                        }
                        for (int i = 60; i < 70; i++)
                        {
                            dgDataSheetForUnc.Columns[i].Header = null;
                            dgDataSheetForUnc.Columns[i].Visibility = Visibility.Collapsed;
                        }

                        List<QMS_M009_B> tempTestType = new List<QMS_M009_B>();
                        tempTestType = vmObj.MC.TestType.Where(x => x.test_type_code == TestTypeParameter).ToList();

                        for (int i = 0; i < tempTestType.Count; i++)
                        {
                            if (tempTestType[i].op_hdr == "Minimum")
                            {
                                if (vmObj.MC.MasterHeader.Count > 0)
                                {
                                    dgDataSheetForUnc.Columns[30].Header = tempTestType[i].op_hdr;
                                    dgDataSheetForUnc.Columns[30].Visibility = 0;
                                }
                                if (vmObj.MC.UnitHeader.Count > 0)
                                {
                                    dgDataSheetForUnc.Columns[60].Header = tempTestType[i].op_hdr;
                                    dgDataSheetForUnc.Columns[60].Visibility = 0;
                                }
                            }
                            else if (tempTestType[i].op_hdr == "Maximum")
                            {
                                if (vmObj.MC.MasterHeader.Count > 0)
                                {
                                    dgDataSheetForUnc.Columns[31].Header = tempTestType[i].op_hdr;
                                    dgDataSheetForUnc.Columns[31].Visibility = 0;
                                }
                                if (vmObj.MC.UnitHeader.Count > 0)
                                {
                                    dgDataSheetForUnc.Columns[61].Header = tempTestType[i].op_hdr;
                                    dgDataSheetForUnc.Columns[61].Visibility = 0;
                                }
                            }
                            else if (tempTestType[i].op_hdr == "Average")
                            {
                                if (vmObj.MC.MasterHeader.Count > 0)
                                {
                                    dgDataSheetForUnc.Columns[32].Header = tempTestType[i].op_hdr;
                                    dgDataSheetForUnc.Columns[32].Visibility = 0;
                                }
                                if (vmObj.MC.UnitHeader.Count > 0)
                                {
                                    dgDataSheetForUnc.Columns[62].Header = tempTestType[i].op_hdr;
                                    dgDataSheetForUnc.Columns[62].Visibility = 0;
                                }
                            }

                            //dgDataSheetForUnc.Columns[i + 33].Header = tempTestType[i].op_hdr;
                            //dgDataSheetForUnc.Columns[i + 33].Visibility = 0;

                            //dgDataSheetForUnc.Columns[i + 63].Header = tempTestType[i].op_hdr;
                            //dgDataSheetForUnc.Columns[i + 63].Visibility = 0;
                        }
                    }
                    #endregion

                    #region Filter Default Values to Datagrid

                    if (vmObj.TestTypeEntity.Count > 0)
                    {
                        if (vmObj.TestTypeEntity != null && vmObj.TestTypeEntity.Count > 0)
                        {
                            vmObj.TestTypeDataGrid = CollectionViewSource.GetDefaultView(vmObj.TestTypeEntity);
                            vmObj.TestTypeDataGrid.Filter = adv => (((QMS_T001_B)adv).test_type_code ?? "").Equals(TestTypeParameter);
                            vmObj.TestTypeDataGrid.Refresh();
                        }
                    }

                    #endregion

                    #region Master Instrument Details
                    //var masterinst = from o in vmObj.MC.TestType where o.test_type_code == TestTypeParameter select o;
                    //if (vmObj.MasterEquipmentEntity != null && masterinst1 != null && masterinst.ToList().Count > 0)
                    //{
                    //    vmObj.MasterEntity.master_inst_name = masterinst.ToList()[0].master_inst_name;
                    //}

                    #endregion

                    SelectedValueGrid.Visibility = Visibility.Visible;

                    #endregion //Datasheet for uncertainty budget

                    #region Environment Conditions
                    dgEnvCondition.Visibility = 0;
                    if (vmObj.MC.EnvConditionEntity != null && vmObj.MC.EnvConditionEntity.Count > 0)
                    {
                        foreach (var p in vmObj.MC.EnvConditionEntity)
                        {
                            if (p.test_type_code == TestTypeParameter)
                            {
                                var InputValueIfExists = vmObj.EnvCondEntity.Where(x => x.env_code == p.env_code).FirstOrDefault();
                                if (InputValueIfExists == null)
                                {
                                    vmObj.EnvCondEntity.Add(new QMS_T001_F()
                                    {
                                        test_type_code = p.test_type_code,
                                        env_code = p.env_code,
                                        env_name = p.env_name,
                                        std_value = p.std_value,
                                        upper_value = p.upper_value,
                                        lower_value = p.lower_value,
                                        r_std_value = p.std_value,
                                        std_value_unit = p.std_value_unit,
                                        resolution = p.resolution,
                                        resolution_unit = p.resolution_unit,
                                    });
                                }
                            }
                        }
                    }

                    #endregion

                    #region Filter For Environmental Conditions
                    if (vmObj.EnvCondEntity.Count > 0)
                    {
                        if (vmObj.EnvCondEntity != null && vmObj.EnvCondEntity.Count > 0)
                        {
                            vmObj.EnvCondDataGrid = CollectionViewSource.GetDefaultView(vmObj.EnvCondEntity);
                            vmObj.EnvCondDataGrid.Filter = adv => (((QMS_T001_F)adv).test_type_code ?? "").Equals(TestTypeParameter);
                            vmObj.EnvCondDataGrid.Refresh();
                        }
                    }

                    #endregion

                }
                e.Handled = true;
            }
            catch (Exception ex)
            { }
        }
        private void MasterValues()
        {
            if (TestTypeParameter != null)
            {
                var masterinst = from o in vmObj.MC.TestType where o.test_type_code == TestTypeParameter select o;
                QMS_T001_A POPUPEntityObject = new QMS_T001_A();
                if (vmObj.MasterEquipmentEntity != null && masterinst != null && masterinst.ToList().Count > 0)
                {
                    POPUPEntityObject = vmObj.MasterEquipmentEntity.Where(x => x.ItemCode == masterinst.ToList()[0].master_inst).FirstOrDefault();
                }

                List<QMS_T001_B> tempEntity = new List<QMS_T001_B>();
                tempEntity = (from o in vmObj.TestTypeEntity where o.test_type_code == TestTypeParameter select o).ToList();
                if (tempEntity.Count > vmObj.dgSelectedIndexTestType && vmObj.dgSelectedIndexTestType >= 0)
                {
                    tempEntity = (from o in tempEntity where o.test_type_code == tempEntity[vmObj.dgSelectedIndexTestType].test_type_code && o.deletion_id == tempEntity[vmObj.dgSelectedIndexTestType].deletion_id select o).ToList();
                }
                if (vmObj.MC.MasterValueEntity != null && vmObj.MC.MasterValueEntity.Count > 0 && vmObj.TestTypeEntity != null && vmObj.TestTypeEntity.Count > 0 && vmObj.MC.MasterHeader != null)
                {
                    List<QMS_M009_J> tempMasterValue = new List<QMS_M009_J>();
                    tempMasterValue = vmObj.MC.MasterValueEntity.Where(x => x.test_type_code == TestTypeParameter).ToList();
                    foreach (var q in tempMasterValue)
                    {
                        foreach (var p in tempEntity)
                        {
                            if (Convert.ToInt32(p.value_id1) == q.value_id1 && Convert.ToInt32(p.value_id2) == q.value_id2 && Convert.ToInt32(p.value_id3) == q.value_id3 && Convert.ToInt32(p.value_id4) == q.value_id4 && Convert.ToInt32(p.value_id5) == q.value_id5 &&
                                Convert.ToInt32(p.value_id6) == q.value_id6 && Convert.ToInt32(p.value_id7) == q.value_id7 && Convert.ToInt32(p.value_id8) == q.value_id8 && Convert.ToInt32(p.value_id9) == q.value_id9 && Convert.ToInt32(p.value_id10) == q.value_id10)
                            {
                                if (p.m_uncertainty == null)
                                {
                                    p.m_uncertainty = q.uncertainty;
                                }
                                if (p.m_resolution == null)
                                {
                                    p.m_resolution = q.resolution;
                                }
                                if (p.m_accuracy == null)
                                {
                                    p.m_accuracy = q.accuracy_up;
                                }
                                if (p.coverage_factor == null)
                                {
                                    p.coverage_factor = (from o in vmObj.MC.TestType where o.test_type_code == TestTypeParameter select o.coverage_factor).FirstOrDefault();
                                }
                                if (p.conf_level == null)
                                {
                                    p.conf_level = (from o in vmObj.MC.TestType where o.test_type_code == TestTypeParameter select o.conf_level).FirstOrDefault();
                                }
                                var tempMasterHeader = vmObj.MC.MasterHeader.Where(x => x.test_type_code == TestTypeParameter).ToList();
                                for (int i = 0; i < tempMasterHeader.Count; i++)
                                {
                                    if (Convert.ToInt32(tempMasterHeader[i].header_id) == Convert.ToInt32(q.header_id))
                                    {
                                        if (i == 0 && p.value1 == null)
                                        {
                                            p.value1 = q.header_value;
                                        }
                                        else if (i == 1 && p.value2 == null)
                                        {
                                            p.value2 = q.header_value;
                                        }
                                        else if (i == 2 && p.value3 == null)
                                        {
                                            p.value3 = q.header_value;
                                        }
                                        else if (i == 3 && p.value4 == null)
                                        {
                                            p.value4 = q.header_value;
                                        }
                                        else if (i == 4 && p.value5 == null)
                                        {
                                            p.value5 = q.header_value;
                                        }
                                        else if (i == 5 && p.value6 == null)
                                        {
                                            p.value6 = q.header_value;
                                        }
                                        else if (i == 6 && p.value7 == null)
                                        {
                                            p.value7 = q.header_value;
                                        }
                                        else if (i == 7 && p.value8 == null)
                                        {
                                            p.value8 = q.header_value;
                                        }
                                        else if (i == 8 && p.value9 == null)
                                        {
                                            p.value9 = q.header_value;
                                        }
                                        else if (i == 9 && p.value10 == null)
                                        {
                                            p.value10 = q.header_value;
                                        }
                                        else if (i == 10 && p.value11 == null)
                                        {
                                            p.value11 = q.header_value;
                                        }
                                        else if (i == 11 && p.value12 == null)
                                        {
                                            p.value12 = q.header_value;
                                        }
                                        else if (i == 12 && p.value13 == null)
                                        {
                                            p.value13 = q.header_value;
                                        }
                                        else if (i == 13 && p.value14 == null)
                                        {
                                            p.value14 = q.header_value;
                                        }
                                        else if (i == 14 && p.value15 == null)
                                        {
                                            p.value15 = q.header_value;
                                        }
                                        else if (i == 15 && p.value16 == null)
                                        {
                                            p.value16 = q.header_value;
                                        }
                                        else if (i == 16 && p.value17 == null)
                                        {
                                            p.value17 = q.header_value;
                                        }
                                        else if (i == 17 && p.value18 == null)
                                        {
                                            p.value18 = q.header_value;
                                        }
                                        else if (i == 18 && p.value19 == null)
                                        {
                                            p.value19 = q.header_value;
                                        }
                                        else if (i == 19 && p.value20 == null)
                                        {
                                            p.value20 = q.header_value;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "QMS_T001_VM")
            {
                popup_Emp.IsOpen = false;
                popup_siteEmp.IsOpen = false;
                popup_Rig.IsOpen = false;
                popup_authEmp.IsOpen = false;
                dgEnvCondition.Visibility = Visibility.Collapsed;
                dgDataSheet.Visibility = Visibility.Collapsed;
                dgDataSheetForUnc.Visibility = Visibility.Collapsed;
                SelectedValueGrid.Visibility = Visibility.Collapsed;
            }
            else if (msg.Notification.Equals("MasterValues"))
            {
                MasterValues();
            }
        }
        private bool isManualEditCommit;
        private void HandleMainDataGridCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (!isManualEditCommit)
            {
                isManualEditCommit = true;
                DataGrid grid = (DataGrid)sender;
                int x = grid.Items.Count;
                grid.CommitEdit(DataGridEditingUnit.Row, true);
                isManualEditCommit = false;
            }
        }
        private void mainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source != popup_authEmp)
            {
                popup_Emp.IsOpen = false;
                popup_siteEmp.IsOpen = false;
                popup_Rig.IsOpen = false;
                popup_authEmp.IsOpen = false;
                //var msg = new NotificationMessage("QMS_T001_VM");
                //this.Dispatcher.BeginInvoke((Action)(() =>
                //{
                //    NotificationMessageReceived(msg);
                //}));
                //e.Handled = true;
            }
        }
        
    }
}
