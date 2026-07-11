using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.SCM.ViewModels;
using Reflection.Presentation.Services;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.SCM.Views
{
    /// <summary>
    /// Interaction logic for DeliveryNote.xaml
    /// </summary>
    public partial class DeliveryNote : WindowElement
    {
        private bool isManualEditCommit;
        private string ts_code_local;
        public DeliveryNote(string ts_code)
        {
            this.ts_code_local = ts_code;
            InitializeComponent();
            this.DataContext = new LOG_T001_A_VM(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public DeliveryNote(string ts_code,string doc_no)
        {
            this.ts_code_local = ts_code;
            InitializeComponent();
            this.DataContext = new LOG_T001_A_VM(ts_code,doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public DeliveryNote(string doc_no, string ts_code,string ts_name_display)
        {
            this.ts_code_local = ts_code;
            AppSessionState.ViewTitle = ts_name_display;
            InitializeComponent();
            this.DataContext = new LOG_T001_A_VM(doc_no, ts_code, ts_name_display);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
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
                var msg = new NotificationMessage(this.ts_code_local);
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == this.ts_code_local)
            {
                popTransporter.IsOpen = false;
                popTR_Mode.IsOpen = false;
            }
        }
        private void mainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source != currency_popup)
            {
                var msg = new NotificationMessage(this.ts_code_local);
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }

        private void dgParty_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // dgParty.UnselectAll();                          

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopupCurrency_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopupCurrency.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;

        }

        private void dgtransporter_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgtransporter.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopupItems_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //  dgPopupItems.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopupitem_cat_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // dgPopupitem_cat.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopUpsold_to_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopUpsold_to.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
        private void dgPopUpSeller_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopUpSeller.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
        
        private void dgPopUpdel_desc_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopUpdel_desc.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgsaleorgnisation_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgsaleorgnisation.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgDistribution_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgDistribution.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgsaledivision_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgsaledivision.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgsalesoffice_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgsalesoffice.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgsalesgroup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgsalesgroup.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgbus_area_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgbus_area.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        //private void dgPopupWarehouse_Unloaded(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        dgPopupWarehouse.UnselectAll();

        //    }
        //    catch (Exception ex)
        //    { }
        //    e.Handled = true;
        //}

        //private void dgStoreloc_Unloaded(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        dgStoreloc.UnselectAll();

        //    }
        //    catch (Exception ex)
        //    { }
        //    e.Handled = true;
        //}

        private void dgcostcentre_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //    dgcostcentre.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgprofitcentre_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //   dgprofitcentre.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopUpship_toParty_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopUpship_toParty.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopupso_noB_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //  dgPopupso_noB.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        //private void dgPopUpmov_tp_Unloaded(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        dgPopUpmov_tp.UnselectAll();

        //    }
        //    catch (Exception ex)
        //    { }
        //    e.Handled = true;
        //}


        private void dgParameters_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // dgParameters.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void PopPara_Unloaded(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    PopPara.UnselectAll();

            //}
            //catch (Exception ex)
            //{ }
            e.Handled = true;
        }

        private void dgPopupItemsplit_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // dgPopupItemsplit.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopUpcf_agent_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopUpcf_agent.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopUporg_country_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopUporg_country.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopupItemsplit1_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //  dgPopupItemsplit1.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;

        }

        private void dgDeliveryAddress_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgDeliveryAddress.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgInvoiceAddress_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgInvoiceAddress.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgepcg_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgepcg.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgepcg1_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgepcg1.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgcpersonname_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgcpersonname.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
            
        }

        private void dgPopUpData(object sender, RoutedEventArgs e)
        {
            try
            {
                dgsotype.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
            
        }

        

        private void dgincoterms_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgincoterms.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
        
    }
}
