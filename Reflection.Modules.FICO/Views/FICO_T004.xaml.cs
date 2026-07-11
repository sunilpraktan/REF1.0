using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using Reflection.Modules.FICO.ViewModels;
using Reflection.Presentation.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.FICO.Views
{
    /// <summary>
    /// Interaction logic for FICO_T001.xaml
    /// </summary>
    public partial class FICO_T004 : WindowElement
    {
        public string ts_code_vm { get; set; }
        private bool isManualEditCommit;
        public FICO_T004(string ts_code)
        {
            ts_code_vm = ts_code;
            
            this.DataContext = new FICO_T004_VM("PI", ts_code);
            InitializeComponent();
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public FICO_T004(string ts_code, string doc_no)
        {
            ts_code_vm = ts_code;
            InitializeComponent();
            this.DataContext = new FICO_T004_VM("PI", ts_code, doc_no);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == ts_code_vm)
            {
                _popupTaxDeclaration.IsOpen = false;
                popup_NotifyParty.IsOpen = false;
                popup_NotifyParty2.IsOpen = false;
                popTradeIndicator.IsOpen = false;
                _popuptr_mode.IsOpen = false;
                popFilterSearch.IsOpen = false;
                popup_SOtype.IsOpen = false;
                _popupBillAdddress.IsOpen = false;
                _popupPayer.IsOpen = false;
                _popupSeller.IsOpen = false;
                _popupCurrency.IsOpen = false;
                _popupPlant.IsOpen = false;
                _popupcf_agent.IsOpen = false;
                _popupEPCG.IsOpen = false;
                _popupAdvance.IsOpen = false;
                _popupFormType.IsOpen = false;
                _popupIncoterm.IsOpen = false;
                _popupGodown.IsOpen = false;
                _popupTransporter.IsOpen = false;
                _popupPayTerms.IsOpen = false;
                _popupOurBank.IsOpen = false;
                _popupNastroBank.IsOpen = false;
                _popupCostCentre.IsOpen = false;
                _popupjournal.IsOpen = false;
                _popupCustNo.IsOpen = false;
                _popupCountry.IsOpen = false;
                _popupSalesOrg.IsOpen = false;
                _popupSalesGroup.IsOpen = false;
                _popupSaleDivision.IsOpen = false;
                _popupDistributionchannel.IsOpen = false;
                PopQNDetail.IsOpen = false;
                PopSoDetail.IsOpen = false;
                PopINDetail.IsOpen = false;
                _popupwithholding.IsOpen = false;
            }
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
            if (e.Source != _popupCurrency)
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
