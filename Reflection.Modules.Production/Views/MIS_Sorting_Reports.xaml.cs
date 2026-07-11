using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
using Reflection.Modules.Production.ViewModels;

namespace Reflection.Modules.Production.Views
{
    /// <summary>
    /// Interaction logic for MIS_Sorting_Reports.xaml
    /// </summary>
    public partial class MIS_Sorting_Reports : WindowElement
    {
        public MIS_Sorting_Reports(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new MIS_Sorting_ReportsVM(ts_code);

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PartyCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

        }
        private void DgPopUp_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopupplant.UnselectAll();
                dgPopupcomp.UnselectAll();
                dgMachinePopup.UnselectAll();
                dgDefectPopup.UnselectAll();
                dgunit.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }


    }
}
