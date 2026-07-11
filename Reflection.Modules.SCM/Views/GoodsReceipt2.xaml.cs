using Reflection.Modules.SCM.ViewModels;
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

namespace Reflection.Modules.SCM.Views
{
    /// <summary>
    /// Interaction logic for GoodsReceipt2.xaml
    /// </summary>
    public partial class GoodsReceipt2 : WindowElement
    {
        public GoodsReceipt2(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new MM_T001_MR_VM2(ts_code);
        }
        public GoodsReceipt2(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new MM_T001_MR_VM2(ts_code,doc_no);
        }

        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopupMvType.UnselectAll();
                dgPopupEmp.UnselectAll();
                // dgPopupPlant.UnselectAll();
                dgPopupDept.UnselectAll();
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

        private void dgPopupMvType_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopupMvType.UnselectAll();
            }
            catch
            {

            }
            e.Handled = true;
        }
        
    }
}
