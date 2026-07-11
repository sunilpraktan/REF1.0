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
    /// Description for SalesOrderMaster.
    /// </summary>
    public partial class SalesOrderMaster : WindowElement
    {
        public string ts_code_vm { get; set; }
        /// <summary>
        /// Initializes a new instance of the SalesOrderMaster class.
        /// </summary>
        public SalesOrderMaster(string ts_code)
        {
            this.ts_code_vm = ts_code;
            InitializeComponent();
            this.DataContext = new SEL_T001_VM("SO",ts_code);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public SalesOrderMaster(string ts_code, string doc_no)
        {
            this.ts_code_vm = ts_code;
            InitializeComponent();
            this.DataContext = new SEL_T001_VM("SO", ts_code, doc_no);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
        private void PopPara_Unloaded(object sender, RoutedEventArgs e)
        {

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
                //popup_Ref_doc_no.IsOpen = false;
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
                _popupOurBank.IsOpen = false;
                _popupNastroBank.IsOpen = false;
                _popupSalesOrg.IsOpen = false;
                _popupSalesGroup.IsOpen = false;
                _popupPlant1.IsOpen = false;
                _popupSeller1.IsOpen = false;
                _popup_SoldToParty.IsOpen = false;
                popup_ShipToParty.IsOpen = false;
                popup_BussPlace.IsOpen = false;
                _popup_status.IsOpen = false;
                popupDocType.IsOpen = false;
                popupFltrStatus.IsOpen = false;
                popupFilterParty.IsOpen = false;
                _popuptr_mode.IsOpen = false;
                popFilterSearch.IsOpen = false;
                _popupComp.IsOpen = false;
                _popupPlant.IsOpen = false;
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                var msg = new NotificationMessage("SEL_T001_VM");
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
                var msg = new NotificationMessage("SEL_T001_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }

        private void tbcMaster_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txttransporter_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        
    }
}