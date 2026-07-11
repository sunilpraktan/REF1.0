using Reflection.Modules.SCM.ViewModels;
using Reflection.Presentation.Windows.Controls;
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
    /// Description for StockChart.
    /// </summary>
    public partial class StockChart : WindowElement
    {
        /// <summary>
        /// Initializes a new instance of the StockChart class.
        /// </summary>
        /// public static readonly DependencyProperty DataListProperty =     

        public StockChart()
        {
            InitializeComponent();
            this.DataContext = new MM_M005_VM();  
        }

        private void dgPopUpProdct_Unloaded(object sender, RoutedEventArgs e)
        {

            try
            {
                dgPopUpProdct.UnselectAll();
                //dgParameters.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
        
    }
}