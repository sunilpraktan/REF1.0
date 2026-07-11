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
    /// Interaction logic for MIS_Sales_Insurance.xaml
    /// </summary>

    public partial class MIS_Sales_Insurance : WindowElement
    {
        public MIS_Sales_Insurance()
        {
            InitializeComponent();
            this.DataContext = new MIS_Sales_InsuranceVM();
        }
        public MIS_Sales_Insurance(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new MIS_Sales_InsuranceVM();
        }

        private void DgPopUp_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopupplant.UnselectAll();
                dgPopupcomp.UnselectAll();
                dgunit.UnselectAll();
                dgFin.UnselectAll();
                dgPost1.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
       
}
