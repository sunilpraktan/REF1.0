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
using System.IO;
using Microsoft.Win32;


namespace Reflection.Modules.Administration.Views
{
    //<summary>
    //Interaction logic for CompanyMaster.xaml
    //</summary>
    public partial class Company_Master : WindowElement
    {
        public Company_Master()
        {
            InitializeComponent();
            this.DataContext = new ADM_M002_VM();
        }
        public Company_Master(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new ADM_M002_VM();
        }
        public Company_Master(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new ADM_M002_VM();
        }

        private void dgPopupGroup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopupGroup.UnselectAll();
                dgPopupCountry.UnselectAll();
                dgPopupState.UnselectAll();
                dgPopupCompCountry.UnselectAll();
                dgPopupCompState.UnselectAll();
                dgPopupContPrsNameList.UnselectAll();
                dgPopupBus_plc.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
    }
}
