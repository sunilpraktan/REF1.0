using Reflection.Modules.PPC.ViewModels;
using Reflection.Presentation.Windows.Controls;

namespace Reflection.Modules.PPC.Views
{
    /// <summary>
    /// Interaction logic for PPC_R01.xaml
    /// </summary>
    public partial class PPC_R01 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public PPC_R01(string ts_code)
        {
            ts_code_vm = ts_code;
            //this.DataContext = new MIS_STD_MM_2_VM("MMI19");
            InitializeComponent();
        }
    }
}
