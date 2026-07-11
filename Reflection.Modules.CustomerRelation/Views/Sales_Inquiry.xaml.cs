using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.CustomerRelation.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.CustomerRelation.Views
{
    /// <summary>
    /// Description for SalesInquiry
    /// </summary>
    public partial class Sales_Inquiry : WindowElement
    {
        public string ts_code_vm { get; set; }
        /// <summary>
        /// Initializes a new instance of the SalesInquiry class.
        /// </summary>
        public Sales_Inquiry(string ts_code)
        {
            InitializeComponent();
            this.ts_code_vm = ts_code;
            this.DataContext = new SEL_T001_INQ_VM("SN",ts_code);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public Sales_Inquiry(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new SEL_T001_INQ_VM("SN",ts_code, doc_no);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == ts_code_vm)
            {
                popFilterSearch.IsOpen = false;
                _popupCountry.IsOpen = false;
                _popupBuyer.IsOpen = false;
                popup_Party.IsOpen = false;
                _popupState.IsOpen = false;
                _popupLocation.IsOpen = false;
                _popupRefContPerson.IsOpen = false;                
                _popupRefParty.IsOpen = false;
                popupSeller.IsOpen = false;
                popupCurrency.IsOpen = false;                
                _popupSalesOrg.IsOpen = false;
                _popupSalesGroup.IsOpen = false;
                _popup_status.IsOpen = false;
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
                var msg = new NotificationMessage("SEL_T001_INQ_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        private void mainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source != popupCurrency)
            {
                var msg = new NotificationMessage("SEL_T001_INQ_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }

        private void txtAddress1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        
    }
}