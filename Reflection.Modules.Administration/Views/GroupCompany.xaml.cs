using Reflection.Modules.Administration.ViewModels;
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

namespace Reflection.Modules.Administration.Views
{
    /// <summary>
    /// Interaction logic for GroupCompany.xaml
    /// </summary>
    public partial class GroupCompany : WindowElement
    {
        public GroupCompany()
        {
            //chages fg sdfsdfsdf
            InitializeComponent();
            this.DataContext = new ADM_M001_VM();
        }
        public GroupCompany(string ts_code)
        {
            //chages fg sdfsdfsdf
            InitializeComponent();
            this.DataContext = new ADM_M001_VM();
        }
        public GroupCompany(string ts_code, string doc_no)
        {
            //chages fg sdfsdfsdf
            InitializeComponent();
            this.DataContext = new ADM_M001_VM();
        }

        private void dgPopupCountry_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopupState.UnselectAll();
                dgPopupCountry.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

      
    }
}
