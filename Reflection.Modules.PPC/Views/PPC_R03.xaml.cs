using Reflection.Modules.PPC.ViewModels;
using Reflection.Presentation.Windows.Controls;

namespace Reflection.Modules.PPC.Views
{
    /// <summary>
    /// Interaction logic for PPC_R03.xaml
    /// </summary>
    public partial class PPC_R03 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public PPC_R03(string ts_code)
        {
            ts_code_vm = ts_code;
            //this.DataContext = new SDM_R02_VM(ts_code);
            InitializeComponent();
        }
    }
}
