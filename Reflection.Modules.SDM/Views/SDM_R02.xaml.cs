using Reflection.Modules.SDM.ViewModels;
using Reflection.Presentation.Windows.Controls;

namespace Reflection.Modules.SDM.Views
{
    /// <summary>
    /// Interaction logic for SDM_R02.xaml
    /// </summary>
    public partial class SDM_R02 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public SDM_R02(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new SDM_R02_VM(ts_code);
            InitializeComponent();
        }
    }
}
