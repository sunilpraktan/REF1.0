using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Reflection.Presentation.Windows.Controls;
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
    /// Interaction logic for MIS_SCM_Store.xaml
    /// </summary>
 

    public partial class MIS_SCM_Store : WindowElement
    {
        public MIS_SCM_Store(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new MIS_SCM_StoreVM(ts_code);
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
                dgPopup1.UnselectAll();
                dgPopup2.UnselectAll();
                dgunit.UnselectAll();
                dgCategory.UnselectAll();
                dgSubCategory.UnselectAll();
                dgFin.UnselectAll();
                dgPost1.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            MC16.Text = "";
            MC17.Text = "";
            MC18.Text = "";
            MC19.Text = "";
           
        }
    }
}
