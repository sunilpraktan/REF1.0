using System;
using System.Windows;
using Reflection.Modules.Production.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.Production.Views
{
    /// <summary>
    /// Interaction logic for Sorting.xaml
    /// </summary>
    public partial class Sorting : WindowElement
    {
        public Sorting(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new ESO_T001_VM(ts_code);
        }
        public Sorting(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new ESO_T001_VM(ts_code,doc_no);
        }

        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgMachine.UnselectAll();
                dgshift.UnselectAll();
                dgShiftIncharge.UnselectAll();
                dgOperator.UnselectAll();
                dgBatch.UnselectAll();



            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }




        private void dgPopupItems_Unloaded(object sender, RoutedEventArgs e)
        {

            e.Handled = true;
        }

        private void dgUOM_Unloaded(object sender, RoutedEventArgs e)
        {
            dgUOM.UnselectAll();
        }
        
    }
}
