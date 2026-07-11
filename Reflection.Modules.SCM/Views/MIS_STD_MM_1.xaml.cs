using Reflection.Modules.SCM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.SCM.Views
{
    /// <summary>
    /// Interaction logic for MIS_STD_MM_1.xaml
    /// </summary>
    public partial class MIS_STD_MM_1 : WindowElement
    {
        public MIS_STD_MM_1()
        {
            this.DataContext = new MIS_STD_MM_1_VM("MMI18");
            InitializeComponent();
        }
        public MIS_STD_MM_1(string ts_code)
        {
            this.DataContext = new MIS_STD_MM_1_VM("MMI18");
            InitializeComponent();
        }
        
    }
}
