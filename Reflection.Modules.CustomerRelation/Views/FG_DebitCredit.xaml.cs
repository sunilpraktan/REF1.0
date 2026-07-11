using Reflection.Modules.CustomerRelation.ViewModels;
//using Reflection.Presentation.Services.ViewModel;
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

namespace Reflection.Modules.CustomerRelation.Views
{
    /// <summary>
    /// Interaction logic for CatlogMaster.xaml
    /// </summary>
    public partial class FG_DebitCredit : WindowElement 
    {
        public FG_DebitCredit()
        {
            InitializeComponent(); 
            this.DataContext = new ZADM_M018_VM();
            
        }
        public FG_DebitCredit(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new ZADM_M018_VM();

        }

        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopupPlant.UnselectAll();
                dgPopupCustomer.UnselectAll();
                dgPopupProduct.UnselectAll();
                dgPopupILD.UnselectAll();
                dgPopupINK.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
    }
}
