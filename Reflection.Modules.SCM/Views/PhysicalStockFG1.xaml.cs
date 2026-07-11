using Reflection.Modules.SCM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System.Windows;

namespace Reflection.Modules.SCM.Views
{
    /// <summary>
    /// Interaction logic for PhysicalStockFG1.xaml
    /// </summary>
    public partial class PhysicalStockFG1 : WindowElement
    {
        public PhysicalStockFG1(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new MM_S010_FG1_VM(ts_code);
        }
        public PhysicalStockFG1(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new MM_S010_FG1_VM(ts_code,doc_no);
        }

        private void dgPopupplant_Unloaded(object sender, RoutedEventArgs e)
        {
            dgCompany.UnselectAll();
            dgPopUppost.UnselectAll();
            dgUnit.UnselectAll();
            dgplant.UnselectAll();
            dgMStoreLoc.UnselectAll();
            dgData.UnselectAll();
            dgCategory.UnselectAll();
            dgSubCategory.UnselectAll();
            dgItemType.UnselectAll();
            dgSubItemType.UnselectAll();
            dgUnit.UnselectAll();
        }

        
    }
}
