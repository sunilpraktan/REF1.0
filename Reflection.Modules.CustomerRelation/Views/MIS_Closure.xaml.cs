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
    /// Interaction logic for MIS_Closure.xaml
    /// </summary>
    public partial class MIS_Closure : WindowElement
    {
        public MIS_Closure()
        {
            InitializeComponent();
            this.DataContext = new MIS_ClosureVM();
        }
        public MIS_Closure(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new MIS_ClosureVM();
        }
        private void dgPopupLocation_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {

                dgPartyType.UnselectAll();


            }
            catch (Exception ex)
            { }
            e.Handled = true;

        }
    }
}
