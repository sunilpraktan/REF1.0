using Reflection.Modules.Production.ViewModels;
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

namespace Reflection.Modules.Production.Views
{
    /// <summary>
    /// Interaction logic for LabelGeneration2.xaml
    /// </summary>
    public partial class LabelGeneration2 : WindowElement
    {
        public LabelGeneration2(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new EPR_T002VM(ts_code);
        }
        public LabelGeneration2(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new EPR_T002VM(ts_code,doc_no);
        }
        private void dgmachine_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgmachine.UnselectAll();
                dgmachine.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgproduct_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgproduct.UnselectAll();
                dgproduct.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
        private void dgItem_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgItem.UnselectAll();
                dgItem.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgink_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgink.UnselectAll();
                dgink.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;

        }

        private void dgild_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgild.UnselectAll();
                dgild.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgpack_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgpack.UnselectAll();
                dgpack.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
        
    }
}
