using Reflection.Modules.SCM.ViewModels;
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

namespace Reflection.Modules.SCM.Views
{
    /// <summary>
    /// Interaction logic for Physical_Stock1.xaml
    /// </summary>
    public partial class Physical_Stock1 : WindowElement
    {
        public Physical_Stock1(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new MM_S010_VM_FG(ts_code);
        }
        public Physical_Stock1(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new MM_S010_VM_FG(ts_code,doc_no);
        }
        private void dgPopupplant_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgplant.UnselectAll();
                dgMStoreLoc.UnselectAll();
                dgCompany.UnselectAll();
                dgPopUppost.UnselectAll();
                dgUnit.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgMStoreLoc_Unloaded(object sender, RoutedEventArgs e)
        {

        }
        
    }
}
