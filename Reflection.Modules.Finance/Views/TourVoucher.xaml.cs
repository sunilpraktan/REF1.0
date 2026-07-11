using System;
using Reflection.Presentation.Windows.Controls;
using Reflection.Modules.Finance.ViewModels;
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

namespace Reflection.Modules.Finance.Views
{
    /// <summary>
    /// Interaction logic for TourVoucher.xaml
    /// </summary>
    public partial class TourVoucher : WindowElement
    {
        public TourVoucher()
        {
            InitializeComponent();
            this.DataContext=new ACC_T003_TV_VM();
        }
        public TourVoucher(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new ACC_T003_TV_VM();
        }
        private void DgPopUp_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgsaleorgnisation.UnselectAll();
                dgSalesGroup.UnselectAll();
                dgEmployee.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        
    }
}
