using Reflection.Modules.SCM.ViewModels;
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

namespace Reflection.Modules.SCM.Views
{
    /// <summary>
    /// Interaction logic for DeliveryNote2_P2P.xaml
    /// </summary>
    public partial class DeliveryNote2_P2P : WindowElement
    {
        public DeliveryNote2_P2P(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new LOG_T001_A_VM2_P2P(ts_code);
        }
        public DeliveryNote2_P2P(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new LOG_T001_A_VM2_P2P(ts_code,doc_no);
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
                dgtransporter.UnselectAll();

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
                //  dgPopUpsold_to.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopUpS_Order_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopUpS_Order.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
        private void dgPopUpdel_desc_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //   dgPopUpdel_desc.UnselectAll();

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
                // dgPopUpship_toParty.UnselectAll();

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

        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            dgMake.UnselectAll();
        }
        
    }
}
