using Reflection.Modules.CustomerRelation.ViewModels;
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

namespace Reflection.Modules.CustomerRelation.Views
{
    /// <summary>
    /// Interaction logic for MIS_CRM_Sales6.xaml
    /// </summary>
    public partial class MIS_CRM_Sales6 : WindowElement
    {
        public MIS_CRM_Sales6()
        {
            InitializeComponent();
            this.DataContext = new MIS_CRM_Sales6_VM();
        }
        public MIS_CRM_Sales6(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new MIS_CRM_Sales6_VM();
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
                dgPopup1.UnselectAll();
                dgPopup2.UnselectAll();
                dgunit.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MC8.Text = "";
            MC20.Text = "";
            MC10.Text = "";
            MC12.Text = "";
            MC15.Text = "";
            MC16.Text = "";
            MC17.Text = "";
            MC18.Text = "";
            MC19.Text = "";
            MC21.Text = "";
            MC22.Text = "";
            MC20.Text = "";
            MC23.Text = "";
        }
    }
}
