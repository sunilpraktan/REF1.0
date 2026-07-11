using Reflection.Modules.Finance.ViewModels;
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

namespace Reflection.Modules.Finance.Views
{
    /// <summary>
    /// Interaction logic for MISFinance_Payment2.xaml
    /// </summary>
    public partial class MISFinance_Payment2 : WindowElement
    {
        public MISFinance_Payment2()
        {
            InitializeComponent();
            this.DataContext = new MISFinance_Payment2_VM();
        }
        public MISFinance_Payment2(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new MISFinance_Payment2_VM();
        }
        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            dgPopupcomp.UnselectAll();
            dgPopupplant.UnselectAll();
            //dgPopup2.UnselectAll();
            dgPopup1.UnselectAll();
        }
    }
}
