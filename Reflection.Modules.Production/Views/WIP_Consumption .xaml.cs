using Reflection.Presentation.Windows.Controls;
using Reflection.Modules.Production.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace Reflection.Modules.Production.Views
{
    /// <summary>
    /// Interaction logic for WIP_Consumption.xaml
    /// </summary>
    public partial class WIP_Consumption :WindowElement
    {
        public WIP_Consumption(string ts_code)
        {
            InitializeComponent();
            this.DataContext =new MM_T001_WIP_ConsumptionVM(ts_code);
           
        }
        public WIP_Consumption(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new MM_T001_WIP_ConsumptionVM(ts_code,doc_no);

        }

        private void dgPopupEmp_Unloaded(object sender, RoutedEventArgs e)
        {
            dgPopupEmp.UnselectAll();
        }
        
    }
}
