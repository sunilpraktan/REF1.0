using System;
using Reflection.Presentation.Windows.Controls;
using Reflection.Modules.CustomerRelation.ViewModels;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Input;

namespace Reflection.Modules.CustomerRelation.Views
{
    /// <summary>
    /// Description for StockTransfer.
    /// </summary>
    public partial class StockTransfer : WindowElement
    {
        /// <summary>
        /// Initializes a new instance of the StockTransfer class.
        /// </summary>
        public StockTransfer(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new PUR_T002_VM("TO", ts_code);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public StockTransfer(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new PUR_T002_VM("TO", ts_code, doc_no);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "PUR_T002_VM")
            {
                PopRQDetail.IsOpen = false;
                popup_Buyer.IsOpen = false;
                popupCurrency.IsOpen = false;
                popupPaymentterm.IsOpen = false;
                popup_PurOrg.IsOpen = false;
                popup_PurGrp.IsOpen = false;
                popup_CostCentre.IsOpen = false;
                _popup_status.IsOpen = false;
                //popSupplingplant.IsOpen = false;
                popReceivingPlant.IsOpen = false;
                PopItems.IsOpen = false;
                PopRQDetail.IsOpen = false;
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
            if (e.Source != popupCurrency)
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