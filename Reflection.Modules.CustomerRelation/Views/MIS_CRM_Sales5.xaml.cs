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
using Reflection.WebServices.Gateway;
using Reflection.Modules.CustomerRelation.ViewModels;

namespace Reflection.Modules.CustomerRelation.Views
{
    /// <summary>
    /// Interaction logic for MIS_SCM_Report1.xaml
    /// </summary>
    public partial class MIS_CRM_Sales5 : WindowElement
    {
        public MIS_CRM_Sales5()
        {
            InitializeComponent();
            this.DataContext = new MIS_CRM_Sales5_VM();

        }
        public MIS_CRM_Sales5(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new MIS_CRM_Sales5_VM();

        }

        private void dgPopupLocation_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {

                dgPartyType.UnselectAll();


            }
            catch (Exception ex)
            { }
            e.Handled = true;

        }


        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PartyCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

        }
    }
}
