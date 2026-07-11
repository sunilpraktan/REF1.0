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
    /// Interaction logic for ExpectedPayment.xaml
    /// </summary>
    public partial class ExpectedPayment : WindowElement
    {
        public ExpectedPayment()
        {
            InitializeComponent();
            this.DataContext = new TSK_T001_C_EP_VM();
        }
        public ExpectedPayment(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new TSK_T001_C_EP_VM();
        }
        private void DgPopUpUnloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgPopupEmp.UnselectAll();
                //dgPopupRefSoNo.UnselectAll();
                dgPopupParty.UnselectAll();
               
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgDataPODatails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
  
}
