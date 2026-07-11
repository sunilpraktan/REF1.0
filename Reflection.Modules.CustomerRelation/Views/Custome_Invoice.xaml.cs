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
    /// Interaction logic for Custome_Invoice.xaml
    /// </summary>
    public partial class Custome_Invoice : WindowElement 
    {
        private bool isManualEditCommit;
        private string ts_code_local;
        public Custome_Invoice(string ts_code)
        {
            ts_code_local = ts_code;
            InitializeComponent();
            this.DataContext = new SEL_T003_Custome_VM("CI", ts_code);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public Custome_Invoice(string ts_code, string doc_n)
        {
            ts_code_local = ts_code;
            InitializeComponent();
            this.DataContext = new SEL_T003_Custome_VM("CI", ts_code, doc_n);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }


        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == ts_code_local)
            {
                popup_NotifyParty.IsOpen = false;
                popup_NotifyParty2.IsOpen = false;
                _popuptr_mode.IsOpen = false;
                //popup_Ref_doc_no.IsOpen = false;
                //_popup_DocCat.IsOpen = false;
                popup_SOtype.IsOpen = false;
                _popupBillAdddress.IsOpen = false;
                _popupPayer.IsOpen = false;
                _popupCurrency.IsOpen = false;
                _popupPlant.IsOpen = false;
                _popupcf_agent.IsOpen = false;
                _popupEPCG.IsOpen = false;
                _popupAdvance.IsOpen = false;
                _popupProductDes.IsOpen = false;
                //_popupFormType.IsOpen = false;
                //_popupGodown.IsOpen = false;
                _popupTransporter.IsOpen = false;
                _popupPayTerms.IsOpen = false;
                _popupOurBank.IsOpen = false;
                _popupNastroBank.IsOpen = false;
                _popupCostCentre.IsOpen = false;
                //_popupjournal.IsOpen = false;
                _popupCustNo.IsOpen = false;
                _popupCountry.IsOpen = false;
                _popupSalesOrg.IsOpen = false;
                _popupSalesGroup.IsOpen = false;
                _popupSaleDivision.IsOpen = false;
                _popupDistributionchannel.IsOpen = false;
                popFilterSearch.IsOpen = false;
                PopSoDetail.IsOpen = false;
                PopDNDetail.IsOpen = false;
                _popupwithholding.IsOpen = false;
                _popupDeclaration.IsOpen = false;
                
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
            if (e.Source != _popupCurrency)
            {
                var msg = new NotificationMessage(ts_code_local);
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        
    }
}
