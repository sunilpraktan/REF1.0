using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.Procurement.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows.Controls;

namespace Reflection.Modules.Procurement.Views
{
    /// <summary>
    /// Interaction logic for PurchaseReturnOrder.xaml
    /// </summary>
    public partial class PurchaseReturnOrder : WindowElement
    {
        public PurchaseReturnOrder(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new PUR_T002_PurchaseReturn_VM(ts_code);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public PurchaseReturnOrder(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new PUR_T002_PurchaseReturn_VM(ts_code, doc_no);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "PUR_T002_PurchaseReturn_VM")
            {
                popup_Supplier.IsOpen = false;
                popup_Buyer.IsOpen = false;
                _popupOrderType.IsOpen = false;
                popup_ValidatedBy.IsOpen = false;
                popup_ContactPerson.IsOpen = false;
                popupDelAddress.IsOpen = false;
                popupBillAddress.IsOpen = false;
                popupCurrency.IsOpen = false;
                popupPaymentterm.IsOpen = false;
                // popupTax.IsOpen = false;
                popup_PurOrg.IsOpen = false;
                popup_PurGrp.IsOpen = false;
                popup_DestWar.IsOpen = false;
                popup_StorLoc.IsOpen = false;
                _popupIncoterm.IsOpen = false;
                _popupEPCG.IsOpen = false;
                _popupAdvance.IsOpen = false;
                popup_CostCentre.IsOpen = false;
                popup_Journal.IsOpen = false;
            }
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
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                var msg = new NotificationMessage("PUR_T002_PurchaseReturn_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        
    }
}
