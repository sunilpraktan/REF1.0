using System;
using Reflection.Presentation.Windows.Controls;
using Reflection.Modules.PRO.ViewModels;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Input;

namespace Reflection.Modules.PRO.Views
{
    /// <summary>
    /// Interaction logic for PRO_T001.xaml
    /// </summary>
    public partial class PRO_T011 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public PRO_T011(string ts_code)
        {
            InitializeComponent();
            ts_code_vm = ts_code;
            this.DataContext = new PRO_T007_VM("RT", ts_code);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);

        }
        public PRO_T011(string ts_code, string doc_no)
        {
            InitializeComponent();
            ts_code_vm = ts_code;
            this.DataContext = new PRO_T007_VM("RT", ts_code, doc_no);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == ts_code_vm)
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
            if (e.Source != popupCurrency)
            {
                var msg = new NotificationMessage(ts_code_vm);
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
    }
}
