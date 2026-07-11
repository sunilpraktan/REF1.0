using System;
using System.Windows.Controls;
using Reflection.Presentation.Windows.Controls;
using Reflection.Modules.CustomerRelation.ViewModels;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Input;

namespace Reflection.Modules.CustomerRelation.Views
{
    /// <summary>
    /// Interaction logic for PurchaseInvoice_DebitCredit.xaml
    /// </summary>
    public partial class PurchaseInvoice_DebitCredit : WindowElement
    {
        public PurchaseInvoice_DebitCredit(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new PUR_T005_DebitCredit_VM(ts_code);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public PurchaseInvoice_DebitCredit(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new PUR_T005_DebitCredit_VM(ts_code, doc_no);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "PUR_T005_DebitCredit_VM")
            {
                popTradeIndicator.IsOpen = false;
                popup_SuppParty.IsOpen = false;
                popup_Payee.IsOpen = false;
                popup_DocCurr.IsOpen = false;
                popup_Plant.IsOpen = false;
                popup_PaymentTerm.IsOpen = false;
                popup_PaymentMethod.IsOpen = false;
                popup_CompanyBank.IsOpen = false;
                popup_NastroBank.IsOpen = false;
                popup_PurOrg.IsOpen = false;
                popup_PurGrp.IsOpen = false;
                _popupIncoterm.IsOpen = false;
                _popupEPCG.IsOpen = false;
                _popupAdvance.IsOpen = false;
                _popupCFAgent.IsOpen = false;
                popup_CostCenter.IsOpen = false;
                popup_Journal.IsOpen = false;
                doctypepopup.IsOpen = false;
                popup_BussPlace.IsOpen = false;
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
                var msg = new NotificationMessage("PUR_T005_DebitCredit_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        private void mainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source != popup_SuppParty)
            {
                var msg = new NotificationMessage("PUR_T005_DebitCredit_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
    }
}
