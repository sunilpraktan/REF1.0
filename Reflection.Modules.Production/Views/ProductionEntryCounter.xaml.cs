using Reflection.Modules.Production.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Input;

namespace Reflection.Modules.Production.Views
{
    /// <summary>
    /// Interaction logic for ProductionEntryCounter.xaml
    /// </summary>
    public partial class ProductionEntryCounter : WindowElement
    {
        public ProductionEntryCounter(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new EPR_T002_PE_CounterVM(ts_code);
        }
        public ProductionEntryCounter(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new EPR_T002_PE_CounterVM(ts_code,doc_no);
        }

        private void dgmachine_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgmachine.UnselectAll();
                dgmachine.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgproduct_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgproduct.UnselectAll();
                dgproduct.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgink_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgink.UnselectAll();
                dgink.UnselectAll();
                
            }
            catch (Exception ex)
            { }
            e.Handled = true;

        }

        private void dgild_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgild.UnselectAll();
                dgild.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgpack_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgpack.UnselectAll();
                dgpack.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
        
    }
}
