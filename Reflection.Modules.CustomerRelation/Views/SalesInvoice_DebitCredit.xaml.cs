using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.CustomerRelation.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Reflection.Modules.CustomerRelation.Views
{
    /// <summary>
    /// Interaction logic for SalesInvoice_DebitCredit.xaml
    /// </summary>
    public partial class SalesInvoice_DebitCredit : WindowElement
    {
        public SalesInvoice_DebitCredit(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new SEL_T003_SalesInvoiceDebitCredit_VM(ts_code);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public SalesInvoice_DebitCredit(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new SEL_T003_SalesInvoiceDebitCredit_VM(ts_code, doc_no);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        private void dgselected_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgsotype.UnselectAll();
                //dgPopupParty.UnselectAll();
                //dgpayer.UnselectAll();
                //dgReferance.UnselectAll();
                //dgplant.UnselectAll();
                //dgPopupCurrency.UnselectAll();
                //dgPayterms.UnselectAll();
                //dgsaleorgnisation.UnselectAll();
                //dgSalesGroup.UnselectAll();
                //dgcostcentre.UnselectAll();
                //dgjournal.UnselectAll();
                //dgSalesPerson.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopuppayer_Unloaded(object sender, RoutedEventArgs e)
        {

            try
            {
                //dgsotype.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgPopup.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopuptax_org_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgPopuptax_org.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopupbtncurrency_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgPopupbtncurrency.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopupcomp_bank_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgPopupcomp_bank.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopupcomp_palnt_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgPopupcomp_palnt.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopupcf_agent_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgPopupcf_agent.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgsaleorgnisation_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgsaleorgnisation.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgsalesgroup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgsalesgroup.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgsold_party_Unloaded(object sender, RoutedEventArgs e)
        {

            try
            {
                //dgsold_party.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopupshpngcond_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        private void dgtransport_party_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgtransport_party.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgprod_descr_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgprod_descr.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dggodwn_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dggodwn.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgdel_at_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgdel_at.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopuppayterm_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgPopuppayterm.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgsaledivision_Unloaded(object sender, RoutedEventArgs e)
        {
            //
            try
            {
                //dgsaledivision.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgFormType_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgFormType.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "SEL_T003_SalesInvoiceDebitCredit_VM")
            {
                popFilterSearch.IsOpen = false;
                //popup_Ref_doc_no.IsOpen = false;
                //_popup_DocCat.IsOpen = false;
                //popup_SOtype.IsOpen = false;
                //_popupBillAdddress.IsOpen = false;
                //_popupPayer.IsOpen = false;
                //_popupSeller.IsOpen = false;
                //_popupCurrency.IsOpen = false;
                //_popupPlant.IsOpen = false;
                //_popupcf_agent.IsOpen = false;
                //_popupEPCG.IsOpen = false;
                //_popupAdvance.IsOpen = false;
                //_popupProductDes.IsOpen = false;
                //_popupFormType.IsOpen = false;
                //_popupGodown.IsOpen = false;
                //_popupTransporter.IsOpen = false;
                //_popupPayTerms.IsOpen = false;
                //_popupOurBank.IsOpen = false;
                //_popupNastroBank.IsOpen = false;
                //_popupCostCentre.IsOpen = false;
                //_popupjournal.IsOpen = false;
                //_popupCustNo.IsOpen = false;
                //_popupCountry.IsOpen = false;
                //_popupSalesOrg.IsOpen = false;
                //_popupSalesGroup.IsOpen = false;
                //_popupSaleDivision.IsOpen = false;
                //_popupDistributionchannel.IsOpen = false;
                //_popupPlant1.IsOpen = false;
                //_popup_DocCat1.IsOpen = false;
                //popup_BussPlace.IsOpen = false;
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
                var msg = new NotificationMessage("SEL_T003_SalesInvoiceDebitCredit_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        private void mainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //if (e.Source != _popupCurrency)
            //{
                var msg = new NotificationMessage("SEL_T003_SalesInvoiceDebitCredit_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            //}
        }
        
    }
}
