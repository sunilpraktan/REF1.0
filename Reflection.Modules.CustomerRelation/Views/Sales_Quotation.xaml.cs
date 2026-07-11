using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.CustomerRelation.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Reflection.Modules.CustomerRelation.Views
{
    /// <summary>
    /// Description for Sales_Quotation.
    /// </summary>
    public partial class Sales_Quotation : WindowElement
    {
        public string ts_code_vm { get; set; }
        /// <summary>
        /// Initializes a new instance of the SalesOrderMaster class.
        /// </summary>
        public Sales_Quotation(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new SEL_T001_Quot_VM("QN", ts_code);
            this.ts_code_vm = ts_code;
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public Sales_Quotation(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new SEL_T001_Quot_VM("QN", ts_code, doc_no);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == ts_code_vm)
            {
                _popup_status.IsOpen = false;
                popFilterSearch.IsOpen = false;
                popup_SoldToParty.IsOpen = false;
                 popup_ShipToParty.IsOpen = false;
                 popup_RefDocNo.IsOpen = false;
                 popup_Buyer.IsOpen = false;
                _popupSeller.IsOpen = false;
                _popupCurrency.IsOpen = false;
                _popupIncoterm.IsOpen = false;
                _popupPayTerms.IsOpen = false;
                _popupRefParty.IsOpen = false;
                _popupRefContPerson.IsOpen = false;
                _popupOurBank.IsOpen = false;
                _popupNastroBank.IsOpen = false;
                //_popupPlant1.IsOpen = false;
                //_popupSeller1.IsOpen = false;
                _popupDeliveryAdddress.IsOpen = false;
                _popupBillAdddress.IsOpen = false;                
                _popupSalesOrg.IsOpen = false;
                _popupSalesGroup.IsOpen = false;
                _popupComp.IsOpen = false;
                _popupPlant.IsOpen = false;
            }
        }
        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
               
                ///popup_SoldToParty.UnselectAll();             
                dgPopupBillAdddress.UnselectAll();            
                //dgPopupRefDocNo.UnselectAll();
               // dgShipToParty.UnselectAll();
               
            }
            catch (Exception ex)
            { }
            e.Handled = true;
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
        private void PopPara_Unloaded(object sender, RoutedEventArgs e)
        {

        }
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                var msg = new NotificationMessage("SEL_T001_Quot_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        private void mainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source != _popupCurrency)
            {
                var msg = new NotificationMessage("SEL_T001_Quot_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        
    }
}