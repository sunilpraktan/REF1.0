using System;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;
using Reflection.Modules.Administration.ViewModels;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Windows.Controls;
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

namespace Reflection.Modules.Administration.Views
{
    /// <summary>
    /// Interaction logic for InkCatalog.xaml
    /// </summary>
    public partial class InkCatalog : WindowElement
    {
        /// <summary>
        /// Initializes a new instance of the Ink Catalog class
        /// </summary>
        public InkCatalog()
        {
            InitializeComponent();
            this.DataContext = new ZADM_M026_VM();
        }
        private void DgPopUp_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgSupplier.UnselectAll();
                dgItemCode.UnselectAll();
                dgInkCode.UnselectAll();
                dgcustomer.UnselectAll();
                
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
    }
}
