using System;
using System.Windows;
using Reflection.Presentation.Windows.Controls;
using Reflection.Modules.CustomerRelation.ViewModels;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Input;

namespace Reflection.Modules.CustomerRelation.Views
{
    /// <summary>
    /// Interaction logic for PurchaseOrder.xaml
    /// </summary>
    public partial class PurchaseOrder : WindowElement
    {
        public string ts_code_vm { get; set; }
        public PurchaseOrder(string ts_code)
        {
            this.ts_code_vm = ts_code;
            InitializeComponent();
            this.DataContext = new PUR_T002_VM("PO", ts_code);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public PurchaseOrder(string ts_code, string doc_no)
        {
            this.ts_code_vm = ts_code;
            InitializeComponent();
            this.DataContext = new PUR_T002_VM("PO", ts_code, doc_no);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgbuyer.UnselectAll();
                //dgPopupParty.UnselectAll();
                //dgPopupQuotation.UnselectAll();
                //dgvalidator.UnselectAll();
                //dgDeliveryAddress.UnselectAll();
                //dgInvoiceAddress.UnselectAll();
                //dgPopupCurrency.UnselectAll();
                //dgPaymentTerm.UnselectAll();
                //dgsaleorgnisation.UnselectAll();
                //dgPurchaseGroup.UnselectAll();
                //dgStorageLocation.UnselectAll();
                //dgcostcentre.UnselectAll();
                //dgjournal.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }



        private void btnSrNo_Unloaded(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }

        private void PopPara_Unloaded(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }

        private void dgParameters_Unloaded(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == ts_code_vm)
            {
                popTradeIndicator.IsOpen = false;
                PopRQDetail.IsOpen = false;
                popup_Supplier.IsOpen = false;
                popup_Buyer.IsOpen = false;
                _popupOrderType.IsOpen = false;
                popup_ValidatedBy.IsOpen = false;
                popup_ContactPerson.IsOpen = false;
                popupDelAddress.IsOpen = false;
                popupBillAddress.IsOpen = false;
                popupCurrency.IsOpen = false;
                popupPaymentterm.IsOpen = false;
                popup_PurOrg.IsOpen = false;
                popup_PurGrp.IsOpen = false;
                popup_DestWar.IsOpen = false;
                popup_StorLoc.IsOpen = false;
                _popupIncoterm.IsOpen = false;
                popup_CostCentre.IsOpen = false;
                popup_BussPlace.IsOpen = false;
                _popup_status.IsOpen = false;
                popFilterSearch.IsOpen = false;
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
                var msg = new NotificationMessage("PUR_T002_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        private void mainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source != popup_Supplier)
            {
                var msg = new NotificationMessage("PUR_T002_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        
    }
}
