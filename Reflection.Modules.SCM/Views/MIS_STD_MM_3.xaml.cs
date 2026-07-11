using Reflection.Modules.SCM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.SCM.Views
{
    /// <summary>
    /// Interaction logic for MIS_STD_MM_2.xaml
    /// </summary>
    public partial class MIS_STD_MM_3 : WindowElement
    {
        public MIS_STD_MM_3()
        {
            this.DataContext = new MIS_STD_MM_3_VM("MMI20");
            InitializeComponent();
        }
        public MIS_STD_MM_3(string ts_code)
        {
            this.DataContext = new MIS_STD_MM_3_VM(ts_code);
            InitializeComponent();
        }
        
    }
}
