using Reflection.Modules.ADM.ViewModels;
using Reflection.Presentation.Windows.Controls;

namespace Reflection.Modules.ADM.Views
{
    /// <summary>
    /// Interaction logic for SDM_R02.xaml
    /// </summary>
    public partial class ADM_R02 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public ADM_R02(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new ADM_R02_VM(ts_code);
            InitializeComponent();
        }
    }
}
