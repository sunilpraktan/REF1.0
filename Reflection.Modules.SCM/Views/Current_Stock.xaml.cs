using Reflection.Modules.SCM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using Reflection.WebServices.Gateway;
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

namespace Reflection.Modules.SCM.Views
{
    /// <summary>
    /// Interaction logic for Current_Stock.xaml
    /// </summary>
    public partial class Current_Stock : WindowElement
    {
        private string ts_code_local;
        public Current_Stock(string ts_code)
        {
            this.ts_code_local = ts_code;
            InitializeComponent();
            this.DataContext = new CurrentStockVM(ts_code);
        }
        public Current_Stock(string ts_code,string doc_no)
        {
            this.ts_code_local = ts_code;
            InitializeComponent();
            this.DataContext = new CurrentStockVM(ts_code,doc_no);
        }

        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopupplant.UnselectAll();
                dgCategory.UnselectAll();
                dgSubCategory.UnselectAll();
                dgPopupcompany.UnselectAll();
                dgPopupStore.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopupITem_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgItemValue.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopupITemType_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgItemType.UnselectAll();
                //dgSubItemType.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopupMvType_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
              // dgPopupMvType.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopupstk_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
               // dgPopupstk.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopupstkpara_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgPopupstkpara.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        
    }
}
