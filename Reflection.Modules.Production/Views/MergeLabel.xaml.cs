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
    /// Interaction logic for MergeLabel.xaml
    /// </summary>
    public partial class MergeLabel : WindowElement
    {
        public MergeLabel(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new EPR_T002_MergeLabelVM(ts_code);
        }
        public MergeLabel(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new EPR_T002_MergeLabelVM(ts_code,doc_no);
        }


        private void dgproduct3_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgproduct3.UnselectAll();
                
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgink3_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgink3.UnselectAll();
                
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgpack4_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgpack4.UnselectAll();
              
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgild5_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgild5.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgmachine_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgmachine.UnselectAll();
                dgmachine5.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;

        }

        private void dgproduct_Unloaded(object sender, RoutedEventArgs e)
        {
            dgproduct.UnselectAll();
        }

        private void dgink_Unloaded(object sender, RoutedEventArgs e)
        {
            dgink.UnselectAll();
        }

        private void dgild_Unloaded(object sender, RoutedEventArgs e)
        {
            dgild.UnselectAll();
        }

        private void dgpack_Unloaded(object sender, RoutedEventArgs e)
        {
            dgpack.UnselectAll();
        }
    }
}
