using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
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
using Reflection.Presentation.Windows.Controls;
using Reflection.WebServices.Gateway;
using System.Collections.Generic;
using Reflection.Modules.CustomerRelation.ViewModels;


namespace Reflection.Modules.CustomerRelation.Views
{
    /// <summary>
    /// Interaction logic for AutoSalesInvoiceMultiple.xaml
    /// </summary>
    public partial class Logistic_periodicReport : WindowElement
    {
        public Logistic_periodicReport()
        {
            InitializeComponent();
            this.DataContext = new Logistic_periodicReportVM();
        }
        public Logistic_periodicReport(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new Logistic_periodicReportVM();
        }
        private void dgPopup1_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopup1.UnselectAll();

            }
            catch
            {

            }
            e.Handled = true;
        }
    
    }
}

