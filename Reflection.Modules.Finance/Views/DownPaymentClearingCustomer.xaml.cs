using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.Finance.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.Finance.Views
{
    /// <summary>
    /// Interaction logic for DownPaymentClearingCustomer.xaml
    /// </summary>
    public partial class DownPaymentClearingCustomer : WindowElement
    {
        private bool isManualEditCommit;
        private string ts_code_local;
        public DownPaymentClearingCustomer(string ts_code)
        {
            this.ts_code_local = ts_code;
            InitializeComponent();
            this.DataContext = new ACC_T001_VM_STD_AC("AR", ts_code);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            //tbcDocDetails.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived2);
        }
        public DownPaymentClearingCustomer(string ts_code, string doc_no)
        {
            this.ts_code_local = ts_code;
            InitializeComponent();
            this.DataContext = new ACC_T001_VM_STD_AC("AR", ts_code, doc_no);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            //tbcDocDetails.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived2);
        }


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
            if (msg.Notification == ts_code_local)
            {
                popStatus.IsOpen = false;
                popup_DocType.IsOpen = false;
                _popupCompany.IsOpen = false;
                _popupCurrency.IsOpen = false;
                _popup_Party.IsOpen = false;
                _popupCurrency.IsOpen = false;
                popupFltrStatus.IsOpen = false;
                _popupSeller1.IsOpen = false;
                popupFilterParty.IsOpen = false;
                _popupLocationFilter.IsOpen = false;
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                var msg = new NotificationMessage(ts_code_local);
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }

        private void mainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source != popFilterSearch)
            {
                var msg = new NotificationMessage(ts_code_local);
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        private void NotificationMessageReceived2(NotificationMessage msg)
        {
            if (msg.Notification == "Enable/Disable Special GL Code")
            {

            }
        }
        
    }
}
