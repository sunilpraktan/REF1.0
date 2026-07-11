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
using System.Collections.ObjectModel;
using Reflection.Modules.SCM.ViewModels;
using Reflection.Modules.SCM.Views;
using Reflection.BusinessEntity;

namespace Reflection.Modules.SCM.Views
{
    /// <summary>
    /// Interaction logic for MIS_SCM_Report1.xaml
    /// </summary>
    public partial class MIS_SCM_Report3 : WindowElement
    {
        public MIS_SCM_Report3(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new MIS_SCM_Report3_VM(ts_code);

        }



        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PartyCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            //MC8.Text = "";
            MC3.Text = "";
            MC15.Text = "";
            MC12.Text = "";



        }
        private void DgPopUp_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopup1.UnselectAll();
                dgPopup2.UnselectAll();
                dgMachinePopup.UnselectAll();
                dgunit.UnselectAll();
                dgPopupplant.UnselectAll();
                dgPopUpmake.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void MC_UnCheck(object sender, RoutedEventArgs e)
        {


        }

        private void MC8_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
