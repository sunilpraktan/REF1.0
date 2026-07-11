using Reflection.Modules.Administration.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Reflection.Modules.Administration.Views
{
    /// <summary>
    /// Interaction logic for LocationMaster.xaml
    /// </summary>
    public partial class LocationMaster : WindowElement
    {
        public LocationMaster()
        {
            InitializeComponent();
            this.DataContext = new ADM_M003_VM();
        }
        public LocationMaster(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new ADM_M003_VM();
        }
        public LocationMaster(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new ADM_M003_VM();
        }

        private void dgPopupCompany_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopupCompany.UnselectAll();
                dgPopupActivity.UnselectAll();
                dgPopupCountry.UnselectAll();
                dgPopupState.UnselectAll();
                dgPopupBus_plc.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void DataLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
