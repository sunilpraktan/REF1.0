using Reflection.Modules.ADM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;

namespace Reflection.Modules.ADM.Views
{
    /// <summary>
    /// Interaction logic for M0001.xaml
    /// </summary>
    public partial class ADM_M0001 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public ADM_M0001(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new ADM_M0001_VM(ts_code);
            InitializeComponent();
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
