using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
using Reflection.Modules.Production.ViewModels;

namespace Reflection.Modules.Production.Views
{
    /// <summary>
    /// Interaction logic for MIS_SCM_Report1.xaml
    /// </summary>
    public partial class MIS_Pro_Periodic : WindowElement
    {
        public MIS_Pro_Periodic(string ts_code)
       {
          InitializeComponent();
          this.DataContext = new MIS_Pro_PeriodicVM(ts_code);

        }



        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PartyCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MC8.Text = "";
            MC10.Text = "";
            MC12.Text = "";
            MC15.Text = "";
            MC16.Text = "";
            MC17.Text = "";
            MC18.Text = "";
            MC19.Text = "";
            MC20.Text = "";
            MC22.Text = "";
            MC24.Text = "";
        }
        private void DgPopUp_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopup1.UnselectAll();
                dgPopup2.UnselectAll();
                dgunit.UnselectAll();
                dgMachinePopup.UnselectAll();
                dgPopupplant.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
    }
}

