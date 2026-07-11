using Reflection.Presentation.Windows.Controls;
using Reflection.Modules.SCM.ViewModels;
using Reflection.WebServices.Gateway;
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
    /// Description for ProductConversion.
    /// </summary>
    public partial class ProductConversion : WindowElement
    {
        /// <summary>
        /// Initializes a new instance of the ProductConversion class.
        /// </summary>
        public ProductConversion()
        {
            InitializeComponent();
            this.DataContext = new MM_T001_PC_VM();
        }

        private void dgParameters_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        private void dgPopUpJobCart_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopUpJobCart.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopUpmov_tp_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopUpmov_tp.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
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

        private void dgPopupItemsS_Unloaded(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    dgPopupItemsS.UnselectAll();

            //}
            //catch (Exception ex)
            //{ }
            //e.Handled = true;

        }



        
    }
}