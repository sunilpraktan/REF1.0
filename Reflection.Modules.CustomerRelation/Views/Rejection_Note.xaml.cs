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
    /// Interaction logic for Rejection_Note.xaml
    /// </summary>
    public partial class Rejection_Note : WindowElement
    {
        public Rejection_Note(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new EQCR_T001_VM_RejectionNote(ts_code);
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
