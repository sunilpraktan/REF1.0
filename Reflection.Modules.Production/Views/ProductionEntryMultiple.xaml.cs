using Reflection.Modules.Production.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Input;

namespace Reflection.Modules.Production.Views
{
    /// <summary>
    /// Interaction logic for ProductionEntryMultiple.xaml
    /// </summary>
    public partial class ProductionEntryMultiple : WindowElement
    {
        public ProductionEntryMultiple(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new PPC_T002VM(ts_code);
        }
        public ProductionEntryMultiple(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new PPC_T002VM(ts_code,doc_no);
        }
        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // dgPopupPlant.UnselectAll();
                //dgPopupMachine.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgParameters_Unloaded(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }

        private void PopPara_Unloaded(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }
        
    }
}
