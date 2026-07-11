using Reflection.Modules.Production.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace Reflection.Modules.Production.Views
{
    /// <summary>
    /// Interaction logic for WritingTestForProduction_2.xaml
    /// </summary>
    public partial class WritingTestForProduction_2 : WindowElement
    {
        public WritingTestForProduction_2(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new ECRM_T003_A_VM_PROD_2(ts_code);
        }
        public WritingTestForProduction_2(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new ECRM_T003_A_VM_PROD_2(ts_code,doc_no);
        }
        private void dgUnLoaded_Event(object sender, RoutedEventArgs e)
        {
            dgPopupMachine.UnselectAll();
            dgPopupConvLot.UnselectAll();
            dgPopupTestType.UnselectAll();
            dgPopupOperator.UnselectAll();
            dgPopupShift.UnselectAll();
            dgPopupbarcode.UnselectAll();
            dgPopUpINK.UnselectAll();
            dgPopUpmodel.UnselectAll();
            dgPopUpProdct.UnselectAll();           

            e.Handled = true;
        }
        
    }
}
