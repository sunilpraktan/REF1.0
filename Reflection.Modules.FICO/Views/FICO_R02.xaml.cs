using Reflection.Modules.FICO.ViewModels;
using Reflection.Presentation.Windows.Controls;

namespace Reflection.Modules.FICO.Views
{
    /// <summary>
    /// Interaction logic for FR_R02.xaml
    /// </summary>
    public partial class FICO_R02 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public FICO_R02(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new FICO_R02_VM(ts_code_vm);
            InitializeComponent();
        }
    }
}
