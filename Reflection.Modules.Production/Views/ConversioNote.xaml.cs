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
    /// Interaction logic for ILDChart.xaml
    /// </summary>
    public partial class ConversioNote : WindowElement
    {
        public ConversioNote(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new EPR_T001_AVM(ts_code);
        }
        public ConversioNote(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new EPR_T001_AVM(ts_code,doc_no);
        }

        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgPopupBall.UnselectAll();
                dgPopupMachine.UnselectAll();
                dgPopupMachine1.UnselectAll();
                dgPopupCustomer.UnselectAll();
                dgPUnit.UnselectAll();
                dgPopupSalesOrder.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgParameters_Unloaded(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }

        private void PopPara_Unloaded(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }

        private void dgPopupSalesOrder_Unloaded(object sender, RoutedEventArgs e)
        {
          
            try
            {
                dgPopupSalesOrder.UnselectAll();
                
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        
    }
}
