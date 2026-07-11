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
    /// Interaction logic for GoodsIssue_Essem.xaml
    /// </summary>
    public partial class GoodsIssue_Essem : WindowElement
    {
        public GoodsIssue_Essem(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new MM_T001_VM_MI_ESSEM(ts_code);
        }
        public GoodsIssue_Essem(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new MM_T001_VM_MI_ESSEM(ts_code,doc_no);
        }

        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopupMvType.UnselectAll();
                dgPopupEmp.UnselectAll();
                //dgPopupPlant.UnselectAll();
                dgPopupDept.UnselectAll();
                dgMake.UnselectAll();
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

        private void dgPopupIndentNo_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopupIndentNo.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
        
    }
}
