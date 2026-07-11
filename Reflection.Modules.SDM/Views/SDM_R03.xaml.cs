using Reflection.Modules.SDM.ViewModels;
using Reflection.Presentation.Windows.Controls;

namespace Reflection.Modules.SDM.Views
{
    /// <summary>
    /// Interaction logic for SDM_R03.xaml
    /// </summary>
    public partial class SDM_R03 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public SDM_R03(string ts_code)
        {
            ts_code_vm = ts_code;
            //this.DataContext = new MIS_STD_MM_2_VM("MMI19");
            InitializeComponent();
        }
    }
}
