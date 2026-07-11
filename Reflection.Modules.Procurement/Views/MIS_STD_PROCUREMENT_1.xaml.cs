using Reflection.Modules.Procurement.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.Procurement.Views
{
    /// <summary>
    /// Interaction logic for MIS_STD_PROCUREMENT_1.xaml
    /// </summary>
    public partial class MIS_STD_PROCUREMENT_1 : WindowElement
    {
        public MIS_STD_PROCUREMENT_1()
        {
            this.DataContext = new MIS_STD_PROCUREMENT_1_VM("PRI18");
            InitializeComponent();
        }
        public MIS_STD_PROCUREMENT_1(string ts_code)
        {
            this.DataContext = new MIS_STD_PROCUREMENT_1_VM("PRI18");
            InitializeComponent();
        }
        
    }
}
