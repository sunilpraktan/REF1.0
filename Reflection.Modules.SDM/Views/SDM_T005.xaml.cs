using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;
using Reflection.Modules.SDM.ViewModels;
using Reflection.Presentation.Services;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.SDM.Views
{
    /// <summary>
    /// Interaction logic for SDM_T001.xaml
    /// </summary>
    public partial class SDM_T005 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public string dgKey { get; set; } = null;
        public SDM_T005(string ts_code)
        {
            this.ts_code_vm = ts_code;
            InitializeComponent();
            this.DataContext = new SDM_T005_VM(ts_code,"SO", "SO");
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public SDM_T005(string ts_code, string doc_no)
        {
            this.ts_code_vm = ts_code;
            InitializeComponent();
            this.DataContext = new SDM_T005_VM(ts_code,"SO","SO",doc_no);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public SDM_T005(string ts_code, STD_LIST_BE STD_OBJECT)
        {
            this.ts_code_vm = ts_code;
            InitializeComponent();
            this.DataContext = new SDM_T005_VM(ts_code, STD_OBJECT);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }


        private bool isManualEditCommit;

        //This will update the bound object whenever a cell edit is ending, i.e.whenever the cell looses focus.
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

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == ts_code_vm)
            {
                ppRefDoc.IsOpen = false;
                popFilterSearch.IsOpen = false;
                popup_SOtype.IsOpen = false;
                popup_NotifyParty.IsOpen = false;
                popup_NotifyParty2.IsOpen = false;
                popTradeIndicator.IsOpen = false;
                popup_Buyer.IsOpen = false;
                _popupSeller.IsOpen = false;
                _popupTransporter.IsOpen = false;
                _popupBillAdddress.IsOpen = false;
                _popupDeliveryAdddress.IsOpen = false;
                _popupSeller.IsOpen = false;
                _popupCurrency.IsOpen = false;
                _popupIncoterm.IsOpen = false;
                _popupPayTerms.IsOpen = false;
                _popupRefParty.IsOpen = false;
                _popupRefContPerson.IsOpen = false;
                _popupSalesOrg.IsOpen = false;
                _popupSalesGroup.IsOpen = false;
                _popupPlant1.IsOpen = false;
                _popupSeller1.IsOpen = false;
                _popup_SoldToParty.IsOpen = false;
                popup_ShipToParty.IsOpen = false;
                _popup_status.IsOpen = false;
                popupDocType.IsOpen = false;
                popupFltrStatus.IsOpen = false;
                //popupFilterParty.IsOpen = false;
                _popuptr_mode.IsOpen = false;
                popFilterSearch.IsOpen = false;
                //ppPlant.IsOpen = false;
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                var msg = new NotificationMessage(ts_code_vm);
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }

        private void mainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source != _popup_SoldToParty)
            {
                var msg = new NotificationMessage(ts_code_vm);
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }

        private void btnTPOPUP_Click(object sender, RoutedEventArgs e)
        {
            //ppItemInfo.IsOpen = true;
        }

        // Working Properly on Got focus, just on Enter it shift to right instead of down cell. also need movement on arrow key. Also need DataGrid name which is not good for generic function fo rall screens.
        private void HandleDataGridGotFocus(object sender, RoutedEventArgs e)
        {
            DataGrid grid = (DataGrid)sender;
            try
            {
                if (e.OriginalSource is DataGridCell cell && !cell.IsEditing && dgKey == null)
                {
                    grid.BeginEdit(e);
                    if (grid.CurrentCell != null && (grid.CurrentCell.Column is DataGridBoundColumn || grid.CurrentCell.Column is DataGridTemplateColumn))
                    {
                        grid.BeginEdit(e);
                        Dispatcher.BeginInvoke(new Action(() =>
                        {
                            TextBox textBox = UIServices.FindVisualChild<TextBox>(cell);
                            if (textBox != null && textBox.IsVisible)
                            {
                                textBox.Focus();
                                textBox.ForceCursor = true;
                                textBox.CaretIndex = textBox.Text.Length;
                                textBox.SelectAll();
                            }
                        }), System.Windows.Threading.DispatcherPriority.Background);
                    }
                }
                dgKey = null; // Set to null once finish.
            }
            catch (Exception ex) { dgKey = null; }
        }
        private void DataGrid_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            // Get the DataGridCell that is currently focused.
            //DataGridCell cell = GetCurrentCell(dataGrid);
            DataGrid grid = (DataGrid)sender;
            if (grid.CurrentCell != null)
            {
                // Check which key was pressed.
                if (e.Key == Key.Enter)
                {
                    dgKey = "Enter";
                }
                else
                {
                    dgKey = null;
                }
            }
        }
    }
}
