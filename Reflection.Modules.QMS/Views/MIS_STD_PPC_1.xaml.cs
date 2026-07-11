using Reflection.Modules.QMS.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.QMS.Views
{
    /// <summary>
    /// Interaction logic for MIS_STD_PPC_1.xaml
    /// </summary>
    public partial class MIS_STD_PPC_1 : WindowElement
    {
        public MIS_STD_PPC_1()
        {
            this.DataContext = new MIS_STD_PPC_1_VM("PPI01");
            InitializeComponent();
        }
        public MIS_STD_PPC_1(string ts_code)
        {
            this.DataContext = new MIS_STD_PPC_1_VM("PPI01");
            InitializeComponent();
        }
        
    }
}
