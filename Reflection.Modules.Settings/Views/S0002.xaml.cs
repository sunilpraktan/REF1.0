using Reflection.Modules.Settings.ViewModels;
using Reflection.Presentation.Windows.Controls;

namespace Reflection.Modules.Settings.Views
{
    /// <summary>
    /// Interaction logic for S0002.xaml
    /// </summary>
    public partial class S0002 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public S0002(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new SYS_S0002_VM(ts_code);
            InitializeComponent();
        }
    }
}
