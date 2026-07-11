using Reflection.Modules.ADM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Reflection.Modules.ADM.Views
{
    /// <summary>
    /// Interaction logic for ADM_M0012.xaml
    /// </summary>
    public partial class ADM_M0012 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public ADM_M0012()
        {
            InitializeComponent();
        }
        public ADM_M0012(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new ADM_M0012_VM(ts_code);
            InitializeComponent();
        }
        public ADM_M0012(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new ADM_M0012_VM(ts_code);
        }

        private void dgPopupUnit_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopupUnit.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopupItem_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopupItem.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopupSorucUnit_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopupSorucUnit.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopupSorucUnitinter_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopupSorucUnitinter.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;

        }

        private void dgPopupIteminter_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopupIteminter.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopupDestiUnitinter_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopupDestiUnitinter.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
    }
}
