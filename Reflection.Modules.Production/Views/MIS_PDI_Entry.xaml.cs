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

namespace Reflection.Modules.Production.Views
{
    /// <summary>
    /// Interaction logic for MIS_PDI_Entry.xaml
    /// </summary>
    public partial class MIS_PDI_Entry : WindowElement
    {
        public MIS_PDI_Entry()
        {
            InitializeComponent();
        }
        private void DgPopUp_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopup1.UnselectAll();
                

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
        
    }
}
