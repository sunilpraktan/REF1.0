using Reflection.Modules.SDM.ViewModels;
using Reflection.Presentation.Windows.Controls;

namespace Reflection.Modules.SDM.Views
{
    /// <summary>
    /// Interaction logic for TESTUI.xaml
    /// </summary>
    public partial class TESTUI : WindowElement
    {
        public string ts_code_vm { get; set; }
        public TESTUI(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new SDM_R02_VM(ts_code);
            InitializeComponent();
        }
    }
}
