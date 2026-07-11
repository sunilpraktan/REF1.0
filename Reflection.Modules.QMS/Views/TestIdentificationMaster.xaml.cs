using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.QMS.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System.Windows.Controls;
using System.Windows;
using System.Linq;
using Reflection.BusinessEntity.QMS;
using System.Collections.Generic;
using System;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI.Core;
using Reflection.Presentation.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Reflection.Presentation.Services.Convertors;

namespace Reflection.Modules.QMS.Views
{
    /// <summary>
    /// Interaction logic for TestIdentificationMaster.xaml
    /// </summary>
    public partial class TestIdentificationMaster : WindowElement
    {
        //QMS_M009_VM vmObj = new QMS_M009_VM();
        QMS_M009_VM vmObj;
        public TestIdentificationMaster(string ts_code)
        {
            InitializeComponent();
            vmObj = new QMS_M009_VM(ts_code);
            this.DataContext = vmObj;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            dgEnvCond.Visibility = Visibility.Collapsed;
            dgStdRdg.Visibility = Visibility.Collapsed;
        }
        public TestIdentificationMaster(string ts_code, string doc_no)
        {
            InitializeComponent();
            vmObj = new QMS_M009_VM(ts_code, doc_no);
            this.DataContext = vmObj;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            dgEnvCond.Visibility = Visibility.Collapsed;
            dgStdRdg.Visibility = Visibility.Collapsed;
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "QMS_M009_VM")
            {
                popup_TP.IsOpen = false;
                popup_WI.IsOpen = false;
                popup_SubCat.IsOpen = false;
                popup_cat.IsOpen = false;
                popup_Serv.IsOpen = false;
                dgStdRdg.Visibility = Visibility.Collapsed;
                dgEnvCond.Visibility = Visibility.Collapsed;
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

        private void Load_button(object sender, RoutedEventArgs e)
        {
            try
            {
                dgEnvCond.Visibility = Visibility.Collapsed;
                dgStdRdg.Visibility = Visibility.Collapsed;
                for (int i = 1; i <= 10; i++)
                {
                    dgStdRdg.Columns[i].Header = null;
                    dgStdRdg.Columns[i].Visibility = Visibility.Collapsed;
                }
                int k = 1;
                string TestTypeParameter;
                Button btnTestType = (Button)sender;
                TestTypeParameter = btnTestType.CommandParameter.ToString();
                vmObj.TestTypeParameter = TestTypeParameter;

                List<QMS_M009_C> tempTestHeader = (from o in vmObj.TestHeaderEntity
                                                   where o.test_type_code == TestTypeParameter && o.hdr_id != 0
                                                   select o).ToList();
                for (int i = 0; i < tempTestHeader.Count; i++)
                {
                    dgStdRdg.Columns[k].Header = tempTestHeader[i].hdr_name;
                    dgStdRdg.Columns[k].Visibility = Visibility.Visible;
                    k++;
                    if (i == 0)
                    {
                        var items = from o in vmObj.HeaderValueEntity
                                    where o.hdr_id == tempTestHeader[i].hdr_id
                                    select o;
                        vmObj.BenchValueList1 = items.ToList();

                        QMS_M009_VM.SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_D)x).column_value ?? "");
                        vmObj.TheFilter = (o, prefix) => (((QMS_M009_D)o).column_value ?? "").Contains(prefix.ToString().ToLower());
                        vmObj.ASBValue1 = new AutoSuggestTextViewModel<dynamic>(vmObj.BenchValueList1, vmObj.TheFilter, QMS_M009_VM.SuggestedValue, "column_value1", "column_value", true);
                        vmObj.ASBValue1.AutoSuggestVM.IsEmptyValueAllowed = true;
                    }
                    else if (i == 1)
                    {
                        var items = from o in vmObj.HeaderValueEntity
                                    where o.hdr_id == tempTestHeader[i].hdr_id
                                    select o;
                        vmObj.BenchValueList2 = items.ToList();

                        QMS_M009_VM.SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_D)x).column_value ?? "");
                        vmObj.TheFilter = (o, prefix) => (((QMS_M009_D)o).column_value ?? "").Contains(prefix.ToString().ToLower());
                        vmObj.ASBValue2 = new AutoSuggestTextViewModel<dynamic>(vmObj.BenchValueList2, vmObj.TheFilter, QMS_M009_VM.SuggestedValue, "column_value2", "column_value", true);
                        vmObj.ASBValue2.AutoSuggestVM.IsEmptyValueAllowed = true;
                    }
                    else if (i == 2)
                    {
                        var items = from o in vmObj.HeaderValueEntity
                                    where o.hdr_id == tempTestHeader[i].hdr_id
                                    select o;
                        vmObj.BenchValueList3 = items.ToList();

                        QMS_M009_VM.SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_D)x).column_value ?? "");
                        vmObj.TheFilter = (o, prefix) => (((QMS_M009_D)o).column_value ?? "").Contains(prefix.ToString().ToLower());
                        vmObj.ASBValue3 = new AutoSuggestTextViewModel<dynamic>(vmObj.BenchValueList3, vmObj.TheFilter, QMS_M009_VM.SuggestedValue, "column_value3", "column_value", true);
                        vmObj.ASBValue3.AutoSuggestVM.IsEmptyValueAllowed = true;
                    }
                    else if (i == 3)
                    {
                        var items = from o in vmObj.MC.HeaderValueEntity
                                    where o.hdr_id == tempTestHeader[i].hdr_id
                                    select o;
                        vmObj.BenchValueList4 = items.ToList();

                        QMS_M009_VM.SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_D)x).column_value ?? "");
                        vmObj.TheFilter = (o, prefix) => (((QMS_M009_D)o).column_value ?? "").Contains(prefix.ToString().ToLower());
                        vmObj.ASBValue4 = new AutoSuggestTextViewModel<dynamic>(vmObj.BenchValueList4, vmObj.TheFilter, QMS_M009_VM.SuggestedValue, "column_value4", "column_value", true);
                        vmObj.ASBValue4.AutoSuggestVM.IsEmptyValueAllowed = true;
                    }
                    else if (i == 4)
                    {
                        var items = from o in vmObj.MC.HeaderValueEntity
                                    where o.hdr_id == tempTestHeader[i].hdr_id
                                    select o;
                        vmObj.BenchValueList5 = items.ToList();

                        QMS_M009_VM.SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_D)x).column_value ?? "");
                        vmObj.TheFilter = (o, prefix) => (((QMS_M009_D)o).column_value ?? "").Contains(prefix.ToString().ToLower());
                        vmObj.ASBValue5 = new AutoSuggestTextViewModel<dynamic>(vmObj.BenchValueList5, vmObj.TheFilter, QMS_M009_VM.SuggestedValue, "column_value5", "column_value", true);
                        vmObj.ASBValue5.AutoSuggestVM.IsEmptyValueAllowed = true;
                    }
                    else if (i == 5)
                    {
                        var items = from o in vmObj.MC.HeaderValueEntity
                                    where o.hdr_id == tempTestHeader[i].hdr_id
                                    select o;
                        vmObj.BenchValueList6 = items.ToList();

                        QMS_M009_VM.SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_D)x).column_value ?? "");
                        vmObj.TheFilter = (o, prefix) => (((QMS_M009_D)o).column_value ?? "").ToString().Contains(prefix.ToString().ToLower());
                        vmObj.ASBValue6 = new AutoSuggestTextViewModel<dynamic>(vmObj.BenchValueList6, vmObj.TheFilter, QMS_M009_VM.SuggestedValue, "column_value6", "column_value", true);
                        vmObj.ASBValue6.AutoSuggestVM.IsEmptyValueAllowed = true;
                    }
                    else if (i == 6)
                    {
                        var items = from o in vmObj.MC.HeaderValueEntity
                                    where o.hdr_id == tempTestHeader[i].hdr_id
                                    select o;
                        vmObj.BenchValueList7 = items.ToList();

                        QMS_M009_VM.SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_D)x).column_value ?? "");
                        vmObj.TheFilter = (o, prefix) => (((QMS_M009_D)o).column_value ?? "").ToString().Contains(prefix.ToString().ToLower());
                        vmObj.ASBValue7 = new AutoSuggestTextViewModel<dynamic>(vmObj.BenchValueList7, vmObj.TheFilter, QMS_M009_VM.SuggestedValue, "column_value7", "column_value", true);
                        vmObj.ASBValue7.AutoSuggestVM.IsEmptyValueAllowed = true;
                    }
                    else if (i == 7)
                    {
                        var items = from o in vmObj.MC.HeaderValueEntity
                                    where o.hdr_id == tempTestHeader[i].hdr_id
                                    select o;
                        vmObj.BenchValueList8 = items.ToList();

                        QMS_M009_VM.SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_D)x).column_value ?? "");
                        vmObj.TheFilter = (o, prefix) => (((QMS_M009_D)o).column_value ?? "").ToString().Contains(prefix.ToString().ToLower());
                        vmObj.ASBValue8 = new AutoSuggestTextViewModel<dynamic>(vmObj.BenchValueList8, vmObj.TheFilter, QMS_M009_VM.SuggestedValue, "column_value8", "column_value", true);
                        vmObj.ASBValue8.AutoSuggestVM.IsEmptyValueAllowed = true;
                    }
                    else if (i == 8)
                    {
                        var items = from o in vmObj.MC.HeaderValueEntity
                                    where o.hdr_id == tempTestHeader[i].hdr_id
                                    select o;
                        vmObj.BenchValueList9 = items.ToList();

                        QMS_M009_VM.SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_D)x).column_value ?? "");
                        vmObj.TheFilter = (o, prefix) => (((QMS_M009_D)o).column_value ?? "").ToString().Contains(prefix.ToString().ToLower());
                        vmObj.ASBValue9 = new AutoSuggestTextViewModel<dynamic>(vmObj.BenchValueList9, vmObj.TheFilter, QMS_M009_VM.SuggestedValue, "column_value9", "column_value", true);
                        vmObj.ASBValue9.AutoSuggestVM.IsEmptyValueAllowed = true;
                    }
                    else if (i == 9)
                    {
                        var items = from o in vmObj.MC.HeaderValueEntity
                                    where o.hdr_id == tempTestHeader[i].hdr_id
                                    select o;
                        vmObj.BenchValueList10 = items.ToList();

                        QMS_M009_VM.SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_D)x).column_value ?? "");
                        vmObj.TheFilter = (o, prefix) => (((QMS_M009_D)o).column_value ?? "").ToString().Contains(prefix.ToString().ToLower());
                        vmObj.ASBValue10 = new AutoSuggestTextViewModel<dynamic>(vmObj.BenchValueList10, vmObj.TheFilter, QMS_M009_VM.SuggestedValue, "column_value10", "column_value", true);
                        vmObj.ASBValue10.AutoSuggestVM.IsEmptyValueAllowed = true;
                    }
                }
                if (vmObj.MasterValueEntity != null && vmObj.MasterValueEntity.Count > 0)
                {
                    vmObj.MasterValueDataGrid = CollectionViewSource.GetDefaultView(vmObj.MasterValueEntity);
                    vmObj.MasterValueDataGrid.Filter = adv => (((QMS_M009_J)adv).test_type_code ?? "").Equals(TestTypeParameter);
                    vmObj.MasterValueDataGrid.Refresh();
                }
                QMS_M009_VM.SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_E)x).rdg_header ?? "");
                vmObj.TheFilter = (o, prefix) => (((QMS_M009_E)o).rdg_header ?? "").ToLower().Contains(prefix.ToString().ToLower());
                vmObj.ASMasterHeader = new AutoSuggestTextViewModel<dynamic>((from o in vmObj.MasterHeaderEntity where o.test_type_code == TestTypeParameter select o), vmObj.TheFilter, QMS_M009_VM.SuggestedValue, "header_name", "rdg_header", true);
                vmObj.ASMasterHeader.AutoSuggestVM.IsEmptyValueAllowed = true;

                if (vmObj.EnvConditionEntity != null && vmObj.EnvConditionEntity.Count > 0)
                {
                    vmObj.EnvCondDataGrid = CollectionViewSource.GetDefaultView(vmObj.EnvConditionEntity);
                    vmObj.EnvCondDataGrid.Filter = adv => (((QMS_M009_K)adv).test_type_code ?? "").Equals(TestTypeParameter);
                    vmObj.EnvCondDataGrid.Refresh();
                }

                dgEnvCond.Visibility = Visibility.Visible;
                dgStdRdg.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            { }
        }
        private void mainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source != popup_ItemType)
            {
                var msg = new NotificationMessage("QMS_M009_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        
    }
}
