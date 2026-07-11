using Reflection.Modules.Quality.ViewModels;
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
    /// Interaction logic for QCR.xaml
    /// </summary>
    public partial class QCR : WindowElement
    {
        public QCR()
        {
            InitializeComponent();
            this.DataContext = new EQCR_T001_VM();
        }
        public QCR(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new EQCR_T001_VM();
        }

        private void dgmaterial_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgmaterial.UnselectAll();
                dgsold_party.UnselectAll();
                dgUOM.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

    }
}
