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
    /// Interaction logic for OpeningStock.xaml
    /// </summary>
    public partial class OpeningStock : WindowElement
    {
        public OpeningStock(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new MM_T001_OpeningStock_VM (ts_code);
        }
        public OpeningStock(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new MM_T001_OpeningStock_VM(ts_code,doc_no);
        }

        private void dgplant_Unloaded(object sender, RoutedEventArgs e)
        {
            dgplant.UnselectAll();
            dgMStoreLoc.UnselectAll();
        }

        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            dgsaleorgnisation.UnselectAll();
            dgPurchaseGroup.UnselectAll();
        }
        
    }
}
