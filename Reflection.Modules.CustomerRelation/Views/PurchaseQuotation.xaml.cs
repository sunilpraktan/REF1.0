using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Reflection.Presentation.Windows.Controls;
using Reflection.Modules.CustomerRelation.ViewModels;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.CustomerRelation.Views
{
    /// <summary>
    /// Interaction logic for PurchaseQuotation.xaml
    /// </summary>
    public partial class PurchaseQuotation : WindowElement
    {
        public PurchaseQuotation(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new PUR_T002_VMQTN(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public PurchaseQuotation(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new PUR_T002_VMQTN(ts_code, doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        //For new PopUp
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "PUR_T002_VMQTN")
            {
                popup_Supplier.IsOpen = false;
                popup_Buyer.IsOpen = false;
                popup_ValidatedBy.IsOpen = false;
                popup_ContactPerson.IsOpen = false;
                popupDelAddress.IsOpen = false;
                popupBillAddress.IsOpen = false;
                popupCurrency.IsOpen = false;
                popupPaymentterm.IsOpen = false;
                popup_PurOrg.IsOpen = false;
                popup_PurGrp.IsOpen = false;
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
                var msg = new NotificationMessage("PUR_T002_VMQTN");
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
                var msg = new NotificationMessage("PUR_T002_VMQTN");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // dgPopup.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        //private void dgData_Loaded(object sender, RoutedEventArgs e)
        //{

        //    e.Handled = true;
        //}
        //private void dgData_Unloaded(object sender, RoutedEventArgs e)
        //{

        //    e.Handled = true;
        //}

        //private void btnSrNo_Loaded(object sender, RoutedEventArgs e)
        //{
        //    e.Handled = true;
        //}

        private void btnSrNo_Unloaded(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }

        private void PopPara_Unloaded(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }

        //private void PopPara_Loaded(object sender, RoutedEventArgs e)
        //{
        //    e.Handled = true;
        //}

        private void dgParameters_Unloaded(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }

        //private void dgsotype_Unloaded(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        dgsotype.UnselectAll();
        //    }
        //    catch (Exception ex)
        //    { }
        //    e.Handled = true;
        //}

        private void dgbuyer_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgbuyer.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopupParty_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgPopupParty.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopupreftype_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgPopupreftype.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        //private void dgPopupQuotation_Unloaded(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        dgPopupQuotation.UnselectAll();
        //    }
        //    catch (Exception ex)
        //    { }
        //    e.Handled = true;
        //}

        private void dgvalidated_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgvalidated.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgdeladdr_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgdeladdr.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgbilladdr_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgbilladdr.UnselectAll();
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

        private void dgPopuppayterm_Unloaded(object sender, RoutedEventArgs e)
        {
            //dgPopuppayterm.UnselectAll();
        }

        private void dgPopupplant_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgPopupplant.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopupItems_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgPopupItems.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgParameters_Unloaded_1(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgParameters.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgtax_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgtax.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgsaleorgnisation11_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgsaleorgnisation11.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;

        }

        private void dgPopupItems1_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgPopupItems1.UnselectAll();
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

        private void dgsaleorgnisation1_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgsaleorgnisation1.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgsaleorgnisation2_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgsaleorgnisation2.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgcostcentre_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgcostcentre.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgjournal_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgjournal.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }


        private void dgvalidator_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgvalidator.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgDeliveryAddress_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgDeliveryAddress.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgInvoiceAddress_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgInvoiceAddress.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void txtPartnerID_LostFocus(object sender, RoutedEventArgs e)
        {
            // Pending
            //BindingExpression be = txtPartnerID.GetBindingExpression(TextBox.TextProperty);
            //be.UpdateSource();
        }

        private void TabControl_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }




        //private void dgParameters_Loaded(object sender, RoutedEventArgs e)
        //{
        //    e.Handled = true;
        //}
        
    }
}
