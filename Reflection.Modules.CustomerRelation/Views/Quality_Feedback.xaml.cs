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
    /// Description for Quality_Feedback.
    /// </summary>
    public partial class Quality_Feedback : WindowElement
    {
        /// <summary>
        /// Initializes a new instance of the Quality_Feedback class.
        /// </summary>
        public Quality_Feedback(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new ECRM_T002_A_VM(ts_code);
        }
        public Quality_Feedback(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new ECRM_T002_A_VM(ts_code, doc_no);
        }

        private void dgPopUpProdct_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopUpProdct.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopUpmodel_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopUpmodel.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
        private void dgPopUpunitinv_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopUpunitinv.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
        private void dgPopUnitdefect_qty_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopUnitDefect_qty.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopUpParty_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopUpParty.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopUpILD_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopUpILD.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;

        }

        private void dgPopUpINK_Unloaded(object sender, RoutedEventArgs e)
        {
            dgPopUpINK.UnselectAll();
        }

        private void dgPopUpcmplnt_RecvBy_Unloaded(object sender, RoutedEventArgs e)
        {
            dgPopUpcmplnt_RecvBy.UnselectAll();
        }

       

        private void dgPopUpcmplnt_HandlBy_Unloaded(object sender, RoutedEventArgs e)
        {
            dgPopUpcmplnt_HandlBy.UnselectAll();
        }

        private void dgPopUpPlant_Unloaded(object sender, RoutedEventArgs e)
        {
            dgPopUpPlant.UnselectAll();
        }

       
       
    }
}